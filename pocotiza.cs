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
   public class pocotiza : GXDataArea
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
            A317ProCotProdCod = GetPar( "ProCotProdCod");
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A317ProCotProdCod) ;
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
            Form.Meta.addItem("description", "POCOTIZA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public pocotiza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pocotiza( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POCOTIZA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo de Producto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotProdCod_Internalname, StringUtil.RTrim( A317ProCotProdCod), StringUtil.RTrim( context.localUtil.Format( A317ProCotProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Producto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProCotProdDsc_Internalname, StringUtil.RTrim( A1666ProCotProdDsc), StringUtil.RTrim( context.localUtil.Format( A1666ProCotProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cantidad Bach", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotBach_Internalname, StringUtil.LTrim( StringUtil.NToC( A1657ProCotBach, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCotBach_Enabled!=0) ? context.localUtil.Format( A1657ProCotBach, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1657ProCotBach, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotBach_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotBach_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha Cotizada", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProCotFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProCotFec_Internalname, context.localUtil.Format(A1664ProCotFec, "99/99/99"), context.localUtil.Format( A1664ProCotFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POCOTIZA.htm");
         GxWebStd.gx_bitmap( context, edtProCotFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProCotFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_POCOTIZA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Observaciones", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProCotObs_Internalname, A1665ProCotObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", 0, 1, edtProCotObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Total Item", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1670ProCotTItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtProCotTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1670ProCotTItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1670ProCotTItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotTItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "% Utilidad", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotUtilidad_Internalname, StringUtil.LTrim( StringUtil.NToC( A1671ProCotUtilidad, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCotUtilidad_Enabled!=0) ? context.localUtil.Format( A1671ProCotUtilidad, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1671ProCotUtilidad, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotUtilidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotUtilidad_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "% Comisión", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_POCOTIZA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCotComision_Internalname, StringUtil.LTrim( StringUtil.NToC( A1659ProCotComision, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCotComision_Enabled!=0) ? context.localUtil.Format( A1659ProCotComision, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1659ProCotComision, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCotComision_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCotComision_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POCOTIZA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POCOTIZA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_POCOTIZA.htm");
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
            Z317ProCotProdCod = cgiGet( "Z317ProCotProdCod");
            Z1657ProCotBach = context.localUtil.CToN( cgiGet( "Z1657ProCotBach"), ".", ",");
            Z1664ProCotFec = context.localUtil.CToD( cgiGet( "Z1664ProCotFec"), 0);
            Z1670ProCotTItem = (int)(context.localUtil.CToN( cgiGet( "Z1670ProCotTItem"), ".", ","));
            Z1671ProCotUtilidad = context.localUtil.CToN( cgiGet( "Z1671ProCotUtilidad"), ".", ",");
            Z1659ProCotComision = context.localUtil.CToN( cgiGet( "Z1659ProCotComision"), ".", ",");
            Z1667ProCotRend1 = context.localUtil.CToN( cgiGet( "Z1667ProCotRend1"), ".", ",");
            Z1668ProCotRend2 = context.localUtil.CToN( cgiGet( "Z1668ProCotRend2"), ".", ",");
            A1667ProCotRend1 = context.localUtil.CToN( cgiGet( "Z1667ProCotRend1"), ".", ",");
            A1668ProCotRend2 = context.localUtil.CToN( cgiGet( "Z1668ProCotRend2"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1667ProCotRend1 = context.localUtil.CToN( cgiGet( "PROCOTREND1"), ".", ",");
            A1668ProCotRend2 = context.localUtil.CToN( cgiGet( "PROCOTREND2"), ".", ",");
            /* Read variables values. */
            A317ProCotProdCod = StringUtil.Upper( cgiGet( edtProCotProdCod_Internalname));
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            A1666ProCotProdDsc = cgiGet( edtProCotProdDsc_Internalname);
            AssignAttri("", false, "A1666ProCotProdDsc", A1666ProCotProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotBach_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotBach_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTBACH");
               AnyError = 1;
               GX_FocusControl = edtProCotBach_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1657ProCotBach = 0;
               AssignAttri("", false, "A1657ProCotBach", StringUtil.LTrimStr( A1657ProCotBach, 15, 2));
            }
            else
            {
               A1657ProCotBach = context.localUtil.CToN( cgiGet( edtProCotBach_Internalname), ".", ",");
               AssignAttri("", false, "A1657ProCotBach", StringUtil.LTrimStr( A1657ProCotBach, 15, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtProCotFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Cotizada"}), 1, "PROCOTFEC");
               AnyError = 1;
               GX_FocusControl = edtProCotFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1664ProCotFec = DateTime.MinValue;
               AssignAttri("", false, "A1664ProCotFec", context.localUtil.Format(A1664ProCotFec, "99/99/99"));
            }
            else
            {
               A1664ProCotFec = context.localUtil.CToD( cgiGet( edtProCotFec_Internalname), 2);
               AssignAttri("", false, "A1664ProCotFec", context.localUtil.Format(A1664ProCotFec, "99/99/99"));
            }
            A1665ProCotObs = cgiGet( edtProCotObs_Internalname);
            AssignAttri("", false, "A1665ProCotObs", A1665ProCotObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotTItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTTITEM");
               AnyError = 1;
               GX_FocusControl = edtProCotTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1670ProCotTItem = 0;
               AssignAttri("", false, "A1670ProCotTItem", StringUtil.LTrimStr( (decimal)(A1670ProCotTItem), 6, 0));
            }
            else
            {
               A1670ProCotTItem = (int)(context.localUtil.CToN( cgiGet( edtProCotTItem_Internalname), ".", ","));
               AssignAttri("", false, "A1670ProCotTItem", StringUtil.LTrimStr( (decimal)(A1670ProCotTItem), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotUtilidad_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotUtilidad_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTUTILIDAD");
               AnyError = 1;
               GX_FocusControl = edtProCotUtilidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1671ProCotUtilidad = 0;
               AssignAttri("", false, "A1671ProCotUtilidad", StringUtil.LTrimStr( A1671ProCotUtilidad, 15, 2));
            }
            else
            {
               A1671ProCotUtilidad = context.localUtil.CToN( cgiGet( edtProCotUtilidad_Internalname), ".", ",");
               AssignAttri("", false, "A1671ProCotUtilidad", StringUtil.LTrimStr( A1671ProCotUtilidad, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCotComision_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCotComision_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOTCOMISION");
               AnyError = 1;
               GX_FocusControl = edtProCotComision_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1659ProCotComision = 0;
               AssignAttri("", false, "A1659ProCotComision", StringUtil.LTrimStr( A1659ProCotComision, 15, 2));
            }
            else
            {
               A1659ProCotComision = context.localUtil.CToN( cgiGet( edtProCotComision_Internalname), ".", ",");
               AssignAttri("", false, "A1659ProCotComision", StringUtil.LTrimStr( A1659ProCotComision, 15, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"POCOTIZA");
            forbiddenHiddens.Add("ProCotRend1", context.localUtil.Format( A1667ProCotRend1, "ZZZZZZ,ZZZ,ZZ9.99"));
            forbiddenHiddens.Add("ProCotRend2", context.localUtil.Format( A1668ProCotRend2, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("pocotiza:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A317ProCotProdCod = GetPar( "ProCotProdCod");
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
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
               InitAll44143( ) ;
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
         DisableAttributes44143( ) ;
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

      protected void CONFIRM_440( )
      {
         BeforeValidate44143( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls44143( ) ;
            }
            else
            {
               CheckExtendedTable44143( ) ;
               if ( AnyError == 0 )
               {
                  ZM44143( 3) ;
               }
               CloseExtendedTableCursors44143( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues440( ) ;
         }
      }

      protected void ResetCaption440( )
      {
      }

      protected void ZM44143( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1657ProCotBach = T00443_A1657ProCotBach[0];
               Z1664ProCotFec = T00443_A1664ProCotFec[0];
               Z1670ProCotTItem = T00443_A1670ProCotTItem[0];
               Z1671ProCotUtilidad = T00443_A1671ProCotUtilidad[0];
               Z1659ProCotComision = T00443_A1659ProCotComision[0];
               Z1667ProCotRend1 = T00443_A1667ProCotRend1[0];
               Z1668ProCotRend2 = T00443_A1668ProCotRend2[0];
            }
            else
            {
               Z1657ProCotBach = A1657ProCotBach;
               Z1664ProCotFec = A1664ProCotFec;
               Z1670ProCotTItem = A1670ProCotTItem;
               Z1671ProCotUtilidad = A1671ProCotUtilidad;
               Z1659ProCotComision = A1659ProCotComision;
               Z1667ProCotRend1 = A1667ProCotRend1;
               Z1668ProCotRend2 = A1668ProCotRend2;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1657ProCotBach = A1657ProCotBach;
            Z1664ProCotFec = A1664ProCotFec;
            Z1665ProCotObs = A1665ProCotObs;
            Z1670ProCotTItem = A1670ProCotTItem;
            Z1671ProCotUtilidad = A1671ProCotUtilidad;
            Z1659ProCotComision = A1659ProCotComision;
            Z1667ProCotRend1 = A1667ProCotRend1;
            Z1668ProCotRend2 = A1668ProCotRend2;
            Z317ProCotProdCod = A317ProCotProdCod;
            Z1666ProCotProdDsc = A1666ProCotProdDsc;
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

      protected void Load44143( )
      {
         /* Using cursor T00445 */
         pr_default.execute(3, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound143 = 1;
            A1666ProCotProdDsc = T00445_A1666ProCotProdDsc[0];
            AssignAttri("", false, "A1666ProCotProdDsc", A1666ProCotProdDsc);
            A1657ProCotBach = T00445_A1657ProCotBach[0];
            AssignAttri("", false, "A1657ProCotBach", StringUtil.LTrimStr( A1657ProCotBach, 15, 2));
            A1664ProCotFec = T00445_A1664ProCotFec[0];
            AssignAttri("", false, "A1664ProCotFec", context.localUtil.Format(A1664ProCotFec, "99/99/99"));
            A1665ProCotObs = T00445_A1665ProCotObs[0];
            AssignAttri("", false, "A1665ProCotObs", A1665ProCotObs);
            A1670ProCotTItem = T00445_A1670ProCotTItem[0];
            AssignAttri("", false, "A1670ProCotTItem", StringUtil.LTrimStr( (decimal)(A1670ProCotTItem), 6, 0));
            A1671ProCotUtilidad = T00445_A1671ProCotUtilidad[0];
            AssignAttri("", false, "A1671ProCotUtilidad", StringUtil.LTrimStr( A1671ProCotUtilidad, 15, 2));
            A1659ProCotComision = T00445_A1659ProCotComision[0];
            AssignAttri("", false, "A1659ProCotComision", StringUtil.LTrimStr( A1659ProCotComision, 15, 2));
            A1667ProCotRend1 = T00445_A1667ProCotRend1[0];
            A1668ProCotRend2 = T00445_A1668ProCotRend2[0];
            ZM44143( -2) ;
         }
         pr_default.close(3);
         OnLoadActions44143( ) ;
      }

      protected void OnLoadActions44143( )
      {
      }

      protected void CheckExtendedTable44143( )
      {
         nIsDirty_143 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00444 */
         pr_default.execute(2, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Produccion Cotiza Producto Terminado'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1666ProCotProdDsc = T00444_A1666ProCotProdDsc[0];
         AssignAttri("", false, "A1666ProCotProdDsc", A1666ProCotProdDsc);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1664ProCotFec) || ( DateTimeUtil.ResetTime ( A1664ProCotFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Cotizada fuera de rango", "OutOfRange", 1, "PROCOTFEC");
            AnyError = 1;
            GX_FocusControl = edtProCotFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors44143( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A317ProCotProdCod )
      {
         /* Using cursor T00446 */
         pr_default.execute(4, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Produccion Cotiza Producto Terminado'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1666ProCotProdDsc = T00446_A1666ProCotProdDsc[0];
         AssignAttri("", false, "A1666ProCotProdDsc", A1666ProCotProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1666ProCotProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey44143( )
      {
         /* Using cursor T00447 */
         pr_default.execute(5, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound143 = 1;
         }
         else
         {
            RcdFound143 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00443 */
         pr_default.execute(1, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM44143( 2) ;
            RcdFound143 = 1;
            A1657ProCotBach = T00443_A1657ProCotBach[0];
            AssignAttri("", false, "A1657ProCotBach", StringUtil.LTrimStr( A1657ProCotBach, 15, 2));
            A1664ProCotFec = T00443_A1664ProCotFec[0];
            AssignAttri("", false, "A1664ProCotFec", context.localUtil.Format(A1664ProCotFec, "99/99/99"));
            A1665ProCotObs = T00443_A1665ProCotObs[0];
            AssignAttri("", false, "A1665ProCotObs", A1665ProCotObs);
            A1670ProCotTItem = T00443_A1670ProCotTItem[0];
            AssignAttri("", false, "A1670ProCotTItem", StringUtil.LTrimStr( (decimal)(A1670ProCotTItem), 6, 0));
            A1671ProCotUtilidad = T00443_A1671ProCotUtilidad[0];
            AssignAttri("", false, "A1671ProCotUtilidad", StringUtil.LTrimStr( A1671ProCotUtilidad, 15, 2));
            A1659ProCotComision = T00443_A1659ProCotComision[0];
            AssignAttri("", false, "A1659ProCotComision", StringUtil.LTrimStr( A1659ProCotComision, 15, 2));
            A1667ProCotRend1 = T00443_A1667ProCotRend1[0];
            A1668ProCotRend2 = T00443_A1668ProCotRend2[0];
            A317ProCotProdCod = T00443_A317ProCotProdCod[0];
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            Z317ProCotProdCod = A317ProCotProdCod;
            sMode143 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load44143( ) ;
            if ( AnyError == 1 )
            {
               RcdFound143 = 0;
               InitializeNonKey44143( ) ;
            }
            Gx_mode = sMode143;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound143 = 0;
            InitializeNonKey44143( ) ;
            sMode143 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode143;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey44143( ) ;
         if ( RcdFound143 == 0 )
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
         RcdFound143 = 0;
         /* Using cursor T00448 */
         pr_default.execute(6, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00448_A317ProCotProdCod[0], A317ProCotProdCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00448_A317ProCotProdCod[0], A317ProCotProdCod) > 0 ) ) )
            {
               A317ProCotProdCod = T00448_A317ProCotProdCod[0];
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               RcdFound143 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound143 = 0;
         /* Using cursor T00449 */
         pr_default.execute(7, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00449_A317ProCotProdCod[0], A317ProCotProdCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00449_A317ProCotProdCod[0], A317ProCotProdCod) < 0 ) ) )
            {
               A317ProCotProdCod = T00449_A317ProCotProdCod[0];
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               RcdFound143 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey44143( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert44143( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound143 == 1 )
            {
               if ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 )
               {
                  A317ProCotProdCod = Z317ProCotProdCod;
                  AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOTPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update44143( ) ;
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCotProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert44143( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOTPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCotProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCotProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert44143( ) ;
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
         if ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 )
         {
            A317ProCotProdCod = Z317ProCotProdCod;
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCotProdCod_Internalname;
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
         GetKey44143( ) ;
         if ( RcdFound143 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PROCOTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 )
            {
               A317ProCotProdCod = Z317ProCotProdCod;
               AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PROCOTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProCotProdCod_Internalname;
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
            if ( StringUtil.StrCmp(A317ProCotProdCod, Z317ProCotProdCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOTPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCotProdCod_Internalname;
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
         context.RollbackDataStores("pocotiza",pr_default);
         GX_FocusControl = edtProCotBach_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_440( ) ;
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
         if ( RcdFound143 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProCotBach_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart44143( ) ;
         if ( RcdFound143 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotBach_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd44143( ) ;
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
         if ( RcdFound143 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotBach_Internalname;
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
         if ( RcdFound143 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotBach_Internalname;
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
         ScanStart44143( ) ;
         if ( RcdFound143 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound143 != 0 )
            {
               ScanNext44143( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCotBach_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd44143( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency44143( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00442 */
            pr_default.execute(0, new Object[] {A317ProCotProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCOTIZA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1657ProCotBach != T00442_A1657ProCotBach[0] ) || ( DateTimeUtil.ResetTime ( Z1664ProCotFec ) != DateTimeUtil.ResetTime ( T00442_A1664ProCotFec[0] ) ) || ( Z1670ProCotTItem != T00442_A1670ProCotTItem[0] ) || ( Z1671ProCotUtilidad != T00442_A1671ProCotUtilidad[0] ) || ( Z1659ProCotComision != T00442_A1659ProCotComision[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1667ProCotRend1 != T00442_A1667ProCotRend1[0] ) || ( Z1668ProCotRend2 != T00442_A1668ProCotRend2[0] ) )
            {
               if ( Z1657ProCotBach != T00442_A1657ProCotBach[0] )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotBach");
                  GXUtil.WriteLogRaw("Old: ",Z1657ProCotBach);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1657ProCotBach[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1664ProCotFec ) != DateTimeUtil.ResetTime ( T00442_A1664ProCotFec[0] ) )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotFec");
                  GXUtil.WriteLogRaw("Old: ",Z1664ProCotFec);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1664ProCotFec[0]);
               }
               if ( Z1670ProCotTItem != T00442_A1670ProCotTItem[0] )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotTItem");
                  GXUtil.WriteLogRaw("Old: ",Z1670ProCotTItem);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1670ProCotTItem[0]);
               }
               if ( Z1671ProCotUtilidad != T00442_A1671ProCotUtilidad[0] )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotUtilidad");
                  GXUtil.WriteLogRaw("Old: ",Z1671ProCotUtilidad);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1671ProCotUtilidad[0]);
               }
               if ( Z1659ProCotComision != T00442_A1659ProCotComision[0] )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotComision");
                  GXUtil.WriteLogRaw("Old: ",Z1659ProCotComision);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1659ProCotComision[0]);
               }
               if ( Z1667ProCotRend1 != T00442_A1667ProCotRend1[0] )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotRend1");
                  GXUtil.WriteLogRaw("Old: ",Z1667ProCotRend1);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1667ProCotRend1[0]);
               }
               if ( Z1668ProCotRend2 != T00442_A1668ProCotRend2[0] )
               {
                  GXUtil.WriteLog("pocotiza:[seudo value changed for attri]"+"ProCotRend2");
                  GXUtil.WriteLogRaw("Old: ",Z1668ProCotRend2);
                  GXUtil.WriteLogRaw("Current: ",T00442_A1668ProCotRend2[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POCOTIZA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert44143( )
      {
         BeforeValidate44143( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable44143( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM44143( 0) ;
            CheckOptimisticConcurrency44143( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm44143( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert44143( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004410 */
                     pr_default.execute(8, new Object[] {A1657ProCotBach, A1664ProCotFec, A1665ProCotObs, A1670ProCotTItem, A1671ProCotUtilidad, A1659ProCotComision, A1667ProCotRend1, A1668ProCotRend2, A317ProCotProdCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("POCOTIZA");
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
                           ResetCaption440( ) ;
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
               Load44143( ) ;
            }
            EndLevel44143( ) ;
         }
         CloseExtendedTableCursors44143( ) ;
      }

      protected void Update44143( )
      {
         BeforeValidate44143( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable44143( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency44143( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm44143( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate44143( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004411 */
                     pr_default.execute(9, new Object[] {A1657ProCotBach, A1664ProCotFec, A1665ProCotObs, A1670ProCotTItem, A1671ProCotUtilidad, A1659ProCotComision, A1667ProCotRend1, A1668ProCotRend2, A317ProCotProdCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("POCOTIZA");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POCOTIZA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate44143( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption440( ) ;
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
            EndLevel44143( ) ;
         }
         CloseExtendedTableCursors44143( ) ;
      }

      protected void DeferredUpdate44143( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate44143( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency44143( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls44143( ) ;
            AfterConfirm44143( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete44143( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004412 */
                  pr_default.execute(10, new Object[] {A317ProCotProdCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("POCOTIZA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound143 == 0 )
                        {
                           InitAll44143( ) ;
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
                        ResetCaption440( ) ;
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
         sMode143 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel44143( ) ;
         Gx_mode = sMode143;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls44143( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004413 */
            pr_default.execute(11, new Object[] {A317ProCotProdCod});
            A1666ProCotProdDsc = T004413_A1666ProCotProdDsc[0];
            AssignAttri("", false, "A1666ProCotProdDsc", A1666ProCotProdDsc);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T004414 */
            pr_default.execute(12, new Object[] {A317ProCotProdCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZADET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel44143( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete44143( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("pocotiza",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues440( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("pocotiza",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart44143( )
      {
         /* Using cursor T004415 */
         pr_default.execute(13);
         RcdFound143 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound143 = 1;
            A317ProCotProdCod = T004415_A317ProCotProdCod[0];
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext44143( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound143 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound143 = 1;
            A317ProCotProdCod = T004415_A317ProCotProdCod[0];
            AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
         }
      }

      protected void ScanEnd44143( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm44143( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert44143( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate44143( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete44143( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete44143( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate44143( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes44143( )
      {
         edtProCotProdCod_Enabled = 0;
         AssignProp("", false, edtProCotProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotProdCod_Enabled), 5, 0), true);
         edtProCotProdDsc_Enabled = 0;
         AssignProp("", false, edtProCotProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotProdDsc_Enabled), 5, 0), true);
         edtProCotBach_Enabled = 0;
         AssignProp("", false, edtProCotBach_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotBach_Enabled), 5, 0), true);
         edtProCotFec_Enabled = 0;
         AssignProp("", false, edtProCotFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotFec_Enabled), 5, 0), true);
         edtProCotObs_Enabled = 0;
         AssignProp("", false, edtProCotObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotObs_Enabled), 5, 0), true);
         edtProCotTItem_Enabled = 0;
         AssignProp("", false, edtProCotTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotTItem_Enabled), 5, 0), true);
         edtProCotUtilidad_Enabled = 0;
         AssignProp("", false, edtProCotUtilidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotUtilidad_Enabled), 5, 0), true);
         edtProCotComision_Enabled = 0;
         AssignProp("", false, edtProCotComision_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCotComision_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes44143( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues440( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025295", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("pocotiza.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"POCOTIZA");
         forbiddenHiddens.Add("ProCotRend1", context.localUtil.Format( A1667ProCotRend1, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ProCotRend2", context.localUtil.Format( A1668ProCotRend2, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pocotiza:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z317ProCotProdCod", StringUtil.RTrim( Z317ProCotProdCod));
         GxWebStd.gx_hidden_field( context, "Z1657ProCotBach", StringUtil.LTrim( StringUtil.NToC( Z1657ProCotBach, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1664ProCotFec", context.localUtil.DToC( Z1664ProCotFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1670ProCotTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1670ProCotTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1671ProCotUtilidad", StringUtil.LTrim( StringUtil.NToC( Z1671ProCotUtilidad, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1659ProCotComision", StringUtil.LTrim( StringUtil.NToC( Z1659ProCotComision, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1667ProCotRend1", StringUtil.LTrim( StringUtil.NToC( Z1667ProCotRend1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1668ProCotRend2", StringUtil.LTrim( StringUtil.NToC( Z1668ProCotRend2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROCOTREND1", StringUtil.LTrim( StringUtil.NToC( A1667ProCotRend1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROCOTREND2", StringUtil.LTrim( StringUtil.NToC( A1668ProCotRend2, 15, 2, ".", "")));
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
         return formatLink("pocotiza.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POCOTIZA" ;
      }

      public override string GetPgmdesc( )
      {
         return "POCOTIZA" ;
      }

      protected void InitializeNonKey44143( )
      {
         A1666ProCotProdDsc = "";
         AssignAttri("", false, "A1666ProCotProdDsc", A1666ProCotProdDsc);
         A1657ProCotBach = 0;
         AssignAttri("", false, "A1657ProCotBach", StringUtil.LTrimStr( A1657ProCotBach, 15, 2));
         A1664ProCotFec = DateTime.MinValue;
         AssignAttri("", false, "A1664ProCotFec", context.localUtil.Format(A1664ProCotFec, "99/99/99"));
         A1665ProCotObs = "";
         AssignAttri("", false, "A1665ProCotObs", A1665ProCotObs);
         A1670ProCotTItem = 0;
         AssignAttri("", false, "A1670ProCotTItem", StringUtil.LTrimStr( (decimal)(A1670ProCotTItem), 6, 0));
         A1671ProCotUtilidad = 0;
         AssignAttri("", false, "A1671ProCotUtilidad", StringUtil.LTrimStr( A1671ProCotUtilidad, 15, 2));
         A1659ProCotComision = 0;
         AssignAttri("", false, "A1659ProCotComision", StringUtil.LTrimStr( A1659ProCotComision, 15, 2));
         A1667ProCotRend1 = 0;
         AssignAttri("", false, "A1667ProCotRend1", StringUtil.LTrimStr( A1667ProCotRend1, 15, 2));
         A1668ProCotRend2 = 0;
         AssignAttri("", false, "A1668ProCotRend2", StringUtil.LTrimStr( A1668ProCotRend2, 15, 2));
         Z1657ProCotBach = 0;
         Z1664ProCotFec = DateTime.MinValue;
         Z1670ProCotTItem = 0;
         Z1671ProCotUtilidad = 0;
         Z1659ProCotComision = 0;
         Z1667ProCotRend1 = 0;
         Z1668ProCotRend2 = 0;
      }

      protected void InitAll44143( )
      {
         A317ProCotProdCod = "";
         AssignAttri("", false, "A317ProCotProdCod", A317ProCotProdCod);
         InitializeNonKey44143( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252916", true, true);
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
         context.AddJavascriptSource("pocotiza.js", "?202281810252917", false, true);
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
         edtProCotProdCod_Internalname = "PROCOTPRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProCotProdDsc_Internalname = "PROCOTPRODDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProCotBach_Internalname = "PROCOTBACH";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtProCotFec_Internalname = "PROCOTFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtProCotObs_Internalname = "PROCOTOBS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtProCotTItem_Internalname = "PROCOTTITEM";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtProCotUtilidad_Internalname = "PROCOTUTILIDAD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtProCotComision_Internalname = "PROCOTCOMISION";
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
         Form.Caption = "POCOTIZA";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProCotComision_Jsonclick = "";
         edtProCotComision_Enabled = 1;
         edtProCotUtilidad_Jsonclick = "";
         edtProCotUtilidad_Enabled = 1;
         edtProCotTItem_Jsonclick = "";
         edtProCotTItem_Enabled = 1;
         edtProCotObs_Enabled = 1;
         edtProCotFec_Jsonclick = "";
         edtProCotFec_Enabled = 1;
         edtProCotBach_Jsonclick = "";
         edtProCotBach_Enabled = 1;
         edtProCotProdDsc_Jsonclick = "";
         edtProCotProdDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProCotProdCod_Jsonclick = "";
         edtProCotProdCod_Enabled = 1;
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
         GX_FocusControl = edtProCotBach_Internalname;
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

      public void Valid_Procotprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T004413 */
         pr_default.execute(11, new Object[] {A317ProCotProdCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Produccion Cotiza Producto Terminado'.", "ForeignKeyNotFound", 1, "PROCOTPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCotProdCod_Internalname;
         }
         A1666ProCotProdDsc = T004413_A1666ProCotProdDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1657ProCotBach", StringUtil.LTrim( StringUtil.NToC( A1657ProCotBach, 15, 2, ".", "")));
         AssignAttri("", false, "A1664ProCotFec", context.localUtil.Format(A1664ProCotFec, "99/99/99"));
         AssignAttri("", false, "A1665ProCotObs", A1665ProCotObs);
         AssignAttri("", false, "A1670ProCotTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1670ProCotTItem), 6, 0, ".", "")));
         AssignAttri("", false, "A1671ProCotUtilidad", StringUtil.LTrim( StringUtil.NToC( A1671ProCotUtilidad, 15, 2, ".", "")));
         AssignAttri("", false, "A1659ProCotComision", StringUtil.LTrim( StringUtil.NToC( A1659ProCotComision, 15, 2, ".", "")));
         AssignAttri("", false, "A1667ProCotRend1", StringUtil.LTrim( StringUtil.NToC( A1667ProCotRend1, 15, 2, ".", "")));
         AssignAttri("", false, "A1668ProCotRend2", StringUtil.LTrim( StringUtil.NToC( A1668ProCotRend2, 15, 2, ".", "")));
         AssignAttri("", false, "A1666ProCotProdDsc", StringUtil.RTrim( A1666ProCotProdDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z317ProCotProdCod", StringUtil.RTrim( Z317ProCotProdCod));
         GxWebStd.gx_hidden_field( context, "Z1657ProCotBach", StringUtil.LTrim( StringUtil.NToC( Z1657ProCotBach, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1664ProCotFec", context.localUtil.Format(Z1664ProCotFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1665ProCotObs", Z1665ProCotObs);
         GxWebStd.gx_hidden_field( context, "Z1670ProCotTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1670ProCotTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1671ProCotUtilidad", StringUtil.LTrim( StringUtil.NToC( Z1671ProCotUtilidad, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1659ProCotComision", StringUtil.LTrim( StringUtil.NToC( Z1659ProCotComision, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1667ProCotRend1", StringUtil.LTrim( StringUtil.NToC( Z1667ProCotRend1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1668ProCotRend2", StringUtil.LTrim( StringUtil.NToC( Z1668ProCotRend2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1666ProCotProdDsc", StringUtil.RTrim( Z1666ProCotProdDsc));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1667ProCotRend1',fld:'PROCOTREND1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1668ProCotRend2',fld:'PROCOTREND2',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PROCOTPRODCOD","{handler:'Valid_Procotprodcod',iparms:[{av:'A1668ProCotRend2',fld:'PROCOTREND2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1667ProCotRend1',fld:'PROCOTREND1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A317ProCotProdCod',fld:'PROCOTPRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROCOTPRODCOD",",oparms:[{av:'A1657ProCotBach',fld:'PROCOTBACH',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1664ProCotFec',fld:'PROCOTFEC',pic:''},{av:'A1665ProCotObs',fld:'PROCOTOBS',pic:''},{av:'A1670ProCotTItem',fld:'PROCOTTITEM',pic:'ZZZZZ9'},{av:'A1671ProCotUtilidad',fld:'PROCOTUTILIDAD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1659ProCotComision',fld:'PROCOTCOMISION',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1667ProCotRend1',fld:'PROCOTREND1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1668ProCotRend2',fld:'PROCOTREND2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1666ProCotProdDsc',fld:'PROCOTPRODDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z317ProCotProdCod'},{av:'Z1657ProCotBach'},{av:'Z1664ProCotFec'},{av:'Z1665ProCotObs'},{av:'Z1670ProCotTItem'},{av:'Z1671ProCotUtilidad'},{av:'Z1659ProCotComision'},{av:'Z1667ProCotRend1'},{av:'Z1668ProCotRend2'},{av:'Z1666ProCotProdDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROCOTFEC","{handler:'Valid_Procotfec',iparms:[]");
         setEventMetadata("VALID_PROCOTFEC",",oparms:[]}");
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
         Z317ProCotProdCod = "";
         Z1664ProCotFec = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A317ProCotProdCod = "";
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
         A1666ProCotProdDsc = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1664ProCotFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A1665ProCotObs = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1665ProCotObs = "";
         Z1666ProCotProdDsc = "";
         T00445_A1666ProCotProdDsc = new string[] {""} ;
         T00445_A1657ProCotBach = new decimal[1] ;
         T00445_A1664ProCotFec = new DateTime[] {DateTime.MinValue} ;
         T00445_A1665ProCotObs = new string[] {""} ;
         T00445_A1670ProCotTItem = new int[1] ;
         T00445_A1671ProCotUtilidad = new decimal[1] ;
         T00445_A1659ProCotComision = new decimal[1] ;
         T00445_A1667ProCotRend1 = new decimal[1] ;
         T00445_A1668ProCotRend2 = new decimal[1] ;
         T00445_A317ProCotProdCod = new string[] {""} ;
         T00444_A1666ProCotProdDsc = new string[] {""} ;
         T00446_A1666ProCotProdDsc = new string[] {""} ;
         T00447_A317ProCotProdCod = new string[] {""} ;
         T00443_A1657ProCotBach = new decimal[1] ;
         T00443_A1664ProCotFec = new DateTime[] {DateTime.MinValue} ;
         T00443_A1665ProCotObs = new string[] {""} ;
         T00443_A1670ProCotTItem = new int[1] ;
         T00443_A1671ProCotUtilidad = new decimal[1] ;
         T00443_A1659ProCotComision = new decimal[1] ;
         T00443_A1667ProCotRend1 = new decimal[1] ;
         T00443_A1668ProCotRend2 = new decimal[1] ;
         T00443_A317ProCotProdCod = new string[] {""} ;
         sMode143 = "";
         T00448_A317ProCotProdCod = new string[] {""} ;
         T00449_A317ProCotProdCod = new string[] {""} ;
         T00442_A1657ProCotBach = new decimal[1] ;
         T00442_A1664ProCotFec = new DateTime[] {DateTime.MinValue} ;
         T00442_A1665ProCotObs = new string[] {""} ;
         T00442_A1670ProCotTItem = new int[1] ;
         T00442_A1671ProCotUtilidad = new decimal[1] ;
         T00442_A1659ProCotComision = new decimal[1] ;
         T00442_A1667ProCotRend1 = new decimal[1] ;
         T00442_A1668ProCotRend2 = new decimal[1] ;
         T00442_A317ProCotProdCod = new string[] {""} ;
         T004413_A1666ProCotProdDsc = new string[] {""} ;
         T004414_A317ProCotProdCod = new string[] {""} ;
         T004414_A318ProCotItem = new int[1] ;
         T004415_A317ProCotProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ317ProCotProdCod = "";
         ZZ1664ProCotFec = DateTime.MinValue;
         ZZ1665ProCotObs = "";
         ZZ1666ProCotProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.pocotiza__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pocotiza__default(),
            new Object[][] {
                new Object[] {
               T00442_A1657ProCotBach, T00442_A1664ProCotFec, T00442_A1665ProCotObs, T00442_A1670ProCotTItem, T00442_A1671ProCotUtilidad, T00442_A1659ProCotComision, T00442_A1667ProCotRend1, T00442_A1668ProCotRend2, T00442_A317ProCotProdCod
               }
               , new Object[] {
               T00443_A1657ProCotBach, T00443_A1664ProCotFec, T00443_A1665ProCotObs, T00443_A1670ProCotTItem, T00443_A1671ProCotUtilidad, T00443_A1659ProCotComision, T00443_A1667ProCotRend1, T00443_A1668ProCotRend2, T00443_A317ProCotProdCod
               }
               , new Object[] {
               T00444_A1666ProCotProdDsc
               }
               , new Object[] {
               T00445_A1666ProCotProdDsc, T00445_A1657ProCotBach, T00445_A1664ProCotFec, T00445_A1665ProCotObs, T00445_A1670ProCotTItem, T00445_A1671ProCotUtilidad, T00445_A1659ProCotComision, T00445_A1667ProCotRend1, T00445_A1668ProCotRend2, T00445_A317ProCotProdCod
               }
               , new Object[] {
               T00446_A1666ProCotProdDsc
               }
               , new Object[] {
               T00447_A317ProCotProdCod
               }
               , new Object[] {
               T00448_A317ProCotProdCod
               }
               , new Object[] {
               T00449_A317ProCotProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004413_A1666ProCotProdDsc
               }
               , new Object[] {
               T004414_A317ProCotProdCod, T004414_A318ProCotItem
               }
               , new Object[] {
               T004415_A317ProCotProdCod
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
      private short RcdFound143 ;
      private short nIsDirty_143 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1670ProCotTItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCotProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProCotProdDsc_Enabled ;
      private int edtProCotBach_Enabled ;
      private int edtProCotFec_Enabled ;
      private int edtProCotObs_Enabled ;
      private int A1670ProCotTItem ;
      private int edtProCotTItem_Enabled ;
      private int edtProCotUtilidad_Enabled ;
      private int edtProCotComision_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ1670ProCotTItem ;
      private decimal Z1657ProCotBach ;
      private decimal Z1671ProCotUtilidad ;
      private decimal Z1659ProCotComision ;
      private decimal Z1667ProCotRend1 ;
      private decimal Z1668ProCotRend2 ;
      private decimal A1657ProCotBach ;
      private decimal A1671ProCotUtilidad ;
      private decimal A1659ProCotComision ;
      private decimal A1667ProCotRend1 ;
      private decimal A1668ProCotRend2 ;
      private decimal ZZ1657ProCotBach ;
      private decimal ZZ1671ProCotUtilidad ;
      private decimal ZZ1659ProCotComision ;
      private decimal ZZ1667ProCotRend1 ;
      private decimal ZZ1668ProCotRend2 ;
      private string sPrefix ;
      private string Z317ProCotProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A317ProCotProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCotProdCod_Internalname ;
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
      private string edtProCotProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProCotProdDsc_Internalname ;
      private string A1666ProCotProdDsc ;
      private string edtProCotProdDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProCotBach_Internalname ;
      private string edtProCotBach_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtProCotFec_Internalname ;
      private string edtProCotFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtProCotObs_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtProCotTItem_Internalname ;
      private string edtProCotTItem_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtProCotUtilidad_Internalname ;
      private string edtProCotUtilidad_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtProCotComision_Internalname ;
      private string edtProCotComision_Jsonclick ;
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
      private string Z1666ProCotProdDsc ;
      private string sMode143 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ317ProCotProdCod ;
      private string ZZ1666ProCotProdDsc ;
      private DateTime Z1664ProCotFec ;
      private DateTime A1664ProCotFec ;
      private DateTime ZZ1664ProCotFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A1665ProCotObs ;
      private string Z1665ProCotObs ;
      private string ZZ1665ProCotObs ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00445_A1666ProCotProdDsc ;
      private decimal[] T00445_A1657ProCotBach ;
      private DateTime[] T00445_A1664ProCotFec ;
      private string[] T00445_A1665ProCotObs ;
      private int[] T00445_A1670ProCotTItem ;
      private decimal[] T00445_A1671ProCotUtilidad ;
      private decimal[] T00445_A1659ProCotComision ;
      private decimal[] T00445_A1667ProCotRend1 ;
      private decimal[] T00445_A1668ProCotRend2 ;
      private string[] T00445_A317ProCotProdCod ;
      private string[] T00444_A1666ProCotProdDsc ;
      private string[] T00446_A1666ProCotProdDsc ;
      private string[] T00447_A317ProCotProdCod ;
      private decimal[] T00443_A1657ProCotBach ;
      private DateTime[] T00443_A1664ProCotFec ;
      private string[] T00443_A1665ProCotObs ;
      private int[] T00443_A1670ProCotTItem ;
      private decimal[] T00443_A1671ProCotUtilidad ;
      private decimal[] T00443_A1659ProCotComision ;
      private decimal[] T00443_A1667ProCotRend1 ;
      private decimal[] T00443_A1668ProCotRend2 ;
      private string[] T00443_A317ProCotProdCod ;
      private string[] T00448_A317ProCotProdCod ;
      private string[] T00449_A317ProCotProdCod ;
      private decimal[] T00442_A1657ProCotBach ;
      private DateTime[] T00442_A1664ProCotFec ;
      private string[] T00442_A1665ProCotObs ;
      private int[] T00442_A1670ProCotTItem ;
      private decimal[] T00442_A1671ProCotUtilidad ;
      private decimal[] T00442_A1659ProCotComision ;
      private decimal[] T00442_A1667ProCotRend1 ;
      private decimal[] T00442_A1668ProCotRend2 ;
      private string[] T00442_A317ProCotProdCod ;
      private string[] T004413_A1666ProCotProdDsc ;
      private string[] T004414_A317ProCotProdCod ;
      private int[] T004414_A318ProCotItem ;
      private string[] T004415_A317ProCotProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class pocotiza__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pocotiza__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00445;
        prmT00445 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00444;
        prmT00444 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00446;
        prmT00446 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00447;
        prmT00447 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00443;
        prmT00443 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00448;
        prmT00448 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00449;
        prmT00449 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00442;
        prmT00442 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004410;
        prmT004410 = new Object[] {
        new ParDef("@ProCotBach",GXType.Decimal,15,2) ,
        new ParDef("@ProCotFec",GXType.Date,8,0) ,
        new ParDef("@ProCotObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProCotTItem",GXType.Int32,6,0) ,
        new ParDef("@ProCotUtilidad",GXType.Decimal,15,2) ,
        new ParDef("@ProCotComision",GXType.Decimal,15,2) ,
        new ParDef("@ProCotRend1",GXType.Decimal,15,2) ,
        new ParDef("@ProCotRend2",GXType.Decimal,15,2) ,
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004411;
        prmT004411 = new Object[] {
        new ParDef("@ProCotBach",GXType.Decimal,15,2) ,
        new ParDef("@ProCotFec",GXType.Date,8,0) ,
        new ParDef("@ProCotObs",GXType.NVarChar,500,0) ,
        new ParDef("@ProCotTItem",GXType.Int32,6,0) ,
        new ParDef("@ProCotUtilidad",GXType.Decimal,15,2) ,
        new ParDef("@ProCotComision",GXType.Decimal,15,2) ,
        new ParDef("@ProCotRend1",GXType.Decimal,15,2) ,
        new ParDef("@ProCotRend2",GXType.Decimal,15,2) ,
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004412;
        prmT004412 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004414;
        prmT004414 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        Object[] prmT004415;
        prmT004415 = new Object[] {
        };
        Object[] prmT004413;
        prmT004413 = new Object[] {
        new ParDef("@ProCotProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00442", "SELECT [ProCotBach], [ProCotFec], [ProCotObs], [ProCotTItem], [ProCotUtilidad], [ProCotComision], [ProCotRend1], [ProCotRend2], [ProCotProdCod] AS ProCotProdCod FROM [POCOTIZA] WITH (UPDLOCK) WHERE [ProCotProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00442,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00443", "SELECT [ProCotBach], [ProCotFec], [ProCotObs], [ProCotTItem], [ProCotUtilidad], [ProCotComision], [ProCotRend1], [ProCotRend2], [ProCotProdCod] AS ProCotProdCod FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00443,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00444", "SELECT [ProdDsc] AS ProCotProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00444,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00445", "SELECT T2.[ProdDsc] AS ProCotProdDsc, TM1.[ProCotBach], TM1.[ProCotFec], TM1.[ProCotObs], TM1.[ProCotTItem], TM1.[ProCotUtilidad], TM1.[ProCotComision], TM1.[ProCotRend1], TM1.[ProCotRend2], TM1.[ProCotProdCod] AS ProCotProdCod FROM ([POCOTIZA] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProCotProdCod]) WHERE TM1.[ProCotProdCod] = @ProCotProdCod ORDER BY TM1.[ProCotProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00445,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00446", "SELECT [ProdDsc] AS ProCotProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00446,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00447", "SELECT [ProCotProdCod] AS ProCotProdCod FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProCotProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00447,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00448", "SELECT TOP 1 [ProCotProdCod] AS ProCotProdCod FROM [POCOTIZA] WHERE ( [ProCotProdCod] > @ProCotProdCod) ORDER BY [ProCotProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00448,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00449", "SELECT TOP 1 [ProCotProdCod] AS ProCotProdCod FROM [POCOTIZA] WHERE ( [ProCotProdCod] < @ProCotProdCod) ORDER BY [ProCotProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00449,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004410", "INSERT INTO [POCOTIZA]([ProCotBach], [ProCotFec], [ProCotObs], [ProCotTItem], [ProCotUtilidad], [ProCotComision], [ProCotRend1], [ProCotRend2], [ProCotProdCod]) VALUES(@ProCotBach, @ProCotFec, @ProCotObs, @ProCotTItem, @ProCotUtilidad, @ProCotComision, @ProCotRend1, @ProCotRend2, @ProCotProdCod)", GxErrorMask.GX_NOMASK,prmT004410)
           ,new CursorDef("T004411", "UPDATE [POCOTIZA] SET [ProCotBach]=@ProCotBach, [ProCotFec]=@ProCotFec, [ProCotObs]=@ProCotObs, [ProCotTItem]=@ProCotTItem, [ProCotUtilidad]=@ProCotUtilidad, [ProCotComision]=@ProCotComision, [ProCotRend1]=@ProCotRend1, [ProCotRend2]=@ProCotRend2  WHERE [ProCotProdCod] = @ProCotProdCod", GxErrorMask.GX_NOMASK,prmT004411)
           ,new CursorDef("T004412", "DELETE FROM [POCOTIZA]  WHERE [ProCotProdCod] = @ProCotProdCod", GxErrorMask.GX_NOMASK,prmT004412)
           ,new CursorDef("T004413", "SELECT [ProdDsc] AS ProCotProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004414", "SELECT TOP 1 [ProCotProdCod] AS ProCotProdCod, [ProCotItem] FROM [POCOTIZADET] WHERE [ProCotProdCod] = @ProCotProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004414,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004415", "SELECT [ProCotProdCod] AS ProCotProdCod FROM [POCOTIZA] ORDER BY [ProCotProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004415,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
