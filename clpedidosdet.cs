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
   public class clpedidosdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A210PedCod = GetPar( "PedCod");
            AssignAttri("", false, "A210PedCod", A210PedCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A210PedCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A28ProdCod) ;
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
            Form.Meta.addItem("description", "Pedidos - Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clpedidosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpedidosdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLPEDIDOSDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pedido", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedCod_Internalname, StringUtil.RTrim( A210PedCod), StringUtil.RTrim( context.localUtil.Format( A210PedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "ITem", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A216PedDItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtPedDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A216PedDItem), "ZZZ9") : context.localUtil.Format( (decimal)(A216PedDItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cantidad", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDCan_Internalname, StringUtil.LTrim( StringUtil.NToC( A1554PedDCan, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDCan_Enabled!=0) ? context.localUtil.Format( A1554PedDCan, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1554PedDCan, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDCan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDCan_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Precio", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDPre_Internalname, StringUtil.LTrim( StringUtil.NToC( A1553PedDPre, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDPre_Enabled!=0) ? context.localUtil.Format( A1553PedDPre, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1553PedDPre, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDPre_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Precio Inc.", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDPreInc_Internalname, StringUtil.LTrim( StringUtil.NToC( A1574PedDPreInc, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDPreInc_Enabled!=0) ? context.localUtil.Format( A1574PedDPreInc, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1574PedDPreInc, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDPreInc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDPreInc_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "% Descuento 1", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDDct_Internalname, StringUtil.LTrim( StringUtil.NToC( A1555PedDDct, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDDct_Enabled!=0) ? context.localUtil.Format( A1555PedDDct, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1555PedDDct, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDDct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDDct_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "% Descuento 2", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDDct2_Internalname, StringUtil.LTrim( StringUtil.NToC( A1556PedDDct2, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDDct2_Enabled!=0) ? context.localUtil.Format( A1556PedDDct2, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1556PedDDct2, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDDct2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDDct2_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Despachado", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDCanDSP_Internalname, StringUtil.LTrim( StringUtil.NToC( A1558PedDCanDSP, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDCanDSP_Enabled!=0) ? context.localUtil.Format( A1558PedDCanDSP, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1558PedDCanDSP, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDCanDSP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDCanDSP_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Facturado", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDCanFAC_Internalname, StringUtil.LTrim( StringUtil.NToC( A1559PedDCanFAC, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDCanFAC_Enabled!=0) ? context.localUtil.Format( A1559PedDCanFAC, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1559PedDCanFAC, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDCanFAC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDCanFAC_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Cantidad Pendiente", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDCanPendiente_Internalname, StringUtil.LTrim( StringUtil.NToC( A1560PedDCanPendiente, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDCanPendiente_Enabled!=0) ? context.localUtil.Format( A1560PedDCanPendiente, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1560PedDCanPendiente, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDCanPendiente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDCanPendiente_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Descripcion producto", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Inafecta IGV", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDIna_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1557PedDIna), 1, 0, ".", "")), StringUtil.LTrim( ((edtPedDIna_Enabled!=0) ? context.localUtil.Format( (decimal)(A1557PedDIna), "9") : context.localUtil.Format( (decimal)(A1557PedDIna), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDIna_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "% Impuesto Selectivo", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDPorSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A1573PedDPorSel, 5, 2, ".", "")), StringUtil.LTrim( ((edtPedDPorSel_Enabled!=0) ? context.localUtil.Format( A1573PedDPorSel, "Z9.99") : context.localUtil.Format( A1573PedDPorSel, "Z9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDPorSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDPorSel_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Referencia 1", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDRef1_Internalname, StringUtil.RTrim( A1575PedDRef1), StringUtil.RTrim( context.localUtil.Format( A1575PedDRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Referencia 2", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDRef2_Internalname, StringUtil.RTrim( A1576PedDRef2), StringUtil.RTrim( context.localUtil.Format( A1576PedDRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Referencia 3", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDRef3_Internalname, StringUtil.RTrim( A1577PedDRef3), StringUtil.RTrim( context.localUtil.Format( A1577PedDRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Referencia 4", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDRef4_Internalname, StringUtil.RTrim( A1578PedDRef4), StringUtil.RTrim( context.localUtil.Format( A1578PedDRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Referencia 5", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDRef5_Internalname, StringUtil.RTrim( A1579PedDRef5), StringUtil.RTrim( context.localUtil.Format( A1579PedDRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDRef5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Observaciones", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPedDObs_Internalname, A1572PedDObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", 0, 1, edtPedDObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Cantidad a Despachar", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDDespachar_Internalname, StringUtil.LTrim( StringUtil.NToC( A1562PedDDespachar, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDDespachar_Enabled!=0) ? context.localUtil.Format( A1562PedDDespachar, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1562PedDDespachar, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDDespachar_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDDespachar_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Inafecto", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1567PedDInafecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDInafecto_Enabled!=0) ? context.localUtil.Format( A1567PedDInafecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1567PedDInafecto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDInafecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Afecto", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1550PedDAfecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDAfecto_Enabled!=0) ? context.localUtil.Format( A1550PedDAfecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1550PedDAfecto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDAfecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Detalle Selectivo", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDSelectivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1585PedDSelectivo, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDSelectivo_Enabled!=0) ? context.localUtil.Format( A1585PedDSelectivo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1585PedDSelectivo, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDSelectivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDSelectivo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Sub Total Item", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDSub_Internalname, StringUtil.LTrim( StringUtil.NToC( A1552PedDSub, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDSub_Enabled!=0) ? context.localUtil.Format( A1552PedDSub, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1552PedDSub, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDSub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDSub_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Total", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1551PedDTot, 18, 8, ".", "")), StringUtil.LTrim( ((edtPedDTot_Enabled!=0) ? context.localUtil.Format( A1551PedDTot, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1551PedDTot, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDTot_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Descuento", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDDcto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1561PedDDcto, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDDcto_Enabled!=0) ? context.localUtil.Format( A1561PedDDcto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1561PedDDcto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDDcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDDcto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLPEDIDOSDET.htm");
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
            Z210PedCod = cgiGet( "Z210PedCod");
            Z216PedDItem = (short)(context.localUtil.CToN( cgiGet( "Z216PedDItem"), ".", ","));
            Z1551PedDTot = context.localUtil.CToN( cgiGet( "Z1551PedDTot"), ".", ",");
            Z1592PedDTotInc = context.localUtil.CToN( cgiGet( "Z1592PedDTotInc"), ".", ",");
            Z1566PedDICBPER = context.localUtil.CToN( cgiGet( "Z1566PedDICBPER"), ".", ",");
            Z1554PedDCan = context.localUtil.CToN( cgiGet( "Z1554PedDCan"), ".", ",");
            Z1553PedDPre = context.localUtil.CToN( cgiGet( "Z1553PedDPre"), ".", ",");
            Z1574PedDPreInc = context.localUtil.CToN( cgiGet( "Z1574PedDPreInc"), ".", ",");
            Z1555PedDDct = context.localUtil.CToN( cgiGet( "Z1555PedDDct"), ".", ",");
            Z1556PedDDct2 = context.localUtil.CToN( cgiGet( "Z1556PedDDct2"), ".", ",");
            Z1558PedDCanDSP = context.localUtil.CToN( cgiGet( "Z1558PedDCanDSP"), ".", ",");
            Z1559PedDCanFAC = context.localUtil.CToN( cgiGet( "Z1559PedDCanFAC"), ".", ",");
            Z1557PedDIna = (short)(context.localUtil.CToN( cgiGet( "Z1557PedDIna"), ".", ","));
            Z1573PedDPorSel = context.localUtil.CToN( cgiGet( "Z1573PedDPorSel"), ".", ",");
            Z1575PedDRef1 = cgiGet( "Z1575PedDRef1");
            Z1576PedDRef2 = cgiGet( "Z1576PedDRef2");
            Z1577PedDRef3 = cgiGet( "Z1577PedDRef3");
            Z1578PedDRef4 = cgiGet( "Z1578PedDRef4");
            Z1579PedDRef5 = cgiGet( "Z1579PedDRef5");
            Z1587PedDValSel = context.localUtil.CToN( cgiGet( "Z1587PedDValSel"), ".", ",");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z1598PedICBPER = context.localUtil.CToN( cgiGet( "Z1598PedICBPER"), ".", ",");
            Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            A1592PedDTotInc = context.localUtil.CToN( cgiGet( "Z1592PedDTotInc"), ".", ",");
            A1566PedDICBPER = context.localUtil.CToN( cgiGet( "Z1566PedDICBPER"), ".", ",");
            A1587PedDValSel = context.localUtil.CToN( cgiGet( "Z1587PedDValSel"), ".", ",");
            A1598PedICBPER = context.localUtil.CToN( cgiGet( "Z1598PedICBPER"), ".", ",");
            n1598PedICBPER = false;
            A180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1591PedDSubInc = context.localUtil.CToN( cgiGet( "PEDDSUBINC"), ".", ",");
            A1587PedDValSel = context.localUtil.CToN( cgiGet( "PEDDVALSEL"), ".", ",");
            A1586PedDSelectivoValor = context.localUtil.CToN( cgiGet( "PEDDSELECTIVOVALOR"), ".", ",");
            A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "PRODAFECICBPER"), ".", ","));
            A180MonCod = (int)(context.localUtil.CToN( cgiGet( "MONCOD"), ".", ","));
            A907ProdValICBPER = context.localUtil.CToN( cgiGet( "PRODVALICBPER"), ".", ",");
            A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "PRODVALICBPERD"), ".", ",");
            A1566PedDICBPER = context.localUtil.CToN( cgiGet( "PEDDICBPER"), ".", ",");
            A1592PedDTotInc = context.localUtil.CToN( cgiGet( "PEDDTOTINC"), ".", ",");
            A1565PedDGratuito = context.localUtil.CToN( cgiGet( "PEDDGRATUITO"), ".", ",");
            A1564PedDExonerado = context.localUtil.CToN( cgiGet( "PEDDEXONERADO"), ".", ",");
            A1563PedDExonerada = context.localUtil.CToN( cgiGet( "PEDDEXONERADA"), ".", ",");
            A1588PedDSelectivoPor = context.localUtil.CToN( cgiGet( "PEDDSELECTIVOPOR"), ".", ",");
            A1598PedICBPER = context.localUtil.CToN( cgiGet( "PEDICBPER"), ".", ",");
            /* Read variables values. */
            A210PedCod = cgiGet( edtPedCod_Internalname);
            AssignAttri("", false, "A210PedCod", A210PedCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDITEM");
               AnyError = 1;
               GX_FocusControl = edtPedDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A216PedDItem = 0;
               AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
            }
            else
            {
               A216PedDItem = (short)(context.localUtil.CToN( cgiGet( edtPedDItem_Internalname), ".", ","));
               AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDCan_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDCan_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDCAN");
               AnyError = 1;
               GX_FocusControl = edtPedDCan_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1554PedDCan = 0;
               AssignAttri("", false, "A1554PedDCan", StringUtil.LTrimStr( A1554PedDCan, 15, 4));
            }
            else
            {
               A1554PedDCan = context.localUtil.CToN( cgiGet( edtPedDCan_Internalname), ".", ",");
               AssignAttri("", false, "A1554PedDCan", StringUtil.LTrimStr( A1554PedDCan, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDPre_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDPre_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDPRE");
               AnyError = 1;
               GX_FocusControl = edtPedDPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1553PedDPre = 0;
               AssignAttri("", false, "A1553PedDPre", StringUtil.LTrimStr( A1553PedDPre, 15, 4));
            }
            else
            {
               A1553PedDPre = context.localUtil.CToN( cgiGet( edtPedDPre_Internalname), ".", ",");
               AssignAttri("", false, "A1553PedDPre", StringUtil.LTrimStr( A1553PedDPre, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDPreInc_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDPreInc_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDPREINC");
               AnyError = 1;
               GX_FocusControl = edtPedDPreInc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1574PedDPreInc = 0;
               AssignAttri("", false, "A1574PedDPreInc", StringUtil.LTrimStr( A1574PedDPreInc, 15, 4));
            }
            else
            {
               A1574PedDPreInc = context.localUtil.CToN( cgiGet( edtPedDPreInc_Internalname), ".", ",");
               AssignAttri("", false, "A1574PedDPreInc", StringUtil.LTrimStr( A1574PedDPreInc, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDDct_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDDct_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDDCT");
               AnyError = 1;
               GX_FocusControl = edtPedDDct_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1555PedDDct = 0;
               AssignAttri("", false, "A1555PedDDct", StringUtil.LTrimStr( A1555PedDDct, 15, 2));
            }
            else
            {
               A1555PedDDct = context.localUtil.CToN( cgiGet( edtPedDDct_Internalname), ".", ",");
               AssignAttri("", false, "A1555PedDDct", StringUtil.LTrimStr( A1555PedDDct, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDDct2_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDDct2_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDDCT2");
               AnyError = 1;
               GX_FocusControl = edtPedDDct2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1556PedDDct2 = 0;
               AssignAttri("", false, "A1556PedDDct2", StringUtil.LTrimStr( A1556PedDDct2, 15, 2));
            }
            else
            {
               A1556PedDDct2 = context.localUtil.CToN( cgiGet( edtPedDDct2_Internalname), ".", ",");
               AssignAttri("", false, "A1556PedDDct2", StringUtil.LTrimStr( A1556PedDDct2, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDCanDSP_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDCanDSP_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDCANDSP");
               AnyError = 1;
               GX_FocusControl = edtPedDCanDSP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1558PedDCanDSP = 0;
               AssignAttri("", false, "A1558PedDCanDSP", StringUtil.LTrimStr( A1558PedDCanDSP, 15, 4));
            }
            else
            {
               A1558PedDCanDSP = context.localUtil.CToN( cgiGet( edtPedDCanDSP_Internalname), ".", ",");
               AssignAttri("", false, "A1558PedDCanDSP", StringUtil.LTrimStr( A1558PedDCanDSP, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDCanFAC_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDCanFAC_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDCANFAC");
               AnyError = 1;
               GX_FocusControl = edtPedDCanFAC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1559PedDCanFAC = 0;
               AssignAttri("", false, "A1559PedDCanFAC", StringUtil.LTrimStr( A1559PedDCanFAC, 15, 4));
            }
            else
            {
               A1559PedDCanFAC = context.localUtil.CToN( cgiGet( edtPedDCanFAC_Internalname), ".", ",");
               AssignAttri("", false, "A1559PedDCanFAC", StringUtil.LTrimStr( A1559PedDCanFAC, 15, 4));
            }
            A1560PedDCanPendiente = context.localUtil.CToN( cgiGet( edtPedDCanPendiente_Internalname), ".", ",");
            AssignAttri("", false, "A1560PedDCanPendiente", StringUtil.LTrimStr( A1560PedDCanPendiente, 15, 4));
            A55ProdDsc = cgiGet( edtProdDsc_Internalname);
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDIna_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDIna_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDINA");
               AnyError = 1;
               GX_FocusControl = edtPedDIna_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1557PedDIna = 0;
               AssignAttri("", false, "A1557PedDIna", StringUtil.Str( (decimal)(A1557PedDIna), 1, 0));
            }
            else
            {
               A1557PedDIna = (short)(context.localUtil.CToN( cgiGet( edtPedDIna_Internalname), ".", ","));
               AssignAttri("", false, "A1557PedDIna", StringUtil.Str( (decimal)(A1557PedDIna), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDPorSel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDPorSel_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDPORSEL");
               AnyError = 1;
               GX_FocusControl = edtPedDPorSel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1573PedDPorSel = 0;
               AssignAttri("", false, "A1573PedDPorSel", StringUtil.LTrimStr( A1573PedDPorSel, 5, 2));
            }
            else
            {
               A1573PedDPorSel = context.localUtil.CToN( cgiGet( edtPedDPorSel_Internalname), ".", ",");
               AssignAttri("", false, "A1573PedDPorSel", StringUtil.LTrimStr( A1573PedDPorSel, 5, 2));
            }
            A1575PedDRef1 = cgiGet( edtPedDRef1_Internalname);
            AssignAttri("", false, "A1575PedDRef1", A1575PedDRef1);
            A1576PedDRef2 = cgiGet( edtPedDRef2_Internalname);
            AssignAttri("", false, "A1576PedDRef2", A1576PedDRef2);
            A1577PedDRef3 = cgiGet( edtPedDRef3_Internalname);
            AssignAttri("", false, "A1577PedDRef3", A1577PedDRef3);
            A1578PedDRef4 = cgiGet( edtPedDRef4_Internalname);
            AssignAttri("", false, "A1578PedDRef4", A1578PedDRef4);
            A1579PedDRef5 = cgiGet( edtPedDRef5_Internalname);
            AssignAttri("", false, "A1579PedDRef5", A1579PedDRef5);
            A1572PedDObs = cgiGet( edtPedDObs_Internalname);
            AssignAttri("", false, "A1572PedDObs", A1572PedDObs);
            A1562PedDDespachar = context.localUtil.CToN( cgiGet( edtPedDDespachar_Internalname), ".", ",");
            AssignAttri("", false, "A1562PedDDespachar", StringUtil.LTrimStr( A1562PedDDespachar, 15, 4));
            A1567PedDInafecto = context.localUtil.CToN( cgiGet( edtPedDInafecto_Internalname), ".", ",");
            AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
            A1550PedDAfecto = context.localUtil.CToN( cgiGet( edtPedDAfecto_Internalname), ".", ",");
            AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
            A1585PedDSelectivo = context.localUtil.CToN( cgiGet( edtPedDSelectivo_Internalname), ".", ",");
            AssignAttri("", false, "A1585PedDSelectivo", StringUtil.LTrimStr( A1585PedDSelectivo, 15, 2));
            A1552PedDSub = context.localUtil.CToN( cgiGet( edtPedDSub_Internalname), ".", ",");
            AssignAttri("", false, "A1552PedDSub", StringUtil.LTrimStr( A1552PedDSub, 15, 4));
            A1551PedDTot = context.localUtil.CToN( cgiGet( edtPedDTot_Internalname), ".", ",");
            AssignAttri("", false, "A1551PedDTot", StringUtil.LTrimStr( A1551PedDTot, 18, 8));
            A1561PedDDcto = context.localUtil.CToN( cgiGet( edtPedDDcto_Internalname), ".", ",");
            AssignAttri("", false, "A1561PedDDcto", StringUtil.LTrimStr( A1561PedDDcto, 15, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLPEDIDOSDET");
            forbiddenHiddens.Add("PedDValSel", context.localUtil.Format( A1587PedDValSel, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( A216PedDItem != Z216PedDItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clpedidosdet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A210PedCod = GetPar( "PedCod");
               AssignAttri("", false, "A210PedCod", A210PedCod);
               A216PedDItem = (short)(NumberUtil.Val( GetPar( "PedDItem"), "."));
               AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
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
               InitAll2T96( ) ;
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
         DisableAttributes2T96( ) ;
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

      protected void CONFIRM_2T0( )
      {
         BeforeValidate2T96( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2T96( ) ;
            }
            else
            {
               CheckExtendedTable2T96( ) ;
               if ( AnyError == 0 )
               {
                  ZM2T96( 17) ;
                  ZM2T96( 19) ;
                  ZM2T96( 20) ;
               }
               CloseExtendedTableCursors2T96( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2T0( ) ;
         }
      }

      protected void ResetCaption2T0( )
      {
      }

      protected void ZM2T96( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1551PedDTot = T002T3_A1551PedDTot[0];
               Z1592PedDTotInc = T002T3_A1592PedDTotInc[0];
               Z1566PedDICBPER = T002T3_A1566PedDICBPER[0];
               Z1554PedDCan = T002T3_A1554PedDCan[0];
               Z1553PedDPre = T002T3_A1553PedDPre[0];
               Z1574PedDPreInc = T002T3_A1574PedDPreInc[0];
               Z1555PedDDct = T002T3_A1555PedDDct[0];
               Z1556PedDDct2 = T002T3_A1556PedDDct2[0];
               Z1558PedDCanDSP = T002T3_A1558PedDCanDSP[0];
               Z1559PedDCanFAC = T002T3_A1559PedDCanFAC[0];
               Z1557PedDIna = T002T3_A1557PedDIna[0];
               Z1573PedDPorSel = T002T3_A1573PedDPorSel[0];
               Z1575PedDRef1 = T002T3_A1575PedDRef1[0];
               Z1576PedDRef2 = T002T3_A1576PedDRef2[0];
               Z1577PedDRef3 = T002T3_A1577PedDRef3[0];
               Z1578PedDRef4 = T002T3_A1578PedDRef4[0];
               Z1579PedDRef5 = T002T3_A1579PedDRef5[0];
               Z1587PedDValSel = T002T3_A1587PedDValSel[0];
               Z28ProdCod = T002T3_A28ProdCod[0];
            }
            else
            {
               Z1551PedDTot = A1551PedDTot;
               Z1592PedDTotInc = A1592PedDTotInc;
               Z1566PedDICBPER = A1566PedDICBPER;
               Z1554PedDCan = A1554PedDCan;
               Z1553PedDPre = A1553PedDPre;
               Z1574PedDPreInc = A1574PedDPreInc;
               Z1555PedDDct = A1555PedDDct;
               Z1556PedDDct2 = A1556PedDDct2;
               Z1558PedDCanDSP = A1558PedDCanDSP;
               Z1559PedDCanFAC = A1559PedDCanFAC;
               Z1557PedDIna = A1557PedDIna;
               Z1573PedDPorSel = A1573PedDPorSel;
               Z1575PedDRef1 = A1575PedDRef1;
               Z1576PedDRef2 = A1576PedDRef2;
               Z1577PedDRef3 = A1577PedDRef3;
               Z1578PedDRef4 = A1578PedDRef4;
               Z1579PedDRef5 = A1579PedDRef5;
               Z1587PedDValSel = A1587PedDValSel;
               Z28ProdCod = A28ProdCod;
            }
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z1598PedICBPER = T002T7_A1598PedICBPER[0];
            Z180MonCod = T002T7_A180MonCod[0];
         }
         if ( GX_JID == -18 )
         {
            Z1551PedDTot = A1551PedDTot;
            Z1592PedDTotInc = A1592PedDTotInc;
            Z1566PedDICBPER = A1566PedDICBPER;
            Z216PedDItem = A216PedDItem;
            Z1554PedDCan = A1554PedDCan;
            Z1553PedDPre = A1553PedDPre;
            Z1574PedDPreInc = A1574PedDPreInc;
            Z1555PedDDct = A1555PedDDct;
            Z1556PedDDct2 = A1556PedDDct2;
            Z1558PedDCanDSP = A1558PedDCanDSP;
            Z1559PedDCanFAC = A1559PedDCanFAC;
            Z55ProdDsc = A55ProdDsc;
            Z1557PedDIna = A1557PedDIna;
            Z1573PedDPorSel = A1573PedDPorSel;
            Z1575PedDRef1 = A1575PedDRef1;
            Z1576PedDRef2 = A1576PedDRef2;
            Z1577PedDRef3 = A1577PedDRef3;
            Z1578PedDRef4 = A1578PedDRef4;
            Z1579PedDRef5 = A1579PedDRef5;
            Z1572PedDObs = A1572PedDObs;
            Z1587PedDValSel = A1587PedDValSel;
            Z210PedCod = A210PedCod;
            Z28ProdCod = A28ProdCod;
            Z1598PedICBPER = A1598PedICBPER;
            Z180MonCod = A180MonCod;
            Z908ProdValICBPERD = A908ProdValICBPERD;
            Z907ProdValICBPER = A907ProdValICBPER;
            Z906ProdAfecICBPER = A906ProdAfecICBPER;
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

      protected void Load2T96( )
      {
         /* Using cursor T002T9 */
         pr_default.execute(6, new Object[] {A216PedDItem, A210PedCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound96 = 1;
            A1598PedICBPER = T002T9_A1598PedICBPER[0];
            n1598PedICBPER = T002T9_n1598PedICBPER[0];
            A1551PedDTot = T002T9_A1551PedDTot[0];
            AssignAttri("", false, "A1551PedDTot", StringUtil.LTrimStr( A1551PedDTot, 18, 8));
            A1592PedDTotInc = T002T9_A1592PedDTotInc[0];
            A1566PedDICBPER = T002T9_A1566PedDICBPER[0];
            A1554PedDCan = T002T9_A1554PedDCan[0];
            AssignAttri("", false, "A1554PedDCan", StringUtil.LTrimStr( A1554PedDCan, 15, 4));
            A1553PedDPre = T002T9_A1553PedDPre[0];
            AssignAttri("", false, "A1553PedDPre", StringUtil.LTrimStr( A1553PedDPre, 15, 4));
            A1574PedDPreInc = T002T9_A1574PedDPreInc[0];
            AssignAttri("", false, "A1574PedDPreInc", StringUtil.LTrimStr( A1574PedDPreInc, 15, 4));
            A1555PedDDct = T002T9_A1555PedDDct[0];
            AssignAttri("", false, "A1555PedDDct", StringUtil.LTrimStr( A1555PedDDct, 15, 2));
            A1556PedDDct2 = T002T9_A1556PedDDct2[0];
            AssignAttri("", false, "A1556PedDDct2", StringUtil.LTrimStr( A1556PedDDct2, 15, 2));
            A1558PedDCanDSP = T002T9_A1558PedDCanDSP[0];
            AssignAttri("", false, "A1558PedDCanDSP", StringUtil.LTrimStr( A1558PedDCanDSP, 15, 4));
            A1559PedDCanFAC = T002T9_A1559PedDCanFAC[0];
            AssignAttri("", false, "A1559PedDCanFAC", StringUtil.LTrimStr( A1559PedDCanFAC, 15, 4));
            A55ProdDsc = T002T9_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1557PedDIna = T002T9_A1557PedDIna[0];
            AssignAttri("", false, "A1557PedDIna", StringUtil.Str( (decimal)(A1557PedDIna), 1, 0));
            A1573PedDPorSel = T002T9_A1573PedDPorSel[0];
            AssignAttri("", false, "A1573PedDPorSel", StringUtil.LTrimStr( A1573PedDPorSel, 5, 2));
            A1575PedDRef1 = T002T9_A1575PedDRef1[0];
            AssignAttri("", false, "A1575PedDRef1", A1575PedDRef1);
            A1576PedDRef2 = T002T9_A1576PedDRef2[0];
            AssignAttri("", false, "A1576PedDRef2", A1576PedDRef2);
            A1577PedDRef3 = T002T9_A1577PedDRef3[0];
            AssignAttri("", false, "A1577PedDRef3", A1577PedDRef3);
            A1578PedDRef4 = T002T9_A1578PedDRef4[0];
            AssignAttri("", false, "A1578PedDRef4", A1578PedDRef4);
            A1579PedDRef5 = T002T9_A1579PedDRef5[0];
            AssignAttri("", false, "A1579PedDRef5", A1579PedDRef5);
            A1572PedDObs = T002T9_A1572PedDObs[0];
            AssignAttri("", false, "A1572PedDObs", A1572PedDObs);
            A1587PedDValSel = T002T9_A1587PedDValSel[0];
            A908ProdValICBPERD = T002T9_A908ProdValICBPERD[0];
            A907ProdValICBPER = T002T9_A907ProdValICBPER[0];
            A906ProdAfecICBPER = T002T9_A906ProdAfecICBPER[0];
            A28ProdCod = T002T9_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A180MonCod = T002T9_A180MonCod[0];
            ZM2T96( -18) ;
         }
         pr_default.close(6);
         OnLoadActions2T96( ) ;
      }

      protected void OnLoadActions2T96( )
      {
         A1566PedDICBPER = ((A906ProdAfecICBPER==1) ? ((A180MonCod==1) ? A907ProdValICBPER*A1554PedDCan : A908ProdValICBPERD*A1554PedDCan) : (decimal)(0));
         AssignAttri("", false, "A1566PedDICBPER", StringUtil.LTrimStr( A1566PedDICBPER, 15, 2));
         A1591PedDSubInc = NumberUtil.Round( A1574PedDPreInc*A1554PedDCan, 4);
         AssignAttri("", false, "A1591PedDSubInc", StringUtil.LTrimStr( A1591PedDSubInc, 15, 4));
         A1592PedDTotInc = NumberUtil.Round( (A1591PedDSubInc)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 2);
         AssignAttri("", false, "A1592PedDTotInc", StringUtil.LTrimStr( A1592PedDTotInc, 15, 4));
         A1586PedDSelectivoValor = (decimal)(A1587PedDValSel*A1554PedDCan);
         AssignAttri("", false, "A1586PedDSelectivoValor", StringUtil.LTrimStr( A1586PedDSelectivoValor, 15, 2));
         A1562PedDDespachar = (decimal)(A1554PedDCan-A1558PedDCanDSP);
         AssignAttri("", false, "A1562PedDDespachar", StringUtil.LTrimStr( A1562PedDDespachar, 15, 4));
         A1560PedDCanPendiente = (decimal)(A1554PedDCan-A1558PedDCanDSP);
         AssignAttri("", false, "A1560PedDCanPendiente", StringUtil.LTrimStr( A1560PedDCanPendiente, 15, 4));
         A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
         AssignAttri("", false, "A1552PedDSub", StringUtil.LTrimStr( A1552PedDSub, 15, 4));
         A1551PedDTot = NumberUtil.Round( (A1552PedDSub)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 8);
         AssignAttri("", false, "A1551PedDTot", StringUtil.LTrimStr( A1551PedDTot, 18, 8));
         A1561PedDDcto = NumberUtil.Round( A1552PedDSub-A1551PedDTot, 4);
         AssignAttri("", false, "A1561PedDDcto", StringUtil.LTrimStr( A1561PedDDcto, 15, 2));
         if ( ( A1557PedDIna == 1 ) || ( A1557PedDIna == 4 ) )
         {
            A1567PedDInafecto = A1551PedDTot;
            AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
         }
         else
         {
            A1567PedDInafecto = 0;
            AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
         }
         if ( A1557PedDIna == 3 )
         {
            A1565PedDGratuito = A1551PedDTot;
            AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
         }
         else
         {
            A1565PedDGratuito = 0;
            AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
         }
         if ( A1557PedDIna == 2 )
         {
            A1564PedDExonerado = A1551PedDTot;
            AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
         }
         else
         {
            A1564PedDExonerado = 0;
            AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
         }
         if ( A1557PedDIna == 2 )
         {
            A1563PedDExonerada = A1551PedDTot;
            AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
         }
         else
         {
            A1563PedDExonerada = 0;
            AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
         }
         if ( A1557PedDIna == 0 )
         {
            A1550PedDAfecto = A1551PedDTot;
            AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
         }
         else
         {
            A1550PedDAfecto = 0;
            AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
         }
         A1588PedDSelectivoPor = NumberUtil.Round( (A1551PedDTot*A1573PedDPorSel)/ (decimal)(100), 2);
         AssignAttri("", false, "A1588PedDSelectivoPor", StringUtil.LTrimStr( A1588PedDSelectivoPor, 15, 2));
         A1585PedDSelectivo = (decimal)(A1586PedDSelectivoValor+A1588PedDSelectivoPor);
         AssignAttri("", false, "A1585PedDSelectivo", StringUtil.LTrimStr( A1585PedDSelectivo, 15, 2));
      }

      protected void CheckExtendedTable2T96( )
      {
         nIsDirty_96 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002T7 */
         pr_default.execute(4, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1598PedICBPER = T002T7_A1598PedICBPER[0];
         n1598PedICBPER = T002T7_n1598PedICBPER[0];
         A180MonCod = T002T7_A180MonCod[0];
         pr_default.close(4);
         /* Using cursor T002T8 */
         pr_default.execute(5, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T002T8_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A908ProdValICBPERD = T002T8_A908ProdValICBPERD[0];
         A907ProdValICBPER = T002T8_A907ProdValICBPER[0];
         A906ProdAfecICBPER = T002T8_A906ProdAfecICBPER[0];
         pr_default.close(5);
         nIsDirty_96 = 1;
         A1566PedDICBPER = ((A906ProdAfecICBPER==1) ? ((A180MonCod==1) ? A907ProdValICBPER*A1554PedDCan : A908ProdValICBPERD*A1554PedDCan) : (decimal)(0));
         AssignAttri("", false, "A1566PedDICBPER", StringUtil.LTrimStr( A1566PedDICBPER, 15, 2));
         nIsDirty_96 = 1;
         A1591PedDSubInc = NumberUtil.Round( A1574PedDPreInc*A1554PedDCan, 4);
         AssignAttri("", false, "A1591PedDSubInc", StringUtil.LTrimStr( A1591PedDSubInc, 15, 4));
         nIsDirty_96 = 1;
         A1592PedDTotInc = NumberUtil.Round( (A1591PedDSubInc)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 2);
         AssignAttri("", false, "A1592PedDTotInc", StringUtil.LTrimStr( A1592PedDTotInc, 15, 4));
         nIsDirty_96 = 1;
         A1586PedDSelectivoValor = (decimal)(A1587PedDValSel*A1554PedDCan);
         AssignAttri("", false, "A1586PedDSelectivoValor", StringUtil.LTrimStr( A1586PedDSelectivoValor, 15, 2));
         nIsDirty_96 = 1;
         A1562PedDDespachar = (decimal)(A1554PedDCan-A1558PedDCanDSP);
         AssignAttri("", false, "A1562PedDDespachar", StringUtil.LTrimStr( A1562PedDDespachar, 15, 4));
         nIsDirty_96 = 1;
         A1560PedDCanPendiente = (decimal)(A1554PedDCan-A1558PedDCanDSP);
         AssignAttri("", false, "A1560PedDCanPendiente", StringUtil.LTrimStr( A1560PedDCanPendiente, 15, 4));
         nIsDirty_96 = 1;
         A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
         AssignAttri("", false, "A1552PedDSub", StringUtil.LTrimStr( A1552PedDSub, 15, 4));
         nIsDirty_96 = 1;
         A1551PedDTot = NumberUtil.Round( (A1552PedDSub)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 8);
         AssignAttri("", false, "A1551PedDTot", StringUtil.LTrimStr( A1551PedDTot, 18, 8));
         nIsDirty_96 = 1;
         A1561PedDDcto = NumberUtil.Round( A1552PedDSub-A1551PedDTot, 4);
         AssignAttri("", false, "A1561PedDDcto", StringUtil.LTrimStr( A1561PedDDcto, 15, 2));
         if ( ( A1557PedDIna == 1 ) || ( A1557PedDIna == 4 ) )
         {
            nIsDirty_96 = 1;
            A1567PedDInafecto = A1551PedDTot;
            AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
         }
         else
         {
            nIsDirty_96 = 1;
            A1567PedDInafecto = 0;
            AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
         }
         if ( A1557PedDIna == 3 )
         {
            nIsDirty_96 = 1;
            A1565PedDGratuito = A1551PedDTot;
            AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
         }
         else
         {
            nIsDirty_96 = 1;
            A1565PedDGratuito = 0;
            AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
         }
         if ( A1557PedDIna == 2 )
         {
            nIsDirty_96 = 1;
            A1564PedDExonerado = A1551PedDTot;
            AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
         }
         else
         {
            nIsDirty_96 = 1;
            A1564PedDExonerado = 0;
            AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
         }
         if ( A1557PedDIna == 2 )
         {
            nIsDirty_96 = 1;
            A1563PedDExonerada = A1551PedDTot;
            AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
         }
         else
         {
            nIsDirty_96 = 1;
            A1563PedDExonerada = 0;
            AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
         }
         if ( A1557PedDIna == 0 )
         {
            nIsDirty_96 = 1;
            A1550PedDAfecto = A1551PedDTot;
            AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
         }
         else
         {
            nIsDirty_96 = 1;
            A1550PedDAfecto = 0;
            AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
         }
         nIsDirty_96 = 1;
         A1588PedDSelectivoPor = NumberUtil.Round( (A1551PedDTot*A1573PedDPorSel)/ (decimal)(100), 2);
         AssignAttri("", false, "A1588PedDSelectivoPor", StringUtil.LTrimStr( A1588PedDSelectivoPor, 15, 2));
         nIsDirty_96 = 1;
         A1585PedDSelectivo = (decimal)(A1586PedDSelectivoValor+A1588PedDSelectivoPor);
         AssignAttri("", false, "A1585PedDSelectivo", StringUtil.LTrimStr( A1585PedDSelectivo, 15, 2));
      }

      protected void CloseExtendedTableCursors2T96( )
      {
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( string A210PedCod )
      {
         /* Using cursor T002T7 */
         pr_default.execute(4, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1598PedICBPER = T002T7_A1598PedICBPER[0];
         n1598PedICBPER = T002T7_n1598PedICBPER[0];
         A180MonCod = T002T7_A180MonCod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void gxLoad_20( string A28ProdCod )
      {
         /* Using cursor T002T10 */
         pr_default.execute(7, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T002T10_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A908ProdValICBPERD = T002T10_A908ProdValICBPERD[0];
         A907ProdValICBPER = T002T10_A907ProdValICBPER[0];
         A906ProdAfecICBPER = T002T10_A906ProdAfecICBPER[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A55ProdDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey2T96( )
      {
         /* Using cursor T002T11 */
         pr_default.execute(8, new Object[] {A210PedCod, A216PedDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound96 = 1;
         }
         else
         {
            RcdFound96 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002T3 */
         pr_default.execute(1, new Object[] {A210PedCod, A216PedDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2T96( 18) ;
            RcdFound96 = 1;
            A1551PedDTot = T002T3_A1551PedDTot[0];
            AssignAttri("", false, "A1551PedDTot", StringUtil.LTrimStr( A1551PedDTot, 18, 8));
            A1592PedDTotInc = T002T3_A1592PedDTotInc[0];
            A1566PedDICBPER = T002T3_A1566PedDICBPER[0];
            A216PedDItem = T002T3_A216PedDItem[0];
            AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
            A1554PedDCan = T002T3_A1554PedDCan[0];
            AssignAttri("", false, "A1554PedDCan", StringUtil.LTrimStr( A1554PedDCan, 15, 4));
            A1553PedDPre = T002T3_A1553PedDPre[0];
            AssignAttri("", false, "A1553PedDPre", StringUtil.LTrimStr( A1553PedDPre, 15, 4));
            A1574PedDPreInc = T002T3_A1574PedDPreInc[0];
            AssignAttri("", false, "A1574PedDPreInc", StringUtil.LTrimStr( A1574PedDPreInc, 15, 4));
            A1555PedDDct = T002T3_A1555PedDDct[0];
            AssignAttri("", false, "A1555PedDDct", StringUtil.LTrimStr( A1555PedDDct, 15, 2));
            A1556PedDDct2 = T002T3_A1556PedDDct2[0];
            AssignAttri("", false, "A1556PedDDct2", StringUtil.LTrimStr( A1556PedDDct2, 15, 2));
            A1558PedDCanDSP = T002T3_A1558PedDCanDSP[0];
            AssignAttri("", false, "A1558PedDCanDSP", StringUtil.LTrimStr( A1558PedDCanDSP, 15, 4));
            A1559PedDCanFAC = T002T3_A1559PedDCanFAC[0];
            AssignAttri("", false, "A1559PedDCanFAC", StringUtil.LTrimStr( A1559PedDCanFAC, 15, 4));
            A1557PedDIna = T002T3_A1557PedDIna[0];
            AssignAttri("", false, "A1557PedDIna", StringUtil.Str( (decimal)(A1557PedDIna), 1, 0));
            A1573PedDPorSel = T002T3_A1573PedDPorSel[0];
            AssignAttri("", false, "A1573PedDPorSel", StringUtil.LTrimStr( A1573PedDPorSel, 5, 2));
            A1575PedDRef1 = T002T3_A1575PedDRef1[0];
            AssignAttri("", false, "A1575PedDRef1", A1575PedDRef1);
            A1576PedDRef2 = T002T3_A1576PedDRef2[0];
            AssignAttri("", false, "A1576PedDRef2", A1576PedDRef2);
            A1577PedDRef3 = T002T3_A1577PedDRef3[0];
            AssignAttri("", false, "A1577PedDRef3", A1577PedDRef3);
            A1578PedDRef4 = T002T3_A1578PedDRef4[0];
            AssignAttri("", false, "A1578PedDRef4", A1578PedDRef4);
            A1579PedDRef5 = T002T3_A1579PedDRef5[0];
            AssignAttri("", false, "A1579PedDRef5", A1579PedDRef5);
            A1572PedDObs = T002T3_A1572PedDObs[0];
            AssignAttri("", false, "A1572PedDObs", A1572PedDObs);
            A1587PedDValSel = T002T3_A1587PedDValSel[0];
            A210PedCod = T002T3_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A28ProdCod = T002T3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z210PedCod = A210PedCod;
            Z216PedDItem = A216PedDItem;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2T96( ) ;
            if ( AnyError == 1 )
            {
               RcdFound96 = 0;
               InitializeNonKey2T96( ) ;
            }
            Gx_mode = sMode96;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound96 = 0;
            InitializeNonKey2T96( ) ;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode96;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2T96( ) ;
         if ( RcdFound96 == 0 )
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
         RcdFound96 = 0;
         /* Using cursor T002T12 */
         pr_default.execute(9, new Object[] {A216PedDItem, A210PedCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002T12_A216PedDItem[0] < A216PedDItem ) || ( T002T12_A216PedDItem[0] == A216PedDItem ) && ( StringUtil.StrCmp(T002T12_A210PedCod[0], A210PedCod) < 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002T12_A216PedDItem[0] > A216PedDItem ) || ( T002T12_A216PedDItem[0] == A216PedDItem ) && ( StringUtil.StrCmp(T002T12_A210PedCod[0], A210PedCod) > 0 ) ) )
            {
               A216PedDItem = T002T12_A216PedDItem[0];
               AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
               A210PedCod = T002T12_A210PedCod[0];
               AssignAttri("", false, "A210PedCod", A210PedCod);
               RcdFound96 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound96 = 0;
         /* Using cursor T002T13 */
         pr_default.execute(10, new Object[] {A216PedDItem, A210PedCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002T13_A216PedDItem[0] > A216PedDItem ) || ( T002T13_A216PedDItem[0] == A216PedDItem ) && ( StringUtil.StrCmp(T002T13_A210PedCod[0], A210PedCod) > 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002T13_A216PedDItem[0] < A216PedDItem ) || ( T002T13_A216PedDItem[0] == A216PedDItem ) && ( StringUtil.StrCmp(T002T13_A210PedCod[0], A210PedCod) < 0 ) ) )
            {
               A216PedDItem = T002T13_A216PedDItem[0];
               AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
               A210PedCod = T002T13_A210PedCod[0];
               AssignAttri("", false, "A210PedCod", A210PedCod);
               RcdFound96 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2T96( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2T96( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound96 == 1 )
            {
               if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( A216PedDItem != Z216PedDItem ) )
               {
                  A210PedCod = Z210PedCod;
                  AssignAttri("", false, "A210PedCod", A210PedCod);
                  A216PedDItem = Z216PedDItem;
                  AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2T96( ) ;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( A216PedDItem != Z216PedDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2T96( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PEDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2T96( ) ;
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
         if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( A216PedDItem != Z216PedDItem ) )
         {
            A210PedCod = Z210PedCod;
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A216PedDItem = Z216PedDItem;
            AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPedCod_Internalname;
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
         GetKey2T96( ) ;
         if ( RcdFound96 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PEDCOD");
               AnyError = 1;
               GX_FocusControl = edtPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( A216PedDItem != Z216PedDItem ) )
            {
               A210PedCod = Z210PedCod;
               AssignAttri("", false, "A210PedCod", A210PedCod);
               A216PedDItem = Z216PedDItem;
               AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PEDCOD");
               AnyError = 1;
               GX_FocusControl = edtPedCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( A216PedDItem != Z216PedDItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPedCod_Internalname;
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
         context.RollbackDataStores("clpedidosdet",pr_default);
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2T0( ) ;
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
         if ( RcdFound96 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
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
         ScanStart2T96( ) ;
         if ( RcdFound96 == 0 )
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
         ScanEnd2T96( ) ;
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
         if ( RcdFound96 == 0 )
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
         if ( RcdFound96 == 0 )
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
         ScanStart2T96( ) ;
         if ( RcdFound96 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound96 != 0 )
            {
               ScanNext2T96( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2T96( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2T96( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002T2 */
            pr_default.execute(0, new Object[] {A210PedCod, A216PedDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1551PedDTot != T002T2_A1551PedDTot[0] ) || ( Z1592PedDTotInc != T002T2_A1592PedDTotInc[0] ) || ( Z1566PedDICBPER != T002T2_A1566PedDICBPER[0] ) || ( Z1554PedDCan != T002T2_A1554PedDCan[0] ) || ( Z1553PedDPre != T002T2_A1553PedDPre[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1574PedDPreInc != T002T2_A1574PedDPreInc[0] ) || ( Z1555PedDDct != T002T2_A1555PedDDct[0] ) || ( Z1556PedDDct2 != T002T2_A1556PedDDct2[0] ) || ( Z1558PedDCanDSP != T002T2_A1558PedDCanDSP[0] ) || ( Z1559PedDCanFAC != T002T2_A1559PedDCanFAC[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1557PedDIna != T002T2_A1557PedDIna[0] ) || ( Z1573PedDPorSel != T002T2_A1573PedDPorSel[0] ) || ( StringUtil.StrCmp(Z1575PedDRef1, T002T2_A1575PedDRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1576PedDRef2, T002T2_A1576PedDRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1577PedDRef3, T002T2_A1577PedDRef3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1578PedDRef4, T002T2_A1578PedDRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1579PedDRef5, T002T2_A1579PedDRef5[0]) != 0 ) || ( Z1587PedDValSel != T002T2_A1587PedDValSel[0] ) || ( StringUtil.StrCmp(Z28ProdCod, T002T2_A28ProdCod[0]) != 0 ) )
            {
               if ( Z1551PedDTot != T002T2_A1551PedDTot[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDTot");
                  GXUtil.WriteLogRaw("Old: ",Z1551PedDTot);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1551PedDTot[0]);
               }
               if ( Z1592PedDTotInc != T002T2_A1592PedDTotInc[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDTotInc");
                  GXUtil.WriteLogRaw("Old: ",Z1592PedDTotInc);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1592PedDTotInc[0]);
               }
               if ( Z1566PedDICBPER != T002T2_A1566PedDICBPER[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z1566PedDICBPER);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1566PedDICBPER[0]);
               }
               if ( Z1554PedDCan != T002T2_A1554PedDCan[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDCan");
                  GXUtil.WriteLogRaw("Old: ",Z1554PedDCan);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1554PedDCan[0]);
               }
               if ( Z1553PedDPre != T002T2_A1553PedDPre[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDPre");
                  GXUtil.WriteLogRaw("Old: ",Z1553PedDPre);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1553PedDPre[0]);
               }
               if ( Z1574PedDPreInc != T002T2_A1574PedDPreInc[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDPreInc");
                  GXUtil.WriteLogRaw("Old: ",Z1574PedDPreInc);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1574PedDPreInc[0]);
               }
               if ( Z1555PedDDct != T002T2_A1555PedDDct[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDDct");
                  GXUtil.WriteLogRaw("Old: ",Z1555PedDDct);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1555PedDDct[0]);
               }
               if ( Z1556PedDDct2 != T002T2_A1556PedDDct2[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDDct2");
                  GXUtil.WriteLogRaw("Old: ",Z1556PedDDct2);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1556PedDDct2[0]);
               }
               if ( Z1558PedDCanDSP != T002T2_A1558PedDCanDSP[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDCanDSP");
                  GXUtil.WriteLogRaw("Old: ",Z1558PedDCanDSP);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1558PedDCanDSP[0]);
               }
               if ( Z1559PedDCanFAC != T002T2_A1559PedDCanFAC[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDCanFAC");
                  GXUtil.WriteLogRaw("Old: ",Z1559PedDCanFAC);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1559PedDCanFAC[0]);
               }
               if ( Z1557PedDIna != T002T2_A1557PedDIna[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDIna");
                  GXUtil.WriteLogRaw("Old: ",Z1557PedDIna);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1557PedDIna[0]);
               }
               if ( Z1573PedDPorSel != T002T2_A1573PedDPorSel[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDPorSel");
                  GXUtil.WriteLogRaw("Old: ",Z1573PedDPorSel);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1573PedDPorSel[0]);
               }
               if ( StringUtil.StrCmp(Z1575PedDRef1, T002T2_A1575PedDRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1575PedDRef1);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1575PedDRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1576PedDRef2, T002T2_A1576PedDRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1576PedDRef2);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1576PedDRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1577PedDRef3, T002T2_A1577PedDRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1577PedDRef3);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1577PedDRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1578PedDRef4, T002T2_A1578PedDRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1578PedDRef4);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1578PedDRef4[0]);
               }
               if ( StringUtil.StrCmp(Z1579PedDRef5, T002T2_A1579PedDRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDRef5");
                  GXUtil.WriteLogRaw("Old: ",Z1579PedDRef5);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1579PedDRef5[0]);
               }
               if ( Z1587PedDValSel != T002T2_A1587PedDValSel[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedDValSel");
                  GXUtil.WriteLogRaw("Old: ",Z1587PedDValSel);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A1587PedDValSel[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T002T2_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A28ProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLPEDIDOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T002T14 */
         pr_default.execute(11, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(11) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOS"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( Z1598PedICBPER != T002T14_A1598PedICBPER[0] ) || ( Z180MonCod != T002T14_A180MonCod[0] ) )
            {
               if ( Z1598PedICBPER != T002T14_A1598PedICBPER[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"PedICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z1598PedICBPER);
                  GXUtil.WriteLogRaw("Current: ",T002T14_A1598PedICBPER[0]);
               }
               if ( Z180MonCod != T002T14_A180MonCod[0] )
               {
                  GXUtil.WriteLog("clpedidosdet:[seudo value changed for attri]"+"MonCod");
                  GXUtil.WriteLogRaw("Old: ",Z180MonCod);
                  GXUtil.WriteLogRaw("Current: ",T002T14_A180MonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLPEDIDOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2T96( )
      {
         BeforeValidate2T96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T96( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2T96( 0) ;
            CheckOptimisticConcurrency2T96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2T96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002T15 */
                     pr_default.execute(12, new Object[] {A55ProdDsc, A1551PedDTot, A1592PedDTotInc, A1566PedDICBPER, A216PedDItem, A1554PedDCan, A1553PedDPre, A1574PedDPreInc, A1555PedDDct, A1556PedDDct2, A1558PedDCanDSP, A1559PedDCanFAC, A1557PedDIna, A1573PedDPorSel, A1575PedDRef1, A1576PedDRef2, A1577PedDRef3, A1578PedDRef4, A1579PedDRef5, A1572PedDObs, A1587PedDValSel, A210PedCod, A28ProdCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
                     if ( (pr_default.getStatus(12) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( level) rules */
                        /* Using cursor T002T17 */
                        pr_default.execute(13, new Object[] {A210PedCod});
                        A1598PedICBPER = T002T17_A1598PedICBPER[0];
                        n1598PedICBPER = T002T17_n1598PedICBPER[0];
                        pr_default.close(13);
                        /* End of After( level) rules */
                        UpdateTablesN12T96( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2T0( ) ;
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
               Load2T96( ) ;
            }
            EndLevel2T96( ) ;
         }
         CloseExtendedTableCursors2T96( ) ;
      }

      protected void Update2T96( )
      {
         BeforeValidate2T96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T96( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2T96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002T18 */
                     pr_default.execute(14, new Object[] {A55ProdDsc, A1551PedDTot, A1592PedDTotInc, A1566PedDICBPER, A1554PedDCan, A1553PedDPre, A1574PedDPreInc, A1555PedDDct, A1556PedDDct2, A1558PedDCanDSP, A1559PedDCanFAC, A1557PedDIna, A1573PedDPorSel, A1575PedDRef1, A1576PedDRef2, A1577PedDRef3, A1578PedDRef4, A1579PedDRef5, A1572PedDObs, A1587PedDValSel, A28ProdCod, A210PedCod, A216PedDItem});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2T96( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( level) rules */
                        /* Using cursor T002T20 */
                        pr_default.execute(15, new Object[] {A210PedCod});
                        A1598PedICBPER = T002T20_A1598PedICBPER[0];
                        n1598PedICBPER = T002T20_n1598PedICBPER[0];
                        pr_default.close(15);
                        /* End of After( level) rules */
                        UpdateTablesN12T96( ) ;
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2T0( ) ;
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
            EndLevel2T96( ) ;
         }
         CloseExtendedTableCursors2T96( ) ;
      }

      protected void DeferredUpdate2T96( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2T96( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T96( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2T96( ) ;
            AfterConfirm2T96( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2T96( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002T21 */
                  pr_default.execute(16, new Object[] {A210PedCod, A216PedDItem});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( level) rules */
                     /* Using cursor T002T23 */
                     pr_default.execute(17, new Object[] {A210PedCod});
                     A1598PedICBPER = T002T23_A1598PedICBPER[0];
                     n1598PedICBPER = T002T23_n1598PedICBPER[0];
                     pr_default.close(17);
                     /* End of After( level) rules */
                     UpdateTablesN12T96( ) ;
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound96 == 0 )
                        {
                           InitAll2T96( ) ;
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
                        ResetCaption2T0( ) ;
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
         sMode96 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2T96( ) ;
         Gx_mode = sMode96;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2T96( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002T24 */
            pr_default.execute(18, new Object[] {A210PedCod});
            Z1598PedICBPER = T002T24_A1598PedICBPER[0];
            Z180MonCod = T002T24_A180MonCod[0];
            A1598PedICBPER = T002T24_A1598PedICBPER[0];
            n1598PedICBPER = T002T24_n1598PedICBPER[0];
            A180MonCod = T002T24_A180MonCod[0];
            pr_default.close(18);
            /* Using cursor T002T25 */
            pr_default.execute(19, new Object[] {A28ProdCod});
            A55ProdDsc = T002T25_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A908ProdValICBPERD = T002T25_A908ProdValICBPERD[0];
            A907ProdValICBPER = T002T25_A907ProdValICBPER[0];
            A906ProdAfecICBPER = T002T25_A906ProdAfecICBPER[0];
            pr_default.close(19);
            A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
            AssignAttri("", false, "A1552PedDSub", StringUtil.LTrimStr( A1552PedDSub, 15, 4));
            A1591PedDSubInc = NumberUtil.Round( A1574PedDPreInc*A1554PedDCan, 4);
            AssignAttri("", false, "A1591PedDSubInc", StringUtil.LTrimStr( A1591PedDSubInc, 15, 4));
            A1562PedDDespachar = (decimal)(A1554PedDCan-A1558PedDCanDSP);
            AssignAttri("", false, "A1562PedDDespachar", StringUtil.LTrimStr( A1562PedDDespachar, 15, 4));
            A1560PedDCanPendiente = (decimal)(A1554PedDCan-A1558PedDCanDSP);
            AssignAttri("", false, "A1560PedDCanPendiente", StringUtil.LTrimStr( A1560PedDCanPendiente, 15, 4));
            if ( ( A1557PedDIna == 1 ) || ( A1557PedDIna == 4 ) )
            {
               A1567PedDInafecto = A1551PedDTot;
               AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
            }
            else
            {
               A1567PedDInafecto = 0;
               AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
            }
            if ( A1557PedDIna == 3 )
            {
               A1565PedDGratuito = A1551PedDTot;
               AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
            }
            else
            {
               A1565PedDGratuito = 0;
               AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
            }
            if ( A1557PedDIna == 2 )
            {
               A1564PedDExonerado = A1551PedDTot;
               AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
            }
            else
            {
               A1564PedDExonerado = 0;
               AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
            }
            if ( A1557PedDIna == 2 )
            {
               A1563PedDExonerada = A1551PedDTot;
               AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
            }
            else
            {
               A1563PedDExonerada = 0;
               AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
            }
            if ( A1557PedDIna == 0 )
            {
               A1550PedDAfecto = A1551PedDTot;
               AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
            }
            else
            {
               A1550PedDAfecto = 0;
               AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
            }
            A1588PedDSelectivoPor = NumberUtil.Round( (A1551PedDTot*A1573PedDPorSel)/ (decimal)(100), 2);
            AssignAttri("", false, "A1588PedDSelectivoPor", StringUtil.LTrimStr( A1588PedDSelectivoPor, 15, 2));
            A1561PedDDcto = NumberUtil.Round( A1552PedDSub-A1551PedDTot, 4);
            AssignAttri("", false, "A1561PedDDcto", StringUtil.LTrimStr( A1561PedDDcto, 15, 2));
            A1586PedDSelectivoValor = (decimal)(A1587PedDValSel*A1554PedDCan);
            AssignAttri("", false, "A1586PedDSelectivoValor", StringUtil.LTrimStr( A1586PedDSelectivoValor, 15, 2));
            A1585PedDSelectivo = (decimal)(A1586PedDSelectivoValor+A1588PedDSelectivoPor);
            AssignAttri("", false, "A1585PedDSelectivo", StringUtil.LTrimStr( A1585PedDSelectivo, 15, 2));
         }
      }

      protected void UpdateTablesN12T96( )
      {
         /* Using cursor T002T26 */
         pr_default.execute(20, new Object[] {n1598PedICBPER, A1598PedICBPER, A210PedCod});
         pr_default.close(20);
         dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOS");
      }

      protected void EndLevel2T96( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(11);
         if ( AnyError == 0 )
         {
            BeforeComplete2T96( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(15);
            pr_default.close(13);
            pr_default.close(2);
            pr_default.close(18);
            pr_default.close(19);
            context.CommitDataStores("clpedidosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(15);
            pr_default.close(13);
            pr_default.close(2);
            pr_default.close(18);
            pr_default.close(19);
            context.RollbackDataStores("clpedidosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2T96( )
      {
         /* Using cursor T002T27 */
         pr_default.execute(21);
         RcdFound96 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound96 = 1;
            A210PedCod = T002T27_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A216PedDItem = T002T27_A216PedDItem[0];
            AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2T96( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound96 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound96 = 1;
            A210PedCod = T002T27_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A216PedDItem = T002T27_A216PedDItem[0];
            AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
         }
      }

      protected void ScanEnd2T96( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm2T96( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2T96( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2T96( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2T96( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2T96( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2T96( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2T96( )
      {
         edtPedCod_Enabled = 0;
         AssignProp("", false, edtPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedCod_Enabled), 5, 0), true);
         edtPedDItem_Enabled = 0;
         AssignProp("", false, edtPedDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDItem_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtPedDCan_Enabled = 0;
         AssignProp("", false, edtPedDCan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDCan_Enabled), 5, 0), true);
         edtPedDPre_Enabled = 0;
         AssignProp("", false, edtPedDPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDPre_Enabled), 5, 0), true);
         edtPedDPreInc_Enabled = 0;
         AssignProp("", false, edtPedDPreInc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDPreInc_Enabled), 5, 0), true);
         edtPedDDct_Enabled = 0;
         AssignProp("", false, edtPedDDct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDDct_Enabled), 5, 0), true);
         edtPedDDct2_Enabled = 0;
         AssignProp("", false, edtPedDDct2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDDct2_Enabled), 5, 0), true);
         edtPedDCanDSP_Enabled = 0;
         AssignProp("", false, edtPedDCanDSP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDCanDSP_Enabled), 5, 0), true);
         edtPedDCanFAC_Enabled = 0;
         AssignProp("", false, edtPedDCanFAC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDCanFAC_Enabled), 5, 0), true);
         edtPedDCanPendiente_Enabled = 0;
         AssignProp("", false, edtPedDCanPendiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDCanPendiente_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtPedDIna_Enabled = 0;
         AssignProp("", false, edtPedDIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDIna_Enabled), 5, 0), true);
         edtPedDPorSel_Enabled = 0;
         AssignProp("", false, edtPedDPorSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDPorSel_Enabled), 5, 0), true);
         edtPedDRef1_Enabled = 0;
         AssignProp("", false, edtPedDRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDRef1_Enabled), 5, 0), true);
         edtPedDRef2_Enabled = 0;
         AssignProp("", false, edtPedDRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDRef2_Enabled), 5, 0), true);
         edtPedDRef3_Enabled = 0;
         AssignProp("", false, edtPedDRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDRef3_Enabled), 5, 0), true);
         edtPedDRef4_Enabled = 0;
         AssignProp("", false, edtPedDRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDRef4_Enabled), 5, 0), true);
         edtPedDRef5_Enabled = 0;
         AssignProp("", false, edtPedDRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDRef5_Enabled), 5, 0), true);
         edtPedDObs_Enabled = 0;
         AssignProp("", false, edtPedDObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDObs_Enabled), 5, 0), true);
         edtPedDDespachar_Enabled = 0;
         AssignProp("", false, edtPedDDespachar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDDespachar_Enabled), 5, 0), true);
         edtPedDInafecto_Enabled = 0;
         AssignProp("", false, edtPedDInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDInafecto_Enabled), 5, 0), true);
         edtPedDAfecto_Enabled = 0;
         AssignProp("", false, edtPedDAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDAfecto_Enabled), 5, 0), true);
         edtPedDSelectivo_Enabled = 0;
         AssignProp("", false, edtPedDSelectivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDSelectivo_Enabled), 5, 0), true);
         edtPedDSub_Enabled = 0;
         AssignProp("", false, edtPedDSub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDSub_Enabled), 5, 0), true);
         edtPedDTot_Enabled = 0;
         AssignProp("", false, edtPedDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDTot_Enabled), 5, 0), true);
         edtPedDDcto_Enabled = 0;
         AssignProp("", false, edtPedDDcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDDcto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2T96( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2T0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810244997", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clpedidosdet.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLPEDIDOSDET");
         forbiddenHiddens.Add("PedDValSel", context.localUtil.Format( A1587PedDValSel, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clpedidosdet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z210PedCod", StringUtil.RTrim( Z210PedCod));
         GxWebStd.gx_hidden_field( context, "Z216PedDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216PedDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1551PedDTot", StringUtil.LTrim( StringUtil.NToC( Z1551PedDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1592PedDTotInc", StringUtil.LTrim( StringUtil.NToC( Z1592PedDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1566PedDICBPER", StringUtil.LTrim( StringUtil.NToC( Z1566PedDICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1554PedDCan", StringUtil.LTrim( StringUtil.NToC( Z1554PedDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1553PedDPre", StringUtil.LTrim( StringUtil.NToC( Z1553PedDPre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1574PedDPreInc", StringUtil.LTrim( StringUtil.NToC( Z1574PedDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1555PedDDct", StringUtil.LTrim( StringUtil.NToC( Z1555PedDDct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1556PedDDct2", StringUtil.LTrim( StringUtil.NToC( Z1556PedDDct2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1558PedDCanDSP", StringUtil.LTrim( StringUtil.NToC( Z1558PedDCanDSP, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1559PedDCanFAC", StringUtil.LTrim( StringUtil.NToC( Z1559PedDCanFAC, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1557PedDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1557PedDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1573PedDPorSel", StringUtil.LTrim( StringUtil.NToC( Z1573PedDPorSel, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1575PedDRef1", StringUtil.RTrim( Z1575PedDRef1));
         GxWebStd.gx_hidden_field( context, "Z1576PedDRef2", StringUtil.RTrim( Z1576PedDRef2));
         GxWebStd.gx_hidden_field( context, "Z1577PedDRef3", StringUtil.RTrim( Z1577PedDRef3));
         GxWebStd.gx_hidden_field( context, "Z1578PedDRef4", StringUtil.RTrim( Z1578PedDRef4));
         GxWebStd.gx_hidden_field( context, "Z1579PedDRef5", StringUtil.RTrim( Z1579PedDRef5));
         GxWebStd.gx_hidden_field( context, "Z1587PedDValSel", StringUtil.LTrim( StringUtil.NToC( Z1587PedDValSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1598PedICBPER", StringUtil.LTrim( StringUtil.NToC( Z1598PedICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PEDDSUBINC", StringUtil.LTrim( StringUtil.NToC( A1591PedDSubInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDVALSEL", StringUtil.LTrim( StringUtil.NToC( A1587PedDValSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDSELECTIVOVALOR", StringUtil.LTrim( StringUtil.NToC( A1586PedDSelectivoValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODAFECICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDICBPER", StringUtil.LTrim( StringUtil.NToC( A1566PedDICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDTOTINC", StringUtil.LTrim( StringUtil.NToC( A1592PedDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDGRATUITO", StringUtil.LTrim( StringUtil.NToC( A1565PedDGratuito, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDEXONERADO", StringUtil.LTrim( StringUtil.NToC( A1564PedDExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDEXONERADA", StringUtil.LTrim( StringUtil.NToC( A1563PedDExonerada, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDDSELECTIVOPOR", StringUtil.LTrim( StringUtil.NToC( A1588PedDSelectivoPor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDICBPER", StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")));
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
         return formatLink("clpedidosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLPEDIDOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pedidos - Detalle" ;
      }

      protected void InitializeNonKey2T96( )
      {
         A1598PedICBPER = 0;
         n1598PedICBPER = false;
         AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrimStr( A1598PedICBPER, 15, 2));
         A1561PedDDcto = 0;
         AssignAttri("", false, "A1561PedDDcto", StringUtil.LTrimStr( A1561PedDDcto, 15, 2));
         A1585PedDSelectivo = 0;
         AssignAttri("", false, "A1585PedDSelectivo", StringUtil.LTrimStr( A1585PedDSelectivo, 15, 2));
         A1588PedDSelectivoPor = 0;
         AssignAttri("", false, "A1588PedDSelectivoPor", StringUtil.LTrimStr( A1588PedDSelectivoPor, 15, 2));
         A1550PedDAfecto = 0;
         AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrimStr( A1550PedDAfecto, 15, 2));
         A1563PedDExonerada = 0;
         AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrimStr( A1563PedDExonerada, 15, 2));
         A1564PedDExonerado = 0;
         AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrimStr( A1564PedDExonerado, 15, 2));
         A1565PedDGratuito = 0;
         AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrimStr( A1565PedDGratuito, 15, 2));
         A1567PedDInafecto = 0;
         AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrimStr( A1567PedDInafecto, 15, 2));
         A1551PedDTot = 0;
         AssignAttri("", false, "A1551PedDTot", StringUtil.LTrimStr( A1551PedDTot, 18, 8));
         A1592PedDTotInc = 0;
         AssignAttri("", false, "A1592PedDTotInc", StringUtil.LTrimStr( A1592PedDTotInc, 15, 4));
         A1552PedDSub = 0;
         AssignAttri("", false, "A1552PedDSub", StringUtil.LTrimStr( A1552PedDSub, 15, 4));
         A1560PedDCanPendiente = 0;
         AssignAttri("", false, "A1560PedDCanPendiente", StringUtil.LTrimStr( A1560PedDCanPendiente, 15, 4));
         A1562PedDDespachar = 0;
         AssignAttri("", false, "A1562PedDDespachar", StringUtil.LTrimStr( A1562PedDDespachar, 15, 4));
         A1566PedDICBPER = 0;
         AssignAttri("", false, "A1566PedDICBPER", StringUtil.LTrimStr( A1566PedDICBPER, 15, 2));
         A1586PedDSelectivoValor = 0;
         AssignAttri("", false, "A1586PedDSelectivoValor", StringUtil.LTrimStr( A1586PedDSelectivoValor, 15, 2));
         A1591PedDSubInc = 0;
         AssignAttri("", false, "A1591PedDSubInc", StringUtil.LTrimStr( A1591PedDSubInc, 15, 4));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A1554PedDCan = 0;
         AssignAttri("", false, "A1554PedDCan", StringUtil.LTrimStr( A1554PedDCan, 15, 4));
         A1553PedDPre = 0;
         AssignAttri("", false, "A1553PedDPre", StringUtil.LTrimStr( A1553PedDPre, 15, 4));
         A1574PedDPreInc = 0;
         AssignAttri("", false, "A1574PedDPreInc", StringUtil.LTrimStr( A1574PedDPreInc, 15, 4));
         A1555PedDDct = 0;
         AssignAttri("", false, "A1555PedDDct", StringUtil.LTrimStr( A1555PedDDct, 15, 2));
         A1556PedDDct2 = 0;
         AssignAttri("", false, "A1556PedDDct2", StringUtil.LTrimStr( A1556PedDDct2, 15, 2));
         A1558PedDCanDSP = 0;
         AssignAttri("", false, "A1558PedDCanDSP", StringUtil.LTrimStr( A1558PedDCanDSP, 15, 4));
         A1559PedDCanFAC = 0;
         AssignAttri("", false, "A1559PedDCanFAC", StringUtil.LTrimStr( A1559PedDCanFAC, 15, 4));
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1557PedDIna = 0;
         AssignAttri("", false, "A1557PedDIna", StringUtil.Str( (decimal)(A1557PedDIna), 1, 0));
         A1573PedDPorSel = 0;
         AssignAttri("", false, "A1573PedDPorSel", StringUtil.LTrimStr( A1573PedDPorSel, 5, 2));
         A1575PedDRef1 = "";
         AssignAttri("", false, "A1575PedDRef1", A1575PedDRef1);
         A1576PedDRef2 = "";
         AssignAttri("", false, "A1576PedDRef2", A1576PedDRef2);
         A1577PedDRef3 = "";
         AssignAttri("", false, "A1577PedDRef3", A1577PedDRef3);
         A1578PedDRef4 = "";
         AssignAttri("", false, "A1578PedDRef4", A1578PedDRef4);
         A1579PedDRef5 = "";
         AssignAttri("", false, "A1579PedDRef5", A1579PedDRef5);
         A1572PedDObs = "";
         AssignAttri("", false, "A1572PedDObs", A1572PedDObs);
         A1587PedDValSel = 0;
         AssignAttri("", false, "A1587PedDValSel", StringUtil.LTrimStr( A1587PedDValSel, 15, 2));
         A908ProdValICBPERD = 0;
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
         A907ProdValICBPER = 0;
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         A906ProdAfecICBPER = 0;
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
         Z1551PedDTot = 0;
         Z1592PedDTotInc = 0;
         Z1566PedDICBPER = 0;
         Z1554PedDCan = 0;
         Z1553PedDPre = 0;
         Z1574PedDPreInc = 0;
         Z1555PedDDct = 0;
         Z1556PedDDct2 = 0;
         Z1558PedDCanDSP = 0;
         Z1559PedDCanFAC = 0;
         Z1557PedDIna = 0;
         Z1573PedDPorSel = 0;
         Z1575PedDRef1 = "";
         Z1576PedDRef2 = "";
         Z1577PedDRef3 = "";
         Z1578PedDRef4 = "";
         Z1579PedDRef5 = "";
         Z1587PedDValSel = 0;
         Z28ProdCod = "";
         Z1598PedICBPER = 0;
         Z180MonCod = 0;
      }

      protected void InitAll2T96( )
      {
         A210PedCod = "";
         AssignAttri("", false, "A210PedCod", A210PedCod);
         A216PedDItem = 0;
         AssignAttri("", false, "A216PedDItem", StringUtil.LTrimStr( (decimal)(A216PedDItem), 4, 0));
         InitializeNonKey2T96( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245022", true, true);
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
         context.AddJavascriptSource("clpedidosdet.js", "?202281810245022", false, true);
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
         edtPedCod_Internalname = "PEDCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPedDItem_Internalname = "PEDDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPedDCan_Internalname = "PEDDCAN";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPedDPre_Internalname = "PEDDPRE";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPedDPreInc_Internalname = "PEDDPREINC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPedDDct_Internalname = "PEDDDCT";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPedDDct2_Internalname = "PEDDDCT2";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPedDCanDSP_Internalname = "PEDDCANDSP";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPedDCanFAC_Internalname = "PEDDCANFAC";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtPedDCanPendiente_Internalname = "PEDDCANPENDIENTE";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtPedDIna_Internalname = "PEDDINA";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtPedDPorSel_Internalname = "PEDDPORSEL";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtPedDRef1_Internalname = "PEDDREF1";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtPedDRef2_Internalname = "PEDDREF2";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtPedDRef3_Internalname = "PEDDREF3";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtPedDRef4_Internalname = "PEDDREF4";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtPedDRef5_Internalname = "PEDDREF5";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtPedDObs_Internalname = "PEDDOBS";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtPedDDespachar_Internalname = "PEDDDESPACHAR";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtPedDInafecto_Internalname = "PEDDINAFECTO";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtPedDAfecto_Internalname = "PEDDAFECTO";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtPedDSelectivo_Internalname = "PEDDSELECTIVO";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtPedDSub_Internalname = "PEDDSUB";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtPedDTot_Internalname = "PEDDTOT";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtPedDDcto_Internalname = "PEDDDCTO";
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
         Form.Caption = "Pedidos - Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPedDDcto_Jsonclick = "";
         edtPedDDcto_Enabled = 0;
         edtPedDTot_Jsonclick = "";
         edtPedDTot_Enabled = 0;
         edtPedDSub_Jsonclick = "";
         edtPedDSub_Enabled = 0;
         edtPedDSelectivo_Jsonclick = "";
         edtPedDSelectivo_Enabled = 0;
         edtPedDAfecto_Jsonclick = "";
         edtPedDAfecto_Enabled = 0;
         edtPedDInafecto_Jsonclick = "";
         edtPedDInafecto_Enabled = 0;
         edtPedDDespachar_Jsonclick = "";
         edtPedDDespachar_Enabled = 0;
         edtPedDObs_Enabled = 1;
         edtPedDRef5_Jsonclick = "";
         edtPedDRef5_Enabled = 1;
         edtPedDRef4_Jsonclick = "";
         edtPedDRef4_Enabled = 1;
         edtPedDRef3_Jsonclick = "";
         edtPedDRef3_Enabled = 1;
         edtPedDRef2_Jsonclick = "";
         edtPedDRef2_Enabled = 1;
         edtPedDRef1_Jsonclick = "";
         edtPedDRef1_Enabled = 1;
         edtPedDPorSel_Jsonclick = "";
         edtPedDPorSel_Enabled = 1;
         edtPedDIna_Jsonclick = "";
         edtPedDIna_Enabled = 1;
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 0;
         edtPedDCanPendiente_Jsonclick = "";
         edtPedDCanPendiente_Enabled = 0;
         edtPedDCanFAC_Jsonclick = "";
         edtPedDCanFAC_Enabled = 1;
         edtPedDCanDSP_Jsonclick = "";
         edtPedDCanDSP_Enabled = 1;
         edtPedDDct2_Jsonclick = "";
         edtPedDDct2_Enabled = 1;
         edtPedDDct_Jsonclick = "";
         edtPedDDct_Enabled = 1;
         edtPedDPreInc_Jsonclick = "";
         edtPedDPreInc_Enabled = 1;
         edtPedDPre_Jsonclick = "";
         edtPedDPre_Enabled = 1;
         edtPedDCan_Jsonclick = "";
         edtPedDCan_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPedDItem_Jsonclick = "";
         edtPedDItem_Enabled = 1;
         edtPedCod_Jsonclick = "";
         edtPedCod_Enabled = 1;
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
         /* Using cursor T002T24 */
         pr_default.execute(18, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1598PedICBPER = T002T24_A1598PedICBPER[0];
         n1598PedICBPER = T002T24_n1598PedICBPER[0];
         A180MonCod = T002T24_A180MonCod[0];
         pr_default.close(18);
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

      public void Valid_Pedcod( )
      {
         n1598PedICBPER = false;
         /* Using cursor T002T24 */
         pr_default.execute(18, new Object[] {A210PedCod});
         Z1598PedICBPER = T002T24_A1598PedICBPER[0];
         Z180MonCod = T002T24_A180MonCod[0];
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
         }
         A1598PedICBPER = T002T24_A1598PedICBPER[0];
         n1598PedICBPER = T002T24_n1598PedICBPER[0];
         A180MonCod = T002T24_A180MonCod[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
      }

      public void Valid_Pedditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A1554PedDCan", StringUtil.LTrim( StringUtil.NToC( A1554PedDCan, 15, 4, ".", "")));
         AssignAttri("", false, "A1553PedDPre", StringUtil.LTrim( StringUtil.NToC( A1553PedDPre, 15, 4, ".", "")));
         AssignAttri("", false, "A1574PedDPreInc", StringUtil.LTrim( StringUtil.NToC( A1574PedDPreInc, 15, 4, ".", "")));
         AssignAttri("", false, "A1555PedDDct", StringUtil.LTrim( StringUtil.NToC( A1555PedDDct, 15, 2, ".", "")));
         AssignAttri("", false, "A1556PedDDct2", StringUtil.LTrim( StringUtil.NToC( A1556PedDDct2, 15, 2, ".", "")));
         AssignAttri("", false, "A1558PedDCanDSP", StringUtil.LTrim( StringUtil.NToC( A1558PedDCanDSP, 15, 4, ".", "")));
         AssignAttri("", false, "A1559PedDCanFAC", StringUtil.LTrim( StringUtil.NToC( A1559PedDCanFAC, 15, 4, ".", "")));
         AssignAttri("", false, "A1557PedDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1557PedDIna), 1, 0, ".", "")));
         AssignAttri("", false, "A1573PedDPorSel", StringUtil.LTrim( StringUtil.NToC( A1573PedDPorSel, 5, 2, ".", "")));
         AssignAttri("", false, "A1575PedDRef1", StringUtil.RTrim( A1575PedDRef1));
         AssignAttri("", false, "A1576PedDRef2", StringUtil.RTrim( A1576PedDRef2));
         AssignAttri("", false, "A1577PedDRef3", StringUtil.RTrim( A1577PedDRef3));
         AssignAttri("", false, "A1578PedDRef4", StringUtil.RTrim( A1578PedDRef4));
         AssignAttri("", false, "A1579PedDRef5", StringUtil.RTrim( A1579PedDRef5));
         AssignAttri("", false, "A1572PedDObs", A1572PedDObs);
         AssignAttri("", false, "A1587PedDValSel", StringUtil.LTrim( StringUtil.NToC( A1587PedDValSel, 15, 2, ".", "")));
         AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         AssignAttri("", false, "A1566PedDICBPER", StringUtil.LTrim( StringUtil.NToC( A1566PedDICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A1591PedDSubInc", StringUtil.LTrim( StringUtil.NToC( A1591PedDSubInc, 15, 4, ".", "")));
         AssignAttri("", false, "A1592PedDTotInc", StringUtil.LTrim( StringUtil.NToC( A1592PedDTotInc, 15, 4, ".", "")));
         AssignAttri("", false, "A1586PedDSelectivoValor", StringUtil.LTrim( StringUtil.NToC( A1586PedDSelectivoValor, 15, 2, ".", "")));
         AssignAttri("", false, "A1562PedDDespachar", StringUtil.LTrim( StringUtil.NToC( A1562PedDDespachar, 15, 4, ".", "")));
         AssignAttri("", false, "A1560PedDCanPendiente", StringUtil.LTrim( StringUtil.NToC( A1560PedDCanPendiente, 15, 4, ".", "")));
         AssignAttri("", false, "A1552PedDSub", StringUtil.LTrim( StringUtil.NToC( A1552PedDSub, 15, 4, ".", "")));
         AssignAttri("", false, "A1551PedDTot", StringUtil.LTrim( StringUtil.NToC( A1551PedDTot, 18, 8, ".", "")));
         AssignAttri("", false, "A1561PedDDcto", StringUtil.LTrim( StringUtil.NToC( A1561PedDDcto, 15, 2, ".", "")));
         AssignAttri("", false, "A1567PedDInafecto", StringUtil.LTrim( StringUtil.NToC( A1567PedDInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1565PedDGratuito", StringUtil.LTrim( StringUtil.NToC( A1565PedDGratuito, 15, 2, ".", "")));
         AssignAttri("", false, "A1564PedDExonerado", StringUtil.LTrim( StringUtil.NToC( A1564PedDExonerado, 15, 2, ".", "")));
         AssignAttri("", false, "A1563PedDExonerada", StringUtil.LTrim( StringUtil.NToC( A1563PedDExonerada, 15, 2, ".", "")));
         AssignAttri("", false, "A1550PedDAfecto", StringUtil.LTrim( StringUtil.NToC( A1550PedDAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1588PedDSelectivoPor", StringUtil.LTrim( StringUtil.NToC( A1588PedDSelectivoPor, 15, 2, ".", "")));
         AssignAttri("", false, "A1585PedDSelectivo", StringUtil.LTrim( StringUtil.NToC( A1585PedDSelectivo, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z210PedCod", StringUtil.RTrim( Z210PedCod));
         GxWebStd.gx_hidden_field( context, "Z216PedDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z216PedDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1554PedDCan", StringUtil.LTrim( StringUtil.NToC( Z1554PedDCan, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1553PedDPre", StringUtil.LTrim( StringUtil.NToC( Z1553PedDPre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1574PedDPreInc", StringUtil.LTrim( StringUtil.NToC( Z1574PedDPreInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1555PedDDct", StringUtil.LTrim( StringUtil.NToC( Z1555PedDDct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1556PedDDct2", StringUtil.LTrim( StringUtil.NToC( Z1556PedDDct2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1558PedDCanDSP", StringUtil.LTrim( StringUtil.NToC( Z1558PedDCanDSP, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1559PedDCanFAC", StringUtil.LTrim( StringUtil.NToC( Z1559PedDCanFAC, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1557PedDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1557PedDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1573PedDPorSel", StringUtil.LTrim( StringUtil.NToC( Z1573PedDPorSel, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1575PedDRef1", StringUtil.RTrim( Z1575PedDRef1));
         GxWebStd.gx_hidden_field( context, "Z1576PedDRef2", StringUtil.RTrim( Z1576PedDRef2));
         GxWebStd.gx_hidden_field( context, "Z1577PedDRef3", StringUtil.RTrim( Z1577PedDRef3));
         GxWebStd.gx_hidden_field( context, "Z1578PedDRef4", StringUtil.RTrim( Z1578PedDRef4));
         GxWebStd.gx_hidden_field( context, "Z1579PedDRef5", StringUtil.RTrim( Z1579PedDRef5));
         GxWebStd.gx_hidden_field( context, "Z1572PedDObs", Z1572PedDObs);
         GxWebStd.gx_hidden_field( context, "Z1587PedDValSel", StringUtil.LTrim( StringUtil.NToC( Z1587PedDValSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1598PedICBPER", StringUtil.LTrim( StringUtil.NToC( Z1598PedICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1566PedDICBPER", StringUtil.LTrim( StringUtil.NToC( Z1566PedDICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1591PedDSubInc", StringUtil.LTrim( StringUtil.NToC( Z1591PedDSubInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1592PedDTotInc", StringUtil.LTrim( StringUtil.NToC( Z1592PedDTotInc, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1586PedDSelectivoValor", StringUtil.LTrim( StringUtil.NToC( Z1586PedDSelectivoValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1562PedDDespachar", StringUtil.LTrim( StringUtil.NToC( Z1562PedDDespachar, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1560PedDCanPendiente", StringUtil.LTrim( StringUtil.NToC( Z1560PedDCanPendiente, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1552PedDSub", StringUtil.LTrim( StringUtil.NToC( Z1552PedDSub, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1551PedDTot", StringUtil.LTrim( StringUtil.NToC( Z1551PedDTot, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1561PedDDcto", StringUtil.LTrim( StringUtil.NToC( Z1561PedDDcto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1567PedDInafecto", StringUtil.LTrim( StringUtil.NToC( Z1567PedDInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1565PedDGratuito", StringUtil.LTrim( StringUtil.NToC( Z1565PedDGratuito, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1564PedDExonerado", StringUtil.LTrim( StringUtil.NToC( Z1564PedDExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1563PedDExonerada", StringUtil.LTrim( StringUtil.NToC( Z1563PedDExonerada, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1550PedDAfecto", StringUtil.LTrim( StringUtil.NToC( Z1550PedDAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1588PedDSelectivoPor", StringUtil.LTrim( StringUtil.NToC( Z1588PedDSelectivoPor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1585PedDSelectivo", StringUtil.LTrim( StringUtil.NToC( Z1585PedDSelectivo, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T002T25 */
         pr_default.execute(19, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         A55ProdDsc = T002T25_A55ProdDsc[0];
         A908ProdValICBPERD = T002T25_A908ProdValICBPERD[0];
         A907ProdValICBPER = T002T25_A907ProdValICBPER[0];
         A906ProdAfecICBPER = T002T25_A906ProdAfecICBPER[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1587PedDValSel',fld:'PEDDVALSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PEDCOD","{handler:'Valid_Pedcod',iparms:[{av:'A210PedCod',fld:'PEDCOD',pic:''},{av:'A1598PedICBPER',fld:'PEDICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PEDCOD",",oparms:[{av:'A1598PedICBPER',fld:'PEDICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_PEDDITEM","{handler:'Valid_Pedditem',iparms:[{av:'A1587PedDValSel',fld:'PEDDVALSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A210PedCod',fld:'PEDCOD',pic:''},{av:'A216PedDItem',fld:'PEDDITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PEDDITEM",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A1554PedDCan',fld:'PEDDCAN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1553PedDPre',fld:'PEDDPRE',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1574PedDPreInc',fld:'PEDDPREINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1555PedDDct',fld:'PEDDDCT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1556PedDDct2',fld:'PEDDDCT2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1558PedDCanDSP',fld:'PEDDCANDSP',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1559PedDCanFAC',fld:'PEDDCANFAC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1557PedDIna',fld:'PEDDINA',pic:'9'},{av:'A1573PedDPorSel',fld:'PEDDPORSEL',pic:'Z9.99'},{av:'A1575PedDRef1',fld:'PEDDREF1',pic:''},{av:'A1576PedDRef2',fld:'PEDDREF2',pic:''},{av:'A1577PedDRef3',fld:'PEDDREF3',pic:''},{av:'A1578PedDRef4',fld:'PEDDREF4',pic:''},{av:'A1579PedDRef5',fld:'PEDDREF5',pic:''},{av:'A1572PedDObs',fld:'PEDDOBS',pic:''},{av:'A1587PedDValSel',fld:'PEDDVALSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1598PedICBPER',fld:'PEDICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A1566PedDICBPER',fld:'PEDDICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1591PedDSubInc',fld:'PEDDSUBINC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1592PedDTotInc',fld:'PEDDTOTINC',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A1586PedDSelectivoValor',fld:'PEDDSELECTIVOVALOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1562PedDDespachar',fld:'PEDDDESPACHAR',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1560PedDCanPendiente',fld:'PEDDCANPENDIENTE',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1552PedDSub',fld:'PEDDSUB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1551PedDTot',fld:'PEDDTOT',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A1561PedDDcto',fld:'PEDDDCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1567PedDInafecto',fld:'PEDDINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1565PedDGratuito',fld:'PEDDGRATUITO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1564PedDExonerado',fld:'PEDDEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1563PedDExonerada',fld:'PEDDEXONERADA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1550PedDAfecto',fld:'PEDDAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1588PedDSelectivoPor',fld:'PEDDSELECTIVOPOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1585PedDSelectivo',fld:'PEDDSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z210PedCod'},{av:'Z216PedDItem'},{av:'Z28ProdCod'},{av:'Z1554PedDCan'},{av:'Z1553PedDPre'},{av:'Z1574PedDPreInc'},{av:'Z1555PedDDct'},{av:'Z1556PedDDct2'},{av:'Z1558PedDCanDSP'},{av:'Z1559PedDCanFAC'},{av:'Z1557PedDIna'},{av:'Z1573PedDPorSel'},{av:'Z1575PedDRef1'},{av:'Z1576PedDRef2'},{av:'Z1577PedDRef3'},{av:'Z1578PedDRef4'},{av:'Z1579PedDRef5'},{av:'Z1572PedDObs'},{av:'Z1587PedDValSel'},{av:'Z1598PedICBPER'},{av:'Z180MonCod'},{av:'Z55ProdDsc'},{av:'Z908ProdValICBPERD'},{av:'Z907ProdValICBPER'},{av:'Z906ProdAfecICBPER'},{av:'Z1566PedDICBPER'},{av:'Z1591PedDSubInc'},{av:'Z1592PedDTotInc'},{av:'Z1586PedDSelectivoValor'},{av:'Z1562PedDDespachar'},{av:'Z1560PedDCanPendiente'},{av:'Z1552PedDSub'},{av:'Z1551PedDTot'},{av:'Z1561PedDDcto'},{av:'Z1567PedDInafecto'},{av:'Z1565PedDGratuito'},{av:'Z1564PedDExonerado'},{av:'Z1563PedDExonerada'},{av:'Z1550PedDAfecto'},{av:'Z1588PedDSelectivoPor'},{av:'Z1585PedDSelectivo'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'}]}");
         setEventMetadata("VALID_PEDDCAN","{handler:'Valid_Peddcan',iparms:[]");
         setEventMetadata("VALID_PEDDCAN",",oparms:[]}");
         setEventMetadata("VALID_PEDDPRE","{handler:'Valid_Peddpre',iparms:[]");
         setEventMetadata("VALID_PEDDPRE",",oparms:[]}");
         setEventMetadata("VALID_PEDDPREINC","{handler:'Valid_Peddpreinc',iparms:[]");
         setEventMetadata("VALID_PEDDPREINC",",oparms:[]}");
         setEventMetadata("VALID_PEDDDCT","{handler:'Valid_Pedddct',iparms:[]");
         setEventMetadata("VALID_PEDDDCT",",oparms:[]}");
         setEventMetadata("VALID_PEDDDCT2","{handler:'Valid_Pedddct2',iparms:[]");
         setEventMetadata("VALID_PEDDDCT2",",oparms:[]}");
         setEventMetadata("VALID_PEDDCANDSP","{handler:'Valid_Peddcandsp',iparms:[]");
         setEventMetadata("VALID_PEDDCANDSP",",oparms:[]}");
         setEventMetadata("VALID_PEDDINA","{handler:'Valid_Peddina',iparms:[]");
         setEventMetadata("VALID_PEDDINA",",oparms:[]}");
         setEventMetadata("VALID_PEDDPORSEL","{handler:'Valid_Peddporsel',iparms:[]");
         setEventMetadata("VALID_PEDDPORSEL",",oparms:[]}");
         setEventMetadata("VALID_PEDDSUB","{handler:'Valid_Peddsub',iparms:[]");
         setEventMetadata("VALID_PEDDSUB",",oparms:[]}");
         setEventMetadata("VALID_PEDDTOT","{handler:'Valid_Peddtot',iparms:[]");
         setEventMetadata("VALID_PEDDTOT",",oparms:[]}");
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
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z210PedCod = "";
         Z1575PedDRef1 = "";
         Z1576PedDRef2 = "";
         Z1577PedDRef3 = "";
         Z1578PedDRef4 = "";
         Z1579PedDRef5 = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A210PedCod = "";
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
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A55ProdDsc = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1575PedDRef1 = "";
         lblTextblock16_Jsonclick = "";
         A1576PedDRef2 = "";
         lblTextblock17_Jsonclick = "";
         A1577PedDRef3 = "";
         lblTextblock18_Jsonclick = "";
         A1578PedDRef4 = "";
         lblTextblock19_Jsonclick = "";
         A1579PedDRef5 = "";
         lblTextblock20_Jsonclick = "";
         A1572PedDObs = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
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
         Z55ProdDsc = "";
         Z1572PedDObs = "";
         T002T9_A1598PedICBPER = new decimal[1] ;
         T002T9_n1598PedICBPER = new bool[] {false} ;
         T002T9_A1551PedDTot = new decimal[1] ;
         T002T9_A1592PedDTotInc = new decimal[1] ;
         T002T9_A1566PedDICBPER = new decimal[1] ;
         T002T9_A216PedDItem = new short[1] ;
         T002T9_A1554PedDCan = new decimal[1] ;
         T002T9_A1553PedDPre = new decimal[1] ;
         T002T9_A1574PedDPreInc = new decimal[1] ;
         T002T9_A1555PedDDct = new decimal[1] ;
         T002T9_A1556PedDDct2 = new decimal[1] ;
         T002T9_A1558PedDCanDSP = new decimal[1] ;
         T002T9_A1559PedDCanFAC = new decimal[1] ;
         T002T9_A55ProdDsc = new string[] {""} ;
         T002T9_A1557PedDIna = new short[1] ;
         T002T9_A1573PedDPorSel = new decimal[1] ;
         T002T9_A1575PedDRef1 = new string[] {""} ;
         T002T9_A1576PedDRef2 = new string[] {""} ;
         T002T9_A1577PedDRef3 = new string[] {""} ;
         T002T9_A1578PedDRef4 = new string[] {""} ;
         T002T9_A1579PedDRef5 = new string[] {""} ;
         T002T9_A1572PedDObs = new string[] {""} ;
         T002T9_A1587PedDValSel = new decimal[1] ;
         T002T9_A908ProdValICBPERD = new decimal[1] ;
         T002T9_A907ProdValICBPER = new decimal[1] ;
         T002T9_A906ProdAfecICBPER = new short[1] ;
         T002T9_A210PedCod = new string[] {""} ;
         T002T9_A28ProdCod = new string[] {""} ;
         T002T9_A180MonCod = new int[1] ;
         T002T7_A1598PedICBPER = new decimal[1] ;
         T002T7_n1598PedICBPER = new bool[] {false} ;
         T002T7_A180MonCod = new int[1] ;
         T002T8_A55ProdDsc = new string[] {""} ;
         T002T8_A908ProdValICBPERD = new decimal[1] ;
         T002T8_A907ProdValICBPER = new decimal[1] ;
         T002T8_A906ProdAfecICBPER = new short[1] ;
         T002T10_A55ProdDsc = new string[] {""} ;
         T002T10_A908ProdValICBPERD = new decimal[1] ;
         T002T10_A907ProdValICBPER = new decimal[1] ;
         T002T10_A906ProdAfecICBPER = new short[1] ;
         T002T11_A210PedCod = new string[] {""} ;
         T002T11_A216PedDItem = new short[1] ;
         T002T3_A1551PedDTot = new decimal[1] ;
         T002T3_A1592PedDTotInc = new decimal[1] ;
         T002T3_A1566PedDICBPER = new decimal[1] ;
         T002T3_A216PedDItem = new short[1] ;
         T002T3_A1554PedDCan = new decimal[1] ;
         T002T3_A1553PedDPre = new decimal[1] ;
         T002T3_A1574PedDPreInc = new decimal[1] ;
         T002T3_A1555PedDDct = new decimal[1] ;
         T002T3_A1556PedDDct2 = new decimal[1] ;
         T002T3_A1558PedDCanDSP = new decimal[1] ;
         T002T3_A1559PedDCanFAC = new decimal[1] ;
         T002T3_A1557PedDIna = new short[1] ;
         T002T3_A1573PedDPorSel = new decimal[1] ;
         T002T3_A1575PedDRef1 = new string[] {""} ;
         T002T3_A1576PedDRef2 = new string[] {""} ;
         T002T3_A1577PedDRef3 = new string[] {""} ;
         T002T3_A1578PedDRef4 = new string[] {""} ;
         T002T3_A1579PedDRef5 = new string[] {""} ;
         T002T3_A1572PedDObs = new string[] {""} ;
         T002T3_A1587PedDValSel = new decimal[1] ;
         T002T3_A210PedCod = new string[] {""} ;
         T002T3_A28ProdCod = new string[] {""} ;
         T002T3_A55ProdDsc = new string[] {""} ;
         sMode96 = "";
         T002T12_A216PedDItem = new short[1] ;
         T002T12_A210PedCod = new string[] {""} ;
         T002T13_A216PedDItem = new short[1] ;
         T002T13_A210PedCod = new string[] {""} ;
         T002T2_A1551PedDTot = new decimal[1] ;
         T002T2_A1592PedDTotInc = new decimal[1] ;
         T002T2_A1566PedDICBPER = new decimal[1] ;
         T002T2_A216PedDItem = new short[1] ;
         T002T2_A1554PedDCan = new decimal[1] ;
         T002T2_A1553PedDPre = new decimal[1] ;
         T002T2_A1574PedDPreInc = new decimal[1] ;
         T002T2_A1555PedDDct = new decimal[1] ;
         T002T2_A1556PedDDct2 = new decimal[1] ;
         T002T2_A1558PedDCanDSP = new decimal[1] ;
         T002T2_A1559PedDCanFAC = new decimal[1] ;
         T002T2_A1557PedDIna = new short[1] ;
         T002T2_A1573PedDPorSel = new decimal[1] ;
         T002T2_A1575PedDRef1 = new string[] {""} ;
         T002T2_A1576PedDRef2 = new string[] {""} ;
         T002T2_A1577PedDRef3 = new string[] {""} ;
         T002T2_A1578PedDRef4 = new string[] {""} ;
         T002T2_A1579PedDRef5 = new string[] {""} ;
         T002T2_A1572PedDObs = new string[] {""} ;
         T002T2_A1587PedDValSel = new decimal[1] ;
         T002T2_A210PedCod = new string[] {""} ;
         T002T2_A28ProdCod = new string[] {""} ;
         T002T2_A55ProdDsc = new string[] {""} ;
         T002T14_A1598PedICBPER = new decimal[1] ;
         T002T14_n1598PedICBPER = new bool[] {false} ;
         T002T14_A180MonCod = new int[1] ;
         T002T17_A1598PedICBPER = new decimal[1] ;
         T002T17_n1598PedICBPER = new bool[] {false} ;
         T002T20_A1598PedICBPER = new decimal[1] ;
         T002T20_n1598PedICBPER = new bool[] {false} ;
         T002T23_A1598PedICBPER = new decimal[1] ;
         T002T23_n1598PedICBPER = new bool[] {false} ;
         T002T24_A1598PedICBPER = new decimal[1] ;
         T002T24_n1598PedICBPER = new bool[] {false} ;
         T002T24_A180MonCod = new int[1] ;
         T002T25_A55ProdDsc = new string[] {""} ;
         T002T25_A908ProdValICBPERD = new decimal[1] ;
         T002T25_A907ProdValICBPER = new decimal[1] ;
         T002T25_A906ProdAfecICBPER = new short[1] ;
         T002T27_A210PedCod = new string[] {""} ;
         T002T27_A216PedDItem = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ210PedCod = "";
         ZZ28ProdCod = "";
         ZZ1575PedDRef1 = "";
         ZZ1576PedDRef2 = "";
         ZZ1577PedDRef3 = "";
         ZZ1578PedDRef4 = "";
         ZZ1579PedDRef5 = "";
         ZZ1572PedDObs = "";
         ZZ55ProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clpedidosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpedidosdet__default(),
            new Object[][] {
                new Object[] {
               T002T2_A1551PedDTot, T002T2_A1592PedDTotInc, T002T2_A1566PedDICBPER, T002T2_A216PedDItem, T002T2_A1554PedDCan, T002T2_A1553PedDPre, T002T2_A1574PedDPreInc, T002T2_A1555PedDDct, T002T2_A1556PedDDct2, T002T2_A1558PedDCanDSP,
               T002T2_A1559PedDCanFAC, T002T2_A1557PedDIna, T002T2_A1573PedDPorSel, T002T2_A1575PedDRef1, T002T2_A1576PedDRef2, T002T2_A1577PedDRef3, T002T2_A1578PedDRef4, T002T2_A1579PedDRef5, T002T2_A1572PedDObs, T002T2_A1587PedDValSel,
               T002T2_A210PedCod, T002T2_A28ProdCod, T002T2_A55ProdDsc
               }
               , new Object[] {
               T002T3_A1551PedDTot, T002T3_A1592PedDTotInc, T002T3_A1566PedDICBPER, T002T3_A216PedDItem, T002T3_A1554PedDCan, T002T3_A1553PedDPre, T002T3_A1574PedDPreInc, T002T3_A1555PedDDct, T002T3_A1556PedDDct2, T002T3_A1558PedDCanDSP,
               T002T3_A1559PedDCanFAC, T002T3_A1557PedDIna, T002T3_A1573PedDPorSel, T002T3_A1575PedDRef1, T002T3_A1576PedDRef2, T002T3_A1577PedDRef3, T002T3_A1578PedDRef4, T002T3_A1579PedDRef5, T002T3_A1572PedDObs, T002T3_A1587PedDValSel,
               T002T3_A210PedCod, T002T3_A28ProdCod, T002T3_A55ProdDsc
               }
               , new Object[] {
               T002T5_A1598PedICBPER, T002T5_n1598PedICBPER
               }
               , new Object[] {
               T002T6_A1598PedICBPER, T002T6_A180MonCod
               }
               , new Object[] {
               T002T7_A1598PedICBPER, T002T7_A180MonCod
               }
               , new Object[] {
               T002T8_A55ProdDsc, T002T8_A908ProdValICBPERD, T002T8_A907ProdValICBPER, T002T8_A906ProdAfecICBPER
               }
               , new Object[] {
               T002T9_A1598PedICBPER, T002T9_A1551PedDTot, T002T9_A1592PedDTotInc, T002T9_A1566PedDICBPER, T002T9_A216PedDItem, T002T9_A1554PedDCan, T002T9_A1553PedDPre, T002T9_A1574PedDPreInc, T002T9_A1555PedDDct, T002T9_A1556PedDDct2,
               T002T9_A1558PedDCanDSP, T002T9_A1559PedDCanFAC, T002T9_A55ProdDsc, T002T9_A1557PedDIna, T002T9_A1573PedDPorSel, T002T9_A1575PedDRef1, T002T9_A1576PedDRef2, T002T9_A1577PedDRef3, T002T9_A1578PedDRef4, T002T9_A1579PedDRef5,
               T002T9_A1572PedDObs, T002T9_A1587PedDValSel, T002T9_A908ProdValICBPERD, T002T9_A907ProdValICBPER, T002T9_A906ProdAfecICBPER, T002T9_A210PedCod, T002T9_A28ProdCod, T002T9_A180MonCod
               }
               , new Object[] {
               T002T10_A55ProdDsc, T002T10_A908ProdValICBPERD, T002T10_A907ProdValICBPER, T002T10_A906ProdAfecICBPER
               }
               , new Object[] {
               T002T11_A210PedCod, T002T11_A216PedDItem
               }
               , new Object[] {
               T002T12_A216PedDItem, T002T12_A210PedCod
               }
               , new Object[] {
               T002T13_A216PedDItem, T002T13_A210PedCod
               }
               , new Object[] {
               T002T14_A1598PedICBPER, T002T14_A180MonCod
               }
               , new Object[] {
               }
               , new Object[] {
               T002T17_A1598PedICBPER, T002T17_n1598PedICBPER
               }
               , new Object[] {
               }
               , new Object[] {
               T002T20_A1598PedICBPER, T002T20_n1598PedICBPER
               }
               , new Object[] {
               }
               , new Object[] {
               T002T23_A1598PedICBPER, T002T23_n1598PedICBPER
               }
               , new Object[] {
               T002T24_A1598PedICBPER, T002T24_A180MonCod
               }
               , new Object[] {
               T002T25_A55ProdDsc, T002T25_A908ProdValICBPERD, T002T25_A907ProdValICBPER, T002T25_A906ProdAfecICBPER
               }
               , new Object[] {
               }
               , new Object[] {
               T002T27_A210PedCod, T002T27_A216PedDItem
               }
            }
         );
      }

      private short Z216PedDItem ;
      private short Z1557PedDIna ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A216PedDItem ;
      private short A1557PedDIna ;
      private short A906ProdAfecICBPER ;
      private short GX_JID ;
      private short Z906ProdAfecICBPER ;
      private short RcdFound96 ;
      private short nIsDirty_96 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ216PedDItem ;
      private short ZZ1557PedDIna ;
      private short ZZ906ProdAfecICBPER ;
      private int Z180MonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPedCod_Enabled ;
      private int edtPedDItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtPedDCan_Enabled ;
      private int edtPedDPre_Enabled ;
      private int edtPedDPreInc_Enabled ;
      private int edtPedDDct_Enabled ;
      private int edtPedDDct2_Enabled ;
      private int edtPedDCanDSP_Enabled ;
      private int edtPedDCanFAC_Enabled ;
      private int edtPedDCanPendiente_Enabled ;
      private int edtProdDsc_Enabled ;
      private int edtPedDIna_Enabled ;
      private int edtPedDPorSel_Enabled ;
      private int edtPedDRef1_Enabled ;
      private int edtPedDRef2_Enabled ;
      private int edtPedDRef3_Enabled ;
      private int edtPedDRef4_Enabled ;
      private int edtPedDRef5_Enabled ;
      private int edtPedDObs_Enabled ;
      private int edtPedDDespachar_Enabled ;
      private int edtPedDInafecto_Enabled ;
      private int edtPedDAfecto_Enabled ;
      private int edtPedDSelectivo_Enabled ;
      private int edtPedDSub_Enabled ;
      private int edtPedDTot_Enabled ;
      private int edtPedDDcto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A180MonCod ;
      private int idxLst ;
      private int ZZ180MonCod ;
      private decimal Z1551PedDTot ;
      private decimal Z1592PedDTotInc ;
      private decimal Z1566PedDICBPER ;
      private decimal Z1554PedDCan ;
      private decimal Z1553PedDPre ;
      private decimal Z1574PedDPreInc ;
      private decimal Z1555PedDDct ;
      private decimal Z1556PedDDct2 ;
      private decimal Z1558PedDCanDSP ;
      private decimal Z1559PedDCanFAC ;
      private decimal Z1573PedDPorSel ;
      private decimal Z1587PedDValSel ;
      private decimal Z1598PedICBPER ;
      private decimal A1554PedDCan ;
      private decimal A1553PedDPre ;
      private decimal A1574PedDPreInc ;
      private decimal A1555PedDDct ;
      private decimal A1556PedDDct2 ;
      private decimal A1558PedDCanDSP ;
      private decimal A1559PedDCanFAC ;
      private decimal A1560PedDCanPendiente ;
      private decimal A1573PedDPorSel ;
      private decimal A1562PedDDespachar ;
      private decimal A1567PedDInafecto ;
      private decimal A1550PedDAfecto ;
      private decimal A1585PedDSelectivo ;
      private decimal A1552PedDSub ;
      private decimal A1551PedDTot ;
      private decimal A1561PedDDcto ;
      private decimal A1592PedDTotInc ;
      private decimal A1566PedDICBPER ;
      private decimal A1587PedDValSel ;
      private decimal A1598PedICBPER ;
      private decimal A1591PedDSubInc ;
      private decimal A1586PedDSelectivoValor ;
      private decimal A907ProdValICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal A1565PedDGratuito ;
      private decimal A1564PedDExonerado ;
      private decimal A1563PedDExonerada ;
      private decimal A1588PedDSelectivoPor ;
      private decimal Z908ProdValICBPERD ;
      private decimal Z907ProdValICBPER ;
      private decimal Z1591PedDSubInc ;
      private decimal Z1586PedDSelectivoValor ;
      private decimal Z1562PedDDespachar ;
      private decimal Z1560PedDCanPendiente ;
      private decimal Z1552PedDSub ;
      private decimal Z1561PedDDcto ;
      private decimal Z1567PedDInafecto ;
      private decimal Z1565PedDGratuito ;
      private decimal Z1564PedDExonerado ;
      private decimal Z1563PedDExonerada ;
      private decimal Z1550PedDAfecto ;
      private decimal Z1588PedDSelectivoPor ;
      private decimal Z1585PedDSelectivo ;
      private decimal ZZ1554PedDCan ;
      private decimal ZZ1553PedDPre ;
      private decimal ZZ1574PedDPreInc ;
      private decimal ZZ1555PedDDct ;
      private decimal ZZ1556PedDDct2 ;
      private decimal ZZ1558PedDCanDSP ;
      private decimal ZZ1559PedDCanFAC ;
      private decimal ZZ1573PedDPorSel ;
      private decimal ZZ1587PedDValSel ;
      private decimal ZZ1598PedICBPER ;
      private decimal ZZ908ProdValICBPERD ;
      private decimal ZZ907ProdValICBPER ;
      private decimal ZZ1566PedDICBPER ;
      private decimal ZZ1591PedDSubInc ;
      private decimal ZZ1592PedDTotInc ;
      private decimal ZZ1586PedDSelectivoValor ;
      private decimal ZZ1562PedDDespachar ;
      private decimal ZZ1560PedDCanPendiente ;
      private decimal ZZ1552PedDSub ;
      private decimal ZZ1551PedDTot ;
      private decimal ZZ1561PedDDcto ;
      private decimal ZZ1567PedDInafecto ;
      private decimal ZZ1565PedDGratuito ;
      private decimal ZZ1564PedDExonerado ;
      private decimal ZZ1563PedDExonerada ;
      private decimal ZZ1550PedDAfecto ;
      private decimal ZZ1588PedDSelectivoPor ;
      private decimal ZZ1585PedDSelectivo ;
      private string sPrefix ;
      private string Z210PedCod ;
      private string Z1575PedDRef1 ;
      private string Z1576PedDRef2 ;
      private string Z1577PedDRef3 ;
      private string Z1578PedDRef4 ;
      private string Z1579PedDRef5 ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A210PedCod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPedCod_Internalname ;
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
      private string edtPedCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPedDItem_Internalname ;
      private string edtPedDItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPedDCan_Internalname ;
      private string edtPedDCan_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPedDPre_Internalname ;
      private string edtPedDPre_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPedDPreInc_Internalname ;
      private string edtPedDPreInc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPedDDct_Internalname ;
      private string edtPedDDct_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPedDDct2_Internalname ;
      private string edtPedDDct2_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPedDCanDSP_Internalname ;
      private string edtPedDCanDSP_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPedDCanFAC_Internalname ;
      private string edtPedDCanFAC_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtPedDCanPendiente_Internalname ;
      private string edtPedDCanPendiente_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtPedDIna_Internalname ;
      private string edtPedDIna_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtPedDPorSel_Internalname ;
      private string edtPedDPorSel_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtPedDRef1_Internalname ;
      private string A1575PedDRef1 ;
      private string edtPedDRef1_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtPedDRef2_Internalname ;
      private string A1576PedDRef2 ;
      private string edtPedDRef2_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtPedDRef3_Internalname ;
      private string A1577PedDRef3 ;
      private string edtPedDRef3_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtPedDRef4_Internalname ;
      private string A1578PedDRef4 ;
      private string edtPedDRef4_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtPedDRef5_Internalname ;
      private string A1579PedDRef5 ;
      private string edtPedDRef5_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtPedDObs_Internalname ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtPedDDespachar_Internalname ;
      private string edtPedDDespachar_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtPedDInafecto_Internalname ;
      private string edtPedDInafecto_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtPedDAfecto_Internalname ;
      private string edtPedDAfecto_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtPedDSelectivo_Internalname ;
      private string edtPedDSelectivo_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtPedDSub_Internalname ;
      private string edtPedDSub_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtPedDTot_Internalname ;
      private string edtPedDTot_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtPedDDcto_Internalname ;
      private string edtPedDDcto_Jsonclick ;
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
      private string sMode96 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ210PedCod ;
      private string ZZ28ProdCod ;
      private string ZZ1575PedDRef1 ;
      private string ZZ1576PedDRef2 ;
      private string ZZ1577PedDRef3 ;
      private string ZZ1578PedDRef4 ;
      private string ZZ1579PedDRef5 ;
      private string ZZ55ProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1598PedICBPER ;
      private bool Gx_longc ;
      private string A1572PedDObs ;
      private string Z1572PedDObs ;
      private string ZZ1572PedDObs ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T002T9_A1598PedICBPER ;
      private bool[] T002T9_n1598PedICBPER ;
      private decimal[] T002T9_A1551PedDTot ;
      private decimal[] T002T9_A1592PedDTotInc ;
      private decimal[] T002T9_A1566PedDICBPER ;
      private short[] T002T9_A216PedDItem ;
      private decimal[] T002T9_A1554PedDCan ;
      private decimal[] T002T9_A1553PedDPre ;
      private decimal[] T002T9_A1574PedDPreInc ;
      private decimal[] T002T9_A1555PedDDct ;
      private decimal[] T002T9_A1556PedDDct2 ;
      private decimal[] T002T9_A1558PedDCanDSP ;
      private decimal[] T002T9_A1559PedDCanFAC ;
      private string[] T002T9_A55ProdDsc ;
      private short[] T002T9_A1557PedDIna ;
      private decimal[] T002T9_A1573PedDPorSel ;
      private string[] T002T9_A1575PedDRef1 ;
      private string[] T002T9_A1576PedDRef2 ;
      private string[] T002T9_A1577PedDRef3 ;
      private string[] T002T9_A1578PedDRef4 ;
      private string[] T002T9_A1579PedDRef5 ;
      private string[] T002T9_A1572PedDObs ;
      private decimal[] T002T9_A1587PedDValSel ;
      private decimal[] T002T9_A908ProdValICBPERD ;
      private decimal[] T002T9_A907ProdValICBPER ;
      private short[] T002T9_A906ProdAfecICBPER ;
      private string[] T002T9_A210PedCod ;
      private string[] T002T9_A28ProdCod ;
      private int[] T002T9_A180MonCod ;
      private decimal[] T002T7_A1598PedICBPER ;
      private bool[] T002T7_n1598PedICBPER ;
      private int[] T002T7_A180MonCod ;
      private string[] T002T8_A55ProdDsc ;
      private decimal[] T002T8_A908ProdValICBPERD ;
      private decimal[] T002T8_A907ProdValICBPER ;
      private short[] T002T8_A906ProdAfecICBPER ;
      private string[] T002T10_A55ProdDsc ;
      private decimal[] T002T10_A908ProdValICBPERD ;
      private decimal[] T002T10_A907ProdValICBPER ;
      private short[] T002T10_A906ProdAfecICBPER ;
      private string[] T002T11_A210PedCod ;
      private short[] T002T11_A216PedDItem ;
      private decimal[] T002T3_A1551PedDTot ;
      private decimal[] T002T3_A1592PedDTotInc ;
      private decimal[] T002T3_A1566PedDICBPER ;
      private short[] T002T3_A216PedDItem ;
      private decimal[] T002T3_A1554PedDCan ;
      private decimal[] T002T3_A1553PedDPre ;
      private decimal[] T002T3_A1574PedDPreInc ;
      private decimal[] T002T3_A1555PedDDct ;
      private decimal[] T002T3_A1556PedDDct2 ;
      private decimal[] T002T3_A1558PedDCanDSP ;
      private decimal[] T002T3_A1559PedDCanFAC ;
      private short[] T002T3_A1557PedDIna ;
      private decimal[] T002T3_A1573PedDPorSel ;
      private string[] T002T3_A1575PedDRef1 ;
      private string[] T002T3_A1576PedDRef2 ;
      private string[] T002T3_A1577PedDRef3 ;
      private string[] T002T3_A1578PedDRef4 ;
      private string[] T002T3_A1579PedDRef5 ;
      private string[] T002T3_A1572PedDObs ;
      private decimal[] T002T3_A1587PedDValSel ;
      private string[] T002T3_A210PedCod ;
      private string[] T002T3_A28ProdCod ;
      private string[] T002T3_A55ProdDsc ;
      private short[] T002T12_A216PedDItem ;
      private string[] T002T12_A210PedCod ;
      private short[] T002T13_A216PedDItem ;
      private string[] T002T13_A210PedCod ;
      private decimal[] T002T2_A1551PedDTot ;
      private decimal[] T002T2_A1592PedDTotInc ;
      private decimal[] T002T2_A1566PedDICBPER ;
      private short[] T002T2_A216PedDItem ;
      private decimal[] T002T2_A1554PedDCan ;
      private decimal[] T002T2_A1553PedDPre ;
      private decimal[] T002T2_A1574PedDPreInc ;
      private decimal[] T002T2_A1555PedDDct ;
      private decimal[] T002T2_A1556PedDDct2 ;
      private decimal[] T002T2_A1558PedDCanDSP ;
      private decimal[] T002T2_A1559PedDCanFAC ;
      private short[] T002T2_A1557PedDIna ;
      private decimal[] T002T2_A1573PedDPorSel ;
      private string[] T002T2_A1575PedDRef1 ;
      private string[] T002T2_A1576PedDRef2 ;
      private string[] T002T2_A1577PedDRef3 ;
      private string[] T002T2_A1578PedDRef4 ;
      private string[] T002T2_A1579PedDRef5 ;
      private string[] T002T2_A1572PedDObs ;
      private decimal[] T002T2_A1587PedDValSel ;
      private string[] T002T2_A210PedCod ;
      private string[] T002T2_A28ProdCod ;
      private string[] T002T2_A55ProdDsc ;
      private decimal[] T002T14_A1598PedICBPER ;
      private bool[] T002T14_n1598PedICBPER ;
      private int[] T002T14_A180MonCod ;
      private decimal[] T002T17_A1598PedICBPER ;
      private bool[] T002T17_n1598PedICBPER ;
      private decimal[] T002T20_A1598PedICBPER ;
      private bool[] T002T20_n1598PedICBPER ;
      private decimal[] T002T23_A1598PedICBPER ;
      private bool[] T002T23_n1598PedICBPER ;
      private decimal[] T002T24_A1598PedICBPER ;
      private bool[] T002T24_n1598PedICBPER ;
      private int[] T002T24_A180MonCod ;
      private string[] T002T25_A55ProdDsc ;
      private decimal[] T002T25_A908ProdValICBPERD ;
      private decimal[] T002T25_A907ProdValICBPER ;
      private short[] T002T25_A906ProdAfecICBPER ;
      private string[] T002T27_A210PedCod ;
      private short[] T002T27_A216PedDItem ;
      private IDataStoreProvider pr_datastore2 ;
      private decimal[] T002T5_A1598PedICBPER ;
      private decimal[] T002T6_A1598PedICBPER ;
      private int[] T002T6_A180MonCod ;
      private bool[] T002T5_n1598PedICBPER ;
      private GXWebForm Form ;
   }

   public class clpedidosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clpedidosdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002T5;
        prmT002T5 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T6;
        prmT002T6 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T9;
        prmT002T9 = new Object[] {
        new ParDef("@PedDItem",GXType.Int16,4,0) ,
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T8;
        prmT002T8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002T7;
        prmT002T7 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T10;
        prmT002T10 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002T11;
        prmT002T11 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@PedDItem",GXType.Int16,4,0)
        };
        Object[] prmT002T3;
        prmT002T3 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@PedDItem",GXType.Int16,4,0)
        };
        Object[] prmT002T12;
        prmT002T12 = new Object[] {
        new ParDef("@PedDItem",GXType.Int16,4,0) ,
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T13;
        prmT002T13 = new Object[] {
        new ParDef("@PedDItem",GXType.Int16,4,0) ,
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T2;
        prmT002T2 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@PedDItem",GXType.Int16,4,0)
        };
        Object[] prmT002T14;
        prmT002T14 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T15;
        prmT002T15 = new Object[] {
        new ParDef("@ProdDsc",GXType.NChar,100,0) ,
        new ParDef("@PedDTot",GXType.Decimal,18,8) ,
        new ParDef("@PedDTotInc",GXType.Decimal,15,4) ,
        new ParDef("@PedDICBPER",GXType.Decimal,15,2) ,
        new ParDef("@PedDItem",GXType.Int16,4,0) ,
        new ParDef("@PedDCan",GXType.Decimal,15,4) ,
        new ParDef("@PedDPre",GXType.Decimal,15,4) ,
        new ParDef("@PedDPreInc",GXType.Decimal,15,4) ,
        new ParDef("@PedDDct",GXType.Decimal,15,2) ,
        new ParDef("@PedDDct2",GXType.Decimal,15,2) ,
        new ParDef("@PedDCanDSP",GXType.Decimal,15,4) ,
        new ParDef("@PedDCanFAC",GXType.Decimal,15,4) ,
        new ParDef("@PedDIna",GXType.Int16,1,0) ,
        new ParDef("@PedDPorSel",GXType.Decimal,5,2) ,
        new ParDef("@PedDRef1",GXType.NChar,20,0) ,
        new ParDef("@PedDRef2",GXType.NChar,20,0) ,
        new ParDef("@PedDRef3",GXType.NChar,20,0) ,
        new ParDef("@PedDRef4",GXType.NChar,20,0) ,
        new ParDef("@PedDRef5",GXType.NChar,20,0) ,
        new ParDef("@PedDObs",GXType.NVarChar,500,0) ,
        new ParDef("@PedDValSel",GXType.Decimal,15,2) ,
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002T17;
        prmT002T17 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T18;
        prmT002T18 = new Object[] {
        new ParDef("@ProdDsc",GXType.NChar,100,0) ,
        new ParDef("@PedDTot",GXType.Decimal,18,8) ,
        new ParDef("@PedDTotInc",GXType.Decimal,15,4) ,
        new ParDef("@PedDICBPER",GXType.Decimal,15,2) ,
        new ParDef("@PedDCan",GXType.Decimal,15,4) ,
        new ParDef("@PedDPre",GXType.Decimal,15,4) ,
        new ParDef("@PedDPreInc",GXType.Decimal,15,4) ,
        new ParDef("@PedDDct",GXType.Decimal,15,2) ,
        new ParDef("@PedDDct2",GXType.Decimal,15,2) ,
        new ParDef("@PedDCanDSP",GXType.Decimal,15,4) ,
        new ParDef("@PedDCanFAC",GXType.Decimal,15,4) ,
        new ParDef("@PedDIna",GXType.Int16,1,0) ,
        new ParDef("@PedDPorSel",GXType.Decimal,5,2) ,
        new ParDef("@PedDRef1",GXType.NChar,20,0) ,
        new ParDef("@PedDRef2",GXType.NChar,20,0) ,
        new ParDef("@PedDRef3",GXType.NChar,20,0) ,
        new ParDef("@PedDRef4",GXType.NChar,20,0) ,
        new ParDef("@PedDRef5",GXType.NChar,20,0) ,
        new ParDef("@PedDObs",GXType.NVarChar,500,0) ,
        new ParDef("@PedDValSel",GXType.Decimal,15,2) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@PedDItem",GXType.Int16,4,0)
        };
        Object[] prmT002T20;
        prmT002T20 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T21;
        prmT002T21 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@PedDItem",GXType.Int16,4,0)
        };
        Object[] prmT002T23;
        prmT002T23 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T26;
        prmT002T26 = new Object[] {
        new ParDef("@PedICBPER",GXType.Decimal,15,2){Nullable=true} ,
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T27;
        prmT002T27 = new Object[] {
        };
        Object[] prmT002T24;
        prmT002T24 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002T25;
        prmT002T25 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002T2", "SELECT [PedDTot], [PedDTotInc], [PedDICBPER], [PedDItem], [PedDCan], [PedDPre], [PedDPreInc], [PedDDct], [PedDDct2], [PedDCanDSP], [PedDCanFAC], [PedDIna], [PedDPorSel], [PedDRef1], [PedDRef2], [PedDRef3], [PedDRef4], [PedDRef5], [PedDObs], [PedDValSel], [PedCod], [ProdCod], [ProdDsc] FROM [CLPEDIDOSDET] WITH (UPDLOCK) WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T3", "SELECT [PedDTot], [PedDTotInc], [PedDICBPER], [PedDItem], [PedDCan], [PedDPre], [PedDPreInc], [PedDDct], [PedDDct2], [PedDCanDSP], [PedDCanFAC], [PedDIna], [PedDPorSel], [PedDRef1], [PedDRef2], [PedDRef3], [PedDRef4], [PedDRef5], [PedDObs], [PedDValSel], [PedCod], [ProdCod], [ProdDsc] FROM [CLPEDIDOSDET] WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T5", "SELECT T1.[PedICBPER] FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod] FROM [CLPEDIDOSDET] WITH (UPDLOCK) GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T6", "SELECT [PedICBPER], [MonCod] FROM [CLPEDIDOS] WITH (UPDLOCK) WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T7", "SELECT [PedICBPER], [MonCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T8", "SELECT [ProdDsc], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T9", "SELECT T2.[PedICBPER], TM1.[PedDTot], TM1.[PedDTotInc], TM1.[PedDICBPER], TM1.[PedDItem], TM1.[PedDCan], TM1.[PedDPre], TM1.[PedDPreInc], TM1.[PedDDct], TM1.[PedDDct2], TM1.[PedDCanDSP], TM1.[PedDCanFAC], TM1.[ProdDsc], TM1.[PedDIna], TM1.[PedDPorSel], TM1.[PedDRef1], TM1.[PedDRef2], TM1.[PedDRef3], TM1.[PedDRef4], TM1.[PedDRef5], TM1.[PedDObs], TM1.[PedDValSel], T3.[ProdValICBPERD], T3.[ProdValICBPER], T3.[ProdAfecICBPER], TM1.[PedCod], TM1.[ProdCod], T2.[MonCod] FROM (([CLPEDIDOSDET] TM1 INNER JOIN [CLPEDIDOS] T2 ON T2.[PedCod] = TM1.[PedCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = TM1.[ProdCod]) WHERE TM1.[PedDItem] = @PedDItem and TM1.[PedCod] = @PedCod ORDER BY TM1.[PedCod], TM1.[PedDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T10", "SELECT [ProdDsc], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T11", "SELECT [PedCod], [PedDItem] FROM [CLPEDIDOSDET] WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T12", "SELECT TOP 1 [PedDItem], [PedCod] FROM [CLPEDIDOSDET] WHERE ( [PedDItem] > @PedDItem or [PedDItem] = @PedDItem and [PedCod] > @PedCod) ORDER BY [PedCod], [PedDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002T13", "SELECT TOP 1 [PedDItem], [PedCod] FROM [CLPEDIDOSDET] WHERE ( [PedDItem] < @PedDItem or [PedDItem] = @PedDItem and [PedCod] < @PedCod) ORDER BY [PedCod] DESC, [PedDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002T14", "SELECT [PedICBPER], [MonCod] FROM [CLPEDIDOS] WITH (UPDLOCK) WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T15", "INSERT INTO [CLPEDIDOSDET]([ProdDsc], [PedDTot], [PedDTotInc], [PedDICBPER], [PedDItem], [PedDCan], [PedDPre], [PedDPreInc], [PedDDct], [PedDDct2], [PedDCanDSP], [PedDCanFAC], [PedDIna], [PedDPorSel], [PedDRef1], [PedDRef2], [PedDRef3], [PedDRef4], [PedDRef5], [PedDObs], [PedDValSel], [PedCod], [ProdCod]) VALUES(@ProdDsc, @PedDTot, @PedDTotInc, @PedDICBPER, @PedDItem, @PedDCan, @PedDPre, @PedDPreInc, @PedDDct, @PedDDct2, @PedDCanDSP, @PedDCanFAC, @PedDIna, @PedDPorSel, @PedDRef1, @PedDRef2, @PedDRef3, @PedDRef4, @PedDRef5, @PedDObs, @PedDValSel, @PedCod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT002T15)
           ,new CursorDef("T002T17", "SELECT COALESCE( T1.[PedICBPER], 0) AS PedICBPER FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod] FROM [CLPEDIDOSDET] WITH (UPDLOCK) GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T18", "UPDATE [CLPEDIDOSDET] SET [ProdDsc]=@ProdDsc, [PedDTot]=@PedDTot, [PedDTotInc]=@PedDTotInc, [PedDICBPER]=@PedDICBPER, [PedDCan]=@PedDCan, [PedDPre]=@PedDPre, [PedDPreInc]=@PedDPreInc, [PedDDct]=@PedDDct, [PedDDct2]=@PedDDct2, [PedDCanDSP]=@PedDCanDSP, [PedDCanFAC]=@PedDCanFAC, [PedDIna]=@PedDIna, [PedDPorSel]=@PedDPorSel, [PedDRef1]=@PedDRef1, [PedDRef2]=@PedDRef2, [PedDRef3]=@PedDRef3, [PedDRef4]=@PedDRef4, [PedDRef5]=@PedDRef5, [PedDObs]=@PedDObs, [PedDValSel]=@PedDValSel, [ProdCod]=@ProdCod  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK,prmT002T18)
           ,new CursorDef("T002T20", "SELECT COALESCE( T1.[PedICBPER], 0) AS PedICBPER FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod] FROM [CLPEDIDOSDET] WITH (UPDLOCK) GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T21", "DELETE FROM [CLPEDIDOSDET]  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK,prmT002T21)
           ,new CursorDef("T002T23", "SELECT COALESCE( T1.[PedICBPER], 0) AS PedICBPER FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod] FROM [CLPEDIDOSDET] WITH (UPDLOCK) GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T24", "SELECT [PedICBPER], [MonCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T25", "SELECT [ProdDsc], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002T26", "UPDATE [CLPEDIDOS] SET [PedICBPER]=@PedICBPER  WHERE [PedCod] = @PedCod", GxErrorMask.GX_NOMASK,prmT002T26)
           ,new CursorDef("T002T27", "SELECT [PedCod], [PedDItem] FROM [CLPEDIDOSDET] ORDER BY [PedCod], [PedDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T27,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 10);
              ((string[]) buf[21])[0] = rslt.getString(22, 15);
              ((string[]) buf[22])[0] = rslt.getString(23, 100);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 10);
              ((string[]) buf[21])[0] = rslt.getString(22, 15);
              ((string[]) buf[22])[0] = rslt.getString(23, 100);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 100);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((string[]) buf[19])[0] = rslt.getString(20, 20);
              ((string[]) buf[20])[0] = rslt.getLongVarchar(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(23);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 10);
              ((string[]) buf[26])[0] = rslt.getString(27, 15);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 11 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 15 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 17 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 18 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
