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
   public class cbrubros : GXHttpHandler
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
            A114TotTipo = GetPar( "TotTipo");
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A114TotTipo, A115TotRub) ;
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
            Form.Meta.addItem("description", "Rubros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbrubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbrubros( IGxContext context )
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
            RenderHtmlCloseForm1W65( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBRUBROS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Reporte", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotTipo_Internalname, StringUtil.RTrim( A114TotTipo), StringUtil.RTrim( context.localUtil.Format( A114TotTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotTipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Rubro Totales", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotRub_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")), StringUtil.LTrim( ((edtTotRub_Enabled!=0) ? context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9") : context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotRub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotRub_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Rubro", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtRubCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Rubro", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubDsc_Internalname, StringUtil.RTrim( A1822RubDsc), StringUtil.RTrim( context.localUtil.Format( A1822RubDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Totales de Rubros", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubDscTot_Internalname, StringUtil.RTrim( A1823RubDscTot), StringUtil.RTrim( context.localUtil.Format( A1823RubDscTot, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubDscTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubDscTot_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "N° Orden", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A117RubOrd), 2, 0, ".", "")), StringUtil.LTrim( ((edtRubOrd_Enabled!=0) ? context.localUtil.Format( (decimal)(A117RubOrd), "Z9") : context.localUtil.Format( (decimal)(A117RubOrd), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubOrd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubOrd_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1829RubSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtRubSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1829RubSts), "9") : context.localUtil.Format( (decimal)(A1829RubSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBRUBROS.htm");
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
            Z114TotTipo = cgiGet( "Z114TotTipo");
            Z115TotRub = (int)(context.localUtil.CToN( cgiGet( "Z115TotRub"), ".", ","));
            Z116RubCod = (int)(context.localUtil.CToN( cgiGet( "Z116RubCod"), ".", ","));
            Z1822RubDsc = cgiGet( "Z1822RubDsc");
            Z1823RubDscTot = cgiGet( "Z1823RubDscTot");
            Z117RubOrd = (short)(context.localUtil.CToN( cgiGet( "Z117RubOrd"), ".", ","));
            Z1829RubSts = (short)(context.localUtil.CToN( cgiGet( "Z1829RubSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A114TotTipo = cgiGet( edtTotTipo_Internalname);
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTRUB");
               AnyError = 1;
               GX_FocusControl = edtTotRub_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A115TotRub = 0;
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            }
            else
            {
               A115TotRub = (int)(context.localUtil.CToN( cgiGet( edtTotRub_Internalname), ".", ","));
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBCOD");
               AnyError = 1;
               GX_FocusControl = edtRubCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A116RubCod = 0;
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            }
            else
            {
               A116RubCod = (int)(context.localUtil.CToN( cgiGet( edtRubCod_Internalname), ".", ","));
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            }
            A1822RubDsc = cgiGet( edtRubDsc_Internalname);
            AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
            A1823RubDscTot = cgiGet( edtRubDscTot_Internalname);
            AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubOrd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubOrd_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBORD");
               AnyError = 1;
               GX_FocusControl = edtRubOrd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A117RubOrd = 0;
               AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
            }
            else
            {
               A117RubOrd = (short)(context.localUtil.CToN( cgiGet( edtRubOrd_Internalname), ".", ","));
               AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBSTS");
               AnyError = 1;
               GX_FocusControl = edtRubSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1829RubSts = 0;
               AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
            }
            else
            {
               A1829RubSts = (short)(context.localUtil.CToN( cgiGet( edtRubSts_Internalname), ".", ","));
               AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
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
               A114TotTipo = GetPar( "TotTipo");
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = (int)(NumberUtil.Val( GetPar( "TotRub"), "."));
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
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
               InitAll1W65( ) ;
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
         DisableAttributes1W65( ) ;
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

      protected void CONFIRM_1W0( )
      {
         BeforeValidate1W65( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1W65( ) ;
            }
            else
            {
               CheckExtendedTable1W65( ) ;
               if ( AnyError == 0 )
               {
                  ZM1W65( 2) ;
               }
               CloseExtendedTableCursors1W65( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1W0( ) ;
         }
      }

      protected void ResetCaption1W0( )
      {
      }

      protected void ZM1W65( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1822RubDsc = T001W3_A1822RubDsc[0];
               Z1823RubDscTot = T001W3_A1823RubDscTot[0];
               Z117RubOrd = T001W3_A117RubOrd[0];
               Z1829RubSts = T001W3_A1829RubSts[0];
            }
            else
            {
               Z1822RubDsc = A1822RubDsc;
               Z1823RubDscTot = A1823RubDscTot;
               Z117RubOrd = A117RubOrd;
               Z1829RubSts = A1829RubSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z116RubCod = A116RubCod;
            Z1822RubDsc = A1822RubDsc;
            Z1823RubDscTot = A1823RubDscTot;
            Z117RubOrd = A117RubOrd;
            Z1829RubSts = A1829RubSts;
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
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

      protected void Load1W65( )
      {
         /* Using cursor T001W5 */
         pr_default.execute(3, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound65 = 1;
            A1822RubDsc = T001W5_A1822RubDsc[0];
            AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
            A1823RubDscTot = T001W5_A1823RubDscTot[0];
            AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
            A117RubOrd = T001W5_A117RubOrd[0];
            AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
            A1829RubSts = T001W5_A1829RubSts[0];
            AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
            ZM1W65( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1W65( ) ;
      }

      protected void OnLoadActions1W65( )
      {
      }

      protected void CheckExtendedTable1W65( )
      {
         nIsDirty_65 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001W4 */
         pr_default.execute(2, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1W65( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A114TotTipo ,
                               int A115TotRub )
      {
         /* Using cursor T001W6 */
         pr_default.execute(4, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
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

      protected void GetKey1W65( )
      {
         /* Using cursor T001W7 */
         pr_default.execute(5, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound65 = 1;
         }
         else
         {
            RcdFound65 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001W3 */
         pr_default.execute(1, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1W65( 1) ;
            RcdFound65 = 1;
            A116RubCod = T001W3_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A1822RubDsc = T001W3_A1822RubDsc[0];
            AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
            A1823RubDscTot = T001W3_A1823RubDscTot[0];
            AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
            A117RubOrd = T001W3_A117RubOrd[0];
            AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
            A1829RubSts = T001W3_A1829RubSts[0];
            AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
            A114TotTipo = T001W3_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001W3_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            sMode65 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1W65( ) ;
            if ( AnyError == 1 )
            {
               RcdFound65 = 0;
               InitializeNonKey1W65( ) ;
            }
            Gx_mode = sMode65;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound65 = 0;
            InitializeNonKey1W65( ) ;
            sMode65 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode65;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1W65( ) ;
         if ( RcdFound65 == 0 )
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
         RcdFound65 = 0;
         /* Using cursor T001W8 */
         pr_default.execute(6, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T001W8_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T001W8_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W8_A115TotRub[0] < A115TotRub ) || ( T001W8_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001W8_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W8_A116RubCod[0] < A116RubCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T001W8_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T001W8_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W8_A115TotRub[0] > A115TotRub ) || ( T001W8_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001W8_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W8_A116RubCod[0] > A116RubCod ) ) )
            {
               A114TotTipo = T001W8_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T001W8_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T001W8_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               RcdFound65 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound65 = 0;
         /* Using cursor T001W9 */
         pr_default.execute(7, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T001W9_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T001W9_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W9_A115TotRub[0] > A115TotRub ) || ( T001W9_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001W9_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W9_A116RubCod[0] > A116RubCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T001W9_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T001W9_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W9_A115TotRub[0] < A115TotRub ) || ( T001W9_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001W9_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001W9_A116RubCod[0] < A116RubCod ) ) )
            {
               A114TotTipo = T001W9_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T001W9_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T001W9_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               RcdFound65 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1W65( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1W65( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound65 == 1 )
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
               {
                  A114TotTipo = Z114TotTipo;
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = Z115TotRub;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  A116RubCod = Z116RubCod;
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TOTTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1W65( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1W65( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOTTIPO");
                     AnyError = 1;
                     GX_FocusControl = edtTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTotTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1W65( ) ;
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
         if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
         {
            A114TotTipo = Z114TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = Z115TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = Z116RubCod;
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTotTipo_Internalname;
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
         GetKey1W65( ) ;
         if ( RcdFound65 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TOTTIPO");
               AnyError = 1;
               GX_FocusControl = edtTotTipo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
            {
               A114TotTipo = Z114TotTipo;
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = Z115TotRub;
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = Z116RubCod;
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TOTTIPO");
               AnyError = 1;
               GX_FocusControl = edtTotTipo_Internalname;
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
            if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TOTTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtTotTipo_Internalname;
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
         context.RollbackDataStores("cbrubros",pr_default);
         GX_FocusControl = edtRubDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1W0( ) ;
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
         if ( RcdFound65 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtRubDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1W65( ) ;
         if ( RcdFound65 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1W65( ) ;
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
         if ( RcdFound65 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubDsc_Internalname;
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
         if ( RcdFound65 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubDsc_Internalname;
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
         ScanStart1W65( ) ;
         if ( RcdFound65 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound65 != 0 )
            {
               ScanNext1W65( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1W65( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1W65( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001W2 */
            pr_default.execute(0, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1822RubDsc, T001W2_A1822RubDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1823RubDscTot, T001W2_A1823RubDscTot[0]) != 0 ) || ( Z117RubOrd != T001W2_A117RubOrd[0] ) || ( Z1829RubSts != T001W2_A1829RubSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1822RubDsc, T001W2_A1822RubDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbrubros:[seudo value changed for attri]"+"RubDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1822RubDsc);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A1822RubDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1823RubDscTot, T001W2_A1823RubDscTot[0]) != 0 )
               {
                  GXUtil.WriteLog("cbrubros:[seudo value changed for attri]"+"RubDscTot");
                  GXUtil.WriteLogRaw("Old: ",Z1823RubDscTot);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A1823RubDscTot[0]);
               }
               if ( Z117RubOrd != T001W2_A117RubOrd[0] )
               {
                  GXUtil.WriteLog("cbrubros:[seudo value changed for attri]"+"RubOrd");
                  GXUtil.WriteLogRaw("Old: ",Z117RubOrd);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A117RubOrd[0]);
               }
               if ( Z1829RubSts != T001W2_A1829RubSts[0] )
               {
                  GXUtil.WriteLog("cbrubros:[seudo value changed for attri]"+"RubSts");
                  GXUtil.WriteLogRaw("Old: ",Z1829RubSts);
                  GXUtil.WriteLogRaw("Current: ",T001W2_A1829RubSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W65( )
      {
         BeforeValidate1W65( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W65( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W65( 0) ;
            CheckOptimisticConcurrency1W65( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W65( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W65( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W10 */
                     pr_default.execute(8, new Object[] {A116RubCod, A1822RubDsc, A1823RubDscTot, A117RubOrd, A1829RubSts, A114TotTipo, A115TotRub});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROS");
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
                           ResetCaption1W0( ) ;
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
               Load1W65( ) ;
            }
            EndLevel1W65( ) ;
         }
         CloseExtendedTableCursors1W65( ) ;
      }

      protected void Update1W65( )
      {
         BeforeValidate1W65( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W65( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W65( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W65( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1W65( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001W11 */
                     pr_default.execute(9, new Object[] {A1822RubDsc, A1823RubDscTot, A117RubOrd, A1829RubSts, A114TotTipo, A115TotRub, A116RubCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1W65( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1W0( ) ;
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
            EndLevel1W65( ) ;
         }
         CloseExtendedTableCursors1W65( ) ;
      }

      protected void DeferredUpdate1W65( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1W65( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W65( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W65( ) ;
            AfterConfirm1W65( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W65( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001W12 */
                  pr_default.execute(10, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBRUBROS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound65 == 0 )
                        {
                           InitAll1W65( ) ;
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
                        ResetCaption1W0( ) ;
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
         sMode65 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1W65( ) ;
         Gx_mode = sMode65;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1W65( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001W13 */
            pr_default.execute(11, new Object[] {A114TotTipo, A115TotRub, A116RubCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Rubros Lineas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1W65( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1W65( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbrubros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbrubros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1W65( )
      {
         /* Using cursor T001W14 */
         pr_default.execute(12);
         RcdFound65 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound65 = 1;
            A114TotTipo = T001W14_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001W14_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T001W14_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1W65( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound65 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound65 = 1;
            A114TotTipo = T001W14_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001W14_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T001W14_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         }
      }

      protected void ScanEnd1W65( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1W65( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W65( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W65( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W65( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W65( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W65( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W65( )
      {
         edtTotTipo_Enabled = 0;
         AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         edtTotRub_Enabled = 0;
         AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         edtRubCod_Enabled = 0;
         AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         edtRubDsc_Enabled = 0;
         AssignProp("", false, edtRubDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubDsc_Enabled), 5, 0), true);
         edtRubDscTot_Enabled = 0;
         AssignProp("", false, edtRubDscTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubDscTot_Enabled), 5, 0), true);
         edtRubOrd_Enabled = 0;
         AssignProp("", false, edtRubOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubOrd_Enabled), 5, 0), true);
         edtRubSts_Enabled = 0;
         AssignProp("", false, edtRubSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1W65( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1W0( )
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
         context.SendWebValue( "Rubros") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810241337", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbrubros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116RubCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z116RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1822RubDsc", StringUtil.RTrim( Z1822RubDsc));
         GxWebStd.gx_hidden_field( context, "Z1823RubDscTot", StringUtil.RTrim( Z1823RubDscTot));
         GxWebStd.gx_hidden_field( context, "Z117RubOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z117RubOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1829RubSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1829RubSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm1W65( )
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
         return "CBRUBROS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rubros" ;
      }

      protected void InitializeNonKey1W65( )
      {
         A1822RubDsc = "";
         AssignAttri("", false, "A1822RubDsc", A1822RubDsc);
         A1823RubDscTot = "";
         AssignAttri("", false, "A1823RubDscTot", A1823RubDscTot);
         A117RubOrd = 0;
         AssignAttri("", false, "A117RubOrd", StringUtil.LTrimStr( (decimal)(A117RubOrd), 2, 0));
         A1829RubSts = 0;
         AssignAttri("", false, "A1829RubSts", StringUtil.Str( (decimal)(A1829RubSts), 1, 0));
         Z1822RubDsc = "";
         Z1823RubDscTot = "";
         Z117RubOrd = 0;
         Z1829RubSts = 0;
      }

      protected void InitAll1W65( )
      {
         A114TotTipo = "";
         AssignAttri("", false, "A114TotTipo", A114TotTipo);
         A115TotRub = 0;
         AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         A116RubCod = 0;
         AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         InitializeNonKey1W65( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810241343", true, true);
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
         context.AddJavascriptSource("cbrubros.js", "?202281810241344", false, true);
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
         edtTotTipo_Internalname = "TOTTIPO";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTotRub_Internalname = "TOTRUB";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtRubCod_Internalname = "RUBCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtRubDsc_Internalname = "RUBDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtRubDscTot_Internalname = "RUBDSCTOT";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtRubOrd_Internalname = "RUBORD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtRubSts_Internalname = "RUBSTS";
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
         edtRubSts_Jsonclick = "";
         edtRubSts_Enabled = 1;
         edtRubOrd_Jsonclick = "";
         edtRubOrd_Enabled = 1;
         edtRubDscTot_Jsonclick = "";
         edtRubDscTot_Enabled = 1;
         edtRubDsc_Jsonclick = "";
         edtRubDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtRubCod_Jsonclick = "";
         edtRubCod_Enabled = 1;
         edtTotRub_Jsonclick = "";
         edtTotRub_Enabled = 1;
         edtTotTipo_Jsonclick = "";
         edtTotTipo_Enabled = 1;
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
         /* Using cursor T001W15 */
         pr_default.execute(13, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         GX_FocusControl = edtRubDsc_Internalname;
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

      public void Valid_Totrub( )
      {
         /* Using cursor T001W15 */
         pr_default.execute(13, new Object[] {A114TotTipo, A115TotRub});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Totales'.", "ForeignKeyNotFound", 1, "TOTRUB");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Rubcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1822RubDsc", StringUtil.RTrim( A1822RubDsc));
         AssignAttri("", false, "A1823RubDscTot", StringUtil.RTrim( A1823RubDscTot));
         AssignAttri("", false, "A117RubOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A117RubOrd), 2, 0, ".", "")));
         AssignAttri("", false, "A1829RubSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1829RubSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116RubCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z116RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1822RubDsc", StringUtil.RTrim( Z1822RubDsc));
         GxWebStd.gx_hidden_field( context, "Z1823RubDscTot", StringUtil.RTrim( Z1823RubDscTot));
         GxWebStd.gx_hidden_field( context, "Z117RubOrd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z117RubOrd), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1829RubSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1829RubSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TOTTIPO","{handler:'Valid_Tottipo',iparms:[]");
         setEventMetadata("VALID_TOTTIPO",",oparms:[]}");
         setEventMetadata("VALID_TOTRUB","{handler:'Valid_Totrub',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TOTRUB",",oparms:[]}");
         setEventMetadata("VALID_RUBCOD","{handler:'Valid_Rubcod',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_RUBCOD",",oparms:[{av:'A1822RubDsc',fld:'RUBDSC',pic:''},{av:'A1823RubDscTot',fld:'RUBDSCTOT',pic:''},{av:'A117RubOrd',fld:'RUBORD',pic:'Z9'},{av:'A1829RubSts',fld:'RUBSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z114TotTipo'},{av:'Z115TotRub'},{av:'Z116RubCod'},{av:'Z1822RubDsc'},{av:'Z1823RubDscTot'},{av:'Z117RubOrd'},{av:'Z1829RubSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z114TotTipo = "";
         Z1822RubDsc = "";
         Z1823RubDscTot = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A114TotTipo = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1822RubDsc = "";
         lblTextblock5_Jsonclick = "";
         A1823RubDscTot = "";
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
         T001W5_A116RubCod = new int[1] ;
         T001W5_A1822RubDsc = new string[] {""} ;
         T001W5_A1823RubDscTot = new string[] {""} ;
         T001W5_A117RubOrd = new short[1] ;
         T001W5_A1829RubSts = new short[1] ;
         T001W5_A114TotTipo = new string[] {""} ;
         T001W5_A115TotRub = new int[1] ;
         T001W4_A114TotTipo = new string[] {""} ;
         T001W6_A114TotTipo = new string[] {""} ;
         T001W7_A114TotTipo = new string[] {""} ;
         T001W7_A115TotRub = new int[1] ;
         T001W7_A116RubCod = new int[1] ;
         T001W3_A116RubCod = new int[1] ;
         T001W3_A1822RubDsc = new string[] {""} ;
         T001W3_A1823RubDscTot = new string[] {""} ;
         T001W3_A117RubOrd = new short[1] ;
         T001W3_A1829RubSts = new short[1] ;
         T001W3_A114TotTipo = new string[] {""} ;
         T001W3_A115TotRub = new int[1] ;
         sMode65 = "";
         T001W8_A114TotTipo = new string[] {""} ;
         T001W8_A115TotRub = new int[1] ;
         T001W8_A116RubCod = new int[1] ;
         T001W9_A114TotTipo = new string[] {""} ;
         T001W9_A115TotRub = new int[1] ;
         T001W9_A116RubCod = new int[1] ;
         T001W2_A116RubCod = new int[1] ;
         T001W2_A1822RubDsc = new string[] {""} ;
         T001W2_A1823RubDscTot = new string[] {""} ;
         T001W2_A117RubOrd = new short[1] ;
         T001W2_A1829RubSts = new short[1] ;
         T001W2_A114TotTipo = new string[] {""} ;
         T001W2_A115TotRub = new int[1] ;
         T001W13_A114TotTipo = new string[] {""} ;
         T001W13_A115TotRub = new int[1] ;
         T001W13_A116RubCod = new int[1] ;
         T001W13_A118RubLinCod = new int[1] ;
         T001W14_A114TotTipo = new string[] {""} ;
         T001W14_A115TotRub = new int[1] ;
         T001W14_A116RubCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001W15_A114TotTipo = new string[] {""} ;
         ZZ114TotTipo = "";
         ZZ1822RubDsc = "";
         ZZ1823RubDscTot = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbrubros__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbrubros__default(),
            new Object[][] {
                new Object[] {
               T001W2_A116RubCod, T001W2_A1822RubDsc, T001W2_A1823RubDscTot, T001W2_A117RubOrd, T001W2_A1829RubSts, T001W2_A114TotTipo, T001W2_A115TotRub
               }
               , new Object[] {
               T001W3_A116RubCod, T001W3_A1822RubDsc, T001W3_A1823RubDscTot, T001W3_A117RubOrd, T001W3_A1829RubSts, T001W3_A114TotTipo, T001W3_A115TotRub
               }
               , new Object[] {
               T001W4_A114TotTipo
               }
               , new Object[] {
               T001W5_A116RubCod, T001W5_A1822RubDsc, T001W5_A1823RubDscTot, T001W5_A117RubOrd, T001W5_A1829RubSts, T001W5_A114TotTipo, T001W5_A115TotRub
               }
               , new Object[] {
               T001W6_A114TotTipo
               }
               , new Object[] {
               T001W7_A114TotTipo, T001W7_A115TotRub, T001W7_A116RubCod
               }
               , new Object[] {
               T001W8_A114TotTipo, T001W8_A115TotRub, T001W8_A116RubCod
               }
               , new Object[] {
               T001W9_A114TotTipo, T001W9_A115TotRub, T001W9_A116RubCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001W13_A114TotTipo, T001W13_A115TotRub, T001W13_A116RubCod, T001W13_A118RubLinCod
               }
               , new Object[] {
               T001W14_A114TotTipo, T001W14_A115TotRub, T001W14_A116RubCod
               }
               , new Object[] {
               T001W15_A114TotTipo
               }
            }
         );
      }

      private short Z117RubOrd ;
      private short Z1829RubSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A117RubOrd ;
      private short A1829RubSts ;
      private short GX_JID ;
      private short RcdFound65 ;
      private short nIsDirty_65 ;
      private short Gx_BScreen ;
      private short ZZ117RubOrd ;
      private short ZZ1829RubSts ;
      private int Z115TotRub ;
      private int Z116RubCod ;
      private int A115TotRub ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTotTipo_Enabled ;
      private int edtTotRub_Enabled ;
      private int A116RubCod ;
      private int edtRubCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtRubDsc_Enabled ;
      private int edtRubDscTot_Enabled ;
      private int edtRubOrd_Enabled ;
      private int edtRubSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ115TotRub ;
      private int ZZ116RubCod ;
      private string sPrefix ;
      private string Z114TotTipo ;
      private string Z1822RubDsc ;
      private string Z1823RubDscTot ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A114TotTipo ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTotTipo_Internalname ;
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
      private string edtTotTipo_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTotRub_Internalname ;
      private string edtTotRub_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtRubCod_Internalname ;
      private string edtRubCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtRubDsc_Internalname ;
      private string A1822RubDsc ;
      private string edtRubDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtRubDscTot_Internalname ;
      private string A1823RubDscTot ;
      private string edtRubDscTot_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtRubOrd_Internalname ;
      private string edtRubOrd_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtRubSts_Internalname ;
      private string edtRubSts_Jsonclick ;
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
      private string sMode65 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ114TotTipo ;
      private string ZZ1822RubDsc ;
      private string ZZ1823RubDscTot ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001W5_A116RubCod ;
      private string[] T001W5_A1822RubDsc ;
      private string[] T001W5_A1823RubDscTot ;
      private short[] T001W5_A117RubOrd ;
      private short[] T001W5_A1829RubSts ;
      private string[] T001W5_A114TotTipo ;
      private int[] T001W5_A115TotRub ;
      private string[] T001W4_A114TotTipo ;
      private string[] T001W6_A114TotTipo ;
      private string[] T001W7_A114TotTipo ;
      private int[] T001W7_A115TotRub ;
      private int[] T001W7_A116RubCod ;
      private int[] T001W3_A116RubCod ;
      private string[] T001W3_A1822RubDsc ;
      private string[] T001W3_A1823RubDscTot ;
      private short[] T001W3_A117RubOrd ;
      private short[] T001W3_A1829RubSts ;
      private string[] T001W3_A114TotTipo ;
      private int[] T001W3_A115TotRub ;
      private string[] T001W8_A114TotTipo ;
      private int[] T001W8_A115TotRub ;
      private int[] T001W8_A116RubCod ;
      private string[] T001W9_A114TotTipo ;
      private int[] T001W9_A115TotRub ;
      private int[] T001W9_A116RubCod ;
      private int[] T001W2_A116RubCod ;
      private string[] T001W2_A1822RubDsc ;
      private string[] T001W2_A1823RubDscTot ;
      private short[] T001W2_A117RubOrd ;
      private short[] T001W2_A1829RubSts ;
      private string[] T001W2_A114TotTipo ;
      private int[] T001W2_A115TotRub ;
      private string[] T001W13_A114TotTipo ;
      private int[] T001W13_A115TotRub ;
      private int[] T001W13_A116RubCod ;
      private int[] T001W13_A118RubLinCod ;
      private string[] T001W14_A114TotTipo ;
      private int[] T001W14_A115TotRub ;
      private int[] T001W14_A116RubCod ;
      private string[] T001W15_A114TotTipo ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cbrubros__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbrubros__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001W5;
        prmT001W5 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W4;
        prmT001W4 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001W6;
        prmT001W6 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001W7;
        prmT001W7 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W3;
        prmT001W3 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W8;
        prmT001W8 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W9;
        prmT001W9 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W2;
        prmT001W2 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W10;
        prmT001W10 = new Object[] {
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubDsc",GXType.NChar,100,0) ,
        new ParDef("@RubDscTot",GXType.NChar,100,0) ,
        new ParDef("@RubOrd",GXType.Int16,2,0) ,
        new ParDef("@RubSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        Object[] prmT001W11;
        prmT001W11 = new Object[] {
        new ParDef("@RubDsc",GXType.NChar,100,0) ,
        new ParDef("@RubDscTot",GXType.NChar,100,0) ,
        new ParDef("@RubOrd",GXType.Int16,2,0) ,
        new ParDef("@RubSts",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W12;
        prmT001W12 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W13;
        prmT001W13 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0)
        };
        Object[] prmT001W14;
        prmT001W14 = new Object[] {
        };
        Object[] prmT001W15;
        prmT001W15 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001W2", "SELECT [RubCod], [RubDsc], [RubDscTot], [RubOrd], [RubSts], [TotTipo], [TotRub] FROM [CBRUBROS] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W3", "SELECT [RubCod], [RubDsc], [RubDscTot], [RubOrd], [RubSts], [TotTipo], [TotRub] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W4", "SELECT [TotTipo] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W5", "SELECT TM1.[RubCod], TM1.[RubDsc], TM1.[RubDscTot], TM1.[RubOrd], TM1.[RubSts], TM1.[TotTipo], TM1.[TotRub] FROM [CBRUBROS] TM1 WHERE TM1.[TotTipo] = @TotTipo and TM1.[TotRub] = @TotRub and TM1.[RubCod] = @RubCod ORDER BY TM1.[TotTipo], TM1.[TotRub], TM1.[RubCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W6", "SELECT [TotTipo] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W7", "SELECT [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W8", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE ( [TotTipo] > @TotTipo or [TotTipo] = @TotTipo and [TotRub] > @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] > @RubCod) ORDER BY [TotTipo], [TotRub], [RubCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W9", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] WHERE ( [TotTipo] < @TotTipo or [TotTipo] = @TotTipo and [TotRub] < @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] < @RubCod) ORDER BY [TotTipo] DESC, [TotRub] DESC, [RubCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W10", "INSERT INTO [CBRUBROS]([RubCod], [RubDsc], [RubDscTot], [RubOrd], [RubSts], [TotTipo], [TotRub]) VALUES(@RubCod, @RubDsc, @RubDscTot, @RubOrd, @RubSts, @TotTipo, @TotRub)", GxErrorMask.GX_NOMASK,prmT001W10)
           ,new CursorDef("T001W11", "UPDATE [CBRUBROS] SET [RubDsc]=@RubDsc, [RubDscTot]=@RubDscTot, [RubOrd]=@RubOrd, [RubSts]=@RubSts  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod", GxErrorMask.GX_NOMASK,prmT001W11)
           ,new CursorDef("T001W12", "DELETE FROM [CBRUBROS]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod", GxErrorMask.GX_NOMASK,prmT001W12)
           ,new CursorDef("T001W13", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001W14", "SELECT [TotTipo], [TotRub], [RubCod] FROM [CBRUBROS] ORDER BY [TotTipo], [TotRub], [RubCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001W14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001W15", "SELECT [TotTipo] FROM [CBRUBROST] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub ",true, GxErrorMask.GX_NOMASK, false, this,prmT001W15,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
