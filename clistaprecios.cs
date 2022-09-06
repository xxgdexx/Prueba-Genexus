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
   public class clistaprecios : GXHttpHandler
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
            A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A202TipLCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A45CliCod = GetPar( "CliCod");
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A45CliCod) ;
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
            Form.Meta.addItem("description", "Lista de Precios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clistaprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clistaprecios( IGxContext context )
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
            RenderHtmlCloseForm2P92( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLISTAPRECIOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Tipo de Lista", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipLCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A203TipLItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtTipLItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A203TipLItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A203TipLItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Cliente", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Tipo de Lista", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipLDsc_Internalname, StringUtil.RTrim( A1912TipLDsc), StringUtil.RTrim( context.localUtil.Format( A1912TipLDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Razon Social", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliDsc_Internalname, StringUtil.RTrim( A161CliDsc), StringUtil.RTrim( context.localUtil.Format( A161CliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Precio", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPreLis_Internalname, StringUtil.LTrim( StringUtil.NToC( A1651PreLis, 17, 4, ".", "")), StringUtil.LTrim( ((edtPreLis_Enabled!=0) ? context.localUtil.Format( A1651PreLis, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1651PreLis, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPreLis_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPreLis_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Producto", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLProdDsc_Internalname, StringUtil.RTrim( A1913TipLProdDsc), StringUtil.RTrim( context.localUtil.Format( A1913TipLProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Fecha", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLISTAPRECIOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLisFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLisFech_Internalname, context.localUtil.Format(A1205LisFech, "99/99/99"), context.localUtil.Format( A1205LisFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLisFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLisFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLISTAPRECIOS.htm");
         GxWebStd.gx_bitmap( context, edtLisFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLisFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLISTAPRECIOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLISTAPRECIOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLISTAPRECIOS.htm");
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
            Z202TipLCod = (int)(context.localUtil.CToN( cgiGet( "Z202TipLCod"), ".", ","));
            Z203TipLItem = (int)(context.localUtil.CToN( cgiGet( "Z203TipLItem"), ".", ","));
            Z1651PreLis = context.localUtil.CToN( cgiGet( "Z1651PreLis"), ".", ",");
            Z1913TipLProdDsc = cgiGet( "Z1913TipLProdDsc");
            Z1205LisFech = context.localUtil.CToD( cgiGet( "Z1205LisFech"), 0);
            Z1652PreLisCred = context.localUtil.CToN( cgiGet( "Z1652PreLisCred"), ".", ",");
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z45CliCod = cgiGet( "Z45CliCod");
            A1652PreLisCred = context.localUtil.CToN( cgiGet( "Z1652PreLisCred"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1652PreLisCred = context.localUtil.CToN( cgiGet( "PRELISCRED"), ".", ",");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtTipLCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A202TipLCod = 0;
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            }
            else
            {
               A202TipLCod = (int)(context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ","));
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPLITEM");
               AnyError = 1;
               GX_FocusControl = edtTipLItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A203TipLItem = 0;
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
            }
            else
            {
               A203TipLItem = (int)(context.localUtil.CToN( cgiGet( edtTipLItem_Internalname), ".", ","));
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
            }
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A45CliCod = cgiGet( edtCliCod_Internalname);
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A1912TipLDsc = cgiGet( edtTipLDsc_Internalname);
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A161CliDsc = cgiGet( edtCliDsc_Internalname);
            n161CliDsc = false;
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRELIS");
               AnyError = 1;
               GX_FocusControl = edtPreLis_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1651PreLis = 0;
               AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
            }
            else
            {
               A1651PreLis = context.localUtil.CToN( cgiGet( edtPreLis_Internalname), ".", ",");
               AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
            }
            A1913TipLProdDsc = cgiGet( edtTipLProdDsc_Internalname);
            AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
            if ( context.localUtil.VCDate( cgiGet( edtLisFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "LISFECH");
               AnyError = 1;
               GX_FocusControl = edtLisFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1205LisFech = DateTime.MinValue;
               AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
            }
            else
            {
               A1205LisFech = context.localUtil.CToD( cgiGet( edtLisFech_Internalname), 2);
               AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLISTAPRECIOS");
            forbiddenHiddens.Add("PreLisCred", context.localUtil.Format( A1652PreLisCred, "ZZZZ,ZZZ,ZZ9.9999"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("clistaprecios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               A203TipLItem = (int)(NumberUtil.Val( GetPar( "TipLItem"), "."));
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
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
               InitAll2P92( ) ;
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
         DisableAttributes2P92( ) ;
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

      protected void CONFIRM_2P0( )
      {
         BeforeValidate2P92( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2P92( ) ;
            }
            else
            {
               CheckExtendedTable2P92( ) ;
               if ( AnyError == 0 )
               {
                  ZM2P92( 3) ;
                  ZM2P92( 4) ;
                  ZM2P92( 5) ;
               }
               CloseExtendedTableCursors2P92( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2P0( ) ;
         }
      }

      protected void ResetCaption2P0( )
      {
      }

      protected void ZM2P92( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1651PreLis = T002P3_A1651PreLis[0];
               Z1913TipLProdDsc = T002P3_A1913TipLProdDsc[0];
               Z1205LisFech = T002P3_A1205LisFech[0];
               Z1652PreLisCred = T002P3_A1652PreLisCred[0];
               Z28ProdCod = T002P3_A28ProdCod[0];
               Z45CliCod = T002P3_A45CliCod[0];
            }
            else
            {
               Z1651PreLis = A1651PreLis;
               Z1913TipLProdDsc = A1913TipLProdDsc;
               Z1205LisFech = A1205LisFech;
               Z1652PreLisCred = A1652PreLisCred;
               Z28ProdCod = A28ProdCod;
               Z45CliCod = A45CliCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z203TipLItem = A203TipLItem;
            Z161CliDsc = A161CliDsc;
            Z1651PreLis = A1651PreLis;
            Z1913TipLProdDsc = A1913TipLProdDsc;
            Z1205LisFech = A1205LisFech;
            Z1652PreLisCred = A1652PreLisCred;
            Z202TipLCod = A202TipLCod;
            Z28ProdCod = A28ProdCod;
            Z45CliCod = A45CliCod;
            Z1912TipLDsc = A1912TipLDsc;
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

      protected void Load2P92( )
      {
         /* Using cursor T002P7 */
         pr_default.execute(5, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound92 = 1;
            A1912TipLDsc = T002P7_A1912TipLDsc[0];
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A161CliDsc = T002P7_A161CliDsc[0];
            n161CliDsc = T002P7_n161CliDsc[0];
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            A1651PreLis = T002P7_A1651PreLis[0];
            AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
            A1913TipLProdDsc = T002P7_A1913TipLProdDsc[0];
            AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
            A1205LisFech = T002P7_A1205LisFech[0];
            AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
            A1652PreLisCred = T002P7_A1652PreLisCred[0];
            A28ProdCod = T002P7_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A45CliCod = T002P7_A45CliCod[0];
            n45CliCod = T002P7_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            ZM2P92( -2) ;
         }
         pr_default.close(5);
         OnLoadActions2P92( ) ;
      }

      protected void OnLoadActions2P92( )
      {
         /* Using cursor T002P6 */
         pr_default.execute(4, new Object[] {n45CliCod, A45CliCod});
         A161CliDsc = T002P6_A161CliDsc[0];
         n161CliDsc = T002P6_n161CliDsc[0];
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         pr_default.close(4);
      }

      protected void CheckExtendedTable2P92( )
      {
         nIsDirty_92 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002P4 */
         pr_default.execute(2, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1912TipLDsc = T002P4_A1912TipLDsc[0];
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         pr_default.close(2);
         /* Using cursor T002P5 */
         pr_default.execute(3, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T002P6 */
         pr_default.execute(4, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A161CliDsc = T002P6_A161CliDsc[0];
         n161CliDsc = T002P6_n161CliDsc[0];
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A1205LisFech) || ( DateTimeUtil.ResetTime ( A1205LisFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "LISFECH");
            AnyError = 1;
            GX_FocusControl = edtLisFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2P92( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A202TipLCod )
      {
         /* Using cursor T002P8 */
         pr_default.execute(6, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1912TipLDsc = T002P8_A1912TipLDsc[0];
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1912TipLDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_4( string A28ProdCod )
      {
         /* Using cursor T002P9 */
         pr_default.execute(7, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
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

      protected void gxLoad_5( string A45CliCod )
      {
         /* Using cursor T002P10 */
         pr_default.execute(8, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A161CliDsc = T002P10_A161CliDsc[0];
         n161CliDsc = T002P10_n161CliDsc[0];
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A161CliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey2P92( )
      {
         /* Using cursor T002P11 */
         pr_default.execute(9, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound92 = 1;
         }
         else
         {
            RcdFound92 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002P3 */
         pr_default.execute(1, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2P92( 2) ;
            RcdFound92 = 1;
            A203TipLItem = T002P3_A203TipLItem[0];
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
            A1651PreLis = T002P3_A1651PreLis[0];
            AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
            A1913TipLProdDsc = T002P3_A1913TipLProdDsc[0];
            AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
            A1205LisFech = T002P3_A1205LisFech[0];
            AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
            A1652PreLisCred = T002P3_A1652PreLisCred[0];
            A202TipLCod = T002P3_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A28ProdCod = T002P3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A45CliCod = T002P3_A45CliCod[0];
            n45CliCod = T002P3_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            Z202TipLCod = A202TipLCod;
            Z203TipLItem = A203TipLItem;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2P92( ) ;
            if ( AnyError == 1 )
            {
               RcdFound92 = 0;
               InitializeNonKey2P92( ) ;
            }
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound92 = 0;
            InitializeNonKey2P92( ) ;
            sMode92 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode92;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2P92( ) ;
         if ( RcdFound92 == 0 )
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
         RcdFound92 = 0;
         /* Using cursor T002P12 */
         pr_default.execute(10, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002P12_A202TipLCod[0] < A202TipLCod ) || ( T002P12_A202TipLCod[0] == A202TipLCod ) && ( T002P12_A203TipLItem[0] < A203TipLItem ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002P12_A202TipLCod[0] > A202TipLCod ) || ( T002P12_A202TipLCod[0] == A202TipLCod ) && ( T002P12_A203TipLItem[0] > A203TipLItem ) ) )
            {
               A202TipLCod = T002P12_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               A203TipLItem = T002P12_A203TipLItem[0];
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound92 = 0;
         /* Using cursor T002P13 */
         pr_default.execute(11, new Object[] {A202TipLCod, A203TipLItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002P13_A202TipLCod[0] > A202TipLCod ) || ( T002P13_A202TipLCod[0] == A202TipLCod ) && ( T002P13_A203TipLItem[0] > A203TipLItem ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002P13_A202TipLCod[0] < A202TipLCod ) || ( T002P13_A202TipLCod[0] == A202TipLCod ) && ( T002P13_A203TipLItem[0] < A203TipLItem ) ) )
            {
               A202TipLCod = T002P13_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               A203TipLItem = T002P13_A203TipLItem[0];
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               RcdFound92 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2P92( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2P92( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound92 == 1 )
            {
               if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
               {
                  A202TipLCod = Z202TipLCod;
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
                  A203TipLItem = Z203TipLItem;
                  AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2P92( ) ;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2P92( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPLCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipLCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipLCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2P92( ) ;
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
         if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
         {
            A202TipLCod = Z202TipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A203TipLItem = Z203TipLItem;
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipLCod_Internalname;
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
         GetKey2P92( ) ;
         if ( RcdFound92 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtTipLCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
            {
               A202TipLCod = Z202TipLCod;
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               A203TipLItem = Z203TipLItem;
               AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPLCOD");
               AnyError = 1;
               GX_FocusControl = edtTipLCod_Internalname;
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
            if ( ( A202TipLCod != Z202TipLCod ) || ( A203TipLItem != Z203TipLItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
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
         context.RollbackDataStores("clistaprecios",pr_default);
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2P0( ) ;
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
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2P92( ) ;
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2P92( ) ;
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
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
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
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
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
         ScanStart2P92( ) ;
         if ( RcdFound92 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound92 != 0 )
            {
               ScanNext2P92( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2P92( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2P92( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002P2 */
            pr_default.execute(0, new Object[] {A202TipLCod, A203TipLItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLISTAPRECIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1651PreLis != T002P2_A1651PreLis[0] ) || ( StringUtil.StrCmp(Z1913TipLProdDsc, T002P2_A1913TipLProdDsc[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1205LisFech ) != DateTimeUtil.ResetTime ( T002P2_A1205LisFech[0] ) ) || ( Z1652PreLisCred != T002P2_A1652PreLisCred[0] ) || ( StringUtil.StrCmp(Z28ProdCod, T002P2_A28ProdCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z45CliCod, T002P2_A45CliCod[0]) != 0 ) )
            {
               if ( Z1651PreLis != T002P2_A1651PreLis[0] )
               {
                  GXUtil.WriteLog("clistaprecios:[seudo value changed for attri]"+"PreLis");
                  GXUtil.WriteLogRaw("Old: ",Z1651PreLis);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A1651PreLis[0]);
               }
               if ( StringUtil.StrCmp(Z1913TipLProdDsc, T002P2_A1913TipLProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clistaprecios:[seudo value changed for attri]"+"TipLProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1913TipLProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A1913TipLProdDsc[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1205LisFech ) != DateTimeUtil.ResetTime ( T002P2_A1205LisFech[0] ) )
               {
                  GXUtil.WriteLog("clistaprecios:[seudo value changed for attri]"+"LisFech");
                  GXUtil.WriteLogRaw("Old: ",Z1205LisFech);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A1205LisFech[0]);
               }
               if ( Z1652PreLisCred != T002P2_A1652PreLisCred[0] )
               {
                  GXUtil.WriteLog("clistaprecios:[seudo value changed for attri]"+"PreLisCred");
                  GXUtil.WriteLogRaw("Old: ",Z1652PreLisCred);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A1652PreLisCred[0]);
               }
               if ( StringUtil.StrCmp(Z28ProdCod, T002P2_A28ProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clistaprecios:[seudo value changed for attri]"+"ProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z28ProdCod);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A28ProdCod[0]);
               }
               if ( StringUtil.StrCmp(Z45CliCod, T002P2_A45CliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clistaprecios:[seudo value changed for attri]"+"CliCod");
                  GXUtil.WriteLogRaw("Old: ",Z45CliCod);
                  GXUtil.WriteLogRaw("Current: ",T002P2_A45CliCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLISTAPRECIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2P92( )
      {
         BeforeValidate2P92( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P92( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2P92( 0) ;
            CheckOptimisticConcurrency2P92( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P92( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2P92( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002P14 */
                     pr_default.execute(12, new Object[] {n161CliDsc, A161CliDsc, A203TipLItem, A1651PreLis, A1913TipLProdDsc, A1205LisFech, A1652PreLisCred, A202TipLCod, A28ProdCod, n45CliCod, A45CliCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
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
                           ResetCaption2P0( ) ;
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
               Load2P92( ) ;
            }
            EndLevel2P92( ) ;
         }
         CloseExtendedTableCursors2P92( ) ;
      }

      protected void Update2P92( )
      {
         BeforeValidate2P92( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P92( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P92( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P92( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2P92( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002P15 */
                     pr_default.execute(13, new Object[] {n161CliDsc, A161CliDsc, A1651PreLis, A1913TipLProdDsc, A1205LisFech, A1652PreLisCred, A28ProdCod, n45CliCod, A45CliCod, A202TipLCod, A203TipLItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLISTAPRECIOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2P92( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2P0( ) ;
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
            EndLevel2P92( ) ;
         }
         CloseExtendedTableCursors2P92( ) ;
      }

      protected void DeferredUpdate2P92( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2P92( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P92( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2P92( ) ;
            AfterConfirm2P92( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2P92( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002P16 */
                  pr_default.execute(14, new Object[] {A202TipLCod, A203TipLItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("CLISTAPRECIOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound92 == 0 )
                        {
                           InitAll2P92( ) ;
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
                        ResetCaption2P0( ) ;
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
         sMode92 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2P92( ) ;
         Gx_mode = sMode92;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2P92( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002P17 */
            pr_default.execute(15, new Object[] {A202TipLCod});
            A1912TipLDsc = T002P17_A1912TipLDsc[0];
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            pr_default.close(15);
            /* Using cursor T002P18 */
            pr_default.execute(16, new Object[] {n45CliCod, A45CliCod});
            A161CliDsc = T002P18_A161CliDsc[0];
            n161CliDsc = T002P18_n161CliDsc[0];
            AssignAttri("", false, "A161CliDsc", A161CliDsc);
            pr_default.close(16);
         }
      }

      protected void EndLevel2P92( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2P92( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("clistaprecios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2P0( ) ;
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
            context.RollbackDataStores("clistaprecios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2P92( )
      {
         /* Using cursor T002P19 */
         pr_default.execute(17);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound92 = 1;
            A202TipLCod = T002P19_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A203TipLItem = T002P19_A203TipLItem[0];
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2P92( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound92 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound92 = 1;
            A202TipLCod = T002P19_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A203TipLItem = T002P19_A203TipLItem[0];
            AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         }
      }

      protected void ScanEnd2P92( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm2P92( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2P92( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2P92( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2P92( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2P92( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2P92( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2P92( )
      {
         edtTipLCod_Enabled = 0;
         AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         edtTipLItem_Enabled = 0;
         AssignProp("", false, edtTipLItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLItem_Enabled), 5, 0), true);
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtTipLDsc_Enabled = 0;
         AssignProp("", false, edtTipLDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLDsc_Enabled), 5, 0), true);
         edtCliDsc_Enabled = 0;
         AssignProp("", false, edtCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDsc_Enabled), 5, 0), true);
         edtPreLis_Enabled = 0;
         AssignProp("", false, edtPreLis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPreLis_Enabled), 5, 0), true);
         edtTipLProdDsc_Enabled = 0;
         AssignProp("", false, edtTipLProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLProdDsc_Enabled), 5, 0), true);
         edtLisFech_Enabled = 0;
         AssignProp("", false, edtLisFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLisFech_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2P92( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2P0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Lista de Precios") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228181024440", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clistaprecios.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLISTAPRECIOS");
         forbiddenHiddens.Add("PreLisCred", context.localUtil.Format( A1652PreLisCred, "ZZZZ,ZZZ,ZZ9.9999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("clistaprecios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z202TipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z203TipLItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z203TipLItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1651PreLis", StringUtil.LTrim( StringUtil.NToC( Z1651PreLis, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1913TipLProdDsc", StringUtil.RTrim( Z1913TipLProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1205LisFech", context.localUtil.DToC( Z1205LisFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1652PreLisCred", StringUtil.LTrim( StringUtil.NToC( Z1652PreLisCred, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PRELISCRED", StringUtil.LTrim( StringUtil.NToC( A1652PreLisCred, 15, 4, ".", "")));
      }

      protected void RenderHtmlCloseForm2P92( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "CLISTAPRECIOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lista de Precios" ;
      }

      protected void InitializeNonKey2P92( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         A45CliCod = "";
         n45CliCod = false;
         AssignAttri("", false, "A45CliCod", A45CliCod);
         A1912TipLDsc = "";
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         A161CliDsc = "";
         n161CliDsc = false;
         AssignAttri("", false, "A161CliDsc", A161CliDsc);
         A1651PreLis = 0;
         AssignAttri("", false, "A1651PreLis", StringUtil.LTrimStr( A1651PreLis, 15, 4));
         A1913TipLProdDsc = "";
         AssignAttri("", false, "A1913TipLProdDsc", A1913TipLProdDsc);
         A1205LisFech = DateTime.MinValue;
         AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
         A1652PreLisCred = 0;
         AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrimStr( A1652PreLisCred, 15, 4));
         Z1651PreLis = 0;
         Z1913TipLProdDsc = "";
         Z1205LisFech = DateTime.MinValue;
         Z1652PreLisCred = 0;
         Z28ProdCod = "";
         Z45CliCod = "";
      }

      protected void InitAll2P92( )
      {
         A202TipLCod = 0;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         A203TipLItem = 0;
         AssignAttri("", false, "A203TipLItem", StringUtil.LTrimStr( (decimal)(A203TipLItem), 6, 0));
         InitializeNonKey2P92( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024448", true, true);
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
         context.AddJavascriptSource("clistaprecios.js", "?20228181024448", false, true);
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
         edtTipLCod_Internalname = "TIPLCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTipLItem_Internalname = "TIPLITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdCod_Internalname = "PRODCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCliCod_Internalname = "CLICOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtTipLDsc_Internalname = "TIPLDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCliDsc_Internalname = "CLIDSC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPreLis_Internalname = "PRELIS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtTipLProdDsc_Internalname = "TIPLPRODDSC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLisFech_Internalname = "LISFECH";
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
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLisFech_Jsonclick = "";
         edtLisFech_Enabled = 1;
         edtTipLProdDsc_Jsonclick = "";
         edtTipLProdDsc_Enabled = 1;
         edtPreLis_Jsonclick = "";
         edtPreLis_Enabled = 1;
         edtCliDsc_Jsonclick = "";
         edtCliDsc_Enabled = 0;
         edtTipLDsc_Jsonclick = "";
         edtTipLDsc_Enabled = 0;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTipLItem_Jsonclick = "";
         edtTipLItem_Enabled = 1;
         edtTipLCod_Jsonclick = "";
         edtTipLCod_Enabled = 1;
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
         /* Using cursor T002P17 */
         pr_default.execute(15, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1912TipLDsc = T002P17_A1912TipLDsc[0];
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         pr_default.close(15);
         GX_FocusControl = edtProdCod_Internalname;
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

      public void Valid_Tiplcod( )
      {
         /* Using cursor T002P17 */
         pr_default.execute(15, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de listas de precios'.", "ForeignKeyNotFound", 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
         }
         A1912TipLDsc = T002P17_A1912TipLDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1912TipLDsc", StringUtil.RTrim( A1912TipLDsc));
      }

      public void Valid_Tiplitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28ProdCod", StringUtil.RTrim( A28ProdCod));
         AssignAttri("", false, "A45CliCod", StringUtil.RTrim( A45CliCod));
         AssignAttri("", false, "A1651PreLis", StringUtil.LTrim( StringUtil.NToC( A1651PreLis, 15, 4, ".", "")));
         AssignAttri("", false, "A1913TipLProdDsc", StringUtil.RTrim( A1913TipLProdDsc));
         AssignAttri("", false, "A1205LisFech", context.localUtil.Format(A1205LisFech, "99/99/99"));
         AssignAttri("", false, "A1652PreLisCred", StringUtil.LTrim( StringUtil.NToC( A1652PreLisCred, 15, 4, ".", "")));
         AssignAttri("", false, "A1912TipLDsc", StringUtil.RTrim( A1912TipLDsc));
         AssignAttri("", false, "A161CliDsc", StringUtil.RTrim( A161CliDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z202TipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z203TipLItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z203TipLItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z1651PreLis", StringUtil.LTrim( StringUtil.NToC( Z1651PreLis, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1913TipLProdDsc", StringUtil.RTrim( Z1913TipLProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1205LisFech", context.localUtil.Format(Z1205LisFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1652PreLisCred", StringUtil.LTrim( StringUtil.NToC( Z1652PreLisCred, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1912TipLDsc", StringUtil.RTrim( Z1912TipLDsc));
         GxWebStd.gx_hidden_field( context, "Z161CliDsc", StringUtil.RTrim( Z161CliDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodcod( )
      {
         /* Using cursor T002P20 */
         pr_default.execute(18, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clicod( )
      {
         n45CliCod = false;
         n161CliDsc = false;
         /* Using cursor T002P18 */
         pr_default.execute(16, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
            }
         }
         A161CliDsc = T002P18_A161CliDsc[0];
         n161CliDsc = T002P18_n161CliDsc[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A161CliDsc", StringUtil.RTrim( A161CliDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1652PreLisCred',fld:'PRELISCRED',pic:'ZZZZ,ZZZ,ZZ9.9999'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TIPLCOD","{handler:'Valid_Tiplcod',iparms:[{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9'},{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''}]");
         setEventMetadata("VALID_TIPLCOD",",oparms:[{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''}]}");
         setEventMetadata("VALID_TIPLITEM","{handler:'Valid_Tiplitem',iparms:[{av:'A1652PreLisCred',fld:'PRELISCRED',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9'},{av:'A203TipLItem',fld:'TIPLITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TIPLITEM",",oparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A1651PreLis',fld:'PRELIS',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1913TipLProdDsc',fld:'TIPLPRODDSC',pic:''},{av:'A1205LisFech',fld:'LISFECH',pic:''},{av:'A1652PreLisCred',fld:'PRELISCRED',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''},{av:'A161CliDsc',fld:'CLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z202TipLCod'},{av:'Z203TipLItem'},{av:'Z28ProdCod'},{av:'Z45CliCod'},{av:'Z1651PreLis'},{av:'Z1913TipLProdDsc'},{av:'Z1205LisFech'},{av:'Z1652PreLisCred'},{av:'Z1912TipLDsc'},{av:'Z161CliDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[]}");
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A161CliDsc',fld:'CLIDSC',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[{av:'A161CliDsc',fld:'CLIDSC',pic:''}]}");
         setEventMetadata("VALID_LISFECH","{handler:'Valid_Lisfech',iparms:[]");
         setEventMetadata("VALID_LISFECH",",oparms:[]}");
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
         pr_default.close(18);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1913TipLProdDsc = "";
         Z1205LisFech = DateTime.MinValue;
         Z28ProdCod = "";
         Z45CliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A28ProdCod = "";
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
         lblTextblock2_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A1912TipLDsc = "";
         lblTextblock6_Jsonclick = "";
         A161CliDsc = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A1913TipLProdDsc = "";
         lblTextblock9_Jsonclick = "";
         A1205LisFech = DateTime.MinValue;
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
         Z161CliDsc = "";
         Z1912TipLDsc = "";
         T002P7_A203TipLItem = new int[1] ;
         T002P7_A1912TipLDsc = new string[] {""} ;
         T002P7_A161CliDsc = new string[] {""} ;
         T002P7_n161CliDsc = new bool[] {false} ;
         T002P7_A1651PreLis = new decimal[1] ;
         T002P7_A1913TipLProdDsc = new string[] {""} ;
         T002P7_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         T002P7_A1652PreLisCred = new decimal[1] ;
         T002P7_A202TipLCod = new int[1] ;
         T002P7_A28ProdCod = new string[] {""} ;
         T002P7_A45CliCod = new string[] {""} ;
         T002P7_n45CliCod = new bool[] {false} ;
         T002P6_A161CliDsc = new string[] {""} ;
         T002P6_n161CliDsc = new bool[] {false} ;
         T002P4_A1912TipLDsc = new string[] {""} ;
         T002P5_A28ProdCod = new string[] {""} ;
         T002P8_A1912TipLDsc = new string[] {""} ;
         T002P9_A28ProdCod = new string[] {""} ;
         T002P10_A161CliDsc = new string[] {""} ;
         T002P10_n161CliDsc = new bool[] {false} ;
         T002P11_A202TipLCod = new int[1] ;
         T002P11_A203TipLItem = new int[1] ;
         T002P3_A203TipLItem = new int[1] ;
         T002P3_A1651PreLis = new decimal[1] ;
         T002P3_A1913TipLProdDsc = new string[] {""} ;
         T002P3_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         T002P3_A1652PreLisCred = new decimal[1] ;
         T002P3_A202TipLCod = new int[1] ;
         T002P3_A28ProdCod = new string[] {""} ;
         T002P3_A45CliCod = new string[] {""} ;
         T002P3_n45CliCod = new bool[] {false} ;
         T002P3_A161CliDsc = new string[] {""} ;
         T002P3_n161CliDsc = new bool[] {false} ;
         sMode92 = "";
         T002P12_A202TipLCod = new int[1] ;
         T002P12_A203TipLItem = new int[1] ;
         T002P13_A202TipLCod = new int[1] ;
         T002P13_A203TipLItem = new int[1] ;
         T002P2_A203TipLItem = new int[1] ;
         T002P2_A1651PreLis = new decimal[1] ;
         T002P2_A1913TipLProdDsc = new string[] {""} ;
         T002P2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         T002P2_A1652PreLisCred = new decimal[1] ;
         T002P2_A202TipLCod = new int[1] ;
         T002P2_A28ProdCod = new string[] {""} ;
         T002P2_A45CliCod = new string[] {""} ;
         T002P2_n45CliCod = new bool[] {false} ;
         T002P2_A161CliDsc = new string[] {""} ;
         T002P2_n161CliDsc = new bool[] {false} ;
         T002P17_A1912TipLDsc = new string[] {""} ;
         T002P18_A161CliDsc = new string[] {""} ;
         T002P18_n161CliDsc = new bool[] {false} ;
         T002P19_A202TipLCod = new int[1] ;
         T002P19_A203TipLItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ28ProdCod = "";
         ZZ45CliCod = "";
         ZZ1913TipLProdDsc = "";
         ZZ1205LisFech = DateTime.MinValue;
         ZZ1912TipLDsc = "";
         ZZ161CliDsc = "";
         T002P20_A28ProdCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clistaprecios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clistaprecios__default(),
            new Object[][] {
                new Object[] {
               T002P2_A203TipLItem, T002P2_A1651PreLis, T002P2_A1913TipLProdDsc, T002P2_A1205LisFech, T002P2_A1652PreLisCred, T002P2_A202TipLCod, T002P2_A28ProdCod, T002P2_A45CliCod, T002P2_n45CliCod, T002P2_A161CliDsc,
               T002P2_n161CliDsc
               }
               , new Object[] {
               T002P3_A203TipLItem, T002P3_A1651PreLis, T002P3_A1913TipLProdDsc, T002P3_A1205LisFech, T002P3_A1652PreLisCred, T002P3_A202TipLCod, T002P3_A28ProdCod, T002P3_A45CliCod, T002P3_n45CliCod, T002P3_A161CliDsc,
               T002P3_n161CliDsc
               }
               , new Object[] {
               T002P4_A1912TipLDsc
               }
               , new Object[] {
               T002P5_A28ProdCod
               }
               , new Object[] {
               T002P6_A161CliDsc
               }
               , new Object[] {
               T002P7_A203TipLItem, T002P7_A1912TipLDsc, T002P7_A161CliDsc, T002P7_n161CliDsc, T002P7_A1651PreLis, T002P7_A1913TipLProdDsc, T002P7_A1205LisFech, T002P7_A1652PreLisCred, T002P7_A202TipLCod, T002P7_A28ProdCod,
               T002P7_A45CliCod, T002P7_n45CliCod
               }
               , new Object[] {
               T002P8_A1912TipLDsc
               }
               , new Object[] {
               T002P9_A28ProdCod
               }
               , new Object[] {
               T002P10_A161CliDsc
               }
               , new Object[] {
               T002P11_A202TipLCod, T002P11_A203TipLItem
               }
               , new Object[] {
               T002P12_A202TipLCod, T002P12_A203TipLItem
               }
               , new Object[] {
               T002P13_A202TipLCod, T002P13_A203TipLItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002P17_A1912TipLDsc
               }
               , new Object[] {
               T002P18_A161CliDsc
               }
               , new Object[] {
               T002P19_A202TipLCod, T002P19_A203TipLItem
               }
               , new Object[] {
               T002P20_A28ProdCod
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
      private short nDynComponent ;
      private short GX_JID ;
      private short RcdFound92 ;
      private short nIsDirty_92 ;
      private short Gx_BScreen ;
      private int Z202TipLCod ;
      private int Z203TipLItem ;
      private int A202TipLCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipLCod_Enabled ;
      private int A203TipLItem ;
      private int edtTipLItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtProdCod_Enabled ;
      private int edtCliCod_Enabled ;
      private int edtTipLDsc_Enabled ;
      private int edtCliDsc_Enabled ;
      private int edtPreLis_Enabled ;
      private int edtTipLProdDsc_Enabled ;
      private int edtLisFech_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ202TipLCod ;
      private int ZZ203TipLItem ;
      private decimal Z1651PreLis ;
      private decimal Z1652PreLisCred ;
      private decimal A1651PreLis ;
      private decimal A1652PreLisCred ;
      private decimal ZZ1651PreLis ;
      private decimal ZZ1652PreLisCred ;
      private string sPrefix ;
      private string Z1913TipLProdDsc ;
      private string Z28ProdCod ;
      private string Z45CliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A28ProdCod ;
      private string A45CliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipLCod_Internalname ;
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
      private string edtTipLCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTipLItem_Internalname ;
      private string edtTipLItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtProdCod_Internalname ;
      private string edtProdCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCliCod_Internalname ;
      private string edtCliCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtTipLDsc_Internalname ;
      private string A1912TipLDsc ;
      private string edtTipLDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCliDsc_Internalname ;
      private string A161CliDsc ;
      private string edtCliDsc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPreLis_Internalname ;
      private string edtPreLis_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtTipLProdDsc_Internalname ;
      private string A1913TipLProdDsc ;
      private string edtTipLProdDsc_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLisFech_Internalname ;
      private string edtLisFech_Jsonclick ;
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
      private string Z161CliDsc ;
      private string Z1912TipLDsc ;
      private string sMode92 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ28ProdCod ;
      private string ZZ45CliCod ;
      private string ZZ1913TipLProdDsc ;
      private string ZZ1912TipLDsc ;
      private string ZZ161CliDsc ;
      private DateTime Z1205LisFech ;
      private DateTime A1205LisFech ;
      private DateTime ZZ1205LisFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n45CliCod ;
      private bool wbErr ;
      private bool n161CliDsc ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002P7_A203TipLItem ;
      private string[] T002P7_A1912TipLDsc ;
      private string[] T002P7_A161CliDsc ;
      private bool[] T002P7_n161CliDsc ;
      private decimal[] T002P7_A1651PreLis ;
      private string[] T002P7_A1913TipLProdDsc ;
      private DateTime[] T002P7_A1205LisFech ;
      private decimal[] T002P7_A1652PreLisCred ;
      private int[] T002P7_A202TipLCod ;
      private string[] T002P7_A28ProdCod ;
      private string[] T002P7_A45CliCod ;
      private bool[] T002P7_n45CliCod ;
      private string[] T002P6_A161CliDsc ;
      private bool[] T002P6_n161CliDsc ;
      private string[] T002P4_A1912TipLDsc ;
      private string[] T002P5_A28ProdCod ;
      private string[] T002P8_A1912TipLDsc ;
      private string[] T002P9_A28ProdCod ;
      private string[] T002P10_A161CliDsc ;
      private bool[] T002P10_n161CliDsc ;
      private int[] T002P11_A202TipLCod ;
      private int[] T002P11_A203TipLItem ;
      private int[] T002P3_A203TipLItem ;
      private decimal[] T002P3_A1651PreLis ;
      private string[] T002P3_A1913TipLProdDsc ;
      private DateTime[] T002P3_A1205LisFech ;
      private decimal[] T002P3_A1652PreLisCred ;
      private int[] T002P3_A202TipLCod ;
      private string[] T002P3_A28ProdCod ;
      private string[] T002P3_A45CliCod ;
      private bool[] T002P3_n45CliCod ;
      private string[] T002P3_A161CliDsc ;
      private bool[] T002P3_n161CliDsc ;
      private int[] T002P12_A202TipLCod ;
      private int[] T002P12_A203TipLItem ;
      private int[] T002P13_A202TipLCod ;
      private int[] T002P13_A203TipLItem ;
      private int[] T002P2_A203TipLItem ;
      private decimal[] T002P2_A1651PreLis ;
      private string[] T002P2_A1913TipLProdDsc ;
      private DateTime[] T002P2_A1205LisFech ;
      private decimal[] T002P2_A1652PreLisCred ;
      private int[] T002P2_A202TipLCod ;
      private string[] T002P2_A28ProdCod ;
      private string[] T002P2_A45CliCod ;
      private bool[] T002P2_n45CliCod ;
      private string[] T002P2_A161CliDsc ;
      private bool[] T002P2_n161CliDsc ;
      private string[] T002P17_A1912TipLDsc ;
      private string[] T002P18_A161CliDsc ;
      private bool[] T002P18_n161CliDsc ;
      private int[] T002P19_A202TipLCod ;
      private int[] T002P19_A203TipLItem ;
      private string[] T002P20_A28ProdCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class clistaprecios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clistaprecios__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002P7;
        prmT002P7 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P4;
        prmT002P4 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT002P5;
        prmT002P5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002P6;
        prmT002P6 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT002P8;
        prmT002P8 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT002P9;
        prmT002P9 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002P10;
        prmT002P10 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT002P11;
        prmT002P11 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P3;
        prmT002P3 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P12;
        prmT002P12 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P13;
        prmT002P13 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P2;
        prmT002P2 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P14;
        prmT002P14 = new Object[] {
        new ParDef("@CliDsc",GXType.NChar,100,0){Nullable=true} ,
        new ParDef("@TipLItem",GXType.Int32,6,0) ,
        new ParDef("@PreLis",GXType.Decimal,15,4) ,
        new ParDef("@TipLProdDsc",GXType.NChar,100,0) ,
        new ParDef("@LisFech",GXType.Date,8,0) ,
        new ParDef("@PreLisCred",GXType.Decimal,15,4) ,
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT002P15;
        prmT002P15 = new Object[] {
        new ParDef("@CliDsc",GXType.NChar,100,0){Nullable=true} ,
        new ParDef("@PreLis",GXType.Decimal,15,4) ,
        new ParDef("@TipLProdDsc",GXType.NChar,100,0) ,
        new ParDef("@LisFech",GXType.Date,8,0) ,
        new ParDef("@PreLisCred",GXType.Decimal,15,4) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P16;
        prmT002P16 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLItem",GXType.Int32,6,0)
        };
        Object[] prmT002P19;
        prmT002P19 = new Object[] {
        };
        Object[] prmT002P17;
        prmT002P17 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT002P20;
        prmT002P20 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT002P18;
        prmT002P18 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T002P2", "SELECT [TipLItem], [PreLis], [TipLProdDsc], [LisFech], [PreLisCred], [TipLCod], [ProdCod], [CliCod], [CliDsc] FROM [CLISTAPRECIOS] WITH (UPDLOCK) WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P3", "SELECT [TipLItem], [PreLis], [TipLProdDsc], [LisFech], [PreLisCred], [TipLCod], [ProdCod], [CliCod], [CliDsc] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P4", "SELECT [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P5", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P6", "SELECT [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P7", "SELECT TM1.[TipLItem], T2.[TipLDsc], TM1.[CliDsc], TM1.[PreLis], TM1.[TipLProdDsc], TM1.[LisFech], TM1.[PreLisCred], TM1.[TipLCod], TM1.[ProdCod], TM1.[CliCod] FROM ([CLISTAPRECIOS] TM1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = TM1.[TipLCod]) WHERE TM1.[TipLCod] = @TipLCod and TM1.[TipLItem] = @TipLItem ORDER BY TM1.[TipLCod], TM1.[TipLItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P8", "SELECT [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P9", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P10", "SELECT [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P11", "SELECT [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P12", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE ( [TipLCod] > @TipLCod or [TipLCod] = @TipLCod and [TipLItem] > @TipLItem) ORDER BY [TipLCod], [TipLItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002P13", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE ( [TipLCod] < @TipLCod or [TipLCod] = @TipLCod and [TipLItem] < @TipLItem) ORDER BY [TipLCod] DESC, [TipLItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002P14", "INSERT INTO [CLISTAPRECIOS]([CliDsc], [TipLItem], [PreLis], [TipLProdDsc], [LisFech], [PreLisCred], [TipLCod], [ProdCod], [CliCod]) VALUES(@CliDsc, @TipLItem, @PreLis, @TipLProdDsc, @LisFech, @PreLisCred, @TipLCod, @ProdCod, @CliCod)", GxErrorMask.GX_NOMASK,prmT002P14)
           ,new CursorDef("T002P15", "UPDATE [CLISTAPRECIOS] SET [CliDsc]=@CliDsc, [PreLis]=@PreLis, [TipLProdDsc]=@TipLProdDsc, [LisFech]=@LisFech, [PreLisCred]=@PreLisCred, [ProdCod]=@ProdCod, [CliCod]=@CliCod  WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem", GxErrorMask.GX_NOMASK,prmT002P15)
           ,new CursorDef("T002P16", "DELETE FROM [CLISTAPRECIOS]  WHERE [TipLCod] = @TipLCod AND [TipLItem] = @TipLItem", GxErrorMask.GX_NOMASK,prmT002P16)
           ,new CursorDef("T002P17", "SELECT [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P18", "SELECT [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P19", "SELECT [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] ORDER BY [TipLCod], [TipLItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002P19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002P20", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002P20,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 100);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 100);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 15);
              ((string[]) buf[10])[0] = rslt.getString(10, 20);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
