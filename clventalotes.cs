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
   public class clventalotes : GXDataArea
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
            A224LotCliCod = GetPar( "LotCliCod");
            AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A224LotCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A149TipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A225LotMonCod = (int)(NumberUtil.Val( GetPar( "LotMonCod"), "."));
            AssignAttri("", false, "A225LotMonCod", StringUtil.LTrimStr( (decimal)(A225LotMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A225LotMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A28ProdCod) ;
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
            Form.Meta.addItem("description", "CLVENTALOTES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLotCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clventalotes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clventalotes( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLVENTALOTES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "R.U.C.", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLotCliCod_Internalname, StringUtil.RTrim( A224LotCliCod), StringUtil.RTrim( context.localUtil.Format( A224LotCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLotCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLotCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cliente", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLotCliDsc_Internalname, StringUtil.RTrim( A1216LotCliDsc), StringUtil.RTrim( context.localUtil.Format( A1216LotCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLotCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLotCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo T. Documento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Moneda", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLotMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A225LotMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLotMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A225LotMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A225LotMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLotMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLotMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Dia", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLotDia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1217LotDia), 2, 0, ".", "")), StringUtil.LTrim( ((edtLotDia_Enabled!=0) ? context.localUtil.Format( (decimal)(A1217LotDia), "Z9") : context.localUtil.Format( (decimal)(A1217LotDia), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLotDia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLotDia_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo condicion pago", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtConpcod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConpcod_Enabled!=0) ? context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A137Conpcod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConpcod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConpcod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Importe", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLotImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A1218LotImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtLotImporte_Enabled!=0) ? context.localUtil.Format( A1218LotImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1218LotImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLotImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLotImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Codigo Producto", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Estado", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTALOTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLotSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1219LotSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtLotSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1219LotSts), "9") : context.localUtil.Format( (decimal)(A1219LotSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLotSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLotSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTALOTES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTALOTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLVENTALOTES.htm");
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
            Z224LotCliCod = cgiGet( "Z224LotCliCod");
            Z1217LotDia = (short)(context.localUtil.CToN( cgiGet( "Z1217LotDia"), ".", ","));
            Z1218LotImporte = context.localUtil.CToN( cgiGet( "Z1218LotImporte"), ".", ",");
            Z1219LotSts = (short)(context.localUtil.CToN( cgiGet( "Z1219LotSts"), ".", ","));
            Z149TipCod = cgiGet( "Z149TipCod");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z225LotMonCod = (int)(context.localUtil.CToN( cgiGet( "Z225LotMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A224LotCliCod = cgiGet( edtLotCliCod_Internalname);
            AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
            A1216LotCliDsc = cgiGet( edtLotCliDsc_Internalname);
            AssignAttri("", false, "A1216LotCliDsc", A1216LotCliDsc);
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLotMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLotMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOTMONCOD");
               AnyError = 1;
               GX_FocusControl = edtLotMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A225LotMonCod = 0;
               AssignAttri("", false, "A225LotMonCod", StringUtil.LTrimStr( (decimal)(A225LotMonCod), 6, 0));
            }
            else
            {
               A225LotMonCod = (int)(context.localUtil.CToN( cgiGet( edtLotMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A225LotMonCod", StringUtil.LTrimStr( (decimal)(A225LotMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLotDia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLotDia_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOTDIA");
               AnyError = 1;
               GX_FocusControl = edtLotDia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1217LotDia = 0;
               AssignAttri("", false, "A1217LotDia", StringUtil.LTrimStr( (decimal)(A1217LotDia), 2, 0));
            }
            else
            {
               A1217LotDia = (short)(context.localUtil.CToN( cgiGet( edtLotDia_Internalname), ".", ","));
               AssignAttri("", false, "A1217LotDia", StringUtil.LTrimStr( (decimal)(A1217LotDia), 2, 0));
            }
            A137Conpcod = (int)(context.localUtil.CToN( cgiGet( edtConpcod_Internalname), ".", ","));
            n137Conpcod = false;
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtLotImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLotImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOTIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtLotImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1218LotImporte = 0;
               AssignAttri("", false, "A1218LotImporte", StringUtil.LTrimStr( A1218LotImporte, 15, 2));
            }
            else
            {
               A1218LotImporte = context.localUtil.CToN( cgiGet( edtLotImporte_Internalname), ".", ",");
               AssignAttri("", false, "A1218LotImporte", StringUtil.LTrimStr( A1218LotImporte, 15, 2));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLotSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLotSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOTSTS");
               AnyError = 1;
               GX_FocusControl = edtLotSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1219LotSts = 0;
               AssignAttri("", false, "A1219LotSts", StringUtil.Str( (decimal)(A1219LotSts), 1, 0));
            }
            else
            {
               A1219LotSts = (short)(context.localUtil.CToN( cgiGet( edtLotSts_Internalname), ".", ","));
               AssignAttri("", false, "A1219LotSts", StringUtil.Str( (decimal)(A1219LotSts), 1, 0));
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
               A224LotCliCod = GetPar( "LotCliCod");
               AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
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
               InitAll2X100( ) ;
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
         DisableAttributes2X100( ) ;
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

      protected void CONFIRM_2X0( )
      {
         BeforeValidate2X100( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2X100( ) ;
            }
            else
            {
               CheckExtendedTable2X100( ) ;
               if ( AnyError == 0 )
               {
                  ZM2X100( 2) ;
                  ZM2X100( 3) ;
                  ZM2X100( 4) ;
                  ZM2X100( 5) ;
               }
               CloseExtendedTableCursors2X100( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2X0( ) ;
         }
      }

      protected void ResetCaption2X0( )
      {
      }

      protected void ZM2X100( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1217LotDia = T002X3_A1217LotDia[0];
               Z1218LotImporte = T002X3_A1218LotImporte[0];
               Z1219LotSts = T002X3_A1219LotSts[0];
               Z149TipCod = T002X3_A149TipCod[0];
               Z28ProdCod = T002X3_A28ProdCod[0];
               Z225LotMonCod = T002X3_A225LotMonCod[0];
            }
            else
            {
               Z1217LotDia = A1217LotDia;
               Z1218LotImporte = A1218LotImporte;
               Z1219LotSts = A1219LotSts;
               Z149TipCod = A149TipCod;
               Z28ProdCod = A28ProdCod;
               Z225LotMonCod = A225LotMonCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1217LotDia = A1217LotDia;
            Z1218LotImporte = A1218LotImporte;
            Z1219LotSts = A1219LotSts;
            Z149TipCod = A149TipCod;
            Z28ProdCod = A28ProdCod;
            Z224LotCliCod = A224LotCliCod;
            Z225LotMonCod = A225LotMonCod;
            Z1216LotCliDsc = A1216LotCliDsc;
            Z137Conpcod = A137Conpcod;
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

      protected void Load2X100( )
      {
         /* Using cursor T002X8 */
         pr_default.execute(6, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound100 = 1;
            A1216LotCliDsc = T002X8_A1216LotCliDsc[0];
            AssignAttri("", false, "A1216LotCliDsc", A1216LotCliDsc);
            A1217LotDia = T002X8_A1217LotDia[0];
            AssignAttri("", false, "A1217LotDia", StringUtil.LTrimStr( (decimal)(A1217LotDia), 2, 0));
            A1218LotImporte = T002X8_A1218LotImporte[0];
            AssignAttri("", false, "A1218LotImporte", StringUtil.LTrimStr( A1218LotImporte, 15, 2));
            A1219LotSts = T002X8_A1219LotSts[0];
            AssignAttri("", false, "A1219LotSts", StringUtil.Str( (decimal)(A1219LotSts), 1, 0));
            A149TipCod = T002X8_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A28ProdCod = T002X8_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A225LotMonCod = T002X8_A225LotMonCod[0];
            AssignAttri("", false, "A225LotMonCod", StringUtil.LTrimStr( (decimal)(A225LotMonCod), 6, 0));
            A137Conpcod = T002X8_A137Conpcod[0];
            n137Conpcod = T002X8_n137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            ZM2X100( -1) ;
         }
         pr_default.close(6);
         OnLoadActions2X100( ) ;
      }

      protected void OnLoadActions2X100( )
      {
      }

      protected void CheckExtendedTable2X100( )
      {
         nIsDirty_100 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002X6 */
         pr_default.execute(4, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Clientes'.", "ForeignKeyNotFound", 1, "LOTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLotCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1216LotCliDsc = T002X6_A1216LotCliDsc[0];
         AssignAttri("", false, "A1216LotCliDsc", A1216LotCliDsc);
         A137Conpcod = T002X6_A137Conpcod[0];
         n137Conpcod = T002X6_n137Conpcod[0];
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         pr_default.close(4);
         /* Using cursor T002X4 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002X7 */
         pr_default.execute(5, new Object[] {A225LotMonCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LOTMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLotMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T002X5 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2X100( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A224LotCliCod )
      {
         /* Using cursor T002X9 */
         pr_default.execute(7, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Clientes'.", "ForeignKeyNotFound", 1, "LOTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLotCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1216LotCliDsc = T002X9_A1216LotCliDsc[0];
         AssignAttri("", false, "A1216LotCliDsc", A1216LotCliDsc);
         A137Conpcod = T002X9_A137Conpcod[0];
         n137Conpcod = T002X9_n137Conpcod[0];
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1216LotCliDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_2( string A149TipCod )
      {
         /* Using cursor T002X10 */
         pr_default.execute(8, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_5( int A225LotMonCod )
      {
         /* Using cursor T002X11 */
         pr_default.execute(9, new Object[] {A225LotMonCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LOTMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLotMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_3( string A28ProdCod )
      {
         /* Using cursor T002X12 */
         pr_default.execute(10, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey2X100( )
      {
         /* Using cursor T002X13 */
         pr_default.execute(11, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound100 = 1;
         }
         else
         {
            RcdFound100 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002X3 */
         pr_default.execute(1, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2X100( 1) ;
            RcdFound100 = 1;
            A1217LotDia = T002X3_A1217LotDia[0];
            AssignAttri("", false, "A1217LotDia", StringUtil.LTrimStr( (decimal)(A1217LotDia), 2, 0));
            A1218LotImporte = T002X3_A1218LotImporte[0];
            AssignAttri("", false, "A1218LotImporte", StringUtil.LTrimStr( A1218LotImporte, 15, 2));
            A1219LotSts = T002X3_A1219LotSts[0];
            AssignAttri("", false, "A1219LotSts", StringUtil.Str( (decimal)(A1219LotSts), 1, 0));
            A149TipCod = T002X3_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A28ProdCod = T002X3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A224LotCliCod = T002X3_A224LotCliCod[0];
            AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
            A225LotMonCod = T002X3_A225LotMonCod[0];
            AssignAttri("", false, "A225LotMonCod", StringUtil.LTrimStr( (decimal)(A225LotMonCod), 6, 0));
            Z224LotCliCod = A224LotCliCod;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2X100( ) ;
            if ( AnyError == 1 )
            {
               RcdFound100 = 0;
               InitializeNonKey2X100( ) ;
            }
            Gx_mode = sMode100;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound100 = 0;
            InitializeNonKey2X100( ) ;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode100;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2X100( ) ;
         if ( RcdFound100 == 0 )
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
         RcdFound100 = 0;
         /* Using cursor T002X14 */
         pr_default.execute(12, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T002X14_A224LotCliCod[0], A224LotCliCod) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T002X14_A224LotCliCod[0], A224LotCliCod) > 0 ) ) )
            {
               A224LotCliCod = T002X14_A224LotCliCod[0];
               AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
               RcdFound100 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound100 = 0;
         /* Using cursor T002X15 */
         pr_default.execute(13, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002X15_A224LotCliCod[0], A224LotCliCod) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002X15_A224LotCliCod[0], A224LotCliCod) < 0 ) ) )
            {
               A224LotCliCod = T002X15_A224LotCliCod[0];
               AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
               RcdFound100 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2X100( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLotCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2X100( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound100 == 1 )
            {
               if ( StringUtil.StrCmp(A224LotCliCod, Z224LotCliCod) != 0 )
               {
                  A224LotCliCod = Z224LotCliCod;
                  AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOTCLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtLotCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLotCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2X100( ) ;
                  GX_FocusControl = edtLotCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A224LotCliCod, Z224LotCliCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLotCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2X100( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOTCLICOD");
                     AnyError = 1;
                     GX_FocusControl = edtLotCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLotCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2X100( ) ;
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
         if ( StringUtil.StrCmp(A224LotCliCod, Z224LotCliCod) != 0 )
         {
            A224LotCliCod = Z224LotCliCod;
            AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLotCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLotCliCod_Internalname;
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
         GetKey2X100( ) ;
         if ( RcdFound100 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LOTCLICOD");
               AnyError = 1;
               GX_FocusControl = edtLotCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A224LotCliCod, Z224LotCliCod) != 0 )
            {
               A224LotCliCod = Z224LotCliCod;
               AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LOTCLICOD");
               AnyError = 1;
               GX_FocusControl = edtLotCliCod_Internalname;
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
            if ( StringUtil.StrCmp(A224LotCliCod, Z224LotCliCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOTCLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtLotCliCod_Internalname;
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
         context.RollbackDataStores("clventalotes",pr_default);
         GX_FocusControl = edtTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2X0( ) ;
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
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LOTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLotCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2X100( ) ;
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2X100( ) ;
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
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCod_Internalname;
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
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCod_Internalname;
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
         ScanStart2X100( ) ;
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound100 != 0 )
            {
               ScanNext2X100( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2X100( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2X100( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002X2 */
            pr_default.execute(0, new Object[] {A224LotCliCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTALOTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1217LotDia != T002X2_A1217LotDia[0] ) || ( Z1218LotImporte != T002X2_A1218LotImporte[0] ) || ( Z1219LotSts != T002X2_A1219LotSts[0] ) || ( StringUtil.StrCmp(Z149TipCod, T002X2_A149TipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z28ProdCod, T002X2_A28ProdCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z225LotMonCod != T002X2_A225LotMonCod[0] ) )
            {
               if ( Z1217LotDia != T002X2_A1217LotDia[0] )
               {
                  GXUtil.WriteLog("clventalotes:[seudo value changed for attri]"+"LotDia");
                  GXUtil.WriteLogRaw("Old: ",Z1217LotDia);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A1217LotDia[0]);
               }
               if ( Z1218LotImporte != T002X2_A1218LotImporte[0] )
               {
                  GXUtil.WriteLog("clventalotes:[seudo value changed for attri]"+"LotImporte");
                  GXUtil.WriteLogRaw("Old: ",Z1218LotImporte);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A1218LotImporte[0]);
               }
               if ( Z1219LotSts != T002X2_A1219LotSts[0] )
               {
                  GXUtil.WriteLog("clventalotes:[seudo value changed for attri]"+"LotSts");
                  GXUtil.WriteLogRaw("Old: ",Z1219LotSts);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A1219LotSts[0]);
               }
               if ( StringUtil.StrCmp(Z149TipCod, T002X2_A149TipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventalotes:[seudo value changed for attri]"+"TipCod");
                  GXUtil.WriteLogRaw("Old: ",Z149TipCod);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A149TipCod[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T002X2_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventalotes:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A28ProdCod[0]);
               }
               if ( Z225LotMonCod != T002X2_A225LotMonCod[0] )
               {
                  GXUtil.WriteLog("clventalotes:[seudo value changed for attri]"+"LotMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z225LotMonCod);
                  GXUtil.WriteLogRaw("Current: ",T002X2_A225LotMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLVENTALOTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2X100( )
      {
         BeforeValidate2X100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X100( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2X100( 0) ;
            CheckOptimisticConcurrency2X100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2X100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X16 */
                     pr_default.execute(14, new Object[] {A1217LotDia, A1218LotImporte, A1219LotSts, A149TipCod, A28ProdCod, A224LotCliCod, A225LotMonCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CLVENTALOTES");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption2X0( ) ;
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
               Load2X100( ) ;
            }
            EndLevel2X100( ) ;
         }
         CloseExtendedTableCursors2X100( ) ;
      }

      protected void Update2X100( )
      {
         BeforeValidate2X100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X100( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2X100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002X17 */
                     pr_default.execute(15, new Object[] {A1217LotDia, A1218LotImporte, A1219LotSts, A149TipCod, A28ProdCod, A225LotMonCod, A224LotCliCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CLVENTALOTES");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTALOTES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2X100( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2X0( ) ;
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
            EndLevel2X100( ) ;
         }
         CloseExtendedTableCursors2X100( ) ;
      }

      protected void DeferredUpdate2X100( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2X100( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X100( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2X100( ) ;
            AfterConfirm2X100( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2X100( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002X18 */
                  pr_default.execute(16, new Object[] {A224LotCliCod});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CLVENTALOTES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound100 == 0 )
                        {
                           InitAll2X100( ) ;
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
                        ResetCaption2X0( ) ;
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
         sMode100 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2X100( ) ;
         Gx_mode = sMode100;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2X100( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002X19 */
            pr_default.execute(17, new Object[] {A224LotCliCod});
            A1216LotCliDsc = T002X19_A1216LotCliDsc[0];
            AssignAttri("", false, "A1216LotCliDsc", A1216LotCliDsc);
            A137Conpcod = T002X19_A137Conpcod[0];
            n137Conpcod = T002X19_n137Conpcod[0];
            AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
            pr_default.close(17);
         }
      }

      protected void EndLevel2X100( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2X100( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            context.CommitDataStores("clventalotes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            context.RollbackDataStores("clventalotes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2X100( )
      {
         /* Using cursor T002X20 */
         pr_default.execute(18);
         RcdFound100 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound100 = 1;
            A224LotCliCod = T002X20_A224LotCliCod[0];
            AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2X100( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound100 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound100 = 1;
            A224LotCliCod = T002X20_A224LotCliCod[0];
            AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
         }
      }

      protected void ScanEnd2X100( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2X100( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2X100( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2X100( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2X100( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2X100( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2X100( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2X100( )
      {
         edtLotCliCod_Enabled = 0;
         AssignProp("", false, edtLotCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLotCliCod_Enabled), 5, 0), true);
         edtLotCliDsc_Enabled = 0;
         AssignProp("", false, edtLotCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLotCliDsc_Enabled), 5, 0), true);
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtLotMonCod_Enabled = 0;
         AssignProp("", false, edtLotMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLotMonCod_Enabled), 5, 0), true);
         edtLotDia_Enabled = 0;
         AssignProp("", false, edtLotDia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLotDia_Enabled), 5, 0), true);
         edtConpcod_Enabled = 0;
         AssignProp("", false, edtConpcod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConpcod_Enabled), 5, 0), true);
         edtLotImporte_Enabled = 0;
         AssignProp("", false, edtLotImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLotImporte_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtLotSts_Enabled = 0;
         AssignProp("", false, edtLotSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLotSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2X100( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2X0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810244990", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clventalotes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z224LotCliCod", StringUtil.RTrim( Z224LotCliCod));
         GxWebStd.gx_hidden_field( context, "Z1217LotDia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1217LotDia), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1218LotImporte", StringUtil.LTrim( StringUtil.NToC( Z1218LotImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1219LotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1219LotSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z225LotMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z225LotMonCod), 6, 0, ".", "")));
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
         return formatLink("clventalotes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLVENTALOTES" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLVENTALOTES" ;
      }

      protected void InitializeNonKey2X100( )
      {
         A1216LotCliDsc = "";
         AssignAttri("", false, "A1216LotCliDsc", A1216LotCliDsc);
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A225LotMonCod = 0;
         AssignAttri("", false, "A225LotMonCod", StringUtil.LTrimStr( (decimal)(A225LotMonCod), 6, 0));
         A1217LotDia = 0;
         AssignAttri("", false, "A1217LotDia", StringUtil.LTrimStr( (decimal)(A1217LotDia), 2, 0));
         A137Conpcod = 0;
         n137Conpcod = false;
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrimStr( (decimal)(A137Conpcod), 6, 0));
         A1218LotImporte = 0;
         AssignAttri("", false, "A1218LotImporte", StringUtil.LTrimStr( A1218LotImporte, 15, 2));
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A1219LotSts = 0;
         AssignAttri("", false, "A1219LotSts", StringUtil.Str( (decimal)(A1219LotSts), 1, 0));
         Z1217LotDia = 0;
         Z1218LotImporte = 0;
         Z1219LotSts = 0;
         Z149TipCod = "";
         Z28ProdCod = "";
         Z225LotMonCod = 0;
      }

      protected void InitAll2X100( )
      {
         A224LotCliCod = "";
         AssignAttri("", false, "A224LotCliCod", A224LotCliCod);
         InitializeNonKey2X100( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810244997", true, true);
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
         context.AddJavascriptSource("clventalotes.js", "?202281810244998", false, true);
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
         edtLotCliCod_Internalname = "LOTCLICOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLotCliDsc_Internalname = "LOTCLIDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipCod_Internalname = "TIPCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLotMonCod_Internalname = "LOTMONCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLotDia_Internalname = "LOTDIA";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtConpcod_Internalname = "CONPCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLotImporte_Internalname = "LOTIMPORTE";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLotSts_Internalname = "LOTSTS";
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
         Form.Caption = "CLVENTALOTES";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLotSts_Jsonclick = "";
         edtLotSts_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         edtLotImporte_Jsonclick = "";
         edtLotImporte_Enabled = 1;
         edtConpcod_Jsonclick = "";
         edtConpcod_Enabled = 0;
         edtLotDia_Jsonclick = "";
         edtLotDia_Enabled = 1;
         edtLotMonCod_Jsonclick = "";
         edtLotMonCod_Enabled = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
         edtLotCliDsc_Jsonclick = "";
         edtLotCliDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLotCliCod_Jsonclick = "";
         edtLotCliCod_Enabled = 1;
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
         GX_FocusControl = edtTipCod_Internalname;
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

      public void Valid_Lotclicod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002X19 */
         pr_default.execute(17, new Object[] {A224LotCliCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Clientes'.", "ForeignKeyNotFound", 1, "LOTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLotCliCod_Internalname;
         }
         A1216LotCliDsc = T002X19_A1216LotCliDsc[0];
         A137Conpcod = T002X19_A137Conpcod[0];
         n137Conpcod = T002X19_n137Conpcod[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A149TipCod", StringUtil.RTrim( A149TipCod));
         AssignAttri("", false, "A225LotMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A225LotMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1217LotDia", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1217LotDia), 2, 0, ".", "")));
         AssignAttri("", false, "A1218LotImporte", StringUtil.LTrim( StringUtil.NToC( A1218LotImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A1219LotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1219LotSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1216LotCliDsc", StringUtil.RTrim( A1216LotCliDsc));
         AssignAttri("", false, "A137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137Conpcod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z224LotCliCod", StringUtil.RTrim( Z224LotCliCod));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z225LotMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z225LotMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1217LotDia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1217LotDia), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1218LotImporte", StringUtil.LTrim( StringUtil.NToC( Z1218LotImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z1219LotSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1219LotSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1216LotCliDsc", StringUtil.RTrim( Z1216LotCliDsc));
         GxWebStd.gx_hidden_field( context, "Z137Conpcod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137Conpcod), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tipcod( )
      {
         /* Using cursor T002X21 */
         pr_default.execute(19, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Lotmoncod( )
      {
         /* Using cursor T002X22 */
         pr_default.execute(20, new Object[] {A225LotMonCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LOTMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLotMonCod_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T002X23 */
         pr_default.execute(21, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         pr_default.close(21);
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
         setEventMetadata("VALID_LOTCLICOD","{handler:'Valid_Lotclicod',iparms:[{av:'A224LotCliCod',fld:'LOTCLICOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LOTCLICOD",",oparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A225LotMonCod',fld:'LOTMONCOD',pic:'ZZZZZ9'},{av:'A1217LotDia',fld:'LOTDIA',pic:'Z9'},{av:'A1218LotImporte',fld:'LOTIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A1219LotSts',fld:'LOTSTS',pic:'9'},{av:'A1216LotCliDsc',fld:'LOTCLIDSC',pic:''},{av:'A137Conpcod',fld:'CONPCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z224LotCliCod'},{av:'Z149TipCod'},{av:'Z225LotMonCod'},{av:'Z1217LotDia'},{av:'Z1218LotImporte'},{av:'Z28ProdCod'},{av:'Z1219LotSts'},{av:'Z1216LotCliDsc'},{av:'Z137Conpcod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_LOTMONCOD","{handler:'Valid_Lotmoncod',iparms:[{av:'A225LotMonCod',fld:'LOTMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LOTMONCOD",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(17);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z224LotCliCod = "";
         Z149TipCod = "";
         Z28ProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A224LotCliCod = "";
         A149TipCod = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1216LotCliDsc = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
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
         Z1216LotCliDsc = "";
         T002X8_A1216LotCliDsc = new string[] {""} ;
         T002X8_A1217LotDia = new short[1] ;
         T002X8_A1218LotImporte = new decimal[1] ;
         T002X8_A1219LotSts = new short[1] ;
         T002X8_A149TipCod = new string[] {""} ;
         T002X8_A28ProdCod = new string[] {""} ;
         T002X8_A224LotCliCod = new string[] {""} ;
         T002X8_A225LotMonCod = new int[1] ;
         T002X8_A137Conpcod = new int[1] ;
         T002X8_n137Conpcod = new bool[] {false} ;
         T002X6_A1216LotCliDsc = new string[] {""} ;
         T002X6_A137Conpcod = new int[1] ;
         T002X6_n137Conpcod = new bool[] {false} ;
         T002X4_A149TipCod = new string[] {""} ;
         T002X7_A225LotMonCod = new int[1] ;
         T002X5_A28ProdCod = new string[] {""} ;
         T002X9_A1216LotCliDsc = new string[] {""} ;
         T002X9_A137Conpcod = new int[1] ;
         T002X9_n137Conpcod = new bool[] {false} ;
         T002X10_A149TipCod = new string[] {""} ;
         T002X11_A225LotMonCod = new int[1] ;
         T002X12_A28ProdCod = new string[] {""} ;
         T002X13_A224LotCliCod = new string[] {""} ;
         T002X3_A1217LotDia = new short[1] ;
         T002X3_A1218LotImporte = new decimal[1] ;
         T002X3_A1219LotSts = new short[1] ;
         T002X3_A149TipCod = new string[] {""} ;
         T002X3_A28ProdCod = new string[] {""} ;
         T002X3_A224LotCliCod = new string[] {""} ;
         T002X3_A225LotMonCod = new int[1] ;
         sMode100 = "";
         T002X14_A224LotCliCod = new string[] {""} ;
         T002X15_A224LotCliCod = new string[] {""} ;
         T002X2_A1217LotDia = new short[1] ;
         T002X2_A1218LotImporte = new decimal[1] ;
         T002X2_A1219LotSts = new short[1] ;
         T002X2_A149TipCod = new string[] {""} ;
         T002X2_A28ProdCod = new string[] {""} ;
         T002X2_A224LotCliCod = new string[] {""} ;
         T002X2_A225LotMonCod = new int[1] ;
         T002X19_A1216LotCliDsc = new string[] {""} ;
         T002X19_A137Conpcod = new int[1] ;
         T002X19_n137Conpcod = new bool[] {false} ;
         T002X20_A224LotCliCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ224LotCliCod = "";
         ZZ149TipCod = "";
         ZZ28ProdCod = "";
         ZZ1216LotCliDsc = "";
         T002X21_A149TipCod = new string[] {""} ;
         T002X22_A225LotMonCod = new int[1] ;
         T002X23_A28ProdCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clventalotes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clventalotes__default(),
            new Object[][] {
                new Object[] {
               T002X2_A1217LotDia, T002X2_A1218LotImporte, T002X2_A1219LotSts, T002X2_A149TipCod, T002X2_A28ProdCod, T002X2_A224LotCliCod, T002X2_A225LotMonCod
               }
               , new Object[] {
               T002X3_A1217LotDia, T002X3_A1218LotImporte, T002X3_A1219LotSts, T002X3_A149TipCod, T002X3_A28ProdCod, T002X3_A224LotCliCod, T002X3_A225LotMonCod
               }
               , new Object[] {
               T002X4_A149TipCod
               }
               , new Object[] {
               T002X5_A28ProdCod
               }
               , new Object[] {
               T002X6_A1216LotCliDsc, T002X6_A137Conpcod, T002X6_n137Conpcod
               }
               , new Object[] {
               T002X7_A225LotMonCod
               }
               , new Object[] {
               T002X8_A1216LotCliDsc, T002X8_A1217LotDia, T002X8_A1218LotImporte, T002X8_A1219LotSts, T002X8_A149TipCod, T002X8_A28ProdCod, T002X8_A224LotCliCod, T002X8_A225LotMonCod, T002X8_A137Conpcod, T002X8_n137Conpcod
               }
               , new Object[] {
               T002X9_A1216LotCliDsc, T002X9_A137Conpcod, T002X9_n137Conpcod
               }
               , new Object[] {
               T002X10_A149TipCod
               }
               , new Object[] {
               T002X11_A225LotMonCod
               }
               , new Object[] {
               T002X12_A28ProdCod
               }
               , new Object[] {
               T002X13_A224LotCliCod
               }
               , new Object[] {
               T002X14_A224LotCliCod
               }
               , new Object[] {
               T002X15_A224LotCliCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002X19_A1216LotCliDsc, T002X19_A137Conpcod, T002X19_n137Conpcod
               }
               , new Object[] {
               T002X20_A224LotCliCod
               }
               , new Object[] {
               T002X21_A149TipCod
               }
               , new Object[] {
               T002X22_A225LotMonCod
               }
               , new Object[] {
               T002X23_A28ProdCod
               }
            }
         );
      }

      private short Z1217LotDia ;
      private short Z1219LotSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1217LotDia ;
      private short A1219LotSts ;
      private short GX_JID ;
      private short RcdFound100 ;
      private short nIsDirty_100 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1217LotDia ;
      private short ZZ1219LotSts ;
      private int Z225LotMonCod ;
      private int A225LotMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLotCliCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLotCliDsc_Enabled ;
      private int edtTipCod_Enabled ;
      private int edtLotMonCod_Enabled ;
      private int edtLotDia_Enabled ;
      private int A137Conpcod ;
      private int edtConpcod_Enabled ;
      private int edtLotImporte_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtLotSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z137Conpcod ;
      private int idxLst ;
      private int ZZ225LotMonCod ;
      private int ZZ137Conpcod ;
      private decimal Z1218LotImporte ;
      private decimal A1218LotImporte ;
      private decimal ZZ1218LotImporte ;
      private string sPrefix ;
      private string Z224LotCliCod ;
      private string Z149TipCod ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A224LotCliCod ;
      private string A149TipCod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLotCliCod_Internalname ;
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
      private string edtLotCliCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLotCliDsc_Internalname ;
      private string A1216LotCliDsc ;
      private string edtLotCliDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipCod_Internalname ;
      private string edtTipCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLotMonCod_Internalname ;
      private string edtLotMonCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLotDia_Internalname ;
      private string edtLotDia_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtConpcod_Internalname ;
      private string edtConpcod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLotImporte_Internalname ;
      private string edtLotImporte_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLotSts_Internalname ;
      private string edtLotSts_Jsonclick ;
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
      private string Z1216LotCliDsc ;
      private string sMode100 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ224LotCliCod ;
      private string ZZ149TipCod ;
      private string ZZ28ProdCod ;
      private string ZZ1216LotCliDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n137Conpcod ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002X8_A1216LotCliDsc ;
      private short[] T002X8_A1217LotDia ;
      private decimal[] T002X8_A1218LotImporte ;
      private short[] T002X8_A1219LotSts ;
      private string[] T002X8_A149TipCod ;
      private string[] T002X8_A28ProdCod ;
      private string[] T002X8_A224LotCliCod ;
      private int[] T002X8_A225LotMonCod ;
      private int[] T002X8_A137Conpcod ;
      private bool[] T002X8_n137Conpcod ;
      private string[] T002X6_A1216LotCliDsc ;
      private int[] T002X6_A137Conpcod ;
      private bool[] T002X6_n137Conpcod ;
      private string[] T002X4_A149TipCod ;
      private int[] T002X7_A225LotMonCod ;
      private string[] T002X5_A28ProdCod ;
      private string[] T002X9_A1216LotCliDsc ;
      private int[] T002X9_A137Conpcod ;
      private bool[] T002X9_n137Conpcod ;
      private string[] T002X10_A149TipCod ;
      private int[] T002X11_A225LotMonCod ;
      private string[] T002X12_A28ProdCod ;
      private string[] T002X13_A224LotCliCod ;
      private short[] T002X3_A1217LotDia ;
      private decimal[] T002X3_A1218LotImporte ;
      private short[] T002X3_A1219LotSts ;
      private string[] T002X3_A149TipCod ;
      private string[] T002X3_A28ProdCod ;
      private string[] T002X3_A224LotCliCod ;
      private int[] T002X3_A225LotMonCod ;
      private string[] T002X14_A224LotCliCod ;
      private string[] T002X15_A224LotCliCod ;
      private short[] T002X2_A1217LotDia ;
      private decimal[] T002X2_A1218LotImporte ;
      private short[] T002X2_A1219LotSts ;
      private string[] T002X2_A149TipCod ;
      private string[] T002X2_A28ProdCod ;
      private string[] T002X2_A224LotCliCod ;
      private int[] T002X2_A225LotMonCod ;
      private string[] T002X19_A1216LotCliDsc ;
      private int[] T002X19_A137Conpcod ;
      private bool[] T002X19_n137Conpcod ;
      private string[] T002X20_A224LotCliCod ;
      private string[] T002X21_A149TipCod ;
      private int[] T002X22_A225LotMonCod ;
      private string[] T002X23_A28ProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clventalotes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clventalotes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002X8;
        prmT002X8 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X6;
        prmT002X6 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X4;
        prmT002X4 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT002X7;
        prmT002X7 = new Object[] {
        new ParDef("@LotMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002X5;
        prmT002X5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002X9;
        prmT002X9 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X10;
        prmT002X10 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT002X11;
        prmT002X11 = new Object[] {
        new ParDef("@LotMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002X12;
        prmT002X12 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002X13;
        prmT002X13 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X3;
        prmT002X3 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X14;
        prmT002X14 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X15;
        prmT002X15 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X2;
        prmT002X2 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X16;
        prmT002X16 = new Object[] {
        new ParDef("@LotDia",GXType.Int16,2,0) ,
        new ParDef("@LotImporte",GXType.Decimal,15,2) ,
        new ParDef("@LotSts",GXType.Int16,1,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@LotCliCod",GXType.NChar,20,0) ,
        new ParDef("@LotMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002X17;
        prmT002X17 = new Object[] {
        new ParDef("@LotDia",GXType.Int16,2,0) ,
        new ParDef("@LotImporte",GXType.Decimal,15,2) ,
        new ParDef("@LotSts",GXType.Int16,1,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@LotMonCod",GXType.Int32,6,0) ,
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X18;
        prmT002X18 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X20;
        prmT002X20 = new Object[] {
        };
        Object[] prmT002X19;
        prmT002X19 = new Object[] {
        new ParDef("@LotCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002X21;
        prmT002X21 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT002X22;
        prmT002X22 = new Object[] {
        new ParDef("@LotMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002X23;
        prmT002X23 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002X2", "SELECT [LotDia], [LotImporte], [LotSts], [TipCod], [ProdCod], [LotCliCod] AS LotCliCod, [LotMonCod] AS LotMonCod FROM [CLVENTALOTES] WITH (UPDLOCK) WHERE [LotCliCod] = @LotCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X3", "SELECT [LotDia], [LotImporte], [LotSts], [TipCod], [ProdCod], [LotCliCod] AS LotCliCod, [LotMonCod] AS LotMonCod FROM [CLVENTALOTES] WHERE [LotCliCod] = @LotCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X4", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X5", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X6", "SELECT [CliDsc] AS LotCliDsc, [Conpcod] FROM [CLCLIENTES] WHERE [CliCod] = @LotCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X7", "SELECT [MonCod] AS LotMonCod FROM [CMONEDAS] WHERE [MonCod] = @LotMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X8", "SELECT T2.[CliDsc] AS LotCliDsc, TM1.[LotDia], TM1.[LotImporte], TM1.[LotSts], TM1.[TipCod], TM1.[ProdCod], TM1.[LotCliCod] AS LotCliCod, TM1.[LotMonCod] AS LotMonCod, T2.[Conpcod] FROM ([CLVENTALOTES] TM1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = TM1.[LotCliCod]) WHERE TM1.[LotCliCod] = @LotCliCod ORDER BY TM1.[LotCliCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X9", "SELECT [CliDsc] AS LotCliDsc, [Conpcod] FROM [CLCLIENTES] WHERE [CliCod] = @LotCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X10", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X11", "SELECT [MonCod] AS LotMonCod FROM [CMONEDAS] WHERE [MonCod] = @LotMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X12", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X13", "SELECT [LotCliCod] AS LotCliCod FROM [CLVENTALOTES] WHERE [LotCliCod] = @LotCliCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X14", "SELECT TOP 1 [LotCliCod] AS LotCliCod FROM [CLVENTALOTES] WHERE ( [LotCliCod] > @LotCliCod) ORDER BY [LotCliCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X15", "SELECT TOP 1 [LotCliCod] AS LotCliCod FROM [CLVENTALOTES] WHERE ( [LotCliCod] < @LotCliCod) ORDER BY [LotCliCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002X16", "INSERT INTO [CLVENTALOTES]([LotDia], [LotImporte], [LotSts], [TipCod], [ProdCod], [LotCliCod], [LotMonCod]) VALUES(@LotDia, @LotImporte, @LotSts, @TipCod, @ProdCod, @LotCliCod, @LotMonCod)", GxErrorMask.GX_NOMASK,prmT002X16)
           ,new CursorDef("T002X17", "UPDATE [CLVENTALOTES] SET [LotDia]=@LotDia, [LotImporte]=@LotImporte, [LotSts]=@LotSts, [TipCod]=@TipCod, [ProdCod]=@ProdCod, [LotMonCod]=@LotMonCod  WHERE [LotCliCod] = @LotCliCod", GxErrorMask.GX_NOMASK,prmT002X17)
           ,new CursorDef("T002X18", "DELETE FROM [CLVENTALOTES]  WHERE [LotCliCod] = @LotCliCod", GxErrorMask.GX_NOMASK,prmT002X18)
           ,new CursorDef("T002X19", "SELECT [CliDsc] AS LotCliDsc, [Conpcod] FROM [CLCLIENTES] WHERE [CliCod] = @LotCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X20", "SELECT [LotCliCod] AS LotCliCod FROM [CLVENTALOTES] ORDER BY [LotCliCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002X20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X21", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X22", "SELECT [MonCod] AS LotMonCod FROM [CMONEDAS] WHERE [MonCod] = @LotMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002X23", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002X23,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
