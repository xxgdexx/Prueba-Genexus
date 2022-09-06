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
   public class clcobranzadet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
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
            gxLoad_3( A166CobTip, A167CobCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A175CobTipCod = GetPar( "CobTipCod");
            AssignAttri("", false, "A175CobTipCod", A175CobTipCod);
            A176CobDocNum = GetPar( "CobDocNum");
            AssignAttri("", false, "A176CobDocNum", A176CobDocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A175CobTipCod, A176CobDocNum) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A143ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A143ForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A174CobDBanCod = (int)(NumberUtil.Val( GetPar( "CobDBanCod"), "."));
            n174CobDBanCod = false;
            AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrimStr( (decimal)(A174CobDBanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A174CobDBanCod) ;
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
            Form.Meta.addItem("description", "Cobranza - Detalle", 0) ;
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

      public clcobranzadet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clcobranzadet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCOBRANZADET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo Cobranza", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobTip_Internalname, StringUtil.RTrim( A166CobTip), StringUtil.RTrim( context.localUtil.Format( A166CobTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Cobranza", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobCod_Internalname, StringUtil.RTrim( A167CobCod), StringUtil.RTrim( context.localUtil.Format( A167CobCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobCod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A173Item), 5, 0, ".", "")), StringUtil.LTrim( ((edtItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A173Item), "ZZZZ9") : context.localUtil.Format( (decimal)(A173Item), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtItem_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "R.U.C.", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobCliCod_Internalname, StringUtil.RTrim( A645CobCliCod), StringUtil.RTrim( context.localUtil.Format( A645CobCliCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Cliente", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobCliDsc_Internalname, StringUtil.RTrim( A646CobCliDsc), StringUtil.RTrim( context.localUtil.Format( A646CobCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo T. Documento", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobTipCod_Internalname, StringUtil.RTrim( A175CobTipCod), StringUtil.RTrim( context.localUtil.Format( A175CobTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Numero Doc.", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobDocNum_Internalname, StringUtil.RTrim( A176CobDocNum), StringUtil.RTrim( context.localUtil.Format( A176CobDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Moneda Origen", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobMonOrigen_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A658CobMonOrigen), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobMonOrigen_Enabled!=0) ? context.localUtil.Format( (decimal)(A658CobMonOrigen), "ZZZZZ9") : context.localUtil.Format( (decimal)(A658CobMonOrigen), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobMonOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobMonOrigen_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Codigo forma pago", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Referencia", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobRef_Internalname, StringUtil.RTrim( A659CobRef), StringUtil.RTrim( context.localUtil.Format( A659CobRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobRef_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Tipo de Cambio", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobTipCam_Internalname, StringUtil.LTrim( StringUtil.NToC( A663CobTipCam, 15, 5, ".", "")), StringUtil.LTrim( ((edtCobTipCam_Enabled!=0) ? context.localUtil.Format( A663CobTipCam, "ZZZZZZZZ9.99999") : context.localUtil.Format( A663CobTipCam, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobTipCam_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobTipCam_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Importe Cobrado", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A654CobDTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtCobDTot_Enabled!=0) ? context.localUtil.Format( A654CobDTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A654CobDTot, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobDTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Canje Letra", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobDCanje_Internalname, StringUtil.RTrim( A647CobDCanje), StringUtil.RTrim( context.localUtil.Format( A647CobDCanje, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobDCanje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobDCanje_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Afecta Bancos", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCobAfecta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A643CobAfecta), 1, 0, ".", "")), StringUtil.LTrim( ((edtCobAfecta_Enabled!=0) ? context.localUtil.Format( (decimal)(A643CobAfecta), "9") : context.localUtil.Format( (decimal)(A643CobAfecta), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobAfecta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobAfecta_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "N° Recibo", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobDRecibo_Internalname, StringUtil.RTrim( A649CobDRecibo), StringUtil.RTrim( context.localUtil.Format( A649CobDRecibo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobDRecibo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobDRecibo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Fecha Diferido", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCobDFDif_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCobDFDif_Internalname, context.localUtil.Format(A648CobDFDif, "99/99/99"), context.localUtil.Format( A648CobDFDif, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobDFDif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobDFDif_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         GxWebStd.gx_bitmap( context, edtCobDFDif_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCobDFDif_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Banco Cobranza", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCobDBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A174CobDBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCobDBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A174CobDBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A174CobDBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCobDBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCobDBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCOBRANZADET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCOBRANZADET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLCOBRANZADET.htm");
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
            Z173Item = (int)(context.localUtil.CToN( cgiGet( "Z173Item"), ".", ","));
            Z659CobRef = cgiGet( "Z659CobRef");
            Z663CobTipCam = context.localUtil.CToN( cgiGet( "Z663CobTipCam"), ".", ",");
            Z654CobDTot = context.localUtil.CToN( cgiGet( "Z654CobDTot"), ".", ",");
            Z647CobDCanje = cgiGet( "Z647CobDCanje");
            Z649CobDRecibo = cgiGet( "Z649CobDRecibo");
            Z648CobDFDif = context.localUtil.CToD( cgiGet( "Z648CobDFDif"), 0);
            Z650CobDRef1 = cgiGet( "Z650CobDRef1");
            Z651CobDRef2 = cgiGet( "Z651CobDRef2");
            Z652CobDRef3 = cgiGet( "Z652CobDRef3");
            Z653CobDRef4 = cgiGet( "Z653CobDRef4");
            Z143ForCod = (int)(context.localUtil.CToN( cgiGet( "Z143ForCod"), ".", ","));
            Z175CobTipCod = cgiGet( "Z175CobTipCod");
            Z176CobDocNum = cgiGet( "Z176CobDocNum");
            Z174CobDBanCod = (int)(context.localUtil.CToN( cgiGet( "Z174CobDBanCod"), ".", ","));
            A650CobDRef1 = cgiGet( "Z650CobDRef1");
            A651CobDRef2 = cgiGet( "Z651CobDRef2");
            A652CobDRef3 = cgiGet( "Z652CobDRef3");
            A653CobDRef4 = cgiGet( "Z653CobDRef4");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A650CobDRef1 = cgiGet( "COBDREF1");
            A651CobDRef2 = cgiGet( "COBDREF2");
            A652CobDRef3 = cgiGet( "COBDREF3");
            A653CobDRef4 = cgiGet( "COBDREF4");
            /* Read variables values. */
            A166CobTip = cgiGet( edtCobTip_Internalname);
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = cgiGet( edtCobCod_Internalname);
            AssignAttri("", false, "A167CobCod", A167CobCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtItem_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ITEM");
               AnyError = 1;
               GX_FocusControl = edtItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A173Item = 0;
               AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
            }
            else
            {
               A173Item = (int)(context.localUtil.CToN( cgiGet( edtItem_Internalname), ".", ","));
               AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
            }
            A645CobCliCod = cgiGet( edtCobCliCod_Internalname);
            AssignAttri("", false, "A645CobCliCod", A645CobCliCod);
            A646CobCliDsc = cgiGet( edtCobCliDsc_Internalname);
            AssignAttri("", false, "A646CobCliDsc", A646CobCliDsc);
            A175CobTipCod = cgiGet( edtCobTipCod_Internalname);
            AssignAttri("", false, "A175CobTipCod", A175CobTipCod);
            A176CobDocNum = cgiGet( edtCobDocNum_Internalname);
            AssignAttri("", false, "A176CobDocNum", A176CobDocNum);
            A658CobMonOrigen = (int)(context.localUtil.CToN( cgiGet( edtCobMonOrigen_Internalname), ".", ","));
            AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrimStr( (decimal)(A658CobMonOrigen), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORCOD");
               AnyError = 1;
               GX_FocusControl = edtForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A143ForCod = 0;
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            }
            else
            {
               A143ForCod = (int)(context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ","));
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            }
            A659CobRef = cgiGet( edtCobRef_Internalname);
            AssignAttri("", false, "A659CobRef", A659CobRef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobTipCam_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobTipCam_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBTIPCAM");
               AnyError = 1;
               GX_FocusControl = edtCobTipCam_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A663CobTipCam = 0;
               AssignAttri("", false, "A663CobTipCam", StringUtil.LTrimStr( A663CobTipCam, 15, 5));
            }
            else
            {
               A663CobTipCam = context.localUtil.CToN( cgiGet( edtCobTipCam_Internalname), ".", ",");
               AssignAttri("", false, "A663CobTipCam", StringUtil.LTrimStr( A663CobTipCam, 15, 5));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobDTot_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCobDTot_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBDTOT");
               AnyError = 1;
               GX_FocusControl = edtCobDTot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A654CobDTot = 0;
               AssignAttri("", false, "A654CobDTot", StringUtil.LTrimStr( A654CobDTot, 15, 2));
            }
            else
            {
               A654CobDTot = context.localUtil.CToN( cgiGet( edtCobDTot_Internalname), ".", ",");
               AssignAttri("", false, "A654CobDTot", StringUtil.LTrimStr( A654CobDTot, 15, 2));
            }
            A647CobDCanje = cgiGet( edtCobDCanje_Internalname);
            AssignAttri("", false, "A647CobDCanje", A647CobDCanje);
            A643CobAfecta = (short)(context.localUtil.CToN( cgiGet( edtCobAfecta_Internalname), ".", ","));
            AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            A649CobDRecibo = cgiGet( edtCobDRecibo_Internalname);
            AssignAttri("", false, "A649CobDRecibo", A649CobDRecibo);
            if ( context.localUtil.VCDate( cgiGet( edtCobDFDif_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Diferido"}), 1, "COBDFDIF");
               AnyError = 1;
               GX_FocusControl = edtCobDFDif_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A648CobDFDif = DateTime.MinValue;
               AssignAttri("", false, "A648CobDFDif", context.localUtil.Format(A648CobDFDif, "99/99/99"));
            }
            else
            {
               A648CobDFDif = context.localUtil.CToD( cgiGet( edtCobDFDif_Internalname), 2);
               AssignAttri("", false, "A648CobDFDif", context.localUtil.Format(A648CobDFDif, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCobDBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCobDBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COBDBANCOD");
               AnyError = 1;
               GX_FocusControl = edtCobDBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A174CobDBanCod = 0;
               n174CobDBanCod = false;
               AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrimStr( (decimal)(A174CobDBanCod), 6, 0));
            }
            else
            {
               A174CobDBanCod = (int)(context.localUtil.CToN( cgiGet( edtCobDBanCod_Internalname), ".", ","));
               n174CobDBanCod = false;
               AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrimStr( (decimal)(A174CobDBanCod), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLCOBRANZADET");
            forbiddenHiddens.Add("CobDRef1", StringUtil.RTrim( context.localUtil.Format( A650CobDRef1, "")));
            forbiddenHiddens.Add("CobDRef2", StringUtil.RTrim( context.localUtil.Format( A651CobDRef2, "")));
            forbiddenHiddens.Add("CobDRef3", StringUtil.RTrim( context.localUtil.Format( A652CobDRef3, "")));
            forbiddenHiddens.Add("CobDRef4", StringUtil.RTrim( context.localUtil.Format( A653CobDRef4, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) || ( A173Item != Z173Item ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clcobranzadet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A166CobTip = GetPar( "CobTip");
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = GetPar( "CobCod");
               AssignAttri("", false, "A167CobCod", A167CobCod);
               A173Item = (int)(NumberUtil.Val( GetPar( "Item"), "."));
               AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
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
               InitAll2H85( ) ;
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
         DisableAttributes2H85( ) ;
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

      protected void CONFIRM_2H0( )
      {
         BeforeValidate2H85( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2H85( ) ;
            }
            else
            {
               CheckExtendedTable2H85( ) ;
               if ( AnyError == 0 )
               {
                  ZM2H85( 3) ;
                  ZM2H85( 4) ;
                  ZM2H85( 5) ;
                  ZM2H85( 6) ;
               }
               CloseExtendedTableCursors2H85( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2H0( ) ;
         }
      }

      protected void ResetCaption2H0( )
      {
      }

      protected void ZM2H85( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z659CobRef = T002H3_A659CobRef[0];
               Z663CobTipCam = T002H3_A663CobTipCam[0];
               Z654CobDTot = T002H3_A654CobDTot[0];
               Z647CobDCanje = T002H3_A647CobDCanje[0];
               Z649CobDRecibo = T002H3_A649CobDRecibo[0];
               Z648CobDFDif = T002H3_A648CobDFDif[0];
               Z650CobDRef1 = T002H3_A650CobDRef1[0];
               Z651CobDRef2 = T002H3_A651CobDRef2[0];
               Z652CobDRef3 = T002H3_A652CobDRef3[0];
               Z653CobDRef4 = T002H3_A653CobDRef4[0];
               Z143ForCod = T002H3_A143ForCod[0];
               Z175CobTipCod = T002H3_A175CobTipCod[0];
               Z176CobDocNum = T002H3_A176CobDocNum[0];
               Z174CobDBanCod = T002H3_A174CobDBanCod[0];
            }
            else
            {
               Z659CobRef = A659CobRef;
               Z663CobTipCam = A663CobTipCam;
               Z654CobDTot = A654CobDTot;
               Z647CobDCanje = A647CobDCanje;
               Z649CobDRecibo = A649CobDRecibo;
               Z648CobDFDif = A648CobDFDif;
               Z650CobDRef1 = A650CobDRef1;
               Z651CobDRef2 = A651CobDRef2;
               Z652CobDRef3 = A652CobDRef3;
               Z653CobDRef4 = A653CobDRef4;
               Z143ForCod = A143ForCod;
               Z175CobTipCod = A175CobTipCod;
               Z176CobDocNum = A176CobDocNum;
               Z174CobDBanCod = A174CobDBanCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z173Item = A173Item;
            Z659CobRef = A659CobRef;
            Z663CobTipCam = A663CobTipCam;
            Z654CobDTot = A654CobDTot;
            Z647CobDCanje = A647CobDCanje;
            Z649CobDRecibo = A649CobDRecibo;
            Z648CobDFDif = A648CobDFDif;
            Z650CobDRef1 = A650CobDRef1;
            Z651CobDRef2 = A651CobDRef2;
            Z652CobDRef3 = A652CobDRef3;
            Z653CobDRef4 = A653CobDRef4;
            Z166CobTip = A166CobTip;
            Z167CobCod = A167CobCod;
            Z143ForCod = A143ForCod;
            Z175CobTipCod = A175CobTipCod;
            Z176CobDocNum = A176CobDocNum;
            Z174CobDBanCod = A174CobDBanCod;
            Z643CobAfecta = A643CobAfecta;
            Z646CobCliDsc = A646CobCliDsc;
            Z645CobCliCod = A645CobCliCod;
            Z658CobMonOrigen = A658CobMonOrigen;
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

      protected void Load2H85( )
      {
         /* Using cursor T002H8 */
         pr_default.execute(6, new Object[] {A166CobTip, A167CobCod, A173Item});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound85 = 1;
            A646CobCliDsc = T002H8_A646CobCliDsc[0];
            AssignAttri("", false, "A646CobCliDsc", A646CobCliDsc);
            A659CobRef = T002H8_A659CobRef[0];
            AssignAttri("", false, "A659CobRef", A659CobRef);
            A663CobTipCam = T002H8_A663CobTipCam[0];
            AssignAttri("", false, "A663CobTipCam", StringUtil.LTrimStr( A663CobTipCam, 15, 5));
            A654CobDTot = T002H8_A654CobDTot[0];
            AssignAttri("", false, "A654CobDTot", StringUtil.LTrimStr( A654CobDTot, 15, 2));
            A647CobDCanje = T002H8_A647CobDCanje[0];
            AssignAttri("", false, "A647CobDCanje", A647CobDCanje);
            A643CobAfecta = T002H8_A643CobAfecta[0];
            AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            A649CobDRecibo = T002H8_A649CobDRecibo[0];
            AssignAttri("", false, "A649CobDRecibo", A649CobDRecibo);
            A648CobDFDif = T002H8_A648CobDFDif[0];
            AssignAttri("", false, "A648CobDFDif", context.localUtil.Format(A648CobDFDif, "99/99/99"));
            A650CobDRef1 = T002H8_A650CobDRef1[0];
            A651CobDRef2 = T002H8_A651CobDRef2[0];
            A652CobDRef3 = T002H8_A652CobDRef3[0];
            A653CobDRef4 = T002H8_A653CobDRef4[0];
            A143ForCod = T002H8_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A175CobTipCod = T002H8_A175CobTipCod[0];
            AssignAttri("", false, "A175CobTipCod", A175CobTipCod);
            A176CobDocNum = T002H8_A176CobDocNum[0];
            AssignAttri("", false, "A176CobDocNum", A176CobDocNum);
            A174CobDBanCod = T002H8_A174CobDBanCod[0];
            n174CobDBanCod = T002H8_n174CobDBanCod[0];
            AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrimStr( (decimal)(A174CobDBanCod), 6, 0));
            A645CobCliCod = T002H8_A645CobCliCod[0];
            AssignAttri("", false, "A645CobCliCod", A645CobCliCod);
            A658CobMonOrigen = T002H8_A658CobMonOrigen[0];
            AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrimStr( (decimal)(A658CobMonOrigen), 6, 0));
            ZM2H85( -2) ;
         }
         pr_default.close(6);
         OnLoadActions2H85( ) ;
      }

      protected void OnLoadActions2H85( )
      {
      }

      protected void CheckExtendedTable2H85( )
      {
         nIsDirty_85 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002H4 */
         pr_default.execute(2, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobranza - Cabecera'.", "ForeignKeyNotFound", 1, "COBCOD");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A643CobAfecta = T002H4_A643CobAfecta[0];
         AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
         pr_default.close(2);
         /* Using cursor T002H6 */
         pr_default.execute(4, new Object[] {A175CobTipCod, A176CobDocNum});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Cobranza'.", "ForeignKeyNotFound", 1, "COBDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCobTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A646CobCliDsc = T002H6_A646CobCliDsc[0];
         AssignAttri("", false, "A646CobCliDsc", A646CobCliDsc);
         A645CobCliCod = T002H6_A645CobCliCod[0];
         AssignAttri("", false, "A645CobCliCod", A645CobCliCod);
         A658CobMonOrigen = T002H6_A658CobMonOrigen[0];
         AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrimStr( (decimal)(A658CobMonOrigen), 6, 0));
         pr_default.close(4);
         /* Using cursor T002H5 */
         pr_default.execute(3, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A648CobDFDif) || ( DateTimeUtil.ResetTime ( A648CobDFDif ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Diferido fuera de rango", "OutOfRange", 1, "COBDFDIF");
            AnyError = 1;
            GX_FocusControl = edtCobDFDif_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002H7 */
         pr_default.execute(5, new Object[] {n174CobDBanCod, A174CobDBanCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A174CobDBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "COBDBANCOD");
               AnyError = 1;
               GX_FocusControl = edtCobDBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors2H85( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A166CobTip ,
                               string A167CobCod )
      {
         /* Using cursor T002H9 */
         pr_default.execute(7, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobranza - Cabecera'.", "ForeignKeyNotFound", 1, "COBCOD");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A643CobAfecta = T002H9_A643CobAfecta[0];
         AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A643CobAfecta), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( string A175CobTipCod ,
                               string A176CobDocNum )
      {
         /* Using cursor T002H10 */
         pr_default.execute(8, new Object[] {A175CobTipCod, A176CobDocNum});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Cobranza'.", "ForeignKeyNotFound", 1, "COBDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCobTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A646CobCliDsc = T002H10_A646CobCliDsc[0];
         AssignAttri("", false, "A646CobCliDsc", A646CobCliDsc);
         A645CobCliCod = T002H10_A645CobCliCod[0];
         AssignAttri("", false, "A645CobCliCod", A645CobCliCod);
         A658CobMonOrigen = T002H10_A658CobMonOrigen[0];
         AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrimStr( (decimal)(A658CobMonOrigen), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A646CobCliDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A645CobCliCod))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A658CobMonOrigen), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_4( int A143ForCod )
      {
         /* Using cursor T002H11 */
         pr_default.execute(9, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_6( int A174CobDBanCod )
      {
         /* Using cursor T002H12 */
         pr_default.execute(10, new Object[] {n174CobDBanCod, A174CobDBanCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A174CobDBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "COBDBANCOD");
               AnyError = 1;
               GX_FocusControl = edtCobDBanCod_Internalname;
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

      protected void GetKey2H85( )
      {
         /* Using cursor T002H13 */
         pr_default.execute(11, new Object[] {A166CobTip, A167CobCod, A173Item});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002H3 */
         pr_default.execute(1, new Object[] {A166CobTip, A167CobCod, A173Item});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2H85( 2) ;
            RcdFound85 = 1;
            A173Item = T002H3_A173Item[0];
            AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
            A659CobRef = T002H3_A659CobRef[0];
            AssignAttri("", false, "A659CobRef", A659CobRef);
            A663CobTipCam = T002H3_A663CobTipCam[0];
            AssignAttri("", false, "A663CobTipCam", StringUtil.LTrimStr( A663CobTipCam, 15, 5));
            A654CobDTot = T002H3_A654CobDTot[0];
            AssignAttri("", false, "A654CobDTot", StringUtil.LTrimStr( A654CobDTot, 15, 2));
            A647CobDCanje = T002H3_A647CobDCanje[0];
            AssignAttri("", false, "A647CobDCanje", A647CobDCanje);
            A649CobDRecibo = T002H3_A649CobDRecibo[0];
            AssignAttri("", false, "A649CobDRecibo", A649CobDRecibo);
            A648CobDFDif = T002H3_A648CobDFDif[0];
            AssignAttri("", false, "A648CobDFDif", context.localUtil.Format(A648CobDFDif, "99/99/99"));
            A650CobDRef1 = T002H3_A650CobDRef1[0];
            A651CobDRef2 = T002H3_A651CobDRef2[0];
            A652CobDRef3 = T002H3_A652CobDRef3[0];
            A653CobDRef4 = T002H3_A653CobDRef4[0];
            A166CobTip = T002H3_A166CobTip[0];
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = T002H3_A167CobCod[0];
            AssignAttri("", false, "A167CobCod", A167CobCod);
            A143ForCod = T002H3_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A175CobTipCod = T002H3_A175CobTipCod[0];
            AssignAttri("", false, "A175CobTipCod", A175CobTipCod);
            A176CobDocNum = T002H3_A176CobDocNum[0];
            AssignAttri("", false, "A176CobDocNum", A176CobDocNum);
            A174CobDBanCod = T002H3_A174CobDBanCod[0];
            n174CobDBanCod = T002H3_n174CobDBanCod[0];
            AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrimStr( (decimal)(A174CobDBanCod), 6, 0));
            Z166CobTip = A166CobTip;
            Z167CobCod = A167CobCod;
            Z173Item = A173Item;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2H85( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey2H85( ) ;
            }
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey2H85( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode85;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2H85( ) ;
         if ( RcdFound85 == 0 )
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
         RcdFound85 = 0;
         /* Using cursor T002H14 */
         pr_default.execute(12, new Object[] {A166CobTip, A167CobCod, A173Item});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T002H14_A166CobTip[0], A166CobTip) < 0 ) || ( StringUtil.StrCmp(T002H14_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002H14_A167CobCod[0], A167CobCod) < 0 ) || ( StringUtil.StrCmp(T002H14_A167CobCod[0], A167CobCod) == 0 ) && ( StringUtil.StrCmp(T002H14_A166CobTip[0], A166CobTip) == 0 ) && ( T002H14_A173Item[0] < A173Item ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T002H14_A166CobTip[0], A166CobTip) > 0 ) || ( StringUtil.StrCmp(T002H14_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002H14_A167CobCod[0], A167CobCod) > 0 ) || ( StringUtil.StrCmp(T002H14_A167CobCod[0], A167CobCod) == 0 ) && ( StringUtil.StrCmp(T002H14_A166CobTip[0], A166CobTip) == 0 ) && ( T002H14_A173Item[0] > A173Item ) ) )
            {
               A166CobTip = T002H14_A166CobTip[0];
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = T002H14_A167CobCod[0];
               AssignAttri("", false, "A167CobCod", A167CobCod);
               A173Item = T002H14_A173Item[0];
               AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
               RcdFound85 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound85 = 0;
         /* Using cursor T002H15 */
         pr_default.execute(13, new Object[] {A166CobTip, A167CobCod, A173Item});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002H15_A166CobTip[0], A166CobTip) > 0 ) || ( StringUtil.StrCmp(T002H15_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002H15_A167CobCod[0], A167CobCod) > 0 ) || ( StringUtil.StrCmp(T002H15_A167CobCod[0], A167CobCod) == 0 ) && ( StringUtil.StrCmp(T002H15_A166CobTip[0], A166CobTip) == 0 ) && ( T002H15_A173Item[0] > A173Item ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002H15_A166CobTip[0], A166CobTip) < 0 ) || ( StringUtil.StrCmp(T002H15_A166CobTip[0], A166CobTip) == 0 ) && ( StringUtil.StrCmp(T002H15_A167CobCod[0], A167CobCod) < 0 ) || ( StringUtil.StrCmp(T002H15_A167CobCod[0], A167CobCod) == 0 ) && ( StringUtil.StrCmp(T002H15_A166CobTip[0], A166CobTip) == 0 ) && ( T002H15_A173Item[0] < A173Item ) ) )
            {
               A166CobTip = T002H15_A166CobTip[0];
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = T002H15_A167CobCod[0];
               AssignAttri("", false, "A167CobCod", A167CobCod);
               A173Item = T002H15_A173Item[0];
               AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
               RcdFound85 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2H85( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2H85( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) || ( A173Item != Z173Item ) )
               {
                  A166CobTip = Z166CobTip;
                  AssignAttri("", false, "A166CobTip", A166CobTip);
                  A167CobCod = Z167CobCod;
                  AssignAttri("", false, "A167CobCod", A167CobCod);
                  A173Item = Z173Item;
                  AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
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
                  Update2H85( ) ;
                  GX_FocusControl = edtCobTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) || ( A173Item != Z173Item ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCobTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2H85( ) ;
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
                     Insert2H85( ) ;
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
         if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) || ( A173Item != Z173Item ) )
         {
            A166CobTip = Z166CobTip;
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = Z167CobCod;
            AssignAttri("", false, "A167CobCod", A167CobCod);
            A173Item = Z173Item;
            AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
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
         GetKey2H85( ) ;
         if ( RcdFound85 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "COBTIP");
               AnyError = 1;
               GX_FocusControl = edtCobTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) || ( A173Item != Z173Item ) )
            {
               A166CobTip = Z166CobTip;
               AssignAttri("", false, "A166CobTip", A166CobTip);
               A167CobCod = Z167CobCod;
               AssignAttri("", false, "A167CobCod", A167CobCod);
               A173Item = Z173Item;
               AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
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
            if ( ( StringUtil.StrCmp(A166CobTip, Z166CobTip) != 0 ) || ( StringUtil.StrCmp(A167CobCod, Z167CobCod) != 0 ) || ( A173Item != Z173Item ) )
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
         context.RollbackDataStores("clcobranzadet",pr_default);
         GX_FocusControl = edtCobTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2H0( ) ;
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
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "COBTIP");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCobTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2H85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2H85( ) ;
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
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobTipCod_Internalname;
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
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobTipCod_Internalname;
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
         ScanStart2H85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound85 != 0 )
            {
               ScanNext2H85( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCobTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2H85( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2H85( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002H2 */
            pr_default.execute(0, new Object[] {A166CobTip, A167CobCod, A173Item});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOBRANZADET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z659CobRef, T002H2_A659CobRef[0]) != 0 ) || ( Z663CobTipCam != T002H2_A663CobTipCam[0] ) || ( Z654CobDTot != T002H2_A654CobDTot[0] ) || ( StringUtil.StrCmp(Z647CobDCanje, T002H2_A647CobDCanje[0]) != 0 ) || ( StringUtil.StrCmp(Z649CobDRecibo, T002H2_A649CobDRecibo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z648CobDFDif ) != DateTimeUtil.ResetTime ( T002H2_A648CobDFDif[0] ) ) || ( StringUtil.StrCmp(Z650CobDRef1, T002H2_A650CobDRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z651CobDRef2, T002H2_A651CobDRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z652CobDRef3, T002H2_A652CobDRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z653CobDRef4, T002H2_A653CobDRef4[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z143ForCod != T002H2_A143ForCod[0] ) || ( StringUtil.StrCmp(Z175CobTipCod, T002H2_A175CobTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z176CobDocNum, T002H2_A176CobDocNum[0]) != 0 ) || ( Z174CobDBanCod != T002H2_A174CobDBanCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z659CobRef, T002H2_A659CobRef[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobRef");
                  GXUtil.WriteLogRaw("Old: ",Z659CobRef);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A659CobRef[0]);
               }
               if ( Z663CobTipCam != T002H2_A663CobTipCam[0] )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobTipCam");
                  GXUtil.WriteLogRaw("Old: ",Z663CobTipCam);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A663CobTipCam[0]);
               }
               if ( Z654CobDTot != T002H2_A654CobDTot[0] )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDTot");
                  GXUtil.WriteLogRaw("Old: ",Z654CobDTot);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A654CobDTot[0]);
               }
               if ( StringUtil.StrCmp(Z647CobDCanje, T002H2_A647CobDCanje[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDCanje");
                  GXUtil.WriteLogRaw("Old: ",Z647CobDCanje);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A647CobDCanje[0]);
               }
               if ( StringUtil.StrCmp(Z649CobDRecibo, T002H2_A649CobDRecibo[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDRecibo");
                  GXUtil.WriteLogRaw("Old: ",Z649CobDRecibo);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A649CobDRecibo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z648CobDFDif ) != DateTimeUtil.ResetTime ( T002H2_A648CobDFDif[0] ) )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDFDif");
                  GXUtil.WriteLogRaw("Old: ",Z648CobDFDif);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A648CobDFDif[0]);
               }
               if ( StringUtil.StrCmp(Z650CobDRef1, T002H2_A650CobDRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDRef1");
                  GXUtil.WriteLogRaw("Old: ",Z650CobDRef1);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A650CobDRef1[0]);
               }
               if ( StringUtil.StrCmp(Z651CobDRef2, T002H2_A651CobDRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDRef2");
                  GXUtil.WriteLogRaw("Old: ",Z651CobDRef2);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A651CobDRef2[0]);
               }
               if ( StringUtil.StrCmp(Z652CobDRef3, T002H2_A652CobDRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDRef3");
                  GXUtil.WriteLogRaw("Old: ",Z652CobDRef3);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A652CobDRef3[0]);
               }
               if ( StringUtil.StrCmp(Z653CobDRef4, T002H2_A653CobDRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDRef4");
                  GXUtil.WriteLogRaw("Old: ",Z653CobDRef4);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A653CobDRef4[0]);
               }
               if ( Z143ForCod != T002H2_A143ForCod[0] )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"ForCod");
                  GXUtil.WriteLogRaw("Old: ",Z143ForCod);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A143ForCod[0]);
               }
               if ( StringUtil.StrCmp(Z175CobTipCod, T002H2_A175CobTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z175CobTipCod);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A175CobTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z176CobDocNum, T002H2_A176CobDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z176CobDocNum);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A176CobDocNum[0]);
               }
               if ( Z174CobDBanCod != T002H2_A174CobDBanCod[0] )
               {
                  GXUtil.WriteLog("clcobranzadet:[seudo value changed for attri]"+"CobDBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z174CobDBanCod);
                  GXUtil.WriteLogRaw("Current: ",T002H2_A174CobDBanCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCOBRANZADET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2H85( )
      {
         BeforeValidate2H85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2H85( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2H85( 0) ;
            CheckOptimisticConcurrency2H85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2H85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2H85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002H16 */
                     pr_default.execute(14, new Object[] {A173Item, A659CobRef, A663CobTipCam, A654CobDTot, A647CobDCanje, A649CobDRecibo, A648CobDFDif, A650CobDRef1, A651CobDRef2, A652CobDRef3, A653CobDRef4, A166CobTip, A167CobCod, A143ForCod, A175CobTipCod, A176CobDocNum, n174CobDBanCod, A174CobDBanCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOBRANZADET");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption2H0( ) ;
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
               Load2H85( ) ;
            }
            EndLevel2H85( ) ;
         }
         CloseExtendedTableCursors2H85( ) ;
      }

      protected void Update2H85( )
      {
         BeforeValidate2H85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2H85( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2H85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2H85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2H85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002H17 */
                     pr_default.execute(15, new Object[] {A659CobRef, A663CobTipCam, A654CobDTot, A647CobDCanje, A649CobDRecibo, A648CobDFDif, A650CobDRef1, A651CobDRef2, A652CobDRef3, A653CobDRef4, A143ForCod, A175CobTipCod, A176CobDocNum, n174CobDBanCod, A174CobDBanCod, A166CobTip, A167CobCod, A173Item});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCOBRANZADET");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCOBRANZADET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2H85( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2H0( ) ;
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
            EndLevel2H85( ) ;
         }
         CloseExtendedTableCursors2H85( ) ;
      }

      protected void DeferredUpdate2H85( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2H85( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2H85( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2H85( ) ;
            AfterConfirm2H85( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2H85( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002H18 */
                  pr_default.execute(16, new Object[] {A166CobTip, A167CobCod, A173Item});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCOBRANZADET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound85 == 0 )
                        {
                           InitAll2H85( ) ;
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
                        ResetCaption2H0( ) ;
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2H85( ) ;
         Gx_mode = sMode85;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2H85( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002H19 */
            pr_default.execute(17, new Object[] {A166CobTip, A167CobCod});
            A643CobAfecta = T002H19_A643CobAfecta[0];
            AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
            pr_default.close(17);
            /* Using cursor T002H20 */
            pr_default.execute(18, new Object[] {A175CobTipCod, A176CobDocNum});
            A646CobCliDsc = T002H20_A646CobCliDsc[0];
            AssignAttri("", false, "A646CobCliDsc", A646CobCliDsc);
            A645CobCliCod = T002H20_A645CobCliCod[0];
            AssignAttri("", false, "A645CobCliCod", A645CobCliCod);
            A658CobMonOrigen = T002H20_A658CobMonOrigen[0];
            AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrimStr( (decimal)(A658CobMonOrigen), 6, 0));
            pr_default.close(18);
         }
      }

      protected void EndLevel2H85( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2H85( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            context.CommitDataStores("clcobranzadet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            context.RollbackDataStores("clcobranzadet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2H85( )
      {
         /* Using cursor T002H21 */
         pr_default.execute(19);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound85 = 1;
            A166CobTip = T002H21_A166CobTip[0];
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = T002H21_A167CobCod[0];
            AssignAttri("", false, "A167CobCod", A167CobCod);
            A173Item = T002H21_A173Item[0];
            AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2H85( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound85 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound85 = 1;
            A166CobTip = T002H21_A166CobTip[0];
            AssignAttri("", false, "A166CobTip", A166CobTip);
            A167CobCod = T002H21_A167CobCod[0];
            AssignAttri("", false, "A167CobCod", A167CobCod);
            A173Item = T002H21_A173Item[0];
            AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
         }
      }

      protected void ScanEnd2H85( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm2H85( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2H85( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2H85( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2H85( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2H85( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2H85( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2H85( )
      {
         edtCobTip_Enabled = 0;
         AssignProp("", false, edtCobTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobTip_Enabled), 5, 0), true);
         edtCobCod_Enabled = 0;
         AssignProp("", false, edtCobCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobCod_Enabled), 5, 0), true);
         edtItem_Enabled = 0;
         AssignProp("", false, edtItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtItem_Enabled), 5, 0), true);
         edtCobCliCod_Enabled = 0;
         AssignProp("", false, edtCobCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobCliCod_Enabled), 5, 0), true);
         edtCobCliDsc_Enabled = 0;
         AssignProp("", false, edtCobCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobCliDsc_Enabled), 5, 0), true);
         edtCobTipCod_Enabled = 0;
         AssignProp("", false, edtCobTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobTipCod_Enabled), 5, 0), true);
         edtCobDocNum_Enabled = 0;
         AssignProp("", false, edtCobDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobDocNum_Enabled), 5, 0), true);
         edtCobMonOrigen_Enabled = 0;
         AssignProp("", false, edtCobMonOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobMonOrigen_Enabled), 5, 0), true);
         edtForCod_Enabled = 0;
         AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         edtCobRef_Enabled = 0;
         AssignProp("", false, edtCobRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobRef_Enabled), 5, 0), true);
         edtCobTipCam_Enabled = 0;
         AssignProp("", false, edtCobTipCam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobTipCam_Enabled), 5, 0), true);
         edtCobDTot_Enabled = 0;
         AssignProp("", false, edtCobDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobDTot_Enabled), 5, 0), true);
         edtCobDCanje_Enabled = 0;
         AssignProp("", false, edtCobDCanje_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobDCanje_Enabled), 5, 0), true);
         edtCobAfecta_Enabled = 0;
         AssignProp("", false, edtCobAfecta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobAfecta_Enabled), 5, 0), true);
         edtCobDRecibo_Enabled = 0;
         AssignProp("", false, edtCobDRecibo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobDRecibo_Enabled), 5, 0), true);
         edtCobDFDif_Enabled = 0;
         AssignProp("", false, edtCobDFDif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobDFDif_Enabled), 5, 0), true);
         edtCobDBanCod_Enabled = 0;
         AssignProp("", false, edtCobDBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCobDBanCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2H85( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2H0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816424127", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clcobranzadet.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLCOBRANZADET");
         forbiddenHiddens.Add("CobDRef1", StringUtil.RTrim( context.localUtil.Format( A650CobDRef1, "")));
         forbiddenHiddens.Add("CobDRef2", StringUtil.RTrim( context.localUtil.Format( A651CobDRef2, "")));
         forbiddenHiddens.Add("CobDRef3", StringUtil.RTrim( context.localUtil.Format( A652CobDRef3, "")));
         forbiddenHiddens.Add("CobDRef4", StringUtil.RTrim( context.localUtil.Format( A653CobDRef4, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clcobranzadet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z166CobTip", StringUtil.RTrim( Z166CobTip));
         GxWebStd.gx_hidden_field( context, "Z167CobCod", StringUtil.RTrim( Z167CobCod));
         GxWebStd.gx_hidden_field( context, "Z173Item", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z173Item), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z659CobRef", StringUtil.RTrim( Z659CobRef));
         GxWebStd.gx_hidden_field( context, "Z663CobTipCam", StringUtil.LTrim( StringUtil.NToC( Z663CobTipCam, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z654CobDTot", StringUtil.LTrim( StringUtil.NToC( Z654CobDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z647CobDCanje", StringUtil.RTrim( Z647CobDCanje));
         GxWebStd.gx_hidden_field( context, "Z649CobDRecibo", StringUtil.RTrim( Z649CobDRecibo));
         GxWebStd.gx_hidden_field( context, "Z648CobDFDif", context.localUtil.DToC( Z648CobDFDif, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z650CobDRef1", Z650CobDRef1);
         GxWebStd.gx_hidden_field( context, "Z651CobDRef2", Z651CobDRef2);
         GxWebStd.gx_hidden_field( context, "Z652CobDRef3", Z652CobDRef3);
         GxWebStd.gx_hidden_field( context, "Z653CobDRef4", Z653CobDRef4);
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z175CobTipCod", StringUtil.RTrim( Z175CobTipCod));
         GxWebStd.gx_hidden_field( context, "Z176CobDocNum", StringUtil.RTrim( Z176CobDocNum));
         GxWebStd.gx_hidden_field( context, "Z174CobDBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z174CobDBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "COBDREF1", A650CobDRef1);
         GxWebStd.gx_hidden_field( context, "COBDREF2", A651CobDRef2);
         GxWebStd.gx_hidden_field( context, "COBDREF3", A652CobDRef3);
         GxWebStd.gx_hidden_field( context, "COBDREF4", A653CobDRef4);
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
         return formatLink("clcobranzadet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCOBRANZADET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cobranza - Detalle" ;
      }

      protected void InitializeNonKey2H85( )
      {
         A645CobCliCod = "";
         AssignAttri("", false, "A645CobCliCod", A645CobCliCod);
         A646CobCliDsc = "";
         AssignAttri("", false, "A646CobCliDsc", A646CobCliDsc);
         A175CobTipCod = "";
         AssignAttri("", false, "A175CobTipCod", A175CobTipCod);
         A176CobDocNum = "";
         AssignAttri("", false, "A176CobDocNum", A176CobDocNum);
         A658CobMonOrigen = 0;
         AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrimStr( (decimal)(A658CobMonOrigen), 6, 0));
         A143ForCod = 0;
         AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         A659CobRef = "";
         AssignAttri("", false, "A659CobRef", A659CobRef);
         A663CobTipCam = 0;
         AssignAttri("", false, "A663CobTipCam", StringUtil.LTrimStr( A663CobTipCam, 15, 5));
         A654CobDTot = 0;
         AssignAttri("", false, "A654CobDTot", StringUtil.LTrimStr( A654CobDTot, 15, 2));
         A647CobDCanje = "";
         AssignAttri("", false, "A647CobDCanje", A647CobDCanje);
         A643CobAfecta = 0;
         AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
         A649CobDRecibo = "";
         AssignAttri("", false, "A649CobDRecibo", A649CobDRecibo);
         A648CobDFDif = DateTime.MinValue;
         AssignAttri("", false, "A648CobDFDif", context.localUtil.Format(A648CobDFDif, "99/99/99"));
         A174CobDBanCod = 0;
         n174CobDBanCod = false;
         AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrimStr( (decimal)(A174CobDBanCod), 6, 0));
         A650CobDRef1 = "";
         AssignAttri("", false, "A650CobDRef1", A650CobDRef1);
         A651CobDRef2 = "";
         AssignAttri("", false, "A651CobDRef2", A651CobDRef2);
         A652CobDRef3 = "";
         AssignAttri("", false, "A652CobDRef3", A652CobDRef3);
         A653CobDRef4 = "";
         AssignAttri("", false, "A653CobDRef4", A653CobDRef4);
         Z659CobRef = "";
         Z663CobTipCam = 0;
         Z654CobDTot = 0;
         Z647CobDCanje = "";
         Z649CobDRecibo = "";
         Z648CobDFDif = DateTime.MinValue;
         Z650CobDRef1 = "";
         Z651CobDRef2 = "";
         Z652CobDRef3 = "";
         Z653CobDRef4 = "";
         Z143ForCod = 0;
         Z175CobTipCod = "";
         Z176CobDocNum = "";
         Z174CobDBanCod = 0;
      }

      protected void InitAll2H85( )
      {
         A166CobTip = "";
         AssignAttri("", false, "A166CobTip", A166CobTip);
         A167CobCod = "";
         AssignAttri("", false, "A167CobCod", A167CobCod);
         A173Item = 0;
         AssignAttri("", false, "A173Item", StringUtil.LTrimStr( (decimal)(A173Item), 5, 0));
         InitializeNonKey2H85( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816424146", true, true);
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
         context.AddJavascriptSource("clcobranzadet.js", "?202281816424146", false, true);
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
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtItem_Internalname = "ITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCobCliCod_Internalname = "COBCLICOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCobCliDsc_Internalname = "COBCLIDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCobTipCod_Internalname = "COBTIPCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCobDocNum_Internalname = "COBDOCNUM";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCobMonOrigen_Internalname = "COBMONORIGEN";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtForCod_Internalname = "FORCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCobRef_Internalname = "COBREF";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCobTipCam_Internalname = "COBTIPCAM";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtCobDTot_Internalname = "COBDTOT";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtCobDCanje_Internalname = "COBDCANJE";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtCobAfecta_Internalname = "COBAFECTA";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtCobDRecibo_Internalname = "COBDRECIBO";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtCobDFDif_Internalname = "COBDFDIF";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtCobDBanCod_Internalname = "COBDBANCOD";
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
         Form.Caption = "Cobranza - Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCobDBanCod_Jsonclick = "";
         edtCobDBanCod_Enabled = 1;
         edtCobDFDif_Jsonclick = "";
         edtCobDFDif_Enabled = 1;
         edtCobDRecibo_Jsonclick = "";
         edtCobDRecibo_Enabled = 1;
         edtCobAfecta_Jsonclick = "";
         edtCobAfecta_Enabled = 0;
         edtCobDCanje_Jsonclick = "";
         edtCobDCanje_Enabled = 1;
         edtCobDTot_Jsonclick = "";
         edtCobDTot_Enabled = 1;
         edtCobTipCam_Jsonclick = "";
         edtCobTipCam_Enabled = 1;
         edtCobRef_Jsonclick = "";
         edtCobRef_Enabled = 1;
         edtForCod_Jsonclick = "";
         edtForCod_Enabled = 1;
         edtCobMonOrigen_Jsonclick = "";
         edtCobMonOrigen_Enabled = 0;
         edtCobDocNum_Jsonclick = "";
         edtCobDocNum_Enabled = 1;
         edtCobTipCod_Jsonclick = "";
         edtCobTipCod_Enabled = 1;
         edtCobCliDsc_Jsonclick = "";
         edtCobCliDsc_Enabled = 0;
         edtCobCliCod_Jsonclick = "";
         edtCobCliCod_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtItem_Jsonclick = "";
         edtItem_Enabled = 1;
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
         /* Using cursor T002H19 */
         pr_default.execute(17, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobranza - Cabecera'.", "ForeignKeyNotFound", 1, "COBCOD");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A643CobAfecta = T002H19_A643CobAfecta[0];
         AssignAttri("", false, "A643CobAfecta", StringUtil.Str( (decimal)(A643CobAfecta), 1, 0));
         pr_default.close(17);
         GX_FocusControl = edtCobTipCod_Internalname;
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
         /* Using cursor T002H19 */
         pr_default.execute(17, new Object[] {A166CobTip, A167CobCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Cobranza - Cabecera'.", "ForeignKeyNotFound", 1, "COBCOD");
            AnyError = 1;
            GX_FocusControl = edtCobTip_Internalname;
         }
         A643CobAfecta = T002H19_A643CobAfecta[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A643CobAfecta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A643CobAfecta), 1, 0, ".", "")));
      }

      public void Valid_Item( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A175CobTipCod", StringUtil.RTrim( A175CobTipCod));
         AssignAttri("", false, "A176CobDocNum", StringUtil.RTrim( A176CobDocNum));
         AssignAttri("", false, "A143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A659CobRef", StringUtil.RTrim( A659CobRef));
         AssignAttri("", false, "A663CobTipCam", StringUtil.LTrim( StringUtil.NToC( A663CobTipCam, 15, 5, ".", "")));
         AssignAttri("", false, "A654CobDTot", StringUtil.LTrim( StringUtil.NToC( A654CobDTot, 15, 2, ".", "")));
         AssignAttri("", false, "A647CobDCanje", StringUtil.RTrim( A647CobDCanje));
         AssignAttri("", false, "A649CobDRecibo", StringUtil.RTrim( A649CobDRecibo));
         AssignAttri("", false, "A648CobDFDif", context.localUtil.Format(A648CobDFDif, "99/99/99"));
         AssignAttri("", false, "A174CobDBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A174CobDBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A650CobDRef1", A650CobDRef1);
         AssignAttri("", false, "A651CobDRef2", A651CobDRef2);
         AssignAttri("", false, "A652CobDRef3", A652CobDRef3);
         AssignAttri("", false, "A653CobDRef4", A653CobDRef4);
         AssignAttri("", false, "A643CobAfecta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A643CobAfecta), 1, 0, ".", "")));
         AssignAttri("", false, "A646CobCliDsc", StringUtil.RTrim( A646CobCliDsc));
         AssignAttri("", false, "A645CobCliCod", StringUtil.RTrim( A645CobCliCod));
         AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(A658CobMonOrigen), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z166CobTip", StringUtil.RTrim( Z166CobTip));
         GxWebStd.gx_hidden_field( context, "Z167CobCod", StringUtil.RTrim( Z167CobCod));
         GxWebStd.gx_hidden_field( context, "Z173Item", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z173Item), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z175CobTipCod", StringUtil.RTrim( Z175CobTipCod));
         GxWebStd.gx_hidden_field( context, "Z176CobDocNum", StringUtil.RTrim( Z176CobDocNum));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z659CobRef", StringUtil.RTrim( Z659CobRef));
         GxWebStd.gx_hidden_field( context, "Z663CobTipCam", StringUtil.LTrim( StringUtil.NToC( Z663CobTipCam, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z654CobDTot", StringUtil.LTrim( StringUtil.NToC( Z654CobDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z647CobDCanje", StringUtil.RTrim( Z647CobDCanje));
         GxWebStd.gx_hidden_field( context, "Z649CobDRecibo", StringUtil.RTrim( Z649CobDRecibo));
         GxWebStd.gx_hidden_field( context, "Z648CobDFDif", context.localUtil.Format(Z648CobDFDif, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z174CobDBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z174CobDBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z650CobDRef1", Z650CobDRef1);
         GxWebStd.gx_hidden_field( context, "Z651CobDRef2", Z651CobDRef2);
         GxWebStd.gx_hidden_field( context, "Z652CobDRef3", Z652CobDRef3);
         GxWebStd.gx_hidden_field( context, "Z653CobDRef4", Z653CobDRef4);
         GxWebStd.gx_hidden_field( context, "Z643CobAfecta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z643CobAfecta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z646CobCliDsc", StringUtil.RTrim( Z646CobCliDsc));
         GxWebStd.gx_hidden_field( context, "Z645CobCliCod", StringUtil.RTrim( Z645CobCliCod));
         GxWebStd.gx_hidden_field( context, "Z658CobMonOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z658CobMonOrigen), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cobdocnum( )
      {
         /* Using cursor T002H20 */
         pr_default.execute(18, new Object[] {A175CobTipCod, A176CobDocNum});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento de Cobranza'.", "ForeignKeyNotFound", 1, "COBDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCobTipCod_Internalname;
         }
         A646CobCliDsc = T002H20_A646CobCliDsc[0];
         A645CobCliCod = T002H20_A645CobCliCod[0];
         A658CobMonOrigen = T002H20_A658CobMonOrigen[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A646CobCliDsc", StringUtil.RTrim( A646CobCliDsc));
         AssignAttri("", false, "A645CobCliCod", StringUtil.RTrim( A645CobCliCod));
         AssignAttri("", false, "A658CobMonOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(A658CobMonOrigen), 6, 0, ".", "")));
      }

      public void Valid_Forcod( )
      {
         /* Using cursor T002H22 */
         pr_default.execute(20, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cobdbancod( )
      {
         n174CobDBanCod = false;
         /* Using cursor T002H23 */
         pr_default.execute(21, new Object[] {n174CobDBanCod, A174CobDBanCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A174CobDBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "COBDBANCOD");
               AnyError = 1;
               GX_FocusControl = edtCobDBanCod_Internalname;
            }
         }
         pr_default.close(21);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A650CobDRef1',fld:'COBDREF1',pic:''},{av:'A651CobDRef2',fld:'COBDREF2',pic:''},{av:'A652CobDRef3',fld:'COBDREF3',pic:''},{av:'A653CobDRef4',fld:'COBDREF4',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_COBTIP","{handler:'Valid_Cobtip',iparms:[]");
         setEventMetadata("VALID_COBTIP",",oparms:[]}");
         setEventMetadata("VALID_COBCOD","{handler:'Valid_Cobcod',iparms:[{av:'A166CobTip',fld:'COBTIP',pic:''},{av:'A167CobCod',fld:'COBCOD',pic:''},{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'}]");
         setEventMetadata("VALID_COBCOD",",oparms:[{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'}]}");
         setEventMetadata("VALID_ITEM","{handler:'Valid_Item',iparms:[{av:'A653CobDRef4',fld:'COBDREF4',pic:''},{av:'A652CobDRef3',fld:'COBDREF3',pic:''},{av:'A651CobDRef2',fld:'COBDREF2',pic:''},{av:'A650CobDRef1',fld:'COBDREF1',pic:''},{av:'A166CobTip',fld:'COBTIP',pic:''},{av:'A167CobCod',fld:'COBCOD',pic:''},{av:'A173Item',fld:'ITEM',pic:'ZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ITEM",",oparms:[{av:'A175CobTipCod',fld:'COBTIPCOD',pic:''},{av:'A176CobDocNum',fld:'COBDOCNUM',pic:''},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'A659CobRef',fld:'COBREF',pic:''},{av:'A663CobTipCam',fld:'COBTIPCAM',pic:'ZZZZZZZZ9.99999'},{av:'A654CobDTot',fld:'COBDTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A647CobDCanje',fld:'COBDCANJE',pic:''},{av:'A649CobDRecibo',fld:'COBDRECIBO',pic:''},{av:'A648CobDFDif',fld:'COBDFDIF',pic:''},{av:'A174CobDBanCod',fld:'COBDBANCOD',pic:'ZZZZZ9'},{av:'A650CobDRef1',fld:'COBDREF1',pic:''},{av:'A651CobDRef2',fld:'COBDREF2',pic:''},{av:'A652CobDRef3',fld:'COBDREF3',pic:''},{av:'A653CobDRef4',fld:'COBDREF4',pic:''},{av:'A643CobAfecta',fld:'COBAFECTA',pic:'9'},{av:'A646CobCliDsc',fld:'COBCLIDSC',pic:''},{av:'A645CobCliCod',fld:'COBCLICOD',pic:''},{av:'A658CobMonOrigen',fld:'COBMONORIGEN',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z166CobTip'},{av:'Z167CobCod'},{av:'Z173Item'},{av:'Z175CobTipCod'},{av:'Z176CobDocNum'},{av:'Z143ForCod'},{av:'Z659CobRef'},{av:'Z663CobTipCam'},{av:'Z654CobDTot'},{av:'Z647CobDCanje'},{av:'Z649CobDRecibo'},{av:'Z648CobDFDif'},{av:'Z174CobDBanCod'},{av:'Z650CobDRef1'},{av:'Z651CobDRef2'},{av:'Z652CobDRef3'},{av:'Z653CobDRef4'},{av:'Z643CobAfecta'},{av:'Z646CobCliDsc'},{av:'Z645CobCliCod'},{av:'Z658CobMonOrigen'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_COBTIPCOD","{handler:'Valid_Cobtipcod',iparms:[]");
         setEventMetadata("VALID_COBTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_COBDOCNUM","{handler:'Valid_Cobdocnum',iparms:[{av:'A175CobTipCod',fld:'COBTIPCOD',pic:''},{av:'A176CobDocNum',fld:'COBDOCNUM',pic:''},{av:'A646CobCliDsc',fld:'COBCLIDSC',pic:''},{av:'A645CobCliCod',fld:'COBCLICOD',pic:''},{av:'A658CobMonOrigen',fld:'COBMONORIGEN',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COBDOCNUM",",oparms:[{av:'A646CobCliDsc',fld:'COBCLIDSC',pic:''},{av:'A645CobCliCod',fld:'COBCLICOD',pic:''},{av:'A658CobMonOrigen',fld:'COBMONORIGEN',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_FORCOD","{handler:'Valid_Forcod',iparms:[{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_FORCOD",",oparms:[]}");
         setEventMetadata("VALID_COBDFDIF","{handler:'Valid_Cobdfdif',iparms:[]");
         setEventMetadata("VALID_COBDFDIF",",oparms:[]}");
         setEventMetadata("VALID_COBDBANCOD","{handler:'Valid_Cobdbancod',iparms:[{av:'A174CobDBanCod',fld:'COBDBANCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COBDBANCOD",",oparms:[]}");
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
         pr_default.close(17);
         pr_default.close(20);
         pr_default.close(18);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z166CobTip = "";
         Z167CobCod = "";
         Z659CobRef = "";
         Z647CobDCanje = "";
         Z649CobDRecibo = "";
         Z648CobDFDif = DateTime.MinValue;
         Z650CobDRef1 = "";
         Z651CobDRef2 = "";
         Z652CobDRef3 = "";
         Z653CobDRef4 = "";
         Z175CobTipCod = "";
         Z176CobDocNum = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A166CobTip = "";
         A167CobCod = "";
         A175CobTipCod = "";
         A176CobDocNum = "";
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
         A645CobCliCod = "";
         lblTextblock5_Jsonclick = "";
         A646CobCliDsc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A659CobRef = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A647CobDCanje = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A649CobDRecibo = "";
         lblTextblock16_Jsonclick = "";
         A648CobDFDif = DateTime.MinValue;
         lblTextblock17_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A650CobDRef1 = "";
         A651CobDRef2 = "";
         A652CobDRef3 = "";
         A653CobDRef4 = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z646CobCliDsc = "";
         Z645CobCliCod = "";
         T002H8_A173Item = new int[1] ;
         T002H8_A646CobCliDsc = new string[] {""} ;
         T002H8_A659CobRef = new string[] {""} ;
         T002H8_A663CobTipCam = new decimal[1] ;
         T002H8_A654CobDTot = new decimal[1] ;
         T002H8_A647CobDCanje = new string[] {""} ;
         T002H8_A643CobAfecta = new short[1] ;
         T002H8_A649CobDRecibo = new string[] {""} ;
         T002H8_A648CobDFDif = new DateTime[] {DateTime.MinValue} ;
         T002H8_A650CobDRef1 = new string[] {""} ;
         T002H8_A651CobDRef2 = new string[] {""} ;
         T002H8_A652CobDRef3 = new string[] {""} ;
         T002H8_A653CobDRef4 = new string[] {""} ;
         T002H8_A166CobTip = new string[] {""} ;
         T002H8_A167CobCod = new string[] {""} ;
         T002H8_A143ForCod = new int[1] ;
         T002H8_A175CobTipCod = new string[] {""} ;
         T002H8_A176CobDocNum = new string[] {""} ;
         T002H8_A174CobDBanCod = new int[1] ;
         T002H8_n174CobDBanCod = new bool[] {false} ;
         T002H8_A645CobCliCod = new string[] {""} ;
         T002H8_A658CobMonOrigen = new int[1] ;
         T002H4_A643CobAfecta = new short[1] ;
         T002H6_A646CobCliDsc = new string[] {""} ;
         T002H6_A645CobCliCod = new string[] {""} ;
         T002H6_A658CobMonOrigen = new int[1] ;
         T002H5_A143ForCod = new int[1] ;
         T002H7_A174CobDBanCod = new int[1] ;
         T002H7_n174CobDBanCod = new bool[] {false} ;
         T002H9_A643CobAfecta = new short[1] ;
         T002H10_A646CobCliDsc = new string[] {""} ;
         T002H10_A645CobCliCod = new string[] {""} ;
         T002H10_A658CobMonOrigen = new int[1] ;
         T002H11_A143ForCod = new int[1] ;
         T002H12_A174CobDBanCod = new int[1] ;
         T002H12_n174CobDBanCod = new bool[] {false} ;
         T002H13_A166CobTip = new string[] {""} ;
         T002H13_A167CobCod = new string[] {""} ;
         T002H13_A173Item = new int[1] ;
         T002H3_A173Item = new int[1] ;
         T002H3_A659CobRef = new string[] {""} ;
         T002H3_A663CobTipCam = new decimal[1] ;
         T002H3_A654CobDTot = new decimal[1] ;
         T002H3_A647CobDCanje = new string[] {""} ;
         T002H3_A649CobDRecibo = new string[] {""} ;
         T002H3_A648CobDFDif = new DateTime[] {DateTime.MinValue} ;
         T002H3_A650CobDRef1 = new string[] {""} ;
         T002H3_A651CobDRef2 = new string[] {""} ;
         T002H3_A652CobDRef3 = new string[] {""} ;
         T002H3_A653CobDRef4 = new string[] {""} ;
         T002H3_A166CobTip = new string[] {""} ;
         T002H3_A167CobCod = new string[] {""} ;
         T002H3_A143ForCod = new int[1] ;
         T002H3_A175CobTipCod = new string[] {""} ;
         T002H3_A176CobDocNum = new string[] {""} ;
         T002H3_A174CobDBanCod = new int[1] ;
         T002H3_n174CobDBanCod = new bool[] {false} ;
         sMode85 = "";
         T002H14_A166CobTip = new string[] {""} ;
         T002H14_A167CobCod = new string[] {""} ;
         T002H14_A173Item = new int[1] ;
         T002H15_A166CobTip = new string[] {""} ;
         T002H15_A167CobCod = new string[] {""} ;
         T002H15_A173Item = new int[1] ;
         T002H2_A173Item = new int[1] ;
         T002H2_A659CobRef = new string[] {""} ;
         T002H2_A663CobTipCam = new decimal[1] ;
         T002H2_A654CobDTot = new decimal[1] ;
         T002H2_A647CobDCanje = new string[] {""} ;
         T002H2_A649CobDRecibo = new string[] {""} ;
         T002H2_A648CobDFDif = new DateTime[] {DateTime.MinValue} ;
         T002H2_A650CobDRef1 = new string[] {""} ;
         T002H2_A651CobDRef2 = new string[] {""} ;
         T002H2_A652CobDRef3 = new string[] {""} ;
         T002H2_A653CobDRef4 = new string[] {""} ;
         T002H2_A166CobTip = new string[] {""} ;
         T002H2_A167CobCod = new string[] {""} ;
         T002H2_A143ForCod = new int[1] ;
         T002H2_A175CobTipCod = new string[] {""} ;
         T002H2_A176CobDocNum = new string[] {""} ;
         T002H2_A174CobDBanCod = new int[1] ;
         T002H2_n174CobDBanCod = new bool[] {false} ;
         T002H19_A643CobAfecta = new short[1] ;
         T002H20_A646CobCliDsc = new string[] {""} ;
         T002H20_A645CobCliCod = new string[] {""} ;
         T002H20_A658CobMonOrigen = new int[1] ;
         T002H21_A166CobTip = new string[] {""} ;
         T002H21_A167CobCod = new string[] {""} ;
         T002H21_A173Item = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ166CobTip = "";
         ZZ167CobCod = "";
         ZZ175CobTipCod = "";
         ZZ176CobDocNum = "";
         ZZ659CobRef = "";
         ZZ647CobDCanje = "";
         ZZ649CobDRecibo = "";
         ZZ648CobDFDif = DateTime.MinValue;
         ZZ650CobDRef1 = "";
         ZZ651CobDRef2 = "";
         ZZ652CobDRef3 = "";
         ZZ653CobDRef4 = "";
         ZZ646CobCliDsc = "";
         ZZ645CobCliCod = "";
         T002H22_A143ForCod = new int[1] ;
         T002H23_A174CobDBanCod = new int[1] ;
         T002H23_n174CobDBanCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clcobranzadet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clcobranzadet__default(),
            new Object[][] {
                new Object[] {
               T002H2_A173Item, T002H2_A659CobRef, T002H2_A663CobTipCam, T002H2_A654CobDTot, T002H2_A647CobDCanje, T002H2_A649CobDRecibo, T002H2_A648CobDFDif, T002H2_A650CobDRef1, T002H2_A651CobDRef2, T002H2_A652CobDRef3,
               T002H2_A653CobDRef4, T002H2_A166CobTip, T002H2_A167CobCod, T002H2_A143ForCod, T002H2_A175CobTipCod, T002H2_A176CobDocNum, T002H2_A174CobDBanCod, T002H2_n174CobDBanCod
               }
               , new Object[] {
               T002H3_A173Item, T002H3_A659CobRef, T002H3_A663CobTipCam, T002H3_A654CobDTot, T002H3_A647CobDCanje, T002H3_A649CobDRecibo, T002H3_A648CobDFDif, T002H3_A650CobDRef1, T002H3_A651CobDRef2, T002H3_A652CobDRef3,
               T002H3_A653CobDRef4, T002H3_A166CobTip, T002H3_A167CobCod, T002H3_A143ForCod, T002H3_A175CobTipCod, T002H3_A176CobDocNum, T002H3_A174CobDBanCod, T002H3_n174CobDBanCod
               }
               , new Object[] {
               T002H4_A643CobAfecta
               }
               , new Object[] {
               T002H5_A143ForCod
               }
               , new Object[] {
               T002H6_A646CobCliDsc, T002H6_A645CobCliCod, T002H6_A658CobMonOrigen
               }
               , new Object[] {
               T002H7_A174CobDBanCod
               }
               , new Object[] {
               T002H8_A173Item, T002H8_A646CobCliDsc, T002H8_A659CobRef, T002H8_A663CobTipCam, T002H8_A654CobDTot, T002H8_A647CobDCanje, T002H8_A643CobAfecta, T002H8_A649CobDRecibo, T002H8_A648CobDFDif, T002H8_A650CobDRef1,
               T002H8_A651CobDRef2, T002H8_A652CobDRef3, T002H8_A653CobDRef4, T002H8_A166CobTip, T002H8_A167CobCod, T002H8_A143ForCod, T002H8_A175CobTipCod, T002H8_A176CobDocNum, T002H8_A174CobDBanCod, T002H8_n174CobDBanCod,
               T002H8_A645CobCliCod, T002H8_A658CobMonOrigen
               }
               , new Object[] {
               T002H9_A643CobAfecta
               }
               , new Object[] {
               T002H10_A646CobCliDsc, T002H10_A645CobCliCod, T002H10_A658CobMonOrigen
               }
               , new Object[] {
               T002H11_A143ForCod
               }
               , new Object[] {
               T002H12_A174CobDBanCod
               }
               , new Object[] {
               T002H13_A166CobTip, T002H13_A167CobCod, T002H13_A173Item
               }
               , new Object[] {
               T002H14_A166CobTip, T002H14_A167CobCod, T002H14_A173Item
               }
               , new Object[] {
               T002H15_A166CobTip, T002H15_A167CobCod, T002H15_A173Item
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002H19_A643CobAfecta
               }
               , new Object[] {
               T002H20_A646CobCliDsc, T002H20_A645CobCliCod, T002H20_A658CobMonOrigen
               }
               , new Object[] {
               T002H21_A166CobTip, T002H21_A167CobCod, T002H21_A173Item
               }
               , new Object[] {
               T002H22_A143ForCod
               }
               , new Object[] {
               T002H23_A174CobDBanCod
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
      private short A643CobAfecta ;
      private short GX_JID ;
      private short Z643CobAfecta ;
      private short RcdFound85 ;
      private short nIsDirty_85 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ643CobAfecta ;
      private int Z173Item ;
      private int Z143ForCod ;
      private int Z174CobDBanCod ;
      private int A143ForCod ;
      private int A174CobDBanCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCobTip_Enabled ;
      private int edtCobCod_Enabled ;
      private int A173Item ;
      private int edtItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCobCliCod_Enabled ;
      private int edtCobCliDsc_Enabled ;
      private int edtCobTipCod_Enabled ;
      private int edtCobDocNum_Enabled ;
      private int A658CobMonOrigen ;
      private int edtCobMonOrigen_Enabled ;
      private int edtForCod_Enabled ;
      private int edtCobRef_Enabled ;
      private int edtCobTipCam_Enabled ;
      private int edtCobDTot_Enabled ;
      private int edtCobDCanje_Enabled ;
      private int edtCobAfecta_Enabled ;
      private int edtCobDRecibo_Enabled ;
      private int edtCobDFDif_Enabled ;
      private int edtCobDBanCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z658CobMonOrigen ;
      private int idxLst ;
      private int ZZ173Item ;
      private int ZZ143ForCod ;
      private int ZZ174CobDBanCod ;
      private int ZZ658CobMonOrigen ;
      private decimal Z663CobTipCam ;
      private decimal Z654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal A654CobDTot ;
      private decimal ZZ663CobTipCam ;
      private decimal ZZ654CobDTot ;
      private string sPrefix ;
      private string Z166CobTip ;
      private string Z167CobCod ;
      private string Z659CobRef ;
      private string Z647CobDCanje ;
      private string Z649CobDRecibo ;
      private string Z175CobTipCod ;
      private string Z176CobDocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A175CobTipCod ;
      private string A176CobDocNum ;
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
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtItem_Internalname ;
      private string edtItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCobCliCod_Internalname ;
      private string A645CobCliCod ;
      private string edtCobCliCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCobCliDsc_Internalname ;
      private string A646CobCliDsc ;
      private string edtCobCliDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCobTipCod_Internalname ;
      private string edtCobTipCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCobDocNum_Internalname ;
      private string edtCobDocNum_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCobMonOrigen_Internalname ;
      private string edtCobMonOrigen_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtForCod_Internalname ;
      private string edtForCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCobRef_Internalname ;
      private string A659CobRef ;
      private string edtCobRef_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCobTipCam_Internalname ;
      private string edtCobTipCam_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtCobDTot_Internalname ;
      private string edtCobDTot_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtCobDCanje_Internalname ;
      private string A647CobDCanje ;
      private string edtCobDCanje_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtCobAfecta_Internalname ;
      private string edtCobAfecta_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtCobDRecibo_Internalname ;
      private string A649CobDRecibo ;
      private string edtCobDRecibo_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtCobDFDif_Internalname ;
      private string edtCobDFDif_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtCobDBanCod_Internalname ;
      private string edtCobDBanCod_Jsonclick ;
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
      private string Z646CobCliDsc ;
      private string Z645CobCliCod ;
      private string sMode85 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ166CobTip ;
      private string ZZ167CobCod ;
      private string ZZ175CobTipCod ;
      private string ZZ176CobDocNum ;
      private string ZZ659CobRef ;
      private string ZZ647CobDCanje ;
      private string ZZ649CobDRecibo ;
      private string ZZ646CobCliDsc ;
      private string ZZ645CobCliCod ;
      private DateTime Z648CobDFDif ;
      private DateTime A648CobDFDif ;
      private DateTime ZZ648CobDFDif ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n174CobDBanCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z650CobDRef1 ;
      private string Z651CobDRef2 ;
      private string Z652CobDRef3 ;
      private string Z653CobDRef4 ;
      private string A650CobDRef1 ;
      private string A651CobDRef2 ;
      private string A652CobDRef3 ;
      private string A653CobDRef4 ;
      private string ZZ650CobDRef1 ;
      private string ZZ651CobDRef2 ;
      private string ZZ652CobDRef3 ;
      private string ZZ653CobDRef4 ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002H8_A173Item ;
      private string[] T002H8_A646CobCliDsc ;
      private string[] T002H8_A659CobRef ;
      private decimal[] T002H8_A663CobTipCam ;
      private decimal[] T002H8_A654CobDTot ;
      private string[] T002H8_A647CobDCanje ;
      private short[] T002H8_A643CobAfecta ;
      private string[] T002H8_A649CobDRecibo ;
      private DateTime[] T002H8_A648CobDFDif ;
      private string[] T002H8_A650CobDRef1 ;
      private string[] T002H8_A651CobDRef2 ;
      private string[] T002H8_A652CobDRef3 ;
      private string[] T002H8_A653CobDRef4 ;
      private string[] T002H8_A166CobTip ;
      private string[] T002H8_A167CobCod ;
      private int[] T002H8_A143ForCod ;
      private string[] T002H8_A175CobTipCod ;
      private string[] T002H8_A176CobDocNum ;
      private int[] T002H8_A174CobDBanCod ;
      private bool[] T002H8_n174CobDBanCod ;
      private string[] T002H8_A645CobCliCod ;
      private int[] T002H8_A658CobMonOrigen ;
      private short[] T002H4_A643CobAfecta ;
      private string[] T002H6_A646CobCliDsc ;
      private string[] T002H6_A645CobCliCod ;
      private int[] T002H6_A658CobMonOrigen ;
      private int[] T002H5_A143ForCod ;
      private int[] T002H7_A174CobDBanCod ;
      private bool[] T002H7_n174CobDBanCod ;
      private short[] T002H9_A643CobAfecta ;
      private string[] T002H10_A646CobCliDsc ;
      private string[] T002H10_A645CobCliCod ;
      private int[] T002H10_A658CobMonOrigen ;
      private int[] T002H11_A143ForCod ;
      private int[] T002H12_A174CobDBanCod ;
      private bool[] T002H12_n174CobDBanCod ;
      private string[] T002H13_A166CobTip ;
      private string[] T002H13_A167CobCod ;
      private int[] T002H13_A173Item ;
      private int[] T002H3_A173Item ;
      private string[] T002H3_A659CobRef ;
      private decimal[] T002H3_A663CobTipCam ;
      private decimal[] T002H3_A654CobDTot ;
      private string[] T002H3_A647CobDCanje ;
      private string[] T002H3_A649CobDRecibo ;
      private DateTime[] T002H3_A648CobDFDif ;
      private string[] T002H3_A650CobDRef1 ;
      private string[] T002H3_A651CobDRef2 ;
      private string[] T002H3_A652CobDRef3 ;
      private string[] T002H3_A653CobDRef4 ;
      private string[] T002H3_A166CobTip ;
      private string[] T002H3_A167CobCod ;
      private int[] T002H3_A143ForCod ;
      private string[] T002H3_A175CobTipCod ;
      private string[] T002H3_A176CobDocNum ;
      private int[] T002H3_A174CobDBanCod ;
      private bool[] T002H3_n174CobDBanCod ;
      private string[] T002H14_A166CobTip ;
      private string[] T002H14_A167CobCod ;
      private int[] T002H14_A173Item ;
      private string[] T002H15_A166CobTip ;
      private string[] T002H15_A167CobCod ;
      private int[] T002H15_A173Item ;
      private int[] T002H2_A173Item ;
      private string[] T002H2_A659CobRef ;
      private decimal[] T002H2_A663CobTipCam ;
      private decimal[] T002H2_A654CobDTot ;
      private string[] T002H2_A647CobDCanje ;
      private string[] T002H2_A649CobDRecibo ;
      private DateTime[] T002H2_A648CobDFDif ;
      private string[] T002H2_A650CobDRef1 ;
      private string[] T002H2_A651CobDRef2 ;
      private string[] T002H2_A652CobDRef3 ;
      private string[] T002H2_A653CobDRef4 ;
      private string[] T002H2_A166CobTip ;
      private string[] T002H2_A167CobCod ;
      private int[] T002H2_A143ForCod ;
      private string[] T002H2_A175CobTipCod ;
      private string[] T002H2_A176CobDocNum ;
      private int[] T002H2_A174CobDBanCod ;
      private bool[] T002H2_n174CobDBanCod ;
      private short[] T002H19_A643CobAfecta ;
      private string[] T002H20_A646CobCliDsc ;
      private string[] T002H20_A645CobCliCod ;
      private int[] T002H20_A658CobMonOrigen ;
      private string[] T002H21_A166CobTip ;
      private string[] T002H21_A167CobCod ;
      private int[] T002H21_A173Item ;
      private int[] T002H22_A143ForCod ;
      private int[] T002H23_A174CobDBanCod ;
      private bool[] T002H23_n174CobDBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clcobranzadet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clcobranzadet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002H8;
        prmT002H8 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H4;
        prmT002H4 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002H6;
        prmT002H6 = new Object[] {
        new ParDef("@CobTipCod",GXType.NChar,3,0) ,
        new ParDef("@CobDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002H5;
        prmT002H5 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002H7;
        prmT002H7 = new Object[] {
        new ParDef("@CobDBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002H9;
        prmT002H9 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002H10;
        prmT002H10 = new Object[] {
        new ParDef("@CobTipCod",GXType.NChar,3,0) ,
        new ParDef("@CobDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002H11;
        prmT002H11 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002H12;
        prmT002H12 = new Object[] {
        new ParDef("@CobDBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002H13;
        prmT002H13 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H3;
        prmT002H3 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H14;
        prmT002H14 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H15;
        prmT002H15 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H2;
        prmT002H2 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H16;
        prmT002H16 = new Object[] {
        new ParDef("@Item",GXType.Int32,5,0) ,
        new ParDef("@CobRef",GXType.NChar,20,0) ,
        new ParDef("@CobTipCam",GXType.Decimal,15,5) ,
        new ParDef("@CobDTot",GXType.Decimal,15,2) ,
        new ParDef("@CobDCanje",GXType.NChar,10,0) ,
        new ParDef("@CobDRecibo",GXType.NChar,20,0) ,
        new ParDef("@CobDFDif",GXType.Date,8,0) ,
        new ParDef("@CobDRef1",GXType.NVarChar,20,0) ,
        new ParDef("@CobDRef2",GXType.NVarChar,20,0) ,
        new ParDef("@CobDRef3",GXType.NVarChar,20,0) ,
        new ParDef("@CobDRef4",GXType.NVarChar,20,0) ,
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@CobTipCod",GXType.NChar,3,0) ,
        new ParDef("@CobDocNum",GXType.NChar,12,0) ,
        new ParDef("@CobDBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002H17;
        prmT002H17 = new Object[] {
        new ParDef("@CobRef",GXType.NChar,20,0) ,
        new ParDef("@CobTipCam",GXType.Decimal,15,5) ,
        new ParDef("@CobDTot",GXType.Decimal,15,2) ,
        new ParDef("@CobDCanje",GXType.NChar,10,0) ,
        new ParDef("@CobDRecibo",GXType.NChar,20,0) ,
        new ParDef("@CobDFDif",GXType.Date,8,0) ,
        new ParDef("@CobDRef1",GXType.NVarChar,20,0) ,
        new ParDef("@CobDRef2",GXType.NVarChar,20,0) ,
        new ParDef("@CobDRef3",GXType.NVarChar,20,0) ,
        new ParDef("@CobDRef4",GXType.NVarChar,20,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@CobTipCod",GXType.NChar,3,0) ,
        new ParDef("@CobDocNum",GXType.NChar,12,0) ,
        new ParDef("@CobDBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H18;
        prmT002H18 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0) ,
        new ParDef("@Item",GXType.Int32,5,0)
        };
        Object[] prmT002H21;
        prmT002H21 = new Object[] {
        };
        Object[] prmT002H19;
        prmT002H19 = new Object[] {
        new ParDef("@CobTip",GXType.NChar,1,0) ,
        new ParDef("@CobCod",GXType.NChar,12,0)
        };
        Object[] prmT002H20;
        prmT002H20 = new Object[] {
        new ParDef("@CobTipCod",GXType.NChar,3,0) ,
        new ParDef("@CobDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002H22;
        prmT002H22 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT002H23;
        prmT002H23 = new Object[] {
        new ParDef("@CobDBanCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T002H2", "SELECT [Item], [CobRef], [CobTipCam], [CobDTot], [CobDCanje], [CobDRecibo], [CobDFDif], [CobDRef1], [CobDRef2], [CobDRef3], [CobDRef4], [CobTip], [CobCod], [ForCod], [CobTipCod] AS CobTipCod, [CobDocNum] AS CobDocNum, [CobDBanCod] AS CobDBanCod FROM [CLCOBRANZADET] WITH (UPDLOCK) WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod AND [Item] = @Item ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H3", "SELECT [Item], [CobRef], [CobTipCam], [CobDTot], [CobDCanje], [CobDRecibo], [CobDFDif], [CobDRef1], [CobDRef2], [CobDRef3], [CobDRef4], [CobTip], [CobCod], [ForCod], [CobTipCod] AS CobTipCod, [CobDocNum] AS CobDocNum, [CobDBanCod] AS CobDBanCod FROM [CLCOBRANZADET] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod AND [Item] = @Item ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H4", "SELECT [CobAfecta] FROM [CLCOBRANZA] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H5", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H6", "SELECT [CCCliDsc] AS CobCliDsc, [CCCliCod] AS CobCliCod, [CCmonCod] AS CobMonOrigen FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CobTipCod AND [CCDocNum] = @CobDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H7", "SELECT [BanCod] AS CobDBanCod FROM [TSBANCOS] WHERE [BanCod] = @CobDBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H8", "SELECT TM1.[Item], T3.[CCCliDsc] AS CobCliDsc, TM1.[CobRef], TM1.[CobTipCam], TM1.[CobDTot], TM1.[CobDCanje], T2.[CobAfecta], TM1.[CobDRecibo], TM1.[CobDFDif], TM1.[CobDRef1], TM1.[CobDRef2], TM1.[CobDRef3], TM1.[CobDRef4], TM1.[CobTip], TM1.[CobCod], TM1.[ForCod], TM1.[CobTipCod] AS CobTipCod, TM1.[CobDocNum] AS CobDocNum, TM1.[CobDBanCod] AS CobDBanCod, T3.[CCCliCod] AS CobCliCod, T3.[CCmonCod] AS CobMonOrigen FROM (([CLCOBRANZADET] TM1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = TM1.[CobTip] AND T2.[CobCod] = TM1.[CobCod]) INNER JOIN [CLCUENTACOBRAR] T3 ON T3.[CCTipCod] = TM1.[CobTipCod] AND T3.[CCDocNum] = TM1.[CobDocNum]) WHERE TM1.[CobTip] = @CobTip and TM1.[CobCod] = @CobCod and TM1.[Item] = @Item ORDER BY TM1.[CobTip], TM1.[CobCod], TM1.[Item]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002H8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H9", "SELECT [CobAfecta] FROM [CLCOBRANZA] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H10", "SELECT [CCCliDsc] AS CobCliDsc, [CCCliCod] AS CobCliCod, [CCmonCod] AS CobMonOrigen FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CobTipCod AND [CCDocNum] = @CobDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H11", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H12", "SELECT [BanCod] AS CobDBanCod FROM [TSBANCOS] WHERE [BanCod] = @CobDBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H13", "SELECT [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod AND [Item] = @Item  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002H13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H14", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE ( [CobTip] > @CobTip or [CobTip] = @CobTip and [CobCod] > @CobCod or [CobCod] = @CobCod and [CobTip] = @CobTip and [Item] > @Item) ORDER BY [CobTip], [CobCod], [Item]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002H14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002H15", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE ( [CobTip] < @CobTip or [CobTip] = @CobTip and [CobCod] < @CobCod or [CobCod] = @CobCod and [CobTip] = @CobTip and [Item] < @Item) ORDER BY [CobTip] DESC, [CobCod] DESC, [Item] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002H15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002H16", "INSERT INTO [CLCOBRANZADET]([Item], [CobRef], [CobTipCam], [CobDTot], [CobDCanje], [CobDRecibo], [CobDFDif], [CobDRef1], [CobDRef2], [CobDRef3], [CobDRef4], [CobTip], [CobCod], [ForCod], [CobTipCod], [CobDocNum], [CobDBanCod]) VALUES(@Item, @CobRef, @CobTipCam, @CobDTot, @CobDCanje, @CobDRecibo, @CobDFDif, @CobDRef1, @CobDRef2, @CobDRef3, @CobDRef4, @CobTip, @CobCod, @ForCod, @CobTipCod, @CobDocNum, @CobDBanCod)", GxErrorMask.GX_NOMASK,prmT002H16)
           ,new CursorDef("T002H17", "UPDATE [CLCOBRANZADET] SET [CobRef]=@CobRef, [CobTipCam]=@CobTipCam, [CobDTot]=@CobDTot, [CobDCanje]=@CobDCanje, [CobDRecibo]=@CobDRecibo, [CobDFDif]=@CobDFDif, [CobDRef1]=@CobDRef1, [CobDRef2]=@CobDRef2, [CobDRef3]=@CobDRef3, [CobDRef4]=@CobDRef4, [ForCod]=@ForCod, [CobTipCod]=@CobTipCod, [CobDocNum]=@CobDocNum, [CobDBanCod]=@CobDBanCod  WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod AND [Item] = @Item", GxErrorMask.GX_NOMASK,prmT002H17)
           ,new CursorDef("T002H18", "DELETE FROM [CLCOBRANZADET]  WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod AND [Item] = @Item", GxErrorMask.GX_NOMASK,prmT002H18)
           ,new CursorDef("T002H19", "SELECT [CobAfecta] FROM [CLCOBRANZA] WHERE [CobTip] = @CobTip AND [CobCod] = @CobCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H20", "SELECT [CCCliDsc] AS CobCliDsc, [CCCliCod] AS CobCliCod, [CCmonCod] AS CobMonOrigen FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CobTipCod AND [CCDocNum] = @CobDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H21", "SELECT [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] ORDER BY [CobTip], [CobCod], [Item]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002H21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H22", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002H23", "SELECT [BanCod] AS CobDBanCod FROM [TSBANCOS] WHERE [BanCod] = @CobDBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002H23,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 1);
              ((string[]) buf[12])[0] = rslt.getString(13, 12);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 3);
              ((string[]) buf[15])[0] = rslt.getString(16, 12);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((bool[]) buf[17])[0] = rslt.wasNull(17);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 1);
              ((string[]) buf[12])[0] = rslt.getString(13, 12);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 3);
              ((string[]) buf[15])[0] = rslt.getString(16, 12);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((bool[]) buf[17])[0] = rslt.wasNull(17);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((string[]) buf[14])[0] = rslt.getString(15, 12);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 3);
              ((string[]) buf[17])[0] = rslt.getString(18, 12);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((bool[]) buf[19])[0] = rslt.wasNull(19);
              ((string[]) buf[20])[0] = rslt.getString(20, 20);
              ((int[]) buf[21])[0] = rslt.getInt(21);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
