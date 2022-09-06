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
   public class poservicio : GXDataArea
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
            A334PSerProdCod = GetPar( "PSerProdCod");
            AssignAttri("", false, "A334PSerProdCod", A334PSerProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A334PSerProdCod) ;
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

      public poservicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poservicio( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POSERVICIO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCod_Internalname, StringUtil.RTrim( A329PSerCod), StringUtil.RTrim( context.localUtil.Format( A329PSerCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPSerFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPSerFec_Internalname, context.localUtil.Format(A1805PSerFec, "99/99/99"), context.localUtil.Format( A1805PSerFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERVICIO.htm");
         GxWebStd.gx_bitmap( context, edtPSerFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPSerFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "N° Pedido", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerRef_Internalname, StringUtil.RTrim( A1816PSerRef), StringUtil.RTrim( context.localUtil.Format( A1816PSerRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerRef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerSts_Internalname, StringUtil.RTrim( A1817PSerSts), StringUtil.RTrim( context.localUtil.Format( A1817PSerSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Observaciones", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPSerObs_Internalname, A1812PSerObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", 0, 1, edtPSerObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerProdCod_Internalname, StringUtil.RTrim( A334PSerProdCod), StringUtil.RTrim( context.localUtil.Format( A334PSerProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Servicio", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPSerProdDsc_Internalname, StringUtil.RTrim( A1815PSerProdDsc), StringUtil.RTrim( context.localUtil.Format( A1815PSerProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cantidad", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCantSer_Internalname, StringUtil.LTrim( StringUtil.NToC( A1793PSerCantSer, 17, 2, ".", "")), StringUtil.LTrim( ((edtPSerCantSer_Enabled!=0) ? context.localUtil.Format( A1793PSerCantSer, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1793PSerCantSer, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCantSer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCantSer_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Atendida", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCantIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1792PSerCantIng, 17, 2, ".", "")), StringUtil.LTrim( ((edtPSerCantIng_Enabled!=0) ? context.localUtil.Format( A1792PSerCantIng, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1792PSerCantIng, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCantIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCantIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Costo Total", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCostos_Internalname, StringUtil.LTrim( StringUtil.NToC( A1798PSerCostos, 17, 2, ".", "")), StringUtil.LTrim( ((edtPSerCostos_Enabled!=0) ? context.localUtil.Format( A1798PSerCostos, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1798PSerCostos, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCostos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCostos_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "R.U.C.", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerCliCod_Internalname, StringUtil.RTrim( A1794PSerCliCod), StringUtil.RTrim( context.localUtil.Format( A1794PSerCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerCliCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Item Pedido", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POSERVICIO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPSerPedItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1814PSerPedItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtPSerPedItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1814PSerPedItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1814PSerPedItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPSerPedItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPSerPedItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POSERVICIO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POSERVICIO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POSERVICIO.htm");
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
            Z1805PSerFec = context.localUtil.CToD( cgiGet( "Z1805PSerFec"), 0);
            Z1816PSerRef = cgiGet( "Z1816PSerRef");
            Z1817PSerSts = cgiGet( "Z1817PSerSts");
            Z1793PSerCantSer = context.localUtil.CToN( cgiGet( "Z1793PSerCantSer"), ".", ",");
            Z1792PSerCantIng = context.localUtil.CToN( cgiGet( "Z1792PSerCantIng"), ".", ",");
            Z1798PSerCostos = context.localUtil.CToN( cgiGet( "Z1798PSerCostos"), ".", ",");
            Z1794PSerCliCod = cgiGet( "Z1794PSerCliCod");
            Z1814PSerPedItem = (int)(context.localUtil.CToN( cgiGet( "Z1814PSerPedItem"), ".", ","));
            Z1818PSerTipo = cgiGet( "Z1818PSerTipo");
            Z334PSerProdCod = cgiGet( "Z334PSerProdCod");
            A1818PSerTipo = cgiGet( "Z1818PSerTipo");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1818PSerTipo = cgiGet( "PSERTIPO");
            /* Read variables values. */
            A329PSerCod = cgiGet( edtPSerCod_Internalname);
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            if ( context.localUtil.VCDate( cgiGet( edtPSerFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "PSERFEC");
               AnyError = 1;
               GX_FocusControl = edtPSerFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1805PSerFec = DateTime.MinValue;
               AssignAttri("", false, "A1805PSerFec", context.localUtil.Format(A1805PSerFec, "99/99/99"));
            }
            else
            {
               A1805PSerFec = context.localUtil.CToD( cgiGet( edtPSerFec_Internalname), 2);
               AssignAttri("", false, "A1805PSerFec", context.localUtil.Format(A1805PSerFec, "99/99/99"));
            }
            A1816PSerRef = cgiGet( edtPSerRef_Internalname);
            AssignAttri("", false, "A1816PSerRef", A1816PSerRef);
            A1817PSerSts = cgiGet( edtPSerSts_Internalname);
            AssignAttri("", false, "A1817PSerSts", A1817PSerSts);
            A1812PSerObs = cgiGet( edtPSerObs_Internalname);
            AssignAttri("", false, "A1812PSerObs", A1812PSerObs);
            A334PSerProdCod = StringUtil.Upper( cgiGet( edtPSerProdCod_Internalname));
            AssignAttri("", false, "A334PSerProdCod", A334PSerProdCod);
            A1815PSerProdDsc = cgiGet( edtPSerProdDsc_Internalname);
            AssignAttri("", false, "A1815PSerProdDsc", A1815PSerProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerCantSer_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerCantSer_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERCANTSER");
               AnyError = 1;
               GX_FocusControl = edtPSerCantSer_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1793PSerCantSer = 0;
               AssignAttri("", false, "A1793PSerCantSer", StringUtil.LTrimStr( A1793PSerCantSer, 15, 2));
            }
            else
            {
               A1793PSerCantSer = context.localUtil.CToN( cgiGet( edtPSerCantSer_Internalname), ".", ",");
               AssignAttri("", false, "A1793PSerCantSer", StringUtil.LTrimStr( A1793PSerCantSer, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerCantIng_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerCantIng_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERCANTING");
               AnyError = 1;
               GX_FocusControl = edtPSerCantIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1792PSerCantIng = 0;
               AssignAttri("", false, "A1792PSerCantIng", StringUtil.LTrimStr( A1792PSerCantIng, 15, 2));
            }
            else
            {
               A1792PSerCantIng = context.localUtil.CToN( cgiGet( edtPSerCantIng_Internalname), ".", ",");
               AssignAttri("", false, "A1792PSerCantIng", StringUtil.LTrimStr( A1792PSerCantIng, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerCostos_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerCostos_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERCOSTOS");
               AnyError = 1;
               GX_FocusControl = edtPSerCostos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1798PSerCostos = 0;
               AssignAttri("", false, "A1798PSerCostos", StringUtil.LTrimStr( A1798PSerCostos, 15, 2));
            }
            else
            {
               A1798PSerCostos = context.localUtil.CToN( cgiGet( edtPSerCostos_Internalname), ".", ",");
               AssignAttri("", false, "A1798PSerCostos", StringUtil.LTrimStr( A1798PSerCostos, 15, 2));
            }
            A1794PSerCliCod = cgiGet( edtPSerCliCod_Internalname);
            AssignAttri("", false, "A1794PSerCliCod", A1794PSerCliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPSerPedItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPSerPedItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PSERPEDITEM");
               AnyError = 1;
               GX_FocusControl = edtPSerPedItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1814PSerPedItem = 0;
               AssignAttri("", false, "A1814PSerPedItem", StringUtil.LTrimStr( (decimal)(A1814PSerPedItem), 6, 0));
            }
            else
            {
               A1814PSerPedItem = (int)(context.localUtil.CToN( cgiGet( edtPSerPedItem_Internalname), ".", ","));
               AssignAttri("", false, "A1814PSerPedItem", StringUtil.LTrimStr( (decimal)(A1814PSerPedItem), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"POSERVICIO");
            forbiddenHiddens.Add("PSerTipo", StringUtil.RTrim( context.localUtil.Format( A1818PSerTipo, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("poservicio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A329PSerCod = GetPar( "PSerCod");
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
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
               InitAll4K159( ) ;
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
         DisableAttributes4K159( ) ;
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

      protected void CONFIRM_4K0( )
      {
         BeforeValidate4K159( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4K159( ) ;
            }
            else
            {
               CheckExtendedTable4K159( ) ;
               if ( AnyError == 0 )
               {
                  ZM4K159( 3) ;
               }
               CloseExtendedTableCursors4K159( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4K0( ) ;
         }
      }

      protected void ResetCaption4K0( )
      {
      }

      protected void ZM4K159( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1805PSerFec = T004K3_A1805PSerFec[0];
               Z1816PSerRef = T004K3_A1816PSerRef[0];
               Z1817PSerSts = T004K3_A1817PSerSts[0];
               Z1793PSerCantSer = T004K3_A1793PSerCantSer[0];
               Z1792PSerCantIng = T004K3_A1792PSerCantIng[0];
               Z1798PSerCostos = T004K3_A1798PSerCostos[0];
               Z1794PSerCliCod = T004K3_A1794PSerCliCod[0];
               Z1814PSerPedItem = T004K3_A1814PSerPedItem[0];
               Z1818PSerTipo = T004K3_A1818PSerTipo[0];
               Z334PSerProdCod = T004K3_A334PSerProdCod[0];
            }
            else
            {
               Z1805PSerFec = A1805PSerFec;
               Z1816PSerRef = A1816PSerRef;
               Z1817PSerSts = A1817PSerSts;
               Z1793PSerCantSer = A1793PSerCantSer;
               Z1792PSerCantIng = A1792PSerCantIng;
               Z1798PSerCostos = A1798PSerCostos;
               Z1794PSerCliCod = A1794PSerCliCod;
               Z1814PSerPedItem = A1814PSerPedItem;
               Z1818PSerTipo = A1818PSerTipo;
               Z334PSerProdCod = A334PSerProdCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z329PSerCod = A329PSerCod;
            Z1805PSerFec = A1805PSerFec;
            Z1816PSerRef = A1816PSerRef;
            Z1817PSerSts = A1817PSerSts;
            Z1812PSerObs = A1812PSerObs;
            Z1793PSerCantSer = A1793PSerCantSer;
            Z1792PSerCantIng = A1792PSerCantIng;
            Z1798PSerCostos = A1798PSerCostos;
            Z1794PSerCliCod = A1794PSerCliCod;
            Z1814PSerPedItem = A1814PSerPedItem;
            Z1818PSerTipo = A1818PSerTipo;
            Z334PSerProdCod = A334PSerProdCod;
            Z1815PSerProdDsc = A1815PSerProdDsc;
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

      protected void Load4K159( )
      {
         /* Using cursor T004K5 */
         pr_default.execute(3, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound159 = 1;
            A1805PSerFec = T004K5_A1805PSerFec[0];
            AssignAttri("", false, "A1805PSerFec", context.localUtil.Format(A1805PSerFec, "99/99/99"));
            A1816PSerRef = T004K5_A1816PSerRef[0];
            AssignAttri("", false, "A1816PSerRef", A1816PSerRef);
            A1817PSerSts = T004K5_A1817PSerSts[0];
            AssignAttri("", false, "A1817PSerSts", A1817PSerSts);
            A1812PSerObs = T004K5_A1812PSerObs[0];
            AssignAttri("", false, "A1812PSerObs", A1812PSerObs);
            A1815PSerProdDsc = T004K5_A1815PSerProdDsc[0];
            AssignAttri("", false, "A1815PSerProdDsc", A1815PSerProdDsc);
            A1793PSerCantSer = T004K5_A1793PSerCantSer[0];
            AssignAttri("", false, "A1793PSerCantSer", StringUtil.LTrimStr( A1793PSerCantSer, 15, 2));
            A1792PSerCantIng = T004K5_A1792PSerCantIng[0];
            AssignAttri("", false, "A1792PSerCantIng", StringUtil.LTrimStr( A1792PSerCantIng, 15, 2));
            A1798PSerCostos = T004K5_A1798PSerCostos[0];
            AssignAttri("", false, "A1798PSerCostos", StringUtil.LTrimStr( A1798PSerCostos, 15, 2));
            A1794PSerCliCod = T004K5_A1794PSerCliCod[0];
            AssignAttri("", false, "A1794PSerCliCod", A1794PSerCliCod);
            A1814PSerPedItem = T004K5_A1814PSerPedItem[0];
            AssignAttri("", false, "A1814PSerPedItem", StringUtil.LTrimStr( (decimal)(A1814PSerPedItem), 6, 0));
            A1818PSerTipo = T004K5_A1818PSerTipo[0];
            A334PSerProdCod = T004K5_A334PSerProdCod[0];
            AssignAttri("", false, "A334PSerProdCod", A334PSerProdCod);
            ZM4K159( -2) ;
         }
         pr_default.close(3);
         OnLoadActions4K159( ) ;
      }

      protected void OnLoadActions4K159( )
      {
      }

      protected void CheckExtendedTable4K159( )
      {
         nIsDirty_159 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1805PSerFec) || ( DateTimeUtil.ResetTime ( A1805PSerFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "PSERFEC");
            AnyError = 1;
            GX_FocusControl = edtPSerFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T004K4 */
         pr_default.execute(2, new Object[] {A334PSerProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Servicio'.", "ForeignKeyNotFound", 1, "PSERPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1815PSerProdDsc = T004K4_A1815PSerProdDsc[0];
         AssignAttri("", false, "A1815PSerProdDsc", A1815PSerProdDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors4K159( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A334PSerProdCod )
      {
         /* Using cursor T004K6 */
         pr_default.execute(4, new Object[] {A334PSerProdCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Servicio'.", "ForeignKeyNotFound", 1, "PSERPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1815PSerProdDsc = T004K6_A1815PSerProdDsc[0];
         AssignAttri("", false, "A1815PSerProdDsc", A1815PSerProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1815PSerProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey4K159( )
      {
         /* Using cursor T004K7 */
         pr_default.execute(5, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound159 = 1;
         }
         else
         {
            RcdFound159 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004K3 */
         pr_default.execute(1, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4K159( 2) ;
            RcdFound159 = 1;
            A329PSerCod = T004K3_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
            A1805PSerFec = T004K3_A1805PSerFec[0];
            AssignAttri("", false, "A1805PSerFec", context.localUtil.Format(A1805PSerFec, "99/99/99"));
            A1816PSerRef = T004K3_A1816PSerRef[0];
            AssignAttri("", false, "A1816PSerRef", A1816PSerRef);
            A1817PSerSts = T004K3_A1817PSerSts[0];
            AssignAttri("", false, "A1817PSerSts", A1817PSerSts);
            A1812PSerObs = T004K3_A1812PSerObs[0];
            AssignAttri("", false, "A1812PSerObs", A1812PSerObs);
            A1793PSerCantSer = T004K3_A1793PSerCantSer[0];
            AssignAttri("", false, "A1793PSerCantSer", StringUtil.LTrimStr( A1793PSerCantSer, 15, 2));
            A1792PSerCantIng = T004K3_A1792PSerCantIng[0];
            AssignAttri("", false, "A1792PSerCantIng", StringUtil.LTrimStr( A1792PSerCantIng, 15, 2));
            A1798PSerCostos = T004K3_A1798PSerCostos[0];
            AssignAttri("", false, "A1798PSerCostos", StringUtil.LTrimStr( A1798PSerCostos, 15, 2));
            A1794PSerCliCod = T004K3_A1794PSerCliCod[0];
            AssignAttri("", false, "A1794PSerCliCod", A1794PSerCliCod);
            A1814PSerPedItem = T004K3_A1814PSerPedItem[0];
            AssignAttri("", false, "A1814PSerPedItem", StringUtil.LTrimStr( (decimal)(A1814PSerPedItem), 6, 0));
            A1818PSerTipo = T004K3_A1818PSerTipo[0];
            A334PSerProdCod = T004K3_A334PSerProdCod[0];
            AssignAttri("", false, "A334PSerProdCod", A334PSerProdCod);
            Z329PSerCod = A329PSerCod;
            sMode159 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4K159( ) ;
            if ( AnyError == 1 )
            {
               RcdFound159 = 0;
               InitializeNonKey4K159( ) ;
            }
            Gx_mode = sMode159;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound159 = 0;
            InitializeNonKey4K159( ) ;
            sMode159 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode159;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4K159( ) ;
         if ( RcdFound159 == 0 )
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
         RcdFound159 = 0;
         /* Using cursor T004K8 */
         pr_default.execute(6, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T004K8_A329PSerCod[0], A329PSerCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T004K8_A329PSerCod[0], A329PSerCod) > 0 ) ) )
            {
               A329PSerCod = T004K8_A329PSerCod[0];
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               RcdFound159 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound159 = 0;
         /* Using cursor T004K9 */
         pr_default.execute(7, new Object[] {A329PSerCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T004K9_A329PSerCod[0], A329PSerCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T004K9_A329PSerCod[0], A329PSerCod) < 0 ) ) )
            {
               A329PSerCod = T004K9_A329PSerCod[0];
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
               RcdFound159 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4K159( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4K159( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound159 == 1 )
            {
               if ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 )
               {
                  A329PSerCod = Z329PSerCod;
                  AssignAttri("", false, "A329PSerCod", A329PSerCod);
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
                  Update4K159( ) ;
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPSerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4K159( ) ;
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
                     Insert4K159( ) ;
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
         if ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 )
         {
            A329PSerCod = Z329PSerCod;
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
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
         GetKey4K159( ) ;
         if ( RcdFound159 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PSERCOD");
               AnyError = 1;
               GX_FocusControl = edtPSerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 )
            {
               A329PSerCod = Z329PSerCod;
               AssignAttri("", false, "A329PSerCod", A329PSerCod);
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
            if ( StringUtil.StrCmp(A329PSerCod, Z329PSerCod) != 0 )
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
         context.RollbackDataStores("poservicio",pr_default);
         GX_FocusControl = edtPSerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4K0( ) ;
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
         if ( RcdFound159 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PSERCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPSerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4K159( ) ;
         if ( RcdFound159 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4K159( ) ;
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
         if ( RcdFound159 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerFec_Internalname;
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
         if ( RcdFound159 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerFec_Internalname;
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
         ScanStart4K159( ) ;
         if ( RcdFound159 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound159 != 0 )
            {
               ScanNext4K159( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPSerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4K159( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4K159( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004K2 */
            pr_default.execute(0, new Object[] {A329PSerCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERVICIO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1805PSerFec ) != DateTimeUtil.ResetTime ( T004K2_A1805PSerFec[0] ) ) || ( StringUtil.StrCmp(Z1816PSerRef, T004K2_A1816PSerRef[0]) != 0 ) || ( StringUtil.StrCmp(Z1817PSerSts, T004K2_A1817PSerSts[0]) != 0 ) || ( Z1793PSerCantSer != T004K2_A1793PSerCantSer[0] ) || ( Z1792PSerCantIng != T004K2_A1792PSerCantIng[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1798PSerCostos != T004K2_A1798PSerCostos[0] ) || ( StringUtil.StrCmp(Z1794PSerCliCod, T004K2_A1794PSerCliCod[0]) != 0 ) || ( Z1814PSerPedItem != T004K2_A1814PSerPedItem[0] ) || ( StringUtil.StrCmp(Z1818PSerTipo, T004K2_A1818PSerTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z334PSerProdCod, T004K2_A334PSerProdCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1805PSerFec ) != DateTimeUtil.ResetTime ( T004K2_A1805PSerFec[0] ) )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerFec");
                  GXUtil.WriteLogRaw("Old: ",Z1805PSerFec);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1805PSerFec[0]);
               }
               if ( StringUtil.StrCmp(Z1816PSerRef, T004K2_A1816PSerRef[0]) != 0 )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerRef");
                  GXUtil.WriteLogRaw("Old: ",Z1816PSerRef);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1816PSerRef[0]);
               }
               if ( StringUtil.StrCmp(Z1817PSerSts, T004K2_A1817PSerSts[0]) != 0 )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerSts");
                  GXUtil.WriteLogRaw("Old: ",Z1817PSerSts);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1817PSerSts[0]);
               }
               if ( Z1793PSerCantSer != T004K2_A1793PSerCantSer[0] )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerCantSer");
                  GXUtil.WriteLogRaw("Old: ",Z1793PSerCantSer);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1793PSerCantSer[0]);
               }
               if ( Z1792PSerCantIng != T004K2_A1792PSerCantIng[0] )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerCantIng");
                  GXUtil.WriteLogRaw("Old: ",Z1792PSerCantIng);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1792PSerCantIng[0]);
               }
               if ( Z1798PSerCostos != T004K2_A1798PSerCostos[0] )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerCostos");
                  GXUtil.WriteLogRaw("Old: ",Z1798PSerCostos);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1798PSerCostos[0]);
               }
               if ( StringUtil.StrCmp(Z1794PSerCliCod, T004K2_A1794PSerCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z1794PSerCliCod);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1794PSerCliCod[0]);
               }
               if ( Z1814PSerPedItem != T004K2_A1814PSerPedItem[0] )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerPedItem");
                  GXUtil.WriteLogRaw("Old: ",Z1814PSerPedItem);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1814PSerPedItem[0]);
               }
               if ( StringUtil.StrCmp(Z1818PSerTipo, T004K2_A1818PSerTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1818PSerTipo);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A1818PSerTipo[0]);
               }
               if ( StringUtil.StrCmp(Z334PSerProdCod, T004K2_A334PSerProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poservicio:[seudo value changed for attri]"+"PSerProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z334PSerProdCod);
                  GXUtil.WriteLogRaw("Current: ",T004K2_A334PSerProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POSERVICIO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4K159( )
      {
         BeforeValidate4K159( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4K159( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4K159( 0) ;
            CheckOptimisticConcurrency4K159( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4K159( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4K159( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004K10 */
                     pr_default.execute(8, new Object[] {A329PSerCod, A1805PSerFec, A1816PSerRef, A1817PSerSts, A1812PSerObs, A1793PSerCantSer, A1792PSerCantIng, A1798PSerCostos, A1794PSerCliCod, A1814PSerPedItem, A1818PSerTipo, A334PSerProdCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERVICIO");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption4K0( ) ;
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
               Load4K159( ) ;
            }
            EndLevel4K159( ) ;
         }
         CloseExtendedTableCursors4K159( ) ;
      }

      protected void Update4K159( )
      {
         BeforeValidate4K159( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4K159( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4K159( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4K159( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4K159( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004K11 */
                     pr_default.execute(9, new Object[] {A1805PSerFec, A1816PSerRef, A1817PSerSts, A1812PSerObs, A1793PSerCantSer, A1792PSerCantIng, A1798PSerCostos, A1794PSerCliCod, A1814PSerPedItem, A1818PSerTipo, A334PSerProdCod, A329PSerCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("POSERVICIO");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POSERVICIO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4K159( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4K0( ) ;
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
            EndLevel4K159( ) ;
         }
         CloseExtendedTableCursors4K159( ) ;
      }

      protected void DeferredUpdate4K159( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4K159( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4K159( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4K159( ) ;
            AfterConfirm4K159( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4K159( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004K12 */
                  pr_default.execute(10, new Object[] {A329PSerCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("POSERVICIO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound159 == 0 )
                        {
                           InitAll4K159( ) ;
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
                        ResetCaption4K0( ) ;
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
         sMode159 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4K159( ) ;
         Gx_mode = sMode159;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4K159( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004K13 */
            pr_default.execute(11, new Object[] {A334PSerProdCod});
            A1815PSerProdDsc = T004K13_A1815PSerProdDsc[0];
            AssignAttri("", false, "A1815PSerProdDsc", A1815PSerProdDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T004K14 */
            pr_default.execute(12, new Object[] {A329PSerCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POSERVICIODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T004K15 */
            pr_default.execute(13, new Object[] {A329PSerCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maquina"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T004K16 */
            pr_default.execute(14, new Object[] {A329PSerCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T004K17 */
            pr_default.execute(15, new Object[] {A329PSerCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Gastos Varios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel4K159( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4K159( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("poservicio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("poservicio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4K159( )
      {
         /* Using cursor T004K18 */
         pr_default.execute(16);
         RcdFound159 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound159 = 1;
            A329PSerCod = T004K18_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4K159( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound159 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound159 = 1;
            A329PSerCod = T004K18_A329PSerCod[0];
            AssignAttri("", false, "A329PSerCod", A329PSerCod);
         }
      }

      protected void ScanEnd4K159( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm4K159( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4K159( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4K159( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4K159( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4K159( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4K159( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4K159( )
      {
         edtPSerCod_Enabled = 0;
         AssignProp("", false, edtPSerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCod_Enabled), 5, 0), true);
         edtPSerFec_Enabled = 0;
         AssignProp("", false, edtPSerFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerFec_Enabled), 5, 0), true);
         edtPSerRef_Enabled = 0;
         AssignProp("", false, edtPSerRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerRef_Enabled), 5, 0), true);
         edtPSerSts_Enabled = 0;
         AssignProp("", false, edtPSerSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerSts_Enabled), 5, 0), true);
         edtPSerObs_Enabled = 0;
         AssignProp("", false, edtPSerObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerObs_Enabled), 5, 0), true);
         edtPSerProdCod_Enabled = 0;
         AssignProp("", false, edtPSerProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerProdCod_Enabled), 5, 0), true);
         edtPSerProdDsc_Enabled = 0;
         AssignProp("", false, edtPSerProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerProdDsc_Enabled), 5, 0), true);
         edtPSerCantSer_Enabled = 0;
         AssignProp("", false, edtPSerCantSer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCantSer_Enabled), 5, 0), true);
         edtPSerCantIng_Enabled = 0;
         AssignProp("", false, edtPSerCantIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCantIng_Enabled), 5, 0), true);
         edtPSerCostos_Enabled = 0;
         AssignProp("", false, edtPSerCostos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCostos_Enabled), 5, 0), true);
         edtPSerCliCod_Enabled = 0;
         AssignProp("", false, edtPSerCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerCliCod_Enabled), 5, 0), true);
         edtPSerPedItem_Enabled = 0;
         AssignProp("", false, edtPSerPedItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPSerPedItem_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4K159( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4K0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254017", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("poservicio.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"POSERVICIO");
         forbiddenHiddens.Add("PSerTipo", StringUtil.RTrim( context.localUtil.Format( A1818PSerTipo, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("poservicio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z329PSerCod", StringUtil.RTrim( Z329PSerCod));
         GxWebStd.gx_hidden_field( context, "Z1805PSerFec", context.localUtil.DToC( Z1805PSerFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1816PSerRef", StringUtil.RTrim( Z1816PSerRef));
         GxWebStd.gx_hidden_field( context, "Z1817PSerSts", StringUtil.RTrim( Z1817PSerSts));
         GxWebStd.gx_hidden_field( context, "Z1793PSerCantSer", StringUtil.LTrim( StringUtil.NToC( Z1793PSerCantSer, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1792PSerCantIng", StringUtil.LTrim( StringUtil.NToC( Z1792PSerCantIng, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1798PSerCostos", StringUtil.LTrim( StringUtil.NToC( Z1798PSerCostos, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1794PSerCliCod", StringUtil.RTrim( Z1794PSerCliCod));
         GxWebStd.gx_hidden_field( context, "Z1814PSerPedItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1814PSerPedItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1818PSerTipo", Z1818PSerTipo);
         GxWebStd.gx_hidden_field( context, "Z334PSerProdCod", StringUtil.RTrim( Z334PSerProdCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PSERTIPO", A1818PSerTipo);
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
         return formatLink("poservicio.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POSERVICIO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Orden de Servicio" ;
      }

      protected void InitializeNonKey4K159( )
      {
         A1805PSerFec = DateTime.MinValue;
         AssignAttri("", false, "A1805PSerFec", context.localUtil.Format(A1805PSerFec, "99/99/99"));
         A1816PSerRef = "";
         AssignAttri("", false, "A1816PSerRef", A1816PSerRef);
         A1817PSerSts = "";
         AssignAttri("", false, "A1817PSerSts", A1817PSerSts);
         A1812PSerObs = "";
         AssignAttri("", false, "A1812PSerObs", A1812PSerObs);
         A334PSerProdCod = "";
         AssignAttri("", false, "A334PSerProdCod", A334PSerProdCod);
         A1815PSerProdDsc = "";
         AssignAttri("", false, "A1815PSerProdDsc", A1815PSerProdDsc);
         A1793PSerCantSer = 0;
         AssignAttri("", false, "A1793PSerCantSer", StringUtil.LTrimStr( A1793PSerCantSer, 15, 2));
         A1792PSerCantIng = 0;
         AssignAttri("", false, "A1792PSerCantIng", StringUtil.LTrimStr( A1792PSerCantIng, 15, 2));
         A1798PSerCostos = 0;
         AssignAttri("", false, "A1798PSerCostos", StringUtil.LTrimStr( A1798PSerCostos, 15, 2));
         A1794PSerCliCod = "";
         AssignAttri("", false, "A1794PSerCliCod", A1794PSerCliCod);
         A1814PSerPedItem = 0;
         AssignAttri("", false, "A1814PSerPedItem", StringUtil.LTrimStr( (decimal)(A1814PSerPedItem), 6, 0));
         A1818PSerTipo = "";
         AssignAttri("", false, "A1818PSerTipo", A1818PSerTipo);
         Z1805PSerFec = DateTime.MinValue;
         Z1816PSerRef = "";
         Z1817PSerSts = "";
         Z1793PSerCantSer = 0;
         Z1792PSerCantIng = 0;
         Z1798PSerCostos = 0;
         Z1794PSerCliCod = "";
         Z1814PSerPedItem = 0;
         Z1818PSerTipo = "";
         Z334PSerProdCod = "";
      }

      protected void InitAll4K159( )
      {
         A329PSerCod = "";
         AssignAttri("", false, "A329PSerCod", A329PSerCod);
         InitializeNonKey4K159( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254029", true, true);
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
         context.AddJavascriptSource("poservicio.js", "?202281810254029", false, true);
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
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPSerFec_Internalname = "PSERFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPSerRef_Internalname = "PSERREF";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPSerSts_Internalname = "PSERSTS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPSerObs_Internalname = "PSEROBS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPSerProdCod_Internalname = "PSERPRODCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPSerProdDsc_Internalname = "PSERPRODDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPSerCantSer_Internalname = "PSERCANTSER";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPSerCantIng_Internalname = "PSERCANTING";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPSerCostos_Internalname = "PSERCOSTOS";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtPSerCliCod_Internalname = "PSERCLICOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtPSerPedItem_Internalname = "PSERPEDITEM";
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
         edtPSerPedItem_Jsonclick = "";
         edtPSerPedItem_Enabled = 1;
         edtPSerCliCod_Jsonclick = "";
         edtPSerCliCod_Enabled = 1;
         edtPSerCostos_Jsonclick = "";
         edtPSerCostos_Enabled = 1;
         edtPSerCantIng_Jsonclick = "";
         edtPSerCantIng_Enabled = 1;
         edtPSerCantSer_Jsonclick = "";
         edtPSerCantSer_Enabled = 1;
         edtPSerProdDsc_Jsonclick = "";
         edtPSerProdDsc_Enabled = 0;
         edtPSerProdCod_Jsonclick = "";
         edtPSerProdCod_Enabled = 1;
         edtPSerObs_Enabled = 1;
         edtPSerSts_Jsonclick = "";
         edtPSerSts_Enabled = 1;
         edtPSerRef_Jsonclick = "";
         edtPSerRef_Enabled = 1;
         edtPSerFec_Jsonclick = "";
         edtPSerFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
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
         GX_FocusControl = edtPSerFec_Internalname;
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
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1805PSerFec", context.localUtil.Format(A1805PSerFec, "99/99/99"));
         AssignAttri("", false, "A1816PSerRef", StringUtil.RTrim( A1816PSerRef));
         AssignAttri("", false, "A1817PSerSts", StringUtil.RTrim( A1817PSerSts));
         AssignAttri("", false, "A1812PSerObs", A1812PSerObs);
         AssignAttri("", false, "A334PSerProdCod", StringUtil.RTrim( A334PSerProdCod));
         AssignAttri("", false, "A1793PSerCantSer", StringUtil.LTrim( StringUtil.NToC( A1793PSerCantSer, 15, 2, ".", "")));
         AssignAttri("", false, "A1792PSerCantIng", StringUtil.LTrim( StringUtil.NToC( A1792PSerCantIng, 15, 2, ".", "")));
         AssignAttri("", false, "A1798PSerCostos", StringUtil.LTrim( StringUtil.NToC( A1798PSerCostos, 15, 2, ".", "")));
         AssignAttri("", false, "A1794PSerCliCod", StringUtil.RTrim( A1794PSerCliCod));
         AssignAttri("", false, "A1814PSerPedItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1814PSerPedItem), 6, 0, ".", "")));
         AssignAttri("", false, "A1818PSerTipo", A1818PSerTipo);
         AssignAttri("", false, "A1815PSerProdDsc", StringUtil.RTrim( A1815PSerProdDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z329PSerCod", StringUtil.RTrim( Z329PSerCod));
         GxWebStd.gx_hidden_field( context, "Z1805PSerFec", context.localUtil.Format(Z1805PSerFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1816PSerRef", StringUtil.RTrim( Z1816PSerRef));
         GxWebStd.gx_hidden_field( context, "Z1817PSerSts", StringUtil.RTrim( Z1817PSerSts));
         GxWebStd.gx_hidden_field( context, "Z1812PSerObs", Z1812PSerObs);
         GxWebStd.gx_hidden_field( context, "Z334PSerProdCod", StringUtil.RTrim( Z334PSerProdCod));
         GxWebStd.gx_hidden_field( context, "Z1793PSerCantSer", StringUtil.LTrim( StringUtil.NToC( Z1793PSerCantSer, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1792PSerCantIng", StringUtil.LTrim( StringUtil.NToC( Z1792PSerCantIng, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1798PSerCostos", StringUtil.LTrim( StringUtil.NToC( Z1798PSerCostos, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1794PSerCliCod", StringUtil.RTrim( Z1794PSerCliCod));
         GxWebStd.gx_hidden_field( context, "Z1814PSerPedItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1814PSerPedItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1818PSerTipo", Z1818PSerTipo);
         GxWebStd.gx_hidden_field( context, "Z1815PSerProdDsc", StringUtil.RTrim( Z1815PSerProdDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Pserprodcod( )
      {
         /* Using cursor T004K13 */
         pr_default.execute(11, new Object[] {A334PSerProdCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Servicio'.", "ForeignKeyNotFound", 1, "PSERPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtPSerProdCod_Internalname;
         }
         A1815PSerProdDsc = T004K13_A1815PSerProdDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1815PSerProdDsc", StringUtil.RTrim( A1815PSerProdDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1818PSerTipo',fld:'PSERTIPO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PSERCOD","{handler:'Valid_Psercod',iparms:[{av:'A1818PSerTipo',fld:'PSERTIPO',pic:''},{av:'A329PSerCod',fld:'PSERCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PSERCOD",",oparms:[{av:'A1805PSerFec',fld:'PSERFEC',pic:''},{av:'A1816PSerRef',fld:'PSERREF',pic:''},{av:'A1817PSerSts',fld:'PSERSTS',pic:''},{av:'A1812PSerObs',fld:'PSEROBS',pic:''},{av:'A334PSerProdCod',fld:'PSERPRODCOD',pic:'@!'},{av:'A1793PSerCantSer',fld:'PSERCANTSER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1792PSerCantIng',fld:'PSERCANTING',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1798PSerCostos',fld:'PSERCOSTOS',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1794PSerCliCod',fld:'PSERCLICOD',pic:''},{av:'A1814PSerPedItem',fld:'PSERPEDITEM',pic:'ZZZZZ9'},{av:'A1818PSerTipo',fld:'PSERTIPO',pic:''},{av:'A1815PSerProdDsc',fld:'PSERPRODDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z329PSerCod'},{av:'Z1805PSerFec'},{av:'Z1816PSerRef'},{av:'Z1817PSerSts'},{av:'Z1812PSerObs'},{av:'Z334PSerProdCod'},{av:'Z1793PSerCantSer'},{av:'Z1792PSerCantIng'},{av:'Z1798PSerCostos'},{av:'Z1794PSerCliCod'},{av:'Z1814PSerPedItem'},{av:'Z1818PSerTipo'},{av:'Z1815PSerProdDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PSERFEC","{handler:'Valid_Pserfec',iparms:[]");
         setEventMetadata("VALID_PSERFEC",",oparms:[]}");
         setEventMetadata("VALID_PSERPRODCOD","{handler:'Valid_Pserprodcod',iparms:[{av:'A334PSerProdCod',fld:'PSERPRODCOD',pic:'@!'},{av:'A1815PSerProdDsc',fld:'PSERPRODDSC',pic:''}]");
         setEventMetadata("VALID_PSERPRODCOD",",oparms:[{av:'A1815PSerProdDsc',fld:'PSERPRODDSC',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z329PSerCod = "";
         Z1805PSerFec = DateTime.MinValue;
         Z1816PSerRef = "";
         Z1817PSerSts = "";
         Z1794PSerCliCod = "";
         Z1818PSerTipo = "";
         Z334PSerProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A334PSerProdCod = "";
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
         A329PSerCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1805PSerFec = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         A1816PSerRef = "";
         lblTextblock4_Jsonclick = "";
         A1817PSerSts = "";
         lblTextblock5_Jsonclick = "";
         A1812PSerObs = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1815PSerProdDsc = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         A1794PSerCliCod = "";
         lblTextblock12_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1818PSerTipo = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1812PSerObs = "";
         Z1815PSerProdDsc = "";
         T004K5_A329PSerCod = new string[] {""} ;
         T004K5_A1805PSerFec = new DateTime[] {DateTime.MinValue} ;
         T004K5_A1816PSerRef = new string[] {""} ;
         T004K5_A1817PSerSts = new string[] {""} ;
         T004K5_A1812PSerObs = new string[] {""} ;
         T004K5_A1815PSerProdDsc = new string[] {""} ;
         T004K5_A1793PSerCantSer = new decimal[1] ;
         T004K5_A1792PSerCantIng = new decimal[1] ;
         T004K5_A1798PSerCostos = new decimal[1] ;
         T004K5_A1794PSerCliCod = new string[] {""} ;
         T004K5_A1814PSerPedItem = new int[1] ;
         T004K5_A1818PSerTipo = new string[] {""} ;
         T004K5_A334PSerProdCod = new string[] {""} ;
         T004K4_A1815PSerProdDsc = new string[] {""} ;
         T004K6_A1815PSerProdDsc = new string[] {""} ;
         T004K7_A329PSerCod = new string[] {""} ;
         T004K3_A329PSerCod = new string[] {""} ;
         T004K3_A1805PSerFec = new DateTime[] {DateTime.MinValue} ;
         T004K3_A1816PSerRef = new string[] {""} ;
         T004K3_A1817PSerSts = new string[] {""} ;
         T004K3_A1812PSerObs = new string[] {""} ;
         T004K3_A1793PSerCantSer = new decimal[1] ;
         T004K3_A1792PSerCantIng = new decimal[1] ;
         T004K3_A1798PSerCostos = new decimal[1] ;
         T004K3_A1794PSerCliCod = new string[] {""} ;
         T004K3_A1814PSerPedItem = new int[1] ;
         T004K3_A1818PSerTipo = new string[] {""} ;
         T004K3_A334PSerProdCod = new string[] {""} ;
         sMode159 = "";
         T004K8_A329PSerCod = new string[] {""} ;
         T004K9_A329PSerCod = new string[] {""} ;
         T004K2_A329PSerCod = new string[] {""} ;
         T004K2_A1805PSerFec = new DateTime[] {DateTime.MinValue} ;
         T004K2_A1816PSerRef = new string[] {""} ;
         T004K2_A1817PSerSts = new string[] {""} ;
         T004K2_A1812PSerObs = new string[] {""} ;
         T004K2_A1793PSerCantSer = new decimal[1] ;
         T004K2_A1792PSerCantIng = new decimal[1] ;
         T004K2_A1798PSerCostos = new decimal[1] ;
         T004K2_A1794PSerCliCod = new string[] {""} ;
         T004K2_A1814PSerPedItem = new int[1] ;
         T004K2_A1818PSerTipo = new string[] {""} ;
         T004K2_A334PSerProdCod = new string[] {""} ;
         T004K13_A1815PSerProdDsc = new string[] {""} ;
         T004K14_A329PSerCod = new string[] {""} ;
         T004K14_A335PSerDItem = new int[1] ;
         T004K15_A329PSerCod = new string[] {""} ;
         T004K15_A320MAQCod = new string[] {""} ;
         T004K16_A329PSerCod = new string[] {""} ;
         T004K16_A321OPECod = new string[] {""} ;
         T004K17_A329PSerCod = new string[] {""} ;
         T004K17_A330PSerGasCod = new short[1] ;
         T004K18_A329PSerCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ329PSerCod = "";
         ZZ1805PSerFec = DateTime.MinValue;
         ZZ1816PSerRef = "";
         ZZ1817PSerSts = "";
         ZZ1812PSerObs = "";
         ZZ334PSerProdCod = "";
         ZZ1794PSerCliCod = "";
         ZZ1818PSerTipo = "";
         ZZ1815PSerProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poservicio__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poservicio__default(),
            new Object[][] {
                new Object[] {
               T004K2_A329PSerCod, T004K2_A1805PSerFec, T004K2_A1816PSerRef, T004K2_A1817PSerSts, T004K2_A1812PSerObs, T004K2_A1793PSerCantSer, T004K2_A1792PSerCantIng, T004K2_A1798PSerCostos, T004K2_A1794PSerCliCod, T004K2_A1814PSerPedItem,
               T004K2_A1818PSerTipo, T004K2_A334PSerProdCod
               }
               , new Object[] {
               T004K3_A329PSerCod, T004K3_A1805PSerFec, T004K3_A1816PSerRef, T004K3_A1817PSerSts, T004K3_A1812PSerObs, T004K3_A1793PSerCantSer, T004K3_A1792PSerCantIng, T004K3_A1798PSerCostos, T004K3_A1794PSerCliCod, T004K3_A1814PSerPedItem,
               T004K3_A1818PSerTipo, T004K3_A334PSerProdCod
               }
               , new Object[] {
               T004K4_A1815PSerProdDsc
               }
               , new Object[] {
               T004K5_A329PSerCod, T004K5_A1805PSerFec, T004K5_A1816PSerRef, T004K5_A1817PSerSts, T004K5_A1812PSerObs, T004K5_A1815PSerProdDsc, T004K5_A1793PSerCantSer, T004K5_A1792PSerCantIng, T004K5_A1798PSerCostos, T004K5_A1794PSerCliCod,
               T004K5_A1814PSerPedItem, T004K5_A1818PSerTipo, T004K5_A334PSerProdCod
               }
               , new Object[] {
               T004K6_A1815PSerProdDsc
               }
               , new Object[] {
               T004K7_A329PSerCod
               }
               , new Object[] {
               T004K8_A329PSerCod
               }
               , new Object[] {
               T004K9_A329PSerCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004K13_A1815PSerProdDsc
               }
               , new Object[] {
               T004K14_A329PSerCod, T004K14_A335PSerDItem
               }
               , new Object[] {
               T004K15_A329PSerCod, T004K15_A320MAQCod
               }
               , new Object[] {
               T004K16_A329PSerCod, T004K16_A321OPECod
               }
               , new Object[] {
               T004K17_A329PSerCod, T004K17_A330PSerGasCod
               }
               , new Object[] {
               T004K18_A329PSerCod
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
      private short RcdFound159 ;
      private short nIsDirty_159 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1814PSerPedItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPSerCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPSerFec_Enabled ;
      private int edtPSerRef_Enabled ;
      private int edtPSerSts_Enabled ;
      private int edtPSerObs_Enabled ;
      private int edtPSerProdCod_Enabled ;
      private int edtPSerProdDsc_Enabled ;
      private int edtPSerCantSer_Enabled ;
      private int edtPSerCantIng_Enabled ;
      private int edtPSerCostos_Enabled ;
      private int edtPSerCliCod_Enabled ;
      private int A1814PSerPedItem ;
      private int edtPSerPedItem_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ1814PSerPedItem ;
      private decimal Z1793PSerCantSer ;
      private decimal Z1792PSerCantIng ;
      private decimal Z1798PSerCostos ;
      private decimal A1793PSerCantSer ;
      private decimal A1792PSerCantIng ;
      private decimal A1798PSerCostos ;
      private decimal ZZ1793PSerCantSer ;
      private decimal ZZ1792PSerCantIng ;
      private decimal ZZ1798PSerCostos ;
      private string sPrefix ;
      private string Z329PSerCod ;
      private string Z1816PSerRef ;
      private string Z1817PSerSts ;
      private string Z1794PSerCliCod ;
      private string Z334PSerProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A334PSerProdCod ;
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
      private string A329PSerCod ;
      private string edtPSerCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPSerFec_Internalname ;
      private string edtPSerFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPSerRef_Internalname ;
      private string A1816PSerRef ;
      private string edtPSerRef_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPSerSts_Internalname ;
      private string A1817PSerSts ;
      private string edtPSerSts_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPSerObs_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPSerProdCod_Internalname ;
      private string edtPSerProdCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPSerProdDsc_Internalname ;
      private string A1815PSerProdDsc ;
      private string edtPSerProdDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPSerCantSer_Internalname ;
      private string edtPSerCantSer_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPSerCantIng_Internalname ;
      private string edtPSerCantIng_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPSerCostos_Internalname ;
      private string edtPSerCostos_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtPSerCliCod_Internalname ;
      private string A1794PSerCliCod ;
      private string edtPSerCliCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtPSerPedItem_Internalname ;
      private string edtPSerPedItem_Jsonclick ;
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
      private string Z1815PSerProdDsc ;
      private string sMode159 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ329PSerCod ;
      private string ZZ1816PSerRef ;
      private string ZZ1817PSerSts ;
      private string ZZ334PSerProdCod ;
      private string ZZ1794PSerCliCod ;
      private string ZZ1815PSerProdDsc ;
      private DateTime Z1805PSerFec ;
      private DateTime A1805PSerFec ;
      private DateTime ZZ1805PSerFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A1812PSerObs ;
      private string Z1812PSerObs ;
      private string ZZ1812PSerObs ;
      private string Z1818PSerTipo ;
      private string A1818PSerTipo ;
      private string ZZ1818PSerTipo ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004K5_A329PSerCod ;
      private DateTime[] T004K5_A1805PSerFec ;
      private string[] T004K5_A1816PSerRef ;
      private string[] T004K5_A1817PSerSts ;
      private string[] T004K5_A1812PSerObs ;
      private string[] T004K5_A1815PSerProdDsc ;
      private decimal[] T004K5_A1793PSerCantSer ;
      private decimal[] T004K5_A1792PSerCantIng ;
      private decimal[] T004K5_A1798PSerCostos ;
      private string[] T004K5_A1794PSerCliCod ;
      private int[] T004K5_A1814PSerPedItem ;
      private string[] T004K5_A1818PSerTipo ;
      private string[] T004K5_A334PSerProdCod ;
      private string[] T004K4_A1815PSerProdDsc ;
      private string[] T004K6_A1815PSerProdDsc ;
      private string[] T004K7_A329PSerCod ;
      private string[] T004K3_A329PSerCod ;
      private DateTime[] T004K3_A1805PSerFec ;
      private string[] T004K3_A1816PSerRef ;
      private string[] T004K3_A1817PSerSts ;
      private string[] T004K3_A1812PSerObs ;
      private decimal[] T004K3_A1793PSerCantSer ;
      private decimal[] T004K3_A1792PSerCantIng ;
      private decimal[] T004K3_A1798PSerCostos ;
      private string[] T004K3_A1794PSerCliCod ;
      private int[] T004K3_A1814PSerPedItem ;
      private string[] T004K3_A1818PSerTipo ;
      private string[] T004K3_A334PSerProdCod ;
      private string[] T004K8_A329PSerCod ;
      private string[] T004K9_A329PSerCod ;
      private string[] T004K2_A329PSerCod ;
      private DateTime[] T004K2_A1805PSerFec ;
      private string[] T004K2_A1816PSerRef ;
      private string[] T004K2_A1817PSerSts ;
      private string[] T004K2_A1812PSerObs ;
      private decimal[] T004K2_A1793PSerCantSer ;
      private decimal[] T004K2_A1792PSerCantIng ;
      private decimal[] T004K2_A1798PSerCostos ;
      private string[] T004K2_A1794PSerCliCod ;
      private int[] T004K2_A1814PSerPedItem ;
      private string[] T004K2_A1818PSerTipo ;
      private string[] T004K2_A334PSerProdCod ;
      private string[] T004K13_A1815PSerProdDsc ;
      private string[] T004K14_A329PSerCod ;
      private int[] T004K14_A335PSerDItem ;
      private string[] T004K15_A329PSerCod ;
      private string[] T004K15_A320MAQCod ;
      private string[] T004K16_A329PSerCod ;
      private string[] T004K16_A321OPECod ;
      private string[] T004K17_A329PSerCod ;
      private short[] T004K17_A330PSerGasCod ;
      private string[] T004K18_A329PSerCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poservicio__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poservicio__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
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
        Object[] prmT004K5;
        prmT004K5 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K4;
        prmT004K4 = new Object[] {
        new ParDef("@PSerProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004K6;
        prmT004K6 = new Object[] {
        new ParDef("@PSerProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004K7;
        prmT004K7 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K3;
        prmT004K3 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K8;
        prmT004K8 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K9;
        prmT004K9 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K2;
        prmT004K2 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K10;
        prmT004K10 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0) ,
        new ParDef("@PSerFec",GXType.Date,8,0) ,
        new ParDef("@PSerRef",GXType.NChar,10,0) ,
        new ParDef("@PSerSts",GXType.NChar,1,0) ,
        new ParDef("@PSerObs",GXType.NVarChar,500,0) ,
        new ParDef("@PSerCantSer",GXType.Decimal,15,2) ,
        new ParDef("@PSerCantIng",GXType.Decimal,15,2) ,
        new ParDef("@PSerCostos",GXType.Decimal,15,2) ,
        new ParDef("@PSerCliCod",GXType.NChar,15,0) ,
        new ParDef("@PSerPedItem",GXType.Int32,6,0) ,
        new ParDef("@PSerTipo",GXType.NVarChar,1,0) ,
        new ParDef("@PSerProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004K11;
        prmT004K11 = new Object[] {
        new ParDef("@PSerFec",GXType.Date,8,0) ,
        new ParDef("@PSerRef",GXType.NChar,10,0) ,
        new ParDef("@PSerSts",GXType.NChar,1,0) ,
        new ParDef("@PSerObs",GXType.NVarChar,500,0) ,
        new ParDef("@PSerCantSer",GXType.Decimal,15,2) ,
        new ParDef("@PSerCantIng",GXType.Decimal,15,2) ,
        new ParDef("@PSerCostos",GXType.Decimal,15,2) ,
        new ParDef("@PSerCliCod",GXType.NChar,15,0) ,
        new ParDef("@PSerPedItem",GXType.Int32,6,0) ,
        new ParDef("@PSerTipo",GXType.NVarChar,1,0) ,
        new ParDef("@PSerProdCod",GXType.NChar,15,0) ,
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K12;
        prmT004K12 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K14;
        prmT004K14 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K15;
        prmT004K15 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K16;
        prmT004K16 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K17;
        prmT004K17 = new Object[] {
        new ParDef("@PSerCod",GXType.NChar,10,0)
        };
        Object[] prmT004K18;
        prmT004K18 = new Object[] {
        };
        Object[] prmT004K13;
        prmT004K13 = new Object[] {
        new ParDef("@PSerProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004K2", "SELECT [PSerCod], [PSerFec], [PSerRef], [PSerSts], [PSerObs], [PSerCantSer], [PSerCantIng], [PSerCostos], [PSerCliCod], [PSerPedItem], [PSerTipo], [PSerProdCod] AS PSerProdCod FROM [POSERVICIO] WITH (UPDLOCK) WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K3", "SELECT [PSerCod], [PSerFec], [PSerRef], [PSerSts], [PSerObs], [PSerCantSer], [PSerCantIng], [PSerCostos], [PSerCliCod], [PSerPedItem], [PSerTipo], [PSerProdCod] AS PSerProdCod FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K4", "SELECT [ProdDsc] AS PSerProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @PSerProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K5", "SELECT TM1.[PSerCod], TM1.[PSerFec], TM1.[PSerRef], TM1.[PSerSts], TM1.[PSerObs], T2.[ProdDsc] AS PSerProdDsc, TM1.[PSerCantSer], TM1.[PSerCantIng], TM1.[PSerCostos], TM1.[PSerCliCod], TM1.[PSerPedItem], TM1.[PSerTipo], TM1.[PSerProdCod] AS PSerProdCod FROM ([POSERVICIO] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[PSerProdCod]) WHERE TM1.[PSerCod] = @PSerCod ORDER BY TM1.[PSerCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004K5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K6", "SELECT [ProdDsc] AS PSerProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @PSerProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K7", "SELECT [PSerCod] FROM [POSERVICIO] WHERE [PSerCod] = @PSerCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K8", "SELECT TOP 1 [PSerCod] FROM [POSERVICIO] WHERE ( [PSerCod] > @PSerCod) ORDER BY [PSerCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004K8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004K9", "SELECT TOP 1 [PSerCod] FROM [POSERVICIO] WHERE ( [PSerCod] < @PSerCod) ORDER BY [PSerCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004K9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004K10", "INSERT INTO [POSERVICIO]([PSerCod], [PSerFec], [PSerRef], [PSerSts], [PSerObs], [PSerCantSer], [PSerCantIng], [PSerCostos], [PSerCliCod], [PSerPedItem], [PSerTipo], [PSerProdCod]) VALUES(@PSerCod, @PSerFec, @PSerRef, @PSerSts, @PSerObs, @PSerCantSer, @PSerCantIng, @PSerCostos, @PSerCliCod, @PSerPedItem, @PSerTipo, @PSerProdCod)", GxErrorMask.GX_NOMASK,prmT004K10)
           ,new CursorDef("T004K11", "UPDATE [POSERVICIO] SET [PSerFec]=@PSerFec, [PSerRef]=@PSerRef, [PSerSts]=@PSerSts, [PSerObs]=@PSerObs, [PSerCantSer]=@PSerCantSer, [PSerCantIng]=@PSerCantIng, [PSerCostos]=@PSerCostos, [PSerCliCod]=@PSerCliCod, [PSerPedItem]=@PSerPedItem, [PSerTipo]=@PSerTipo, [PSerProdCod]=@PSerProdCod  WHERE [PSerCod] = @PSerCod", GxErrorMask.GX_NOMASK,prmT004K11)
           ,new CursorDef("T004K12", "DELETE FROM [POSERVICIO]  WHERE [PSerCod] = @PSerCod", GxErrorMask.GX_NOMASK,prmT004K12)
           ,new CursorDef("T004K13", "SELECT [ProdDsc] AS PSerProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @PSerProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004K14", "SELECT TOP 1 [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004K15", "SELECT TOP 1 [PSerCod], [MAQCod] FROM [POORSERMAQ] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004K16", "SELECT TOP 1 [PSerCod], [OPECod] FROM [POORDSEROPERARIO] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004K17", "SELECT TOP 1 [PSerCod], [PSerGasCod] FROM [POORDSERGASTOS] WHERE [PSerCod] = @PSerCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004K17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004K18", "SELECT [PSerCod] FROM [POSERVICIO] ORDER BY [PSerCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004K18,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
