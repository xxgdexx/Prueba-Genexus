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
   public class clventas : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A149TipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = GetPar( "DocNum");
            n24DocNum = false;
            AssignAttri("", false, "A24DocNum", A24DocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A149TipCod, A24DocNum) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A231DocCliCod = GetPar( "DocCliCod");
            AssignAttri("", false, "A231DocCliCod", A231DocCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A231DocCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A230DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
            AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A230DocMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A229DocConpCod = (int)(NumberUtil.Val( GetPar( "DocConpCod"), "."));
            AssignAttri("", false, "A229DocConpCod", StringUtil.LTrimStr( (decimal)(A229DocConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A229DocConpCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A228DocLisp = (int)(NumberUtil.Val( GetPar( "DocLisp"), "."));
            n228DocLisp = false;
            AssignAttri("", false, "A228DocLisp", StringUtil.LTrimStr( (decimal)(A228DocLisp), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A228DocLisp) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A227DocVendCod = (int)(NumberUtil.Val( GetPar( "DocVendCod"), "."));
            AssignAttri("", false, "A227DocVendCod", StringUtil.LTrimStr( (decimal)(A227DocVendCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A227DocVendCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A226DocMovCod = (int)(NumberUtil.Val( GetPar( "DocMovCod"), "."));
            AssignAttri("", false, "A226DocMovCod", StringUtil.LTrimStr( (decimal)(A226DocMovCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A226DocMovCod) ;
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
            Form.Meta.addItem("description", "Ventas - Cabecera", 0) ;
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

      public clventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clventas( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLVENTAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Numero Doc.", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocNum_Internalname, StringUtil.RTrim( A24DocNum), StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "T/D", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipAbr_Internalname, StringUtil.RTrim( A306TipAbr), StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocFec_Internalname, context.localUtil.Format(A232DocFec, "99/99/99"), context.localUtil.Format( A232DocFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         GxWebStd.gx_bitmap( context, edtDocFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha Vcto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocFVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocFVcto_Internalname, context.localUtil.Format(A931DocFVcto, "99/99/9999"), context.localUtil.Format( A931DocFVcto, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocFVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocFVcto_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         GxWebStd.gx_bitmap( context, edtDocFVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocFVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo Cliente", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocCliCod_Internalname, StringUtil.RTrim( A231DocCliCod), StringUtil.RTrim( context.localUtil.Format( A231DocCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Razon Social", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocCliDsc_Internalname, StringUtil.RTrim( A887DocCliDsc), StringUtil.RTrim( context.localUtil.Format( A887DocCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Dirección", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocCliDir_Internalname, StringUtil.RTrim( A885DocCliDir), StringUtil.RTrim( context.localUtil.Format( A885DocCliDir, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocCliDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocCliDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cliente Direccion", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocCliDirItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A886DocCliDirItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocCliDirItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A886DocCliDirItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A886DocCliDirItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocCliDirItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocCliDirItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Codigo Moneda", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A230DocMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A230DocMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A230DocMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Codigo condicion pago", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A229DocConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A229DocConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A229DocConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Condicion de Pago", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocConpDsc_Internalname, StringUtil.RTrim( A888DocConpDsc), StringUtil.RTrim( context.localUtil.Format( A888DocConpDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Dias", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A904DocDias), 4, 0, ".", "")), StringUtil.LTrim( ((edtDocDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A904DocDias), "ZZZ9") : context.localUtil.Format( (decimal)(A904DocDias), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDias_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Codigo Tipo de Lista", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocLisp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A228DocLisp), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocLisp_Enabled!=0) ? context.localUtil.Format( (decimal)(A228DocLisp), "ZZZZZ9") : context.localUtil.Format( (decimal)(A228DocLisp), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocLisp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocLisp_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Sub Afecto", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocSubAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A920DocSubAfecto, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocSubAfecto_Enabled!=0) ? context.localUtil.Format( A920DocSubAfecto, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A920DocSubAfecto, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocSubAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocSubAfecto_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Sub Inafecto", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocSubInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A921DocSubInafecto, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocSubInafecto_Enabled!=0) ? context.localUtil.Format( A921DocSubInafecto, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A921DocSubInafecto, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocSubInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocSubInafecto_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "I.S.C.", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocSubSelectivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A922DocSubSelectivo, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocSubSelectivo_Enabled!=0) ? context.localUtil.Format( A922DocSubSelectivo, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A922DocSubSelectivo, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocSubSelectivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocSubSelectivo_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Anticipos", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocAnticipos_Internalname, StringUtil.LTrim( StringUtil.NToC( A882DocAnticipos, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocAnticipos_Enabled!=0) ? context.localUtil.Format( A882DocAnticipos, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A882DocAnticipos, "ZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocAnticipos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocAnticipos_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Descuento", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocDscto_Internalname, StringUtil.LTrim( StringUtil.NToC( A918DocDscto, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocDscto_Enabled!=0) ? context.localUtil.Format( A918DocDscto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A918DocDscto, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDscto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDscto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Sub Total", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocSub_Internalname, StringUtil.LTrim( StringUtil.NToC( A919DocSub, 15, 4, ".", "")), StringUtil.LTrim( ((edtDocSub_Enabled!=0) ? context.localUtil.Format( A919DocSub, "ZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A919DocSub, "ZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocSub_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocSub_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Redondeo", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocRedondeo_Internalname, StringUtil.LTrim( StringUtil.NToC( A935DocRedondeo, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocRedondeo_Enabled!=0) ? context.localUtil.Format( A935DocRedondeo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A935DocRedondeo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocRedondeo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocRedondeo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "% Descuento", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocDcto_Internalname, StringUtil.LTrim( StringUtil.NToC( A899DocDcto, 6, 2, ".", "")), StringUtil.LTrim( ((edtDocDcto_Enabled!=0) ? context.localUtil.Format( A899DocDcto, "ZZ9.99") : context.localUtil.Format( A899DocDcto, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocDcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocDcto_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "% I.G.V.", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocPorIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A934DocPorIVA, 6, 2, ".", "")), StringUtil.LTrim( ((edtDocPorIVA_Enabled!=0) ? context.localUtil.Format( A934DocPorIVA, "ZZ9.99") : context.localUtil.Format( A934DocPorIVA, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocPorIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocPorIVA_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "I.G.V.", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A933DocIVA, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocIVA_Enabled!=0) ? context.localUtil.Format( A933DocIVA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A933DocIVA, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocIVA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Total", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A948DocTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocTot_Enabled!=0) ? context.localUtil.Format( A948DocTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A948DocTot, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Observaciones", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocObs_Internalname, A936DocObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", 0, 1, edtDocObs_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Tipo Documento", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTRef_Internalname, StringUtil.RTrim( A950DocTRef), StringUtil.RTrim( context.localUtil.Format( A950DocTRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTRef_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Documento", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocRef_Internalname, StringUtil.RTrim( A939DocRef), StringUtil.RTrim( context.localUtil.Format( A939DocRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocRef_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Situación", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocSts_Internalname, StringUtil.RTrim( A941DocSts), StringUtil.RTrim( context.localUtil.Format( A941DocSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Total Items", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( A947DocTItem, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocTItem_Enabled!=0) ? context.localUtil.Format( A947DocTItem, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A947DocTItem, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTItem_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Pedido", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocPedCod_Internalname, StringUtil.RTrim( A937DocPedCod), StringUtil.RTrim( context.localUtil.Format( A937DocPedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Tipo de Venta", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTipo_Internalname, StringUtil.RTrim( A946DocTipo), StringUtil.RTrim( context.localUtil.Format( A946DocTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Fecha Referencia", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocFecRef_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocFecRef_Internalname, context.localUtil.Format(A929DocFecRef, "99/99/99"), context.localUtil.Format( A929DocFecRef, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocFecRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocFecRef_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         GxWebStd.gx_bitmap( context, edtDocFecRef_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocFecRef_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Almacen Venta Directa", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A880DocAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A880DocAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A880DocAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Vendedor", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocVendCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A227DocVendCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocVendCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A227DocVendCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A227DocVendCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocVendCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocVendCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Vendedor", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocVendDsc_Internalname, StringUtil.RTrim( A953DocVendDsc), StringUtil.RTrim( context.localUtil.Format( A953DocVendDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocVendDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocVendDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Centro de Costo", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocCosCod_Internalname, StringUtil.RTrim( A890DocCosCod), StringUtil.RTrim( context.localUtil.Format( A890DocCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Usuario", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocUsuCod_Internalname, StringUtil.RTrim( A951DocUsuCod), StringUtil.RTrim( context.localUtil.Format( A951DocUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Usuario Fecha", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDocUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDocUsuFec_Internalname, context.localUtil.TToC( A952DocUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A952DocUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         GxWebStd.gx_bitmap( context, edtDocUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDocUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Año", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A954DocVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtDocVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A954DocVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A954DocVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Mes", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A955DocVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtDocVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A955DocVouMes), "Z9") : context.localUtil.Format( (decimal)(A955DocVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,221);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "Tipo Asiento", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A944DocTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A944DocTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A944DocTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,226);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "N° Asiento", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocVouNum_Internalname, StringUtil.RTrim( A956DocVouNum), StringUtil.RTrim( context.localUtil.Format( A956DocVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,231);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "Codigo Movimiento", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A226DocMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtDocMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A226DocMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A226DocMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,236);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "Total Signo", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocTotSigno_Internalname, StringUtil.LTrim( StringUtil.NToC( A949DocTotSigno, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocTotSigno_Enabled!=0) ? context.localUtil.Format( A949DocTotSigno, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A949DocTotSigno, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTotSigno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTotSigno_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "N° Percepción", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocPercepcion_Internalname, StringUtil.RTrim( A938DocPercepcion), StringUtil.RTrim( context.localUtil.Format( A938DocPercepcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,246);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocPercepcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocPercepcion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock47_Internalname, "Aplica Anticipos", "", "", lblTextblock47_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocAplicaAnticipo_Internalname, StringUtil.LTrim( StringUtil.NToC( A883DocAplicaAnticipo, 17, 2, ".", "")), StringUtil.LTrim( ((edtDocAplicaAnticipo_Enabled!=0) ? context.localUtil.Format( A883DocAplicaAnticipo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A883DocAplicaAnticipo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,251);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocAplicaAnticipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocAplicaAnticipo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock48_Internalname, "N° Serie", "", "", lblTextblock48_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocSerie_Internalname, A940DocSerie, StringUtil.RTrim( context.localUtil.Format( A940DocSerie, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocSerie_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLVENTAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 259,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 260,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 261,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 262,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLVENTAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 263,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLVENTAS.htm");
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
            Z24DocNum = cgiGet( "Z24DocNum");
            Z232DocFec = context.localUtil.CToD( cgiGet( "Z232DocFec"), 0);
            Z931DocFVcto = context.localUtil.CToD( cgiGet( "Z931DocFVcto"), 0);
            Z886DocCliDirItem = (int)(context.localUtil.CToN( cgiGet( "Z886DocCliDirItem"), ".", ","));
            Z882DocAnticipos = context.localUtil.CToN( cgiGet( "Z882DocAnticipos"), ".", ",");
            Z935DocRedondeo = context.localUtil.CToN( cgiGet( "Z935DocRedondeo"), ".", ",");
            Z899DocDcto = context.localUtil.CToN( cgiGet( "Z899DocDcto"), ".", ",");
            Z934DocPorIVA = context.localUtil.CToN( cgiGet( "Z934DocPorIVA"), ".", ",");
            Z950DocTRef = cgiGet( "Z950DocTRef");
            Z939DocRef = cgiGet( "Z939DocRef");
            Z941DocSts = cgiGet( "Z941DocSts");
            Z947DocTItem = context.localUtil.CToN( cgiGet( "Z947DocTItem"), ".", ",");
            Z937DocPedCod = cgiGet( "Z937DocPedCod");
            Z946DocTipo = cgiGet( "Z946DocTipo");
            Z929DocFecRef = context.localUtil.CToD( cgiGet( "Z929DocFecRef"), 0);
            Z880DocAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z880DocAlmCod"), ".", ","));
            Z890DocCosCod = cgiGet( "Z890DocCosCod");
            n890DocCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A890DocCosCod)) ? true : false);
            Z951DocUsuCod = cgiGet( "Z951DocUsuCod");
            Z952DocUsuFec = context.localUtil.CToT( cgiGet( "Z952DocUsuFec"), 0);
            Z954DocVouAno = (short)(context.localUtil.CToN( cgiGet( "Z954DocVouAno"), ".", ","));
            Z955DocVouMes = (short)(context.localUtil.CToN( cgiGet( "Z955DocVouMes"), ".", ","));
            Z944DocTASICod = (int)(context.localUtil.CToN( cgiGet( "Z944DocTASICod"), ".", ","));
            Z956DocVouNum = cgiGet( "Z956DocVouNum");
            Z938DocPercepcion = cgiGet( "Z938DocPercepcion");
            n938DocPercepcion = (String.IsNullOrEmpty(StringUtil.RTrim( A938DocPercepcion)) ? true : false);
            Z883DocAplicaAnticipo = context.localUtil.CToN( cgiGet( "Z883DocAplicaAnticipo"), ".", ",");
            Z884DocCadena = cgiGet( "Z884DocCadena");
            n884DocCadena = (String.IsNullOrEmpty(StringUtil.RTrim( A884DocCadena)) ? true : false);
            Z930DocFEOBS = cgiGet( "Z930DocFEOBS");
            Z881DocAnticipo = cgiGet( "Z881DocAnticipo");
            Z945DocTipAnticipo = cgiGet( "Z945DocTipAnticipo");
            Z879DocAIVA = (short)(context.localUtil.CToN( cgiGet( "Z879DocAIVA"), ".", ","));
            Z178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
            n178TieCod = ((0==A178TieCod) ? true : false);
            Z231DocCliCod = cgiGet( "Z231DocCliCod");
            Z230DocMonCod = (int)(context.localUtil.CToN( cgiGet( "Z230DocMonCod"), ".", ","));
            Z229DocConpCod = (int)(context.localUtil.CToN( cgiGet( "Z229DocConpCod"), ".", ","));
            Z228DocLisp = (int)(context.localUtil.CToN( cgiGet( "Z228DocLisp"), ".", ","));
            n228DocLisp = ((0==A228DocLisp) ? true : false);
            Z227DocVendCod = (int)(context.localUtil.CToN( cgiGet( "Z227DocVendCod"), ".", ","));
            Z226DocMovCod = (int)(context.localUtil.CToN( cgiGet( "Z226DocMovCod"), ".", ","));
            A884DocCadena = cgiGet( "Z884DocCadena");
            n884DocCadena = false;
            n884DocCadena = (String.IsNullOrEmpty(StringUtil.RTrim( A884DocCadena)) ? true : false);
            A930DocFEOBS = cgiGet( "Z930DocFEOBS");
            n930DocFEOBS = false;
            A881DocAnticipo = cgiGet( "Z881DocAnticipo");
            A945DocTipAnticipo = cgiGet( "Z945DocTipAnticipo");
            A879DocAIVA = (short)(context.localUtil.CToN( cgiGet( "Z879DocAIVA"), ".", ","));
            A178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
            n178TieCod = false;
            n178TieCod = ((0==A178TieCod) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A927DocSubExonerado = context.localUtil.CToN( cgiGet( "DOCSUBEXONERADO"), ".", ",");
            A932DocICBPER = context.localUtil.CToN( cgiGet( "DOCICBPER"), ".", ",");
            A511TipSigno = (short)(context.localUtil.CToN( cgiGet( "TIPSIGNO"), ".", ","));
            A884DocCadena = cgiGet( "DOCCADENA");
            n884DocCadena = (String.IsNullOrEmpty(StringUtil.RTrim( A884DocCadena)) ? true : false);
            A930DocFEOBS = cgiGet( "DOCFEOBS");
            A881DocAnticipo = cgiGet( "DOCANTICIPO");
            A945DocTipAnticipo = cgiGet( "DOCTIPANTICIPO");
            A879DocAIVA = (short)(context.localUtil.CToN( cgiGet( "DOCAIVA"), ".", ","));
            A178TieCod = (int)(context.localUtil.CToN( cgiGet( "TIECOD"), ".", ","));
            n178TieCod = ((0==A178TieCod) ? true : false);
            A943DocSubGratuitoIna = context.localUtil.CToN( cgiGet( "DOCSUBGRATUITOINA"), ".", ",");
            A942DocSubGratuito = context.localUtil.CToN( cgiGet( "DOCSUBGRATUITO"), ".", ",");
            /* Read variables values. */
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = cgiGet( edtDocNum_Internalname);
            n24DocNum = false;
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A306TipAbr = cgiGet( edtTipAbr_Internalname);
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            if ( context.localUtil.VCDate( cgiGet( edtDocFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "DOCFEC");
               AnyError = 1;
               GX_FocusControl = edtDocFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A232DocFec = DateTime.MinValue;
               AssignAttri("", false, "A232DocFec", context.localUtil.Format(A232DocFec, "99/99/99"));
            }
            else
            {
               A232DocFec = context.localUtil.CToD( cgiGet( edtDocFec_Internalname), 2);
               AssignAttri("", false, "A232DocFec", context.localUtil.Format(A232DocFec, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtDocFVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "DOCFVCTO");
               AnyError = 1;
               GX_FocusControl = edtDocFVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A931DocFVcto = DateTime.MinValue;
               AssignAttri("", false, "A931DocFVcto", context.localUtil.Format(A931DocFVcto, "99/99/9999"));
            }
            else
            {
               A931DocFVcto = context.localUtil.CToD( cgiGet( edtDocFVcto_Internalname), 2);
               AssignAttri("", false, "A931DocFVcto", context.localUtil.Format(A931DocFVcto, "99/99/9999"));
            }
            A231DocCliCod = cgiGet( edtDocCliCod_Internalname);
            AssignAttri("", false, "A231DocCliCod", A231DocCliCod);
            A887DocCliDsc = cgiGet( edtDocCliDsc_Internalname);
            AssignAttri("", false, "A887DocCliDsc", A887DocCliDsc);
            A885DocCliDir = cgiGet( edtDocCliDir_Internalname);
            AssignAttri("", false, "A885DocCliDir", A885DocCliDir);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocCliDirItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocCliDirItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCCLIDIRITEM");
               AnyError = 1;
               GX_FocusControl = edtDocCliDirItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A886DocCliDirItem = 0;
               AssignAttri("", false, "A886DocCliDirItem", StringUtil.LTrimStr( (decimal)(A886DocCliDirItem), 6, 0));
            }
            else
            {
               A886DocCliDirItem = (int)(context.localUtil.CToN( cgiGet( edtDocCliDirItem_Internalname), ".", ","));
               AssignAttri("", false, "A886DocCliDirItem", StringUtil.LTrimStr( (decimal)(A886DocCliDirItem), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCMONCOD");
               AnyError = 1;
               GX_FocusControl = edtDocMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A230DocMonCod = 0;
               AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
            }
            else
            {
               A230DocMonCod = (int)(context.localUtil.CToN( cgiGet( edtDocMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtDocConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A229DocConpCod = 0;
               AssignAttri("", false, "A229DocConpCod", StringUtil.LTrimStr( (decimal)(A229DocConpCod), 6, 0));
            }
            else
            {
               A229DocConpCod = (int)(context.localUtil.CToN( cgiGet( edtDocConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A229DocConpCod", StringUtil.LTrimStr( (decimal)(A229DocConpCod), 6, 0));
            }
            A888DocConpDsc = cgiGet( edtDocConpDsc_Internalname);
            AssignAttri("", false, "A888DocConpDsc", A888DocConpDsc);
            A904DocDias = (short)(context.localUtil.CToN( cgiGet( edtDocDias_Internalname), ".", ","));
            AssignAttri("", false, "A904DocDias", StringUtil.LTrimStr( (decimal)(A904DocDias), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocLisp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocLisp_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCLISP");
               AnyError = 1;
               GX_FocusControl = edtDocLisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A228DocLisp = 0;
               n228DocLisp = false;
               AssignAttri("", false, "A228DocLisp", StringUtil.LTrimStr( (decimal)(A228DocLisp), 6, 0));
            }
            else
            {
               A228DocLisp = (int)(context.localUtil.CToN( cgiGet( edtDocLisp_Internalname), ".", ","));
               n228DocLisp = false;
               AssignAttri("", false, "A228DocLisp", StringUtil.LTrimStr( (decimal)(A228DocLisp), 6, 0));
            }
            n228DocLisp = ((0==A228DocLisp) ? true : false);
            A920DocSubAfecto = context.localUtil.CToN( cgiGet( edtDocSubAfecto_Internalname), ".", ",");
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = context.localUtil.CToN( cgiGet( edtDocSubInafecto_Internalname), ".", ",");
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = context.localUtil.CToN( cgiGet( edtDocSubSelectivo_Internalname), ".", ",");
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocAnticipos_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDocAnticipos_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCANTICIPOS");
               AnyError = 1;
               GX_FocusControl = edtDocAnticipos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A882DocAnticipos = 0;
               AssignAttri("", false, "A882DocAnticipos", StringUtil.LTrimStr( A882DocAnticipos, 15, 4));
            }
            else
            {
               A882DocAnticipos = context.localUtil.CToN( cgiGet( edtDocAnticipos_Internalname), ".", ",");
               AssignAttri("", false, "A882DocAnticipos", StringUtil.LTrimStr( A882DocAnticipos, 15, 4));
            }
            A918DocDscto = context.localUtil.CToN( cgiGet( edtDocDscto_Internalname), ".", ",");
            AssignAttri("", false, "A918DocDscto", StringUtil.LTrimStr( A918DocDscto, 15, 2));
            A919DocSub = context.localUtil.CToN( cgiGet( edtDocSub_Internalname), ".", ",");
            AssignAttri("", false, "A919DocSub", StringUtil.LTrimStr( A919DocSub, 15, 4));
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocRedondeo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDocRedondeo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCREDONDEO");
               AnyError = 1;
               GX_FocusControl = edtDocRedondeo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A935DocRedondeo = 0;
               AssignAttri("", false, "A935DocRedondeo", StringUtil.LTrimStr( A935DocRedondeo, 15, 2));
            }
            else
            {
               A935DocRedondeo = context.localUtil.CToN( cgiGet( edtDocRedondeo_Internalname), ".", ",");
               AssignAttri("", false, "A935DocRedondeo", StringUtil.LTrimStr( A935DocRedondeo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocDcto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocDcto_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCDCTO");
               AnyError = 1;
               GX_FocusControl = edtDocDcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A899DocDcto = 0;
               AssignAttri("", false, "A899DocDcto", StringUtil.LTrimStr( A899DocDcto, 6, 2));
            }
            else
            {
               A899DocDcto = context.localUtil.CToN( cgiGet( edtDocDcto_Internalname), ".", ",");
               AssignAttri("", false, "A899DocDcto", StringUtil.LTrimStr( A899DocDcto, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocPorIVA_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocPorIVA_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCPORIVA");
               AnyError = 1;
               GX_FocusControl = edtDocPorIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A934DocPorIVA = 0;
               AssignAttri("", false, "A934DocPorIVA", StringUtil.LTrimStr( A934DocPorIVA, 6, 2));
            }
            else
            {
               A934DocPorIVA = context.localUtil.CToN( cgiGet( edtDocPorIVA_Internalname), ".", ",");
               AssignAttri("", false, "A934DocPorIVA", StringUtil.LTrimStr( A934DocPorIVA, 6, 2));
            }
            A933DocIVA = context.localUtil.CToN( cgiGet( edtDocIVA_Internalname), ".", ",");
            AssignAttri("", false, "A933DocIVA", StringUtil.LTrimStr( A933DocIVA, 15, 2));
            A948DocTot = context.localUtil.CToN( cgiGet( edtDocTot_Internalname), ".", ",");
            AssignAttri("", false, "A948DocTot", StringUtil.LTrimStr( A948DocTot, 15, 2));
            A936DocObs = cgiGet( edtDocObs_Internalname);
            AssignAttri("", false, "A936DocObs", A936DocObs);
            A950DocTRef = cgiGet( edtDocTRef_Internalname);
            AssignAttri("", false, "A950DocTRef", A950DocTRef);
            A939DocRef = cgiGet( edtDocRef_Internalname);
            AssignAttri("", false, "A939DocRef", A939DocRef);
            A941DocSts = cgiGet( edtDocSts_Internalname);
            AssignAttri("", false, "A941DocSts", A941DocSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocTItem_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDocTItem_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCTITEM");
               AnyError = 1;
               GX_FocusControl = edtDocTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A947DocTItem = 0;
               AssignAttri("", false, "A947DocTItem", StringUtil.LTrimStr( A947DocTItem, 15, 2));
            }
            else
            {
               A947DocTItem = context.localUtil.CToN( cgiGet( edtDocTItem_Internalname), ".", ",");
               AssignAttri("", false, "A947DocTItem", StringUtil.LTrimStr( A947DocTItem, 15, 2));
            }
            A937DocPedCod = cgiGet( edtDocPedCod_Internalname);
            AssignAttri("", false, "A937DocPedCod", A937DocPedCod);
            A946DocTipo = cgiGet( edtDocTipo_Internalname);
            AssignAttri("", false, "A946DocTipo", A946DocTipo);
            if ( context.localUtil.VCDate( cgiGet( edtDocFecRef_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Referencia"}), 1, "DOCFECREF");
               AnyError = 1;
               GX_FocusControl = edtDocFecRef_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A929DocFecRef = DateTime.MinValue;
               AssignAttri("", false, "A929DocFecRef", context.localUtil.Format(A929DocFecRef, "99/99/99"));
            }
            else
            {
               A929DocFecRef = context.localUtil.CToD( cgiGet( edtDocFecRef_Internalname), 2);
               AssignAttri("", false, "A929DocFecRef", context.localUtil.Format(A929DocFecRef, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCALMCOD");
               AnyError = 1;
               GX_FocusControl = edtDocAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A880DocAlmCod = 0;
               AssignAttri("", false, "A880DocAlmCod", StringUtil.LTrimStr( (decimal)(A880DocAlmCod), 6, 0));
            }
            else
            {
               A880DocAlmCod = (int)(context.localUtil.CToN( cgiGet( edtDocAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A880DocAlmCod", StringUtil.LTrimStr( (decimal)(A880DocAlmCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocVendCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocVendCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCVENDCOD");
               AnyError = 1;
               GX_FocusControl = edtDocVendCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A227DocVendCod = 0;
               AssignAttri("", false, "A227DocVendCod", StringUtil.LTrimStr( (decimal)(A227DocVendCod), 6, 0));
            }
            else
            {
               A227DocVendCod = (int)(context.localUtil.CToN( cgiGet( edtDocVendCod_Internalname), ".", ","));
               AssignAttri("", false, "A227DocVendCod", StringUtil.LTrimStr( (decimal)(A227DocVendCod), 6, 0));
            }
            A953DocVendDsc = cgiGet( edtDocVendDsc_Internalname);
            AssignAttri("", false, "A953DocVendDsc", A953DocVendDsc);
            A890DocCosCod = cgiGet( edtDocCosCod_Internalname);
            n890DocCosCod = false;
            AssignAttri("", false, "A890DocCosCod", A890DocCosCod);
            n890DocCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A890DocCosCod)) ? true : false);
            A951DocUsuCod = cgiGet( edtDocUsuCod_Internalname);
            AssignAttri("", false, "A951DocUsuCod", A951DocUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtDocUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "DOCUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtDocUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A952DocUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A952DocUsuFec", context.localUtil.TToC( A952DocUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A952DocUsuFec = context.localUtil.CToT( cgiGet( edtDocUsuFec_Internalname));
               AssignAttri("", false, "A952DocUsuFec", context.localUtil.TToC( A952DocUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCVOUANO");
               AnyError = 1;
               GX_FocusControl = edtDocVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A954DocVouAno = 0;
               AssignAttri("", false, "A954DocVouAno", StringUtil.LTrimStr( (decimal)(A954DocVouAno), 4, 0));
            }
            else
            {
               A954DocVouAno = (short)(context.localUtil.CToN( cgiGet( edtDocVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A954DocVouAno", StringUtil.LTrimStr( (decimal)(A954DocVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCVOUMES");
               AnyError = 1;
               GX_FocusControl = edtDocVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A955DocVouMes = 0;
               AssignAttri("", false, "A955DocVouMes", StringUtil.LTrimStr( (decimal)(A955DocVouMes), 2, 0));
            }
            else
            {
               A955DocVouMes = (short)(context.localUtil.CToN( cgiGet( edtDocVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A955DocVouMes", StringUtil.LTrimStr( (decimal)(A955DocVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCTASICOD");
               AnyError = 1;
               GX_FocusControl = edtDocTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A944DocTASICod = 0;
               AssignAttri("", false, "A944DocTASICod", StringUtil.LTrimStr( (decimal)(A944DocTASICod), 6, 0));
            }
            else
            {
               A944DocTASICod = (int)(context.localUtil.CToN( cgiGet( edtDocTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A944DocTASICod", StringUtil.LTrimStr( (decimal)(A944DocTASICod), 6, 0));
            }
            A956DocVouNum = cgiGet( edtDocVouNum_Internalname);
            AssignAttri("", false, "A956DocVouNum", A956DocVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtDocMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A226DocMovCod = 0;
               AssignAttri("", false, "A226DocMovCod", StringUtil.LTrimStr( (decimal)(A226DocMovCod), 6, 0));
            }
            else
            {
               A226DocMovCod = (int)(context.localUtil.CToN( cgiGet( edtDocMovCod_Internalname), ".", ","));
               AssignAttri("", false, "A226DocMovCod", StringUtil.LTrimStr( (decimal)(A226DocMovCod), 6, 0));
            }
            A949DocTotSigno = context.localUtil.CToN( cgiGet( edtDocTotSigno_Internalname), ".", ",");
            AssignAttri("", false, "A949DocTotSigno", StringUtil.LTrimStr( A949DocTotSigno, 15, 2));
            A938DocPercepcion = cgiGet( edtDocPercepcion_Internalname);
            n938DocPercepcion = false;
            AssignAttri("", false, "A938DocPercepcion", A938DocPercepcion);
            n938DocPercepcion = (String.IsNullOrEmpty(StringUtil.RTrim( A938DocPercepcion)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocAplicaAnticipo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtDocAplicaAnticipo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCAPLICAANTICIPO");
               AnyError = 1;
               GX_FocusControl = edtDocAplicaAnticipo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A883DocAplicaAnticipo = 0;
               AssignAttri("", false, "A883DocAplicaAnticipo", StringUtil.LTrimStr( A883DocAplicaAnticipo, 15, 2));
            }
            else
            {
               A883DocAplicaAnticipo = context.localUtil.CToN( cgiGet( edtDocAplicaAnticipo_Internalname), ".", ",");
               AssignAttri("", false, "A883DocAplicaAnticipo", StringUtil.LTrimStr( A883DocAplicaAnticipo, 15, 2));
            }
            A940DocSerie = cgiGet( edtDocSerie_Internalname);
            AssignAttri("", false, "A940DocSerie", A940DocSerie);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLVENTAS");
            forbiddenHiddens.Add("DocCadena", StringUtil.RTrim( context.localUtil.Format( A884DocCadena, "")));
            forbiddenHiddens.Add("TieCod", context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"));
            forbiddenHiddens.Add("DocFEOBS", StringUtil.RTrim( context.localUtil.Format( A930DocFEOBS, "")));
            forbiddenHiddens.Add("DocAnticipo", StringUtil.RTrim( context.localUtil.Format( A881DocAnticipo, "")));
            forbiddenHiddens.Add("DocTipAnticipo", StringUtil.RTrim( context.localUtil.Format( A945DocTipAnticipo, "")));
            forbiddenHiddens.Add("DocAIVA", context.localUtil.Format( (decimal)(A879DocAIVA), "9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clventas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A24DocNum = GetPar( "DocNum");
               n24DocNum = false;
               AssignAttri("", false, "A24DocNum", A24DocNum);
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
               InitAll2Y101( ) ;
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
         DisableAttributes2Y101( ) ;
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

      protected void CONFIRM_2Y0( )
      {
         BeforeValidate2Y101( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Y101( ) ;
            }
            else
            {
               CheckExtendedTable2Y101( ) ;
               if ( AnyError == 0 )
               {
                  ZM2Y101( 12) ;
                  ZM2Y101( 13) ;
                  ZM2Y101( 14) ;
                  ZM2Y101( 15) ;
                  ZM2Y101( 16) ;
                  ZM2Y101( 17) ;
                  ZM2Y101( 18) ;
                  ZM2Y101( 19) ;
                  ZM2Y101( 20) ;
               }
               CloseExtendedTableCursors2Y101( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2Y0( ) ;
         }
      }

      protected void ResetCaption2Y0( )
      {
      }

      protected void ZM2Y101( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z232DocFec = T002Y3_A232DocFec[0];
               Z931DocFVcto = T002Y3_A931DocFVcto[0];
               Z886DocCliDirItem = T002Y3_A886DocCliDirItem[0];
               Z882DocAnticipos = T002Y3_A882DocAnticipos[0];
               Z935DocRedondeo = T002Y3_A935DocRedondeo[0];
               Z899DocDcto = T002Y3_A899DocDcto[0];
               Z934DocPorIVA = T002Y3_A934DocPorIVA[0];
               Z950DocTRef = T002Y3_A950DocTRef[0];
               Z939DocRef = T002Y3_A939DocRef[0];
               Z941DocSts = T002Y3_A941DocSts[0];
               Z947DocTItem = T002Y3_A947DocTItem[0];
               Z937DocPedCod = T002Y3_A937DocPedCod[0];
               Z946DocTipo = T002Y3_A946DocTipo[0];
               Z929DocFecRef = T002Y3_A929DocFecRef[0];
               Z880DocAlmCod = T002Y3_A880DocAlmCod[0];
               Z890DocCosCod = T002Y3_A890DocCosCod[0];
               Z951DocUsuCod = T002Y3_A951DocUsuCod[0];
               Z952DocUsuFec = T002Y3_A952DocUsuFec[0];
               Z954DocVouAno = T002Y3_A954DocVouAno[0];
               Z955DocVouMes = T002Y3_A955DocVouMes[0];
               Z944DocTASICod = T002Y3_A944DocTASICod[0];
               Z956DocVouNum = T002Y3_A956DocVouNum[0];
               Z938DocPercepcion = T002Y3_A938DocPercepcion[0];
               Z883DocAplicaAnticipo = T002Y3_A883DocAplicaAnticipo[0];
               Z884DocCadena = T002Y3_A884DocCadena[0];
               Z930DocFEOBS = T002Y3_A930DocFEOBS[0];
               Z881DocAnticipo = T002Y3_A881DocAnticipo[0];
               Z945DocTipAnticipo = T002Y3_A945DocTipAnticipo[0];
               Z879DocAIVA = T002Y3_A879DocAIVA[0];
               Z178TieCod = T002Y3_A178TieCod[0];
               Z231DocCliCod = T002Y3_A231DocCliCod[0];
               Z230DocMonCod = T002Y3_A230DocMonCod[0];
               Z229DocConpCod = T002Y3_A229DocConpCod[0];
               Z228DocLisp = T002Y3_A228DocLisp[0];
               Z227DocVendCod = T002Y3_A227DocVendCod[0];
               Z226DocMovCod = T002Y3_A226DocMovCod[0];
            }
            else
            {
               Z232DocFec = A232DocFec;
               Z931DocFVcto = A931DocFVcto;
               Z886DocCliDirItem = A886DocCliDirItem;
               Z882DocAnticipos = A882DocAnticipos;
               Z935DocRedondeo = A935DocRedondeo;
               Z899DocDcto = A899DocDcto;
               Z934DocPorIVA = A934DocPorIVA;
               Z950DocTRef = A950DocTRef;
               Z939DocRef = A939DocRef;
               Z941DocSts = A941DocSts;
               Z947DocTItem = A947DocTItem;
               Z937DocPedCod = A937DocPedCod;
               Z946DocTipo = A946DocTipo;
               Z929DocFecRef = A929DocFecRef;
               Z880DocAlmCod = A880DocAlmCod;
               Z890DocCosCod = A890DocCosCod;
               Z951DocUsuCod = A951DocUsuCod;
               Z952DocUsuFec = A952DocUsuFec;
               Z954DocVouAno = A954DocVouAno;
               Z955DocVouMes = A955DocVouMes;
               Z944DocTASICod = A944DocTASICod;
               Z956DocVouNum = A956DocVouNum;
               Z938DocPercepcion = A938DocPercepcion;
               Z883DocAplicaAnticipo = A883DocAplicaAnticipo;
               Z884DocCadena = A884DocCadena;
               Z930DocFEOBS = A930DocFEOBS;
               Z881DocAnticipo = A881DocAnticipo;
               Z945DocTipAnticipo = A945DocTipAnticipo;
               Z879DocAIVA = A879DocAIVA;
               Z178TieCod = A178TieCod;
               Z231DocCliCod = A231DocCliCod;
               Z230DocMonCod = A230DocMonCod;
               Z229DocConpCod = A229DocConpCod;
               Z228DocLisp = A228DocLisp;
               Z227DocVendCod = A227DocVendCod;
               Z226DocMovCod = A226DocMovCod;
            }
         }
         if ( GX_JID == -11 )
         {
            Z24DocNum = A24DocNum;
            Z232DocFec = A232DocFec;
            Z931DocFVcto = A931DocFVcto;
            Z886DocCliDirItem = A886DocCliDirItem;
            Z882DocAnticipos = A882DocAnticipos;
            Z935DocRedondeo = A935DocRedondeo;
            Z899DocDcto = A899DocDcto;
            Z934DocPorIVA = A934DocPorIVA;
            Z936DocObs = A936DocObs;
            Z950DocTRef = A950DocTRef;
            Z939DocRef = A939DocRef;
            Z941DocSts = A941DocSts;
            Z947DocTItem = A947DocTItem;
            Z937DocPedCod = A937DocPedCod;
            Z946DocTipo = A946DocTipo;
            Z929DocFecRef = A929DocFecRef;
            Z880DocAlmCod = A880DocAlmCod;
            Z890DocCosCod = A890DocCosCod;
            Z951DocUsuCod = A951DocUsuCod;
            Z952DocUsuFec = A952DocUsuFec;
            Z954DocVouAno = A954DocVouAno;
            Z955DocVouMes = A955DocVouMes;
            Z944DocTASICod = A944DocTASICod;
            Z956DocVouNum = A956DocVouNum;
            Z938DocPercepcion = A938DocPercepcion;
            Z883DocAplicaAnticipo = A883DocAplicaAnticipo;
            Z884DocCadena = A884DocCadena;
            Z930DocFEOBS = A930DocFEOBS;
            Z881DocAnticipo = A881DocAnticipo;
            Z945DocTipAnticipo = A945DocTipAnticipo;
            Z879DocAIVA = A879DocAIVA;
            Z149TipCod = A149TipCod;
            Z178TieCod = A178TieCod;
            Z231DocCliCod = A231DocCliCod;
            Z230DocMonCod = A230DocMonCod;
            Z229DocConpCod = A229DocConpCod;
            Z228DocLisp = A228DocLisp;
            Z227DocVendCod = A227DocVendCod;
            Z226DocMovCod = A226DocMovCod;
            Z306TipAbr = A306TipAbr;
            Z511TipSigno = A511TipSigno;
            Z932DocICBPER = A932DocICBPER;
            Z920DocSubAfecto = A920DocSubAfecto;
            Z921DocSubInafecto = A921DocSubInafecto;
            Z922DocSubSelectivo = A922DocSubSelectivo;
            Z927DocSubExonerado = A927DocSubExonerado;
            Z943DocSubGratuitoIna = A943DocSubGratuitoIna;
            Z942DocSubGratuito = A942DocSubGratuito;
            Z887DocCliDsc = A887DocCliDsc;
            Z885DocCliDir = A885DocCliDir;
            Z888DocConpDsc = A888DocConpDsc;
            Z904DocDias = A904DocDias;
            Z953DocVendDsc = A953DocVendDsc;
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
         /* Using cursor T002Y5 */
         pr_default.execute(3, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A178TieCod) ) )
            {
               GX_msglist.addItem("No existe 'Tiendas'.", "ForeignKeyNotFound", 1, "TIECOD");
               AnyError = 1;
            }
         }
         pr_default.close(3);
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

      protected void Load2Y101( )
      {
         /* Using cursor T002Y15 */
         pr_default.execute(11, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound101 = 1;
            A306TipAbr = T002Y15_A306TipAbr[0];
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            A232DocFec = T002Y15_A232DocFec[0];
            AssignAttri("", false, "A232DocFec", context.localUtil.Format(A232DocFec, "99/99/99"));
            A931DocFVcto = T002Y15_A931DocFVcto[0];
            AssignAttri("", false, "A931DocFVcto", context.localUtil.Format(A931DocFVcto, "99/99/9999"));
            A887DocCliDsc = T002Y15_A887DocCliDsc[0];
            AssignAttri("", false, "A887DocCliDsc", A887DocCliDsc);
            A885DocCliDir = T002Y15_A885DocCliDir[0];
            AssignAttri("", false, "A885DocCliDir", A885DocCliDir);
            A886DocCliDirItem = T002Y15_A886DocCliDirItem[0];
            AssignAttri("", false, "A886DocCliDirItem", StringUtil.LTrimStr( (decimal)(A886DocCliDirItem), 6, 0));
            A888DocConpDsc = T002Y15_A888DocConpDsc[0];
            AssignAttri("", false, "A888DocConpDsc", A888DocConpDsc);
            A904DocDias = T002Y15_A904DocDias[0];
            AssignAttri("", false, "A904DocDias", StringUtil.LTrimStr( (decimal)(A904DocDias), 4, 0));
            A882DocAnticipos = T002Y15_A882DocAnticipos[0];
            AssignAttri("", false, "A882DocAnticipos", StringUtil.LTrimStr( A882DocAnticipos, 15, 4));
            A935DocRedondeo = T002Y15_A935DocRedondeo[0];
            AssignAttri("", false, "A935DocRedondeo", StringUtil.LTrimStr( A935DocRedondeo, 15, 2));
            A899DocDcto = T002Y15_A899DocDcto[0];
            AssignAttri("", false, "A899DocDcto", StringUtil.LTrimStr( A899DocDcto, 6, 2));
            A934DocPorIVA = T002Y15_A934DocPorIVA[0];
            AssignAttri("", false, "A934DocPorIVA", StringUtil.LTrimStr( A934DocPorIVA, 6, 2));
            A936DocObs = T002Y15_A936DocObs[0];
            AssignAttri("", false, "A936DocObs", A936DocObs);
            A950DocTRef = T002Y15_A950DocTRef[0];
            AssignAttri("", false, "A950DocTRef", A950DocTRef);
            A939DocRef = T002Y15_A939DocRef[0];
            AssignAttri("", false, "A939DocRef", A939DocRef);
            A941DocSts = T002Y15_A941DocSts[0];
            AssignAttri("", false, "A941DocSts", A941DocSts);
            A947DocTItem = T002Y15_A947DocTItem[0];
            AssignAttri("", false, "A947DocTItem", StringUtil.LTrimStr( A947DocTItem, 15, 2));
            A937DocPedCod = T002Y15_A937DocPedCod[0];
            AssignAttri("", false, "A937DocPedCod", A937DocPedCod);
            A946DocTipo = T002Y15_A946DocTipo[0];
            AssignAttri("", false, "A946DocTipo", A946DocTipo);
            A929DocFecRef = T002Y15_A929DocFecRef[0];
            AssignAttri("", false, "A929DocFecRef", context.localUtil.Format(A929DocFecRef, "99/99/99"));
            A880DocAlmCod = T002Y15_A880DocAlmCod[0];
            AssignAttri("", false, "A880DocAlmCod", StringUtil.LTrimStr( (decimal)(A880DocAlmCod), 6, 0));
            A953DocVendDsc = T002Y15_A953DocVendDsc[0];
            AssignAttri("", false, "A953DocVendDsc", A953DocVendDsc);
            A890DocCosCod = T002Y15_A890DocCosCod[0];
            n890DocCosCod = T002Y15_n890DocCosCod[0];
            AssignAttri("", false, "A890DocCosCod", A890DocCosCod);
            A951DocUsuCod = T002Y15_A951DocUsuCod[0];
            AssignAttri("", false, "A951DocUsuCod", A951DocUsuCod);
            A952DocUsuFec = T002Y15_A952DocUsuFec[0];
            AssignAttri("", false, "A952DocUsuFec", context.localUtil.TToC( A952DocUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A954DocVouAno = T002Y15_A954DocVouAno[0];
            AssignAttri("", false, "A954DocVouAno", StringUtil.LTrimStr( (decimal)(A954DocVouAno), 4, 0));
            A955DocVouMes = T002Y15_A955DocVouMes[0];
            AssignAttri("", false, "A955DocVouMes", StringUtil.LTrimStr( (decimal)(A955DocVouMes), 2, 0));
            A944DocTASICod = T002Y15_A944DocTASICod[0];
            AssignAttri("", false, "A944DocTASICod", StringUtil.LTrimStr( (decimal)(A944DocTASICod), 6, 0));
            A956DocVouNum = T002Y15_A956DocVouNum[0];
            AssignAttri("", false, "A956DocVouNum", A956DocVouNum);
            A938DocPercepcion = T002Y15_A938DocPercepcion[0];
            n938DocPercepcion = T002Y15_n938DocPercepcion[0];
            AssignAttri("", false, "A938DocPercepcion", A938DocPercepcion);
            A883DocAplicaAnticipo = T002Y15_A883DocAplicaAnticipo[0];
            AssignAttri("", false, "A883DocAplicaAnticipo", StringUtil.LTrimStr( A883DocAplicaAnticipo, 15, 2));
            A884DocCadena = T002Y15_A884DocCadena[0];
            n884DocCadena = T002Y15_n884DocCadena[0];
            A930DocFEOBS = T002Y15_A930DocFEOBS[0];
            n930DocFEOBS = T002Y15_n930DocFEOBS[0];
            A881DocAnticipo = T002Y15_A881DocAnticipo[0];
            A945DocTipAnticipo = T002Y15_A945DocTipAnticipo[0];
            A879DocAIVA = T002Y15_A879DocAIVA[0];
            A511TipSigno = T002Y15_A511TipSigno[0];
            A178TieCod = T002Y15_A178TieCod[0];
            n178TieCod = T002Y15_n178TieCod[0];
            A231DocCliCod = T002Y15_A231DocCliCod[0];
            AssignAttri("", false, "A231DocCliCod", A231DocCliCod);
            A230DocMonCod = T002Y15_A230DocMonCod[0];
            AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
            A229DocConpCod = T002Y15_A229DocConpCod[0];
            AssignAttri("", false, "A229DocConpCod", StringUtil.LTrimStr( (decimal)(A229DocConpCod), 6, 0));
            A228DocLisp = T002Y15_A228DocLisp[0];
            n228DocLisp = T002Y15_n228DocLisp[0];
            AssignAttri("", false, "A228DocLisp", StringUtil.LTrimStr( (decimal)(A228DocLisp), 6, 0));
            A227DocVendCod = T002Y15_A227DocVendCod[0];
            AssignAttri("", false, "A227DocVendCod", StringUtil.LTrimStr( (decimal)(A227DocVendCod), 6, 0));
            A226DocMovCod = T002Y15_A226DocMovCod[0];
            AssignAttri("", false, "A226DocMovCod", StringUtil.LTrimStr( (decimal)(A226DocMovCod), 6, 0));
            A932DocICBPER = T002Y15_A932DocICBPER[0];
            A920DocSubAfecto = T002Y15_A920DocSubAfecto[0];
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = T002Y15_A921DocSubInafecto[0];
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = T002Y15_A922DocSubSelectivo[0];
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            A927DocSubExonerado = T002Y15_A927DocSubExonerado[0];
            A943DocSubGratuitoIna = T002Y15_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = T002Y15_A942DocSubGratuito[0];
            ZM2Y101( -11) ;
         }
         pr_default.close(11);
         OnLoadActions2Y101( ) ;
      }

      protected void OnLoadActions2Y101( )
      {
         A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
         AssignAttri("", false, "A919DocSub", StringUtil.LTrimStr( A919DocSub, 15, 4));
         A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
         AssignAttri("", false, "A918DocDscto", StringUtil.LTrimStr( A918DocDscto, 15, 2));
         A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
         AssignAttri("", false, "A933DocIVA", StringUtil.LTrimStr( A933DocIVA, 15, 2));
         A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
         AssignAttri("", false, "A948DocTot", StringUtil.LTrimStr( A948DocTot, 15, 2));
         A949DocTotSigno = (decimal)(A948DocTot*A511TipSigno);
         AssignAttri("", false, "A949DocTotSigno", StringUtil.LTrimStr( A949DocTotSigno, 15, 2));
         A940DocSerie = StringUtil.Substring( A24DocNum, 1, 3);
         AssignAttri("", false, "A940DocSerie", A940DocSerie);
      }

      protected void CheckExtendedTable2Y101( )
      {
         nIsDirty_101 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002Y4 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A306TipAbr = T002Y4_A306TipAbr[0];
         AssignAttri("", false, "A306TipAbr", A306TipAbr);
         A511TipSigno = T002Y4_A511TipSigno[0];
         pr_default.close(2);
         /* Using cursor T002Y13 */
         pr_default.execute(10, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A932DocICBPER = T002Y13_A932DocICBPER[0];
            A920DocSubAfecto = T002Y13_A920DocSubAfecto[0];
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = T002Y13_A921DocSubInafecto[0];
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = T002Y13_A922DocSubSelectivo[0];
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            A927DocSubExonerado = T002Y13_A927DocSubExonerado[0];
            A943DocSubGratuitoIna = T002Y13_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = T002Y13_A942DocSubGratuito[0];
         }
         else
         {
            nIsDirty_101 = 1;
            A932DocICBPER = 0;
            AssignAttri("", false, "A932DocICBPER", StringUtil.LTrimStr( A932DocICBPER, 15, 2));
            nIsDirty_101 = 1;
            A920DocSubAfecto = 0;
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            nIsDirty_101 = 1;
            A921DocSubInafecto = 0;
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            nIsDirty_101 = 1;
            A922DocSubSelectivo = 0;
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            nIsDirty_101 = 1;
            A927DocSubExonerado = 0;
            AssignAttri("", false, "A927DocSubExonerado", StringUtil.LTrimStr( A927DocSubExonerado, 15, 4));
            nIsDirty_101 = 1;
            A943DocSubGratuitoIna = 0;
            AssignAttri("", false, "A943DocSubGratuitoIna", StringUtil.LTrimStr( A943DocSubGratuitoIna, 15, 4));
            nIsDirty_101 = 1;
            A942DocSubGratuito = 0;
            AssignAttri("", false, "A942DocSubGratuito", StringUtil.LTrimStr( A942DocSubGratuito, 15, 4));
         }
         pr_default.close(10);
         nIsDirty_101 = 1;
         A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
         AssignAttri("", false, "A919DocSub", StringUtil.LTrimStr( A919DocSub, 15, 4));
         nIsDirty_101 = 1;
         A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
         AssignAttri("", false, "A918DocDscto", StringUtil.LTrimStr( A918DocDscto, 15, 2));
         nIsDirty_101 = 1;
         A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
         AssignAttri("", false, "A933DocIVA", StringUtil.LTrimStr( A933DocIVA, 15, 2));
         nIsDirty_101 = 1;
         A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
         AssignAttri("", false, "A948DocTot", StringUtil.LTrimStr( A948DocTot, 15, 2));
         nIsDirty_101 = 1;
         A949DocTotSigno = (decimal)(A948DocTot*A511TipSigno);
         AssignAttri("", false, "A949DocTotSigno", StringUtil.LTrimStr( A949DocTotSigno, 15, 2));
         nIsDirty_101 = 1;
         A940DocSerie = StringUtil.Substring( A24DocNum, 1, 3);
         AssignAttri("", false, "A940DocSerie", A940DocSerie);
         if ( ! ( (DateTime.MinValue==A232DocFec) || ( DateTimeUtil.ResetTime ( A232DocFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "DOCFEC");
            AnyError = 1;
            GX_FocusControl = edtDocFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A931DocFVcto) || ( DateTimeUtil.ResetTime ( A931DocFVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "DOCFVCTO");
            AnyError = 1;
            GX_FocusControl = edtDocFVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002Y6 */
         pr_default.execute(4, new Object[] {A231DocCliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "DOCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtDocCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A887DocCliDsc = T002Y6_A887DocCliDsc[0];
         AssignAttri("", false, "A887DocCliDsc", A887DocCliDsc);
         A885DocCliDir = T002Y6_A885DocCliDir[0];
         AssignAttri("", false, "A885DocCliDir", A885DocCliDir);
         pr_default.close(4);
         /* Using cursor T002Y7 */
         pr_default.execute(5, new Object[] {A230DocMonCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "DOCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtDocMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T002Y8 */
         pr_default.execute(6, new Object[] {A229DocConpCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Venta'.", "ForeignKeyNotFound", 1, "DOCCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtDocConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A888DocConpDsc = T002Y8_A888DocConpDsc[0];
         AssignAttri("", false, "A888DocConpDsc", A888DocConpDsc);
         A904DocDias = T002Y8_A904DocDias[0];
         AssignAttri("", false, "A904DocDias", StringUtil.LTrimStr( (decimal)(A904DocDias), 4, 0));
         pr_default.close(6);
         /* Using cursor T002Y9 */
         pr_default.execute(7, new Object[] {n228DocLisp, A228DocLisp});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A228DocLisp) ) )
            {
               GX_msglist.addItem("No existe 'Sub Lista Precios Venta'.", "ForeignKeyNotFound", 1, "DOCLISP");
               AnyError = 1;
               GX_FocusControl = edtDocLisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A929DocFecRef) || ( DateTimeUtil.ResetTime ( A929DocFecRef ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Referencia fuera de rango", "OutOfRange", 1, "DOCFECREF");
            AnyError = 1;
            GX_FocusControl = edtDocFecRef_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002Y10 */
         pr_default.execute(8, new Object[] {A227DocVendCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "DOCVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtDocVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A953DocVendDsc = T002Y10_A953DocVendDsc[0];
         AssignAttri("", false, "A953DocVendDsc", A953DocVendDsc);
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A952DocUsuFec) || ( A952DocUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "DOCUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtDocUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002Y11 */
         pr_default.execute(9, new Object[] {A226DocMovCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Venta Tipo Movimiento'.", "ForeignKeyNotFound", 1, "DOCMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtDocMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(9);
      }

      protected void CloseExtendedTableCursors2Y101( )
      {
         pr_default.close(2);
         pr_default.close(10);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( string A149TipCod )
      {
         /* Using cursor T002Y16 */
         pr_default.execute(12, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A306TipAbr = T002Y16_A306TipAbr[0];
         AssignAttri("", false, "A306TipAbr", A306TipAbr);
         A511TipSigno = T002Y16_A511TipSigno[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A306TipAbr))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_20( string A149TipCod ,
                                string A24DocNum )
      {
         /* Using cursor T002Y18 */
         pr_default.execute(13, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A932DocICBPER = T002Y18_A932DocICBPER[0];
            A920DocSubAfecto = T002Y18_A920DocSubAfecto[0];
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = T002Y18_A921DocSubInafecto[0];
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = T002Y18_A922DocSubSelectivo[0];
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            A927DocSubExonerado = T002Y18_A927DocSubExonerado[0];
            A943DocSubGratuitoIna = T002Y18_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = T002Y18_A942DocSubGratuito[0];
         }
         else
         {
            A932DocICBPER = 0;
            AssignAttri("", false, "A932DocICBPER", StringUtil.LTrimStr( A932DocICBPER, 15, 2));
            A920DocSubAfecto = 0;
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = 0;
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = 0;
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            A927DocSubExonerado = 0;
            AssignAttri("", false, "A927DocSubExonerado", StringUtil.LTrimStr( A927DocSubExonerado, 15, 4));
            A943DocSubGratuitoIna = 0;
            AssignAttri("", false, "A943DocSubGratuitoIna", StringUtil.LTrimStr( A943DocSubGratuitoIna, 15, 4));
            A942DocSubGratuito = 0;
            AssignAttri("", false, "A942DocSubGratuito", StringUtil.LTrimStr( A942DocSubGratuito, 15, 4));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A920DocSubAfecto, 15, 4, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A921DocSubInafecto, 15, 4, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A922DocSubSelectivo, 15, 4, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A927DocSubExonerado, 15, 4, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A943DocSubGratuitoIna, 15, 4, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A942DocSubGratuito, 15, 4, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_14( string A231DocCliCod )
      {
         /* Using cursor T002Y19 */
         pr_default.execute(14, new Object[] {A231DocCliCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "DOCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtDocCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A887DocCliDsc = T002Y19_A887DocCliDsc[0];
         AssignAttri("", false, "A887DocCliDsc", A887DocCliDsc);
         A885DocCliDir = T002Y19_A885DocCliDir[0];
         AssignAttri("", false, "A885DocCliDir", A885DocCliDir);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A887DocCliDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A885DocCliDir))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_15( int A230DocMonCod )
      {
         /* Using cursor T002Y20 */
         pr_default.execute(15, new Object[] {A230DocMonCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "DOCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtDocMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_16( int A229DocConpCod )
      {
         /* Using cursor T002Y21 */
         pr_default.execute(16, new Object[] {A229DocConpCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Venta'.", "ForeignKeyNotFound", 1, "DOCCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtDocConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A888DocConpDsc = T002Y21_A888DocConpDsc[0];
         AssignAttri("", false, "A888DocConpDsc", A888DocConpDsc);
         A904DocDias = T002Y21_A904DocDias[0];
         AssignAttri("", false, "A904DocDias", StringUtil.LTrimStr( (decimal)(A904DocDias), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A888DocConpDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A904DocDias), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_17( int A228DocLisp )
      {
         /* Using cursor T002Y22 */
         pr_default.execute(17, new Object[] {n228DocLisp, A228DocLisp});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A228DocLisp) ) )
            {
               GX_msglist.addItem("No existe 'Sub Lista Precios Venta'.", "ForeignKeyNotFound", 1, "DOCLISP");
               AnyError = 1;
               GX_FocusControl = edtDocLisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_18( int A227DocVendCod )
      {
         /* Using cursor T002Y23 */
         pr_default.execute(18, new Object[] {A227DocVendCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "DOCVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtDocVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A953DocVendDsc = T002Y23_A953DocVendDsc[0];
         AssignAttri("", false, "A953DocVendDsc", A953DocVendDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A953DocVendDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_19( int A226DocMovCod )
      {
         /* Using cursor T002Y24 */
         pr_default.execute(19, new Object[] {A226DocMovCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Venta Tipo Movimiento'.", "ForeignKeyNotFound", 1, "DOCMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtDocMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void GetKey2Y101( )
      {
         /* Using cursor T002Y25 */
         pr_default.execute(20, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound101 = 1;
         }
         else
         {
            RcdFound101 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Y3 */
         pr_default.execute(1, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Y101( 11) ;
            RcdFound101 = 1;
            A24DocNum = T002Y3_A24DocNum[0];
            n24DocNum = T002Y3_n24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A232DocFec = T002Y3_A232DocFec[0];
            AssignAttri("", false, "A232DocFec", context.localUtil.Format(A232DocFec, "99/99/99"));
            A931DocFVcto = T002Y3_A931DocFVcto[0];
            AssignAttri("", false, "A931DocFVcto", context.localUtil.Format(A931DocFVcto, "99/99/9999"));
            A886DocCliDirItem = T002Y3_A886DocCliDirItem[0];
            AssignAttri("", false, "A886DocCliDirItem", StringUtil.LTrimStr( (decimal)(A886DocCliDirItem), 6, 0));
            A882DocAnticipos = T002Y3_A882DocAnticipos[0];
            AssignAttri("", false, "A882DocAnticipos", StringUtil.LTrimStr( A882DocAnticipos, 15, 4));
            A935DocRedondeo = T002Y3_A935DocRedondeo[0];
            AssignAttri("", false, "A935DocRedondeo", StringUtil.LTrimStr( A935DocRedondeo, 15, 2));
            A899DocDcto = T002Y3_A899DocDcto[0];
            AssignAttri("", false, "A899DocDcto", StringUtil.LTrimStr( A899DocDcto, 6, 2));
            A934DocPorIVA = T002Y3_A934DocPorIVA[0];
            AssignAttri("", false, "A934DocPorIVA", StringUtil.LTrimStr( A934DocPorIVA, 6, 2));
            A936DocObs = T002Y3_A936DocObs[0];
            AssignAttri("", false, "A936DocObs", A936DocObs);
            A950DocTRef = T002Y3_A950DocTRef[0];
            AssignAttri("", false, "A950DocTRef", A950DocTRef);
            A939DocRef = T002Y3_A939DocRef[0];
            AssignAttri("", false, "A939DocRef", A939DocRef);
            A941DocSts = T002Y3_A941DocSts[0];
            AssignAttri("", false, "A941DocSts", A941DocSts);
            A947DocTItem = T002Y3_A947DocTItem[0];
            AssignAttri("", false, "A947DocTItem", StringUtil.LTrimStr( A947DocTItem, 15, 2));
            A937DocPedCod = T002Y3_A937DocPedCod[0];
            AssignAttri("", false, "A937DocPedCod", A937DocPedCod);
            A946DocTipo = T002Y3_A946DocTipo[0];
            AssignAttri("", false, "A946DocTipo", A946DocTipo);
            A929DocFecRef = T002Y3_A929DocFecRef[0];
            AssignAttri("", false, "A929DocFecRef", context.localUtil.Format(A929DocFecRef, "99/99/99"));
            A880DocAlmCod = T002Y3_A880DocAlmCod[0];
            AssignAttri("", false, "A880DocAlmCod", StringUtil.LTrimStr( (decimal)(A880DocAlmCod), 6, 0));
            A890DocCosCod = T002Y3_A890DocCosCod[0];
            n890DocCosCod = T002Y3_n890DocCosCod[0];
            AssignAttri("", false, "A890DocCosCod", A890DocCosCod);
            A951DocUsuCod = T002Y3_A951DocUsuCod[0];
            AssignAttri("", false, "A951DocUsuCod", A951DocUsuCod);
            A952DocUsuFec = T002Y3_A952DocUsuFec[0];
            AssignAttri("", false, "A952DocUsuFec", context.localUtil.TToC( A952DocUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A954DocVouAno = T002Y3_A954DocVouAno[0];
            AssignAttri("", false, "A954DocVouAno", StringUtil.LTrimStr( (decimal)(A954DocVouAno), 4, 0));
            A955DocVouMes = T002Y3_A955DocVouMes[0];
            AssignAttri("", false, "A955DocVouMes", StringUtil.LTrimStr( (decimal)(A955DocVouMes), 2, 0));
            A944DocTASICod = T002Y3_A944DocTASICod[0];
            AssignAttri("", false, "A944DocTASICod", StringUtil.LTrimStr( (decimal)(A944DocTASICod), 6, 0));
            A956DocVouNum = T002Y3_A956DocVouNum[0];
            AssignAttri("", false, "A956DocVouNum", A956DocVouNum);
            A938DocPercepcion = T002Y3_A938DocPercepcion[0];
            n938DocPercepcion = T002Y3_n938DocPercepcion[0];
            AssignAttri("", false, "A938DocPercepcion", A938DocPercepcion);
            A883DocAplicaAnticipo = T002Y3_A883DocAplicaAnticipo[0];
            AssignAttri("", false, "A883DocAplicaAnticipo", StringUtil.LTrimStr( A883DocAplicaAnticipo, 15, 2));
            A884DocCadena = T002Y3_A884DocCadena[0];
            n884DocCadena = T002Y3_n884DocCadena[0];
            A930DocFEOBS = T002Y3_A930DocFEOBS[0];
            n930DocFEOBS = T002Y3_n930DocFEOBS[0];
            A881DocAnticipo = T002Y3_A881DocAnticipo[0];
            A945DocTipAnticipo = T002Y3_A945DocTipAnticipo[0];
            A879DocAIVA = T002Y3_A879DocAIVA[0];
            A149TipCod = T002Y3_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A178TieCod = T002Y3_A178TieCod[0];
            n178TieCod = T002Y3_n178TieCod[0];
            A231DocCliCod = T002Y3_A231DocCliCod[0];
            AssignAttri("", false, "A231DocCliCod", A231DocCliCod);
            A230DocMonCod = T002Y3_A230DocMonCod[0];
            AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
            A229DocConpCod = T002Y3_A229DocConpCod[0];
            AssignAttri("", false, "A229DocConpCod", StringUtil.LTrimStr( (decimal)(A229DocConpCod), 6, 0));
            A228DocLisp = T002Y3_A228DocLisp[0];
            n228DocLisp = T002Y3_n228DocLisp[0];
            AssignAttri("", false, "A228DocLisp", StringUtil.LTrimStr( (decimal)(A228DocLisp), 6, 0));
            A227DocVendCod = T002Y3_A227DocVendCod[0];
            AssignAttri("", false, "A227DocVendCod", StringUtil.LTrimStr( (decimal)(A227DocVendCod), 6, 0));
            A226DocMovCod = T002Y3_A226DocMovCod[0];
            AssignAttri("", false, "A226DocMovCod", StringUtil.LTrimStr( (decimal)(A226DocMovCod), 6, 0));
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2Y101( ) ;
            if ( AnyError == 1 )
            {
               RcdFound101 = 0;
               InitializeNonKey2Y101( ) ;
            }
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound101 = 0;
            InitializeNonKey2Y101( ) ;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Y101( ) ;
         if ( RcdFound101 == 0 )
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
         RcdFound101 = 0;
         /* Using cursor T002Y26 */
         pr_default.execute(21, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(21) != 101) )
         {
            while ( (pr_default.getStatus(21) != 101) && ( ( StringUtil.StrCmp(T002Y26_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T002Y26_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T002Y26_A24DocNum[0], A24DocNum) < 0 ) ) )
            {
               pr_default.readNext(21);
            }
            if ( (pr_default.getStatus(21) != 101) && ( ( StringUtil.StrCmp(T002Y26_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T002Y26_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T002Y26_A24DocNum[0], A24DocNum) > 0 ) ) )
            {
               A149TipCod = T002Y26_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = T002Y26_A24DocNum[0];
               n24DocNum = T002Y26_n24DocNum[0];
               AssignAttri("", false, "A24DocNum", A24DocNum);
               RcdFound101 = 1;
            }
         }
         pr_default.close(21);
      }

      protected void move_previous( )
      {
         RcdFound101 = 0;
         /* Using cursor T002Y27 */
         pr_default.execute(22, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T002Y27_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T002Y27_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T002Y27_A24DocNum[0], A24DocNum) > 0 ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T002Y27_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T002Y27_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T002Y27_A24DocNum[0], A24DocNum) < 0 ) ) )
            {
               A149TipCod = T002Y27_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = T002Y27_A24DocNum[0];
               n24DocNum = T002Y27_n24DocNum[0];
               AssignAttri("", false, "A24DocNum", A24DocNum);
               RcdFound101 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Y101( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Y101( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound101 == 1 )
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
               {
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  A24DocNum = Z24DocNum;
                  n24DocNum = false;
                  AssignAttri("", false, "A24DocNum", A24DocNum);
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
                  Update2Y101( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Y101( ) ;
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
                     Insert2Y101( ) ;
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
         if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
         {
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = Z24DocNum;
            n24DocNum = false;
            AssignAttri("", false, "A24DocNum", A24DocNum);
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
         GetKey2Y101( ) ;
         if ( RcdFound101 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
            {
               A149TipCod = Z149TipCod;
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = Z24DocNum;
               n24DocNum = false;
               AssignAttri("", false, "A24DocNum", A24DocNum);
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
            if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
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
         context.RollbackDataStores("clventas",pr_default);
         GX_FocusControl = edtDocFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2Y0( ) ;
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
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtDocFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2Y101( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDocFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Y101( ) ;
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
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDocFec_Internalname;
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
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDocFec_Internalname;
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
         ScanStart2Y101( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound101 != 0 )
            {
               ScanNext2Y101( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDocFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Y101( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2Y101( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Y2 */
            pr_default.execute(0, new Object[] {A149TipCod, n24DocNum, A24DocNum});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z232DocFec ) != DateTimeUtil.ResetTime ( T002Y2_A232DocFec[0] ) ) || ( DateTimeUtil.ResetTime ( Z931DocFVcto ) != DateTimeUtil.ResetTime ( T002Y2_A931DocFVcto[0] ) ) || ( Z886DocCliDirItem != T002Y2_A886DocCliDirItem[0] ) || ( Z882DocAnticipos != T002Y2_A882DocAnticipos[0] ) || ( Z935DocRedondeo != T002Y2_A935DocRedondeo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z899DocDcto != T002Y2_A899DocDcto[0] ) || ( Z934DocPorIVA != T002Y2_A934DocPorIVA[0] ) || ( StringUtil.StrCmp(Z950DocTRef, T002Y2_A950DocTRef[0]) != 0 ) || ( StringUtil.StrCmp(Z939DocRef, T002Y2_A939DocRef[0]) != 0 ) || ( StringUtil.StrCmp(Z941DocSts, T002Y2_A941DocSts[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z947DocTItem != T002Y2_A947DocTItem[0] ) || ( StringUtil.StrCmp(Z937DocPedCod, T002Y2_A937DocPedCod[0]) != 0 ) || ( StringUtil.StrCmp(Z946DocTipo, T002Y2_A946DocTipo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z929DocFecRef ) != DateTimeUtil.ResetTime ( T002Y2_A929DocFecRef[0] ) ) || ( Z880DocAlmCod != T002Y2_A880DocAlmCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z890DocCosCod, T002Y2_A890DocCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z951DocUsuCod, T002Y2_A951DocUsuCod[0]) != 0 ) || ( Z952DocUsuFec != T002Y2_A952DocUsuFec[0] ) || ( Z954DocVouAno != T002Y2_A954DocVouAno[0] ) || ( Z955DocVouMes != T002Y2_A955DocVouMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z944DocTASICod != T002Y2_A944DocTASICod[0] ) || ( StringUtil.StrCmp(Z956DocVouNum, T002Y2_A956DocVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z938DocPercepcion, T002Y2_A938DocPercepcion[0]) != 0 ) || ( Z883DocAplicaAnticipo != T002Y2_A883DocAplicaAnticipo[0] ) || ( StringUtil.StrCmp(Z884DocCadena, T002Y2_A884DocCadena[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z930DocFEOBS, T002Y2_A930DocFEOBS[0]) != 0 ) || ( StringUtil.StrCmp(Z881DocAnticipo, T002Y2_A881DocAnticipo[0]) != 0 ) || ( StringUtil.StrCmp(Z945DocTipAnticipo, T002Y2_A945DocTipAnticipo[0]) != 0 ) || ( Z879DocAIVA != T002Y2_A879DocAIVA[0] ) || ( Z178TieCod != T002Y2_A178TieCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z231DocCliCod, T002Y2_A231DocCliCod[0]) != 0 ) || ( Z230DocMonCod != T002Y2_A230DocMonCod[0] ) || ( Z229DocConpCod != T002Y2_A229DocConpCod[0] ) || ( Z228DocLisp != T002Y2_A228DocLisp[0] ) || ( Z227DocVendCod != T002Y2_A227DocVendCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z226DocMovCod != T002Y2_A226DocMovCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z232DocFec ) != DateTimeUtil.ResetTime ( T002Y2_A232DocFec[0] ) )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocFec");
                  GXUtil.WriteLogRaw("Old: ",Z232DocFec);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A232DocFec[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z931DocFVcto ) != DateTimeUtil.ResetTime ( T002Y2_A931DocFVcto[0] ) )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocFVcto");
                  GXUtil.WriteLogRaw("Old: ",Z931DocFVcto);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A931DocFVcto[0]);
               }
               if ( Z886DocCliDirItem != T002Y2_A886DocCliDirItem[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocCliDirItem");
                  GXUtil.WriteLogRaw("Old: ",Z886DocCliDirItem);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A886DocCliDirItem[0]);
               }
               if ( Z882DocAnticipos != T002Y2_A882DocAnticipos[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocAnticipos");
                  GXUtil.WriteLogRaw("Old: ",Z882DocAnticipos);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A882DocAnticipos[0]);
               }
               if ( Z935DocRedondeo != T002Y2_A935DocRedondeo[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocRedondeo");
                  GXUtil.WriteLogRaw("Old: ",Z935DocRedondeo);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A935DocRedondeo[0]);
               }
               if ( Z899DocDcto != T002Y2_A899DocDcto[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocDcto");
                  GXUtil.WriteLogRaw("Old: ",Z899DocDcto);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A899DocDcto[0]);
               }
               if ( Z934DocPorIVA != T002Y2_A934DocPorIVA[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocPorIVA");
                  GXUtil.WriteLogRaw("Old: ",Z934DocPorIVA);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A934DocPorIVA[0]);
               }
               if ( StringUtil.StrCmp(Z950DocTRef, T002Y2_A950DocTRef[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocTRef");
                  GXUtil.WriteLogRaw("Old: ",Z950DocTRef);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A950DocTRef[0]);
               }
               if ( StringUtil.StrCmp(Z939DocRef, T002Y2_A939DocRef[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocRef");
                  GXUtil.WriteLogRaw("Old: ",Z939DocRef);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A939DocRef[0]);
               }
               if ( StringUtil.StrCmp(Z941DocSts, T002Y2_A941DocSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocSts");
                  GXUtil.WriteLogRaw("Old: ",Z941DocSts);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A941DocSts[0]);
               }
               if ( Z947DocTItem != T002Y2_A947DocTItem[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocTItem");
                  GXUtil.WriteLogRaw("Old: ",Z947DocTItem);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A947DocTItem[0]);
               }
               if ( StringUtil.StrCmp(Z937DocPedCod, T002Y2_A937DocPedCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocPedCod");
                  GXUtil.WriteLogRaw("Old: ",Z937DocPedCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A937DocPedCod[0]);
               }
               if ( StringUtil.StrCmp(Z946DocTipo, T002Y2_A946DocTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocTipo");
                  GXUtil.WriteLogRaw("Old: ",Z946DocTipo);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A946DocTipo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z929DocFecRef ) != DateTimeUtil.ResetTime ( T002Y2_A929DocFecRef[0] ) )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocFecRef");
                  GXUtil.WriteLogRaw("Old: ",Z929DocFecRef);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A929DocFecRef[0]);
               }
               if ( Z880DocAlmCod != T002Y2_A880DocAlmCod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocAlmCod");
                  GXUtil.WriteLogRaw("Old: ",Z880DocAlmCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A880DocAlmCod[0]);
               }
               if ( StringUtil.StrCmp(Z890DocCosCod, T002Y2_A890DocCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z890DocCosCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A890DocCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z951DocUsuCod, T002Y2_A951DocUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z951DocUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A951DocUsuCod[0]);
               }
               if ( Z952DocUsuFec != T002Y2_A952DocUsuFec[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z952DocUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A952DocUsuFec[0]);
               }
               if ( Z954DocVouAno != T002Y2_A954DocVouAno[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z954DocVouAno);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A954DocVouAno[0]);
               }
               if ( Z955DocVouMes != T002Y2_A955DocVouMes[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z955DocVouMes);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A955DocVouMes[0]);
               }
               if ( Z944DocTASICod != T002Y2_A944DocTASICod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z944DocTASICod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A944DocTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z956DocVouNum, T002Y2_A956DocVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z956DocVouNum);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A956DocVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z938DocPercepcion, T002Y2_A938DocPercepcion[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocPercepcion");
                  GXUtil.WriteLogRaw("Old: ",Z938DocPercepcion);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A938DocPercepcion[0]);
               }
               if ( Z883DocAplicaAnticipo != T002Y2_A883DocAplicaAnticipo[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocAplicaAnticipo");
                  GXUtil.WriteLogRaw("Old: ",Z883DocAplicaAnticipo);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A883DocAplicaAnticipo[0]);
               }
               if ( StringUtil.StrCmp(Z884DocCadena, T002Y2_A884DocCadena[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocCadena");
                  GXUtil.WriteLogRaw("Old: ",Z884DocCadena);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A884DocCadena[0]);
               }
               if ( StringUtil.StrCmp(Z930DocFEOBS, T002Y2_A930DocFEOBS[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocFEOBS");
                  GXUtil.WriteLogRaw("Old: ",Z930DocFEOBS);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A930DocFEOBS[0]);
               }
               if ( StringUtil.StrCmp(Z881DocAnticipo, T002Y2_A881DocAnticipo[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocAnticipo");
                  GXUtil.WriteLogRaw("Old: ",Z881DocAnticipo);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A881DocAnticipo[0]);
               }
               if ( StringUtil.StrCmp(Z945DocTipAnticipo, T002Y2_A945DocTipAnticipo[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocTipAnticipo");
                  GXUtil.WriteLogRaw("Old: ",Z945DocTipAnticipo);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A945DocTipAnticipo[0]);
               }
               if ( Z879DocAIVA != T002Y2_A879DocAIVA[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocAIVA");
                  GXUtil.WriteLogRaw("Old: ",Z879DocAIVA);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A879DocAIVA[0]);
               }
               if ( Z178TieCod != T002Y2_A178TieCod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"TieCod");
                  GXUtil.WriteLogRaw("Old: ",Z178TieCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A178TieCod[0]);
               }
               if ( StringUtil.StrCmp(Z231DocCliCod, T002Y2_A231DocCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z231DocCliCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A231DocCliCod[0]);
               }
               if ( Z230DocMonCod != T002Y2_A230DocMonCod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z230DocMonCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A230DocMonCod[0]);
               }
               if ( Z229DocConpCod != T002Y2_A229DocConpCod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocConpCod");
                  GXUtil.WriteLogRaw("Old: ",Z229DocConpCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A229DocConpCod[0]);
               }
               if ( Z228DocLisp != T002Y2_A228DocLisp[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocLisp");
                  GXUtil.WriteLogRaw("Old: ",Z228DocLisp);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A228DocLisp[0]);
               }
               if ( Z227DocVendCod != T002Y2_A227DocVendCod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocVendCod");
                  GXUtil.WriteLogRaw("Old: ",Z227DocVendCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A227DocVendCod[0]);
               }
               if ( Z226DocMovCod != T002Y2_A226DocMovCod[0] )
               {
                  GXUtil.WriteLog("clventas:[seudo value changed for attri]"+"DocMovCod");
                  GXUtil.WriteLogRaw("Old: ",Z226DocMovCod);
                  GXUtil.WriteLogRaw("Current: ",T002Y2_A226DocMovCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLVENTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Y101( )
      {
         BeforeValidate2Y101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y101( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Y101( 0) ;
            CheckOptimisticConcurrency2Y101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Y101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Y28 */
                     pr_default.execute(23, new Object[] {n24DocNum, A24DocNum, A232DocFec, A931DocFVcto, A886DocCliDirItem, A882DocAnticipos, A935DocRedondeo, A899DocDcto, A934DocPorIVA, A936DocObs, A950DocTRef, A939DocRef, A941DocSts, A947DocTItem, A937DocPedCod, A946DocTipo, A929DocFecRef, A880DocAlmCod, n890DocCosCod, A890DocCosCod, A951DocUsuCod, A952DocUsuFec, A954DocVouAno, A955DocVouMes, A944DocTASICod, A956DocVouNum, n938DocPercepcion, A938DocPercepcion, A883DocAplicaAnticipo, n884DocCadena, A884DocCadena, n930DocFEOBS, A930DocFEOBS, A881DocAnticipo, A945DocTipAnticipo, A879DocAIVA, A149TipCod, n178TieCod, A178TieCod, A231DocCliCod, A230DocMonCod, A229DocConpCod, n228DocLisp, A228DocLisp, A227DocVendCod, A226DocMovCod, A932DocICBPER});
                     pr_default.close(23);
                     dsDefault.SmartCacheProvider.SetUpdated("CLVENTAS");
                     if ( (pr_default.getStatus(23) == 1) )
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
                           ResetCaption2Y0( ) ;
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
               Load2Y101( ) ;
            }
            EndLevel2Y101( ) ;
         }
         CloseExtendedTableCursors2Y101( ) ;
      }

      protected void Update2Y101( )
      {
         BeforeValidate2Y101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y101( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Y101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Y29 */
                     pr_default.execute(24, new Object[] {A232DocFec, A931DocFVcto, A886DocCliDirItem, A882DocAnticipos, A935DocRedondeo, A899DocDcto, A934DocPorIVA, A936DocObs, A950DocTRef, A939DocRef, A941DocSts, A947DocTItem, A937DocPedCod, A946DocTipo, A929DocFecRef, A880DocAlmCod, n890DocCosCod, A890DocCosCod, A951DocUsuCod, A952DocUsuFec, A954DocVouAno, A955DocVouMes, A944DocTASICod, A956DocVouNum, n938DocPercepcion, A938DocPercepcion, A883DocAplicaAnticipo, n884DocCadena, A884DocCadena, n930DocFEOBS, A930DocFEOBS, A881DocAnticipo, A945DocTipAnticipo, A879DocAIVA, n178TieCod, A178TieCod, A231DocCliCod, A230DocMonCod, A229DocConpCod, n228DocLisp, A228DocLisp, A227DocVendCod, A226DocMovCod, A932DocICBPER, A149TipCod, n24DocNum, A24DocNum});
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("CLVENTAS");
                     if ( (pr_default.getStatus(24) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLVENTAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Y101( ) ;
                     if ( AnyError == 0 )
                     {
                        new clventasupdateredundancy(context ).execute( ref  A149TipCod, ref  A24DocNum) ;
                        AssignAttri("", false, "A149TipCod", A149TipCod);
                        AssignAttri("", false, "A24DocNum", A24DocNum);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2Y0( ) ;
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
            EndLevel2Y101( ) ;
         }
         CloseExtendedTableCursors2Y101( ) ;
      }

      protected void DeferredUpdate2Y101( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2Y101( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y101( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Y101( ) ;
            AfterConfirm2Y101( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Y101( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Y30 */
                  pr_default.execute(25, new Object[] {A149TipCod, n24DocNum, A24DocNum});
                  pr_default.close(25);
                  dsDefault.SmartCacheProvider.SetUpdated("CLVENTAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound101 == 0 )
                        {
                           InitAll2Y101( ) ;
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
                        ResetCaption2Y0( ) ;
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
         sMode101 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Y101( ) ;
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Y101( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002Y31 */
            pr_default.execute(26, new Object[] {A149TipCod});
            A306TipAbr = T002Y31_A306TipAbr[0];
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            A511TipSigno = T002Y31_A511TipSigno[0];
            pr_default.close(26);
            /* Using cursor T002Y33 */
            pr_default.execute(27, new Object[] {A149TipCod, n24DocNum, A24DocNum});
            if ( (pr_default.getStatus(27) != 101) )
            {
               A932DocICBPER = T002Y33_A932DocICBPER[0];
               A920DocSubAfecto = T002Y33_A920DocSubAfecto[0];
               AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
               A921DocSubInafecto = T002Y33_A921DocSubInafecto[0];
               AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
               A922DocSubSelectivo = T002Y33_A922DocSubSelectivo[0];
               AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
               A927DocSubExonerado = T002Y33_A927DocSubExonerado[0];
               A943DocSubGratuitoIna = T002Y33_A943DocSubGratuitoIna[0];
               A942DocSubGratuito = T002Y33_A942DocSubGratuito[0];
            }
            else
            {
               A932DocICBPER = 0;
               AssignAttri("", false, "A932DocICBPER", StringUtil.LTrimStr( A932DocICBPER, 15, 2));
               A920DocSubAfecto = 0;
               AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
               A921DocSubInafecto = 0;
               AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
               A922DocSubSelectivo = 0;
               AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
               A927DocSubExonerado = 0;
               AssignAttri("", false, "A927DocSubExonerado", StringUtil.LTrimStr( A927DocSubExonerado, 15, 4));
               A943DocSubGratuitoIna = 0;
               AssignAttri("", false, "A943DocSubGratuitoIna", StringUtil.LTrimStr( A943DocSubGratuitoIna, 15, 4));
               A942DocSubGratuito = 0;
               AssignAttri("", false, "A942DocSubGratuito", StringUtil.LTrimStr( A942DocSubGratuito, 15, 4));
            }
            pr_default.close(27);
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AssignAttri("", false, "A919DocSub", StringUtil.LTrimStr( A919DocSub, 15, 4));
            A940DocSerie = StringUtil.Substring( A24DocNum, 1, 3);
            AssignAttri("", false, "A940DocSerie", A940DocSerie);
            /* Using cursor T002Y34 */
            pr_default.execute(28, new Object[] {A231DocCliCod});
            A887DocCliDsc = T002Y34_A887DocCliDsc[0];
            AssignAttri("", false, "A887DocCliDsc", A887DocCliDsc);
            A885DocCliDir = T002Y34_A885DocCliDir[0];
            AssignAttri("", false, "A885DocCliDir", A885DocCliDir);
            pr_default.close(28);
            /* Using cursor T002Y35 */
            pr_default.execute(29, new Object[] {A229DocConpCod});
            A888DocConpDsc = T002Y35_A888DocConpDsc[0];
            AssignAttri("", false, "A888DocConpDsc", A888DocConpDsc);
            A904DocDias = T002Y35_A904DocDias[0];
            AssignAttri("", false, "A904DocDias", StringUtil.LTrimStr( (decimal)(A904DocDias), 4, 0));
            pr_default.close(29);
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            AssignAttri("", false, "A918DocDscto", StringUtil.LTrimStr( A918DocDscto, 15, 2));
            A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
            AssignAttri("", false, "A933DocIVA", StringUtil.LTrimStr( A933DocIVA, 15, 2));
            A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
            AssignAttri("", false, "A948DocTot", StringUtil.LTrimStr( A948DocTot, 15, 2));
            A949DocTotSigno = (decimal)(A948DocTot*A511TipSigno);
            AssignAttri("", false, "A949DocTotSigno", StringUtil.LTrimStr( A949DocTotSigno, 15, 2));
            /* Using cursor T002Y36 */
            pr_default.execute(30, new Object[] {A227DocVendCod});
            A953DocVendDsc = T002Y36_A953DocVendDsc[0];
            AssignAttri("", false, "A953DocVendDsc", A953DocVendDsc);
            pr_default.close(30);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002Y37 */
            pr_default.execute(31, new Object[] {A149TipCod, n24DocNum, A24DocNum});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ventas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T002Y38 */
            pr_default.execute(32, new Object[] {A149TipCod, n24DocNum, A24DocNum});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Clientes Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T002Y39 */
            pr_default.execute(33, new Object[] {A149TipCod, n24DocNum, A24DocNum});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
         }
      }

      protected void EndLevel2Y101( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Y101( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(26);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(27);
            context.CommitDataStores("clventas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(26);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(27);
            context.RollbackDataStores("clventas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Y101( )
      {
         /* Using cursor T002Y40 */
         pr_default.execute(34);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound101 = 1;
            A149TipCod = T002Y40_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T002Y40_A24DocNum[0];
            n24DocNum = T002Y40_n24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Y101( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound101 = 1;
            A149TipCod = T002Y40_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T002Y40_A24DocNum[0];
            n24DocNum = T002Y40_n24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
         }
      }

      protected void ScanEnd2Y101( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm2Y101( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Y101( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Y101( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Y101( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Y101( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Y101( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Y101( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtDocNum_Enabled = 0;
         AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), true);
         edtTipAbr_Enabled = 0;
         AssignProp("", false, edtTipAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipAbr_Enabled), 5, 0), true);
         edtDocFec_Enabled = 0;
         AssignProp("", false, edtDocFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocFec_Enabled), 5, 0), true);
         edtDocFVcto_Enabled = 0;
         AssignProp("", false, edtDocFVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocFVcto_Enabled), 5, 0), true);
         edtDocCliCod_Enabled = 0;
         AssignProp("", false, edtDocCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocCliCod_Enabled), 5, 0), true);
         edtDocCliDsc_Enabled = 0;
         AssignProp("", false, edtDocCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocCliDsc_Enabled), 5, 0), true);
         edtDocCliDir_Enabled = 0;
         AssignProp("", false, edtDocCliDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocCliDir_Enabled), 5, 0), true);
         edtDocCliDirItem_Enabled = 0;
         AssignProp("", false, edtDocCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocCliDirItem_Enabled), 5, 0), true);
         edtDocMonCod_Enabled = 0;
         AssignProp("", false, edtDocMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocMonCod_Enabled), 5, 0), true);
         edtDocConpCod_Enabled = 0;
         AssignProp("", false, edtDocConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocConpCod_Enabled), 5, 0), true);
         edtDocConpDsc_Enabled = 0;
         AssignProp("", false, edtDocConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocConpDsc_Enabled), 5, 0), true);
         edtDocDias_Enabled = 0;
         AssignProp("", false, edtDocDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDias_Enabled), 5, 0), true);
         edtDocLisp_Enabled = 0;
         AssignProp("", false, edtDocLisp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocLisp_Enabled), 5, 0), true);
         edtDocSubAfecto_Enabled = 0;
         AssignProp("", false, edtDocSubAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocSubAfecto_Enabled), 5, 0), true);
         edtDocSubInafecto_Enabled = 0;
         AssignProp("", false, edtDocSubInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocSubInafecto_Enabled), 5, 0), true);
         edtDocSubSelectivo_Enabled = 0;
         AssignProp("", false, edtDocSubSelectivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocSubSelectivo_Enabled), 5, 0), true);
         edtDocAnticipos_Enabled = 0;
         AssignProp("", false, edtDocAnticipos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAnticipos_Enabled), 5, 0), true);
         edtDocDscto_Enabled = 0;
         AssignProp("", false, edtDocDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDscto_Enabled), 5, 0), true);
         edtDocSub_Enabled = 0;
         AssignProp("", false, edtDocSub_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocSub_Enabled), 5, 0), true);
         edtDocRedondeo_Enabled = 0;
         AssignProp("", false, edtDocRedondeo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocRedondeo_Enabled), 5, 0), true);
         edtDocDcto_Enabled = 0;
         AssignProp("", false, edtDocDcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocDcto_Enabled), 5, 0), true);
         edtDocPorIVA_Enabled = 0;
         AssignProp("", false, edtDocPorIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocPorIVA_Enabled), 5, 0), true);
         edtDocIVA_Enabled = 0;
         AssignProp("", false, edtDocIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocIVA_Enabled), 5, 0), true);
         edtDocTot_Enabled = 0;
         AssignProp("", false, edtDocTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTot_Enabled), 5, 0), true);
         edtDocObs_Enabled = 0;
         AssignProp("", false, edtDocObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocObs_Enabled), 5, 0), true);
         edtDocTRef_Enabled = 0;
         AssignProp("", false, edtDocTRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTRef_Enabled), 5, 0), true);
         edtDocRef_Enabled = 0;
         AssignProp("", false, edtDocRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocRef_Enabled), 5, 0), true);
         edtDocSts_Enabled = 0;
         AssignProp("", false, edtDocSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocSts_Enabled), 5, 0), true);
         edtDocTItem_Enabled = 0;
         AssignProp("", false, edtDocTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTItem_Enabled), 5, 0), true);
         edtDocPedCod_Enabled = 0;
         AssignProp("", false, edtDocPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocPedCod_Enabled), 5, 0), true);
         edtDocTipo_Enabled = 0;
         AssignProp("", false, edtDocTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipo_Enabled), 5, 0), true);
         edtDocFecRef_Enabled = 0;
         AssignProp("", false, edtDocFecRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocFecRef_Enabled), 5, 0), true);
         edtDocAlmCod_Enabled = 0;
         AssignProp("", false, edtDocAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAlmCod_Enabled), 5, 0), true);
         edtDocVendCod_Enabled = 0;
         AssignProp("", false, edtDocVendCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocVendCod_Enabled), 5, 0), true);
         edtDocVendDsc_Enabled = 0;
         AssignProp("", false, edtDocVendDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocVendDsc_Enabled), 5, 0), true);
         edtDocCosCod_Enabled = 0;
         AssignProp("", false, edtDocCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocCosCod_Enabled), 5, 0), true);
         edtDocUsuCod_Enabled = 0;
         AssignProp("", false, edtDocUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocUsuCod_Enabled), 5, 0), true);
         edtDocUsuFec_Enabled = 0;
         AssignProp("", false, edtDocUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocUsuFec_Enabled), 5, 0), true);
         edtDocVouAno_Enabled = 0;
         AssignProp("", false, edtDocVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocVouAno_Enabled), 5, 0), true);
         edtDocVouMes_Enabled = 0;
         AssignProp("", false, edtDocVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocVouMes_Enabled), 5, 0), true);
         edtDocTASICod_Enabled = 0;
         AssignProp("", false, edtDocTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTASICod_Enabled), 5, 0), true);
         edtDocVouNum_Enabled = 0;
         AssignProp("", false, edtDocVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocVouNum_Enabled), 5, 0), true);
         edtDocMovCod_Enabled = 0;
         AssignProp("", false, edtDocMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocMovCod_Enabled), 5, 0), true);
         edtDocTotSigno_Enabled = 0;
         AssignProp("", false, edtDocTotSigno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTotSigno_Enabled), 5, 0), true);
         edtDocPercepcion_Enabled = 0;
         AssignProp("", false, edtDocPercepcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocPercepcion_Enabled), 5, 0), true);
         edtDocAplicaAnticipo_Enabled = 0;
         AssignProp("", false, edtDocAplicaAnticipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocAplicaAnticipo_Enabled), 5, 0), true);
         edtDocSerie_Enabled = 0;
         AssignProp("", false, edtDocSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocSerie_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Y101( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Y0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025433", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clventas.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLVENTAS");
         forbiddenHiddens.Add("DocCadena", StringUtil.RTrim( context.localUtil.Format( A884DocCadena, "")));
         forbiddenHiddens.Add("TieCod", context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"));
         forbiddenHiddens.Add("DocFEOBS", StringUtil.RTrim( context.localUtil.Format( A930DocFEOBS, "")));
         forbiddenHiddens.Add("DocAnticipo", StringUtil.RTrim( context.localUtil.Format( A881DocAnticipo, "")));
         forbiddenHiddens.Add("DocTipAnticipo", StringUtil.RTrim( context.localUtil.Format( A945DocTipAnticipo, "")));
         forbiddenHiddens.Add("DocAIVA", context.localUtil.Format( (decimal)(A879DocAIVA), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clventas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z232DocFec", context.localUtil.DToC( Z232DocFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z931DocFVcto", context.localUtil.DToC( Z931DocFVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z886DocCliDirItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z886DocCliDirItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z882DocAnticipos", StringUtil.LTrim( StringUtil.NToC( Z882DocAnticipos, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z935DocRedondeo", StringUtil.LTrim( StringUtil.NToC( Z935DocRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z899DocDcto", StringUtil.LTrim( StringUtil.NToC( Z899DocDcto, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z934DocPorIVA", StringUtil.LTrim( StringUtil.NToC( Z934DocPorIVA, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z950DocTRef", StringUtil.RTrim( Z950DocTRef));
         GxWebStd.gx_hidden_field( context, "Z939DocRef", StringUtil.RTrim( Z939DocRef));
         GxWebStd.gx_hidden_field( context, "Z941DocSts", StringUtil.RTrim( Z941DocSts));
         GxWebStd.gx_hidden_field( context, "Z947DocTItem", StringUtil.LTrim( StringUtil.NToC( Z947DocTItem, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z937DocPedCod", StringUtil.RTrim( Z937DocPedCod));
         GxWebStd.gx_hidden_field( context, "Z946DocTipo", StringUtil.RTrim( Z946DocTipo));
         GxWebStd.gx_hidden_field( context, "Z929DocFecRef", context.localUtil.DToC( Z929DocFecRef, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z880DocAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z880DocAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z890DocCosCod", StringUtil.RTrim( Z890DocCosCod));
         GxWebStd.gx_hidden_field( context, "Z951DocUsuCod", StringUtil.RTrim( Z951DocUsuCod));
         GxWebStd.gx_hidden_field( context, "Z952DocUsuFec", context.localUtil.TToC( Z952DocUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z954DocVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z954DocVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z955DocVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z955DocVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z944DocTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z944DocTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z956DocVouNum", StringUtil.RTrim( Z956DocVouNum));
         GxWebStd.gx_hidden_field( context, "Z938DocPercepcion", StringUtil.RTrim( Z938DocPercepcion));
         GxWebStd.gx_hidden_field( context, "Z883DocAplicaAnticipo", StringUtil.LTrim( StringUtil.NToC( Z883DocAplicaAnticipo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z884DocCadena", Z884DocCadena);
         GxWebStd.gx_hidden_field( context, "Z930DocFEOBS", Z930DocFEOBS);
         GxWebStd.gx_hidden_field( context, "Z881DocAnticipo", StringUtil.RTrim( Z881DocAnticipo));
         GxWebStd.gx_hidden_field( context, "Z945DocTipAnticipo", StringUtil.RTrim( Z945DocTipAnticipo));
         GxWebStd.gx_hidden_field( context, "Z879DocAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z879DocAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z231DocCliCod", StringUtil.RTrim( Z231DocCliCod));
         GxWebStd.gx_hidden_field( context, "Z230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z230DocMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z229DocConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z229DocConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z228DocLisp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z228DocLisp), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z227DocVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227DocVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z226DocMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z226DocMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "DOCSUBEXONERADO", StringUtil.LTrim( StringUtil.NToC( A927DocSubExonerado, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCICBPER", StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPSIGNO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCCADENA", A884DocCadena);
         GxWebStd.gx_hidden_field( context, "DOCFEOBS", A930DocFEOBS);
         GxWebStd.gx_hidden_field( context, "DOCANTICIPO", StringUtil.RTrim( A881DocAnticipo));
         GxWebStd.gx_hidden_field( context, "DOCTIPANTICIPO", StringUtil.RTrim( A945DocTipAnticipo));
         GxWebStd.gx_hidden_field( context, "DOCAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A879DocAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCSUBGRATUITOINA", StringUtil.LTrim( StringUtil.NToC( A943DocSubGratuitoIna, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCSUBGRATUITO", StringUtil.LTrim( StringUtil.NToC( A942DocSubGratuito, 15, 4, ".", "")));
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
         return formatLink("clventas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLVENTAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ventas - Cabecera" ;
      }

      protected void InitializeNonKey2Y101( )
      {
         A949DocTotSigno = 0;
         AssignAttri("", false, "A949DocTotSigno", StringUtil.LTrimStr( A949DocTotSigno, 15, 2));
         A918DocDscto = 0;
         AssignAttri("", false, "A918DocDscto", StringUtil.LTrimStr( A918DocDscto, 15, 2));
         A948DocTot = 0;
         AssignAttri("", false, "A948DocTot", StringUtil.LTrimStr( A948DocTot, 15, 2));
         A919DocSub = 0;
         AssignAttri("", false, "A919DocSub", StringUtil.LTrimStr( A919DocSub, 15, 4));
         A933DocIVA = 0;
         AssignAttri("", false, "A933DocIVA", StringUtil.LTrimStr( A933DocIVA, 15, 2));
         A932DocICBPER = 0;
         AssignAttri("", false, "A932DocICBPER", StringUtil.LTrimStr( A932DocICBPER, 15, 2));
         A940DocSerie = "";
         AssignAttri("", false, "A940DocSerie", A940DocSerie);
         A306TipAbr = "";
         AssignAttri("", false, "A306TipAbr", A306TipAbr);
         A232DocFec = DateTime.MinValue;
         AssignAttri("", false, "A232DocFec", context.localUtil.Format(A232DocFec, "99/99/99"));
         A931DocFVcto = DateTime.MinValue;
         AssignAttri("", false, "A931DocFVcto", context.localUtil.Format(A931DocFVcto, "99/99/9999"));
         A231DocCliCod = "";
         AssignAttri("", false, "A231DocCliCod", A231DocCliCod);
         A887DocCliDsc = "";
         AssignAttri("", false, "A887DocCliDsc", A887DocCliDsc);
         A885DocCliDir = "";
         AssignAttri("", false, "A885DocCliDir", A885DocCliDir);
         A886DocCliDirItem = 0;
         AssignAttri("", false, "A886DocCliDirItem", StringUtil.LTrimStr( (decimal)(A886DocCliDirItem), 6, 0));
         A230DocMonCod = 0;
         AssignAttri("", false, "A230DocMonCod", StringUtil.LTrimStr( (decimal)(A230DocMonCod), 6, 0));
         A229DocConpCod = 0;
         AssignAttri("", false, "A229DocConpCod", StringUtil.LTrimStr( (decimal)(A229DocConpCod), 6, 0));
         A888DocConpDsc = "";
         AssignAttri("", false, "A888DocConpDsc", A888DocConpDsc);
         A904DocDias = 0;
         AssignAttri("", false, "A904DocDias", StringUtil.LTrimStr( (decimal)(A904DocDias), 4, 0));
         A228DocLisp = 0;
         n228DocLisp = false;
         AssignAttri("", false, "A228DocLisp", StringUtil.LTrimStr( (decimal)(A228DocLisp), 6, 0));
         n228DocLisp = ((0==A228DocLisp) ? true : false);
         A920DocSubAfecto = 0;
         AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
         A921DocSubInafecto = 0;
         AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
         A922DocSubSelectivo = 0;
         AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
         A927DocSubExonerado = 0;
         AssignAttri("", false, "A927DocSubExonerado", StringUtil.LTrimStr( A927DocSubExonerado, 15, 4));
         A943DocSubGratuitoIna = 0;
         AssignAttri("", false, "A943DocSubGratuitoIna", StringUtil.LTrimStr( A943DocSubGratuitoIna, 15, 4));
         A942DocSubGratuito = 0;
         AssignAttri("", false, "A942DocSubGratuito", StringUtil.LTrimStr( A942DocSubGratuito, 15, 4));
         A882DocAnticipos = 0;
         AssignAttri("", false, "A882DocAnticipos", StringUtil.LTrimStr( A882DocAnticipos, 15, 4));
         A935DocRedondeo = 0;
         AssignAttri("", false, "A935DocRedondeo", StringUtil.LTrimStr( A935DocRedondeo, 15, 2));
         A899DocDcto = 0;
         AssignAttri("", false, "A899DocDcto", StringUtil.LTrimStr( A899DocDcto, 6, 2));
         A934DocPorIVA = 0;
         AssignAttri("", false, "A934DocPorIVA", StringUtil.LTrimStr( A934DocPorIVA, 6, 2));
         A936DocObs = "";
         AssignAttri("", false, "A936DocObs", A936DocObs);
         A950DocTRef = "";
         AssignAttri("", false, "A950DocTRef", A950DocTRef);
         A939DocRef = "";
         AssignAttri("", false, "A939DocRef", A939DocRef);
         A941DocSts = "";
         AssignAttri("", false, "A941DocSts", A941DocSts);
         A947DocTItem = 0;
         AssignAttri("", false, "A947DocTItem", StringUtil.LTrimStr( A947DocTItem, 15, 2));
         A937DocPedCod = "";
         AssignAttri("", false, "A937DocPedCod", A937DocPedCod);
         A946DocTipo = "";
         AssignAttri("", false, "A946DocTipo", A946DocTipo);
         A929DocFecRef = DateTime.MinValue;
         AssignAttri("", false, "A929DocFecRef", context.localUtil.Format(A929DocFecRef, "99/99/99"));
         A880DocAlmCod = 0;
         AssignAttri("", false, "A880DocAlmCod", StringUtil.LTrimStr( (decimal)(A880DocAlmCod), 6, 0));
         A227DocVendCod = 0;
         AssignAttri("", false, "A227DocVendCod", StringUtil.LTrimStr( (decimal)(A227DocVendCod), 6, 0));
         A953DocVendDsc = "";
         AssignAttri("", false, "A953DocVendDsc", A953DocVendDsc);
         A890DocCosCod = "";
         n890DocCosCod = false;
         AssignAttri("", false, "A890DocCosCod", A890DocCosCod);
         n890DocCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A890DocCosCod)) ? true : false);
         A951DocUsuCod = "";
         AssignAttri("", false, "A951DocUsuCod", A951DocUsuCod);
         A952DocUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A952DocUsuFec", context.localUtil.TToC( A952DocUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A954DocVouAno = 0;
         AssignAttri("", false, "A954DocVouAno", StringUtil.LTrimStr( (decimal)(A954DocVouAno), 4, 0));
         A955DocVouMes = 0;
         AssignAttri("", false, "A955DocVouMes", StringUtil.LTrimStr( (decimal)(A955DocVouMes), 2, 0));
         A944DocTASICod = 0;
         AssignAttri("", false, "A944DocTASICod", StringUtil.LTrimStr( (decimal)(A944DocTASICod), 6, 0));
         A956DocVouNum = "";
         AssignAttri("", false, "A956DocVouNum", A956DocVouNum);
         A226DocMovCod = 0;
         AssignAttri("", false, "A226DocMovCod", StringUtil.LTrimStr( (decimal)(A226DocMovCod), 6, 0));
         A938DocPercepcion = "";
         n938DocPercepcion = false;
         AssignAttri("", false, "A938DocPercepcion", A938DocPercepcion);
         n938DocPercepcion = (String.IsNullOrEmpty(StringUtil.RTrim( A938DocPercepcion)) ? true : false);
         A883DocAplicaAnticipo = 0;
         AssignAttri("", false, "A883DocAplicaAnticipo", StringUtil.LTrimStr( A883DocAplicaAnticipo, 15, 2));
         A884DocCadena = "";
         n884DocCadena = false;
         AssignAttri("", false, "A884DocCadena", A884DocCadena);
         A178TieCod = 0;
         n178TieCod = false;
         AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         A930DocFEOBS = "";
         n930DocFEOBS = false;
         AssignAttri("", false, "A930DocFEOBS", A930DocFEOBS);
         A881DocAnticipo = "";
         AssignAttri("", false, "A881DocAnticipo", A881DocAnticipo);
         A945DocTipAnticipo = "";
         AssignAttri("", false, "A945DocTipAnticipo", A945DocTipAnticipo);
         A879DocAIVA = 0;
         AssignAttri("", false, "A879DocAIVA", StringUtil.Str( (decimal)(A879DocAIVA), 1, 0));
         A511TipSigno = 0;
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
         Z232DocFec = DateTime.MinValue;
         Z931DocFVcto = DateTime.MinValue;
         Z886DocCliDirItem = 0;
         Z882DocAnticipos = 0;
         Z935DocRedondeo = 0;
         Z899DocDcto = 0;
         Z934DocPorIVA = 0;
         Z950DocTRef = "";
         Z939DocRef = "";
         Z941DocSts = "";
         Z947DocTItem = 0;
         Z937DocPedCod = "";
         Z946DocTipo = "";
         Z929DocFecRef = DateTime.MinValue;
         Z880DocAlmCod = 0;
         Z890DocCosCod = "";
         Z951DocUsuCod = "";
         Z952DocUsuFec = (DateTime)(DateTime.MinValue);
         Z954DocVouAno = 0;
         Z955DocVouMes = 0;
         Z944DocTASICod = 0;
         Z956DocVouNum = "";
         Z938DocPercepcion = "";
         Z883DocAplicaAnticipo = 0;
         Z884DocCadena = "";
         Z930DocFEOBS = "";
         Z881DocAnticipo = "";
         Z945DocTipAnticipo = "";
         Z879DocAIVA = 0;
         Z178TieCod = 0;
         Z231DocCliCod = "";
         Z230DocMonCod = 0;
         Z229DocConpCod = 0;
         Z228DocLisp = 0;
         Z227DocVendCod = 0;
         Z226DocMovCod = 0;
      }

      protected void InitAll2Y101( )
      {
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A24DocNum = "";
         n24DocNum = false;
         AssignAttri("", false, "A24DocNum", A24DocNum);
         InitializeNonKey2Y101( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025487", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("clventas.js", "?20228181025488", false, true);
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
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtDocNum_Internalname = "DOCNUM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTipAbr_Internalname = "TIPABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtDocFec_Internalname = "DOCFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtDocFVcto_Internalname = "DOCFVCTO";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtDocCliCod_Internalname = "DOCCLICOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtDocCliDsc_Internalname = "DOCCLIDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtDocCliDir_Internalname = "DOCCLIDIR";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtDocCliDirItem_Internalname = "DOCCLIDIRITEM";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtDocMonCod_Internalname = "DOCMONCOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtDocConpCod_Internalname = "DOCCONPCOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtDocConpDsc_Internalname = "DOCCONPDSC";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtDocDias_Internalname = "DOCDIAS";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtDocLisp_Internalname = "DOCLISP";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtDocSubAfecto_Internalname = "DOCSUBAFECTO";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtDocSubInafecto_Internalname = "DOCSUBINAFECTO";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtDocSubSelectivo_Internalname = "DOCSUBSELECTIVO";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtDocAnticipos_Internalname = "DOCANTICIPOS";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtDocDscto_Internalname = "DOCDSCTO";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtDocSub_Internalname = "DOCSUB";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtDocRedondeo_Internalname = "DOCREDONDEO";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtDocDcto_Internalname = "DOCDCTO";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtDocPorIVA_Internalname = "DOCPORIVA";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtDocIVA_Internalname = "DOCIVA";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtDocTot_Internalname = "DOCTOT";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtDocObs_Internalname = "DOCOBS";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtDocTRef_Internalname = "DOCTREF";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtDocRef_Internalname = "DOCREF";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtDocSts_Internalname = "DOCSTS";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtDocTItem_Internalname = "DOCTITEM";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtDocPedCod_Internalname = "DOCPEDCOD";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtDocTipo_Internalname = "DOCTIPO";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtDocFecRef_Internalname = "DOCFECREF";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtDocAlmCod_Internalname = "DOCALMCOD";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtDocVendCod_Internalname = "DOCVENDCOD";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtDocVendDsc_Internalname = "DOCVENDDSC";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtDocCosCod_Internalname = "DOCCOSCOD";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtDocUsuCod_Internalname = "DOCUSUCOD";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtDocUsuFec_Internalname = "DOCUSUFEC";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtDocVouAno_Internalname = "DOCVOUANO";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtDocVouMes_Internalname = "DOCVOUMES";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         edtDocTASICod_Internalname = "DOCTASICOD";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         edtDocVouNum_Internalname = "DOCVOUNUM";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         edtDocMovCod_Internalname = "DOCMOVCOD";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         edtDocTotSigno_Internalname = "DOCTOTSIGNO";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         edtDocPercepcion_Internalname = "DOCPERCEPCION";
         lblTextblock47_Internalname = "TEXTBLOCK47";
         edtDocAplicaAnticipo_Internalname = "DOCAPLICAANTICIPO";
         lblTextblock48_Internalname = "TEXTBLOCK48";
         edtDocSerie_Internalname = "DOCSERIE";
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
         Form.Caption = "Ventas - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDocSerie_Jsonclick = "";
         edtDocSerie_Enabled = 0;
         edtDocAplicaAnticipo_Jsonclick = "";
         edtDocAplicaAnticipo_Enabled = 1;
         edtDocPercepcion_Jsonclick = "";
         edtDocPercepcion_Enabled = 1;
         edtDocTotSigno_Jsonclick = "";
         edtDocTotSigno_Enabled = 0;
         edtDocMovCod_Jsonclick = "";
         edtDocMovCod_Enabled = 1;
         edtDocVouNum_Jsonclick = "";
         edtDocVouNum_Enabled = 1;
         edtDocTASICod_Jsonclick = "";
         edtDocTASICod_Enabled = 1;
         edtDocVouMes_Jsonclick = "";
         edtDocVouMes_Enabled = 1;
         edtDocVouAno_Jsonclick = "";
         edtDocVouAno_Enabled = 1;
         edtDocUsuFec_Jsonclick = "";
         edtDocUsuFec_Enabled = 1;
         edtDocUsuCod_Jsonclick = "";
         edtDocUsuCod_Enabled = 1;
         edtDocCosCod_Jsonclick = "";
         edtDocCosCod_Enabled = 1;
         edtDocVendDsc_Jsonclick = "";
         edtDocVendDsc_Enabled = 0;
         edtDocVendCod_Jsonclick = "";
         edtDocVendCod_Enabled = 1;
         edtDocAlmCod_Jsonclick = "";
         edtDocAlmCod_Enabled = 1;
         edtDocFecRef_Jsonclick = "";
         edtDocFecRef_Enabled = 1;
         edtDocTipo_Jsonclick = "";
         edtDocTipo_Enabled = 1;
         edtDocPedCod_Jsonclick = "";
         edtDocPedCod_Enabled = 1;
         edtDocTItem_Jsonclick = "";
         edtDocTItem_Enabled = 1;
         edtDocSts_Jsonclick = "";
         edtDocSts_Enabled = 1;
         edtDocRef_Jsonclick = "";
         edtDocRef_Enabled = 1;
         edtDocTRef_Jsonclick = "";
         edtDocTRef_Enabled = 1;
         edtDocObs_Enabled = 1;
         edtDocTot_Jsonclick = "";
         edtDocTot_Enabled = 0;
         edtDocIVA_Jsonclick = "";
         edtDocIVA_Enabled = 0;
         edtDocPorIVA_Jsonclick = "";
         edtDocPorIVA_Enabled = 1;
         edtDocDcto_Jsonclick = "";
         edtDocDcto_Enabled = 1;
         edtDocRedondeo_Jsonclick = "";
         edtDocRedondeo_Enabled = 1;
         edtDocSub_Jsonclick = "";
         edtDocSub_Enabled = 0;
         edtDocDscto_Jsonclick = "";
         edtDocDscto_Enabled = 0;
         edtDocAnticipos_Jsonclick = "";
         edtDocAnticipos_Enabled = 1;
         edtDocSubSelectivo_Jsonclick = "";
         edtDocSubSelectivo_Enabled = 0;
         edtDocSubInafecto_Jsonclick = "";
         edtDocSubInafecto_Enabled = 0;
         edtDocSubAfecto_Jsonclick = "";
         edtDocSubAfecto_Enabled = 0;
         edtDocLisp_Jsonclick = "";
         edtDocLisp_Enabled = 1;
         edtDocDias_Jsonclick = "";
         edtDocDias_Enabled = 0;
         edtDocConpDsc_Jsonclick = "";
         edtDocConpDsc_Enabled = 0;
         edtDocConpCod_Jsonclick = "";
         edtDocConpCod_Enabled = 1;
         edtDocMonCod_Jsonclick = "";
         edtDocMonCod_Enabled = 1;
         edtDocCliDirItem_Jsonclick = "";
         edtDocCliDirItem_Enabled = 1;
         edtDocCliDir_Jsonclick = "";
         edtDocCliDir_Enabled = 0;
         edtDocCliDsc_Jsonclick = "";
         edtDocCliDsc_Enabled = 0;
         edtDocCliCod_Jsonclick = "";
         edtDocCliCod_Enabled = 1;
         edtDocFVcto_Jsonclick = "";
         edtDocFVcto_Enabled = 1;
         edtDocFec_Jsonclick = "";
         edtDocFec_Enabled = 1;
         edtTipAbr_Jsonclick = "";
         edtTipAbr_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtDocNum_Jsonclick = "";
         edtDocNum_Enabled = 1;
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
         /* Using cursor T002Y31 */
         pr_default.execute(26, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A306TipAbr = T002Y31_A306TipAbr[0];
         AssignAttri("", false, "A306TipAbr", A306TipAbr);
         A511TipSigno = T002Y31_A511TipSigno[0];
         pr_default.close(26);
         /* Using cursor T002Y33 */
         pr_default.execute(27, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A932DocICBPER = T002Y33_A932DocICBPER[0];
            A920DocSubAfecto = T002Y33_A920DocSubAfecto[0];
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = T002Y33_A921DocSubInafecto[0];
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = T002Y33_A922DocSubSelectivo[0];
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            A927DocSubExonerado = T002Y33_A927DocSubExonerado[0];
            A943DocSubGratuitoIna = T002Y33_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = T002Y33_A942DocSubGratuito[0];
         }
         else
         {
            A932DocICBPER = 0;
            AssignAttri("", false, "A932DocICBPER", StringUtil.LTrimStr( A932DocICBPER, 15, 2));
            A920DocSubAfecto = 0;
            AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrimStr( A920DocSubAfecto, 15, 4));
            A921DocSubInafecto = 0;
            AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrimStr( A921DocSubInafecto, 15, 4));
            A922DocSubSelectivo = 0;
            AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrimStr( A922DocSubSelectivo, 15, 4));
            A927DocSubExonerado = 0;
            AssignAttri("", false, "A927DocSubExonerado", StringUtil.LTrimStr( A927DocSubExonerado, 15, 4));
            A943DocSubGratuitoIna = 0;
            AssignAttri("", false, "A943DocSubGratuitoIna", StringUtil.LTrimStr( A943DocSubGratuitoIna, 15, 4));
            A942DocSubGratuito = 0;
            AssignAttri("", false, "A942DocSubGratuito", StringUtil.LTrimStr( A942DocSubGratuito, 15, 4));
         }
         pr_default.close(27);
         GX_FocusControl = edtDocFec_Internalname;
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
         /* Using cursor T002Y31 */
         pr_default.execute(26, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         A306TipAbr = T002Y31_A306TipAbr[0];
         A511TipSigno = T002Y31_A511TipSigno[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A306TipAbr", StringUtil.RTrim( A306TipAbr));
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
      }

      public void Valid_Docnum( )
      {
         n930DocFEOBS = false;
         n884DocCadena = false;
         n24DocNum = false;
         n178TieCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002Y33 */
         pr_default.execute(27, new Object[] {A149TipCod, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A932DocICBPER = T002Y33_A932DocICBPER[0];
            A920DocSubAfecto = T002Y33_A920DocSubAfecto[0];
            A921DocSubInafecto = T002Y33_A921DocSubInafecto[0];
            A922DocSubSelectivo = T002Y33_A922DocSubSelectivo[0];
            A927DocSubExonerado = T002Y33_A927DocSubExonerado[0];
            A943DocSubGratuitoIna = T002Y33_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = T002Y33_A942DocSubGratuito[0];
         }
         else
         {
            A932DocICBPER = 0;
            A920DocSubAfecto = 0;
            A921DocSubInafecto = 0;
            A922DocSubSelectivo = 0;
            A927DocSubExonerado = 0;
            A943DocSubGratuitoIna = 0;
            A942DocSubGratuito = 0;
         }
         pr_default.close(27);
         A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
         A940DocSerie = StringUtil.Substring( A24DocNum, 1, 3);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A232DocFec", context.localUtil.Format(A232DocFec, "99/99/99"));
         AssignAttri("", false, "A931DocFVcto", context.localUtil.Format(A931DocFVcto, "99/99/9999"));
         AssignAttri("", false, "A231DocCliCod", StringUtil.RTrim( A231DocCliCod));
         AssignAttri("", false, "A886DocCliDirItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A886DocCliDirItem), 6, 0, ".", "")));
         AssignAttri("", false, "A230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A230DocMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A229DocConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A229DocConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A228DocLisp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A228DocLisp), 6, 0, ".", "")));
         AssignAttri("", false, "A882DocAnticipos", StringUtil.LTrim( StringUtil.NToC( A882DocAnticipos, 15, 4, ".", "")));
         AssignAttri("", false, "A935DocRedondeo", StringUtil.LTrim( StringUtil.NToC( A935DocRedondeo, 15, 2, ".", "")));
         AssignAttri("", false, "A899DocDcto", StringUtil.LTrim( StringUtil.NToC( A899DocDcto, 6, 2, ".", "")));
         AssignAttri("", false, "A934DocPorIVA", StringUtil.LTrim( StringUtil.NToC( A934DocPorIVA, 6, 2, ".", "")));
         AssignAttri("", false, "A936DocObs", A936DocObs);
         AssignAttri("", false, "A950DocTRef", StringUtil.RTrim( A950DocTRef));
         AssignAttri("", false, "A939DocRef", StringUtil.RTrim( A939DocRef));
         AssignAttri("", false, "A941DocSts", StringUtil.RTrim( A941DocSts));
         AssignAttri("", false, "A947DocTItem", StringUtil.LTrim( StringUtil.NToC( A947DocTItem, 15, 2, ".", "")));
         AssignAttri("", false, "A937DocPedCod", StringUtil.RTrim( A937DocPedCod));
         AssignAttri("", false, "A946DocTipo", StringUtil.RTrim( A946DocTipo));
         AssignAttri("", false, "A929DocFecRef", context.localUtil.Format(A929DocFecRef, "99/99/99"));
         AssignAttri("", false, "A880DocAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A880DocAlmCod), 6, 0, ".", "")));
         AssignAttri("", false, "A227DocVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A227DocVendCod), 6, 0, ".", "")));
         AssignAttri("", false, "A890DocCosCod", StringUtil.RTrim( A890DocCosCod));
         AssignAttri("", false, "A951DocUsuCod", StringUtil.RTrim( A951DocUsuCod));
         AssignAttri("", false, "A952DocUsuFec", context.localUtil.TToC( A952DocUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A954DocVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A954DocVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A955DocVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A955DocVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A944DocTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A944DocTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A956DocVouNum", StringUtil.RTrim( A956DocVouNum));
         AssignAttri("", false, "A226DocMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A226DocMovCod), 6, 0, ".", "")));
         AssignAttri("", false, "A938DocPercepcion", StringUtil.RTrim( A938DocPercepcion));
         AssignAttri("", false, "A883DocAplicaAnticipo", StringUtil.LTrim( StringUtil.NToC( A883DocAplicaAnticipo, 15, 2, ".", "")));
         AssignAttri("", false, "A884DocCadena", A884DocCadena);
         AssignAttri("", false, "A178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")));
         AssignAttri("", false, "A930DocFEOBS", A930DocFEOBS);
         AssignAttri("", false, "A881DocAnticipo", StringUtil.RTrim( A881DocAnticipo));
         AssignAttri("", false, "A945DocTipAnticipo", StringUtil.RTrim( A945DocTipAnticipo));
         AssignAttri("", false, "A879DocAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A879DocAIVA), 1, 0, ".", "")));
         AssignAttri("", false, "A306TipAbr", StringUtil.RTrim( A306TipAbr));
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         AssignAttri("", false, "A932DocICBPER", StringUtil.LTrim( StringUtil.NToC( A932DocICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A920DocSubAfecto", StringUtil.LTrim( StringUtil.NToC( A920DocSubAfecto, 15, 4, ".", "")));
         AssignAttri("", false, "A921DocSubInafecto", StringUtil.LTrim( StringUtil.NToC( A921DocSubInafecto, 15, 4, ".", "")));
         AssignAttri("", false, "A922DocSubSelectivo", StringUtil.LTrim( StringUtil.NToC( A922DocSubSelectivo, 15, 4, ".", "")));
         AssignAttri("", false, "A927DocSubExonerado", StringUtil.LTrim( StringUtil.NToC( A927DocSubExonerado, 15, 4, ".", "")));
         AssignAttri("", false, "A943DocSubGratuitoIna", StringUtil.LTrim( StringUtil.NToC( A943DocSubGratuitoIna, 15, 4, ".", "")));
         AssignAttri("", false, "A942DocSubGratuito", StringUtil.LTrim( StringUtil.NToC( A942DocSubGratuito, 15, 4, ".", "")));
         AssignAttri("", false, "A919DocSub", StringUtil.LTrim( StringUtil.NToC( A919DocSub, 15, 4, ".", "")));
         AssignAttri("", false, "A918DocDscto", StringUtil.LTrim( StringUtil.NToC( A918DocDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A933DocIVA", StringUtil.LTrim( StringUtil.NToC( A933DocIVA, 15, 2, ".", "")));
         AssignAttri("", false, "A948DocTot", StringUtil.LTrim( StringUtil.NToC( A948DocTot, 15, 2, ".", "")));
         AssignAttri("", false, "A949DocTotSigno", StringUtil.LTrim( StringUtil.NToC( A949DocTotSigno, 15, 2, ".", "")));
         AssignAttri("", false, "A940DocSerie", A940DocSerie);
         AssignAttri("", false, "A887DocCliDsc", StringUtil.RTrim( A887DocCliDsc));
         AssignAttri("", false, "A885DocCliDir", StringUtil.RTrim( A885DocCliDir));
         AssignAttri("", false, "A888DocConpDsc", StringUtil.RTrim( A888DocConpDsc));
         AssignAttri("", false, "A904DocDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A904DocDias), 4, 0, ".", "")));
         AssignAttri("", false, "A953DocVendDsc", StringUtil.RTrim( A953DocVendDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z232DocFec", context.localUtil.Format(Z232DocFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z931DocFVcto", context.localUtil.Format(Z931DocFVcto, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z231DocCliCod", StringUtil.RTrim( Z231DocCliCod));
         GxWebStd.gx_hidden_field( context, "Z886DocCliDirItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z886DocCliDirItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z230DocMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z230DocMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z229DocConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z229DocConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z228DocLisp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z228DocLisp), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z882DocAnticipos", StringUtil.LTrim( StringUtil.NToC( Z882DocAnticipos, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z935DocRedondeo", StringUtil.LTrim( StringUtil.NToC( Z935DocRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z899DocDcto", StringUtil.LTrim( StringUtil.NToC( Z899DocDcto, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z934DocPorIVA", StringUtil.LTrim( StringUtil.NToC( Z934DocPorIVA, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z936DocObs", Z936DocObs);
         GxWebStd.gx_hidden_field( context, "Z950DocTRef", StringUtil.RTrim( Z950DocTRef));
         GxWebStd.gx_hidden_field( context, "Z939DocRef", StringUtil.RTrim( Z939DocRef));
         GxWebStd.gx_hidden_field( context, "Z941DocSts", StringUtil.RTrim( Z941DocSts));
         GxWebStd.gx_hidden_field( context, "Z947DocTItem", StringUtil.LTrim( StringUtil.NToC( Z947DocTItem, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z937DocPedCod", StringUtil.RTrim( Z937DocPedCod));
         GxWebStd.gx_hidden_field( context, "Z946DocTipo", StringUtil.RTrim( Z946DocTipo));
         GxWebStd.gx_hidden_field( context, "Z929DocFecRef", context.localUtil.Format(Z929DocFecRef, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z880DocAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z880DocAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z227DocVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227DocVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z890DocCosCod", StringUtil.RTrim( Z890DocCosCod));
         GxWebStd.gx_hidden_field( context, "Z951DocUsuCod", StringUtil.RTrim( Z951DocUsuCod));
         GxWebStd.gx_hidden_field( context, "Z952DocUsuFec", context.localUtil.TToC( Z952DocUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z954DocVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z954DocVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z955DocVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z955DocVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z944DocTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z944DocTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z956DocVouNum", StringUtil.RTrim( Z956DocVouNum));
         GxWebStd.gx_hidden_field( context, "Z226DocMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z226DocMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z938DocPercepcion", StringUtil.RTrim( Z938DocPercepcion));
         GxWebStd.gx_hidden_field( context, "Z883DocAplicaAnticipo", StringUtil.LTrim( StringUtil.NToC( Z883DocAplicaAnticipo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z884DocCadena", Z884DocCadena);
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z930DocFEOBS", Z930DocFEOBS);
         GxWebStd.gx_hidden_field( context, "Z881DocAnticipo", StringUtil.RTrim( Z881DocAnticipo));
         GxWebStd.gx_hidden_field( context, "Z945DocTipAnticipo", StringUtil.RTrim( Z945DocTipAnticipo));
         GxWebStd.gx_hidden_field( context, "Z879DocAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z879DocAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z306TipAbr", StringUtil.RTrim( Z306TipAbr));
         GxWebStd.gx_hidden_field( context, "Z511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z932DocICBPER", StringUtil.LTrim( StringUtil.NToC( Z932DocICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z920DocSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z920DocSubAfecto, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z921DocSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z921DocSubInafecto, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z922DocSubSelectivo", StringUtil.LTrim( StringUtil.NToC( Z922DocSubSelectivo, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z927DocSubExonerado", StringUtil.LTrim( StringUtil.NToC( Z927DocSubExonerado, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z943DocSubGratuitoIna", StringUtil.LTrim( StringUtil.NToC( Z943DocSubGratuitoIna, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z942DocSubGratuito", StringUtil.LTrim( StringUtil.NToC( Z942DocSubGratuito, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z919DocSub", StringUtil.LTrim( StringUtil.NToC( Z919DocSub, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z918DocDscto", StringUtil.LTrim( StringUtil.NToC( Z918DocDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z933DocIVA", StringUtil.LTrim( StringUtil.NToC( Z933DocIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z948DocTot", StringUtil.LTrim( StringUtil.NToC( Z948DocTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z949DocTotSigno", StringUtil.LTrim( StringUtil.NToC( Z949DocTotSigno, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z940DocSerie", Z940DocSerie);
         GxWebStd.gx_hidden_field( context, "Z887DocCliDsc", StringUtil.RTrim( Z887DocCliDsc));
         GxWebStd.gx_hidden_field( context, "Z885DocCliDir", StringUtil.RTrim( Z885DocCliDir));
         GxWebStd.gx_hidden_field( context, "Z888DocConpDsc", StringUtil.RTrim( Z888DocConpDsc));
         GxWebStd.gx_hidden_field( context, "Z904DocDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z904DocDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z953DocVendDsc", StringUtil.RTrim( Z953DocVendDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Docclicod( )
      {
         /* Using cursor T002Y34 */
         pr_default.execute(28, new Object[] {A231DocCliCod});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "DOCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtDocCliCod_Internalname;
         }
         A887DocCliDsc = T002Y34_A887DocCliDsc[0];
         A885DocCliDir = T002Y34_A885DocCliDir[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A887DocCliDsc", StringUtil.RTrim( A887DocCliDsc));
         AssignAttri("", false, "A885DocCliDir", StringUtil.RTrim( A885DocCliDir));
      }

      public void Valid_Docmoncod( )
      {
         /* Using cursor T002Y41 */
         pr_default.execute(35, new Object[] {A230DocMonCod});
         if ( (pr_default.getStatus(35) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "DOCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtDocMonCod_Internalname;
         }
         pr_default.close(35);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Docconpcod( )
      {
         /* Using cursor T002Y35 */
         pr_default.execute(29, new Object[] {A229DocConpCod});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Venta'.", "ForeignKeyNotFound", 1, "DOCCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtDocConpCod_Internalname;
         }
         A888DocConpDsc = T002Y35_A888DocConpDsc[0];
         A904DocDias = T002Y35_A904DocDias[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A888DocConpDsc", StringUtil.RTrim( A888DocConpDsc));
         AssignAttri("", false, "A904DocDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A904DocDias), 4, 0, ".", "")));
      }

      public void Valid_Doclisp( )
      {
         n228DocLisp = false;
         /* Using cursor T002Y42 */
         pr_default.execute(36, new Object[] {n228DocLisp, A228DocLisp});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( (0==A228DocLisp) ) )
            {
               GX_msglist.addItem("No existe 'Sub Lista Precios Venta'.", "ForeignKeyNotFound", 1, "DOCLISP");
               AnyError = 1;
               GX_FocusControl = edtDocLisp_Internalname;
            }
         }
         pr_default.close(36);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Docvendcod( )
      {
         /* Using cursor T002Y36 */
         pr_default.execute(30, new Object[] {A227DocVendCod});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "DOCVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtDocVendCod_Internalname;
         }
         A953DocVendDsc = T002Y36_A953DocVendDsc[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A953DocVendDsc", StringUtil.RTrim( A953DocVendDsc));
      }

      public void Valid_Docmovcod( )
      {
         /* Using cursor T002Y43 */
         pr_default.execute(37, new Object[] {A226DocMovCod});
         if ( (pr_default.getStatus(37) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Venta Tipo Movimiento'.", "ForeignKeyNotFound", 1, "DOCMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtDocMovCod_Internalname;
         }
         pr_default.close(37);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A884DocCadena',fld:'DOCCADENA',pic:''},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'A930DocFEOBS',fld:'DOCFEOBS',pic:''},{av:'A881DocAnticipo',fld:'DOCANTICIPO',pic:''},{av:'A945DocTipAnticipo',fld:'DOCTIPANTICIPO',pic:''},{av:'A879DocAIVA',fld:'DOCAIVA',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A306TipAbr',fld:'TIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[{av:'A306TipAbr',fld:'TIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]}");
         setEventMetadata("VALID_DOCNUM","{handler:'Valid_Docnum',iparms:[{av:'A879DocAIVA',fld:'DOCAIVA',pic:'9'},{av:'A945DocTipAnticipo',fld:'DOCTIPANTICIPO',pic:''},{av:'A881DocAnticipo',fld:'DOCANTICIPO',pic:''},{av:'A930DocFEOBS',fld:'DOCFEOBS',pic:''},{av:'A884DocCadena',fld:'DOCCADENA',pic:''},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''},{av:'A920DocSubAfecto',fld:'DOCSUBAFECTO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A921DocSubInafecto',fld:'DOCSUBINAFECTO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A922DocSubSelectivo',fld:'DOCSUBSELECTIVO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A927DocSubExonerado',fld:'DOCSUBEXONERADO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DOCNUM",",oparms:[{av:'A232DocFec',fld:'DOCFEC',pic:''},{av:'A931DocFVcto',fld:'DOCFVCTO',pic:''},{av:'A231DocCliCod',fld:'DOCCLICOD',pic:''},{av:'A886DocCliDirItem',fld:'DOCCLIDIRITEM',pic:'ZZZZZ9'},{av:'A230DocMonCod',fld:'DOCMONCOD',pic:'ZZZZZ9'},{av:'A229DocConpCod',fld:'DOCCONPCOD',pic:'ZZZZZ9'},{av:'A228DocLisp',fld:'DOCLISP',pic:'ZZZZZ9'},{av:'A882DocAnticipos',fld:'DOCANTICIPOS',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A935DocRedondeo',fld:'DOCREDONDEO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A899DocDcto',fld:'DOCDCTO',pic:'ZZ9.99'},{av:'A934DocPorIVA',fld:'DOCPORIVA',pic:'ZZ9.99'},{av:'A936DocObs',fld:'DOCOBS',pic:''},{av:'A950DocTRef',fld:'DOCTREF',pic:''},{av:'A939DocRef',fld:'DOCREF',pic:''},{av:'A941DocSts',fld:'DOCSTS',pic:''},{av:'A947DocTItem',fld:'DOCTITEM',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A937DocPedCod',fld:'DOCPEDCOD',pic:''},{av:'A946DocTipo',fld:'DOCTIPO',pic:''},{av:'A929DocFecRef',fld:'DOCFECREF',pic:''},{av:'A880DocAlmCod',fld:'DOCALMCOD',pic:'ZZZZZ9'},{av:'A227DocVendCod',fld:'DOCVENDCOD',pic:'ZZZZZ9'},{av:'A890DocCosCod',fld:'DOCCOSCOD',pic:''},{av:'A951DocUsuCod',fld:'DOCUSUCOD',pic:''},{av:'A952DocUsuFec',fld:'DOCUSUFEC',pic:'99/99/99 99:99'},{av:'A954DocVouAno',fld:'DOCVOUANO',pic:'ZZZ9'},{av:'A955DocVouMes',fld:'DOCVOUMES',pic:'Z9'},{av:'A944DocTASICod',fld:'DOCTASICOD',pic:'ZZZZZ9'},{av:'A956DocVouNum',fld:'DOCVOUNUM',pic:''},{av:'A226DocMovCod',fld:'DOCMOVCOD',pic:'ZZZZZ9'},{av:'A938DocPercepcion',fld:'DOCPERCEPCION',pic:''},{av:'A883DocAplicaAnticipo',fld:'DOCAPLICAANTICIPO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A884DocCadena',fld:'DOCCADENA',pic:''},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'A930DocFEOBS',fld:'DOCFEOBS',pic:''},{av:'A881DocAnticipo',fld:'DOCANTICIPO',pic:''},{av:'A945DocTipAnticipo',fld:'DOCTIPANTICIPO',pic:''},{av:'A879DocAIVA',fld:'DOCAIVA',pic:'9'},{av:'A306TipAbr',fld:'TIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'},{av:'A932DocICBPER',fld:'DOCICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A920DocSubAfecto',fld:'DOCSUBAFECTO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A921DocSubInafecto',fld:'DOCSUBINAFECTO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A922DocSubSelectivo',fld:'DOCSUBSELECTIVO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A927DocSubExonerado',fld:'DOCSUBEXONERADO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A943DocSubGratuitoIna',fld:'DOCSUBGRATUITOINA',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A942DocSubGratuito',fld:'DOCSUBGRATUITO',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A919DocSub',fld:'DOCSUB',pic:'ZZZZ,ZZZ,ZZ9.99'},{av:'A918DocDscto',fld:'DOCDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A933DocIVA',fld:'DOCIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A948DocTot',fld:'DOCTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A949DocTotSigno',fld:'DOCTOTSIGNO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A940DocSerie',fld:'DOCSERIE',pic:''},{av:'A887DocCliDsc',fld:'DOCCLIDSC',pic:''},{av:'A885DocCliDir',fld:'DOCCLIDIR',pic:''},{av:'A888DocConpDsc',fld:'DOCCONPDSC',pic:''},{av:'A904DocDias',fld:'DOCDIAS',pic:'ZZZ9'},{av:'A953DocVendDsc',fld:'DOCVENDDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z149TipCod'},{av:'Z24DocNum'},{av:'Z232DocFec'},{av:'Z931DocFVcto'},{av:'Z231DocCliCod'},{av:'Z886DocCliDirItem'},{av:'Z230DocMonCod'},{av:'Z229DocConpCod'},{av:'Z228DocLisp'},{av:'Z882DocAnticipos'},{av:'Z935DocRedondeo'},{av:'Z899DocDcto'},{av:'Z934DocPorIVA'},{av:'Z936DocObs'},{av:'Z950DocTRef'},{av:'Z939DocRef'},{av:'Z941DocSts'},{av:'Z947DocTItem'},{av:'Z937DocPedCod'},{av:'Z946DocTipo'},{av:'Z929DocFecRef'},{av:'Z880DocAlmCod'},{av:'Z227DocVendCod'},{av:'Z890DocCosCod'},{av:'Z951DocUsuCod'},{av:'Z952DocUsuFec'},{av:'Z954DocVouAno'},{av:'Z955DocVouMes'},{av:'Z944DocTASICod'},{av:'Z956DocVouNum'},{av:'Z226DocMovCod'},{av:'Z938DocPercepcion'},{av:'Z883DocAplicaAnticipo'},{av:'Z884DocCadena'},{av:'Z178TieCod'},{av:'Z930DocFEOBS'},{av:'Z881DocAnticipo'},{av:'Z945DocTipAnticipo'},{av:'Z879DocAIVA'},{av:'Z306TipAbr'},{av:'Z511TipSigno'},{av:'Z932DocICBPER'},{av:'Z920DocSubAfecto'},{av:'Z921DocSubInafecto'},{av:'Z922DocSubSelectivo'},{av:'Z927DocSubExonerado'},{av:'Z943DocSubGratuitoIna'},{av:'Z942DocSubGratuito'},{av:'Z919DocSub'},{av:'Z918DocDscto'},{av:'Z933DocIVA'},{av:'Z948DocTot'},{av:'Z949DocTotSigno'},{av:'Z940DocSerie'},{av:'Z887DocCliDsc'},{av:'Z885DocCliDir'},{av:'Z888DocConpDsc'},{av:'Z904DocDias'},{av:'Z953DocVendDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_DOCFEC","{handler:'Valid_Docfec',iparms:[]");
         setEventMetadata("VALID_DOCFEC",",oparms:[]}");
         setEventMetadata("VALID_DOCFVCTO","{handler:'Valid_Docfvcto',iparms:[]");
         setEventMetadata("VALID_DOCFVCTO",",oparms:[]}");
         setEventMetadata("VALID_DOCCLICOD","{handler:'Valid_Docclicod',iparms:[{av:'A231DocCliCod',fld:'DOCCLICOD',pic:''},{av:'A887DocCliDsc',fld:'DOCCLIDSC',pic:''},{av:'A885DocCliDir',fld:'DOCCLIDIR',pic:''}]");
         setEventMetadata("VALID_DOCCLICOD",",oparms:[{av:'A887DocCliDsc',fld:'DOCCLIDSC',pic:''},{av:'A885DocCliDir',fld:'DOCCLIDIR',pic:''}]}");
         setEventMetadata("VALID_DOCMONCOD","{handler:'Valid_Docmoncod',iparms:[{av:'A230DocMonCod',fld:'DOCMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_DOCMONCOD",",oparms:[]}");
         setEventMetadata("VALID_DOCCONPCOD","{handler:'Valid_Docconpcod',iparms:[{av:'A229DocConpCod',fld:'DOCCONPCOD',pic:'ZZZZZ9'},{av:'A888DocConpDsc',fld:'DOCCONPDSC',pic:''},{av:'A904DocDias',fld:'DOCDIAS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_DOCCONPCOD",",oparms:[{av:'A888DocConpDsc',fld:'DOCCONPDSC',pic:''},{av:'A904DocDias',fld:'DOCDIAS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_DOCLISP","{handler:'Valid_Doclisp',iparms:[{av:'A228DocLisp',fld:'DOCLISP',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_DOCLISP",",oparms:[]}");
         setEventMetadata("VALID_DOCSUBAFECTO","{handler:'Valid_Docsubafecto',iparms:[]");
         setEventMetadata("VALID_DOCSUBAFECTO",",oparms:[]}");
         setEventMetadata("VALID_DOCSUBINAFECTO","{handler:'Valid_Docsubinafecto',iparms:[]");
         setEventMetadata("VALID_DOCSUBINAFECTO",",oparms:[]}");
         setEventMetadata("VALID_DOCSUBSELECTIVO","{handler:'Valid_Docsubselectivo',iparms:[]");
         setEventMetadata("VALID_DOCSUBSELECTIVO",",oparms:[]}");
         setEventMetadata("VALID_DOCANTICIPOS","{handler:'Valid_Docanticipos',iparms:[]");
         setEventMetadata("VALID_DOCANTICIPOS",",oparms:[]}");
         setEventMetadata("VALID_DOCDSCTO","{handler:'Valid_Docdscto',iparms:[]");
         setEventMetadata("VALID_DOCDSCTO",",oparms:[]}");
         setEventMetadata("VALID_DOCSUB","{handler:'Valid_Docsub',iparms:[]");
         setEventMetadata("VALID_DOCSUB",",oparms:[]}");
         setEventMetadata("VALID_DOCREDONDEO","{handler:'Valid_Docredondeo',iparms:[]");
         setEventMetadata("VALID_DOCREDONDEO",",oparms:[]}");
         setEventMetadata("VALID_DOCDCTO","{handler:'Valid_Docdcto',iparms:[]");
         setEventMetadata("VALID_DOCDCTO",",oparms:[]}");
         setEventMetadata("VALID_DOCPORIVA","{handler:'Valid_Docporiva',iparms:[]");
         setEventMetadata("VALID_DOCPORIVA",",oparms:[]}");
         setEventMetadata("VALID_DOCIVA","{handler:'Valid_Dociva',iparms:[]");
         setEventMetadata("VALID_DOCIVA",",oparms:[]}");
         setEventMetadata("VALID_DOCTOT","{handler:'Valid_Doctot',iparms:[]");
         setEventMetadata("VALID_DOCTOT",",oparms:[]}");
         setEventMetadata("VALID_DOCFECREF","{handler:'Valid_Docfecref',iparms:[]");
         setEventMetadata("VALID_DOCFECREF",",oparms:[]}");
         setEventMetadata("VALID_DOCVENDCOD","{handler:'Valid_Docvendcod',iparms:[{av:'A227DocVendCod',fld:'DOCVENDCOD',pic:'ZZZZZ9'},{av:'A953DocVendDsc',fld:'DOCVENDDSC',pic:''}]");
         setEventMetadata("VALID_DOCVENDCOD",",oparms:[{av:'A953DocVendDsc',fld:'DOCVENDDSC',pic:''}]}");
         setEventMetadata("VALID_DOCUSUFEC","{handler:'Valid_Docusufec',iparms:[]");
         setEventMetadata("VALID_DOCUSUFEC",",oparms:[]}");
         setEventMetadata("VALID_DOCMOVCOD","{handler:'Valid_Docmovcod',iparms:[{av:'A226DocMovCod',fld:'DOCMOVCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_DOCMOVCOD",",oparms:[]}");
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
         pr_default.close(26);
         pr_default.close(28);
         pr_default.close(35);
         pr_default.close(29);
         pr_default.close(36);
         pr_default.close(30);
         pr_default.close(37);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z149TipCod = "";
         Z24DocNum = "";
         Z232DocFec = DateTime.MinValue;
         Z931DocFVcto = DateTime.MinValue;
         Z950DocTRef = "";
         Z939DocRef = "";
         Z941DocSts = "";
         Z937DocPedCod = "";
         Z946DocTipo = "";
         Z929DocFecRef = DateTime.MinValue;
         Z890DocCosCod = "";
         Z951DocUsuCod = "";
         Z952DocUsuFec = (DateTime)(DateTime.MinValue);
         Z956DocVouNum = "";
         Z938DocPercepcion = "";
         Z884DocCadena = "";
         Z930DocFEOBS = "";
         Z881DocAnticipo = "";
         Z945DocTipAnticipo = "";
         Z231DocCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A149TipCod = "";
         A24DocNum = "";
         A231DocCliCod = "";
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
         A306TipAbr = "";
         lblTextblock4_Jsonclick = "";
         A232DocFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A931DocFVcto = DateTime.MinValue;
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A887DocCliDsc = "";
         lblTextblock8_Jsonclick = "";
         A885DocCliDir = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A888DocConpDsc = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         A936DocObs = "";
         lblTextblock27_Jsonclick = "";
         A950DocTRef = "";
         lblTextblock28_Jsonclick = "";
         A939DocRef = "";
         lblTextblock29_Jsonclick = "";
         A941DocSts = "";
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         A937DocPedCod = "";
         lblTextblock32_Jsonclick = "";
         A946DocTipo = "";
         lblTextblock33_Jsonclick = "";
         A929DocFecRef = DateTime.MinValue;
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
         A953DocVendDsc = "";
         lblTextblock37_Jsonclick = "";
         A890DocCosCod = "";
         lblTextblock38_Jsonclick = "";
         A951DocUsuCod = "";
         lblTextblock39_Jsonclick = "";
         A952DocUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock40_Jsonclick = "";
         lblTextblock41_Jsonclick = "";
         lblTextblock42_Jsonclick = "";
         lblTextblock43_Jsonclick = "";
         A956DocVouNum = "";
         lblTextblock44_Jsonclick = "";
         lblTextblock45_Jsonclick = "";
         lblTextblock46_Jsonclick = "";
         A938DocPercepcion = "";
         lblTextblock47_Jsonclick = "";
         lblTextblock48_Jsonclick = "";
         A940DocSerie = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A884DocCadena = "";
         A930DocFEOBS = "";
         A881DocAnticipo = "";
         A945DocTipAnticipo = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z936DocObs = "";
         Z306TipAbr = "";
         Z887DocCliDsc = "";
         Z885DocCliDir = "";
         Z888DocConpDsc = "";
         Z953DocVendDsc = "";
         T002Y5_A178TieCod = new int[1] ;
         T002Y5_n178TieCod = new bool[] {false} ;
         T002Y15_A24DocNum = new string[] {""} ;
         T002Y15_n24DocNum = new bool[] {false} ;
         T002Y15_A306TipAbr = new string[] {""} ;
         T002Y15_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         T002Y15_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         T002Y15_A887DocCliDsc = new string[] {""} ;
         T002Y15_A885DocCliDir = new string[] {""} ;
         T002Y15_A886DocCliDirItem = new int[1] ;
         T002Y15_A888DocConpDsc = new string[] {""} ;
         T002Y15_A904DocDias = new short[1] ;
         T002Y15_A882DocAnticipos = new decimal[1] ;
         T002Y15_A935DocRedondeo = new decimal[1] ;
         T002Y15_A899DocDcto = new decimal[1] ;
         T002Y15_A934DocPorIVA = new decimal[1] ;
         T002Y15_A936DocObs = new string[] {""} ;
         T002Y15_A950DocTRef = new string[] {""} ;
         T002Y15_A939DocRef = new string[] {""} ;
         T002Y15_A941DocSts = new string[] {""} ;
         T002Y15_A947DocTItem = new decimal[1] ;
         T002Y15_A937DocPedCod = new string[] {""} ;
         T002Y15_A946DocTipo = new string[] {""} ;
         T002Y15_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         T002Y15_A880DocAlmCod = new int[1] ;
         T002Y15_A953DocVendDsc = new string[] {""} ;
         T002Y15_A890DocCosCod = new string[] {""} ;
         T002Y15_n890DocCosCod = new bool[] {false} ;
         T002Y15_A951DocUsuCod = new string[] {""} ;
         T002Y15_A952DocUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002Y15_A954DocVouAno = new short[1] ;
         T002Y15_A955DocVouMes = new short[1] ;
         T002Y15_A944DocTASICod = new int[1] ;
         T002Y15_A956DocVouNum = new string[] {""} ;
         T002Y15_A938DocPercepcion = new string[] {""} ;
         T002Y15_n938DocPercepcion = new bool[] {false} ;
         T002Y15_A883DocAplicaAnticipo = new decimal[1] ;
         T002Y15_A884DocCadena = new string[] {""} ;
         T002Y15_n884DocCadena = new bool[] {false} ;
         T002Y15_A930DocFEOBS = new string[] {""} ;
         T002Y15_n930DocFEOBS = new bool[] {false} ;
         T002Y15_A881DocAnticipo = new string[] {""} ;
         T002Y15_A945DocTipAnticipo = new string[] {""} ;
         T002Y15_A879DocAIVA = new short[1] ;
         T002Y15_A511TipSigno = new short[1] ;
         T002Y15_A149TipCod = new string[] {""} ;
         T002Y15_A178TieCod = new int[1] ;
         T002Y15_n178TieCod = new bool[] {false} ;
         T002Y15_A231DocCliCod = new string[] {""} ;
         T002Y15_A230DocMonCod = new int[1] ;
         T002Y15_A229DocConpCod = new int[1] ;
         T002Y15_A228DocLisp = new int[1] ;
         T002Y15_n228DocLisp = new bool[] {false} ;
         T002Y15_A227DocVendCod = new int[1] ;
         T002Y15_A226DocMovCod = new int[1] ;
         T002Y15_A932DocICBPER = new decimal[1] ;
         T002Y15_A920DocSubAfecto = new decimal[1] ;
         T002Y15_A921DocSubInafecto = new decimal[1] ;
         T002Y15_A922DocSubSelectivo = new decimal[1] ;
         T002Y15_A927DocSubExonerado = new decimal[1] ;
         T002Y15_A943DocSubGratuitoIna = new decimal[1] ;
         T002Y15_A942DocSubGratuito = new decimal[1] ;
         T002Y4_A306TipAbr = new string[] {""} ;
         T002Y4_A511TipSigno = new short[1] ;
         T002Y13_A932DocICBPER = new decimal[1] ;
         T002Y13_A920DocSubAfecto = new decimal[1] ;
         T002Y13_A921DocSubInafecto = new decimal[1] ;
         T002Y13_A922DocSubSelectivo = new decimal[1] ;
         T002Y13_A927DocSubExonerado = new decimal[1] ;
         T002Y13_A943DocSubGratuitoIna = new decimal[1] ;
         T002Y13_A942DocSubGratuito = new decimal[1] ;
         T002Y6_A887DocCliDsc = new string[] {""} ;
         T002Y6_A885DocCliDir = new string[] {""} ;
         T002Y7_A230DocMonCod = new int[1] ;
         T002Y8_A888DocConpDsc = new string[] {""} ;
         T002Y8_A904DocDias = new short[1] ;
         T002Y9_A228DocLisp = new int[1] ;
         T002Y9_n228DocLisp = new bool[] {false} ;
         T002Y10_A953DocVendDsc = new string[] {""} ;
         T002Y11_A226DocMovCod = new int[1] ;
         T002Y16_A306TipAbr = new string[] {""} ;
         T002Y16_A511TipSigno = new short[1] ;
         T002Y18_A932DocICBPER = new decimal[1] ;
         T002Y18_A920DocSubAfecto = new decimal[1] ;
         T002Y18_A921DocSubInafecto = new decimal[1] ;
         T002Y18_A922DocSubSelectivo = new decimal[1] ;
         T002Y18_A927DocSubExonerado = new decimal[1] ;
         T002Y18_A943DocSubGratuitoIna = new decimal[1] ;
         T002Y18_A942DocSubGratuito = new decimal[1] ;
         T002Y19_A887DocCliDsc = new string[] {""} ;
         T002Y19_A885DocCliDir = new string[] {""} ;
         T002Y20_A230DocMonCod = new int[1] ;
         T002Y21_A888DocConpDsc = new string[] {""} ;
         T002Y21_A904DocDias = new short[1] ;
         T002Y22_A228DocLisp = new int[1] ;
         T002Y22_n228DocLisp = new bool[] {false} ;
         T002Y23_A953DocVendDsc = new string[] {""} ;
         T002Y24_A226DocMovCod = new int[1] ;
         T002Y25_A149TipCod = new string[] {""} ;
         T002Y25_A24DocNum = new string[] {""} ;
         T002Y25_n24DocNum = new bool[] {false} ;
         T002Y3_A24DocNum = new string[] {""} ;
         T002Y3_n24DocNum = new bool[] {false} ;
         T002Y3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         T002Y3_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         T002Y3_A886DocCliDirItem = new int[1] ;
         T002Y3_A882DocAnticipos = new decimal[1] ;
         T002Y3_A935DocRedondeo = new decimal[1] ;
         T002Y3_A899DocDcto = new decimal[1] ;
         T002Y3_A934DocPorIVA = new decimal[1] ;
         T002Y3_A936DocObs = new string[] {""} ;
         T002Y3_A950DocTRef = new string[] {""} ;
         T002Y3_A939DocRef = new string[] {""} ;
         T002Y3_A941DocSts = new string[] {""} ;
         T002Y3_A947DocTItem = new decimal[1] ;
         T002Y3_A937DocPedCod = new string[] {""} ;
         T002Y3_A946DocTipo = new string[] {""} ;
         T002Y3_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         T002Y3_A880DocAlmCod = new int[1] ;
         T002Y3_A890DocCosCod = new string[] {""} ;
         T002Y3_n890DocCosCod = new bool[] {false} ;
         T002Y3_A951DocUsuCod = new string[] {""} ;
         T002Y3_A952DocUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002Y3_A954DocVouAno = new short[1] ;
         T002Y3_A955DocVouMes = new short[1] ;
         T002Y3_A944DocTASICod = new int[1] ;
         T002Y3_A956DocVouNum = new string[] {""} ;
         T002Y3_A938DocPercepcion = new string[] {""} ;
         T002Y3_n938DocPercepcion = new bool[] {false} ;
         T002Y3_A883DocAplicaAnticipo = new decimal[1] ;
         T002Y3_A884DocCadena = new string[] {""} ;
         T002Y3_n884DocCadena = new bool[] {false} ;
         T002Y3_A930DocFEOBS = new string[] {""} ;
         T002Y3_n930DocFEOBS = new bool[] {false} ;
         T002Y3_A881DocAnticipo = new string[] {""} ;
         T002Y3_A945DocTipAnticipo = new string[] {""} ;
         T002Y3_A879DocAIVA = new short[1] ;
         T002Y3_A149TipCod = new string[] {""} ;
         T002Y3_A178TieCod = new int[1] ;
         T002Y3_n178TieCod = new bool[] {false} ;
         T002Y3_A231DocCliCod = new string[] {""} ;
         T002Y3_A230DocMonCod = new int[1] ;
         T002Y3_A229DocConpCod = new int[1] ;
         T002Y3_A228DocLisp = new int[1] ;
         T002Y3_n228DocLisp = new bool[] {false} ;
         T002Y3_A227DocVendCod = new int[1] ;
         T002Y3_A226DocMovCod = new int[1] ;
         sMode101 = "";
         T002Y26_A149TipCod = new string[] {""} ;
         T002Y26_A24DocNum = new string[] {""} ;
         T002Y26_n24DocNum = new bool[] {false} ;
         T002Y27_A149TipCod = new string[] {""} ;
         T002Y27_A24DocNum = new string[] {""} ;
         T002Y27_n24DocNum = new bool[] {false} ;
         T002Y2_A24DocNum = new string[] {""} ;
         T002Y2_n24DocNum = new bool[] {false} ;
         T002Y2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         T002Y2_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         T002Y2_A886DocCliDirItem = new int[1] ;
         T002Y2_A882DocAnticipos = new decimal[1] ;
         T002Y2_A935DocRedondeo = new decimal[1] ;
         T002Y2_A899DocDcto = new decimal[1] ;
         T002Y2_A934DocPorIVA = new decimal[1] ;
         T002Y2_A936DocObs = new string[] {""} ;
         T002Y2_A950DocTRef = new string[] {""} ;
         T002Y2_A939DocRef = new string[] {""} ;
         T002Y2_A941DocSts = new string[] {""} ;
         T002Y2_A947DocTItem = new decimal[1] ;
         T002Y2_A937DocPedCod = new string[] {""} ;
         T002Y2_A946DocTipo = new string[] {""} ;
         T002Y2_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         T002Y2_A880DocAlmCod = new int[1] ;
         T002Y2_A890DocCosCod = new string[] {""} ;
         T002Y2_n890DocCosCod = new bool[] {false} ;
         T002Y2_A951DocUsuCod = new string[] {""} ;
         T002Y2_A952DocUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002Y2_A954DocVouAno = new short[1] ;
         T002Y2_A955DocVouMes = new short[1] ;
         T002Y2_A944DocTASICod = new int[1] ;
         T002Y2_A956DocVouNum = new string[] {""} ;
         T002Y2_A938DocPercepcion = new string[] {""} ;
         T002Y2_n938DocPercepcion = new bool[] {false} ;
         T002Y2_A883DocAplicaAnticipo = new decimal[1] ;
         T002Y2_A884DocCadena = new string[] {""} ;
         T002Y2_n884DocCadena = new bool[] {false} ;
         T002Y2_A930DocFEOBS = new string[] {""} ;
         T002Y2_n930DocFEOBS = new bool[] {false} ;
         T002Y2_A881DocAnticipo = new string[] {""} ;
         T002Y2_A945DocTipAnticipo = new string[] {""} ;
         T002Y2_A879DocAIVA = new short[1] ;
         T002Y2_A149TipCod = new string[] {""} ;
         T002Y2_A178TieCod = new int[1] ;
         T002Y2_n178TieCod = new bool[] {false} ;
         T002Y2_A231DocCliCod = new string[] {""} ;
         T002Y2_A230DocMonCod = new int[1] ;
         T002Y2_A229DocConpCod = new int[1] ;
         T002Y2_A228DocLisp = new int[1] ;
         T002Y2_n228DocLisp = new bool[] {false} ;
         T002Y2_A227DocVendCod = new int[1] ;
         T002Y2_A226DocMovCod = new int[1] ;
         T002Y31_A306TipAbr = new string[] {""} ;
         T002Y31_A511TipSigno = new short[1] ;
         T002Y33_A932DocICBPER = new decimal[1] ;
         T002Y33_A920DocSubAfecto = new decimal[1] ;
         T002Y33_A921DocSubInafecto = new decimal[1] ;
         T002Y33_A922DocSubSelectivo = new decimal[1] ;
         T002Y33_A927DocSubExonerado = new decimal[1] ;
         T002Y33_A943DocSubGratuitoIna = new decimal[1] ;
         T002Y33_A942DocSubGratuito = new decimal[1] ;
         T002Y34_A887DocCliDsc = new string[] {""} ;
         T002Y34_A885DocCliDir = new string[] {""} ;
         T002Y35_A888DocConpDsc = new string[] {""} ;
         T002Y35_A904DocDias = new short[1] ;
         T002Y36_A953DocVendDsc = new string[] {""} ;
         T002Y37_A149TipCod = new string[] {""} ;
         T002Y37_A24DocNum = new string[] {""} ;
         T002Y37_n24DocNum = new bool[] {false} ;
         T002Y37_A233DocItem = new long[1] ;
         T002Y38_A144CLAntTipCod = new string[] {""} ;
         T002Y38_A145CLAntDocNum = new string[] {""} ;
         T002Y38_A149TipCod = new string[] {""} ;
         T002Y38_A24DocNum = new string[] {""} ;
         T002Y38_n24DocNum = new bool[] {false} ;
         T002Y39_A13MvATip = new string[] {""} ;
         T002Y39_A14MvACod = new string[] {""} ;
         T002Y40_A149TipCod = new string[] {""} ;
         T002Y40_A24DocNum = new string[] {""} ;
         T002Y40_n24DocNum = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z940DocSerie = "";
         ZZ149TipCod = "";
         ZZ24DocNum = "";
         ZZ232DocFec = DateTime.MinValue;
         ZZ931DocFVcto = DateTime.MinValue;
         ZZ231DocCliCod = "";
         ZZ936DocObs = "";
         ZZ950DocTRef = "";
         ZZ939DocRef = "";
         ZZ941DocSts = "";
         ZZ937DocPedCod = "";
         ZZ946DocTipo = "";
         ZZ929DocFecRef = DateTime.MinValue;
         ZZ890DocCosCod = "";
         ZZ951DocUsuCod = "";
         ZZ952DocUsuFec = (DateTime)(DateTime.MinValue);
         ZZ956DocVouNum = "";
         ZZ938DocPercepcion = "";
         ZZ884DocCadena = "";
         ZZ930DocFEOBS = "";
         ZZ881DocAnticipo = "";
         ZZ945DocTipAnticipo = "";
         ZZ306TipAbr = "";
         ZZ940DocSerie = "";
         ZZ887DocCliDsc = "";
         ZZ885DocCliDir = "";
         ZZ888DocConpDsc = "";
         ZZ953DocVendDsc = "";
         T002Y41_A230DocMonCod = new int[1] ;
         T002Y42_A228DocLisp = new int[1] ;
         T002Y42_n228DocLisp = new bool[] {false} ;
         T002Y43_A226DocMovCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clventas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clventas__default(),
            new Object[][] {
                new Object[] {
               T002Y2_A24DocNum, T002Y2_A232DocFec, T002Y2_A931DocFVcto, T002Y2_A886DocCliDirItem, T002Y2_A882DocAnticipos, T002Y2_A935DocRedondeo, T002Y2_A899DocDcto, T002Y2_A934DocPorIVA, T002Y2_A936DocObs, T002Y2_A950DocTRef,
               T002Y2_A939DocRef, T002Y2_A941DocSts, T002Y2_A947DocTItem, T002Y2_A937DocPedCod, T002Y2_A946DocTipo, T002Y2_A929DocFecRef, T002Y2_A880DocAlmCod, T002Y2_A890DocCosCod, T002Y2_n890DocCosCod, T002Y2_A951DocUsuCod,
               T002Y2_A952DocUsuFec, T002Y2_A954DocVouAno, T002Y2_A955DocVouMes, T002Y2_A944DocTASICod, T002Y2_A956DocVouNum, T002Y2_A938DocPercepcion, T002Y2_n938DocPercepcion, T002Y2_A883DocAplicaAnticipo, T002Y2_A884DocCadena, T002Y2_n884DocCadena,
               T002Y2_A930DocFEOBS, T002Y2_n930DocFEOBS, T002Y2_A881DocAnticipo, T002Y2_A945DocTipAnticipo, T002Y2_A879DocAIVA, T002Y2_A149TipCod, T002Y2_A178TieCod, T002Y2_n178TieCod, T002Y2_A231DocCliCod, T002Y2_A230DocMonCod,
               T002Y2_A229DocConpCod, T002Y2_A228DocLisp, T002Y2_n228DocLisp, T002Y2_A227DocVendCod, T002Y2_A226DocMovCod
               }
               , new Object[] {
               T002Y3_A24DocNum, T002Y3_A232DocFec, T002Y3_A931DocFVcto, T002Y3_A886DocCliDirItem, T002Y3_A882DocAnticipos, T002Y3_A935DocRedondeo, T002Y3_A899DocDcto, T002Y3_A934DocPorIVA, T002Y3_A936DocObs, T002Y3_A950DocTRef,
               T002Y3_A939DocRef, T002Y3_A941DocSts, T002Y3_A947DocTItem, T002Y3_A937DocPedCod, T002Y3_A946DocTipo, T002Y3_A929DocFecRef, T002Y3_A880DocAlmCod, T002Y3_A890DocCosCod, T002Y3_n890DocCosCod, T002Y3_A951DocUsuCod,
               T002Y3_A952DocUsuFec, T002Y3_A954DocVouAno, T002Y3_A955DocVouMes, T002Y3_A944DocTASICod, T002Y3_A956DocVouNum, T002Y3_A938DocPercepcion, T002Y3_n938DocPercepcion, T002Y3_A883DocAplicaAnticipo, T002Y3_A884DocCadena, T002Y3_n884DocCadena,
               T002Y3_A930DocFEOBS, T002Y3_n930DocFEOBS, T002Y3_A881DocAnticipo, T002Y3_A945DocTipAnticipo, T002Y3_A879DocAIVA, T002Y3_A149TipCod, T002Y3_A178TieCod, T002Y3_n178TieCod, T002Y3_A231DocCliCod, T002Y3_A230DocMonCod,
               T002Y3_A229DocConpCod, T002Y3_A228DocLisp, T002Y3_n228DocLisp, T002Y3_A227DocVendCod, T002Y3_A226DocMovCod
               }
               , new Object[] {
               T002Y4_A306TipAbr, T002Y4_A511TipSigno
               }
               , new Object[] {
               T002Y5_A178TieCod
               }
               , new Object[] {
               T002Y6_A887DocCliDsc, T002Y6_A885DocCliDir
               }
               , new Object[] {
               T002Y7_A230DocMonCod
               }
               , new Object[] {
               T002Y8_A888DocConpDsc, T002Y8_A904DocDias
               }
               , new Object[] {
               T002Y9_A228DocLisp
               }
               , new Object[] {
               T002Y10_A953DocVendDsc
               }
               , new Object[] {
               T002Y11_A226DocMovCod
               }
               , new Object[] {
               T002Y13_A932DocICBPER, T002Y13_A920DocSubAfecto, T002Y13_A921DocSubInafecto, T002Y13_A922DocSubSelectivo, T002Y13_A927DocSubExonerado, T002Y13_A943DocSubGratuitoIna, T002Y13_A942DocSubGratuito
               }
               , new Object[] {
               T002Y15_A24DocNum, T002Y15_A306TipAbr, T002Y15_A232DocFec, T002Y15_A931DocFVcto, T002Y15_A887DocCliDsc, T002Y15_A885DocCliDir, T002Y15_A886DocCliDirItem, T002Y15_A888DocConpDsc, T002Y15_A904DocDias, T002Y15_A882DocAnticipos,
               T002Y15_A935DocRedondeo, T002Y15_A899DocDcto, T002Y15_A934DocPorIVA, T002Y15_A936DocObs, T002Y15_A950DocTRef, T002Y15_A939DocRef, T002Y15_A941DocSts, T002Y15_A947DocTItem, T002Y15_A937DocPedCod, T002Y15_A946DocTipo,
               T002Y15_A929DocFecRef, T002Y15_A880DocAlmCod, T002Y15_A953DocVendDsc, T002Y15_A890DocCosCod, T002Y15_n890DocCosCod, T002Y15_A951DocUsuCod, T002Y15_A952DocUsuFec, T002Y15_A954DocVouAno, T002Y15_A955DocVouMes, T002Y15_A944DocTASICod,
               T002Y15_A956DocVouNum, T002Y15_A938DocPercepcion, T002Y15_n938DocPercepcion, T002Y15_A883DocAplicaAnticipo, T002Y15_A884DocCadena, T002Y15_n884DocCadena, T002Y15_A930DocFEOBS, T002Y15_n930DocFEOBS, T002Y15_A881DocAnticipo, T002Y15_A945DocTipAnticipo,
               T002Y15_A879DocAIVA, T002Y15_A511TipSigno, T002Y15_A149TipCod, T002Y15_A178TieCod, T002Y15_n178TieCod, T002Y15_A231DocCliCod, T002Y15_A230DocMonCod, T002Y15_A229DocConpCod, T002Y15_A228DocLisp, T002Y15_n228DocLisp,
               T002Y15_A227DocVendCod, T002Y15_A226DocMovCod, T002Y15_A932DocICBPER, T002Y15_A920DocSubAfecto, T002Y15_A921DocSubInafecto, T002Y15_A922DocSubSelectivo, T002Y15_A927DocSubExonerado, T002Y15_A943DocSubGratuitoIna, T002Y15_A942DocSubGratuito
               }
               , new Object[] {
               T002Y16_A306TipAbr, T002Y16_A511TipSigno
               }
               , new Object[] {
               T002Y18_A932DocICBPER, T002Y18_A920DocSubAfecto, T002Y18_A921DocSubInafecto, T002Y18_A922DocSubSelectivo, T002Y18_A927DocSubExonerado, T002Y18_A943DocSubGratuitoIna, T002Y18_A942DocSubGratuito
               }
               , new Object[] {
               T002Y19_A887DocCliDsc, T002Y19_A885DocCliDir
               }
               , new Object[] {
               T002Y20_A230DocMonCod
               }
               , new Object[] {
               T002Y21_A888DocConpDsc, T002Y21_A904DocDias
               }
               , new Object[] {
               T002Y22_A228DocLisp
               }
               , new Object[] {
               T002Y23_A953DocVendDsc
               }
               , new Object[] {
               T002Y24_A226DocMovCod
               }
               , new Object[] {
               T002Y25_A149TipCod, T002Y25_A24DocNum
               }
               , new Object[] {
               T002Y26_A149TipCod, T002Y26_A24DocNum
               }
               , new Object[] {
               T002Y27_A149TipCod, T002Y27_A24DocNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Y31_A306TipAbr, T002Y31_A511TipSigno
               }
               , new Object[] {
               T002Y33_A932DocICBPER, T002Y33_A920DocSubAfecto, T002Y33_A921DocSubInafecto, T002Y33_A922DocSubSelectivo, T002Y33_A927DocSubExonerado, T002Y33_A943DocSubGratuitoIna, T002Y33_A942DocSubGratuito
               }
               , new Object[] {
               T002Y34_A887DocCliDsc, T002Y34_A885DocCliDir
               }
               , new Object[] {
               T002Y35_A888DocConpDsc, T002Y35_A904DocDias
               }
               , new Object[] {
               T002Y36_A953DocVendDsc
               }
               , new Object[] {
               T002Y37_A149TipCod, T002Y37_A24DocNum, T002Y37_A233DocItem
               }
               , new Object[] {
               T002Y38_A144CLAntTipCod, T002Y38_A145CLAntDocNum, T002Y38_A149TipCod, T002Y38_A24DocNum
               }
               , new Object[] {
               T002Y39_A13MvATip, T002Y39_A14MvACod
               }
               , new Object[] {
               T002Y40_A149TipCod, T002Y40_A24DocNum
               }
               , new Object[] {
               T002Y41_A230DocMonCod
               }
               , new Object[] {
               T002Y42_A228DocLisp
               }
               , new Object[] {
               T002Y43_A226DocMovCod
               }
            }
         );
      }

      private short Z954DocVouAno ;
      private short Z955DocVouMes ;
      private short Z879DocAIVA ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A904DocDias ;
      private short A954DocVouAno ;
      private short A955DocVouMes ;
      private short A879DocAIVA ;
      private short A511TipSigno ;
      private short GX_JID ;
      private short Z511TipSigno ;
      private short Z904DocDias ;
      private short RcdFound101 ;
      private short nIsDirty_101 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ954DocVouAno ;
      private short ZZ955DocVouMes ;
      private short ZZ879DocAIVA ;
      private short ZZ511TipSigno ;
      private short ZZ904DocDias ;
      private int Z886DocCliDirItem ;
      private int Z880DocAlmCod ;
      private int Z944DocTASICod ;
      private int Z178TieCod ;
      private int Z230DocMonCod ;
      private int Z229DocConpCod ;
      private int Z228DocLisp ;
      private int Z227DocVendCod ;
      private int Z226DocMovCod ;
      private int A230DocMonCod ;
      private int A229DocConpCod ;
      private int A228DocLisp ;
      private int A227DocVendCod ;
      private int A226DocMovCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipCod_Enabled ;
      private int edtDocNum_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTipAbr_Enabled ;
      private int edtDocFec_Enabled ;
      private int edtDocFVcto_Enabled ;
      private int edtDocCliCod_Enabled ;
      private int edtDocCliDsc_Enabled ;
      private int edtDocCliDir_Enabled ;
      private int A886DocCliDirItem ;
      private int edtDocCliDirItem_Enabled ;
      private int edtDocMonCod_Enabled ;
      private int edtDocConpCod_Enabled ;
      private int edtDocConpDsc_Enabled ;
      private int edtDocDias_Enabled ;
      private int edtDocLisp_Enabled ;
      private int edtDocSubAfecto_Enabled ;
      private int edtDocSubInafecto_Enabled ;
      private int edtDocSubSelectivo_Enabled ;
      private int edtDocAnticipos_Enabled ;
      private int edtDocDscto_Enabled ;
      private int edtDocSub_Enabled ;
      private int edtDocRedondeo_Enabled ;
      private int edtDocDcto_Enabled ;
      private int edtDocPorIVA_Enabled ;
      private int edtDocIVA_Enabled ;
      private int edtDocTot_Enabled ;
      private int edtDocObs_Enabled ;
      private int edtDocTRef_Enabled ;
      private int edtDocRef_Enabled ;
      private int edtDocSts_Enabled ;
      private int edtDocTItem_Enabled ;
      private int edtDocPedCod_Enabled ;
      private int edtDocTipo_Enabled ;
      private int edtDocFecRef_Enabled ;
      private int A880DocAlmCod ;
      private int edtDocAlmCod_Enabled ;
      private int edtDocVendCod_Enabled ;
      private int edtDocVendDsc_Enabled ;
      private int edtDocCosCod_Enabled ;
      private int edtDocUsuCod_Enabled ;
      private int edtDocUsuFec_Enabled ;
      private int edtDocVouAno_Enabled ;
      private int edtDocVouMes_Enabled ;
      private int A944DocTASICod ;
      private int edtDocTASICod_Enabled ;
      private int edtDocVouNum_Enabled ;
      private int edtDocMovCod_Enabled ;
      private int edtDocTotSigno_Enabled ;
      private int edtDocPercepcion_Enabled ;
      private int edtDocAplicaAnticipo_Enabled ;
      private int edtDocSerie_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A178TieCod ;
      private int idxLst ;
      private int ZZ886DocCliDirItem ;
      private int ZZ230DocMonCod ;
      private int ZZ229DocConpCod ;
      private int ZZ228DocLisp ;
      private int ZZ880DocAlmCod ;
      private int ZZ227DocVendCod ;
      private int ZZ944DocTASICod ;
      private int ZZ226DocMovCod ;
      private int ZZ178TieCod ;
      private decimal Z882DocAnticipos ;
      private decimal Z935DocRedondeo ;
      private decimal Z899DocDcto ;
      private decimal Z934DocPorIVA ;
      private decimal Z947DocTItem ;
      private decimal Z883DocAplicaAnticipo ;
      private decimal A920DocSubAfecto ;
      private decimal A921DocSubInafecto ;
      private decimal A922DocSubSelectivo ;
      private decimal A882DocAnticipos ;
      private decimal A918DocDscto ;
      private decimal A919DocSub ;
      private decimal A935DocRedondeo ;
      private decimal A899DocDcto ;
      private decimal A934DocPorIVA ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal A947DocTItem ;
      private decimal A949DocTotSigno ;
      private decimal A883DocAplicaAnticipo ;
      private decimal A927DocSubExonerado ;
      private decimal A932DocICBPER ;
      private decimal A943DocSubGratuitoIna ;
      private decimal A942DocSubGratuito ;
      private decimal Z932DocICBPER ;
      private decimal Z920DocSubAfecto ;
      private decimal Z921DocSubInafecto ;
      private decimal Z922DocSubSelectivo ;
      private decimal Z927DocSubExonerado ;
      private decimal Z943DocSubGratuitoIna ;
      private decimal Z942DocSubGratuito ;
      private decimal Z919DocSub ;
      private decimal Z918DocDscto ;
      private decimal Z933DocIVA ;
      private decimal Z948DocTot ;
      private decimal Z949DocTotSigno ;
      private decimal ZZ882DocAnticipos ;
      private decimal ZZ935DocRedondeo ;
      private decimal ZZ899DocDcto ;
      private decimal ZZ934DocPorIVA ;
      private decimal ZZ947DocTItem ;
      private decimal ZZ883DocAplicaAnticipo ;
      private decimal ZZ932DocICBPER ;
      private decimal ZZ920DocSubAfecto ;
      private decimal ZZ921DocSubInafecto ;
      private decimal ZZ922DocSubSelectivo ;
      private decimal ZZ927DocSubExonerado ;
      private decimal ZZ943DocSubGratuitoIna ;
      private decimal ZZ942DocSubGratuito ;
      private decimal ZZ919DocSub ;
      private decimal ZZ918DocDscto ;
      private decimal ZZ933DocIVA ;
      private decimal ZZ948DocTot ;
      private decimal ZZ949DocTotSigno ;
      private string sPrefix ;
      private string Z149TipCod ;
      private string Z24DocNum ;
      private string Z950DocTRef ;
      private string Z939DocRef ;
      private string Z941DocSts ;
      private string Z937DocPedCod ;
      private string Z946DocTipo ;
      private string Z890DocCosCod ;
      private string Z951DocUsuCod ;
      private string Z956DocVouNum ;
      private string Z938DocPercepcion ;
      private string Z881DocAnticipo ;
      private string Z945DocTipAnticipo ;
      private string Z231DocCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A231DocCliCod ;
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
      private string edtTipCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtDocNum_Internalname ;
      private string edtDocNum_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTipAbr_Internalname ;
      private string A306TipAbr ;
      private string edtTipAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtDocFec_Internalname ;
      private string edtDocFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtDocFVcto_Internalname ;
      private string edtDocFVcto_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtDocCliCod_Internalname ;
      private string edtDocCliCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtDocCliDsc_Internalname ;
      private string A887DocCliDsc ;
      private string edtDocCliDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtDocCliDir_Internalname ;
      private string A885DocCliDir ;
      private string edtDocCliDir_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtDocCliDirItem_Internalname ;
      private string edtDocCliDirItem_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtDocMonCod_Internalname ;
      private string edtDocMonCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtDocConpCod_Internalname ;
      private string edtDocConpCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtDocConpDsc_Internalname ;
      private string A888DocConpDsc ;
      private string edtDocConpDsc_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtDocDias_Internalname ;
      private string edtDocDias_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtDocLisp_Internalname ;
      private string edtDocLisp_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtDocSubAfecto_Internalname ;
      private string edtDocSubAfecto_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtDocSubInafecto_Internalname ;
      private string edtDocSubInafecto_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtDocSubSelectivo_Internalname ;
      private string edtDocSubSelectivo_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtDocAnticipos_Internalname ;
      private string edtDocAnticipos_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtDocDscto_Internalname ;
      private string edtDocDscto_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtDocSub_Internalname ;
      private string edtDocSub_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtDocRedondeo_Internalname ;
      private string edtDocRedondeo_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtDocDcto_Internalname ;
      private string edtDocDcto_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtDocPorIVA_Internalname ;
      private string edtDocPorIVA_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtDocIVA_Internalname ;
      private string edtDocIVA_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtDocTot_Internalname ;
      private string edtDocTot_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtDocObs_Internalname ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtDocTRef_Internalname ;
      private string A950DocTRef ;
      private string edtDocTRef_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtDocRef_Internalname ;
      private string A939DocRef ;
      private string edtDocRef_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtDocSts_Internalname ;
      private string A941DocSts ;
      private string edtDocSts_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtDocTItem_Internalname ;
      private string edtDocTItem_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtDocPedCod_Internalname ;
      private string A937DocPedCod ;
      private string edtDocPedCod_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtDocTipo_Internalname ;
      private string A946DocTipo ;
      private string edtDocTipo_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtDocFecRef_Internalname ;
      private string edtDocFecRef_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtDocAlmCod_Internalname ;
      private string edtDocAlmCod_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtDocVendCod_Internalname ;
      private string edtDocVendCod_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtDocVendDsc_Internalname ;
      private string A953DocVendDsc ;
      private string edtDocVendDsc_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtDocCosCod_Internalname ;
      private string A890DocCosCod ;
      private string edtDocCosCod_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtDocUsuCod_Internalname ;
      private string A951DocUsuCod ;
      private string edtDocUsuCod_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string edtDocUsuFec_Internalname ;
      private string edtDocUsuFec_Jsonclick ;
      private string lblTextblock40_Internalname ;
      private string lblTextblock40_Jsonclick ;
      private string edtDocVouAno_Internalname ;
      private string edtDocVouAno_Jsonclick ;
      private string lblTextblock41_Internalname ;
      private string lblTextblock41_Jsonclick ;
      private string edtDocVouMes_Internalname ;
      private string edtDocVouMes_Jsonclick ;
      private string lblTextblock42_Internalname ;
      private string lblTextblock42_Jsonclick ;
      private string edtDocTASICod_Internalname ;
      private string edtDocTASICod_Jsonclick ;
      private string lblTextblock43_Internalname ;
      private string lblTextblock43_Jsonclick ;
      private string edtDocVouNum_Internalname ;
      private string A956DocVouNum ;
      private string edtDocVouNum_Jsonclick ;
      private string lblTextblock44_Internalname ;
      private string lblTextblock44_Jsonclick ;
      private string edtDocMovCod_Internalname ;
      private string edtDocMovCod_Jsonclick ;
      private string lblTextblock45_Internalname ;
      private string lblTextblock45_Jsonclick ;
      private string edtDocTotSigno_Internalname ;
      private string edtDocTotSigno_Jsonclick ;
      private string lblTextblock46_Internalname ;
      private string lblTextblock46_Jsonclick ;
      private string edtDocPercepcion_Internalname ;
      private string A938DocPercepcion ;
      private string edtDocPercepcion_Jsonclick ;
      private string lblTextblock47_Internalname ;
      private string lblTextblock47_Jsonclick ;
      private string edtDocAplicaAnticipo_Internalname ;
      private string edtDocAplicaAnticipo_Jsonclick ;
      private string lblTextblock48_Internalname ;
      private string lblTextblock48_Jsonclick ;
      private string edtDocSerie_Internalname ;
      private string edtDocSerie_Jsonclick ;
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
      private string A881DocAnticipo ;
      private string A945DocTipAnticipo ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z306TipAbr ;
      private string Z887DocCliDsc ;
      private string Z885DocCliDir ;
      private string Z888DocConpDsc ;
      private string Z953DocVendDsc ;
      private string sMode101 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ149TipCod ;
      private string ZZ24DocNum ;
      private string ZZ231DocCliCod ;
      private string ZZ950DocTRef ;
      private string ZZ939DocRef ;
      private string ZZ941DocSts ;
      private string ZZ937DocPedCod ;
      private string ZZ946DocTipo ;
      private string ZZ890DocCosCod ;
      private string ZZ951DocUsuCod ;
      private string ZZ956DocVouNum ;
      private string ZZ938DocPercepcion ;
      private string ZZ881DocAnticipo ;
      private string ZZ945DocTipAnticipo ;
      private string ZZ306TipAbr ;
      private string ZZ887DocCliDsc ;
      private string ZZ885DocCliDir ;
      private string ZZ888DocConpDsc ;
      private string ZZ953DocVendDsc ;
      private DateTime Z952DocUsuFec ;
      private DateTime A952DocUsuFec ;
      private DateTime ZZ952DocUsuFec ;
      private DateTime Z232DocFec ;
      private DateTime Z931DocFVcto ;
      private DateTime Z929DocFecRef ;
      private DateTime A232DocFec ;
      private DateTime A931DocFVcto ;
      private DateTime A929DocFecRef ;
      private DateTime ZZ232DocFec ;
      private DateTime ZZ931DocFVcto ;
      private DateTime ZZ929DocFecRef ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n24DocNum ;
      private bool n228DocLisp ;
      private bool wbErr ;
      private bool n890DocCosCod ;
      private bool n938DocPercepcion ;
      private bool n884DocCadena ;
      private bool n178TieCod ;
      private bool n930DocFEOBS ;
      private bool Gx_longc ;
      private string A936DocObs ;
      private string Z936DocObs ;
      private string ZZ936DocObs ;
      private string Z884DocCadena ;
      private string Z930DocFEOBS ;
      private string A940DocSerie ;
      private string A884DocCadena ;
      private string A930DocFEOBS ;
      private string Z940DocSerie ;
      private string ZZ884DocCadena ;
      private string ZZ930DocFEOBS ;
      private string ZZ940DocSerie ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002Y5_A178TieCod ;
      private bool[] T002Y5_n178TieCod ;
      private string[] T002Y15_A24DocNum ;
      private bool[] T002Y15_n24DocNum ;
      private string[] T002Y15_A306TipAbr ;
      private DateTime[] T002Y15_A232DocFec ;
      private DateTime[] T002Y15_A931DocFVcto ;
      private string[] T002Y15_A887DocCliDsc ;
      private string[] T002Y15_A885DocCliDir ;
      private int[] T002Y15_A886DocCliDirItem ;
      private string[] T002Y15_A888DocConpDsc ;
      private short[] T002Y15_A904DocDias ;
      private decimal[] T002Y15_A882DocAnticipos ;
      private decimal[] T002Y15_A935DocRedondeo ;
      private decimal[] T002Y15_A899DocDcto ;
      private decimal[] T002Y15_A934DocPorIVA ;
      private string[] T002Y15_A936DocObs ;
      private string[] T002Y15_A950DocTRef ;
      private string[] T002Y15_A939DocRef ;
      private string[] T002Y15_A941DocSts ;
      private decimal[] T002Y15_A947DocTItem ;
      private string[] T002Y15_A937DocPedCod ;
      private string[] T002Y15_A946DocTipo ;
      private DateTime[] T002Y15_A929DocFecRef ;
      private int[] T002Y15_A880DocAlmCod ;
      private string[] T002Y15_A953DocVendDsc ;
      private string[] T002Y15_A890DocCosCod ;
      private bool[] T002Y15_n890DocCosCod ;
      private string[] T002Y15_A951DocUsuCod ;
      private DateTime[] T002Y15_A952DocUsuFec ;
      private short[] T002Y15_A954DocVouAno ;
      private short[] T002Y15_A955DocVouMes ;
      private int[] T002Y15_A944DocTASICod ;
      private string[] T002Y15_A956DocVouNum ;
      private string[] T002Y15_A938DocPercepcion ;
      private bool[] T002Y15_n938DocPercepcion ;
      private decimal[] T002Y15_A883DocAplicaAnticipo ;
      private string[] T002Y15_A884DocCadena ;
      private bool[] T002Y15_n884DocCadena ;
      private string[] T002Y15_A930DocFEOBS ;
      private bool[] T002Y15_n930DocFEOBS ;
      private string[] T002Y15_A881DocAnticipo ;
      private string[] T002Y15_A945DocTipAnticipo ;
      private short[] T002Y15_A879DocAIVA ;
      private short[] T002Y15_A511TipSigno ;
      private string[] T002Y15_A149TipCod ;
      private int[] T002Y15_A178TieCod ;
      private bool[] T002Y15_n178TieCod ;
      private string[] T002Y15_A231DocCliCod ;
      private int[] T002Y15_A230DocMonCod ;
      private int[] T002Y15_A229DocConpCod ;
      private int[] T002Y15_A228DocLisp ;
      private bool[] T002Y15_n228DocLisp ;
      private int[] T002Y15_A227DocVendCod ;
      private int[] T002Y15_A226DocMovCod ;
      private decimal[] T002Y15_A932DocICBPER ;
      private decimal[] T002Y15_A920DocSubAfecto ;
      private decimal[] T002Y15_A921DocSubInafecto ;
      private decimal[] T002Y15_A922DocSubSelectivo ;
      private decimal[] T002Y15_A927DocSubExonerado ;
      private decimal[] T002Y15_A943DocSubGratuitoIna ;
      private decimal[] T002Y15_A942DocSubGratuito ;
      private string[] T002Y4_A306TipAbr ;
      private short[] T002Y4_A511TipSigno ;
      private decimal[] T002Y13_A932DocICBPER ;
      private decimal[] T002Y13_A920DocSubAfecto ;
      private decimal[] T002Y13_A921DocSubInafecto ;
      private decimal[] T002Y13_A922DocSubSelectivo ;
      private decimal[] T002Y13_A927DocSubExonerado ;
      private decimal[] T002Y13_A943DocSubGratuitoIna ;
      private decimal[] T002Y13_A942DocSubGratuito ;
      private string[] T002Y6_A887DocCliDsc ;
      private string[] T002Y6_A885DocCliDir ;
      private int[] T002Y7_A230DocMonCod ;
      private string[] T002Y8_A888DocConpDsc ;
      private short[] T002Y8_A904DocDias ;
      private int[] T002Y9_A228DocLisp ;
      private bool[] T002Y9_n228DocLisp ;
      private string[] T002Y10_A953DocVendDsc ;
      private int[] T002Y11_A226DocMovCod ;
      private string[] T002Y16_A306TipAbr ;
      private short[] T002Y16_A511TipSigno ;
      private decimal[] T002Y18_A932DocICBPER ;
      private decimal[] T002Y18_A920DocSubAfecto ;
      private decimal[] T002Y18_A921DocSubInafecto ;
      private decimal[] T002Y18_A922DocSubSelectivo ;
      private decimal[] T002Y18_A927DocSubExonerado ;
      private decimal[] T002Y18_A943DocSubGratuitoIna ;
      private decimal[] T002Y18_A942DocSubGratuito ;
      private string[] T002Y19_A887DocCliDsc ;
      private string[] T002Y19_A885DocCliDir ;
      private int[] T002Y20_A230DocMonCod ;
      private string[] T002Y21_A888DocConpDsc ;
      private short[] T002Y21_A904DocDias ;
      private int[] T002Y22_A228DocLisp ;
      private bool[] T002Y22_n228DocLisp ;
      private string[] T002Y23_A953DocVendDsc ;
      private int[] T002Y24_A226DocMovCod ;
      private string[] T002Y25_A149TipCod ;
      private string[] T002Y25_A24DocNum ;
      private bool[] T002Y25_n24DocNum ;
      private string[] T002Y3_A24DocNum ;
      private bool[] T002Y3_n24DocNum ;
      private DateTime[] T002Y3_A232DocFec ;
      private DateTime[] T002Y3_A931DocFVcto ;
      private int[] T002Y3_A886DocCliDirItem ;
      private decimal[] T002Y3_A882DocAnticipos ;
      private decimal[] T002Y3_A935DocRedondeo ;
      private decimal[] T002Y3_A899DocDcto ;
      private decimal[] T002Y3_A934DocPorIVA ;
      private string[] T002Y3_A936DocObs ;
      private string[] T002Y3_A950DocTRef ;
      private string[] T002Y3_A939DocRef ;
      private string[] T002Y3_A941DocSts ;
      private decimal[] T002Y3_A947DocTItem ;
      private string[] T002Y3_A937DocPedCod ;
      private string[] T002Y3_A946DocTipo ;
      private DateTime[] T002Y3_A929DocFecRef ;
      private int[] T002Y3_A880DocAlmCod ;
      private string[] T002Y3_A890DocCosCod ;
      private bool[] T002Y3_n890DocCosCod ;
      private string[] T002Y3_A951DocUsuCod ;
      private DateTime[] T002Y3_A952DocUsuFec ;
      private short[] T002Y3_A954DocVouAno ;
      private short[] T002Y3_A955DocVouMes ;
      private int[] T002Y3_A944DocTASICod ;
      private string[] T002Y3_A956DocVouNum ;
      private string[] T002Y3_A938DocPercepcion ;
      private bool[] T002Y3_n938DocPercepcion ;
      private decimal[] T002Y3_A883DocAplicaAnticipo ;
      private string[] T002Y3_A884DocCadena ;
      private bool[] T002Y3_n884DocCadena ;
      private string[] T002Y3_A930DocFEOBS ;
      private bool[] T002Y3_n930DocFEOBS ;
      private string[] T002Y3_A881DocAnticipo ;
      private string[] T002Y3_A945DocTipAnticipo ;
      private short[] T002Y3_A879DocAIVA ;
      private string[] T002Y3_A149TipCod ;
      private int[] T002Y3_A178TieCod ;
      private bool[] T002Y3_n178TieCod ;
      private string[] T002Y3_A231DocCliCod ;
      private int[] T002Y3_A230DocMonCod ;
      private int[] T002Y3_A229DocConpCod ;
      private int[] T002Y3_A228DocLisp ;
      private bool[] T002Y3_n228DocLisp ;
      private int[] T002Y3_A227DocVendCod ;
      private int[] T002Y3_A226DocMovCod ;
      private string[] T002Y26_A149TipCod ;
      private string[] T002Y26_A24DocNum ;
      private bool[] T002Y26_n24DocNum ;
      private string[] T002Y27_A149TipCod ;
      private string[] T002Y27_A24DocNum ;
      private bool[] T002Y27_n24DocNum ;
      private string[] T002Y2_A24DocNum ;
      private bool[] T002Y2_n24DocNum ;
      private DateTime[] T002Y2_A232DocFec ;
      private DateTime[] T002Y2_A931DocFVcto ;
      private int[] T002Y2_A886DocCliDirItem ;
      private decimal[] T002Y2_A882DocAnticipos ;
      private decimal[] T002Y2_A935DocRedondeo ;
      private decimal[] T002Y2_A899DocDcto ;
      private decimal[] T002Y2_A934DocPorIVA ;
      private string[] T002Y2_A936DocObs ;
      private string[] T002Y2_A950DocTRef ;
      private string[] T002Y2_A939DocRef ;
      private string[] T002Y2_A941DocSts ;
      private decimal[] T002Y2_A947DocTItem ;
      private string[] T002Y2_A937DocPedCod ;
      private string[] T002Y2_A946DocTipo ;
      private DateTime[] T002Y2_A929DocFecRef ;
      private int[] T002Y2_A880DocAlmCod ;
      private string[] T002Y2_A890DocCosCod ;
      private bool[] T002Y2_n890DocCosCod ;
      private string[] T002Y2_A951DocUsuCod ;
      private DateTime[] T002Y2_A952DocUsuFec ;
      private short[] T002Y2_A954DocVouAno ;
      private short[] T002Y2_A955DocVouMes ;
      private int[] T002Y2_A944DocTASICod ;
      private string[] T002Y2_A956DocVouNum ;
      private string[] T002Y2_A938DocPercepcion ;
      private bool[] T002Y2_n938DocPercepcion ;
      private decimal[] T002Y2_A883DocAplicaAnticipo ;
      private string[] T002Y2_A884DocCadena ;
      private bool[] T002Y2_n884DocCadena ;
      private string[] T002Y2_A930DocFEOBS ;
      private bool[] T002Y2_n930DocFEOBS ;
      private string[] T002Y2_A881DocAnticipo ;
      private string[] T002Y2_A945DocTipAnticipo ;
      private short[] T002Y2_A879DocAIVA ;
      private string[] T002Y2_A149TipCod ;
      private int[] T002Y2_A178TieCod ;
      private bool[] T002Y2_n178TieCod ;
      private string[] T002Y2_A231DocCliCod ;
      private int[] T002Y2_A230DocMonCod ;
      private int[] T002Y2_A229DocConpCod ;
      private int[] T002Y2_A228DocLisp ;
      private bool[] T002Y2_n228DocLisp ;
      private int[] T002Y2_A227DocVendCod ;
      private int[] T002Y2_A226DocMovCod ;
      private string[] T002Y31_A306TipAbr ;
      private short[] T002Y31_A511TipSigno ;
      private decimal[] T002Y33_A932DocICBPER ;
      private decimal[] T002Y33_A920DocSubAfecto ;
      private decimal[] T002Y33_A921DocSubInafecto ;
      private decimal[] T002Y33_A922DocSubSelectivo ;
      private decimal[] T002Y33_A927DocSubExonerado ;
      private decimal[] T002Y33_A943DocSubGratuitoIna ;
      private decimal[] T002Y33_A942DocSubGratuito ;
      private string[] T002Y34_A887DocCliDsc ;
      private string[] T002Y34_A885DocCliDir ;
      private string[] T002Y35_A888DocConpDsc ;
      private short[] T002Y35_A904DocDias ;
      private string[] T002Y36_A953DocVendDsc ;
      private string[] T002Y37_A149TipCod ;
      private string[] T002Y37_A24DocNum ;
      private bool[] T002Y37_n24DocNum ;
      private long[] T002Y37_A233DocItem ;
      private string[] T002Y38_A144CLAntTipCod ;
      private string[] T002Y38_A145CLAntDocNum ;
      private string[] T002Y38_A149TipCod ;
      private string[] T002Y38_A24DocNum ;
      private bool[] T002Y38_n24DocNum ;
      private string[] T002Y39_A13MvATip ;
      private string[] T002Y39_A14MvACod ;
      private string[] T002Y40_A149TipCod ;
      private string[] T002Y40_A24DocNum ;
      private bool[] T002Y40_n24DocNum ;
      private int[] T002Y41_A230DocMonCod ;
      private int[] T002Y42_A228DocLisp ;
      private bool[] T002Y42_n228DocLisp ;
      private int[] T002Y43_A226DocMovCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clventas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clventas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002Y5;
        prmT002Y5 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002Y15;
        prmT002Y15 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        string cmdBufferT002Y15;
        cmdBufferT002Y15=" SELECT TM1.[DocNum], T2.[TipAbr], TM1.[DocFec], TM1.[DocFVcto], T4.[CliDsc] AS DocCliDsc, T4.[CliDir] AS DocCliDir, TM1.[DocCliDirItem], T5.[ConpDsc] AS DocConpDsc, T5.[ConpDias] AS DocDias, TM1.[DocAnticipos], TM1.[DocRedondeo], TM1.[DocDcto], TM1.[DocPorIVA], TM1.[DocObs], TM1.[DocTRef], TM1.[DocRef], TM1.[DocSts], TM1.[DocTItem], TM1.[DocPedCod], TM1.[DocTipo], TM1.[DocFecRef], TM1.[DocAlmCod], T6.[VenDsc] AS DocVendDsc, TM1.[DocCosCod], TM1.[DocUsuCod], TM1.[DocUsuFec], TM1.[DocVouAno], TM1.[DocVouMes], TM1.[DocTASICod], TM1.[DocVouNum], TM1.[DocPercepcion], TM1.[DocAplicaAnticipo], TM1.[DocCadena], TM1.[DocFEOBS], TM1.[DocAnticipo], TM1.[DocTipAnticipo], TM1.[DocAIVA], T2.[TipSigno], TM1.[TipCod], TM1.[TieCod], TM1.[DocCliCod] AS DocCliCod, TM1.[DocMonCod] AS DocMonCod, TM1.[DocConpCod] AS DocConpCod, TM1.[DocLisp] AS DocLisp, TM1.[DocVendCod] AS DocVendCod, TM1.[DocMovCod] AS DocMovCod, COALESCE( T3.[DocICBPER], 0) AS DocICBPER, COALESCE( T3.[DocSubAfecto], 0) AS DocSubAfecto, COALESCE( T3.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T3.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T3.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T3.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T3.[DocSubGratuito], 0) AS DocSubGratuito FROM ((((([CLVENTAS] TM1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = TM1.[TipCod]) LEFT JOIN (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 "
        + " END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T3 ON T3.[TipCod] = TM1.[TipCod] AND T3.[DocNum] = TM1.[DocNum]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = TM1.[DocCliCod]) INNER JOIN [CCONDICIONPAGO] T5 ON T5.[Conpcod] = TM1.[DocConpCod]) INNER JOIN [CVENDEDORES] T6 ON T6.[VenCod] = TM1.[DocVendCod]) WHERE TM1.[TipCod] = @TipCod and TM1.[DocNum] = @DocNum ORDER BY TM1.[TipCod], TM1.[DocNum]  OPTION (FAST 100)" ;
        Object[] prmT002Y4;
        prmT002Y4 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT002Y13;
        prmT002Y13 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y6;
        prmT002Y6 = new Object[] {
        new ParDef("@DocCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002Y7;
        prmT002Y7 = new Object[] {
        new ParDef("@DocMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y8;
        prmT002Y8 = new Object[] {
        new ParDef("@DocConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y9;
        prmT002Y9 = new Object[] {
        new ParDef("@DocLisp",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002Y10;
        prmT002Y10 = new Object[] {
        new ParDef("@DocVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y11;
        prmT002Y11 = new Object[] {
        new ParDef("@DocMovCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y16;
        prmT002Y16 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT002Y18;
        prmT002Y18 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y19;
        prmT002Y19 = new Object[] {
        new ParDef("@DocCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002Y20;
        prmT002Y20 = new Object[] {
        new ParDef("@DocMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y21;
        prmT002Y21 = new Object[] {
        new ParDef("@DocConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y22;
        prmT002Y22 = new Object[] {
        new ParDef("@DocLisp",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002Y23;
        prmT002Y23 = new Object[] {
        new ParDef("@DocVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y24;
        prmT002Y24 = new Object[] {
        new ParDef("@DocMovCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y25;
        prmT002Y25 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y3;
        prmT002Y3 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y26;
        prmT002Y26 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y27;
        prmT002Y27 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y2;
        prmT002Y2 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y28;
        prmT002Y28 = new Object[] {
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true} ,
        new ParDef("@DocFec",GXType.Date,8,0) ,
        new ParDef("@DocFVcto",GXType.Date,8,0) ,
        new ParDef("@DocCliDirItem",GXType.Int32,6,0) ,
        new ParDef("@DocAnticipos",GXType.Decimal,15,4) ,
        new ParDef("@DocRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@DocDcto",GXType.Decimal,6,2) ,
        new ParDef("@DocPorIVA",GXType.Decimal,6,2) ,
        new ParDef("@DocObs",GXType.NVarChar,1000,0) ,
        new ParDef("@DocTRef",GXType.NChar,3,0) ,
        new ParDef("@DocRef",GXType.NChar,12,0) ,
        new ParDef("@DocSts",GXType.NChar,1,0) ,
        new ParDef("@DocTItem",GXType.Decimal,15,2) ,
        new ParDef("@DocPedCod",GXType.NChar,10,0) ,
        new ParDef("@DocTipo",GXType.NChar,1,0) ,
        new ParDef("@DocFecRef",GXType.Date,8,0) ,
        new ParDef("@DocAlmCod",GXType.Int32,6,0) ,
        new ParDef("@DocCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@DocUsuCod",GXType.NChar,10,0) ,
        new ParDef("@DocUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@DocVouAno",GXType.Int16,4,0) ,
        new ParDef("@DocVouMes",GXType.Int16,2,0) ,
        new ParDef("@DocTASICod",GXType.Int32,6,0) ,
        new ParDef("@DocVouNum",GXType.NChar,10,0) ,
        new ParDef("@DocPercepcion",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@DocAplicaAnticipo",GXType.Decimal,15,2) ,
        new ParDef("@DocCadena",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@DocFEOBS",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@DocAnticipo",GXType.NChar,12,0) ,
        new ParDef("@DocTipAnticipo",GXType.NChar,3,0) ,
        new ParDef("@DocAIVA",GXType.Int16,1,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@DocCliCod",GXType.NChar,20,0) ,
        new ParDef("@DocMonCod",GXType.Int32,6,0) ,
        new ParDef("@DocConpCod",GXType.Int32,6,0) ,
        new ParDef("@DocLisp",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@DocVendCod",GXType.Int32,6,0) ,
        new ParDef("@DocMovCod",GXType.Int32,6,0) ,
        new ParDef("@DocICBPER",GXType.Decimal,15,2)
        };
        Object[] prmT002Y29;
        prmT002Y29 = new Object[] {
        new ParDef("@DocFec",GXType.Date,8,0) ,
        new ParDef("@DocFVcto",GXType.Date,8,0) ,
        new ParDef("@DocCliDirItem",GXType.Int32,6,0) ,
        new ParDef("@DocAnticipos",GXType.Decimal,15,4) ,
        new ParDef("@DocRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@DocDcto",GXType.Decimal,6,2) ,
        new ParDef("@DocPorIVA",GXType.Decimal,6,2) ,
        new ParDef("@DocObs",GXType.NVarChar,1000,0) ,
        new ParDef("@DocTRef",GXType.NChar,3,0) ,
        new ParDef("@DocRef",GXType.NChar,12,0) ,
        new ParDef("@DocSts",GXType.NChar,1,0) ,
        new ParDef("@DocTItem",GXType.Decimal,15,2) ,
        new ParDef("@DocPedCod",GXType.NChar,10,0) ,
        new ParDef("@DocTipo",GXType.NChar,1,0) ,
        new ParDef("@DocFecRef",GXType.Date,8,0) ,
        new ParDef("@DocAlmCod",GXType.Int32,6,0) ,
        new ParDef("@DocCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@DocUsuCod",GXType.NChar,10,0) ,
        new ParDef("@DocUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@DocVouAno",GXType.Int16,4,0) ,
        new ParDef("@DocVouMes",GXType.Int16,2,0) ,
        new ParDef("@DocTASICod",GXType.Int32,6,0) ,
        new ParDef("@DocVouNum",GXType.NChar,10,0) ,
        new ParDef("@DocPercepcion",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@DocAplicaAnticipo",GXType.Decimal,15,2) ,
        new ParDef("@DocCadena",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@DocFEOBS",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@DocAnticipo",GXType.NChar,12,0) ,
        new ParDef("@DocTipAnticipo",GXType.NChar,3,0) ,
        new ParDef("@DocAIVA",GXType.Int16,1,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@DocCliCod",GXType.NChar,20,0) ,
        new ParDef("@DocMonCod",GXType.Int32,6,0) ,
        new ParDef("@DocConpCod",GXType.Int32,6,0) ,
        new ParDef("@DocLisp",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@DocVendCod",GXType.Int32,6,0) ,
        new ParDef("@DocMovCod",GXType.Int32,6,0) ,
        new ParDef("@DocICBPER",GXType.Decimal,15,2) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y30;
        prmT002Y30 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y37;
        prmT002Y37 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y38;
        prmT002Y38 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y39;
        prmT002Y39 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y40;
        prmT002Y40 = new Object[] {
        };
        Object[] prmT002Y31;
        prmT002Y31 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT002Y33;
        prmT002Y33 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT002Y34;
        prmT002Y34 = new Object[] {
        new ParDef("@DocCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002Y41;
        prmT002Y41 = new Object[] {
        new ParDef("@DocMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y35;
        prmT002Y35 = new Object[] {
        new ParDef("@DocConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y42;
        prmT002Y42 = new Object[] {
        new ParDef("@DocLisp",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002Y36;
        prmT002Y36 = new Object[] {
        new ParDef("@DocVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002Y43;
        prmT002Y43 = new Object[] {
        new ParDef("@DocMovCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002Y2", "SELECT [DocNum], [DocFec], [DocFVcto], [DocCliDirItem], [DocAnticipos], [DocRedondeo], [DocDcto], [DocPorIVA], [DocObs], [DocTRef], [DocRef], [DocSts], [DocTItem], [DocPedCod], [DocTipo], [DocFecRef], [DocAlmCod], [DocCosCod], [DocUsuCod], [DocUsuFec], [DocVouAno], [DocVouMes], [DocTASICod], [DocVouNum], [DocPercepcion], [DocAplicaAnticipo], [DocCadena], [DocFEOBS], [DocAnticipo], [DocTipAnticipo], [DocAIVA], [TipCod], [TieCod], [DocCliCod] AS DocCliCod, [DocMonCod] AS DocMonCod, [DocConpCod] AS DocConpCod, [DocLisp] AS DocLisp, [DocVendCod] AS DocVendCod, [DocMovCod] AS DocMovCod FROM [CLVENTAS] WITH (UPDLOCK) WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y3", "SELECT [DocNum], [DocFec], [DocFVcto], [DocCliDirItem], [DocAnticipos], [DocRedondeo], [DocDcto], [DocPorIVA], [DocObs], [DocTRef], [DocRef], [DocSts], [DocTItem], [DocPedCod], [DocTipo], [DocFecRef], [DocAlmCod], [DocCosCod], [DocUsuCod], [DocUsuFec], [DocVouAno], [DocVouMes], [DocTASICod], [DocVouNum], [DocPercepcion], [DocAplicaAnticipo], [DocCadena], [DocFEOBS], [DocAnticipo], [DocTipAnticipo], [DocAIVA], [TipCod], [TieCod], [DocCliCod] AS DocCliCod, [DocMonCod] AS DocMonCod, [DocConpCod] AS DocConpCod, [DocLisp] AS DocLisp, [DocVendCod] AS DocVendCod, [DocMovCod] AS DocMovCod FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y4", "SELECT [TipAbr], [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y5", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y6", "SELECT [CliDsc] AS DocCliDsc, [CliDir] AS DocCliDir FROM [CLCLIENTES] WHERE [CliCod] = @DocCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y7", "SELECT [MonCod] AS DocMonCod FROM [CMONEDAS] WHERE [MonCod] = @DocMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y8", "SELECT [ConpDsc] AS DocConpDsc, [ConpDias] AS DocDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @DocConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y9", "SELECT [TipLCod] AS DocLisp FROM [CTIPOSLISTAS] WHERE [TipLCod] = @DocLisp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y10", "SELECT [VenDsc] AS DocVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @DocVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y11", "SELECT [MovVCod] AS DocMovCod FROM [CMOVVENTAS] WHERE [MovVCod] = @DocMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y13", "SELECT COALESCE( T1.[DocICBPER], 0) AS DocICBPER, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T1.[DocSubGratuito], 0) AS DocSubGratuito FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y15", cmdBufferT002Y15,true, GxErrorMask.GX_NOMASK, false, this,prmT002Y15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y16", "SELECT [TipAbr], [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y18", "SELECT COALESCE( T1.[DocICBPER], 0) AS DocICBPER, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T1.[DocSubGratuito], 0) AS DocSubGratuito FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y19", "SELECT [CliDsc] AS DocCliDsc, [CliDir] AS DocCliDir FROM [CLCLIENTES] WHERE [CliCod] = @DocCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y20", "SELECT [MonCod] AS DocMonCod FROM [CMONEDAS] WHERE [MonCod] = @DocMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y21", "SELECT [ConpDsc] AS DocConpDsc, [ConpDias] AS DocDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @DocConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y22", "SELECT [TipLCod] AS DocLisp FROM [CTIPOSLISTAS] WHERE [TipLCod] = @DocLisp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y23", "SELECT [VenDsc] AS DocVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @DocVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y24", "SELECT [MovVCod] AS DocMovCod FROM [CMOVVENTAS] WHERE [MovVCod] = @DocMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y25", "SELECT [TipCod], [DocNum] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y26", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE ( [TipCod] > @TipCod or [TipCod] = @TipCod and [DocNum] > @DocNum) ORDER BY [TipCod], [DocNum]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y27", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE ( [TipCod] < @TipCod or [TipCod] = @TipCod and [DocNum] < @DocNum) ORDER BY [TipCod] DESC, [DocNum] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y28", "INSERT INTO [CLVENTAS]([DocNum], [DocFec], [DocFVcto], [DocCliDirItem], [DocAnticipos], [DocRedondeo], [DocDcto], [DocPorIVA], [DocObs], [DocTRef], [DocRef], [DocSts], [DocTItem], [DocPedCod], [DocTipo], [DocFecRef], [DocAlmCod], [DocCosCod], [DocUsuCod], [DocUsuFec], [DocVouAno], [DocVouMes], [DocTASICod], [DocVouNum], [DocPercepcion], [DocAplicaAnticipo], [DocCadena], [DocFEOBS], [DocAnticipo], [DocTipAnticipo], [DocAIVA], [TipCod], [TieCod], [DocCliCod], [DocMonCod], [DocConpCod], [DocLisp], [DocVendCod], [DocMovCod], [DocICBPER]) VALUES(@DocNum, @DocFec, @DocFVcto, @DocCliDirItem, @DocAnticipos, @DocRedondeo, @DocDcto, @DocPorIVA, @DocObs, @DocTRef, @DocRef, @DocSts, @DocTItem, @DocPedCod, @DocTipo, @DocFecRef, @DocAlmCod, @DocCosCod, @DocUsuCod, @DocUsuFec, @DocVouAno, @DocVouMes, @DocTASICod, @DocVouNum, @DocPercepcion, @DocAplicaAnticipo, @DocCadena, @DocFEOBS, @DocAnticipo, @DocTipAnticipo, @DocAIVA, @TipCod, @TieCod, @DocCliCod, @DocMonCod, @DocConpCod, @DocLisp, @DocVendCod, @DocMovCod, @DocICBPER)", GxErrorMask.GX_NOMASK,prmT002Y28)
           ,new CursorDef("T002Y29", "UPDATE [CLVENTAS] SET [DocFec]=@DocFec, [DocFVcto]=@DocFVcto, [DocCliDirItem]=@DocCliDirItem, [DocAnticipos]=@DocAnticipos, [DocRedondeo]=@DocRedondeo, [DocDcto]=@DocDcto, [DocPorIVA]=@DocPorIVA, [DocObs]=@DocObs, [DocTRef]=@DocTRef, [DocRef]=@DocRef, [DocSts]=@DocSts, [DocTItem]=@DocTItem, [DocPedCod]=@DocPedCod, [DocTipo]=@DocTipo, [DocFecRef]=@DocFecRef, [DocAlmCod]=@DocAlmCod, [DocCosCod]=@DocCosCod, [DocUsuCod]=@DocUsuCod, [DocUsuFec]=@DocUsuFec, [DocVouAno]=@DocVouAno, [DocVouMes]=@DocVouMes, [DocTASICod]=@DocTASICod, [DocVouNum]=@DocVouNum, [DocPercepcion]=@DocPercepcion, [DocAplicaAnticipo]=@DocAplicaAnticipo, [DocCadena]=@DocCadena, [DocFEOBS]=@DocFEOBS, [DocAnticipo]=@DocAnticipo, [DocTipAnticipo]=@DocTipAnticipo, [DocAIVA]=@DocAIVA, [TieCod]=@TieCod, [DocCliCod]=@DocCliCod, [DocMonCod]=@DocMonCod, [DocConpCod]=@DocConpCod, [DocLisp]=@DocLisp, [DocVendCod]=@DocVendCod, [DocMovCod]=@DocMovCod, [DocICBPER]=@DocICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT002Y29)
           ,new CursorDef("T002Y30", "DELETE FROM [CLVENTAS]  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT002Y30)
           ,new CursorDef("T002Y31", "SELECT [TipAbr], [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y33", "SELECT COALESCE( T1.[DocICBPER], 0) AS DocICBPER, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T1.[DocSubGratuito], 0) AS DocSubGratuito FROM (SELECT SUM([DocDICBPER]) AS DocICBPER, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y34", "SELECT [CliDsc] AS DocCliDsc, [CliDir] AS DocCliDir FROM [CLCLIENTES] WHERE [CliCod] = @DocCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y35", "SELECT [ConpDsc] AS DocConpDsc, [ConpDias] AS DocDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @DocConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y36", "SELECT [VenDsc] AS DocVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @DocVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y37", "SELECT TOP 1 [TipCod], [DocNum], [DocItem] FROM [CLVENTASDET] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y38", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y39", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [DocTip] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Y40", "SELECT [TipCod], [DocNum] FROM [CLVENTAS] ORDER BY [TipCod], [DocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y40,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y41", "SELECT [MonCod] AS DocMonCod FROM [CMONEDAS] WHERE [MonCod] = @DocMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y42", "SELECT [TipLCod] AS DocLisp FROM [CTIPOSLISTAS] WHERE [TipLCod] = @DocLisp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y42,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Y43", "SELECT [MovVCod] AS DocMovCod FROM [CMOVVENTAS] WHERE [MovVCod] = @DocMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Y43,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 12);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 12);
              ((string[]) buf[11])[0] = rslt.getString(12, 1);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((string[]) buf[14])[0] = rslt.getString(15, 1);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 10);
              ((bool[]) buf[18])[0] = rslt.wasNull(18);
              ((string[]) buf[19])[0] = rslt.getString(19, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(20);
              ((short[]) buf[21])[0] = rslt.getShort(21);
              ((short[]) buf[22])[0] = rslt.getShort(22);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((string[]) buf[24])[0] = rslt.getString(24, 10);
              ((string[]) buf[25])[0] = rslt.getString(25, 10);
              ((bool[]) buf[26])[0] = rslt.wasNull(25);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
              ((string[]) buf[28])[0] = rslt.getVarchar(27);
              ((bool[]) buf[29])[0] = rslt.wasNull(27);
              ((string[]) buf[30])[0] = rslt.getVarchar(28);
              ((bool[]) buf[31])[0] = rslt.wasNull(28);
              ((string[]) buf[32])[0] = rslt.getString(29, 12);
              ((string[]) buf[33])[0] = rslt.getString(30, 3);
              ((short[]) buf[34])[0] = rslt.getShort(31);
              ((string[]) buf[35])[0] = rslt.getString(32, 3);
              ((int[]) buf[36])[0] = rslt.getInt(33);
              ((bool[]) buf[37])[0] = rslt.wasNull(33);
              ((string[]) buf[38])[0] = rslt.getString(34, 20);
              ((int[]) buf[39])[0] = rslt.getInt(35);
              ((int[]) buf[40])[0] = rslt.getInt(36);
              ((int[]) buf[41])[0] = rslt.getInt(37);
              ((bool[]) buf[42])[0] = rslt.wasNull(37);
              ((int[]) buf[43])[0] = rslt.getInt(38);
              ((int[]) buf[44])[0] = rslt.getInt(39);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 12);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 12);
              ((string[]) buf[11])[0] = rslt.getString(12, 1);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((string[]) buf[14])[0] = rslt.getString(15, 1);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 10);
              ((bool[]) buf[18])[0] = rslt.wasNull(18);
              ((string[]) buf[19])[0] = rslt.getString(19, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(20);
              ((short[]) buf[21])[0] = rslt.getShort(21);
              ((short[]) buf[22])[0] = rslt.getShort(22);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((string[]) buf[24])[0] = rslt.getString(24, 10);
              ((string[]) buf[25])[0] = rslt.getString(25, 10);
              ((bool[]) buf[26])[0] = rslt.wasNull(25);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
              ((string[]) buf[28])[0] = rslt.getVarchar(27);
              ((bool[]) buf[29])[0] = rslt.wasNull(27);
              ((string[]) buf[30])[0] = rslt.getVarchar(28);
              ((bool[]) buf[31])[0] = rslt.wasNull(28);
              ((string[]) buf[32])[0] = rslt.getString(29, 12);
              ((string[]) buf[33])[0] = rslt.getString(30, 3);
              ((short[]) buf[34])[0] = rslt.getShort(31);
              ((string[]) buf[35])[0] = rslt.getString(32, 3);
              ((int[]) buf[36])[0] = rslt.getInt(33);
              ((bool[]) buf[37])[0] = rslt.wasNull(33);
              ((string[]) buf[38])[0] = rslt.getString(34, 20);
              ((int[]) buf[39])[0] = rslt.getInt(35);
              ((int[]) buf[40])[0] = rslt.getInt(36);
              ((int[]) buf[41])[0] = rslt.getInt(37);
              ((bool[]) buf[42])[0] = rslt.wasNull(37);
              ((int[]) buf[43])[0] = rslt.getInt(38);
              ((int[]) buf[44])[0] = rslt.getInt(39);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 12);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 3);
              ((string[]) buf[15])[0] = rslt.getString(16, 12);
              ((string[]) buf[16])[0] = rslt.getString(17, 1);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((string[]) buf[19])[0] = rslt.getString(20, 1);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 100);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((bool[]) buf[24])[0] = rslt.wasNull(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 10);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(26);
              ((short[]) buf[27])[0] = rslt.getShort(27);
              ((short[]) buf[28])[0] = rslt.getShort(28);
              ((int[]) buf[29])[0] = rslt.getInt(29);
              ((string[]) buf[30])[0] = rslt.getString(30, 10);
              ((string[]) buf[31])[0] = rslt.getString(31, 10);
              ((bool[]) buf[32])[0] = rslt.wasNull(31);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
              ((string[]) buf[34])[0] = rslt.getVarchar(33);
              ((bool[]) buf[35])[0] = rslt.wasNull(33);
              ((string[]) buf[36])[0] = rslt.getVarchar(34);
              ((bool[]) buf[37])[0] = rslt.wasNull(34);
              ((string[]) buf[38])[0] = rslt.getString(35, 12);
              ((string[]) buf[39])[0] = rslt.getString(36, 3);
              ((short[]) buf[40])[0] = rslt.getShort(37);
              ((short[]) buf[41])[0] = rslt.getShort(38);
              ((string[]) buf[42])[0] = rslt.getString(39, 3);
              ((int[]) buf[43])[0] = rslt.getInt(40);
              ((bool[]) buf[44])[0] = rslt.wasNull(40);
              ((string[]) buf[45])[0] = rslt.getString(41, 20);
              ((int[]) buf[46])[0] = rslt.getInt(42);
              ((int[]) buf[47])[0] = rslt.getInt(43);
              ((int[]) buf[48])[0] = rslt.getInt(44);
              ((bool[]) buf[49])[0] = rslt.wasNull(44);
              ((int[]) buf[50])[0] = rslt.getInt(45);
              ((int[]) buf[51])[0] = rslt.getInt(46);
              ((decimal[]) buf[52])[0] = rslt.getDecimal(47);
              ((decimal[]) buf[53])[0] = rslt.getDecimal(48);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(49);
              ((decimal[]) buf[55])[0] = rslt.getDecimal(50);
              ((decimal[]) buf[56])[0] = rslt.getDecimal(51);
              ((decimal[]) buf[57])[0] = rslt.getDecimal(52);
              ((decimal[]) buf[58])[0] = rslt.getDecimal(53);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 27 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 35 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 36 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 37 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
