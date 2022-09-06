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
   public class alistadescuento : GXDataArea
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
            A39ListProdCod = GetPar( "ListProdCod");
            n39ListProdCod = false;
            AssignAttri("", false, "A39ListProdCod", A39ListProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A39ListProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A38ListCliCod = GetPar( "ListCliCod");
            n38ListCliCod = false;
            AssignAttri("", false, "A38ListCliCod", A38ListCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A38ListCliCod) ;
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
            Form.Meta.addItem("description", "Lista de Descuentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtListItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public alistadescuento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public alistadescuento( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ALISTADESCUENTO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Item", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37ListItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtListItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A37ListItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A37ListItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Cliente", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListTipCli_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1214ListTipCli), 6, 0, ".", "")), StringUtil.LTrim( ((edtListTipCli_Enabled!=0) ? context.localUtil.Format( (decimal)(A1214ListTipCli), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1214ListTipCli), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListTipCli_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListTipCli_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Linea de Productos", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1211ListLinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtListLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1211ListLinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1211ListLinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListProdCod_Internalname, StringUtil.RTrim( A39ListProdCod), StringUtil.RTrim( context.localUtil.Format( A39ListProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Cliente", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListCliCod_Internalname, StringUtil.RTrim( A38ListCliCod), StringUtil.RTrim( context.localUtil.Format( A38ListCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% Porcentaje", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListPorcentaje_Internalname, StringUtil.LTrim( StringUtil.NToC( A1212ListPorcentaje, 6, 2, ".", "")), StringUtil.LTrim( ((edtListPorcentaje_Enabled!=0) ? context.localUtil.Format( A1212ListPorcentaje, "ZZ9.99") : context.localUtil.Format( A1212ListPorcentaje, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListPorcentaje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListPorcentaje_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Fecha Desde", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtListDesde_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtListDesde_Internalname, context.localUtil.Format(A1209ListDesde, "99/99/99"), context.localUtil.Format( A1209ListDesde, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListDesde_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListDesde_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ALISTADESCUENTO.htm");
         GxWebStd.gx_bitmap( context, edtListDesde_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtListDesde_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fecha Hasta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtListHasta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtListHasta_Internalname, context.localUtil.Format(A1210ListHasta, "99/99/99"), context.localUtil.Format( A1210ListHasta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListHasta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListHasta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ALISTADESCUENTO.htm");
         GxWebStd.gx_bitmap( context, edtListHasta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtListHasta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Tipo", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListTipo_Internalname, StringUtil.RTrim( A1215ListTipo), StringUtil.RTrim( context.localUtil.Format( A1215ListTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Producto", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtListProdDsc_Internalname, StringUtil.RTrim( A1213ListProdDsc), StringUtil.RTrim( context.localUtil.Format( A1213ListProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Cliente", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtListCliDsc_Internalname, StringUtil.RTrim( A1208ListCliDsc), StringUtil.RTrim( context.localUtil.Format( A1208ListCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ALISTADESCUENTO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ALISTADESCUENTO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ALISTADESCUENTO.htm");
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
            Z37ListItem = (int)(context.localUtil.CToN( cgiGet( "Z37ListItem"), ".", ","));
            Z1214ListTipCli = (int)(context.localUtil.CToN( cgiGet( "Z1214ListTipCli"), ".", ","));
            Z1211ListLinCod = (int)(context.localUtil.CToN( cgiGet( "Z1211ListLinCod"), ".", ","));
            Z2262ListSubLCod = (int)(context.localUtil.CToN( cgiGet( "Z2262ListSubLCod"), ".", ","));
            Z1212ListPorcentaje = context.localUtil.CToN( cgiGet( "Z1212ListPorcentaje"), ".", ",");
            Z1209ListDesde = context.localUtil.CToD( cgiGet( "Z1209ListDesde"), 0);
            Z1210ListHasta = context.localUtil.CToD( cgiGet( "Z1210ListHasta"), 0);
            Z1215ListTipo = cgiGet( "Z1215ListTipo");
            Z1206ListCantDesde = context.localUtil.CToN( cgiGet( "Z1206ListCantDesde"), ".", ",");
            Z1207ListCantHasta = context.localUtil.CToN( cgiGet( "Z1207ListCantHasta"), ".", ",");
            Z39ListProdCod = cgiGet( "Z39ListProdCod");
            Z38ListCliCod = cgiGet( "Z38ListCliCod");
            A2262ListSubLCod = (int)(context.localUtil.CToN( cgiGet( "Z2262ListSubLCod"), ".", ","));
            A1206ListCantDesde = context.localUtil.CToN( cgiGet( "Z1206ListCantDesde"), ".", ",");
            A1207ListCantHasta = context.localUtil.CToN( cgiGet( "Z1207ListCantHasta"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A2262ListSubLCod = (int)(context.localUtil.CToN( cgiGet( "LISTSUBLCOD"), ".", ","));
            A1206ListCantDesde = context.localUtil.CToN( cgiGet( "LISTCANTDESDE"), ".", ",");
            A1207ListCantHasta = context.localUtil.CToN( cgiGet( "LISTCANTHASTA"), ".", ",");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtListItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTITEM");
               AnyError = 1;
               GX_FocusControl = edtListItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A37ListItem = 0;
               AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
            }
            else
            {
               A37ListItem = (int)(context.localUtil.CToN( cgiGet( edtListItem_Internalname), ".", ","));
               AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtListTipCli_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListTipCli_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTTIPCLI");
               AnyError = 1;
               GX_FocusControl = edtListTipCli_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1214ListTipCli = 0;
               AssignAttri("", false, "A1214ListTipCli", StringUtil.LTrimStr( (decimal)(A1214ListTipCli), 6, 0));
            }
            else
            {
               A1214ListTipCli = (int)(context.localUtil.CToN( cgiGet( edtListTipCli_Internalname), ".", ","));
               AssignAttri("", false, "A1214ListTipCli", StringUtil.LTrimStr( (decimal)(A1214ListTipCli), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtListLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTLINCOD");
               AnyError = 1;
               GX_FocusControl = edtListLinCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1211ListLinCod = 0;
               n1211ListLinCod = false;
               AssignAttri("", false, "A1211ListLinCod", StringUtil.LTrimStr( (decimal)(A1211ListLinCod), 6, 0));
            }
            else
            {
               A1211ListLinCod = (int)(context.localUtil.CToN( cgiGet( edtListLinCod_Internalname), ".", ","));
               n1211ListLinCod = false;
               AssignAttri("", false, "A1211ListLinCod", StringUtil.LTrimStr( (decimal)(A1211ListLinCod), 6, 0));
            }
            A39ListProdCod = StringUtil.Upper( cgiGet( edtListProdCod_Internalname));
            n39ListProdCod = false;
            AssignAttri("", false, "A39ListProdCod", A39ListProdCod);
            A38ListCliCod = cgiGet( edtListCliCod_Internalname);
            n38ListCliCod = false;
            AssignAttri("", false, "A38ListCliCod", A38ListCliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtListPorcentaje_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListPorcentaje_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTPORCENTAJE");
               AnyError = 1;
               GX_FocusControl = edtListPorcentaje_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1212ListPorcentaje = 0;
               AssignAttri("", false, "A1212ListPorcentaje", StringUtil.LTrimStr( A1212ListPorcentaje, 6, 2));
            }
            else
            {
               A1212ListPorcentaje = context.localUtil.CToN( cgiGet( edtListPorcentaje_Internalname), ".", ",");
               AssignAttri("", false, "A1212ListPorcentaje", StringUtil.LTrimStr( A1212ListPorcentaje, 6, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtListDesde_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Desde"}), 1, "LISTDESDE");
               AnyError = 1;
               GX_FocusControl = edtListDesde_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1209ListDesde = DateTime.MinValue;
               AssignAttri("", false, "A1209ListDesde", context.localUtil.Format(A1209ListDesde, "99/99/99"));
            }
            else
            {
               A1209ListDesde = context.localUtil.CToD( cgiGet( edtListDesde_Internalname), 2);
               AssignAttri("", false, "A1209ListDesde", context.localUtil.Format(A1209ListDesde, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtListHasta_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Hasta"}), 1, "LISTHASTA");
               AnyError = 1;
               GX_FocusControl = edtListHasta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1210ListHasta = DateTime.MinValue;
               AssignAttri("", false, "A1210ListHasta", context.localUtil.Format(A1210ListHasta, "99/99/99"));
            }
            else
            {
               A1210ListHasta = context.localUtil.CToD( cgiGet( edtListHasta_Internalname), 2);
               AssignAttri("", false, "A1210ListHasta", context.localUtil.Format(A1210ListHasta, "99/99/99"));
            }
            A1215ListTipo = cgiGet( edtListTipo_Internalname);
            AssignAttri("", false, "A1215ListTipo", A1215ListTipo);
            A1213ListProdDsc = cgiGet( edtListProdDsc_Internalname);
            AssignAttri("", false, "A1213ListProdDsc", A1213ListProdDsc);
            A1208ListCliDsc = cgiGet( edtListCliDsc_Internalname);
            AssignAttri("", false, "A1208ListCliDsc", A1208ListCliDsc);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ALISTADESCUENTO");
            forbiddenHiddens.Add("ListSubLCod", context.localUtil.Format( (decimal)(A2262ListSubLCod), "ZZZZZ9"));
            forbiddenHiddens.Add("ListCantDesde", context.localUtil.Format( A1206ListCantDesde, "ZZZZZZ,ZZZ,ZZ9.99"));
            forbiddenHiddens.Add("ListCantHasta", context.localUtil.Format( A1207ListCantHasta, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A37ListItem != Z37ListItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("alistadescuento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A37ListItem = (int)(NumberUtil.Val( GetPar( "ListItem"), "."));
               AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
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
               InitAll1842( ) ;
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
         DisableAttributes1842( ) ;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1842( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1842( ) ;
            }
            else
            {
               CheckExtendedTable1842( ) ;
               if ( AnyError == 0 )
               {
                  ZM1842( 4) ;
                  ZM1842( 5) ;
               }
               CloseExtendedTableCursors1842( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues180( ) ;
         }
      }

      protected void ResetCaption180( )
      {
      }

      protected void ZM1842( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1214ListTipCli = T00183_A1214ListTipCli[0];
               Z1211ListLinCod = T00183_A1211ListLinCod[0];
               Z2262ListSubLCod = T00183_A2262ListSubLCod[0];
               Z1212ListPorcentaje = T00183_A1212ListPorcentaje[0];
               Z1209ListDesde = T00183_A1209ListDesde[0];
               Z1210ListHasta = T00183_A1210ListHasta[0];
               Z1215ListTipo = T00183_A1215ListTipo[0];
               Z1206ListCantDesde = T00183_A1206ListCantDesde[0];
               Z1207ListCantHasta = T00183_A1207ListCantHasta[0];
               Z39ListProdCod = T00183_A39ListProdCod[0];
               Z38ListCliCod = T00183_A38ListCliCod[0];
            }
            else
            {
               Z1214ListTipCli = A1214ListTipCli;
               Z1211ListLinCod = A1211ListLinCod;
               Z2262ListSubLCod = A2262ListSubLCod;
               Z1212ListPorcentaje = A1212ListPorcentaje;
               Z1209ListDesde = A1209ListDesde;
               Z1210ListHasta = A1210ListHasta;
               Z1215ListTipo = A1215ListTipo;
               Z1206ListCantDesde = A1206ListCantDesde;
               Z1207ListCantHasta = A1207ListCantHasta;
               Z39ListProdCod = A39ListProdCod;
               Z38ListCliCod = A38ListCliCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z37ListItem = A37ListItem;
            Z1214ListTipCli = A1214ListTipCli;
            Z1211ListLinCod = A1211ListLinCod;
            Z2262ListSubLCod = A2262ListSubLCod;
            Z1212ListPorcentaje = A1212ListPorcentaje;
            Z1209ListDesde = A1209ListDesde;
            Z1210ListHasta = A1210ListHasta;
            Z1215ListTipo = A1215ListTipo;
            Z1206ListCantDesde = A1206ListCantDesde;
            Z1207ListCantHasta = A1207ListCantHasta;
            Z39ListProdCod = A39ListProdCod;
            Z38ListCliCod = A38ListCliCod;
            Z1213ListProdDsc = A1213ListProdDsc;
            Z1208ListCliDsc = A1208ListCliDsc;
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

      protected void Load1842( )
      {
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A37ListItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound42 = 1;
            A1214ListTipCli = T00186_A1214ListTipCli[0];
            AssignAttri("", false, "A1214ListTipCli", StringUtil.LTrimStr( (decimal)(A1214ListTipCli), 6, 0));
            A1211ListLinCod = T00186_A1211ListLinCod[0];
            n1211ListLinCod = T00186_n1211ListLinCod[0];
            AssignAttri("", false, "A1211ListLinCod", StringUtil.LTrimStr( (decimal)(A1211ListLinCod), 6, 0));
            A2262ListSubLCod = T00186_A2262ListSubLCod[0];
            A1212ListPorcentaje = T00186_A1212ListPorcentaje[0];
            AssignAttri("", false, "A1212ListPorcentaje", StringUtil.LTrimStr( A1212ListPorcentaje, 6, 2));
            A1209ListDesde = T00186_A1209ListDesde[0];
            AssignAttri("", false, "A1209ListDesde", context.localUtil.Format(A1209ListDesde, "99/99/99"));
            A1210ListHasta = T00186_A1210ListHasta[0];
            AssignAttri("", false, "A1210ListHasta", context.localUtil.Format(A1210ListHasta, "99/99/99"));
            A1215ListTipo = T00186_A1215ListTipo[0];
            AssignAttri("", false, "A1215ListTipo", A1215ListTipo);
            A1213ListProdDsc = T00186_A1213ListProdDsc[0];
            AssignAttri("", false, "A1213ListProdDsc", A1213ListProdDsc);
            A1208ListCliDsc = T00186_A1208ListCliDsc[0];
            AssignAttri("", false, "A1208ListCliDsc", A1208ListCliDsc);
            A1206ListCantDesde = T00186_A1206ListCantDesde[0];
            A1207ListCantHasta = T00186_A1207ListCantHasta[0];
            A39ListProdCod = T00186_A39ListProdCod[0];
            n39ListProdCod = T00186_n39ListProdCod[0];
            AssignAttri("", false, "A39ListProdCod", A39ListProdCod);
            A38ListCliCod = T00186_A38ListCliCod[0];
            n38ListCliCod = T00186_n38ListCliCod[0];
            AssignAttri("", false, "A38ListCliCod", A38ListCliCod);
            ZM1842( -3) ;
         }
         pr_default.close(4);
         OnLoadActions1842( ) ;
      }

      protected void OnLoadActions1842( )
      {
      }

      protected void CheckExtendedTable1842( )
      {
         nIsDirty_42 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {n39ListProdCod, A39ListProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A39ListProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Descuento Producto'.", "ForeignKeyNotFound", 1, "LISTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtListProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1213ListProdDsc = T00184_A1213ListProdDsc[0];
         AssignAttri("", false, "A1213ListProdDsc", A1213ListProdDsc);
         pr_default.close(2);
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {n38ListCliCod, A38ListCliCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A38ListCliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Descuento Cliente'.", "ForeignKeyNotFound", 1, "LISTCLICOD");
               AnyError = 1;
               GX_FocusControl = edtListCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1208ListCliDsc = T00185_A1208ListCliDsc[0];
         AssignAttri("", false, "A1208ListCliDsc", A1208ListCliDsc);
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1209ListDesde) || ( DateTimeUtil.ResetTime ( A1209ListDesde ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Desde fuera de rango", "OutOfRange", 1, "LISTDESDE");
            AnyError = 1;
            GX_FocusControl = edtListDesde_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1210ListHasta) || ( DateTimeUtil.ResetTime ( A1210ListHasta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hasta fuera de rango", "OutOfRange", 1, "LISTHASTA");
            AnyError = 1;
            GX_FocusControl = edtListHasta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1842( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A39ListProdCod )
      {
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {n39ListProdCod, A39ListProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A39ListProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Descuento Producto'.", "ForeignKeyNotFound", 1, "LISTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtListProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1213ListProdDsc = T00187_A1213ListProdDsc[0];
         AssignAttri("", false, "A1213ListProdDsc", A1213ListProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1213ListProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( string A38ListCliCod )
      {
         /* Using cursor T00188 */
         pr_default.execute(6, new Object[] {n38ListCliCod, A38ListCliCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A38ListCliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Descuento Cliente'.", "ForeignKeyNotFound", 1, "LISTCLICOD");
               AnyError = 1;
               GX_FocusControl = edtListCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1208ListCliDsc = T00188_A1208ListCliDsc[0];
         AssignAttri("", false, "A1208ListCliDsc", A1208ListCliDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1208ListCliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1842( )
      {
         /* Using cursor T00189 */
         pr_default.execute(7, new Object[] {A37ListItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A37ListItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1842( 3) ;
            RcdFound42 = 1;
            A37ListItem = T00183_A37ListItem[0];
            AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
            A1214ListTipCli = T00183_A1214ListTipCli[0];
            AssignAttri("", false, "A1214ListTipCli", StringUtil.LTrimStr( (decimal)(A1214ListTipCli), 6, 0));
            A1211ListLinCod = T00183_A1211ListLinCod[0];
            n1211ListLinCod = T00183_n1211ListLinCod[0];
            AssignAttri("", false, "A1211ListLinCod", StringUtil.LTrimStr( (decimal)(A1211ListLinCod), 6, 0));
            A2262ListSubLCod = T00183_A2262ListSubLCod[0];
            A1212ListPorcentaje = T00183_A1212ListPorcentaje[0];
            AssignAttri("", false, "A1212ListPorcentaje", StringUtil.LTrimStr( A1212ListPorcentaje, 6, 2));
            A1209ListDesde = T00183_A1209ListDesde[0];
            AssignAttri("", false, "A1209ListDesde", context.localUtil.Format(A1209ListDesde, "99/99/99"));
            A1210ListHasta = T00183_A1210ListHasta[0];
            AssignAttri("", false, "A1210ListHasta", context.localUtil.Format(A1210ListHasta, "99/99/99"));
            A1215ListTipo = T00183_A1215ListTipo[0];
            AssignAttri("", false, "A1215ListTipo", A1215ListTipo);
            A1206ListCantDesde = T00183_A1206ListCantDesde[0];
            A1207ListCantHasta = T00183_A1207ListCantHasta[0];
            A39ListProdCod = T00183_A39ListProdCod[0];
            n39ListProdCod = T00183_n39ListProdCod[0];
            AssignAttri("", false, "A39ListProdCod", A39ListProdCod);
            A38ListCliCod = T00183_A38ListCliCod[0];
            n38ListCliCod = T00183_n38ListCliCod[0];
            AssignAttri("", false, "A38ListCliCod", A38ListCliCod);
            Z37ListItem = A37ListItem;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1842( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey1842( ) ;
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1842( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1842( ) ;
         if ( RcdFound42 == 0 )
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
         RcdFound42 = 0;
         /* Using cursor T001810 */
         pr_default.execute(8, new Object[] {A37ListItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001810_A37ListItem[0] < A37ListItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001810_A37ListItem[0] > A37ListItem ) ) )
            {
               A37ListItem = T001810_A37ListItem[0];
               AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound42 = 0;
         /* Using cursor T001811 */
         pr_default.execute(9, new Object[] {A37ListItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001811_A37ListItem[0] > A37ListItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001811_A37ListItem[0] < A37ListItem ) ) )
            {
               A37ListItem = T001811_A37ListItem[0];
               AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1842( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtListItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1842( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A37ListItem != Z37ListItem )
               {
                  A37ListItem = Z37ListItem;
                  AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LISTITEM");
                  AnyError = 1;
                  GX_FocusControl = edtListItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtListItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1842( ) ;
                  GX_FocusControl = edtListItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A37ListItem != Z37ListItem )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtListItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1842( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LISTITEM");
                     AnyError = 1;
                     GX_FocusControl = edtListItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtListItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1842( ) ;
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
         if ( A37ListItem != Z37ListItem )
         {
            A37ListItem = Z37ListItem;
            AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LISTITEM");
            AnyError = 1;
            GX_FocusControl = edtListItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtListItem_Internalname;
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
         GetKey1842( ) ;
         if ( RcdFound42 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LISTITEM");
               AnyError = 1;
               GX_FocusControl = edtListItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A37ListItem != Z37ListItem )
            {
               A37ListItem = Z37ListItem;
               AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LISTITEM");
               AnyError = 1;
               GX_FocusControl = edtListItem_Internalname;
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
            if ( A37ListItem != Z37ListItem )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LISTITEM");
                  AnyError = 1;
                  GX_FocusControl = edtListItem_Internalname;
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
         context.RollbackDataStores("alistadescuento",pr_default);
         GX_FocusControl = edtListTipCli_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_180( ) ;
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
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LISTITEM");
            AnyError = 1;
            GX_FocusControl = edtListItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtListTipCli_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1842( ) ;
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtListTipCli_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1842( ) ;
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
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtListTipCli_Internalname;
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
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtListTipCli_Internalname;
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
         ScanStart1842( ) ;
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound42 != 0 )
            {
               ScanNext1842( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtListTipCli_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1842( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1842( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A37ListItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ALISTADESCUENTO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1214ListTipCli != T00182_A1214ListTipCli[0] ) || ( Z1211ListLinCod != T00182_A1211ListLinCod[0] ) || ( Z2262ListSubLCod != T00182_A2262ListSubLCod[0] ) || ( Z1212ListPorcentaje != T00182_A1212ListPorcentaje[0] ) || ( DateTimeUtil.ResetTime ( Z1209ListDesde ) != DateTimeUtil.ResetTime ( T00182_A1209ListDesde[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z1210ListHasta ) != DateTimeUtil.ResetTime ( T00182_A1210ListHasta[0] ) ) || ( StringUtil.StrCmp(Z1215ListTipo, T00182_A1215ListTipo[0]) != 0 ) || ( Z1206ListCantDesde != T00182_A1206ListCantDesde[0] ) || ( Z1207ListCantHasta != T00182_A1207ListCantHasta[0] ) || ( StringUtil.StrCmp(Z39ListProdCod, T00182_A39ListProdCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z38ListCliCod, T00182_A38ListCliCod[0]) != 0 ) )
            {
               if ( Z1214ListTipCli != T00182_A1214ListTipCli[0] )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListTipCli");
                  GXUtil.WriteLogRaw("Old: ",Z1214ListTipCli);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1214ListTipCli[0]);
               }
               if ( Z1211ListLinCod != T00182_A1211ListLinCod[0] )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListLinCod");
                  GXUtil.WriteLogRaw("Old: ",Z1211ListLinCod);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1211ListLinCod[0]);
               }
               if ( Z2262ListSubLCod != T00182_A2262ListSubLCod[0] )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListSubLCod");
                  GXUtil.WriteLogRaw("Old: ",Z2262ListSubLCod);
                  GXUtil.WriteLogRaw("Current: ",T00182_A2262ListSubLCod[0]);
               }
               if ( Z1212ListPorcentaje != T00182_A1212ListPorcentaje[0] )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListPorcentaje");
                  GXUtil.WriteLogRaw("Old: ",Z1212ListPorcentaje);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1212ListPorcentaje[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1209ListDesde ) != DateTimeUtil.ResetTime ( T00182_A1209ListDesde[0] ) )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListDesde");
                  GXUtil.WriteLogRaw("Old: ",Z1209ListDesde);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1209ListDesde[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1210ListHasta ) != DateTimeUtil.ResetTime ( T00182_A1210ListHasta[0] ) )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListHasta");
                  GXUtil.WriteLogRaw("Old: ",Z1210ListHasta);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1210ListHasta[0]);
               }
               if ( StringUtil.StrCmp(Z1215ListTipo, T00182_A1215ListTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1215ListTipo);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1215ListTipo[0]);
               }
               if ( Z1206ListCantDesde != T00182_A1206ListCantDesde[0] )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListCantDesde");
                  GXUtil.WriteLogRaw("Old: ",Z1206ListCantDesde);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1206ListCantDesde[0]);
               }
               if ( Z1207ListCantHasta != T00182_A1207ListCantHasta[0] )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListCantHasta");
                  GXUtil.WriteLogRaw("Old: ",Z1207ListCantHasta);
                  GXUtil.WriteLogRaw("Current: ",T00182_A1207ListCantHasta[0]);
               }
               if ( StringUtil.StrCmp(Z39ListProdCod, T00182_A39ListProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z39ListProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00182_A39ListProdCod[0]);
               }
               if ( StringUtil.StrCmp(Z38ListCliCod, T00182_A38ListCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("alistadescuento:[seudo value changed for attri]"+"ListCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z38ListCliCod);
                  GXUtil.WriteLogRaw("Current: ",T00182_A38ListCliCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ALISTADESCUENTO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1842( )
      {
         BeforeValidate1842( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1842( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1842( 0) ;
            CheckOptimisticConcurrency1842( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1842( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1842( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001812 */
                     pr_default.execute(10, new Object[] {A37ListItem, A1214ListTipCli, n1211ListLinCod, A1211ListLinCod, A2262ListSubLCod, A1212ListPorcentaje, A1209ListDesde, A1210ListHasta, A1215ListTipo, A1206ListCantDesde, A1207ListCantHasta, n39ListProdCod, A39ListProdCod, n38ListCliCod, A38ListCliCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ALISTADESCUENTO");
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
                           ResetCaption180( ) ;
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
               Load1842( ) ;
            }
            EndLevel1842( ) ;
         }
         CloseExtendedTableCursors1842( ) ;
      }

      protected void Update1842( )
      {
         BeforeValidate1842( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1842( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1842( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1842( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1842( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001813 */
                     pr_default.execute(11, new Object[] {A1214ListTipCli, n1211ListLinCod, A1211ListLinCod, A2262ListSubLCod, A1212ListPorcentaje, A1209ListDesde, A1210ListHasta, A1215ListTipo, A1206ListCantDesde, A1207ListCantHasta, n39ListProdCod, A39ListProdCod, n38ListCliCod, A38ListCliCod, A37ListItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ALISTADESCUENTO");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ALISTADESCUENTO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1842( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption180( ) ;
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
            EndLevel1842( ) ;
         }
         CloseExtendedTableCursors1842( ) ;
      }

      protected void DeferredUpdate1842( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1842( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1842( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1842( ) ;
            AfterConfirm1842( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1842( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001814 */
                  pr_default.execute(12, new Object[] {A37ListItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ALISTADESCUENTO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound42 == 0 )
                        {
                           InitAll1842( ) ;
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
                        ResetCaption180( ) ;
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1842( ) ;
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1842( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001815 */
            pr_default.execute(13, new Object[] {n39ListProdCod, A39ListProdCod});
            A1213ListProdDsc = T001815_A1213ListProdDsc[0];
            AssignAttri("", false, "A1213ListProdDsc", A1213ListProdDsc);
            pr_default.close(13);
            /* Using cursor T001816 */
            pr_default.execute(14, new Object[] {n38ListCliCod, A38ListCliCod});
            A1208ListCliDsc = T001816_A1208ListCliDsc[0];
            AssignAttri("", false, "A1208ListCliDsc", A1208ListCliDsc);
            pr_default.close(14);
         }
      }

      protected void EndLevel1842( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1842( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("alistadescuento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
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
            context.RollbackDataStores("alistadescuento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1842( )
      {
         /* Using cursor T001817 */
         pr_default.execute(15);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound42 = 1;
            A37ListItem = T001817_A37ListItem[0];
            AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1842( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound42 = 1;
            A37ListItem = T001817_A37ListItem[0];
            AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
         }
      }

      protected void ScanEnd1842( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1842( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1842( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1842( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1842( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1842( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1842( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1842( )
      {
         edtListItem_Enabled = 0;
         AssignProp("", false, edtListItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListItem_Enabled), 5, 0), true);
         edtListTipCli_Enabled = 0;
         AssignProp("", false, edtListTipCli_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListTipCli_Enabled), 5, 0), true);
         edtListLinCod_Enabled = 0;
         AssignProp("", false, edtListLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListLinCod_Enabled), 5, 0), true);
         edtListProdCod_Enabled = 0;
         AssignProp("", false, edtListProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListProdCod_Enabled), 5, 0), true);
         edtListCliCod_Enabled = 0;
         AssignProp("", false, edtListCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListCliCod_Enabled), 5, 0), true);
         edtListPorcentaje_Enabled = 0;
         AssignProp("", false, edtListPorcentaje_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListPorcentaje_Enabled), 5, 0), true);
         edtListDesde_Enabled = 0;
         AssignProp("", false, edtListDesde_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListDesde_Enabled), 5, 0), true);
         edtListHasta_Enabled = 0;
         AssignProp("", false, edtListHasta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListHasta_Enabled), 5, 0), true);
         edtListTipo_Enabled = 0;
         AssignProp("", false, edtListTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListTipo_Enabled), 5, 0), true);
         edtListProdDsc_Enabled = 0;
         AssignProp("", false, edtListProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListProdDsc_Enabled), 5, 0), true);
         edtListCliDsc_Enabled = 0;
         AssignProp("", false, edtListCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListCliDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1842( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816422687", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("alistadescuento.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ALISTADESCUENTO");
         forbiddenHiddens.Add("ListSubLCod", context.localUtil.Format( (decimal)(A2262ListSubLCod), "ZZZZZ9"));
         forbiddenHiddens.Add("ListCantDesde", context.localUtil.Format( A1206ListCantDesde, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ListCantHasta", context.localUtil.Format( A1207ListCantHasta, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("alistadescuento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z37ListItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37ListItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1214ListTipCli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1214ListTipCli), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1211ListLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1211ListLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2262ListSubLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2262ListSubLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1212ListPorcentaje", StringUtil.LTrim( StringUtil.NToC( Z1212ListPorcentaje, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1209ListDesde", context.localUtil.DToC( Z1209ListDesde, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1210ListHasta", context.localUtil.DToC( Z1210ListHasta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1215ListTipo", StringUtil.RTrim( Z1215ListTipo));
         GxWebStd.gx_hidden_field( context, "Z1206ListCantDesde", StringUtil.LTrim( StringUtil.NToC( Z1206ListCantDesde, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1207ListCantHasta", StringUtil.LTrim( StringUtil.NToC( Z1207ListCantHasta, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z39ListProdCod", StringUtil.RTrim( Z39ListProdCod));
         GxWebStd.gx_hidden_field( context, "Z38ListCliCod", StringUtil.RTrim( Z38ListCliCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "LISTSUBLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2262ListSubLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LISTCANTDESDE", StringUtil.LTrim( StringUtil.NToC( A1206ListCantDesde, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "LISTCANTHASTA", StringUtil.LTrim( StringUtil.NToC( A1207ListCantHasta, 15, 2, ".", "")));
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
         return formatLink("alistadescuento.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ALISTADESCUENTO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lista de Descuentos" ;
      }

      protected void InitializeNonKey1842( )
      {
         A1214ListTipCli = 0;
         AssignAttri("", false, "A1214ListTipCli", StringUtil.LTrimStr( (decimal)(A1214ListTipCli), 6, 0));
         A1211ListLinCod = 0;
         n1211ListLinCod = false;
         AssignAttri("", false, "A1211ListLinCod", StringUtil.LTrimStr( (decimal)(A1211ListLinCod), 6, 0));
         A2262ListSubLCod = 0;
         AssignAttri("", false, "A2262ListSubLCod", StringUtil.LTrimStr( (decimal)(A2262ListSubLCod), 6, 0));
         A39ListProdCod = "";
         n39ListProdCod = false;
         AssignAttri("", false, "A39ListProdCod", A39ListProdCod);
         A38ListCliCod = "";
         n38ListCliCod = false;
         AssignAttri("", false, "A38ListCliCod", A38ListCliCod);
         A1212ListPorcentaje = 0;
         AssignAttri("", false, "A1212ListPorcentaje", StringUtil.LTrimStr( A1212ListPorcentaje, 6, 2));
         A1209ListDesde = DateTime.MinValue;
         AssignAttri("", false, "A1209ListDesde", context.localUtil.Format(A1209ListDesde, "99/99/99"));
         A1210ListHasta = DateTime.MinValue;
         AssignAttri("", false, "A1210ListHasta", context.localUtil.Format(A1210ListHasta, "99/99/99"));
         A1215ListTipo = "";
         AssignAttri("", false, "A1215ListTipo", A1215ListTipo);
         A1213ListProdDsc = "";
         AssignAttri("", false, "A1213ListProdDsc", A1213ListProdDsc);
         A1208ListCliDsc = "";
         AssignAttri("", false, "A1208ListCliDsc", A1208ListCliDsc);
         A1206ListCantDesde = 0;
         AssignAttri("", false, "A1206ListCantDesde", StringUtil.LTrimStr( A1206ListCantDesde, 15, 2));
         A1207ListCantHasta = 0;
         AssignAttri("", false, "A1207ListCantHasta", StringUtil.LTrimStr( A1207ListCantHasta, 15, 2));
         Z1214ListTipCli = 0;
         Z1211ListLinCod = 0;
         Z2262ListSubLCod = 0;
         Z1212ListPorcentaje = 0;
         Z1209ListDesde = DateTime.MinValue;
         Z1210ListHasta = DateTime.MinValue;
         Z1215ListTipo = "";
         Z1206ListCantDesde = 0;
         Z1207ListCantHasta = 0;
         Z39ListProdCod = "";
         Z38ListCliCod = "";
      }

      protected void InitAll1842( )
      {
         A37ListItem = 0;
         AssignAttri("", false, "A37ListItem", StringUtil.LTrimStr( (decimal)(A37ListItem), 6, 0));
         InitializeNonKey1842( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181642271", true, true);
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
         context.AddJavascriptSource("alistadescuento.js", "?20228181642271", false, true);
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
         edtListItem_Internalname = "LISTITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtListTipCli_Internalname = "LISTTIPCLI";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtListLinCod_Internalname = "LISTLINCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtListProdCod_Internalname = "LISTPRODCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtListCliCod_Internalname = "LISTCLICOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtListPorcentaje_Internalname = "LISTPORCENTAJE";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtListDesde_Internalname = "LISTDESDE";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtListHasta_Internalname = "LISTHASTA";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtListTipo_Internalname = "LISTTIPO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtListProdDsc_Internalname = "LISTPRODDSC";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtListCliDsc_Internalname = "LISTCLIDSC";
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
         Form.Caption = "Lista de Descuentos";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtListCliDsc_Jsonclick = "";
         edtListCliDsc_Enabled = 0;
         edtListProdDsc_Jsonclick = "";
         edtListProdDsc_Enabled = 0;
         edtListTipo_Jsonclick = "";
         edtListTipo_Enabled = 1;
         edtListHasta_Jsonclick = "";
         edtListHasta_Enabled = 1;
         edtListDesde_Jsonclick = "";
         edtListDesde_Enabled = 1;
         edtListPorcentaje_Jsonclick = "";
         edtListPorcentaje_Enabled = 1;
         edtListCliCod_Jsonclick = "";
         edtListCliCod_Enabled = 1;
         edtListProdCod_Jsonclick = "";
         edtListProdCod_Enabled = 1;
         edtListLinCod_Jsonclick = "";
         edtListLinCod_Enabled = 1;
         edtListTipCli_Jsonclick = "";
         edtListTipCli_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtListItem_Jsonclick = "";
         edtListItem_Enabled = 1;
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
         GX_FocusControl = edtListTipCli_Internalname;
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

      public void Valid_Listitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1214ListTipCli", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1214ListTipCli), 6, 0, ".", "")));
         AssignAttri("", false, "A1211ListLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1211ListLinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2262ListSubLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2262ListSubLCod), 6, 0, ".", "")));
         AssignAttri("", false, "A39ListProdCod", StringUtil.RTrim( A39ListProdCod));
         AssignAttri("", false, "A38ListCliCod", StringUtil.RTrim( A38ListCliCod));
         AssignAttri("", false, "A1212ListPorcentaje", StringUtil.LTrim( StringUtil.NToC( A1212ListPorcentaje, 6, 2, ".", "")));
         AssignAttri("", false, "A1209ListDesde", context.localUtil.Format(A1209ListDesde, "99/99/99"));
         AssignAttri("", false, "A1210ListHasta", context.localUtil.Format(A1210ListHasta, "99/99/99"));
         AssignAttri("", false, "A1215ListTipo", StringUtil.RTrim( A1215ListTipo));
         AssignAttri("", false, "A1206ListCantDesde", StringUtil.LTrim( StringUtil.NToC( A1206ListCantDesde, 15, 2, ".", "")));
         AssignAttri("", false, "A1207ListCantHasta", StringUtil.LTrim( StringUtil.NToC( A1207ListCantHasta, 15, 2, ".", "")));
         AssignAttri("", false, "A1213ListProdDsc", StringUtil.RTrim( A1213ListProdDsc));
         AssignAttri("", false, "A1208ListCliDsc", StringUtil.RTrim( A1208ListCliDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z37ListItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37ListItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1214ListTipCli", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1214ListTipCli), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1211ListLinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1211ListLinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2262ListSubLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2262ListSubLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z39ListProdCod", StringUtil.RTrim( Z39ListProdCod));
         GxWebStd.gx_hidden_field( context, "Z38ListCliCod", StringUtil.RTrim( Z38ListCliCod));
         GxWebStd.gx_hidden_field( context, "Z1212ListPorcentaje", StringUtil.LTrim( StringUtil.NToC( Z1212ListPorcentaje, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1209ListDesde", context.localUtil.Format(Z1209ListDesde, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1210ListHasta", context.localUtil.Format(Z1210ListHasta, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1215ListTipo", StringUtil.RTrim( Z1215ListTipo));
         GxWebStd.gx_hidden_field( context, "Z1206ListCantDesde", StringUtil.LTrim( StringUtil.NToC( Z1206ListCantDesde, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1207ListCantHasta", StringUtil.LTrim( StringUtil.NToC( Z1207ListCantHasta, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1213ListProdDsc", StringUtil.RTrim( Z1213ListProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1208ListCliDsc", StringUtil.RTrim( Z1208ListCliDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Listprodcod( )
      {
         n39ListProdCod = false;
         /* Using cursor T001815 */
         pr_default.execute(13, new Object[] {n39ListProdCod, A39ListProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A39ListProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Descuento Producto'.", "ForeignKeyNotFound", 1, "LISTPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtListProdCod_Internalname;
            }
         }
         A1213ListProdDsc = T001815_A1213ListProdDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1213ListProdDsc", StringUtil.RTrim( A1213ListProdDsc));
      }

      public void Valid_Listclicod( )
      {
         n38ListCliCod = false;
         /* Using cursor T001816 */
         pr_default.execute(14, new Object[] {n38ListCliCod, A38ListCliCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A38ListCliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Descuento Cliente'.", "ForeignKeyNotFound", 1, "LISTCLICOD");
               AnyError = 1;
               GX_FocusControl = edtListCliCod_Internalname;
            }
         }
         A1208ListCliDsc = T001816_A1208ListCliDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1208ListCliDsc", StringUtil.RTrim( A1208ListCliDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A2262ListSubLCod',fld:'LISTSUBLCOD',pic:'ZZZZZ9'},{av:'A1206ListCantDesde',fld:'LISTCANTDESDE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1207ListCantHasta',fld:'LISTCANTHASTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_LISTITEM","{handler:'Valid_Listitem',iparms:[{av:'A1207ListCantHasta',fld:'LISTCANTHASTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1206ListCantDesde',fld:'LISTCANTDESDE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2262ListSubLCod',fld:'LISTSUBLCOD',pic:'ZZZZZ9'},{av:'A37ListItem',fld:'LISTITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LISTITEM",",oparms:[{av:'A1214ListTipCli',fld:'LISTTIPCLI',pic:'ZZZZZ9'},{av:'A1211ListLinCod',fld:'LISTLINCOD',pic:'ZZZZZ9'},{av:'A2262ListSubLCod',fld:'LISTSUBLCOD',pic:'ZZZZZ9'},{av:'A39ListProdCod',fld:'LISTPRODCOD',pic:'@!'},{av:'A38ListCliCod',fld:'LISTCLICOD',pic:''},{av:'A1212ListPorcentaje',fld:'LISTPORCENTAJE',pic:'ZZ9.99'},{av:'A1209ListDesde',fld:'LISTDESDE',pic:''},{av:'A1210ListHasta',fld:'LISTHASTA',pic:''},{av:'A1215ListTipo',fld:'LISTTIPO',pic:''},{av:'A1206ListCantDesde',fld:'LISTCANTDESDE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1207ListCantHasta',fld:'LISTCANTHASTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1213ListProdDsc',fld:'LISTPRODDSC',pic:''},{av:'A1208ListCliDsc',fld:'LISTCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z37ListItem'},{av:'Z1214ListTipCli'},{av:'Z1211ListLinCod'},{av:'Z2262ListSubLCod'},{av:'Z39ListProdCod'},{av:'Z38ListCliCod'},{av:'Z1212ListPorcentaje'},{av:'Z1209ListDesde'},{av:'Z1210ListHasta'},{av:'Z1215ListTipo'},{av:'Z1206ListCantDesde'},{av:'Z1207ListCantHasta'},{av:'Z1213ListProdDsc'},{av:'Z1208ListCliDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_LISTPRODCOD","{handler:'Valid_Listprodcod',iparms:[{av:'A39ListProdCod',fld:'LISTPRODCOD',pic:'@!'},{av:'A1213ListProdDsc',fld:'LISTPRODDSC',pic:''}]");
         setEventMetadata("VALID_LISTPRODCOD",",oparms:[{av:'A1213ListProdDsc',fld:'LISTPRODDSC',pic:''}]}");
         setEventMetadata("VALID_LISTCLICOD","{handler:'Valid_Listclicod',iparms:[{av:'A38ListCliCod',fld:'LISTCLICOD',pic:''},{av:'A1208ListCliDsc',fld:'LISTCLIDSC',pic:''}]");
         setEventMetadata("VALID_LISTCLICOD",",oparms:[{av:'A1208ListCliDsc',fld:'LISTCLIDSC',pic:''}]}");
         setEventMetadata("VALID_LISTDESDE","{handler:'Valid_Listdesde',iparms:[]");
         setEventMetadata("VALID_LISTDESDE",",oparms:[]}");
         setEventMetadata("VALID_LISTHASTA","{handler:'Valid_Listhasta',iparms:[]");
         setEventMetadata("VALID_LISTHASTA",",oparms:[]}");
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
         Z1209ListDesde = DateTime.MinValue;
         Z1210ListHasta = DateTime.MinValue;
         Z1215ListTipo = "";
         Z39ListProdCod = "";
         Z38ListCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A39ListProdCod = "";
         A38ListCliCod = "";
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
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1209ListDesde = DateTime.MinValue;
         lblTextblock8_Jsonclick = "";
         A1210ListHasta = DateTime.MinValue;
         lblTextblock9_Jsonclick = "";
         A1215ListTipo = "";
         lblTextblock10_Jsonclick = "";
         A1213ListProdDsc = "";
         lblTextblock11_Jsonclick = "";
         A1208ListCliDsc = "";
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
         Z1213ListProdDsc = "";
         Z1208ListCliDsc = "";
         T00186_A37ListItem = new int[1] ;
         T00186_A1214ListTipCli = new int[1] ;
         T00186_A1211ListLinCod = new int[1] ;
         T00186_n1211ListLinCod = new bool[] {false} ;
         T00186_A2262ListSubLCod = new int[1] ;
         T00186_A1212ListPorcentaje = new decimal[1] ;
         T00186_A1209ListDesde = new DateTime[] {DateTime.MinValue} ;
         T00186_A1210ListHasta = new DateTime[] {DateTime.MinValue} ;
         T00186_A1215ListTipo = new string[] {""} ;
         T00186_A1213ListProdDsc = new string[] {""} ;
         T00186_A1208ListCliDsc = new string[] {""} ;
         T00186_A1206ListCantDesde = new decimal[1] ;
         T00186_A1207ListCantHasta = new decimal[1] ;
         T00186_A39ListProdCod = new string[] {""} ;
         T00186_n39ListProdCod = new bool[] {false} ;
         T00186_A38ListCliCod = new string[] {""} ;
         T00186_n38ListCliCod = new bool[] {false} ;
         T00184_A1213ListProdDsc = new string[] {""} ;
         T00185_A1208ListCliDsc = new string[] {""} ;
         T00187_A1213ListProdDsc = new string[] {""} ;
         T00188_A1208ListCliDsc = new string[] {""} ;
         T00189_A37ListItem = new int[1] ;
         T00183_A37ListItem = new int[1] ;
         T00183_A1214ListTipCli = new int[1] ;
         T00183_A1211ListLinCod = new int[1] ;
         T00183_n1211ListLinCod = new bool[] {false} ;
         T00183_A2262ListSubLCod = new int[1] ;
         T00183_A1212ListPorcentaje = new decimal[1] ;
         T00183_A1209ListDesde = new DateTime[] {DateTime.MinValue} ;
         T00183_A1210ListHasta = new DateTime[] {DateTime.MinValue} ;
         T00183_A1215ListTipo = new string[] {""} ;
         T00183_A1206ListCantDesde = new decimal[1] ;
         T00183_A1207ListCantHasta = new decimal[1] ;
         T00183_A39ListProdCod = new string[] {""} ;
         T00183_n39ListProdCod = new bool[] {false} ;
         T00183_A38ListCliCod = new string[] {""} ;
         T00183_n38ListCliCod = new bool[] {false} ;
         sMode42 = "";
         T001810_A37ListItem = new int[1] ;
         T001811_A37ListItem = new int[1] ;
         T00182_A37ListItem = new int[1] ;
         T00182_A1214ListTipCli = new int[1] ;
         T00182_A1211ListLinCod = new int[1] ;
         T00182_n1211ListLinCod = new bool[] {false} ;
         T00182_A2262ListSubLCod = new int[1] ;
         T00182_A1212ListPorcentaje = new decimal[1] ;
         T00182_A1209ListDesde = new DateTime[] {DateTime.MinValue} ;
         T00182_A1210ListHasta = new DateTime[] {DateTime.MinValue} ;
         T00182_A1215ListTipo = new string[] {""} ;
         T00182_A1206ListCantDesde = new decimal[1] ;
         T00182_A1207ListCantHasta = new decimal[1] ;
         T00182_A39ListProdCod = new string[] {""} ;
         T00182_n39ListProdCod = new bool[] {false} ;
         T00182_A38ListCliCod = new string[] {""} ;
         T00182_n38ListCliCod = new bool[] {false} ;
         T001815_A1213ListProdDsc = new string[] {""} ;
         T001816_A1208ListCliDsc = new string[] {""} ;
         T001817_A37ListItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ39ListProdCod = "";
         ZZ38ListCliCod = "";
         ZZ1209ListDesde = DateTime.MinValue;
         ZZ1210ListHasta = DateTime.MinValue;
         ZZ1215ListTipo = "";
         ZZ1213ListProdDsc = "";
         ZZ1208ListCliDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.alistadescuento__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadescuento__default(),
            new Object[][] {
                new Object[] {
               T00182_A37ListItem, T00182_A1214ListTipCli, T00182_A1211ListLinCod, T00182_n1211ListLinCod, T00182_A2262ListSubLCod, T00182_A1212ListPorcentaje, T00182_A1209ListDesde, T00182_A1210ListHasta, T00182_A1215ListTipo, T00182_A1206ListCantDesde,
               T00182_A1207ListCantHasta, T00182_A39ListProdCod, T00182_n39ListProdCod, T00182_A38ListCliCod, T00182_n38ListCliCod
               }
               , new Object[] {
               T00183_A37ListItem, T00183_A1214ListTipCli, T00183_A1211ListLinCod, T00183_n1211ListLinCod, T00183_A2262ListSubLCod, T00183_A1212ListPorcentaje, T00183_A1209ListDesde, T00183_A1210ListHasta, T00183_A1215ListTipo, T00183_A1206ListCantDesde,
               T00183_A1207ListCantHasta, T00183_A39ListProdCod, T00183_n39ListProdCod, T00183_A38ListCliCod, T00183_n38ListCliCod
               }
               , new Object[] {
               T00184_A1213ListProdDsc
               }
               , new Object[] {
               T00185_A1208ListCliDsc
               }
               , new Object[] {
               T00186_A37ListItem, T00186_A1214ListTipCli, T00186_A1211ListLinCod, T00186_n1211ListLinCod, T00186_A2262ListSubLCod, T00186_A1212ListPorcentaje, T00186_A1209ListDesde, T00186_A1210ListHasta, T00186_A1215ListTipo, T00186_A1213ListProdDsc,
               T00186_A1208ListCliDsc, T00186_A1206ListCantDesde, T00186_A1207ListCantHasta, T00186_A39ListProdCod, T00186_n39ListProdCod, T00186_A38ListCliCod, T00186_n38ListCliCod
               }
               , new Object[] {
               T00187_A1213ListProdDsc
               }
               , new Object[] {
               T00188_A1208ListCliDsc
               }
               , new Object[] {
               T00189_A37ListItem
               }
               , new Object[] {
               T001810_A37ListItem
               }
               , new Object[] {
               T001811_A37ListItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001815_A1213ListProdDsc
               }
               , new Object[] {
               T001816_A1208ListCliDsc
               }
               , new Object[] {
               T001817_A37ListItem
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
      private short RcdFound42 ;
      private short nIsDirty_42 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z37ListItem ;
      private int Z1214ListTipCli ;
      private int Z1211ListLinCod ;
      private int Z2262ListSubLCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A37ListItem ;
      private int edtListItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int A1214ListTipCli ;
      private int edtListTipCli_Enabled ;
      private int A1211ListLinCod ;
      private int edtListLinCod_Enabled ;
      private int edtListProdCod_Enabled ;
      private int edtListCliCod_Enabled ;
      private int edtListPorcentaje_Enabled ;
      private int edtListDesde_Enabled ;
      private int edtListHasta_Enabled ;
      private int edtListTipo_Enabled ;
      private int edtListProdDsc_Enabled ;
      private int edtListCliDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A2262ListSubLCod ;
      private int idxLst ;
      private int ZZ37ListItem ;
      private int ZZ1214ListTipCli ;
      private int ZZ1211ListLinCod ;
      private int ZZ2262ListSubLCod ;
      private decimal Z1212ListPorcentaje ;
      private decimal Z1206ListCantDesde ;
      private decimal Z1207ListCantHasta ;
      private decimal A1212ListPorcentaje ;
      private decimal A1206ListCantDesde ;
      private decimal A1207ListCantHasta ;
      private decimal ZZ1212ListPorcentaje ;
      private decimal ZZ1206ListCantDesde ;
      private decimal ZZ1207ListCantHasta ;
      private string sPrefix ;
      private string Z1215ListTipo ;
      private string Z39ListProdCod ;
      private string Z38ListCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A39ListProdCod ;
      private string A38ListCliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtListItem_Internalname ;
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
      private string edtListItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtListTipCli_Internalname ;
      private string edtListTipCli_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtListLinCod_Internalname ;
      private string edtListLinCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtListProdCod_Internalname ;
      private string edtListProdCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtListCliCod_Internalname ;
      private string edtListCliCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtListPorcentaje_Internalname ;
      private string edtListPorcentaje_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtListDesde_Internalname ;
      private string edtListDesde_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtListHasta_Internalname ;
      private string edtListHasta_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtListTipo_Internalname ;
      private string A1215ListTipo ;
      private string edtListTipo_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtListProdDsc_Internalname ;
      private string A1213ListProdDsc ;
      private string edtListProdDsc_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtListCliDsc_Internalname ;
      private string A1208ListCliDsc ;
      private string edtListCliDsc_Jsonclick ;
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
      private string Z1213ListProdDsc ;
      private string Z1208ListCliDsc ;
      private string sMode42 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ39ListProdCod ;
      private string ZZ38ListCliCod ;
      private string ZZ1215ListTipo ;
      private string ZZ1213ListProdDsc ;
      private string ZZ1208ListCliDsc ;
      private DateTime Z1209ListDesde ;
      private DateTime Z1210ListHasta ;
      private DateTime A1209ListDesde ;
      private DateTime A1210ListHasta ;
      private DateTime ZZ1209ListDesde ;
      private DateTime ZZ1210ListHasta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n39ListProdCod ;
      private bool n38ListCliCod ;
      private bool wbErr ;
      private bool n1211ListLinCod ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00186_A37ListItem ;
      private int[] T00186_A1214ListTipCli ;
      private int[] T00186_A1211ListLinCod ;
      private bool[] T00186_n1211ListLinCod ;
      private int[] T00186_A2262ListSubLCod ;
      private decimal[] T00186_A1212ListPorcentaje ;
      private DateTime[] T00186_A1209ListDesde ;
      private DateTime[] T00186_A1210ListHasta ;
      private string[] T00186_A1215ListTipo ;
      private string[] T00186_A1213ListProdDsc ;
      private string[] T00186_A1208ListCliDsc ;
      private decimal[] T00186_A1206ListCantDesde ;
      private decimal[] T00186_A1207ListCantHasta ;
      private string[] T00186_A39ListProdCod ;
      private bool[] T00186_n39ListProdCod ;
      private string[] T00186_A38ListCliCod ;
      private bool[] T00186_n38ListCliCod ;
      private string[] T00184_A1213ListProdDsc ;
      private string[] T00185_A1208ListCliDsc ;
      private string[] T00187_A1213ListProdDsc ;
      private string[] T00188_A1208ListCliDsc ;
      private int[] T00189_A37ListItem ;
      private int[] T00183_A37ListItem ;
      private int[] T00183_A1214ListTipCli ;
      private int[] T00183_A1211ListLinCod ;
      private bool[] T00183_n1211ListLinCod ;
      private int[] T00183_A2262ListSubLCod ;
      private decimal[] T00183_A1212ListPorcentaje ;
      private DateTime[] T00183_A1209ListDesde ;
      private DateTime[] T00183_A1210ListHasta ;
      private string[] T00183_A1215ListTipo ;
      private decimal[] T00183_A1206ListCantDesde ;
      private decimal[] T00183_A1207ListCantHasta ;
      private string[] T00183_A39ListProdCod ;
      private bool[] T00183_n39ListProdCod ;
      private string[] T00183_A38ListCliCod ;
      private bool[] T00183_n38ListCliCod ;
      private int[] T001810_A37ListItem ;
      private int[] T001811_A37ListItem ;
      private int[] T00182_A37ListItem ;
      private int[] T00182_A1214ListTipCli ;
      private int[] T00182_A1211ListLinCod ;
      private bool[] T00182_n1211ListLinCod ;
      private int[] T00182_A2262ListSubLCod ;
      private decimal[] T00182_A1212ListPorcentaje ;
      private DateTime[] T00182_A1209ListDesde ;
      private DateTime[] T00182_A1210ListHasta ;
      private string[] T00182_A1215ListTipo ;
      private decimal[] T00182_A1206ListCantDesde ;
      private decimal[] T00182_A1207ListCantHasta ;
      private string[] T00182_A39ListProdCod ;
      private bool[] T00182_n39ListProdCod ;
      private string[] T00182_A38ListCliCod ;
      private bool[] T00182_n38ListCliCod ;
      private string[] T001815_A1213ListProdDsc ;
      private string[] T001816_A1208ListCliDsc ;
      private int[] T001817_A37ListItem ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class alistadescuento__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class alistadescuento__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00186;
        prmT00186 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT00184;
        prmT00184 = new Object[] {
        new ParDef("@ListProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00185;
        prmT00185 = new Object[] {
        new ParDef("@ListCliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00187;
        prmT00187 = new Object[] {
        new ParDef("@ListProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00188;
        prmT00188 = new Object[] {
        new ParDef("@ListCliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00189;
        prmT00189 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT00183;
        prmT00183 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT001810;
        prmT001810 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT001811;
        prmT001811 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT00182;
        prmT00182 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT001812;
        prmT001812 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0) ,
        new ParDef("@ListTipCli",GXType.Int32,6,0) ,
        new ParDef("@ListLinCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ListSubLCod",GXType.Int32,6,0) ,
        new ParDef("@ListPorcentaje",GXType.Decimal,6,2) ,
        new ParDef("@ListDesde",GXType.Date,8,0) ,
        new ParDef("@ListHasta",GXType.Date,8,0) ,
        new ParDef("@ListTipo",GXType.NChar,1,0) ,
        new ParDef("@ListCantDesde",GXType.Decimal,15,2) ,
        new ParDef("@ListCantHasta",GXType.Decimal,15,2) ,
        new ParDef("@ListProdCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ListCliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001813;
        prmT001813 = new Object[] {
        new ParDef("@ListTipCli",GXType.Int32,6,0) ,
        new ParDef("@ListLinCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ListSubLCod",GXType.Int32,6,0) ,
        new ParDef("@ListPorcentaje",GXType.Decimal,6,2) ,
        new ParDef("@ListDesde",GXType.Date,8,0) ,
        new ParDef("@ListHasta",GXType.Date,8,0) ,
        new ParDef("@ListTipo",GXType.NChar,1,0) ,
        new ParDef("@ListCantDesde",GXType.Decimal,15,2) ,
        new ParDef("@ListCantHasta",GXType.Decimal,15,2) ,
        new ParDef("@ListProdCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ListCliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT001814;
        prmT001814 = new Object[] {
        new ParDef("@ListItem",GXType.Int32,6,0)
        };
        Object[] prmT001817;
        prmT001817 = new Object[] {
        };
        Object[] prmT001815;
        prmT001815 = new Object[] {
        new ParDef("@ListProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001816;
        prmT001816 = new Object[] {
        new ParDef("@ListCliCod",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00182", "SELECT [ListItem], [ListTipCli], [ListLinCod], [ListSubLCod], [ListPorcentaje], [ListDesde], [ListHasta], [ListTipo], [ListCantDesde], [ListCantHasta], [ListProdCod] AS ListProdCod, [ListCliCod] AS ListCliCod FROM [ALISTADESCUENTO] WITH (UPDLOCK) WHERE [ListItem] = @ListItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00183", "SELECT [ListItem], [ListTipCli], [ListLinCod], [ListSubLCod], [ListPorcentaje], [ListDesde], [ListHasta], [ListTipo], [ListCantDesde], [ListCantHasta], [ListProdCod] AS ListProdCod, [ListCliCod] AS ListCliCod FROM [ALISTADESCUENTO] WHERE [ListItem] = @ListItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00184", "SELECT [ProdDsc] AS ListProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ListProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00185", "SELECT [CliDsc] AS ListCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @ListCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00186", "SELECT TM1.[ListItem], TM1.[ListTipCli], TM1.[ListLinCod], TM1.[ListSubLCod], TM1.[ListPorcentaje], TM1.[ListDesde], TM1.[ListHasta], TM1.[ListTipo], T2.[ProdDsc] AS ListProdDsc, T3.[CliDsc] AS ListCliDsc, TM1.[ListCantDesde], TM1.[ListCantHasta], TM1.[ListProdCod] AS ListProdCod, TM1.[ListCliCod] AS ListCliCod FROM (([ALISTADESCUENTO] TM1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ListProdCod]) LEFT JOIN [CLCLIENTES] T3 ON T3.[CliCod] = TM1.[ListCliCod]) WHERE TM1.[ListItem] = @ListItem ORDER BY TM1.[ListItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00187", "SELECT [ProdDsc] AS ListProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ListProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00188", "SELECT [CliDsc] AS ListCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @ListCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00188,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00189", "SELECT [ListItem] FROM [ALISTADESCUENTO] WHERE [ListItem] = @ListItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00189,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001810", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE ( [ListItem] > @ListItem) ORDER BY [ListItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001811", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE ( [ListItem] < @ListItem) ORDER BY [ListItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001812", "INSERT INTO [ALISTADESCUENTO]([ListItem], [ListTipCli], [ListLinCod], [ListSubLCod], [ListPorcentaje], [ListDesde], [ListHasta], [ListTipo], [ListCantDesde], [ListCantHasta], [ListProdCod], [ListCliCod]) VALUES(@ListItem, @ListTipCli, @ListLinCod, @ListSubLCod, @ListPorcentaje, @ListDesde, @ListHasta, @ListTipo, @ListCantDesde, @ListCantHasta, @ListProdCod, @ListCliCod)", GxErrorMask.GX_NOMASK,prmT001812)
           ,new CursorDef("T001813", "UPDATE [ALISTADESCUENTO] SET [ListTipCli]=@ListTipCli, [ListLinCod]=@ListLinCod, [ListSubLCod]=@ListSubLCod, [ListPorcentaje]=@ListPorcentaje, [ListDesde]=@ListDesde, [ListHasta]=@ListHasta, [ListTipo]=@ListTipo, [ListCantDesde]=@ListCantDesde, [ListCantHasta]=@ListCantHasta, [ListProdCod]=@ListProdCod, [ListCliCod]=@ListCliCod  WHERE [ListItem] = @ListItem", GxErrorMask.GX_NOMASK,prmT001813)
           ,new CursorDef("T001814", "DELETE FROM [ALISTADESCUENTO]  WHERE [ListItem] = @ListItem", GxErrorMask.GX_NOMASK,prmT001814)
           ,new CursorDef("T001815", "SELECT [ProdDsc] AS ListProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ListProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001816", "SELECT [CliDsc] AS ListCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @ListCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001816,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001817", "SELECT [ListItem] FROM [ALISTADESCUENTO] ORDER BY [ListItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001817,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 1);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 15);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 1);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 15);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 1);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((string[]) buf[10])[0] = rslt.getString(10, 100);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 15);
              ((bool[]) buf[14])[0] = rslt.wasNull(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(14);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
