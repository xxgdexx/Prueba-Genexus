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
   public class cpordendet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A289OrdCod = GetPar( "OrdCod");
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A289OrdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A28ProdCod) ;
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
            Form.Meta.addItem("description", "Ordenes de Compra - Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpordendet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpordendet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPORDENDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdCod_Internalname, StringUtil.RTrim( A289OrdCod), StringUtil.RTrim( context.localUtil.Format( A289OrdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Ord DItem", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A295OrdDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrdDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A295OrdDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A295OrdDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cantidad", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDCan_Internalname, StringUtil.LTrim( StringUtil.NToC( A1431OrdDCan, 17, 4, ".", "")), StringUtil.LTrim( ((edtOrdDCan_Enabled!=0) ? context.localUtil.Format( A1431OrdDCan, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1431OrdDCan, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDCan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDCan_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Precio", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDPre_Internalname, StringUtil.LTrim( StringUtil.NToC( A1438OrdDPre, 20, 6, ".", "")), StringUtil.LTrim( ((edtOrdDPre_Enabled!=0) ? context.localUtil.Format( A1438OrdDPre, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A1438OrdDPre, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDPre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% Dscto", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDDscto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1439OrdDDscto, 17, 2, ".", "")), StringUtil.LTrim( ((edtOrdDDscto_Enabled!=0) ? context.localUtil.Format( A1439OrdDDscto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1439OrdDDscto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDDscto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDDscto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Total Producto", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtOrdDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1444OrdDTot, 18, 8, ".", "")), StringUtil.LTrim( ((edtOrdDTot_Enabled!=0) ? context.localUtil.Format( A1444OrdDTot, "ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1444OrdDTot, "ZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDTot_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cantidad Ingresada", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDCanIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1434OrdDCanIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtOrdDCanIng_Enabled!=0) ? context.localUtil.Format( A1434OrdDCanIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1434OrdDCanIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDCanIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDCanIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cantidad Facturada", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDCanFac_Internalname, StringUtil.LTrim( StringUtil.NToC( A1432OrdDCanFac, 17, 4, ".", "")), StringUtil.LTrim( ((edtOrdDCanFac_Enabled!=0) ? context.localUtil.Format( A1432OrdDCanFac, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1432OrdDCanFac, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDCanFac_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDCanFac_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Observación", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOrdDObs_Internalname, A1441OrdDObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", 0, 1, edtOrdDObs_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Autorización", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtOrdAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1426OrdAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtOrdAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A1426OrdAut), "9") : context.localUtil.Format( (decimal)(A1426OrdAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Bultos", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdDBulto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1430OrdDBulto, 17, 4, ".", "")), StringUtil.LTrim( ((edtOrdDBulto_Enabled!=0) ? context.localUtil.Format( A1430OrdDBulto, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1430OrdDBulto, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdDBulto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdDBulto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPORDENDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPORDENDET.htm");
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
            Z289OrdCod = cgiGet( "Z289OrdCod");
            Z295OrdDItem = (int)(context.localUtil.CToN( cgiGet( "Z295OrdDItem"), ".", ","));
            Z1444OrdDTot = context.localUtil.CToN( cgiGet( "Z1444OrdDTot"), ".", ",");
            Z1431OrdDCan = context.localUtil.CToN( cgiGet( "Z1431OrdDCan"), ".", ",");
            Z1438OrdDPre = context.localUtil.CToN( cgiGet( "Z1438OrdDPre"), ".", ",");
            Z1439OrdDDscto = context.localUtil.CToN( cgiGet( "Z1439OrdDDscto"), ".", ",");
            Z1434OrdDCanIng = context.localUtil.CToN( cgiGet( "Z1434OrdDCanIng"), ".", ",");
            Z1432OrdDCanFac = context.localUtil.CToN( cgiGet( "Z1432OrdDCanFac"), ".", ",");
            Z1430OrdDBulto = context.localUtil.CToN( cgiGet( "Z1430OrdDBulto"), ".", ",");
            Z1440OrdDIna = (short)(context.localUtil.CToN( cgiGet( "Z1440OrdDIna"), ".", ","));
            Z1460OrdReqCod = cgiGet( "Z1460OrdReqCod");
            Z1447OrdDTotInc = context.localUtil.CToN( cgiGet( "Z1447OrdDTotInc"), ".", ",");
            Z1442OrdDPreInc = context.localUtil.CToN( cgiGet( "Z1442OrdDPreInc"), ".", ",");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            A1440OrdDIna = (short)(context.localUtil.CToN( cgiGet( "Z1440OrdDIna"), ".", ","));
            A1460OrdReqCod = cgiGet( "Z1460OrdReqCod");
            A1447OrdDTotInc = context.localUtil.CToN( cgiGet( "Z1447OrdDTotInc"), ".", ",");
            A1442OrdDPreInc = context.localUtil.CToN( cgiGet( "Z1442OrdDPreInc"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1436OrdDDescuento = context.localUtil.CToN( cgiGet( "ORDDDESCUENTO"), ".", ",");
            A1437OrdDSub = context.localUtil.CToN( cgiGet( "ORDDSUB"), ".", ",");
            A1435OrdDCanIngF = context.localUtil.CToN( cgiGet( "ORDDCANINGF"), ".", ",");
            A1433OrdDCanFacF = context.localUtil.CToN( cgiGet( "ORDDCANFACF"), ".", ",");
            A1446OrdDTotF = context.localUtil.CToN( cgiGet( "ORDDTOTF"), ".", ",");
            A1440OrdDIna = (short)(context.localUtil.CToN( cgiGet( "ORDDINA"), ".", ","));
            A1445OrdDSubInafecto = context.localUtil.CToN( cgiGet( "ORDDSUBINAFECTO"), ".", ",");
            A1443OrdDSubAfecto = context.localUtil.CToN( cgiGet( "ORDDSUBAFECTO"), ".", ",");
            A1460OrdReqCod = cgiGet( "ORDREQCOD");
            A1447OrdDTotInc = context.localUtil.CToN( cgiGet( "ORDDTOTINC"), ".", ",");
            A1442OrdDPreInc = context.localUtil.CToN( cgiGet( "ORDDPREINC"), ".", ",");
            /* Read variables values. */
            A289OrdCod = cgiGet( edtOrdCod_Internalname);
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDITEM");
               AnyError = 1;
               GX_FocusControl = edtOrdDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A295OrdDItem = 0;
               AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
            }
            else
            {
               A295OrdDItem = (int)(context.localUtil.CToN( cgiGet( edtOrdDItem_Internalname), ".", ","));
               AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDCan_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDCan_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDCAN");
               AnyError = 1;
               GX_FocusControl = edtOrdDCan_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1431OrdDCan = 0;
               AssignAttri("", false, "A1431OrdDCan", StringUtil.LTrimStr( A1431OrdDCan, 15, 4));
            }
            else
            {
               A1431OrdDCan = context.localUtil.CToN( cgiGet( edtOrdDCan_Internalname), ".", ",");
               AssignAttri("", false, "A1431OrdDCan", StringUtil.LTrimStr( A1431OrdDCan, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDPre_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDPre_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDPRE");
               AnyError = 1;
               GX_FocusControl = edtOrdDPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1438OrdDPre = 0;
               AssignAttri("", false, "A1438OrdDPre", StringUtil.LTrimStr( A1438OrdDPre, 18, 6));
            }
            else
            {
               A1438OrdDPre = context.localUtil.CToN( cgiGet( edtOrdDPre_Internalname), ".", ",");
               AssignAttri("", false, "A1438OrdDPre", StringUtil.LTrimStr( A1438OrdDPre, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDDscto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDDscto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDDSCTO");
               AnyError = 1;
               GX_FocusControl = edtOrdDDscto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1439OrdDDscto = 0;
               AssignAttri("", false, "A1439OrdDDscto", StringUtil.LTrimStr( A1439OrdDDscto, 15, 2));
            }
            else
            {
               A1439OrdDDscto = context.localUtil.CToN( cgiGet( edtOrdDDscto_Internalname), ".", ",");
               AssignAttri("", false, "A1439OrdDDscto", StringUtil.LTrimStr( A1439OrdDDscto, 15, 2));
            }
            A1444OrdDTot = context.localUtil.CToN( cgiGet( edtOrdDTot_Internalname), ".", ",");
            AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrimStr( A1444OrdDTot, 18, 8));
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDCanIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDCanIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDCANING");
               AnyError = 1;
               GX_FocusControl = edtOrdDCanIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1434OrdDCanIng = 0;
               AssignAttri("", false, "A1434OrdDCanIng", StringUtil.LTrimStr( A1434OrdDCanIng, 15, 4));
            }
            else
            {
               A1434OrdDCanIng = context.localUtil.CToN( cgiGet( edtOrdDCanIng_Internalname), ".", ",");
               AssignAttri("", false, "A1434OrdDCanIng", StringUtil.LTrimStr( A1434OrdDCanIng, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDCanFac_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDCanFac_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDCANFAC");
               AnyError = 1;
               GX_FocusControl = edtOrdDCanFac_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1432OrdDCanFac = 0;
               AssignAttri("", false, "A1432OrdDCanFac", StringUtil.LTrimStr( A1432OrdDCanFac, 15, 4));
            }
            else
            {
               A1432OrdDCanFac = context.localUtil.CToN( cgiGet( edtOrdDCanFac_Internalname), ".", ",");
               AssignAttri("", false, "A1432OrdDCanFac", StringUtil.LTrimStr( A1432OrdDCanFac, 15, 4));
            }
            A1441OrdDObs = cgiGet( edtOrdDObs_Internalname);
            AssignAttri("", false, "A1441OrdDObs", A1441OrdDObs);
            A1426OrdAut = (short)(context.localUtil.CToN( cgiGet( edtOrdAut_Internalname), ".", ","));
            AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdDBulto_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdDBulto_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDDBULTO");
               AnyError = 1;
               GX_FocusControl = edtOrdDBulto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1430OrdDBulto = 0;
               AssignAttri("", false, "A1430OrdDBulto", StringUtil.LTrimStr( A1430OrdDBulto, 15, 4));
            }
            else
            {
               A1430OrdDBulto = context.localUtil.CToN( cgiGet( edtOrdDBulto_Internalname), ".", ",");
               AssignAttri("", false, "A1430OrdDBulto", StringUtil.LTrimStr( A1430OrdDBulto, 15, 4));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CPORDENDET");
            forbiddenHiddens.Add("OrdDIna", context.localUtil.Format( (decimal)(A1440OrdDIna), "9"));
            forbiddenHiddens.Add("OrdReqCod", StringUtil.RTrim( context.localUtil.Format( A1460OrdReqCod, "")));
            forbiddenHiddens.Add("OrdDTotInc", context.localUtil.Format( A1447OrdDTotInc, "ZZZZ,ZZZ,ZZ9.9999"));
            forbiddenHiddens.Add("OrdDPreInc", context.localUtil.Format( A1442OrdDPreInc, "ZZZZZ,ZZZ,ZZ9.999999"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A295OrdDItem != Z295OrdDItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cpordendet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A289OrdCod = GetPar( "OrdCod");
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A295OrdDItem = (int)(NumberUtil.Val( GetPar( "OrdDItem"), "."));
               AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
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
               InitAll3K123( ) ;
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
         DisableAttributes3K123( ) ;
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

      protected void CONFIRM_3K0( )
      {
         BeforeValidate3K123( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3K123( ) ;
            }
            else
            {
               CheckExtendedTable3K123( ) ;
               if ( AnyError == 0 )
               {
                  ZM3K123( 10) ;
                  ZM3K123( 11) ;
               }
               CloseExtendedTableCursors3K123( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3K0( ) ;
         }
      }

      protected void ResetCaption3K0( )
      {
      }

      protected void ZM3K123( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1444OrdDTot = T003K3_A1444OrdDTot[0];
               Z1431OrdDCan = T003K3_A1431OrdDCan[0];
               Z1438OrdDPre = T003K3_A1438OrdDPre[0];
               Z1439OrdDDscto = T003K3_A1439OrdDDscto[0];
               Z1434OrdDCanIng = T003K3_A1434OrdDCanIng[0];
               Z1432OrdDCanFac = T003K3_A1432OrdDCanFac[0];
               Z1430OrdDBulto = T003K3_A1430OrdDBulto[0];
               Z1440OrdDIna = T003K3_A1440OrdDIna[0];
               Z1460OrdReqCod = T003K3_A1460OrdReqCod[0];
               Z1447OrdDTotInc = T003K3_A1447OrdDTotInc[0];
               Z1442OrdDPreInc = T003K3_A1442OrdDPreInc[0];
               Z28ProdCod = T003K3_A28ProdCod[0];
            }
            else
            {
               Z1444OrdDTot = A1444OrdDTot;
               Z1431OrdDCan = A1431OrdDCan;
               Z1438OrdDPre = A1438OrdDPre;
               Z1439OrdDDscto = A1439OrdDDscto;
               Z1434OrdDCanIng = A1434OrdDCanIng;
               Z1432OrdDCanFac = A1432OrdDCanFac;
               Z1430OrdDBulto = A1430OrdDBulto;
               Z1440OrdDIna = A1440OrdDIna;
               Z1460OrdReqCod = A1460OrdReqCod;
               Z1447OrdDTotInc = A1447OrdDTotInc;
               Z1442OrdDPreInc = A1442OrdDPreInc;
               Z28ProdCod = A28ProdCod;
            }
         }
         if ( GX_JID == -9 )
         {
            Z1444OrdDTot = A1444OrdDTot;
            Z295OrdDItem = A295OrdDItem;
            Z1431OrdDCan = A1431OrdDCan;
            Z1438OrdDPre = A1438OrdDPre;
            Z1439OrdDDscto = A1439OrdDDscto;
            Z1434OrdDCanIng = A1434OrdDCanIng;
            Z1432OrdDCanFac = A1432OrdDCanFac;
            Z1441OrdDObs = A1441OrdDObs;
            Z1430OrdDBulto = A1430OrdDBulto;
            Z1440OrdDIna = A1440OrdDIna;
            Z1460OrdReqCod = A1460OrdReqCod;
            Z1447OrdDTotInc = A1447OrdDTotInc;
            Z1442OrdDPreInc = A1442OrdDPreInc;
            Z289OrdCod = A289OrdCod;
            Z28ProdCod = A28ProdCod;
            Z1426OrdAut = A1426OrdAut;
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

      protected void Load3K123( )
      {
         /* Using cursor T003K6 */
         pr_default.execute(4, new Object[] {A289OrdCod, A295OrdDItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound123 = 1;
            A1444OrdDTot = T003K6_A1444OrdDTot[0];
            AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrimStr( A1444OrdDTot, 18, 8));
            A1431OrdDCan = T003K6_A1431OrdDCan[0];
            AssignAttri("", false, "A1431OrdDCan", StringUtil.LTrimStr( A1431OrdDCan, 15, 4));
            A1438OrdDPre = T003K6_A1438OrdDPre[0];
            AssignAttri("", false, "A1438OrdDPre", StringUtil.LTrimStr( A1438OrdDPre, 18, 6));
            A1439OrdDDscto = T003K6_A1439OrdDDscto[0];
            AssignAttri("", false, "A1439OrdDDscto", StringUtil.LTrimStr( A1439OrdDDscto, 15, 2));
            A1434OrdDCanIng = T003K6_A1434OrdDCanIng[0];
            AssignAttri("", false, "A1434OrdDCanIng", StringUtil.LTrimStr( A1434OrdDCanIng, 15, 4));
            A1432OrdDCanFac = T003K6_A1432OrdDCanFac[0];
            AssignAttri("", false, "A1432OrdDCanFac", StringUtil.LTrimStr( A1432OrdDCanFac, 15, 4));
            A1441OrdDObs = T003K6_A1441OrdDObs[0];
            AssignAttri("", false, "A1441OrdDObs", A1441OrdDObs);
            A1426OrdAut = T003K6_A1426OrdAut[0];
            AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            A1430OrdDBulto = T003K6_A1430OrdDBulto[0];
            AssignAttri("", false, "A1430OrdDBulto", StringUtil.LTrimStr( A1430OrdDBulto, 15, 4));
            A1440OrdDIna = T003K6_A1440OrdDIna[0];
            A1460OrdReqCod = T003K6_A1460OrdReqCod[0];
            A1447OrdDTotInc = T003K6_A1447OrdDTotInc[0];
            A1442OrdDPreInc = T003K6_A1442OrdDPreInc[0];
            A28ProdCod = T003K6_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            ZM3K123( -9) ;
         }
         pr_default.close(4);
         OnLoadActions3K123( ) ;
      }

      protected void OnLoadActions3K123( )
      {
         A1437OrdDSub = NumberUtil.Round( A1431OrdDCan*A1438OrdDPre, 2);
         AssignAttri("", false, "A1437OrdDSub", StringUtil.LTrimStr( A1437OrdDSub, 15, 2));
         A1436OrdDDescuento = NumberUtil.Round( A1437OrdDSub*A1439OrdDDscto/ (decimal)(100), 2);
         AssignAttri("", false, "A1436OrdDDescuento", StringUtil.LTrimStr( A1436OrdDDescuento, 15, 2));
         A1444OrdDTot = NumberUtil.Round( (A1431OrdDCan*A1438OrdDPre)-A1436OrdDDescuento, 8);
         AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrimStr( A1444OrdDTot, 18, 8));
         A1435OrdDCanIngF = (decimal)(A1431OrdDCan-A1434OrdDCanIng);
         AssignAttri("", false, "A1435OrdDCanIngF", StringUtil.LTrimStr( A1435OrdDCanIngF, 15, 4));
         A1433OrdDCanFacF = (decimal)(A1431OrdDCan-A1432OrdDCanFac);
         AssignAttri("", false, "A1433OrdDCanFacF", StringUtil.LTrimStr( A1433OrdDCanFacF, 15, 4));
         A1446OrdDTotF = (decimal)(NumberUtil.Round( A1433OrdDCanFacF*A1438OrdDPre, 2)-NumberUtil.Round( NumberUtil.Round( A1433OrdDCanFacF*A1438OrdDPre, 2)*A1439OrdDDscto/ (decimal)(100), 2));
         AssignAttri("", false, "A1446OrdDTotF", StringUtil.LTrimStr( A1446OrdDTotF, 15, 2));
         A1445OrdDSubInafecto = ((A1440OrdDIna==1) ? A1444OrdDTot : (decimal)(0));
         AssignAttri("", false, "A1445OrdDSubInafecto", StringUtil.LTrimStr( A1445OrdDSubInafecto, 15, 2));
         A1443OrdDSubAfecto = ((A1440OrdDIna==0) ? A1444OrdDTot : (decimal)(0));
         AssignAttri("", false, "A1443OrdDSubAfecto", StringUtil.LTrimStr( A1443OrdDSubAfecto, 15, 2));
      }

      protected void CheckExtendedTable3K123( )
      {
         nIsDirty_123 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003K4 */
         pr_default.execute(2, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1426OrdAut = T003K4_A1426OrdAut[0];
         AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
         pr_default.close(2);
         /* Using cursor T003K5 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         nIsDirty_123 = 1;
         A1437OrdDSub = NumberUtil.Round( A1431OrdDCan*A1438OrdDPre, 2);
         AssignAttri("", false, "A1437OrdDSub", StringUtil.LTrimStr( A1437OrdDSub, 15, 2));
         nIsDirty_123 = 1;
         A1436OrdDDescuento = NumberUtil.Round( A1437OrdDSub*A1439OrdDDscto/ (decimal)(100), 2);
         AssignAttri("", false, "A1436OrdDDescuento", StringUtil.LTrimStr( A1436OrdDDescuento, 15, 2));
         nIsDirty_123 = 1;
         A1444OrdDTot = NumberUtil.Round( (A1431OrdDCan*A1438OrdDPre)-A1436OrdDDescuento, 8);
         AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrimStr( A1444OrdDTot, 18, 8));
         nIsDirty_123 = 1;
         A1435OrdDCanIngF = (decimal)(A1431OrdDCan-A1434OrdDCanIng);
         AssignAttri("", false, "A1435OrdDCanIngF", StringUtil.LTrimStr( A1435OrdDCanIngF, 15, 4));
         nIsDirty_123 = 1;
         A1433OrdDCanFacF = (decimal)(A1431OrdDCan-A1432OrdDCanFac);
         AssignAttri("", false, "A1433OrdDCanFacF", StringUtil.LTrimStr( A1433OrdDCanFacF, 15, 4));
         nIsDirty_123 = 1;
         A1446OrdDTotF = (decimal)(NumberUtil.Round( A1433OrdDCanFacF*A1438OrdDPre, 2)-NumberUtil.Round( NumberUtil.Round( A1433OrdDCanFacF*A1438OrdDPre, 2)*A1439OrdDDscto/ (decimal)(100), 2));
         AssignAttri("", false, "A1446OrdDTotF", StringUtil.LTrimStr( A1446OrdDTotF, 15, 2));
         nIsDirty_123 = 1;
         A1445OrdDSubInafecto = ((A1440OrdDIna==1) ? A1444OrdDTot : (decimal)(0));
         AssignAttri("", false, "A1445OrdDSubInafecto", StringUtil.LTrimStr( A1445OrdDSubInafecto, 15, 2));
         nIsDirty_123 = 1;
         A1443OrdDSubAfecto = ((A1440OrdDIna==0) ? A1444OrdDTot : (decimal)(0));
         AssignAttri("", false, "A1443OrdDSubAfecto", StringUtil.LTrimStr( A1443OrdDSubAfecto, 15, 2));
      }

      protected void CloseExtendedTableCursors3K123( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( string A289OrdCod )
      {
         /* Using cursor T003K7 */
         pr_default.execute(5, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1426OrdAut = T003K7_A1426OrdAut[0];
         AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1426OrdAut), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_11( string A28ProdCod )
      {
         /* Using cursor T003K8 */
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

      protected void GetKey3K123( )
      {
         /* Using cursor T003K9 */
         pr_default.execute(7, new Object[] {A289OrdCod, A295OrdDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound123 = 1;
         }
         else
         {
            RcdFound123 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003K3 */
         pr_default.execute(1, new Object[] {A289OrdCod, A295OrdDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3K123( 9) ;
            RcdFound123 = 1;
            A1444OrdDTot = T003K3_A1444OrdDTot[0];
            AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrimStr( A1444OrdDTot, 18, 8));
            A295OrdDItem = T003K3_A295OrdDItem[0];
            AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
            A1431OrdDCan = T003K3_A1431OrdDCan[0];
            AssignAttri("", false, "A1431OrdDCan", StringUtil.LTrimStr( A1431OrdDCan, 15, 4));
            A1438OrdDPre = T003K3_A1438OrdDPre[0];
            AssignAttri("", false, "A1438OrdDPre", StringUtil.LTrimStr( A1438OrdDPre, 18, 6));
            A1439OrdDDscto = T003K3_A1439OrdDDscto[0];
            AssignAttri("", false, "A1439OrdDDscto", StringUtil.LTrimStr( A1439OrdDDscto, 15, 2));
            A1434OrdDCanIng = T003K3_A1434OrdDCanIng[0];
            AssignAttri("", false, "A1434OrdDCanIng", StringUtil.LTrimStr( A1434OrdDCanIng, 15, 4));
            A1432OrdDCanFac = T003K3_A1432OrdDCanFac[0];
            AssignAttri("", false, "A1432OrdDCanFac", StringUtil.LTrimStr( A1432OrdDCanFac, 15, 4));
            A1441OrdDObs = T003K3_A1441OrdDObs[0];
            AssignAttri("", false, "A1441OrdDObs", A1441OrdDObs);
            A1430OrdDBulto = T003K3_A1430OrdDBulto[0];
            AssignAttri("", false, "A1430OrdDBulto", StringUtil.LTrimStr( A1430OrdDBulto, 15, 4));
            A1440OrdDIna = T003K3_A1440OrdDIna[0];
            A1460OrdReqCod = T003K3_A1460OrdReqCod[0];
            A1447OrdDTotInc = T003K3_A1447OrdDTotInc[0];
            A1442OrdDPreInc = T003K3_A1442OrdDPreInc[0];
            A289OrdCod = T003K3_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A28ProdCod = T003K3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z289OrdCod = A289OrdCod;
            Z295OrdDItem = A295OrdDItem;
            sMode123 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3K123( ) ;
            if ( AnyError == 1 )
            {
               RcdFound123 = 0;
               InitializeNonKey3K123( ) ;
            }
            Gx_mode = sMode123;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound123 = 0;
            InitializeNonKey3K123( ) ;
            sMode123 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode123;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3K123( ) ;
         if ( RcdFound123 == 0 )
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
         RcdFound123 = 0;
         /* Using cursor T003K10 */
         pr_default.execute(8, new Object[] {A289OrdCod, A295OrdDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003K10_A289OrdCod[0], A289OrdCod) < 0 ) || ( StringUtil.StrCmp(T003K10_A289OrdCod[0], A289OrdCod) == 0 ) && ( T003K10_A295OrdDItem[0] < A295OrdDItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003K10_A289OrdCod[0], A289OrdCod) > 0 ) || ( StringUtil.StrCmp(T003K10_A289OrdCod[0], A289OrdCod) == 0 ) && ( T003K10_A295OrdDItem[0] > A295OrdDItem ) ) )
            {
               A289OrdCod = T003K10_A289OrdCod[0];
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A295OrdDItem = T003K10_A295OrdDItem[0];
               AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
               RcdFound123 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound123 = 0;
         /* Using cursor T003K11 */
         pr_default.execute(9, new Object[] {A289OrdCod, A295OrdDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003K11_A289OrdCod[0], A289OrdCod) > 0 ) || ( StringUtil.StrCmp(T003K11_A289OrdCod[0], A289OrdCod) == 0 ) && ( T003K11_A295OrdDItem[0] > A295OrdDItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003K11_A289OrdCod[0], A289OrdCod) < 0 ) || ( StringUtil.StrCmp(T003K11_A289OrdCod[0], A289OrdCod) == 0 ) && ( T003K11_A295OrdDItem[0] < A295OrdDItem ) ) )
            {
               A289OrdCod = T003K11_A289OrdCod[0];
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A295OrdDItem = T003K11_A295OrdDItem[0];
               AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
               RcdFound123 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3K123( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3K123( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound123 == 1 )
            {
               if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A295OrdDItem != Z295OrdDItem ) )
               {
                  A289OrdCod = Z289OrdCod;
                  AssignAttri("", false, "A289OrdCod", A289OrdCod);
                  A295OrdDItem = Z295OrdDItem;
                  AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ORDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3K123( ) ;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A295OrdDItem != Z295OrdDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3K123( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtOrdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtOrdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3K123( ) ;
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
         if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A295OrdDItem != Z295OrdDItem ) )
         {
            A289OrdCod = Z289OrdCod;
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A295OrdDItem = Z295OrdDItem;
            AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOrdCod_Internalname;
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
         GetKey3K123( ) ;
         if ( RcdFound123 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ORDCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A295OrdDItem != Z295OrdDItem ) )
            {
               A289OrdCod = Z289OrdCod;
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A295OrdDItem = Z295OrdDItem;
               AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ORDCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A295OrdDItem != Z295OrdDItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtOrdCod_Internalname;
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
         context.RollbackDataStores("cpordendet",pr_default);
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3K0( ) ;
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
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
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
         ScanStart3K123( ) ;
         if ( RcdFound123 == 0 )
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
         ScanEnd3K123( ) ;
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
         if ( RcdFound123 == 0 )
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
         if ( RcdFound123 == 0 )
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
         ScanStart3K123( ) ;
         if ( RcdFound123 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound123 != 0 )
            {
               ScanNext3K123( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3K123( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3K123( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003K2 */
            pr_default.execute(0, new Object[] {A289OrdCod, A295OrdDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPORDENDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1444OrdDTot != T003K2_A1444OrdDTot[0] ) || ( Z1431OrdDCan != T003K2_A1431OrdDCan[0] ) || ( Z1438OrdDPre != T003K2_A1438OrdDPre[0] ) || ( Z1439OrdDDscto != T003K2_A1439OrdDDscto[0] ) || ( Z1434OrdDCanIng != T003K2_A1434OrdDCanIng[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1432OrdDCanFac != T003K2_A1432OrdDCanFac[0] ) || ( Z1430OrdDBulto != T003K2_A1430OrdDBulto[0] ) || ( Z1440OrdDIna != T003K2_A1440OrdDIna[0] ) || ( StringUtil.StrCmp(Z1460OrdReqCod, T003K2_A1460OrdReqCod[0]) != 0 ) || ( Z1447OrdDTotInc != T003K2_A1447OrdDTotInc[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1442OrdDPreInc != T003K2_A1442OrdDPreInc[0] ) || ( StringUtil.StrCmp(Z28ProdCod, T003K2_A28ProdCod[0]) != 0 ) )
            {
               if ( Z1444OrdDTot != T003K2_A1444OrdDTot[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDTot");
                  GXUtil.WriteLogRaw("Old: ",Z1444OrdDTot);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1444OrdDTot[0]);
               }
               if ( Z1431OrdDCan != T003K2_A1431OrdDCan[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDCan");
                  GXUtil.WriteLogRaw("Old: ",Z1431OrdDCan);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1431OrdDCan[0]);
               }
               if ( Z1438OrdDPre != T003K2_A1438OrdDPre[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDPre");
                  GXUtil.WriteLogRaw("Old: ",Z1438OrdDPre);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1438OrdDPre[0]);
               }
               if ( Z1439OrdDDscto != T003K2_A1439OrdDDscto[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDDscto");
                  GXUtil.WriteLogRaw("Old: ",Z1439OrdDDscto);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1439OrdDDscto[0]);
               }
               if ( Z1434OrdDCanIng != T003K2_A1434OrdDCanIng[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDCanIng");
                  GXUtil.WriteLogRaw("Old: ",Z1434OrdDCanIng);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1434OrdDCanIng[0]);
               }
               if ( Z1432OrdDCanFac != T003K2_A1432OrdDCanFac[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDCanFac");
                  GXUtil.WriteLogRaw("Old: ",Z1432OrdDCanFac);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1432OrdDCanFac[0]);
               }
               if ( Z1430OrdDBulto != T003K2_A1430OrdDBulto[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDBulto");
                  GXUtil.WriteLogRaw("Old: ",Z1430OrdDBulto);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1430OrdDBulto[0]);
               }
               if ( Z1440OrdDIna != T003K2_A1440OrdDIna[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDIna");
                  GXUtil.WriteLogRaw("Old: ",Z1440OrdDIna);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1440OrdDIna[0]);
               }
               if ( StringUtil.StrCmp(Z1460OrdReqCod, T003K2_A1460OrdReqCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdReqCod");
                  GXUtil.WriteLogRaw("Old: ",Z1460OrdReqCod);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1460OrdReqCod[0]);
               }
               if ( Z1447OrdDTotInc != T003K2_A1447OrdDTotInc[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDTotInc");
                  GXUtil.WriteLogRaw("Old: ",Z1447OrdDTotInc);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1447OrdDTotInc[0]);
               }
               if ( Z1442OrdDPreInc != T003K2_A1442OrdDPreInc[0] )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"OrdDPreInc");
                  GXUtil.WriteLogRaw("Old: ",Z1442OrdDPreInc);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A1442OrdDPreInc[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T003K2_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpordendet:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T003K2_A28ProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPORDENDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3K123( )
      {
         BeforeValidate3K123( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3K123( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3K123( 0) ;
            CheckOptimisticConcurrency3K123( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3K123( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3K123( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003K12 */
                     pr_default.execute(10, new Object[] {A1444OrdDTot, A295OrdDItem, A1431OrdDCan, A1438OrdDPre, A1439OrdDDscto, A1434OrdDCanIng, A1432OrdDCanFac, A1441OrdDObs, A1430OrdDBulto, A1440OrdDIna, A1460OrdReqCod, A1447OrdDTotInc, A1442OrdDPreInc, A289OrdCod, A28ProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPORDENDET");
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
                           ResetCaption3K0( ) ;
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
               Load3K123( ) ;
            }
            EndLevel3K123( ) ;
         }
         CloseExtendedTableCursors3K123( ) ;
      }

      protected void Update3K123( )
      {
         BeforeValidate3K123( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3K123( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3K123( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3K123( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3K123( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003K13 */
                     pr_default.execute(11, new Object[] {A1444OrdDTot, A1431OrdDCan, A1438OrdDPre, A1439OrdDDscto, A1434OrdDCanIng, A1432OrdDCanFac, A1441OrdDObs, A1430OrdDBulto, A1440OrdDIna, A1460OrdReqCod, A1447OrdDTotInc, A1442OrdDPreInc, A28ProdCod, A289OrdCod, A295OrdDItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPORDENDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPORDENDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3K123( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3K0( ) ;
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
            EndLevel3K123( ) ;
         }
         CloseExtendedTableCursors3K123( ) ;
      }

      protected void DeferredUpdate3K123( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3K123( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3K123( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3K123( ) ;
            AfterConfirm3K123( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3K123( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003K14 */
                  pr_default.execute(12, new Object[] {A289OrdCod, A295OrdDItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPORDENDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound123 == 0 )
                        {
                           InitAll3K123( ) ;
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
                        ResetCaption3K0( ) ;
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
         sMode123 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3K123( ) ;
         Gx_mode = sMode123;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3K123( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003K15 */
            pr_default.execute(13, new Object[] {A289OrdCod});
            A1426OrdAut = T003K15_A1426OrdAut[0];
            AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            pr_default.close(13);
            A1437OrdDSub = NumberUtil.Round( A1431OrdDCan*A1438OrdDPre, 2);
            AssignAttri("", false, "A1437OrdDSub", StringUtil.LTrimStr( A1437OrdDSub, 15, 2));
            A1436OrdDDescuento = NumberUtil.Round( A1437OrdDSub*A1439OrdDDscto/ (decimal)(100), 2);
            AssignAttri("", false, "A1436OrdDDescuento", StringUtil.LTrimStr( A1436OrdDDescuento, 15, 2));
            A1435OrdDCanIngF = (decimal)(A1431OrdDCan-A1434OrdDCanIng);
            AssignAttri("", false, "A1435OrdDCanIngF", StringUtil.LTrimStr( A1435OrdDCanIngF, 15, 4));
            A1433OrdDCanFacF = (decimal)(A1431OrdDCan-A1432OrdDCanFac);
            AssignAttri("", false, "A1433OrdDCanFacF", StringUtil.LTrimStr( A1433OrdDCanFacF, 15, 4));
            A1446OrdDTotF = (decimal)(NumberUtil.Round( A1433OrdDCanFacF*A1438OrdDPre, 2)-NumberUtil.Round( NumberUtil.Round( A1433OrdDCanFacF*A1438OrdDPre, 2)*A1439OrdDDscto/ (decimal)(100), 2));
            AssignAttri("", false, "A1446OrdDTotF", StringUtil.LTrimStr( A1446OrdDTotF, 15, 2));
            A1445OrdDSubInafecto = ((A1440OrdDIna==1) ? A1444OrdDTot : (decimal)(0));
            AssignAttri("", false, "A1445OrdDSubInafecto", StringUtil.LTrimStr( A1445OrdDSubInafecto, 15, 2));
            A1443OrdDSubAfecto = ((A1440OrdDIna==0) ? A1444OrdDTot : (decimal)(0));
            AssignAttri("", false, "A1443OrdDSubAfecto", StringUtil.LTrimStr( A1443OrdDSubAfecto, 15, 2));
         }
      }

      protected void EndLevel3K123( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3K123( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("cpordendet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("cpordendet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3K123( )
      {
         /* Using cursor T003K16 */
         pr_default.execute(14);
         RcdFound123 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound123 = 1;
            A289OrdCod = T003K16_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A295OrdDItem = T003K16_A295OrdDItem[0];
            AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3K123( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound123 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound123 = 1;
            A289OrdCod = T003K16_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A295OrdDItem = T003K16_A295OrdDItem[0];
            AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
         }
      }

      protected void ScanEnd3K123( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm3K123( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3K123( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3K123( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3K123( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3K123( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3K123( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3K123( )
      {
         edtOrdCod_Enabled = 0;
         AssignProp("", false, edtOrdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCod_Enabled), 5, 0), true);
         edtOrdDItem_Enabled = 0;
         AssignProp("", false, edtOrdDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDItem_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtOrdDCan_Enabled = 0;
         AssignProp("", false, edtOrdDCan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDCan_Enabled), 5, 0), true);
         edtOrdDPre_Enabled = 0;
         AssignProp("", false, edtOrdDPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDPre_Enabled), 5, 0), true);
         edtOrdDDscto_Enabled = 0;
         AssignProp("", false, edtOrdDDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDDscto_Enabled), 5, 0), true);
         edtOrdDTot_Enabled = 0;
         AssignProp("", false, edtOrdDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDTot_Enabled), 5, 0), true);
         edtOrdDCanIng_Enabled = 0;
         AssignProp("", false, edtOrdDCanIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDCanIng_Enabled), 5, 0), true);
         edtOrdDCanFac_Enabled = 0;
         AssignProp("", false, edtOrdDCanFac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDCanFac_Enabled), 5, 0), true);
         edtOrdDObs_Enabled = 0;
         AssignProp("", false, edtOrdDObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDObs_Enabled), 5, 0), true);
         edtOrdAut_Enabled = 0;
         AssignProp("", false, edtOrdAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdAut_Enabled), 5, 0), true);
         edtOrdDBulto_Enabled = 0;
         AssignProp("", false, edtOrdDBulto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdDBulto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3K123( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3K0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810251331", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpordendet.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CPORDENDET");
         forbiddenHiddens.Add("OrdDIna", context.localUtil.Format( (decimal)(A1440OrdDIna), "9"));
         forbiddenHiddens.Add("OrdReqCod", StringUtil.RTrim( context.localUtil.Format( A1460OrdReqCod, "")));
         forbiddenHiddens.Add("OrdDTotInc", context.localUtil.Format( A1447OrdDTotInc, "ZZZZ,ZZZ,ZZ9.9999"));
         forbiddenHiddens.Add("OrdDPreInc", context.localUtil.Format( A1442OrdDPreInc, "ZZZZZ,ZZZ,ZZ9.999999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cpordendet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z289OrdCod", StringUtil.RTrim( Z289OrdCod));
         GxWebStd.gx_hidden_field( context, "Z295OrdDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z295OrdDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1444OrdDTot", StringUtil.LTrim( StringUtil.NToC( Z1444OrdDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1431OrdDCan", StringUtil.LTrim( StringUtil.NToC( Z1431OrdDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1438OrdDPre", StringUtil.LTrim( StringUtil.NToC( Z1438OrdDPre, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1439OrdDDscto", StringUtil.LTrim( StringUtil.NToC( Z1439OrdDDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1434OrdDCanIng", StringUtil.LTrim( StringUtil.NToC( Z1434OrdDCanIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1432OrdDCanFac", StringUtil.LTrim( StringUtil.NToC( Z1432OrdDCanFac, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1430OrdDBulto", StringUtil.LTrim( StringUtil.NToC( Z1430OrdDBulto, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1440OrdDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1440OrdDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1460OrdReqCod", Z1460OrdReqCod);
         GxWebStd.gx_hidden_field( context, "Z1447OrdDTotInc", StringUtil.LTrim( StringUtil.NToC( Z1447OrdDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1442OrdDPreInc", StringUtil.LTrim( StringUtil.NToC( Z1442OrdDPreInc, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "ORDDDESCUENTO", StringUtil.LTrim( StringUtil.NToC( A1436OrdDDescuento, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDSUB", StringUtil.LTrim( StringUtil.NToC( A1437OrdDSub, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDCANINGF", StringUtil.LTrim( StringUtil.NToC( A1435OrdDCanIngF, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDCANFACF", StringUtil.LTrim( StringUtil.NToC( A1433OrdDCanFacF, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDTOTF", StringUtil.LTrim( StringUtil.NToC( A1446OrdDTotF, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDINA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1440OrdDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDSUBINAFECTO", StringUtil.LTrim( StringUtil.NToC( A1445OrdDSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDSUBAFECTO", StringUtil.LTrim( StringUtil.NToC( A1443OrdDSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDREQCOD", A1460OrdReqCod);
         GxWebStd.gx_hidden_field( context, "ORDDTOTINC", StringUtil.LTrim( StringUtil.NToC( A1447OrdDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDPREINC", StringUtil.LTrim( StringUtil.NToC( A1442OrdDPreInc, 18, 6, ".", "")));
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
         return formatLink("cpordendet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPORDENDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ordenes de Compra - Detalle" ;
      }

      protected void InitializeNonKey3K123( )
      {
         A1443OrdDSubAfecto = 0;
         AssignAttri("", false, "A1443OrdDSubAfecto", StringUtil.LTrimStr( A1443OrdDSubAfecto, 15, 2));
         A1445OrdDSubInafecto = 0;
         AssignAttri("", false, "A1445OrdDSubInafecto", StringUtil.LTrimStr( A1445OrdDSubInafecto, 15, 2));
         A1436OrdDDescuento = 0;
         AssignAttri("", false, "A1436OrdDDescuento", StringUtil.LTrimStr( A1436OrdDDescuento, 15, 2));
         A1446OrdDTotF = 0;
         AssignAttri("", false, "A1446OrdDTotF", StringUtil.LTrimStr( A1446OrdDTotF, 15, 2));
         A1433OrdDCanFacF = 0;
         AssignAttri("", false, "A1433OrdDCanFacF", StringUtil.LTrimStr( A1433OrdDCanFacF, 15, 4));
         A1435OrdDCanIngF = 0;
         AssignAttri("", false, "A1435OrdDCanIngF", StringUtil.LTrimStr( A1435OrdDCanIngF, 15, 4));
         A1437OrdDSub = 0;
         AssignAttri("", false, "A1437OrdDSub", StringUtil.LTrimStr( A1437OrdDSub, 15, 2));
         A1444OrdDTot = 0;
         AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrimStr( A1444OrdDTot, 18, 8));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A1431OrdDCan = 0;
         AssignAttri("", false, "A1431OrdDCan", StringUtil.LTrimStr( A1431OrdDCan, 15, 4));
         A1438OrdDPre = 0;
         AssignAttri("", false, "A1438OrdDPre", StringUtil.LTrimStr( A1438OrdDPre, 18, 6));
         A1439OrdDDscto = 0;
         AssignAttri("", false, "A1439OrdDDscto", StringUtil.LTrimStr( A1439OrdDDscto, 15, 2));
         A1434OrdDCanIng = 0;
         AssignAttri("", false, "A1434OrdDCanIng", StringUtil.LTrimStr( A1434OrdDCanIng, 15, 4));
         A1432OrdDCanFac = 0;
         AssignAttri("", false, "A1432OrdDCanFac", StringUtil.LTrimStr( A1432OrdDCanFac, 15, 4));
         A1441OrdDObs = "";
         AssignAttri("", false, "A1441OrdDObs", A1441OrdDObs);
         A1426OrdAut = 0;
         AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
         A1430OrdDBulto = 0;
         AssignAttri("", false, "A1430OrdDBulto", StringUtil.LTrimStr( A1430OrdDBulto, 15, 4));
         A1440OrdDIna = 0;
         AssignAttri("", false, "A1440OrdDIna", StringUtil.Str( (decimal)(A1440OrdDIna), 1, 0));
         A1460OrdReqCod = "";
         AssignAttri("", false, "A1460OrdReqCod", A1460OrdReqCod);
         A1447OrdDTotInc = 0;
         AssignAttri("", false, "A1447OrdDTotInc", StringUtil.LTrimStr( A1447OrdDTotInc, 15, 4));
         A1442OrdDPreInc = 0;
         AssignAttri("", false, "A1442OrdDPreInc", StringUtil.LTrimStr( A1442OrdDPreInc, 18, 6));
         Z1444OrdDTot = 0;
         Z1431OrdDCan = 0;
         Z1438OrdDPre = 0;
         Z1439OrdDDscto = 0;
         Z1434OrdDCanIng = 0;
         Z1432OrdDCanFac = 0;
         Z1430OrdDBulto = 0;
         Z1440OrdDIna = 0;
         Z1460OrdReqCod = "";
         Z1447OrdDTotInc = 0;
         Z1442OrdDPreInc = 0;
         Z28ProdCod = "";
      }

      protected void InitAll3K123( )
      {
         A289OrdCod = "";
         AssignAttri("", false, "A289OrdCod", A289OrdCod);
         A295OrdDItem = 0;
         AssignAttri("", false, "A295OrdDItem", StringUtil.LTrimStr( (decimal)(A295OrdDItem), 6, 0));
         InitializeNonKey3K123( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251346", true, true);
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
         context.AddJavascriptSource("cpordendet.js", "?202281810251346", false, true);
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
         edtOrdCod_Internalname = "ORDCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtOrdDItem_Internalname = "ORDDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtOrdDCan_Internalname = "ORDDCAN";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtOrdDPre_Internalname = "ORDDPRE";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtOrdDDscto_Internalname = "ORDDDSCTO";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtOrdDTot_Internalname = "ORDDTOT";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtOrdDCanIng_Internalname = "ORDDCANING";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtOrdDCanFac_Internalname = "ORDDCANFAC";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtOrdDObs_Internalname = "ORDDOBS";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtOrdAut_Internalname = "ORDAUT";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtOrdDBulto_Internalname = "ORDDBULTO";
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
         Form.Caption = "Ordenes de Compra - Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtOrdDBulto_Jsonclick = "";
         edtOrdDBulto_Enabled = 1;
         edtOrdAut_Jsonclick = "";
         edtOrdAut_Enabled = 0;
         edtOrdDObs_Enabled = 1;
         edtOrdDCanFac_Jsonclick = "";
         edtOrdDCanFac_Enabled = 1;
         edtOrdDCanIng_Jsonclick = "";
         edtOrdDCanIng_Enabled = 1;
         edtOrdDTot_Jsonclick = "";
         edtOrdDTot_Enabled = 0;
         edtOrdDDscto_Jsonclick = "";
         edtOrdDDscto_Enabled = 1;
         edtOrdDPre_Jsonclick = "";
         edtOrdDPre_Enabled = 1;
         edtOrdDCan_Jsonclick = "";
         edtOrdDCan_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtOrdDItem_Jsonclick = "";
         edtOrdDItem_Enabled = 1;
         edtOrdCod_Jsonclick = "";
         edtOrdCod_Enabled = 1;
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
         /* Using cursor T003K15 */
         pr_default.execute(13, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1426OrdAut = T003K15_A1426OrdAut[0];
         AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
         pr_default.close(13);
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

      public void Valid_Ordcod( )
      {
         /* Using cursor T003K15 */
         pr_default.execute(13, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
         }
         A1426OrdAut = T003K15_A1426OrdAut[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1426OrdAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1426OrdAut), 1, 0, ".", "")));
      }

      public void Valid_Ordditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A1431OrdDCan", StringUtil.LTrim( StringUtil.NToC( A1431OrdDCan, 15, 4, ".", "")));
         AssignAttri("", false, "A1438OrdDPre", StringUtil.LTrim( StringUtil.NToC( A1438OrdDPre, 18, 6, ".", "")));
         AssignAttri("", false, "A1439OrdDDscto", StringUtil.LTrim( StringUtil.NToC( A1439OrdDDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A1434OrdDCanIng", StringUtil.LTrim( StringUtil.NToC( A1434OrdDCanIng, 15, 4, ".", "")));
         AssignAttri("", false, "A1432OrdDCanFac", StringUtil.LTrim( StringUtil.NToC( A1432OrdDCanFac, 15, 4, ".", "")));
         AssignAttri("", false, "A1441OrdDObs", A1441OrdDObs);
         AssignAttri("", false, "A1430OrdDBulto", StringUtil.LTrim( StringUtil.NToC( A1430OrdDBulto, 15, 4, ".", "")));
         AssignAttri("", false, "A1440OrdDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1440OrdDIna), 1, 0, ".", "")));
         AssignAttri("", false, "A1460OrdReqCod", A1460OrdReqCod);
         AssignAttri("", false, "A1447OrdDTotInc", StringUtil.LTrim( StringUtil.NToC( A1447OrdDTotInc, 15, 4, ".", "")));
         AssignAttri("", false, "A1442OrdDPreInc", StringUtil.LTrim( StringUtil.NToC( A1442OrdDPreInc, 18, 6, ".", "")));
         AssignAttri("", false, "A1426OrdAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1426OrdAut), 1, 0, ".", "")));
         AssignAttri("", false, "A1437OrdDSub", StringUtil.LTrim( StringUtil.NToC( A1437OrdDSub, 15, 2, ".", "")));
         AssignAttri("", false, "A1436OrdDDescuento", StringUtil.LTrim( StringUtil.NToC( A1436OrdDDescuento, 15, 2, ".", "")));
         AssignAttri("", false, "A1444OrdDTot", StringUtil.LTrim( StringUtil.NToC( A1444OrdDTot, 18, 8, ".", "")));
         AssignAttri("", false, "A1435OrdDCanIngF", StringUtil.LTrim( StringUtil.NToC( A1435OrdDCanIngF, 15, 4, ".", "")));
         AssignAttri("", false, "A1433OrdDCanFacF", StringUtil.LTrim( StringUtil.NToC( A1433OrdDCanFacF, 15, 4, ".", "")));
         AssignAttri("", false, "A1446OrdDTotF", StringUtil.LTrim( StringUtil.NToC( A1446OrdDTotF, 15, 2, ".", "")));
         AssignAttri("", false, "A1445OrdDSubInafecto", StringUtil.LTrim( StringUtil.NToC( A1445OrdDSubInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1443OrdDSubAfecto", StringUtil.LTrim( StringUtil.NToC( A1443OrdDSubAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z289OrdCod", StringUtil.RTrim( Z289OrdCod));
         GxWebStd.gx_hidden_field( context, "Z295OrdDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z295OrdDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1431OrdDCan", StringUtil.LTrim( StringUtil.NToC( Z1431OrdDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1438OrdDPre", StringUtil.LTrim( StringUtil.NToC( Z1438OrdDPre, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1439OrdDDscto", StringUtil.LTrim( StringUtil.NToC( Z1439OrdDDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1434OrdDCanIng", StringUtil.LTrim( StringUtil.NToC( Z1434OrdDCanIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1432OrdDCanFac", StringUtil.LTrim( StringUtil.NToC( Z1432OrdDCanFac, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1441OrdDObs", Z1441OrdDObs);
         GxWebStd.gx_hidden_field( context, "Z1430OrdDBulto", StringUtil.LTrim( StringUtil.NToC( Z1430OrdDBulto, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1440OrdDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1440OrdDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1460OrdReqCod", Z1460OrdReqCod);
         GxWebStd.gx_hidden_field( context, "Z1447OrdDTotInc", StringUtil.LTrim( StringUtil.NToC( Z1447OrdDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1442OrdDPreInc", StringUtil.LTrim( StringUtil.NToC( Z1442OrdDPreInc, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1426OrdAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1426OrdAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1437OrdDSub", StringUtil.LTrim( StringUtil.NToC( Z1437OrdDSub, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1436OrdDDescuento", StringUtil.LTrim( StringUtil.NToC( Z1436OrdDDescuento, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1444OrdDTot", StringUtil.LTrim( StringUtil.NToC( Z1444OrdDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1435OrdDCanIngF", StringUtil.LTrim( StringUtil.NToC( Z1435OrdDCanIngF, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1433OrdDCanFacF", StringUtil.LTrim( StringUtil.NToC( Z1433OrdDCanFacF, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1446OrdDTotF", StringUtil.LTrim( StringUtil.NToC( Z1446OrdDTotF, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1445OrdDSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1445OrdDSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1443OrdDSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1443OrdDSubAfecto, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T003K17 */
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1440OrdDIna',fld:'ORDDINA',pic:'9'},{av:'A1460OrdReqCod',fld:'ORDREQCOD',pic:''},{av:'A1447OrdDTotInc',fld:'ORDDTOTINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1442OrdDPreInc',fld:'ORDDPREINC',pic:'ZZZZZ,ZZZ,ZZ9.999999'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_ORDCOD","{handler:'Valid_Ordcod',iparms:[{av:'A289OrdCod',fld:'ORDCOD',pic:''},{av:'A1426OrdAut',fld:'ORDAUT',pic:'9'}]");
         setEventMetadata("VALID_ORDCOD",",oparms:[{av:'A1426OrdAut',fld:'ORDAUT',pic:'9'}]}");
         setEventMetadata("VALID_ORDDITEM","{handler:'Valid_Ordditem',iparms:[{av:'A1442OrdDPreInc',fld:'ORDDPREINC',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A1447OrdDTotInc',fld:'ORDDTOTINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1460OrdReqCod',fld:'ORDREQCOD',pic:''},{av:'A1440OrdDIna',fld:'ORDDINA',pic:'9'},{av:'A289OrdCod',fld:'ORDCOD',pic:''},{av:'A295OrdDItem',fld:'ORDDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ORDDITEM",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A1431OrdDCan',fld:'ORDDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1438OrdDPre',fld:'ORDDPRE',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A1439OrdDDscto',fld:'ORDDDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1434OrdDCanIng',fld:'ORDDCANING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1432OrdDCanFac',fld:'ORDDCANFAC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1441OrdDObs',fld:'ORDDOBS',pic:''},{av:'A1430OrdDBulto',fld:'ORDDBULTO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1440OrdDIna',fld:'ORDDINA',pic:'9'},{av:'A1460OrdReqCod',fld:'ORDREQCOD',pic:''},{av:'A1447OrdDTotInc',fld:'ORDDTOTINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1442OrdDPreInc',fld:'ORDDPREINC',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A1426OrdAut',fld:'ORDAUT',pic:'9'},{av:'A1437OrdDSub',fld:'ORDDSUB',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1436OrdDDescuento',fld:'ORDDDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1444OrdDTot',fld:'ORDDTOT',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A1435OrdDCanIngF',fld:'ORDDCANINGF',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1433OrdDCanFacF',fld:'ORDDCANFACF',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1446OrdDTotF',fld:'ORDDTOTF',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1445OrdDSubInafecto',fld:'ORDDSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1443OrdDSubAfecto',fld:'ORDDSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z289OrdCod'},{av:'Z295OrdDItem'},{av:'Z28ProdCod'},{av:'Z1431OrdDCan'},{av:'Z1438OrdDPre'},{av:'Z1439OrdDDscto'},{av:'Z1434OrdDCanIng'},{av:'Z1432OrdDCanFac'},{av:'Z1441OrdDObs'},{av:'Z1430OrdDBulto'},{av:'Z1440OrdDIna'},{av:'Z1460OrdReqCod'},{av:'Z1447OrdDTotInc'},{av:'Z1442OrdDPreInc'},{av:'Z1426OrdAut'},{av:'Z1437OrdDSub'},{av:'Z1436OrdDDescuento'},{av:'Z1444OrdDTot'},{av:'Z1435OrdDCanIngF'},{av:'Z1433OrdDCanFacF'},{av:'Z1446OrdDTotF'},{av:'Z1445OrdDSubInafecto'},{av:'Z1443OrdDSubAfecto'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[]}");
         setEventMetadata("VALID_ORDDCAN","{handler:'Valid_Orddcan',iparms:[]");
         setEventMetadata("VALID_ORDDCAN",",oparms:[]}");
         setEventMetadata("VALID_ORDDPRE","{handler:'Valid_Orddpre',iparms:[]");
         setEventMetadata("VALID_ORDDPRE",",oparms:[]}");
         setEventMetadata("VALID_ORDDDSCTO","{handler:'Valid_Ordddscto',iparms:[]");
         setEventMetadata("VALID_ORDDDSCTO",",oparms:[]}");
         setEventMetadata("VALID_ORDDTOT","{handler:'Valid_Orddtot',iparms:[]");
         setEventMetadata("VALID_ORDDTOT",",oparms:[]}");
         setEventMetadata("VALID_ORDDCANING","{handler:'Valid_Orddcaning',iparms:[]");
         setEventMetadata("VALID_ORDDCANING",",oparms:[]}");
         setEventMetadata("VALID_ORDDCANFAC","{handler:'Valid_Orddcanfac',iparms:[]");
         setEventMetadata("VALID_ORDDCANFAC",",oparms:[]}");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z289OrdCod = "";
         Z1460OrdReqCod = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A289OrdCod = "";
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
         A1441OrdDObs = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1460OrdReqCod = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1441OrdDObs = "";
         T003K6_A1444OrdDTot = new decimal[1] ;
         T003K6_A295OrdDItem = new int[1] ;
         T003K6_A1431OrdDCan = new decimal[1] ;
         T003K6_A1438OrdDPre = new decimal[1] ;
         T003K6_A1439OrdDDscto = new decimal[1] ;
         T003K6_A1434OrdDCanIng = new decimal[1] ;
         T003K6_A1432OrdDCanFac = new decimal[1] ;
         T003K6_A1441OrdDObs = new string[] {""} ;
         T003K6_A1426OrdAut = new short[1] ;
         T003K6_A1430OrdDBulto = new decimal[1] ;
         T003K6_A1440OrdDIna = new short[1] ;
         T003K6_A1460OrdReqCod = new string[] {""} ;
         T003K6_A1447OrdDTotInc = new decimal[1] ;
         T003K6_A1442OrdDPreInc = new decimal[1] ;
         T003K6_A289OrdCod = new string[] {""} ;
         T003K6_A28ProdCod = new string[] {""} ;
         T003K4_A1426OrdAut = new short[1] ;
         T003K5_A28ProdCod = new string[] {""} ;
         T003K7_A1426OrdAut = new short[1] ;
         T003K8_A28ProdCod = new string[] {""} ;
         T003K9_A289OrdCod = new string[] {""} ;
         T003K9_A295OrdDItem = new int[1] ;
         T003K3_A1444OrdDTot = new decimal[1] ;
         T003K3_A295OrdDItem = new int[1] ;
         T003K3_A1431OrdDCan = new decimal[1] ;
         T003K3_A1438OrdDPre = new decimal[1] ;
         T003K3_A1439OrdDDscto = new decimal[1] ;
         T003K3_A1434OrdDCanIng = new decimal[1] ;
         T003K3_A1432OrdDCanFac = new decimal[1] ;
         T003K3_A1441OrdDObs = new string[] {""} ;
         T003K3_A1430OrdDBulto = new decimal[1] ;
         T003K3_A1440OrdDIna = new short[1] ;
         T003K3_A1460OrdReqCod = new string[] {""} ;
         T003K3_A1447OrdDTotInc = new decimal[1] ;
         T003K3_A1442OrdDPreInc = new decimal[1] ;
         T003K3_A289OrdCod = new string[] {""} ;
         T003K3_A28ProdCod = new string[] {""} ;
         sMode123 = "";
         T003K10_A289OrdCod = new string[] {""} ;
         T003K10_A295OrdDItem = new int[1] ;
         T003K11_A289OrdCod = new string[] {""} ;
         T003K11_A295OrdDItem = new int[1] ;
         T003K2_A1444OrdDTot = new decimal[1] ;
         T003K2_A295OrdDItem = new int[1] ;
         T003K2_A1431OrdDCan = new decimal[1] ;
         T003K2_A1438OrdDPre = new decimal[1] ;
         T003K2_A1439OrdDDscto = new decimal[1] ;
         T003K2_A1434OrdDCanIng = new decimal[1] ;
         T003K2_A1432OrdDCanFac = new decimal[1] ;
         T003K2_A1441OrdDObs = new string[] {""} ;
         T003K2_A1430OrdDBulto = new decimal[1] ;
         T003K2_A1440OrdDIna = new short[1] ;
         T003K2_A1460OrdReqCod = new string[] {""} ;
         T003K2_A1447OrdDTotInc = new decimal[1] ;
         T003K2_A1442OrdDPreInc = new decimal[1] ;
         T003K2_A289OrdCod = new string[] {""} ;
         T003K2_A28ProdCod = new string[] {""} ;
         T003K15_A1426OrdAut = new short[1] ;
         T003K16_A289OrdCod = new string[] {""} ;
         T003K16_A295OrdDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ289OrdCod = "";
         ZZ28ProdCod = "";
         ZZ1441OrdDObs = "";
         ZZ1460OrdReqCod = "";
         T003K17_A28ProdCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpordendet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpordendet__default(),
            new Object[][] {
                new Object[] {
               T003K2_A1444OrdDTot, T003K2_A295OrdDItem, T003K2_A1431OrdDCan, T003K2_A1438OrdDPre, T003K2_A1439OrdDDscto, T003K2_A1434OrdDCanIng, T003K2_A1432OrdDCanFac, T003K2_A1441OrdDObs, T003K2_A1430OrdDBulto, T003K2_A1440OrdDIna,
               T003K2_A1460OrdReqCod, T003K2_A1447OrdDTotInc, T003K2_A1442OrdDPreInc, T003K2_A289OrdCod, T003K2_A28ProdCod
               }
               , new Object[] {
               T003K3_A1444OrdDTot, T003K3_A295OrdDItem, T003K3_A1431OrdDCan, T003K3_A1438OrdDPre, T003K3_A1439OrdDDscto, T003K3_A1434OrdDCanIng, T003K3_A1432OrdDCanFac, T003K3_A1441OrdDObs, T003K3_A1430OrdDBulto, T003K3_A1440OrdDIna,
               T003K3_A1460OrdReqCod, T003K3_A1447OrdDTotInc, T003K3_A1442OrdDPreInc, T003K3_A289OrdCod, T003K3_A28ProdCod
               }
               , new Object[] {
               T003K4_A1426OrdAut
               }
               , new Object[] {
               T003K5_A28ProdCod
               }
               , new Object[] {
               T003K6_A1444OrdDTot, T003K6_A295OrdDItem, T003K6_A1431OrdDCan, T003K6_A1438OrdDPre, T003K6_A1439OrdDDscto, T003K6_A1434OrdDCanIng, T003K6_A1432OrdDCanFac, T003K6_A1441OrdDObs, T003K6_A1426OrdAut, T003K6_A1430OrdDBulto,
               T003K6_A1440OrdDIna, T003K6_A1460OrdReqCod, T003K6_A1447OrdDTotInc, T003K6_A1442OrdDPreInc, T003K6_A289OrdCod, T003K6_A28ProdCod
               }
               , new Object[] {
               T003K7_A1426OrdAut
               }
               , new Object[] {
               T003K8_A28ProdCod
               }
               , new Object[] {
               T003K9_A289OrdCod, T003K9_A295OrdDItem
               }
               , new Object[] {
               T003K10_A289OrdCod, T003K10_A295OrdDItem
               }
               , new Object[] {
               T003K11_A289OrdCod, T003K11_A295OrdDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003K15_A1426OrdAut
               }
               , new Object[] {
               T003K16_A289OrdCod, T003K16_A295OrdDItem
               }
               , new Object[] {
               T003K17_A28ProdCod
               }
            }
         );
      }

      private short Z1440OrdDIna ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1426OrdAut ;
      private short A1440OrdDIna ;
      private short GX_JID ;
      private short Z1426OrdAut ;
      private short RcdFound123 ;
      private short nIsDirty_123 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1440OrdDIna ;
      private short ZZ1426OrdAut ;
      private int Z295OrdDItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtOrdCod_Enabled ;
      private int A295OrdDItem ;
      private int edtOrdDItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtOrdDCan_Enabled ;
      private int edtOrdDPre_Enabled ;
      private int edtOrdDDscto_Enabled ;
      private int edtOrdDTot_Enabled ;
      private int edtOrdDCanIng_Enabled ;
      private int edtOrdDCanFac_Enabled ;
      private int edtOrdDObs_Enabled ;
      private int edtOrdAut_Enabled ;
      private int edtOrdDBulto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ295OrdDItem ;
      private decimal Z1444OrdDTot ;
      private decimal Z1431OrdDCan ;
      private decimal Z1438OrdDPre ;
      private decimal Z1439OrdDDscto ;
      private decimal Z1434OrdDCanIng ;
      private decimal Z1432OrdDCanFac ;
      private decimal Z1430OrdDBulto ;
      private decimal Z1447OrdDTotInc ;
      private decimal Z1442OrdDPreInc ;
      private decimal A1431OrdDCan ;
      private decimal A1438OrdDPre ;
      private decimal A1439OrdDDscto ;
      private decimal A1444OrdDTot ;
      private decimal A1434OrdDCanIng ;
      private decimal A1432OrdDCanFac ;
      private decimal A1430OrdDBulto ;
      private decimal A1447OrdDTotInc ;
      private decimal A1442OrdDPreInc ;
      private decimal A1436OrdDDescuento ;
      private decimal A1437OrdDSub ;
      private decimal A1435OrdDCanIngF ;
      private decimal A1433OrdDCanFacF ;
      private decimal A1446OrdDTotF ;
      private decimal A1445OrdDSubInafecto ;
      private decimal A1443OrdDSubAfecto ;
      private decimal Z1437OrdDSub ;
      private decimal Z1436OrdDDescuento ;
      private decimal Z1435OrdDCanIngF ;
      private decimal Z1433OrdDCanFacF ;
      private decimal Z1446OrdDTotF ;
      private decimal Z1445OrdDSubInafecto ;
      private decimal Z1443OrdDSubAfecto ;
      private decimal ZZ1431OrdDCan ;
      private decimal ZZ1438OrdDPre ;
      private decimal ZZ1439OrdDDscto ;
      private decimal ZZ1434OrdDCanIng ;
      private decimal ZZ1432OrdDCanFac ;
      private decimal ZZ1430OrdDBulto ;
      private decimal ZZ1447OrdDTotInc ;
      private decimal ZZ1442OrdDPreInc ;
      private decimal ZZ1437OrdDSub ;
      private decimal ZZ1436OrdDDescuento ;
      private decimal ZZ1444OrdDTot ;
      private decimal ZZ1435OrdDCanIngF ;
      private decimal ZZ1433OrdDCanFacF ;
      private decimal ZZ1446OrdDTotF ;
      private decimal ZZ1445OrdDSubInafecto ;
      private decimal ZZ1443OrdDSubAfecto ;
      private string sPrefix ;
      private string Z289OrdCod ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A289OrdCod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOrdCod_Internalname ;
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
      private string edtOrdCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtOrdDItem_Internalname ;
      private string edtOrdDItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtOrdDCan_Internalname ;
      private string edtOrdDCan_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtOrdDPre_Internalname ;
      private string edtOrdDPre_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtOrdDDscto_Internalname ;
      private string edtOrdDDscto_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtOrdDTot_Internalname ;
      private string edtOrdDTot_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtOrdDCanIng_Internalname ;
      private string edtOrdDCanIng_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtOrdDCanFac_Internalname ;
      private string edtOrdDCanFac_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtOrdDObs_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtOrdAut_Internalname ;
      private string edtOrdAut_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtOrdDBulto_Internalname ;
      private string edtOrdDBulto_Jsonclick ;
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
      private string sMode123 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ289OrdCod ;
      private string ZZ28ProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A1441OrdDObs ;
      private string Z1441OrdDObs ;
      private string ZZ1441OrdDObs ;
      private string Z1460OrdReqCod ;
      private string A1460OrdReqCod ;
      private string ZZ1460OrdReqCod ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T003K6_A1444OrdDTot ;
      private int[] T003K6_A295OrdDItem ;
      private decimal[] T003K6_A1431OrdDCan ;
      private decimal[] T003K6_A1438OrdDPre ;
      private decimal[] T003K6_A1439OrdDDscto ;
      private decimal[] T003K6_A1434OrdDCanIng ;
      private decimal[] T003K6_A1432OrdDCanFac ;
      private string[] T003K6_A1441OrdDObs ;
      private short[] T003K6_A1426OrdAut ;
      private decimal[] T003K6_A1430OrdDBulto ;
      private short[] T003K6_A1440OrdDIna ;
      private string[] T003K6_A1460OrdReqCod ;
      private decimal[] T003K6_A1447OrdDTotInc ;
      private decimal[] T003K6_A1442OrdDPreInc ;
      private string[] T003K6_A289OrdCod ;
      private string[] T003K6_A28ProdCod ;
      private short[] T003K4_A1426OrdAut ;
      private string[] T003K5_A28ProdCod ;
      private short[] T003K7_A1426OrdAut ;
      private string[] T003K8_A28ProdCod ;
      private string[] T003K9_A289OrdCod ;
      private int[] T003K9_A295OrdDItem ;
      private decimal[] T003K3_A1444OrdDTot ;
      private int[] T003K3_A295OrdDItem ;
      private decimal[] T003K3_A1431OrdDCan ;
      private decimal[] T003K3_A1438OrdDPre ;
      private decimal[] T003K3_A1439OrdDDscto ;
      private decimal[] T003K3_A1434OrdDCanIng ;
      private decimal[] T003K3_A1432OrdDCanFac ;
      private string[] T003K3_A1441OrdDObs ;
      private decimal[] T003K3_A1430OrdDBulto ;
      private short[] T003K3_A1440OrdDIna ;
      private string[] T003K3_A1460OrdReqCod ;
      private decimal[] T003K3_A1447OrdDTotInc ;
      private decimal[] T003K3_A1442OrdDPreInc ;
      private string[] T003K3_A289OrdCod ;
      private string[] T003K3_A28ProdCod ;
      private string[] T003K10_A289OrdCod ;
      private int[] T003K10_A295OrdDItem ;
      private string[] T003K11_A289OrdCod ;
      private int[] T003K11_A295OrdDItem ;
      private decimal[] T003K2_A1444OrdDTot ;
      private int[] T003K2_A295OrdDItem ;
      private decimal[] T003K2_A1431OrdDCan ;
      private decimal[] T003K2_A1438OrdDPre ;
      private decimal[] T003K2_A1439OrdDDscto ;
      private decimal[] T003K2_A1434OrdDCanIng ;
      private decimal[] T003K2_A1432OrdDCanFac ;
      private string[] T003K2_A1441OrdDObs ;
      private decimal[] T003K2_A1430OrdDBulto ;
      private short[] T003K2_A1440OrdDIna ;
      private string[] T003K2_A1460OrdReqCod ;
      private decimal[] T003K2_A1447OrdDTotInc ;
      private decimal[] T003K2_A1442OrdDPreInc ;
      private string[] T003K2_A289OrdCod ;
      private string[] T003K2_A28ProdCod ;
      private short[] T003K15_A1426OrdAut ;
      private string[] T003K16_A289OrdCod ;
      private int[] T003K16_A295OrdDItem ;
      private string[] T003K17_A28ProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpordendet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpordendet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003K6;
        prmT003K6 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K4;
        prmT003K4 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003K5;
        prmT003K5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003K7;
        prmT003K7 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003K8;
        prmT003K8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003K9;
        prmT003K9 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K3;
        prmT003K3 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K10;
        prmT003K10 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K11;
        prmT003K11 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K2;
        prmT003K2 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K12;
        prmT003K12 = new Object[] {
        new ParDef("@OrdDTot",GXType.Decimal,18,8) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0) ,
        new ParDef("@OrdDCan",GXType.Decimal,15,4) ,
        new ParDef("@OrdDPre",GXType.Decimal,18,6) ,
        new ParDef("@OrdDDscto",GXType.Decimal,15,2) ,
        new ParDef("@OrdDCanIng",GXType.Decimal,15,4) ,
        new ParDef("@OrdDCanFac",GXType.Decimal,15,4) ,
        new ParDef("@OrdDObs",GXType.NVarChar,1000,0) ,
        new ParDef("@OrdDBulto",GXType.Decimal,15,4) ,
        new ParDef("@OrdDIna",GXType.Int16,1,0) ,
        new ParDef("@OrdReqCod",GXType.NVarChar,10,0) ,
        new ParDef("@OrdDTotInc",GXType.Decimal,15,4) ,
        new ParDef("@OrdDPreInc",GXType.Decimal,18,6) ,
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003K13;
        prmT003K13 = new Object[] {
        new ParDef("@OrdDTot",GXType.Decimal,18,8) ,
        new ParDef("@OrdDCan",GXType.Decimal,15,4) ,
        new ParDef("@OrdDPre",GXType.Decimal,18,6) ,
        new ParDef("@OrdDDscto",GXType.Decimal,15,2) ,
        new ParDef("@OrdDCanIng",GXType.Decimal,15,4) ,
        new ParDef("@OrdDCanFac",GXType.Decimal,15,4) ,
        new ParDef("@OrdDObs",GXType.NVarChar,1000,0) ,
        new ParDef("@OrdDBulto",GXType.Decimal,15,4) ,
        new ParDef("@OrdDIna",GXType.Int16,1,0) ,
        new ParDef("@OrdReqCod",GXType.NVarChar,10,0) ,
        new ParDef("@OrdDTotInc",GXType.Decimal,15,4) ,
        new ParDef("@OrdDPreInc",GXType.Decimal,18,6) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K14;
        prmT003K14 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdDItem",GXType.Int32,6,0)
        };
        Object[] prmT003K16;
        prmT003K16 = new Object[] {
        };
        Object[] prmT003K15;
        prmT003K15 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003K17;
        prmT003K17 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003K2", "SELECT [OrdDTot], [OrdDItem], [OrdDCan], [OrdDPre], [OrdDDscto], [OrdDCanIng], [OrdDCanFac], [OrdDObs], [OrdDBulto], [OrdDIna], [OrdReqCod], [OrdDTotInc], [OrdDPreInc], [OrdCod], [ProdCod] FROM [CPORDENDET] WITH (UPDLOCK) WHERE [OrdCod] = @OrdCod AND [OrdDItem] = @OrdDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K3", "SELECT [OrdDTot], [OrdDItem], [OrdDCan], [OrdDPre], [OrdDDscto], [OrdDCanIng], [OrdDCanFac], [OrdDObs], [OrdDBulto], [OrdDIna], [OrdReqCod], [OrdDTotInc], [OrdDPreInc], [OrdCod], [ProdCod] FROM [CPORDENDET] WHERE [OrdCod] = @OrdCod AND [OrdDItem] = @OrdDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K4", "SELECT [OrdAut] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K5", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K6", "SELECT TM1.[OrdDTot], TM1.[OrdDItem], TM1.[OrdDCan], TM1.[OrdDPre], TM1.[OrdDDscto], TM1.[OrdDCanIng], TM1.[OrdDCanFac], TM1.[OrdDObs], T2.[OrdAut], TM1.[OrdDBulto], TM1.[OrdDIna], TM1.[OrdReqCod], TM1.[OrdDTotInc], TM1.[OrdDPreInc], TM1.[OrdCod], TM1.[ProdCod] FROM ([CPORDENDET] TM1 INNER JOIN [CPORDEN] T2 ON T2.[OrdCod] = TM1.[OrdCod]) WHERE TM1.[OrdCod] = @OrdCod and TM1.[OrdDItem] = @OrdDItem ORDER BY TM1.[OrdCod], TM1.[OrdDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003K6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K7", "SELECT [OrdAut] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K8", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K9", "SELECT [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE [OrdCod] = @OrdCod AND [OrdDItem] = @OrdDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003K9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K10", "SELECT TOP 1 [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE ( [OrdCod] > @OrdCod or [OrdCod] = @OrdCod and [OrdDItem] > @OrdDItem) ORDER BY [OrdCod], [OrdDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003K10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003K11", "SELECT TOP 1 [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE ( [OrdCod] < @OrdCod or [OrdCod] = @OrdCod and [OrdDItem] < @OrdDItem) ORDER BY [OrdCod] DESC, [OrdDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003K11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003K12", "INSERT INTO [CPORDENDET]([OrdDTot], [OrdDItem], [OrdDCan], [OrdDPre], [OrdDDscto], [OrdDCanIng], [OrdDCanFac], [OrdDObs], [OrdDBulto], [OrdDIna], [OrdReqCod], [OrdDTotInc], [OrdDPreInc], [OrdCod], [ProdCod]) VALUES(@OrdDTot, @OrdDItem, @OrdDCan, @OrdDPre, @OrdDDscto, @OrdDCanIng, @OrdDCanFac, @OrdDObs, @OrdDBulto, @OrdDIna, @OrdReqCod, @OrdDTotInc, @OrdDPreInc, @OrdCod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT003K12)
           ,new CursorDef("T003K13", "UPDATE [CPORDENDET] SET [OrdDTot]=@OrdDTot, [OrdDCan]=@OrdDCan, [OrdDPre]=@OrdDPre, [OrdDDscto]=@OrdDDscto, [OrdDCanIng]=@OrdDCanIng, [OrdDCanFac]=@OrdDCanFac, [OrdDObs]=@OrdDObs, [OrdDBulto]=@OrdDBulto, [OrdDIna]=@OrdDIna, [OrdReqCod]=@OrdReqCod, [OrdDTotInc]=@OrdDTotInc, [OrdDPreInc]=@OrdDPreInc, [ProdCod]=@ProdCod  WHERE [OrdCod] = @OrdCod AND [OrdDItem] = @OrdDItem", GxErrorMask.GX_NOMASK,prmT003K13)
           ,new CursorDef("T003K14", "DELETE FROM [CPORDENDET]  WHERE [OrdCod] = @OrdCod AND [OrdDItem] = @OrdDItem", GxErrorMask.GX_NOMASK,prmT003K14)
           ,new CursorDef("T003K15", "SELECT [OrdAut] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K16", "SELECT [OrdCod], [OrdDItem] FROM [CPORDENDET] ORDER BY [OrdCod], [OrdDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003K16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003K17", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003K17,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((string[]) buf[14])[0] = rslt.getString(15, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((string[]) buf[14])[0] = rslt.getString(15, 15);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
