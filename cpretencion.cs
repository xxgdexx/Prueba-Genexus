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
   public class cpretencion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A302CPRetCod = GetPar( "CPRetCod");
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A302CPRetCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A302CPRetCod = GetPar( "CPRetCod");
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A302CPRetCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A143ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A143ForCod) ;
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
            Form.Meta.addItem("description", "Retención", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpretencion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpretencion( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPRETENCION.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Retención", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetCod_Internalname, StringUtil.RTrim( A302CPRetCod), StringUtil.RTrim( context.localUtil.Format( A302CPRetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha Retención", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCPRetFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCPRetFec_Internalname, context.localUtil.Format(A834CPRetFec, "99/99/99"), context.localUtil.Format( A834CPRetFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         GxWebStd.gx_bitmap( context, edtCPRetFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCPRetFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Proveedor", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Razon Social", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDsc_Internalname, StringUtil.RTrim( A247PrvDsc), StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Dirección", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDir_Internalname, StringUtil.RTrim( A1763PrvDir), StringUtil.RTrim( context.localUtil.Format( A1763PrvDir, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Tipo de Cambio", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A840CPRetTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtCPRetTipCmb_Enabled!=0) ? context.localUtil.Format( A840CPRetTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A840CPRetTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetSts_Internalname, StringUtil.RTrim( A847CPRetSts), StringUtil.RTrim( context.localUtil.Format( A847CPRetSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Impresión", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetImp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A835CPRetImp), 1, 0, ".", "")), StringUtil.LTrim( ((edtCPRetImp_Enabled!=0) ? context.localUtil.Format( (decimal)(A835CPRetImp), "9") : context.localUtil.Format( (decimal)(A835CPRetImp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetImp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "N° Asiento", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetVouNum_Internalname, StringUtil.RTrim( A855CPRetVouNum), StringUtil.RTrim( context.localUtil.Format( A855CPRetVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Tipo de Asiento", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A848CPRetTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCPRetTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A848CPRetTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A848CPRetTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Año", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A853CPRetVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCPRetVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A853CPRetVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A853CPRetVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Mes", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A854CPRetVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCPRetVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A854CPRetVouMes), "Z9") : context.localUtil.Format( (decimal)(A854CPRetVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Usuario", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetUsu_Internalname, StringUtil.RTrim( A851CPRetUsu), StringUtil.RTrim( context.localUtil.Format( A851CPRetUsu, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetUsu_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetUsu_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Fecha Hora", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCPRetUsuF_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCPRetUsuF_Internalname, context.localUtil.TToC( A852CPRetUsuF, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A852CPRetUsuF, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetUsuF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetUsuF_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         GxWebStd.gx_bitmap( context, edtCPRetUsuF_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCPRetUsuF_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Codigo forma pago", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "N° Pago", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPRetPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A845CPRetPagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtCPRetPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A845CPRetPagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A845CPRetPagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Importe Total", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetTotalG_Internalname, StringUtil.LTrim( StringUtil.NToC( A837CPRetTotalG, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetTotalG_Enabled!=0) ? context.localUtil.Format( A837CPRetTotalG, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A837CPRetTotalG, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTotalG_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTotalG_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Total Retención", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetTotalR_Internalname, StringUtil.LTrim( StringUtil.NToC( A841CPRetTotalR, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetTotalR_Enabled!=0) ? context.localUtil.Format( A841CPRetTotalR, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A841CPRetTotalR, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTotalR_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTotalR_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Total Pagado", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A836CPRetPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetPago_Enabled!=0) ? context.localUtil.Format( A836CPRetPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A836CPRetPago, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Total Retención MO", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPRetTotalRO_Internalname, StringUtil.LTrim( StringUtil.NToC( A850CPRetTotalRO, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPRetTotalRO_Enabled!=0) ? context.localUtil.Format( A850CPRetTotalRO, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A850CPRetTotalRO, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPRetTotalRO_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPRetTotalRO_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPRETENCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPRETENCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPRETENCION.htm");
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
            Z302CPRetCod = cgiGet( "Z302CPRetCod");
            Z834CPRetFec = context.localUtil.CToD( cgiGet( "Z834CPRetFec"), 0);
            Z840CPRetTipCmb = context.localUtil.CToN( cgiGet( "Z840CPRetTipCmb"), ".", ",");
            Z847CPRetSts = cgiGet( "Z847CPRetSts");
            Z835CPRetImp = (short)(context.localUtil.CToN( cgiGet( "Z835CPRetImp"), ".", ","));
            Z855CPRetVouNum = cgiGet( "Z855CPRetVouNum");
            Z848CPRetTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z848CPRetTasiCod"), ".", ","));
            Z853CPRetVouAno = (short)(context.localUtil.CToN( cgiGet( "Z853CPRetVouAno"), ".", ","));
            Z854CPRetVouMes = (short)(context.localUtil.CToN( cgiGet( "Z854CPRetVouMes"), ".", ","));
            Z851CPRetUsu = cgiGet( "Z851CPRetUsu");
            Z852CPRetUsuF = context.localUtil.CToT( cgiGet( "Z852CPRetUsuF"), 0);
            Z845CPRetPagReg = (long)(context.localUtil.CToN( cgiGet( "Z845CPRetPagReg"), ".", ","));
            Z832CPRetCadena = cgiGet( "Z832CPRetCadena");
            Z846CPRetREObs = cgiGet( "Z846CPRetREObs");
            Z244PrvCod = cgiGet( "Z244PrvCod");
            Z143ForCod = (int)(context.localUtil.CToN( cgiGet( "Z143ForCod"), ".", ","));
            A832CPRetCadena = cgiGet( "Z832CPRetCadena");
            A846CPRetREObs = cgiGet( "Z846CPRetREObs");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A832CPRetCadena = cgiGet( "CPRETCADENA");
            A846CPRetREObs = cgiGet( "CPRETREOBS");
            /* Read variables values. */
            A302CPRetCod = cgiGet( edtCPRetCod_Internalname);
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            if ( context.localUtil.VCDate( cgiGet( edtCPRetFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Retención"}), 1, "CPRETFEC");
               AnyError = 1;
               GX_FocusControl = edtCPRetFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A834CPRetFec = DateTime.MinValue;
               AssignAttri("", false, "A834CPRetFec", context.localUtil.Format(A834CPRetFec, "99/99/99"));
            }
            else
            {
               A834CPRetFec = context.localUtil.CToD( cgiGet( edtCPRetFec_Internalname), 2);
               AssignAttri("", false, "A834CPRetFec", context.localUtil.Format(A834CPRetFec, "99/99/99"));
            }
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A247PrvDsc = cgiGet( edtPrvDsc_Internalname);
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = cgiGet( edtPrvDir_Internalname);
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtCPRetTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A840CPRetTipCmb = 0;
               AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrimStr( A840CPRetTipCmb, 15, 5));
            }
            else
            {
               A840CPRetTipCmb = context.localUtil.CToN( cgiGet( edtCPRetTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrimStr( A840CPRetTipCmb, 15, 5));
            }
            A847CPRetSts = cgiGet( edtCPRetSts_Internalname);
            AssignAttri("", false, "A847CPRetSts", A847CPRetSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetImp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetImp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETIMP");
               AnyError = 1;
               GX_FocusControl = edtCPRetImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A835CPRetImp = 0;
               AssignAttri("", false, "A835CPRetImp", StringUtil.Str( (decimal)(A835CPRetImp), 1, 0));
            }
            else
            {
               A835CPRetImp = (short)(context.localUtil.CToN( cgiGet( edtCPRetImp_Internalname), ".", ","));
               AssignAttri("", false, "A835CPRetImp", StringUtil.Str( (decimal)(A835CPRetImp), 1, 0));
            }
            A855CPRetVouNum = cgiGet( edtCPRetVouNum_Internalname);
            AssignAttri("", false, "A855CPRetVouNum", A855CPRetVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETTASICOD");
               AnyError = 1;
               GX_FocusControl = edtCPRetTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A848CPRetTasiCod = 0;
               AssignAttri("", false, "A848CPRetTasiCod", StringUtil.LTrimStr( (decimal)(A848CPRetTasiCod), 6, 0));
            }
            else
            {
               A848CPRetTasiCod = (int)(context.localUtil.CToN( cgiGet( edtCPRetTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A848CPRetTasiCod", StringUtil.LTrimStr( (decimal)(A848CPRetTasiCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETVOUANO");
               AnyError = 1;
               GX_FocusControl = edtCPRetVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A853CPRetVouAno = 0;
               AssignAttri("", false, "A853CPRetVouAno", StringUtil.LTrimStr( (decimal)(A853CPRetVouAno), 4, 0));
            }
            else
            {
               A853CPRetVouAno = (short)(context.localUtil.CToN( cgiGet( edtCPRetVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A853CPRetVouAno", StringUtil.LTrimStr( (decimal)(A853CPRetVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETVOUMES");
               AnyError = 1;
               GX_FocusControl = edtCPRetVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A854CPRetVouMes = 0;
               AssignAttri("", false, "A854CPRetVouMes", StringUtil.LTrimStr( (decimal)(A854CPRetVouMes), 2, 0));
            }
            else
            {
               A854CPRetVouMes = (short)(context.localUtil.CToN( cgiGet( edtCPRetVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A854CPRetVouMes", StringUtil.LTrimStr( (decimal)(A854CPRetVouMes), 2, 0));
            }
            A851CPRetUsu = cgiGet( edtCPRetUsu_Internalname);
            AssignAttri("", false, "A851CPRetUsu", A851CPRetUsu);
            if ( context.localUtil.VCDateTime( cgiGet( edtCPRetUsuF_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora"}), 1, "CPRETUSUF");
               AnyError = 1;
               GX_FocusControl = edtCPRetUsuF_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A852CPRetUsuF = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A852CPRetUsuF", context.localUtil.TToC( A852CPRetUsuF, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A852CPRetUsuF = context.localUtil.CToT( cgiGet( edtCPRetUsuF_Internalname));
               AssignAttri("", false, "A852CPRetUsuF", context.localUtil.TToC( A852CPRetUsuF, 8, 5, 0, 3, "/", ":", " "));
            }
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPRetPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPRetPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPRETPAGREG");
               AnyError = 1;
               GX_FocusControl = edtCPRetPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A845CPRetPagReg = 0;
               AssignAttri("", false, "A845CPRetPagReg", StringUtil.LTrimStr( (decimal)(A845CPRetPagReg), 10, 0));
            }
            else
            {
               A845CPRetPagReg = (long)(context.localUtil.CToN( cgiGet( edtCPRetPagReg_Internalname), ".", ","));
               AssignAttri("", false, "A845CPRetPagReg", StringUtil.LTrimStr( (decimal)(A845CPRetPagReg), 10, 0));
            }
            A837CPRetTotalG = context.localUtil.CToN( cgiGet( edtCPRetTotalG_Internalname), ".", ",");
            AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
            A841CPRetTotalR = context.localUtil.CToN( cgiGet( edtCPRetTotalR_Internalname), ".", ",");
            AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
            A836CPRetPago = context.localUtil.CToN( cgiGet( edtCPRetPago_Internalname), ".", ",");
            AssignAttri("", false, "A836CPRetPago", StringUtil.LTrimStr( A836CPRetPago, 15, 2));
            A850CPRetTotalRO = context.localUtil.CToN( cgiGet( edtCPRetTotalRO_Internalname), ".", ",");
            n850CPRetTotalRO = false;
            AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CPRETENCION");
            forbiddenHiddens.Add("CPRetCadena", StringUtil.RTrim( context.localUtil.Format( A832CPRetCadena, "")));
            forbiddenHiddens.Add("CPRetREObs", StringUtil.RTrim( context.localUtil.Format( A846CPRetREObs, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cpretencion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A302CPRetCod = GetPar( "CPRetCod");
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
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
               InitAll3M125( ) ;
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
         DisableAttributes3M125( ) ;
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

      protected void CONFIRM_3M0( )
      {
         BeforeValidate3M125( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3M125( ) ;
            }
            else
            {
               CheckExtendedTable3M125( ) ;
               if ( AnyError == 0 )
               {
                  ZM3M125( 5) ;
                  ZM3M125( 6) ;
                  ZM3M125( 7) ;
                  ZM3M125( 8) ;
               }
               CloseExtendedTableCursors3M125( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3M0( ) ;
         }
      }

      protected void ResetCaption3M0( )
      {
      }

      protected void ZM3M125( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z834CPRetFec = T003M3_A834CPRetFec[0];
               Z840CPRetTipCmb = T003M3_A840CPRetTipCmb[0];
               Z847CPRetSts = T003M3_A847CPRetSts[0];
               Z835CPRetImp = T003M3_A835CPRetImp[0];
               Z855CPRetVouNum = T003M3_A855CPRetVouNum[0];
               Z848CPRetTasiCod = T003M3_A848CPRetTasiCod[0];
               Z853CPRetVouAno = T003M3_A853CPRetVouAno[0];
               Z854CPRetVouMes = T003M3_A854CPRetVouMes[0];
               Z851CPRetUsu = T003M3_A851CPRetUsu[0];
               Z852CPRetUsuF = T003M3_A852CPRetUsuF[0];
               Z845CPRetPagReg = T003M3_A845CPRetPagReg[0];
               Z832CPRetCadena = T003M3_A832CPRetCadena[0];
               Z846CPRetREObs = T003M3_A846CPRetREObs[0];
               Z244PrvCod = T003M3_A244PrvCod[0];
               Z143ForCod = T003M3_A143ForCod[0];
            }
            else
            {
               Z834CPRetFec = A834CPRetFec;
               Z840CPRetTipCmb = A840CPRetTipCmb;
               Z847CPRetSts = A847CPRetSts;
               Z835CPRetImp = A835CPRetImp;
               Z855CPRetVouNum = A855CPRetVouNum;
               Z848CPRetTasiCod = A848CPRetTasiCod;
               Z853CPRetVouAno = A853CPRetVouAno;
               Z854CPRetVouMes = A854CPRetVouMes;
               Z851CPRetUsu = A851CPRetUsu;
               Z852CPRetUsuF = A852CPRetUsuF;
               Z845CPRetPagReg = A845CPRetPagReg;
               Z832CPRetCadena = A832CPRetCadena;
               Z846CPRetREObs = A846CPRetREObs;
               Z244PrvCod = A244PrvCod;
               Z143ForCod = A143ForCod;
            }
         }
         if ( GX_JID == -4 )
         {
            Z302CPRetCod = A302CPRetCod;
            Z834CPRetFec = A834CPRetFec;
            Z840CPRetTipCmb = A840CPRetTipCmb;
            Z847CPRetSts = A847CPRetSts;
            Z835CPRetImp = A835CPRetImp;
            Z855CPRetVouNum = A855CPRetVouNum;
            Z848CPRetTasiCod = A848CPRetTasiCod;
            Z853CPRetVouAno = A853CPRetVouAno;
            Z854CPRetVouMes = A854CPRetVouMes;
            Z851CPRetUsu = A851CPRetUsu;
            Z852CPRetUsuF = A852CPRetUsuF;
            Z845CPRetPagReg = A845CPRetPagReg;
            Z832CPRetCadena = A832CPRetCadena;
            Z846CPRetREObs = A846CPRetREObs;
            Z244PrvCod = A244PrvCod;
            Z143ForCod = A143ForCod;
            Z841CPRetTotalR = A841CPRetTotalR;
            Z837CPRetTotalG = A837CPRetTotalG;
            Z850CPRetTotalRO = A850CPRetTotalRO;
            Z247PrvDsc = A247PrvDsc;
            Z1763PrvDir = A1763PrvDir;
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

      protected void Load3M125( )
      {
         /* Using cursor T003M12 */
         pr_default.execute(6, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound125 = 1;
            A834CPRetFec = T003M12_A834CPRetFec[0];
            AssignAttri("", false, "A834CPRetFec", context.localUtil.Format(A834CPRetFec, "99/99/99"));
            A247PrvDsc = T003M12_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = T003M12_A1763PrvDir[0];
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            A840CPRetTipCmb = T003M12_A840CPRetTipCmb[0];
            AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrimStr( A840CPRetTipCmb, 15, 5));
            A847CPRetSts = T003M12_A847CPRetSts[0];
            AssignAttri("", false, "A847CPRetSts", A847CPRetSts);
            A835CPRetImp = T003M12_A835CPRetImp[0];
            AssignAttri("", false, "A835CPRetImp", StringUtil.Str( (decimal)(A835CPRetImp), 1, 0));
            A855CPRetVouNum = T003M12_A855CPRetVouNum[0];
            AssignAttri("", false, "A855CPRetVouNum", A855CPRetVouNum);
            A848CPRetTasiCod = T003M12_A848CPRetTasiCod[0];
            AssignAttri("", false, "A848CPRetTasiCod", StringUtil.LTrimStr( (decimal)(A848CPRetTasiCod), 6, 0));
            A853CPRetVouAno = T003M12_A853CPRetVouAno[0];
            AssignAttri("", false, "A853CPRetVouAno", StringUtil.LTrimStr( (decimal)(A853CPRetVouAno), 4, 0));
            A854CPRetVouMes = T003M12_A854CPRetVouMes[0];
            AssignAttri("", false, "A854CPRetVouMes", StringUtil.LTrimStr( (decimal)(A854CPRetVouMes), 2, 0));
            A851CPRetUsu = T003M12_A851CPRetUsu[0];
            AssignAttri("", false, "A851CPRetUsu", A851CPRetUsu);
            A852CPRetUsuF = T003M12_A852CPRetUsuF[0];
            AssignAttri("", false, "A852CPRetUsuF", context.localUtil.TToC( A852CPRetUsuF, 8, 5, 0, 3, "/", ":", " "));
            A845CPRetPagReg = T003M12_A845CPRetPagReg[0];
            AssignAttri("", false, "A845CPRetPagReg", StringUtil.LTrimStr( (decimal)(A845CPRetPagReg), 10, 0));
            A832CPRetCadena = T003M12_A832CPRetCadena[0];
            A846CPRetREObs = T003M12_A846CPRetREObs[0];
            A244PrvCod = T003M12_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A143ForCod = T003M12_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A841CPRetTotalR = T003M12_A841CPRetTotalR[0];
            AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
            A837CPRetTotalG = T003M12_A837CPRetTotalG[0];
            AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
            A850CPRetTotalRO = T003M12_A850CPRetTotalRO[0];
            n850CPRetTotalRO = T003M12_n850CPRetTotalRO[0];
            AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
            ZM3M125( -4) ;
         }
         pr_default.close(6);
         OnLoadActions3M125( ) ;
      }

      protected void OnLoadActions3M125( )
      {
         A836CPRetPago = (decimal)(A837CPRetTotalG-A841CPRetTotalR);
         AssignAttri("", false, "A836CPRetPago", StringUtil.LTrimStr( A836CPRetPago, 15, 2));
      }

      protected void CheckExtendedTable3M125( )
      {
         nIsDirty_125 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003M7 */
         pr_default.execute(4, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A841CPRetTotalR = T003M7_A841CPRetTotalR[0];
            AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
            A837CPRetTotalG = T003M7_A837CPRetTotalG[0];
            AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
         }
         else
         {
            nIsDirty_125 = 1;
            A841CPRetTotalR = 0;
            AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
            nIsDirty_125 = 1;
            A837CPRetTotalG = 0;
            AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
         }
         pr_default.close(4);
         nIsDirty_125 = 1;
         A836CPRetPago = (decimal)(A837CPRetTotalG-A841CPRetTotalR);
         AssignAttri("", false, "A836CPRetPago", StringUtil.LTrimStr( A836CPRetPago, 15, 2));
         /* Using cursor T003M9 */
         pr_default.execute(5, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A850CPRetTotalRO = T003M9_A850CPRetTotalRO[0];
            n850CPRetTotalRO = T003M9_n850CPRetTotalRO[0];
            AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
         }
         else
         {
            nIsDirty_125 = 1;
            A850CPRetTotalRO = 0;
            n850CPRetTotalRO = false;
            AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
         }
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A834CPRetFec) || ( DateTimeUtil.ResetTime ( A834CPRetFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Retención fuera de rango", "OutOfRange", 1, "CPRETFEC");
            AnyError = 1;
            GX_FocusControl = edtCPRetFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003M4 */
         pr_default.execute(2, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T003M4_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = T003M4_A1763PrvDir[0];
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A852CPRetUsuF) || ( A852CPRetUsuF >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "CPRETUSUF");
            AnyError = 1;
            GX_FocusControl = edtCPRetUsuF_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003M5 */
         pr_default.execute(3, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors3M125( )
      {
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( string A302CPRetCod )
      {
         /* Using cursor T003M14 */
         pr_default.execute(7, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A841CPRetTotalR = T003M14_A841CPRetTotalR[0];
            AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
            A837CPRetTotalG = T003M14_A837CPRetTotalG[0];
            AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
         }
         else
         {
            A841CPRetTotalR = 0;
            AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
            A837CPRetTotalG = 0;
            AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A841CPRetTotalR, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A837CPRetTotalG, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_8( string A302CPRetCod )
      {
         /* Using cursor T003M16 */
         pr_default.execute(8, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A850CPRetTotalRO = T003M16_A850CPRetTotalRO[0];
            n850CPRetTotalRO = T003M16_n850CPRetTotalRO[0];
            AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
         }
         else
         {
            A850CPRetTotalRO = 0;
            n850CPRetTotalRO = false;
            AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A850CPRetTotalRO, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_5( string A244PrvCod )
      {
         /* Using cursor T003M17 */
         pr_default.execute(9, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T003M17_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = T003M17_A1763PrvDir[0];
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A247PrvDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1763PrvDir))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( int A143ForCod )
      {
         /* Using cursor T003M18 */
         pr_default.execute(10, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
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

      protected void GetKey3M125( )
      {
         /* Using cursor T003M19 */
         pr_default.execute(11, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound125 = 1;
         }
         else
         {
            RcdFound125 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003M3 */
         pr_default.execute(1, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3M125( 4) ;
            RcdFound125 = 1;
            A302CPRetCod = T003M3_A302CPRetCod[0];
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            A834CPRetFec = T003M3_A834CPRetFec[0];
            AssignAttri("", false, "A834CPRetFec", context.localUtil.Format(A834CPRetFec, "99/99/99"));
            A840CPRetTipCmb = T003M3_A840CPRetTipCmb[0];
            AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrimStr( A840CPRetTipCmb, 15, 5));
            A847CPRetSts = T003M3_A847CPRetSts[0];
            AssignAttri("", false, "A847CPRetSts", A847CPRetSts);
            A835CPRetImp = T003M3_A835CPRetImp[0];
            AssignAttri("", false, "A835CPRetImp", StringUtil.Str( (decimal)(A835CPRetImp), 1, 0));
            A855CPRetVouNum = T003M3_A855CPRetVouNum[0];
            AssignAttri("", false, "A855CPRetVouNum", A855CPRetVouNum);
            A848CPRetTasiCod = T003M3_A848CPRetTasiCod[0];
            AssignAttri("", false, "A848CPRetTasiCod", StringUtil.LTrimStr( (decimal)(A848CPRetTasiCod), 6, 0));
            A853CPRetVouAno = T003M3_A853CPRetVouAno[0];
            AssignAttri("", false, "A853CPRetVouAno", StringUtil.LTrimStr( (decimal)(A853CPRetVouAno), 4, 0));
            A854CPRetVouMes = T003M3_A854CPRetVouMes[0];
            AssignAttri("", false, "A854CPRetVouMes", StringUtil.LTrimStr( (decimal)(A854CPRetVouMes), 2, 0));
            A851CPRetUsu = T003M3_A851CPRetUsu[0];
            AssignAttri("", false, "A851CPRetUsu", A851CPRetUsu);
            A852CPRetUsuF = T003M3_A852CPRetUsuF[0];
            AssignAttri("", false, "A852CPRetUsuF", context.localUtil.TToC( A852CPRetUsuF, 8, 5, 0, 3, "/", ":", " "));
            A845CPRetPagReg = T003M3_A845CPRetPagReg[0];
            AssignAttri("", false, "A845CPRetPagReg", StringUtil.LTrimStr( (decimal)(A845CPRetPagReg), 10, 0));
            A832CPRetCadena = T003M3_A832CPRetCadena[0];
            A846CPRetREObs = T003M3_A846CPRetREObs[0];
            A244PrvCod = T003M3_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A143ForCod = T003M3_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            Z302CPRetCod = A302CPRetCod;
            sMode125 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3M125( ) ;
            if ( AnyError == 1 )
            {
               RcdFound125 = 0;
               InitializeNonKey3M125( ) ;
            }
            Gx_mode = sMode125;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound125 = 0;
            InitializeNonKey3M125( ) ;
            sMode125 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode125;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3M125( ) ;
         if ( RcdFound125 == 0 )
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
         RcdFound125 = 0;
         /* Using cursor T003M20 */
         pr_default.execute(12, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T003M20_A302CPRetCod[0], A302CPRetCod) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T003M20_A302CPRetCod[0], A302CPRetCod) > 0 ) ) )
            {
               A302CPRetCod = T003M20_A302CPRetCod[0];
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               RcdFound125 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound125 = 0;
         /* Using cursor T003M21 */
         pr_default.execute(13, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T003M21_A302CPRetCod[0], A302CPRetCod) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T003M21_A302CPRetCod[0], A302CPRetCod) < 0 ) ) )
            {
               A302CPRetCod = T003M21_A302CPRetCod[0];
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               RcdFound125 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3M125( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3M125( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound125 == 1 )
            {
               if ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 )
               {
                  A302CPRetCod = Z302CPRetCod;
                  AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CPRETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3M125( ) ;
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCPRetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3M125( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPRETCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCPRetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCPRetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3M125( ) ;
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
         if ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 )
         {
            A302CPRetCod = Z302CPRetCod;
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCPRetCod_Internalname;
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
         GetKey3M125( ) ;
         if ( RcdFound125 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CPRETCOD");
               AnyError = 1;
               GX_FocusControl = edtCPRetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 )
            {
               A302CPRetCod = Z302CPRetCod;
               AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CPRETCOD");
               AnyError = 1;
               GX_FocusControl = edtCPRetCod_Internalname;
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
            if ( StringUtil.StrCmp(A302CPRetCod, Z302CPRetCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPRETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPRetCod_Internalname;
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
         context.RollbackDataStores("cpretencion",pr_default);
         GX_FocusControl = edtCPRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3M0( ) ;
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
         if ( RcdFound125 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CPRETCOD");
            AnyError = 1;
            GX_FocusControl = edtCPRetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCPRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3M125( ) ;
         if ( RcdFound125 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3M125( ) ;
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
         if ( RcdFound125 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetFec_Internalname;
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
         if ( RcdFound125 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetFec_Internalname;
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
         ScanStart3M125( ) ;
         if ( RcdFound125 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound125 != 0 )
            {
               ScanNext3M125( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPRetFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3M125( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3M125( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003M2 */
            pr_default.execute(0, new Object[] {A302CPRetCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPRETENCION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z834CPRetFec ) != DateTimeUtil.ResetTime ( T003M2_A834CPRetFec[0] ) ) || ( Z840CPRetTipCmb != T003M2_A840CPRetTipCmb[0] ) || ( StringUtil.StrCmp(Z847CPRetSts, T003M2_A847CPRetSts[0]) != 0 ) || ( Z835CPRetImp != T003M2_A835CPRetImp[0] ) || ( StringUtil.StrCmp(Z855CPRetVouNum, T003M2_A855CPRetVouNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z848CPRetTasiCod != T003M2_A848CPRetTasiCod[0] ) || ( Z853CPRetVouAno != T003M2_A853CPRetVouAno[0] ) || ( Z854CPRetVouMes != T003M2_A854CPRetVouMes[0] ) || ( StringUtil.StrCmp(Z851CPRetUsu, T003M2_A851CPRetUsu[0]) != 0 ) || ( Z852CPRetUsuF != T003M2_A852CPRetUsuF[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z845CPRetPagReg != T003M2_A845CPRetPagReg[0] ) || ( StringUtil.StrCmp(Z832CPRetCadena, T003M2_A832CPRetCadena[0]) != 0 ) || ( StringUtil.StrCmp(Z846CPRetREObs, T003M2_A846CPRetREObs[0]) != 0 ) || ( StringUtil.StrCmp(Z244PrvCod, T003M2_A244PrvCod[0]) != 0 ) || ( Z143ForCod != T003M2_A143ForCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z834CPRetFec ) != DateTimeUtil.ResetTime ( T003M2_A834CPRetFec[0] ) )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetFec");
                  GXUtil.WriteLogRaw("Old: ",Z834CPRetFec);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A834CPRetFec[0]);
               }
               if ( Z840CPRetTipCmb != T003M2_A840CPRetTipCmb[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z840CPRetTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A840CPRetTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z847CPRetSts, T003M2_A847CPRetSts[0]) != 0 )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetSts");
                  GXUtil.WriteLogRaw("Old: ",Z847CPRetSts);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A847CPRetSts[0]);
               }
               if ( Z835CPRetImp != T003M2_A835CPRetImp[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetImp");
                  GXUtil.WriteLogRaw("Old: ",Z835CPRetImp);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A835CPRetImp[0]);
               }
               if ( StringUtil.StrCmp(Z855CPRetVouNum, T003M2_A855CPRetVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z855CPRetVouNum);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A855CPRetVouNum[0]);
               }
               if ( Z848CPRetTasiCod != T003M2_A848CPRetTasiCod[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z848CPRetTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A848CPRetTasiCod[0]);
               }
               if ( Z853CPRetVouAno != T003M2_A853CPRetVouAno[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z853CPRetVouAno);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A853CPRetVouAno[0]);
               }
               if ( Z854CPRetVouMes != T003M2_A854CPRetVouMes[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z854CPRetVouMes);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A854CPRetVouMes[0]);
               }
               if ( StringUtil.StrCmp(Z851CPRetUsu, T003M2_A851CPRetUsu[0]) != 0 )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetUsu");
                  GXUtil.WriteLogRaw("Old: ",Z851CPRetUsu);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A851CPRetUsu[0]);
               }
               if ( Z852CPRetUsuF != T003M2_A852CPRetUsuF[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetUsuF");
                  GXUtil.WriteLogRaw("Old: ",Z852CPRetUsuF);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A852CPRetUsuF[0]);
               }
               if ( Z845CPRetPagReg != T003M2_A845CPRetPagReg[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetPagReg");
                  GXUtil.WriteLogRaw("Old: ",Z845CPRetPagReg);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A845CPRetPagReg[0]);
               }
               if ( StringUtil.StrCmp(Z832CPRetCadena, T003M2_A832CPRetCadena[0]) != 0 )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetCadena");
                  GXUtil.WriteLogRaw("Old: ",Z832CPRetCadena);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A832CPRetCadena[0]);
               }
               if ( StringUtil.StrCmp(Z846CPRetREObs, T003M2_A846CPRetREObs[0]) != 0 )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"CPRetREObs");
                  GXUtil.WriteLogRaw("Old: ",Z846CPRetREObs);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A846CPRetREObs[0]);
               }
               if ( StringUtil.StrCmp(Z244PrvCod, T003M2_A244PrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"PrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z244PrvCod);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A244PrvCod[0]);
               }
               if ( Z143ForCod != T003M2_A143ForCod[0] )
               {
                  GXUtil.WriteLog("cpretencion:[seudo value changed for attri]"+"ForCod");
                  GXUtil.WriteLogRaw("Old: ",Z143ForCod);
                  GXUtil.WriteLogRaw("Current: ",T003M2_A143ForCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPRETENCION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3M125( )
      {
         BeforeValidate3M125( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3M125( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3M125( 0) ;
            CheckOptimisticConcurrency3M125( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3M125( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3M125( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003M22 */
                     pr_default.execute(14, new Object[] {A302CPRetCod, A834CPRetFec, A840CPRetTipCmb, A847CPRetSts, A835CPRetImp, A855CPRetVouNum, A848CPRetTasiCod, A853CPRetVouAno, A854CPRetVouMes, A851CPRetUsu, A852CPRetUsuF, A845CPRetPagReg, A832CPRetCadena, A846CPRetREObs, A244PrvCod, A143ForCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CPRETENCION");
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
                           ResetCaption3M0( ) ;
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
               Load3M125( ) ;
            }
            EndLevel3M125( ) ;
         }
         CloseExtendedTableCursors3M125( ) ;
      }

      protected void Update3M125( )
      {
         BeforeValidate3M125( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3M125( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3M125( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3M125( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3M125( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003M23 */
                     pr_default.execute(15, new Object[] {A834CPRetFec, A840CPRetTipCmb, A847CPRetSts, A835CPRetImp, A855CPRetVouNum, A848CPRetTasiCod, A853CPRetVouAno, A854CPRetVouMes, A851CPRetUsu, A852CPRetUsuF, A845CPRetPagReg, A832CPRetCadena, A846CPRetREObs, A244PrvCod, A143ForCod, A302CPRetCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CPRETENCION");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPRETENCION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3M125( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3M0( ) ;
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
            EndLevel3M125( ) ;
         }
         CloseExtendedTableCursors3M125( ) ;
      }

      protected void DeferredUpdate3M125( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3M125( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3M125( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3M125( ) ;
            AfterConfirm3M125( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3M125( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003M24 */
                  pr_default.execute(16, new Object[] {A302CPRetCod});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CPRETENCION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound125 == 0 )
                        {
                           InitAll3M125( ) ;
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
                        ResetCaption3M0( ) ;
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
         sMode125 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3M125( ) ;
         Gx_mode = sMode125;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3M125( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003M26 */
            pr_default.execute(17, new Object[] {A302CPRetCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A841CPRetTotalR = T003M26_A841CPRetTotalR[0];
               AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
               A837CPRetTotalG = T003M26_A837CPRetTotalG[0];
               AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
            }
            else
            {
               A841CPRetTotalR = 0;
               AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
               A837CPRetTotalG = 0;
               AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
            }
            pr_default.close(17);
            A836CPRetPago = (decimal)(A837CPRetTotalG-A841CPRetTotalR);
            AssignAttri("", false, "A836CPRetPago", StringUtil.LTrimStr( A836CPRetPago, 15, 2));
            /* Using cursor T003M28 */
            pr_default.execute(18, new Object[] {A302CPRetCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A850CPRetTotalRO = T003M28_A850CPRetTotalRO[0];
               n850CPRetTotalRO = T003M28_n850CPRetTotalRO[0];
               AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
            }
            else
            {
               A850CPRetTotalRO = 0;
               n850CPRetTotalRO = false;
               AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
            }
            pr_default.close(18);
            /* Using cursor T003M29 */
            pr_default.execute(19, new Object[] {A244PrvCod});
            A247PrvDsc = T003M29_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1763PrvDir = T003M29_A1763PrvDir[0];
            AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003M30 */
            pr_default.execute(20, new Object[] {A302CPRetCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Retención Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel3M125( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3M125( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(17);
            pr_default.close(18);
            context.CommitDataStores("cpretencion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(17);
            pr_default.close(18);
            context.RollbackDataStores("cpretencion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3M125( )
      {
         /* Using cursor T003M31 */
         pr_default.execute(21);
         RcdFound125 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound125 = 1;
            A302CPRetCod = T003M31_A302CPRetCod[0];
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3M125( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound125 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound125 = 1;
            A302CPRetCod = T003M31_A302CPRetCod[0];
            AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
         }
      }

      protected void ScanEnd3M125( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm3M125( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3M125( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3M125( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3M125( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3M125( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3M125( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3M125( )
      {
         edtCPRetCod_Enabled = 0;
         AssignProp("", false, edtCPRetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetCod_Enabled), 5, 0), true);
         edtCPRetFec_Enabled = 0;
         AssignProp("", false, edtCPRetFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetFec_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtPrvDsc_Enabled = 0;
         AssignProp("", false, edtPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDsc_Enabled), 5, 0), true);
         edtPrvDir_Enabled = 0;
         AssignProp("", false, edtPrvDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDir_Enabled), 5, 0), true);
         edtCPRetTipCmb_Enabled = 0;
         AssignProp("", false, edtCPRetTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTipCmb_Enabled), 5, 0), true);
         edtCPRetSts_Enabled = 0;
         AssignProp("", false, edtCPRetSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetSts_Enabled), 5, 0), true);
         edtCPRetImp_Enabled = 0;
         AssignProp("", false, edtCPRetImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetImp_Enabled), 5, 0), true);
         edtCPRetVouNum_Enabled = 0;
         AssignProp("", false, edtCPRetVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetVouNum_Enabled), 5, 0), true);
         edtCPRetTasiCod_Enabled = 0;
         AssignProp("", false, edtCPRetTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTasiCod_Enabled), 5, 0), true);
         edtCPRetVouAno_Enabled = 0;
         AssignProp("", false, edtCPRetVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetVouAno_Enabled), 5, 0), true);
         edtCPRetVouMes_Enabled = 0;
         AssignProp("", false, edtCPRetVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetVouMes_Enabled), 5, 0), true);
         edtCPRetUsu_Enabled = 0;
         AssignProp("", false, edtCPRetUsu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetUsu_Enabled), 5, 0), true);
         edtCPRetUsuF_Enabled = 0;
         AssignProp("", false, edtCPRetUsuF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetUsuF_Enabled), 5, 0), true);
         edtForCod_Enabled = 0;
         AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         edtCPRetPagReg_Enabled = 0;
         AssignProp("", false, edtCPRetPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetPagReg_Enabled), 5, 0), true);
         edtCPRetTotalG_Enabled = 0;
         AssignProp("", false, edtCPRetTotalG_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTotalG_Enabled), 5, 0), true);
         edtCPRetTotalR_Enabled = 0;
         AssignProp("", false, edtCPRetTotalR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTotalR_Enabled), 5, 0), true);
         edtCPRetPago_Enabled = 0;
         AssignProp("", false, edtCPRetPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetPago_Enabled), 5, 0), true);
         edtCPRetTotalRO_Enabled = 0;
         AssignProp("", false, edtCPRetTotalRO_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPRetTotalRO_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3M125( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810251815", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpretencion.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CPRETENCION");
         forbiddenHiddens.Add("CPRetCadena", StringUtil.RTrim( context.localUtil.Format( A832CPRetCadena, "")));
         forbiddenHiddens.Add("CPRetREObs", StringUtil.RTrim( context.localUtil.Format( A846CPRetREObs, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cpretencion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z302CPRetCod", StringUtil.RTrim( Z302CPRetCod));
         GxWebStd.gx_hidden_field( context, "Z834CPRetFec", context.localUtil.DToC( Z834CPRetFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z840CPRetTipCmb", StringUtil.LTrim( StringUtil.NToC( Z840CPRetTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z847CPRetSts", StringUtil.RTrim( Z847CPRetSts));
         GxWebStd.gx_hidden_field( context, "Z835CPRetImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z835CPRetImp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z855CPRetVouNum", StringUtil.RTrim( Z855CPRetVouNum));
         GxWebStd.gx_hidden_field( context, "Z848CPRetTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z848CPRetTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z853CPRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z853CPRetVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z854CPRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z854CPRetVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z851CPRetUsu", StringUtil.RTrim( Z851CPRetUsu));
         GxWebStd.gx_hidden_field( context, "Z852CPRetUsuF", context.localUtil.TToC( Z852CPRetUsuF, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z845CPRetPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z845CPRetPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z832CPRetCadena", Z832CPRetCadena);
         GxWebStd.gx_hidden_field( context, "Z846CPRetREObs", Z846CPRetREObs);
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CPRETCADENA", A832CPRetCadena);
         GxWebStd.gx_hidden_field( context, "CPRETREOBS", A846CPRetREObs);
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
         return formatLink("cpretencion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPRETENCION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Retención" ;
      }

      protected void InitializeNonKey3M125( )
      {
         A836CPRetPago = 0;
         AssignAttri("", false, "A836CPRetPago", StringUtil.LTrimStr( A836CPRetPago, 15, 2));
         A841CPRetTotalR = 0;
         AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrimStr( A841CPRetTotalR, 15, 2));
         A837CPRetTotalG = 0;
         AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrimStr( A837CPRetTotalG, 15, 2));
         A834CPRetFec = DateTime.MinValue;
         AssignAttri("", false, "A834CPRetFec", context.localUtil.Format(A834CPRetFec, "99/99/99"));
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         A247PrvDsc = "";
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1763PrvDir = "";
         AssignAttri("", false, "A1763PrvDir", A1763PrvDir);
         A840CPRetTipCmb = 0;
         AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrimStr( A840CPRetTipCmb, 15, 5));
         A847CPRetSts = "";
         AssignAttri("", false, "A847CPRetSts", A847CPRetSts);
         A835CPRetImp = 0;
         AssignAttri("", false, "A835CPRetImp", StringUtil.Str( (decimal)(A835CPRetImp), 1, 0));
         A855CPRetVouNum = "";
         AssignAttri("", false, "A855CPRetVouNum", A855CPRetVouNum);
         A848CPRetTasiCod = 0;
         AssignAttri("", false, "A848CPRetTasiCod", StringUtil.LTrimStr( (decimal)(A848CPRetTasiCod), 6, 0));
         A853CPRetVouAno = 0;
         AssignAttri("", false, "A853CPRetVouAno", StringUtil.LTrimStr( (decimal)(A853CPRetVouAno), 4, 0));
         A854CPRetVouMes = 0;
         AssignAttri("", false, "A854CPRetVouMes", StringUtil.LTrimStr( (decimal)(A854CPRetVouMes), 2, 0));
         A851CPRetUsu = "";
         AssignAttri("", false, "A851CPRetUsu", A851CPRetUsu);
         A852CPRetUsuF = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A852CPRetUsuF", context.localUtil.TToC( A852CPRetUsuF, 8, 5, 0, 3, "/", ":", " "));
         A143ForCod = 0;
         AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         A845CPRetPagReg = 0;
         AssignAttri("", false, "A845CPRetPagReg", StringUtil.LTrimStr( (decimal)(A845CPRetPagReg), 10, 0));
         A850CPRetTotalRO = 0;
         n850CPRetTotalRO = false;
         AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrimStr( A850CPRetTotalRO, 15, 2));
         A832CPRetCadena = "";
         AssignAttri("", false, "A832CPRetCadena", A832CPRetCadena);
         A846CPRetREObs = "";
         AssignAttri("", false, "A846CPRetREObs", A846CPRetREObs);
         Z834CPRetFec = DateTime.MinValue;
         Z840CPRetTipCmb = 0;
         Z847CPRetSts = "";
         Z835CPRetImp = 0;
         Z855CPRetVouNum = "";
         Z848CPRetTasiCod = 0;
         Z853CPRetVouAno = 0;
         Z854CPRetVouMes = 0;
         Z851CPRetUsu = "";
         Z852CPRetUsuF = (DateTime)(DateTime.MinValue);
         Z845CPRetPagReg = 0;
         Z832CPRetCadena = "";
         Z846CPRetREObs = "";
         Z244PrvCod = "";
         Z143ForCod = 0;
      }

      protected void InitAll3M125( )
      {
         A302CPRetCod = "";
         AssignAttri("", false, "A302CPRetCod", A302CPRetCod);
         InitializeNonKey3M125( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251832", true, true);
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
         context.AddJavascriptSource("cpretencion.js", "?202281810251832", false, true);
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
         edtCPRetCod_Internalname = "CPRETCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCPRetFec_Internalname = "CPRETFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPrvCod_Internalname = "PRVCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPrvDsc_Internalname = "PRVDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPrvDir_Internalname = "PRVDIR";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCPRetTipCmb_Internalname = "CPRETTIPCMB";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCPRetSts_Internalname = "CPRETSTS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCPRetImp_Internalname = "CPRETIMP";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCPRetVouNum_Internalname = "CPRETVOUNUM";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCPRetTasiCod_Internalname = "CPRETTASICOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCPRetVouAno_Internalname = "CPRETVOUANO";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtCPRetVouMes_Internalname = "CPRETVOUMES";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtCPRetUsu_Internalname = "CPRETUSU";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtCPRetUsuF_Internalname = "CPRETUSUF";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtForCod_Internalname = "FORCOD";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtCPRetPagReg_Internalname = "CPRETPAGREG";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtCPRetTotalG_Internalname = "CPRETTOTALG";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtCPRetTotalR_Internalname = "CPRETTOTALR";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtCPRetPago_Internalname = "CPRETPAGO";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtCPRetTotalRO_Internalname = "CPRETTOTALRO";
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
         Form.Caption = "Retención";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCPRetTotalRO_Jsonclick = "";
         edtCPRetTotalRO_Enabled = 0;
         edtCPRetPago_Jsonclick = "";
         edtCPRetPago_Enabled = 0;
         edtCPRetTotalR_Jsonclick = "";
         edtCPRetTotalR_Enabled = 0;
         edtCPRetTotalG_Jsonclick = "";
         edtCPRetTotalG_Enabled = 0;
         edtCPRetPagReg_Jsonclick = "";
         edtCPRetPagReg_Enabled = 1;
         edtForCod_Jsonclick = "";
         edtForCod_Enabled = 1;
         edtCPRetUsuF_Jsonclick = "";
         edtCPRetUsuF_Enabled = 1;
         edtCPRetUsu_Jsonclick = "";
         edtCPRetUsu_Enabled = 1;
         edtCPRetVouMes_Jsonclick = "";
         edtCPRetVouMes_Enabled = 1;
         edtCPRetVouAno_Jsonclick = "";
         edtCPRetVouAno_Enabled = 1;
         edtCPRetTasiCod_Jsonclick = "";
         edtCPRetTasiCod_Enabled = 1;
         edtCPRetVouNum_Jsonclick = "";
         edtCPRetVouNum_Enabled = 1;
         edtCPRetImp_Jsonclick = "";
         edtCPRetImp_Enabled = 1;
         edtCPRetSts_Jsonclick = "";
         edtCPRetSts_Enabled = 1;
         edtCPRetTipCmb_Jsonclick = "";
         edtCPRetTipCmb_Enabled = 1;
         edtPrvDir_Jsonclick = "";
         edtPrvDir_Enabled = 0;
         edtPrvDsc_Jsonclick = "";
         edtPrvDsc_Enabled = 0;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         edtCPRetFec_Jsonclick = "";
         edtCPRetFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCPRetCod_Jsonclick = "";
         edtCPRetCod_Enabled = 1;
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
         GX_FocusControl = edtCPRetFec_Internalname;
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

      public void Valid_Cpretcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T003M26 */
         pr_default.execute(17, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A841CPRetTotalR = T003M26_A841CPRetTotalR[0];
            A837CPRetTotalG = T003M26_A837CPRetTotalG[0];
         }
         else
         {
            A841CPRetTotalR = 0;
            A837CPRetTotalG = 0;
         }
         pr_default.close(17);
         A836CPRetPago = (decimal)(A837CPRetTotalG-A841CPRetTotalR);
         /* Using cursor T003M28 */
         pr_default.execute(18, new Object[] {A302CPRetCod});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A850CPRetTotalRO = T003M28_A850CPRetTotalRO[0];
            n850CPRetTotalRO = T003M28_n850CPRetTotalRO[0];
         }
         else
         {
            A850CPRetTotalRO = 0;
            n850CPRetTotalRO = false;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A834CPRetFec", context.localUtil.Format(A834CPRetFec, "99/99/99"));
         AssignAttri("", false, "A244PrvCod", StringUtil.RTrim( A244PrvCod));
         AssignAttri("", false, "A840CPRetTipCmb", StringUtil.LTrim( StringUtil.NToC( A840CPRetTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A847CPRetSts", StringUtil.RTrim( A847CPRetSts));
         AssignAttri("", false, "A835CPRetImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A835CPRetImp), 1, 0, ".", "")));
         AssignAttri("", false, "A855CPRetVouNum", StringUtil.RTrim( A855CPRetVouNum));
         AssignAttri("", false, "A848CPRetTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A848CPRetTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A853CPRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A853CPRetVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A854CPRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A854CPRetVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A851CPRetUsu", StringUtil.RTrim( A851CPRetUsu));
         AssignAttri("", false, "A852CPRetUsuF", context.localUtil.TToC( A852CPRetUsuF, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A845CPRetPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(A845CPRetPagReg), 10, 0, ".", "")));
         AssignAttri("", false, "A832CPRetCadena", A832CPRetCadena);
         AssignAttri("", false, "A846CPRetREObs", A846CPRetREObs);
         AssignAttri("", false, "A841CPRetTotalR", StringUtil.LTrim( StringUtil.NToC( A841CPRetTotalR, 15, 2, ".", "")));
         AssignAttri("", false, "A837CPRetTotalG", StringUtil.LTrim( StringUtil.NToC( A837CPRetTotalG, 15, 2, ".", "")));
         AssignAttri("", false, "A836CPRetPago", StringUtil.LTrim( StringUtil.NToC( A836CPRetPago, 15, 2, ".", "")));
         AssignAttri("", false, "A850CPRetTotalRO", StringUtil.LTrim( StringUtil.NToC( A850CPRetTotalRO, 15, 2, ".", "")));
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A1763PrvDir", StringUtil.RTrim( A1763PrvDir));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z302CPRetCod", StringUtil.RTrim( Z302CPRetCod));
         GxWebStd.gx_hidden_field( context, "Z834CPRetFec", context.localUtil.Format(Z834CPRetFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z840CPRetTipCmb", StringUtil.LTrim( StringUtil.NToC( Z840CPRetTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z847CPRetSts", StringUtil.RTrim( Z847CPRetSts));
         GxWebStd.gx_hidden_field( context, "Z835CPRetImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z835CPRetImp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z855CPRetVouNum", StringUtil.RTrim( Z855CPRetVouNum));
         GxWebStd.gx_hidden_field( context, "Z848CPRetTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z848CPRetTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z853CPRetVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z853CPRetVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z854CPRetVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z854CPRetVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z851CPRetUsu", StringUtil.RTrim( Z851CPRetUsu));
         GxWebStd.gx_hidden_field( context, "Z852CPRetUsuF", context.localUtil.TToC( Z852CPRetUsuF, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z845CPRetPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z845CPRetPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z832CPRetCadena", Z832CPRetCadena);
         GxWebStd.gx_hidden_field( context, "Z846CPRetREObs", Z846CPRetREObs);
         GxWebStd.gx_hidden_field( context, "Z841CPRetTotalR", StringUtil.LTrim( StringUtil.NToC( Z841CPRetTotalR, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z837CPRetTotalG", StringUtil.LTrim( StringUtil.NToC( Z837CPRetTotalG, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z836CPRetPago", StringUtil.LTrim( StringUtil.NToC( Z836CPRetPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z850CPRetTotalRO", StringUtil.LTrim( StringUtil.NToC( Z850CPRetTotalRO, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1763PrvDir", StringUtil.RTrim( Z1763PrvDir));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prvcod( )
      {
         /* Using cursor T003M29 */
         pr_default.execute(19, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
         }
         A247PrvDsc = T003M29_A247PrvDsc[0];
         A1763PrvDir = T003M29_A1763PrvDir[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A1763PrvDir", StringUtil.RTrim( A1763PrvDir));
      }

      public void Valid_Forcod( )
      {
         /* Using cursor T003M32 */
         pr_default.execute(22, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
         }
         pr_default.close(22);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A832CPRetCadena',fld:'CPRETCADENA',pic:''},{av:'A846CPRetREObs',fld:'CPRETREOBS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CPRETCOD","{handler:'Valid_Cpretcod',iparms:[{av:'A846CPRetREObs',fld:'CPRETREOBS',pic:''},{av:'A832CPRetCadena',fld:'CPRETCADENA',pic:''},{av:'A302CPRetCod',fld:'CPRETCOD',pic:''},{av:'A837CPRetTotalG',fld:'CPRETTOTALG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A841CPRetTotalR',fld:'CPRETTOTALR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CPRETCOD",",oparms:[{av:'A834CPRetFec',fld:'CPRETFEC',pic:''},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A840CPRetTipCmb',fld:'CPRETTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A847CPRetSts',fld:'CPRETSTS',pic:''},{av:'A835CPRetImp',fld:'CPRETIMP',pic:'9'},{av:'A855CPRetVouNum',fld:'CPRETVOUNUM',pic:''},{av:'A848CPRetTasiCod',fld:'CPRETTASICOD',pic:'ZZZZZ9'},{av:'A853CPRetVouAno',fld:'CPRETVOUANO',pic:'ZZZ9'},{av:'A854CPRetVouMes',fld:'CPRETVOUMES',pic:'Z9'},{av:'A851CPRetUsu',fld:'CPRETUSU',pic:''},{av:'A852CPRetUsuF',fld:'CPRETUSUF',pic:'99/99/99 99:99'},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'A845CPRetPagReg',fld:'CPRETPAGREG',pic:'ZZZZZZZZZ9'},{av:'A832CPRetCadena',fld:'CPRETCADENA',pic:''},{av:'A846CPRetREObs',fld:'CPRETREOBS',pic:''},{av:'A841CPRetTotalR',fld:'CPRETTOTALR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A837CPRetTotalG',fld:'CPRETTOTALG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A836CPRetPago',fld:'CPRETPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A850CPRetTotalRO',fld:'CPRETTOTALRO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z302CPRetCod'},{av:'Z834CPRetFec'},{av:'Z244PrvCod'},{av:'Z840CPRetTipCmb'},{av:'Z847CPRetSts'},{av:'Z835CPRetImp'},{av:'Z855CPRetVouNum'},{av:'Z848CPRetTasiCod'},{av:'Z853CPRetVouAno'},{av:'Z854CPRetVouMes'},{av:'Z851CPRetUsu'},{av:'Z852CPRetUsuF'},{av:'Z143ForCod'},{av:'Z845CPRetPagReg'},{av:'Z832CPRetCadena'},{av:'Z846CPRetREObs'},{av:'Z841CPRetTotalR'},{av:'Z837CPRetTotalG'},{av:'Z836CPRetPago'},{av:'Z850CPRetTotalRO'},{av:'Z247PrvDsc'},{av:'Z1763PrvDir'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CPRETFEC","{handler:'Valid_Cpretfec',iparms:[]");
         setEventMetadata("VALID_CPRETFEC",",oparms:[]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1763PrvDir',fld:'PRVDIR',pic:''}]}");
         setEventMetadata("VALID_CPRETUSUF","{handler:'Valid_Cpretusuf',iparms:[]");
         setEventMetadata("VALID_CPRETUSUF",",oparms:[]}");
         setEventMetadata("VALID_FORCOD","{handler:'Valid_Forcod',iparms:[{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_FORCOD",",oparms:[]}");
         setEventMetadata("VALID_CPRETTOTALG","{handler:'Valid_Cprettotalg',iparms:[]");
         setEventMetadata("VALID_CPRETTOTALG",",oparms:[]}");
         setEventMetadata("VALID_CPRETTOTALR","{handler:'Valid_Cprettotalr',iparms:[]");
         setEventMetadata("VALID_CPRETTOTALR",",oparms:[]}");
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
         pr_default.close(19);
         pr_default.close(22);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z302CPRetCod = "";
         Z834CPRetFec = DateTime.MinValue;
         Z847CPRetSts = "";
         Z855CPRetVouNum = "";
         Z851CPRetUsu = "";
         Z852CPRetUsuF = (DateTime)(DateTime.MinValue);
         Z832CPRetCadena = "";
         Z846CPRetREObs = "";
         Z244PrvCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A302CPRetCod = "";
         A244PrvCod = "";
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
         A834CPRetFec = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A247PrvDsc = "";
         lblTextblock5_Jsonclick = "";
         A1763PrvDir = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A847CPRetSts = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A855CPRetVouNum = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A851CPRetUsu = "";
         lblTextblock14_Jsonclick = "";
         A852CPRetUsuF = (DateTime)(DateTime.MinValue);
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A832CPRetCadena = "";
         A846CPRetREObs = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z247PrvDsc = "";
         Z1763PrvDir = "";
         T003M12_A302CPRetCod = new string[] {""} ;
         T003M12_A834CPRetFec = new DateTime[] {DateTime.MinValue} ;
         T003M12_A247PrvDsc = new string[] {""} ;
         T003M12_A1763PrvDir = new string[] {""} ;
         T003M12_A840CPRetTipCmb = new decimal[1] ;
         T003M12_A847CPRetSts = new string[] {""} ;
         T003M12_A835CPRetImp = new short[1] ;
         T003M12_A855CPRetVouNum = new string[] {""} ;
         T003M12_A848CPRetTasiCod = new int[1] ;
         T003M12_A853CPRetVouAno = new short[1] ;
         T003M12_A854CPRetVouMes = new short[1] ;
         T003M12_A851CPRetUsu = new string[] {""} ;
         T003M12_A852CPRetUsuF = new DateTime[] {DateTime.MinValue} ;
         T003M12_A845CPRetPagReg = new long[1] ;
         T003M12_A832CPRetCadena = new string[] {""} ;
         T003M12_A846CPRetREObs = new string[] {""} ;
         T003M12_A244PrvCod = new string[] {""} ;
         T003M12_A143ForCod = new int[1] ;
         T003M12_A841CPRetTotalR = new decimal[1] ;
         T003M12_A837CPRetTotalG = new decimal[1] ;
         T003M12_A850CPRetTotalRO = new decimal[1] ;
         T003M12_n850CPRetTotalRO = new bool[] {false} ;
         T003M7_A841CPRetTotalR = new decimal[1] ;
         T003M7_A837CPRetTotalG = new decimal[1] ;
         T003M9_A850CPRetTotalRO = new decimal[1] ;
         T003M9_n850CPRetTotalRO = new bool[] {false} ;
         T003M4_A247PrvDsc = new string[] {""} ;
         T003M4_A1763PrvDir = new string[] {""} ;
         T003M5_A143ForCod = new int[1] ;
         T003M14_A841CPRetTotalR = new decimal[1] ;
         T003M14_A837CPRetTotalG = new decimal[1] ;
         T003M16_A850CPRetTotalRO = new decimal[1] ;
         T003M16_n850CPRetTotalRO = new bool[] {false} ;
         T003M17_A247PrvDsc = new string[] {""} ;
         T003M17_A1763PrvDir = new string[] {""} ;
         T003M18_A143ForCod = new int[1] ;
         T003M19_A302CPRetCod = new string[] {""} ;
         T003M3_A302CPRetCod = new string[] {""} ;
         T003M3_A834CPRetFec = new DateTime[] {DateTime.MinValue} ;
         T003M3_A840CPRetTipCmb = new decimal[1] ;
         T003M3_A847CPRetSts = new string[] {""} ;
         T003M3_A835CPRetImp = new short[1] ;
         T003M3_A855CPRetVouNum = new string[] {""} ;
         T003M3_A848CPRetTasiCod = new int[1] ;
         T003M3_A853CPRetVouAno = new short[1] ;
         T003M3_A854CPRetVouMes = new short[1] ;
         T003M3_A851CPRetUsu = new string[] {""} ;
         T003M3_A852CPRetUsuF = new DateTime[] {DateTime.MinValue} ;
         T003M3_A845CPRetPagReg = new long[1] ;
         T003M3_A832CPRetCadena = new string[] {""} ;
         T003M3_A846CPRetREObs = new string[] {""} ;
         T003M3_A244PrvCod = new string[] {""} ;
         T003M3_A143ForCod = new int[1] ;
         sMode125 = "";
         T003M20_A302CPRetCod = new string[] {""} ;
         T003M21_A302CPRetCod = new string[] {""} ;
         T003M2_A302CPRetCod = new string[] {""} ;
         T003M2_A834CPRetFec = new DateTime[] {DateTime.MinValue} ;
         T003M2_A840CPRetTipCmb = new decimal[1] ;
         T003M2_A847CPRetSts = new string[] {""} ;
         T003M2_A835CPRetImp = new short[1] ;
         T003M2_A855CPRetVouNum = new string[] {""} ;
         T003M2_A848CPRetTasiCod = new int[1] ;
         T003M2_A853CPRetVouAno = new short[1] ;
         T003M2_A854CPRetVouMes = new short[1] ;
         T003M2_A851CPRetUsu = new string[] {""} ;
         T003M2_A852CPRetUsuF = new DateTime[] {DateTime.MinValue} ;
         T003M2_A845CPRetPagReg = new long[1] ;
         T003M2_A832CPRetCadena = new string[] {""} ;
         T003M2_A846CPRetREObs = new string[] {""} ;
         T003M2_A244PrvCod = new string[] {""} ;
         T003M2_A143ForCod = new int[1] ;
         T003M26_A841CPRetTotalR = new decimal[1] ;
         T003M26_A837CPRetTotalG = new decimal[1] ;
         T003M28_A850CPRetTotalRO = new decimal[1] ;
         T003M28_n850CPRetTotalRO = new bool[] {false} ;
         T003M29_A247PrvDsc = new string[] {""} ;
         T003M29_A1763PrvDir = new string[] {""} ;
         T003M30_A302CPRetCod = new string[] {""} ;
         T003M30_A303CPRetPrvCod = new string[] {""} ;
         T003M30_A304CPRetTipCod = new string[] {""} ;
         T003M30_A305CPRetComCod = new string[] {""} ;
         T003M31_A302CPRetCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ302CPRetCod = "";
         ZZ834CPRetFec = DateTime.MinValue;
         ZZ244PrvCod = "";
         ZZ847CPRetSts = "";
         ZZ855CPRetVouNum = "";
         ZZ851CPRetUsu = "";
         ZZ852CPRetUsuF = (DateTime)(DateTime.MinValue);
         ZZ832CPRetCadena = "";
         ZZ846CPRetREObs = "";
         ZZ247PrvDsc = "";
         ZZ1763PrvDir = "";
         T003M32_A143ForCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpretencion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpretencion__default(),
            new Object[][] {
                new Object[] {
               T003M2_A302CPRetCod, T003M2_A834CPRetFec, T003M2_A840CPRetTipCmb, T003M2_A847CPRetSts, T003M2_A835CPRetImp, T003M2_A855CPRetVouNum, T003M2_A848CPRetTasiCod, T003M2_A853CPRetVouAno, T003M2_A854CPRetVouMes, T003M2_A851CPRetUsu,
               T003M2_A852CPRetUsuF, T003M2_A845CPRetPagReg, T003M2_A832CPRetCadena, T003M2_A846CPRetREObs, T003M2_A244PrvCod, T003M2_A143ForCod
               }
               , new Object[] {
               T003M3_A302CPRetCod, T003M3_A834CPRetFec, T003M3_A840CPRetTipCmb, T003M3_A847CPRetSts, T003M3_A835CPRetImp, T003M3_A855CPRetVouNum, T003M3_A848CPRetTasiCod, T003M3_A853CPRetVouAno, T003M3_A854CPRetVouMes, T003M3_A851CPRetUsu,
               T003M3_A852CPRetUsuF, T003M3_A845CPRetPagReg, T003M3_A832CPRetCadena, T003M3_A846CPRetREObs, T003M3_A244PrvCod, T003M3_A143ForCod
               }
               , new Object[] {
               T003M4_A247PrvDsc, T003M4_A1763PrvDir
               }
               , new Object[] {
               T003M5_A143ForCod
               }
               , new Object[] {
               T003M7_A841CPRetTotalR, T003M7_A837CPRetTotalG
               }
               , new Object[] {
               T003M9_A850CPRetTotalRO, T003M9_n850CPRetTotalRO
               }
               , new Object[] {
               T003M12_A302CPRetCod, T003M12_A834CPRetFec, T003M12_A247PrvDsc, T003M12_A1763PrvDir, T003M12_A840CPRetTipCmb, T003M12_A847CPRetSts, T003M12_A835CPRetImp, T003M12_A855CPRetVouNum, T003M12_A848CPRetTasiCod, T003M12_A853CPRetVouAno,
               T003M12_A854CPRetVouMes, T003M12_A851CPRetUsu, T003M12_A852CPRetUsuF, T003M12_A845CPRetPagReg, T003M12_A832CPRetCadena, T003M12_A846CPRetREObs, T003M12_A244PrvCod, T003M12_A143ForCod, T003M12_A841CPRetTotalR, T003M12_A837CPRetTotalG,
               T003M12_A850CPRetTotalRO, T003M12_n850CPRetTotalRO
               }
               , new Object[] {
               T003M14_A841CPRetTotalR, T003M14_A837CPRetTotalG
               }
               , new Object[] {
               T003M16_A850CPRetTotalRO, T003M16_n850CPRetTotalRO
               }
               , new Object[] {
               T003M17_A247PrvDsc, T003M17_A1763PrvDir
               }
               , new Object[] {
               T003M18_A143ForCod
               }
               , new Object[] {
               T003M19_A302CPRetCod
               }
               , new Object[] {
               T003M20_A302CPRetCod
               }
               , new Object[] {
               T003M21_A302CPRetCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003M26_A841CPRetTotalR, T003M26_A837CPRetTotalG
               }
               , new Object[] {
               T003M28_A850CPRetTotalRO, T003M28_n850CPRetTotalRO
               }
               , new Object[] {
               T003M29_A247PrvDsc, T003M29_A1763PrvDir
               }
               , new Object[] {
               T003M30_A302CPRetCod, T003M30_A303CPRetPrvCod, T003M30_A304CPRetTipCod, T003M30_A305CPRetComCod
               }
               , new Object[] {
               T003M31_A302CPRetCod
               }
               , new Object[] {
               T003M32_A143ForCod
               }
            }
         );
      }

      private short Z835CPRetImp ;
      private short Z853CPRetVouAno ;
      private short Z854CPRetVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A835CPRetImp ;
      private short A853CPRetVouAno ;
      private short A854CPRetVouMes ;
      private short GX_JID ;
      private short RcdFound125 ;
      private short nIsDirty_125 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ835CPRetImp ;
      private short ZZ853CPRetVouAno ;
      private short ZZ854CPRetVouMes ;
      private int Z848CPRetTasiCod ;
      private int Z143ForCod ;
      private int A143ForCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCPRetCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCPRetFec_Enabled ;
      private int edtPrvCod_Enabled ;
      private int edtPrvDsc_Enabled ;
      private int edtPrvDir_Enabled ;
      private int edtCPRetTipCmb_Enabled ;
      private int edtCPRetSts_Enabled ;
      private int edtCPRetImp_Enabled ;
      private int edtCPRetVouNum_Enabled ;
      private int A848CPRetTasiCod ;
      private int edtCPRetTasiCod_Enabled ;
      private int edtCPRetVouAno_Enabled ;
      private int edtCPRetVouMes_Enabled ;
      private int edtCPRetUsu_Enabled ;
      private int edtCPRetUsuF_Enabled ;
      private int edtForCod_Enabled ;
      private int edtCPRetPagReg_Enabled ;
      private int edtCPRetTotalG_Enabled ;
      private int edtCPRetTotalR_Enabled ;
      private int edtCPRetPago_Enabled ;
      private int edtCPRetTotalRO_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ848CPRetTasiCod ;
      private int ZZ143ForCod ;
      private long Z845CPRetPagReg ;
      private long A845CPRetPagReg ;
      private long ZZ845CPRetPagReg ;
      private decimal Z840CPRetTipCmb ;
      private decimal A840CPRetTipCmb ;
      private decimal A837CPRetTotalG ;
      private decimal A841CPRetTotalR ;
      private decimal A836CPRetPago ;
      private decimal A850CPRetTotalRO ;
      private decimal Z841CPRetTotalR ;
      private decimal Z837CPRetTotalG ;
      private decimal Z850CPRetTotalRO ;
      private decimal Z836CPRetPago ;
      private decimal ZZ840CPRetTipCmb ;
      private decimal ZZ841CPRetTotalR ;
      private decimal ZZ837CPRetTotalG ;
      private decimal ZZ836CPRetPago ;
      private decimal ZZ850CPRetTotalRO ;
      private string sPrefix ;
      private string Z302CPRetCod ;
      private string Z847CPRetSts ;
      private string Z855CPRetVouNum ;
      private string Z851CPRetUsu ;
      private string Z244PrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A302CPRetCod ;
      private string A244PrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCPRetCod_Internalname ;
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
      private string edtCPRetCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCPRetFec_Internalname ;
      private string edtCPRetFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPrvCod_Internalname ;
      private string edtPrvCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPrvDsc_Internalname ;
      private string A247PrvDsc ;
      private string edtPrvDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPrvDir_Internalname ;
      private string A1763PrvDir ;
      private string edtPrvDir_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCPRetTipCmb_Internalname ;
      private string edtCPRetTipCmb_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCPRetSts_Internalname ;
      private string A847CPRetSts ;
      private string edtCPRetSts_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCPRetImp_Internalname ;
      private string edtCPRetImp_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCPRetVouNum_Internalname ;
      private string A855CPRetVouNum ;
      private string edtCPRetVouNum_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCPRetTasiCod_Internalname ;
      private string edtCPRetTasiCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCPRetVouAno_Internalname ;
      private string edtCPRetVouAno_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtCPRetVouMes_Internalname ;
      private string edtCPRetVouMes_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtCPRetUsu_Internalname ;
      private string A851CPRetUsu ;
      private string edtCPRetUsu_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtCPRetUsuF_Internalname ;
      private string edtCPRetUsuF_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtForCod_Internalname ;
      private string edtForCod_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtCPRetPagReg_Internalname ;
      private string edtCPRetPagReg_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtCPRetTotalG_Internalname ;
      private string edtCPRetTotalG_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtCPRetTotalR_Internalname ;
      private string edtCPRetTotalR_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtCPRetPago_Internalname ;
      private string edtCPRetPago_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtCPRetTotalRO_Internalname ;
      private string edtCPRetTotalRO_Jsonclick ;
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
      private string Z247PrvDsc ;
      private string Z1763PrvDir ;
      private string sMode125 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ302CPRetCod ;
      private string ZZ244PrvCod ;
      private string ZZ847CPRetSts ;
      private string ZZ855CPRetVouNum ;
      private string ZZ851CPRetUsu ;
      private string ZZ247PrvDsc ;
      private string ZZ1763PrvDir ;
      private DateTime Z852CPRetUsuF ;
      private DateTime A852CPRetUsuF ;
      private DateTime ZZ852CPRetUsuF ;
      private DateTime Z834CPRetFec ;
      private DateTime A834CPRetFec ;
      private DateTime ZZ834CPRetFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n850CPRetTotalRO ;
      private bool Gx_longc ;
      private string Z832CPRetCadena ;
      private string Z846CPRetREObs ;
      private string A832CPRetCadena ;
      private string A846CPRetREObs ;
      private string ZZ832CPRetCadena ;
      private string ZZ846CPRetREObs ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003M12_A302CPRetCod ;
      private DateTime[] T003M12_A834CPRetFec ;
      private string[] T003M12_A247PrvDsc ;
      private string[] T003M12_A1763PrvDir ;
      private decimal[] T003M12_A840CPRetTipCmb ;
      private string[] T003M12_A847CPRetSts ;
      private short[] T003M12_A835CPRetImp ;
      private string[] T003M12_A855CPRetVouNum ;
      private int[] T003M12_A848CPRetTasiCod ;
      private short[] T003M12_A853CPRetVouAno ;
      private short[] T003M12_A854CPRetVouMes ;
      private string[] T003M12_A851CPRetUsu ;
      private DateTime[] T003M12_A852CPRetUsuF ;
      private long[] T003M12_A845CPRetPagReg ;
      private string[] T003M12_A832CPRetCadena ;
      private string[] T003M12_A846CPRetREObs ;
      private string[] T003M12_A244PrvCod ;
      private int[] T003M12_A143ForCod ;
      private decimal[] T003M12_A841CPRetTotalR ;
      private decimal[] T003M12_A837CPRetTotalG ;
      private decimal[] T003M12_A850CPRetTotalRO ;
      private bool[] T003M12_n850CPRetTotalRO ;
      private decimal[] T003M7_A841CPRetTotalR ;
      private decimal[] T003M7_A837CPRetTotalG ;
      private decimal[] T003M9_A850CPRetTotalRO ;
      private bool[] T003M9_n850CPRetTotalRO ;
      private string[] T003M4_A247PrvDsc ;
      private string[] T003M4_A1763PrvDir ;
      private int[] T003M5_A143ForCod ;
      private decimal[] T003M14_A841CPRetTotalR ;
      private decimal[] T003M14_A837CPRetTotalG ;
      private decimal[] T003M16_A850CPRetTotalRO ;
      private bool[] T003M16_n850CPRetTotalRO ;
      private string[] T003M17_A247PrvDsc ;
      private string[] T003M17_A1763PrvDir ;
      private int[] T003M18_A143ForCod ;
      private string[] T003M19_A302CPRetCod ;
      private string[] T003M3_A302CPRetCod ;
      private DateTime[] T003M3_A834CPRetFec ;
      private decimal[] T003M3_A840CPRetTipCmb ;
      private string[] T003M3_A847CPRetSts ;
      private short[] T003M3_A835CPRetImp ;
      private string[] T003M3_A855CPRetVouNum ;
      private int[] T003M3_A848CPRetTasiCod ;
      private short[] T003M3_A853CPRetVouAno ;
      private short[] T003M3_A854CPRetVouMes ;
      private string[] T003M3_A851CPRetUsu ;
      private DateTime[] T003M3_A852CPRetUsuF ;
      private long[] T003M3_A845CPRetPagReg ;
      private string[] T003M3_A832CPRetCadena ;
      private string[] T003M3_A846CPRetREObs ;
      private string[] T003M3_A244PrvCod ;
      private int[] T003M3_A143ForCod ;
      private string[] T003M20_A302CPRetCod ;
      private string[] T003M21_A302CPRetCod ;
      private string[] T003M2_A302CPRetCod ;
      private DateTime[] T003M2_A834CPRetFec ;
      private decimal[] T003M2_A840CPRetTipCmb ;
      private string[] T003M2_A847CPRetSts ;
      private short[] T003M2_A835CPRetImp ;
      private string[] T003M2_A855CPRetVouNum ;
      private int[] T003M2_A848CPRetTasiCod ;
      private short[] T003M2_A853CPRetVouAno ;
      private short[] T003M2_A854CPRetVouMes ;
      private string[] T003M2_A851CPRetUsu ;
      private DateTime[] T003M2_A852CPRetUsuF ;
      private long[] T003M2_A845CPRetPagReg ;
      private string[] T003M2_A832CPRetCadena ;
      private string[] T003M2_A846CPRetREObs ;
      private string[] T003M2_A244PrvCod ;
      private int[] T003M2_A143ForCod ;
      private decimal[] T003M26_A841CPRetTotalR ;
      private decimal[] T003M26_A837CPRetTotalG ;
      private decimal[] T003M28_A850CPRetTotalRO ;
      private bool[] T003M28_n850CPRetTotalRO ;
      private string[] T003M29_A247PrvDsc ;
      private string[] T003M29_A1763PrvDir ;
      private string[] T003M30_A302CPRetCod ;
      private string[] T003M30_A303CPRetPrvCod ;
      private string[] T003M30_A304CPRetTipCod ;
      private string[] T003M30_A305CPRetComCod ;
      private string[] T003M31_A302CPRetCod ;
      private int[] T003M32_A143ForCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpretencion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpretencion__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003M12;
        prmT003M12 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M7;
        prmT003M7 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M9;
        prmT003M9 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M4;
        prmT003M4 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003M5;
        prmT003M5 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT003M14;
        prmT003M14 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M16;
        prmT003M16 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M17;
        prmT003M17 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003M18;
        prmT003M18 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT003M19;
        prmT003M19 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M3;
        prmT003M3 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M20;
        prmT003M20 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M21;
        prmT003M21 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M2;
        prmT003M2 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M22;
        prmT003M22 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0) ,
        new ParDef("@CPRetFec",GXType.Date,8,0) ,
        new ParDef("@CPRetTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@CPRetSts",GXType.NChar,1,0) ,
        new ParDef("@CPRetImp",GXType.Int16,1,0) ,
        new ParDef("@CPRetVouNum",GXType.NChar,10,0) ,
        new ParDef("@CPRetTasiCod",GXType.Int32,6,0) ,
        new ParDef("@CPRetVouAno",GXType.Int16,4,0) ,
        new ParDef("@CPRetVouMes",GXType.Int16,2,0) ,
        new ParDef("@CPRetUsu",GXType.NChar,10,0) ,
        new ParDef("@CPRetUsuF",GXType.DateTime,8,5) ,
        new ParDef("@CPRetPagReg",GXType.Decimal,10,0) ,
        new ParDef("@CPRetCadena",GXType.NVarChar,50,0) ,
        new ParDef("@CPRetREObs",GXType.NVarChar,200,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT003M23;
        prmT003M23 = new Object[] {
        new ParDef("@CPRetFec",GXType.Date,8,0) ,
        new ParDef("@CPRetTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@CPRetSts",GXType.NChar,1,0) ,
        new ParDef("@CPRetImp",GXType.Int16,1,0) ,
        new ParDef("@CPRetVouNum",GXType.NChar,10,0) ,
        new ParDef("@CPRetTasiCod",GXType.Int32,6,0) ,
        new ParDef("@CPRetVouAno",GXType.Int16,4,0) ,
        new ParDef("@CPRetVouMes",GXType.Int16,2,0) ,
        new ParDef("@CPRetUsu",GXType.NChar,10,0) ,
        new ParDef("@CPRetUsuF",GXType.DateTime,8,5) ,
        new ParDef("@CPRetPagReg",GXType.Decimal,10,0) ,
        new ParDef("@CPRetCadena",GXType.NVarChar,50,0) ,
        new ParDef("@CPRetREObs",GXType.NVarChar,200,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M24;
        prmT003M24 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M30;
        prmT003M30 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M31;
        prmT003M31 = new Object[] {
        };
        Object[] prmT003M26;
        prmT003M26 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M28;
        prmT003M28 = new Object[] {
        new ParDef("@CPRetCod",GXType.NChar,10,0)
        };
        Object[] prmT003M29;
        prmT003M29 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003M32;
        prmT003M32 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003M2", "SELECT [CPRetCod], [CPRetFec], [CPRetTipCmb], [CPRetSts], [CPRetImp], [CPRetVouNum], [CPRetTasiCod], [CPRetVouAno], [CPRetVouMes], [CPRetUsu], [CPRetUsuF], [CPRetPagReg], [CPRetCadena], [CPRetREObs], [PrvCod], [ForCod] FROM [CPRETENCION] WITH (UPDLOCK) WHERE [CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M3", "SELECT [CPRetCod], [CPRetFec], [CPRetTipCmb], [CPRetSts], [CPRetImp], [CPRetVouNum], [CPRetTasiCod], [CPRetVouAno], [CPRetVouMes], [CPRetUsu], [CPRetUsuF], [CPRetPagReg], [CPRetCadena], [CPRetREObs], [PrvCod], [ForCod] FROM [CPRETENCION] WHERE [CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M4", "SELECT [PrvDsc], [PrvDir] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M5", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M7", "SELECT COALESCE( T1.[CPRetTotalR], 0) AS CPRetTotalR, COALESCE( T1.[CPRetTotalG], 0) AS CPRetTotalG FROM (SELECT SUM(CASE  WHEN T4.[CPMonCod] = 2 THEN ROUND(T2.[CPRetRet] * CAST(T3.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T2.[CPRetRet] END) AS CPRetTotalR, T2.[CPRetCod], SUM(CASE  WHEN T4.[CPMonCod] = 2 THEN ROUND(T2.[CPRetTotal] * CAST(T3.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T2.[CPRetTotal] END) AS CPRetTotalG FROM (([CPRETENCIONDET] T2 INNER JOIN [CPRETENCION] T3 WITH (UPDLOCK) ON T3.[CPRetCod] = T2.[CPRetCod]) INNER JOIN [CPCUENTAPAGAR] T4 ON T4.[CPTipCod] = T2.[CPRetTipCod] AND T4.[CPComCod] = T2.[CPRetComCod] AND T4.[CPPrvCod] = T2.[CPRetPrvCod]) GROUP BY T2.[CPRetCod] ) T1 WHERE T1.[CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M9", "SELECT COALESCE( T1.[CPRetTotalRO], 0) AS CPRetTotalRO FROM (SELECT SUM([CPRetRet]) AS CPRetTotalRO, [CPRetCod] FROM [CPRETENCIONDET] GROUP BY [CPRetCod] ) T1 WHERE T1.[CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M12", "SELECT TM1.[CPRetCod], TM1.[CPRetFec], T4.[PrvDsc], T4.[PrvDir], TM1.[CPRetTipCmb], TM1.[CPRetSts], TM1.[CPRetImp], TM1.[CPRetVouNum], TM1.[CPRetTasiCod], TM1.[CPRetVouAno], TM1.[CPRetVouMes], TM1.[CPRetUsu], TM1.[CPRetUsuF], TM1.[CPRetPagReg], TM1.[CPRetCadena], TM1.[CPRetREObs], TM1.[PrvCod], TM1.[ForCod], COALESCE( T2.[CPRetTotalR], 0) AS CPRetTotalR, COALESCE( T2.[CPRetTotalG], 0) AS CPRetTotalG, COALESCE( T3.[CPRetTotalRO], 0) AS CPRetTotalRO FROM ((([CPRETENCION] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CPMonCod] = 2 THEN ROUND(T5.[CPRetRet] * CAST(TM1.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T5.[CPRetRet] END) AS CPRetTotalR, T5.[CPRetCod], SUM(CASE  WHEN T7.[CPMonCod] = 2 THEN ROUND(T5.[CPRetTotal] * CAST(TM1.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T5.[CPRetTotal] END) AS CPRetTotalG FROM (([CPRETENCIONDET] T5 INNER JOIN [CPRETENCION] TM1 ON TM1.[CPRetCod] = T5.[CPRetCod]) INNER JOIN [CPCUENTAPAGAR] T7 ON T7.[CPTipCod] = T5.[CPRetTipCod] AND T7.[CPComCod] = T5.[CPRetComCod] AND T7.[CPPrvCod] = T5.[CPRetPrvCod]) GROUP BY T5.[CPRetCod] ) T2 ON T2.[CPRetCod] = TM1.[CPRetCod]) LEFT JOIN (SELECT SUM([CPRetRet]) AS CPRetTotalRO, [CPRetCod] FROM [CPRETENCIONDET] GROUP BY [CPRetCod] ) T3 ON T3.[CPRetCod] = TM1.[CPRetCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = TM1.[PrvCod]) WHERE TM1.[CPRetCod] = @CPRetCod ORDER BY TM1.[CPRetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003M12,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M14", "SELECT COALESCE( T1.[CPRetTotalR], 0) AS CPRetTotalR, COALESCE( T1.[CPRetTotalG], 0) AS CPRetTotalG FROM (SELECT SUM(CASE  WHEN T4.[CPMonCod] = 2 THEN ROUND(T2.[CPRetRet] * CAST(T3.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T2.[CPRetRet] END) AS CPRetTotalR, T2.[CPRetCod], SUM(CASE  WHEN T4.[CPMonCod] = 2 THEN ROUND(T2.[CPRetTotal] * CAST(T3.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T2.[CPRetTotal] END) AS CPRetTotalG FROM (([CPRETENCIONDET] T2 INNER JOIN [CPRETENCION] T3 WITH (UPDLOCK) ON T3.[CPRetCod] = T2.[CPRetCod]) INNER JOIN [CPCUENTAPAGAR] T4 ON T4.[CPTipCod] = T2.[CPRetTipCod] AND T4.[CPComCod] = T2.[CPRetComCod] AND T4.[CPPrvCod] = T2.[CPRetPrvCod]) GROUP BY T2.[CPRetCod] ) T1 WHERE T1.[CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M16", "SELECT COALESCE( T1.[CPRetTotalRO], 0) AS CPRetTotalRO FROM (SELECT SUM([CPRetRet]) AS CPRetTotalRO, [CPRetCod] FROM [CPRETENCIONDET] GROUP BY [CPRetCod] ) T1 WHERE T1.[CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M17", "SELECT [PrvDsc], [PrvDir] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M18", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M19", "SELECT [CPRetCod] FROM [CPRETENCION] WHERE [CPRetCod] = @CPRetCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003M19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M20", "SELECT TOP 1 [CPRetCod] FROM [CPRETENCION] WHERE ( [CPRetCod] > @CPRetCod) ORDER BY [CPRetCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003M20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003M21", "SELECT TOP 1 [CPRetCod] FROM [CPRETENCION] WHERE ( [CPRetCod] < @CPRetCod) ORDER BY [CPRetCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003M21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003M22", "INSERT INTO [CPRETENCION]([CPRetCod], [CPRetFec], [CPRetTipCmb], [CPRetSts], [CPRetImp], [CPRetVouNum], [CPRetTasiCod], [CPRetVouAno], [CPRetVouMes], [CPRetUsu], [CPRetUsuF], [CPRetPagReg], [CPRetCadena], [CPRetREObs], [PrvCod], [ForCod]) VALUES(@CPRetCod, @CPRetFec, @CPRetTipCmb, @CPRetSts, @CPRetImp, @CPRetVouNum, @CPRetTasiCod, @CPRetVouAno, @CPRetVouMes, @CPRetUsu, @CPRetUsuF, @CPRetPagReg, @CPRetCadena, @CPRetREObs, @PrvCod, @ForCod)", GxErrorMask.GX_NOMASK,prmT003M22)
           ,new CursorDef("T003M23", "UPDATE [CPRETENCION] SET [CPRetFec]=@CPRetFec, [CPRetTipCmb]=@CPRetTipCmb, [CPRetSts]=@CPRetSts, [CPRetImp]=@CPRetImp, [CPRetVouNum]=@CPRetVouNum, [CPRetTasiCod]=@CPRetTasiCod, [CPRetVouAno]=@CPRetVouAno, [CPRetVouMes]=@CPRetVouMes, [CPRetUsu]=@CPRetUsu, [CPRetUsuF]=@CPRetUsuF, [CPRetPagReg]=@CPRetPagReg, [CPRetCadena]=@CPRetCadena, [CPRetREObs]=@CPRetREObs, [PrvCod]=@PrvCod, [ForCod]=@ForCod  WHERE [CPRetCod] = @CPRetCod", GxErrorMask.GX_NOMASK,prmT003M23)
           ,new CursorDef("T003M24", "DELETE FROM [CPRETENCION]  WHERE [CPRetCod] = @CPRetCod", GxErrorMask.GX_NOMASK,prmT003M24)
           ,new CursorDef("T003M26", "SELECT COALESCE( T1.[CPRetTotalR], 0) AS CPRetTotalR, COALESCE( T1.[CPRetTotalG], 0) AS CPRetTotalG FROM (SELECT SUM(CASE  WHEN T4.[CPMonCod] = 2 THEN ROUND(T2.[CPRetRet] * CAST(T3.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T2.[CPRetRet] END) AS CPRetTotalR, T2.[CPRetCod], SUM(CASE  WHEN T4.[CPMonCod] = 2 THEN ROUND(T2.[CPRetTotal] * CAST(T3.[CPRetTipCmb] AS decimal( 25, 10)), 2) ELSE T2.[CPRetTotal] END) AS CPRetTotalG FROM (([CPRETENCIONDET] T2 INNER JOIN [CPRETENCION] T3 WITH (UPDLOCK) ON T3.[CPRetCod] = T2.[CPRetCod]) INNER JOIN [CPCUENTAPAGAR] T4 ON T4.[CPTipCod] = T2.[CPRetTipCod] AND T4.[CPComCod] = T2.[CPRetComCod] AND T4.[CPPrvCod] = T2.[CPRetPrvCod]) GROUP BY T2.[CPRetCod] ) T1 WHERE T1.[CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M28", "SELECT COALESCE( T1.[CPRetTotalRO], 0) AS CPRetTotalRO FROM (SELECT SUM([CPRetRet]) AS CPRetTotalRO, [CPRetCod] FROM [CPRETENCIONDET] GROUP BY [CPRetCod] ) T1 WHERE T1.[CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M29", "SELECT [PrvDsc], [PrvDir] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M30", "SELECT TOP 1 [CPRetCod], [CPRetPrvCod] AS CPRetPrvCod, [CPRetTipCod] AS CPRetTipCod, [CPRetComCod] AS CPRetComCod FROM [CPRETENCIONDET] WHERE [CPRetCod] = @CPRetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003M31", "SELECT [CPRetCod] FROM [CPRETENCION] ORDER BY [CPRetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003M31,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003M32", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003M32,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((long[]) buf[13])[0] = rslt.getLong(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(21);
              ((bool[]) buf[21])[0] = rslt.wasNull(21);
              return;
           case 7 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 18 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
