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
   public class clpercepciondet : GXDataArea
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
            A218PerCod = GetPar( "PerCod");
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = GetPar( "PerTip");
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = GetPar( "PerTDoc");
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A218PerCod, A219PerTip, A220PerTDoc) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A222PerTipCod = GetPar( "PerTipCod");
            AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
            A223PerDocNum = GetPar( "PerDocNum");
            AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A222PerTipCod, A223PerDocNum) ;
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
            Form.Meta.addItem("description", "Detalle de Comprobante de Percepción", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPerTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clpercepciondet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpercepciondet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLPERCEPCIONDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "T/D", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTip_Internalname, StringUtil.RTrim( A219PerTip), StringUtil.RTrim( context.localUtil.Format( A219PerTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Percepción", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerCod_Internalname, StringUtil.RTrim( A218PerCod), StringUtil.RTrim( context.localUtil.Format( A218PerCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "T/D Ref", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTDoc_Internalname, A220PerTDoc, StringUtil.RTrim( context.localUtil.Format( A220PerTDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTDoc_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Per Tip Cod", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTipCod_Internalname, StringUtil.RTrim( A222PerTipCod), StringUtil.RTrim( context.localUtil.Format( A222PerTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Per Doc Num", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerDocNum_Internalname, StringUtil.RTrim( A223PerDocNum), StringUtil.RTrim( context.localUtil.Format( A223PerDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Importe Documento", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerImpDoc_Internalname, StringUtil.LTrim( StringUtil.NToC( A1618PerImpDoc, 17, 2, ".", "")), StringUtil.LTrim( ((edtPerImpDoc_Enabled!=0) ? context.localUtil.Format( A1618PerImpDoc, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1618PerImpDoc, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerImpDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerImpDoc_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Importe Percepción", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerImpPer_Internalname, StringUtil.LTrim( StringUtil.NToC( A1619PerImpPer, 17, 2, ".", "")), StringUtil.LTrim( ((edtPerImpPer_Enabled!=0) ? context.localUtil.Format( A1619PerImpPer, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1619PerImpPer, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerImpPer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerImpPer_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPERCEPCIONDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCIONDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLPERCEPCIONDET.htm");
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
            Z219PerTip = cgiGet( "Z219PerTip");
            Z218PerCod = cgiGet( "Z218PerCod");
            Z220PerTDoc = cgiGet( "Z220PerTDoc");
            Z222PerTipCod = cgiGet( "Z222PerTipCod");
            Z223PerDocNum = cgiGet( "Z223PerDocNum");
            Z1618PerImpDoc = context.localUtil.CToN( cgiGet( "Z1618PerImpDoc"), ".", ",");
            Z1619PerImpPer = context.localUtil.CToN( cgiGet( "Z1619PerImpPer"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A219PerTip = cgiGet( edtPerTip_Internalname);
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A218PerCod = cgiGet( edtPerCod_Internalname);
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A220PerTDoc = cgiGet( edtPerTDoc_Internalname);
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            A222PerTipCod = cgiGet( edtPerTipCod_Internalname);
            AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
            A223PerDocNum = cgiGet( edtPerDocNum_Internalname);
            AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPerImpDoc_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPerImpDoc_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERIMPDOC");
               AnyError = 1;
               GX_FocusControl = edtPerImpDoc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1618PerImpDoc = 0;
               AssignAttri("", false, "A1618PerImpDoc", StringUtil.LTrimStr( A1618PerImpDoc, 15, 2));
            }
            else
            {
               A1618PerImpDoc = context.localUtil.CToN( cgiGet( edtPerImpDoc_Internalname), ".", ",");
               AssignAttri("", false, "A1618PerImpDoc", StringUtil.LTrimStr( A1618PerImpDoc, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPerImpPer_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPerImpPer_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERIMPPER");
               AnyError = 1;
               GX_FocusControl = edtPerImpPer_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1619PerImpPer = 0;
               AssignAttri("", false, "A1619PerImpPer", StringUtil.LTrimStr( A1619PerImpPer, 15, 2));
            }
            else
            {
               A1619PerImpPer = context.localUtil.CToN( cgiGet( edtPerImpPer_Internalname), ".", ",");
               AssignAttri("", false, "A1619PerImpPer", StringUtil.LTrimStr( A1619PerImpPer, 15, 2));
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
               A219PerTip = GetPar( "PerTip");
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A218PerCod = GetPar( "PerCod");
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A220PerTDoc = GetPar( "PerTDoc");
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               A222PerTipCod = GetPar( "PerTipCod");
               AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
               A223PerDocNum = GetPar( "PerDocNum");
               AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
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
               InitAll2W99( ) ;
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
         DisableAttributes2W99( ) ;
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

      protected void CONFIRM_2W0( )
      {
         BeforeValidate2W99( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2W99( ) ;
            }
            else
            {
               CheckExtendedTable2W99( ) ;
               if ( AnyError == 0 )
               {
                  ZM2W99( 2) ;
                  ZM2W99( 3) ;
               }
               CloseExtendedTableCursors2W99( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2W0( ) ;
         }
      }

      protected void ResetCaption2W0( )
      {
      }

      protected void ZM2W99( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1618PerImpDoc = T002W3_A1618PerImpDoc[0];
               Z1619PerImpPer = T002W3_A1619PerImpPer[0];
            }
            else
            {
               Z1618PerImpDoc = A1618PerImpDoc;
               Z1619PerImpPer = A1619PerImpPer;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1618PerImpDoc = A1618PerImpDoc;
            Z1619PerImpPer = A1619PerImpPer;
            Z218PerCod = A218PerCod;
            Z219PerTip = A219PerTip;
            Z220PerTDoc = A220PerTDoc;
            Z222PerTipCod = A222PerTipCod;
            Z223PerDocNum = A223PerDocNum;
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

      protected void Load2W99( )
      {
         /* Using cursor T002W6 */
         pr_default.execute(4, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound99 = 1;
            A1618PerImpDoc = T002W6_A1618PerImpDoc[0];
            AssignAttri("", false, "A1618PerImpDoc", StringUtil.LTrimStr( A1618PerImpDoc, 15, 2));
            A1619PerImpPer = T002W6_A1619PerImpPer[0];
            AssignAttri("", false, "A1619PerImpPer", StringUtil.LTrimStr( A1619PerImpPer, 15, 2));
            ZM2W99( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2W99( ) ;
      }

      protected void OnLoadActions2W99( )
      {
      }

      protected void CheckExtendedTable2W99( )
      {
         nIsDirty_99 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002W4 */
         pr_default.execute(2, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Comprobantes de Percepción'.", "ForeignKeyNotFound", 1, "PERTDOC");
            AnyError = 1;
            GX_FocusControl = edtPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002W5 */
         pr_default.execute(3, new Object[] {A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Percepcion'.", "ForeignKeyNotFound", 1, "PERDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtPerTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2W99( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A218PerCod ,
                               string A219PerTip ,
                               string A220PerTDoc )
      {
         /* Using cursor T002W7 */
         pr_default.execute(5, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Comprobantes de Percepción'.", "ForeignKeyNotFound", 1, "PERTDOC");
            AnyError = 1;
            GX_FocusControl = edtPerCod_Internalname;
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

      protected void gxLoad_3( string A222PerTipCod ,
                               string A223PerDocNum )
      {
         /* Using cursor T002W8 */
         pr_default.execute(6, new Object[] {A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Percepcion'.", "ForeignKeyNotFound", 1, "PERDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtPerTipCod_Internalname;
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

      protected void GetKey2W99( )
      {
         /* Using cursor T002W9 */
         pr_default.execute(7, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound99 = 1;
         }
         else
         {
            RcdFound99 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002W3 */
         pr_default.execute(1, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2W99( 1) ;
            RcdFound99 = 1;
            A1618PerImpDoc = T002W3_A1618PerImpDoc[0];
            AssignAttri("", false, "A1618PerImpDoc", StringUtil.LTrimStr( A1618PerImpDoc, 15, 2));
            A1619PerImpPer = T002W3_A1619PerImpPer[0];
            AssignAttri("", false, "A1619PerImpPer", StringUtil.LTrimStr( A1619PerImpPer, 15, 2));
            A218PerCod = T002W3_A218PerCod[0];
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = T002W3_A219PerTip[0];
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = T002W3_A220PerTDoc[0];
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            A222PerTipCod = T002W3_A222PerTipCod[0];
            AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
            A223PerDocNum = T002W3_A223PerDocNum[0];
            AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
            Z219PerTip = A219PerTip;
            Z218PerCod = A218PerCod;
            Z220PerTDoc = A220PerTDoc;
            Z222PerTipCod = A222PerTipCod;
            Z223PerDocNum = A223PerDocNum;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2W99( ) ;
            if ( AnyError == 1 )
            {
               RcdFound99 = 0;
               InitializeNonKey2W99( ) ;
            }
            Gx_mode = sMode99;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound99 = 0;
            InitializeNonKey2W99( ) ;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode99;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2W99( ) ;
         if ( RcdFound99 == 0 )
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
         RcdFound99 = 0;
         /* Using cursor T002W10 */
         pr_default.execute(8, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) < 0 ) || ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) < 0 ) || ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A220PerTDoc[0], A220PerTDoc) < 0 ) || ( StringUtil.StrCmp(T002W10_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A222PerTipCod[0], A222PerTipCod) < 0 ) || ( StringUtil.StrCmp(T002W10_A222PerTipCod[0], A222PerTipCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A223PerDocNum[0], A223PerDocNum) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) > 0 ) || ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) > 0 ) || ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A220PerTDoc[0], A220PerTDoc) > 0 ) || ( StringUtil.StrCmp(T002W10_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A222PerTipCod[0], A222PerTipCod) > 0 ) || ( StringUtil.StrCmp(T002W10_A222PerTipCod[0], A222PerTipCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W10_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W10_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W10_A223PerDocNum[0], A223PerDocNum) > 0 ) ) )
            {
               A219PerTip = T002W10_A219PerTip[0];
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A218PerCod = T002W10_A218PerCod[0];
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A220PerTDoc = T002W10_A220PerTDoc[0];
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               A222PerTipCod = T002W10_A222PerTipCod[0];
               AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
               A223PerDocNum = T002W10_A223PerDocNum[0];
               AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
               RcdFound99 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound99 = 0;
         /* Using cursor T002W11 */
         pr_default.execute(9, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) > 0 ) || ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) > 0 ) || ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A220PerTDoc[0], A220PerTDoc) > 0 ) || ( StringUtil.StrCmp(T002W11_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A222PerTipCod[0], A222PerTipCod) > 0 ) || ( StringUtil.StrCmp(T002W11_A222PerTipCod[0], A222PerTipCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A223PerDocNum[0], A223PerDocNum) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) < 0 ) || ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) < 0 ) || ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A220PerTDoc[0], A220PerTDoc) < 0 ) || ( StringUtil.StrCmp(T002W11_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A222PerTipCod[0], A222PerTipCod) < 0 ) || ( StringUtil.StrCmp(T002W11_A222PerTipCod[0], A222PerTipCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A220PerTDoc[0], A220PerTDoc) == 0 ) && ( StringUtil.StrCmp(T002W11_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002W11_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002W11_A223PerDocNum[0], A223PerDocNum) < 0 ) ) )
            {
               A219PerTip = T002W11_A219PerTip[0];
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A218PerCod = T002W11_A218PerCod[0];
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A220PerTDoc = T002W11_A220PerTDoc[0];
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               A222PerTipCod = T002W11_A222PerTipCod[0];
               AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
               A223PerDocNum = T002W11_A223PerDocNum[0];
               AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
               RcdFound99 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2W99( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPerTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2W99( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound99 == 1 )
            {
               if ( ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) || ( StringUtil.StrCmp(A222PerTipCod, Z222PerTipCod) != 0 ) || ( StringUtil.StrCmp(A223PerDocNum, Z223PerDocNum) != 0 ) )
               {
                  A219PerTip = Z219PerTip;
                  AssignAttri("", false, "A219PerTip", A219PerTip);
                  A218PerCod = Z218PerCod;
                  AssignAttri("", false, "A218PerCod", A218PerCod);
                  A220PerTDoc = Z220PerTDoc;
                  AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
                  A222PerTipCod = Z222PerTipCod;
                  AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
                  A223PerDocNum = Z223PerDocNum;
                  AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PERTIP");
                  AnyError = 1;
                  GX_FocusControl = edtPerTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPerTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2W99( ) ;
                  GX_FocusControl = edtPerTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) || ( StringUtil.StrCmp(A222PerTipCod, Z222PerTipCod) != 0 ) || ( StringUtil.StrCmp(A223PerDocNum, Z223PerDocNum) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPerTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2W99( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PERTIP");
                     AnyError = 1;
                     GX_FocusControl = edtPerTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPerTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2W99( ) ;
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
         if ( ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) || ( StringUtil.StrCmp(A222PerTipCod, Z222PerTipCod) != 0 ) || ( StringUtil.StrCmp(A223PerDocNum, Z223PerDocNum) != 0 ) )
         {
            A219PerTip = Z219PerTip;
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A218PerCod = Z218PerCod;
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A220PerTDoc = Z220PerTDoc;
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            A222PerTipCod = Z222PerTipCod;
            AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
            A223PerDocNum = Z223PerDocNum;
            AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PERTIP");
            AnyError = 1;
            GX_FocusControl = edtPerTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPerTip_Internalname;
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
         GetKey2W99( ) ;
         if ( RcdFound99 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PERTIP");
               AnyError = 1;
               GX_FocusControl = edtPerTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) || ( StringUtil.StrCmp(A222PerTipCod, Z222PerTipCod) != 0 ) || ( StringUtil.StrCmp(A223PerDocNum, Z223PerDocNum) != 0 ) )
            {
               A219PerTip = Z219PerTip;
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A218PerCod = Z218PerCod;
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A220PerTDoc = Z220PerTDoc;
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               A222PerTipCod = Z222PerTipCod;
               AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
               A223PerDocNum = Z223PerDocNum;
               AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PERTIP");
               AnyError = 1;
               GX_FocusControl = edtPerTip_Internalname;
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
            if ( ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) || ( StringUtil.StrCmp(A222PerTipCod, Z222PerTipCod) != 0 ) || ( StringUtil.StrCmp(A223PerDocNum, Z223PerDocNum) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PERTIP");
                  AnyError = 1;
                  GX_FocusControl = edtPerTip_Internalname;
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
         context.RollbackDataStores("clpercepciondet",pr_default);
         GX_FocusControl = edtPerImpDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2W0( ) ;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PERTIP");
            AnyError = 1;
            GX_FocusControl = edtPerTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPerImpDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2W99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerImpDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2W99( ) ;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerImpDoc_Internalname;
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
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerImpDoc_Internalname;
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
         ScanStart2W99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound99 != 0 )
            {
               ScanNext2W99( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerImpDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2W99( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2W99( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002W2 */
            pr_default.execute(0, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPERCEPCIONDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1618PerImpDoc != T002W2_A1618PerImpDoc[0] ) || ( Z1619PerImpPer != T002W2_A1619PerImpPer[0] ) )
            {
               if ( Z1618PerImpDoc != T002W2_A1618PerImpDoc[0] )
               {
                  GXUtil.WriteLog("clpercepciondet:[seudo value changed for attri]"+"PerImpDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1618PerImpDoc);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A1618PerImpDoc[0]);
               }
               if ( Z1619PerImpPer != T002W2_A1619PerImpPer[0] )
               {
                  GXUtil.WriteLog("clpercepciondet:[seudo value changed for attri]"+"PerImpPer");
                  GXUtil.WriteLogRaw("Old: ",Z1619PerImpPer);
                  GXUtil.WriteLogRaw("Current: ",T002W2_A1619PerImpPer[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLPERCEPCIONDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2W99( )
      {
         BeforeValidate2W99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W99( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2W99( 0) ;
            CheckOptimisticConcurrency2W99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2W99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002W12 */
                     pr_default.execute(10, new Object[] {A1618PerImpDoc, A1619PerImpPer, A218PerCod, A219PerTip, A220PerTDoc, A222PerTipCod, A223PerDocNum});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPERCEPCIONDET");
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
                           ResetCaption2W0( ) ;
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
               Load2W99( ) ;
            }
            EndLevel2W99( ) ;
         }
         CloseExtendedTableCursors2W99( ) ;
      }

      protected void Update2W99( )
      {
         BeforeValidate2W99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W99( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2W99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002W13 */
                     pr_default.execute(11, new Object[] {A1618PerImpDoc, A1619PerImpPer, A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPERCEPCIONDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPERCEPCIONDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2W99( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2W0( ) ;
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
            EndLevel2W99( ) ;
         }
         CloseExtendedTableCursors2W99( ) ;
      }

      protected void DeferredUpdate2W99( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2W99( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W99( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2W99( ) ;
            AfterConfirm2W99( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2W99( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002W14 */
                  pr_default.execute(12, new Object[] {A219PerTip, A218PerCod, A220PerTDoc, A222PerTipCod, A223PerDocNum});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLPERCEPCIONDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound99 == 0 )
                        {
                           InitAll2W99( ) ;
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
                        ResetCaption2W0( ) ;
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
         sMode99 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2W99( ) ;
         Gx_mode = sMode99;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2W99( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2W99( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2W99( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clpercepciondet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clpercepciondet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2W99( )
      {
         /* Using cursor T002W15 */
         pr_default.execute(13);
         RcdFound99 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound99 = 1;
            A219PerTip = T002W15_A219PerTip[0];
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A218PerCod = T002W15_A218PerCod[0];
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A220PerTDoc = T002W15_A220PerTDoc[0];
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            A222PerTipCod = T002W15_A222PerTipCod[0];
            AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
            A223PerDocNum = T002W15_A223PerDocNum[0];
            AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2W99( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound99 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound99 = 1;
            A219PerTip = T002W15_A219PerTip[0];
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A218PerCod = T002W15_A218PerCod[0];
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A220PerTDoc = T002W15_A220PerTDoc[0];
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            A222PerTipCod = T002W15_A222PerTipCod[0];
            AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
            A223PerDocNum = T002W15_A223PerDocNum[0];
            AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
         }
      }

      protected void ScanEnd2W99( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2W99( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2W99( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2W99( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2W99( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2W99( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2W99( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2W99( )
      {
         edtPerTip_Enabled = 0;
         AssignProp("", false, edtPerTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTip_Enabled), 5, 0), true);
         edtPerCod_Enabled = 0;
         AssignProp("", false, edtPerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerCod_Enabled), 5, 0), true);
         edtPerTDoc_Enabled = 0;
         AssignProp("", false, edtPerTDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTDoc_Enabled), 5, 0), true);
         edtPerTipCod_Enabled = 0;
         AssignProp("", false, edtPerTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTipCod_Enabled), 5, 0), true);
         edtPerDocNum_Enabled = 0;
         AssignProp("", false, edtPerDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerDocNum_Enabled), 5, 0), true);
         edtPerImpDoc_Enabled = 0;
         AssignProp("", false, edtPerImpDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerImpDoc_Enabled), 5, 0), true);
         edtPerImpPer_Enabled = 0;
         AssignProp("", false, edtPerImpPer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerImpPer_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2W99( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2W0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810244954", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clpercepciondet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z219PerTip", StringUtil.RTrim( Z219PerTip));
         GxWebStd.gx_hidden_field( context, "Z218PerCod", StringUtil.RTrim( Z218PerCod));
         GxWebStd.gx_hidden_field( context, "Z220PerTDoc", Z220PerTDoc);
         GxWebStd.gx_hidden_field( context, "Z222PerTipCod", StringUtil.RTrim( Z222PerTipCod));
         GxWebStd.gx_hidden_field( context, "Z223PerDocNum", StringUtil.RTrim( Z223PerDocNum));
         GxWebStd.gx_hidden_field( context, "Z1618PerImpDoc", StringUtil.LTrim( StringUtil.NToC( Z1618PerImpDoc, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1619PerImpPer", StringUtil.LTrim( StringUtil.NToC( Z1619PerImpPer, 15, 2, ".", "")));
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
         return formatLink("clpercepciondet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLPERCEPCIONDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle de Comprobante de Percepción" ;
      }

      protected void InitializeNonKey2W99( )
      {
         A1618PerImpDoc = 0;
         AssignAttri("", false, "A1618PerImpDoc", StringUtil.LTrimStr( A1618PerImpDoc, 15, 2));
         A1619PerImpPer = 0;
         AssignAttri("", false, "A1619PerImpPer", StringUtil.LTrimStr( A1619PerImpPer, 15, 2));
         Z1618PerImpDoc = 0;
         Z1619PerImpPer = 0;
      }

      protected void InitAll2W99( )
      {
         A219PerTip = "";
         AssignAttri("", false, "A219PerTip", A219PerTip);
         A218PerCod = "";
         AssignAttri("", false, "A218PerCod", A218PerCod);
         A220PerTDoc = "";
         AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
         A222PerTipCod = "";
         AssignAttri("", false, "A222PerTipCod", A222PerTipCod);
         A223PerDocNum = "";
         AssignAttri("", false, "A223PerDocNum", A223PerDocNum);
         InitializeNonKey2W99( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810244959", true, true);
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
         context.AddJavascriptSource("clpercepciondet.js", "?202281810244960", false, true);
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
         edtPerTip_Internalname = "PERTIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPerCod_Internalname = "PERCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPerTDoc_Internalname = "PERTDOC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPerTipCod_Internalname = "PERTIPCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPerDocNum_Internalname = "PERDOCNUM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPerImpDoc_Internalname = "PERIMPDOC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPerImpPer_Internalname = "PERIMPPER";
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
         Form.Caption = "Detalle de Comprobante de Percepción";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPerImpPer_Jsonclick = "";
         edtPerImpPer_Enabled = 1;
         edtPerImpDoc_Jsonclick = "";
         edtPerImpDoc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPerDocNum_Jsonclick = "";
         edtPerDocNum_Enabled = 1;
         edtPerTipCod_Jsonclick = "";
         edtPerTipCod_Enabled = 1;
         edtPerTDoc_Jsonclick = "";
         edtPerTDoc_Enabled = 1;
         edtPerCod_Jsonclick = "";
         edtPerCod_Enabled = 1;
         edtPerTip_Jsonclick = "";
         edtPerTip_Enabled = 1;
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
         /* Using cursor T002W16 */
         pr_default.execute(14, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Comprobantes de Percepción'.", "ForeignKeyNotFound", 1, "PERTDOC");
            AnyError = 1;
            GX_FocusControl = edtPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T002W17 */
         pr_default.execute(15, new Object[] {A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Percepcion'.", "ForeignKeyNotFound", 1, "PERDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtPerTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtPerImpDoc_Internalname;
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

      public void Valid_Pertdoc( )
      {
         /* Using cursor T002W16 */
         pr_default.execute(14, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Comprobantes de Percepción'.", "ForeignKeyNotFound", 1, "PERTDOC");
            AnyError = 1;
            GX_FocusControl = edtPerCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Perdocnum( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002W17 */
         pr_default.execute(15, new Object[] {A222PerTipCod, A223PerDocNum});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Percepcion'.", "ForeignKeyNotFound", 1, "PERDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtPerTipCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1618PerImpDoc", StringUtil.LTrim( StringUtil.NToC( A1618PerImpDoc, 15, 2, ".", "")));
         AssignAttri("", false, "A1619PerImpPer", StringUtil.LTrim( StringUtil.NToC( A1619PerImpPer, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z219PerTip", StringUtil.RTrim( Z219PerTip));
         GxWebStd.gx_hidden_field( context, "Z218PerCod", StringUtil.RTrim( Z218PerCod));
         GxWebStd.gx_hidden_field( context, "Z220PerTDoc", Z220PerTDoc);
         GxWebStd.gx_hidden_field( context, "Z222PerTipCod", StringUtil.RTrim( Z222PerTipCod));
         GxWebStd.gx_hidden_field( context, "Z223PerDocNum", StringUtil.RTrim( Z223PerDocNum));
         GxWebStd.gx_hidden_field( context, "Z1618PerImpDoc", StringUtil.LTrim( StringUtil.NToC( Z1618PerImpDoc, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1619PerImpPer", StringUtil.LTrim( StringUtil.NToC( Z1619PerImpPer, 15, 2, ".", "")));
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
         setEventMetadata("VALID_PERTIP","{handler:'Valid_Pertip',iparms:[]");
         setEventMetadata("VALID_PERTIP",",oparms:[]}");
         setEventMetadata("VALID_PERCOD","{handler:'Valid_Percod',iparms:[]");
         setEventMetadata("VALID_PERCOD",",oparms:[]}");
         setEventMetadata("VALID_PERTDOC","{handler:'Valid_Pertdoc',iparms:[{av:'A218PerCod',fld:'PERCOD',pic:''},{av:'A219PerTip',fld:'PERTIP',pic:''},{av:'A220PerTDoc',fld:'PERTDOC',pic:''}]");
         setEventMetadata("VALID_PERTDOC",",oparms:[]}");
         setEventMetadata("VALID_PERTIPCOD","{handler:'Valid_Pertipcod',iparms:[]");
         setEventMetadata("VALID_PERTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_PERDOCNUM","{handler:'Valid_Perdocnum',iparms:[{av:'A219PerTip',fld:'PERTIP',pic:''},{av:'A218PerCod',fld:'PERCOD',pic:''},{av:'A220PerTDoc',fld:'PERTDOC',pic:''},{av:'A222PerTipCod',fld:'PERTIPCOD',pic:''},{av:'A223PerDocNum',fld:'PERDOCNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PERDOCNUM",",oparms:[{av:'A1618PerImpDoc',fld:'PERIMPDOC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1619PerImpPer',fld:'PERIMPPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z219PerTip'},{av:'Z218PerCod'},{av:'Z220PerTDoc'},{av:'Z222PerTipCod'},{av:'Z223PerDocNum'},{av:'Z1618PerImpDoc'},{av:'Z1619PerImpPer'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z219PerTip = "";
         Z218PerCod = "";
         Z220PerTDoc = "";
         Z222PerTipCod = "";
         Z223PerDocNum = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A218PerCod = "";
         A219PerTip = "";
         A220PerTDoc = "";
         A222PerTipCod = "";
         A223PerDocNum = "";
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
         lblTextblock5_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
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
         T002W6_A1618PerImpDoc = new decimal[1] ;
         T002W6_A1619PerImpPer = new decimal[1] ;
         T002W6_A218PerCod = new string[] {""} ;
         T002W6_A219PerTip = new string[] {""} ;
         T002W6_A220PerTDoc = new string[] {""} ;
         T002W6_A222PerTipCod = new string[] {""} ;
         T002W6_A223PerDocNum = new string[] {""} ;
         T002W4_A218PerCod = new string[] {""} ;
         T002W5_A222PerTipCod = new string[] {""} ;
         T002W7_A218PerCod = new string[] {""} ;
         T002W8_A222PerTipCod = new string[] {""} ;
         T002W9_A219PerTip = new string[] {""} ;
         T002W9_A218PerCod = new string[] {""} ;
         T002W9_A220PerTDoc = new string[] {""} ;
         T002W9_A222PerTipCod = new string[] {""} ;
         T002W9_A223PerDocNum = new string[] {""} ;
         T002W3_A1618PerImpDoc = new decimal[1] ;
         T002W3_A1619PerImpPer = new decimal[1] ;
         T002W3_A218PerCod = new string[] {""} ;
         T002W3_A219PerTip = new string[] {""} ;
         T002W3_A220PerTDoc = new string[] {""} ;
         T002W3_A222PerTipCod = new string[] {""} ;
         T002W3_A223PerDocNum = new string[] {""} ;
         sMode99 = "";
         T002W10_A219PerTip = new string[] {""} ;
         T002W10_A218PerCod = new string[] {""} ;
         T002W10_A220PerTDoc = new string[] {""} ;
         T002W10_A222PerTipCod = new string[] {""} ;
         T002W10_A223PerDocNum = new string[] {""} ;
         T002W11_A219PerTip = new string[] {""} ;
         T002W11_A218PerCod = new string[] {""} ;
         T002W11_A220PerTDoc = new string[] {""} ;
         T002W11_A222PerTipCod = new string[] {""} ;
         T002W11_A223PerDocNum = new string[] {""} ;
         T002W2_A1618PerImpDoc = new decimal[1] ;
         T002W2_A1619PerImpPer = new decimal[1] ;
         T002W2_A218PerCod = new string[] {""} ;
         T002W2_A219PerTip = new string[] {""} ;
         T002W2_A220PerTDoc = new string[] {""} ;
         T002W2_A222PerTipCod = new string[] {""} ;
         T002W2_A223PerDocNum = new string[] {""} ;
         T002W15_A219PerTip = new string[] {""} ;
         T002W15_A218PerCod = new string[] {""} ;
         T002W15_A220PerTDoc = new string[] {""} ;
         T002W15_A222PerTipCod = new string[] {""} ;
         T002W15_A223PerDocNum = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002W16_A218PerCod = new string[] {""} ;
         T002W17_A222PerTipCod = new string[] {""} ;
         ZZ219PerTip = "";
         ZZ218PerCod = "";
         ZZ220PerTDoc = "";
         ZZ222PerTipCod = "";
         ZZ223PerDocNum = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clpercepciondet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpercepciondet__default(),
            new Object[][] {
                new Object[] {
               T002W2_A1618PerImpDoc, T002W2_A1619PerImpPer, T002W2_A218PerCod, T002W2_A219PerTip, T002W2_A220PerTDoc, T002W2_A222PerTipCod, T002W2_A223PerDocNum
               }
               , new Object[] {
               T002W3_A1618PerImpDoc, T002W3_A1619PerImpPer, T002W3_A218PerCod, T002W3_A219PerTip, T002W3_A220PerTDoc, T002W3_A222PerTipCod, T002W3_A223PerDocNum
               }
               , new Object[] {
               T002W4_A218PerCod
               }
               , new Object[] {
               T002W5_A222PerTipCod
               }
               , new Object[] {
               T002W6_A1618PerImpDoc, T002W6_A1619PerImpPer, T002W6_A218PerCod, T002W6_A219PerTip, T002W6_A220PerTDoc, T002W6_A222PerTipCod, T002W6_A223PerDocNum
               }
               , new Object[] {
               T002W7_A218PerCod
               }
               , new Object[] {
               T002W8_A222PerTipCod
               }
               , new Object[] {
               T002W9_A219PerTip, T002W9_A218PerCod, T002W9_A220PerTDoc, T002W9_A222PerTipCod, T002W9_A223PerDocNum
               }
               , new Object[] {
               T002W10_A219PerTip, T002W10_A218PerCod, T002W10_A220PerTDoc, T002W10_A222PerTipCod, T002W10_A223PerDocNum
               }
               , new Object[] {
               T002W11_A219PerTip, T002W11_A218PerCod, T002W11_A220PerTDoc, T002W11_A222PerTipCod, T002W11_A223PerDocNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002W15_A219PerTip, T002W15_A218PerCod, T002W15_A220PerTDoc, T002W15_A222PerTipCod, T002W15_A223PerDocNum
               }
               , new Object[] {
               T002W16_A218PerCod
               }
               , new Object[] {
               T002W17_A222PerTipCod
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
      private short RcdFound99 ;
      private short nIsDirty_99 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPerTip_Enabled ;
      private int edtPerCod_Enabled ;
      private int edtPerTDoc_Enabled ;
      private int edtPerTipCod_Enabled ;
      private int edtPerDocNum_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPerImpDoc_Enabled ;
      private int edtPerImpPer_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z1618PerImpDoc ;
      private decimal Z1619PerImpPer ;
      private decimal A1618PerImpDoc ;
      private decimal A1619PerImpPer ;
      private decimal ZZ1618PerImpDoc ;
      private decimal ZZ1619PerImpPer ;
      private string sPrefix ;
      private string Z219PerTip ;
      private string Z218PerCod ;
      private string Z222PerTipCod ;
      private string Z223PerDocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A218PerCod ;
      private string A219PerTip ;
      private string A222PerTipCod ;
      private string A223PerDocNum ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPerTip_Internalname ;
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
      private string edtPerTip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPerCod_Internalname ;
      private string edtPerCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPerTDoc_Internalname ;
      private string edtPerTDoc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPerTipCod_Internalname ;
      private string edtPerTipCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPerDocNum_Internalname ;
      private string edtPerDocNum_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPerImpDoc_Internalname ;
      private string edtPerImpDoc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPerImpPer_Internalname ;
      private string edtPerImpPer_Jsonclick ;
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
      private string sMode99 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ219PerTip ;
      private string ZZ218PerCod ;
      private string ZZ222PerTipCod ;
      private string ZZ223PerDocNum ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z220PerTDoc ;
      private string A220PerTDoc ;
      private string ZZ220PerTDoc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T002W6_A1618PerImpDoc ;
      private decimal[] T002W6_A1619PerImpPer ;
      private string[] T002W6_A218PerCod ;
      private string[] T002W6_A219PerTip ;
      private string[] T002W6_A220PerTDoc ;
      private string[] T002W6_A222PerTipCod ;
      private string[] T002W6_A223PerDocNum ;
      private string[] T002W4_A218PerCod ;
      private string[] T002W5_A222PerTipCod ;
      private string[] T002W7_A218PerCod ;
      private string[] T002W8_A222PerTipCod ;
      private string[] T002W9_A219PerTip ;
      private string[] T002W9_A218PerCod ;
      private string[] T002W9_A220PerTDoc ;
      private string[] T002W9_A222PerTipCod ;
      private string[] T002W9_A223PerDocNum ;
      private decimal[] T002W3_A1618PerImpDoc ;
      private decimal[] T002W3_A1619PerImpPer ;
      private string[] T002W3_A218PerCod ;
      private string[] T002W3_A219PerTip ;
      private string[] T002W3_A220PerTDoc ;
      private string[] T002W3_A222PerTipCod ;
      private string[] T002W3_A223PerDocNum ;
      private string[] T002W10_A219PerTip ;
      private string[] T002W10_A218PerCod ;
      private string[] T002W10_A220PerTDoc ;
      private string[] T002W10_A222PerTipCod ;
      private string[] T002W10_A223PerDocNum ;
      private string[] T002W11_A219PerTip ;
      private string[] T002W11_A218PerCod ;
      private string[] T002W11_A220PerTDoc ;
      private string[] T002W11_A222PerTipCod ;
      private string[] T002W11_A223PerDocNum ;
      private decimal[] T002W2_A1618PerImpDoc ;
      private decimal[] T002W2_A1619PerImpPer ;
      private string[] T002W2_A218PerCod ;
      private string[] T002W2_A219PerTip ;
      private string[] T002W2_A220PerTDoc ;
      private string[] T002W2_A222PerTipCod ;
      private string[] T002W2_A223PerDocNum ;
      private string[] T002W15_A219PerTip ;
      private string[] T002W15_A218PerCod ;
      private string[] T002W15_A220PerTDoc ;
      private string[] T002W15_A222PerTipCod ;
      private string[] T002W15_A223PerDocNum ;
      private string[] T002W16_A218PerCod ;
      private string[] T002W17_A222PerTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clpercepciondet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clpercepciondet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002W6;
        prmT002W6 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W4;
        prmT002W4 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002W5;
        prmT002W5 = new Object[] {
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W7;
        prmT002W7 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002W8;
        prmT002W8 = new Object[] {
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W9;
        prmT002W9 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W3;
        prmT002W3 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W10;
        prmT002W10 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W11;
        prmT002W11 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W2;
        prmT002W2 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W12;
        prmT002W12 = new Object[] {
        new ParDef("@PerImpDoc",GXType.Decimal,15,2) ,
        new ParDef("@PerImpPer",GXType.Decimal,15,2) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W13;
        prmT002W13 = new Object[] {
        new ParDef("@PerImpDoc",GXType.Decimal,15,2) ,
        new ParDef("@PerImpPer",GXType.Decimal,15,2) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W14;
        prmT002W14 = new Object[] {
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002W15;
        prmT002W15 = new Object[] {
        };
        Object[] prmT002W16;
        prmT002W16 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002W17;
        prmT002W17 = new Object[] {
        new ParDef("@PerTipCod",GXType.NChar,3,0) ,
        new ParDef("@PerDocNum",GXType.NChar,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002W2", "SELECT [PerImpDoc], [PerImpPer], [PerCod], [PerTip], [PerTDoc], [PerTipCod] AS PerTipCod, [PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] WITH (UPDLOCK) WHERE [PerTip] = @PerTip AND [PerCod] = @PerCod AND [PerTDoc] = @PerTDoc AND [PerTipCod] = @PerTipCod AND [PerDocNum] = @PerDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W3", "SELECT [PerImpDoc], [PerImpPer], [PerCod], [PerTip], [PerTDoc], [PerTipCod] AS PerTipCod, [PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] WHERE [PerTip] = @PerTip AND [PerCod] = @PerCod AND [PerTDoc] = @PerTDoc AND [PerTipCod] = @PerTipCod AND [PerDocNum] = @PerDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W4", "SELECT [PerCod] FROM [CLPERCEPCION] WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W5", "SELECT [CCTipCod] AS PerTipCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @PerTipCod AND [CCDocNum] = @PerDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W6", "SELECT TM1.[PerImpDoc], TM1.[PerImpPer], TM1.[PerCod], TM1.[PerTip], TM1.[PerTDoc], TM1.[PerTipCod] AS PerTipCod, TM1.[PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] TM1 WHERE TM1.[PerTip] = @PerTip and TM1.[PerCod] = @PerCod and TM1.[PerTDoc] = @PerTDoc and TM1.[PerTipCod] = @PerTipCod and TM1.[PerDocNum] = @PerDocNum ORDER BY TM1.[PerTip], TM1.[PerCod], TM1.[PerTDoc], TM1.[PerTipCod], TM1.[PerDocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W7", "SELECT [PerCod] FROM [CLPERCEPCION] WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W8", "SELECT [CCTipCod] AS PerTipCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @PerTipCod AND [CCDocNum] = @PerDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W9", "SELECT [PerTip], [PerCod], [PerTDoc], [PerTipCod] AS PerTipCod, [PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] WHERE [PerTip] = @PerTip AND [PerCod] = @PerCod AND [PerTDoc] = @PerTDoc AND [PerTipCod] = @PerTipCod AND [PerDocNum] = @PerDocNum  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W10", "SELECT TOP 1 [PerTip], [PerCod], [PerTDoc], [PerTipCod] AS PerTipCod, [PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] WHERE ( [PerTip] > @PerTip or [PerTip] = @PerTip and [PerCod] > @PerCod or [PerCod] = @PerCod and [PerTip] = @PerTip and [PerTDoc] > @PerTDoc or [PerTDoc] = @PerTDoc and [PerCod] = @PerCod and [PerTip] = @PerTip and [PerTipCod] > @PerTipCod or [PerTipCod] = @PerTipCod and [PerTDoc] = @PerTDoc and [PerCod] = @PerCod and [PerTip] = @PerTip and [PerDocNum] > @PerDocNum) ORDER BY [PerTip], [PerCod], [PerTDoc], [PerTipCod], [PerDocNum]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W11", "SELECT TOP 1 [PerTip], [PerCod], [PerTDoc], [PerTipCod] AS PerTipCod, [PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] WHERE ( [PerTip] < @PerTip or [PerTip] = @PerTip and [PerCod] < @PerCod or [PerCod] = @PerCod and [PerTip] = @PerTip and [PerTDoc] < @PerTDoc or [PerTDoc] = @PerTDoc and [PerCod] = @PerCod and [PerTip] = @PerTip and [PerTipCod] < @PerTipCod or [PerTipCod] = @PerTipCod and [PerTDoc] = @PerTDoc and [PerCod] = @PerCod and [PerTip] = @PerTip and [PerDocNum] < @PerDocNum) ORDER BY [PerTip] DESC, [PerCod] DESC, [PerTDoc] DESC, [PerTipCod] DESC, [PerDocNum] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002W12", "INSERT INTO [CLPERCEPCIONDET]([PerImpDoc], [PerImpPer], [PerCod], [PerTip], [PerTDoc], [PerTipCod], [PerDocNum]) VALUES(@PerImpDoc, @PerImpPer, @PerCod, @PerTip, @PerTDoc, @PerTipCod, @PerDocNum)", GxErrorMask.GX_NOMASK,prmT002W12)
           ,new CursorDef("T002W13", "UPDATE [CLPERCEPCIONDET] SET [PerImpDoc]=@PerImpDoc, [PerImpPer]=@PerImpPer  WHERE [PerTip] = @PerTip AND [PerCod] = @PerCod AND [PerTDoc] = @PerTDoc AND [PerTipCod] = @PerTipCod AND [PerDocNum] = @PerDocNum", GxErrorMask.GX_NOMASK,prmT002W13)
           ,new CursorDef("T002W14", "DELETE FROM [CLPERCEPCIONDET]  WHERE [PerTip] = @PerTip AND [PerCod] = @PerCod AND [PerTDoc] = @PerTDoc AND [PerTipCod] = @PerTipCod AND [PerDocNum] = @PerDocNum", GxErrorMask.GX_NOMASK,prmT002W14)
           ,new CursorDef("T002W15", "SELECT [PerTip], [PerCod], [PerTDoc], [PerTipCod] AS PerTipCod, [PerDocNum] AS PerDocNum FROM [CLPERCEPCIONDET] ORDER BY [PerTip], [PerCod], [PerTDoc], [PerTipCod], [PerDocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002W15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W16", "SELECT [PerCod] FROM [CLPERCEPCION] WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002W17", "SELECT [CCTipCod] AS PerTipCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @PerTipCod AND [CCDocNum] = @PerDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002W17,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 12);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
