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
   public class clineaprod : GXHttpHandler
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
            Form.Meta.addItem("description", "Lineas de Productos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clineaprod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clineaprod( IGxContext context )
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
            RenderHtmlCloseForm2O17( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLINEAPROD.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo de Linea", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripcion de Linea", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinDsc_Internalname, StringUtil.RTrim( A1153LinDsc), StringUtil.RTrim( context.localUtil.Format( A1153LinDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura de Linea", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinAbr_Internalname, StringUtil.RTrim( A1152LinAbr), StringUtil.RTrim( context.localUtil.Format( A1152LinAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cod.Sunat", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinSunat_Internalname, A1160LinSunat, StringUtil.RTrim( context.localUtil.Format( A1160LinSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Controla Stock", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtLinStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1158LinStk), "9") : context.localUtil.Format( (decimal)(A1158LinStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Situacion de Linea", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1159LinSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtLinSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1159LinSts), "9") : context.localUtil.Format( (decimal)(A1159LinSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Referencia 1", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef1_Internalname, A1154LinRef1, StringUtil.RTrim( context.localUtil.Format( A1154LinRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Referencia 2 (Fecha)", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef2_Internalname, A1155LinRef2, StringUtil.RTrim( context.localUtil.Format( A1155LinRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Referencia 3", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef3_Internalname, A1156LinRef3, StringUtil.RTrim( context.localUtil.Format( A1156LinRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Referencia 4", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLINEAPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef4_Internalname, A1157LinRef4, StringUtil.RTrim( context.localUtil.Format( A1157LinRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLINEAPROD.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLINEAPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLINEAPROD.htm");
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
            Z52LinCod = (int)(context.localUtil.CToN( cgiGet( "Z52LinCod"), ".", ","));
            Z1153LinDsc = cgiGet( "Z1153LinDsc");
            Z1152LinAbr = cgiGet( "Z1152LinAbr");
            Z1160LinSunat = cgiGet( "Z1160LinSunat");
            Z1158LinStk = (short)(context.localUtil.CToN( cgiGet( "Z1158LinStk"), ".", ","));
            Z1159LinSts = (short)(context.localUtil.CToN( cgiGet( "Z1159LinSts"), ".", ","));
            Z1154LinRef1 = cgiGet( "Z1154LinRef1");
            Z1155LinRef2 = cgiGet( "Z1155LinRef2");
            Z1156LinRef3 = cgiGet( "Z1156LinRef3");
            Z1157LinRef4 = cgiGet( "Z1157LinRef4");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINCOD");
               AnyError = 1;
               GX_FocusControl = edtLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A52LinCod = 0;
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            }
            else
            {
               A52LinCod = (int)(context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ","));
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            }
            A1153LinDsc = cgiGet( edtLinDsc_Internalname);
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            A1152LinAbr = cgiGet( edtLinAbr_Internalname);
            AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
            A1160LinSunat = cgiGet( edtLinSunat_Internalname);
            AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINSTK");
               AnyError = 1;
               GX_FocusControl = edtLinStk_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1158LinStk = 0;
               AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            }
            else
            {
               A1158LinStk = (short)(context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ","));
               AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLinSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINSTS");
               AnyError = 1;
               GX_FocusControl = edtLinSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1159LinSts = 0;
               AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
            }
            else
            {
               A1159LinSts = (short)(context.localUtil.CToN( cgiGet( edtLinSts_Internalname), ".", ","));
               AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
            }
            A1154LinRef1 = cgiGet( edtLinRef1_Internalname);
            AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
            A1155LinRef2 = cgiGet( edtLinRef2_Internalname);
            AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
            A1156LinRef3 = cgiGet( edtLinRef3_Internalname);
            AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
            A1157LinRef4 = cgiGet( edtLinRef4_Internalname);
            AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
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
               A52LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
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
               InitAll2O17( ) ;
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
         DisableAttributes2O17( ) ;
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

      protected void CONFIRM_2O0( )
      {
         BeforeValidate2O17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2O17( ) ;
            }
            else
            {
               CheckExtendedTable2O17( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2O17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2O0( ) ;
         }
      }

      protected void ResetCaption2O0( )
      {
      }

      protected void ZM2O17( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1153LinDsc = T002O3_A1153LinDsc[0];
               Z1152LinAbr = T002O3_A1152LinAbr[0];
               Z1160LinSunat = T002O3_A1160LinSunat[0];
               Z1158LinStk = T002O3_A1158LinStk[0];
               Z1159LinSts = T002O3_A1159LinSts[0];
               Z1154LinRef1 = T002O3_A1154LinRef1[0];
               Z1155LinRef2 = T002O3_A1155LinRef2[0];
               Z1156LinRef3 = T002O3_A1156LinRef3[0];
               Z1157LinRef4 = T002O3_A1157LinRef4[0];
            }
            else
            {
               Z1153LinDsc = A1153LinDsc;
               Z1152LinAbr = A1152LinAbr;
               Z1160LinSunat = A1160LinSunat;
               Z1158LinStk = A1158LinStk;
               Z1159LinSts = A1159LinSts;
               Z1154LinRef1 = A1154LinRef1;
               Z1155LinRef2 = A1155LinRef2;
               Z1156LinRef3 = A1156LinRef3;
               Z1157LinRef4 = A1157LinRef4;
            }
         }
         if ( GX_JID == -1 )
         {
            Z52LinCod = A52LinCod;
            Z1153LinDsc = A1153LinDsc;
            Z1152LinAbr = A1152LinAbr;
            Z1160LinSunat = A1160LinSunat;
            Z1158LinStk = A1158LinStk;
            Z1159LinSts = A1159LinSts;
            Z1154LinRef1 = A1154LinRef1;
            Z1155LinRef2 = A1155LinRef2;
            Z1156LinRef3 = A1156LinRef3;
            Z1157LinRef4 = A1157LinRef4;
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

      protected void Load2O17( )
      {
         /* Using cursor T002O4 */
         pr_default.execute(2, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A1153LinDsc = T002O4_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            A1152LinAbr = T002O4_A1152LinAbr[0];
            AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
            A1160LinSunat = T002O4_A1160LinSunat[0];
            AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
            A1158LinStk = T002O4_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A1159LinSts = T002O4_A1159LinSts[0];
            AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
            A1154LinRef1 = T002O4_A1154LinRef1[0];
            AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
            A1155LinRef2 = T002O4_A1155LinRef2[0];
            AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
            A1156LinRef3 = T002O4_A1156LinRef3[0];
            AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
            A1157LinRef4 = T002O4_A1157LinRef4[0];
            AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
            ZM2O17( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2O17( ) ;
      }

      protected void OnLoadActions2O17( )
      {
      }

      protected void CheckExtendedTable2O17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2O17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2O17( )
      {
         /* Using cursor T002O5 */
         pr_default.execute(3, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002O3 */
         pr_default.execute(1, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2O17( 1) ;
            RcdFound17 = 1;
            A52LinCod = T002O3_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            A1153LinDsc = T002O3_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            A1152LinAbr = T002O3_A1152LinAbr[0];
            AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
            A1160LinSunat = T002O3_A1160LinSunat[0];
            AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
            A1158LinStk = T002O3_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A1159LinSts = T002O3_A1159LinSts[0];
            AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
            A1154LinRef1 = T002O3_A1154LinRef1[0];
            AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
            A1155LinRef2 = T002O3_A1155LinRef2[0];
            AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
            A1156LinRef3 = T002O3_A1156LinRef3[0];
            AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
            A1157LinRef4 = T002O3_A1157LinRef4[0];
            AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
            Z52LinCod = A52LinCod;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2O17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey2O17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey2O17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2O17( ) ;
         if ( RcdFound17 == 0 )
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
         RcdFound17 = 0;
         /* Using cursor T002O6 */
         pr_default.execute(4, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002O6_A52LinCod[0] < A52LinCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002O6_A52LinCod[0] > A52LinCod ) ) )
            {
               A52LinCod = T002O6_A52LinCod[0];
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T002O7 */
         pr_default.execute(5, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002O7_A52LinCod[0] > A52LinCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002O7_A52LinCod[0] < A52LinCod ) ) )
            {
               A52LinCod = T002O7_A52LinCod[0];
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2O17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2O17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A52LinCod != Z52LinCod )
               {
                  A52LinCod = Z52LinCod;
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2O17( ) ;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A52LinCod != Z52LinCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2O17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LINCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLinCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLinCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2O17( ) ;
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
         if ( A52LinCod != Z52LinCod )
         {
            A52LinCod = Z52LinCod;
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLinCod_Internalname;
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
         GetKey2O17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LINCOD");
               AnyError = 1;
               GX_FocusControl = edtLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A52LinCod != Z52LinCod )
            {
               A52LinCod = Z52LinCod;
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LINCOD");
               AnyError = 1;
               GX_FocusControl = edtLinCod_Internalname;
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
            if ( A52LinCod != Z52LinCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLinCod_Internalname;
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
         context.RollbackDataStores("clineaprod",pr_default);
         GX_FocusControl = edtLinDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2O0( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLinDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2O17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2O17( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinDsc_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinDsc_Internalname;
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
         ScanStart2O17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound17 != 0 )
            {
               ScanNext2O17( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2O17( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2O17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002O2 */
            pr_default.execute(0, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLINEAPROD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1153LinDsc, T002O2_A1153LinDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1152LinAbr, T002O2_A1152LinAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z1160LinSunat, T002O2_A1160LinSunat[0]) != 0 ) || ( Z1158LinStk != T002O2_A1158LinStk[0] ) || ( Z1159LinSts != T002O2_A1159LinSts[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1154LinRef1, T002O2_A1154LinRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1155LinRef2, T002O2_A1155LinRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1156LinRef3, T002O2_A1156LinRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1157LinRef4, T002O2_A1157LinRef4[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1153LinDsc, T002O2_A1153LinDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1153LinDsc);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1153LinDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1152LinAbr, T002O2_A1152LinAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1152LinAbr);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1152LinAbr[0]);
               }
               if ( StringUtil.StrCmp(Z1160LinSunat, T002O2_A1160LinSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinSunat");
                  GXUtil.WriteLogRaw("Old: ",Z1160LinSunat);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1160LinSunat[0]);
               }
               if ( Z1158LinStk != T002O2_A1158LinStk[0] )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinStk");
                  GXUtil.WriteLogRaw("Old: ",Z1158LinStk);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1158LinStk[0]);
               }
               if ( Z1159LinSts != T002O2_A1159LinSts[0] )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinSts");
                  GXUtil.WriteLogRaw("Old: ",Z1159LinSts);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1159LinSts[0]);
               }
               if ( StringUtil.StrCmp(Z1154LinRef1, T002O2_A1154LinRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1154LinRef1);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1154LinRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1155LinRef2, T002O2_A1155LinRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1155LinRef2);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1155LinRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1156LinRef3, T002O2_A1156LinRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1156LinRef3);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1156LinRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1157LinRef4, T002O2_A1157LinRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clineaprod:[seudo value changed for attri]"+"LinRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1157LinRef4);
                  GXUtil.WriteLogRaw("Current: ",T002O2_A1157LinRef4[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLINEAPROD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2O17( )
      {
         BeforeValidate2O17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2O17( 0) ;
            CheckOptimisticConcurrency2O17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2O17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002O8 */
                     pr_default.execute(6, new Object[] {A52LinCod, A1153LinDsc, A1152LinAbr, A1160LinSunat, A1158LinStk, A1159LinSts, A1154LinRef1, A1155LinRef2, A1156LinRef3, A1157LinRef4});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CLINEAPROD");
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
                           ResetCaption2O0( ) ;
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
               Load2O17( ) ;
            }
            EndLevel2O17( ) ;
         }
         CloseExtendedTableCursors2O17( ) ;
      }

      protected void Update2O17( )
      {
         BeforeValidate2O17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2O17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002O9 */
                     pr_default.execute(7, new Object[] {A1153LinDsc, A1152LinAbr, A1160LinSunat, A1158LinStk, A1159LinSts, A1154LinRef1, A1155LinRef2, A1156LinRef3, A1157LinRef4, A52LinCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CLINEAPROD");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLINEAPROD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2O17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2O0( ) ;
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
            EndLevel2O17( ) ;
         }
         CloseExtendedTableCursors2O17( ) ;
      }

      protected void DeferredUpdate2O17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2O17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2O17( ) ;
            AfterConfirm2O17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2O17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002O10 */
                  pr_default.execute(8, new Object[] {A52LinCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CLINEAPROD");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound17 == 0 )
                        {
                           InitAll2O17( ) ;
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
                        ResetCaption2O0( ) ;
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2O17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2O17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002O11 */
            pr_default.execute(9, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCONCEPTOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T002O12 */
            pr_default.execute(10, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T002O13 */
            pr_default.execute(11, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel2O17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2O17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clineaprod",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clineaprod",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2O17( )
      {
         /* Using cursor T002O14 */
         pr_default.execute(12);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound17 = 1;
            A52LinCod = T002O14_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2O17( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound17 = 1;
            A52LinCod = T002O14_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
      }

      protected void ScanEnd2O17( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2O17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2O17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2O17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2O17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2O17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2O17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2O17( )
      {
         edtLinCod_Enabled = 0;
         AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         edtLinDsc_Enabled = 0;
         AssignProp("", false, edtLinDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinDsc_Enabled), 5, 0), true);
         edtLinAbr_Enabled = 0;
         AssignProp("", false, edtLinAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinAbr_Enabled), 5, 0), true);
         edtLinSunat_Enabled = 0;
         AssignProp("", false, edtLinSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinSunat_Enabled), 5, 0), true);
         edtLinStk_Enabled = 0;
         AssignProp("", false, edtLinStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinStk_Enabled), 5, 0), true);
         edtLinSts_Enabled = 0;
         AssignProp("", false, edtLinSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinSts_Enabled), 5, 0), true);
         edtLinRef1_Enabled = 0;
         AssignProp("", false, edtLinRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef1_Enabled), 5, 0), true);
         edtLinRef2_Enabled = 0;
         AssignProp("", false, edtLinRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef2_Enabled), 5, 0), true);
         edtLinRef3_Enabled = 0;
         AssignProp("", false, edtLinRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef3_Enabled), 5, 0), true);
         edtLinRef4_Enabled = 0;
         AssignProp("", false, edtLinRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef4_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2O17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2O0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Lineas de Productos") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228181024421", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clineaprod.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1153LinDsc", StringUtil.RTrim( Z1153LinDsc));
         GxWebStd.gx_hidden_field( context, "Z1152LinAbr", StringUtil.RTrim( Z1152LinAbr));
         GxWebStd.gx_hidden_field( context, "Z1160LinSunat", Z1160LinSunat);
         GxWebStd.gx_hidden_field( context, "Z1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1158LinStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1159LinSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1159LinSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1154LinRef1", Z1154LinRef1);
         GxWebStd.gx_hidden_field( context, "Z1155LinRef2", Z1155LinRef2);
         GxWebStd.gx_hidden_field( context, "Z1156LinRef3", Z1156LinRef3);
         GxWebStd.gx_hidden_field( context, "Z1157LinRef4", Z1157LinRef4);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm2O17( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "CLINEAPROD" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lineas de Productos" ;
      }

      protected void InitializeNonKey2O17( )
      {
         A1153LinDsc = "";
         AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
         A1152LinAbr = "";
         AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
         A1160LinSunat = "";
         AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
         A1158LinStk = 0;
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         A1159LinSts = 0;
         AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
         A1154LinRef1 = "";
         AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
         A1155LinRef2 = "";
         AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
         A1156LinRef3 = "";
         AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
         A1157LinRef4 = "";
         AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
         Z1153LinDsc = "";
         Z1152LinAbr = "";
         Z1160LinSunat = "";
         Z1158LinStk = 0;
         Z1159LinSts = 0;
         Z1154LinRef1 = "";
         Z1155LinRef2 = "";
         Z1156LinRef3 = "";
         Z1157LinRef4 = "";
      }

      protected void InitAll2O17( )
      {
         A52LinCod = 0;
         AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         InitializeNonKey2O17( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024429", true, true);
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
         context.AddJavascriptSource("clineaprod.js", "?20228181024429", false, true);
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
         edtLinCod_Internalname = "LINCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLinDsc_Internalname = "LINDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLinAbr_Internalname = "LINABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLinSunat_Internalname = "LINSUNAT";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLinStk_Internalname = "LINSTK";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLinSts_Internalname = "LINSTS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLinRef1_Internalname = "LINREF1";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtLinRef2_Internalname = "LINREF2";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLinRef3_Internalname = "LINREF3";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtLinRef4_Internalname = "LINREF4";
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
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLinRef4_Jsonclick = "";
         edtLinRef4_Enabled = 1;
         edtLinRef3_Jsonclick = "";
         edtLinRef3_Enabled = 1;
         edtLinRef2_Jsonclick = "";
         edtLinRef2_Enabled = 1;
         edtLinRef1_Jsonclick = "";
         edtLinRef1_Enabled = 1;
         edtLinSts_Jsonclick = "";
         edtLinSts_Enabled = 1;
         edtLinStk_Jsonclick = "";
         edtLinStk_Enabled = 1;
         edtLinSunat_Jsonclick = "";
         edtLinSunat_Enabled = 1;
         edtLinAbr_Jsonclick = "";
         edtLinAbr_Enabled = 1;
         edtLinDsc_Jsonclick = "";
         edtLinDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLinCod_Jsonclick = "";
         edtLinCod_Enabled = 1;
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
         GX_FocusControl = edtLinDsc_Internalname;
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

      public void Valid_Lincod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1153LinDsc", StringUtil.RTrim( A1153LinDsc));
         AssignAttri("", false, "A1152LinAbr", StringUtil.RTrim( A1152LinAbr));
         AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
         AssignAttri("", false, "A1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")));
         AssignAttri("", false, "A1159LinSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1159LinSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
         AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
         AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
         AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1153LinDsc", StringUtil.RTrim( Z1153LinDsc));
         GxWebStd.gx_hidden_field( context, "Z1152LinAbr", StringUtil.RTrim( Z1152LinAbr));
         GxWebStd.gx_hidden_field( context, "Z1160LinSunat", Z1160LinSunat);
         GxWebStd.gx_hidden_field( context, "Z1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1158LinStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1159LinSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1159LinSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1154LinRef1", Z1154LinRef1);
         GxWebStd.gx_hidden_field( context, "Z1155LinRef2", Z1155LinRef2);
         GxWebStd.gx_hidden_field( context, "Z1156LinRef3", Z1156LinRef3);
         GxWebStd.gx_hidden_field( context, "Z1157LinRef4", Z1157LinRef4);
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
         setEventMetadata("VALID_LINCOD","{handler:'Valid_Lincod',iparms:[{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LINCOD",",oparms:[{av:'A1153LinDsc',fld:'LINDSC',pic:''},{av:'A1152LinAbr',fld:'LINABR',pic:''},{av:'A1160LinSunat',fld:'LINSUNAT',pic:''},{av:'A1158LinStk',fld:'LINSTK',pic:'9'},{av:'A1159LinSts',fld:'LINSTS',pic:'9'},{av:'A1154LinRef1',fld:'LINREF1',pic:''},{av:'A1155LinRef2',fld:'LINREF2',pic:''},{av:'A1156LinRef3',fld:'LINREF3',pic:''},{av:'A1157LinRef4',fld:'LINREF4',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z52LinCod'},{av:'Z1153LinDsc'},{av:'Z1152LinAbr'},{av:'Z1160LinSunat'},{av:'Z1158LinStk'},{av:'Z1159LinSts'},{av:'Z1154LinRef1'},{av:'Z1155LinRef2'},{av:'Z1156LinRef3'},{av:'Z1157LinRef4'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1153LinDsc = "";
         Z1152LinAbr = "";
         Z1160LinSunat = "";
         Z1154LinRef1 = "";
         Z1155LinRef2 = "";
         Z1156LinRef3 = "";
         Z1157LinRef4 = "";
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
         A1153LinDsc = "";
         lblTextblock3_Jsonclick = "";
         A1152LinAbr = "";
         lblTextblock4_Jsonclick = "";
         A1160LinSunat = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1154LinRef1 = "";
         lblTextblock8_Jsonclick = "";
         A1155LinRef2 = "";
         lblTextblock9_Jsonclick = "";
         A1156LinRef3 = "";
         lblTextblock10_Jsonclick = "";
         A1157LinRef4 = "";
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
         T002O4_A52LinCod = new int[1] ;
         T002O4_A1153LinDsc = new string[] {""} ;
         T002O4_A1152LinAbr = new string[] {""} ;
         T002O4_A1160LinSunat = new string[] {""} ;
         T002O4_A1158LinStk = new short[1] ;
         T002O4_A1159LinSts = new short[1] ;
         T002O4_A1154LinRef1 = new string[] {""} ;
         T002O4_A1155LinRef2 = new string[] {""} ;
         T002O4_A1156LinRef3 = new string[] {""} ;
         T002O4_A1157LinRef4 = new string[] {""} ;
         T002O5_A52LinCod = new int[1] ;
         T002O3_A52LinCod = new int[1] ;
         T002O3_A1153LinDsc = new string[] {""} ;
         T002O3_A1152LinAbr = new string[] {""} ;
         T002O3_A1160LinSunat = new string[] {""} ;
         T002O3_A1158LinStk = new short[1] ;
         T002O3_A1159LinSts = new short[1] ;
         T002O3_A1154LinRef1 = new string[] {""} ;
         T002O3_A1155LinRef2 = new string[] {""} ;
         T002O3_A1156LinRef3 = new string[] {""} ;
         T002O3_A1157LinRef4 = new string[] {""} ;
         sMode17 = "";
         T002O6_A52LinCod = new int[1] ;
         T002O7_A52LinCod = new int[1] ;
         T002O2_A52LinCod = new int[1] ;
         T002O2_A1153LinDsc = new string[] {""} ;
         T002O2_A1152LinAbr = new string[] {""} ;
         T002O2_A1160LinSunat = new string[] {""} ;
         T002O2_A1158LinStk = new short[1] ;
         T002O2_A1159LinSts = new short[1] ;
         T002O2_A1154LinRef1 = new string[] {""} ;
         T002O2_A1155LinRef2 = new string[] {""} ;
         T002O2_A1156LinRef3 = new string[] {""} ;
         T002O2_A1157LinRef4 = new string[] {""} ;
         T002O11_A313PoConcCod = new int[1] ;
         T002O12_A83ParTip = new string[] {""} ;
         T002O12_A84ParCod = new int[1] ;
         T002O12_A104ParDItem = new short[1] ;
         T002O13_A28ProdCod = new string[] {""} ;
         T002O14_A52LinCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1153LinDsc = "";
         ZZ1152LinAbr = "";
         ZZ1160LinSunat = "";
         ZZ1154LinRef1 = "";
         ZZ1155LinRef2 = "";
         ZZ1156LinRef3 = "";
         ZZ1157LinRef4 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clineaprod__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clineaprod__default(),
            new Object[][] {
                new Object[] {
               T002O2_A52LinCod, T002O2_A1153LinDsc, T002O2_A1152LinAbr, T002O2_A1160LinSunat, T002O2_A1158LinStk, T002O2_A1159LinSts, T002O2_A1154LinRef1, T002O2_A1155LinRef2, T002O2_A1156LinRef3, T002O2_A1157LinRef4
               }
               , new Object[] {
               T002O3_A52LinCod, T002O3_A1153LinDsc, T002O3_A1152LinAbr, T002O3_A1160LinSunat, T002O3_A1158LinStk, T002O3_A1159LinSts, T002O3_A1154LinRef1, T002O3_A1155LinRef2, T002O3_A1156LinRef3, T002O3_A1157LinRef4
               }
               , new Object[] {
               T002O4_A52LinCod, T002O4_A1153LinDsc, T002O4_A1152LinAbr, T002O4_A1160LinSunat, T002O4_A1158LinStk, T002O4_A1159LinSts, T002O4_A1154LinRef1, T002O4_A1155LinRef2, T002O4_A1156LinRef3, T002O4_A1157LinRef4
               }
               , new Object[] {
               T002O5_A52LinCod
               }
               , new Object[] {
               T002O6_A52LinCod
               }
               , new Object[] {
               T002O7_A52LinCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002O11_A313PoConcCod
               }
               , new Object[] {
               T002O12_A83ParTip, T002O12_A84ParCod, T002O12_A104ParDItem
               }
               , new Object[] {
               T002O13_A28ProdCod
               }
               , new Object[] {
               T002O14_A52LinCod
               }
            }
         );
      }

      private short Z1158LinStk ;
      private short Z1159LinSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1158LinStk ;
      private short A1159LinSts ;
      private short GX_JID ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private short Gx_BScreen ;
      private short ZZ1158LinStk ;
      private short ZZ1159LinSts ;
      private int Z52LinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A52LinCod ;
      private int edtLinCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLinDsc_Enabled ;
      private int edtLinAbr_Enabled ;
      private int edtLinSunat_Enabled ;
      private int edtLinStk_Enabled ;
      private int edtLinSts_Enabled ;
      private int edtLinRef1_Enabled ;
      private int edtLinRef2_Enabled ;
      private int edtLinRef3_Enabled ;
      private int edtLinRef4_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ52LinCod ;
      private string sPrefix ;
      private string Z1153LinDsc ;
      private string Z1152LinAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLinCod_Internalname ;
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
      private string edtLinCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLinDsc_Internalname ;
      private string A1153LinDsc ;
      private string edtLinDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLinAbr_Internalname ;
      private string A1152LinAbr ;
      private string edtLinAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLinSunat_Internalname ;
      private string edtLinSunat_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLinStk_Internalname ;
      private string edtLinStk_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLinSts_Internalname ;
      private string edtLinSts_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLinRef1_Internalname ;
      private string edtLinRef1_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtLinRef2_Internalname ;
      private string edtLinRef2_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLinRef3_Internalname ;
      private string edtLinRef3_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtLinRef4_Internalname ;
      private string edtLinRef4_Jsonclick ;
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
      private string sMode17 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1153LinDsc ;
      private string ZZ1152LinAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z1160LinSunat ;
      private string Z1154LinRef1 ;
      private string Z1155LinRef2 ;
      private string Z1156LinRef3 ;
      private string Z1157LinRef4 ;
      private string A1160LinSunat ;
      private string A1154LinRef1 ;
      private string A1155LinRef2 ;
      private string A1156LinRef3 ;
      private string A1157LinRef4 ;
      private string ZZ1160LinSunat ;
      private string ZZ1154LinRef1 ;
      private string ZZ1155LinRef2 ;
      private string ZZ1156LinRef3 ;
      private string ZZ1157LinRef4 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002O4_A52LinCod ;
      private string[] T002O4_A1153LinDsc ;
      private string[] T002O4_A1152LinAbr ;
      private string[] T002O4_A1160LinSunat ;
      private short[] T002O4_A1158LinStk ;
      private short[] T002O4_A1159LinSts ;
      private string[] T002O4_A1154LinRef1 ;
      private string[] T002O4_A1155LinRef2 ;
      private string[] T002O4_A1156LinRef3 ;
      private string[] T002O4_A1157LinRef4 ;
      private int[] T002O5_A52LinCod ;
      private int[] T002O3_A52LinCod ;
      private string[] T002O3_A1153LinDsc ;
      private string[] T002O3_A1152LinAbr ;
      private string[] T002O3_A1160LinSunat ;
      private short[] T002O3_A1158LinStk ;
      private short[] T002O3_A1159LinSts ;
      private string[] T002O3_A1154LinRef1 ;
      private string[] T002O3_A1155LinRef2 ;
      private string[] T002O3_A1156LinRef3 ;
      private string[] T002O3_A1157LinRef4 ;
      private int[] T002O6_A52LinCod ;
      private int[] T002O7_A52LinCod ;
      private int[] T002O2_A52LinCod ;
      private string[] T002O2_A1153LinDsc ;
      private string[] T002O2_A1152LinAbr ;
      private string[] T002O2_A1160LinSunat ;
      private short[] T002O2_A1158LinStk ;
      private short[] T002O2_A1159LinSts ;
      private string[] T002O2_A1154LinRef1 ;
      private string[] T002O2_A1155LinRef2 ;
      private string[] T002O2_A1156LinRef3 ;
      private string[] T002O2_A1157LinRef4 ;
      private int[] T002O11_A313PoConcCod ;
      private string[] T002O12_A83ParTip ;
      private int[] T002O12_A84ParCod ;
      private short[] T002O12_A104ParDItem ;
      private string[] T002O13_A28ProdCod ;
      private int[] T002O14_A52LinCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class clineaprod__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clineaprod__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002O4;
        prmT002O4 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O5;
        prmT002O5 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O3;
        prmT002O3 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O6;
        prmT002O6 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O7;
        prmT002O7 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O2;
        prmT002O2 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O8;
        prmT002O8 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0) ,
        new ParDef("@LinDsc",GXType.NChar,100,0) ,
        new ParDef("@LinAbr",GXType.NChar,5,0) ,
        new ParDef("@LinSunat",GXType.NVarChar,5,0) ,
        new ParDef("@LinStk",GXType.Int16,1,0) ,
        new ParDef("@LinSts",GXType.Int16,1,0) ,
        new ParDef("@LinRef1",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef2",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef3",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef4",GXType.NVarChar,20,0)
        };
        Object[] prmT002O9;
        prmT002O9 = new Object[] {
        new ParDef("@LinDsc",GXType.NChar,100,0) ,
        new ParDef("@LinAbr",GXType.NChar,5,0) ,
        new ParDef("@LinSunat",GXType.NVarChar,5,0) ,
        new ParDef("@LinStk",GXType.Int16,1,0) ,
        new ParDef("@LinSts",GXType.Int16,1,0) ,
        new ParDef("@LinRef1",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef2",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef3",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef4",GXType.NVarChar,20,0) ,
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O10;
        prmT002O10 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O11;
        prmT002O11 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O12;
        prmT002O12 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O13;
        prmT002O13 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT002O14;
        prmT002O14 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002O2", "SELECT [LinCod], [LinDsc], [LinAbr], [LinSunat], [LinStk], [LinSts], [LinRef1], [LinRef2], [LinRef3], [LinRef4] FROM [CLINEAPROD] WITH (UPDLOCK) WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O3", "SELECT [LinCod], [LinDsc], [LinAbr], [LinSunat], [LinStk], [LinSts], [LinRef1], [LinRef2], [LinRef3], [LinRef4] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O4", "SELECT TM1.[LinCod], TM1.[LinDsc], TM1.[LinAbr], TM1.[LinSunat], TM1.[LinStk], TM1.[LinSts], TM1.[LinRef1], TM1.[LinRef2], TM1.[LinRef3], TM1.[LinRef4] FROM [CLINEAPROD] TM1 WHERE TM1.[LinCod] = @LinCod ORDER BY TM1.[LinCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O5", "SELECT [LinCod] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002O6", "SELECT TOP 1 [LinCod] FROM [CLINEAPROD] WHERE ( [LinCod] > @LinCod) ORDER BY [LinCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O7", "SELECT TOP 1 [LinCod] FROM [CLINEAPROD] WHERE ( [LinCod] < @LinCod) ORDER BY [LinCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O8", "INSERT INTO [CLINEAPROD]([LinCod], [LinDsc], [LinAbr], [LinSunat], [LinStk], [LinSts], [LinRef1], [LinRef2], [LinRef3], [LinRef4]) VALUES(@LinCod, @LinDsc, @LinAbr, @LinSunat, @LinStk, @LinSts, @LinRef1, @LinRef2, @LinRef3, @LinRef4)", GxErrorMask.GX_NOMASK,prmT002O8)
           ,new CursorDef("T002O9", "UPDATE [CLINEAPROD] SET [LinDsc]=@LinDsc, [LinAbr]=@LinAbr, [LinSunat]=@LinSunat, [LinStk]=@LinStk, [LinSts]=@LinSts, [LinRef1]=@LinRef1, [LinRef2]=@LinRef2, [LinRef3]=@LinRef3, [LinRef4]=@LinRef4  WHERE [LinCod] = @LinCod", GxErrorMask.GX_NOMASK,prmT002O9)
           ,new CursorDef("T002O10", "DELETE FROM [CLINEAPROD]  WHERE [LinCod] = @LinCod", GxErrorMask.GX_NOMASK,prmT002O10)
           ,new CursorDef("T002O11", "SELECT TOP 1 [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcLinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O12", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDLinProd] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O13", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002O13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002O14", "SELECT [LinCod] FROM [CLINEAPROD] ORDER BY [LinCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002O14,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
