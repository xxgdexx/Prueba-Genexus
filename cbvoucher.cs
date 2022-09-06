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
   public class cbvoucher : GXDataArea
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
            A126TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A126TASICod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A127VouAno = (short)(NumberUtil.Val( GetPar( "VouAno"), "."));
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = (short)(NumberUtil.Val( GetPar( "VouMes"), "."));
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = GetPar( "VouNum");
            AssignAttri("", false, "A129VouNum", A129VouNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A127VouAno, A128VouMes, A126TASICod, A129VouNum) ;
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
            Form.Meta.addItem("description", "Asientos Contables - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbvoucher( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbvoucher( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBVOUCHER.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Año", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127VouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A127VouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A127VouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Mes", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128VouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A128VouMes), "Z9") : context.localUtil.Format( (decimal)(A128VouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo Asiento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126TASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "N° Asiento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouNum_Internalname, StringUtil.RTrim( A129VouNum), StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVouFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVouFec_Internalname, context.localUtil.Format(A2074VouFec, "99/99/99"), context.localUtil.Format( A2074VouFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHER.htm");
         GxWebStd.gx_bitmap( context, edtVouFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVouFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Glosa", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouGls_Internalname, StringUtil.RTrim( A2075VouGls), StringUtil.RTrim( context.localUtil.Format( A2075VouGls, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouGls_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouGls_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Total Secuencia", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouTSec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2081VouTSec), 6, 0, ".", "")), StringUtil.LTrim( ((edtVouTSec_Enabled!=0) ? context.localUtil.Format( (decimal)(A2081VouTSec), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2081VouTSec), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouTSec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouTSec_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Estatus", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2077VouSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtVouSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2077VouSts), "9") : context.localUtil.Format( (decimal)(A2077VouSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Tipo de Asiento", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHER.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouTip_Internalname, StringUtil.RTrim( A2078VouTip), StringUtil.RTrim( context.localUtil.Format( A2078VouTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHER.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHER.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBVOUCHER.htm");
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
            Z127VouAno = (short)(context.localUtil.CToN( cgiGet( "Z127VouAno"), ".", ","));
            Z128VouMes = (short)(context.localUtil.CToN( cgiGet( "Z128VouMes"), ".", ","));
            Z126TASICod = (int)(context.localUtil.CToN( cgiGet( "Z126TASICod"), ".", ","));
            Z129VouNum = cgiGet( "Z129VouNum");
            Z2074VouFec = context.localUtil.CToD( cgiGet( "Z2074VouFec"), 0);
            Z2075VouGls = cgiGet( "Z2075VouGls");
            Z2081VouTSec = (int)(context.localUtil.CToN( cgiGet( "Z2081VouTSec"), ".", ","));
            Z2077VouSts = (short)(context.localUtil.CToN( cgiGet( "Z2077VouSts"), ".", ","));
            Z2078VouTip = cgiGet( "Z2078VouTip");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A2079VouTotD = context.localUtil.CToN( cgiGet( "VOUTOTD"), ".", ",");
            A2080VouTotH = context.localUtil.CToN( cgiGet( "VOUTOTH"), ".", ",");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUANO");
               AnyError = 1;
               GX_FocusControl = edtVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A127VouAno = 0;
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            }
            else
            {
               A127VouAno = (short)(context.localUtil.CToN( cgiGet( edtVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUMES");
               AnyError = 1;
               GX_FocusControl = edtVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A128VouMes = 0;
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            }
            else
            {
               A128VouMes = (short)(context.localUtil.CToN( cgiGet( edtVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TASICOD");
               AnyError = 1;
               GX_FocusControl = edtTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A126TASICod = 0;
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            }
            else
            {
               A126TASICod = (int)(context.localUtil.CToN( cgiGet( edtTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            }
            A129VouNum = cgiGet( edtVouNum_Internalname);
            AssignAttri("", false, "A129VouNum", A129VouNum);
            if ( context.localUtil.VCDate( cgiGet( edtVouFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "VOUFEC");
               AnyError = 1;
               GX_FocusControl = edtVouFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2074VouFec = DateTime.MinValue;
               AssignAttri("", false, "A2074VouFec", context.localUtil.Format(A2074VouFec, "99/99/99"));
            }
            else
            {
               A2074VouFec = context.localUtil.CToD( cgiGet( edtVouFec_Internalname), 2);
               AssignAttri("", false, "A2074VouFec", context.localUtil.Format(A2074VouFec, "99/99/99"));
            }
            A2075VouGls = cgiGet( edtVouGls_Internalname);
            AssignAttri("", false, "A2075VouGls", A2075VouGls);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouTSec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouTSec_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUTSEC");
               AnyError = 1;
               GX_FocusControl = edtVouTSec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2081VouTSec = 0;
               AssignAttri("", false, "A2081VouTSec", StringUtil.LTrimStr( (decimal)(A2081VouTSec), 6, 0));
            }
            else
            {
               A2081VouTSec = (int)(context.localUtil.CToN( cgiGet( edtVouTSec_Internalname), ".", ","));
               AssignAttri("", false, "A2081VouTSec", StringUtil.LTrimStr( (decimal)(A2081VouTSec), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUSTS");
               AnyError = 1;
               GX_FocusControl = edtVouSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2077VouSts = 0;
               AssignAttri("", false, "A2077VouSts", StringUtil.Str( (decimal)(A2077VouSts), 1, 0));
            }
            else
            {
               A2077VouSts = (short)(context.localUtil.CToN( cgiGet( edtVouSts_Internalname), ".", ","));
               AssignAttri("", false, "A2077VouSts", StringUtil.Str( (decimal)(A2077VouSts), 1, 0));
            }
            A2078VouTip = cgiGet( edtVouTip_Internalname);
            AssignAttri("", false, "A2078VouTip", A2078VouTip);
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
               A127VouAno = (short)(NumberUtil.Val( GetPar( "VouAno"), "."));
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = (short)(NumberUtil.Val( GetPar( "VouMes"), "."));
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = GetPar( "VouNum");
               AssignAttri("", false, "A129VouNum", A129VouNum);
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
               InitAll2372( ) ;
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
         DisableAttributes2372( ) ;
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

      protected void CONFIRM_230( )
      {
         BeforeValidate2372( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2372( ) ;
            }
            else
            {
               CheckExtendedTable2372( ) ;
               if ( AnyError == 0 )
               {
                  ZM2372( 3) ;
                  ZM2372( 4) ;
               }
               CloseExtendedTableCursors2372( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues230( ) ;
         }
      }

      protected void ResetCaption230( )
      {
      }

      protected void ZM2372( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2074VouFec = T00233_A2074VouFec[0];
               Z2075VouGls = T00233_A2075VouGls[0];
               Z2081VouTSec = T00233_A2081VouTSec[0];
               Z2077VouSts = T00233_A2077VouSts[0];
               Z2078VouTip = T00233_A2078VouTip[0];
            }
            else
            {
               Z2074VouFec = A2074VouFec;
               Z2075VouGls = A2075VouGls;
               Z2081VouTSec = A2081VouTSec;
               Z2077VouSts = A2077VouSts;
               Z2078VouTip = A2078VouTip;
            }
         }
         if ( GX_JID == -2 )
         {
            Z127VouAno = A127VouAno;
            Z128VouMes = A128VouMes;
            Z129VouNum = A129VouNum;
            Z2074VouFec = A2074VouFec;
            Z2075VouGls = A2075VouGls;
            Z2081VouTSec = A2081VouTSec;
            Z2077VouSts = A2077VouSts;
            Z2078VouTip = A2078VouTip;
            Z126TASICod = A126TASICod;
            Z2079VouTotD = A2079VouTotD;
            Z2080VouTotH = A2080VouTotH;
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

      protected void Load2372( )
      {
         /* Using cursor T00238 */
         pr_default.execute(4, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound72 = 1;
            A2074VouFec = T00238_A2074VouFec[0];
            AssignAttri("", false, "A2074VouFec", context.localUtil.Format(A2074VouFec, "99/99/99"));
            A2075VouGls = T00238_A2075VouGls[0];
            AssignAttri("", false, "A2075VouGls", A2075VouGls);
            A2081VouTSec = T00238_A2081VouTSec[0];
            AssignAttri("", false, "A2081VouTSec", StringUtil.LTrimStr( (decimal)(A2081VouTSec), 6, 0));
            A2077VouSts = T00238_A2077VouSts[0];
            AssignAttri("", false, "A2077VouSts", StringUtil.Str( (decimal)(A2077VouSts), 1, 0));
            A2078VouTip = T00238_A2078VouTip[0];
            AssignAttri("", false, "A2078VouTip", A2078VouTip);
            A2079VouTotD = T00238_A2079VouTotD[0];
            A2080VouTotH = T00238_A2080VouTotH[0];
            ZM2372( -2) ;
         }
         pr_default.close(4);
         OnLoadActions2372( ) ;
      }

      protected void OnLoadActions2372( )
      {
      }

      protected void CheckExtendedTable2372( )
      {
         nIsDirty_72 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00234 */
         pr_default.execute(2, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Asiento'.", "ForeignKeyNotFound", 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00236 */
         pr_default.execute(3, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A2079VouTotD = T00236_A2079VouTotD[0];
            A2080VouTotH = T00236_A2080VouTotH[0];
         }
         else
         {
            nIsDirty_72 = 1;
            A2079VouTotD = 0;
            AssignAttri("", false, "A2079VouTotD", StringUtil.LTrimStr( A2079VouTotD, 15, 2));
            nIsDirty_72 = 1;
            A2080VouTotH = 0;
            AssignAttri("", false, "A2080VouTotH", StringUtil.LTrimStr( A2080VouTotH, 15, 2));
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A2074VouFec) || ( DateTimeUtil.ResetTime ( A2074VouFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "VOUFEC");
            AnyError = 1;
            GX_FocusControl = edtVouFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2372( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A126TASICod )
      {
         /* Using cursor T00239 */
         pr_default.execute(5, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Asiento'.", "ForeignKeyNotFound", 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
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

      protected void gxLoad_4( short A127VouAno ,
                               short A128VouMes ,
                               int A126TASICod ,
                               string A129VouNum )
      {
         /* Using cursor T002311 */
         pr_default.execute(6, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A2079VouTotD = T002311_A2079VouTotD[0];
            A2080VouTotH = T002311_A2080VouTotH[0];
         }
         else
         {
            A2079VouTotD = 0;
            AssignAttri("", false, "A2079VouTotD", StringUtil.LTrimStr( A2079VouTotD, 15, 2));
            A2080VouTotH = 0;
            AssignAttri("", false, "A2080VouTotH", StringUtil.LTrimStr( A2080VouTotH, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A2079VouTotD, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A2080VouTotH, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2372( )
      {
         /* Using cursor T002312 */
         pr_default.execute(7, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00233 */
         pr_default.execute(1, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2372( 2) ;
            RcdFound72 = 1;
            A127VouAno = T00233_A127VouAno[0];
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = T00233_A128VouMes[0];
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A129VouNum = T00233_A129VouNum[0];
            AssignAttri("", false, "A129VouNum", A129VouNum);
            A2074VouFec = T00233_A2074VouFec[0];
            AssignAttri("", false, "A2074VouFec", context.localUtil.Format(A2074VouFec, "99/99/99"));
            A2075VouGls = T00233_A2075VouGls[0];
            AssignAttri("", false, "A2075VouGls", A2075VouGls);
            A2081VouTSec = T00233_A2081VouTSec[0];
            AssignAttri("", false, "A2081VouTSec", StringUtil.LTrimStr( (decimal)(A2081VouTSec), 6, 0));
            A2077VouSts = T00233_A2077VouSts[0];
            AssignAttri("", false, "A2077VouSts", StringUtil.Str( (decimal)(A2077VouSts), 1, 0));
            A2078VouTip = T00233_A2078VouTip[0];
            AssignAttri("", false, "A2078VouTip", A2078VouTip);
            A126TASICod = T00233_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            Z127VouAno = A127VouAno;
            Z128VouMes = A128VouMes;
            Z126TASICod = A126TASICod;
            Z129VouNum = A129VouNum;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2372( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey2372( ) ;
            }
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey2372( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode72;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2372( ) ;
         if ( RcdFound72 == 0 )
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
         RcdFound72 = 0;
         /* Using cursor T002313 */
         pr_default.execute(8, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002313_A127VouAno[0] < A127VouAno ) || ( T002313_A127VouAno[0] == A127VouAno ) && ( T002313_A128VouMes[0] < A128VouMes ) || ( T002313_A128VouMes[0] == A128VouMes ) && ( T002313_A127VouAno[0] == A127VouAno ) && ( T002313_A126TASICod[0] < A126TASICod ) || ( T002313_A126TASICod[0] == A126TASICod ) && ( T002313_A128VouMes[0] == A128VouMes ) && ( T002313_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002313_A129VouNum[0], A129VouNum) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002313_A127VouAno[0] > A127VouAno ) || ( T002313_A127VouAno[0] == A127VouAno ) && ( T002313_A128VouMes[0] > A128VouMes ) || ( T002313_A128VouMes[0] == A128VouMes ) && ( T002313_A127VouAno[0] == A127VouAno ) && ( T002313_A126TASICod[0] > A126TASICod ) || ( T002313_A126TASICod[0] == A126TASICod ) && ( T002313_A128VouMes[0] == A128VouMes ) && ( T002313_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002313_A129VouNum[0], A129VouNum) > 0 ) ) )
            {
               A127VouAno = T002313_A127VouAno[0];
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = T002313_A128VouMes[0];
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = T002313_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = T002313_A129VouNum[0];
               AssignAttri("", false, "A129VouNum", A129VouNum);
               RcdFound72 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound72 = 0;
         /* Using cursor T002314 */
         pr_default.execute(9, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002314_A127VouAno[0] > A127VouAno ) || ( T002314_A127VouAno[0] == A127VouAno ) && ( T002314_A128VouMes[0] > A128VouMes ) || ( T002314_A128VouMes[0] == A128VouMes ) && ( T002314_A127VouAno[0] == A127VouAno ) && ( T002314_A126TASICod[0] > A126TASICod ) || ( T002314_A126TASICod[0] == A126TASICod ) && ( T002314_A128VouMes[0] == A128VouMes ) && ( T002314_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002314_A129VouNum[0], A129VouNum) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002314_A127VouAno[0] < A127VouAno ) || ( T002314_A127VouAno[0] == A127VouAno ) && ( T002314_A128VouMes[0] < A128VouMes ) || ( T002314_A128VouMes[0] == A128VouMes ) && ( T002314_A127VouAno[0] == A127VouAno ) && ( T002314_A126TASICod[0] < A126TASICod ) || ( T002314_A126TASICod[0] == A126TASICod ) && ( T002314_A128VouMes[0] == A128VouMes ) && ( T002314_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002314_A129VouNum[0], A129VouNum) < 0 ) ) )
            {
               A127VouAno = T002314_A127VouAno[0];
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = T002314_A128VouMes[0];
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = T002314_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = T002314_A129VouNum[0];
               AssignAttri("", false, "A129VouNum", A129VouNum);
               RcdFound72 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2372( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2372( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) )
               {
                  A127VouAno = Z127VouAno;
                  AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
                  A128VouMes = Z128VouMes;
                  AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
                  A126TASICod = Z126TASICod;
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
                  A129VouNum = Z129VouNum;
                  AssignAttri("", false, "A129VouNum", A129VouNum);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VOUANO");
                  AnyError = 1;
                  GX_FocusControl = edtVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2372( ) ;
                  GX_FocusControl = edtVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2372( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VOUANO");
                     AnyError = 1;
                     GX_FocusControl = edtVouAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtVouAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2372( ) ;
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
         if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) )
         {
            A127VouAno = Z127VouAno;
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = Z128VouMes;
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = Z126TASICod;
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = Z129VouNum;
            AssignAttri("", false, "A129VouNum", A129VouNum);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VOUANO");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVouAno_Internalname;
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
         GetKey2372( ) ;
         if ( RcdFound72 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "VOUANO");
               AnyError = 1;
               GX_FocusControl = edtVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) )
            {
               A127VouAno = Z127VouAno;
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = Z128VouMes;
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = Z126TASICod;
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = Z129VouNum;
               AssignAttri("", false, "A129VouNum", A129VouNum);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "VOUANO");
               AnyError = 1;
               GX_FocusControl = edtVouAno_Internalname;
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
            if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VOUANO");
                  AnyError = 1;
                  GX_FocusControl = edtVouAno_Internalname;
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
         context.RollbackDataStores("cbvoucher",pr_default);
         GX_FocusControl = edtVouFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_230( ) ;
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
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VOUANO");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtVouFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2372( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVouFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2372( ) ;
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
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVouFec_Internalname;
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
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVouFec_Internalname;
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
         ScanStart2372( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound72 != 0 )
            {
               ScanNext2372( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtVouFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2372( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2372( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00232 */
            pr_default.execute(0, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBVOUCHER"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2074VouFec ) != DateTimeUtil.ResetTime ( T00232_A2074VouFec[0] ) ) || ( StringUtil.StrCmp(Z2075VouGls, T00232_A2075VouGls[0]) != 0 ) || ( Z2081VouTSec != T00232_A2081VouTSec[0] ) || ( Z2077VouSts != T00232_A2077VouSts[0] ) || ( StringUtil.StrCmp(Z2078VouTip, T00232_A2078VouTip[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2074VouFec ) != DateTimeUtil.ResetTime ( T00232_A2074VouFec[0] ) )
               {
                  GXUtil.WriteLog("cbvoucher:[seudo value changed for attri]"+"VouFec");
                  GXUtil.WriteLogRaw("Old: ",Z2074VouFec);
                  GXUtil.WriteLogRaw("Current: ",T00232_A2074VouFec[0]);
               }
               if ( StringUtil.StrCmp(Z2075VouGls, T00232_A2075VouGls[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucher:[seudo value changed for attri]"+"VouGls");
                  GXUtil.WriteLogRaw("Old: ",Z2075VouGls);
                  GXUtil.WriteLogRaw("Current: ",T00232_A2075VouGls[0]);
               }
               if ( Z2081VouTSec != T00232_A2081VouTSec[0] )
               {
                  GXUtil.WriteLog("cbvoucher:[seudo value changed for attri]"+"VouTSec");
                  GXUtil.WriteLogRaw("Old: ",Z2081VouTSec);
                  GXUtil.WriteLogRaw("Current: ",T00232_A2081VouTSec[0]);
               }
               if ( Z2077VouSts != T00232_A2077VouSts[0] )
               {
                  GXUtil.WriteLog("cbvoucher:[seudo value changed for attri]"+"VouSts");
                  GXUtil.WriteLogRaw("Old: ",Z2077VouSts);
                  GXUtil.WriteLogRaw("Current: ",T00232_A2077VouSts[0]);
               }
               if ( StringUtil.StrCmp(Z2078VouTip, T00232_A2078VouTip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucher:[seudo value changed for attri]"+"VouTip");
                  GXUtil.WriteLogRaw("Old: ",Z2078VouTip);
                  GXUtil.WriteLogRaw("Current: ",T00232_A2078VouTip[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBVOUCHER"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2372( )
      {
         BeforeValidate2372( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2372( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2372( 0) ;
            CheckOptimisticConcurrency2372( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2372( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2372( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002315 */
                     pr_default.execute(10, new Object[] {A127VouAno, A128VouMes, A129VouNum, A2074VouFec, A2075VouGls, A2081VouTSec, A2077VouSts, A2078VouTip, A126TASICod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBVOUCHER");
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
                           ResetCaption230( ) ;
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
               Load2372( ) ;
            }
            EndLevel2372( ) ;
         }
         CloseExtendedTableCursors2372( ) ;
      }

      protected void Update2372( )
      {
         BeforeValidate2372( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2372( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2372( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2372( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2372( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002316 */
                     pr_default.execute(11, new Object[] {A2074VouFec, A2075VouGls, A2081VouTSec, A2077VouSts, A2078VouTip, A127VouAno, A128VouMes, A126TASICod, A129VouNum});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBVOUCHER");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBVOUCHER"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2372( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption230( ) ;
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
            EndLevel2372( ) ;
         }
         CloseExtendedTableCursors2372( ) ;
      }

      protected void DeferredUpdate2372( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2372( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2372( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2372( ) ;
            AfterConfirm2372( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2372( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002317 */
                  pr_default.execute(12, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CBVOUCHER");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound72 == 0 )
                        {
                           InitAll2372( ) ;
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
                        ResetCaption230( ) ;
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2372( ) ;
         Gx_mode = sMode72;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2372( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002319 */
            pr_default.execute(13, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A2079VouTotD = T002319_A2079VouTotD[0];
               A2080VouTotH = T002319_A2080VouTotH[0];
            }
            else
            {
               A2079VouTotD = 0;
               AssignAttri("", false, "A2079VouTotD", StringUtil.LTrimStr( A2079VouTotD, 15, 2));
               A2080VouTotH = 0;
               AssignAttri("", false, "A2080VouTotH", StringUtil.LTrimStr( A2080VouTotH, 15, 2));
            }
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002320 */
            pr_default.execute(14, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel2372( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2372( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("cbvoucher",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues230( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("cbvoucher",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2372( )
      {
         /* Using cursor T002321 */
         pr_default.execute(15);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound72 = 1;
            A127VouAno = T002321_A127VouAno[0];
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = T002321_A128VouMes[0];
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = T002321_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = T002321_A129VouNum[0];
            AssignAttri("", false, "A129VouNum", A129VouNum);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2372( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound72 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound72 = 1;
            A127VouAno = T002321_A127VouAno[0];
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = T002321_A128VouMes[0];
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = T002321_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = T002321_A129VouNum[0];
            AssignAttri("", false, "A129VouNum", A129VouNum);
         }
      }

      protected void ScanEnd2372( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2372( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2372( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2372( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2372( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2372( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2372( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2372( )
      {
         edtVouAno_Enabled = 0;
         AssignProp("", false, edtVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouAno_Enabled), 5, 0), true);
         edtVouMes_Enabled = 0;
         AssignProp("", false, edtVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouMes_Enabled), 5, 0), true);
         edtTASICod_Enabled = 0;
         AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
         edtVouNum_Enabled = 0;
         AssignProp("", false, edtVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouNum_Enabled), 5, 0), true);
         edtVouFec_Enabled = 0;
         AssignProp("", false, edtVouFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouFec_Enabled), 5, 0), true);
         edtVouGls_Enabled = 0;
         AssignProp("", false, edtVouGls_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouGls_Enabled), 5, 0), true);
         edtVouTSec_Enabled = 0;
         AssignProp("", false, edtVouTSec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouTSec_Enabled), 5, 0), true);
         edtVouSts_Enabled = 0;
         AssignProp("", false, edtVouSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouSts_Enabled), 5, 0), true);
         edtVouTip_Enabled = 0;
         AssignProp("", false, edtVouTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouTip_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2372( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues230( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816423485", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbvoucher.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z127VouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127VouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z128VouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128VouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z126TASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z129VouNum", StringUtil.RTrim( Z129VouNum));
         GxWebStd.gx_hidden_field( context, "Z2074VouFec", context.localUtil.DToC( Z2074VouFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2075VouGls", StringUtil.RTrim( Z2075VouGls));
         GxWebStd.gx_hidden_field( context, "Z2081VouTSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2081VouTSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2077VouSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2077VouSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2078VouTip", StringUtil.RTrim( Z2078VouTip));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "VOUTOTD", StringUtil.LTrim( StringUtil.NToC( A2079VouTotD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "VOUTOTH", StringUtil.LTrim( StringUtil.NToC( A2080VouTotH, 15, 2, ".", "")));
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
         return formatLink("cbvoucher.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBVOUCHER" ;
      }

      public override string GetPgmdesc( )
      {
         return "Asientos Contables - Cabecera" ;
      }

      protected void InitializeNonKey2372( )
      {
         A2074VouFec = DateTime.MinValue;
         AssignAttri("", false, "A2074VouFec", context.localUtil.Format(A2074VouFec, "99/99/99"));
         A2075VouGls = "";
         AssignAttri("", false, "A2075VouGls", A2075VouGls);
         A2081VouTSec = 0;
         AssignAttri("", false, "A2081VouTSec", StringUtil.LTrimStr( (decimal)(A2081VouTSec), 6, 0));
         A2077VouSts = 0;
         AssignAttri("", false, "A2077VouSts", StringUtil.Str( (decimal)(A2077VouSts), 1, 0));
         A2078VouTip = "";
         AssignAttri("", false, "A2078VouTip", A2078VouTip);
         A2079VouTotD = 0;
         AssignAttri("", false, "A2079VouTotD", StringUtil.LTrimStr( A2079VouTotD, 15, 2));
         A2080VouTotH = 0;
         AssignAttri("", false, "A2080VouTotH", StringUtil.LTrimStr( A2080VouTotH, 15, 2));
         Z2074VouFec = DateTime.MinValue;
         Z2075VouGls = "";
         Z2081VouTSec = 0;
         Z2077VouSts = 0;
         Z2078VouTip = "";
      }

      protected void InitAll2372( )
      {
         A127VouAno = 0;
         AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
         A128VouMes = 0;
         AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
         A126TASICod = 0;
         AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         A129VouNum = "";
         AssignAttri("", false, "A129VouNum", A129VouNum);
         InitializeNonKey2372( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816423497", true, true);
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
         context.AddJavascriptSource("cbvoucher.js", "?202281816423498", false, true);
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
         edtVouAno_Internalname = "VOUANO";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtVouMes_Internalname = "VOUMES";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTASICod_Internalname = "TASICOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtVouNum_Internalname = "VOUNUM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtVouFec_Internalname = "VOUFEC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtVouGls_Internalname = "VOUGLS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtVouTSec_Internalname = "VOUTSEC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtVouSts_Internalname = "VOUSTS";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtVouTip_Internalname = "VOUTIP";
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
         Form.Caption = "Asientos Contables - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVouTip_Jsonclick = "";
         edtVouTip_Enabled = 1;
         edtVouSts_Jsonclick = "";
         edtVouSts_Enabled = 1;
         edtVouTSec_Jsonclick = "";
         edtVouTSec_Enabled = 1;
         edtVouGls_Jsonclick = "";
         edtVouGls_Enabled = 1;
         edtVouFec_Jsonclick = "";
         edtVouFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtVouNum_Jsonclick = "";
         edtVouNum_Enabled = 1;
         edtTASICod_Jsonclick = "";
         edtTASICod_Enabled = 1;
         edtVouMes_Jsonclick = "";
         edtVouMes_Enabled = 1;
         edtVouAno_Jsonclick = "";
         edtVouAno_Enabled = 1;
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
         /* Using cursor T002322 */
         pr_default.execute(16, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Asiento'.", "ForeignKeyNotFound", 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         /* Using cursor T002319 */
         pr_default.execute(13, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A2079VouTotD = T002319_A2079VouTotD[0];
            A2080VouTotH = T002319_A2080VouTotH[0];
         }
         else
         {
            A2079VouTotD = 0;
            AssignAttri("", false, "A2079VouTotD", StringUtil.LTrimStr( A2079VouTotD, 15, 2));
            A2080VouTotH = 0;
            AssignAttri("", false, "A2080VouTotH", StringUtil.LTrimStr( A2080VouTotH, 15, 2));
         }
         pr_default.close(13);
         GX_FocusControl = edtVouFec_Internalname;
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

      public void Valid_Tasicod( )
      {
         /* Using cursor T002322 */
         pr_default.execute(16, new Object[] {A126TASICod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Asiento'.", "ForeignKeyNotFound", 1, "TASICOD");
            AnyError = 1;
            GX_FocusControl = edtTASICod_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Vounum( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002319 */
         pr_default.execute(13, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A2079VouTotD = T002319_A2079VouTotD[0];
            A2080VouTotH = T002319_A2080VouTotH[0];
         }
         else
         {
            A2079VouTotD = 0;
            A2080VouTotH = 0;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2074VouFec", context.localUtil.Format(A2074VouFec, "99/99/99"));
         AssignAttri("", false, "A2075VouGls", StringUtil.RTrim( A2075VouGls));
         AssignAttri("", false, "A2081VouTSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2081VouTSec), 6, 0, ".", "")));
         AssignAttri("", false, "A2077VouSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2077VouSts), 1, 0, ".", "")));
         AssignAttri("", false, "A2078VouTip", StringUtil.RTrim( A2078VouTip));
         AssignAttri("", false, "A2079VouTotD", StringUtil.LTrim( StringUtil.NToC( A2079VouTotD, 15, 2, ".", "")));
         AssignAttri("", false, "A2080VouTotH", StringUtil.LTrim( StringUtil.NToC( A2080VouTotH, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z127VouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127VouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z128VouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128VouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z126TASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z129VouNum", StringUtil.RTrim( Z129VouNum));
         GxWebStd.gx_hidden_field( context, "Z2074VouFec", context.localUtil.Format(Z2074VouFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2075VouGls", StringUtil.RTrim( Z2075VouGls));
         GxWebStd.gx_hidden_field( context, "Z2081VouTSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2081VouTSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2077VouSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2077VouSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2078VouTip", StringUtil.RTrim( Z2078VouTip));
         GxWebStd.gx_hidden_field( context, "Z2079VouTotD", StringUtil.LTrim( StringUtil.NToC( Z2079VouTotD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2080VouTotH", StringUtil.LTrim( StringUtil.NToC( Z2080VouTotH, 15, 2, ".", "")));
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
         setEventMetadata("VALID_VOUANO","{handler:'Valid_Vouano',iparms:[]");
         setEventMetadata("VALID_VOUANO",",oparms:[]}");
         setEventMetadata("VALID_VOUMES","{handler:'Valid_Voumes',iparms:[]");
         setEventMetadata("VALID_VOUMES",",oparms:[]}");
         setEventMetadata("VALID_TASICOD","{handler:'Valid_Tasicod',iparms:[{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TASICOD",",oparms:[]}");
         setEventMetadata("VALID_VOUNUM","{handler:'Valid_Vounum',iparms:[{av:'A127VouAno',fld:'VOUANO',pic:'ZZZ9'},{av:'A128VouMes',fld:'VOUMES',pic:'Z9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A129VouNum',fld:'VOUNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_VOUNUM",",oparms:[{av:'A2074VouFec',fld:'VOUFEC',pic:''},{av:'A2075VouGls',fld:'VOUGLS',pic:''},{av:'A2081VouTSec',fld:'VOUTSEC',pic:'ZZZZZ9'},{av:'A2077VouSts',fld:'VOUSTS',pic:'9'},{av:'A2078VouTip',fld:'VOUTIP',pic:''},{av:'A2079VouTotD',fld:'VOUTOTD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2080VouTotH',fld:'VOUTOTH',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z127VouAno'},{av:'Z128VouMes'},{av:'Z126TASICod'},{av:'Z129VouNum'},{av:'Z2074VouFec'},{av:'Z2075VouGls'},{av:'Z2081VouTSec'},{av:'Z2077VouSts'},{av:'Z2078VouTip'},{av:'Z2079VouTotD'},{av:'Z2080VouTotH'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_VOUFEC","{handler:'Valid_Voufec',iparms:[]");
         setEventMetadata("VALID_VOUFEC",",oparms:[]}");
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
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z129VouNum = "";
         Z2074VouFec = DateTime.MinValue;
         Z2075VouGls = "";
         Z2078VouTip = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A129VouNum = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A2074VouFec = DateTime.MinValue;
         lblTextblock6_Jsonclick = "";
         A2075VouGls = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A2078VouTip = "";
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
         T00238_A127VouAno = new short[1] ;
         T00238_A128VouMes = new short[1] ;
         T00238_A129VouNum = new string[] {""} ;
         T00238_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         T00238_A2075VouGls = new string[] {""} ;
         T00238_A2081VouTSec = new int[1] ;
         T00238_A2077VouSts = new short[1] ;
         T00238_A2078VouTip = new string[] {""} ;
         T00238_A126TASICod = new int[1] ;
         T00238_A2079VouTotD = new decimal[1] ;
         T00238_A2080VouTotH = new decimal[1] ;
         T00234_A126TASICod = new int[1] ;
         T00236_A2079VouTotD = new decimal[1] ;
         T00236_A2080VouTotH = new decimal[1] ;
         T00239_A126TASICod = new int[1] ;
         T002311_A2079VouTotD = new decimal[1] ;
         T002311_A2080VouTotH = new decimal[1] ;
         T002312_A127VouAno = new short[1] ;
         T002312_A128VouMes = new short[1] ;
         T002312_A126TASICod = new int[1] ;
         T002312_A129VouNum = new string[] {""} ;
         T00233_A127VouAno = new short[1] ;
         T00233_A128VouMes = new short[1] ;
         T00233_A129VouNum = new string[] {""} ;
         T00233_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         T00233_A2075VouGls = new string[] {""} ;
         T00233_A2081VouTSec = new int[1] ;
         T00233_A2077VouSts = new short[1] ;
         T00233_A2078VouTip = new string[] {""} ;
         T00233_A126TASICod = new int[1] ;
         sMode72 = "";
         T002313_A127VouAno = new short[1] ;
         T002313_A128VouMes = new short[1] ;
         T002313_A126TASICod = new int[1] ;
         T002313_A129VouNum = new string[] {""} ;
         T002314_A127VouAno = new short[1] ;
         T002314_A128VouMes = new short[1] ;
         T002314_A126TASICod = new int[1] ;
         T002314_A129VouNum = new string[] {""} ;
         T00232_A127VouAno = new short[1] ;
         T00232_A128VouMes = new short[1] ;
         T00232_A129VouNum = new string[] {""} ;
         T00232_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         T00232_A2075VouGls = new string[] {""} ;
         T00232_A2081VouTSec = new int[1] ;
         T00232_A2077VouSts = new short[1] ;
         T00232_A2078VouTip = new string[] {""} ;
         T00232_A126TASICod = new int[1] ;
         T002319_A2079VouTotD = new decimal[1] ;
         T002319_A2080VouTotH = new decimal[1] ;
         T002320_A127VouAno = new short[1] ;
         T002320_A128VouMes = new short[1] ;
         T002320_A126TASICod = new int[1] ;
         T002320_A129VouNum = new string[] {""} ;
         T002320_A130VouDSec = new int[1] ;
         T002321_A127VouAno = new short[1] ;
         T002321_A128VouMes = new short[1] ;
         T002321_A126TASICod = new int[1] ;
         T002321_A129VouNum = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002322_A126TASICod = new int[1] ;
         ZZ129VouNum = "";
         ZZ2074VouFec = DateTime.MinValue;
         ZZ2075VouGls = "";
         ZZ2078VouTip = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbvoucher__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbvoucher__default(),
            new Object[][] {
                new Object[] {
               T00232_A127VouAno, T00232_A128VouMes, T00232_A129VouNum, T00232_A2074VouFec, T00232_A2075VouGls, T00232_A2081VouTSec, T00232_A2077VouSts, T00232_A2078VouTip, T00232_A126TASICod
               }
               , new Object[] {
               T00233_A127VouAno, T00233_A128VouMes, T00233_A129VouNum, T00233_A2074VouFec, T00233_A2075VouGls, T00233_A2081VouTSec, T00233_A2077VouSts, T00233_A2078VouTip, T00233_A126TASICod
               }
               , new Object[] {
               T00234_A126TASICod
               }
               , new Object[] {
               T00236_A2079VouTotD, T00236_A2080VouTotH
               }
               , new Object[] {
               T00238_A127VouAno, T00238_A128VouMes, T00238_A129VouNum, T00238_A2074VouFec, T00238_A2075VouGls, T00238_A2081VouTSec, T00238_A2077VouSts, T00238_A2078VouTip, T00238_A126TASICod, T00238_A2079VouTotD,
               T00238_A2080VouTotH
               }
               , new Object[] {
               T00239_A126TASICod
               }
               , new Object[] {
               T002311_A2079VouTotD, T002311_A2080VouTotH
               }
               , new Object[] {
               T002312_A127VouAno, T002312_A128VouMes, T002312_A126TASICod, T002312_A129VouNum
               }
               , new Object[] {
               T002313_A127VouAno, T002313_A128VouMes, T002313_A126TASICod, T002313_A129VouNum
               }
               , new Object[] {
               T002314_A127VouAno, T002314_A128VouMes, T002314_A126TASICod, T002314_A129VouNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002319_A2079VouTotD, T002319_A2080VouTotH
               }
               , new Object[] {
               T002320_A127VouAno, T002320_A128VouMes, T002320_A126TASICod, T002320_A129VouNum, T002320_A130VouDSec
               }
               , new Object[] {
               T002321_A127VouAno, T002321_A128VouMes, T002321_A126TASICod, T002321_A129VouNum
               }
               , new Object[] {
               T002322_A126TASICod
               }
            }
         );
      }

      private short Z127VouAno ;
      private short Z128VouMes ;
      private short Z2077VouSts ;
      private short GxWebError ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2077VouSts ;
      private short GX_JID ;
      private short RcdFound72 ;
      private short nIsDirty_72 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ127VouAno ;
      private short ZZ128VouMes ;
      private short ZZ2077VouSts ;
      private int Z126TASICod ;
      private int Z2081VouTSec ;
      private int A126TASICod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtVouAno_Enabled ;
      private int edtVouMes_Enabled ;
      private int edtTASICod_Enabled ;
      private int edtVouNum_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtVouFec_Enabled ;
      private int edtVouGls_Enabled ;
      private int A2081VouTSec ;
      private int edtVouTSec_Enabled ;
      private int edtVouSts_Enabled ;
      private int edtVouTip_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ126TASICod ;
      private int ZZ2081VouTSec ;
      private decimal A2079VouTotD ;
      private decimal A2080VouTotH ;
      private decimal Z2079VouTotD ;
      private decimal Z2080VouTotH ;
      private decimal ZZ2079VouTotD ;
      private decimal ZZ2080VouTotH ;
      private string sPrefix ;
      private string Z129VouNum ;
      private string Z2075VouGls ;
      private string Z2078VouTip ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A129VouNum ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVouAno_Internalname ;
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
      private string edtVouAno_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtVouMes_Internalname ;
      private string edtVouMes_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTASICod_Internalname ;
      private string edtTASICod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtVouNum_Internalname ;
      private string edtVouNum_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtVouFec_Internalname ;
      private string edtVouFec_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtVouGls_Internalname ;
      private string A2075VouGls ;
      private string edtVouGls_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtVouTSec_Internalname ;
      private string edtVouTSec_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtVouSts_Internalname ;
      private string edtVouSts_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtVouTip_Internalname ;
      private string A2078VouTip ;
      private string edtVouTip_Jsonclick ;
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
      private string sMode72 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ129VouNum ;
      private string ZZ2075VouGls ;
      private string ZZ2078VouTip ;
      private DateTime Z2074VouFec ;
      private DateTime A2074VouFec ;
      private DateTime ZZ2074VouFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00238_A127VouAno ;
      private short[] T00238_A128VouMes ;
      private string[] T00238_A129VouNum ;
      private DateTime[] T00238_A2074VouFec ;
      private string[] T00238_A2075VouGls ;
      private int[] T00238_A2081VouTSec ;
      private short[] T00238_A2077VouSts ;
      private string[] T00238_A2078VouTip ;
      private int[] T00238_A126TASICod ;
      private decimal[] T00238_A2079VouTotD ;
      private decimal[] T00238_A2080VouTotH ;
      private int[] T00234_A126TASICod ;
      private decimal[] T00236_A2079VouTotD ;
      private decimal[] T00236_A2080VouTotH ;
      private int[] T00239_A126TASICod ;
      private decimal[] T002311_A2079VouTotD ;
      private decimal[] T002311_A2080VouTotH ;
      private short[] T002312_A127VouAno ;
      private short[] T002312_A128VouMes ;
      private int[] T002312_A126TASICod ;
      private string[] T002312_A129VouNum ;
      private short[] T00233_A127VouAno ;
      private short[] T00233_A128VouMes ;
      private string[] T00233_A129VouNum ;
      private DateTime[] T00233_A2074VouFec ;
      private string[] T00233_A2075VouGls ;
      private int[] T00233_A2081VouTSec ;
      private short[] T00233_A2077VouSts ;
      private string[] T00233_A2078VouTip ;
      private int[] T00233_A126TASICod ;
      private short[] T002313_A127VouAno ;
      private short[] T002313_A128VouMes ;
      private int[] T002313_A126TASICod ;
      private string[] T002313_A129VouNum ;
      private short[] T002314_A127VouAno ;
      private short[] T002314_A128VouMes ;
      private int[] T002314_A126TASICod ;
      private string[] T002314_A129VouNum ;
      private short[] T00232_A127VouAno ;
      private short[] T00232_A128VouMes ;
      private string[] T00232_A129VouNum ;
      private DateTime[] T00232_A2074VouFec ;
      private string[] T00232_A2075VouGls ;
      private int[] T00232_A2081VouTSec ;
      private short[] T00232_A2077VouSts ;
      private string[] T00232_A2078VouTip ;
      private int[] T00232_A126TASICod ;
      private decimal[] T002319_A2079VouTotD ;
      private decimal[] T002319_A2080VouTotH ;
      private short[] T002320_A127VouAno ;
      private short[] T002320_A128VouMes ;
      private int[] T002320_A126TASICod ;
      private string[] T002320_A129VouNum ;
      private int[] T002320_A130VouDSec ;
      private short[] T002321_A127VouAno ;
      private short[] T002321_A128VouMes ;
      private int[] T002321_A126TASICod ;
      private string[] T002321_A129VouNum ;
      private int[] T002322_A126TASICod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbvoucher__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbvoucher__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00238;
        prmT00238 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT00234;
        prmT00234 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT00236;
        prmT00236 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT00239;
        prmT00239 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT002311;
        prmT002311 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002312;
        prmT002312 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT00233;
        prmT00233 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002313;
        prmT002313 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002314;
        prmT002314 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT00232;
        prmT00232 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002315;
        prmT002315 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouFec",GXType.Date,8,0) ,
        new ParDef("@VouGls",GXType.NChar,100,0) ,
        new ParDef("@VouTSec",GXType.Int32,6,0) ,
        new ParDef("@VouSts",GXType.Int16,1,0) ,
        new ParDef("@VouTip",GXType.NChar,3,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT002316;
        prmT002316 = new Object[] {
        new ParDef("@VouFec",GXType.Date,8,0) ,
        new ParDef("@VouGls",GXType.NChar,100,0) ,
        new ParDef("@VouTSec",GXType.Int32,6,0) ,
        new ParDef("@VouSts",GXType.Int16,1,0) ,
        new ParDef("@VouTip",GXType.NChar,3,0) ,
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002317;
        prmT002317 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002320;
        prmT002320 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002321;
        prmT002321 = new Object[] {
        };
        Object[] prmT002322;
        prmT002322 = new Object[] {
        new ParDef("@TASICod",GXType.Int32,6,0)
        };
        Object[] prmT002319;
        prmT002319 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00232", "SELECT [VouAno], [VouMes], [VouNum], [VouFec], [VouGls], [VouTSec], [VouSts], [VouTip], [TASICod] FROM [CBVOUCHER] WITH (UPDLOCK) WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00232,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00233", "SELECT [VouAno], [VouMes], [VouNum], [VouFec], [VouGls], [VouTSec], [VouSts], [VouTip], [TASICod] FROM [CBVOUCHER] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00233,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00234", "SELECT [TASICod] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00234,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00236", "SELECT COALESCE( T1.[VouTotD], 0) AS VouTotD, COALESCE( T1.[VouTotH], 0) AS VouTotH FROM (SELECT SUM([VouDDeb]) AS VouTotD, [VouAno], [VouMes], [TASICod], [VouNum], SUM([VouDHab]) AS VouTotH FROM [CBVOUCHERDET] GROUP BY [VouAno], [VouMes], [TASICod], [VouNum] ) T1 WHERE T1.[VouAno] = @VouAno AND T1.[VouMes] = @VouMes AND T1.[TASICod] = @TASICod AND T1.[VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00236,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00238", "SELECT TM1.[VouAno], TM1.[VouMes], TM1.[VouNum], TM1.[VouFec], TM1.[VouGls], TM1.[VouTSec], TM1.[VouSts], TM1.[VouTip], TM1.[TASICod], COALESCE( T2.[VouTotD], 0) AS VouTotD, COALESCE( T2.[VouTotH], 0) AS VouTotH FROM ([CBVOUCHER] TM1 LEFT JOIN (SELECT SUM([VouDDeb]) AS VouTotD, [VouAno], [VouMes], [TASICod], [VouNum], SUM([VouDHab]) AS VouTotH FROM [CBVOUCHERDET] GROUP BY [VouAno], [VouMes], [TASICod], [VouNum] ) T2 ON T2.[VouAno] = TM1.[VouAno] AND T2.[VouMes] = TM1.[VouMes] AND T2.[TASICod] = TM1.[TASICod] AND T2.[VouNum] = TM1.[VouNum]) WHERE TM1.[VouAno] = @VouAno and TM1.[VouMes] = @VouMes and TM1.[TASICod] = @TASICod and TM1.[VouNum] = @VouNum ORDER BY TM1.[VouAno], TM1.[VouMes], TM1.[TASICod], TM1.[VouNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00238,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00239", "SELECT [TASICod] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00239,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002311", "SELECT COALESCE( T1.[VouTotD], 0) AS VouTotD, COALESCE( T1.[VouTotH], 0) AS VouTotH FROM (SELECT SUM([VouDDeb]) AS VouTotD, [VouAno], [VouMes], [TASICod], [VouNum], SUM([VouDHab]) AS VouTotH FROM [CBVOUCHERDET] GROUP BY [VouAno], [VouMes], [TASICod], [VouNum] ) T1 WHERE T1.[VouAno] = @VouAno AND T1.[VouMes] = @VouMes AND T1.[TASICod] = @TASICod AND T1.[VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002312", "SELECT [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002313", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] WHERE ( [VouAno] > @VouAno or [VouAno] = @VouAno and [VouMes] > @VouMes or [VouMes] = @VouMes and [VouAno] = @VouAno and [TASICod] > @TASICod or [TASICod] = @TASICod and [VouMes] = @VouMes and [VouAno] = @VouAno and [VouNum] > @VouNum) ORDER BY [VouAno], [VouMes], [TASICod], [VouNum]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002313,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002314", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] WHERE ( [VouAno] < @VouAno or [VouAno] = @VouAno and [VouMes] < @VouMes or [VouMes] = @VouMes and [VouAno] = @VouAno and [TASICod] < @TASICod or [TASICod] = @TASICod and [VouMes] = @VouMes and [VouAno] = @VouAno and [VouNum] < @VouNum) ORDER BY [VouAno] DESC, [VouMes] DESC, [TASICod] DESC, [VouNum] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002314,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002315", "INSERT INTO [CBVOUCHER]([VouAno], [VouMes], [VouNum], [VouFec], [VouGls], [VouTSec], [VouSts], [VouTip], [TASICod]) VALUES(@VouAno, @VouMes, @VouNum, @VouFec, @VouGls, @VouTSec, @VouSts, @VouTip, @TASICod)", GxErrorMask.GX_NOMASK,prmT002315)
           ,new CursorDef("T002316", "UPDATE [CBVOUCHER] SET [VouFec]=@VouFec, [VouGls]=@VouGls, [VouTSec]=@VouTSec, [VouSts]=@VouSts, [VouTip]=@VouTip  WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum", GxErrorMask.GX_NOMASK,prmT002316)
           ,new CursorDef("T002317", "DELETE FROM [CBVOUCHER]  WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum", GxErrorMask.GX_NOMASK,prmT002317)
           ,new CursorDef("T002319", "SELECT COALESCE( T1.[VouTotD], 0) AS VouTotD, COALESCE( T1.[VouTotH], 0) AS VouTotH FROM (SELECT SUM([VouDDeb]) AS VouTotD, [VouAno], [VouMes], [TASICod], [VouNum], SUM([VouDHab]) AS VouTotH FROM [CBVOUCHERDET] GROUP BY [VouAno], [VouMes], [TASICod], [VouNum] ) T1 WHERE T1.[VouAno] = @VouAno AND T1.[VouMes] = @VouMes AND T1.[TASICod] = @TASICod AND T1.[VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002319,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002320", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002320,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002321", "SELECT [VouAno], [VouMes], [TASICod], [VouNum] FROM [CBVOUCHER] ORDER BY [VouAno], [VouMes], [TASICod], [VouNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002321,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002322", "SELECT [TASICod] FROM [CBTIPOASIENTO] WHERE [TASICod] = @TASICod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002322,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 13 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 15 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
