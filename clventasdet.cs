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
   public class clventasdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = GetPar( "DocNum");
            AssignAttri("", false, "A24DocNum", A24DocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A149TipCod, A24DocNum) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A28ProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A52LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A52LinCod) ;
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
            Form.Meta.addItem("description", "Ventas - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clventasdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clventasdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLVENTASDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Numero Doc.", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocNum_Internalname, StringUtil.RTrim( A24DocNum), StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A233DocItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtDocItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A233DocItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A233DocItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Descripcion producto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Cantidad", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDCan_Internalname, StringUtil.LTrim( StringUtil.NToC( A895DocDCan, 17, 4, ".", "")), StringUtil.LTrim( ((edtDocDCan_Enabled!=0) ? context.localUtil.Format( A895DocDCan, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A895DocDCan, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDCan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDCan_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Precio", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDpre_Internalname, StringUtil.LTrim( StringUtil.NToC( A894DocDpre, 17, 4, ".", "")), StringUtil.LTrim( ((edtDocDpre_Enabled!=0) ? context.localUtil.Format( A894DocDpre, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A894DocDpre, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDpre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDpre_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "% Descuento 1", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDDct_Internalname, StringUtil.LTrim( StringUtil.NToC( A896DocDDct, 10, 2, ".", "")), StringUtil.LTrim( ((edtDocDDct_Enabled!=0) ? context.localUtil.Format( A896DocDDct, "ZZZZZZ9.99") : context.localUtil.Format( A896DocDDct, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDDct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDDct_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "% Descuento 2", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDDct2_Internalname, StringUtil.LTrim( StringUtil.NToC( A897DocDDct2, 10, 2, ".", "")), StringUtil.LTrim( ((edtDocDDct2_Enabled!=0) ? context.localUtil.Format( A897DocDDct2, "ZZZZZZ9.99") : context.localUtil.Format( A897DocDDct2, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDDct2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDDct2_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Sub Total Item", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDSub_Internalname, StringUtil.LTrim( StringUtil.NToC( A893DocDSub, 17, 4, ".", "")), StringUtil.LTrim( ((edtDocDSub_Enabled!=0) ? context.localUtil.Format( A893DocDSub, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A893DocDSub, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDSub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDSub_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Total Producto", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A892DocDTot, 18, 8, ".", "")), StringUtil.LTrim( ((edtDocDTot_Enabled!=0) ? context.localUtil.Format( A892DocDTot, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A892DocDTot, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDTot_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Descuento", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDDcto_Internalname, StringUtil.LTrim( StringUtil.NToC( A900DocDDcto, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocDDcto_Enabled!=0) ? context.localUtil.Format( A900DocDDcto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A900DocDDcto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDDcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDDcto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Controla Stock", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLinStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtLinStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1158LinStk), "9") : context.localUtil.Format( (decimal)(A1158LinStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Observaciones", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocDObs_Internalname, A910DocDObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", 0, 1, edtDocDObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Inafecta IGV", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDIna_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A898DocDIna), 1, 0, ".", "")), StringUtil.LTrim( ((edtDocDIna_Enabled!=0) ? context.localUtil.Format( (decimal)(A898DocDIna), "9") : context.localUtil.Format( (decimal)(A898DocDIna), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDIna_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "% Impuesto Selectivo", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDPorSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A912DocDPorSel, 5, 2, ".", "")), StringUtil.LTrim( ((edtDocDPorSel_Enabled!=0) ? context.localUtil.Format( A912DocDPorSel, "Z9.99") : context.localUtil.Format( A912DocDPorSel, "Z9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDPorSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDPorSel_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Afecto", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A891DocDAfecto, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocDAfecto_Enabled!=0) ? context.localUtil.Format( A891DocDAfecto, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A891DocDAfecto, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDAfecto_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Inafecto", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A909DocDInafecto, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocDInafecto_Enabled!=0) ? context.localUtil.Format( A909DocDInafecto, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A909DocDInafecto, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDInafecto_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Selectivo", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDSelectivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A923DocDSelectivo, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocDSelectivo_Enabled!=0) ? context.localUtil.Format( A923DocDSelectivo, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A923DocDSelectivo, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDSelectivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDSelectivo_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "% Impuesto Selectivo", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdPorSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")), StringUtil.LTrim( ((edtProdPorSel_Enabled!=0) ? context.localUtil.Format( A1703ProdPorSel, "ZZ9.99") : context.localUtil.Format( A1703ProdPorSel, "ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdPorSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdPorSel_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Doc. Referencia 1", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDRef1_Internalname, A914DocDRef1, StringUtil.RTrim( context.localUtil.Format( A914DocDRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Doc. Referencia 2", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDRef2_Internalname, A915DocDRef2, StringUtil.RTrim( context.localUtil.Format( A915DocDRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Doc. Referencia 3", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDRef3_Internalname, A916DocDRef3, StringUtil.RTrim( context.localUtil.Format( A916DocDRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Doc. Referencia 4", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDRef4_Internalname, A917DocDRef4, StringUtil.RTrim( context.localUtil.Format( A917DocDRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "N° Pedido", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDPed_Internalname, A911DocDPed, StringUtil.RTrim( context.localUtil.Format( A911DocDPed, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDPed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDPed_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLVENTASDET.htm");
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
            Z149TipCod = cgiGet( "Z149TipCod");
            Z24DocNum = cgiGet( "Z24DocNum");
            Z233DocItem = (long)(context.localUtil.CToN( cgiGet( "Z233DocItem"), ".", ","));
            Z892DocDTot = context.localUtil.CToN( cgiGet( "Z892DocDTot"), ".", ",");
            Z905DocDICBPER = context.localUtil.CToN( cgiGet( "Z905DocDICBPER"), ".", ",");
            Z895DocDCan = context.localUtil.CToN( cgiGet( "Z895DocDCan"), ".", ",");
            Z894DocDpre = context.localUtil.CToN( cgiGet( "Z894DocDpre"), ".", ",");
            Z896DocDDct = context.localUtil.CToN( cgiGet( "Z896DocDDct"), ".", ",");
            Z897DocDDct2 = context.localUtil.CToN( cgiGet( "Z897DocDDct2"), ".", ",");
            Z898DocDIna = (short)(context.localUtil.CToN( cgiGet( "Z898DocDIna"), ".", ","));
            Z912DocDPorSel = context.localUtil.CToN( cgiGet( "Z912DocDPorSel"), ".", ",");
            Z914DocDRef1 = cgiGet( "Z914DocDRef1");
            Z915DocDRef2 = cgiGet( "Z915DocDRef2");
            Z916DocDRef3 = cgiGet( "Z916DocDRef3");
            Z917DocDRef4 = cgiGet( "Z917DocDRef4");
            Z911DocDPed = cgiGet( "Z911DocDPed");
            Z913DocDPreInc = context.localUtil.CToN( cgiGet( "Z913DocDPreInc"), ".", ",");
            Z928DocDTotInc = context.localUtil.CToN( cgiGet( "Z928DocDTotInc"), ".", ",");
            Z926DocDValSel = context.localUtil.CToN( cgiGet( "Z926DocDValSel"), ".", ",");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z932DocICBPER = context.localUtil.CToN( cgiGet( "Z932DocICBPER"), ".", ",");
            Z230DocMonCod = (int)(context.localUtil.CToN( cgiGet( "Z230DocMonCod"), ".", ","));
            A905DocDICBPER = context.localUtil.CToN( cgiGet( "Z905DocDICBPER"), ".", ",");
            A913DocDPreInc = context.localUtil.CToN( cgiGet( "Z913DocDPreInc"), ".", ",");
            A928DocDTotInc = context.localUtil.CToN( cgiGet( "Z928DocDTotInc"), ".", ",");
            A926DocDValSel = context.localUtil.CToN( cgiGet( "Z926DocDValSel"), ".", ",");
            A932DocICBPER = context.localUtil.CToN( cgiGet( "Z932DocICBPER"), ".", ",");
            n932DocICBPER = false;
            A230DocMonCod = (int)(context.localUtil.CToN( cgiGet( "Z230DocMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A926DocDValSel = context.localUtil.CToN( cgiGet( "DOCDVALSEL"), ".", ",");
            A925DocDSelectivoValor = context.localUtil.CToN( cgiGet( "DOCDSELECTIVOVALOR"), ".", ",");
            A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "PRODAFECICBPER"), ".", ","));
            A230DocMonCod = (int)(context.localUtil.CToN( cgiGet( "DOCMONCOD"), ".", ","));
            A907ProdValICBPER = context.localUtil.CToN( cgiGet( "PRODVALICBPER"), ".", ",");
            A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "PRODVALICBPERD"), ".", ",");
            A905DocDICBPER = context.localUtil.CToN( cgiGet( "DOCDICBPER"), ".", ",");
            A924DocDSelectivoPor = context.localUtil.CToN( cgiGet( "DOCDSELECTIVOPOR"), ".", ",");
            A903DocDGratuitoIna = context.localUtil.CToN( cgiGet( "DOCDGRATUITOINA"), ".", ",");
            A902DocDGratuito = context.localUtil.CToN( cgiGet( "DOCDGRATUITO"), ".", ",");
            A901DocDExonerado = context.localUtil.CToN( cgiGet( "DOCDEXONERADO"), ".", ",");
            A913DocDPreInc = context.localUtil.CToN( cgiGet( "DOCDPREINC"), ".", ",");
            A928DocDTotInc = context.localUtil.CToN( cgiGet( "DOCDTOTINC"), ".", ",");
            A932DocICBPER = context.localUtil.CToN( cgiGet( "DOCICBPER"), ".", ",");
            A52LinCod = (int)(context.localUtil.CToN( cgiGet( "LINCOD"), ".", ","));
            /* Read variables values. */
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = cgiGet( edtDocNum_Internalname);
            AssignAttri("", false, "A24DocNum", A24DocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCITEM");
               AnyError = 1;
               GX_FocusControl = edtDocItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A233DocItem = 0;
               AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
            }
            else
            {
               A233DocItem = (long)(context.localUtil.CToN( cgiGet( edtDocItem_Internalname), ".", ","));
               AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A55ProdDsc = cgiGet( edtProdDsc_Internalname);
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDCan_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDCan_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDCAN");
               AnyError = 1;
               GX_FocusControl = edtDocDCan_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A895DocDCan = 0;
               AssignAttri("", false, "A895DocDCan", StringUtil.LTrimStr( A895DocDCan, 15, 4));
            }
            else
            {
               A895DocDCan = context.localUtil.CToN( cgiGet( edtDocDCan_Internalname), ".", ",");
               AssignAttri("", false, "A895DocDCan", StringUtil.LTrimStr( A895DocDCan, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDpre_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDpre_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDPRE");
               AnyError = 1;
               GX_FocusControl = edtDocDpre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A894DocDpre = 0;
               AssignAttri("", false, "A894DocDpre", StringUtil.LTrimStr( A894DocDpre, 15, 4));
            }
            else
            {
               A894DocDpre = context.localUtil.CToN( cgiGet( edtDocDpre_Internalname), ".", ",");
               AssignAttri("", false, "A894DocDpre", StringUtil.LTrimStr( A894DocDpre, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDDct_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDDct_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDDCT");
               AnyError = 1;
               GX_FocusControl = edtDocDDct_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A896DocDDct = 0;
               AssignAttri("", false, "A896DocDDct", StringUtil.LTrimStr( A896DocDDct, 10, 2));
            }
            else
            {
               A896DocDDct = context.localUtil.CToN( cgiGet( edtDocDDct_Internalname), ".", ",");
               AssignAttri("", false, "A896DocDDct", StringUtil.LTrimStr( A896DocDDct, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDDct2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDDct2_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDDCT2");
               AnyError = 1;
               GX_FocusControl = edtDocDDct2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A897DocDDct2 = 0;
               AssignAttri("", false, "A897DocDDct2", StringUtil.LTrimStr( A897DocDDct2, 10, 2));
            }
            else
            {
               A897DocDDct2 = context.localUtil.CToN( cgiGet( edtDocDDct2_Internalname), ".", ",");
               AssignAttri("", false, "A897DocDDct2", StringUtil.LTrimStr( A897DocDDct2, 10, 2));
            }
            A893DocDSub = context.localUtil.CToN( cgiGet( edtDocDSub_Internalname), ".", ",");
            AssignAttri("", false, "A893DocDSub", StringUtil.LTrimStr( A893DocDSub, 15, 4));
            A892DocDTot = context.localUtil.CToN( cgiGet( edtDocDTot_Internalname), ".", ",");
            AssignAttri("", false, "A892DocDTot", StringUtil.LTrimStr( A892DocDTot, 18, 8));
            A900DocDDcto = context.localUtil.CToN( cgiGet( edtDocDDcto_Internalname), ".", ",");
            AssignAttri("", false, "A900DocDDcto", StringUtil.LTrimStr( A900DocDDcto, 15, 2));
            A1158LinStk = (short)(context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ","));
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A910DocDObs = cgiGet( edtDocDObs_Internalname);
            AssignAttri("", false, "A910DocDObs", A910DocDObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDIna_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDIna_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDINA");
               AnyError = 1;
               GX_FocusControl = edtDocDIna_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A898DocDIna = 0;
               AssignAttri("", false, "A898DocDIna", StringUtil.Str( (decimal)(A898DocDIna), 1, 0));
            }
            else
            {
               A898DocDIna = (short)(context.localUtil.CToN( cgiGet( edtDocDIna_Internalname), ".", ","));
               AssignAttri("", false, "A898DocDIna", StringUtil.Str( (decimal)(A898DocDIna), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDPorSel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDPorSel_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDPORSEL");
               AnyError = 1;
               GX_FocusControl = edtDocDPorSel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A912DocDPorSel = 0;
               AssignAttri("", false, "A912DocDPorSel", StringUtil.LTrimStr( A912DocDPorSel, 5, 2));
            }
            else
            {
               A912DocDPorSel = context.localUtil.CToN( cgiGet( edtDocDPorSel_Internalname), ".", ",");
               AssignAttri("", false, "A912DocDPorSel", StringUtil.LTrimStr( A912DocDPorSel, 5, 2));
            }
            A891DocDAfecto = context.localUtil.CToN( cgiGet( edtDocDAfecto_Internalname), ".", ",");
            AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
            A909DocDInafecto = context.localUtil.CToN( cgiGet( edtDocDInafecto_Internalname), ".", ",");
            AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
            A923DocDSelectivo = context.localUtil.CToN( cgiGet( edtDocDSelectivo_Internalname), ".", ",");
            AssignAttri("", false, "A923DocDSelectivo", StringUtil.LTrimStr( A923DocDSelectivo, 15, 4));
            A1703ProdPorSel = context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",");
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A914DocDRef1 = cgiGet( edtDocDRef1_Internalname);
            AssignAttri("", false, "A914DocDRef1", A914DocDRef1);
            A915DocDRef2 = cgiGet( edtDocDRef2_Internalname);
            AssignAttri("", false, "A915DocDRef2", A915DocDRef2);
            A916DocDRef3 = cgiGet( edtDocDRef3_Internalname);
            AssignAttri("", false, "A916DocDRef3", A916DocDRef3);
            A917DocDRef4 = cgiGet( edtDocDRef4_Internalname);
            AssignAttri("", false, "A917DocDRef4", A917DocDRef4);
            A911DocDPed = cgiGet( edtDocDPed_Internalname);
            AssignAttri("", false, "A911DocDPed", A911DocDPed);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLVENTASDET");
            forbiddenHiddens.Add("DocDPreInc", context.localUtil.Format( A913DocDPreInc, "ZZZZ,ZZZ,ZZ9.9999"));
            forbiddenHiddens.Add("DocDTotInc", context.localUtil.Format( A928DocDTotInc, "ZZZZZZ,ZZZ,ZZ9.99"));
            forbiddenHiddens.Add("DocDValSel", context.localUtil.Format( A926DocDValSel, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) || ( A233DocItem != Z233DocItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clventasdet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A149TipCod = GetPar( "TipCod");
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = GetPar( "DocNum");
               AssignAttri("", false, "A24DocNum", A24DocNum);
               A233DocItem = (long)(NumberUtil.Val( GetPar( "DocItem"), "."));
               AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
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
               InitAll2Z102( ) ;
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
         DisableAttributes2Z102( ) ;
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

      protected void CONFIRM_2Z0( )
      {
         BeforeValidate2Z102( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Z102( ) ;
            }
            else
            {
               CheckExtendedTable2Z102( ) ;
               if ( AnyError == 0 )
               {
                  ZM2Z102( 13) ;
                  ZM2Z102( 15) ;
                  ZM2Z102( 16) ;
                  ZM2Z102( 17) ;
               }
               CloseExtendedTableCursors2Z102( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2Z0( ) ;
         }
      }

      protected void ResetCaption2Z0( )
      {
      }

      protected void ZM2Z102( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z892DocDTot = T002Z3_A892DocDTot[0];
               Z905DocDICBPER = T002Z3_A905DocDICBPER[0];
               Z895DocDCan = T002Z3_A895DocDCan[0];
               Z894DocDpre = T002Z3_A894DocDpre[0];
               Z896DocDDct = T002Z3_A896DocDDct[0];
               Z897DocDDct2 = T002Z3_A897DocDDct2[0];
               Z898DocDIna = T002Z3_A898DocDIna[0];
               Z912DocDPorSel = T002Z3_A912DocDPorSel[0];
               Z914DocDRef1 = T002Z3_A914DocDRef1[0];
               Z915DocDRef2 = T002Z3_A915DocDRef2[0];
               Z916DocDRef3 = T002Z3_A916DocDRef3[0];
               Z917DocDRef4 = T002Z3_A917DocDRef4[0];
               Z911DocDPed = T002Z3_A911DocDPed[0];
               Z913DocDPreInc = T002Z3_A913DocDPreInc[0];
               Z928DocDTotInc = T002Z3_A928DocDTotInc[0];
               Z926DocDValSel = T002Z3_A926DocDValSel[0];
               Z28ProdCod = T002Z3_A28ProdCod[0];
            }
            else
            {
               Z892DocDTot = A892DocDTot;
               Z905DocDICBPER = A905DocDICBPER;
               Z895DocDCan = A895DocDCan;
               Z894DocDpre = A894DocDpre;
               Z896DocDDct = A896DocDDct;
               Z897DocDDct2 = A897DocDDct2;
               Z898DocDIna = A898DocDIna;
               Z912DocDPorSel = A912DocDPorSel;
               Z914DocDRef1 = A914DocDRef1;
               Z915DocDRef2 = A915DocDRef2;
               Z916DocDRef3 = A916DocDRef3;
               Z917DocDRef4 = A917DocDRef4;
               Z911DocDPed = A911DocDPed;
               Z913DocDPreInc = A913DocDPreInc;
               Z928DocDTotInc = A928DocDTotInc;
               Z926DocDValSel = A926DocDValSel;
               Z28ProdCod = A28ProdCod;
            }
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z932DocICBPER = T002Z7_A932DocICBPER[0];
            Z230DocMonCod = T002Z7_A230DocMonCod[0];
         }
         if ( GX_JID == -14 )
         {
            Z892DocDTot = A892DocDTot;
            Z905DocDICBPER = A905DocDICBPER;
            Z233DocItem = A233DocItem;
            Z895DocDCan = A895DocDCan;
            Z894DocDpre = A894DocDpre;
            Z896DocDDct = A896DocDDct;
            Z897DocDDct2 = A897DocDDct2;
            Z910DocDObs = A910DocDObs;
            Z898DocDIna = A898DocDIna;
            Z912DocDPorSel = A912DocDPorSel;
            Z914DocDRef1 = A914DocDRef1;
            Z915DocDRef2 = A915DocDRef2;
            Z916DocDRef3 = A916DocDRef3;
            Z917DocDRef4 = A917DocDRef4;
            Z911DocDPed = A911DocDPed;
            Z913DocDPreInc = A913DocDPreInc;
            Z928DocDTotInc = A928DocDTotInc;
            Z926DocDValSel = A926DocDValSel;
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
            Z28ProdCod = A28ProdCod;
            Z932DocICBPER = A932DocICBPER;
            Z230DocMonCod = A230DocMonCod;
            Z52LinCod = A52LinCod;
            Z55ProdDsc = A55ProdDsc;
            Z1703ProdPorSel = A1703ProdPorSel;
            Z908ProdValICBPERD = A908ProdValICBPERD;
            Z907ProdValICBPER = A907ProdValICBPER;
            Z906ProdAfecICBPER = A906ProdAfecICBPER;
            Z1158LinStk = A1158LinStk;
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

      protected void Load2Z102( )
      {
         /* Using cursor T002Z10 */
         pr_default.execute(7, new Object[] {A233DocItem, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound102 = 1;
            A52LinCod = T002Z10_A52LinCod[0];
            A932DocICBPER = T002Z10_A932DocICBPER[0];
            n932DocICBPER = T002Z10_n932DocICBPER[0];
            A892DocDTot = T002Z10_A892DocDTot[0];
            AssignAttri("", false, "A892DocDTot", StringUtil.LTrimStr( A892DocDTot, 18, 8));
            A905DocDICBPER = T002Z10_A905DocDICBPER[0];
            A55ProdDsc = T002Z10_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A895DocDCan = T002Z10_A895DocDCan[0];
            AssignAttri("", false, "A895DocDCan", StringUtil.LTrimStr( A895DocDCan, 15, 4));
            A894DocDpre = T002Z10_A894DocDpre[0];
            AssignAttri("", false, "A894DocDpre", StringUtil.LTrimStr( A894DocDpre, 15, 4));
            A896DocDDct = T002Z10_A896DocDDct[0];
            AssignAttri("", false, "A896DocDDct", StringUtil.LTrimStr( A896DocDDct, 10, 2));
            A897DocDDct2 = T002Z10_A897DocDDct2[0];
            AssignAttri("", false, "A897DocDDct2", StringUtil.LTrimStr( A897DocDDct2, 10, 2));
            A1158LinStk = T002Z10_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A910DocDObs = T002Z10_A910DocDObs[0];
            AssignAttri("", false, "A910DocDObs", A910DocDObs);
            A898DocDIna = T002Z10_A898DocDIna[0];
            AssignAttri("", false, "A898DocDIna", StringUtil.Str( (decimal)(A898DocDIna), 1, 0));
            A912DocDPorSel = T002Z10_A912DocDPorSel[0];
            AssignAttri("", false, "A912DocDPorSel", StringUtil.LTrimStr( A912DocDPorSel, 5, 2));
            A1703ProdPorSel = T002Z10_A1703ProdPorSel[0];
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A914DocDRef1 = T002Z10_A914DocDRef1[0];
            AssignAttri("", false, "A914DocDRef1", A914DocDRef1);
            A915DocDRef2 = T002Z10_A915DocDRef2[0];
            AssignAttri("", false, "A915DocDRef2", A915DocDRef2);
            A916DocDRef3 = T002Z10_A916DocDRef3[0];
            AssignAttri("", false, "A916DocDRef3", A916DocDRef3);
            A917DocDRef4 = T002Z10_A917DocDRef4[0];
            AssignAttri("", false, "A917DocDRef4", A917DocDRef4);
            A911DocDPed = T002Z10_A911DocDPed[0];
            AssignAttri("", false, "A911DocDPed", A911DocDPed);
            A913DocDPreInc = T002Z10_A913DocDPreInc[0];
            A928DocDTotInc = T002Z10_A928DocDTotInc[0];
            A926DocDValSel = T002Z10_A926DocDValSel[0];
            A908ProdValICBPERD = T002Z10_A908ProdValICBPERD[0];
            A907ProdValICBPER = T002Z10_A907ProdValICBPER[0];
            A906ProdAfecICBPER = T002Z10_A906ProdAfecICBPER[0];
            A28ProdCod = T002Z10_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A230DocMonCod = T002Z10_A230DocMonCod[0];
            ZM2Z102( -14) ;
         }
         pr_default.close(7);
         OnLoadActions2Z102( ) ;
      }

      protected void OnLoadActions2Z102( )
      {
         A905DocDICBPER = ((A906ProdAfecICBPER==1) ? ((A230DocMonCod==1) ? A907ProdValICBPER*A895DocDCan : A908ProdValICBPERD*A895DocDCan) : (decimal)(0));
         AssignAttri("", false, "A905DocDICBPER", StringUtil.LTrimStr( A905DocDICBPER, 15, 2));
         A925DocDSelectivoValor = (decimal)(A895DocDCan*A926DocDValSel);
         AssignAttri("", false, "A925DocDSelectivoValor", StringUtil.LTrimStr( A925DocDSelectivoValor, 15, 2));
         A893DocDSub = NumberUtil.Round( A894DocDpre*A895DocDCan, 4);
         AssignAttri("", false, "A893DocDSub", StringUtil.LTrimStr( A893DocDSub, 15, 4));
         A892DocDTot = NumberUtil.Round( (A893DocDSub)*(1-A896DocDDct/ (decimal)(100))*(1-A897DocDDct2/ (decimal)(100)), 2);
         AssignAttri("", false, "A892DocDTot", StringUtil.LTrimStr( A892DocDTot, 18, 8));
         A900DocDDcto = NumberUtil.Round( A893DocDSub-A892DocDTot, 2);
         AssignAttri("", false, "A900DocDDcto", StringUtil.LTrimStr( A900DocDDcto, 15, 2));
         if ( A898DocDIna == 1 )
         {
            A909DocDInafecto = A892DocDTot;
            AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
         }
         else
         {
            A909DocDInafecto = 0;
            AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
         }
         if ( A898DocDIna == 4 )
         {
            A903DocDGratuitoIna = A892DocDTot;
            AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
         }
         else
         {
            A903DocDGratuitoIna = 0;
            AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
         }
         if ( A898DocDIna == 3 )
         {
            A902DocDGratuito = A892DocDTot;
            AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
         }
         else
         {
            A902DocDGratuito = 0;
            AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
         }
         if ( A898DocDIna == 2 )
         {
            A901DocDExonerado = A892DocDTot;
            AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
         }
         else
         {
            A901DocDExonerado = 0;
            AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
         }
         if ( A898DocDIna == 0 )
         {
            A891DocDAfecto = A892DocDTot;
            AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
         }
         else
         {
            A891DocDAfecto = 0;
            AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
         }
         A924DocDSelectivoPor = NumberUtil.Round( (A892DocDTot*A912DocDPorSel)/ (decimal)(100), 2);
         AssignAttri("", false, "A924DocDSelectivoPor", StringUtil.LTrimStr( A924DocDSelectivoPor, 15, 2));
         A923DocDSelectivo = (decimal)(A924DocDSelectivoPor+A925DocDSelectivoValor);
         AssignAttri("", false, "A923DocDSelectivo", StringUtil.LTrimStr( A923DocDSelectivo, 15, 4));
      }

      protected void CheckExtendedTable2Z102( )
      {
         nIsDirty_102 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002Z7 */
         pr_default.execute(4, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A932DocICBPER = T002Z7_A932DocICBPER[0];
         n932DocICBPER = T002Z7_n932DocICBPER[0];
         A230DocMonCod = T002Z7_A230DocMonCod[0];
         pr_default.close(4);
         /* Using cursor T002Z8 */
         pr_default.execute(5, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A52LinCod = T002Z8_A52LinCod[0];
         A55ProdDsc = T002Z8_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1703ProdPorSel = T002Z8_A1703ProdPorSel[0];
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
         A908ProdValICBPERD = T002Z8_A908ProdValICBPERD[0];
         A907ProdValICBPER = T002Z8_A907ProdValICBPER[0];
         A906ProdAfecICBPER = T002Z8_A906ProdAfecICBPER[0];
         pr_default.close(5);
         /* Using cursor T002Z9 */
         pr_default.execute(6, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
         }
         A1158LinStk = T002Z9_A1158LinStk[0];
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         pr_default.close(6);
         nIsDirty_102 = 1;
         A905DocDICBPER = ((A906ProdAfecICBPER==1) ? ((A230DocMonCod==1) ? A907ProdValICBPER*A895DocDCan : A908ProdValICBPERD*A895DocDCan) : (decimal)(0));
         AssignAttri("", false, "A905DocDICBPER", StringUtil.LTrimStr( A905DocDICBPER, 15, 2));
         nIsDirty_102 = 1;
         A925DocDSelectivoValor = (decimal)(A895DocDCan*A926DocDValSel);
         AssignAttri("", false, "A925DocDSelectivoValor", StringUtil.LTrimStr( A925DocDSelectivoValor, 15, 2));
         nIsDirty_102 = 1;
         A893DocDSub = NumberUtil.Round( A894DocDpre*A895DocDCan, 4);
         AssignAttri("", false, "A893DocDSub", StringUtil.LTrimStr( A893DocDSub, 15, 4));
         nIsDirty_102 = 1;
         A892DocDTot = NumberUtil.Round( (A893DocDSub)*(1-A896DocDDct/ (decimal)(100))*(1-A897DocDDct2/ (decimal)(100)), 2);
         AssignAttri("", false, "A892DocDTot", StringUtil.LTrimStr( A892DocDTot, 18, 8));
         nIsDirty_102 = 1;
         A900DocDDcto = NumberUtil.Round( A893DocDSub-A892DocDTot, 2);
         AssignAttri("", false, "A900DocDDcto", StringUtil.LTrimStr( A900DocDDcto, 15, 2));
         if ( A898DocDIna == 1 )
         {
            nIsDirty_102 = 1;
            A909DocDInafecto = A892DocDTot;
            AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
         }
         else
         {
            nIsDirty_102 = 1;
            A909DocDInafecto = 0;
            AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
         }
         if ( A898DocDIna == 4 )
         {
            nIsDirty_102 = 1;
            A903DocDGratuitoIna = A892DocDTot;
            AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
         }
         else
         {
            nIsDirty_102 = 1;
            A903DocDGratuitoIna = 0;
            AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
         }
         if ( A898DocDIna == 3 )
         {
            nIsDirty_102 = 1;
            A902DocDGratuito = A892DocDTot;
            AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
         }
         else
         {
            nIsDirty_102 = 1;
            A902DocDGratuito = 0;
            AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
         }
         if ( A898DocDIna == 2 )
         {
            nIsDirty_102 = 1;
            A901DocDExonerado = A892DocDTot;
            AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
         }
         else
         {
            nIsDirty_102 = 1;
            A901DocDExonerado = 0;
            AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
         }
         if ( A898DocDIna == 0 )
         {
            nIsDirty_102 = 1;
            A891DocDAfecto = A892DocDTot;
            AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
         }
         else
         {
            nIsDirty_102 = 1;
            A891DocDAfecto = 0;
            AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
         }
         nIsDirty_102 = 1;
         A924DocDSelectivoPor = NumberUtil.Round( (A892DocDTot*A912DocDPorSel)/ (decimal)(100), 2);
         AssignAttri("", false, "A924DocDSelectivoPor", StringUtil.LTrimStr( A924DocDSelectivoPor, 15, 2));
         nIsDirty_102 = 1;
         A923DocDSelectivo = (decimal)(A924DocDSelectivoPor+A925DocDSelectivoValor);
         AssignAttri("", false, "A923DocDSelectivo", StringUtil.LTrimStr( A923DocDSelectivo, 15, 4));
      }

      protected void CloseExtendedTableCursors2Z102( )
      {
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( string A149TipCod ,
                                string A24DocNum )
      {
         /* Using cursor T002Z7 */
         pr_default.execute(4, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A932DocICBPER = T002Z7_A932DocICBPER[0];
         n932DocICBPER = T002Z7_n932DocICBPER[0];
         A230DocMonCod = T002Z7_A230DocMonCod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A230DocMonCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void gxLoad_16( string A28ProdCod )
      {
         /* Using cursor T002Z11 */
         pr_default.execute(8, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A52LinCod = T002Z11_A52LinCod[0];
         A55ProdDsc = T002Z11_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1703ProdPorSel = T002Z11_A1703ProdPorSel[0];
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
         A908ProdValICBPERD = T002Z11_A908ProdValICBPERD[0];
         A907ProdValICBPER = T002Z11_A907ProdValICBPER[0];
         A906ProdAfecICBPER = T002Z11_A906ProdAfecICBPER[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A55ProdDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_17( int A52LinCod )
      {
         /* Using cursor T002Z12 */
         pr_default.execute(9, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
         }
         A1158LinStk = T002Z12_A1158LinStk[0];
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey2Z102( )
      {
         /* Using cursor T002Z13 */
         pr_default.execute(10, new Object[] {A149TipCod, A24DocNum, A233DocItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound102 = 1;
         }
         else
         {
            RcdFound102 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Z3 */
         pr_default.execute(1, new Object[] {A149TipCod, A24DocNum, A233DocItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Z102( 14) ;
            RcdFound102 = 1;
            A892DocDTot = T002Z3_A892DocDTot[0];
            AssignAttri("", false, "A892DocDTot", StringUtil.LTrimStr( A892DocDTot, 18, 8));
            A905DocDICBPER = T002Z3_A905DocDICBPER[0];
            A233DocItem = T002Z3_A233DocItem[0];
            AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
            A895DocDCan = T002Z3_A895DocDCan[0];
            AssignAttri("", false, "A895DocDCan", StringUtil.LTrimStr( A895DocDCan, 15, 4));
            A894DocDpre = T002Z3_A894DocDpre[0];
            AssignAttri("", false, "A894DocDpre", StringUtil.LTrimStr( A894DocDpre, 15, 4));
            A896DocDDct = T002Z3_A896DocDDct[0];
            AssignAttri("", false, "A896DocDDct", StringUtil.LTrimStr( A896DocDDct, 10, 2));
            A897DocDDct2 = T002Z3_A897DocDDct2[0];
            AssignAttri("", false, "A897DocDDct2", StringUtil.LTrimStr( A897DocDDct2, 10, 2));
            A910DocDObs = T002Z3_A910DocDObs[0];
            AssignAttri("", false, "A910DocDObs", A910DocDObs);
            A898DocDIna = T002Z3_A898DocDIna[0];
            AssignAttri("", false, "A898DocDIna", StringUtil.Str( (decimal)(A898DocDIna), 1, 0));
            A912DocDPorSel = T002Z3_A912DocDPorSel[0];
            AssignAttri("", false, "A912DocDPorSel", StringUtil.LTrimStr( A912DocDPorSel, 5, 2));
            A914DocDRef1 = T002Z3_A914DocDRef1[0];
            AssignAttri("", false, "A914DocDRef1", A914DocDRef1);
            A915DocDRef2 = T002Z3_A915DocDRef2[0];
            AssignAttri("", false, "A915DocDRef2", A915DocDRef2);
            A916DocDRef3 = T002Z3_A916DocDRef3[0];
            AssignAttri("", false, "A916DocDRef3", A916DocDRef3);
            A917DocDRef4 = T002Z3_A917DocDRef4[0];
            AssignAttri("", false, "A917DocDRef4", A917DocDRef4);
            A911DocDPed = T002Z3_A911DocDPed[0];
            AssignAttri("", false, "A911DocDPed", A911DocDPed);
            A913DocDPreInc = T002Z3_A913DocDPreInc[0];
            A928DocDTotInc = T002Z3_A928DocDTotInc[0];
            A926DocDValSel = T002Z3_A926DocDValSel[0];
            A149TipCod = T002Z3_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T002Z3_A24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A28ProdCod = T002Z3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
            Z233DocItem = A233DocItem;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2Z102( ) ;
            if ( AnyError == 1 )
            {
               RcdFound102 = 0;
               InitializeNonKey2Z102( ) ;
            }
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound102 = 0;
            InitializeNonKey2Z102( ) ;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Z102( ) ;
         if ( RcdFound102 == 0 )
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
         RcdFound102 = 0;
         /* Using cursor T002Z14 */
         pr_default.execute(11, new Object[] {A233DocItem, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002Z14_A233DocItem[0] < A233DocItem ) || ( T002Z14_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z14_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T002Z14_A149TipCod[0], A149TipCod) == 0 ) && ( T002Z14_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z14_A24DocNum[0], A24DocNum) < 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002Z14_A233DocItem[0] > A233DocItem ) || ( T002Z14_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z14_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T002Z14_A149TipCod[0], A149TipCod) == 0 ) && ( T002Z14_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z14_A24DocNum[0], A24DocNum) > 0 ) ) )
            {
               A233DocItem = T002Z14_A233DocItem[0];
               AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
               A149TipCod = T002Z14_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = T002Z14_A24DocNum[0];
               AssignAttri("", false, "A24DocNum", A24DocNum);
               RcdFound102 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound102 = 0;
         /* Using cursor T002Z15 */
         pr_default.execute(12, new Object[] {A233DocItem, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T002Z15_A233DocItem[0] > A233DocItem ) || ( T002Z15_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z15_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T002Z15_A149TipCod[0], A149TipCod) == 0 ) && ( T002Z15_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z15_A24DocNum[0], A24DocNum) > 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T002Z15_A233DocItem[0] < A233DocItem ) || ( T002Z15_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z15_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T002Z15_A149TipCod[0], A149TipCod) == 0 ) && ( T002Z15_A233DocItem[0] == A233DocItem ) && ( StringUtil.StrCmp(T002Z15_A24DocNum[0], A24DocNum) < 0 ) ) )
            {
               A233DocItem = T002Z15_A233DocItem[0];
               AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
               A149TipCod = T002Z15_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = T002Z15_A24DocNum[0];
               AssignAttri("", false, "A24DocNum", A24DocNum);
               RcdFound102 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Z102( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Z102( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound102 == 1 )
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) || ( A233DocItem != Z233DocItem ) )
               {
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  A24DocNum = Z24DocNum;
                  AssignAttri("", false, "A24DocNum", A24DocNum);
                  A233DocItem = Z233DocItem;
                  AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2Z102( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) || ( A233DocItem != Z233DocItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Z102( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Z102( ) ;
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
         if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) || ( A233DocItem != Z233DocItem ) )
         {
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = Z24DocNum;
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A233DocItem = Z233DocItem;
            AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipCod_Internalname;
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
         GetKey2Z102( ) ;
         if ( RcdFound102 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) || ( A233DocItem != Z233DocItem ) )
            {
               A149TipCod = Z149TipCod;
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = Z24DocNum;
               AssignAttri("", false, "A24DocNum", A24DocNum);
               A233DocItem = Z233DocItem;
               AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) || ( A233DocItem != Z233DocItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
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
         pr_default.close(2);
         context.RollbackDataStores("clventasdet",pr_default);
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2Z0( ) ;
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
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
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
         ScanStart2Z102( ) ;
         if ( RcdFound102 == 0 )
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
         ScanEnd2Z102( ) ;
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
         if ( RcdFound102 == 0 )
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
         if ( RcdFound102 == 0 )
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
         ScanStart2Z102( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound102 != 0 )
            {
               ScanNext2Z102( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Z102( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2Z102( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Z2 */
            pr_default.execute(0, new Object[] {A149TipCod, A24DocNum, A233DocItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTASDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z892DocDTot != T002Z2_A892DocDTot[0] ) || ( Z905DocDICBPER != T002Z2_A905DocDICBPER[0] ) || ( Z895DocDCan != T002Z2_A895DocDCan[0] ) || ( Z894DocDpre != T002Z2_A894DocDpre[0] ) || ( Z896DocDDct != T002Z2_A896DocDDct[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z897DocDDct2 != T002Z2_A897DocDDct2[0] ) || ( Z898DocDIna != T002Z2_A898DocDIna[0] ) || ( Z912DocDPorSel != T002Z2_A912DocDPorSel[0] ) || ( StringUtil.StrCmp(Z914DocDRef1, T002Z2_A914DocDRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z915DocDRef2, T002Z2_A915DocDRef2[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z916DocDRef3, T002Z2_A916DocDRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z917DocDRef4, T002Z2_A917DocDRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z911DocDPed, T002Z2_A911DocDPed[0]) != 0 ) || ( Z913DocDPreInc != T002Z2_A913DocDPreInc[0] ) || ( Z928DocDTotInc != T002Z2_A928DocDTotInc[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z926DocDValSel != T002Z2_A926DocDValSel[0] ) || ( StringUtil.StrCmp(Z28ProdCod, T002Z2_A28ProdCod[0]) != 0 ) )
            {
               if ( Z892DocDTot != T002Z2_A892DocDTot[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDTot");
                  GXUtil.WriteLogRaw("Old: ",Z892DocDTot);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A892DocDTot[0]);
               }
               if ( Z905DocDICBPER != T002Z2_A905DocDICBPER[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z905DocDICBPER);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A905DocDICBPER[0]);
               }
               if ( Z895DocDCan != T002Z2_A895DocDCan[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDCan");
                  GXUtil.WriteLogRaw("Old: ",Z895DocDCan);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A895DocDCan[0]);
               }
               if ( Z894DocDpre != T002Z2_A894DocDpre[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDpre");
                  GXUtil.WriteLogRaw("Old: ",Z894DocDpre);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A894DocDpre[0]);
               }
               if ( Z896DocDDct != T002Z2_A896DocDDct[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDDct");
                  GXUtil.WriteLogRaw("Old: ",Z896DocDDct);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A896DocDDct[0]);
               }
               if ( Z897DocDDct2 != T002Z2_A897DocDDct2[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDDct2");
                  GXUtil.WriteLogRaw("Old: ",Z897DocDDct2);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A897DocDDct2[0]);
               }
               if ( Z898DocDIna != T002Z2_A898DocDIna[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDIna");
                  GXUtil.WriteLogRaw("Old: ",Z898DocDIna);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A898DocDIna[0]);
               }
               if ( Z912DocDPorSel != T002Z2_A912DocDPorSel[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDPorSel");
                  GXUtil.WriteLogRaw("Old: ",Z912DocDPorSel);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A912DocDPorSel[0]);
               }
               if ( StringUtil.StrCmp(Z914DocDRef1, T002Z2_A914DocDRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDRef1");
                  GXUtil.WriteLogRaw("Old: ",Z914DocDRef1);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A914DocDRef1[0]);
               }
               if ( StringUtil.StrCmp(Z915DocDRef2, T002Z2_A915DocDRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDRef2");
                  GXUtil.WriteLogRaw("Old: ",Z915DocDRef2);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A915DocDRef2[0]);
               }
               if ( StringUtil.StrCmp(Z916DocDRef3, T002Z2_A916DocDRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDRef3");
                  GXUtil.WriteLogRaw("Old: ",Z916DocDRef3);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A916DocDRef3[0]);
               }
               if ( StringUtil.StrCmp(Z917DocDRef4, T002Z2_A917DocDRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDRef4");
                  GXUtil.WriteLogRaw("Old: ",Z917DocDRef4);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A917DocDRef4[0]);
               }
               if ( StringUtil.StrCmp(Z911DocDPed, T002Z2_A911DocDPed[0]) != 0 )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDPed");
                  GXUtil.WriteLogRaw("Old: ",Z911DocDPed);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A911DocDPed[0]);
               }
               if ( Z913DocDPreInc != T002Z2_A913DocDPreInc[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDPreInc");
                  GXUtil.WriteLogRaw("Old: ",Z913DocDPreInc);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A913DocDPreInc[0]);
               }
               if ( Z928DocDTotInc != T002Z2_A928DocDTotInc[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDTotInc");
                  GXUtil.WriteLogRaw("Old: ",Z928DocDTotInc);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A928DocDTotInc[0]);
               }
               if ( Z926DocDValSel != T002Z2_A926DocDValSel[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocDValSel");
                  GXUtil.WriteLogRaw("Old: ",Z926DocDValSel);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A926DocDValSel[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T002Z2_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T002Z2_A28ProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLVENTASDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T002Z16 */
         pr_default.execute(13, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(13) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTAS"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( Z932DocICBPER != T002Z16_A932DocICBPER[0] ) || ( Z230DocMonCod != T002Z16_A230DocMonCod[0] ) )
            {
               if ( Z932DocICBPER != T002Z16_A932DocICBPER[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z932DocICBPER);
                  GXUtil.WriteLogRaw("Current: ",T002Z16_A932DocICBPER[0]);
               }
               if ( Z230DocMonCod != T002Z16_A230DocMonCod[0] )
               {
                  GXUtil.WriteLog("clventasdet:[seudo value changed for attri]"+"DocMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z230DocMonCod);
                  GXUtil.WriteLogRaw("Current: ",T002Z16_A230DocMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLVENTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Z102( )
      {
         BeforeValidate2Z102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Z102( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Z102( 0) ;
            CheckOptimisticConcurrency2Z102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Z102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Z102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Z17 */
                     pr_default.execute(14, new Object[] {A892DocDTot, A905DocDICBPER, A233DocItem, A895DocDCan, A894DocDpre, A896DocDDct, A897DocDDct2, A910DocDObs, A898DocDIna, A912DocDPorSel, A914DocDRef1, A915DocDRef2, A916DocDRef3, A917DocDRef4, A911DocDPed, A913DocDPreInc, A928DocDTotInc, A926DocDValSel, A149TipCod, A24DocNum, A28ProdCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
                     if ( (pr_default.getStatus(14) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( level) rules */
                        /* Using cursor T002Z19 */
                        pr_default.execute(15, new Object[] {A149TipCod, A24DocNum});
                        A932DocICBPER = T002Z19_A932DocICBPER[0];
                        n932DocICBPER = T002Z19_n932DocICBPER[0];
                        pr_default.close(15);
                        /* End of After( level) rules */
                        UpdateTablesN12Z102( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2Z0( ) ;
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
               Load2Z102( ) ;
            }
            EndLevel2Z102( ) ;
         }
         CloseExtendedTableCursors2Z102( ) ;
      }

      protected void Update2Z102( )
      {
         BeforeValidate2Z102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Z102( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Z102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Z102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Z102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Z20 */
                     pr_default.execute(16, new Object[] {A892DocDTot, A905DocDICBPER, A895DocDCan, A894DocDpre, A896DocDDct, A897DocDDct2, A910DocDObs, A898DocDIna, A912DocDPorSel, A914DocDRef1, A915DocDRef2, A916DocDRef3, A917DocDRef4, A911DocDPed, A913DocDPreInc, A928DocDTotInc, A926DocDValSel, A28ProdCod, A149TipCod, A24DocNum, A233DocItem});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTASDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Z102( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( level) rules */
                        /* Using cursor T002Z22 */
                        pr_default.execute(17, new Object[] {A149TipCod, A24DocNum});
                        A932DocICBPER = T002Z22_A932DocICBPER[0];
                        n932DocICBPER = T002Z22_n932DocICBPER[0];
                        pr_default.close(17);
                        /* End of After( level) rules */
                        UpdateTablesN12Z102( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2Z0( ) ;
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
            EndLevel2Z102( ) ;
         }
         CloseExtendedTableCursors2Z102( ) ;
      }

      protected void DeferredUpdate2Z102( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2Z102( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Z102( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Z102( ) ;
            AfterConfirm2Z102( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Z102( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Z23 */
                  pr_default.execute(18, new Object[] {A149TipCod, A24DocNum, A233DocItem});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( level) rules */
                     /* Using cursor T002Z25 */
                     pr_default.execute(19, new Object[] {A149TipCod, A24DocNum});
                     A932DocICBPER = T002Z25_A932DocICBPER[0];
                     n932DocICBPER = T002Z25_n932DocICBPER[0];
                     pr_default.close(19);
                     /* End of After( level) rules */
                     UpdateTablesN12Z102( ) ;
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound102 == 0 )
                        {
                           InitAll2Z102( ) ;
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
                        ResetCaption2Z0( ) ;
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
         sMode102 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Z102( ) ;
         Gx_mode = sMode102;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Z102( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002Z26 */
            pr_default.execute(20, new Object[] {A149TipCod, A24DocNum});
            Z932DocICBPER = T002Z26_A932DocICBPER[0];
            Z230DocMonCod = T002Z26_A230DocMonCod[0];
            A932DocICBPER = T002Z26_A932DocICBPER[0];
            n932DocICBPER = T002Z26_n932DocICBPER[0];
            A230DocMonCod = T002Z26_A230DocMonCod[0];
            pr_default.close(20);
            /* Using cursor T002Z27 */
            pr_default.execute(21, new Object[] {A28ProdCod});
            A52LinCod = T002Z27_A52LinCod[0];
            A55ProdDsc = T002Z27_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1703ProdPorSel = T002Z27_A1703ProdPorSel[0];
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A908ProdValICBPERD = T002Z27_A908ProdValICBPERD[0];
            A907ProdValICBPER = T002Z27_A907ProdValICBPER[0];
            A906ProdAfecICBPER = T002Z27_A906ProdAfecICBPER[0];
            pr_default.close(21);
            /* Using cursor T002Z28 */
            pr_default.execute(22, new Object[] {A52LinCod});
            A1158LinStk = T002Z28_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            pr_default.close(22);
            A893DocDSub = NumberUtil.Round( A894DocDpre*A895DocDCan, 4);
            AssignAttri("", false, "A893DocDSub", StringUtil.LTrimStr( A893DocDSub, 15, 4));
            A900DocDDcto = NumberUtil.Round( A893DocDSub-A892DocDTot, 2);
            AssignAttri("", false, "A900DocDDcto", StringUtil.LTrimStr( A900DocDDcto, 15, 2));
            A924DocDSelectivoPor = NumberUtil.Round( (A892DocDTot*A912DocDPorSel)/ (decimal)(100), 2);
            AssignAttri("", false, "A924DocDSelectivoPor", StringUtil.LTrimStr( A924DocDSelectivoPor, 15, 2));
            if ( A898DocDIna == 1 )
            {
               A909DocDInafecto = A892DocDTot;
               AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
            }
            else
            {
               A909DocDInafecto = 0;
               AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
            }
            if ( A898DocDIna == 4 )
            {
               A903DocDGratuitoIna = A892DocDTot;
               AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
            }
            else
            {
               A903DocDGratuitoIna = 0;
               AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
            }
            if ( A898DocDIna == 3 )
            {
               A902DocDGratuito = A892DocDTot;
               AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
            }
            else
            {
               A902DocDGratuito = 0;
               AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
            }
            if ( A898DocDIna == 2 )
            {
               A901DocDExonerado = A892DocDTot;
               AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
            }
            else
            {
               A901DocDExonerado = 0;
               AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
            }
            if ( A898DocDIna == 0 )
            {
               A891DocDAfecto = A892DocDTot;
               AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
            }
            else
            {
               A891DocDAfecto = 0;
               AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
            }
            A925DocDSelectivoValor = (decimal)(A895DocDCan*A926DocDValSel);
            AssignAttri("", false, "A925DocDSelectivoValor", StringUtil.LTrimStr( A925DocDSelectivoValor, 15, 2));
            A923DocDSelectivo = (decimal)(A924DocDSelectivoPor+A925DocDSelectivoValor);
            AssignAttri("", false, "A923DocDSelectivo", StringUtil.LTrimStr( A923DocDSelectivo, 15, 4));
         }
      }

      protected void UpdateTablesN12Z102( )
      {
         /* Using cursor T002Z29 */
         pr_default.execute(23, new Object[] {n932DocICBPER, A932DocICBPER, A149TipCod, A24DocNum});
         pr_default.close(23);
         dsDefault.SmartCacheProvider.SetUpdated("CLVENTAS");
      }

      protected void EndLevel2Z102( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(13);
         if ( AnyError == 0 )
         {
            BeforeComplete2Z102( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(17);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            context.CommitDataStores("clventasdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(17);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            context.RollbackDataStores("clventasdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Z102( )
      {
         /* Using cursor T002Z30 */
         pr_default.execute(24);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound102 = 1;
            A149TipCod = T002Z30_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T002Z30_A24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A233DocItem = T002Z30_A233DocItem[0];
            AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Z102( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound102 = 1;
            A149TipCod = T002Z30_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T002Z30_A24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A233DocItem = T002Z30_A233DocItem[0];
            AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
         }
      }

      protected void ScanEnd2Z102( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm2Z102( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Z102( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Z102( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Z102( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Z102( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Z102( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Z102( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtDocNum_Enabled = 0;
         AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), true);
         edtDocItem_Enabled = 0;
         AssignProp("", false, edtDocItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocItem_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtDocDCan_Enabled = 0;
         AssignProp("", false, edtDocDCan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDCan_Enabled), 5, 0), true);
         edtDocDpre_Enabled = 0;
         AssignProp("", false, edtDocDpre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDpre_Enabled), 5, 0), true);
         edtDocDDct_Enabled = 0;
         AssignProp("", false, edtDocDDct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDDct_Enabled), 5, 0), true);
         edtDocDDct2_Enabled = 0;
         AssignProp("", false, edtDocDDct2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDDct2_Enabled), 5, 0), true);
         edtDocDSub_Enabled = 0;
         AssignProp("", false, edtDocDSub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDSub_Enabled), 5, 0), true);
         edtDocDTot_Enabled = 0;
         AssignProp("", false, edtDocDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDTot_Enabled), 5, 0), true);
         edtDocDDcto_Enabled = 0;
         AssignProp("", false, edtDocDDcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDDcto_Enabled), 5, 0), true);
         edtLinStk_Enabled = 0;
         AssignProp("", false, edtLinStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinStk_Enabled), 5, 0), true);
         edtDocDObs_Enabled = 0;
         AssignProp("", false, edtDocDObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDObs_Enabled), 5, 0), true);
         edtDocDIna_Enabled = 0;
         AssignProp("", false, edtDocDIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDIna_Enabled), 5, 0), true);
         edtDocDPorSel_Enabled = 0;
         AssignProp("", false, edtDocDPorSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDPorSel_Enabled), 5, 0), true);
         edtDocDAfecto_Enabled = 0;
         AssignProp("", false, edtDocDAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDAfecto_Enabled), 5, 0), true);
         edtDocDInafecto_Enabled = 0;
         AssignProp("", false, edtDocDInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDInafecto_Enabled), 5, 0), true);
         edtDocDSelectivo_Enabled = 0;
         AssignProp("", false, edtDocDSelectivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDSelectivo_Enabled), 5, 0), true);
         edtProdPorSel_Enabled = 0;
         AssignProp("", false, edtProdPorSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdPorSel_Enabled), 5, 0), true);
         edtDocDRef1_Enabled = 0;
         AssignProp("", false, edtDocDRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDRef1_Enabled), 5, 0), true);
         edtDocDRef2_Enabled = 0;
         AssignProp("", false, edtDocDRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDRef2_Enabled), 5, 0), true);
         edtDocDRef3_Enabled = 0;
         AssignProp("", false, edtDocDRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDRef3_Enabled), 5, 0), true);
         edtDocDRef4_Enabled = 0;
         AssignProp("", false, edtDocDRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDRef4_Enabled), 5, 0), true);
         edtDocDPed_Enabled = 0;
         AssignProp("", false, edtDocDPed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDPed_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Z102( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Z0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245420", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clventasdet.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLVENTASDET");
         forbiddenHiddens.Add("DocDPreInc", context.localUtil.Format( A913DocDPreInc, "ZZZZ,ZZZ,ZZ9.9999"));
         forbiddenHiddens.Add("DocDTotInc", context.localUtil.Format( A928DocDTotInc, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("DocDValSel", context.localUtil.Format( A926DocDValSel, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clventasdet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z233DocItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233DocItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z892DocDTot", StringUtil.LTrim( StringUtil.NToC( Z892DocDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z905DocDICBPER", StringUtil.LTrim( StringUtil.NToC( Z905DocDICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z895DocDCan", StringUtil.LTrim( StringUtil.NToC( Z895DocDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z894DocDpre", StringUtil.LTrim( StringUtil.NToC( Z894DocDpre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z896DocDDct", StringUtil.LTrim( StringUtil.NToC( Z896DocDDct, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z897DocDDct2", StringUtil.LTrim( StringUtil.NToC( Z897DocDDct2, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z898DocDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z898DocDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z912DocDPorSel", StringUtil.LTrim( StringUtil.NToC( Z912DocDPorSel, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z914DocDRef1", Z914DocDRef1);
         GxWebStd.gx_hidden_field( context, "Z915DocDRef2", Z915DocDRef2);
         GxWebStd.gx_hidden_field( context, "Z916DocDRef3", Z916DocDRef3);
         GxWebStd.gx_hidden_field( context, "Z917DocDRef4", Z917DocDRef4);
         GxWebStd.gx_hidden_field( context, "Z911DocDPed", Z911DocDPed);
         GxWebStd.gx_hidden_field( context, "Z913DocDPreInc", StringUtil.LTrim( StringUtil.NToC( Z913DocDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z928DocDTotInc", StringUtil.LTrim( StringUtil.NToC( Z928DocDTotInc, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z926DocDValSel", StringUtil.LTrim( StringUtil.NToC( Z926DocDValSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z932DocICBPER", StringUtil.LTrim( StringUtil.NToC( Z932DocICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z230DocMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "DOCDVALSEL", StringUtil.LTrim( StringUtil.NToC( A926DocDValSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDSELECTIVOVALOR", StringUtil.LTrim( StringUtil.NToC( A925DocDSelectivoValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODAFECICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCMONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230DocMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDICBPER", StringUtil.LTrim( StringUtil.NToC( A905DocDICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDSELECTIVOPOR", StringUtil.LTrim( StringUtil.NToC( A924DocDSelectivoPor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDGRATUITOINA", StringUtil.LTrim( StringUtil.NToC( A903DocDGratuitoIna, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDGRATUITO", StringUtil.LTrim( StringUtil.NToC( A902DocDGratuito, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDEXONERADO", StringUtil.LTrim( StringUtil.NToC( A901DocDExonerado, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDPREINC", StringUtil.LTrim( StringUtil.NToC( A913DocDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCDTOTINC", StringUtil.LTrim( StringUtil.NToC( A928DocDTotInc, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCICBPER", StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "LINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
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
         return formatLink("clventasdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLVENTASDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ventas - Cabecera" ;
      }

      protected void InitializeNonKey2Z102( )
      {
         A52LinCod = 0;
         AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         A932DocICBPER = 0;
         n932DocICBPER = false;
         AssignAttri("", false, "A932DocICBPER", StringUtil.LTrimStr( A932DocICBPER, 15, 2));
         A923DocDSelectivo = 0;
         AssignAttri("", false, "A923DocDSelectivo", StringUtil.LTrimStr( A923DocDSelectivo, 15, 4));
         A891DocDAfecto = 0;
         AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrimStr( A891DocDAfecto, 15, 4));
         A901DocDExonerado = 0;
         AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrimStr( A901DocDExonerado, 15, 4));
         A902DocDGratuito = 0;
         AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrimStr( A902DocDGratuito, 15, 4));
         A903DocDGratuitoIna = 0;
         AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrimStr( A903DocDGratuitoIna, 15, 4));
         A909DocDInafecto = 0;
         AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrimStr( A909DocDInafecto, 15, 4));
         A924DocDSelectivoPor = 0;
         AssignAttri("", false, "A924DocDSelectivoPor", StringUtil.LTrimStr( A924DocDSelectivoPor, 15, 2));
         A900DocDDcto = 0;
         AssignAttri("", false, "A900DocDDcto", StringUtil.LTrimStr( A900DocDDcto, 15, 2));
         A892DocDTot = 0;
         AssignAttri("", false, "A892DocDTot", StringUtil.LTrimStr( A892DocDTot, 18, 8));
         A893DocDSub = 0;
         AssignAttri("", false, "A893DocDSub", StringUtil.LTrimStr( A893DocDSub, 15, 4));
         A905DocDICBPER = 0;
         AssignAttri("", false, "A905DocDICBPER", StringUtil.LTrimStr( A905DocDICBPER, 15, 2));
         A925DocDSelectivoValor = 0;
         AssignAttri("", false, "A925DocDSelectivoValor", StringUtil.LTrimStr( A925DocDSelectivoValor, 15, 2));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A895DocDCan = 0;
         AssignAttri("", false, "A895DocDCan", StringUtil.LTrimStr( A895DocDCan, 15, 4));
         A894DocDpre = 0;
         AssignAttri("", false, "A894DocDpre", StringUtil.LTrimStr( A894DocDpre, 15, 4));
         A896DocDDct = 0;
         AssignAttri("", false, "A896DocDDct", StringUtil.LTrimStr( A896DocDDct, 10, 2));
         A897DocDDct2 = 0;
         AssignAttri("", false, "A897DocDDct2", StringUtil.LTrimStr( A897DocDDct2, 10, 2));
         A1158LinStk = 0;
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         A910DocDObs = "";
         AssignAttri("", false, "A910DocDObs", A910DocDObs);
         A898DocDIna = 0;
         AssignAttri("", false, "A898DocDIna", StringUtil.Str( (decimal)(A898DocDIna), 1, 0));
         A912DocDPorSel = 0;
         AssignAttri("", false, "A912DocDPorSel", StringUtil.LTrimStr( A912DocDPorSel, 5, 2));
         A1703ProdPorSel = 0;
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
         A914DocDRef1 = "";
         AssignAttri("", false, "A914DocDRef1", A914DocDRef1);
         A915DocDRef2 = "";
         AssignAttri("", false, "A915DocDRef2", A915DocDRef2);
         A916DocDRef3 = "";
         AssignAttri("", false, "A916DocDRef3", A916DocDRef3);
         A917DocDRef4 = "";
         AssignAttri("", false, "A917DocDRef4", A917DocDRef4);
         A911DocDPed = "";
         AssignAttri("", false, "A911DocDPed", A911DocDPed);
         A913DocDPreInc = 0;
         AssignAttri("", false, "A913DocDPreInc", StringUtil.LTrimStr( A913DocDPreInc, 15, 4));
         A928DocDTotInc = 0;
         AssignAttri("", false, "A928DocDTotInc", StringUtil.LTrimStr( A928DocDTotInc, 15, 2));
         A926DocDValSel = 0;
         AssignAttri("", false, "A926DocDValSel", StringUtil.LTrimStr( A926DocDValSel, 15, 2));
         A908ProdValICBPERD = 0;
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
         A907ProdValICBPER = 0;
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
         A230DocMonCod = 0;
         AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
         A906ProdAfecICBPER = 0;
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
         Z892DocDTot = 0;
         Z905DocDICBPER = 0;
         Z895DocDCan = 0;
         Z894DocDpre = 0;
         Z896DocDDct = 0;
         Z897DocDDct2 = 0;
         Z898DocDIna = 0;
         Z912DocDPorSel = 0;
         Z914DocDRef1 = "";
         Z915DocDRef2 = "";
         Z916DocDRef3 = "";
         Z917DocDRef4 = "";
         Z911DocDPed = "";
         Z913DocDPreInc = 0;
         Z928DocDTotInc = 0;
         Z926DocDValSel = 0;
         Z28ProdCod = "";
         Z932DocICBPER = 0;
         Z230DocMonCod = 0;
      }

      protected void InitAll2Z102( )
      {
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A24DocNum = "";
         AssignAttri("", false, "A24DocNum", A24DocNum);
         A233DocItem = 0;
         AssignAttri("", false, "A233DocItem", StringUtil.LTrimStr( (decimal)(A233DocItem), 10, 0));
         InitializeNonKey2Z102( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245449", true, true);
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
         context.AddJavascriptSource("clventasdet.js", "?202281810245449", false, true);
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
         edtTipCod_Internalname = "TIPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtDocNum_Internalname = "DOCNUM";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtDocItem_Internalname = "DOCITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtDocDCan_Internalname = "DOCDCAN";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtDocDpre_Internalname = "DOCDPRE";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtDocDDct_Internalname = "DOCDDCT";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtDocDDct2_Internalname = "DOCDDCT2";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtDocDSub_Internalname = "DOCDSUB";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtDocDTot_Internalname = "DOCDTOT";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtDocDDcto_Internalname = "DOCDDCTO";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtLinStk_Internalname = "LINSTK";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtDocDObs_Internalname = "DOCDOBS";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtDocDIna_Internalname = "DOCDINA";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtDocDPorSel_Internalname = "DOCDPORSEL";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtDocDAfecto_Internalname = "DOCDAFECTO";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtDocDInafecto_Internalname = "DOCDINAFECTO";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtDocDSelectivo_Internalname = "DOCDSELECTIVO";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtProdPorSel_Internalname = "PRODPORSEL";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtDocDRef1_Internalname = "DOCDREF1";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtDocDRef2_Internalname = "DOCDREF2";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtDocDRef3_Internalname = "DOCDREF3";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtDocDRef4_Internalname = "DOCDREF4";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtDocDPed_Internalname = "DOCDPED";
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
         Form.Caption = "Ventas - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDocDPed_Jsonclick = "";
         edtDocDPed_Enabled = 1;
         edtDocDRef4_Jsonclick = "";
         edtDocDRef4_Enabled = 1;
         edtDocDRef3_Jsonclick = "";
         edtDocDRef3_Enabled = 1;
         edtDocDRef2_Jsonclick = "";
         edtDocDRef2_Enabled = 1;
         edtDocDRef1_Jsonclick = "";
         edtDocDRef1_Enabled = 1;
         edtProdPorSel_Jsonclick = "";
         edtProdPorSel_Enabled = 0;
         edtDocDSelectivo_Jsonclick = "";
         edtDocDSelectivo_Enabled = 0;
         edtDocDInafecto_Jsonclick = "";
         edtDocDInafecto_Enabled = 0;
         edtDocDAfecto_Jsonclick = "";
         edtDocDAfecto_Enabled = 0;
         edtDocDPorSel_Jsonclick = "";
         edtDocDPorSel_Enabled = 1;
         edtDocDIna_Jsonclick = "";
         edtDocDIna_Enabled = 1;
         edtDocDObs_Enabled = 1;
         edtLinStk_Jsonclick = "";
         edtLinStk_Enabled = 0;
         edtDocDDcto_Jsonclick = "";
         edtDocDDcto_Enabled = 0;
         edtDocDTot_Jsonclick = "";
         edtDocDTot_Enabled = 0;
         edtDocDSub_Jsonclick = "";
         edtDocDSub_Enabled = 0;
         edtDocDDct2_Jsonclick = "";
         edtDocDDct2_Enabled = 1;
         edtDocDDct_Jsonclick = "";
         edtDocDDct_Enabled = 1;
         edtDocDpre_Jsonclick = "";
         edtDocDpre_Enabled = 1;
         edtDocDCan_Jsonclick = "";
         edtDocDCan_Enabled = 1;
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 0;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtDocItem_Jsonclick = "";
         edtDocItem_Enabled = 1;
         edtDocNum_Jsonclick = "";
         edtDocNum_Enabled = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
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
         /* Using cursor T002Z26 */
         pr_default.execute(20, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A932DocICBPER = T002Z26_A932DocICBPER[0];
         n932DocICBPER = T002Z26_n932DocICBPER[0];
         A230DocMonCod = T002Z26_A230DocMonCod[0];
         pr_default.close(20);
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

      public void Valid_Docnum( )
      {
         n932DocICBPER = false;
         /* Using cursor T002Z26 */
         pr_default.execute(20, new Object[] {A149TipCod, A24DocNum});
         Z932DocICBPER = T002Z26_A932DocICBPER[0];
         Z230DocMonCod = T002Z26_A230DocMonCod[0];
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         A932DocICBPER = T002Z26_A932DocICBPER[0];
         n932DocICBPER = T002Z26_n932DocICBPER[0];
         A230DocMonCod = T002Z26_A230DocMonCod[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A932DocICBPER", StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230DocMonCod), 6, 0, ".", "")));
      }

      public void Valid_Docitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A895DocDCan", StringUtil.LTrim( StringUtil.NToC( A895DocDCan, 15, 4, ".", "")));
         AssignAttri("", false, "A894DocDpre", StringUtil.LTrim( StringUtil.NToC( A894DocDpre, 15, 4, ".", "")));
         AssignAttri("", false, "A896DocDDct", StringUtil.LTrim( StringUtil.NToC( A896DocDDct, 10, 2, ".", "")));
         AssignAttri("", false, "A897DocDDct2", StringUtil.LTrim( StringUtil.NToC( A897DocDDct2, 10, 2, ".", "")));
         AssignAttri("", false, "A910DocDObs", A910DocDObs);
         AssignAttri("", false, "A898DocDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(A898DocDIna), 1, 0, ".", "")));
         AssignAttri("", false, "A912DocDPorSel", StringUtil.LTrim( StringUtil.NToC( A912DocDPorSel, 5, 2, ".", "")));
         AssignAttri("", false, "A914DocDRef1", A914DocDRef1);
         AssignAttri("", false, "A915DocDRef2", A915DocDRef2);
         AssignAttri("", false, "A916DocDRef3", A916DocDRef3);
         AssignAttri("", false, "A917DocDRef4", A917DocDRef4);
         AssignAttri("", false, "A911DocDPed", A911DocDPed);
         AssignAttri("", false, "A913DocDPreInc", StringUtil.LTrim( StringUtil.NToC( A913DocDPreInc, 15, 4, ".", "")));
         AssignAttri("", false, "A928DocDTotInc", StringUtil.LTrim( StringUtil.NToC( A928DocDTotInc, 15, 2, ".", "")));
         AssignAttri("", false, "A926DocDValSel", StringUtil.LTrim( StringUtil.NToC( A926DocDValSel, 15, 2, ".", "")));
         AssignAttri("", false, "A932DocICBPER", StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230DocMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         AssignAttri("", false, "A1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")));
         AssignAttri("", false, "A905DocDICBPER", StringUtil.LTrim( StringUtil.NToC( A905DocDICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A925DocDSelectivoValor", StringUtil.LTrim( StringUtil.NToC( A925DocDSelectivoValor, 15, 2, ".", "")));
         AssignAttri("", false, "A893DocDSub", StringUtil.LTrim( StringUtil.NToC( A893DocDSub, 15, 4, ".", "")));
         AssignAttri("", false, "A892DocDTot", StringUtil.LTrim( StringUtil.NToC( A892DocDTot, 18, 8, ".", "")));
         AssignAttri("", false, "A900DocDDcto", StringUtil.LTrim( StringUtil.NToC( A900DocDDcto, 15, 2, ".", "")));
         AssignAttri("", false, "A909DocDInafecto", StringUtil.LTrim( StringUtil.NToC( A909DocDInafecto, 15, 4, ".", "")));
         AssignAttri("", false, "A903DocDGratuitoIna", StringUtil.LTrim( StringUtil.NToC( A903DocDGratuitoIna, 15, 4, ".", "")));
         AssignAttri("", false, "A902DocDGratuito", StringUtil.LTrim( StringUtil.NToC( A902DocDGratuito, 15, 4, ".", "")));
         AssignAttri("", false, "A901DocDExonerado", StringUtil.LTrim( StringUtil.NToC( A901DocDExonerado, 15, 4, ".", "")));
         AssignAttri("", false, "A891DocDAfecto", StringUtil.LTrim( StringUtil.NToC( A891DocDAfecto, 15, 4, ".", "")));
         AssignAttri("", false, "A924DocDSelectivoPor", StringUtil.LTrim( StringUtil.NToC( A924DocDSelectivoPor, 15, 2, ".", "")));
         AssignAttri("", false, "A923DocDSelectivo", StringUtil.LTrim( StringUtil.NToC( A923DocDSelectivo, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z233DocItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z233DocItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z895DocDCan", StringUtil.LTrim( StringUtil.NToC( Z895DocDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z894DocDpre", StringUtil.LTrim( StringUtil.NToC( Z894DocDpre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z896DocDDct", StringUtil.LTrim( StringUtil.NToC( Z896DocDDct, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z897DocDDct2", StringUtil.LTrim( StringUtil.NToC( Z897DocDDct2, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z910DocDObs", Z910DocDObs);
         GxWebStd.gx_hidden_field( context, "Z898DocDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z898DocDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z912DocDPorSel", StringUtil.LTrim( StringUtil.NToC( Z912DocDPorSel, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z914DocDRef1", Z914DocDRef1);
         GxWebStd.gx_hidden_field( context, "Z915DocDRef2", Z915DocDRef2);
         GxWebStd.gx_hidden_field( context, "Z916DocDRef3", Z916DocDRef3);
         GxWebStd.gx_hidden_field( context, "Z917DocDRef4", Z917DocDRef4);
         GxWebStd.gx_hidden_field( context, "Z911DocDPed", Z911DocDPed);
         GxWebStd.gx_hidden_field( context, "Z913DocDPreInc", StringUtil.LTrim( StringUtil.NToC( Z913DocDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z928DocDTotInc", StringUtil.LTrim( StringUtil.NToC( Z928DocDTotInc, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z926DocDValSel", StringUtil.LTrim( StringUtil.NToC( Z926DocDValSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z932DocICBPER", StringUtil.LTrim( StringUtil.NToC( Z932DocICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z230DocMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( Z1703ProdPorSel, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1158LinStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z905DocDICBPER", StringUtil.LTrim( StringUtil.NToC( Z905DocDICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z925DocDSelectivoValor", StringUtil.LTrim( StringUtil.NToC( Z925DocDSelectivoValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z893DocDSub", StringUtil.LTrim( StringUtil.NToC( Z893DocDSub, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z892DocDTot", StringUtil.LTrim( StringUtil.NToC( Z892DocDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z900DocDDcto", StringUtil.LTrim( StringUtil.NToC( Z900DocDDcto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z909DocDInafecto", StringUtil.LTrim( StringUtil.NToC( Z909DocDInafecto, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z903DocDGratuitoIna", StringUtil.LTrim( StringUtil.NToC( Z903DocDGratuitoIna, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z902DocDGratuito", StringUtil.LTrim( StringUtil.NToC( Z902DocDGratuito, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z901DocDExonerado", StringUtil.LTrim( StringUtil.NToC( Z901DocDExonerado, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z891DocDAfecto", StringUtil.LTrim( StringUtil.NToC( Z891DocDAfecto, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z924DocDSelectivoPor", StringUtil.LTrim( StringUtil.NToC( Z924DocDSelectivoPor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z923DocDSelectivo", StringUtil.LTrim( StringUtil.NToC( Z923DocDSelectivo, 15, 4, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T002Z27 */
         pr_default.execute(21, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         A52LinCod = T002Z27_A52LinCod[0];
         A55ProdDsc = T002Z27_A55ProdDsc[0];
         A1703ProdPorSel = T002Z27_A1703ProdPorSel[0];
         A908ProdValICBPERD = T002Z27_A908ProdValICBPERD[0];
         A907ProdValICBPER = T002Z27_A907ProdValICBPER[0];
         A906ProdAfecICBPER = T002Z27_A906ProdAfecICBPER[0];
         pr_default.close(21);
         /* Using cursor T002Z28 */
         pr_default.execute(22, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
         }
         A1158LinStk = T002Z28_A1158LinStk[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         AssignAttri("", false, "A1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A913DocDPreInc',fld:'DOCDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A928DocDTotInc',fld:'DOCDTOTINC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A926DocDValSel',fld:'DOCDVALSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_DOCNUM","{handler:'Valid_Docnum',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''},{av:'A932DocICBPER',fld:'DOCICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A230DocMonCod',fld:'DOCMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_DOCNUM",",oparms:[{av:'A932DocICBPER',fld:'DOCICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A230DocMonCod',fld:'DOCMONCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_DOCITEM","{handler:'Valid_Docitem',iparms:[{av:'A926DocDValSel',fld:'DOCDVALSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A928DocDTotInc',fld:'DOCDTOTINC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A913DocDPreInc',fld:'DOCDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''},{av:'A233DocItem',fld:'DOCITEM',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DOCITEM",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A895DocDCan',fld:'DOCDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A894DocDpre',fld:'DOCDPRE',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A896DocDDct',fld:'DOCDDCT',pic:'ZZZZZZ9.99'},{av:'A897DocDDct2',fld:'DOCDDCT2',pic:'ZZZZZZ9.99'},{av:'A910DocDObs',fld:'DOCDOBS',pic:''},{av:'A898DocDIna',fld:'DOCDINA',pic:'9'},{av:'A912DocDPorSel',fld:'DOCDPORSEL',pic:'Z9.99'},{av:'A914DocDRef1',fld:'DOCDREF1',pic:''},{av:'A915DocDRef2',fld:'DOCDREF2',pic:''},{av:'A916DocDRef3',fld:'DOCDREF3',pic:''},{av:'A917DocDRef4',fld:'DOCDREF4',pic:''},{av:'A911DocDPed',fld:'DOCDPED',pic:''},{av:'A913DocDPreInc',fld:'DOCDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A928DocDTotInc',fld:'DOCDTOTINC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A926DocDValSel',fld:'DOCDVALSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A932DocICBPER',fld:'DOCICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A230DocMonCod',fld:'DOCMONCOD',pic:'ZZZZZ9'},{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1703ProdPorSel',fld:'PRODPORSEL',pic:'ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A1158LinStk',fld:'LINSTK',pic:'9'},{av:'A905DocDICBPER',fld:'DOCDICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A925DocDSelectivoValor',fld:'DOCDSELECTIVOVALOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A893DocDSub',fld:'DOCDSUB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A892DocDTot',fld:'DOCDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A900DocDDcto',fld:'DOCDDCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A909DocDInafecto',fld:'DOCDINAFECTO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A903DocDGratuitoIna',fld:'DOCDGRATUITOINA',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A902DocDGratuito',fld:'DOCDGRATUITO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A901DocDExonerado',fld:'DOCDEXONERADO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A891DocDAfecto',fld:'DOCDAFECTO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A924DocDSelectivoPor',fld:'DOCDSELECTIVOPOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A923DocDSelectivo',fld:'DOCDSELECTIVO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z149TipCod'},{av:'Z24DocNum'},{av:'Z233DocItem'},{av:'Z28ProdCod'},{av:'Z895DocDCan'},{av:'Z894DocDpre'},{av:'Z896DocDDct'},{av:'Z897DocDDct2'},{av:'Z910DocDObs'},{av:'Z898DocDIna'},{av:'Z912DocDPorSel'},{av:'Z914DocDRef1'},{av:'Z915DocDRef2'},{av:'Z916DocDRef3'},{av:'Z917DocDRef4'},{av:'Z911DocDPed'},{av:'Z913DocDPreInc'},{av:'Z928DocDTotInc'},{av:'Z926DocDValSel'},{av:'Z932DocICBPER'},{av:'Z230DocMonCod'},{av:'Z52LinCod'},{av:'Z55ProdDsc'},{av:'Z1703ProdPorSel'},{av:'Z908ProdValICBPERD'},{av:'Z907ProdValICBPER'},{av:'Z906ProdAfecICBPER'},{av:'Z1158LinStk'},{av:'Z905DocDICBPER'},{av:'Z925DocDSelectivoValor'},{av:'Z893DocDSub'},{av:'Z892DocDTot'},{av:'Z900DocDDcto'},{av:'Z909DocDInafecto'},{av:'Z903DocDGratuitoIna'},{av:'Z902DocDGratuito'},{av:'Z901DocDExonerado'},{av:'Z891DocDAfecto'},{av:'Z924DocDSelectivoPor'},{av:'Z923DocDSelectivo'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1703ProdPorSel',fld:'PRODPORSEL',pic:'ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A1158LinStk',fld:'LINSTK',pic:'9'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1703ProdPorSel',fld:'PRODPORSEL',pic:'ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A1158LinStk',fld:'LINSTK',pic:'9'}]}");
         setEventMetadata("VALID_DOCDCAN","{handler:'Valid_Docdcan',iparms:[]");
         setEventMetadata("VALID_DOCDCAN",",oparms:[]}");
         setEventMetadata("VALID_DOCDPRE","{handler:'Valid_Docdpre',iparms:[]");
         setEventMetadata("VALID_DOCDPRE",",oparms:[]}");
         setEventMetadata("VALID_DOCDDCT","{handler:'Valid_Docddct',iparms:[]");
         setEventMetadata("VALID_DOCDDCT",",oparms:[]}");
         setEventMetadata("VALID_DOCDDCT2","{handler:'Valid_Docddct2',iparms:[]");
         setEventMetadata("VALID_DOCDDCT2",",oparms:[]}");
         setEventMetadata("VALID_DOCDSUB","{handler:'Valid_Docdsub',iparms:[]");
         setEventMetadata("VALID_DOCDSUB",",oparms:[]}");
         setEventMetadata("VALID_DOCDTOT","{handler:'Valid_Docdtot',iparms:[]");
         setEventMetadata("VALID_DOCDTOT",",oparms:[]}");
         setEventMetadata("VALID_DOCDINA","{handler:'Valid_Docdina',iparms:[]");
         setEventMetadata("VALID_DOCDINA",",oparms:[]}");
         setEventMetadata("VALID_DOCDPORSEL","{handler:'Valid_Docdporsel',iparms:[]");
         setEventMetadata("VALID_DOCDPORSEL",",oparms:[]}");
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z149TipCod = "";
         Z24DocNum = "";
         Z914DocDRef1 = "";
         Z915DocDRef2 = "";
         Z916DocDRef3 = "";
         Z917DocDRef4 = "";
         Z911DocDPed = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A149TipCod = "";
         A24DocNum = "";
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
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A55ProdDsc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A910DocDObs = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         A914DocDRef1 = "";
         lblTextblock22_Jsonclick = "";
         A915DocDRef2 = "";
         lblTextblock23_Jsonclick = "";
         A916DocDRef3 = "";
         lblTextblock24_Jsonclick = "";
         A917DocDRef4 = "";
         lblTextblock25_Jsonclick = "";
         A911DocDPed = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z910DocDObs = "";
         Z55ProdDsc = "";
         T002Z10_A52LinCod = new int[1] ;
         T002Z10_A932DocICBPER = new decimal[1] ;
         T002Z10_n932DocICBPER = new bool[] {false} ;
         T002Z10_A892DocDTot = new decimal[1] ;
         T002Z10_A905DocDICBPER = new decimal[1] ;
         T002Z10_A233DocItem = new long[1] ;
         T002Z10_A55ProdDsc = new string[] {""} ;
         T002Z10_A895DocDCan = new decimal[1] ;
         T002Z10_A894DocDpre = new decimal[1] ;
         T002Z10_A896DocDDct = new decimal[1] ;
         T002Z10_A897DocDDct2 = new decimal[1] ;
         T002Z10_A1158LinStk = new short[1] ;
         T002Z10_A910DocDObs = new string[] {""} ;
         T002Z10_A898DocDIna = new short[1] ;
         T002Z10_A912DocDPorSel = new decimal[1] ;
         T002Z10_A1703ProdPorSel = new decimal[1] ;
         T002Z10_A914DocDRef1 = new string[] {""} ;
         T002Z10_A915DocDRef2 = new string[] {""} ;
         T002Z10_A916DocDRef3 = new string[] {""} ;
         T002Z10_A917DocDRef4 = new string[] {""} ;
         T002Z10_A911DocDPed = new string[] {""} ;
         T002Z10_A913DocDPreInc = new decimal[1] ;
         T002Z10_A928DocDTotInc = new decimal[1] ;
         T002Z10_A926DocDValSel = new decimal[1] ;
         T002Z10_A908ProdValICBPERD = new decimal[1] ;
         T002Z10_A907ProdValICBPER = new decimal[1] ;
         T002Z10_A906ProdAfecICBPER = new short[1] ;
         T002Z10_A149TipCod = new string[] {""} ;
         T002Z10_A24DocNum = new string[] {""} ;
         T002Z10_A28ProdCod = new string[] {""} ;
         T002Z10_A230DocMonCod = new int[1] ;
         T002Z7_A932DocICBPER = new decimal[1] ;
         T002Z7_n932DocICBPER = new bool[] {false} ;
         T002Z7_A230DocMonCod = new int[1] ;
         T002Z8_A52LinCod = new int[1] ;
         T002Z8_A55ProdDsc = new string[] {""} ;
         T002Z8_A1703ProdPorSel = new decimal[1] ;
         T002Z8_A908ProdValICBPERD = new decimal[1] ;
         T002Z8_A907ProdValICBPER = new decimal[1] ;
         T002Z8_A906ProdAfecICBPER = new short[1] ;
         T002Z9_A1158LinStk = new short[1] ;
         T002Z11_A52LinCod = new int[1] ;
         T002Z11_A55ProdDsc = new string[] {""} ;
         T002Z11_A1703ProdPorSel = new decimal[1] ;
         T002Z11_A908ProdValICBPERD = new decimal[1] ;
         T002Z11_A907ProdValICBPER = new decimal[1] ;
         T002Z11_A906ProdAfecICBPER = new short[1] ;
         T002Z12_A1158LinStk = new short[1] ;
         T002Z13_A149TipCod = new string[] {""} ;
         T002Z13_A24DocNum = new string[] {""} ;
         T002Z13_A233DocItem = new long[1] ;
         T002Z3_A892DocDTot = new decimal[1] ;
         T002Z3_A905DocDICBPER = new decimal[1] ;
         T002Z3_A233DocItem = new long[1] ;
         T002Z3_A895DocDCan = new decimal[1] ;
         T002Z3_A894DocDpre = new decimal[1] ;
         T002Z3_A896DocDDct = new decimal[1] ;
         T002Z3_A897DocDDct2 = new decimal[1] ;
         T002Z3_A910DocDObs = new string[] {""} ;
         T002Z3_A898DocDIna = new short[1] ;
         T002Z3_A912DocDPorSel = new decimal[1] ;
         T002Z3_A914DocDRef1 = new string[] {""} ;
         T002Z3_A915DocDRef2 = new string[] {""} ;
         T002Z3_A916DocDRef3 = new string[] {""} ;
         T002Z3_A917DocDRef4 = new string[] {""} ;
         T002Z3_A911DocDPed = new string[] {""} ;
         T002Z3_A913DocDPreInc = new decimal[1] ;
         T002Z3_A928DocDTotInc = new decimal[1] ;
         T002Z3_A926DocDValSel = new decimal[1] ;
         T002Z3_A149TipCod = new string[] {""} ;
         T002Z3_A24DocNum = new string[] {""} ;
         T002Z3_A28ProdCod = new string[] {""} ;
         sMode102 = "";
         T002Z14_A233DocItem = new long[1] ;
         T002Z14_A149TipCod = new string[] {""} ;
         T002Z14_A24DocNum = new string[] {""} ;
         T002Z15_A233DocItem = new long[1] ;
         T002Z15_A149TipCod = new string[] {""} ;
         T002Z15_A24DocNum = new string[] {""} ;
         T002Z2_A892DocDTot = new decimal[1] ;
         T002Z2_A905DocDICBPER = new decimal[1] ;
         T002Z2_A233DocItem = new long[1] ;
         T002Z2_A895DocDCan = new decimal[1] ;
         T002Z2_A894DocDpre = new decimal[1] ;
         T002Z2_A896DocDDct = new decimal[1] ;
         T002Z2_A897DocDDct2 = new decimal[1] ;
         T002Z2_A910DocDObs = new string[] {""} ;
         T002Z2_A898DocDIna = new short[1] ;
         T002Z2_A912DocDPorSel = new decimal[1] ;
         T002Z2_A914DocDRef1 = new string[] {""} ;
         T002Z2_A915DocDRef2 = new string[] {""} ;
         T002Z2_A916DocDRef3 = new string[] {""} ;
         T002Z2_A917DocDRef4 = new string[] {""} ;
         T002Z2_A911DocDPed = new string[] {""} ;
         T002Z2_A913DocDPreInc = new decimal[1] ;
         T002Z2_A928DocDTotInc = new decimal[1] ;
         T002Z2_A926DocDValSel = new decimal[1] ;
         T002Z2_A149TipCod = new string[] {""} ;
         T002Z2_A24DocNum = new string[] {""} ;
         T002Z2_A28ProdCod = new string[] {""} ;
         T002Z16_A932DocICBPER = new decimal[1] ;
         T002Z16_n932DocICBPER = new bool[] {false} ;
         T002Z16_A230DocMonCod = new int[1] ;
         T002Z19_A932DocICBPER = new decimal[1] ;
         T002Z19_n932DocICBPER = new bool[] {false} ;
         T002Z22_A932DocICBPER = new decimal[1] ;
         T002Z22_n932DocICBPER = new bool[] {false} ;
         T002Z25_A932DocICBPER = new decimal[1] ;
         T002Z25_n932DocICBPER = new bool[] {false} ;
         T002Z26_A932DocICBPER = new decimal[1] ;
         T002Z26_n932DocICBPER = new bool[] {false} ;
         T002Z26_A230DocMonCod = new int[1] ;
         T002Z27_A52LinCod = new int[1] ;
         T002Z27_A55ProdDsc = new string[] {""} ;
         T002Z27_A1703ProdPorSel = new decimal[1] ;
         T002Z27_A908ProdValICBPERD = new decimal[1] ;
         T002Z27_A907ProdValICBPER = new decimal[1] ;
         T002Z27_A906ProdAfecICBPER = new short[1] ;
         T002Z28_A1158LinStk = new short[1] ;
         T002Z30_A149TipCod = new string[] {""} ;
         T002Z30_A24DocNum = new string[] {""} ;
         T002Z30_A233DocItem = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ149TipCod = "";
         ZZ24DocNum = "";
         ZZ28ProdCod = "";
         ZZ910DocDObs = "";
         ZZ914DocDRef1 = "";
         ZZ915DocDRef2 = "";
         ZZ916DocDRef3 = "";
         ZZ917DocDRef4 = "";
         ZZ911DocDPed = "";
         ZZ55ProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clventasdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clventasdet__default(),
            new Object[][] {
                new Object[] {
               T002Z2_A892DocDTot, T002Z2_A905DocDICBPER, T002Z2_A233DocItem, T002Z2_A895DocDCan, T002Z2_A894DocDpre, T002Z2_A896DocDDct, T002Z2_A897DocDDct2, T002Z2_A910DocDObs, T002Z2_A898DocDIna, T002Z2_A912DocDPorSel,
               T002Z2_A914DocDRef1, T002Z2_A915DocDRef2, T002Z2_A916DocDRef3, T002Z2_A917DocDRef4, T002Z2_A911DocDPed, T002Z2_A913DocDPreInc, T002Z2_A928DocDTotInc, T002Z2_A926DocDValSel, T002Z2_A149TipCod, T002Z2_A24DocNum,
               T002Z2_A28ProdCod
               }
               , new Object[] {
               T002Z3_A892DocDTot, T002Z3_A905DocDICBPER, T002Z3_A233DocItem, T002Z3_A895DocDCan, T002Z3_A894DocDpre, T002Z3_A896DocDDct, T002Z3_A897DocDDct2, T002Z3_A910DocDObs, T002Z3_A898DocDIna, T002Z3_A912DocDPorSel,
               T002Z3_A914DocDRef1, T002Z3_A915DocDRef2, T002Z3_A916DocDRef3, T002Z3_A917DocDRef4, T002Z3_A911DocDPed, T002Z3_A913DocDPreInc, T002Z3_A928DocDTotInc, T002Z3_A926DocDValSel, T002Z3_A149TipCod, T002Z3_A24DocNum,
               T002Z3_A28ProdCod
               }
               , new Object[] {
               T002Z5_A932DocICBPER, T002Z5_n932DocICBPER
               }
               , new Object[] {
               T002Z6_A932DocICBPER, T002Z6_A230DocMonCod
               }
               , new Object[] {
               T002Z7_A932DocICBPER, T002Z7_A230DocMonCod
               }
               , new Object[] {
               T002Z8_A52LinCod, T002Z8_A55ProdDsc, T002Z8_A1703ProdPorSel, T002Z8_A908ProdValICBPERD, T002Z8_A907ProdValICBPER, T002Z8_A906ProdAfecICBPER
               }
               , new Object[] {
               T002Z9_A1158LinStk
               }
               , new Object[] {
               T002Z10_A52LinCod, T002Z10_A932DocICBPER, T002Z10_A892DocDTot, T002Z10_A905DocDICBPER, T002Z10_A233DocItem, T002Z10_A55ProdDsc, T002Z10_A895DocDCan, T002Z10_A894DocDpre, T002Z10_A896DocDDct, T002Z10_A897DocDDct2,
               T002Z10_A1158LinStk, T002Z10_A910DocDObs, T002Z10_A898DocDIna, T002Z10_A912DocDPorSel, T002Z10_A1703ProdPorSel, T002Z10_A914DocDRef1, T002Z10_A915DocDRef2, T002Z10_A916DocDRef3, T002Z10_A917DocDRef4, T002Z10_A911DocDPed,
               T002Z10_A913DocDPreInc, T002Z10_A928DocDTotInc, T002Z10_A926DocDValSel, T002Z10_A908ProdValICBPERD, T002Z10_A907ProdValICBPER, T002Z10_A906ProdAfecICBPER, T002Z10_A149TipCod, T002Z10_A24DocNum, T002Z10_A28ProdCod, T002Z10_A230DocMonCod
               }
               , new Object[] {
               T002Z11_A52LinCod, T002Z11_A55ProdDsc, T002Z11_A1703ProdPorSel, T002Z11_A908ProdValICBPERD, T002Z11_A907ProdValICBPER, T002Z11_A906ProdAfecICBPER
               }
               , new Object[] {
               T002Z12_A1158LinStk
               }
               , new Object[] {
               T002Z13_A149TipCod, T002Z13_A24DocNum, T002Z13_A233DocItem
               }
               , new Object[] {
               T002Z14_A233DocItem, T002Z14_A149TipCod, T002Z14_A24DocNum
               }
               , new Object[] {
               T002Z15_A233DocItem, T002Z15_A149TipCod, T002Z15_A24DocNum
               }
               , new Object[] {
               T002Z16_A932DocICBPER, T002Z16_A230DocMonCod
               }
               , new Object[] {
               }
               , new Object[] {
               T002Z19_A932DocICBPER, T002Z19_n932DocICBPER
               }
               , new Object[] {
               }
               , new Object[] {
               T002Z22_A932DocICBPER, T002Z22_n932DocICBPER
               }
               , new Object[] {
               }
               , new Object[] {
               T002Z25_A932DocICBPER, T002Z25_n932DocICBPER
               }
               , new Object[] {
               T002Z26_A932DocICBPER, T002Z26_A230DocMonCod
               }
               , new Object[] {
               T002Z27_A52LinCod, T002Z27_A55ProdDsc, T002Z27_A1703ProdPorSel, T002Z27_A908ProdValICBPERD, T002Z27_A907ProdValICBPER, T002Z27_A906ProdAfecICBPER
               }
               , new Object[] {
               T002Z28_A1158LinStk
               }
               , new Object[] {
               }
               , new Object[] {
               T002Z30_A149TipCod, T002Z30_A24DocNum, T002Z30_A233DocItem
               }
            }
         );
      }

      private short Z898DocDIna ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1158LinStk ;
      private short A898DocDIna ;
      private short A906ProdAfecICBPER ;
      private short GX_JID ;
      private short Z906ProdAfecICBPER ;
      private short Z1158LinStk ;
      private short RcdFound102 ;
      private short nIsDirty_102 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ898DocDIna ;
      private short ZZ906ProdAfecICBPER ;
      private short ZZ1158LinStk ;
      private int Z230DocMonCod ;
      private int A52LinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipCod_Enabled ;
      private int edtDocNum_Enabled ;
      private int edtDocItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtProdDsc_Enabled ;
      private int edtDocDCan_Enabled ;
      private int edtDocDpre_Enabled ;
      private int edtDocDDct_Enabled ;
      private int edtDocDDct2_Enabled ;
      private int edtDocDSub_Enabled ;
      private int edtDocDTot_Enabled ;
      private int edtDocDDcto_Enabled ;
      private int edtLinStk_Enabled ;
      private int edtDocDObs_Enabled ;
      private int edtDocDIna_Enabled ;
      private int edtDocDPorSel_Enabled ;
      private int edtDocDAfecto_Enabled ;
      private int edtDocDInafecto_Enabled ;
      private int edtDocDSelectivo_Enabled ;
      private int edtProdPorSel_Enabled ;
      private int edtDocDRef1_Enabled ;
      private int edtDocDRef2_Enabled ;
      private int edtDocDRef3_Enabled ;
      private int edtDocDRef4_Enabled ;
      private int edtDocDPed_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A230DocMonCod ;
      private int Z52LinCod ;
      private int idxLst ;
      private int ZZ230DocMonCod ;
      private int ZZ52LinCod ;
      private long Z233DocItem ;
      private long A233DocItem ;
      private long ZZ233DocItem ;
      private decimal Z892DocDTot ;
      private decimal Z905DocDICBPER ;
      private decimal Z895DocDCan ;
      private decimal Z894DocDpre ;
      private decimal Z896DocDDct ;
      private decimal Z897DocDDct2 ;
      private decimal Z912DocDPorSel ;
      private decimal Z913DocDPreInc ;
      private decimal Z928DocDTotInc ;
      private decimal Z926DocDValSel ;
      private decimal Z932DocICBPER ;
      private decimal A895DocDCan ;
      private decimal A894DocDpre ;
      private decimal A896DocDDct ;
      private decimal A897DocDDct2 ;
      private decimal A893DocDSub ;
      private decimal A892DocDTot ;
      private decimal A900DocDDcto ;
      private decimal A912DocDPorSel ;
      private decimal A891DocDAfecto ;
      private decimal A909DocDInafecto ;
      private decimal A923DocDSelectivo ;
      private decimal A1703ProdPorSel ;
      private decimal A905DocDICBPER ;
      private decimal A913DocDPreInc ;
      private decimal A928DocDTotInc ;
      private decimal A926DocDValSel ;
      private decimal A932DocICBPER ;
      private decimal A925DocDSelectivoValor ;
      private decimal A907ProdValICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal A924DocDSelectivoPor ;
      private decimal A903DocDGratuitoIna ;
      private decimal A902DocDGratuito ;
      private decimal A901DocDExonerado ;
      private decimal Z1703ProdPorSel ;
      private decimal Z908ProdValICBPERD ;
      private decimal Z907ProdValICBPER ;
      private decimal Z925DocDSelectivoValor ;
      private decimal Z893DocDSub ;
      private decimal Z900DocDDcto ;
      private decimal Z909DocDInafecto ;
      private decimal Z903DocDGratuitoIna ;
      private decimal Z902DocDGratuito ;
      private decimal Z901DocDExonerado ;
      private decimal Z891DocDAfecto ;
      private decimal Z924DocDSelectivoPor ;
      private decimal Z923DocDSelectivo ;
      private decimal ZZ895DocDCan ;
      private decimal ZZ894DocDpre ;
      private decimal ZZ896DocDDct ;
      private decimal ZZ897DocDDct2 ;
      private decimal ZZ912DocDPorSel ;
      private decimal ZZ913DocDPreInc ;
      private decimal ZZ928DocDTotInc ;
      private decimal ZZ926DocDValSel ;
      private decimal ZZ932DocICBPER ;
      private decimal ZZ1703ProdPorSel ;
      private decimal ZZ908ProdValICBPERD ;
      private decimal ZZ907ProdValICBPER ;
      private decimal ZZ905DocDICBPER ;
      private decimal ZZ925DocDSelectivoValor ;
      private decimal ZZ893DocDSub ;
      private decimal ZZ892DocDTot ;
      private decimal ZZ900DocDDcto ;
      private decimal ZZ909DocDInafecto ;
      private decimal ZZ903DocDGratuitoIna ;
      private decimal ZZ902DocDGratuito ;
      private decimal ZZ901DocDExonerado ;
      private decimal ZZ891DocDAfecto ;
      private decimal ZZ924DocDSelectivoPor ;
      private decimal ZZ923DocDSelectivo ;
      private string sPrefix ;
      private string Z149TipCod ;
      private string Z24DocNum ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipCod_Internalname ;
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
      private string edtTipCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtDocNum_Internalname ;
      private string edtDocNum_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtDocItem_Internalname ;
      private string edtDocItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtDocDCan_Internalname ;
      private string edtDocDCan_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtDocDpre_Internalname ;
      private string edtDocDpre_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtDocDDct_Internalname ;
      private string edtDocDDct_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtDocDDct2_Internalname ;
      private string edtDocDDct2_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtDocDSub_Internalname ;
      private string edtDocDSub_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtDocDTot_Internalname ;
      private string edtDocDTot_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtDocDDcto_Internalname ;
      private string edtDocDDcto_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtLinStk_Internalname ;
      private string edtLinStk_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtDocDObs_Internalname ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtDocDIna_Internalname ;
      private string edtDocDIna_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtDocDPorSel_Internalname ;
      private string edtDocDPorSel_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtDocDAfecto_Internalname ;
      private string edtDocDAfecto_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtDocDInafecto_Internalname ;
      private string edtDocDInafecto_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtDocDSelectivo_Internalname ;
      private string edtDocDSelectivo_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtProdPorSel_Internalname ;
      private string edtProdPorSel_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtDocDRef1_Internalname ;
      private string edtDocDRef1_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtDocDRef2_Internalname ;
      private string edtDocDRef2_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtDocDRef3_Internalname ;
      private string edtDocDRef3_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtDocDRef4_Internalname ;
      private string edtDocDRef4_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtDocDPed_Internalname ;
      private string edtDocDPed_Jsonclick ;
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
      private string Z55ProdDsc ;
      private string sMode102 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ149TipCod ;
      private string ZZ24DocNum ;
      private string ZZ28ProdCod ;
      private string ZZ55ProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n932DocICBPER ;
      private bool Gx_longc ;
      private string A910DocDObs ;
      private string Z910DocDObs ;
      private string ZZ910DocDObs ;
      private string Z914DocDRef1 ;
      private string Z915DocDRef2 ;
      private string Z916DocDRef3 ;
      private string Z917DocDRef4 ;
      private string Z911DocDPed ;
      private string A914DocDRef1 ;
      private string A915DocDRef2 ;
      private string A916DocDRef3 ;
      private string A917DocDRef4 ;
      private string A911DocDPed ;
      private string ZZ914DocDRef1 ;
      private string ZZ915DocDRef2 ;
      private string ZZ916DocDRef3 ;
      private string ZZ917DocDRef4 ;
      private string ZZ911DocDPed ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002Z10_A52LinCod ;
      private decimal[] T002Z10_A932DocICBPER ;
      private bool[] T002Z10_n932DocICBPER ;
      private decimal[] T002Z10_A892DocDTot ;
      private decimal[] T002Z10_A905DocDICBPER ;
      private long[] T002Z10_A233DocItem ;
      private string[] T002Z10_A55ProdDsc ;
      private decimal[] T002Z10_A895DocDCan ;
      private decimal[] T002Z10_A894DocDpre ;
      private decimal[] T002Z10_A896DocDDct ;
      private decimal[] T002Z10_A897DocDDct2 ;
      private short[] T002Z10_A1158LinStk ;
      private string[] T002Z10_A910DocDObs ;
      private short[] T002Z10_A898DocDIna ;
      private decimal[] T002Z10_A912DocDPorSel ;
      private decimal[] T002Z10_A1703ProdPorSel ;
      private string[] T002Z10_A914DocDRef1 ;
      private string[] T002Z10_A915DocDRef2 ;
      private string[] T002Z10_A916DocDRef3 ;
      private string[] T002Z10_A917DocDRef4 ;
      private string[] T002Z10_A911DocDPed ;
      private decimal[] T002Z10_A913DocDPreInc ;
      private decimal[] T002Z10_A928DocDTotInc ;
      private decimal[] T002Z10_A926DocDValSel ;
      private decimal[] T002Z10_A908ProdValICBPERD ;
      private decimal[] T002Z10_A907ProdValICBPER ;
      private short[] T002Z10_A906ProdAfecICBPER ;
      private string[] T002Z10_A149TipCod ;
      private string[] T002Z10_A24DocNum ;
      private string[] T002Z10_A28ProdCod ;
      private int[] T002Z10_A230DocMonCod ;
      private decimal[] T002Z7_A932DocICBPER ;
      private bool[] T002Z7_n932DocICBPER ;
      private int[] T002Z7_A230DocMonCod ;
      private int[] T002Z8_A52LinCod ;
      private string[] T002Z8_A55ProdDsc ;
      private decimal[] T002Z8_A1703ProdPorSel ;
      private decimal[] T002Z8_A908ProdValICBPERD ;
      private decimal[] T002Z8_A907ProdValICBPER ;
      private short[] T002Z8_A906ProdAfecICBPER ;
      private short[] T002Z9_A1158LinStk ;
      private int[] T002Z11_A52LinCod ;
      private string[] T002Z11_A55ProdDsc ;
      private decimal[] T002Z11_A1703ProdPorSel ;
      private decimal[] T002Z11_A908ProdValICBPERD ;
      private decimal[] T002Z11_A907ProdValICBPER ;
      private short[] T002Z11_A906ProdAfecICBPER ;
      private short[] T002Z12_A1158LinStk ;
      private string[] T002Z13_A149TipCod ;
      private string[] T002Z13_A24DocNum ;
      private long[] T002Z13_A233DocItem ;
      private decimal[] T002Z3_A892DocDTot ;
      private decimal[] T002Z3_A905DocDICBPER ;
      private long[] T002Z3_A233DocItem ;
      private decimal[] T002Z3_A895DocDCan ;
      private decimal[] T002Z3_A894DocDpre ;
      private decimal[] T002Z3_A896DocDDct ;
      private decimal[] T002Z3_A897DocDDct2 ;
      private string[] T002Z3_A910DocDObs ;
      private short[] T002Z3_A898DocDIna ;
      private decimal[] T002Z3_A912DocDPorSel ;
      private string[] T002Z3_A914DocDRef1 ;
      private string[] T002Z3_A915DocDRef2 ;
      private string[] T002Z3_A916DocDRef3 ;
      private string[] T002Z3_A917DocDRef4 ;
      private string[] T002Z3_A911DocDPed ;
      private decimal[] T002Z3_A913DocDPreInc ;
      private decimal[] T002Z3_A928DocDTotInc ;
      private decimal[] T002Z3_A926DocDValSel ;
      private string[] T002Z3_A149TipCod ;
      private string[] T002Z3_A24DocNum ;
      private string[] T002Z3_A28ProdCod ;
      private long[] T002Z14_A233DocItem ;
      private string[] T002Z14_A149TipCod ;
      private string[] T002Z14_A24DocNum ;
      private long[] T002Z15_A233DocItem ;
      private string[] T002Z15_A149TipCod ;
      private string[] T002Z15_A24DocNum ;
      private decimal[] T002Z2_A892DocDTot ;
      private decimal[] T002Z2_A905DocDICBPER ;
      private long[] T002Z2_A233DocItem ;
      private decimal[] T002Z2_A895DocDCan ;
      private decimal[] T002Z2_A894DocDpre ;
      private decimal[] T002Z2_A896DocDDct ;
      private decimal[] T002Z2_A897DocDDct2 ;
      private string[] T002Z2_A910DocDObs ;
      private short[] T002Z2_A898DocDIna ;
      private decimal[] T002Z2_A912DocDPorSel ;
      private string[] T002Z2_A914DocDRef1 ;
      private string[] T002Z2_A915DocDRef2 ;
      private string[] T002Z2_A916DocDRef3 ;
      private string[] T002Z2_A917DocDRef4 ;
      private string[] T002Z2_A911DocDPed ;
      private decimal[] T002Z2_A913DocDPreInc ;
      private decimal[] T002Z2_A928DocDTotInc ;
      private decimal[] T002Z2_A926DocDValSel ;
      private string[] T002Z2_A149TipCod ;
      private string[] T002Z2_A24DocNum ;
      private string[] T002Z2_A28ProdCod ;
      private decimal[] T002Z16_A932DocICBPER ;
      private bool[] T002Z16_n932DocICBPER ;
      private int[] T002Z16_A230DocMonCod ;
      private decimal[] T002Z19_A932DocICBPER ;
      private bool[] T002Z19_n932DocICBPER ;
      private decimal[] T002Z22_A932DocICBPER ;
      private bool[] T002Z22_n932DocICBPER ;
      private decimal[] T002Z25_A932DocICBPER ;
      private bool[] T002Z25_n932DocICBPER ;
      private decimal[] T002Z26_A932DocICBPER ;
      private bool[] T002Z26_n932DocICBPER ;
      private int[] T002Z26_A230DocMonCod ;
      private int[] T002Z27_A52LinCod ;
      private string[] T002Z27_A55ProdDsc ;
      private decimal[] T002Z27_A1703ProdPorSel ;
      private decimal[] T002Z27_A908ProdValICBPERD ;
      private decimal[] T002Z27_A907ProdValICBPER ;
      private short[] T002Z27_A906ProdAfecICBPER ;
      private short[] T002Z28_A1158LinStk ;
      private string[] T002Z30_A149TipCod ;
      private string[] T002Z30_A24DocNum ;
      private long[] T002Z30_A233DocItem ;
      private IDataStoreProvider pr_datastore2 ;
      private decimal[] T002Z5_A932DocICBPER ;
      private decimal[] T002Z6_A932DocICBPER ;
      private int[] T002Z6_A230DocMonCod ;
      private bool[] T002Z5_n932DocICBPER ;
      private GXWebForm Form ;
   }

   public class clventasdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clventasdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002Z5;
        prmT002Z5 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z6;
        prmT002Z6 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z10;
        prmT002Z10 = new Object[] {
        new ParDef("@DocItem",GXType.Decimal,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z8;
        prmT002Z8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002Z9;
        prmT002Z9 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002Z7;
        prmT002Z7 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z11;
        prmT002Z11 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002Z12;
        prmT002Z12 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002Z13;
        prmT002Z13 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0) ,
        new ParDef("@DocItem",GXType.Decimal,10,0)
        };
        Object[] prmT002Z3;
        prmT002Z3 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0) ,
        new ParDef("@DocItem",GXType.Decimal,10,0)
        };
        Object[] prmT002Z14;
        prmT002Z14 = new Object[] {
        new ParDef("@DocItem",GXType.Decimal,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z15;
        prmT002Z15 = new Object[] {
        new ParDef("@DocItem",GXType.Decimal,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z2;
        prmT002Z2 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0) ,
        new ParDef("@DocItem",GXType.Decimal,10,0)
        };
        Object[] prmT002Z16;
        prmT002Z16 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z17;
        prmT002Z17 = new Object[] {
        new ParDef("@DocDTot",GXType.Decimal,18,8) ,
        new ParDef("@DocDICBPER",GXType.Decimal,15,2) ,
        new ParDef("@DocItem",GXType.Decimal,10,0) ,
        new ParDef("@DocDCan",GXType.Decimal,15,4) ,
        new ParDef("@DocDpre",GXType.Decimal,15,4) ,
        new ParDef("@DocDDct",GXType.Decimal,10,2) ,
        new ParDef("@DocDDct2",GXType.Decimal,10,2) ,
        new ParDef("@DocDObs",GXType.NVarChar,500,0) ,
        new ParDef("@DocDIna",GXType.Int16,1,0) ,
        new ParDef("@DocDPorSel",GXType.Decimal,5,2) ,
        new ParDef("@DocDRef1",GXType.NVarChar,20,0) ,
        new ParDef("@DocDRef2",GXType.NVarChar,20,0) ,
        new ParDef("@DocDRef3",GXType.NVarChar,20,0) ,
        new ParDef("@DocDRef4",GXType.NVarChar,20,0) ,
        new ParDef("@DocDPed",GXType.NVarChar,10,0) ,
        new ParDef("@DocDPreInc",GXType.Decimal,15,4) ,
        new ParDef("@DocDTotInc",GXType.Decimal,15,2) ,
        new ParDef("@DocDValSel",GXType.Decimal,15,2) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002Z19;
        prmT002Z19 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z20;
        prmT002Z20 = new Object[] {
        new ParDef("@DocDTot",GXType.Decimal,18,8) ,
        new ParDef("@DocDICBPER",GXType.Decimal,15,2) ,
        new ParDef("@DocDCan",GXType.Decimal,15,4) ,
        new ParDef("@DocDpre",GXType.Decimal,15,4) ,
        new ParDef("@DocDDct",GXType.Decimal,10,2) ,
        new ParDef("@DocDDct2",GXType.Decimal,10,2) ,
        new ParDef("@DocDObs",GXType.NVarChar,500,0) ,
        new ParDef("@DocDIna",GXType.Int16,1,0) ,
        new ParDef("@DocDPorSel",GXType.Decimal,5,2) ,
        new ParDef("@DocDRef1",GXType.NVarChar,20,0) ,
        new ParDef("@DocDRef2",GXType.NVarChar,20,0) ,
        new ParDef("@DocDRef3",GXType.NVarChar,20,0) ,
        new ParDef("@DocDRef4",GXType.NVarChar,20,0) ,
        new ParDef("@DocDPed",GXType.NVarChar,10,0) ,
        new ParDef("@DocDPreInc",GXType.Decimal,15,4) ,
        new ParDef("@DocDTotInc",GXType.Decimal,15,2) ,
        new ParDef("@DocDValSel",GXType.Decimal,15,2) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0) ,
        new ParDef("@DocItem",GXType.Decimal,10,0)
        };
        Object[] prmT002Z22;
        prmT002Z22 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z23;
        prmT002Z23 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0) ,
        new ParDef("@DocItem",GXType.Decimal,10,0)
        };
        Object[] prmT002Z25;
        prmT002Z25 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z29;
        prmT002Z29 = new Object[] {
        new ParDef("@DocICBPER",GXType.Decimal,15,2){Nullable=true} ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z30;
        prmT002Z30 = new Object[] {
        };
        Object[] prmT002Z26;
        prmT002Z26 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002Z27;
        prmT002Z27 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002Z28;
        prmT002Z28 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002Z2", "SELECT [DocDTot], [DocDICBPER], [DocItem], [DocDCan], [DocDpre], [DocDDct], [DocDDct2], [DocDObs], [DocDIna], [DocDPorSel], [DocDRef1], [DocDRef2], [DocDRef3], [DocDRef4], [DocDPed], [DocDPreInc], [DocDTotInc], [DocDValSel], [TipCod], [DocNum], [ProdCod] FROM [CLVENTASDET] WITH (UPDLOCK) WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z3", "SELECT [DocDTot], [DocDICBPER], [DocItem], [DocDCan], [DocDpre], [DocDDct], [DocDDct2], [DocDObs], [DocDIna], [DocDPorSel], [DocDRef1], [DocDRef2], [DocDRef3], [DocDRef4], [DocDPed], [DocDPreInc], [DocDTotInc], [DocDValSel], [TipCod], [DocNum], [ProdCod] FROM [CLVENTASDET] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z5", "SELECT T1.[DocICBPER] FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum] FROM [CLVENTASDET] WITH (UPDLOCK) GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z6", "SELECT [DocICBPER], [DocMonCod] FROM [CLVENTAS] WITH (UPDLOCK) WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z7", "SELECT [DocICBPER], [DocMonCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z8", "SELECT [LinCod], [ProdDsc], [ProdPorSel], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z9", "SELECT [LinStk] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z10", "SELECT T3.[LinCod], T2.[DocICBPER], TM1.[DocDTot], TM1.[DocDICBPER], TM1.[DocItem], T3.[ProdDsc], TM1.[DocDCan], TM1.[DocDpre], TM1.[DocDDct], TM1.[DocDDct2], T4.[LinStk], TM1.[DocDObs], TM1.[DocDIna], TM1.[DocDPorSel], T3.[ProdPorSel], TM1.[DocDRef1], TM1.[DocDRef2], TM1.[DocDRef3], TM1.[DocDRef4], TM1.[DocDPed], TM1.[DocDPreInc], TM1.[DocDTotInc], TM1.[DocDValSel], T3.[ProdValICBPERD], T3.[ProdValICBPER], T3.[ProdAfecICBPER], TM1.[TipCod], TM1.[DocNum], TM1.[ProdCod], T2.[DocMonCod] FROM ((([CLVENTASDET] TM1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = TM1.[TipCod] AND T2.[DocNum] = TM1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = TM1.[ProdCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod]) WHERE TM1.[DocItem] = @DocItem and TM1.[TipCod] = @TipCod and TM1.[DocNum] = @DocNum ORDER BY TM1.[TipCod], TM1.[DocNum], TM1.[DocItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z11", "SELECT [LinCod], [ProdDsc], [ProdPorSel], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z12", "SELECT [LinStk] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z13", "SELECT [TipCod], [DocNum], [DocItem] FROM [CLVENTASDET] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z14", "SELECT TOP 1 [DocItem], [TipCod], [DocNum] FROM [CLVENTASDET] WHERE ( [DocItem] > @DocItem or [DocItem] = @DocItem and [TipCod] > @TipCod or [TipCod] = @TipCod and [DocItem] = @DocItem and [DocNum] > @DocNum) ORDER BY [TipCod], [DocNum], [DocItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Z15", "SELECT TOP 1 [DocItem], [TipCod], [DocNum] FROM [CLVENTASDET] WHERE ( [DocItem] < @DocItem or [DocItem] = @DocItem and [TipCod] < @TipCod or [TipCod] = @TipCod and [DocItem] = @DocItem and [DocNum] < @DocNum) ORDER BY [TipCod] DESC, [DocNum] DESC, [DocItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Z16", "SELECT [DocICBPER], [DocMonCod] FROM [CLVENTAS] WITH (UPDLOCK) WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z17", "INSERT INTO [CLVENTASDET]([DocDTot], [DocDICBPER], [DocItem], [DocDCan], [DocDpre], [DocDDct], [DocDDct2], [DocDObs], [DocDIna], [DocDPorSel], [DocDRef1], [DocDRef2], [DocDRef3], [DocDRef4], [DocDPed], [DocDPreInc], [DocDTotInc], [DocDValSel], [TipCod], [DocNum], [ProdCod]) VALUES(@DocDTot, @DocDICBPER, @DocItem, @DocDCan, @DocDpre, @DocDDct, @DocDDct2, @DocDObs, @DocDIna, @DocDPorSel, @DocDRef1, @DocDRef2, @DocDRef3, @DocDRef4, @DocDPed, @DocDPreInc, @DocDTotInc, @DocDValSel, @TipCod, @DocNum, @ProdCod)", GxErrorMask.GX_NOMASK,prmT002Z17)
           ,new CursorDef("T002Z19", "SELECT COALESCE( T1.[DocICBPER], 0) AS DocICBPER FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum] FROM [CLVENTASDET] WITH (UPDLOCK) GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z20", "UPDATE [CLVENTASDET] SET [DocDTot]=@DocDTot, [DocDICBPER]=@DocDICBPER, [DocDCan]=@DocDCan, [DocDpre]=@DocDpre, [DocDDct]=@DocDDct, [DocDDct2]=@DocDDct2, [DocDObs]=@DocDObs, [DocDIna]=@DocDIna, [DocDPorSel]=@DocDPorSel, [DocDRef1]=@DocDRef1, [DocDRef2]=@DocDRef2, [DocDRef3]=@DocDRef3, [DocDRef4]=@DocDRef4, [DocDPed]=@DocDPed, [DocDPreInc]=@DocDPreInc, [DocDTotInc]=@DocDTotInc, [DocDValSel]=@DocDValSel, [ProdCod]=@ProdCod  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem", GxErrorMask.GX_NOMASK,prmT002Z20)
           ,new CursorDef("T002Z22", "SELECT COALESCE( T1.[DocICBPER], 0) AS DocICBPER FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum] FROM [CLVENTASDET] WITH (UPDLOCK) GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z23", "DELETE FROM [CLVENTASDET]  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem", GxErrorMask.GX_NOMASK,prmT002Z23)
           ,new CursorDef("T002Z25", "SELECT COALESCE( T1.[DocICBPER], 0) AS DocICBPER FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum] FROM [CLVENTASDET] WITH (UPDLOCK) GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z26", "SELECT [DocICBPER], [DocMonCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z27", "SELECT [LinCod], [ProdDsc], [ProdPorSel], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z28", "SELECT [LinStk] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Z29", "UPDATE [CLVENTAS] SET [DocICBPER]=@DocICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT002Z29)
           ,new CursorDef("T002Z30", "SELECT [TipCod], [DocNum], [DocItem] FROM [CLVENTASDET] ORDER BY [TipCod], [DocNum], [DocItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Z30,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 12);
              ((string[]) buf[20])[0] = rslt.getString(21, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 12);
              ((string[]) buf[20])[0] = rslt.getString(21, 15);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(23);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(24);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(25);
              ((short[]) buf[25])[0] = rslt.getShort(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 3);
              ((string[]) buf[27])[0] = rslt.getString(28, 12);
              ((string[]) buf[28])[0] = rslt.getString(29, 15);
              ((int[]) buf[29])[0] = rslt.getInt(30);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 13 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 17 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 19 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 20 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
     }
  }

}

}
