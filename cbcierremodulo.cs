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
   public class cbcierremodulo : GXDataArea
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
            Form.Meta.addItem("description", "Cierre Modulo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbcierremodulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbcierremodulo( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBCIERREMODULO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Modulo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModCod_Internalname, StringUtil.RTrim( A73CMModCod), StringUtil.RTrim( context.localUtil.Format( A73CMModCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Año", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A74CMModAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtCMModAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9") : context.localUtil.Format( (decimal)(A74CMModAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Mes", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75CMModMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtCMModMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A75CMModMes), "Z9") : context.localUtil.Format( (decimal)(A75CMModMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Estado", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A640CMModSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCMModSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A640CMModSts), "9") : context.localUtil.Format( (decimal)(A640CMModSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Usuario Creación", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModUsuC_Internalname, StringUtil.RTrim( A641CMModUsuC), StringUtil.RTrim( context.localUtil.Format( A641CMModUsuC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Fecha Creación", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCMModFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCMModFecC_Internalname, context.localUtil.Format(A638CMModFecC, "99/99/99"), context.localUtil.Format( A638CMModFecC, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModFecC_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBCIERREMODULO.htm");
         GxWebStd.gx_bitmap( context, edtCMModFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCMModFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Usuario Modificación", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCMModUsuM_Internalname, StringUtil.RTrim( A642CMModUsuM), StringUtil.RTrim( context.localUtil.Format( A642CMModUsuM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fecha Modificación", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBCIERREMODULO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCMModFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCMModFecM_Internalname, context.localUtil.Format(A639CMModFecM, "99/99/99"), context.localUtil.Format( A639CMModFecM, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCMModFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCMModFecM_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBCIERREMODULO.htm");
         GxWebStd.gx_bitmap( context, edtCMModFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCMModFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CBCIERREMODULO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBCIERREMODULO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBCIERREMODULO.htm");
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
            Z73CMModCod = cgiGet( "Z73CMModCod");
            Z74CMModAno = (short)(context.localUtil.CToN( cgiGet( "Z74CMModAno"), ".", ","));
            Z75CMModMes = (short)(context.localUtil.CToN( cgiGet( "Z75CMModMes"), ".", ","));
            Z640CMModSts = (short)(context.localUtil.CToN( cgiGet( "Z640CMModSts"), ".", ","));
            Z641CMModUsuC = cgiGet( "Z641CMModUsuC");
            Z638CMModFecC = context.localUtil.CToD( cgiGet( "Z638CMModFecC"), 0);
            Z642CMModUsuM = cgiGet( "Z642CMModUsuM");
            Z639CMModFecM = context.localUtil.CToD( cgiGet( "Z639CMModFecM"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A73CMModCod = cgiGet( edtCMModCod_Internalname);
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CMMODANO");
               AnyError = 1;
               GX_FocusControl = edtCMModAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A74CMModAno = 0;
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            }
            else
            {
               A74CMModAno = (short)(context.localUtil.CToN( cgiGet( edtCMModAno_Internalname), ".", ","));
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCMModMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCMModMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CMMODMES");
               AnyError = 1;
               GX_FocusControl = edtCMModMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A75CMModMes = 0;
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            }
            else
            {
               A75CMModMes = (short)(context.localUtil.CToN( cgiGet( edtCMModMes_Internalname), ".", ","));
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCMModSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCMModSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CMMODSTS");
               AnyError = 1;
               GX_FocusControl = edtCMModSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A640CMModSts = 0;
               AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            }
            else
            {
               A640CMModSts = (short)(context.localUtil.CToN( cgiGet( edtCMModSts_Internalname), ".", ","));
               AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            }
            A641CMModUsuC = cgiGet( edtCMModUsuC_Internalname);
            AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
            if ( context.localUtil.VCDate( cgiGet( edtCMModFecC_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Creación"}), 1, "CMMODFECC");
               AnyError = 1;
               GX_FocusControl = edtCMModFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A638CMModFecC = DateTime.MinValue;
               AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
            }
            else
            {
               A638CMModFecC = context.localUtil.CToD( cgiGet( edtCMModFecC_Internalname), 2);
               AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
            }
            A642CMModUsuM = cgiGet( edtCMModUsuM_Internalname);
            AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
            if ( context.localUtil.VCDate( cgiGet( edtCMModFecM_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Modificación"}), 1, "CMMODFECM");
               AnyError = 1;
               GX_FocusControl = edtCMModFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A639CMModFecM = DateTime.MinValue;
               AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
            }
            else
            {
               A639CMModFecM = context.localUtil.CToD( cgiGet( edtCMModFecM_Internalname), 2);
               AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
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
               A73CMModCod = GetPar( "CMModCod");
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               A74CMModAno = (short)(NumberUtil.Val( GetPar( "CMModAno"), "."));
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               A75CMModMes = (short)(NumberUtil.Val( GetPar( "CMModMes"), "."));
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
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
               InitAll1N7( ) ;
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
         DisableAttributes1N7( ) ;
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

      protected void CONFIRM_1N0( )
      {
         BeforeValidate1N7( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1N7( ) ;
            }
            else
            {
               CheckExtendedTable1N7( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1N7( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1N0( ) ;
         }
      }

      protected void ResetCaption1N0( )
      {
      }

      protected void ZM1N7( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z640CMModSts = T001N3_A640CMModSts[0];
               Z641CMModUsuC = T001N3_A641CMModUsuC[0];
               Z638CMModFecC = T001N3_A638CMModFecC[0];
               Z642CMModUsuM = T001N3_A642CMModUsuM[0];
               Z639CMModFecM = T001N3_A639CMModFecM[0];
            }
            else
            {
               Z640CMModSts = A640CMModSts;
               Z641CMModUsuC = A641CMModUsuC;
               Z638CMModFecC = A638CMModFecC;
               Z642CMModUsuM = A642CMModUsuM;
               Z639CMModFecM = A639CMModFecM;
            }
         }
         if ( GX_JID == -3 )
         {
            Z73CMModCod = A73CMModCod;
            Z74CMModAno = A74CMModAno;
            Z75CMModMes = A75CMModMes;
            Z640CMModSts = A640CMModSts;
            Z641CMModUsuC = A641CMModUsuC;
            Z638CMModFecC = A638CMModFecC;
            Z642CMModUsuM = A642CMModUsuM;
            Z639CMModFecM = A639CMModFecM;
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

      protected void Load1N7( )
      {
         /* Using cursor T001N4 */
         pr_default.execute(2, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound7 = 1;
            A640CMModSts = T001N4_A640CMModSts[0];
            AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            A641CMModUsuC = T001N4_A641CMModUsuC[0];
            AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
            A638CMModFecC = T001N4_A638CMModFecC[0];
            AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
            A642CMModUsuM = T001N4_A642CMModUsuM[0];
            AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
            A639CMModFecM = T001N4_A639CMModFecM[0];
            AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
            ZM1N7( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1N7( ) ;
      }

      protected void OnLoadActions1N7( )
      {
      }

      protected void CheckExtendedTable1N7( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A638CMModFecC) || ( DateTimeUtil.ResetTime ( A638CMModFecC ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Creación fuera de rango", "OutOfRange", 1, "CMMODFECC");
            AnyError = 1;
            GX_FocusControl = edtCMModFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A639CMModFecM) || ( DateTimeUtil.ResetTime ( A639CMModFecM ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Modificación fuera de rango", "OutOfRange", 1, "CMMODFECM");
            AnyError = 1;
            GX_FocusControl = edtCMModFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1N7( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1N7( )
      {
         /* Using cursor T001N5 */
         pr_default.execute(3, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001N3 */
         pr_default.execute(1, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1N7( 3) ;
            RcdFound7 = 1;
            A73CMModCod = T001N3_A73CMModCod[0];
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = T001N3_A74CMModAno[0];
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = T001N3_A75CMModMes[0];
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            A640CMModSts = T001N3_A640CMModSts[0];
            AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
            A641CMModUsuC = T001N3_A641CMModUsuC[0];
            AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
            A638CMModFecC = T001N3_A638CMModFecC[0];
            AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
            A642CMModUsuM = T001N3_A642CMModUsuM[0];
            AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
            A639CMModFecM = T001N3_A639CMModFecM[0];
            AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
            Z73CMModCod = A73CMModCod;
            Z74CMModAno = A74CMModAno;
            Z75CMModMes = A75CMModMes;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1N7( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey1N7( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey1N7( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1N7( ) ;
         if ( RcdFound7 == 0 )
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
         RcdFound7 = 0;
         /* Using cursor T001N6 */
         pr_default.execute(4, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T001N6_A73CMModCod[0], A73CMModCod) < 0 ) || ( StringUtil.StrCmp(T001N6_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N6_A74CMModAno[0] < A74CMModAno ) || ( T001N6_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T001N6_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N6_A75CMModMes[0] < A75CMModMes ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T001N6_A73CMModCod[0], A73CMModCod) > 0 ) || ( StringUtil.StrCmp(T001N6_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N6_A74CMModAno[0] > A74CMModAno ) || ( T001N6_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T001N6_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N6_A75CMModMes[0] > A75CMModMes ) ) )
            {
               A73CMModCod = T001N6_A73CMModCod[0];
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               A74CMModAno = T001N6_A74CMModAno[0];
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               A75CMModMes = T001N6_A75CMModMes[0];
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T001N7 */
         pr_default.execute(5, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001N7_A73CMModCod[0], A73CMModCod) > 0 ) || ( StringUtil.StrCmp(T001N7_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N7_A74CMModAno[0] > A74CMModAno ) || ( T001N7_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T001N7_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N7_A75CMModMes[0] > A75CMModMes ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T001N7_A73CMModCod[0], A73CMModCod) < 0 ) || ( StringUtil.StrCmp(T001N7_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N7_A74CMModAno[0] < A74CMModAno ) || ( T001N7_A74CMModAno[0] == A74CMModAno ) && ( StringUtil.StrCmp(T001N7_A73CMModCod[0], A73CMModCod) == 0 ) && ( T001N7_A75CMModMes[0] < A75CMModMes ) ) )
            {
               A73CMModCod = T001N7_A73CMModCod[0];
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               A74CMModAno = T001N7_A74CMModAno[0];
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               A75CMModMes = T001N7_A75CMModMes[0];
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1N7( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1N7( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
               {
                  A73CMModCod = Z73CMModCod;
                  AssignAttri("", false, "A73CMModCod", A73CMModCod);
                  A74CMModAno = Z74CMModAno;
                  AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
                  A75CMModMes = Z75CMModMes;
                  AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CMMODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1N7( ) ;
                  GX_FocusControl = edtCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCMModCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1N7( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CMMODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCMModCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCMModCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1N7( ) ;
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
         if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
         {
            A73CMModCod = Z73CMModCod;
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = Z74CMModAno;
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = Z75CMModMes;
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CMMODCOD");
            AnyError = 1;
            GX_FocusControl = edtCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCMModCod_Internalname;
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
         GetKey1N7( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CMMODCOD");
               AnyError = 1;
               GX_FocusControl = edtCMModCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
            {
               A73CMModCod = Z73CMModCod;
               AssignAttri("", false, "A73CMModCod", A73CMModCod);
               A74CMModAno = Z74CMModAno;
               AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
               A75CMModMes = Z75CMModMes;
               AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CMMODCOD");
               AnyError = 1;
               GX_FocusControl = edtCMModCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A73CMModCod, Z73CMModCod) != 0 ) || ( A74CMModAno != Z74CMModAno ) || ( A75CMModMes != Z75CMModMes ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CMMODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCMModCod_Internalname;
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
         context.RollbackDataStores("cbcierremodulo",pr_default);
         GX_FocusControl = edtCMModSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1N0( ) ;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CMMODCOD");
            AnyError = 1;
            GX_FocusControl = edtCMModCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCMModSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1N7( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCMModSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1N7( ) ;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCMModSts_Internalname;
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
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCMModSts_Internalname;
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
         ScanStart1N7( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound7 != 0 )
            {
               ScanNext1N7( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCMModSts_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1N7( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1N7( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001N2 */
            pr_default.execute(0, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCIERREMODULO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z640CMModSts != T001N2_A640CMModSts[0] ) || ( StringUtil.StrCmp(Z641CMModUsuC, T001N2_A641CMModUsuC[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z638CMModFecC ) != DateTimeUtil.ResetTime ( T001N2_A638CMModFecC[0] ) ) || ( StringUtil.StrCmp(Z642CMModUsuM, T001N2_A642CMModUsuM[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z639CMModFecM ) != DateTimeUtil.ResetTime ( T001N2_A639CMModFecM[0] ) ) )
            {
               if ( Z640CMModSts != T001N2_A640CMModSts[0] )
               {
                  GXUtil.WriteLog("cbcierremodulo:[seudo value changed for attri]"+"CMModSts");
                  GXUtil.WriteLogRaw("Old: ",Z640CMModSts);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A640CMModSts[0]);
               }
               if ( StringUtil.StrCmp(Z641CMModUsuC, T001N2_A641CMModUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcierremodulo:[seudo value changed for attri]"+"CMModUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z641CMModUsuC);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A641CMModUsuC[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z638CMModFecC ) != DateTimeUtil.ResetTime ( T001N2_A638CMModFecC[0] ) )
               {
                  GXUtil.WriteLog("cbcierremodulo:[seudo value changed for attri]"+"CMModFecC");
                  GXUtil.WriteLogRaw("Old: ",Z638CMModFecC);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A638CMModFecC[0]);
               }
               if ( StringUtil.StrCmp(Z642CMModUsuM, T001N2_A642CMModUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("cbcierremodulo:[seudo value changed for attri]"+"CMModUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z642CMModUsuM);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A642CMModUsuM[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z639CMModFecM ) != DateTimeUtil.ResetTime ( T001N2_A639CMModFecM[0] ) )
               {
                  GXUtil.WriteLog("cbcierremodulo:[seudo value changed for attri]"+"CMModFecM");
                  GXUtil.WriteLogRaw("Old: ",Z639CMModFecM);
                  GXUtil.WriteLogRaw("Current: ",T001N2_A639CMModFecM[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBCIERREMODULO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1N7( )
      {
         BeforeValidate1N7( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N7( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1N7( 0) ;
            CheckOptimisticConcurrency1N7( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N7( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1N7( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001N8 */
                     pr_default.execute(6, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes, A640CMModSts, A641CMModUsuC, A638CMModFecC, A642CMModUsuM, A639CMModFecM});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCIERREMODULO");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption1N0( ) ;
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
               Load1N7( ) ;
            }
            EndLevel1N7( ) ;
         }
         CloseExtendedTableCursors1N7( ) ;
      }

      protected void Update1N7( )
      {
         BeforeValidate1N7( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N7( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N7( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N7( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1N7( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001N9 */
                     pr_default.execute(7, new Object[] {A640CMModSts, A641CMModUsuC, A638CMModFecC, A642CMModUsuM, A639CMModFecM, A73CMModCod, A74CMModAno, A75CMModMes});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CBCIERREMODULO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBCIERREMODULO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1N7( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1N0( ) ;
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
            EndLevel1N7( ) ;
         }
         CloseExtendedTableCursors1N7( ) ;
      }

      protected void DeferredUpdate1N7( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1N7( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N7( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1N7( ) ;
            AfterConfirm1N7( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1N7( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001N10 */
                  pr_default.execute(8, new Object[] {A73CMModCod, A74CMModAno, A75CMModMes});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CBCIERREMODULO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound7 == 0 )
                        {
                           InitAll1N7( ) ;
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
                        ResetCaption1N0( ) ;
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1N7( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1N7( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1N7( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1N7( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbcierremodulo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbcierremodulo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1N7( )
      {
         /* Using cursor T001N11 */
         pr_default.execute(9);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A73CMModCod = T001N11_A73CMModCod[0];
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = T001N11_A74CMModAno[0];
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = T001N11_A75CMModMes[0];
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1N7( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A73CMModCod = T001N11_A73CMModCod[0];
            AssignAttri("", false, "A73CMModCod", A73CMModCod);
            A74CMModAno = T001N11_A74CMModAno[0];
            AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
            A75CMModMes = T001N11_A75CMModMes[0];
            AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         }
      }

      protected void ScanEnd1N7( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1N7( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1N7( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1N7( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1N7( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1N7( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1N7( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1N7( )
      {
         edtCMModCod_Enabled = 0;
         AssignProp("", false, edtCMModCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModCod_Enabled), 5, 0), true);
         edtCMModAno_Enabled = 0;
         AssignProp("", false, edtCMModAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModAno_Enabled), 5, 0), true);
         edtCMModMes_Enabled = 0;
         AssignProp("", false, edtCMModMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModMes_Enabled), 5, 0), true);
         edtCMModSts_Enabled = 0;
         AssignProp("", false, edtCMModSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModSts_Enabled), 5, 0), true);
         edtCMModUsuC_Enabled = 0;
         AssignProp("", false, edtCMModUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuC_Enabled), 5, 0), true);
         edtCMModFecC_Enabled = 0;
         AssignProp("", false, edtCMModFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecC_Enabled), 5, 0), true);
         edtCMModUsuM_Enabled = 0;
         AssignProp("", false, edtCMModUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModUsuM_Enabled), 5, 0), true);
         edtCMModFecM_Enabled = 0;
         AssignProp("", false, edtCMModFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCMModFecM_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1N7( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1N0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181024385", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbcierremodulo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z73CMModCod", StringUtil.RTrim( Z73CMModCod));
         GxWebStd.gx_hidden_field( context, "Z74CMModAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z74CMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z75CMModMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75CMModMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z640CMModSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z640CMModSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z641CMModUsuC", StringUtil.RTrim( Z641CMModUsuC));
         GxWebStd.gx_hidden_field( context, "Z638CMModFecC", context.localUtil.DToC( Z638CMModFecC, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z642CMModUsuM", StringUtil.RTrim( Z642CMModUsuM));
         GxWebStd.gx_hidden_field( context, "Z639CMModFecM", context.localUtil.DToC( Z639CMModFecM, 0, "/"));
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
         return formatLink("cbcierremodulo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBCIERREMODULO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cierre Modulo" ;
      }

      protected void InitializeNonKey1N7( )
      {
         A640CMModSts = 0;
         AssignAttri("", false, "A640CMModSts", StringUtil.Str( (decimal)(A640CMModSts), 1, 0));
         A641CMModUsuC = "";
         AssignAttri("", false, "A641CMModUsuC", A641CMModUsuC);
         A638CMModFecC = DateTime.MinValue;
         AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
         A642CMModUsuM = "";
         AssignAttri("", false, "A642CMModUsuM", A642CMModUsuM);
         A639CMModFecM = DateTime.MinValue;
         AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
         Z640CMModSts = 0;
         Z641CMModUsuC = "";
         Z638CMModFecC = DateTime.MinValue;
         Z642CMModUsuM = "";
         Z639CMModFecM = DateTime.MinValue;
      }

      protected void InitAll1N7( )
      {
         A73CMModCod = "";
         AssignAttri("", false, "A73CMModCod", A73CMModCod);
         A74CMModAno = 0;
         AssignAttri("", false, "A74CMModAno", StringUtil.LTrimStr( (decimal)(A74CMModAno), 4, 0));
         A75CMModMes = 0;
         AssignAttri("", false, "A75CMModMes", StringUtil.LTrimStr( (decimal)(A75CMModMes), 2, 0));
         InitializeNonKey1N7( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024392", true, true);
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
         context.AddJavascriptSource("cbcierremodulo.js", "?20228181024392", false, true);
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
         edtCMModCod_Internalname = "CMMODCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCMModAno_Internalname = "CMMODANO";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCMModMes_Internalname = "CMMODMES";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCMModSts_Internalname = "CMMODSTS";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCMModUsuC_Internalname = "CMMODUSUC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCMModFecC_Internalname = "CMMODFECC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCMModUsuM_Internalname = "CMMODUSUM";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCMModFecM_Internalname = "CMMODFECM";
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
         Form.Caption = "Cierre Modulo";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCMModFecM_Jsonclick = "";
         edtCMModFecM_Enabled = 1;
         edtCMModUsuM_Jsonclick = "";
         edtCMModUsuM_Enabled = 1;
         edtCMModFecC_Jsonclick = "";
         edtCMModFecC_Enabled = 1;
         edtCMModUsuC_Jsonclick = "";
         edtCMModUsuC_Enabled = 1;
         edtCMModSts_Jsonclick = "";
         edtCMModSts_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCMModMes_Jsonclick = "";
         edtCMModMes_Enabled = 1;
         edtCMModAno_Jsonclick = "";
         edtCMModAno_Enabled = 1;
         edtCMModCod_Jsonclick = "";
         edtCMModCod_Enabled = 1;
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
         GX_FocusControl = edtCMModSts_Internalname;
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

      public void Valid_Cmmodmes( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A640CMModSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A640CMModSts), 1, 0, ".", "")));
         AssignAttri("", false, "A641CMModUsuC", StringUtil.RTrim( A641CMModUsuC));
         AssignAttri("", false, "A638CMModFecC", context.localUtil.Format(A638CMModFecC, "99/99/99"));
         AssignAttri("", false, "A642CMModUsuM", StringUtil.RTrim( A642CMModUsuM));
         AssignAttri("", false, "A639CMModFecM", context.localUtil.Format(A639CMModFecM, "99/99/99"));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z73CMModCod", StringUtil.RTrim( Z73CMModCod));
         GxWebStd.gx_hidden_field( context, "Z74CMModAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z74CMModAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z75CMModMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75CMModMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z640CMModSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z640CMModSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z641CMModUsuC", StringUtil.RTrim( Z641CMModUsuC));
         GxWebStd.gx_hidden_field( context, "Z638CMModFecC", context.localUtil.Format(Z638CMModFecC, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z642CMModUsuM", StringUtil.RTrim( Z642CMModUsuM));
         GxWebStd.gx_hidden_field( context, "Z639CMModFecM", context.localUtil.Format(Z639CMModFecM, "99/99/99"));
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
         setEventMetadata("VALID_CMMODCOD","{handler:'Valid_Cmmodcod',iparms:[]");
         setEventMetadata("VALID_CMMODCOD",",oparms:[]}");
         setEventMetadata("VALID_CMMODANO","{handler:'Valid_Cmmodano',iparms:[]");
         setEventMetadata("VALID_CMMODANO",",oparms:[]}");
         setEventMetadata("VALID_CMMODMES","{handler:'Valid_Cmmodmes',iparms:[{av:'A73CMModCod',fld:'CMMODCOD',pic:''},{av:'A74CMModAno',fld:'CMMODANO',pic:'ZZZ9'},{av:'A75CMModMes',fld:'CMMODMES',pic:'Z9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CMMODMES",",oparms:[{av:'A640CMModSts',fld:'CMMODSTS',pic:'9'},{av:'A641CMModUsuC',fld:'CMMODUSUC',pic:''},{av:'A638CMModFecC',fld:'CMMODFECC',pic:''},{av:'A642CMModUsuM',fld:'CMMODUSUM',pic:''},{av:'A639CMModFecM',fld:'CMMODFECM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z73CMModCod'},{av:'Z74CMModAno'},{av:'Z75CMModMes'},{av:'Z640CMModSts'},{av:'Z641CMModUsuC'},{av:'Z638CMModFecC'},{av:'Z642CMModUsuM'},{av:'Z639CMModFecM'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CMMODFECC","{handler:'Valid_Cmmodfecc',iparms:[]");
         setEventMetadata("VALID_CMMODFECC",",oparms:[]}");
         setEventMetadata("VALID_CMMODFECM","{handler:'Valid_Cmmodfecm',iparms:[]");
         setEventMetadata("VALID_CMMODFECM",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z73CMModCod = "";
         Z641CMModUsuC = "";
         Z638CMModFecC = DateTime.MinValue;
         Z642CMModUsuM = "";
         Z639CMModFecM = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A73CMModCod = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A641CMModUsuC = "";
         lblTextblock6_Jsonclick = "";
         A638CMModFecC = DateTime.MinValue;
         lblTextblock7_Jsonclick = "";
         A642CMModUsuM = "";
         lblTextblock8_Jsonclick = "";
         A639CMModFecM = DateTime.MinValue;
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
         T001N4_A73CMModCod = new string[] {""} ;
         T001N4_A74CMModAno = new short[1] ;
         T001N4_A75CMModMes = new short[1] ;
         T001N4_A640CMModSts = new short[1] ;
         T001N4_A641CMModUsuC = new string[] {""} ;
         T001N4_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         T001N4_A642CMModUsuM = new string[] {""} ;
         T001N4_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         T001N5_A73CMModCod = new string[] {""} ;
         T001N5_A74CMModAno = new short[1] ;
         T001N5_A75CMModMes = new short[1] ;
         T001N3_A73CMModCod = new string[] {""} ;
         T001N3_A74CMModAno = new short[1] ;
         T001N3_A75CMModMes = new short[1] ;
         T001N3_A640CMModSts = new short[1] ;
         T001N3_A641CMModUsuC = new string[] {""} ;
         T001N3_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         T001N3_A642CMModUsuM = new string[] {""} ;
         T001N3_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         sMode7 = "";
         T001N6_A73CMModCod = new string[] {""} ;
         T001N6_A74CMModAno = new short[1] ;
         T001N6_A75CMModMes = new short[1] ;
         T001N7_A73CMModCod = new string[] {""} ;
         T001N7_A74CMModAno = new short[1] ;
         T001N7_A75CMModMes = new short[1] ;
         T001N2_A73CMModCod = new string[] {""} ;
         T001N2_A74CMModAno = new short[1] ;
         T001N2_A75CMModMes = new short[1] ;
         T001N2_A640CMModSts = new short[1] ;
         T001N2_A641CMModUsuC = new string[] {""} ;
         T001N2_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         T001N2_A642CMModUsuM = new string[] {""} ;
         T001N2_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         T001N11_A73CMModCod = new string[] {""} ;
         T001N11_A74CMModAno = new short[1] ;
         T001N11_A75CMModMes = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ73CMModCod = "";
         ZZ641CMModUsuC = "";
         ZZ638CMModFecC = DateTime.MinValue;
         ZZ642CMModUsuM = "";
         ZZ639CMModFecM = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbcierremodulo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbcierremodulo__default(),
            new Object[][] {
                new Object[] {
               T001N2_A73CMModCod, T001N2_A74CMModAno, T001N2_A75CMModMes, T001N2_A640CMModSts, T001N2_A641CMModUsuC, T001N2_A638CMModFecC, T001N2_A642CMModUsuM, T001N2_A639CMModFecM
               }
               , new Object[] {
               T001N3_A73CMModCod, T001N3_A74CMModAno, T001N3_A75CMModMes, T001N3_A640CMModSts, T001N3_A641CMModUsuC, T001N3_A638CMModFecC, T001N3_A642CMModUsuM, T001N3_A639CMModFecM
               }
               , new Object[] {
               T001N4_A73CMModCod, T001N4_A74CMModAno, T001N4_A75CMModMes, T001N4_A640CMModSts, T001N4_A641CMModUsuC, T001N4_A638CMModFecC, T001N4_A642CMModUsuM, T001N4_A639CMModFecM
               }
               , new Object[] {
               T001N5_A73CMModCod, T001N5_A74CMModAno, T001N5_A75CMModMes
               }
               , new Object[] {
               T001N6_A73CMModCod, T001N6_A74CMModAno, T001N6_A75CMModMes
               }
               , new Object[] {
               T001N7_A73CMModCod, T001N7_A74CMModAno, T001N7_A75CMModMes
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001N11_A73CMModCod, T001N11_A74CMModAno, T001N11_A75CMModMes
               }
            }
         );
      }

      private short Z74CMModAno ;
      private short Z75CMModMes ;
      private short Z640CMModSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A74CMModAno ;
      private short A75CMModMes ;
      private short A640CMModSts ;
      private short GX_JID ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ74CMModAno ;
      private short ZZ75CMModMes ;
      private short ZZ640CMModSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCMModCod_Enabled ;
      private int edtCMModAno_Enabled ;
      private int edtCMModMes_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCMModSts_Enabled ;
      private int edtCMModUsuC_Enabled ;
      private int edtCMModFecC_Enabled ;
      private int edtCMModUsuM_Enabled ;
      private int edtCMModFecM_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string Z73CMModCod ;
      private string Z641CMModUsuC ;
      private string Z642CMModUsuM ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCMModCod_Internalname ;
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
      private string A73CMModCod ;
      private string edtCMModCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCMModAno_Internalname ;
      private string edtCMModAno_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCMModMes_Internalname ;
      private string edtCMModMes_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCMModSts_Internalname ;
      private string edtCMModSts_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCMModUsuC_Internalname ;
      private string A641CMModUsuC ;
      private string edtCMModUsuC_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCMModFecC_Internalname ;
      private string edtCMModFecC_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCMModUsuM_Internalname ;
      private string A642CMModUsuM ;
      private string edtCMModUsuM_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCMModFecM_Internalname ;
      private string edtCMModFecM_Jsonclick ;
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
      private string sMode7 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ73CMModCod ;
      private string ZZ641CMModUsuC ;
      private string ZZ642CMModUsuM ;
      private DateTime Z638CMModFecC ;
      private DateTime Z639CMModFecM ;
      private DateTime A638CMModFecC ;
      private DateTime A639CMModFecM ;
      private DateTime ZZ638CMModFecC ;
      private DateTime ZZ639CMModFecM ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001N4_A73CMModCod ;
      private short[] T001N4_A74CMModAno ;
      private short[] T001N4_A75CMModMes ;
      private short[] T001N4_A640CMModSts ;
      private string[] T001N4_A641CMModUsuC ;
      private DateTime[] T001N4_A638CMModFecC ;
      private string[] T001N4_A642CMModUsuM ;
      private DateTime[] T001N4_A639CMModFecM ;
      private string[] T001N5_A73CMModCod ;
      private short[] T001N5_A74CMModAno ;
      private short[] T001N5_A75CMModMes ;
      private string[] T001N3_A73CMModCod ;
      private short[] T001N3_A74CMModAno ;
      private short[] T001N3_A75CMModMes ;
      private short[] T001N3_A640CMModSts ;
      private string[] T001N3_A641CMModUsuC ;
      private DateTime[] T001N3_A638CMModFecC ;
      private string[] T001N3_A642CMModUsuM ;
      private DateTime[] T001N3_A639CMModFecM ;
      private string[] T001N6_A73CMModCod ;
      private short[] T001N6_A74CMModAno ;
      private short[] T001N6_A75CMModMes ;
      private string[] T001N7_A73CMModCod ;
      private short[] T001N7_A74CMModAno ;
      private short[] T001N7_A75CMModMes ;
      private string[] T001N2_A73CMModCod ;
      private short[] T001N2_A74CMModAno ;
      private short[] T001N2_A75CMModMes ;
      private short[] T001N2_A640CMModSts ;
      private string[] T001N2_A641CMModUsuC ;
      private DateTime[] T001N2_A638CMModFecC ;
      private string[] T001N2_A642CMModUsuM ;
      private DateTime[] T001N2_A639CMModFecM ;
      private string[] T001N11_A73CMModCod ;
      private short[] T001N11_A74CMModAno ;
      private short[] T001N11_A75CMModMes ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbcierremodulo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbcierremodulo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001N4;
        prmT001N4 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N5;
        prmT001N5 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N3;
        prmT001N3 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N6;
        prmT001N6 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N7;
        prmT001N7 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N2;
        prmT001N2 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N8;
        prmT001N8 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0) ,
        new ParDef("@CMModSts",GXType.Int16,1,0) ,
        new ParDef("@CMModUsuC",GXType.NChar,10,0) ,
        new ParDef("@CMModFecC",GXType.Date,8,0) ,
        new ParDef("@CMModUsuM",GXType.NChar,10,0) ,
        new ParDef("@CMModFecM",GXType.Date,8,0)
        };
        Object[] prmT001N9;
        prmT001N9 = new Object[] {
        new ParDef("@CMModSts",GXType.Int16,1,0) ,
        new ParDef("@CMModUsuC",GXType.NChar,10,0) ,
        new ParDef("@CMModFecC",GXType.Date,8,0) ,
        new ParDef("@CMModUsuM",GXType.NChar,10,0) ,
        new ParDef("@CMModFecM",GXType.Date,8,0) ,
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N10;
        prmT001N10 = new Object[] {
        new ParDef("@CMModCod",GXType.NChar,3,0) ,
        new ParDef("@CMModAno",GXType.Int16,4,0) ,
        new ParDef("@CMModMes",GXType.Int16,2,0)
        };
        Object[] prmT001N11;
        prmT001N11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001N2", "SELECT [CMModCod], [CMModAno], [CMModMes], [CMModSts], [CMModUsuC], [CMModFecC], [CMModUsuM], [CMModFecM] FROM [CBCIERREMODULO] WITH (UPDLOCK) WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001N3", "SELECT [CMModCod], [CMModAno], [CMModMes], [CMModSts], [CMModUsuC], [CMModFecC], [CMModUsuM], [CMModFecM] FROM [CBCIERREMODULO] WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes ",true, GxErrorMask.GX_NOMASK, false, this,prmT001N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001N4", "SELECT TM1.[CMModCod], TM1.[CMModAno], TM1.[CMModMes], TM1.[CMModSts], TM1.[CMModUsuC], TM1.[CMModFecC], TM1.[CMModUsuM], TM1.[CMModFecM] FROM [CBCIERREMODULO] TM1 WHERE TM1.[CMModCod] = @CMModCod and TM1.[CMModAno] = @CMModAno and TM1.[CMModMes] = @CMModMes ORDER BY TM1.[CMModCod], TM1.[CMModAno], TM1.[CMModMes]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001N5", "SELECT [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001N6", "SELECT TOP 1 [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] WHERE ( [CMModCod] > @CMModCod or [CMModCod] = @CMModCod and [CMModAno] > @CMModAno or [CMModAno] = @CMModAno and [CMModCod] = @CMModCod and [CMModMes] > @CMModMes) ORDER BY [CMModCod], [CMModAno], [CMModMes]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001N7", "SELECT TOP 1 [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] WHERE ( [CMModCod] < @CMModCod or [CMModCod] = @CMModCod and [CMModAno] < @CMModAno or [CMModAno] = @CMModAno and [CMModCod] = @CMModCod and [CMModMes] < @CMModMes) ORDER BY [CMModCod] DESC, [CMModAno] DESC, [CMModMes] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001N7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001N8", "INSERT INTO [CBCIERREMODULO]([CMModCod], [CMModAno], [CMModMes], [CMModSts], [CMModUsuC], [CMModFecC], [CMModUsuM], [CMModFecM]) VALUES(@CMModCod, @CMModAno, @CMModMes, @CMModSts, @CMModUsuC, @CMModFecC, @CMModUsuM, @CMModFecM)", GxErrorMask.GX_NOMASK,prmT001N8)
           ,new CursorDef("T001N9", "UPDATE [CBCIERREMODULO] SET [CMModSts]=@CMModSts, [CMModUsuC]=@CMModUsuC, [CMModFecC]=@CMModFecC, [CMModUsuM]=@CMModUsuM, [CMModFecM]=@CMModFecM  WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes", GxErrorMask.GX_NOMASK,prmT001N9)
           ,new CursorDef("T001N10", "DELETE FROM [CBCIERREMODULO]  WHERE [CMModCod] = @CMModCod AND [CMModAno] = @CMModAno AND [CMModMes] = @CMModMes", GxErrorMask.GX_NOMASK,prmT001N10)
           ,new CursorDef("T001N11", "SELECT [CMModCod], [CMModAno], [CMModMes] FROM [CBCIERREMODULO] ORDER BY [CMModCod], [CMModAno], [CMModMes]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001N11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
     }
  }

}

}
