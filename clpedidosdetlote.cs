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
   public class clpedidosdetlote : GXDataArea
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
            A210PedCod = GetPar( "PedCod");
            AssignAttri("", false, "A210PedCod", A210PedCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A210PedCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A28ProdCod = GetPar( "ProdCod");
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A28ProdCod) ;
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
            Form.Meta.addItem("description", "CLPEDIDOSDETLOTE", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clpedidosdetlote( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpedidosdetlote( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLPEDIDOSDETLOTE.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pedido", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedCod_Internalname, StringUtil.RTrim( A210PedCod), StringUtil.RTrim( context.localUtil.Format( A210PedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Producto", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Referencia 1", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDLRef1_Internalname, A217PedDLRef1, StringUtil.RTrim( context.localUtil.Format( A217PedDLRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDLRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDLRef1_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Referencia 2", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedDLRef2_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedDLRef2_Internalname, context.localUtil.Format(A1569PedDLRef2, "99/99/99"), context.localUtil.Format( A1569PedDLRef2, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDLRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDLRef2_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOSDETLOTE.htm");
         GxWebStd.gx_bitmap( context, edtPedDLRef2_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedDLRef2_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Referencia 3", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDLRef3_Internalname, A1570PedDLRef3, StringUtil.RTrim( context.localUtil.Format( A1570PedDLRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDLRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDLRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Referencia 4", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDLRef4_Internalname, A1571PedDLRef4, StringUtil.RTrim( context.localUtil.Format( A1571PedDLRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDLRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDLRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Cantidad", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedDLCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1568PedDLCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtPedDLCant_Enabled!=0) ? context.localUtil.Format( A1568PedDLCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1568PedDLCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDLCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDLCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Almacen", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOSDETLOTE.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1544PedAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPedAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1544PedAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1544PedAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOSDETLOTE.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOSDETLOTE.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLPEDIDOSDETLOTE.htm");
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
            Z210PedCod = cgiGet( "Z210PedCod");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z217PedDLRef1 = cgiGet( "Z217PedDLRef1");
            Z1569PedDLRef2 = context.localUtil.CToD( cgiGet( "Z1569PedDLRef2"), 0);
            Z1570PedDLRef3 = cgiGet( "Z1570PedDLRef3");
            Z1571PedDLRef4 = cgiGet( "Z1571PedDLRef4");
            Z1568PedDLCant = context.localUtil.CToN( cgiGet( "Z1568PedDLCant"), ".", ",");
            Z1544PedAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z1544PedAlmCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A210PedCod = cgiGet( edtPedCod_Internalname);
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A217PedDLRef1 = cgiGet( edtPedDLRef1_Internalname);
            AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
            if ( context.localUtil.VCDate( cgiGet( edtPedDLRef2_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Referencia 2"}), 1, "PEDDLREF2");
               AnyError = 1;
               GX_FocusControl = edtPedDLRef2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1569PedDLRef2 = DateTime.MinValue;
               AssignAttri("", false, "A1569PedDLRef2", context.localUtil.Format(A1569PedDLRef2, "99/99/99"));
            }
            else
            {
               A1569PedDLRef2 = context.localUtil.CToD( cgiGet( edtPedDLRef2_Internalname), 2);
               AssignAttri("", false, "A1569PedDLRef2", context.localUtil.Format(A1569PedDLRef2, "99/99/99"));
            }
            A1570PedDLRef3 = cgiGet( edtPedDLRef3_Internalname);
            AssignAttri("", false, "A1570PedDLRef3", A1570PedDLRef3);
            A1571PedDLRef4 = cgiGet( edtPedDLRef4_Internalname);
            AssignAttri("", false, "A1571PedDLRef4", A1571PedDLRef4);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedDLCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedDLCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDDLCANT");
               AnyError = 1;
               GX_FocusControl = edtPedDLCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1568PedDLCant = 0;
               AssignAttri("", false, "A1568PedDLCant", StringUtil.LTrimStr( A1568PedDLCant, 15, 4));
            }
            else
            {
               A1568PedDLCant = context.localUtil.CToN( cgiGet( edtPedDLCant_Internalname), ".", ",");
               AssignAttri("", false, "A1568PedDLCant", StringUtil.LTrimStr( A1568PedDLCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDALMCOD");
               AnyError = 1;
               GX_FocusControl = edtPedAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1544PedAlmCod = 0;
               AssignAttri("", false, "A1544PedAlmCod", StringUtil.LTrimStr( (decimal)(A1544PedAlmCod), 6, 0));
            }
            else
            {
               A1544PedAlmCod = (int)(context.localUtil.CToN( cgiGet( edtPedAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A1544PedAlmCod", StringUtil.LTrimStr( (decimal)(A1544PedAlmCod), 6, 0));
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
               A210PedCod = GetPar( "PedCod");
               AssignAttri("", false, "A210PedCod", A210PedCod);
               A28ProdCod = GetPar( "ProdCod");
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A217PedDLRef1 = GetPar( "PedDLRef1");
               AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
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
               InitAll2U97( ) ;
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
         DisableAttributes2U97( ) ;
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

      protected void CONFIRM_2U0( )
      {
         BeforeValidate2U97( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2U97( ) ;
            }
            else
            {
               CheckExtendedTable2U97( ) ;
               if ( AnyError == 0 )
               {
                  ZM2U97( 3) ;
                  ZM2U97( 4) ;
               }
               CloseExtendedTableCursors2U97( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2U0( ) ;
         }
      }

      protected void ResetCaption2U0( )
      {
      }

      protected void ZM2U97( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1569PedDLRef2 = T002U3_A1569PedDLRef2[0];
               Z1570PedDLRef3 = T002U3_A1570PedDLRef3[0];
               Z1571PedDLRef4 = T002U3_A1571PedDLRef4[0];
               Z1568PedDLCant = T002U3_A1568PedDLCant[0];
               Z1544PedAlmCod = T002U3_A1544PedAlmCod[0];
            }
            else
            {
               Z1569PedDLRef2 = A1569PedDLRef2;
               Z1570PedDLRef3 = A1570PedDLRef3;
               Z1571PedDLRef4 = A1571PedDLRef4;
               Z1568PedDLCant = A1568PedDLCant;
               Z1544PedAlmCod = A1544PedAlmCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z217PedDLRef1 = A217PedDLRef1;
            Z1569PedDLRef2 = A1569PedDLRef2;
            Z1570PedDLRef3 = A1570PedDLRef3;
            Z1571PedDLRef4 = A1571PedDLRef4;
            Z1568PedDLCant = A1568PedDLCant;
            Z1544PedAlmCod = A1544PedAlmCod;
            Z210PedCod = A210PedCod;
            Z28ProdCod = A28ProdCod;
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

      protected void Load2U97( )
      {
         /* Using cursor T002U6 */
         pr_default.execute(4, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound97 = 1;
            A1569PedDLRef2 = T002U6_A1569PedDLRef2[0];
            AssignAttri("", false, "A1569PedDLRef2", context.localUtil.Format(A1569PedDLRef2, "99/99/99"));
            A1570PedDLRef3 = T002U6_A1570PedDLRef3[0];
            AssignAttri("", false, "A1570PedDLRef3", A1570PedDLRef3);
            A1571PedDLRef4 = T002U6_A1571PedDLRef4[0];
            AssignAttri("", false, "A1571PedDLRef4", A1571PedDLRef4);
            A1568PedDLCant = T002U6_A1568PedDLCant[0];
            AssignAttri("", false, "A1568PedDLCant", StringUtil.LTrimStr( A1568PedDLCant, 15, 4));
            A1544PedAlmCod = T002U6_A1544PedAlmCod[0];
            AssignAttri("", false, "A1544PedAlmCod", StringUtil.LTrimStr( (decimal)(A1544PedAlmCod), 6, 0));
            ZM2U97( -2) ;
         }
         pr_default.close(4);
         OnLoadActions2U97( ) ;
      }

      protected void OnLoadActions2U97( )
      {
      }

      protected void CheckExtendedTable2U97( )
      {
         nIsDirty_97 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002U4 */
         pr_default.execute(2, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002U5 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1569PedDLRef2) || ( DateTimeUtil.ResetTime ( A1569PedDLRef2 ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Referencia 2 fuera de rango", "OutOfRange", 1, "PEDDLREF2");
            AnyError = 1;
            GX_FocusControl = edtPedDLRef2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2U97( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A210PedCod )
      {
         /* Using cursor T002U7 */
         pr_default.execute(5, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
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

      protected void gxLoad_4( string A28ProdCod )
      {
         /* Using cursor T002U8 */
         pr_default.execute(6, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
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

      protected void GetKey2U97( )
      {
         /* Using cursor T002U9 */
         pr_default.execute(7, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound97 = 1;
         }
         else
         {
            RcdFound97 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002U3 */
         pr_default.execute(1, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2U97( 2) ;
            RcdFound97 = 1;
            A217PedDLRef1 = T002U3_A217PedDLRef1[0];
            AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
            A1569PedDLRef2 = T002U3_A1569PedDLRef2[0];
            AssignAttri("", false, "A1569PedDLRef2", context.localUtil.Format(A1569PedDLRef2, "99/99/99"));
            A1570PedDLRef3 = T002U3_A1570PedDLRef3[0];
            AssignAttri("", false, "A1570PedDLRef3", A1570PedDLRef3);
            A1571PedDLRef4 = T002U3_A1571PedDLRef4[0];
            AssignAttri("", false, "A1571PedDLRef4", A1571PedDLRef4);
            A1568PedDLCant = T002U3_A1568PedDLCant[0];
            AssignAttri("", false, "A1568PedDLCant", StringUtil.LTrimStr( A1568PedDLCant, 15, 4));
            A1544PedAlmCod = T002U3_A1544PedAlmCod[0];
            AssignAttri("", false, "A1544PedAlmCod", StringUtil.LTrimStr( (decimal)(A1544PedAlmCod), 6, 0));
            A210PedCod = T002U3_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A28ProdCod = T002U3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            Z210PedCod = A210PedCod;
            Z28ProdCod = A28ProdCod;
            Z217PedDLRef1 = A217PedDLRef1;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2U97( ) ;
            if ( AnyError == 1 )
            {
               RcdFound97 = 0;
               InitializeNonKey2U97( ) ;
            }
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound97 = 0;
            InitializeNonKey2U97( ) ;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode97;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2U97( ) ;
         if ( RcdFound97 == 0 )
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
         RcdFound97 = 0;
         /* Using cursor T002U10 */
         pr_default.execute(8, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002U10_A210PedCod[0], A210PedCod) < 0 ) || ( StringUtil.StrCmp(T002U10_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U10_A28ProdCod[0], A28ProdCod) < 0 ) || ( StringUtil.StrCmp(T002U10_A28ProdCod[0], A28ProdCod) == 0 ) && ( StringUtil.StrCmp(T002U10_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U10_A217PedDLRef1[0], A217PedDLRef1) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002U10_A210PedCod[0], A210PedCod) > 0 ) || ( StringUtil.StrCmp(T002U10_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U10_A28ProdCod[0], A28ProdCod) > 0 ) || ( StringUtil.StrCmp(T002U10_A28ProdCod[0], A28ProdCod) == 0 ) && ( StringUtil.StrCmp(T002U10_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U10_A217PedDLRef1[0], A217PedDLRef1) > 0 ) ) )
            {
               A210PedCod = T002U10_A210PedCod[0];
               AssignAttri("", false, "A210PedCod", A210PedCod);
               A28ProdCod = T002U10_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A217PedDLRef1 = T002U10_A217PedDLRef1[0];
               AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
               RcdFound97 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound97 = 0;
         /* Using cursor T002U11 */
         pr_default.execute(9, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002U11_A210PedCod[0], A210PedCod) > 0 ) || ( StringUtil.StrCmp(T002U11_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U11_A28ProdCod[0], A28ProdCod) > 0 ) || ( StringUtil.StrCmp(T002U11_A28ProdCod[0], A28ProdCod) == 0 ) && ( StringUtil.StrCmp(T002U11_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U11_A217PedDLRef1[0], A217PedDLRef1) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002U11_A210PedCod[0], A210PedCod) < 0 ) || ( StringUtil.StrCmp(T002U11_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U11_A28ProdCod[0], A28ProdCod) < 0 ) || ( StringUtil.StrCmp(T002U11_A28ProdCod[0], A28ProdCod) == 0 ) && ( StringUtil.StrCmp(T002U11_A210PedCod[0], A210PedCod) == 0 ) && ( StringUtil.StrCmp(T002U11_A217PedDLRef1[0], A217PedDLRef1) < 0 ) ) )
            {
               A210PedCod = T002U11_A210PedCod[0];
               AssignAttri("", false, "A210PedCod", A210PedCod);
               A28ProdCod = T002U11_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A217PedDLRef1 = T002U11_A217PedDLRef1[0];
               AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
               RcdFound97 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2U97( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2U97( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound97 == 1 )
            {
               if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A217PedDLRef1, Z217PedDLRef1) != 0 ) )
               {
                  A210PedCod = Z210PedCod;
                  AssignAttri("", false, "A210PedCod", A210PedCod);
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
                  A217PedDLRef1 = Z217PedDLRef1;
                  AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2U97( ) ;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A217PedDLRef1, Z217PedDLRef1) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2U97( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PEDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2U97( ) ;
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
         if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A217PedDLRef1, Z217PedDLRef1) != 0 ) )
         {
            A210PedCod = Z210PedCod;
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A217PedDLRef1 = Z217PedDLRef1;
            AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPedCod_Internalname;
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
         GetKey2U97( ) ;
         if ( RcdFound97 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PEDCOD");
               AnyError = 1;
               GX_FocusControl = edtPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A217PedDLRef1, Z217PedDLRef1) != 0 ) )
            {
               A210PedCod = Z210PedCod;
               AssignAttri("", false, "A210PedCod", A210PedCod);
               A28ProdCod = Z28ProdCod;
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               A217PedDLRef1 = Z217PedDLRef1;
               AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PEDCOD");
               AnyError = 1;
               GX_FocusControl = edtPedCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) || ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) || ( StringUtil.StrCmp(A217PedDLRef1, Z217PedDLRef1) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtPedCod_Internalname;
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
         context.RollbackDataStores("clpedidosdetlote",pr_default);
         GX_FocusControl = edtPedDLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2U0( ) ;
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
         if ( RcdFound97 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPedDLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2U97( ) ;
         if ( RcdFound97 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedDLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2U97( ) ;
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
         if ( RcdFound97 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedDLRef2_Internalname;
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
         if ( RcdFound97 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedDLRef2_Internalname;
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
         ScanStart2U97( ) ;
         if ( RcdFound97 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound97 != 0 )
            {
               ScanNext2U97( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedDLRef2_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2U97( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2U97( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002U2 */
            pr_default.execute(0, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOSDETLOTE"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1569PedDLRef2 ) != DateTimeUtil.ResetTime ( T002U2_A1569PedDLRef2[0] ) ) || ( StringUtil.StrCmp(Z1570PedDLRef3, T002U2_A1570PedDLRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1571PedDLRef4, T002U2_A1571PedDLRef4[0]) != 0 ) || ( Z1568PedDLCant != T002U2_A1568PedDLCant[0] ) || ( Z1544PedAlmCod != T002U2_A1544PedAlmCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1569PedDLRef2 ) != DateTimeUtil.ResetTime ( T002U2_A1569PedDLRef2[0] ) )
               {
                  GXUtil.WriteLog("clpedidosdetlote:[seudo value changed for attri]"+"PedDLRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1569PedDLRef2);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A1569PedDLRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1570PedDLRef3, T002U2_A1570PedDLRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdetlote:[seudo value changed for attri]"+"PedDLRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1570PedDLRef3);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A1570PedDLRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1571PedDLRef4, T002U2_A1571PedDLRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidosdetlote:[seudo value changed for attri]"+"PedDLRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1571PedDLRef4);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A1571PedDLRef4[0]);
               }
               if ( Z1568PedDLCant != T002U2_A1568PedDLCant[0] )
               {
                  GXUtil.WriteLog("clpedidosdetlote:[seudo value changed for attri]"+"PedDLCant");
                  GXUtil.WriteLogRaw("Old: ",Z1568PedDLCant);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A1568PedDLCant[0]);
               }
               if ( Z1544PedAlmCod != T002U2_A1544PedAlmCod[0] )
               {
                  GXUtil.WriteLog("clpedidosdetlote:[seudo value changed for attri]"+"PedAlmCod");
                  GXUtil.WriteLogRaw("Old: ",Z1544PedAlmCod);
                  GXUtil.WriteLogRaw("Current: ",T002U2_A1544PedAlmCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLPEDIDOSDETLOTE"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2U97( )
      {
         BeforeValidate2U97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U97( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2U97( 0) ;
            CheckOptimisticConcurrency2U97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2U97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U12 */
                     pr_default.execute(10, new Object[] {A217PedDLRef1, A1569PedDLRef2, A1570PedDLRef3, A1571PedDLRef4, A1568PedDLCant, A1544PedAlmCod, A210PedCod, A28ProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDETLOTE");
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
                           ResetCaption2U0( ) ;
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
               Load2U97( ) ;
            }
            EndLevel2U97( ) ;
         }
         CloseExtendedTableCursors2U97( ) ;
      }

      protected void Update2U97( )
      {
         BeforeValidate2U97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U97( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2U97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002U13 */
                     pr_default.execute(11, new Object[] {A1569PedDLRef2, A1570PedDLRef3, A1571PedDLRef4, A1568PedDLCant, A1544PedAlmCod, A210PedCod, A28ProdCod, A217PedDLRef1});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDETLOTE");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOSDETLOTE"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2U97( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2U0( ) ;
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
            EndLevel2U97( ) ;
         }
         CloseExtendedTableCursors2U97( ) ;
      }

      protected void DeferredUpdate2U97( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2U97( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U97( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2U97( ) ;
            AfterConfirm2U97( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2U97( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002U14 */
                  pr_default.execute(12, new Object[] {A210PedCod, A28ProdCod, A217PedDLRef1});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDETLOTE");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound97 == 0 )
                        {
                           InitAll2U97( ) ;
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
                        ResetCaption2U0( ) ;
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
         sMode97 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2U97( ) ;
         Gx_mode = sMode97;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2U97( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2U97( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2U97( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clpedidosdetlote",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clpedidosdetlote",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2U97( )
      {
         /* Using cursor T002U15 */
         pr_default.execute(13);
         RcdFound97 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound97 = 1;
            A210PedCod = T002U15_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A28ProdCod = T002U15_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A217PedDLRef1 = T002U15_A217PedDLRef1[0];
            AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2U97( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound97 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound97 = 1;
            A210PedCod = T002U15_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A28ProdCod = T002U15_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A217PedDLRef1 = T002U15_A217PedDLRef1[0];
            AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
         }
      }

      protected void ScanEnd2U97( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2U97( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2U97( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2U97( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2U97( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2U97( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2U97( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2U97( )
      {
         edtPedCod_Enabled = 0;
         AssignProp("", false, edtPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedCod_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtPedDLRef1_Enabled = 0;
         AssignProp("", false, edtPedDLRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDLRef1_Enabled), 5, 0), true);
         edtPedDLRef2_Enabled = 0;
         AssignProp("", false, edtPedDLRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDLRef2_Enabled), 5, 0), true);
         edtPedDLRef3_Enabled = 0;
         AssignProp("", false, edtPedDLRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDLRef3_Enabled), 5, 0), true);
         edtPedDLRef4_Enabled = 0;
         AssignProp("", false, edtPedDLRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDLRef4_Enabled), 5, 0), true);
         edtPedDLCant_Enabled = 0;
         AssignProp("", false, edtPedDLCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDLCant_Enabled), 5, 0), true);
         edtPedAlmCod_Enabled = 0;
         AssignProp("", false, edtPedAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedAlmCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2U97( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2U0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810244672", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clpedidosdetlote.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z210PedCod", StringUtil.RTrim( Z210PedCod));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z217PedDLRef1", Z217PedDLRef1);
         GxWebStd.gx_hidden_field( context, "Z1569PedDLRef2", context.localUtil.DToC( Z1569PedDLRef2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1570PedDLRef3", Z1570PedDLRef3);
         GxWebStd.gx_hidden_field( context, "Z1571PedDLRef4", Z1571PedDLRef4);
         GxWebStd.gx_hidden_field( context, "Z1568PedDLCant", StringUtil.LTrim( StringUtil.NToC( Z1568PedDLCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1544PedAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1544PedAlmCod), 6, 0, ".", "")));
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
         return formatLink("clpedidosdetlote.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLPEDIDOSDETLOTE" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLPEDIDOSDETLOTE" ;
      }

      protected void InitializeNonKey2U97( )
      {
         A1569PedDLRef2 = DateTime.MinValue;
         AssignAttri("", false, "A1569PedDLRef2", context.localUtil.Format(A1569PedDLRef2, "99/99/99"));
         A1570PedDLRef3 = "";
         AssignAttri("", false, "A1570PedDLRef3", A1570PedDLRef3);
         A1571PedDLRef4 = "";
         AssignAttri("", false, "A1571PedDLRef4", A1571PedDLRef4);
         A1568PedDLCant = 0;
         AssignAttri("", false, "A1568PedDLCant", StringUtil.LTrimStr( A1568PedDLCant, 15, 4));
         A1544PedAlmCod = 0;
         AssignAttri("", false, "A1544PedAlmCod", StringUtil.LTrimStr( (decimal)(A1544PedAlmCod), 6, 0));
         Z1569PedDLRef2 = DateTime.MinValue;
         Z1570PedDLRef3 = "";
         Z1571PedDLRef4 = "";
         Z1568PedDLCant = 0;
         Z1544PedAlmCod = 0;
      }

      protected void InitAll2U97( )
      {
         A210PedCod = "";
         AssignAttri("", false, "A210PedCod", A210PedCod);
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A217PedDLRef1 = "";
         AssignAttri("", false, "A217PedDLRef1", A217PedDLRef1);
         InitializeNonKey2U97( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810244680", true, true);
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
         context.AddJavascriptSource("clpedidosdetlote.js", "?202281810244680", false, true);
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
         edtPedCod_Internalname = "PEDCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPedDLRef1_Internalname = "PEDDLREF1";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPedDLRef2_Internalname = "PEDDLREF2";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPedDLRef3_Internalname = "PEDDLREF3";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPedDLRef4_Internalname = "PEDDLREF4";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPedDLCant_Internalname = "PEDDLCANT";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPedAlmCod_Internalname = "PEDALMCOD";
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
         Form.Caption = "CLPEDIDOSDETLOTE";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPedAlmCod_Jsonclick = "";
         edtPedAlmCod_Enabled = 1;
         edtPedDLCant_Jsonclick = "";
         edtPedDLCant_Enabled = 1;
         edtPedDLRef4_Jsonclick = "";
         edtPedDLRef4_Enabled = 1;
         edtPedDLRef3_Jsonclick = "";
         edtPedDLRef3_Enabled = 1;
         edtPedDLRef2_Jsonclick = "";
         edtPedDLRef2_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPedDLRef1_Jsonclick = "";
         edtPedDLRef1_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         edtPedCod_Jsonclick = "";
         edtPedCod_Enabled = 1;
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
         /* Using cursor T002U16 */
         pr_default.execute(14, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T002U17 */
         pr_default.execute(15, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtPedDLRef2_Internalname;
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

      public void Valid_Pedcod( )
      {
         /* Using cursor T002U16 */
         pr_default.execute(14, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Pedidos'.", "ForeignKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T002U17 */
         pr_default.execute(15, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Peddlref1( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1569PedDLRef2", context.localUtil.Format(A1569PedDLRef2, "99/99/99"));
         AssignAttri("", false, "A1570PedDLRef3", A1570PedDLRef3);
         AssignAttri("", false, "A1571PedDLRef4", A1571PedDLRef4);
         AssignAttri("", false, "A1568PedDLCant", StringUtil.LTrim( StringUtil.NToC( A1568PedDLCant, 15, 4, ".", "")));
         AssignAttri("", false, "A1544PedAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1544PedAlmCod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z210PedCod", StringUtil.RTrim( Z210PedCod));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z217PedDLRef1", Z217PedDLRef1);
         GxWebStd.gx_hidden_field( context, "Z1569PedDLRef2", context.localUtil.Format(Z1569PedDLRef2, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1570PedDLRef3", Z1570PedDLRef3);
         GxWebStd.gx_hidden_field( context, "Z1571PedDLRef4", Z1571PedDLRef4);
         GxWebStd.gx_hidden_field( context, "Z1568PedDLCant", StringUtil.LTrim( StringUtil.NToC( Z1568PedDLCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1544PedAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1544PedAlmCod), 6, 0, ".", "")));
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
         setEventMetadata("VALID_PEDCOD","{handler:'Valid_Pedcod',iparms:[{av:'A210PedCod',fld:'PEDCOD',pic:''}]");
         setEventMetadata("VALID_PEDCOD",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[]}");
         setEventMetadata("VALID_PEDDLREF1","{handler:'Valid_Peddlref1',iparms:[{av:'A210PedCod',fld:'PEDCOD',pic:''},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A217PedDLRef1',fld:'PEDDLREF1',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PEDDLREF1",",oparms:[{av:'A1569PedDLRef2',fld:'PEDDLREF2',pic:''},{av:'A1570PedDLRef3',fld:'PEDDLREF3',pic:''},{av:'A1571PedDLRef4',fld:'PEDDLREF4',pic:''},{av:'A1568PedDLCant',fld:'PEDDLCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1544PedAlmCod',fld:'PEDALMCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z210PedCod'},{av:'Z28ProdCod'},{av:'Z217PedDLRef1'},{av:'Z1569PedDLRef2'},{av:'Z1570PedDLRef3'},{av:'Z1571PedDLRef4'},{av:'Z1568PedDLCant'},{av:'Z1544PedAlmCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PEDDLREF2","{handler:'Valid_Peddlref2',iparms:[]");
         setEventMetadata("VALID_PEDDLREF2",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z210PedCod = "";
         Z28ProdCod = "";
         Z217PedDLRef1 = "";
         Z1569PedDLRef2 = DateTime.MinValue;
         Z1570PedDLRef3 = "";
         Z1571PedDLRef4 = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A210PedCod = "";
         A28ProdCod = "";
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
         A217PedDLRef1 = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1569PedDLRef2 = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A1570PedDLRef3 = "";
         lblTextblock6_Jsonclick = "";
         A1571PedDLRef4 = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
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
         T002U6_A217PedDLRef1 = new string[] {""} ;
         T002U6_A1569PedDLRef2 = new DateTime[] {DateTime.MinValue} ;
         T002U6_A1570PedDLRef3 = new string[] {""} ;
         T002U6_A1571PedDLRef4 = new string[] {""} ;
         T002U6_A1568PedDLCant = new decimal[1] ;
         T002U6_A1544PedAlmCod = new int[1] ;
         T002U6_A210PedCod = new string[] {""} ;
         T002U6_A28ProdCod = new string[] {""} ;
         T002U4_A210PedCod = new string[] {""} ;
         T002U5_A28ProdCod = new string[] {""} ;
         T002U7_A210PedCod = new string[] {""} ;
         T002U8_A28ProdCod = new string[] {""} ;
         T002U9_A210PedCod = new string[] {""} ;
         T002U9_A28ProdCod = new string[] {""} ;
         T002U9_A217PedDLRef1 = new string[] {""} ;
         T002U3_A217PedDLRef1 = new string[] {""} ;
         T002U3_A1569PedDLRef2 = new DateTime[] {DateTime.MinValue} ;
         T002U3_A1570PedDLRef3 = new string[] {""} ;
         T002U3_A1571PedDLRef4 = new string[] {""} ;
         T002U3_A1568PedDLCant = new decimal[1] ;
         T002U3_A1544PedAlmCod = new int[1] ;
         T002U3_A210PedCod = new string[] {""} ;
         T002U3_A28ProdCod = new string[] {""} ;
         sMode97 = "";
         T002U10_A210PedCod = new string[] {""} ;
         T002U10_A28ProdCod = new string[] {""} ;
         T002U10_A217PedDLRef1 = new string[] {""} ;
         T002U11_A210PedCod = new string[] {""} ;
         T002U11_A28ProdCod = new string[] {""} ;
         T002U11_A217PedDLRef1 = new string[] {""} ;
         T002U2_A217PedDLRef1 = new string[] {""} ;
         T002U2_A1569PedDLRef2 = new DateTime[] {DateTime.MinValue} ;
         T002U2_A1570PedDLRef3 = new string[] {""} ;
         T002U2_A1571PedDLRef4 = new string[] {""} ;
         T002U2_A1568PedDLCant = new decimal[1] ;
         T002U2_A1544PedAlmCod = new int[1] ;
         T002U2_A210PedCod = new string[] {""} ;
         T002U2_A28ProdCod = new string[] {""} ;
         T002U15_A210PedCod = new string[] {""} ;
         T002U15_A28ProdCod = new string[] {""} ;
         T002U15_A217PedDLRef1 = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002U16_A210PedCod = new string[] {""} ;
         T002U17_A28ProdCod = new string[] {""} ;
         ZZ210PedCod = "";
         ZZ28ProdCod = "";
         ZZ217PedDLRef1 = "";
         ZZ1569PedDLRef2 = DateTime.MinValue;
         ZZ1570PedDLRef3 = "";
         ZZ1571PedDLRef4 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clpedidosdetlote__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpedidosdetlote__default(),
            new Object[][] {
                new Object[] {
               T002U2_A217PedDLRef1, T002U2_A1569PedDLRef2, T002U2_A1570PedDLRef3, T002U2_A1571PedDLRef4, T002U2_A1568PedDLCant, T002U2_A1544PedAlmCod, T002U2_A210PedCod, T002U2_A28ProdCod
               }
               , new Object[] {
               T002U3_A217PedDLRef1, T002U3_A1569PedDLRef2, T002U3_A1570PedDLRef3, T002U3_A1571PedDLRef4, T002U3_A1568PedDLCant, T002U3_A1544PedAlmCod, T002U3_A210PedCod, T002U3_A28ProdCod
               }
               , new Object[] {
               T002U4_A210PedCod
               }
               , new Object[] {
               T002U5_A28ProdCod
               }
               , new Object[] {
               T002U6_A217PedDLRef1, T002U6_A1569PedDLRef2, T002U6_A1570PedDLRef3, T002U6_A1571PedDLRef4, T002U6_A1568PedDLCant, T002U6_A1544PedAlmCod, T002U6_A210PedCod, T002U6_A28ProdCod
               }
               , new Object[] {
               T002U7_A210PedCod
               }
               , new Object[] {
               T002U8_A28ProdCod
               }
               , new Object[] {
               T002U9_A210PedCod, T002U9_A28ProdCod, T002U9_A217PedDLRef1
               }
               , new Object[] {
               T002U10_A210PedCod, T002U10_A28ProdCod, T002U10_A217PedDLRef1
               }
               , new Object[] {
               T002U11_A210PedCod, T002U11_A28ProdCod, T002U11_A217PedDLRef1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002U15_A210PedCod, T002U15_A28ProdCod, T002U15_A217PedDLRef1
               }
               , new Object[] {
               T002U16_A210PedCod
               }
               , new Object[] {
               T002U17_A28ProdCod
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
      private short RcdFound97 ;
      private short nIsDirty_97 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1544PedAlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPedCod_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtPedDLRef1_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPedDLRef2_Enabled ;
      private int edtPedDLRef3_Enabled ;
      private int edtPedDLRef4_Enabled ;
      private int edtPedDLCant_Enabled ;
      private int A1544PedAlmCod ;
      private int edtPedAlmCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ1544PedAlmCod ;
      private decimal Z1568PedDLCant ;
      private decimal A1568PedDLCant ;
      private decimal ZZ1568PedDLCant ;
      private string sPrefix ;
      private string Z210PedCod ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A210PedCod ;
      private string A28ProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPedCod_Internalname ;
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
      private string edtPedCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPedDLRef1_Internalname ;
      private string edtPedDLRef1_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPedDLRef2_Internalname ;
      private string edtPedDLRef2_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPedDLRef3_Internalname ;
      private string edtPedDLRef3_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPedDLRef4_Internalname ;
      private string edtPedDLRef4_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPedDLCant_Internalname ;
      private string edtPedDLCant_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPedAlmCod_Internalname ;
      private string edtPedAlmCod_Jsonclick ;
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
      private string sMode97 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ210PedCod ;
      private string ZZ28ProdCod ;
      private DateTime Z1569PedDLRef2 ;
      private DateTime A1569PedDLRef2 ;
      private DateTime ZZ1569PedDLRef2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z217PedDLRef1 ;
      private string Z1570PedDLRef3 ;
      private string Z1571PedDLRef4 ;
      private string A217PedDLRef1 ;
      private string A1570PedDLRef3 ;
      private string A1571PedDLRef4 ;
      private string ZZ217PedDLRef1 ;
      private string ZZ1570PedDLRef3 ;
      private string ZZ1571PedDLRef4 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002U6_A217PedDLRef1 ;
      private DateTime[] T002U6_A1569PedDLRef2 ;
      private string[] T002U6_A1570PedDLRef3 ;
      private string[] T002U6_A1571PedDLRef4 ;
      private decimal[] T002U6_A1568PedDLCant ;
      private int[] T002U6_A1544PedAlmCod ;
      private string[] T002U6_A210PedCod ;
      private string[] T002U6_A28ProdCod ;
      private string[] T002U4_A210PedCod ;
      private string[] T002U5_A28ProdCod ;
      private string[] T002U7_A210PedCod ;
      private string[] T002U8_A28ProdCod ;
      private string[] T002U9_A210PedCod ;
      private string[] T002U9_A28ProdCod ;
      private string[] T002U9_A217PedDLRef1 ;
      private string[] T002U3_A217PedDLRef1 ;
      private DateTime[] T002U3_A1569PedDLRef2 ;
      private string[] T002U3_A1570PedDLRef3 ;
      private string[] T002U3_A1571PedDLRef4 ;
      private decimal[] T002U3_A1568PedDLCant ;
      private int[] T002U3_A1544PedAlmCod ;
      private string[] T002U3_A210PedCod ;
      private string[] T002U3_A28ProdCod ;
      private string[] T002U10_A210PedCod ;
      private string[] T002U10_A28ProdCod ;
      private string[] T002U10_A217PedDLRef1 ;
      private string[] T002U11_A210PedCod ;
      private string[] T002U11_A28ProdCod ;
      private string[] T002U11_A217PedDLRef1 ;
      private string[] T002U2_A217PedDLRef1 ;
      private DateTime[] T002U2_A1569PedDLRef2 ;
      private string[] T002U2_A1570PedDLRef3 ;
      private string[] T002U2_A1571PedDLRef4 ;
      private decimal[] T002U2_A1568PedDLCant ;
      private int[] T002U2_A1544PedAlmCod ;
      private string[] T002U2_A210PedCod ;
      private string[] T002U2_A28ProdCod ;
      private string[] T002U15_A210PedCod ;
      private string[] T002U15_A28ProdCod ;
      private string[] T002U15_A217PedDLRef1 ;
      private string[] T002U16_A210PedCod ;
      private string[] T002U17_A28ProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clpedidosdetlote__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clpedidosdetlote__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002U6;
        prmT002U6 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U4;
        prmT002U4 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002U5;
        prmT002U5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002U7;
        prmT002U7 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002U8;
        prmT002U8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002U9;
        prmT002U9 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U3;
        prmT002U3 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U10;
        prmT002U10 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U11;
        prmT002U11 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U2;
        prmT002U2 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U12;
        prmT002U12 = new Object[] {
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0) ,
        new ParDef("@PedDLRef2",GXType.Date,8,0) ,
        new ParDef("@PedDLRef3",GXType.NVarChar,20,0) ,
        new ParDef("@PedDLRef4",GXType.NVarChar,20,0) ,
        new ParDef("@PedDLCant",GXType.Decimal,15,4) ,
        new ParDef("@PedAlmCod",GXType.Int32,6,0) ,
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002U13;
        prmT002U13 = new Object[] {
        new ParDef("@PedDLRef2",GXType.Date,8,0) ,
        new ParDef("@PedDLRef3",GXType.NVarChar,20,0) ,
        new ParDef("@PedDLRef4",GXType.NVarChar,20,0) ,
        new ParDef("@PedDLCant",GXType.Decimal,15,4) ,
        new ParDef("@PedAlmCod",GXType.Int32,6,0) ,
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U14;
        prmT002U14 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@PedDLRef1",GXType.NVarChar,10,0)
        };
        Object[] prmT002U15;
        prmT002U15 = new Object[] {
        };
        Object[] prmT002U16;
        prmT002U16 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002U17;
        prmT002U17 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002U2", "SELECT [PedDLRef1], [PedDLRef2], [PedDLRef3], [PedDLRef4], [PedDLCant], [PedAlmCod], [PedCod], [ProdCod] FROM [CLPEDIDOSDETLOTE] WITH (UPDLOCK) WHERE [PedCod] = @PedCod AND [ProdCod] = @ProdCod AND [PedDLRef1] = @PedDLRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U3", "SELECT [PedDLRef1], [PedDLRef2], [PedDLRef3], [PedDLRef4], [PedDLCant], [PedAlmCod], [PedCod], [ProdCod] FROM [CLPEDIDOSDETLOTE] WHERE [PedCod] = @PedCod AND [ProdCod] = @ProdCod AND [PedDLRef1] = @PedDLRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U4", "SELECT [PedCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U5", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U6", "SELECT TM1.[PedDLRef1], TM1.[PedDLRef2], TM1.[PedDLRef3], TM1.[PedDLRef4], TM1.[PedDLCant], TM1.[PedAlmCod], TM1.[PedCod], TM1.[ProdCod] FROM [CLPEDIDOSDETLOTE] TM1 WHERE TM1.[PedCod] = @PedCod and TM1.[ProdCod] = @ProdCod and TM1.[PedDLRef1] = @PedDLRef1 ORDER BY TM1.[PedCod], TM1.[ProdCod], TM1.[PedDLRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U7", "SELECT [PedCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U8", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U9", "SELECT [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE [PedCod] = @PedCod AND [ProdCod] = @ProdCod AND [PedDLRef1] = @PedDLRef1  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U10", "SELECT TOP 1 [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE ( [PedCod] > @PedCod or [PedCod] = @PedCod and [ProdCod] > @ProdCod or [ProdCod] = @ProdCod and [PedCod] = @PedCod and [PedDLRef1] > @PedDLRef1) ORDER BY [PedCod], [ProdCod], [PedDLRef1]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002U11", "SELECT TOP 1 [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE ( [PedCod] < @PedCod or [PedCod] = @PedCod and [ProdCod] < @ProdCod or [ProdCod] = @ProdCod and [PedCod] = @PedCod and [PedDLRef1] < @PedDLRef1) ORDER BY [PedCod] DESC, [ProdCod] DESC, [PedDLRef1] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002U12", "INSERT INTO [CLPEDIDOSDETLOTE]([PedDLRef1], [PedDLRef2], [PedDLRef3], [PedDLRef4], [PedDLCant], [PedAlmCod], [PedCod], [ProdCod]) VALUES(@PedDLRef1, @PedDLRef2, @PedDLRef3, @PedDLRef4, @PedDLCant, @PedAlmCod, @PedCod, @ProdCod)", GxErrorMask.GX_NOMASK,prmT002U12)
           ,new CursorDef("T002U13", "UPDATE [CLPEDIDOSDETLOTE] SET [PedDLRef2]=@PedDLRef2, [PedDLRef3]=@PedDLRef3, [PedDLRef4]=@PedDLRef4, [PedDLCant]=@PedDLCant, [PedAlmCod]=@PedAlmCod  WHERE [PedCod] = @PedCod AND [ProdCod] = @ProdCod AND [PedDLRef1] = @PedDLRef1", GxErrorMask.GX_NOMASK,prmT002U13)
           ,new CursorDef("T002U14", "DELETE FROM [CLPEDIDOSDETLOTE]  WHERE [PedCod] = @PedCod AND [ProdCod] = @ProdCod AND [PedDLRef1] = @PedDLRef1", GxErrorMask.GX_NOMASK,prmT002U14)
           ,new CursorDef("T002U15", "SELECT [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] ORDER BY [PedCod], [ProdCod], [PedDLRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002U15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U16", "SELECT [PedCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002U17", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002U17,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
