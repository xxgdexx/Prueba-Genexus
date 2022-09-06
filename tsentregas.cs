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
   public class tsentregas : GXHttpHandler
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
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A91CueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A970EntCodAux = GetPar( "EntCodAux");
            n970EntCodAux = false;
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A70TipACod, A970EntCodAux) ;
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
            Form.Meta.addItem("description", "Entregas a Rendir", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsentregas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsentregas( IGxContext context )
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
         cmbEntSts = new GXCombobox();
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
         if ( cmbEntSts.ItemCount > 0 )
         {
            A973EntSts = (short)(NumberUtil.Val( cmbEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0))), "."));
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0));
            AssignProp("", false, cmbEntSts_Internalname, "Values", cmbEntSts.ToJavascriptSource(), true);
         }
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
            RenderHtmlCloseForm58175( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSENTREGAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365EntCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtEntCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Entrega a Rendir", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntDsc_Internalname, StringUtil.RTrim( A972EntDsc), StringUtil.RTrim( context.localUtil.Format( A972EntDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntAbr_Internalname, StringUtil.RTrim( A969EntAbr), StringUtil.RTrim( context.localUtil.Format( A969EntAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cuenta", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Descripción de Cuenta", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc), StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo T. Auxiliar", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipACod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipACod_Enabled!=0) ? context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipACod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Auxiliar", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntCodAux_Internalname, StringUtil.RTrim( A970EntCodAux), StringUtil.RTrim( context.localUtil.Format( A970EntCodAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCodAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntCodAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Auxiliar", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEntCodAuxDsc_Internalname, StringUtil.RTrim( A971EntCodAuxDsc), StringUtil.RTrim( context.localUtil.Format( A971EntCodAuxDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCodAuxDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntCodAuxDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Estado", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSENTREGAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEntSts, cmbEntSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0)), 1, cmbEntSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbEntSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 1, "HLP_TSENTREGAS.htm");
         cmbEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         AssignProp("", false, cmbEntSts_Internalname, "Values", (string)(cmbEntSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSENTREGAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSENTREGAS.htm");
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
            Z365EntCod = (int)(context.localUtil.CToN( cgiGet( "Z365EntCod"), ".", ","));
            Z972EntDsc = cgiGet( "Z972EntDsc");
            Z969EntAbr = cgiGet( "Z969EntAbr");
            Z973EntSts = (short)(context.localUtil.CToN( cgiGet( "Z973EntSts"), ".", ","));
            Z91CueCod = cgiGet( "Z91CueCod");
            Z970EntCodAux = cgiGet( "Z970EntCodAux");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A365EntCod = 0;
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            }
            else
            {
               A365EntCod = (int)(context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ","));
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            }
            A972EntDsc = cgiGet( edtEntDsc_Internalname);
            AssignAttri("", false, "A972EntDsc", A972EntDsc);
            A969EntAbr = cgiGet( edtEntAbr_Internalname);
            AssignAttri("", false, "A969EntAbr", A969EntAbr);
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A860CueDsc = cgiGet( edtCueDsc_Internalname);
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A970EntCodAux = cgiGet( edtEntCodAux_Internalname);
            n970EntCodAux = false;
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            A971EntCodAuxDsc = cgiGet( edtEntCodAuxDsc_Internalname);
            AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
            cmbEntSts.CurrentValue = cgiGet( cmbEntSts_Internalname);
            A973EntSts = (short)(NumberUtil.Val( cgiGet( cmbEntSts_Internalname), "."));
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
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
               A365EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
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
               InitAll58175( ) ;
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
         DisableAttributes58175( ) ;
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

      protected void CONFIRM_580( )
      {
         BeforeValidate58175( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls58175( ) ;
            }
            else
            {
               CheckExtendedTable58175( ) ;
               if ( AnyError == 0 )
               {
                  ZM58175( 2) ;
                  ZM58175( 3) ;
               }
               CloseExtendedTableCursors58175( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues580( ) ;
         }
      }

      protected void ResetCaption580( )
      {
      }

      protected void ZM58175( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z972EntDsc = T00583_A972EntDsc[0];
               Z969EntAbr = T00583_A969EntAbr[0];
               Z973EntSts = T00583_A973EntSts[0];
               Z91CueCod = T00583_A91CueCod[0];
               Z970EntCodAux = T00583_A970EntCodAux[0];
            }
            else
            {
               Z972EntDsc = A972EntDsc;
               Z969EntAbr = A969EntAbr;
               Z973EntSts = A973EntSts;
               Z91CueCod = A91CueCod;
               Z970EntCodAux = A970EntCodAux;
            }
         }
         if ( GX_JID == -1 )
         {
            Z365EntCod = A365EntCod;
            Z972EntDsc = A972EntDsc;
            Z969EntAbr = A969EntAbr;
            Z973EntSts = A973EntSts;
            Z91CueCod = A91CueCod;
            Z970EntCodAux = A970EntCodAux;
            Z860CueDsc = A860CueDsc;
            Z70TipACod = A70TipACod;
            Z971EntCodAuxDsc = A971EntCodAuxDsc;
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

      protected void Load58175( )
      {
         /* Using cursor T00586 */
         pr_default.execute(4, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound175 = 1;
            A972EntDsc = T00586_A972EntDsc[0];
            AssignAttri("", false, "A972EntDsc", A972EntDsc);
            A969EntAbr = T00586_A969EntAbr[0];
            AssignAttri("", false, "A969EntAbr", A969EntAbr);
            A860CueDsc = T00586_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A971EntCodAuxDsc = T00586_A971EntCodAuxDsc[0];
            AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
            A973EntSts = T00586_A973EntSts[0];
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
            A91CueCod = T00586_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A70TipACod = T00586_A70TipACod[0];
            n70TipACod = T00586_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A970EntCodAux = T00586_A970EntCodAux[0];
            n970EntCodAux = T00586_n970EntCodAux[0];
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            ZM58175( -1) ;
         }
         pr_default.close(4);
         OnLoadActions58175( ) ;
      }

      protected void OnLoadActions58175( )
      {
      }

      protected void CheckExtendedTable58175( )
      {
         nIsDirty_175 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00584 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T00584_A860CueDsc[0];
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A70TipACod = T00584_A70TipACod[0];
         n70TipACod = T00584_n70TipACod[0];
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         pr_default.close(2);
         /* Using cursor T00585 */
         pr_default.execute(3, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A70TipACod) || String.IsNullOrEmpty(StringUtil.RTrim( A970EntCodAux)) ) )
            {
               GX_msglist.addItem("No existe 'Auxiliar'.", "ForeignKeyNotFound", 1, "ENTCODAUX");
               AnyError = 1;
               GX_FocusControl = edtEntCodAux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A971EntCodAuxDsc = T00585_A971EntCodAuxDsc[0];
         AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors58175( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A91CueCod )
      {
         /* Using cursor T00587 */
         pr_default.execute(5, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A860CueDsc = T00587_A860CueDsc[0];
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A70TipACod = T00587_A70TipACod[0];
         n70TipACod = T00587_n70TipACod[0];
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A860CueDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A70TipACod ,
                               string A970EntCodAux )
      {
         /* Using cursor T00588 */
         pr_default.execute(6, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A70TipACod) || String.IsNullOrEmpty(StringUtil.RTrim( A970EntCodAux)) ) )
            {
               GX_msglist.addItem("No existe 'Auxiliar'.", "ForeignKeyNotFound", 1, "ENTCODAUX");
               AnyError = 1;
               GX_FocusControl = edtEntCodAux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A971EntCodAuxDsc = T00588_A971EntCodAuxDsc[0];
         AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A971EntCodAuxDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey58175( )
      {
         /* Using cursor T00589 */
         pr_default.execute(7, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound175 = 1;
         }
         else
         {
            RcdFound175 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00583 */
         pr_default.execute(1, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM58175( 1) ;
            RcdFound175 = 1;
            A365EntCod = T00583_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A972EntDsc = T00583_A972EntDsc[0];
            AssignAttri("", false, "A972EntDsc", A972EntDsc);
            A969EntAbr = T00583_A969EntAbr[0];
            AssignAttri("", false, "A969EntAbr", A969EntAbr);
            A973EntSts = T00583_A973EntSts[0];
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
            A91CueCod = T00583_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A970EntCodAux = T00583_A970EntCodAux[0];
            n970EntCodAux = T00583_n970EntCodAux[0];
            AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
            Z365EntCod = A365EntCod;
            sMode175 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load58175( ) ;
            if ( AnyError == 1 )
            {
               RcdFound175 = 0;
               InitializeNonKey58175( ) ;
            }
            Gx_mode = sMode175;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound175 = 0;
            InitializeNonKey58175( ) ;
            sMode175 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode175;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey58175( ) ;
         if ( RcdFound175 == 0 )
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
         RcdFound175 = 0;
         /* Using cursor T005810 */
         pr_default.execute(8, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T005810_A365EntCod[0] < A365EntCod ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T005810_A365EntCod[0] > A365EntCod ) ) )
            {
               A365EntCod = T005810_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               RcdFound175 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound175 = 0;
         /* Using cursor T005811 */
         pr_default.execute(9, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T005811_A365EntCod[0] > A365EntCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T005811_A365EntCod[0] < A365EntCod ) ) )
            {
               A365EntCod = T005811_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               RcdFound175 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey58175( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert58175( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound175 == 1 )
            {
               if ( A365EntCod != Z365EntCod )
               {
                  A365EntCod = Z365EntCod;
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update58175( ) ;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A365EntCod != Z365EntCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert58175( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert58175( ) ;
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
         if ( A365EntCod != Z365EntCod )
         {
            A365EntCod = Z365EntCod;
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEntCod_Internalname;
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
         GetKey58175( ) ;
         if ( RcdFound175 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A365EntCod != Z365EntCod )
            {
               A365EntCod = Z365EntCod;
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
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
            if ( A365EntCod != Z365EntCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
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
         context.RollbackDataStores("tsentregas",pr_default);
         GX_FocusControl = edtEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_580( ) ;
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
         if ( RcdFound175 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart58175( ) ;
         if ( RcdFound175 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd58175( ) ;
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
         if ( RcdFound175 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEntDsc_Internalname;
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
         if ( RcdFound175 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEntDsc_Internalname;
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
         ScanStart58175( ) ;
         if ( RcdFound175 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound175 != 0 )
            {
               ScanNext58175( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtEntDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd58175( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency58175( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00582 */
            pr_default.execute(0, new Object[] {A365EntCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSENTREGAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z972EntDsc, T00582_A972EntDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z969EntAbr, T00582_A969EntAbr[0]) != 0 ) || ( Z973EntSts != T00582_A973EntSts[0] ) || ( StringUtil.StrCmp(Z91CueCod, T00582_A91CueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z970EntCodAux, T00582_A970EntCodAux[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z972EntDsc, T00582_A972EntDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsentregas:[seudo value changed for attri]"+"EntDsc");
                  GXUtil.WriteLogRaw("Old: ",Z972EntDsc);
                  GXUtil.WriteLogRaw("Current: ",T00582_A972EntDsc[0]);
               }
               if ( StringUtil.StrCmp(Z969EntAbr, T00582_A969EntAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("tsentregas:[seudo value changed for attri]"+"EntAbr");
                  GXUtil.WriteLogRaw("Old: ",Z969EntAbr);
                  GXUtil.WriteLogRaw("Current: ",T00582_A969EntAbr[0]);
               }
               if ( Z973EntSts != T00582_A973EntSts[0] )
               {
                  GXUtil.WriteLog("tsentregas:[seudo value changed for attri]"+"EntSts");
                  GXUtil.WriteLogRaw("Old: ",Z973EntSts);
                  GXUtil.WriteLogRaw("Current: ",T00582_A973EntSts[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T00582_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsentregas:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T00582_A91CueCod[0]);
               }
               if ( StringUtil.StrCmp(Z970EntCodAux, T00582_A970EntCodAux[0]) != 0 )
               {
                  GXUtil.WriteLog("tsentregas:[seudo value changed for attri]"+"EntCodAux");
                  GXUtil.WriteLogRaw("Old: ",Z970EntCodAux);
                  GXUtil.WriteLogRaw("Current: ",T00582_A970EntCodAux[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSENTREGAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert58175( )
      {
         BeforeValidate58175( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable58175( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM58175( 0) ;
            CheckOptimisticConcurrency58175( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm58175( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert58175( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005812 */
                     pr_default.execute(10, new Object[] {A365EntCod, A972EntDsc, A969EntAbr, A973EntSts, A91CueCod, n970EntCodAux, A970EntCodAux});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("TSENTREGAS");
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
                           ResetCaption580( ) ;
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
               Load58175( ) ;
            }
            EndLevel58175( ) ;
         }
         CloseExtendedTableCursors58175( ) ;
      }

      protected void Update58175( )
      {
         BeforeValidate58175( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable58175( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency58175( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm58175( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate58175( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005813 */
                     pr_default.execute(11, new Object[] {A972EntDsc, A969EntAbr, A973EntSts, A91CueCod, n970EntCodAux, A970EntCodAux, A365EntCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("TSENTREGAS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSENTREGAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate58175( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption580( ) ;
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
            EndLevel58175( ) ;
         }
         CloseExtendedTableCursors58175( ) ;
      }

      protected void DeferredUpdate58175( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate58175( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency58175( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls58175( ) ;
            AfterConfirm58175( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete58175( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005814 */
                  pr_default.execute(12, new Object[] {A365EntCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("TSENTREGAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound175 == 0 )
                        {
                           InitAll58175( ) ;
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
                        ResetCaption580( ) ;
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
         sMode175 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel58175( ) ;
         Gx_mode = sMode175;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls58175( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005815 */
            pr_default.execute(13, new Object[] {A91CueCod});
            A860CueDsc = T005815_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A70TipACod = T005815_A70TipACod[0];
            n70TipACod = T005815_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            pr_default.close(13);
            /* Using cursor T005816 */
            pr_default.execute(14, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
            A971EntCodAuxDsc = T005816_A971EntCodAuxDsc[0];
            AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005817 */
            pr_default.execute(15, new Object[] {A365EntCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005818 */
            pr_default.execute(16, new Object[] {A365EntCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel58175( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete58175( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("tsentregas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues580( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("tsentregas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart58175( )
      {
         /* Using cursor T005819 */
         pr_default.execute(17);
         RcdFound175 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound175 = 1;
            A365EntCod = T005819_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext58175( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound175 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound175 = 1;
            A365EntCod = T005819_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         }
      }

      protected void ScanEnd58175( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm58175( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert58175( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate58175( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete58175( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete58175( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate58175( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes58175( )
      {
         edtEntCod_Enabled = 0;
         AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         edtEntDsc_Enabled = 0;
         AssignProp("", false, edtEntDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntDsc_Enabled), 5, 0), true);
         edtEntAbr_Enabled = 0;
         AssignProp("", false, edtEntAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntAbr_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtCueDsc_Enabled = 0;
         AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), true);
         edtTipACod_Enabled = 0;
         AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         edtEntCodAux_Enabled = 0;
         AssignProp("", false, edtEntCodAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCodAux_Enabled), 5, 0), true);
         edtEntCodAuxDsc_Enabled = 0;
         AssignProp("", false, edtEntCodAuxDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCodAuxDsc_Enabled), 5, 0), true);
         cmbEntSts.Enabled = 0;
         AssignProp("", false, cmbEntSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEntSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes58175( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues580( )
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
         context.SendWebValue( "Entregas a Rendir") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254956", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsentregas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z972EntDsc", StringUtil.RTrim( Z972EntDsc));
         GxWebStd.gx_hidden_field( context, "Z969EntAbr", StringUtil.RTrim( Z969EntAbr));
         GxWebStd.gx_hidden_field( context, "Z973EntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z973EntSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z970EntCodAux", StringUtil.RTrim( Z970EntCodAux));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm58175( )
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
         return "TSENTREGAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entregas a Rendir" ;
      }

      protected void InitializeNonKey58175( )
      {
         A972EntDsc = "";
         AssignAttri("", false, "A972EntDsc", A972EntDsc);
         A969EntAbr = "";
         AssignAttri("", false, "A969EntAbr", A969EntAbr);
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         A860CueDsc = "";
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A70TipACod = 0;
         n70TipACod = false;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         A970EntCodAux = "";
         n970EntCodAux = false;
         AssignAttri("", false, "A970EntCodAux", A970EntCodAux);
         A971EntCodAuxDsc = "";
         AssignAttri("", false, "A971EntCodAuxDsc", A971EntCodAuxDsc);
         A973EntSts = 0;
         AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         Z972EntDsc = "";
         Z969EntAbr = "";
         Z973EntSts = 0;
         Z91CueCod = "";
         Z970EntCodAux = "";
      }

      protected void InitAll58175( )
      {
         A365EntCod = 0;
         AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         InitializeNonKey58175( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254962", true, true);
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
         context.AddJavascriptSource("tsentregas.js", "?202281810254962", false, true);
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
         edtEntCod_Internalname = "ENTCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtEntDsc_Internalname = "ENTDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtEntAbr_Internalname = "ENTABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCueCod_Internalname = "CUECOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCueDsc_Internalname = "CUEDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtTipACod_Internalname = "TIPACOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtEntCodAux_Internalname = "ENTCODAUX";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtEntCodAuxDsc_Internalname = "ENTCODAUXDSC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         cmbEntSts_Internalname = "ENTSTS";
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
         cmbEntSts_Jsonclick = "";
         cmbEntSts.Enabled = 1;
         edtEntCodAuxDsc_Jsonclick = "";
         edtEntCodAuxDsc_Enabled = 0;
         edtEntCodAux_Jsonclick = "";
         edtEntCodAux_Enabled = 1;
         edtTipACod_Jsonclick = "";
         edtTipACod_Enabled = 0;
         edtCueDsc_Jsonclick = "";
         edtCueDsc_Enabled = 0;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtEntAbr_Jsonclick = "";
         edtEntAbr_Enabled = 1;
         edtEntDsc_Jsonclick = "";
         edtEntDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtEntCod_Jsonclick = "";
         edtEntCod_Enabled = 1;
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
         cmbEntSts.Name = "ENTSTS";
         cmbEntSts.WebTags = "";
         cmbEntSts.addItem("1", "ACTIVO", 0);
         cmbEntSts.addItem("0", "INACTIVO", 0);
         if ( cmbEntSts.ItemCount > 0 )
         {
            A973EntSts = (short)(NumberUtil.Val( cmbEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0))), "."));
            AssignAttri("", false, "A973EntSts", StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtEntDsc_Internalname;
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

      public void Valid_Entcod( )
      {
         A973EntSts = (short)(NumberUtil.Val( cmbEntSts.CurrentValue, "."));
         cmbEntSts.CurrentValue = StringUtil.Str( (decimal)(A973EntSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbEntSts.ItemCount > 0 )
         {
            A973EntSts = (short)(NumberUtil.Val( cmbEntSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0))), "."));
            cmbEntSts.CurrentValue = StringUtil.Str( (decimal)(A973EntSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A972EntDsc", StringUtil.RTrim( A972EntDsc));
         AssignAttri("", false, "A969EntAbr", StringUtil.RTrim( A969EntAbr));
         AssignAttri("", false, "A91CueCod", StringUtil.RTrim( A91CueCod));
         AssignAttri("", false, "A970EntCodAux", StringUtil.RTrim( A970EntCodAux));
         AssignAttri("", false, "A973EntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A973EntSts), 1, 0, ".", "")));
         cmbEntSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A973EntSts), 1, 0));
         AssignProp("", false, cmbEntSts_Internalname, "Values", cmbEntSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
         AssignAttri("", false, "A70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
         AssignAttri("", false, "A971EntCodAuxDsc", StringUtil.RTrim( A971EntCodAuxDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z972EntDsc", StringUtil.RTrim( Z972EntDsc));
         GxWebStd.gx_hidden_field( context, "Z969EntAbr", StringUtil.RTrim( Z969EntAbr));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z970EntCodAux", StringUtil.RTrim( Z970EntCodAux));
         GxWebStd.gx_hidden_field( context, "Z973EntSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z973EntSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z860CueDsc", StringUtil.RTrim( Z860CueDsc));
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z971EntCodAuxDsc", StringUtil.RTrim( Z971EntCodAuxDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         n70TipACod = false;
         /* Using cursor T005815 */
         pr_default.execute(13, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         A860CueDsc = T005815_A860CueDsc[0];
         A70TipACod = T005815_A70TipACod[0];
         n70TipACod = T005815_n70TipACod[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
         AssignAttri("", false, "A70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
      }

      public void Valid_Entcodaux( )
      {
         n70TipACod = false;
         n970EntCodAux = false;
         /* Using cursor T005816 */
         pr_default.execute(14, new Object[] {n70TipACod, A70TipACod, n970EntCodAux, A970EntCodAux});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A70TipACod) || String.IsNullOrEmpty(StringUtil.RTrim( A970EntCodAux)) ) )
            {
               GX_msglist.addItem("No existe 'Auxiliar'.", "ForeignKeyNotFound", 1, "ENTCODAUX");
               AnyError = 1;
               GX_FocusControl = edtEntCodAux_Internalname;
            }
         }
         A971EntCodAuxDsc = T005816_A971EntCodAuxDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A971EntCodAuxDsc", StringUtil.RTrim( A971EntCodAuxDsc));
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
         setEventMetadata("VALID_ENTCOD","{handler:'Valid_Entcod',iparms:[{av:'cmbEntSts'},{av:'A973EntSts',fld:'ENTSTS',pic:'9'},{av:'A365EntCod',fld:'ENTCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ENTCOD",",oparms:[{av:'A972EntDsc',fld:'ENTDSC',pic:''},{av:'A969EntAbr',fld:'ENTABR',pic:''},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A970EntCodAux',fld:'ENTCODAUX',pic:''},{av:'cmbEntSts'},{av:'A973EntSts',fld:'ENTSTS',pic:'9'},{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'},{av:'A971EntCodAuxDsc',fld:'ENTCODAUXDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z365EntCod'},{av:'Z972EntDsc'},{av:'Z969EntAbr'},{av:'Z91CueCod'},{av:'Z970EntCodAux'},{av:'Z973EntSts'},{av:'Z860CueDsc'},{av:'Z70TipACod'},{av:'Z971EntCodAuxDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
         setEventMetadata("VALID_ENTCODAUX","{handler:'Valid_Entcodaux',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'},{av:'A970EntCodAux',fld:'ENTCODAUX',pic:''},{av:'A971EntCodAuxDsc',fld:'ENTCODAUXDSC',pic:''}]");
         setEventMetadata("VALID_ENTCODAUX",",oparms:[{av:'A971EntCodAuxDsc',fld:'ENTCODAUXDSC',pic:''}]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z972EntDsc = "";
         Z969EntAbr = "";
         Z91CueCod = "";
         Z970EntCodAux = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A91CueCod = "";
         A970EntCodAux = "";
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
         A972EntDsc = "";
         lblTextblock3_Jsonclick = "";
         A969EntAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A860CueDsc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A971EntCodAuxDsc = "";
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
         Z860CueDsc = "";
         Z971EntCodAuxDsc = "";
         T00586_A365EntCod = new int[1] ;
         T00586_A972EntDsc = new string[] {""} ;
         T00586_A969EntAbr = new string[] {""} ;
         T00586_A860CueDsc = new string[] {""} ;
         T00586_A971EntCodAuxDsc = new string[] {""} ;
         T00586_A973EntSts = new short[1] ;
         T00586_A91CueCod = new string[] {""} ;
         T00586_A70TipACod = new int[1] ;
         T00586_n70TipACod = new bool[] {false} ;
         T00586_A970EntCodAux = new string[] {""} ;
         T00586_n970EntCodAux = new bool[] {false} ;
         T00584_A860CueDsc = new string[] {""} ;
         T00584_A70TipACod = new int[1] ;
         T00584_n70TipACod = new bool[] {false} ;
         T00585_A971EntCodAuxDsc = new string[] {""} ;
         T00587_A860CueDsc = new string[] {""} ;
         T00587_A70TipACod = new int[1] ;
         T00587_n70TipACod = new bool[] {false} ;
         T00588_A971EntCodAuxDsc = new string[] {""} ;
         T00589_A365EntCod = new int[1] ;
         T00583_A365EntCod = new int[1] ;
         T00583_A972EntDsc = new string[] {""} ;
         T00583_A969EntAbr = new string[] {""} ;
         T00583_A973EntSts = new short[1] ;
         T00583_A91CueCod = new string[] {""} ;
         T00583_A970EntCodAux = new string[] {""} ;
         T00583_n970EntCodAux = new bool[] {false} ;
         sMode175 = "";
         T005810_A365EntCod = new int[1] ;
         T005811_A365EntCod = new int[1] ;
         T00582_A365EntCod = new int[1] ;
         T00582_A972EntDsc = new string[] {""} ;
         T00582_A969EntAbr = new string[] {""} ;
         T00582_A973EntSts = new short[1] ;
         T00582_A91CueCod = new string[] {""} ;
         T00582_A970EntCodAux = new string[] {""} ;
         T00582_n970EntCodAux = new bool[] {false} ;
         T005815_A860CueDsc = new string[] {""} ;
         T005815_A70TipACod = new int[1] ;
         T005815_n70TipACod = new bool[] {false} ;
         T005816_A971EntCodAuxDsc = new string[] {""} ;
         T005817_A365EntCod = new int[1] ;
         T005817_A403MVLEntCod = new string[] {""} ;
         T005817_A404MVLEITem = new int[1] ;
         T005818_A365EntCod = new int[1] ;
         T005818_A366AperEntCod = new string[] {""} ;
         T005819_A365EntCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ972EntDsc = "";
         ZZ969EntAbr = "";
         ZZ91CueCod = "";
         ZZ970EntCodAux = "";
         ZZ860CueDsc = "";
         ZZ971EntCodAuxDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsentregas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsentregas__default(),
            new Object[][] {
                new Object[] {
               T00582_A365EntCod, T00582_A972EntDsc, T00582_A969EntAbr, T00582_A973EntSts, T00582_A91CueCod, T00582_A970EntCodAux, T00582_n970EntCodAux
               }
               , new Object[] {
               T00583_A365EntCod, T00583_A972EntDsc, T00583_A969EntAbr, T00583_A973EntSts, T00583_A91CueCod, T00583_A970EntCodAux, T00583_n970EntCodAux
               }
               , new Object[] {
               T00584_A860CueDsc, T00584_A70TipACod, T00584_n70TipACod
               }
               , new Object[] {
               T00585_A971EntCodAuxDsc
               }
               , new Object[] {
               T00586_A365EntCod, T00586_A972EntDsc, T00586_A969EntAbr, T00586_A860CueDsc, T00586_A971EntCodAuxDsc, T00586_A973EntSts, T00586_A91CueCod, T00586_A70TipACod, T00586_n70TipACod, T00586_A970EntCodAux,
               T00586_n970EntCodAux
               }
               , new Object[] {
               T00587_A860CueDsc, T00587_A70TipACod, T00587_n70TipACod
               }
               , new Object[] {
               T00588_A971EntCodAuxDsc
               }
               , new Object[] {
               T00589_A365EntCod
               }
               , new Object[] {
               T005810_A365EntCod
               }
               , new Object[] {
               T005811_A365EntCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005815_A860CueDsc, T005815_A70TipACod, T005815_n70TipACod
               }
               , new Object[] {
               T005816_A971EntCodAuxDsc
               }
               , new Object[] {
               T005817_A365EntCod, T005817_A403MVLEntCod, T005817_A404MVLEITem
               }
               , new Object[] {
               T005818_A365EntCod, T005818_A366AperEntCod
               }
               , new Object[] {
               T005819_A365EntCod
               }
            }
         );
      }

      private short Z973EntSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A973EntSts ;
      private short GX_JID ;
      private short RcdFound175 ;
      private short nIsDirty_175 ;
      private short Gx_BScreen ;
      private short ZZ973EntSts ;
      private int Z365EntCod ;
      private int A70TipACod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A365EntCod ;
      private int edtEntCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtEntDsc_Enabled ;
      private int edtEntAbr_Enabled ;
      private int edtCueCod_Enabled ;
      private int edtCueDsc_Enabled ;
      private int edtTipACod_Enabled ;
      private int edtEntCodAux_Enabled ;
      private int edtEntCodAuxDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z70TipACod ;
      private int idxLst ;
      private int ZZ365EntCod ;
      private int ZZ70TipACod ;
      private string sPrefix ;
      private string Z972EntDsc ;
      private string Z969EntAbr ;
      private string Z91CueCod ;
      private string Z970EntCodAux ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A91CueCod ;
      private string A970EntCodAux ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEntCod_Internalname ;
      private string cmbEntSts_Internalname ;
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
      private string edtEntCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtEntDsc_Internalname ;
      private string A972EntDsc ;
      private string edtEntDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtEntAbr_Internalname ;
      private string A969EntAbr ;
      private string edtEntAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCueDsc_Internalname ;
      private string A860CueDsc ;
      private string edtCueDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtTipACod_Internalname ;
      private string edtTipACod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtEntCodAux_Internalname ;
      private string edtEntCodAux_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtEntCodAuxDsc_Internalname ;
      private string A971EntCodAuxDsc ;
      private string edtEntCodAuxDsc_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string cmbEntSts_Jsonclick ;
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
      private string Z860CueDsc ;
      private string Z971EntCodAuxDsc ;
      private string sMode175 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ972EntDsc ;
      private string ZZ969EntAbr ;
      private string ZZ91CueCod ;
      private string ZZ970EntCodAux ;
      private string ZZ860CueDsc ;
      private string ZZ971EntCodAuxDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n70TipACod ;
      private bool n970EntCodAux ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbEntSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00586_A365EntCod ;
      private string[] T00586_A972EntDsc ;
      private string[] T00586_A969EntAbr ;
      private string[] T00586_A860CueDsc ;
      private string[] T00586_A971EntCodAuxDsc ;
      private short[] T00586_A973EntSts ;
      private string[] T00586_A91CueCod ;
      private int[] T00586_A70TipACod ;
      private bool[] T00586_n70TipACod ;
      private string[] T00586_A970EntCodAux ;
      private bool[] T00586_n970EntCodAux ;
      private string[] T00584_A860CueDsc ;
      private int[] T00584_A70TipACod ;
      private bool[] T00584_n70TipACod ;
      private string[] T00585_A971EntCodAuxDsc ;
      private string[] T00587_A860CueDsc ;
      private int[] T00587_A70TipACod ;
      private bool[] T00587_n70TipACod ;
      private string[] T00588_A971EntCodAuxDsc ;
      private int[] T00589_A365EntCod ;
      private int[] T00583_A365EntCod ;
      private string[] T00583_A972EntDsc ;
      private string[] T00583_A969EntAbr ;
      private short[] T00583_A973EntSts ;
      private string[] T00583_A91CueCod ;
      private string[] T00583_A970EntCodAux ;
      private bool[] T00583_n970EntCodAux ;
      private int[] T005810_A365EntCod ;
      private int[] T005811_A365EntCod ;
      private int[] T00582_A365EntCod ;
      private string[] T00582_A972EntDsc ;
      private string[] T00582_A969EntAbr ;
      private short[] T00582_A973EntSts ;
      private string[] T00582_A91CueCod ;
      private string[] T00582_A970EntCodAux ;
      private bool[] T00582_n970EntCodAux ;
      private string[] T005815_A860CueDsc ;
      private int[] T005815_A70TipACod ;
      private bool[] T005815_n70TipACod ;
      private string[] T005816_A971EntCodAuxDsc ;
      private int[] T005817_A365EntCod ;
      private string[] T005817_A403MVLEntCod ;
      private int[] T005817_A404MVLEITem ;
      private int[] T005818_A365EntCod ;
      private string[] T005818_A366AperEntCod ;
      private int[] T005819_A365EntCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class tsentregas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsentregas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00586;
        prmT00586 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT00584;
        prmT00584 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00585;
        prmT00585 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00587;
        prmT00587 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00588;
        prmT00588 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00589;
        prmT00589 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT00583;
        prmT00583 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005810;
        prmT005810 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005811;
        prmT005811 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT00582;
        prmT00582 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005812;
        prmT005812 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@EntDsc",GXType.NChar,100,0) ,
        new ParDef("@EntAbr",GXType.NChar,5,0) ,
        new ParDef("@EntSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005813;
        prmT005813 = new Object[] {
        new ParDef("@EntDsc",GXType.NChar,100,0) ,
        new ParDef("@EntAbr",GXType.NChar,5,0) ,
        new ParDef("@EntSts",GXType.Int16,1,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005814;
        prmT005814 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005817;
        prmT005817 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005818;
        prmT005818 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005819;
        prmT005819 = new Object[] {
        };
        Object[] prmT005815;
        prmT005815 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT005816;
        prmT005816 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCodAux",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00582", "SELECT [EntCod], [EntDsc], [EntAbr], [EntSts], [CueCod], [EntCodAux] AS EntCodAux FROM [TSENTREGAS] WITH (UPDLOCK) WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00582,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00583", "SELECT [EntCod], [EntDsc], [EntAbr], [EntSts], [CueCod], [EntCodAux] AS EntCodAux FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00583,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00584", "SELECT [CueDsc], [TipACod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00584,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00585", "SELECT [TipADDsc] AS EntCodAuxDsc FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @EntCodAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT00585,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00586", "SELECT TM1.[EntCod], TM1.[EntDsc], TM1.[EntAbr], T2.[CueDsc], T3.[TipADDsc] AS EntCodAuxDsc, TM1.[EntSts], TM1.[CueCod], T2.[TipACod], TM1.[EntCodAux] AS EntCodAux FROM (([TSENTREGAS] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CueCod]) LEFT JOIN [CBAUXILIARES] T3 ON T3.[TipACod] = T2.[TipACod] AND T3.[TipADCod] = TM1.[EntCodAux]) WHERE TM1.[EntCod] = @EntCod ORDER BY TM1.[EntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00586,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00587", "SELECT [CueDsc], [TipACod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00587,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00588", "SELECT [TipADDsc] AS EntCodAuxDsc FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @EntCodAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT00588,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00589", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00589,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005810", "SELECT TOP 1 [EntCod] FROM [TSENTREGAS] WHERE ( [EntCod] > @EntCod) ORDER BY [EntCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005811", "SELECT TOP 1 [EntCod] FROM [TSENTREGAS] WHERE ( [EntCod] < @EntCod) ORDER BY [EntCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005812", "INSERT INTO [TSENTREGAS]([EntCod], [EntDsc], [EntAbr], [EntSts], [CueCod], [EntCodAux]) VALUES(@EntCod, @EntDsc, @EntAbr, @EntSts, @CueCod, @EntCodAux)", GxErrorMask.GX_NOMASK,prmT005812)
           ,new CursorDef("T005813", "UPDATE [TSENTREGAS] SET [EntDsc]=@EntDsc, [EntAbr]=@EntAbr, [EntSts]=@EntSts, [CueCod]=@CueCod, [EntCodAux]=@EntCodAux  WHERE [EntCod] = @EntCod", GxErrorMask.GX_NOMASK,prmT005813)
           ,new CursorDef("T005814", "DELETE FROM [TSENTREGAS]  WHERE [EntCod] = @EntCod", GxErrorMask.GX_NOMASK,prmT005814)
           ,new CursorDef("T005815", "SELECT [CueDsc], [TipACod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005816", "SELECT [TipADDsc] AS EntCodAuxDsc FROM [CBAUXILIARES] WHERE [TipACod] = @TipACod AND [TipADCod] = @EntCodAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT005816,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005817", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005817,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005818", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005818,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005819", "SELECT [EntCod] FROM [TSENTREGAS] ORDER BY [EntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005819,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
