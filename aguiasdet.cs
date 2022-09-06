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
   public class aguiasdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A13MvATip = GetPar( "MvATip");
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = GetPar( "MvACod");
            AssignAttri("", false, "A14MvACod", A14MvACod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A13MvATip, A14MvACod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A28ProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A52LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A52LinCod) ;
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
            Form.Meta.addItem("description", "Movimientos de Almacen - Detalles", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aguiasdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguiasdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AGUIASDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Mov. Almacen", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvATip_Internalname, StringUtil.RTrim( A13MvATip), StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvATip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvATip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Mov.Almacen", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvACod_Internalname, StringUtil.RTrim( A14MvACod), StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvACod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Descripcion producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cantidad", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvADCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1248MvADCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtMvADCant_Enabled!=0) ? context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvADCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvADCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Producto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Item", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvADItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30MvADItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtMvADItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A30MvADItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A30MvADItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvADItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvADItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Controla Stock", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLinStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtLinStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1158LinStk), "9") : context.localUtil.Format( (decimal)(A1158LinStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Precio de Venta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADVentaU_Internalname, StringUtil.LTrim( StringUtil.NToC( A1266MVADVentaU, 20, 6, ".", "")), StringUtil.LTrim( ((edtMVADVentaU_Enabled!=0) ? context.localUtil.Format( A1266MVADVentaU, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A1266MVADVentaU, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADVentaU_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADVentaU_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Total", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVADVentaT_Internalname, StringUtil.LTrim( StringUtil.NToC( A1265MVADVentaT, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVADVentaT_Enabled!=0) ? context.localUtil.Format( A1265MVADVentaT, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1265MVADVentaT, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADVentaT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADVentaT_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Referencia 1", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADRef1_Internalname, StringUtil.RTrim( A1258MVADRef1), StringUtil.RTrim( context.localUtil.Format( A1258MVADRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Referencia 2", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADRef2_Internalname, StringUtil.RTrim( A1259MVADRef2), StringUtil.RTrim( context.localUtil.Format( A1259MVADRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Referencia 3", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADRef3_Internalname, StringUtil.RTrim( A1260MVADRef3), StringUtil.RTrim( context.localUtil.Format( A1260MVADRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Referencia 4", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADRef4_Internalname, StringUtil.RTrim( A1261MVADRef4), StringUtil.RTrim( context.localUtil.Format( A1261MVADRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Referencia 5", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADRef5_Internalname, StringUtil.RTrim( A1262MVADRef5), StringUtil.RTrim( context.localUtil.Format( A1262MVADRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADRef5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Bultos", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADBultos_Internalname, StringUtil.LTrim( StringUtil.NToC( A1247MVADBultos, 17, 4, ".", "")), StringUtil.LTrim( ((edtMVADBultos_Enabled!=0) ? context.localUtil.Format( A1247MVADBultos, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1247MVADBultos, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADBultos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADBultos_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Cantidad Lotes", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADLote_Internalname, StringUtil.LTrim( StringUtil.NToC( A1253MVADLote, 17, 4, ".", "")), StringUtil.LTrim( ((edtMVADLote_Enabled!=0) ? context.localUtil.Format( A1253MVADLote, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1253MVADLote, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLote_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLote_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Estado Lote", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1263MVADSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtMVADSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1263MVADSts), "9") : context.localUtil.Format( (decimal)(A1263MVADSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Codigo Ubicación", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADUbi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1264MVADUbi), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVADUbi_Enabled!=0) ? context.localUtil.Format( (decimal)(A1264MVADUbi), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1264MVADUbi), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADUbi_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADUbi_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Comentario", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMVADObs_Internalname, A1257MVADObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", 0, 1, edtMVADObs_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Precio", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A1250MVADPrecio, 20, 6, ".", "")), StringUtil.LTrim( ((edtMVADPrecio_Enabled!=0) ? context.localUtil.Format( A1250MVADPrecio, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A1250MVADPrecio, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADPrecio_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Total Costo", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVADCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1249MVADCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVADCosto_Enabled!=0) ? context.localUtil.Format( A1249MVADCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1249MVADCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_AGUIASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_AGUIASDET.htm");
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
            Z13MvATip = cgiGet( "Z13MvATip");
            Z14MvACod = cgiGet( "Z14MvACod");
            Z30MvADItem = (int)(context.localUtil.CToN( cgiGet( "Z30MvADItem"), ".", ","));
            Z1249MVADCosto = context.localUtil.CToN( cgiGet( "Z1249MVADCosto"), ".", ",");
            Z1248MvADCant = context.localUtil.CToN( cgiGet( "Z1248MvADCant"), ".", ",");
            Z1266MVADVentaU = context.localUtil.CToN( cgiGet( "Z1266MVADVentaU"), ".", ",");
            Z1258MVADRef1 = cgiGet( "Z1258MVADRef1");
            Z1259MVADRef2 = cgiGet( "Z1259MVADRef2");
            Z1260MVADRef3 = cgiGet( "Z1260MVADRef3");
            Z1261MVADRef4 = cgiGet( "Z1261MVADRef4");
            Z1262MVADRef5 = cgiGet( "Z1262MVADRef5");
            Z1247MVADBultos = context.localUtil.CToN( cgiGet( "Z1247MVADBultos"), ".", ",");
            Z1253MVADLote = context.localUtil.CToN( cgiGet( "Z1253MVADLote"), ".", ",");
            Z1263MVADSts = (short)(context.localUtil.CToN( cgiGet( "Z1263MVADSts"), ".", ","));
            Z1264MVADUbi = (int)(context.localUtil.CToN( cgiGet( "Z1264MVADUbi"), ".", ","));
            n1264MVADUbi = ((0==A1264MVADUbi) ? true : false);
            Z1250MVADPrecio = context.localUtil.CToN( cgiGet( "Z1250MVADPrecio"), ".", ",");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A52LinCod = (int)(context.localUtil.CToN( cgiGet( "LINCOD"), ".", ","));
            /* Read variables values. */
            A13MvATip = cgiGet( edtMvATip_Internalname);
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = cgiGet( edtMvACod_Internalname);
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A55ProdDsc = cgiGet( edtProdDsc_Internalname);
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMvADCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMvADCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADCANT");
               AnyError = 1;
               GX_FocusControl = edtMvADCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1248MvADCant = 0;
               AssignAttri("", false, "A1248MvADCant", StringUtil.LTrimStr( A1248MvADCant, 15, 4));
            }
            else
            {
               A1248MvADCant = context.localUtil.CToN( cgiGet( edtMvADCant_Internalname), ".", ",");
               AssignAttri("", false, "A1248MvADCant", StringUtil.LTrimStr( A1248MvADCant, 15, 4));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMvADItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMvADItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADITEM");
               AnyError = 1;
               GX_FocusControl = edtMvADItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A30MvADItem = 0;
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            }
            else
            {
               A30MvADItem = (int)(context.localUtil.CToN( cgiGet( edtMvADItem_Internalname), ".", ","));
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            }
            A1158LinStk = (short)(context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ","));
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADVentaU_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADVentaU_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADVENTAU");
               AnyError = 1;
               GX_FocusControl = edtMVADVentaU_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1266MVADVentaU = 0;
               AssignAttri("", false, "A1266MVADVentaU", StringUtil.LTrimStr( A1266MVADVentaU, 18, 6));
            }
            else
            {
               A1266MVADVentaU = context.localUtil.CToN( cgiGet( edtMVADVentaU_Internalname), ".", ",");
               AssignAttri("", false, "A1266MVADVentaU", StringUtil.LTrimStr( A1266MVADVentaU, 18, 6));
            }
            A1265MVADVentaT = context.localUtil.CToN( cgiGet( edtMVADVentaT_Internalname), ".", ",");
            AssignAttri("", false, "A1265MVADVentaT", StringUtil.LTrimStr( A1265MVADVentaT, 15, 2));
            A1258MVADRef1 = cgiGet( edtMVADRef1_Internalname);
            AssignAttri("", false, "A1258MVADRef1", A1258MVADRef1);
            A1259MVADRef2 = cgiGet( edtMVADRef2_Internalname);
            AssignAttri("", false, "A1259MVADRef2", A1259MVADRef2);
            A1260MVADRef3 = cgiGet( edtMVADRef3_Internalname);
            AssignAttri("", false, "A1260MVADRef3", A1260MVADRef3);
            A1261MVADRef4 = cgiGet( edtMVADRef4_Internalname);
            AssignAttri("", false, "A1261MVADRef4", A1261MVADRef4);
            A1262MVADRef5 = cgiGet( edtMVADRef5_Internalname);
            AssignAttri("", false, "A1262MVADRef5", A1262MVADRef5);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADBultos_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADBultos_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADBULTOS");
               AnyError = 1;
               GX_FocusControl = edtMVADBultos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1247MVADBultos = 0;
               AssignAttri("", false, "A1247MVADBultos", StringUtil.LTrimStr( A1247MVADBultos, 15, 4));
            }
            else
            {
               A1247MVADBultos = context.localUtil.CToN( cgiGet( edtMVADBultos_Internalname), ".", ",");
               AssignAttri("", false, "A1247MVADBultos", StringUtil.LTrimStr( A1247MVADBultos, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADLote_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADLote_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADLOTE");
               AnyError = 1;
               GX_FocusControl = edtMVADLote_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1253MVADLote = 0;
               AssignAttri("", false, "A1253MVADLote", StringUtil.LTrimStr( A1253MVADLote, 15, 4));
            }
            else
            {
               A1253MVADLote = context.localUtil.CToN( cgiGet( edtMVADLote_Internalname), ".", ",");
               AssignAttri("", false, "A1253MVADLote", StringUtil.LTrimStr( A1253MVADLote, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADSTS");
               AnyError = 1;
               GX_FocusControl = edtMVADSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1263MVADSts = 0;
               AssignAttri("", false, "A1263MVADSts", StringUtil.Str( (decimal)(A1263MVADSts), 1, 0));
            }
            else
            {
               A1263MVADSts = (short)(context.localUtil.CToN( cgiGet( edtMVADSts_Internalname), ".", ","));
               AssignAttri("", false, "A1263MVADSts", StringUtil.Str( (decimal)(A1263MVADSts), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADUbi_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADUbi_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADUBI");
               AnyError = 1;
               GX_FocusControl = edtMVADUbi_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1264MVADUbi = 0;
               n1264MVADUbi = false;
               AssignAttri("", false, "A1264MVADUbi", StringUtil.LTrimStr( (decimal)(A1264MVADUbi), 6, 0));
            }
            else
            {
               A1264MVADUbi = (int)(context.localUtil.CToN( cgiGet( edtMVADUbi_Internalname), ".", ","));
               n1264MVADUbi = false;
               AssignAttri("", false, "A1264MVADUbi", StringUtil.LTrimStr( (decimal)(A1264MVADUbi), 6, 0));
            }
            n1264MVADUbi = ((0==A1264MVADUbi) ? true : false);
            A1257MVADObs = cgiGet( edtMVADObs_Internalname);
            AssignAttri("", false, "A1257MVADObs", A1257MVADObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADPrecio_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADPrecio_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADPRECIO");
               AnyError = 1;
               GX_FocusControl = edtMVADPrecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1250MVADPrecio = 0;
               AssignAttri("", false, "A1250MVADPrecio", StringUtil.LTrimStr( A1250MVADPrecio, 18, 6));
            }
            else
            {
               A1250MVADPrecio = context.localUtil.CToN( cgiGet( edtMVADPrecio_Internalname), ".", ",");
               AssignAttri("", false, "A1250MVADPrecio", StringUtil.LTrimStr( A1250MVADPrecio, 18, 6));
            }
            A1249MVADCosto = context.localUtil.CToN( cgiGet( edtMVADCosto_Internalname), ".", ",");
            AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrimStr( A1249MVADCosto, 15, 2));
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
               A13MvATip = GetPar( "MvATip");
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = GetPar( "MvACod");
               AssignAttri("", false, "A14MvACod", A14MvACod);
               A30MvADItem = (int)(NumberUtil.Val( GetPar( "MvADItem"), "."));
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
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
               InitAll1640( ) ;
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
         DisableAttributes1640( ) ;
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1640( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1640( ) ;
            }
            else
            {
               CheckExtendedTable1640( ) ;
               if ( AnyError == 0 )
               {
                  ZM1640( 4) ;
                  ZM1640( 5) ;
                  ZM1640( 6) ;
               }
               CloseExtendedTableCursors1640( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues160( ) ;
         }
      }

      protected void ResetCaption160( )
      {
      }

      protected void ZM1640( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1249MVADCosto = T00163_A1249MVADCosto[0];
               Z1248MvADCant = T00163_A1248MvADCant[0];
               Z1266MVADVentaU = T00163_A1266MVADVentaU[0];
               Z1258MVADRef1 = T00163_A1258MVADRef1[0];
               Z1259MVADRef2 = T00163_A1259MVADRef2[0];
               Z1260MVADRef3 = T00163_A1260MVADRef3[0];
               Z1261MVADRef4 = T00163_A1261MVADRef4[0];
               Z1262MVADRef5 = T00163_A1262MVADRef5[0];
               Z1247MVADBultos = T00163_A1247MVADBultos[0];
               Z1253MVADLote = T00163_A1253MVADLote[0];
               Z1263MVADSts = T00163_A1263MVADSts[0];
               Z1264MVADUbi = T00163_A1264MVADUbi[0];
               Z1250MVADPrecio = T00163_A1250MVADPrecio[0];
               Z28ProdCod = T00163_A28ProdCod[0];
            }
            else
            {
               Z1249MVADCosto = A1249MVADCosto;
               Z1248MvADCant = A1248MvADCant;
               Z1266MVADVentaU = A1266MVADVentaU;
               Z1258MVADRef1 = A1258MVADRef1;
               Z1259MVADRef2 = A1259MVADRef2;
               Z1260MVADRef3 = A1260MVADRef3;
               Z1261MVADRef4 = A1261MVADRef4;
               Z1262MVADRef5 = A1262MVADRef5;
               Z1247MVADBultos = A1247MVADBultos;
               Z1253MVADLote = A1253MVADLote;
               Z1263MVADSts = A1263MVADSts;
               Z1264MVADUbi = A1264MVADUbi;
               Z1250MVADPrecio = A1250MVADPrecio;
               Z28ProdCod = A28ProdCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z1249MVADCosto = A1249MVADCosto;
            Z30MvADItem = A30MvADItem;
            Z1248MvADCant = A1248MvADCant;
            Z1266MVADVentaU = A1266MVADVentaU;
            Z1258MVADRef1 = A1258MVADRef1;
            Z1259MVADRef2 = A1259MVADRef2;
            Z1260MVADRef3 = A1260MVADRef3;
            Z1261MVADRef4 = A1261MVADRef4;
            Z1262MVADRef5 = A1262MVADRef5;
            Z1247MVADBultos = A1247MVADBultos;
            Z1253MVADLote = A1253MVADLote;
            Z1263MVADSts = A1263MVADSts;
            Z1264MVADUbi = A1264MVADUbi;
            Z1257MVADObs = A1257MVADObs;
            Z1250MVADPrecio = A1250MVADPrecio;
            Z13MvATip = A13MvATip;
            Z14MvACod = A14MvACod;
            Z28ProdCod = A28ProdCod;
            Z52LinCod = A52LinCod;
            Z55ProdDsc = A55ProdDsc;
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

      protected void Load1640( )
      {
         /* Using cursor T00167 */
         pr_default.execute(5, new Object[] {A30MvADItem, A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound40 = 1;
            A52LinCod = T00167_A52LinCod[0];
            A1249MVADCosto = T00167_A1249MVADCosto[0];
            AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrimStr( A1249MVADCosto, 15, 2));
            A55ProdDsc = T00167_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1248MvADCant = T00167_A1248MvADCant[0];
            AssignAttri("", false, "A1248MvADCant", StringUtil.LTrimStr( A1248MvADCant, 15, 4));
            A1158LinStk = T00167_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A1266MVADVentaU = T00167_A1266MVADVentaU[0];
            AssignAttri("", false, "A1266MVADVentaU", StringUtil.LTrimStr( A1266MVADVentaU, 18, 6));
            A1258MVADRef1 = T00167_A1258MVADRef1[0];
            AssignAttri("", false, "A1258MVADRef1", A1258MVADRef1);
            A1259MVADRef2 = T00167_A1259MVADRef2[0];
            AssignAttri("", false, "A1259MVADRef2", A1259MVADRef2);
            A1260MVADRef3 = T00167_A1260MVADRef3[0];
            AssignAttri("", false, "A1260MVADRef3", A1260MVADRef3);
            A1261MVADRef4 = T00167_A1261MVADRef4[0];
            AssignAttri("", false, "A1261MVADRef4", A1261MVADRef4);
            A1262MVADRef5 = T00167_A1262MVADRef5[0];
            AssignAttri("", false, "A1262MVADRef5", A1262MVADRef5);
            A1247MVADBultos = T00167_A1247MVADBultos[0];
            AssignAttri("", false, "A1247MVADBultos", StringUtil.LTrimStr( A1247MVADBultos, 15, 4));
            A1253MVADLote = T00167_A1253MVADLote[0];
            AssignAttri("", false, "A1253MVADLote", StringUtil.LTrimStr( A1253MVADLote, 15, 4));
            A1263MVADSts = T00167_A1263MVADSts[0];
            AssignAttri("", false, "A1263MVADSts", StringUtil.Str( (decimal)(A1263MVADSts), 1, 0));
            A1264MVADUbi = T00167_A1264MVADUbi[0];
            n1264MVADUbi = T00167_n1264MVADUbi[0];
            AssignAttri("", false, "A1264MVADUbi", StringUtil.LTrimStr( (decimal)(A1264MVADUbi), 6, 0));
            A1257MVADObs = T00167_A1257MVADObs[0];
            AssignAttri("", false, "A1257MVADObs", A1257MVADObs);
            A1250MVADPrecio = T00167_A1250MVADPrecio[0];
            AssignAttri("", false, "A1250MVADPrecio", StringUtil.LTrimStr( A1250MVADPrecio, 18, 6));
            A28ProdCod = T00167_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            ZM1640( -3) ;
         }
         pr_default.close(5);
         OnLoadActions1640( ) ;
      }

      protected void OnLoadActions1640( )
      {
         A1265MVADVentaT = (decimal)(A1248MvADCant*A1266MVADVentaU);
         AssignAttri("", false, "A1265MVADVentaT", StringUtil.LTrimStr( A1265MVADVentaT, 15, 2));
         A1249MVADCosto = (decimal)(A1248MvADCant*A1250MVADPrecio);
         AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrimStr( A1249MVADCosto, 15, 2));
      }

      protected void CheckExtendedTable1640( )
      {
         nIsDirty_40 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00164 */
         pr_default.execute(2, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov. Almacen(Entradas,Salidas,Remision)'.", "ForeignKeyNotFound", 1, "MVACOD");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         nIsDirty_40 = 1;
         A1265MVADVentaT = (decimal)(A1248MvADCant*A1266MVADVentaU);
         AssignAttri("", false, "A1265MVADVentaT", StringUtil.LTrimStr( A1265MVADVentaT, 15, 2));
         nIsDirty_40 = 1;
         A1249MVADCosto = (decimal)(A1248MvADCant*A1250MVADPrecio);
         AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrimStr( A1249MVADCosto, 15, 2));
         /* Using cursor T00165 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A52LinCod = T00165_A52LinCod[0];
         A55ProdDsc = T00165_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         pr_default.close(3);
         /* Using cursor T00166 */
         pr_default.execute(4, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
         }
         A1158LinStk = T00166_A1158LinStk[0];
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1640( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A13MvATip ,
                               string A14MvACod )
      {
         /* Using cursor T00168 */
         pr_default.execute(6, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov. Almacen(Entradas,Salidas,Remision)'.", "ForeignKeyNotFound", 1, "MVACOD");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
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

      protected void gxLoad_5( string A28ProdCod )
      {
         /* Using cursor T00169 */
         pr_default.execute(7, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A52LinCod = T00169_A52LinCod[0];
         A55ProdDsc = T00169_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A55ProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_6( int A52LinCod )
      {
         /* Using cursor T001610 */
         pr_default.execute(8, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
         }
         A1158LinStk = T001610_A1158LinStk[0];
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1640( )
      {
         /* Using cursor T001611 */
         pr_default.execute(9, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00163 */
         pr_default.execute(1, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1640( 3) ;
            RcdFound40 = 1;
            A1249MVADCosto = T00163_A1249MVADCosto[0];
            AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrimStr( A1249MVADCosto, 15, 2));
            A30MvADItem = T00163_A30MvADItem[0];
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            A1248MvADCant = T00163_A1248MvADCant[0];
            AssignAttri("", false, "A1248MvADCant", StringUtil.LTrimStr( A1248MvADCant, 15, 4));
            A1266MVADVentaU = T00163_A1266MVADVentaU[0];
            AssignAttri("", false, "A1266MVADVentaU", StringUtil.LTrimStr( A1266MVADVentaU, 18, 6));
            A1258MVADRef1 = T00163_A1258MVADRef1[0];
            AssignAttri("", false, "A1258MVADRef1", A1258MVADRef1);
            A1259MVADRef2 = T00163_A1259MVADRef2[0];
            AssignAttri("", false, "A1259MVADRef2", A1259MVADRef2);
            A1260MVADRef3 = T00163_A1260MVADRef3[0];
            AssignAttri("", false, "A1260MVADRef3", A1260MVADRef3);
            A1261MVADRef4 = T00163_A1261MVADRef4[0];
            AssignAttri("", false, "A1261MVADRef4", A1261MVADRef4);
            A1262MVADRef5 = T00163_A1262MVADRef5[0];
            AssignAttri("", false, "A1262MVADRef5", A1262MVADRef5);
            A1247MVADBultos = T00163_A1247MVADBultos[0];
            AssignAttri("", false, "A1247MVADBultos", StringUtil.LTrimStr( A1247MVADBultos, 15, 4));
            A1253MVADLote = T00163_A1253MVADLote[0];
            AssignAttri("", false, "A1253MVADLote", StringUtil.LTrimStr( A1253MVADLote, 15, 4));
            A1263MVADSts = T00163_A1263MVADSts[0];
            AssignAttri("", false, "A1263MVADSts", StringUtil.Str( (decimal)(A1263MVADSts), 1, 0));
            A1264MVADUbi = T00163_A1264MVADUbi[0];
            n1264MVADUbi = T00163_n1264MVADUbi[0];
            AssignAttri("", false, "A1264MVADUbi", StringUtil.LTrimStr( (decimal)(A1264MVADUbi), 6, 0));
            A1257MVADObs = T00163_A1257MVADObs[0];
            AssignAttri("", false, "A1257MVADObs", A1257MVADObs);
            A1250MVADPrecio = T00163_A1250MVADPrecio[0];
            AssignAttri("", false, "A1250MVADPrecio", StringUtil.LTrimStr( A1250MVADPrecio, 18, 6));
            A13MvATip = T00163_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T00163_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A28ProdCod = T00163_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z13MvATip = A13MvATip;
            Z14MvACod = A14MvACod;
            Z30MvADItem = A30MvADItem;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1640( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1640( ) ;
            }
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1640( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1640( ) ;
         if ( RcdFound40 == 0 )
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
         RcdFound40 = 0;
         /* Using cursor T001612 */
         pr_default.execute(10, new Object[] {A30MvADItem, A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001612_A30MvADItem[0] < A30MvADItem ) || ( T001612_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001612_A13MvATip[0], A13MvATip) < 0 ) || ( StringUtil.StrCmp(T001612_A13MvATip[0], A13MvATip) == 0 ) && ( T001612_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001612_A14MvACod[0], A14MvACod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001612_A30MvADItem[0] > A30MvADItem ) || ( T001612_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001612_A13MvATip[0], A13MvATip) > 0 ) || ( StringUtil.StrCmp(T001612_A13MvATip[0], A13MvATip) == 0 ) && ( T001612_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001612_A14MvACod[0], A14MvACod) > 0 ) ) )
            {
               A30MvADItem = T001612_A30MvADItem[0];
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               A13MvATip = T001612_A13MvATip[0];
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = T001612_A14MvACod[0];
               AssignAttri("", false, "A14MvACod", A14MvACod);
               RcdFound40 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound40 = 0;
         /* Using cursor T001613 */
         pr_default.execute(11, new Object[] {A30MvADItem, A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001613_A30MvADItem[0] > A30MvADItem ) || ( T001613_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001613_A13MvATip[0], A13MvATip) > 0 ) || ( StringUtil.StrCmp(T001613_A13MvATip[0], A13MvATip) == 0 ) && ( T001613_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001613_A14MvACod[0], A14MvACod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001613_A30MvADItem[0] < A30MvADItem ) || ( T001613_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001613_A13MvATip[0], A13MvATip) < 0 ) || ( StringUtil.StrCmp(T001613_A13MvATip[0], A13MvATip) == 0 ) && ( T001613_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T001613_A14MvACod[0], A14MvACod) < 0 ) ) )
            {
               A30MvADItem = T001613_A30MvADItem[0];
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               A13MvATip = T001613_A13MvATip[0];
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = T001613_A14MvACod[0];
               AssignAttri("", false, "A14MvACod", A14MvACod);
               RcdFound40 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1640( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1640( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) )
               {
                  A13MvATip = Z13MvATip;
                  AssignAttri("", false, "A13MvATip", A13MvATip);
                  A14MvACod = Z14MvACod;
                  AssignAttri("", false, "A14MvACod", A14MvACod);
                  A30MvADItem = Z30MvADItem;
                  AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1640( ) ;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1640( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MVATIP");
                     AnyError = 1;
                     GX_FocusControl = edtMvATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMvATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1640( ) ;
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
         if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) )
         {
            A13MvATip = Z13MvATip;
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = Z14MvACod;
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = Z30MvADItem;
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MVATIP");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMvATip_Internalname;
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
         GetKey1640( ) ;
         if ( RcdFound40 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "MVATIP");
               AnyError = 1;
               GX_FocusControl = edtMvATip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) )
            {
               A13MvATip = Z13MvATip;
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = Z14MvACod;
               AssignAttri("", false, "A14MvACod", A14MvACod);
               A30MvADItem = Z30MvADItem;
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "MVATIP");
               AnyError = 1;
               GX_FocusControl = edtMvATip_Internalname;
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
            if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtMvATip_Internalname;
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
         context.RollbackDataStores("aguiasdet",pr_default);
         GX_FocusControl = edtMvADCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_160( ) ;
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
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MVATIP");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMvADCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1640( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvADCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1640( ) ;
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
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvADCant_Internalname;
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
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvADCant_Internalname;
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
         ScanStart1640( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound40 != 0 )
            {
               ScanNext1640( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvADCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1640( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1640( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00162 */
            pr_default.execute(0, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1249MVADCosto != T00162_A1249MVADCosto[0] ) || ( Z1248MvADCant != T00162_A1248MvADCant[0] ) || ( Z1266MVADVentaU != T00162_A1266MVADVentaU[0] ) || ( StringUtil.StrCmp(Z1258MVADRef1, T00162_A1258MVADRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1259MVADRef2, T00162_A1259MVADRef2[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1260MVADRef3, T00162_A1260MVADRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1261MVADRef4, T00162_A1261MVADRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1262MVADRef5, T00162_A1262MVADRef5[0]) != 0 ) || ( Z1247MVADBultos != T00162_A1247MVADBultos[0] ) || ( Z1253MVADLote != T00162_A1253MVADLote[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1263MVADSts != T00162_A1263MVADSts[0] ) || ( Z1264MVADUbi != T00162_A1264MVADUbi[0] ) || ( Z1250MVADPrecio != T00162_A1250MVADPrecio[0] ) || ( StringUtil.StrCmp(Z28ProdCod, T00162_A28ProdCod[0]) != 0 ) )
            {
               if ( Z1249MVADCosto != T00162_A1249MVADCosto[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1249MVADCosto);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1249MVADCosto[0]);
               }
               if ( Z1248MvADCant != T00162_A1248MvADCant[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MvADCant");
                  GXUtil.WriteLogRaw("Old: ",Z1248MvADCant);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1248MvADCant[0]);
               }
               if ( Z1266MVADVentaU != T00162_A1266MVADVentaU[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADVentaU");
                  GXUtil.WriteLogRaw("Old: ",Z1266MVADVentaU);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1266MVADVentaU[0]);
               }
               if ( StringUtil.StrCmp(Z1258MVADRef1, T00162_A1258MVADRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1258MVADRef1);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1258MVADRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1259MVADRef2, T00162_A1259MVADRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1259MVADRef2);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1259MVADRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1260MVADRef3, T00162_A1260MVADRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1260MVADRef3);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1260MVADRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1261MVADRef4, T00162_A1261MVADRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1261MVADRef4);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1261MVADRef4[0]);
               }
               if ( StringUtil.StrCmp(Z1262MVADRef5, T00162_A1262MVADRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADRef5");
                  GXUtil.WriteLogRaw("Old: ",Z1262MVADRef5);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1262MVADRef5[0]);
               }
               if ( Z1247MVADBultos != T00162_A1247MVADBultos[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADBultos");
                  GXUtil.WriteLogRaw("Old: ",Z1247MVADBultos);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1247MVADBultos[0]);
               }
               if ( Z1253MVADLote != T00162_A1253MVADLote[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADLote");
                  GXUtil.WriteLogRaw("Old: ",Z1253MVADLote);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1253MVADLote[0]);
               }
               if ( Z1263MVADSts != T00162_A1263MVADSts[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADSts");
                  GXUtil.WriteLogRaw("Old: ",Z1263MVADSts);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1263MVADSts[0]);
               }
               if ( Z1264MVADUbi != T00162_A1264MVADUbi[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADUbi");
                  GXUtil.WriteLogRaw("Old: ",Z1264MVADUbi);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1264MVADUbi[0]);
               }
               if ( Z1250MVADPrecio != T00162_A1250MVADPrecio[0] )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"MVADPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z1250MVADPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00162_A1250MVADPrecio[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T00162_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdet:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00162_A28ProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AGUIASDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1640( )
      {
         BeforeValidate1640( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1640( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1640( 0) ;
            CheckOptimisticConcurrency1640( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1640( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1640( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001614 */
                     pr_default.execute(12, new Object[] {A1249MVADCosto, A30MvADItem, A1248MvADCant, A1266MVADVentaU, A1258MVADRef1, A1259MVADRef2, A1260MVADRef3, A1261MVADRef4, A1262MVADRef5, A1247MVADBultos, A1253MVADLote, A1263MVADSts, n1264MVADUbi, A1264MVADUbi, A1257MVADObs, A1250MVADPrecio, A13MvATip, A14MvACod, A28ProdCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASDET");
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
                           ResetCaption160( ) ;
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
               Load1640( ) ;
            }
            EndLevel1640( ) ;
         }
         CloseExtendedTableCursors1640( ) ;
      }

      protected void Update1640( )
      {
         BeforeValidate1640( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1640( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1640( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1640( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1640( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001615 */
                     pr_default.execute(13, new Object[] {A1249MVADCosto, A1248MvADCant, A1266MVADVentaU, A1258MVADRef1, A1259MVADRef2, A1260MVADRef3, A1261MVADRef4, A1262MVADRef5, A1247MVADBultos, A1253MVADLote, A1263MVADSts, n1264MVADUbi, A1264MVADUbi, A1257MVADObs, A1250MVADPrecio, A28ProdCod, A13MvATip, A14MvACod, A30MvADItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASDET");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1640( ) ;
                     if ( AnyError == 0 )
                     {
                        new aguiasdetupdateredundancy(context ).execute( ref  A13MvATip, ref  A14MvACod, ref  A30MvADItem) ;
                        AssignAttri("", false, "A13MvATip", A13MvATip);
                        AssignAttri("", false, "A14MvACod", A14MvACod);
                        AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption160( ) ;
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
            EndLevel1640( ) ;
         }
         CloseExtendedTableCursors1640( ) ;
      }

      protected void DeferredUpdate1640( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1640( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1640( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1640( ) ;
            AfterConfirm1640( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1640( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001616 */
                  pr_default.execute(14, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("AGUIASDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound40 == 0 )
                        {
                           InitAll1640( ) ;
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
                        ResetCaption160( ) ;
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
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1640( ) ;
         Gx_mode = sMode40;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1640( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001617 */
            pr_default.execute(15, new Object[] {A28ProdCod});
            A52LinCod = T001617_A52LinCod[0];
            A55ProdDsc = T001617_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            pr_default.close(15);
            /* Using cursor T001618 */
            pr_default.execute(16, new Object[] {A52LinCod});
            A1158LinStk = T001618_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            pr_default.close(16);
            A1265MVADVentaT = (decimal)(A1248MvADCant*A1266MVADVentaU);
            AssignAttri("", false, "A1265MVADVentaT", StringUtil.LTrimStr( A1265MVADVentaT, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001619 */
            pr_default.execute(17, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Almacen Lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel1640( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1640( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("aguiasdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues160( ) ;
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
            context.RollbackDataStores("aguiasdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1640( )
      {
         /* Using cursor T001620 */
         pr_default.execute(18);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound40 = 1;
            A13MvATip = T001620_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T001620_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = T001620_A30MvADItem[0];
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1640( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound40 = 1;
            A13MvATip = T001620_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T001620_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = T001620_A30MvADItem[0];
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
         }
      }

      protected void ScanEnd1640( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm1640( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1640( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1640( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1640( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1640( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1640( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1640( )
      {
         edtMvATip_Enabled = 0;
         AssignProp("", false, edtMvATip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvATip_Enabled), 5, 0), true);
         edtMvACod_Enabled = 0;
         AssignProp("", false, edtMvACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvACod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtMvADCant_Enabled = 0;
         AssignProp("", false, edtMvADCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvADCant_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtMvADItem_Enabled = 0;
         AssignProp("", false, edtMvADItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvADItem_Enabled), 5, 0), true);
         edtLinStk_Enabled = 0;
         AssignProp("", false, edtLinStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinStk_Enabled), 5, 0), true);
         edtMVADVentaU_Enabled = 0;
         AssignProp("", false, edtMVADVentaU_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADVentaU_Enabled), 5, 0), true);
         edtMVADVentaT_Enabled = 0;
         AssignProp("", false, edtMVADVentaT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADVentaT_Enabled), 5, 0), true);
         edtMVADRef1_Enabled = 0;
         AssignProp("", false, edtMVADRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADRef1_Enabled), 5, 0), true);
         edtMVADRef2_Enabled = 0;
         AssignProp("", false, edtMVADRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADRef2_Enabled), 5, 0), true);
         edtMVADRef3_Enabled = 0;
         AssignProp("", false, edtMVADRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADRef3_Enabled), 5, 0), true);
         edtMVADRef4_Enabled = 0;
         AssignProp("", false, edtMVADRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADRef4_Enabled), 5, 0), true);
         edtMVADRef5_Enabled = 0;
         AssignProp("", false, edtMVADRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADRef5_Enabled), 5, 0), true);
         edtMVADBultos_Enabled = 0;
         AssignProp("", false, edtMVADBultos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADBultos_Enabled), 5, 0), true);
         edtMVADLote_Enabled = 0;
         AssignProp("", false, edtMVADLote_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLote_Enabled), 5, 0), true);
         edtMVADSts_Enabled = 0;
         AssignProp("", false, edtMVADSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADSts_Enabled), 5, 0), true);
         edtMVADUbi_Enabled = 0;
         AssignProp("", false, edtMVADUbi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADUbi_Enabled), 5, 0), true);
         edtMVADObs_Enabled = 0;
         AssignProp("", false, edtMVADObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADObs_Enabled), 5, 0), true);
         edtMVADPrecio_Enabled = 0;
         AssignProp("", false, edtMVADPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADPrecio_Enabled), 5, 0), true);
         edtMVADCosto_Enabled = 0;
         AssignProp("", false, edtMVADCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADCosto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1640( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues160( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811465183", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aguiasdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z13MvATip", StringUtil.RTrim( Z13MvATip));
         GxWebStd.gx_hidden_field( context, "Z14MvACod", StringUtil.RTrim( Z14MvACod));
         GxWebStd.gx_hidden_field( context, "Z30MvADItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30MvADItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1249MVADCosto", StringUtil.LTrim( StringUtil.NToC( Z1249MVADCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1248MvADCant", StringUtil.LTrim( StringUtil.NToC( Z1248MvADCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1266MVADVentaU", StringUtil.LTrim( StringUtil.NToC( Z1266MVADVentaU, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1258MVADRef1", StringUtil.RTrim( Z1258MVADRef1));
         GxWebStd.gx_hidden_field( context, "Z1259MVADRef2", StringUtil.RTrim( Z1259MVADRef2));
         GxWebStd.gx_hidden_field( context, "Z1260MVADRef3", StringUtil.RTrim( Z1260MVADRef3));
         GxWebStd.gx_hidden_field( context, "Z1261MVADRef4", StringUtil.RTrim( Z1261MVADRef4));
         GxWebStd.gx_hidden_field( context, "Z1262MVADRef5", StringUtil.RTrim( Z1262MVADRef5));
         GxWebStd.gx_hidden_field( context, "Z1247MVADBultos", StringUtil.LTrim( StringUtil.NToC( Z1247MVADBultos, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1253MVADLote", StringUtil.LTrim( StringUtil.NToC( Z1253MVADLote, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1263MVADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1263MVADSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1264MVADUbi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1264MVADUbi), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1250MVADPrecio", StringUtil.LTrim( StringUtil.NToC( Z1250MVADPrecio, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("aguiasdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AGUIASDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos de Almacen - Detalles" ;
      }

      protected void InitializeNonKey1640( )
      {
         A52LinCod = 0;
         AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         A1249MVADCosto = 0;
         AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrimStr( A1249MVADCosto, 15, 2));
         A1265MVADVentaT = 0;
         AssignAttri("", false, "A1265MVADVentaT", StringUtil.LTrimStr( A1265MVADVentaT, 15, 2));
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A1248MvADCant = 0;
         AssignAttri("", false, "A1248MvADCant", StringUtil.LTrimStr( A1248MvADCant, 15, 4));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A1158LinStk = 0;
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         A1266MVADVentaU = 0;
         AssignAttri("", false, "A1266MVADVentaU", StringUtil.LTrimStr( A1266MVADVentaU, 18, 6));
         A1258MVADRef1 = "";
         AssignAttri("", false, "A1258MVADRef1", A1258MVADRef1);
         A1259MVADRef2 = "";
         AssignAttri("", false, "A1259MVADRef2", A1259MVADRef2);
         A1260MVADRef3 = "";
         AssignAttri("", false, "A1260MVADRef3", A1260MVADRef3);
         A1261MVADRef4 = "";
         AssignAttri("", false, "A1261MVADRef4", A1261MVADRef4);
         A1262MVADRef5 = "";
         AssignAttri("", false, "A1262MVADRef5", A1262MVADRef5);
         A1247MVADBultos = 0;
         AssignAttri("", false, "A1247MVADBultos", StringUtil.LTrimStr( A1247MVADBultos, 15, 4));
         A1253MVADLote = 0;
         AssignAttri("", false, "A1253MVADLote", StringUtil.LTrimStr( A1253MVADLote, 15, 4));
         A1263MVADSts = 0;
         AssignAttri("", false, "A1263MVADSts", StringUtil.Str( (decimal)(A1263MVADSts), 1, 0));
         A1264MVADUbi = 0;
         n1264MVADUbi = false;
         AssignAttri("", false, "A1264MVADUbi", StringUtil.LTrimStr( (decimal)(A1264MVADUbi), 6, 0));
         n1264MVADUbi = ((0==A1264MVADUbi) ? true : false);
         A1257MVADObs = "";
         AssignAttri("", false, "A1257MVADObs", A1257MVADObs);
         A1250MVADPrecio = 0;
         AssignAttri("", false, "A1250MVADPrecio", StringUtil.LTrimStr( A1250MVADPrecio, 18, 6));
         Z1249MVADCosto = 0;
         Z1248MvADCant = 0;
         Z1266MVADVentaU = 0;
         Z1258MVADRef1 = "";
         Z1259MVADRef2 = "";
         Z1260MVADRef3 = "";
         Z1261MVADRef4 = "";
         Z1262MVADRef5 = "";
         Z1247MVADBultos = 0;
         Z1253MVADLote = 0;
         Z1263MVADSts = 0;
         Z1264MVADUbi = 0;
         Z1250MVADPrecio = 0;
         Z28ProdCod = "";
      }

      protected void InitAll1640( )
      {
         A13MvATip = "";
         AssignAttri("", false, "A13MvATip", A13MvATip);
         A14MvACod = "";
         AssignAttri("", false, "A14MvACod", A14MvACod);
         A30MvADItem = 0;
         AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
         InitializeNonKey1640( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811465188", true, true);
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
         context.AddJavascriptSource("aguiasdet.js", "?202281811465188", false, true);
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
         edtMvATip_Internalname = "MVATIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMvACod_Internalname = "MVACOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMvADCant_Internalname = "MVADCANT";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtMvADItem_Internalname = "MVADITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLinStk_Internalname = "LINSTK";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtMVADVentaU_Internalname = "MVADVENTAU";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtMVADVentaT_Internalname = "MVADVENTAT";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtMVADRef1_Internalname = "MVADREF1";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtMVADRef2_Internalname = "MVADREF2";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtMVADRef3_Internalname = "MVADREF3";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtMVADRef4_Internalname = "MVADREF4";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtMVADRef5_Internalname = "MVADREF5";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtMVADBultos_Internalname = "MVADBULTOS";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtMVADLote_Internalname = "MVADLOTE";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtMVADSts_Internalname = "MVADSTS";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtMVADUbi_Internalname = "MVADUBI";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtMVADObs_Internalname = "MVADOBS";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtMVADPrecio_Internalname = "MVADPRECIO";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtMVADCosto_Internalname = "MVADCOSTO";
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
         Form.Caption = "Movimientos de Almacen - Detalles";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMVADCosto_Jsonclick = "";
         edtMVADCosto_Enabled = 0;
         edtMVADPrecio_Jsonclick = "";
         edtMVADPrecio_Enabled = 1;
         edtMVADObs_Enabled = 1;
         edtMVADUbi_Jsonclick = "";
         edtMVADUbi_Enabled = 1;
         edtMVADSts_Jsonclick = "";
         edtMVADSts_Enabled = 1;
         edtMVADLote_Jsonclick = "";
         edtMVADLote_Enabled = 1;
         edtMVADBultos_Jsonclick = "";
         edtMVADBultos_Enabled = 1;
         edtMVADRef5_Jsonclick = "";
         edtMVADRef5_Enabled = 1;
         edtMVADRef4_Jsonclick = "";
         edtMVADRef4_Enabled = 1;
         edtMVADRef3_Jsonclick = "";
         edtMVADRef3_Enabled = 1;
         edtMVADRef2_Jsonclick = "";
         edtMVADRef2_Enabled = 1;
         edtMVADRef1_Jsonclick = "";
         edtMVADRef1_Enabled = 1;
         edtMVADVentaT_Jsonclick = "";
         edtMVADVentaT_Enabled = 0;
         edtMVADVentaU_Jsonclick = "";
         edtMVADVentaU_Enabled = 1;
         edtLinStk_Jsonclick = "";
         edtLinStk_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMvADItem_Jsonclick = "";
         edtMvADItem_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         edtMvADCant_Jsonclick = "";
         edtMvADCant_Enabled = 1;
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 0;
         edtMvACod_Jsonclick = "";
         edtMvACod_Enabled = 1;
         edtMvATip_Jsonclick = "";
         edtMvATip_Enabled = 1;
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
         /* Using cursor T001621 */
         pr_default.execute(19, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov. Almacen(Entradas,Salidas,Remision)'.", "ForeignKeyNotFound", 1, "MVACOD");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(19);
         GX_FocusControl = edtMvADCant_Internalname;
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

      public void Valid_Mvacod( )
      {
         /* Using cursor T001621 */
         pr_default.execute(19, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov. Almacen(Entradas,Salidas,Remision)'.", "ForeignKeyNotFound", 1, "MVACOD");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvaditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1248MvADCant", StringUtil.LTrim( StringUtil.NToC( A1248MvADCant, 15, 4, ".", "")));
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A1266MVADVentaU", StringUtil.LTrim( StringUtil.NToC( A1266MVADVentaU, 18, 6, ".", "")));
         AssignAttri("", false, "A1258MVADRef1", StringUtil.RTrim( A1258MVADRef1));
         AssignAttri("", false, "A1259MVADRef2", StringUtil.RTrim( A1259MVADRef2));
         AssignAttri("", false, "A1260MVADRef3", StringUtil.RTrim( A1260MVADRef3));
         AssignAttri("", false, "A1261MVADRef4", StringUtil.RTrim( A1261MVADRef4));
         AssignAttri("", false, "A1262MVADRef5", StringUtil.RTrim( A1262MVADRef5));
         AssignAttri("", false, "A1247MVADBultos", StringUtil.LTrim( StringUtil.NToC( A1247MVADBultos, 15, 4, ".", "")));
         AssignAttri("", false, "A1253MVADLote", StringUtil.LTrim( StringUtil.NToC( A1253MVADLote, 15, 4, ".", "")));
         AssignAttri("", false, "A1263MVADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1263MVADSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1264MVADUbi", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1264MVADUbi), 6, 0, ".", "")));
         AssignAttri("", false, "A1257MVADObs", A1257MVADObs);
         AssignAttri("", false, "A1250MVADPrecio", StringUtil.LTrim( StringUtil.NToC( A1250MVADPrecio, 18, 6, ".", "")));
         AssignAttri("", false, "A1265MVADVentaT", StringUtil.LTrim( StringUtil.NToC( A1265MVADVentaT, 15, 2, ".", "")));
         AssignAttri("", false, "A1249MVADCosto", StringUtil.LTrim( StringUtil.NToC( A1249MVADCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z13MvATip", StringUtil.RTrim( Z13MvATip));
         GxWebStd.gx_hidden_field( context, "Z14MvACod", StringUtil.RTrim( Z14MvACod));
         GxWebStd.gx_hidden_field( context, "Z30MvADItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30MvADItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1248MvADCant", StringUtil.LTrim( StringUtil.NToC( Z1248MvADCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1266MVADVentaU", StringUtil.LTrim( StringUtil.NToC( Z1266MVADVentaU, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1258MVADRef1", StringUtil.RTrim( Z1258MVADRef1));
         GxWebStd.gx_hidden_field( context, "Z1259MVADRef2", StringUtil.RTrim( Z1259MVADRef2));
         GxWebStd.gx_hidden_field( context, "Z1260MVADRef3", StringUtil.RTrim( Z1260MVADRef3));
         GxWebStd.gx_hidden_field( context, "Z1261MVADRef4", StringUtil.RTrim( Z1261MVADRef4));
         GxWebStd.gx_hidden_field( context, "Z1262MVADRef5", StringUtil.RTrim( Z1262MVADRef5));
         GxWebStd.gx_hidden_field( context, "Z1247MVADBultos", StringUtil.LTrim( StringUtil.NToC( Z1247MVADBultos, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1253MVADLote", StringUtil.LTrim( StringUtil.NToC( Z1253MVADLote, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1263MVADSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1263MVADSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1264MVADUbi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1264MVADUbi), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1257MVADObs", Z1257MVADObs);
         GxWebStd.gx_hidden_field( context, "Z1250MVADPrecio", StringUtil.LTrim( StringUtil.NToC( Z1250MVADPrecio, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1265MVADVentaT", StringUtil.LTrim( StringUtil.NToC( Z1265MVADVentaT, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1249MVADCosto", StringUtil.LTrim( StringUtil.NToC( Z1249MVADCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1158LinStk), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T001617 */
         pr_default.execute(15, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         A52LinCod = T001617_A52LinCod[0];
         A55ProdDsc = T001617_A55ProdDsc[0];
         pr_default.close(15);
         /* Using cursor T001618 */
         pr_default.execute(16, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
         }
         A1158LinStk = T001618_A1158LinStk[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_MVATIP","{handler:'Valid_Mvatip',iparms:[]");
         setEventMetadata("VALID_MVATIP",",oparms:[]}");
         setEventMetadata("VALID_MVACOD","{handler:'Valid_Mvacod',iparms:[{av:'A13MvATip',fld:'MVATIP',pic:''},{av:'A14MvACod',fld:'MVACOD',pic:''}]");
         setEventMetadata("VALID_MVACOD",",oparms:[]}");
         setEventMetadata("VALID_MVADCANT","{handler:'Valid_Mvadcant',iparms:[]");
         setEventMetadata("VALID_MVADCANT",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1158LinStk',fld:'LINSTK',pic:'9'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1158LinStk',fld:'LINSTK',pic:'9'}]}");
         setEventMetadata("VALID_MVADITEM","{handler:'Valid_Mvaditem',iparms:[{av:'A13MvATip',fld:'MVATIP',pic:''},{av:'A14MvACod',fld:'MVACOD',pic:''},{av:'A30MvADItem',fld:'MVADITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MVADITEM",",oparms:[{av:'A1248MvADCant',fld:'MVADCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A1266MVADVentaU',fld:'MVADVENTAU',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A1258MVADRef1',fld:'MVADREF1',pic:''},{av:'A1259MVADRef2',fld:'MVADREF2',pic:''},{av:'A1260MVADRef3',fld:'MVADREF3',pic:''},{av:'A1261MVADRef4',fld:'MVADREF4',pic:''},{av:'A1262MVADRef5',fld:'MVADREF5',pic:''},{av:'A1247MVADBultos',fld:'MVADBULTOS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1253MVADLote',fld:'MVADLOTE',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1263MVADSts',fld:'MVADSTS',pic:'9'},{av:'A1264MVADUbi',fld:'MVADUBI',pic:'ZZZZZ9'},{av:'A1257MVADObs',fld:'MVADOBS',pic:''},{av:'A1250MVADPrecio',fld:'MVADPRECIO',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A1265MVADVentaT',fld:'MVADVENTAT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1249MVADCosto',fld:'MVADCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A1158LinStk',fld:'LINSTK',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z13MvATip'},{av:'Z14MvACod'},{av:'Z30MvADItem'},{av:'Z1248MvADCant'},{av:'Z28ProdCod'},{av:'Z1266MVADVentaU'},{av:'Z1258MVADRef1'},{av:'Z1259MVADRef2'},{av:'Z1260MVADRef3'},{av:'Z1261MVADRef4'},{av:'Z1262MVADRef5'},{av:'Z1247MVADBultos'},{av:'Z1253MVADLote'},{av:'Z1263MVADSts'},{av:'Z1264MVADUbi'},{av:'Z1257MVADObs'},{av:'Z1250MVADPrecio'},{av:'Z1265MVADVentaT'},{av:'Z1249MVADCosto'},{av:'Z52LinCod'},{av:'Z55ProdDsc'},{av:'Z1158LinStk'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_MVADVENTAU","{handler:'Valid_Mvadventau',iparms:[]");
         setEventMetadata("VALID_MVADVENTAU",",oparms:[]}");
         setEventMetadata("VALID_MVADPRECIO","{handler:'Valid_Mvadprecio',iparms:[]");
         setEventMetadata("VALID_MVADPRECIO",",oparms:[]}");
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
         pr_default.close(19);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z13MvATip = "";
         Z14MvACod = "";
         Z1258MVADRef1 = "";
         Z1259MVADRef2 = "";
         Z1260MVADRef3 = "";
         Z1261MVADRef4 = "";
         Z1262MVADRef5 = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A13MvATip = "";
         A14MvACod = "";
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
         A55ProdDsc = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1258MVADRef1 = "";
         lblTextblock11_Jsonclick = "";
         A1259MVADRef2 = "";
         lblTextblock12_Jsonclick = "";
         A1260MVADRef3 = "";
         lblTextblock13_Jsonclick = "";
         A1261MVADRef4 = "";
         lblTextblock14_Jsonclick = "";
         A1262MVADRef5 = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         A1257MVADObs = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
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
         Z1257MVADObs = "";
         Z55ProdDsc = "";
         T00167_A52LinCod = new int[1] ;
         T00167_A1249MVADCosto = new decimal[1] ;
         T00167_A30MvADItem = new int[1] ;
         T00167_A55ProdDsc = new string[] {""} ;
         T00167_A1248MvADCant = new decimal[1] ;
         T00167_A1158LinStk = new short[1] ;
         T00167_A1266MVADVentaU = new decimal[1] ;
         T00167_A1258MVADRef1 = new string[] {""} ;
         T00167_A1259MVADRef2 = new string[] {""} ;
         T00167_A1260MVADRef3 = new string[] {""} ;
         T00167_A1261MVADRef4 = new string[] {""} ;
         T00167_A1262MVADRef5 = new string[] {""} ;
         T00167_A1247MVADBultos = new decimal[1] ;
         T00167_A1253MVADLote = new decimal[1] ;
         T00167_A1263MVADSts = new short[1] ;
         T00167_A1264MVADUbi = new int[1] ;
         T00167_n1264MVADUbi = new bool[] {false} ;
         T00167_A1257MVADObs = new string[] {""} ;
         T00167_A1250MVADPrecio = new decimal[1] ;
         T00167_A13MvATip = new string[] {""} ;
         T00167_A14MvACod = new string[] {""} ;
         T00167_A28ProdCod = new string[] {""} ;
         T00164_A13MvATip = new string[] {""} ;
         T00165_A52LinCod = new int[1] ;
         T00165_A55ProdDsc = new string[] {""} ;
         T00166_A1158LinStk = new short[1] ;
         T00168_A13MvATip = new string[] {""} ;
         T00169_A52LinCod = new int[1] ;
         T00169_A55ProdDsc = new string[] {""} ;
         T001610_A1158LinStk = new short[1] ;
         T001611_A13MvATip = new string[] {""} ;
         T001611_A14MvACod = new string[] {""} ;
         T001611_A30MvADItem = new int[1] ;
         T00163_A1249MVADCosto = new decimal[1] ;
         T00163_A30MvADItem = new int[1] ;
         T00163_A1248MvADCant = new decimal[1] ;
         T00163_A1266MVADVentaU = new decimal[1] ;
         T00163_A1258MVADRef1 = new string[] {""} ;
         T00163_A1259MVADRef2 = new string[] {""} ;
         T00163_A1260MVADRef3 = new string[] {""} ;
         T00163_A1261MVADRef4 = new string[] {""} ;
         T00163_A1262MVADRef5 = new string[] {""} ;
         T00163_A1247MVADBultos = new decimal[1] ;
         T00163_A1253MVADLote = new decimal[1] ;
         T00163_A1263MVADSts = new short[1] ;
         T00163_A1264MVADUbi = new int[1] ;
         T00163_n1264MVADUbi = new bool[] {false} ;
         T00163_A1257MVADObs = new string[] {""} ;
         T00163_A1250MVADPrecio = new decimal[1] ;
         T00163_A13MvATip = new string[] {""} ;
         T00163_A14MvACod = new string[] {""} ;
         T00163_A28ProdCod = new string[] {""} ;
         sMode40 = "";
         T001612_A30MvADItem = new int[1] ;
         T001612_A13MvATip = new string[] {""} ;
         T001612_A14MvACod = new string[] {""} ;
         T001613_A30MvADItem = new int[1] ;
         T001613_A13MvATip = new string[] {""} ;
         T001613_A14MvACod = new string[] {""} ;
         T00162_A1249MVADCosto = new decimal[1] ;
         T00162_A30MvADItem = new int[1] ;
         T00162_A1248MvADCant = new decimal[1] ;
         T00162_A1266MVADVentaU = new decimal[1] ;
         T00162_A1258MVADRef1 = new string[] {""} ;
         T00162_A1259MVADRef2 = new string[] {""} ;
         T00162_A1260MVADRef3 = new string[] {""} ;
         T00162_A1261MVADRef4 = new string[] {""} ;
         T00162_A1262MVADRef5 = new string[] {""} ;
         T00162_A1247MVADBultos = new decimal[1] ;
         T00162_A1253MVADLote = new decimal[1] ;
         T00162_A1263MVADSts = new short[1] ;
         T00162_A1264MVADUbi = new int[1] ;
         T00162_n1264MVADUbi = new bool[] {false} ;
         T00162_A1257MVADObs = new string[] {""} ;
         T00162_A1250MVADPrecio = new decimal[1] ;
         T00162_A13MvATip = new string[] {""} ;
         T00162_A14MvACod = new string[] {""} ;
         T00162_A28ProdCod = new string[] {""} ;
         T001617_A52LinCod = new int[1] ;
         T001617_A55ProdDsc = new string[] {""} ;
         T001618_A1158LinStk = new short[1] ;
         T001619_A13MvATip = new string[] {""} ;
         T001619_A14MvACod = new string[] {""} ;
         T001619_A30MvADItem = new int[1] ;
         T001619_A31MVADLRef1 = new string[] {""} ;
         T001620_A13MvATip = new string[] {""} ;
         T001620_A14MvACod = new string[] {""} ;
         T001620_A30MvADItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001621_A13MvATip = new string[] {""} ;
         ZZ13MvATip = "";
         ZZ14MvACod = "";
         ZZ28ProdCod = "";
         ZZ1258MVADRef1 = "";
         ZZ1259MVADRef2 = "";
         ZZ1260MVADRef3 = "";
         ZZ1261MVADRef4 = "";
         ZZ1262MVADRef5 = "";
         ZZ1257MVADObs = "";
         ZZ55ProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aguiasdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguiasdet__default(),
            new Object[][] {
                new Object[] {
               T00162_A1249MVADCosto, T00162_A30MvADItem, T00162_A1248MvADCant, T00162_A1266MVADVentaU, T00162_A1258MVADRef1, T00162_A1259MVADRef2, T00162_A1260MVADRef3, T00162_A1261MVADRef4, T00162_A1262MVADRef5, T00162_A1247MVADBultos,
               T00162_A1253MVADLote, T00162_A1263MVADSts, T00162_A1264MVADUbi, T00162_n1264MVADUbi, T00162_A1257MVADObs, T00162_A1250MVADPrecio, T00162_A13MvATip, T00162_A14MvACod, T00162_A28ProdCod
               }
               , new Object[] {
               T00163_A1249MVADCosto, T00163_A30MvADItem, T00163_A1248MvADCant, T00163_A1266MVADVentaU, T00163_A1258MVADRef1, T00163_A1259MVADRef2, T00163_A1260MVADRef3, T00163_A1261MVADRef4, T00163_A1262MVADRef5, T00163_A1247MVADBultos,
               T00163_A1253MVADLote, T00163_A1263MVADSts, T00163_A1264MVADUbi, T00163_n1264MVADUbi, T00163_A1257MVADObs, T00163_A1250MVADPrecio, T00163_A13MvATip, T00163_A14MvACod, T00163_A28ProdCod
               }
               , new Object[] {
               T00164_A13MvATip
               }
               , new Object[] {
               T00165_A52LinCod, T00165_A55ProdDsc
               }
               , new Object[] {
               T00166_A1158LinStk
               }
               , new Object[] {
               T00167_A52LinCod, T00167_A1249MVADCosto, T00167_A30MvADItem, T00167_A55ProdDsc, T00167_A1248MvADCant, T00167_A1158LinStk, T00167_A1266MVADVentaU, T00167_A1258MVADRef1, T00167_A1259MVADRef2, T00167_A1260MVADRef3,
               T00167_A1261MVADRef4, T00167_A1262MVADRef5, T00167_A1247MVADBultos, T00167_A1253MVADLote, T00167_A1263MVADSts, T00167_A1264MVADUbi, T00167_n1264MVADUbi, T00167_A1257MVADObs, T00167_A1250MVADPrecio, T00167_A13MvATip,
               T00167_A14MvACod, T00167_A28ProdCod
               }
               , new Object[] {
               T00168_A13MvATip
               }
               , new Object[] {
               T00169_A52LinCod, T00169_A55ProdDsc
               }
               , new Object[] {
               T001610_A1158LinStk
               }
               , new Object[] {
               T001611_A13MvATip, T001611_A14MvACod, T001611_A30MvADItem
               }
               , new Object[] {
               T001612_A30MvADItem, T001612_A13MvATip, T001612_A14MvACod
               }
               , new Object[] {
               T001613_A30MvADItem, T001613_A13MvATip, T001613_A14MvACod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001617_A52LinCod, T001617_A55ProdDsc
               }
               , new Object[] {
               T001618_A1158LinStk
               }
               , new Object[] {
               T001619_A13MvATip, T001619_A14MvACod, T001619_A30MvADItem, T001619_A31MVADLRef1
               }
               , new Object[] {
               T001620_A13MvATip, T001620_A14MvACod, T001620_A30MvADItem
               }
               , new Object[] {
               T001621_A13MvATip
               }
            }
         );
      }

      private short Z1263MVADSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1158LinStk ;
      private short A1263MVADSts ;
      private short GX_JID ;
      private short Z1158LinStk ;
      private short RcdFound40 ;
      private short nIsDirty_40 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1263MVADSts ;
      private short ZZ1158LinStk ;
      private int Z30MvADItem ;
      private int Z1264MVADUbi ;
      private int A52LinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMvATip_Enabled ;
      private int edtMvACod_Enabled ;
      private int edtProdDsc_Enabled ;
      private int edtMvADCant_Enabled ;
      private int edtProdCod_Enabled ;
      private int A30MvADItem ;
      private int edtMvADItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLinStk_Enabled ;
      private int edtMVADVentaU_Enabled ;
      private int edtMVADVentaT_Enabled ;
      private int edtMVADRef1_Enabled ;
      private int edtMVADRef2_Enabled ;
      private int edtMVADRef3_Enabled ;
      private int edtMVADRef4_Enabled ;
      private int edtMVADRef5_Enabled ;
      private int edtMVADBultos_Enabled ;
      private int edtMVADLote_Enabled ;
      private int edtMVADSts_Enabled ;
      private int A1264MVADUbi ;
      private int edtMVADUbi_Enabled ;
      private int edtMVADObs_Enabled ;
      private int edtMVADPrecio_Enabled ;
      private int edtMVADCosto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z52LinCod ;
      private int idxLst ;
      private int ZZ30MvADItem ;
      private int ZZ1264MVADUbi ;
      private int ZZ52LinCod ;
      private decimal Z1249MVADCosto ;
      private decimal Z1248MvADCant ;
      private decimal Z1266MVADVentaU ;
      private decimal Z1247MVADBultos ;
      private decimal Z1253MVADLote ;
      private decimal Z1250MVADPrecio ;
      private decimal A1248MvADCant ;
      private decimal A1266MVADVentaU ;
      private decimal A1265MVADVentaT ;
      private decimal A1247MVADBultos ;
      private decimal A1253MVADLote ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private decimal Z1265MVADVentaT ;
      private decimal ZZ1248MvADCant ;
      private decimal ZZ1266MVADVentaU ;
      private decimal ZZ1247MVADBultos ;
      private decimal ZZ1253MVADLote ;
      private decimal ZZ1250MVADPrecio ;
      private decimal ZZ1265MVADVentaT ;
      private decimal ZZ1249MVADCosto ;
      private string sPrefix ;
      private string Z13MvATip ;
      private string Z14MvACod ;
      private string Z1258MVADRef1 ;
      private string Z1259MVADRef2 ;
      private string Z1260MVADRef3 ;
      private string Z1261MVADRef4 ;
      private string Z1262MVADRef5 ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMvATip_Internalname ;
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
      private string edtMvATip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMvACod_Internalname ;
      private string edtMvACod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMvADCant_Internalname ;
      private string edtMvADCant_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtMvADItem_Internalname ;
      private string edtMvADItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLinStk_Internalname ;
      private string edtLinStk_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtMVADVentaU_Internalname ;
      private string edtMVADVentaU_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtMVADVentaT_Internalname ;
      private string edtMVADVentaT_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtMVADRef1_Internalname ;
      private string A1258MVADRef1 ;
      private string edtMVADRef1_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtMVADRef2_Internalname ;
      private string A1259MVADRef2 ;
      private string edtMVADRef2_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtMVADRef3_Internalname ;
      private string A1260MVADRef3 ;
      private string edtMVADRef3_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtMVADRef4_Internalname ;
      private string A1261MVADRef4 ;
      private string edtMVADRef4_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtMVADRef5_Internalname ;
      private string A1262MVADRef5 ;
      private string edtMVADRef5_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtMVADBultos_Internalname ;
      private string edtMVADBultos_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtMVADLote_Internalname ;
      private string edtMVADLote_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtMVADSts_Internalname ;
      private string edtMVADSts_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtMVADUbi_Internalname ;
      private string edtMVADUbi_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtMVADObs_Internalname ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtMVADPrecio_Internalname ;
      private string edtMVADPrecio_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtMVADCosto_Internalname ;
      private string edtMVADCosto_Jsonclick ;
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
      private string sMode40 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ13MvATip ;
      private string ZZ14MvACod ;
      private string ZZ28ProdCod ;
      private string ZZ1258MVADRef1 ;
      private string ZZ1259MVADRef2 ;
      private string ZZ1260MVADRef3 ;
      private string ZZ1261MVADRef4 ;
      private string ZZ1262MVADRef5 ;
      private string ZZ55ProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1264MVADUbi ;
      private bool Gx_longc ;
      private string A1257MVADObs ;
      private string Z1257MVADObs ;
      private string ZZ1257MVADObs ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00167_A52LinCod ;
      private decimal[] T00167_A1249MVADCosto ;
      private int[] T00167_A30MvADItem ;
      private string[] T00167_A55ProdDsc ;
      private decimal[] T00167_A1248MvADCant ;
      private short[] T00167_A1158LinStk ;
      private decimal[] T00167_A1266MVADVentaU ;
      private string[] T00167_A1258MVADRef1 ;
      private string[] T00167_A1259MVADRef2 ;
      private string[] T00167_A1260MVADRef3 ;
      private string[] T00167_A1261MVADRef4 ;
      private string[] T00167_A1262MVADRef5 ;
      private decimal[] T00167_A1247MVADBultos ;
      private decimal[] T00167_A1253MVADLote ;
      private short[] T00167_A1263MVADSts ;
      private int[] T00167_A1264MVADUbi ;
      private bool[] T00167_n1264MVADUbi ;
      private string[] T00167_A1257MVADObs ;
      private decimal[] T00167_A1250MVADPrecio ;
      private string[] T00167_A13MvATip ;
      private string[] T00167_A14MvACod ;
      private string[] T00167_A28ProdCod ;
      private string[] T00164_A13MvATip ;
      private int[] T00165_A52LinCod ;
      private string[] T00165_A55ProdDsc ;
      private short[] T00166_A1158LinStk ;
      private string[] T00168_A13MvATip ;
      private int[] T00169_A52LinCod ;
      private string[] T00169_A55ProdDsc ;
      private short[] T001610_A1158LinStk ;
      private string[] T001611_A13MvATip ;
      private string[] T001611_A14MvACod ;
      private int[] T001611_A30MvADItem ;
      private decimal[] T00163_A1249MVADCosto ;
      private int[] T00163_A30MvADItem ;
      private decimal[] T00163_A1248MvADCant ;
      private decimal[] T00163_A1266MVADVentaU ;
      private string[] T00163_A1258MVADRef1 ;
      private string[] T00163_A1259MVADRef2 ;
      private string[] T00163_A1260MVADRef3 ;
      private string[] T00163_A1261MVADRef4 ;
      private string[] T00163_A1262MVADRef5 ;
      private decimal[] T00163_A1247MVADBultos ;
      private decimal[] T00163_A1253MVADLote ;
      private short[] T00163_A1263MVADSts ;
      private int[] T00163_A1264MVADUbi ;
      private bool[] T00163_n1264MVADUbi ;
      private string[] T00163_A1257MVADObs ;
      private decimal[] T00163_A1250MVADPrecio ;
      private string[] T00163_A13MvATip ;
      private string[] T00163_A14MvACod ;
      private string[] T00163_A28ProdCod ;
      private int[] T001612_A30MvADItem ;
      private string[] T001612_A13MvATip ;
      private string[] T001612_A14MvACod ;
      private int[] T001613_A30MvADItem ;
      private string[] T001613_A13MvATip ;
      private string[] T001613_A14MvACod ;
      private decimal[] T00162_A1249MVADCosto ;
      private int[] T00162_A30MvADItem ;
      private decimal[] T00162_A1248MvADCant ;
      private decimal[] T00162_A1266MVADVentaU ;
      private string[] T00162_A1258MVADRef1 ;
      private string[] T00162_A1259MVADRef2 ;
      private string[] T00162_A1260MVADRef3 ;
      private string[] T00162_A1261MVADRef4 ;
      private string[] T00162_A1262MVADRef5 ;
      private decimal[] T00162_A1247MVADBultos ;
      private decimal[] T00162_A1253MVADLote ;
      private short[] T00162_A1263MVADSts ;
      private int[] T00162_A1264MVADUbi ;
      private bool[] T00162_n1264MVADUbi ;
      private string[] T00162_A1257MVADObs ;
      private decimal[] T00162_A1250MVADPrecio ;
      private string[] T00162_A13MvATip ;
      private string[] T00162_A14MvACod ;
      private string[] T00162_A28ProdCod ;
      private int[] T001617_A52LinCod ;
      private string[] T001617_A55ProdDsc ;
      private short[] T001618_A1158LinStk ;
      private string[] T001619_A13MvATip ;
      private string[] T001619_A14MvACod ;
      private int[] T001619_A30MvADItem ;
      private string[] T001619_A31MVADLRef1 ;
      private string[] T001620_A13MvATip ;
      private string[] T001620_A14MvACod ;
      private int[] T001620_A30MvADItem ;
      private string[] T001621_A13MvATip ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aguiasdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aguiasdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00167;
        prmT00167 = new Object[] {
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00164;
        prmT00164 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00165;
        prmT00165 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00166;
        prmT00166 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT00168;
        prmT00168 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00169;
        prmT00169 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001610;
        prmT001610 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT001611;
        prmT001611 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT00163;
        prmT00163 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT001612;
        prmT001612 = new Object[] {
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001613;
        prmT001613 = new Object[] {
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00162;
        prmT00162 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT001614;
        prmT001614 = new Object[] {
        new ParDef("@MVADCosto",GXType.Decimal,15,2) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MvADCant",GXType.Decimal,15,4) ,
        new ParDef("@MVADVentaU",GXType.Decimal,18,6) ,
        new ParDef("@MVADRef1",GXType.NChar,20,0) ,
        new ParDef("@MVADRef2",GXType.NChar,20,0) ,
        new ParDef("@MVADRef3",GXType.NChar,20,0) ,
        new ParDef("@MVADRef4",GXType.NChar,20,0) ,
        new ParDef("@MVADRef5",GXType.NChar,20,0) ,
        new ParDef("@MVADBultos",GXType.Decimal,15,4) ,
        new ParDef("@MVADLote",GXType.Decimal,15,4) ,
        new ParDef("@MVADSts",GXType.Int16,1,0) ,
        new ParDef("@MVADUbi",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVADObs",GXType.NVarChar,2000,0) ,
        new ParDef("@MVADPrecio",GXType.Decimal,18,6) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001615;
        prmT001615 = new Object[] {
        new ParDef("@MVADCosto",GXType.Decimal,15,2) ,
        new ParDef("@MvADCant",GXType.Decimal,15,4) ,
        new ParDef("@MVADVentaU",GXType.Decimal,18,6) ,
        new ParDef("@MVADRef1",GXType.NChar,20,0) ,
        new ParDef("@MVADRef2",GXType.NChar,20,0) ,
        new ParDef("@MVADRef3",GXType.NChar,20,0) ,
        new ParDef("@MVADRef4",GXType.NChar,20,0) ,
        new ParDef("@MVADRef5",GXType.NChar,20,0) ,
        new ParDef("@MVADBultos",GXType.Decimal,15,4) ,
        new ParDef("@MVADLote",GXType.Decimal,15,4) ,
        new ParDef("@MVADSts",GXType.Int16,1,0) ,
        new ParDef("@MVADUbi",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVADObs",GXType.NVarChar,2000,0) ,
        new ParDef("@MVADPrecio",GXType.Decimal,18,6) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT001616;
        prmT001616 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT001619;
        prmT001619 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT001620;
        prmT001620 = new Object[] {
        };
        Object[] prmT001621;
        prmT001621 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001617;
        prmT001617 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001618;
        prmT001618 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00162", "SELECT [MVADCosto], [MvADItem], [MvADCant], [MVADVentaU], [MVADRef1], [MVADRef2], [MVADRef3], [MVADRef4], [MVADRef5], [MVADBultos], [MVADLote], [MVADSts], [MVADUbi], [MVADObs], [MVADPrecio], [MvATip], [MvACod], [ProdCod] FROM [AGUIASDET] WITH (UPDLOCK) WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00162,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00163", "SELECT [MVADCosto], [MvADItem], [MvADCant], [MVADVentaU], [MVADRef1], [MVADRef2], [MVADRef3], [MVADRef4], [MVADRef5], [MVADBultos], [MVADLote], [MVADSts], [MVADUbi], [MVADObs], [MVADPrecio], [MvATip], [MvACod], [ProdCod] FROM [AGUIASDET] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00163,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00164", "SELECT [MvATip] FROM [AGUIAS] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00164,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00165", "SELECT [LinCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00165,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00166", "SELECT [LinStk] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00166,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00167", "SELECT T2.[LinCod], TM1.[MVADCosto], TM1.[MvADItem], T2.[ProdDsc], TM1.[MvADCant], T3.[LinStk], TM1.[MVADVentaU], TM1.[MVADRef1], TM1.[MVADRef2], TM1.[MVADRef3], TM1.[MVADRef4], TM1.[MVADRef5], TM1.[MVADBultos], TM1.[MVADLote], TM1.[MVADSts], TM1.[MVADUbi], TM1.[MVADObs], TM1.[MVADPrecio], TM1.[MvATip], TM1.[MvACod], TM1.[ProdCod] FROM (([AGUIASDET] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) WHERE TM1.[MvADItem] = @MvADItem and TM1.[MvATip] = @MvATip and TM1.[MvACod] = @MvACod ORDER BY TM1.[MvATip], TM1.[MvACod], TM1.[MvADItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00167,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00168", "SELECT [MvATip] FROM [AGUIAS] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00168,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00169", "SELECT [LinCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00169,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001610", "SELECT [LinStk] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001610,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001611", "SELECT [MvATip], [MvACod], [MvADItem] FROM [AGUIASDET] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001611,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001612", "SELECT TOP 1 [MvADItem], [MvATip], [MvACod] FROM [AGUIASDET] WHERE ( [MvADItem] > @MvADItem or [MvADItem] = @MvADItem and [MvATip] > @MvATip or [MvATip] = @MvATip and [MvADItem] = @MvADItem and [MvACod] > @MvACod) ORDER BY [MvATip], [MvACod], [MvADItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001613", "SELECT TOP 1 [MvADItem], [MvATip], [MvACod] FROM [AGUIASDET] WHERE ( [MvADItem] < @MvADItem or [MvADItem] = @MvADItem and [MvATip] < @MvATip or [MvATip] = @MvATip and [MvADItem] = @MvADItem and [MvACod] < @MvACod) ORDER BY [MvATip] DESC, [MvACod] DESC, [MvADItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001613,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001614", "INSERT INTO [AGUIASDET]([MVADCosto], [MvADItem], [MvADCant], [MVADVentaU], [MVADRef1], [MVADRef2], [MVADRef3], [MVADRef4], [MVADRef5], [MVADBultos], [MVADLote], [MVADSts], [MVADUbi], [MVADObs], [MVADPrecio], [MvATip], [MvACod], [ProdCod]) VALUES(@MVADCosto, @MvADItem, @MvADCant, @MVADVentaU, @MVADRef1, @MVADRef2, @MVADRef3, @MVADRef4, @MVADRef5, @MVADBultos, @MVADLote, @MVADSts, @MVADUbi, @MVADObs, @MVADPrecio, @MvATip, @MvACod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT001614)
           ,new CursorDef("T001615", "UPDATE [AGUIASDET] SET [MVADCosto]=@MVADCosto, [MvADCant]=@MvADCant, [MVADVentaU]=@MVADVentaU, [MVADRef1]=@MVADRef1, [MVADRef2]=@MVADRef2, [MVADRef3]=@MVADRef3, [MVADRef4]=@MVADRef4, [MVADRef5]=@MVADRef5, [MVADBultos]=@MVADBultos, [MVADLote]=@MVADLote, [MVADSts]=@MVADSts, [MVADUbi]=@MVADUbi, [MVADObs]=@MVADObs, [MVADPrecio]=@MVADPrecio, [ProdCod]=@ProdCod  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem", GxErrorMask.GX_NOMASK,prmT001615)
           ,new CursorDef("T001616", "DELETE FROM [AGUIASDET]  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem", GxErrorMask.GX_NOMASK,prmT001616)
           ,new CursorDef("T001617", "SELECT [LinCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001617,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001618", "SELECT [LinStk] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001618,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001619", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem], [MVADLRef1] FROM [AGUIASDETLOTE] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001619,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001620", "SELECT [MvATip], [MvACod], [MvADItem] FROM [AGUIASDET] ORDER BY [MvATip], [MvACod], [MvADItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001620,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001621", "SELECT [MvATip] FROM [AGUIAS] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001621,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              ((string[]) buf[14])[0] = rslt.getLongVarchar(14);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
              ((string[]) buf[16])[0] = rslt.getString(16, 3);
              ((string[]) buf[17])[0] = rslt.getString(17, 12);
              ((string[]) buf[18])[0] = rslt.getString(18, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              ((string[]) buf[14])[0] = rslt.getLongVarchar(14);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
              ((string[]) buf[16])[0] = rslt.getString(16, 3);
              ((string[]) buf[17])[0] = rslt.getString(17, 12);
              ((string[]) buf[18])[0] = rslt.getString(18, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((bool[]) buf[16])[0] = rslt.wasNull(16);
              ((string[]) buf[17])[0] = rslt.getLongVarchar(17);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
              ((string[]) buf[19])[0] = rslt.getString(19, 3);
              ((string[]) buf[20])[0] = rslt.getString(20, 12);
              ((string[]) buf[21])[0] = rslt.getString(21, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
