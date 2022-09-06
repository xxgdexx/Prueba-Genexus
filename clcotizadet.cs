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
   public class clcotizadet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A177CotCod = GetPar( "CotCod");
            AssignAttri("", false, "A177CotCod", A177CotCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A177CotCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A28ProdCod) ;
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
            Form.Meta.addItem("description", "CLCOTIZADET", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clcotizadet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clcotizadet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCOTIZADET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Cotización", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotCod_Internalname, StringUtil.RTrim( A177CotCod), StringUtil.RTrim( context.localUtil.Format( A177CotCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A183CotDItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtCotDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A183CotDItem), "ZZZ9") : context.localUtil.Format( (decimal)(A183CotDItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cantidad", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDCan_Internalname, StringUtil.LTrim( StringUtil.NToC( A770CotDCan, 17, 4, ".", "")), StringUtil.LTrim( ((edtCotDCan_Enabled!=0) ? context.localUtil.Format( A770CotDCan, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A770CotDCan, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDCan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDCan_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Precio", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDPre_Internalname, StringUtil.LTrim( StringUtil.NToC( A771CotDPre, 16, 4, ".", "")), StringUtil.LTrim( ((edtCotDPre_Enabled!=0) ? context.localUtil.Format( A771CotDPre, "ZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A771CotDPre, "ZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDPre_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% Dscto 1", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDDsct1_Internalname, StringUtil.LTrim( StringUtil.NToC( A772CotDDsct1, 6, 2, ".", "")), StringUtil.LTrim( ((edtCotDDsct1_Enabled!=0) ? context.localUtil.Format( A772CotDDsct1, "ZZ9.99") : context.localUtil.Format( A772CotDDsct1, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDDsct1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDDsct1_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "% Dscto 2", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDDsct2_Internalname, StringUtil.LTrim( StringUtil.NToC( A773CotDDsct2, 6, 2, ".", "")), StringUtil.LTrim( ((edtCotDDsct2_Enabled!=0) ? context.localUtil.Format( A773CotDDsct2, "ZZ9.99") : context.localUtil.Format( A773CotDDsct2, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDDsct2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDDsct2_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Afecto I.G.V.", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDIna_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A774CotDIna), 1, 0, ".", "")), StringUtil.LTrim( ((edtCotDIna_Enabled!=0) ? context.localUtil.Format( (decimal)(A774CotDIna), "9") : context.localUtil.Format( (decimal)(A774CotDIna), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDIna_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "% Selectivo", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotDSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A792CotDSel, 6, 2, ".", "")), StringUtil.LTrim( ((edtCotDSel_Enabled!=0) ? context.localUtil.Format( A792CotDSel, "ZZ9.99") : context.localUtil.Format( A792CotDSel, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDSel_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Observaciones", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCotDObs_Internalname, A779CotDObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", 0, 1, edtCotDObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Total Item", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCotDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A768CotDTot, 18, 8, ".", "")), StringUtil.LTrim( ((edtCotDTot_Enabled!=0) ? context.localUtil.Format( A768CotDTot, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A768CotDTot, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCotDTot_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_CLCOTIZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOTIZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLCOTIZADET.htm");
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
            Z177CotCod = cgiGet( "Z177CotCod");
            Z183CotDItem = (short)(context.localUtil.CToN( cgiGet( "Z183CotDItem"), ".", ","));
            Z768CotDTot = context.localUtil.CToN( cgiGet( "Z768CotDTot"), ".", ",");
            Z795CotDTotInc = context.localUtil.CToN( cgiGet( "Z795CotDTotInc"), ".", ",");
            Z770CotDCan = context.localUtil.CToN( cgiGet( "Z770CotDCan"), ".", ",");
            Z771CotDPre = context.localUtil.CToN( cgiGet( "Z771CotDPre"), ".", ",");
            Z772CotDDsct1 = context.localUtil.CToN( cgiGet( "Z772CotDDsct1"), ".", ",");
            Z773CotDDsct2 = context.localUtil.CToN( cgiGet( "Z773CotDDsct2"), ".", ",");
            Z774CotDIna = (short)(context.localUtil.CToN( cgiGet( "Z774CotDIna"), ".", ","));
            Z792CotDSel = context.localUtil.CToN( cgiGet( "Z792CotDSel"), ".", ",");
            Z780CotDPreInc = context.localUtil.CToN( cgiGet( "Z780CotDPreInc"), ".", ",");
            Z781CotDRef1 = cgiGet( "Z781CotDRef1");
            Z782CotDRef2 = cgiGet( "Z782CotDRef2");
            Z783CotDRef3 = cgiGet( "Z783CotDRef3");
            Z784CotDRef4 = cgiGet( "Z784CotDRef4");
            Z785CotDRef5 = cgiGet( "Z785CotDRef5");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            A795CotDTotInc = context.localUtil.CToN( cgiGet( "Z795CotDTotInc"), ".", ",");
            A780CotDPreInc = context.localUtil.CToN( cgiGet( "Z780CotDPreInc"), ".", ",");
            A781CotDRef1 = cgiGet( "Z781CotDRef1");
            A782CotDRef2 = cgiGet( "Z782CotDRef2");
            A783CotDRef3 = cgiGet( "Z783CotDRef3");
            A784CotDRef4 = cgiGet( "Z784CotDRef4");
            A785CotDRef5 = cgiGet( "Z785CotDRef5");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A780CotDPreInc = context.localUtil.CToN( cgiGet( "COTDPREINC"), ".", ",");
            A795CotDTotInc = context.localUtil.CToN( cgiGet( "COTDTOTINC"), ".", ",");
            A769CotDSub = context.localUtil.CToN( cgiGet( "COTDSUB"), ".", ",");
            A778CotDInafecto = context.localUtil.CToN( cgiGet( "COTDINAFECTO"), ".", ",");
            A777CotDGratuito = context.localUtil.CToN( cgiGet( "COTDGRATUITO"), ".", ",");
            A776CotDExonerado = context.localUtil.CToN( cgiGet( "COTDEXONERADO"), ".", ",");
            A767CotDAfecto = context.localUtil.CToN( cgiGet( "COTDAFECTO"), ".", ",");
            A791CotDSelectivo = context.localUtil.CToN( cgiGet( "COTDSELECTIVO"), ".", ",");
            A775CotDDscto = context.localUtil.CToN( cgiGet( "COTDDSCTO"), ".", ",");
            A781CotDRef1 = cgiGet( "COTDREF1");
            A782CotDRef2 = cgiGet( "COTDREF2");
            A783CotDRef3 = cgiGet( "COTDREF3");
            A784CotDRef4 = cgiGet( "COTDREF4");
            A785CotDRef5 = cgiGet( "COTDREF5");
            /* Read variables values. */
            A177CotCod = cgiGet( edtCotCod_Internalname);
            AssignAttri("", false, "A177CotCod", A177CotCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDITEM");
               AnyError = 1;
               GX_FocusControl = edtCotDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A183CotDItem = 0;
               AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
            }
            else
            {
               A183CotDItem = (short)(context.localUtil.CToN( cgiGet( edtCotDItem_Internalname), ".", ","));
               AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDCan_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDCan_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDCAN");
               AnyError = 1;
               GX_FocusControl = edtCotDCan_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A770CotDCan = 0;
               AssignAttri("", false, "A770CotDCan", StringUtil.LTrimStr( A770CotDCan, 15, 4));
            }
            else
            {
               A770CotDCan = context.localUtil.CToN( cgiGet( edtCotDCan_Internalname), ".", ",");
               AssignAttri("", false, "A770CotDCan", StringUtil.LTrimStr( A770CotDCan, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDPre_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDPre_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDPRE");
               AnyError = 1;
               GX_FocusControl = edtCotDPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A771CotDPre = 0;
               AssignAttri("", false, "A771CotDPre", StringUtil.LTrimStr( A771CotDPre, 15, 4));
            }
            else
            {
               A771CotDPre = context.localUtil.CToN( cgiGet( edtCotDPre_Internalname), ".", ",");
               AssignAttri("", false, "A771CotDPre", StringUtil.LTrimStr( A771CotDPre, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDDsct1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDDsct1_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDDSCT1");
               AnyError = 1;
               GX_FocusControl = edtCotDDsct1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A772CotDDsct1 = 0;
               AssignAttri("", false, "A772CotDDsct1", StringUtil.LTrimStr( A772CotDDsct1, 6, 2));
            }
            else
            {
               A772CotDDsct1 = context.localUtil.CToN( cgiGet( edtCotDDsct1_Internalname), ".", ",");
               AssignAttri("", false, "A772CotDDsct1", StringUtil.LTrimStr( A772CotDDsct1, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDDsct2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDDsct2_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDDSCT2");
               AnyError = 1;
               GX_FocusControl = edtCotDDsct2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A773CotDDsct2 = 0;
               AssignAttri("", false, "A773CotDDsct2", StringUtil.LTrimStr( A773CotDDsct2, 6, 2));
            }
            else
            {
               A773CotDDsct2 = context.localUtil.CToN( cgiGet( edtCotDDsct2_Internalname), ".", ",");
               AssignAttri("", false, "A773CotDDsct2", StringUtil.LTrimStr( A773CotDDsct2, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDIna_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDIna_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDINA");
               AnyError = 1;
               GX_FocusControl = edtCotDIna_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A774CotDIna = 0;
               AssignAttri("", false, "A774CotDIna", StringUtil.Str( (decimal)(A774CotDIna), 1, 0));
            }
            else
            {
               A774CotDIna = (short)(context.localUtil.CToN( cgiGet( edtCotDIna_Internalname), ".", ","));
               AssignAttri("", false, "A774CotDIna", StringUtil.Str( (decimal)(A774CotDIna), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCotDSel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCotDSel_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COTDSEL");
               AnyError = 1;
               GX_FocusControl = edtCotDSel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A792CotDSel = 0;
               AssignAttri("", false, "A792CotDSel", StringUtil.LTrimStr( A792CotDSel, 6, 2));
            }
            else
            {
               A792CotDSel = context.localUtil.CToN( cgiGet( edtCotDSel_Internalname), ".", ",");
               AssignAttri("", false, "A792CotDSel", StringUtil.LTrimStr( A792CotDSel, 6, 2));
            }
            A779CotDObs = cgiGet( edtCotDObs_Internalname);
            AssignAttri("", false, "A779CotDObs", A779CotDObs);
            A768CotDTot = context.localUtil.CToN( cgiGet( edtCotDTot_Internalname), ".", ",");
            AssignAttri("", false, "A768CotDTot", StringUtil.LTrimStr( A768CotDTot, 18, 8));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLCOTIZADET");
            forbiddenHiddens.Add("CotDPreInc", context.localUtil.Format( A780CotDPreInc, "ZZZZ,ZZZ,ZZ9.9999"));
            forbiddenHiddens.Add("CotDRef1", StringUtil.RTrim( context.localUtil.Format( A781CotDRef1, "")));
            forbiddenHiddens.Add("CotDRef2", StringUtil.RTrim( context.localUtil.Format( A782CotDRef2, "")));
            forbiddenHiddens.Add("CotDRef3", StringUtil.RTrim( context.localUtil.Format( A783CotDRef3, "")));
            forbiddenHiddens.Add("CotDRef4", StringUtil.RTrim( context.localUtil.Format( A784CotDRef4, "")));
            forbiddenHiddens.Add("CotDRef5", StringUtil.RTrim( context.localUtil.Format( A785CotDRef5, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 ) || ( A183CotDItem != Z183CotDItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clcotizadet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A177CotCod = GetPar( "CotCod");
               AssignAttri("", false, "A177CotCod", A177CotCod);
               A183CotDItem = (short)(NumberUtil.Val( GetPar( "CotDItem"), "."));
               AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
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
               InitAll2J87( ) ;
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
         DisableAttributes2J87( ) ;
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

      protected void CONFIRM_2J0( )
      {
         BeforeValidate2J87( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2J87( ) ;
            }
            else
            {
               CheckExtendedTable2J87( ) ;
               if ( AnyError == 0 )
               {
                  ZM2J87( 11) ;
                  ZM2J87( 12) ;
               }
               CloseExtendedTableCursors2J87( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2J0( ) ;
         }
      }

      protected void ResetCaption2J0( )
      {
      }

      protected void ZM2J87( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z768CotDTot = T002J3_A768CotDTot[0];
               Z795CotDTotInc = T002J3_A795CotDTotInc[0];
               Z770CotDCan = T002J3_A770CotDCan[0];
               Z771CotDPre = T002J3_A771CotDPre[0];
               Z772CotDDsct1 = T002J3_A772CotDDsct1[0];
               Z773CotDDsct2 = T002J3_A773CotDDsct2[0];
               Z774CotDIna = T002J3_A774CotDIna[0];
               Z792CotDSel = T002J3_A792CotDSel[0];
               Z780CotDPreInc = T002J3_A780CotDPreInc[0];
               Z781CotDRef1 = T002J3_A781CotDRef1[0];
               Z782CotDRef2 = T002J3_A782CotDRef2[0];
               Z783CotDRef3 = T002J3_A783CotDRef3[0];
               Z784CotDRef4 = T002J3_A784CotDRef4[0];
               Z785CotDRef5 = T002J3_A785CotDRef5[0];
               Z28ProdCod = T002J3_A28ProdCod[0];
            }
            else
            {
               Z768CotDTot = A768CotDTot;
               Z795CotDTotInc = A795CotDTotInc;
               Z770CotDCan = A770CotDCan;
               Z771CotDPre = A771CotDPre;
               Z772CotDDsct1 = A772CotDDsct1;
               Z773CotDDsct2 = A773CotDDsct2;
               Z774CotDIna = A774CotDIna;
               Z792CotDSel = A792CotDSel;
               Z780CotDPreInc = A780CotDPreInc;
               Z781CotDRef1 = A781CotDRef1;
               Z782CotDRef2 = A782CotDRef2;
               Z783CotDRef3 = A783CotDRef3;
               Z784CotDRef4 = A784CotDRef4;
               Z785CotDRef5 = A785CotDRef5;
               Z28ProdCod = A28ProdCod;
            }
         }
         if ( GX_JID == -10 )
         {
            Z768CotDTot = A768CotDTot;
            Z795CotDTotInc = A795CotDTotInc;
            Z183CotDItem = A183CotDItem;
            Z770CotDCan = A770CotDCan;
            Z771CotDPre = A771CotDPre;
            Z772CotDDsct1 = A772CotDDsct1;
            Z773CotDDsct2 = A773CotDDsct2;
            Z774CotDIna = A774CotDIna;
            Z792CotDSel = A792CotDSel;
            Z779CotDObs = A779CotDObs;
            Z780CotDPreInc = A780CotDPreInc;
            Z781CotDRef1 = A781CotDRef1;
            Z782CotDRef2 = A782CotDRef2;
            Z783CotDRef3 = A783CotDRef3;
            Z784CotDRef4 = A784CotDRef4;
            Z785CotDRef5 = A785CotDRef5;
            Z177CotCod = A177CotCod;
            Z28ProdCod = A28ProdCod;
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

      protected void Load2J87( )
      {
         /* Using cursor T002J6 */
         pr_default.execute(4, new Object[] {A177CotCod, A183CotDItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound87 = 1;
            A768CotDTot = T002J6_A768CotDTot[0];
            AssignAttri("", false, "A768CotDTot", StringUtil.LTrimStr( A768CotDTot, 18, 8));
            A795CotDTotInc = T002J6_A795CotDTotInc[0];
            A770CotDCan = T002J6_A770CotDCan[0];
            AssignAttri("", false, "A770CotDCan", StringUtil.LTrimStr( A770CotDCan, 15, 4));
            A771CotDPre = T002J6_A771CotDPre[0];
            AssignAttri("", false, "A771CotDPre", StringUtil.LTrimStr( A771CotDPre, 15, 4));
            A772CotDDsct1 = T002J6_A772CotDDsct1[0];
            AssignAttri("", false, "A772CotDDsct1", StringUtil.LTrimStr( A772CotDDsct1, 6, 2));
            A773CotDDsct2 = T002J6_A773CotDDsct2[0];
            AssignAttri("", false, "A773CotDDsct2", StringUtil.LTrimStr( A773CotDDsct2, 6, 2));
            A774CotDIna = T002J6_A774CotDIna[0];
            AssignAttri("", false, "A774CotDIna", StringUtil.Str( (decimal)(A774CotDIna), 1, 0));
            A792CotDSel = T002J6_A792CotDSel[0];
            AssignAttri("", false, "A792CotDSel", StringUtil.LTrimStr( A792CotDSel, 6, 2));
            A779CotDObs = T002J6_A779CotDObs[0];
            AssignAttri("", false, "A779CotDObs", A779CotDObs);
            A780CotDPreInc = T002J6_A780CotDPreInc[0];
            A781CotDRef1 = T002J6_A781CotDRef1[0];
            A782CotDRef2 = T002J6_A782CotDRef2[0];
            A783CotDRef3 = T002J6_A783CotDRef3[0];
            A784CotDRef4 = T002J6_A784CotDRef4[0];
            A785CotDRef5 = T002J6_A785CotDRef5[0];
            A28ProdCod = T002J6_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            ZM2J87( -10) ;
         }
         pr_default.close(4);
         OnLoadActions2J87( ) ;
      }

      protected void OnLoadActions2J87( )
      {
         A795CotDTotInc = NumberUtil.Round( (A780CotDPreInc*A770CotDCan)*(1-(A772CotDDsct1/ (decimal)(100)))*(1-(A773CotDDsct2/ (decimal)(100))), 2);
         AssignAttri("", false, "A795CotDTotInc", StringUtil.LTrimStr( A795CotDTotInc, 15, 4));
         A769CotDSub = NumberUtil.Round( A770CotDCan*A771CotDPre, 4);
         AssignAttri("", false, "A769CotDSub", StringUtil.LTrimStr( A769CotDSub, 15, 4));
         A768CotDTot = NumberUtil.Round( (A769CotDSub)*(1-(A772CotDDsct1/ (decimal)(100)))*(1-(A773CotDDsct2/ (decimal)(100))), 2);
         AssignAttri("", false, "A768CotDTot", StringUtil.LTrimStr( A768CotDTot, 18, 8));
         A775CotDDscto = NumberUtil.Round( A768CotDTot-A769CotDSub, 2);
         AssignAttri("", false, "A775CotDDscto", StringUtil.LTrimStr( A775CotDDscto, 15, 2));
         if ( ( A774CotDIna == 1 ) || ( A774CotDIna == 4 ) )
         {
            A778CotDInafecto = A768CotDTot;
            AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
         }
         else
         {
            A778CotDInafecto = 0;
            AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
         }
         if ( A774CotDIna == 3 )
         {
            A777CotDGratuito = A768CotDTot;
            AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
         }
         else
         {
            A777CotDGratuito = 0;
            AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
         }
         if ( A774CotDIna == 2 )
         {
            A776CotDExonerado = A768CotDTot;
            AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
         }
         else
         {
            A776CotDExonerado = 0;
            AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
         }
         if ( A774CotDIna == 0 )
         {
            A767CotDAfecto = A768CotDTot;
            AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
         }
         else
         {
            A767CotDAfecto = 0;
            AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
         }
         A791CotDSelectivo = NumberUtil.Round( (A768CotDTot*A792CotDSel)/ (decimal)(100), 2);
         AssignAttri("", false, "A791CotDSelectivo", StringUtil.LTrimStr( A791CotDSelectivo, 15, 2));
      }

      protected void CheckExtendedTable2J87( )
      {
         nIsDirty_87 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002J4 */
         pr_default.execute(2, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Cotizacion'.", "ForeignKeyNotFound", 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002J5 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         nIsDirty_87 = 1;
         A795CotDTotInc = NumberUtil.Round( (A780CotDPreInc*A770CotDCan)*(1-(A772CotDDsct1/ (decimal)(100)))*(1-(A773CotDDsct2/ (decimal)(100))), 2);
         AssignAttri("", false, "A795CotDTotInc", StringUtil.LTrimStr( A795CotDTotInc, 15, 4));
         nIsDirty_87 = 1;
         A769CotDSub = NumberUtil.Round( A770CotDCan*A771CotDPre, 4);
         AssignAttri("", false, "A769CotDSub", StringUtil.LTrimStr( A769CotDSub, 15, 4));
         nIsDirty_87 = 1;
         A768CotDTot = NumberUtil.Round( (A769CotDSub)*(1-(A772CotDDsct1/ (decimal)(100)))*(1-(A773CotDDsct2/ (decimal)(100))), 2);
         AssignAttri("", false, "A768CotDTot", StringUtil.LTrimStr( A768CotDTot, 18, 8));
         nIsDirty_87 = 1;
         A775CotDDscto = NumberUtil.Round( A768CotDTot-A769CotDSub, 2);
         AssignAttri("", false, "A775CotDDscto", StringUtil.LTrimStr( A775CotDDscto, 15, 2));
         if ( ( A774CotDIna == 1 ) || ( A774CotDIna == 4 ) )
         {
            nIsDirty_87 = 1;
            A778CotDInafecto = A768CotDTot;
            AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
         }
         else
         {
            nIsDirty_87 = 1;
            A778CotDInafecto = 0;
            AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
         }
         if ( A774CotDIna == 3 )
         {
            nIsDirty_87 = 1;
            A777CotDGratuito = A768CotDTot;
            AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
         }
         else
         {
            nIsDirty_87 = 1;
            A777CotDGratuito = 0;
            AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
         }
         if ( A774CotDIna == 2 )
         {
            nIsDirty_87 = 1;
            A776CotDExonerado = A768CotDTot;
            AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
         }
         else
         {
            nIsDirty_87 = 1;
            A776CotDExonerado = 0;
            AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
         }
         if ( A774CotDIna == 0 )
         {
            nIsDirty_87 = 1;
            A767CotDAfecto = A768CotDTot;
            AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
         }
         else
         {
            nIsDirty_87 = 1;
            A767CotDAfecto = 0;
            AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
         }
         nIsDirty_87 = 1;
         A791CotDSelectivo = NumberUtil.Round( (A768CotDTot*A792CotDSel)/ (decimal)(100), 2);
         AssignAttri("", false, "A791CotDSelectivo", StringUtil.LTrimStr( A791CotDSelectivo, 15, 2));
      }

      protected void CloseExtendedTableCursors2J87( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( string A177CotCod )
      {
         /* Using cursor T002J7 */
         pr_default.execute(5, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Cotizacion'.", "ForeignKeyNotFound", 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
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

      protected void gxLoad_12( string A28ProdCod )
      {
         /* Using cursor T002J8 */
         pr_default.execute(6, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
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

      protected void GetKey2J87( )
      {
         /* Using cursor T002J9 */
         pr_default.execute(7, new Object[] {A177CotCod, A183CotDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound87 = 1;
         }
         else
         {
            RcdFound87 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002J3 */
         pr_default.execute(1, new Object[] {A177CotCod, A183CotDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2J87( 10) ;
            RcdFound87 = 1;
            A768CotDTot = T002J3_A768CotDTot[0];
            AssignAttri("", false, "A768CotDTot", StringUtil.LTrimStr( A768CotDTot, 18, 8));
            A795CotDTotInc = T002J3_A795CotDTotInc[0];
            A183CotDItem = T002J3_A183CotDItem[0];
            AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
            A770CotDCan = T002J3_A770CotDCan[0];
            AssignAttri("", false, "A770CotDCan", StringUtil.LTrimStr( A770CotDCan, 15, 4));
            A771CotDPre = T002J3_A771CotDPre[0];
            AssignAttri("", false, "A771CotDPre", StringUtil.LTrimStr( A771CotDPre, 15, 4));
            A772CotDDsct1 = T002J3_A772CotDDsct1[0];
            AssignAttri("", false, "A772CotDDsct1", StringUtil.LTrimStr( A772CotDDsct1, 6, 2));
            A773CotDDsct2 = T002J3_A773CotDDsct2[0];
            AssignAttri("", false, "A773CotDDsct2", StringUtil.LTrimStr( A773CotDDsct2, 6, 2));
            A774CotDIna = T002J3_A774CotDIna[0];
            AssignAttri("", false, "A774CotDIna", StringUtil.Str( (decimal)(A774CotDIna), 1, 0));
            A792CotDSel = T002J3_A792CotDSel[0];
            AssignAttri("", false, "A792CotDSel", StringUtil.LTrimStr( A792CotDSel, 6, 2));
            A779CotDObs = T002J3_A779CotDObs[0];
            AssignAttri("", false, "A779CotDObs", A779CotDObs);
            A780CotDPreInc = T002J3_A780CotDPreInc[0];
            A781CotDRef1 = T002J3_A781CotDRef1[0];
            A782CotDRef2 = T002J3_A782CotDRef2[0];
            A783CotDRef3 = T002J3_A783CotDRef3[0];
            A784CotDRef4 = T002J3_A784CotDRef4[0];
            A785CotDRef5 = T002J3_A785CotDRef5[0];
            A177CotCod = T002J3_A177CotCod[0];
            AssignAttri("", false, "A177CotCod", A177CotCod);
            A28ProdCod = T002J3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z177CotCod = A177CotCod;
            Z183CotDItem = A183CotDItem;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2J87( ) ;
            if ( AnyError == 1 )
            {
               RcdFound87 = 0;
               InitializeNonKey2J87( ) ;
            }
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound87 = 0;
            InitializeNonKey2J87( ) ;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode87;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2J87( ) ;
         if ( RcdFound87 == 0 )
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
         RcdFound87 = 0;
         /* Using cursor T002J10 */
         pr_default.execute(8, new Object[] {A177CotCod, A183CotDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002J10_A177CotCod[0], A177CotCod) < 0 ) || ( StringUtil.StrCmp(T002J10_A177CotCod[0], A177CotCod) == 0 ) && ( T002J10_A183CotDItem[0] < A183CotDItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002J10_A177CotCod[0], A177CotCod) > 0 ) || ( StringUtil.StrCmp(T002J10_A177CotCod[0], A177CotCod) == 0 ) && ( T002J10_A183CotDItem[0] > A183CotDItem ) ) )
            {
               A177CotCod = T002J10_A177CotCod[0];
               AssignAttri("", false, "A177CotCod", A177CotCod);
               A183CotDItem = T002J10_A183CotDItem[0];
               AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
               RcdFound87 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound87 = 0;
         /* Using cursor T002J11 */
         pr_default.execute(9, new Object[] {A177CotCod, A183CotDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002J11_A177CotCod[0], A177CotCod) > 0 ) || ( StringUtil.StrCmp(T002J11_A177CotCod[0], A177CotCod) == 0 ) && ( T002J11_A183CotDItem[0] > A183CotDItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002J11_A177CotCod[0], A177CotCod) < 0 ) || ( StringUtil.StrCmp(T002J11_A177CotCod[0], A177CotCod) == 0 ) && ( T002J11_A183CotDItem[0] < A183CotDItem ) ) )
            {
               A177CotCod = T002J11_A177CotCod[0];
               AssignAttri("", false, "A177CotCod", A177CotCod);
               A183CotDItem = T002J11_A183CotDItem[0];
               AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
               RcdFound87 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2J87( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2J87( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound87 == 1 )
            {
               if ( ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 ) || ( A183CotDItem != Z183CotDItem ) )
               {
                  A177CotCod = Z177CotCod;
                  AssignAttri("", false, "A177CotCod", A177CotCod);
                  A183CotDItem = Z183CotDItem;
                  AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2J87( ) ;
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 ) || ( A183CotDItem != Z183CotDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCotCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2J87( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCotCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCotCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2J87( ) ;
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
         if ( ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 ) || ( A183CotDItem != Z183CotDItem ) )
         {
            A177CotCod = Z177CotCod;
            AssignAttri("", false, "A177CotCod", A177CotCod);
            A183CotDItem = Z183CotDItem;
            AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCotCod_Internalname;
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
         GetKey2J87( ) ;
         if ( RcdFound87 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "COTCOD");
               AnyError = 1;
               GX_FocusControl = edtCotCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 ) || ( A183CotDItem != Z183CotDItem ) )
            {
               A177CotCod = Z177CotCod;
               AssignAttri("", false, "A177CotCod", A177CotCod);
               A183CotDItem = Z183CotDItem;
               AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "COTCOD");
               AnyError = 1;
               GX_FocusControl = edtCotCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A177CotCod, Z177CotCod) != 0 ) || ( A183CotDItem != Z183CotDItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCotCod_Internalname;
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
         context.RollbackDataStores("clcotizadet",pr_default);
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2J0( ) ;
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
         if ( RcdFound87 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2J87( ) ;
         if ( RcdFound87 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2J87( ) ;
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
         if ( RcdFound87 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
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
         if ( RcdFound87 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
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
         ScanStart2J87( ) ;
         if ( RcdFound87 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound87 != 0 )
            {
               ScanNext2J87( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2J87( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2J87( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002J2 */
            pr_default.execute(0, new Object[] {A177CotCod, A183CotDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOTIZADET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z768CotDTot != T002J2_A768CotDTot[0] ) || ( Z795CotDTotInc != T002J2_A795CotDTotInc[0] ) || ( Z770CotDCan != T002J2_A770CotDCan[0] ) || ( Z771CotDPre != T002J2_A771CotDPre[0] ) || ( Z772CotDDsct1 != T002J2_A772CotDDsct1[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z773CotDDsct2 != T002J2_A773CotDDsct2[0] ) || ( Z774CotDIna != T002J2_A774CotDIna[0] ) || ( Z792CotDSel != T002J2_A792CotDSel[0] ) || ( Z780CotDPreInc != T002J2_A780CotDPreInc[0] ) || ( StringUtil.StrCmp(Z781CotDRef1, T002J2_A781CotDRef1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z782CotDRef2, T002J2_A782CotDRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z783CotDRef3, T002J2_A783CotDRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z784CotDRef4, T002J2_A784CotDRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z785CotDRef5, T002J2_A785CotDRef5[0]) != 0 ) || ( StringUtil.StrCmp(Z28ProdCod, T002J2_A28ProdCod[0]) != 0 ) )
            {
               if ( Z768CotDTot != T002J2_A768CotDTot[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDTot");
                  GXUtil.WriteLogRaw("Old: ",Z768CotDTot);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A768CotDTot[0]);
               }
               if ( Z795CotDTotInc != T002J2_A795CotDTotInc[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDTotInc");
                  GXUtil.WriteLogRaw("Old: ",Z795CotDTotInc);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A795CotDTotInc[0]);
               }
               if ( Z770CotDCan != T002J2_A770CotDCan[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDCan");
                  GXUtil.WriteLogRaw("Old: ",Z770CotDCan);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A770CotDCan[0]);
               }
               if ( Z771CotDPre != T002J2_A771CotDPre[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDPre");
                  GXUtil.WriteLogRaw("Old: ",Z771CotDPre);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A771CotDPre[0]);
               }
               if ( Z772CotDDsct1 != T002J2_A772CotDDsct1[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDDsct1");
                  GXUtil.WriteLogRaw("Old: ",Z772CotDDsct1);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A772CotDDsct1[0]);
               }
               if ( Z773CotDDsct2 != T002J2_A773CotDDsct2[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDDsct2");
                  GXUtil.WriteLogRaw("Old: ",Z773CotDDsct2);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A773CotDDsct2[0]);
               }
               if ( Z774CotDIna != T002J2_A774CotDIna[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDIna");
                  GXUtil.WriteLogRaw("Old: ",Z774CotDIna);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A774CotDIna[0]);
               }
               if ( Z792CotDSel != T002J2_A792CotDSel[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDSel");
                  GXUtil.WriteLogRaw("Old: ",Z792CotDSel);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A792CotDSel[0]);
               }
               if ( Z780CotDPreInc != T002J2_A780CotDPreInc[0] )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDPreInc");
                  GXUtil.WriteLogRaw("Old: ",Z780CotDPreInc);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A780CotDPreInc[0]);
               }
               if ( StringUtil.StrCmp(Z781CotDRef1, T002J2_A781CotDRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDRef1");
                  GXUtil.WriteLogRaw("Old: ",Z781CotDRef1);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A781CotDRef1[0]);
               }
               if ( StringUtil.StrCmp(Z782CotDRef2, T002J2_A782CotDRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDRef2");
                  GXUtil.WriteLogRaw("Old: ",Z782CotDRef2);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A782CotDRef2[0]);
               }
               if ( StringUtil.StrCmp(Z783CotDRef3, T002J2_A783CotDRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDRef3");
                  GXUtil.WriteLogRaw("Old: ",Z783CotDRef3);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A783CotDRef3[0]);
               }
               if ( StringUtil.StrCmp(Z784CotDRef4, T002J2_A784CotDRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDRef4");
                  GXUtil.WriteLogRaw("Old: ",Z784CotDRef4);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A784CotDRef4[0]);
               }
               if ( StringUtil.StrCmp(Z785CotDRef5, T002J2_A785CotDRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"CotDRef5");
                  GXUtil.WriteLogRaw("Old: ",Z785CotDRef5);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A785CotDRef5[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T002J2_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcotizadet:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T002J2_A28ProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCOTIZADET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2J87( )
      {
         BeforeValidate2J87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J87( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2J87( 0) ;
            CheckOptimisticConcurrency2J87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2J87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002J12 */
                     pr_default.execute(10, new Object[] {A768CotDTot, A795CotDTotInc, A183CotDItem, A770CotDCan, A771CotDPre, A772CotDDsct1, A773CotDDsct2, A774CotDIna, A792CotDSel, A779CotDObs, A780CotDPreInc, A781CotDRef1, A782CotDRef2, A783CotDRef3, A784CotDRef4, A785CotDRef5, A177CotCod, A28ProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZADET");
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
                           ResetCaption2J0( ) ;
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
               Load2J87( ) ;
            }
            EndLevel2J87( ) ;
         }
         CloseExtendedTableCursors2J87( ) ;
      }

      protected void Update2J87( )
      {
         BeforeValidate2J87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J87( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2J87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002J13 */
                     pr_default.execute(11, new Object[] {A768CotDTot, A795CotDTotInc, A770CotDCan, A771CotDPre, A772CotDDsct1, A773CotDDsct2, A774CotDIna, A792CotDSel, A779CotDObs, A780CotDPreInc, A781CotDRef1, A782CotDRef2, A783CotDRef3, A784CotDRef4, A785CotDRef5, A28ProdCod, A177CotCod, A183CotDItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZADET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOTIZADET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2J87( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2J0( ) ;
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
            EndLevel2J87( ) ;
         }
         CloseExtendedTableCursors2J87( ) ;
      }

      protected void DeferredUpdate2J87( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2J87( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J87( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2J87( ) ;
            AfterConfirm2J87( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2J87( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002J14 */
                  pr_default.execute(12, new Object[] {A177CotCod, A183CotDItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZADET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound87 == 0 )
                        {
                           InitAll2J87( ) ;
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
                        ResetCaption2J0( ) ;
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
         sMode87 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2J87( ) ;
         Gx_mode = sMode87;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2J87( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A769CotDSub = NumberUtil.Round( A770CotDCan*A771CotDPre, 4);
            AssignAttri("", false, "A769CotDSub", StringUtil.LTrimStr( A769CotDSub, 15, 4));
            if ( ( A774CotDIna == 1 ) || ( A774CotDIna == 4 ) )
            {
               A778CotDInafecto = A768CotDTot;
               AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
            }
            else
            {
               A778CotDInafecto = 0;
               AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
            }
            if ( A774CotDIna == 3 )
            {
               A777CotDGratuito = A768CotDTot;
               AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
            }
            else
            {
               A777CotDGratuito = 0;
               AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
            }
            if ( A774CotDIna == 2 )
            {
               A776CotDExonerado = A768CotDTot;
               AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
            }
            else
            {
               A776CotDExonerado = 0;
               AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
            }
            if ( A774CotDIna == 0 )
            {
               A767CotDAfecto = A768CotDTot;
               AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
            }
            else
            {
               A767CotDAfecto = 0;
               AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
            }
            A791CotDSelectivo = NumberUtil.Round( (A768CotDTot*A792CotDSel)/ (decimal)(100), 2);
            AssignAttri("", false, "A791CotDSelectivo", StringUtil.LTrimStr( A791CotDSelectivo, 15, 2));
            A775CotDDscto = NumberUtil.Round( A768CotDTot-A769CotDSub, 2);
            AssignAttri("", false, "A775CotDDscto", StringUtil.LTrimStr( A775CotDDscto, 15, 2));
         }
      }

      protected void EndLevel2J87( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2J87( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clcotizadet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clcotizadet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2J87( )
      {
         /* Using cursor T002J15 */
         pr_default.execute(13);
         RcdFound87 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound87 = 1;
            A177CotCod = T002J15_A177CotCod[0];
            AssignAttri("", false, "A177CotCod", A177CotCod);
            A183CotDItem = T002J15_A183CotDItem[0];
            AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2J87( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound87 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound87 = 1;
            A177CotCod = T002J15_A177CotCod[0];
            AssignAttri("", false, "A177CotCod", A177CotCod);
            A183CotDItem = T002J15_A183CotDItem[0];
            AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
         }
      }

      protected void ScanEnd2J87( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2J87( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2J87( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2J87( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2J87( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2J87( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2J87( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2J87( )
      {
         edtCotCod_Enabled = 0;
         AssignProp("", false, edtCotCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotCod_Enabled), 5, 0), true);
         edtCotDItem_Enabled = 0;
         AssignProp("", false, edtCotDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDItem_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtCotDCan_Enabled = 0;
         AssignProp("", false, edtCotDCan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDCan_Enabled), 5, 0), true);
         edtCotDPre_Enabled = 0;
         AssignProp("", false, edtCotDPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDPre_Enabled), 5, 0), true);
         edtCotDDsct1_Enabled = 0;
         AssignProp("", false, edtCotDDsct1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDDsct1_Enabled), 5, 0), true);
         edtCotDDsct2_Enabled = 0;
         AssignProp("", false, edtCotDDsct2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDDsct2_Enabled), 5, 0), true);
         edtCotDIna_Enabled = 0;
         AssignProp("", false, edtCotDIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDIna_Enabled), 5, 0), true);
         edtCotDSel_Enabled = 0;
         AssignProp("", false, edtCotDSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDSel_Enabled), 5, 0), true);
         edtCotDObs_Enabled = 0;
         AssignProp("", false, edtCotDObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDObs_Enabled), 5, 0), true);
         edtCotDTot_Enabled = 0;
         AssignProp("", false, edtCotDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotDTot_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2J87( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816424414", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clcotizadet.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLCOTIZADET");
         forbiddenHiddens.Add("CotDPreInc", context.localUtil.Format( A780CotDPreInc, "ZZZZ,ZZZ,ZZ9.9999"));
         forbiddenHiddens.Add("CotDRef1", StringUtil.RTrim( context.localUtil.Format( A781CotDRef1, "")));
         forbiddenHiddens.Add("CotDRef2", StringUtil.RTrim( context.localUtil.Format( A782CotDRef2, "")));
         forbiddenHiddens.Add("CotDRef3", StringUtil.RTrim( context.localUtil.Format( A783CotDRef3, "")));
         forbiddenHiddens.Add("CotDRef4", StringUtil.RTrim( context.localUtil.Format( A784CotDRef4, "")));
         forbiddenHiddens.Add("CotDRef5", StringUtil.RTrim( context.localUtil.Format( A785CotDRef5, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clcotizadet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z177CotCod", StringUtil.RTrim( Z177CotCod));
         GxWebStd.gx_hidden_field( context, "Z183CotDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z183CotDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z768CotDTot", StringUtil.LTrim( StringUtil.NToC( Z768CotDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z795CotDTotInc", StringUtil.LTrim( StringUtil.NToC( Z795CotDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z770CotDCan", StringUtil.LTrim( StringUtil.NToC( Z770CotDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z771CotDPre", StringUtil.LTrim( StringUtil.NToC( Z771CotDPre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z772CotDDsct1", StringUtil.LTrim( StringUtil.NToC( Z772CotDDsct1, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z773CotDDsct2", StringUtil.LTrim( StringUtil.NToC( Z773CotDDsct2, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z774CotDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z774CotDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z792CotDSel", StringUtil.LTrim( StringUtil.NToC( Z792CotDSel, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z780CotDPreInc", StringUtil.LTrim( StringUtil.NToC( Z780CotDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z781CotDRef1", Z781CotDRef1);
         GxWebStd.gx_hidden_field( context, "Z782CotDRef2", Z782CotDRef2);
         GxWebStd.gx_hidden_field( context, "Z783CotDRef3", Z783CotDRef3);
         GxWebStd.gx_hidden_field( context, "Z784CotDRef4", Z784CotDRef4);
         GxWebStd.gx_hidden_field( context, "Z785CotDRef5", Z785CotDRef5);
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "COTDPREINC", StringUtil.LTrim( StringUtil.NToC( A780CotDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDTOTINC", StringUtil.LTrim( StringUtil.NToC( A795CotDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDSUB", StringUtil.LTrim( StringUtil.NToC( A769CotDSub, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDINAFECTO", StringUtil.LTrim( StringUtil.NToC( A778CotDInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDGRATUITO", StringUtil.LTrim( StringUtil.NToC( A777CotDGratuito, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDEXONERADO", StringUtil.LTrim( StringUtil.NToC( A776CotDExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDAFECTO", StringUtil.LTrim( StringUtil.NToC( A767CotDAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDSELECTIVO", StringUtil.LTrim( StringUtil.NToC( A791CotDSelectivo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDDSCTO", StringUtil.LTrim( StringUtil.NToC( A775CotDDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COTDREF1", A781CotDRef1);
         GxWebStd.gx_hidden_field( context, "COTDREF2", A782CotDRef2);
         GxWebStd.gx_hidden_field( context, "COTDREF3", A783CotDRef3);
         GxWebStd.gx_hidden_field( context, "COTDREF4", A784CotDRef4);
         GxWebStd.gx_hidden_field( context, "COTDREF5", A785CotDRef5);
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
         return formatLink("clcotizadet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCOTIZADET" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLCOTIZADET" ;
      }

      protected void InitializeNonKey2J87( )
      {
         A775CotDDscto = 0;
         AssignAttri("", false, "A775CotDDscto", StringUtil.LTrimStr( A775CotDDscto, 15, 2));
         A791CotDSelectivo = 0;
         AssignAttri("", false, "A791CotDSelectivo", StringUtil.LTrimStr( A791CotDSelectivo, 15, 2));
         A767CotDAfecto = 0;
         AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrimStr( A767CotDAfecto, 15, 2));
         A776CotDExonerado = 0;
         AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrimStr( A776CotDExonerado, 15, 2));
         A777CotDGratuito = 0;
         AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrimStr( A777CotDGratuito, 15, 2));
         A778CotDInafecto = 0;
         AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrimStr( A778CotDInafecto, 15, 2));
         A768CotDTot = 0;
         AssignAttri("", false, "A768CotDTot", StringUtil.LTrimStr( A768CotDTot, 18, 8));
         A769CotDSub = 0;
         AssignAttri("", false, "A769CotDSub", StringUtil.LTrimStr( A769CotDSub, 15, 4));
         A795CotDTotInc = 0;
         AssignAttri("", false, "A795CotDTotInc", StringUtil.LTrimStr( A795CotDTotInc, 15, 4));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A770CotDCan = 0;
         AssignAttri("", false, "A770CotDCan", StringUtil.LTrimStr( A770CotDCan, 15, 4));
         A771CotDPre = 0;
         AssignAttri("", false, "A771CotDPre", StringUtil.LTrimStr( A771CotDPre, 15, 4));
         A772CotDDsct1 = 0;
         AssignAttri("", false, "A772CotDDsct1", StringUtil.LTrimStr( A772CotDDsct1, 6, 2));
         A773CotDDsct2 = 0;
         AssignAttri("", false, "A773CotDDsct2", StringUtil.LTrimStr( A773CotDDsct2, 6, 2));
         A774CotDIna = 0;
         AssignAttri("", false, "A774CotDIna", StringUtil.Str( (decimal)(A774CotDIna), 1, 0));
         A792CotDSel = 0;
         AssignAttri("", false, "A792CotDSel", StringUtil.LTrimStr( A792CotDSel, 6, 2));
         A779CotDObs = "";
         AssignAttri("", false, "A779CotDObs", A779CotDObs);
         A780CotDPreInc = 0;
         AssignAttri("", false, "A780CotDPreInc", StringUtil.LTrimStr( A780CotDPreInc, 15, 4));
         A781CotDRef1 = "";
         AssignAttri("", false, "A781CotDRef1", A781CotDRef1);
         A782CotDRef2 = "";
         AssignAttri("", false, "A782CotDRef2", A782CotDRef2);
         A783CotDRef3 = "";
         AssignAttri("", false, "A783CotDRef3", A783CotDRef3);
         A784CotDRef4 = "";
         AssignAttri("", false, "A784CotDRef4", A784CotDRef4);
         A785CotDRef5 = "";
         AssignAttri("", false, "A785CotDRef5", A785CotDRef5);
         Z768CotDTot = 0;
         Z795CotDTotInc = 0;
         Z770CotDCan = 0;
         Z771CotDPre = 0;
         Z772CotDDsct1 = 0;
         Z773CotDDsct2 = 0;
         Z774CotDIna = 0;
         Z792CotDSel = 0;
         Z780CotDPreInc = 0;
         Z781CotDRef1 = "";
         Z782CotDRef2 = "";
         Z783CotDRef3 = "";
         Z784CotDRef4 = "";
         Z785CotDRef5 = "";
         Z28ProdCod = "";
      }

      protected void InitAll2J87( )
      {
         A177CotCod = "";
         AssignAttri("", false, "A177CotCod", A177CotCod);
         A183CotDItem = 0;
         AssignAttri("", false, "A183CotDItem", StringUtil.LTrimStr( (decimal)(A183CotDItem), 4, 0));
         InitializeNonKey2J87( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816424434", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("clcotizadet.js", "?202281816424434", false, true);
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
         edtCotCod_Internalname = "COTCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCotDItem_Internalname = "COTDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCotDCan_Internalname = "COTDCAN";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCotDPre_Internalname = "COTDPRE";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCotDDsct1_Internalname = "COTDDSCT1";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCotDDsct2_Internalname = "COTDDSCT2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCotDIna_Internalname = "COTDINA";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCotDSel_Internalname = "COTDSEL";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCotDObs_Internalname = "COTDOBS";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCotDTot_Internalname = "COTDTOT";
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
         Form.Caption = "CLCOTIZADET";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCotDTot_Jsonclick = "";
         edtCotDTot_Enabled = 0;
         edtCotDObs_Enabled = 1;
         edtCotDSel_Jsonclick = "";
         edtCotDSel_Enabled = 1;
         edtCotDIna_Jsonclick = "";
         edtCotDIna_Enabled = 1;
         edtCotDDsct2_Jsonclick = "";
         edtCotDDsct2_Enabled = 1;
         edtCotDDsct1_Jsonclick = "";
         edtCotDDsct1_Enabled = 1;
         edtCotDPre_Jsonclick = "";
         edtCotDPre_Enabled = 1;
         edtCotDCan_Jsonclick = "";
         edtCotDCan_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCotDItem_Jsonclick = "";
         edtCotDItem_Enabled = 1;
         edtCotCod_Jsonclick = "";
         edtCotCod_Enabled = 1;
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
         /* Using cursor T002J16 */
         pr_default.execute(14, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Cotizacion'.", "ForeignKeyNotFound", 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtProdCod_Internalname;
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

      public void Valid_Cotcod( )
      {
         /* Using cursor T002J16 */
         pr_default.execute(14, new Object[] {A177CotCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Cotizacion'.", "ForeignKeyNotFound", 1, "COTCOD");
            AnyError = 1;
            GX_FocusControl = edtCotCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cotditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A770CotDCan", StringUtil.LTrim( StringUtil.NToC( A770CotDCan, 15, 4, ".", "")));
         AssignAttri("", false, "A771CotDPre", StringUtil.LTrim( StringUtil.NToC( A771CotDPre, 15, 4, ".", "")));
         AssignAttri("", false, "A772CotDDsct1", StringUtil.LTrim( StringUtil.NToC( A772CotDDsct1, 6, 2, ".", "")));
         AssignAttri("", false, "A773CotDDsct2", StringUtil.LTrim( StringUtil.NToC( A773CotDDsct2, 6, 2, ".", "")));
         AssignAttri("", false, "A774CotDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(A774CotDIna), 1, 0, ".", "")));
         AssignAttri("", false, "A792CotDSel", StringUtil.LTrim( StringUtil.NToC( A792CotDSel, 6, 2, ".", "")));
         AssignAttri("", false, "A779CotDObs", A779CotDObs);
         AssignAttri("", false, "A780CotDPreInc", StringUtil.LTrim( StringUtil.NToC( A780CotDPreInc, 15, 4, ".", "")));
         AssignAttri("", false, "A781CotDRef1", A781CotDRef1);
         AssignAttri("", false, "A782CotDRef2", A782CotDRef2);
         AssignAttri("", false, "A783CotDRef3", A783CotDRef3);
         AssignAttri("", false, "A784CotDRef4", A784CotDRef4);
         AssignAttri("", false, "A785CotDRef5", A785CotDRef5);
         AssignAttri("", false, "A795CotDTotInc", StringUtil.LTrim( StringUtil.NToC( A795CotDTotInc, 15, 4, ".", "")));
         AssignAttri("", false, "A769CotDSub", StringUtil.LTrim( StringUtil.NToC( A769CotDSub, 15, 4, ".", "")));
         AssignAttri("", false, "A768CotDTot", StringUtil.LTrim( StringUtil.NToC( A768CotDTot, 18, 8, ".", "")));
         AssignAttri("", false, "A775CotDDscto", StringUtil.LTrim( StringUtil.NToC( A775CotDDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A778CotDInafecto", StringUtil.LTrim( StringUtil.NToC( A778CotDInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A777CotDGratuito", StringUtil.LTrim( StringUtil.NToC( A777CotDGratuito, 15, 2, ".", "")));
         AssignAttri("", false, "A776CotDExonerado", StringUtil.LTrim( StringUtil.NToC( A776CotDExonerado, 15, 2, ".", "")));
         AssignAttri("", false, "A767CotDAfecto", StringUtil.LTrim( StringUtil.NToC( A767CotDAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A791CotDSelectivo", StringUtil.LTrim( StringUtil.NToC( A791CotDSelectivo, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z177CotCod", StringUtil.RTrim( Z177CotCod));
         GxWebStd.gx_hidden_field( context, "Z183CotDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z183CotDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z770CotDCan", StringUtil.LTrim( StringUtil.NToC( Z770CotDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z771CotDPre", StringUtil.LTrim( StringUtil.NToC( Z771CotDPre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z772CotDDsct1", StringUtil.LTrim( StringUtil.NToC( Z772CotDDsct1, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z773CotDDsct2", StringUtil.LTrim( StringUtil.NToC( Z773CotDDsct2, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z774CotDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z774CotDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z792CotDSel", StringUtil.LTrim( StringUtil.NToC( Z792CotDSel, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z779CotDObs", Z779CotDObs);
         GxWebStd.gx_hidden_field( context, "Z780CotDPreInc", StringUtil.LTrim( StringUtil.NToC( Z780CotDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z781CotDRef1", Z781CotDRef1);
         GxWebStd.gx_hidden_field( context, "Z782CotDRef2", Z782CotDRef2);
         GxWebStd.gx_hidden_field( context, "Z783CotDRef3", Z783CotDRef3);
         GxWebStd.gx_hidden_field( context, "Z784CotDRef4", Z784CotDRef4);
         GxWebStd.gx_hidden_field( context, "Z785CotDRef5", Z785CotDRef5);
         GxWebStd.gx_hidden_field( context, "Z795CotDTotInc", StringUtil.LTrim( StringUtil.NToC( Z795CotDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z769CotDSub", StringUtil.LTrim( StringUtil.NToC( Z769CotDSub, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z768CotDTot", StringUtil.LTrim( StringUtil.NToC( Z768CotDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z775CotDDscto", StringUtil.LTrim( StringUtil.NToC( Z775CotDDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z778CotDInafecto", StringUtil.LTrim( StringUtil.NToC( Z778CotDInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z777CotDGratuito", StringUtil.LTrim( StringUtil.NToC( Z777CotDGratuito, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z776CotDExonerado", StringUtil.LTrim( StringUtil.NToC( Z776CotDExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z767CotDAfecto", StringUtil.LTrim( StringUtil.NToC( Z767CotDAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z791CotDSelectivo", StringUtil.LTrim( StringUtil.NToC( Z791CotDSelectivo, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T002J17 */
         pr_default.execute(15, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A780CotDPreInc',fld:'COTDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A781CotDRef1',fld:'COTDREF1',pic:''},{av:'A782CotDRef2',fld:'COTDREF2',pic:''},{av:'A783CotDRef3',fld:'COTDREF3',pic:''},{av:'A784CotDRef4',fld:'COTDREF4',pic:''},{av:'A785CotDRef5',fld:'COTDREF5',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_COTCOD","{handler:'Valid_Cotcod',iparms:[{av:'A177CotCod',fld:'COTCOD',pic:''}]");
         setEventMetadata("VALID_COTCOD",",oparms:[]}");
         setEventMetadata("VALID_COTDITEM","{handler:'Valid_Cotditem',iparms:[{av:'A785CotDRef5',fld:'COTDREF5',pic:''},{av:'A784CotDRef4',fld:'COTDREF4',pic:''},{av:'A783CotDRef3',fld:'COTDREF3',pic:''},{av:'A782CotDRef2',fld:'COTDREF2',pic:''},{av:'A781CotDRef1',fld:'COTDREF1',pic:''},{av:'A780CotDPreInc',fld:'COTDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A177CotCod',fld:'COTCOD',pic:''},{av:'A183CotDItem',fld:'COTDITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COTDITEM",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A770CotDCan',fld:'COTDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A771CotDPre',fld:'COTDPRE',pic:'ZZZ,ZZZ,ZZ9.9999'},{av:'A772CotDDsct1',fld:'COTDDSCT1',pic:'ZZ9.99'},{av:'A773CotDDsct2',fld:'COTDDSCT2',pic:'ZZ9.99'},{av:'A774CotDIna',fld:'COTDINA',pic:'9'},{av:'A792CotDSel',fld:'COTDSEL',pic:'ZZ9.99'},{av:'A779CotDObs',fld:'COTDOBS',pic:''},{av:'A780CotDPreInc',fld:'COTDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A781CotDRef1',fld:'COTDREF1',pic:''},{av:'A782CotDRef2',fld:'COTDREF2',pic:''},{av:'A783CotDRef3',fld:'COTDREF3',pic:''},{av:'A784CotDRef4',fld:'COTDREF4',pic:''},{av:'A785CotDRef5',fld:'COTDREF5',pic:''},{av:'A795CotDTotInc',fld:'COTDTOTINC',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A769CotDSub',fld:'COTDSUB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A768CotDTot',fld:'COTDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A775CotDDscto',fld:'COTDDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A778CotDInafecto',fld:'COTDINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A777CotDGratuito',fld:'COTDGRATUITO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A776CotDExonerado',fld:'COTDEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A767CotDAfecto',fld:'COTDAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A791CotDSelectivo',fld:'COTDSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z177CotCod'},{av:'Z183CotDItem'},{av:'Z28ProdCod'},{av:'Z770CotDCan'},{av:'Z771CotDPre'},{av:'Z772CotDDsct1'},{av:'Z773CotDDsct2'},{av:'Z774CotDIna'},{av:'Z792CotDSel'},{av:'Z779CotDObs'},{av:'Z780CotDPreInc'},{av:'Z781CotDRef1'},{av:'Z782CotDRef2'},{av:'Z783CotDRef3'},{av:'Z784CotDRef4'},{av:'Z785CotDRef5'},{av:'Z795CotDTotInc'},{av:'Z769CotDSub'},{av:'Z768CotDTot'},{av:'Z775CotDDscto'},{av:'Z778CotDInafecto'},{av:'Z777CotDGratuito'},{av:'Z776CotDExonerado'},{av:'Z767CotDAfecto'},{av:'Z791CotDSelectivo'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[]}");
         setEventMetadata("VALID_COTDCAN","{handler:'Valid_Cotdcan',iparms:[]");
         setEventMetadata("VALID_COTDCAN",",oparms:[]}");
         setEventMetadata("VALID_COTDPRE","{handler:'Valid_Cotdpre',iparms:[]");
         setEventMetadata("VALID_COTDPRE",",oparms:[]}");
         setEventMetadata("VALID_COTDDSCT1","{handler:'Valid_Cotddsct1',iparms:[]");
         setEventMetadata("VALID_COTDDSCT1",",oparms:[]}");
         setEventMetadata("VALID_COTDDSCT2","{handler:'Valid_Cotddsct2',iparms:[]");
         setEventMetadata("VALID_COTDDSCT2",",oparms:[]}");
         setEventMetadata("VALID_COTDINA","{handler:'Valid_Cotdina',iparms:[]");
         setEventMetadata("VALID_COTDINA",",oparms:[]}");
         setEventMetadata("VALID_COTDSEL","{handler:'Valid_Cotdsel',iparms:[]");
         setEventMetadata("VALID_COTDSEL",",oparms:[]}");
         setEventMetadata("VALID_COTDTOT","{handler:'Valid_Cotdtot',iparms:[]");
         setEventMetadata("VALID_COTDTOT",",oparms:[]}");
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
         Z177CotCod = "";
         Z781CotDRef1 = "";
         Z782CotDRef2 = "";
         Z783CotDRef3 = "";
         Z784CotDRef4 = "";
         Z785CotDRef5 = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A177CotCod = "";
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
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A779CotDObs = "";
         lblTextblock11_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A781CotDRef1 = "";
         A782CotDRef2 = "";
         A783CotDRef3 = "";
         A784CotDRef4 = "";
         A785CotDRef5 = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z779CotDObs = "";
         T002J6_A768CotDTot = new decimal[1] ;
         T002J6_A795CotDTotInc = new decimal[1] ;
         T002J6_A183CotDItem = new short[1] ;
         T002J6_A770CotDCan = new decimal[1] ;
         T002J6_A771CotDPre = new decimal[1] ;
         T002J6_A772CotDDsct1 = new decimal[1] ;
         T002J6_A773CotDDsct2 = new decimal[1] ;
         T002J6_A774CotDIna = new short[1] ;
         T002J6_A792CotDSel = new decimal[1] ;
         T002J6_A779CotDObs = new string[] {""} ;
         T002J6_A780CotDPreInc = new decimal[1] ;
         T002J6_A781CotDRef1 = new string[] {""} ;
         T002J6_A782CotDRef2 = new string[] {""} ;
         T002J6_A783CotDRef3 = new string[] {""} ;
         T002J6_A784CotDRef4 = new string[] {""} ;
         T002J6_A785CotDRef5 = new string[] {""} ;
         T002J6_A177CotCod = new string[] {""} ;
         T002J6_A28ProdCod = new string[] {""} ;
         T002J4_A177CotCod = new string[] {""} ;
         T002J5_A28ProdCod = new string[] {""} ;
         T002J7_A177CotCod = new string[] {""} ;
         T002J8_A28ProdCod = new string[] {""} ;
         T002J9_A177CotCod = new string[] {""} ;
         T002J9_A183CotDItem = new short[1] ;
         T002J3_A768CotDTot = new decimal[1] ;
         T002J3_A795CotDTotInc = new decimal[1] ;
         T002J3_A183CotDItem = new short[1] ;
         T002J3_A770CotDCan = new decimal[1] ;
         T002J3_A771CotDPre = new decimal[1] ;
         T002J3_A772CotDDsct1 = new decimal[1] ;
         T002J3_A773CotDDsct2 = new decimal[1] ;
         T002J3_A774CotDIna = new short[1] ;
         T002J3_A792CotDSel = new decimal[1] ;
         T002J3_A779CotDObs = new string[] {""} ;
         T002J3_A780CotDPreInc = new decimal[1] ;
         T002J3_A781CotDRef1 = new string[] {""} ;
         T002J3_A782CotDRef2 = new string[] {""} ;
         T002J3_A783CotDRef3 = new string[] {""} ;
         T002J3_A784CotDRef4 = new string[] {""} ;
         T002J3_A785CotDRef5 = new string[] {""} ;
         T002J3_A177CotCod = new string[] {""} ;
         T002J3_A28ProdCod = new string[] {""} ;
         sMode87 = "";
         T002J10_A177CotCod = new string[] {""} ;
         T002J10_A183CotDItem = new short[1] ;
         T002J11_A177CotCod = new string[] {""} ;
         T002J11_A183CotDItem = new short[1] ;
         T002J2_A768CotDTot = new decimal[1] ;
         T002J2_A795CotDTotInc = new decimal[1] ;
         T002J2_A183CotDItem = new short[1] ;
         T002J2_A770CotDCan = new decimal[1] ;
         T002J2_A771CotDPre = new decimal[1] ;
         T002J2_A772CotDDsct1 = new decimal[1] ;
         T002J2_A773CotDDsct2 = new decimal[1] ;
         T002J2_A774CotDIna = new short[1] ;
         T002J2_A792CotDSel = new decimal[1] ;
         T002J2_A779CotDObs = new string[] {""} ;
         T002J2_A780CotDPreInc = new decimal[1] ;
         T002J2_A781CotDRef1 = new string[] {""} ;
         T002J2_A782CotDRef2 = new string[] {""} ;
         T002J2_A783CotDRef3 = new string[] {""} ;
         T002J2_A784CotDRef4 = new string[] {""} ;
         T002J2_A785CotDRef5 = new string[] {""} ;
         T002J2_A177CotCod = new string[] {""} ;
         T002J2_A28ProdCod = new string[] {""} ;
         T002J15_A177CotCod = new string[] {""} ;
         T002J15_A183CotDItem = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002J16_A177CotCod = new string[] {""} ;
         ZZ177CotCod = "";
         ZZ28ProdCod = "";
         ZZ779CotDObs = "";
         ZZ781CotDRef1 = "";
         ZZ782CotDRef2 = "";
         ZZ783CotDRef3 = "";
         ZZ784CotDRef4 = "";
         ZZ785CotDRef5 = "";
         T002J17_A28ProdCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clcotizadet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clcotizadet__default(),
            new Object[][] {
                new Object[] {
               T002J2_A768CotDTot, T002J2_A795CotDTotInc, T002J2_A183CotDItem, T002J2_A770CotDCan, T002J2_A771CotDPre, T002J2_A772CotDDsct1, T002J2_A773CotDDsct2, T002J2_A774CotDIna, T002J2_A792CotDSel, T002J2_A779CotDObs,
               T002J2_A780CotDPreInc, T002J2_A781CotDRef1, T002J2_A782CotDRef2, T002J2_A783CotDRef3, T002J2_A784CotDRef4, T002J2_A785CotDRef5, T002J2_A177CotCod, T002J2_A28ProdCod
               }
               , new Object[] {
               T002J3_A768CotDTot, T002J3_A795CotDTotInc, T002J3_A183CotDItem, T002J3_A770CotDCan, T002J3_A771CotDPre, T002J3_A772CotDDsct1, T002J3_A773CotDDsct2, T002J3_A774CotDIna, T002J3_A792CotDSel, T002J3_A779CotDObs,
               T002J3_A780CotDPreInc, T002J3_A781CotDRef1, T002J3_A782CotDRef2, T002J3_A783CotDRef3, T002J3_A784CotDRef4, T002J3_A785CotDRef5, T002J3_A177CotCod, T002J3_A28ProdCod
               }
               , new Object[] {
               T002J4_A177CotCod
               }
               , new Object[] {
               T002J5_A28ProdCod
               }
               , new Object[] {
               T002J6_A768CotDTot, T002J6_A795CotDTotInc, T002J6_A183CotDItem, T002J6_A770CotDCan, T002J6_A771CotDPre, T002J6_A772CotDDsct1, T002J6_A773CotDDsct2, T002J6_A774CotDIna, T002J6_A792CotDSel, T002J6_A779CotDObs,
               T002J6_A780CotDPreInc, T002J6_A781CotDRef1, T002J6_A782CotDRef2, T002J6_A783CotDRef3, T002J6_A784CotDRef4, T002J6_A785CotDRef5, T002J6_A177CotCod, T002J6_A28ProdCod
               }
               , new Object[] {
               T002J7_A177CotCod
               }
               , new Object[] {
               T002J8_A28ProdCod
               }
               , new Object[] {
               T002J9_A177CotCod, T002J9_A183CotDItem
               }
               , new Object[] {
               T002J10_A177CotCod, T002J10_A183CotDItem
               }
               , new Object[] {
               T002J11_A177CotCod, T002J11_A183CotDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002J15_A177CotCod, T002J15_A183CotDItem
               }
               , new Object[] {
               T002J16_A177CotCod
               }
               , new Object[] {
               T002J17_A28ProdCod
               }
            }
         );
      }

      private short Z183CotDItem ;
      private short Z774CotDIna ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A183CotDItem ;
      private short A774CotDIna ;
      private short GX_JID ;
      private short RcdFound87 ;
      private short nIsDirty_87 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ183CotDItem ;
      private short ZZ774CotDIna ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCotCod_Enabled ;
      private int edtCotDItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtCotDCan_Enabled ;
      private int edtCotDPre_Enabled ;
      private int edtCotDDsct1_Enabled ;
      private int edtCotDDsct2_Enabled ;
      private int edtCotDIna_Enabled ;
      private int edtCotDSel_Enabled ;
      private int edtCotDObs_Enabled ;
      private int edtCotDTot_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z768CotDTot ;
      private decimal Z795CotDTotInc ;
      private decimal Z770CotDCan ;
      private decimal Z771CotDPre ;
      private decimal Z772CotDDsct1 ;
      private decimal Z773CotDDsct2 ;
      private decimal Z792CotDSel ;
      private decimal Z780CotDPreInc ;
      private decimal A770CotDCan ;
      private decimal A771CotDPre ;
      private decimal A772CotDDsct1 ;
      private decimal A773CotDDsct2 ;
      private decimal A792CotDSel ;
      private decimal A768CotDTot ;
      private decimal A795CotDTotInc ;
      private decimal A780CotDPreInc ;
      private decimal A769CotDSub ;
      private decimal A778CotDInafecto ;
      private decimal A777CotDGratuito ;
      private decimal A776CotDExonerado ;
      private decimal A767CotDAfecto ;
      private decimal A791CotDSelectivo ;
      private decimal A775CotDDscto ;
      private decimal Z769CotDSub ;
      private decimal Z775CotDDscto ;
      private decimal Z778CotDInafecto ;
      private decimal Z777CotDGratuito ;
      private decimal Z776CotDExonerado ;
      private decimal Z767CotDAfecto ;
      private decimal Z791CotDSelectivo ;
      private decimal ZZ770CotDCan ;
      private decimal ZZ771CotDPre ;
      private decimal ZZ772CotDDsct1 ;
      private decimal ZZ773CotDDsct2 ;
      private decimal ZZ792CotDSel ;
      private decimal ZZ780CotDPreInc ;
      private decimal ZZ795CotDTotInc ;
      private decimal ZZ769CotDSub ;
      private decimal ZZ768CotDTot ;
      private decimal ZZ775CotDDscto ;
      private decimal ZZ778CotDInafecto ;
      private decimal ZZ777CotDGratuito ;
      private decimal ZZ776CotDExonerado ;
      private decimal ZZ767CotDAfecto ;
      private decimal ZZ791CotDSelectivo ;
      private string sPrefix ;
      private string Z177CotCod ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A177CotCod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCotCod_Internalname ;
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
      private string edtCotCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCotDItem_Internalname ;
      private string edtCotDItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCotDCan_Internalname ;
      private string edtCotDCan_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCotDPre_Internalname ;
      private string edtCotDPre_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCotDDsct1_Internalname ;
      private string edtCotDDsct1_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCotDDsct2_Internalname ;
      private string edtCotDDsct2_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCotDIna_Internalname ;
      private string edtCotDIna_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCotDSel_Internalname ;
      private string edtCotDSel_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCotDObs_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCotDTot_Internalname ;
      private string edtCotDTot_Jsonclick ;
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
      private string sMode87 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ177CotCod ;
      private string ZZ28ProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A779CotDObs ;
      private string Z779CotDObs ;
      private string ZZ779CotDObs ;
      private string Z781CotDRef1 ;
      private string Z782CotDRef2 ;
      private string Z783CotDRef3 ;
      private string Z784CotDRef4 ;
      private string Z785CotDRef5 ;
      private string A781CotDRef1 ;
      private string A782CotDRef2 ;
      private string A783CotDRef3 ;
      private string A784CotDRef4 ;
      private string A785CotDRef5 ;
      private string ZZ781CotDRef1 ;
      private string ZZ782CotDRef2 ;
      private string ZZ783CotDRef3 ;
      private string ZZ784CotDRef4 ;
      private string ZZ785CotDRef5 ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T002J6_A768CotDTot ;
      private decimal[] T002J6_A795CotDTotInc ;
      private short[] T002J6_A183CotDItem ;
      private decimal[] T002J6_A770CotDCan ;
      private decimal[] T002J6_A771CotDPre ;
      private decimal[] T002J6_A772CotDDsct1 ;
      private decimal[] T002J6_A773CotDDsct2 ;
      private short[] T002J6_A774CotDIna ;
      private decimal[] T002J6_A792CotDSel ;
      private string[] T002J6_A779CotDObs ;
      private decimal[] T002J6_A780CotDPreInc ;
      private string[] T002J6_A781CotDRef1 ;
      private string[] T002J6_A782CotDRef2 ;
      private string[] T002J6_A783CotDRef3 ;
      private string[] T002J6_A784CotDRef4 ;
      private string[] T002J6_A785CotDRef5 ;
      private string[] T002J6_A177CotCod ;
      private string[] T002J6_A28ProdCod ;
      private string[] T002J4_A177CotCod ;
      private string[] T002J5_A28ProdCod ;
      private string[] T002J7_A177CotCod ;
      private string[] T002J8_A28ProdCod ;
      private string[] T002J9_A177CotCod ;
      private short[] T002J9_A183CotDItem ;
      private decimal[] T002J3_A768CotDTot ;
      private decimal[] T002J3_A795CotDTotInc ;
      private short[] T002J3_A183CotDItem ;
      private decimal[] T002J3_A770CotDCan ;
      private decimal[] T002J3_A771CotDPre ;
      private decimal[] T002J3_A772CotDDsct1 ;
      private decimal[] T002J3_A773CotDDsct2 ;
      private short[] T002J3_A774CotDIna ;
      private decimal[] T002J3_A792CotDSel ;
      private string[] T002J3_A779CotDObs ;
      private decimal[] T002J3_A780CotDPreInc ;
      private string[] T002J3_A781CotDRef1 ;
      private string[] T002J3_A782CotDRef2 ;
      private string[] T002J3_A783CotDRef3 ;
      private string[] T002J3_A784CotDRef4 ;
      private string[] T002J3_A785CotDRef5 ;
      private string[] T002J3_A177CotCod ;
      private string[] T002J3_A28ProdCod ;
      private string[] T002J10_A177CotCod ;
      private short[] T002J10_A183CotDItem ;
      private string[] T002J11_A177CotCod ;
      private short[] T002J11_A183CotDItem ;
      private decimal[] T002J2_A768CotDTot ;
      private decimal[] T002J2_A795CotDTotInc ;
      private short[] T002J2_A183CotDItem ;
      private decimal[] T002J2_A770CotDCan ;
      private decimal[] T002J2_A771CotDPre ;
      private decimal[] T002J2_A772CotDDsct1 ;
      private decimal[] T002J2_A773CotDDsct2 ;
      private short[] T002J2_A774CotDIna ;
      private decimal[] T002J2_A792CotDSel ;
      private string[] T002J2_A779CotDObs ;
      private decimal[] T002J2_A780CotDPreInc ;
      private string[] T002J2_A781CotDRef1 ;
      private string[] T002J2_A782CotDRef2 ;
      private string[] T002J2_A783CotDRef3 ;
      private string[] T002J2_A784CotDRef4 ;
      private string[] T002J2_A785CotDRef5 ;
      private string[] T002J2_A177CotCod ;
      private string[] T002J2_A28ProdCod ;
      private string[] T002J15_A177CotCod ;
      private short[] T002J15_A183CotDItem ;
      private string[] T002J16_A177CotCod ;
      private string[] T002J17_A28ProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clcotizadet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clcotizadet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002J6;
        prmT002J6 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J4;
        prmT002J4 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002J5;
        prmT002J5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002J7;
        prmT002J7 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002J8;
        prmT002J8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002J9;
        prmT002J9 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J3;
        prmT002J3 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J10;
        prmT002J10 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J11;
        prmT002J11 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J2;
        prmT002J2 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J12;
        prmT002J12 = new Object[] {
        new ParDef("@CotDTot",GXType.Decimal,18,8) ,
        new ParDef("@CotDTotInc",GXType.Decimal,15,4) ,
        new ParDef("@CotDItem",GXType.Int16,4,0) ,
        new ParDef("@CotDCan",GXType.Decimal,15,4) ,
        new ParDef("@CotDPre",GXType.Decimal,15,4) ,
        new ParDef("@CotDDsct1",GXType.Decimal,6,2) ,
        new ParDef("@CotDDsct2",GXType.Decimal,6,2) ,
        new ParDef("@CotDIna",GXType.Int16,1,0) ,
        new ParDef("@CotDSel",GXType.Decimal,6,2) ,
        new ParDef("@CotDObs",GXType.NVarChar,500,0) ,
        new ParDef("@CotDPreInc",GXType.Decimal,15,4) ,
        new ParDef("@CotDRef1",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef2",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef3",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef4",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef5",GXType.NVarChar,20,0) ,
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002J13;
        prmT002J13 = new Object[] {
        new ParDef("@CotDTot",GXType.Decimal,18,8) ,
        new ParDef("@CotDTotInc",GXType.Decimal,15,4) ,
        new ParDef("@CotDCan",GXType.Decimal,15,4) ,
        new ParDef("@CotDPre",GXType.Decimal,15,4) ,
        new ParDef("@CotDDsct1",GXType.Decimal,6,2) ,
        new ParDef("@CotDDsct2",GXType.Decimal,6,2) ,
        new ParDef("@CotDIna",GXType.Int16,1,0) ,
        new ParDef("@CotDSel",GXType.Decimal,6,2) ,
        new ParDef("@CotDObs",GXType.NVarChar,500,0) ,
        new ParDef("@CotDPreInc",GXType.Decimal,15,4) ,
        new ParDef("@CotDRef1",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef2",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef3",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef4",GXType.NVarChar,20,0) ,
        new ParDef("@CotDRef5",GXType.NVarChar,20,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J14;
        prmT002J14 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0) ,
        new ParDef("@CotDItem",GXType.Int16,4,0)
        };
        Object[] prmT002J15;
        prmT002J15 = new Object[] {
        };
        Object[] prmT002J16;
        prmT002J16 = new Object[] {
        new ParDef("@CotCod",GXType.NChar,10,0)
        };
        Object[] prmT002J17;
        prmT002J17 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002J2", "SELECT [CotDTot], [CotDTotInc], [CotDItem], [CotDCan], [CotDPre], [CotDDsct1], [CotDDsct2], [CotDIna], [CotDSel], [CotDObs], [CotDPreInc], [CotDRef1], [CotDRef2], [CotDRef3], [CotDRef4], [CotDRef5], [CotCod], [ProdCod] FROM [CLCOTIZADET] WITH (UPDLOCK) WHERE [CotCod] = @CotCod AND [CotDItem] = @CotDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J3", "SELECT [CotDTot], [CotDTotInc], [CotDItem], [CotDCan], [CotDPre], [CotDDsct1], [CotDDsct2], [CotDIna], [CotDSel], [CotDObs], [CotDPreInc], [CotDRef1], [CotDRef2], [CotDRef3], [CotDRef4], [CotDRef5], [CotCod], [ProdCod] FROM [CLCOTIZADET] WHERE [CotCod] = @CotCod AND [CotDItem] = @CotDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J4", "SELECT [CotCod] FROM [CLCOTIZA] WHERE [CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J5", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J6", "SELECT TM1.[CotDTot], TM1.[CotDTotInc], TM1.[CotDItem], TM1.[CotDCan], TM1.[CotDPre], TM1.[CotDDsct1], TM1.[CotDDsct2], TM1.[CotDIna], TM1.[CotDSel], TM1.[CotDObs], TM1.[CotDPreInc], TM1.[CotDRef1], TM1.[CotDRef2], TM1.[CotDRef3], TM1.[CotDRef4], TM1.[CotDRef5], TM1.[CotCod], TM1.[ProdCod] FROM [CLCOTIZADET] TM1 WHERE TM1.[CotCod] = @CotCod and TM1.[CotDItem] = @CotDItem ORDER BY TM1.[CotCod], TM1.[CotDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J7", "SELECT [CotCod] FROM [CLCOTIZA] WHERE [CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J8", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J9", "SELECT [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE [CotCod] = @CotCod AND [CotDItem] = @CotDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J10", "SELECT TOP 1 [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE ( [CotCod] > @CotCod or [CotCod] = @CotCod and [CotDItem] > @CotDItem) ORDER BY [CotCod], [CotDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J11", "SELECT TOP 1 [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE ( [CotCod] < @CotCod or [CotCod] = @CotCod and [CotDItem] < @CotDItem) ORDER BY [CotCod] DESC, [CotDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002J12", "INSERT INTO [CLCOTIZADET]([CotDTot], [CotDTotInc], [CotDItem], [CotDCan], [CotDPre], [CotDDsct1], [CotDDsct2], [CotDIna], [CotDSel], [CotDObs], [CotDPreInc], [CotDRef1], [CotDRef2], [CotDRef3], [CotDRef4], [CotDRef5], [CotCod], [ProdCod]) VALUES(@CotDTot, @CotDTotInc, @CotDItem, @CotDCan, @CotDPre, @CotDDsct1, @CotDDsct2, @CotDIna, @CotDSel, @CotDObs, @CotDPreInc, @CotDRef1, @CotDRef2, @CotDRef3, @CotDRef4, @CotDRef5, @CotCod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT002J12)
           ,new CursorDef("T002J13", "UPDATE [CLCOTIZADET] SET [CotDTot]=@CotDTot, [CotDTotInc]=@CotDTotInc, [CotDCan]=@CotDCan, [CotDPre]=@CotDPre, [CotDDsct1]=@CotDDsct1, [CotDDsct2]=@CotDDsct2, [CotDIna]=@CotDIna, [CotDSel]=@CotDSel, [CotDObs]=@CotDObs, [CotDPreInc]=@CotDPreInc, [CotDRef1]=@CotDRef1, [CotDRef2]=@CotDRef2, [CotDRef3]=@CotDRef3, [CotDRef4]=@CotDRef4, [CotDRef5]=@CotDRef5, [ProdCod]=@ProdCod  WHERE [CotCod] = @CotCod AND [CotDItem] = @CotDItem", GxErrorMask.GX_NOMASK,prmT002J13)
           ,new CursorDef("T002J14", "DELETE FROM [CLCOTIZADET]  WHERE [CotCod] = @CotCod AND [CotDItem] = @CotDItem", GxErrorMask.GX_NOMASK,prmT002J14)
           ,new CursorDef("T002J15", "SELECT [CotCod], [CotDItem] FROM [CLCOTIZADET] ORDER BY [CotCod], [CotDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002J15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J16", "SELECT [CotCod] FROM [CLCOTIZA] WHERE [CotCod] = @CotCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002J17", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002J17,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
