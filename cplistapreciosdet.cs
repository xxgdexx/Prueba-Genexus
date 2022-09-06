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
   public class cplistapreciosdet : GXDataArea
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
            A284CPLisProdCod = GetPar( "CPLisProdCod");
            AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A284CPLisProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A300PrvConpCod = (int)(NumberUtil.Val( GetPar( "PrvConpCod"), "."));
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A300PrvConpCod) ;
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
            Form.Meta.addItem("description", "Detalle de Lista de Precios Proveedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCPLisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cplistapreciosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cplistapreciosdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLISTAPRECIOSDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Producto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisProdCod_Internalname, StringUtil.RTrim( A284CPLisProdCod), StringUtil.RTrim( context.localUtil.Format( A284CPLisProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Orden", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisPrvItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A285CPLisPrvItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtCPLisPrvItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A285CPLisPrvItem), "ZZZ9") : context.localUtil.Format( (decimal)(A285CPLisPrvItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisPrvItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisPrvItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Proveedor", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Razon Social", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDsc_Internalname, StringUtil.RTrim( A247PrvDsc), StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Dirección", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDir_Internalname, StringUtil.RTrim( A1763PrvDir), StringUtil.RTrim( context.localUtil.Format( A1763PrvDir, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Condicion de pago", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A300PrvConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPrvConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A300PrvConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A300PrvConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Condición de Pago", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvConpDsc_Internalname, StringUtil.RTrim( A1756PrvConpDsc), StringUtil.RTrim( context.localUtil.Format( A1756PrvConpDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Importe MN", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisPrvMN_Internalname, StringUtil.LTrim( StringUtil.NToC( A829CPLisPrvMN, 17, 4, ".", "")), StringUtil.LTrim( ((edtCPLisPrvMN_Enabled!=0) ? context.localUtil.Format( A829CPLisPrvMN, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A829CPLisPrvMN, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisPrvMN_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisPrvMN_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Importe ME", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisPrvME_Internalname, StringUtil.LTrim( StringUtil.NToC( A828CPLisPrvME, 17, 4, ".", "")), StringUtil.LTrim( ((edtCPLisPrvME_Enabled!=0) ? context.localUtil.Format( A828CPLisPrvME, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A828CPLisPrvME, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisPrvME_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisPrvME_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPLISTAPRECIOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPLISTAPRECIOSDET.htm");
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
            Z284CPLisProdCod = cgiGet( "Z284CPLisProdCod");
            Z285CPLisPrvItem = (short)(context.localUtil.CToN( cgiGet( "Z285CPLisPrvItem"), ".", ","));
            Z829CPLisPrvMN = context.localUtil.CToN( cgiGet( "Z829CPLisPrvMN"), ".", ",");
            Z828CPLisPrvME = context.localUtil.CToN( cgiGet( "Z828CPLisPrvME"), ".", ",");
            Z244PrvCod = cgiGet( "Z244PrvCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A284CPLisProdCod = StringUtil.Upper( cgiGet( edtCPLisProdCod_Internalname));
            AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPLisPrvItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPLisPrvItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPLISPRVITEM");
               AnyError = 1;
               GX_FocusControl = edtCPLisPrvItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A285CPLisPrvItem = 0;
               AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
            }
            else
            {
               A285CPLisPrvItem = (short)(context.localUtil.CToN( cgiGet( edtCPLisPrvItem_Internalname), ".", ","));
               AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
            }
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A247PrvDsc = cgiGet( edtPrvDsc_Internalname);
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = cgiGet( edtPrvDir_Internalname);
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A300PrvConpCod = (int)(context.localUtil.CToN( cgiGet( edtPrvConpCod_Internalname), ".", ","));
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            A1756PrvConpDsc = cgiGet( edtPrvConpDsc_Internalname);
            AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPLisPrvMN_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPLisPrvMN_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPLISPRVMN");
               AnyError = 1;
               GX_FocusControl = edtCPLisPrvMN_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A829CPLisPrvMN = 0;
               AssignAttri("", false, "A829CPLisPrvMN", StringUtil.LTrimStr( A829CPLisPrvMN, 15, 4));
            }
            else
            {
               A829CPLisPrvMN = context.localUtil.CToN( cgiGet( edtCPLisPrvMN_Internalname), ".", ",");
               AssignAttri("", false, "A829CPLisPrvMN", StringUtil.LTrimStr( A829CPLisPrvMN, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPLisPrvME_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPLisPrvME_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPLISPRVME");
               AnyError = 1;
               GX_FocusControl = edtCPLisPrvME_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A828CPLisPrvME = 0;
               AssignAttri("", false, "A828CPLisPrvME", StringUtil.LTrimStr( A828CPLisPrvME, 15, 4));
            }
            else
            {
               A828CPLisPrvME = context.localUtil.CToN( cgiGet( edtCPLisPrvME_Internalname), ".", ",");
               AssignAttri("", false, "A828CPLisPrvME", StringUtil.LTrimStr( A828CPLisPrvME, 15, 4));
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
               A284CPLisProdCod = GetPar( "CPLisProdCod");
               AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
               A285CPLisPrvItem = (short)(NumberUtil.Val( GetPar( "CPLisPrvItem"), "."));
               AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
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
               InitAll3G119( ) ;
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
         DisableAttributes3G119( ) ;
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

      protected void CONFIRM_3G0( )
      {
         BeforeValidate3G119( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3G119( ) ;
            }
            else
            {
               CheckExtendedTable3G119( ) ;
               if ( AnyError == 0 )
               {
                  ZM3G119( 2) ;
                  ZM3G119( 3) ;
                  ZM3G119( 4) ;
               }
               CloseExtendedTableCursors3G119( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3G0( ) ;
         }
      }

      protected void ResetCaption3G0( )
      {
      }

      protected void ZM3G119( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z829CPLisPrvMN = T003G3_A829CPLisPrvMN[0];
               Z828CPLisPrvME = T003G3_A828CPLisPrvME[0];
               Z244PrvCod = T003G3_A244PrvCod[0];
            }
            else
            {
               Z829CPLisPrvMN = A829CPLisPrvMN;
               Z828CPLisPrvME = A828CPLisPrvME;
               Z244PrvCod = A244PrvCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z285CPLisPrvItem = A285CPLisPrvItem;
            Z829CPLisPrvMN = A829CPLisPrvMN;
            Z828CPLisPrvME = A828CPLisPrvME;
            Z284CPLisProdCod = A284CPLisProdCod;
            Z244PrvCod = A244PrvCod;
            Z247PrvDsc = A247PrvDsc;
            Z1763PrvDir = A1763PrvDir;
            Z300PrvConpCod = A300PrvConpCod;
            Z1756PrvConpDsc = A1756PrvConpDsc;
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

      protected void Load3G119( )
      {
         /* Using cursor T003G7 */
         pr_default.execute(5, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound119 = 1;
            A247PrvDsc = T003G7_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = T003G7_A1763PrvDir[0];
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A1756PrvConpDsc = T003G7_A1756PrvConpDsc[0];
            AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
            A829CPLisPrvMN = T003G7_A829CPLisPrvMN[0];
            AssignAttri("", false, "A829CPLisPrvMN", StringUtil.LTrimStr( A829CPLisPrvMN, 15, 4));
            A828CPLisPrvME = T003G7_A828CPLisPrvME[0];
            AssignAttri("", false, "A828CPLisPrvME", StringUtil.LTrimStr( A828CPLisPrvME, 15, 4));
            A244PrvCod = T003G7_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A300PrvConpCod = T003G7_A300PrvConpCod[0];
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            ZM3G119( -1) ;
         }
         pr_default.close(5);
         OnLoadActions3G119( ) ;
      }

      protected void OnLoadActions3G119( )
      {
      }

      protected void CheckExtendedTable3G119( )
      {
         nIsDirty_119 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003G4 */
         pr_default.execute(2, new Object[] {A284CPLisProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista de Precios Proveedores'.", "ForeignKeyNotFound", 1, "CPLISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T003G5 */
         pr_default.execute(3, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T003G5_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = T003G5_A1763PrvDir[0];
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         A300PrvConpCod = T003G5_A300PrvConpCod[0];
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
         pr_default.close(3);
         /* Using cursor T003G6 */
         pr_default.execute(4, new Object[] {A300PrvConpCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion pago'.", "ForeignKeyNotFound", 1, "PRVCONPCOD");
            AnyError = 1;
         }
         A1756PrvConpDsc = T003G6_A1756PrvConpDsc[0];
         AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors3G119( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A284CPLisProdCod )
      {
         /* Using cursor T003G8 */
         pr_default.execute(6, new Object[] {A284CPLisProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista de Precios Proveedores'.", "ForeignKeyNotFound", 1, "CPLISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisProdCod_Internalname;
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

      protected void gxLoad_3( string A244PrvCod )
      {
         /* Using cursor T003G9 */
         pr_default.execute(7, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T003G9_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = T003G9_A1763PrvDir[0];
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         A300PrvConpCod = T003G9_A300PrvConpCod[0];
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A247PrvDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1763PrvDir))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A300PrvConpCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( int A300PrvConpCod )
      {
         /* Using cursor T003G10 */
         pr_default.execute(8, new Object[] {A300PrvConpCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion pago'.", "ForeignKeyNotFound", 1, "PRVCONPCOD");
            AnyError = 1;
         }
         A1756PrvConpDsc = T003G10_A1756PrvConpDsc[0];
         AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1756PrvConpDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey3G119( )
      {
         /* Using cursor T003G11 */
         pr_default.execute(9, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound119 = 1;
         }
         else
         {
            RcdFound119 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003G3 */
         pr_default.execute(1, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3G119( 1) ;
            RcdFound119 = 1;
            A285CPLisPrvItem = T003G3_A285CPLisPrvItem[0];
            AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
            A829CPLisPrvMN = T003G3_A829CPLisPrvMN[0];
            AssignAttri("", false, "A829CPLisPrvMN", StringUtil.LTrimStr( A829CPLisPrvMN, 15, 4));
            A828CPLisPrvME = T003G3_A828CPLisPrvME[0];
            AssignAttri("", false, "A828CPLisPrvME", StringUtil.LTrimStr( A828CPLisPrvME, 15, 4));
            A284CPLisProdCod = T003G3_A284CPLisProdCod[0];
            AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
            A244PrvCod = T003G3_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            Z284CPLisProdCod = A284CPLisProdCod;
            Z285CPLisPrvItem = A285CPLisPrvItem;
            sMode119 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3G119( ) ;
            if ( AnyError == 1 )
            {
               RcdFound119 = 0;
               InitializeNonKey3G119( ) ;
            }
            Gx_mode = sMode119;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound119 = 0;
            InitializeNonKey3G119( ) ;
            sMode119 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode119;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3G119( ) ;
         if ( RcdFound119 == 0 )
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
         RcdFound119 = 0;
         /* Using cursor T003G12 */
         pr_default.execute(10, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T003G12_A284CPLisProdCod[0], A284CPLisProdCod) < 0 ) || ( StringUtil.StrCmp(T003G12_A284CPLisProdCod[0], A284CPLisProdCod) == 0 ) && ( T003G12_A285CPLisPrvItem[0] < A285CPLisPrvItem ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T003G12_A284CPLisProdCod[0], A284CPLisProdCod) > 0 ) || ( StringUtil.StrCmp(T003G12_A284CPLisProdCod[0], A284CPLisProdCod) == 0 ) && ( T003G12_A285CPLisPrvItem[0] > A285CPLisPrvItem ) ) )
            {
               A284CPLisProdCod = T003G12_A284CPLisProdCod[0];
               AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
               A285CPLisPrvItem = T003G12_A285CPLisPrvItem[0];
               AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
               RcdFound119 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound119 = 0;
         /* Using cursor T003G13 */
         pr_default.execute(11, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T003G13_A284CPLisProdCod[0], A284CPLisProdCod) > 0 ) || ( StringUtil.StrCmp(T003G13_A284CPLisProdCod[0], A284CPLisProdCod) == 0 ) && ( T003G13_A285CPLisPrvItem[0] > A285CPLisPrvItem ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T003G13_A284CPLisProdCod[0], A284CPLisProdCod) < 0 ) || ( StringUtil.StrCmp(T003G13_A284CPLisProdCod[0], A284CPLisProdCod) == 0 ) && ( T003G13_A285CPLisPrvItem[0] < A285CPLisPrvItem ) ) )
            {
               A284CPLisProdCod = T003G13_A284CPLisProdCod[0];
               AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
               A285CPLisPrvItem = T003G13_A285CPLisPrvItem[0];
               AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
               RcdFound119 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3G119( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCPLisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3G119( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound119 == 1 )
            {
               if ( ( StringUtil.StrCmp(A284CPLisProdCod, Z284CPLisProdCod) != 0 ) || ( A285CPLisPrvItem != Z285CPLisPrvItem ) )
               {
                  A284CPLisProdCod = Z284CPLisProdCod;
                  AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
                  A285CPLisPrvItem = Z285CPLisPrvItem;
                  AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CPLISPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPLisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCPLisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3G119( ) ;
                  GX_FocusControl = edtCPLisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A284CPLisProdCod, Z284CPLisProdCod) != 0 ) || ( A285CPLisPrvItem != Z285CPLisPrvItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCPLisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3G119( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPLISPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCPLisProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCPLisProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3G119( ) ;
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
         if ( ( StringUtil.StrCmp(A284CPLisProdCod, Z284CPLisProdCod) != 0 ) || ( A285CPLisPrvItem != Z285CPLisPrvItem ) )
         {
            A284CPLisProdCod = Z284CPLisProdCod;
            AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
            A285CPLisPrvItem = Z285CPLisPrvItem;
            AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CPLISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCPLisProdCod_Internalname;
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
         GetKey3G119( ) ;
         if ( RcdFound119 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CPLISPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtCPLisProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A284CPLisProdCod, Z284CPLisProdCod) != 0 ) || ( A285CPLisPrvItem != Z285CPLisPrvItem ) )
            {
               A284CPLisProdCod = Z284CPLisProdCod;
               AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
               A285CPLisPrvItem = Z285CPLisPrvItem;
               AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CPLISPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtCPLisProdCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A284CPLisProdCod, Z284CPLisProdCod) != 0 ) || ( A285CPLisPrvItem != Z285CPLisPrvItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPLISPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPLisProdCod_Internalname;
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
         context.RollbackDataStores("cplistapreciosdet",pr_default);
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3G0( ) ;
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
         if ( RcdFound119 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CPLISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3G119( ) ;
         if ( RcdFound119 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3G119( ) ;
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
         if ( RcdFound119 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
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
         if ( RcdFound119 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
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
         ScanStart3G119( ) ;
         if ( RcdFound119 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound119 != 0 )
            {
               ScanNext3G119( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3G119( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3G119( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003G2 */
            pr_default.execute(0, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLISTAPRECIOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z829CPLisPrvMN != T003G2_A829CPLisPrvMN[0] ) || ( Z828CPLisPrvME != T003G2_A828CPLisPrvME[0] ) || ( StringUtil.StrCmp(Z244PrvCod, T003G2_A244PrvCod[0]) != 0 ) )
            {
               if ( Z829CPLisPrvMN != T003G2_A829CPLisPrvMN[0] )
               {
                  GXUtil.WriteLog("cplistapreciosdet:[seudo value changed for attri]"+"CPLisPrvMN");
                  GXUtil.WriteLogRaw("Old: ",Z829CPLisPrvMN);
                  GXUtil.WriteLogRaw("Current: ",T003G2_A829CPLisPrvMN[0]);
               }
               if ( Z828CPLisPrvME != T003G2_A828CPLisPrvME[0] )
               {
                  GXUtil.WriteLog("cplistapreciosdet:[seudo value changed for attri]"+"CPLisPrvME");
                  GXUtil.WriteLogRaw("Old: ",Z828CPLisPrvME);
                  GXUtil.WriteLogRaw("Current: ",T003G2_A828CPLisPrvME[0]);
               }
               if ( StringUtil.StrCmp(Z244PrvCod, T003G2_A244PrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cplistapreciosdet:[seudo value changed for attri]"+"PrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z244PrvCod);
                  GXUtil.WriteLogRaw("Current: ",T003G2_A244PrvCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLISTAPRECIOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3G119( )
      {
         BeforeValidate3G119( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3G119( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3G119( 0) ;
            CheckOptimisticConcurrency3G119( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3G119( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3G119( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003G14 */
                     pr_default.execute(12, new Object[] {A285CPLisPrvItem, A829CPLisPrvMN, A828CPLisPrvME, A284CPLisProdCod, A244PrvCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLISTAPRECIOSDET");
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
                           ResetCaption3G0( ) ;
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
               Load3G119( ) ;
            }
            EndLevel3G119( ) ;
         }
         CloseExtendedTableCursors3G119( ) ;
      }

      protected void Update3G119( )
      {
         BeforeValidate3G119( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3G119( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3G119( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3G119( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3G119( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003G15 */
                     pr_default.execute(13, new Object[] {A829CPLisPrvMN, A828CPLisPrvME, A244PrvCod, A284CPLisProdCod, A285CPLisPrvItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLISTAPRECIOSDET");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLISTAPRECIOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3G119( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3G0( ) ;
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
            EndLevel3G119( ) ;
         }
         CloseExtendedTableCursors3G119( ) ;
      }

      protected void DeferredUpdate3G119( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3G119( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3G119( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3G119( ) ;
            AfterConfirm3G119( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3G119( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003G16 */
                  pr_default.execute(14, new Object[] {A284CPLisProdCod, A285CPLisPrvItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLISTAPRECIOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound119 == 0 )
                        {
                           InitAll3G119( ) ;
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
                        ResetCaption3G0( ) ;
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
         sMode119 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3G119( ) ;
         Gx_mode = sMode119;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3G119( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003G17 */
            pr_default.execute(15, new Object[] {A244PrvCod});
            A247PrvDsc = T003G17_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = T003G17_A1763PrvDir[0];
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A300PrvConpCod = T003G17_A300PrvConpCod[0];
            AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
            pr_default.close(15);
            /* Using cursor T003G18 */
            pr_default.execute(16, new Object[] {A300PrvConpCod});
            A1756PrvConpDsc = T003G18_A1756PrvConpDsc[0];
            AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
            pr_default.close(16);
         }
      }

      protected void EndLevel3G119( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3G119( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("cplistapreciosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3G0( ) ;
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
            context.RollbackDataStores("cplistapreciosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3G119( )
      {
         /* Using cursor T003G19 */
         pr_default.execute(17);
         RcdFound119 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound119 = 1;
            A284CPLisProdCod = T003G19_A284CPLisProdCod[0];
            AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
            A285CPLisPrvItem = T003G19_A285CPLisPrvItem[0];
            AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3G119( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound119 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound119 = 1;
            A284CPLisProdCod = T003G19_A284CPLisProdCod[0];
            AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
            A285CPLisPrvItem = T003G19_A285CPLisPrvItem[0];
            AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
         }
      }

      protected void ScanEnd3G119( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm3G119( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3G119( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3G119( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3G119( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3G119( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3G119( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3G119( )
      {
         edtCPLisProdCod_Enabled = 0;
         AssignProp("", false, edtCPLisProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisProdCod_Enabled), 5, 0), true);
         edtCPLisPrvItem_Enabled = 0;
         AssignProp("", false, edtCPLisPrvItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisPrvItem_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtPrvDsc_Enabled = 0;
         AssignProp("", false, edtPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDsc_Enabled), 5, 0), true);
         edtPrvDir_Enabled = 0;
         AssignProp("", false, edtPrvDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDir_Enabled), 5, 0), true);
         edtPrvConpCod_Enabled = 0;
         AssignProp("", false, edtPrvConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvConpCod_Enabled), 5, 0), true);
         edtPrvConpDsc_Enabled = 0;
         AssignProp("", false, edtPrvConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvConpDsc_Enabled), 5, 0), true);
         edtCPLisPrvMN_Enabled = 0;
         AssignProp("", false, edtCPLisPrvMN_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisPrvMN_Enabled), 5, 0), true);
         edtCPLisPrvME_Enabled = 0;
         AssignProp("", false, edtCPLisPrvME_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisPrvME_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3G119( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025960", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cplistapreciosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z284CPLisProdCod", StringUtil.RTrim( Z284CPLisProdCod));
         GxWebStd.gx_hidden_field( context, "Z285CPLisPrvItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z285CPLisPrvItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z829CPLisPrvMN", StringUtil.LTrim( StringUtil.NToC( Z829CPLisPrvMN, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z828CPLisPrvME", StringUtil.LTrim( StringUtil.NToC( Z828CPLisPrvME, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
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
         return formatLink("cplistapreciosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLISTAPRECIOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle de Lista de Precios Proveedor" ;
      }

      protected void InitializeNonKey3G119( )
      {
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         A247PrvDsc = "";
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = "";
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         A300PrvConpCod = 0;
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrimStr( (decimal)(A300PrvConpCod), 6, 0));
         A1756PrvConpDsc = "";
         AssignAttri("", false, "A1756PrvConpDsc", A1756PrvConpDsc);
         A829CPLisPrvMN = 0;
         AssignAttri("", false, "A829CPLisPrvMN", StringUtil.LTrimStr( A829CPLisPrvMN, 15, 4));
         A828CPLisPrvME = 0;
         AssignAttri("", false, "A828CPLisPrvME", StringUtil.LTrimStr( A828CPLisPrvME, 15, 4));
         Z829CPLisPrvMN = 0;
         Z828CPLisPrvME = 0;
         Z244PrvCod = "";
      }

      protected void InitAll3G119( )
      {
         A284CPLisProdCod = "";
         AssignAttri("", false, "A284CPLisProdCod", A284CPLisProdCod);
         A285CPLisPrvItem = 0;
         AssignAttri("", false, "A285CPLisPrvItem", StringUtil.LTrimStr( (decimal)(A285CPLisPrvItem), 4, 0));
         InitializeNonKey3G119( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025967", true, true);
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
         context.AddJavascriptSource("cplistapreciosdet.js", "?20228181025967", false, true);
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
         edtCPLisProdCod_Internalname = "CPLISPRODCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCPLisPrvItem_Internalname = "CPLISPRVITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPrvCod_Internalname = "PRVCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPrvDsc_Internalname = "PRVDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPrvDir_Internalname = "PRVDIR";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPrvConpCod_Internalname = "PRVCONPCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPrvConpDsc_Internalname = "PRVCONPDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCPLisPrvMN_Internalname = "CPLISPRVMN";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCPLisPrvME_Internalname = "CPLISPRVME";
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
         Form.Caption = "Detalle de Lista de Precios Proveedor";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCPLisPrvME_Jsonclick = "";
         edtCPLisPrvME_Enabled = 1;
         edtCPLisPrvMN_Jsonclick = "";
         edtCPLisPrvMN_Enabled = 1;
         edtPrvConpDsc_Jsonclick = "";
         edtPrvConpDsc_Enabled = 0;
         edtPrvConpCod_Jsonclick = "";
         edtPrvConpCod_Enabled = 0;
         edtPrvDir_Jsonclick = "";
         edtPrvDir_Enabled = 0;
         edtPrvDsc_Jsonclick = "";
         edtPrvDsc_Enabled = 0;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCPLisPrvItem_Jsonclick = "";
         edtCPLisPrvItem_Enabled = 1;
         edtCPLisProdCod_Jsonclick = "";
         edtCPLisProdCod_Enabled = 1;
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
         /* Using cursor T003G20 */
         pr_default.execute(18, new Object[] {A284CPLisProdCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista de Precios Proveedores'.", "ForeignKeyNotFound", 1, "CPLISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtPrvCod_Internalname;
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

      public void Valid_Cplisprodcod( )
      {
         /* Using cursor T003G20 */
         pr_default.execute(18, new Object[] {A284CPLisProdCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista de Precios Proveedores'.", "ForeignKeyNotFound", 1, "CPLISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisProdCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cplisprvitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A244PrvCod", StringUtil.RTrim( A244PrvCod));
         AssignAttri("", false, "A829CPLisPrvMN", StringUtil.LTrim( StringUtil.NToC( A829CPLisPrvMN, 15, 4, ".", "")));
         AssignAttri("", false, "A828CPLisPrvME", StringUtil.LTrim( StringUtil.NToC( A828CPLisPrvME, 15, 4, ".", "")));
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A1763PrvDir", StringUtil.RTrim( A1763PrvDir));
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A300PrvConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1756PrvConpDsc", StringUtil.RTrim( A1756PrvConpDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z284CPLisProdCod", StringUtil.RTrim( Z284CPLisProdCod));
         GxWebStd.gx_hidden_field( context, "Z285CPLisPrvItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z285CPLisPrvItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z829CPLisPrvMN", StringUtil.LTrim( StringUtil.NToC( Z829CPLisPrvMN, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z828CPLisPrvME", StringUtil.LTrim( StringUtil.NToC( Z828CPLisPrvME, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1763PrvDir", StringUtil.RTrim( Z1763PrvDir));
         GxWebStd.gx_hidden_field( context, "Z300PrvConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z300PrvConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1756PrvConpDsc", StringUtil.RTrim( Z1756PrvConpDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prvcod( )
      {
         /* Using cursor T003G17 */
         pr_default.execute(15, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
         }
         A247PrvDsc = T003G17_A247PrvDsc[0];
         A1763PrvDir = T003G17_A1763PrvDir[0];
         A300PrvConpCod = T003G17_A300PrvConpCod[0];
         pr_default.close(15);
         /* Using cursor T003G18 */
         pr_default.execute(16, new Object[] {A300PrvConpCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Condicion pago'.", "ForeignKeyNotFound", 1, "PRVCONPCOD");
            AnyError = 1;
         }
         A1756PrvConpDsc = T003G18_A1756PrvConpDsc[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A1763PrvDir", StringUtil.RTrim( A1763PrvDir));
         AssignAttri("", false, "A300PrvConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A300PrvConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1756PrvConpDsc", StringUtil.RTrim( A1756PrvConpDsc));
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
         setEventMetadata("VALID_CPLISPRODCOD","{handler:'Valid_Cplisprodcod',iparms:[{av:'A284CPLisProdCod',fld:'CPLISPRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_CPLISPRODCOD",",oparms:[]}");
         setEventMetadata("VALID_CPLISPRVITEM","{handler:'Valid_Cplisprvitem',iparms:[{av:'A284CPLisProdCod',fld:'CPLISPRODCOD',pic:'@!'},{av:'A285CPLisPrvItem',fld:'CPLISPRVITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CPLISPRVITEM",",oparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A829CPLisPrvMN',fld:'CPLISPRVMN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A828CPLisPrvME',fld:'CPLISPRVME',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''},{av:'A300PrvConpCod',fld:'PRVCONPCOD',pic:'ZZZZZ9'},{av:'A1756PrvConpDsc',fld:'PRVCONPDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z284CPLisProdCod'},{av:'Z285CPLisPrvItem'},{av:'Z244PrvCod'},{av:'Z829CPLisPrvMN'},{av:'Z828CPLisPrvME'},{av:'Z247PrvDsc'},{av:'Z1763PrvDir'},{av:'Z300PrvConpCod'},{av:'Z1756PrvConpDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A300PrvConpCod',fld:'PRVCONPCOD',pic:'ZZZZZ9'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''},{av:'A1756PrvConpDsc',fld:'PRVCONPDSC',pic:''}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''},{av:'A300PrvConpCod',fld:'PRVCONPCOD',pic:'ZZZZZ9'},{av:'A1756PrvConpDsc',fld:'PRVCONPDSC',pic:''}]}");
         setEventMetadata("VALID_PRVCONPCOD","{handler:'Valid_Prvconpcod',iparms:[]");
         setEventMetadata("VALID_PRVCONPCOD",",oparms:[]}");
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
         Z284CPLisProdCod = "";
         Z244PrvCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A284CPLisProdCod = "";
         A244PrvCod = "";
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
         A247PrvDsc = "";
         lblTextblock5_Jsonclick = "";
         A1763PrvDir = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1756PrvConpDsc = "";
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
         Z247PrvDsc = "";
         Z1763PrvDir = "";
         Z1756PrvConpDsc = "";
         T003G7_A285CPLisPrvItem = new short[1] ;
         T003G7_A247PrvDsc = new string[] {""} ;
         T003G7_A1763PrvDir = new string[] {""} ;
         T003G7_A1756PrvConpDsc = new string[] {""} ;
         T003G7_A829CPLisPrvMN = new decimal[1] ;
         T003G7_A828CPLisPrvME = new decimal[1] ;
         T003G7_A284CPLisProdCod = new string[] {""} ;
         T003G7_A244PrvCod = new string[] {""} ;
         T003G7_A300PrvConpCod = new int[1] ;
         T003G4_A284CPLisProdCod = new string[] {""} ;
         T003G5_A247PrvDsc = new string[] {""} ;
         T003G5_A1763PrvDir = new string[] {""} ;
         T003G5_A300PrvConpCod = new int[1] ;
         T003G6_A1756PrvConpDsc = new string[] {""} ;
         T003G8_A284CPLisProdCod = new string[] {""} ;
         T003G9_A247PrvDsc = new string[] {""} ;
         T003G9_A1763PrvDir = new string[] {""} ;
         T003G9_A300PrvConpCod = new int[1] ;
         T003G10_A1756PrvConpDsc = new string[] {""} ;
         T003G11_A284CPLisProdCod = new string[] {""} ;
         T003G11_A285CPLisPrvItem = new short[1] ;
         T003G3_A285CPLisPrvItem = new short[1] ;
         T003G3_A829CPLisPrvMN = new decimal[1] ;
         T003G3_A828CPLisPrvME = new decimal[1] ;
         T003G3_A284CPLisProdCod = new string[] {""} ;
         T003G3_A244PrvCod = new string[] {""} ;
         sMode119 = "";
         T003G12_A284CPLisProdCod = new string[] {""} ;
         T003G12_A285CPLisPrvItem = new short[1] ;
         T003G13_A284CPLisProdCod = new string[] {""} ;
         T003G13_A285CPLisPrvItem = new short[1] ;
         T003G2_A285CPLisPrvItem = new short[1] ;
         T003G2_A829CPLisPrvMN = new decimal[1] ;
         T003G2_A828CPLisPrvME = new decimal[1] ;
         T003G2_A284CPLisProdCod = new string[] {""} ;
         T003G2_A244PrvCod = new string[] {""} ;
         T003G17_A247PrvDsc = new string[] {""} ;
         T003G17_A1763PrvDir = new string[] {""} ;
         T003G17_A300PrvConpCod = new int[1] ;
         T003G18_A1756PrvConpDsc = new string[] {""} ;
         T003G19_A284CPLisProdCod = new string[] {""} ;
         T003G19_A285CPLisPrvItem = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003G20_A284CPLisProdCod = new string[] {""} ;
         ZZ284CPLisProdCod = "";
         ZZ244PrvCod = "";
         ZZ247PrvDsc = "";
         ZZ1763PrvDir = "";
         ZZ1756PrvConpDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cplistapreciosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cplistapreciosdet__default(),
            new Object[][] {
                new Object[] {
               T003G2_A285CPLisPrvItem, T003G2_A829CPLisPrvMN, T003G2_A828CPLisPrvME, T003G2_A284CPLisProdCod, T003G2_A244PrvCod
               }
               , new Object[] {
               T003G3_A285CPLisPrvItem, T003G3_A829CPLisPrvMN, T003G3_A828CPLisPrvME, T003G3_A284CPLisProdCod, T003G3_A244PrvCod
               }
               , new Object[] {
               T003G4_A284CPLisProdCod
               }
               , new Object[] {
               T003G5_A247PrvDsc, T003G5_A1763PrvDir, T003G5_A300PrvConpCod
               }
               , new Object[] {
               T003G6_A1756PrvConpDsc
               }
               , new Object[] {
               T003G7_A285CPLisPrvItem, T003G7_A247PrvDsc, T003G7_A1763PrvDir, T003G7_A1756PrvConpDsc, T003G7_A829CPLisPrvMN, T003G7_A828CPLisPrvME, T003G7_A284CPLisProdCod, T003G7_A244PrvCod, T003G7_A300PrvConpCod
               }
               , new Object[] {
               T003G8_A284CPLisProdCod
               }
               , new Object[] {
               T003G9_A247PrvDsc, T003G9_A1763PrvDir, T003G9_A300PrvConpCod
               }
               , new Object[] {
               T003G10_A1756PrvConpDsc
               }
               , new Object[] {
               T003G11_A284CPLisProdCod, T003G11_A285CPLisPrvItem
               }
               , new Object[] {
               T003G12_A284CPLisProdCod, T003G12_A285CPLisPrvItem
               }
               , new Object[] {
               T003G13_A284CPLisProdCod, T003G13_A285CPLisPrvItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003G17_A247PrvDsc, T003G17_A1763PrvDir, T003G17_A300PrvConpCod
               }
               , new Object[] {
               T003G18_A1756PrvConpDsc
               }
               , new Object[] {
               T003G19_A284CPLisProdCod, T003G19_A285CPLisPrvItem
               }
               , new Object[] {
               T003G20_A284CPLisProdCod
               }
            }
         );
      }

      private short Z285CPLisPrvItem ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A285CPLisPrvItem ;
      private short GX_JID ;
      private short RcdFound119 ;
      private short nIsDirty_119 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ285CPLisPrvItem ;
      private int A300PrvConpCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCPLisProdCod_Enabled ;
      private int edtCPLisPrvItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPrvCod_Enabled ;
      private int edtPrvDsc_Enabled ;
      private int edtPrvDir_Enabled ;
      private int edtPrvConpCod_Enabled ;
      private int edtPrvConpDsc_Enabled ;
      private int edtCPLisPrvMN_Enabled ;
      private int edtCPLisPrvME_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z300PrvConpCod ;
      private int idxLst ;
      private int ZZ300PrvConpCod ;
      private decimal Z829CPLisPrvMN ;
      private decimal Z828CPLisPrvME ;
      private decimal A829CPLisPrvMN ;
      private decimal A828CPLisPrvME ;
      private decimal ZZ829CPLisPrvMN ;
      private decimal ZZ828CPLisPrvME ;
      private string sPrefix ;
      private string Z284CPLisProdCod ;
      private string Z244PrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A284CPLisProdCod ;
      private string A244PrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCPLisProdCod_Internalname ;
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
      private string edtCPLisProdCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCPLisPrvItem_Internalname ;
      private string edtCPLisPrvItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPrvCod_Internalname ;
      private string edtPrvCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPrvDsc_Internalname ;
      private string A247PrvDsc ;
      private string edtPrvDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPrvDir_Internalname ;
      private string A1763PrvDir ;
      private string edtPrvDir_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPrvConpCod_Internalname ;
      private string edtPrvConpCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPrvConpDsc_Internalname ;
      private string A1756PrvConpDsc ;
      private string edtPrvConpDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCPLisPrvMN_Internalname ;
      private string edtCPLisPrvMN_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCPLisPrvME_Internalname ;
      private string edtCPLisPrvME_Jsonclick ;
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
      private string Z247PrvDsc ;
      private string Z1763PrvDir ;
      private string Z1756PrvConpDsc ;
      private string sMode119 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ284CPLisProdCod ;
      private string ZZ244PrvCod ;
      private string ZZ247PrvDsc ;
      private string ZZ1763PrvDir ;
      private string ZZ1756PrvConpDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T003G7_A285CPLisPrvItem ;
      private string[] T003G7_A247PrvDsc ;
      private string[] T003G7_A1763PrvDir ;
      private string[] T003G7_A1756PrvConpDsc ;
      private decimal[] T003G7_A829CPLisPrvMN ;
      private decimal[] T003G7_A828CPLisPrvME ;
      private string[] T003G7_A284CPLisProdCod ;
      private string[] T003G7_A244PrvCod ;
      private int[] T003G7_A300PrvConpCod ;
      private string[] T003G4_A284CPLisProdCod ;
      private string[] T003G5_A247PrvDsc ;
      private string[] T003G5_A1763PrvDir ;
      private int[] T003G5_A300PrvConpCod ;
      private string[] T003G6_A1756PrvConpDsc ;
      private string[] T003G8_A284CPLisProdCod ;
      private string[] T003G9_A247PrvDsc ;
      private string[] T003G9_A1763PrvDir ;
      private int[] T003G9_A300PrvConpCod ;
      private string[] T003G10_A1756PrvConpDsc ;
      private string[] T003G11_A284CPLisProdCod ;
      private short[] T003G11_A285CPLisPrvItem ;
      private short[] T003G3_A285CPLisPrvItem ;
      private decimal[] T003G3_A829CPLisPrvMN ;
      private decimal[] T003G3_A828CPLisPrvME ;
      private string[] T003G3_A284CPLisProdCod ;
      private string[] T003G3_A244PrvCod ;
      private string[] T003G12_A284CPLisProdCod ;
      private short[] T003G12_A285CPLisPrvItem ;
      private string[] T003G13_A284CPLisProdCod ;
      private short[] T003G13_A285CPLisPrvItem ;
      private short[] T003G2_A285CPLisPrvItem ;
      private decimal[] T003G2_A829CPLisPrvMN ;
      private decimal[] T003G2_A828CPLisPrvME ;
      private string[] T003G2_A284CPLisProdCod ;
      private string[] T003G2_A244PrvCod ;
      private string[] T003G17_A247PrvDsc ;
      private string[] T003G17_A1763PrvDir ;
      private int[] T003G17_A300PrvConpCod ;
      private string[] T003G18_A1756PrvConpDsc ;
      private string[] T003G19_A284CPLisProdCod ;
      private short[] T003G19_A285CPLisPrvItem ;
      private string[] T003G20_A284CPLisProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cplistapreciosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cplistapreciosdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003G7;
        prmT003G7 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G4;
        prmT003G4 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003G5;
        prmT003G5 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003G6;
        prmT003G6 = new Object[] {
        new ParDef("@PrvConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003G8;
        prmT003G8 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003G9;
        prmT003G9 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003G10;
        prmT003G10 = new Object[] {
        new ParDef("@PrvConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003G11;
        prmT003G11 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G3;
        prmT003G3 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G12;
        prmT003G12 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G13;
        prmT003G13 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G2;
        prmT003G2 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G14;
        prmT003G14 = new Object[] {
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0) ,
        new ParDef("@CPLisPrvMN",GXType.Decimal,15,4) ,
        new ParDef("@CPLisPrvME",GXType.Decimal,15,4) ,
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003G15;
        prmT003G15 = new Object[] {
        new ParDef("@CPLisPrvMN",GXType.Decimal,15,4) ,
        new ParDef("@CPLisPrvME",GXType.Decimal,15,4) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G16;
        prmT003G16 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisPrvItem",GXType.Int16,4,0)
        };
        Object[] prmT003G19;
        prmT003G19 = new Object[] {
        };
        Object[] prmT003G20;
        prmT003G20 = new Object[] {
        new ParDef("@CPLisProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003G17;
        prmT003G17 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003G18;
        prmT003G18 = new Object[] {
        new ParDef("@PrvConpCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003G2", "SELECT [CPLisPrvItem], [CPLisPrvMN], [CPLisPrvME], [CPLisProdCod], [PrvCod] FROM [CPLISTAPRECIOSDET] WITH (UPDLOCK) WHERE [CPLisProdCod] = @CPLisProdCod AND [CPLisPrvItem] = @CPLisPrvItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G3", "SELECT [CPLisPrvItem], [CPLisPrvMN], [CPLisPrvME], [CPLisProdCod], [PrvCod] FROM [CPLISTAPRECIOSDET] WHERE [CPLisProdCod] = @CPLisProdCod AND [CPLisPrvItem] = @CPLisPrvItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G4", "SELECT [CPLisProdCod] FROM [CPLISTAPRECIOS] WHERE [CPLisProdCod] = @CPLisProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G5", "SELECT [PrvDsc], [PrvDir], [PrvConpCod] AS PrvConpCod FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G6", "SELECT [ConpDsc] AS PrvConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PrvConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G7", "SELECT TM1.[CPLisPrvItem], T2.[PrvDsc], T2.[PrvDir], T3.[ConpDsc] AS PrvConpDsc, TM1.[CPLisPrvMN], TM1.[CPLisPrvME], TM1.[CPLisProdCod], TM1.[PrvCod], T2.[PrvConpCod] AS PrvConpCod FROM (([CPLISTAPRECIOSDET] TM1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = TM1.[PrvCod]) INNER JOIN [CCONDICIONPAGO] T3 ON T3.[Conpcod] = T2.[PrvConpCod]) WHERE TM1.[CPLisProdCod] = @CPLisProdCod and TM1.[CPLisPrvItem] = @CPLisPrvItem ORDER BY TM1.[CPLisProdCod], TM1.[CPLisPrvItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003G7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G8", "SELECT [CPLisProdCod] FROM [CPLISTAPRECIOS] WHERE [CPLisProdCod] = @CPLisProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G9", "SELECT [PrvDsc], [PrvDir], [PrvConpCod] AS PrvConpCod FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G10", "SELECT [ConpDsc] AS PrvConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PrvConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G11", "SELECT [CPLisProdCod], [CPLisPrvItem] FROM [CPLISTAPRECIOSDET] WHERE [CPLisProdCod] = @CPLisProdCod AND [CPLisPrvItem] = @CPLisPrvItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G12", "SELECT TOP 1 [CPLisProdCod], [CPLisPrvItem] FROM [CPLISTAPRECIOSDET] WHERE ( [CPLisProdCod] > @CPLisProdCod or [CPLisProdCod] = @CPLisProdCod and [CPLisPrvItem] > @CPLisPrvItem) ORDER BY [CPLisProdCod], [CPLisPrvItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003G13", "SELECT TOP 1 [CPLisProdCod], [CPLisPrvItem] FROM [CPLISTAPRECIOSDET] WHERE ( [CPLisProdCod] < @CPLisProdCod or [CPLisProdCod] = @CPLisProdCod and [CPLisPrvItem] < @CPLisPrvItem) ORDER BY [CPLisProdCod] DESC, [CPLisPrvItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003G13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003G14", "INSERT INTO [CPLISTAPRECIOSDET]([CPLisPrvItem], [CPLisPrvMN], [CPLisPrvME], [CPLisProdCod], [PrvCod]) VALUES(@CPLisPrvItem, @CPLisPrvMN, @CPLisPrvME, @CPLisProdCod, @PrvCod)", GxErrorMask.GX_NOMASK,prmT003G14)
           ,new CursorDef("T003G15", "UPDATE [CPLISTAPRECIOSDET] SET [CPLisPrvMN]=@CPLisPrvMN, [CPLisPrvME]=@CPLisPrvME, [PrvCod]=@PrvCod  WHERE [CPLisProdCod] = @CPLisProdCod AND [CPLisPrvItem] = @CPLisPrvItem", GxErrorMask.GX_NOMASK,prmT003G15)
           ,new CursorDef("T003G16", "DELETE FROM [CPLISTAPRECIOSDET]  WHERE [CPLisProdCod] = @CPLisProdCod AND [CPLisPrvItem] = @CPLisPrvItem", GxErrorMask.GX_NOMASK,prmT003G16)
           ,new CursorDef("T003G17", "SELECT [PrvDsc], [PrvDir], [PrvConpCod] AS PrvConpCod FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G18", "SELECT [ConpDsc] AS PrvConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PrvConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G19", "SELECT [CPLisProdCod], [CPLisPrvItem] FROM [CPLISTAPRECIOSDET] ORDER BY [CPLisProdCod], [CPLisPrvItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003G19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003G20", "SELECT [CPLisProdCod] FROM [CPLISTAPRECIOS] WHERE [CPLisProdCod] = @CPLisProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003G20,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
