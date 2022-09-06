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
   public class clcobranza : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A166CobTip = GetPar( "CobTip");
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = GetPar( "CobCod");
            AssignAttri("", false, "A167CobCod", A167CobCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A166CobTip, A167CobCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A172CobMon = (int)(NumberUtil.Val( GetPar( "CobMon"), "."));
            AssignAttri("", false, "A172CobMon", StringUtil.LTrimStr( (decimal)(A172CobMon), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A172CobMon) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A171CobVendCod = (int)(NumberUtil.Val( GetPar( "CobVendCod"), "."));
            AssignAttri("", false, "A171CobVendCod", StringUtil.LTrimStr( (decimal)(A171CobVendCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A171CobVendCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A169CobBanCod = (int)(NumberUtil.Val( GetPar( "CobBanCod"), "."));
            n169CobBanCod = false;
            AssignAttri("", false, "A169CobBanCod", StringUtil.LTrimStr( (decimal)(A169CobBanCod), 6, 0));
            A170CobCbCod = GetPar( "CobCbCod");
            n170CobCbCod = false;
            AssignAttri("", false, "A170CobCbCod", A170CobCbCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A169CobBanCod, A170CobCbCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A168CobConBCod = (int)(NumberUtil.Val( GetPar( "CobConBCod"), "."));
            n168CobConBCod = false;
            AssignAttri("", false, "A168CobConBCod", StringUtil.LTrimStr( (decimal)(A168CobConBCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A168CobConBCod) ;
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
            Form.Meta.addItem("description", "Cobranza - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clcobranza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clcobranza( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCOBRANZA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo Cobranza", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobTip_Internalname, StringUtil.RTrim( A166CobTip), StringUtil.RTrim( context.localUtil.Format( A166CobTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Cobranza", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobCod_Internalname, StringUtil.RTrim( A167CobCod), StringUtil.RTrim( context.localUtil.Format( A167CobCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobCod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCobFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCobFec_Internalname, context.localUtil.Format(A655CobFec, "99/99/99"), context.localUtil.Format( A655CobFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         GxWebStd.gx_bitmap( context, edtCobFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCobFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Moneda", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A172CobMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A172CobMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A172CobMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Moneda", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobMonDsc_Internalname, StringUtil.RTrim( A657CobMonDsc), StringUtil.RTrim( context.localUtil.Format( A657CobMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Moneda", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobMonAbr_Internalname, StringUtil.RTrim( A656CobMonAbr), StringUtil.RTrim( context.localUtil.Format( A656CobMonAbr, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobMonAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobMonAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo Cobrador", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobVendCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A171CobVendCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobVendCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A171CobVendCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A171CobVendCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobVendCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobVendCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cobrador", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobVendDsc_Internalname, StringUtil.RTrim( A667CobVendDsc), StringUtil.RTrim( context.localUtil.Format( A667CobVendDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobVendDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobVendDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Total Item", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTotalItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1927TotalItem), 5, 0, ".", "")), StringUtil.LTrim( ((edtTotalItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1927TotalItem), "ZZZZ9") : context.localUtil.Format( (decimal)(A1927TotalItem), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTotalItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTotalItem_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Codigo de Banco", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A169CobBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A169CobBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A169CobBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Cuenta", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobCbCod_Internalname, StringUtil.RTrim( A170CobCbCod), StringUtil.RTrim( context.localUtil.Format( A170CobCbCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobCbCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobCbCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Concepto de Banco", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobConBCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A168CobConBCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobConBCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A168CobConBCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A168CobConBCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobConBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobConBCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Registro", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobRegistro_Internalname, StringUtil.RTrim( A660CobRegistro), StringUtil.RTrim( context.localUtil.Format( A660CobRegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobRegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Importe Banco", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobBanImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A644CobBanImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtCobBanImp_Enabled!=0) ? context.localUtil.Format( A644CobBanImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A644CobBanImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobBanImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobBanImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Afecta Bancos", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobAfecta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A643CobAfecta), 1, 0, ".", "")), StringUtil.LTrim( ((edtCobAfecta_Enabled!=0) ? context.localUtil.Format( (decimal)(A643CobAfecta), "9") : context.localUtil.Format( (decimal)(A643CobAfecta), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobAfecta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobAfecta_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Estado", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobSts_Internalname, StringUtil.RTrim( A661CobSts), StringUtil.RTrim( context.localUtil.Format( A661CobSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Año", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A668CobVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCobVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A668CobVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A668CobVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Mes", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A669CobVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCobVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A669CobVouMes), "Z9") : context.localUtil.Format( (decimal)(A669CobVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Tipo Asiento", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobTAsiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A662CobTAsiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobTAsiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A662CobTAsiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A662CobTAsiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobTAsiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobTAsiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "N° Asiento", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobVouNum_Internalname, StringUtil.RTrim( A670CobVouNum), StringUtil.RTrim( context.localUtil.Format( A670CobVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Total Cobrado", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A664CobTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtCobTot_Enabled!=0) ? context.localUtil.Format( A664CobTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A664CobTot, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Usuario", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobUsuCod_Internalname, StringUtil.RTrim( A665CobUsuCod), StringUtil.RTrim( context.localUtil.Format( A665CobUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Usuario Fecha", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCobUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCobUsuFec_Internalname, context.localUtil.TToC( A666CobUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A666CobUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZA.htm");
         GxWebStd.gx_bitmap( context, edtCobUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCobUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOBRANZA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLCOBRANZA.htm");
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
            Z166CobTip = cgiGet( "Z166CobTip");
            Z167CobCod = cgiGet( "Z167CobCod");
            Z655CobFec = context.localUtil.CToD( cgiGet( "Z655CobFec"), 0);
            Z1927TotalItem = (int)(context.localUtil.CToN( cgiGet( "Z1927TotalItem"), ".", ","));
            Z660CobRegistro = cgiGet( "Z660CobRegistro");
            n660CobRegistro = (String.IsNullOrEmpty(StringUtil.RTrim( A660CobRegistro)) ? true : false);
            Z644CobBanImp = context.localUtil.CToN( cgiGet( "Z644CobBanImp"), ".", ",");
            n644CobBanImp = ((Convert.ToDecimal(0)==A644CobBanImp) ? true : false);
            Z643CobAfecta = (short)(context.localUtil.CToN( cgiGet( "Z643CobAfecta"), ".", ","));
            Z661CobSts = cgiGet( "Z661CobSts");
            Z668CobVouAno = (short)(context.localUtil.CToN( cgiGet( "Z668CobVouAno"), ".", ","));
            Z669CobVouMes = (short)(context.localUtil.CToN( cgiGet( "Z669CobVouMes"), ".", ","));
            Z662CobTAsiCod = (int)(context.localUtil.CToN( cgiGet( "Z662CobTAsiCod"), ".", ","));
            Z670CobVouNum = cgiGet( "Z670CobVouNum");
            Z665CobUsuCod = cgiGet( "Z665CobUsuCod");
            Z666CobUsuFec = context.localUtil.CToT( cgiGet( "Z666CobUsuFec"), 0);
            Z172CobMon = (int)(context.localUtil.CToN( cgiGet( "Z172CobMon"), ".", ","));
            Z171CobVendCod = (int)(context.localUtil.CToN( cgiGet( "Z171CobVendCod"), ".", ","));
            Z169CobBanCod = (int)(context.localUtil.CToN( cgiGet( "Z169CobBanCod"), ".", ","));
            n169CobBanCod = ((0==A169CobBanCod) ? true : false);
            Z170CobCbCod = cgiGet( "Z170CobCbCod");
            n170CobCbCod = (String.IsNullOrEmpty(StringUtil.RTrim( A170CobCbCod)) ? true : false);
            Z168CobConBCod = (int)(context.localUtil.CToN( cgiGet( "Z168CobConBCod"), ".", ","));
            n168CobConBCod = ((0==A168CobConBCod) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A166CobTip = cgiGet( edtCobTip_Internalname);
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = cgiGet( edtCobCod_Internalname);
            AssignAttri("", false, "A167CobCod", A167CobCod);
            if ( context.localUtil.VCDate( cgiGet( edtCobFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "COBFEC");
               AnyError = 1;
               GX_FocusControl = edtCobFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A655CobFec = DateTime.MinValue;
               AssignAttri("", false, "A655CobFec", context.localUtil.Format(A655CobFec, "99/99/99"));
            }
            else
            {
               A655CobFec = context.localUtil.CToD( cgiGet( edtCobFec_Internalname), 2);
               AssignAttri("", false, "A655CobFec", context.localUtil.Format(A655CobFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobMon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBMON");
               AnyError = 1;
               GX_FocusControl = edtCobMon_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A172CobMon = 0;
               AssignAttri("", false, "A172CobMon", StringUtil.LTrimStr( (decimal)(A172CobMon), 6, 0));
            }
            else
            {
               A172CobMon = (int)(context.localUtil.CToN( cgiGet( edtCobMon_Internalname), ".", ","));
               AssignAttri("", false, "A172CobMon", StringUtil.LTrimStr( (decimal)(A172CobMon), 6, 0));
            }
            A657CobMonDsc = cgiGet( edtCobMonDsc_Internalname);
            AssignAttri("", false, "A657CobMonDsc", A657CobMonDsc);
            A656CobMonAbr = cgiGet( edtCobMonAbr_Internalname);
            AssignAttri("", false, "A656CobMonAbr", A656CobMonAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobVendCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobVendCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBVENDCOD");
               AnyError = 1;
               GX_FocusControl = edtCobVendCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A171CobVendCod = 0;
               AssignAttri("", false, "A171CobVendCod", StringUtil.LTrimStr( (decimal)(A171CobVendCod), 6, 0));
            }
            else
            {
               A171CobVendCod = (int)(context.localUtil.CToN( cgiGet( edtCobVendCod_Internalname), ".", ","));
               AssignAttri("", false, "A171CobVendCod", StringUtil.LTrimStr( (decimal)(A171CobVendCod), 6, 0));
            }
            A667CobVendDsc = cgiGet( edtCobVendDsc_Internalname);
            AssignAttri("", false, "A667CobVendDsc", A667CobVendDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTotalItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTotalItem_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TOTALITEM");
               AnyError = 1;
               GX_FocusControl = edtTotalItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1927TotalItem = 0;
               AssignAttri("", false, "A1927TotalItem", StringUtil.LTrimStr( (decimal)(A1927TotalItem), 5, 0));
            }
            else
            {
               A1927TotalItem = (int)(context.localUtil.CToN( cgiGet( edtTotalItem_Internalname), ".", ","));
               AssignAttri("", false, "A1927TotalItem", StringUtil.LTrimStr( (decimal)(A1927TotalItem), 5, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtCobBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A169CobBanCod = 0;
               n169CobBanCod = false;
               AssignAttri("", false, "A169CobBanCod", StringUtil.LTrimStr( (decimal)(A169CobBanCod), 6, 0));
            }
            else
            {
               A169CobBanCod = (int)(context.localUtil.CToN( cgiGet( edtCobBanCod_Internalname), ".", ","));
               n169CobBanCod = false;
               AssignAttri("", false, "A169CobBanCod", StringUtil.LTrimStr( (decimal)(A169CobBanCod), 6, 0));
            }
            n169CobBanCod = ((0==A169CobBanCod) ? true : false);
            A170CobCbCod = cgiGet( edtCobCbCod_Internalname);
            n170CobCbCod = false;
            AssignAttri("", false, "A170CobCbCod", A170CobCbCod);
            n170CobCbCod = (String.IsNullOrEmpty(StringUtil.RTrim( A170CobCbCod)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobConBCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobConBCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBCONBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobConBCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A168CobConBCod = 0;
               n168CobConBCod = false;
               AssignAttri("", false, "A168CobConBCod", StringUtil.LTrimStr( (decimal)(A168CobConBCod), 6, 0));
            }
            else
            {
               A168CobConBCod = (int)(context.localUtil.CToN( cgiGet( edtCobConBCod_Internalname), ".", ","));
               n168CobConBCod = false;
               AssignAttri("", false, "A168CobConBCod", StringUtil.LTrimStr( (decimal)(A168CobConBCod), 6, 0));
            }
            n168CobConBCod = ((0==A168CobConBCod) ? true : false);
            A660CobRegistro = cgiGet( edtCobRegistro_Internalname);
            n660CobRegistro = false;
            AssignAttri("", false, "A660CobRegistro", A660CobRegistro);
            n660CobRegistro = (String.IsNullOrEmpty(StringUtil.RTrim( A660CobRegistro)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobBanImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCobBanImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBBANIMP");
               AnyError = 1;
               GX_FocusControl = edtCobBanImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A644CobBanImp = 0;
               n644CobBanImp = false;
               AssignAttri("", false, "A644CobBanImp", StringUtil.LTrimStr( A644CobBanImp, 15, 2));
            }
            else
            {
               A644CobBanImp = context.localUtil.CToN( cgiGet( edtCobBanImp_Internalname), ".", ",");
               n644CobBanImp = false;
               AssignAttri("", false, "A644CobBanImp", StringUtil.LTrimStr( A644CobBanImp, 15, 2));
            }
            n644CobBanImp = ((Convert.ToDecimal(0)==A644CobBanImp) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobAfecta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobAfecta_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBAFECTA");
               AnyError = 1;
               GX_FocusControl = edtCobAfecta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A643CobAfecta = 0;
               AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            }
            else
            {
               A643CobAfecta = (short)(context.localUtil.CToN( cgiGet( edtCobAfecta_Internalname), ".", ","));
               AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            }
            A661CobSts = cgiGet( edtCobSts_Internalname);
            AssignAttri("", false, "A661CobSts", A661CobSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBVOUANO");
               AnyError = 1;
               GX_FocusControl = edtCobVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A668CobVouAno = 0;
               AssignAttri("", false, "A668CobVouAno", StringUtil.LTrimStr( (decimal)(A668CobVouAno), 4, 0));
            }
            else
            {
               A668CobVouAno = (short)(context.localUtil.CToN( cgiGet( edtCobVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A668CobVouAno", StringUtil.LTrimStr( (decimal)(A668CobVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBVOUMES");
               AnyError = 1;
               GX_FocusControl = edtCobVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A669CobVouMes = 0;
               AssignAttri("", false, "A669CobVouMes", StringUtil.LTrimStr( (decimal)(A669CobVouMes), 2, 0));
            }
            else
            {
               A669CobVouMes = (short)(context.localUtil.CToN( cgiGet( edtCobVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A669CobVouMes", StringUtil.LTrimStr( (decimal)(A669CobVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobTAsiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobTAsiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBTASICOD");
               AnyError = 1;
               GX_FocusControl = edtCobTAsiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A662CobTAsiCod = 0;
               AssignAttri("", false, "A662CobTAsiCod", StringUtil.LTrimStr( (decimal)(A662CobTAsiCod), 6, 0));
            }
            else
            {
               A662CobTAsiCod = (int)(context.localUtil.CToN( cgiGet( edtCobTAsiCod_Internalname), ".", ","));
               AssignAttri("", false, "A662CobTAsiCod", StringUtil.LTrimStr( (decimal)(A662CobTAsiCod), 6, 0));
            }
            A670CobVouNum = cgiGet( edtCobVouNum_Internalname);
            AssignAttri("", false, "A670CobVouNum", A670CobVouNum);
            A664CobTot = context.localUtil.CToN( cgiGet( edtCobTot_Internalname), ".", ",");
            n664CobTot = false;
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
            A665CobUsuCod = cgiGet( edtCobUsuCod_Internalname);
            AssignAttri("", false, "A665CobUsuCod", A665CobUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtCobUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "COBUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtCobUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A666CobUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A666CobUsuFec", context.localUtil.TToC( A666CobUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A666CobUsuFec = context.localUtil.CToT( cgiGet( edtCobUsuFec_Internalname));
               AssignAttri("", false, "A666CobUsuFec", context.localUtil.TToC( A666CobUsuFec, 8, 5, 0, 3, "/", ":", " "));
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
               A166CobTip = GetPar( "CobTip");
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = GetPar( "CobCod");
               AssignAttri("", false, "A167CobCod", A167CobCod);
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
               InitAll2G84( ) ;
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
         DisableAttributes2G84( ) ;
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

      protected void CONFIRM_2G0( )
      {
         BeforeValidate2G84( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2G84( ) ;
            }
            else
            {
               CheckExtendedTable2G84( ) ;
               if ( AnyError == 0 )
               {
                  ZM2G84( 4) ;
                  ZM2G84( 5) ;
                  ZM2G84( 6) ;
                  ZM2G84( 7) ;
                  ZM2G84( 8) ;
               }
               CloseExtendedTableCursors2G84( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2G0( ) ;
         }
      }

      protected void ResetCaption2G0( )
      {
      }

      protected void ZM2G84( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z655CobFec = T002G3_A655CobFec[0];
               Z1927TotalItem = T002G3_A1927TotalItem[0];
               Z660CobRegistro = T002G3_A660CobRegistro[0];
               Z644CobBanImp = T002G3_A644CobBanImp[0];
               Z643CobAfecta = T002G3_A643CobAfecta[0];
               Z661CobSts = T002G3_A661CobSts[0];
               Z668CobVouAno = T002G3_A668CobVouAno[0];
               Z669CobVouMes = T002G3_A669CobVouMes[0];
               Z662CobTAsiCod = T002G3_A662CobTAsiCod[0];
               Z670CobVouNum = T002G3_A670CobVouNum[0];
               Z665CobUsuCod = T002G3_A665CobUsuCod[0];
               Z666CobUsuFec = T002G3_A666CobUsuFec[0];
               Z172CobMon = T002G3_A172CobMon[0];
               Z171CobVendCod = T002G3_A171CobVendCod[0];
               Z169CobBanCod = T002G3_A169CobBanCod[0];
               Z170CobCbCod = T002G3_A170CobCbCod[0];
               Z168CobConBCod = T002G3_A168CobConBCod[0];
            }
            else
            {
               Z655CobFec = A655CobFec;
               Z1927TotalItem = A1927TotalItem;
               Z660CobRegistro = A660CobRegistro;
               Z644CobBanImp = A644CobBanImp;
               Z643CobAfecta = A643CobAfecta;
               Z661CobSts = A661CobSts;
               Z668CobVouAno = A668CobVouAno;
               Z669CobVouMes = A669CobVouMes;
               Z662CobTAsiCod = A662CobTAsiCod;
               Z670CobVouNum = A670CobVouNum;
               Z665CobUsuCod = A665CobUsuCod;
               Z666CobUsuFec = A666CobUsuFec;
               Z172CobMon = A172CobMon;
               Z171CobVendCod = A171CobVendCod;
               Z169CobBanCod = A169CobBanCod;
               Z170CobCbCod = A170CobCbCod;
               Z168CobConBCod = A168CobConBCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z166CobTip = A166CobTip;
            Z167CobCod = A167CobCod;
            Z655CobFec = A655CobFec;
            Z1927TotalItem = A1927TotalItem;
            Z660CobRegistro = A660CobRegistro;
            Z644CobBanImp = A644CobBanImp;
            Z643CobAfecta = A643CobAfecta;
            Z661CobSts = A661CobSts;
            Z668CobVouAno = A668CobVouAno;
            Z669CobVouMes = A669CobVouMes;
            Z662CobTAsiCod = A662CobTAsiCod;
            Z670CobVouNum = A670CobVouNum;
            Z665CobUsuCod = A665CobUsuCod;
            Z666CobUsuFec = A666CobUsuFec;
            Z172CobMon = A172CobMon;
            Z171CobVendCod = A171CobVendCod;
            Z169CobBanCod = A169CobBanCod;
            Z170CobCbCod = A170CobCbCod;
            Z168CobConBCod = A168CobConBCod;
            Z664CobTot = A664CobTot;
            Z657CobMonDsc = A657CobMonDsc;
            Z656CobMonAbr = A656CobMonAbr;
            Z667CobVendDsc = A667CobVendDsc;
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

      protected void Load2G84( )
      {
         /* Using cursor T002G11 */
         pr_default.execute(7, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound84 = 1;
            A655CobFec = T002G11_A655CobFec[0];
            AssignAttri("", false, "A655CobFec", context.localUtil.Format(A655CobFec, "99/99/99"));
            A657CobMonDsc = T002G11_A657CobMonDsc[0];
            AssignAttri("", false, "A657CobMonDsc", A657CobMonDsc);
            A656CobMonAbr = T002G11_A656CobMonAbr[0];
            AssignAttri("", false, "A656CobMonAbr", A656CobMonAbr);
            A667CobVendDsc = T002G11_A667CobVendDsc[0];
            AssignAttri("", false, "A667CobVendDsc", A667CobVendDsc);
            A1927TotalItem = T002G11_A1927TotalItem[0];
            AssignAttri("", false, "A1927TotalItem", StringUtil.LTrimStr( (decimal)(A1927TotalItem), 5, 0));
            A660CobRegistro = T002G11_A660CobRegistro[0];
            n660CobRegistro = T002G11_n660CobRegistro[0];
            AssignAttri("", false, "A660CobRegistro", A660CobRegistro);
            A644CobBanImp = T002G11_A644CobBanImp[0];
            n644CobBanImp = T002G11_n644CobBanImp[0];
            AssignAttri("", false, "A644CobBanImp", StringUtil.LTrimStr( A644CobBanImp, 15, 2));
            A643CobAfecta = T002G11_A643CobAfecta[0];
            AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            A661CobSts = T002G11_A661CobSts[0];
            AssignAttri("", false, "A661CobSts", A661CobSts);
            A668CobVouAno = T002G11_A668CobVouAno[0];
            AssignAttri("", false, "A668CobVouAno", StringUtil.LTrimStr( (decimal)(A668CobVouAno), 4, 0));
            A669CobVouMes = T002G11_A669CobVouMes[0];
            AssignAttri("", false, "A669CobVouMes", StringUtil.LTrimStr( (decimal)(A669CobVouMes), 2, 0));
            A662CobTAsiCod = T002G11_A662CobTAsiCod[0];
            AssignAttri("", false, "A662CobTAsiCod", StringUtil.LTrimStr( (decimal)(A662CobTAsiCod), 6, 0));
            A670CobVouNum = T002G11_A670CobVouNum[0];
            AssignAttri("", false, "A670CobVouNum", A670CobVouNum);
            A665CobUsuCod = T002G11_A665CobUsuCod[0];
            AssignAttri("", false, "A665CobUsuCod", A665CobUsuCod);
            A666CobUsuFec = T002G11_A666CobUsuFec[0];
            AssignAttri("", false, "A666CobUsuFec", context.localUtil.TToC( A666CobUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A172CobMon = T002G11_A172CobMon[0];
            AssignAttri("", false, "A172CobMon", StringUtil.LTrimStr( (decimal)(A172CobMon), 6, 0));
            A171CobVendCod = T002G11_A171CobVendCod[0];
            AssignAttri("", false, "A171CobVendCod", StringUtil.LTrimStr( (decimal)(A171CobVendCod), 6, 0));
            A169CobBanCod = T002G11_A169CobBanCod[0];
            n169CobBanCod = T002G11_n169CobBanCod[0];
            AssignAttri("", false, "A169CobBanCod", StringUtil.LTrimStr( (decimal)(A169CobBanCod), 6, 0));
            A170CobCbCod = T002G11_A170CobCbCod[0];
            n170CobCbCod = T002G11_n170CobCbCod[0];
            AssignAttri("", false, "A170CobCbCod", A170CobCbCod);
            A168CobConBCod = T002G11_A168CobConBCod[0];
            n168CobConBCod = T002G11_n168CobConBCod[0];
            AssignAttri("", false, "A168CobConBCod", StringUtil.LTrimStr( (decimal)(A168CobConBCod), 6, 0));
            A664CobTot = T002G11_A664CobTot[0];
            n664CobTot = T002G11_n664CobTot[0];
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
            ZM2G84( -3) ;
         }
         pr_default.close(7);
         OnLoadActions2G84( ) ;
      }

      protected void OnLoadActions2G84( )
      {
      }

      protected void CheckExtendedTable2G84( )
      {
         nIsDirty_84 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002G9 */
         pr_default.execute(6, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A664CobTot = T002G9_A664CobTot[0];
            n664CobTot = T002G9_n664CobTot[0];
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         }
         else
         {
            nIsDirty_84 = 1;
            A664CobTot = 0;
            n664CobTot = false;
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A655CobFec) || ( DateTimeUtil.ResetTime ( A655CobFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "COBFEC");
            AnyError = 1;
            GX_FocusControl = edtCobFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002G4 */
         pr_default.execute(2, new Object[] {A172CobMon});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "COBMON");
            AnyError = 1;
            GX_FocusControl = edtCobMon_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A657CobMonDsc = T002G4_A657CobMonDsc[0];
         AssignAttri("", false, "A657CobMonDsc", A657CobMonDsc);
         A656CobMonAbr = T002G4_A656CobMonAbr[0];
         AssignAttri("", false, "A656CobMonAbr", A656CobMonAbr);
         pr_default.close(2);
         /* Using cursor T002G5 */
         pr_default.execute(3, new Object[] {A171CobVendCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobrador'.", "ForeignKeyNotFound", 1, "COBVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCobVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A667CobVendDsc = T002G5_A667CobVendDsc[0];
         AssignAttri("", false, "A667CobVendDsc", A667CobVendDsc);
         pr_default.close(3);
         /* Using cursor T002G6 */
         pr_default.execute(4, new Object[] {n169CobBanCod, A169CobBanCod, n170CobCbCod, A170CobCbCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A169CobBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A170CobCbCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Cobranza Banco'.", "ForeignKeyNotFound", 1, "COBCBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T002G7 */
         pr_default.execute(5, new Object[] {n168CobConBCod, A168CobConBCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A168CobConBCod) ) )
            {
               GX_msglist.addItem("No existe 'Concepto Banco'.", "ForeignKeyNotFound", 1, "COBCONBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobConBCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A666CobUsuFec) || ( A666CobUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "COBUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtCobUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2G84( )
      {
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( string A166CobTip ,
                               string A167CobCod )
      {
         /* Using cursor T002G13 */
         pr_default.execute(8, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A664CobTot = T002G13_A664CobTot[0];
            n664CobTot = T002G13_n664CobTot[0];
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         }
         else
         {
            A664CobTot = 0;
            n664CobTot = false;
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A664CobTot, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_4( int A172CobMon )
      {
         /* Using cursor T002G14 */
         pr_default.execute(9, new Object[] {A172CobMon});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "COBMON");
            AnyError = 1;
            GX_FocusControl = edtCobMon_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A657CobMonDsc = T002G14_A657CobMonDsc[0];
         AssignAttri("", false, "A657CobMonDsc", A657CobMonDsc);
         A656CobMonAbr = T002G14_A656CobMonAbr[0];
         AssignAttri("", false, "A656CobMonAbr", A656CobMonAbr);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A657CobMonDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A656CobMonAbr))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_5( int A171CobVendCod )
      {
         /* Using cursor T002G15 */
         pr_default.execute(10, new Object[] {A171CobVendCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobrador'.", "ForeignKeyNotFound", 1, "COBVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCobVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A667CobVendDsc = T002G15_A667CobVendDsc[0];
         AssignAttri("", false, "A667CobVendDsc", A667CobVendDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A667CobVendDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_6( int A169CobBanCod ,
                               string A170CobCbCod )
      {
         /* Using cursor T002G16 */
         pr_default.execute(11, new Object[] {n169CobBanCod, A169CobBanCod, n170CobCbCod, A170CobCbCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A169CobBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A170CobCbCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Cobranza Banco'.", "ForeignKeyNotFound", 1, "COBCBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobBanCod_Internalname;
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

      protected void gxLoad_7( int A168CobConBCod )
      {
         /* Using cursor T002G17 */
         pr_default.execute(12, new Object[] {n168CobConBCod, A168CobConBCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A168CobConBCod) ) )
            {
               GX_msglist.addItem("No existe 'Concepto Banco'.", "ForeignKeyNotFound", 1, "COBCONBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobConBCod_Internalname;
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

      protected void GetKey2G84( )
      {
         /* Using cursor T002G18 */
         pr_default.execute(13, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound84 = 1;
         }
         else
         {
            RcdFound84 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002G3 */
         pr_default.execute(1, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2G84( 3) ;
            RcdFound84 = 1;
            A166CobTip = T002G3_A166CobTip[0];
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = T002G3_A167CobCod[0];
            AssignAttri("", false, "A167CobCod", A167CobCod);
            A655CobFec = T002G3_A655CobFec[0];
            AssignAttri("", false, "A655CobFec", context.localUtil.Format(A655CobFec, "99/99/99"));
            A1927TotalItem = T002G3_A1927TotalItem[0];
            AssignAttri("", false, "A1927TotalItem", StringUtil.LTrimStr( (decimal)(A1927TotalItem), 5, 0));
            A660CobRegistro = T002G3_A660CobRegistro[0];
            n660CobRegistro = T002G3_n660CobRegistro[0];
            AssignAttri("", false, "A660CobRegistro", A660CobRegistro);
            A644CobBanImp = T002G3_A644CobBanImp[0];
            n644CobBanImp = T002G3_n644CobBanImp[0];
            AssignAttri("", false, "A644CobBanImp", StringUtil.LTrimStr( A644CobBanImp, 15, 2));
            A643CobAfecta = T002G3_A643CobAfecta[0];
            AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            A661CobSts = T002G3_A661CobSts[0];
            AssignAttri("", false, "A661CobSts", A661CobSts);
            A668CobVouAno = T002G3_A668CobVouAno[0];
            AssignAttri("", false, "A668CobVouAno", StringUtil.LTrimStr( (decimal)(A668CobVouAno), 4, 0));
            A669CobVouMes = T002G3_A669CobVouMes[0];
            AssignAttri("", false, "A669CobVouMes", StringUtil.LTrimStr( (decimal)(A669CobVouMes), 2, 0));
            A662CobTAsiCod = T002G3_A662CobTAsiCod[0];
            AssignAttri("", false, "A662CobTAsiCod", StringUtil.LTrimStr( (decimal)(A662CobTAsiCod), 6, 0));
            A670CobVouNum = T002G3_A670CobVouNum[0];
            AssignAttri("", false, "A670CobVouNum", A670CobVouNum);
            A665CobUsuCod = T002G3_A665CobUsuCod[0];
            AssignAttri("", false, "A665CobUsuCod", A665CobUsuCod);
            A666CobUsuFec = T002G3_A666CobUsuFec[0];
            AssignAttri("", false, "A666CobUsuFec", context.localUtil.TToC( A666CobUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A172CobMon = T002G3_A172CobMon[0];
            AssignAttri("", false, "A172CobMon", StringUtil.LTrimStr( (decimal)(A172CobMon), 6, 0));
            A171CobVendCod = T002G3_A171CobVendCod[0];
            AssignAttri("", false, "A171CobVendCod", StringUtil.LTrimStr( (decimal)(A171CobVendCod), 6, 0));
            A169CobBanCod = T002G3_A169CobBanCod[0];
            n169CobBanCod = T002G3_n169CobBanCod[0];
            AssignAttri("", false, "A169CobBanCod", StringUtil.LTrimStr( (decimal)(A169CobBanCod), 6, 0));
            A170CobCbCod = T002G3_A170CobCbCod[0];
            n170CobCbCod = T002G3_n170CobCbCod[0];
            AssignAttri("", false, "A170CobCbCod", A170CobCbCod);
            A168CobConBCod = T002G3_A168CobConBCod[0];
            n168CobConBCod = T002G3_n168CobConBCod[0];
            AssignAttri("", false, "A168CobConBCod", StringUtil.LTrimStr( (decimal)(A168CobConBCod), 6, 0));
            Z166CobTip = A166CobTip;
            Z167CobCod = A167CobCod;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2G84( ) ;
            if ( AnyError == 1 )
            {
               RcdFound84 = 0;
               InitializeNonKey2G84( ) ;
            }
            Gx_mode = sMode84;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound84 = 0;
            InitializeNonKey2G84( ) ;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode84;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2G84( ) ;
         if ( RcdFound84 == 0 )
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
         RcdFound84 = 0;
         /* Using cursor T002G19 */
         pr_default.execute(14, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T002G19_A166CobTip[0], A166CobTip) < 0 ) || ( StringUtil.StrCmp(T002G19_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002G19_A167CobCod[0], A167CobCod) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T002G19_A166CobTip[0], A166CobTip) > 0 ) || ( StringUtil.StrCmp(T002G19_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002G19_A167CobCod[0], A167CobCod) > 0 ) ) )
            {
               A166CobTip = T002G19_A166CobTip[0];
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = T002G19_A167CobCod[0];
               AssignAttri("", false, "A167CobCod", A167CobCod);
               RcdFound84 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound84 = 0;
         /* Using cursor T002G20 */
         pr_default.execute(15, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T002G20_A166CobTip[0], A166CobTip) > 0 ) || ( StringUtil.StrCmp(T002G20_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002G20_A167CobCod[0], A167CobCod) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T002G20_A166CobTip[0], A166CobTip) < 0 ) || ( StringUtil.StrCmp(T002G20_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002G20_A167CobCod[0], A167CobCod) < 0 ) ) )
            {
               A166CobTip = T002G20_A166CobTip[0];
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = T002G20_A167CobCod[0];
               AssignAttri("", false, "A167CobCod", A167CobCod);
               RcdFound84 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2G84( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2G84( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound84 == 1 )
            {
               if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) )
               {
                  A166CobTip = Z166CobTip;
                  AssignAttri("", false, "A166CobTip", A166CobTip);
                  A167CobCod = Z167CobCod;
                  AssignAttri("", false, "A167CobCod", A167CobCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COBTIP");
                  AnyError = 1;
                  GX_FocusControl = edtCobTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCobTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2G84( ) ;
                  GX_FocusControl = edtCobTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCobTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2G84( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COBTIP");
                     AnyError = 1;
                     GX_FocusControl = edtCobTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCobTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2G84( ) ;
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
         if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) )
         {
            A166CobTip = Z166CobTip;
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = Z167CobCod;
            AssignAttri("", false, "A167CobCod", A167CobCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COBTIP");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCobTip_Internalname;
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
         GetKey2G84( ) ;
         if ( RcdFound84 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "COBTIP");
               AnyError = 1;
               GX_FocusControl = edtCobTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) )
            {
               A166CobTip = Z166CobTip;
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = Z167CobCod;
               AssignAttri("", false, "A167CobCod", A167CobCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "COBTIP");
               AnyError = 1;
               GX_FocusControl = edtCobTip_Internalname;
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
            if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COBTIP");
                  AnyError = 1;
                  GX_FocusControl = edtCobTip_Internalname;
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
         context.RollbackDataStores("clcobranza",pr_default);
         GX_FocusControl = edtCobFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2G0( ) ;
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
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COBTIP");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCobFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2G84( ) ;
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2G84( ) ;
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
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobFec_Internalname;
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
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobFec_Internalname;
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
         ScanStart2G84( ) ;
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound84 != 0 )
            {
               ScanNext2G84( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2G84( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2G84( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002G2 */
            pr_default.execute(0, new Object[] {A166CobTip, A167CobCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOBRANZA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z655CobFec ) != DateTimeUtil.ResetTime ( T002G2_A655CobFec[0] ) ) || ( Z1927TotalItem != T002G2_A1927TotalItem[0] ) || ( StringUtil.StrCmp(Z660CobRegistro, T002G2_A660CobRegistro[0]) != 0 ) || ( Z644CobBanImp != T002G2_A644CobBanImp[0] ) || ( Z643CobAfecta != T002G2_A643CobAfecta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z661CobSts, T002G2_A661CobSts[0]) != 0 ) || ( Z668CobVouAno != T002G2_A668CobVouAno[0] ) || ( Z669CobVouMes != T002G2_A669CobVouMes[0] ) || ( Z662CobTAsiCod != T002G2_A662CobTAsiCod[0] ) || ( StringUtil.StrCmp(Z670CobVouNum, T002G2_A670CobVouNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z665CobUsuCod, T002G2_A665CobUsuCod[0]) != 0 ) || ( Z666CobUsuFec != T002G2_A666CobUsuFec[0] ) || ( Z172CobMon != T002G2_A172CobMon[0] ) || ( Z171CobVendCod != T002G2_A171CobVendCod[0] ) || ( Z169CobBanCod != T002G2_A169CobBanCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z170CobCbCod, T002G2_A170CobCbCod[0]) != 0 ) || ( Z168CobConBCod != T002G2_A168CobConBCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z655CobFec ) != DateTimeUtil.ResetTime ( T002G2_A655CobFec[0] ) )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobFec");
                  GXUtil.WriteLogRaw("Old: ",Z655CobFec);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A655CobFec[0]);
               }
               if ( Z1927TotalItem != T002G2_A1927TotalItem[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"TotalItem");
                  GXUtil.WriteLogRaw("Old: ",Z1927TotalItem);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A1927TotalItem[0]);
               }
               if ( StringUtil.StrCmp(Z660CobRegistro, T002G2_A660CobRegistro[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z660CobRegistro);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A660CobRegistro[0]);
               }
               if ( Z644CobBanImp != T002G2_A644CobBanImp[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobBanImp");
                  GXUtil.WriteLogRaw("Old: ",Z644CobBanImp);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A644CobBanImp[0]);
               }
               if ( Z643CobAfecta != T002G2_A643CobAfecta[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobAfecta");
                  GXUtil.WriteLogRaw("Old: ",Z643CobAfecta);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A643CobAfecta[0]);
               }
               if ( StringUtil.StrCmp(Z661CobSts, T002G2_A661CobSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobSts");
                  GXUtil.WriteLogRaw("Old: ",Z661CobSts);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A661CobSts[0]);
               }
               if ( Z668CobVouAno != T002G2_A668CobVouAno[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z668CobVouAno);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A668CobVouAno[0]);
               }
               if ( Z669CobVouMes != T002G2_A669CobVouMes[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z669CobVouMes);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A669CobVouMes[0]);
               }
               if ( Z662CobTAsiCod != T002G2_A662CobTAsiCod[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobTAsiCod");
                  GXUtil.WriteLogRaw("Old: ",Z662CobTAsiCod);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A662CobTAsiCod[0]);
               }
               if ( StringUtil.StrCmp(Z670CobVouNum, T002G2_A670CobVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z670CobVouNum);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A670CobVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z665CobUsuCod, T002G2_A665CobUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z665CobUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A665CobUsuCod[0]);
               }
               if ( Z666CobUsuFec != T002G2_A666CobUsuFec[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z666CobUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A666CobUsuFec[0]);
               }
               if ( Z172CobMon != T002G2_A172CobMon[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobMon");
                  GXUtil.WriteLogRaw("Old: ",Z172CobMon);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A172CobMon[0]);
               }
               if ( Z171CobVendCod != T002G2_A171CobVendCod[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobVendCod");
                  GXUtil.WriteLogRaw("Old: ",Z171CobVendCod);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A171CobVendCod[0]);
               }
               if ( Z169CobBanCod != T002G2_A169CobBanCod[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z169CobBanCod);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A169CobBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z170CobCbCod, T002G2_A170CobCbCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobCbCod");
                  GXUtil.WriteLogRaw("Old: ",Z170CobCbCod);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A170CobCbCod[0]);
               }
               if ( Z168CobConBCod != T002G2_A168CobConBCod[0] )
               {
                  GXUtil.WriteLog("clcobranza:[seudo value changed for attri]"+"CobConBCod");
                  GXUtil.WriteLogRaw("Old: ",Z168CobConBCod);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A168CobConBCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCOBRANZA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2G84( )
      {
         BeforeValidate2G84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G84( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2G84( 0) ;
            CheckOptimisticConcurrency2G84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2G84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G21 */
                     pr_default.execute(16, new Object[] {A166CobTip, A167CobCod, A655CobFec, A1927TotalItem, n660CobRegistro, A660CobRegistro, n644CobBanImp, A644CobBanImp, A643CobAfecta, A661CobSts, A668CobVouAno, A669CobVouMes, A662CobTAsiCod, A670CobVouNum, A665CobUsuCod, A666CobUsuFec, A172CobMon, A171CobVendCod, n169CobBanCod, A169CobBanCod, n170CobCbCod, A170CobCbCod, n168CobConBCod, A168CobConBCod});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOBRANZA");
                     if ( (pr_default.getStatus(16) == 1) )
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
                           ResetCaption2G0( ) ;
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
               Load2G84( ) ;
            }
            EndLevel2G84( ) ;
         }
         CloseExtendedTableCursors2G84( ) ;
      }

      protected void Update2G84( )
      {
         BeforeValidate2G84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G84( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2G84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G22 */
                     pr_default.execute(17, new Object[] {A655CobFec, A1927TotalItem, n660CobRegistro, A660CobRegistro, n644CobBanImp, A644CobBanImp, A643CobAfecta, A661CobSts, A668CobVouAno, A669CobVouMes, A662CobTAsiCod, A670CobVouNum, A665CobUsuCod, A666CobUsuFec, A172CobMon, A171CobVendCod, n169CobBanCod, A169CobBanCod, n170CobCbCod, A170CobCbCod, n168CobConBCod, A168CobConBCod, A166CobTip, A167CobCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOBRANZA");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOBRANZA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2G84( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2G0( ) ;
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
            EndLevel2G84( ) ;
         }
         CloseExtendedTableCursors2G84( ) ;
      }

      protected void DeferredUpdate2G84( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2G84( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G84( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2G84( ) ;
            AfterConfirm2G84( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2G84( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002G23 */
                  pr_default.execute(18, new Object[] {A166CobTip, A167CobCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCOBRANZA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound84 == 0 )
                        {
                           InitAll2G84( ) ;
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
                        ResetCaption2G0( ) ;
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
         sMode84 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2G84( ) ;
         Gx_mode = sMode84;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2G84( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002G25 */
            pr_default.execute(19, new Object[] {A166CobTip, A167CobCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A664CobTot = T002G25_A664CobTot[0];
               n664CobTot = T002G25_n664CobTot[0];
               AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
            }
            else
            {
               A664CobTot = 0;
               n664CobTot = false;
               AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
            }
            pr_default.close(19);
            /* Using cursor T002G26 */
            pr_default.execute(20, new Object[] {A172CobMon});
            A657CobMonDsc = T002G26_A657CobMonDsc[0];
            AssignAttri("", false, "A657CobMonDsc", A657CobMonDsc);
            A656CobMonAbr = T002G26_A656CobMonAbr[0];
            AssignAttri("", false, "A656CobMonAbr", A656CobMonAbr);
            pr_default.close(20);
            /* Using cursor T002G27 */
            pr_default.execute(21, new Object[] {A171CobVendCod});
            A667CobVendDsc = T002G27_A667CobVendDsc[0];
            AssignAttri("", false, "A667CobVendDsc", A667CobVendDsc);
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002G28 */
            pr_default.execute(22, new Object[] {A166CobTip, A167CobCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel2G84( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2G84( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            context.CommitDataStores("clcobranza",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            context.RollbackDataStores("clcobranza",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2G84( )
      {
         /* Using cursor T002G29 */
         pr_default.execute(23);
         RcdFound84 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound84 = 1;
            A166CobTip = T002G29_A166CobTip[0];
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = T002G29_A167CobCod[0];
            AssignAttri("", false, "A167CobCod", A167CobCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2G84( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound84 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound84 = 1;
            A166CobTip = T002G29_A166CobTip[0];
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = T002G29_A167CobCod[0];
            AssignAttri("", false, "A167CobCod", A167CobCod);
         }
      }

      protected void ScanEnd2G84( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm2G84( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2G84( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2G84( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2G84( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2G84( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2G84( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2G84( )
      {
         edtCobTip_Enabled = 0;
         AssignProp("", false, edtCobTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobTip_Enabled), 5, 0), true);
         edtCobCod_Enabled = 0;
         AssignProp("", false, edtCobCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobCod_Enabled), 5, 0), true);
         edtCobFec_Enabled = 0;
         AssignProp("", false, edtCobFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobFec_Enabled), 5, 0), true);
         edtCobMon_Enabled = 0;
         AssignProp("", false, edtCobMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobMon_Enabled), 5, 0), true);
         edtCobMonDsc_Enabled = 0;
         AssignProp("", false, edtCobMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobMonDsc_Enabled), 5, 0), true);
         edtCobMonAbr_Enabled = 0;
         AssignProp("", false, edtCobMonAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobMonAbr_Enabled), 5, 0), true);
         edtCobVendCod_Enabled = 0;
         AssignProp("", false, edtCobVendCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobVendCod_Enabled), 5, 0), true);
         edtCobVendDsc_Enabled = 0;
         AssignProp("", false, edtCobVendDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobVendDsc_Enabled), 5, 0), true);
         edtTotalItem_Enabled = 0;
         AssignProp("", false, edtTotalItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTotalItem_Enabled), 5, 0), true);
         edtCobBanCod_Enabled = 0;
         AssignProp("", false, edtCobBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobBanCod_Enabled), 5, 0), true);
         edtCobCbCod_Enabled = 0;
         AssignProp("", false, edtCobCbCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobCbCod_Enabled), 5, 0), true);
         edtCobConBCod_Enabled = 0;
         AssignProp("", false, edtCobConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobConBCod_Enabled), 5, 0), true);
         edtCobRegistro_Enabled = 0;
         AssignProp("", false, edtCobRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobRegistro_Enabled), 5, 0), true);
         edtCobBanImp_Enabled = 0;
         AssignProp("", false, edtCobBanImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobBanImp_Enabled), 5, 0), true);
         edtCobAfecta_Enabled = 0;
         AssignProp("", false, edtCobAfecta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobAfecta_Enabled), 5, 0), true);
         edtCobSts_Enabled = 0;
         AssignProp("", false, edtCobSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobSts_Enabled), 5, 0), true);
         edtCobVouAno_Enabled = 0;
         AssignProp("", false, edtCobVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobVouAno_Enabled), 5, 0), true);
         edtCobVouMes_Enabled = 0;
         AssignProp("", false, edtCobVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobVouMes_Enabled), 5, 0), true);
         edtCobTAsiCod_Enabled = 0;
         AssignProp("", false, edtCobTAsiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobTAsiCod_Enabled), 5, 0), true);
         edtCobVouNum_Enabled = 0;
         AssignProp("", false, edtCobVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobVouNum_Enabled), 5, 0), true);
         edtCobTot_Enabled = 0;
         AssignProp("", false, edtCobTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobTot_Enabled), 5, 0), true);
         edtCobUsuCod_Enabled = 0;
         AssignProp("", false, edtCobUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobUsuCod_Enabled), 5, 0), true);
         edtCobUsuFec_Enabled = 0;
         AssignProp("", false, edtCobUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobUsuFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2G84( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816424510", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clcobranza.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z166CobTip", StringUtil.RTrim( Z166CobTip));
         GxWebStd.gx_hidden_field( context, "Z167CobCod", StringUtil.RTrim( Z167CobCod));
         GxWebStd.gx_hidden_field( context, "Z655CobFec", context.localUtil.DToC( Z655CobFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1927TotalItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1927TotalItem), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z660CobRegistro", StringUtil.RTrim( Z660CobRegistro));
         GxWebStd.gx_hidden_field( context, "Z644CobBanImp", StringUtil.LTrim( StringUtil.NToC( Z644CobBanImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z643CobAfecta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z643CobAfecta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z661CobSts", StringUtil.RTrim( Z661CobSts));
         GxWebStd.gx_hidden_field( context, "Z668CobVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z668CobVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z669CobVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z669CobVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z662CobTAsiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z662CobTAsiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z670CobVouNum", StringUtil.RTrim( Z670CobVouNum));
         GxWebStd.gx_hidden_field( context, "Z665CobUsuCod", StringUtil.RTrim( Z665CobUsuCod));
         GxWebStd.gx_hidden_field( context, "Z666CobUsuFec", context.localUtil.TToC( Z666CobUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z172CobMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z172CobMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z171CobVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z171CobVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z169CobBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z169CobBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z170CobCbCod", StringUtil.RTrim( Z170CobCbCod));
         GxWebStd.gx_hidden_field( context, "Z168CobConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168CobConBCod), 6, 0, ".", "")));
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
         return formatLink("clcobranza.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCOBRANZA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cobranza - Cabecera" ;
      }

      protected void InitializeNonKey2G84( )
      {
         A655CobFec = DateTime.MinValue;
         AssignAttri("", false, "A655CobFec", context.localUtil.Format(A655CobFec, "99/99/99"));
         A172CobMon = 0;
         AssignAttri("", false, "A172CobMon", StringUtil.LTrimStr( (decimal)(A172CobMon), 6, 0));
         A657CobMonDsc = "";
         AssignAttri("", false, "A657CobMonDsc", A657CobMonDsc);
         A656CobMonAbr = "";
         AssignAttri("", false, "A656CobMonAbr", A656CobMonAbr);
         A171CobVendCod = 0;
         AssignAttri("", false, "A171CobVendCod", StringUtil.LTrimStr( (decimal)(A171CobVendCod), 6, 0));
         A667CobVendDsc = "";
         AssignAttri("", false, "A667CobVendDsc", A667CobVendDsc);
         A1927TotalItem = 0;
         AssignAttri("", false, "A1927TotalItem", StringUtil.LTrimStr( (decimal)(A1927TotalItem), 5, 0));
         A169CobBanCod = 0;
         n169CobBanCod = false;
         AssignAttri("", false, "A169CobBanCod", StringUtil.LTrimStr( (decimal)(A169CobBanCod), 6, 0));
         n169CobBanCod = ((0==A169CobBanCod) ? true : false);
         A170CobCbCod = "";
         n170CobCbCod = false;
         AssignAttri("", false, "A170CobCbCod", A170CobCbCod);
         n170CobCbCod = (String.IsNullOrEmpty(StringUtil.RTrim( A170CobCbCod)) ? true : false);
         A168CobConBCod = 0;
         n168CobConBCod = false;
         AssignAttri("", false, "A168CobConBCod", StringUtil.LTrimStr( (decimal)(A168CobConBCod), 6, 0));
         n168CobConBCod = ((0==A168CobConBCod) ? true : false);
         A660CobRegistro = "";
         n660CobRegistro = false;
         AssignAttri("", false, "A660CobRegistro", A660CobRegistro);
         n660CobRegistro = (String.IsNullOrEmpty(StringUtil.RTrim( A660CobRegistro)) ? true : false);
         A644CobBanImp = 0;
         n644CobBanImp = false;
         AssignAttri("", false, "A644CobBanImp", StringUtil.LTrimStr( A644CobBanImp, 15, 2));
         n644CobBanImp = ((Convert.ToDecimal(0)==A644CobBanImp) ? true : false);
         A643CobAfecta = 0;
         AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
         A661CobSts = "";
         AssignAttri("", false, "A661CobSts", A661CobSts);
         A668CobVouAno = 0;
         AssignAttri("", false, "A668CobVouAno", StringUtil.LTrimStr( (decimal)(A668CobVouAno), 4, 0));
         A669CobVouMes = 0;
         AssignAttri("", false, "A669CobVouMes", StringUtil.LTrimStr( (decimal)(A669CobVouMes), 2, 0));
         A662CobTAsiCod = 0;
         AssignAttri("", false, "A662CobTAsiCod", StringUtil.LTrimStr( (decimal)(A662CobTAsiCod), 6, 0));
         A670CobVouNum = "";
         AssignAttri("", false, "A670CobVouNum", A670CobVouNum);
         A664CobTot = 0;
         n664CobTot = false;
         AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         A665CobUsuCod = "";
         AssignAttri("", false, "A665CobUsuCod", A665CobUsuCod);
         A666CobUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A666CobUsuFec", context.localUtil.TToC( A666CobUsuFec, 8, 5, 0, 3, "/", ":", " "));
         Z655CobFec = DateTime.MinValue;
         Z1927TotalItem = 0;
         Z660CobRegistro = "";
         Z644CobBanImp = 0;
         Z643CobAfecta = 0;
         Z661CobSts = "";
         Z668CobVouAno = 0;
         Z669CobVouMes = 0;
         Z662CobTAsiCod = 0;
         Z670CobVouNum = "";
         Z665CobUsuCod = "";
         Z666CobUsuFec = (DateTime)(DateTime.MinValue);
         Z172CobMon = 0;
         Z171CobVendCod = 0;
         Z169CobBanCod = 0;
         Z170CobCbCod = "";
         Z168CobConBCod = 0;
      }

      protected void InitAll2G84( )
      {
         A166CobTip = "";
         AssignAttri("", false, "A166CobTip", A166CobTip);
         A167CobCod = "";
         AssignAttri("", false, "A167CobCod", A167CobCod);
         InitializeNonKey2G84( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816424529", true, true);
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
         context.AddJavascriptSource("clcobranza.js", "?202281816424529", false, true);
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
         edtCobTip_Internalname = "COBTIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCobCod_Internalname = "COBCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCobFec_Internalname = "COBFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCobMon_Internalname = "COBMON";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCobMonDsc_Internalname = "COBMONDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCobMonAbr_Internalname = "COBMONABR";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCobVendCod_Internalname = "COBVENDCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCobVendDsc_Internalname = "COBVENDDSC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtTotalItem_Internalname = "TOTALITEM";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCobBanCod_Internalname = "COBBANCOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCobCbCod_Internalname = "COBCBCOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtCobConBCod_Internalname = "COBCONBCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtCobRegistro_Internalname = "COBREGISTRO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtCobBanImp_Internalname = "COBBANIMP";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtCobAfecta_Internalname = "COBAFECTA";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtCobSts_Internalname = "COBSTS";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtCobVouAno_Internalname = "COBVOUANO";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtCobVouMes_Internalname = "COBVOUMES";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtCobTAsiCod_Internalname = "COBTASICOD";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtCobVouNum_Internalname = "COBVOUNUM";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtCobTot_Internalname = "COBTOT";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtCobUsuCod_Internalname = "COBUSUCOD";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtCobUsuFec_Internalname = "COBUSUFEC";
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
         Form.Caption = "Cobranza - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCobUsuFec_Jsonclick = "";
         edtCobUsuFec_Enabled = 1;
         edtCobUsuCod_Jsonclick = "";
         edtCobUsuCod_Enabled = 1;
         edtCobTot_Jsonclick = "";
         edtCobTot_Enabled = 0;
         edtCobVouNum_Jsonclick = "";
         edtCobVouNum_Enabled = 1;
         edtCobTAsiCod_Jsonclick = "";
         edtCobTAsiCod_Enabled = 1;
         edtCobVouMes_Jsonclick = "";
         edtCobVouMes_Enabled = 1;
         edtCobVouAno_Jsonclick = "";
         edtCobVouAno_Enabled = 1;
         edtCobSts_Jsonclick = "";
         edtCobSts_Enabled = 1;
         edtCobAfecta_Jsonclick = "";
         edtCobAfecta_Enabled = 1;
         edtCobBanImp_Jsonclick = "";
         edtCobBanImp_Enabled = 1;
         edtCobRegistro_Jsonclick = "";
         edtCobRegistro_Enabled = 1;
         edtCobConBCod_Jsonclick = "";
         edtCobConBCod_Enabled = 1;
         edtCobCbCod_Jsonclick = "";
         edtCobCbCod_Enabled = 1;
         edtCobBanCod_Jsonclick = "";
         edtCobBanCod_Enabled = 1;
         edtTotalItem_Jsonclick = "";
         edtTotalItem_Enabled = 1;
         edtCobVendDsc_Jsonclick = "";
         edtCobVendDsc_Enabled = 0;
         edtCobVendCod_Jsonclick = "";
         edtCobVendCod_Enabled = 1;
         edtCobMonAbr_Jsonclick = "";
         edtCobMonAbr_Enabled = 0;
         edtCobMonDsc_Jsonclick = "";
         edtCobMonDsc_Enabled = 0;
         edtCobMon_Jsonclick = "";
         edtCobMon_Enabled = 1;
         edtCobFec_Jsonclick = "";
         edtCobFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCobCod_Jsonclick = "";
         edtCobCod_Enabled = 1;
         edtCobTip_Jsonclick = "";
         edtCobTip_Enabled = 1;
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
         /* Using cursor T002G25 */
         pr_default.execute(19, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A664CobTot = T002G25_A664CobTot[0];
            n664CobTot = T002G25_n664CobTot[0];
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         }
         else
         {
            A664CobTot = 0;
            n664CobTot = false;
            AssignAttri("", false, "A664CobTot", StringUtil.LTrimStr( A664CobTot, 15, 2));
         }
         pr_default.close(19);
         GX_FocusControl = edtCobFec_Internalname;
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

      public void Valid_Cobcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002G25 */
         pr_default.execute(19, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A664CobTot = T002G25_A664CobTot[0];
            n664CobTot = T002G25_n664CobTot[0];
         }
         else
         {
            A664CobTot = 0;
            n664CobTot = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A655CobFec", context.localUtil.Format(A655CobFec, "99/99/99"));
         AssignAttri("", false, "A172CobMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A172CobMon), 6, 0, ".", "")));
         AssignAttri("", false, "A171CobVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A171CobVendCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1927TotalItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1927TotalItem), 5, 0, ".", "")));
         AssignAttri("", false, "A169CobBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A169CobBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A170CobCbCod", StringUtil.RTrim( A170CobCbCod));
         AssignAttri("", false, "A168CobConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168CobConBCod), 6, 0, ".", "")));
         AssignAttri("", false, "A660CobRegistro", StringUtil.RTrim( A660CobRegistro));
         AssignAttri("", false, "A644CobBanImp", StringUtil.LTrim( StringUtil.NToC( A644CobBanImp, 15, 2, ".", "")));
         AssignAttri("", false, "A643CobAfecta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A643CobAfecta), 1, 0, ".", "")));
         AssignAttri("", false, "A661CobSts", StringUtil.RTrim( A661CobSts));
         AssignAttri("", false, "A668CobVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A668CobVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A669CobVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A669CobVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A662CobTAsiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A662CobTAsiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A670CobVouNum", StringUtil.RTrim( A670CobVouNum));
         AssignAttri("", false, "A665CobUsuCod", StringUtil.RTrim( A665CobUsuCod));
         AssignAttri("", false, "A666CobUsuFec", context.localUtil.TToC( A666CobUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A664CobTot", StringUtil.LTrim( StringUtil.NToC( A664CobTot, 15, 2, ".", "")));
         AssignAttri("", false, "A657CobMonDsc", StringUtil.RTrim( A657CobMonDsc));
         AssignAttri("", false, "A656CobMonAbr", StringUtil.RTrim( A656CobMonAbr));
         AssignAttri("", false, "A667CobVendDsc", StringUtil.RTrim( A667CobVendDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z166CobTip", StringUtil.RTrim( Z166CobTip));
         GxWebStd.gx_hidden_field( context, "Z167CobCod", StringUtil.RTrim( Z167CobCod));
         GxWebStd.gx_hidden_field( context, "Z655CobFec", context.localUtil.Format(Z655CobFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z172CobMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z172CobMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z171CobVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z171CobVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1927TotalItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1927TotalItem), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z169CobBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z169CobBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z170CobCbCod", StringUtil.RTrim( Z170CobCbCod));
         GxWebStd.gx_hidden_field( context, "Z168CobConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168CobConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z660CobRegistro", StringUtil.RTrim( Z660CobRegistro));
         GxWebStd.gx_hidden_field( context, "Z644CobBanImp", StringUtil.LTrim( StringUtil.NToC( Z644CobBanImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z643CobAfecta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z643CobAfecta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z661CobSts", StringUtil.RTrim( Z661CobSts));
         GxWebStd.gx_hidden_field( context, "Z668CobVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z668CobVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z669CobVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z669CobVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z662CobTAsiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z662CobTAsiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z670CobVouNum", StringUtil.RTrim( Z670CobVouNum));
         GxWebStd.gx_hidden_field( context, "Z665CobUsuCod", StringUtil.RTrim( Z665CobUsuCod));
         GxWebStd.gx_hidden_field( context, "Z666CobUsuFec", context.localUtil.TToC( Z666CobUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z664CobTot", StringUtil.LTrim( StringUtil.NToC( Z664CobTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z657CobMonDsc", StringUtil.RTrim( Z657CobMonDsc));
         GxWebStd.gx_hidden_field( context, "Z656CobMonAbr", StringUtil.RTrim( Z656CobMonAbr));
         GxWebStd.gx_hidden_field( context, "Z667CobVendDsc", StringUtil.RTrim( Z667CobVendDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cobmon( )
      {
         /* Using cursor T002G26 */
         pr_default.execute(20, new Object[] {A172CobMon});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "COBMON");
            AnyError = 1;
            GX_FocusControl = edtCobMon_Internalname;
         }
         A657CobMonDsc = T002G26_A657CobMonDsc[0];
         A656CobMonAbr = T002G26_A656CobMonAbr[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A657CobMonDsc", StringUtil.RTrim( A657CobMonDsc));
         AssignAttri("", false, "A656CobMonAbr", StringUtil.RTrim( A656CobMonAbr));
      }

      public void Valid_Cobvendcod( )
      {
         /* Using cursor T002G27 */
         pr_default.execute(21, new Object[] {A171CobVendCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobrador'.", "ForeignKeyNotFound", 1, "COBVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCobVendCod_Internalname;
         }
         A667CobVendDsc = T002G27_A667CobVendDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A667CobVendDsc", StringUtil.RTrim( A667CobVendDsc));
      }

      public void Valid_Cobcbcod( )
      {
         n169CobBanCod = false;
         n170CobCbCod = false;
         /* Using cursor T002G30 */
         pr_default.execute(24, new Object[] {n169CobBanCod, A169CobBanCod, n170CobCbCod, A170CobCbCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A169CobBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A170CobCbCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Cobranza Banco'.", "ForeignKeyNotFound", 1, "COBCBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobBanCod_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cobconbcod( )
      {
         n168CobConBCod = false;
         /* Using cursor T002G31 */
         pr_default.execute(25, new Object[] {n168CobConBCod, A168CobConBCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A168CobConBCod) ) )
            {
               GX_msglist.addItem("No existe 'Concepto Banco'.", "ForeignKeyNotFound", 1, "COBCONBCOD");
               AnyError = 1;
               GX_FocusControl = edtCobConBCod_Internalname;
            }
         }
         pr_default.close(25);
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
         setEventMetadata("VALID_COBTIP","{handler:'Valid_Cobtip',iparms:[]");
         setEventMetadata("VALID_COBTIP",",oparms:[]}");
         setEventMetadata("VALID_COBCOD","{handler:'Valid_Cobcod',iparms:[{av:'A166CobTip',fld:'COBTIP',pic:''},{av:'A167CobCod',fld:'COBCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COBCOD",",oparms:[{av:'A655CobFec',fld:'COBFEC',pic:''},{av:'A172CobMon',fld:'COBMON',pic:'ZZZZZ9'},{av:'A171CobVendCod',fld:'COBVENDCOD',pic:'ZZZZZ9'},{av:'A1927TotalItem',fld:'TOTALITEM',pic:'ZZZZ9'},{av:'A169CobBanCod',fld:'COBBANCOD',pic:'ZZZZZ9'},{av:'A170CobCbCod',fld:'COBCBCOD',pic:''},{av:'A168CobConBCod',fld:'COBCONBCOD',pic:'ZZZZZ9'},{av:'A660CobRegistro',fld:'COBREGISTRO',pic:''},{av:'A644CobBanImp',fld:'COBBANIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'},{av:'A661CobSts',fld:'COBSTS',pic:''},{av:'A668CobVouAno',fld:'COBVOUANO',pic:'ZZZ9'},{av:'A669CobVouMes',fld:'COBVOUMES',pic:'Z9'},{av:'A662CobTAsiCod',fld:'COBTASICOD',pic:'ZZZZZ9'},{av:'A670CobVouNum',fld:'COBVOUNUM',pic:''},{av:'A665CobUsuCod',fld:'COBUSUCOD',pic:''},{av:'A666CobUsuFec',fld:'COBUSUFEC',pic:'99/99/99 99:99'},{av:'A664CobTot',fld:'COBTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A657CobMonDsc',fld:'COBMONDSC',pic:''},{av:'A656CobMonAbr',fld:'COBMONABR',pic:''},{av:'A667CobVendDsc',fld:'COBVENDDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z166CobTip'},{av:'Z167CobCod'},{av:'Z655CobFec'},{av:'Z172CobMon'},{av:'Z171CobVendCod'},{av:'Z1927TotalItem'},{av:'Z169CobBanCod'},{av:'Z170CobCbCod'},{av:'Z168CobConBCod'},{av:'Z660CobRegistro'},{av:'Z644CobBanImp'},{av:'Z643CobAfecta'},{av:'Z661CobSts'},{av:'Z668CobVouAno'},{av:'Z669CobVouMes'},{av:'Z662CobTAsiCod'},{av:'Z670CobVouNum'},{av:'Z665CobUsuCod'},{av:'Z666CobUsuFec'},{av:'Z664CobTot'},{av:'Z657CobMonDsc'},{av:'Z656CobMonAbr'},{av:'Z667CobVendDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_COBFEC","{handler:'Valid_Cobfec',iparms:[]");
         setEventMetadata("VALID_COBFEC",",oparms:[]}");
         setEventMetadata("VALID_COBMON","{handler:'Valid_Cobmon',iparms:[{av:'A172CobMon',fld:'COBMON',pic:'ZZZZZ9'},{av:'A657CobMonDsc',fld:'COBMONDSC',pic:''},{av:'A656CobMonAbr',fld:'COBMONABR',pic:''}]");
         setEventMetadata("VALID_COBMON",",oparms:[{av:'A657CobMonDsc',fld:'COBMONDSC',pic:''},{av:'A656CobMonAbr',fld:'COBMONABR',pic:''}]}");
         setEventMetadata("VALID_COBVENDCOD","{handler:'Valid_Cobvendcod',iparms:[{av:'A171CobVendCod',fld:'COBVENDCOD',pic:'ZZZZZ9'},{av:'A667CobVendDsc',fld:'COBVENDDSC',pic:''}]");
         setEventMetadata("VALID_COBVENDCOD",",oparms:[{av:'A667CobVendDsc',fld:'COBVENDDSC',pic:''}]}");
         setEventMetadata("VALID_COBBANCOD","{handler:'Valid_Cobbancod',iparms:[]");
         setEventMetadata("VALID_COBBANCOD",",oparms:[]}");
         setEventMetadata("VALID_COBCBCOD","{handler:'Valid_Cobcbcod',iparms:[{av:'A169CobBanCod',fld:'COBBANCOD',pic:'ZZZZZ9'},{av:'A170CobCbCod',fld:'COBCBCOD',pic:''}]");
         setEventMetadata("VALID_COBCBCOD",",oparms:[]}");
         setEventMetadata("VALID_COBCONBCOD","{handler:'Valid_Cobconbcod',iparms:[{av:'A168CobConBCod',fld:'COBCONBCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COBCONBCOD",",oparms:[]}");
         setEventMetadata("VALID_COBUSUFEC","{handler:'Valid_Cobusufec',iparms:[]");
         setEventMetadata("VALID_COBUSUFEC",",oparms:[]}");
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z166CobTip = "";
         Z167CobCod = "";
         Z655CobFec = DateTime.MinValue;
         Z660CobRegistro = "";
         Z661CobSts = "";
         Z670CobVouNum = "";
         Z665CobUsuCod = "";
         Z666CobUsuFec = (DateTime)(DateTime.MinValue);
         Z170CobCbCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A166CobTip = "";
         A167CobCod = "";
         A170CobCbCod = "";
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
         A655CobFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A657CobMonDsc = "";
         lblTextblock6_Jsonclick = "";
         A656CobMonAbr = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A667CobVendDsc = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A660CobRegistro = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         A661CobSts = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         A670CobVouNum = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         A665CobUsuCod = "";
         lblTextblock23_Jsonclick = "";
         A666CobUsuFec = (DateTime)(DateTime.MinValue);
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
         Z657CobMonDsc = "";
         Z656CobMonAbr = "";
         Z667CobVendDsc = "";
         T002G11_A166CobTip = new string[] {""} ;
         T002G11_A167CobCod = new string[] {""} ;
         T002G11_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         T002G11_A657CobMonDsc = new string[] {""} ;
         T002G11_A656CobMonAbr = new string[] {""} ;
         T002G11_A667CobVendDsc = new string[] {""} ;
         T002G11_A1927TotalItem = new int[1] ;
         T002G11_A660CobRegistro = new string[] {""} ;
         T002G11_n660CobRegistro = new bool[] {false} ;
         T002G11_A644CobBanImp = new decimal[1] ;
         T002G11_n644CobBanImp = new bool[] {false} ;
         T002G11_A643CobAfecta = new short[1] ;
         T002G11_A661CobSts = new string[] {""} ;
         T002G11_A668CobVouAno = new short[1] ;
         T002G11_A669CobVouMes = new short[1] ;
         T002G11_A662CobTAsiCod = new int[1] ;
         T002G11_A670CobVouNum = new string[] {""} ;
         T002G11_A665CobUsuCod = new string[] {""} ;
         T002G11_A666CobUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002G11_A172CobMon = new int[1] ;
         T002G11_A171CobVendCod = new int[1] ;
         T002G11_A169CobBanCod = new int[1] ;
         T002G11_n169CobBanCod = new bool[] {false} ;
         T002G11_A170CobCbCod = new string[] {""} ;
         T002G11_n170CobCbCod = new bool[] {false} ;
         T002G11_A168CobConBCod = new int[1] ;
         T002G11_n168CobConBCod = new bool[] {false} ;
         T002G11_A664CobTot = new decimal[1] ;
         T002G11_n664CobTot = new bool[] {false} ;
         T002G9_A664CobTot = new decimal[1] ;
         T002G9_n664CobTot = new bool[] {false} ;
         T002G4_A657CobMonDsc = new string[] {""} ;
         T002G4_A656CobMonAbr = new string[] {""} ;
         T002G5_A667CobVendDsc = new string[] {""} ;
         T002G6_A169CobBanCod = new int[1] ;
         T002G6_n169CobBanCod = new bool[] {false} ;
         T002G7_A168CobConBCod = new int[1] ;
         T002G7_n168CobConBCod = new bool[] {false} ;
         T002G13_A664CobTot = new decimal[1] ;
         T002G13_n664CobTot = new bool[] {false} ;
         T002G14_A657CobMonDsc = new string[] {""} ;
         T002G14_A656CobMonAbr = new string[] {""} ;
         T002G15_A667CobVendDsc = new string[] {""} ;
         T002G16_A169CobBanCod = new int[1] ;
         T002G16_n169CobBanCod = new bool[] {false} ;
         T002G17_A168CobConBCod = new int[1] ;
         T002G17_n168CobConBCod = new bool[] {false} ;
         T002G18_A166CobTip = new string[] {""} ;
         T002G18_A167CobCod = new string[] {""} ;
         T002G3_A166CobTip = new string[] {""} ;
         T002G3_A167CobCod = new string[] {""} ;
         T002G3_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         T002G3_A1927TotalItem = new int[1] ;
         T002G3_A660CobRegistro = new string[] {""} ;
         T002G3_n660CobRegistro = new bool[] {false} ;
         T002G3_A644CobBanImp = new decimal[1] ;
         T002G3_n644CobBanImp = new bool[] {false} ;
         T002G3_A643CobAfecta = new short[1] ;
         T002G3_A661CobSts = new string[] {""} ;
         T002G3_A668CobVouAno = new short[1] ;
         T002G3_A669CobVouMes = new short[1] ;
         T002G3_A662CobTAsiCod = new int[1] ;
         T002G3_A670CobVouNum = new string[] {""} ;
         T002G3_A665CobUsuCod = new string[] {""} ;
         T002G3_A666CobUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002G3_A172CobMon = new int[1] ;
         T002G3_A171CobVendCod = new int[1] ;
         T002G3_A169CobBanCod = new int[1] ;
         T002G3_n169CobBanCod = new bool[] {false} ;
         T002G3_A170CobCbCod = new string[] {""} ;
         T002G3_n170CobCbCod = new bool[] {false} ;
         T002G3_A168CobConBCod = new int[1] ;
         T002G3_n168CobConBCod = new bool[] {false} ;
         sMode84 = "";
         T002G19_A166CobTip = new string[] {""} ;
         T002G19_A167CobCod = new string[] {""} ;
         T002G20_A166CobTip = new string[] {""} ;
         T002G20_A167CobCod = new string[] {""} ;
         T002G2_A166CobTip = new string[] {""} ;
         T002G2_A167CobCod = new string[] {""} ;
         T002G2_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         T002G2_A1927TotalItem = new int[1] ;
         T002G2_A660CobRegistro = new string[] {""} ;
         T002G2_n660CobRegistro = new bool[] {false} ;
         T002G2_A644CobBanImp = new decimal[1] ;
         T002G2_n644CobBanImp = new bool[] {false} ;
         T002G2_A643CobAfecta = new short[1] ;
         T002G2_A661CobSts = new string[] {""} ;
         T002G2_A668CobVouAno = new short[1] ;
         T002G2_A669CobVouMes = new short[1] ;
         T002G2_A662CobTAsiCod = new int[1] ;
         T002G2_A670CobVouNum = new string[] {""} ;
         T002G2_A665CobUsuCod = new string[] {""} ;
         T002G2_A666CobUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002G2_A172CobMon = new int[1] ;
         T002G2_A171CobVendCod = new int[1] ;
         T002G2_A169CobBanCod = new int[1] ;
         T002G2_n169CobBanCod = new bool[] {false} ;
         T002G2_A170CobCbCod = new string[] {""} ;
         T002G2_n170CobCbCod = new bool[] {false} ;
         T002G2_A168CobConBCod = new int[1] ;
         T002G2_n168CobConBCod = new bool[] {false} ;
         T002G25_A664CobTot = new decimal[1] ;
         T002G25_n664CobTot = new bool[] {false} ;
         T002G26_A657CobMonDsc = new string[] {""} ;
         T002G26_A656CobMonAbr = new string[] {""} ;
         T002G27_A667CobVendDsc = new string[] {""} ;
         T002G28_A166CobTip = new string[] {""} ;
         T002G28_A167CobCod = new string[] {""} ;
         T002G28_A173Item = new int[1] ;
         T002G29_A166CobTip = new string[] {""} ;
         T002G29_A167CobCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ166CobTip = "";
         ZZ167CobCod = "";
         ZZ655CobFec = DateTime.MinValue;
         ZZ170CobCbCod = "";
         ZZ660CobRegistro = "";
         ZZ661CobSts = "";
         ZZ670CobVouNum = "";
         ZZ665CobUsuCod = "";
         ZZ666CobUsuFec = (DateTime)(DateTime.MinValue);
         ZZ657CobMonDsc = "";
         ZZ656CobMonAbr = "";
         ZZ667CobVendDsc = "";
         T002G30_A169CobBanCod = new int[1] ;
         T002G30_n169CobBanCod = new bool[] {false} ;
         T002G31_A168CobConBCod = new int[1] ;
         T002G31_n168CobConBCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clcobranza__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clcobranza__default(),
            new Object[][] {
                new Object[] {
               T002G2_A166CobTip, T002G2_A167CobCod, T002G2_A655CobFec, T002G2_A1927TotalItem, T002G2_A660CobRegistro, T002G2_n660CobRegistro, T002G2_A644CobBanImp, T002G2_n644CobBanImp, T002G2_A643CobAfecta, T002G2_A661CobSts,
               T002G2_A668CobVouAno, T002G2_A669CobVouMes, T002G2_A662CobTAsiCod, T002G2_A670CobVouNum, T002G2_A665CobUsuCod, T002G2_A666CobUsuFec, T002G2_A172CobMon, T002G2_A171CobVendCod, T002G2_A169CobBanCod, T002G2_n169CobBanCod,
               T002G2_A170CobCbCod, T002G2_n170CobCbCod, T002G2_A168CobConBCod, T002G2_n168CobConBCod
               }
               , new Object[] {
               T002G3_A166CobTip, T002G3_A167CobCod, T002G3_A655CobFec, T002G3_A1927TotalItem, T002G3_A660CobRegistro, T002G3_n660CobRegistro, T002G3_A644CobBanImp, T002G3_n644CobBanImp, T002G3_A643CobAfecta, T002G3_A661CobSts,
               T002G3_A668CobVouAno, T002G3_A669CobVouMes, T002G3_A662CobTAsiCod, T002G3_A670CobVouNum, T002G3_A665CobUsuCod, T002G3_A666CobUsuFec, T002G3_A172CobMon, T002G3_A171CobVendCod, T002G3_A169CobBanCod, T002G3_n169CobBanCod,
               T002G3_A170CobCbCod, T002G3_n170CobCbCod, T002G3_A168CobConBCod, T002G3_n168CobConBCod
               }
               , new Object[] {
               T002G4_A657CobMonDsc, T002G4_A656CobMonAbr
               }
               , new Object[] {
               T002G5_A667CobVendDsc
               }
               , new Object[] {
               T002G6_A169CobBanCod
               }
               , new Object[] {
               T002G7_A168CobConBCod
               }
               , new Object[] {
               T002G9_A664CobTot, T002G9_n664CobTot
               }
               , new Object[] {
               T002G11_A166CobTip, T002G11_A167CobCod, T002G11_A655CobFec, T002G11_A657CobMonDsc, T002G11_A656CobMonAbr, T002G11_A667CobVendDsc, T002G11_A1927TotalItem, T002G11_A660CobRegistro, T002G11_n660CobRegistro, T002G11_A644CobBanImp,
               T002G11_n644CobBanImp, T002G11_A643CobAfecta, T002G11_A661CobSts, T002G11_A668CobVouAno, T002G11_A669CobVouMes, T002G11_A662CobTAsiCod, T002G11_A670CobVouNum, T002G11_A665CobUsuCod, T002G11_A666CobUsuFec, T002G11_A172CobMon,
               T002G11_A171CobVendCod, T002G11_A169CobBanCod, T002G11_n169CobBanCod, T002G11_A170CobCbCod, T002G11_n170CobCbCod, T002G11_A168CobConBCod, T002G11_n168CobConBCod, T002G11_A664CobTot, T002G11_n664CobTot
               }
               , new Object[] {
               T002G13_A664CobTot, T002G13_n664CobTot
               }
               , new Object[] {
               T002G14_A657CobMonDsc, T002G14_A656CobMonAbr
               }
               , new Object[] {
               T002G15_A667CobVendDsc
               }
               , new Object[] {
               T002G16_A169CobBanCod
               }
               , new Object[] {
               T002G17_A168CobConBCod
               }
               , new Object[] {
               T002G18_A166CobTip, T002G18_A167CobCod
               }
               , new Object[] {
               T002G19_A166CobTip, T002G19_A167CobCod
               }
               , new Object[] {
               T002G20_A166CobTip, T002G20_A167CobCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002G25_A664CobTot, T002G25_n664CobTot
               }
               , new Object[] {
               T002G26_A657CobMonDsc, T002G26_A656CobMonAbr
               }
               , new Object[] {
               T002G27_A667CobVendDsc
               }
               , new Object[] {
               T002G28_A166CobTip, T002G28_A167CobCod, T002G28_A173Item
               }
               , new Object[] {
               T002G29_A166CobTip, T002G29_A167CobCod
               }
               , new Object[] {
               T002G30_A169CobBanCod
               }
               , new Object[] {
               T002G31_A168CobConBCod
               }
            }
         );
      }

      private short Z643CobAfecta ;
      private short Z668CobVouAno ;
      private short Z669CobVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A643CobAfecta ;
      private short A668CobVouAno ;
      private short A669CobVouMes ;
      private short GX_JID ;
      private short RcdFound84 ;
      private short nIsDirty_84 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ643CobAfecta ;
      private short ZZ668CobVouAno ;
      private short ZZ669CobVouMes ;
      private int Z1927TotalItem ;
      private int Z662CobTAsiCod ;
      private int Z172CobMon ;
      private int Z171CobVendCod ;
      private int Z169CobBanCod ;
      private int Z168CobConBCod ;
      private int A172CobMon ;
      private int A171CobVendCod ;
      private int A169CobBanCod ;
      private int A168CobConBCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCobTip_Enabled ;
      private int edtCobCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCobFec_Enabled ;
      private int edtCobMon_Enabled ;
      private int edtCobMonDsc_Enabled ;
      private int edtCobMonAbr_Enabled ;
      private int edtCobVendCod_Enabled ;
      private int edtCobVendDsc_Enabled ;
      private int A1927TotalItem ;
      private int edtTotalItem_Enabled ;
      private int edtCobBanCod_Enabled ;
      private int edtCobCbCod_Enabled ;
      private int edtCobConBCod_Enabled ;
      private int edtCobRegistro_Enabled ;
      private int edtCobBanImp_Enabled ;
      private int edtCobAfecta_Enabled ;
      private int edtCobSts_Enabled ;
      private int edtCobVouAno_Enabled ;
      private int edtCobVouMes_Enabled ;
      private int A662CobTAsiCod ;
      private int edtCobTAsiCod_Enabled ;
      private int edtCobVouNum_Enabled ;
      private int edtCobTot_Enabled ;
      private int edtCobUsuCod_Enabled ;
      private int edtCobUsuFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ172CobMon ;
      private int ZZ171CobVendCod ;
      private int ZZ1927TotalItem ;
      private int ZZ169CobBanCod ;
      private int ZZ168CobConBCod ;
      private int ZZ662CobTAsiCod ;
      private decimal Z644CobBanImp ;
      private decimal A644CobBanImp ;
      private decimal A664CobTot ;
      private decimal Z664CobTot ;
      private decimal ZZ644CobBanImp ;
      private decimal ZZ664CobTot ;
      private string sPrefix ;
      private string Z166CobTip ;
      private string Z167CobCod ;
      private string Z660CobRegistro ;
      private string Z661CobSts ;
      private string Z670CobVouNum ;
      private string Z665CobUsuCod ;
      private string Z170CobCbCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A170CobCbCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCobTip_Internalname ;
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
      private string edtCobTip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCobCod_Internalname ;
      private string edtCobCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCobFec_Internalname ;
      private string edtCobFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCobMon_Internalname ;
      private string edtCobMon_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCobMonDsc_Internalname ;
      private string A657CobMonDsc ;
      private string edtCobMonDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCobMonAbr_Internalname ;
      private string A656CobMonAbr ;
      private string edtCobMonAbr_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCobVendCod_Internalname ;
      private string edtCobVendCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCobVendDsc_Internalname ;
      private string A667CobVendDsc ;
      private string edtCobVendDsc_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtTotalItem_Internalname ;
      private string edtTotalItem_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCobBanCod_Internalname ;
      private string edtCobBanCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCobCbCod_Internalname ;
      private string edtCobCbCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtCobConBCod_Internalname ;
      private string edtCobConBCod_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtCobRegistro_Internalname ;
      private string A660CobRegistro ;
      private string edtCobRegistro_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtCobBanImp_Internalname ;
      private string edtCobBanImp_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtCobAfecta_Internalname ;
      private string edtCobAfecta_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtCobSts_Internalname ;
      private string A661CobSts ;
      private string edtCobSts_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtCobVouAno_Internalname ;
      private string edtCobVouAno_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtCobVouMes_Internalname ;
      private string edtCobVouMes_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtCobTAsiCod_Internalname ;
      private string edtCobTAsiCod_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtCobVouNum_Internalname ;
      private string A670CobVouNum ;
      private string edtCobVouNum_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtCobTot_Internalname ;
      private string edtCobTot_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtCobUsuCod_Internalname ;
      private string A665CobUsuCod ;
      private string edtCobUsuCod_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtCobUsuFec_Internalname ;
      private string edtCobUsuFec_Jsonclick ;
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
      private string Z657CobMonDsc ;
      private string Z656CobMonAbr ;
      private string Z667CobVendDsc ;
      private string sMode84 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ166CobTip ;
      private string ZZ167CobCod ;
      private string ZZ170CobCbCod ;
      private string ZZ660CobRegistro ;
      private string ZZ661CobSts ;
      private string ZZ670CobVouNum ;
      private string ZZ665CobUsuCod ;
      private string ZZ657CobMonDsc ;
      private string ZZ656CobMonAbr ;
      private string ZZ667CobVendDsc ;
      private DateTime Z666CobUsuFec ;
      private DateTime A666CobUsuFec ;
      private DateTime ZZ666CobUsuFec ;
      private DateTime Z655CobFec ;
      private DateTime A655CobFec ;
      private DateTime ZZ655CobFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n169CobBanCod ;
      private bool n170CobCbCod ;
      private bool n168CobConBCod ;
      private bool wbErr ;
      private bool n660CobRegistro ;
      private bool n644CobBanImp ;
      private bool n664CobTot ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002G11_A166CobTip ;
      private string[] T002G11_A167CobCod ;
      private DateTime[] T002G11_A655CobFec ;
      private string[] T002G11_A657CobMonDsc ;
      private string[] T002G11_A656CobMonAbr ;
      private string[] T002G11_A667CobVendDsc ;
      private int[] T002G11_A1927TotalItem ;
      private string[] T002G11_A660CobRegistro ;
      private bool[] T002G11_n660CobRegistro ;
      private decimal[] T002G11_A644CobBanImp ;
      private bool[] T002G11_n644CobBanImp ;
      private short[] T002G11_A643CobAfecta ;
      private string[] T002G11_A661CobSts ;
      private short[] T002G11_A668CobVouAno ;
      private short[] T002G11_A669CobVouMes ;
      private int[] T002G11_A662CobTAsiCod ;
      private string[] T002G11_A670CobVouNum ;
      private string[] T002G11_A665CobUsuCod ;
      private DateTime[] T002G11_A666CobUsuFec ;
      private int[] T002G11_A172CobMon ;
      private int[] T002G11_A171CobVendCod ;
      private int[] T002G11_A169CobBanCod ;
      private bool[] T002G11_n169CobBanCod ;
      private string[] T002G11_A170CobCbCod ;
      private bool[] T002G11_n170CobCbCod ;
      private int[] T002G11_A168CobConBCod ;
      private bool[] T002G11_n168CobConBCod ;
      private decimal[] T002G11_A664CobTot ;
      private bool[] T002G11_n664CobTot ;
      private decimal[] T002G9_A664CobTot ;
      private bool[] T002G9_n664CobTot ;
      private string[] T002G4_A657CobMonDsc ;
      private string[] T002G4_A656CobMonAbr ;
      private string[] T002G5_A667CobVendDsc ;
      private int[] T002G6_A169CobBanCod ;
      private bool[] T002G6_n169CobBanCod ;
      private int[] T002G7_A168CobConBCod ;
      private bool[] T002G7_n168CobConBCod ;
      private decimal[] T002G13_A664CobTot ;
      private bool[] T002G13_n664CobTot ;
      private string[] T002G14_A657CobMonDsc ;
      private string[] T002G14_A656CobMonAbr ;
      private string[] T002G15_A667CobVendDsc ;
      private int[] T002G16_A169CobBanCod ;
      private bool[] T002G16_n169CobBanCod ;
      private int[] T002G17_A168CobConBCod ;
      private bool[] T002G17_n168CobConBCod ;
      private string[] T002G18_A166CobTip ;
      private string[] T002G18_A167CobCod ;
      private string[] T002G3_A166CobTip ;
      private string[] T002G3_A167CobCod ;
      private DateTime[] T002G3_A655CobFec ;
      private int[] T002G3_A1927TotalItem ;
      private string[] T002G3_A660CobRegistro ;
      private bool[] T002G3_n660CobRegistro ;
      private decimal[] T002G3_A644CobBanImp ;
      private bool[] T002G3_n644CobBanImp ;
      private short[] T002G3_A643CobAfecta ;
      private string[] T002G3_A661CobSts ;
      private short[] T002G3_A668CobVouAno ;
      private short[] T002G3_A669CobVouMes ;
      private int[] T002G3_A662CobTAsiCod ;
      private string[] T002G3_A670CobVouNum ;
      private string[] T002G3_A665CobUsuCod ;
      private DateTime[] T002G3_A666CobUsuFec ;
      private int[] T002G3_A172CobMon ;
      private int[] T002G3_A171CobVendCod ;
      private int[] T002G3_A169CobBanCod ;
      private bool[] T002G3_n169CobBanCod ;
      private string[] T002G3_A170CobCbCod ;
      private bool[] T002G3_n170CobCbCod ;
      private int[] T002G3_A168CobConBCod ;
      private bool[] T002G3_n168CobConBCod ;
      private string[] T002G19_A166CobTip ;
      private string[] T002G19_A167CobCod ;
      private string[] T002G20_A166CobTip ;
      private string[] T002G20_A167CobCod ;
      private string[] T002G2_A166CobTip ;
      private string[] T002G2_A167CobCod ;
      private DateTime[] T002G2_A655CobFec ;
      private int[] T002G2_A1927TotalItem ;
      private string[] T002G2_A660CobRegistro ;
      private bool[] T002G2_n660CobRegistro ;
      private decimal[] T002G2_A644CobBanImp ;
      private bool[] T002G2_n644CobBanImp ;
      private short[] T002G2_A643CobAfecta ;
      private string[] T002G2_A661CobSts ;
      private short[] T002G2_A668CobVouAno ;
      private short[] T002G2_A669CobVouMes ;
      private int[] T002G2_A662CobTAsiCod ;
      private string[] T002G2_A670CobVouNum ;
      private string[] T002G2_A665CobUsuCod ;
      private DateTime[] T002G2_A666CobUsuFec ;
      private int[] T002G2_A172CobMon ;
      private int[] T002G2_A171CobVendCod ;
      private int[] T002G2_A169CobBanCod ;
      private bool[] T002G2_n169CobBanCod ;
      private string[] T002G2_A170CobCbCod ;
      private bool[] T002G2_n170CobCbCod ;
      private int[] T002G2_A168CobConBCod ;
      private bool[] T002G2_n168CobConBCod ;
      private decimal[] T002G25_A664CobTot ;
      private bool[] T002G25_n664CobTot ;
      private string[] T002G26_A657CobMonDsc ;
      private string[] T002G26_A656CobMonAbr ;
      private string[] T002G27_A667CobVendDsc ;
      private string[] T002G28_A166CobTip ;
      private string[] T002G28_A167CobCod ;
      private int[] T002G28_A173Item ;
      private string[] T002G29_A166CobTip ;
      private string[] T002G29_A167CobCod ;
      private int[] T002G30_A169CobBanCod ;
      private bool[] T002G30_n169CobBanCod ;
      private int[] T002G31_A168CobConBCod ;
      private bool[] T002G31_n168CobConBCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clcobranza__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clcobranza__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002G11;
        prmT002G11 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G9;
        prmT002G9 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G4;
        prmT002G4 = new Object[] {
        new ParDef("@CobMon",GXType.Int32,6,0)
        };
        Object[] prmT002G5;
        prmT002G5 = new Object[] {
        new ParDef("@CobVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002G6;
        prmT002G6 = new Object[] {
        new ParDef("@CobBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobCbCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT002G7;
        prmT002G7 = new Object[] {
        new ParDef("@CobConBCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002G13;
        prmT002G13 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G14;
        prmT002G14 = new Object[] {
        new ParDef("@CobMon",GXType.Int32,6,0)
        };
        Object[] prmT002G15;
        prmT002G15 = new Object[] {
        new ParDef("@CobVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002G16;
        prmT002G16 = new Object[] {
        new ParDef("@CobBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobCbCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT002G17;
        prmT002G17 = new Object[] {
        new ParDef("@CobConBCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002G18;
        prmT002G18 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G3;
        prmT002G3 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G19;
        prmT002G19 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G20;
        prmT002G20 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G2;
        prmT002G2 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G21;
        prmT002G21 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@CobFec",GXType.Date,8,0) ,
        new ParDef("@TotalItem",GXType.Int32,5,0) ,
        new ParDef("@CobRegistro",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CobBanImp",GXType.Decimal,15,2){Nullable=true} ,
        new ParDef("@CobAfecta",GXType.Int16,1,0) ,
        new ParDef("@CobSts",GXType.NChar,1,0) ,
        new ParDef("@CobVouAno",GXType.Int16,4,0) ,
        new ParDef("@CobVouMes",GXType.Int16,2,0) ,
        new ParDef("@CobTAsiCod",GXType.Int32,6,0) ,
        new ParDef("@CobVouNum",GXType.NChar,10,0) ,
        new ParDef("@CobUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CobUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CobMon",GXType.Int32,6,0) ,
        new ParDef("@CobVendCod",GXType.Int32,6,0) ,
        new ParDef("@CobBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobCbCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CobConBCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002G22;
        prmT002G22 = new Object[] {
        new ParDef("@CobFec",GXType.Date,8,0) ,
        new ParDef("@TotalItem",GXType.Int32,5,0) ,
        new ParDef("@CobRegistro",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@CobBanImp",GXType.Decimal,15,2){Nullable=true} ,
        new ParDef("@CobAfecta",GXType.Int16,1,0) ,
        new ParDef("@CobSts",GXType.NChar,1,0) ,
        new ParDef("@CobVouAno",GXType.Int16,4,0) ,
        new ParDef("@CobVouMes",GXType.Int16,2,0) ,
        new ParDef("@CobTAsiCod",GXType.Int32,6,0) ,
        new ParDef("@CobVouNum",GXType.NChar,10,0) ,
        new ParDef("@CobUsuCod",GXType.NChar,10,0) ,
        new ParDef("@CobUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@CobMon",GXType.Int32,6,0) ,
        new ParDef("@CobVendCod",GXType.Int32,6,0) ,
        new ParDef("@CobBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobCbCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CobConBCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G23;
        prmT002G23 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G28;
        prmT002G28 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G29;
        prmT002G29 = new Object[] {
        };
        Object[] prmT002G25;
        prmT002G25 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002G26;
        prmT002G26 = new Object[] {
        new ParDef("@CobMon",GXType.Int32,6,0)
        };
        Object[] prmT002G27;
        prmT002G27 = new Object[] {
        new ParDef("@CobVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002G30;
        prmT002G30 = new Object[] {
        new ParDef("@CobBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobCbCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT002G31;
        prmT002G31 = new Object[] {
        new ParDef("@CobConBCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T002G2", "SELECT [CobTip], [CobCod], [CobFec], [TotalItem], [CobRegistro], [CobBanImp], [CobAfecta], [CobSts], [CobVouAno], [CobVouMes], [CobTAsiCod], [CobVouNum], [CobUsuCod], [CobUsuFec], [CobMon] AS CobMon, [CobVendCod] AS CobVendCod, [CobBanCod] AS CobBanCod, [CobCbCod] AS CobCbCod, [CobConBCod] AS CobConBCod FROM [CLCOBRANZA] WITH (UPDLOCK) WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G3", "SELECT [CobTip], [CobCod], [CobFec], [TotalItem], [CobRegistro], [CobBanImp], [CobAfecta], [CobSts], [CobVouAno], [CobVouMes], [CobTAsiCod], [CobVouNum], [CobUsuCod], [CobUsuFec], [CobMon] AS CobMon, [CobVendCod] AS CobVendCod, [CobBanCod] AS CobBanCod, [CobCbCod] AS CobCbCod, [CobConBCod] AS CobConBCod FROM [CLCOBRANZA] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G4", "SELECT [MonDsc] AS CobMonDsc, [MonAbr] AS CobMonAbr FROM [CMONEDAS] WHERE [MonCod] = @CobMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G5", "SELECT [VenDsc] AS CobVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @CobVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G6", "SELECT [BanCod] AS CobBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @CobBanCod AND [CBCod] = @CobCbCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G7", "SELECT [ConBCod] AS CobConBCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @CobConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G9", "SELECT COALESCE( T1.[CobTot], 0) AS CobTot FROM (SELECT SUM([CobDTot]) AS CobTot, [CobTip], [CobCod] FROM [CLCOBRANZADET] GROUP BY [CobTip], [CobCod] ) T1 WHERE T1.[CobTip] = @CobTip AND T1.[CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G11", "SELECT TM1.[CobTip], TM1.[CobCod], TM1.[CobFec], T3.[MonDsc] AS CobMonDsc, T3.[MonAbr] AS CobMonAbr, T4.[VenDsc] AS CobVendDsc, TM1.[TotalItem], TM1.[CobRegistro], TM1.[CobBanImp], TM1.[CobAfecta], TM1.[CobSts], TM1.[CobVouAno], TM1.[CobVouMes], TM1.[CobTAsiCod], TM1.[CobVouNum], TM1.[CobUsuCod], TM1.[CobUsuFec], TM1.[CobMon] AS CobMon, TM1.[CobVendCod] AS CobVendCod, TM1.[CobBanCod] AS CobBanCod, TM1.[CobCbCod] AS CobCbCod, TM1.[CobConBCod] AS CobConBCod, COALESCE( T2.[CobTot], 0) AS CobTot FROM ((([CLCOBRANZA] TM1 LEFT JOIN (SELECT SUM([CobDTot]) AS CobTot, [CobTip], [CobCod] FROM [CLCOBRANZADET] GROUP BY [CobTip], [CobCod] ) T2 ON T2.[CobTip] = TM1.[CobTip] AND T2.[CobCod] = TM1.[CobCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = TM1.[CobMon]) INNER JOIN [CVENDEDORES] T4 ON T4.[VenCod] = TM1.[CobVendCod]) WHERE TM1.[CobTip] = @CobTip and TM1.[CobCod] = @CobCod ORDER BY TM1.[CobTip], TM1.[CobCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G11,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G13", "SELECT COALESCE( T1.[CobTot], 0) AS CobTot FROM (SELECT SUM([CobDTot]) AS CobTot, [CobTip], [CobCod] FROM [CLCOBRANZADET] GROUP BY [CobTip], [CobCod] ) T1 WHERE T1.[CobTip] = @CobTip AND T1.[CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G14", "SELECT [MonDsc] AS CobMonDsc, [MonAbr] AS CobMonAbr FROM [CMONEDAS] WHERE [MonCod] = @CobMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G15", "SELECT [VenDsc] AS CobVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @CobVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G16", "SELECT [BanCod] AS CobBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @CobBanCod AND [CBCod] = @CobCbCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G17", "SELECT [ConBCod] AS CobConBCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @CobConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G18", "SELECT [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G19", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE ( [CobTip] > @CobTip or [CobTip] = @CobTip and [CobCod] > @CobCod) ORDER BY [CobTip], [CobCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G20", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE ( [CobTip] < @CobTip or [CobTip] = @CobTip and [CobCod] < @CobCod) ORDER BY [CobTip] DESC, [CobCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G21", "INSERT INTO [CLCOBRANZA]([CobTip], [CobCod], [CobFec], [TotalItem], [CobRegistro], [CobBanImp], [CobAfecta], [CobSts], [CobVouAno], [CobVouMes], [CobTAsiCod], [CobVouNum], [CobUsuCod], [CobUsuFec], [CobMon], [CobVendCod], [CobBanCod], [CobCbCod], [CobConBCod]) VALUES(@CobTip, @CobCod, @CobFec, @TotalItem, @CobRegistro, @CobBanImp, @CobAfecta, @CobSts, @CobVouAno, @CobVouMes, @CobTAsiCod, @CobVouNum, @CobUsuCod, @CobUsuFec, @CobMon, @CobVendCod, @CobBanCod, @CobCbCod, @CobConBCod)", GxErrorMask.GX_NOMASK,prmT002G21)
           ,new CursorDef("T002G22", "UPDATE [CLCOBRANZA] SET [CobFec]=@CobFec, [TotalItem]=@TotalItem, [CobRegistro]=@CobRegistro, [CobBanImp]=@CobBanImp, [CobAfecta]=@CobAfecta, [CobSts]=@CobSts, [CobVouAno]=@CobVouAno, [CobVouMes]=@CobVouMes, [CobTAsiCod]=@CobTAsiCod, [CobVouNum]=@CobVouNum, [CobUsuCod]=@CobUsuCod, [CobUsuFec]=@CobUsuFec, [CobMon]=@CobMon, [CobVendCod]=@CobVendCod, [CobBanCod]=@CobBanCod, [CobCbCod]=@CobCbCod, [CobConBCod]=@CobConBCod  WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod", GxErrorMask.GX_NOMASK,prmT002G22)
           ,new CursorDef("T002G23", "DELETE FROM [CLCOBRANZA]  WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod", GxErrorMask.GX_NOMASK,prmT002G23)
           ,new CursorDef("T002G25", "SELECT COALESCE( T1.[CobTot], 0) AS CobTot FROM (SELECT SUM([CobDTot]) AS CobTot, [CobTip], [CobCod] FROM [CLCOBRANZADET] GROUP BY [CobTip], [CobCod] ) T1 WHERE T1.[CobTip] = @CobTip AND T1.[CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G26", "SELECT [MonDsc] AS CobMonDsc, [MonAbr] AS CobMonAbr FROM [CMONEDAS] WHERE [MonCod] = @CobMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G27", "SELECT [VenDsc] AS CobVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @CobVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G28", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G29", "SELECT [CobTip], [CobCod] FROM [CLCOBRANZA] ORDER BY [CobTip], [CobCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G29,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G30", "SELECT [BanCod] AS CobBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @CobBanCod AND [CBCod] = @CobCbCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G31", "SELECT [ConBCod] AS CobConBCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @CobConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G31,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((short[]) buf[10])[0] = rslt.getShort(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((int[]) buf[12])[0] = rslt.getInt(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 10);
              ((string[]) buf[14])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
              ((int[]) buf[16])[0] = rslt.getInt(15);
              ((int[]) buf[17])[0] = rslt.getInt(16);
              ((int[]) buf[18])[0] = rslt.getInt(17);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((string[]) buf[20])[0] = rslt.getString(18, 20);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              ((int[]) buf[22])[0] = rslt.getInt(19);
              ((bool[]) buf[23])[0] = rslt.wasNull(19);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((short[]) buf[8])[0] = rslt.getShort(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 1);
              ((short[]) buf[10])[0] = rslt.getShort(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((int[]) buf[12])[0] = rslt.getInt(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 10);
              ((string[]) buf[14])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
              ((int[]) buf[16])[0] = rslt.getInt(15);
              ((int[]) buf[17])[0] = rslt.getInt(16);
              ((int[]) buf[18])[0] = rslt.getInt(17);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((string[]) buf[20])[0] = rslt.getString(18, 20);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              ((int[]) buf[22])[0] = rslt.getInt(19);
              ((bool[]) buf[23])[0] = rslt.wasNull(19);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 1);
              ((short[]) buf[13])[0] = rslt.getShort(12);
              ((short[]) buf[14])[0] = rslt.getShort(13);
              ((int[]) buf[15])[0] = rslt.getInt(14);
              ((string[]) buf[16])[0] = rslt.getString(15, 10);
              ((string[]) buf[17])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(17);
              ((int[]) buf[19])[0] = rslt.getInt(18);
              ((int[]) buf[20])[0] = rslt.getInt(19);
              ((int[]) buf[21])[0] = rslt.getInt(20);
              ((bool[]) buf[22])[0] = rslt.wasNull(20);
              ((string[]) buf[23])[0] = rslt.getString(21, 20);
              ((bool[]) buf[24])[0] = rslt.wasNull(21);
              ((int[]) buf[25])[0] = rslt.getInt(22);
              ((bool[]) buf[26])[0] = rslt.wasNull(22);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(23);
              ((bool[]) buf[28])[0] = rslt.wasNull(23);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 19 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
