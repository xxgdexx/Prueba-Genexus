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
   public class cpcuentapagar : GXDataArea
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
            A260CPTipCod = GetPar( "CPTipCod");
            AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A260CPTipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A262CPPrvCod = GetPar( "CPPrvCod");
            AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A262CPPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A263CPMonCod = (int)(NumberUtil.Val( GetPar( "CPMonCod"), "."));
            AssignAttri("", false, "A263CPMonCod", StringUtil.LTrimStr( (decimal)(A263CPMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A263CPMonCod) ;
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
            Form.Meta.addItem("description", "Cuentas por Pagar", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpcuentapagar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpcuentapagar( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPCUENTAPAGAR.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPTipCod_Internalname, StringUtil.RTrim( A260CPTipCod), StringUtil.RTrim( context.localUtil.Format( A260CPTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Numero Doc.", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPComCod_Internalname, StringUtil.RTrim( A261CPComCod), StringUtil.RTrim( context.localUtil.Format( A261CPComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPComCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "R.U.C.", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPPrvCod_Internalname, StringUtil.RTrim( A262CPPrvCod), StringUtil.RTrim( context.localUtil.Format( A262CPPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCPFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCPFech_Internalname, context.localUtil.Format(A264CPFech, "99/99/99"), context.localUtil.Format( A264CPFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         GxWebStd.gx_bitmap( context, edtCPFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCPFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha Vcto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCPFVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCPFVcto_Internalname, context.localUtil.Format(A817CPFVcto, "99/99/99"), context.localUtil.Format( A817CPFVcto, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPFVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPFVcto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         GxWebStd.gx_bitmap( context, edtCPFVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCPFVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Fecha Registro", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCPFReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCPFReg_Internalname, context.localUtil.Format(A816CPFReg, "99/99/99"), context.localUtil.Format( A816CPFReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPFReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPFReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         GxWebStd.gx_bitmap( context, edtCPFReg_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCPFReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo Moneda", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A263CPMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCPMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A263CPMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A263CPMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Importe Total", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPImpTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A820CPImpTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPImpTotal_Enabled!=0) ? context.localUtil.Format( A820CPImpTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A820CPImpTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPImpTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPImpTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Pago", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPImpPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A818CPImpPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPImpPago_Enabled!=0) ? context.localUtil.Format( A818CPImpPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A818CPImpPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPImpPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPImpPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Estado", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPEstado_Internalname, StringUtil.RTrim( A815CPEstado), StringUtil.RTrim( context.localUtil.Format( A815CPEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPEstado_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Total Signo", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPImpTotalSig_Internalname, StringUtil.LTrim( StringUtil.NToC( A822CPImpTotalSig, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPImpTotalSig_Enabled!=0) ? context.localUtil.Format( A822CPImpTotalSig, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A822CPImpTotalSig, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPImpTotalSig_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPImpTotalSig_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Proveedor", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPPrvDsc_Internalname, StringUtil.RTrim( A831CPPrvDsc), StringUtil.RTrim( context.localUtil.Format( A831CPPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Saldo", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPImpSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A819CPImpSaldo, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPImpSaldo_Enabled!=0) ? context.localUtil.Format( A819CPImpSaldo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A819CPImpSaldo, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPImpSaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPImpSaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Saldo Signo", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCUENTAPAGAR.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPImpSaldoSig_Internalname, StringUtil.LTrim( StringUtil.NToC( A821CPImpSaldoSig, 17, 2, ".", "")), StringUtil.LTrim( ((edtCPImpSaldoSig_Enabled!=0) ? context.localUtil.Format( A821CPImpSaldoSig, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A821CPImpSaldoSig, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPImpSaldoSig_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPImpSaldoSig_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCUENTAPAGAR.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCUENTAPAGAR.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPCUENTAPAGAR.htm");
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
            Z260CPTipCod = cgiGet( "Z260CPTipCod");
            Z261CPComCod = cgiGet( "Z261CPComCod");
            Z262CPPrvCod = cgiGet( "Z262CPPrvCod");
            Z264CPFech = context.localUtil.CToD( cgiGet( "Z264CPFech"), 0);
            Z817CPFVcto = context.localUtil.CToD( cgiGet( "Z817CPFVcto"), 0);
            Z816CPFReg = context.localUtil.CToD( cgiGet( "Z816CPFReg"), 0);
            Z820CPImpTotal = context.localUtil.CToN( cgiGet( "Z820CPImpTotal"), ".", ",");
            Z818CPImpPago = context.localUtil.CToN( cgiGet( "Z818CPImpPago"), ".", ",");
            Z815CPEstado = cgiGet( "Z815CPEstado");
            Z263CPMonCod = (int)(context.localUtil.CToN( cgiGet( "Z263CPMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A511TipSigno = (short)(context.localUtil.CToN( cgiGet( "TIPSIGNO"), ".", ","));
            n511TipSigno = false;
            A856CPTipAbr = cgiGet( "CPTIPABR");
            A830CPMonDsc = cgiGet( "CPMONDSC");
            /* Read variables values. */
            A260CPTipCod = cgiGet( edtCPTipCod_Internalname);
            AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
            A261CPComCod = cgiGet( edtCPComCod_Internalname);
            AssignAttri("", false, "A261CPComCod", A261CPComCod);
            A262CPPrvCod = StringUtil.Upper( cgiGet( edtCPPrvCod_Internalname));
            AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
            if ( context.localUtil.VCDate( cgiGet( edtCPFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CPFECH");
               AnyError = 1;
               GX_FocusControl = edtCPFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A264CPFech = DateTime.MinValue;
               AssignAttri("", false, "A264CPFech", context.localUtil.Format(A264CPFech, "99/99/99"));
            }
            else
            {
               A264CPFech = context.localUtil.CToD( cgiGet( edtCPFech_Internalname), 2);
               AssignAttri("", false, "A264CPFech", context.localUtil.Format(A264CPFech, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCPFVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "CPFVCTO");
               AnyError = 1;
               GX_FocusControl = edtCPFVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A817CPFVcto = DateTime.MinValue;
               AssignAttri("", false, "A817CPFVcto", context.localUtil.Format(A817CPFVcto, "99/99/99"));
            }
            else
            {
               A817CPFVcto = context.localUtil.CToD( cgiGet( edtCPFVcto_Internalname), 2);
               AssignAttri("", false, "A817CPFVcto", context.localUtil.Format(A817CPFVcto, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCPFReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Registro"}), 1, "CPFREG");
               AnyError = 1;
               GX_FocusControl = edtCPFReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A816CPFReg = DateTime.MinValue;
               AssignAttri("", false, "A816CPFReg", context.localUtil.Format(A816CPFReg, "99/99/99"));
            }
            else
            {
               A816CPFReg = context.localUtil.CToD( cgiGet( edtCPFReg_Internalname), 2);
               AssignAttri("", false, "A816CPFReg", context.localUtil.Format(A816CPFReg, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCPMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtCPMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A263CPMonCod = 0;
               AssignAttri("", false, "A263CPMonCod", StringUtil.LTrimStr( (decimal)(A263CPMonCod), 6, 0));
            }
            else
            {
               A263CPMonCod = (int)(context.localUtil.CToN( cgiGet( edtCPMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A263CPMonCod", StringUtil.LTrimStr( (decimal)(A263CPMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPImpTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPImpTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPIMPTOTAL");
               AnyError = 1;
               GX_FocusControl = edtCPImpTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A820CPImpTotal = 0;
               AssignAttri("", false, "A820CPImpTotal", StringUtil.LTrimStr( A820CPImpTotal, 15, 2));
            }
            else
            {
               A820CPImpTotal = context.localUtil.CToN( cgiGet( edtCPImpTotal_Internalname), ".", ",");
               AssignAttri("", false, "A820CPImpTotal", StringUtil.LTrimStr( A820CPImpTotal, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPImpPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPImpPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPIMPPAGO");
               AnyError = 1;
               GX_FocusControl = edtCPImpPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A818CPImpPago = 0;
               AssignAttri("", false, "A818CPImpPago", StringUtil.LTrimStr( A818CPImpPago, 15, 2));
            }
            else
            {
               A818CPImpPago = context.localUtil.CToN( cgiGet( edtCPImpPago_Internalname), ".", ",");
               AssignAttri("", false, "A818CPImpPago", StringUtil.LTrimStr( A818CPImpPago, 15, 2));
            }
            A815CPEstado = cgiGet( edtCPEstado_Internalname);
            AssignAttri("", false, "A815CPEstado", A815CPEstado);
            A822CPImpTotalSig = context.localUtil.CToN( cgiGet( edtCPImpTotalSig_Internalname), ".", ",");
            AssignAttri("", false, "A822CPImpTotalSig", StringUtil.LTrimStr( A822CPImpTotalSig, 15, 2));
            A831CPPrvDsc = cgiGet( edtCPPrvDsc_Internalname);
            AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
            A819CPImpSaldo = context.localUtil.CToN( cgiGet( edtCPImpSaldo_Internalname), ".", ",");
            AssignAttri("", false, "A819CPImpSaldo", StringUtil.LTrimStr( A819CPImpSaldo, 15, 2));
            A821CPImpSaldoSig = context.localUtil.CToN( cgiGet( edtCPImpSaldoSig_Internalname), ".", ",");
            AssignAttri("", false, "A821CPImpSaldoSig", StringUtil.LTrimStr( A821CPImpSaldoSig, 15, 2));
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
               A260CPTipCod = GetPar( "CPTipCod");
               AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
               A261CPComCod = GetPar( "CPComCod");
               AssignAttri("", false, "A261CPComCod", A261CPComCod);
               A262CPPrvCod = GetPar( "CPPrvCod");
               AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
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
               InitAll39112( ) ;
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
         DisableAttributes39112( ) ;
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

      protected void CONFIRM_390( )
      {
         BeforeValidate39112( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls39112( ) ;
            }
            else
            {
               CheckExtendedTable39112( ) ;
               if ( AnyError == 0 )
               {
                  ZM39112( 8) ;
                  ZM39112( 9) ;
                  ZM39112( 10) ;
               }
               CloseExtendedTableCursors39112( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues390( ) ;
         }
      }

      protected void ResetCaption390( )
      {
      }

      protected void ZM39112( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z264CPFech = T00393_A264CPFech[0];
               Z817CPFVcto = T00393_A817CPFVcto[0];
               Z816CPFReg = T00393_A816CPFReg[0];
               Z820CPImpTotal = T00393_A820CPImpTotal[0];
               Z818CPImpPago = T00393_A818CPImpPago[0];
               Z815CPEstado = T00393_A815CPEstado[0];
               Z263CPMonCod = T00393_A263CPMonCod[0];
            }
            else
            {
               Z264CPFech = A264CPFech;
               Z817CPFVcto = A817CPFVcto;
               Z816CPFReg = A816CPFReg;
               Z820CPImpTotal = A820CPImpTotal;
               Z818CPImpPago = A818CPImpPago;
               Z815CPEstado = A815CPEstado;
               Z263CPMonCod = A263CPMonCod;
            }
         }
         if ( GX_JID == -7 )
         {
            Z261CPComCod = A261CPComCod;
            Z264CPFech = A264CPFech;
            Z817CPFVcto = A817CPFVcto;
            Z816CPFReg = A816CPFReg;
            Z820CPImpTotal = A820CPImpTotal;
            Z818CPImpPago = A818CPImpPago;
            Z815CPEstado = A815CPEstado;
            Z260CPTipCod = A260CPTipCod;
            Z262CPPrvCod = A262CPPrvCod;
            Z263CPMonCod = A263CPMonCod;
            Z856CPTipAbr = A856CPTipAbr;
            Z511TipSigno = A511TipSigno;
            Z831CPPrvDsc = A831CPPrvDsc;
            Z830CPMonDsc = A830CPMonDsc;
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

      protected void Load39112( )
      {
         /* Using cursor T00397 */
         pr_default.execute(5, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound112 = 1;
            A856CPTipAbr = T00397_A856CPTipAbr[0];
            A264CPFech = T00397_A264CPFech[0];
            AssignAttri("", false, "A264CPFech", context.localUtil.Format(A264CPFech, "99/99/99"));
            A817CPFVcto = T00397_A817CPFVcto[0];
            AssignAttri("", false, "A817CPFVcto", context.localUtil.Format(A817CPFVcto, "99/99/99"));
            A816CPFReg = T00397_A816CPFReg[0];
            AssignAttri("", false, "A816CPFReg", context.localUtil.Format(A816CPFReg, "99/99/99"));
            A830CPMonDsc = T00397_A830CPMonDsc[0];
            A820CPImpTotal = T00397_A820CPImpTotal[0];
            AssignAttri("", false, "A820CPImpTotal", StringUtil.LTrimStr( A820CPImpTotal, 15, 2));
            A818CPImpPago = T00397_A818CPImpPago[0];
            AssignAttri("", false, "A818CPImpPago", StringUtil.LTrimStr( A818CPImpPago, 15, 2));
            A815CPEstado = T00397_A815CPEstado[0];
            AssignAttri("", false, "A815CPEstado", A815CPEstado);
            A831CPPrvDsc = T00397_A831CPPrvDsc[0];
            AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
            A511TipSigno = T00397_A511TipSigno[0];
            n511TipSigno = T00397_n511TipSigno[0];
            A263CPMonCod = T00397_A263CPMonCod[0];
            AssignAttri("", false, "A263CPMonCod", StringUtil.LTrimStr( (decimal)(A263CPMonCod), 6, 0));
            ZM39112( -7) ;
         }
         pr_default.close(5);
         OnLoadActions39112( ) ;
      }

      protected void OnLoadActions39112( )
      {
         A822CPImpTotalSig = NumberUtil.Round( A820CPImpTotal*A511TipSigno, 2);
         AssignAttri("", false, "A822CPImpTotalSig", StringUtil.LTrimStr( A822CPImpTotalSig, 15, 2));
         A819CPImpSaldo = (decimal)(A820CPImpTotal-A818CPImpPago);
         AssignAttri("", false, "A819CPImpSaldo", StringUtil.LTrimStr( A819CPImpSaldo, 15, 2));
         A821CPImpSaldoSig = (decimal)(A819CPImpSaldo*A511TipSigno);
         AssignAttri("", false, "A821CPImpSaldoSig", StringUtil.LTrimStr( A821CPImpSaldoSig, 15, 2));
      }

      protected void CheckExtendedTable39112( )
      {
         nIsDirty_112 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00394 */
         pr_default.execute(2, new Object[] {A260CPTipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento Cuentas por Pagar'.", "ForeignKeyNotFound", 1, "CPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A856CPTipAbr = T00394_A856CPTipAbr[0];
         A511TipSigno = T00394_A511TipSigno[0];
         n511TipSigno = T00394_n511TipSigno[0];
         pr_default.close(2);
         nIsDirty_112 = 1;
         A822CPImpTotalSig = NumberUtil.Round( A820CPImpTotal*A511TipSigno, 2);
         AssignAttri("", false, "A822CPImpTotalSig", StringUtil.LTrimStr( A822CPImpTotalSig, 15, 2));
         /* Using cursor T00395 */
         pr_default.execute(3, new Object[] {A262CPPrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Proveedor'.", "ForeignKeyNotFound", 1, "CPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A831CPPrvDsc = T00395_A831CPPrvDsc[0];
         AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A264CPFech) || ( DateTimeUtil.ResetTime ( A264CPFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CPFECH");
            AnyError = 1;
            GX_FocusControl = edtCPFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A817CPFVcto) || ( DateTimeUtil.ResetTime ( A817CPFVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "CPFVCTO");
            AnyError = 1;
            GX_FocusControl = edtCPFVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A816CPFReg) || ( DateTimeUtil.ResetTime ( A816CPFReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Registro fuera de rango", "OutOfRange", 1, "CPFREG");
            AnyError = 1;
            GX_FocusControl = edtCPFReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00396 */
         pr_default.execute(4, new Object[] {A263CPMonCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Moneda'.", "ForeignKeyNotFound", 1, "CPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCPMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A830CPMonDsc = T00396_A830CPMonDsc[0];
         pr_default.close(4);
         nIsDirty_112 = 1;
         A819CPImpSaldo = (decimal)(A820CPImpTotal-A818CPImpPago);
         AssignAttri("", false, "A819CPImpSaldo", StringUtil.LTrimStr( A819CPImpSaldo, 15, 2));
         nIsDirty_112 = 1;
         A821CPImpSaldoSig = (decimal)(A819CPImpSaldo*A511TipSigno);
         AssignAttri("", false, "A821CPImpSaldoSig", StringUtil.LTrimStr( A821CPImpSaldoSig, 15, 2));
      }

      protected void CloseExtendedTableCursors39112( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( string A260CPTipCod )
      {
         /* Using cursor T00398 */
         pr_default.execute(6, new Object[] {A260CPTipCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento Cuentas por Pagar'.", "ForeignKeyNotFound", 1, "CPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A856CPTipAbr = T00398_A856CPTipAbr[0];
         A511TipSigno = T00398_A511TipSigno[0];
         n511TipSigno = T00398_n511TipSigno[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A856CPTipAbr))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_9( string A262CPPrvCod )
      {
         /* Using cursor T00399 */
         pr_default.execute(7, new Object[] {A262CPPrvCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Proveedor'.", "ForeignKeyNotFound", 1, "CPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A831CPPrvDsc = T00399_A831CPPrvDsc[0];
         AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A831CPPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_10( int A263CPMonCod )
      {
         /* Using cursor T003910 */
         pr_default.execute(8, new Object[] {A263CPMonCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Moneda'.", "ForeignKeyNotFound", 1, "CPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCPMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A830CPMonDsc = T003910_A830CPMonDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A830CPMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey39112( )
      {
         /* Using cursor T003911 */
         pr_default.execute(9, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound112 = 1;
         }
         else
         {
            RcdFound112 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00393 */
         pr_default.execute(1, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM39112( 7) ;
            RcdFound112 = 1;
            A261CPComCod = T00393_A261CPComCod[0];
            AssignAttri("", false, "A261CPComCod", A261CPComCod);
            A264CPFech = T00393_A264CPFech[0];
            AssignAttri("", false, "A264CPFech", context.localUtil.Format(A264CPFech, "99/99/99"));
            A817CPFVcto = T00393_A817CPFVcto[0];
            AssignAttri("", false, "A817CPFVcto", context.localUtil.Format(A817CPFVcto, "99/99/99"));
            A816CPFReg = T00393_A816CPFReg[0];
            AssignAttri("", false, "A816CPFReg", context.localUtil.Format(A816CPFReg, "99/99/99"));
            A820CPImpTotal = T00393_A820CPImpTotal[0];
            AssignAttri("", false, "A820CPImpTotal", StringUtil.LTrimStr( A820CPImpTotal, 15, 2));
            A818CPImpPago = T00393_A818CPImpPago[0];
            AssignAttri("", false, "A818CPImpPago", StringUtil.LTrimStr( A818CPImpPago, 15, 2));
            A815CPEstado = T00393_A815CPEstado[0];
            AssignAttri("", false, "A815CPEstado", A815CPEstado);
            A260CPTipCod = T00393_A260CPTipCod[0];
            AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
            A262CPPrvCod = T00393_A262CPPrvCod[0];
            AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
            A263CPMonCod = T00393_A263CPMonCod[0];
            AssignAttri("", false, "A263CPMonCod", StringUtil.LTrimStr( (decimal)(A263CPMonCod), 6, 0));
            Z260CPTipCod = A260CPTipCod;
            Z261CPComCod = A261CPComCod;
            Z262CPPrvCod = A262CPPrvCod;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load39112( ) ;
            if ( AnyError == 1 )
            {
               RcdFound112 = 0;
               InitializeNonKey39112( ) ;
            }
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound112 = 0;
            InitializeNonKey39112( ) ;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey39112( ) ;
         if ( RcdFound112 == 0 )
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
         RcdFound112 = 0;
         /* Using cursor T003912 */
         pr_default.execute(10, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T003912_A260CPTipCod[0], A260CPTipCod) < 0 ) || ( StringUtil.StrCmp(T003912_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003912_A261CPComCod[0], A261CPComCod) < 0 ) || ( StringUtil.StrCmp(T003912_A261CPComCod[0], A261CPComCod) == 0 ) && ( StringUtil.StrCmp(T003912_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003912_A262CPPrvCod[0], A262CPPrvCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T003912_A260CPTipCod[0], A260CPTipCod) > 0 ) || ( StringUtil.StrCmp(T003912_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003912_A261CPComCod[0], A261CPComCod) > 0 ) || ( StringUtil.StrCmp(T003912_A261CPComCod[0], A261CPComCod) == 0 ) && ( StringUtil.StrCmp(T003912_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003912_A262CPPrvCod[0], A262CPPrvCod) > 0 ) ) )
            {
               A260CPTipCod = T003912_A260CPTipCod[0];
               AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
               A261CPComCod = T003912_A261CPComCod[0];
               AssignAttri("", false, "A261CPComCod", A261CPComCod);
               A262CPPrvCod = T003912_A262CPPrvCod[0];
               AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
               RcdFound112 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound112 = 0;
         /* Using cursor T003913 */
         pr_default.execute(11, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T003913_A260CPTipCod[0], A260CPTipCod) > 0 ) || ( StringUtil.StrCmp(T003913_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003913_A261CPComCod[0], A261CPComCod) > 0 ) || ( StringUtil.StrCmp(T003913_A261CPComCod[0], A261CPComCod) == 0 ) && ( StringUtil.StrCmp(T003913_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003913_A262CPPrvCod[0], A262CPPrvCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T003913_A260CPTipCod[0], A260CPTipCod) < 0 ) || ( StringUtil.StrCmp(T003913_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003913_A261CPComCod[0], A261CPComCod) < 0 ) || ( StringUtil.StrCmp(T003913_A261CPComCod[0], A261CPComCod) == 0 ) && ( StringUtil.StrCmp(T003913_A260CPTipCod[0], A260CPTipCod) == 0 ) && ( StringUtil.StrCmp(T003913_A262CPPrvCod[0], A262CPPrvCod) < 0 ) ) )
            {
               A260CPTipCod = T003913_A260CPTipCod[0];
               AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
               A261CPComCod = T003913_A261CPComCod[0];
               AssignAttri("", false, "A261CPComCod", A261CPComCod);
               A262CPPrvCod = T003913_A262CPPrvCod[0];
               AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
               RcdFound112 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey39112( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert39112( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound112 == 1 )
            {
               if ( ( StringUtil.StrCmp(A260CPTipCod, Z260CPTipCod) != 0 ) || ( StringUtil.StrCmp(A261CPComCod, Z261CPComCod) != 0 ) || ( StringUtil.StrCmp(A262CPPrvCod, Z262CPPrvCod) != 0 ) )
               {
                  A260CPTipCod = Z260CPTipCod;
                  AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
                  A261CPComCod = Z261CPComCod;
                  AssignAttri("", false, "A261CPComCod", A261CPComCod);
                  A262CPPrvCod = Z262CPPrvCod;
                  AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CPTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCPTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update39112( ) ;
                  GX_FocusControl = edtCPTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A260CPTipCod, Z260CPTipCod) != 0 ) || ( StringUtil.StrCmp(A261CPComCod, Z261CPComCod) != 0 ) || ( StringUtil.StrCmp(A262CPPrvCod, Z262CPPrvCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCPTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert39112( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPTIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCPTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCPTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert39112( ) ;
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
         if ( ( StringUtil.StrCmp(A260CPTipCod, Z260CPTipCod) != 0 ) || ( StringUtil.StrCmp(A261CPComCod, Z261CPComCod) != 0 ) || ( StringUtil.StrCmp(A262CPPrvCod, Z262CPPrvCod) != 0 ) )
         {
            A260CPTipCod = Z260CPTipCod;
            AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
            A261CPComCod = Z261CPComCod;
            AssignAttri("", false, "A261CPComCod", A261CPComCod);
            A262CPPrvCod = Z262CPPrvCod;
            AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCPTipCod_Internalname;
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
         GetKey39112( ) ;
         if ( RcdFound112 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CPTIPCOD");
               AnyError = 1;
               GX_FocusControl = edtCPTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A260CPTipCod, Z260CPTipCod) != 0 ) || ( StringUtil.StrCmp(A261CPComCod, Z261CPComCod) != 0 ) || ( StringUtil.StrCmp(A262CPPrvCod, Z262CPPrvCod) != 0 ) )
            {
               A260CPTipCod = Z260CPTipCod;
               AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
               A261CPComCod = Z261CPComCod;
               AssignAttri("", false, "A261CPComCod", A261CPComCod);
               A262CPPrvCod = Z262CPPrvCod;
               AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CPTIPCOD");
               AnyError = 1;
               GX_FocusControl = edtCPTipCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A260CPTipCod, Z260CPTipCod) != 0 ) || ( StringUtil.StrCmp(A261CPComCod, Z261CPComCod) != 0 ) || ( StringUtil.StrCmp(A262CPPrvCod, Z262CPPrvCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPTipCod_Internalname;
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
         context.RollbackDataStores("cpcuentapagar",pr_default);
         GX_FocusControl = edtCPFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_390( ) ;
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
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCPFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart39112( ) ;
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd39112( ) ;
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
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPFech_Internalname;
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
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPFech_Internalname;
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
         ScanStart39112( ) ;
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound112 != 0 )
            {
               ScanNext39112( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd39112( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency39112( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00392 */
            pr_default.execute(0, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCUENTAPAGAR"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z264CPFech ) != DateTimeUtil.ResetTime ( T00392_A264CPFech[0] ) ) || ( DateTimeUtil.ResetTime ( Z817CPFVcto ) != DateTimeUtil.ResetTime ( T00392_A817CPFVcto[0] ) ) || ( DateTimeUtil.ResetTime ( Z816CPFReg ) != DateTimeUtil.ResetTime ( T00392_A816CPFReg[0] ) ) || ( Z820CPImpTotal != T00392_A820CPImpTotal[0] ) || ( Z818CPImpPago != T00392_A818CPImpPago[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z815CPEstado, T00392_A815CPEstado[0]) != 0 ) || ( Z263CPMonCod != T00392_A263CPMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z264CPFech ) != DateTimeUtil.ResetTime ( T00392_A264CPFech[0] ) )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPFech");
                  GXUtil.WriteLogRaw("Old: ",Z264CPFech);
                  GXUtil.WriteLogRaw("Current: ",T00392_A264CPFech[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z817CPFVcto ) != DateTimeUtil.ResetTime ( T00392_A817CPFVcto[0] ) )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPFVcto");
                  GXUtil.WriteLogRaw("Old: ",Z817CPFVcto);
                  GXUtil.WriteLogRaw("Current: ",T00392_A817CPFVcto[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z816CPFReg ) != DateTimeUtil.ResetTime ( T00392_A816CPFReg[0] ) )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPFReg");
                  GXUtil.WriteLogRaw("Old: ",Z816CPFReg);
                  GXUtil.WriteLogRaw("Current: ",T00392_A816CPFReg[0]);
               }
               if ( Z820CPImpTotal != T00392_A820CPImpTotal[0] )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPImpTotal");
                  GXUtil.WriteLogRaw("Old: ",Z820CPImpTotal);
                  GXUtil.WriteLogRaw("Current: ",T00392_A820CPImpTotal[0]);
               }
               if ( Z818CPImpPago != T00392_A818CPImpPago[0] )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPImpPago");
                  GXUtil.WriteLogRaw("Old: ",Z818CPImpPago);
                  GXUtil.WriteLogRaw("Current: ",T00392_A818CPImpPago[0]);
               }
               if ( StringUtil.StrCmp(Z815CPEstado, T00392_A815CPEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPEstado");
                  GXUtil.WriteLogRaw("Old: ",Z815CPEstado);
                  GXUtil.WriteLogRaw("Current: ",T00392_A815CPEstado[0]);
               }
               if ( Z263CPMonCod != T00392_A263CPMonCod[0] )
               {
                  GXUtil.WriteLog("cpcuentapagar:[seudo value changed for attri]"+"CPMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z263CPMonCod);
                  GXUtil.WriteLogRaw("Current: ",T00392_A263CPMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPCUENTAPAGAR"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert39112( )
      {
         BeforeValidate39112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable39112( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM39112( 0) ;
            CheckOptimisticConcurrency39112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm39112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert39112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003914 */
                     pr_default.execute(12, new Object[] {A261CPComCod, A264CPFech, A817CPFVcto, A816CPFReg, A820CPImpTotal, A818CPImpPago, A815CPEstado, A260CPTipCod, A262CPPrvCod, A263CPMonCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCUENTAPAGAR");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption390( ) ;
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
               Load39112( ) ;
            }
            EndLevel39112( ) ;
         }
         CloseExtendedTableCursors39112( ) ;
      }

      protected void Update39112( )
      {
         BeforeValidate39112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable39112( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency39112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm39112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate39112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003915 */
                     pr_default.execute(13, new Object[] {A264CPFech, A817CPFVcto, A816CPFReg, A820CPImpTotal, A818CPImpPago, A815CPEstado, A263CPMonCod, A260CPTipCod, A261CPComCod, A262CPPrvCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCUENTAPAGAR");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCUENTAPAGAR"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate39112( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption390( ) ;
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
            EndLevel39112( ) ;
         }
         CloseExtendedTableCursors39112( ) ;
      }

      protected void DeferredUpdate39112( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate39112( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency39112( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls39112( ) ;
            AfterConfirm39112( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete39112( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003916 */
                  pr_default.execute(14, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("CPCUENTAPAGAR");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound112 == 0 )
                        {
                           InitAll39112( ) ;
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
                        ResetCaption390( ) ;
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
         sMode112 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel39112( ) ;
         Gx_mode = sMode112;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls39112( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003917 */
            pr_default.execute(15, new Object[] {A260CPTipCod});
            A856CPTipAbr = T003917_A856CPTipAbr[0];
            A511TipSigno = T003917_A511TipSigno[0];
            n511TipSigno = T003917_n511TipSigno[0];
            pr_default.close(15);
            /* Using cursor T003918 */
            pr_default.execute(16, new Object[] {A262CPPrvCod});
            A831CPPrvDsc = T003918_A831CPPrvDsc[0];
            AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
            pr_default.close(16);
            /* Using cursor T003919 */
            pr_default.execute(17, new Object[] {A263CPMonCod});
            A830CPMonDsc = T003919_A830CPMonDsc[0];
            pr_default.close(17);
            A822CPImpTotalSig = NumberUtil.Round( A820CPImpTotal*A511TipSigno, 2);
            AssignAttri("", false, "A822CPImpTotalSig", StringUtil.LTrimStr( A822CPImpTotalSig, 15, 2));
            A819CPImpSaldo = (decimal)(A820CPImpTotal-A818CPImpPago);
            AssignAttri("", false, "A819CPImpSaldo", StringUtil.LTrimStr( A819CPImpSaldo, 15, 2));
            A821CPImpSaldoSig = (decimal)(A819CPImpSaldo*A511TipSigno);
            AssignAttri("", false, "A821CPImpSaldoSig", StringUtil.LTrimStr( A821CPImpSaldoSig, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003920 */
            pr_default.execute(18, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pagos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T003921 */
            pr_default.execute(19, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Retención Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T003922 */
            pr_default.execute(20, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel39112( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete39112( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("cpcuentapagar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues390( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.RollbackDataStores("cpcuentapagar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart39112( )
      {
         /* Using cursor T003923 */
         pr_default.execute(21);
         RcdFound112 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound112 = 1;
            A260CPTipCod = T003923_A260CPTipCod[0];
            AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
            A261CPComCod = T003923_A261CPComCod[0];
            AssignAttri("", false, "A261CPComCod", A261CPComCod);
            A262CPPrvCod = T003923_A262CPPrvCod[0];
            AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext39112( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound112 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound112 = 1;
            A260CPTipCod = T003923_A260CPTipCod[0];
            AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
            A261CPComCod = T003923_A261CPComCod[0];
            AssignAttri("", false, "A261CPComCod", A261CPComCod);
            A262CPPrvCod = T003923_A262CPPrvCod[0];
            AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
         }
      }

      protected void ScanEnd39112( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm39112( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert39112( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate39112( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete39112( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete39112( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate39112( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes39112( )
      {
         edtCPTipCod_Enabled = 0;
         AssignProp("", false, edtCPTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPTipCod_Enabled), 5, 0), true);
         edtCPComCod_Enabled = 0;
         AssignProp("", false, edtCPComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPComCod_Enabled), 5, 0), true);
         edtCPPrvCod_Enabled = 0;
         AssignProp("", false, edtCPPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPPrvCod_Enabled), 5, 0), true);
         edtCPFech_Enabled = 0;
         AssignProp("", false, edtCPFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPFech_Enabled), 5, 0), true);
         edtCPFVcto_Enabled = 0;
         AssignProp("", false, edtCPFVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPFVcto_Enabled), 5, 0), true);
         edtCPFReg_Enabled = 0;
         AssignProp("", false, edtCPFReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPFReg_Enabled), 5, 0), true);
         edtCPMonCod_Enabled = 0;
         AssignProp("", false, edtCPMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPMonCod_Enabled), 5, 0), true);
         edtCPImpTotal_Enabled = 0;
         AssignProp("", false, edtCPImpTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPImpTotal_Enabled), 5, 0), true);
         edtCPImpPago_Enabled = 0;
         AssignProp("", false, edtCPImpPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPImpPago_Enabled), 5, 0), true);
         edtCPEstado_Enabled = 0;
         AssignProp("", false, edtCPEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPEstado_Enabled), 5, 0), true);
         edtCPImpTotalSig_Enabled = 0;
         AssignProp("", false, edtCPImpTotalSig_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPImpTotalSig_Enabled), 5, 0), true);
         edtCPPrvDsc_Enabled = 0;
         AssignProp("", false, edtCPPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPPrvDsc_Enabled), 5, 0), true);
         edtCPImpSaldo_Enabled = 0;
         AssignProp("", false, edtCPImpSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPImpSaldo_Enabled), 5, 0), true);
         edtCPImpSaldoSig_Enabled = 0;
         AssignProp("", false, edtCPImpSaldoSig_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPImpSaldoSig_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes39112( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues390( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025044", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpcuentapagar.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z260CPTipCod", StringUtil.RTrim( Z260CPTipCod));
         GxWebStd.gx_hidden_field( context, "Z261CPComCod", StringUtil.RTrim( Z261CPComCod));
         GxWebStd.gx_hidden_field( context, "Z262CPPrvCod", StringUtil.RTrim( Z262CPPrvCod));
         GxWebStd.gx_hidden_field( context, "Z264CPFech", context.localUtil.DToC( Z264CPFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z817CPFVcto", context.localUtil.DToC( Z817CPFVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z816CPFReg", context.localUtil.DToC( Z816CPFReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z820CPImpTotal", StringUtil.LTrim( StringUtil.NToC( Z820CPImpTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z818CPImpPago", StringUtil.LTrim( StringUtil.NToC( Z818CPImpPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z815CPEstado", StringUtil.RTrim( Z815CPEstado));
         GxWebStd.gx_hidden_field( context, "Z263CPMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z263CPMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "TIPSIGNO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CPTIPABR", StringUtil.RTrim( A856CPTipAbr));
         GxWebStd.gx_hidden_field( context, "CPMONDSC", StringUtil.RTrim( A830CPMonDsc));
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
         return formatLink("cpcuentapagar.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPCUENTAPAGAR" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cuentas por Pagar" ;
      }

      protected void InitializeNonKey39112( )
      {
         A821CPImpSaldoSig = 0;
         AssignAttri("", false, "A821CPImpSaldoSig", StringUtil.LTrimStr( A821CPImpSaldoSig, 15, 2));
         A819CPImpSaldo = 0;
         AssignAttri("", false, "A819CPImpSaldo", StringUtil.LTrimStr( A819CPImpSaldo, 15, 2));
         A822CPImpTotalSig = 0;
         AssignAttri("", false, "A822CPImpTotalSig", StringUtil.LTrimStr( A822CPImpTotalSig, 15, 2));
         A856CPTipAbr = "";
         AssignAttri("", false, "A856CPTipAbr", A856CPTipAbr);
         A264CPFech = DateTime.MinValue;
         AssignAttri("", false, "A264CPFech", context.localUtil.Format(A264CPFech, "99/99/99"));
         A817CPFVcto = DateTime.MinValue;
         AssignAttri("", false, "A817CPFVcto", context.localUtil.Format(A817CPFVcto, "99/99/99"));
         A816CPFReg = DateTime.MinValue;
         AssignAttri("", false, "A816CPFReg", context.localUtil.Format(A816CPFReg, "99/99/99"));
         A263CPMonCod = 0;
         AssignAttri("", false, "A263CPMonCod", StringUtil.LTrimStr( (decimal)(A263CPMonCod), 6, 0));
         A830CPMonDsc = "";
         AssignAttri("", false, "A830CPMonDsc", A830CPMonDsc);
         A820CPImpTotal = 0;
         AssignAttri("", false, "A820CPImpTotal", StringUtil.LTrimStr( A820CPImpTotal, 15, 2));
         A818CPImpPago = 0;
         AssignAttri("", false, "A818CPImpPago", StringUtil.LTrimStr( A818CPImpPago, 15, 2));
         A815CPEstado = "";
         AssignAttri("", false, "A815CPEstado", A815CPEstado);
         A831CPPrvDsc = "";
         AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
         A511TipSigno = 0;
         n511TipSigno = false;
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
         Z264CPFech = DateTime.MinValue;
         Z817CPFVcto = DateTime.MinValue;
         Z816CPFReg = DateTime.MinValue;
         Z820CPImpTotal = 0;
         Z818CPImpPago = 0;
         Z815CPEstado = "";
         Z263CPMonCod = 0;
      }

      protected void InitAll39112( )
      {
         A260CPTipCod = "";
         AssignAttri("", false, "A260CPTipCod", A260CPTipCod);
         A261CPComCod = "";
         AssignAttri("", false, "A261CPComCod", A261CPComCod);
         A262CPPrvCod = "";
         AssignAttri("", false, "A262CPPrvCod", A262CPPrvCod);
         InitializeNonKey39112( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025055", true, true);
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
         context.AddJavascriptSource("cpcuentapagar.js", "?20228181025055", false, true);
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
         edtCPTipCod_Internalname = "CPTIPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCPComCod_Internalname = "CPCOMCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCPPrvCod_Internalname = "CPPRVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCPFech_Internalname = "CPFECH";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCPFVcto_Internalname = "CPFVCTO";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCPFReg_Internalname = "CPFREG";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCPMonCod_Internalname = "CPMONCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCPImpTotal_Internalname = "CPIMPTOTAL";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCPImpPago_Internalname = "CPIMPPAGO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCPEstado_Internalname = "CPESTADO";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtCPImpTotalSig_Internalname = "CPIMPTOTALSIG";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtCPPrvDsc_Internalname = "CPPRVDSC";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtCPImpSaldo_Internalname = "CPIMPSALDO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtCPImpSaldoSig_Internalname = "CPIMPSALDOSIG";
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
         Form.Caption = "Cuentas por Pagar";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCPImpSaldoSig_Jsonclick = "";
         edtCPImpSaldoSig_Enabled = 0;
         edtCPImpSaldo_Jsonclick = "";
         edtCPImpSaldo_Enabled = 0;
         edtCPPrvDsc_Jsonclick = "";
         edtCPPrvDsc_Enabled = 0;
         edtCPImpTotalSig_Jsonclick = "";
         edtCPImpTotalSig_Enabled = 0;
         edtCPEstado_Jsonclick = "";
         edtCPEstado_Enabled = 1;
         edtCPImpPago_Jsonclick = "";
         edtCPImpPago_Enabled = 1;
         edtCPImpTotal_Jsonclick = "";
         edtCPImpTotal_Enabled = 1;
         edtCPMonCod_Jsonclick = "";
         edtCPMonCod_Enabled = 1;
         edtCPFReg_Jsonclick = "";
         edtCPFReg_Enabled = 1;
         edtCPFVcto_Jsonclick = "";
         edtCPFVcto_Enabled = 1;
         edtCPFech_Jsonclick = "";
         edtCPFech_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCPPrvCod_Jsonclick = "";
         edtCPPrvCod_Enabled = 1;
         edtCPComCod_Jsonclick = "";
         edtCPComCod_Enabled = 1;
         edtCPTipCod_Jsonclick = "";
         edtCPTipCod_Enabled = 1;
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
         /* Using cursor T003917 */
         pr_default.execute(15, new Object[] {A260CPTipCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento Cuentas por Pagar'.", "ForeignKeyNotFound", 1, "CPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A856CPTipAbr = T003917_A856CPTipAbr[0];
         A511TipSigno = T003917_A511TipSigno[0];
         n511TipSigno = T003917_n511TipSigno[0];
         pr_default.close(15);
         /* Using cursor T003918 */
         pr_default.execute(16, new Object[] {A262CPPrvCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Proveedor'.", "ForeignKeyNotFound", 1, "CPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A831CPPrvDsc = T003918_A831CPPrvDsc[0];
         AssignAttri("", false, "A831CPPrvDsc", A831CPPrvDsc);
         pr_default.close(16);
         GX_FocusControl = edtCPFech_Internalname;
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

      public void Valid_Cptipcod( )
      {
         n511TipSigno = false;
         /* Using cursor T003917 */
         pr_default.execute(15, new Object[] {A260CPTipCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Documento Cuentas por Pagar'.", "ForeignKeyNotFound", 1, "CPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCPTipCod_Internalname;
         }
         A856CPTipAbr = T003917_A856CPTipAbr[0];
         A511TipSigno = T003917_A511TipSigno[0];
         n511TipSigno = T003917_n511TipSigno[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A856CPTipAbr", StringUtil.RTrim( A856CPTipAbr));
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
      }

      public void Valid_Cpprvcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T003918 */
         pr_default.execute(16, new Object[] {A262CPPrvCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Proveedor'.", "ForeignKeyNotFound", 1, "CPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPPrvCod_Internalname;
         }
         A831CPPrvDsc = T003918_A831CPPrvDsc[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A264CPFech", context.localUtil.Format(A264CPFech, "99/99/99"));
         AssignAttri("", false, "A817CPFVcto", context.localUtil.Format(A817CPFVcto, "99/99/99"));
         AssignAttri("", false, "A816CPFReg", context.localUtil.Format(A816CPFReg, "99/99/99"));
         AssignAttri("", false, "A263CPMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A263CPMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A820CPImpTotal", StringUtil.LTrim( StringUtil.NToC( A820CPImpTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A818CPImpPago", StringUtil.LTrim( StringUtil.NToC( A818CPImpPago, 15, 2, ".", "")));
         AssignAttri("", false, "A815CPEstado", StringUtil.RTrim( A815CPEstado));
         AssignAttri("", false, "A856CPTipAbr", StringUtil.RTrim( A856CPTipAbr));
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")));
         AssignAttri("", false, "A822CPImpTotalSig", StringUtil.LTrim( StringUtil.NToC( A822CPImpTotalSig, 15, 2, ".", "")));
         AssignAttri("", false, "A831CPPrvDsc", StringUtil.RTrim( A831CPPrvDsc));
         AssignAttri("", false, "A830CPMonDsc", StringUtil.RTrim( A830CPMonDsc));
         AssignAttri("", false, "A819CPImpSaldo", StringUtil.LTrim( StringUtil.NToC( A819CPImpSaldo, 15, 2, ".", "")));
         AssignAttri("", false, "A821CPImpSaldoSig", StringUtil.LTrim( StringUtil.NToC( A821CPImpSaldoSig, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z260CPTipCod", StringUtil.RTrim( Z260CPTipCod));
         GxWebStd.gx_hidden_field( context, "Z261CPComCod", StringUtil.RTrim( Z261CPComCod));
         GxWebStd.gx_hidden_field( context, "Z262CPPrvCod", StringUtil.RTrim( Z262CPPrvCod));
         GxWebStd.gx_hidden_field( context, "Z264CPFech", context.localUtil.Format(Z264CPFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z817CPFVcto", context.localUtil.Format(Z817CPFVcto, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z816CPFReg", context.localUtil.Format(Z816CPFReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z263CPMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z263CPMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z820CPImpTotal", StringUtil.LTrim( StringUtil.NToC( Z820CPImpTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z818CPImpPago", StringUtil.LTrim( StringUtil.NToC( Z818CPImpPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z815CPEstado", StringUtil.RTrim( Z815CPEstado));
         GxWebStd.gx_hidden_field( context, "Z856CPTipAbr", StringUtil.RTrim( Z856CPTipAbr));
         GxWebStd.gx_hidden_field( context, "Z511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z822CPImpTotalSig", StringUtil.LTrim( StringUtil.NToC( Z822CPImpTotalSig, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z831CPPrvDsc", StringUtil.RTrim( Z831CPPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z830CPMonDsc", StringUtil.RTrim( Z830CPMonDsc));
         GxWebStd.gx_hidden_field( context, "Z819CPImpSaldo", StringUtil.LTrim( StringUtil.NToC( Z819CPImpSaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z821CPImpSaldoSig", StringUtil.LTrim( StringUtil.NToC( Z821CPImpSaldoSig, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cpmoncod( )
      {
         /* Using cursor T003919 */
         pr_default.execute(17, new Object[] {A263CPMonCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Pagar Moneda'.", "ForeignKeyNotFound", 1, "CPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCPMonCod_Internalname;
         }
         A830CPMonDsc = T003919_A830CPMonDsc[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A830CPMonDsc", StringUtil.RTrim( A830CPMonDsc));
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
         setEventMetadata("VALID_CPTIPCOD","{handler:'Valid_Cptipcod',iparms:[{av:'A260CPTipCod',fld:'CPTIPCOD',pic:''},{av:'A856CPTipAbr',fld:'CPTIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]");
         setEventMetadata("VALID_CPTIPCOD",",oparms:[{av:'A856CPTipAbr',fld:'CPTIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'}]}");
         setEventMetadata("VALID_CPCOMCOD","{handler:'Valid_Cpcomcod',iparms:[]");
         setEventMetadata("VALID_CPCOMCOD",",oparms:[]}");
         setEventMetadata("VALID_CPPRVCOD","{handler:'Valid_Cpprvcod',iparms:[{av:'A260CPTipCod',fld:'CPTIPCOD',pic:''},{av:'A261CPComCod',fld:'CPCOMCOD',pic:''},{av:'A262CPPrvCod',fld:'CPPRVCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CPPRVCOD",",oparms:[{av:'A264CPFech',fld:'CPFECH',pic:''},{av:'A817CPFVcto',fld:'CPFVCTO',pic:''},{av:'A816CPFReg',fld:'CPFREG',pic:''},{av:'A263CPMonCod',fld:'CPMONCOD',pic:'ZZZZZ9'},{av:'A820CPImpTotal',fld:'CPIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A818CPImpPago',fld:'CPIMPPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A815CPEstado',fld:'CPESTADO',pic:''},{av:'A856CPTipAbr',fld:'CPTIPABR',pic:''},{av:'A511TipSigno',fld:'TIPSIGNO',pic:'Z9'},{av:'A822CPImpTotalSig',fld:'CPIMPTOTALSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A831CPPrvDsc',fld:'CPPRVDSC',pic:''},{av:'A830CPMonDsc',fld:'CPMONDSC',pic:''},{av:'A819CPImpSaldo',fld:'CPIMPSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A821CPImpSaldoSig',fld:'CPIMPSALDOSIG',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z260CPTipCod'},{av:'Z261CPComCod'},{av:'Z262CPPrvCod'},{av:'Z264CPFech'},{av:'Z817CPFVcto'},{av:'Z816CPFReg'},{av:'Z263CPMonCod'},{av:'Z820CPImpTotal'},{av:'Z818CPImpPago'},{av:'Z815CPEstado'},{av:'Z856CPTipAbr'},{av:'Z511TipSigno'},{av:'Z822CPImpTotalSig'},{av:'Z831CPPrvDsc'},{av:'Z830CPMonDsc'},{av:'Z819CPImpSaldo'},{av:'Z821CPImpSaldoSig'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CPFECH","{handler:'Valid_Cpfech',iparms:[]");
         setEventMetadata("VALID_CPFECH",",oparms:[]}");
         setEventMetadata("VALID_CPFVCTO","{handler:'Valid_Cpfvcto',iparms:[]");
         setEventMetadata("VALID_CPFVCTO",",oparms:[]}");
         setEventMetadata("VALID_CPFREG","{handler:'Valid_Cpfreg',iparms:[]");
         setEventMetadata("VALID_CPFREG",",oparms:[]}");
         setEventMetadata("VALID_CPMONCOD","{handler:'Valid_Cpmoncod',iparms:[{av:'A263CPMonCod',fld:'CPMONCOD',pic:'ZZZZZ9'},{av:'A830CPMonDsc',fld:'CPMONDSC',pic:''}]");
         setEventMetadata("VALID_CPMONCOD",",oparms:[{av:'A830CPMonDsc',fld:'CPMONDSC',pic:''}]}");
         setEventMetadata("VALID_CPIMPTOTAL","{handler:'Valid_Cpimptotal',iparms:[]");
         setEventMetadata("VALID_CPIMPTOTAL",",oparms:[]}");
         setEventMetadata("VALID_CPIMPPAGO","{handler:'Valid_Cpimppago',iparms:[]");
         setEventMetadata("VALID_CPIMPPAGO",",oparms:[]}");
         setEventMetadata("VALID_CPIMPSALDO","{handler:'Valid_Cpimpsaldo',iparms:[]");
         setEventMetadata("VALID_CPIMPSALDO",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z260CPTipCod = "";
         Z261CPComCod = "";
         Z262CPPrvCod = "";
         Z264CPFech = DateTime.MinValue;
         Z817CPFVcto = DateTime.MinValue;
         Z816CPFReg = DateTime.MinValue;
         Z815CPEstado = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A260CPTipCod = "";
         A262CPPrvCod = "";
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
         A261CPComCod = "";
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A264CPFech = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A817CPFVcto = DateTime.MinValue;
         lblTextblock6_Jsonclick = "";
         A816CPFReg = DateTime.MinValue;
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A815CPEstado = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A831CPPrvDsc = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A856CPTipAbr = "";
         A830CPMonDsc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z856CPTipAbr = "";
         Z831CPPrvDsc = "";
         Z830CPMonDsc = "";
         T00397_A261CPComCod = new string[] {""} ;
         T00397_A856CPTipAbr = new string[] {""} ;
         T00397_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         T00397_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         T00397_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         T00397_A830CPMonDsc = new string[] {""} ;
         T00397_A820CPImpTotal = new decimal[1] ;
         T00397_A818CPImpPago = new decimal[1] ;
         T00397_A815CPEstado = new string[] {""} ;
         T00397_A831CPPrvDsc = new string[] {""} ;
         T00397_A511TipSigno = new short[1] ;
         T00397_n511TipSigno = new bool[] {false} ;
         T00397_A260CPTipCod = new string[] {""} ;
         T00397_A262CPPrvCod = new string[] {""} ;
         T00397_A263CPMonCod = new int[1] ;
         T00394_A856CPTipAbr = new string[] {""} ;
         T00394_A511TipSigno = new short[1] ;
         T00394_n511TipSigno = new bool[] {false} ;
         T00395_A831CPPrvDsc = new string[] {""} ;
         T00396_A830CPMonDsc = new string[] {""} ;
         T00398_A856CPTipAbr = new string[] {""} ;
         T00398_A511TipSigno = new short[1] ;
         T00398_n511TipSigno = new bool[] {false} ;
         T00399_A831CPPrvDsc = new string[] {""} ;
         T003910_A830CPMonDsc = new string[] {""} ;
         T003911_A260CPTipCod = new string[] {""} ;
         T003911_A261CPComCod = new string[] {""} ;
         T003911_A262CPPrvCod = new string[] {""} ;
         T00393_A261CPComCod = new string[] {""} ;
         T00393_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         T00393_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         T00393_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         T00393_A820CPImpTotal = new decimal[1] ;
         T00393_A818CPImpPago = new decimal[1] ;
         T00393_A815CPEstado = new string[] {""} ;
         T00393_A260CPTipCod = new string[] {""} ;
         T00393_A262CPPrvCod = new string[] {""} ;
         T00393_A263CPMonCod = new int[1] ;
         sMode112 = "";
         T003912_A260CPTipCod = new string[] {""} ;
         T003912_A261CPComCod = new string[] {""} ;
         T003912_A262CPPrvCod = new string[] {""} ;
         T003913_A260CPTipCod = new string[] {""} ;
         T003913_A261CPComCod = new string[] {""} ;
         T003913_A262CPPrvCod = new string[] {""} ;
         T00392_A261CPComCod = new string[] {""} ;
         T00392_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         T00392_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         T00392_A816CPFReg = new DateTime[] {DateTime.MinValue} ;
         T00392_A820CPImpTotal = new decimal[1] ;
         T00392_A818CPImpPago = new decimal[1] ;
         T00392_A815CPEstado = new string[] {""} ;
         T00392_A260CPTipCod = new string[] {""} ;
         T00392_A262CPPrvCod = new string[] {""} ;
         T00392_A263CPMonCod = new int[1] ;
         T003917_A856CPTipAbr = new string[] {""} ;
         T003917_A511TipSigno = new short[1] ;
         T003917_n511TipSigno = new bool[] {false} ;
         T003918_A831CPPrvDsc = new string[] {""} ;
         T003919_A830CPMonDsc = new string[] {""} ;
         T003920_A412PagReg = new long[1] ;
         T003920_A419PagItem = new short[1] ;
         T003921_A302CPRetCod = new string[] {""} ;
         T003921_A303CPRetPrvCod = new string[] {""} ;
         T003921_A304CPRetTipCod = new string[] {""} ;
         T003921_A305CPRetComCod = new string[] {""} ;
         T003922_A270LiqCod = new string[] {""} ;
         T003922_A236LiqPrvCod = new string[] {""} ;
         T003922_A277LiqMItem = new int[1] ;
         T003923_A260CPTipCod = new string[] {""} ;
         T003923_A261CPComCod = new string[] {""} ;
         T003923_A262CPPrvCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ260CPTipCod = "";
         ZZ261CPComCod = "";
         ZZ262CPPrvCod = "";
         ZZ264CPFech = DateTime.MinValue;
         ZZ817CPFVcto = DateTime.MinValue;
         ZZ816CPFReg = DateTime.MinValue;
         ZZ815CPEstado = "";
         ZZ856CPTipAbr = "";
         ZZ831CPPrvDsc = "";
         ZZ830CPMonDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpcuentapagar__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpcuentapagar__default(),
            new Object[][] {
                new Object[] {
               T00392_A261CPComCod, T00392_A264CPFech, T00392_A817CPFVcto, T00392_A816CPFReg, T00392_A820CPImpTotal, T00392_A818CPImpPago, T00392_A815CPEstado, T00392_A260CPTipCod, T00392_A262CPPrvCod, T00392_A263CPMonCod
               }
               , new Object[] {
               T00393_A261CPComCod, T00393_A264CPFech, T00393_A817CPFVcto, T00393_A816CPFReg, T00393_A820CPImpTotal, T00393_A818CPImpPago, T00393_A815CPEstado, T00393_A260CPTipCod, T00393_A262CPPrvCod, T00393_A263CPMonCod
               }
               , new Object[] {
               T00394_A856CPTipAbr, T00394_A511TipSigno, T00394_n511TipSigno
               }
               , new Object[] {
               T00395_A831CPPrvDsc
               }
               , new Object[] {
               T00396_A830CPMonDsc
               }
               , new Object[] {
               T00397_A261CPComCod, T00397_A856CPTipAbr, T00397_A264CPFech, T00397_A817CPFVcto, T00397_A816CPFReg, T00397_A830CPMonDsc, T00397_A820CPImpTotal, T00397_A818CPImpPago, T00397_A815CPEstado, T00397_A831CPPrvDsc,
               T00397_A511TipSigno, T00397_n511TipSigno, T00397_A260CPTipCod, T00397_A262CPPrvCod, T00397_A263CPMonCod
               }
               , new Object[] {
               T00398_A856CPTipAbr, T00398_A511TipSigno, T00398_n511TipSigno
               }
               , new Object[] {
               T00399_A831CPPrvDsc
               }
               , new Object[] {
               T003910_A830CPMonDsc
               }
               , new Object[] {
               T003911_A260CPTipCod, T003911_A261CPComCod, T003911_A262CPPrvCod
               }
               , new Object[] {
               T003912_A260CPTipCod, T003912_A261CPComCod, T003912_A262CPPrvCod
               }
               , new Object[] {
               T003913_A260CPTipCod, T003913_A261CPComCod, T003913_A262CPPrvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003917_A856CPTipAbr, T003917_A511TipSigno, T003917_n511TipSigno
               }
               , new Object[] {
               T003918_A831CPPrvDsc
               }
               , new Object[] {
               T003919_A830CPMonDsc
               }
               , new Object[] {
               T003920_A412PagReg, T003920_A419PagItem
               }
               , new Object[] {
               T003921_A302CPRetCod, T003921_A303CPRetPrvCod, T003921_A304CPRetTipCod, T003921_A305CPRetComCod
               }
               , new Object[] {
               T003922_A270LiqCod, T003922_A236LiqPrvCod, T003922_A277LiqMItem
               }
               , new Object[] {
               T003923_A260CPTipCod, T003923_A261CPComCod, T003923_A262CPPrvCod
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
      private short RcdFound112 ;
      private short nIsDirty_112 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ511TipSigno ;
      private int Z263CPMonCod ;
      private int A263CPMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCPTipCod_Enabled ;
      private int edtCPComCod_Enabled ;
      private int edtCPPrvCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCPFech_Enabled ;
      private int edtCPFVcto_Enabled ;
      private int edtCPFReg_Enabled ;
      private int edtCPMonCod_Enabled ;
      private int edtCPImpTotal_Enabled ;
      private int edtCPImpPago_Enabled ;
      private int edtCPEstado_Enabled ;
      private int edtCPImpTotalSig_Enabled ;
      private int edtCPPrvDsc_Enabled ;
      private int edtCPImpSaldo_Enabled ;
      private int edtCPImpSaldoSig_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ263CPMonCod ;
      private decimal Z820CPImpTotal ;
      private decimal Z818CPImpPago ;
      private decimal A820CPImpTotal ;
      private decimal A818CPImpPago ;
      private decimal A822CPImpTotalSig ;
      private decimal A819CPImpSaldo ;
      private decimal A821CPImpSaldoSig ;
      private decimal Z822CPImpTotalSig ;
      private decimal Z819CPImpSaldo ;
      private decimal Z821CPImpSaldoSig ;
      private decimal ZZ820CPImpTotal ;
      private decimal ZZ818CPImpPago ;
      private decimal ZZ822CPImpTotalSig ;
      private decimal ZZ819CPImpSaldo ;
      private decimal ZZ821CPImpSaldoSig ;
      private string sPrefix ;
      private string Z260CPTipCod ;
      private string Z261CPComCod ;
      private string Z262CPPrvCod ;
      private string Z815CPEstado ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A260CPTipCod ;
      private string A262CPPrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCPTipCod_Internalname ;
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
      private string edtCPTipCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCPComCod_Internalname ;
      private string A261CPComCod ;
      private string edtCPComCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCPPrvCod_Internalname ;
      private string edtCPPrvCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCPFech_Internalname ;
      private string edtCPFech_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCPFVcto_Internalname ;
      private string edtCPFVcto_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCPFReg_Internalname ;
      private string edtCPFReg_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCPMonCod_Internalname ;
      private string edtCPMonCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCPImpTotal_Internalname ;
      private string edtCPImpTotal_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCPImpPago_Internalname ;
      private string edtCPImpPago_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCPEstado_Internalname ;
      private string A815CPEstado ;
      private string edtCPEstado_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtCPImpTotalSig_Internalname ;
      private string edtCPImpTotalSig_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtCPPrvDsc_Internalname ;
      private string A831CPPrvDsc ;
      private string edtCPPrvDsc_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtCPImpSaldo_Internalname ;
      private string edtCPImpSaldo_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtCPImpSaldoSig_Internalname ;
      private string edtCPImpSaldoSig_Jsonclick ;
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
      private string A856CPTipAbr ;
      private string A830CPMonDsc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z856CPTipAbr ;
      private string Z831CPPrvDsc ;
      private string Z830CPMonDsc ;
      private string sMode112 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ260CPTipCod ;
      private string ZZ261CPComCod ;
      private string ZZ262CPPrvCod ;
      private string ZZ815CPEstado ;
      private string ZZ856CPTipAbr ;
      private string ZZ831CPPrvDsc ;
      private string ZZ830CPMonDsc ;
      private DateTime Z264CPFech ;
      private DateTime Z817CPFVcto ;
      private DateTime Z816CPFReg ;
      private DateTime A264CPFech ;
      private DateTime A817CPFVcto ;
      private DateTime A816CPFReg ;
      private DateTime ZZ264CPFech ;
      private DateTime ZZ817CPFVcto ;
      private DateTime ZZ816CPFReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n511TipSigno ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00397_A261CPComCod ;
      private string[] T00397_A856CPTipAbr ;
      private DateTime[] T00397_A264CPFech ;
      private DateTime[] T00397_A817CPFVcto ;
      private DateTime[] T00397_A816CPFReg ;
      private string[] T00397_A830CPMonDsc ;
      private decimal[] T00397_A820CPImpTotal ;
      private decimal[] T00397_A818CPImpPago ;
      private string[] T00397_A815CPEstado ;
      private string[] T00397_A831CPPrvDsc ;
      private short[] T00397_A511TipSigno ;
      private bool[] T00397_n511TipSigno ;
      private string[] T00397_A260CPTipCod ;
      private string[] T00397_A262CPPrvCod ;
      private int[] T00397_A263CPMonCod ;
      private string[] T00394_A856CPTipAbr ;
      private short[] T00394_A511TipSigno ;
      private bool[] T00394_n511TipSigno ;
      private string[] T00395_A831CPPrvDsc ;
      private string[] T00396_A830CPMonDsc ;
      private string[] T00398_A856CPTipAbr ;
      private short[] T00398_A511TipSigno ;
      private bool[] T00398_n511TipSigno ;
      private string[] T00399_A831CPPrvDsc ;
      private string[] T003910_A830CPMonDsc ;
      private string[] T003911_A260CPTipCod ;
      private string[] T003911_A261CPComCod ;
      private string[] T003911_A262CPPrvCod ;
      private string[] T00393_A261CPComCod ;
      private DateTime[] T00393_A264CPFech ;
      private DateTime[] T00393_A817CPFVcto ;
      private DateTime[] T00393_A816CPFReg ;
      private decimal[] T00393_A820CPImpTotal ;
      private decimal[] T00393_A818CPImpPago ;
      private string[] T00393_A815CPEstado ;
      private string[] T00393_A260CPTipCod ;
      private string[] T00393_A262CPPrvCod ;
      private int[] T00393_A263CPMonCod ;
      private string[] T003912_A260CPTipCod ;
      private string[] T003912_A261CPComCod ;
      private string[] T003912_A262CPPrvCod ;
      private string[] T003913_A260CPTipCod ;
      private string[] T003913_A261CPComCod ;
      private string[] T003913_A262CPPrvCod ;
      private string[] T00392_A261CPComCod ;
      private DateTime[] T00392_A264CPFech ;
      private DateTime[] T00392_A817CPFVcto ;
      private DateTime[] T00392_A816CPFReg ;
      private decimal[] T00392_A820CPImpTotal ;
      private decimal[] T00392_A818CPImpPago ;
      private string[] T00392_A815CPEstado ;
      private string[] T00392_A260CPTipCod ;
      private string[] T00392_A262CPPrvCod ;
      private int[] T00392_A263CPMonCod ;
      private string[] T003917_A856CPTipAbr ;
      private short[] T003917_A511TipSigno ;
      private bool[] T003917_n511TipSigno ;
      private string[] T003918_A831CPPrvDsc ;
      private string[] T003919_A830CPMonDsc ;
      private long[] T003920_A412PagReg ;
      private short[] T003920_A419PagItem ;
      private string[] T003921_A302CPRetCod ;
      private string[] T003921_A303CPRetPrvCod ;
      private string[] T003921_A304CPRetTipCod ;
      private string[] T003921_A305CPRetComCod ;
      private string[] T003922_A270LiqCod ;
      private string[] T003922_A236LiqPrvCod ;
      private int[] T003922_A277LiqMItem ;
      private string[] T003923_A260CPTipCod ;
      private string[] T003923_A261CPComCod ;
      private string[] T003923_A262CPPrvCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpcuentapagar__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpcuentapagar__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
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
        Object[] prmT00397;
        prmT00397 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00394;
        prmT00394 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0)
        };
        Object[] prmT00395;
        prmT00395 = new Object[] {
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00396;
        prmT00396 = new Object[] {
        new ParDef("@CPMonCod",GXType.Int32,6,0)
        };
        Object[] prmT00398;
        prmT00398 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0)
        };
        Object[] prmT00399;
        prmT00399 = new Object[] {
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003910;
        prmT003910 = new Object[] {
        new ParDef("@CPMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003911;
        prmT003911 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00393;
        prmT00393 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003912;
        prmT003912 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003913;
        prmT003913 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00392;
        prmT00392 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003914;
        prmT003914 = new Object[] {
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPFech",GXType.Date,8,0) ,
        new ParDef("@CPFVcto",GXType.Date,8,0) ,
        new ParDef("@CPFReg",GXType.Date,8,0) ,
        new ParDef("@CPImpTotal",GXType.Decimal,15,2) ,
        new ParDef("@CPImpPago",GXType.Decimal,15,2) ,
        new ParDef("@CPEstado",GXType.NChar,1,0) ,
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003915;
        prmT003915 = new Object[] {
        new ParDef("@CPFech",GXType.Date,8,0) ,
        new ParDef("@CPFVcto",GXType.Date,8,0) ,
        new ParDef("@CPFReg",GXType.Date,8,0) ,
        new ParDef("@CPImpTotal",GXType.Decimal,15,2) ,
        new ParDef("@CPImpPago",GXType.Decimal,15,2) ,
        new ParDef("@CPEstado",GXType.NChar,1,0) ,
        new ParDef("@CPMonCod",GXType.Int32,6,0) ,
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003916;
        prmT003916 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003920;
        prmT003920 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003921;
        prmT003921 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003922;
        prmT003922 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003923;
        prmT003923 = new Object[] {
        };
        Object[] prmT003917;
        prmT003917 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003918;
        prmT003918 = new Object[] {
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003919;
        prmT003919 = new Object[] {
        new ParDef("@CPMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00392", "SELECT [CPComCod], [CPFech], [CPFVcto], [CPFReg], [CPImpTotal], [CPImpPago], [CPEstado], [CPTipCod] AS CPTipCod, [CPPrvCod] AS CPPrvCod, [CPMonCod] AS CPMonCod FROM [CPCUENTAPAGAR] WITH (UPDLOCK) WHERE [CPTipCod] = @CPTipCod AND [CPComCod] = @CPComCod AND [CPPrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00392,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00393", "SELECT [CPComCod], [CPFech], [CPFVcto], [CPFReg], [CPImpTotal], [CPImpPago], [CPEstado], [CPTipCod] AS CPTipCod, [CPPrvCod] AS CPPrvCod, [CPMonCod] AS CPMonCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @CPTipCod AND [CPComCod] = @CPComCod AND [CPPrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00393,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00394", "SELECT [TipAbr] AS CPTipAbr, [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @CPTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00394,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00395", "SELECT [PrvDsc] AS CPPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00395,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00396", "SELECT [MonDsc] AS CPMonDsc FROM [CMONEDAS] WHERE [MonCod] = @CPMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00396,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00397", "SELECT TM1.[CPComCod], T2.[TipAbr] AS CPTipAbr, TM1.[CPFech], TM1.[CPFVcto], TM1.[CPFReg], T4.[MonDsc] AS CPMonDsc, TM1.[CPImpTotal], TM1.[CPImpPago], TM1.[CPEstado], T3.[PrvDsc] AS CPPrvDsc, T2.[TipSigno], TM1.[CPTipCod] AS CPTipCod, TM1.[CPPrvCod] AS CPPrvCod, TM1.[CPMonCod] AS CPMonCod FROM ((([CPCUENTAPAGAR] TM1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = TM1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = TM1.[CPPrvCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = TM1.[CPMonCod]) WHERE TM1.[CPTipCod] = @CPTipCod and TM1.[CPComCod] = @CPComCod and TM1.[CPPrvCod] = @CPPrvCod ORDER BY TM1.[CPTipCod], TM1.[CPComCod], TM1.[CPPrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00397,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00398", "SELECT [TipAbr] AS CPTipAbr, [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @CPTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00398,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00399", "SELECT [PrvDsc] AS CPPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00399,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003910", "SELECT [MonDsc] AS CPMonDsc FROM [CMONEDAS] WHERE [MonCod] = @CPMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003911", "SELECT [CPTipCod] AS CPTipCod, [CPComCod], [CPPrvCod] AS CPPrvCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @CPTipCod AND [CPComCod] = @CPComCod AND [CPPrvCod] = @CPPrvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003912", "SELECT TOP 1 [CPTipCod] AS CPTipCod, [CPComCod], [CPPrvCod] AS CPPrvCod FROM [CPCUENTAPAGAR] WHERE ( [CPTipCod] > @CPTipCod or [CPTipCod] = @CPTipCod and [CPComCod] > @CPComCod or [CPComCod] = @CPComCod and [CPTipCod] = @CPTipCod and [CPPrvCod] > @CPPrvCod) ORDER BY [CPTipCod], [CPComCod], [CPPrvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003912,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003913", "SELECT TOP 1 [CPTipCod] AS CPTipCod, [CPComCod], [CPPrvCod] AS CPPrvCod FROM [CPCUENTAPAGAR] WHERE ( [CPTipCod] < @CPTipCod or [CPTipCod] = @CPTipCod and [CPComCod] < @CPComCod or [CPComCod] = @CPComCod and [CPTipCod] = @CPTipCod and [CPPrvCod] < @CPPrvCod) ORDER BY [CPTipCod] DESC, [CPComCod] DESC, [CPPrvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003913,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003914", "INSERT INTO [CPCUENTAPAGAR]([CPComCod], [CPFech], [CPFVcto], [CPFReg], [CPImpTotal], [CPImpPago], [CPEstado], [CPTipCod], [CPPrvCod], [CPMonCod]) VALUES(@CPComCod, @CPFech, @CPFVcto, @CPFReg, @CPImpTotal, @CPImpPago, @CPEstado, @CPTipCod, @CPPrvCod, @CPMonCod)", GxErrorMask.GX_NOMASK,prmT003914)
           ,new CursorDef("T003915", "UPDATE [CPCUENTAPAGAR] SET [CPFech]=@CPFech, [CPFVcto]=@CPFVcto, [CPFReg]=@CPFReg, [CPImpTotal]=@CPImpTotal, [CPImpPago]=@CPImpPago, [CPEstado]=@CPEstado, [CPMonCod]=@CPMonCod  WHERE [CPTipCod] = @CPTipCod AND [CPComCod] = @CPComCod AND [CPPrvCod] = @CPPrvCod", GxErrorMask.GX_NOMASK,prmT003915)
           ,new CursorDef("T003916", "DELETE FROM [CPCUENTAPAGAR]  WHERE [CPTipCod] = @CPTipCod AND [CPComCod] = @CPComCod AND [CPPrvCod] = @CPPrvCod", GxErrorMask.GX_NOMASK,prmT003916)
           ,new CursorDef("T003917", "SELECT [TipAbr] AS CPTipAbr, [TipSigno] FROM [CTIPDOC] WHERE [TipCod] = @CPTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003917,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003918", "SELECT [PrvDsc] AS CPPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003918,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003919", "SELECT [MonDsc] AS CPMonDsc FROM [CMONEDAS] WHERE [MonCod] = @CPMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003919,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003920", "SELECT TOP 1 [PagReg], [PagItem] FROM [TSPAGOSDET] WHERE [PagDTipCod] = @CPTipCod AND [PagDComCod] = @CPComCod AND [PagDPrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003920,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003921", "SELECT TOP 1 [CPRetCod], [CPRetPrvCod], [CPRetTipCod], [CPRetComCod] FROM [CPRETENCIONDET] WHERE [CPRetTipCod] = @CPTipCod AND [CPRetComCod] = @CPComCod AND [CPRetPrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003921,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003922", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE [LiqMTipCod] = @CPTipCod AND [LiqMComCod] = @CPComCod AND [LiqMPrvCod] = @CPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003922,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003923", "SELECT [CPTipCod] AS CPTipCod, [CPComCod], [CPPrvCod] AS CPPrvCod FROM [CPCUENTAPAGAR] ORDER BY [CPTipCod], [CPComCod], [CPPrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003923,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 100);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 3);
              ((string[]) buf[13])[0] = rslt.getString(13, 20);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
     }
  }

}

}
