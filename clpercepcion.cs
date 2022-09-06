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
   public class clpercepcion : GXDataArea
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
            A221PerCliCod = GetPar( "PerCliCod");
            AssignAttri("", false, "A221PerCliCod", A221PerCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A221PerCliCod) ;
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
            Form.Meta.addItem("description", "Comprobantes de Percepción", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clpercepcion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpercepcion( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLPERCEPCION.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Percepción", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerCod_Internalname, StringUtil.RTrim( A218PerCod), StringUtil.RTrim( context.localUtil.Format( A218PerCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "T/D", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTip_Internalname, StringUtil.RTrim( A219PerTip), StringUtil.RTrim( context.localUtil.Format( A219PerTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "T/D Ref", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTDoc_Internalname, A220PerTDoc, StringUtil.RTrim( context.localUtil.Format( A220PerTDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTDoc_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPerFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPerFec_Internalname, context.localUtil.Format(A1617PerFec, "99/99/99"), context.localUtil.Format( A1617PerFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPERCEPCION.htm");
         GxWebStd.gx_bitmap( context, edtPerFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPerFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Cliente", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerCliCod_Internalname, StringUtil.RTrim( A221PerCliCod), StringUtil.RTrim( context.localUtil.Format( A221PerCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Cliente", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPerCliDsc_Internalname, StringUtil.RTrim( A1616PerCliDsc), StringUtil.RTrim( context.localUtil.Format( A1616PerCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerSts_Internalname, StringUtil.RTrim( A1620PerSts), StringUtil.RTrim( context.localUtil.Format( A1620PerSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Año Voucher", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1625PerVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtPerVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1625PerVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1625PerVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Mes Voucher", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1626PerVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtPerVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1626PerVouMes), "Z9") : context.localUtil.Format( (decimal)(A1626PerVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Tipo Asiento", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1621PerTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPerTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1621PerTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1621PerTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "N° Voucher", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerVouNum_Internalname, StringUtil.RTrim( A1627PerVouNum), StringUtil.RTrim( context.localUtil.Format( A1627PerVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Usuario", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerUsuCod_Internalname, StringUtil.RTrim( A1623PerUsuCod), StringUtil.RTrim( context.localUtil.Format( A1623PerUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Usuario Fecha", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPerUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPerUsuFec_Internalname, context.localUtil.TToC( A1624PerUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1624PerUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPERCEPCION.htm");
         GxWebStd.gx_bitmap( context, edtPerUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPerUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Tipo de Cambio", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPerTipCambio_Internalname, StringUtil.LTrim( StringUtil.NToC( A1622PerTipCambio, 17, 4, ".", "")), StringUtil.LTrim( ((edtPerTipCambio_Enabled!=0) ? context.localUtil.Format( A1622PerTipCambio, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1622PerTipCambio, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPerTipCambio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPerTipCambio_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPERCEPCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPERCEPCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLPERCEPCION.htm");
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
            Z218PerCod = cgiGet( "Z218PerCod");
            Z219PerTip = cgiGet( "Z219PerTip");
            Z220PerTDoc = cgiGet( "Z220PerTDoc");
            Z1617PerFec = context.localUtil.CToD( cgiGet( "Z1617PerFec"), 0);
            Z1620PerSts = cgiGet( "Z1620PerSts");
            Z1625PerVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1625PerVouAno"), ".", ","));
            Z1626PerVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1626PerVouMes"), ".", ","));
            Z1621PerTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z1621PerTasiCod"), ".", ","));
            Z1627PerVouNum = cgiGet( "Z1627PerVouNum");
            Z1623PerUsuCod = cgiGet( "Z1623PerUsuCod");
            Z1624PerUsuFec = context.localUtil.CToT( cgiGet( "Z1624PerUsuFec"), 0);
            Z1622PerTipCambio = context.localUtil.CToN( cgiGet( "Z1622PerTipCambio"), ".", ",");
            Z221PerCliCod = cgiGet( "Z221PerCliCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A218PerCod = cgiGet( edtPerCod_Internalname);
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = cgiGet( edtPerTip_Internalname);
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = cgiGet( edtPerTDoc_Internalname);
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            if ( context.localUtil.VCDate( cgiGet( edtPerFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "PERFEC");
               AnyError = 1;
               GX_FocusControl = edtPerFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1617PerFec = DateTime.MinValue;
               AssignAttri("", false, "A1617PerFec", context.localUtil.Format(A1617PerFec, "99/99/99"));
            }
            else
            {
               A1617PerFec = context.localUtil.CToD( cgiGet( edtPerFec_Internalname), 2);
               AssignAttri("", false, "A1617PerFec", context.localUtil.Format(A1617PerFec, "99/99/99"));
            }
            A221PerCliCod = cgiGet( edtPerCliCod_Internalname);
            AssignAttri("", false, "A221PerCliCod", A221PerCliCod);
            A1616PerCliDsc = cgiGet( edtPerCliDsc_Internalname);
            AssignAttri("", false, "A1616PerCliDsc", A1616PerCliDsc);
            A1620PerSts = cgiGet( edtPerSts_Internalname);
            AssignAttri("", false, "A1620PerSts", A1620PerSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPerVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPerVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERVOUANO");
               AnyError = 1;
               GX_FocusControl = edtPerVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1625PerVouAno = 0;
               AssignAttri("", false, "A1625PerVouAno", StringUtil.LTrimStr( (decimal)(A1625PerVouAno), 4, 0));
            }
            else
            {
               A1625PerVouAno = (short)(context.localUtil.CToN( cgiGet( edtPerVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1625PerVouAno", StringUtil.LTrimStr( (decimal)(A1625PerVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPerVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPerVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERVOUMES");
               AnyError = 1;
               GX_FocusControl = edtPerVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1626PerVouMes = 0;
               AssignAttri("", false, "A1626PerVouMes", StringUtil.LTrimStr( (decimal)(A1626PerVouMes), 2, 0));
            }
            else
            {
               A1626PerVouMes = (short)(context.localUtil.CToN( cgiGet( edtPerVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1626PerVouMes", StringUtil.LTrimStr( (decimal)(A1626PerVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPerTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPerTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERTASICOD");
               AnyError = 1;
               GX_FocusControl = edtPerTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1621PerTasiCod = 0;
               AssignAttri("", false, "A1621PerTasiCod", StringUtil.LTrimStr( (decimal)(A1621PerTasiCod), 6, 0));
            }
            else
            {
               A1621PerTasiCod = (int)(context.localUtil.CToN( cgiGet( edtPerTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A1621PerTasiCod", StringUtil.LTrimStr( (decimal)(A1621PerTasiCod), 6, 0));
            }
            A1627PerVouNum = cgiGet( edtPerVouNum_Internalname);
            AssignAttri("", false, "A1627PerVouNum", A1627PerVouNum);
            A1623PerUsuCod = cgiGet( edtPerUsuCod_Internalname);
            AssignAttri("", false, "A1623PerUsuCod", A1623PerUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtPerUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "PERUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtPerUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1624PerUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1624PerUsuFec", context.localUtil.TToC( A1624PerUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1624PerUsuFec = context.localUtil.CToT( cgiGet( edtPerUsuFec_Internalname));
               AssignAttri("", false, "A1624PerUsuFec", context.localUtil.TToC( A1624PerUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPerTipCambio_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPerTipCambio_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERTIPCAMBIO");
               AnyError = 1;
               GX_FocusControl = edtPerTipCambio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1622PerTipCambio = 0;
               AssignAttri("", false, "A1622PerTipCambio", StringUtil.LTrimStr( A1622PerTipCambio, 15, 4));
            }
            else
            {
               A1622PerTipCambio = context.localUtil.CToN( cgiGet( edtPerTipCambio_Internalname), ".", ",");
               AssignAttri("", false, "A1622PerTipCambio", StringUtil.LTrimStr( A1622PerTipCambio, 15, 4));
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
               A218PerCod = GetPar( "PerCod");
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A219PerTip = GetPar( "PerTip");
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A220PerTDoc = GetPar( "PerTDoc");
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
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
               InitAll2V98( ) ;
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
         DisableAttributes2V98( ) ;
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

      protected void CONFIRM_2V0( )
      {
         BeforeValidate2V98( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2V98( ) ;
            }
            else
            {
               CheckExtendedTable2V98( ) ;
               if ( AnyError == 0 )
               {
                  ZM2V98( 4) ;
               }
               CloseExtendedTableCursors2V98( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2V0( ) ;
         }
      }

      protected void ResetCaption2V0( )
      {
      }

      protected void ZM2V98( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1617PerFec = T002V3_A1617PerFec[0];
               Z1620PerSts = T002V3_A1620PerSts[0];
               Z1625PerVouAno = T002V3_A1625PerVouAno[0];
               Z1626PerVouMes = T002V3_A1626PerVouMes[0];
               Z1621PerTasiCod = T002V3_A1621PerTasiCod[0];
               Z1627PerVouNum = T002V3_A1627PerVouNum[0];
               Z1623PerUsuCod = T002V3_A1623PerUsuCod[0];
               Z1624PerUsuFec = T002V3_A1624PerUsuFec[0];
               Z1622PerTipCambio = T002V3_A1622PerTipCambio[0];
               Z221PerCliCod = T002V3_A221PerCliCod[0];
            }
            else
            {
               Z1617PerFec = A1617PerFec;
               Z1620PerSts = A1620PerSts;
               Z1625PerVouAno = A1625PerVouAno;
               Z1626PerVouMes = A1626PerVouMes;
               Z1621PerTasiCod = A1621PerTasiCod;
               Z1627PerVouNum = A1627PerVouNum;
               Z1623PerUsuCod = A1623PerUsuCod;
               Z1624PerUsuFec = A1624PerUsuFec;
               Z1622PerTipCambio = A1622PerTipCambio;
               Z221PerCliCod = A221PerCliCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z218PerCod = A218PerCod;
            Z219PerTip = A219PerTip;
            Z220PerTDoc = A220PerTDoc;
            Z1617PerFec = A1617PerFec;
            Z1620PerSts = A1620PerSts;
            Z1625PerVouAno = A1625PerVouAno;
            Z1626PerVouMes = A1626PerVouMes;
            Z1621PerTasiCod = A1621PerTasiCod;
            Z1627PerVouNum = A1627PerVouNum;
            Z1623PerUsuCod = A1623PerUsuCod;
            Z1624PerUsuFec = A1624PerUsuFec;
            Z1622PerTipCambio = A1622PerTipCambio;
            Z221PerCliCod = A221PerCliCod;
            Z1616PerCliDsc = A1616PerCliDsc;
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

      protected void Load2V98( )
      {
         /* Using cursor T002V5 */
         pr_default.execute(3, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound98 = 1;
            A1617PerFec = T002V5_A1617PerFec[0];
            AssignAttri("", false, "A1617PerFec", context.localUtil.Format(A1617PerFec, "99/99/99"));
            A1616PerCliDsc = T002V5_A1616PerCliDsc[0];
            AssignAttri("", false, "A1616PerCliDsc", A1616PerCliDsc);
            A1620PerSts = T002V5_A1620PerSts[0];
            AssignAttri("", false, "A1620PerSts", A1620PerSts);
            A1625PerVouAno = T002V5_A1625PerVouAno[0];
            AssignAttri("", false, "A1625PerVouAno", StringUtil.LTrimStr( (decimal)(A1625PerVouAno), 4, 0));
            A1626PerVouMes = T002V5_A1626PerVouMes[0];
            AssignAttri("", false, "A1626PerVouMes", StringUtil.LTrimStr( (decimal)(A1626PerVouMes), 2, 0));
            A1621PerTasiCod = T002V5_A1621PerTasiCod[0];
            AssignAttri("", false, "A1621PerTasiCod", StringUtil.LTrimStr( (decimal)(A1621PerTasiCod), 6, 0));
            A1627PerVouNum = T002V5_A1627PerVouNum[0];
            AssignAttri("", false, "A1627PerVouNum", A1627PerVouNum);
            A1623PerUsuCod = T002V5_A1623PerUsuCod[0];
            AssignAttri("", false, "A1623PerUsuCod", A1623PerUsuCod);
            A1624PerUsuFec = T002V5_A1624PerUsuFec[0];
            AssignAttri("", false, "A1624PerUsuFec", context.localUtil.TToC( A1624PerUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1622PerTipCambio = T002V5_A1622PerTipCambio[0];
            AssignAttri("", false, "A1622PerTipCambio", StringUtil.LTrimStr( A1622PerTipCambio, 15, 4));
            A221PerCliCod = T002V5_A221PerCliCod[0];
            AssignAttri("", false, "A221PerCliCod", A221PerCliCod);
            ZM2V98( -3) ;
         }
         pr_default.close(3);
         OnLoadActions2V98( ) ;
      }

      protected void OnLoadActions2V98( )
      {
      }

      protected void CheckExtendedTable2V98( )
      {
         nIsDirty_98 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1617PerFec) || ( DateTimeUtil.ResetTime ( A1617PerFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "PERFEC");
            AnyError = 1;
            GX_FocusControl = edtPerFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002V4 */
         pr_default.execute(2, new Object[] {A221PerCliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Percepcion Cliente'.", "ForeignKeyNotFound", 1, "PERCLICOD");
            AnyError = 1;
            GX_FocusControl = edtPerCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1616PerCliDsc = T002V4_A1616PerCliDsc[0];
         AssignAttri("", false, "A1616PerCliDsc", A1616PerCliDsc);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1624PerUsuFec) || ( A1624PerUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "PERUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtPerUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2V98( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A221PerCliCod )
      {
         /* Using cursor T002V6 */
         pr_default.execute(4, new Object[] {A221PerCliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Percepcion Cliente'.", "ForeignKeyNotFound", 1, "PERCLICOD");
            AnyError = 1;
            GX_FocusControl = edtPerCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1616PerCliDsc = T002V6_A1616PerCliDsc[0];
         AssignAttri("", false, "A1616PerCliDsc", A1616PerCliDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1616PerCliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey2V98( )
      {
         /* Using cursor T002V7 */
         pr_default.execute(5, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound98 = 1;
         }
         else
         {
            RcdFound98 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002V3 */
         pr_default.execute(1, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2V98( 3) ;
            RcdFound98 = 1;
            A218PerCod = T002V3_A218PerCod[0];
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = T002V3_A219PerTip[0];
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = T002V3_A220PerTDoc[0];
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            A1617PerFec = T002V3_A1617PerFec[0];
            AssignAttri("", false, "A1617PerFec", context.localUtil.Format(A1617PerFec, "99/99/99"));
            A1620PerSts = T002V3_A1620PerSts[0];
            AssignAttri("", false, "A1620PerSts", A1620PerSts);
            A1625PerVouAno = T002V3_A1625PerVouAno[0];
            AssignAttri("", false, "A1625PerVouAno", StringUtil.LTrimStr( (decimal)(A1625PerVouAno), 4, 0));
            A1626PerVouMes = T002V3_A1626PerVouMes[0];
            AssignAttri("", false, "A1626PerVouMes", StringUtil.LTrimStr( (decimal)(A1626PerVouMes), 2, 0));
            A1621PerTasiCod = T002V3_A1621PerTasiCod[0];
            AssignAttri("", false, "A1621PerTasiCod", StringUtil.LTrimStr( (decimal)(A1621PerTasiCod), 6, 0));
            A1627PerVouNum = T002V3_A1627PerVouNum[0];
            AssignAttri("", false, "A1627PerVouNum", A1627PerVouNum);
            A1623PerUsuCod = T002V3_A1623PerUsuCod[0];
            AssignAttri("", false, "A1623PerUsuCod", A1623PerUsuCod);
            A1624PerUsuFec = T002V3_A1624PerUsuFec[0];
            AssignAttri("", false, "A1624PerUsuFec", context.localUtil.TToC( A1624PerUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1622PerTipCambio = T002V3_A1622PerTipCambio[0];
            AssignAttri("", false, "A1622PerTipCambio", StringUtil.LTrimStr( A1622PerTipCambio, 15, 4));
            A221PerCliCod = T002V3_A221PerCliCod[0];
            AssignAttri("", false, "A221PerCliCod", A221PerCliCod);
            Z218PerCod = A218PerCod;
            Z219PerTip = A219PerTip;
            Z220PerTDoc = A220PerTDoc;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2V98( ) ;
            if ( AnyError == 1 )
            {
               RcdFound98 = 0;
               InitializeNonKey2V98( ) ;
            }
            Gx_mode = sMode98;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound98 = 0;
            InitializeNonKey2V98( ) ;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode98;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2V98( ) ;
         if ( RcdFound98 == 0 )
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
         RcdFound98 = 0;
         /* Using cursor T002V8 */
         pr_default.execute(6, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T002V8_A218PerCod[0], A218PerCod) < 0 ) || ( StringUtil.StrCmp(T002V8_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V8_A219PerTip[0], A219PerTip) < 0 ) || ( StringUtil.StrCmp(T002V8_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002V8_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V8_A220PerTDoc[0], A220PerTDoc) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T002V8_A218PerCod[0], A218PerCod) > 0 ) || ( StringUtil.StrCmp(T002V8_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V8_A219PerTip[0], A219PerTip) > 0 ) || ( StringUtil.StrCmp(T002V8_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002V8_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V8_A220PerTDoc[0], A220PerTDoc) > 0 ) ) )
            {
               A218PerCod = T002V8_A218PerCod[0];
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A219PerTip = T002V8_A219PerTip[0];
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A220PerTDoc = T002V8_A220PerTDoc[0];
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               RcdFound98 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound98 = 0;
         /* Using cursor T002V9 */
         pr_default.execute(7, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T002V9_A218PerCod[0], A218PerCod) > 0 ) || ( StringUtil.StrCmp(T002V9_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V9_A219PerTip[0], A219PerTip) > 0 ) || ( StringUtil.StrCmp(T002V9_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002V9_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V9_A220PerTDoc[0], A220PerTDoc) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T002V9_A218PerCod[0], A218PerCod) < 0 ) || ( StringUtil.StrCmp(T002V9_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V9_A219PerTip[0], A219PerTip) < 0 ) || ( StringUtil.StrCmp(T002V9_A219PerTip[0], A219PerTip) == 0 ) && ( StringUtil.StrCmp(T002V9_A218PerCod[0], A218PerCod) == 0 ) && ( StringUtil.StrCmp(T002V9_A220PerTDoc[0], A220PerTDoc) < 0 ) ) )
            {
               A218PerCod = T002V9_A218PerCod[0];
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A219PerTip = T002V9_A219PerTip[0];
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A220PerTDoc = T002V9_A220PerTDoc[0];
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               RcdFound98 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2V98( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2V98( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound98 == 1 )
            {
               if ( ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) )
               {
                  A218PerCod = Z218PerCod;
                  AssignAttri("", false, "A218PerCod", A218PerCod);
                  A219PerTip = Z219PerTip;
                  AssignAttri("", false, "A219PerTip", A219PerTip);
                  A220PerTDoc = Z220PerTDoc;
                  AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2V98( ) ;
                  GX_FocusControl = edtPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPerCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2V98( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PERCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPerCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2V98( ) ;
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
         if ( ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) )
         {
            A218PerCod = Z218PerCod;
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = Z219PerTip;
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = Z220PerTDoc;
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PERCOD");
            AnyError = 1;
            GX_FocusControl = edtPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPerCod_Internalname;
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
         GetKey2V98( ) ;
         if ( RcdFound98 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PERCOD");
               AnyError = 1;
               GX_FocusControl = edtPerCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) )
            {
               A218PerCod = Z218PerCod;
               AssignAttri("", false, "A218PerCod", A218PerCod);
               A219PerTip = Z219PerTip;
               AssignAttri("", false, "A219PerTip", A219PerTip);
               A220PerTDoc = Z220PerTDoc;
               AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PERCOD");
               AnyError = 1;
               GX_FocusControl = edtPerCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A218PerCod, Z218PerCod) != 0 ) || ( StringUtil.StrCmp(A219PerTip, Z219PerTip) != 0 ) || ( StringUtil.StrCmp(A220PerTDoc, Z220PerTDoc) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PERCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPerCod_Internalname;
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
         context.RollbackDataStores("clpercepcion",pr_default);
         GX_FocusControl = edtPerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2V0( ) ;
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
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PERCOD");
            AnyError = 1;
            GX_FocusControl = edtPerCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2V98( ) ;
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2V98( ) ;
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
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerFec_Internalname;
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
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerFec_Internalname;
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
         ScanStart2V98( ) ;
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound98 != 0 )
            {
               ScanNext2V98( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPerFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2V98( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2V98( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002V2 */
            pr_default.execute(0, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPERCEPCION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1617PerFec ) != DateTimeUtil.ResetTime ( T002V2_A1617PerFec[0] ) ) || ( StringUtil.StrCmp(Z1620PerSts, T002V2_A1620PerSts[0]) != 0 ) || ( Z1625PerVouAno != T002V2_A1625PerVouAno[0] ) || ( Z1626PerVouMes != T002V2_A1626PerVouMes[0] ) || ( Z1621PerTasiCod != T002V2_A1621PerTasiCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1627PerVouNum, T002V2_A1627PerVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1623PerUsuCod, T002V2_A1623PerUsuCod[0]) != 0 ) || ( Z1624PerUsuFec != T002V2_A1624PerUsuFec[0] ) || ( Z1622PerTipCambio != T002V2_A1622PerTipCambio[0] ) || ( StringUtil.StrCmp(Z221PerCliCod, T002V2_A221PerCliCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1617PerFec ) != DateTimeUtil.ResetTime ( T002V2_A1617PerFec[0] ) )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerFec");
                  GXUtil.WriteLogRaw("Old: ",Z1617PerFec);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1617PerFec[0]);
               }
               if ( StringUtil.StrCmp(Z1620PerSts, T002V2_A1620PerSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerSts");
                  GXUtil.WriteLogRaw("Old: ",Z1620PerSts);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1620PerSts[0]);
               }
               if ( Z1625PerVouAno != T002V2_A1625PerVouAno[0] )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1625PerVouAno);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1625PerVouAno[0]);
               }
               if ( Z1626PerVouMes != T002V2_A1626PerVouMes[0] )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1626PerVouMes);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1626PerVouMes[0]);
               }
               if ( Z1621PerTasiCod != T002V2_A1621PerTasiCod[0] )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z1621PerTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1621PerTasiCod[0]);
               }
               if ( StringUtil.StrCmp(Z1627PerVouNum, T002V2_A1627PerVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1627PerVouNum);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1627PerVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1623PerUsuCod, T002V2_A1623PerUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1623PerUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1623PerUsuCod[0]);
               }
               if ( Z1624PerUsuFec != T002V2_A1624PerUsuFec[0] )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1624PerUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1624PerUsuFec[0]);
               }
               if ( Z1622PerTipCambio != T002V2_A1622PerTipCambio[0] )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerTipCambio");
                  GXUtil.WriteLogRaw("Old: ",Z1622PerTipCambio);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A1622PerTipCambio[0]);
               }
               if ( StringUtil.StrCmp(Z221PerCliCod, T002V2_A221PerCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clpercepcion:[seudo value changed for attri]"+"PerCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z221PerCliCod);
                  GXUtil.WriteLogRaw("Current: ",T002V2_A221PerCliCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLPERCEPCION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2V98( )
      {
         BeforeValidate2V98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2V98( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2V98( 0) ;
            CheckOptimisticConcurrency2V98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2V98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2V98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002V10 */
                     pr_default.execute(8, new Object[] {A218PerCod, A219PerTip, A220PerTDoc, A1617PerFec, A1620PerSts, A1625PerVouAno, A1626PerVouMes, A1621PerTasiCod, A1627PerVouNum, A1623PerUsuCod, A1624PerUsuFec, A1622PerTipCambio, A221PerCliCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPERCEPCION");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption2V0( ) ;
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
               Load2V98( ) ;
            }
            EndLevel2V98( ) ;
         }
         CloseExtendedTableCursors2V98( ) ;
      }

      protected void Update2V98( )
      {
         BeforeValidate2V98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2V98( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2V98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2V98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2V98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002V11 */
                     pr_default.execute(9, new Object[] {A1617PerFec, A1620PerSts, A1625PerVouAno, A1626PerVouMes, A1621PerTasiCod, A1627PerVouNum, A1623PerUsuCod, A1624PerUsuFec, A1622PerTipCambio, A221PerCliCod, A218PerCod, A219PerTip, A220PerTDoc});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPERCEPCION");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPERCEPCION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2V98( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2V0( ) ;
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
            EndLevel2V98( ) ;
         }
         CloseExtendedTableCursors2V98( ) ;
      }

      protected void DeferredUpdate2V98( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2V98( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2V98( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2V98( ) ;
            AfterConfirm2V98( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2V98( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002V12 */
                  pr_default.execute(10, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CLPERCEPCION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound98 == 0 )
                        {
                           InitAll2V98( ) ;
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
                        ResetCaption2V0( ) ;
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
         sMode98 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2V98( ) ;
         Gx_mode = sMode98;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2V98( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002V13 */
            pr_default.execute(11, new Object[] {A221PerCliCod});
            A1616PerCliDsc = T002V13_A1616PerCliDsc[0];
            AssignAttri("", false, "A1616PerCliDsc", A1616PerCliDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002V14 */
            pr_default.execute(12, new Object[] {A218PerCod, A219PerTip, A220PerTDoc});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Comprobante de Percepción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel2V98( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2V98( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("clpercepcion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("clpercepcion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2V98( )
      {
         /* Using cursor T002V15 */
         pr_default.execute(13);
         RcdFound98 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound98 = 1;
            A218PerCod = T002V15_A218PerCod[0];
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = T002V15_A219PerTip[0];
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = T002V15_A220PerTDoc[0];
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2V98( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound98 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound98 = 1;
            A218PerCod = T002V15_A218PerCod[0];
            AssignAttri("", false, "A218PerCod", A218PerCod);
            A219PerTip = T002V15_A219PerTip[0];
            AssignAttri("", false, "A219PerTip", A219PerTip);
            A220PerTDoc = T002V15_A220PerTDoc[0];
            AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
         }
      }

      protected void ScanEnd2V98( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2V98( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2V98( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2V98( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2V98( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2V98( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2V98( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2V98( )
      {
         edtPerCod_Enabled = 0;
         AssignProp("", false, edtPerCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerCod_Enabled), 5, 0), true);
         edtPerTip_Enabled = 0;
         AssignProp("", false, edtPerTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTip_Enabled), 5, 0), true);
         edtPerTDoc_Enabled = 0;
         AssignProp("", false, edtPerTDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTDoc_Enabled), 5, 0), true);
         edtPerFec_Enabled = 0;
         AssignProp("", false, edtPerFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerFec_Enabled), 5, 0), true);
         edtPerCliCod_Enabled = 0;
         AssignProp("", false, edtPerCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerCliCod_Enabled), 5, 0), true);
         edtPerCliDsc_Enabled = 0;
         AssignProp("", false, edtPerCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerCliDsc_Enabled), 5, 0), true);
         edtPerSts_Enabled = 0;
         AssignProp("", false, edtPerSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerSts_Enabled), 5, 0), true);
         edtPerVouAno_Enabled = 0;
         AssignProp("", false, edtPerVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerVouAno_Enabled), 5, 0), true);
         edtPerVouMes_Enabled = 0;
         AssignProp("", false, edtPerVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerVouMes_Enabled), 5, 0), true);
         edtPerTasiCod_Enabled = 0;
         AssignProp("", false, edtPerTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTasiCod_Enabled), 5, 0), true);
         edtPerVouNum_Enabled = 0;
         AssignProp("", false, edtPerVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerVouNum_Enabled), 5, 0), true);
         edtPerUsuCod_Enabled = 0;
         AssignProp("", false, edtPerUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerUsuCod_Enabled), 5, 0), true);
         edtPerUsuFec_Enabled = 0;
         AssignProp("", false, edtPerUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerUsuFec_Enabled), 5, 0), true);
         edtPerTipCambio_Enabled = 0;
         AssignProp("", false, edtPerTipCambio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPerTipCambio_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2V98( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2V0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810244778", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clpercepcion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z218PerCod", StringUtil.RTrim( Z218PerCod));
         GxWebStd.gx_hidden_field( context, "Z219PerTip", StringUtil.RTrim( Z219PerTip));
         GxWebStd.gx_hidden_field( context, "Z220PerTDoc", Z220PerTDoc);
         GxWebStd.gx_hidden_field( context, "Z1617PerFec", context.localUtil.DToC( Z1617PerFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1620PerSts", StringUtil.RTrim( Z1620PerSts));
         GxWebStd.gx_hidden_field( context, "Z1625PerVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1625PerVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1626PerVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1626PerVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1621PerTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1621PerTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1627PerVouNum", StringUtil.RTrim( Z1627PerVouNum));
         GxWebStd.gx_hidden_field( context, "Z1623PerUsuCod", StringUtil.RTrim( Z1623PerUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1624PerUsuFec", context.localUtil.TToC( Z1624PerUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1622PerTipCambio", StringUtil.LTrim( StringUtil.NToC( Z1622PerTipCambio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z221PerCliCod", StringUtil.RTrim( Z221PerCliCod));
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
         return formatLink("clpercepcion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLPERCEPCION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Comprobantes de Percepción" ;
      }

      protected void InitializeNonKey2V98( )
      {
         A1617PerFec = DateTime.MinValue;
         AssignAttri("", false, "A1617PerFec", context.localUtil.Format(A1617PerFec, "99/99/99"));
         A221PerCliCod = "";
         AssignAttri("", false, "A221PerCliCod", A221PerCliCod);
         A1616PerCliDsc = "";
         AssignAttri("", false, "A1616PerCliDsc", A1616PerCliDsc);
         A1620PerSts = "";
         AssignAttri("", false, "A1620PerSts", A1620PerSts);
         A1625PerVouAno = 0;
         AssignAttri("", false, "A1625PerVouAno", StringUtil.LTrimStr( (decimal)(A1625PerVouAno), 4, 0));
         A1626PerVouMes = 0;
         AssignAttri("", false, "A1626PerVouMes", StringUtil.LTrimStr( (decimal)(A1626PerVouMes), 2, 0));
         A1621PerTasiCod = 0;
         AssignAttri("", false, "A1621PerTasiCod", StringUtil.LTrimStr( (decimal)(A1621PerTasiCod), 6, 0));
         A1627PerVouNum = "";
         AssignAttri("", false, "A1627PerVouNum", A1627PerVouNum);
         A1623PerUsuCod = "";
         AssignAttri("", false, "A1623PerUsuCod", A1623PerUsuCod);
         A1624PerUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1624PerUsuFec", context.localUtil.TToC( A1624PerUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1622PerTipCambio = 0;
         AssignAttri("", false, "A1622PerTipCambio", StringUtil.LTrimStr( A1622PerTipCambio, 15, 4));
         Z1617PerFec = DateTime.MinValue;
         Z1620PerSts = "";
         Z1625PerVouAno = 0;
         Z1626PerVouMes = 0;
         Z1621PerTasiCod = 0;
         Z1627PerVouNum = "";
         Z1623PerUsuCod = "";
         Z1624PerUsuFec = (DateTime)(DateTime.MinValue);
         Z1622PerTipCambio = 0;
         Z221PerCliCod = "";
      }

      protected void InitAll2V98( )
      {
         A218PerCod = "";
         AssignAttri("", false, "A218PerCod", A218PerCod);
         A219PerTip = "";
         AssignAttri("", false, "A219PerTip", A219PerTip);
         A220PerTDoc = "";
         AssignAttri("", false, "A220PerTDoc", A220PerTDoc);
         InitializeNonKey2V98( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810244788", true, true);
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
         context.AddJavascriptSource("clpercepcion.js", "?202281810244789", false, true);
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
         edtPerCod_Internalname = "PERCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPerTip_Internalname = "PERTIP";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPerTDoc_Internalname = "PERTDOC";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPerFec_Internalname = "PERFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPerCliCod_Internalname = "PERCLICOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPerCliDsc_Internalname = "PERCLIDSC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPerSts_Internalname = "PERSTS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPerVouAno_Internalname = "PERVOUANO";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPerVouMes_Internalname = "PERVOUMES";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPerTasiCod_Internalname = "PERTASICOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtPerVouNum_Internalname = "PERVOUNUM";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtPerUsuCod_Internalname = "PERUSUCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtPerUsuFec_Internalname = "PERUSUFEC";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtPerTipCambio_Internalname = "PERTIPCAMBIO";
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
         Form.Caption = "Comprobantes de Percepción";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPerTipCambio_Jsonclick = "";
         edtPerTipCambio_Enabled = 1;
         edtPerUsuFec_Jsonclick = "";
         edtPerUsuFec_Enabled = 1;
         edtPerUsuCod_Jsonclick = "";
         edtPerUsuCod_Enabled = 1;
         edtPerVouNum_Jsonclick = "";
         edtPerVouNum_Enabled = 1;
         edtPerTasiCod_Jsonclick = "";
         edtPerTasiCod_Enabled = 1;
         edtPerVouMes_Jsonclick = "";
         edtPerVouMes_Enabled = 1;
         edtPerVouAno_Jsonclick = "";
         edtPerVouAno_Enabled = 1;
         edtPerSts_Jsonclick = "";
         edtPerSts_Enabled = 1;
         edtPerCliDsc_Jsonclick = "";
         edtPerCliDsc_Enabled = 0;
         edtPerCliCod_Jsonclick = "";
         edtPerCliCod_Enabled = 1;
         edtPerFec_Jsonclick = "";
         edtPerFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPerTDoc_Jsonclick = "";
         edtPerTDoc_Enabled = 1;
         edtPerTip_Jsonclick = "";
         edtPerTip_Enabled = 1;
         edtPerCod_Jsonclick = "";
         edtPerCod_Enabled = 1;
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
         GX_FocusControl = edtPerFec_Internalname;
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

      public void Valid_Pertdoc( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1617PerFec", context.localUtil.Format(A1617PerFec, "99/99/99"));
         AssignAttri("", false, "A221PerCliCod", StringUtil.RTrim( A221PerCliCod));
         AssignAttri("", false, "A1620PerSts", StringUtil.RTrim( A1620PerSts));
         AssignAttri("", false, "A1625PerVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1625PerVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1626PerVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1626PerVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1621PerTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1621PerTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1627PerVouNum", StringUtil.RTrim( A1627PerVouNum));
         AssignAttri("", false, "A1623PerUsuCod", StringUtil.RTrim( A1623PerUsuCod));
         AssignAttri("", false, "A1624PerUsuFec", context.localUtil.TToC( A1624PerUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1622PerTipCambio", StringUtil.LTrim( StringUtil.NToC( A1622PerTipCambio, 15, 4, ".", "")));
         AssignAttri("", false, "A1616PerCliDsc", StringUtil.RTrim( A1616PerCliDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z218PerCod", StringUtil.RTrim( Z218PerCod));
         GxWebStd.gx_hidden_field( context, "Z219PerTip", StringUtil.RTrim( Z219PerTip));
         GxWebStd.gx_hidden_field( context, "Z220PerTDoc", Z220PerTDoc);
         GxWebStd.gx_hidden_field( context, "Z1617PerFec", context.localUtil.Format(Z1617PerFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z221PerCliCod", StringUtil.RTrim( Z221PerCliCod));
         GxWebStd.gx_hidden_field( context, "Z1620PerSts", StringUtil.RTrim( Z1620PerSts));
         GxWebStd.gx_hidden_field( context, "Z1625PerVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1625PerVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1626PerVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1626PerVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1621PerTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1621PerTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1627PerVouNum", StringUtil.RTrim( Z1627PerVouNum));
         GxWebStd.gx_hidden_field( context, "Z1623PerUsuCod", StringUtil.RTrim( Z1623PerUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1624PerUsuFec", context.localUtil.TToC( Z1624PerUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1622PerTipCambio", StringUtil.LTrim( StringUtil.NToC( Z1622PerTipCambio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1616PerCliDsc", StringUtil.RTrim( Z1616PerCliDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Perclicod( )
      {
         /* Using cursor T002V13 */
         pr_default.execute(11, new Object[] {A221PerCliCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Percepcion Cliente'.", "ForeignKeyNotFound", 1, "PERCLICOD");
            AnyError = 1;
            GX_FocusControl = edtPerCliCod_Internalname;
         }
         A1616PerCliDsc = T002V13_A1616PerCliDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1616PerCliDsc", StringUtil.RTrim( A1616PerCliDsc));
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
         setEventMetadata("VALID_PERCOD","{handler:'Valid_Percod',iparms:[]");
         setEventMetadata("VALID_PERCOD",",oparms:[]}");
         setEventMetadata("VALID_PERTIP","{handler:'Valid_Pertip',iparms:[]");
         setEventMetadata("VALID_PERTIP",",oparms:[]}");
         setEventMetadata("VALID_PERTDOC","{handler:'Valid_Pertdoc',iparms:[{av:'A218PerCod',fld:'PERCOD',pic:''},{av:'A219PerTip',fld:'PERTIP',pic:''},{av:'A220PerTDoc',fld:'PERTDOC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PERTDOC",",oparms:[{av:'A1617PerFec',fld:'PERFEC',pic:''},{av:'A221PerCliCod',fld:'PERCLICOD',pic:''},{av:'A1620PerSts',fld:'PERSTS',pic:''},{av:'A1625PerVouAno',fld:'PERVOUANO',pic:'ZZZ9'},{av:'A1626PerVouMes',fld:'PERVOUMES',pic:'Z9'},{av:'A1621PerTasiCod',fld:'PERTASICOD',pic:'ZZZZZ9'},{av:'A1627PerVouNum',fld:'PERVOUNUM',pic:''},{av:'A1623PerUsuCod',fld:'PERUSUCOD',pic:''},{av:'A1624PerUsuFec',fld:'PERUSUFEC',pic:'99/99/99 99:99'},{av:'A1622PerTipCambio',fld:'PERTIPCAMBIO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1616PerCliDsc',fld:'PERCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z218PerCod'},{av:'Z219PerTip'},{av:'Z220PerTDoc'},{av:'Z1617PerFec'},{av:'Z221PerCliCod'},{av:'Z1620PerSts'},{av:'Z1625PerVouAno'},{av:'Z1626PerVouMes'},{av:'Z1621PerTasiCod'},{av:'Z1627PerVouNum'},{av:'Z1623PerUsuCod'},{av:'Z1624PerUsuFec'},{av:'Z1622PerTipCambio'},{av:'Z1616PerCliDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PERFEC","{handler:'Valid_Perfec',iparms:[]");
         setEventMetadata("VALID_PERFEC",",oparms:[]}");
         setEventMetadata("VALID_PERCLICOD","{handler:'Valid_Perclicod',iparms:[{av:'A221PerCliCod',fld:'PERCLICOD',pic:''},{av:'A1616PerCliDsc',fld:'PERCLIDSC',pic:''}]");
         setEventMetadata("VALID_PERCLICOD",",oparms:[{av:'A1616PerCliDsc',fld:'PERCLIDSC',pic:''}]}");
         setEventMetadata("VALID_PERUSUFEC","{handler:'Valid_Perusufec',iparms:[]");
         setEventMetadata("VALID_PERUSUFEC",",oparms:[]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z218PerCod = "";
         Z219PerTip = "";
         Z220PerTDoc = "";
         Z1617PerFec = DateTime.MinValue;
         Z1620PerSts = "";
         Z1627PerVouNum = "";
         Z1623PerUsuCod = "";
         Z1624PerUsuFec = (DateTime)(DateTime.MinValue);
         Z221PerCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A221PerCliCod = "";
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
         A218PerCod = "";
         lblTextblock2_Jsonclick = "";
         A219PerTip = "";
         lblTextblock3_Jsonclick = "";
         A220PerTDoc = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1617PerFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A1616PerCliDsc = "";
         lblTextblock7_Jsonclick = "";
         A1620PerSts = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         A1627PerVouNum = "";
         lblTextblock12_Jsonclick = "";
         A1623PerUsuCod = "";
         lblTextblock13_Jsonclick = "";
         A1624PerUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock14_Jsonclick = "";
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
         Z1616PerCliDsc = "";
         T002V5_A218PerCod = new string[] {""} ;
         T002V5_A219PerTip = new string[] {""} ;
         T002V5_A220PerTDoc = new string[] {""} ;
         T002V5_A1617PerFec = new DateTime[] {DateTime.MinValue} ;
         T002V5_A1616PerCliDsc = new string[] {""} ;
         T002V5_A1620PerSts = new string[] {""} ;
         T002V5_A1625PerVouAno = new short[1] ;
         T002V5_A1626PerVouMes = new short[1] ;
         T002V5_A1621PerTasiCod = new int[1] ;
         T002V5_A1627PerVouNum = new string[] {""} ;
         T002V5_A1623PerUsuCod = new string[] {""} ;
         T002V5_A1624PerUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002V5_A1622PerTipCambio = new decimal[1] ;
         T002V5_A221PerCliCod = new string[] {""} ;
         T002V4_A1616PerCliDsc = new string[] {""} ;
         T002V6_A1616PerCliDsc = new string[] {""} ;
         T002V7_A218PerCod = new string[] {""} ;
         T002V7_A219PerTip = new string[] {""} ;
         T002V7_A220PerTDoc = new string[] {""} ;
         T002V3_A218PerCod = new string[] {""} ;
         T002V3_A219PerTip = new string[] {""} ;
         T002V3_A220PerTDoc = new string[] {""} ;
         T002V3_A1617PerFec = new DateTime[] {DateTime.MinValue} ;
         T002V3_A1620PerSts = new string[] {""} ;
         T002V3_A1625PerVouAno = new short[1] ;
         T002V3_A1626PerVouMes = new short[1] ;
         T002V3_A1621PerTasiCod = new int[1] ;
         T002V3_A1627PerVouNum = new string[] {""} ;
         T002V3_A1623PerUsuCod = new string[] {""} ;
         T002V3_A1624PerUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002V3_A1622PerTipCambio = new decimal[1] ;
         T002V3_A221PerCliCod = new string[] {""} ;
         sMode98 = "";
         T002V8_A218PerCod = new string[] {""} ;
         T002V8_A219PerTip = new string[] {""} ;
         T002V8_A220PerTDoc = new string[] {""} ;
         T002V9_A218PerCod = new string[] {""} ;
         T002V9_A219PerTip = new string[] {""} ;
         T002V9_A220PerTDoc = new string[] {""} ;
         T002V2_A218PerCod = new string[] {""} ;
         T002V2_A219PerTip = new string[] {""} ;
         T002V2_A220PerTDoc = new string[] {""} ;
         T002V2_A1617PerFec = new DateTime[] {DateTime.MinValue} ;
         T002V2_A1620PerSts = new string[] {""} ;
         T002V2_A1625PerVouAno = new short[1] ;
         T002V2_A1626PerVouMes = new short[1] ;
         T002V2_A1621PerTasiCod = new int[1] ;
         T002V2_A1627PerVouNum = new string[] {""} ;
         T002V2_A1623PerUsuCod = new string[] {""} ;
         T002V2_A1624PerUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002V2_A1622PerTipCambio = new decimal[1] ;
         T002V2_A221PerCliCod = new string[] {""} ;
         T002V13_A1616PerCliDsc = new string[] {""} ;
         T002V14_A219PerTip = new string[] {""} ;
         T002V14_A218PerCod = new string[] {""} ;
         T002V14_A220PerTDoc = new string[] {""} ;
         T002V14_A222PerTipCod = new string[] {""} ;
         T002V14_A223PerDocNum = new string[] {""} ;
         T002V15_A218PerCod = new string[] {""} ;
         T002V15_A219PerTip = new string[] {""} ;
         T002V15_A220PerTDoc = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ218PerCod = "";
         ZZ219PerTip = "";
         ZZ220PerTDoc = "";
         ZZ1617PerFec = DateTime.MinValue;
         ZZ221PerCliCod = "";
         ZZ1620PerSts = "";
         ZZ1627PerVouNum = "";
         ZZ1623PerUsuCod = "";
         ZZ1624PerUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1616PerCliDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clpercepcion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpercepcion__default(),
            new Object[][] {
                new Object[] {
               T002V2_A218PerCod, T002V2_A219PerTip, T002V2_A220PerTDoc, T002V2_A1617PerFec, T002V2_A1620PerSts, T002V2_A1625PerVouAno, T002V2_A1626PerVouMes, T002V2_A1621PerTasiCod, T002V2_A1627PerVouNum, T002V2_A1623PerUsuCod,
               T002V2_A1624PerUsuFec, T002V2_A1622PerTipCambio, T002V2_A221PerCliCod
               }
               , new Object[] {
               T002V3_A218PerCod, T002V3_A219PerTip, T002V3_A220PerTDoc, T002V3_A1617PerFec, T002V3_A1620PerSts, T002V3_A1625PerVouAno, T002V3_A1626PerVouMes, T002V3_A1621PerTasiCod, T002V3_A1627PerVouNum, T002V3_A1623PerUsuCod,
               T002V3_A1624PerUsuFec, T002V3_A1622PerTipCambio, T002V3_A221PerCliCod
               }
               , new Object[] {
               T002V4_A1616PerCliDsc
               }
               , new Object[] {
               T002V5_A218PerCod, T002V5_A219PerTip, T002V5_A220PerTDoc, T002V5_A1617PerFec, T002V5_A1616PerCliDsc, T002V5_A1620PerSts, T002V5_A1625PerVouAno, T002V5_A1626PerVouMes, T002V5_A1621PerTasiCod, T002V5_A1627PerVouNum,
               T002V5_A1623PerUsuCod, T002V5_A1624PerUsuFec, T002V5_A1622PerTipCambio, T002V5_A221PerCliCod
               }
               , new Object[] {
               T002V6_A1616PerCliDsc
               }
               , new Object[] {
               T002V7_A218PerCod, T002V7_A219PerTip, T002V7_A220PerTDoc
               }
               , new Object[] {
               T002V8_A218PerCod, T002V8_A219PerTip, T002V8_A220PerTDoc
               }
               , new Object[] {
               T002V9_A218PerCod, T002V9_A219PerTip, T002V9_A220PerTDoc
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002V13_A1616PerCliDsc
               }
               , new Object[] {
               T002V14_A219PerTip, T002V14_A218PerCod, T002V14_A220PerTDoc, T002V14_A222PerTipCod, T002V14_A223PerDocNum
               }
               , new Object[] {
               T002V15_A218PerCod, T002V15_A219PerTip, T002V15_A220PerTDoc
               }
            }
         );
      }

      private short Z1625PerVouAno ;
      private short Z1626PerVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1625PerVouAno ;
      private short A1626PerVouMes ;
      private short GX_JID ;
      private short RcdFound98 ;
      private short nIsDirty_98 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1625PerVouAno ;
      private short ZZ1626PerVouMes ;
      private int Z1621PerTasiCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPerCod_Enabled ;
      private int edtPerTip_Enabled ;
      private int edtPerTDoc_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPerFec_Enabled ;
      private int edtPerCliCod_Enabled ;
      private int edtPerCliDsc_Enabled ;
      private int edtPerSts_Enabled ;
      private int edtPerVouAno_Enabled ;
      private int edtPerVouMes_Enabled ;
      private int A1621PerTasiCod ;
      private int edtPerTasiCod_Enabled ;
      private int edtPerVouNum_Enabled ;
      private int edtPerUsuCod_Enabled ;
      private int edtPerUsuFec_Enabled ;
      private int edtPerTipCambio_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ1621PerTasiCod ;
      private decimal Z1622PerTipCambio ;
      private decimal A1622PerTipCambio ;
      private decimal ZZ1622PerTipCambio ;
      private string sPrefix ;
      private string Z218PerCod ;
      private string Z219PerTip ;
      private string Z1620PerSts ;
      private string Z1627PerVouNum ;
      private string Z1623PerUsuCod ;
      private string Z221PerCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A221PerCliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPerCod_Internalname ;
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
      private string A218PerCod ;
      private string edtPerCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPerTip_Internalname ;
      private string A219PerTip ;
      private string edtPerTip_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPerTDoc_Internalname ;
      private string edtPerTDoc_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPerFec_Internalname ;
      private string edtPerFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPerCliCod_Internalname ;
      private string edtPerCliCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPerCliDsc_Internalname ;
      private string A1616PerCliDsc ;
      private string edtPerCliDsc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPerSts_Internalname ;
      private string A1620PerSts ;
      private string edtPerSts_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPerVouAno_Internalname ;
      private string edtPerVouAno_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPerVouMes_Internalname ;
      private string edtPerVouMes_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPerTasiCod_Internalname ;
      private string edtPerTasiCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtPerVouNum_Internalname ;
      private string A1627PerVouNum ;
      private string edtPerVouNum_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtPerUsuCod_Internalname ;
      private string A1623PerUsuCod ;
      private string edtPerUsuCod_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtPerUsuFec_Internalname ;
      private string edtPerUsuFec_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtPerTipCambio_Internalname ;
      private string edtPerTipCambio_Jsonclick ;
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
      private string Z1616PerCliDsc ;
      private string sMode98 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ218PerCod ;
      private string ZZ219PerTip ;
      private string ZZ221PerCliCod ;
      private string ZZ1620PerSts ;
      private string ZZ1627PerVouNum ;
      private string ZZ1623PerUsuCod ;
      private string ZZ1616PerCliDsc ;
      private DateTime Z1624PerUsuFec ;
      private DateTime A1624PerUsuFec ;
      private DateTime ZZ1624PerUsuFec ;
      private DateTime Z1617PerFec ;
      private DateTime A1617PerFec ;
      private DateTime ZZ1617PerFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z220PerTDoc ;
      private string A220PerTDoc ;
      private string ZZ220PerTDoc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002V5_A218PerCod ;
      private string[] T002V5_A219PerTip ;
      private string[] T002V5_A220PerTDoc ;
      private DateTime[] T002V5_A1617PerFec ;
      private string[] T002V5_A1616PerCliDsc ;
      private string[] T002V5_A1620PerSts ;
      private short[] T002V5_A1625PerVouAno ;
      private short[] T002V5_A1626PerVouMes ;
      private int[] T002V5_A1621PerTasiCod ;
      private string[] T002V5_A1627PerVouNum ;
      private string[] T002V5_A1623PerUsuCod ;
      private DateTime[] T002V5_A1624PerUsuFec ;
      private decimal[] T002V5_A1622PerTipCambio ;
      private string[] T002V5_A221PerCliCod ;
      private string[] T002V4_A1616PerCliDsc ;
      private string[] T002V6_A1616PerCliDsc ;
      private string[] T002V7_A218PerCod ;
      private string[] T002V7_A219PerTip ;
      private string[] T002V7_A220PerTDoc ;
      private string[] T002V3_A218PerCod ;
      private string[] T002V3_A219PerTip ;
      private string[] T002V3_A220PerTDoc ;
      private DateTime[] T002V3_A1617PerFec ;
      private string[] T002V3_A1620PerSts ;
      private short[] T002V3_A1625PerVouAno ;
      private short[] T002V3_A1626PerVouMes ;
      private int[] T002V3_A1621PerTasiCod ;
      private string[] T002V3_A1627PerVouNum ;
      private string[] T002V3_A1623PerUsuCod ;
      private DateTime[] T002V3_A1624PerUsuFec ;
      private decimal[] T002V3_A1622PerTipCambio ;
      private string[] T002V3_A221PerCliCod ;
      private string[] T002V8_A218PerCod ;
      private string[] T002V8_A219PerTip ;
      private string[] T002V8_A220PerTDoc ;
      private string[] T002V9_A218PerCod ;
      private string[] T002V9_A219PerTip ;
      private string[] T002V9_A220PerTDoc ;
      private string[] T002V2_A218PerCod ;
      private string[] T002V2_A219PerTip ;
      private string[] T002V2_A220PerTDoc ;
      private DateTime[] T002V2_A1617PerFec ;
      private string[] T002V2_A1620PerSts ;
      private short[] T002V2_A1625PerVouAno ;
      private short[] T002V2_A1626PerVouMes ;
      private int[] T002V2_A1621PerTasiCod ;
      private string[] T002V2_A1627PerVouNum ;
      private string[] T002V2_A1623PerUsuCod ;
      private DateTime[] T002V2_A1624PerUsuFec ;
      private decimal[] T002V2_A1622PerTipCambio ;
      private string[] T002V2_A221PerCliCod ;
      private string[] T002V13_A1616PerCliDsc ;
      private string[] T002V14_A219PerTip ;
      private string[] T002V14_A218PerCod ;
      private string[] T002V14_A220PerTDoc ;
      private string[] T002V14_A222PerTipCod ;
      private string[] T002V14_A223PerDocNum ;
      private string[] T002V15_A218PerCod ;
      private string[] T002V15_A219PerTip ;
      private string[] T002V15_A220PerTDoc ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clpercepcion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clpercepcion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002V5;
        prmT002V5 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V4;
        prmT002V4 = new Object[] {
        new ParDef("@PerCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002V6;
        prmT002V6 = new Object[] {
        new ParDef("@PerCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002V7;
        prmT002V7 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V3;
        prmT002V3 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V8;
        prmT002V8 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V9;
        prmT002V9 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V2;
        prmT002V2 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V10;
        prmT002V10 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0) ,
        new ParDef("@PerFec",GXType.Date,8,0) ,
        new ParDef("@PerSts",GXType.NChar,1,0) ,
        new ParDef("@PerVouAno",GXType.Int16,4,0) ,
        new ParDef("@PerVouMes",GXType.Int16,2,0) ,
        new ParDef("@PerTasiCod",GXType.Int32,6,0) ,
        new ParDef("@PerVouNum",GXType.NChar,10,0) ,
        new ParDef("@PerUsuCod",GXType.NChar,10,0) ,
        new ParDef("@PerUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@PerTipCambio",GXType.Decimal,15,4) ,
        new ParDef("@PerCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002V11;
        prmT002V11 = new Object[] {
        new ParDef("@PerFec",GXType.Date,8,0) ,
        new ParDef("@PerSts",GXType.NChar,1,0) ,
        new ParDef("@PerVouAno",GXType.Int16,4,0) ,
        new ParDef("@PerVouMes",GXType.Int16,2,0) ,
        new ParDef("@PerTasiCod",GXType.Int32,6,0) ,
        new ParDef("@PerVouNum",GXType.NChar,10,0) ,
        new ParDef("@PerUsuCod",GXType.NChar,10,0) ,
        new ParDef("@PerUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@PerTipCambio",GXType.Decimal,15,4) ,
        new ParDef("@PerCliCod",GXType.NChar,20,0) ,
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V12;
        prmT002V12 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V14;
        prmT002V14 = new Object[] {
        new ParDef("@PerCod",GXType.NChar,10,0) ,
        new ParDef("@PerTip",GXType.NChar,3,0) ,
        new ParDef("@PerTDoc",GXType.NVarChar,3,0)
        };
        Object[] prmT002V15;
        prmT002V15 = new Object[] {
        };
        Object[] prmT002V13;
        prmT002V13 = new Object[] {
        new ParDef("@PerCliCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002V2", "SELECT [PerCod], [PerTip], [PerTDoc], [PerFec], [PerSts], [PerVouAno], [PerVouMes], [PerTasiCod], [PerVouNum], [PerUsuCod], [PerUsuFec], [PerTipCambio], [PerCliCod] AS PerCliCod FROM [CLPERCEPCION] WITH (UPDLOCK) WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V3", "SELECT [PerCod], [PerTip], [PerTDoc], [PerFec], [PerSts], [PerVouAno], [PerVouMes], [PerTasiCod], [PerVouNum], [PerUsuCod], [PerUsuFec], [PerTipCambio], [PerCliCod] AS PerCliCod FROM [CLPERCEPCION] WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V4", "SELECT [CliDsc] AS PerCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @PerCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V5", "SELECT TM1.[PerCod], TM1.[PerTip], TM1.[PerTDoc], TM1.[PerFec], T2.[CliDsc] AS PerCliDsc, TM1.[PerSts], TM1.[PerVouAno], TM1.[PerVouMes], TM1.[PerTasiCod], TM1.[PerVouNum], TM1.[PerUsuCod], TM1.[PerUsuFec], TM1.[PerTipCambio], TM1.[PerCliCod] AS PerCliCod FROM ([CLPERCEPCION] TM1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = TM1.[PerCliCod]) WHERE TM1.[PerCod] = @PerCod and TM1.[PerTip] = @PerTip and TM1.[PerTDoc] = @PerTDoc ORDER BY TM1.[PerCod], TM1.[PerTip], TM1.[PerTDoc]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002V5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V6", "SELECT [CliDsc] AS PerCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @PerCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V7", "SELECT [PerCod], [PerTip], [PerTDoc] FROM [CLPERCEPCION] WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002V7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V8", "SELECT TOP 1 [PerCod], [PerTip], [PerTDoc] FROM [CLPERCEPCION] WHERE ( [PerCod] > @PerCod or [PerCod] = @PerCod and [PerTip] > @PerTip or [PerTip] = @PerTip and [PerCod] = @PerCod and [PerTDoc] > @PerTDoc) ORDER BY [PerCod], [PerTip], [PerTDoc]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002V8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002V9", "SELECT TOP 1 [PerCod], [PerTip], [PerTDoc] FROM [CLPERCEPCION] WHERE ( [PerCod] < @PerCod or [PerCod] = @PerCod and [PerTip] < @PerTip or [PerTip] = @PerTip and [PerCod] = @PerCod and [PerTDoc] < @PerTDoc) ORDER BY [PerCod] DESC, [PerTip] DESC, [PerTDoc] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002V9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002V10", "INSERT INTO [CLPERCEPCION]([PerCod], [PerTip], [PerTDoc], [PerFec], [PerSts], [PerVouAno], [PerVouMes], [PerTasiCod], [PerVouNum], [PerUsuCod], [PerUsuFec], [PerTipCambio], [PerCliCod]) VALUES(@PerCod, @PerTip, @PerTDoc, @PerFec, @PerSts, @PerVouAno, @PerVouMes, @PerTasiCod, @PerVouNum, @PerUsuCod, @PerUsuFec, @PerTipCambio, @PerCliCod)", GxErrorMask.GX_NOMASK,prmT002V10)
           ,new CursorDef("T002V11", "UPDATE [CLPERCEPCION] SET [PerFec]=@PerFec, [PerSts]=@PerSts, [PerVouAno]=@PerVouAno, [PerVouMes]=@PerVouMes, [PerTasiCod]=@PerTasiCod, [PerVouNum]=@PerVouNum, [PerUsuCod]=@PerUsuCod, [PerUsuFec]=@PerUsuFec, [PerTipCambio]=@PerTipCambio, [PerCliCod]=@PerCliCod  WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc", GxErrorMask.GX_NOMASK,prmT002V11)
           ,new CursorDef("T002V12", "DELETE FROM [CLPERCEPCION]  WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc", GxErrorMask.GX_NOMASK,prmT002V12)
           ,new CursorDef("T002V13", "SELECT [CliDsc] AS PerCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @PerCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002V14", "SELECT TOP 1 [PerTip], [PerCod], [PerTDoc], [PerTipCod], [PerDocNum] FROM [CLPERCEPCIONDET] WHERE [PerCod] = @PerCod AND [PerTip] = @PerTip AND [PerTDoc] = @PerTDoc ",true, GxErrorMask.GX_NOMASK, false, this,prmT002V14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002V15", "SELECT [PerCod], [PerTip], [PerTDoc] FROM [CLPERCEPCION] ORDER BY [PerCod], [PerTip], [PerTDoc]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002V15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
  }

}

}
