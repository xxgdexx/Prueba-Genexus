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
   public class cldocumentosdet : GXDataArea
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
            A191ImpItem = (long)(NumberUtil.Val( GetPar( "ImpItem"), "."));
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A191ImpItem) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A198ImpDProdCod = GetPar( "ImpDProdCod");
            AssignAttri("", false, "A198ImpDProdCod", A198ImpDProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A198ImpDProdCod) ;
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
            Form.Meta.addItem("description", "Documentos Afectos IGV - Detalles", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cldocumentosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cldocumentosdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLDOCUMENTOSDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Item", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A191ImpItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtImpItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A191ImpItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A191ImpItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Detalle Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ImpDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A197ImpDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A197ImpDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDProdCod_Internalname, StringUtil.RTrim( A198ImpDProdCod), StringUtil.RTrim( context.localUtil.Format( A198ImpDProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cantidad", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1025ImpDCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtImpDCant_Enabled!=0) ? context.localUtil.Format( A1025ImpDCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1025ImpDCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Precio", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDPre_Internalname, StringUtil.LTrim( StringUtil.NToC( A1032ImpDPre, 17, 4, ".", "")), StringUtil.LTrim( ((edtImpDPre_Enabled!=0) ? context.localUtil.Format( A1032ImpDPre, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1032ImpDPre, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDPre_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% Descuento 1", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDDct_Internalname, StringUtil.LTrim( StringUtil.NToC( A1026ImpDDct, 17, 2, ".", "")), StringUtil.LTrim( ((edtImpDDct_Enabled!=0) ? context.localUtil.Format( A1026ImpDDct, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1026ImpDDct, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDDct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDDct_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "% Descuento 2", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDDct2_Internalname, StringUtil.LTrim( StringUtil.NToC( A1027ImpDDct2, 17, 2, ".", "")), StringUtil.LTrim( ((edtImpDDct2_Enabled!=0) ? context.localUtil.Format( A1027ImpDDct2, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1027ImpDDct2, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDDct2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDDct2_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Observaciones", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtImpDObs_Internalname, A1029ImpDObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", 0, 1, edtImpDObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Inafecta IGV", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDIna_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1028ImpDIna), 1, 0, ".", "")), StringUtil.LTrim( ((edtImpDIna_Enabled!=0) ? context.localUtil.Format( (decimal)(A1028ImpDIna), "9") : context.localUtil.Format( (decimal)(A1028ImpDIna), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDIna_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "% Impuesto Selectivo", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOSDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDPorSel_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031ImpDPorSel), 5, 0, ".", "")), StringUtil.LTrim( ((edtImpDPorSel_Enabled!=0) ? context.localUtil.Format( (decimal)(A1031ImpDPorSel), "ZZZZ9") : context.localUtil.Format( (decimal)(A1031ImpDPorSel), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDPorSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDPorSel_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOSDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLDOCUMENTOSDET.htm");
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
            Z191ImpItem = (long)(context.localUtil.CToN( cgiGet( "Z191ImpItem"), ".", ","));
            Z197ImpDItem = (int)(context.localUtil.CToN( cgiGet( "Z197ImpDItem"), ".", ","));
            Z1025ImpDCant = context.localUtil.CToN( cgiGet( "Z1025ImpDCant"), ".", ",");
            Z1032ImpDPre = context.localUtil.CToN( cgiGet( "Z1032ImpDPre"), ".", ",");
            Z1026ImpDDct = context.localUtil.CToN( cgiGet( "Z1026ImpDDct"), ".", ",");
            Z1027ImpDDct2 = context.localUtil.CToN( cgiGet( "Z1027ImpDDct2"), ".", ",");
            Z1028ImpDIna = (short)(context.localUtil.CToN( cgiGet( "Z1028ImpDIna"), ".", ","));
            Z1031ImpDPorSel = (int)(context.localUtil.CToN( cgiGet( "Z1031ImpDPorSel"), ".", ","));
            Z198ImpDProdCod = cgiGet( "Z198ImpDProdCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPITEM");
               AnyError = 1;
               GX_FocusControl = edtImpItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A191ImpItem = 0;
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            }
            else
            {
               A191ImpItem = (long)(context.localUtil.CToN( cgiGet( edtImpItem_Internalname), ".", ","));
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDITEM");
               AnyError = 1;
               GX_FocusControl = edtImpDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A197ImpDItem = 0;
               AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
            }
            else
            {
               A197ImpDItem = (int)(context.localUtil.CToN( cgiGet( edtImpDItem_Internalname), ".", ","));
               AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
            }
            A198ImpDProdCod = StringUtil.Upper( cgiGet( edtImpDProdCod_Internalname));
            AssignAttri("", false, "A198ImpDProdCod", A198ImpDProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDCANT");
               AnyError = 1;
               GX_FocusControl = edtImpDCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1025ImpDCant = 0;
               AssignAttri("", false, "A1025ImpDCant", StringUtil.LTrimStr( A1025ImpDCant, 15, 4));
            }
            else
            {
               A1025ImpDCant = context.localUtil.CToN( cgiGet( edtImpDCant_Internalname), ".", ",");
               AssignAttri("", false, "A1025ImpDCant", StringUtil.LTrimStr( A1025ImpDCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDPre_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDPre_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDPRE");
               AnyError = 1;
               GX_FocusControl = edtImpDPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1032ImpDPre = 0;
               AssignAttri("", false, "A1032ImpDPre", StringUtil.LTrimStr( A1032ImpDPre, 15, 4));
            }
            else
            {
               A1032ImpDPre = context.localUtil.CToN( cgiGet( edtImpDPre_Internalname), ".", ",");
               AssignAttri("", false, "A1032ImpDPre", StringUtil.LTrimStr( A1032ImpDPre, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDDct_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDDct_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDDCT");
               AnyError = 1;
               GX_FocusControl = edtImpDDct_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1026ImpDDct = 0;
               AssignAttri("", false, "A1026ImpDDct", StringUtil.LTrimStr( A1026ImpDDct, 15, 2));
            }
            else
            {
               A1026ImpDDct = context.localUtil.CToN( cgiGet( edtImpDDct_Internalname), ".", ",");
               AssignAttri("", false, "A1026ImpDDct", StringUtil.LTrimStr( A1026ImpDDct, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDDct2_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDDct2_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDDCT2");
               AnyError = 1;
               GX_FocusControl = edtImpDDct2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1027ImpDDct2 = 0;
               AssignAttri("", false, "A1027ImpDDct2", StringUtil.LTrimStr( A1027ImpDDct2, 15, 2));
            }
            else
            {
               A1027ImpDDct2 = context.localUtil.CToN( cgiGet( edtImpDDct2_Internalname), ".", ",");
               AssignAttri("", false, "A1027ImpDDct2", StringUtil.LTrimStr( A1027ImpDDct2, 15, 2));
            }
            A1029ImpDObs = cgiGet( edtImpDObs_Internalname);
            AssignAttri("", false, "A1029ImpDObs", A1029ImpDObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDIna_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDIna_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDINA");
               AnyError = 1;
               GX_FocusControl = edtImpDIna_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1028ImpDIna = 0;
               AssignAttri("", false, "A1028ImpDIna", StringUtil.Str( (decimal)(A1028ImpDIna), 1, 0));
            }
            else
            {
               A1028ImpDIna = (short)(context.localUtil.CToN( cgiGet( edtImpDIna_Internalname), ".", ","));
               AssignAttri("", false, "A1028ImpDIna", StringUtil.Str( (decimal)(A1028ImpDIna), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpDPorSel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpDPorSel_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPDPORSEL");
               AnyError = 1;
               GX_FocusControl = edtImpDPorSel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1031ImpDPorSel = 0;
               AssignAttri("", false, "A1031ImpDPorSel", StringUtil.LTrimStr( (decimal)(A1031ImpDPorSel), 5, 0));
            }
            else
            {
               A1031ImpDPorSel = (int)(context.localUtil.CToN( cgiGet( edtImpDPorSel_Internalname), ".", ","));
               AssignAttri("", false, "A1031ImpDPorSel", StringUtil.LTrimStr( (decimal)(A1031ImpDPorSel), 5, 0));
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
               A191ImpItem = (long)(NumberUtil.Val( GetPar( "ImpItem"), "."));
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               A197ImpDItem = (int)(NumberUtil.Val( GetPar( "ImpDItem"), "."));
               AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
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
               InitAll2M90( ) ;
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
         DisableAttributes2M90( ) ;
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

      protected void CONFIRM_2M0( )
      {
         BeforeValidate2M90( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2M90( ) ;
            }
            else
            {
               CheckExtendedTable2M90( ) ;
               if ( AnyError == 0 )
               {
                  ZM2M90( 2) ;
                  ZM2M90( 3) ;
               }
               CloseExtendedTableCursors2M90( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2M0( ) ;
         }
      }

      protected void ResetCaption2M0( )
      {
      }

      protected void ZM2M90( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1025ImpDCant = T002M3_A1025ImpDCant[0];
               Z1032ImpDPre = T002M3_A1032ImpDPre[0];
               Z1026ImpDDct = T002M3_A1026ImpDDct[0];
               Z1027ImpDDct2 = T002M3_A1027ImpDDct2[0];
               Z1028ImpDIna = T002M3_A1028ImpDIna[0];
               Z1031ImpDPorSel = T002M3_A1031ImpDPorSel[0];
               Z198ImpDProdCod = T002M3_A198ImpDProdCod[0];
            }
            else
            {
               Z1025ImpDCant = A1025ImpDCant;
               Z1032ImpDPre = A1032ImpDPre;
               Z1026ImpDDct = A1026ImpDDct;
               Z1027ImpDDct2 = A1027ImpDDct2;
               Z1028ImpDIna = A1028ImpDIna;
               Z1031ImpDPorSel = A1031ImpDPorSel;
               Z198ImpDProdCod = A198ImpDProdCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z197ImpDItem = A197ImpDItem;
            Z1025ImpDCant = A1025ImpDCant;
            Z1032ImpDPre = A1032ImpDPre;
            Z1026ImpDDct = A1026ImpDDct;
            Z1027ImpDDct2 = A1027ImpDDct2;
            Z1029ImpDObs = A1029ImpDObs;
            Z1028ImpDIna = A1028ImpDIna;
            Z1031ImpDPorSel = A1031ImpDPorSel;
            Z191ImpItem = A191ImpItem;
            Z198ImpDProdCod = A198ImpDProdCod;
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

      protected void Load2M90( )
      {
         /* Using cursor T002M6 */
         pr_default.execute(4, new Object[] {A191ImpItem, A197ImpDItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound90 = 1;
            A1025ImpDCant = T002M6_A1025ImpDCant[0];
            AssignAttri("", false, "A1025ImpDCant", StringUtil.LTrimStr( A1025ImpDCant, 15, 4));
            A1032ImpDPre = T002M6_A1032ImpDPre[0];
            AssignAttri("", false, "A1032ImpDPre", StringUtil.LTrimStr( A1032ImpDPre, 15, 4));
            A1026ImpDDct = T002M6_A1026ImpDDct[0];
            AssignAttri("", false, "A1026ImpDDct", StringUtil.LTrimStr( A1026ImpDDct, 15, 2));
            A1027ImpDDct2 = T002M6_A1027ImpDDct2[0];
            AssignAttri("", false, "A1027ImpDDct2", StringUtil.LTrimStr( A1027ImpDDct2, 15, 2));
            A1029ImpDObs = T002M6_A1029ImpDObs[0];
            AssignAttri("", false, "A1029ImpDObs", A1029ImpDObs);
            A1028ImpDIna = T002M6_A1028ImpDIna[0];
            AssignAttri("", false, "A1028ImpDIna", StringUtil.Str( (decimal)(A1028ImpDIna), 1, 0));
            A1031ImpDPorSel = T002M6_A1031ImpDPorSel[0];
            AssignAttri("", false, "A1031ImpDPorSel", StringUtil.LTrimStr( (decimal)(A1031ImpDPorSel), 5, 0));
            A198ImpDProdCod = T002M6_A198ImpDProdCod[0];
            AssignAttri("", false, "A198ImpDProdCod", A198ImpDProdCod);
            ZM2M90( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2M90( ) ;
      }

      protected void OnLoadActions2M90( )
      {
      }

      protected void CheckExtendedTable2M90( )
      {
         nIsDirty_90 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002M4 */
         pr_default.execute(2, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Documentos'.", "ForeignKeyNotFound", 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002M5 */
         pr_default.execute(3, new Object[] {A198ImpDProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IMPDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtImpDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2M90( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A191ImpItem )
      {
         /* Using cursor T002M7 */
         pr_default.execute(5, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Documentos'.", "ForeignKeyNotFound", 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A198ImpDProdCod )
      {
         /* Using cursor T002M8 */
         pr_default.execute(6, new Object[] {A198ImpDProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IMPDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtImpDProdCod_Internalname;
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

      protected void GetKey2M90( )
      {
         /* Using cursor T002M9 */
         pr_default.execute(7, new Object[] {A191ImpItem, A197ImpDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound90 = 1;
         }
         else
         {
            RcdFound90 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002M3 */
         pr_default.execute(1, new Object[] {A191ImpItem, A197ImpDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2M90( 1) ;
            RcdFound90 = 1;
            A197ImpDItem = T002M3_A197ImpDItem[0];
            AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
            A1025ImpDCant = T002M3_A1025ImpDCant[0];
            AssignAttri("", false, "A1025ImpDCant", StringUtil.LTrimStr( A1025ImpDCant, 15, 4));
            A1032ImpDPre = T002M3_A1032ImpDPre[0];
            AssignAttri("", false, "A1032ImpDPre", StringUtil.LTrimStr( A1032ImpDPre, 15, 4));
            A1026ImpDDct = T002M3_A1026ImpDDct[0];
            AssignAttri("", false, "A1026ImpDDct", StringUtil.LTrimStr( A1026ImpDDct, 15, 2));
            A1027ImpDDct2 = T002M3_A1027ImpDDct2[0];
            AssignAttri("", false, "A1027ImpDDct2", StringUtil.LTrimStr( A1027ImpDDct2, 15, 2));
            A1029ImpDObs = T002M3_A1029ImpDObs[0];
            AssignAttri("", false, "A1029ImpDObs", A1029ImpDObs);
            A1028ImpDIna = T002M3_A1028ImpDIna[0];
            AssignAttri("", false, "A1028ImpDIna", StringUtil.Str( (decimal)(A1028ImpDIna), 1, 0));
            A1031ImpDPorSel = T002M3_A1031ImpDPorSel[0];
            AssignAttri("", false, "A1031ImpDPorSel", StringUtil.LTrimStr( (decimal)(A1031ImpDPorSel), 5, 0));
            A191ImpItem = T002M3_A191ImpItem[0];
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            A198ImpDProdCod = T002M3_A198ImpDProdCod[0];
            AssignAttri("", false, "A198ImpDProdCod", A198ImpDProdCod);
            Z191ImpItem = A191ImpItem;
            Z197ImpDItem = A197ImpDItem;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2M90( ) ;
            if ( AnyError == 1 )
            {
               RcdFound90 = 0;
               InitializeNonKey2M90( ) ;
            }
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound90 = 0;
            InitializeNonKey2M90( ) ;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2M90( ) ;
         if ( RcdFound90 == 0 )
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
         RcdFound90 = 0;
         /* Using cursor T002M10 */
         pr_default.execute(8, new Object[] {A191ImpItem, A197ImpDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002M10_A191ImpItem[0] < A191ImpItem ) || ( T002M10_A191ImpItem[0] == A191ImpItem ) && ( T002M10_A197ImpDItem[0] < A197ImpDItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002M10_A191ImpItem[0] > A191ImpItem ) || ( T002M10_A191ImpItem[0] == A191ImpItem ) && ( T002M10_A197ImpDItem[0] > A197ImpDItem ) ) )
            {
               A191ImpItem = T002M10_A191ImpItem[0];
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               A197ImpDItem = T002M10_A197ImpDItem[0];
               AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
               RcdFound90 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound90 = 0;
         /* Using cursor T002M11 */
         pr_default.execute(9, new Object[] {A191ImpItem, A197ImpDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002M11_A191ImpItem[0] > A191ImpItem ) || ( T002M11_A191ImpItem[0] == A191ImpItem ) && ( T002M11_A197ImpDItem[0] > A197ImpDItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002M11_A191ImpItem[0] < A191ImpItem ) || ( T002M11_A191ImpItem[0] == A191ImpItem ) && ( T002M11_A197ImpDItem[0] < A197ImpDItem ) ) )
            {
               A191ImpItem = T002M11_A191ImpItem[0];
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               A197ImpDItem = T002M11_A197ImpDItem[0];
               AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
               RcdFound90 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2M90( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2M90( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound90 == 1 )
            {
               if ( ( A191ImpItem != Z191ImpItem ) || ( A197ImpDItem != Z197ImpDItem ) )
               {
                  A191ImpItem = Z191ImpItem;
                  AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
                  A197ImpDItem = Z197ImpDItem;
                  AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IMPITEM");
                  AnyError = 1;
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2M90( ) ;
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A191ImpItem != Z191ImpItem ) || ( A197ImpDItem != Z197ImpDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2M90( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IMPITEM");
                     AnyError = 1;
                     GX_FocusControl = edtImpItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtImpItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2M90( ) ;
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
         if ( ( A191ImpItem != Z191ImpItem ) || ( A197ImpDItem != Z197ImpDItem ) )
         {
            A191ImpItem = Z191ImpItem;
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            A197ImpDItem = Z197ImpDItem;
            AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtImpItem_Internalname;
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
         GetKey2M90( ) ;
         if ( RcdFound90 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "IMPITEM");
               AnyError = 1;
               GX_FocusControl = edtImpItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A191ImpItem != Z191ImpItem ) || ( A197ImpDItem != Z197ImpDItem ) )
            {
               A191ImpItem = Z191ImpItem;
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               A197ImpDItem = Z197ImpDItem;
               AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "IMPITEM");
               AnyError = 1;
               GX_FocusControl = edtImpItem_Internalname;
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
            if ( ( A191ImpItem != Z191ImpItem ) || ( A197ImpDItem != Z197ImpDItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IMPITEM");
                  AnyError = 1;
                  GX_FocusControl = edtImpItem_Internalname;
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
         context.RollbackDataStores("cldocumentosdet",pr_default);
         GX_FocusControl = edtImpDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2M0( ) ;
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
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtImpDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2M90( ) ;
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2M90( ) ;
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
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpDProdCod_Internalname;
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
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpDProdCod_Internalname;
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
         ScanStart2M90( ) ;
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound90 != 0 )
            {
               ScanNext2M90( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2M90( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2M90( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002M2 */
            pr_default.execute(0, new Object[] {A191ImpItem, A197ImpDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLDOCUMENTOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1025ImpDCant != T002M2_A1025ImpDCant[0] ) || ( Z1032ImpDPre != T002M2_A1032ImpDPre[0] ) || ( Z1026ImpDDct != T002M2_A1026ImpDDct[0] ) || ( Z1027ImpDDct2 != T002M2_A1027ImpDDct2[0] ) || ( Z1028ImpDIna != T002M2_A1028ImpDIna[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1031ImpDPorSel != T002M2_A1031ImpDPorSel[0] ) || ( StringUtil.StrCmp(Z198ImpDProdCod, T002M2_A198ImpDProdCod[0]) != 0 ) )
            {
               if ( Z1025ImpDCant != T002M2_A1025ImpDCant[0] )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDCant");
                  GXUtil.WriteLogRaw("Old: ",Z1025ImpDCant);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A1025ImpDCant[0]);
               }
               if ( Z1032ImpDPre != T002M2_A1032ImpDPre[0] )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDPre");
                  GXUtil.WriteLogRaw("Old: ",Z1032ImpDPre);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A1032ImpDPre[0]);
               }
               if ( Z1026ImpDDct != T002M2_A1026ImpDDct[0] )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDDct");
                  GXUtil.WriteLogRaw("Old: ",Z1026ImpDDct);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A1026ImpDDct[0]);
               }
               if ( Z1027ImpDDct2 != T002M2_A1027ImpDDct2[0] )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDDct2");
                  GXUtil.WriteLogRaw("Old: ",Z1027ImpDDct2);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A1027ImpDDct2[0]);
               }
               if ( Z1028ImpDIna != T002M2_A1028ImpDIna[0] )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDIna");
                  GXUtil.WriteLogRaw("Old: ",Z1028ImpDIna);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A1028ImpDIna[0]);
               }
               if ( Z1031ImpDPorSel != T002M2_A1031ImpDPorSel[0] )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDPorSel");
                  GXUtil.WriteLogRaw("Old: ",Z1031ImpDPorSel);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A1031ImpDPorSel[0]);
               }
               if ( StringUtil.StrCmp(Z198ImpDProdCod, T002M2_A198ImpDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentosdet:[seudo value changed for attri]"+"ImpDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z198ImpDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T002M2_A198ImpDProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLDOCUMENTOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2M90( )
      {
         BeforeValidate2M90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2M90( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2M90( 0) ;
            CheckOptimisticConcurrency2M90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2M90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2M90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002M12 */
                     pr_default.execute(10, new Object[] {A197ImpDItem, A1025ImpDCant, A1032ImpDPre, A1026ImpDDct, A1027ImpDDct2, A1029ImpDObs, A1028ImpDIna, A1031ImpDPorSel, A191ImpItem, A198ImpDProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLDOCUMENTOSDET");
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
                           ResetCaption2M0( ) ;
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
               Load2M90( ) ;
            }
            EndLevel2M90( ) ;
         }
         CloseExtendedTableCursors2M90( ) ;
      }

      protected void Update2M90( )
      {
         BeforeValidate2M90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2M90( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2M90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2M90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2M90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002M13 */
                     pr_default.execute(11, new Object[] {A1025ImpDCant, A1032ImpDPre, A1026ImpDDct, A1027ImpDDct2, A1029ImpDObs, A1028ImpDIna, A1031ImpDPorSel, A198ImpDProdCod, A191ImpItem, A197ImpDItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLDOCUMENTOSDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLDOCUMENTOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2M90( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2M0( ) ;
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
            EndLevel2M90( ) ;
         }
         CloseExtendedTableCursors2M90( ) ;
      }

      protected void DeferredUpdate2M90( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2M90( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2M90( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2M90( ) ;
            AfterConfirm2M90( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2M90( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002M14 */
                  pr_default.execute(12, new Object[] {A191ImpItem, A197ImpDItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLDOCUMENTOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound90 == 0 )
                        {
                           InitAll2M90( ) ;
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
                        ResetCaption2M0( ) ;
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
         sMode90 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2M90( ) ;
         Gx_mode = sMode90;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2M90( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2M90( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2M90( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cldocumentosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cldocumentosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2M90( )
      {
         /* Using cursor T002M15 */
         pr_default.execute(13);
         RcdFound90 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound90 = 1;
            A191ImpItem = T002M15_A191ImpItem[0];
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            A197ImpDItem = T002M15_A197ImpDItem[0];
            AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2M90( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound90 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound90 = 1;
            A191ImpItem = T002M15_A191ImpItem[0];
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            A197ImpDItem = T002M15_A197ImpDItem[0];
            AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
         }
      }

      protected void ScanEnd2M90( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2M90( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2M90( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2M90( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2M90( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2M90( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2M90( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2M90( )
      {
         edtImpItem_Enabled = 0;
         AssignProp("", false, edtImpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpItem_Enabled), 5, 0), true);
         edtImpDItem_Enabled = 0;
         AssignProp("", false, edtImpDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDItem_Enabled), 5, 0), true);
         edtImpDProdCod_Enabled = 0;
         AssignProp("", false, edtImpDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDProdCod_Enabled), 5, 0), true);
         edtImpDCant_Enabled = 0;
         AssignProp("", false, edtImpDCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDCant_Enabled), 5, 0), true);
         edtImpDPre_Enabled = 0;
         AssignProp("", false, edtImpDPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDPre_Enabled), 5, 0), true);
         edtImpDDct_Enabled = 0;
         AssignProp("", false, edtImpDDct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDDct_Enabled), 5, 0), true);
         edtImpDDct2_Enabled = 0;
         AssignProp("", false, edtImpDDct2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDDct2_Enabled), 5, 0), true);
         edtImpDObs_Enabled = 0;
         AssignProp("", false, edtImpDObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDObs_Enabled), 5, 0), true);
         edtImpDIna_Enabled = 0;
         AssignProp("", false, edtImpDIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDIna_Enabled), 5, 0), true);
         edtImpDPorSel_Enabled = 0;
         AssignProp("", false, edtImpDPorSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDPorSel_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2M90( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816424766", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cldocumentosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z191ImpItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z191ImpItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z197ImpDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z197ImpDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1025ImpDCant", StringUtil.LTrim( StringUtil.NToC( Z1025ImpDCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1032ImpDPre", StringUtil.LTrim( StringUtil.NToC( Z1032ImpDPre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1026ImpDDct", StringUtil.LTrim( StringUtil.NToC( Z1026ImpDDct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1027ImpDDct2", StringUtil.LTrim( StringUtil.NToC( Z1027ImpDDct2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1028ImpDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1028ImpDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1031ImpDPorSel", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1031ImpDPorSel), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z198ImpDProdCod", StringUtil.RTrim( Z198ImpDProdCod));
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
         return formatLink("cldocumentosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLDOCUMENTOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documentos Afectos IGV - Detalles" ;
      }

      protected void InitializeNonKey2M90( )
      {
         A198ImpDProdCod = "";
         AssignAttri("", false, "A198ImpDProdCod", A198ImpDProdCod);
         A1025ImpDCant = 0;
         AssignAttri("", false, "A1025ImpDCant", StringUtil.LTrimStr( A1025ImpDCant, 15, 4));
         A1032ImpDPre = 0;
         AssignAttri("", false, "A1032ImpDPre", StringUtil.LTrimStr( A1032ImpDPre, 15, 4));
         A1026ImpDDct = 0;
         AssignAttri("", false, "A1026ImpDDct", StringUtil.LTrimStr( A1026ImpDDct, 15, 2));
         A1027ImpDDct2 = 0;
         AssignAttri("", false, "A1027ImpDDct2", StringUtil.LTrimStr( A1027ImpDDct2, 15, 2));
         A1029ImpDObs = "";
         AssignAttri("", false, "A1029ImpDObs", A1029ImpDObs);
         A1028ImpDIna = 0;
         AssignAttri("", false, "A1028ImpDIna", StringUtil.Str( (decimal)(A1028ImpDIna), 1, 0));
         A1031ImpDPorSel = 0;
         AssignAttri("", false, "A1031ImpDPorSel", StringUtil.LTrimStr( (decimal)(A1031ImpDPorSel), 5, 0));
         Z1025ImpDCant = 0;
         Z1032ImpDPre = 0;
         Z1026ImpDDct = 0;
         Z1027ImpDDct2 = 0;
         Z1028ImpDIna = 0;
         Z1031ImpDPorSel = 0;
         Z198ImpDProdCod = "";
      }

      protected void InitAll2M90( )
      {
         A191ImpItem = 0;
         AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
         A197ImpDItem = 0;
         AssignAttri("", false, "A197ImpDItem", StringUtil.LTrimStr( (decimal)(A197ImpDItem), 6, 0));
         InitializeNonKey2M90( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816424776", true, true);
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
         context.AddJavascriptSource("cldocumentosdet.js", "?202281816424777", false, true);
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
         edtImpItem_Internalname = "IMPITEM";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtImpDItem_Internalname = "IMPDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtImpDProdCod_Internalname = "IMPDPRODCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtImpDCant_Internalname = "IMPDCANT";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtImpDPre_Internalname = "IMPDPRE";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtImpDDct_Internalname = "IMPDDCT";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtImpDDct2_Internalname = "IMPDDCT2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtImpDObs_Internalname = "IMPDOBS";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtImpDIna_Internalname = "IMPDINA";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtImpDPorSel_Internalname = "IMPDPORSEL";
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
         Form.Caption = "Documentos Afectos IGV - Detalles";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtImpDPorSel_Jsonclick = "";
         edtImpDPorSel_Enabled = 1;
         edtImpDIna_Jsonclick = "";
         edtImpDIna_Enabled = 1;
         edtImpDObs_Enabled = 1;
         edtImpDDct2_Jsonclick = "";
         edtImpDDct2_Enabled = 1;
         edtImpDDct_Jsonclick = "";
         edtImpDDct_Enabled = 1;
         edtImpDPre_Jsonclick = "";
         edtImpDPre_Enabled = 1;
         edtImpDCant_Jsonclick = "";
         edtImpDCant_Enabled = 1;
         edtImpDProdCod_Jsonclick = "";
         edtImpDProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtImpDItem_Jsonclick = "";
         edtImpDItem_Enabled = 1;
         edtImpItem_Jsonclick = "";
         edtImpItem_Enabled = 1;
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
         /* Using cursor T002M16 */
         pr_default.execute(14, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Documentos'.", "ForeignKeyNotFound", 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtImpDProdCod_Internalname;
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

      public void Valid_Impitem( )
      {
         /* Using cursor T002M16 */
         pr_default.execute(14, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Documentos'.", "ForeignKeyNotFound", 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Impditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A198ImpDProdCod", StringUtil.RTrim( A198ImpDProdCod));
         AssignAttri("", false, "A1025ImpDCant", StringUtil.LTrim( StringUtil.NToC( A1025ImpDCant, 15, 4, ".", "")));
         AssignAttri("", false, "A1032ImpDPre", StringUtil.LTrim( StringUtil.NToC( A1032ImpDPre, 15, 4, ".", "")));
         AssignAttri("", false, "A1026ImpDDct", StringUtil.LTrim( StringUtil.NToC( A1026ImpDDct, 15, 2, ".", "")));
         AssignAttri("", false, "A1027ImpDDct2", StringUtil.LTrim( StringUtil.NToC( A1027ImpDDct2, 15, 2, ".", "")));
         AssignAttri("", false, "A1029ImpDObs", A1029ImpDObs);
         AssignAttri("", false, "A1028ImpDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1028ImpDIna), 1, 0, ".", "")));
         AssignAttri("", false, "A1031ImpDPorSel", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031ImpDPorSel), 5, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z191ImpItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z191ImpItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z197ImpDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z197ImpDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z198ImpDProdCod", StringUtil.RTrim( Z198ImpDProdCod));
         GxWebStd.gx_hidden_field( context, "Z1025ImpDCant", StringUtil.LTrim( StringUtil.NToC( Z1025ImpDCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1032ImpDPre", StringUtil.LTrim( StringUtil.NToC( Z1032ImpDPre, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1026ImpDDct", StringUtil.LTrim( StringUtil.NToC( Z1026ImpDDct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1027ImpDDct2", StringUtil.LTrim( StringUtil.NToC( Z1027ImpDDct2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1029ImpDObs", Z1029ImpDObs);
         GxWebStd.gx_hidden_field( context, "Z1028ImpDIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1028ImpDIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1031ImpDPorSel", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1031ImpDPorSel), 5, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Impdprodcod( )
      {
         /* Using cursor T002M17 */
         pr_default.execute(15, new Object[] {A198ImpDProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IMPDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtImpDProdCod_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_IMPITEM","{handler:'Valid_Impitem',iparms:[{av:'A191ImpItem',fld:'IMPITEM',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("VALID_IMPITEM",",oparms:[]}");
         setEventMetadata("VALID_IMPDITEM","{handler:'Valid_Impditem',iparms:[{av:'A191ImpItem',fld:'IMPITEM',pic:'ZZZZZZZZZ9'},{av:'A197ImpDItem',fld:'IMPDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_IMPDITEM",",oparms:[{av:'A198ImpDProdCod',fld:'IMPDPRODCOD',pic:'@!'},{av:'A1025ImpDCant',fld:'IMPDCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1032ImpDPre',fld:'IMPDPRE',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1026ImpDDct',fld:'IMPDDCT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1027ImpDDct2',fld:'IMPDDCT2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1029ImpDObs',fld:'IMPDOBS',pic:''},{av:'A1028ImpDIna',fld:'IMPDINA',pic:'9'},{av:'A1031ImpDPorSel',fld:'IMPDPORSEL',pic:'ZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z191ImpItem'},{av:'Z197ImpDItem'},{av:'Z198ImpDProdCod'},{av:'Z1025ImpDCant'},{av:'Z1032ImpDPre'},{av:'Z1026ImpDDct'},{av:'Z1027ImpDDct2'},{av:'Z1029ImpDObs'},{av:'Z1028ImpDIna'},{av:'Z1031ImpDPorSel'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_IMPDPRODCOD","{handler:'Valid_Impdprodcod',iparms:[{av:'A198ImpDProdCod',fld:'IMPDPRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_IMPDPRODCOD",",oparms:[]}");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z198ImpDProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A198ImpDProdCod = "";
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
         A1029ImpDObs = "";
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
         Z1029ImpDObs = "";
         T002M6_A197ImpDItem = new int[1] ;
         T002M6_A1025ImpDCant = new decimal[1] ;
         T002M6_A1032ImpDPre = new decimal[1] ;
         T002M6_A1026ImpDDct = new decimal[1] ;
         T002M6_A1027ImpDDct2 = new decimal[1] ;
         T002M6_A1029ImpDObs = new string[] {""} ;
         T002M6_A1028ImpDIna = new short[1] ;
         T002M6_A1031ImpDPorSel = new int[1] ;
         T002M6_A191ImpItem = new long[1] ;
         T002M6_A198ImpDProdCod = new string[] {""} ;
         T002M4_A191ImpItem = new long[1] ;
         T002M5_A198ImpDProdCod = new string[] {""} ;
         T002M7_A191ImpItem = new long[1] ;
         T002M8_A198ImpDProdCod = new string[] {""} ;
         T002M9_A191ImpItem = new long[1] ;
         T002M9_A197ImpDItem = new int[1] ;
         T002M3_A197ImpDItem = new int[1] ;
         T002M3_A1025ImpDCant = new decimal[1] ;
         T002M3_A1032ImpDPre = new decimal[1] ;
         T002M3_A1026ImpDDct = new decimal[1] ;
         T002M3_A1027ImpDDct2 = new decimal[1] ;
         T002M3_A1029ImpDObs = new string[] {""} ;
         T002M3_A1028ImpDIna = new short[1] ;
         T002M3_A1031ImpDPorSel = new int[1] ;
         T002M3_A191ImpItem = new long[1] ;
         T002M3_A198ImpDProdCod = new string[] {""} ;
         sMode90 = "";
         T002M10_A191ImpItem = new long[1] ;
         T002M10_A197ImpDItem = new int[1] ;
         T002M11_A191ImpItem = new long[1] ;
         T002M11_A197ImpDItem = new int[1] ;
         T002M2_A197ImpDItem = new int[1] ;
         T002M2_A1025ImpDCant = new decimal[1] ;
         T002M2_A1032ImpDPre = new decimal[1] ;
         T002M2_A1026ImpDDct = new decimal[1] ;
         T002M2_A1027ImpDDct2 = new decimal[1] ;
         T002M2_A1029ImpDObs = new string[] {""} ;
         T002M2_A1028ImpDIna = new short[1] ;
         T002M2_A1031ImpDPorSel = new int[1] ;
         T002M2_A191ImpItem = new long[1] ;
         T002M2_A198ImpDProdCod = new string[] {""} ;
         T002M15_A191ImpItem = new long[1] ;
         T002M15_A197ImpDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002M16_A191ImpItem = new long[1] ;
         ZZ198ImpDProdCod = "";
         ZZ1029ImpDObs = "";
         T002M17_A198ImpDProdCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cldocumentosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cldocumentosdet__default(),
            new Object[][] {
                new Object[] {
               T002M2_A197ImpDItem, T002M2_A1025ImpDCant, T002M2_A1032ImpDPre, T002M2_A1026ImpDDct, T002M2_A1027ImpDDct2, T002M2_A1029ImpDObs, T002M2_A1028ImpDIna, T002M2_A1031ImpDPorSel, T002M2_A191ImpItem, T002M2_A198ImpDProdCod
               }
               , new Object[] {
               T002M3_A197ImpDItem, T002M3_A1025ImpDCant, T002M3_A1032ImpDPre, T002M3_A1026ImpDDct, T002M3_A1027ImpDDct2, T002M3_A1029ImpDObs, T002M3_A1028ImpDIna, T002M3_A1031ImpDPorSel, T002M3_A191ImpItem, T002M3_A198ImpDProdCod
               }
               , new Object[] {
               T002M4_A191ImpItem
               }
               , new Object[] {
               T002M5_A198ImpDProdCod
               }
               , new Object[] {
               T002M6_A197ImpDItem, T002M6_A1025ImpDCant, T002M6_A1032ImpDPre, T002M6_A1026ImpDDct, T002M6_A1027ImpDDct2, T002M6_A1029ImpDObs, T002M6_A1028ImpDIna, T002M6_A1031ImpDPorSel, T002M6_A191ImpItem, T002M6_A198ImpDProdCod
               }
               , new Object[] {
               T002M7_A191ImpItem
               }
               , new Object[] {
               T002M8_A198ImpDProdCod
               }
               , new Object[] {
               T002M9_A191ImpItem, T002M9_A197ImpDItem
               }
               , new Object[] {
               T002M10_A191ImpItem, T002M10_A197ImpDItem
               }
               , new Object[] {
               T002M11_A191ImpItem, T002M11_A197ImpDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002M15_A191ImpItem, T002M15_A197ImpDItem
               }
               , new Object[] {
               T002M16_A191ImpItem
               }
               , new Object[] {
               T002M17_A198ImpDProdCod
               }
            }
         );
      }

      private short Z1028ImpDIna ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1028ImpDIna ;
      private short GX_JID ;
      private short RcdFound90 ;
      private short nIsDirty_90 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1028ImpDIna ;
      private int Z197ImpDItem ;
      private int Z1031ImpDPorSel ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtImpItem_Enabled ;
      private int A197ImpDItem ;
      private int edtImpDItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtImpDProdCod_Enabled ;
      private int edtImpDCant_Enabled ;
      private int edtImpDPre_Enabled ;
      private int edtImpDDct_Enabled ;
      private int edtImpDDct2_Enabled ;
      private int edtImpDObs_Enabled ;
      private int edtImpDIna_Enabled ;
      private int A1031ImpDPorSel ;
      private int edtImpDPorSel_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ197ImpDItem ;
      private int ZZ1031ImpDPorSel ;
      private long Z191ImpItem ;
      private long A191ImpItem ;
      private long ZZ191ImpItem ;
      private decimal Z1025ImpDCant ;
      private decimal Z1032ImpDPre ;
      private decimal Z1026ImpDDct ;
      private decimal Z1027ImpDDct2 ;
      private decimal A1025ImpDCant ;
      private decimal A1032ImpDPre ;
      private decimal A1026ImpDDct ;
      private decimal A1027ImpDDct2 ;
      private decimal ZZ1025ImpDCant ;
      private decimal ZZ1032ImpDPre ;
      private decimal ZZ1026ImpDDct ;
      private decimal ZZ1027ImpDDct2 ;
      private string sPrefix ;
      private string Z198ImpDProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A198ImpDProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtImpItem_Internalname ;
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
      private string edtImpItem_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtImpDItem_Internalname ;
      private string edtImpDItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtImpDProdCod_Internalname ;
      private string edtImpDProdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtImpDCant_Internalname ;
      private string edtImpDCant_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtImpDPre_Internalname ;
      private string edtImpDPre_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtImpDDct_Internalname ;
      private string edtImpDDct_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtImpDDct2_Internalname ;
      private string edtImpDDct2_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtImpDObs_Internalname ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtImpDIna_Internalname ;
      private string edtImpDIna_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtImpDPorSel_Internalname ;
      private string edtImpDPorSel_Jsonclick ;
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
      private string sMode90 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ198ImpDProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A1029ImpDObs ;
      private string Z1029ImpDObs ;
      private string ZZ1029ImpDObs ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002M6_A197ImpDItem ;
      private decimal[] T002M6_A1025ImpDCant ;
      private decimal[] T002M6_A1032ImpDPre ;
      private decimal[] T002M6_A1026ImpDDct ;
      private decimal[] T002M6_A1027ImpDDct2 ;
      private string[] T002M6_A1029ImpDObs ;
      private short[] T002M6_A1028ImpDIna ;
      private int[] T002M6_A1031ImpDPorSel ;
      private long[] T002M6_A191ImpItem ;
      private string[] T002M6_A198ImpDProdCod ;
      private long[] T002M4_A191ImpItem ;
      private string[] T002M5_A198ImpDProdCod ;
      private long[] T002M7_A191ImpItem ;
      private string[] T002M8_A198ImpDProdCod ;
      private long[] T002M9_A191ImpItem ;
      private int[] T002M9_A197ImpDItem ;
      private int[] T002M3_A197ImpDItem ;
      private decimal[] T002M3_A1025ImpDCant ;
      private decimal[] T002M3_A1032ImpDPre ;
      private decimal[] T002M3_A1026ImpDDct ;
      private decimal[] T002M3_A1027ImpDDct2 ;
      private string[] T002M3_A1029ImpDObs ;
      private short[] T002M3_A1028ImpDIna ;
      private int[] T002M3_A1031ImpDPorSel ;
      private long[] T002M3_A191ImpItem ;
      private string[] T002M3_A198ImpDProdCod ;
      private long[] T002M10_A191ImpItem ;
      private int[] T002M10_A197ImpDItem ;
      private long[] T002M11_A191ImpItem ;
      private int[] T002M11_A197ImpDItem ;
      private int[] T002M2_A197ImpDItem ;
      private decimal[] T002M2_A1025ImpDCant ;
      private decimal[] T002M2_A1032ImpDPre ;
      private decimal[] T002M2_A1026ImpDDct ;
      private decimal[] T002M2_A1027ImpDDct2 ;
      private string[] T002M2_A1029ImpDObs ;
      private short[] T002M2_A1028ImpDIna ;
      private int[] T002M2_A1031ImpDPorSel ;
      private long[] T002M2_A191ImpItem ;
      private string[] T002M2_A198ImpDProdCod ;
      private long[] T002M15_A191ImpItem ;
      private int[] T002M15_A197ImpDItem ;
      private long[] T002M16_A191ImpItem ;
      private string[] T002M17_A198ImpDProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cldocumentosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cldocumentosdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002M6;
        prmT002M6 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M4;
        prmT002M4 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002M5;
        prmT002M5 = new Object[] {
        new ParDef("@ImpDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002M7;
        prmT002M7 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002M8;
        prmT002M8 = new Object[] {
        new ParDef("@ImpDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002M9;
        prmT002M9 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M3;
        prmT002M3 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M10;
        prmT002M10 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M11;
        prmT002M11 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M2;
        prmT002M2 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M12;
        prmT002M12 = new Object[] {
        new ParDef("@ImpDItem",GXType.Int32,6,0) ,
        new ParDef("@ImpDCant",GXType.Decimal,15,4) ,
        new ParDef("@ImpDPre",GXType.Decimal,15,4) ,
        new ParDef("@ImpDDct",GXType.Decimal,15,2) ,
        new ParDef("@ImpDDct2",GXType.Decimal,15,2) ,
        new ParDef("@ImpDObs",GXType.NVarChar,500,0) ,
        new ParDef("@ImpDIna",GXType.Int16,1,0) ,
        new ParDef("@ImpDPorSel",GXType.Int32,5,0) ,
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002M13;
        prmT002M13 = new Object[] {
        new ParDef("@ImpDCant",GXType.Decimal,15,4) ,
        new ParDef("@ImpDPre",GXType.Decimal,15,4) ,
        new ParDef("@ImpDDct",GXType.Decimal,15,2) ,
        new ParDef("@ImpDDct2",GXType.Decimal,15,2) ,
        new ParDef("@ImpDObs",GXType.NVarChar,500,0) ,
        new ParDef("@ImpDIna",GXType.Int16,1,0) ,
        new ParDef("@ImpDPorSel",GXType.Int32,5,0) ,
        new ParDef("@ImpDProdCod",GXType.NChar,15,0) ,
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M14;
        prmT002M14 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpDItem",GXType.Int32,6,0)
        };
        Object[] prmT002M15;
        prmT002M15 = new Object[] {
        };
        Object[] prmT002M16;
        prmT002M16 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002M17;
        prmT002M17 = new Object[] {
        new ParDef("@ImpDProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002M2", "SELECT [ImpDItem], [ImpDCant], [ImpDPre], [ImpDDct], [ImpDDct2], [ImpDObs], [ImpDIna], [ImpDPorSel], [ImpItem], [ImpDProdCod] AS ImpDProdCod FROM [CLDOCUMENTOSDET] WITH (UPDLOCK) WHERE [ImpItem] = @ImpItem AND [ImpDItem] = @ImpDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M3", "SELECT [ImpDItem], [ImpDCant], [ImpDPre], [ImpDDct], [ImpDDct2], [ImpDObs], [ImpDIna], [ImpDPorSel], [ImpItem], [ImpDProdCod] AS ImpDProdCod FROM [CLDOCUMENTOSDET] WHERE [ImpItem] = @ImpItem AND [ImpDItem] = @ImpDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M4", "SELECT [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpItem] = @ImpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M5", "SELECT [ProdCod] AS ImpDProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @ImpDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M6", "SELECT TM1.[ImpDItem], TM1.[ImpDCant], TM1.[ImpDPre], TM1.[ImpDDct], TM1.[ImpDDct2], TM1.[ImpDObs], TM1.[ImpDIna], TM1.[ImpDPorSel], TM1.[ImpItem], TM1.[ImpDProdCod] AS ImpDProdCod FROM [CLDOCUMENTOSDET] TM1 WHERE TM1.[ImpItem] = @ImpItem and TM1.[ImpDItem] = @ImpDItem ORDER BY TM1.[ImpItem], TM1.[ImpDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002M6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M7", "SELECT [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpItem] = @ImpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M8", "SELECT [ProdCod] AS ImpDProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @ImpDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M9", "SELECT [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE [ImpItem] = @ImpItem AND [ImpDItem] = @ImpDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002M9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M10", "SELECT TOP 1 [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE ( [ImpItem] > @ImpItem or [ImpItem] = @ImpItem and [ImpDItem] > @ImpDItem) ORDER BY [ImpItem], [ImpDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002M10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002M11", "SELECT TOP 1 [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE ( [ImpItem] < @ImpItem or [ImpItem] = @ImpItem and [ImpDItem] < @ImpDItem) ORDER BY [ImpItem] DESC, [ImpDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002M11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002M12", "INSERT INTO [CLDOCUMENTOSDET]([ImpDItem], [ImpDCant], [ImpDPre], [ImpDDct], [ImpDDct2], [ImpDObs], [ImpDIna], [ImpDPorSel], [ImpItem], [ImpDProdCod]) VALUES(@ImpDItem, @ImpDCant, @ImpDPre, @ImpDDct, @ImpDDct2, @ImpDObs, @ImpDIna, @ImpDPorSel, @ImpItem, @ImpDProdCod)", GxErrorMask.GX_NOMASK,prmT002M12)
           ,new CursorDef("T002M13", "UPDATE [CLDOCUMENTOSDET] SET [ImpDCant]=@ImpDCant, [ImpDPre]=@ImpDPre, [ImpDDct]=@ImpDDct, [ImpDDct2]=@ImpDDct2, [ImpDObs]=@ImpDObs, [ImpDIna]=@ImpDIna, [ImpDPorSel]=@ImpDPorSel, [ImpDProdCod]=@ImpDProdCod  WHERE [ImpItem] = @ImpItem AND [ImpDItem] = @ImpDItem", GxErrorMask.GX_NOMASK,prmT002M13)
           ,new CursorDef("T002M14", "DELETE FROM [CLDOCUMENTOSDET]  WHERE [ImpItem] = @ImpItem AND [ImpDItem] = @ImpDItem", GxErrorMask.GX_NOMASK,prmT002M14)
           ,new CursorDef("T002M15", "SELECT [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] ORDER BY [ImpItem], [ImpDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002M15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M16", "SELECT [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpItem] = @ImpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002M17", "SELECT [ProdCod] AS ImpDProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @ImpDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002M17,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
