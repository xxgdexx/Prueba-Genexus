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
   public class adespacho : GXDataArea
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
            A10ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A10ChoCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A1AYUCod = GetPar( "AYUCod");
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A1AYUCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A9UNTCod = (int)(NumberUtil.Val( GetPar( "UNTCod"), "."));
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A9UNTCod) ;
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
            Form.Meta.addItem("description", "Despacho", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public adespacho( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public adespacho( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ADESPACHO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Despacho", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDesCod_Internalname, StringUtil.RTrim( A8DesCod), StringUtil.RTrim( context.localUtil.Format( A8DesCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDesCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDesCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha Despacho", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDesFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDesFec_Internalname, context.localUtil.TToC( A875DesFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A875DesFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDesFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDesFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ADESPACHO.htm");
         GxWebStd.gx_bitmap( context, edtDesFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDesFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ADESPACHO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Chofer", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ChoCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtChoCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Ayudante", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUCod_Internalname, StringUtil.RTrim( A1AYUCod), StringUtil.RTrim( context.localUtil.Format( A1AYUCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Unidad", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUNTCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UNTCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUNTCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A9UNTCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A9UNTCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUNTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUNTCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Observaciones", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDesObs_Internalname, A876DesObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", 0, 1, edtDesObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Items", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDesDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A874DesDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtDesDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A874DesDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A874DesDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDesDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDesDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ADESPACHO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ADESPACHO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ADESPACHO.htm");
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
            Z8DesCod = cgiGet( "Z8DesCod");
            Z875DesFec = context.localUtil.CToT( cgiGet( "Z875DesFec"), 0);
            Z874DesDItem = (int)(context.localUtil.CToN( cgiGet( "Z874DesDItem"), ".", ","));
            Z10ChoCod = (int)(context.localUtil.CToN( cgiGet( "Z10ChoCod"), ".", ","));
            Z1AYUCod = cgiGet( "Z1AYUCod");
            Z9UNTCod = (int)(context.localUtil.CToN( cgiGet( "Z9UNTCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A8DesCod = cgiGet( edtDesCod_Internalname);
            AssignAttri("", false, "A8DesCod", A8DesCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtDesFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Despacho"}), 1, "DESFEC");
               AnyError = 1;
               GX_FocusControl = edtDesFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A875DesFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A875DesFec", context.localUtil.TToC( A875DesFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A875DesFec = context.localUtil.CToT( cgiGet( edtDesFec_Internalname));
               AssignAttri("", false, "A875DesFec", context.localUtil.TToC( A875DesFec, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHOCOD");
               AnyError = 1;
               GX_FocusControl = edtChoCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10ChoCod = 0;
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            }
            else
            {
               A10ChoCod = (int)(context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ","));
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            }
            A1AYUCod = cgiGet( edtAYUCod_Internalname);
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUNTCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUNTCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNTCOD");
               AnyError = 1;
               GX_FocusControl = edtUNTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A9UNTCod = 0;
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            }
            else
            {
               A9UNTCod = (int)(context.localUtil.CToN( cgiGet( edtUNTCod_Internalname), ".", ","));
               AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            }
            A876DesObs = cgiGet( edtDesObs_Internalname);
            AssignAttri("", false, "A876DesObs", A876DesObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDesDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDesDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DESDITEM");
               AnyError = 1;
               GX_FocusControl = edtDesDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A874DesDItem = 0;
               AssignAttri("", false, "A874DesDItem", StringUtil.LTrimStr( (decimal)(A874DesDItem), 6, 0));
            }
            else
            {
               A874DesDItem = (int)(context.localUtil.CToN( cgiGet( edtDesDItem_Internalname), ".", ","));
               AssignAttri("", false, "A874DesDItem", StringUtil.LTrimStr( (decimal)(A874DesDItem), 6, 0));
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
               A8DesCod = GetPar( "DesCod");
               AssignAttri("", false, "A8DesCod", A8DesCod);
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
               InitAll1236( ) ;
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
         DisableAttributes1236( ) ;
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

      protected void CONFIRM_120( )
      {
         BeforeValidate1236( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1236( ) ;
            }
            else
            {
               CheckExtendedTable1236( ) ;
               if ( AnyError == 0 )
               {
                  ZM1236( 3) ;
                  ZM1236( 4) ;
                  ZM1236( 5) ;
               }
               CloseExtendedTableCursors1236( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues120( ) ;
         }
      }

      protected void ResetCaption120( )
      {
      }

      protected void ZM1236( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z875DesFec = T00123_A875DesFec[0];
               Z874DesDItem = T00123_A874DesDItem[0];
               Z10ChoCod = T00123_A10ChoCod[0];
               Z1AYUCod = T00123_A1AYUCod[0];
               Z9UNTCod = T00123_A9UNTCod[0];
            }
            else
            {
               Z875DesFec = A875DesFec;
               Z874DesDItem = A874DesDItem;
               Z10ChoCod = A10ChoCod;
               Z1AYUCod = A1AYUCod;
               Z9UNTCod = A9UNTCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z8DesCod = A8DesCod;
            Z875DesFec = A875DesFec;
            Z876DesObs = A876DesObs;
            Z874DesDItem = A874DesDItem;
            Z10ChoCod = A10ChoCod;
            Z1AYUCod = A1AYUCod;
            Z9UNTCod = A9UNTCod;
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

      protected void Load1236( )
      {
         /* Using cursor T00127 */
         pr_default.execute(5, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound36 = 1;
            A875DesFec = T00127_A875DesFec[0];
            AssignAttri("", false, "A875DesFec", context.localUtil.TToC( A875DesFec, 8, 5, 0, 3, "/", ":", " "));
            A876DesObs = T00127_A876DesObs[0];
            AssignAttri("", false, "A876DesObs", A876DesObs);
            A874DesDItem = T00127_A874DesDItem[0];
            AssignAttri("", false, "A874DesDItem", StringUtil.LTrimStr( (decimal)(A874DesDItem), 6, 0));
            A10ChoCod = T00127_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            A1AYUCod = T00127_A1AYUCod[0];
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            A9UNTCod = T00127_A9UNTCod[0];
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            ZM1236( -2) ;
         }
         pr_default.close(5);
         OnLoadActions1236( ) ;
      }

      protected void OnLoadActions1236( )
      {
      }

      protected void CheckExtendedTable1236( )
      {
         nIsDirty_36 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A875DesFec) || ( A875DesFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Despacho fuera de rango", "OutOfRange", 1, "DESFEC");
            AnyError = 1;
            GX_FocusControl = edtDesFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00124 */
         pr_default.execute(2, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Transportistas'.", "ForeignKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00125 */
         pr_default.execute(3, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Ayudantes'.", "ForeignKeyNotFound", 1, "AYUCOD");
            AnyError = 1;
            GX_FocusControl = edtAYUCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00126 */
         pr_default.execute(4, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidades Transportes'.", "ForeignKeyNotFound", 1, "UNTCOD");
            AnyError = 1;
            GX_FocusControl = edtUNTCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1236( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A10ChoCod )
      {
         /* Using cursor T00128 */
         pr_default.execute(6, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Transportistas'.", "ForeignKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_4( string A1AYUCod )
      {
         /* Using cursor T00129 */
         pr_default.execute(7, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Ayudantes'.", "ForeignKeyNotFound", 1, "AYUCOD");
            AnyError = 1;
            GX_FocusControl = edtAYUCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( int A9UNTCod )
      {
         /* Using cursor T001210 */
         pr_default.execute(8, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidades Transportes'.", "ForeignKeyNotFound", 1, "UNTCOD");
            AnyError = 1;
            GX_FocusControl = edtUNTCod_Internalname;
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

      protected void GetKey1236( )
      {
         /* Using cursor T001211 */
         pr_default.execute(9, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00123 */
         pr_default.execute(1, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1236( 2) ;
            RcdFound36 = 1;
            A8DesCod = T00123_A8DesCod[0];
            AssignAttri("", false, "A8DesCod", A8DesCod);
            A875DesFec = T00123_A875DesFec[0];
            AssignAttri("", false, "A875DesFec", context.localUtil.TToC( A875DesFec, 8, 5, 0, 3, "/", ":", " "));
            A876DesObs = T00123_A876DesObs[0];
            AssignAttri("", false, "A876DesObs", A876DesObs);
            A874DesDItem = T00123_A874DesDItem[0];
            AssignAttri("", false, "A874DesDItem", StringUtil.LTrimStr( (decimal)(A874DesDItem), 6, 0));
            A10ChoCod = T00123_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            A1AYUCod = T00123_A1AYUCod[0];
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            A9UNTCod = T00123_A9UNTCod[0];
            AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
            Z8DesCod = A8DesCod;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1236( ) ;
            if ( AnyError == 1 )
            {
               RcdFound36 = 0;
               InitializeNonKey1236( ) ;
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey1236( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1236( ) ;
         if ( RcdFound36 == 0 )
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
         RcdFound36 = 0;
         /* Using cursor T001212 */
         pr_default.execute(10, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T001212_A8DesCod[0], A8DesCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T001212_A8DesCod[0], A8DesCod) > 0 ) ) )
            {
               A8DesCod = T001212_A8DesCod[0];
               AssignAttri("", false, "A8DesCod", A8DesCod);
               RcdFound36 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound36 = 0;
         /* Using cursor T001213 */
         pr_default.execute(11, new Object[] {A8DesCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T001213_A8DesCod[0], A8DesCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T001213_A8DesCod[0], A8DesCod) < 0 ) ) )
            {
               A8DesCod = T001213_A8DesCod[0];
               AssignAttri("", false, "A8DesCod", A8DesCod);
               RcdFound36 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1236( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1236( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound36 == 1 )
            {
               if ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 )
               {
                  A8DesCod = Z8DesCod;
                  AssignAttri("", false, "A8DesCod", A8DesCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DESCOD");
                  AnyError = 1;
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1236( ) ;
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtDesCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1236( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DESCOD");
                     AnyError = 1;
                     GX_FocusControl = edtDesCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtDesCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1236( ) ;
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
         if ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 )
         {
            A8DesCod = Z8DesCod;
            AssignAttri("", false, "A8DesCod", A8DesCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDesCod_Internalname;
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
         GetKey1236( ) ;
         if ( RcdFound36 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "DESCOD");
               AnyError = 1;
               GX_FocusControl = edtDesCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 )
            {
               A8DesCod = Z8DesCod;
               AssignAttri("", false, "A8DesCod", A8DesCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "DESCOD");
               AnyError = 1;
               GX_FocusControl = edtDesCod_Internalname;
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
            if ( StringUtil.StrCmp(A8DesCod, Z8DesCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DESCOD");
                  AnyError = 1;
                  GX_FocusControl = edtDesCod_Internalname;
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
         context.RollbackDataStores("adespacho",pr_default);
         GX_FocusControl = edtDesFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_120( ) ;
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
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "DESCOD");
            AnyError = 1;
            GX_FocusControl = edtDesCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtDesFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1236( ) ;
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDesFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1236( ) ;
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
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDesFec_Internalname;
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
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDesFec_Internalname;
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
         ScanStart1236( ) ;
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound36 != 0 )
            {
               ScanNext1236( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDesFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1236( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1236( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00122 */
            pr_default.execute(0, new Object[] {A8DesCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ADESPACHO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z875DesFec != T00122_A875DesFec[0] ) || ( Z874DesDItem != T00122_A874DesDItem[0] ) || ( Z10ChoCod != T00122_A10ChoCod[0] ) || ( StringUtil.StrCmp(Z1AYUCod, T00122_A1AYUCod[0]) != 0 ) || ( Z9UNTCod != T00122_A9UNTCod[0] ) )
            {
               if ( Z875DesFec != T00122_A875DesFec[0] )
               {
                  GXUtil.WriteLog("adespacho:[seudo value changed for attri]"+"DesFec");
                  GXUtil.WriteLogRaw("Old: ",Z875DesFec);
                  GXUtil.WriteLogRaw("Current: ",T00122_A875DesFec[0]);
               }
               if ( Z874DesDItem != T00122_A874DesDItem[0] )
               {
                  GXUtil.WriteLog("adespacho:[seudo value changed for attri]"+"DesDItem");
                  GXUtil.WriteLogRaw("Old: ",Z874DesDItem);
                  GXUtil.WriteLogRaw("Current: ",T00122_A874DesDItem[0]);
               }
               if ( Z10ChoCod != T00122_A10ChoCod[0] )
               {
                  GXUtil.WriteLog("adespacho:[seudo value changed for attri]"+"ChoCod");
                  GXUtil.WriteLogRaw("Old: ",Z10ChoCod);
                  GXUtil.WriteLogRaw("Current: ",T00122_A10ChoCod[0]);
               }
               if ( StringUtil.StrCmp(Z1AYUCod, T00122_A1AYUCod[0]) != 0 )
               {
                  GXUtil.WriteLog("adespacho:[seudo value changed for attri]"+"AYUCod");
                  GXUtil.WriteLogRaw("Old: ",Z1AYUCod);
                  GXUtil.WriteLogRaw("Current: ",T00122_A1AYUCod[0]);
               }
               if ( Z9UNTCod != T00122_A9UNTCod[0] )
               {
                  GXUtil.WriteLog("adespacho:[seudo value changed for attri]"+"UNTCod");
                  GXUtil.WriteLogRaw("Old: ",Z9UNTCod);
                  GXUtil.WriteLogRaw("Current: ",T00122_A9UNTCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ADESPACHO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1236( )
      {
         BeforeValidate1236( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1236( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1236( 0) ;
            CheckOptimisticConcurrency1236( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1236( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1236( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001214 */
                     pr_default.execute(12, new Object[] {A8DesCod, A875DesFec, A876DesObs, A874DesDItem, A10ChoCod, A1AYUCod, A9UNTCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("ADESPACHO");
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
                           ResetCaption120( ) ;
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
               Load1236( ) ;
            }
            EndLevel1236( ) ;
         }
         CloseExtendedTableCursors1236( ) ;
      }

      protected void Update1236( )
      {
         BeforeValidate1236( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1236( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1236( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1236( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1236( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001215 */
                     pr_default.execute(13, new Object[] {A875DesFec, A876DesObs, A874DesDItem, A10ChoCod, A1AYUCod, A9UNTCod, A8DesCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("ADESPACHO");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ADESPACHO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1236( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption120( ) ;
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
            EndLevel1236( ) ;
         }
         CloseExtendedTableCursors1236( ) ;
      }

      protected void DeferredUpdate1236( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1236( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1236( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1236( ) ;
            AfterConfirm1236( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1236( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001216 */
                  pr_default.execute(14, new Object[] {A8DesCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("ADESPACHO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound36 == 0 )
                        {
                           InitAll1236( ) ;
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
                        ResetCaption120( ) ;
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
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1236( ) ;
         Gx_mode = sMode36;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1236( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001217 */
            pr_default.execute(15, new Object[] {A8DesCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Despacho Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel1236( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1236( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("adespacho",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues120( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("adespacho",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1236( )
      {
         /* Using cursor T001218 */
         pr_default.execute(16);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound36 = 1;
            A8DesCod = T001218_A8DesCod[0];
            AssignAttri("", false, "A8DesCod", A8DesCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1236( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound36 = 1;
            A8DesCod = T001218_A8DesCod[0];
            AssignAttri("", false, "A8DesCod", A8DesCod);
         }
      }

      protected void ScanEnd1236( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1236( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1236( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1236( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1236( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1236( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1236( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1236( )
      {
         edtDesCod_Enabled = 0;
         AssignProp("", false, edtDesCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesCod_Enabled), 5, 0), true);
         edtDesFec_Enabled = 0;
         AssignProp("", false, edtDesFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesFec_Enabled), 5, 0), true);
         edtChoCod_Enabled = 0;
         AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
         edtAYUCod_Enabled = 0;
         AssignProp("", false, edtAYUCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUCod_Enabled), 5, 0), true);
         edtUNTCod_Enabled = 0;
         AssignProp("", false, edtUNTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUNTCod_Enabled), 5, 0), true);
         edtDesObs_Enabled = 0;
         AssignProp("", false, edtDesObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesObs_Enabled), 5, 0), true);
         edtDesDItem_Enabled = 0;
         AssignProp("", false, edtDesDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDesDItem_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1236( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues120( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443479", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("adespacho.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z8DesCod", StringUtil.RTrim( Z8DesCod));
         GxWebStd.gx_hidden_field( context, "Z875DesFec", context.localUtil.TToC( Z875DesFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z874DesDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z874DesDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1AYUCod", StringUtil.RTrim( Z1AYUCod));
         GxWebStd.gx_hidden_field( context, "Z9UNTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UNTCod), 6, 0, ".", "")));
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
         return formatLink("adespacho.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ADESPACHO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Despacho" ;
      }

      protected void InitializeNonKey1236( )
      {
         A875DesFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A875DesFec", context.localUtil.TToC( A875DesFec, 8, 5, 0, 3, "/", ":", " "));
         A10ChoCod = 0;
         AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         A1AYUCod = "";
         AssignAttri("", false, "A1AYUCod", A1AYUCod);
         A9UNTCod = 0;
         AssignAttri("", false, "A9UNTCod", StringUtil.LTrimStr( (decimal)(A9UNTCod), 6, 0));
         A876DesObs = "";
         AssignAttri("", false, "A876DesObs", A876DesObs);
         A874DesDItem = 0;
         AssignAttri("", false, "A874DesDItem", StringUtil.LTrimStr( (decimal)(A874DesDItem), 6, 0));
         Z875DesFec = (DateTime)(DateTime.MinValue);
         Z874DesDItem = 0;
         Z10ChoCod = 0;
         Z1AYUCod = "";
         Z9UNTCod = 0;
      }

      protected void InitAll1236( )
      {
         A8DesCod = "";
         AssignAttri("", false, "A8DesCod", A8DesCod);
         InitializeNonKey1236( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443485", true, true);
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
         context.AddJavascriptSource("adespacho.js", "?202281811443486", false, true);
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
         edtDesCod_Internalname = "DESCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtDesFec_Internalname = "DESFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtChoCod_Internalname = "CHOCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAYUCod_Internalname = "AYUCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtUNTCod_Internalname = "UNTCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtDesObs_Internalname = "DESOBS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtDesDItem_Internalname = "DESDITEM";
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
         Form.Caption = "Despacho";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDesDItem_Jsonclick = "";
         edtDesDItem_Enabled = 1;
         edtDesObs_Enabled = 1;
         edtUNTCod_Jsonclick = "";
         edtUNTCod_Enabled = 1;
         edtAYUCod_Jsonclick = "";
         edtAYUCod_Enabled = 1;
         edtChoCod_Jsonclick = "";
         edtChoCod_Enabled = 1;
         edtDesFec_Jsonclick = "";
         edtDesFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtDesCod_Jsonclick = "";
         edtDesCod_Enabled = 1;
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
         GX_FocusControl = edtDesFec_Internalname;
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

      public void Valid_Descod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A875DesFec", context.localUtil.TToC( A875DesFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ChoCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1AYUCod", StringUtil.RTrim( A1AYUCod));
         AssignAttri("", false, "A9UNTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UNTCod), 6, 0, ".", "")));
         AssignAttri("", false, "A876DesObs", A876DesObs);
         AssignAttri("", false, "A874DesDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A874DesDItem), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z8DesCod", StringUtil.RTrim( Z8DesCod));
         GxWebStd.gx_hidden_field( context, "Z875DesFec", context.localUtil.TToC( Z875DesFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1AYUCod", StringUtil.RTrim( Z1AYUCod));
         GxWebStd.gx_hidden_field( context, "Z9UNTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UNTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z876DesObs", Z876DesObs);
         GxWebStd.gx_hidden_field( context, "Z874DesDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z874DesDItem), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Chocod( )
      {
         /* Using cursor T001219 */
         pr_default.execute(17, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Transportistas'.", "ForeignKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ayucod( )
      {
         /* Using cursor T001220 */
         pr_default.execute(18, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Ayudantes'.", "ForeignKeyNotFound", 1, "AYUCOD");
            AnyError = 1;
            GX_FocusControl = edtAYUCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Untcod( )
      {
         /* Using cursor T001221 */
         pr_default.execute(19, new Object[] {A9UNTCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidades Transportes'.", "ForeignKeyNotFound", 1, "UNTCOD");
            AnyError = 1;
            GX_FocusControl = edtUNTCod_Internalname;
         }
         pr_default.close(19);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_DESCOD","{handler:'Valid_Descod',iparms:[{av:'A8DesCod',fld:'DESCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DESCOD",",oparms:[{av:'A875DesFec',fld:'DESFEC',pic:'99/99/99 99:99'},{av:'A10ChoCod',fld:'CHOCOD',pic:'ZZZZZ9'},{av:'A1AYUCod',fld:'AYUCOD',pic:''},{av:'A9UNTCod',fld:'UNTCOD',pic:'ZZZZZ9'},{av:'A876DesObs',fld:'DESOBS',pic:''},{av:'A874DesDItem',fld:'DESDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z8DesCod'},{av:'Z875DesFec'},{av:'Z10ChoCod'},{av:'Z1AYUCod'},{av:'Z9UNTCod'},{av:'Z876DesObs'},{av:'Z874DesDItem'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_DESFEC","{handler:'Valid_Desfec',iparms:[]");
         setEventMetadata("VALID_DESFEC",",oparms:[]}");
         setEventMetadata("VALID_CHOCOD","{handler:'Valid_Chocod',iparms:[{av:'A10ChoCod',fld:'CHOCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CHOCOD",",oparms:[]}");
         setEventMetadata("VALID_AYUCOD","{handler:'Valid_Ayucod',iparms:[{av:'A1AYUCod',fld:'AYUCOD',pic:''}]");
         setEventMetadata("VALID_AYUCOD",",oparms:[]}");
         setEventMetadata("VALID_UNTCOD","{handler:'Valid_Untcod',iparms:[{av:'A9UNTCod',fld:'UNTCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_UNTCOD",",oparms:[]}");
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
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z8DesCod = "";
         Z875DesFec = (DateTime)(DateTime.MinValue);
         Z1AYUCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A1AYUCod = "";
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
         A8DesCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A875DesFec = (DateTime)(DateTime.MinValue);
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A876DesObs = "";
         lblTextblock7_Jsonclick = "";
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
         Z876DesObs = "";
         T00127_A8DesCod = new string[] {""} ;
         T00127_A875DesFec = new DateTime[] {DateTime.MinValue} ;
         T00127_A876DesObs = new string[] {""} ;
         T00127_A874DesDItem = new int[1] ;
         T00127_A10ChoCod = new int[1] ;
         T00127_A1AYUCod = new string[] {""} ;
         T00127_A9UNTCod = new int[1] ;
         T00124_A10ChoCod = new int[1] ;
         T00125_A1AYUCod = new string[] {""} ;
         T00126_A9UNTCod = new int[1] ;
         T00128_A10ChoCod = new int[1] ;
         T00129_A1AYUCod = new string[] {""} ;
         T001210_A9UNTCod = new int[1] ;
         T001211_A8DesCod = new string[] {""} ;
         T00123_A8DesCod = new string[] {""} ;
         T00123_A875DesFec = new DateTime[] {DateTime.MinValue} ;
         T00123_A876DesObs = new string[] {""} ;
         T00123_A874DesDItem = new int[1] ;
         T00123_A10ChoCod = new int[1] ;
         T00123_A1AYUCod = new string[] {""} ;
         T00123_A9UNTCod = new int[1] ;
         sMode36 = "";
         T001212_A8DesCod = new string[] {""} ;
         T001213_A8DesCod = new string[] {""} ;
         T00122_A8DesCod = new string[] {""} ;
         T00122_A875DesFec = new DateTime[] {DateTime.MinValue} ;
         T00122_A876DesObs = new string[] {""} ;
         T00122_A874DesDItem = new int[1] ;
         T00122_A10ChoCod = new int[1] ;
         T00122_A1AYUCod = new string[] {""} ;
         T00122_A9UNTCod = new int[1] ;
         T001217_A8DesCod = new string[] {""} ;
         T001217_A11DesTipGuia = new string[] {""} ;
         T001217_A12DesGuia = new string[] {""} ;
         T001218_A8DesCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ8DesCod = "";
         ZZ875DesFec = (DateTime)(DateTime.MinValue);
         ZZ1AYUCod = "";
         ZZ876DesObs = "";
         T001219_A10ChoCod = new int[1] ;
         T001220_A1AYUCod = new string[] {""} ;
         T001221_A9UNTCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.adespacho__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.adespacho__default(),
            new Object[][] {
                new Object[] {
               T00122_A8DesCod, T00122_A875DesFec, T00122_A876DesObs, T00122_A874DesDItem, T00122_A10ChoCod, T00122_A1AYUCod, T00122_A9UNTCod
               }
               , new Object[] {
               T00123_A8DesCod, T00123_A875DesFec, T00123_A876DesObs, T00123_A874DesDItem, T00123_A10ChoCod, T00123_A1AYUCod, T00123_A9UNTCod
               }
               , new Object[] {
               T00124_A10ChoCod
               }
               , new Object[] {
               T00125_A1AYUCod
               }
               , new Object[] {
               T00126_A9UNTCod
               }
               , new Object[] {
               T00127_A8DesCod, T00127_A875DesFec, T00127_A876DesObs, T00127_A874DesDItem, T00127_A10ChoCod, T00127_A1AYUCod, T00127_A9UNTCod
               }
               , new Object[] {
               T00128_A10ChoCod
               }
               , new Object[] {
               T00129_A1AYUCod
               }
               , new Object[] {
               T001210_A9UNTCod
               }
               , new Object[] {
               T001211_A8DesCod
               }
               , new Object[] {
               T001212_A8DesCod
               }
               , new Object[] {
               T001213_A8DesCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001217_A8DesCod, T001217_A11DesTipGuia, T001217_A12DesGuia
               }
               , new Object[] {
               T001218_A8DesCod
               }
               , new Object[] {
               T001219_A10ChoCod
               }
               , new Object[] {
               T001220_A1AYUCod
               }
               , new Object[] {
               T001221_A9UNTCod
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
      private short GX_JID ;
      private short RcdFound36 ;
      private short nIsDirty_36 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z874DesDItem ;
      private int Z10ChoCod ;
      private int Z9UNTCod ;
      private int A10ChoCod ;
      private int A9UNTCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtDesCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtDesFec_Enabled ;
      private int edtChoCod_Enabled ;
      private int edtAYUCod_Enabled ;
      private int edtUNTCod_Enabled ;
      private int edtDesObs_Enabled ;
      private int A874DesDItem ;
      private int edtDesDItem_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ10ChoCod ;
      private int ZZ9UNTCod ;
      private int ZZ874DesDItem ;
      private string sPrefix ;
      private string Z8DesCod ;
      private string Z1AYUCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1AYUCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDesCod_Internalname ;
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
      private string A8DesCod ;
      private string edtDesCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtDesFec_Internalname ;
      private string edtDesFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtChoCod_Internalname ;
      private string edtChoCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAYUCod_Internalname ;
      private string edtAYUCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtUNTCod_Internalname ;
      private string edtUNTCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtDesObs_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtDesDItem_Internalname ;
      private string edtDesDItem_Jsonclick ;
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
      private string sMode36 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ8DesCod ;
      private string ZZ1AYUCod ;
      private DateTime Z875DesFec ;
      private DateTime A875DesFec ;
      private DateTime ZZ875DesFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string A876DesObs ;
      private string Z876DesObs ;
      private string ZZ876DesObs ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00127_A8DesCod ;
      private DateTime[] T00127_A875DesFec ;
      private string[] T00127_A876DesObs ;
      private int[] T00127_A874DesDItem ;
      private int[] T00127_A10ChoCod ;
      private string[] T00127_A1AYUCod ;
      private int[] T00127_A9UNTCod ;
      private int[] T00124_A10ChoCod ;
      private string[] T00125_A1AYUCod ;
      private int[] T00126_A9UNTCod ;
      private int[] T00128_A10ChoCod ;
      private string[] T00129_A1AYUCod ;
      private int[] T001210_A9UNTCod ;
      private string[] T001211_A8DesCod ;
      private string[] T00123_A8DesCod ;
      private DateTime[] T00123_A875DesFec ;
      private string[] T00123_A876DesObs ;
      private int[] T00123_A874DesDItem ;
      private int[] T00123_A10ChoCod ;
      private string[] T00123_A1AYUCod ;
      private int[] T00123_A9UNTCod ;
      private string[] T001212_A8DesCod ;
      private string[] T001213_A8DesCod ;
      private string[] T00122_A8DesCod ;
      private DateTime[] T00122_A875DesFec ;
      private string[] T00122_A876DesObs ;
      private int[] T00122_A874DesDItem ;
      private int[] T00122_A10ChoCod ;
      private string[] T00122_A1AYUCod ;
      private int[] T00122_A9UNTCod ;
      private string[] T001217_A8DesCod ;
      private string[] T001217_A11DesTipGuia ;
      private string[] T001217_A12DesGuia ;
      private string[] T001218_A8DesCod ;
      private int[] T001219_A10ChoCod ;
      private string[] T001220_A1AYUCod ;
      private int[] T001221_A9UNTCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class adespacho__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class adespacho__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00127;
        prmT00127 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT00124;
        prmT00124 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00125;
        prmT00125 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00126;
        prmT00126 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT00128;
        prmT00128 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT00129;
        prmT00129 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT001210;
        prmT001210 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001211;
        prmT001211 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT00123;
        prmT00123 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001212;
        prmT001212 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001213;
        prmT001213 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT00122;
        prmT00122 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001214;
        prmT001214 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0) ,
        new ParDef("@DesFec",GXType.DateTime,8,5) ,
        new ParDef("@DesObs",GXType.NVarChar,500,0) ,
        new ParDef("@DesDItem",GXType.Int32,6,0) ,
        new ParDef("@ChoCod",GXType.Int32,6,0) ,
        new ParDef("@AYUCod",GXType.NChar,15,0) ,
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        Object[] prmT001215;
        prmT001215 = new Object[] {
        new ParDef("@DesFec",GXType.DateTime,8,5) ,
        new ParDef("@DesObs",GXType.NVarChar,500,0) ,
        new ParDef("@DesDItem",GXType.Int32,6,0) ,
        new ParDef("@ChoCod",GXType.Int32,6,0) ,
        new ParDef("@AYUCod",GXType.NChar,15,0) ,
        new ParDef("@UNTCod",GXType.Int32,6,0) ,
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001216;
        prmT001216 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001217;
        prmT001217 = new Object[] {
        new ParDef("@DesCod",GXType.NChar,10,0)
        };
        Object[] prmT001218;
        prmT001218 = new Object[] {
        };
        Object[] prmT001219;
        prmT001219 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT001220;
        prmT001220 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT001221;
        prmT001221 = new Object[] {
        new ParDef("@UNTCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00122", "SELECT [DesCod], [DesFec], [DesObs], [DesDItem], [ChoCod], [AYUCod], [UNTCod] FROM [ADESPACHO] WITH (UPDLOCK) WHERE [DesCod] = @DesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00123", "SELECT [DesCod], [DesFec], [DesObs], [DesDItem], [ChoCod], [AYUCod], [UNTCod] FROM [ADESPACHO] WHERE [DesCod] = @DesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00123,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00124", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00124,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00125", "SELECT [AYUCod] FROM [AAYUDANTES] WHERE [AYUCod] = @AYUCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00125,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00126", "SELECT [UNTCod] FROM [AUNITRANSP] WHERE [UNTCod] = @UNTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00126,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00127", "SELECT TM1.[DesCod], TM1.[DesFec], TM1.[DesObs], TM1.[DesDItem], TM1.[ChoCod], TM1.[AYUCod], TM1.[UNTCod] FROM [ADESPACHO] TM1 WHERE TM1.[DesCod] = @DesCod ORDER BY TM1.[DesCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00127,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00128", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00128,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00129", "SELECT [AYUCod] FROM [AAYUDANTES] WHERE [AYUCod] = @AYUCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00129,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001210", "SELECT [UNTCod] FROM [AUNITRANSP] WHERE [UNTCod] = @UNTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001210,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001211", "SELECT [DesCod] FROM [ADESPACHO] WHERE [DesCod] = @DesCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001211,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001212", "SELECT TOP 1 [DesCod] FROM [ADESPACHO] WHERE ( [DesCod] > @DesCod) ORDER BY [DesCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001212,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001213", "SELECT TOP 1 [DesCod] FROM [ADESPACHO] WHERE ( [DesCod] < @DesCod) ORDER BY [DesCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001213,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001214", "INSERT INTO [ADESPACHO]([DesCod], [DesFec], [DesObs], [DesDItem], [ChoCod], [AYUCod], [UNTCod]) VALUES(@DesCod, @DesFec, @DesObs, @DesDItem, @ChoCod, @AYUCod, @UNTCod)", GxErrorMask.GX_NOMASK,prmT001214)
           ,new CursorDef("T001215", "UPDATE [ADESPACHO] SET [DesFec]=@DesFec, [DesObs]=@DesObs, [DesDItem]=@DesDItem, [ChoCod]=@ChoCod, [AYUCod]=@AYUCod, [UNTCod]=@UNTCod  WHERE [DesCod] = @DesCod", GxErrorMask.GX_NOMASK,prmT001215)
           ,new CursorDef("T001216", "DELETE FROM [ADESPACHO]  WHERE [DesCod] = @DesCod", GxErrorMask.GX_NOMASK,prmT001216)
           ,new CursorDef("T001217", "SELECT TOP 1 [DesCod], [DesTipGuia], [DesGuia] FROM [ADESPACHODET] WHERE [DesCod] = @DesCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001217,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001218", "SELECT [DesCod] FROM [ADESPACHO] ORDER BY [DesCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001218,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001219", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001219,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001220", "SELECT [AYUCod] FROM [AAYUDANTES] WHERE [AYUCod] = @AYUCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001220,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001221", "SELECT [UNTCod] FROM [AUNITRANSP] WHERE [UNTCod] = @UNTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001221,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
