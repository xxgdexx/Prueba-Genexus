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
   public class cbplancuenta : GXDataArea
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
            A109CueGasDebe = GetPar( "CueGasDebe");
            n109CueGasDebe = false;
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A109CueGasDebe) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A110CueGasHaber = GetPar( "CueGasHaber");
            n110CueGasHaber = false;
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A110CueGasHaber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A111CueMonDebe = GetPar( "CueMonDebe");
            n111CueMonDebe = false;
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A111CueMonDebe) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A112CueMonHaber = GetPar( "CueMonHaber");
            n112CueMonHaber = false;
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A112CueMonHaber) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A70TipACod = (int)(NumberUtil.Val( GetPar( "TipACod"), "."));
            n70TipACod = false;
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A70TipACod) ;
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
            Form.Meta.addItem("description", "Plan de Cuentas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbplancuenta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbplancuenta( IGxContext context )
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
         cmbCueSts = new GXCombobox();
         cmbCueRef4 = new GXCombobox();
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
         if ( cmbCueSts.ItemCount > 0 )
         {
            A873CueSts = (short)(NumberUtil.Val( cmbCueSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0))), "."));
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            AssignProp("", false, cmbCueSts_Internalname, "Values", cmbCueSts.ToJavascriptSource(), true);
         }
         if ( cmbCueRef4.ItemCount > 0 )
         {
            A871CueRef4 = (short)(NumberUtil.Val( cmbCueRef4.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0))), "."));
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueRef4.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            AssignProp("", false, cmbCueRef4_Internalname, "Values", cmbCueRef4.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPLANCUENTA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Cuenta", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripción de Cuenta", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueDsc_Internalname, StringUtil.RTrim( A860CueDsc), StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura Cuenta", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueAbr_Internalname, StringUtil.RTrim( A857CueAbr), StringUtil.RTrim( context.localUtil.Format( A857CueAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueAbr_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Movimiento Cuenta", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A867CueMov), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueMov_Enabled!=0) ? context.localUtil.Format( (decimal)(A867CueMov), "9") : context.localUtil.Format( (decimal)(A867CueMov), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueMov_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Monetaria", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A864CueMon), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A864CueMon), "9") : context.localUtil.Format( (decimal)(A864CueMon), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueMon_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Centro de Costos", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A859CueCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A859CueCos), "9") : context.localUtil.Format( (decimal)(A859CueCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Situación", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCueSts, cmbCueSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0)), 1, cmbCueSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCueSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 1, "HLP_CBPLANCUENTA.htm");
         cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         AssignProp("", false, cmbCueSts_Internalname, "Values", (string)(cmbCueSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cuenta de Gasto Debe", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueGasDebe_Internalname, StringUtil.RTrim( A109CueGasDebe), StringUtil.RTrim( context.localUtil.Format( A109CueGasDebe, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueGasDebe_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueGasDebe_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cuenta de Gasto Haber", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueGasHaber_Internalname, StringUtil.RTrim( A110CueGasHaber), StringUtil.RTrim( context.localUtil.Format( A110CueGasHaber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueGasHaber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueGasHaber_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Referencia 1", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A868CueRef1), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef1_Enabled!=0) ? context.localUtil.Format( (decimal)(A868CueRef1), "9") : context.localUtil.Format( (decimal)(A868CueRef1), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueRef1_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Referencia 2", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A869CueRef2), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef2_Enabled!=0) ? context.localUtil.Format( (decimal)(A869CueRef2), "9") : context.localUtil.Format( (decimal)(A869CueRef2), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueRef2_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Referencia 3", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A870CueRef3), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef3_Enabled!=0) ? context.localUtil.Format( (decimal)(A870CueRef3), "9") : context.localUtil.Format( (decimal)(A870CueRef3), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueRef3_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Referencia 4", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCueRef4, cmbCueRef4_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0)), 1, cmbCueRef4_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCueRef4.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 1, "HLP_CBPLANCUENTA.htm");
         cmbCueRef4.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         AssignProp("", false, cmbCueRef4_Internalname, "Values", (string)(cmbCueRef4.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Referencia 5", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueRef5_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A872CueRef5), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueRef5_Enabled!=0) ? context.localUtil.Format( (decimal)(A872CueRef5), "9") : context.localUtil.Format( (decimal)(A872CueRef5), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueRef5_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Cuenta Monetaria Debe", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMonDebe_Internalname, StringUtil.RTrim( A111CueMonDebe), StringUtil.RTrim( context.localUtil.Format( A111CueMonDebe, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMonDebe_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueMonDebe_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Cuenta Monetaria Haber", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueMonHaber_Internalname, StringUtil.RTrim( A112CueMonHaber), StringUtil.RTrim( context.localUtil.Format( A112CueMonHaber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueMonHaber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueMonHaber_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Codigo T. Auxiliar", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipACod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipACod_Enabled!=0) ? context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A70TipACod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipACod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Agrupo Documento", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueGrupDoc_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A863CueGrupDoc), 1, 0, ".", "")), StringUtil.LTrim( ((edtCueGrupDoc_Enabled!=0) ? context.localUtil.Format( (decimal)(A863CueGrupDoc), "9") : context.localUtil.Format( (decimal)(A863CueGrupDoc), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueGrupDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueGrupDoc_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPLANCUENTA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPLANCUENTA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBPLANCUENTA.htm");
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
            Z91CueCod = cgiGet( "Z91CueCod");
            Z860CueDsc = cgiGet( "Z860CueDsc");
            Z857CueAbr = cgiGet( "Z857CueAbr");
            Z867CueMov = (short)(context.localUtil.CToN( cgiGet( "Z867CueMov"), ".", ","));
            Z864CueMon = (short)(context.localUtil.CToN( cgiGet( "Z864CueMon"), ".", ","));
            Z859CueCos = (short)(context.localUtil.CToN( cgiGet( "Z859CueCos"), ".", ","));
            Z873CueSts = (short)(context.localUtil.CToN( cgiGet( "Z873CueSts"), ".", ","));
            Z868CueRef1 = (short)(context.localUtil.CToN( cgiGet( "Z868CueRef1"), ".", ","));
            Z869CueRef2 = (short)(context.localUtil.CToN( cgiGet( "Z869CueRef2"), ".", ","));
            Z870CueRef3 = (short)(context.localUtil.CToN( cgiGet( "Z870CueRef3"), ".", ","));
            Z871CueRef4 = (short)(context.localUtil.CToN( cgiGet( "Z871CueRef4"), ".", ","));
            Z872CueRef5 = (short)(context.localUtil.CToN( cgiGet( "Z872CueRef5"), ".", ","));
            Z863CueGrupDoc = (short)(context.localUtil.CToN( cgiGet( "Z863CueGrupDoc"), ".", ","));
            Z70TipACod = (int)(context.localUtil.CToN( cgiGet( "Z70TipACod"), ".", ","));
            n70TipACod = ((0==A70TipACod) ? true : false);
            Z109CueGasDebe = cgiGet( "Z109CueGasDebe");
            Z110CueGasHaber = cgiGet( "Z110CueGasHaber");
            Z111CueMonDebe = cgiGet( "Z111CueMonDebe");
            Z112CueMonHaber = cgiGet( "Z112CueMonHaber");
            Z113CueCierre = cgiGet( "Z113CueCierre");
            n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
            A113CueCierre = cgiGet( "Z113CueCierre");
            n113CueCierre = false;
            n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A2098CueDscCompleto = cgiGet( "CUEDSCCOMPLETO");
            A113CueCierre = cgiGet( "CUECIERRE");
            n113CueCierre = (String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ? true : false);
            A858CueCierreDsc = cgiGet( "CUECIERREDSC");
            /* Read variables values. */
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A860CueDsc = cgiGet( edtCueDsc_Internalname);
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A857CueAbr = cgiGet( edtCueAbr_Internalname);
            n857CueAbr = false;
            AssignAttri("", false, "A857CueAbr", A857CueAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEMOV");
               AnyError = 1;
               GX_FocusControl = edtCueMov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A867CueMov = 0;
               AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
            }
            else
            {
               A867CueMov = (short)(context.localUtil.CToN( cgiGet( edtCueMov_Internalname), ".", ","));
               AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEMON");
               AnyError = 1;
               GX_FocusControl = edtCueMon_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A864CueMon = 0;
               AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
            }
            else
            {
               A864CueMon = (short)(context.localUtil.CToN( cgiGet( edtCueMon_Internalname), ".", ","));
               AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUECOS");
               AnyError = 1;
               GX_FocusControl = edtCueCos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A859CueCos = 0;
               AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
            }
            else
            {
               A859CueCos = (short)(context.localUtil.CToN( cgiGet( edtCueCos_Internalname), ".", ","));
               AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
            }
            cmbCueSts.CurrentValue = cgiGet( cmbCueSts_Internalname);
            A873CueSts = (short)(NumberUtil.Val( cgiGet( cmbCueSts_Internalname), "."));
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            A109CueGasDebe = cgiGet( edtCueGasDebe_Internalname);
            n109CueGasDebe = false;
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            A110CueGasHaber = cgiGet( edtCueGasHaber_Internalname);
            n110CueGasHaber = false;
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef1_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF1");
               AnyError = 1;
               GX_FocusControl = edtCueRef1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A868CueRef1 = 0;
               AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
            }
            else
            {
               A868CueRef1 = (short)(context.localUtil.CToN( cgiGet( edtCueRef1_Internalname), ".", ","));
               AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef2_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF2");
               AnyError = 1;
               GX_FocusControl = edtCueRef2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A869CueRef2 = 0;
               AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
            }
            else
            {
               A869CueRef2 = (short)(context.localUtil.CToN( cgiGet( edtCueRef2_Internalname), ".", ","));
               AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef3_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef3_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF3");
               AnyError = 1;
               GX_FocusControl = edtCueRef3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A870CueRef3 = 0;
               AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
            }
            else
            {
               A870CueRef3 = (short)(context.localUtil.CToN( cgiGet( edtCueRef3_Internalname), ".", ","));
               AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
            }
            cmbCueRef4.CurrentValue = cgiGet( cmbCueRef4_Internalname);
            A871CueRef4 = (short)(NumberUtil.Val( cgiGet( cmbCueRef4_Internalname), "."));
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueRef5_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueRef5_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEREF5");
               AnyError = 1;
               GX_FocusControl = edtCueRef5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A872CueRef5 = 0;
               AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
            }
            else
            {
               A872CueRef5 = (short)(context.localUtil.CToN( cgiGet( edtCueRef5_Internalname), ".", ","));
               AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
            }
            A111CueMonDebe = cgiGet( edtCueMonDebe_Internalname);
            n111CueMonDebe = false;
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            A112CueMonHaber = cgiGet( edtCueMonHaber_Internalname);
            n112CueMonHaber = false;
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A70TipACod = 0;
               n70TipACod = false;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            }
            else
            {
               A70TipACod = (int)(context.localUtil.CToN( cgiGet( edtTipACod_Internalname), ".", ","));
               n70TipACod = false;
               AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            }
            n70TipACod = ((0==A70TipACod) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCueGrupDoc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCueGrupDoc_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CUEGRUPDOC");
               AnyError = 1;
               GX_FocusControl = edtCueGrupDoc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A863CueGrupDoc = 0;
               AssignAttri("", false, "A863CueGrupDoc", StringUtil.Str( (decimal)(A863CueGrupDoc), 1, 0));
            }
            else
            {
               A863CueGrupDoc = (short)(context.localUtil.CToN( cgiGet( edtCueGrupDoc_Internalname), ".", ","));
               AssignAttri("", false, "A863CueGrupDoc", StringUtil.Str( (decimal)(A863CueGrupDoc), 1, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CBPLANCUENTA");
            forbiddenHiddens.Add("CueCierre", StringUtil.RTrim( context.localUtil.Format( A113CueCierre, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cbplancuenta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               InitAll1V64( ) ;
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
         DisableAttributes1V64( ) ;
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

      protected void CONFIRM_1V0( )
      {
         BeforeValidate1V64( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1V64( ) ;
            }
            else
            {
               CheckExtendedTable1V64( ) ;
               if ( AnyError == 0 )
               {
                  ZM1V64( 3) ;
                  ZM1V64( 4) ;
                  ZM1V64( 5) ;
                  ZM1V64( 6) ;
                  ZM1V64( 7) ;
                  ZM1V64( 8) ;
               }
               CloseExtendedTableCursors1V64( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1V0( ) ;
         }
      }

      protected void ResetCaption1V0( )
      {
      }

      protected void ZM1V64( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z860CueDsc = T001V3_A860CueDsc[0];
               Z857CueAbr = T001V3_A857CueAbr[0];
               Z867CueMov = T001V3_A867CueMov[0];
               Z864CueMon = T001V3_A864CueMon[0];
               Z859CueCos = T001V3_A859CueCos[0];
               Z873CueSts = T001V3_A873CueSts[0];
               Z868CueRef1 = T001V3_A868CueRef1[0];
               Z869CueRef2 = T001V3_A869CueRef2[0];
               Z870CueRef3 = T001V3_A870CueRef3[0];
               Z871CueRef4 = T001V3_A871CueRef4[0];
               Z872CueRef5 = T001V3_A872CueRef5[0];
               Z863CueGrupDoc = T001V3_A863CueGrupDoc[0];
               Z70TipACod = T001V3_A70TipACod[0];
               Z109CueGasDebe = T001V3_A109CueGasDebe[0];
               Z110CueGasHaber = T001V3_A110CueGasHaber[0];
               Z111CueMonDebe = T001V3_A111CueMonDebe[0];
               Z112CueMonHaber = T001V3_A112CueMonHaber[0];
               Z113CueCierre = T001V3_A113CueCierre[0];
            }
            else
            {
               Z860CueDsc = A860CueDsc;
               Z857CueAbr = A857CueAbr;
               Z867CueMov = A867CueMov;
               Z864CueMon = A864CueMon;
               Z859CueCos = A859CueCos;
               Z873CueSts = A873CueSts;
               Z868CueRef1 = A868CueRef1;
               Z869CueRef2 = A869CueRef2;
               Z870CueRef3 = A870CueRef3;
               Z871CueRef4 = A871CueRef4;
               Z872CueRef5 = A872CueRef5;
               Z863CueGrupDoc = A863CueGrupDoc;
               Z70TipACod = A70TipACod;
               Z109CueGasDebe = A109CueGasDebe;
               Z110CueGasHaber = A110CueGasHaber;
               Z111CueMonDebe = A111CueMonDebe;
               Z112CueMonHaber = A112CueMonHaber;
               Z113CueCierre = A113CueCierre;
            }
         }
         if ( GX_JID == -2 )
         {
            Z91CueCod = A91CueCod;
            Z860CueDsc = A860CueDsc;
            Z857CueAbr = A857CueAbr;
            Z867CueMov = A867CueMov;
            Z864CueMon = A864CueMon;
            Z859CueCos = A859CueCos;
            Z873CueSts = A873CueSts;
            Z868CueRef1 = A868CueRef1;
            Z869CueRef2 = A869CueRef2;
            Z870CueRef3 = A870CueRef3;
            Z871CueRef4 = A871CueRef4;
            Z872CueRef5 = A872CueRef5;
            Z863CueGrupDoc = A863CueGrupDoc;
            Z70TipACod = A70TipACod;
            Z109CueGasDebe = A109CueGasDebe;
            Z110CueGasHaber = A110CueGasHaber;
            Z111CueMonDebe = A111CueMonDebe;
            Z112CueMonHaber = A112CueMonHaber;
            Z113CueCierre = A113CueCierre;
            Z858CueCierreDsc = A858CueCierreDsc;
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
         /* Using cursor T001V9 */
         pr_default.execute(7, new Object[] {n113CueCierre, A113CueCierre});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A113CueCierre)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Cierre'.", "ForeignKeyNotFound", 1, "CUECIERRE");
               AnyError = 1;
            }
         }
         A858CueCierreDsc = T001V9_A858CueCierreDsc[0];
         pr_default.close(7);
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

      protected void Load1V64( )
      {
         /* Using cursor T001V10 */
         pr_default.execute(8, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound64 = 1;
            A860CueDsc = T001V10_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A857CueAbr = T001V10_A857CueAbr[0];
            n857CueAbr = T001V10_n857CueAbr[0];
            AssignAttri("", false, "A857CueAbr", A857CueAbr);
            A867CueMov = T001V10_A867CueMov[0];
            AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
            A864CueMon = T001V10_A864CueMon[0];
            AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
            A859CueCos = T001V10_A859CueCos[0];
            AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
            A873CueSts = T001V10_A873CueSts[0];
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            A868CueRef1 = T001V10_A868CueRef1[0];
            AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
            A869CueRef2 = T001V10_A869CueRef2[0];
            AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
            A870CueRef3 = T001V10_A870CueRef3[0];
            AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
            A871CueRef4 = T001V10_A871CueRef4[0];
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            A872CueRef5 = T001V10_A872CueRef5[0];
            AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
            A863CueGrupDoc = T001V10_A863CueGrupDoc[0];
            AssignAttri("", false, "A863CueGrupDoc", StringUtil.Str( (decimal)(A863CueGrupDoc), 1, 0));
            A858CueCierreDsc = T001V10_A858CueCierreDsc[0];
            A70TipACod = T001V10_A70TipACod[0];
            n70TipACod = T001V10_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A109CueGasDebe = T001V10_A109CueGasDebe[0];
            n109CueGasDebe = T001V10_n109CueGasDebe[0];
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            A110CueGasHaber = T001V10_A110CueGasHaber[0];
            n110CueGasHaber = T001V10_n110CueGasHaber[0];
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            A111CueMonDebe = T001V10_A111CueMonDebe[0];
            n111CueMonDebe = T001V10_n111CueMonDebe[0];
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            A112CueMonHaber = T001V10_A112CueMonHaber[0];
            n112CueMonHaber = T001V10_n112CueMonHaber[0];
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            A113CueCierre = T001V10_A113CueCierre[0];
            n113CueCierre = T001V10_n113CueCierre[0];
            ZM1V64( -2) ;
         }
         pr_default.close(8);
         OnLoadActions1V64( ) ;
      }

      protected void OnLoadActions1V64( )
      {
         A2098CueDscCompleto = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
         AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
      }

      protected void CheckExtendedTable1V64( )
      {
         nIsDirty_64 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         nIsDirty_64 = 1;
         A2098CueDscCompleto = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
         AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
         /* Using cursor T001V5 */
         pr_default.execute(3, new Object[] {n109CueGasDebe, A109CueGasDebe});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueGasDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T001V6 */
         pr_default.execute(4, new Object[] {n110CueGasHaber, A110CueGasHaber});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASHABER");
               AnyError = 1;
               GX_FocusControl = edtCueGasHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T001V7 */
         pr_default.execute(5, new Object[] {n111CueMonDebe, A111CueMonDebe});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A111CueMonDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueMonDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T001V8 */
         pr_default.execute(6, new Object[] {n112CueMonHaber, A112CueMonHaber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112CueMonHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONHABER");
               AnyError = 1;
               GX_FocusControl = edtCueMonHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T001V4 */
         pr_default.execute(2, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1V64( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A109CueGasDebe )
      {
         /* Using cursor T001V11 */
         pr_default.execute(9, new Object[] {n109CueGasDebe, A109CueGasDebe});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueGasDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_5( string A110CueGasHaber )
      {
         /* Using cursor T001V12 */
         pr_default.execute(10, new Object[] {n110CueGasHaber, A110CueGasHaber});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASHABER");
               AnyError = 1;
               GX_FocusControl = edtCueGasHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_6( string A111CueMonDebe )
      {
         /* Using cursor T001V13 */
         pr_default.execute(11, new Object[] {n111CueMonDebe, A111CueMonDebe});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A111CueMonDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueMonDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_7( string A112CueMonHaber )
      {
         /* Using cursor T001V14 */
         pr_default.execute(12, new Object[] {n112CueMonHaber, A112CueMonHaber});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112CueMonHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONHABER");
               AnyError = 1;
               GX_FocusControl = edtCueMonHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_3( int A70TipACod )
      {
         /* Using cursor T001V15 */
         pr_default.execute(13, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void GetKey1V64( )
      {
         /* Using cursor T001V16 */
         pr_default.execute(14, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound64 = 1;
         }
         else
         {
            RcdFound64 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001V3 */
         pr_default.execute(1, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1V64( 2) ;
            RcdFound64 = 1;
            A91CueCod = T001V3_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A860CueDsc = T001V3_A860CueDsc[0];
            AssignAttri("", false, "A860CueDsc", A860CueDsc);
            A857CueAbr = T001V3_A857CueAbr[0];
            n857CueAbr = T001V3_n857CueAbr[0];
            AssignAttri("", false, "A857CueAbr", A857CueAbr);
            A867CueMov = T001V3_A867CueMov[0];
            AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
            A864CueMon = T001V3_A864CueMon[0];
            AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
            A859CueCos = T001V3_A859CueCos[0];
            AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
            A873CueSts = T001V3_A873CueSts[0];
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
            A868CueRef1 = T001V3_A868CueRef1[0];
            AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
            A869CueRef2 = T001V3_A869CueRef2[0];
            AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
            A870CueRef3 = T001V3_A870CueRef3[0];
            AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
            A871CueRef4 = T001V3_A871CueRef4[0];
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
            A872CueRef5 = T001V3_A872CueRef5[0];
            AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
            A863CueGrupDoc = T001V3_A863CueGrupDoc[0];
            AssignAttri("", false, "A863CueGrupDoc", StringUtil.Str( (decimal)(A863CueGrupDoc), 1, 0));
            A70TipACod = T001V3_A70TipACod[0];
            n70TipACod = T001V3_n70TipACod[0];
            AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
            A109CueGasDebe = T001V3_A109CueGasDebe[0];
            n109CueGasDebe = T001V3_n109CueGasDebe[0];
            AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
            A110CueGasHaber = T001V3_A110CueGasHaber[0];
            n110CueGasHaber = T001V3_n110CueGasHaber[0];
            AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
            A111CueMonDebe = T001V3_A111CueMonDebe[0];
            n111CueMonDebe = T001V3_n111CueMonDebe[0];
            AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
            A112CueMonHaber = T001V3_A112CueMonHaber[0];
            n112CueMonHaber = T001V3_n112CueMonHaber[0];
            AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
            A113CueCierre = T001V3_A113CueCierre[0];
            n113CueCierre = T001V3_n113CueCierre[0];
            Z91CueCod = A91CueCod;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1V64( ) ;
            if ( AnyError == 1 )
            {
               RcdFound64 = 0;
               InitializeNonKey1V64( ) ;
            }
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound64 = 0;
            InitializeNonKey1V64( ) ;
            sMode64 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode64;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1V64( ) ;
         if ( RcdFound64 == 0 )
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
         RcdFound64 = 0;
         /* Using cursor T001V17 */
         pr_default.execute(15, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T001V17_A91CueCod[0], A91CueCod) < 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T001V17_A91CueCod[0], A91CueCod) > 0 ) ) )
            {
               A91CueCod = T001V17_A91CueCod[0];
               AssignAttri("", false, "A91CueCod", A91CueCod);
               RcdFound64 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void move_previous( )
      {
         RcdFound64 = 0;
         /* Using cursor T001V18 */
         pr_default.execute(16, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T001V18_A91CueCod[0], A91CueCod) > 0 ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T001V18_A91CueCod[0], A91CueCod) < 0 ) ) )
            {
               A91CueCod = T001V18_A91CueCod[0];
               AssignAttri("", false, "A91CueCod", A91CueCod);
               RcdFound64 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1V64( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1V64( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound64 == 1 )
            {
               if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
               {
                  A91CueCod = Z91CueCod;
                  AssignAttri("", false, "A91CueCod", A91CueCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CUECOD");
                  AnyError = 1;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1V64( ) ;
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCueCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1V64( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUECOD");
                     AnyError = 1;
                     GX_FocusControl = edtCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCueCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1V64( ) ;
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
         if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
         {
            A91CueCod = Z91CueCod;
            AssignAttri("", false, "A91CueCod", A91CueCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCueCod_Internalname;
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
         GetKey1V64( ) ;
         if ( RcdFound64 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CUECOD");
               AnyError = 1;
               GX_FocusControl = edtCueCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
            {
               A91CueCod = Z91CueCod;
               AssignAttri("", false, "A91CueCod", A91CueCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CUECOD");
               AnyError = 1;
               GX_FocusControl = edtCueCod_Internalname;
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
            if ( StringUtil.StrCmp(A91CueCod, Z91CueCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CUECOD");
                  AnyError = 1;
                  GX_FocusControl = edtCueCod_Internalname;
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
         context.RollbackDataStores("cbplancuenta",pr_default);
         GX_FocusControl = edtCueDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1V0( ) ;
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
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCueDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1V64( ) ;
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1V64( ) ;
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
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueDsc_Internalname;
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
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueDsc_Internalname;
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
         ScanStart1V64( ) ;
         if ( RcdFound64 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound64 != 0 )
            {
               ScanNext1V64( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1V64( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1V64( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001V2 */
            pr_default.execute(0, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPLANCUENTA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z860CueDsc, T001V2_A860CueDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z857CueAbr, T001V2_A857CueAbr[0]) != 0 ) || ( Z867CueMov != T001V2_A867CueMov[0] ) || ( Z864CueMon != T001V2_A864CueMon[0] ) || ( Z859CueCos != T001V2_A859CueCos[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z873CueSts != T001V2_A873CueSts[0] ) || ( Z868CueRef1 != T001V2_A868CueRef1[0] ) || ( Z869CueRef2 != T001V2_A869CueRef2[0] ) || ( Z870CueRef3 != T001V2_A870CueRef3[0] ) || ( Z871CueRef4 != T001V2_A871CueRef4[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z872CueRef5 != T001V2_A872CueRef5[0] ) || ( Z863CueGrupDoc != T001V2_A863CueGrupDoc[0] ) || ( Z70TipACod != T001V2_A70TipACod[0] ) || ( StringUtil.StrCmp(Z109CueGasDebe, T001V2_A109CueGasDebe[0]) != 0 ) || ( StringUtil.StrCmp(Z110CueGasHaber, T001V2_A110CueGasHaber[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z111CueMonDebe, T001V2_A111CueMonDebe[0]) != 0 ) || ( StringUtil.StrCmp(Z112CueMonHaber, T001V2_A112CueMonHaber[0]) != 0 ) || ( StringUtil.StrCmp(Z113CueCierre, T001V2_A113CueCierre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z860CueDsc, T001V2_A860CueDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueDsc");
                  GXUtil.WriteLogRaw("Old: ",Z860CueDsc);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A860CueDsc[0]);
               }
               if ( StringUtil.StrCmp(Z857CueAbr, T001V2_A857CueAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueAbr");
                  GXUtil.WriteLogRaw("Old: ",Z857CueAbr);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A857CueAbr[0]);
               }
               if ( Z867CueMov != T001V2_A867CueMov[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueMov");
                  GXUtil.WriteLogRaw("Old: ",Z867CueMov);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A867CueMov[0]);
               }
               if ( Z864CueMon != T001V2_A864CueMon[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueMon");
                  GXUtil.WriteLogRaw("Old: ",Z864CueMon);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A864CueMon[0]);
               }
               if ( Z859CueCos != T001V2_A859CueCos[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueCos");
                  GXUtil.WriteLogRaw("Old: ",Z859CueCos);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A859CueCos[0]);
               }
               if ( Z873CueSts != T001V2_A873CueSts[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueSts");
                  GXUtil.WriteLogRaw("Old: ",Z873CueSts);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A873CueSts[0]);
               }
               if ( Z868CueRef1 != T001V2_A868CueRef1[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueRef1");
                  GXUtil.WriteLogRaw("Old: ",Z868CueRef1);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A868CueRef1[0]);
               }
               if ( Z869CueRef2 != T001V2_A869CueRef2[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueRef2");
                  GXUtil.WriteLogRaw("Old: ",Z869CueRef2);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A869CueRef2[0]);
               }
               if ( Z870CueRef3 != T001V2_A870CueRef3[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueRef3");
                  GXUtil.WriteLogRaw("Old: ",Z870CueRef3);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A870CueRef3[0]);
               }
               if ( Z871CueRef4 != T001V2_A871CueRef4[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueRef4");
                  GXUtil.WriteLogRaw("Old: ",Z871CueRef4);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A871CueRef4[0]);
               }
               if ( Z872CueRef5 != T001V2_A872CueRef5[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueRef5");
                  GXUtil.WriteLogRaw("Old: ",Z872CueRef5);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A872CueRef5[0]);
               }
               if ( Z863CueGrupDoc != T001V2_A863CueGrupDoc[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueGrupDoc");
                  GXUtil.WriteLogRaw("Old: ",Z863CueGrupDoc);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A863CueGrupDoc[0]);
               }
               if ( Z70TipACod != T001V2_A70TipACod[0] )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"TipACod");
                  GXUtil.WriteLogRaw("Old: ",Z70TipACod);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A70TipACod[0]);
               }
               if ( StringUtil.StrCmp(Z109CueGasDebe, T001V2_A109CueGasDebe[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueGasDebe");
                  GXUtil.WriteLogRaw("Old: ",Z109CueGasDebe);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A109CueGasDebe[0]);
               }
               if ( StringUtil.StrCmp(Z110CueGasHaber, T001V2_A110CueGasHaber[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueGasHaber");
                  GXUtil.WriteLogRaw("Old: ",Z110CueGasHaber);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A110CueGasHaber[0]);
               }
               if ( StringUtil.StrCmp(Z111CueMonDebe, T001V2_A111CueMonDebe[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueMonDebe");
                  GXUtil.WriteLogRaw("Old: ",Z111CueMonDebe);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A111CueMonDebe[0]);
               }
               if ( StringUtil.StrCmp(Z112CueMonHaber, T001V2_A112CueMonHaber[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueMonHaber");
                  GXUtil.WriteLogRaw("Old: ",Z112CueMonHaber);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A112CueMonHaber[0]);
               }
               if ( StringUtil.StrCmp(Z113CueCierre, T001V2_A113CueCierre[0]) != 0 )
               {
                  GXUtil.WriteLog("cbplancuenta:[seudo value changed for attri]"+"CueCierre");
                  GXUtil.WriteLogRaw("Old: ",Z113CueCierre);
                  GXUtil.WriteLogRaw("Current: ",T001V2_A113CueCierre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPLANCUENTA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1V64( )
      {
         BeforeValidate1V64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V64( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1V64( 0) ;
            CheckOptimisticConcurrency1V64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1V64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V19 */
                     pr_default.execute(17, new Object[] {A91CueCod, A860CueDsc, n857CueAbr, A857CueAbr, A867CueMov, A864CueMon, A859CueCos, A873CueSts, A868CueRef1, A869CueRef2, A870CueRef3, A871CueRef4, A872CueRef5, A863CueGrupDoc, n70TipACod, A70TipACod, n109CueGasDebe, A109CueGasDebe, n110CueGasHaber, A110CueGasHaber, n111CueMonDebe, A111CueMonDebe, n112CueMonHaber, A112CueMonHaber, n113CueCierre, A113CueCierre});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPLANCUENTA");
                     if ( (pr_default.getStatus(17) == 1) )
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
                           ResetCaption1V0( ) ;
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
               Load1V64( ) ;
            }
            EndLevel1V64( ) ;
         }
         CloseExtendedTableCursors1V64( ) ;
      }

      protected void Update1V64( )
      {
         BeforeValidate1V64( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V64( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V64( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V64( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1V64( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001V20 */
                     pr_default.execute(18, new Object[] {A860CueDsc, n857CueAbr, A857CueAbr, A867CueMov, A864CueMon, A859CueCos, A873CueSts, A868CueRef1, A869CueRef2, A870CueRef3, A871CueRef4, A872CueRef5, A863CueGrupDoc, n70TipACod, A70TipACod, n109CueGasDebe, A109CueGasDebe, n110CueGasHaber, A110CueGasHaber, n111CueMonDebe, A111CueMonDebe, n112CueMonHaber, A112CueMonHaber, n113CueCierre, A113CueCierre, A91CueCod});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPLANCUENTA");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPLANCUENTA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1V64( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1V0( ) ;
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
            EndLevel1V64( ) ;
         }
         CloseExtendedTableCursors1V64( ) ;
      }

      protected void DeferredUpdate1V64( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1V64( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V64( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1V64( ) ;
            AfterConfirm1V64( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1V64( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001V21 */
                  pr_default.execute(19, new Object[] {A91CueCod});
                  pr_default.close(19);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPLANCUENTA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound64 == 0 )
                        {
                           InitAll1V64( ) ;
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
                        ResetCaption1V0( ) ;
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
         sMode64 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1V64( ) ;
         Gx_mode = sMode64;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1V64( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A2098CueDscCompleto = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
            AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001V22 */
            pr_default.execute(20, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001V23 */
            pr_default.execute(21, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T001V24 */
            pr_default.execute(22, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T001V25 */
            pr_default.execute(23, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T001V26 */
            pr_default.execute(24, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Plan de Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T001V27 */
            pr_default.execute(25, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T001V28 */
            pr_default.execute(26, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T001V29 */
            pr_default.execute(27, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuentas de Banco"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T001V30 */
            pr_default.execute(28, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Concepto de Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T001V31 */
            pr_default.execute(29, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Conceptos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T001V32 */
            pr_default.execute(30, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCONCEPTOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T001V33 */
            pr_default.execute(31, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T001V34 */
            pr_default.execute(32, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldos Mensuales Contables"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T001V35 */
            pr_default.execute(33, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T001V36 */
            pr_default.execute(34, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T001V37 */
            pr_default.execute(35, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T001V38 */
            pr_default.execute(36, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T001V39 */
            pr_default.execute(37, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T001V40 */
            pr_default.execute(38, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T001V41 */
            pr_default.execute(39, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T001V42 */
            pr_default.execute(40, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T001V43 */
            pr_default.execute(41, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T001V44 */
            pr_default.execute(42, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T001V45 */
            pr_default.execute(43, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T001V46 */
            pr_default.execute(44, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T001V47 */
            pr_default.execute(45, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBPRESUPUESTORUBROSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T001V48 */
            pr_default.execute(46, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conceptos de Planilla"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T001V49 */
            pr_default.execute(47, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entregas a rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T001V50 */
            pr_default.execute(48, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Concepto de entregas a rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor T001V51 */
            pr_default.execute(49, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Concepto Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor T001V52 */
            pr_default.execute(50, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor T001V53 */
            pr_default.execute(51, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agentes de Aduana"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor T001V54 */
            pr_default.execute(52, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor T001V55 */
            pr_default.execute(53, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lineas Cuentas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor T001V56 */
            pr_default.execute(54, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta 4"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
            /* Using cursor T001V57 */
            pr_default.execute(55, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(55) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta 3"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(55);
            /* Using cursor T001V58 */
            pr_default.execute(56, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(56) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta Haber"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(56);
            /* Using cursor T001V59 */
            pr_default.execute(57, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(57) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"+" ("+"Cuenta Debe"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(57);
            /* Using cursor T001V60 */
            pr_default.execute(58, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(58) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Centro de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(58);
            /* Using cursor T001V61 */
            pr_default.execute(59, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(59) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conceptos de Compras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(59);
            /* Using cursor T001V62 */
            pr_default.execute(60, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(60) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"+" ("+"Cuenta Almacen"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(60);
            /* Using cursor T001V63 */
            pr_default.execute(61, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(61) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(61);
            /* Using cursor T001V64 */
            pr_default.execute(62, new Object[] {A91CueCod});
            if ( (pr_default.getStatus(62) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"+" ("+"Cuenta Contable"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(62);
         }
      }

      protected void EndLevel1V64( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1V64( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbplancuenta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbplancuenta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1V64( )
      {
         /* Using cursor T001V65 */
         pr_default.execute(63);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound64 = 1;
            A91CueCod = T001V65_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1V64( )
      {
         /* Scan next routine */
         pr_default.readNext(63);
         RcdFound64 = 0;
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound64 = 1;
            A91CueCod = T001V65_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
         }
      }

      protected void ScanEnd1V64( )
      {
         pr_default.close(63);
      }

      protected void AfterConfirm1V64( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1V64( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1V64( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1V64( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1V64( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1V64( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1V64( )
      {
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtCueDsc_Enabled = 0;
         AssignProp("", false, edtCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueDsc_Enabled), 5, 0), true);
         edtCueAbr_Enabled = 0;
         AssignProp("", false, edtCueAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueAbr_Enabled), 5, 0), true);
         edtCueMov_Enabled = 0;
         AssignProp("", false, edtCueMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMov_Enabled), 5, 0), true);
         edtCueMon_Enabled = 0;
         AssignProp("", false, edtCueMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMon_Enabled), 5, 0), true);
         edtCueCos_Enabled = 0;
         AssignProp("", false, edtCueCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCos_Enabled), 5, 0), true);
         cmbCueSts.Enabled = 0;
         AssignProp("", false, cmbCueSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCueSts.Enabled), 5, 0), true);
         edtCueGasDebe_Enabled = 0;
         AssignProp("", false, edtCueGasDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasDebe_Enabled), 5, 0), true);
         edtCueGasHaber_Enabled = 0;
         AssignProp("", false, edtCueGasHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGasHaber_Enabled), 5, 0), true);
         edtCueRef1_Enabled = 0;
         AssignProp("", false, edtCueRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef1_Enabled), 5, 0), true);
         edtCueRef2_Enabled = 0;
         AssignProp("", false, edtCueRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef2_Enabled), 5, 0), true);
         edtCueRef3_Enabled = 0;
         AssignProp("", false, edtCueRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef3_Enabled), 5, 0), true);
         cmbCueRef4.Enabled = 0;
         AssignProp("", false, cmbCueRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCueRef4.Enabled), 5, 0), true);
         edtCueRef5_Enabled = 0;
         AssignProp("", false, edtCueRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueRef5_Enabled), 5, 0), true);
         edtCueMonDebe_Enabled = 0;
         AssignProp("", false, edtCueMonDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonDebe_Enabled), 5, 0), true);
         edtCueMonHaber_Enabled = 0;
         AssignProp("", false, edtCueMonHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueMonHaber_Enabled), 5, 0), true);
         edtTipACod_Enabled = 0;
         AssignProp("", false, edtTipACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipACod_Enabled), 5, 0), true);
         edtCueGrupDoc_Enabled = 0;
         AssignProp("", false, edtCueGrupDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueGrupDoc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1V64( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1V0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242586", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbplancuenta.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CBPLANCUENTA");
         forbiddenHiddens.Add("CueCierre", StringUtil.RTrim( context.localUtil.Format( A113CueCierre, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cbplancuenta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z860CueDsc", StringUtil.RTrim( Z860CueDsc));
         GxWebStd.gx_hidden_field( context, "Z857CueAbr", StringUtil.RTrim( Z857CueAbr));
         GxWebStd.gx_hidden_field( context, "Z867CueMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z867CueMov), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z864CueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z864CueMon), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z859CueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z859CueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z873CueSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z873CueSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z868CueRef1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z868CueRef1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z869CueRef2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z869CueRef2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z870CueRef3", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z870CueRef3), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z871CueRef4", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z871CueRef4), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z872CueRef5", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z872CueRef5), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z863CueGrupDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z863CueGrupDoc), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z109CueGasDebe", StringUtil.RTrim( Z109CueGasDebe));
         GxWebStd.gx_hidden_field( context, "Z110CueGasHaber", StringUtil.RTrim( Z110CueGasHaber));
         GxWebStd.gx_hidden_field( context, "Z111CueMonDebe", StringUtil.RTrim( Z111CueMonDebe));
         GxWebStd.gx_hidden_field( context, "Z112CueMonHaber", StringUtil.RTrim( Z112CueMonHaber));
         GxWebStd.gx_hidden_field( context, "Z113CueCierre", StringUtil.RTrim( Z113CueCierre));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CUEDSCCOMPLETO", StringUtil.RTrim( A2098CueDscCompleto));
         GxWebStd.gx_hidden_field( context, "CUECIERRE", StringUtil.RTrim( A113CueCierre));
         GxWebStd.gx_hidden_field( context, "CUECIERREDSC", StringUtil.RTrim( A858CueCierreDsc));
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
         return formatLink("cbplancuenta.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPLANCUENTA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Plan de Cuentas" ;
      }

      protected void InitializeNonKey1V64( )
      {
         A2098CueDscCompleto = "";
         AssignAttri("", false, "A2098CueDscCompleto", A2098CueDscCompleto);
         A860CueDsc = "";
         AssignAttri("", false, "A860CueDsc", A860CueDsc);
         A857CueAbr = "";
         n857CueAbr = false;
         AssignAttri("", false, "A857CueAbr", A857CueAbr);
         A867CueMov = 0;
         AssignAttri("", false, "A867CueMov", StringUtil.Str( (decimal)(A867CueMov), 1, 0));
         A864CueMon = 0;
         AssignAttri("", false, "A864CueMon", StringUtil.Str( (decimal)(A864CueMon), 1, 0));
         A859CueCos = 0;
         AssignAttri("", false, "A859CueCos", StringUtil.Str( (decimal)(A859CueCos), 1, 0));
         A873CueSts = 0;
         AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         A109CueGasDebe = "";
         n109CueGasDebe = false;
         AssignAttri("", false, "A109CueGasDebe", A109CueGasDebe);
         A110CueGasHaber = "";
         n110CueGasHaber = false;
         AssignAttri("", false, "A110CueGasHaber", A110CueGasHaber);
         A868CueRef1 = 0;
         AssignAttri("", false, "A868CueRef1", StringUtil.Str( (decimal)(A868CueRef1), 1, 0));
         A869CueRef2 = 0;
         AssignAttri("", false, "A869CueRef2", StringUtil.Str( (decimal)(A869CueRef2), 1, 0));
         A870CueRef3 = 0;
         AssignAttri("", false, "A870CueRef3", StringUtil.Str( (decimal)(A870CueRef3), 1, 0));
         A871CueRef4 = 0;
         AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         A872CueRef5 = 0;
         AssignAttri("", false, "A872CueRef5", StringUtil.Str( (decimal)(A872CueRef5), 1, 0));
         A111CueMonDebe = "";
         n111CueMonDebe = false;
         AssignAttri("", false, "A111CueMonDebe", A111CueMonDebe);
         A112CueMonHaber = "";
         n112CueMonHaber = false;
         AssignAttri("", false, "A112CueMonHaber", A112CueMonHaber);
         A70TipACod = 0;
         n70TipACod = false;
         AssignAttri("", false, "A70TipACod", StringUtil.LTrimStr( (decimal)(A70TipACod), 6, 0));
         n70TipACod = ((0==A70TipACod) ? true : false);
         A863CueGrupDoc = 0;
         AssignAttri("", false, "A863CueGrupDoc", StringUtil.Str( (decimal)(A863CueGrupDoc), 1, 0));
         A113CueCierre = "";
         n113CueCierre = false;
         AssignAttri("", false, "A113CueCierre", A113CueCierre);
         A858CueCierreDsc = "";
         AssignAttri("", false, "A858CueCierreDsc", A858CueCierreDsc);
         Z860CueDsc = "";
         Z857CueAbr = "";
         Z867CueMov = 0;
         Z864CueMon = 0;
         Z859CueCos = 0;
         Z873CueSts = 0;
         Z868CueRef1 = 0;
         Z869CueRef2 = 0;
         Z870CueRef3 = 0;
         Z871CueRef4 = 0;
         Z872CueRef5 = 0;
         Z863CueGrupDoc = 0;
         Z70TipACod = 0;
         Z109CueGasDebe = "";
         Z110CueGasHaber = "";
         Z111CueMonDebe = "";
         Z112CueMonHaber = "";
         Z113CueCierre = "";
      }

      protected void InitAll1V64( )
      {
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         InitializeNonKey1V64( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024267", true, true);
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
         context.AddJavascriptSource("cbplancuenta.js", "?20228181024267", false, true);
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
         edtCueCod_Internalname = "CUECOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCueDsc_Internalname = "CUEDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCueAbr_Internalname = "CUEABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCueMov_Internalname = "CUEMOV";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCueMon_Internalname = "CUEMON";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCueCos_Internalname = "CUECOS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         cmbCueSts_Internalname = "CUESTS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCueGasDebe_Internalname = "CUEGASDEBE";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCueGasHaber_Internalname = "CUEGASHABER";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCueRef1_Internalname = "CUEREF1";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCueRef2_Internalname = "CUEREF2";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtCueRef3_Internalname = "CUEREF3";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         cmbCueRef4_Internalname = "CUEREF4";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtCueRef5_Internalname = "CUEREF5";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtCueMonDebe_Internalname = "CUEMONDEBE";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtCueMonHaber_Internalname = "CUEMONHABER";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtTipACod_Internalname = "TIPACOD";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtCueGrupDoc_Internalname = "CUEGRUPDOC";
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
         Form.Caption = "Plan de Cuentas";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCueGrupDoc_Jsonclick = "";
         edtCueGrupDoc_Enabled = 1;
         edtTipACod_Jsonclick = "";
         edtTipACod_Enabled = 1;
         edtCueMonHaber_Jsonclick = "";
         edtCueMonHaber_Enabled = 1;
         edtCueMonDebe_Jsonclick = "";
         edtCueMonDebe_Enabled = 1;
         edtCueRef5_Jsonclick = "";
         edtCueRef5_Enabled = 1;
         cmbCueRef4_Jsonclick = "";
         cmbCueRef4.Enabled = 1;
         edtCueRef3_Jsonclick = "";
         edtCueRef3_Enabled = 1;
         edtCueRef2_Jsonclick = "";
         edtCueRef2_Enabled = 1;
         edtCueRef1_Jsonclick = "";
         edtCueRef1_Enabled = 1;
         edtCueGasHaber_Jsonclick = "";
         edtCueGasHaber_Enabled = 1;
         edtCueGasDebe_Jsonclick = "";
         edtCueGasDebe_Enabled = 1;
         cmbCueSts_Jsonclick = "";
         cmbCueSts.Enabled = 1;
         edtCueCos_Jsonclick = "";
         edtCueCos_Enabled = 1;
         edtCueMon_Jsonclick = "";
         edtCueMon_Enabled = 1;
         edtCueMov_Jsonclick = "";
         edtCueMov_Enabled = 1;
         edtCueAbr_Jsonclick = "";
         edtCueAbr_Enabled = 1;
         edtCueDsc_Jsonclick = "";
         edtCueDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
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
         cmbCueSts.Name = "CUESTS";
         cmbCueSts.WebTags = "";
         cmbCueSts.addItem("1", "ACTIVO", 0);
         cmbCueSts.addItem("0", "INACTIVO", 0);
         if ( cmbCueSts.ItemCount > 0 )
         {
            A873CueSts = (short)(NumberUtil.Val( cmbCueSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0))), "."));
            AssignAttri("", false, "A873CueSts", StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         }
         cmbCueRef4.Name = "CUEREF4";
         cmbCueRef4.WebTags = "";
         cmbCueRef4.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "(Ninguno)", 0);
         cmbCueRef4.addItem("1", "Venta", 0);
         cmbCueRef4.addItem("2", "Compra", 0);
         if ( cmbCueRef4.ItemCount > 0 )
         {
            A871CueRef4 = (short)(NumberUtil.Val( cmbCueRef4.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0))), "."));
            AssignAttri("", false, "A871CueRef4", StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtCueDsc_Internalname;
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

      public void Valid_Cuecod( )
      {
         A871CueRef4 = (short)(NumberUtil.Val( cmbCueRef4.CurrentValue, "."));
         cmbCueRef4.CurrentValue = StringUtil.Str( (decimal)(A871CueRef4), 1, 0);
         A873CueSts = (short)(NumberUtil.Val( cmbCueSts.CurrentValue, "."));
         cmbCueSts.CurrentValue = StringUtil.Str( (decimal)(A873CueSts), 1, 0);
         n113CueCierre = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbCueSts.ItemCount > 0 )
         {
            A873CueSts = (short)(NumberUtil.Val( cmbCueSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0))), "."));
            cmbCueSts.CurrentValue = StringUtil.Str( (decimal)(A873CueSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         }
         if ( cmbCueRef4.ItemCount > 0 )
         {
            A871CueRef4 = (short)(NumberUtil.Val( cmbCueRef4.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0))), "."));
            cmbCueRef4.CurrentValue = StringUtil.Str( (decimal)(A871CueRef4), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCueRef4.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A860CueDsc", StringUtil.RTrim( A860CueDsc));
         AssignAttri("", false, "A857CueAbr", StringUtil.RTrim( A857CueAbr));
         AssignAttri("", false, "A867CueMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(A867CueMov), 1, 0, ".", "")));
         AssignAttri("", false, "A864CueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A864CueMon), 1, 0, ".", "")));
         AssignAttri("", false, "A859CueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A859CueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A873CueSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A873CueSts), 1, 0, ".", "")));
         cmbCueSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A873CueSts), 1, 0));
         AssignProp("", false, cmbCueSts_Internalname, "Values", cmbCueSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A109CueGasDebe", StringUtil.RTrim( A109CueGasDebe));
         AssignAttri("", false, "A110CueGasHaber", StringUtil.RTrim( A110CueGasHaber));
         AssignAttri("", false, "A868CueRef1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A868CueRef1), 1, 0, ".", "")));
         AssignAttri("", false, "A869CueRef2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A869CueRef2), 1, 0, ".", "")));
         AssignAttri("", false, "A870CueRef3", StringUtil.LTrim( StringUtil.NToC( (decimal)(A870CueRef3), 1, 0, ".", "")));
         AssignAttri("", false, "A871CueRef4", StringUtil.LTrim( StringUtil.NToC( (decimal)(A871CueRef4), 1, 0, ".", "")));
         cmbCueRef4.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A871CueRef4), 1, 0));
         AssignProp("", false, cmbCueRef4_Internalname, "Values", cmbCueRef4.ToJavascriptSource(), true);
         AssignAttri("", false, "A872CueRef5", StringUtil.LTrim( StringUtil.NToC( (decimal)(A872CueRef5), 1, 0, ".", "")));
         AssignAttri("", false, "A111CueMonDebe", StringUtil.RTrim( A111CueMonDebe));
         AssignAttri("", false, "A112CueMonHaber", StringUtil.RTrim( A112CueMonHaber));
         AssignAttri("", false, "A70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A70TipACod), 6, 0, ".", "")));
         AssignAttri("", false, "A863CueGrupDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(A863CueGrupDoc), 1, 0, ".", "")));
         AssignAttri("", false, "A113CueCierre", StringUtil.RTrim( A113CueCierre));
         AssignAttri("", false, "A858CueCierreDsc", StringUtil.RTrim( A858CueCierreDsc));
         AssignAttri("", false, "A2098CueDscCompleto", StringUtil.RTrim( A2098CueDscCompleto));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z860CueDsc", StringUtil.RTrim( Z860CueDsc));
         GxWebStd.gx_hidden_field( context, "Z857CueAbr", StringUtil.RTrim( Z857CueAbr));
         GxWebStd.gx_hidden_field( context, "Z867CueMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z867CueMov), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z864CueMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z864CueMon), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z859CueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z859CueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z873CueSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z873CueSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z109CueGasDebe", StringUtil.RTrim( Z109CueGasDebe));
         GxWebStd.gx_hidden_field( context, "Z110CueGasHaber", StringUtil.RTrim( Z110CueGasHaber));
         GxWebStd.gx_hidden_field( context, "Z868CueRef1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z868CueRef1), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z869CueRef2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z869CueRef2), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z870CueRef3", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z870CueRef3), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z871CueRef4", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z871CueRef4), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z872CueRef5", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z872CueRef5), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z111CueMonDebe", StringUtil.RTrim( Z111CueMonDebe));
         GxWebStd.gx_hidden_field( context, "Z112CueMonHaber", StringUtil.RTrim( Z112CueMonHaber));
         GxWebStd.gx_hidden_field( context, "Z70TipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70TipACod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z863CueGrupDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z863CueGrupDoc), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z113CueCierre", StringUtil.RTrim( Z113CueCierre));
         GxWebStd.gx_hidden_field( context, "Z858CueCierreDsc", StringUtil.RTrim( Z858CueCierreDsc));
         GxWebStd.gx_hidden_field( context, "Z2098CueDscCompleto", StringUtil.RTrim( Z2098CueDscCompleto));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuegasdebe( )
      {
         n109CueGasDebe = false;
         /* Using cursor T001V66 */
         pr_default.execute(64, new Object[] {n109CueGasDebe, A109CueGasDebe});
         if ( (pr_default.getStatus(64) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A109CueGasDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueGasDebe_Internalname;
            }
         }
         pr_default.close(64);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuegashaber( )
      {
         n110CueGasHaber = false;
         /* Using cursor T001V67 */
         pr_default.execute(65, new Object[] {n110CueGasHaber, A110CueGasHaber});
         if ( (pr_default.getStatus(65) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A110CueGasHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Gasto'.", "ForeignKeyNotFound", 1, "CUEGASHABER");
               AnyError = 1;
               GX_FocusControl = edtCueGasHaber_Internalname;
            }
         }
         pr_default.close(65);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuemondebe( )
      {
         n111CueMonDebe = false;
         /* Using cursor T001V68 */
         pr_default.execute(66, new Object[] {n111CueMonDebe, A111CueMonDebe});
         if ( (pr_default.getStatus(66) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A111CueMonDebe)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONDEBE");
               AnyError = 1;
               GX_FocusControl = edtCueMonDebe_Internalname;
            }
         }
         pr_default.close(66);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cuemonhaber( )
      {
         n112CueMonHaber = false;
         /* Using cursor T001V69 */
         pr_default.execute(67, new Object[] {n112CueMonHaber, A112CueMonHaber});
         if ( (pr_default.getStatus(67) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112CueMonHaber)) ) )
            {
               GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CUEMONHABER");
               AnyError = 1;
               GX_FocusControl = edtCueMonHaber_Internalname;
            }
         }
         pr_default.close(67);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tipacod( )
      {
         n70TipACod = false;
         /* Using cursor T001V70 */
         pr_default.execute(68, new Object[] {n70TipACod, A70TipACod});
         if ( (pr_default.getStatus(68) == 101) )
         {
            if ( ! ( (0==A70TipACod) ) )
            {
               GX_msglist.addItem("No existe 'Tipos de Auxiliar'.", "ForeignKeyNotFound", 1, "TIPACOD");
               AnyError = 1;
               GX_FocusControl = edtTipACod_Internalname;
            }
         }
         pr_default.close(68);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A113CueCierre',fld:'CUECIERRE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'cmbCueRef4'},{av:'A871CueRef4',fld:'CUEREF4',pic:'9'},{av:'cmbCueSts'},{av:'A873CueSts',fld:'CUESTS',pic:'9'},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A113CueCierre',fld:'CUECIERRE',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CUECOD",",oparms:[{av:'A860CueDsc',fld:'CUEDSC',pic:''},{av:'A857CueAbr',fld:'CUEABR',pic:''},{av:'A867CueMov',fld:'CUEMOV',pic:'9'},{av:'A864CueMon',fld:'CUEMON',pic:'9'},{av:'A859CueCos',fld:'CUECOS',pic:'9'},{av:'cmbCueSts'},{av:'A873CueSts',fld:'CUESTS',pic:'9'},{av:'A109CueGasDebe',fld:'CUEGASDEBE',pic:''},{av:'A110CueGasHaber',fld:'CUEGASHABER',pic:''},{av:'A868CueRef1',fld:'CUEREF1',pic:'9'},{av:'A869CueRef2',fld:'CUEREF2',pic:'9'},{av:'A870CueRef3',fld:'CUEREF3',pic:'9'},{av:'cmbCueRef4'},{av:'A871CueRef4',fld:'CUEREF4',pic:'9'},{av:'A872CueRef5',fld:'CUEREF5',pic:'9'},{av:'A111CueMonDebe',fld:'CUEMONDEBE',pic:''},{av:'A112CueMonHaber',fld:'CUEMONHABER',pic:''},{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'},{av:'A863CueGrupDoc',fld:'CUEGRUPDOC',pic:'9'},{av:'A113CueCierre',fld:'CUECIERRE',pic:''},{av:'A858CueCierreDsc',fld:'CUECIERREDSC',pic:''},{av:'A2098CueDscCompleto',fld:'CUEDSCCOMPLETO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z91CueCod'},{av:'Z860CueDsc'},{av:'Z857CueAbr'},{av:'Z867CueMov'},{av:'Z864CueMon'},{av:'Z859CueCos'},{av:'Z873CueSts'},{av:'Z109CueGasDebe'},{av:'Z110CueGasHaber'},{av:'Z868CueRef1'},{av:'Z869CueRef2'},{av:'Z870CueRef3'},{av:'Z871CueRef4'},{av:'Z872CueRef5'},{av:'Z111CueMonDebe'},{av:'Z112CueMonHaber'},{av:'Z70TipACod'},{av:'Z863CueGrupDoc'},{av:'Z113CueCierre'},{av:'Z858CueCierreDsc'},{av:'Z2098CueDscCompleto'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CUEDSC","{handler:'Valid_Cuedsc',iparms:[]");
         setEventMetadata("VALID_CUEDSC",",oparms:[]}");
         setEventMetadata("VALID_CUEGASDEBE","{handler:'Valid_Cuegasdebe',iparms:[{av:'A109CueGasDebe',fld:'CUEGASDEBE',pic:''}]");
         setEventMetadata("VALID_CUEGASDEBE",",oparms:[]}");
         setEventMetadata("VALID_CUEGASHABER","{handler:'Valid_Cuegashaber',iparms:[{av:'A110CueGasHaber',fld:'CUEGASHABER',pic:''}]");
         setEventMetadata("VALID_CUEGASHABER",",oparms:[]}");
         setEventMetadata("VALID_CUEMONDEBE","{handler:'Valid_Cuemondebe',iparms:[{av:'A111CueMonDebe',fld:'CUEMONDEBE',pic:''}]");
         setEventMetadata("VALID_CUEMONDEBE",",oparms:[]}");
         setEventMetadata("VALID_CUEMONHABER","{handler:'Valid_Cuemonhaber',iparms:[{av:'A112CueMonHaber',fld:'CUEMONHABER',pic:''}]");
         setEventMetadata("VALID_CUEMONHABER",",oparms:[]}");
         setEventMetadata("VALID_TIPACOD","{handler:'Valid_Tipacod',iparms:[{av:'A70TipACod',fld:'TIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TIPACOD",",oparms:[]}");
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
         pr_default.close(68);
         pr_default.close(64);
         pr_default.close(65);
         pr_default.close(66);
         pr_default.close(67);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z91CueCod = "";
         Z860CueDsc = "";
         Z857CueAbr = "";
         Z109CueGasDebe = "";
         Z110CueGasHaber = "";
         Z111CueMonDebe = "";
         Z112CueMonHaber = "";
         Z113CueCierre = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A109CueGasDebe = "";
         A110CueGasHaber = "";
         A111CueMonDebe = "";
         A112CueMonHaber = "";
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
         A91CueCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A860CueDsc = "";
         lblTextblock3_Jsonclick = "";
         A857CueAbr = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A113CueCierre = "";
         Gx_mode = "";
         A2098CueDscCompleto = "";
         A858CueCierreDsc = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z858CueCierreDsc = "";
         T001V9_A858CueCierreDsc = new string[] {""} ;
         T001V10_A91CueCod = new string[] {""} ;
         T001V10_A860CueDsc = new string[] {""} ;
         T001V10_A857CueAbr = new string[] {""} ;
         T001V10_n857CueAbr = new bool[] {false} ;
         T001V10_A867CueMov = new short[1] ;
         T001V10_A864CueMon = new short[1] ;
         T001V10_A859CueCos = new short[1] ;
         T001V10_A873CueSts = new short[1] ;
         T001V10_A868CueRef1 = new short[1] ;
         T001V10_A869CueRef2 = new short[1] ;
         T001V10_A870CueRef3 = new short[1] ;
         T001V10_A871CueRef4 = new short[1] ;
         T001V10_A872CueRef5 = new short[1] ;
         T001V10_A863CueGrupDoc = new short[1] ;
         T001V10_A858CueCierreDsc = new string[] {""} ;
         T001V10_A70TipACod = new int[1] ;
         T001V10_n70TipACod = new bool[] {false} ;
         T001V10_A109CueGasDebe = new string[] {""} ;
         T001V10_n109CueGasDebe = new bool[] {false} ;
         T001V10_A110CueGasHaber = new string[] {""} ;
         T001V10_n110CueGasHaber = new bool[] {false} ;
         T001V10_A111CueMonDebe = new string[] {""} ;
         T001V10_n111CueMonDebe = new bool[] {false} ;
         T001V10_A112CueMonHaber = new string[] {""} ;
         T001V10_n112CueMonHaber = new bool[] {false} ;
         T001V10_A113CueCierre = new string[] {""} ;
         T001V10_n113CueCierre = new bool[] {false} ;
         T001V5_A109CueGasDebe = new string[] {""} ;
         T001V5_n109CueGasDebe = new bool[] {false} ;
         T001V6_A110CueGasHaber = new string[] {""} ;
         T001V6_n110CueGasHaber = new bool[] {false} ;
         T001V7_A111CueMonDebe = new string[] {""} ;
         T001V7_n111CueMonDebe = new bool[] {false} ;
         T001V8_A112CueMonHaber = new string[] {""} ;
         T001V8_n112CueMonHaber = new bool[] {false} ;
         T001V4_A70TipACod = new int[1] ;
         T001V4_n70TipACod = new bool[] {false} ;
         T001V11_A109CueGasDebe = new string[] {""} ;
         T001V11_n109CueGasDebe = new bool[] {false} ;
         T001V12_A110CueGasHaber = new string[] {""} ;
         T001V12_n110CueGasHaber = new bool[] {false} ;
         T001V13_A111CueMonDebe = new string[] {""} ;
         T001V13_n111CueMonDebe = new bool[] {false} ;
         T001V14_A112CueMonHaber = new string[] {""} ;
         T001V14_n112CueMonHaber = new bool[] {false} ;
         T001V15_A70TipACod = new int[1] ;
         T001V15_n70TipACod = new bool[] {false} ;
         T001V16_A91CueCod = new string[] {""} ;
         T001V3_A91CueCod = new string[] {""} ;
         T001V3_A860CueDsc = new string[] {""} ;
         T001V3_A857CueAbr = new string[] {""} ;
         T001V3_n857CueAbr = new bool[] {false} ;
         T001V3_A867CueMov = new short[1] ;
         T001V3_A864CueMon = new short[1] ;
         T001V3_A859CueCos = new short[1] ;
         T001V3_A873CueSts = new short[1] ;
         T001V3_A868CueRef1 = new short[1] ;
         T001V3_A869CueRef2 = new short[1] ;
         T001V3_A870CueRef3 = new short[1] ;
         T001V3_A871CueRef4 = new short[1] ;
         T001V3_A872CueRef5 = new short[1] ;
         T001V3_A863CueGrupDoc = new short[1] ;
         T001V3_A70TipACod = new int[1] ;
         T001V3_n70TipACod = new bool[] {false} ;
         T001V3_A109CueGasDebe = new string[] {""} ;
         T001V3_n109CueGasDebe = new bool[] {false} ;
         T001V3_A110CueGasHaber = new string[] {""} ;
         T001V3_n110CueGasHaber = new bool[] {false} ;
         T001V3_A111CueMonDebe = new string[] {""} ;
         T001V3_n111CueMonDebe = new bool[] {false} ;
         T001V3_A112CueMonHaber = new string[] {""} ;
         T001V3_n112CueMonHaber = new bool[] {false} ;
         T001V3_A113CueCierre = new string[] {""} ;
         T001V3_n113CueCierre = new bool[] {false} ;
         sMode64 = "";
         T001V17_A91CueCod = new string[] {""} ;
         T001V18_A91CueCod = new string[] {""} ;
         T001V2_A91CueCod = new string[] {""} ;
         T001V2_A860CueDsc = new string[] {""} ;
         T001V2_A857CueAbr = new string[] {""} ;
         T001V2_n857CueAbr = new bool[] {false} ;
         T001V2_A867CueMov = new short[1] ;
         T001V2_A864CueMon = new short[1] ;
         T001V2_A859CueCos = new short[1] ;
         T001V2_A873CueSts = new short[1] ;
         T001V2_A868CueRef1 = new short[1] ;
         T001V2_A869CueRef2 = new short[1] ;
         T001V2_A870CueRef3 = new short[1] ;
         T001V2_A871CueRef4 = new short[1] ;
         T001V2_A872CueRef5 = new short[1] ;
         T001V2_A863CueGrupDoc = new short[1] ;
         T001V2_A70TipACod = new int[1] ;
         T001V2_n70TipACod = new bool[] {false} ;
         T001V2_A109CueGasDebe = new string[] {""} ;
         T001V2_n109CueGasDebe = new bool[] {false} ;
         T001V2_A110CueGasHaber = new string[] {""} ;
         T001V2_n110CueGasHaber = new bool[] {false} ;
         T001V2_A111CueMonDebe = new string[] {""} ;
         T001V2_n111CueMonDebe = new bool[] {false} ;
         T001V2_A112CueMonHaber = new string[] {""} ;
         T001V2_n112CueMonHaber = new bool[] {false} ;
         T001V2_A113CueCierre = new string[] {""} ;
         T001V2_n113CueCierre = new bool[] {false} ;
         T001V22_A113CueCierre = new string[] {""} ;
         T001V22_n113CueCierre = new bool[] {false} ;
         T001V23_A112CueMonHaber = new string[] {""} ;
         T001V23_n112CueMonHaber = new bool[] {false} ;
         T001V24_A111CueMonDebe = new string[] {""} ;
         T001V24_n111CueMonDebe = new bool[] {false} ;
         T001V25_A110CueGasHaber = new string[] {""} ;
         T001V25_n110CueGasHaber = new bool[] {false} ;
         T001V26_A109CueGasDebe = new string[] {""} ;
         T001V26_n109CueGasDebe = new bool[] {false} ;
         T001V27_A365EntCod = new int[1] ;
         T001V27_A403MVLEntCod = new string[] {""} ;
         T001V27_A404MVLEITem = new int[1] ;
         T001V28_A358CajCod = new int[1] ;
         T001V28_A391MVLCajCod = new string[] {""} ;
         T001V28_A392MVLITem = new int[1] ;
         T001V29_A372BanCod = new int[1] ;
         T001V29_A377CBCod = new string[] {""} ;
         T001V30_A355ConBCod = new int[1] ;
         T001V31_A332PSerConcCod = new int[1] ;
         T001V31_A333PSerDConcCueCod = new string[] {""} ;
         T001V32_A313PoConcCod = new int[1] ;
         T001V32_A315PoConcDCueCod = new string[] {""} ;
         T001V33_A149TipCod = new string[] {""} ;
         T001V33_A243ComCod = new string[] {""} ;
         T001V33_A244PrvCod = new string[] {""} ;
         T001V33_A250ComDItem = new short[1] ;
         T001V33_A251ComDOrdCod = new string[] {""} ;
         T001V34_A121SalVouAno = new short[1] ;
         T001V34_A122SalVouMes = new short[1] ;
         T001V34_A123SalCueCod = new string[] {""} ;
         T001V34_A124SalMonCod = new int[1] ;
         T001V34_A125SalCueAux = new string[] {""} ;
         T001V35_A83ParTip = new string[] {""} ;
         T001V35_A84ParCod = new int[1] ;
         T001V35_A104ParDItem = new short[1] ;
         T001V36_A83ParTip = new string[] {""} ;
         T001V36_A84ParCod = new int[1] ;
         T001V36_A104ParDItem = new short[1] ;
         T001V37_A83ParTip = new string[] {""} ;
         T001V37_A84ParCod = new int[1] ;
         T001V38_A83ParTip = new string[] {""} ;
         T001V38_A84ParCod = new int[1] ;
         T001V39_A83ParTip = new string[] {""} ;
         T001V39_A84ParCod = new int[1] ;
         T001V40_A83ParTip = new string[] {""} ;
         T001V40_A84ParCod = new int[1] ;
         T001V41_A83ParTip = new string[] {""} ;
         T001V41_A84ParCod = new int[1] ;
         T001V42_A83ParTip = new string[] {""} ;
         T001V42_A84ParCod = new int[1] ;
         T001V43_A83ParTip = new string[] {""} ;
         T001V43_A84ParCod = new int[1] ;
         T001V44_A83ParTip = new string[] {""} ;
         T001V44_A84ParCod = new int[1] ;
         T001V45_A83ParTip = new string[] {""} ;
         T001V45_A84ParCod = new int[1] ;
         T001V46_A83ParTip = new string[] {""} ;
         T001V46_A84ParCod = new int[1] ;
         T001V47_A2280CBTipPre = new int[1] ;
         T001V47_A2281CBTipTipo = new string[] {""} ;
         T001V47_A2282CBLinPre = new int[1] ;
         T001V47_A2283CBRubPre = new int[1] ;
         T001V47_A2284CBRubDItem = new int[1] ;
         T001V48_A83ParTip = new string[] {""} ;
         T001V48_A84ParCod = new int[1] ;
         T001V48_A90ParDTipItem = new int[1] ;
         T001V49_A365EntCod = new int[1] ;
         T001V50_A376ConEntCod = new int[1] ;
         T001V51_A375ConCajCod = new int[1] ;
         T001V52_A358CajCod = new int[1] ;
         T001V53_A236LiqPrvCod = new string[] {""} ;
         T001V54_A127VouAno = new short[1] ;
         T001V54_A128VouMes = new short[1] ;
         T001V54_A126TASICod = new int[1] ;
         T001V54_A129VouNum = new string[] {""} ;
         T001V54_A130VouDSec = new int[1] ;
         T001V55_A114TotTipo = new string[] {""} ;
         T001V55_A115TotRub = new int[1] ;
         T001V55_A116RubCod = new int[1] ;
         T001V55_A118RubLinCod = new int[1] ;
         T001V55_A91CueCod = new string[] {""} ;
         T001V56_A83ParTip = new string[] {""} ;
         T001V56_A84ParCod = new int[1] ;
         T001V56_A85ParDActItem = new int[1] ;
         T001V57_A83ParTip = new string[] {""} ;
         T001V57_A84ParCod = new int[1] ;
         T001V57_A85ParDActItem = new int[1] ;
         T001V58_A83ParTip = new string[] {""} ;
         T001V58_A84ParCod = new int[1] ;
         T001V58_A85ParDActItem = new int[1] ;
         T001V59_A83ParTip = new string[] {""} ;
         T001V59_A84ParCod = new int[1] ;
         T001V59_A85ParDActItem = new int[1] ;
         T001V60_A79COSCod = new string[] {""} ;
         T001V61_A76CConpCod = new int[1] ;
         T001V62_A28ProdCod = new string[] {""} ;
         T001V63_A28ProdCod = new string[] {""} ;
         T001V64_A28ProdCod = new string[] {""} ;
         T001V65_A91CueCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z2098CueDscCompleto = "";
         ZZ91CueCod = "";
         ZZ860CueDsc = "";
         ZZ857CueAbr = "";
         ZZ109CueGasDebe = "";
         ZZ110CueGasHaber = "";
         ZZ111CueMonDebe = "";
         ZZ112CueMonHaber = "";
         ZZ113CueCierre = "";
         ZZ858CueCierreDsc = "";
         ZZ2098CueDscCompleto = "";
         T001V66_A109CueGasDebe = new string[] {""} ;
         T001V66_n109CueGasDebe = new bool[] {false} ;
         T001V67_A110CueGasHaber = new string[] {""} ;
         T001V67_n110CueGasHaber = new bool[] {false} ;
         T001V68_A111CueMonDebe = new string[] {""} ;
         T001V68_n111CueMonDebe = new bool[] {false} ;
         T001V69_A112CueMonHaber = new string[] {""} ;
         T001V69_n112CueMonHaber = new bool[] {false} ;
         T001V70_A70TipACod = new int[1] ;
         T001V70_n70TipACod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbplancuenta__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbplancuenta__default(),
            new Object[][] {
                new Object[] {
               T001V2_A91CueCod, T001V2_A860CueDsc, T001V2_A857CueAbr, T001V2_n857CueAbr, T001V2_A867CueMov, T001V2_A864CueMon, T001V2_A859CueCos, T001V2_A873CueSts, T001V2_A868CueRef1, T001V2_A869CueRef2,
               T001V2_A870CueRef3, T001V2_A871CueRef4, T001V2_A872CueRef5, T001V2_A863CueGrupDoc, T001V2_A70TipACod, T001V2_n70TipACod, T001V2_A109CueGasDebe, T001V2_n109CueGasDebe, T001V2_A110CueGasHaber, T001V2_n110CueGasHaber,
               T001V2_A111CueMonDebe, T001V2_n111CueMonDebe, T001V2_A112CueMonHaber, T001V2_n112CueMonHaber, T001V2_A113CueCierre, T001V2_n113CueCierre
               }
               , new Object[] {
               T001V3_A91CueCod, T001V3_A860CueDsc, T001V3_A857CueAbr, T001V3_n857CueAbr, T001V3_A867CueMov, T001V3_A864CueMon, T001V3_A859CueCos, T001V3_A873CueSts, T001V3_A868CueRef1, T001V3_A869CueRef2,
               T001V3_A870CueRef3, T001V3_A871CueRef4, T001V3_A872CueRef5, T001V3_A863CueGrupDoc, T001V3_A70TipACod, T001V3_n70TipACod, T001V3_A109CueGasDebe, T001V3_n109CueGasDebe, T001V3_A110CueGasHaber, T001V3_n110CueGasHaber,
               T001V3_A111CueMonDebe, T001V3_n111CueMonDebe, T001V3_A112CueMonHaber, T001V3_n112CueMonHaber, T001V3_A113CueCierre, T001V3_n113CueCierre
               }
               , new Object[] {
               T001V4_A70TipACod
               }
               , new Object[] {
               T001V5_A109CueGasDebe
               }
               , new Object[] {
               T001V6_A110CueGasHaber
               }
               , new Object[] {
               T001V7_A111CueMonDebe
               }
               , new Object[] {
               T001V8_A112CueMonHaber
               }
               , new Object[] {
               T001V9_A858CueCierreDsc
               }
               , new Object[] {
               T001V10_A91CueCod, T001V10_A860CueDsc, T001V10_A857CueAbr, T001V10_n857CueAbr, T001V10_A867CueMov, T001V10_A864CueMon, T001V10_A859CueCos, T001V10_A873CueSts, T001V10_A868CueRef1, T001V10_A869CueRef2,
               T001V10_A870CueRef3, T001V10_A871CueRef4, T001V10_A872CueRef5, T001V10_A863CueGrupDoc, T001V10_A858CueCierreDsc, T001V10_A70TipACod, T001V10_n70TipACod, T001V10_A109CueGasDebe, T001V10_n109CueGasDebe, T001V10_A110CueGasHaber,
               T001V10_n110CueGasHaber, T001V10_A111CueMonDebe, T001V10_n111CueMonDebe, T001V10_A112CueMonHaber, T001V10_n112CueMonHaber, T001V10_A113CueCierre, T001V10_n113CueCierre
               }
               , new Object[] {
               T001V11_A109CueGasDebe
               }
               , new Object[] {
               T001V12_A110CueGasHaber
               }
               , new Object[] {
               T001V13_A111CueMonDebe
               }
               , new Object[] {
               T001V14_A112CueMonHaber
               }
               , new Object[] {
               T001V15_A70TipACod
               }
               , new Object[] {
               T001V16_A91CueCod
               }
               , new Object[] {
               T001V17_A91CueCod
               }
               , new Object[] {
               T001V18_A91CueCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001V22_A113CueCierre
               }
               , new Object[] {
               T001V23_A112CueMonHaber
               }
               , new Object[] {
               T001V24_A111CueMonDebe
               }
               , new Object[] {
               T001V25_A110CueGasHaber
               }
               , new Object[] {
               T001V26_A109CueGasDebe
               }
               , new Object[] {
               T001V27_A365EntCod, T001V27_A403MVLEntCod, T001V27_A404MVLEITem
               }
               , new Object[] {
               T001V28_A358CajCod, T001V28_A391MVLCajCod, T001V28_A392MVLITem
               }
               , new Object[] {
               T001V29_A372BanCod, T001V29_A377CBCod
               }
               , new Object[] {
               T001V30_A355ConBCod
               }
               , new Object[] {
               T001V31_A332PSerConcCod, T001V31_A333PSerDConcCueCod
               }
               , new Object[] {
               T001V32_A313PoConcCod, T001V32_A315PoConcDCueCod
               }
               , new Object[] {
               T001V33_A149TipCod, T001V33_A243ComCod, T001V33_A244PrvCod, T001V33_A250ComDItem, T001V33_A251ComDOrdCod
               }
               , new Object[] {
               T001V34_A121SalVouAno, T001V34_A122SalVouMes, T001V34_A123SalCueCod, T001V34_A124SalMonCod, T001V34_A125SalCueAux
               }
               , new Object[] {
               T001V35_A83ParTip, T001V35_A84ParCod, T001V35_A104ParDItem
               }
               , new Object[] {
               T001V36_A83ParTip, T001V36_A84ParCod, T001V36_A104ParDItem
               }
               , new Object[] {
               T001V37_A83ParTip, T001V37_A84ParCod
               }
               , new Object[] {
               T001V38_A83ParTip, T001V38_A84ParCod
               }
               , new Object[] {
               T001V39_A83ParTip, T001V39_A84ParCod
               }
               , new Object[] {
               T001V40_A83ParTip, T001V40_A84ParCod
               }
               , new Object[] {
               T001V41_A83ParTip, T001V41_A84ParCod
               }
               , new Object[] {
               T001V42_A83ParTip, T001V42_A84ParCod
               }
               , new Object[] {
               T001V43_A83ParTip, T001V43_A84ParCod
               }
               , new Object[] {
               T001V44_A83ParTip, T001V44_A84ParCod
               }
               , new Object[] {
               T001V45_A83ParTip, T001V45_A84ParCod
               }
               , new Object[] {
               T001V46_A83ParTip, T001V46_A84ParCod
               }
               , new Object[] {
               T001V47_A2280CBTipPre, T001V47_A2281CBTipTipo, T001V47_A2282CBLinPre, T001V47_A2283CBRubPre, T001V47_A2284CBRubDItem
               }
               , new Object[] {
               T001V48_A83ParTip, T001V48_A84ParCod, T001V48_A90ParDTipItem
               }
               , new Object[] {
               T001V49_A365EntCod
               }
               , new Object[] {
               T001V50_A376ConEntCod
               }
               , new Object[] {
               T001V51_A375ConCajCod
               }
               , new Object[] {
               T001V52_A358CajCod
               }
               , new Object[] {
               T001V53_A236LiqPrvCod
               }
               , new Object[] {
               T001V54_A127VouAno, T001V54_A128VouMes, T001V54_A126TASICod, T001V54_A129VouNum, T001V54_A130VouDSec
               }
               , new Object[] {
               T001V55_A114TotTipo, T001V55_A115TotRub, T001V55_A116RubCod, T001V55_A118RubLinCod, T001V55_A91CueCod
               }
               , new Object[] {
               T001V56_A83ParTip, T001V56_A84ParCod, T001V56_A85ParDActItem
               }
               , new Object[] {
               T001V57_A83ParTip, T001V57_A84ParCod, T001V57_A85ParDActItem
               }
               , new Object[] {
               T001V58_A83ParTip, T001V58_A84ParCod, T001V58_A85ParDActItem
               }
               , new Object[] {
               T001V59_A83ParTip, T001V59_A84ParCod, T001V59_A85ParDActItem
               }
               , new Object[] {
               T001V60_A79COSCod
               }
               , new Object[] {
               T001V61_A76CConpCod
               }
               , new Object[] {
               T001V62_A28ProdCod
               }
               , new Object[] {
               T001V63_A28ProdCod
               }
               , new Object[] {
               T001V64_A28ProdCod
               }
               , new Object[] {
               T001V65_A91CueCod
               }
               , new Object[] {
               T001V66_A109CueGasDebe
               }
               , new Object[] {
               T001V67_A110CueGasHaber
               }
               , new Object[] {
               T001V68_A111CueMonDebe
               }
               , new Object[] {
               T001V69_A112CueMonHaber
               }
               , new Object[] {
               T001V70_A70TipACod
               }
            }
         );
      }

      private short Z867CueMov ;
      private short Z864CueMon ;
      private short Z859CueCos ;
      private short Z873CueSts ;
      private short Z868CueRef1 ;
      private short Z869CueRef2 ;
      private short Z870CueRef3 ;
      private short Z871CueRef4 ;
      private short Z872CueRef5 ;
      private short Z863CueGrupDoc ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A873CueSts ;
      private short A871CueRef4 ;
      private short A867CueMov ;
      private short A864CueMon ;
      private short A859CueCos ;
      private short A868CueRef1 ;
      private short A869CueRef2 ;
      private short A870CueRef3 ;
      private short A872CueRef5 ;
      private short A863CueGrupDoc ;
      private short GX_JID ;
      private short RcdFound64 ;
      private short nIsDirty_64 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ867CueMov ;
      private short ZZ864CueMon ;
      private short ZZ859CueCos ;
      private short ZZ873CueSts ;
      private short ZZ868CueRef1 ;
      private short ZZ869CueRef2 ;
      private short ZZ870CueRef3 ;
      private short ZZ871CueRef4 ;
      private short ZZ872CueRef5 ;
      private short ZZ863CueGrupDoc ;
      private int Z70TipACod ;
      private int A70TipACod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCueCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCueDsc_Enabled ;
      private int edtCueAbr_Enabled ;
      private int edtCueMov_Enabled ;
      private int edtCueMon_Enabled ;
      private int edtCueCos_Enabled ;
      private int edtCueGasDebe_Enabled ;
      private int edtCueGasHaber_Enabled ;
      private int edtCueRef1_Enabled ;
      private int edtCueRef2_Enabled ;
      private int edtCueRef3_Enabled ;
      private int edtCueRef5_Enabled ;
      private int edtCueMonDebe_Enabled ;
      private int edtCueMonHaber_Enabled ;
      private int edtTipACod_Enabled ;
      private int edtCueGrupDoc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ70TipACod ;
      private string sPrefix ;
      private string Z91CueCod ;
      private string Z860CueDsc ;
      private string Z857CueAbr ;
      private string Z109CueGasDebe ;
      private string Z110CueGasHaber ;
      private string Z111CueMonDebe ;
      private string Z112CueMonHaber ;
      private string Z113CueCierre ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
      private string A111CueMonDebe ;
      private string A112CueMonHaber ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCueCod_Internalname ;
      private string cmbCueSts_Internalname ;
      private string cmbCueRef4_Internalname ;
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
      private string A91CueCod ;
      private string edtCueCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCueDsc_Internalname ;
      private string A860CueDsc ;
      private string edtCueDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCueAbr_Internalname ;
      private string A857CueAbr ;
      private string edtCueAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCueMov_Internalname ;
      private string edtCueMov_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCueMon_Internalname ;
      private string edtCueMon_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCueCos_Internalname ;
      private string edtCueCos_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string cmbCueSts_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCueGasDebe_Internalname ;
      private string edtCueGasDebe_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCueGasHaber_Internalname ;
      private string edtCueGasHaber_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCueRef1_Internalname ;
      private string edtCueRef1_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCueRef2_Internalname ;
      private string edtCueRef2_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtCueRef3_Internalname ;
      private string edtCueRef3_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string cmbCueRef4_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtCueRef5_Internalname ;
      private string edtCueRef5_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtCueMonDebe_Internalname ;
      private string edtCueMonDebe_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtCueMonHaber_Internalname ;
      private string edtCueMonHaber_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtTipACod_Internalname ;
      private string edtTipACod_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtCueGrupDoc_Internalname ;
      private string edtCueGrupDoc_Jsonclick ;
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
      private string A113CueCierre ;
      private string Gx_mode ;
      private string A2098CueDscCompleto ;
      private string A858CueCierreDsc ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z858CueCierreDsc ;
      private string sMode64 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string Z2098CueDscCompleto ;
      private string ZZ91CueCod ;
      private string ZZ860CueDsc ;
      private string ZZ857CueAbr ;
      private string ZZ109CueGasDebe ;
      private string ZZ110CueGasHaber ;
      private string ZZ111CueMonDebe ;
      private string ZZ112CueMonHaber ;
      private string ZZ113CueCierre ;
      private string ZZ858CueCierreDsc ;
      private string ZZ2098CueDscCompleto ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n109CueGasDebe ;
      private bool n110CueGasHaber ;
      private bool n111CueMonDebe ;
      private bool n112CueMonHaber ;
      private bool n70TipACod ;
      private bool wbErr ;
      private bool n113CueCierre ;
      private bool n857CueAbr ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCueSts ;
      private GXCombobox cmbCueRef4 ;
      private IDataStoreProvider pr_default ;
      private string[] T001V9_A858CueCierreDsc ;
      private string[] T001V10_A91CueCod ;
      private string[] T001V10_A860CueDsc ;
      private string[] T001V10_A857CueAbr ;
      private bool[] T001V10_n857CueAbr ;
      private short[] T001V10_A867CueMov ;
      private short[] T001V10_A864CueMon ;
      private short[] T001V10_A859CueCos ;
      private short[] T001V10_A873CueSts ;
      private short[] T001V10_A868CueRef1 ;
      private short[] T001V10_A869CueRef2 ;
      private short[] T001V10_A870CueRef3 ;
      private short[] T001V10_A871CueRef4 ;
      private short[] T001V10_A872CueRef5 ;
      private short[] T001V10_A863CueGrupDoc ;
      private string[] T001V10_A858CueCierreDsc ;
      private int[] T001V10_A70TipACod ;
      private bool[] T001V10_n70TipACod ;
      private string[] T001V10_A109CueGasDebe ;
      private bool[] T001V10_n109CueGasDebe ;
      private string[] T001V10_A110CueGasHaber ;
      private bool[] T001V10_n110CueGasHaber ;
      private string[] T001V10_A111CueMonDebe ;
      private bool[] T001V10_n111CueMonDebe ;
      private string[] T001V10_A112CueMonHaber ;
      private bool[] T001V10_n112CueMonHaber ;
      private string[] T001V10_A113CueCierre ;
      private bool[] T001V10_n113CueCierre ;
      private string[] T001V5_A109CueGasDebe ;
      private bool[] T001V5_n109CueGasDebe ;
      private string[] T001V6_A110CueGasHaber ;
      private bool[] T001V6_n110CueGasHaber ;
      private string[] T001V7_A111CueMonDebe ;
      private bool[] T001V7_n111CueMonDebe ;
      private string[] T001V8_A112CueMonHaber ;
      private bool[] T001V8_n112CueMonHaber ;
      private int[] T001V4_A70TipACod ;
      private bool[] T001V4_n70TipACod ;
      private string[] T001V11_A109CueGasDebe ;
      private bool[] T001V11_n109CueGasDebe ;
      private string[] T001V12_A110CueGasHaber ;
      private bool[] T001V12_n110CueGasHaber ;
      private string[] T001V13_A111CueMonDebe ;
      private bool[] T001V13_n111CueMonDebe ;
      private string[] T001V14_A112CueMonHaber ;
      private bool[] T001V14_n112CueMonHaber ;
      private int[] T001V15_A70TipACod ;
      private bool[] T001V15_n70TipACod ;
      private string[] T001V16_A91CueCod ;
      private string[] T001V3_A91CueCod ;
      private string[] T001V3_A860CueDsc ;
      private string[] T001V3_A857CueAbr ;
      private bool[] T001V3_n857CueAbr ;
      private short[] T001V3_A867CueMov ;
      private short[] T001V3_A864CueMon ;
      private short[] T001V3_A859CueCos ;
      private short[] T001V3_A873CueSts ;
      private short[] T001V3_A868CueRef1 ;
      private short[] T001V3_A869CueRef2 ;
      private short[] T001V3_A870CueRef3 ;
      private short[] T001V3_A871CueRef4 ;
      private short[] T001V3_A872CueRef5 ;
      private short[] T001V3_A863CueGrupDoc ;
      private int[] T001V3_A70TipACod ;
      private bool[] T001V3_n70TipACod ;
      private string[] T001V3_A109CueGasDebe ;
      private bool[] T001V3_n109CueGasDebe ;
      private string[] T001V3_A110CueGasHaber ;
      private bool[] T001V3_n110CueGasHaber ;
      private string[] T001V3_A111CueMonDebe ;
      private bool[] T001V3_n111CueMonDebe ;
      private string[] T001V3_A112CueMonHaber ;
      private bool[] T001V3_n112CueMonHaber ;
      private string[] T001V3_A113CueCierre ;
      private bool[] T001V3_n113CueCierre ;
      private string[] T001V17_A91CueCod ;
      private string[] T001V18_A91CueCod ;
      private string[] T001V2_A91CueCod ;
      private string[] T001V2_A860CueDsc ;
      private string[] T001V2_A857CueAbr ;
      private bool[] T001V2_n857CueAbr ;
      private short[] T001V2_A867CueMov ;
      private short[] T001V2_A864CueMon ;
      private short[] T001V2_A859CueCos ;
      private short[] T001V2_A873CueSts ;
      private short[] T001V2_A868CueRef1 ;
      private short[] T001V2_A869CueRef2 ;
      private short[] T001V2_A870CueRef3 ;
      private short[] T001V2_A871CueRef4 ;
      private short[] T001V2_A872CueRef5 ;
      private short[] T001V2_A863CueGrupDoc ;
      private int[] T001V2_A70TipACod ;
      private bool[] T001V2_n70TipACod ;
      private string[] T001V2_A109CueGasDebe ;
      private bool[] T001V2_n109CueGasDebe ;
      private string[] T001V2_A110CueGasHaber ;
      private bool[] T001V2_n110CueGasHaber ;
      private string[] T001V2_A111CueMonDebe ;
      private bool[] T001V2_n111CueMonDebe ;
      private string[] T001V2_A112CueMonHaber ;
      private bool[] T001V2_n112CueMonHaber ;
      private string[] T001V2_A113CueCierre ;
      private bool[] T001V2_n113CueCierre ;
      private string[] T001V22_A113CueCierre ;
      private bool[] T001V22_n113CueCierre ;
      private string[] T001V23_A112CueMonHaber ;
      private bool[] T001V23_n112CueMonHaber ;
      private string[] T001V24_A111CueMonDebe ;
      private bool[] T001V24_n111CueMonDebe ;
      private string[] T001V25_A110CueGasHaber ;
      private bool[] T001V25_n110CueGasHaber ;
      private string[] T001V26_A109CueGasDebe ;
      private bool[] T001V26_n109CueGasDebe ;
      private int[] T001V27_A365EntCod ;
      private string[] T001V27_A403MVLEntCod ;
      private int[] T001V27_A404MVLEITem ;
      private int[] T001V28_A358CajCod ;
      private string[] T001V28_A391MVLCajCod ;
      private int[] T001V28_A392MVLITem ;
      private int[] T001V29_A372BanCod ;
      private string[] T001V29_A377CBCod ;
      private int[] T001V30_A355ConBCod ;
      private int[] T001V31_A332PSerConcCod ;
      private string[] T001V31_A333PSerDConcCueCod ;
      private int[] T001V32_A313PoConcCod ;
      private string[] T001V32_A315PoConcDCueCod ;
      private string[] T001V33_A149TipCod ;
      private string[] T001V33_A243ComCod ;
      private string[] T001V33_A244PrvCod ;
      private short[] T001V33_A250ComDItem ;
      private string[] T001V33_A251ComDOrdCod ;
      private short[] T001V34_A121SalVouAno ;
      private short[] T001V34_A122SalVouMes ;
      private string[] T001V34_A123SalCueCod ;
      private int[] T001V34_A124SalMonCod ;
      private string[] T001V34_A125SalCueAux ;
      private string[] T001V35_A83ParTip ;
      private int[] T001V35_A84ParCod ;
      private short[] T001V35_A104ParDItem ;
      private string[] T001V36_A83ParTip ;
      private int[] T001V36_A84ParCod ;
      private short[] T001V36_A104ParDItem ;
      private string[] T001V37_A83ParTip ;
      private int[] T001V37_A84ParCod ;
      private string[] T001V38_A83ParTip ;
      private int[] T001V38_A84ParCod ;
      private string[] T001V39_A83ParTip ;
      private int[] T001V39_A84ParCod ;
      private string[] T001V40_A83ParTip ;
      private int[] T001V40_A84ParCod ;
      private string[] T001V41_A83ParTip ;
      private int[] T001V41_A84ParCod ;
      private string[] T001V42_A83ParTip ;
      private int[] T001V42_A84ParCod ;
      private string[] T001V43_A83ParTip ;
      private int[] T001V43_A84ParCod ;
      private string[] T001V44_A83ParTip ;
      private int[] T001V44_A84ParCod ;
      private string[] T001V45_A83ParTip ;
      private int[] T001V45_A84ParCod ;
      private string[] T001V46_A83ParTip ;
      private int[] T001V46_A84ParCod ;
      private int[] T001V47_A2280CBTipPre ;
      private string[] T001V47_A2281CBTipTipo ;
      private int[] T001V47_A2282CBLinPre ;
      private int[] T001V47_A2283CBRubPre ;
      private int[] T001V47_A2284CBRubDItem ;
      private string[] T001V48_A83ParTip ;
      private int[] T001V48_A84ParCod ;
      private int[] T001V48_A90ParDTipItem ;
      private int[] T001V49_A365EntCod ;
      private int[] T001V50_A376ConEntCod ;
      private int[] T001V51_A375ConCajCod ;
      private int[] T001V52_A358CajCod ;
      private string[] T001V53_A236LiqPrvCod ;
      private short[] T001V54_A127VouAno ;
      private short[] T001V54_A128VouMes ;
      private int[] T001V54_A126TASICod ;
      private string[] T001V54_A129VouNum ;
      private int[] T001V54_A130VouDSec ;
      private string[] T001V55_A114TotTipo ;
      private int[] T001V55_A115TotRub ;
      private int[] T001V55_A116RubCod ;
      private int[] T001V55_A118RubLinCod ;
      private string[] T001V55_A91CueCod ;
      private string[] T001V56_A83ParTip ;
      private int[] T001V56_A84ParCod ;
      private int[] T001V56_A85ParDActItem ;
      private string[] T001V57_A83ParTip ;
      private int[] T001V57_A84ParCod ;
      private int[] T001V57_A85ParDActItem ;
      private string[] T001V58_A83ParTip ;
      private int[] T001V58_A84ParCod ;
      private int[] T001V58_A85ParDActItem ;
      private string[] T001V59_A83ParTip ;
      private int[] T001V59_A84ParCod ;
      private int[] T001V59_A85ParDActItem ;
      private string[] T001V60_A79COSCod ;
      private int[] T001V61_A76CConpCod ;
      private string[] T001V62_A28ProdCod ;
      private string[] T001V63_A28ProdCod ;
      private string[] T001V64_A28ProdCod ;
      private string[] T001V65_A91CueCod ;
      private string[] T001V66_A109CueGasDebe ;
      private bool[] T001V66_n109CueGasDebe ;
      private string[] T001V67_A110CueGasHaber ;
      private bool[] T001V67_n110CueGasHaber ;
      private string[] T001V68_A111CueMonDebe ;
      private bool[] T001V68_n111CueMonDebe ;
      private string[] T001V69_A112CueMonHaber ;
      private bool[] T001V69_n112CueMonHaber ;
      private int[] T001V70_A70TipACod ;
      private bool[] T001V70_n70TipACod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbplancuenta__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbplancuenta__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new ForEachCursor(def[59])
       ,new ForEachCursor(def[60])
       ,new ForEachCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new ForEachCursor(def[65])
       ,new ForEachCursor(def[66])
       ,new ForEachCursor(def[67])
       ,new ForEachCursor(def[68])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001V9;
        prmT001V9 = new Object[] {
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V10;
        prmT001V10 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V5;
        prmT001V5 = new Object[] {
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V6;
        prmT001V6 = new Object[] {
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V7;
        prmT001V7 = new Object[] {
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V8;
        prmT001V8 = new Object[] {
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V4;
        prmT001V4 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001V11;
        prmT001V11 = new Object[] {
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V12;
        prmT001V12 = new Object[] {
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V13;
        prmT001V13 = new Object[] {
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V14;
        prmT001V14 = new Object[] {
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V15;
        prmT001V15 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001V16;
        prmT001V16 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V3;
        prmT001V3 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V17;
        prmT001V17 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V18;
        prmT001V18 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V2;
        prmT001V2 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V19;
        prmT001V19 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@CueDsc",GXType.NChar,100,0) ,
        new ParDef("@CueAbr",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CueMov",GXType.Int16,1,0) ,
        new ParDef("@CueMon",GXType.Int16,1,0) ,
        new ParDef("@CueCos",GXType.Int16,1,0) ,
        new ParDef("@CueSts",GXType.Int16,1,0) ,
        new ParDef("@CueRef1",GXType.Int16,1,0) ,
        new ParDef("@CueRef2",GXType.Int16,1,0) ,
        new ParDef("@CueRef3",GXType.Int16,1,0) ,
        new ParDef("@CueRef4",GXType.Int16,1,0) ,
        new ParDef("@CueRef5",GXType.Int16,1,0) ,
        new ParDef("@CueGrupDoc",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V20;
        prmT001V20 = new Object[] {
        new ParDef("@CueDsc",GXType.NChar,100,0) ,
        new ParDef("@CueAbr",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CueMov",GXType.Int16,1,0) ,
        new ParDef("@CueMon",GXType.Int16,1,0) ,
        new ParDef("@CueCos",GXType.Int16,1,0) ,
        new ParDef("@CueSts",GXType.Int16,1,0) ,
        new ParDef("@CueRef1",GXType.Int16,1,0) ,
        new ParDef("@CueRef2",GXType.Int16,1,0) ,
        new ParDef("@CueRef3",GXType.Int16,1,0) ,
        new ParDef("@CueRef4",GXType.Int16,1,0) ,
        new ParDef("@CueRef5",GXType.Int16,1,0) ,
        new ParDef("@CueGrupDoc",GXType.Int16,1,0) ,
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueCierre",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V21;
        prmT001V21 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V22;
        prmT001V22 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V23;
        prmT001V23 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V24;
        prmT001V24 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V25;
        prmT001V25 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V26;
        prmT001V26 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V27;
        prmT001V27 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V28;
        prmT001V28 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V29;
        prmT001V29 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V30;
        prmT001V30 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V31;
        prmT001V31 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V32;
        prmT001V32 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V33;
        prmT001V33 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V34;
        prmT001V34 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V35;
        prmT001V35 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V36;
        prmT001V36 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V37;
        prmT001V37 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V38;
        prmT001V38 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V39;
        prmT001V39 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V40;
        prmT001V40 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V41;
        prmT001V41 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V42;
        prmT001V42 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V43;
        prmT001V43 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V44;
        prmT001V44 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V45;
        prmT001V45 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V46;
        prmT001V46 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V47;
        prmT001V47 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V48;
        prmT001V48 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V49;
        prmT001V49 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V50;
        prmT001V50 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V51;
        prmT001V51 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V52;
        prmT001V52 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V53;
        prmT001V53 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V54;
        prmT001V54 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V55;
        prmT001V55 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V56;
        prmT001V56 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V57;
        prmT001V57 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V58;
        prmT001V58 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V59;
        prmT001V59 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V60;
        prmT001V60 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V61;
        prmT001V61 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V62;
        prmT001V62 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V63;
        prmT001V63 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V64;
        prmT001V64 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001V65;
        prmT001V65 = new Object[] {
        };
        Object[] prmT001V66;
        prmT001V66 = new Object[] {
        new ParDef("@CueGasDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V67;
        prmT001V67 = new Object[] {
        new ParDef("@CueGasHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V68;
        prmT001V68 = new Object[] {
        new ParDef("@CueMonDebe",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V69;
        prmT001V69 = new Object[] {
        new ParDef("@CueMonHaber",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001V70;
        prmT001V70 = new Object[] {
        new ParDef("@TipACod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001V2", "SELECT [CueCod], [CueDsc], [CueAbr], [CueMov], [CueMon], [CueCos], [CueSts], [CueRef1], [CueRef2], [CueRef3], [CueRef4], [CueRef5], [CueGrupDoc], [TipACod], [CueGasDebe] AS CueGasDebe, [CueGasHaber] AS CueGasHaber, [CueMonDebe] AS CueMonDebe, [CueMonHaber] AS CueMonHaber, [CueCierre] AS CueCierre FROM [CBPLANCUENTA] WITH (UPDLOCK) WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V3", "SELECT [CueCod], [CueDsc], [CueAbr], [CueMov], [CueMon], [CueCos], [CueSts], [CueRef1], [CueRef2], [CueRef3], [CueRef4], [CueRef5], [CueGrupDoc], [TipACod], [CueGasDebe] AS CueGasDebe, [CueGasHaber] AS CueGasHaber, [CueMonDebe] AS CueMonDebe, [CueMonHaber] AS CueMonHaber, [CueCierre] AS CueCierre FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V4", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V5", "SELECT [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V6", "SELECT [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V7", "SELECT [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V8", "SELECT [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V9", "SELECT [CueDsc] AS CueCierreDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCierre ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V10", "SELECT TM1.[CueCod], TM1.[CueDsc], TM1.[CueAbr], TM1.[CueMov], TM1.[CueMon], TM1.[CueCos], TM1.[CueSts], TM1.[CueRef1], TM1.[CueRef2], TM1.[CueRef3], TM1.[CueRef4], TM1.[CueRef5], TM1.[CueGrupDoc], T2.[CueDsc] AS CueCierreDsc, TM1.[TipACod], TM1.[CueGasDebe] AS CueGasDebe, TM1.[CueGasHaber] AS CueGasHaber, TM1.[CueMonDebe] AS CueMonDebe, TM1.[CueMonHaber] AS CueMonHaber, TM1.[CueCierre] AS CueCierre FROM ([CBPLANCUENTA] TM1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CueCierre]) WHERE TM1.[CueCod] = @CueCod ORDER BY TM1.[CueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V11", "SELECT [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V12", "SELECT [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V13", "SELECT [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V14", "SELECT [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V15", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V16", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V17", "SELECT TOP 1 [CueCod] FROM [CBPLANCUENTA] WHERE ( [CueCod] > @CueCod) ORDER BY [CueCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V18", "SELECT TOP 1 [CueCod] FROM [CBPLANCUENTA] WHERE ( [CueCod] < @CueCod) ORDER BY [CueCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V19", "INSERT INTO [CBPLANCUENTA]([CueCod], [CueDsc], [CueAbr], [CueMov], [CueMon], [CueCos], [CueSts], [CueRef1], [CueRef2], [CueRef3], [CueRef4], [CueRef5], [CueGrupDoc], [TipACod], [CueGasDebe], [CueGasHaber], [CueMonDebe], [CueMonHaber], [CueCierre], [CueBienes]) VALUES(@CueCod, @CueDsc, @CueAbr, @CueMov, @CueMon, @CueCos, @CueSts, @CueRef1, @CueRef2, @CueRef3, @CueRef4, @CueRef5, @CueGrupDoc, @TipACod, @CueGasDebe, @CueGasHaber, @CueMonDebe, @CueMonHaber, @CueCierre, convert(int, 0))", GxErrorMask.GX_NOMASK,prmT001V19)
           ,new CursorDef("T001V20", "UPDATE [CBPLANCUENTA] SET [CueDsc]=@CueDsc, [CueAbr]=@CueAbr, [CueMov]=@CueMov, [CueMon]=@CueMon, [CueCos]=@CueCos, [CueSts]=@CueSts, [CueRef1]=@CueRef1, [CueRef2]=@CueRef2, [CueRef3]=@CueRef3, [CueRef4]=@CueRef4, [CueRef5]=@CueRef5, [CueGrupDoc]=@CueGrupDoc, [TipACod]=@TipACod, [CueGasDebe]=@CueGasDebe, [CueGasHaber]=@CueGasHaber, [CueMonDebe]=@CueMonDebe, [CueMonHaber]=@CueMonHaber, [CueCierre]=@CueCierre  WHERE [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT001V20)
           ,new CursorDef("T001V21", "DELETE FROM [CBPLANCUENTA]  WHERE [CueCod] = @CueCod", GxErrorMask.GX_NOMASK,prmT001V21)
           ,new CursorDef("T001V22", "SELECT TOP 1 [CueCod] AS CueCierre FROM [CBPLANCUENTA] WHERE [CueCierre] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V23", "SELECT TOP 1 [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueMonHaber] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V24", "SELECT TOP 1 [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueMonDebe] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V25", "SELECT TOP 1 [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueGasHaber] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V26", "SELECT TOP 1 [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueGasDebe] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V27", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLECueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V28", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V29", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [CBCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V30", "SELECT TOP 1 [ConBCod] FROM [TSCONCEPTOBANCOS] WHERE [ConBCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V31", "SELECT TOP 1 [PSerConcCod], [PSerDConcCueCod] FROM [POSERCONCEPTOSDET] WHERE [PSerDConcCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V32", "SELECT TOP 1 [PoConcCod], [PoConcDCueCod] FROM [POCONCEPTOSDET] WHERE [PoConcDCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V33", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComDCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V34", "SELECT TOP 1 [SalVouAno], [SalVouMes], [SalCueCod], [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE [SalCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V35", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDCueCod1] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V36", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V37", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue10] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V38", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue9] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V39", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue8] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V40", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue7] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V41", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue6] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V41,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V42", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue5] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V42,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V43", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue4] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V44", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue3] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V44,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V45", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue2] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V45,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V46", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParCue1] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V46,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V47", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre], [CBRubDItem] FROM [CBPRESUPUESTORUBROSCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V47,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V48", "SELECT TOP 1 [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V48,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V49", "SELECT TOP 1 [EntCod] FROM [TSENTREGAS] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V49,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V50", "SELECT TOP 1 [ConEntCod] FROM [TSCONCEPTOENTREGA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V50,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V51", "SELECT TOP 1 [ConCajCod] FROM [TSCONCEPTOCAJA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V51,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V52", "SELECT TOP 1 [CajCod] FROM [TSCAJACHICA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V52,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V53", "SELECT TOP 1 [LiqPrvCod] FROM [CPAGENTES] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V53,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V54", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V54,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V55", "SELECT TOP 1 [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] FROM [CBRUBROSLD] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V55,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V56", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod4] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V56,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V57", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod3] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V57,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V58", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod2] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V58,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V59", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParActCueCod1] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V59,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V60", "SELECT TOP 1 [COSCod] FROM [CBCOSTOS] WHERE [COSCueDestino] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V60,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V61", "SELECT TOP 1 [CConpCod] FROM [CBCOMPRASCONC] WHERE [CConpCueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V61,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V62", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [ProdCuentaA] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V62,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V63", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [ProdCuentaC] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V63,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V64", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [ProdCuentaV] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V64,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001V65", "SELECT [CueCod] FROM [CBPLANCUENTA] ORDER BY [CueCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001V65,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V66", "SELECT [CueCod] AS CueGasDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V66,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V67", "SELECT [CueCod] AS CueGasHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueGasHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V67,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V68", "SELECT [CueCod] AS CueMonDebe FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonDebe ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V68,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V69", "SELECT [CueCod] AS CueMonHaber FROM [CBPLANCUENTA] WHERE [CueCod] = @CueMonHaber ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V69,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001V70", "SELECT [TipACod] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @TipACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001V70,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getString(15, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((string[]) buf[18])[0] = rslt.getString(16, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((string[]) buf[20])[0] = rslt.getString(17, 15);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              ((string[]) buf[22])[0] = rslt.getString(18, 15);
              ((bool[]) buf[23])[0] = rslt.wasNull(18);
              ((string[]) buf[24])[0] = rslt.getString(19, 15);
              ((bool[]) buf[25])[0] = rslt.wasNull(19);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getString(15, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((string[]) buf[18])[0] = rslt.getString(16, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((string[]) buf[20])[0] = rslt.getString(17, 15);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              ((string[]) buf[22])[0] = rslt.getString(18, 15);
              ((bool[]) buf[23])[0] = rslt.wasNull(18);
              ((string[]) buf[24])[0] = rslt.getString(19, 15);
              ((bool[]) buf[25])[0] = rslt.wasNull(19);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((short[]) buf[4])[0] = rslt.getShort(4);
              ((short[]) buf[5])[0] = rslt.getShort(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((short[]) buf[8])[0] = rslt.getShort(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((string[]) buf[14])[0] = rslt.getString(14, 100);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 15);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              ((string[]) buf[19])[0] = rslt.getString(17, 15);
              ((bool[]) buf[20])[0] = rslt.wasNull(17);
              ((string[]) buf[21])[0] = rslt.getString(18, 15);
              ((bool[]) buf[22])[0] = rslt.wasNull(18);
              ((string[]) buf[23])[0] = rslt.getString(19, 15);
              ((bool[]) buf[24])[0] = rslt.wasNull(19);
              ((string[]) buf[25])[0] = rslt.getString(20, 15);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 32 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 45 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 47 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 48 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 49 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 50 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 52 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 53 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 54 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 55 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 57 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 58 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 59 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
     getresults60( cursor, rslt, buf) ;
  }

  public void getresults60( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 60 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 61 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 62 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 63 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 64 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 65 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 66 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 67 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 68 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
