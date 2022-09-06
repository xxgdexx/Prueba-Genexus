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
   public class cbrubrosld : GXDataArea
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
            A116RubCod = (int)(NumberUtil.Val( GetPar( "RubCod"), "."));
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = (int)(NumberUtil.Val( GetPar( "RubLinCod"), "."));
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A91CueCod) ;
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
            Form.Meta.addItem("description", "Rubros Lineas Detalles", 0) ;
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

      public cbrubrosld( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbrubrosld( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBRUBROSLD.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Reporte", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotTipo_Internalname, StringUtil.RTrim( A114TotTipo), StringUtil.RTrim( context.localUtil.Format( A114TotTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotTipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Rubro Totales", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotRub_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115TotRub), 6, 0, ".", "")), StringUtil.LTrim( ((edtTotRub_Enabled!=0) ? context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9") : context.localUtil.Format( (decimal)(A115TotRub), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotRub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotRub_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Rubro", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A116RubCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtRubCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A116RubCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Linea", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118RubLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtRubLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A118RubLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Cuenta", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Signo Positivo", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLDPos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1825RubLDPos), 1, 0, ".", "")), StringUtil.LTrim( ((edtRubLDPos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1825RubLDPos), "9") : context.localUtil.Format( (decimal)(A1825RubLDPos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLDPos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubLDPos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Signo Negativo", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBRUBROSLD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubLDNeg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1824RubLDNeg), 1, 0, ".", "")), StringUtil.LTrim( ((edtRubLDNeg_Enabled!=0) ? context.localUtil.Format( (decimal)(A1824RubLDNeg), "9") : context.localUtil.Format( (decimal)(A1824RubLDNeg), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubLDNeg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRubLDNeg_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBRUBROSLD.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBRUBROSLD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBRUBROSLD.htm");
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
            Z118RubLinCod = (int)(context.localUtil.CToN( cgiGet( "Z118RubLinCod"), ".", ","));
            Z91CueCod = cgiGet( "Z91CueCod");
            Z1825RubLDPos = (short)(context.localUtil.CToN( cgiGet( "Z1825RubLDPos"), ".", ","));
            Z1824RubLDNeg = (short)(context.localUtil.CToN( cgiGet( "Z1824RubLDNeg"), ".", ","));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBLINCOD");
               AnyError = 1;
               GX_FocusControl = edtRubLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A118RubLinCod = 0;
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            }
            else
            {
               A118RubLinCod = (int)(context.localUtil.CToN( cgiGet( edtRubLinCod_Internalname), ".", ","));
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            }
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubLDPos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLDPos_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBLDPOS");
               AnyError = 1;
               GX_FocusControl = edtRubLDPos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1825RubLDPos = 0;
               AssignAttri("", false, "A1825RubLDPos", StringUtil.Str( (decimal)(A1825RubLDPos), 1, 0));
            }
            else
            {
               A1825RubLDPos = (short)(context.localUtil.CToN( cgiGet( edtRubLDPos_Internalname), ".", ","));
               AssignAttri("", false, "A1825RubLDPos", StringUtil.Str( (decimal)(A1825RubLDPos), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRubLDNeg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubLDNeg_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBLDNEG");
               AnyError = 1;
               GX_FocusControl = edtRubLDNeg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1824RubLDNeg = 0;
               AssignAttri("", false, "A1824RubLDNeg", StringUtil.Str( (decimal)(A1824RubLDNeg), 1, 0));
            }
            else
            {
               A1824RubLDNeg = (short)(context.localUtil.CToN( cgiGet( edtRubLDNeg_Internalname), ".", ","));
               AssignAttri("", false, "A1824RubLDNeg", StringUtil.Str( (decimal)(A1824RubLDNeg), 1, 0));
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
               A118RubLinCod = (int)(NumberUtil.Val( GetPar( "RubLinCod"), "."));
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               A91CueCod = GetPar( "CueCod");
               AssignAttri("", false, "A91CueCod", A91CueCod);
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
               InitAll1Y67( ) ;
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
         DisableAttributes1Y67( ) ;
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

      protected void CONFIRM_1Y0( )
      {
         BeforeValidate1Y67( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Y67( ) ;
            }
            else
            {
               CheckExtendedTable1Y67( ) ;
               if ( AnyError == 0 )
               {
                  ZM1Y67( 2) ;
                  ZM1Y67( 3) ;
               }
               CloseExtendedTableCursors1Y67( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1Y0( ) ;
         }
      }

      protected void ResetCaption1Y0( )
      {
      }

      protected void ZM1Y67( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1825RubLDPos = T001Y3_A1825RubLDPos[0];
               Z1824RubLDNeg = T001Y3_A1824RubLDNeg[0];
            }
            else
            {
               Z1825RubLDPos = A1825RubLDPos;
               Z1824RubLDNeg = A1824RubLDNeg;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1825RubLDPos = A1825RubLDPos;
            Z1824RubLDNeg = A1824RubLDNeg;
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            Z118RubLinCod = A118RubLinCod;
            Z91CueCod = A91CueCod;
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

      protected void Load1Y67( )
      {
         /* Using cursor T001Y6 */
         pr_default.execute(4, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound67 = 1;
            A1825RubLDPos = T001Y6_A1825RubLDPos[0];
            AssignAttri("", false, "A1825RubLDPos", StringUtil.Str( (decimal)(A1825RubLDPos), 1, 0));
            A1824RubLDNeg = T001Y6_A1824RubLDNeg[0];
            AssignAttri("", false, "A1824RubLDNeg", StringUtil.Str( (decimal)(A1824RubLDNeg), 1, 0));
            ZM1Y67( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1Y67( ) ;
      }

      protected void OnLoadActions1Y67( )
      {
      }

      protected void CheckExtendedTable1Y67( )
      {
         nIsDirty_67 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001Y4 */
         pr_default.execute(2, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Lineas'.", "ForeignKeyNotFound", 1, "RUBLINCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001Y5 */
         pr_default.execute(3, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Y67( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A114TotTipo ,
                               int A115TotRub ,
                               int A116RubCod ,
                               int A118RubLinCod )
      {
         /* Using cursor T001Y7 */
         pr_default.execute(5, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Lineas'.", "ForeignKeyNotFound", 1, "RUBLINCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
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

      protected void gxLoad_3( string A91CueCod )
      {
         /* Using cursor T001Y8 */
         pr_default.execute(6, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
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

      protected void GetKey1Y67( )
      {
         /* Using cursor T001Y9 */
         pr_default.execute(7, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001Y3 */
         pr_default.execute(1, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Y67( 1) ;
            RcdFound67 = 1;
            A1825RubLDPos = T001Y3_A1825RubLDPos[0];
            AssignAttri("", false, "A1825RubLDPos", StringUtil.Str( (decimal)(A1825RubLDPos), 1, 0));
            A1824RubLDNeg = T001Y3_A1824RubLDNeg[0];
            AssignAttri("", false, "A1824RubLDNeg", StringUtil.Str( (decimal)(A1824RubLDNeg), 1, 0));
            A114TotTipo = T001Y3_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001Y3_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T001Y3_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = T001Y3_A118RubLinCod[0];
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            A91CueCod = T001Y3_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            Z114TotTipo = A114TotTipo;
            Z115TotRub = A115TotRub;
            Z116RubCod = A116RubCod;
            Z118RubLinCod = A118RubLinCod;
            Z91CueCod = A91CueCod;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1Y67( ) ;
            if ( AnyError == 1 )
            {
               RcdFound67 = 0;
               InitializeNonKey1Y67( ) ;
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey1Y67( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Y67( ) ;
         if ( RcdFound67 == 0 )
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
         RcdFound67 = 0;
         /* Using cursor T001Y10 */
         pr_default.execute(8, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y10_A115TotRub[0] < A115TotRub ) || ( T001Y10_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y10_A116RubCod[0] < A116RubCod ) || ( T001Y10_A116RubCod[0] == A116RubCod ) && ( T001Y10_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y10_A118RubLinCod[0] < A118RubLinCod ) || ( T001Y10_A118RubLinCod[0] == A118RubLinCod ) && ( T001Y10_A116RubCod[0] == A116RubCod ) && ( T001Y10_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( StringUtil.StrCmp(T001Y10_A91CueCod[0], A91CueCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y10_A115TotRub[0] > A115TotRub ) || ( T001Y10_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y10_A116RubCod[0] > A116RubCod ) || ( T001Y10_A116RubCod[0] == A116RubCod ) && ( T001Y10_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y10_A118RubLinCod[0] > A118RubLinCod ) || ( T001Y10_A118RubLinCod[0] == A118RubLinCod ) && ( T001Y10_A116RubCod[0] == A116RubCod ) && ( T001Y10_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y10_A114TotTipo[0], A114TotTipo) == 0 ) && ( StringUtil.StrCmp(T001Y10_A91CueCod[0], A91CueCod) > 0 ) ) )
            {
               A114TotTipo = T001Y10_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T001Y10_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T001Y10_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               A118RubLinCod = T001Y10_A118RubLinCod[0];
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               A91CueCod = T001Y10_A91CueCod[0];
               AssignAttri("", false, "A91CueCod", A91CueCod);
               RcdFound67 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound67 = 0;
         /* Using cursor T001Y11 */
         pr_default.execute(9, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) > 0 ) || ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y11_A115TotRub[0] > A115TotRub ) || ( T001Y11_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y11_A116RubCod[0] > A116RubCod ) || ( T001Y11_A116RubCod[0] == A116RubCod ) && ( T001Y11_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y11_A118RubLinCod[0] > A118RubLinCod ) || ( T001Y11_A118RubLinCod[0] == A118RubLinCod ) && ( T001Y11_A116RubCod[0] == A116RubCod ) && ( T001Y11_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( StringUtil.StrCmp(T001Y11_A91CueCod[0], A91CueCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) < 0 ) || ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y11_A115TotRub[0] < A115TotRub ) || ( T001Y11_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y11_A116RubCod[0] < A116RubCod ) || ( T001Y11_A116RubCod[0] == A116RubCod ) && ( T001Y11_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( T001Y11_A118RubLinCod[0] < A118RubLinCod ) || ( T001Y11_A118RubLinCod[0] == A118RubLinCod ) && ( T001Y11_A116RubCod[0] == A116RubCod ) && ( T001Y11_A115TotRub[0] == A115TotRub ) && ( StringUtil.StrCmp(T001Y11_A114TotTipo[0], A114TotTipo) == 0 ) && ( StringUtil.StrCmp(T001Y11_A91CueCod[0], A91CueCod) < 0 ) ) )
            {
               A114TotTipo = T001Y11_A114TotTipo[0];
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = T001Y11_A115TotRub[0];
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = T001Y11_A116RubCod[0];
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               A118RubLinCod = T001Y11_A118RubLinCod[0];
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               A91CueCod = T001Y11_A91CueCod[0];
               AssignAttri("", false, "A91CueCod", A91CueCod);
               RcdFound67 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1Y67( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1Y67( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound67 == 1 )
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) || ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) )
               {
                  A114TotTipo = Z114TotTipo;
                  AssignAttri("", false, "A114TotTipo", A114TotTipo);
                  A115TotRub = Z115TotRub;
                  AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
                  A116RubCod = Z116RubCod;
                  AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
                  A118RubLinCod = Z118RubLinCod;
                  AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
                  A91CueCod = Z91CueCod;
                  AssignAttri("", false, "A91CueCod", A91CueCod);
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
                  Update1Y67( ) ;
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) || ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTotTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1Y67( ) ;
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
                     Insert1Y67( ) ;
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
         if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) || ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) )
         {
            A114TotTipo = Z114TotTipo;
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = Z115TotRub;
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = Z116RubCod;
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = Z118RubLinCod;
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            A91CueCod = Z91CueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
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
         GetKey1Y67( ) ;
         if ( RcdFound67 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TOTTIPO");
               AnyError = 1;
               GX_FocusControl = edtTotTipo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) || ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) )
            {
               A114TotTipo = Z114TotTipo;
               AssignAttri("", false, "A114TotTipo", A114TotTipo);
               A115TotRub = Z115TotRub;
               AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
               A116RubCod = Z116RubCod;
               AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
               A118RubLinCod = Z118RubLinCod;
               AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
               A91CueCod = Z91CueCod;
               AssignAttri("", false, "A91CueCod", A91CueCod);
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
            if ( ( StringUtil.StrCmp(A114TotTipo, Z114TotTipo) != 0 ) || ( A115TotRub != Z115TotRub ) || ( A116RubCod != Z116RubCod ) || ( A118RubLinCod != Z118RubLinCod ) || ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) )
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
         context.RollbackDataStores("cbrubrosld",pr_default);
         GX_FocusControl = edtRubLDPos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1Y0( ) ;
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
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TOTTIPO");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtRubLDPos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1Y67( ) ;
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubLDPos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Y67( ) ;
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
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubLDPos_Internalname;
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
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubLDPos_Internalname;
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
         ScanStart1Y67( ) ;
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound67 != 0 )
            {
               ScanNext1Y67( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRubLDPos_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1Y67( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1Y67( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001Y2 */
            pr_default.execute(0, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROSLD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1825RubLDPos != T001Y2_A1825RubLDPos[0] ) || ( Z1824RubLDNeg != T001Y2_A1824RubLDNeg[0] ) )
            {
               if ( Z1825RubLDPos != T001Y2_A1825RubLDPos[0] )
               {
                  GXUtil.WriteLog("cbrubrosld:[seudo value changed for attri]"+"RubLDPos");
                  GXUtil.WriteLogRaw("Old: ",Z1825RubLDPos);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A1825RubLDPos[0]);
               }
               if ( Z1824RubLDNeg != T001Y2_A1824RubLDNeg[0] )
               {
                  GXUtil.WriteLog("cbrubrosld:[seudo value changed for attri]"+"RubLDNeg");
                  GXUtil.WriteLogRaw("Old: ",Z1824RubLDNeg);
                  GXUtil.WriteLogRaw("Current: ",T001Y2_A1824RubLDNeg[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBRUBROSLD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Y67( )
      {
         BeforeValidate1Y67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y67( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Y67( 0) ;
            CheckOptimisticConcurrency1Y67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Y67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y12 */
                     pr_default.execute(10, new Object[] {A1825RubLDPos, A1824RubLDNeg, A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSLD");
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
                           ResetCaption1Y0( ) ;
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
               Load1Y67( ) ;
            }
            EndLevel1Y67( ) ;
         }
         CloseExtendedTableCursors1Y67( ) ;
      }

      protected void Update1Y67( )
      {
         BeforeValidate1Y67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y67( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Y67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001Y13 */
                     pr_default.execute(11, new Object[] {A1825RubLDPos, A1824RubLDNeg, A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSLD");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBRUBROSLD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Y67( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1Y0( ) ;
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
            EndLevel1Y67( ) ;
         }
         CloseExtendedTableCursors1Y67( ) ;
      }

      protected void DeferredUpdate1Y67( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1Y67( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y67( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Y67( ) ;
            AfterConfirm1Y67( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Y67( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001Y14 */
                  pr_default.execute(12, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod, A91CueCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CBRUBROSLD");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound67 == 0 )
                        {
                           InitAll1Y67( ) ;
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
                        ResetCaption1Y0( ) ;
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
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1Y67( ) ;
         Gx_mode = sMode67;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1Y67( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1Y67( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Y67( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbrubrosld",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbrubrosld",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1Y67( )
      {
         /* Using cursor T001Y15 */
         pr_default.execute(13);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound67 = 1;
            A114TotTipo = T001Y15_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001Y15_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T001Y15_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = T001Y15_A118RubLinCod[0];
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            A91CueCod = T001Y15_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1Y67( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound67 = 1;
            A114TotTipo = T001Y15_A114TotTipo[0];
            AssignAttri("", false, "A114TotTipo", A114TotTipo);
            A115TotRub = T001Y15_A115TotRub[0];
            AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
            A116RubCod = T001Y15_A116RubCod[0];
            AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
            A118RubLinCod = T001Y15_A118RubLinCod[0];
            AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
            A91CueCod = T001Y15_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
      }

      protected void ScanEnd1Y67( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1Y67( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Y67( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Y67( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Y67( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Y67( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Y67( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Y67( )
      {
         edtTotTipo_Enabled = 0;
         AssignProp("", false, edtTotTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotTipo_Enabled), 5, 0), true);
         edtTotRub_Enabled = 0;
         AssignProp("", false, edtTotRub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotRub_Enabled), 5, 0), true);
         edtRubCod_Enabled = 0;
         AssignProp("", false, edtRubCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubCod_Enabled), 5, 0), true);
         edtRubLinCod_Enabled = 0;
         AssignProp("", false, edtRubLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLinCod_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtRubLDPos_Enabled = 0;
         AssignProp("", false, edtRubLDPos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLDPos_Enabled), 5, 0), true);
         edtRubLDNeg_Enabled = 0;
         AssignProp("", false, edtRubLDNeg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubLDNeg_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1Y67( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1Y0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810241593", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbrubrosld.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z118RubLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118RubLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z1825RubLDPos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1825RubLDPos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1824RubLDNeg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1824RubLDNeg), 1, 0, ".", "")));
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
         return formatLink("cbrubrosld.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBRUBROSLD" ;
      }

      public override string GetPgmdesc( )
      {
         return "Rubros Lineas Detalles" ;
      }

      protected void InitializeNonKey1Y67( )
      {
         A1825RubLDPos = 0;
         AssignAttri("", false, "A1825RubLDPos", StringUtil.Str( (decimal)(A1825RubLDPos), 1, 0));
         A1824RubLDNeg = 0;
         AssignAttri("", false, "A1824RubLDNeg", StringUtil.Str( (decimal)(A1824RubLDNeg), 1, 0));
         Z1825RubLDPos = 0;
         Z1824RubLDNeg = 0;
      }

      protected void InitAll1Y67( )
      {
         A114TotTipo = "";
         AssignAttri("", false, "A114TotTipo", A114TotTipo);
         A115TotRub = 0;
         AssignAttri("", false, "A115TotRub", StringUtil.LTrimStr( (decimal)(A115TotRub), 6, 0));
         A116RubCod = 0;
         AssignAttri("", false, "A116RubCod", StringUtil.LTrimStr( (decimal)(A116RubCod), 6, 0));
         A118RubLinCod = 0;
         AssignAttri("", false, "A118RubLinCod", StringUtil.LTrimStr( (decimal)(A118RubLinCod), 6, 0));
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         InitializeNonKey1Y67( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024160", true, true);
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
         context.AddJavascriptSource("cbrubrosld.js", "?20228181024160", false, true);
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
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtRubLinCod_Internalname = "RUBLINCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCueCod_Internalname = "CUECOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtRubLDPos_Internalname = "RUBLDPOS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtRubLDNeg_Internalname = "RUBLDNEG";
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
         Form.Caption = "Rubros Lineas Detalles";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRubLDNeg_Jsonclick = "";
         edtRubLDNeg_Enabled = 1;
         edtRubLDPos_Jsonclick = "";
         edtRubLDPos_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtRubLinCod_Jsonclick = "";
         edtRubLinCod_Enabled = 1;
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
         /* Using cursor T001Y16 */
         pr_default.execute(14, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Lineas'.", "ForeignKeyNotFound", 1, "RUBLINCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T001Y17 */
         pr_default.execute(15, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtRubLDPos_Internalname;
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

      public void Valid_Rublincod( )
      {
         /* Using cursor T001Y16 */
         pr_default.execute(14, new Object[] {A114TotTipo, A115TotRub, A116RubCod, A118RubLinCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Rubros Lineas'.", "ForeignKeyNotFound", 1, "RUBLINCOD");
            AnyError = 1;
            GX_FocusControl = edtTotTipo_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuecod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001Y17 */
         pr_default.execute(15, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1825RubLDPos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1825RubLDPos), 1, 0, ".", "")));
         AssignAttri("", false, "A1824RubLDNeg", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1824RubLDNeg), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z114TotTipo", StringUtil.RTrim( Z114TotTipo));
         GxWebStd.gx_hidden_field( context, "Z115TotRub", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115TotRub), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116RubCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z116RubCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z118RubLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118RubLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z1825RubLDPos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1825RubLDPos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1824RubLDNeg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1824RubLDNeg), 1, 0, ".", "")));
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
         setEventMetadata("VALID_TOTRUB","{handler:'Valid_Totrub',iparms:[]");
         setEventMetadata("VALID_TOTRUB",",oparms:[]}");
         setEventMetadata("VALID_RUBCOD","{handler:'Valid_Rubcod',iparms:[]");
         setEventMetadata("VALID_RUBCOD",",oparms:[]}");
         setEventMetadata("VALID_RUBLINCOD","{handler:'Valid_Rublincod',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9'},{av:'A118RubLinCod',fld:'RUBLINCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_RUBLINCOD",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A114TotTipo',fld:'TOTTIPO',pic:''},{av:'A115TotRub',fld:'TOTRUB',pic:'ZZZZZ9'},{av:'A116RubCod',fld:'RUBCOD',pic:'ZZZZZ9'},{av:'A118RubLinCod',fld:'RUBLINCOD',pic:'ZZZZZ9'},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A1825RubLDPos',fld:'RUBLDPOS',pic:'9'},{av:'A1824RubLDNeg',fld:'RUBLDNEG',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z114TotTipo'},{av:'Z115TotRub'},{av:'Z116RubCod'},{av:'Z118RubLinCod'},{av:'Z91CueCod'},{av:'Z1825RubLDPos'},{av:'Z1824RubLDNeg'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z114TotTipo = "";
         Z91CueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A114TotTipo = "";
         A91CueCod = "";
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
         T001Y6_A1825RubLDPos = new short[1] ;
         T001Y6_A1824RubLDNeg = new short[1] ;
         T001Y6_A114TotTipo = new string[] {""} ;
         T001Y6_A115TotRub = new int[1] ;
         T001Y6_A116RubCod = new int[1] ;
         T001Y6_A118RubLinCod = new int[1] ;
         T001Y6_A91CueCod = new string[] {""} ;
         T001Y4_A114TotTipo = new string[] {""} ;
         T001Y5_A91CueCod = new string[] {""} ;
         T001Y7_A114TotTipo = new string[] {""} ;
         T001Y8_A91CueCod = new string[] {""} ;
         T001Y9_A114TotTipo = new string[] {""} ;
         T001Y9_A115TotRub = new int[1] ;
         T001Y9_A116RubCod = new int[1] ;
         T001Y9_A118RubLinCod = new int[1] ;
         T001Y9_A91CueCod = new string[] {""} ;
         T001Y3_A1825RubLDPos = new short[1] ;
         T001Y3_A1824RubLDNeg = new short[1] ;
         T001Y3_A114TotTipo = new string[] {""} ;
         T001Y3_A115TotRub = new int[1] ;
         T001Y3_A116RubCod = new int[1] ;
         T001Y3_A118RubLinCod = new int[1] ;
         T001Y3_A91CueCod = new string[] {""} ;
         sMode67 = "";
         T001Y10_A114TotTipo = new string[] {""} ;
         T001Y10_A115TotRub = new int[1] ;
         T001Y10_A116RubCod = new int[1] ;
         T001Y10_A118RubLinCod = new int[1] ;
         T001Y10_A91CueCod = new string[] {""} ;
         T001Y11_A114TotTipo = new string[] {""} ;
         T001Y11_A115TotRub = new int[1] ;
         T001Y11_A116RubCod = new int[1] ;
         T001Y11_A118RubLinCod = new int[1] ;
         T001Y11_A91CueCod = new string[] {""} ;
         T001Y2_A1825RubLDPos = new short[1] ;
         T001Y2_A1824RubLDNeg = new short[1] ;
         T001Y2_A114TotTipo = new string[] {""} ;
         T001Y2_A115TotRub = new int[1] ;
         T001Y2_A116RubCod = new int[1] ;
         T001Y2_A118RubLinCod = new int[1] ;
         T001Y2_A91CueCod = new string[] {""} ;
         T001Y15_A114TotTipo = new string[] {""} ;
         T001Y15_A115TotRub = new int[1] ;
         T001Y15_A116RubCod = new int[1] ;
         T001Y15_A118RubLinCod = new int[1] ;
         T001Y15_A91CueCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001Y16_A114TotTipo = new string[] {""} ;
         T001Y17_A91CueCod = new string[] {""} ;
         ZZ114TotTipo = "";
         ZZ91CueCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbrubrosld__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbrubrosld__default(),
            new Object[][] {
                new Object[] {
               T001Y2_A1825RubLDPos, T001Y2_A1824RubLDNeg, T001Y2_A114TotTipo, T001Y2_A115TotRub, T001Y2_A116RubCod, T001Y2_A118RubLinCod, T001Y2_A91CueCod
               }
               , new Object[] {
               T001Y3_A1825RubLDPos, T001Y3_A1824RubLDNeg, T001Y3_A114TotTipo, T001Y3_A115TotRub, T001Y3_A116RubCod, T001Y3_A118RubLinCod, T001Y3_A91CueCod
               }
               , new Object[] {
               T001Y4_A114TotTipo
               }
               , new Object[] {
               T001Y5_A91CueCod
               }
               , new Object[] {
               T001Y6_A1825RubLDPos, T001Y6_A1824RubLDNeg, T001Y6_A114TotTipo, T001Y6_A115TotRub, T001Y6_A116RubCod, T001Y6_A118RubLinCod, T001Y6_A91CueCod
               }
               , new Object[] {
               T001Y7_A114TotTipo
               }
               , new Object[] {
               T001Y8_A91CueCod
               }
               , new Object[] {
               T001Y9_A114TotTipo, T001Y9_A115TotRub, T001Y9_A116RubCod, T001Y9_A118RubLinCod, T001Y9_A91CueCod
               }
               , new Object[] {
               T001Y10_A114TotTipo, T001Y10_A115TotRub, T001Y10_A116RubCod, T001Y10_A118RubLinCod, T001Y10_A91CueCod
               }
               , new Object[] {
               T001Y11_A114TotTipo, T001Y11_A115TotRub, T001Y11_A116RubCod, T001Y11_A118RubLinCod, T001Y11_A91CueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001Y15_A114TotTipo, T001Y15_A115TotRub, T001Y15_A116RubCod, T001Y15_A118RubLinCod, T001Y15_A91CueCod
               }
               , new Object[] {
               T001Y16_A114TotTipo
               }
               , new Object[] {
               T001Y17_A91CueCod
               }
            }
         );
      }

      private short Z1825RubLDPos ;
      private short Z1824RubLDNeg ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1825RubLDPos ;
      private short A1824RubLDNeg ;
      private short GX_JID ;
      private short RcdFound67 ;
      private short nIsDirty_67 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1825RubLDPos ;
      private short ZZ1824RubLDNeg ;
      private int Z115TotRub ;
      private int Z116RubCod ;
      private int Z118RubLinCod ;
      private int A115TotRub ;
      private int A116RubCod ;
      private int A118RubLinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTotTipo_Enabled ;
      private int edtTotRub_Enabled ;
      private int edtRubCod_Enabled ;
      private int edtRubLinCod_Enabled ;
      private int edtCueCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtRubLDPos_Enabled ;
      private int edtRubLDNeg_Enabled ;
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
      private int ZZ118RubLinCod ;
      private string sPrefix ;
      private string Z114TotTipo ;
      private string Z91CueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A114TotTipo ;
      private string A91CueCod ;
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
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtRubLinCod_Internalname ;
      private string edtRubLinCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtRubLDPos_Internalname ;
      private string edtRubLDPos_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtRubLDNeg_Internalname ;
      private string edtRubLDNeg_Jsonclick ;
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
      private string sMode67 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ114TotTipo ;
      private string ZZ91CueCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T001Y6_A1825RubLDPos ;
      private short[] T001Y6_A1824RubLDNeg ;
      private string[] T001Y6_A114TotTipo ;
      private int[] T001Y6_A115TotRub ;
      private int[] T001Y6_A116RubCod ;
      private int[] T001Y6_A118RubLinCod ;
      private string[] T001Y6_A91CueCod ;
      private string[] T001Y4_A114TotTipo ;
      private string[] T001Y5_A91CueCod ;
      private string[] T001Y7_A114TotTipo ;
      private string[] T001Y8_A91CueCod ;
      private string[] T001Y9_A114TotTipo ;
      private int[] T001Y9_A115TotRub ;
      private int[] T001Y9_A116RubCod ;
      private int[] T001Y9_A118RubLinCod ;
      private string[] T001Y9_A91CueCod ;
      private short[] T001Y3_A1825RubLDPos ;
      private short[] T001Y3_A1824RubLDNeg ;
      private string[] T001Y3_A114TotTipo ;
      private int[] T001Y3_A115TotRub ;
      private int[] T001Y3_A116RubCod ;
      private int[] T001Y3_A118RubLinCod ;
      private string[] T001Y3_A91CueCod ;
      private string[] T001Y10_A114TotTipo ;
      private int[] T001Y10_A115TotRub ;
      private int[] T001Y10_A116RubCod ;
      private int[] T001Y10_A118RubLinCod ;
      private string[] T001Y10_A91CueCod ;
      private string[] T001Y11_A114TotTipo ;
      private int[] T001Y11_A115TotRub ;
      private int[] T001Y11_A116RubCod ;
      private int[] T001Y11_A118RubLinCod ;
      private string[] T001Y11_A91CueCod ;
      private short[] T001Y2_A1825RubLDPos ;
      private short[] T001Y2_A1824RubLDNeg ;
      private string[] T001Y2_A114TotTipo ;
      private int[] T001Y2_A115TotRub ;
      private int[] T001Y2_A116RubCod ;
      private int[] T001Y2_A118RubLinCod ;
      private string[] T001Y2_A91CueCod ;
      private string[] T001Y15_A114TotTipo ;
      private int[] T001Y15_A115TotRub ;
      private int[] T001Y15_A116RubCod ;
      private int[] T001Y15_A118RubLinCod ;
      private string[] T001Y15_A91CueCod ;
      private string[] T001Y16_A114TotTipo ;
      private string[] T001Y17_A91CueCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbrubrosld__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbrubrosld__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001Y6;
        prmT001Y6 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y4;
        prmT001Y4 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT001Y5;
        prmT001Y5 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y7;
        prmT001Y7 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT001Y8;
        prmT001Y8 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y9;
        prmT001Y9 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y3;
        prmT001Y3 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y10;
        prmT001Y10 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y11;
        prmT001Y11 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y2;
        prmT001Y2 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y12;
        prmT001Y12 = new Object[] {
        new ParDef("@RubLDPos",GXType.Int16,1,0) ,
        new ParDef("@RubLDNeg",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y13;
        prmT001Y13 = new Object[] {
        new ParDef("@RubLDPos",GXType.Int16,1,0) ,
        new ParDef("@RubLDNeg",GXType.Int16,1,0) ,
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y14;
        prmT001Y14 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001Y15;
        prmT001Y15 = new Object[] {
        };
        Object[] prmT001Y16;
        prmT001Y16 = new Object[] {
        new ParDef("@TotTipo",GXType.NChar,3,0) ,
        new ParDef("@TotRub",GXType.Int32,6,0) ,
        new ParDef("@RubCod",GXType.Int32,6,0) ,
        new ParDef("@RubLinCod",GXType.Int32,6,0)
        };
        Object[] prmT001Y17;
        prmT001Y17 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001Y2", "SELECT [RubLDPos], [RubLDNeg], [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WITH (UPDLOCK) WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y3", "SELECT [RubLDPos], [RubLDNeg], [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y4", "SELECT [TotTipo] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y5", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y6", "SELECT TM1.[RubLDPos], TM1.[RubLDNeg], TM1.[TotTipo], TM1.[TotRub], TM1.[RubCod], TM1.[RubLinCod], TM1.[CueCod] FROM [CBRUBROSLD] TM1 WHERE TM1.[TotTipo] = @TotTipo and TM1.[TotRub] = @TotRub and TM1.[RubCod] = @RubCod and TM1.[RubLinCod] = @RubLinCod and TM1.[CueCod] = @CueCod ORDER BY TM1.[TotTipo], TM1.[TotRub], TM1.[RubCod], TM1.[RubLinCod], TM1.[CueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y7", "SELECT [TotTipo] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y8", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y9", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y10", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE ( [TotTipo] > @TotTipo or [TotTipo] = @TotTipo and [TotRub] > @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] > @RubCod or [RubCod] = @RubCod and [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubLinCod] > @RubLinCod or [RubLinCod] = @RubLinCod and [RubCod] = @RubCod and [TotRub] = @TotRub and [TotTipo] = @TotTipo and [CueCod] > @CueCod) ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y11", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE ( [TotTipo] < @TotTipo or [TotTipo] = @TotTipo and [TotRub] < @TotRub or [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubCod] < @RubCod or [RubCod] = @RubCod and [TotRub] = @TotRub and [TotTipo] = @TotTipo and [RubLinCod] < @RubLinCod or [RubLinCod] = @RubLinCod and [RubCod] = @RubCod and [TotRub] = @TotRub and [TotTipo] = @TotTipo and [CueCod] < @CueCod) ORDER BY [TotTipo] DESC, [TotRub] DESC, [RubCod] DESC, [RubLinCod] DESC, [CueCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001Y12", "INSERT INTO [CBRUBROSLD]([RubLDPos], [RubLDNeg], [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod]) VALUES(@RubLDPos, @RubLDNeg, @TotTipo, @TotRub, @RubCod, @RubLinCod, @CueCod)", GxErrorMask.GX_NOMASK,prmT001Y12)
           ,new CursorDef("T001Y13", "UPDATE [CBRUBROSLD] SET [RubLDPos]=@RubLDPos, [RubLDNeg]=@RubLDNeg  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT001Y13)
           ,new CursorDef("T001Y14", "DELETE FROM [CBRUBROSLD]  WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod AND [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT001Y14)
           ,new CursorDef("T001Y15", "SELECT [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y16", "SELECT [TotTipo] FROM [CBRUBROSL] WHERE [TotTipo] = @TotTipo AND [TotRub] = @TotRub AND [RubCod] = @RubCod AND [RubLinCod] = @RubLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001Y17", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001Y17,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
