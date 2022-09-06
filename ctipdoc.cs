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
   public class ctipdoc : GXHttpHandler
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
            Form.Meta.addItem("description", "Tipos de Documentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ctipdoc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctipdoc( IGxContext context )
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
            RenderHtmlCloseForm3Q129( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTIPDOC.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Documento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipDsc_Internalname, StringUtil.RTrim( A1910TipDsc), StringUtil.RTrim( context.localUtil.Format( A1910TipDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "T/D", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipAbr_Internalname, StringUtil.RTrim( A306TipAbr), StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Signo", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSigno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")), StringUtil.LTrim( ((edtTipSigno_Enabled!=0) ? context.localUtil.Format( (decimal)(A511TipSigno), "Z9") : context.localUtil.Format( (decimal)(A511TipSigno), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSigno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipSigno_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situación", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1919TipSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1919TipSts), "9") : context.localUtil.Format( (decimal)(A1919TipSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Registro de Venta", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipVta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1921TipVta), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipVta_Enabled!=0) ? context.localUtil.Format( (decimal)(A1921TipVta), "9") : context.localUtil.Format( (decimal)(A1921TipVta), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipVta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipVta_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Registro de Compras", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCmp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1906TipCmp), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipCmp_Enabled!=0) ? context.localUtil.Format( (decimal)(A1906TipCmp), "9") : context.localUtil.Format( (decimal)(A1906TipCmp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCmp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCmp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Recibos por Honorarios", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipRHo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1915TipRHo), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipRHo_Enabled!=0) ? context.localUtil.Format( (decimal)(A1915TipRHo), "9") : context.localUtil.Format( (decimal)(A1915TipRHo), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipRHo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipRHo_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPDOC.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPDOC.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTIPDOC.htm");
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
            Z149TipCod = cgiGet( "Z149TipCod");
            Z1910TipDsc = cgiGet( "Z1910TipDsc");
            Z306TipAbr = cgiGet( "Z306TipAbr");
            Z511TipSigno = (short)(context.localUtil.CToN( cgiGet( "Z511TipSigno"), ".", ","));
            Z1919TipSts = (short)(context.localUtil.CToN( cgiGet( "Z1919TipSts"), ".", ","));
            Z1921TipVta = (short)(context.localUtil.CToN( cgiGet( "Z1921TipVta"), ".", ","));
            Z1906TipCmp = (short)(context.localUtil.CToN( cgiGet( "Z1906TipCmp"), ".", ","));
            Z1915TipRHo = (short)(context.localUtil.CToN( cgiGet( "Z1915TipRHo"), ".", ","));
            Z1909TipCxP = (short)(context.localUtil.CToN( cgiGet( "Z1909TipCxP"), ".", ","));
            Z1903TipBan = (short)(context.localUtil.CToN( cgiGet( "Z1903TipBan"), ".", ","));
            A1909TipCxP = (short)(context.localUtil.CToN( cgiGet( "Z1909TipCxP"), ".", ","));
            A1903TipBan = (short)(context.localUtil.CToN( cgiGet( "Z1903TipBan"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1909TipCxP = (short)(context.localUtil.CToN( cgiGet( "TIPCXP"), ".", ","));
            A1903TipBan = (short)(context.localUtil.CToN( cgiGet( "TIPBAN"), ".", ","));
            /* Read variables values. */
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A1910TipDsc = cgiGet( edtTipDsc_Internalname);
            AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
            A306TipAbr = cgiGet( edtTipAbr_Internalname);
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipSigno_Internalname), ".", ",") < Convert.ToDecimal( -9 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipSigno_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPSIGNO");
               AnyError = 1;
               GX_FocusControl = edtTipSigno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A511TipSigno = 0;
               AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
            }
            else
            {
               A511TipSigno = (short)(context.localUtil.CToN( cgiGet( edtTipSigno_Internalname), ".", ","));
               AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPSTS");
               AnyError = 1;
               GX_FocusControl = edtTipSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1919TipSts = 0;
               AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
            }
            else
            {
               A1919TipSts = (short)(context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ","));
               AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPVTA");
               AnyError = 1;
               GX_FocusControl = edtTipVta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1921TipVta = 0;
               AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
            }
            else
            {
               A1921TipVta = (short)(context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ","));
               AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCMP");
               AnyError = 1;
               GX_FocusControl = edtTipCmp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1906TipCmp = 0;
               AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
            }
            else
            {
               A1906TipCmp = (short)(context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ","));
               AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPRHO");
               AnyError = 1;
               GX_FocusControl = edtTipRHo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1915TipRHo = 0;
               AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
            }
            else
            {
               A1915TipRHo = (short)(context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ","));
               AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CTIPDOC");
            forbiddenHiddens.Add("TipCxP", context.localUtil.Format( (decimal)(A1909TipCxP), "9"));
            forbiddenHiddens.Add("TipBan", context.localUtil.Format( (decimal)(A1903TipBan), "9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("ctipdoc:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A149TipCod = GetPar( "TipCod");
               AssignAttri("", false, "A149TipCod", A149TipCod);
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
               InitAll3Q129( ) ;
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
         DisableAttributes3Q129( ) ;
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

      protected void CONFIRM_3Q0( )
      {
         BeforeValidate3Q129( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3Q129( ) ;
            }
            else
            {
               CheckExtendedTable3Q129( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3Q129( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3Q0( ) ;
         }
      }

      protected void ResetCaption3Q0( )
      {
      }

      protected void ZM3Q129( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1910TipDsc = T003Q3_A1910TipDsc[0];
               Z306TipAbr = T003Q3_A306TipAbr[0];
               Z511TipSigno = T003Q3_A511TipSigno[0];
               Z1919TipSts = T003Q3_A1919TipSts[0];
               Z1921TipVta = T003Q3_A1921TipVta[0];
               Z1906TipCmp = T003Q3_A1906TipCmp[0];
               Z1915TipRHo = T003Q3_A1915TipRHo[0];
               Z1909TipCxP = T003Q3_A1909TipCxP[0];
               Z1903TipBan = T003Q3_A1903TipBan[0];
            }
            else
            {
               Z1910TipDsc = A1910TipDsc;
               Z306TipAbr = A306TipAbr;
               Z511TipSigno = A511TipSigno;
               Z1919TipSts = A1919TipSts;
               Z1921TipVta = A1921TipVta;
               Z1906TipCmp = A1906TipCmp;
               Z1915TipRHo = A1915TipRHo;
               Z1909TipCxP = A1909TipCxP;
               Z1903TipBan = A1903TipBan;
            }
         }
         if ( GX_JID == -1 )
         {
            Z149TipCod = A149TipCod;
            Z1910TipDsc = A1910TipDsc;
            Z306TipAbr = A306TipAbr;
            Z511TipSigno = A511TipSigno;
            Z1919TipSts = A1919TipSts;
            Z1921TipVta = A1921TipVta;
            Z1906TipCmp = A1906TipCmp;
            Z1915TipRHo = A1915TipRHo;
            Z1909TipCxP = A1909TipCxP;
            Z1903TipBan = A1903TipBan;
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

      protected void Load3Q129( )
      {
         /* Using cursor T003Q4 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound129 = 1;
            A1910TipDsc = T003Q4_A1910TipDsc[0];
            AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
            A306TipAbr = T003Q4_A306TipAbr[0];
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            A511TipSigno = T003Q4_A511TipSigno[0];
            AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
            A1919TipSts = T003Q4_A1919TipSts[0];
            AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
            A1921TipVta = T003Q4_A1921TipVta[0];
            AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
            A1906TipCmp = T003Q4_A1906TipCmp[0];
            AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
            A1915TipRHo = T003Q4_A1915TipRHo[0];
            AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
            A1909TipCxP = T003Q4_A1909TipCxP[0];
            A1903TipBan = T003Q4_A1903TipBan[0];
            ZM3Q129( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3Q129( ) ;
      }

      protected void OnLoadActions3Q129( )
      {
      }

      protected void CheckExtendedTable3Q129( )
      {
         nIsDirty_129 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3Q129( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3Q129( )
      {
         /* Using cursor T003Q5 */
         pr_default.execute(3, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound129 = 1;
         }
         else
         {
            RcdFound129 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003Q3 */
         pr_default.execute(1, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3Q129( 1) ;
            RcdFound129 = 1;
            A149TipCod = T003Q3_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A1910TipDsc = T003Q3_A1910TipDsc[0];
            AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
            A306TipAbr = T003Q3_A306TipAbr[0];
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            A511TipSigno = T003Q3_A511TipSigno[0];
            AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
            A1919TipSts = T003Q3_A1919TipSts[0];
            AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
            A1921TipVta = T003Q3_A1921TipVta[0];
            AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
            A1906TipCmp = T003Q3_A1906TipCmp[0];
            AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
            A1915TipRHo = T003Q3_A1915TipRHo[0];
            AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
            A1909TipCxP = T003Q3_A1909TipCxP[0];
            A1903TipBan = T003Q3_A1903TipBan[0];
            Z149TipCod = A149TipCod;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3Q129( ) ;
            if ( AnyError == 1 )
            {
               RcdFound129 = 0;
               InitializeNonKey3Q129( ) ;
            }
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound129 = 0;
            InitializeNonKey3Q129( ) ;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3Q129( ) ;
         if ( RcdFound129 == 0 )
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
         RcdFound129 = 0;
         /* Using cursor T003Q6 */
         pr_default.execute(4, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T003Q6_A149TipCod[0], A149TipCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T003Q6_A149TipCod[0], A149TipCod) > 0 ) ) )
            {
               A149TipCod = T003Q6_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               RcdFound129 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound129 = 0;
         /* Using cursor T003Q7 */
         pr_default.execute(5, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T003Q7_A149TipCod[0], A149TipCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T003Q7_A149TipCod[0], A149TipCod) < 0 ) ) )
            {
               A149TipCod = T003Q7_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               RcdFound129 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3Q129( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3Q129( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound129 == 1 )
            {
               if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
               {
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3Q129( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3Q129( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3Q129( ) ;
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
         if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
         {
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipCod_Internalname;
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
         GetKey3Q129( ) ;
         if ( RcdFound129 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
            {
               A149TipCod = Z149TipCod;
               AssignAttri("", false, "A149TipCod", A149TipCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
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
            if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
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
         context.RollbackDataStores("ctipdoc",pr_default);
         GX_FocusControl = edtTipDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3Q0( ) ;
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
         if ( RcdFound129 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTipDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3Q129( ) ;
         if ( RcdFound129 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3Q129( ) ;
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
         if ( RcdFound129 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipDsc_Internalname;
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
         if ( RcdFound129 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipDsc_Internalname;
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
         ScanStart3Q129( ) ;
         if ( RcdFound129 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound129 != 0 )
            {
               ScanNext3Q129( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTipDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3Q129( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3Q129( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003Q2 */
            pr_default.execute(0, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPDOC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1910TipDsc, T003Q2_A1910TipDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z306TipAbr, T003Q2_A306TipAbr[0]) != 0 ) || ( Z511TipSigno != T003Q2_A511TipSigno[0] ) || ( Z1919TipSts != T003Q2_A1919TipSts[0] ) || ( Z1921TipVta != T003Q2_A1921TipVta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1906TipCmp != T003Q2_A1906TipCmp[0] ) || ( Z1915TipRHo != T003Q2_A1915TipRHo[0] ) || ( Z1909TipCxP != T003Q2_A1909TipCxP[0] ) || ( Z1903TipBan != T003Q2_A1903TipBan[0] ) )
            {
               if ( StringUtil.StrCmp(Z1910TipDsc, T003Q2_A1910TipDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1910TipDsc);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1910TipDsc[0]);
               }
               if ( StringUtil.StrCmp(Z306TipAbr, T003Q2_A306TipAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipAbr");
                  GXUtil.WriteLogRaw("Old: ",Z306TipAbr);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A306TipAbr[0]);
               }
               if ( Z511TipSigno != T003Q2_A511TipSigno[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipSigno");
                  GXUtil.WriteLogRaw("Old: ",Z511TipSigno);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A511TipSigno[0]);
               }
               if ( Z1919TipSts != T003Q2_A1919TipSts[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipSts");
                  GXUtil.WriteLogRaw("Old: ",Z1919TipSts);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1919TipSts[0]);
               }
               if ( Z1921TipVta != T003Q2_A1921TipVta[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipVta");
                  GXUtil.WriteLogRaw("Old: ",Z1921TipVta);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1921TipVta[0]);
               }
               if ( Z1906TipCmp != T003Q2_A1906TipCmp[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipCmp");
                  GXUtil.WriteLogRaw("Old: ",Z1906TipCmp);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1906TipCmp[0]);
               }
               if ( Z1915TipRHo != T003Q2_A1915TipRHo[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipRHo");
                  GXUtil.WriteLogRaw("Old: ",Z1915TipRHo);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1915TipRHo[0]);
               }
               if ( Z1909TipCxP != T003Q2_A1909TipCxP[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipCxP");
                  GXUtil.WriteLogRaw("Old: ",Z1909TipCxP);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1909TipCxP[0]);
               }
               if ( Z1903TipBan != T003Q2_A1903TipBan[0] )
               {
                  GXUtil.WriteLog("ctipdoc:[seudo value changed for attri]"+"TipBan");
                  GXUtil.WriteLogRaw("Old: ",Z1903TipBan);
                  GXUtil.WriteLogRaw("Current: ",T003Q2_A1903TipBan[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPDOC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3Q129( )
      {
         BeforeValidate3Q129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3Q129( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3Q129( 0) ;
            CheckOptimisticConcurrency3Q129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3Q129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3Q129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003Q8 */
                     pr_default.execute(6, new Object[] {A149TipCod, A1910TipDsc, A306TipAbr, A511TipSigno, A1919TipSts, A1921TipVta, A1906TipCmp, A1915TipRHo, A1909TipCxP, A1903TipBan});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPDOC");
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
                           ResetCaption3Q0( ) ;
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
               Load3Q129( ) ;
            }
            EndLevel3Q129( ) ;
         }
         CloseExtendedTableCursors3Q129( ) ;
      }

      protected void Update3Q129( )
      {
         BeforeValidate3Q129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3Q129( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3Q129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3Q129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3Q129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003Q9 */
                     pr_default.execute(7, new Object[] {A1910TipDsc, A306TipAbr, A511TipSigno, A1919TipSts, A1921TipVta, A1906TipCmp, A1915TipRHo, A1909TipCxP, A1903TipBan, A149TipCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPDOC");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPDOC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3Q129( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3Q0( ) ;
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
            EndLevel3Q129( ) ;
         }
         CloseExtendedTableCursors3Q129( ) ;
      }

      protected void DeferredUpdate3Q129( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3Q129( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3Q129( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3Q129( ) ;
            AfterConfirm3Q129( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3Q129( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003Q10 */
                  pr_default.execute(8, new Object[] {A149TipCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPDOC");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound129 == 0 )
                        {
                           InitAll3Q129( ) ;
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
                        ResetCaption3Q0( ) ;
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
         sMode129 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3Q129( ) ;
         Gx_mode = sMode129;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3Q129( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003Q11 */
            pr_default.execute(9, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003Q12 */
            pr_default.execute(10, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T003Q13 */
            pr_default.execute(11, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta Pagar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T003Q14 */
            pr_default.execute(12, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ChequeDiferido Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T003Q15 */
            pr_default.execute(13, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T003Q16 */
            pr_default.execute(14, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T003Q17 */
            pr_default.execute(15, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T003Q18 */
            pr_default.execute(16, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T003Q19 */
            pr_default.execute(17, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T003Q20 */
            pr_default.execute(18, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T003Q21 */
            pr_default.execute(19, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T003Q22 */
            pr_default.execute(20, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T003Q23 */
            pr_default.execute(21, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel3Q129( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3Q129( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctipdoc",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctipdoc",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3Q129( )
      {
         /* Using cursor T003Q24 */
         pr_default.execute(22);
         RcdFound129 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound129 = 1;
            A149TipCod = T003Q24_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3Q129( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound129 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound129 = 1;
            A149TipCod = T003Q24_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
         }
      }

      protected void ScanEnd3Q129( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm3Q129( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3Q129( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3Q129( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3Q129( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3Q129( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3Q129( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3Q129( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtTipDsc_Enabled = 0;
         AssignProp("", false, edtTipDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipDsc_Enabled), 5, 0), true);
         edtTipAbr_Enabled = 0;
         AssignProp("", false, edtTipAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipAbr_Enabled), 5, 0), true);
         edtTipSigno_Enabled = 0;
         AssignProp("", false, edtTipSigno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSigno_Enabled), 5, 0), true);
         edtTipSts_Enabled = 0;
         AssignProp("", false, edtTipSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSts_Enabled), 5, 0), true);
         edtTipVta_Enabled = 0;
         AssignProp("", false, edtTipVta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipVta_Enabled), 5, 0), true);
         edtTipCmp_Enabled = 0;
         AssignProp("", false, edtTipCmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCmp_Enabled), 5, 0), true);
         edtTipRHo_Enabled = 0;
         AssignProp("", false, edtTipRHo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipRHo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3Q129( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3Q0( )
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
         context.SendWebValue( "Tipos de Documentos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025251", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctipdoc.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CTIPDOC");
         forbiddenHiddens.Add("TipCxP", context.localUtil.Format( (decimal)(A1909TipCxP), "9"));
         forbiddenHiddens.Add("TipBan", context.localUtil.Format( (decimal)(A1903TipBan), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ctipdoc:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z1910TipDsc", StringUtil.RTrim( Z1910TipDsc));
         GxWebStd.gx_hidden_field( context, "Z306TipAbr", StringUtil.RTrim( Z306TipAbr));
         GxWebStd.gx_hidden_field( context, "Z511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1919TipSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1919TipSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1921TipVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1921TipVta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1906TipCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1906TipCmp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1915TipRHo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1915TipRHo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1909TipCxP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1909TipCxP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1903TipBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1903TipBan), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "TIPCXP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPBAN", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm3Q129( )
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
         return "CTIPDOC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Documentos" ;
      }

      protected void InitializeNonKey3Q129( )
      {
         A1910TipDsc = "";
         AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
         A306TipAbr = "";
         AssignAttri("", false, "A306TipAbr", A306TipAbr);
         A511TipSigno = 0;
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
         A1919TipSts = 0;
         AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
         A1921TipVta = 0;
         AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
         A1906TipCmp = 0;
         AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
         A1915TipRHo = 0;
         AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
         A1909TipCxP = 0;
         AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
         A1903TipBan = 0;
         AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
         Z1910TipDsc = "";
         Z306TipAbr = "";
         Z511TipSigno = 0;
         Z1919TipSts = 0;
         Z1921TipVta = 0;
         Z1906TipCmp = 0;
         Z1915TipRHo = 0;
         Z1909TipCxP = 0;
         Z1903TipBan = 0;
      }

      protected void InitAll3Q129( )
      {
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         InitializeNonKey3Q129( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252512", true, true);
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
         context.AddJavascriptSource("ctipdoc.js", "?202281810252512", false, true);
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
         edtTipCod_Internalname = "TIPCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTipDsc_Internalname = "TIPDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipAbr_Internalname = "TIPABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtTipSigno_Internalname = "TIPSIGNO";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtTipSts_Internalname = "TIPSTS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtTipVta_Internalname = "TIPVTA";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtTipCmp_Internalname = "TIPCMP";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtTipRHo_Internalname = "TIPRHO";
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
         edtTipRHo_Jsonclick = "";
         edtTipRHo_Enabled = 1;
         edtTipCmp_Jsonclick = "";
         edtTipCmp_Enabled = 1;
         edtTipVta_Jsonclick = "";
         edtTipVta_Enabled = 1;
         edtTipSts_Jsonclick = "";
         edtTipSts_Enabled = 1;
         edtTipSigno_Jsonclick = "";
         edtTipSigno_Enabled = 1;
         edtTipAbr_Jsonclick = "";
         edtTipAbr_Enabled = 1;
         edtTipDsc_Jsonclick = "";
         edtTipDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
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
         GX_FocusControl = edtTipDsc_Internalname;
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

      public void Valid_Tipcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1910TipDsc", StringUtil.RTrim( A1910TipDsc));
         AssignAttri("", false, "A306TipAbr", StringUtil.RTrim( A306TipAbr));
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         AssignAttri("", false, "A1919TipSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1919TipSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1921TipVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1921TipVta), 1, 0, ".", "")));
         AssignAttri("", false, "A1906TipCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1906TipCmp), 1, 0, ".", "")));
         AssignAttri("", false, "A1915TipRHo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1915TipRHo), 1, 0, ".", "")));
         AssignAttri("", false, "A1909TipCxP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")));
         AssignAttri("", false, "A1903TipBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z1910TipDsc", StringUtil.RTrim( Z1910TipDsc));
         GxWebStd.gx_hidden_field( context, "Z306TipAbr", StringUtil.RTrim( Z306TipAbr));
         GxWebStd.gx_hidden_field( context, "Z511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1919TipSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1919TipSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1921TipVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1921TipVta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1906TipCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1906TipCmp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1915TipRHo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1915TipRHo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1909TipCxP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1909TipCxP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1903TipBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1903TipBan), 1, 0, ".", "")));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A1903TipBan',fld:'TIPBAN',pic:'9'},{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[{av:'A1910TipDsc',fld:'TIPDSC',pic:''},{av:'A306TipAbr',fld:'TIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'},{av:'A1919TipSts',fld:'TIPSTS',pic:'9'},{av:'A1921TipVta',fld:'TIPVTA',pic:'9'},{av:'A1906TipCmp',fld:'TIPCMP',pic:'9'},{av:'A1915TipRHo',fld:'TIPRHO',pic:'9'},{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z149TipCod'},{av:'Z1910TipDsc'},{av:'Z306TipAbr'},{av:'Z511TipSigno'},{av:'Z1919TipSts'},{av:'Z1921TipVta'},{av:'Z1906TipCmp'},{av:'Z1915TipRHo'},{av:'Z1909TipCxP'},{av:'Z1903TipBan'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z149TipCod = "";
         Z1910TipDsc = "";
         Z306TipAbr = "";
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
         A149TipCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1910TipDsc = "";
         lblTextblock3_Jsonclick = "";
         A306TipAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T003Q4_A149TipCod = new string[] {""} ;
         T003Q4_A1910TipDsc = new string[] {""} ;
         T003Q4_A306TipAbr = new string[] {""} ;
         T003Q4_A511TipSigno = new short[1] ;
         T003Q4_A1919TipSts = new short[1] ;
         T003Q4_A1921TipVta = new short[1] ;
         T003Q4_A1906TipCmp = new short[1] ;
         T003Q4_A1915TipRHo = new short[1] ;
         T003Q4_A1909TipCxP = new short[1] ;
         T003Q4_A1903TipBan = new short[1] ;
         T003Q5_A149TipCod = new string[] {""} ;
         T003Q3_A149TipCod = new string[] {""} ;
         T003Q3_A1910TipDsc = new string[] {""} ;
         T003Q3_A306TipAbr = new string[] {""} ;
         T003Q3_A511TipSigno = new short[1] ;
         T003Q3_A1919TipSts = new short[1] ;
         T003Q3_A1921TipVta = new short[1] ;
         T003Q3_A1906TipCmp = new short[1] ;
         T003Q3_A1915TipRHo = new short[1] ;
         T003Q3_A1909TipCxP = new short[1] ;
         T003Q3_A1903TipBan = new short[1] ;
         sMode129 = "";
         T003Q6_A149TipCod = new string[] {""} ;
         T003Q7_A149TipCod = new string[] {""} ;
         T003Q2_A149TipCod = new string[] {""} ;
         T003Q2_A1910TipDsc = new string[] {""} ;
         T003Q2_A306TipAbr = new string[] {""} ;
         T003Q2_A511TipSigno = new short[1] ;
         T003Q2_A1919TipSts = new short[1] ;
         T003Q2_A1921TipVta = new short[1] ;
         T003Q2_A1906TipCmp = new short[1] ;
         T003Q2_A1915TipRHo = new short[1] ;
         T003Q2_A1909TipCxP = new short[1] ;
         T003Q2_A1903TipBan = new short[1] ;
         T003Q11_A270LiqCod = new string[] {""} ;
         T003Q11_A236LiqPrvCod = new string[] {""} ;
         T003Q11_A271LiqCodItem = new int[1] ;
         T003Q11_A282LiqDItem = new int[1] ;
         T003Q12_A265LetPLetCod = new string[] {""} ;
         T003Q12_A268LetPItem = new int[1] ;
         T003Q13_A260CPTipCod = new string[] {""} ;
         T003Q13_A261CPComCod = new string[] {""} ;
         T003Q13_A262CPPrvCod = new string[] {""} ;
         T003Q14_A238CheqDCod = new string[] {""} ;
         T003Q14_A241CheqDItem = new int[1] ;
         T003Q15_A184CCTipCod = new string[] {""} ;
         T003Q15_A185CCDocNum = new string[] {""} ;
         T003Q16_A387TSMovCod = new string[] {""} ;
         T003Q17_A224LotCliCod = new string[] {""} ;
         T003Q18_A149TipCod = new string[] {""} ;
         T003Q18_A243ComCod = new string[] {""} ;
         T003Q18_A244PrvCod = new string[] {""} ;
         T003Q19_A149TipCod = new string[] {""} ;
         T003Q19_A24DocNum = new string[] {""} ;
         T003Q19_n24DocNum = new bool[] {false} ;
         T003Q20_A348UsuCod = new string[] {""} ;
         T003Q20_A149TipCod = new string[] {""} ;
         T003Q20_A351UsuSerDet = new string[] {""} ;
         T003Q21_A127VouAno = new short[1] ;
         T003Q21_A128VouMes = new short[1] ;
         T003Q21_A126TASICod = new int[1] ;
         T003Q21_A129VouNum = new string[] {""} ;
         T003Q21_A130VouDSec = new int[1] ;
         T003Q22_A83ParTip = new string[] {""} ;
         T003Q22_A84ParCod = new int[1] ;
         T003Q23_A13MvATip = new string[] {""} ;
         T003Q23_A14MvACod = new string[] {""} ;
         T003Q24_A149TipCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ149TipCod = "";
         ZZ1910TipDsc = "";
         ZZ306TipAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctipdoc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctipdoc__default(),
            new Object[][] {
                new Object[] {
               T003Q2_A149TipCod, T003Q2_A1910TipDsc, T003Q2_A306TipAbr, T003Q2_A511TipSigno, T003Q2_A1919TipSts, T003Q2_A1921TipVta, T003Q2_A1906TipCmp, T003Q2_A1915TipRHo, T003Q2_A1909TipCxP, T003Q2_A1903TipBan
               }
               , new Object[] {
               T003Q3_A149TipCod, T003Q3_A1910TipDsc, T003Q3_A306TipAbr, T003Q3_A511TipSigno, T003Q3_A1919TipSts, T003Q3_A1921TipVta, T003Q3_A1906TipCmp, T003Q3_A1915TipRHo, T003Q3_A1909TipCxP, T003Q3_A1903TipBan
               }
               , new Object[] {
               T003Q4_A149TipCod, T003Q4_A1910TipDsc, T003Q4_A306TipAbr, T003Q4_A511TipSigno, T003Q4_A1919TipSts, T003Q4_A1921TipVta, T003Q4_A1906TipCmp, T003Q4_A1915TipRHo, T003Q4_A1909TipCxP, T003Q4_A1903TipBan
               }
               , new Object[] {
               T003Q5_A149TipCod
               }
               , new Object[] {
               T003Q6_A149TipCod
               }
               , new Object[] {
               T003Q7_A149TipCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003Q11_A270LiqCod, T003Q11_A236LiqPrvCod, T003Q11_A271LiqCodItem, T003Q11_A282LiqDItem
               }
               , new Object[] {
               T003Q12_A265LetPLetCod, T003Q12_A268LetPItem
               }
               , new Object[] {
               T003Q13_A260CPTipCod, T003Q13_A261CPComCod, T003Q13_A262CPPrvCod
               }
               , new Object[] {
               T003Q14_A238CheqDCod, T003Q14_A241CheqDItem
               }
               , new Object[] {
               T003Q15_A184CCTipCod, T003Q15_A185CCDocNum
               }
               , new Object[] {
               T003Q16_A387TSMovCod
               }
               , new Object[] {
               T003Q17_A224LotCliCod
               }
               , new Object[] {
               T003Q18_A149TipCod, T003Q18_A243ComCod, T003Q18_A244PrvCod
               }
               , new Object[] {
               T003Q19_A149TipCod, T003Q19_A24DocNum
               }
               , new Object[] {
               T003Q20_A348UsuCod, T003Q20_A149TipCod, T003Q20_A351UsuSerDet
               }
               , new Object[] {
               T003Q21_A127VouAno, T003Q21_A128VouMes, T003Q21_A126TASICod, T003Q21_A129VouNum, T003Q21_A130VouDSec
               }
               , new Object[] {
               T003Q22_A83ParTip, T003Q22_A84ParCod
               }
               , new Object[] {
               T003Q23_A13MvATip, T003Q23_A14MvACod
               }
               , new Object[] {
               T003Q24_A149TipCod
               }
            }
         );
      }

      private short Z511TipSigno ;
      private short Z1919TipSts ;
      private short Z1921TipVta ;
      private short Z1906TipCmp ;
      private short Z1915TipRHo ;
      private short Z1909TipCxP ;
      private short Z1903TipBan ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A511TipSigno ;
      private short A1919TipSts ;
      private short A1921TipVta ;
      private short A1906TipCmp ;
      private short A1915TipRHo ;
      private short A1909TipCxP ;
      private short A1903TipBan ;
      private short GX_JID ;
      private short RcdFound129 ;
      private short nIsDirty_129 ;
      private short Gx_BScreen ;
      private short ZZ511TipSigno ;
      private short ZZ1919TipSts ;
      private short ZZ1921TipVta ;
      private short ZZ1906TipCmp ;
      private short ZZ1915TipRHo ;
      private short ZZ1909TipCxP ;
      private short ZZ1903TipBan ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTipDsc_Enabled ;
      private int edtTipAbr_Enabled ;
      private int edtTipSigno_Enabled ;
      private int edtTipSts_Enabled ;
      private int edtTipVta_Enabled ;
      private int edtTipCmp_Enabled ;
      private int edtTipRHo_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string Z149TipCod ;
      private string Z1910TipDsc ;
      private string Z306TipAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipCod_Internalname ;
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
      private string A149TipCod ;
      private string edtTipCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTipDsc_Internalname ;
      private string A1910TipDsc ;
      private string edtTipDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipAbr_Internalname ;
      private string A306TipAbr ;
      private string edtTipAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtTipSigno_Internalname ;
      private string edtTipSigno_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtTipSts_Internalname ;
      private string edtTipSts_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtTipVta_Internalname ;
      private string edtTipVta_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtTipCmp_Internalname ;
      private string edtTipCmp_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtTipRHo_Internalname ;
      private string edtTipRHo_Jsonclick ;
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
      private string sMode129 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ149TipCod ;
      private string ZZ1910TipDsc ;
      private string ZZ306TipAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003Q4_A149TipCod ;
      private string[] T003Q4_A1910TipDsc ;
      private string[] T003Q4_A306TipAbr ;
      private short[] T003Q4_A511TipSigno ;
      private short[] T003Q4_A1919TipSts ;
      private short[] T003Q4_A1921TipVta ;
      private short[] T003Q4_A1906TipCmp ;
      private short[] T003Q4_A1915TipRHo ;
      private short[] T003Q4_A1909TipCxP ;
      private short[] T003Q4_A1903TipBan ;
      private string[] T003Q5_A149TipCod ;
      private string[] T003Q3_A149TipCod ;
      private string[] T003Q3_A1910TipDsc ;
      private string[] T003Q3_A306TipAbr ;
      private short[] T003Q3_A511TipSigno ;
      private short[] T003Q3_A1919TipSts ;
      private short[] T003Q3_A1921TipVta ;
      private short[] T003Q3_A1906TipCmp ;
      private short[] T003Q3_A1915TipRHo ;
      private short[] T003Q3_A1909TipCxP ;
      private short[] T003Q3_A1903TipBan ;
      private string[] T003Q6_A149TipCod ;
      private string[] T003Q7_A149TipCod ;
      private string[] T003Q2_A149TipCod ;
      private string[] T003Q2_A1910TipDsc ;
      private string[] T003Q2_A306TipAbr ;
      private short[] T003Q2_A511TipSigno ;
      private short[] T003Q2_A1919TipSts ;
      private short[] T003Q2_A1921TipVta ;
      private short[] T003Q2_A1906TipCmp ;
      private short[] T003Q2_A1915TipRHo ;
      private short[] T003Q2_A1909TipCxP ;
      private short[] T003Q2_A1903TipBan ;
      private string[] T003Q11_A270LiqCod ;
      private string[] T003Q11_A236LiqPrvCod ;
      private int[] T003Q11_A271LiqCodItem ;
      private int[] T003Q11_A282LiqDItem ;
      private string[] T003Q12_A265LetPLetCod ;
      private int[] T003Q12_A268LetPItem ;
      private string[] T003Q13_A260CPTipCod ;
      private string[] T003Q13_A261CPComCod ;
      private string[] T003Q13_A262CPPrvCod ;
      private string[] T003Q14_A238CheqDCod ;
      private int[] T003Q14_A241CheqDItem ;
      private string[] T003Q15_A184CCTipCod ;
      private string[] T003Q15_A185CCDocNum ;
      private string[] T003Q16_A387TSMovCod ;
      private string[] T003Q17_A224LotCliCod ;
      private string[] T003Q18_A149TipCod ;
      private string[] T003Q18_A243ComCod ;
      private string[] T003Q18_A244PrvCod ;
      private string[] T003Q19_A149TipCod ;
      private string[] T003Q19_A24DocNum ;
      private bool[] T003Q19_n24DocNum ;
      private string[] T003Q20_A348UsuCod ;
      private string[] T003Q20_A149TipCod ;
      private string[] T003Q20_A351UsuSerDet ;
      private short[] T003Q21_A127VouAno ;
      private short[] T003Q21_A128VouMes ;
      private int[] T003Q21_A126TASICod ;
      private string[] T003Q21_A129VouNum ;
      private int[] T003Q21_A130VouDSec ;
      private string[] T003Q22_A83ParTip ;
      private int[] T003Q22_A84ParCod ;
      private string[] T003Q23_A13MvATip ;
      private string[] T003Q23_A14MvACod ;
      private string[] T003Q24_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class ctipdoc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctipdoc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003Q4;
        prmT003Q4 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q5;
        prmT003Q5 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q3;
        prmT003Q3 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q6;
        prmT003Q6 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q7;
        prmT003Q7 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q2;
        prmT003Q2 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q8;
        prmT003Q8 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@TipDsc",GXType.NChar,100,0) ,
        new ParDef("@TipAbr",GXType.NChar,5,0) ,
        new ParDef("@TipSigno",GXType.Int16,2,0) ,
        new ParDef("@TipSts",GXType.Int16,1,0) ,
        new ParDef("@TipVta",GXType.Int16,1,0) ,
        new ParDef("@TipCmp",GXType.Int16,1,0) ,
        new ParDef("@TipRHo",GXType.Int16,1,0) ,
        new ParDef("@TipCxP",GXType.Int16,1,0) ,
        new ParDef("@TipBan",GXType.Int16,1,0)
        };
        Object[] prmT003Q9;
        prmT003Q9 = new Object[] {
        new ParDef("@TipDsc",GXType.NChar,100,0) ,
        new ParDef("@TipAbr",GXType.NChar,5,0) ,
        new ParDef("@TipSigno",GXType.Int16,2,0) ,
        new ParDef("@TipSts",GXType.Int16,1,0) ,
        new ParDef("@TipVta",GXType.Int16,1,0) ,
        new ParDef("@TipCmp",GXType.Int16,1,0) ,
        new ParDef("@TipRHo",GXType.Int16,1,0) ,
        new ParDef("@TipCxP",GXType.Int16,1,0) ,
        new ParDef("@TipBan",GXType.Int16,1,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q10;
        prmT003Q10 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q11;
        prmT003Q11 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q12;
        prmT003Q12 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q13;
        prmT003Q13 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q14;
        prmT003Q14 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q15;
        prmT003Q15 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q16;
        prmT003Q16 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q17;
        prmT003Q17 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q18;
        prmT003Q18 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q19;
        prmT003Q19 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q20;
        prmT003Q20 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q21;
        prmT003Q21 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q22;
        prmT003Q22 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q23;
        prmT003Q23 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003Q24;
        prmT003Q24 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003Q2", "SELECT [TipCod], [TipDsc], [TipAbr], [TipSigno], [TipSts], [TipVta], [TipCmp], [TipRHo], [TipCxP], [TipBan] FROM [CTIPDOC] WITH (UPDLOCK) WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Q3", "SELECT [TipCod], [TipDsc], [TipAbr], [TipSigno], [TipSts], [TipVta], [TipCmp], [TipRHo], [TipCxP], [TipBan] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Q4", "SELECT TM1.[TipCod], TM1.[TipDsc], TM1.[TipAbr], TM1.[TipSigno], TM1.[TipSts], TM1.[TipVta], TM1.[TipCmp], TM1.[TipRHo], TM1.[TipCxP], TM1.[TipBan] FROM [CTIPDOC] TM1 WHERE TM1.[TipCod] = @TipCod ORDER BY TM1.[TipCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Q5", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Q6", "SELECT TOP 1 [TipCod] FROM [CTIPDOC] WHERE ( [TipCod] > @TipCod) ORDER BY [TipCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q7", "SELECT TOP 1 [TipCod] FROM [CTIPDOC] WHERE ( [TipCod] < @TipCod) ORDER BY [TipCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q8", "INSERT INTO [CTIPDOC]([TipCod], [TipDsc], [TipAbr], [TipSigno], [TipSts], [TipVta], [TipCmp], [TipRHo], [TipCxP], [TipBan]) VALUES(@TipCod, @TipDsc, @TipAbr, @TipSigno, @TipSts, @TipVta, @TipCmp, @TipRHo, @TipCxP, @TipBan)", GxErrorMask.GX_NOMASK,prmT003Q8)
           ,new CursorDef("T003Q9", "UPDATE [CTIPDOC] SET [TipDsc]=@TipDsc, [TipAbr]=@TipAbr, [TipSigno]=@TipSigno, [TipSts]=@TipSts, [TipVta]=@TipVta, [TipCmp]=@TipCmp, [TipRHo]=@TipRHo, [TipCxP]=@TipCxP, [TipBan]=@TipBan  WHERE [TipCod] = @TipCod", GxErrorMask.GX_NOMASK,prmT003Q9)
           ,new CursorDef("T003Q10", "DELETE FROM [CTIPDOC]  WHERE [TipCod] = @TipCod", GxErrorMask.GX_NOMASK,prmT003Q10)
           ,new CursorDef("T003Q11", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] WHERE [LiqDTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q12", "SELECT TOP 1 [LetPLetCod], [LetPItem] FROM [CPLETRASDET] WHERE [LetPTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q13", "SELECT TOP 1 [CPTipCod], [CPComCod], [CPPrvCod] FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q14", "SELECT TOP 1 [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] WHERE [CheqDTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q15", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q16", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q17", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q18", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q19", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q20", "SELECT TOP 1 [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q21", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [VouDTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q22", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q23", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [DocTip] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Q24", "SELECT [TipCod] FROM [CTIPDOC] ORDER BY [TipCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Q24,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
