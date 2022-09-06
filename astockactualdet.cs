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
   public class astockactualdet : GXDataArea
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
            A63AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A63AlmCod, A28ProdCod) ;
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
            Form.Meta.addItem("description", "Stock Actual Detalles", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public astockactualdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public astockactualdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ASTOCKACTUALDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Almacen", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63AlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A63AlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Producto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Referencia 1", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkRef1_Internalname, A64StkRef1, StringUtil.RTrim( context.localUtil.Format( A64StkRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Referencia 2", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkRef2_Internalname, A1888StkRef2, StringUtil.RTrim( context.localUtil.Format( A1888StkRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Referencia 3", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkRef3_Internalname, A1889StkRef3, StringUtil.RTrim( context.localUtil.Format( A1889StkRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Referencia 4", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkRef4_Internalname, A1890StkRef4, StringUtil.RTrim( context.localUtil.Format( A1890StkRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Stock Ingresos", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkDIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1884StkDIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtStkDIng_Enabled!=0) ? context.localUtil.Format( A1884StkDIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1884StkDIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkDIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkDIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Stock Salidas", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkDSal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1885StkDSal, 17, 4, ".", "")), StringUtil.LTrim( ((edtStkDSal_Enabled!=0) ? context.localUtil.Format( A1885StkDSal, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1885StkDSal, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkDSal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkDSal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Stock Actual", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtStkDAct_Internalname, StringUtil.LTrim( StringUtil.NToC( A1883StkDAct, 17, 4, ".", "")), StringUtil.LTrim( ((edtStkDAct_Enabled!=0) ? context.localUtil.Format( A1883StkDAct, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1883StkDAct, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkDAct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkDAct_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Estado", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtStkDSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1887StkDSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtStkDSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1887StkDSts), "9") : context.localUtil.Format( (decimal)(A1887StkDSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkDSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkDSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Fecha", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtStkDFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtStkDFec_Internalname, context.localUtil.Format(A1886StkDFec, "99/99/99"), context.localUtil.Format( A1886StkDFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtStkDFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtStkDFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASTOCKACTUALDET.htm");
         GxWebStd.gx_bitmap( context, edtStkDFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtStkDFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ASTOCKACTUALDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASTOCKACTUALDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ASTOCKACTUALDET.htm");
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
            Z63AlmCod = (int)(context.localUtil.CToN( cgiGet( "Z63AlmCod"), ".", ","));
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z64StkRef1 = cgiGet( "Z64StkRef1");
            Z1888StkRef2 = cgiGet( "Z1888StkRef2");
            Z1889StkRef3 = cgiGet( "Z1889StkRef3");
            Z1890StkRef4 = cgiGet( "Z1890StkRef4");
            Z1884StkDIng = context.localUtil.CToN( cgiGet( "Z1884StkDIng"), ".", ",");
            Z1885StkDSal = context.localUtil.CToN( cgiGet( "Z1885StkDSal"), ".", ",");
            Z1887StkDSts = (short)(context.localUtil.CToN( cgiGet( "Z1887StkDSts"), ".", ","));
            Z1886StkDFec = context.localUtil.CToD( cgiGet( "Z1886StkDFec"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A63AlmCod = 0;
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            }
            else
            {
               A63AlmCod = (int)(context.localUtil.CToN( cgiGet( edtAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A64StkRef1 = cgiGet( edtStkRef1_Internalname);
            AssignAttri("", false, "A64StkRef1", A64StkRef1);
            A1888StkRef2 = cgiGet( edtStkRef2_Internalname);
            AssignAttri("", false, "A1888StkRef2", A1888StkRef2);
            A1889StkRef3 = cgiGet( edtStkRef3_Internalname);
            AssignAttri("", false, "A1889StkRef3", A1889StkRef3);
            A1890StkRef4 = cgiGet( edtStkRef4_Internalname);
            AssignAttri("", false, "A1890StkRef4", A1890StkRef4);
            if ( ( ( context.localUtil.CToN( cgiGet( edtStkDIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtStkDIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STKDING");
               AnyError = 1;
               GX_FocusControl = edtStkDIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1884StkDIng = 0;
               AssignAttri("", false, "A1884StkDIng", StringUtil.LTrimStr( A1884StkDIng, 15, 4));
            }
            else
            {
               A1884StkDIng = context.localUtil.CToN( cgiGet( edtStkDIng_Internalname), ".", ",");
               AssignAttri("", false, "A1884StkDIng", StringUtil.LTrimStr( A1884StkDIng, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtStkDSal_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtStkDSal_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STKDSAL");
               AnyError = 1;
               GX_FocusControl = edtStkDSal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1885StkDSal = 0;
               AssignAttri("", false, "A1885StkDSal", StringUtil.LTrimStr( A1885StkDSal, 15, 4));
            }
            else
            {
               A1885StkDSal = context.localUtil.CToN( cgiGet( edtStkDSal_Internalname), ".", ",");
               AssignAttri("", false, "A1885StkDSal", StringUtil.LTrimStr( A1885StkDSal, 15, 4));
            }
            A1883StkDAct = context.localUtil.CToN( cgiGet( edtStkDAct_Internalname), ".", ",");
            AssignAttri("", false, "A1883StkDAct", StringUtil.LTrimStr( A1883StkDAct, 15, 4));
            if ( ( ( context.localUtil.CToN( cgiGet( edtStkDSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtStkDSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "STKDSTS");
               AnyError = 1;
               GX_FocusControl = edtStkDSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1887StkDSts = 0;
               AssignAttri("", false, "A1887StkDSts", StringUtil.Str( (decimal)(A1887StkDSts), 1, 0));
            }
            else
            {
               A1887StkDSts = (short)(context.localUtil.CToN( cgiGet( edtStkDSts_Internalname), ".", ","));
               AssignAttri("", false, "A1887StkDSts", StringUtil.Str( (decimal)(A1887StkDSts), 1, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtStkDFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "STKDFEC");
               AnyError = 1;
               GX_FocusControl = edtStkDFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1886StkDFec = DateTime.MinValue;
               AssignAttri("", false, "A1886StkDFec", context.localUtil.Format(A1886StkDFec, "99/99/99"));
            }
            else
            {
               A1886StkDFec = context.localUtil.CToD( cgiGet( edtStkDFec_Internalname), 2);
               AssignAttri("", false, "A1886StkDFec", context.localUtil.Format(A1886StkDFec, "99/99/99"));
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
               A63AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = GetPar( "ProdCod");
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A64StkRef1 = GetPar( "StkRef1");
               AssignAttri("", false, "A64StkRef1", A64StkRef1);
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
               InitAll1G50( ) ;
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
         DisableAttributes1G50( ) ;
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G50( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G50( ) ;
            }
            else
            {
               CheckExtendedTable1G50( ) ;
               if ( AnyError == 0 )
               {
                  ZM1G50( 4) ;
               }
               CloseExtendedTableCursors1G50( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1G0( ) ;
         }
      }

      protected void ResetCaption1G0( )
      {
      }

      protected void ZM1G50( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1888StkRef2 = T001G3_A1888StkRef2[0];
               Z1889StkRef3 = T001G3_A1889StkRef3[0];
               Z1890StkRef4 = T001G3_A1890StkRef4[0];
               Z1884StkDIng = T001G3_A1884StkDIng[0];
               Z1885StkDSal = T001G3_A1885StkDSal[0];
               Z1887StkDSts = T001G3_A1887StkDSts[0];
               Z1886StkDFec = T001G3_A1886StkDFec[0];
            }
            else
            {
               Z1888StkRef2 = A1888StkRef2;
               Z1889StkRef3 = A1889StkRef3;
               Z1890StkRef4 = A1890StkRef4;
               Z1884StkDIng = A1884StkDIng;
               Z1885StkDSal = A1885StkDSal;
               Z1887StkDSts = A1887StkDSts;
               Z1886StkDFec = A1886StkDFec;
            }
         }
         if ( GX_JID == -3 )
         {
            Z64StkRef1 = A64StkRef1;
            Z1888StkRef2 = A1888StkRef2;
            Z1889StkRef3 = A1889StkRef3;
            Z1890StkRef4 = A1890StkRef4;
            Z1884StkDIng = A1884StkDIng;
            Z1885StkDSal = A1885StkDSal;
            Z1887StkDSts = A1887StkDSts;
            Z1886StkDFec = A1886StkDFec;
            Z63AlmCod = A63AlmCod;
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

      protected void Load1G50( )
      {
         /* Using cursor T001G5 */
         pr_default.execute(3, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound50 = 1;
            A1888StkRef2 = T001G5_A1888StkRef2[0];
            AssignAttri("", false, "A1888StkRef2", A1888StkRef2);
            A1889StkRef3 = T001G5_A1889StkRef3[0];
            AssignAttri("", false, "A1889StkRef3", A1889StkRef3);
            A1890StkRef4 = T001G5_A1890StkRef4[0];
            AssignAttri("", false, "A1890StkRef4", A1890StkRef4);
            A1884StkDIng = T001G5_A1884StkDIng[0];
            AssignAttri("", false, "A1884StkDIng", StringUtil.LTrimStr( A1884StkDIng, 15, 4));
            A1885StkDSal = T001G5_A1885StkDSal[0];
            AssignAttri("", false, "A1885StkDSal", StringUtil.LTrimStr( A1885StkDSal, 15, 4));
            A1887StkDSts = T001G5_A1887StkDSts[0];
            AssignAttri("", false, "A1887StkDSts", StringUtil.Str( (decimal)(A1887StkDSts), 1, 0));
            A1886StkDFec = T001G5_A1886StkDFec[0];
            AssignAttri("", false, "A1886StkDFec", context.localUtil.Format(A1886StkDFec, "99/99/99"));
            ZM1G50( -3) ;
         }
         pr_default.close(3);
         OnLoadActions1G50( ) ;
      }

      protected void OnLoadActions1G50( )
      {
         A1883StkDAct = (decimal)(A1884StkDIng-A1885StkDSal);
         AssignAttri("", false, "A1883StkDAct", StringUtil.LTrimStr( A1883StkDAct, 15, 4));
      }

      protected void CheckExtendedTable1G50( )
      {
         nIsDirty_50 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001G4 */
         pr_default.execute(2, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Stock Actual'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         nIsDirty_50 = 1;
         A1883StkDAct = (decimal)(A1884StkDIng-A1885StkDSal);
         AssignAttri("", false, "A1883StkDAct", StringUtil.LTrimStr( A1883StkDAct, 15, 4));
         if ( ! ( (DateTime.MinValue==A1886StkDFec) || ( DateTimeUtil.ResetTime ( A1886StkDFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "STKDFEC");
            AnyError = 1;
            GX_FocusControl = edtStkDFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1G50( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A63AlmCod ,
                               string A28ProdCod )
      {
         /* Using cursor T001G6 */
         pr_default.execute(4, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Stock Actual'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1G50( )
      {
         /* Using cursor T001G7 */
         pr_default.execute(5, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound50 = 1;
         }
         else
         {
            RcdFound50 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001G3 */
         pr_default.execute(1, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G50( 3) ;
            RcdFound50 = 1;
            A64StkRef1 = T001G3_A64StkRef1[0];
            AssignAttri("", false, "A64StkRef1", A64StkRef1);
            A1888StkRef2 = T001G3_A1888StkRef2[0];
            AssignAttri("", false, "A1888StkRef2", A1888StkRef2);
            A1889StkRef3 = T001G3_A1889StkRef3[0];
            AssignAttri("", false, "A1889StkRef3", A1889StkRef3);
            A1890StkRef4 = T001G3_A1890StkRef4[0];
            AssignAttri("", false, "A1890StkRef4", A1890StkRef4);
            A1884StkDIng = T001G3_A1884StkDIng[0];
            AssignAttri("", false, "A1884StkDIng", StringUtil.LTrimStr( A1884StkDIng, 15, 4));
            A1885StkDSal = T001G3_A1885StkDSal[0];
            AssignAttri("", false, "A1885StkDSal", StringUtil.LTrimStr( A1885StkDSal, 15, 4));
            A1887StkDSts = T001G3_A1887StkDSts[0];
            AssignAttri("", false, "A1887StkDSts", StringUtil.Str( (decimal)(A1887StkDSts), 1, 0));
            A1886StkDFec = T001G3_A1886StkDFec[0];
            AssignAttri("", false, "A1886StkDFec", context.localUtil.Format(A1886StkDFec, "99/99/99"));
            A63AlmCod = T001G3_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = T001G3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z63AlmCod = A63AlmCod;
            Z28ProdCod = A28ProdCod;
            Z64StkRef1 = A64StkRef1;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1G50( ) ;
            if ( AnyError == 1 )
            {
               RcdFound50 = 0;
               InitializeNonKey1G50( ) ;
            }
            Gx_mode = sMode50;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound50 = 0;
            InitializeNonKey1G50( ) ;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode50;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G50( ) ;
         if ( RcdFound50 == 0 )
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
         RcdFound50 = 0;
         /* Using cursor T001G8 */
         pr_default.execute(6, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001G8_A63AlmCod[0] < A63AlmCod ) || ( T001G8_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G8_A28ProdCod[0], A28ProdCod) < 0 ) || ( StringUtil.StrCmp(T001G8_A28ProdCod[0], A28ProdCod) == 0 ) && ( T001G8_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G8_A64StkRef1[0], A64StkRef1) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001G8_A63AlmCod[0] > A63AlmCod ) || ( T001G8_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G8_A28ProdCod[0], A28ProdCod) > 0 ) || ( StringUtil.StrCmp(T001G8_A28ProdCod[0], A28ProdCod) == 0 ) && ( T001G8_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G8_A64StkRef1[0], A64StkRef1) > 0 ) ) )
            {
               A63AlmCod = T001G8_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = T001G8_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A64StkRef1 = T001G8_A64StkRef1[0];
               AssignAttri("", false, "A64StkRef1", A64StkRef1);
               RcdFound50 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound50 = 0;
         /* Using cursor T001G9 */
         pr_default.execute(7, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001G9_A63AlmCod[0] > A63AlmCod ) || ( T001G9_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G9_A28ProdCod[0], A28ProdCod) > 0 ) || ( StringUtil.StrCmp(T001G9_A28ProdCod[0], A28ProdCod) == 0 ) && ( T001G9_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G9_A64StkRef1[0], A64StkRef1) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001G9_A63AlmCod[0] < A63AlmCod ) || ( T001G9_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G9_A28ProdCod[0], A28ProdCod) < 0 ) || ( StringUtil.StrCmp(T001G9_A28ProdCod[0], A28ProdCod) == 0 ) && ( T001G9_A63AlmCod[0] == A63AlmCod ) && ( StringUtil.StrCmp(T001G9_A64StkRef1[0], A64StkRef1) < 0 ) ) )
            {
               A63AlmCod = T001G9_A63AlmCod[0];
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = T001G9_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A64StkRef1 = T001G9_A64StkRef1[0];
               AssignAttri("", false, "A64StkRef1", A64StkRef1);
               RcdFound50 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1G50( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1G50( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound50 == 1 )
            {
               if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A64StkRef1, Z64StkRef1) != 0 ) )
               {
                  A63AlmCod = Z63AlmCod;
                  AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
                  A64StkRef1 = Z64StkRef1;
                  AssignAttri("", false, "A64StkRef1", A64StkRef1);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1G50( ) ;
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A64StkRef1, Z64StkRef1) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1G50( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ALMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1G50( ) ;
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
         if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A64StkRef1, Z64StkRef1) != 0 ) )
         {
            A63AlmCod = Z63AlmCod;
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A64StkRef1 = Z64StkRef1;
            AssignAttri("", false, "A64StkRef1", A64StkRef1);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAlmCod_Internalname;
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
         GetKey1G50( ) ;
         if ( RcdFound50 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A64StkRef1, Z64StkRef1) != 0 ) )
            {
               A63AlmCod = Z63AlmCod;
               AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
               A28ProdCod = Z28ProdCod;
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A64StkRef1 = Z64StkRef1;
               AssignAttri("", false, "A64StkRef1", A64StkRef1);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ALMCOD");
               AnyError = 1;
               GX_FocusControl = edtAlmCod_Internalname;
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
            if ( ( A63AlmCod != Z63AlmCod ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A64StkRef1, Z64StkRef1) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAlmCod_Internalname;
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
         context.RollbackDataStores("astockactualdet",pr_default);
         GX_FocusControl = edtStkRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1G0( ) ;
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
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ALMCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtStkRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1G50( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1G50( ) ;
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
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkRef2_Internalname;
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
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkRef2_Internalname;
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
         ScanStart1G50( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound50 != 0 )
            {
               ScanNext1G50( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtStkRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1G50( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1G50( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001G2 */
            pr_default.execute(0, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ASTOCKACTUALDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1888StkRef2, T001G2_A1888StkRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1889StkRef3, T001G2_A1889StkRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1890StkRef4, T001G2_A1890StkRef4[0]) != 0 ) || ( Z1884StkDIng != T001G2_A1884StkDIng[0] ) || ( Z1885StkDSal != T001G2_A1885StkDSal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1887StkDSts != T001G2_A1887StkDSts[0] ) || ( DateTimeUtil.ResetTime ( Z1886StkDFec ) != DateTimeUtil.ResetTime ( T001G2_A1886StkDFec[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z1888StkRef2, T001G2_A1888StkRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1888StkRef2);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1888StkRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1889StkRef3, T001G2_A1889StkRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1889StkRef3);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1889StkRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1890StkRef4, T001G2_A1890StkRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1890StkRef4);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1890StkRef4[0]);
               }
               if ( Z1884StkDIng != T001G2_A1884StkDIng[0] )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkDIng");
                  GXUtil.WriteLogRaw("Old: ",Z1884StkDIng);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1884StkDIng[0]);
               }
               if ( Z1885StkDSal != T001G2_A1885StkDSal[0] )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkDSal");
                  GXUtil.WriteLogRaw("Old: ",Z1885StkDSal);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1885StkDSal[0]);
               }
               if ( Z1887StkDSts != T001G2_A1887StkDSts[0] )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkDSts");
                  GXUtil.WriteLogRaw("Old: ",Z1887StkDSts);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1887StkDSts[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1886StkDFec ) != DateTimeUtil.ResetTime ( T001G2_A1886StkDFec[0] ) )
               {
                  GXUtil.WriteLog("astockactualdet:[seudo value changed for attri]"+"StkDFec");
                  GXUtil.WriteLogRaw("Old: ",Z1886StkDFec);
                  GXUtil.WriteLogRaw("Current: ",T001G2_A1886StkDFec[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ASTOCKACTUALDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G50( )
      {
         BeforeValidate1G50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G50( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G50( 0) ;
            CheckOptimisticConcurrency1G50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G10 */
                     pr_default.execute(8, new Object[] {A64StkRef1, A1888StkRef2, A1889StkRef3, A1890StkRef4, A1884StkDIng, A1885StkDSal, A1887StkDSts, A1886StkDFec, A63AlmCod, A28ProdCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ASTOCKACTUALDET");
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
                           ResetCaption1G0( ) ;
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
               Load1G50( ) ;
            }
            EndLevel1G50( ) ;
         }
         CloseExtendedTableCursors1G50( ) ;
      }

      protected void Update1G50( )
      {
         BeforeValidate1G50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G50( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001G11 */
                     pr_default.execute(9, new Object[] {A1888StkRef2, A1889StkRef3, A1890StkRef4, A1884StkDIng, A1885StkDSal, A1887StkDSts, A1886StkDFec, A63AlmCod, A28ProdCod, A64StkRef1});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ASTOCKACTUALDET");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ASTOCKACTUALDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G50( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1G0( ) ;
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
            EndLevel1G50( ) ;
         }
         CloseExtendedTableCursors1G50( ) ;
      }

      protected void DeferredUpdate1G50( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1G50( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G50( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G50( ) ;
            AfterConfirm1G50( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G50( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001G12 */
                  pr_default.execute(10, new Object[] {A63AlmCod, A28ProdCod, A64StkRef1});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ASTOCKACTUALDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound50 == 0 )
                        {
                           InitAll1G50( ) ;
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
                        ResetCaption1G0( ) ;
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
         sMode50 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1G50( ) ;
         Gx_mode = sMode50;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1G50( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1883StkDAct = (decimal)(A1884StkDIng-A1885StkDSal);
            AssignAttri("", false, "A1883StkDAct", StringUtil.LTrimStr( A1883StkDAct, 15, 4));
         }
      }

      protected void EndLevel1G50( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G50( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("astockactualdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("astockactualdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1G50( )
      {
         /* Using cursor T001G13 */
         pr_default.execute(11);
         RcdFound50 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound50 = 1;
            A63AlmCod = T001G13_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = T001G13_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A64StkRef1 = T001G13_A64StkRef1[0];
            AssignAttri("", false, "A64StkRef1", A64StkRef1);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1G50( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound50 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound50 = 1;
            A63AlmCod = T001G13_A63AlmCod[0];
            AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
            A28ProdCod = T001G13_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A64StkRef1 = T001G13_A64StkRef1[0];
            AssignAttri("", false, "A64StkRef1", A64StkRef1);
         }
      }

      protected void ScanEnd1G50( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1G50( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G50( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G50( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G50( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G50( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G50( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G50( )
      {
         edtAlmCod_Enabled = 0;
         AssignProp("", false, edtAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAlmCod_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtStkRef1_Enabled = 0;
         AssignProp("", false, edtStkRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkRef1_Enabled), 5, 0), true);
         edtStkRef2_Enabled = 0;
         AssignProp("", false, edtStkRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkRef2_Enabled), 5, 0), true);
         edtStkRef3_Enabled = 0;
         AssignProp("", false, edtStkRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkRef3_Enabled), 5, 0), true);
         edtStkRef4_Enabled = 0;
         AssignProp("", false, edtStkRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkRef4_Enabled), 5, 0), true);
         edtStkDIng_Enabled = 0;
         AssignProp("", false, edtStkDIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkDIng_Enabled), 5, 0), true);
         edtStkDSal_Enabled = 0;
         AssignProp("", false, edtStkDSal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkDSal_Enabled), 5, 0), true);
         edtStkDAct_Enabled = 0;
         AssignProp("", false, edtStkDAct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkDAct_Enabled), 5, 0), true);
         edtStkDSts_Enabled = 0;
         AssignProp("", false, edtStkDSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkDSts_Enabled), 5, 0), true);
         edtStkDFec_Enabled = 0;
         AssignProp("", false, edtStkDFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtStkDFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1G50( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811465777", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("astockactualdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z64StkRef1", Z64StkRef1);
         GxWebStd.gx_hidden_field( context, "Z1888StkRef2", Z1888StkRef2);
         GxWebStd.gx_hidden_field( context, "Z1889StkRef3", Z1889StkRef3);
         GxWebStd.gx_hidden_field( context, "Z1890StkRef4", Z1890StkRef4);
         GxWebStd.gx_hidden_field( context, "Z1884StkDIng", StringUtil.LTrim( StringUtil.NToC( Z1884StkDIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1885StkDSal", StringUtil.LTrim( StringUtil.NToC( Z1885StkDSal, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1887StkDSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1887StkDSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1886StkDFec", context.localUtil.DToC( Z1886StkDFec, 0, "/"));
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
         return formatLink("astockactualdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ASTOCKACTUALDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Stock Actual Detalles" ;
      }

      protected void InitializeNonKey1G50( )
      {
         A1883StkDAct = 0;
         AssignAttri("", false, "A1883StkDAct", StringUtil.LTrimStr( A1883StkDAct, 15, 4));
         A1888StkRef2 = "";
         AssignAttri("", false, "A1888StkRef2", A1888StkRef2);
         A1889StkRef3 = "";
         AssignAttri("", false, "A1889StkRef3", A1889StkRef3);
         A1890StkRef4 = "";
         AssignAttri("", false, "A1890StkRef4", A1890StkRef4);
         A1884StkDIng = 0;
         AssignAttri("", false, "A1884StkDIng", StringUtil.LTrimStr( A1884StkDIng, 15, 4));
         A1885StkDSal = 0;
         AssignAttri("", false, "A1885StkDSal", StringUtil.LTrimStr( A1885StkDSal, 15, 4));
         A1887StkDSts = 0;
         AssignAttri("", false, "A1887StkDSts", StringUtil.Str( (decimal)(A1887StkDSts), 1, 0));
         A1886StkDFec = DateTime.MinValue;
         AssignAttri("", false, "A1886StkDFec", context.localUtil.Format(A1886StkDFec, "99/99/99"));
         Z1888StkRef2 = "";
         Z1889StkRef3 = "";
         Z1890StkRef4 = "";
         Z1884StkDIng = 0;
         Z1885StkDSal = 0;
         Z1887StkDSts = 0;
         Z1886StkDFec = DateTime.MinValue;
      }

      protected void InitAll1G50( )
      {
         A63AlmCod = 0;
         AssignAttri("", false, "A63AlmCod", StringUtil.LTrimStr( (decimal)(A63AlmCod), 6, 0));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A64StkRef1 = "";
         AssignAttri("", false, "A64StkRef1", A64StkRef1);
         InitializeNonKey1G50( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811465780", true, true);
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
         context.AddJavascriptSource("astockactualdet.js", "?202281811465780", false, true);
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
         edtAlmCod_Internalname = "ALMCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtStkRef1_Internalname = "STKREF1";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtStkRef2_Internalname = "STKREF2";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtStkRef3_Internalname = "STKREF3";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtStkRef4_Internalname = "STKREF4";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtStkDIng_Internalname = "STKDING";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtStkDSal_Internalname = "STKDSAL";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtStkDAct_Internalname = "STKDACT";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtStkDSts_Internalname = "STKDSTS";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtStkDFec_Internalname = "STKDFEC";
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
         Form.Caption = "Stock Actual Detalles";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtStkDFec_Jsonclick = "";
         edtStkDFec_Enabled = 1;
         edtStkDSts_Jsonclick = "";
         edtStkDSts_Enabled = 1;
         edtStkDAct_Jsonclick = "";
         edtStkDAct_Enabled = 0;
         edtStkDSal_Jsonclick = "";
         edtStkDSal_Enabled = 1;
         edtStkDIng_Jsonclick = "";
         edtStkDIng_Enabled = 1;
         edtStkRef4_Jsonclick = "";
         edtStkRef4_Enabled = 1;
         edtStkRef3_Jsonclick = "";
         edtStkRef3_Enabled = 1;
         edtStkRef2_Jsonclick = "";
         edtStkRef2_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtStkRef1_Jsonclick = "";
         edtStkRef1_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         edtAlmCod_Jsonclick = "";
         edtAlmCod_Enabled = 1;
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
         /* Using cursor T001G14 */
         pr_default.execute(12, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Stock Actual'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtStkRef2_Internalname;
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
         /* Using cursor T001G14 */
         pr_default.execute(12, new Object[] {A63AlmCod, A28ProdCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Stock Actual'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtAlmCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Stkref1( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1888StkRef2", A1888StkRef2);
         AssignAttri("", false, "A1889StkRef3", A1889StkRef3);
         AssignAttri("", false, "A1890StkRef4", A1890StkRef4);
         AssignAttri("", false, "A1884StkDIng", StringUtil.LTrim( StringUtil.NToC( A1884StkDIng, 15, 4, ".", "")));
         AssignAttri("", false, "A1885StkDSal", StringUtil.LTrim( StringUtil.NToC( A1885StkDSal, 15, 4, ".", "")));
         AssignAttri("", false, "A1887StkDSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1887StkDSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1886StkDFec", context.localUtil.Format(A1886StkDFec, "99/99/99"));
         AssignAttri("", false, "A1883StkDAct", StringUtil.LTrim( StringUtil.NToC( A1883StkDAct, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z63AlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63AlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z64StkRef1", Z64StkRef1);
         GxWebStd.gx_hidden_field( context, "Z1888StkRef2", Z1888StkRef2);
         GxWebStd.gx_hidden_field( context, "Z1889StkRef3", Z1889StkRef3);
         GxWebStd.gx_hidden_field( context, "Z1890StkRef4", Z1890StkRef4);
         GxWebStd.gx_hidden_field( context, "Z1884StkDIng", StringUtil.LTrim( StringUtil.NToC( Z1884StkDIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1885StkDSal", StringUtil.LTrim( StringUtil.NToC( Z1885StkDSal, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1887StkDSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1887StkDSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1886StkDFec", context.localUtil.Format(Z1886StkDFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1883StkDAct", StringUtil.LTrim( StringUtil.NToC( Z1883StkDAct, 15, 4, ".", "")));
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
         setEventMetadata("VALID_ALMCOD","{handler:'Valid_Almcod',iparms:[]");
         setEventMetadata("VALID_ALMCOD",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A63AlmCod',fld:'ALMCOD',pic:'ZZZZZ9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[]}");
         setEventMetadata("VALID_STKREF1","{handler:'Valid_Stkref1',iparms:[{av:'A63AlmCod',fld:'ALMCOD',pic:'ZZZZZ9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A64StkRef1',fld:'STKREF1',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_STKREF1",",oparms:[{av:'A1888StkRef2',fld:'STKREF2',pic:''},{av:'A1889StkRef3',fld:'STKREF3',pic:''},{av:'A1890StkRef4',fld:'STKREF4',pic:''},{av:'A1884StkDIng',fld:'STKDING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1885StkDSal',fld:'STKDSAL',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1887StkDSts',fld:'STKDSTS',pic:'9'},{av:'A1886StkDFec',fld:'STKDFEC',pic:''},{av:'A1883StkDAct',fld:'STKDACT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z63AlmCod'},{av:'Z28ProdCod'},{av:'Z64StkRef1'},{av:'Z1888StkRef2'},{av:'Z1889StkRef3'},{av:'Z1890StkRef4'},{av:'Z1884StkDIng'},{av:'Z1885StkDSal'},{av:'Z1887StkDSts'},{av:'Z1886StkDFec'},{av:'Z1883StkDAct'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_STKDING","{handler:'Valid_Stkding',iparms:[]");
         setEventMetadata("VALID_STKDING",",oparms:[]}");
         setEventMetadata("VALID_STKDSAL","{handler:'Valid_Stkdsal',iparms:[]");
         setEventMetadata("VALID_STKDSAL",",oparms:[]}");
         setEventMetadata("VALID_STKDFEC","{handler:'Valid_Stkdfec',iparms:[]");
         setEventMetadata("VALID_STKDFEC",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z28ProdCod = "";
         Z64StkRef1 = "";
         Z1888StkRef2 = "";
         Z1889StkRef3 = "";
         Z1890StkRef4 = "";
         Z1886StkDFec = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A64StkRef1 = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1888StkRef2 = "";
         lblTextblock5_Jsonclick = "";
         A1889StkRef3 = "";
         lblTextblock6_Jsonclick = "";
         A1890StkRef4 = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         A1886StkDFec = DateTime.MinValue;
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
         T001G5_A64StkRef1 = new string[] {""} ;
         T001G5_A1888StkRef2 = new string[] {""} ;
         T001G5_A1889StkRef3 = new string[] {""} ;
         T001G5_A1890StkRef4 = new string[] {""} ;
         T001G5_A1884StkDIng = new decimal[1] ;
         T001G5_A1885StkDSal = new decimal[1] ;
         T001G5_A1887StkDSts = new short[1] ;
         T001G5_A1886StkDFec = new DateTime[] {DateTime.MinValue} ;
         T001G5_A63AlmCod = new int[1] ;
         T001G5_A28ProdCod = new string[] {""} ;
         T001G4_A63AlmCod = new int[1] ;
         T001G6_A63AlmCod = new int[1] ;
         T001G7_A63AlmCod = new int[1] ;
         T001G7_A28ProdCod = new string[] {""} ;
         T001G7_A64StkRef1 = new string[] {""} ;
         T001G3_A64StkRef1 = new string[] {""} ;
         T001G3_A1888StkRef2 = new string[] {""} ;
         T001G3_A1889StkRef3 = new string[] {""} ;
         T001G3_A1890StkRef4 = new string[] {""} ;
         T001G3_A1884StkDIng = new decimal[1] ;
         T001G3_A1885StkDSal = new decimal[1] ;
         T001G3_A1887StkDSts = new short[1] ;
         T001G3_A1886StkDFec = new DateTime[] {DateTime.MinValue} ;
         T001G3_A63AlmCod = new int[1] ;
         T001G3_A28ProdCod = new string[] {""} ;
         sMode50 = "";
         T001G8_A63AlmCod = new int[1] ;
         T001G8_A28ProdCod = new string[] {""} ;
         T001G8_A64StkRef1 = new string[] {""} ;
         T001G9_A63AlmCod = new int[1] ;
         T001G9_A28ProdCod = new string[] {""} ;
         T001G9_A64StkRef1 = new string[] {""} ;
         T001G2_A64StkRef1 = new string[] {""} ;
         T001G2_A1888StkRef2 = new string[] {""} ;
         T001G2_A1889StkRef3 = new string[] {""} ;
         T001G2_A1890StkRef4 = new string[] {""} ;
         T001G2_A1884StkDIng = new decimal[1] ;
         T001G2_A1885StkDSal = new decimal[1] ;
         T001G2_A1887StkDSts = new short[1] ;
         T001G2_A1886StkDFec = new DateTime[] {DateTime.MinValue} ;
         T001G2_A63AlmCod = new int[1] ;
         T001G2_A28ProdCod = new string[] {""} ;
         T001G13_A63AlmCod = new int[1] ;
         T001G13_A28ProdCod = new string[] {""} ;
         T001G13_A64StkRef1 = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001G14_A63AlmCod = new int[1] ;
         ZZ28ProdCod = "";
         ZZ64StkRef1 = "";
         ZZ1888StkRef2 = "";
         ZZ1889StkRef3 = "";
         ZZ1890StkRef4 = "";
         ZZ1886StkDFec = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.astockactualdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.astockactualdet__default(),
            new Object[][] {
                new Object[] {
               T001G2_A64StkRef1, T001G2_A1888StkRef2, T001G2_A1889StkRef3, T001G2_A1890StkRef4, T001G2_A1884StkDIng, T001G2_A1885StkDSal, T001G2_A1887StkDSts, T001G2_A1886StkDFec, T001G2_A63AlmCod, T001G2_A28ProdCod
               }
               , new Object[] {
               T001G3_A64StkRef1, T001G3_A1888StkRef2, T001G3_A1889StkRef3, T001G3_A1890StkRef4, T001G3_A1884StkDIng, T001G3_A1885StkDSal, T001G3_A1887StkDSts, T001G3_A1886StkDFec, T001G3_A63AlmCod, T001G3_A28ProdCod
               }
               , new Object[] {
               T001G4_A63AlmCod
               }
               , new Object[] {
               T001G5_A64StkRef1, T001G5_A1888StkRef2, T001G5_A1889StkRef3, T001G5_A1890StkRef4, T001G5_A1884StkDIng, T001G5_A1885StkDSal, T001G5_A1887StkDSts, T001G5_A1886StkDFec, T001G5_A63AlmCod, T001G5_A28ProdCod
               }
               , new Object[] {
               T001G6_A63AlmCod
               }
               , new Object[] {
               T001G7_A63AlmCod, T001G7_A28ProdCod, T001G7_A64StkRef1
               }
               , new Object[] {
               T001G8_A63AlmCod, T001G8_A28ProdCod, T001G8_A64StkRef1
               }
               , new Object[] {
               T001G9_A63AlmCod, T001G9_A28ProdCod, T001G9_A64StkRef1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001G13_A63AlmCod, T001G13_A28ProdCod, T001G13_A64StkRef1
               }
               , new Object[] {
               T001G14_A63AlmCod
               }
            }
         );
      }

      private short Z1887StkDSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1887StkDSts ;
      private short GX_JID ;
      private short RcdFound50 ;
      private short nIsDirty_50 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1887StkDSts ;
      private int Z63AlmCod ;
      private int A63AlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAlmCod_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtStkRef1_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtStkRef2_Enabled ;
      private int edtStkRef3_Enabled ;
      private int edtStkRef4_Enabled ;
      private int edtStkDIng_Enabled ;
      private int edtStkDSal_Enabled ;
      private int edtStkDAct_Enabled ;
      private int edtStkDSts_Enabled ;
      private int edtStkDFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ63AlmCod ;
      private decimal Z1884StkDIng ;
      private decimal Z1885StkDSal ;
      private decimal A1884StkDIng ;
      private decimal A1885StkDSal ;
      private decimal A1883StkDAct ;
      private decimal Z1883StkDAct ;
      private decimal ZZ1884StkDIng ;
      private decimal ZZ1885StkDSal ;
      private decimal ZZ1883StkDAct ;
      private string sPrefix ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAlmCod_Internalname ;
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
      private string edtAlmCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtStkRef1_Internalname ;
      private string edtStkRef1_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtStkRef2_Internalname ;
      private string edtStkRef2_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtStkRef3_Internalname ;
      private string edtStkRef3_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtStkRef4_Internalname ;
      private string edtStkRef4_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtStkDIng_Internalname ;
      private string edtStkDIng_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtStkDSal_Internalname ;
      private string edtStkDSal_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtStkDAct_Internalname ;
      private string edtStkDAct_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtStkDSts_Internalname ;
      private string edtStkDSts_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtStkDFec_Internalname ;
      private string edtStkDFec_Jsonclick ;
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
      private string sMode50 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ28ProdCod ;
      private DateTime Z1886StkDFec ;
      private DateTime A1886StkDFec ;
      private DateTime ZZ1886StkDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z64StkRef1 ;
      private string Z1888StkRef2 ;
      private string Z1889StkRef3 ;
      private string Z1890StkRef4 ;
      private string A64StkRef1 ;
      private string A1888StkRef2 ;
      private string A1889StkRef3 ;
      private string A1890StkRef4 ;
      private string ZZ64StkRef1 ;
      private string ZZ1888StkRef2 ;
      private string ZZ1889StkRef3 ;
      private string ZZ1890StkRef4 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001G5_A64StkRef1 ;
      private string[] T001G5_A1888StkRef2 ;
      private string[] T001G5_A1889StkRef3 ;
      private string[] T001G5_A1890StkRef4 ;
      private decimal[] T001G5_A1884StkDIng ;
      private decimal[] T001G5_A1885StkDSal ;
      private short[] T001G5_A1887StkDSts ;
      private DateTime[] T001G5_A1886StkDFec ;
      private int[] T001G5_A63AlmCod ;
      private string[] T001G5_A28ProdCod ;
      private int[] T001G4_A63AlmCod ;
      private int[] T001G6_A63AlmCod ;
      private int[] T001G7_A63AlmCod ;
      private string[] T001G7_A28ProdCod ;
      private string[] T001G7_A64StkRef1 ;
      private string[] T001G3_A64StkRef1 ;
      private string[] T001G3_A1888StkRef2 ;
      private string[] T001G3_A1889StkRef3 ;
      private string[] T001G3_A1890StkRef4 ;
      private decimal[] T001G3_A1884StkDIng ;
      private decimal[] T001G3_A1885StkDSal ;
      private short[] T001G3_A1887StkDSts ;
      private DateTime[] T001G3_A1886StkDFec ;
      private int[] T001G3_A63AlmCod ;
      private string[] T001G3_A28ProdCod ;
      private int[] T001G8_A63AlmCod ;
      private string[] T001G8_A28ProdCod ;
      private string[] T001G8_A64StkRef1 ;
      private int[] T001G9_A63AlmCod ;
      private string[] T001G9_A28ProdCod ;
      private string[] T001G9_A64StkRef1 ;
      private string[] T001G2_A64StkRef1 ;
      private string[] T001G2_A1888StkRef2 ;
      private string[] T001G2_A1889StkRef3 ;
      private string[] T001G2_A1890StkRef4 ;
      private decimal[] T001G2_A1884StkDIng ;
      private decimal[] T001G2_A1885StkDSal ;
      private short[] T001G2_A1887StkDSts ;
      private DateTime[] T001G2_A1886StkDFec ;
      private int[] T001G2_A63AlmCod ;
      private string[] T001G2_A28ProdCod ;
      private int[] T001G13_A63AlmCod ;
      private string[] T001G13_A28ProdCod ;
      private string[] T001G13_A64StkRef1 ;
      private int[] T001G14_A63AlmCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class astockactualdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class astockactualdet__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001G5;
        prmT001G5 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G4;
        prmT001G4 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001G6;
        prmT001G6 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001G7;
        prmT001G7 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G3;
        prmT001G3 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G8;
        prmT001G8 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G9;
        prmT001G9 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G2;
        prmT001G2 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G10;
        prmT001G10 = new Object[] {
        new ParDef("@StkRef1",GXType.NVarChar,20,0) ,
        new ParDef("@StkRef2",GXType.NVarChar,20,0) ,
        new ParDef("@StkRef3",GXType.NVarChar,20,0) ,
        new ParDef("@StkRef4",GXType.NVarChar,20,0) ,
        new ParDef("@StkDIng",GXType.Decimal,15,4) ,
        new ParDef("@StkDSal",GXType.Decimal,15,4) ,
        new ParDef("@StkDSts",GXType.Int16,1,0) ,
        new ParDef("@StkDFec",GXType.Date,8,0) ,
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001G11;
        prmT001G11 = new Object[] {
        new ParDef("@StkRef2",GXType.NVarChar,20,0) ,
        new ParDef("@StkRef3",GXType.NVarChar,20,0) ,
        new ParDef("@StkRef4",GXType.NVarChar,20,0) ,
        new ParDef("@StkDIng",GXType.Decimal,15,4) ,
        new ParDef("@StkDSal",GXType.Decimal,15,4) ,
        new ParDef("@StkDSts",GXType.Int16,1,0) ,
        new ParDef("@StkDFec",GXType.Date,8,0) ,
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G12;
        prmT001G12 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@StkRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001G13;
        prmT001G13 = new Object[] {
        };
        Object[] prmT001G14;
        prmT001G14 = new Object[] {
        new ParDef("@AlmCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001G2", "SELECT [StkRef1], [StkRef2], [StkRef3], [StkRef4], [StkDIng], [StkDSal], [StkDSts], [StkDFec], [AlmCod], [ProdCod] FROM [ASTOCKACTUALDET] WITH (UPDLOCK) WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod AND [StkRef1] = @StkRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G3", "SELECT [StkRef1], [StkRef2], [StkRef3], [StkRef4], [StkDIng], [StkDSal], [StkDSts], [StkDFec], [AlmCod], [ProdCod] FROM [ASTOCKACTUALDET] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod AND [StkRef1] = @StkRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G4", "SELECT [AlmCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G5", "SELECT TM1.[StkRef1], TM1.[StkRef2], TM1.[StkRef3], TM1.[StkRef4], TM1.[StkDIng], TM1.[StkDSal], TM1.[StkDSts], TM1.[StkDFec], TM1.[AlmCod], TM1.[ProdCod] FROM [ASTOCKACTUALDET] TM1 WHERE TM1.[AlmCod] = @AlmCod and TM1.[ProdCod] = @ProdCod and TM1.[StkRef1] = @StkRef1 ORDER BY TM1.[AlmCod], TM1.[ProdCod], TM1.[StkRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G6", "SELECT [AlmCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G7", "SELECT [AlmCod], [ProdCod], [StkRef1] FROM [ASTOCKACTUALDET] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod AND [StkRef1] = @StkRef1  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G8", "SELECT TOP 1 [AlmCod], [ProdCod], [StkRef1] FROM [ASTOCKACTUALDET] WHERE ( [AlmCod] > @AlmCod or [AlmCod] = @AlmCod and [ProdCod] > @ProdCod or [ProdCod] = @ProdCod and [AlmCod] = @AlmCod and [StkRef1] > @StkRef1) ORDER BY [AlmCod], [ProdCod], [StkRef1]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001G9", "SELECT TOP 1 [AlmCod], [ProdCod], [StkRef1] FROM [ASTOCKACTUALDET] WHERE ( [AlmCod] < @AlmCod or [AlmCod] = @AlmCod and [ProdCod] < @ProdCod or [ProdCod] = @ProdCod and [AlmCod] = @AlmCod and [StkRef1] < @StkRef1) ORDER BY [AlmCod] DESC, [ProdCod] DESC, [StkRef1] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001G10", "INSERT INTO [ASTOCKACTUALDET]([StkRef1], [StkRef2], [StkRef3], [StkRef4], [StkDIng], [StkDSal], [StkDSts], [StkDFec], [AlmCod], [ProdCod]) VALUES(@StkRef1, @StkRef2, @StkRef3, @StkRef4, @StkDIng, @StkDSal, @StkDSts, @StkDFec, @AlmCod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT001G10)
           ,new CursorDef("T001G11", "UPDATE [ASTOCKACTUALDET] SET [StkRef2]=@StkRef2, [StkRef3]=@StkRef3, [StkRef4]=@StkRef4, [StkDIng]=@StkDIng, [StkDSal]=@StkDSal, [StkDSts]=@StkDSts, [StkDFec]=@StkDFec  WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod AND [StkRef1] = @StkRef1", GxErrorMask.GX_NOMASK,prmT001G11)
           ,new CursorDef("T001G12", "DELETE FROM [ASTOCKACTUALDET]  WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod AND [StkRef1] = @StkRef1", GxErrorMask.GX_NOMASK,prmT001G12)
           ,new CursorDef("T001G13", "SELECT [AlmCod], [ProdCod], [StkRef1] FROM [ASTOCKACTUALDET] ORDER BY [AlmCod], [ProdCod], [StkRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001G13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001G14", "SELECT [AlmCod] FROM [ASTOCKACTUAL] WHERE [AlmCod] = @AlmCod AND [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001G14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
