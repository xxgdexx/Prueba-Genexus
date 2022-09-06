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
   public class cvendedores : GXDataArea
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
            Form.Meta.addItem("description", "Vendedores / Cobradores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cvendedores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cvendedores( IGxContext context )
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
         cmbVenSts = new GXCombobox();
         cmbVenTipo = new GXCombobox();
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
         if ( cmbVenSts.ItemCount > 0 )
         {
            A2047VenSts = (short)(NumberUtil.Val( cmbVenSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0))), "."));
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVenSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            AssignProp("", false, cmbVenSts_Internalname, "Values", cmbVenSts.ToJavascriptSource(), true);
         }
         if ( cmbVenTipo.ItemCount > 0 )
         {
            A2049VenTipo = cmbVenTipo.getValidValue(A2049VenTipo);
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVenTipo.CurrentValue = StringUtil.RTrim( A2049VenTipo);
            AssignProp("", false, cmbVenTipo_Internalname, "Values", cmbVenTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CVENDEDORES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A309VenCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtVenCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A309VenCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A309VenCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Vendedor / Cobrador", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenDsc_Internalname, StringUtil.RTrim( A2045VenDsc), StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Dirección", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenDir_Internalname, StringUtil.RTrim( A2044VenDir), StringUtil.RTrim( context.localUtil.Format( A2044VenDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Telefono", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenTelf_Internalname, StringUtil.RTrim( A2048VenTelf), StringUtil.RTrim( context.localUtil.Format( A2048VenTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenTelf_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Celular", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenCel_Internalname, StringUtil.RTrim( A2043VenCel), StringUtil.RTrim( context.localUtil.Format( A2043VenCel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenCel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenCel_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "R.U.C.", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenRuc_Internalname, StringUtil.RTrim( A2046VenRuc), StringUtil.RTrim( context.localUtil.Format( A2046VenRuc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenRuc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenRuc_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVenSts, cmbVenSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0)), 1, cmbVenSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVenSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 1, "HLP_CVENDEDORES.htm");
         cmbVenSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         AssignProp("", false, cmbVenSts_Internalname, "Values", (string)(cmbVenSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Tipo", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CVENDEDORES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVenTipo, cmbVenTipo_Internalname, StringUtil.RTrim( A2049VenTipo), 1, cmbVenTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbVenTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 1, "HLP_CVENDEDORES.htm");
         cmbVenTipo.CurrentValue = StringUtil.RTrim( A2049VenTipo);
         AssignProp("", false, cmbVenTipo_Internalname, "Values", (string)(cmbVenTipo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CVENDEDORES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CVENDEDORES.htm");
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
            Z309VenCod = (int)(context.localUtil.CToN( cgiGet( "Z309VenCod"), ".", ","));
            Z2045VenDsc = cgiGet( "Z2045VenDsc");
            Z2044VenDir = cgiGet( "Z2044VenDir");
            Z2048VenTelf = cgiGet( "Z2048VenTelf");
            Z2043VenCel = cgiGet( "Z2043VenCel");
            Z2046VenRuc = cgiGet( "Z2046VenRuc");
            Z2047VenSts = (short)(context.localUtil.CToN( cgiGet( "Z2047VenSts"), ".", ","));
            Z2049VenTipo = cgiGet( "Z2049VenTipo");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtVenCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVenCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENCOD");
               AnyError = 1;
               GX_FocusControl = edtVenCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A309VenCod = 0;
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
            }
            else
            {
               A309VenCod = (int)(context.localUtil.CToN( cgiGet( edtVenCod_Internalname), ".", ","));
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
            }
            A2045VenDsc = cgiGet( edtVenDsc_Internalname);
            AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
            A2044VenDir = cgiGet( edtVenDir_Internalname);
            AssignAttri("", false, "A2044VenDir", A2044VenDir);
            A2048VenTelf = cgiGet( edtVenTelf_Internalname);
            AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
            A2043VenCel = cgiGet( edtVenCel_Internalname);
            AssignAttri("", false, "A2043VenCel", A2043VenCel);
            A2046VenRuc = cgiGet( edtVenRuc_Internalname);
            AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
            cmbVenSts.CurrentValue = cgiGet( cmbVenSts_Internalname);
            A2047VenSts = (short)(NumberUtil.Val( cgiGet( cmbVenSts_Internalname), "."));
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            cmbVenTipo.CurrentValue = cgiGet( cmbVenTipo_Internalname);
            A2049VenTipo = cgiGet( cmbVenTipo_Internalname);
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
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
               A309VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
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
               InitAll3Z138( ) ;
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
         DisableAttributes3Z138( ) ;
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

      protected void CONFIRM_3Z0( )
      {
         BeforeValidate3Z138( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3Z138( ) ;
            }
            else
            {
               CheckExtendedTable3Z138( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3Z138( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3Z0( ) ;
         }
      }

      protected void ResetCaption3Z0( )
      {
      }

      protected void ZM3Z138( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2045VenDsc = T003Z3_A2045VenDsc[0];
               Z2044VenDir = T003Z3_A2044VenDir[0];
               Z2048VenTelf = T003Z3_A2048VenTelf[0];
               Z2043VenCel = T003Z3_A2043VenCel[0];
               Z2046VenRuc = T003Z3_A2046VenRuc[0];
               Z2047VenSts = T003Z3_A2047VenSts[0];
               Z2049VenTipo = T003Z3_A2049VenTipo[0];
            }
            else
            {
               Z2045VenDsc = A2045VenDsc;
               Z2044VenDir = A2044VenDir;
               Z2048VenTelf = A2048VenTelf;
               Z2043VenCel = A2043VenCel;
               Z2046VenRuc = A2046VenRuc;
               Z2047VenSts = A2047VenSts;
               Z2049VenTipo = A2049VenTipo;
            }
         }
         if ( GX_JID == -1 )
         {
            Z309VenCod = A309VenCod;
            Z2045VenDsc = A2045VenDsc;
            Z2044VenDir = A2044VenDir;
            Z2048VenTelf = A2048VenTelf;
            Z2043VenCel = A2043VenCel;
            Z2046VenRuc = A2046VenRuc;
            Z2047VenSts = A2047VenSts;
            Z2049VenTipo = A2049VenTipo;
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

      protected void Load3Z138( )
      {
         /* Using cursor T003Z4 */
         pr_default.execute(2, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound138 = 1;
            A2045VenDsc = T003Z4_A2045VenDsc[0];
            AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
            A2044VenDir = T003Z4_A2044VenDir[0];
            AssignAttri("", false, "A2044VenDir", A2044VenDir);
            A2048VenTelf = T003Z4_A2048VenTelf[0];
            AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
            A2043VenCel = T003Z4_A2043VenCel[0];
            AssignAttri("", false, "A2043VenCel", A2043VenCel);
            A2046VenRuc = T003Z4_A2046VenRuc[0];
            AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
            A2047VenSts = T003Z4_A2047VenSts[0];
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            A2049VenTipo = T003Z4_A2049VenTipo[0];
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
            ZM3Z138( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3Z138( ) ;
      }

      protected void OnLoadActions3Z138( )
      {
      }

      protected void CheckExtendedTable3Z138( )
      {
         nIsDirty_138 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3Z138( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3Z138( )
      {
         /* Using cursor T003Z5 */
         pr_default.execute(3, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound138 = 1;
         }
         else
         {
            RcdFound138 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003Z3 */
         pr_default.execute(1, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3Z138( 1) ;
            RcdFound138 = 1;
            A309VenCod = T003Z3_A309VenCod[0];
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
            A2045VenDsc = T003Z3_A2045VenDsc[0];
            AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
            A2044VenDir = T003Z3_A2044VenDir[0];
            AssignAttri("", false, "A2044VenDir", A2044VenDir);
            A2048VenTelf = T003Z3_A2048VenTelf[0];
            AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
            A2043VenCel = T003Z3_A2043VenCel[0];
            AssignAttri("", false, "A2043VenCel", A2043VenCel);
            A2046VenRuc = T003Z3_A2046VenRuc[0];
            AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
            A2047VenSts = T003Z3_A2047VenSts[0];
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            A2049VenTipo = T003Z3_A2049VenTipo[0];
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
            Z309VenCod = A309VenCod;
            sMode138 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3Z138( ) ;
            if ( AnyError == 1 )
            {
               RcdFound138 = 0;
               InitializeNonKey3Z138( ) ;
            }
            Gx_mode = sMode138;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound138 = 0;
            InitializeNonKey3Z138( ) ;
            sMode138 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode138;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3Z138( ) ;
         if ( RcdFound138 == 0 )
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
         RcdFound138 = 0;
         /* Using cursor T003Z6 */
         pr_default.execute(4, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003Z6_A309VenCod[0] < A309VenCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003Z6_A309VenCod[0] > A309VenCod ) ) )
            {
               A309VenCod = T003Z6_A309VenCod[0];
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               RcdFound138 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound138 = 0;
         /* Using cursor T003Z7 */
         pr_default.execute(5, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003Z7_A309VenCod[0] > A309VenCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003Z7_A309VenCod[0] < A309VenCod ) ) )
            {
               A309VenCod = T003Z7_A309VenCod[0];
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               RcdFound138 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3Z138( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3Z138( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound138 == 1 )
            {
               if ( A309VenCod != Z309VenCod )
               {
                  A309VenCod = Z309VenCod;
                  AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VENCOD");
                  AnyError = 1;
                  GX_FocusControl = edtVenCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVenCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3Z138( ) ;
                  GX_FocusControl = edtVenCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A309VenCod != Z309VenCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtVenCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3Z138( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENCOD");
                     AnyError = 1;
                     GX_FocusControl = edtVenCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtVenCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3Z138( ) ;
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
         if ( A309VenCod != Z309VenCod )
         {
            A309VenCod = Z309VenCod;
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VENCOD");
            AnyError = 1;
            GX_FocusControl = edtVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVenCod_Internalname;
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
         GetKey3Z138( ) ;
         if ( RcdFound138 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "VENCOD");
               AnyError = 1;
               GX_FocusControl = edtVenCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A309VenCod != Z309VenCod )
            {
               A309VenCod = Z309VenCod;
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "VENCOD");
               AnyError = 1;
               GX_FocusControl = edtVenCod_Internalname;
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
            if ( A309VenCod != Z309VenCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENCOD");
                  AnyError = 1;
                  GX_FocusControl = edtVenCod_Internalname;
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
         context.RollbackDataStores("cvendedores",pr_default);
         GX_FocusControl = edtVenDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3Z0( ) ;
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
         if ( RcdFound138 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VENCOD");
            AnyError = 1;
            GX_FocusControl = edtVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtVenDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3Z138( ) ;
         if ( RcdFound138 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVenDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3Z138( ) ;
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
         if ( RcdFound138 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVenDsc_Internalname;
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
         if ( RcdFound138 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVenDsc_Internalname;
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
         ScanStart3Z138( ) ;
         if ( RcdFound138 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound138 != 0 )
            {
               ScanNext3Z138( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVenDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3Z138( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3Z138( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003Z2 */
            pr_default.execute(0, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CVENDEDORES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2045VenDsc, T003Z2_A2045VenDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2044VenDir, T003Z2_A2044VenDir[0]) != 0 ) || ( StringUtil.StrCmp(Z2048VenTelf, T003Z2_A2048VenTelf[0]) != 0 ) || ( StringUtil.StrCmp(Z2043VenCel, T003Z2_A2043VenCel[0]) != 0 ) || ( StringUtil.StrCmp(Z2046VenRuc, T003Z2_A2046VenRuc[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2047VenSts != T003Z2_A2047VenSts[0] ) || ( StringUtil.StrCmp(Z2049VenTipo, T003Z2_A2049VenTipo[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2045VenDsc, T003Z2_A2045VenDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2045VenDsc);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2045VenDsc[0]);
               }
               if ( StringUtil.StrCmp(Z2044VenDir, T003Z2_A2044VenDir[0]) != 0 )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenDir");
                  GXUtil.WriteLogRaw("Old: ",Z2044VenDir);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2044VenDir[0]);
               }
               if ( StringUtil.StrCmp(Z2048VenTelf, T003Z2_A2048VenTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenTelf");
                  GXUtil.WriteLogRaw("Old: ",Z2048VenTelf);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2048VenTelf[0]);
               }
               if ( StringUtil.StrCmp(Z2043VenCel, T003Z2_A2043VenCel[0]) != 0 )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenCel");
                  GXUtil.WriteLogRaw("Old: ",Z2043VenCel);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2043VenCel[0]);
               }
               if ( StringUtil.StrCmp(Z2046VenRuc, T003Z2_A2046VenRuc[0]) != 0 )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenRuc");
                  GXUtil.WriteLogRaw("Old: ",Z2046VenRuc);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2046VenRuc[0]);
               }
               if ( Z2047VenSts != T003Z2_A2047VenSts[0] )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenSts");
                  GXUtil.WriteLogRaw("Old: ",Z2047VenSts);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2047VenSts[0]);
               }
               if ( StringUtil.StrCmp(Z2049VenTipo, T003Z2_A2049VenTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("cvendedores:[seudo value changed for attri]"+"VenTipo");
                  GXUtil.WriteLogRaw("Old: ",Z2049VenTipo);
                  GXUtil.WriteLogRaw("Current: ",T003Z2_A2049VenTipo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CVENDEDORES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3Z138( )
      {
         BeforeValidate3Z138( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3Z138( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3Z138( 0) ;
            CheckOptimisticConcurrency3Z138( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3Z138( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3Z138( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003Z8 */
                     pr_default.execute(6, new Object[] {A309VenCod, A2045VenDsc, A2044VenDir, A2048VenTelf, A2043VenCel, A2046VenRuc, A2047VenSts, A2049VenTipo});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CVENDEDORES");
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
                           ResetCaption3Z0( ) ;
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
               Load3Z138( ) ;
            }
            EndLevel3Z138( ) ;
         }
         CloseExtendedTableCursors3Z138( ) ;
      }

      protected void Update3Z138( )
      {
         BeforeValidate3Z138( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3Z138( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3Z138( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3Z138( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3Z138( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003Z9 */
                     pr_default.execute(7, new Object[] {A2045VenDsc, A2044VenDir, A2048VenTelf, A2043VenCel, A2046VenRuc, A2047VenSts, A2049VenTipo, A309VenCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CVENDEDORES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CVENDEDORES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3Z138( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3Z0( ) ;
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
            EndLevel3Z138( ) ;
         }
         CloseExtendedTableCursors3Z138( ) ;
      }

      protected void DeferredUpdate3Z138( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3Z138( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3Z138( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3Z138( ) ;
            AfterConfirm3Z138( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3Z138( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003Z10 */
                  pr_default.execute(8, new Object[] {A309VenCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CVENDEDORES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound138 == 0 )
                        {
                           InitAll3Z138( ) ;
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
                        ResetCaption3Z0( ) ;
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
         sMode138 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3Z138( ) ;
         Gx_mode = sMode138;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3Z138( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003Z11 */
            pr_default.execute(9, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003Z12 */
            pr_default.execute(10, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T003Z13 */
            pr_default.execute(11, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T003Z14 */
            pr_default.execute(12, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T003Z15 */
            pr_default.execute(13, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T003Z16 */
            pr_default.execute(14, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T003Z17 */
            pr_default.execute(15, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T003Z18 */
            pr_default.execute(16, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T003Z19 */
            pr_default.execute(17, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel3Z138( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3Z138( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cvendedores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cvendedores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3Z138( )
      {
         /* Using cursor T003Z20 */
         pr_default.execute(18);
         RcdFound138 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound138 = 1;
            A309VenCod = T003Z20_A309VenCod[0];
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3Z138( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound138 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound138 = 1;
            A309VenCod = T003Z20_A309VenCod[0];
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         }
      }

      protected void ScanEnd3Z138( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm3Z138( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3Z138( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3Z138( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3Z138( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3Z138( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3Z138( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3Z138( )
      {
         edtVenCod_Enabled = 0;
         AssignProp("", false, edtVenCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCod_Enabled), 5, 0), true);
         edtVenDsc_Enabled = 0;
         AssignProp("", false, edtVenDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenDsc_Enabled), 5, 0), true);
         edtVenDir_Enabled = 0;
         AssignProp("", false, edtVenDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenDir_Enabled), 5, 0), true);
         edtVenTelf_Enabled = 0;
         AssignProp("", false, edtVenTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenTelf_Enabled), 5, 0), true);
         edtVenCel_Enabled = 0;
         AssignProp("", false, edtVenCel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCel_Enabled), 5, 0), true);
         edtVenRuc_Enabled = 0;
         AssignProp("", false, edtVenRuc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenRuc_Enabled), 5, 0), true);
         cmbVenSts.Enabled = 0;
         AssignProp("", false, cmbVenSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVenSts.Enabled), 5, 0), true);
         cmbVenTipo.Enabled = 0;
         AssignProp("", false, cmbVenTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVenTipo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3Z138( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3Z0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252899", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cvendedores.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z309VenCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z309VenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2045VenDsc", StringUtil.RTrim( Z2045VenDsc));
         GxWebStd.gx_hidden_field( context, "Z2044VenDir", StringUtil.RTrim( Z2044VenDir));
         GxWebStd.gx_hidden_field( context, "Z2048VenTelf", StringUtil.RTrim( Z2048VenTelf));
         GxWebStd.gx_hidden_field( context, "Z2043VenCel", StringUtil.RTrim( Z2043VenCel));
         GxWebStd.gx_hidden_field( context, "Z2046VenRuc", StringUtil.RTrim( Z2046VenRuc));
         GxWebStd.gx_hidden_field( context, "Z2047VenSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2047VenSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2049VenTipo", StringUtil.RTrim( Z2049VenTipo));
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
         return formatLink("cvendedores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CVENDEDORES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Vendedores / Cobradores" ;
      }

      protected void InitializeNonKey3Z138( )
      {
         A2045VenDsc = "";
         AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
         A2044VenDir = "";
         AssignAttri("", false, "A2044VenDir", A2044VenDir);
         A2048VenTelf = "";
         AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
         A2043VenCel = "";
         AssignAttri("", false, "A2043VenCel", A2043VenCel);
         A2046VenRuc = "";
         AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
         A2047VenSts = 0;
         AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         A2049VenTipo = "";
         AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
         Z2045VenDsc = "";
         Z2044VenDir = "";
         Z2048VenTelf = "";
         Z2043VenCel = "";
         Z2046VenRuc = "";
         Z2047VenSts = 0;
         Z2049VenTipo = "";
      }

      protected void InitAll3Z138( )
      {
         A309VenCod = 0;
         AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         InitializeNonKey3Z138( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025297", true, true);
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
         context.AddJavascriptSource("cvendedores.js", "?20228181025297", false, true);
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
         edtVenCod_Internalname = "VENCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtVenDsc_Internalname = "VENDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtVenDir_Internalname = "VENDIR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtVenTelf_Internalname = "VENTELF";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtVenCel_Internalname = "VENCEL";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtVenRuc_Internalname = "VENRUC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         cmbVenSts_Internalname = "VENSTS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         cmbVenTipo_Internalname = "VENTIPO";
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
         Form.Caption = "Vendedores / Cobradores";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbVenTipo_Jsonclick = "";
         cmbVenTipo.Enabled = 1;
         cmbVenSts_Jsonclick = "";
         cmbVenSts.Enabled = 1;
         edtVenRuc_Jsonclick = "";
         edtVenRuc_Enabled = 1;
         edtVenCel_Jsonclick = "";
         edtVenCel_Enabled = 1;
         edtVenTelf_Jsonclick = "";
         edtVenTelf_Enabled = 1;
         edtVenDir_Jsonclick = "";
         edtVenDir_Enabled = 1;
         edtVenDsc_Jsonclick = "";
         edtVenDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtVenCod_Jsonclick = "";
         edtVenCod_Enabled = 1;
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
         cmbVenSts.Name = "VENSTS";
         cmbVenSts.WebTags = "";
         cmbVenSts.addItem("1", "ACTIVO", 0);
         cmbVenSts.addItem("0", "INACTIVO", 0);
         if ( cmbVenSts.ItemCount > 0 )
         {
            A2047VenSts = (short)(NumberUtil.Val( cmbVenSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0))), "."));
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         }
         cmbVenTipo.Name = "VENTIPO";
         cmbVenTipo.WebTags = "";
         cmbVenTipo.addItem("T", "Ambos", 0);
         cmbVenTipo.addItem("V", "Vendedor", 0);
         cmbVenTipo.addItem("C", "Cobrador", 0);
         if ( cmbVenTipo.ItemCount > 0 )
         {
            A2049VenTipo = cmbVenTipo.getValidValue(A2049VenTipo);
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtVenDsc_Internalname;
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

      public void Valid_Vencod( )
      {
         A2049VenTipo = cmbVenTipo.CurrentValue;
         cmbVenTipo.CurrentValue = A2049VenTipo;
         A2047VenSts = (short)(NumberUtil.Val( cmbVenSts.CurrentValue, "."));
         cmbVenSts.CurrentValue = StringUtil.Str( (decimal)(A2047VenSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbVenSts.ItemCount > 0 )
         {
            A2047VenSts = (short)(NumberUtil.Val( cmbVenSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0))), "."));
            cmbVenSts.CurrentValue = StringUtil.Str( (decimal)(A2047VenSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVenSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         }
         if ( cmbVenTipo.ItemCount > 0 )
         {
            A2049VenTipo = cmbVenTipo.getValidValue(A2049VenTipo);
            cmbVenTipo.CurrentValue = A2049VenTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVenTipo.CurrentValue = StringUtil.RTrim( A2049VenTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2045VenDsc", StringUtil.RTrim( A2045VenDsc));
         AssignAttri("", false, "A2044VenDir", StringUtil.RTrim( A2044VenDir));
         AssignAttri("", false, "A2048VenTelf", StringUtil.RTrim( A2048VenTelf));
         AssignAttri("", false, "A2043VenCel", StringUtil.RTrim( A2043VenCel));
         AssignAttri("", false, "A2046VenRuc", StringUtil.RTrim( A2046VenRuc));
         AssignAttri("", false, "A2047VenSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2047VenSts), 1, 0, ".", "")));
         cmbVenSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         AssignProp("", false, cmbVenSts_Internalname, "Values", cmbVenSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A2049VenTipo", StringUtil.RTrim( A2049VenTipo));
         cmbVenTipo.CurrentValue = StringUtil.RTrim( A2049VenTipo);
         AssignProp("", false, cmbVenTipo_Internalname, "Values", cmbVenTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z309VenCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z309VenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2045VenDsc", StringUtil.RTrim( Z2045VenDsc));
         GxWebStd.gx_hidden_field( context, "Z2044VenDir", StringUtil.RTrim( Z2044VenDir));
         GxWebStd.gx_hidden_field( context, "Z2048VenTelf", StringUtil.RTrim( Z2048VenTelf));
         GxWebStd.gx_hidden_field( context, "Z2043VenCel", StringUtil.RTrim( Z2043VenCel));
         GxWebStd.gx_hidden_field( context, "Z2046VenRuc", StringUtil.RTrim( Z2046VenRuc));
         GxWebStd.gx_hidden_field( context, "Z2047VenSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2047VenSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2049VenTipo", StringUtil.RTrim( Z2049VenTipo));
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
         setEventMetadata("VALID_VENCOD","{handler:'Valid_Vencod',iparms:[{av:'cmbVenTipo'},{av:'A2049VenTipo',fld:'VENTIPO',pic:''},{av:'cmbVenSts'},{av:'A2047VenSts',fld:'VENSTS',pic:'9'},{av:'A309VenCod',fld:'VENCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_VENCOD",",oparms:[{av:'A2045VenDsc',fld:'VENDSC',pic:''},{av:'A2044VenDir',fld:'VENDIR',pic:''},{av:'A2048VenTelf',fld:'VENTELF',pic:''},{av:'A2043VenCel',fld:'VENCEL',pic:''},{av:'A2046VenRuc',fld:'VENRUC',pic:''},{av:'cmbVenSts'},{av:'A2047VenSts',fld:'VENSTS',pic:'9'},{av:'cmbVenTipo'},{av:'A2049VenTipo',fld:'VENTIPO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z309VenCod'},{av:'Z2045VenDsc'},{av:'Z2044VenDir'},{av:'Z2048VenTelf'},{av:'Z2043VenCel'},{av:'Z2046VenRuc'},{av:'Z2047VenSts'},{av:'Z2049VenTipo'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z2045VenDsc = "";
         Z2044VenDir = "";
         Z2048VenTelf = "";
         Z2043VenCel = "";
         Z2046VenRuc = "";
         Z2049VenTipo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A2049VenTipo = "";
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
         A2045VenDsc = "";
         lblTextblock3_Jsonclick = "";
         A2044VenDir = "";
         lblTextblock4_Jsonclick = "";
         A2048VenTelf = "";
         lblTextblock5_Jsonclick = "";
         A2043VenCel = "";
         lblTextblock6_Jsonclick = "";
         A2046VenRuc = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
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
         T003Z4_A309VenCod = new int[1] ;
         T003Z4_A2045VenDsc = new string[] {""} ;
         T003Z4_A2044VenDir = new string[] {""} ;
         T003Z4_A2048VenTelf = new string[] {""} ;
         T003Z4_A2043VenCel = new string[] {""} ;
         T003Z4_A2046VenRuc = new string[] {""} ;
         T003Z4_A2047VenSts = new short[1] ;
         T003Z4_A2049VenTipo = new string[] {""} ;
         T003Z5_A309VenCod = new int[1] ;
         T003Z3_A309VenCod = new int[1] ;
         T003Z3_A2045VenDsc = new string[] {""} ;
         T003Z3_A2044VenDir = new string[] {""} ;
         T003Z3_A2048VenTelf = new string[] {""} ;
         T003Z3_A2043VenCel = new string[] {""} ;
         T003Z3_A2046VenRuc = new string[] {""} ;
         T003Z3_A2047VenSts = new short[1] ;
         T003Z3_A2049VenTipo = new string[] {""} ;
         sMode138 = "";
         T003Z6_A309VenCod = new int[1] ;
         T003Z7_A309VenCod = new int[1] ;
         T003Z2_A309VenCod = new int[1] ;
         T003Z2_A2045VenDsc = new string[] {""} ;
         T003Z2_A2044VenDir = new string[] {""} ;
         T003Z2_A2048VenTelf = new string[] {""} ;
         T003Z2_A2043VenCel = new string[] {""} ;
         T003Z2_A2046VenRuc = new string[] {""} ;
         T003Z2_A2047VenSts = new short[1] ;
         T003Z2_A2049VenTipo = new string[] {""} ;
         T003Z11_A348UsuCod = new string[] {""} ;
         T003Z12_A149TipCod = new string[] {""} ;
         T003Z12_A24DocNum = new string[] {""} ;
         T003Z13_A210PedCod = new string[] {""} ;
         T003Z14_A191ImpItem = new long[1] ;
         T003Z15_A184CCTipCod = new string[] {""} ;
         T003Z15_A185CCDocNum = new string[] {""} ;
         T003Z16_A177CotCod = new string[] {""} ;
         T003Z17_A166CobTip = new string[] {""} ;
         T003Z17_A167CobCod = new string[] {""} ;
         T003Z18_A45CliCod = new string[] {""} ;
         T003Z19_A144CLAntTipCod = new string[] {""} ;
         T003Z19_A145CLAntDocNum = new string[] {""} ;
         T003Z20_A309VenCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2045VenDsc = "";
         ZZ2044VenDir = "";
         ZZ2048VenTelf = "";
         ZZ2043VenCel = "";
         ZZ2046VenRuc = "";
         ZZ2049VenTipo = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cvendedores__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cvendedores__default(),
            new Object[][] {
                new Object[] {
               T003Z2_A309VenCod, T003Z2_A2045VenDsc, T003Z2_A2044VenDir, T003Z2_A2048VenTelf, T003Z2_A2043VenCel, T003Z2_A2046VenRuc, T003Z2_A2047VenSts, T003Z2_A2049VenTipo
               }
               , new Object[] {
               T003Z3_A309VenCod, T003Z3_A2045VenDsc, T003Z3_A2044VenDir, T003Z3_A2048VenTelf, T003Z3_A2043VenCel, T003Z3_A2046VenRuc, T003Z3_A2047VenSts, T003Z3_A2049VenTipo
               }
               , new Object[] {
               T003Z4_A309VenCod, T003Z4_A2045VenDsc, T003Z4_A2044VenDir, T003Z4_A2048VenTelf, T003Z4_A2043VenCel, T003Z4_A2046VenRuc, T003Z4_A2047VenSts, T003Z4_A2049VenTipo
               }
               , new Object[] {
               T003Z5_A309VenCod
               }
               , new Object[] {
               T003Z6_A309VenCod
               }
               , new Object[] {
               T003Z7_A309VenCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003Z11_A348UsuCod
               }
               , new Object[] {
               T003Z12_A149TipCod, T003Z12_A24DocNum
               }
               , new Object[] {
               T003Z13_A210PedCod
               }
               , new Object[] {
               T003Z14_A191ImpItem
               }
               , new Object[] {
               T003Z15_A184CCTipCod, T003Z15_A185CCDocNum
               }
               , new Object[] {
               T003Z16_A177CotCod
               }
               , new Object[] {
               T003Z17_A166CobTip, T003Z17_A167CobCod
               }
               , new Object[] {
               T003Z18_A45CliCod
               }
               , new Object[] {
               T003Z19_A144CLAntTipCod, T003Z19_A145CLAntDocNum
               }
               , new Object[] {
               T003Z20_A309VenCod
               }
            }
         );
      }

      private short Z2047VenSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2047VenSts ;
      private short GX_JID ;
      private short RcdFound138 ;
      private short nIsDirty_138 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2047VenSts ;
      private int Z309VenCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A309VenCod ;
      private int edtVenCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtVenDsc_Enabled ;
      private int edtVenDir_Enabled ;
      private int edtVenTelf_Enabled ;
      private int edtVenCel_Enabled ;
      private int edtVenRuc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ309VenCod ;
      private string sPrefix ;
      private string Z2045VenDsc ;
      private string Z2044VenDir ;
      private string Z2048VenTelf ;
      private string Z2043VenCel ;
      private string Z2046VenRuc ;
      private string Z2049VenTipo ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVenCod_Internalname ;
      private string cmbVenSts_Internalname ;
      private string A2049VenTipo ;
      private string cmbVenTipo_Internalname ;
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
      private string edtVenCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtVenDsc_Internalname ;
      private string A2045VenDsc ;
      private string edtVenDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtVenDir_Internalname ;
      private string A2044VenDir ;
      private string edtVenDir_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtVenTelf_Internalname ;
      private string A2048VenTelf ;
      private string edtVenTelf_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtVenCel_Internalname ;
      private string A2043VenCel ;
      private string edtVenCel_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtVenRuc_Internalname ;
      private string A2046VenRuc ;
      private string edtVenRuc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string cmbVenSts_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string cmbVenTipo_Jsonclick ;
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
      private string sMode138 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2045VenDsc ;
      private string ZZ2044VenDir ;
      private string ZZ2048VenTelf ;
      private string ZZ2043VenCel ;
      private string ZZ2046VenRuc ;
      private string ZZ2049VenTipo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVenSts ;
      private GXCombobox cmbVenTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T003Z4_A309VenCod ;
      private string[] T003Z4_A2045VenDsc ;
      private string[] T003Z4_A2044VenDir ;
      private string[] T003Z4_A2048VenTelf ;
      private string[] T003Z4_A2043VenCel ;
      private string[] T003Z4_A2046VenRuc ;
      private short[] T003Z4_A2047VenSts ;
      private string[] T003Z4_A2049VenTipo ;
      private int[] T003Z5_A309VenCod ;
      private int[] T003Z3_A309VenCod ;
      private string[] T003Z3_A2045VenDsc ;
      private string[] T003Z3_A2044VenDir ;
      private string[] T003Z3_A2048VenTelf ;
      private string[] T003Z3_A2043VenCel ;
      private string[] T003Z3_A2046VenRuc ;
      private short[] T003Z3_A2047VenSts ;
      private string[] T003Z3_A2049VenTipo ;
      private int[] T003Z6_A309VenCod ;
      private int[] T003Z7_A309VenCod ;
      private int[] T003Z2_A309VenCod ;
      private string[] T003Z2_A2045VenDsc ;
      private string[] T003Z2_A2044VenDir ;
      private string[] T003Z2_A2048VenTelf ;
      private string[] T003Z2_A2043VenCel ;
      private string[] T003Z2_A2046VenRuc ;
      private short[] T003Z2_A2047VenSts ;
      private string[] T003Z2_A2049VenTipo ;
      private string[] T003Z11_A348UsuCod ;
      private string[] T003Z12_A149TipCod ;
      private string[] T003Z12_A24DocNum ;
      private string[] T003Z13_A210PedCod ;
      private long[] T003Z14_A191ImpItem ;
      private string[] T003Z15_A184CCTipCod ;
      private string[] T003Z15_A185CCDocNum ;
      private string[] T003Z16_A177CotCod ;
      private string[] T003Z17_A166CobTip ;
      private string[] T003Z17_A167CobCod ;
      private string[] T003Z18_A45CliCod ;
      private string[] T003Z19_A144CLAntTipCod ;
      private string[] T003Z19_A145CLAntDocNum ;
      private int[] T003Z20_A309VenCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cvendedores__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cvendedores__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003Z4;
        prmT003Z4 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z5;
        prmT003Z5 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z3;
        prmT003Z3 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z6;
        prmT003Z6 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z7;
        prmT003Z7 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z2;
        prmT003Z2 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z8;
        prmT003Z8 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0) ,
        new ParDef("@VenDsc",GXType.NChar,100,0) ,
        new ParDef("@VenDir",GXType.NChar,100,0) ,
        new ParDef("@VenTelf",GXType.NChar,15,0) ,
        new ParDef("@VenCel",GXType.NChar,15,0) ,
        new ParDef("@VenRuc",GXType.NChar,15,0) ,
        new ParDef("@VenSts",GXType.Int16,1,0) ,
        new ParDef("@VenTipo",GXType.NChar,1,0)
        };
        Object[] prmT003Z9;
        prmT003Z9 = new Object[] {
        new ParDef("@VenDsc",GXType.NChar,100,0) ,
        new ParDef("@VenDir",GXType.NChar,100,0) ,
        new ParDef("@VenTelf",GXType.NChar,15,0) ,
        new ParDef("@VenCel",GXType.NChar,15,0) ,
        new ParDef("@VenRuc",GXType.NChar,15,0) ,
        new ParDef("@VenSts",GXType.Int16,1,0) ,
        new ParDef("@VenTipo",GXType.NChar,1,0) ,
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z10;
        prmT003Z10 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z11;
        prmT003Z11 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z12;
        prmT003Z12 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z13;
        prmT003Z13 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z14;
        prmT003Z14 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z15;
        prmT003Z15 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z16;
        prmT003Z16 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z17;
        prmT003Z17 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z18;
        prmT003Z18 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z19;
        prmT003Z19 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT003Z20;
        prmT003Z20 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003Z2", "SELECT [VenCod], [VenDsc], [VenDir], [VenTelf], [VenCel], [VenRuc], [VenSts], [VenTipo] FROM [CVENDEDORES] WITH (UPDLOCK) WHERE [VenCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Z3", "SELECT [VenCod], [VenDsc], [VenDir], [VenTelf], [VenCel], [VenRuc], [VenSts], [VenTipo] FROM [CVENDEDORES] WHERE [VenCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Z4", "SELECT TM1.[VenCod], TM1.[VenDsc], TM1.[VenDir], TM1.[VenTelf], TM1.[VenCel], TM1.[VenRuc], TM1.[VenSts], TM1.[VenTipo] FROM [CVENDEDORES] TM1 WHERE TM1.[VenCod] = @VenCod ORDER BY TM1.[VenCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Z5", "SELECT [VenCod] FROM [CVENDEDORES] WHERE [VenCod] = @VenCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Z6", "SELECT TOP 1 [VenCod] FROM [CVENDEDORES] WHERE ( [VenCod] > @VenCod) ORDER BY [VenCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z7", "SELECT TOP 1 [VenCod] FROM [CVENDEDORES] WHERE ( [VenCod] < @VenCod) ORDER BY [VenCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z8", "INSERT INTO [CVENDEDORES]([VenCod], [VenDsc], [VenDir], [VenTelf], [VenCel], [VenRuc], [VenSts], [VenTipo]) VALUES(@VenCod, @VenDsc, @VenDir, @VenTelf, @VenCel, @VenRuc, @VenSts, @VenTipo)", GxErrorMask.GX_NOMASK,prmT003Z8)
           ,new CursorDef("T003Z9", "UPDATE [CVENDEDORES] SET [VenDsc]=@VenDsc, [VenDir]=@VenDir, [VenTelf]=@VenTelf, [VenCel]=@VenCel, [VenRuc]=@VenRuc, [VenSts]=@VenSts, [VenTipo]=@VenTipo  WHERE [VenCod] = @VenCod", GxErrorMask.GX_NOMASK,prmT003Z9)
           ,new CursorDef("T003Z10", "DELETE FROM [CVENDEDORES]  WHERE [VenCod] = @VenCod", GxErrorMask.GX_NOMASK,prmT003Z10)
           ,new CursorDef("T003Z11", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuVend] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z12", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z13", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [PedVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z14", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z15", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z16", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CotVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z17", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z18", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [CliVend] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z19", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntVenCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Z20", "SELECT [VenCod] FROM [CVENDEDORES] ORDER BY [VenCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Z20,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
