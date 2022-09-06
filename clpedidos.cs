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
   public class clpedidos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A210PedCod = GetPar( "PedCod");
            AssignAttri("", false, "A210PedCod", A210PedCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A210PedCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A45CliCod = GetPar( "CliCod");
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A45CliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A180MonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A214PedConp = (int)(NumberUtil.Val( GetPar( "PedConp"), "."));
            AssignAttri("", false, "A214PedConp", StringUtil.LTrimStr( (decimal)(A214PedConp), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A214PedConp) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A213PedLisp = (int)(NumberUtil.Val( GetPar( "PedLisp"), "."));
            n213PedLisp = false;
            AssignAttri("", false, "A213PedLisp", StringUtil.LTrimStr( (decimal)(A213PedLisp), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A213PedLisp) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A211PedVendCod = (int)(NumberUtil.Val( GetPar( "PedVendCod"), "."));
            AssignAttri("", false, "A211PedVendCod", StringUtil.LTrimStr( (decimal)(A211PedVendCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A211PedVendCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A212TPedCod = (int)(NumberUtil.Val( GetPar( "TPedCod"), "."));
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A212TPedCod) ;
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
            Form.Meta.addItem("description", "Pedidos - Cabecera", 0) ;
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

      public clpedidos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpedidos( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLPEDIDOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Pedido", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedCod_Internalname, StringUtil.RTrim( A210PedCod), StringUtil.RTrim( context.localUtil.Format( A210PedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha Pedido", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedFec_Internalname, context.localUtil.Format(A215PedFec, "99/99/99"), context.localUtil.Format( A215PedFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         GxWebStd.gx_bitmap( context, edtPedFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Cliente", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Moneda", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Condición Pago", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedConp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A214PedConp), 6, 0, ".", "")), StringUtil.LTrim( ((edtPedConp_Enabled!=0) ? context.localUtil.Format( (decimal)(A214PedConp), "ZZZZZ9") : context.localUtil.Format( (decimal)(A214PedConp), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedConp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedConp_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Lista de Precios", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedLisp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A213PedLisp), 6, 0, ".", "")), StringUtil.LTrim( ((edtPedLisp_Enabled!=0) ? context.localUtil.Format( (decimal)(A213PedLisp), "ZZZZZ9") : context.localUtil.Format( (decimal)(A213PedLisp), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedLisp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedLisp_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Referencia", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedRef_Internalname, StringUtil.RTrim( A1605PedRef), StringUtil.RTrim( context.localUtil.Format( A1605PedRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedRef_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "%Dscto", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedPorDsct_Internalname, StringUtil.LTrim( StringUtil.NToC( A1590PedPorDsct, 6, 2, ".", "")), StringUtil.LTrim( ((edtPedPorDsct_Enabled!=0) ? context.localUtil.Format( A1590PedPorDsct, "ZZ9.99") : context.localUtil.Format( A1590PedPorDsct, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedPorDsct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedPorDsct_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "% I.G.V.", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedPorIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A1602PedPorIVA, 6, 2, ".", "")), StringUtil.LTrim( ((edtPedPorIVA_Enabled!=0) ? context.localUtil.Format( A1602PedPorIVA, "ZZ9.99") : context.localUtil.Format( A1602PedPorIVA, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedPorIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedPorIVA_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Observaciones", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPedObs_Internalname, A1604PedObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", 0, 1, edtPedObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Total Items", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1609PedTItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtPedTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1609PedTItem), "ZZZ9") : context.localUtil.Format( (decimal)(A1609PedTItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedTItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Situación", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedSts_Internalname, StringUtil.RTrim( A1606PedSts), StringUtil.RTrim( context.localUtil.Format( A1606PedSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Redondeo", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedRedondeo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1603PedRedondeo, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedRedondeo_Enabled!=0) ? context.localUtil.Format( A1603PedRedondeo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1603PedRedondeo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedRedondeo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedRedondeo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Codigo Vendedor", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedVendCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211PedVendCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPedVendCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A211PedVendCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A211PedVendCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedVendCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedVendCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Usuario Creación", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedUsuC_Internalname, StringUtil.RTrim( A1613PedUsuC), StringUtil.RTrim( context.localUtil.Format( A1613PedUsuC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Fecha Creación", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedFecC_Internalname, context.localUtil.TToC( A1596PedFecC, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1596PedFecC, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedFecC_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         GxWebStd.gx_bitmap( context, edtPedFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Usuario Modificación", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedUsuM_Internalname, StringUtil.RTrim( A1614PedUsuM), StringUtil.RTrim( context.localUtil.Format( A1614PedUsuM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Dscto", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedDsct_Internalname, StringUtil.LTrim( StringUtil.NToC( A1580PedDsct, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedDsct_Enabled!=0) ? context.localUtil.Format( A1580PedDsct, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1580PedDsct, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedDsct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedDsct_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Fecha Modificación", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedFecM_Internalname, context.localUtil.TToC( A1597PedFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1597PedFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         GxWebStd.gx_bitmap( context, edtPedFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Usuario Autorización", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedUsuA_Internalname, StringUtil.RTrim( A1611PedUsuA), StringUtil.RTrim( context.localUtil.Format( A1611PedUsuA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedUsuA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedUsuA_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Fecha Autorización", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedFecA_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedFecA_Internalname, context.localUtil.TToC( A1593PedFecA, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1593PedFecA, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedFecA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedFecA_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         GxWebStd.gx_bitmap( context, edtPedFecA_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedFecA_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Usuario Autorización 2", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedUsuA2_Internalname, StringUtil.RTrim( A1612PedUsuA2), StringUtil.RTrim( context.localUtil.Format( A1612PedUsuA2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedUsuA2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedUsuA2_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Fecha Autorización 2", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedFecA2_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedFecA2_Internalname, context.localUtil.TToC( A1594PedFecA2, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1594PedFecA2, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedFecA2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedFecA2_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         GxWebStd.gx_bitmap( context, edtPedFecA2_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedFecA2_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Tipo de Ingreso de Pedido", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedIngreso_Internalname, StringUtil.RTrim( A1600PedIngreso), StringUtil.RTrim( context.localUtil.Format( A1600PedIngreso, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedIngreso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedIngreso_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Observación de Ingreso", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPedingObs_Internalname, A1599PedingObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", 0, 1, edtPedingObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Dirección de Despacho 1", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedCliDespacho_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1545PedCliDespacho), 6, 0, ".", "")), StringUtil.LTrim( ((edtPedCliDespacho_Enabled!=0) ? context.localUtil.Format( (decimal)(A1545PedCliDespacho), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1545PedCliDespacho), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedCliDespacho_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedCliDespacho_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Dirección de Despacho 2", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedCliDespacho2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1546PedCliDespacho2), 6, 0, ".", "")), StringUtil.LTrim( ((edtPedCliDespacho2_Enabled!=0) ? context.localUtil.Format( (decimal)(A1546PedCliDespacho2), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1546PedCliDespacho2), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedCliDespacho2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedCliDespacho2_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Fecha Atención", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPedFecAten_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPedFecAten_Internalname, context.localUtil.TToC( A1595PedFecAten, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1595PedFecAten, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedFecAten_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedFecAten_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         GxWebStd.gx_bitmap( context, edtPedFecAten_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPedFecAten_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Flag Cotizacion", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPedCotiza_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1549PedCotiza), 1, 0, ".", "")), StringUtil.LTrim( ((edtPedCotiza_Enabled!=0) ? context.localUtil.Format( (decimal)(A1549PedCotiza), "9") : context.localUtil.Format( (decimal)(A1549PedCotiza), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedCotiza_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedCotiza_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Codigo", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212TPedCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTPedCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A212TPedCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A212TPedCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPedCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Sub Total", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedSubT_Internalname, StringUtil.LTrim( StringUtil.NToC( A1581PedSubT, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedSubT_Enabled!=0) ? context.localUtil.Format( A1581PedSubT, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1581PedSubT, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedSubT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedSubT_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "I.G.V.", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A1601PedIVA, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedIVA_Enabled!=0) ? context.localUtil.Format( A1601PedIVA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1601PedIVA, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedIVA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Total Pedido", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1610PedTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedTotal_Enabled!=0) ? context.localUtil.Format( A1610PedTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1610PedTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Sub Inafecto", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedSubIna_Internalname, StringUtil.LTrim( StringUtil.NToC( A1582PedSubIna, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedSubIna_Enabled!=0) ? context.localUtil.Format( A1582PedSubIna, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1582PedSubIna, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedSubIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedSubIna_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Sub Afecto", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedSubAfe_Internalname, StringUtil.LTrim( StringUtil.NToC( A1583PedSubAfe, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedSubAfe_Enabled!=0) ? context.localUtil.Format( A1583PedSubAfe, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1583PedSubAfe, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedSubAfe_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedSubAfe_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Condición de Pago", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedConpDsc_Internalname, StringUtil.RTrim( A1548PedConpDsc), StringUtil.RTrim( context.localUtil.Format( A1548PedConpDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Vendedor", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedVendDsc_Internalname, StringUtil.RTrim( A1615PedVendDsc), StringUtil.RTrim( context.localUtil.Format( A1615PedVendDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedVendDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedVendDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Sub Selectivo", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedSubSelectivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1584PedSubSelectivo, 17, 2, ".", "")), StringUtil.LTrim( ((edtPedSubSelectivo_Enabled!=0) ? context.localUtil.Format( A1584PedSubSelectivo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1584PedSubSelectivo, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedSubSelectivo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedSubSelectivo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Dias", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPedConpDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1547PedConpDias), 4, 0, ".", "")), StringUtil.LTrim( ((edtPedConpDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A1547PedConpDias), "ZZZ9") : context.localUtil.Format( (decimal)(A1547PedConpDias), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPedConpDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPedConpDias_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLPEDIDOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 215,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 217,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLPEDIDOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 218,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLPEDIDOS.htm");
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
            Z215PedFec = context.localUtil.CToD( cgiGet( "Z215PedFec"), 0);
            Z1605PedRef = cgiGet( "Z1605PedRef");
            Z1590PedPorDsct = context.localUtil.CToN( cgiGet( "Z1590PedPorDsct"), ".", ",");
            Z1602PedPorIVA = context.localUtil.CToN( cgiGet( "Z1602PedPorIVA"), ".", ",");
            Z1609PedTItem = (short)(context.localUtil.CToN( cgiGet( "Z1609PedTItem"), ".", ","));
            Z1606PedSts = cgiGet( "Z1606PedSts");
            Z1603PedRedondeo = context.localUtil.CToN( cgiGet( "Z1603PedRedondeo"), ".", ",");
            Z1613PedUsuC = cgiGet( "Z1613PedUsuC");
            Z1596PedFecC = context.localUtil.CToT( cgiGet( "Z1596PedFecC"), 0);
            Z1614PedUsuM = cgiGet( "Z1614PedUsuM");
            Z1597PedFecM = context.localUtil.CToT( cgiGet( "Z1597PedFecM"), 0);
            Z1611PedUsuA = cgiGet( "Z1611PedUsuA");
            Z1593PedFecA = context.localUtil.CToT( cgiGet( "Z1593PedFecA"), 0);
            Z1612PedUsuA2 = cgiGet( "Z1612PedUsuA2");
            Z1594PedFecA2 = context.localUtil.CToT( cgiGet( "Z1594PedFecA2"), 0);
            Z1600PedIngreso = cgiGet( "Z1600PedIngreso");
            Z1545PedCliDespacho = (int)(context.localUtil.CToN( cgiGet( "Z1545PedCliDespacho"), ".", ","));
            Z1546PedCliDespacho2 = (int)(context.localUtil.CToN( cgiGet( "Z1546PedCliDespacho2"), ".", ","));
            Z1595PedFecAten = context.localUtil.CToT( cgiGet( "Z1595PedFecAten"), 0);
            Z1549PedCotiza = (short)(context.localUtil.CToN( cgiGet( "Z1549PedCotiza"), ".", ","));
            Z1543PedAIVA = (short)(context.localUtil.CToN( cgiGet( "Z1543PedAIVA"), ".", ","));
            Z1608PedTipCod = cgiGet( "Z1608PedTipCod");
            Z45CliCod = cgiGet( "Z45CliCod");
            Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            Z212TPedCod = (int)(context.localUtil.CToN( cgiGet( "Z212TPedCod"), ".", ","));
            Z178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
            Z214PedConp = (int)(context.localUtil.CToN( cgiGet( "Z214PedConp"), ".", ","));
            Z213PedLisp = (int)(context.localUtil.CToN( cgiGet( "Z213PedLisp"), ".", ","));
            n213PedLisp = ((0==A213PedLisp) ? true : false);
            Z211PedVendCod = (int)(context.localUtil.CToN( cgiGet( "Z211PedVendCod"), ".", ","));
            A1543PedAIVA = (short)(context.localUtil.CToN( cgiGet( "Z1543PedAIVA"), ".", ","));
            A1608PedTipCod = cgiGet( "Z1608PedTipCod");
            A178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1598PedICBPER = context.localUtil.CToN( cgiGet( "PEDICBPER"), ".", ",");
            A1589PedSubExonerado = context.localUtil.CToN( cgiGet( "PEDSUBEXONERADO"), ".", ",");
            A1543PedAIVA = (short)(context.localUtil.CToN( cgiGet( "PEDAIVA"), ".", ","));
            A1608PedTipCod = cgiGet( "PEDTIPCOD");
            A178TieCod = (int)(context.localUtil.CToN( cgiGet( "TIECOD"), ".", ","));
            A1607PedSubGratuito = context.localUtil.CToN( cgiGet( "PEDSUBGRATUITO"), ".", ",");
            /* Read variables values. */
            A210PedCod = cgiGet( edtPedCod_Internalname);
            AssignAttri("", false, "A210PedCod", A210PedCod);
            if ( context.localUtil.VCDate( cgiGet( edtPedFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Pedido"}), 1, "PEDFEC");
               AnyError = 1;
               GX_FocusControl = edtPedFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A215PedFec = DateTime.MinValue;
               AssignAttri("", false, "A215PedFec", context.localUtil.Format(A215PedFec, "99/99/99"));
            }
            else
            {
               A215PedFec = context.localUtil.CToD( cgiGet( edtPedFec_Internalname), 2);
               AssignAttri("", false, "A215PedFec", context.localUtil.Format(A215PedFec, "99/99/99"));
            }
            A45CliCod = cgiGet( edtCliCod_Internalname);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONCOD");
               AnyError = 1;
               GX_FocusControl = edtMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A180MonCod = 0;
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            else
            {
               A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedConp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedConp_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDCONP");
               AnyError = 1;
               GX_FocusControl = edtPedConp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A214PedConp = 0;
               AssignAttri("", false, "A214PedConp", StringUtil.LTrimStr( (decimal)(A214PedConp), 6, 0));
            }
            else
            {
               A214PedConp = (int)(context.localUtil.CToN( cgiGet( edtPedConp_Internalname), ".", ","));
               AssignAttri("", false, "A214PedConp", StringUtil.LTrimStr( (decimal)(A214PedConp), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedLisp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedLisp_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDLISP");
               AnyError = 1;
               GX_FocusControl = edtPedLisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A213PedLisp = 0;
               n213PedLisp = false;
               AssignAttri("", false, "A213PedLisp", StringUtil.LTrimStr( (decimal)(A213PedLisp), 6, 0));
            }
            else
            {
               A213PedLisp = (int)(context.localUtil.CToN( cgiGet( edtPedLisp_Internalname), ".", ","));
               n213PedLisp = false;
               AssignAttri("", false, "A213PedLisp", StringUtil.LTrimStr( (decimal)(A213PedLisp), 6, 0));
            }
            n213PedLisp = ((0==A213PedLisp) ? true : false);
            A1605PedRef = cgiGet( edtPedRef_Internalname);
            AssignAttri("", false, "A1605PedRef", A1605PedRef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedPorDsct_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedPorDsct_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDPORDSCT");
               AnyError = 1;
               GX_FocusControl = edtPedPorDsct_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1590PedPorDsct = 0;
               AssignAttri("", false, "A1590PedPorDsct", StringUtil.LTrimStr( A1590PedPorDsct, 6, 2));
            }
            else
            {
               A1590PedPorDsct = context.localUtil.CToN( cgiGet( edtPedPorDsct_Internalname), ".", ",");
               AssignAttri("", false, "A1590PedPorDsct", StringUtil.LTrimStr( A1590PedPorDsct, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedPorIVA_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedPorIVA_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDPORIVA");
               AnyError = 1;
               GX_FocusControl = edtPedPorIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1602PedPorIVA = 0;
               AssignAttri("", false, "A1602PedPorIVA", StringUtil.LTrimStr( A1602PedPorIVA, 6, 2));
            }
            else
            {
               A1602PedPorIVA = context.localUtil.CToN( cgiGet( edtPedPorIVA_Internalname), ".", ",");
               AssignAttri("", false, "A1602PedPorIVA", StringUtil.LTrimStr( A1602PedPorIVA, 6, 2));
            }
            A1604PedObs = cgiGet( edtPedObs_Internalname);
            AssignAttri("", false, "A1604PedObs", A1604PedObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedTItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDTITEM");
               AnyError = 1;
               GX_FocusControl = edtPedTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1609PedTItem = 0;
               AssignAttri("", false, "A1609PedTItem", StringUtil.LTrimStr( (decimal)(A1609PedTItem), 4, 0));
            }
            else
            {
               A1609PedTItem = (short)(context.localUtil.CToN( cgiGet( edtPedTItem_Internalname), ".", ","));
               AssignAttri("", false, "A1609PedTItem", StringUtil.LTrimStr( (decimal)(A1609PedTItem), 4, 0));
            }
            A1606PedSts = cgiGet( edtPedSts_Internalname);
            AssignAttri("", false, "A1606PedSts", A1606PedSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedRedondeo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPedRedondeo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDREDONDEO");
               AnyError = 1;
               GX_FocusControl = edtPedRedondeo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1603PedRedondeo = 0;
               AssignAttri("", false, "A1603PedRedondeo", StringUtil.LTrimStr( A1603PedRedondeo, 15, 2));
            }
            else
            {
               A1603PedRedondeo = context.localUtil.CToN( cgiGet( edtPedRedondeo_Internalname), ".", ",");
               AssignAttri("", false, "A1603PedRedondeo", StringUtil.LTrimStr( A1603PedRedondeo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedVendCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedVendCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDVENDCOD");
               AnyError = 1;
               GX_FocusControl = edtPedVendCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A211PedVendCod = 0;
               AssignAttri("", false, "A211PedVendCod", StringUtil.LTrimStr( (decimal)(A211PedVendCod), 6, 0));
            }
            else
            {
               A211PedVendCod = (int)(context.localUtil.CToN( cgiGet( edtPedVendCod_Internalname), ".", ","));
               AssignAttri("", false, "A211PedVendCod", StringUtil.LTrimStr( (decimal)(A211PedVendCod), 6, 0));
            }
            A1613PedUsuC = cgiGet( edtPedUsuC_Internalname);
            AssignAttri("", false, "A1613PedUsuC", A1613PedUsuC);
            if ( context.localUtil.VCDateTime( cgiGet( edtPedFecC_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Creación"}), 1, "PEDFECC");
               AnyError = 1;
               GX_FocusControl = edtPedFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1596PedFecC = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1596PedFecC", context.localUtil.TToC( A1596PedFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1596PedFecC = context.localUtil.CToT( cgiGet( edtPedFecC_Internalname));
               AssignAttri("", false, "A1596PedFecC", context.localUtil.TToC( A1596PedFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            A1614PedUsuM = cgiGet( edtPedUsuM_Internalname);
            AssignAttri("", false, "A1614PedUsuM", A1614PedUsuM);
            A1580PedDsct = context.localUtil.CToN( cgiGet( edtPedDsct_Internalname), ".", ",");
            AssignAttri("", false, "A1580PedDsct", StringUtil.LTrimStr( A1580PedDsct, 15, 2));
            if ( context.localUtil.VCDateTime( cgiGet( edtPedFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Modificación"}), 1, "PEDFECM");
               AnyError = 1;
               GX_FocusControl = edtPedFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1597PedFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1597PedFecM", context.localUtil.TToC( A1597PedFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1597PedFecM = context.localUtil.CToT( cgiGet( edtPedFecM_Internalname));
               AssignAttri("", false, "A1597PedFecM", context.localUtil.TToC( A1597PedFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            A1611PedUsuA = cgiGet( edtPedUsuA_Internalname);
            AssignAttri("", false, "A1611PedUsuA", A1611PedUsuA);
            if ( context.localUtil.VCDateTime( cgiGet( edtPedFecA_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Autorización"}), 1, "PEDFECA");
               AnyError = 1;
               GX_FocusControl = edtPedFecA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1593PedFecA = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1593PedFecA", context.localUtil.TToC( A1593PedFecA, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1593PedFecA = context.localUtil.CToT( cgiGet( edtPedFecA_Internalname));
               AssignAttri("", false, "A1593PedFecA", context.localUtil.TToC( A1593PedFecA, 8, 5, 0, 3, "/", ":", " "));
            }
            A1612PedUsuA2 = cgiGet( edtPedUsuA2_Internalname);
            AssignAttri("", false, "A1612PedUsuA2", A1612PedUsuA2);
            if ( context.localUtil.VCDateTime( cgiGet( edtPedFecA2_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Autorización 2"}), 1, "PEDFECA2");
               AnyError = 1;
               GX_FocusControl = edtPedFecA2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1594PedFecA2 = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1594PedFecA2", context.localUtil.TToC( A1594PedFecA2, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1594PedFecA2 = context.localUtil.CToT( cgiGet( edtPedFecA2_Internalname));
               AssignAttri("", false, "A1594PedFecA2", context.localUtil.TToC( A1594PedFecA2, 8, 5, 0, 3, "/", ":", " "));
            }
            A1600PedIngreso = cgiGet( edtPedIngreso_Internalname);
            AssignAttri("", false, "A1600PedIngreso", A1600PedIngreso);
            A1599PedingObs = cgiGet( edtPedingObs_Internalname);
            AssignAttri("", false, "A1599PedingObs", A1599PedingObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedCliDespacho_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedCliDespacho_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDCLIDESPACHO");
               AnyError = 1;
               GX_FocusControl = edtPedCliDespacho_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1545PedCliDespacho = 0;
               AssignAttri("", false, "A1545PedCliDespacho", StringUtil.LTrimStr( (decimal)(A1545PedCliDespacho), 6, 0));
            }
            else
            {
               A1545PedCliDespacho = (int)(context.localUtil.CToN( cgiGet( edtPedCliDespacho_Internalname), ".", ","));
               AssignAttri("", false, "A1545PedCliDespacho", StringUtil.LTrimStr( (decimal)(A1545PedCliDespacho), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedCliDespacho2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedCliDespacho2_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDCLIDESPACHO2");
               AnyError = 1;
               GX_FocusControl = edtPedCliDespacho2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1546PedCliDespacho2 = 0;
               AssignAttri("", false, "A1546PedCliDespacho2", StringUtil.LTrimStr( (decimal)(A1546PedCliDespacho2), 6, 0));
            }
            else
            {
               A1546PedCliDespacho2 = (int)(context.localUtil.CToN( cgiGet( edtPedCliDespacho2_Internalname), ".", ","));
               AssignAttri("", false, "A1546PedCliDespacho2", StringUtil.LTrimStr( (decimal)(A1546PedCliDespacho2), 6, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtPedFecAten_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Atención"}), 1, "PEDFECATEN");
               AnyError = 1;
               GX_FocusControl = edtPedFecAten_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1595PedFecAten = (DateTime)(DateTime.MinValue);
               n1595PedFecAten = false;
               AssignAttri("", false, "A1595PedFecAten", context.localUtil.TToC( A1595PedFecAten, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1595PedFecAten = context.localUtil.CToT( cgiGet( edtPedFecAten_Internalname));
               n1595PedFecAten = false;
               AssignAttri("", false, "A1595PedFecAten", context.localUtil.TToC( A1595PedFecAten, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPedCotiza_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPedCotiza_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PEDCOTIZA");
               AnyError = 1;
               GX_FocusControl = edtPedCotiza_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1549PedCotiza = 0;
               AssignAttri("", false, "A1549PedCotiza", StringUtil.Str( (decimal)(A1549PedCotiza), 1, 0));
            }
            else
            {
               A1549PedCotiza = (short)(context.localUtil.CToN( cgiGet( edtPedCotiza_Internalname), ".", ","));
               AssignAttri("", false, "A1549PedCotiza", StringUtil.Str( (decimal)(A1549PedCotiza), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtTPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A212TPedCod = 0;
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            }
            else
            {
               A212TPedCod = (int)(context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ","));
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            }
            A1581PedSubT = context.localUtil.CToN( cgiGet( edtPedSubT_Internalname), ".", ",");
            AssignAttri("", false, "A1581PedSubT", StringUtil.LTrimStr( A1581PedSubT, 15, 2));
            A1601PedIVA = context.localUtil.CToN( cgiGet( edtPedIVA_Internalname), ".", ",");
            AssignAttri("", false, "A1601PedIVA", StringUtil.LTrimStr( A1601PedIVA, 15, 2));
            A1610PedTotal = context.localUtil.CToN( cgiGet( edtPedTotal_Internalname), ".", ",");
            AssignAttri("", false, "A1610PedTotal", StringUtil.LTrimStr( A1610PedTotal, 15, 2));
            A1582PedSubIna = context.localUtil.CToN( cgiGet( edtPedSubIna_Internalname), ".", ",");
            AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
            A1583PedSubAfe = context.localUtil.CToN( cgiGet( edtPedSubAfe_Internalname), ".", ",");
            AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
            A1548PedConpDsc = cgiGet( edtPedConpDsc_Internalname);
            AssignAttri("", false, "A1548PedConpDsc", A1548PedConpDsc);
            A1615PedVendDsc = cgiGet( edtPedVendDsc_Internalname);
            AssignAttri("", false, "A1615PedVendDsc", A1615PedVendDsc);
            A1584PedSubSelectivo = context.localUtil.CToN( cgiGet( edtPedSubSelectivo_Internalname), ".", ",");
            AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
            A1547PedConpDias = (short)(context.localUtil.CToN( cgiGet( edtPedConpDias_Internalname), ".", ","));
            AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrimStr( (decimal)(A1547PedConpDias), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLPEDIDOS");
            forbiddenHiddens.Add("TieCod", context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"));
            forbiddenHiddens.Add("PedAIVA", context.localUtil.Format( (decimal)(A1543PedAIVA), "9"));
            forbiddenHiddens.Add("PedTipCod", StringUtil.RTrim( context.localUtil.Format( A1608PedTipCod, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clpedidos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A210PedCod = GetPar( "PedCod");
               AssignAttri("", false, "A210PedCod", A210PedCod);
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
               InitAll2S95( ) ;
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
         DisableAttributes2S95( ) ;
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

      protected void CONFIRM_2S0( )
      {
         BeforeValidate2S95( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2S95( ) ;
            }
            else
            {
               CheckExtendedTable2S95( ) ;
               if ( AnyError == 0 )
               {
                  ZM2S95( 12) ;
                  ZM2S95( 13) ;
                  ZM2S95( 14) ;
                  ZM2S95( 15) ;
                  ZM2S95( 16) ;
                  ZM2S95( 17) ;
                  ZM2S95( 18) ;
                  ZM2S95( 19) ;
               }
               CloseExtendedTableCursors2S95( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2S0( ) ;
         }
      }

      protected void ResetCaption2S0( )
      {
      }

      protected void ZM2S95( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z215PedFec = T002S3_A215PedFec[0];
               Z1605PedRef = T002S3_A1605PedRef[0];
               Z1590PedPorDsct = T002S3_A1590PedPorDsct[0];
               Z1602PedPorIVA = T002S3_A1602PedPorIVA[0];
               Z1609PedTItem = T002S3_A1609PedTItem[0];
               Z1606PedSts = T002S3_A1606PedSts[0];
               Z1603PedRedondeo = T002S3_A1603PedRedondeo[0];
               Z1613PedUsuC = T002S3_A1613PedUsuC[0];
               Z1596PedFecC = T002S3_A1596PedFecC[0];
               Z1614PedUsuM = T002S3_A1614PedUsuM[0];
               Z1597PedFecM = T002S3_A1597PedFecM[0];
               Z1611PedUsuA = T002S3_A1611PedUsuA[0];
               Z1593PedFecA = T002S3_A1593PedFecA[0];
               Z1612PedUsuA2 = T002S3_A1612PedUsuA2[0];
               Z1594PedFecA2 = T002S3_A1594PedFecA2[0];
               Z1600PedIngreso = T002S3_A1600PedIngreso[0];
               Z1545PedCliDespacho = T002S3_A1545PedCliDespacho[0];
               Z1546PedCliDespacho2 = T002S3_A1546PedCliDespacho2[0];
               Z1595PedFecAten = T002S3_A1595PedFecAten[0];
               Z1549PedCotiza = T002S3_A1549PedCotiza[0];
               Z1543PedAIVA = T002S3_A1543PedAIVA[0];
               Z1608PedTipCod = T002S3_A1608PedTipCod[0];
               Z45CliCod = T002S3_A45CliCod[0];
               Z180MonCod = T002S3_A180MonCod[0];
               Z212TPedCod = T002S3_A212TPedCod[0];
               Z178TieCod = T002S3_A178TieCod[0];
               Z214PedConp = T002S3_A214PedConp[0];
               Z213PedLisp = T002S3_A213PedLisp[0];
               Z211PedVendCod = T002S3_A211PedVendCod[0];
            }
            else
            {
               Z215PedFec = A215PedFec;
               Z1605PedRef = A1605PedRef;
               Z1590PedPorDsct = A1590PedPorDsct;
               Z1602PedPorIVA = A1602PedPorIVA;
               Z1609PedTItem = A1609PedTItem;
               Z1606PedSts = A1606PedSts;
               Z1603PedRedondeo = A1603PedRedondeo;
               Z1613PedUsuC = A1613PedUsuC;
               Z1596PedFecC = A1596PedFecC;
               Z1614PedUsuM = A1614PedUsuM;
               Z1597PedFecM = A1597PedFecM;
               Z1611PedUsuA = A1611PedUsuA;
               Z1593PedFecA = A1593PedFecA;
               Z1612PedUsuA2 = A1612PedUsuA2;
               Z1594PedFecA2 = A1594PedFecA2;
               Z1600PedIngreso = A1600PedIngreso;
               Z1545PedCliDespacho = A1545PedCliDespacho;
               Z1546PedCliDespacho2 = A1546PedCliDespacho2;
               Z1595PedFecAten = A1595PedFecAten;
               Z1549PedCotiza = A1549PedCotiza;
               Z1543PedAIVA = A1543PedAIVA;
               Z1608PedTipCod = A1608PedTipCod;
               Z45CliCod = A45CliCod;
               Z180MonCod = A180MonCod;
               Z212TPedCod = A212TPedCod;
               Z178TieCod = A178TieCod;
               Z214PedConp = A214PedConp;
               Z213PedLisp = A213PedLisp;
               Z211PedVendCod = A211PedVendCod;
            }
         }
         if ( GX_JID == -11 )
         {
            Z210PedCod = A210PedCod;
            Z215PedFec = A215PedFec;
            Z1605PedRef = A1605PedRef;
            Z1590PedPorDsct = A1590PedPorDsct;
            Z1602PedPorIVA = A1602PedPorIVA;
            Z1604PedObs = A1604PedObs;
            Z1609PedTItem = A1609PedTItem;
            Z1606PedSts = A1606PedSts;
            Z1603PedRedondeo = A1603PedRedondeo;
            Z1613PedUsuC = A1613PedUsuC;
            Z1596PedFecC = A1596PedFecC;
            Z1614PedUsuM = A1614PedUsuM;
            Z1597PedFecM = A1597PedFecM;
            Z1611PedUsuA = A1611PedUsuA;
            Z1593PedFecA = A1593PedFecA;
            Z1612PedUsuA2 = A1612PedUsuA2;
            Z1594PedFecA2 = A1594PedFecA2;
            Z1600PedIngreso = A1600PedIngreso;
            Z1599PedingObs = A1599PedingObs;
            Z1545PedCliDespacho = A1545PedCliDespacho;
            Z1546PedCliDespacho2 = A1546PedCliDespacho2;
            Z1595PedFecAten = A1595PedFecAten;
            Z1549PedCotiza = A1549PedCotiza;
            Z1543PedAIVA = A1543PedAIVA;
            Z1608PedTipCod = A1608PedTipCod;
            Z45CliCod = A45CliCod;
            Z180MonCod = A180MonCod;
            Z212TPedCod = A212TPedCod;
            Z178TieCod = A178TieCod;
            Z214PedConp = A214PedConp;
            Z213PedLisp = A213PedLisp;
            Z211PedVendCod = A211PedVendCod;
            Z1598PedICBPER = A1598PedICBPER;
            Z1582PedSubIna = A1582PedSubIna;
            Z1583PedSubAfe = A1583PedSubAfe;
            Z1589PedSubExonerado = A1589PedSubExonerado;
            Z1607PedSubGratuito = A1607PedSubGratuito;
            Z1584PedSubSelectivo = A1584PedSubSelectivo;
            Z1548PedConpDsc = A1548PedConpDsc;
            Z1547PedConpDias = A1547PedConpDias;
            Z1615PedVendDsc = A1615PedVendDsc;
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
         /* Using cursor T002S7 */
         pr_default.execute(5, new Object[] {A178TieCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tiendas'.", "ForeignKeyNotFound", 1, "TIECOD");
            AnyError = 1;
         }
         pr_default.close(5);
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

      protected void Load2S95( )
      {
         /* Using cursor T002S14 */
         pr_default.execute(10, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound95 = 1;
            A215PedFec = T002S14_A215PedFec[0];
            AssignAttri("", false, "A215PedFec", context.localUtil.Format(A215PedFec, "99/99/99"));
            A1605PedRef = T002S14_A1605PedRef[0];
            AssignAttri("", false, "A1605PedRef", A1605PedRef);
            A1590PedPorDsct = T002S14_A1590PedPorDsct[0];
            AssignAttri("", false, "A1590PedPorDsct", StringUtil.LTrimStr( A1590PedPorDsct, 6, 2));
            A1602PedPorIVA = T002S14_A1602PedPorIVA[0];
            AssignAttri("", false, "A1602PedPorIVA", StringUtil.LTrimStr( A1602PedPorIVA, 6, 2));
            A1604PedObs = T002S14_A1604PedObs[0];
            AssignAttri("", false, "A1604PedObs", A1604PedObs);
            A1609PedTItem = T002S14_A1609PedTItem[0];
            AssignAttri("", false, "A1609PedTItem", StringUtil.LTrimStr( (decimal)(A1609PedTItem), 4, 0));
            A1606PedSts = T002S14_A1606PedSts[0];
            AssignAttri("", false, "A1606PedSts", A1606PedSts);
            A1603PedRedondeo = T002S14_A1603PedRedondeo[0];
            AssignAttri("", false, "A1603PedRedondeo", StringUtil.LTrimStr( A1603PedRedondeo, 15, 2));
            A1613PedUsuC = T002S14_A1613PedUsuC[0];
            AssignAttri("", false, "A1613PedUsuC", A1613PedUsuC);
            A1596PedFecC = T002S14_A1596PedFecC[0];
            AssignAttri("", false, "A1596PedFecC", context.localUtil.TToC( A1596PedFecC, 8, 5, 0, 3, "/", ":", " "));
            A1614PedUsuM = T002S14_A1614PedUsuM[0];
            AssignAttri("", false, "A1614PedUsuM", A1614PedUsuM);
            A1597PedFecM = T002S14_A1597PedFecM[0];
            AssignAttri("", false, "A1597PedFecM", context.localUtil.TToC( A1597PedFecM, 8, 5, 0, 3, "/", ":", " "));
            A1611PedUsuA = T002S14_A1611PedUsuA[0];
            AssignAttri("", false, "A1611PedUsuA", A1611PedUsuA);
            A1593PedFecA = T002S14_A1593PedFecA[0];
            AssignAttri("", false, "A1593PedFecA", context.localUtil.TToC( A1593PedFecA, 8, 5, 0, 3, "/", ":", " "));
            A1612PedUsuA2 = T002S14_A1612PedUsuA2[0];
            AssignAttri("", false, "A1612PedUsuA2", A1612PedUsuA2);
            A1594PedFecA2 = T002S14_A1594PedFecA2[0];
            AssignAttri("", false, "A1594PedFecA2", context.localUtil.TToC( A1594PedFecA2, 8, 5, 0, 3, "/", ":", " "));
            A1600PedIngreso = T002S14_A1600PedIngreso[0];
            AssignAttri("", false, "A1600PedIngreso", A1600PedIngreso);
            A1599PedingObs = T002S14_A1599PedingObs[0];
            AssignAttri("", false, "A1599PedingObs", A1599PedingObs);
            A1545PedCliDespacho = T002S14_A1545PedCliDespacho[0];
            AssignAttri("", false, "A1545PedCliDespacho", StringUtil.LTrimStr( (decimal)(A1545PedCliDespacho), 6, 0));
            A1546PedCliDespacho2 = T002S14_A1546PedCliDespacho2[0];
            AssignAttri("", false, "A1546PedCliDespacho2", StringUtil.LTrimStr( (decimal)(A1546PedCliDespacho2), 6, 0));
            A1595PedFecAten = T002S14_A1595PedFecAten[0];
            n1595PedFecAten = T002S14_n1595PedFecAten[0];
            AssignAttri("", false, "A1595PedFecAten", context.localUtil.TToC( A1595PedFecAten, 8, 5, 0, 3, "/", ":", " "));
            A1549PedCotiza = T002S14_A1549PedCotiza[0];
            AssignAttri("", false, "A1549PedCotiza", StringUtil.Str( (decimal)(A1549PedCotiza), 1, 0));
            A1548PedConpDsc = T002S14_A1548PedConpDsc[0];
            AssignAttri("", false, "A1548PedConpDsc", A1548PedConpDsc);
            A1615PedVendDsc = T002S14_A1615PedVendDsc[0];
            AssignAttri("", false, "A1615PedVendDsc", A1615PedVendDsc);
            A1547PedConpDias = T002S14_A1547PedConpDias[0];
            AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrimStr( (decimal)(A1547PedConpDias), 4, 0));
            A1543PedAIVA = T002S14_A1543PedAIVA[0];
            A1608PedTipCod = T002S14_A1608PedTipCod[0];
            A45CliCod = T002S14_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A180MonCod = T002S14_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A212TPedCod = T002S14_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            A178TieCod = T002S14_A178TieCod[0];
            A214PedConp = T002S14_A214PedConp[0];
            AssignAttri("", false, "A214PedConp", StringUtil.LTrimStr( (decimal)(A214PedConp), 6, 0));
            A213PedLisp = T002S14_A213PedLisp[0];
            n213PedLisp = T002S14_n213PedLisp[0];
            AssignAttri("", false, "A213PedLisp", StringUtil.LTrimStr( (decimal)(A213PedLisp), 6, 0));
            A211PedVendCod = T002S14_A211PedVendCod[0];
            AssignAttri("", false, "A211PedVendCod", StringUtil.LTrimStr( (decimal)(A211PedVendCod), 6, 0));
            A1598PedICBPER = T002S14_A1598PedICBPER[0];
            A1582PedSubIna = T002S14_A1582PedSubIna[0];
            AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
            A1583PedSubAfe = T002S14_A1583PedSubAfe[0];
            AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
            A1589PedSubExonerado = T002S14_A1589PedSubExonerado[0];
            A1607PedSubGratuito = T002S14_A1607PedSubGratuito[0];
            A1584PedSubSelectivo = T002S14_A1584PedSubSelectivo[0];
            AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
            ZM2S95( -11) ;
         }
         pr_default.close(10);
         OnLoadActions2S95( ) ;
      }

      protected void OnLoadActions2S95( )
      {
         A1581PedSubT = (decimal)(A1582PedSubIna+A1583PedSubAfe+A1584PedSubSelectivo+A1589PedSubExonerado);
         AssignAttri("", false, "A1581PedSubT", StringUtil.LTrimStr( A1581PedSubT, 15, 2));
         A1580PedDsct = (decimal)(((A1581PedSubT*A1590PedPorDsct)/ (decimal)(100)));
         AssignAttri("", false, "A1580PedDsct", StringUtil.LTrimStr( A1580PedDsct, 15, 2));
         A1601PedIVA = (decimal)((((A1583PedSubAfe+A1584PedSubSelectivo-A1580PedDsct)*A1602PedPorIVA)/ (decimal)(100))+A1603PedRedondeo);
         AssignAttri("", false, "A1601PedIVA", StringUtil.LTrimStr( A1601PedIVA, 15, 2));
         A1610PedTotal = (decimal)((A1581PedSubT-A1580PedDsct)+A1601PedIVA+A1598PedICBPER);
         AssignAttri("", false, "A1610PedTotal", StringUtil.LTrimStr( A1610PedTotal, 15, 2));
      }

      protected void CheckExtendedTable2S95( )
      {
         nIsDirty_95 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002S12 */
         pr_default.execute(9, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A1598PedICBPER = T002S12_A1598PedICBPER[0];
            A1582PedSubIna = T002S12_A1582PedSubIna[0];
            AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
            A1583PedSubAfe = T002S12_A1583PedSubAfe[0];
            AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
            A1589PedSubExonerado = T002S12_A1589PedSubExonerado[0];
            A1607PedSubGratuito = T002S12_A1607PedSubGratuito[0];
            A1584PedSubSelectivo = T002S12_A1584PedSubSelectivo[0];
            AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
         }
         else
         {
            nIsDirty_95 = 1;
            A1598PedICBPER = 0;
            AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrimStr( A1598PedICBPER, 15, 2));
            nIsDirty_95 = 1;
            A1582PedSubIna = 0;
            AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
            nIsDirty_95 = 1;
            A1583PedSubAfe = 0;
            AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
            nIsDirty_95 = 1;
            A1589PedSubExonerado = 0;
            AssignAttri("", false, "A1589PedSubExonerado", StringUtil.LTrimStr( A1589PedSubExonerado, 15, 2));
            nIsDirty_95 = 1;
            A1607PedSubGratuito = 0;
            AssignAttri("", false, "A1607PedSubGratuito", StringUtil.LTrimStr( A1607PedSubGratuito, 15, 2));
            nIsDirty_95 = 1;
            A1584PedSubSelectivo = 0;
            AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
         }
         pr_default.close(9);
         nIsDirty_95 = 1;
         A1581PedSubT = (decimal)(A1582PedSubIna+A1583PedSubAfe+A1584PedSubSelectivo+A1589PedSubExonerado);
         AssignAttri("", false, "A1581PedSubT", StringUtil.LTrimStr( A1581PedSubT, 15, 2));
         nIsDirty_95 = 1;
         A1580PedDsct = (decimal)(((A1581PedSubT*A1590PedPorDsct)/ (decimal)(100)));
         AssignAttri("", false, "A1580PedDsct", StringUtil.LTrimStr( A1580PedDsct, 15, 2));
         nIsDirty_95 = 1;
         A1601PedIVA = (decimal)((((A1583PedSubAfe+A1584PedSubSelectivo-A1580PedDsct)*A1602PedPorIVA)/ (decimal)(100))+A1603PedRedondeo);
         AssignAttri("", false, "A1601PedIVA", StringUtil.LTrimStr( A1601PedIVA, 15, 2));
         nIsDirty_95 = 1;
         A1610PedTotal = (decimal)((A1581PedSubT-A1580PedDsct)+A1601PedIVA+A1598PedICBPER);
         AssignAttri("", false, "A1610PedTotal", StringUtil.LTrimStr( A1610PedTotal, 15, 2));
         if ( ! ( (DateTime.MinValue==A215PedFec) || ( DateTimeUtil.ResetTime ( A215PedFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Pedido fuera de rango", "OutOfRange", 1, "PEDFEC");
            AnyError = 1;
            GX_FocusControl = edtPedFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002S4 */
         pr_default.execute(2, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002S5 */
         pr_default.execute(3, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T002S8 */
         pr_default.execute(6, new Object[] {A214PedConp});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Pago'.", "ForeignKeyNotFound", 1, "PEDCONP");
            AnyError = 1;
            GX_FocusControl = edtPedConp_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1548PedConpDsc = T002S8_A1548PedConpDsc[0];
         AssignAttri("", false, "A1548PedConpDsc", A1548PedConpDsc);
         A1547PedConpDias = T002S8_A1547PedConpDias[0];
         AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrimStr( (decimal)(A1547PedConpDias), 4, 0));
         pr_default.close(6);
         /* Using cursor T002S9 */
         pr_default.execute(7, new Object[] {n213PedLisp, A213PedLisp});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A213PedLisp) ) )
            {
               GX_msglist.addItem("No existe 'Sub Lista Precios Pedido'.", "ForeignKeyNotFound", 1, "PEDLISP");
               AnyError = 1;
               GX_FocusControl = edtPedLisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
         /* Using cursor T002S10 */
         pr_default.execute(8, new Object[] {A211PedVendCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "PEDVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1615PedVendDsc = T002S10_A1615PedVendDsc[0];
         AssignAttri("", false, "A1615PedVendDsc", A1615PedVendDsc);
         pr_default.close(8);
         if ( ! ( (DateTime.MinValue==A1596PedFecC) || ( A1596PedFecC >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Creación fuera de rango", "OutOfRange", 1, "PEDFECC");
            AnyError = 1;
            GX_FocusControl = edtPedFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1597PedFecM) || ( A1597PedFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Modificación fuera de rango", "OutOfRange", 1, "PEDFECM");
            AnyError = 1;
            GX_FocusControl = edtPedFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1593PedFecA) || ( A1593PedFecA >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Autorización fuera de rango", "OutOfRange", 1, "PEDFECA");
            AnyError = 1;
            GX_FocusControl = edtPedFecA_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1594PedFecA2) || ( A1594PedFecA2 >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Autorización 2 fuera de rango", "OutOfRange", 1, "PEDFECA2");
            AnyError = 1;
            GX_FocusControl = edtPedFecA2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1595PedFecAten) || ( A1595PedFecAten >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Atención fuera de rango", "OutOfRange", 1, "PEDFECATEN");
            AnyError = 1;
            GX_FocusControl = edtPedFecAten_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002S6 */
         pr_default.execute(4, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Pedidos'.", "ForeignKeyNotFound", 1, "TPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2S95( )
      {
         pr_default.close(9);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( string A210PedCod )
      {
         /* Using cursor T002S16 */
         pr_default.execute(11, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A1598PedICBPER = T002S16_A1598PedICBPER[0];
            A1582PedSubIna = T002S16_A1582PedSubIna[0];
            AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
            A1583PedSubAfe = T002S16_A1583PedSubAfe[0];
            AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
            A1589PedSubExonerado = T002S16_A1589PedSubExonerado[0];
            A1607PedSubGratuito = T002S16_A1607PedSubGratuito[0];
            A1584PedSubSelectivo = T002S16_A1584PedSubSelectivo[0];
            AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
         }
         else
         {
            A1598PedICBPER = 0;
            AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrimStr( A1598PedICBPER, 15, 2));
            A1582PedSubIna = 0;
            AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
            A1583PedSubAfe = 0;
            AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
            A1589PedSubExonerado = 0;
            AssignAttri("", false, "A1589PedSubExonerado", StringUtil.LTrimStr( A1589PedSubExonerado, 15, 2));
            A1607PedSubGratuito = 0;
            AssignAttri("", false, "A1607PedSubGratuito", StringUtil.LTrimStr( A1607PedSubGratuito, 15, 2));
            A1584PedSubSelectivo = 0;
            AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1582PedSubIna, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1583PedSubAfe, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1589PedSubExonerado, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1607PedSubGratuito, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1584PedSubSelectivo, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_12( string A45CliCod )
      {
         /* Using cursor T002S17 */
         pr_default.execute(12, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
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

      protected void gxLoad_13( int A180MonCod )
      {
         /* Using cursor T002S18 */
         pr_default.execute(13, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_16( int A214PedConp )
      {
         /* Using cursor T002S19 */
         pr_default.execute(14, new Object[] {A214PedConp});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Pago'.", "ForeignKeyNotFound", 1, "PEDCONP");
            AnyError = 1;
            GX_FocusControl = edtPedConp_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1548PedConpDsc = T002S19_A1548PedConpDsc[0];
         AssignAttri("", false, "A1548PedConpDsc", A1548PedConpDsc);
         A1547PedConpDias = T002S19_A1547PedConpDias[0];
         AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrimStr( (decimal)(A1547PedConpDias), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1548PedConpDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1547PedConpDias), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_17( int A213PedLisp )
      {
         /* Using cursor T002S20 */
         pr_default.execute(15, new Object[] {n213PedLisp, A213PedLisp});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A213PedLisp) ) )
            {
               GX_msglist.addItem("No existe 'Sub Lista Precios Pedido'.", "ForeignKeyNotFound", 1, "PEDLISP");
               AnyError = 1;
               GX_FocusControl = edtPedLisp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_18( int A211PedVendCod )
      {
         /* Using cursor T002S21 */
         pr_default.execute(16, new Object[] {A211PedVendCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "PEDVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1615PedVendDsc = T002S21_A1615PedVendDsc[0];
         AssignAttri("", false, "A1615PedVendDsc", A1615PedVendDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1615PedVendDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_14( int A212TPedCod )
      {
         /* Using cursor T002S22 */
         pr_default.execute(17, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Pedidos'.", "ForeignKeyNotFound", 1, "TPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void GetKey2S95( )
      {
         /* Using cursor T002S23 */
         pr_default.execute(18, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002S3 */
         pr_default.execute(1, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2S95( 11) ;
            RcdFound95 = 1;
            A210PedCod = T002S3_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
            A215PedFec = T002S3_A215PedFec[0];
            AssignAttri("", false, "A215PedFec", context.localUtil.Format(A215PedFec, "99/99/99"));
            A1605PedRef = T002S3_A1605PedRef[0];
            AssignAttri("", false, "A1605PedRef", A1605PedRef);
            A1590PedPorDsct = T002S3_A1590PedPorDsct[0];
            AssignAttri("", false, "A1590PedPorDsct", StringUtil.LTrimStr( A1590PedPorDsct, 6, 2));
            A1602PedPorIVA = T002S3_A1602PedPorIVA[0];
            AssignAttri("", false, "A1602PedPorIVA", StringUtil.LTrimStr( A1602PedPorIVA, 6, 2));
            A1604PedObs = T002S3_A1604PedObs[0];
            AssignAttri("", false, "A1604PedObs", A1604PedObs);
            A1609PedTItem = T002S3_A1609PedTItem[0];
            AssignAttri("", false, "A1609PedTItem", StringUtil.LTrimStr( (decimal)(A1609PedTItem), 4, 0));
            A1606PedSts = T002S3_A1606PedSts[0];
            AssignAttri("", false, "A1606PedSts", A1606PedSts);
            A1603PedRedondeo = T002S3_A1603PedRedondeo[0];
            AssignAttri("", false, "A1603PedRedondeo", StringUtil.LTrimStr( A1603PedRedondeo, 15, 2));
            A1613PedUsuC = T002S3_A1613PedUsuC[0];
            AssignAttri("", false, "A1613PedUsuC", A1613PedUsuC);
            A1596PedFecC = T002S3_A1596PedFecC[0];
            AssignAttri("", false, "A1596PedFecC", context.localUtil.TToC( A1596PedFecC, 8, 5, 0, 3, "/", ":", " "));
            A1614PedUsuM = T002S3_A1614PedUsuM[0];
            AssignAttri("", false, "A1614PedUsuM", A1614PedUsuM);
            A1597PedFecM = T002S3_A1597PedFecM[0];
            AssignAttri("", false, "A1597PedFecM", context.localUtil.TToC( A1597PedFecM, 8, 5, 0, 3, "/", ":", " "));
            A1611PedUsuA = T002S3_A1611PedUsuA[0];
            AssignAttri("", false, "A1611PedUsuA", A1611PedUsuA);
            A1593PedFecA = T002S3_A1593PedFecA[0];
            AssignAttri("", false, "A1593PedFecA", context.localUtil.TToC( A1593PedFecA, 8, 5, 0, 3, "/", ":", " "));
            A1612PedUsuA2 = T002S3_A1612PedUsuA2[0];
            AssignAttri("", false, "A1612PedUsuA2", A1612PedUsuA2);
            A1594PedFecA2 = T002S3_A1594PedFecA2[0];
            AssignAttri("", false, "A1594PedFecA2", context.localUtil.TToC( A1594PedFecA2, 8, 5, 0, 3, "/", ":", " "));
            A1600PedIngreso = T002S3_A1600PedIngreso[0];
            AssignAttri("", false, "A1600PedIngreso", A1600PedIngreso);
            A1599PedingObs = T002S3_A1599PedingObs[0];
            AssignAttri("", false, "A1599PedingObs", A1599PedingObs);
            A1545PedCliDespacho = T002S3_A1545PedCliDespacho[0];
            AssignAttri("", false, "A1545PedCliDespacho", StringUtil.LTrimStr( (decimal)(A1545PedCliDespacho), 6, 0));
            A1546PedCliDespacho2 = T002S3_A1546PedCliDespacho2[0];
            AssignAttri("", false, "A1546PedCliDespacho2", StringUtil.LTrimStr( (decimal)(A1546PedCliDespacho2), 6, 0));
            A1595PedFecAten = T002S3_A1595PedFecAten[0];
            n1595PedFecAten = T002S3_n1595PedFecAten[0];
            AssignAttri("", false, "A1595PedFecAten", context.localUtil.TToC( A1595PedFecAten, 8, 5, 0, 3, "/", ":", " "));
            A1549PedCotiza = T002S3_A1549PedCotiza[0];
            AssignAttri("", false, "A1549PedCotiza", StringUtil.Str( (decimal)(A1549PedCotiza), 1, 0));
            A1543PedAIVA = T002S3_A1543PedAIVA[0];
            A1608PedTipCod = T002S3_A1608PedTipCod[0];
            A45CliCod = T002S3_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A180MonCod = T002S3_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A212TPedCod = T002S3_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            A178TieCod = T002S3_A178TieCod[0];
            A214PedConp = T002S3_A214PedConp[0];
            AssignAttri("", false, "A214PedConp", StringUtil.LTrimStr( (decimal)(A214PedConp), 6, 0));
            A213PedLisp = T002S3_A213PedLisp[0];
            n213PedLisp = T002S3_n213PedLisp[0];
            AssignAttri("", false, "A213PedLisp", StringUtil.LTrimStr( (decimal)(A213PedLisp), 6, 0));
            A211PedVendCod = T002S3_A211PedVendCod[0];
            AssignAttri("", false, "A211PedVendCod", StringUtil.LTrimStr( (decimal)(A211PedVendCod), 6, 0));
            Z210PedCod = A210PedCod;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2S95( ) ;
            if ( AnyError == 1 )
            {
               RcdFound95 = 0;
               InitializeNonKey2S95( ) ;
            }
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey2S95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode95;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2S95( ) ;
         if ( RcdFound95 == 0 )
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
         RcdFound95 = 0;
         /* Using cursor T002S24 */
         pr_default.execute(19, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( StringUtil.StrCmp(T002S24_A210PedCod[0], A210PedCod) < 0 ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( StringUtil.StrCmp(T002S24_A210PedCod[0], A210PedCod) > 0 ) ) )
            {
               A210PedCod = T002S24_A210PedCod[0];
               AssignAttri("", false, "A210PedCod", A210PedCod);
               RcdFound95 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void move_previous( )
      {
         RcdFound95 = 0;
         /* Using cursor T002S25 */
         pr_default.execute(20, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(20) != 101) )
         {
            while ( (pr_default.getStatus(20) != 101) && ( ( StringUtil.StrCmp(T002S25_A210PedCod[0], A210PedCod) > 0 ) ) )
            {
               pr_default.readNext(20);
            }
            if ( (pr_default.getStatus(20) != 101) && ( ( StringUtil.StrCmp(T002S25_A210PedCod[0], A210PedCod) < 0 ) ) )
            {
               A210PedCod = T002S25_A210PedCod[0];
               AssignAttri("", false, "A210PedCod", A210PedCod);
               RcdFound95 = 1;
            }
         }
         pr_default.close(20);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2S95( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2S95( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound95 == 1 )
            {
               if ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 )
               {
                  A210PedCod = Z210PedCod;
                  AssignAttri("", false, "A210PedCod", A210PedCod);
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
                  Update2S95( ) ;
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2S95( ) ;
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
                     Insert2S95( ) ;
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
         if ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 )
         {
            A210PedCod = Z210PedCod;
            AssignAttri("", false, "A210PedCod", A210PedCod);
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
         GetKey2S95( ) ;
         if ( RcdFound95 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PEDCOD");
               AnyError = 1;
               GX_FocusControl = edtPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 )
            {
               A210PedCod = Z210PedCod;
               AssignAttri("", false, "A210PedCod", A210PedCod);
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
            if ( StringUtil.StrCmp(A210PedCod, Z210PedCod) != 0 )
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
         context.RollbackDataStores("clpedidos",pr_default);
         GX_FocusControl = edtPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2S0( ) ;
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
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PEDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2S95( ) ;
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2S95( ) ;
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
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedFec_Internalname;
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
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedFec_Internalname;
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
         ScanStart2S95( ) ;
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound95 != 0 )
            {
               ScanNext2S95( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPedFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2S95( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2S95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002S2 */
            pr_default.execute(0, new Object[] {A210PedCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z215PedFec ) != DateTimeUtil.ResetTime ( T002S2_A215PedFec[0] ) ) || ( StringUtil.StrCmp(Z1605PedRef, T002S2_A1605PedRef[0]) != 0 ) || ( Z1590PedPorDsct != T002S2_A1590PedPorDsct[0] ) || ( Z1602PedPorIVA != T002S2_A1602PedPorIVA[0] ) || ( Z1609PedTItem != T002S2_A1609PedTItem[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1606PedSts, T002S2_A1606PedSts[0]) != 0 ) || ( Z1603PedRedondeo != T002S2_A1603PedRedondeo[0] ) || ( StringUtil.StrCmp(Z1613PedUsuC, T002S2_A1613PedUsuC[0]) != 0 ) || ( Z1596PedFecC != T002S2_A1596PedFecC[0] ) || ( StringUtil.StrCmp(Z1614PedUsuM, T002S2_A1614PedUsuM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1597PedFecM != T002S2_A1597PedFecM[0] ) || ( StringUtil.StrCmp(Z1611PedUsuA, T002S2_A1611PedUsuA[0]) != 0 ) || ( Z1593PedFecA != T002S2_A1593PedFecA[0] ) || ( StringUtil.StrCmp(Z1612PedUsuA2, T002S2_A1612PedUsuA2[0]) != 0 ) || ( Z1594PedFecA2 != T002S2_A1594PedFecA2[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1600PedIngreso, T002S2_A1600PedIngreso[0]) != 0 ) || ( Z1545PedCliDespacho != T002S2_A1545PedCliDespacho[0] ) || ( Z1546PedCliDespacho2 != T002S2_A1546PedCliDespacho2[0] ) || ( Z1595PedFecAten != T002S2_A1595PedFecAten[0] ) || ( Z1549PedCotiza != T002S2_A1549PedCotiza[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1543PedAIVA != T002S2_A1543PedAIVA[0] ) || ( StringUtil.StrCmp(Z1608PedTipCod, T002S2_A1608PedTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z45CliCod, T002S2_A45CliCod[0]) != 0 ) || ( Z180MonCod != T002S2_A180MonCod[0] ) || ( Z212TPedCod != T002S2_A212TPedCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z178TieCod != T002S2_A178TieCod[0] ) || ( Z214PedConp != T002S2_A214PedConp[0] ) || ( Z213PedLisp != T002S2_A213PedLisp[0] ) || ( Z211PedVendCod != T002S2_A211PedVendCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z215PedFec ) != DateTimeUtil.ResetTime ( T002S2_A215PedFec[0] ) )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedFec");
                  GXUtil.WriteLogRaw("Old: ",Z215PedFec);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A215PedFec[0]);
               }
               if ( StringUtil.StrCmp(Z1605PedRef, T002S2_A1605PedRef[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedRef");
                  GXUtil.WriteLogRaw("Old: ",Z1605PedRef);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1605PedRef[0]);
               }
               if ( Z1590PedPorDsct != T002S2_A1590PedPorDsct[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedPorDsct");
                  GXUtil.WriteLogRaw("Old: ",Z1590PedPorDsct);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1590PedPorDsct[0]);
               }
               if ( Z1602PedPorIVA != T002S2_A1602PedPorIVA[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedPorIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1602PedPorIVA);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1602PedPorIVA[0]);
               }
               if ( Z1609PedTItem != T002S2_A1609PedTItem[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedTItem");
                  GXUtil.WriteLogRaw("Old: ",Z1609PedTItem);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1609PedTItem[0]);
               }
               if ( StringUtil.StrCmp(Z1606PedSts, T002S2_A1606PedSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedSts");
                  GXUtil.WriteLogRaw("Old: ",Z1606PedSts);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1606PedSts[0]);
               }
               if ( Z1603PedRedondeo != T002S2_A1603PedRedondeo[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedRedondeo");
                  GXUtil.WriteLogRaw("Old: ",Z1603PedRedondeo);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1603PedRedondeo[0]);
               }
               if ( StringUtil.StrCmp(Z1613PedUsuC, T002S2_A1613PedUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z1613PedUsuC);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1613PedUsuC[0]);
               }
               if ( Z1596PedFecC != T002S2_A1596PedFecC[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedFecC");
                  GXUtil.WriteLogRaw("Old: ",Z1596PedFecC);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1596PedFecC[0]);
               }
               if ( StringUtil.StrCmp(Z1614PedUsuM, T002S2_A1614PedUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z1614PedUsuM);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1614PedUsuM[0]);
               }
               if ( Z1597PedFecM != T002S2_A1597PedFecM[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedFecM");
                  GXUtil.WriteLogRaw("Old: ",Z1597PedFecM);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1597PedFecM[0]);
               }
               if ( StringUtil.StrCmp(Z1611PedUsuA, T002S2_A1611PedUsuA[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedUsuA");
                  GXUtil.WriteLogRaw("Old: ",Z1611PedUsuA);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1611PedUsuA[0]);
               }
               if ( Z1593PedFecA != T002S2_A1593PedFecA[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedFecA");
                  GXUtil.WriteLogRaw("Old: ",Z1593PedFecA);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1593PedFecA[0]);
               }
               if ( StringUtil.StrCmp(Z1612PedUsuA2, T002S2_A1612PedUsuA2[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedUsuA2");
                  GXUtil.WriteLogRaw("Old: ",Z1612PedUsuA2);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1612PedUsuA2[0]);
               }
               if ( Z1594PedFecA2 != T002S2_A1594PedFecA2[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedFecA2");
                  GXUtil.WriteLogRaw("Old: ",Z1594PedFecA2);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1594PedFecA2[0]);
               }
               if ( StringUtil.StrCmp(Z1600PedIngreso, T002S2_A1600PedIngreso[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedIngreso");
                  GXUtil.WriteLogRaw("Old: ",Z1600PedIngreso);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1600PedIngreso[0]);
               }
               if ( Z1545PedCliDespacho != T002S2_A1545PedCliDespacho[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedCliDespacho");
                  GXUtil.WriteLogRaw("Old: ",Z1545PedCliDespacho);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1545PedCliDespacho[0]);
               }
               if ( Z1546PedCliDespacho2 != T002S2_A1546PedCliDespacho2[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedCliDespacho2");
                  GXUtil.WriteLogRaw("Old: ",Z1546PedCliDespacho2);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1546PedCliDespacho2[0]);
               }
               if ( Z1595PedFecAten != T002S2_A1595PedFecAten[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedFecAten");
                  GXUtil.WriteLogRaw("Old: ",Z1595PedFecAten);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1595PedFecAten[0]);
               }
               if ( Z1549PedCotiza != T002S2_A1549PedCotiza[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedCotiza");
                  GXUtil.WriteLogRaw("Old: ",Z1549PedCotiza);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1549PedCotiza[0]);
               }
               if ( Z1543PedAIVA != T002S2_A1543PedAIVA[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedAIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1543PedAIVA);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1543PedAIVA[0]);
               }
               if ( StringUtil.StrCmp(Z1608PedTipCod, T002S2_A1608PedTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z1608PedTipCod);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A1608PedTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z45CliCod, T002S2_A45CliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"CliCod");
                  GXUtil.WriteLogRaw("Old: ",Z45CliCod);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A45CliCod[0]);
               }
               if ( Z180MonCod != T002S2_A180MonCod[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"MonCod");
                  GXUtil.WriteLogRaw("Old: ",Z180MonCod);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A180MonCod[0]);
               }
               if ( Z212TPedCod != T002S2_A212TPedCod[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"TPedCod");
                  GXUtil.WriteLogRaw("Old: ",Z212TPedCod);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A212TPedCod[0]);
               }
               if ( Z178TieCod != T002S2_A178TieCod[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"TieCod");
                  GXUtil.WriteLogRaw("Old: ",Z178TieCod);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A178TieCod[0]);
               }
               if ( Z214PedConp != T002S2_A214PedConp[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedConp");
                  GXUtil.WriteLogRaw("Old: ",Z214PedConp);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A214PedConp[0]);
               }
               if ( Z213PedLisp != T002S2_A213PedLisp[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedLisp");
                  GXUtil.WriteLogRaw("Old: ",Z213PedLisp);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A213PedLisp[0]);
               }
               if ( Z211PedVendCod != T002S2_A211PedVendCod[0] )
               {
                  GXUtil.WriteLog("clpedidos:[seudo value changed for attri]"+"PedVendCod");
                  GXUtil.WriteLogRaw("Old: ",Z211PedVendCod);
                  GXUtil.WriteLogRaw("Current: ",T002S2_A211PedVendCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLPEDIDOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2S95( )
      {
         BeforeValidate2S95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2S95( 0) ;
            CheckOptimisticConcurrency2S95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2S95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002S26 */
                     pr_default.execute(21, new Object[] {A210PedCod, A215PedFec, A1605PedRef, A1590PedPorDsct, A1602PedPorIVA, A1604PedObs, A1609PedTItem, A1606PedSts, A1603PedRedondeo, A1613PedUsuC, A1596PedFecC, A1614PedUsuM, A1597PedFecM, A1611PedUsuA, A1593PedFecA, A1612PedUsuA2, A1594PedFecA2, A1600PedIngreso, A1599PedingObs, A1545PedCliDespacho, A1546PedCliDespacho2, n1595PedFecAten, A1595PedFecAten, A1549PedCotiza, A1543PedAIVA, A1608PedTipCod, A45CliCod, A180MonCod, A212TPedCod, A178TieCod, A214PedConp, n213PedLisp, A213PedLisp, A211PedVendCod, A1598PedICBPER});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOS");
                     if ( (pr_default.getStatus(21) == 1) )
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
                           ResetCaption2S0( ) ;
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
               Load2S95( ) ;
            }
            EndLevel2S95( ) ;
         }
         CloseExtendedTableCursors2S95( ) ;
      }

      protected void Update2S95( )
      {
         BeforeValidate2S95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S95( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2S95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002S27 */
                     pr_default.execute(22, new Object[] {A215PedFec, A1605PedRef, A1590PedPorDsct, A1602PedPorIVA, A1604PedObs, A1609PedTItem, A1606PedSts, A1603PedRedondeo, A1613PedUsuC, A1596PedFecC, A1614PedUsuM, A1597PedFecM, A1611PedUsuA, A1593PedFecA, A1612PedUsuA2, A1594PedFecA2, A1600PedIngreso, A1599PedingObs, A1545PedCliDespacho, A1546PedCliDespacho2, n1595PedFecAten, A1595PedFecAten, A1549PedCotiza, A1543PedAIVA, A1608PedTipCod, A45CliCod, A180MonCod, A212TPedCod, A178TieCod, A214PedConp, n213PedLisp, A213PedLisp, A211PedVendCod, A1598PedICBPER, A210PedCod});
                     pr_default.close(22);
                     dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOS");
                     if ( (pr_default.getStatus(22) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLPEDIDOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2S95( ) ;
                     if ( AnyError == 0 )
                     {
                        new clpedidosupdateredundancy(context ).execute( ref  A210PedCod) ;
                        AssignAttri("", false, "A210PedCod", A210PedCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2S0( ) ;
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
            EndLevel2S95( ) ;
         }
         CloseExtendedTableCursors2S95( ) ;
      }

      protected void DeferredUpdate2S95( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2S95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2S95( ) ;
            AfterConfirm2S95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2S95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002S28 */
                  pr_default.execute(23, new Object[] {A210PedCod});
                  pr_default.close(23);
                  dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound95 == 0 )
                        {
                           InitAll2S95( ) ;
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
                        ResetCaption2S0( ) ;
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
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2S95( ) ;
         Gx_mode = sMode95;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2S95( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002S30 */
            pr_default.execute(24, new Object[] {A210PedCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A1598PedICBPER = T002S30_A1598PedICBPER[0];
               A1582PedSubIna = T002S30_A1582PedSubIna[0];
               AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
               A1583PedSubAfe = T002S30_A1583PedSubAfe[0];
               AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
               A1589PedSubExonerado = T002S30_A1589PedSubExonerado[0];
               A1607PedSubGratuito = T002S30_A1607PedSubGratuito[0];
               A1584PedSubSelectivo = T002S30_A1584PedSubSelectivo[0];
               AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
            }
            else
            {
               A1598PedICBPER = 0;
               AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrimStr( A1598PedICBPER, 15, 2));
               A1582PedSubIna = 0;
               AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
               A1583PedSubAfe = 0;
               AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
               A1589PedSubExonerado = 0;
               AssignAttri("", false, "A1589PedSubExonerado", StringUtil.LTrimStr( A1589PedSubExonerado, 15, 2));
               A1607PedSubGratuito = 0;
               AssignAttri("", false, "A1607PedSubGratuito", StringUtil.LTrimStr( A1607PedSubGratuito, 15, 2));
               A1584PedSubSelectivo = 0;
               AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
            }
            pr_default.close(24);
            A1581PedSubT = (decimal)(A1582PedSubIna+A1583PedSubAfe+A1584PedSubSelectivo+A1589PedSubExonerado);
            AssignAttri("", false, "A1581PedSubT", StringUtil.LTrimStr( A1581PedSubT, 15, 2));
            /* Using cursor T002S31 */
            pr_default.execute(25, new Object[] {A214PedConp});
            A1548PedConpDsc = T002S31_A1548PedConpDsc[0];
            AssignAttri("", false, "A1548PedConpDsc", A1548PedConpDsc);
            A1547PedConpDias = T002S31_A1547PedConpDias[0];
            AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrimStr( (decimal)(A1547PedConpDias), 4, 0));
            pr_default.close(25);
            A1580PedDsct = (decimal)(((A1581PedSubT*A1590PedPorDsct)/ (decimal)(100)));
            AssignAttri("", false, "A1580PedDsct", StringUtil.LTrimStr( A1580PedDsct, 15, 2));
            A1601PedIVA = (decimal)((((A1583PedSubAfe+A1584PedSubSelectivo-A1580PedDsct)*A1602PedPorIVA)/ (decimal)(100))+A1603PedRedondeo);
            AssignAttri("", false, "A1601PedIVA", StringUtil.LTrimStr( A1601PedIVA, 15, 2));
            A1610PedTotal = (decimal)((A1581PedSubT-A1580PedDsct)+A1601PedIVA+A1598PedICBPER);
            AssignAttri("", false, "A1610PedTotal", StringUtil.LTrimStr( A1610PedTotal, 15, 2));
            /* Using cursor T002S32 */
            pr_default.execute(26, new Object[] {A211PedVendCod});
            A1615PedVendDsc = T002S32_A1615PedVendDsc[0];
            AssignAttri("", false, "A1615PedVendDsc", A1615PedVendDsc);
            pr_default.close(26);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002S33 */
            pr_default.execute(27, new Object[] {A210PedCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLPEDIDOSDETLOTE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T002S34 */
            pr_default.execute(28, new Object[] {A210PedCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T002S35 */
            pr_default.execute(29, new Object[] {A210PedCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void EndLevel2S95( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2S95( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(25);
            pr_default.close(26);
            pr_default.close(24);
            context.CommitDataStores("clpedidos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(25);
            pr_default.close(26);
            pr_default.close(24);
            context.RollbackDataStores("clpedidos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2S95( )
      {
         /* Using cursor T002S36 */
         pr_default.execute(30);
         RcdFound95 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound95 = 1;
            A210PedCod = T002S36_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2S95( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound95 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound95 = 1;
            A210PedCod = T002S36_A210PedCod[0];
            AssignAttri("", false, "A210PedCod", A210PedCod);
         }
      }

      protected void ScanEnd2S95( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm2S95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2S95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2S95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2S95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2S95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2S95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2S95( )
      {
         edtPedCod_Enabled = 0;
         AssignProp("", false, edtPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedCod_Enabled), 5, 0), true);
         edtPedFec_Enabled = 0;
         AssignProp("", false, edtPedFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedFec_Enabled), 5, 0), true);
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         edtPedConp_Enabled = 0;
         AssignProp("", false, edtPedConp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedConp_Enabled), 5, 0), true);
         edtPedLisp_Enabled = 0;
         AssignProp("", false, edtPedLisp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedLisp_Enabled), 5, 0), true);
         edtPedRef_Enabled = 0;
         AssignProp("", false, edtPedRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedRef_Enabled), 5, 0), true);
         edtPedPorDsct_Enabled = 0;
         AssignProp("", false, edtPedPorDsct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedPorDsct_Enabled), 5, 0), true);
         edtPedPorIVA_Enabled = 0;
         AssignProp("", false, edtPedPorIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedPorIVA_Enabled), 5, 0), true);
         edtPedObs_Enabled = 0;
         AssignProp("", false, edtPedObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedObs_Enabled), 5, 0), true);
         edtPedTItem_Enabled = 0;
         AssignProp("", false, edtPedTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedTItem_Enabled), 5, 0), true);
         edtPedSts_Enabled = 0;
         AssignProp("", false, edtPedSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedSts_Enabled), 5, 0), true);
         edtPedRedondeo_Enabled = 0;
         AssignProp("", false, edtPedRedondeo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedRedondeo_Enabled), 5, 0), true);
         edtPedVendCod_Enabled = 0;
         AssignProp("", false, edtPedVendCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedVendCod_Enabled), 5, 0), true);
         edtPedUsuC_Enabled = 0;
         AssignProp("", false, edtPedUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedUsuC_Enabled), 5, 0), true);
         edtPedFecC_Enabled = 0;
         AssignProp("", false, edtPedFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedFecC_Enabled), 5, 0), true);
         edtPedUsuM_Enabled = 0;
         AssignProp("", false, edtPedUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedUsuM_Enabled), 5, 0), true);
         edtPedDsct_Enabled = 0;
         AssignProp("", false, edtPedDsct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedDsct_Enabled), 5, 0), true);
         edtPedFecM_Enabled = 0;
         AssignProp("", false, edtPedFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedFecM_Enabled), 5, 0), true);
         edtPedUsuA_Enabled = 0;
         AssignProp("", false, edtPedUsuA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedUsuA_Enabled), 5, 0), true);
         edtPedFecA_Enabled = 0;
         AssignProp("", false, edtPedFecA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedFecA_Enabled), 5, 0), true);
         edtPedUsuA2_Enabled = 0;
         AssignProp("", false, edtPedUsuA2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedUsuA2_Enabled), 5, 0), true);
         edtPedFecA2_Enabled = 0;
         AssignProp("", false, edtPedFecA2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedFecA2_Enabled), 5, 0), true);
         edtPedIngreso_Enabled = 0;
         AssignProp("", false, edtPedIngreso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedIngreso_Enabled), 5, 0), true);
         edtPedingObs_Enabled = 0;
         AssignProp("", false, edtPedingObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedingObs_Enabled), 5, 0), true);
         edtPedCliDespacho_Enabled = 0;
         AssignProp("", false, edtPedCliDespacho_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedCliDespacho_Enabled), 5, 0), true);
         edtPedCliDespacho2_Enabled = 0;
         AssignProp("", false, edtPedCliDespacho2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedCliDespacho2_Enabled), 5, 0), true);
         edtPedFecAten_Enabled = 0;
         AssignProp("", false, edtPedFecAten_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedFecAten_Enabled), 5, 0), true);
         edtPedCotiza_Enabled = 0;
         AssignProp("", false, edtPedCotiza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedCotiza_Enabled), 5, 0), true);
         edtTPedCod_Enabled = 0;
         AssignProp("", false, edtTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedCod_Enabled), 5, 0), true);
         edtPedSubT_Enabled = 0;
         AssignProp("", false, edtPedSubT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedSubT_Enabled), 5, 0), true);
         edtPedIVA_Enabled = 0;
         AssignProp("", false, edtPedIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedIVA_Enabled), 5, 0), true);
         edtPedTotal_Enabled = 0;
         AssignProp("", false, edtPedTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedTotal_Enabled), 5, 0), true);
         edtPedSubIna_Enabled = 0;
         AssignProp("", false, edtPedSubIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedSubIna_Enabled), 5, 0), true);
         edtPedSubAfe_Enabled = 0;
         AssignProp("", false, edtPedSubAfe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedSubAfe_Enabled), 5, 0), true);
         edtPedConpDsc_Enabled = 0;
         AssignProp("", false, edtPedConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedConpDsc_Enabled), 5, 0), true);
         edtPedVendDsc_Enabled = 0;
         AssignProp("", false, edtPedVendDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedVendDsc_Enabled), 5, 0), true);
         edtPedSubSelectivo_Enabled = 0;
         AssignProp("", false, edtPedSubSelectivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedSubSelectivo_Enabled), 5, 0), true);
         edtPedConpDias_Enabled = 0;
         AssignProp("", false, edtPedConpDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPedConpDias_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2S95( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2S0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245416", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clpedidos.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLPEDIDOS");
         forbiddenHiddens.Add("TieCod", context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"));
         forbiddenHiddens.Add("PedAIVA", context.localUtil.Format( (decimal)(A1543PedAIVA), "9"));
         forbiddenHiddens.Add("PedTipCod", StringUtil.RTrim( context.localUtil.Format( A1608PedTipCod, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clpedidos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z210PedCod", StringUtil.RTrim( Z210PedCod));
         GxWebStd.gx_hidden_field( context, "Z215PedFec", context.localUtil.DToC( Z215PedFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1605PedRef", StringUtil.RTrim( Z1605PedRef));
         GxWebStd.gx_hidden_field( context, "Z1590PedPorDsct", StringUtil.LTrim( StringUtil.NToC( Z1590PedPorDsct, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1602PedPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1602PedPorIVA, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1609PedTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1609PedTItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1606PedSts", StringUtil.RTrim( Z1606PedSts));
         GxWebStd.gx_hidden_field( context, "Z1603PedRedondeo", StringUtil.LTrim( StringUtil.NToC( Z1603PedRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1613PedUsuC", StringUtil.RTrim( Z1613PedUsuC));
         GxWebStd.gx_hidden_field( context, "Z1596PedFecC", context.localUtil.TToC( Z1596PedFecC, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1614PedUsuM", StringUtil.RTrim( Z1614PedUsuM));
         GxWebStd.gx_hidden_field( context, "Z1597PedFecM", context.localUtil.TToC( Z1597PedFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1611PedUsuA", StringUtil.RTrim( Z1611PedUsuA));
         GxWebStd.gx_hidden_field( context, "Z1593PedFecA", context.localUtil.TToC( Z1593PedFecA, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1612PedUsuA2", StringUtil.RTrim( Z1612PedUsuA2));
         GxWebStd.gx_hidden_field( context, "Z1594PedFecA2", context.localUtil.TToC( Z1594PedFecA2, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1600PedIngreso", StringUtil.RTrim( Z1600PedIngreso));
         GxWebStd.gx_hidden_field( context, "Z1545PedCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1545PedCliDespacho), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1546PedCliDespacho2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1546PedCliDespacho2), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1595PedFecAten", context.localUtil.TToC( Z1595PedFecAten, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1549PedCotiza", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1549PedCotiza), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1543PedAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1543PedAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1608PedTipCod", StringUtil.RTrim( Z1608PedTipCod));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z212TPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212TPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z214PedConp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z214PedConp), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z213PedLisp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z213PedLisp), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z211PedVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211PedVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PEDICBPER", StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDSUBEXONERADO", StringUtil.LTrim( StringUtil.NToC( A1589PedSubExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1543PedAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDTIPCOD", StringUtil.RTrim( A1608PedTipCod));
         GxWebStd.gx_hidden_field( context, "TIECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PEDSUBGRATUITO", StringUtil.LTrim( StringUtil.NToC( A1607PedSubGratuito, 15, 2, ".", "")));
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
         return formatLink("clpedidos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLPEDIDOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pedidos - Cabecera" ;
      }

      protected void InitializeNonKey2S95( )
      {
         A1581PedSubT = 0;
         AssignAttri("", false, "A1581PedSubT", StringUtil.LTrimStr( A1581PedSubT, 15, 2));
         A1610PedTotal = 0;
         AssignAttri("", false, "A1610PedTotal", StringUtil.LTrimStr( A1610PedTotal, 15, 2));
         A1601PedIVA = 0;
         AssignAttri("", false, "A1601PedIVA", StringUtil.LTrimStr( A1601PedIVA, 15, 2));
         A1580PedDsct = 0;
         AssignAttri("", false, "A1580PedDsct", StringUtil.LTrimStr( A1580PedDsct, 15, 2));
         A1598PedICBPER = 0;
         AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrimStr( A1598PedICBPER, 15, 2));
         A215PedFec = DateTime.MinValue;
         AssignAttri("", false, "A215PedFec", context.localUtil.Format(A215PedFec, "99/99/99"));
         A45CliCod = "";
         AssignAttri("", false, "A45CliCod", A45CliCod);
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         A214PedConp = 0;
         AssignAttri("", false, "A214PedConp", StringUtil.LTrimStr( (decimal)(A214PedConp), 6, 0));
         A213PedLisp = 0;
         n213PedLisp = false;
         AssignAttri("", false, "A213PedLisp", StringUtil.LTrimStr( (decimal)(A213PedLisp), 6, 0));
         n213PedLisp = ((0==A213PedLisp) ? true : false);
         A1605PedRef = "";
         AssignAttri("", false, "A1605PedRef", A1605PedRef);
         A1590PedPorDsct = 0;
         AssignAttri("", false, "A1590PedPorDsct", StringUtil.LTrimStr( A1590PedPorDsct, 6, 2));
         A1602PedPorIVA = 0;
         AssignAttri("", false, "A1602PedPorIVA", StringUtil.LTrimStr( A1602PedPorIVA, 6, 2));
         A1604PedObs = "";
         AssignAttri("", false, "A1604PedObs", A1604PedObs);
         A1609PedTItem = 0;
         AssignAttri("", false, "A1609PedTItem", StringUtil.LTrimStr( (decimal)(A1609PedTItem), 4, 0));
         A1606PedSts = "";
         AssignAttri("", false, "A1606PedSts", A1606PedSts);
         A1603PedRedondeo = 0;
         AssignAttri("", false, "A1603PedRedondeo", StringUtil.LTrimStr( A1603PedRedondeo, 15, 2));
         A211PedVendCod = 0;
         AssignAttri("", false, "A211PedVendCod", StringUtil.LTrimStr( (decimal)(A211PedVendCod), 6, 0));
         A1613PedUsuC = "";
         AssignAttri("", false, "A1613PedUsuC", A1613PedUsuC);
         A1596PedFecC = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1596PedFecC", context.localUtil.TToC( A1596PedFecC, 8, 5, 0, 3, "/", ":", " "));
         A1614PedUsuM = "";
         AssignAttri("", false, "A1614PedUsuM", A1614PedUsuM);
         A1597PedFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1597PedFecM", context.localUtil.TToC( A1597PedFecM, 8, 5, 0, 3, "/", ":", " "));
         A1611PedUsuA = "";
         AssignAttri("", false, "A1611PedUsuA", A1611PedUsuA);
         A1593PedFecA = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1593PedFecA", context.localUtil.TToC( A1593PedFecA, 8, 5, 0, 3, "/", ":", " "));
         A1612PedUsuA2 = "";
         AssignAttri("", false, "A1612PedUsuA2", A1612PedUsuA2);
         A1594PedFecA2 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1594PedFecA2", context.localUtil.TToC( A1594PedFecA2, 8, 5, 0, 3, "/", ":", " "));
         A1600PedIngreso = "";
         AssignAttri("", false, "A1600PedIngreso", A1600PedIngreso);
         A1599PedingObs = "";
         AssignAttri("", false, "A1599PedingObs", A1599PedingObs);
         A1545PedCliDespacho = 0;
         AssignAttri("", false, "A1545PedCliDespacho", StringUtil.LTrimStr( (decimal)(A1545PedCliDespacho), 6, 0));
         A1546PedCliDespacho2 = 0;
         AssignAttri("", false, "A1546PedCliDespacho2", StringUtil.LTrimStr( (decimal)(A1546PedCliDespacho2), 6, 0));
         A1595PedFecAten = (DateTime)(DateTime.MinValue);
         n1595PedFecAten = false;
         AssignAttri("", false, "A1595PedFecAten", context.localUtil.TToC( A1595PedFecAten, 8, 5, 0, 3, "/", ":", " "));
         A1549PedCotiza = 0;
         AssignAttri("", false, "A1549PedCotiza", StringUtil.Str( (decimal)(A1549PedCotiza), 1, 0));
         A212TPedCod = 0;
         AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         A1582PedSubIna = 0;
         AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrimStr( A1582PedSubIna, 15, 2));
         A1583PedSubAfe = 0;
         AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrimStr( A1583PedSubAfe, 15, 2));
         A1548PedConpDsc = "";
         AssignAttri("", false, "A1548PedConpDsc", A1548PedConpDsc);
         A1615PedVendDsc = "";
         AssignAttri("", false, "A1615PedVendDsc", A1615PedVendDsc);
         A1589PedSubExonerado = 0;
         AssignAttri("", false, "A1589PedSubExonerado", StringUtil.LTrimStr( A1589PedSubExonerado, 15, 2));
         A1607PedSubGratuito = 0;
         AssignAttri("", false, "A1607PedSubGratuito", StringUtil.LTrimStr( A1607PedSubGratuito, 15, 2));
         A1584PedSubSelectivo = 0;
         AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrimStr( A1584PedSubSelectivo, 15, 2));
         A1547PedConpDias = 0;
         AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrimStr( (decimal)(A1547PedConpDias), 4, 0));
         A178TieCod = 0;
         AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         A1543PedAIVA = 0;
         AssignAttri("", false, "A1543PedAIVA", StringUtil.Str( (decimal)(A1543PedAIVA), 1, 0));
         A1608PedTipCod = "";
         AssignAttri("", false, "A1608PedTipCod", A1608PedTipCod);
         Z215PedFec = DateTime.MinValue;
         Z1605PedRef = "";
         Z1590PedPorDsct = 0;
         Z1602PedPorIVA = 0;
         Z1609PedTItem = 0;
         Z1606PedSts = "";
         Z1603PedRedondeo = 0;
         Z1613PedUsuC = "";
         Z1596PedFecC = (DateTime)(DateTime.MinValue);
         Z1614PedUsuM = "";
         Z1597PedFecM = (DateTime)(DateTime.MinValue);
         Z1611PedUsuA = "";
         Z1593PedFecA = (DateTime)(DateTime.MinValue);
         Z1612PedUsuA2 = "";
         Z1594PedFecA2 = (DateTime)(DateTime.MinValue);
         Z1600PedIngreso = "";
         Z1545PedCliDespacho = 0;
         Z1546PedCliDespacho2 = 0;
         Z1595PedFecAten = (DateTime)(DateTime.MinValue);
         Z1549PedCotiza = 0;
         Z1543PedAIVA = 0;
         Z1608PedTipCod = "";
         Z45CliCod = "";
         Z180MonCod = 0;
         Z212TPedCod = 0;
         Z178TieCod = 0;
         Z214PedConp = 0;
         Z213PedLisp = 0;
         Z211PedVendCod = 0;
      }

      protected void InitAll2S95( )
      {
         A210PedCod = "";
         AssignAttri("", false, "A210PedCod", A210PedCod);
         InitializeNonKey2S95( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245449", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("clpedidos.js", "?202281810245450", false, true);
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
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPedFec_Internalname = "PEDFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCliCod_Internalname = "CLICOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMonCod_Internalname = "MONCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPedConp_Internalname = "PEDCONP";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPedLisp_Internalname = "PEDLISP";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPedRef_Internalname = "PEDREF";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPedPorDsct_Internalname = "PEDPORDSCT";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPedPorIVA_Internalname = "PEDPORIVA";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPedObs_Internalname = "PEDOBS";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtPedTItem_Internalname = "PEDTITEM";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtPedSts_Internalname = "PEDSTS";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtPedRedondeo_Internalname = "PEDREDONDEO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtPedVendCod_Internalname = "PEDVENDCOD";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtPedUsuC_Internalname = "PEDUSUC";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtPedFecC_Internalname = "PEDFECC";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtPedUsuM_Internalname = "PEDUSUM";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtPedDsct_Internalname = "PEDDSCT";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtPedFecM_Internalname = "PEDFECM";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtPedUsuA_Internalname = "PEDUSUA";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtPedFecA_Internalname = "PEDFECA";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtPedUsuA2_Internalname = "PEDUSUA2";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtPedFecA2_Internalname = "PEDFECA2";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtPedIngreso_Internalname = "PEDINGRESO";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtPedingObs_Internalname = "PEDINGOBS";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtPedCliDespacho_Internalname = "PEDCLIDESPACHO";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtPedCliDespacho2_Internalname = "PEDCLIDESPACHO2";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtPedFecAten_Internalname = "PEDFECATEN";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtPedCotiza_Internalname = "PEDCOTIZA";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtTPedCod_Internalname = "TPEDCOD";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtPedSubT_Internalname = "PEDSUBT";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtPedIVA_Internalname = "PEDIVA";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtPedTotal_Internalname = "PEDTOTAL";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtPedSubIna_Internalname = "PEDSUBINA";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtPedSubAfe_Internalname = "PEDSUBAFE";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtPedConpDsc_Internalname = "PEDCONPDSC";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtPedVendDsc_Internalname = "PEDVENDDSC";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtPedSubSelectivo_Internalname = "PEDSUBSELECTIVO";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtPedConpDias_Internalname = "PEDCONPDIAS";
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
         Form.Caption = "Pedidos - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPedConpDias_Jsonclick = "";
         edtPedConpDias_Enabled = 0;
         edtPedSubSelectivo_Jsonclick = "";
         edtPedSubSelectivo_Enabled = 0;
         edtPedVendDsc_Jsonclick = "";
         edtPedVendDsc_Enabled = 0;
         edtPedConpDsc_Jsonclick = "";
         edtPedConpDsc_Enabled = 0;
         edtPedSubAfe_Jsonclick = "";
         edtPedSubAfe_Enabled = 0;
         edtPedSubIna_Jsonclick = "";
         edtPedSubIna_Enabled = 0;
         edtPedTotal_Jsonclick = "";
         edtPedTotal_Enabled = 0;
         edtPedIVA_Jsonclick = "";
         edtPedIVA_Enabled = 0;
         edtPedSubT_Jsonclick = "";
         edtPedSubT_Enabled = 0;
         edtTPedCod_Jsonclick = "";
         edtTPedCod_Enabled = 1;
         edtPedCotiza_Jsonclick = "";
         edtPedCotiza_Enabled = 1;
         edtPedFecAten_Jsonclick = "";
         edtPedFecAten_Enabled = 1;
         edtPedCliDespacho2_Jsonclick = "";
         edtPedCliDespacho2_Enabled = 1;
         edtPedCliDespacho_Jsonclick = "";
         edtPedCliDespacho_Enabled = 1;
         edtPedingObs_Enabled = 1;
         edtPedIngreso_Jsonclick = "";
         edtPedIngreso_Enabled = 1;
         edtPedFecA2_Jsonclick = "";
         edtPedFecA2_Enabled = 1;
         edtPedUsuA2_Jsonclick = "";
         edtPedUsuA2_Enabled = 1;
         edtPedFecA_Jsonclick = "";
         edtPedFecA_Enabled = 1;
         edtPedUsuA_Jsonclick = "";
         edtPedUsuA_Enabled = 1;
         edtPedFecM_Jsonclick = "";
         edtPedFecM_Enabled = 1;
         edtPedDsct_Jsonclick = "";
         edtPedDsct_Enabled = 0;
         edtPedUsuM_Jsonclick = "";
         edtPedUsuM_Enabled = 1;
         edtPedFecC_Jsonclick = "";
         edtPedFecC_Enabled = 1;
         edtPedUsuC_Jsonclick = "";
         edtPedUsuC_Enabled = 1;
         edtPedVendCod_Jsonclick = "";
         edtPedVendCod_Enabled = 1;
         edtPedRedondeo_Jsonclick = "";
         edtPedRedondeo_Enabled = 1;
         edtPedSts_Jsonclick = "";
         edtPedSts_Enabled = 1;
         edtPedTItem_Jsonclick = "";
         edtPedTItem_Enabled = 1;
         edtPedObs_Enabled = 1;
         edtPedPorIVA_Jsonclick = "";
         edtPedPorIVA_Enabled = 1;
         edtPedPorDsct_Jsonclick = "";
         edtPedPorDsct_Enabled = 1;
         edtPedRef_Jsonclick = "";
         edtPedRef_Enabled = 1;
         edtPedLisp_Jsonclick = "";
         edtPedLisp_Enabled = 1;
         edtPedConp_Jsonclick = "";
         edtPedConp_Enabled = 1;
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
         edtPedFec_Jsonclick = "";
         edtPedFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
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
         GX_FocusControl = edtPedFec_Internalname;
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
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T002S30 */
         pr_default.execute(24, new Object[] {A210PedCod});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A1598PedICBPER = T002S30_A1598PedICBPER[0];
            A1582PedSubIna = T002S30_A1582PedSubIna[0];
            A1583PedSubAfe = T002S30_A1583PedSubAfe[0];
            A1589PedSubExonerado = T002S30_A1589PedSubExonerado[0];
            A1607PedSubGratuito = T002S30_A1607PedSubGratuito[0];
            A1584PedSubSelectivo = T002S30_A1584PedSubSelectivo[0];
         }
         else
         {
            A1598PedICBPER = 0;
            A1582PedSubIna = 0;
            A1583PedSubAfe = 0;
            A1589PedSubExonerado = 0;
            A1607PedSubGratuito = 0;
            A1584PedSubSelectivo = 0;
         }
         pr_default.close(24);
         A1581PedSubT = (decimal)(A1582PedSubIna+A1583PedSubAfe+A1584PedSubSelectivo+A1589PedSubExonerado);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A215PedFec", context.localUtil.Format(A215PedFec, "99/99/99"));
         AssignAttri("", false, "A45CliCod", StringUtil.RTrim( A45CliCod));
         AssignAttri("", false, "A180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A214PedConp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A214PedConp), 6, 0, ".", "")));
         AssignAttri("", false, "A213PedLisp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A213PedLisp), 6, 0, ".", "")));
         AssignAttri("", false, "A1605PedRef", StringUtil.RTrim( A1605PedRef));
         AssignAttri("", false, "A1590PedPorDsct", StringUtil.LTrim( StringUtil.NToC( A1590PedPorDsct, 6, 2, ".", "")));
         AssignAttri("", false, "A1602PedPorIVA", StringUtil.LTrim( StringUtil.NToC( A1602PedPorIVA, 6, 2, ".", "")));
         AssignAttri("", false, "A1604PedObs", A1604PedObs);
         AssignAttri("", false, "A1609PedTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1609PedTItem), 4, 0, ".", "")));
         AssignAttri("", false, "A1606PedSts", StringUtil.RTrim( A1606PedSts));
         AssignAttri("", false, "A1603PedRedondeo", StringUtil.LTrim( StringUtil.NToC( A1603PedRedondeo, 15, 2, ".", "")));
         AssignAttri("", false, "A211PedVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A211PedVendCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1613PedUsuC", StringUtil.RTrim( A1613PedUsuC));
         AssignAttri("", false, "A1596PedFecC", context.localUtil.TToC( A1596PedFecC, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1614PedUsuM", StringUtil.RTrim( A1614PedUsuM));
         AssignAttri("", false, "A1597PedFecM", context.localUtil.TToC( A1597PedFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1611PedUsuA", StringUtil.RTrim( A1611PedUsuA));
         AssignAttri("", false, "A1593PedFecA", context.localUtil.TToC( A1593PedFecA, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1612PedUsuA2", StringUtil.RTrim( A1612PedUsuA2));
         AssignAttri("", false, "A1594PedFecA2", context.localUtil.TToC( A1594PedFecA2, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1600PedIngreso", StringUtil.RTrim( A1600PedIngreso));
         AssignAttri("", false, "A1599PedingObs", A1599PedingObs);
         AssignAttri("", false, "A1545PedCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1545PedCliDespacho), 6, 0, ".", "")));
         AssignAttri("", false, "A1546PedCliDespacho2", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1546PedCliDespacho2), 6, 0, ".", "")));
         AssignAttri("", false, "A1595PedFecAten", context.localUtil.TToC( A1595PedFecAten, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1549PedCotiza", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1549PedCotiza), 1, 0, ".", "")));
         AssignAttri("", false, "A212TPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A212TPedCod), 6, 0, ".", "")));
         AssignAttri("", false, "A178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1543PedAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1543PedAIVA), 1, 0, ".", "")));
         AssignAttri("", false, "A1608PedTipCod", StringUtil.RTrim( A1608PedTipCod));
         AssignAttri("", false, "A1598PedICBPER", StringUtil.LTrim( StringUtil.NToC( A1598PedICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A1582PedSubIna", StringUtil.LTrim( StringUtil.NToC( A1582PedSubIna, 15, 2, ".", "")));
         AssignAttri("", false, "A1583PedSubAfe", StringUtil.LTrim( StringUtil.NToC( A1583PedSubAfe, 15, 2, ".", "")));
         AssignAttri("", false, "A1589PedSubExonerado", StringUtil.LTrim( StringUtil.NToC( A1589PedSubExonerado, 15, 2, ".", "")));
         AssignAttri("", false, "A1607PedSubGratuito", StringUtil.LTrim( StringUtil.NToC( A1607PedSubGratuito, 15, 2, ".", "")));
         AssignAttri("", false, "A1584PedSubSelectivo", StringUtil.LTrim( StringUtil.NToC( A1584PedSubSelectivo, 15, 2, ".", "")));
         AssignAttri("", false, "A1581PedSubT", StringUtil.LTrim( StringUtil.NToC( A1581PedSubT, 15, 2, ".", "")));
         AssignAttri("", false, "A1580PedDsct", StringUtil.LTrim( StringUtil.NToC( A1580PedDsct, 15, 2, ".", "")));
         AssignAttri("", false, "A1601PedIVA", StringUtil.LTrim( StringUtil.NToC( A1601PedIVA, 15, 2, ".", "")));
         AssignAttri("", false, "A1610PedTotal", StringUtil.LTrim( StringUtil.NToC( A1610PedTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A1548PedConpDsc", StringUtil.RTrim( A1548PedConpDsc));
         AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1547PedConpDias), 4, 0, ".", "")));
         AssignAttri("", false, "A1615PedVendDsc", StringUtil.RTrim( A1615PedVendDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z210PedCod", StringUtil.RTrim( Z210PedCod));
         GxWebStd.gx_hidden_field( context, "Z215PedFec", context.localUtil.Format(Z215PedFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z214PedConp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z214PedConp), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z213PedLisp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z213PedLisp), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1605PedRef", StringUtil.RTrim( Z1605PedRef));
         GxWebStd.gx_hidden_field( context, "Z1590PedPorDsct", StringUtil.LTrim( StringUtil.NToC( Z1590PedPorDsct, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1602PedPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1602PedPorIVA, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1604PedObs", Z1604PedObs);
         GxWebStd.gx_hidden_field( context, "Z1609PedTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1609PedTItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1606PedSts", StringUtil.RTrim( Z1606PedSts));
         GxWebStd.gx_hidden_field( context, "Z1603PedRedondeo", StringUtil.LTrim( StringUtil.NToC( Z1603PedRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z211PedVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211PedVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1613PedUsuC", StringUtil.RTrim( Z1613PedUsuC));
         GxWebStd.gx_hidden_field( context, "Z1596PedFecC", context.localUtil.TToC( Z1596PedFecC, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1614PedUsuM", StringUtil.RTrim( Z1614PedUsuM));
         GxWebStd.gx_hidden_field( context, "Z1597PedFecM", context.localUtil.TToC( Z1597PedFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1611PedUsuA", StringUtil.RTrim( Z1611PedUsuA));
         GxWebStd.gx_hidden_field( context, "Z1593PedFecA", context.localUtil.TToC( Z1593PedFecA, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1612PedUsuA2", StringUtil.RTrim( Z1612PedUsuA2));
         GxWebStd.gx_hidden_field( context, "Z1594PedFecA2", context.localUtil.TToC( Z1594PedFecA2, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1600PedIngreso", StringUtil.RTrim( Z1600PedIngreso));
         GxWebStd.gx_hidden_field( context, "Z1599PedingObs", Z1599PedingObs);
         GxWebStd.gx_hidden_field( context, "Z1545PedCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1545PedCliDespacho), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1546PedCliDespacho2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1546PedCliDespacho2), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1595PedFecAten", context.localUtil.TToC( Z1595PedFecAten, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1549PedCotiza", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1549PedCotiza), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z212TPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212TPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1543PedAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1543PedAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1608PedTipCod", StringUtil.RTrim( Z1608PedTipCod));
         GxWebStd.gx_hidden_field( context, "Z1598PedICBPER", StringUtil.LTrim( StringUtil.NToC( Z1598PedICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1582PedSubIna", StringUtil.LTrim( StringUtil.NToC( Z1582PedSubIna, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1583PedSubAfe", StringUtil.LTrim( StringUtil.NToC( Z1583PedSubAfe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1589PedSubExonerado", StringUtil.LTrim( StringUtil.NToC( Z1589PedSubExonerado, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1607PedSubGratuito", StringUtil.LTrim( StringUtil.NToC( Z1607PedSubGratuito, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1584PedSubSelectivo", StringUtil.LTrim( StringUtil.NToC( Z1584PedSubSelectivo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1581PedSubT", StringUtil.LTrim( StringUtil.NToC( Z1581PedSubT, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1580PedDsct", StringUtil.LTrim( StringUtil.NToC( Z1580PedDsct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1601PedIVA", StringUtil.LTrim( StringUtil.NToC( Z1601PedIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1610PedTotal", StringUtil.LTrim( StringUtil.NToC( Z1610PedTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1548PedConpDsc", StringUtil.RTrim( Z1548PedConpDsc));
         GxWebStd.gx_hidden_field( context, "Z1547PedConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1547PedConpDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1615PedVendDsc", StringUtil.RTrim( Z1615PedVendDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clicod( )
      {
         /* Using cursor T002S37 */
         pr_default.execute(31, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
         }
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Moncod( )
      {
         /* Using cursor T002S38 */
         pr_default.execute(32, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
         }
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pedconp( )
      {
         /* Using cursor T002S31 */
         pr_default.execute(25, new Object[] {A214PedConp});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Pago'.", "ForeignKeyNotFound", 1, "PEDCONP");
            AnyError = 1;
            GX_FocusControl = edtPedConp_Internalname;
         }
         A1548PedConpDsc = T002S31_A1548PedConpDsc[0];
         A1547PedConpDias = T002S31_A1547PedConpDias[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1548PedConpDsc", StringUtil.RTrim( A1548PedConpDsc));
         AssignAttri("", false, "A1547PedConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1547PedConpDias), 4, 0, ".", "")));
      }

      public void Valid_Pedlisp( )
      {
         n213PedLisp = false;
         /* Using cursor T002S39 */
         pr_default.execute(33, new Object[] {n213PedLisp, A213PedLisp});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( (0==A213PedLisp) ) )
            {
               GX_msglist.addItem("No existe 'Sub Lista Precios Pedido'.", "ForeignKeyNotFound", 1, "PEDLISP");
               AnyError = 1;
               GX_FocusControl = edtPedLisp_Internalname;
            }
         }
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pedvendcod( )
      {
         /* Using cursor T002S32 */
         pr_default.execute(26, new Object[] {A211PedVendCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "PEDVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtPedVendCod_Internalname;
         }
         A1615PedVendDsc = T002S32_A1615PedVendDsc[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1615PedVendDsc", StringUtil.RTrim( A1615PedVendDsc));
      }

      public void Valid_Tpedcod( )
      {
         /* Using cursor T002S40 */
         pr_default.execute(34, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Pedidos'.", "ForeignKeyNotFound", 1, "TPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtTPedCod_Internalname;
         }
         pr_default.close(34);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'A1543PedAIVA',fld:'PEDAIVA',pic:'9'},{av:'A1608PedTipCod',fld:'PEDTIPCOD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PEDCOD","{handler:'Valid_Pedcod',iparms:[{av:'A1608PedTipCod',fld:'PEDTIPCOD',pic:''},{av:'A1543PedAIVA',fld:'PEDAIVA',pic:'9'},{av:'A210PedCod',fld:'PEDCOD',pic:''},{av:'A1582PedSubIna',fld:'PEDSUBINA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1583PedSubAfe',fld:'PEDSUBAFE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1584PedSubSelectivo',fld:'PEDSUBSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1589PedSubExonerado',fld:'PEDSUBEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PEDCOD",",oparms:[{av:'A215PedFec',fld:'PEDFEC',pic:''},{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A214PedConp',fld:'PEDCONP',pic:'ZZZZZ9'},{av:'A213PedLisp',fld:'PEDLISP',pic:'ZZZZZ9'},{av:'A1605PedRef',fld:'PEDREF',pic:''},{av:'A1590PedPorDsct',fld:'PEDPORDSCT',pic:'ZZ9.99'},{av:'A1602PedPorIVA',fld:'PEDPORIVA',pic:'ZZ9.99'},{av:'A1604PedObs',fld:'PEDOBS',pic:''},{av:'A1609PedTItem',fld:'PEDTITEM',pic:'ZZZ9'},{av:'A1606PedSts',fld:'PEDSTS',pic:''},{av:'A1603PedRedondeo',fld:'PEDREDONDEO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A211PedVendCod',fld:'PEDVENDCOD',pic:'ZZZZZ9'},{av:'A1613PedUsuC',fld:'PEDUSUC',pic:''},{av:'A1596PedFecC',fld:'PEDFECC',pic:'99/99/99 99:99'},{av:'A1614PedUsuM',fld:'PEDUSUM',pic:''},{av:'A1597PedFecM',fld:'PEDFECM',pic:'99/99/99 99:99'},{av:'A1611PedUsuA',fld:'PEDUSUA',pic:''},{av:'A1593PedFecA',fld:'PEDFECA',pic:'99/99/99 99:99'},{av:'A1612PedUsuA2',fld:'PEDUSUA2',pic:''},{av:'A1594PedFecA2',fld:'PEDFECA2',pic:'99/99/99 99:99'},{av:'A1600PedIngreso',fld:'PEDINGRESO',pic:''},{av:'A1599PedingObs',fld:'PEDINGOBS',pic:''},{av:'A1545PedCliDespacho',fld:'PEDCLIDESPACHO',pic:'ZZZZZ9'},{av:'A1546PedCliDespacho2',fld:'PEDCLIDESPACHO2',pic:'ZZZZZ9'},{av:'A1595PedFecAten',fld:'PEDFECATEN',pic:'99/99/99 99:99'},{av:'A1549PedCotiza',fld:'PEDCOTIZA',pic:'9'},{av:'A212TPedCod',fld:'TPEDCOD',pic:'ZZZZZ9'},{av:'A178TieCod',fld:'TIECOD',pic:'ZZZZZ9'},{av:'A1543PedAIVA',fld:'PEDAIVA',pic:'9'},{av:'A1608PedTipCod',fld:'PEDTIPCOD',pic:''},{av:'A1598PedICBPER',fld:'PEDICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1582PedSubIna',fld:'PEDSUBINA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1583PedSubAfe',fld:'PEDSUBAFE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1589PedSubExonerado',fld:'PEDSUBEXONERADO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1607PedSubGratuito',fld:'PEDSUBGRATUITO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1584PedSubSelectivo',fld:'PEDSUBSELECTIVO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1581PedSubT',fld:'PEDSUBT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1580PedDsct',fld:'PEDDSCT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1601PedIVA',fld:'PEDIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1610PedTotal',fld:'PEDTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1548PedConpDsc',fld:'PEDCONPDSC',pic:''},{av:'A1547PedConpDias',fld:'PEDCONPDIAS',pic:'ZZZ9'},{av:'A1615PedVendDsc',fld:'PEDVENDDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z210PedCod'},{av:'Z215PedFec'},{av:'Z45CliCod'},{av:'Z180MonCod'},{av:'Z214PedConp'},{av:'Z213PedLisp'},{av:'Z1605PedRef'},{av:'Z1590PedPorDsct'},{av:'Z1602PedPorIVA'},{av:'Z1604PedObs'},{av:'Z1609PedTItem'},{av:'Z1606PedSts'},{av:'Z1603PedRedondeo'},{av:'Z211PedVendCod'},{av:'Z1613PedUsuC'},{av:'Z1596PedFecC'},{av:'Z1614PedUsuM'},{av:'Z1597PedFecM'},{av:'Z1611PedUsuA'},{av:'Z1593PedFecA'},{av:'Z1612PedUsuA2'},{av:'Z1594PedFecA2'},{av:'Z1600PedIngreso'},{av:'Z1599PedingObs'},{av:'Z1545PedCliDespacho'},{av:'Z1546PedCliDespacho2'},{av:'Z1595PedFecAten'},{av:'Z1549PedCotiza'},{av:'Z212TPedCod'},{av:'Z178TieCod'},{av:'Z1543PedAIVA'},{av:'Z1608PedTipCod'},{av:'Z1598PedICBPER'},{av:'Z1582PedSubIna'},{av:'Z1583PedSubAfe'},{av:'Z1589PedSubExonerado'},{av:'Z1607PedSubGratuito'},{av:'Z1584PedSubSelectivo'},{av:'Z1581PedSubT'},{av:'Z1580PedDsct'},{av:'Z1601PedIVA'},{av:'Z1610PedTotal'},{av:'Z1548PedConpDsc'},{av:'Z1547PedConpDias'},{av:'Z1615PedVendDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PEDFEC","{handler:'Valid_Pedfec',iparms:[]");
         setEventMetadata("VALID_PEDFEC",",oparms:[]}");
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[]}");
         setEventMetadata("VALID_PEDCONP","{handler:'Valid_Pedconp',iparms:[{av:'A214PedConp',fld:'PEDCONP',pic:'ZZZZZ9'},{av:'A1548PedConpDsc',fld:'PEDCONPDSC',pic:''},{av:'A1547PedConpDias',fld:'PEDCONPDIAS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PEDCONP",",oparms:[{av:'A1548PedConpDsc',fld:'PEDCONPDSC',pic:''},{av:'A1547PedConpDias',fld:'PEDCONPDIAS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PEDLISP","{handler:'Valid_Pedlisp',iparms:[{av:'A213PedLisp',fld:'PEDLISP',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PEDLISP",",oparms:[]}");
         setEventMetadata("VALID_PEDPORDSCT","{handler:'Valid_Pedpordsct',iparms:[]");
         setEventMetadata("VALID_PEDPORDSCT",",oparms:[]}");
         setEventMetadata("VALID_PEDPORIVA","{handler:'Valid_Pedporiva',iparms:[]");
         setEventMetadata("VALID_PEDPORIVA",",oparms:[]}");
         setEventMetadata("VALID_PEDREDONDEO","{handler:'Valid_Pedredondeo',iparms:[]");
         setEventMetadata("VALID_PEDREDONDEO",",oparms:[]}");
         setEventMetadata("VALID_PEDVENDCOD","{handler:'Valid_Pedvendcod',iparms:[{av:'A211PedVendCod',fld:'PEDVENDCOD',pic:'ZZZZZ9'},{av:'A1615PedVendDsc',fld:'PEDVENDDSC',pic:''}]");
         setEventMetadata("VALID_PEDVENDCOD",",oparms:[{av:'A1615PedVendDsc',fld:'PEDVENDDSC',pic:''}]}");
         setEventMetadata("VALID_PEDFECC","{handler:'Valid_Pedfecc',iparms:[]");
         setEventMetadata("VALID_PEDFECC",",oparms:[]}");
         setEventMetadata("VALID_PEDDSCT","{handler:'Valid_Peddsct',iparms:[]");
         setEventMetadata("VALID_PEDDSCT",",oparms:[]}");
         setEventMetadata("VALID_PEDFECM","{handler:'Valid_Pedfecm',iparms:[]");
         setEventMetadata("VALID_PEDFECM",",oparms:[]}");
         setEventMetadata("VALID_PEDFECA","{handler:'Valid_Pedfeca',iparms:[]");
         setEventMetadata("VALID_PEDFECA",",oparms:[]}");
         setEventMetadata("VALID_PEDFECA2","{handler:'Valid_Pedfeca2',iparms:[]");
         setEventMetadata("VALID_PEDFECA2",",oparms:[]}");
         setEventMetadata("VALID_PEDFECATEN","{handler:'Valid_Pedfecaten',iparms:[]");
         setEventMetadata("VALID_PEDFECATEN",",oparms:[]}");
         setEventMetadata("VALID_TPEDCOD","{handler:'Valid_Tpedcod',iparms:[{av:'A212TPedCod',fld:'TPEDCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TPEDCOD",",oparms:[]}");
         setEventMetadata("VALID_PEDSUBT","{handler:'Valid_Pedsubt',iparms:[]");
         setEventMetadata("VALID_PEDSUBT",",oparms:[]}");
         setEventMetadata("VALID_PEDIVA","{handler:'Valid_Pediva',iparms:[]");
         setEventMetadata("VALID_PEDIVA",",oparms:[]}");
         setEventMetadata("VALID_PEDSUBINA","{handler:'Valid_Pedsubina',iparms:[]");
         setEventMetadata("VALID_PEDSUBINA",",oparms:[]}");
         setEventMetadata("VALID_PEDSUBAFE","{handler:'Valid_Pedsubafe',iparms:[]");
         setEventMetadata("VALID_PEDSUBAFE",",oparms:[]}");
         setEventMetadata("VALID_PEDSUBSELECTIVO","{handler:'Valid_Pedsubselectivo',iparms:[]");
         setEventMetadata("VALID_PEDSUBSELECTIVO",",oparms:[]}");
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
         pr_default.close(31);
         pr_default.close(32);
         pr_default.close(34);
         pr_default.close(25);
         pr_default.close(33);
         pr_default.close(26);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z210PedCod = "";
         Z215PedFec = DateTime.MinValue;
         Z1605PedRef = "";
         Z1606PedSts = "";
         Z1613PedUsuC = "";
         Z1596PedFecC = (DateTime)(DateTime.MinValue);
         Z1614PedUsuM = "";
         Z1597PedFecM = (DateTime)(DateTime.MinValue);
         Z1611PedUsuA = "";
         Z1593PedFecA = (DateTime)(DateTime.MinValue);
         Z1612PedUsuA2 = "";
         Z1594PedFecA2 = (DateTime)(DateTime.MinValue);
         Z1600PedIngreso = "";
         Z1595PedFecAten = (DateTime)(DateTime.MinValue);
         Z1608PedTipCod = "";
         Z45CliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A210PedCod = "";
         A45CliCod = "";
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
         A215PedFec = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1605PedRef = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1604PedObs = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A1606PedSts = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1613PedUsuC = "";
         lblTextblock16_Jsonclick = "";
         A1596PedFecC = (DateTime)(DateTime.MinValue);
         lblTextblock17_Jsonclick = "";
         A1614PedUsuM = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         A1597PedFecM = (DateTime)(DateTime.MinValue);
         lblTextblock20_Jsonclick = "";
         A1611PedUsuA = "";
         lblTextblock21_Jsonclick = "";
         A1593PedFecA = (DateTime)(DateTime.MinValue);
         lblTextblock22_Jsonclick = "";
         A1612PedUsuA2 = "";
         lblTextblock23_Jsonclick = "";
         A1594PedFecA2 = (DateTime)(DateTime.MinValue);
         lblTextblock24_Jsonclick = "";
         A1600PedIngreso = "";
         lblTextblock25_Jsonclick = "";
         A1599PedingObs = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         A1595PedFecAten = (DateTime)(DateTime.MinValue);
         lblTextblock29_Jsonclick = "";
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         lblTextblock32_Jsonclick = "";
         lblTextblock33_Jsonclick = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
         A1548PedConpDsc = "";
         lblTextblock37_Jsonclick = "";
         A1615PedVendDsc = "";
         lblTextblock38_Jsonclick = "";
         lblTextblock39_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1608PedTipCod = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1604PedObs = "";
         Z1599PedingObs = "";
         Z1548PedConpDsc = "";
         Z1615PedVendDsc = "";
         T002S7_A178TieCod = new int[1] ;
         T002S14_A210PedCod = new string[] {""} ;
         T002S14_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         T002S14_A1605PedRef = new string[] {""} ;
         T002S14_A1590PedPorDsct = new decimal[1] ;
         T002S14_A1602PedPorIVA = new decimal[1] ;
         T002S14_A1604PedObs = new string[] {""} ;
         T002S14_A1609PedTItem = new short[1] ;
         T002S14_A1606PedSts = new string[] {""} ;
         T002S14_A1603PedRedondeo = new decimal[1] ;
         T002S14_A1613PedUsuC = new string[] {""} ;
         T002S14_A1596PedFecC = new DateTime[] {DateTime.MinValue} ;
         T002S14_A1614PedUsuM = new string[] {""} ;
         T002S14_A1597PedFecM = new DateTime[] {DateTime.MinValue} ;
         T002S14_A1611PedUsuA = new string[] {""} ;
         T002S14_A1593PedFecA = new DateTime[] {DateTime.MinValue} ;
         T002S14_A1612PedUsuA2 = new string[] {""} ;
         T002S14_A1594PedFecA2 = new DateTime[] {DateTime.MinValue} ;
         T002S14_A1600PedIngreso = new string[] {""} ;
         T002S14_A1599PedingObs = new string[] {""} ;
         T002S14_A1545PedCliDespacho = new int[1] ;
         T002S14_A1546PedCliDespacho2 = new int[1] ;
         T002S14_A1595PedFecAten = new DateTime[] {DateTime.MinValue} ;
         T002S14_n1595PedFecAten = new bool[] {false} ;
         T002S14_A1549PedCotiza = new short[1] ;
         T002S14_A1548PedConpDsc = new string[] {""} ;
         T002S14_A1615PedVendDsc = new string[] {""} ;
         T002S14_A1547PedConpDias = new short[1] ;
         T002S14_A1543PedAIVA = new short[1] ;
         T002S14_A1608PedTipCod = new string[] {""} ;
         T002S14_A45CliCod = new string[] {""} ;
         T002S14_A180MonCod = new int[1] ;
         T002S14_A212TPedCod = new int[1] ;
         T002S14_A178TieCod = new int[1] ;
         T002S14_A214PedConp = new int[1] ;
         T002S14_A213PedLisp = new int[1] ;
         T002S14_n213PedLisp = new bool[] {false} ;
         T002S14_A211PedVendCod = new int[1] ;
         T002S14_A1598PedICBPER = new decimal[1] ;
         T002S14_A1582PedSubIna = new decimal[1] ;
         T002S14_A1583PedSubAfe = new decimal[1] ;
         T002S14_A1589PedSubExonerado = new decimal[1] ;
         T002S14_A1607PedSubGratuito = new decimal[1] ;
         T002S14_A1584PedSubSelectivo = new decimal[1] ;
         T002S12_A1598PedICBPER = new decimal[1] ;
         T002S12_A1582PedSubIna = new decimal[1] ;
         T002S12_A1583PedSubAfe = new decimal[1] ;
         T002S12_A1589PedSubExonerado = new decimal[1] ;
         T002S12_A1607PedSubGratuito = new decimal[1] ;
         T002S12_A1584PedSubSelectivo = new decimal[1] ;
         T002S4_A45CliCod = new string[] {""} ;
         T002S5_A180MonCod = new int[1] ;
         T002S8_A1548PedConpDsc = new string[] {""} ;
         T002S8_A1547PedConpDias = new short[1] ;
         T002S9_A213PedLisp = new int[1] ;
         T002S9_n213PedLisp = new bool[] {false} ;
         T002S10_A1615PedVendDsc = new string[] {""} ;
         T002S6_A212TPedCod = new int[1] ;
         T002S16_A1598PedICBPER = new decimal[1] ;
         T002S16_A1582PedSubIna = new decimal[1] ;
         T002S16_A1583PedSubAfe = new decimal[1] ;
         T002S16_A1589PedSubExonerado = new decimal[1] ;
         T002S16_A1607PedSubGratuito = new decimal[1] ;
         T002S16_A1584PedSubSelectivo = new decimal[1] ;
         T002S17_A45CliCod = new string[] {""} ;
         T002S18_A180MonCod = new int[1] ;
         T002S19_A1548PedConpDsc = new string[] {""} ;
         T002S19_A1547PedConpDias = new short[1] ;
         T002S20_A213PedLisp = new int[1] ;
         T002S20_n213PedLisp = new bool[] {false} ;
         T002S21_A1615PedVendDsc = new string[] {""} ;
         T002S22_A212TPedCod = new int[1] ;
         T002S23_A210PedCod = new string[] {""} ;
         T002S3_A210PedCod = new string[] {""} ;
         T002S3_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         T002S3_A1605PedRef = new string[] {""} ;
         T002S3_A1590PedPorDsct = new decimal[1] ;
         T002S3_A1602PedPorIVA = new decimal[1] ;
         T002S3_A1604PedObs = new string[] {""} ;
         T002S3_A1609PedTItem = new short[1] ;
         T002S3_A1606PedSts = new string[] {""} ;
         T002S3_A1603PedRedondeo = new decimal[1] ;
         T002S3_A1613PedUsuC = new string[] {""} ;
         T002S3_A1596PedFecC = new DateTime[] {DateTime.MinValue} ;
         T002S3_A1614PedUsuM = new string[] {""} ;
         T002S3_A1597PedFecM = new DateTime[] {DateTime.MinValue} ;
         T002S3_A1611PedUsuA = new string[] {""} ;
         T002S3_A1593PedFecA = new DateTime[] {DateTime.MinValue} ;
         T002S3_A1612PedUsuA2 = new string[] {""} ;
         T002S3_A1594PedFecA2 = new DateTime[] {DateTime.MinValue} ;
         T002S3_A1600PedIngreso = new string[] {""} ;
         T002S3_A1599PedingObs = new string[] {""} ;
         T002S3_A1545PedCliDespacho = new int[1] ;
         T002S3_A1546PedCliDespacho2 = new int[1] ;
         T002S3_A1595PedFecAten = new DateTime[] {DateTime.MinValue} ;
         T002S3_n1595PedFecAten = new bool[] {false} ;
         T002S3_A1549PedCotiza = new short[1] ;
         T002S3_A1543PedAIVA = new short[1] ;
         T002S3_A1608PedTipCod = new string[] {""} ;
         T002S3_A45CliCod = new string[] {""} ;
         T002S3_A180MonCod = new int[1] ;
         T002S3_A212TPedCod = new int[1] ;
         T002S3_A178TieCod = new int[1] ;
         T002S3_A214PedConp = new int[1] ;
         T002S3_A213PedLisp = new int[1] ;
         T002S3_n213PedLisp = new bool[] {false} ;
         T002S3_A211PedVendCod = new int[1] ;
         sMode95 = "";
         T002S24_A210PedCod = new string[] {""} ;
         T002S25_A210PedCod = new string[] {""} ;
         T002S2_A210PedCod = new string[] {""} ;
         T002S2_A215PedFec = new DateTime[] {DateTime.MinValue} ;
         T002S2_A1605PedRef = new string[] {""} ;
         T002S2_A1590PedPorDsct = new decimal[1] ;
         T002S2_A1602PedPorIVA = new decimal[1] ;
         T002S2_A1604PedObs = new string[] {""} ;
         T002S2_A1609PedTItem = new short[1] ;
         T002S2_A1606PedSts = new string[] {""} ;
         T002S2_A1603PedRedondeo = new decimal[1] ;
         T002S2_A1613PedUsuC = new string[] {""} ;
         T002S2_A1596PedFecC = new DateTime[] {DateTime.MinValue} ;
         T002S2_A1614PedUsuM = new string[] {""} ;
         T002S2_A1597PedFecM = new DateTime[] {DateTime.MinValue} ;
         T002S2_A1611PedUsuA = new string[] {""} ;
         T002S2_A1593PedFecA = new DateTime[] {DateTime.MinValue} ;
         T002S2_A1612PedUsuA2 = new string[] {""} ;
         T002S2_A1594PedFecA2 = new DateTime[] {DateTime.MinValue} ;
         T002S2_A1600PedIngreso = new string[] {""} ;
         T002S2_A1599PedingObs = new string[] {""} ;
         T002S2_A1545PedCliDespacho = new int[1] ;
         T002S2_A1546PedCliDespacho2 = new int[1] ;
         T002S2_A1595PedFecAten = new DateTime[] {DateTime.MinValue} ;
         T002S2_n1595PedFecAten = new bool[] {false} ;
         T002S2_A1549PedCotiza = new short[1] ;
         T002S2_A1543PedAIVA = new short[1] ;
         T002S2_A1608PedTipCod = new string[] {""} ;
         T002S2_A45CliCod = new string[] {""} ;
         T002S2_A180MonCod = new int[1] ;
         T002S2_A212TPedCod = new int[1] ;
         T002S2_A178TieCod = new int[1] ;
         T002S2_A214PedConp = new int[1] ;
         T002S2_A213PedLisp = new int[1] ;
         T002S2_n213PedLisp = new bool[] {false} ;
         T002S2_A211PedVendCod = new int[1] ;
         T002S30_A1598PedICBPER = new decimal[1] ;
         T002S30_A1582PedSubIna = new decimal[1] ;
         T002S30_A1583PedSubAfe = new decimal[1] ;
         T002S30_A1589PedSubExonerado = new decimal[1] ;
         T002S30_A1607PedSubGratuito = new decimal[1] ;
         T002S30_A1584PedSubSelectivo = new decimal[1] ;
         T002S31_A1548PedConpDsc = new string[] {""} ;
         T002S31_A1547PedConpDias = new short[1] ;
         T002S32_A1615PedVendDsc = new string[] {""} ;
         T002S33_A210PedCod = new string[] {""} ;
         T002S33_A28ProdCod = new string[] {""} ;
         T002S33_A217PedDLRef1 = new string[] {""} ;
         T002S34_A210PedCod = new string[] {""} ;
         T002S34_A216PedDItem = new short[1] ;
         T002S35_A13MvATip = new string[] {""} ;
         T002S35_A14MvACod = new string[] {""} ;
         T002S36_A210PedCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ210PedCod = "";
         ZZ215PedFec = DateTime.MinValue;
         ZZ45CliCod = "";
         ZZ1605PedRef = "";
         ZZ1604PedObs = "";
         ZZ1606PedSts = "";
         ZZ1613PedUsuC = "";
         ZZ1596PedFecC = (DateTime)(DateTime.MinValue);
         ZZ1614PedUsuM = "";
         ZZ1597PedFecM = (DateTime)(DateTime.MinValue);
         ZZ1611PedUsuA = "";
         ZZ1593PedFecA = (DateTime)(DateTime.MinValue);
         ZZ1612PedUsuA2 = "";
         ZZ1594PedFecA2 = (DateTime)(DateTime.MinValue);
         ZZ1600PedIngreso = "";
         ZZ1599PedingObs = "";
         ZZ1595PedFecAten = (DateTime)(DateTime.MinValue);
         ZZ1608PedTipCod = "";
         ZZ1548PedConpDsc = "";
         ZZ1615PedVendDsc = "";
         T002S37_A45CliCod = new string[] {""} ;
         T002S38_A180MonCod = new int[1] ;
         T002S39_A213PedLisp = new int[1] ;
         T002S39_n213PedLisp = new bool[] {false} ;
         T002S40_A212TPedCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clpedidos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpedidos__default(),
            new Object[][] {
                new Object[] {
               T002S2_A210PedCod, T002S2_A215PedFec, T002S2_A1605PedRef, T002S2_A1590PedPorDsct, T002S2_A1602PedPorIVA, T002S2_A1604PedObs, T002S2_A1609PedTItem, T002S2_A1606PedSts, T002S2_A1603PedRedondeo, T002S2_A1613PedUsuC,
               T002S2_A1596PedFecC, T002S2_A1614PedUsuM, T002S2_A1597PedFecM, T002S2_A1611PedUsuA, T002S2_A1593PedFecA, T002S2_A1612PedUsuA2, T002S2_A1594PedFecA2, T002S2_A1600PedIngreso, T002S2_A1599PedingObs, T002S2_A1545PedCliDespacho,
               T002S2_A1546PedCliDespacho2, T002S2_A1595PedFecAten, T002S2_n1595PedFecAten, T002S2_A1549PedCotiza, T002S2_A1543PedAIVA, T002S2_A1608PedTipCod, T002S2_A45CliCod, T002S2_A180MonCod, T002S2_A212TPedCod, T002S2_A178TieCod,
               T002S2_A214PedConp, T002S2_A213PedLisp, T002S2_n213PedLisp, T002S2_A211PedVendCod
               }
               , new Object[] {
               T002S3_A210PedCod, T002S3_A215PedFec, T002S3_A1605PedRef, T002S3_A1590PedPorDsct, T002S3_A1602PedPorIVA, T002S3_A1604PedObs, T002S3_A1609PedTItem, T002S3_A1606PedSts, T002S3_A1603PedRedondeo, T002S3_A1613PedUsuC,
               T002S3_A1596PedFecC, T002S3_A1614PedUsuM, T002S3_A1597PedFecM, T002S3_A1611PedUsuA, T002S3_A1593PedFecA, T002S3_A1612PedUsuA2, T002S3_A1594PedFecA2, T002S3_A1600PedIngreso, T002S3_A1599PedingObs, T002S3_A1545PedCliDespacho,
               T002S3_A1546PedCliDespacho2, T002S3_A1595PedFecAten, T002S3_n1595PedFecAten, T002S3_A1549PedCotiza, T002S3_A1543PedAIVA, T002S3_A1608PedTipCod, T002S3_A45CliCod, T002S3_A180MonCod, T002S3_A212TPedCod, T002S3_A178TieCod,
               T002S3_A214PedConp, T002S3_A213PedLisp, T002S3_n213PedLisp, T002S3_A211PedVendCod
               }
               , new Object[] {
               T002S4_A45CliCod
               }
               , new Object[] {
               T002S5_A180MonCod
               }
               , new Object[] {
               T002S6_A212TPedCod
               }
               , new Object[] {
               T002S7_A178TieCod
               }
               , new Object[] {
               T002S8_A1548PedConpDsc, T002S8_A1547PedConpDias
               }
               , new Object[] {
               T002S9_A213PedLisp
               }
               , new Object[] {
               T002S10_A1615PedVendDsc
               }
               , new Object[] {
               T002S12_A1598PedICBPER, T002S12_A1582PedSubIna, T002S12_A1583PedSubAfe, T002S12_A1589PedSubExonerado, T002S12_A1607PedSubGratuito, T002S12_A1584PedSubSelectivo
               }
               , new Object[] {
               T002S14_A210PedCod, T002S14_A215PedFec, T002S14_A1605PedRef, T002S14_A1590PedPorDsct, T002S14_A1602PedPorIVA, T002S14_A1604PedObs, T002S14_A1609PedTItem, T002S14_A1606PedSts, T002S14_A1603PedRedondeo, T002S14_A1613PedUsuC,
               T002S14_A1596PedFecC, T002S14_A1614PedUsuM, T002S14_A1597PedFecM, T002S14_A1611PedUsuA, T002S14_A1593PedFecA, T002S14_A1612PedUsuA2, T002S14_A1594PedFecA2, T002S14_A1600PedIngreso, T002S14_A1599PedingObs, T002S14_A1545PedCliDespacho,
               T002S14_A1546PedCliDespacho2, T002S14_A1595PedFecAten, T002S14_n1595PedFecAten, T002S14_A1549PedCotiza, T002S14_A1548PedConpDsc, T002S14_A1615PedVendDsc, T002S14_A1547PedConpDias, T002S14_A1543PedAIVA, T002S14_A1608PedTipCod, T002S14_A45CliCod,
               T002S14_A180MonCod, T002S14_A212TPedCod, T002S14_A178TieCod, T002S14_A214PedConp, T002S14_A213PedLisp, T002S14_n213PedLisp, T002S14_A211PedVendCod, T002S14_A1598PedICBPER, T002S14_A1582PedSubIna, T002S14_A1583PedSubAfe,
               T002S14_A1589PedSubExonerado, T002S14_A1607PedSubGratuito, T002S14_A1584PedSubSelectivo
               }
               , new Object[] {
               T002S16_A1598PedICBPER, T002S16_A1582PedSubIna, T002S16_A1583PedSubAfe, T002S16_A1589PedSubExonerado, T002S16_A1607PedSubGratuito, T002S16_A1584PedSubSelectivo
               }
               , new Object[] {
               T002S17_A45CliCod
               }
               , new Object[] {
               T002S18_A180MonCod
               }
               , new Object[] {
               T002S19_A1548PedConpDsc, T002S19_A1547PedConpDias
               }
               , new Object[] {
               T002S20_A213PedLisp
               }
               , new Object[] {
               T002S21_A1615PedVendDsc
               }
               , new Object[] {
               T002S22_A212TPedCod
               }
               , new Object[] {
               T002S23_A210PedCod
               }
               , new Object[] {
               T002S24_A210PedCod
               }
               , new Object[] {
               T002S25_A210PedCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002S30_A1598PedICBPER, T002S30_A1582PedSubIna, T002S30_A1583PedSubAfe, T002S30_A1589PedSubExonerado, T002S30_A1607PedSubGratuito, T002S30_A1584PedSubSelectivo
               }
               , new Object[] {
               T002S31_A1548PedConpDsc, T002S31_A1547PedConpDias
               }
               , new Object[] {
               T002S32_A1615PedVendDsc
               }
               , new Object[] {
               T002S33_A210PedCod, T002S33_A28ProdCod, T002S33_A217PedDLRef1
               }
               , new Object[] {
               T002S34_A210PedCod, T002S34_A216PedDItem
               }
               , new Object[] {
               T002S35_A13MvATip, T002S35_A14MvACod
               }
               , new Object[] {
               T002S36_A210PedCod
               }
               , new Object[] {
               T002S37_A45CliCod
               }
               , new Object[] {
               T002S38_A180MonCod
               }
               , new Object[] {
               T002S39_A213PedLisp
               }
               , new Object[] {
               T002S40_A212TPedCod
               }
            }
         );
      }

      private short Z1609PedTItem ;
      private short Z1549PedCotiza ;
      private short Z1543PedAIVA ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1609PedTItem ;
      private short A1549PedCotiza ;
      private short A1547PedConpDias ;
      private short A1543PedAIVA ;
      private short GX_JID ;
      private short Z1547PedConpDias ;
      private short RcdFound95 ;
      private short nIsDirty_95 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1609PedTItem ;
      private short ZZ1549PedCotiza ;
      private short ZZ1543PedAIVA ;
      private short ZZ1547PedConpDias ;
      private int Z1545PedCliDespacho ;
      private int Z1546PedCliDespacho2 ;
      private int Z180MonCod ;
      private int Z212TPedCod ;
      private int Z178TieCod ;
      private int Z214PedConp ;
      private int Z213PedLisp ;
      private int Z211PedVendCod ;
      private int A180MonCod ;
      private int A214PedConp ;
      private int A213PedLisp ;
      private int A211PedVendCod ;
      private int A212TPedCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPedCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPedFec_Enabled ;
      private int edtCliCod_Enabled ;
      private int edtMonCod_Enabled ;
      private int edtPedConp_Enabled ;
      private int edtPedLisp_Enabled ;
      private int edtPedRef_Enabled ;
      private int edtPedPorDsct_Enabled ;
      private int edtPedPorIVA_Enabled ;
      private int edtPedObs_Enabled ;
      private int edtPedTItem_Enabled ;
      private int edtPedSts_Enabled ;
      private int edtPedRedondeo_Enabled ;
      private int edtPedVendCod_Enabled ;
      private int edtPedUsuC_Enabled ;
      private int edtPedFecC_Enabled ;
      private int edtPedUsuM_Enabled ;
      private int edtPedDsct_Enabled ;
      private int edtPedFecM_Enabled ;
      private int edtPedUsuA_Enabled ;
      private int edtPedFecA_Enabled ;
      private int edtPedUsuA2_Enabled ;
      private int edtPedFecA2_Enabled ;
      private int edtPedIngreso_Enabled ;
      private int edtPedingObs_Enabled ;
      private int A1545PedCliDespacho ;
      private int edtPedCliDespacho_Enabled ;
      private int A1546PedCliDespacho2 ;
      private int edtPedCliDespacho2_Enabled ;
      private int edtPedFecAten_Enabled ;
      private int edtPedCotiza_Enabled ;
      private int edtTPedCod_Enabled ;
      private int edtPedSubT_Enabled ;
      private int edtPedIVA_Enabled ;
      private int edtPedTotal_Enabled ;
      private int edtPedSubIna_Enabled ;
      private int edtPedSubAfe_Enabled ;
      private int edtPedConpDsc_Enabled ;
      private int edtPedVendDsc_Enabled ;
      private int edtPedSubSelectivo_Enabled ;
      private int edtPedConpDias_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A178TieCod ;
      private int idxLst ;
      private int ZZ180MonCod ;
      private int ZZ214PedConp ;
      private int ZZ213PedLisp ;
      private int ZZ211PedVendCod ;
      private int ZZ1545PedCliDespacho ;
      private int ZZ1546PedCliDespacho2 ;
      private int ZZ212TPedCod ;
      private int ZZ178TieCod ;
      private decimal Z1590PedPorDsct ;
      private decimal Z1602PedPorIVA ;
      private decimal Z1603PedRedondeo ;
      private decimal A1590PedPorDsct ;
      private decimal A1602PedPorIVA ;
      private decimal A1603PedRedondeo ;
      private decimal A1580PedDsct ;
      private decimal A1581PedSubT ;
      private decimal A1601PedIVA ;
      private decimal A1610PedTotal ;
      private decimal A1582PedSubIna ;
      private decimal A1583PedSubAfe ;
      private decimal A1584PedSubSelectivo ;
      private decimal A1598PedICBPER ;
      private decimal A1589PedSubExonerado ;
      private decimal A1607PedSubGratuito ;
      private decimal Z1598PedICBPER ;
      private decimal Z1582PedSubIna ;
      private decimal Z1583PedSubAfe ;
      private decimal Z1589PedSubExonerado ;
      private decimal Z1607PedSubGratuito ;
      private decimal Z1584PedSubSelectivo ;
      private decimal Z1581PedSubT ;
      private decimal Z1580PedDsct ;
      private decimal Z1601PedIVA ;
      private decimal Z1610PedTotal ;
      private decimal ZZ1590PedPorDsct ;
      private decimal ZZ1602PedPorIVA ;
      private decimal ZZ1603PedRedondeo ;
      private decimal ZZ1598PedICBPER ;
      private decimal ZZ1582PedSubIna ;
      private decimal ZZ1583PedSubAfe ;
      private decimal ZZ1589PedSubExonerado ;
      private decimal ZZ1607PedSubGratuito ;
      private decimal ZZ1584PedSubSelectivo ;
      private decimal ZZ1581PedSubT ;
      private decimal ZZ1580PedDsct ;
      private decimal ZZ1601PedIVA ;
      private decimal ZZ1610PedTotal ;
      private string sPrefix ;
      private string Z210PedCod ;
      private string Z1605PedRef ;
      private string Z1606PedSts ;
      private string Z1613PedUsuC ;
      private string Z1614PedUsuM ;
      private string Z1611PedUsuA ;
      private string Z1612PedUsuA2 ;
      private string Z1600PedIngreso ;
      private string Z1608PedTipCod ;
      private string Z45CliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A210PedCod ;
      private string A45CliCod ;
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
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPedFec_Internalname ;
      private string edtPedFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCliCod_Internalname ;
      private string edtCliCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMonCod_Internalname ;
      private string edtMonCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPedConp_Internalname ;
      private string edtPedConp_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPedLisp_Internalname ;
      private string edtPedLisp_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPedRef_Internalname ;
      private string A1605PedRef ;
      private string edtPedRef_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPedPorDsct_Internalname ;
      private string edtPedPorDsct_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPedPorIVA_Internalname ;
      private string edtPedPorIVA_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPedObs_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtPedTItem_Internalname ;
      private string edtPedTItem_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtPedSts_Internalname ;
      private string A1606PedSts ;
      private string edtPedSts_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtPedRedondeo_Internalname ;
      private string edtPedRedondeo_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtPedVendCod_Internalname ;
      private string edtPedVendCod_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtPedUsuC_Internalname ;
      private string A1613PedUsuC ;
      private string edtPedUsuC_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtPedFecC_Internalname ;
      private string edtPedFecC_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtPedUsuM_Internalname ;
      private string A1614PedUsuM ;
      private string edtPedUsuM_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtPedDsct_Internalname ;
      private string edtPedDsct_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtPedFecM_Internalname ;
      private string edtPedFecM_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtPedUsuA_Internalname ;
      private string A1611PedUsuA ;
      private string edtPedUsuA_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtPedFecA_Internalname ;
      private string edtPedFecA_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtPedUsuA2_Internalname ;
      private string A1612PedUsuA2 ;
      private string edtPedUsuA2_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtPedFecA2_Internalname ;
      private string edtPedFecA2_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtPedIngreso_Internalname ;
      private string A1600PedIngreso ;
      private string edtPedIngreso_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtPedingObs_Internalname ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtPedCliDespacho_Internalname ;
      private string edtPedCliDespacho_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtPedCliDespacho2_Internalname ;
      private string edtPedCliDespacho2_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtPedFecAten_Internalname ;
      private string edtPedFecAten_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtPedCotiza_Internalname ;
      private string edtPedCotiza_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtTPedCod_Internalname ;
      private string edtTPedCod_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtPedSubT_Internalname ;
      private string edtPedSubT_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtPedIVA_Internalname ;
      private string edtPedIVA_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtPedTotal_Internalname ;
      private string edtPedTotal_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtPedSubIna_Internalname ;
      private string edtPedSubIna_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtPedSubAfe_Internalname ;
      private string edtPedSubAfe_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtPedConpDsc_Internalname ;
      private string A1548PedConpDsc ;
      private string edtPedConpDsc_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtPedVendDsc_Internalname ;
      private string A1615PedVendDsc ;
      private string edtPedVendDsc_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtPedSubSelectivo_Internalname ;
      private string edtPedSubSelectivo_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string edtPedConpDias_Internalname ;
      private string edtPedConpDias_Jsonclick ;
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
      private string A1608PedTipCod ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1548PedConpDsc ;
      private string Z1615PedVendDsc ;
      private string sMode95 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ210PedCod ;
      private string ZZ45CliCod ;
      private string ZZ1605PedRef ;
      private string ZZ1606PedSts ;
      private string ZZ1613PedUsuC ;
      private string ZZ1614PedUsuM ;
      private string ZZ1611PedUsuA ;
      private string ZZ1612PedUsuA2 ;
      private string ZZ1600PedIngreso ;
      private string ZZ1608PedTipCod ;
      private string ZZ1548PedConpDsc ;
      private string ZZ1615PedVendDsc ;
      private DateTime Z1596PedFecC ;
      private DateTime Z1597PedFecM ;
      private DateTime Z1593PedFecA ;
      private DateTime Z1594PedFecA2 ;
      private DateTime Z1595PedFecAten ;
      private DateTime A1596PedFecC ;
      private DateTime A1597PedFecM ;
      private DateTime A1593PedFecA ;
      private DateTime A1594PedFecA2 ;
      private DateTime A1595PedFecAten ;
      private DateTime ZZ1596PedFecC ;
      private DateTime ZZ1597PedFecM ;
      private DateTime ZZ1593PedFecA ;
      private DateTime ZZ1594PedFecA2 ;
      private DateTime ZZ1595PedFecAten ;
      private DateTime Z215PedFec ;
      private DateTime A215PedFec ;
      private DateTime ZZ215PedFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n213PedLisp ;
      private bool wbErr ;
      private bool n1595PedFecAten ;
      private bool Gx_longc ;
      private string A1604PedObs ;
      private string A1599PedingObs ;
      private string Z1604PedObs ;
      private string Z1599PedingObs ;
      private string ZZ1604PedObs ;
      private string ZZ1599PedingObs ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002S7_A178TieCod ;
      private string[] T002S14_A210PedCod ;
      private DateTime[] T002S14_A215PedFec ;
      private string[] T002S14_A1605PedRef ;
      private decimal[] T002S14_A1590PedPorDsct ;
      private decimal[] T002S14_A1602PedPorIVA ;
      private string[] T002S14_A1604PedObs ;
      private short[] T002S14_A1609PedTItem ;
      private string[] T002S14_A1606PedSts ;
      private decimal[] T002S14_A1603PedRedondeo ;
      private string[] T002S14_A1613PedUsuC ;
      private DateTime[] T002S14_A1596PedFecC ;
      private string[] T002S14_A1614PedUsuM ;
      private DateTime[] T002S14_A1597PedFecM ;
      private string[] T002S14_A1611PedUsuA ;
      private DateTime[] T002S14_A1593PedFecA ;
      private string[] T002S14_A1612PedUsuA2 ;
      private DateTime[] T002S14_A1594PedFecA2 ;
      private string[] T002S14_A1600PedIngreso ;
      private string[] T002S14_A1599PedingObs ;
      private int[] T002S14_A1545PedCliDespacho ;
      private int[] T002S14_A1546PedCliDespacho2 ;
      private DateTime[] T002S14_A1595PedFecAten ;
      private bool[] T002S14_n1595PedFecAten ;
      private short[] T002S14_A1549PedCotiza ;
      private string[] T002S14_A1548PedConpDsc ;
      private string[] T002S14_A1615PedVendDsc ;
      private short[] T002S14_A1547PedConpDias ;
      private short[] T002S14_A1543PedAIVA ;
      private string[] T002S14_A1608PedTipCod ;
      private string[] T002S14_A45CliCod ;
      private int[] T002S14_A180MonCod ;
      private int[] T002S14_A212TPedCod ;
      private int[] T002S14_A178TieCod ;
      private int[] T002S14_A214PedConp ;
      private int[] T002S14_A213PedLisp ;
      private bool[] T002S14_n213PedLisp ;
      private int[] T002S14_A211PedVendCod ;
      private decimal[] T002S14_A1598PedICBPER ;
      private decimal[] T002S14_A1582PedSubIna ;
      private decimal[] T002S14_A1583PedSubAfe ;
      private decimal[] T002S14_A1589PedSubExonerado ;
      private decimal[] T002S14_A1607PedSubGratuito ;
      private decimal[] T002S14_A1584PedSubSelectivo ;
      private decimal[] T002S12_A1598PedICBPER ;
      private decimal[] T002S12_A1582PedSubIna ;
      private decimal[] T002S12_A1583PedSubAfe ;
      private decimal[] T002S12_A1589PedSubExonerado ;
      private decimal[] T002S12_A1607PedSubGratuito ;
      private decimal[] T002S12_A1584PedSubSelectivo ;
      private string[] T002S4_A45CliCod ;
      private int[] T002S5_A180MonCod ;
      private string[] T002S8_A1548PedConpDsc ;
      private short[] T002S8_A1547PedConpDias ;
      private int[] T002S9_A213PedLisp ;
      private bool[] T002S9_n213PedLisp ;
      private string[] T002S10_A1615PedVendDsc ;
      private int[] T002S6_A212TPedCod ;
      private decimal[] T002S16_A1598PedICBPER ;
      private decimal[] T002S16_A1582PedSubIna ;
      private decimal[] T002S16_A1583PedSubAfe ;
      private decimal[] T002S16_A1589PedSubExonerado ;
      private decimal[] T002S16_A1607PedSubGratuito ;
      private decimal[] T002S16_A1584PedSubSelectivo ;
      private string[] T002S17_A45CliCod ;
      private int[] T002S18_A180MonCod ;
      private string[] T002S19_A1548PedConpDsc ;
      private short[] T002S19_A1547PedConpDias ;
      private int[] T002S20_A213PedLisp ;
      private bool[] T002S20_n213PedLisp ;
      private string[] T002S21_A1615PedVendDsc ;
      private int[] T002S22_A212TPedCod ;
      private string[] T002S23_A210PedCod ;
      private string[] T002S3_A210PedCod ;
      private DateTime[] T002S3_A215PedFec ;
      private string[] T002S3_A1605PedRef ;
      private decimal[] T002S3_A1590PedPorDsct ;
      private decimal[] T002S3_A1602PedPorIVA ;
      private string[] T002S3_A1604PedObs ;
      private short[] T002S3_A1609PedTItem ;
      private string[] T002S3_A1606PedSts ;
      private decimal[] T002S3_A1603PedRedondeo ;
      private string[] T002S3_A1613PedUsuC ;
      private DateTime[] T002S3_A1596PedFecC ;
      private string[] T002S3_A1614PedUsuM ;
      private DateTime[] T002S3_A1597PedFecM ;
      private string[] T002S3_A1611PedUsuA ;
      private DateTime[] T002S3_A1593PedFecA ;
      private string[] T002S3_A1612PedUsuA2 ;
      private DateTime[] T002S3_A1594PedFecA2 ;
      private string[] T002S3_A1600PedIngreso ;
      private string[] T002S3_A1599PedingObs ;
      private int[] T002S3_A1545PedCliDespacho ;
      private int[] T002S3_A1546PedCliDespacho2 ;
      private DateTime[] T002S3_A1595PedFecAten ;
      private bool[] T002S3_n1595PedFecAten ;
      private short[] T002S3_A1549PedCotiza ;
      private short[] T002S3_A1543PedAIVA ;
      private string[] T002S3_A1608PedTipCod ;
      private string[] T002S3_A45CliCod ;
      private int[] T002S3_A180MonCod ;
      private int[] T002S3_A212TPedCod ;
      private int[] T002S3_A178TieCod ;
      private int[] T002S3_A214PedConp ;
      private int[] T002S3_A213PedLisp ;
      private bool[] T002S3_n213PedLisp ;
      private int[] T002S3_A211PedVendCod ;
      private string[] T002S24_A210PedCod ;
      private string[] T002S25_A210PedCod ;
      private string[] T002S2_A210PedCod ;
      private DateTime[] T002S2_A215PedFec ;
      private string[] T002S2_A1605PedRef ;
      private decimal[] T002S2_A1590PedPorDsct ;
      private decimal[] T002S2_A1602PedPorIVA ;
      private string[] T002S2_A1604PedObs ;
      private short[] T002S2_A1609PedTItem ;
      private string[] T002S2_A1606PedSts ;
      private decimal[] T002S2_A1603PedRedondeo ;
      private string[] T002S2_A1613PedUsuC ;
      private DateTime[] T002S2_A1596PedFecC ;
      private string[] T002S2_A1614PedUsuM ;
      private DateTime[] T002S2_A1597PedFecM ;
      private string[] T002S2_A1611PedUsuA ;
      private DateTime[] T002S2_A1593PedFecA ;
      private string[] T002S2_A1612PedUsuA2 ;
      private DateTime[] T002S2_A1594PedFecA2 ;
      private string[] T002S2_A1600PedIngreso ;
      private string[] T002S2_A1599PedingObs ;
      private int[] T002S2_A1545PedCliDespacho ;
      private int[] T002S2_A1546PedCliDespacho2 ;
      private DateTime[] T002S2_A1595PedFecAten ;
      private bool[] T002S2_n1595PedFecAten ;
      private short[] T002S2_A1549PedCotiza ;
      private short[] T002S2_A1543PedAIVA ;
      private string[] T002S2_A1608PedTipCod ;
      private string[] T002S2_A45CliCod ;
      private int[] T002S2_A180MonCod ;
      private int[] T002S2_A212TPedCod ;
      private int[] T002S2_A178TieCod ;
      private int[] T002S2_A214PedConp ;
      private int[] T002S2_A213PedLisp ;
      private bool[] T002S2_n213PedLisp ;
      private int[] T002S2_A211PedVendCod ;
      private decimal[] T002S30_A1598PedICBPER ;
      private decimal[] T002S30_A1582PedSubIna ;
      private decimal[] T002S30_A1583PedSubAfe ;
      private decimal[] T002S30_A1589PedSubExonerado ;
      private decimal[] T002S30_A1607PedSubGratuito ;
      private decimal[] T002S30_A1584PedSubSelectivo ;
      private string[] T002S31_A1548PedConpDsc ;
      private short[] T002S31_A1547PedConpDias ;
      private string[] T002S32_A1615PedVendDsc ;
      private string[] T002S33_A210PedCod ;
      private string[] T002S33_A28ProdCod ;
      private string[] T002S33_A217PedDLRef1 ;
      private string[] T002S34_A210PedCod ;
      private short[] T002S34_A216PedDItem ;
      private string[] T002S35_A13MvATip ;
      private string[] T002S35_A14MvACod ;
      private string[] T002S36_A210PedCod ;
      private string[] T002S37_A45CliCod ;
      private int[] T002S38_A180MonCod ;
      private int[] T002S39_A213PedLisp ;
      private bool[] T002S39_n213PedLisp ;
      private int[] T002S40_A212TPedCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clpedidos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clpedidos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002S7;
        prmT002S7 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0)
        };
        Object[] prmT002S14;
        prmT002S14 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S12;
        prmT002S12 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S4;
        prmT002S4 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002S5;
        prmT002S5 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT002S8;
        prmT002S8 = new Object[] {
        new ParDef("@PedConp",GXType.Int32,6,0)
        };
        Object[] prmT002S9;
        prmT002S9 = new Object[] {
        new ParDef("@PedLisp",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002S10;
        prmT002S10 = new Object[] {
        new ParDef("@PedVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002S6;
        prmT002S6 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT002S16;
        prmT002S16 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S17;
        prmT002S17 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002S18;
        prmT002S18 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT002S19;
        prmT002S19 = new Object[] {
        new ParDef("@PedConp",GXType.Int32,6,0)
        };
        Object[] prmT002S20;
        prmT002S20 = new Object[] {
        new ParDef("@PedLisp",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002S21;
        prmT002S21 = new Object[] {
        new ParDef("@PedVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002S22;
        prmT002S22 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT002S23;
        prmT002S23 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S3;
        prmT002S3 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S24;
        prmT002S24 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S25;
        prmT002S25 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S2;
        prmT002S2 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S26;
        prmT002S26 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0) ,
        new ParDef("@PedFec",GXType.Date,8,0) ,
        new ParDef("@PedRef",GXType.NChar,20,0) ,
        new ParDef("@PedPorDsct",GXType.Decimal,6,2) ,
        new ParDef("@PedPorIVA",GXType.Decimal,6,2) ,
        new ParDef("@PedObs",GXType.NVarChar,500,0) ,
        new ParDef("@PedTItem",GXType.Int16,4,0) ,
        new ParDef("@PedSts",GXType.NChar,1,0) ,
        new ParDef("@PedRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@PedUsuC",GXType.NChar,10,0) ,
        new ParDef("@PedFecC",GXType.DateTime,8,5) ,
        new ParDef("@PedUsuM",GXType.NChar,10,0) ,
        new ParDef("@PedFecM",GXType.DateTime,8,5) ,
        new ParDef("@PedUsuA",GXType.NChar,10,0) ,
        new ParDef("@PedFecA",GXType.DateTime,8,5) ,
        new ParDef("@PedUsuA2",GXType.NChar,10,0) ,
        new ParDef("@PedFecA2",GXType.DateTime,8,5) ,
        new ParDef("@PedIngreso",GXType.NChar,50,0) ,
        new ParDef("@PedingObs",GXType.NVarChar,500,0) ,
        new ParDef("@PedCliDespacho",GXType.Int32,6,0) ,
        new ParDef("@PedCliDespacho2",GXType.Int32,6,0) ,
        new ParDef("@PedFecAten",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@PedCotiza",GXType.Int16,1,0) ,
        new ParDef("@PedAIVA",GXType.Int16,1,0) ,
        new ParDef("@PedTipCod",GXType.NChar,3,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@TPedCod",GXType.Int32,6,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0) ,
        new ParDef("@PedConp",GXType.Int32,6,0) ,
        new ParDef("@PedLisp",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PedVendCod",GXType.Int32,6,0) ,
        new ParDef("@PedICBPER",GXType.Decimal,15,2)
        };
        Object[] prmT002S27;
        prmT002S27 = new Object[] {
        new ParDef("@PedFec",GXType.Date,8,0) ,
        new ParDef("@PedRef",GXType.NChar,20,0) ,
        new ParDef("@PedPorDsct",GXType.Decimal,6,2) ,
        new ParDef("@PedPorIVA",GXType.Decimal,6,2) ,
        new ParDef("@PedObs",GXType.NVarChar,500,0) ,
        new ParDef("@PedTItem",GXType.Int16,4,0) ,
        new ParDef("@PedSts",GXType.NChar,1,0) ,
        new ParDef("@PedRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@PedUsuC",GXType.NChar,10,0) ,
        new ParDef("@PedFecC",GXType.DateTime,8,5) ,
        new ParDef("@PedUsuM",GXType.NChar,10,0) ,
        new ParDef("@PedFecM",GXType.DateTime,8,5) ,
        new ParDef("@PedUsuA",GXType.NChar,10,0) ,
        new ParDef("@PedFecA",GXType.DateTime,8,5) ,
        new ParDef("@PedUsuA2",GXType.NChar,10,0) ,
        new ParDef("@PedFecA2",GXType.DateTime,8,5) ,
        new ParDef("@PedIngreso",GXType.NChar,50,0) ,
        new ParDef("@PedingObs",GXType.NVarChar,500,0) ,
        new ParDef("@PedCliDespacho",GXType.Int32,6,0) ,
        new ParDef("@PedCliDespacho2",GXType.Int32,6,0) ,
        new ParDef("@PedFecAten",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@PedCotiza",GXType.Int16,1,0) ,
        new ParDef("@PedAIVA",GXType.Int16,1,0) ,
        new ParDef("@PedTipCod",GXType.NChar,3,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@TPedCod",GXType.Int32,6,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0) ,
        new ParDef("@PedConp",GXType.Int32,6,0) ,
        new ParDef("@PedLisp",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PedVendCod",GXType.Int32,6,0) ,
        new ParDef("@PedICBPER",GXType.Decimal,15,2) ,
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S28;
        prmT002S28 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S33;
        prmT002S33 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S34;
        prmT002S34 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S35;
        prmT002S35 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S36;
        prmT002S36 = new Object[] {
        };
        Object[] prmT002S30;
        prmT002S30 = new Object[] {
        new ParDef("@PedCod",GXType.NChar,10,0)
        };
        Object[] prmT002S37;
        prmT002S37 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002S38;
        prmT002S38 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT002S31;
        prmT002S31 = new Object[] {
        new ParDef("@PedConp",GXType.Int32,6,0)
        };
        Object[] prmT002S39;
        prmT002S39 = new Object[] {
        new ParDef("@PedLisp",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002S32;
        prmT002S32 = new Object[] {
        new ParDef("@PedVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002S40;
        prmT002S40 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002S2", "SELECT [PedCod], [PedFec], [PedRef], [PedPorDsct], [PedPorIVA], [PedObs], [PedTItem], [PedSts], [PedRedondeo], [PedUsuC], [PedFecC], [PedUsuM], [PedFecM], [PedUsuA], [PedFecA], [PedUsuA2], [PedFecA2], [PedIngreso], [PedingObs], [PedCliDespacho], [PedCliDespacho2], [PedFecAten], [PedCotiza], [PedAIVA], [PedTipCod], [CliCod], [MonCod], [TPedCod], [TieCod], [PedConp] AS PedConp, [PedLisp] AS PedLisp, [PedVendCod] AS PedVendCod FROM [CLPEDIDOS] WITH (UPDLOCK) WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S3", "SELECT [PedCod], [PedFec], [PedRef], [PedPorDsct], [PedPorIVA], [PedObs], [PedTItem], [PedSts], [PedRedondeo], [PedUsuC], [PedFecC], [PedUsuM], [PedFecM], [PedUsuA], [PedFecA], [PedUsuA2], [PedFecA2], [PedIngreso], [PedingObs], [PedCliDespacho], [PedCliDespacho2], [PedFecAten], [PedCotiza], [PedAIVA], [PedTipCod], [CliCod], [MonCod], [TPedCod], [TieCod], [PedConp] AS PedConp, [PedLisp] AS PedLisp, [PedVendCod] AS PedVendCod FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S4", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S5", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S6", "SELECT [TPedCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S7", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S8", "SELECT [ConpDsc] AS PedConpDsc, [ConpDias] AS PedConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PedConp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S9", "SELECT [TipLCod] AS PedLisp FROM [CTIPOSLISTAS] WHERE [TipLCod] = @PedLisp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S10", "SELECT [VenDsc] AS PedVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @PedVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S12", "SELECT COALESCE( T1.[PedICBPER], 0) AS PedICBPER, COALESCE( T1.[PedSubIna], 0) AS PedSubIna, COALESCE( T1.[PedSubAfe], 0) AS PedSubAfe, COALESCE( T1.[PedSubExonerado], 0) AS PedSubExonerado, COALESCE( T1.[PedSubGratuito], 0) AS PedSubGratuito, COALESCE( T1.[PedSubSelectivo], 0) AS PedSubSelectivo FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod], SUM(CASE  WHEN [PedDIna] = 1 or [PedDIna] = 4 THEN [PedDTot] ELSE 0 END) AS PedSubIna, SUM(CASE  WHEN [PedDIna] = 0 THEN [PedDTot] ELSE 0 END) AS PedSubAfe, SUM(CASE  WHEN [PedDIna] = 2 THEN [PedDTot] ELSE 0 END) AS PedSubExonerado, SUM(CASE  WHEN [PedDIna] = 3 THEN [PedDTot] ELSE 0 END) AS PedSubGratuito, SUM(( [PedDValSel] * CAST([PedDCan] AS decimal( 25, 10))) + ( ROUND(CAST(( [PedDTot] * CAST([PedDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2))) AS PedSubSelectivo FROM [CLPEDIDOSDET] GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S14", "SELECT TM1.[PedCod], TM1.[PedFec], TM1.[PedRef], TM1.[PedPorDsct], TM1.[PedPorIVA], TM1.[PedObs], TM1.[PedTItem], TM1.[PedSts], TM1.[PedRedondeo], TM1.[PedUsuC], TM1.[PedFecC], TM1.[PedUsuM], TM1.[PedFecM], TM1.[PedUsuA], TM1.[PedFecA], TM1.[PedUsuA2], TM1.[PedFecA2], TM1.[PedIngreso], TM1.[PedingObs], TM1.[PedCliDespacho], TM1.[PedCliDespacho2], TM1.[PedFecAten], TM1.[PedCotiza], T3.[ConpDsc] AS PedConpDsc, T4.[VenDsc] AS PedVendDsc, T3.[ConpDias] AS PedConpDias, TM1.[PedAIVA], TM1.[PedTipCod], TM1.[CliCod], TM1.[MonCod], TM1.[TPedCod], TM1.[TieCod], TM1.[PedConp] AS PedConp, TM1.[PedLisp] AS PedLisp, TM1.[PedVendCod] AS PedVendCod, COALESCE( T2.[PedICBPER], 0) AS PedICBPER, COALESCE( T2.[PedSubIna], 0) AS PedSubIna, COALESCE( T2.[PedSubAfe], 0) AS PedSubAfe, COALESCE( T2.[PedSubExonerado], 0) AS PedSubExonerado, COALESCE( T2.[PedSubGratuito], 0) AS PedSubGratuito, COALESCE( T2.[PedSubSelectivo], 0) AS PedSubSelectivo FROM ((([CLPEDIDOS] TM1 LEFT JOIN (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod], SUM(CASE  WHEN [PedDIna] = 1 or [PedDIna] = 4 THEN [PedDTot] ELSE 0 END) AS PedSubIna, SUM(CASE  WHEN [PedDIna] = 0 THEN [PedDTot] ELSE 0 END) AS PedSubAfe, SUM(CASE  WHEN [PedDIna] = 2 THEN [PedDTot] ELSE 0 END) AS PedSubExonerado, SUM(CASE  WHEN [PedDIna] = 3 THEN [PedDTot] ELSE 0 END) AS PedSubGratuito, SUM(( [PedDValSel] * CAST([PedDCan] AS decimal( 25, 10))) + ( ROUND(CAST(( [PedDTot] * CAST([PedDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2))) AS PedSubSelectivo FROM [CLPEDIDOSDET] GROUP BY [PedCod] ) T2 ON T2.[PedCod] = TM1.[PedCod]) INNER JOIN [CCONDICIONPAGO] T3 ON T3.[Conpcod] = TM1.[PedConp]) INNER JOIN [CVENDEDORES] T4 ON T4.[VenCod] = TM1.[PedVendCod]) WHERE TM1.[PedCod] = @PedCod ORDER BY TM1.[PedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S16", "SELECT COALESCE( T1.[PedICBPER], 0) AS PedICBPER, COALESCE( T1.[PedSubIna], 0) AS PedSubIna, COALESCE( T1.[PedSubAfe], 0) AS PedSubAfe, COALESCE( T1.[PedSubExonerado], 0) AS PedSubExonerado, COALESCE( T1.[PedSubGratuito], 0) AS PedSubGratuito, COALESCE( T1.[PedSubSelectivo], 0) AS PedSubSelectivo FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod], SUM(CASE  WHEN [PedDIna] = 1 or [PedDIna] = 4 THEN [PedDTot] ELSE 0 END) AS PedSubIna, SUM(CASE  WHEN [PedDIna] = 0 THEN [PedDTot] ELSE 0 END) AS PedSubAfe, SUM(CASE  WHEN [PedDIna] = 2 THEN [PedDTot] ELSE 0 END) AS PedSubExonerado, SUM(CASE  WHEN [PedDIna] = 3 THEN [PedDTot] ELSE 0 END) AS PedSubGratuito, SUM(( [PedDValSel] * CAST([PedDCan] AS decimal( 25, 10))) + ( ROUND(CAST(( [PedDTot] * CAST([PedDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2))) AS PedSubSelectivo FROM [CLPEDIDOSDET] GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S17", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S18", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S19", "SELECT [ConpDsc] AS PedConpDsc, [ConpDias] AS PedConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PedConp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S20", "SELECT [TipLCod] AS PedLisp FROM [CTIPOSLISTAS] WHERE [TipLCod] = @PedLisp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S21", "SELECT [VenDsc] AS PedVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @PedVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S22", "SELECT [TPedCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S23", "SELECT [PedCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S24", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE ( [PedCod] > @PedCod) ORDER BY [PedCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S25", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE ( [PedCod] < @PedCod) ORDER BY [PedCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S26", "INSERT INTO [CLPEDIDOS]([PedCod], [PedFec], [PedRef], [PedPorDsct], [PedPorIVA], [PedObs], [PedTItem], [PedSts], [PedRedondeo], [PedUsuC], [PedFecC], [PedUsuM], [PedFecM], [PedUsuA], [PedFecA], [PedUsuA2], [PedFecA2], [PedIngreso], [PedingObs], [PedCliDespacho], [PedCliDespacho2], [PedFecAten], [PedCotiza], [PedAIVA], [PedTipCod], [CliCod], [MonCod], [TPedCod], [TieCod], [PedConp], [PedLisp], [PedVendCod], [PedICBPER]) VALUES(@PedCod, @PedFec, @PedRef, @PedPorDsct, @PedPorIVA, @PedObs, @PedTItem, @PedSts, @PedRedondeo, @PedUsuC, @PedFecC, @PedUsuM, @PedFecM, @PedUsuA, @PedFecA, @PedUsuA2, @PedFecA2, @PedIngreso, @PedingObs, @PedCliDespacho, @PedCliDespacho2, @PedFecAten, @PedCotiza, @PedAIVA, @PedTipCod, @CliCod, @MonCod, @TPedCod, @TieCod, @PedConp, @PedLisp, @PedVendCod, @PedICBPER)", GxErrorMask.GX_NOMASK,prmT002S26)
           ,new CursorDef("T002S27", "UPDATE [CLPEDIDOS] SET [PedFec]=@PedFec, [PedRef]=@PedRef, [PedPorDsct]=@PedPorDsct, [PedPorIVA]=@PedPorIVA, [PedObs]=@PedObs, [PedTItem]=@PedTItem, [PedSts]=@PedSts, [PedRedondeo]=@PedRedondeo, [PedUsuC]=@PedUsuC, [PedFecC]=@PedFecC, [PedUsuM]=@PedUsuM, [PedFecM]=@PedFecM, [PedUsuA]=@PedUsuA, [PedFecA]=@PedFecA, [PedUsuA2]=@PedUsuA2, [PedFecA2]=@PedFecA2, [PedIngreso]=@PedIngreso, [PedingObs]=@PedingObs, [PedCliDespacho]=@PedCliDespacho, [PedCliDespacho2]=@PedCliDespacho2, [PedFecAten]=@PedFecAten, [PedCotiza]=@PedCotiza, [PedAIVA]=@PedAIVA, [PedTipCod]=@PedTipCod, [CliCod]=@CliCod, [MonCod]=@MonCod, [TPedCod]=@TPedCod, [TieCod]=@TieCod, [PedConp]=@PedConp, [PedLisp]=@PedLisp, [PedVendCod]=@PedVendCod, [PedICBPER]=@PedICBPER  WHERE [PedCod] = @PedCod", GxErrorMask.GX_NOMASK,prmT002S27)
           ,new CursorDef("T002S28", "DELETE FROM [CLPEDIDOS]  WHERE [PedCod] = @PedCod", GxErrorMask.GX_NOMASK,prmT002S28)
           ,new CursorDef("T002S30", "SELECT COALESCE( T1.[PedICBPER], 0) AS PedICBPER, COALESCE( T1.[PedSubIna], 0) AS PedSubIna, COALESCE( T1.[PedSubAfe], 0) AS PedSubAfe, COALESCE( T1.[PedSubExonerado], 0) AS PedSubExonerado, COALESCE( T1.[PedSubGratuito], 0) AS PedSubGratuito, COALESCE( T1.[PedSubSelectivo], 0) AS PedSubSelectivo FROM (SELECT SUM([PedDICBPER]) AS PedICBPER, [PedCod], SUM(CASE  WHEN [PedDIna] = 1 or [PedDIna] = 4 THEN [PedDTot] ELSE 0 END) AS PedSubIna, SUM(CASE  WHEN [PedDIna] = 0 THEN [PedDTot] ELSE 0 END) AS PedSubAfe, SUM(CASE  WHEN [PedDIna] = 2 THEN [PedDTot] ELSE 0 END) AS PedSubExonerado, SUM(CASE  WHEN [PedDIna] = 3 THEN [PedDTot] ELSE 0 END) AS PedSubGratuito, SUM(( [PedDValSel] * CAST([PedDCan] AS decimal( 25, 10))) + ( ROUND(CAST(( [PedDTot] * CAST([PedDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2))) AS PedSubSelectivo FROM [CLPEDIDOSDET] GROUP BY [PedCod] ) T1 WHERE T1.[PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S31", "SELECT [ConpDsc] AS PedConpDsc, [ConpDias] AS PedConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @PedConp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S32", "SELECT [VenDsc] AS PedVendDsc FROM [CVENDEDORES] WHERE [VenCod] = @PedVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S33", "SELECT TOP 1 [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S34", "SELECT TOP 1 [PedCod], [PedDItem] FROM [CLPEDIDOSDET] WHERE [PedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S35", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVPedCod] = @PedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002S36", "SELECT [PedCod] FROM [CLPEDIDOS] ORDER BY [PedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002S36,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S37", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S38", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S39", "SELECT [TipLCod] AS PedLisp FROM [CTIPOSLISTAS] WHERE [TipLCod] = @PedLisp ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002S40", "SELECT [TPedCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002S40,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 50);
              ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((short[]) buf[23])[0] = rslt.getShort(23);
              ((short[]) buf[24])[0] = rslt.getShort(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 3);
              ((string[]) buf[26])[0] = rslt.getString(26, 20);
              ((int[]) buf[27])[0] = rslt.getInt(27);
              ((int[]) buf[28])[0] = rslt.getInt(28);
              ((int[]) buf[29])[0] = rslt.getInt(29);
              ((int[]) buf[30])[0] = rslt.getInt(30);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((bool[]) buf[32])[0] = rslt.wasNull(31);
              ((int[]) buf[33])[0] = rslt.getInt(32);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 50);
              ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((short[]) buf[23])[0] = rslt.getShort(23);
              ((short[]) buf[24])[0] = rslt.getShort(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 3);
              ((string[]) buf[26])[0] = rslt.getString(26, 20);
              ((int[]) buf[27])[0] = rslt.getInt(27);
              ((int[]) buf[28])[0] = rslt.getInt(28);
              ((int[]) buf[29])[0] = rslt.getInt(29);
              ((int[]) buf[30])[0] = rslt.getInt(30);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((bool[]) buf[32])[0] = rslt.wasNull(31);
              ((int[]) buf[33])[0] = rslt.getInt(32);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 50);
              ((string[]) buf[18])[0] = rslt.getLongVarchar(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((short[]) buf[23])[0] = rslt.getShort(23);
              ((string[]) buf[24])[0] = rslt.getString(24, 100);
              ((string[]) buf[25])[0] = rslt.getString(25, 100);
              ((short[]) buf[26])[0] = rslt.getShort(26);
              ((short[]) buf[27])[0] = rslt.getShort(27);
              ((string[]) buf[28])[0] = rslt.getString(28, 3);
              ((string[]) buf[29])[0] = rslt.getString(29, 20);
              ((int[]) buf[30])[0] = rslt.getInt(30);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((int[]) buf[32])[0] = rslt.getInt(32);
              ((int[]) buf[33])[0] = rslt.getInt(33);
              ((int[]) buf[34])[0] = rslt.getInt(34);
              ((bool[]) buf[35])[0] = rslt.wasNull(34);
              ((int[]) buf[36])[0] = rslt.getInt(35);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(36);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(37);
              ((decimal[]) buf[39])[0] = rslt.getDecimal(38);
              ((decimal[]) buf[40])[0] = rslt.getDecimal(39);
              ((decimal[]) buf[41])[0] = rslt.getDecimal(40);
              ((decimal[]) buf[42])[0] = rslt.getDecimal(41);
              return;
           case 11 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 24 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 32 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 33 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 34 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
