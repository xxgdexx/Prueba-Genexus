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
   public class cchoferes : GXHttpHandler
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
            Form.Meta.addItem("description", "Choferes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cchoferes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cchoferes( IGxContext context )
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
         cmbChoSts = new GXCombobox();
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
         if ( cmbChoSts.ItemCount > 0 )
         {
            A549ChoSts = (short)(NumberUtil.Val( cmbChoSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0))), "."));
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChoSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
            AssignProp("", false, cmbChoSts_Internalname, "Values", cmbChoSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm2574( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CCHOFERES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Chofer", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ChoCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtChoCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Chofer", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoDsc_Internalname, StringUtil.RTrim( A542ChoDsc), StringUtil.RTrim( context.localUtil.Format( A542ChoDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Dirección", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoDir_Internalname, StringUtil.RTrim( A545ChoDir), StringUtil.RTrim( context.localUtil.Format( A545ChoDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Telefono", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoTel_Internalname, StringUtil.RTrim( A550ChoTel), StringUtil.RTrim( context.localUtil.Format( A550ChoTel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoTel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoTel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "R.U.C.", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoRuc_Internalname, StringUtil.RTrim( A548ChoRuc), StringUtil.RTrim( context.localUtil.Format( A548ChoRuc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoRuc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoRuc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Marca", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoMarca_Internalname, StringUtil.RTrim( A547ChoMarca), StringUtil.RTrim( context.localUtil.Format( A547ChoMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoMarca_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Placa", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoPlaca_Internalname, StringUtil.RTrim( A543ChoPlaca), StringUtil.RTrim( context.localUtil.Format( A543ChoPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoPlaca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "N° Licencia", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoLicencia_Internalname, StringUtil.RTrim( A546ChoLicencia), StringUtil.RTrim( context.localUtil.Format( A546ChoLicencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoLicencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoLicencia_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "N° Constancia", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoConsta_Internalname, StringUtil.RTrim( A544ChoConsta), StringUtil.RTrim( context.localUtil.Format( A544ChoConsta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoConsta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoConsta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Estado", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CCHOFERES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbChoSts, cmbChoSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0)), 1, cmbChoSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbChoSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 1, "HLP_CCHOFERES.htm");
         cmbChoSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         AssignProp("", false, cmbChoSts_Internalname, "Values", (string)(cmbChoSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CCHOFERES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CCHOFERES.htm");
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
            Z10ChoCod = (int)(context.localUtil.CToN( cgiGet( "Z10ChoCod"), ".", ","));
            Z542ChoDsc = cgiGet( "Z542ChoDsc");
            Z545ChoDir = cgiGet( "Z545ChoDir");
            Z550ChoTel = cgiGet( "Z550ChoTel");
            Z548ChoRuc = cgiGet( "Z548ChoRuc");
            Z547ChoMarca = cgiGet( "Z547ChoMarca");
            Z543ChoPlaca = cgiGet( "Z543ChoPlaca");
            Z546ChoLicencia = cgiGet( "Z546ChoLicencia");
            Z544ChoConsta = cgiGet( "Z544ChoConsta");
            Z549ChoSts = (short)(context.localUtil.CToN( cgiGet( "Z549ChoSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A541ChoCompleto = cgiGet( "CHOCOMPLETO");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHOCOD");
               AnyError = 1;
               GX_FocusControl = edtChoCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10ChoCod = 0;
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            }
            else
            {
               A10ChoCod = (int)(context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ","));
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            }
            A542ChoDsc = cgiGet( edtChoDsc_Internalname);
            AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
            A545ChoDir = cgiGet( edtChoDir_Internalname);
            AssignAttri("", false, "A545ChoDir", A545ChoDir);
            A550ChoTel = cgiGet( edtChoTel_Internalname);
            AssignAttri("", false, "A550ChoTel", A550ChoTel);
            A548ChoRuc = cgiGet( edtChoRuc_Internalname);
            AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
            A547ChoMarca = cgiGet( edtChoMarca_Internalname);
            AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
            A543ChoPlaca = cgiGet( edtChoPlaca_Internalname);
            AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
            A546ChoLicencia = cgiGet( edtChoLicencia_Internalname);
            AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
            A544ChoConsta = cgiGet( edtChoConsta_Internalname);
            AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
            cmbChoSts.CurrentValue = cgiGet( cmbChoSts_Internalname);
            A549ChoSts = (short)(NumberUtil.Val( cgiGet( cmbChoSts_Internalname), "."));
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
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
               A10ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
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
               InitAll2574( ) ;
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
         DisableAttributes2574( ) ;
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

      protected void CONFIRM_250( )
      {
         BeforeValidate2574( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2574( ) ;
            }
            else
            {
               CheckExtendedTable2574( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2574( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues250( ) ;
         }
      }

      protected void ResetCaption250( )
      {
      }

      protected void ZM2574( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z542ChoDsc = T00253_A542ChoDsc[0];
               Z545ChoDir = T00253_A545ChoDir[0];
               Z550ChoTel = T00253_A550ChoTel[0];
               Z548ChoRuc = T00253_A548ChoRuc[0];
               Z547ChoMarca = T00253_A547ChoMarca[0];
               Z543ChoPlaca = T00253_A543ChoPlaca[0];
               Z546ChoLicencia = T00253_A546ChoLicencia[0];
               Z544ChoConsta = T00253_A544ChoConsta[0];
               Z549ChoSts = T00253_A549ChoSts[0];
            }
            else
            {
               Z542ChoDsc = A542ChoDsc;
               Z545ChoDir = A545ChoDir;
               Z550ChoTel = A550ChoTel;
               Z548ChoRuc = A548ChoRuc;
               Z547ChoMarca = A547ChoMarca;
               Z543ChoPlaca = A543ChoPlaca;
               Z546ChoLicencia = A546ChoLicencia;
               Z544ChoConsta = A544ChoConsta;
               Z549ChoSts = A549ChoSts;
            }
         }
         if ( GX_JID == -2 )
         {
            Z10ChoCod = A10ChoCod;
            Z542ChoDsc = A542ChoDsc;
            Z545ChoDir = A545ChoDir;
            Z550ChoTel = A550ChoTel;
            Z548ChoRuc = A548ChoRuc;
            Z547ChoMarca = A547ChoMarca;
            Z543ChoPlaca = A543ChoPlaca;
            Z546ChoLicencia = A546ChoLicencia;
            Z544ChoConsta = A544ChoConsta;
            Z549ChoSts = A549ChoSts;
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

      protected void Load2574( )
      {
         /* Using cursor T00254 */
         pr_default.execute(2, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound74 = 1;
            A542ChoDsc = T00254_A542ChoDsc[0];
            AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
            A545ChoDir = T00254_A545ChoDir[0];
            AssignAttri("", false, "A545ChoDir", A545ChoDir);
            A550ChoTel = T00254_A550ChoTel[0];
            AssignAttri("", false, "A550ChoTel", A550ChoTel);
            A548ChoRuc = T00254_A548ChoRuc[0];
            AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
            A547ChoMarca = T00254_A547ChoMarca[0];
            AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
            A543ChoPlaca = T00254_A543ChoPlaca[0];
            AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
            A546ChoLicencia = T00254_A546ChoLicencia[0];
            AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
            A544ChoConsta = T00254_A544ChoConsta[0];
            AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
            A549ChoSts = T00254_A549ChoSts[0];
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
            ZM2574( -2) ;
         }
         pr_default.close(2);
         OnLoadActions2574( ) ;
      }

      protected void OnLoadActions2574( )
      {
         A541ChoCompleto = StringUtil.Trim( A542ChoDsc) + " " + StringUtil.Trim( A543ChoPlaca);
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
      }

      protected void CheckExtendedTable2574( )
      {
         nIsDirty_74 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         nIsDirty_74 = 1;
         A541ChoCompleto = StringUtil.Trim( A542ChoDsc) + " " + StringUtil.Trim( A543ChoPlaca);
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
      }

      protected void CloseExtendedTableCursors2574( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2574( )
      {
         /* Using cursor T00255 */
         pr_default.execute(3, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00253 */
         pr_default.execute(1, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2574( 2) ;
            RcdFound74 = 1;
            A10ChoCod = T00253_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            A542ChoDsc = T00253_A542ChoDsc[0];
            AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
            A545ChoDir = T00253_A545ChoDir[0];
            AssignAttri("", false, "A545ChoDir", A545ChoDir);
            A550ChoTel = T00253_A550ChoTel[0];
            AssignAttri("", false, "A550ChoTel", A550ChoTel);
            A548ChoRuc = T00253_A548ChoRuc[0];
            AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
            A547ChoMarca = T00253_A547ChoMarca[0];
            AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
            A543ChoPlaca = T00253_A543ChoPlaca[0];
            AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
            A546ChoLicencia = T00253_A546ChoLicencia[0];
            AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
            A544ChoConsta = T00253_A544ChoConsta[0];
            AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
            A549ChoSts = T00253_A549ChoSts[0];
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
            Z10ChoCod = A10ChoCod;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2574( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey2574( ) ;
            }
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey2574( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2574( ) ;
         if ( RcdFound74 == 0 )
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
         RcdFound74 = 0;
         /* Using cursor T00256 */
         pr_default.execute(4, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00256_A10ChoCod[0] < A10ChoCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00256_A10ChoCod[0] > A10ChoCod ) ) )
            {
               A10ChoCod = T00256_A10ChoCod[0];
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound74 = 0;
         /* Using cursor T00257 */
         pr_default.execute(5, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00257_A10ChoCod[0] > A10ChoCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00257_A10ChoCod[0] < A10ChoCod ) ) )
            {
               A10ChoCod = T00257_A10ChoCod[0];
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2574( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2574( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A10ChoCod != Z10ChoCod )
               {
                  A10ChoCod = Z10ChoCod;
                  AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CHOCOD");
                  AnyError = 1;
                  GX_FocusControl = edtChoCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtChoCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2574( ) ;
                  GX_FocusControl = edtChoCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A10ChoCod != Z10ChoCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtChoCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2574( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHOCOD");
                     AnyError = 1;
                     GX_FocusControl = edtChoCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtChoCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2574( ) ;
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
         if ( A10ChoCod != Z10ChoCod )
         {
            A10ChoCod = Z10ChoCod;
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtChoCod_Internalname;
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
         GetKey2574( ) ;
         if ( RcdFound74 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CHOCOD");
               AnyError = 1;
               GX_FocusControl = edtChoCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A10ChoCod != Z10ChoCod )
            {
               A10ChoCod = Z10ChoCod;
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CHOCOD");
               AnyError = 1;
               GX_FocusControl = edtChoCod_Internalname;
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
            if ( A10ChoCod != Z10ChoCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHOCOD");
                  AnyError = 1;
                  GX_FocusControl = edtChoCod_Internalname;
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
         context.RollbackDataStores("cchoferes",pr_default);
         GX_FocusControl = edtChoDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_250( ) ;
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
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtChoDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2574( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtChoDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2574( ) ;
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
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtChoDsc_Internalname;
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
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtChoDsc_Internalname;
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
         ScanStart2574( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound74 != 0 )
            {
               ScanNext2574( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtChoDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2574( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2574( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00252 */
            pr_default.execute(0, new Object[] {A10ChoCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCHOFERES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z542ChoDsc, T00252_A542ChoDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z545ChoDir, T00252_A545ChoDir[0]) != 0 ) || ( StringUtil.StrCmp(Z550ChoTel, T00252_A550ChoTel[0]) != 0 ) || ( StringUtil.StrCmp(Z548ChoRuc, T00252_A548ChoRuc[0]) != 0 ) || ( StringUtil.StrCmp(Z547ChoMarca, T00252_A547ChoMarca[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z543ChoPlaca, T00252_A543ChoPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z546ChoLicencia, T00252_A546ChoLicencia[0]) != 0 ) || ( StringUtil.StrCmp(Z544ChoConsta, T00252_A544ChoConsta[0]) != 0 ) || ( Z549ChoSts != T00252_A549ChoSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z542ChoDsc, T00252_A542ChoDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoDsc");
                  GXUtil.WriteLogRaw("Old: ",Z542ChoDsc);
                  GXUtil.WriteLogRaw("Current: ",T00252_A542ChoDsc[0]);
               }
               if ( StringUtil.StrCmp(Z545ChoDir, T00252_A545ChoDir[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoDir");
                  GXUtil.WriteLogRaw("Old: ",Z545ChoDir);
                  GXUtil.WriteLogRaw("Current: ",T00252_A545ChoDir[0]);
               }
               if ( StringUtil.StrCmp(Z550ChoTel, T00252_A550ChoTel[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoTel");
                  GXUtil.WriteLogRaw("Old: ",Z550ChoTel);
                  GXUtil.WriteLogRaw("Current: ",T00252_A550ChoTel[0]);
               }
               if ( StringUtil.StrCmp(Z548ChoRuc, T00252_A548ChoRuc[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoRuc");
                  GXUtil.WriteLogRaw("Old: ",Z548ChoRuc);
                  GXUtil.WriteLogRaw("Current: ",T00252_A548ChoRuc[0]);
               }
               if ( StringUtil.StrCmp(Z547ChoMarca, T00252_A547ChoMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoMarca");
                  GXUtil.WriteLogRaw("Old: ",Z547ChoMarca);
                  GXUtil.WriteLogRaw("Current: ",T00252_A547ChoMarca[0]);
               }
               if ( StringUtil.StrCmp(Z543ChoPlaca, T00252_A543ChoPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z543ChoPlaca);
                  GXUtil.WriteLogRaw("Current: ",T00252_A543ChoPlaca[0]);
               }
               if ( StringUtil.StrCmp(Z546ChoLicencia, T00252_A546ChoLicencia[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoLicencia");
                  GXUtil.WriteLogRaw("Old: ",Z546ChoLicencia);
                  GXUtil.WriteLogRaw("Current: ",T00252_A546ChoLicencia[0]);
               }
               if ( StringUtil.StrCmp(Z544ChoConsta, T00252_A544ChoConsta[0]) != 0 )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoConsta");
                  GXUtil.WriteLogRaw("Old: ",Z544ChoConsta);
                  GXUtil.WriteLogRaw("Current: ",T00252_A544ChoConsta[0]);
               }
               if ( Z549ChoSts != T00252_A549ChoSts[0] )
               {
                  GXUtil.WriteLog("cchoferes:[seudo value changed for attri]"+"ChoSts");
                  GXUtil.WriteLogRaw("Old: ",Z549ChoSts);
                  GXUtil.WriteLogRaw("Current: ",T00252_A549ChoSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CCHOFERES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2574( )
      {
         BeforeValidate2574( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2574( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2574( 0) ;
            CheckOptimisticConcurrency2574( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2574( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2574( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00258 */
                     pr_default.execute(6, new Object[] {A10ChoCod, A542ChoDsc, A545ChoDir, A550ChoTel, A548ChoRuc, A547ChoMarca, A543ChoPlaca, A546ChoLicencia, A544ChoConsta, A549ChoSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CCHOFERES");
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
                           ResetCaption250( ) ;
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
               Load2574( ) ;
            }
            EndLevel2574( ) ;
         }
         CloseExtendedTableCursors2574( ) ;
      }

      protected void Update2574( )
      {
         BeforeValidate2574( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2574( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2574( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2574( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2574( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00259 */
                     pr_default.execute(7, new Object[] {A542ChoDsc, A545ChoDir, A550ChoTel, A548ChoRuc, A547ChoMarca, A543ChoPlaca, A546ChoLicencia, A544ChoConsta, A549ChoSts, A10ChoCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CCHOFERES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CCHOFERES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2574( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption250( ) ;
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
            EndLevel2574( ) ;
         }
         CloseExtendedTableCursors2574( ) ;
      }

      protected void DeferredUpdate2574( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2574( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2574( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2574( ) ;
            AfterConfirm2574( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2574( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002510 */
                  pr_default.execute(8, new Object[] {A10ChoCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CCHOFERES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound74 == 0 )
                        {
                           InitAll2574( ) ;
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
                        ResetCaption250( ) ;
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2574( ) ;
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2574( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A541ChoCompleto = StringUtil.Trim( A542ChoDsc) + " " + StringUtil.Trim( A543ChoPlaca);
            AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002511 */
            pr_default.execute(9, new Object[] {A10ChoCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T002512 */
            pr_default.execute(10, new Object[] {A10ChoCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Despacho"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel2574( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2574( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cchoferes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues250( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cchoferes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2574( )
      {
         /* Using cursor T002513 */
         pr_default.execute(11);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A10ChoCod = T002513_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2574( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A10ChoCod = T002513_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         }
      }

      protected void ScanEnd2574( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2574( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2574( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2574( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2574( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2574( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2574( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2574( )
      {
         edtChoCod_Enabled = 0;
         AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
         edtChoDsc_Enabled = 0;
         AssignProp("", false, edtChoDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoDsc_Enabled), 5, 0), true);
         edtChoDir_Enabled = 0;
         AssignProp("", false, edtChoDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoDir_Enabled), 5, 0), true);
         edtChoTel_Enabled = 0;
         AssignProp("", false, edtChoTel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoTel_Enabled), 5, 0), true);
         edtChoRuc_Enabled = 0;
         AssignProp("", false, edtChoRuc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoRuc_Enabled), 5, 0), true);
         edtChoMarca_Enabled = 0;
         AssignProp("", false, edtChoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoMarca_Enabled), 5, 0), true);
         edtChoPlaca_Enabled = 0;
         AssignProp("", false, edtChoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoPlaca_Enabled), 5, 0), true);
         edtChoLicencia_Enabled = 0;
         AssignProp("", false, edtChoLicencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoLicencia_Enabled), 5, 0), true);
         edtChoConsta_Enabled = 0;
         AssignProp("", false, edtChoConsta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoConsta_Enabled), 5, 0), true);
         cmbChoSts.Enabled = 0;
         AssignProp("", false, cmbChoSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbChoSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2574( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues250( )
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
         context.SendWebValue( "Choferes") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242069", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cchoferes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z542ChoDsc", StringUtil.RTrim( Z542ChoDsc));
         GxWebStd.gx_hidden_field( context, "Z545ChoDir", StringUtil.RTrim( Z545ChoDir));
         GxWebStd.gx_hidden_field( context, "Z550ChoTel", StringUtil.RTrim( Z550ChoTel));
         GxWebStd.gx_hidden_field( context, "Z548ChoRuc", StringUtil.RTrim( Z548ChoRuc));
         GxWebStd.gx_hidden_field( context, "Z547ChoMarca", StringUtil.RTrim( Z547ChoMarca));
         GxWebStd.gx_hidden_field( context, "Z543ChoPlaca", StringUtil.RTrim( Z543ChoPlaca));
         GxWebStd.gx_hidden_field( context, "Z546ChoLicencia", StringUtil.RTrim( Z546ChoLicencia));
         GxWebStd.gx_hidden_field( context, "Z544ChoConsta", StringUtil.RTrim( Z544ChoConsta));
         GxWebStd.gx_hidden_field( context, "Z549ChoSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z549ChoSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CHOCOMPLETO", A541ChoCompleto);
      }

      protected void RenderHtmlCloseForm2574( )
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
         return "CCHOFERES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Choferes" ;
      }

      protected void InitializeNonKey2574( )
      {
         A541ChoCompleto = "";
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
         A542ChoDsc = "";
         AssignAttri("", false, "A542ChoDsc", A542ChoDsc);
         A545ChoDir = "";
         AssignAttri("", false, "A545ChoDir", A545ChoDir);
         A550ChoTel = "";
         AssignAttri("", false, "A550ChoTel", A550ChoTel);
         A548ChoRuc = "";
         AssignAttri("", false, "A548ChoRuc", A548ChoRuc);
         A547ChoMarca = "";
         AssignAttri("", false, "A547ChoMarca", A547ChoMarca);
         A543ChoPlaca = "";
         AssignAttri("", false, "A543ChoPlaca", A543ChoPlaca);
         A546ChoLicencia = "";
         AssignAttri("", false, "A546ChoLicencia", A546ChoLicencia);
         A544ChoConsta = "";
         AssignAttri("", false, "A544ChoConsta", A544ChoConsta);
         A549ChoSts = 0;
         AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         Z542ChoDsc = "";
         Z545ChoDir = "";
         Z550ChoTel = "";
         Z548ChoRuc = "";
         Z547ChoMarca = "";
         Z543ChoPlaca = "";
         Z546ChoLicencia = "";
         Z544ChoConsta = "";
         Z549ChoSts = 0;
      }

      protected void InitAll2574( )
      {
         A10ChoCod = 0;
         AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         InitializeNonKey2574( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810242076", true, true);
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
         context.AddJavascriptSource("cchoferes.js", "?202281810242076", false, true);
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
         edtChoCod_Internalname = "CHOCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtChoDsc_Internalname = "CHODSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtChoDir_Internalname = "CHODIR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtChoTel_Internalname = "CHOTEL";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtChoRuc_Internalname = "CHORUC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtChoMarca_Internalname = "CHOMARCA";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtChoPlaca_Internalname = "CHOPLACA";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtChoLicencia_Internalname = "CHOLICENCIA";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtChoConsta_Internalname = "CHOCONSTA";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         cmbChoSts_Internalname = "CHOSTS";
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
         cmbChoSts_Jsonclick = "";
         cmbChoSts.Enabled = 1;
         edtChoConsta_Jsonclick = "";
         edtChoConsta_Enabled = 1;
         edtChoLicencia_Jsonclick = "";
         edtChoLicencia_Enabled = 1;
         edtChoPlaca_Jsonclick = "";
         edtChoPlaca_Enabled = 1;
         edtChoMarca_Jsonclick = "";
         edtChoMarca_Enabled = 1;
         edtChoRuc_Jsonclick = "";
         edtChoRuc_Enabled = 1;
         edtChoTel_Jsonclick = "";
         edtChoTel_Enabled = 1;
         edtChoDir_Jsonclick = "";
         edtChoDir_Enabled = 1;
         edtChoDsc_Jsonclick = "";
         edtChoDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtChoCod_Jsonclick = "";
         edtChoCod_Enabled = 1;
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
         cmbChoSts.Name = "CHOSTS";
         cmbChoSts.WebTags = "";
         cmbChoSts.addItem("1", "ACTIVO", 0);
         cmbChoSts.addItem("0", "INACTIVO", 0);
         if ( cmbChoSts.ItemCount > 0 )
         {
            A549ChoSts = (short)(NumberUtil.Val( cmbChoSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0))), "."));
            AssignAttri("", false, "A549ChoSts", StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtChoDsc_Internalname;
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

      public void Valid_Chocod( )
      {
         A549ChoSts = (short)(NumberUtil.Val( cmbChoSts.CurrentValue, "."));
         cmbChoSts.CurrentValue = StringUtil.Str( (decimal)(A549ChoSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbChoSts.ItemCount > 0 )
         {
            A549ChoSts = (short)(NumberUtil.Val( cmbChoSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0))), "."));
            cmbChoSts.CurrentValue = StringUtil.Str( (decimal)(A549ChoSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbChoSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A542ChoDsc", StringUtil.RTrim( A542ChoDsc));
         AssignAttri("", false, "A545ChoDir", StringUtil.RTrim( A545ChoDir));
         AssignAttri("", false, "A550ChoTel", StringUtil.RTrim( A550ChoTel));
         AssignAttri("", false, "A548ChoRuc", StringUtil.RTrim( A548ChoRuc));
         AssignAttri("", false, "A547ChoMarca", StringUtil.RTrim( A547ChoMarca));
         AssignAttri("", false, "A543ChoPlaca", StringUtil.RTrim( A543ChoPlaca));
         AssignAttri("", false, "A546ChoLicencia", StringUtil.RTrim( A546ChoLicencia));
         AssignAttri("", false, "A544ChoConsta", StringUtil.RTrim( A544ChoConsta));
         AssignAttri("", false, "A549ChoSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A549ChoSts), 1, 0, ".", "")));
         cmbChoSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A549ChoSts), 1, 0));
         AssignProp("", false, cmbChoSts_Internalname, "Values", cmbChoSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A541ChoCompleto", A541ChoCompleto);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z542ChoDsc", StringUtil.RTrim( Z542ChoDsc));
         GxWebStd.gx_hidden_field( context, "Z545ChoDir", StringUtil.RTrim( Z545ChoDir));
         GxWebStd.gx_hidden_field( context, "Z550ChoTel", StringUtil.RTrim( Z550ChoTel));
         GxWebStd.gx_hidden_field( context, "Z548ChoRuc", StringUtil.RTrim( Z548ChoRuc));
         GxWebStd.gx_hidden_field( context, "Z547ChoMarca", StringUtil.RTrim( Z547ChoMarca));
         GxWebStd.gx_hidden_field( context, "Z543ChoPlaca", StringUtil.RTrim( Z543ChoPlaca));
         GxWebStd.gx_hidden_field( context, "Z546ChoLicencia", StringUtil.RTrim( Z546ChoLicencia));
         GxWebStd.gx_hidden_field( context, "Z544ChoConsta", StringUtil.RTrim( Z544ChoConsta));
         GxWebStd.gx_hidden_field( context, "Z549ChoSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z549ChoSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z541ChoCompleto", Z541ChoCompleto);
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
         setEventMetadata("VALID_CHOCOD","{handler:'Valid_Chocod',iparms:[{av:'cmbChoSts'},{av:'A549ChoSts',fld:'CHOSTS',pic:'9'},{av:'A10ChoCod',fld:'CHOCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CHOCOD",",oparms:[{av:'A542ChoDsc',fld:'CHODSC',pic:''},{av:'A545ChoDir',fld:'CHODIR',pic:''},{av:'A550ChoTel',fld:'CHOTEL',pic:''},{av:'A548ChoRuc',fld:'CHORUC',pic:''},{av:'A547ChoMarca',fld:'CHOMARCA',pic:''},{av:'A543ChoPlaca',fld:'CHOPLACA',pic:''},{av:'A546ChoLicencia',fld:'CHOLICENCIA',pic:''},{av:'A544ChoConsta',fld:'CHOCONSTA',pic:''},{av:'cmbChoSts'},{av:'A549ChoSts',fld:'CHOSTS',pic:'9'},{av:'A541ChoCompleto',fld:'CHOCOMPLETO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z10ChoCod'},{av:'Z542ChoDsc'},{av:'Z545ChoDir'},{av:'Z550ChoTel'},{av:'Z548ChoRuc'},{av:'Z547ChoMarca'},{av:'Z543ChoPlaca'},{av:'Z546ChoLicencia'},{av:'Z544ChoConsta'},{av:'Z549ChoSts'},{av:'Z541ChoCompleto'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CHODSC","{handler:'Valid_Chodsc',iparms:[]");
         setEventMetadata("VALID_CHODSC",",oparms:[]}");
         setEventMetadata("VALID_CHOPLACA","{handler:'Valid_Choplaca',iparms:[]");
         setEventMetadata("VALID_CHOPLACA",",oparms:[]}");
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
         Z542ChoDsc = "";
         Z545ChoDir = "";
         Z550ChoTel = "";
         Z548ChoRuc = "";
         Z547ChoMarca = "";
         Z543ChoPlaca = "";
         Z546ChoLicencia = "";
         Z544ChoConsta = "";
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
         A542ChoDsc = "";
         lblTextblock3_Jsonclick = "";
         A545ChoDir = "";
         lblTextblock4_Jsonclick = "";
         A550ChoTel = "";
         lblTextblock5_Jsonclick = "";
         A548ChoRuc = "";
         lblTextblock6_Jsonclick = "";
         A547ChoMarca = "";
         lblTextblock7_Jsonclick = "";
         A543ChoPlaca = "";
         lblTextblock8_Jsonclick = "";
         A546ChoLicencia = "";
         lblTextblock9_Jsonclick = "";
         A544ChoConsta = "";
         lblTextblock10_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A541ChoCompleto = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00254_A10ChoCod = new int[1] ;
         T00254_A542ChoDsc = new string[] {""} ;
         T00254_A545ChoDir = new string[] {""} ;
         T00254_A550ChoTel = new string[] {""} ;
         T00254_A548ChoRuc = new string[] {""} ;
         T00254_A547ChoMarca = new string[] {""} ;
         T00254_A543ChoPlaca = new string[] {""} ;
         T00254_A546ChoLicencia = new string[] {""} ;
         T00254_A544ChoConsta = new string[] {""} ;
         T00254_A549ChoSts = new short[1] ;
         T00255_A10ChoCod = new int[1] ;
         T00253_A10ChoCod = new int[1] ;
         T00253_A542ChoDsc = new string[] {""} ;
         T00253_A545ChoDir = new string[] {""} ;
         T00253_A550ChoTel = new string[] {""} ;
         T00253_A548ChoRuc = new string[] {""} ;
         T00253_A547ChoMarca = new string[] {""} ;
         T00253_A543ChoPlaca = new string[] {""} ;
         T00253_A546ChoLicencia = new string[] {""} ;
         T00253_A544ChoConsta = new string[] {""} ;
         T00253_A549ChoSts = new short[1] ;
         sMode74 = "";
         T00256_A10ChoCod = new int[1] ;
         T00257_A10ChoCod = new int[1] ;
         T00252_A10ChoCod = new int[1] ;
         T00252_A542ChoDsc = new string[] {""} ;
         T00252_A545ChoDir = new string[] {""} ;
         T00252_A550ChoTel = new string[] {""} ;
         T00252_A548ChoRuc = new string[] {""} ;
         T00252_A547ChoMarca = new string[] {""} ;
         T00252_A543ChoPlaca = new string[] {""} ;
         T00252_A546ChoLicencia = new string[] {""} ;
         T00252_A544ChoConsta = new string[] {""} ;
         T00252_A549ChoSts = new short[1] ;
         T002511_A13MvATip = new string[] {""} ;
         T002511_A14MvACod = new string[] {""} ;
         T002512_A8DesCod = new string[] {""} ;
         T002513_A10ChoCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z541ChoCompleto = "";
         ZZ542ChoDsc = "";
         ZZ545ChoDir = "";
         ZZ550ChoTel = "";
         ZZ548ChoRuc = "";
         ZZ547ChoMarca = "";
         ZZ543ChoPlaca = "";
         ZZ546ChoLicencia = "";
         ZZ544ChoConsta = "";
         ZZ541ChoCompleto = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cchoferes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cchoferes__default(),
            new Object[][] {
                new Object[] {
               T00252_A10ChoCod, T00252_A542ChoDsc, T00252_A545ChoDir, T00252_A550ChoTel, T00252_A548ChoRuc, T00252_A547ChoMarca, T00252_A543ChoPlaca, T00252_A546ChoLicencia, T00252_A544ChoConsta, T00252_A549ChoSts
               }
               , new Object[] {
               T00253_A10ChoCod, T00253_A542ChoDsc, T00253_A545ChoDir, T00253_A550ChoTel, T00253_A548ChoRuc, T00253_A547ChoMarca, T00253_A543ChoPlaca, T00253_A546ChoLicencia, T00253_A544ChoConsta, T00253_A549ChoSts
               }
               , new Object[] {
               T00254_A10ChoCod, T00254_A542ChoDsc, T00254_A545ChoDir, T00254_A550ChoTel, T00254_A548ChoRuc, T00254_A547ChoMarca, T00254_A543ChoPlaca, T00254_A546ChoLicencia, T00254_A544ChoConsta, T00254_A549ChoSts
               }
               , new Object[] {
               T00255_A10ChoCod
               }
               , new Object[] {
               T00256_A10ChoCod
               }
               , new Object[] {
               T00257_A10ChoCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002511_A13MvATip, T002511_A14MvACod
               }
               , new Object[] {
               T002512_A8DesCod
               }
               , new Object[] {
               T002513_A10ChoCod
               }
            }
         );
      }

      private short Z549ChoSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A549ChoSts ;
      private short GX_JID ;
      private short RcdFound74 ;
      private short nIsDirty_74 ;
      private short Gx_BScreen ;
      private short ZZ549ChoSts ;
      private int Z10ChoCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A10ChoCod ;
      private int edtChoCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtChoDsc_Enabled ;
      private int edtChoDir_Enabled ;
      private int edtChoTel_Enabled ;
      private int edtChoRuc_Enabled ;
      private int edtChoMarca_Enabled ;
      private int edtChoPlaca_Enabled ;
      private int edtChoLicencia_Enabled ;
      private int edtChoConsta_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ10ChoCod ;
      private string sPrefix ;
      private string Z542ChoDsc ;
      private string Z545ChoDir ;
      private string Z550ChoTel ;
      private string Z548ChoRuc ;
      private string Z547ChoMarca ;
      private string Z543ChoPlaca ;
      private string Z546ChoLicencia ;
      private string Z544ChoConsta ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtChoCod_Internalname ;
      private string cmbChoSts_Internalname ;
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
      private string edtChoCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtChoDsc_Internalname ;
      private string A542ChoDsc ;
      private string edtChoDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtChoDir_Internalname ;
      private string A545ChoDir ;
      private string edtChoDir_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtChoTel_Internalname ;
      private string A550ChoTel ;
      private string edtChoTel_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtChoRuc_Internalname ;
      private string A548ChoRuc ;
      private string edtChoRuc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtChoMarca_Internalname ;
      private string A547ChoMarca ;
      private string edtChoMarca_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtChoPlaca_Internalname ;
      private string A543ChoPlaca ;
      private string edtChoPlaca_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtChoLicencia_Internalname ;
      private string A546ChoLicencia ;
      private string edtChoLicencia_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtChoConsta_Internalname ;
      private string A544ChoConsta ;
      private string edtChoConsta_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string cmbChoSts_Jsonclick ;
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
      private string sMode74 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ542ChoDsc ;
      private string ZZ545ChoDir ;
      private string ZZ550ChoTel ;
      private string ZZ548ChoRuc ;
      private string ZZ547ChoMarca ;
      private string ZZ543ChoPlaca ;
      private string ZZ546ChoLicencia ;
      private string ZZ544ChoConsta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A541ChoCompleto ;
      private string Z541ChoCompleto ;
      private string ZZ541ChoCompleto ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbChoSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00254_A10ChoCod ;
      private string[] T00254_A542ChoDsc ;
      private string[] T00254_A545ChoDir ;
      private string[] T00254_A550ChoTel ;
      private string[] T00254_A548ChoRuc ;
      private string[] T00254_A547ChoMarca ;
      private string[] T00254_A543ChoPlaca ;
      private string[] T00254_A546ChoLicencia ;
      private string[] T00254_A544ChoConsta ;
      private short[] T00254_A549ChoSts ;
      private int[] T00255_A10ChoCod ;
      private int[] T00253_A10ChoCod ;
      private string[] T00253_A542ChoDsc ;
      private string[] T00253_A545ChoDir ;
      private string[] T00253_A550ChoTel ;
      private string[] T00253_A548ChoRuc ;
      private string[] T00253_A547ChoMarca ;
      private string[] T00253_A543ChoPlaca ;
      private string[] T00253_A546ChoLicencia ;
      private string[] T00253_A544ChoConsta ;
      private short[] T00253_A549ChoSts ;
      private int[] T00256_A10ChoCod ;
      private int[] T00257_A10ChoCod ;
      private int[] T00252_A10ChoCod ;
      private string[] T00252_A542ChoDsc ;
      private string[] T00252_A545ChoDir ;
      private string[] T00252_A550ChoTel ;
      private string[] T00252_A548ChoRuc ;
      private string[] T00252_A547ChoMarca ;
      private string[] T00252_A543ChoPlaca ;
      private string[] T00252_A546ChoLicencia ;
      private string[] T00252_A544ChoConsta ;
      private short[] T00252_A549ChoSts ;
      private string[] T002511_A13MvATip ;
      private string[] T002511_A14MvACod ;
      private string[] T002512_A8DesCod ;
      private int[] T002513_A10ChoCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cchoferes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cchoferes__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00254;
        prmT00254 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00255;
        prmT00255 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00253;
        prmT00253 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00256;
        prmT00256 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00257;
        prmT00257 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00252;
        prmT00252 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00258;
        prmT00258 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0) ,
        new ParDef("@ChoDsc",GXType.NChar,100,0) ,
        new ParDef("@ChoDir",GXType.NChar,100,0) ,
        new ParDef("@ChoTel",GXType.NChar,20,0) ,
        new ParDef("@ChoRuc",GXType.NChar,20,0) ,
        new ParDef("@ChoMarca",GXType.NChar,30,0) ,
        new ParDef("@ChoPlaca",GXType.NChar,20,0) ,
        new ParDef("@ChoLicencia",GXType.NChar,20,0) ,
        new ParDef("@ChoConsta",GXType.NChar,20,0) ,
        new ParDef("@ChoSts",GXType.Int16,1,0)
        };
        Object[] prmT00259;
        prmT00259 = new Object[] {
        new ParDef("@ChoDsc",GXType.NChar,100,0) ,
        new ParDef("@ChoDir",GXType.NChar,100,0) ,
        new ParDef("@ChoTel",GXType.NChar,20,0) ,
        new ParDef("@ChoRuc",GXType.NChar,20,0) ,
        new ParDef("@ChoMarca",GXType.NChar,30,0) ,
        new ParDef("@ChoPlaca",GXType.NChar,20,0) ,
        new ParDef("@ChoLicencia",GXType.NChar,20,0) ,
        new ParDef("@ChoConsta",GXType.NChar,20,0) ,
        new ParDef("@ChoSts",GXType.Int16,1,0) ,
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT002510;
        prmT002510 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT002511;
        prmT002511 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT002512;
        prmT002512 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT002513;
        prmT002513 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00252", "SELECT [ChoCod], [ChoDsc], [ChoDir], [ChoTel], [ChoRuc], [ChoMarca], [ChoPlaca], [ChoLicencia], [ChoConsta], [ChoSts] FROM [CCHOFERES] WITH (UPDLOCK) WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00252,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00253", "SELECT [ChoCod], [ChoDsc], [ChoDir], [ChoTel], [ChoRuc], [ChoMarca], [ChoPlaca], [ChoLicencia], [ChoConsta], [ChoSts] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00253,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00254", "SELECT TM1.[ChoCod], TM1.[ChoDsc], TM1.[ChoDir], TM1.[ChoTel], TM1.[ChoRuc], TM1.[ChoMarca], TM1.[ChoPlaca], TM1.[ChoLicencia], TM1.[ChoConsta], TM1.[ChoSts] FROM [CCHOFERES] TM1 WHERE TM1.[ChoCod] = @ChoCod ORDER BY TM1.[ChoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00254,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00255", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00255,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00256", "SELECT TOP 1 [ChoCod] FROM [CCHOFERES] WHERE ( [ChoCod] > @ChoCod) ORDER BY [ChoCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00256,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00257", "SELECT TOP 1 [ChoCod] FROM [CCHOFERES] WHERE ( [ChoCod] < @ChoCod) ORDER BY [ChoCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00257,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00258", "INSERT INTO [CCHOFERES]([ChoCod], [ChoDsc], [ChoDir], [ChoTel], [ChoRuc], [ChoMarca], [ChoPlaca], [ChoLicencia], [ChoConsta], [ChoSts]) VALUES(@ChoCod, @ChoDsc, @ChoDir, @ChoTel, @ChoRuc, @ChoMarca, @ChoPlaca, @ChoLicencia, @ChoConsta, @ChoSts)", GxErrorMask.GX_NOMASK,prmT00258)
           ,new CursorDef("T00259", "UPDATE [CCHOFERES] SET [ChoDsc]=@ChoDsc, [ChoDir]=@ChoDir, [ChoTel]=@ChoTel, [ChoRuc]=@ChoRuc, [ChoMarca]=@ChoMarca, [ChoPlaca]=@ChoPlaca, [ChoLicencia]=@ChoLicencia, [ChoConsta]=@ChoConsta, [ChoSts]=@ChoSts  WHERE [ChoCod] = @ChoCod", GxErrorMask.GX_NOMASK,prmT00259)
           ,new CursorDef("T002510", "DELETE FROM [CCHOFERES]  WHERE [ChoCod] = @ChoCod", GxErrorMask.GX_NOMASK,prmT002510)
           ,new CursorDef("T002511", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002512", "SELECT TOP 1 [DesCod] FROM [ADESPACHO] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002512,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002513", "SELECT [ChoCod] FROM [CCHOFERES] ORDER BY [ChoCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002513,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
