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
   public class poordenes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A323ProProdCod = GetPar( "ProProdCod");
            AssignAttri("", false, "A323ProProdCod", A323ProProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A323ProProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A324ProPlanCod = GetPar( "ProPlanCod");
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A324ProPlanCod) ;
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
            Form.Meta.addItem("description", "Cabecera Ordenes de Producción", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poordenes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poordenes( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POORDENES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCod_Internalname, StringUtil.RTrim( A322ProCod), StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha Orden", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProFec_Internalname, context.localUtil.Format(A325ProFec, "99/99/99"), context.localUtil.Format( A325ProFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POORDENES.htm");
         GxWebStd.gx_bitmap( context, edtProFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_POORDENES.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Referencia", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProRef_Internalname, StringUtil.RTrim( A1739ProRef), StringUtil.RTrim( context.localUtil.Format( A1739ProRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProRef_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProSts_Internalname, StringUtil.RTrim( A1740ProSts), StringUtil.RTrim( context.localUtil.Format( A1740ProSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Observación", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProObs_Internalname, A1730ProObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", 0, 1, edtProObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Producto a Producir", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProProdCod_Internalname, StringUtil.RTrim( A323ProProdCod), StringUtil.RTrim( context.localUtil.Format( A323ProProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Producto", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProProdDsc_Internalname, StringUtil.RTrim( A1738ProProdDsc), StringUtil.RTrim( context.localUtil.Format( A1738ProProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cantidad a Producir", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCantProd_Internalname, StringUtil.LTrim( StringUtil.NToC( A1654ProCantProd, 17, 4, ".", "")), StringUtil.LTrim( ((edtProCantProd_Enabled!=0) ? context.localUtil.Format( A1654ProCantProd, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1654ProCantProd, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCantProd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCantProd_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cantidad Ingresada", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCantProdIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1655ProCantProdIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtProCantProdIng_Enabled!=0) ? context.localUtil.Format( A1655ProCantProdIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1655ProCantProdIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCantProdIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCantProdIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "N° Plan", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POORDENES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProPlanCod_Internalname, StringUtil.RTrim( A324ProPlanCod), StringUtil.RTrim( context.localUtil.Format( A324ProPlanCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProPlanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProPlanCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POORDENES.htm");
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
            Z322ProCod = cgiGet( "Z322ProCod");
            Z325ProFec = context.localUtil.CToD( cgiGet( "Z325ProFec"), 0);
            Z1739ProRef = cgiGet( "Z1739ProRef");
            Z1740ProSts = cgiGet( "Z1740ProSts");
            Z1654ProCantProd = context.localUtil.CToN( cgiGet( "Z1654ProCantProd"), ".", ",");
            Z1655ProCantProdIng = context.localUtil.CToN( cgiGet( "Z1655ProCantProdIng"), ".", ",");
            Z324ProPlanCod = cgiGet( "Z324ProPlanCod");
            Z323ProProdCod = cgiGet( "Z323ProProdCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1653ProCantFalta = context.localUtil.CToN( cgiGet( "PROCANTFALTA"), ".", ",");
            /* Read variables values. */
            A322ProCod = cgiGet( edtProCod_Internalname);
            AssignAttri("", false, "A322ProCod", A322ProCod);
            if ( context.localUtil.VCDate( cgiGet( edtProFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Orden"}), 1, "PROFEC");
               AnyError = 1;
               GX_FocusControl = edtProFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A325ProFec = DateTime.MinValue;
               AssignAttri("", false, "A325ProFec", context.localUtil.Format(A325ProFec, "99/99/99"));
            }
            else
            {
               A325ProFec = context.localUtil.CToD( cgiGet( edtProFec_Internalname), 2);
               AssignAttri("", false, "A325ProFec", context.localUtil.Format(A325ProFec, "99/99/99"));
            }
            A1739ProRef = cgiGet( edtProRef_Internalname);
            AssignAttri("", false, "A1739ProRef", A1739ProRef);
            A1740ProSts = cgiGet( edtProSts_Internalname);
            AssignAttri("", false, "A1740ProSts", A1740ProSts);
            A1730ProObs = cgiGet( edtProObs_Internalname);
            AssignAttri("", false, "A1730ProObs", A1730ProObs);
            A323ProProdCod = StringUtil.Upper( cgiGet( edtProProdCod_Internalname));
            AssignAttri("", false, "A323ProProdCod", A323ProProdCod);
            A1738ProProdDsc = cgiGet( edtProProdDsc_Internalname);
            AssignAttri("", false, "A1738ProProdDsc", A1738ProProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCantProd_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCantProd_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCANTPROD");
               AnyError = 1;
               GX_FocusControl = edtProCantProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1654ProCantProd = 0;
               AssignAttri("", false, "A1654ProCantProd", StringUtil.LTrimStr( A1654ProCantProd, 15, 4));
            }
            else
            {
               A1654ProCantProd = context.localUtil.CToN( cgiGet( edtProCantProd_Internalname), ".", ",");
               AssignAttri("", false, "A1654ProCantProd", StringUtil.LTrimStr( A1654ProCantProd, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCantProdIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCantProdIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCANTPRODING");
               AnyError = 1;
               GX_FocusControl = edtProCantProdIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1655ProCantProdIng = 0;
               AssignAttri("", false, "A1655ProCantProdIng", StringUtil.LTrimStr( A1655ProCantProdIng, 15, 4));
            }
            else
            {
               A1655ProCantProdIng = context.localUtil.CToN( cgiGet( edtProCantProdIng_Internalname), ".", ",");
               AssignAttri("", false, "A1655ProCantProdIng", StringUtil.LTrimStr( A1655ProCantProdIng, 15, 4));
            }
            A324ProPlanCod = cgiGet( edtProPlanCod_Internalname);
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
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
               A322ProCod = GetPar( "ProCod");
               AssignAttri("", false, "A322ProCod", A322ProCod);
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
               InitAll48147( ) ;
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
         DisableAttributes48147( ) ;
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

      protected void CONFIRM_480( )
      {
         BeforeValidate48147( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls48147( ) ;
            }
            else
            {
               CheckExtendedTable48147( ) ;
               if ( AnyError == 0 )
               {
                  ZM48147( 4) ;
                  ZM48147( 5) ;
               }
               CloseExtendedTableCursors48147( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues480( ) ;
         }
      }

      protected void ResetCaption480( )
      {
      }

      protected void ZM48147( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z325ProFec = T00483_A325ProFec[0];
               Z1739ProRef = T00483_A1739ProRef[0];
               Z1740ProSts = T00483_A1740ProSts[0];
               Z1654ProCantProd = T00483_A1654ProCantProd[0];
               Z1655ProCantProdIng = T00483_A1655ProCantProdIng[0];
               Z324ProPlanCod = T00483_A324ProPlanCod[0];
               Z323ProProdCod = T00483_A323ProProdCod[0];
            }
            else
            {
               Z325ProFec = A325ProFec;
               Z1739ProRef = A1739ProRef;
               Z1740ProSts = A1740ProSts;
               Z1654ProCantProd = A1654ProCantProd;
               Z1655ProCantProdIng = A1655ProCantProdIng;
               Z324ProPlanCod = A324ProPlanCod;
               Z323ProProdCod = A323ProProdCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z322ProCod = A322ProCod;
            Z325ProFec = A325ProFec;
            Z1739ProRef = A1739ProRef;
            Z1740ProSts = A1740ProSts;
            Z1730ProObs = A1730ProObs;
            Z1654ProCantProd = A1654ProCantProd;
            Z1655ProCantProdIng = A1655ProCantProdIng;
            Z324ProPlanCod = A324ProPlanCod;
            Z323ProProdCod = A323ProProdCod;
            Z1738ProProdDsc = A1738ProProdDsc;
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

      protected void Load48147( )
      {
         /* Using cursor T00486 */
         pr_default.execute(4, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound147 = 1;
            A325ProFec = T00486_A325ProFec[0];
            AssignAttri("", false, "A325ProFec", context.localUtil.Format(A325ProFec, "99/99/99"));
            A1739ProRef = T00486_A1739ProRef[0];
            AssignAttri("", false, "A1739ProRef", A1739ProRef);
            A1740ProSts = T00486_A1740ProSts[0];
            AssignAttri("", false, "A1740ProSts", A1740ProSts);
            A1730ProObs = T00486_A1730ProObs[0];
            AssignAttri("", false, "A1730ProObs", A1730ProObs);
            A1738ProProdDsc = T00486_A1738ProProdDsc[0];
            AssignAttri("", false, "A1738ProProdDsc", A1738ProProdDsc);
            A1654ProCantProd = T00486_A1654ProCantProd[0];
            AssignAttri("", false, "A1654ProCantProd", StringUtil.LTrimStr( A1654ProCantProd, 15, 4));
            A1655ProCantProdIng = T00486_A1655ProCantProdIng[0];
            AssignAttri("", false, "A1655ProCantProdIng", StringUtil.LTrimStr( A1655ProCantProdIng, 15, 4));
            A324ProPlanCod = T00486_A324ProPlanCod[0];
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
            A323ProProdCod = T00486_A323ProProdCod[0];
            AssignAttri("", false, "A323ProProdCod", A323ProProdCod);
            ZM48147( -3) ;
         }
         pr_default.close(4);
         OnLoadActions48147( ) ;
      }

      protected void OnLoadActions48147( )
      {
         A1653ProCantFalta = (decimal)(A1654ProCantProd-A1655ProCantProdIng);
         AssignAttri("", false, "A1653ProCantFalta", StringUtil.LTrimStr( A1653ProCantFalta, 15, 4));
      }

      protected void CheckExtendedTable48147( )
      {
         nIsDirty_147 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A325ProFec) || ( DateTimeUtil.ResetTime ( A325ProFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Orden fuera de rango", "OutOfRange", 1, "PROFEC");
            AnyError = 1;
            GX_FocusControl = edtProFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00485 */
         pr_default.execute(3, new Object[] {A323ProProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PROPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1738ProProdDsc = T00485_A1738ProProdDsc[0];
         AssignAttri("", false, "A1738ProProdDsc", A1738ProProdDsc);
         pr_default.close(3);
         nIsDirty_147 = 1;
         A1653ProCantFalta = (decimal)(A1654ProCantProd-A1655ProCantProdIng);
         AssignAttri("", false, "A1653ProCantFalta", StringUtil.LTrimStr( A1653ProCantFalta, 15, 4));
         /* Using cursor T00484 */
         pr_default.execute(2, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabacera Plan de Producción'.", "ForeignKeyNotFound", 1, "PROPLANCOD");
            AnyError = 1;
            GX_FocusControl = edtProPlanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors48147( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A323ProProdCod )
      {
         /* Using cursor T00487 */
         pr_default.execute(5, new Object[] {A323ProProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PROPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1738ProProdDsc = T00487_A1738ProProdDsc[0];
         AssignAttri("", false, "A1738ProProdDsc", A1738ProProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1738ProProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( string A324ProPlanCod )
      {
         /* Using cursor T00488 */
         pr_default.execute(6, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabacera Plan de Producción'.", "ForeignKeyNotFound", 1, "PROPLANCOD");
            AnyError = 1;
            GX_FocusControl = edtProPlanCod_Internalname;
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

      protected void GetKey48147( )
      {
         /* Using cursor T00489 */
         pr_default.execute(7, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound147 = 1;
         }
         else
         {
            RcdFound147 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00483 */
         pr_default.execute(1, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM48147( 3) ;
            RcdFound147 = 1;
            A322ProCod = T00483_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A325ProFec = T00483_A325ProFec[0];
            AssignAttri("", false, "A325ProFec", context.localUtil.Format(A325ProFec, "99/99/99"));
            A1739ProRef = T00483_A1739ProRef[0];
            AssignAttri("", false, "A1739ProRef", A1739ProRef);
            A1740ProSts = T00483_A1740ProSts[0];
            AssignAttri("", false, "A1740ProSts", A1740ProSts);
            A1730ProObs = T00483_A1730ProObs[0];
            AssignAttri("", false, "A1730ProObs", A1730ProObs);
            A1654ProCantProd = T00483_A1654ProCantProd[0];
            AssignAttri("", false, "A1654ProCantProd", StringUtil.LTrimStr( A1654ProCantProd, 15, 4));
            A1655ProCantProdIng = T00483_A1655ProCantProdIng[0];
            AssignAttri("", false, "A1655ProCantProdIng", StringUtil.LTrimStr( A1655ProCantProdIng, 15, 4));
            A324ProPlanCod = T00483_A324ProPlanCod[0];
            AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
            A323ProProdCod = T00483_A323ProProdCod[0];
            AssignAttri("", false, "A323ProProdCod", A323ProProdCod);
            Z322ProCod = A322ProCod;
            sMode147 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load48147( ) ;
            if ( AnyError == 1 )
            {
               RcdFound147 = 0;
               InitializeNonKey48147( ) ;
            }
            Gx_mode = sMode147;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound147 = 0;
            InitializeNonKey48147( ) ;
            sMode147 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode147;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey48147( ) ;
         if ( RcdFound147 == 0 )
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
         RcdFound147 = 0;
         /* Using cursor T004810 */
         pr_default.execute(8, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004810_A322ProCod[0], A322ProCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004810_A322ProCod[0], A322ProCod) > 0 ) ) )
            {
               A322ProCod = T004810_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               RcdFound147 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound147 = 0;
         /* Using cursor T004811 */
         pr_default.execute(9, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004811_A322ProCod[0], A322ProCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004811_A322ProCod[0], A322ProCod) < 0 ) ) )
            {
               A322ProCod = T004811_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               RcdFound147 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey48147( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert48147( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound147 == 1 )
            {
               if ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 )
               {
                  A322ProCod = Z322ProCod;
                  AssignAttri("", false, "A322ProCod", A322ProCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update48147( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert48147( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert48147( ) ;
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
         if ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 )
         {
            A322ProCod = Z322ProCod;
            AssignAttri("", false, "A322ProCod", A322ProCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCod_Internalname;
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
         GetKey48147( ) ;
         if ( RcdFound147 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PROCOD");
               AnyError = 1;
               GX_FocusControl = edtProCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 )
            {
               A322ProCod = Z322ProCod;
               AssignAttri("", false, "A322ProCod", A322ProCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PROCOD");
               AnyError = 1;
               GX_FocusControl = edtProCod_Internalname;
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
            if ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCod_Internalname;
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
         context.RollbackDataStores("poordenes",pr_default);
         GX_FocusControl = edtProFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_480( ) ;
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
         if ( RcdFound147 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart48147( ) ;
         if ( RcdFound147 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd48147( ) ;
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
         if ( RcdFound147 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProFec_Internalname;
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
         if ( RcdFound147 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProFec_Internalname;
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
         ScanStart48147( ) ;
         if ( RcdFound147 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound147 != 0 )
            {
               ScanNext48147( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd48147( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency48147( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00482 */
            pr_default.execute(0, new Object[] {A322ProCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z325ProFec ) != DateTimeUtil.ResetTime ( T00482_A325ProFec[0] ) ) || ( StringUtil.StrCmp(Z1739ProRef, T00482_A1739ProRef[0]) != 0 ) || ( StringUtil.StrCmp(Z1740ProSts, T00482_A1740ProSts[0]) != 0 ) || ( Z1654ProCantProd != T00482_A1654ProCantProd[0] ) || ( Z1655ProCantProdIng != T00482_A1655ProCantProdIng[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z324ProPlanCod, T00482_A324ProPlanCod[0]) != 0 ) || ( StringUtil.StrCmp(Z323ProProdCod, T00482_A323ProProdCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z325ProFec ) != DateTimeUtil.ResetTime ( T00482_A325ProFec[0] ) )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProFec");
                  GXUtil.WriteLogRaw("Old: ",Z325ProFec);
                  GXUtil.WriteLogRaw("Current: ",T00482_A325ProFec[0]);
               }
               if ( StringUtil.StrCmp(Z1739ProRef, T00482_A1739ProRef[0]) != 0 )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProRef");
                  GXUtil.WriteLogRaw("Old: ",Z1739ProRef);
                  GXUtil.WriteLogRaw("Current: ",T00482_A1739ProRef[0]);
               }
               if ( StringUtil.StrCmp(Z1740ProSts, T00482_A1740ProSts[0]) != 0 )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProSts");
                  GXUtil.WriteLogRaw("Old: ",Z1740ProSts);
                  GXUtil.WriteLogRaw("Current: ",T00482_A1740ProSts[0]);
               }
               if ( Z1654ProCantProd != T00482_A1654ProCantProd[0] )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProCantProd");
                  GXUtil.WriteLogRaw("Old: ",Z1654ProCantProd);
                  GXUtil.WriteLogRaw("Current: ",T00482_A1654ProCantProd[0]);
               }
               if ( Z1655ProCantProdIng != T00482_A1655ProCantProdIng[0] )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProCantProdIng");
                  GXUtil.WriteLogRaw("Old: ",Z1655ProCantProdIng);
                  GXUtil.WriteLogRaw("Current: ",T00482_A1655ProCantProdIng[0]);
               }
               if ( StringUtil.StrCmp(Z324ProPlanCod, T00482_A324ProPlanCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProPlanCod");
                  GXUtil.WriteLogRaw("Old: ",Z324ProPlanCod);
                  GXUtil.WriteLogRaw("Current: ",T00482_A324ProPlanCod[0]);
               }
               if ( StringUtil.StrCmp(Z323ProProdCod, T00482_A323ProProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poordenes:[seudo value changed for attri]"+"ProProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z323ProProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00482_A323ProProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POORDENES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert48147( )
      {
         BeforeValidate48147( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable48147( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM48147( 0) ;
            CheckOptimisticConcurrency48147( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm48147( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert48147( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004812 */
                     pr_default.execute(10, new Object[] {A322ProCod, A325ProFec, A1739ProRef, A1740ProSts, A1730ProObs, A1654ProCantProd, A1655ProCantProdIng, A324ProPlanCod, A323ProProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENES");
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
                           ResetCaption480( ) ;
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
               Load48147( ) ;
            }
            EndLevel48147( ) ;
         }
         CloseExtendedTableCursors48147( ) ;
      }

      protected void Update48147( )
      {
         BeforeValidate48147( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable48147( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency48147( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm48147( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate48147( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004813 */
                     pr_default.execute(11, new Object[] {A325ProFec, A1739ProRef, A1740ProSts, A1730ProObs, A1654ProCantProd, A1655ProCantProdIng, A324ProPlanCod, A323ProProdCod, A322ProCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENES");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate48147( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption480( ) ;
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
            EndLevel48147( ) ;
         }
         CloseExtendedTableCursors48147( ) ;
      }

      protected void DeferredUpdate48147( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate48147( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency48147( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls48147( ) ;
            AfterConfirm48147( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete48147( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004814 */
                  pr_default.execute(12, new Object[] {A322ProCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("POORDENES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound147 == 0 )
                        {
                           InitAll48147( ) ;
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
                        ResetCaption480( ) ;
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
         sMode147 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel48147( ) ;
         Gx_mode = sMode147;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls48147( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004815 */
            pr_default.execute(13, new Object[] {A323ProProdCod});
            A1738ProProdDsc = T004815_A1738ProProdDsc[0];
            AssignAttri("", false, "A1738ProProdDsc", A1738ProProdDsc);
            pr_default.close(13);
            A1653ProCantFalta = (decimal)(A1654ProCantProd-A1655ProCantProdIng);
            AssignAttri("", false, "A1653ProCantFalta", StringUtil.LTrimStr( A1653ProCantFalta, 15, 4));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T004816 */
            pr_default.execute(14, new Object[] {A322ProCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Producción Operarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T004817 */
            pr_default.execute(15, new Object[] {A322ProCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Producción Maquinas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T004818 */
            pr_default.execute(16, new Object[] {A322ProCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Produccion Gastos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T004819 */
            pr_default.execute(17, new Object[] {A322ProCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel48147( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete48147( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("poordenes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues480( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("poordenes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart48147( )
      {
         /* Using cursor T004820 */
         pr_default.execute(18);
         RcdFound147 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound147 = 1;
            A322ProCod = T004820_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext48147( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound147 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound147 = 1;
            A322ProCod = T004820_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
         }
      }

      protected void ScanEnd48147( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm48147( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert48147( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate48147( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete48147( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete48147( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate48147( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes48147( )
      {
         edtProCod_Enabled = 0;
         AssignProp("", false, edtProCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCod_Enabled), 5, 0), true);
         edtProFec_Enabled = 0;
         AssignProp("", false, edtProFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProFec_Enabled), 5, 0), true);
         edtProRef_Enabled = 0;
         AssignProp("", false, edtProRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProRef_Enabled), 5, 0), true);
         edtProSts_Enabled = 0;
         AssignProp("", false, edtProSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProSts_Enabled), 5, 0), true);
         edtProObs_Enabled = 0;
         AssignProp("", false, edtProObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProObs_Enabled), 5, 0), true);
         edtProProdCod_Enabled = 0;
         AssignProp("", false, edtProProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProProdCod_Enabled), 5, 0), true);
         edtProProdDsc_Enabled = 0;
         AssignProp("", false, edtProProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProProdDsc_Enabled), 5, 0), true);
         edtProCantProd_Enabled = 0;
         AssignProp("", false, edtProCantProd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCantProd_Enabled), 5, 0), true);
         edtProCantProdIng_Enabled = 0;
         AssignProp("", false, edtProCantProdIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCantProdIng_Enabled), 5, 0), true);
         edtProPlanCod_Enabled = 0;
         AssignProp("", false, edtProPlanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProPlanCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes48147( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues480( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253663", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poordenes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z325ProFec", context.localUtil.DToC( Z325ProFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1739ProRef", StringUtil.RTrim( Z1739ProRef));
         GxWebStd.gx_hidden_field( context, "Z1740ProSts", StringUtil.RTrim( Z1740ProSts));
         GxWebStd.gx_hidden_field( context, "Z1654ProCantProd", StringUtil.LTrim( StringUtil.NToC( Z1654ProCantProd, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1655ProCantProdIng", StringUtil.LTrim( StringUtil.NToC( Z1655ProCantProdIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z324ProPlanCod", StringUtil.RTrim( Z324ProPlanCod));
         GxWebStd.gx_hidden_field( context, "Z323ProProdCod", StringUtil.RTrim( Z323ProProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROCANTFALTA", StringUtil.LTrim( StringUtil.NToC( A1653ProCantFalta, 15, 4, ".", "")));
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
         return formatLink("poordenes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POORDENES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cabecera Ordenes de Producción" ;
      }

      protected void InitializeNonKey48147( )
      {
         A1653ProCantFalta = 0;
         AssignAttri("", false, "A1653ProCantFalta", StringUtil.LTrimStr( A1653ProCantFalta, 15, 4));
         A325ProFec = DateTime.MinValue;
         AssignAttri("", false, "A325ProFec", context.localUtil.Format(A325ProFec, "99/99/99"));
         A1739ProRef = "";
         AssignAttri("", false, "A1739ProRef", A1739ProRef);
         A1740ProSts = "";
         AssignAttri("", false, "A1740ProSts", A1740ProSts);
         A1730ProObs = "";
         AssignAttri("", false, "A1730ProObs", A1730ProObs);
         A323ProProdCod = "";
         AssignAttri("", false, "A323ProProdCod", A323ProProdCod);
         A1738ProProdDsc = "";
         AssignAttri("", false, "A1738ProProdDsc", A1738ProProdDsc);
         A1654ProCantProd = 0;
         AssignAttri("", false, "A1654ProCantProd", StringUtil.LTrimStr( A1654ProCantProd, 15, 4));
         A1655ProCantProdIng = 0;
         AssignAttri("", false, "A1655ProCantProdIng", StringUtil.LTrimStr( A1655ProCantProdIng, 15, 4));
         A324ProPlanCod = "";
         AssignAttri("", false, "A324ProPlanCod", A324ProPlanCod);
         Z325ProFec = DateTime.MinValue;
         Z1739ProRef = "";
         Z1740ProSts = "";
         Z1654ProCantProd = 0;
         Z1655ProCantProdIng = 0;
         Z324ProPlanCod = "";
         Z323ProProdCod = "";
      }

      protected void InitAll48147( )
      {
         A322ProCod = "";
         AssignAttri("", false, "A322ProCod", A322ProCod);
         InitializeNonKey48147( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253673", true, true);
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
         context.AddJavascriptSource("poordenes.js", "?202281810253674", false, true);
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
         edtProCod_Internalname = "PROCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProFec_Internalname = "PROFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProRef_Internalname = "PROREF";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProSts_Internalname = "PROSTS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProObs_Internalname = "PROOBS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtProProdCod_Internalname = "PROPRODCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtProProdDsc_Internalname = "PROPRODDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtProCantProd_Internalname = "PROCANTPROD";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtProCantProdIng_Internalname = "PROCANTPRODING";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtProPlanCod_Internalname = "PROPLANCOD";
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
         Form.Caption = "Cabecera Ordenes de Producción";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProPlanCod_Jsonclick = "";
         edtProPlanCod_Enabled = 1;
         edtProCantProdIng_Jsonclick = "";
         edtProCantProdIng_Enabled = 1;
         edtProCantProd_Jsonclick = "";
         edtProCantProd_Enabled = 1;
         edtProProdDsc_Jsonclick = "";
         edtProProdDsc_Enabled = 0;
         edtProProdCod_Jsonclick = "";
         edtProProdCod_Enabled = 1;
         edtProObs_Enabled = 1;
         edtProSts_Jsonclick = "";
         edtProSts_Enabled = 1;
         edtProRef_Jsonclick = "";
         edtProRef_Enabled = 1;
         edtProFec_Jsonclick = "";
         edtProFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProCod_Jsonclick = "";
         edtProCod_Enabled = 1;
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
         GX_FocusControl = edtProFec_Internalname;
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

      public void Valid_Procod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A325ProFec", context.localUtil.Format(A325ProFec, "99/99/99"));
         AssignAttri("", false, "A1739ProRef", StringUtil.RTrim( A1739ProRef));
         AssignAttri("", false, "A1740ProSts", StringUtil.RTrim( A1740ProSts));
         AssignAttri("", false, "A1730ProObs", A1730ProObs);
         AssignAttri("", false, "A323ProProdCod", StringUtil.RTrim( A323ProProdCod));
         AssignAttri("", false, "A1654ProCantProd", StringUtil.LTrim( StringUtil.NToC( A1654ProCantProd, 15, 4, ".", "")));
         AssignAttri("", false, "A1655ProCantProdIng", StringUtil.LTrim( StringUtil.NToC( A1655ProCantProdIng, 15, 4, ".", "")));
         AssignAttri("", false, "A324ProPlanCod", StringUtil.RTrim( A324ProPlanCod));
         AssignAttri("", false, "A1738ProProdDsc", StringUtil.RTrim( A1738ProProdDsc));
         AssignAttri("", false, "A1653ProCantFalta", StringUtil.LTrim( StringUtil.NToC( A1653ProCantFalta, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z325ProFec", context.localUtil.Format(Z325ProFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1739ProRef", StringUtil.RTrim( Z1739ProRef));
         GxWebStd.gx_hidden_field( context, "Z1740ProSts", StringUtil.RTrim( Z1740ProSts));
         GxWebStd.gx_hidden_field( context, "Z1730ProObs", Z1730ProObs);
         GxWebStd.gx_hidden_field( context, "Z323ProProdCod", StringUtil.RTrim( Z323ProProdCod));
         GxWebStd.gx_hidden_field( context, "Z1654ProCantProd", StringUtil.LTrim( StringUtil.NToC( Z1654ProCantProd, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1655ProCantProdIng", StringUtil.LTrim( StringUtil.NToC( Z1655ProCantProdIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z324ProPlanCod", StringUtil.RTrim( Z324ProPlanCod));
         GxWebStd.gx_hidden_field( context, "Z1738ProProdDsc", StringUtil.RTrim( Z1738ProProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1653ProCantFalta", StringUtil.LTrim( StringUtil.NToC( Z1653ProCantFalta, 15, 4, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Proprodcod( )
      {
         /* Using cursor T004815 */
         pr_default.execute(13, new Object[] {A323ProProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PROPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProProdCod_Internalname;
         }
         A1738ProProdDsc = T004815_A1738ProProdDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1738ProProdDsc", StringUtil.RTrim( A1738ProProdDsc));
      }

      public void Valid_Proplancod( )
      {
         /* Using cursor T004821 */
         pr_default.execute(19, new Object[] {A324ProPlanCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabacera Plan de Producción'.", "ForeignKeyNotFound", 1, "PROPLANCOD");
            AnyError = 1;
            GX_FocusControl = edtProPlanCod_Internalname;
         }
         pr_default.close(19);
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
         setEventMetadata("VALID_PROCOD","{handler:'Valid_Procod',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROCOD",",oparms:[{av:'A325ProFec',fld:'PROFEC',pic:''},{av:'A1739ProRef',fld:'PROREF',pic:''},{av:'A1740ProSts',fld:'PROSTS',pic:''},{av:'A1730ProObs',fld:'PROOBS',pic:''},{av:'A323ProProdCod',fld:'PROPRODCOD',pic:'@!'},{av:'A1654ProCantProd',fld:'PROCANTPROD',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1655ProCantProdIng',fld:'PROCANTPRODING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A324ProPlanCod',fld:'PROPLANCOD',pic:''},{av:'A1738ProProdDsc',fld:'PROPRODDSC',pic:''},{av:'A1653ProCantFalta',fld:'PROCANTFALTA',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z322ProCod'},{av:'Z325ProFec'},{av:'Z1739ProRef'},{av:'Z1740ProSts'},{av:'Z1730ProObs'},{av:'Z323ProProdCod'},{av:'Z1654ProCantProd'},{av:'Z1655ProCantProdIng'},{av:'Z324ProPlanCod'},{av:'Z1738ProProdDsc'},{av:'Z1653ProCantFalta'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROFEC","{handler:'Valid_Profec',iparms:[]");
         setEventMetadata("VALID_PROFEC",",oparms:[]}");
         setEventMetadata("VALID_PROPRODCOD","{handler:'Valid_Proprodcod',iparms:[{av:'A323ProProdCod',fld:'PROPRODCOD',pic:'@!'},{av:'A1738ProProdDsc',fld:'PROPRODDSC',pic:''}]");
         setEventMetadata("VALID_PROPRODCOD",",oparms:[{av:'A1738ProProdDsc',fld:'PROPRODDSC',pic:''}]}");
         setEventMetadata("VALID_PROCANTPROD","{handler:'Valid_Procantprod',iparms:[]");
         setEventMetadata("VALID_PROCANTPROD",",oparms:[]}");
         setEventMetadata("VALID_PROCANTPRODING","{handler:'Valid_Procantproding',iparms:[]");
         setEventMetadata("VALID_PROCANTPRODING",",oparms:[]}");
         setEventMetadata("VALID_PROPLANCOD","{handler:'Valid_Proplancod',iparms:[{av:'A324ProPlanCod',fld:'PROPLANCOD',pic:''}]");
         setEventMetadata("VALID_PROPLANCOD",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z322ProCod = "";
         Z325ProFec = DateTime.MinValue;
         Z1739ProRef = "";
         Z1740ProSts = "";
         Z324ProPlanCod = "";
         Z323ProProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A323ProProdCod = "";
         A324ProPlanCod = "";
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
         A322ProCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A325ProFec = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         A1739ProRef = "";
         lblTextblock4_Jsonclick = "";
         A1740ProSts = "";
         lblTextblock5_Jsonclick = "";
         A1730ProObs = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1738ProProdDsc = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
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
         Z1730ProObs = "";
         Z1738ProProdDsc = "";
         T00486_A322ProCod = new string[] {""} ;
         T00486_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         T00486_A1739ProRef = new string[] {""} ;
         T00486_A1740ProSts = new string[] {""} ;
         T00486_A1730ProObs = new string[] {""} ;
         T00486_A1738ProProdDsc = new string[] {""} ;
         T00486_A1654ProCantProd = new decimal[1] ;
         T00486_A1655ProCantProdIng = new decimal[1] ;
         T00486_A324ProPlanCod = new string[] {""} ;
         T00486_A323ProProdCod = new string[] {""} ;
         T00485_A1738ProProdDsc = new string[] {""} ;
         T00484_A324ProPlanCod = new string[] {""} ;
         T00487_A1738ProProdDsc = new string[] {""} ;
         T00488_A324ProPlanCod = new string[] {""} ;
         T00489_A322ProCod = new string[] {""} ;
         T00483_A322ProCod = new string[] {""} ;
         T00483_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         T00483_A1739ProRef = new string[] {""} ;
         T00483_A1740ProSts = new string[] {""} ;
         T00483_A1730ProObs = new string[] {""} ;
         T00483_A1654ProCantProd = new decimal[1] ;
         T00483_A1655ProCantProdIng = new decimal[1] ;
         T00483_A324ProPlanCod = new string[] {""} ;
         T00483_A323ProProdCod = new string[] {""} ;
         sMode147 = "";
         T004810_A322ProCod = new string[] {""} ;
         T004811_A322ProCod = new string[] {""} ;
         T00482_A322ProCod = new string[] {""} ;
         T00482_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         T00482_A1739ProRef = new string[] {""} ;
         T00482_A1740ProSts = new string[] {""} ;
         T00482_A1730ProObs = new string[] {""} ;
         T00482_A1654ProCantProd = new decimal[1] ;
         T00482_A1655ProCantProdIng = new decimal[1] ;
         T00482_A324ProPlanCod = new string[] {""} ;
         T00482_A323ProProdCod = new string[] {""} ;
         T004815_A1738ProProdDsc = new string[] {""} ;
         T004816_A322ProCod = new string[] {""} ;
         T004816_A321OPECod = new string[] {""} ;
         T004817_A322ProCod = new string[] {""} ;
         T004817_A320MAQCod = new string[] {""} ;
         T004818_A322ProCod = new string[] {""} ;
         T004818_A328ProGasCod = new short[1] ;
         T004819_A322ProCod = new string[] {""} ;
         T004819_A326ProDItem = new int[1] ;
         T004820_A322ProCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ322ProCod = "";
         ZZ325ProFec = DateTime.MinValue;
         ZZ1739ProRef = "";
         ZZ1740ProSts = "";
         ZZ1730ProObs = "";
         ZZ323ProProdCod = "";
         ZZ324ProPlanCod = "";
         ZZ1738ProProdDsc = "";
         T004821_A324ProPlanCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poordenes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poordenes__default(),
            new Object[][] {
                new Object[] {
               T00482_A322ProCod, T00482_A325ProFec, T00482_A1739ProRef, T00482_A1740ProSts, T00482_A1730ProObs, T00482_A1654ProCantProd, T00482_A1655ProCantProdIng, T00482_A324ProPlanCod, T00482_A323ProProdCod
               }
               , new Object[] {
               T00483_A322ProCod, T00483_A325ProFec, T00483_A1739ProRef, T00483_A1740ProSts, T00483_A1730ProObs, T00483_A1654ProCantProd, T00483_A1655ProCantProdIng, T00483_A324ProPlanCod, T00483_A323ProProdCod
               }
               , new Object[] {
               T00484_A324ProPlanCod
               }
               , new Object[] {
               T00485_A1738ProProdDsc
               }
               , new Object[] {
               T00486_A322ProCod, T00486_A325ProFec, T00486_A1739ProRef, T00486_A1740ProSts, T00486_A1730ProObs, T00486_A1738ProProdDsc, T00486_A1654ProCantProd, T00486_A1655ProCantProdIng, T00486_A324ProPlanCod, T00486_A323ProProdCod
               }
               , new Object[] {
               T00487_A1738ProProdDsc
               }
               , new Object[] {
               T00488_A324ProPlanCod
               }
               , new Object[] {
               T00489_A322ProCod
               }
               , new Object[] {
               T004810_A322ProCod
               }
               , new Object[] {
               T004811_A322ProCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004815_A1738ProProdDsc
               }
               , new Object[] {
               T004816_A322ProCod, T004816_A321OPECod
               }
               , new Object[] {
               T004817_A322ProCod, T004817_A320MAQCod
               }
               , new Object[] {
               T004818_A322ProCod, T004818_A328ProGasCod
               }
               , new Object[] {
               T004819_A322ProCod, T004819_A326ProDItem
               }
               , new Object[] {
               T004820_A322ProCod
               }
               , new Object[] {
               T004821_A324ProPlanCod
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
      private short RcdFound147 ;
      private short nIsDirty_147 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProFec_Enabled ;
      private int edtProRef_Enabled ;
      private int edtProSts_Enabled ;
      private int edtProObs_Enabled ;
      private int edtProProdCod_Enabled ;
      private int edtProProdDsc_Enabled ;
      private int edtProCantProd_Enabled ;
      private int edtProCantProdIng_Enabled ;
      private int edtProPlanCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z1654ProCantProd ;
      private decimal Z1655ProCantProdIng ;
      private decimal A1654ProCantProd ;
      private decimal A1655ProCantProdIng ;
      private decimal A1653ProCantFalta ;
      private decimal Z1653ProCantFalta ;
      private decimal ZZ1654ProCantProd ;
      private decimal ZZ1655ProCantProdIng ;
      private decimal ZZ1653ProCantFalta ;
      private string sPrefix ;
      private string Z322ProCod ;
      private string Z1739ProRef ;
      private string Z1740ProSts ;
      private string Z324ProPlanCod ;
      private string Z323ProProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A323ProProdCod ;
      private string A324ProPlanCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCod_Internalname ;
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
      private string A322ProCod ;
      private string edtProCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProFec_Internalname ;
      private string edtProFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProRef_Internalname ;
      private string A1739ProRef ;
      private string edtProRef_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProSts_Internalname ;
      private string A1740ProSts ;
      private string edtProSts_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProObs_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtProProdCod_Internalname ;
      private string edtProProdCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtProProdDsc_Internalname ;
      private string A1738ProProdDsc ;
      private string edtProProdDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtProCantProd_Internalname ;
      private string edtProCantProd_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtProCantProdIng_Internalname ;
      private string edtProCantProdIng_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtProPlanCod_Internalname ;
      private string edtProPlanCod_Jsonclick ;
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
      private string Z1738ProProdDsc ;
      private string sMode147 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ322ProCod ;
      private string ZZ1739ProRef ;
      private string ZZ1740ProSts ;
      private string ZZ323ProProdCod ;
      private string ZZ324ProPlanCod ;
      private string ZZ1738ProProdDsc ;
      private DateTime Z325ProFec ;
      private DateTime A325ProFec ;
      private DateTime ZZ325ProFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A1730ProObs ;
      private string Z1730ProObs ;
      private string ZZ1730ProObs ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00486_A322ProCod ;
      private DateTime[] T00486_A325ProFec ;
      private string[] T00486_A1739ProRef ;
      private string[] T00486_A1740ProSts ;
      private string[] T00486_A1730ProObs ;
      private string[] T00486_A1738ProProdDsc ;
      private decimal[] T00486_A1654ProCantProd ;
      private decimal[] T00486_A1655ProCantProdIng ;
      private string[] T00486_A324ProPlanCod ;
      private string[] T00486_A323ProProdCod ;
      private string[] T00485_A1738ProProdDsc ;
      private string[] T00484_A324ProPlanCod ;
      private string[] T00487_A1738ProProdDsc ;
      private string[] T00488_A324ProPlanCod ;
      private string[] T00489_A322ProCod ;
      private string[] T00483_A322ProCod ;
      private DateTime[] T00483_A325ProFec ;
      private string[] T00483_A1739ProRef ;
      private string[] T00483_A1740ProSts ;
      private string[] T00483_A1730ProObs ;
      private decimal[] T00483_A1654ProCantProd ;
      private decimal[] T00483_A1655ProCantProdIng ;
      private string[] T00483_A324ProPlanCod ;
      private string[] T00483_A323ProProdCod ;
      private string[] T004810_A322ProCod ;
      private string[] T004811_A322ProCod ;
      private string[] T00482_A322ProCod ;
      private DateTime[] T00482_A325ProFec ;
      private string[] T00482_A1739ProRef ;
      private string[] T00482_A1740ProSts ;
      private string[] T00482_A1730ProObs ;
      private decimal[] T00482_A1654ProCantProd ;
      private decimal[] T00482_A1655ProCantProdIng ;
      private string[] T00482_A324ProPlanCod ;
      private string[] T00482_A323ProProdCod ;
      private string[] T004815_A1738ProProdDsc ;
      private string[] T004816_A322ProCod ;
      private string[] T004816_A321OPECod ;
      private string[] T004817_A322ProCod ;
      private string[] T004817_A320MAQCod ;
      private string[] T004818_A322ProCod ;
      private short[] T004818_A328ProGasCod ;
      private string[] T004819_A322ProCod ;
      private int[] T004819_A326ProDItem ;
      private string[] T004820_A322ProCod ;
      private string[] T004821_A324ProPlanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poordenes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poordenes__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00486;
        prmT00486 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT00485;
        prmT00485 = new Object[] {
        new ParDef("@ProProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00484;
        prmT00484 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT00487;
        prmT00487 = new Object[] {
        new ParDef("@ProProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00488;
        prmT00488 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        Object[] prmT00489;
        prmT00489 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT00483;
        prmT00483 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004810;
        prmT004810 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004811;
        prmT004811 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT00482;
        prmT00482 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004812;
        prmT004812 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProFec",GXType.Date,8,0) ,
        new ParDef("@ProRef",GXType.NChar,50,0) ,
        new ParDef("@ProSts",GXType.NChar,1,0) ,
        new ParDef("@ProObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProCantProd",GXType.Decimal,15,4) ,
        new ParDef("@ProCantProdIng",GXType.Decimal,15,4) ,
        new ParDef("@ProPlanCod",GXType.NChar,10,0) ,
        new ParDef("@ProProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004813;
        prmT004813 = new Object[] {
        new ParDef("@ProFec",GXType.Date,8,0) ,
        new ParDef("@ProRef",GXType.NChar,50,0) ,
        new ParDef("@ProSts",GXType.NChar,1,0) ,
        new ParDef("@ProObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProCantProd",GXType.Decimal,15,4) ,
        new ParDef("@ProCantProdIng",GXType.Decimal,15,4) ,
        new ParDef("@ProPlanCod",GXType.NChar,10,0) ,
        new ParDef("@ProProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004814;
        prmT004814 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004816;
        prmT004816 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004817;
        prmT004817 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004818;
        prmT004818 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004819;
        prmT004819 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004820;
        prmT004820 = new Object[] {
        };
        Object[] prmT004815;
        prmT004815 = new Object[] {
        new ParDef("@ProProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004821;
        prmT004821 = new Object[] {
        new ParDef("@ProPlanCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00482", "SELECT [ProCod], [ProFec], [ProRef], [ProSts], [ProObs], [ProCantProd], [ProCantProdIng], [ProPlanCod], [ProProdCod] AS ProProdCod FROM [POORDENES] WITH (UPDLOCK) WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00482,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00483", "SELECT [ProCod], [ProFec], [ProRef], [ProSts], [ProObs], [ProCantProd], [ProCantProdIng], [ProPlanCod], [ProProdCod] AS ProProdCod FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00483,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00484", "SELECT [ProPlanCod] FROM [POPLAN] WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00484,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00485", "SELECT [ProdDsc] AS ProProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00485,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00486", "SELECT TM1.[ProCod], TM1.[ProFec], TM1.[ProRef], TM1.[ProSts], TM1.[ProObs], T2.[ProdDsc] AS ProProdDsc, TM1.[ProCantProd], TM1.[ProCantProdIng], TM1.[ProPlanCod], TM1.[ProProdCod] AS ProProdCod FROM ([POORDENES] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProProdCod]) WHERE TM1.[ProCod] = @ProCod ORDER BY TM1.[ProCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00486,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00487", "SELECT [ProdDsc] AS ProProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00487,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00488", "SELECT [ProPlanCod] FROM [POPLAN] WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00488,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00489", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00489,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004810", "SELECT TOP 1 [ProCod] FROM [POORDENES] WHERE ( [ProCod] > @ProCod) ORDER BY [ProCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004811", "SELECT TOP 1 [ProCod] FROM [POORDENES] WHERE ( [ProCod] < @ProCod) ORDER BY [ProCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004812", "INSERT INTO [POORDENES]([ProCod], [ProFec], [ProRef], [ProSts], [ProObs], [ProCantProd], [ProCantProdIng], [ProPlanCod], [ProProdCod]) VALUES(@ProCod, @ProFec, @ProRef, @ProSts, @ProObs, @ProCantProd, @ProCantProdIng, @ProPlanCod, @ProProdCod)", GxErrorMask.GX_NOMASK,prmT004812)
           ,new CursorDef("T004813", "UPDATE [POORDENES] SET [ProFec]=@ProFec, [ProRef]=@ProRef, [ProSts]=@ProSts, [ProObs]=@ProObs, [ProCantProd]=@ProCantProd, [ProCantProdIng]=@ProCantProdIng, [ProPlanCod]=@ProPlanCod, [ProProdCod]=@ProProdCod  WHERE [ProCod] = @ProCod", GxErrorMask.GX_NOMASK,prmT004813)
           ,new CursorDef("T004814", "DELETE FROM [POORDENES]  WHERE [ProCod] = @ProCod", GxErrorMask.GX_NOMASK,prmT004814)
           ,new CursorDef("T004815", "SELECT [ProdDsc] AS ProProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004816", "SELECT TOP 1 [ProCod], [OPECod] FROM [POORDENOPERARIO] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004816,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004817", "SELECT TOP 1 [ProCod], [MAQCod] FROM [POORDENMAQ] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004817,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004818", "SELECT TOP 1 [ProCod], [ProGasCod] FROM [POORDENGASTO] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004818,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004819", "SELECT TOP 1 [ProCod], [ProDItem] FROM [POORDENESDET] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004819,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004820", "SELECT [ProCod] FROM [POORDENES] ORDER BY [ProCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004820,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004821", "SELECT [ProPlanCod] FROM [POPLAN] WHERE [ProPlanCod] = @ProPlanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004821,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
