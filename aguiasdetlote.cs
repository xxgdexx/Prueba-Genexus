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
   public class aguiasdetlote : GXDataArea
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
            A13MvATip = GetPar( "MvATip");
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = GetPar( "MvACod");
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = (int)(NumberUtil.Val( GetPar( "MvADItem"), "."));
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A13MvATip, A14MvACod, A30MvADItem) ;
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
            Form.Meta.addItem("description", "Movimiento de Almacen Lotes", 0) ;
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

      public aguiasdetlote( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguiasdetlote( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AGUIASDETLOTE.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Mov. Almacen", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvATip_Internalname, StringUtil.RTrim( A13MvATip), StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvATip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvATip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Mov.Almacen", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvACod_Internalname, StringUtil.RTrim( A14MvACod), StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvACod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvADItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30MvADItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtMvADItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A30MvADItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A30MvADItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvADItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvADItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Referencia 1", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADLRef1_Internalname, A31MVADLRef1, StringUtil.RTrim( context.localUtil.Format( A31MVADLRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Referencia 2", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADLRef2_Internalname, A1254MVADLRef2, StringUtil.RTrim( context.localUtil.Format( A1254MVADLRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Referencia 3", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADLRef3_Internalname, A1255MVADLRef3, StringUtil.RTrim( context.localUtil.Format( A1255MVADLRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Referencia 4", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADLRef4_Internalname, A1256MVADLRef4, StringUtil.RTrim( context.localUtil.Format( A1256MVADLRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cantidad", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVADLCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1251MVADLCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtMVADLCant_Enabled!=0) ? context.localUtil.Format( A1251MVADLCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1251MVADLCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Fecha", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIASDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVADLFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVADLFec_Internalname, context.localUtil.Format(A1252MVADLFec, "99/99/99"), context.localUtil.Format( A1252MVADLFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVADLFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVADLFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASDETLOTE.htm");
         GxWebStd.gx_bitmap( context, edtMVADLFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVADLFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AGUIASDETLOTE.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_AGUIASDETLOTE.htm");
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
            Z31MVADLRef1 = cgiGet( "Z31MVADLRef1");
            Z1254MVADLRef2 = cgiGet( "Z1254MVADLRef2");
            Z1255MVADLRef3 = cgiGet( "Z1255MVADLRef3");
            Z1256MVADLRef4 = cgiGet( "Z1256MVADLRef4");
            Z1251MVADLCant = context.localUtil.CToN( cgiGet( "Z1251MVADLCant"), ".", ",");
            Z1252MVADLFec = context.localUtil.CToD( cgiGet( "Z1252MVADLFec"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A13MvATip = cgiGet( edtMvATip_Internalname);
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = cgiGet( edtMvACod_Internalname);
            AssignAttri("", false, "A14MvACod", A14MvACod);
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
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A31MVADLRef1 = cgiGet( edtMVADLRef1_Internalname);
            AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
            A1254MVADLRef2 = cgiGet( edtMVADLRef2_Internalname);
            AssignAttri("", false, "A1254MVADLRef2", A1254MVADLRef2);
            A1255MVADLRef3 = cgiGet( edtMVADLRef3_Internalname);
            AssignAttri("", false, "A1255MVADLRef3", A1255MVADLRef3);
            A1256MVADLRef4 = cgiGet( edtMVADLRef4_Internalname);
            AssignAttri("", false, "A1256MVADLRef4", A1256MVADLRef4);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVADLCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVADLCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVADLCANT");
               AnyError = 1;
               GX_FocusControl = edtMVADLCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1251MVADLCant = 0;
               AssignAttri("", false, "A1251MVADLCant", StringUtil.LTrimStr( A1251MVADLCant, 15, 4));
            }
            else
            {
               A1251MVADLCant = context.localUtil.CToN( cgiGet( edtMVADLCant_Internalname), ".", ",");
               AssignAttri("", false, "A1251MVADLCant", StringUtil.LTrimStr( A1251MVADLCant, 15, 4));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVADLFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "MVADLFEC");
               AnyError = 1;
               GX_FocusControl = edtMVADLFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1252MVADLFec = DateTime.MinValue;
               AssignAttri("", false, "A1252MVADLFec", context.localUtil.Format(A1252MVADLFec, "99/99/99"));
            }
            else
            {
               A1252MVADLFec = context.localUtil.CToD( cgiGet( edtMVADLFec_Internalname), 2);
               AssignAttri("", false, "A1252MVADLFec", context.localUtil.Format(A1252MVADLFec, "99/99/99"));
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
               A13MvATip = GetPar( "MvATip");
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = GetPar( "MvACod");
               AssignAttri("", false, "A14MvACod", A14MvACod);
               A30MvADItem = (int)(NumberUtil.Val( GetPar( "MvADItem"), "."));
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               A31MVADLRef1 = GetPar( "MVADLRef1");
               AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
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
               InitAll1741( ) ;
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
         DisableAttributes1741( ) ;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1741( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1741( ) ;
            }
            else
            {
               CheckExtendedTable1741( ) ;
               if ( AnyError == 0 )
               {
                  ZM1741( 3) ;
               }
               CloseExtendedTableCursors1741( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues170( ) ;
         }
      }

      protected void ResetCaption170( )
      {
      }

      protected void ZM1741( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1254MVADLRef2 = T00173_A1254MVADLRef2[0];
               Z1255MVADLRef3 = T00173_A1255MVADLRef3[0];
               Z1256MVADLRef4 = T00173_A1256MVADLRef4[0];
               Z1251MVADLCant = T00173_A1251MVADLCant[0];
               Z1252MVADLFec = T00173_A1252MVADLFec[0];
            }
            else
            {
               Z1254MVADLRef2 = A1254MVADLRef2;
               Z1255MVADLRef3 = A1255MVADLRef3;
               Z1256MVADLRef4 = A1256MVADLRef4;
               Z1251MVADLCant = A1251MVADLCant;
               Z1252MVADLFec = A1252MVADLFec;
            }
         }
         if ( GX_JID == -2 )
         {
            Z31MVADLRef1 = A31MVADLRef1;
            Z28ProdCod = A28ProdCod;
            Z1254MVADLRef2 = A1254MVADLRef2;
            Z1255MVADLRef3 = A1255MVADLRef3;
            Z1256MVADLRef4 = A1256MVADLRef4;
            Z1251MVADLCant = A1251MVADLCant;
            Z1252MVADLFec = A1252MVADLFec;
            Z13MvATip = A13MvATip;
            Z14MvACod = A14MvACod;
            Z30MvADItem = A30MvADItem;
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

      protected void Load1741( )
      {
         /* Using cursor T00175 */
         pr_default.execute(3, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound41 = 1;
            A28ProdCod = T00175_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A1254MVADLRef2 = T00175_A1254MVADLRef2[0];
            AssignAttri("", false, "A1254MVADLRef2", A1254MVADLRef2);
            A1255MVADLRef3 = T00175_A1255MVADLRef3[0];
            AssignAttri("", false, "A1255MVADLRef3", A1255MVADLRef3);
            A1256MVADLRef4 = T00175_A1256MVADLRef4[0];
            AssignAttri("", false, "A1256MVADLRef4", A1256MVADLRef4);
            A1251MVADLCant = T00175_A1251MVADLCant[0];
            AssignAttri("", false, "A1251MVADLCant", StringUtil.LTrimStr( A1251MVADLCant, 15, 4));
            A1252MVADLFec = T00175_A1252MVADLFec[0];
            AssignAttri("", false, "A1252MVADLFec", context.localUtil.Format(A1252MVADLFec, "99/99/99"));
            ZM1741( -2) ;
         }
         pr_default.close(3);
         OnLoadActions1741( ) ;
      }

      protected void OnLoadActions1741( )
      {
         /* Using cursor T00174 */
         pr_default.execute(2, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         A28ProdCod = T00174_A28ProdCod[0];
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         pr_default.close(2);
      }

      protected void CheckExtendedTable1741( )
      {
         nIsDirty_41 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00174 */
         pr_default.execute(2, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov Almacen Detalle'.", "ForeignKeyNotFound", 1, "MVADITEM");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28ProdCod = T00174_A28ProdCod[0];
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1252MVADLFec) || ( DateTimeUtil.ResetTime ( A1252MVADLFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "MVADLFEC");
            AnyError = 1;
            GX_FocusControl = edtMVADLFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1741( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A13MvATip ,
                               string A14MvACod ,
                               int A30MvADItem )
      {
         /* Using cursor T00176 */
         pr_default.execute(4, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov Almacen Detalle'.", "ForeignKeyNotFound", 1, "MVADITEM");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28ProdCod = T00176_A28ProdCod[0];
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A28ProdCod))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1741( )
      {
         /* Using cursor T00177 */
         pr_default.execute(5, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00173 */
         pr_default.execute(1, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1741( 2) ;
            RcdFound41 = 1;
            A31MVADLRef1 = T00173_A31MVADLRef1[0];
            AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
            A1254MVADLRef2 = T00173_A1254MVADLRef2[0];
            AssignAttri("", false, "A1254MVADLRef2", A1254MVADLRef2);
            A1255MVADLRef3 = T00173_A1255MVADLRef3[0];
            AssignAttri("", false, "A1255MVADLRef3", A1255MVADLRef3);
            A1256MVADLRef4 = T00173_A1256MVADLRef4[0];
            AssignAttri("", false, "A1256MVADLRef4", A1256MVADLRef4);
            A1251MVADLCant = T00173_A1251MVADLCant[0];
            AssignAttri("", false, "A1251MVADLCant", StringUtil.LTrimStr( A1251MVADLCant, 15, 4));
            A1252MVADLFec = T00173_A1252MVADLFec[0];
            AssignAttri("", false, "A1252MVADLFec", context.localUtil.Format(A1252MVADLFec, "99/99/99"));
            A13MvATip = T00173_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T00173_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = T00173_A30MvADItem[0];
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            Z13MvATip = A13MvATip;
            Z14MvACod = A14MvACod;
            Z30MvADItem = A30MvADItem;
            Z31MVADLRef1 = A31MVADLRef1;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1741( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1741( ) ;
            }
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1741( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1741( ) ;
         if ( RcdFound41 == 0 )
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
         RcdFound41 = 0;
         /* Using cursor T00178 */
         pr_default.execute(6, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) < 0 ) || ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00178_A14MvACod[0], A14MvACod) < 0 ) || ( StringUtil.StrCmp(T00178_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) == 0 ) && ( T00178_A30MvADItem[0] < A30MvADItem ) || ( T00178_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T00178_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00178_A31MVADLRef1[0], A31MVADLRef1) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) > 0 ) || ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00178_A14MvACod[0], A14MvACod) > 0 ) || ( StringUtil.StrCmp(T00178_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) == 0 ) && ( T00178_A30MvADItem[0] > A30MvADItem ) || ( T00178_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T00178_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00178_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00178_A31MVADLRef1[0], A31MVADLRef1) > 0 ) ) )
            {
               A13MvATip = T00178_A13MvATip[0];
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = T00178_A14MvACod[0];
               AssignAttri("", false, "A14MvACod", A14MvACod);
               A30MvADItem = T00178_A30MvADItem[0];
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               A31MVADLRef1 = T00178_A31MVADLRef1[0];
               AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
               RcdFound41 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound41 = 0;
         /* Using cursor T00179 */
         pr_default.execute(7, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) > 0 ) || ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00179_A14MvACod[0], A14MvACod) > 0 ) || ( StringUtil.StrCmp(T00179_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) == 0 ) && ( T00179_A30MvADItem[0] > A30MvADItem ) || ( T00179_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T00179_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00179_A31MVADLRef1[0], A31MVADLRef1) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) < 0 ) || ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00179_A14MvACod[0], A14MvACod) < 0 ) || ( StringUtil.StrCmp(T00179_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) == 0 ) && ( T00179_A30MvADItem[0] < A30MvADItem ) || ( T00179_A30MvADItem[0] == A30MvADItem ) && ( StringUtil.StrCmp(T00179_A14MvACod[0], A14MvACod) == 0 ) && ( StringUtil.StrCmp(T00179_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T00179_A31MVADLRef1[0], A31MVADLRef1) < 0 ) ) )
            {
               A13MvATip = T00179_A13MvATip[0];
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = T00179_A14MvACod[0];
               AssignAttri("", false, "A14MvACod", A14MvACod);
               A30MvADItem = T00179_A30MvADItem[0];
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               A31MVADLRef1 = T00179_A31MVADLRef1[0];
               AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
               RcdFound41 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1741( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1741( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) || ( StringUtil.StrCmp(A31MVADLRef1, Z31MVADLRef1) != 0 ) )
               {
                  A13MvATip = Z13MvATip;
                  AssignAttri("", false, "A13MvATip", A13MvATip);
                  A14MvACod = Z14MvACod;
                  AssignAttri("", false, "A14MvACod", A14MvACod);
                  A30MvADItem = Z30MvADItem;
                  AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
                  A31MVADLRef1 = Z31MVADLRef1;
                  AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
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
                  Update1741( ) ;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) || ( StringUtil.StrCmp(A31MVADLRef1, Z31MVADLRef1) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1741( ) ;
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
                     Insert1741( ) ;
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
         if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) || ( StringUtil.StrCmp(A31MVADLRef1, Z31MVADLRef1) != 0 ) )
         {
            A13MvATip = Z13MvATip;
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = Z14MvACod;
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = Z30MvADItem;
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            A31MVADLRef1 = Z31MVADLRef1;
            AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
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
         GetKey1741( ) ;
         if ( RcdFound41 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "MVATIP");
               AnyError = 1;
               GX_FocusControl = edtMvATip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) || ( StringUtil.StrCmp(A31MVADLRef1, Z31MVADLRef1) != 0 ) )
            {
               A13MvATip = Z13MvATip;
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = Z14MvACod;
               AssignAttri("", false, "A14MvACod", A14MvACod);
               A30MvADItem = Z30MvADItem;
               AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
               A31MVADLRef1 = Z31MVADLRef1;
               AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
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
            if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) || ( A30MvADItem != Z30MvADItem ) || ( StringUtil.StrCmp(A31MVADLRef1, Z31MVADLRef1) != 0 ) )
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
         context.RollbackDataStores("aguiasdetlote",pr_default);
         GX_FocusControl = edtMVADLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_170( ) ;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MVATIP");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMVADLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1741( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVADLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1741( ) ;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVADLRef2_Internalname;
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
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVADLRef2_Internalname;
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
         ScanStart1741( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound41 != 0 )
            {
               ScanNext1741( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVADLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1741( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1741( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00172 */
            pr_default.execute(0, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASDETLOTE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1254MVADLRef2, T00172_A1254MVADLRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1255MVADLRef3, T00172_A1255MVADLRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1256MVADLRef4, T00172_A1256MVADLRef4[0]) != 0 ) || ( Z1251MVADLCant != T00172_A1251MVADLCant[0] ) || ( DateTimeUtil.ResetTime ( Z1252MVADLFec ) != DateTimeUtil.ResetTime ( T00172_A1252MVADLFec[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z1254MVADLRef2, T00172_A1254MVADLRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdetlote:[seudo value changed for attri]"+"MVADLRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1254MVADLRef2);
                  GXUtil.WriteLogRaw("Current: ",T00172_A1254MVADLRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1255MVADLRef3, T00172_A1255MVADLRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdetlote:[seudo value changed for attri]"+"MVADLRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1255MVADLRef3);
                  GXUtil.WriteLogRaw("Current: ",T00172_A1255MVADLRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1256MVADLRef4, T00172_A1256MVADLRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiasdetlote:[seudo value changed for attri]"+"MVADLRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1256MVADLRef4);
                  GXUtil.WriteLogRaw("Current: ",T00172_A1256MVADLRef4[0]);
               }
               if ( Z1251MVADLCant != T00172_A1251MVADLCant[0] )
               {
                  GXUtil.WriteLog("aguiasdetlote:[seudo value changed for attri]"+"MVADLCant");
                  GXUtil.WriteLogRaw("Old: ",Z1251MVADLCant);
                  GXUtil.WriteLogRaw("Current: ",T00172_A1251MVADLCant[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1252MVADLFec ) != DateTimeUtil.ResetTime ( T00172_A1252MVADLFec[0] ) )
               {
                  GXUtil.WriteLog("aguiasdetlote:[seudo value changed for attri]"+"MVADLFec");
                  GXUtil.WriteLogRaw("Old: ",Z1252MVADLFec);
                  GXUtil.WriteLogRaw("Current: ",T00172_A1252MVADLFec[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AGUIASDETLOTE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1741( )
      {
         BeforeValidate1741( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1741( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1741( 0) ;
            CheckOptimisticConcurrency1741( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1741( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1741( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001710 */
                     pr_default.execute(8, new Object[] {A28ProdCod, A31MVADLRef1, A1254MVADLRef2, A1255MVADLRef3, A1256MVADLRef4, A1251MVADLCant, A1252MVADLFec, A13MvATip, A14MvACod, A30MvADItem});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASDETLOTE");
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
                           ResetCaption170( ) ;
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
               Load1741( ) ;
            }
            EndLevel1741( ) ;
         }
         CloseExtendedTableCursors1741( ) ;
      }

      protected void Update1741( )
      {
         BeforeValidate1741( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1741( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1741( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1741( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1741( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001711 */
                     pr_default.execute(9, new Object[] {A28ProdCod, A1254MVADLRef2, A1255MVADLRef3, A1256MVADLRef4, A1251MVADLCant, A1252MVADLFec, A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASDETLOTE");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASDETLOTE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1741( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption170( ) ;
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
            EndLevel1741( ) ;
         }
         CloseExtendedTableCursors1741( ) ;
      }

      protected void DeferredUpdate1741( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1741( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1741( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1741( ) ;
            AfterConfirm1741( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1741( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001712 */
                  pr_default.execute(10, new Object[] {A13MvATip, A14MvACod, A30MvADItem, A31MVADLRef1});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("AGUIASDETLOTE");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound41 == 0 )
                        {
                           InitAll1741( ) ;
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
                        ResetCaption170( ) ;
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
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1741( ) ;
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1741( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001713 */
            pr_default.execute(11, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
            A28ProdCod = T001713_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            pr_default.close(11);
         }
      }

      protected void EndLevel1741( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1741( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("aguiasdetlote",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues170( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("aguiasdetlote",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1741( )
      {
         /* Using cursor T001714 */
         pr_default.execute(12);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound41 = 1;
            A13MvATip = T001714_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T001714_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = T001714_A30MvADItem[0];
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            A31MVADLRef1 = T001714_A31MVADLRef1[0];
            AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1741( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound41 = 1;
            A13MvATip = T001714_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T001714_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A30MvADItem = T001714_A30MvADItem[0];
            AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
            A31MVADLRef1 = T001714_A31MVADLRef1[0];
            AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
         }
      }

      protected void ScanEnd1741( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1741( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1741( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1741( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1741( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1741( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1741( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1741( )
      {
         edtMvATip_Enabled = 0;
         AssignProp("", false, edtMvATip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvATip_Enabled), 5, 0), true);
         edtMvACod_Enabled = 0;
         AssignProp("", false, edtMvACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvACod_Enabled), 5, 0), true);
         edtMvADItem_Enabled = 0;
         AssignProp("", false, edtMvADItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvADItem_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtMVADLRef1_Enabled = 0;
         AssignProp("", false, edtMVADLRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLRef1_Enabled), 5, 0), true);
         edtMVADLRef2_Enabled = 0;
         AssignProp("", false, edtMVADLRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLRef2_Enabled), 5, 0), true);
         edtMVADLRef3_Enabled = 0;
         AssignProp("", false, edtMVADLRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLRef3_Enabled), 5, 0), true);
         edtMVADLRef4_Enabled = 0;
         AssignProp("", false, edtMVADLRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLRef4_Enabled), 5, 0), true);
         edtMVADLCant_Enabled = 0;
         AssignProp("", false, edtMVADLCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLCant_Enabled), 5, 0), true);
         edtMVADLFec_Enabled = 0;
         AssignProp("", false, edtMVADLFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVADLFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1741( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues170( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443967", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aguiasdetlote.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z31MVADLRef1", Z31MVADLRef1);
         GxWebStd.gx_hidden_field( context, "Z1254MVADLRef2", Z1254MVADLRef2);
         GxWebStd.gx_hidden_field( context, "Z1255MVADLRef3", Z1255MVADLRef3);
         GxWebStd.gx_hidden_field( context, "Z1256MVADLRef4", Z1256MVADLRef4);
         GxWebStd.gx_hidden_field( context, "Z1251MVADLCant", StringUtil.LTrim( StringUtil.NToC( Z1251MVADLCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1252MVADLFec", context.localUtil.DToC( Z1252MVADLFec, 0, "/"));
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
         return formatLink("aguiasdetlote.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AGUIASDETLOTE" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimiento de Almacen Lotes" ;
      }

      protected void InitializeNonKey1741( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A1254MVADLRef2 = "";
         AssignAttri("", false, "A1254MVADLRef2", A1254MVADLRef2);
         A1255MVADLRef3 = "";
         AssignAttri("", false, "A1255MVADLRef3", A1255MVADLRef3);
         A1256MVADLRef4 = "";
         AssignAttri("", false, "A1256MVADLRef4", A1256MVADLRef4);
         A1251MVADLCant = 0;
         AssignAttri("", false, "A1251MVADLCant", StringUtil.LTrimStr( A1251MVADLCant, 15, 4));
         A1252MVADLFec = DateTime.MinValue;
         AssignAttri("", false, "A1252MVADLFec", context.localUtil.Format(A1252MVADLFec, "99/99/99"));
         Z1254MVADLRef2 = "";
         Z1255MVADLRef3 = "";
         Z1256MVADLRef4 = "";
         Z1251MVADLCant = 0;
         Z1252MVADLFec = DateTime.MinValue;
      }

      protected void InitAll1741( )
      {
         A13MvATip = "";
         AssignAttri("", false, "A13MvATip", A13MvATip);
         A14MvACod = "";
         AssignAttri("", false, "A14MvACod", A14MvACod);
         A30MvADItem = 0;
         AssignAttri("", false, "A30MvADItem", StringUtil.LTrimStr( (decimal)(A30MvADItem), 6, 0));
         A31MVADLRef1 = "";
         AssignAttri("", false, "A31MVADLRef1", A31MVADLRef1);
         InitializeNonKey1741( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443974", true, true);
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
         context.AddJavascriptSource("aguiasdetlote.js", "?202281811443975", false, true);
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
         edtMvADItem_Internalname = "MVADITEM";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtMVADLRef1_Internalname = "MVADLREF1";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtMVADLRef2_Internalname = "MVADLREF2";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtMVADLRef3_Internalname = "MVADLREF3";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtMVADLRef4_Internalname = "MVADLREF4";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtMVADLCant_Internalname = "MVADLCANT";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtMVADLFec_Internalname = "MVADLFEC";
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
         Form.Caption = "Movimiento de Almacen Lotes";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMVADLFec_Jsonclick = "";
         edtMVADLFec_Enabled = 1;
         edtMVADLCant_Jsonclick = "";
         edtMVADLCant_Enabled = 1;
         edtMVADLRef4_Jsonclick = "";
         edtMVADLRef4_Enabled = 1;
         edtMVADLRef3_Jsonclick = "";
         edtMVADLRef3_Enabled = 1;
         edtMVADLRef2_Jsonclick = "";
         edtMVADLRef2_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMVADLRef1_Jsonclick = "";
         edtMVADLRef1_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 0;
         edtMvADItem_Jsonclick = "";
         edtMvADItem_Enabled = 1;
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
         /* Using cursor T001713 */
         pr_default.execute(11, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov Almacen Detalle'.", "ForeignKeyNotFound", 1, "MVADITEM");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28ProdCod = T001713_A28ProdCod[0];
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         pr_default.close(11);
         GX_FocusControl = edtMVADLRef2_Internalname;
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

      public void Valid_Mvaditem( )
      {
         /* Using cursor T001713 */
         pr_default.execute(11, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Mov Almacen Detalle'.", "ForeignKeyNotFound", 1, "MVADITEM");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
         }
         A28ProdCod = T001713_A28ProdCod[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
      }

      public void Valid_Mvadlref1( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1254MVADLRef2", A1254MVADLRef2);
         AssignAttri("", false, "A1255MVADLRef3", A1255MVADLRef3);
         AssignAttri("", false, "A1256MVADLRef4", A1256MVADLRef4);
         AssignAttri("", false, "A1251MVADLCant", StringUtil.LTrim( StringUtil.NToC( A1251MVADLCant, 15, 4, ".", "")));
         AssignAttri("", false, "A1252MVADLFec", context.localUtil.Format(A1252MVADLFec, "99/99/99"));
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z13MvATip", StringUtil.RTrim( Z13MvATip));
         GxWebStd.gx_hidden_field( context, "Z14MvACod", StringUtil.RTrim( Z14MvACod));
         GxWebStd.gx_hidden_field( context, "Z30MvADItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30MvADItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31MVADLRef1", Z31MVADLRef1);
         GxWebStd.gx_hidden_field( context, "Z1254MVADLRef2", Z1254MVADLRef2);
         GxWebStd.gx_hidden_field( context, "Z1255MVADLRef3", Z1255MVADLRef3);
         GxWebStd.gx_hidden_field( context, "Z1256MVADLRef4", Z1256MVADLRef4);
         GxWebStd.gx_hidden_field( context, "Z1251MVADLCant", StringUtil.LTrim( StringUtil.NToC( Z1251MVADLCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1252MVADLFec", context.localUtil.Format(Z1252MVADLFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
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
         setEventMetadata("VALID_MVATIP","{handler:'Valid_Mvatip',iparms:[]");
         setEventMetadata("VALID_MVATIP",",oparms:[]}");
         setEventMetadata("VALID_MVACOD","{handler:'Valid_Mvacod',iparms:[]");
         setEventMetadata("VALID_MVACOD",",oparms:[]}");
         setEventMetadata("VALID_MVADITEM","{handler:'Valid_Mvaditem',iparms:[{av:'A13MvATip',fld:'MVATIP',pic:''},{av:'A14MvACod',fld:'MVACOD',pic:''},{av:'A30MvADItem',fld:'MVADITEM',pic:'ZZZZZ9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_MVADITEM",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]}");
         setEventMetadata("VALID_MVADLREF1","{handler:'Valid_Mvadlref1',iparms:[{av:'A13MvATip',fld:'MVATIP',pic:''},{av:'A14MvACod',fld:'MVACOD',pic:''},{av:'A30MvADItem',fld:'MVADITEM',pic:'ZZZZZ9'},{av:'A31MVADLRef1',fld:'MVADLREF1',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MVADLREF1",",oparms:[{av:'A1254MVADLRef2',fld:'MVADLREF2',pic:''},{av:'A1255MVADLRef3',fld:'MVADLREF3',pic:''},{av:'A1256MVADLRef4',fld:'MVADLREF4',pic:''},{av:'A1251MVADLCant',fld:'MVADLCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1252MVADLFec',fld:'MVADLFEC',pic:''},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z13MvATip'},{av:'Z14MvACod'},{av:'Z30MvADItem'},{av:'Z31MVADLRef1'},{av:'Z1254MVADLRef2'},{av:'Z1255MVADLRef3'},{av:'Z1256MVADLRef4'},{av:'Z1251MVADLCant'},{av:'Z1252MVADLFec'},{av:'Z28ProdCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_MVADLFEC","{handler:'Valid_Mvadlfec',iparms:[]");
         setEventMetadata("VALID_MVADLFEC",",oparms:[]}");
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
         Z13MvATip = "";
         Z14MvACod = "";
         Z31MVADLRef1 = "";
         Z1254MVADLRef2 = "";
         Z1255MVADLRef3 = "";
         Z1256MVADLRef4 = "";
         Z1252MVADLFec = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A13MvATip = "";
         A14MvACod = "";
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
         lblTextblock4_Jsonclick = "";
         A28ProdCod = "";
         lblTextblock5_Jsonclick = "";
         A31MVADLRef1 = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A1254MVADLRef2 = "";
         lblTextblock7_Jsonclick = "";
         A1255MVADLRef3 = "";
         lblTextblock8_Jsonclick = "";
         A1256MVADLRef4 = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1252MVADLFec = DateTime.MinValue;
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
         Z28ProdCod = "";
         T00175_A31MVADLRef1 = new string[] {""} ;
         T00175_A28ProdCod = new string[] {""} ;
         T00175_A1254MVADLRef2 = new string[] {""} ;
         T00175_A1255MVADLRef3 = new string[] {""} ;
         T00175_A1256MVADLRef4 = new string[] {""} ;
         T00175_A1251MVADLCant = new decimal[1] ;
         T00175_A1252MVADLFec = new DateTime[] {DateTime.MinValue} ;
         T00175_A13MvATip = new string[] {""} ;
         T00175_A14MvACod = new string[] {""} ;
         T00175_A30MvADItem = new int[1] ;
         T00174_A28ProdCod = new string[] {""} ;
         T00176_A28ProdCod = new string[] {""} ;
         T00177_A13MvATip = new string[] {""} ;
         T00177_A14MvACod = new string[] {""} ;
         T00177_A30MvADItem = new int[1] ;
         T00177_A31MVADLRef1 = new string[] {""} ;
         T00173_A31MVADLRef1 = new string[] {""} ;
         T00173_A1254MVADLRef2 = new string[] {""} ;
         T00173_A1255MVADLRef3 = new string[] {""} ;
         T00173_A1256MVADLRef4 = new string[] {""} ;
         T00173_A1251MVADLCant = new decimal[1] ;
         T00173_A1252MVADLFec = new DateTime[] {DateTime.MinValue} ;
         T00173_A13MvATip = new string[] {""} ;
         T00173_A14MvACod = new string[] {""} ;
         T00173_A30MvADItem = new int[1] ;
         T00173_A28ProdCod = new string[] {""} ;
         sMode41 = "";
         T00178_A13MvATip = new string[] {""} ;
         T00178_A14MvACod = new string[] {""} ;
         T00178_A30MvADItem = new int[1] ;
         T00178_A31MVADLRef1 = new string[] {""} ;
         T00179_A13MvATip = new string[] {""} ;
         T00179_A14MvACod = new string[] {""} ;
         T00179_A30MvADItem = new int[1] ;
         T00179_A31MVADLRef1 = new string[] {""} ;
         T00172_A31MVADLRef1 = new string[] {""} ;
         T00172_A1254MVADLRef2 = new string[] {""} ;
         T00172_A1255MVADLRef3 = new string[] {""} ;
         T00172_A1256MVADLRef4 = new string[] {""} ;
         T00172_A1251MVADLCant = new decimal[1] ;
         T00172_A1252MVADLFec = new DateTime[] {DateTime.MinValue} ;
         T00172_A13MvATip = new string[] {""} ;
         T00172_A14MvACod = new string[] {""} ;
         T00172_A30MvADItem = new int[1] ;
         T00172_A28ProdCod = new string[] {""} ;
         T001713_A28ProdCod = new string[] {""} ;
         T001714_A13MvATip = new string[] {""} ;
         T001714_A14MvACod = new string[] {""} ;
         T001714_A30MvADItem = new int[1] ;
         T001714_A31MVADLRef1 = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ13MvATip = "";
         ZZ14MvACod = "";
         ZZ31MVADLRef1 = "";
         ZZ1254MVADLRef2 = "";
         ZZ1255MVADLRef3 = "";
         ZZ1256MVADLRef4 = "";
         ZZ1252MVADLFec = DateTime.MinValue;
         ZZ28ProdCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aguiasdetlote__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguiasdetlote__default(),
            new Object[][] {
                new Object[] {
               T00172_A31MVADLRef1, T00172_A1254MVADLRef2, T00172_A1255MVADLRef3, T00172_A1256MVADLRef4, T00172_A1251MVADLCant, T00172_A1252MVADLFec, T00172_A13MvATip, T00172_A14MvACod, T00172_A30MvADItem, T00172_A28ProdCod
               }
               , new Object[] {
               T00173_A31MVADLRef1, T00173_A1254MVADLRef2, T00173_A1255MVADLRef3, T00173_A1256MVADLRef4, T00173_A1251MVADLCant, T00173_A1252MVADLFec, T00173_A13MvATip, T00173_A14MvACod, T00173_A30MvADItem, T00173_A28ProdCod
               }
               , new Object[] {
               T00174_A28ProdCod
               }
               , new Object[] {
               T00175_A31MVADLRef1, T00175_A28ProdCod, T00175_A1254MVADLRef2, T00175_A1255MVADLRef3, T00175_A1256MVADLRef4, T00175_A1251MVADLCant, T00175_A1252MVADLFec, T00175_A13MvATip, T00175_A14MvACod, T00175_A30MvADItem
               }
               , new Object[] {
               T00176_A28ProdCod
               }
               , new Object[] {
               T00177_A13MvATip, T00177_A14MvACod, T00177_A30MvADItem, T00177_A31MVADLRef1
               }
               , new Object[] {
               T00178_A13MvATip, T00178_A14MvACod, T00178_A30MvADItem, T00178_A31MVADLRef1
               }
               , new Object[] {
               T00179_A13MvATip, T00179_A14MvACod, T00179_A30MvADItem, T00179_A31MVADLRef1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001713_A28ProdCod
               }
               , new Object[] {
               T001714_A13MvATip, T001714_A14MvACod, T001714_A30MvADItem, T001714_A31MVADLRef1
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
      private short RcdFound41 ;
      private short nIsDirty_41 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z30MvADItem ;
      private int A30MvADItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMvATip_Enabled ;
      private int edtMvACod_Enabled ;
      private int edtMvADItem_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtMVADLRef1_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMVADLRef2_Enabled ;
      private int edtMVADLRef3_Enabled ;
      private int edtMVADLRef4_Enabled ;
      private int edtMVADLCant_Enabled ;
      private int edtMVADLFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ30MvADItem ;
      private decimal Z1251MVADLCant ;
      private decimal A1251MVADLCant ;
      private decimal ZZ1251MVADLCant ;
      private string sPrefix ;
      private string Z13MvATip ;
      private string Z14MvACod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A13MvATip ;
      private string A14MvACod ;
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
      private string edtMvADItem_Internalname ;
      private string edtMvADItem_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string A28ProdCod ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtMVADLRef1_Internalname ;
      private string edtMVADLRef1_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtMVADLRef2_Internalname ;
      private string edtMVADLRef2_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtMVADLRef3_Internalname ;
      private string edtMVADLRef3_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtMVADLRef4_Internalname ;
      private string edtMVADLRef4_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtMVADLCant_Internalname ;
      private string edtMVADLCant_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtMVADLFec_Internalname ;
      private string edtMVADLFec_Jsonclick ;
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
      private string Z28ProdCod ;
      private string sMode41 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ13MvATip ;
      private string ZZ14MvACod ;
      private string ZZ28ProdCod ;
      private DateTime Z1252MVADLFec ;
      private DateTime A1252MVADLFec ;
      private DateTime ZZ1252MVADLFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z31MVADLRef1 ;
      private string Z1254MVADLRef2 ;
      private string Z1255MVADLRef3 ;
      private string Z1256MVADLRef4 ;
      private string A31MVADLRef1 ;
      private string A1254MVADLRef2 ;
      private string A1255MVADLRef3 ;
      private string A1256MVADLRef4 ;
      private string ZZ31MVADLRef1 ;
      private string ZZ1254MVADLRef2 ;
      private string ZZ1255MVADLRef3 ;
      private string ZZ1256MVADLRef4 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00175_A31MVADLRef1 ;
      private string[] T00175_A28ProdCod ;
      private string[] T00175_A1254MVADLRef2 ;
      private string[] T00175_A1255MVADLRef3 ;
      private string[] T00175_A1256MVADLRef4 ;
      private decimal[] T00175_A1251MVADLCant ;
      private DateTime[] T00175_A1252MVADLFec ;
      private string[] T00175_A13MvATip ;
      private string[] T00175_A14MvACod ;
      private int[] T00175_A30MvADItem ;
      private string[] T00174_A28ProdCod ;
      private string[] T00176_A28ProdCod ;
      private string[] T00177_A13MvATip ;
      private string[] T00177_A14MvACod ;
      private int[] T00177_A30MvADItem ;
      private string[] T00177_A31MVADLRef1 ;
      private string[] T00173_A31MVADLRef1 ;
      private string[] T00173_A1254MVADLRef2 ;
      private string[] T00173_A1255MVADLRef3 ;
      private string[] T00173_A1256MVADLRef4 ;
      private decimal[] T00173_A1251MVADLCant ;
      private DateTime[] T00173_A1252MVADLFec ;
      private string[] T00173_A13MvATip ;
      private string[] T00173_A14MvACod ;
      private int[] T00173_A30MvADItem ;
      private string[] T00173_A28ProdCod ;
      private string[] T00178_A13MvATip ;
      private string[] T00178_A14MvACod ;
      private int[] T00178_A30MvADItem ;
      private string[] T00178_A31MVADLRef1 ;
      private string[] T00179_A13MvATip ;
      private string[] T00179_A14MvACod ;
      private int[] T00179_A30MvADItem ;
      private string[] T00179_A31MVADLRef1 ;
      private string[] T00172_A31MVADLRef1 ;
      private string[] T00172_A1254MVADLRef2 ;
      private string[] T00172_A1255MVADLRef3 ;
      private string[] T00172_A1256MVADLRef4 ;
      private decimal[] T00172_A1251MVADLCant ;
      private DateTime[] T00172_A1252MVADLFec ;
      private string[] T00172_A13MvATip ;
      private string[] T00172_A14MvACod ;
      private int[] T00172_A30MvADItem ;
      private string[] T00172_A28ProdCod ;
      private string[] T001713_A28ProdCod ;
      private string[] T001714_A13MvATip ;
      private string[] T001714_A14MvACod ;
      private int[] T001714_A30MvADItem ;
      private string[] T001714_A31MVADLRef1 ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aguiasdetlote__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aguiasdetlote__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00175;
        prmT00175 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00174;
        prmT00174 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT00176;
        prmT00176 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT00177;
        prmT00177 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00173;
        prmT00173 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00178;
        prmT00178 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00179;
        prmT00179 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00172;
        prmT00172 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001710;
        prmT001710 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLRef2",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLRef3",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLRef4",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLCant",GXType.Decimal,15,4) ,
        new ParDef("@MVADLFec",GXType.Date,8,0) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        Object[] prmT001711;
        prmT001711 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@MVADLRef2",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLRef3",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLRef4",GXType.NVarChar,20,0) ,
        new ParDef("@MVADLCant",GXType.Decimal,15,4) ,
        new ParDef("@MVADLFec",GXType.Date,8,0) ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001712;
        prmT001712 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0) ,
        new ParDef("@MVADLRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT001714;
        prmT001714 = new Object[] {
        };
        Object[] prmT001713;
        prmT001713 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvADItem",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00172", "SELECT [MVADLRef1], [MVADLRef2], [MVADLRef3], [MVADLRef4], [MVADLCant], [MVADLFec], [MvATip], [MvACod], [MvADItem], [ProdCod] FROM [AGUIASDETLOTE] WITH (UPDLOCK) WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem AND [MVADLRef1] = @MVADLRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00173", "SELECT [MVADLRef1], [MVADLRef2], [MVADLRef3], [MVADLRef4], [MVADLCant], [MVADLFec], [MvATip], [MvACod], [MvADItem], [ProdCod] FROM [AGUIASDETLOTE] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem AND [MVADLRef1] = @MVADLRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00174", "SELECT [ProdCod] FROM [AGUIASDET] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00174,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00175", "SELECT TM1.[MVADLRef1], TM1.[ProdCod], TM1.[MVADLRef2], TM1.[MVADLRef3], TM1.[MVADLRef4], TM1.[MVADLCant], TM1.[MVADLFec], TM1.[MvATip], TM1.[MvACod], TM1.[MvADItem] FROM [AGUIASDETLOTE] TM1 WHERE TM1.[MvATip] = @MvATip and TM1.[MvACod] = @MvACod and TM1.[MvADItem] = @MvADItem and TM1.[MVADLRef1] = @MVADLRef1 ORDER BY TM1.[MvATip], TM1.[MvACod], TM1.[MvADItem], TM1.[MVADLRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00175,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00176", "SELECT [ProdCod] FROM [AGUIASDET] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00176,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00177", "SELECT [MvATip], [MvACod], [MvADItem], [MVADLRef1] FROM [AGUIASDETLOTE] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem AND [MVADLRef1] = @MVADLRef1  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00177,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00178", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem], [MVADLRef1] FROM [AGUIASDETLOTE] WHERE ( [MvATip] > @MvATip or [MvATip] = @MvATip and [MvACod] > @MvACod or [MvACod] = @MvACod and [MvATip] = @MvATip and [MvADItem] > @MvADItem or [MvADItem] = @MvADItem and [MvACod] = @MvACod and [MvATip] = @MvATip and [MVADLRef1] > @MVADLRef1) ORDER BY [MvATip], [MvACod], [MvADItem], [MVADLRef1]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00178,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00179", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem], [MVADLRef1] FROM [AGUIASDETLOTE] WHERE ( [MvATip] < @MvATip or [MvATip] = @MvATip and [MvACod] < @MvACod or [MvACod] = @MvACod and [MvATip] = @MvATip and [MvADItem] < @MvADItem or [MvADItem] = @MvADItem and [MvACod] = @MvACod and [MvATip] = @MvATip and [MVADLRef1] < @MVADLRef1) ORDER BY [MvATip] DESC, [MvACod] DESC, [MvADItem] DESC, [MVADLRef1] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00179,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001710", "INSERT INTO [AGUIASDETLOTE]([ProdCod], [MVADLRef1], [MVADLRef2], [MVADLRef3], [MVADLRef4], [MVADLCant], [MVADLFec], [MvATip], [MvACod], [MvADItem]) VALUES(@ProdCod, @MVADLRef1, @MVADLRef2, @MVADLRef3, @MVADLRef4, @MVADLCant, @MVADLFec, @MvATip, @MvACod, @MvADItem)", GxErrorMask.GX_NOMASK,prmT001710)
           ,new CursorDef("T001711", "UPDATE [AGUIASDETLOTE] SET [ProdCod]=@ProdCod, [MVADLRef2]=@MVADLRef2, [MVADLRef3]=@MVADLRef3, [MVADLRef4]=@MVADLRef4, [MVADLCant]=@MVADLCant, [MVADLFec]=@MVADLFec  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem AND [MVADLRef1] = @MVADLRef1", GxErrorMask.GX_NOMASK,prmT001711)
           ,new CursorDef("T001712", "DELETE FROM [AGUIASDETLOTE]  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem AND [MVADLRef1] = @MVADLRef1", GxErrorMask.GX_NOMASK,prmT001712)
           ,new CursorDef("T001713", "SELECT [ProdCod] FROM [AGUIASDET] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod AND [MvADItem] = @MvADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001713,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001714", "SELECT [MvATip], [MvACod], [MvADItem], [MVADLRef1] FROM [AGUIASDETLOTE] ORDER BY [MvATip], [MvACod], [MvADItem], [MVADLRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001714,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getString(8, 12);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getString(8, 12);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 12);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
     }
  }

}

}
