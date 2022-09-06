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
   public class cpalmacenvsconta : GXDataArea
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
            Form.Meta.addItem("description", "Reporte de Almacen vs Contabilidad", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVSItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpalmacenvsconta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpalmacenvsconta( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPALMACENVSCONTA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Item", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A237VSItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtVSItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A237VSItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A237VSItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVSFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVSFecha_Internalname, context.localUtil.Format(A2087VSFecha, "99/99/99"), context.localUtil.Format( A2087VSFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPALMACENVSCONTA.htm");
         GxWebStd.gx_bitmap( context, edtVSFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVSFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "N° Orden", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSOrdCod_Internalname, StringUtil.RTrim( A2089VSOrdCod), StringUtil.RTrim( context.localUtil.Format( A2089VSOrdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSOrdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSOrdCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "N° Ingreso", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSMVACod_Internalname, StringUtil.RTrim( A2088VSMVACod), StringUtil.RTrim( context.localUtil.Format( A2088VSMVACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSMVACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSMVACod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Producto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSProdCod_Internalname, StringUtil.RTrim( A2090VSProdCod), StringUtil.RTrim( context.localUtil.Format( A2090VSProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Descripcion producto", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSProdDsc_Internalname, A2091VSProdDsc, StringUtil.RTrim( context.localUtil.Format( A2091VSProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "T/D", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSTipCod_Internalname, StringUtil.RTrim( A2092VSTipCod), StringUtil.RTrim( context.localUtil.Format( A2092VSTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSTipCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "N° Documento", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSDocNum_Internalname, StringUtil.RTrim( A2086VSDocNum), StringUtil.RTrim( context.localUtil.Format( A2086VSDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSDocNum_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cantidad Ingresada", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSCantIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A2083VSCantIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtVSCantIng_Enabled!=0) ? context.localUtil.Format( A2083VSCantIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2083VSCantIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSCantIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSCantIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Costo Ingresado", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSCostoIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A2085VSCostoIng, 17, 2, ".", "")), StringUtil.LTrim( ((edtVSCostoIng_Enabled!=0) ? context.localUtil.Format( A2085VSCostoIng, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2085VSCostoIng, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSCostoIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSCostoIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Cantidad Facturada", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSCantFac_Internalname, StringUtil.LTrim( StringUtil.NToC( A2082VSCantFac, 17, 4, ".", "")), StringUtil.LTrim( ((edtVSCantFac_Enabled!=0) ? context.localUtil.Format( A2082VSCantFac, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2082VSCantFac, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSCantFac_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSCantFac_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Costo Facturado", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSCostoFac_Internalname, StringUtil.LTrim( StringUtil.NToC( A2084VSCostoFac, 17, 2, ".", "")), StringUtil.LTrim( ((edtVSCostoFac_Enabled!=0) ? context.localUtil.Format( A2084VSCostoFac, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2084VSCostoFac, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSCostoFac_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSCostoFac_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Tipo de Movimiento", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVSTipMov_Internalname, A2093VSTipMov, StringUtil.RTrim( context.localUtil.Format( A2093VSTipMov, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVSTipMov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVSTipMov_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPALMACENVSCONTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPALMACENVSCONTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPALMACENVSCONTA.htm");
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
            Z237VSItem = (long)(context.localUtil.CToN( cgiGet( "Z237VSItem"), ".", ","));
            Z2087VSFecha = context.localUtil.CToD( cgiGet( "Z2087VSFecha"), 0);
            Z2089VSOrdCod = cgiGet( "Z2089VSOrdCod");
            Z2088VSMVACod = cgiGet( "Z2088VSMVACod");
            Z2090VSProdCod = cgiGet( "Z2090VSProdCod");
            Z2091VSProdDsc = cgiGet( "Z2091VSProdDsc");
            Z2092VSTipCod = cgiGet( "Z2092VSTipCod");
            Z2086VSDocNum = cgiGet( "Z2086VSDocNum");
            Z2083VSCantIng = context.localUtil.CToN( cgiGet( "Z2083VSCantIng"), ".", ",");
            Z2085VSCostoIng = context.localUtil.CToN( cgiGet( "Z2085VSCostoIng"), ".", ",");
            Z2082VSCantFac = context.localUtil.CToN( cgiGet( "Z2082VSCantFac"), ".", ",");
            Z2084VSCostoFac = context.localUtil.CToN( cgiGet( "Z2084VSCostoFac"), ".", ",");
            Z2093VSTipMov = cgiGet( "Z2093VSTipMov");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtVSItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVSItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VSITEM");
               AnyError = 1;
               GX_FocusControl = edtVSItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A237VSItem = 0;
               AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
            }
            else
            {
               A237VSItem = (long)(context.localUtil.CToN( cgiGet( edtVSItem_Internalname), ".", ","));
               AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtVSFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "VSFECHA");
               AnyError = 1;
               GX_FocusControl = edtVSFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2087VSFecha = DateTime.MinValue;
               AssignAttri("", false, "A2087VSFecha", context.localUtil.Format(A2087VSFecha, "99/99/99"));
            }
            else
            {
               A2087VSFecha = context.localUtil.CToD( cgiGet( edtVSFecha_Internalname), 2);
               AssignAttri("", false, "A2087VSFecha", context.localUtil.Format(A2087VSFecha, "99/99/99"));
            }
            A2089VSOrdCod = cgiGet( edtVSOrdCod_Internalname);
            AssignAttri("", false, "A2089VSOrdCod", A2089VSOrdCod);
            A2088VSMVACod = cgiGet( edtVSMVACod_Internalname);
            AssignAttri("", false, "A2088VSMVACod", A2088VSMVACod);
            A2090VSProdCod = cgiGet( edtVSProdCod_Internalname);
            AssignAttri("", false, "A2090VSProdCod", A2090VSProdCod);
            A2091VSProdDsc = cgiGet( edtVSProdDsc_Internalname);
            AssignAttri("", false, "A2091VSProdDsc", A2091VSProdDsc);
            A2092VSTipCod = cgiGet( edtVSTipCod_Internalname);
            AssignAttri("", false, "A2092VSTipCod", A2092VSTipCod);
            A2086VSDocNum = cgiGet( edtVSDocNum_Internalname);
            AssignAttri("", false, "A2086VSDocNum", A2086VSDocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVSCantIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVSCantIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VSCANTING");
               AnyError = 1;
               GX_FocusControl = edtVSCantIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2083VSCantIng = 0;
               AssignAttri("", false, "A2083VSCantIng", StringUtil.LTrimStr( A2083VSCantIng, 15, 4));
            }
            else
            {
               A2083VSCantIng = context.localUtil.CToN( cgiGet( edtVSCantIng_Internalname), ".", ",");
               AssignAttri("", false, "A2083VSCantIng", StringUtil.LTrimStr( A2083VSCantIng, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVSCostoIng_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVSCostoIng_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VSCOSTOING");
               AnyError = 1;
               GX_FocusControl = edtVSCostoIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2085VSCostoIng = 0;
               AssignAttri("", false, "A2085VSCostoIng", StringUtil.LTrimStr( A2085VSCostoIng, 15, 2));
            }
            else
            {
               A2085VSCostoIng = context.localUtil.CToN( cgiGet( edtVSCostoIng_Internalname), ".", ",");
               AssignAttri("", false, "A2085VSCostoIng", StringUtil.LTrimStr( A2085VSCostoIng, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVSCantFac_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVSCantFac_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VSCANTFAC");
               AnyError = 1;
               GX_FocusControl = edtVSCantFac_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2082VSCantFac = 0;
               AssignAttri("", false, "A2082VSCantFac", StringUtil.LTrimStr( A2082VSCantFac, 15, 4));
            }
            else
            {
               A2082VSCantFac = context.localUtil.CToN( cgiGet( edtVSCantFac_Internalname), ".", ",");
               AssignAttri("", false, "A2082VSCantFac", StringUtil.LTrimStr( A2082VSCantFac, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVSCostoFac_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVSCostoFac_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VSCOSTOFAC");
               AnyError = 1;
               GX_FocusControl = edtVSCostoFac_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2084VSCostoFac = 0;
               AssignAttri("", false, "A2084VSCostoFac", StringUtil.LTrimStr( A2084VSCostoFac, 15, 2));
            }
            else
            {
               A2084VSCostoFac = context.localUtil.CToN( cgiGet( edtVSCostoFac_Internalname), ".", ",");
               AssignAttri("", false, "A2084VSCostoFac", StringUtil.LTrimStr( A2084VSCostoFac, 15, 2));
            }
            A2093VSTipMov = cgiGet( edtVSTipMov_Internalname);
            AssignAttri("", false, "A2093VSTipMov", A2093VSTipMov);
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
               A237VSItem = (long)(NumberUtil.Val( GetPar( "VSItem"), "."));
               AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
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
               InitAll35108( ) ;
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
         DisableAttributes35108( ) ;
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

      protected void CONFIRM_350( )
      {
         BeforeValidate35108( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls35108( ) ;
            }
            else
            {
               CheckExtendedTable35108( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors35108( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues350( ) ;
         }
      }

      protected void ResetCaption350( )
      {
      }

      protected void ZM35108( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2087VSFecha = T00353_A2087VSFecha[0];
               Z2089VSOrdCod = T00353_A2089VSOrdCod[0];
               Z2088VSMVACod = T00353_A2088VSMVACod[0];
               Z2090VSProdCod = T00353_A2090VSProdCod[0];
               Z2091VSProdDsc = T00353_A2091VSProdDsc[0];
               Z2092VSTipCod = T00353_A2092VSTipCod[0];
               Z2086VSDocNum = T00353_A2086VSDocNum[0];
               Z2083VSCantIng = T00353_A2083VSCantIng[0];
               Z2085VSCostoIng = T00353_A2085VSCostoIng[0];
               Z2082VSCantFac = T00353_A2082VSCantFac[0];
               Z2084VSCostoFac = T00353_A2084VSCostoFac[0];
               Z2093VSTipMov = T00353_A2093VSTipMov[0];
            }
            else
            {
               Z2087VSFecha = A2087VSFecha;
               Z2089VSOrdCod = A2089VSOrdCod;
               Z2088VSMVACod = A2088VSMVACod;
               Z2090VSProdCod = A2090VSProdCod;
               Z2091VSProdDsc = A2091VSProdDsc;
               Z2092VSTipCod = A2092VSTipCod;
               Z2086VSDocNum = A2086VSDocNum;
               Z2083VSCantIng = A2083VSCantIng;
               Z2085VSCostoIng = A2085VSCostoIng;
               Z2082VSCantFac = A2082VSCantFac;
               Z2084VSCostoFac = A2084VSCostoFac;
               Z2093VSTipMov = A2093VSTipMov;
            }
         }
         if ( GX_JID == -2 )
         {
            Z237VSItem = A237VSItem;
            Z2087VSFecha = A2087VSFecha;
            Z2089VSOrdCod = A2089VSOrdCod;
            Z2088VSMVACod = A2088VSMVACod;
            Z2090VSProdCod = A2090VSProdCod;
            Z2091VSProdDsc = A2091VSProdDsc;
            Z2092VSTipCod = A2092VSTipCod;
            Z2086VSDocNum = A2086VSDocNum;
            Z2083VSCantIng = A2083VSCantIng;
            Z2085VSCostoIng = A2085VSCostoIng;
            Z2082VSCantFac = A2082VSCantFac;
            Z2084VSCostoFac = A2084VSCostoFac;
            Z2093VSTipMov = A2093VSTipMov;
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

      protected void Load35108( )
      {
         /* Using cursor T00354 */
         pr_default.execute(2, new Object[] {A237VSItem});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound108 = 1;
            A2087VSFecha = T00354_A2087VSFecha[0];
            AssignAttri("", false, "A2087VSFecha", context.localUtil.Format(A2087VSFecha, "99/99/99"));
            A2089VSOrdCod = T00354_A2089VSOrdCod[0];
            AssignAttri("", false, "A2089VSOrdCod", A2089VSOrdCod);
            A2088VSMVACod = T00354_A2088VSMVACod[0];
            AssignAttri("", false, "A2088VSMVACod", A2088VSMVACod);
            A2090VSProdCod = T00354_A2090VSProdCod[0];
            AssignAttri("", false, "A2090VSProdCod", A2090VSProdCod);
            A2091VSProdDsc = T00354_A2091VSProdDsc[0];
            AssignAttri("", false, "A2091VSProdDsc", A2091VSProdDsc);
            A2092VSTipCod = T00354_A2092VSTipCod[0];
            AssignAttri("", false, "A2092VSTipCod", A2092VSTipCod);
            A2086VSDocNum = T00354_A2086VSDocNum[0];
            AssignAttri("", false, "A2086VSDocNum", A2086VSDocNum);
            A2083VSCantIng = T00354_A2083VSCantIng[0];
            AssignAttri("", false, "A2083VSCantIng", StringUtil.LTrimStr( A2083VSCantIng, 15, 4));
            A2085VSCostoIng = T00354_A2085VSCostoIng[0];
            AssignAttri("", false, "A2085VSCostoIng", StringUtil.LTrimStr( A2085VSCostoIng, 15, 2));
            A2082VSCantFac = T00354_A2082VSCantFac[0];
            AssignAttri("", false, "A2082VSCantFac", StringUtil.LTrimStr( A2082VSCantFac, 15, 4));
            A2084VSCostoFac = T00354_A2084VSCostoFac[0];
            AssignAttri("", false, "A2084VSCostoFac", StringUtil.LTrimStr( A2084VSCostoFac, 15, 2));
            A2093VSTipMov = T00354_A2093VSTipMov[0];
            AssignAttri("", false, "A2093VSTipMov", A2093VSTipMov);
            ZM35108( -2) ;
         }
         pr_default.close(2);
         OnLoadActions35108( ) ;
      }

      protected void OnLoadActions35108( )
      {
      }

      protected void CheckExtendedTable35108( )
      {
         nIsDirty_108 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2087VSFecha) || ( DateTimeUtil.ResetTime ( A2087VSFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "VSFECHA");
            AnyError = 1;
            GX_FocusControl = edtVSFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors35108( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey35108( )
      {
         /* Using cursor T00355 */
         pr_default.execute(3, new Object[] {A237VSItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound108 = 1;
         }
         else
         {
            RcdFound108 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00353 */
         pr_default.execute(1, new Object[] {A237VSItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM35108( 2) ;
            RcdFound108 = 1;
            A237VSItem = T00353_A237VSItem[0];
            AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
            A2087VSFecha = T00353_A2087VSFecha[0];
            AssignAttri("", false, "A2087VSFecha", context.localUtil.Format(A2087VSFecha, "99/99/99"));
            A2089VSOrdCod = T00353_A2089VSOrdCod[0];
            AssignAttri("", false, "A2089VSOrdCod", A2089VSOrdCod);
            A2088VSMVACod = T00353_A2088VSMVACod[0];
            AssignAttri("", false, "A2088VSMVACod", A2088VSMVACod);
            A2090VSProdCod = T00353_A2090VSProdCod[0];
            AssignAttri("", false, "A2090VSProdCod", A2090VSProdCod);
            A2091VSProdDsc = T00353_A2091VSProdDsc[0];
            AssignAttri("", false, "A2091VSProdDsc", A2091VSProdDsc);
            A2092VSTipCod = T00353_A2092VSTipCod[0];
            AssignAttri("", false, "A2092VSTipCod", A2092VSTipCod);
            A2086VSDocNum = T00353_A2086VSDocNum[0];
            AssignAttri("", false, "A2086VSDocNum", A2086VSDocNum);
            A2083VSCantIng = T00353_A2083VSCantIng[0];
            AssignAttri("", false, "A2083VSCantIng", StringUtil.LTrimStr( A2083VSCantIng, 15, 4));
            A2085VSCostoIng = T00353_A2085VSCostoIng[0];
            AssignAttri("", false, "A2085VSCostoIng", StringUtil.LTrimStr( A2085VSCostoIng, 15, 2));
            A2082VSCantFac = T00353_A2082VSCantFac[0];
            AssignAttri("", false, "A2082VSCantFac", StringUtil.LTrimStr( A2082VSCantFac, 15, 4));
            A2084VSCostoFac = T00353_A2084VSCostoFac[0];
            AssignAttri("", false, "A2084VSCostoFac", StringUtil.LTrimStr( A2084VSCostoFac, 15, 2));
            A2093VSTipMov = T00353_A2093VSTipMov[0];
            AssignAttri("", false, "A2093VSTipMov", A2093VSTipMov);
            Z237VSItem = A237VSItem;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load35108( ) ;
            if ( AnyError == 1 )
            {
               RcdFound108 = 0;
               InitializeNonKey35108( ) ;
            }
            Gx_mode = sMode108;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound108 = 0;
            InitializeNonKey35108( ) ;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode108;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey35108( ) ;
         if ( RcdFound108 == 0 )
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
         RcdFound108 = 0;
         /* Using cursor T00356 */
         pr_default.execute(4, new Object[] {A237VSItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00356_A237VSItem[0] < A237VSItem ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00356_A237VSItem[0] > A237VSItem ) ) )
            {
               A237VSItem = T00356_A237VSItem[0];
               AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
               RcdFound108 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound108 = 0;
         /* Using cursor T00357 */
         pr_default.execute(5, new Object[] {A237VSItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00357_A237VSItem[0] > A237VSItem ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00357_A237VSItem[0] < A237VSItem ) ) )
            {
               A237VSItem = T00357_A237VSItem[0];
               AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
               RcdFound108 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey35108( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVSItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert35108( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound108 == 1 )
            {
               if ( A237VSItem != Z237VSItem )
               {
                  A237VSItem = Z237VSItem;
                  AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VSITEM");
                  AnyError = 1;
                  GX_FocusControl = edtVSItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVSItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update35108( ) ;
                  GX_FocusControl = edtVSItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A237VSItem != Z237VSItem )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtVSItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert35108( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VSITEM");
                     AnyError = 1;
                     GX_FocusControl = edtVSItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtVSItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert35108( ) ;
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
         if ( A237VSItem != Z237VSItem )
         {
            A237VSItem = Z237VSItem;
            AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VSITEM");
            AnyError = 1;
            GX_FocusControl = edtVSItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVSItem_Internalname;
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
         GetKey35108( ) ;
         if ( RcdFound108 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "VSITEM");
               AnyError = 1;
               GX_FocusControl = edtVSItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A237VSItem != Z237VSItem )
            {
               A237VSItem = Z237VSItem;
               AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "VSITEM");
               AnyError = 1;
               GX_FocusControl = edtVSItem_Internalname;
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
            if ( A237VSItem != Z237VSItem )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VSITEM");
                  AnyError = 1;
                  GX_FocusControl = edtVSItem_Internalname;
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
         context.RollbackDataStores("cpalmacenvsconta",pr_default);
         GX_FocusControl = edtVSFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_350( ) ;
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
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VSITEM");
            AnyError = 1;
            GX_FocusControl = edtVSItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtVSFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart35108( ) ;
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVSFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd35108( ) ;
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
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVSFecha_Internalname;
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
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVSFecha_Internalname;
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
         ScanStart35108( ) ;
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound108 != 0 )
            {
               ScanNext35108( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVSFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd35108( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency35108( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00352 */
            pr_default.execute(0, new Object[] {A237VSItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPALMACENVSCONTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2087VSFecha ) != DateTimeUtil.ResetTime ( T00352_A2087VSFecha[0] ) ) || ( StringUtil.StrCmp(Z2089VSOrdCod, T00352_A2089VSOrdCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2088VSMVACod, T00352_A2088VSMVACod[0]) != 0 ) || ( StringUtil.StrCmp(Z2090VSProdCod, T00352_A2090VSProdCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2091VSProdDsc, T00352_A2091VSProdDsc[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2092VSTipCod, T00352_A2092VSTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2086VSDocNum, T00352_A2086VSDocNum[0]) != 0 ) || ( Z2083VSCantIng != T00352_A2083VSCantIng[0] ) || ( Z2085VSCostoIng != T00352_A2085VSCostoIng[0] ) || ( Z2082VSCantFac != T00352_A2082VSCantFac[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2084VSCostoFac != T00352_A2084VSCostoFac[0] ) || ( StringUtil.StrCmp(Z2093VSTipMov, T00352_A2093VSTipMov[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2087VSFecha ) != DateTimeUtil.ResetTime ( T00352_A2087VSFecha[0] ) )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSFecha");
                  GXUtil.WriteLogRaw("Old: ",Z2087VSFecha);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2087VSFecha[0]);
               }
               if ( StringUtil.StrCmp(Z2089VSOrdCod, T00352_A2089VSOrdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSOrdCod");
                  GXUtil.WriteLogRaw("Old: ",Z2089VSOrdCod);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2089VSOrdCod[0]);
               }
               if ( StringUtil.StrCmp(Z2088VSMVACod, T00352_A2088VSMVACod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSMVACod");
                  GXUtil.WriteLogRaw("Old: ",Z2088VSMVACod);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2088VSMVACod[0]);
               }
               if ( StringUtil.StrCmp(Z2090VSProdCod, T00352_A2090VSProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z2090VSProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2090VSProdCod[0]);
               }
               if ( StringUtil.StrCmp(Z2091VSProdDsc, T00352_A2091VSProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2091VSProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2091VSProdDsc[0]);
               }
               if ( StringUtil.StrCmp(Z2092VSTipCod, T00352_A2092VSTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z2092VSTipCod);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2092VSTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z2086VSDocNum, T00352_A2086VSDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z2086VSDocNum);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2086VSDocNum[0]);
               }
               if ( Z2083VSCantIng != T00352_A2083VSCantIng[0] )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSCantIng");
                  GXUtil.WriteLogRaw("Old: ",Z2083VSCantIng);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2083VSCantIng[0]);
               }
               if ( Z2085VSCostoIng != T00352_A2085VSCostoIng[0] )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSCostoIng");
                  GXUtil.WriteLogRaw("Old: ",Z2085VSCostoIng);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2085VSCostoIng[0]);
               }
               if ( Z2082VSCantFac != T00352_A2082VSCantFac[0] )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSCantFac");
                  GXUtil.WriteLogRaw("Old: ",Z2082VSCantFac);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2082VSCantFac[0]);
               }
               if ( Z2084VSCostoFac != T00352_A2084VSCostoFac[0] )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSCostoFac");
                  GXUtil.WriteLogRaw("Old: ",Z2084VSCostoFac);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2084VSCostoFac[0]);
               }
               if ( StringUtil.StrCmp(Z2093VSTipMov, T00352_A2093VSTipMov[0]) != 0 )
               {
                  GXUtil.WriteLog("cpalmacenvsconta:[seudo value changed for attri]"+"VSTipMov");
                  GXUtil.WriteLogRaw("Old: ",Z2093VSTipMov);
                  GXUtil.WriteLogRaw("Current: ",T00352_A2093VSTipMov[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPALMACENVSCONTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert35108( )
      {
         BeforeValidate35108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable35108( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM35108( 0) ;
            CheckOptimisticConcurrency35108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm35108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert35108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00358 */
                     pr_default.execute(6, new Object[] {A237VSItem, A2087VSFecha, A2089VSOrdCod, A2088VSMVACod, A2090VSProdCod, A2091VSProdDsc, A2092VSTipCod, A2086VSDocNum, A2083VSCantIng, A2085VSCostoIng, A2082VSCantFac, A2084VSCostoFac, A2093VSTipMov});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption350( ) ;
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
               Load35108( ) ;
            }
            EndLevel35108( ) ;
         }
         CloseExtendedTableCursors35108( ) ;
      }

      protected void Update35108( )
      {
         BeforeValidate35108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable35108( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency35108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm35108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate35108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00359 */
                     pr_default.execute(7, new Object[] {A2087VSFecha, A2089VSOrdCod, A2088VSMVACod, A2090VSProdCod, A2091VSProdDsc, A2092VSTipCod, A2086VSDocNum, A2083VSCantIng, A2085VSCostoIng, A2082VSCantFac, A2084VSCostoFac, A2093VSTipMov, A237VSItem});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPALMACENVSCONTA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate35108( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption350( ) ;
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
            EndLevel35108( ) ;
         }
         CloseExtendedTableCursors35108( ) ;
      }

      protected void DeferredUpdate35108( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate35108( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency35108( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls35108( ) ;
            AfterConfirm35108( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete35108( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003510 */
                  pr_default.execute(8, new Object[] {A237VSItem});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound108 == 0 )
                        {
                           InitAll35108( ) ;
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
                        ResetCaption350( ) ;
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
         sMode108 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel35108( ) ;
         Gx_mode = sMode108;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls35108( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel35108( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete35108( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpalmacenvsconta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues350( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpalmacenvsconta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart35108( )
      {
         /* Using cursor T003511 */
         pr_default.execute(9);
         RcdFound108 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound108 = 1;
            A237VSItem = T003511_A237VSItem[0];
            AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext35108( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound108 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound108 = 1;
            A237VSItem = T003511_A237VSItem[0];
            AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
         }
      }

      protected void ScanEnd35108( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm35108( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert35108( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate35108( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete35108( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete35108( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate35108( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes35108( )
      {
         edtVSItem_Enabled = 0;
         AssignProp("", false, edtVSItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSItem_Enabled), 5, 0), true);
         edtVSFecha_Enabled = 0;
         AssignProp("", false, edtVSFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSFecha_Enabled), 5, 0), true);
         edtVSOrdCod_Enabled = 0;
         AssignProp("", false, edtVSOrdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSOrdCod_Enabled), 5, 0), true);
         edtVSMVACod_Enabled = 0;
         AssignProp("", false, edtVSMVACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSMVACod_Enabled), 5, 0), true);
         edtVSProdCod_Enabled = 0;
         AssignProp("", false, edtVSProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSProdCod_Enabled), 5, 0), true);
         edtVSProdDsc_Enabled = 0;
         AssignProp("", false, edtVSProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSProdDsc_Enabled), 5, 0), true);
         edtVSTipCod_Enabled = 0;
         AssignProp("", false, edtVSTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSTipCod_Enabled), 5, 0), true);
         edtVSDocNum_Enabled = 0;
         AssignProp("", false, edtVSDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSDocNum_Enabled), 5, 0), true);
         edtVSCantIng_Enabled = 0;
         AssignProp("", false, edtVSCantIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSCantIng_Enabled), 5, 0), true);
         edtVSCostoIng_Enabled = 0;
         AssignProp("", false, edtVSCostoIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSCostoIng_Enabled), 5, 0), true);
         edtVSCantFac_Enabled = 0;
         AssignProp("", false, edtVSCantFac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSCantFac_Enabled), 5, 0), true);
         edtVSCostoFac_Enabled = 0;
         AssignProp("", false, edtVSCostoFac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSCostoFac_Enabled), 5, 0), true);
         edtVSTipMov_Enabled = 0;
         AssignProp("", false, edtVSTipMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVSTipMov_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes35108( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues350( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245552", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpalmacenvsconta.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z237VSItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237VSItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2087VSFecha", context.localUtil.DToC( Z2087VSFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2089VSOrdCod", StringUtil.RTrim( Z2089VSOrdCod));
         GxWebStd.gx_hidden_field( context, "Z2088VSMVACod", StringUtil.RTrim( Z2088VSMVACod));
         GxWebStd.gx_hidden_field( context, "Z2090VSProdCod", StringUtil.RTrim( Z2090VSProdCod));
         GxWebStd.gx_hidden_field( context, "Z2091VSProdDsc", Z2091VSProdDsc);
         GxWebStd.gx_hidden_field( context, "Z2092VSTipCod", StringUtil.RTrim( Z2092VSTipCod));
         GxWebStd.gx_hidden_field( context, "Z2086VSDocNum", StringUtil.RTrim( Z2086VSDocNum));
         GxWebStd.gx_hidden_field( context, "Z2083VSCantIng", StringUtil.LTrim( StringUtil.NToC( Z2083VSCantIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2085VSCostoIng", StringUtil.LTrim( StringUtil.NToC( Z2085VSCostoIng, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2082VSCantFac", StringUtil.LTrim( StringUtil.NToC( Z2082VSCantFac, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2084VSCostoFac", StringUtil.LTrim( StringUtil.NToC( Z2084VSCostoFac, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2093VSTipMov", Z2093VSTipMov);
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
         return formatLink("cpalmacenvsconta.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPALMACENVSCONTA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reporte de Almacen vs Contabilidad" ;
      }

      protected void InitializeNonKey35108( )
      {
         A2087VSFecha = DateTime.MinValue;
         AssignAttri("", false, "A2087VSFecha", context.localUtil.Format(A2087VSFecha, "99/99/99"));
         A2089VSOrdCod = "";
         AssignAttri("", false, "A2089VSOrdCod", A2089VSOrdCod);
         A2088VSMVACod = "";
         AssignAttri("", false, "A2088VSMVACod", A2088VSMVACod);
         A2090VSProdCod = "";
         AssignAttri("", false, "A2090VSProdCod", A2090VSProdCod);
         A2091VSProdDsc = "";
         AssignAttri("", false, "A2091VSProdDsc", A2091VSProdDsc);
         A2092VSTipCod = "";
         AssignAttri("", false, "A2092VSTipCod", A2092VSTipCod);
         A2086VSDocNum = "";
         AssignAttri("", false, "A2086VSDocNum", A2086VSDocNum);
         A2083VSCantIng = 0;
         AssignAttri("", false, "A2083VSCantIng", StringUtil.LTrimStr( A2083VSCantIng, 15, 4));
         A2085VSCostoIng = 0;
         AssignAttri("", false, "A2085VSCostoIng", StringUtil.LTrimStr( A2085VSCostoIng, 15, 2));
         A2082VSCantFac = 0;
         AssignAttri("", false, "A2082VSCantFac", StringUtil.LTrimStr( A2082VSCantFac, 15, 4));
         A2084VSCostoFac = 0;
         AssignAttri("", false, "A2084VSCostoFac", StringUtil.LTrimStr( A2084VSCostoFac, 15, 2));
         A2093VSTipMov = "";
         AssignAttri("", false, "A2093VSTipMov", A2093VSTipMov);
         Z2087VSFecha = DateTime.MinValue;
         Z2089VSOrdCod = "";
         Z2088VSMVACod = "";
         Z2090VSProdCod = "";
         Z2091VSProdDsc = "";
         Z2092VSTipCod = "";
         Z2086VSDocNum = "";
         Z2083VSCantIng = 0;
         Z2085VSCostoIng = 0;
         Z2082VSCantFac = 0;
         Z2084VSCostoFac = 0;
         Z2093VSTipMov = "";
      }

      protected void InitAll35108( )
      {
         A237VSItem = 0;
         AssignAttri("", false, "A237VSItem", StringUtil.LTrimStr( (decimal)(A237VSItem), 10, 0));
         InitializeNonKey35108( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245563", true, true);
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
         context.AddJavascriptSource("cpalmacenvsconta.js", "?202281810245563", false, true);
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
         edtVSItem_Internalname = "VSITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtVSFecha_Internalname = "VSFECHA";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtVSOrdCod_Internalname = "VSORDCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtVSMVACod_Internalname = "VSMVACOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtVSProdCod_Internalname = "VSPRODCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtVSProdDsc_Internalname = "VSPRODDSC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtVSTipCod_Internalname = "VSTIPCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtVSDocNum_Internalname = "VSDOCNUM";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtVSCantIng_Internalname = "VSCANTING";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtVSCostoIng_Internalname = "VSCOSTOING";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtVSCantFac_Internalname = "VSCANTFAC";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtVSCostoFac_Internalname = "VSCOSTOFAC";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtVSTipMov_Internalname = "VSTIPMOV";
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
         Form.Caption = "Reporte de Almacen vs Contabilidad";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVSTipMov_Jsonclick = "";
         edtVSTipMov_Enabled = 1;
         edtVSCostoFac_Jsonclick = "";
         edtVSCostoFac_Enabled = 1;
         edtVSCantFac_Jsonclick = "";
         edtVSCantFac_Enabled = 1;
         edtVSCostoIng_Jsonclick = "";
         edtVSCostoIng_Enabled = 1;
         edtVSCantIng_Jsonclick = "";
         edtVSCantIng_Enabled = 1;
         edtVSDocNum_Jsonclick = "";
         edtVSDocNum_Enabled = 1;
         edtVSTipCod_Jsonclick = "";
         edtVSTipCod_Enabled = 1;
         edtVSProdDsc_Jsonclick = "";
         edtVSProdDsc_Enabled = 1;
         edtVSProdCod_Jsonclick = "";
         edtVSProdCod_Enabled = 1;
         edtVSMVACod_Jsonclick = "";
         edtVSMVACod_Enabled = 1;
         edtVSOrdCod_Jsonclick = "";
         edtVSOrdCod_Enabled = 1;
         edtVSFecha_Jsonclick = "";
         edtVSFecha_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtVSItem_Jsonclick = "";
         edtVSItem_Enabled = 1;
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
         GX_FocusControl = edtVSFecha_Internalname;
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

      public void Valid_Vsitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2087VSFecha", context.localUtil.Format(A2087VSFecha, "99/99/99"));
         AssignAttri("", false, "A2089VSOrdCod", StringUtil.RTrim( A2089VSOrdCod));
         AssignAttri("", false, "A2088VSMVACod", StringUtil.RTrim( A2088VSMVACod));
         AssignAttri("", false, "A2090VSProdCod", StringUtil.RTrim( A2090VSProdCod));
         AssignAttri("", false, "A2091VSProdDsc", A2091VSProdDsc);
         AssignAttri("", false, "A2092VSTipCod", StringUtil.RTrim( A2092VSTipCod));
         AssignAttri("", false, "A2086VSDocNum", StringUtil.RTrim( A2086VSDocNum));
         AssignAttri("", false, "A2083VSCantIng", StringUtil.LTrim( StringUtil.NToC( A2083VSCantIng, 15, 4, ".", "")));
         AssignAttri("", false, "A2085VSCostoIng", StringUtil.LTrim( StringUtil.NToC( A2085VSCostoIng, 15, 2, ".", "")));
         AssignAttri("", false, "A2082VSCantFac", StringUtil.LTrim( StringUtil.NToC( A2082VSCantFac, 15, 4, ".", "")));
         AssignAttri("", false, "A2084VSCostoFac", StringUtil.LTrim( StringUtil.NToC( A2084VSCostoFac, 15, 2, ".", "")));
         AssignAttri("", false, "A2093VSTipMov", A2093VSTipMov);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z237VSItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z237VSItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2087VSFecha", context.localUtil.Format(Z2087VSFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2089VSOrdCod", StringUtil.RTrim( Z2089VSOrdCod));
         GxWebStd.gx_hidden_field( context, "Z2088VSMVACod", StringUtil.RTrim( Z2088VSMVACod));
         GxWebStd.gx_hidden_field( context, "Z2090VSProdCod", StringUtil.RTrim( Z2090VSProdCod));
         GxWebStd.gx_hidden_field( context, "Z2091VSProdDsc", Z2091VSProdDsc);
         GxWebStd.gx_hidden_field( context, "Z2092VSTipCod", StringUtil.RTrim( Z2092VSTipCod));
         GxWebStd.gx_hidden_field( context, "Z2086VSDocNum", StringUtil.RTrim( Z2086VSDocNum));
         GxWebStd.gx_hidden_field( context, "Z2083VSCantIng", StringUtil.LTrim( StringUtil.NToC( Z2083VSCantIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2085VSCostoIng", StringUtil.LTrim( StringUtil.NToC( Z2085VSCostoIng, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2082VSCantFac", StringUtil.LTrim( StringUtil.NToC( Z2082VSCantFac, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2084VSCostoFac", StringUtil.LTrim( StringUtil.NToC( Z2084VSCostoFac, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2093VSTipMov", Z2093VSTipMov);
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("VALID_VSITEM","{handler:'Valid_Vsitem',iparms:[{av:'A237VSItem',fld:'VSITEM',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_VSITEM",",oparms:[{av:'A2087VSFecha',fld:'VSFECHA',pic:''},{av:'A2089VSOrdCod',fld:'VSORDCOD',pic:''},{av:'A2088VSMVACod',fld:'VSMVACOD',pic:''},{av:'A2090VSProdCod',fld:'VSPRODCOD',pic:''},{av:'A2091VSProdDsc',fld:'VSPRODDSC',pic:''},{av:'A2092VSTipCod',fld:'VSTIPCOD',pic:''},{av:'A2086VSDocNum',fld:'VSDOCNUM',pic:''},{av:'A2083VSCantIng',fld:'VSCANTING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2085VSCostoIng',fld:'VSCOSTOING',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2082VSCantFac',fld:'VSCANTFAC',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2084VSCostoFac',fld:'VSCOSTOFAC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2093VSTipMov',fld:'VSTIPMOV',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z237VSItem'},{av:'Z2087VSFecha'},{av:'Z2089VSOrdCod'},{av:'Z2088VSMVACod'},{av:'Z2090VSProdCod'},{av:'Z2091VSProdDsc'},{av:'Z2092VSTipCod'},{av:'Z2086VSDocNum'},{av:'Z2083VSCantIng'},{av:'Z2085VSCostoIng'},{av:'Z2082VSCantFac'},{av:'Z2084VSCostoFac'},{av:'Z2093VSTipMov'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_VSFECHA","{handler:'Valid_Vsfecha',iparms:[]");
         setEventMetadata("VALID_VSFECHA",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2087VSFecha = DateTime.MinValue;
         Z2089VSOrdCod = "";
         Z2088VSMVACod = "";
         Z2090VSProdCod = "";
         Z2091VSProdDsc = "";
         Z2092VSTipCod = "";
         Z2086VSDocNum = "";
         Z2093VSTipMov = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A2087VSFecha = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         A2089VSOrdCod = "";
         lblTextblock4_Jsonclick = "";
         A2088VSMVACod = "";
         lblTextblock5_Jsonclick = "";
         A2090VSProdCod = "";
         lblTextblock6_Jsonclick = "";
         A2091VSProdDsc = "";
         lblTextblock7_Jsonclick = "";
         A2092VSTipCod = "";
         lblTextblock8_Jsonclick = "";
         A2086VSDocNum = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A2093VSTipMov = "";
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
         T00354_A237VSItem = new long[1] ;
         T00354_A2087VSFecha = new DateTime[] {DateTime.MinValue} ;
         T00354_A2089VSOrdCod = new string[] {""} ;
         T00354_A2088VSMVACod = new string[] {""} ;
         T00354_A2090VSProdCod = new string[] {""} ;
         T00354_A2091VSProdDsc = new string[] {""} ;
         T00354_A2092VSTipCod = new string[] {""} ;
         T00354_A2086VSDocNum = new string[] {""} ;
         T00354_A2083VSCantIng = new decimal[1] ;
         T00354_A2085VSCostoIng = new decimal[1] ;
         T00354_A2082VSCantFac = new decimal[1] ;
         T00354_A2084VSCostoFac = new decimal[1] ;
         T00354_A2093VSTipMov = new string[] {""} ;
         T00355_A237VSItem = new long[1] ;
         T00353_A237VSItem = new long[1] ;
         T00353_A2087VSFecha = new DateTime[] {DateTime.MinValue} ;
         T00353_A2089VSOrdCod = new string[] {""} ;
         T00353_A2088VSMVACod = new string[] {""} ;
         T00353_A2090VSProdCod = new string[] {""} ;
         T00353_A2091VSProdDsc = new string[] {""} ;
         T00353_A2092VSTipCod = new string[] {""} ;
         T00353_A2086VSDocNum = new string[] {""} ;
         T00353_A2083VSCantIng = new decimal[1] ;
         T00353_A2085VSCostoIng = new decimal[1] ;
         T00353_A2082VSCantFac = new decimal[1] ;
         T00353_A2084VSCostoFac = new decimal[1] ;
         T00353_A2093VSTipMov = new string[] {""} ;
         sMode108 = "";
         T00356_A237VSItem = new long[1] ;
         T00357_A237VSItem = new long[1] ;
         T00352_A237VSItem = new long[1] ;
         T00352_A2087VSFecha = new DateTime[] {DateTime.MinValue} ;
         T00352_A2089VSOrdCod = new string[] {""} ;
         T00352_A2088VSMVACod = new string[] {""} ;
         T00352_A2090VSProdCod = new string[] {""} ;
         T00352_A2091VSProdDsc = new string[] {""} ;
         T00352_A2092VSTipCod = new string[] {""} ;
         T00352_A2086VSDocNum = new string[] {""} ;
         T00352_A2083VSCantIng = new decimal[1] ;
         T00352_A2085VSCostoIng = new decimal[1] ;
         T00352_A2082VSCantFac = new decimal[1] ;
         T00352_A2084VSCostoFac = new decimal[1] ;
         T00352_A2093VSTipMov = new string[] {""} ;
         T003511_A237VSItem = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2087VSFecha = DateTime.MinValue;
         ZZ2089VSOrdCod = "";
         ZZ2088VSMVACod = "";
         ZZ2090VSProdCod = "";
         ZZ2091VSProdDsc = "";
         ZZ2092VSTipCod = "";
         ZZ2086VSDocNum = "";
         ZZ2093VSTipMov = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpalmacenvsconta__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpalmacenvsconta__default(),
            new Object[][] {
                new Object[] {
               T00352_A237VSItem, T00352_A2087VSFecha, T00352_A2089VSOrdCod, T00352_A2088VSMVACod, T00352_A2090VSProdCod, T00352_A2091VSProdDsc, T00352_A2092VSTipCod, T00352_A2086VSDocNum, T00352_A2083VSCantIng, T00352_A2085VSCostoIng,
               T00352_A2082VSCantFac, T00352_A2084VSCostoFac, T00352_A2093VSTipMov
               }
               , new Object[] {
               T00353_A237VSItem, T00353_A2087VSFecha, T00353_A2089VSOrdCod, T00353_A2088VSMVACod, T00353_A2090VSProdCod, T00353_A2091VSProdDsc, T00353_A2092VSTipCod, T00353_A2086VSDocNum, T00353_A2083VSCantIng, T00353_A2085VSCostoIng,
               T00353_A2082VSCantFac, T00353_A2084VSCostoFac, T00353_A2093VSTipMov
               }
               , new Object[] {
               T00354_A237VSItem, T00354_A2087VSFecha, T00354_A2089VSOrdCod, T00354_A2088VSMVACod, T00354_A2090VSProdCod, T00354_A2091VSProdDsc, T00354_A2092VSTipCod, T00354_A2086VSDocNum, T00354_A2083VSCantIng, T00354_A2085VSCostoIng,
               T00354_A2082VSCantFac, T00354_A2084VSCostoFac, T00354_A2093VSTipMov
               }
               , new Object[] {
               T00355_A237VSItem
               }
               , new Object[] {
               T00356_A237VSItem
               }
               , new Object[] {
               T00357_A237VSItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003511_A237VSItem
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
      private short RcdFound108 ;
      private short nIsDirty_108 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtVSItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtVSFecha_Enabled ;
      private int edtVSOrdCod_Enabled ;
      private int edtVSMVACod_Enabled ;
      private int edtVSProdCod_Enabled ;
      private int edtVSProdDsc_Enabled ;
      private int edtVSTipCod_Enabled ;
      private int edtVSDocNum_Enabled ;
      private int edtVSCantIng_Enabled ;
      private int edtVSCostoIng_Enabled ;
      private int edtVSCantFac_Enabled ;
      private int edtVSCostoFac_Enabled ;
      private int edtVSTipMov_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private long Z237VSItem ;
      private long A237VSItem ;
      private long ZZ237VSItem ;
      private decimal Z2083VSCantIng ;
      private decimal Z2085VSCostoIng ;
      private decimal Z2082VSCantFac ;
      private decimal Z2084VSCostoFac ;
      private decimal A2083VSCantIng ;
      private decimal A2085VSCostoIng ;
      private decimal A2082VSCantFac ;
      private decimal A2084VSCostoFac ;
      private decimal ZZ2083VSCantIng ;
      private decimal ZZ2085VSCostoIng ;
      private decimal ZZ2082VSCantFac ;
      private decimal ZZ2084VSCostoFac ;
      private string sPrefix ;
      private string Z2089VSOrdCod ;
      private string Z2088VSMVACod ;
      private string Z2090VSProdCod ;
      private string Z2092VSTipCod ;
      private string Z2086VSDocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVSItem_Internalname ;
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
      private string edtVSItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtVSFecha_Internalname ;
      private string edtVSFecha_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtVSOrdCod_Internalname ;
      private string A2089VSOrdCod ;
      private string edtVSOrdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtVSMVACod_Internalname ;
      private string A2088VSMVACod ;
      private string edtVSMVACod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtVSProdCod_Internalname ;
      private string A2090VSProdCod ;
      private string edtVSProdCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtVSProdDsc_Internalname ;
      private string edtVSProdDsc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtVSTipCod_Internalname ;
      private string A2092VSTipCod ;
      private string edtVSTipCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtVSDocNum_Internalname ;
      private string A2086VSDocNum ;
      private string edtVSDocNum_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtVSCantIng_Internalname ;
      private string edtVSCantIng_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtVSCostoIng_Internalname ;
      private string edtVSCostoIng_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtVSCantFac_Internalname ;
      private string edtVSCantFac_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtVSCostoFac_Internalname ;
      private string edtVSCostoFac_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtVSTipMov_Internalname ;
      private string edtVSTipMov_Jsonclick ;
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
      private string sMode108 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2089VSOrdCod ;
      private string ZZ2088VSMVACod ;
      private string ZZ2090VSProdCod ;
      private string ZZ2092VSTipCod ;
      private string ZZ2086VSDocNum ;
      private DateTime Z2087VSFecha ;
      private DateTime A2087VSFecha ;
      private DateTime ZZ2087VSFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2091VSProdDsc ;
      private string Z2093VSTipMov ;
      private string A2091VSProdDsc ;
      private string A2093VSTipMov ;
      private string ZZ2091VSProdDsc ;
      private string ZZ2093VSTipMov ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T00354_A237VSItem ;
      private DateTime[] T00354_A2087VSFecha ;
      private string[] T00354_A2089VSOrdCod ;
      private string[] T00354_A2088VSMVACod ;
      private string[] T00354_A2090VSProdCod ;
      private string[] T00354_A2091VSProdDsc ;
      private string[] T00354_A2092VSTipCod ;
      private string[] T00354_A2086VSDocNum ;
      private decimal[] T00354_A2083VSCantIng ;
      private decimal[] T00354_A2085VSCostoIng ;
      private decimal[] T00354_A2082VSCantFac ;
      private decimal[] T00354_A2084VSCostoFac ;
      private string[] T00354_A2093VSTipMov ;
      private long[] T00355_A237VSItem ;
      private long[] T00353_A237VSItem ;
      private DateTime[] T00353_A2087VSFecha ;
      private string[] T00353_A2089VSOrdCod ;
      private string[] T00353_A2088VSMVACod ;
      private string[] T00353_A2090VSProdCod ;
      private string[] T00353_A2091VSProdDsc ;
      private string[] T00353_A2092VSTipCod ;
      private string[] T00353_A2086VSDocNum ;
      private decimal[] T00353_A2083VSCantIng ;
      private decimal[] T00353_A2085VSCostoIng ;
      private decimal[] T00353_A2082VSCantFac ;
      private decimal[] T00353_A2084VSCostoFac ;
      private string[] T00353_A2093VSTipMov ;
      private long[] T00356_A237VSItem ;
      private long[] T00357_A237VSItem ;
      private long[] T00352_A237VSItem ;
      private DateTime[] T00352_A2087VSFecha ;
      private string[] T00352_A2089VSOrdCod ;
      private string[] T00352_A2088VSMVACod ;
      private string[] T00352_A2090VSProdCod ;
      private string[] T00352_A2091VSProdDsc ;
      private string[] T00352_A2092VSTipCod ;
      private string[] T00352_A2086VSDocNum ;
      private decimal[] T00352_A2083VSCantIng ;
      private decimal[] T00352_A2085VSCostoIng ;
      private decimal[] T00352_A2082VSCantFac ;
      private decimal[] T00352_A2084VSCostoFac ;
      private string[] T00352_A2093VSTipMov ;
      private long[] T003511_A237VSItem ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpalmacenvsconta__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpalmacenvsconta__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00354;
        prmT00354 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT00355;
        prmT00355 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT00353;
        prmT00353 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT00356;
        prmT00356 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT00357;
        prmT00357 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT00352;
        prmT00352 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT00358;
        prmT00358 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0) ,
        new ParDef("@VSFecha",GXType.Date,8,0) ,
        new ParDef("@VSOrdCod",GXType.NChar,10,0) ,
        new ParDef("@VSMVACod",GXType.NChar,10,0) ,
        new ParDef("@VSProdCod",GXType.NChar,15,0) ,
        new ParDef("@VSProdDsc",GXType.NVarChar,100,0) ,
        new ParDef("@VSTipCod",GXType.NChar,5,0) ,
        new ParDef("@VSDocNum",GXType.NChar,15,0) ,
        new ParDef("@VSCantIng",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoIng",GXType.Decimal,15,2) ,
        new ParDef("@VSCantFac",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoFac",GXType.Decimal,15,2) ,
        new ParDef("@VSTipMov",GXType.NVarChar,100,0)
        };
        Object[] prmT00359;
        prmT00359 = new Object[] {
        new ParDef("@VSFecha",GXType.Date,8,0) ,
        new ParDef("@VSOrdCod",GXType.NChar,10,0) ,
        new ParDef("@VSMVACod",GXType.NChar,10,0) ,
        new ParDef("@VSProdCod",GXType.NChar,15,0) ,
        new ParDef("@VSProdDsc",GXType.NVarChar,100,0) ,
        new ParDef("@VSTipCod",GXType.NChar,5,0) ,
        new ParDef("@VSDocNum",GXType.NChar,15,0) ,
        new ParDef("@VSCantIng",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoIng",GXType.Decimal,15,2) ,
        new ParDef("@VSCantFac",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoFac",GXType.Decimal,15,2) ,
        new ParDef("@VSTipMov",GXType.NVarChar,100,0) ,
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT003510;
        prmT003510 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0)
        };
        Object[] prmT003511;
        prmT003511 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00352", "SELECT [VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov] FROM [CPALMACENVSCONTA] WITH (UPDLOCK) WHERE [VSItem] = @VSItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00352,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00353", "SELECT [VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov] FROM [CPALMACENVSCONTA] WHERE [VSItem] = @VSItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00353,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00354", "SELECT TM1.[VSItem], TM1.[VSFecha], TM1.[VSOrdCod], TM1.[VSMVACod], TM1.[VSProdCod], TM1.[VSProdDsc], TM1.[VSTipCod], TM1.[VSDocNum], TM1.[VSCantIng], TM1.[VSCostoIng], TM1.[VSCantFac], TM1.[VSCostoFac], TM1.[VSTipMov] FROM [CPALMACENVSCONTA] TM1 WHERE TM1.[VSItem] = @VSItem ORDER BY TM1.[VSItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00354,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00355", "SELECT [VSItem] FROM [CPALMACENVSCONTA] WHERE [VSItem] = @VSItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00355,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00356", "SELECT TOP 1 [VSItem] FROM [CPALMACENVSCONTA] WHERE ( [VSItem] > @VSItem) ORDER BY [VSItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00356,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00357", "SELECT TOP 1 [VSItem] FROM [CPALMACENVSCONTA] WHERE ( [VSItem] < @VSItem) ORDER BY [VSItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00357,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00358", "INSERT INTO [CPALMACENVSCONTA]([VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov]) VALUES(@VSItem, @VSFecha, @VSOrdCod, @VSMVACod, @VSProdCod, @VSProdDsc, @VSTipCod, @VSDocNum, @VSCantIng, @VSCostoIng, @VSCantFac, @VSCostoFac, @VSTipMov)", GxErrorMask.GX_NOMASK,prmT00358)
           ,new CursorDef("T00359", "UPDATE [CPALMACENVSCONTA] SET [VSFecha]=@VSFecha, [VSOrdCod]=@VSOrdCod, [VSMVACod]=@VSMVACod, [VSProdCod]=@VSProdCod, [VSProdDsc]=@VSProdDsc, [VSTipCod]=@VSTipCod, [VSDocNum]=@VSDocNum, [VSCantIng]=@VSCantIng, [VSCostoIng]=@VSCostoIng, [VSCantFac]=@VSCantFac, [VSCostoFac]=@VSCostoFac, [VSTipMov]=@VSTipMov  WHERE [VSItem] = @VSItem", GxErrorMask.GX_NOMASK,prmT00359)
           ,new CursorDef("T003510", "DELETE FROM [CPALMACENVSCONTA]  WHERE [VSItem] = @VSItem", GxErrorMask.GX_NOMASK,prmT003510)
           ,new CursorDef("T003511", "SELECT [VSItem] FROM [CPALMACENVSCONTA] ORDER BY [VSItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003511,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 5);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 5);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 5);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
