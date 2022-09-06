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
   public class clcuentacobrar : GXDataArea
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
            A184CCTipCod = GetPar( "CCTipCod");
            AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A184CCTipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A188CCCliCod = GetPar( "CCCliCod");
            AssignAttri("", false, "A188CCCliCod", A188CCCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A188CCCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A187CCmonCod = (int)(NumberUtil.Val( GetPar( "CCmonCod"), "."));
            AssignAttri("", false, "A187CCmonCod", StringUtil.LTrimStr( (decimal)(A187CCmonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A187CCmonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A186CCVendCod = (int)(NumberUtil.Val( GetPar( "CCVendCod"), "."));
            AssignAttri("", false, "A186CCVendCod", StringUtil.LTrimStr( (decimal)(A186CCVendCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A186CCVendCod) ;
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
            Form.Meta.addItem("description", "Cuenta por Cobrar", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clcuentacobrar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clcuentacobrar( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCUENTACOBRAR.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCTipCod_Internalname, StringUtil.RTrim( A184CCTipCod), StringUtil.RTrim( context.localUtil.Format( A184CCTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Numero Doc.", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCDocNum_Internalname, StringUtil.RTrim( A185CCDocNum), StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "R.U.C.", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCCliCod_Internalname, StringUtil.RTrim( A188CCCliCod), StringUtil.RTrim( context.localUtil.Format( A188CCCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCCFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCCFech_Internalname, context.localUtil.Format(A190CCFech, "99/99/99"), context.localUtil.Format( A190CCFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         GxWebStd.gx_bitmap( context, edtCCFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCCFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha Vcto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCCFVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCCFVcto_Internalname, context.localUtil.Format(A508CCFVcto, "99/99/99"), context.localUtil.Format( A508CCFVcto, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCFVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCFVcto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         GxWebStd.gx_bitmap( context, edtCCFVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCCFVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo Moneda", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCmonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CCmonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCCmonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A187CCmonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A187CCmonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCmonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCmonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Importe Total", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCImpTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A513CCImpTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtCCImpTotal_Enabled!=0) ? context.localUtil.Format( A513CCImpTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A513CCImpTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCImpTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCImpTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Pago", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCImpPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A509CCImpPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtCCImpPago_Enabled!=0) ? context.localUtil.Format( A509CCImpPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A509CCImpPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCImpPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCImpPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Estado", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCEstado_Internalname, StringUtil.RTrim( A506CCEstado), StringUtil.RTrim( context.localUtil.Format( A506CCEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCEstado_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Cliente", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCCliDsc_Internalname, StringUtil.RTrim( A189CCCliDsc), StringUtil.RTrim( context.localUtil.Format( A189CCCliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Vendedor", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCCVendCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A186CCVendCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCCVendCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A186CCVendCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A186CCVendCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCVendCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCVendCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Saldo", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCCImpSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A512CCImpSaldo, 17, 2, ".", "")), StringUtil.LTrim( ((edtCCImpSaldo_Enabled!=0) ? context.localUtil.Format( A512CCImpSaldo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A512CCImpSaldo, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCImpSaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCImpSaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Saldo Signo", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCCImpSaldoSig_Internalname, StringUtil.LTrim( StringUtil.NToC( A514CCImpSaldoSig, 17, 2, ".", "")), StringUtil.LTrim( ((edtCCImpSaldoSig_Enabled!=0) ? context.localUtil.Format( A514CCImpSaldoSig, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A514CCImpSaldoSig, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCCImpSaldoSig_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCCImpSaldoSig_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCUENTACOBRAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCUENTACOBRAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLCUENTACOBRAR.htm");
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
            Z184CCTipCod = cgiGet( "Z184CCTipCod");
            Z185CCDocNum = cgiGet( "Z185CCDocNum");
            Z190CCFech = context.localUtil.CToD( cgiGet( "Z190CCFech"), 0);
            Z508CCFVcto = context.localUtil.CToD( cgiGet( "Z508CCFVcto"), 0);
            Z513CCImpTotal = context.localUtil.CToN( cgiGet( "Z513CCImpTotal"), ".", ",");
            Z509CCImpPago = context.localUtil.CToN( cgiGet( "Z509CCImpPago"), ".", ",");
            Z506CCEstado = cgiGet( "Z506CCEstado");
            Z189CCCliDsc = cgiGet( "Z189CCCliDsc");
            Z507CCFecUltPago = context.localUtil.CToD( cgiGet( "Z507CCFecUltPago"), 0);
            Z188CCCliCod = cgiGet( "Z188CCCliCod");
            Z187CCmonCod = (int)(context.localUtil.CToN( cgiGet( "Z187CCmonCod"), ".", ","));
            Z186CCVendCod = (int)(context.localUtil.CToN( cgiGet( "Z186CCVendCod"), ".", ","));
            A507CCFecUltPago = context.localUtil.CToD( cgiGet( "Z507CCFecUltPago"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A511TipSigno = (short)(context.localUtil.CToN( cgiGet( "TIPSIGNO"), ".", ","));
            n511TipSigno = false;
            A515CCImpTotalSig = context.localUtil.CToN( cgiGet( "CCIMPTOTALSIG"), ".", ",");
            A510CCImpPagoSig = context.localUtil.CToN( cgiGet( "CCIMPPAGOSIG"), ".", ",");
            A507CCFecUltPago = context.localUtil.CToD( cgiGet( "CCFECULTPAGO"), 0);
            /* Read variables values. */
            A184CCTipCod = cgiGet( edtCCTipCod_Internalname);
            AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
            A185CCDocNum = cgiGet( edtCCDocNum_Internalname);
            AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
            A188CCCliCod = cgiGet( edtCCCliCod_Internalname);
            AssignAttri("", false, "A188CCCliCod", A188CCCliCod);
            if ( context.localUtil.VCDate( cgiGet( edtCCFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CCFECH");
               AnyError = 1;
               GX_FocusControl = edtCCFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A190CCFech = DateTime.MinValue;
               AssignAttri("", false, "A190CCFech", context.localUtil.Format(A190CCFech, "99/99/99"));
            }
            else
            {
               A190CCFech = context.localUtil.CToD( cgiGet( edtCCFech_Internalname), 2);
               AssignAttri("", false, "A190CCFech", context.localUtil.Format(A190CCFech, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCCFVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "CCFVCTO");
               AnyError = 1;
               GX_FocusControl = edtCCFVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A508CCFVcto = DateTime.MinValue;
               AssignAttri("", false, "A508CCFVcto", context.localUtil.Format(A508CCFVcto, "99/99/99"));
            }
            else
            {
               A508CCFVcto = context.localUtil.CToD( cgiGet( edtCCFVcto_Internalname), 2);
               AssignAttri("", false, "A508CCFVcto", context.localUtil.Format(A508CCFVcto, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCCmonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCCmonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CCMONCOD");
               AnyError = 1;
               GX_FocusControl = edtCCmonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A187CCmonCod = 0;
               AssignAttri("", false, "A187CCmonCod", StringUtil.LTrimStr( (decimal)(A187CCmonCod), 6, 0));
            }
            else
            {
               A187CCmonCod = (int)(context.localUtil.CToN( cgiGet( edtCCmonCod_Internalname), ".", ","));
               AssignAttri("", false, "A187CCmonCod", StringUtil.LTrimStr( (decimal)(A187CCmonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCCImpTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCCImpTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CCIMPTOTAL");
               AnyError = 1;
               GX_FocusControl = edtCCImpTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A513CCImpTotal = 0;
               AssignAttri("", false, "A513CCImpTotal", StringUtil.LTrimStr( A513CCImpTotal, 15, 2));
            }
            else
            {
               A513CCImpTotal = context.localUtil.CToN( cgiGet( edtCCImpTotal_Internalname), ".", ",");
               AssignAttri("", false, "A513CCImpTotal", StringUtil.LTrimStr( A513CCImpTotal, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCCImpPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCCImpPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CCIMPPAGO");
               AnyError = 1;
               GX_FocusControl = edtCCImpPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A509CCImpPago = 0;
               AssignAttri("", false, "A509CCImpPago", StringUtil.LTrimStr( A509CCImpPago, 15, 2));
            }
            else
            {
               A509CCImpPago = context.localUtil.CToN( cgiGet( edtCCImpPago_Internalname), ".", ",");
               AssignAttri("", false, "A509CCImpPago", StringUtil.LTrimStr( A509CCImpPago, 15, 2));
            }
            A506CCEstado = cgiGet( edtCCEstado_Internalname);
            AssignAttri("", false, "A506CCEstado", A506CCEstado);
            A189CCCliDsc = cgiGet( edtCCCliDsc_Internalname);
            AssignAttri("", false, "A189CCCliDsc", A189CCCliDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCCVendCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCCVendCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CCVENDCOD");
               AnyError = 1;
               GX_FocusControl = edtCCVendCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A186CCVendCod = 0;
               AssignAttri("", false, "A186CCVendCod", StringUtil.LTrimStr( (decimal)(A186CCVendCod), 6, 0));
            }
            else
            {
               A186CCVendCod = (int)(context.localUtil.CToN( cgiGet( edtCCVendCod_Internalname), ".", ","));
               AssignAttri("", false, "A186CCVendCod", StringUtil.LTrimStr( (decimal)(A186CCVendCod), 6, 0));
            }
            A512CCImpSaldo = context.localUtil.CToN( cgiGet( edtCCImpSaldo_Internalname), ".", ",");
            AssignAttri("", false, "A512CCImpSaldo", StringUtil.LTrimStr( A512CCImpSaldo, 15, 2));
            A514CCImpSaldoSig = context.localUtil.CToN( cgiGet( edtCCImpSaldoSig_Internalname), ".", ",");
            AssignAttri("", false, "A514CCImpSaldoSig", StringUtil.LTrimStr( A514CCImpSaldoSig, 15, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLCUENTACOBRAR");
            forbiddenHiddens.Add("CCFecUltPago", context.localUtil.Format(A507CCFecUltPago, "99/99/99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A184CCTipCod, Z184CCTipCod) != 0 ) || ( StringUtil.StrCmp(A185CCDocNum, Z185CCDocNum) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clcuentacobrar:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A184CCTipCod = GetPar( "CCTipCod");
               AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
               A185CCDocNum = GetPar( "CCDocNum");
               AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
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
               InitAll2K88( ) ;
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
         DisableAttributes2K88( ) ;
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

      protected void CONFIRM_2K0( )
      {
         BeforeValidate2K88( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2K88( ) ;
            }
            else
            {
               CheckExtendedTable2K88( ) ;
               if ( AnyError == 0 )
               {
                  ZM2K88( 8) ;
                  ZM2K88( 9) ;
                  ZM2K88( 10) ;
                  ZM2K88( 11) ;
               }
               CloseExtendedTableCursors2K88( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2K0( ) ;
         }
      }

      protected void ResetCaption2K0( )
      {
      }

      protected void ZM2K88( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z190CCFech = T002K3_A190CCFech[0];
               Z508CCFVcto = T002K3_A508CCFVcto[0];
               Z513CCImpTotal = T002K3_A513CCImpTotal[0];
               Z509CCImpPago = T002K3_A509CCImpPago[0];
               Z506CCEstado = T002K3_A506CCEstado[0];
               Z189CCCliDsc = T002K3_A189CCCliDsc[0];
               Z507CCFecUltPago = T002K3_A507CCFecUltPago[0];
               Z188CCCliCod = T002K3_A188CCCliCod[0];
               Z187CCmonCod = T002K3_A187CCmonCod[0];
               Z186CCVendCod = T002K3_A186CCVendCod[0];
            }
            else
            {
               Z190CCFech = A190CCFech;
               Z508CCFVcto = A508CCFVcto;
               Z513CCImpTotal = A513CCImpTotal;
               Z509CCImpPago = A509CCImpPago;
               Z506CCEstado = A506CCEstado;
               Z189CCCliDsc = A189CCCliDsc;
               Z507CCFecUltPago = A507CCFecUltPago;
               Z188CCCliCod = A188CCCliCod;
               Z187CCmonCod = A187CCmonCod;
               Z186CCVendCod = A186CCVendCod;
            }
         }
         if ( GX_JID == -7 )
         {
            Z185CCDocNum = A185CCDocNum;
            Z190CCFech = A190CCFech;
            Z508CCFVcto = A508CCFVcto;
            Z513CCImpTotal = A513CCImpTotal;
            Z509CCImpPago = A509CCImpPago;
            Z506CCEstado = A506CCEstado;
            Z189CCCliDsc = A189CCCliDsc;
            Z507CCFecUltPago = A507CCFecUltPago;
            Z184CCTipCod = A184CCTipCod;
            Z188CCCliCod = A188CCCliCod;
            Z187CCmonCod = A187CCmonCod;
            Z186CCVendCod = A186CCVendCod;
            Z511TipSigno = A511TipSigno;
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

      protected void Load2K88( )
      {
         /* Using cursor T002K8 */
         pr_default.execute(6, new Object[] {A184CCTipCod, A185CCDocNum});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound88 = 1;
            A190CCFech = T002K8_A190CCFech[0];
            AssignAttri("", false, "A190CCFech", context.localUtil.Format(A190CCFech, "99/99/99"));
            A508CCFVcto = T002K8_A508CCFVcto[0];
            AssignAttri("", false, "A508CCFVcto", context.localUtil.Format(A508CCFVcto, "99/99/99"));
            A513CCImpTotal = T002K8_A513CCImpTotal[0];
            AssignAttri("", false, "A513CCImpTotal", StringUtil.LTrimStr( A513CCImpTotal, 15, 2));
            A509CCImpPago = T002K8_A509CCImpPago[0];
            AssignAttri("", false, "A509CCImpPago", StringUtil.LTrimStr( A509CCImpPago, 15, 2));
            A506CCEstado = T002K8_A506CCEstado[0];
            AssignAttri("", false, "A506CCEstado", A506CCEstado);
            A189CCCliDsc = T002K8_A189CCCliDsc[0];
            AssignAttri("", false, "A189CCCliDsc", A189CCCliDsc);
            A507CCFecUltPago = T002K8_A507CCFecUltPago[0];
            A511TipSigno = T002K8_A511TipSigno[0];
            n511TipSigno = T002K8_n511TipSigno[0];
            A188CCCliCod = T002K8_A188CCCliCod[0];
            AssignAttri("", false, "A188CCCliCod", A188CCCliCod);
            A187CCmonCod = T002K8_A187CCmonCod[0];
            AssignAttri("", false, "A187CCmonCod", StringUtil.LTrimStr( (decimal)(A187CCmonCod), 6, 0));
            A186CCVendCod = T002K8_A186CCVendCod[0];
            AssignAttri("", false, "A186CCVendCod", StringUtil.LTrimStr( (decimal)(A186CCVendCod), 6, 0));
            ZM2K88( -7) ;
         }
         pr_default.close(6);
         OnLoadActions2K88( ) ;
      }

      protected void OnLoadActions2K88( )
      {
         A515CCImpTotalSig = (decimal)(A513CCImpTotal*A511TipSigno);
         AssignAttri("", false, "A515CCImpTotalSig", StringUtil.LTrimStr( A515CCImpTotalSig, 15, 2));
         A510CCImpPagoSig = (decimal)(A509CCImpPago*A511TipSigno);
         AssignAttri("", false, "A510CCImpPagoSig", StringUtil.LTrimStr( A510CCImpPagoSig, 15, 2));
         A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
         AssignAttri("", false, "A512CCImpSaldo", StringUtil.LTrimStr( A512CCImpSaldo, 15, 2));
         A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
         AssignAttri("", false, "A514CCImpSaldoSig", StringUtil.LTrimStr( A514CCImpSaldoSig, 15, 2));
      }

      protected void CheckExtendedTable2K88( )
      {
         nIsDirty_88 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002K4 */
         pr_default.execute(2, new Object[] {A184CCTipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cuenta Cobrar Tipo Documento'.", "ForeignKeyNotFound", 1, "CCTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A511TipSigno = T002K4_A511TipSigno[0];
         n511TipSigno = T002K4_n511TipSigno[0];
         pr_default.close(2);
         nIsDirty_88 = 1;
         A515CCImpTotalSig = (decimal)(A513CCImpTotal*A511TipSigno);
         AssignAttri("", false, "A515CCImpTotalSig", StringUtil.LTrimStr( A515CCImpTotalSig, 15, 2));
         nIsDirty_88 = 1;
         A510CCImpPagoSig = (decimal)(A509CCImpPago*A511TipSigno);
         AssignAttri("", false, "A510CCImpPagoSig", StringUtil.LTrimStr( A510CCImpPagoSig, 15, 2));
         /* Using cursor T002K5 */
         pr_default.execute(3, new Object[] {A188CCCliCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCCCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A190CCFech) || ( DateTimeUtil.ResetTime ( A190CCFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CCFECH");
            AnyError = 1;
            GX_FocusControl = edtCCFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A508CCFVcto) || ( DateTimeUtil.ResetTime ( A508CCFVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "CCFVCTO");
            AnyError = 1;
            GX_FocusControl = edtCCFVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002K6 */
         pr_default.execute(4, new Object[] {A187CCmonCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Cobrar Moneda'.", "ForeignKeyNotFound", 1, "CCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCCmonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         nIsDirty_88 = 1;
         A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
         AssignAttri("", false, "A512CCImpSaldo", StringUtil.LTrimStr( A512CCImpSaldo, 15, 2));
         nIsDirty_88 = 1;
         A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
         AssignAttri("", false, "A514CCImpSaldoSig", StringUtil.LTrimStr( A514CCImpSaldoSig, 15, 2));
         /* Using cursor T002K7 */
         pr_default.execute(5, new Object[] {A186CCVendCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "CCVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCCVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors2K88( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( string A184CCTipCod )
      {
         /* Using cursor T002K9 */
         pr_default.execute(7, new Object[] {A184CCTipCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cuenta Cobrar Tipo Documento'.", "ForeignKeyNotFound", 1, "CCTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A511TipSigno = T002K9_A511TipSigno[0];
         n511TipSigno = T002K9_n511TipSigno[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_9( string A188CCCliCod )
      {
         /* Using cursor T002K10 */
         pr_default.execute(8, new Object[] {A188CCCliCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCCCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_10( int A187CCmonCod )
      {
         /* Using cursor T002K11 */
         pr_default.execute(9, new Object[] {A187CCmonCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Cobrar Moneda'.", "ForeignKeyNotFound", 1, "CCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCCmonCod_Internalname;
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

      protected void gxLoad_11( int A186CCVendCod )
      {
         /* Using cursor T002K12 */
         pr_default.execute(10, new Object[] {A186CCVendCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "CCVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCCVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey2K88( )
      {
         /* Using cursor T002K13 */
         pr_default.execute(11, new Object[] {A184CCTipCod, A185CCDocNum});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound88 = 1;
         }
         else
         {
            RcdFound88 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002K3 */
         pr_default.execute(1, new Object[] {A184CCTipCod, A185CCDocNum});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2K88( 7) ;
            RcdFound88 = 1;
            A185CCDocNum = T002K3_A185CCDocNum[0];
            AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
            A190CCFech = T002K3_A190CCFech[0];
            AssignAttri("", false, "A190CCFech", context.localUtil.Format(A190CCFech, "99/99/99"));
            A508CCFVcto = T002K3_A508CCFVcto[0];
            AssignAttri("", false, "A508CCFVcto", context.localUtil.Format(A508CCFVcto, "99/99/99"));
            A513CCImpTotal = T002K3_A513CCImpTotal[0];
            AssignAttri("", false, "A513CCImpTotal", StringUtil.LTrimStr( A513CCImpTotal, 15, 2));
            A509CCImpPago = T002K3_A509CCImpPago[0];
            AssignAttri("", false, "A509CCImpPago", StringUtil.LTrimStr( A509CCImpPago, 15, 2));
            A506CCEstado = T002K3_A506CCEstado[0];
            AssignAttri("", false, "A506CCEstado", A506CCEstado);
            A189CCCliDsc = T002K3_A189CCCliDsc[0];
            AssignAttri("", false, "A189CCCliDsc", A189CCCliDsc);
            A507CCFecUltPago = T002K3_A507CCFecUltPago[0];
            A184CCTipCod = T002K3_A184CCTipCod[0];
            AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
            A188CCCliCod = T002K3_A188CCCliCod[0];
            AssignAttri("", false, "A188CCCliCod", A188CCCliCod);
            A187CCmonCod = T002K3_A187CCmonCod[0];
            AssignAttri("", false, "A187CCmonCod", StringUtil.LTrimStr( (decimal)(A187CCmonCod), 6, 0));
            A186CCVendCod = T002K3_A186CCVendCod[0];
            AssignAttri("", false, "A186CCVendCod", StringUtil.LTrimStr( (decimal)(A186CCVendCod), 6, 0));
            Z184CCTipCod = A184CCTipCod;
            Z185CCDocNum = A185CCDocNum;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2K88( ) ;
            if ( AnyError == 1 )
            {
               RcdFound88 = 0;
               InitializeNonKey2K88( ) ;
            }
            Gx_mode = sMode88;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound88 = 0;
            InitializeNonKey2K88( ) ;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode88;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2K88( ) ;
         if ( RcdFound88 == 0 )
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
         RcdFound88 = 0;
         /* Using cursor T002K14 */
         pr_default.execute(12, new Object[] {A184CCTipCod, A185CCDocNum});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T002K14_A184CCTipCod[0], A184CCTipCod) < 0 ) || ( StringUtil.StrCmp(T002K14_A184CCTipCod[0], A184CCTipCod) == 0 ) && ( StringUtil.StrCmp(T002K14_A185CCDocNum[0], A185CCDocNum) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T002K14_A184CCTipCod[0], A184CCTipCod) > 0 ) || ( StringUtil.StrCmp(T002K14_A184CCTipCod[0], A184CCTipCod) == 0 ) && ( StringUtil.StrCmp(T002K14_A185CCDocNum[0], A185CCDocNum) > 0 ) ) )
            {
               A184CCTipCod = T002K14_A184CCTipCod[0];
               AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
               A185CCDocNum = T002K14_A185CCDocNum[0];
               AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
               RcdFound88 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound88 = 0;
         /* Using cursor T002K15 */
         pr_default.execute(13, new Object[] {A184CCTipCod, A185CCDocNum});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002K15_A184CCTipCod[0], A184CCTipCod) > 0 ) || ( StringUtil.StrCmp(T002K15_A184CCTipCod[0], A184CCTipCod) == 0 ) && ( StringUtil.StrCmp(T002K15_A185CCDocNum[0], A185CCDocNum) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002K15_A184CCTipCod[0], A184CCTipCod) < 0 ) || ( StringUtil.StrCmp(T002K15_A184CCTipCod[0], A184CCTipCod) == 0 ) && ( StringUtil.StrCmp(T002K15_A185CCDocNum[0], A185CCDocNum) < 0 ) ) )
            {
               A184CCTipCod = T002K15_A184CCTipCod[0];
               AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
               A185CCDocNum = T002K15_A185CCDocNum[0];
               AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
               RcdFound88 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2K88( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2K88( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound88 == 1 )
            {
               if ( ( StringUtil.StrCmp(A184CCTipCod, Z184CCTipCod) != 0 ) || ( StringUtil.StrCmp(A185CCDocNum, Z185CCDocNum) != 0 ) )
               {
                  A184CCTipCod = Z184CCTipCod;
                  AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
                  A185CCDocNum = Z185CCDocNum;
                  AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CCTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCCTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCCTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2K88( ) ;
                  GX_FocusControl = edtCCTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A184CCTipCod, Z184CCTipCod) != 0 ) || ( StringUtil.StrCmp(A185CCDocNum, Z185CCDocNum) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCCTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2K88( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CCTIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCCTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCCTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2K88( ) ;
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
         if ( ( StringUtil.StrCmp(A184CCTipCod, Z184CCTipCod) != 0 ) || ( StringUtil.StrCmp(A185CCDocNum, Z185CCDocNum) != 0 ) )
         {
            A184CCTipCod = Z184CCTipCod;
            AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
            A185CCDocNum = Z185CCDocNum;
            AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CCTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCCTipCod_Internalname;
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
         GetKey2K88( ) ;
         if ( RcdFound88 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CCTIPCOD");
               AnyError = 1;
               GX_FocusControl = edtCCTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A184CCTipCod, Z184CCTipCod) != 0 ) || ( StringUtil.StrCmp(A185CCDocNum, Z185CCDocNum) != 0 ) )
            {
               A184CCTipCod = Z184CCTipCod;
               AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
               A185CCDocNum = Z185CCDocNum;
               AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CCTIPCOD");
               AnyError = 1;
               GX_FocusControl = edtCCTipCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A184CCTipCod, Z184CCTipCod) != 0 ) || ( StringUtil.StrCmp(A185CCDocNum, Z185CCDocNum) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CCTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCCTipCod_Internalname;
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
         context.RollbackDataStores("clcuentacobrar",pr_default);
         GX_FocusControl = edtCCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2K0( ) ;
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
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CCTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2K88( ) ;
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2K88( ) ;
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
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCCCliCod_Internalname;
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
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCCCliCod_Internalname;
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
         ScanStart2K88( ) ;
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound88 != 0 )
            {
               ScanNext2K88( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2K88( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2K88( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002K2 */
            pr_default.execute(0, new Object[] {A184CCTipCod, A185CCDocNum});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCUENTACOBRAR"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z190CCFech ) != DateTimeUtil.ResetTime ( T002K2_A190CCFech[0] ) ) || ( DateTimeUtil.ResetTime ( Z508CCFVcto ) != DateTimeUtil.ResetTime ( T002K2_A508CCFVcto[0] ) ) || ( Z513CCImpTotal != T002K2_A513CCImpTotal[0] ) || ( Z509CCImpPago != T002K2_A509CCImpPago[0] ) || ( StringUtil.StrCmp(Z506CCEstado, T002K2_A506CCEstado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z189CCCliDsc, T002K2_A189CCCliDsc[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z507CCFecUltPago ) != DateTimeUtil.ResetTime ( T002K2_A507CCFecUltPago[0] ) ) || ( StringUtil.StrCmp(Z188CCCliCod, T002K2_A188CCCliCod[0]) != 0 ) || ( Z187CCmonCod != T002K2_A187CCmonCod[0] ) || ( Z186CCVendCod != T002K2_A186CCVendCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z190CCFech ) != DateTimeUtil.ResetTime ( T002K2_A190CCFech[0] ) )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCFech");
                  GXUtil.WriteLogRaw("Old: ",Z190CCFech);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A190CCFech[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z508CCFVcto ) != DateTimeUtil.ResetTime ( T002K2_A508CCFVcto[0] ) )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCFVcto");
                  GXUtil.WriteLogRaw("Old: ",Z508CCFVcto);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A508CCFVcto[0]);
               }
               if ( Z513CCImpTotal != T002K2_A513CCImpTotal[0] )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCImpTotal");
                  GXUtil.WriteLogRaw("Old: ",Z513CCImpTotal);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A513CCImpTotal[0]);
               }
               if ( Z509CCImpPago != T002K2_A509CCImpPago[0] )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCImpPago");
                  GXUtil.WriteLogRaw("Old: ",Z509CCImpPago);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A509CCImpPago[0]);
               }
               if ( StringUtil.StrCmp(Z506CCEstado, T002K2_A506CCEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCEstado");
                  GXUtil.WriteLogRaw("Old: ",Z506CCEstado);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A506CCEstado[0]);
               }
               if ( StringUtil.StrCmp(Z189CCCliDsc, T002K2_A189CCCliDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCCliDsc");
                  GXUtil.WriteLogRaw("Old: ",Z189CCCliDsc);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A189CCCliDsc[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z507CCFecUltPago ) != DateTimeUtil.ResetTime ( T002K2_A507CCFecUltPago[0] ) )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCFecUltPago");
                  GXUtil.WriteLogRaw("Old: ",Z507CCFecUltPago);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A507CCFecUltPago[0]);
               }
               if ( StringUtil.StrCmp(Z188CCCliCod, T002K2_A188CCCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z188CCCliCod);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A188CCCliCod[0]);
               }
               if ( Z187CCmonCod != T002K2_A187CCmonCod[0] )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCmonCod");
                  GXUtil.WriteLogRaw("Old: ",Z187CCmonCod);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A187CCmonCod[0]);
               }
               if ( Z186CCVendCod != T002K2_A186CCVendCod[0] )
               {
                  GXUtil.WriteLog("clcuentacobrar:[seudo value changed for attri]"+"CCVendCod");
                  GXUtil.WriteLogRaw("Old: ",Z186CCVendCod);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A186CCVendCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCUENTACOBRAR"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K88( )
      {
         BeforeValidate2K88( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K88( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K88( 0) ;
            CheckOptimisticConcurrency2K88( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K88( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K88( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K16 */
                     pr_default.execute(14, new Object[] {A185CCDocNum, A190CCFech, A508CCFVcto, A513CCImpTotal, A509CCImpPago, A506CCEstado, A189CCCliDsc, A507CCFecUltPago, A184CCTipCod, A188CCCliCod, A187CCmonCod, A186CCVendCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCUENTACOBRAR");
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
                           ResetCaption2K0( ) ;
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
               Load2K88( ) ;
            }
            EndLevel2K88( ) ;
         }
         CloseExtendedTableCursors2K88( ) ;
      }

      protected void Update2K88( )
      {
         BeforeValidate2K88( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K88( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K88( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K88( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K88( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K17 */
                     pr_default.execute(15, new Object[] {A190CCFech, A508CCFVcto, A513CCImpTotal, A509CCImpPago, A506CCEstado, A189CCCliDsc, A507CCFecUltPago, A188CCCliCod, A187CCmonCod, A186CCVendCod, A184CCTipCod, A185CCDocNum});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCUENTACOBRAR");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCUENTACOBRAR"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K88( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2K0( ) ;
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
            EndLevel2K88( ) ;
         }
         CloseExtendedTableCursors2K88( ) ;
      }

      protected void DeferredUpdate2K88( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2K88( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K88( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K88( ) ;
            AfterConfirm2K88( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K88( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002K18 */
                  pr_default.execute(16, new Object[] {A184CCTipCod, A185CCDocNum});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCUENTACOBRAR");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound88 == 0 )
                        {
                           InitAll2K88( ) ;
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
                        ResetCaption2K0( ) ;
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
         sMode88 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2K88( ) ;
         Gx_mode = sMode88;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2K88( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002K19 */
            pr_default.execute(17, new Object[] {A184CCTipCod});
            A511TipSigno = T002K19_A511TipSigno[0];
            n511TipSigno = T002K19_n511TipSigno[0];
            pr_default.close(17);
            A515CCImpTotalSig = (decimal)(A513CCImpTotal*A511TipSigno);
            AssignAttri("", false, "A515CCImpTotalSig", StringUtil.LTrimStr( A515CCImpTotalSig, 15, 2));
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            AssignAttri("", false, "A512CCImpSaldo", StringUtil.LTrimStr( A512CCImpSaldo, 15, 2));
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AssignAttri("", false, "A514CCImpSaldoSig", StringUtil.LTrimStr( A514CCImpSaldoSig, 15, 2));
            A510CCImpPagoSig = (decimal)(A509CCImpPago*A511TipSigno);
            AssignAttri("", false, "A510CCImpPagoSig", StringUtil.LTrimStr( A510CCImpPagoSig, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002K20 */
            pr_default.execute(18, new Object[] {A184CCTipCod, A185CCDocNum});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Comprobante de Percepción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T002K21 */
            pr_default.execute(19, new Object[] {A184CCTipCod, A185CCDocNum});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002K22 */
            pr_default.execute(20, new Object[] {A184CCTipCod, A185CCDocNum});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T002K23 */
            pr_default.execute(21, new Object[] {A184CCTipCod, A185CCDocNum});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQDIFERIDODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel2K88( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2K88( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            context.CommitDataStores("clcuentacobrar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            context.RollbackDataStores("clcuentacobrar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2K88( )
      {
         /* Using cursor T002K24 */
         pr_default.execute(22);
         RcdFound88 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound88 = 1;
            A184CCTipCod = T002K24_A184CCTipCod[0];
            AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
            A185CCDocNum = T002K24_A185CCDocNum[0];
            AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2K88( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound88 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound88 = 1;
            A184CCTipCod = T002K24_A184CCTipCod[0];
            AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
            A185CCDocNum = T002K24_A185CCDocNum[0];
            AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
         }
      }

      protected void ScanEnd2K88( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm2K88( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K88( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K88( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K88( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K88( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K88( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K88( )
      {
         edtCCTipCod_Enabled = 0;
         AssignProp("", false, edtCCTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCTipCod_Enabled), 5, 0), true);
         edtCCDocNum_Enabled = 0;
         AssignProp("", false, edtCCDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDocNum_Enabled), 5, 0), true);
         edtCCCliCod_Enabled = 0;
         AssignProp("", false, edtCCCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCCliCod_Enabled), 5, 0), true);
         edtCCFech_Enabled = 0;
         AssignProp("", false, edtCCFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCFech_Enabled), 5, 0), true);
         edtCCFVcto_Enabled = 0;
         AssignProp("", false, edtCCFVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCFVcto_Enabled), 5, 0), true);
         edtCCmonCod_Enabled = 0;
         AssignProp("", false, edtCCmonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCmonCod_Enabled), 5, 0), true);
         edtCCImpTotal_Enabled = 0;
         AssignProp("", false, edtCCImpTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCImpTotal_Enabled), 5, 0), true);
         edtCCImpPago_Enabled = 0;
         AssignProp("", false, edtCCImpPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCImpPago_Enabled), 5, 0), true);
         edtCCEstado_Enabled = 0;
         AssignProp("", false, edtCCEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCEstado_Enabled), 5, 0), true);
         edtCCCliDsc_Enabled = 0;
         AssignProp("", false, edtCCCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCCliDsc_Enabled), 5, 0), true);
         edtCCVendCod_Enabled = 0;
         AssignProp("", false, edtCCVendCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCVendCod_Enabled), 5, 0), true);
         edtCCImpSaldo_Enabled = 0;
         AssignProp("", false, edtCCImpSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCImpSaldo_Enabled), 5, 0), true);
         edtCCImpSaldoSig_Enabled = 0;
         AssignProp("", false, edtCCImpSaldoSig_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCImpSaldoSig_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2K88( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2K0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816424591", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clcuentacobrar.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLCUENTACOBRAR");
         forbiddenHiddens.Add("CCFecUltPago", context.localUtil.Format(A507CCFecUltPago, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clcuentacobrar:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z184CCTipCod", StringUtil.RTrim( Z184CCTipCod));
         GxWebStd.gx_hidden_field( context, "Z185CCDocNum", StringUtil.RTrim( Z185CCDocNum));
         GxWebStd.gx_hidden_field( context, "Z190CCFech", context.localUtil.DToC( Z190CCFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z508CCFVcto", context.localUtil.DToC( Z508CCFVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z513CCImpTotal", StringUtil.LTrim( StringUtil.NToC( Z513CCImpTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z509CCImpPago", StringUtil.LTrim( StringUtil.NToC( Z509CCImpPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z506CCEstado", StringUtil.RTrim( Z506CCEstado));
         GxWebStd.gx_hidden_field( context, "Z189CCCliDsc", StringUtil.RTrim( Z189CCCliDsc));
         GxWebStd.gx_hidden_field( context, "Z507CCFecUltPago", context.localUtil.DToC( Z507CCFecUltPago, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z188CCCliCod", StringUtil.RTrim( Z188CCCliCod));
         GxWebStd.gx_hidden_field( context, "Z187CCmonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z187CCmonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z186CCVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z186CCVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "TIPSIGNO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CCIMPTOTALSIG", StringUtil.LTrim( StringUtil.NToC( A515CCImpTotalSig, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CCIMPPAGOSIG", StringUtil.LTrim( StringUtil.NToC( A510CCImpPagoSig, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CCFECULTPAGO", context.localUtil.DToC( A507CCFecUltPago, 0, "/"));
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
         return formatLink("clcuentacobrar.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCUENTACOBRAR" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cuenta por Cobrar" ;
      }

      protected void InitializeNonKey2K88( )
      {
         A514CCImpSaldoSig = 0;
         AssignAttri("", false, "A514CCImpSaldoSig", StringUtil.LTrimStr( A514CCImpSaldoSig, 15, 2));
         A510CCImpPagoSig = 0;
         AssignAttri("", false, "A510CCImpPagoSig", StringUtil.LTrimStr( A510CCImpPagoSig, 15, 2));
         A512CCImpSaldo = 0;
         AssignAttri("", false, "A512CCImpSaldo", StringUtil.LTrimStr( A512CCImpSaldo, 15, 2));
         A515CCImpTotalSig = 0;
         AssignAttri("", false, "A515CCImpTotalSig", StringUtil.LTrimStr( A515CCImpTotalSig, 15, 2));
         A188CCCliCod = "";
         AssignAttri("", false, "A188CCCliCod", A188CCCliCod);
         A190CCFech = DateTime.MinValue;
         AssignAttri("", false, "A190CCFech", context.localUtil.Format(A190CCFech, "99/99/99"));
         A508CCFVcto = DateTime.MinValue;
         AssignAttri("", false, "A508CCFVcto", context.localUtil.Format(A508CCFVcto, "99/99/99"));
         A187CCmonCod = 0;
         AssignAttri("", false, "A187CCmonCod", StringUtil.LTrimStr( (decimal)(A187CCmonCod), 6, 0));
         A513CCImpTotal = 0;
         AssignAttri("", false, "A513CCImpTotal", StringUtil.LTrimStr( A513CCImpTotal, 15, 2));
         A509CCImpPago = 0;
         AssignAttri("", false, "A509CCImpPago", StringUtil.LTrimStr( A509CCImpPago, 15, 2));
         A506CCEstado = "";
         AssignAttri("", false, "A506CCEstado", A506CCEstado);
         A189CCCliDsc = "";
         AssignAttri("", false, "A189CCCliDsc", A189CCCliDsc);
         A186CCVendCod = 0;
         AssignAttri("", false, "A186CCVendCod", StringUtil.LTrimStr( (decimal)(A186CCVendCod), 6, 0));
         A507CCFecUltPago = DateTime.MinValue;
         AssignAttri("", false, "A507CCFecUltPago", context.localUtil.Format(A507CCFecUltPago, "99/99/99"));
         A511TipSigno = 0;
         n511TipSigno = false;
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
         Z190CCFech = DateTime.MinValue;
         Z508CCFVcto = DateTime.MinValue;
         Z513CCImpTotal = 0;
         Z509CCImpPago = 0;
         Z506CCEstado = "";
         Z189CCCliDsc = "";
         Z507CCFecUltPago = DateTime.MinValue;
         Z188CCCliCod = "";
         Z187CCmonCod = 0;
         Z186CCVendCod = 0;
      }

      protected void InitAll2K88( )
      {
         A184CCTipCod = "";
         AssignAttri("", false, "A184CCTipCod", A184CCTipCod);
         A185CCDocNum = "";
         AssignAttri("", false, "A185CCDocNum", A185CCDocNum);
         InitializeNonKey2K88( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181642467", true, true);
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
         context.AddJavascriptSource("clcuentacobrar.js", "?20228181642467", false, true);
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
         edtCCTipCod_Internalname = "CCTIPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCCDocNum_Internalname = "CCDOCNUM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCCCliCod_Internalname = "CCCLICOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCCFech_Internalname = "CCFECH";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCCFVcto_Internalname = "CCFVCTO";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCCmonCod_Internalname = "CCMONCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCCImpTotal_Internalname = "CCIMPTOTAL";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCCImpPago_Internalname = "CCIMPPAGO";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCCEstado_Internalname = "CCESTADO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCCCliDsc_Internalname = "CCCLIDSC";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCCVendCod_Internalname = "CCVENDCOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtCCImpSaldo_Internalname = "CCIMPSALDO";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtCCImpSaldoSig_Internalname = "CCIMPSALDOSIG";
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
         Form.Caption = "Cuenta por Cobrar";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCCImpSaldoSig_Jsonclick = "";
         edtCCImpSaldoSig_Enabled = 0;
         edtCCImpSaldo_Jsonclick = "";
         edtCCImpSaldo_Enabled = 0;
         edtCCVendCod_Jsonclick = "";
         edtCCVendCod_Enabled = 1;
         edtCCCliDsc_Jsonclick = "";
         edtCCCliDsc_Enabled = 1;
         edtCCEstado_Jsonclick = "";
         edtCCEstado_Enabled = 1;
         edtCCImpPago_Jsonclick = "";
         edtCCImpPago_Enabled = 1;
         edtCCImpTotal_Jsonclick = "";
         edtCCImpTotal_Enabled = 1;
         edtCCmonCod_Jsonclick = "";
         edtCCmonCod_Enabled = 1;
         edtCCFVcto_Jsonclick = "";
         edtCCFVcto_Enabled = 1;
         edtCCFech_Jsonclick = "";
         edtCCFech_Enabled = 1;
         edtCCCliCod_Jsonclick = "";
         edtCCCliCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCCDocNum_Jsonclick = "";
         edtCCDocNum_Enabled = 1;
         edtCCTipCod_Jsonclick = "";
         edtCCTipCod_Enabled = 1;
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
         /* Using cursor T002K19 */
         pr_default.execute(17, new Object[] {A184CCTipCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cuenta Cobrar Tipo Documento'.", "ForeignKeyNotFound", 1, "CCTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCCTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A511TipSigno = T002K19_A511TipSigno[0];
         n511TipSigno = T002K19_n511TipSigno[0];
         pr_default.close(17);
         GX_FocusControl = edtCCCliCod_Internalname;
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

      public void Valid_Cctipcod( )
      {
         n511TipSigno = false;
         /* Using cursor T002K19 */
         pr_default.execute(17, new Object[] {A184CCTipCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cuenta Cobrar Tipo Documento'.", "ForeignKeyNotFound", 1, "CCTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCCTipCod_Internalname;
         }
         A511TipSigno = T002K19_A511TipSigno[0];
         n511TipSigno = T002K19_n511TipSigno[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
      }

      public void Valid_Ccdocnum( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A188CCCliCod", StringUtil.RTrim( A188CCCliCod));
         AssignAttri("", false, "A190CCFech", context.localUtil.Format(A190CCFech, "99/99/99"));
         AssignAttri("", false, "A508CCFVcto", context.localUtil.Format(A508CCFVcto, "99/99/99"));
         AssignAttri("", false, "A187CCmonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CCmonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A513CCImpTotal", StringUtil.LTrim( StringUtil.NToC( A513CCImpTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A509CCImpPago", StringUtil.LTrim( StringUtil.NToC( A509CCImpPago, 15, 2, ".", "")));
         AssignAttri("", false, "A506CCEstado", StringUtil.RTrim( A506CCEstado));
         AssignAttri("", false, "A189CCCliDsc", StringUtil.RTrim( A189CCCliDsc));
         AssignAttri("", false, "A186CCVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A186CCVendCod), 6, 0, ".", "")));
         AssignAttri("", false, "A507CCFecUltPago", context.localUtil.Format(A507CCFecUltPago, "99/99/99"));
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         AssignAttri("", false, "A515CCImpTotalSig", StringUtil.LTrim( StringUtil.NToC( A515CCImpTotalSig, 15, 2, ".", "")));
         AssignAttri("", false, "A510CCImpPagoSig", StringUtil.LTrim( StringUtil.NToC( A510CCImpPagoSig, 15, 2, ".", "")));
         AssignAttri("", false, "A512CCImpSaldo", StringUtil.LTrim( StringUtil.NToC( A512CCImpSaldo, 15, 2, ".", "")));
         AssignAttri("", false, "A514CCImpSaldoSig", StringUtil.LTrim( StringUtil.NToC( A514CCImpSaldoSig, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z184CCTipCod", StringUtil.RTrim( Z184CCTipCod));
         GxWebStd.gx_hidden_field( context, "Z185CCDocNum", StringUtil.RTrim( Z185CCDocNum));
         GxWebStd.gx_hidden_field( context, "Z188CCCliCod", StringUtil.RTrim( Z188CCCliCod));
         GxWebStd.gx_hidden_field( context, "Z190CCFech", context.localUtil.Format(Z190CCFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z508CCFVcto", context.localUtil.Format(Z508CCFVcto, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z187CCmonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z187CCmonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z513CCImpTotal", StringUtil.LTrim( StringUtil.NToC( Z513CCImpTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z509CCImpPago", StringUtil.LTrim( StringUtil.NToC( Z509CCImpPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z506CCEstado", StringUtil.RTrim( Z506CCEstado));
         GxWebStd.gx_hidden_field( context, "Z189CCCliDsc", StringUtil.RTrim( Z189CCCliDsc));
         GxWebStd.gx_hidden_field( context, "Z186CCVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z186CCVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z507CCFecUltPago", context.localUtil.Format(Z507CCFecUltPago, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z515CCImpTotalSig", StringUtil.LTrim( StringUtil.NToC( Z515CCImpTotalSig, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z510CCImpPagoSig", StringUtil.LTrim( StringUtil.NToC( Z510CCImpPagoSig, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z512CCImpSaldo", StringUtil.LTrim( StringUtil.NToC( Z512CCImpSaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z514CCImpSaldoSig", StringUtil.LTrim( StringUtil.NToC( Z514CCImpSaldoSig, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Ccclicod( )
      {
         /* Using cursor T002K25 */
         pr_default.execute(23, new Object[] {A188CCCliCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCCCliCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ccmoncod( )
      {
         /* Using cursor T002K26 */
         pr_default.execute(24, new Object[] {A187CCmonCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Cobrar Moneda'.", "ForeignKeyNotFound", 1, "CCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCCmonCod_Internalname;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ccvendcod( )
      {
         /* Using cursor T002K27 */
         pr_default.execute(25, new Object[] {A186CCVendCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "CCVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtCCVendCod_Internalname;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A507CCFecUltPago',fld:'CCFECULTPAGO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CCTIPCOD","{handler:'Valid_Cctipcod',iparms:[{av:'A184CCTipCod',fld:'CCTIPCOD',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]");
         setEventMetadata("VALID_CCTIPCOD",",oparms:[{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]}");
         setEventMetadata("VALID_CCDOCNUM","{handler:'Valid_Ccdocnum',iparms:[{av:'A507CCFecUltPago',fld:'CCFECULTPAGO',pic:''},{av:'A184CCTipCod',fld:'CCTIPCOD',pic:''},{av:'A185CCDocNum',fld:'CCDOCNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CCDOCNUM",",oparms:[{av:'A188CCCliCod',fld:'CCCLICOD',pic:''},{av:'A190CCFech',fld:'CCFECH',pic:''},{av:'A508CCFVcto',fld:'CCFVCTO',pic:''},{av:'A187CCmonCod',fld:'CCMONCOD',pic:'ZZZZZ9'},{av:'A513CCImpTotal',fld:'CCIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A509CCImpPago',fld:'CCIMPPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A506CCEstado',fld:'CCESTADO',pic:''},{av:'A189CCCliDsc',fld:'CCCLIDSC',pic:''},{av:'A186CCVendCod',fld:'CCVENDCOD',pic:'ZZZZZ9'},{av:'A507CCFecUltPago',fld:'CCFECULTPAGO',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'},{av:'A515CCImpTotalSig',fld:'CCIMPTOTALSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A510CCImpPagoSig',fld:'CCIMPPAGOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A512CCImpSaldo',fld:'CCIMPSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A514CCImpSaldoSig',fld:'CCIMPSALDOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z184CCTipCod'},{av:'Z185CCDocNum'},{av:'Z188CCCliCod'},{av:'Z190CCFech'},{av:'Z508CCFVcto'},{av:'Z187CCmonCod'},{av:'Z513CCImpTotal'},{av:'Z509CCImpPago'},{av:'Z506CCEstado'},{av:'Z189CCCliDsc'},{av:'Z186CCVendCod'},{av:'Z507CCFecUltPago'},{av:'Z511TipSigno'},{av:'Z515CCImpTotalSig'},{av:'Z510CCImpPagoSig'},{av:'Z512CCImpSaldo'},{av:'Z514CCImpSaldoSig'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CCCLICOD","{handler:'Valid_Ccclicod',iparms:[{av:'A188CCCliCod',fld:'CCCLICOD',pic:''}]");
         setEventMetadata("VALID_CCCLICOD",",oparms:[]}");
         setEventMetadata("VALID_CCFECH","{handler:'Valid_Ccfech',iparms:[]");
         setEventMetadata("VALID_CCFECH",",oparms:[]}");
         setEventMetadata("VALID_CCFVCTO","{handler:'Valid_Ccfvcto',iparms:[]");
         setEventMetadata("VALID_CCFVCTO",",oparms:[]}");
         setEventMetadata("VALID_CCMONCOD","{handler:'Valid_Ccmoncod',iparms:[{av:'A187CCmonCod',fld:'CCMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CCMONCOD",",oparms:[]}");
         setEventMetadata("VALID_CCIMPTOTAL","{handler:'Valid_Ccimptotal',iparms:[]");
         setEventMetadata("VALID_CCIMPTOTAL",",oparms:[]}");
         setEventMetadata("VALID_CCIMPPAGO","{handler:'Valid_Ccimppago',iparms:[]");
         setEventMetadata("VALID_CCIMPPAGO",",oparms:[]}");
         setEventMetadata("VALID_CCVENDCOD","{handler:'Valid_Ccvendcod',iparms:[{av:'A186CCVendCod',fld:'CCVENDCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CCVENDCOD",",oparms:[]}");
         setEventMetadata("VALID_CCIMPSALDO","{handler:'Valid_Ccimpsaldo',iparms:[]");
         setEventMetadata("VALID_CCIMPSALDO",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z184CCTipCod = "";
         Z185CCDocNum = "";
         Z190CCFech = DateTime.MinValue;
         Z508CCFVcto = DateTime.MinValue;
         Z506CCEstado = "";
         Z189CCCliDsc = "";
         Z507CCFecUltPago = DateTime.MinValue;
         Z188CCCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A184CCTipCod = "";
         A188CCCliCod = "";
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
         A185CCDocNum = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A190CCFech = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A508CCFVcto = DateTime.MinValue;
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A506CCEstado = "";
         lblTextblock10_Jsonclick = "";
         A189CCCliDsc = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A507CCFecUltPago = DateTime.MinValue;
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T002K8_A185CCDocNum = new string[] {""} ;
         T002K8_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         T002K8_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         T002K8_A513CCImpTotal = new decimal[1] ;
         T002K8_A509CCImpPago = new decimal[1] ;
         T002K8_A506CCEstado = new string[] {""} ;
         T002K8_A189CCCliDsc = new string[] {""} ;
         T002K8_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         T002K8_A511TipSigno = new short[1] ;
         T002K8_n511TipSigno = new bool[] {false} ;
         T002K8_A184CCTipCod = new string[] {""} ;
         T002K8_A188CCCliCod = new string[] {""} ;
         T002K8_A187CCmonCod = new int[1] ;
         T002K8_A186CCVendCod = new int[1] ;
         T002K4_A511TipSigno = new short[1] ;
         T002K4_n511TipSigno = new bool[] {false} ;
         T002K5_A188CCCliCod = new string[] {""} ;
         T002K6_A187CCmonCod = new int[1] ;
         T002K7_A186CCVendCod = new int[1] ;
         T002K9_A511TipSigno = new short[1] ;
         T002K9_n511TipSigno = new bool[] {false} ;
         T002K10_A188CCCliCod = new string[] {""} ;
         T002K11_A187CCmonCod = new int[1] ;
         T002K12_A186CCVendCod = new int[1] ;
         T002K13_A184CCTipCod = new string[] {""} ;
         T002K13_A185CCDocNum = new string[] {""} ;
         T002K3_A185CCDocNum = new string[] {""} ;
         T002K3_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         T002K3_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         T002K3_A513CCImpTotal = new decimal[1] ;
         T002K3_A509CCImpPago = new decimal[1] ;
         T002K3_A506CCEstado = new string[] {""} ;
         T002K3_A189CCCliDsc = new string[] {""} ;
         T002K3_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         T002K3_A184CCTipCod = new string[] {""} ;
         T002K3_A188CCCliCod = new string[] {""} ;
         T002K3_A187CCmonCod = new int[1] ;
         T002K3_A186CCVendCod = new int[1] ;
         sMode88 = "";
         T002K14_A184CCTipCod = new string[] {""} ;
         T002K14_A185CCDocNum = new string[] {""} ;
         T002K15_A184CCTipCod = new string[] {""} ;
         T002K15_A185CCDocNum = new string[] {""} ;
         T002K2_A185CCDocNum = new string[] {""} ;
         T002K2_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         T002K2_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         T002K2_A513CCImpTotal = new decimal[1] ;
         T002K2_A509CCImpPago = new decimal[1] ;
         T002K2_A506CCEstado = new string[] {""} ;
         T002K2_A189CCCliDsc = new string[] {""} ;
         T002K2_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         T002K2_A184CCTipCod = new string[] {""} ;
         T002K2_A188CCCliCod = new string[] {""} ;
         T002K2_A187CCmonCod = new int[1] ;
         T002K2_A186CCVendCod = new int[1] ;
         T002K19_A511TipSigno = new short[1] ;
         T002K19_n511TipSigno = new bool[] {false} ;
         T002K20_A219PerTip = new string[] {""} ;
         T002K20_A218PerCod = new string[] {""} ;
         T002K20_A220PerTDoc = new string[] {""} ;
         T002K20_A222PerTipCod = new string[] {""} ;
         T002K20_A223PerDocNum = new string[] {""} ;
         T002K21_A204LetCLetCod = new string[] {""} ;
         T002K21_A207LetCItem = new int[1] ;
         T002K22_A166CobTip = new string[] {""} ;
         T002K22_A167CobCod = new string[] {""} ;
         T002K22_A173Item = new int[1] ;
         T002K23_A150CLCheqDCod = new string[] {""} ;
         T002K23_A153CLCheqDItem = new int[1] ;
         T002K24_A184CCTipCod = new string[] {""} ;
         T002K24_A185CCDocNum = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ184CCTipCod = "";
         ZZ185CCDocNum = "";
         ZZ188CCCliCod = "";
         ZZ190CCFech = DateTime.MinValue;
         ZZ508CCFVcto = DateTime.MinValue;
         ZZ506CCEstado = "";
         ZZ189CCCliDsc = "";
         ZZ507CCFecUltPago = DateTime.MinValue;
         T002K25_A188CCCliCod = new string[] {""} ;
         T002K26_A187CCmonCod = new int[1] ;
         T002K27_A186CCVendCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clcuentacobrar__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clcuentacobrar__default(),
            new Object[][] {
                new Object[] {
               T002K2_A185CCDocNum, T002K2_A190CCFech, T002K2_A508CCFVcto, T002K2_A513CCImpTotal, T002K2_A509CCImpPago, T002K2_A506CCEstado, T002K2_A189CCCliDsc, T002K2_A507CCFecUltPago, T002K2_A184CCTipCod, T002K2_A188CCCliCod,
               T002K2_A187CCmonCod, T002K2_A186CCVendCod
               }
               , new Object[] {
               T002K3_A185CCDocNum, T002K3_A190CCFech, T002K3_A508CCFVcto, T002K3_A513CCImpTotal, T002K3_A509CCImpPago, T002K3_A506CCEstado, T002K3_A189CCCliDsc, T002K3_A507CCFecUltPago, T002K3_A184CCTipCod, T002K3_A188CCCliCod,
               T002K3_A187CCmonCod, T002K3_A186CCVendCod
               }
               , new Object[] {
               T002K4_A511TipSigno, T002K4_n511TipSigno
               }
               , new Object[] {
               T002K5_A188CCCliCod
               }
               , new Object[] {
               T002K6_A187CCmonCod
               }
               , new Object[] {
               T002K7_A186CCVendCod
               }
               , new Object[] {
               T002K8_A185CCDocNum, T002K8_A190CCFech, T002K8_A508CCFVcto, T002K8_A513CCImpTotal, T002K8_A509CCImpPago, T002K8_A506CCEstado, T002K8_A189CCCliDsc, T002K8_A507CCFecUltPago, T002K8_A511TipSigno, T002K8_n511TipSigno,
               T002K8_A184CCTipCod, T002K8_A188CCCliCod, T002K8_A187CCmonCod, T002K8_A186CCVendCod
               }
               , new Object[] {
               T002K9_A511TipSigno, T002K9_n511TipSigno
               }
               , new Object[] {
               T002K10_A188CCCliCod
               }
               , new Object[] {
               T002K11_A187CCmonCod
               }
               , new Object[] {
               T002K12_A186CCVendCod
               }
               , new Object[] {
               T002K13_A184CCTipCod, T002K13_A185CCDocNum
               }
               , new Object[] {
               T002K14_A184CCTipCod, T002K14_A185CCDocNum
               }
               , new Object[] {
               T002K15_A184CCTipCod, T002K15_A185CCDocNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002K19_A511TipSigno, T002K19_n511TipSigno
               }
               , new Object[] {
               T002K20_A219PerTip, T002K20_A218PerCod, T002K20_A220PerTDoc, T002K20_A222PerTipCod, T002K20_A223PerDocNum
               }
               , new Object[] {
               T002K21_A204LetCLetCod, T002K21_A207LetCItem
               }
               , new Object[] {
               T002K22_A166CobTip, T002K22_A167CobCod, T002K22_A173Item
               }
               , new Object[] {
               T002K23_A150CLCheqDCod, T002K23_A153CLCheqDItem
               }
               , new Object[] {
               T002K24_A184CCTipCod, T002K24_A185CCDocNum
               }
               , new Object[] {
               T002K25_A188CCCliCod
               }
               , new Object[] {
               T002K26_A187CCmonCod
               }
               , new Object[] {
               T002K27_A186CCVendCod
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
      private short A511TipSigno ;
      private short GX_JID ;
      private short Z511TipSigno ;
      private short RcdFound88 ;
      private short nIsDirty_88 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ511TipSigno ;
      private int Z187CCmonCod ;
      private int Z186CCVendCod ;
      private int A187CCmonCod ;
      private int A186CCVendCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCCTipCod_Enabled ;
      private int edtCCDocNum_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCCCliCod_Enabled ;
      private int edtCCFech_Enabled ;
      private int edtCCFVcto_Enabled ;
      private int edtCCmonCod_Enabled ;
      private int edtCCImpTotal_Enabled ;
      private int edtCCImpPago_Enabled ;
      private int edtCCEstado_Enabled ;
      private int edtCCCliDsc_Enabled ;
      private int edtCCVendCod_Enabled ;
      private int edtCCImpSaldo_Enabled ;
      private int edtCCImpSaldoSig_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ187CCmonCod ;
      private int ZZ186CCVendCod ;
      private decimal Z513CCImpTotal ;
      private decimal Z509CCImpPago ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal A512CCImpSaldo ;
      private decimal A514CCImpSaldoSig ;
      private decimal A515CCImpTotalSig ;
      private decimal A510CCImpPagoSig ;
      private decimal Z515CCImpTotalSig ;
      private decimal Z510CCImpPagoSig ;
      private decimal Z512CCImpSaldo ;
      private decimal Z514CCImpSaldoSig ;
      private decimal ZZ513CCImpTotal ;
      private decimal ZZ509CCImpPago ;
      private decimal ZZ515CCImpTotalSig ;
      private decimal ZZ510CCImpPagoSig ;
      private decimal ZZ512CCImpSaldo ;
      private decimal ZZ514CCImpSaldoSig ;
      private string sPrefix ;
      private string Z184CCTipCod ;
      private string Z185CCDocNum ;
      private string Z506CCEstado ;
      private string Z189CCCliDsc ;
      private string Z188CCCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A184CCTipCod ;
      private string A188CCCliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCCTipCod_Internalname ;
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
      private string edtCCTipCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCCDocNum_Internalname ;
      private string A185CCDocNum ;
      private string edtCCDocNum_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCCCliCod_Internalname ;
      private string edtCCCliCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCCFech_Internalname ;
      private string edtCCFech_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCCFVcto_Internalname ;
      private string edtCCFVcto_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCCmonCod_Internalname ;
      private string edtCCmonCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCCImpTotal_Internalname ;
      private string edtCCImpTotal_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCCImpPago_Internalname ;
      private string edtCCImpPago_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCCEstado_Internalname ;
      private string A506CCEstado ;
      private string edtCCEstado_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCCCliDsc_Internalname ;
      private string A189CCCliDsc ;
      private string edtCCCliDsc_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCCVendCod_Internalname ;
      private string edtCCVendCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtCCImpSaldo_Internalname ;
      private string edtCCImpSaldo_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtCCImpSaldoSig_Internalname ;
      private string edtCCImpSaldoSig_Jsonclick ;
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
      private string sMode88 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ184CCTipCod ;
      private string ZZ185CCDocNum ;
      private string ZZ188CCCliCod ;
      private string ZZ506CCEstado ;
      private string ZZ189CCCliDsc ;
      private DateTime Z190CCFech ;
      private DateTime Z508CCFVcto ;
      private DateTime Z507CCFecUltPago ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime A507CCFecUltPago ;
      private DateTime ZZ190CCFech ;
      private DateTime ZZ508CCFVcto ;
      private DateTime ZZ507CCFecUltPago ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n511TipSigno ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002K8_A185CCDocNum ;
      private DateTime[] T002K8_A190CCFech ;
      private DateTime[] T002K8_A508CCFVcto ;
      private decimal[] T002K8_A513CCImpTotal ;
      private decimal[] T002K8_A509CCImpPago ;
      private string[] T002K8_A506CCEstado ;
      private string[] T002K8_A189CCCliDsc ;
      private DateTime[] T002K8_A507CCFecUltPago ;
      private short[] T002K8_A511TipSigno ;
      private bool[] T002K8_n511TipSigno ;
      private string[] T002K8_A184CCTipCod ;
      private string[] T002K8_A188CCCliCod ;
      private int[] T002K8_A187CCmonCod ;
      private int[] T002K8_A186CCVendCod ;
      private short[] T002K4_A511TipSigno ;
      private bool[] T002K4_n511TipSigno ;
      private string[] T002K5_A188CCCliCod ;
      private int[] T002K6_A187CCmonCod ;
      private int[] T002K7_A186CCVendCod ;
      private short[] T002K9_A511TipSigno ;
      private bool[] T002K9_n511TipSigno ;
      private string[] T002K10_A188CCCliCod ;
      private int[] T002K11_A187CCmonCod ;
      private int[] T002K12_A186CCVendCod ;
      private string[] T002K13_A184CCTipCod ;
      private string[] T002K13_A185CCDocNum ;
      private string[] T002K3_A185CCDocNum ;
      private DateTime[] T002K3_A190CCFech ;
      private DateTime[] T002K3_A508CCFVcto ;
      private decimal[] T002K3_A513CCImpTotal ;
      private decimal[] T002K3_A509CCImpPago ;
      private string[] T002K3_A506CCEstado ;
      private string[] T002K3_A189CCCliDsc ;
      private DateTime[] T002K3_A507CCFecUltPago ;
      private string[] T002K3_A184CCTipCod ;
      private string[] T002K3_A188CCCliCod ;
      private int[] T002K3_A187CCmonCod ;
      private int[] T002K3_A186CCVendCod ;
      private string[] T002K14_A184CCTipCod ;
      private string[] T002K14_A185CCDocNum ;
      private string[] T002K15_A184CCTipCod ;
      private string[] T002K15_A185CCDocNum ;
      private string[] T002K2_A185CCDocNum ;
      private DateTime[] T002K2_A190CCFech ;
      private DateTime[] T002K2_A508CCFVcto ;
      private decimal[] T002K2_A513CCImpTotal ;
      private decimal[] T002K2_A509CCImpPago ;
      private string[] T002K2_A506CCEstado ;
      private string[] T002K2_A189CCCliDsc ;
      private DateTime[] T002K2_A507CCFecUltPago ;
      private string[] T002K2_A184CCTipCod ;
      private string[] T002K2_A188CCCliCod ;
      private int[] T002K2_A187CCmonCod ;
      private int[] T002K2_A186CCVendCod ;
      private short[] T002K19_A511TipSigno ;
      private bool[] T002K19_n511TipSigno ;
      private string[] T002K20_A219PerTip ;
      private string[] T002K20_A218PerCod ;
      private string[] T002K20_A220PerTDoc ;
      private string[] T002K20_A222PerTipCod ;
      private string[] T002K20_A223PerDocNum ;
      private string[] T002K21_A204LetCLetCod ;
      private int[] T002K21_A207LetCItem ;
      private string[] T002K22_A166CobTip ;
      private string[] T002K22_A167CobCod ;
      private int[] T002K22_A173Item ;
      private string[] T002K23_A150CLCheqDCod ;
      private int[] T002K23_A153CLCheqDItem ;
      private string[] T002K24_A184CCTipCod ;
      private string[] T002K24_A185CCDocNum ;
      private string[] T002K25_A188CCCliCod ;
      private int[] T002K26_A187CCmonCod ;
      private int[] T002K27_A186CCVendCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clcuentacobrar__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clcuentacobrar__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002K8;
        prmT002K8 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K4;
        prmT002K4 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0)
        };
        Object[] prmT002K5;
        prmT002K5 = new Object[] {
        new ParDef("@CCCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002K6;
        prmT002K6 = new Object[] {
        new ParDef("@CCmonCod",GXType.Int32,6,0)
        };
        Object[] prmT002K7;
        prmT002K7 = new Object[] {
        new ParDef("@CCVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002K9;
        prmT002K9 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0)
        };
        Object[] prmT002K10;
        prmT002K10 = new Object[] {
        new ParDef("@CCCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002K11;
        prmT002K11 = new Object[] {
        new ParDef("@CCmonCod",GXType.Int32,6,0)
        };
        Object[] prmT002K12;
        prmT002K12 = new Object[] {
        new ParDef("@CCVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002K13;
        prmT002K13 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K3;
        prmT002K3 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K14;
        prmT002K14 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K15;
        prmT002K15 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K2;
        prmT002K2 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K16;
        prmT002K16 = new Object[] {
        new ParDef("@CCDocNum",GXType.NChar,12,0) ,
        new ParDef("@CCFech",GXType.Date,8,0) ,
        new ParDef("@CCFVcto",GXType.Date,8,0) ,
        new ParDef("@CCImpTotal",GXType.Decimal,15,2) ,
        new ParDef("@CCImpPago",GXType.Decimal,15,2) ,
        new ParDef("@CCEstado",GXType.NChar,1,0) ,
        new ParDef("@CCCliDsc",GXType.NChar,100,0) ,
        new ParDef("@CCFecUltPago",GXType.Date,8,0) ,
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCCliCod",GXType.NChar,20,0) ,
        new ParDef("@CCmonCod",GXType.Int32,6,0) ,
        new ParDef("@CCVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002K17;
        prmT002K17 = new Object[] {
        new ParDef("@CCFech",GXType.Date,8,0) ,
        new ParDef("@CCFVcto",GXType.Date,8,0) ,
        new ParDef("@CCImpTotal",GXType.Decimal,15,2) ,
        new ParDef("@CCImpPago",GXType.Decimal,15,2) ,
        new ParDef("@CCEstado",GXType.NChar,1,0) ,
        new ParDef("@CCCliDsc",GXType.NChar,100,0) ,
        new ParDef("@CCFecUltPago",GXType.Date,8,0) ,
        new ParDef("@CCCliCod",GXType.NChar,20,0) ,
        new ParDef("@CCmonCod",GXType.Int32,6,0) ,
        new ParDef("@CCVendCod",GXType.Int32,6,0) ,
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K18;
        prmT002K18 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K20;
        prmT002K20 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K21;
        prmT002K21 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K22;
        prmT002K22 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K23;
        prmT002K23 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0) ,
        new ParDef("@CCDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002K24;
        prmT002K24 = new Object[] {
        };
        Object[] prmT002K19;
        prmT002K19 = new Object[] {
        new ParDef("@CCTipCod",GXType.NChar,3,0)
        };
        Object[] prmT002K25;
        prmT002K25 = new Object[] {
        new ParDef("@CCCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002K26;
        prmT002K26 = new Object[] {
        new ParDef("@CCmonCod",GXType.Int32,6,0)
        };
        Object[] prmT002K27;
        prmT002K27 = new Object[] {
        new ParDef("@CCVendCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002K2", "SELECT [CCDocNum], [CCFech], [CCFVcto], [CCImpTotal], [CCImpPago], [CCEstado], [CCCliDsc], [CCFecUltPago], [CCTipCod] AS CCTipCod, [CCCliCod] AS CCCliCod, [CCmonCod] AS CCmonCod, [CCVendCod] AS CCVendCod FROM [CLCUENTACOBRAR] WITH (UPDLOCK) WHERE [CCTipCod] = @CCTipCod AND [CCDocNum] = @CCDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K3", "SELECT [CCDocNum], [CCFech], [CCFVcto], [CCImpTotal], [CCImpPago], [CCEstado], [CCCliDsc], [CCFecUltPago], [CCTipCod] AS CCTipCod, [CCCliCod] AS CCCliCod, [CCmonCod] AS CCmonCod, [CCVendCod] AS CCVendCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CCTipCod AND [CCDocNum] = @CCDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K4", "SELECT [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @CCTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K5", "SELECT [CliCod] AS CCCliCod FROM [CLCLIENTES] WHERE [CliCod] = @CCCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K6", "SELECT [MonCod] AS CCmonCod FROM [CMONEDAS] WHERE [MonCod] = @CCmonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K7", "SELECT [VenCod] AS CCVendCod FROM [CVENDEDORES] WHERE [VenCod] = @CCVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K8", "SELECT TM1.[CCDocNum], TM1.[CCFech], TM1.[CCFVcto], TM1.[CCImpTotal], TM1.[CCImpPago], TM1.[CCEstado], TM1.[CCCliDsc], TM1.[CCFecUltPago], T2.[TipSigno], TM1.[CCTipCod] AS CCTipCod, TM1.[CCCliCod] AS CCCliCod, TM1.[CCmonCod] AS CCmonCod, TM1.[CCVendCod] AS CCVendCod FROM ([CLCUENTACOBRAR] TM1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = TM1.[CCTipCod]) WHERE TM1.[CCTipCod] = @CCTipCod and TM1.[CCDocNum] = @CCDocNum ORDER BY TM1.[CCTipCod], TM1.[CCDocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K9", "SELECT [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @CCTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K10", "SELECT [CliCod] AS CCCliCod FROM [CLCLIENTES] WHERE [CliCod] = @CCCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K11", "SELECT [MonCod] AS CCmonCod FROM [CMONEDAS] WHERE [MonCod] = @CCmonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K12", "SELECT [VenCod] AS CCVendCod FROM [CVENDEDORES] WHERE [VenCod] = @CCVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K13", "SELECT [CCTipCod] AS CCTipCod, [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CCTipCod AND [CCDocNum] = @CCDocNum  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K14", "SELECT TOP 1 [CCTipCod] AS CCTipCod, [CCDocNum] FROM [CLCUENTACOBRAR] WHERE ( [CCTipCod] > @CCTipCod or [CCTipCod] = @CCTipCod and [CCDocNum] > @CCDocNum) ORDER BY [CCTipCod], [CCDocNum]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K15", "SELECT TOP 1 [CCTipCod] AS CCTipCod, [CCDocNum] FROM [CLCUENTACOBRAR] WHERE ( [CCTipCod] < @CCTipCod or [CCTipCod] = @CCTipCod and [CCDocNum] < @CCDocNum) ORDER BY [CCTipCod] DESC, [CCDocNum] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K16", "INSERT INTO [CLCUENTACOBRAR]([CCDocNum], [CCFech], [CCFVcto], [CCImpTotal], [CCImpPago], [CCEstado], [CCCliDsc], [CCFecUltPago], [CCTipCod], [CCCliCod], [CCmonCod], [CCVendCod]) VALUES(@CCDocNum, @CCFech, @CCFVcto, @CCImpTotal, @CCImpPago, @CCEstado, @CCCliDsc, @CCFecUltPago, @CCTipCod, @CCCliCod, @CCmonCod, @CCVendCod)", GxErrorMask.GX_NOMASK,prmT002K16)
           ,new CursorDef("T002K17", "UPDATE [CLCUENTACOBRAR] SET [CCFech]=@CCFech, [CCFVcto]=@CCFVcto, [CCImpTotal]=@CCImpTotal, [CCImpPago]=@CCImpPago, [CCEstado]=@CCEstado, [CCCliDsc]=@CCCliDsc, [CCFecUltPago]=@CCFecUltPago, [CCCliCod]=@CCCliCod, [CCmonCod]=@CCmonCod, [CCVendCod]=@CCVendCod  WHERE [CCTipCod] = @CCTipCod AND [CCDocNum] = @CCDocNum", GxErrorMask.GX_NOMASK,prmT002K17)
           ,new CursorDef("T002K18", "DELETE FROM [CLCUENTACOBRAR]  WHERE [CCTipCod] = @CCTipCod AND [CCDocNum] = @CCDocNum", GxErrorMask.GX_NOMASK,prmT002K18)
           ,new CursorDef("T002K19", "SELECT [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @CCTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K20", "SELECT TOP 1 [PerTip], [PerCod], [PerTDoc], [PerTipCod], [PerDocNum] FROM [CLPERCEPCIONDET] WHERE [PerTipCod] = @CCTipCod AND [PerDocNum] = @CCDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K21", "SELECT TOP 1 [LetCLetCod], [LetCItem] FROM [CLLETRASDET] WHERE [LetCTipCod] = @CCTipCod AND [LetCDocNum] = @CCDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K22", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [CobTipCod] = @CCTipCod AND [CobDocNum] = @CCDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K23", "SELECT TOP 1 [CLCheqDCod], [CLCheqDItem] FROM [CLCHEQUEDIFERIDODET] WHERE [CLCheqDTipCod] = @CCTipCod AND [CLCheqDDocNum] = @CCDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K24", "SELECT [CCTipCod] AS CCTipCod, [CCDocNum] FROM [CLCUENTACOBRAR] ORDER BY [CCTipCod], [CCDocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K25", "SELECT [CliCod] AS CCCliCod FROM [CLCLIENTES] WHERE [CliCod] = @CCCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K26", "SELECT [MonCod] AS CCmonCod FROM [CMONEDAS] WHERE [MonCod] = @CCmonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K27", "SELECT [VenCod] AS CCVendCod FROM [CVENDEDORES] WHERE [VenCod] = @CCVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K27,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 12);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 12);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 3);
              ((string[]) buf[11])[0] = rslt.getString(11, 20);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
