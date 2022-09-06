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
   public class aguiasconsigna : GXDataArea
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
            A29AGCliCod = GetPar( "AGCliCod");
            AssignAttri("", false, "A29AGCliCod", A29AGCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A29AGCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A28ProdCod) ;
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
            Form.Meta.addItem("description", "Seguimiento de Consignacion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAGMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aguiasconsigna( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguiasconsigna( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AGUIASCONSIGNA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "T/G", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGMVATip_Internalname, StringUtil.RTrim( A26AGMVATip), StringUtil.RTrim( context.localUtil.Format( A26AGMVATip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGMVATip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGMVATip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Guia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGMVACod_Internalname, StringUtil.RTrim( A27AGMVACod), StringUtil.RTrim( context.localUtil.Format( A27AGMVACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGMVACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGMVACod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAGMVAFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAGMVAFec_Internalname, context.localUtil.Format(A431AGMVAFec, "99/99/99"), context.localUtil.Format( A431AGMVAFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGMVAFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGMVAFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASCONSIGNA.htm");
         GxWebStd.gx_bitmap( context, edtAGMVAFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAGMVAFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Pedido", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGPedCod_Internalname, StringUtil.RTrim( A432AGPedCod), StringUtil.RTrim( context.localUtil.Format( A432AGPedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Cliente", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGCliCod_Internalname, StringUtil.RTrim( A29AGCliCod), StringUtil.RTrim( context.localUtil.Format( A29AGCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Cliente", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAGCliDsc_Internalname, StringUtil.RTrim( A427AGCliDsc), StringUtil.RTrim( context.localUtil.Format( A427AGCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo Producto", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Descripcion producto", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cantidad Pedida", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGMVADCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A428AGMVADCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtAGMVADCant_Enabled!=0) ? context.localUtil.Format( A428AGMVADCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A428AGMVADCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGMVADCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGMVADCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Cantidad Facturada", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAGMVADCantF_Internalname, StringUtil.LTrim( StringUtil.NToC( A429AGMVADCantF, 17, 4, ".", "")), StringUtil.LTrim( ((edtAGMVADCantF_Enabled!=0) ? context.localUtil.Format( A429AGMVADCantF, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A429AGMVADCantF, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGMVADCantF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGMVADCantF_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Cantidad Pendiente", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASCONSIGNA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAGMVADCantP_Internalname, StringUtil.LTrim( StringUtil.NToC( A430AGMVADCantP, 17, 4, ".", "")), StringUtil.LTrim( ((edtAGMVADCantP_Enabled!=0) ? context.localUtil.Format( A430AGMVADCantP, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A430AGMVADCantP, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAGMVADCantP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAGMVADCantP_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASCONSIGNA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASCONSIGNA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_AGUIASCONSIGNA.htm");
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
            Z26AGMVATip = cgiGet( "Z26AGMVATip");
            Z27AGMVACod = cgiGet( "Z27AGMVACod");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z431AGMVAFec = context.localUtil.CToD( cgiGet( "Z431AGMVAFec"), 0);
            Z432AGPedCod = cgiGet( "Z432AGPedCod");
            Z428AGMVADCant = context.localUtil.CToN( cgiGet( "Z428AGMVADCant"), ".", ",");
            Z429AGMVADCantF = context.localUtil.CToN( cgiGet( "Z429AGMVADCantF"), ".", ",");
            Z29AGCliCod = cgiGet( "Z29AGCliCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A26AGMVATip = cgiGet( edtAGMVATip_Internalname);
            AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
            A27AGMVACod = cgiGet( edtAGMVACod_Internalname);
            AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
            if ( context.localUtil.VCDate( cgiGet( edtAGMVAFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "AGMVAFEC");
               AnyError = 1;
               GX_FocusControl = edtAGMVAFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A431AGMVAFec = DateTime.MinValue;
               AssignAttri("", false, "A431AGMVAFec", context.localUtil.Format(A431AGMVAFec, "99/99/99"));
            }
            else
            {
               A431AGMVAFec = context.localUtil.CToD( cgiGet( edtAGMVAFec_Internalname), 2);
               AssignAttri("", false, "A431AGMVAFec", context.localUtil.Format(A431AGMVAFec, "99/99/99"));
            }
            A432AGPedCod = cgiGet( edtAGPedCod_Internalname);
            AssignAttri("", false, "A432AGPedCod", A432AGPedCod);
            A29AGCliCod = cgiGet( edtAGCliCod_Internalname);
            AssignAttri("", false, "A29AGCliCod", A29AGCliCod);
            A427AGCliDsc = cgiGet( edtAGCliDsc_Internalname);
            AssignAttri("", false, "A427AGCliDsc", A427AGCliDsc);
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A55ProdDsc = cgiGet( edtProdDsc_Internalname);
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAGMVADCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAGMVADCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AGMVADCANT");
               AnyError = 1;
               GX_FocusControl = edtAGMVADCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A428AGMVADCant = 0;
               AssignAttri("", false, "A428AGMVADCant", StringUtil.LTrimStr( A428AGMVADCant, 15, 4));
            }
            else
            {
               A428AGMVADCant = context.localUtil.CToN( cgiGet( edtAGMVADCant_Internalname), ".", ",");
               AssignAttri("", false, "A428AGMVADCant", StringUtil.LTrimStr( A428AGMVADCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAGMVADCantF_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAGMVADCantF_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AGMVADCANTF");
               AnyError = 1;
               GX_FocusControl = edtAGMVADCantF_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A429AGMVADCantF = 0;
               AssignAttri("", false, "A429AGMVADCantF", StringUtil.LTrimStr( A429AGMVADCantF, 15, 4));
            }
            else
            {
               A429AGMVADCantF = context.localUtil.CToN( cgiGet( edtAGMVADCantF_Internalname), ".", ",");
               AssignAttri("", false, "A429AGMVADCantF", StringUtil.LTrimStr( A429AGMVADCantF, 15, 4));
            }
            A430AGMVADCantP = context.localUtil.CToN( cgiGet( edtAGMVADCantP_Internalname), ".", ",");
            AssignAttri("", false, "A430AGMVADCantP", StringUtil.LTrimStr( A430AGMVADCantP, 15, 4));
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
               A26AGMVATip = GetPar( "AGMVATip");
               AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
               A27AGMVACod = GetPar( "AGMVACod");
               AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
               A28ProdCod = GetPar( "ProdCod");
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
               InitAll1539( ) ;
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
         DisableAttributes1539( ) ;
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1539( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1539( ) ;
            }
            else
            {
               CheckExtendedTable1539( ) ;
               if ( AnyError == 0 )
               {
                  ZM1539( 4) ;
                  ZM1539( 5) ;
               }
               CloseExtendedTableCursors1539( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues150( ) ;
         }
      }

      protected void ResetCaption150( )
      {
      }

      protected void ZM1539( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z431AGMVAFec = T00153_A431AGMVAFec[0];
               Z432AGPedCod = T00153_A432AGPedCod[0];
               Z428AGMVADCant = T00153_A428AGMVADCant[0];
               Z429AGMVADCantF = T00153_A429AGMVADCantF[0];
               Z29AGCliCod = T00153_A29AGCliCod[0];
            }
            else
            {
               Z431AGMVAFec = A431AGMVAFec;
               Z432AGPedCod = A432AGPedCod;
               Z428AGMVADCant = A428AGMVADCant;
               Z429AGMVADCantF = A429AGMVADCantF;
               Z29AGCliCod = A29AGCliCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z26AGMVATip = A26AGMVATip;
            Z27AGMVACod = A27AGMVACod;
            Z431AGMVAFec = A431AGMVAFec;
            Z432AGPedCod = A432AGPedCod;
            Z428AGMVADCant = A428AGMVADCant;
            Z429AGMVADCantF = A429AGMVADCantF;
            Z28ProdCod = A28ProdCod;
            Z29AGCliCod = A29AGCliCod;
            Z427AGCliDsc = A427AGCliDsc;
            Z55ProdDsc = A55ProdDsc;
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

      protected void Load1539( )
      {
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound39 = 1;
            A431AGMVAFec = T00156_A431AGMVAFec[0];
            AssignAttri("", false, "A431AGMVAFec", context.localUtil.Format(A431AGMVAFec, "99/99/99"));
            A432AGPedCod = T00156_A432AGPedCod[0];
            AssignAttri("", false, "A432AGPedCod", A432AGPedCod);
            A427AGCliDsc = T00156_A427AGCliDsc[0];
            AssignAttri("", false, "A427AGCliDsc", A427AGCliDsc);
            A55ProdDsc = T00156_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A428AGMVADCant = T00156_A428AGMVADCant[0];
            AssignAttri("", false, "A428AGMVADCant", StringUtil.LTrimStr( A428AGMVADCant, 15, 4));
            A429AGMVADCantF = T00156_A429AGMVADCantF[0];
            AssignAttri("", false, "A429AGMVADCantF", StringUtil.LTrimStr( A429AGMVADCantF, 15, 4));
            A29AGCliCod = T00156_A29AGCliCod[0];
            AssignAttri("", false, "A29AGCliCod", A29AGCliCod);
            ZM1539( -3) ;
         }
         pr_default.close(4);
         OnLoadActions1539( ) ;
      }

      protected void OnLoadActions1539( )
      {
         A430AGMVADCantP = (decimal)(A428AGMVADCant-A429AGMVADCantF);
         AssignAttri("", false, "A430AGMVADCantP", StringUtil.LTrimStr( A430AGMVADCantP, 15, 4));
      }

      protected void CheckExtendedTable1539( )
      {
         nIsDirty_39 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A431AGMVAFec) || ( DateTimeUtil.ResetTime ( A431AGMVAFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "AGMVAFEC");
            AnyError = 1;
            GX_FocusControl = edtAGMVAFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00155 */
         pr_default.execute(3, new Object[] {A29AGCliCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "AGCLICOD");
            AnyError = 1;
            GX_FocusControl = edtAGCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A427AGCliDsc = T00155_A427AGCliDsc[0];
         AssignAttri("", false, "A427AGCliDsc", A427AGCliDsc);
         pr_default.close(3);
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T00154_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         pr_default.close(2);
         nIsDirty_39 = 1;
         A430AGMVADCantP = (decimal)(A428AGMVADCant-A429AGMVADCantF);
         AssignAttri("", false, "A430AGMVADCantP", StringUtil.LTrimStr( A430AGMVADCantP, 15, 4));
      }

      protected void CloseExtendedTableCursors1539( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A29AGCliCod )
      {
         /* Using cursor T00157 */
         pr_default.execute(5, new Object[] {A29AGCliCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "AGCLICOD");
            AnyError = 1;
            GX_FocusControl = edtAGCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A427AGCliDsc = T00157_A427AGCliDsc[0];
         AssignAttri("", false, "A427AGCliDsc", A427AGCliDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A427AGCliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( string A28ProdCod )
      {
         /* Using cursor T00158 */
         pr_default.execute(6, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T00158_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A55ProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1539( )
      {
         /* Using cursor T00159 */
         pr_default.execute(7, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1539( 3) ;
            RcdFound39 = 1;
            A26AGMVATip = T00153_A26AGMVATip[0];
            AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
            A27AGMVACod = T00153_A27AGMVACod[0];
            AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
            A431AGMVAFec = T00153_A431AGMVAFec[0];
            AssignAttri("", false, "A431AGMVAFec", context.localUtil.Format(A431AGMVAFec, "99/99/99"));
            A432AGPedCod = T00153_A432AGPedCod[0];
            AssignAttri("", false, "A432AGPedCod", A432AGPedCod);
            A428AGMVADCant = T00153_A428AGMVADCant[0];
            AssignAttri("", false, "A428AGMVADCant", StringUtil.LTrimStr( A428AGMVADCant, 15, 4));
            A429AGMVADCantF = T00153_A429AGMVADCantF[0];
            AssignAttri("", false, "A429AGMVADCantF", StringUtil.LTrimStr( A429AGMVADCantF, 15, 4));
            A28ProdCod = T00153_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A29AGCliCod = T00153_A29AGCliCod[0];
            AssignAttri("", false, "A29AGCliCod", A29AGCliCod);
            Z26AGMVATip = A26AGMVATip;
            Z27AGMVACod = A27AGMVACod;
            Z28ProdCod = A28ProdCod;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1539( ) ;
            if ( AnyError == 1 )
            {
               RcdFound39 = 0;
               InitializeNonKey1539( ) ;
            }
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey1539( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode39;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1539( ) ;
         if ( RcdFound39 == 0 )
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
         RcdFound39 = 0;
         /* Using cursor T001510 */
         pr_default.execute(8, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001510_A26AGMVATip[0], A26AGMVATip) < 0 ) || ( StringUtil.StrCmp(T001510_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001510_A27AGMVACod[0], A27AGMVACod) < 0 ) || ( StringUtil.StrCmp(T001510_A27AGMVACod[0], A27AGMVACod) == 0 ) && ( StringUtil.StrCmp(T001510_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001510_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001510_A26AGMVATip[0], A26AGMVATip) > 0 ) || ( StringUtil.StrCmp(T001510_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001510_A27AGMVACod[0], A27AGMVACod) > 0 ) || ( StringUtil.StrCmp(T001510_A27AGMVACod[0], A27AGMVACod) == 0 ) && ( StringUtil.StrCmp(T001510_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001510_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               A26AGMVATip = T001510_A26AGMVATip[0];
               AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
               A27AGMVACod = T001510_A27AGMVACod[0];
               AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
               A28ProdCod = T001510_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound39 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound39 = 0;
         /* Using cursor T001511 */
         pr_default.execute(9, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001511_A26AGMVATip[0], A26AGMVATip) > 0 ) || ( StringUtil.StrCmp(T001511_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001511_A27AGMVACod[0], A27AGMVACod) > 0 ) || ( StringUtil.StrCmp(T001511_A27AGMVACod[0], A27AGMVACod) == 0 ) && ( StringUtil.StrCmp(T001511_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001511_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001511_A26AGMVATip[0], A26AGMVATip) < 0 ) || ( StringUtil.StrCmp(T001511_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001511_A27AGMVACod[0], A27AGMVACod) < 0 ) || ( StringUtil.StrCmp(T001511_A27AGMVACod[0], A27AGMVACod) == 0 ) && ( StringUtil.StrCmp(T001511_A26AGMVATip[0], A26AGMVATip) == 0 ) && ( StringUtil.StrCmp(T001511_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               A26AGMVATip = T001511_A26AGMVATip[0];
               AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
               A27AGMVACod = T001511_A27AGMVACod[0];
               AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
               A28ProdCod = T001511_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound39 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1539( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAGMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1539( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound39 == 1 )
            {
               if ( ( StringUtil.StrCmp(A26AGMVATip, Z26AGMVATip) != 0 ) || ( StringUtil.StrCmp(A27AGMVACod, Z27AGMVACod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
               {
                  A26AGMVATip = Z26AGMVATip;
                  AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
                  A27AGMVACod = Z27AGMVACod;
                  AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AGMVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtAGMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAGMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1539( ) ;
                  GX_FocusControl = edtAGMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A26AGMVATip, Z26AGMVATip) != 0 ) || ( StringUtil.StrCmp(A27AGMVACod, Z27AGMVACod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAGMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1539( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AGMVATIP");
                     AnyError = 1;
                     GX_FocusControl = edtAGMVATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAGMVATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1539( ) ;
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
         if ( ( StringUtil.StrCmp(A26AGMVATip, Z26AGMVATip) != 0 ) || ( StringUtil.StrCmp(A27AGMVACod, Z27AGMVACod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
         {
            A26AGMVATip = Z26AGMVATip;
            AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
            A27AGMVACod = Z27AGMVACod;
            AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AGMVATIP");
            AnyError = 1;
            GX_FocusControl = edtAGMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAGMVATip_Internalname;
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
         GetKey1539( ) ;
         if ( RcdFound39 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "AGMVATIP");
               AnyError = 1;
               GX_FocusControl = edtAGMVATip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A26AGMVATip, Z26AGMVATip) != 0 ) || ( StringUtil.StrCmp(A27AGMVACod, Z27AGMVACod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
            {
               A26AGMVATip = Z26AGMVATip;
               AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
               A27AGMVACod = Z27AGMVACod;
               AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
               A28ProdCod = Z28ProdCod;
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "AGMVATIP");
               AnyError = 1;
               GX_FocusControl = edtAGMVATip_Internalname;
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
            if ( ( StringUtil.StrCmp(A26AGMVATip, Z26AGMVATip) != 0 ) || ( StringUtil.StrCmp(A27AGMVACod, Z27AGMVACod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AGMVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtAGMVATip_Internalname;
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
         context.RollbackDataStores("aguiasconsigna",pr_default);
         GX_FocusControl = edtAGMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_150( ) ;
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
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AGMVATIP");
            AnyError = 1;
            GX_FocusControl = edtAGMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAGMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1539( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAGMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1539( ) ;
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
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAGMVAFec_Internalname;
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
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAGMVAFec_Internalname;
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
         ScanStart1539( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound39 != 0 )
            {
               ScanNext1539( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAGMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1539( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1539( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASCONSIGNA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z431AGMVAFec ) != DateTimeUtil.ResetTime ( T00152_A431AGMVAFec[0] ) ) || ( StringUtil.StrCmp(Z432AGPedCod, T00152_A432AGPedCod[0]) != 0 ) || ( Z428AGMVADCant != T00152_A428AGMVADCant[0] ) || ( Z429AGMVADCantF != T00152_A429AGMVADCantF[0] ) || ( StringUtil.StrCmp(Z29AGCliCod, T00152_A29AGCliCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z431AGMVAFec ) != DateTimeUtil.ResetTime ( T00152_A431AGMVAFec[0] ) )
               {
                  GXUtil.WriteLog("aguiasconsigna:[seudo value changed for attri]"+"AGMVAFec");
                  GXUtil.WriteLogRaw("Old: ",Z431AGMVAFec);
                  GXUtil.WriteLogRaw("Current: ",T00152_A431AGMVAFec[0]);
               }
               if ( StringUtil.StrCmp(Z432AGPedCod, T00152_A432AGPedCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasconsigna:[seudo value changed for attri]"+"AGPedCod");
                  GXUtil.WriteLogRaw("Old: ",Z432AGPedCod);
                  GXUtil.WriteLogRaw("Current: ",T00152_A432AGPedCod[0]);
               }
               if ( Z428AGMVADCant != T00152_A428AGMVADCant[0] )
               {
                  GXUtil.WriteLog("aguiasconsigna:[seudo value changed for attri]"+"AGMVADCant");
                  GXUtil.WriteLogRaw("Old: ",Z428AGMVADCant);
                  GXUtil.WriteLogRaw("Current: ",T00152_A428AGMVADCant[0]);
               }
               if ( Z429AGMVADCantF != T00152_A429AGMVADCantF[0] )
               {
                  GXUtil.WriteLog("aguiasconsigna:[seudo value changed for attri]"+"AGMVADCantF");
                  GXUtil.WriteLogRaw("Old: ",Z429AGMVADCantF);
                  GXUtil.WriteLogRaw("Current: ",T00152_A429AGMVADCantF[0]);
               }
               if ( StringUtil.StrCmp(Z29AGCliCod, T00152_A29AGCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasconsigna:[seudo value changed for attri]"+"AGCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z29AGCliCod);
                  GXUtil.WriteLogRaw("Current: ",T00152_A29AGCliCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AGUIASCONSIGNA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1539( )
      {
         BeforeValidate1539( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1539( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1539( 0) ;
            CheckOptimisticConcurrency1539( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1539( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1539( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001512 */
                     pr_default.execute(10, new Object[] {A26AGMVATip, A27AGMVACod, A431AGMVAFec, A432AGPedCod, A428AGMVADCant, A429AGMVADCantF, A28ProdCod, A29AGCliCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASCONSIGNA");
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
                           ResetCaption150( ) ;
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
               Load1539( ) ;
            }
            EndLevel1539( ) ;
         }
         CloseExtendedTableCursors1539( ) ;
      }

      protected void Update1539( )
      {
         BeforeValidate1539( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1539( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1539( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1539( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1539( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001513 */
                     pr_default.execute(11, new Object[] {A431AGMVAFec, A432AGPedCod, A428AGMVADCant, A429AGMVADCantF, A29AGCliCod, A26AGMVATip, A27AGMVACod, A28ProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASCONSIGNA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASCONSIGNA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1539( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption150( ) ;
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
            EndLevel1539( ) ;
         }
         CloseExtendedTableCursors1539( ) ;
      }

      protected void DeferredUpdate1539( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1539( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1539( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1539( ) ;
            AfterConfirm1539( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1539( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001514 */
                  pr_default.execute(12, new Object[] {A26AGMVATip, A27AGMVACod, A28ProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("AGUIASCONSIGNA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound39 == 0 )
                        {
                           InitAll1539( ) ;
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
                        ResetCaption150( ) ;
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
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1539( ) ;
         Gx_mode = sMode39;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1539( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001515 */
            pr_default.execute(13, new Object[] {A29AGCliCod});
            A427AGCliDsc = T001515_A427AGCliDsc[0];
            AssignAttri("", false, "A427AGCliDsc", A427AGCliDsc);
            pr_default.close(13);
            /* Using cursor T001516 */
            pr_default.execute(14, new Object[] {A28ProdCod});
            A55ProdDsc = T001516_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            pr_default.close(14);
            A430AGMVADCantP = (decimal)(A428AGMVADCant-A429AGMVADCantF);
            AssignAttri("", false, "A430AGMVADCantP", StringUtil.LTrimStr( A430AGMVADCantP, 15, 4));
         }
      }

      protected void EndLevel1539( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1539( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(13);
            context.CommitDataStores("aguiasconsigna",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(14);
            pr_default.close(13);
            context.RollbackDataStores("aguiasconsigna",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1539( )
      {
         /* Using cursor T001517 */
         pr_default.execute(15);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound39 = 1;
            A26AGMVATip = T001517_A26AGMVATip[0];
            AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
            A27AGMVACod = T001517_A27AGMVACod[0];
            AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
            A28ProdCod = T001517_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1539( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound39 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound39 = 1;
            A26AGMVATip = T001517_A26AGMVATip[0];
            AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
            A27AGMVACod = T001517_A27AGMVACod[0];
            AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
            A28ProdCod = T001517_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
      }

      protected void ScanEnd1539( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1539( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1539( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1539( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1539( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1539( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1539( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1539( )
      {
         edtAGMVATip_Enabled = 0;
         AssignProp("", false, edtAGMVATip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGMVATip_Enabled), 5, 0), true);
         edtAGMVACod_Enabled = 0;
         AssignProp("", false, edtAGMVACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGMVACod_Enabled), 5, 0), true);
         edtAGMVAFec_Enabled = 0;
         AssignProp("", false, edtAGMVAFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGMVAFec_Enabled), 5, 0), true);
         edtAGPedCod_Enabled = 0;
         AssignProp("", false, edtAGPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGPedCod_Enabled), 5, 0), true);
         edtAGCliCod_Enabled = 0;
         AssignProp("", false, edtAGCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGCliCod_Enabled), 5, 0), true);
         edtAGCliDsc_Enabled = 0;
         AssignProp("", false, edtAGCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGCliDsc_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtAGMVADCant_Enabled = 0;
         AssignProp("", false, edtAGMVADCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGMVADCant_Enabled), 5, 0), true);
         edtAGMVADCantF_Enabled = 0;
         AssignProp("", false, edtAGMVADCantF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGMVADCantF_Enabled), 5, 0), true);
         edtAGMVADCantP_Enabled = 0;
         AssignProp("", false, edtAGMVADCantP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAGMVADCantP_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1539( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811465032", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aguiasconsigna.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z26AGMVATip", StringUtil.RTrim( Z26AGMVATip));
         GxWebStd.gx_hidden_field( context, "Z27AGMVACod", StringUtil.RTrim( Z27AGMVACod));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z431AGMVAFec", context.localUtil.DToC( Z431AGMVAFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z432AGPedCod", StringUtil.RTrim( Z432AGPedCod));
         GxWebStd.gx_hidden_field( context, "Z428AGMVADCant", StringUtil.LTrim( StringUtil.NToC( Z428AGMVADCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z429AGMVADCantF", StringUtil.LTrim( StringUtil.NToC( Z429AGMVADCantF, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29AGCliCod", StringUtil.RTrim( Z29AGCliCod));
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
         return formatLink("aguiasconsigna.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AGUIASCONSIGNA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seguimiento de Consignacion" ;
      }

      protected void InitializeNonKey1539( )
      {
         A430AGMVADCantP = 0;
         AssignAttri("", false, "A430AGMVADCantP", StringUtil.LTrimStr( A430AGMVADCantP, 15, 4));
         A431AGMVAFec = DateTime.MinValue;
         AssignAttri("", false, "A431AGMVAFec", context.localUtil.Format(A431AGMVAFec, "99/99/99"));
         A432AGPedCod = "";
         AssignAttri("", false, "A432AGPedCod", A432AGPedCod);
         A29AGCliCod = "";
         AssignAttri("", false, "A29AGCliCod", A29AGCliCod);
         A427AGCliDsc = "";
         AssignAttri("", false, "A427AGCliDsc", A427AGCliDsc);
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A428AGMVADCant = 0;
         AssignAttri("", false, "A428AGMVADCant", StringUtil.LTrimStr( A428AGMVADCant, 15, 4));
         A429AGMVADCantF = 0;
         AssignAttri("", false, "A429AGMVADCantF", StringUtil.LTrimStr( A429AGMVADCantF, 15, 4));
         Z431AGMVAFec = DateTime.MinValue;
         Z432AGPedCod = "";
         Z428AGMVADCant = 0;
         Z429AGMVADCantF = 0;
         Z29AGCliCod = "";
      }

      protected void InitAll1539( )
      {
         A26AGMVATip = "";
         AssignAttri("", false, "A26AGMVATip", A26AGMVATip);
         A27AGMVACod = "";
         AssignAttri("", false, "A27AGMVACod", A27AGMVACod);
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         InitializeNonKey1539( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811465035", true, true);
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
         context.AddJavascriptSource("aguiasconsigna.js", "?202281811465036", false, true);
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
         edtAGMVATip_Internalname = "AGMVATIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAGMVACod_Internalname = "AGMVACOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtAGMVAFec_Internalname = "AGMVAFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAGPedCod_Internalname = "AGPEDCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtAGCliCod_Internalname = "AGCLICOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtAGCliDsc_Internalname = "AGCLIDSC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtProdCod_Internalname = "PRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtAGMVADCant_Internalname = "AGMVADCANT";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtAGMVADCantF_Internalname = "AGMVADCANTF";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtAGMVADCantP_Internalname = "AGMVADCANTP";
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
         Form.Caption = "Seguimiento de Consignacion";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAGMVADCantP_Jsonclick = "";
         edtAGMVADCantP_Enabled = 0;
         edtAGMVADCantF_Jsonclick = "";
         edtAGMVADCantF_Enabled = 1;
         edtAGMVADCant_Jsonclick = "";
         edtAGMVADCant_Enabled = 1;
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         edtAGCliDsc_Jsonclick = "";
         edtAGCliDsc_Enabled = 0;
         edtAGCliCod_Jsonclick = "";
         edtAGCliCod_Enabled = 1;
         edtAGPedCod_Jsonclick = "";
         edtAGPedCod_Enabled = 1;
         edtAGMVAFec_Jsonclick = "";
         edtAGMVAFec_Enabled = 1;
         edtAGMVACod_Jsonclick = "";
         edtAGMVACod_Enabled = 1;
         edtAGMVATip_Jsonclick = "";
         edtAGMVATip_Enabled = 1;
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
         /* Using cursor T001516 */
         pr_default.execute(14, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ProdDsc = T001516_A55ProdDsc[0];
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         pr_default.close(14);
         GX_FocusControl = edtAGMVAFec_Internalname;
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

      public void Valid_Prodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001516 */
         pr_default.execute(14, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         A55ProdDsc = T001516_A55ProdDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A431AGMVAFec", context.localUtil.Format(A431AGMVAFec, "99/99/99"));
         AssignAttri("", false, "A432AGPedCod", StringUtil.RTrim( A432AGPedCod));
         AssignAttri("", false, "A29AGCliCod", StringUtil.RTrim( A29AGCliCod));
         AssignAttri("", false, "A428AGMVADCant", StringUtil.LTrim( StringUtil.NToC( A428AGMVADCant, 15, 4, ".", "")));
         AssignAttri("", false, "A429AGMVADCantF", StringUtil.LTrim( StringUtil.NToC( A429AGMVADCantF, 15, 4, ".", "")));
         AssignAttri("", false, "A427AGCliDsc", StringUtil.RTrim( A427AGCliDsc));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A430AGMVADCantP", StringUtil.LTrim( StringUtil.NToC( A430AGMVADCantP, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z26AGMVATip", StringUtil.RTrim( Z26AGMVATip));
         GxWebStd.gx_hidden_field( context, "Z27AGMVACod", StringUtil.RTrim( Z27AGMVACod));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z431AGMVAFec", context.localUtil.Format(Z431AGMVAFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z432AGPedCod", StringUtil.RTrim( Z432AGPedCod));
         GxWebStd.gx_hidden_field( context, "Z29AGCliCod", StringUtil.RTrim( Z29AGCliCod));
         GxWebStd.gx_hidden_field( context, "Z428AGMVADCant", StringUtil.LTrim( StringUtil.NToC( Z428AGMVADCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z429AGMVADCantF", StringUtil.LTrim( StringUtil.NToC( Z429AGMVADCantF, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z427AGCliDsc", StringUtil.RTrim( Z427AGCliDsc));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z430AGMVADCantP", StringUtil.LTrim( StringUtil.NToC( Z430AGMVADCantP, 15, 4, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Agclicod( )
      {
         /* Using cursor T001515 */
         pr_default.execute(13, new Object[] {A29AGCliCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "AGCLICOD");
            AnyError = 1;
            GX_FocusControl = edtAGCliCod_Internalname;
         }
         A427AGCliDsc = T001515_A427AGCliDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A427AGCliDsc", StringUtil.RTrim( A427AGCliDsc));
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
         setEventMetadata("VALID_AGMVATIP","{handler:'Valid_Agmvatip',iparms:[]");
         setEventMetadata("VALID_AGMVATIP",",oparms:[]}");
         setEventMetadata("VALID_AGMVACOD","{handler:'Valid_Agmvacod',iparms:[]");
         setEventMetadata("VALID_AGMVACOD",",oparms:[]}");
         setEventMetadata("VALID_AGMVAFEC","{handler:'Valid_Agmvafec',iparms:[]");
         setEventMetadata("VALID_AGMVAFEC",",oparms:[]}");
         setEventMetadata("VALID_AGCLICOD","{handler:'Valid_Agclicod',iparms:[{av:'A29AGCliCod',fld:'AGCLICOD',pic:''},{av:'A427AGCliDsc',fld:'AGCLIDSC',pic:''}]");
         setEventMetadata("VALID_AGCLICOD",",oparms:[{av:'A427AGCliDsc',fld:'AGCLIDSC',pic:''}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A26AGMVATip',fld:'AGMVATIP',pic:''},{av:'A27AGMVACod',fld:'AGMVACOD',pic:''},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A431AGMVAFec',fld:'AGMVAFEC',pic:''},{av:'A432AGPedCod',fld:'AGPEDCOD',pic:''},{av:'A29AGCliCod',fld:'AGCLICOD',pic:''},{av:'A428AGMVADCant',fld:'AGMVADCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A429AGMVADCantF',fld:'AGMVADCANTF',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A427AGCliDsc',fld:'AGCLIDSC',pic:''},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A430AGMVADCantP',fld:'AGMVADCANTP',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z26AGMVATip'},{av:'Z27AGMVACod'},{av:'Z28ProdCod'},{av:'Z431AGMVAFec'},{av:'Z432AGPedCod'},{av:'Z29AGCliCod'},{av:'Z428AGMVADCant'},{av:'Z429AGMVADCantF'},{av:'Z427AGCliDsc'},{av:'Z55ProdDsc'},{av:'Z430AGMVADCantP'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_AGMVADCANT","{handler:'Valid_Agmvadcant',iparms:[]");
         setEventMetadata("VALID_AGMVADCANT",",oparms:[]}");
         setEventMetadata("VALID_AGMVADCANTF","{handler:'Valid_Agmvadcantf',iparms:[]");
         setEventMetadata("VALID_AGMVADCANTF",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z26AGMVATip = "";
         Z27AGMVACod = "";
         Z28ProdCod = "";
         Z431AGMVAFec = DateTime.MinValue;
         Z432AGPedCod = "";
         Z29AGCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A29AGCliCod = "";
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
         A26AGMVATip = "";
         lblTextblock2_Jsonclick = "";
         A27AGMVACod = "";
         lblTextblock3_Jsonclick = "";
         A431AGMVAFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         A432AGPedCod = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A427AGCliDsc = "";
         lblTextblock7_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A55ProdDsc = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
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
         Z427AGCliDsc = "";
         Z55ProdDsc = "";
         T00156_A26AGMVATip = new string[] {""} ;
         T00156_A27AGMVACod = new string[] {""} ;
         T00156_A431AGMVAFec = new DateTime[] {DateTime.MinValue} ;
         T00156_A432AGPedCod = new string[] {""} ;
         T00156_A427AGCliDsc = new string[] {""} ;
         T00156_A55ProdDsc = new string[] {""} ;
         T00156_A428AGMVADCant = new decimal[1] ;
         T00156_A429AGMVADCantF = new decimal[1] ;
         T00156_A28ProdCod = new string[] {""} ;
         T00156_A29AGCliCod = new string[] {""} ;
         T00155_A427AGCliDsc = new string[] {""} ;
         T00154_A55ProdDsc = new string[] {""} ;
         T00157_A427AGCliDsc = new string[] {""} ;
         T00158_A55ProdDsc = new string[] {""} ;
         T00159_A26AGMVATip = new string[] {""} ;
         T00159_A27AGMVACod = new string[] {""} ;
         T00159_A28ProdCod = new string[] {""} ;
         T00153_A26AGMVATip = new string[] {""} ;
         T00153_A27AGMVACod = new string[] {""} ;
         T00153_A431AGMVAFec = new DateTime[] {DateTime.MinValue} ;
         T00153_A432AGPedCod = new string[] {""} ;
         T00153_A428AGMVADCant = new decimal[1] ;
         T00153_A429AGMVADCantF = new decimal[1] ;
         T00153_A28ProdCod = new string[] {""} ;
         T00153_A29AGCliCod = new string[] {""} ;
         sMode39 = "";
         T001510_A26AGMVATip = new string[] {""} ;
         T001510_A27AGMVACod = new string[] {""} ;
         T001510_A28ProdCod = new string[] {""} ;
         T001511_A26AGMVATip = new string[] {""} ;
         T001511_A27AGMVACod = new string[] {""} ;
         T001511_A28ProdCod = new string[] {""} ;
         T00152_A26AGMVATip = new string[] {""} ;
         T00152_A27AGMVACod = new string[] {""} ;
         T00152_A431AGMVAFec = new DateTime[] {DateTime.MinValue} ;
         T00152_A432AGPedCod = new string[] {""} ;
         T00152_A428AGMVADCant = new decimal[1] ;
         T00152_A429AGMVADCantF = new decimal[1] ;
         T00152_A28ProdCod = new string[] {""} ;
         T00152_A29AGCliCod = new string[] {""} ;
         T001515_A427AGCliDsc = new string[] {""} ;
         T001516_A55ProdDsc = new string[] {""} ;
         T001517_A26AGMVATip = new string[] {""} ;
         T001517_A27AGMVACod = new string[] {""} ;
         T001517_A28ProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ26AGMVATip = "";
         ZZ27AGMVACod = "";
         ZZ28ProdCod = "";
         ZZ431AGMVAFec = DateTime.MinValue;
         ZZ432AGPedCod = "";
         ZZ29AGCliCod = "";
         ZZ427AGCliDsc = "";
         ZZ55ProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aguiasconsigna__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguiasconsigna__default(),
            new Object[][] {
                new Object[] {
               T00152_A26AGMVATip, T00152_A27AGMVACod, T00152_A431AGMVAFec, T00152_A432AGPedCod, T00152_A428AGMVADCant, T00152_A429AGMVADCantF, T00152_A28ProdCod, T00152_A29AGCliCod
               }
               , new Object[] {
               T00153_A26AGMVATip, T00153_A27AGMVACod, T00153_A431AGMVAFec, T00153_A432AGPedCod, T00153_A428AGMVADCant, T00153_A429AGMVADCantF, T00153_A28ProdCod, T00153_A29AGCliCod
               }
               , new Object[] {
               T00154_A55ProdDsc
               }
               , new Object[] {
               T00155_A427AGCliDsc
               }
               , new Object[] {
               T00156_A26AGMVATip, T00156_A27AGMVACod, T00156_A431AGMVAFec, T00156_A432AGPedCod, T00156_A427AGCliDsc, T00156_A55ProdDsc, T00156_A428AGMVADCant, T00156_A429AGMVADCantF, T00156_A28ProdCod, T00156_A29AGCliCod
               }
               , new Object[] {
               T00157_A427AGCliDsc
               }
               , new Object[] {
               T00158_A55ProdDsc
               }
               , new Object[] {
               T00159_A26AGMVATip, T00159_A27AGMVACod, T00159_A28ProdCod
               }
               , new Object[] {
               T001510_A26AGMVATip, T001510_A27AGMVACod, T001510_A28ProdCod
               }
               , new Object[] {
               T001511_A26AGMVATip, T001511_A27AGMVACod, T001511_A28ProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001515_A427AGCliDsc
               }
               , new Object[] {
               T001516_A55ProdDsc
               }
               , new Object[] {
               T001517_A26AGMVATip, T001517_A27AGMVACod, T001517_A28ProdCod
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
      private short RcdFound39 ;
      private short nIsDirty_39 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAGMVATip_Enabled ;
      private int edtAGMVACod_Enabled ;
      private int edtAGMVAFec_Enabled ;
      private int edtAGPedCod_Enabled ;
      private int edtAGCliCod_Enabled ;
      private int edtAGCliDsc_Enabled ;
      private int edtProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdDsc_Enabled ;
      private int edtAGMVADCant_Enabled ;
      private int edtAGMVADCantF_Enabled ;
      private int edtAGMVADCantP_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z428AGMVADCant ;
      private decimal Z429AGMVADCantF ;
      private decimal A428AGMVADCant ;
      private decimal A429AGMVADCantF ;
      private decimal A430AGMVADCantP ;
      private decimal Z430AGMVADCantP ;
      private decimal ZZ428AGMVADCant ;
      private decimal ZZ429AGMVADCantF ;
      private decimal ZZ430AGMVADCantP ;
      private string sPrefix ;
      private string Z26AGMVATip ;
      private string Z27AGMVACod ;
      private string Z28ProdCod ;
      private string Z432AGPedCod ;
      private string Z29AGCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A29AGCliCod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAGMVATip_Internalname ;
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
      private string A26AGMVATip ;
      private string edtAGMVATip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAGMVACod_Internalname ;
      private string A27AGMVACod ;
      private string edtAGMVACod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtAGMVAFec_Internalname ;
      private string edtAGMVAFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAGPedCod_Internalname ;
      private string A432AGPedCod ;
      private string edtAGPedCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtAGCliCod_Internalname ;
      private string edtAGCliCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtAGCliDsc_Internalname ;
      private string A427AGCliDsc ;
      private string edtAGCliDsc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtProdDsc_Internalname ;
      private string A55ProdDsc ;
      private string edtProdDsc_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtAGMVADCant_Internalname ;
      private string edtAGMVADCant_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtAGMVADCantF_Internalname ;
      private string edtAGMVADCantF_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtAGMVADCantP_Internalname ;
      private string edtAGMVADCantP_Jsonclick ;
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
      private string Z427AGCliDsc ;
      private string Z55ProdDsc ;
      private string sMode39 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ26AGMVATip ;
      private string ZZ27AGMVACod ;
      private string ZZ28ProdCod ;
      private string ZZ432AGPedCod ;
      private string ZZ29AGCliCod ;
      private string ZZ427AGCliDsc ;
      private string ZZ55ProdDsc ;
      private DateTime Z431AGMVAFec ;
      private DateTime A431AGMVAFec ;
      private DateTime ZZ431AGMVAFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00156_A26AGMVATip ;
      private string[] T00156_A27AGMVACod ;
      private DateTime[] T00156_A431AGMVAFec ;
      private string[] T00156_A432AGPedCod ;
      private string[] T00156_A427AGCliDsc ;
      private string[] T00156_A55ProdDsc ;
      private decimal[] T00156_A428AGMVADCant ;
      private decimal[] T00156_A429AGMVADCantF ;
      private string[] T00156_A28ProdCod ;
      private string[] T00156_A29AGCliCod ;
      private string[] T00155_A427AGCliDsc ;
      private string[] T00154_A55ProdDsc ;
      private string[] T00157_A427AGCliDsc ;
      private string[] T00158_A55ProdDsc ;
      private string[] T00159_A26AGMVATip ;
      private string[] T00159_A27AGMVACod ;
      private string[] T00159_A28ProdCod ;
      private string[] T00153_A26AGMVATip ;
      private string[] T00153_A27AGMVACod ;
      private DateTime[] T00153_A431AGMVAFec ;
      private string[] T00153_A432AGPedCod ;
      private decimal[] T00153_A428AGMVADCant ;
      private decimal[] T00153_A429AGMVADCantF ;
      private string[] T00153_A28ProdCod ;
      private string[] T00153_A29AGCliCod ;
      private string[] T001510_A26AGMVATip ;
      private string[] T001510_A27AGMVACod ;
      private string[] T001510_A28ProdCod ;
      private string[] T001511_A26AGMVATip ;
      private string[] T001511_A27AGMVACod ;
      private string[] T001511_A28ProdCod ;
      private string[] T00152_A26AGMVATip ;
      private string[] T00152_A27AGMVACod ;
      private DateTime[] T00152_A431AGMVAFec ;
      private string[] T00152_A432AGPedCod ;
      private decimal[] T00152_A428AGMVADCant ;
      private decimal[] T00152_A429AGMVADCantF ;
      private string[] T00152_A28ProdCod ;
      private string[] T00152_A29AGCliCod ;
      private string[] T001515_A427AGCliDsc ;
      private string[] T001516_A55ProdDsc ;
      private string[] T001517_A26AGMVATip ;
      private string[] T001517_A27AGMVACod ;
      private string[] T001517_A28ProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aguiasconsigna__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aguiasconsigna__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00156;
        prmT00156 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00155;
        prmT00155 = new Object[] {
        new ParDef("@AGCliCod",GXType.NChar,20,0)
        };
        Object[] prmT00154;
        prmT00154 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00157;
        prmT00157 = new Object[] {
        new ParDef("@AGCliCod",GXType.NChar,20,0)
        };
        Object[] prmT00158;
        prmT00158 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00159;
        prmT00159 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00153;
        prmT00153 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001510;
        prmT001510 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001511;
        prmT001511 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00152;
        prmT00152 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001512;
        prmT001512 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@AGMVAFec",GXType.Date,8,0) ,
        new ParDef("@AGPedCod",GXType.NChar,10,0) ,
        new ParDef("@AGMVADCant",GXType.Decimal,15,4) ,
        new ParDef("@AGMVADCantF",GXType.Decimal,15,4) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@AGCliCod",GXType.NChar,20,0)
        };
        Object[] prmT001513;
        prmT001513 = new Object[] {
        new ParDef("@AGMVAFec",GXType.Date,8,0) ,
        new ParDef("@AGPedCod",GXType.NChar,10,0) ,
        new ParDef("@AGMVADCant",GXType.Decimal,15,4) ,
        new ParDef("@AGMVADCantF",GXType.Decimal,15,4) ,
        new ParDef("@AGCliCod",GXType.NChar,20,0) ,
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001514;
        prmT001514 = new Object[] {
        new ParDef("@AGMVATip",GXType.NChar,3,0) ,
        new ParDef("@AGMVACod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001517;
        prmT001517 = new Object[] {
        };
        Object[] prmT001516;
        prmT001516 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001515;
        prmT001515 = new Object[] {
        new ParDef("@AGCliCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00152", "SELECT [AGMVATip], [AGMVACod], [AGMVAFec], [AGPedCod], [AGMVADCant], [AGMVADCantF], [ProdCod], [AGCliCod] AS AGCliCod FROM [AGUIASCONSIGNA] WITH (UPDLOCK) WHERE [AGMVATip] = @AGMVATip AND [AGMVACod] = @AGMVACod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00153", "SELECT [AGMVATip], [AGMVACod], [AGMVAFec], [AGPedCod], [AGMVADCant], [AGMVADCantF], [ProdCod], [AGCliCod] AS AGCliCod FROM [AGUIASCONSIGNA] WHERE [AGMVATip] = @AGMVATip AND [AGMVACod] = @AGMVACod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00154", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00155", "SELECT [CliDsc] AS AGCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @AGCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00156", "SELECT TM1.[AGMVATip], TM1.[AGMVACod], TM1.[AGMVAFec], TM1.[AGPedCod], T2.[CliDsc] AS AGCliDsc, T3.[ProdDsc], TM1.[AGMVADCant], TM1.[AGMVADCantF], TM1.[ProdCod], TM1.[AGCliCod] AS AGCliCod FROM (([AGUIASCONSIGNA] TM1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = TM1.[AGCliCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = TM1.[ProdCod]) WHERE TM1.[AGMVATip] = @AGMVATip and TM1.[AGMVACod] = @AGMVACod and TM1.[ProdCod] = @ProdCod ORDER BY TM1.[AGMVATip], TM1.[AGMVACod], TM1.[ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00157", "SELECT [CliDsc] AS AGCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @AGCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00158", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00159", "SELECT [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE [AGMVATip] = @AGMVATip AND [AGMVACod] = @AGMVACod AND [ProdCod] = @ProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00159,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001510", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE ( [AGMVATip] > @AGMVATip or [AGMVATip] = @AGMVATip and [AGMVACod] > @AGMVACod or [AGMVACod] = @AGMVACod and [AGMVATip] = @AGMVATip and [ProdCod] > @ProdCod) ORDER BY [AGMVATip], [AGMVACod], [ProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001510,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001511", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE ( [AGMVATip] < @AGMVATip or [AGMVATip] = @AGMVATip and [AGMVACod] < @AGMVACod or [AGMVACod] = @AGMVACod and [AGMVATip] = @AGMVATip and [ProdCod] < @ProdCod) ORDER BY [AGMVATip] DESC, [AGMVACod] DESC, [ProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001512", "INSERT INTO [AGUIASCONSIGNA]([AGMVATip], [AGMVACod], [AGMVAFec], [AGPedCod], [AGMVADCant], [AGMVADCantF], [ProdCod], [AGCliCod]) VALUES(@AGMVATip, @AGMVACod, @AGMVAFec, @AGPedCod, @AGMVADCant, @AGMVADCantF, @ProdCod, @AGCliCod)", GxErrorMask.GX_NOMASK,prmT001512)
           ,new CursorDef("T001513", "UPDATE [AGUIASCONSIGNA] SET [AGMVAFec]=@AGMVAFec, [AGPedCod]=@AGPedCod, [AGMVADCant]=@AGMVADCant, [AGMVADCantF]=@AGMVADCantF, [AGCliCod]=@AGCliCod  WHERE [AGMVATip] = @AGMVATip AND [AGMVACod] = @AGMVACod AND [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001513)
           ,new CursorDef("T001514", "DELETE FROM [AGUIASCONSIGNA]  WHERE [AGMVATip] = @AGMVATip AND [AGMVACod] = @AGMVACod AND [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001514)
           ,new CursorDef("T001515", "SELECT [CliDsc] AS AGCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @AGCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001515,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001516", "SELECT [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001516,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001517", "SELECT [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] ORDER BY [AGMVATip], [AGMVACod], [ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001517,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
     }
  }

}

}
