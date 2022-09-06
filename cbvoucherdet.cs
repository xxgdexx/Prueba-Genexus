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
   public class cbvoucherdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
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
            gxLoad_5( A127VouAno, A128VouMes, A126TASICod, A129VouNum) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A91CueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A79COSCod = GetPar( "COSCod");
            n79COSCod = false;
            AssignAttri("", false, "A79COSCod", A79COSCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A79COSCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A132VouDTipCod = GetPar( "VouDTipCod");
            AssignAttri("", false, "A132VouDTipCod", A132VouDTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A132VouDTipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A131VouDMon = (int)(NumberUtil.Val( GetPar( "VouDMon"), "."));
            AssignAttri("", false, "A131VouDMon", StringUtil.LTrimStr( (decimal)(A131VouDMon), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A131VouDMon) ;
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
            Form.Meta.addItem("description", "Asientos Contables - Detalles", 0) ;
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

      public cbvoucherdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbvoucherdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBVOUCHERDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Año", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127VouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A127VouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A127VouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Mes", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128VouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A128VouMes), "Z9") : context.localUtil.Format( (decimal)(A128VouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo Asiento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126TASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A126TASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "N° Asiento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouNum_Internalname, StringUtil.RTrim( A129VouNum), StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Secuencia", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDSec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A130VouDSec), 6, 0, ".", "")), StringUtil.LTrim( ((edtVouDSec_Enabled!=0) ? context.localUtil.Format( (decimal)(A130VouDSec), "ZZZZZ9") : context.localUtil.Format( (decimal)(A130VouDSec), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDSec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDSec_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Cuenta", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo de C.Costo", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCOSCod_Internalname, StringUtil.RTrim( A79COSCod), StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCOSCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCOSCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fecha", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVouDFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVouDFec_Internalname, context.localUtil.Format(A135VouDFec, "99/99/99"), context.localUtil.Format( A135VouDFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         GxWebStd.gx_bitmap( context, edtVouDFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVouDFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "T/D", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDTipCod_Internalname, StringUtil.RTrim( A132VouDTipCod), StringUtil.RTrim( context.localUtil.Format( A132VouDTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Documento", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDDoc_Internalname, StringUtil.RTrim( A2053VouDDoc), StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Glosa", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDGls_Internalname, StringUtil.RTrim( A2054VouDGls), StringUtil.RTrim( context.localUtil.Format( A2054VouDGls, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDGls_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDGls_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Moneda", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131VouDMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtVouDMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A131VouDMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A131VouDMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Tipo de Cambio", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDTcmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A2069VouDTcmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtVouDTcmb_Enabled!=0) ? context.localUtil.Format( A2069VouDTcmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A2069VouDTcmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDTcmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDTcmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Debe Origen", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDDebO_Internalname, StringUtil.LTrim( StringUtil.NToC( A2052VouDDebO, 15, 2, ".", "")), StringUtil.LTrim( ((edtVouDDebO_Enabled!=0) ? context.localUtil.Format( A2052VouDDebO, "ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2052VouDDebO, "ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDDebO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDDebO_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Haber Origen", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDHabO_Internalname, StringUtil.LTrim( StringUtil.NToC( A2056VouDHabO, 15, 2, ".", "")), StringUtil.LTrim( ((edtVouDHabO_Enabled!=0) ? context.localUtil.Format( A2056VouDHabO, "ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2056VouDHabO, "ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDHabO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDHabO_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Debe", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDDeb_Internalname, StringUtil.LTrim( StringUtil.NToC( A2051VouDDeb, 15, 2, ".", "")), StringUtil.LTrim( ((edtVouDDeb_Enabled!=0) ? context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDDeb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDDeb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Haber", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDHab_Internalname, StringUtil.LTrim( StringUtil.NToC( A2055VouDHab, 15, 2, ".", "")), StringUtil.LTrim( ((edtVouDHab_Enabled!=0) ? context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDHab_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDHab_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Registro", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouReg_Internalname, StringUtil.RTrim( A136VouReg), StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouReg_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Cuenta", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueAuxCod_Internalname, StringUtil.RTrim( A134CueAuxCod), StringUtil.RTrim( context.localUtil.Format( A134CueAuxCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueAuxCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueAuxCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Auxiliar", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCodAux_Internalname, StringUtil.RTrim( A133CueCodAux), StringUtil.RTrim( context.localUtil.Format( A133CueCodAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCodAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCodAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Movimiento Adicional", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouMovAdic_Internalname, StringUtil.RTrim( A2076VouMovAdic), StringUtil.RTrim( context.localUtil.Format( A2076VouMovAdic, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouMovAdic_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouMovAdic_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Usuario C", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDUsuCodC_Internalname, StringUtil.RTrim( A2070VouDUsuCodC), StringUtil.RTrim( context.localUtil.Format( A2070VouDUsuCodC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDUsuCodC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDUsuCodC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Usuario Fecha C", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVouDUsuFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVouDUsuFecC_Internalname, context.localUtil.TToC( A2072VouDUsuFecC, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2072VouDUsuFecC, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDUsuFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDUsuFecC_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         GxWebStd.gx_bitmap( context, edtVouDUsuFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVouDUsuFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Usuario M", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDUsuCodM_Internalname, StringUtil.RTrim( A2071VouDUsuCodM), StringUtil.RTrim( context.localUtil.Format( A2071VouDUsuCodM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDUsuCodM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDUsuCodM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Usuario Fecha M", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVouDUsuFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVouDUsuFecM_Internalname, context.localUtil.TToC( A2073VouDUsuFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2073VouDUsuFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDUsuFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDUsuFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBVOUCHERDET.htm");
         GxWebStd.gx_bitmap( context, edtVouDUsuFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVouDUsuFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Codigo Producto", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDProdCod_Internalname, StringUtil.RTrim( A2058VouDProdCod), StringUtil.RTrim( context.localUtil.Format( A2058VouDProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "N° Orden", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDordCod_Internalname, StringUtil.RTrim( A2057VouDordCod), StringUtil.RTrim( context.localUtil.Format( A2057VouDordCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDordCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDordCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Cantidad", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVouDCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A2050VouDCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtVouDCant_Enabled!=0) ? context.localUtil.Format( A2050VouDCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2050VouDCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVouDCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVouDCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CBVOUCHERDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBVOUCHERDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBVOUCHERDET.htm");
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
            Z130VouDSec = (int)(context.localUtil.CToN( cgiGet( "Z130VouDSec"), ".", ","));
            Z135VouDFec = context.localUtil.CToD( cgiGet( "Z135VouDFec"), 0);
            Z2053VouDDoc = cgiGet( "Z2053VouDDoc");
            Z2054VouDGls = cgiGet( "Z2054VouDGls");
            Z2069VouDTcmb = context.localUtil.CToN( cgiGet( "Z2069VouDTcmb"), ".", ",");
            Z2052VouDDebO = context.localUtil.CToN( cgiGet( "Z2052VouDDebO"), ".", ",");
            Z2056VouDHabO = context.localUtil.CToN( cgiGet( "Z2056VouDHabO"), ".", ",");
            Z2051VouDDeb = context.localUtil.CToN( cgiGet( "Z2051VouDDeb"), ".", ",");
            Z2055VouDHab = context.localUtil.CToN( cgiGet( "Z2055VouDHab"), ".", ",");
            Z136VouReg = cgiGet( "Z136VouReg");
            Z134CueAuxCod = cgiGet( "Z134CueAuxCod");
            Z133CueCodAux = cgiGet( "Z133CueCodAux");
            Z2076VouMovAdic = cgiGet( "Z2076VouMovAdic");
            Z2070VouDUsuCodC = cgiGet( "Z2070VouDUsuCodC");
            Z2072VouDUsuFecC = context.localUtil.CToT( cgiGet( "Z2072VouDUsuFecC"), 0);
            Z2071VouDUsuCodM = cgiGet( "Z2071VouDUsuCodM");
            Z2073VouDUsuFecM = context.localUtil.CToT( cgiGet( "Z2073VouDUsuFecM"), 0);
            Z2058VouDProdCod = cgiGet( "Z2058VouDProdCod");
            Z2057VouDordCod = cgiGet( "Z2057VouDordCod");
            Z2050VouDCant = context.localUtil.CToN( cgiGet( "Z2050VouDCant"), ".", ",");
            Z2059VouDRef1 = cgiGet( "Z2059VouDRef1");
            Z2061VouDRef2 = cgiGet( "Z2061VouDRef2");
            Z2062VouDRef3 = cgiGet( "Z2062VouDRef3");
            Z2063VouDRef4 = cgiGet( "Z2063VouDRef4");
            Z2064VouDRef5 = cgiGet( "Z2064VouDRef5");
            Z2065VouDRef6 = cgiGet( "Z2065VouDRef6");
            Z2066VouDRef7 = cgiGet( "Z2066VouDRef7");
            Z2067VouDRef8 = cgiGet( "Z2067VouDRef8");
            Z2068VouDRef9 = cgiGet( "Z2068VouDRef9");
            Z2060VouDRef10 = cgiGet( "Z2060VouDRef10");
            Z91CueCod = cgiGet( "Z91CueCod");
            Z79COSCod = cgiGet( "Z79COSCod");
            Z132VouDTipCod = cgiGet( "Z132VouDTipCod");
            Z131VouDMon = (int)(context.localUtil.CToN( cgiGet( "Z131VouDMon"), ".", ","));
            A2059VouDRef1 = cgiGet( "Z2059VouDRef1");
            A2061VouDRef2 = cgiGet( "Z2061VouDRef2");
            A2062VouDRef3 = cgiGet( "Z2062VouDRef3");
            A2063VouDRef4 = cgiGet( "Z2063VouDRef4");
            A2064VouDRef5 = cgiGet( "Z2064VouDRef5");
            A2065VouDRef6 = cgiGet( "Z2065VouDRef6");
            A2066VouDRef7 = cgiGet( "Z2066VouDRef7");
            A2067VouDRef8 = cgiGet( "Z2067VouDRef8");
            A2068VouDRef9 = cgiGet( "Z2068VouDRef9");
            A2060VouDRef10 = cgiGet( "Z2060VouDRef10");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A2059VouDRef1 = cgiGet( "VOUDREF1");
            A2061VouDRef2 = cgiGet( "VOUDREF2");
            A2062VouDRef3 = cgiGet( "VOUDREF3");
            A2063VouDRef4 = cgiGet( "VOUDREF4");
            A2064VouDRef5 = cgiGet( "VOUDREF5");
            A2065VouDRef6 = cgiGet( "VOUDREF6");
            A2066VouDRef7 = cgiGet( "VOUDREF7");
            A2067VouDRef8 = cgiGet( "VOUDREF8");
            A2068VouDRef9 = cgiGet( "VOUDREF9");
            A2060VouDRef10 = cgiGet( "VOUDREF10");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDSec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDSec_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDSEC");
               AnyError = 1;
               GX_FocusControl = edtVouDSec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A130VouDSec = 0;
               AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
            }
            else
            {
               A130VouDSec = (int)(context.localUtil.CToN( cgiGet( edtVouDSec_Internalname), ".", ","));
               AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
            }
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A79COSCod = cgiGet( edtCOSCod_Internalname);
            n79COSCod = false;
            AssignAttri("", false, "A79COSCod", A79COSCod);
            if ( context.localUtil.VCDate( cgiGet( edtVouDFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "VOUDFEC");
               AnyError = 1;
               GX_FocusControl = edtVouDFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A135VouDFec = DateTime.MinValue;
               AssignAttri("", false, "A135VouDFec", context.localUtil.Format(A135VouDFec, "99/99/99"));
            }
            else
            {
               A135VouDFec = context.localUtil.CToD( cgiGet( edtVouDFec_Internalname), 2);
               AssignAttri("", false, "A135VouDFec", context.localUtil.Format(A135VouDFec, "99/99/99"));
            }
            A132VouDTipCod = cgiGet( edtVouDTipCod_Internalname);
            AssignAttri("", false, "A132VouDTipCod", A132VouDTipCod);
            A2053VouDDoc = cgiGet( edtVouDDoc_Internalname);
            AssignAttri("", false, "A2053VouDDoc", A2053VouDDoc);
            A2054VouDGls = cgiGet( edtVouDGls_Internalname);
            AssignAttri("", false, "A2054VouDGls", A2054VouDGls);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDMon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDMON");
               AnyError = 1;
               GX_FocusControl = edtVouDMon_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A131VouDMon = 0;
               AssignAttri("", false, "A131VouDMon", StringUtil.LTrimStr( (decimal)(A131VouDMon), 6, 0));
            }
            else
            {
               A131VouDMon = (int)(context.localUtil.CToN( cgiGet( edtVouDMon_Internalname), ".", ","));
               AssignAttri("", false, "A131VouDMon", StringUtil.LTrimStr( (decimal)(A131VouDMon), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDTcmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDTcmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDTCMB");
               AnyError = 1;
               GX_FocusControl = edtVouDTcmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2069VouDTcmb = 0;
               AssignAttri("", false, "A2069VouDTcmb", StringUtil.LTrimStr( A2069VouDTcmb, 15, 5));
            }
            else
            {
               A2069VouDTcmb = context.localUtil.CToN( cgiGet( edtVouDTcmb_Internalname), ".", ",");
               AssignAttri("", false, "A2069VouDTcmb", StringUtil.LTrimStr( A2069VouDTcmb, 15, 5));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDDebO_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDDebO_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDDEBO");
               AnyError = 1;
               GX_FocusControl = edtVouDDebO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2052VouDDebO = 0;
               AssignAttri("", false, "A2052VouDDebO", StringUtil.LTrimStr( A2052VouDDebO, 15, 2));
            }
            else
            {
               A2052VouDDebO = context.localUtil.CToN( cgiGet( edtVouDDebO_Internalname), ".", ",");
               AssignAttri("", false, "A2052VouDDebO", StringUtil.LTrimStr( A2052VouDDebO, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDHabO_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDHabO_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDHABO");
               AnyError = 1;
               GX_FocusControl = edtVouDHabO_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2056VouDHabO = 0;
               AssignAttri("", false, "A2056VouDHabO", StringUtil.LTrimStr( A2056VouDHabO, 15, 2));
            }
            else
            {
               A2056VouDHabO = context.localUtil.CToN( cgiGet( edtVouDHabO_Internalname), ".", ",");
               AssignAttri("", false, "A2056VouDHabO", StringUtil.LTrimStr( A2056VouDHabO, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDDeb_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDDeb_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDDEB");
               AnyError = 1;
               GX_FocusControl = edtVouDDeb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2051VouDDeb = 0;
               AssignAttri("", false, "A2051VouDDeb", StringUtil.LTrimStr( A2051VouDDeb, 15, 2));
            }
            else
            {
               A2051VouDDeb = context.localUtil.CToN( cgiGet( edtVouDDeb_Internalname), ".", ",");
               AssignAttri("", false, "A2051VouDDeb", StringUtil.LTrimStr( A2051VouDDeb, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDHab_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDHab_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDHAB");
               AnyError = 1;
               GX_FocusControl = edtVouDHab_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2055VouDHab = 0;
               AssignAttri("", false, "A2055VouDHab", StringUtil.LTrimStr( A2055VouDHab, 15, 2));
            }
            else
            {
               A2055VouDHab = context.localUtil.CToN( cgiGet( edtVouDHab_Internalname), ".", ",");
               AssignAttri("", false, "A2055VouDHab", StringUtil.LTrimStr( A2055VouDHab, 15, 2));
            }
            A136VouReg = cgiGet( edtVouReg_Internalname);
            AssignAttri("", false, "A136VouReg", A136VouReg);
            A134CueAuxCod = cgiGet( edtCueAuxCod_Internalname);
            AssignAttri("", false, "A134CueAuxCod", A134CueAuxCod);
            A133CueCodAux = cgiGet( edtCueCodAux_Internalname);
            AssignAttri("", false, "A133CueCodAux", A133CueCodAux);
            A2076VouMovAdic = cgiGet( edtVouMovAdic_Internalname);
            AssignAttri("", false, "A2076VouMovAdic", A2076VouMovAdic);
            A2070VouDUsuCodC = cgiGet( edtVouDUsuCodC_Internalname);
            AssignAttri("", false, "A2070VouDUsuCodC", A2070VouDUsuCodC);
            if ( context.localUtil.VCDateTime( cgiGet( edtVouDUsuFecC_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha C"}), 1, "VOUDUSUFECC");
               AnyError = 1;
               GX_FocusControl = edtVouDUsuFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2072VouDUsuFecC = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A2072VouDUsuFecC", context.localUtil.TToC( A2072VouDUsuFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A2072VouDUsuFecC = context.localUtil.CToT( cgiGet( edtVouDUsuFecC_Internalname));
               AssignAttri("", false, "A2072VouDUsuFecC", context.localUtil.TToC( A2072VouDUsuFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            A2071VouDUsuCodM = cgiGet( edtVouDUsuCodM_Internalname);
            AssignAttri("", false, "A2071VouDUsuCodM", A2071VouDUsuCodM);
            if ( context.localUtil.VCDateTime( cgiGet( edtVouDUsuFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha M"}), 1, "VOUDUSUFECM");
               AnyError = 1;
               GX_FocusControl = edtVouDUsuFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2073VouDUsuFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A2073VouDUsuFecM", context.localUtil.TToC( A2073VouDUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A2073VouDUsuFecM = context.localUtil.CToT( cgiGet( edtVouDUsuFecM_Internalname));
               AssignAttri("", false, "A2073VouDUsuFecM", context.localUtil.TToC( A2073VouDUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            A2058VouDProdCod = cgiGet( edtVouDProdCod_Internalname);
            AssignAttri("", false, "A2058VouDProdCod", A2058VouDProdCod);
            A2057VouDordCod = cgiGet( edtVouDordCod_Internalname);
            AssignAttri("", false, "A2057VouDordCod", A2057VouDordCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtVouDCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtVouDCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOUDCANT");
               AnyError = 1;
               GX_FocusControl = edtVouDCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2050VouDCant = 0;
               AssignAttri("", false, "A2050VouDCant", StringUtil.LTrimStr( A2050VouDCant, 15, 4));
            }
            else
            {
               A2050VouDCant = context.localUtil.CToN( cgiGet( edtVouDCant_Internalname), ".", ",");
               AssignAttri("", false, "A2050VouDCant", StringUtil.LTrimStr( A2050VouDCant, 15, 4));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CBVOUCHERDET");
            forbiddenHiddens.Add("VouDRef1", StringUtil.RTrim( context.localUtil.Format( A2059VouDRef1, "")));
            forbiddenHiddens.Add("VouDRef2", StringUtil.RTrim( context.localUtil.Format( A2061VouDRef2, "")));
            forbiddenHiddens.Add("VouDRef3", StringUtil.RTrim( context.localUtil.Format( A2062VouDRef3, "")));
            forbiddenHiddens.Add("VouDRef4", StringUtil.RTrim( context.localUtil.Format( A2063VouDRef4, "")));
            forbiddenHiddens.Add("VouDRef5", StringUtil.RTrim( context.localUtil.Format( A2064VouDRef5, "")));
            forbiddenHiddens.Add("VouDRef6", StringUtil.RTrim( context.localUtil.Format( A2065VouDRef6, "")));
            forbiddenHiddens.Add("VouDRef7", StringUtil.RTrim( context.localUtil.Format( A2066VouDRef7, "")));
            forbiddenHiddens.Add("VouDRef8", StringUtil.RTrim( context.localUtil.Format( A2067VouDRef8, "")));
            forbiddenHiddens.Add("VouDRef9", StringUtil.RTrim( context.localUtil.Format( A2068VouDRef9, "")));
            forbiddenHiddens.Add("VouDRef10", StringUtil.RTrim( context.localUtil.Format( A2060VouDRef10, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) || ( A130VouDSec != Z130VouDSec ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cbvoucherdet:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A127VouAno = (short)(NumberUtil.Val( GetPar( "VouAno"), "."));
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = (short)(NumberUtil.Val( GetPar( "VouMes"), "."));
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = GetPar( "VouNum");
               AssignAttri("", false, "A129VouNum", A129VouNum);
               A130VouDSec = (int)(NumberUtil.Val( GetPar( "VouDSec"), "."));
               AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
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
               InitAll2473( ) ;
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
         DisableAttributes2473( ) ;
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

      protected void CONFIRM_240( )
      {
         BeforeValidate2473( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2473( ) ;
            }
            else
            {
               CheckExtendedTable2473( ) ;
               if ( AnyError == 0 )
               {
                  ZM2473( 5) ;
                  ZM2473( 6) ;
                  ZM2473( 7) ;
                  ZM2473( 8) ;
                  ZM2473( 9) ;
               }
               CloseExtendedTableCursors2473( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues240( ) ;
         }
      }

      protected void ResetCaption240( )
      {
      }

      protected void ZM2473( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z135VouDFec = T00243_A135VouDFec[0];
               Z2053VouDDoc = T00243_A2053VouDDoc[0];
               Z2054VouDGls = T00243_A2054VouDGls[0];
               Z2069VouDTcmb = T00243_A2069VouDTcmb[0];
               Z2052VouDDebO = T00243_A2052VouDDebO[0];
               Z2056VouDHabO = T00243_A2056VouDHabO[0];
               Z2051VouDDeb = T00243_A2051VouDDeb[0];
               Z2055VouDHab = T00243_A2055VouDHab[0];
               Z136VouReg = T00243_A136VouReg[0];
               Z134CueAuxCod = T00243_A134CueAuxCod[0];
               Z133CueCodAux = T00243_A133CueCodAux[0];
               Z2076VouMovAdic = T00243_A2076VouMovAdic[0];
               Z2070VouDUsuCodC = T00243_A2070VouDUsuCodC[0];
               Z2072VouDUsuFecC = T00243_A2072VouDUsuFecC[0];
               Z2071VouDUsuCodM = T00243_A2071VouDUsuCodM[0];
               Z2073VouDUsuFecM = T00243_A2073VouDUsuFecM[0];
               Z2058VouDProdCod = T00243_A2058VouDProdCod[0];
               Z2057VouDordCod = T00243_A2057VouDordCod[0];
               Z2050VouDCant = T00243_A2050VouDCant[0];
               Z2059VouDRef1 = T00243_A2059VouDRef1[0];
               Z2061VouDRef2 = T00243_A2061VouDRef2[0];
               Z2062VouDRef3 = T00243_A2062VouDRef3[0];
               Z2063VouDRef4 = T00243_A2063VouDRef4[0];
               Z2064VouDRef5 = T00243_A2064VouDRef5[0];
               Z2065VouDRef6 = T00243_A2065VouDRef6[0];
               Z2066VouDRef7 = T00243_A2066VouDRef7[0];
               Z2067VouDRef8 = T00243_A2067VouDRef8[0];
               Z2068VouDRef9 = T00243_A2068VouDRef9[0];
               Z2060VouDRef10 = T00243_A2060VouDRef10[0];
               Z91CueCod = T00243_A91CueCod[0];
               Z79COSCod = T00243_A79COSCod[0];
               Z132VouDTipCod = T00243_A132VouDTipCod[0];
               Z131VouDMon = T00243_A131VouDMon[0];
            }
            else
            {
               Z135VouDFec = A135VouDFec;
               Z2053VouDDoc = A2053VouDDoc;
               Z2054VouDGls = A2054VouDGls;
               Z2069VouDTcmb = A2069VouDTcmb;
               Z2052VouDDebO = A2052VouDDebO;
               Z2056VouDHabO = A2056VouDHabO;
               Z2051VouDDeb = A2051VouDDeb;
               Z2055VouDHab = A2055VouDHab;
               Z136VouReg = A136VouReg;
               Z134CueAuxCod = A134CueAuxCod;
               Z133CueCodAux = A133CueCodAux;
               Z2076VouMovAdic = A2076VouMovAdic;
               Z2070VouDUsuCodC = A2070VouDUsuCodC;
               Z2072VouDUsuFecC = A2072VouDUsuFecC;
               Z2071VouDUsuCodM = A2071VouDUsuCodM;
               Z2073VouDUsuFecM = A2073VouDUsuFecM;
               Z2058VouDProdCod = A2058VouDProdCod;
               Z2057VouDordCod = A2057VouDordCod;
               Z2050VouDCant = A2050VouDCant;
               Z2059VouDRef1 = A2059VouDRef1;
               Z2061VouDRef2 = A2061VouDRef2;
               Z2062VouDRef3 = A2062VouDRef3;
               Z2063VouDRef4 = A2063VouDRef4;
               Z2064VouDRef5 = A2064VouDRef5;
               Z2065VouDRef6 = A2065VouDRef6;
               Z2066VouDRef7 = A2066VouDRef7;
               Z2067VouDRef8 = A2067VouDRef8;
               Z2068VouDRef9 = A2068VouDRef9;
               Z2060VouDRef10 = A2060VouDRef10;
               Z91CueCod = A91CueCod;
               Z79COSCod = A79COSCod;
               Z132VouDTipCod = A132VouDTipCod;
               Z131VouDMon = A131VouDMon;
            }
         }
         if ( GX_JID == -4 )
         {
            Z130VouDSec = A130VouDSec;
            Z135VouDFec = A135VouDFec;
            Z2053VouDDoc = A2053VouDDoc;
            Z2054VouDGls = A2054VouDGls;
            Z2069VouDTcmb = A2069VouDTcmb;
            Z2052VouDDebO = A2052VouDDebO;
            Z2056VouDHabO = A2056VouDHabO;
            Z2051VouDDeb = A2051VouDDeb;
            Z2055VouDHab = A2055VouDHab;
            Z136VouReg = A136VouReg;
            Z134CueAuxCod = A134CueAuxCod;
            Z133CueCodAux = A133CueCodAux;
            Z2076VouMovAdic = A2076VouMovAdic;
            Z2070VouDUsuCodC = A2070VouDUsuCodC;
            Z2072VouDUsuFecC = A2072VouDUsuFecC;
            Z2071VouDUsuCodM = A2071VouDUsuCodM;
            Z2073VouDUsuFecM = A2073VouDUsuFecM;
            Z2058VouDProdCod = A2058VouDProdCod;
            Z2057VouDordCod = A2057VouDordCod;
            Z2050VouDCant = A2050VouDCant;
            Z2059VouDRef1 = A2059VouDRef1;
            Z2061VouDRef2 = A2061VouDRef2;
            Z2062VouDRef3 = A2062VouDRef3;
            Z2063VouDRef4 = A2063VouDRef4;
            Z2064VouDRef5 = A2064VouDRef5;
            Z2065VouDRef6 = A2065VouDRef6;
            Z2066VouDRef7 = A2066VouDRef7;
            Z2067VouDRef8 = A2067VouDRef8;
            Z2068VouDRef9 = A2068VouDRef9;
            Z2060VouDRef10 = A2060VouDRef10;
            Z127VouAno = A127VouAno;
            Z128VouMes = A128VouMes;
            Z126TASICod = A126TASICod;
            Z129VouNum = A129VouNum;
            Z91CueCod = A91CueCod;
            Z79COSCod = A79COSCod;
            Z132VouDTipCod = A132VouDTipCod;
            Z131VouDMon = A131VouDMon;
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

      protected void Load2473( )
      {
         /* Using cursor T00249 */
         pr_default.execute(7, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound73 = 1;
            A135VouDFec = T00249_A135VouDFec[0];
            AssignAttri("", false, "A135VouDFec", context.localUtil.Format(A135VouDFec, "99/99/99"));
            A2053VouDDoc = T00249_A2053VouDDoc[0];
            AssignAttri("", false, "A2053VouDDoc", A2053VouDDoc);
            A2054VouDGls = T00249_A2054VouDGls[0];
            AssignAttri("", false, "A2054VouDGls", A2054VouDGls);
            A2069VouDTcmb = T00249_A2069VouDTcmb[0];
            AssignAttri("", false, "A2069VouDTcmb", StringUtil.LTrimStr( A2069VouDTcmb, 15, 5));
            A2052VouDDebO = T00249_A2052VouDDebO[0];
            AssignAttri("", false, "A2052VouDDebO", StringUtil.LTrimStr( A2052VouDDebO, 15, 2));
            A2056VouDHabO = T00249_A2056VouDHabO[0];
            AssignAttri("", false, "A2056VouDHabO", StringUtil.LTrimStr( A2056VouDHabO, 15, 2));
            A2051VouDDeb = T00249_A2051VouDDeb[0];
            AssignAttri("", false, "A2051VouDDeb", StringUtil.LTrimStr( A2051VouDDeb, 15, 2));
            A2055VouDHab = T00249_A2055VouDHab[0];
            AssignAttri("", false, "A2055VouDHab", StringUtil.LTrimStr( A2055VouDHab, 15, 2));
            A136VouReg = T00249_A136VouReg[0];
            AssignAttri("", false, "A136VouReg", A136VouReg);
            A134CueAuxCod = T00249_A134CueAuxCod[0];
            AssignAttri("", false, "A134CueAuxCod", A134CueAuxCod);
            A133CueCodAux = T00249_A133CueCodAux[0];
            AssignAttri("", false, "A133CueCodAux", A133CueCodAux);
            A2076VouMovAdic = T00249_A2076VouMovAdic[0];
            AssignAttri("", false, "A2076VouMovAdic", A2076VouMovAdic);
            A2070VouDUsuCodC = T00249_A2070VouDUsuCodC[0];
            AssignAttri("", false, "A2070VouDUsuCodC", A2070VouDUsuCodC);
            A2072VouDUsuFecC = T00249_A2072VouDUsuFecC[0];
            AssignAttri("", false, "A2072VouDUsuFecC", context.localUtil.TToC( A2072VouDUsuFecC, 8, 5, 0, 3, "/", ":", " "));
            A2071VouDUsuCodM = T00249_A2071VouDUsuCodM[0];
            AssignAttri("", false, "A2071VouDUsuCodM", A2071VouDUsuCodM);
            A2073VouDUsuFecM = T00249_A2073VouDUsuFecM[0];
            AssignAttri("", false, "A2073VouDUsuFecM", context.localUtil.TToC( A2073VouDUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            A2058VouDProdCod = T00249_A2058VouDProdCod[0];
            AssignAttri("", false, "A2058VouDProdCod", A2058VouDProdCod);
            A2057VouDordCod = T00249_A2057VouDordCod[0];
            AssignAttri("", false, "A2057VouDordCod", A2057VouDordCod);
            A2050VouDCant = T00249_A2050VouDCant[0];
            AssignAttri("", false, "A2050VouDCant", StringUtil.LTrimStr( A2050VouDCant, 15, 4));
            A2059VouDRef1 = T00249_A2059VouDRef1[0];
            A2061VouDRef2 = T00249_A2061VouDRef2[0];
            A2062VouDRef3 = T00249_A2062VouDRef3[0];
            A2063VouDRef4 = T00249_A2063VouDRef4[0];
            A2064VouDRef5 = T00249_A2064VouDRef5[0];
            A2065VouDRef6 = T00249_A2065VouDRef6[0];
            A2066VouDRef7 = T00249_A2066VouDRef7[0];
            A2067VouDRef8 = T00249_A2067VouDRef8[0];
            A2068VouDRef9 = T00249_A2068VouDRef9[0];
            A2060VouDRef10 = T00249_A2060VouDRef10[0];
            A91CueCod = T00249_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A79COSCod = T00249_A79COSCod[0];
            n79COSCod = T00249_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A132VouDTipCod = T00249_A132VouDTipCod[0];
            AssignAttri("", false, "A132VouDTipCod", A132VouDTipCod);
            A131VouDMon = T00249_A131VouDMon[0];
            AssignAttri("", false, "A131VouDMon", StringUtil.LTrimStr( (decimal)(A131VouDMon), 6, 0));
            ZM2473( -4) ;
         }
         pr_default.close(7);
         OnLoadActions2473( ) ;
      }

      protected void OnLoadActions2473( )
      {
      }

      protected void CheckExtendedTable2473( )
      {
         nIsDirty_73 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00244 */
         pr_default.execute(2, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Asiento Contable'.", "ForeignKeyNotFound", 1, "VOUNUM");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00245 */
         pr_default.execute(3, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00246 */
         pr_default.execute(4, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A135VouDFec) || ( DateTimeUtil.ResetTime ( A135VouDFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "VOUDFEC");
            AnyError = 1;
            GX_FocusControl = edtVouDFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00247 */
         pr_default.execute(5, new Object[] {A132VouDTipCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "VOUDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtVouDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T00248 */
         pr_default.execute(6, new Object[] {A131VouDMon});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "VOUDMON");
            AnyError = 1;
            GX_FocusControl = edtVouDMon_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A2072VouDUsuFecC) || ( A2072VouDUsuFecC >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha C fuera de rango", "OutOfRange", 1, "VOUDUSUFECC");
            AnyError = 1;
            GX_FocusControl = edtVouDUsuFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A2073VouDUsuFecM) || ( A2073VouDUsuFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha M fuera de rango", "OutOfRange", 1, "VOUDUSUFECM");
            AnyError = 1;
            GX_FocusControl = edtVouDUsuFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2473( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( short A127VouAno ,
                               short A128VouMes ,
                               int A126TASICod ,
                               string A129VouNum )
      {
         /* Using cursor T002410 */
         pr_default.execute(8, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Asiento Contable'.", "ForeignKeyNotFound", 1, "VOUNUM");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
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

      protected void gxLoad_6( string A91CueCod )
      {
         /* Using cursor T002411 */
         pr_default.execute(9, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
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

      protected void gxLoad_7( string A79COSCod )
      {
         /* Using cursor T002412 */
         pr_default.execute(10, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
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

      protected void gxLoad_8( string A132VouDTipCod )
      {
         /* Using cursor T002413 */
         pr_default.execute(11, new Object[] {A132VouDTipCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "VOUDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtVouDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_9( int A131VouDMon )
      {
         /* Using cursor T002414 */
         pr_default.execute(12, new Object[] {A131VouDMon});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "VOUDMON");
            AnyError = 1;
            GX_FocusControl = edtVouDMon_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey2473( )
      {
         /* Using cursor T002415 */
         pr_default.execute(13, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00243 */
         pr_default.execute(1, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2473( 4) ;
            RcdFound73 = 1;
            A130VouDSec = T00243_A130VouDSec[0];
            AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
            A135VouDFec = T00243_A135VouDFec[0];
            AssignAttri("", false, "A135VouDFec", context.localUtil.Format(A135VouDFec, "99/99/99"));
            A2053VouDDoc = T00243_A2053VouDDoc[0];
            AssignAttri("", false, "A2053VouDDoc", A2053VouDDoc);
            A2054VouDGls = T00243_A2054VouDGls[0];
            AssignAttri("", false, "A2054VouDGls", A2054VouDGls);
            A2069VouDTcmb = T00243_A2069VouDTcmb[0];
            AssignAttri("", false, "A2069VouDTcmb", StringUtil.LTrimStr( A2069VouDTcmb, 15, 5));
            A2052VouDDebO = T00243_A2052VouDDebO[0];
            AssignAttri("", false, "A2052VouDDebO", StringUtil.LTrimStr( A2052VouDDebO, 15, 2));
            A2056VouDHabO = T00243_A2056VouDHabO[0];
            AssignAttri("", false, "A2056VouDHabO", StringUtil.LTrimStr( A2056VouDHabO, 15, 2));
            A2051VouDDeb = T00243_A2051VouDDeb[0];
            AssignAttri("", false, "A2051VouDDeb", StringUtil.LTrimStr( A2051VouDDeb, 15, 2));
            A2055VouDHab = T00243_A2055VouDHab[0];
            AssignAttri("", false, "A2055VouDHab", StringUtil.LTrimStr( A2055VouDHab, 15, 2));
            A136VouReg = T00243_A136VouReg[0];
            AssignAttri("", false, "A136VouReg", A136VouReg);
            A134CueAuxCod = T00243_A134CueAuxCod[0];
            AssignAttri("", false, "A134CueAuxCod", A134CueAuxCod);
            A133CueCodAux = T00243_A133CueCodAux[0];
            AssignAttri("", false, "A133CueCodAux", A133CueCodAux);
            A2076VouMovAdic = T00243_A2076VouMovAdic[0];
            AssignAttri("", false, "A2076VouMovAdic", A2076VouMovAdic);
            A2070VouDUsuCodC = T00243_A2070VouDUsuCodC[0];
            AssignAttri("", false, "A2070VouDUsuCodC", A2070VouDUsuCodC);
            A2072VouDUsuFecC = T00243_A2072VouDUsuFecC[0];
            AssignAttri("", false, "A2072VouDUsuFecC", context.localUtil.TToC( A2072VouDUsuFecC, 8, 5, 0, 3, "/", ":", " "));
            A2071VouDUsuCodM = T00243_A2071VouDUsuCodM[0];
            AssignAttri("", false, "A2071VouDUsuCodM", A2071VouDUsuCodM);
            A2073VouDUsuFecM = T00243_A2073VouDUsuFecM[0];
            AssignAttri("", false, "A2073VouDUsuFecM", context.localUtil.TToC( A2073VouDUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            A2058VouDProdCod = T00243_A2058VouDProdCod[0];
            AssignAttri("", false, "A2058VouDProdCod", A2058VouDProdCod);
            A2057VouDordCod = T00243_A2057VouDordCod[0];
            AssignAttri("", false, "A2057VouDordCod", A2057VouDordCod);
            A2050VouDCant = T00243_A2050VouDCant[0];
            AssignAttri("", false, "A2050VouDCant", StringUtil.LTrimStr( A2050VouDCant, 15, 4));
            A2059VouDRef1 = T00243_A2059VouDRef1[0];
            A2061VouDRef2 = T00243_A2061VouDRef2[0];
            A2062VouDRef3 = T00243_A2062VouDRef3[0];
            A2063VouDRef4 = T00243_A2063VouDRef4[0];
            A2064VouDRef5 = T00243_A2064VouDRef5[0];
            A2065VouDRef6 = T00243_A2065VouDRef6[0];
            A2066VouDRef7 = T00243_A2066VouDRef7[0];
            A2067VouDRef8 = T00243_A2067VouDRef8[0];
            A2068VouDRef9 = T00243_A2068VouDRef9[0];
            A2060VouDRef10 = T00243_A2060VouDRef10[0];
            A127VouAno = T00243_A127VouAno[0];
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = T00243_A128VouMes[0];
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = T00243_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = T00243_A129VouNum[0];
            AssignAttri("", false, "A129VouNum", A129VouNum);
            A91CueCod = T00243_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A79COSCod = T00243_A79COSCod[0];
            n79COSCod = T00243_n79COSCod[0];
            AssignAttri("", false, "A79COSCod", A79COSCod);
            A132VouDTipCod = T00243_A132VouDTipCod[0];
            AssignAttri("", false, "A132VouDTipCod", A132VouDTipCod);
            A131VouDMon = T00243_A131VouDMon[0];
            AssignAttri("", false, "A131VouDMon", StringUtil.LTrimStr( (decimal)(A131VouDMon), 6, 0));
            Z127VouAno = A127VouAno;
            Z128VouMes = A128VouMes;
            Z126TASICod = A126TASICod;
            Z129VouNum = A129VouNum;
            Z130VouDSec = A130VouDSec;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2473( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey2473( ) ;
            }
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey2473( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2473( ) ;
         if ( RcdFound73 == 0 )
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
         RcdFound73 = 0;
         /* Using cursor T002416 */
         pr_default.execute(14, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T002416_A127VouAno[0] < A127VouAno ) || ( T002416_A127VouAno[0] == A127VouAno ) && ( T002416_A128VouMes[0] < A128VouMes ) || ( T002416_A128VouMes[0] == A128VouMes ) && ( T002416_A127VouAno[0] == A127VouAno ) && ( T002416_A126TASICod[0] < A126TASICod ) || ( T002416_A126TASICod[0] == A126TASICod ) && ( T002416_A128VouMes[0] == A128VouMes ) && ( T002416_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002416_A129VouNum[0], A129VouNum) < 0 ) || ( StringUtil.StrCmp(T002416_A129VouNum[0], A129VouNum) == 0 ) && ( T002416_A126TASICod[0] == A126TASICod ) && ( T002416_A128VouMes[0] == A128VouMes ) && ( T002416_A127VouAno[0] == A127VouAno ) && ( T002416_A130VouDSec[0] < A130VouDSec ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T002416_A127VouAno[0] > A127VouAno ) || ( T002416_A127VouAno[0] == A127VouAno ) && ( T002416_A128VouMes[0] > A128VouMes ) || ( T002416_A128VouMes[0] == A128VouMes ) && ( T002416_A127VouAno[0] == A127VouAno ) && ( T002416_A126TASICod[0] > A126TASICod ) || ( T002416_A126TASICod[0] == A126TASICod ) && ( T002416_A128VouMes[0] == A128VouMes ) && ( T002416_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002416_A129VouNum[0], A129VouNum) > 0 ) || ( StringUtil.StrCmp(T002416_A129VouNum[0], A129VouNum) == 0 ) && ( T002416_A126TASICod[0] == A126TASICod ) && ( T002416_A128VouMes[0] == A128VouMes ) && ( T002416_A127VouAno[0] == A127VouAno ) && ( T002416_A130VouDSec[0] > A130VouDSec ) ) )
            {
               A127VouAno = T002416_A127VouAno[0];
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = T002416_A128VouMes[0];
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = T002416_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = T002416_A129VouNum[0];
               AssignAttri("", false, "A129VouNum", A129VouNum);
               A130VouDSec = T002416_A130VouDSec[0];
               AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
               RcdFound73 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound73 = 0;
         /* Using cursor T002417 */
         pr_default.execute(15, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T002417_A127VouAno[0] > A127VouAno ) || ( T002417_A127VouAno[0] == A127VouAno ) && ( T002417_A128VouMes[0] > A128VouMes ) || ( T002417_A128VouMes[0] == A128VouMes ) && ( T002417_A127VouAno[0] == A127VouAno ) && ( T002417_A126TASICod[0] > A126TASICod ) || ( T002417_A126TASICod[0] == A126TASICod ) && ( T002417_A128VouMes[0] == A128VouMes ) && ( T002417_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002417_A129VouNum[0], A129VouNum) > 0 ) || ( StringUtil.StrCmp(T002417_A129VouNum[0], A129VouNum) == 0 ) && ( T002417_A126TASICod[0] == A126TASICod ) && ( T002417_A128VouMes[0] == A128VouMes ) && ( T002417_A127VouAno[0] == A127VouAno ) && ( T002417_A130VouDSec[0] > A130VouDSec ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T002417_A127VouAno[0] < A127VouAno ) || ( T002417_A127VouAno[0] == A127VouAno ) && ( T002417_A128VouMes[0] < A128VouMes ) || ( T002417_A128VouMes[0] == A128VouMes ) && ( T002417_A127VouAno[0] == A127VouAno ) && ( T002417_A126TASICod[0] < A126TASICod ) || ( T002417_A126TASICod[0] == A126TASICod ) && ( T002417_A128VouMes[0] == A128VouMes ) && ( T002417_A127VouAno[0] == A127VouAno ) && ( StringUtil.StrCmp(T002417_A129VouNum[0], A129VouNum) < 0 ) || ( StringUtil.StrCmp(T002417_A129VouNum[0], A129VouNum) == 0 ) && ( T002417_A126TASICod[0] == A126TASICod ) && ( T002417_A128VouMes[0] == A128VouMes ) && ( T002417_A127VouAno[0] == A127VouAno ) && ( T002417_A130VouDSec[0] < A130VouDSec ) ) )
            {
               A127VouAno = T002417_A127VouAno[0];
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = T002417_A128VouMes[0];
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = T002417_A126TASICod[0];
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = T002417_A129VouNum[0];
               AssignAttri("", false, "A129VouNum", A129VouNum);
               A130VouDSec = T002417_A130VouDSec[0];
               AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
               RcdFound73 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2473( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2473( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) || ( A130VouDSec != Z130VouDSec ) )
               {
                  A127VouAno = Z127VouAno;
                  AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
                  A128VouMes = Z128VouMes;
                  AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
                  A126TASICod = Z126TASICod;
                  AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
                  A129VouNum = Z129VouNum;
                  AssignAttri("", false, "A129VouNum", A129VouNum);
                  A130VouDSec = Z130VouDSec;
                  AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
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
                  Update2473( ) ;
                  GX_FocusControl = edtVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) || ( A130VouDSec != Z130VouDSec ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2473( ) ;
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
                     Insert2473( ) ;
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
         if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) || ( A130VouDSec != Z130VouDSec ) )
         {
            A127VouAno = Z127VouAno;
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = Z128VouMes;
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = Z126TASICod;
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = Z129VouNum;
            AssignAttri("", false, "A129VouNum", A129VouNum);
            A130VouDSec = Z130VouDSec;
            AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
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
         GetKey2473( ) ;
         if ( RcdFound73 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "VOUANO");
               AnyError = 1;
               GX_FocusControl = edtVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) || ( A130VouDSec != Z130VouDSec ) )
            {
               A127VouAno = Z127VouAno;
               AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
               A128VouMes = Z128VouMes;
               AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
               A126TASICod = Z126TASICod;
               AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
               A129VouNum = Z129VouNum;
               AssignAttri("", false, "A129VouNum", A129VouNum);
               A130VouDSec = Z130VouDSec;
               AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
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
            if ( ( A127VouAno != Z127VouAno ) || ( A128VouMes != Z128VouMes ) || ( A126TASICod != Z126TASICod ) || ( StringUtil.StrCmp(A129VouNum, Z129VouNum) != 0 ) || ( A130VouDSec != Z130VouDSec ) )
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
         context.RollbackDataStores("cbvoucherdet",pr_default);
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_240( ) ;
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
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VOUANO");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2473( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2473( ) ;
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
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
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
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
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
         ScanStart2473( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound73 != 0 )
            {
               ScanNext2473( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCueCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2473( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2473( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00242 */
            pr_default.execute(0, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBVOUCHERDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z135VouDFec ) != DateTimeUtil.ResetTime ( T00242_A135VouDFec[0] ) ) || ( StringUtil.StrCmp(Z2053VouDDoc, T00242_A2053VouDDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z2054VouDGls, T00242_A2054VouDGls[0]) != 0 ) || ( Z2069VouDTcmb != T00242_A2069VouDTcmb[0] ) || ( Z2052VouDDebO != T00242_A2052VouDDebO[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2056VouDHabO != T00242_A2056VouDHabO[0] ) || ( Z2051VouDDeb != T00242_A2051VouDDeb[0] ) || ( Z2055VouDHab != T00242_A2055VouDHab[0] ) || ( StringUtil.StrCmp(Z136VouReg, T00242_A136VouReg[0]) != 0 ) || ( StringUtil.StrCmp(Z134CueAuxCod, T00242_A134CueAuxCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z133CueCodAux, T00242_A133CueCodAux[0]) != 0 ) || ( StringUtil.StrCmp(Z2076VouMovAdic, T00242_A2076VouMovAdic[0]) != 0 ) || ( StringUtil.StrCmp(Z2070VouDUsuCodC, T00242_A2070VouDUsuCodC[0]) != 0 ) || ( Z2072VouDUsuFecC != T00242_A2072VouDUsuFecC[0] ) || ( StringUtil.StrCmp(Z2071VouDUsuCodM, T00242_A2071VouDUsuCodM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2073VouDUsuFecM != T00242_A2073VouDUsuFecM[0] ) || ( StringUtil.StrCmp(Z2058VouDProdCod, T00242_A2058VouDProdCod[0]) != 0 ) || ( StringUtil.StrCmp(Z2057VouDordCod, T00242_A2057VouDordCod[0]) != 0 ) || ( Z2050VouDCant != T00242_A2050VouDCant[0] ) || ( StringUtil.StrCmp(Z2059VouDRef1, T00242_A2059VouDRef1[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2061VouDRef2, T00242_A2061VouDRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z2062VouDRef3, T00242_A2062VouDRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z2063VouDRef4, T00242_A2063VouDRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z2064VouDRef5, T00242_A2064VouDRef5[0]) != 0 ) || ( StringUtil.StrCmp(Z2065VouDRef6, T00242_A2065VouDRef6[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2066VouDRef7, T00242_A2066VouDRef7[0]) != 0 ) || ( StringUtil.StrCmp(Z2067VouDRef8, T00242_A2067VouDRef8[0]) != 0 ) || ( StringUtil.StrCmp(Z2068VouDRef9, T00242_A2068VouDRef9[0]) != 0 ) || ( StringUtil.StrCmp(Z2060VouDRef10, T00242_A2060VouDRef10[0]) != 0 ) || ( StringUtil.StrCmp(Z91CueCod, T00242_A91CueCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z79COSCod, T00242_A79COSCod[0]) != 0 ) || ( StringUtil.StrCmp(Z132VouDTipCod, T00242_A132VouDTipCod[0]) != 0 ) || ( Z131VouDMon != T00242_A131VouDMon[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z135VouDFec ) != DateTimeUtil.ResetTime ( T00242_A135VouDFec[0] ) )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDFec");
                  GXUtil.WriteLogRaw("Old: ",Z135VouDFec);
                  GXUtil.WriteLogRaw("Current: ",T00242_A135VouDFec[0]);
               }
               if ( StringUtil.StrCmp(Z2053VouDDoc, T00242_A2053VouDDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDDoc");
                  GXUtil.WriteLogRaw("Old: ",Z2053VouDDoc);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2053VouDDoc[0]);
               }
               if ( StringUtil.StrCmp(Z2054VouDGls, T00242_A2054VouDGls[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDGls");
                  GXUtil.WriteLogRaw("Old: ",Z2054VouDGls);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2054VouDGls[0]);
               }
               if ( Z2069VouDTcmb != T00242_A2069VouDTcmb[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDTcmb");
                  GXUtil.WriteLogRaw("Old: ",Z2069VouDTcmb);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2069VouDTcmb[0]);
               }
               if ( Z2052VouDDebO != T00242_A2052VouDDebO[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDDebO");
                  GXUtil.WriteLogRaw("Old: ",Z2052VouDDebO);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2052VouDDebO[0]);
               }
               if ( Z2056VouDHabO != T00242_A2056VouDHabO[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDHabO");
                  GXUtil.WriteLogRaw("Old: ",Z2056VouDHabO);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2056VouDHabO[0]);
               }
               if ( Z2051VouDDeb != T00242_A2051VouDDeb[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDDeb");
                  GXUtil.WriteLogRaw("Old: ",Z2051VouDDeb);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2051VouDDeb[0]);
               }
               if ( Z2055VouDHab != T00242_A2055VouDHab[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDHab");
                  GXUtil.WriteLogRaw("Old: ",Z2055VouDHab);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2055VouDHab[0]);
               }
               if ( StringUtil.StrCmp(Z136VouReg, T00242_A136VouReg[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouReg");
                  GXUtil.WriteLogRaw("Old: ",Z136VouReg);
                  GXUtil.WriteLogRaw("Current: ",T00242_A136VouReg[0]);
               }
               if ( StringUtil.StrCmp(Z134CueAuxCod, T00242_A134CueAuxCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"CueAuxCod");
                  GXUtil.WriteLogRaw("Old: ",Z134CueAuxCod);
                  GXUtil.WriteLogRaw("Current: ",T00242_A134CueAuxCod[0]);
               }
               if ( StringUtil.StrCmp(Z133CueCodAux, T00242_A133CueCodAux[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"CueCodAux");
                  GXUtil.WriteLogRaw("Old: ",Z133CueCodAux);
                  GXUtil.WriteLogRaw("Current: ",T00242_A133CueCodAux[0]);
               }
               if ( StringUtil.StrCmp(Z2076VouMovAdic, T00242_A2076VouMovAdic[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouMovAdic");
                  GXUtil.WriteLogRaw("Old: ",Z2076VouMovAdic);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2076VouMovAdic[0]);
               }
               if ( StringUtil.StrCmp(Z2070VouDUsuCodC, T00242_A2070VouDUsuCodC[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDUsuCodC");
                  GXUtil.WriteLogRaw("Old: ",Z2070VouDUsuCodC);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2070VouDUsuCodC[0]);
               }
               if ( Z2072VouDUsuFecC != T00242_A2072VouDUsuFecC[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDUsuFecC");
                  GXUtil.WriteLogRaw("Old: ",Z2072VouDUsuFecC);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2072VouDUsuFecC[0]);
               }
               if ( StringUtil.StrCmp(Z2071VouDUsuCodM, T00242_A2071VouDUsuCodM[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDUsuCodM");
                  GXUtil.WriteLogRaw("Old: ",Z2071VouDUsuCodM);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2071VouDUsuCodM[0]);
               }
               if ( Z2073VouDUsuFecM != T00242_A2073VouDUsuFecM[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDUsuFecM");
                  GXUtil.WriteLogRaw("Old: ",Z2073VouDUsuFecM);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2073VouDUsuFecM[0]);
               }
               if ( StringUtil.StrCmp(Z2058VouDProdCod, T00242_A2058VouDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z2058VouDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2058VouDProdCod[0]);
               }
               if ( StringUtil.StrCmp(Z2057VouDordCod, T00242_A2057VouDordCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDordCod");
                  GXUtil.WriteLogRaw("Old: ",Z2057VouDordCod);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2057VouDordCod[0]);
               }
               if ( Z2050VouDCant != T00242_A2050VouDCant[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDCant");
                  GXUtil.WriteLogRaw("Old: ",Z2050VouDCant);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2050VouDCant[0]);
               }
               if ( StringUtil.StrCmp(Z2059VouDRef1, T00242_A2059VouDRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef1");
                  GXUtil.WriteLogRaw("Old: ",Z2059VouDRef1);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2059VouDRef1[0]);
               }
               if ( StringUtil.StrCmp(Z2061VouDRef2, T00242_A2061VouDRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef2");
                  GXUtil.WriteLogRaw("Old: ",Z2061VouDRef2);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2061VouDRef2[0]);
               }
               if ( StringUtil.StrCmp(Z2062VouDRef3, T00242_A2062VouDRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef3");
                  GXUtil.WriteLogRaw("Old: ",Z2062VouDRef3);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2062VouDRef3[0]);
               }
               if ( StringUtil.StrCmp(Z2063VouDRef4, T00242_A2063VouDRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef4");
                  GXUtil.WriteLogRaw("Old: ",Z2063VouDRef4);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2063VouDRef4[0]);
               }
               if ( StringUtil.StrCmp(Z2064VouDRef5, T00242_A2064VouDRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef5");
                  GXUtil.WriteLogRaw("Old: ",Z2064VouDRef5);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2064VouDRef5[0]);
               }
               if ( StringUtil.StrCmp(Z2065VouDRef6, T00242_A2065VouDRef6[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef6");
                  GXUtil.WriteLogRaw("Old: ",Z2065VouDRef6);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2065VouDRef6[0]);
               }
               if ( StringUtil.StrCmp(Z2066VouDRef7, T00242_A2066VouDRef7[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef7");
                  GXUtil.WriteLogRaw("Old: ",Z2066VouDRef7);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2066VouDRef7[0]);
               }
               if ( StringUtil.StrCmp(Z2067VouDRef8, T00242_A2067VouDRef8[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef8");
                  GXUtil.WriteLogRaw("Old: ",Z2067VouDRef8);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2067VouDRef8[0]);
               }
               if ( StringUtil.StrCmp(Z2068VouDRef9, T00242_A2068VouDRef9[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef9");
                  GXUtil.WriteLogRaw("Old: ",Z2068VouDRef9);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2068VouDRef9[0]);
               }
               if ( StringUtil.StrCmp(Z2060VouDRef10, T00242_A2060VouDRef10[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDRef10");
                  GXUtil.WriteLogRaw("Old: ",Z2060VouDRef10);
                  GXUtil.WriteLogRaw("Current: ",T00242_A2060VouDRef10[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T00242_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T00242_A91CueCod[0]);
               }
               if ( StringUtil.StrCmp(Z79COSCod, T00242_A79COSCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"COSCod");
                  GXUtil.WriteLogRaw("Old: ",Z79COSCod);
                  GXUtil.WriteLogRaw("Current: ",T00242_A79COSCod[0]);
               }
               if ( StringUtil.StrCmp(Z132VouDTipCod, T00242_A132VouDTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z132VouDTipCod);
                  GXUtil.WriteLogRaw("Current: ",T00242_A132VouDTipCod[0]);
               }
               if ( Z131VouDMon != T00242_A131VouDMon[0] )
               {
                  GXUtil.WriteLog("cbvoucherdet:[seudo value changed for attri]"+"VouDMon");
                  GXUtil.WriteLogRaw("Old: ",Z131VouDMon);
                  GXUtil.WriteLogRaw("Current: ",T00242_A131VouDMon[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBVOUCHERDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2473( )
      {
         BeforeValidate2473( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2473( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2473( 0) ;
            CheckOptimisticConcurrency2473( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2473( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2473( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002418 */
                     pr_default.execute(16, new Object[] {A130VouDSec, A135VouDFec, A2053VouDDoc, A2054VouDGls, A2069VouDTcmb, A2052VouDDebO, A2056VouDHabO, A2051VouDDeb, A2055VouDHab, A136VouReg, A134CueAuxCod, A133CueCodAux, A2076VouMovAdic, A2070VouDUsuCodC, A2072VouDUsuFecC, A2071VouDUsuCodM, A2073VouDUsuFecM, A2058VouDProdCod, A2057VouDordCod, A2050VouDCant, A2059VouDRef1, A2061VouDRef2, A2062VouDRef3, A2063VouDRef4, A2064VouDRef5, A2065VouDRef6, A2066VouDRef7, A2067VouDRef8, A2068VouDRef9, A2060VouDRef10, A127VouAno, A128VouMes, A126TASICod, A129VouNum, A91CueCod, n79COSCod, A79COSCod, A132VouDTipCod, A131VouDMon});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CBVOUCHERDET");
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
                           ResetCaption240( ) ;
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
               Load2473( ) ;
            }
            EndLevel2473( ) ;
         }
         CloseExtendedTableCursors2473( ) ;
      }

      protected void Update2473( )
      {
         BeforeValidate2473( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2473( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2473( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2473( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2473( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002419 */
                     pr_default.execute(17, new Object[] {A135VouDFec, A2053VouDDoc, A2054VouDGls, A2069VouDTcmb, A2052VouDDebO, A2056VouDHabO, A2051VouDDeb, A2055VouDHab, A136VouReg, A134CueAuxCod, A133CueCodAux, A2076VouMovAdic, A2070VouDUsuCodC, A2072VouDUsuFecC, A2071VouDUsuCodM, A2073VouDUsuFecM, A2058VouDProdCod, A2057VouDordCod, A2050VouDCant, A2059VouDRef1, A2061VouDRef2, A2062VouDRef3, A2063VouDRef4, A2064VouDRef5, A2065VouDRef6, A2066VouDRef7, A2067VouDRef8, A2068VouDRef9, A2060VouDRef10, A91CueCod, n79COSCod, A79COSCod, A132VouDTipCod, A131VouDMon, A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CBVOUCHERDET");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBVOUCHERDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2473( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption240( ) ;
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
            EndLevel2473( ) ;
         }
         CloseExtendedTableCursors2473( ) ;
      }

      protected void DeferredUpdate2473( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2473( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2473( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2473( ) ;
            AfterConfirm2473( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2473( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002420 */
                  pr_default.execute(18, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, A130VouDSec});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CBVOUCHERDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound73 == 0 )
                        {
                           InitAll2473( ) ;
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
                        ResetCaption240( ) ;
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2473( ) ;
         Gx_mode = sMode73;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2473( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2473( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2473( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbvoucherdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues240( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbvoucherdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2473( )
      {
         /* Using cursor T002421 */
         pr_default.execute(19);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound73 = 1;
            A127VouAno = T002421_A127VouAno[0];
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = T002421_A128VouMes[0];
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = T002421_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = T002421_A129VouNum[0];
            AssignAttri("", false, "A129VouNum", A129VouNum);
            A130VouDSec = T002421_A130VouDSec[0];
            AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2473( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound73 = 1;
            A127VouAno = T002421_A127VouAno[0];
            AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
            A128VouMes = T002421_A128VouMes[0];
            AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
            A126TASICod = T002421_A126TASICod[0];
            AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
            A129VouNum = T002421_A129VouNum[0];
            AssignAttri("", false, "A129VouNum", A129VouNum);
            A130VouDSec = T002421_A130VouDSec[0];
            AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
         }
      }

      protected void ScanEnd2473( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm2473( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2473( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2473( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2473( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2473( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2473( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2473( )
      {
         edtVouAno_Enabled = 0;
         AssignProp("", false, edtVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouAno_Enabled), 5, 0), true);
         edtVouMes_Enabled = 0;
         AssignProp("", false, edtVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouMes_Enabled), 5, 0), true);
         edtTASICod_Enabled = 0;
         AssignProp("", false, edtTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTASICod_Enabled), 5, 0), true);
         edtVouNum_Enabled = 0;
         AssignProp("", false, edtVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouNum_Enabled), 5, 0), true);
         edtVouDSec_Enabled = 0;
         AssignProp("", false, edtVouDSec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDSec_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtCOSCod_Enabled = 0;
         AssignProp("", false, edtCOSCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCOSCod_Enabled), 5, 0), true);
         edtVouDFec_Enabled = 0;
         AssignProp("", false, edtVouDFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDFec_Enabled), 5, 0), true);
         edtVouDTipCod_Enabled = 0;
         AssignProp("", false, edtVouDTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDTipCod_Enabled), 5, 0), true);
         edtVouDDoc_Enabled = 0;
         AssignProp("", false, edtVouDDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDDoc_Enabled), 5, 0), true);
         edtVouDGls_Enabled = 0;
         AssignProp("", false, edtVouDGls_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDGls_Enabled), 5, 0), true);
         edtVouDMon_Enabled = 0;
         AssignProp("", false, edtVouDMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDMon_Enabled), 5, 0), true);
         edtVouDTcmb_Enabled = 0;
         AssignProp("", false, edtVouDTcmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDTcmb_Enabled), 5, 0), true);
         edtVouDDebO_Enabled = 0;
         AssignProp("", false, edtVouDDebO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDDebO_Enabled), 5, 0), true);
         edtVouDHabO_Enabled = 0;
         AssignProp("", false, edtVouDHabO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDHabO_Enabled), 5, 0), true);
         edtVouDDeb_Enabled = 0;
         AssignProp("", false, edtVouDDeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDDeb_Enabled), 5, 0), true);
         edtVouDHab_Enabled = 0;
         AssignProp("", false, edtVouDHab_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDHab_Enabled), 5, 0), true);
         edtVouReg_Enabled = 0;
         AssignProp("", false, edtVouReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouReg_Enabled), 5, 0), true);
         edtCueAuxCod_Enabled = 0;
         AssignProp("", false, edtCueAuxCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueAuxCod_Enabled), 5, 0), true);
         edtCueCodAux_Enabled = 0;
         AssignProp("", false, edtCueCodAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCodAux_Enabled), 5, 0), true);
         edtVouMovAdic_Enabled = 0;
         AssignProp("", false, edtVouMovAdic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouMovAdic_Enabled), 5, 0), true);
         edtVouDUsuCodC_Enabled = 0;
         AssignProp("", false, edtVouDUsuCodC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDUsuCodC_Enabled), 5, 0), true);
         edtVouDUsuFecC_Enabled = 0;
         AssignProp("", false, edtVouDUsuFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDUsuFecC_Enabled), 5, 0), true);
         edtVouDUsuCodM_Enabled = 0;
         AssignProp("", false, edtVouDUsuCodM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDUsuCodM_Enabled), 5, 0), true);
         edtVouDUsuFecM_Enabled = 0;
         AssignProp("", false, edtVouDUsuFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDUsuFecM_Enabled), 5, 0), true);
         edtVouDProdCod_Enabled = 0;
         AssignProp("", false, edtVouDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDProdCod_Enabled), 5, 0), true);
         edtVouDordCod_Enabled = 0;
         AssignProp("", false, edtVouDordCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDordCod_Enabled), 5, 0), true);
         edtVouDCant_Enabled = 0;
         AssignProp("", false, edtVouDCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVouDCant_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2473( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues240( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816423760", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbvoucherdet.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CBVOUCHERDET");
         forbiddenHiddens.Add("VouDRef1", StringUtil.RTrim( context.localUtil.Format( A2059VouDRef1, "")));
         forbiddenHiddens.Add("VouDRef2", StringUtil.RTrim( context.localUtil.Format( A2061VouDRef2, "")));
         forbiddenHiddens.Add("VouDRef3", StringUtil.RTrim( context.localUtil.Format( A2062VouDRef3, "")));
         forbiddenHiddens.Add("VouDRef4", StringUtil.RTrim( context.localUtil.Format( A2063VouDRef4, "")));
         forbiddenHiddens.Add("VouDRef5", StringUtil.RTrim( context.localUtil.Format( A2064VouDRef5, "")));
         forbiddenHiddens.Add("VouDRef6", StringUtil.RTrim( context.localUtil.Format( A2065VouDRef6, "")));
         forbiddenHiddens.Add("VouDRef7", StringUtil.RTrim( context.localUtil.Format( A2066VouDRef7, "")));
         forbiddenHiddens.Add("VouDRef8", StringUtil.RTrim( context.localUtil.Format( A2067VouDRef8, "")));
         forbiddenHiddens.Add("VouDRef9", StringUtil.RTrim( context.localUtil.Format( A2068VouDRef9, "")));
         forbiddenHiddens.Add("VouDRef10", StringUtil.RTrim( context.localUtil.Format( A2060VouDRef10, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cbvoucherdet:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
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
         GxWebStd.gx_hidden_field( context, "Z130VouDSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z130VouDSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z135VouDFec", context.localUtil.DToC( Z135VouDFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2053VouDDoc", StringUtil.RTrim( Z2053VouDDoc));
         GxWebStd.gx_hidden_field( context, "Z2054VouDGls", StringUtil.RTrim( Z2054VouDGls));
         GxWebStd.gx_hidden_field( context, "Z2069VouDTcmb", StringUtil.LTrim( StringUtil.NToC( Z2069VouDTcmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2052VouDDebO", StringUtil.LTrim( StringUtil.NToC( Z2052VouDDebO, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2056VouDHabO", StringUtil.LTrim( StringUtil.NToC( Z2056VouDHabO, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2051VouDDeb", StringUtil.LTrim( StringUtil.NToC( Z2051VouDDeb, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2055VouDHab", StringUtil.LTrim( StringUtil.NToC( Z2055VouDHab, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z136VouReg", StringUtil.RTrim( Z136VouReg));
         GxWebStd.gx_hidden_field( context, "Z134CueAuxCod", StringUtil.RTrim( Z134CueAuxCod));
         GxWebStd.gx_hidden_field( context, "Z133CueCodAux", StringUtil.RTrim( Z133CueCodAux));
         GxWebStd.gx_hidden_field( context, "Z2076VouMovAdic", StringUtil.RTrim( Z2076VouMovAdic));
         GxWebStd.gx_hidden_field( context, "Z2070VouDUsuCodC", StringUtil.RTrim( Z2070VouDUsuCodC));
         GxWebStd.gx_hidden_field( context, "Z2072VouDUsuFecC", context.localUtil.TToC( Z2072VouDUsuFecC, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2071VouDUsuCodM", StringUtil.RTrim( Z2071VouDUsuCodM));
         GxWebStd.gx_hidden_field( context, "Z2073VouDUsuFecM", context.localUtil.TToC( Z2073VouDUsuFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2058VouDProdCod", StringUtil.RTrim( Z2058VouDProdCod));
         GxWebStd.gx_hidden_field( context, "Z2057VouDordCod", StringUtil.RTrim( Z2057VouDordCod));
         GxWebStd.gx_hidden_field( context, "Z2050VouDCant", StringUtil.LTrim( StringUtil.NToC( Z2050VouDCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2059VouDRef1", Z2059VouDRef1);
         GxWebStd.gx_hidden_field( context, "Z2061VouDRef2", Z2061VouDRef2);
         GxWebStd.gx_hidden_field( context, "Z2062VouDRef3", Z2062VouDRef3);
         GxWebStd.gx_hidden_field( context, "Z2063VouDRef4", Z2063VouDRef4);
         GxWebStd.gx_hidden_field( context, "Z2064VouDRef5", Z2064VouDRef5);
         GxWebStd.gx_hidden_field( context, "Z2065VouDRef6", Z2065VouDRef6);
         GxWebStd.gx_hidden_field( context, "Z2066VouDRef7", Z2066VouDRef7);
         GxWebStd.gx_hidden_field( context, "Z2067VouDRef8", Z2067VouDRef8);
         GxWebStd.gx_hidden_field( context, "Z2068VouDRef9", Z2068VouDRef9);
         GxWebStd.gx_hidden_field( context, "Z2060VouDRef10", Z2060VouDRef10);
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z132VouDTipCod", StringUtil.RTrim( Z132VouDTipCod));
         GxWebStd.gx_hidden_field( context, "Z131VouDMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131VouDMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "VOUDREF1", A2059VouDRef1);
         GxWebStd.gx_hidden_field( context, "VOUDREF2", A2061VouDRef2);
         GxWebStd.gx_hidden_field( context, "VOUDREF3", A2062VouDRef3);
         GxWebStd.gx_hidden_field( context, "VOUDREF4", A2063VouDRef4);
         GxWebStd.gx_hidden_field( context, "VOUDREF5", A2064VouDRef5);
         GxWebStd.gx_hidden_field( context, "VOUDREF6", A2065VouDRef6);
         GxWebStd.gx_hidden_field( context, "VOUDREF7", A2066VouDRef7);
         GxWebStd.gx_hidden_field( context, "VOUDREF8", A2067VouDRef8);
         GxWebStd.gx_hidden_field( context, "VOUDREF9", A2068VouDRef9);
         GxWebStd.gx_hidden_field( context, "VOUDREF10", A2060VouDRef10);
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
         return formatLink("cbvoucherdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBVOUCHERDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Asientos Contables - Detalles" ;
      }

      protected void InitializeNonKey2473( )
      {
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         A79COSCod = "";
         n79COSCod = false;
         AssignAttri("", false, "A79COSCod", A79COSCod);
         A135VouDFec = DateTime.MinValue;
         AssignAttri("", false, "A135VouDFec", context.localUtil.Format(A135VouDFec, "99/99/99"));
         A132VouDTipCod = "";
         AssignAttri("", false, "A132VouDTipCod", A132VouDTipCod);
         A2053VouDDoc = "";
         AssignAttri("", false, "A2053VouDDoc", A2053VouDDoc);
         A2054VouDGls = "";
         AssignAttri("", false, "A2054VouDGls", A2054VouDGls);
         A131VouDMon = 0;
         AssignAttri("", false, "A131VouDMon", StringUtil.LTrimStr( (decimal)(A131VouDMon), 6, 0));
         A2069VouDTcmb = 0;
         AssignAttri("", false, "A2069VouDTcmb", StringUtil.LTrimStr( A2069VouDTcmb, 15, 5));
         A2052VouDDebO = 0;
         AssignAttri("", false, "A2052VouDDebO", StringUtil.LTrimStr( A2052VouDDebO, 15, 2));
         A2056VouDHabO = 0;
         AssignAttri("", false, "A2056VouDHabO", StringUtil.LTrimStr( A2056VouDHabO, 15, 2));
         A2051VouDDeb = 0;
         AssignAttri("", false, "A2051VouDDeb", StringUtil.LTrimStr( A2051VouDDeb, 15, 2));
         A2055VouDHab = 0;
         AssignAttri("", false, "A2055VouDHab", StringUtil.LTrimStr( A2055VouDHab, 15, 2));
         A136VouReg = "";
         AssignAttri("", false, "A136VouReg", A136VouReg);
         A134CueAuxCod = "";
         AssignAttri("", false, "A134CueAuxCod", A134CueAuxCod);
         A133CueCodAux = "";
         AssignAttri("", false, "A133CueCodAux", A133CueCodAux);
         A2076VouMovAdic = "";
         AssignAttri("", false, "A2076VouMovAdic", A2076VouMovAdic);
         A2070VouDUsuCodC = "";
         AssignAttri("", false, "A2070VouDUsuCodC", A2070VouDUsuCodC);
         A2072VouDUsuFecC = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2072VouDUsuFecC", context.localUtil.TToC( A2072VouDUsuFecC, 8, 5, 0, 3, "/", ":", " "));
         A2071VouDUsuCodM = "";
         AssignAttri("", false, "A2071VouDUsuCodM", A2071VouDUsuCodM);
         A2073VouDUsuFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2073VouDUsuFecM", context.localUtil.TToC( A2073VouDUsuFecM, 8, 5, 0, 3, "/", ":", " "));
         A2058VouDProdCod = "";
         AssignAttri("", false, "A2058VouDProdCod", A2058VouDProdCod);
         A2057VouDordCod = "";
         AssignAttri("", false, "A2057VouDordCod", A2057VouDordCod);
         A2050VouDCant = 0;
         AssignAttri("", false, "A2050VouDCant", StringUtil.LTrimStr( A2050VouDCant, 15, 4));
         A2059VouDRef1 = "";
         AssignAttri("", false, "A2059VouDRef1", A2059VouDRef1);
         A2061VouDRef2 = "";
         AssignAttri("", false, "A2061VouDRef2", A2061VouDRef2);
         A2062VouDRef3 = "";
         AssignAttri("", false, "A2062VouDRef3", A2062VouDRef3);
         A2063VouDRef4 = "";
         AssignAttri("", false, "A2063VouDRef4", A2063VouDRef4);
         A2064VouDRef5 = "";
         AssignAttri("", false, "A2064VouDRef5", A2064VouDRef5);
         A2065VouDRef6 = "";
         AssignAttri("", false, "A2065VouDRef6", A2065VouDRef6);
         A2066VouDRef7 = "";
         AssignAttri("", false, "A2066VouDRef7", A2066VouDRef7);
         A2067VouDRef8 = "";
         AssignAttri("", false, "A2067VouDRef8", A2067VouDRef8);
         A2068VouDRef9 = "";
         AssignAttri("", false, "A2068VouDRef9", A2068VouDRef9);
         A2060VouDRef10 = "";
         AssignAttri("", false, "A2060VouDRef10", A2060VouDRef10);
         Z135VouDFec = DateTime.MinValue;
         Z2053VouDDoc = "";
         Z2054VouDGls = "";
         Z2069VouDTcmb = 0;
         Z2052VouDDebO = 0;
         Z2056VouDHabO = 0;
         Z2051VouDDeb = 0;
         Z2055VouDHab = 0;
         Z136VouReg = "";
         Z134CueAuxCod = "";
         Z133CueCodAux = "";
         Z2076VouMovAdic = "";
         Z2070VouDUsuCodC = "";
         Z2072VouDUsuFecC = (DateTime)(DateTime.MinValue);
         Z2071VouDUsuCodM = "";
         Z2073VouDUsuFecM = (DateTime)(DateTime.MinValue);
         Z2058VouDProdCod = "";
         Z2057VouDordCod = "";
         Z2050VouDCant = 0;
         Z2059VouDRef1 = "";
         Z2061VouDRef2 = "";
         Z2062VouDRef3 = "";
         Z2063VouDRef4 = "";
         Z2064VouDRef5 = "";
         Z2065VouDRef6 = "";
         Z2066VouDRef7 = "";
         Z2067VouDRef8 = "";
         Z2068VouDRef9 = "";
         Z2060VouDRef10 = "";
         Z91CueCod = "";
         Z79COSCod = "";
         Z132VouDTipCod = "";
         Z131VouDMon = 0;
      }

      protected void InitAll2473( )
      {
         A127VouAno = 0;
         AssignAttri("", false, "A127VouAno", StringUtil.LTrimStr( (decimal)(A127VouAno), 4, 0));
         A128VouMes = 0;
         AssignAttri("", false, "A128VouMes", StringUtil.LTrimStr( (decimal)(A128VouMes), 2, 0));
         A126TASICod = 0;
         AssignAttri("", false, "A126TASICod", StringUtil.LTrimStr( (decimal)(A126TASICod), 6, 0));
         A129VouNum = "";
         AssignAttri("", false, "A129VouNum", A129VouNum);
         A130VouDSec = 0;
         AssignAttri("", false, "A130VouDSec", StringUtil.LTrimStr( (decimal)(A130VouDSec), 6, 0));
         InitializeNonKey2473( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181642384", true, true);
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
         context.AddJavascriptSource("cbvoucherdet.js", "?20228181642385", false, true);
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
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtVouDSec_Internalname = "VOUDSEC";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCueCod_Internalname = "CUECOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCOSCod_Internalname = "COSCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtVouDFec_Internalname = "VOUDFEC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtVouDTipCod_Internalname = "VOUDTIPCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtVouDDoc_Internalname = "VOUDDOC";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtVouDGls_Internalname = "VOUDGLS";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtVouDMon_Internalname = "VOUDMON";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtVouDTcmb_Internalname = "VOUDTCMB";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtVouDDebO_Internalname = "VOUDDEBO";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtVouDHabO_Internalname = "VOUDHABO";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtVouDDeb_Internalname = "VOUDDEB";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtVouDHab_Internalname = "VOUDHAB";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtVouReg_Internalname = "VOUREG";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtCueAuxCod_Internalname = "CUEAUXCOD";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtCueCodAux_Internalname = "CUECODAUX";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtVouMovAdic_Internalname = "VOUMOVADIC";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtVouDUsuCodC_Internalname = "VOUDUSUCODC";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtVouDUsuFecC_Internalname = "VOUDUSUFECC";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtVouDUsuCodM_Internalname = "VOUDUSUCODM";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtVouDUsuFecM_Internalname = "VOUDUSUFECM";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtVouDProdCod_Internalname = "VOUDPRODCOD";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtVouDordCod_Internalname = "VOUDORDCOD";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtVouDCant_Internalname = "VOUDCANT";
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
         Form.Caption = "Asientos Contables - Detalles";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVouDCant_Jsonclick = "";
         edtVouDCant_Enabled = 1;
         edtVouDordCod_Jsonclick = "";
         edtVouDordCod_Enabled = 1;
         edtVouDProdCod_Jsonclick = "";
         edtVouDProdCod_Enabled = 1;
         edtVouDUsuFecM_Jsonclick = "";
         edtVouDUsuFecM_Enabled = 1;
         edtVouDUsuCodM_Jsonclick = "";
         edtVouDUsuCodM_Enabled = 1;
         edtVouDUsuFecC_Jsonclick = "";
         edtVouDUsuFecC_Enabled = 1;
         edtVouDUsuCodC_Jsonclick = "";
         edtVouDUsuCodC_Enabled = 1;
         edtVouMovAdic_Jsonclick = "";
         edtVouMovAdic_Enabled = 1;
         edtCueCodAux_Jsonclick = "";
         edtCueCodAux_Enabled = 1;
         edtCueAuxCod_Jsonclick = "";
         edtCueAuxCod_Enabled = 1;
         edtVouReg_Jsonclick = "";
         edtVouReg_Enabled = 1;
         edtVouDHab_Jsonclick = "";
         edtVouDHab_Enabled = 1;
         edtVouDDeb_Jsonclick = "";
         edtVouDDeb_Enabled = 1;
         edtVouDHabO_Jsonclick = "";
         edtVouDHabO_Enabled = 1;
         edtVouDDebO_Jsonclick = "";
         edtVouDDebO_Enabled = 1;
         edtVouDTcmb_Jsonclick = "";
         edtVouDTcmb_Enabled = 1;
         edtVouDMon_Jsonclick = "";
         edtVouDMon_Enabled = 1;
         edtVouDGls_Jsonclick = "";
         edtVouDGls_Enabled = 1;
         edtVouDDoc_Jsonclick = "";
         edtVouDDoc_Enabled = 1;
         edtVouDTipCod_Jsonclick = "";
         edtVouDTipCod_Enabled = 1;
         edtVouDFec_Jsonclick = "";
         edtVouDFec_Enabled = 1;
         edtCOSCod_Jsonclick = "";
         edtCOSCod_Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtVouDSec_Jsonclick = "";
         edtVouDSec_Enabled = 1;
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
         /* Using cursor T002422 */
         pr_default.execute(20, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Asiento Contable'.", "ForeignKeyNotFound", 1, "VOUNUM");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
         GX_FocusControl = edtCueCod_Internalname;
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

      public void Valid_Vounum( )
      {
         /* Using cursor T002422 */
         pr_default.execute(20, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Asiento Contable'.", "ForeignKeyNotFound", 1, "VOUNUM");
            AnyError = 1;
            GX_FocusControl = edtVouAno_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Voudsec( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A91CueCod", StringUtil.RTrim( A91CueCod));
         AssignAttri("", false, "A79COSCod", StringUtil.RTrim( A79COSCod));
         AssignAttri("", false, "A135VouDFec", context.localUtil.Format(A135VouDFec, "99/99/99"));
         AssignAttri("", false, "A132VouDTipCod", StringUtil.RTrim( A132VouDTipCod));
         AssignAttri("", false, "A2053VouDDoc", StringUtil.RTrim( A2053VouDDoc));
         AssignAttri("", false, "A2054VouDGls", StringUtil.RTrim( A2054VouDGls));
         AssignAttri("", false, "A131VouDMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131VouDMon), 6, 0, ".", "")));
         AssignAttri("", false, "A2069VouDTcmb", StringUtil.LTrim( StringUtil.NToC( A2069VouDTcmb, 15, 5, ".", "")));
         AssignAttri("", false, "A2052VouDDebO", StringUtil.LTrim( StringUtil.NToC( A2052VouDDebO, 15, 2, ".", "")));
         AssignAttri("", false, "A2056VouDHabO", StringUtil.LTrim( StringUtil.NToC( A2056VouDHabO, 15, 2, ".", "")));
         AssignAttri("", false, "A2051VouDDeb", StringUtil.LTrim( StringUtil.NToC( A2051VouDDeb, 15, 2, ".", "")));
         AssignAttri("", false, "A2055VouDHab", StringUtil.LTrim( StringUtil.NToC( A2055VouDHab, 15, 2, ".", "")));
         AssignAttri("", false, "A136VouReg", StringUtil.RTrim( A136VouReg));
         AssignAttri("", false, "A134CueAuxCod", StringUtil.RTrim( A134CueAuxCod));
         AssignAttri("", false, "A133CueCodAux", StringUtil.RTrim( A133CueCodAux));
         AssignAttri("", false, "A2076VouMovAdic", StringUtil.RTrim( A2076VouMovAdic));
         AssignAttri("", false, "A2070VouDUsuCodC", StringUtil.RTrim( A2070VouDUsuCodC));
         AssignAttri("", false, "A2072VouDUsuFecC", context.localUtil.TToC( A2072VouDUsuFecC, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A2071VouDUsuCodM", StringUtil.RTrim( A2071VouDUsuCodM));
         AssignAttri("", false, "A2073VouDUsuFecM", context.localUtil.TToC( A2073VouDUsuFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A2058VouDProdCod", StringUtil.RTrim( A2058VouDProdCod));
         AssignAttri("", false, "A2057VouDordCod", StringUtil.RTrim( A2057VouDordCod));
         AssignAttri("", false, "A2050VouDCant", StringUtil.LTrim( StringUtil.NToC( A2050VouDCant, 15, 4, ".", "")));
         AssignAttri("", false, "A2059VouDRef1", A2059VouDRef1);
         AssignAttri("", false, "A2061VouDRef2", A2061VouDRef2);
         AssignAttri("", false, "A2062VouDRef3", A2062VouDRef3);
         AssignAttri("", false, "A2063VouDRef4", A2063VouDRef4);
         AssignAttri("", false, "A2064VouDRef5", A2064VouDRef5);
         AssignAttri("", false, "A2065VouDRef6", A2065VouDRef6);
         AssignAttri("", false, "A2066VouDRef7", A2066VouDRef7);
         AssignAttri("", false, "A2067VouDRef8", A2067VouDRef8);
         AssignAttri("", false, "A2068VouDRef9", A2068VouDRef9);
         AssignAttri("", false, "A2060VouDRef10", A2060VouDRef10);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z127VouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127VouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z128VouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128VouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z126TASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126TASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z129VouNum", StringUtil.RTrim( Z129VouNum));
         GxWebStd.gx_hidden_field( context, "Z130VouDSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z130VouDSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z79COSCod", StringUtil.RTrim( Z79COSCod));
         GxWebStd.gx_hidden_field( context, "Z135VouDFec", context.localUtil.Format(Z135VouDFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z132VouDTipCod", StringUtil.RTrim( Z132VouDTipCod));
         GxWebStd.gx_hidden_field( context, "Z2053VouDDoc", StringUtil.RTrim( Z2053VouDDoc));
         GxWebStd.gx_hidden_field( context, "Z2054VouDGls", StringUtil.RTrim( Z2054VouDGls));
         GxWebStd.gx_hidden_field( context, "Z131VouDMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131VouDMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2069VouDTcmb", StringUtil.LTrim( StringUtil.NToC( Z2069VouDTcmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2052VouDDebO", StringUtil.LTrim( StringUtil.NToC( Z2052VouDDebO, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2056VouDHabO", StringUtil.LTrim( StringUtil.NToC( Z2056VouDHabO, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2051VouDDeb", StringUtil.LTrim( StringUtil.NToC( Z2051VouDDeb, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2055VouDHab", StringUtil.LTrim( StringUtil.NToC( Z2055VouDHab, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z136VouReg", StringUtil.RTrim( Z136VouReg));
         GxWebStd.gx_hidden_field( context, "Z134CueAuxCod", StringUtil.RTrim( Z134CueAuxCod));
         GxWebStd.gx_hidden_field( context, "Z133CueCodAux", StringUtil.RTrim( Z133CueCodAux));
         GxWebStd.gx_hidden_field( context, "Z2076VouMovAdic", StringUtil.RTrim( Z2076VouMovAdic));
         GxWebStd.gx_hidden_field( context, "Z2070VouDUsuCodC", StringUtil.RTrim( Z2070VouDUsuCodC));
         GxWebStd.gx_hidden_field( context, "Z2072VouDUsuFecC", context.localUtil.TToC( Z2072VouDUsuFecC, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2071VouDUsuCodM", StringUtil.RTrim( Z2071VouDUsuCodM));
         GxWebStd.gx_hidden_field( context, "Z2073VouDUsuFecM", context.localUtil.TToC( Z2073VouDUsuFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2058VouDProdCod", StringUtil.RTrim( Z2058VouDProdCod));
         GxWebStd.gx_hidden_field( context, "Z2057VouDordCod", StringUtil.RTrim( Z2057VouDordCod));
         GxWebStd.gx_hidden_field( context, "Z2050VouDCant", StringUtil.LTrim( StringUtil.NToC( Z2050VouDCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2059VouDRef1", Z2059VouDRef1);
         GxWebStd.gx_hidden_field( context, "Z2061VouDRef2", Z2061VouDRef2);
         GxWebStd.gx_hidden_field( context, "Z2062VouDRef3", Z2062VouDRef3);
         GxWebStd.gx_hidden_field( context, "Z2063VouDRef4", Z2063VouDRef4);
         GxWebStd.gx_hidden_field( context, "Z2064VouDRef5", Z2064VouDRef5);
         GxWebStd.gx_hidden_field( context, "Z2065VouDRef6", Z2065VouDRef6);
         GxWebStd.gx_hidden_field( context, "Z2066VouDRef7", Z2066VouDRef7);
         GxWebStd.gx_hidden_field( context, "Z2067VouDRef8", Z2067VouDRef8);
         GxWebStd.gx_hidden_field( context, "Z2068VouDRef9", Z2068VouDRef9);
         GxWebStd.gx_hidden_field( context, "Z2060VouDRef10", Z2060VouDRef10);
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T002423 */
         pr_default.execute(21, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Coscod( )
      {
         n79COSCod = false;
         /* Using cursor T002424 */
         pr_default.execute(22, new Object[] {n79COSCod, A79COSCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "COSCOD");
               AnyError = 1;
               GX_FocusControl = edtCOSCod_Internalname;
            }
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Voudtipcod( )
      {
         /* Using cursor T002425 */
         pr_default.execute(23, new Object[] {A132VouDTipCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "VOUDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtVouDTipCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Voudmon( )
      {
         /* Using cursor T002426 */
         pr_default.execute(24, new Object[] {A131VouDMon});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "VOUDMON");
            AnyError = 1;
            GX_FocusControl = edtVouDMon_Internalname;
         }
         pr_default.close(24);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A2059VouDRef1',fld:'VOUDREF1',pic:''},{av:'A2061VouDRef2',fld:'VOUDREF2',pic:''},{av:'A2062VouDRef3',fld:'VOUDREF3',pic:''},{av:'A2063VouDRef4',fld:'VOUDREF4',pic:''},{av:'A2064VouDRef5',fld:'VOUDREF5',pic:''},{av:'A2065VouDRef6',fld:'VOUDREF6',pic:''},{av:'A2066VouDRef7',fld:'VOUDREF7',pic:''},{av:'A2067VouDRef8',fld:'VOUDREF8',pic:''},{av:'A2068VouDRef9',fld:'VOUDREF9',pic:''},{av:'A2060VouDRef10',fld:'VOUDREF10',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_VOUANO","{handler:'Valid_Vouano',iparms:[]");
         setEventMetadata("VALID_VOUANO",",oparms:[]}");
         setEventMetadata("VALID_VOUMES","{handler:'Valid_Voumes',iparms:[]");
         setEventMetadata("VALID_VOUMES",",oparms:[]}");
         setEventMetadata("VALID_TASICOD","{handler:'Valid_Tasicod',iparms:[]");
         setEventMetadata("VALID_TASICOD",",oparms:[]}");
         setEventMetadata("VALID_VOUNUM","{handler:'Valid_Vounum',iparms:[{av:'A127VouAno',fld:'VOUANO',pic:'ZZZ9'},{av:'A128VouMes',fld:'VOUMES',pic:'Z9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A129VouNum',fld:'VOUNUM',pic:''}]");
         setEventMetadata("VALID_VOUNUM",",oparms:[]}");
         setEventMetadata("VALID_VOUDSEC","{handler:'Valid_Voudsec',iparms:[{av:'A2060VouDRef10',fld:'VOUDREF10',pic:''},{av:'A2068VouDRef9',fld:'VOUDREF9',pic:''},{av:'A2067VouDRef8',fld:'VOUDREF8',pic:''},{av:'A2066VouDRef7',fld:'VOUDREF7',pic:''},{av:'A2065VouDRef6',fld:'VOUDREF6',pic:''},{av:'A2064VouDRef5',fld:'VOUDREF5',pic:''},{av:'A2063VouDRef4',fld:'VOUDREF4',pic:''},{av:'A2062VouDRef3',fld:'VOUDREF3',pic:''},{av:'A2061VouDRef2',fld:'VOUDREF2',pic:''},{av:'A2059VouDRef1',fld:'VOUDREF1',pic:''},{av:'A127VouAno',fld:'VOUANO',pic:'ZZZ9'},{av:'A128VouMes',fld:'VOUMES',pic:'Z9'},{av:'A126TASICod',fld:'TASICOD',pic:'ZZZZZ9'},{av:'A129VouNum',fld:'VOUNUM',pic:''},{av:'A130VouDSec',fld:'VOUDSEC',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_VOUDSEC",",oparms:[{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A79COSCod',fld:'COSCOD',pic:''},{av:'A135VouDFec',fld:'VOUDFEC',pic:''},{av:'A132VouDTipCod',fld:'VOUDTIPCOD',pic:''},{av:'A2053VouDDoc',fld:'VOUDDOC',pic:''},{av:'A2054VouDGls',fld:'VOUDGLS',pic:''},{av:'A131VouDMon',fld:'VOUDMON',pic:'ZZZZZ9'},{av:'A2069VouDTcmb',fld:'VOUDTCMB',pic:'ZZZZZZZZ9.99999'},{av:'A2052VouDDebO',fld:'VOUDDEBO',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A2056VouDHabO',fld:'VOUDHABO',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A2051VouDDeb',fld:'VOUDDEB',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A2055VouDHab',fld:'VOUDHAB',pic:'ZZZ,ZZZ,ZZ9.99'},{av:'A136VouReg',fld:'VOUREG',pic:''},{av:'A134CueAuxCod',fld:'CUEAUXCOD',pic:''},{av:'A133CueCodAux',fld:'CUECODAUX',pic:''},{av:'A2076VouMovAdic',fld:'VOUMOVADIC',pic:''},{av:'A2070VouDUsuCodC',fld:'VOUDUSUCODC',pic:''},{av:'A2072VouDUsuFecC',fld:'VOUDUSUFECC',pic:'99/99/99 99:99'},{av:'A2071VouDUsuCodM',fld:'VOUDUSUCODM',pic:''},{av:'A2073VouDUsuFecM',fld:'VOUDUSUFECM',pic:'99/99/99 99:99'},{av:'A2058VouDProdCod',fld:'VOUDPRODCOD',pic:''},{av:'A2057VouDordCod',fld:'VOUDORDCOD',pic:''},{av:'A2050VouDCant',fld:'VOUDCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2059VouDRef1',fld:'VOUDREF1',pic:''},{av:'A2061VouDRef2',fld:'VOUDREF2',pic:''},{av:'A2062VouDRef3',fld:'VOUDREF3',pic:''},{av:'A2063VouDRef4',fld:'VOUDREF4',pic:''},{av:'A2064VouDRef5',fld:'VOUDREF5',pic:''},{av:'A2065VouDRef6',fld:'VOUDREF6',pic:''},{av:'A2066VouDRef7',fld:'VOUDREF7',pic:''},{av:'A2067VouDRef8',fld:'VOUDREF8',pic:''},{av:'A2068VouDRef9',fld:'VOUDREF9',pic:''},{av:'A2060VouDRef10',fld:'VOUDREF10',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z127VouAno'},{av:'Z128VouMes'},{av:'Z126TASICod'},{av:'Z129VouNum'},{av:'Z130VouDSec'},{av:'Z91CueCod'},{av:'Z79COSCod'},{av:'Z135VouDFec'},{av:'Z132VouDTipCod'},{av:'Z2053VouDDoc'},{av:'Z2054VouDGls'},{av:'Z131VouDMon'},{av:'Z2069VouDTcmb'},{av:'Z2052VouDDebO'},{av:'Z2056VouDHabO'},{av:'Z2051VouDDeb'},{av:'Z2055VouDHab'},{av:'Z136VouReg'},{av:'Z134CueAuxCod'},{av:'Z133CueCodAux'},{av:'Z2076VouMovAdic'},{av:'Z2070VouDUsuCodC'},{av:'Z2072VouDUsuFecC'},{av:'Z2071VouDUsuCodM'},{av:'Z2073VouDUsuFecM'},{av:'Z2058VouDProdCod'},{av:'Z2057VouDordCod'},{av:'Z2050VouDCant'},{av:'Z2059VouDRef1'},{av:'Z2061VouDRef2'},{av:'Z2062VouDRef3'},{av:'Z2063VouDRef4'},{av:'Z2064VouDRef5'},{av:'Z2065VouDRef6'},{av:'Z2066VouDRef7'},{av:'Z2067VouDRef8'},{av:'Z2068VouDRef9'},{av:'Z2060VouDRef10'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
         setEventMetadata("VALID_COSCOD","{handler:'Valid_Coscod',iparms:[{av:'A79COSCod',fld:'COSCOD',pic:''}]");
         setEventMetadata("VALID_COSCOD",",oparms:[]}");
         setEventMetadata("VALID_VOUDFEC","{handler:'Valid_Voudfec',iparms:[]");
         setEventMetadata("VALID_VOUDFEC",",oparms:[]}");
         setEventMetadata("VALID_VOUDTIPCOD","{handler:'Valid_Voudtipcod',iparms:[{av:'A132VouDTipCod',fld:'VOUDTIPCOD',pic:''}]");
         setEventMetadata("VALID_VOUDTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_VOUDMON","{handler:'Valid_Voudmon',iparms:[{av:'A131VouDMon',fld:'VOUDMON',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_VOUDMON",",oparms:[]}");
         setEventMetadata("VALID_VOUDUSUFECC","{handler:'Valid_Voudusufecc',iparms:[]");
         setEventMetadata("VALID_VOUDUSUFECC",",oparms:[]}");
         setEventMetadata("VALID_VOUDUSUFECM","{handler:'Valid_Voudusufecm',iparms:[]");
         setEventMetadata("VALID_VOUDUSUFECM",",oparms:[]}");
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
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z129VouNum = "";
         Z135VouDFec = DateTime.MinValue;
         Z2053VouDDoc = "";
         Z2054VouDGls = "";
         Z136VouReg = "";
         Z134CueAuxCod = "";
         Z133CueCodAux = "";
         Z2076VouMovAdic = "";
         Z2070VouDUsuCodC = "";
         Z2072VouDUsuFecC = (DateTime)(DateTime.MinValue);
         Z2071VouDUsuCodM = "";
         Z2073VouDUsuFecM = (DateTime)(DateTime.MinValue);
         Z2058VouDProdCod = "";
         Z2057VouDordCod = "";
         Z2059VouDRef1 = "";
         Z2061VouDRef2 = "";
         Z2062VouDRef3 = "";
         Z2063VouDRef4 = "";
         Z2064VouDRef5 = "";
         Z2065VouDRef6 = "";
         Z2066VouDRef7 = "";
         Z2067VouDRef8 = "";
         Z2068VouDRef9 = "";
         Z2060VouDRef10 = "";
         Z91CueCod = "";
         Z79COSCod = "";
         Z132VouDTipCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A129VouNum = "";
         A91CueCod = "";
         A79COSCod = "";
         A132VouDTipCod = "";
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
         lblTextblock8_Jsonclick = "";
         A135VouDFec = DateTime.MinValue;
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A2053VouDDoc = "";
         lblTextblock11_Jsonclick = "";
         A2054VouDGls = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A136VouReg = "";
         lblTextblock19_Jsonclick = "";
         A134CueAuxCod = "";
         lblTextblock20_Jsonclick = "";
         A133CueCodAux = "";
         lblTextblock21_Jsonclick = "";
         A2076VouMovAdic = "";
         lblTextblock22_Jsonclick = "";
         A2070VouDUsuCodC = "";
         lblTextblock23_Jsonclick = "";
         A2072VouDUsuFecC = (DateTime)(DateTime.MinValue);
         lblTextblock24_Jsonclick = "";
         A2071VouDUsuCodM = "";
         lblTextblock25_Jsonclick = "";
         A2073VouDUsuFecM = (DateTime)(DateTime.MinValue);
         lblTextblock26_Jsonclick = "";
         A2058VouDProdCod = "";
         lblTextblock27_Jsonclick = "";
         A2057VouDordCod = "";
         lblTextblock28_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A2059VouDRef1 = "";
         A2061VouDRef2 = "";
         A2062VouDRef3 = "";
         A2063VouDRef4 = "";
         A2064VouDRef5 = "";
         A2065VouDRef6 = "";
         A2066VouDRef7 = "";
         A2067VouDRef8 = "";
         A2068VouDRef9 = "";
         A2060VouDRef10 = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00249_A130VouDSec = new int[1] ;
         T00249_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         T00249_A2053VouDDoc = new string[] {""} ;
         T00249_A2054VouDGls = new string[] {""} ;
         T00249_A2069VouDTcmb = new decimal[1] ;
         T00249_A2052VouDDebO = new decimal[1] ;
         T00249_A2056VouDHabO = new decimal[1] ;
         T00249_A2051VouDDeb = new decimal[1] ;
         T00249_A2055VouDHab = new decimal[1] ;
         T00249_A136VouReg = new string[] {""} ;
         T00249_A134CueAuxCod = new string[] {""} ;
         T00249_A133CueCodAux = new string[] {""} ;
         T00249_A2076VouMovAdic = new string[] {""} ;
         T00249_A2070VouDUsuCodC = new string[] {""} ;
         T00249_A2072VouDUsuFecC = new DateTime[] {DateTime.MinValue} ;
         T00249_A2071VouDUsuCodM = new string[] {""} ;
         T00249_A2073VouDUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T00249_A2058VouDProdCod = new string[] {""} ;
         T00249_A2057VouDordCod = new string[] {""} ;
         T00249_A2050VouDCant = new decimal[1] ;
         T00249_A2059VouDRef1 = new string[] {""} ;
         T00249_A2061VouDRef2 = new string[] {""} ;
         T00249_A2062VouDRef3 = new string[] {""} ;
         T00249_A2063VouDRef4 = new string[] {""} ;
         T00249_A2064VouDRef5 = new string[] {""} ;
         T00249_A2065VouDRef6 = new string[] {""} ;
         T00249_A2066VouDRef7 = new string[] {""} ;
         T00249_A2067VouDRef8 = new string[] {""} ;
         T00249_A2068VouDRef9 = new string[] {""} ;
         T00249_A2060VouDRef10 = new string[] {""} ;
         T00249_A127VouAno = new short[1] ;
         T00249_A128VouMes = new short[1] ;
         T00249_A126TASICod = new int[1] ;
         T00249_A129VouNum = new string[] {""} ;
         T00249_A91CueCod = new string[] {""} ;
         T00249_A79COSCod = new string[] {""} ;
         T00249_n79COSCod = new bool[] {false} ;
         T00249_A132VouDTipCod = new string[] {""} ;
         T00249_A131VouDMon = new int[1] ;
         T00244_A127VouAno = new short[1] ;
         T00245_A91CueCod = new string[] {""} ;
         T00246_A79COSCod = new string[] {""} ;
         T00246_n79COSCod = new bool[] {false} ;
         T00247_A132VouDTipCod = new string[] {""} ;
         T00248_A131VouDMon = new int[1] ;
         T002410_A127VouAno = new short[1] ;
         T002411_A91CueCod = new string[] {""} ;
         T002412_A79COSCod = new string[] {""} ;
         T002412_n79COSCod = new bool[] {false} ;
         T002413_A132VouDTipCod = new string[] {""} ;
         T002414_A131VouDMon = new int[1] ;
         T002415_A127VouAno = new short[1] ;
         T002415_A128VouMes = new short[1] ;
         T002415_A126TASICod = new int[1] ;
         T002415_A129VouNum = new string[] {""} ;
         T002415_A130VouDSec = new int[1] ;
         T00243_A130VouDSec = new int[1] ;
         T00243_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         T00243_A2053VouDDoc = new string[] {""} ;
         T00243_A2054VouDGls = new string[] {""} ;
         T00243_A2069VouDTcmb = new decimal[1] ;
         T00243_A2052VouDDebO = new decimal[1] ;
         T00243_A2056VouDHabO = new decimal[1] ;
         T00243_A2051VouDDeb = new decimal[1] ;
         T00243_A2055VouDHab = new decimal[1] ;
         T00243_A136VouReg = new string[] {""} ;
         T00243_A134CueAuxCod = new string[] {""} ;
         T00243_A133CueCodAux = new string[] {""} ;
         T00243_A2076VouMovAdic = new string[] {""} ;
         T00243_A2070VouDUsuCodC = new string[] {""} ;
         T00243_A2072VouDUsuFecC = new DateTime[] {DateTime.MinValue} ;
         T00243_A2071VouDUsuCodM = new string[] {""} ;
         T00243_A2073VouDUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T00243_A2058VouDProdCod = new string[] {""} ;
         T00243_A2057VouDordCod = new string[] {""} ;
         T00243_A2050VouDCant = new decimal[1] ;
         T00243_A2059VouDRef1 = new string[] {""} ;
         T00243_A2061VouDRef2 = new string[] {""} ;
         T00243_A2062VouDRef3 = new string[] {""} ;
         T00243_A2063VouDRef4 = new string[] {""} ;
         T00243_A2064VouDRef5 = new string[] {""} ;
         T00243_A2065VouDRef6 = new string[] {""} ;
         T00243_A2066VouDRef7 = new string[] {""} ;
         T00243_A2067VouDRef8 = new string[] {""} ;
         T00243_A2068VouDRef9 = new string[] {""} ;
         T00243_A2060VouDRef10 = new string[] {""} ;
         T00243_A127VouAno = new short[1] ;
         T00243_A128VouMes = new short[1] ;
         T00243_A126TASICod = new int[1] ;
         T00243_A129VouNum = new string[] {""} ;
         T00243_A91CueCod = new string[] {""} ;
         T00243_A79COSCod = new string[] {""} ;
         T00243_n79COSCod = new bool[] {false} ;
         T00243_A132VouDTipCod = new string[] {""} ;
         T00243_A131VouDMon = new int[1] ;
         sMode73 = "";
         T002416_A127VouAno = new short[1] ;
         T002416_A128VouMes = new short[1] ;
         T002416_A126TASICod = new int[1] ;
         T002416_A129VouNum = new string[] {""} ;
         T002416_A130VouDSec = new int[1] ;
         T002417_A127VouAno = new short[1] ;
         T002417_A128VouMes = new short[1] ;
         T002417_A126TASICod = new int[1] ;
         T002417_A129VouNum = new string[] {""} ;
         T002417_A130VouDSec = new int[1] ;
         T00242_A130VouDSec = new int[1] ;
         T00242_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         T00242_A2053VouDDoc = new string[] {""} ;
         T00242_A2054VouDGls = new string[] {""} ;
         T00242_A2069VouDTcmb = new decimal[1] ;
         T00242_A2052VouDDebO = new decimal[1] ;
         T00242_A2056VouDHabO = new decimal[1] ;
         T00242_A2051VouDDeb = new decimal[1] ;
         T00242_A2055VouDHab = new decimal[1] ;
         T00242_A136VouReg = new string[] {""} ;
         T00242_A134CueAuxCod = new string[] {""} ;
         T00242_A133CueCodAux = new string[] {""} ;
         T00242_A2076VouMovAdic = new string[] {""} ;
         T00242_A2070VouDUsuCodC = new string[] {""} ;
         T00242_A2072VouDUsuFecC = new DateTime[] {DateTime.MinValue} ;
         T00242_A2071VouDUsuCodM = new string[] {""} ;
         T00242_A2073VouDUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T00242_A2058VouDProdCod = new string[] {""} ;
         T00242_A2057VouDordCod = new string[] {""} ;
         T00242_A2050VouDCant = new decimal[1] ;
         T00242_A2059VouDRef1 = new string[] {""} ;
         T00242_A2061VouDRef2 = new string[] {""} ;
         T00242_A2062VouDRef3 = new string[] {""} ;
         T00242_A2063VouDRef4 = new string[] {""} ;
         T00242_A2064VouDRef5 = new string[] {""} ;
         T00242_A2065VouDRef6 = new string[] {""} ;
         T00242_A2066VouDRef7 = new string[] {""} ;
         T00242_A2067VouDRef8 = new string[] {""} ;
         T00242_A2068VouDRef9 = new string[] {""} ;
         T00242_A2060VouDRef10 = new string[] {""} ;
         T00242_A127VouAno = new short[1] ;
         T00242_A128VouMes = new short[1] ;
         T00242_A126TASICod = new int[1] ;
         T00242_A129VouNum = new string[] {""} ;
         T00242_A91CueCod = new string[] {""} ;
         T00242_A79COSCod = new string[] {""} ;
         T00242_n79COSCod = new bool[] {false} ;
         T00242_A132VouDTipCod = new string[] {""} ;
         T00242_A131VouDMon = new int[1] ;
         T002421_A127VouAno = new short[1] ;
         T002421_A128VouMes = new short[1] ;
         T002421_A126TASICod = new int[1] ;
         T002421_A129VouNum = new string[] {""} ;
         T002421_A130VouDSec = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002422_A127VouAno = new short[1] ;
         ZZ129VouNum = "";
         ZZ91CueCod = "";
         ZZ79COSCod = "";
         ZZ135VouDFec = DateTime.MinValue;
         ZZ132VouDTipCod = "";
         ZZ2053VouDDoc = "";
         ZZ2054VouDGls = "";
         ZZ136VouReg = "";
         ZZ134CueAuxCod = "";
         ZZ133CueCodAux = "";
         ZZ2076VouMovAdic = "";
         ZZ2070VouDUsuCodC = "";
         ZZ2072VouDUsuFecC = (DateTime)(DateTime.MinValue);
         ZZ2071VouDUsuCodM = "";
         ZZ2073VouDUsuFecM = (DateTime)(DateTime.MinValue);
         ZZ2058VouDProdCod = "";
         ZZ2057VouDordCod = "";
         ZZ2059VouDRef1 = "";
         ZZ2061VouDRef2 = "";
         ZZ2062VouDRef3 = "";
         ZZ2063VouDRef4 = "";
         ZZ2064VouDRef5 = "";
         ZZ2065VouDRef6 = "";
         ZZ2066VouDRef7 = "";
         ZZ2067VouDRef8 = "";
         ZZ2068VouDRef9 = "";
         ZZ2060VouDRef10 = "";
         T002423_A91CueCod = new string[] {""} ;
         T002424_A79COSCod = new string[] {""} ;
         T002424_n79COSCod = new bool[] {false} ;
         T002425_A132VouDTipCod = new string[] {""} ;
         T002426_A131VouDMon = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbvoucherdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbvoucherdet__default(),
            new Object[][] {
                new Object[] {
               T00242_A130VouDSec, T00242_A135VouDFec, T00242_A2053VouDDoc, T00242_A2054VouDGls, T00242_A2069VouDTcmb, T00242_A2052VouDDebO, T00242_A2056VouDHabO, T00242_A2051VouDDeb, T00242_A2055VouDHab, T00242_A136VouReg,
               T00242_A134CueAuxCod, T00242_A133CueCodAux, T00242_A2076VouMovAdic, T00242_A2070VouDUsuCodC, T00242_A2072VouDUsuFecC, T00242_A2071VouDUsuCodM, T00242_A2073VouDUsuFecM, T00242_A2058VouDProdCod, T00242_A2057VouDordCod, T00242_A2050VouDCant,
               T00242_A2059VouDRef1, T00242_A2061VouDRef2, T00242_A2062VouDRef3, T00242_A2063VouDRef4, T00242_A2064VouDRef5, T00242_A2065VouDRef6, T00242_A2066VouDRef7, T00242_A2067VouDRef8, T00242_A2068VouDRef9, T00242_A2060VouDRef10,
               T00242_A127VouAno, T00242_A128VouMes, T00242_A126TASICod, T00242_A129VouNum, T00242_A91CueCod, T00242_A79COSCod, T00242_n79COSCod, T00242_A132VouDTipCod, T00242_A131VouDMon
               }
               , new Object[] {
               T00243_A130VouDSec, T00243_A135VouDFec, T00243_A2053VouDDoc, T00243_A2054VouDGls, T00243_A2069VouDTcmb, T00243_A2052VouDDebO, T00243_A2056VouDHabO, T00243_A2051VouDDeb, T00243_A2055VouDHab, T00243_A136VouReg,
               T00243_A134CueAuxCod, T00243_A133CueCodAux, T00243_A2076VouMovAdic, T00243_A2070VouDUsuCodC, T00243_A2072VouDUsuFecC, T00243_A2071VouDUsuCodM, T00243_A2073VouDUsuFecM, T00243_A2058VouDProdCod, T00243_A2057VouDordCod, T00243_A2050VouDCant,
               T00243_A2059VouDRef1, T00243_A2061VouDRef2, T00243_A2062VouDRef3, T00243_A2063VouDRef4, T00243_A2064VouDRef5, T00243_A2065VouDRef6, T00243_A2066VouDRef7, T00243_A2067VouDRef8, T00243_A2068VouDRef9, T00243_A2060VouDRef10,
               T00243_A127VouAno, T00243_A128VouMes, T00243_A126TASICod, T00243_A129VouNum, T00243_A91CueCod, T00243_A79COSCod, T00243_n79COSCod, T00243_A132VouDTipCod, T00243_A131VouDMon
               }
               , new Object[] {
               T00244_A127VouAno
               }
               , new Object[] {
               T00245_A91CueCod
               }
               , new Object[] {
               T00246_A79COSCod
               }
               , new Object[] {
               T00247_A132VouDTipCod
               }
               , new Object[] {
               T00248_A131VouDMon
               }
               , new Object[] {
               T00249_A130VouDSec, T00249_A135VouDFec, T00249_A2053VouDDoc, T00249_A2054VouDGls, T00249_A2069VouDTcmb, T00249_A2052VouDDebO, T00249_A2056VouDHabO, T00249_A2051VouDDeb, T00249_A2055VouDHab, T00249_A136VouReg,
               T00249_A134CueAuxCod, T00249_A133CueCodAux, T00249_A2076VouMovAdic, T00249_A2070VouDUsuCodC, T00249_A2072VouDUsuFecC, T00249_A2071VouDUsuCodM, T00249_A2073VouDUsuFecM, T00249_A2058VouDProdCod, T00249_A2057VouDordCod, T00249_A2050VouDCant,
               T00249_A2059VouDRef1, T00249_A2061VouDRef2, T00249_A2062VouDRef3, T00249_A2063VouDRef4, T00249_A2064VouDRef5, T00249_A2065VouDRef6, T00249_A2066VouDRef7, T00249_A2067VouDRef8, T00249_A2068VouDRef9, T00249_A2060VouDRef10,
               T00249_A127VouAno, T00249_A128VouMes, T00249_A126TASICod, T00249_A129VouNum, T00249_A91CueCod, T00249_A79COSCod, T00249_n79COSCod, T00249_A132VouDTipCod, T00249_A131VouDMon
               }
               , new Object[] {
               T002410_A127VouAno
               }
               , new Object[] {
               T002411_A91CueCod
               }
               , new Object[] {
               T002412_A79COSCod
               }
               , new Object[] {
               T002413_A132VouDTipCod
               }
               , new Object[] {
               T002414_A131VouDMon
               }
               , new Object[] {
               T002415_A127VouAno, T002415_A128VouMes, T002415_A126TASICod, T002415_A129VouNum, T002415_A130VouDSec
               }
               , new Object[] {
               T002416_A127VouAno, T002416_A128VouMes, T002416_A126TASICod, T002416_A129VouNum, T002416_A130VouDSec
               }
               , new Object[] {
               T002417_A127VouAno, T002417_A128VouMes, T002417_A126TASICod, T002417_A129VouNum, T002417_A130VouDSec
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002421_A127VouAno, T002421_A128VouMes, T002421_A126TASICod, T002421_A129VouNum, T002421_A130VouDSec
               }
               , new Object[] {
               T002422_A127VouAno
               }
               , new Object[] {
               T002423_A91CueCod
               }
               , new Object[] {
               T002424_A79COSCod
               }
               , new Object[] {
               T002425_A132VouDTipCod
               }
               , new Object[] {
               T002426_A131VouDMon
               }
            }
         );
      }

      private short Z127VouAno ;
      private short Z128VouMes ;
      private short GxWebError ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound73 ;
      private short nIsDirty_73 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ127VouAno ;
      private short ZZ128VouMes ;
      private int Z126TASICod ;
      private int Z130VouDSec ;
      private int Z131VouDMon ;
      private int A126TASICod ;
      private int A131VouDMon ;
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
      private int A130VouDSec ;
      private int edtVouDSec_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCueCod_Enabled ;
      private int edtCOSCod_Enabled ;
      private int edtVouDFec_Enabled ;
      private int edtVouDTipCod_Enabled ;
      private int edtVouDDoc_Enabled ;
      private int edtVouDGls_Enabled ;
      private int edtVouDMon_Enabled ;
      private int edtVouDTcmb_Enabled ;
      private int edtVouDDebO_Enabled ;
      private int edtVouDHabO_Enabled ;
      private int edtVouDDeb_Enabled ;
      private int edtVouDHab_Enabled ;
      private int edtVouReg_Enabled ;
      private int edtCueAuxCod_Enabled ;
      private int edtCueCodAux_Enabled ;
      private int edtVouMovAdic_Enabled ;
      private int edtVouDUsuCodC_Enabled ;
      private int edtVouDUsuFecC_Enabled ;
      private int edtVouDUsuCodM_Enabled ;
      private int edtVouDUsuFecM_Enabled ;
      private int edtVouDProdCod_Enabled ;
      private int edtVouDordCod_Enabled ;
      private int edtVouDCant_Enabled ;
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
      private int ZZ130VouDSec ;
      private int ZZ131VouDMon ;
      private decimal Z2069VouDTcmb ;
      private decimal Z2052VouDDebO ;
      private decimal Z2056VouDHabO ;
      private decimal Z2051VouDDeb ;
      private decimal Z2055VouDHab ;
      private decimal Z2050VouDCant ;
      private decimal A2069VouDTcmb ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2050VouDCant ;
      private decimal ZZ2069VouDTcmb ;
      private decimal ZZ2052VouDDebO ;
      private decimal ZZ2056VouDHabO ;
      private decimal ZZ2051VouDDeb ;
      private decimal ZZ2055VouDHab ;
      private decimal ZZ2050VouDCant ;
      private string sPrefix ;
      private string Z129VouNum ;
      private string Z2053VouDDoc ;
      private string Z2054VouDGls ;
      private string Z136VouReg ;
      private string Z134CueAuxCod ;
      private string Z133CueCodAux ;
      private string Z2076VouMovAdic ;
      private string Z2070VouDUsuCodC ;
      private string Z2071VouDUsuCodM ;
      private string Z2058VouDProdCod ;
      private string Z2057VouDordCod ;
      private string Z91CueCod ;
      private string Z79COSCod ;
      private string Z132VouDTipCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A129VouNum ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string A132VouDTipCod ;
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
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtVouDSec_Internalname ;
      private string edtVouDSec_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCOSCod_Internalname ;
      private string edtCOSCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtVouDFec_Internalname ;
      private string edtVouDFec_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtVouDTipCod_Internalname ;
      private string edtVouDTipCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtVouDDoc_Internalname ;
      private string A2053VouDDoc ;
      private string edtVouDDoc_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtVouDGls_Internalname ;
      private string A2054VouDGls ;
      private string edtVouDGls_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtVouDMon_Internalname ;
      private string edtVouDMon_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtVouDTcmb_Internalname ;
      private string edtVouDTcmb_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtVouDDebO_Internalname ;
      private string edtVouDDebO_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtVouDHabO_Internalname ;
      private string edtVouDHabO_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtVouDDeb_Internalname ;
      private string edtVouDDeb_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtVouDHab_Internalname ;
      private string edtVouDHab_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtVouReg_Internalname ;
      private string A136VouReg ;
      private string edtVouReg_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtCueAuxCod_Internalname ;
      private string A134CueAuxCod ;
      private string edtCueAuxCod_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtCueCodAux_Internalname ;
      private string A133CueCodAux ;
      private string edtCueCodAux_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtVouMovAdic_Internalname ;
      private string A2076VouMovAdic ;
      private string edtVouMovAdic_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtVouDUsuCodC_Internalname ;
      private string A2070VouDUsuCodC ;
      private string edtVouDUsuCodC_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtVouDUsuFecC_Internalname ;
      private string edtVouDUsuFecC_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtVouDUsuCodM_Internalname ;
      private string A2071VouDUsuCodM ;
      private string edtVouDUsuCodM_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtVouDUsuFecM_Internalname ;
      private string edtVouDUsuFecM_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtVouDProdCod_Internalname ;
      private string A2058VouDProdCod ;
      private string edtVouDProdCod_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtVouDordCod_Internalname ;
      private string A2057VouDordCod ;
      private string edtVouDordCod_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtVouDCant_Internalname ;
      private string edtVouDCant_Jsonclick ;
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
      private string sMode73 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ129VouNum ;
      private string ZZ91CueCod ;
      private string ZZ79COSCod ;
      private string ZZ132VouDTipCod ;
      private string ZZ2053VouDDoc ;
      private string ZZ2054VouDGls ;
      private string ZZ136VouReg ;
      private string ZZ134CueAuxCod ;
      private string ZZ133CueCodAux ;
      private string ZZ2076VouMovAdic ;
      private string ZZ2070VouDUsuCodC ;
      private string ZZ2071VouDUsuCodM ;
      private string ZZ2058VouDProdCod ;
      private string ZZ2057VouDordCod ;
      private DateTime Z2072VouDUsuFecC ;
      private DateTime Z2073VouDUsuFecM ;
      private DateTime A2072VouDUsuFecC ;
      private DateTime A2073VouDUsuFecM ;
      private DateTime ZZ2072VouDUsuFecC ;
      private DateTime ZZ2073VouDUsuFecM ;
      private DateTime Z135VouDFec ;
      private DateTime A135VouDFec ;
      private DateTime ZZ135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n79COSCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2059VouDRef1 ;
      private string Z2061VouDRef2 ;
      private string Z2062VouDRef3 ;
      private string Z2063VouDRef4 ;
      private string Z2064VouDRef5 ;
      private string Z2065VouDRef6 ;
      private string Z2066VouDRef7 ;
      private string Z2067VouDRef8 ;
      private string Z2068VouDRef9 ;
      private string Z2060VouDRef10 ;
      private string A2059VouDRef1 ;
      private string A2061VouDRef2 ;
      private string A2062VouDRef3 ;
      private string A2063VouDRef4 ;
      private string A2064VouDRef5 ;
      private string A2065VouDRef6 ;
      private string A2066VouDRef7 ;
      private string A2067VouDRef8 ;
      private string A2068VouDRef9 ;
      private string A2060VouDRef10 ;
      private string ZZ2059VouDRef1 ;
      private string ZZ2061VouDRef2 ;
      private string ZZ2062VouDRef3 ;
      private string ZZ2063VouDRef4 ;
      private string ZZ2064VouDRef5 ;
      private string ZZ2065VouDRef6 ;
      private string ZZ2066VouDRef7 ;
      private string ZZ2067VouDRef8 ;
      private string ZZ2068VouDRef9 ;
      private string ZZ2060VouDRef10 ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00249_A130VouDSec ;
      private DateTime[] T00249_A135VouDFec ;
      private string[] T00249_A2053VouDDoc ;
      private string[] T00249_A2054VouDGls ;
      private decimal[] T00249_A2069VouDTcmb ;
      private decimal[] T00249_A2052VouDDebO ;
      private decimal[] T00249_A2056VouDHabO ;
      private decimal[] T00249_A2051VouDDeb ;
      private decimal[] T00249_A2055VouDHab ;
      private string[] T00249_A136VouReg ;
      private string[] T00249_A134CueAuxCod ;
      private string[] T00249_A133CueCodAux ;
      private string[] T00249_A2076VouMovAdic ;
      private string[] T00249_A2070VouDUsuCodC ;
      private DateTime[] T00249_A2072VouDUsuFecC ;
      private string[] T00249_A2071VouDUsuCodM ;
      private DateTime[] T00249_A2073VouDUsuFecM ;
      private string[] T00249_A2058VouDProdCod ;
      private string[] T00249_A2057VouDordCod ;
      private decimal[] T00249_A2050VouDCant ;
      private string[] T00249_A2059VouDRef1 ;
      private string[] T00249_A2061VouDRef2 ;
      private string[] T00249_A2062VouDRef3 ;
      private string[] T00249_A2063VouDRef4 ;
      private string[] T00249_A2064VouDRef5 ;
      private string[] T00249_A2065VouDRef6 ;
      private string[] T00249_A2066VouDRef7 ;
      private string[] T00249_A2067VouDRef8 ;
      private string[] T00249_A2068VouDRef9 ;
      private string[] T00249_A2060VouDRef10 ;
      private short[] T00249_A127VouAno ;
      private short[] T00249_A128VouMes ;
      private int[] T00249_A126TASICod ;
      private string[] T00249_A129VouNum ;
      private string[] T00249_A91CueCod ;
      private string[] T00249_A79COSCod ;
      private bool[] T00249_n79COSCod ;
      private string[] T00249_A132VouDTipCod ;
      private int[] T00249_A131VouDMon ;
      private short[] T00244_A127VouAno ;
      private string[] T00245_A91CueCod ;
      private string[] T00246_A79COSCod ;
      private bool[] T00246_n79COSCod ;
      private string[] T00247_A132VouDTipCod ;
      private int[] T00248_A131VouDMon ;
      private short[] T002410_A127VouAno ;
      private string[] T002411_A91CueCod ;
      private string[] T002412_A79COSCod ;
      private bool[] T002412_n79COSCod ;
      private string[] T002413_A132VouDTipCod ;
      private int[] T002414_A131VouDMon ;
      private short[] T002415_A127VouAno ;
      private short[] T002415_A128VouMes ;
      private int[] T002415_A126TASICod ;
      private string[] T002415_A129VouNum ;
      private int[] T002415_A130VouDSec ;
      private int[] T00243_A130VouDSec ;
      private DateTime[] T00243_A135VouDFec ;
      private string[] T00243_A2053VouDDoc ;
      private string[] T00243_A2054VouDGls ;
      private decimal[] T00243_A2069VouDTcmb ;
      private decimal[] T00243_A2052VouDDebO ;
      private decimal[] T00243_A2056VouDHabO ;
      private decimal[] T00243_A2051VouDDeb ;
      private decimal[] T00243_A2055VouDHab ;
      private string[] T00243_A136VouReg ;
      private string[] T00243_A134CueAuxCod ;
      private string[] T00243_A133CueCodAux ;
      private string[] T00243_A2076VouMovAdic ;
      private string[] T00243_A2070VouDUsuCodC ;
      private DateTime[] T00243_A2072VouDUsuFecC ;
      private string[] T00243_A2071VouDUsuCodM ;
      private DateTime[] T00243_A2073VouDUsuFecM ;
      private string[] T00243_A2058VouDProdCod ;
      private string[] T00243_A2057VouDordCod ;
      private decimal[] T00243_A2050VouDCant ;
      private string[] T00243_A2059VouDRef1 ;
      private string[] T00243_A2061VouDRef2 ;
      private string[] T00243_A2062VouDRef3 ;
      private string[] T00243_A2063VouDRef4 ;
      private string[] T00243_A2064VouDRef5 ;
      private string[] T00243_A2065VouDRef6 ;
      private string[] T00243_A2066VouDRef7 ;
      private string[] T00243_A2067VouDRef8 ;
      private string[] T00243_A2068VouDRef9 ;
      private string[] T00243_A2060VouDRef10 ;
      private short[] T00243_A127VouAno ;
      private short[] T00243_A128VouMes ;
      private int[] T00243_A126TASICod ;
      private string[] T00243_A129VouNum ;
      private string[] T00243_A91CueCod ;
      private string[] T00243_A79COSCod ;
      private bool[] T00243_n79COSCod ;
      private string[] T00243_A132VouDTipCod ;
      private int[] T00243_A131VouDMon ;
      private short[] T002416_A127VouAno ;
      private short[] T002416_A128VouMes ;
      private int[] T002416_A126TASICod ;
      private string[] T002416_A129VouNum ;
      private int[] T002416_A130VouDSec ;
      private short[] T002417_A127VouAno ;
      private short[] T002417_A128VouMes ;
      private int[] T002417_A126TASICod ;
      private string[] T002417_A129VouNum ;
      private int[] T002417_A130VouDSec ;
      private int[] T00242_A130VouDSec ;
      private DateTime[] T00242_A135VouDFec ;
      private string[] T00242_A2053VouDDoc ;
      private string[] T00242_A2054VouDGls ;
      private decimal[] T00242_A2069VouDTcmb ;
      private decimal[] T00242_A2052VouDDebO ;
      private decimal[] T00242_A2056VouDHabO ;
      private decimal[] T00242_A2051VouDDeb ;
      private decimal[] T00242_A2055VouDHab ;
      private string[] T00242_A136VouReg ;
      private string[] T00242_A134CueAuxCod ;
      private string[] T00242_A133CueCodAux ;
      private string[] T00242_A2076VouMovAdic ;
      private string[] T00242_A2070VouDUsuCodC ;
      private DateTime[] T00242_A2072VouDUsuFecC ;
      private string[] T00242_A2071VouDUsuCodM ;
      private DateTime[] T00242_A2073VouDUsuFecM ;
      private string[] T00242_A2058VouDProdCod ;
      private string[] T00242_A2057VouDordCod ;
      private decimal[] T00242_A2050VouDCant ;
      private string[] T00242_A2059VouDRef1 ;
      private string[] T00242_A2061VouDRef2 ;
      private string[] T00242_A2062VouDRef3 ;
      private string[] T00242_A2063VouDRef4 ;
      private string[] T00242_A2064VouDRef5 ;
      private string[] T00242_A2065VouDRef6 ;
      private string[] T00242_A2066VouDRef7 ;
      private string[] T00242_A2067VouDRef8 ;
      private string[] T00242_A2068VouDRef9 ;
      private string[] T00242_A2060VouDRef10 ;
      private short[] T00242_A127VouAno ;
      private short[] T00242_A128VouMes ;
      private int[] T00242_A126TASICod ;
      private string[] T00242_A129VouNum ;
      private string[] T00242_A91CueCod ;
      private string[] T00242_A79COSCod ;
      private bool[] T00242_n79COSCod ;
      private string[] T00242_A132VouDTipCod ;
      private int[] T00242_A131VouDMon ;
      private short[] T002421_A127VouAno ;
      private short[] T002421_A128VouMes ;
      private int[] T002421_A126TASICod ;
      private string[] T002421_A129VouNum ;
      private int[] T002421_A130VouDSec ;
      private short[] T002422_A127VouAno ;
      private string[] T002423_A91CueCod ;
      private string[] T002424_A79COSCod ;
      private bool[] T002424_n79COSCod ;
      private string[] T002425_A132VouDTipCod ;
      private int[] T002426_A131VouDMon ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbvoucherdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbvoucherdet__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00249;
        prmT00249 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT00244;
        prmT00244 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT00245;
        prmT00245 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT00246;
        prmT00246 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT00247;
        prmT00247 = new Object[] {
        new ParDef("@VouDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT00248;
        prmT00248 = new Object[] {
        new ParDef("@VouDMon",GXType.Int32,6,0)
        };
        Object[] prmT002410;
        prmT002410 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002411;
        prmT002411 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT002412;
        prmT002412 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT002413;
        prmT002413 = new Object[] {
        new ParDef("@VouDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT002414;
        prmT002414 = new Object[] {
        new ParDef("@VouDMon",GXType.Int32,6,0)
        };
        Object[] prmT002415;
        prmT002415 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT00243;
        prmT00243 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT002416;
        prmT002416 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT002417;
        prmT002417 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT00242;
        prmT00242 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT002418;
        prmT002418 = new Object[] {
        new ParDef("@VouDSec",GXType.Int32,6,0) ,
        new ParDef("@VouDFec",GXType.Date,8,0) ,
        new ParDef("@VouDDoc",GXType.NChar,20,0) ,
        new ParDef("@VouDGls",GXType.NChar,100,0) ,
        new ParDef("@VouDTcmb",GXType.Decimal,15,5) ,
        new ParDef("@VouDDebO",GXType.Decimal,15,2) ,
        new ParDef("@VouDHabO",GXType.Decimal,15,2) ,
        new ParDef("@VouDDeb",GXType.Decimal,15,2) ,
        new ParDef("@VouDHab",GXType.Decimal,15,2) ,
        new ParDef("@VouReg",GXType.NChar,15,0) ,
        new ParDef("@CueAuxCod",GXType.NChar,15,0) ,
        new ParDef("@CueCodAux",GXType.NChar,20,0) ,
        new ParDef("@VouMovAdic",GXType.NChar,1,0) ,
        new ParDef("@VouDUsuCodC",GXType.NChar,10,0) ,
        new ParDef("@VouDUsuFecC",GXType.DateTime,8,5) ,
        new ParDef("@VouDUsuCodM",GXType.NChar,10,0) ,
        new ParDef("@VouDUsuFecM",GXType.DateTime,8,5) ,
        new ParDef("@VouDProdCod",GXType.NChar,15,0) ,
        new ParDef("@VouDordCod",GXType.NChar,10,0) ,
        new ParDef("@VouDCant",GXType.Decimal,15,4) ,
        new ParDef("@VouDRef1",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef2",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef3",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef4",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef5",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef6",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef7",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef8",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef9",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef10",GXType.NVarChar,100,0) ,
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@VouDTipCod",GXType.NChar,3,0) ,
        new ParDef("@VouDMon",GXType.Int32,6,0)
        };
        Object[] prmT002419;
        prmT002419 = new Object[] {
        new ParDef("@VouDFec",GXType.Date,8,0) ,
        new ParDef("@VouDDoc",GXType.NChar,20,0) ,
        new ParDef("@VouDGls",GXType.NChar,100,0) ,
        new ParDef("@VouDTcmb",GXType.Decimal,15,5) ,
        new ParDef("@VouDDebO",GXType.Decimal,15,2) ,
        new ParDef("@VouDHabO",GXType.Decimal,15,2) ,
        new ParDef("@VouDDeb",GXType.Decimal,15,2) ,
        new ParDef("@VouDHab",GXType.Decimal,15,2) ,
        new ParDef("@VouReg",GXType.NChar,15,0) ,
        new ParDef("@CueAuxCod",GXType.NChar,15,0) ,
        new ParDef("@CueCodAux",GXType.NChar,20,0) ,
        new ParDef("@VouMovAdic",GXType.NChar,1,0) ,
        new ParDef("@VouDUsuCodC",GXType.NChar,10,0) ,
        new ParDef("@VouDUsuFecC",GXType.DateTime,8,5) ,
        new ParDef("@VouDUsuCodM",GXType.NChar,10,0) ,
        new ParDef("@VouDUsuFecM",GXType.DateTime,8,5) ,
        new ParDef("@VouDProdCod",GXType.NChar,15,0) ,
        new ParDef("@VouDordCod",GXType.NChar,10,0) ,
        new ParDef("@VouDCant",GXType.Decimal,15,4) ,
        new ParDef("@VouDRef1",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef2",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef3",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef4",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef5",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef6",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef7",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef8",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef9",GXType.NVarChar,100,0) ,
        new ParDef("@VouDRef10",GXType.NVarChar,100,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@VouDTipCod",GXType.NChar,3,0) ,
        new ParDef("@VouDMon",GXType.Int32,6,0) ,
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT002420;
        prmT002420 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0) ,
        new ParDef("@VouDSec",GXType.Int32,6,0)
        };
        Object[] prmT002421;
        prmT002421 = new Object[] {
        };
        Object[] prmT002422;
        prmT002422 = new Object[] {
        new ParDef("@VouAno",GXType.Int16,4,0) ,
        new ParDef("@VouMes",GXType.Int16,2,0) ,
        new ParDef("@TASICod",GXType.Int32,6,0) ,
        new ParDef("@VouNum",GXType.NChar,10,0)
        };
        Object[] prmT002423;
        prmT002423 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT002424;
        prmT002424 = new Object[] {
        new ParDef("@COSCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT002425;
        prmT002425 = new Object[] {
        new ParDef("@VouDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT002426;
        prmT002426 = new Object[] {
        new ParDef("@VouDMon",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00242", "SELECT [VouDSec], [VouDFec], [VouDDoc], [VouDGls], [VouDTcmb], [VouDDebO], [VouDHabO], [VouDDeb], [VouDHab], [VouReg], [CueAuxCod], [CueCodAux], [VouMovAdic], [VouDUsuCodC], [VouDUsuFecC], [VouDUsuCodM], [VouDUsuFecM], [VouDProdCod], [VouDordCod], [VouDCant], [VouDRef1], [VouDRef2], [VouDRef3], [VouDRef4], [VouDRef5], [VouDRef6], [VouDRef7], [VouDRef8], [VouDRef9], [VouDRef10], [VouAno], [VouMes], [TASICod], [VouNum], [CueCod], [COSCod], [VouDTipCod] AS VouDTipCod, [VouDMon] AS VouDMon FROM [CBVOUCHERDET] WITH (UPDLOCK) WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum AND [VouDSec] = @VouDSec ",true, GxErrorMask.GX_NOMASK, false, this,prmT00242,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00243", "SELECT [VouDSec], [VouDFec], [VouDDoc], [VouDGls], [VouDTcmb], [VouDDebO], [VouDHabO], [VouDDeb], [VouDHab], [VouReg], [CueAuxCod], [CueCodAux], [VouMovAdic], [VouDUsuCodC], [VouDUsuFecC], [VouDUsuCodM], [VouDUsuFecM], [VouDProdCod], [VouDordCod], [VouDCant], [VouDRef1], [VouDRef2], [VouDRef3], [VouDRef4], [VouDRef5], [VouDRef6], [VouDRef7], [VouDRef8], [VouDRef9], [VouDRef10], [VouAno], [VouMes], [TASICod], [VouNum], [CueCod], [COSCod], [VouDTipCod] AS VouDTipCod, [VouDMon] AS VouDMon FROM [CBVOUCHERDET] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum AND [VouDSec] = @VouDSec ",true, GxErrorMask.GX_NOMASK, false, this,prmT00243,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00244", "SELECT [VouAno] FROM [CBVOUCHER] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00244,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00245", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00245,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00246", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00246,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00247", "SELECT [TipCod] AS VouDTipCod FROM [CTIPDOC] WHERE [TipCod] = @VouDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00247,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00248", "SELECT [MonCod] AS VouDMon FROM [CMONEDAS] WHERE [MonCod] = @VouDMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT00248,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00249", "SELECT TM1.[VouDSec], TM1.[VouDFec], TM1.[VouDDoc], TM1.[VouDGls], TM1.[VouDTcmb], TM1.[VouDDebO], TM1.[VouDHabO], TM1.[VouDDeb], TM1.[VouDHab], TM1.[VouReg], TM1.[CueAuxCod], TM1.[CueCodAux], TM1.[VouMovAdic], TM1.[VouDUsuCodC], TM1.[VouDUsuFecC], TM1.[VouDUsuCodM], TM1.[VouDUsuFecM], TM1.[VouDProdCod], TM1.[VouDordCod], TM1.[VouDCant], TM1.[VouDRef1], TM1.[VouDRef2], TM1.[VouDRef3], TM1.[VouDRef4], TM1.[VouDRef5], TM1.[VouDRef6], TM1.[VouDRef7], TM1.[VouDRef8], TM1.[VouDRef9], TM1.[VouDRef10], TM1.[VouAno], TM1.[VouMes], TM1.[TASICod], TM1.[VouNum], TM1.[CueCod], TM1.[COSCod], TM1.[VouDTipCod] AS VouDTipCod, TM1.[VouDMon] AS VouDMon FROM [CBVOUCHERDET] TM1 WHERE TM1.[VouAno] = @VouAno and TM1.[VouMes] = @VouMes and TM1.[TASICod] = @TASICod and TM1.[VouNum] = @VouNum and TM1.[VouDSec] = @VouDSec ORDER BY TM1.[VouAno], TM1.[VouMes], TM1.[TASICod], TM1.[VouNum], TM1.[VouDSec]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00249,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002410", "SELECT [VouAno] FROM [CBVOUCHER] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002411", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002412", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002413", "SELECT [TipCod] AS VouDTipCod FROM [CTIPDOC] WHERE [TipCod] = @VouDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002414", "SELECT [MonCod] AS VouDMon FROM [CMONEDAS] WHERE [MonCod] = @VouDMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT002414,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002415", "SELECT [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum AND [VouDSec] = @VouDSec  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002416", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ( [VouAno] > @VouAno or [VouAno] = @VouAno and [VouMes] > @VouMes or [VouMes] = @VouMes and [VouAno] = @VouAno and [TASICod] > @TASICod or [TASICod] = @TASICod and [VouMes] = @VouMes and [VouAno] = @VouAno and [VouNum] > @VouNum or [VouNum] = @VouNum and [TASICod] = @TASICod and [VouMes] = @VouMes and [VouAno] = @VouAno and [VouDSec] > @VouDSec) ORDER BY [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002416,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002417", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE ( [VouAno] < @VouAno or [VouAno] = @VouAno and [VouMes] < @VouMes or [VouMes] = @VouMes and [VouAno] = @VouAno and [TASICod] < @TASICod or [TASICod] = @TASICod and [VouMes] = @VouMes and [VouAno] = @VouAno and [VouNum] < @VouNum or [VouNum] = @VouNum and [TASICod] = @TASICod and [VouMes] = @VouMes and [VouAno] = @VouAno and [VouDSec] < @VouDSec) ORDER BY [VouAno] DESC, [VouMes] DESC, [TASICod] DESC, [VouNum] DESC, [VouDSec] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002417,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002418", "INSERT INTO [CBVOUCHERDET]([VouDSec], [VouDFec], [VouDDoc], [VouDGls], [VouDTcmb], [VouDDebO], [VouDHabO], [VouDDeb], [VouDHab], [VouReg], [CueAuxCod], [CueCodAux], [VouMovAdic], [VouDUsuCodC], [VouDUsuFecC], [VouDUsuCodM], [VouDUsuFecM], [VouDProdCod], [VouDordCod], [VouDCant], [VouDRef1], [VouDRef2], [VouDRef3], [VouDRef4], [VouDRef5], [VouDRef6], [VouDRef7], [VouDRef8], [VouDRef9], [VouDRef10], [VouAno], [VouMes], [TASICod], [VouNum], [CueCod], [COSCod], [VouDTipCod], [VouDMon]) VALUES(@VouDSec, @VouDFec, @VouDDoc, @VouDGls, @VouDTcmb, @VouDDebO, @VouDHabO, @VouDDeb, @VouDHab, @VouReg, @CueAuxCod, @CueCodAux, @VouMovAdic, @VouDUsuCodC, @VouDUsuFecC, @VouDUsuCodM, @VouDUsuFecM, @VouDProdCod, @VouDordCod, @VouDCant, @VouDRef1, @VouDRef2, @VouDRef3, @VouDRef4, @VouDRef5, @VouDRef6, @VouDRef7, @VouDRef8, @VouDRef9, @VouDRef10, @VouAno, @VouMes, @TASICod, @VouNum, @CueCod, @COSCod, @VouDTipCod, @VouDMon)", GxErrorMask.GX_NOMASK,prmT002418)
           ,new CursorDef("T002419", "UPDATE [CBVOUCHERDET] SET [VouDFec]=@VouDFec, [VouDDoc]=@VouDDoc, [VouDGls]=@VouDGls, [VouDTcmb]=@VouDTcmb, [VouDDebO]=@VouDDebO, [VouDHabO]=@VouDHabO, [VouDDeb]=@VouDDeb, [VouDHab]=@VouDHab, [VouReg]=@VouReg, [CueAuxCod]=@CueAuxCod, [CueCodAux]=@CueCodAux, [VouMovAdic]=@VouMovAdic, [VouDUsuCodC]=@VouDUsuCodC, [VouDUsuFecC]=@VouDUsuFecC, [VouDUsuCodM]=@VouDUsuCodM, [VouDUsuFecM]=@VouDUsuFecM, [VouDProdCod]=@VouDProdCod, [VouDordCod]=@VouDordCod, [VouDCant]=@VouDCant, [VouDRef1]=@VouDRef1, [VouDRef2]=@VouDRef2, [VouDRef3]=@VouDRef3, [VouDRef4]=@VouDRef4, [VouDRef5]=@VouDRef5, [VouDRef6]=@VouDRef6, [VouDRef7]=@VouDRef7, [VouDRef8]=@VouDRef8, [VouDRef9]=@VouDRef9, [VouDRef10]=@VouDRef10, [CueCod]=@CueCod, [COSCod]=@COSCod, [VouDTipCod]=@VouDTipCod, [VouDMon]=@VouDMon  WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum AND [VouDSec] = @VouDSec", GxErrorMask.GX_NOMASK,prmT002419)
           ,new CursorDef("T002420", "DELETE FROM [CBVOUCHERDET]  WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum AND [VouDSec] = @VouDSec", GxErrorMask.GX_NOMASK,prmT002420)
           ,new CursorDef("T002421", "SELECT [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] ORDER BY [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002421,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002422", "SELECT [VouAno] FROM [CBVOUCHER] WHERE [VouAno] = @VouAno AND [VouMes] = @VouMes AND [TASICod] = @TASICod AND [VouNum] = @VouNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002422,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002423", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002423,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002424", "SELECT [COSCod] FROM [CBCOSTOS] WHERE [COSCod] = @COSCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002424,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002425", "SELECT [TipCod] AS VouDTipCod FROM [CTIPDOC] WHERE [TipCod] = @VouDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002425,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002426", "SELECT [MonCod] AS VouDMon FROM [CMONEDAS] WHERE [MonCod] = @VouDMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT002426,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((string[]) buf[27])[0] = rslt.getVarchar(28);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getVarchar(30);
              ((short[]) buf[30])[0] = rslt.getShort(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 10);
              ((string[]) buf[34])[0] = rslt.getString(35, 15);
              ((string[]) buf[35])[0] = rslt.getString(36, 10);
              ((bool[]) buf[36])[0] = rslt.wasNull(36);
              ((string[]) buf[37])[0] = rslt.getString(37, 3);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((string[]) buf[27])[0] = rslt.getVarchar(28);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getVarchar(30);
              ((short[]) buf[30])[0] = rslt.getShort(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 10);
              ((string[]) buf[34])[0] = rslt.getString(35, 15);
              ((string[]) buf[35])[0] = rslt.getString(36, 10);
              ((bool[]) buf[36])[0] = rslt.wasNull(36);
              ((string[]) buf[37])[0] = rslt.getString(37, 3);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((string[]) buf[27])[0] = rslt.getVarchar(28);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getVarchar(30);
              ((short[]) buf[30])[0] = rslt.getShort(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 10);
              ((string[]) buf[34])[0] = rslt.getString(35, 15);
              ((string[]) buf[35])[0] = rslt.getString(36, 10);
              ((bool[]) buf[36])[0] = rslt.wasNull(36);
              ((string[]) buf[37])[0] = rslt.getString(37, 3);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
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
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
