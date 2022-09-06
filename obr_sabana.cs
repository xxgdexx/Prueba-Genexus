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
   public class obr_sabana : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A312Iesa_SabProdCod = GetPar( "Iesa_SabProdCod");
            AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A312Iesa_SabProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A1000Iesa_SabLinCod = (int)(NumberUtil.Val( GetPar( "Iesa_SabLinCod"), "."));
            AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A1000Iesa_SabLinCod) ;
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
            Form.Meta.addItem("description", "OBR_ SABANA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtIesa_SabPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public obr_sabana( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public obr_sabana( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_OBR_SABANA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Pedido", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabPedCod_Internalname, StringUtil.RTrim( A310Iesa_SabPedCod), StringUtil.RTrim( context.localUtil.Format( A310Iesa_SabPedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabProdSec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A311Iesa_SabProdSec), 6, 0, ".", "")), StringUtil.LTrim( ((edtIesa_SabProdSec_Enabled!=0) ? context.localUtil.Format( (decimal)(A311Iesa_SabProdSec), "ZZZZZ9") : context.localUtil.Format( (decimal)(A311Iesa_SabProdSec), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabProdSec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabProdSec_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabProdCod_Internalname, StringUtil.RTrim( A312Iesa_SabProdCod), StringUtil.RTrim( context.localUtil.Format( A312Iesa_SabProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIesa_SabProdDsc_Internalname, StringUtil.RTrim( A1008Iesa_SabProdDsc), StringUtil.RTrim( context.localUtil.Format( A1008Iesa_SabProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Linea de Producto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIesa_SabLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1000Iesa_SabLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtIesa_SabLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1000Iesa_SabLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1000Iesa_SabLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Sub Linea", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIesa_SabSubLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1014Iesa_SabSubLCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtIesa_SabSubLCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1014Iesa_SabSubLCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1014Iesa_SabSubLCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabSubLCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabSubLCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Maneja Stock", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtIesa_SabLinStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1001Iesa_SabLinStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtIesa_SabLinStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1001Iesa_SabLinStk), "9") : context.localUtil.Format( (decimal)(A1001Iesa_SabLinStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabLinStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabLinStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fecha", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIesa_SabPedFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIesa_SabPedFec_Internalname, context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"), context.localUtil.Format( A1007Iesa_SabPedFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabPedFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabPedFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         GxWebStd.gx_bitmap( context, edtIesa_SabPedFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIesa_SabPedFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Codigo Obra", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_ObrCod_Internalname, StringUtil.RTrim( A994Iesa_ObrCod), StringUtil.RTrim( context.localUtil.Format( A994Iesa_ObrCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_ObrCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_ObrCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Codigo Area", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_AreCod_Internalname, StringUtil.RTrim( A991Iesa_AreCod), StringUtil.RTrim( context.localUtil.Format( A991Iesa_AreCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_AreCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_AreCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Codigo", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_CCosCod_Internalname, StringUtil.RTrim( A992Iesa_CCosCod), StringUtil.RTrim( context.localUtil.Format( A992Iesa_CCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_CCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_CCosCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Codigo Equipo", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_EquCod_Internalname, StringUtil.RTrim( A993Iesa_EquCod), StringUtil.RTrim( context.localUtil.Format( A993Iesa_EquCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_EquCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_EquCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Cantidad", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabPedCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1006Iesa_SabPedCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtIesa_SabPedCant_Enabled!=0) ? context.localUtil.Format( A1006Iesa_SabPedCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1006Iesa_SabPedCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabPedCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabPedCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "N° Orden", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabOcom_Internalname, StringUtil.RTrim( A1002Iesa_SabOcom), StringUtil.RTrim( context.localUtil.Format( A1002Iesa_SabOcom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabOcom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabOcom_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Cant. Ingresada", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A997Iesa_SabIng, 17, 4, ".", "")), StringUtil.LTrim( ((edtIesa_SabIng_Enabled!=0) ? context.localUtil.Format( A997Iesa_SabIng, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A997Iesa_SabIng, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabIng_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Fecha Orden", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIesa_SabOComFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIesa_SabOComFec_Internalname, context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"), context.localUtil.Format( A1004Iesa_SabOComFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabOComFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabOComFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         GxWebStd.gx_bitmap( context, edtIesa_SabOComFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIesa_SabOComFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "R.U.C.", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabPrvCod_Internalname, StringUtil.RTrim( A1009Iesa_SabPrvCod), StringUtil.RTrim( context.localUtil.Format( A1009Iesa_SabPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabPrvCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Proveedor", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabPrvDsc_Internalname, A1010Iesa_SabPrvDsc, StringUtil.RTrim( context.localUtil.Format( A1010Iesa_SabPrvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Costo Unit.", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabOComCos_Internalname, StringUtil.LTrim( StringUtil.NToC( A1003Iesa_SabOComCos, 17, 4, ".", "")), StringUtil.LTrim( ((edtIesa_SabOComCos_Enabled!=0) ? context.localUtil.Format( A1003Iesa_SabOComCos, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1003Iesa_SabOComCos, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabOComCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabOComCos_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "N° Ingreso", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabIngreso_Internalname, StringUtil.RTrim( A999Iesa_SabIngreso), StringUtil.RTrim( context.localUtil.Format( A999Iesa_SabIngreso, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabIngreso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabIngreso_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "F.Ingreso", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIesa_SabIngFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIesa_SabIngFec_Internalname, context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"), context.localUtil.Format( A998Iesa_SabIngFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabIngFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabIngFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         GxWebStd.gx_bitmap( context, edtIesa_SabIngFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIesa_SabIngFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Estado", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabSts_Internalname, StringUtil.RTrim( A1013Iesa_SabSts), StringUtil.RTrim( context.localUtil.Format( A1013Iesa_SabSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Autorizaciones", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabBoton_Internalname, StringUtil.RTrim( A995Iesa_SabBoton), StringUtil.RTrim( context.localUtil.Format( A995Iesa_SabBoton, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabBoton_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabBoton_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "T/S", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabTipSal_Internalname, StringUtil.RTrim( A1015Iesa_SabTipSal), StringUtil.RTrim( context.localUtil.Format( A1015Iesa_SabTipSal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabTipSal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabTipSal_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "N° Salida", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabSalida_Internalname, StringUtil.RTrim( A1012Iesa_SabSalida), StringUtil.RTrim( context.localUtil.Format( A1012Iesa_SabSalida, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabSalida_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabSalida_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Fecha Salida", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtIesa_SabSalFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtIesa_SabSalFec_Internalname, context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"), context.localUtil.Format( A1011Iesa_SabSalFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabSalFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabSalFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_OBR_SABANA.htm");
         GxWebStd.gx_bitmap( context, edtIesa_SabSalFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtIesa_SabSalFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Cant.Atendida", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabCantAten_Internalname, StringUtil.LTrim( StringUtil.NToC( A996Iesa_SabCantAten, 17, 4, ".", "")), StringUtil.LTrim( ((edtIesa_SabCantAten_Enabled!=0) ? context.localUtil.Format( A996Iesa_SabCantAten, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A996Iesa_SabCantAten, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabCantAten_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabCantAten_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "N° OT", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_OBR_SABANA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIesa_SabOT_Internalname, A1005Iesa_SabOT, StringUtil.RTrim( context.localUtil.Format( A1005Iesa_SabOT, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIesa_SabOT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIesa_SabOT_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_OBR_SABANA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_OBR_SABANA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_OBR_SABANA.htm");
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
            Z310Iesa_SabPedCod = cgiGet( "Z310Iesa_SabPedCod");
            Z311Iesa_SabProdSec = (int)(context.localUtil.CToN( cgiGet( "Z311Iesa_SabProdSec"), ".", ","));
            Z312Iesa_SabProdCod = cgiGet( "Z312Iesa_SabProdCod");
            Z1007Iesa_SabPedFec = context.localUtil.CToD( cgiGet( "Z1007Iesa_SabPedFec"), 0);
            Z994Iesa_ObrCod = cgiGet( "Z994Iesa_ObrCod");
            Z991Iesa_AreCod = cgiGet( "Z991Iesa_AreCod");
            Z992Iesa_CCosCod = cgiGet( "Z992Iesa_CCosCod");
            Z993Iesa_EquCod = cgiGet( "Z993Iesa_EquCod");
            Z1006Iesa_SabPedCant = context.localUtil.CToN( cgiGet( "Z1006Iesa_SabPedCant"), ".", ",");
            Z1002Iesa_SabOcom = cgiGet( "Z1002Iesa_SabOcom");
            Z997Iesa_SabIng = context.localUtil.CToN( cgiGet( "Z997Iesa_SabIng"), ".", ",");
            Z1004Iesa_SabOComFec = context.localUtil.CToD( cgiGet( "Z1004Iesa_SabOComFec"), 0);
            Z1009Iesa_SabPrvCod = cgiGet( "Z1009Iesa_SabPrvCod");
            Z1010Iesa_SabPrvDsc = cgiGet( "Z1010Iesa_SabPrvDsc");
            Z1003Iesa_SabOComCos = context.localUtil.CToN( cgiGet( "Z1003Iesa_SabOComCos"), ".", ",");
            Z999Iesa_SabIngreso = cgiGet( "Z999Iesa_SabIngreso");
            Z998Iesa_SabIngFec = context.localUtil.CToD( cgiGet( "Z998Iesa_SabIngFec"), 0);
            Z1013Iesa_SabSts = cgiGet( "Z1013Iesa_SabSts");
            Z995Iesa_SabBoton = cgiGet( "Z995Iesa_SabBoton");
            Z1015Iesa_SabTipSal = cgiGet( "Z1015Iesa_SabTipSal");
            Z1012Iesa_SabSalida = cgiGet( "Z1012Iesa_SabSalida");
            Z1011Iesa_SabSalFec = context.localUtil.CToD( cgiGet( "Z1011Iesa_SabSalFec"), 0);
            Z996Iesa_SabCantAten = context.localUtil.CToN( cgiGet( "Z996Iesa_SabCantAten"), ".", ",");
            Z1005Iesa_SabOT = cgiGet( "Z1005Iesa_SabOT");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A310Iesa_SabPedCod = cgiGet( edtIesa_SabPedCod_Internalname);
            AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtIesa_SabProdSec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIesa_SabProdSec_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IESA_SABPRODSEC");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabProdSec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A311Iesa_SabProdSec = 0;
               AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
            }
            else
            {
               A311Iesa_SabProdSec = (int)(context.localUtil.CToN( cgiGet( edtIesa_SabProdSec_Internalname), ".", ","));
               AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
            }
            A312Iesa_SabProdCod = StringUtil.Upper( cgiGet( edtIesa_SabProdCod_Internalname));
            AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
            A1008Iesa_SabProdDsc = cgiGet( edtIesa_SabProdDsc_Internalname);
            AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
            A1000Iesa_SabLinCod = (int)(context.localUtil.CToN( cgiGet( edtIesa_SabLinCod_Internalname), ".", ","));
            AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
            A1014Iesa_SabSubLCod = (int)(context.localUtil.CToN( cgiGet( edtIesa_SabSubLCod_Internalname), ".", ","));
            n1014Iesa_SabSubLCod = false;
            AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
            A1001Iesa_SabLinStk = (short)(context.localUtil.CToN( cgiGet( edtIesa_SabLinStk_Internalname), ".", ","));
            AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
            if ( context.localUtil.VCDate( cgiGet( edtIesa_SabPedFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "IESA_SABPEDFEC");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabPedFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1007Iesa_SabPedFec = DateTime.MinValue;
               AssignAttri("", false, "A1007Iesa_SabPedFec", context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"));
            }
            else
            {
               A1007Iesa_SabPedFec = context.localUtil.CToD( cgiGet( edtIesa_SabPedFec_Internalname), 2);
               AssignAttri("", false, "A1007Iesa_SabPedFec", context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"));
            }
            A994Iesa_ObrCod = cgiGet( edtIesa_ObrCod_Internalname);
            AssignAttri("", false, "A994Iesa_ObrCod", A994Iesa_ObrCod);
            A991Iesa_AreCod = cgiGet( edtIesa_AreCod_Internalname);
            AssignAttri("", false, "A991Iesa_AreCod", A991Iesa_AreCod);
            A992Iesa_CCosCod = cgiGet( edtIesa_CCosCod_Internalname);
            AssignAttri("", false, "A992Iesa_CCosCod", A992Iesa_CCosCod);
            A993Iesa_EquCod = cgiGet( edtIesa_EquCod_Internalname);
            AssignAttri("", false, "A993Iesa_EquCod", A993Iesa_EquCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtIesa_SabPedCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtIesa_SabPedCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IESA_SABPEDCANT");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabPedCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1006Iesa_SabPedCant = 0;
               AssignAttri("", false, "A1006Iesa_SabPedCant", StringUtil.LTrimStr( A1006Iesa_SabPedCant, 15, 4));
            }
            else
            {
               A1006Iesa_SabPedCant = context.localUtil.CToN( cgiGet( edtIesa_SabPedCant_Internalname), ".", ",");
               AssignAttri("", false, "A1006Iesa_SabPedCant", StringUtil.LTrimStr( A1006Iesa_SabPedCant, 15, 4));
            }
            A1002Iesa_SabOcom = cgiGet( edtIesa_SabOcom_Internalname);
            AssignAttri("", false, "A1002Iesa_SabOcom", A1002Iesa_SabOcom);
            if ( ( ( context.localUtil.CToN( cgiGet( edtIesa_SabIng_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtIesa_SabIng_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IESA_SABING");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A997Iesa_SabIng = 0;
               AssignAttri("", false, "A997Iesa_SabIng", StringUtil.LTrimStr( A997Iesa_SabIng, 15, 4));
            }
            else
            {
               A997Iesa_SabIng = context.localUtil.CToN( cgiGet( edtIesa_SabIng_Internalname), ".", ",");
               AssignAttri("", false, "A997Iesa_SabIng", StringUtil.LTrimStr( A997Iesa_SabIng, 15, 4));
            }
            if ( context.localUtil.VCDate( cgiGet( edtIesa_SabOComFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Orden"}), 1, "IESA_SABOCOMFEC");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabOComFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1004Iesa_SabOComFec = DateTime.MinValue;
               AssignAttri("", false, "A1004Iesa_SabOComFec", context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"));
            }
            else
            {
               A1004Iesa_SabOComFec = context.localUtil.CToD( cgiGet( edtIesa_SabOComFec_Internalname), 2);
               AssignAttri("", false, "A1004Iesa_SabOComFec", context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"));
            }
            A1009Iesa_SabPrvCod = cgiGet( edtIesa_SabPrvCod_Internalname);
            AssignAttri("", false, "A1009Iesa_SabPrvCod", A1009Iesa_SabPrvCod);
            A1010Iesa_SabPrvDsc = cgiGet( edtIesa_SabPrvDsc_Internalname);
            AssignAttri("", false, "A1010Iesa_SabPrvDsc", A1010Iesa_SabPrvDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtIesa_SabOComCos_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtIesa_SabOComCos_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IESA_SABOCOMCOS");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabOComCos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1003Iesa_SabOComCos = 0;
               AssignAttri("", false, "A1003Iesa_SabOComCos", StringUtil.LTrimStr( A1003Iesa_SabOComCos, 15, 4));
            }
            else
            {
               A1003Iesa_SabOComCos = context.localUtil.CToN( cgiGet( edtIesa_SabOComCos_Internalname), ".", ",");
               AssignAttri("", false, "A1003Iesa_SabOComCos", StringUtil.LTrimStr( A1003Iesa_SabOComCos, 15, 4));
            }
            A999Iesa_SabIngreso = cgiGet( edtIesa_SabIngreso_Internalname);
            AssignAttri("", false, "A999Iesa_SabIngreso", A999Iesa_SabIngreso);
            if ( context.localUtil.VCDate( cgiGet( edtIesa_SabIngFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"F.Ingreso"}), 1, "IESA_SABINGFEC");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabIngFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A998Iesa_SabIngFec = DateTime.MinValue;
               AssignAttri("", false, "A998Iesa_SabIngFec", context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"));
            }
            else
            {
               A998Iesa_SabIngFec = context.localUtil.CToD( cgiGet( edtIesa_SabIngFec_Internalname), 2);
               AssignAttri("", false, "A998Iesa_SabIngFec", context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"));
            }
            A1013Iesa_SabSts = cgiGet( edtIesa_SabSts_Internalname);
            AssignAttri("", false, "A1013Iesa_SabSts", A1013Iesa_SabSts);
            A995Iesa_SabBoton = cgiGet( edtIesa_SabBoton_Internalname);
            AssignAttri("", false, "A995Iesa_SabBoton", A995Iesa_SabBoton);
            A1015Iesa_SabTipSal = cgiGet( edtIesa_SabTipSal_Internalname);
            AssignAttri("", false, "A1015Iesa_SabTipSal", A1015Iesa_SabTipSal);
            A1012Iesa_SabSalida = cgiGet( edtIesa_SabSalida_Internalname);
            AssignAttri("", false, "A1012Iesa_SabSalida", A1012Iesa_SabSalida);
            if ( context.localUtil.VCDate( cgiGet( edtIesa_SabSalFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Salida"}), 1, "IESA_SABSALFEC");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabSalFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1011Iesa_SabSalFec = DateTime.MinValue;
               AssignAttri("", false, "A1011Iesa_SabSalFec", context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"));
            }
            else
            {
               A1011Iesa_SabSalFec = context.localUtil.CToD( cgiGet( edtIesa_SabSalFec_Internalname), 2);
               AssignAttri("", false, "A1011Iesa_SabSalFec", context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtIesa_SabCantAten_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtIesa_SabCantAten_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IESA_SABCANTATEN");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabCantAten_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A996Iesa_SabCantAten = 0;
               AssignAttri("", false, "A996Iesa_SabCantAten", StringUtil.LTrimStr( A996Iesa_SabCantAten, 15, 4));
            }
            else
            {
               A996Iesa_SabCantAten = context.localUtil.CToN( cgiGet( edtIesa_SabCantAten_Internalname), ".", ",");
               AssignAttri("", false, "A996Iesa_SabCantAten", StringUtil.LTrimStr( A996Iesa_SabCantAten, 15, 4));
            }
            A1005Iesa_SabOT = cgiGet( edtIesa_SabOT_Internalname);
            AssignAttri("", false, "A1005Iesa_SabOT", A1005Iesa_SabOT);
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
               A310Iesa_SabPedCod = GetPar( "Iesa_SabPedCod");
               AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
               A311Iesa_SabProdSec = (int)(NumberUtil.Val( GetPar( "Iesa_SabProdSec"), "."));
               AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
               A312Iesa_SabProdCod = GetPar( "Iesa_SabProdCod");
               AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
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
               InitAll41140( ) ;
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
         DisableAttributes41140( ) ;
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

      protected void CONFIRM_410( )
      {
         BeforeValidate41140( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls41140( ) ;
            }
            else
            {
               CheckExtendedTable41140( ) ;
               if ( AnyError == 0 )
               {
                  ZM41140( 6) ;
                  ZM41140( 7) ;
               }
               CloseExtendedTableCursors41140( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues410( ) ;
         }
      }

      protected void ResetCaption410( )
      {
      }

      protected void ZM41140( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1007Iesa_SabPedFec = T00413_A1007Iesa_SabPedFec[0];
               Z994Iesa_ObrCod = T00413_A994Iesa_ObrCod[0];
               Z991Iesa_AreCod = T00413_A991Iesa_AreCod[0];
               Z992Iesa_CCosCod = T00413_A992Iesa_CCosCod[0];
               Z993Iesa_EquCod = T00413_A993Iesa_EquCod[0];
               Z1006Iesa_SabPedCant = T00413_A1006Iesa_SabPedCant[0];
               Z1002Iesa_SabOcom = T00413_A1002Iesa_SabOcom[0];
               Z997Iesa_SabIng = T00413_A997Iesa_SabIng[0];
               Z1004Iesa_SabOComFec = T00413_A1004Iesa_SabOComFec[0];
               Z1009Iesa_SabPrvCod = T00413_A1009Iesa_SabPrvCod[0];
               Z1010Iesa_SabPrvDsc = T00413_A1010Iesa_SabPrvDsc[0];
               Z1003Iesa_SabOComCos = T00413_A1003Iesa_SabOComCos[0];
               Z999Iesa_SabIngreso = T00413_A999Iesa_SabIngreso[0];
               Z998Iesa_SabIngFec = T00413_A998Iesa_SabIngFec[0];
               Z1013Iesa_SabSts = T00413_A1013Iesa_SabSts[0];
               Z995Iesa_SabBoton = T00413_A995Iesa_SabBoton[0];
               Z1015Iesa_SabTipSal = T00413_A1015Iesa_SabTipSal[0];
               Z1012Iesa_SabSalida = T00413_A1012Iesa_SabSalida[0];
               Z1011Iesa_SabSalFec = T00413_A1011Iesa_SabSalFec[0];
               Z996Iesa_SabCantAten = T00413_A996Iesa_SabCantAten[0];
               Z1005Iesa_SabOT = T00413_A1005Iesa_SabOT[0];
            }
            else
            {
               Z1007Iesa_SabPedFec = A1007Iesa_SabPedFec;
               Z994Iesa_ObrCod = A994Iesa_ObrCod;
               Z991Iesa_AreCod = A991Iesa_AreCod;
               Z992Iesa_CCosCod = A992Iesa_CCosCod;
               Z993Iesa_EquCod = A993Iesa_EquCod;
               Z1006Iesa_SabPedCant = A1006Iesa_SabPedCant;
               Z1002Iesa_SabOcom = A1002Iesa_SabOcom;
               Z997Iesa_SabIng = A997Iesa_SabIng;
               Z1004Iesa_SabOComFec = A1004Iesa_SabOComFec;
               Z1009Iesa_SabPrvCod = A1009Iesa_SabPrvCod;
               Z1010Iesa_SabPrvDsc = A1010Iesa_SabPrvDsc;
               Z1003Iesa_SabOComCos = A1003Iesa_SabOComCos;
               Z999Iesa_SabIngreso = A999Iesa_SabIngreso;
               Z998Iesa_SabIngFec = A998Iesa_SabIngFec;
               Z1013Iesa_SabSts = A1013Iesa_SabSts;
               Z995Iesa_SabBoton = A995Iesa_SabBoton;
               Z1015Iesa_SabTipSal = A1015Iesa_SabTipSal;
               Z1012Iesa_SabSalida = A1012Iesa_SabSalida;
               Z1011Iesa_SabSalFec = A1011Iesa_SabSalFec;
               Z996Iesa_SabCantAten = A996Iesa_SabCantAten;
               Z1005Iesa_SabOT = A1005Iesa_SabOT;
            }
         }
         if ( GX_JID == -5 )
         {
            Z310Iesa_SabPedCod = A310Iesa_SabPedCod;
            Z311Iesa_SabProdSec = A311Iesa_SabProdSec;
            Z1007Iesa_SabPedFec = A1007Iesa_SabPedFec;
            Z994Iesa_ObrCod = A994Iesa_ObrCod;
            Z991Iesa_AreCod = A991Iesa_AreCod;
            Z992Iesa_CCosCod = A992Iesa_CCosCod;
            Z993Iesa_EquCod = A993Iesa_EquCod;
            Z1006Iesa_SabPedCant = A1006Iesa_SabPedCant;
            Z1002Iesa_SabOcom = A1002Iesa_SabOcom;
            Z997Iesa_SabIng = A997Iesa_SabIng;
            Z1004Iesa_SabOComFec = A1004Iesa_SabOComFec;
            Z1009Iesa_SabPrvCod = A1009Iesa_SabPrvCod;
            Z1010Iesa_SabPrvDsc = A1010Iesa_SabPrvDsc;
            Z1003Iesa_SabOComCos = A1003Iesa_SabOComCos;
            Z999Iesa_SabIngreso = A999Iesa_SabIngreso;
            Z998Iesa_SabIngFec = A998Iesa_SabIngFec;
            Z1013Iesa_SabSts = A1013Iesa_SabSts;
            Z995Iesa_SabBoton = A995Iesa_SabBoton;
            Z1015Iesa_SabTipSal = A1015Iesa_SabTipSal;
            Z1012Iesa_SabSalida = A1012Iesa_SabSalida;
            Z1011Iesa_SabSalFec = A1011Iesa_SabSalFec;
            Z996Iesa_SabCantAten = A996Iesa_SabCantAten;
            Z1005Iesa_SabOT = A1005Iesa_SabOT;
            Z312Iesa_SabProdCod = A312Iesa_SabProdCod;
            Z1008Iesa_SabProdDsc = A1008Iesa_SabProdDsc;
            Z1000Iesa_SabLinCod = A1000Iesa_SabLinCod;
            Z1014Iesa_SabSubLCod = A1014Iesa_SabSubLCod;
            Z1001Iesa_SabLinStk = A1001Iesa_SabLinStk;
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

      protected void Load41140( )
      {
         /* Using cursor T00416 */
         pr_default.execute(4, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound140 = 1;
            A1008Iesa_SabProdDsc = T00416_A1008Iesa_SabProdDsc[0];
            AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
            A1001Iesa_SabLinStk = T00416_A1001Iesa_SabLinStk[0];
            AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
            A1007Iesa_SabPedFec = T00416_A1007Iesa_SabPedFec[0];
            AssignAttri("", false, "A1007Iesa_SabPedFec", context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"));
            A994Iesa_ObrCod = T00416_A994Iesa_ObrCod[0];
            AssignAttri("", false, "A994Iesa_ObrCod", A994Iesa_ObrCod);
            A991Iesa_AreCod = T00416_A991Iesa_AreCod[0];
            AssignAttri("", false, "A991Iesa_AreCod", A991Iesa_AreCod);
            A992Iesa_CCosCod = T00416_A992Iesa_CCosCod[0];
            AssignAttri("", false, "A992Iesa_CCosCod", A992Iesa_CCosCod);
            A993Iesa_EquCod = T00416_A993Iesa_EquCod[0];
            AssignAttri("", false, "A993Iesa_EquCod", A993Iesa_EquCod);
            A1006Iesa_SabPedCant = T00416_A1006Iesa_SabPedCant[0];
            AssignAttri("", false, "A1006Iesa_SabPedCant", StringUtil.LTrimStr( A1006Iesa_SabPedCant, 15, 4));
            A1002Iesa_SabOcom = T00416_A1002Iesa_SabOcom[0];
            AssignAttri("", false, "A1002Iesa_SabOcom", A1002Iesa_SabOcom);
            A997Iesa_SabIng = T00416_A997Iesa_SabIng[0];
            AssignAttri("", false, "A997Iesa_SabIng", StringUtil.LTrimStr( A997Iesa_SabIng, 15, 4));
            A1004Iesa_SabOComFec = T00416_A1004Iesa_SabOComFec[0];
            AssignAttri("", false, "A1004Iesa_SabOComFec", context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"));
            A1009Iesa_SabPrvCod = T00416_A1009Iesa_SabPrvCod[0];
            AssignAttri("", false, "A1009Iesa_SabPrvCod", A1009Iesa_SabPrvCod);
            A1010Iesa_SabPrvDsc = T00416_A1010Iesa_SabPrvDsc[0];
            AssignAttri("", false, "A1010Iesa_SabPrvDsc", A1010Iesa_SabPrvDsc);
            A1003Iesa_SabOComCos = T00416_A1003Iesa_SabOComCos[0];
            AssignAttri("", false, "A1003Iesa_SabOComCos", StringUtil.LTrimStr( A1003Iesa_SabOComCos, 15, 4));
            A999Iesa_SabIngreso = T00416_A999Iesa_SabIngreso[0];
            AssignAttri("", false, "A999Iesa_SabIngreso", A999Iesa_SabIngreso);
            A998Iesa_SabIngFec = T00416_A998Iesa_SabIngFec[0];
            AssignAttri("", false, "A998Iesa_SabIngFec", context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"));
            A1013Iesa_SabSts = T00416_A1013Iesa_SabSts[0];
            AssignAttri("", false, "A1013Iesa_SabSts", A1013Iesa_SabSts);
            A995Iesa_SabBoton = T00416_A995Iesa_SabBoton[0];
            AssignAttri("", false, "A995Iesa_SabBoton", A995Iesa_SabBoton);
            A1015Iesa_SabTipSal = T00416_A1015Iesa_SabTipSal[0];
            AssignAttri("", false, "A1015Iesa_SabTipSal", A1015Iesa_SabTipSal);
            A1012Iesa_SabSalida = T00416_A1012Iesa_SabSalida[0];
            AssignAttri("", false, "A1012Iesa_SabSalida", A1012Iesa_SabSalida);
            A1011Iesa_SabSalFec = T00416_A1011Iesa_SabSalFec[0];
            AssignAttri("", false, "A1011Iesa_SabSalFec", context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"));
            A996Iesa_SabCantAten = T00416_A996Iesa_SabCantAten[0];
            AssignAttri("", false, "A996Iesa_SabCantAten", StringUtil.LTrimStr( A996Iesa_SabCantAten, 15, 4));
            A1005Iesa_SabOT = T00416_A1005Iesa_SabOT[0];
            AssignAttri("", false, "A1005Iesa_SabOT", A1005Iesa_SabOT);
            A1000Iesa_SabLinCod = T00416_A1000Iesa_SabLinCod[0];
            AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
            A1014Iesa_SabSubLCod = T00416_A1014Iesa_SabSubLCod[0];
            n1014Iesa_SabSubLCod = T00416_n1014Iesa_SabSubLCod[0];
            AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
            ZM41140( -5) ;
         }
         pr_default.close(4);
         OnLoadActions41140( ) ;
      }

      protected void OnLoadActions41140( )
      {
      }

      protected void CheckExtendedTable41140( )
      {
         nIsDirty_140 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00414 */
         pr_default.execute(2, new Object[] {A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1008Iesa_SabProdDsc = T00414_A1008Iesa_SabProdDsc[0];
         AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
         A1000Iesa_SabLinCod = T00414_A1000Iesa_SabLinCod[0];
         AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
         A1014Iesa_SabSubLCod = T00414_A1014Iesa_SabSubLCod[0];
         n1014Iesa_SabSubLCod = T00414_n1014Iesa_SabSubLCod[0];
         AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
         pr_default.close(2);
         /* Using cursor T00415 */
         pr_default.execute(3, new Object[] {A1000Iesa_SabLinCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABLINCOD");
            AnyError = 1;
         }
         A1001Iesa_SabLinStk = T00415_A1001Iesa_SabLinStk[0];
         AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1007Iesa_SabPedFec) || ( DateTimeUtil.ResetTime ( A1007Iesa_SabPedFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "IESA_SABPEDFEC");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabPedFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1004Iesa_SabOComFec) || ( DateTimeUtil.ResetTime ( A1004Iesa_SabOComFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Orden fuera de rango", "OutOfRange", 1, "IESA_SABOCOMFEC");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabOComFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A998Iesa_SabIngFec) || ( DateTimeUtil.ResetTime ( A998Iesa_SabIngFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo F.Ingreso fuera de rango", "OutOfRange", 1, "IESA_SABINGFEC");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabIngFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1011Iesa_SabSalFec) || ( DateTimeUtil.ResetTime ( A1011Iesa_SabSalFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Salida fuera de rango", "OutOfRange", 1, "IESA_SABSALFEC");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabSalFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors41140( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( string A312Iesa_SabProdCod )
      {
         /* Using cursor T00417 */
         pr_default.execute(5, new Object[] {A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1008Iesa_SabProdDsc = T00417_A1008Iesa_SabProdDsc[0];
         AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
         A1000Iesa_SabLinCod = T00417_A1000Iesa_SabLinCod[0];
         AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
         A1014Iesa_SabSubLCod = T00417_A1014Iesa_SabSubLCod[0];
         n1014Iesa_SabSubLCod = T00417_n1014Iesa_SabSubLCod[0];
         AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1008Iesa_SabProdDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1000Iesa_SabLinCod), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1014Iesa_SabSubLCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( int A1000Iesa_SabLinCod )
      {
         /* Using cursor T00418 */
         pr_default.execute(6, new Object[] {A1000Iesa_SabLinCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABLINCOD");
            AnyError = 1;
         }
         A1001Iesa_SabLinStk = T00418_A1001Iesa_SabLinStk[0];
         AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1001Iesa_SabLinStk), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey41140( )
      {
         /* Using cursor T00419 */
         pr_default.execute(7, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound140 = 1;
         }
         else
         {
            RcdFound140 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00413 */
         pr_default.execute(1, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM41140( 5) ;
            RcdFound140 = 1;
            A310Iesa_SabPedCod = T00413_A310Iesa_SabPedCod[0];
            AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
            A311Iesa_SabProdSec = T00413_A311Iesa_SabProdSec[0];
            AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
            A1007Iesa_SabPedFec = T00413_A1007Iesa_SabPedFec[0];
            AssignAttri("", false, "A1007Iesa_SabPedFec", context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"));
            A994Iesa_ObrCod = T00413_A994Iesa_ObrCod[0];
            AssignAttri("", false, "A994Iesa_ObrCod", A994Iesa_ObrCod);
            A991Iesa_AreCod = T00413_A991Iesa_AreCod[0];
            AssignAttri("", false, "A991Iesa_AreCod", A991Iesa_AreCod);
            A992Iesa_CCosCod = T00413_A992Iesa_CCosCod[0];
            AssignAttri("", false, "A992Iesa_CCosCod", A992Iesa_CCosCod);
            A993Iesa_EquCod = T00413_A993Iesa_EquCod[0];
            AssignAttri("", false, "A993Iesa_EquCod", A993Iesa_EquCod);
            A1006Iesa_SabPedCant = T00413_A1006Iesa_SabPedCant[0];
            AssignAttri("", false, "A1006Iesa_SabPedCant", StringUtil.LTrimStr( A1006Iesa_SabPedCant, 15, 4));
            A1002Iesa_SabOcom = T00413_A1002Iesa_SabOcom[0];
            AssignAttri("", false, "A1002Iesa_SabOcom", A1002Iesa_SabOcom);
            A997Iesa_SabIng = T00413_A997Iesa_SabIng[0];
            AssignAttri("", false, "A997Iesa_SabIng", StringUtil.LTrimStr( A997Iesa_SabIng, 15, 4));
            A1004Iesa_SabOComFec = T00413_A1004Iesa_SabOComFec[0];
            AssignAttri("", false, "A1004Iesa_SabOComFec", context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"));
            A1009Iesa_SabPrvCod = T00413_A1009Iesa_SabPrvCod[0];
            AssignAttri("", false, "A1009Iesa_SabPrvCod", A1009Iesa_SabPrvCod);
            A1010Iesa_SabPrvDsc = T00413_A1010Iesa_SabPrvDsc[0];
            AssignAttri("", false, "A1010Iesa_SabPrvDsc", A1010Iesa_SabPrvDsc);
            A1003Iesa_SabOComCos = T00413_A1003Iesa_SabOComCos[0];
            AssignAttri("", false, "A1003Iesa_SabOComCos", StringUtil.LTrimStr( A1003Iesa_SabOComCos, 15, 4));
            A999Iesa_SabIngreso = T00413_A999Iesa_SabIngreso[0];
            AssignAttri("", false, "A999Iesa_SabIngreso", A999Iesa_SabIngreso);
            A998Iesa_SabIngFec = T00413_A998Iesa_SabIngFec[0];
            AssignAttri("", false, "A998Iesa_SabIngFec", context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"));
            A1013Iesa_SabSts = T00413_A1013Iesa_SabSts[0];
            AssignAttri("", false, "A1013Iesa_SabSts", A1013Iesa_SabSts);
            A995Iesa_SabBoton = T00413_A995Iesa_SabBoton[0];
            AssignAttri("", false, "A995Iesa_SabBoton", A995Iesa_SabBoton);
            A1015Iesa_SabTipSal = T00413_A1015Iesa_SabTipSal[0];
            AssignAttri("", false, "A1015Iesa_SabTipSal", A1015Iesa_SabTipSal);
            A1012Iesa_SabSalida = T00413_A1012Iesa_SabSalida[0];
            AssignAttri("", false, "A1012Iesa_SabSalida", A1012Iesa_SabSalida);
            A1011Iesa_SabSalFec = T00413_A1011Iesa_SabSalFec[0];
            AssignAttri("", false, "A1011Iesa_SabSalFec", context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"));
            A996Iesa_SabCantAten = T00413_A996Iesa_SabCantAten[0];
            AssignAttri("", false, "A996Iesa_SabCantAten", StringUtil.LTrimStr( A996Iesa_SabCantAten, 15, 4));
            A1005Iesa_SabOT = T00413_A1005Iesa_SabOT[0];
            AssignAttri("", false, "A1005Iesa_SabOT", A1005Iesa_SabOT);
            A312Iesa_SabProdCod = T00413_A312Iesa_SabProdCod[0];
            AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
            Z310Iesa_SabPedCod = A310Iesa_SabPedCod;
            Z311Iesa_SabProdSec = A311Iesa_SabProdSec;
            Z312Iesa_SabProdCod = A312Iesa_SabProdCod;
            sMode140 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load41140( ) ;
            if ( AnyError == 1 )
            {
               RcdFound140 = 0;
               InitializeNonKey41140( ) ;
            }
            Gx_mode = sMode140;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound140 = 0;
            InitializeNonKey41140( ) ;
            sMode140 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode140;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey41140( ) ;
         if ( RcdFound140 == 0 )
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
         RcdFound140 = 0;
         /* Using cursor T004110 */
         pr_default.execute(8, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004110_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) < 0 ) || ( StringUtil.StrCmp(T004110_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( T004110_A311Iesa_SabProdSec[0] < A311Iesa_SabProdSec ) || ( T004110_A311Iesa_SabProdSec[0] == A311Iesa_SabProdSec ) && ( StringUtil.StrCmp(T004110_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( StringUtil.StrCmp(T004110_A312Iesa_SabProdCod[0], A312Iesa_SabProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T004110_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) > 0 ) || ( StringUtil.StrCmp(T004110_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( T004110_A311Iesa_SabProdSec[0] > A311Iesa_SabProdSec ) || ( T004110_A311Iesa_SabProdSec[0] == A311Iesa_SabProdSec ) && ( StringUtil.StrCmp(T004110_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( StringUtil.StrCmp(T004110_A312Iesa_SabProdCod[0], A312Iesa_SabProdCod) > 0 ) ) )
            {
               A310Iesa_SabPedCod = T004110_A310Iesa_SabPedCod[0];
               AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
               A311Iesa_SabProdSec = T004110_A311Iesa_SabProdSec[0];
               AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
               A312Iesa_SabProdCod = T004110_A312Iesa_SabProdCod[0];
               AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
               RcdFound140 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound140 = 0;
         /* Using cursor T004111 */
         pr_default.execute(9, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004111_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) > 0 ) || ( StringUtil.StrCmp(T004111_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( T004111_A311Iesa_SabProdSec[0] > A311Iesa_SabProdSec ) || ( T004111_A311Iesa_SabProdSec[0] == A311Iesa_SabProdSec ) && ( StringUtil.StrCmp(T004111_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( StringUtil.StrCmp(T004111_A312Iesa_SabProdCod[0], A312Iesa_SabProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T004111_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) < 0 ) || ( StringUtil.StrCmp(T004111_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( T004111_A311Iesa_SabProdSec[0] < A311Iesa_SabProdSec ) || ( T004111_A311Iesa_SabProdSec[0] == A311Iesa_SabProdSec ) && ( StringUtil.StrCmp(T004111_A310Iesa_SabPedCod[0], A310Iesa_SabPedCod) == 0 ) && ( StringUtil.StrCmp(T004111_A312Iesa_SabProdCod[0], A312Iesa_SabProdCod) < 0 ) ) )
            {
               A310Iesa_SabPedCod = T004111_A310Iesa_SabPedCod[0];
               AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
               A311Iesa_SabProdSec = T004111_A311Iesa_SabProdSec[0];
               AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
               A312Iesa_SabProdCod = T004111_A312Iesa_SabProdCod[0];
               AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
               RcdFound140 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey41140( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtIesa_SabPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert41140( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound140 == 1 )
            {
               if ( ( StringUtil.StrCmp(A310Iesa_SabPedCod, Z310Iesa_SabPedCod) != 0 ) || ( A311Iesa_SabProdSec != Z311Iesa_SabProdSec ) || ( StringUtil.StrCmp(A312Iesa_SabProdCod, Z312Iesa_SabProdCod) != 0 ) )
               {
                  A310Iesa_SabPedCod = Z310Iesa_SabPedCod;
                  AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
                  A311Iesa_SabProdSec = Z311Iesa_SabProdSec;
                  AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
                  A312Iesa_SabProdCod = Z312Iesa_SabProdCod;
                  AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IESA_SABPEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtIesa_SabPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtIesa_SabPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update41140( ) ;
                  GX_FocusControl = edtIesa_SabPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A310Iesa_SabPedCod, Z310Iesa_SabPedCod) != 0 ) || ( A311Iesa_SabProdSec != Z311Iesa_SabProdSec ) || ( StringUtil.StrCmp(A312Iesa_SabProdCod, Z312Iesa_SabProdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtIesa_SabPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert41140( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IESA_SABPEDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtIesa_SabPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtIesa_SabPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert41140( ) ;
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
         if ( ( StringUtil.StrCmp(A310Iesa_SabPedCod, Z310Iesa_SabPedCod) != 0 ) || ( A311Iesa_SabProdSec != Z311Iesa_SabProdSec ) || ( StringUtil.StrCmp(A312Iesa_SabProdCod, Z312Iesa_SabProdCod) != 0 ) )
         {
            A310Iesa_SabPedCod = Z310Iesa_SabPedCod;
            AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
            A311Iesa_SabProdSec = Z311Iesa_SabProdSec;
            AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
            A312Iesa_SabProdCod = Z312Iesa_SabProdCod;
            AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IESA_SABPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtIesa_SabPedCod_Internalname;
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
         GetKey41140( ) ;
         if ( RcdFound140 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "IESA_SABPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A310Iesa_SabPedCod, Z310Iesa_SabPedCod) != 0 ) || ( A311Iesa_SabProdSec != Z311Iesa_SabProdSec ) || ( StringUtil.StrCmp(A312Iesa_SabProdCod, Z312Iesa_SabProdCod) != 0 ) )
            {
               A310Iesa_SabPedCod = Z310Iesa_SabPedCod;
               AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
               A311Iesa_SabProdSec = Z311Iesa_SabProdSec;
               AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
               A312Iesa_SabProdCod = Z312Iesa_SabProdCod;
               AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "IESA_SABPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtIesa_SabPedCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A310Iesa_SabPedCod, Z310Iesa_SabPedCod) != 0 ) || ( A311Iesa_SabProdSec != Z311Iesa_SabProdSec ) || ( StringUtil.StrCmp(A312Iesa_SabProdCod, Z312Iesa_SabProdCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IESA_SABPEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtIesa_SabPedCod_Internalname;
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
         context.RollbackDataStores("obr_sabana",pr_default);
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_410( ) ;
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
         if ( RcdFound140 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "IESA_SABPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart41140( ) ;
         if ( RcdFound140 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd41140( ) ;
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
         if ( RcdFound140 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
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
         if ( RcdFound140 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
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
         ScanStart41140( ) ;
         if ( RcdFound140 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound140 != 0 )
            {
               ScanNext41140( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd41140( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency41140( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00412 */
            pr_default.execute(0, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OBR_SABANA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1007Iesa_SabPedFec ) != DateTimeUtil.ResetTime ( T00412_A1007Iesa_SabPedFec[0] ) ) || ( StringUtil.StrCmp(Z994Iesa_ObrCod, T00412_A994Iesa_ObrCod[0]) != 0 ) || ( StringUtil.StrCmp(Z991Iesa_AreCod, T00412_A991Iesa_AreCod[0]) != 0 ) || ( StringUtil.StrCmp(Z992Iesa_CCosCod, T00412_A992Iesa_CCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z993Iesa_EquCod, T00412_A993Iesa_EquCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1006Iesa_SabPedCant != T00412_A1006Iesa_SabPedCant[0] ) || ( StringUtil.StrCmp(Z1002Iesa_SabOcom, T00412_A1002Iesa_SabOcom[0]) != 0 ) || ( Z997Iesa_SabIng != T00412_A997Iesa_SabIng[0] ) || ( DateTimeUtil.ResetTime ( Z1004Iesa_SabOComFec ) != DateTimeUtil.ResetTime ( T00412_A1004Iesa_SabOComFec[0] ) ) || ( StringUtil.StrCmp(Z1009Iesa_SabPrvCod, T00412_A1009Iesa_SabPrvCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1010Iesa_SabPrvDsc, T00412_A1010Iesa_SabPrvDsc[0]) != 0 ) || ( Z1003Iesa_SabOComCos != T00412_A1003Iesa_SabOComCos[0] ) || ( StringUtil.StrCmp(Z999Iesa_SabIngreso, T00412_A999Iesa_SabIngreso[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z998Iesa_SabIngFec ) != DateTimeUtil.ResetTime ( T00412_A998Iesa_SabIngFec[0] ) ) || ( StringUtil.StrCmp(Z1013Iesa_SabSts, T00412_A1013Iesa_SabSts[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z995Iesa_SabBoton, T00412_A995Iesa_SabBoton[0]) != 0 ) || ( StringUtil.StrCmp(Z1015Iesa_SabTipSal, T00412_A1015Iesa_SabTipSal[0]) != 0 ) || ( StringUtil.StrCmp(Z1012Iesa_SabSalida, T00412_A1012Iesa_SabSalida[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1011Iesa_SabSalFec ) != DateTimeUtil.ResetTime ( T00412_A1011Iesa_SabSalFec[0] ) ) || ( Z996Iesa_SabCantAten != T00412_A996Iesa_SabCantAten[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1005Iesa_SabOT, T00412_A1005Iesa_SabOT[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1007Iesa_SabPedFec ) != DateTimeUtil.ResetTime ( T00412_A1007Iesa_SabPedFec[0] ) )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabPedFec");
                  GXUtil.WriteLogRaw("Old: ",Z1007Iesa_SabPedFec);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1007Iesa_SabPedFec[0]);
               }
               if ( StringUtil.StrCmp(Z994Iesa_ObrCod, T00412_A994Iesa_ObrCod[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_ObrCod");
                  GXUtil.WriteLogRaw("Old: ",Z994Iesa_ObrCod);
                  GXUtil.WriteLogRaw("Current: ",T00412_A994Iesa_ObrCod[0]);
               }
               if ( StringUtil.StrCmp(Z991Iesa_AreCod, T00412_A991Iesa_AreCod[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_AreCod");
                  GXUtil.WriteLogRaw("Old: ",Z991Iesa_AreCod);
                  GXUtil.WriteLogRaw("Current: ",T00412_A991Iesa_AreCod[0]);
               }
               if ( StringUtil.StrCmp(Z992Iesa_CCosCod, T00412_A992Iesa_CCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_CCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z992Iesa_CCosCod);
                  GXUtil.WriteLogRaw("Current: ",T00412_A992Iesa_CCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z993Iesa_EquCod, T00412_A993Iesa_EquCod[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_EquCod");
                  GXUtil.WriteLogRaw("Old: ",Z993Iesa_EquCod);
                  GXUtil.WriteLogRaw("Current: ",T00412_A993Iesa_EquCod[0]);
               }
               if ( Z1006Iesa_SabPedCant != T00412_A1006Iesa_SabPedCant[0] )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabPedCant");
                  GXUtil.WriteLogRaw("Old: ",Z1006Iesa_SabPedCant);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1006Iesa_SabPedCant[0]);
               }
               if ( StringUtil.StrCmp(Z1002Iesa_SabOcom, T00412_A1002Iesa_SabOcom[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabOcom");
                  GXUtil.WriteLogRaw("Old: ",Z1002Iesa_SabOcom);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1002Iesa_SabOcom[0]);
               }
               if ( Z997Iesa_SabIng != T00412_A997Iesa_SabIng[0] )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabIng");
                  GXUtil.WriteLogRaw("Old: ",Z997Iesa_SabIng);
                  GXUtil.WriteLogRaw("Current: ",T00412_A997Iesa_SabIng[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1004Iesa_SabOComFec ) != DateTimeUtil.ResetTime ( T00412_A1004Iesa_SabOComFec[0] ) )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabOComFec");
                  GXUtil.WriteLogRaw("Old: ",Z1004Iesa_SabOComFec);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1004Iesa_SabOComFec[0]);
               }
               if ( StringUtil.StrCmp(Z1009Iesa_SabPrvCod, T00412_A1009Iesa_SabPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z1009Iesa_SabPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1009Iesa_SabPrvCod[0]);
               }
               if ( StringUtil.StrCmp(Z1010Iesa_SabPrvDsc, T00412_A1010Iesa_SabPrvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabPrvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1010Iesa_SabPrvDsc);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1010Iesa_SabPrvDsc[0]);
               }
               if ( Z1003Iesa_SabOComCos != T00412_A1003Iesa_SabOComCos[0] )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabOComCos");
                  GXUtil.WriteLogRaw("Old: ",Z1003Iesa_SabOComCos);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1003Iesa_SabOComCos[0]);
               }
               if ( StringUtil.StrCmp(Z999Iesa_SabIngreso, T00412_A999Iesa_SabIngreso[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabIngreso");
                  GXUtil.WriteLogRaw("Old: ",Z999Iesa_SabIngreso);
                  GXUtil.WriteLogRaw("Current: ",T00412_A999Iesa_SabIngreso[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z998Iesa_SabIngFec ) != DateTimeUtil.ResetTime ( T00412_A998Iesa_SabIngFec[0] ) )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabIngFec");
                  GXUtil.WriteLogRaw("Old: ",Z998Iesa_SabIngFec);
                  GXUtil.WriteLogRaw("Current: ",T00412_A998Iesa_SabIngFec[0]);
               }
               if ( StringUtil.StrCmp(Z1013Iesa_SabSts, T00412_A1013Iesa_SabSts[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabSts");
                  GXUtil.WriteLogRaw("Old: ",Z1013Iesa_SabSts);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1013Iesa_SabSts[0]);
               }
               if ( StringUtil.StrCmp(Z995Iesa_SabBoton, T00412_A995Iesa_SabBoton[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabBoton");
                  GXUtil.WriteLogRaw("Old: ",Z995Iesa_SabBoton);
                  GXUtil.WriteLogRaw("Current: ",T00412_A995Iesa_SabBoton[0]);
               }
               if ( StringUtil.StrCmp(Z1015Iesa_SabTipSal, T00412_A1015Iesa_SabTipSal[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabTipSal");
                  GXUtil.WriteLogRaw("Old: ",Z1015Iesa_SabTipSal);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1015Iesa_SabTipSal[0]);
               }
               if ( StringUtil.StrCmp(Z1012Iesa_SabSalida, T00412_A1012Iesa_SabSalida[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabSalida");
                  GXUtil.WriteLogRaw("Old: ",Z1012Iesa_SabSalida);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1012Iesa_SabSalida[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1011Iesa_SabSalFec ) != DateTimeUtil.ResetTime ( T00412_A1011Iesa_SabSalFec[0] ) )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabSalFec");
                  GXUtil.WriteLogRaw("Old: ",Z1011Iesa_SabSalFec);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1011Iesa_SabSalFec[0]);
               }
               if ( Z996Iesa_SabCantAten != T00412_A996Iesa_SabCantAten[0] )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabCantAten");
                  GXUtil.WriteLogRaw("Old: ",Z996Iesa_SabCantAten);
                  GXUtil.WriteLogRaw("Current: ",T00412_A996Iesa_SabCantAten[0]);
               }
               if ( StringUtil.StrCmp(Z1005Iesa_SabOT, T00412_A1005Iesa_SabOT[0]) != 0 )
               {
                  GXUtil.WriteLog("obr_sabana:[seudo value changed for attri]"+"Iesa_SabOT");
                  GXUtil.WriteLogRaw("Old: ",Z1005Iesa_SabOT);
                  GXUtil.WriteLogRaw("Current: ",T00412_A1005Iesa_SabOT[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"OBR_SABANA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert41140( )
      {
         BeforeValidate41140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable41140( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM41140( 0) ;
            CheckOptimisticConcurrency41140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm41140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert41140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004112 */
                     pr_default.execute(10, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A1007Iesa_SabPedFec, A994Iesa_ObrCod, A991Iesa_AreCod, A992Iesa_CCosCod, A993Iesa_EquCod, A1006Iesa_SabPedCant, A1002Iesa_SabOcom, A997Iesa_SabIng, A1004Iesa_SabOComFec, A1009Iesa_SabPrvCod, A1010Iesa_SabPrvDsc, A1003Iesa_SabOComCos, A999Iesa_SabIngreso, A998Iesa_SabIngFec, A1013Iesa_SabSts, A995Iesa_SabBoton, A1015Iesa_SabTipSal, A1012Iesa_SabSalida, A1011Iesa_SabSalFec, A996Iesa_SabCantAten, A1005Iesa_SabOT, A312Iesa_SabProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("OBR_SABANA");
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
                           ResetCaption410( ) ;
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
               Load41140( ) ;
            }
            EndLevel41140( ) ;
         }
         CloseExtendedTableCursors41140( ) ;
      }

      protected void Update41140( )
      {
         BeforeValidate41140( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable41140( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency41140( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm41140( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate41140( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004113 */
                     pr_default.execute(11, new Object[] {A1007Iesa_SabPedFec, A994Iesa_ObrCod, A991Iesa_AreCod, A992Iesa_CCosCod, A993Iesa_EquCod, A1006Iesa_SabPedCant, A1002Iesa_SabOcom, A997Iesa_SabIng, A1004Iesa_SabOComFec, A1009Iesa_SabPrvCod, A1010Iesa_SabPrvDsc, A1003Iesa_SabOComCos, A999Iesa_SabIngreso, A998Iesa_SabIngFec, A1013Iesa_SabSts, A995Iesa_SabBoton, A1015Iesa_SabTipSal, A1012Iesa_SabSalida, A1011Iesa_SabSalFec, A996Iesa_SabCantAten, A1005Iesa_SabOT, A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("OBR_SABANA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OBR_SABANA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate41140( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption410( ) ;
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
            EndLevel41140( ) ;
         }
         CloseExtendedTableCursors41140( ) ;
      }

      protected void DeferredUpdate41140( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate41140( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency41140( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls41140( ) ;
            AfterConfirm41140( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete41140( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004114 */
                  pr_default.execute(12, new Object[] {A310Iesa_SabPedCod, A311Iesa_SabProdSec, A312Iesa_SabProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("OBR_SABANA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound140 == 0 )
                        {
                           InitAll41140( ) ;
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
                        ResetCaption410( ) ;
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
         sMode140 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel41140( ) ;
         Gx_mode = sMode140;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls41140( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004115 */
            pr_default.execute(13, new Object[] {A312Iesa_SabProdCod});
            A1008Iesa_SabProdDsc = T004115_A1008Iesa_SabProdDsc[0];
            AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
            A1000Iesa_SabLinCod = T004115_A1000Iesa_SabLinCod[0];
            AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
            A1014Iesa_SabSubLCod = T004115_A1014Iesa_SabSubLCod[0];
            n1014Iesa_SabSubLCod = T004115_n1014Iesa_SabSubLCod[0];
            AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
            pr_default.close(13);
            /* Using cursor T004116 */
            pr_default.execute(14, new Object[] {A1000Iesa_SabLinCod});
            A1001Iesa_SabLinStk = T004116_A1001Iesa_SabLinStk[0];
            AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
            pr_default.close(14);
         }
      }

      protected void EndLevel41140( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete41140( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("obr_sabana",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues410( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("obr_sabana",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart41140( )
      {
         /* Using cursor T004117 */
         pr_default.execute(15);
         RcdFound140 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound140 = 1;
            A310Iesa_SabPedCod = T004117_A310Iesa_SabPedCod[0];
            AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
            A311Iesa_SabProdSec = T004117_A311Iesa_SabProdSec[0];
            AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
            A312Iesa_SabProdCod = T004117_A312Iesa_SabProdCod[0];
            AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext41140( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound140 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound140 = 1;
            A310Iesa_SabPedCod = T004117_A310Iesa_SabPedCod[0];
            AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
            A311Iesa_SabProdSec = T004117_A311Iesa_SabProdSec[0];
            AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
            A312Iesa_SabProdCod = T004117_A312Iesa_SabProdCod[0];
            AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
         }
      }

      protected void ScanEnd41140( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm41140( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert41140( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate41140( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete41140( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete41140( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate41140( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes41140( )
      {
         edtIesa_SabPedCod_Enabled = 0;
         AssignProp("", false, edtIesa_SabPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabPedCod_Enabled), 5, 0), true);
         edtIesa_SabProdSec_Enabled = 0;
         AssignProp("", false, edtIesa_SabProdSec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabProdSec_Enabled), 5, 0), true);
         edtIesa_SabProdCod_Enabled = 0;
         AssignProp("", false, edtIesa_SabProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabProdCod_Enabled), 5, 0), true);
         edtIesa_SabProdDsc_Enabled = 0;
         AssignProp("", false, edtIesa_SabProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabProdDsc_Enabled), 5, 0), true);
         edtIesa_SabLinCod_Enabled = 0;
         AssignProp("", false, edtIesa_SabLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabLinCod_Enabled), 5, 0), true);
         edtIesa_SabSubLCod_Enabled = 0;
         AssignProp("", false, edtIesa_SabSubLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabSubLCod_Enabled), 5, 0), true);
         edtIesa_SabLinStk_Enabled = 0;
         AssignProp("", false, edtIesa_SabLinStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabLinStk_Enabled), 5, 0), true);
         edtIesa_SabPedFec_Enabled = 0;
         AssignProp("", false, edtIesa_SabPedFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabPedFec_Enabled), 5, 0), true);
         edtIesa_ObrCod_Enabled = 0;
         AssignProp("", false, edtIesa_ObrCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_ObrCod_Enabled), 5, 0), true);
         edtIesa_AreCod_Enabled = 0;
         AssignProp("", false, edtIesa_AreCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_AreCod_Enabled), 5, 0), true);
         edtIesa_CCosCod_Enabled = 0;
         AssignProp("", false, edtIesa_CCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_CCosCod_Enabled), 5, 0), true);
         edtIesa_EquCod_Enabled = 0;
         AssignProp("", false, edtIesa_EquCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_EquCod_Enabled), 5, 0), true);
         edtIesa_SabPedCant_Enabled = 0;
         AssignProp("", false, edtIesa_SabPedCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabPedCant_Enabled), 5, 0), true);
         edtIesa_SabOcom_Enabled = 0;
         AssignProp("", false, edtIesa_SabOcom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabOcom_Enabled), 5, 0), true);
         edtIesa_SabIng_Enabled = 0;
         AssignProp("", false, edtIesa_SabIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabIng_Enabled), 5, 0), true);
         edtIesa_SabOComFec_Enabled = 0;
         AssignProp("", false, edtIesa_SabOComFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabOComFec_Enabled), 5, 0), true);
         edtIesa_SabPrvCod_Enabled = 0;
         AssignProp("", false, edtIesa_SabPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabPrvCod_Enabled), 5, 0), true);
         edtIesa_SabPrvDsc_Enabled = 0;
         AssignProp("", false, edtIesa_SabPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabPrvDsc_Enabled), 5, 0), true);
         edtIesa_SabOComCos_Enabled = 0;
         AssignProp("", false, edtIesa_SabOComCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabOComCos_Enabled), 5, 0), true);
         edtIesa_SabIngreso_Enabled = 0;
         AssignProp("", false, edtIesa_SabIngreso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabIngreso_Enabled), 5, 0), true);
         edtIesa_SabIngFec_Enabled = 0;
         AssignProp("", false, edtIesa_SabIngFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabIngFec_Enabled), 5, 0), true);
         edtIesa_SabSts_Enabled = 0;
         AssignProp("", false, edtIesa_SabSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabSts_Enabled), 5, 0), true);
         edtIesa_SabBoton_Enabled = 0;
         AssignProp("", false, edtIesa_SabBoton_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabBoton_Enabled), 5, 0), true);
         edtIesa_SabTipSal_Enabled = 0;
         AssignProp("", false, edtIesa_SabTipSal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabTipSal_Enabled), 5, 0), true);
         edtIesa_SabSalida_Enabled = 0;
         AssignProp("", false, edtIesa_SabSalida_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabSalida_Enabled), 5, 0), true);
         edtIesa_SabSalFec_Enabled = 0;
         AssignProp("", false, edtIesa_SabSalFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabSalFec_Enabled), 5, 0), true);
         edtIesa_SabCantAten_Enabled = 0;
         AssignProp("", false, edtIesa_SabCantAten_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabCantAten_Enabled), 5, 0), true);
         edtIesa_SabOT_Enabled = 0;
         AssignProp("", false, edtIesa_SabOT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIesa_SabOT_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes41140( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues410( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810252965", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("obr_sabana.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z310Iesa_SabPedCod", StringUtil.RTrim( Z310Iesa_SabPedCod));
         GxWebStd.gx_hidden_field( context, "Z311Iesa_SabProdSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z311Iesa_SabProdSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z312Iesa_SabProdCod", StringUtil.RTrim( Z312Iesa_SabProdCod));
         GxWebStd.gx_hidden_field( context, "Z1007Iesa_SabPedFec", context.localUtil.DToC( Z1007Iesa_SabPedFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z994Iesa_ObrCod", StringUtil.RTrim( Z994Iesa_ObrCod));
         GxWebStd.gx_hidden_field( context, "Z991Iesa_AreCod", StringUtil.RTrim( Z991Iesa_AreCod));
         GxWebStd.gx_hidden_field( context, "Z992Iesa_CCosCod", StringUtil.RTrim( Z992Iesa_CCosCod));
         GxWebStd.gx_hidden_field( context, "Z993Iesa_EquCod", StringUtil.RTrim( Z993Iesa_EquCod));
         GxWebStd.gx_hidden_field( context, "Z1006Iesa_SabPedCant", StringUtil.LTrim( StringUtil.NToC( Z1006Iesa_SabPedCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1002Iesa_SabOcom", StringUtil.RTrim( Z1002Iesa_SabOcom));
         GxWebStd.gx_hidden_field( context, "Z997Iesa_SabIng", StringUtil.LTrim( StringUtil.NToC( Z997Iesa_SabIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1004Iesa_SabOComFec", context.localUtil.DToC( Z1004Iesa_SabOComFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1009Iesa_SabPrvCod", StringUtil.RTrim( Z1009Iesa_SabPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1010Iesa_SabPrvDsc", Z1010Iesa_SabPrvDsc);
         GxWebStd.gx_hidden_field( context, "Z1003Iesa_SabOComCos", StringUtil.LTrim( StringUtil.NToC( Z1003Iesa_SabOComCos, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z999Iesa_SabIngreso", StringUtil.RTrim( Z999Iesa_SabIngreso));
         GxWebStd.gx_hidden_field( context, "Z998Iesa_SabIngFec", context.localUtil.DToC( Z998Iesa_SabIngFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1013Iesa_SabSts", StringUtil.RTrim( Z1013Iesa_SabSts));
         GxWebStd.gx_hidden_field( context, "Z995Iesa_SabBoton", StringUtil.RTrim( Z995Iesa_SabBoton));
         GxWebStd.gx_hidden_field( context, "Z1015Iesa_SabTipSal", StringUtil.RTrim( Z1015Iesa_SabTipSal));
         GxWebStd.gx_hidden_field( context, "Z1012Iesa_SabSalida", StringUtil.RTrim( Z1012Iesa_SabSalida));
         GxWebStd.gx_hidden_field( context, "Z1011Iesa_SabSalFec", context.localUtil.DToC( Z1011Iesa_SabSalFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z996Iesa_SabCantAten", StringUtil.LTrim( StringUtil.NToC( Z996Iesa_SabCantAten, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1005Iesa_SabOT", Z1005Iesa_SabOT);
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
         return formatLink("obr_sabana.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "OBR_SABANA" ;
      }

      public override string GetPgmdesc( )
      {
         return "OBR_ SABANA" ;
      }

      protected void InitializeNonKey41140( )
      {
         A1008Iesa_SabProdDsc = "";
         AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
         A1000Iesa_SabLinCod = 0;
         AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
         A1014Iesa_SabSubLCod = 0;
         n1014Iesa_SabSubLCod = false;
         AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
         A1001Iesa_SabLinStk = 0;
         AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
         A1007Iesa_SabPedFec = DateTime.MinValue;
         AssignAttri("", false, "A1007Iesa_SabPedFec", context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"));
         A994Iesa_ObrCod = "";
         AssignAttri("", false, "A994Iesa_ObrCod", A994Iesa_ObrCod);
         A991Iesa_AreCod = "";
         AssignAttri("", false, "A991Iesa_AreCod", A991Iesa_AreCod);
         A992Iesa_CCosCod = "";
         AssignAttri("", false, "A992Iesa_CCosCod", A992Iesa_CCosCod);
         A993Iesa_EquCod = "";
         AssignAttri("", false, "A993Iesa_EquCod", A993Iesa_EquCod);
         A1006Iesa_SabPedCant = 0;
         AssignAttri("", false, "A1006Iesa_SabPedCant", StringUtil.LTrimStr( A1006Iesa_SabPedCant, 15, 4));
         A1002Iesa_SabOcom = "";
         AssignAttri("", false, "A1002Iesa_SabOcom", A1002Iesa_SabOcom);
         A997Iesa_SabIng = 0;
         AssignAttri("", false, "A997Iesa_SabIng", StringUtil.LTrimStr( A997Iesa_SabIng, 15, 4));
         A1004Iesa_SabOComFec = DateTime.MinValue;
         AssignAttri("", false, "A1004Iesa_SabOComFec", context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"));
         A1009Iesa_SabPrvCod = "";
         AssignAttri("", false, "A1009Iesa_SabPrvCod", A1009Iesa_SabPrvCod);
         A1010Iesa_SabPrvDsc = "";
         AssignAttri("", false, "A1010Iesa_SabPrvDsc", A1010Iesa_SabPrvDsc);
         A1003Iesa_SabOComCos = 0;
         AssignAttri("", false, "A1003Iesa_SabOComCos", StringUtil.LTrimStr( A1003Iesa_SabOComCos, 15, 4));
         A999Iesa_SabIngreso = "";
         AssignAttri("", false, "A999Iesa_SabIngreso", A999Iesa_SabIngreso);
         A998Iesa_SabIngFec = DateTime.MinValue;
         AssignAttri("", false, "A998Iesa_SabIngFec", context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"));
         A1013Iesa_SabSts = "";
         AssignAttri("", false, "A1013Iesa_SabSts", A1013Iesa_SabSts);
         A995Iesa_SabBoton = "";
         AssignAttri("", false, "A995Iesa_SabBoton", A995Iesa_SabBoton);
         A1015Iesa_SabTipSal = "";
         AssignAttri("", false, "A1015Iesa_SabTipSal", A1015Iesa_SabTipSal);
         A1012Iesa_SabSalida = "";
         AssignAttri("", false, "A1012Iesa_SabSalida", A1012Iesa_SabSalida);
         A1011Iesa_SabSalFec = DateTime.MinValue;
         AssignAttri("", false, "A1011Iesa_SabSalFec", context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"));
         A996Iesa_SabCantAten = 0;
         AssignAttri("", false, "A996Iesa_SabCantAten", StringUtil.LTrimStr( A996Iesa_SabCantAten, 15, 4));
         A1005Iesa_SabOT = "";
         AssignAttri("", false, "A1005Iesa_SabOT", A1005Iesa_SabOT);
         Z1007Iesa_SabPedFec = DateTime.MinValue;
         Z994Iesa_ObrCod = "";
         Z991Iesa_AreCod = "";
         Z992Iesa_CCosCod = "";
         Z993Iesa_EquCod = "";
         Z1006Iesa_SabPedCant = 0;
         Z1002Iesa_SabOcom = "";
         Z997Iesa_SabIng = 0;
         Z1004Iesa_SabOComFec = DateTime.MinValue;
         Z1009Iesa_SabPrvCod = "";
         Z1010Iesa_SabPrvDsc = "";
         Z1003Iesa_SabOComCos = 0;
         Z999Iesa_SabIngreso = "";
         Z998Iesa_SabIngFec = DateTime.MinValue;
         Z1013Iesa_SabSts = "";
         Z995Iesa_SabBoton = "";
         Z1015Iesa_SabTipSal = "";
         Z1012Iesa_SabSalida = "";
         Z1011Iesa_SabSalFec = DateTime.MinValue;
         Z996Iesa_SabCantAten = 0;
         Z1005Iesa_SabOT = "";
      }

      protected void InitAll41140( )
      {
         A310Iesa_SabPedCod = "";
         AssignAttri("", false, "A310Iesa_SabPedCod", A310Iesa_SabPedCod);
         A311Iesa_SabProdSec = 0;
         AssignAttri("", false, "A311Iesa_SabProdSec", StringUtil.LTrimStr( (decimal)(A311Iesa_SabProdSec), 6, 0));
         A312Iesa_SabProdCod = "";
         AssignAttri("", false, "A312Iesa_SabProdCod", A312Iesa_SabProdCod);
         InitializeNonKey41140( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252985", true, true);
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
         context.AddJavascriptSource("obr_sabana.js", "?202281810252986", false, true);
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
         edtIesa_SabPedCod_Internalname = "IESA_SABPEDCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtIesa_SabProdSec_Internalname = "IESA_SABPRODSEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtIesa_SabProdCod_Internalname = "IESA_SABPRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtIesa_SabProdDsc_Internalname = "IESA_SABPRODDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtIesa_SabLinCod_Internalname = "IESA_SABLINCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtIesa_SabSubLCod_Internalname = "IESA_SABSUBLCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtIesa_SabLinStk_Internalname = "IESA_SABLINSTK";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtIesa_SabPedFec_Internalname = "IESA_SABPEDFEC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtIesa_ObrCod_Internalname = "IESA_OBRCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtIesa_AreCod_Internalname = "IESA_ARECOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtIesa_CCosCod_Internalname = "IESA_CCOSCOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtIesa_EquCod_Internalname = "IESA_EQUCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtIesa_SabPedCant_Internalname = "IESA_SABPEDCANT";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtIesa_SabOcom_Internalname = "IESA_SABOCOM";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtIesa_SabIng_Internalname = "IESA_SABING";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtIesa_SabOComFec_Internalname = "IESA_SABOCOMFEC";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtIesa_SabPrvCod_Internalname = "IESA_SABPRVCOD";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtIesa_SabPrvDsc_Internalname = "IESA_SABPRVDSC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtIesa_SabOComCos_Internalname = "IESA_SABOCOMCOS";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtIesa_SabIngreso_Internalname = "IESA_SABINGRESO";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtIesa_SabIngFec_Internalname = "IESA_SABINGFEC";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtIesa_SabSts_Internalname = "IESA_SABSTS";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtIesa_SabBoton_Internalname = "IESA_SABBOTON";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtIesa_SabTipSal_Internalname = "IESA_SABTIPSAL";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtIesa_SabSalida_Internalname = "IESA_SABSALIDA";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtIesa_SabSalFec_Internalname = "IESA_SABSALFEC";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtIesa_SabCantAten_Internalname = "IESA_SABCANTATEN";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtIesa_SabOT_Internalname = "IESA_SABOT";
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
         Form.Caption = "OBR_ SABANA";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtIesa_SabOT_Jsonclick = "";
         edtIesa_SabOT_Enabled = 1;
         edtIesa_SabCantAten_Jsonclick = "";
         edtIesa_SabCantAten_Enabled = 1;
         edtIesa_SabSalFec_Jsonclick = "";
         edtIesa_SabSalFec_Enabled = 1;
         edtIesa_SabSalida_Jsonclick = "";
         edtIesa_SabSalida_Enabled = 1;
         edtIesa_SabTipSal_Jsonclick = "";
         edtIesa_SabTipSal_Enabled = 1;
         edtIesa_SabBoton_Jsonclick = "";
         edtIesa_SabBoton_Enabled = 1;
         edtIesa_SabSts_Jsonclick = "";
         edtIesa_SabSts_Enabled = 1;
         edtIesa_SabIngFec_Jsonclick = "";
         edtIesa_SabIngFec_Enabled = 1;
         edtIesa_SabIngreso_Jsonclick = "";
         edtIesa_SabIngreso_Enabled = 1;
         edtIesa_SabOComCos_Jsonclick = "";
         edtIesa_SabOComCos_Enabled = 1;
         edtIesa_SabPrvDsc_Jsonclick = "";
         edtIesa_SabPrvDsc_Enabled = 1;
         edtIesa_SabPrvCod_Jsonclick = "";
         edtIesa_SabPrvCod_Enabled = 1;
         edtIesa_SabOComFec_Jsonclick = "";
         edtIesa_SabOComFec_Enabled = 1;
         edtIesa_SabIng_Jsonclick = "";
         edtIesa_SabIng_Enabled = 1;
         edtIesa_SabOcom_Jsonclick = "";
         edtIesa_SabOcom_Enabled = 1;
         edtIesa_SabPedCant_Jsonclick = "";
         edtIesa_SabPedCant_Enabled = 1;
         edtIesa_EquCod_Jsonclick = "";
         edtIesa_EquCod_Enabled = 1;
         edtIesa_CCosCod_Jsonclick = "";
         edtIesa_CCosCod_Enabled = 1;
         edtIesa_AreCod_Jsonclick = "";
         edtIesa_AreCod_Enabled = 1;
         edtIesa_ObrCod_Jsonclick = "";
         edtIesa_ObrCod_Enabled = 1;
         edtIesa_SabPedFec_Jsonclick = "";
         edtIesa_SabPedFec_Enabled = 1;
         edtIesa_SabLinStk_Jsonclick = "";
         edtIesa_SabLinStk_Enabled = 0;
         edtIesa_SabSubLCod_Jsonclick = "";
         edtIesa_SabSubLCod_Enabled = 0;
         edtIesa_SabLinCod_Jsonclick = "";
         edtIesa_SabLinCod_Enabled = 0;
         edtIesa_SabProdDsc_Jsonclick = "";
         edtIesa_SabProdDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtIesa_SabProdCod_Jsonclick = "";
         edtIesa_SabProdCod_Enabled = 1;
         edtIesa_SabProdSec_Jsonclick = "";
         edtIesa_SabProdSec_Enabled = 1;
         edtIesa_SabPedCod_Jsonclick = "";
         edtIesa_SabPedCod_Enabled = 1;
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
         /* Using cursor T004115 */
         pr_default.execute(13, new Object[] {A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1008Iesa_SabProdDsc = T004115_A1008Iesa_SabProdDsc[0];
         AssignAttri("", false, "A1008Iesa_SabProdDsc", A1008Iesa_SabProdDsc);
         A1000Iesa_SabLinCod = T004115_A1000Iesa_SabLinCod[0];
         AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrimStr( (decimal)(A1000Iesa_SabLinCod), 6, 0));
         A1014Iesa_SabSubLCod = T004115_A1014Iesa_SabSubLCod[0];
         n1014Iesa_SabSubLCod = T004115_n1014Iesa_SabSubLCod[0];
         AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrimStr( (decimal)(A1014Iesa_SabSubLCod), 6, 0));
         pr_default.close(13);
         /* Using cursor T004116 */
         pr_default.execute(14, new Object[] {A1000Iesa_SabLinCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABLINCOD");
            AnyError = 1;
         }
         A1001Iesa_SabLinStk = T004116_A1001Iesa_SabLinStk[0];
         AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.Str( (decimal)(A1001Iesa_SabLinStk), 1, 0));
         pr_default.close(14);
         GX_FocusControl = edtIesa_SabPedFec_Internalname;
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

      public void Valid_Iesa_sabprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T004115 */
         pr_default.execute(13, new Object[] {A312Iesa_SabProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtIesa_SabProdCod_Internalname;
         }
         A1008Iesa_SabProdDsc = T004115_A1008Iesa_SabProdDsc[0];
         A1000Iesa_SabLinCod = T004115_A1000Iesa_SabLinCod[0];
         A1014Iesa_SabSubLCod = T004115_A1014Iesa_SabSubLCod[0];
         n1014Iesa_SabSubLCod = T004115_n1014Iesa_SabSubLCod[0];
         pr_default.close(13);
         /* Using cursor T004116 */
         pr_default.execute(14, new Object[] {A1000Iesa_SabLinCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "IESA_SABLINCOD");
            AnyError = 1;
         }
         A1001Iesa_SabLinStk = T004116_A1001Iesa_SabLinStk[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1007Iesa_SabPedFec", context.localUtil.Format(A1007Iesa_SabPedFec, "99/99/99"));
         AssignAttri("", false, "A994Iesa_ObrCod", StringUtil.RTrim( A994Iesa_ObrCod));
         AssignAttri("", false, "A991Iesa_AreCod", StringUtil.RTrim( A991Iesa_AreCod));
         AssignAttri("", false, "A992Iesa_CCosCod", StringUtil.RTrim( A992Iesa_CCosCod));
         AssignAttri("", false, "A993Iesa_EquCod", StringUtil.RTrim( A993Iesa_EquCod));
         AssignAttri("", false, "A1006Iesa_SabPedCant", StringUtil.LTrim( StringUtil.NToC( A1006Iesa_SabPedCant, 15, 4, ".", "")));
         AssignAttri("", false, "A1002Iesa_SabOcom", StringUtil.RTrim( A1002Iesa_SabOcom));
         AssignAttri("", false, "A997Iesa_SabIng", StringUtil.LTrim( StringUtil.NToC( A997Iesa_SabIng, 15, 4, ".", "")));
         AssignAttri("", false, "A1004Iesa_SabOComFec", context.localUtil.Format(A1004Iesa_SabOComFec, "99/99/99"));
         AssignAttri("", false, "A1009Iesa_SabPrvCod", StringUtil.RTrim( A1009Iesa_SabPrvCod));
         AssignAttri("", false, "A1010Iesa_SabPrvDsc", A1010Iesa_SabPrvDsc);
         AssignAttri("", false, "A1003Iesa_SabOComCos", StringUtil.LTrim( StringUtil.NToC( A1003Iesa_SabOComCos, 15, 4, ".", "")));
         AssignAttri("", false, "A999Iesa_SabIngreso", StringUtil.RTrim( A999Iesa_SabIngreso));
         AssignAttri("", false, "A998Iesa_SabIngFec", context.localUtil.Format(A998Iesa_SabIngFec, "99/99/99"));
         AssignAttri("", false, "A1013Iesa_SabSts", StringUtil.RTrim( A1013Iesa_SabSts));
         AssignAttri("", false, "A995Iesa_SabBoton", StringUtil.RTrim( A995Iesa_SabBoton));
         AssignAttri("", false, "A1015Iesa_SabTipSal", StringUtil.RTrim( A1015Iesa_SabTipSal));
         AssignAttri("", false, "A1012Iesa_SabSalida", StringUtil.RTrim( A1012Iesa_SabSalida));
         AssignAttri("", false, "A1011Iesa_SabSalFec", context.localUtil.Format(A1011Iesa_SabSalFec, "99/99/99"));
         AssignAttri("", false, "A996Iesa_SabCantAten", StringUtil.LTrim( StringUtil.NToC( A996Iesa_SabCantAten, 15, 4, ".", "")));
         AssignAttri("", false, "A1005Iesa_SabOT", A1005Iesa_SabOT);
         AssignAttri("", false, "A1008Iesa_SabProdDsc", StringUtil.RTrim( A1008Iesa_SabProdDsc));
         AssignAttri("", false, "A1000Iesa_SabLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1000Iesa_SabLinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1014Iesa_SabSubLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1014Iesa_SabSubLCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1001Iesa_SabLinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1001Iesa_SabLinStk), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z310Iesa_SabPedCod", StringUtil.RTrim( Z310Iesa_SabPedCod));
         GxWebStd.gx_hidden_field( context, "Z311Iesa_SabProdSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z311Iesa_SabProdSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z312Iesa_SabProdCod", StringUtil.RTrim( Z312Iesa_SabProdCod));
         GxWebStd.gx_hidden_field( context, "Z1007Iesa_SabPedFec", context.localUtil.Format(Z1007Iesa_SabPedFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z994Iesa_ObrCod", StringUtil.RTrim( Z994Iesa_ObrCod));
         GxWebStd.gx_hidden_field( context, "Z991Iesa_AreCod", StringUtil.RTrim( Z991Iesa_AreCod));
         GxWebStd.gx_hidden_field( context, "Z992Iesa_CCosCod", StringUtil.RTrim( Z992Iesa_CCosCod));
         GxWebStd.gx_hidden_field( context, "Z993Iesa_EquCod", StringUtil.RTrim( Z993Iesa_EquCod));
         GxWebStd.gx_hidden_field( context, "Z1006Iesa_SabPedCant", StringUtil.LTrim( StringUtil.NToC( Z1006Iesa_SabPedCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1002Iesa_SabOcom", StringUtil.RTrim( Z1002Iesa_SabOcom));
         GxWebStd.gx_hidden_field( context, "Z997Iesa_SabIng", StringUtil.LTrim( StringUtil.NToC( Z997Iesa_SabIng, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1004Iesa_SabOComFec", context.localUtil.Format(Z1004Iesa_SabOComFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1009Iesa_SabPrvCod", StringUtil.RTrim( Z1009Iesa_SabPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1010Iesa_SabPrvDsc", Z1010Iesa_SabPrvDsc);
         GxWebStd.gx_hidden_field( context, "Z1003Iesa_SabOComCos", StringUtil.LTrim( StringUtil.NToC( Z1003Iesa_SabOComCos, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z999Iesa_SabIngreso", StringUtil.RTrim( Z999Iesa_SabIngreso));
         GxWebStd.gx_hidden_field( context, "Z998Iesa_SabIngFec", context.localUtil.Format(Z998Iesa_SabIngFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1013Iesa_SabSts", StringUtil.RTrim( Z1013Iesa_SabSts));
         GxWebStd.gx_hidden_field( context, "Z995Iesa_SabBoton", StringUtil.RTrim( Z995Iesa_SabBoton));
         GxWebStd.gx_hidden_field( context, "Z1015Iesa_SabTipSal", StringUtil.RTrim( Z1015Iesa_SabTipSal));
         GxWebStd.gx_hidden_field( context, "Z1012Iesa_SabSalida", StringUtil.RTrim( Z1012Iesa_SabSalida));
         GxWebStd.gx_hidden_field( context, "Z1011Iesa_SabSalFec", context.localUtil.Format(Z1011Iesa_SabSalFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z996Iesa_SabCantAten", StringUtil.LTrim( StringUtil.NToC( Z996Iesa_SabCantAten, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1005Iesa_SabOT", Z1005Iesa_SabOT);
         GxWebStd.gx_hidden_field( context, "Z1008Iesa_SabProdDsc", StringUtil.RTrim( Z1008Iesa_SabProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1000Iesa_SabLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1000Iesa_SabLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1014Iesa_SabSubLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1014Iesa_SabSubLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1001Iesa_SabLinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1001Iesa_SabLinStk), 1, 0, ".", "")));
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
         setEventMetadata("VALID_IESA_SABPEDCOD","{handler:'Valid_Iesa_sabpedcod',iparms:[]");
         setEventMetadata("VALID_IESA_SABPEDCOD",",oparms:[]}");
         setEventMetadata("VALID_IESA_SABPRODSEC","{handler:'Valid_Iesa_sabprodsec',iparms:[]");
         setEventMetadata("VALID_IESA_SABPRODSEC",",oparms:[]}");
         setEventMetadata("VALID_IESA_SABPRODCOD","{handler:'Valid_Iesa_sabprodcod',iparms:[{av:'A310Iesa_SabPedCod',fld:'IESA_SABPEDCOD',pic:''},{av:'A311Iesa_SabProdSec',fld:'IESA_SABPRODSEC',pic:'ZZZZZ9'},{av:'A312Iesa_SabProdCod',fld:'IESA_SABPRODCOD',pic:'@!'},{av:'A1000Iesa_SabLinCod',fld:'IESA_SABLINCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_IESA_SABPRODCOD",",oparms:[{av:'A1007Iesa_SabPedFec',fld:'IESA_SABPEDFEC',pic:''},{av:'A994Iesa_ObrCod',fld:'IESA_OBRCOD',pic:''},{av:'A991Iesa_AreCod',fld:'IESA_ARECOD',pic:''},{av:'A992Iesa_CCosCod',fld:'IESA_CCOSCOD',pic:''},{av:'A993Iesa_EquCod',fld:'IESA_EQUCOD',pic:''},{av:'A1006Iesa_SabPedCant',fld:'IESA_SABPEDCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1002Iesa_SabOcom',fld:'IESA_SABOCOM',pic:''},{av:'A997Iesa_SabIng',fld:'IESA_SABING',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1004Iesa_SabOComFec',fld:'IESA_SABOCOMFEC',pic:''},{av:'A1009Iesa_SabPrvCod',fld:'IESA_SABPRVCOD',pic:''},{av:'A1010Iesa_SabPrvDsc',fld:'IESA_SABPRVDSC',pic:''},{av:'A1003Iesa_SabOComCos',fld:'IESA_SABOCOMCOS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A999Iesa_SabIngreso',fld:'IESA_SABINGRESO',pic:''},{av:'A998Iesa_SabIngFec',fld:'IESA_SABINGFEC',pic:''},{av:'A1013Iesa_SabSts',fld:'IESA_SABSTS',pic:''},{av:'A995Iesa_SabBoton',fld:'IESA_SABBOTON',pic:''},{av:'A1015Iesa_SabTipSal',fld:'IESA_SABTIPSAL',pic:''},{av:'A1012Iesa_SabSalida',fld:'IESA_SABSALIDA',pic:''},{av:'A1011Iesa_SabSalFec',fld:'IESA_SABSALFEC',pic:''},{av:'A996Iesa_SabCantAten',fld:'IESA_SABCANTATEN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1005Iesa_SabOT',fld:'IESA_SABOT',pic:''},{av:'A1008Iesa_SabProdDsc',fld:'IESA_SABPRODDSC',pic:''},{av:'A1000Iesa_SabLinCod',fld:'IESA_SABLINCOD',pic:'ZZZZZ9'},{av:'A1014Iesa_SabSubLCod',fld:'IESA_SABSUBLCOD',pic:'ZZZZZ9'},{av:'A1001Iesa_SabLinStk',fld:'IESA_SABLINSTK',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z310Iesa_SabPedCod'},{av:'Z311Iesa_SabProdSec'},{av:'Z312Iesa_SabProdCod'},{av:'Z1007Iesa_SabPedFec'},{av:'Z994Iesa_ObrCod'},{av:'Z991Iesa_AreCod'},{av:'Z992Iesa_CCosCod'},{av:'Z993Iesa_EquCod'},{av:'Z1006Iesa_SabPedCant'},{av:'Z1002Iesa_SabOcom'},{av:'Z997Iesa_SabIng'},{av:'Z1004Iesa_SabOComFec'},{av:'Z1009Iesa_SabPrvCod'},{av:'Z1010Iesa_SabPrvDsc'},{av:'Z1003Iesa_SabOComCos'},{av:'Z999Iesa_SabIngreso'},{av:'Z998Iesa_SabIngFec'},{av:'Z1013Iesa_SabSts'},{av:'Z995Iesa_SabBoton'},{av:'Z1015Iesa_SabTipSal'},{av:'Z1012Iesa_SabSalida'},{av:'Z1011Iesa_SabSalFec'},{av:'Z996Iesa_SabCantAten'},{av:'Z1005Iesa_SabOT'},{av:'Z1008Iesa_SabProdDsc'},{av:'Z1000Iesa_SabLinCod'},{av:'Z1014Iesa_SabSubLCod'},{av:'Z1001Iesa_SabLinStk'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_IESA_SABLINCOD","{handler:'Valid_Iesa_sablincod',iparms:[]");
         setEventMetadata("VALID_IESA_SABLINCOD",",oparms:[]}");
         setEventMetadata("VALID_IESA_SABPEDFEC","{handler:'Valid_Iesa_sabpedfec',iparms:[]");
         setEventMetadata("VALID_IESA_SABPEDFEC",",oparms:[]}");
         setEventMetadata("VALID_IESA_SABOCOMFEC","{handler:'Valid_Iesa_sabocomfec',iparms:[]");
         setEventMetadata("VALID_IESA_SABOCOMFEC",",oparms:[]}");
         setEventMetadata("VALID_IESA_SABINGFEC","{handler:'Valid_Iesa_sabingfec',iparms:[]");
         setEventMetadata("VALID_IESA_SABINGFEC",",oparms:[]}");
         setEventMetadata("VALID_IESA_SABSALFEC","{handler:'Valid_Iesa_sabsalfec',iparms:[]");
         setEventMetadata("VALID_IESA_SABSALFEC",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z310Iesa_SabPedCod = "";
         Z312Iesa_SabProdCod = "";
         Z1007Iesa_SabPedFec = DateTime.MinValue;
         Z994Iesa_ObrCod = "";
         Z991Iesa_AreCod = "";
         Z992Iesa_CCosCod = "";
         Z993Iesa_EquCod = "";
         Z1002Iesa_SabOcom = "";
         Z1004Iesa_SabOComFec = DateTime.MinValue;
         Z1009Iesa_SabPrvCod = "";
         Z1010Iesa_SabPrvDsc = "";
         Z999Iesa_SabIngreso = "";
         Z998Iesa_SabIngFec = DateTime.MinValue;
         Z1013Iesa_SabSts = "";
         Z995Iesa_SabBoton = "";
         Z1015Iesa_SabTipSal = "";
         Z1012Iesa_SabSalida = "";
         Z1011Iesa_SabSalFec = DateTime.MinValue;
         Z1005Iesa_SabOT = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A312Iesa_SabProdCod = "";
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
         A310Iesa_SabPedCod = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1008Iesa_SabProdDsc = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A1007Iesa_SabPedFec = DateTime.MinValue;
         lblTextblock9_Jsonclick = "";
         A994Iesa_ObrCod = "";
         lblTextblock10_Jsonclick = "";
         A991Iesa_AreCod = "";
         lblTextblock11_Jsonclick = "";
         A992Iesa_CCosCod = "";
         lblTextblock12_Jsonclick = "";
         A993Iesa_EquCod = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A1002Iesa_SabOcom = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         A1004Iesa_SabOComFec = DateTime.MinValue;
         lblTextblock17_Jsonclick = "";
         A1009Iesa_SabPrvCod = "";
         lblTextblock18_Jsonclick = "";
         A1010Iesa_SabPrvDsc = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         A999Iesa_SabIngreso = "";
         lblTextblock21_Jsonclick = "";
         A998Iesa_SabIngFec = DateTime.MinValue;
         lblTextblock22_Jsonclick = "";
         A1013Iesa_SabSts = "";
         lblTextblock23_Jsonclick = "";
         A995Iesa_SabBoton = "";
         lblTextblock24_Jsonclick = "";
         A1015Iesa_SabTipSal = "";
         lblTextblock25_Jsonclick = "";
         A1012Iesa_SabSalida = "";
         lblTextblock26_Jsonclick = "";
         A1011Iesa_SabSalFec = DateTime.MinValue;
         lblTextblock27_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         A1005Iesa_SabOT = "";
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
         Z1008Iesa_SabProdDsc = "";
         T00416_A310Iesa_SabPedCod = new string[] {""} ;
         T00416_A311Iesa_SabProdSec = new int[1] ;
         T00416_A1008Iesa_SabProdDsc = new string[] {""} ;
         T00416_A1001Iesa_SabLinStk = new short[1] ;
         T00416_A1007Iesa_SabPedFec = new DateTime[] {DateTime.MinValue} ;
         T00416_A994Iesa_ObrCod = new string[] {""} ;
         T00416_A991Iesa_AreCod = new string[] {""} ;
         T00416_A992Iesa_CCosCod = new string[] {""} ;
         T00416_A993Iesa_EquCod = new string[] {""} ;
         T00416_A1006Iesa_SabPedCant = new decimal[1] ;
         T00416_A1002Iesa_SabOcom = new string[] {""} ;
         T00416_A997Iesa_SabIng = new decimal[1] ;
         T00416_A1004Iesa_SabOComFec = new DateTime[] {DateTime.MinValue} ;
         T00416_A1009Iesa_SabPrvCod = new string[] {""} ;
         T00416_A1010Iesa_SabPrvDsc = new string[] {""} ;
         T00416_A1003Iesa_SabOComCos = new decimal[1] ;
         T00416_A999Iesa_SabIngreso = new string[] {""} ;
         T00416_A998Iesa_SabIngFec = new DateTime[] {DateTime.MinValue} ;
         T00416_A1013Iesa_SabSts = new string[] {""} ;
         T00416_A995Iesa_SabBoton = new string[] {""} ;
         T00416_A1015Iesa_SabTipSal = new string[] {""} ;
         T00416_A1012Iesa_SabSalida = new string[] {""} ;
         T00416_A1011Iesa_SabSalFec = new DateTime[] {DateTime.MinValue} ;
         T00416_A996Iesa_SabCantAten = new decimal[1] ;
         T00416_A1005Iesa_SabOT = new string[] {""} ;
         T00416_A312Iesa_SabProdCod = new string[] {""} ;
         T00416_A1000Iesa_SabLinCod = new int[1] ;
         T00416_A1014Iesa_SabSubLCod = new int[1] ;
         T00416_n1014Iesa_SabSubLCod = new bool[] {false} ;
         T00414_A1008Iesa_SabProdDsc = new string[] {""} ;
         T00414_A1000Iesa_SabLinCod = new int[1] ;
         T00414_A1014Iesa_SabSubLCod = new int[1] ;
         T00414_n1014Iesa_SabSubLCod = new bool[] {false} ;
         T00415_A1001Iesa_SabLinStk = new short[1] ;
         T00417_A1008Iesa_SabProdDsc = new string[] {""} ;
         T00417_A1000Iesa_SabLinCod = new int[1] ;
         T00417_A1014Iesa_SabSubLCod = new int[1] ;
         T00417_n1014Iesa_SabSubLCod = new bool[] {false} ;
         T00418_A1001Iesa_SabLinStk = new short[1] ;
         T00419_A310Iesa_SabPedCod = new string[] {""} ;
         T00419_A311Iesa_SabProdSec = new int[1] ;
         T00419_A312Iesa_SabProdCod = new string[] {""} ;
         T00413_A310Iesa_SabPedCod = new string[] {""} ;
         T00413_A311Iesa_SabProdSec = new int[1] ;
         T00413_A1007Iesa_SabPedFec = new DateTime[] {DateTime.MinValue} ;
         T00413_A994Iesa_ObrCod = new string[] {""} ;
         T00413_A991Iesa_AreCod = new string[] {""} ;
         T00413_A992Iesa_CCosCod = new string[] {""} ;
         T00413_A993Iesa_EquCod = new string[] {""} ;
         T00413_A1006Iesa_SabPedCant = new decimal[1] ;
         T00413_A1002Iesa_SabOcom = new string[] {""} ;
         T00413_A997Iesa_SabIng = new decimal[1] ;
         T00413_A1004Iesa_SabOComFec = new DateTime[] {DateTime.MinValue} ;
         T00413_A1009Iesa_SabPrvCod = new string[] {""} ;
         T00413_A1010Iesa_SabPrvDsc = new string[] {""} ;
         T00413_A1003Iesa_SabOComCos = new decimal[1] ;
         T00413_A999Iesa_SabIngreso = new string[] {""} ;
         T00413_A998Iesa_SabIngFec = new DateTime[] {DateTime.MinValue} ;
         T00413_A1013Iesa_SabSts = new string[] {""} ;
         T00413_A995Iesa_SabBoton = new string[] {""} ;
         T00413_A1015Iesa_SabTipSal = new string[] {""} ;
         T00413_A1012Iesa_SabSalida = new string[] {""} ;
         T00413_A1011Iesa_SabSalFec = new DateTime[] {DateTime.MinValue} ;
         T00413_A996Iesa_SabCantAten = new decimal[1] ;
         T00413_A1005Iesa_SabOT = new string[] {""} ;
         T00413_A312Iesa_SabProdCod = new string[] {""} ;
         sMode140 = "";
         T004110_A310Iesa_SabPedCod = new string[] {""} ;
         T004110_A311Iesa_SabProdSec = new int[1] ;
         T004110_A312Iesa_SabProdCod = new string[] {""} ;
         T004111_A310Iesa_SabPedCod = new string[] {""} ;
         T004111_A311Iesa_SabProdSec = new int[1] ;
         T004111_A312Iesa_SabProdCod = new string[] {""} ;
         T00412_A310Iesa_SabPedCod = new string[] {""} ;
         T00412_A311Iesa_SabProdSec = new int[1] ;
         T00412_A1007Iesa_SabPedFec = new DateTime[] {DateTime.MinValue} ;
         T00412_A994Iesa_ObrCod = new string[] {""} ;
         T00412_A991Iesa_AreCod = new string[] {""} ;
         T00412_A992Iesa_CCosCod = new string[] {""} ;
         T00412_A993Iesa_EquCod = new string[] {""} ;
         T00412_A1006Iesa_SabPedCant = new decimal[1] ;
         T00412_A1002Iesa_SabOcom = new string[] {""} ;
         T00412_A997Iesa_SabIng = new decimal[1] ;
         T00412_A1004Iesa_SabOComFec = new DateTime[] {DateTime.MinValue} ;
         T00412_A1009Iesa_SabPrvCod = new string[] {""} ;
         T00412_A1010Iesa_SabPrvDsc = new string[] {""} ;
         T00412_A1003Iesa_SabOComCos = new decimal[1] ;
         T00412_A999Iesa_SabIngreso = new string[] {""} ;
         T00412_A998Iesa_SabIngFec = new DateTime[] {DateTime.MinValue} ;
         T00412_A1013Iesa_SabSts = new string[] {""} ;
         T00412_A995Iesa_SabBoton = new string[] {""} ;
         T00412_A1015Iesa_SabTipSal = new string[] {""} ;
         T00412_A1012Iesa_SabSalida = new string[] {""} ;
         T00412_A1011Iesa_SabSalFec = new DateTime[] {DateTime.MinValue} ;
         T00412_A996Iesa_SabCantAten = new decimal[1] ;
         T00412_A1005Iesa_SabOT = new string[] {""} ;
         T00412_A312Iesa_SabProdCod = new string[] {""} ;
         T004115_A1008Iesa_SabProdDsc = new string[] {""} ;
         T004115_A1000Iesa_SabLinCod = new int[1] ;
         T004115_A1014Iesa_SabSubLCod = new int[1] ;
         T004115_n1014Iesa_SabSubLCod = new bool[] {false} ;
         T004116_A1001Iesa_SabLinStk = new short[1] ;
         T004117_A310Iesa_SabPedCod = new string[] {""} ;
         T004117_A311Iesa_SabProdSec = new int[1] ;
         T004117_A312Iesa_SabProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ310Iesa_SabPedCod = "";
         ZZ312Iesa_SabProdCod = "";
         ZZ1007Iesa_SabPedFec = DateTime.MinValue;
         ZZ994Iesa_ObrCod = "";
         ZZ991Iesa_AreCod = "";
         ZZ992Iesa_CCosCod = "";
         ZZ993Iesa_EquCod = "";
         ZZ1002Iesa_SabOcom = "";
         ZZ1004Iesa_SabOComFec = DateTime.MinValue;
         ZZ1009Iesa_SabPrvCod = "";
         ZZ1010Iesa_SabPrvDsc = "";
         ZZ999Iesa_SabIngreso = "";
         ZZ998Iesa_SabIngFec = DateTime.MinValue;
         ZZ1013Iesa_SabSts = "";
         ZZ995Iesa_SabBoton = "";
         ZZ1015Iesa_SabTipSal = "";
         ZZ1012Iesa_SabSalida = "";
         ZZ1011Iesa_SabSalFec = DateTime.MinValue;
         ZZ1005Iesa_SabOT = "";
         ZZ1008Iesa_SabProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.obr_sabana__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obr_sabana__default(),
            new Object[][] {
                new Object[] {
               T00412_A310Iesa_SabPedCod, T00412_A311Iesa_SabProdSec, T00412_A1007Iesa_SabPedFec, T00412_A994Iesa_ObrCod, T00412_A991Iesa_AreCod, T00412_A992Iesa_CCosCod, T00412_A993Iesa_EquCod, T00412_A1006Iesa_SabPedCant, T00412_A1002Iesa_SabOcom, T00412_A997Iesa_SabIng,
               T00412_A1004Iesa_SabOComFec, T00412_A1009Iesa_SabPrvCod, T00412_A1010Iesa_SabPrvDsc, T00412_A1003Iesa_SabOComCos, T00412_A999Iesa_SabIngreso, T00412_A998Iesa_SabIngFec, T00412_A1013Iesa_SabSts, T00412_A995Iesa_SabBoton, T00412_A1015Iesa_SabTipSal, T00412_A1012Iesa_SabSalida,
               T00412_A1011Iesa_SabSalFec, T00412_A996Iesa_SabCantAten, T00412_A1005Iesa_SabOT, T00412_A312Iesa_SabProdCod
               }
               , new Object[] {
               T00413_A310Iesa_SabPedCod, T00413_A311Iesa_SabProdSec, T00413_A1007Iesa_SabPedFec, T00413_A994Iesa_ObrCod, T00413_A991Iesa_AreCod, T00413_A992Iesa_CCosCod, T00413_A993Iesa_EquCod, T00413_A1006Iesa_SabPedCant, T00413_A1002Iesa_SabOcom, T00413_A997Iesa_SabIng,
               T00413_A1004Iesa_SabOComFec, T00413_A1009Iesa_SabPrvCod, T00413_A1010Iesa_SabPrvDsc, T00413_A1003Iesa_SabOComCos, T00413_A999Iesa_SabIngreso, T00413_A998Iesa_SabIngFec, T00413_A1013Iesa_SabSts, T00413_A995Iesa_SabBoton, T00413_A1015Iesa_SabTipSal, T00413_A1012Iesa_SabSalida,
               T00413_A1011Iesa_SabSalFec, T00413_A996Iesa_SabCantAten, T00413_A1005Iesa_SabOT, T00413_A312Iesa_SabProdCod
               }
               , new Object[] {
               T00414_A1008Iesa_SabProdDsc, T00414_A1000Iesa_SabLinCod, T00414_A1014Iesa_SabSubLCod, T00414_n1014Iesa_SabSubLCod
               }
               , new Object[] {
               T00415_A1001Iesa_SabLinStk
               }
               , new Object[] {
               T00416_A310Iesa_SabPedCod, T00416_A311Iesa_SabProdSec, T00416_A1008Iesa_SabProdDsc, T00416_A1001Iesa_SabLinStk, T00416_A1007Iesa_SabPedFec, T00416_A994Iesa_ObrCod, T00416_A991Iesa_AreCod, T00416_A992Iesa_CCosCod, T00416_A993Iesa_EquCod, T00416_A1006Iesa_SabPedCant,
               T00416_A1002Iesa_SabOcom, T00416_A997Iesa_SabIng, T00416_A1004Iesa_SabOComFec, T00416_A1009Iesa_SabPrvCod, T00416_A1010Iesa_SabPrvDsc, T00416_A1003Iesa_SabOComCos, T00416_A999Iesa_SabIngreso, T00416_A998Iesa_SabIngFec, T00416_A1013Iesa_SabSts, T00416_A995Iesa_SabBoton,
               T00416_A1015Iesa_SabTipSal, T00416_A1012Iesa_SabSalida, T00416_A1011Iesa_SabSalFec, T00416_A996Iesa_SabCantAten, T00416_A1005Iesa_SabOT, T00416_A312Iesa_SabProdCod, T00416_A1000Iesa_SabLinCod, T00416_A1014Iesa_SabSubLCod, T00416_n1014Iesa_SabSubLCod
               }
               , new Object[] {
               T00417_A1008Iesa_SabProdDsc, T00417_A1000Iesa_SabLinCod, T00417_A1014Iesa_SabSubLCod, T00417_n1014Iesa_SabSubLCod
               }
               , new Object[] {
               T00418_A1001Iesa_SabLinStk
               }
               , new Object[] {
               T00419_A310Iesa_SabPedCod, T00419_A311Iesa_SabProdSec, T00419_A312Iesa_SabProdCod
               }
               , new Object[] {
               T004110_A310Iesa_SabPedCod, T004110_A311Iesa_SabProdSec, T004110_A312Iesa_SabProdCod
               }
               , new Object[] {
               T004111_A310Iesa_SabPedCod, T004111_A311Iesa_SabProdSec, T004111_A312Iesa_SabProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004115_A1008Iesa_SabProdDsc, T004115_A1000Iesa_SabLinCod, T004115_A1014Iesa_SabSubLCod, T004115_n1014Iesa_SabSubLCod
               }
               , new Object[] {
               T004116_A1001Iesa_SabLinStk
               }
               , new Object[] {
               T004117_A310Iesa_SabPedCod, T004117_A311Iesa_SabProdSec, T004117_A312Iesa_SabProdCod
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
      private short A1001Iesa_SabLinStk ;
      private short GX_JID ;
      private short Z1001Iesa_SabLinStk ;
      private short RcdFound140 ;
      private short nIsDirty_140 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1001Iesa_SabLinStk ;
      private int Z311Iesa_SabProdSec ;
      private int A1000Iesa_SabLinCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIesa_SabPedCod_Enabled ;
      private int A311Iesa_SabProdSec ;
      private int edtIesa_SabProdSec_Enabled ;
      private int edtIesa_SabProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtIesa_SabProdDsc_Enabled ;
      private int edtIesa_SabLinCod_Enabled ;
      private int A1014Iesa_SabSubLCod ;
      private int edtIesa_SabSubLCod_Enabled ;
      private int edtIesa_SabLinStk_Enabled ;
      private int edtIesa_SabPedFec_Enabled ;
      private int edtIesa_ObrCod_Enabled ;
      private int edtIesa_AreCod_Enabled ;
      private int edtIesa_CCosCod_Enabled ;
      private int edtIesa_EquCod_Enabled ;
      private int edtIesa_SabPedCant_Enabled ;
      private int edtIesa_SabOcom_Enabled ;
      private int edtIesa_SabIng_Enabled ;
      private int edtIesa_SabOComFec_Enabled ;
      private int edtIesa_SabPrvCod_Enabled ;
      private int edtIesa_SabPrvDsc_Enabled ;
      private int edtIesa_SabOComCos_Enabled ;
      private int edtIesa_SabIngreso_Enabled ;
      private int edtIesa_SabIngFec_Enabled ;
      private int edtIesa_SabSts_Enabled ;
      private int edtIesa_SabBoton_Enabled ;
      private int edtIesa_SabTipSal_Enabled ;
      private int edtIesa_SabSalida_Enabled ;
      private int edtIesa_SabSalFec_Enabled ;
      private int edtIesa_SabCantAten_Enabled ;
      private int edtIesa_SabOT_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z1000Iesa_SabLinCod ;
      private int Z1014Iesa_SabSubLCod ;
      private int idxLst ;
      private int ZZ311Iesa_SabProdSec ;
      private int ZZ1000Iesa_SabLinCod ;
      private int ZZ1014Iesa_SabSubLCod ;
      private decimal Z1006Iesa_SabPedCant ;
      private decimal Z997Iesa_SabIng ;
      private decimal Z1003Iesa_SabOComCos ;
      private decimal Z996Iesa_SabCantAten ;
      private decimal A1006Iesa_SabPedCant ;
      private decimal A997Iesa_SabIng ;
      private decimal A1003Iesa_SabOComCos ;
      private decimal A996Iesa_SabCantAten ;
      private decimal ZZ1006Iesa_SabPedCant ;
      private decimal ZZ997Iesa_SabIng ;
      private decimal ZZ1003Iesa_SabOComCos ;
      private decimal ZZ996Iesa_SabCantAten ;
      private string sPrefix ;
      private string Z310Iesa_SabPedCod ;
      private string Z312Iesa_SabProdCod ;
      private string Z994Iesa_ObrCod ;
      private string Z991Iesa_AreCod ;
      private string Z992Iesa_CCosCod ;
      private string Z993Iesa_EquCod ;
      private string Z1002Iesa_SabOcom ;
      private string Z1009Iesa_SabPrvCod ;
      private string Z999Iesa_SabIngreso ;
      private string Z1013Iesa_SabSts ;
      private string Z995Iesa_SabBoton ;
      private string Z1015Iesa_SabTipSal ;
      private string Z1012Iesa_SabSalida ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A312Iesa_SabProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtIesa_SabPedCod_Internalname ;
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
      private string A310Iesa_SabPedCod ;
      private string edtIesa_SabPedCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtIesa_SabProdSec_Internalname ;
      private string edtIesa_SabProdSec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtIesa_SabProdCod_Internalname ;
      private string edtIesa_SabProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtIesa_SabProdDsc_Internalname ;
      private string A1008Iesa_SabProdDsc ;
      private string edtIesa_SabProdDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtIesa_SabLinCod_Internalname ;
      private string edtIesa_SabLinCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtIesa_SabSubLCod_Internalname ;
      private string edtIesa_SabSubLCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtIesa_SabLinStk_Internalname ;
      private string edtIesa_SabLinStk_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtIesa_SabPedFec_Internalname ;
      private string edtIesa_SabPedFec_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtIesa_ObrCod_Internalname ;
      private string A994Iesa_ObrCod ;
      private string edtIesa_ObrCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtIesa_AreCod_Internalname ;
      private string A991Iesa_AreCod ;
      private string edtIesa_AreCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtIesa_CCosCod_Internalname ;
      private string A992Iesa_CCosCod ;
      private string edtIesa_CCosCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtIesa_EquCod_Internalname ;
      private string A993Iesa_EquCod ;
      private string edtIesa_EquCod_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtIesa_SabPedCant_Internalname ;
      private string edtIesa_SabPedCant_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtIesa_SabOcom_Internalname ;
      private string A1002Iesa_SabOcom ;
      private string edtIesa_SabOcom_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtIesa_SabIng_Internalname ;
      private string edtIesa_SabIng_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtIesa_SabOComFec_Internalname ;
      private string edtIesa_SabOComFec_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtIesa_SabPrvCod_Internalname ;
      private string A1009Iesa_SabPrvCod ;
      private string edtIesa_SabPrvCod_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtIesa_SabPrvDsc_Internalname ;
      private string edtIesa_SabPrvDsc_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtIesa_SabOComCos_Internalname ;
      private string edtIesa_SabOComCos_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtIesa_SabIngreso_Internalname ;
      private string A999Iesa_SabIngreso ;
      private string edtIesa_SabIngreso_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtIesa_SabIngFec_Internalname ;
      private string edtIesa_SabIngFec_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtIesa_SabSts_Internalname ;
      private string A1013Iesa_SabSts ;
      private string edtIesa_SabSts_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtIesa_SabBoton_Internalname ;
      private string A995Iesa_SabBoton ;
      private string edtIesa_SabBoton_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtIesa_SabTipSal_Internalname ;
      private string A1015Iesa_SabTipSal ;
      private string edtIesa_SabTipSal_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtIesa_SabSalida_Internalname ;
      private string A1012Iesa_SabSalida ;
      private string edtIesa_SabSalida_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtIesa_SabSalFec_Internalname ;
      private string edtIesa_SabSalFec_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtIesa_SabCantAten_Internalname ;
      private string edtIesa_SabCantAten_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtIesa_SabOT_Internalname ;
      private string edtIesa_SabOT_Jsonclick ;
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
      private string Z1008Iesa_SabProdDsc ;
      private string sMode140 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ310Iesa_SabPedCod ;
      private string ZZ312Iesa_SabProdCod ;
      private string ZZ994Iesa_ObrCod ;
      private string ZZ991Iesa_AreCod ;
      private string ZZ992Iesa_CCosCod ;
      private string ZZ993Iesa_EquCod ;
      private string ZZ1002Iesa_SabOcom ;
      private string ZZ1009Iesa_SabPrvCod ;
      private string ZZ999Iesa_SabIngreso ;
      private string ZZ1013Iesa_SabSts ;
      private string ZZ995Iesa_SabBoton ;
      private string ZZ1015Iesa_SabTipSal ;
      private string ZZ1012Iesa_SabSalida ;
      private string ZZ1008Iesa_SabProdDsc ;
      private DateTime Z1007Iesa_SabPedFec ;
      private DateTime Z1004Iesa_SabOComFec ;
      private DateTime Z998Iesa_SabIngFec ;
      private DateTime Z1011Iesa_SabSalFec ;
      private DateTime A1007Iesa_SabPedFec ;
      private DateTime A1004Iesa_SabOComFec ;
      private DateTime A998Iesa_SabIngFec ;
      private DateTime A1011Iesa_SabSalFec ;
      private DateTime ZZ1007Iesa_SabPedFec ;
      private DateTime ZZ1004Iesa_SabOComFec ;
      private DateTime ZZ998Iesa_SabIngFec ;
      private DateTime ZZ1011Iesa_SabSalFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1014Iesa_SabSubLCod ;
      private bool Gx_longc ;
      private string Z1010Iesa_SabPrvDsc ;
      private string Z1005Iesa_SabOT ;
      private string A1010Iesa_SabPrvDsc ;
      private string A1005Iesa_SabOT ;
      private string ZZ1010Iesa_SabPrvDsc ;
      private string ZZ1005Iesa_SabOT ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00416_A310Iesa_SabPedCod ;
      private int[] T00416_A311Iesa_SabProdSec ;
      private string[] T00416_A1008Iesa_SabProdDsc ;
      private short[] T00416_A1001Iesa_SabLinStk ;
      private DateTime[] T00416_A1007Iesa_SabPedFec ;
      private string[] T00416_A994Iesa_ObrCod ;
      private string[] T00416_A991Iesa_AreCod ;
      private string[] T00416_A992Iesa_CCosCod ;
      private string[] T00416_A993Iesa_EquCod ;
      private decimal[] T00416_A1006Iesa_SabPedCant ;
      private string[] T00416_A1002Iesa_SabOcom ;
      private decimal[] T00416_A997Iesa_SabIng ;
      private DateTime[] T00416_A1004Iesa_SabOComFec ;
      private string[] T00416_A1009Iesa_SabPrvCod ;
      private string[] T00416_A1010Iesa_SabPrvDsc ;
      private decimal[] T00416_A1003Iesa_SabOComCos ;
      private string[] T00416_A999Iesa_SabIngreso ;
      private DateTime[] T00416_A998Iesa_SabIngFec ;
      private string[] T00416_A1013Iesa_SabSts ;
      private string[] T00416_A995Iesa_SabBoton ;
      private string[] T00416_A1015Iesa_SabTipSal ;
      private string[] T00416_A1012Iesa_SabSalida ;
      private DateTime[] T00416_A1011Iesa_SabSalFec ;
      private decimal[] T00416_A996Iesa_SabCantAten ;
      private string[] T00416_A1005Iesa_SabOT ;
      private string[] T00416_A312Iesa_SabProdCod ;
      private int[] T00416_A1000Iesa_SabLinCod ;
      private int[] T00416_A1014Iesa_SabSubLCod ;
      private bool[] T00416_n1014Iesa_SabSubLCod ;
      private string[] T00414_A1008Iesa_SabProdDsc ;
      private int[] T00414_A1000Iesa_SabLinCod ;
      private int[] T00414_A1014Iesa_SabSubLCod ;
      private bool[] T00414_n1014Iesa_SabSubLCod ;
      private short[] T00415_A1001Iesa_SabLinStk ;
      private string[] T00417_A1008Iesa_SabProdDsc ;
      private int[] T00417_A1000Iesa_SabLinCod ;
      private int[] T00417_A1014Iesa_SabSubLCod ;
      private bool[] T00417_n1014Iesa_SabSubLCod ;
      private short[] T00418_A1001Iesa_SabLinStk ;
      private string[] T00419_A310Iesa_SabPedCod ;
      private int[] T00419_A311Iesa_SabProdSec ;
      private string[] T00419_A312Iesa_SabProdCod ;
      private string[] T00413_A310Iesa_SabPedCod ;
      private int[] T00413_A311Iesa_SabProdSec ;
      private DateTime[] T00413_A1007Iesa_SabPedFec ;
      private string[] T00413_A994Iesa_ObrCod ;
      private string[] T00413_A991Iesa_AreCod ;
      private string[] T00413_A992Iesa_CCosCod ;
      private string[] T00413_A993Iesa_EquCod ;
      private decimal[] T00413_A1006Iesa_SabPedCant ;
      private string[] T00413_A1002Iesa_SabOcom ;
      private decimal[] T00413_A997Iesa_SabIng ;
      private DateTime[] T00413_A1004Iesa_SabOComFec ;
      private string[] T00413_A1009Iesa_SabPrvCod ;
      private string[] T00413_A1010Iesa_SabPrvDsc ;
      private decimal[] T00413_A1003Iesa_SabOComCos ;
      private string[] T00413_A999Iesa_SabIngreso ;
      private DateTime[] T00413_A998Iesa_SabIngFec ;
      private string[] T00413_A1013Iesa_SabSts ;
      private string[] T00413_A995Iesa_SabBoton ;
      private string[] T00413_A1015Iesa_SabTipSal ;
      private string[] T00413_A1012Iesa_SabSalida ;
      private DateTime[] T00413_A1011Iesa_SabSalFec ;
      private decimal[] T00413_A996Iesa_SabCantAten ;
      private string[] T00413_A1005Iesa_SabOT ;
      private string[] T00413_A312Iesa_SabProdCod ;
      private string[] T004110_A310Iesa_SabPedCod ;
      private int[] T004110_A311Iesa_SabProdSec ;
      private string[] T004110_A312Iesa_SabProdCod ;
      private string[] T004111_A310Iesa_SabPedCod ;
      private int[] T004111_A311Iesa_SabProdSec ;
      private string[] T004111_A312Iesa_SabProdCod ;
      private string[] T00412_A310Iesa_SabPedCod ;
      private int[] T00412_A311Iesa_SabProdSec ;
      private DateTime[] T00412_A1007Iesa_SabPedFec ;
      private string[] T00412_A994Iesa_ObrCod ;
      private string[] T00412_A991Iesa_AreCod ;
      private string[] T00412_A992Iesa_CCosCod ;
      private string[] T00412_A993Iesa_EquCod ;
      private decimal[] T00412_A1006Iesa_SabPedCant ;
      private string[] T00412_A1002Iesa_SabOcom ;
      private decimal[] T00412_A997Iesa_SabIng ;
      private DateTime[] T00412_A1004Iesa_SabOComFec ;
      private string[] T00412_A1009Iesa_SabPrvCod ;
      private string[] T00412_A1010Iesa_SabPrvDsc ;
      private decimal[] T00412_A1003Iesa_SabOComCos ;
      private string[] T00412_A999Iesa_SabIngreso ;
      private DateTime[] T00412_A998Iesa_SabIngFec ;
      private string[] T00412_A1013Iesa_SabSts ;
      private string[] T00412_A995Iesa_SabBoton ;
      private string[] T00412_A1015Iesa_SabTipSal ;
      private string[] T00412_A1012Iesa_SabSalida ;
      private DateTime[] T00412_A1011Iesa_SabSalFec ;
      private decimal[] T00412_A996Iesa_SabCantAten ;
      private string[] T00412_A1005Iesa_SabOT ;
      private string[] T00412_A312Iesa_SabProdCod ;
      private string[] T004115_A1008Iesa_SabProdDsc ;
      private int[] T004115_A1000Iesa_SabLinCod ;
      private int[] T004115_A1014Iesa_SabSubLCod ;
      private bool[] T004115_n1014Iesa_SabSubLCod ;
      private short[] T004116_A1001Iesa_SabLinStk ;
      private string[] T004117_A310Iesa_SabPedCod ;
      private int[] T004117_A311Iesa_SabProdSec ;
      private string[] T004117_A312Iesa_SabProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class obr_sabana__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class obr_sabana__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00416;
        prmT00416 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00414;
        prmT00414 = new Object[] {
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00415;
        prmT00415 = new Object[] {
        new ParDef("@Iesa_SabLinCod",GXType.Int32,6,0)
        };
        Object[] prmT00417;
        prmT00417 = new Object[] {
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00418;
        prmT00418 = new Object[] {
        new ParDef("@Iesa_SabLinCod",GXType.Int32,6,0)
        };
        Object[] prmT00419;
        prmT00419 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00413;
        prmT00413 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004110;
        prmT004110 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004111;
        prmT004111 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00412;
        prmT00412 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004112;
        prmT004112 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabPedFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_ObrCod",GXType.NChar,3,0) ,
        new ParDef("@Iesa_AreCod",GXType.NChar,3,0) ,
        new ParDef("@Iesa_CCosCod",GXType.NChar,3,0) ,
        new ParDef("@Iesa_EquCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabPedCant",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabOcom",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabIng",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabOComFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_SabPrvCod",GXType.NChar,15,0) ,
        new ParDef("@Iesa_SabPrvDsc",GXType.NVarChar,100,0) ,
        new ParDef("@Iesa_SabOComCos",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabIngreso",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabIngFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_SabSts",GXType.NChar,1,0) ,
        new ParDef("@Iesa_SabBoton",GXType.NChar,1,0) ,
        new ParDef("@Iesa_SabTipSal",GXType.NChar,3,0) ,
        new ParDef("@Iesa_SabSalida",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabSalFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_SabCantAten",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabOT",GXType.NVarChar,10,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004113;
        prmT004113 = new Object[] {
        new ParDef("@Iesa_SabPedFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_ObrCod",GXType.NChar,3,0) ,
        new ParDef("@Iesa_AreCod",GXType.NChar,3,0) ,
        new ParDef("@Iesa_CCosCod",GXType.NChar,3,0) ,
        new ParDef("@Iesa_EquCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabPedCant",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabOcom",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabIng",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabOComFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_SabPrvCod",GXType.NChar,15,0) ,
        new ParDef("@Iesa_SabPrvDsc",GXType.NVarChar,100,0) ,
        new ParDef("@Iesa_SabOComCos",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabIngreso",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabIngFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_SabSts",GXType.NChar,1,0) ,
        new ParDef("@Iesa_SabBoton",GXType.NChar,1,0) ,
        new ParDef("@Iesa_SabTipSal",GXType.NChar,3,0) ,
        new ParDef("@Iesa_SabSalida",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabSalFec",GXType.Date,8,0) ,
        new ParDef("@Iesa_SabCantAten",GXType.Decimal,15,4) ,
        new ParDef("@Iesa_SabOT",GXType.NVarChar,10,0) ,
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004114;
        prmT004114 = new Object[] {
        new ParDef("@Iesa_SabPedCod",GXType.NChar,10,0) ,
        new ParDef("@Iesa_SabProdSec",GXType.Int32,6,0) ,
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004117;
        prmT004117 = new Object[] {
        };
        Object[] prmT004115;
        prmT004115 = new Object[] {
        new ParDef("@Iesa_SabProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004116;
        prmT004116 = new Object[] {
        new ParDef("@Iesa_SabLinCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00412", "SELECT [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabPedFec], [Iesa_ObrCod], [Iesa_AreCod], [Iesa_CCosCod], [Iesa_EquCod], [Iesa_SabPedCant], [Iesa_SabOcom], [Iesa_SabIng], [Iesa_SabOComFec], [Iesa_SabPrvCod], [Iesa_SabPrvDsc], [Iesa_SabOComCos], [Iesa_SabIngreso], [Iesa_SabIngFec], [Iesa_SabSts], [Iesa_SabBoton], [Iesa_SabTipSal], [Iesa_SabSalida], [Iesa_SabSalFec], [Iesa_SabCantAten], [Iesa_SabOT], [Iesa_SabProdCod] AS Iesa_SabProdCod FROM [OBR_SABANA] WITH (UPDLOCK) WHERE [Iesa_SabPedCod] = @Iesa_SabPedCod AND [Iesa_SabProdSec] = @Iesa_SabProdSec AND [Iesa_SabProdCod] = @Iesa_SabProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00413", "SELECT [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabPedFec], [Iesa_ObrCod], [Iesa_AreCod], [Iesa_CCosCod], [Iesa_EquCod], [Iesa_SabPedCant], [Iesa_SabOcom], [Iesa_SabIng], [Iesa_SabOComFec], [Iesa_SabPrvCod], [Iesa_SabPrvDsc], [Iesa_SabOComCos], [Iesa_SabIngreso], [Iesa_SabIngFec], [Iesa_SabSts], [Iesa_SabBoton], [Iesa_SabTipSal], [Iesa_SabSalida], [Iesa_SabSalFec], [Iesa_SabCantAten], [Iesa_SabOT], [Iesa_SabProdCod] AS Iesa_SabProdCod FROM [OBR_SABANA] WHERE [Iesa_SabPedCod] = @Iesa_SabPedCod AND [Iesa_SabProdSec] = @Iesa_SabProdSec AND [Iesa_SabProdCod] = @Iesa_SabProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00414", "SELECT [ProdDsc] AS Iesa_SabProdDsc, [LinCod] AS Iesa_SabLinCod, [SublCod] AS Iesa_SabSubLCod FROM [APRODUCTOS] WHERE [ProdCod] = @Iesa_SabProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00414,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00415", "SELECT [LinStk] AS Iesa_SabLinStk FROM [CLINEAPROD] WHERE [LinCod] = @Iesa_SabLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00416", "SELECT TM1.[Iesa_SabPedCod], TM1.[Iesa_SabProdSec], T2.[ProdDsc] AS Iesa_SabProdDsc, T3.[LinStk] AS Iesa_SabLinStk, TM1.[Iesa_SabPedFec], TM1.[Iesa_ObrCod], TM1.[Iesa_AreCod], TM1.[Iesa_CCosCod], TM1.[Iesa_EquCod], TM1.[Iesa_SabPedCant], TM1.[Iesa_SabOcom], TM1.[Iesa_SabIng], TM1.[Iesa_SabOComFec], TM1.[Iesa_SabPrvCod], TM1.[Iesa_SabPrvDsc], TM1.[Iesa_SabOComCos], TM1.[Iesa_SabIngreso], TM1.[Iesa_SabIngFec], TM1.[Iesa_SabSts], TM1.[Iesa_SabBoton], TM1.[Iesa_SabTipSal], TM1.[Iesa_SabSalida], TM1.[Iesa_SabSalFec], TM1.[Iesa_SabCantAten], TM1.[Iesa_SabOT], TM1.[Iesa_SabProdCod] AS Iesa_SabProdCod, T2.[LinCod] AS Iesa_SabLinCod, T2.[SublCod] AS Iesa_SabSubLCod FROM (([OBR_SABANA] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[Iesa_SabProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) WHERE TM1.[Iesa_SabPedCod] = @Iesa_SabPedCod and TM1.[Iesa_SabProdSec] = @Iesa_SabProdSec and TM1.[Iesa_SabProdCod] = @Iesa_SabProdCod ORDER BY TM1.[Iesa_SabPedCod], TM1.[Iesa_SabProdSec], TM1.[Iesa_SabProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00416,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00417", "SELECT [ProdDsc] AS Iesa_SabProdDsc, [LinCod] AS Iesa_SabLinCod, [SublCod] AS Iesa_SabSubLCod FROM [APRODUCTOS] WHERE [ProdCod] = @Iesa_SabProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00418", "SELECT [LinStk] AS Iesa_SabLinStk FROM [CLINEAPROD] WHERE [LinCod] = @Iesa_SabLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00419", "SELECT [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] AS Iesa_SabProdCod FROM [OBR_SABANA] WHERE [Iesa_SabPedCod] = @Iesa_SabPedCod AND [Iesa_SabProdSec] = @Iesa_SabProdSec AND [Iesa_SabProdCod] = @Iesa_SabProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004110", "SELECT TOP 1 [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] AS Iesa_SabProdCod FROM [OBR_SABANA] WHERE ( [Iesa_SabPedCod] > @Iesa_SabPedCod or [Iesa_SabPedCod] = @Iesa_SabPedCod and [Iesa_SabProdSec] > @Iesa_SabProdSec or [Iesa_SabProdSec] = @Iesa_SabProdSec and [Iesa_SabPedCod] = @Iesa_SabPedCod and [Iesa_SabProdCod] > @Iesa_SabProdCod) ORDER BY [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004110,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004111", "SELECT TOP 1 [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] AS Iesa_SabProdCod FROM [OBR_SABANA] WHERE ( [Iesa_SabPedCod] < @Iesa_SabPedCod or [Iesa_SabPedCod] = @Iesa_SabPedCod and [Iesa_SabProdSec] < @Iesa_SabProdSec or [Iesa_SabProdSec] = @Iesa_SabProdSec and [Iesa_SabPedCod] = @Iesa_SabPedCod and [Iesa_SabProdCod] < @Iesa_SabProdCod) ORDER BY [Iesa_SabPedCod] DESC, [Iesa_SabProdSec] DESC, [Iesa_SabProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004112", "INSERT INTO [OBR_SABANA]([Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabPedFec], [Iesa_ObrCod], [Iesa_AreCod], [Iesa_CCosCod], [Iesa_EquCod], [Iesa_SabPedCant], [Iesa_SabOcom], [Iesa_SabIng], [Iesa_SabOComFec], [Iesa_SabPrvCod], [Iesa_SabPrvDsc], [Iesa_SabOComCos], [Iesa_SabIngreso], [Iesa_SabIngFec], [Iesa_SabSts], [Iesa_SabBoton], [Iesa_SabTipSal], [Iesa_SabSalida], [Iesa_SabSalFec], [Iesa_SabCantAten], [Iesa_SabOT], [Iesa_SabProdCod]) VALUES(@Iesa_SabPedCod, @Iesa_SabProdSec, @Iesa_SabPedFec, @Iesa_ObrCod, @Iesa_AreCod, @Iesa_CCosCod, @Iesa_EquCod, @Iesa_SabPedCant, @Iesa_SabOcom, @Iesa_SabIng, @Iesa_SabOComFec, @Iesa_SabPrvCod, @Iesa_SabPrvDsc, @Iesa_SabOComCos, @Iesa_SabIngreso, @Iesa_SabIngFec, @Iesa_SabSts, @Iesa_SabBoton, @Iesa_SabTipSal, @Iesa_SabSalida, @Iesa_SabSalFec, @Iesa_SabCantAten, @Iesa_SabOT, @Iesa_SabProdCod)", GxErrorMask.GX_NOMASK,prmT004112)
           ,new CursorDef("T004113", "UPDATE [OBR_SABANA] SET [Iesa_SabPedFec]=@Iesa_SabPedFec, [Iesa_ObrCod]=@Iesa_ObrCod, [Iesa_AreCod]=@Iesa_AreCod, [Iesa_CCosCod]=@Iesa_CCosCod, [Iesa_EquCod]=@Iesa_EquCod, [Iesa_SabPedCant]=@Iesa_SabPedCant, [Iesa_SabOcom]=@Iesa_SabOcom, [Iesa_SabIng]=@Iesa_SabIng, [Iesa_SabOComFec]=@Iesa_SabOComFec, [Iesa_SabPrvCod]=@Iesa_SabPrvCod, [Iesa_SabPrvDsc]=@Iesa_SabPrvDsc, [Iesa_SabOComCos]=@Iesa_SabOComCos, [Iesa_SabIngreso]=@Iesa_SabIngreso, [Iesa_SabIngFec]=@Iesa_SabIngFec, [Iesa_SabSts]=@Iesa_SabSts, [Iesa_SabBoton]=@Iesa_SabBoton, [Iesa_SabTipSal]=@Iesa_SabTipSal, [Iesa_SabSalida]=@Iesa_SabSalida, [Iesa_SabSalFec]=@Iesa_SabSalFec, [Iesa_SabCantAten]=@Iesa_SabCantAten, [Iesa_SabOT]=@Iesa_SabOT  WHERE [Iesa_SabPedCod] = @Iesa_SabPedCod AND [Iesa_SabProdSec] = @Iesa_SabProdSec AND [Iesa_SabProdCod] = @Iesa_SabProdCod", GxErrorMask.GX_NOMASK,prmT004113)
           ,new CursorDef("T004114", "DELETE FROM [OBR_SABANA]  WHERE [Iesa_SabPedCod] = @Iesa_SabPedCod AND [Iesa_SabProdSec] = @Iesa_SabProdSec AND [Iesa_SabProdCod] = @Iesa_SabProdCod", GxErrorMask.GX_NOMASK,prmT004114)
           ,new CursorDef("T004115", "SELECT [ProdDsc] AS Iesa_SabProdDsc, [LinCod] AS Iesa_SabLinCod, [SublCod] AS Iesa_SabSubLCod FROM [APRODUCTOS] WHERE [ProdCod] = @Iesa_SabProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004115,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004116", "SELECT [LinStk] AS Iesa_SabLinStk FROM [CLINEAPROD] WHERE [LinCod] = @Iesa_SabLinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004116,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004117", "SELECT [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] AS Iesa_SabProdCod FROM [OBR_SABANA] ORDER BY [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004117,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 1);
              ((string[]) buf[17])[0] = rslt.getString(18, 1);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 1);
              ((string[]) buf[17])[0] = rslt.getString(18, 1);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 15);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 1);
              ((string[]) buf[19])[0] = rslt.getString(20, 1);
              ((string[]) buf[20])[0] = rslt.getString(21, 3);
              ((string[]) buf[21])[0] = rslt.getString(22, 10);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(23);
              ((decimal[]) buf[23])[0] = rslt.getDecimal(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 15);
              ((int[]) buf[26])[0] = rslt.getInt(27);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              ((bool[]) buf[28])[0] = rslt.wasNull(28);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
     }
  }

}

}
