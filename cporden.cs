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
   public class cporden : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A289OrdCod = GetPar( "OrdCod");
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A289OrdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A292OrdConpCod = (int)(NumberUtil.Val( GetPar( "OrdConpCod"), "."));
            AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrimStr( (decimal)(A292OrdConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A292OrdConpCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A291OrdCosCod = GetPar( "OrdCosCod");
            n291OrdCosCod = false;
            AssignAttri("", false, "A291OrdCosCod", A291OrdCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A291OrdCosCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A290OrdMonCod = (int)(NumberUtil.Val( GetPar( "OrdMonCod"), "."));
            AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrimStr( (decimal)(A290OrdMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A290OrdMonCod) ;
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
            Form.Meta.addItem("description", "Ordenes de Compra - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cporden( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cporden( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPORDEN.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Orden", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdCod_Internalname, StringUtil.RTrim( A289OrdCod), StringUtil.RTrim( context.localUtil.Format( A289OrdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Proveedor", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrdFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrdFec_Internalname, context.localUtil.Format(A293OrdFec, "99/99/99"), context.localUtil.Format( A293OrdFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         GxWebStd.gx_bitmap( context, edtOrdFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrdFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Condición de Pago", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A292OrdConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrdConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A292OrdConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A292OrdConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "% Dscto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdPorDscto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1458OrdPorDscto, 5, 2, ".", "")), StringUtil.LTrim( ((edtOrdPorDscto_Enabled!=0) ? context.localUtil.Format( A1458OrdPorDscto, "Z9.99") : context.localUtil.Format( A1458OrdPorDscto, "Z9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdPorDscto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdPorDscto_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "% I.G.V", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdPorIva_Internalname, StringUtil.LTrim( StringUtil.NToC( A1459OrdPorIva, 5, 2, ".", "")), StringUtil.LTrim( ((edtOrdPorIva_Enabled!=0) ? context.localUtil.Format( A1459OrdPorIva, "Z9.99") : context.localUtil.Format( A1459OrdPorIva, "Z9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdPorIva_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdPorIva_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Observaciones", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtOrdObs_Internalname, A1454OrdObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", 0, 1, edtOrdObs_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Total Item", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1453OrdItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrdItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1453OrdItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1453OrdItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Situación", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdSts_Internalname, StringUtil.RTrim( A1462OrdSts), StringUtil.RTrim( context.localUtil.Format( A1462OrdSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Usuario Creación", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdUsuC_Internalname, StringUtil.RTrim( A1469OrdUsuC), StringUtil.RTrim( context.localUtil.Format( A1469OrdUsuC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Fecha Creación", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrdFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrdFecC_Internalname, context.localUtil.TToC( A1451OrdFecC, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1451OrdFecC, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdFecC_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         GxWebStd.gx_bitmap( context, edtOrdFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrdFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Usuario Modificación", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdUsuM_Internalname, StringUtil.RTrim( A1470OrdUsuM), StringUtil.RTrim( context.localUtil.Format( A1470OrdUsuM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Fecha Modificación", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrdFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrdFecM_Internalname, context.localUtil.TToC( A1452OrdFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1452OrdFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         GxWebStd.gx_bitmap( context, edtOrdFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrdFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Autorización", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1426OrdAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtOrdAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A1426OrdAut), "9") : context.localUtil.Format( (decimal)(A1426OrdAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Usuario Autorización", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdUsuAut_Internalname, StringUtil.RTrim( A1467OrdUsuAut), StringUtil.RTrim( context.localUtil.Format( A1467OrdUsuAut, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdUsuAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdUsuAut_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Fecha Autorización", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrdFecAut_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrdFecAut_Internalname, context.localUtil.Format(A1449OrdFecAut, "99/99/99"), context.localUtil.Format( A1449OrdFecAut, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdFecAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdFecAut_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         GxWebStd.gx_bitmap( context, edtOrdFecAut_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrdFecAut_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Centro de Costo", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdCosCod_Internalname, StringUtil.RTrim( A291OrdCosCod), StringUtil.RTrim( context.localUtil.Format( A291OrdCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "N° Requerimiento", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdRequ_Internalname, StringUtil.RTrim( A1461OrdRequ), StringUtil.RTrim( context.localUtil.Format( A1461OrdRequ, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdRequ_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdRequ_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Lugar de Entrega", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdEntrega_Internalname, StringUtil.RTrim( A1448OrdEntrega), StringUtil.RTrim( context.localUtil.Format( A1448OrdEntrega, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdEntrega_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Moneda", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A290OrdMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrdMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A290OrdMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A290OrdMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Tipo de Orden", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdTip_Internalname, A1466OrdTip, StringUtil.RTrim( context.localUtil.Format( A1466OrdTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Almacen", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1425OrdAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrdAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1425OrdAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1425OrdAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDEN.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDEN.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPORDEN.htm");
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
            Z289OrdCod = cgiGet( "Z289OrdCod");
            Z293OrdFec = context.localUtil.CToD( cgiGet( "Z293OrdFec"), 0);
            Z1458OrdPorDscto = context.localUtil.CToN( cgiGet( "Z1458OrdPorDscto"), ".", ",");
            Z1459OrdPorIva = context.localUtil.CToN( cgiGet( "Z1459OrdPorIva"), ".", ",");
            Z1453OrdItem = (int)(context.localUtil.CToN( cgiGet( "Z1453OrdItem"), ".", ","));
            Z1462OrdSts = cgiGet( "Z1462OrdSts");
            Z1469OrdUsuC = cgiGet( "Z1469OrdUsuC");
            Z1451OrdFecC = context.localUtil.CToT( cgiGet( "Z1451OrdFecC"), 0);
            Z1470OrdUsuM = cgiGet( "Z1470OrdUsuM");
            Z1452OrdFecM = context.localUtil.CToT( cgiGet( "Z1452OrdFecM"), 0);
            Z1426OrdAut = (short)(context.localUtil.CToN( cgiGet( "Z1426OrdAut"), ".", ","));
            Z1467OrdUsuAut = cgiGet( "Z1467OrdUsuAut");
            Z1449OrdFecAut = context.localUtil.CToD( cgiGet( "Z1449OrdFecAut"), 0);
            Z1468OrdUsuAut1 = cgiGet( "Z1468OrdUsuAut1");
            Z1450OrdFecAut1 = context.localUtil.CToD( cgiGet( "Z1450OrdFecAut1"), 0);
            Z1461OrdRequ = cgiGet( "Z1461OrdRequ");
            Z1448OrdEntrega = cgiGet( "Z1448OrdEntrega");
            Z1466OrdTip = cgiGet( "Z1466OrdTip");
            Z1425OrdAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z1425OrdAlmCod"), ".", ","));
            Z1424OrdAIVA = (short)(context.localUtil.CToN( cgiGet( "Z1424OrdAIVA"), ".", ","));
            Z2236OrdTItemCron = (int)(context.localUtil.CToN( cgiGet( "Z2236OrdTItemCron"), ".", ","));
            Z244PrvCod = cgiGet( "Z244PrvCod");
            Z292OrdConpCod = (int)(context.localUtil.CToN( cgiGet( "Z292OrdConpCod"), ".", ","));
            Z291OrdCosCod = cgiGet( "Z291OrdCosCod");
            Z290OrdMonCod = (int)(context.localUtil.CToN( cgiGet( "Z290OrdMonCod"), ".", ","));
            A1468OrdUsuAut1 = cgiGet( "Z1468OrdUsuAut1");
            A1450OrdFecAut1 = context.localUtil.CToD( cgiGet( "Z1450OrdFecAut1"), 0);
            A1424OrdAIVA = (short)(context.localUtil.CToN( cgiGet( "Z1424OrdAIVA"), ".", ","));
            A2236OrdTItemCron = (int)(context.localUtil.CToN( cgiGet( "Z2236OrdTItemCron"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1465OrdSubTotal = context.localUtil.CToN( cgiGet( "ORDSUBTOTAL"), ".", ",");
            A2233OrdDscto = context.localUtil.CToN( cgiGet( "ORDDSCTO"), ".", ",");
            A1463OrdSubAfecto = context.localUtil.CToN( cgiGet( "ORDSUBAFECTO"), ".", ",");
            A2234OrdIva = context.localUtil.CToN( cgiGet( "ORDIVA"), ".", ",");
            A1464OrdSubInafecto = context.localUtil.CToN( cgiGet( "ORDSUBINAFECTO"), ".", ",");
            A2235OrdTot = context.localUtil.CToN( cgiGet( "ORDTOT"), ".", ",");
            A1468OrdUsuAut1 = cgiGet( "ORDUSUAUT1");
            A1450OrdFecAut1 = context.localUtil.CToD( cgiGet( "ORDFECAUT1"), 0);
            A1424OrdAIVA = (short)(context.localUtil.CToN( cgiGet( "ORDAIVA"), ".", ","));
            A2236OrdTItemCron = (int)(context.localUtil.CToN( cgiGet( "ORDTITEMCRON"), ".", ","));
            A298TprvCod = (int)(context.localUtil.CToN( cgiGet( "TPRVCOD"), ".", ","));
            A1427OrdConpDsc = cgiGet( "ORDCONPDSC");
            /* Read variables values. */
            A289OrdCod = cgiGet( edtOrdCod_Internalname);
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            if ( context.localUtil.VCDate( cgiGet( edtOrdFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "ORDFEC");
               AnyError = 1;
               GX_FocusControl = edtOrdFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A293OrdFec = DateTime.MinValue;
               AssignAttri("", false, "A293OrdFec", context.localUtil.Format(A293OrdFec, "99/99/99"));
            }
            else
            {
               A293OrdFec = context.localUtil.CToD( cgiGet( edtOrdFec_Internalname), 2);
               AssignAttri("", false, "A293OrdFec", context.localUtil.Format(A293OrdFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A292OrdConpCod = 0;
               AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrimStr( (decimal)(A292OrdConpCod), 6, 0));
            }
            else
            {
               A292OrdConpCod = (int)(context.localUtil.CToN( cgiGet( edtOrdConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrimStr( (decimal)(A292OrdConpCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdPorDscto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdPorDscto_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDPORDSCTO");
               AnyError = 1;
               GX_FocusControl = edtOrdPorDscto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1458OrdPorDscto = 0;
               AssignAttri("", false, "A1458OrdPorDscto", StringUtil.LTrimStr( A1458OrdPorDscto, 5, 2));
            }
            else
            {
               A1458OrdPorDscto = context.localUtil.CToN( cgiGet( edtOrdPorDscto_Internalname), ".", ",");
               AssignAttri("", false, "A1458OrdPorDscto", StringUtil.LTrimStr( A1458OrdPorDscto, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdPorIva_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdPorIva_Internalname), ".", ",") > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDPORIVA");
               AnyError = 1;
               GX_FocusControl = edtOrdPorIva_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1459OrdPorIva = 0;
               AssignAttri("", false, "A1459OrdPorIva", StringUtil.LTrimStr( A1459OrdPorIva, 5, 2));
            }
            else
            {
               A1459OrdPorIva = context.localUtil.CToN( cgiGet( edtOrdPorIva_Internalname), ".", ",");
               AssignAttri("", false, "A1459OrdPorIva", StringUtil.LTrimStr( A1459OrdPorIva, 5, 2));
            }
            A1454OrdObs = cgiGet( edtOrdObs_Internalname);
            AssignAttri("", false, "A1454OrdObs", A1454OrdObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDITEM");
               AnyError = 1;
               GX_FocusControl = edtOrdItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1453OrdItem = 0;
               AssignAttri("", false, "A1453OrdItem", StringUtil.LTrimStr( (decimal)(A1453OrdItem), 6, 0));
            }
            else
            {
               A1453OrdItem = (int)(context.localUtil.CToN( cgiGet( edtOrdItem_Internalname), ".", ","));
               AssignAttri("", false, "A1453OrdItem", StringUtil.LTrimStr( (decimal)(A1453OrdItem), 6, 0));
            }
            A1462OrdSts = cgiGet( edtOrdSts_Internalname);
            AssignAttri("", false, "A1462OrdSts", A1462OrdSts);
            A1469OrdUsuC = cgiGet( edtOrdUsuC_Internalname);
            AssignAttri("", false, "A1469OrdUsuC", A1469OrdUsuC);
            if ( context.localUtil.VCDateTime( cgiGet( edtOrdFecC_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Creación"}), 1, "ORDFECC");
               AnyError = 1;
               GX_FocusControl = edtOrdFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1451OrdFecC = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1451OrdFecC", context.localUtil.TToC( A1451OrdFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1451OrdFecC = context.localUtil.CToT( cgiGet( edtOrdFecC_Internalname));
               AssignAttri("", false, "A1451OrdFecC", context.localUtil.TToC( A1451OrdFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            A1470OrdUsuM = cgiGet( edtOrdUsuM_Internalname);
            AssignAttri("", false, "A1470OrdUsuM", A1470OrdUsuM);
            if ( context.localUtil.VCDateTime( cgiGet( edtOrdFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Modificación"}), 1, "ORDFECM");
               AnyError = 1;
               GX_FocusControl = edtOrdFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1452OrdFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1452OrdFecM", context.localUtil.TToC( A1452OrdFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1452OrdFecM = context.localUtil.CToT( cgiGet( edtOrdFecM_Internalname));
               AssignAttri("", false, "A1452OrdFecM", context.localUtil.TToC( A1452OrdFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdAut_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdAut_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDAUT");
               AnyError = 1;
               GX_FocusControl = edtOrdAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1426OrdAut = 0;
               AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            }
            else
            {
               A1426OrdAut = (short)(context.localUtil.CToN( cgiGet( edtOrdAut_Internalname), ".", ","));
               AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            }
            A1467OrdUsuAut = cgiGet( edtOrdUsuAut_Internalname);
            AssignAttri("", false, "A1467OrdUsuAut", A1467OrdUsuAut);
            if ( context.localUtil.VCDate( cgiGet( edtOrdFecAut_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Autorización"}), 1, "ORDFECAUT");
               AnyError = 1;
               GX_FocusControl = edtOrdFecAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1449OrdFecAut = DateTime.MinValue;
               AssignAttri("", false, "A1449OrdFecAut", context.localUtil.Format(A1449OrdFecAut, "99/99/99"));
            }
            else
            {
               A1449OrdFecAut = context.localUtil.CToD( cgiGet( edtOrdFecAut_Internalname), 2);
               AssignAttri("", false, "A1449OrdFecAut", context.localUtil.Format(A1449OrdFecAut, "99/99/99"));
            }
            A291OrdCosCod = cgiGet( edtOrdCosCod_Internalname);
            n291OrdCosCod = false;
            AssignAttri("", false, "A291OrdCosCod", A291OrdCosCod);
            A1461OrdRequ = cgiGet( edtOrdRequ_Internalname);
            AssignAttri("", false, "A1461OrdRequ", A1461OrdRequ);
            A1448OrdEntrega = cgiGet( edtOrdEntrega_Internalname);
            AssignAttri("", false, "A1448OrdEntrega", A1448OrdEntrega);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDMONCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A290OrdMonCod = 0;
               AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrimStr( (decimal)(A290OrdMonCod), 6, 0));
            }
            else
            {
               A290OrdMonCod = (int)(context.localUtil.CToN( cgiGet( edtOrdMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrimStr( (decimal)(A290OrdMonCod), 6, 0));
            }
            A1466OrdTip = cgiGet( edtOrdTip_Internalname);
            AssignAttri("", false, "A1466OrdTip", A1466OrdTip);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDALMCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1425OrdAlmCod = 0;
               n1425OrdAlmCod = false;
               AssignAttri("", false, "A1425OrdAlmCod", StringUtil.LTrimStr( (decimal)(A1425OrdAlmCod), 6, 0));
            }
            else
            {
               A1425OrdAlmCod = (int)(context.localUtil.CToN( cgiGet( edtOrdAlmCod_Internalname), ".", ","));
               n1425OrdAlmCod = false;
               AssignAttri("", false, "A1425OrdAlmCod", StringUtil.LTrimStr( (decimal)(A1425OrdAlmCod), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CPORDEN");
            forbiddenHiddens.Add("OrdUsuAut1", StringUtil.RTrim( context.localUtil.Format( A1468OrdUsuAut1, "")));
            forbiddenHiddens.Add("OrdFecAut1", context.localUtil.Format(A1450OrdFecAut1, "99/99/99"));
            forbiddenHiddens.Add("OrdAIVA", context.localUtil.Format( (decimal)(A1424OrdAIVA), "9"));
            forbiddenHiddens.Add("OrdTItemCron", context.localUtil.Format( (decimal)(A2236OrdTItemCron), "ZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cporden:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A289OrdCod = GetPar( "OrdCod");
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
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
               InitAll3I121( ) ;
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
         DisableAttributes3I121( ) ;
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

      protected void CONFIRM_3I0( )
      {
         BeforeValidate3I121( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3I121( ) ;
            }
            else
            {
               CheckExtendedTable3I121( ) ;
               if ( AnyError == 0 )
               {
                  ZM3I121( 10) ;
                  ZM3I121( 11) ;
                  ZM3I121( 12) ;
                  ZM3I121( 13) ;
                  ZM3I121( 14) ;
               }
               CloseExtendedTableCursors3I121( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3I0( ) ;
         }
      }

      protected void ResetCaption3I0( )
      {
      }

      protected void ZM3I121( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z293OrdFec = T003I3_A293OrdFec[0];
               Z1458OrdPorDscto = T003I3_A1458OrdPorDscto[0];
               Z1459OrdPorIva = T003I3_A1459OrdPorIva[0];
               Z1453OrdItem = T003I3_A1453OrdItem[0];
               Z1462OrdSts = T003I3_A1462OrdSts[0];
               Z1469OrdUsuC = T003I3_A1469OrdUsuC[0];
               Z1451OrdFecC = T003I3_A1451OrdFecC[0];
               Z1470OrdUsuM = T003I3_A1470OrdUsuM[0];
               Z1452OrdFecM = T003I3_A1452OrdFecM[0];
               Z1426OrdAut = T003I3_A1426OrdAut[0];
               Z1467OrdUsuAut = T003I3_A1467OrdUsuAut[0];
               Z1449OrdFecAut = T003I3_A1449OrdFecAut[0];
               Z1468OrdUsuAut1 = T003I3_A1468OrdUsuAut1[0];
               Z1450OrdFecAut1 = T003I3_A1450OrdFecAut1[0];
               Z1461OrdRequ = T003I3_A1461OrdRequ[0];
               Z1448OrdEntrega = T003I3_A1448OrdEntrega[0];
               Z1466OrdTip = T003I3_A1466OrdTip[0];
               Z1425OrdAlmCod = T003I3_A1425OrdAlmCod[0];
               Z1424OrdAIVA = T003I3_A1424OrdAIVA[0];
               Z2236OrdTItemCron = T003I3_A2236OrdTItemCron[0];
               Z244PrvCod = T003I3_A244PrvCod[0];
               Z292OrdConpCod = T003I3_A292OrdConpCod[0];
               Z291OrdCosCod = T003I3_A291OrdCosCod[0];
               Z290OrdMonCod = T003I3_A290OrdMonCod[0];
            }
            else
            {
               Z293OrdFec = A293OrdFec;
               Z1458OrdPorDscto = A1458OrdPorDscto;
               Z1459OrdPorIva = A1459OrdPorIva;
               Z1453OrdItem = A1453OrdItem;
               Z1462OrdSts = A1462OrdSts;
               Z1469OrdUsuC = A1469OrdUsuC;
               Z1451OrdFecC = A1451OrdFecC;
               Z1470OrdUsuM = A1470OrdUsuM;
               Z1452OrdFecM = A1452OrdFecM;
               Z1426OrdAut = A1426OrdAut;
               Z1467OrdUsuAut = A1467OrdUsuAut;
               Z1449OrdFecAut = A1449OrdFecAut;
               Z1468OrdUsuAut1 = A1468OrdUsuAut1;
               Z1450OrdFecAut1 = A1450OrdFecAut1;
               Z1461OrdRequ = A1461OrdRequ;
               Z1448OrdEntrega = A1448OrdEntrega;
               Z1466OrdTip = A1466OrdTip;
               Z1425OrdAlmCod = A1425OrdAlmCod;
               Z1424OrdAIVA = A1424OrdAIVA;
               Z2236OrdTItemCron = A2236OrdTItemCron;
               Z244PrvCod = A244PrvCod;
               Z292OrdConpCod = A292OrdConpCod;
               Z291OrdCosCod = A291OrdCosCod;
               Z290OrdMonCod = A290OrdMonCod;
            }
         }
         if ( GX_JID == -9 )
         {
            Z289OrdCod = A289OrdCod;
            Z293OrdFec = A293OrdFec;
            Z1458OrdPorDscto = A1458OrdPorDscto;
            Z1459OrdPorIva = A1459OrdPorIva;
            Z1454OrdObs = A1454OrdObs;
            Z1453OrdItem = A1453OrdItem;
            Z1462OrdSts = A1462OrdSts;
            Z1469OrdUsuC = A1469OrdUsuC;
            Z1451OrdFecC = A1451OrdFecC;
            Z1470OrdUsuM = A1470OrdUsuM;
            Z1452OrdFecM = A1452OrdFecM;
            Z1426OrdAut = A1426OrdAut;
            Z1467OrdUsuAut = A1467OrdUsuAut;
            Z1449OrdFecAut = A1449OrdFecAut;
            Z1468OrdUsuAut1 = A1468OrdUsuAut1;
            Z1450OrdFecAut1 = A1450OrdFecAut1;
            Z1461OrdRequ = A1461OrdRequ;
            Z1448OrdEntrega = A1448OrdEntrega;
            Z1466OrdTip = A1466OrdTip;
            Z1425OrdAlmCod = A1425OrdAlmCod;
            Z1424OrdAIVA = A1424OrdAIVA;
            Z2236OrdTItemCron = A2236OrdTItemCron;
            Z244PrvCod = A244PrvCod;
            Z292OrdConpCod = A292OrdConpCod;
            Z291OrdCosCod = A291OrdCosCod;
            Z290OrdMonCod = A290OrdMonCod;
            Z1463OrdSubAfecto = A1463OrdSubAfecto;
            Z1464OrdSubInafecto = A1464OrdSubInafecto;
            Z298TprvCod = A298TprvCod;
            Z1427OrdConpDsc = A1427OrdConpDsc;
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

      protected void Load3I121( )
      {
         /* Using cursor T003I11 */
         pr_default.execute(7, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound121 = 1;
            A293OrdFec = T003I11_A293OrdFec[0];
            AssignAttri("", false, "A293OrdFec", context.localUtil.Format(A293OrdFec, "99/99/99"));
            A1458OrdPorDscto = T003I11_A1458OrdPorDscto[0];
            AssignAttri("", false, "A1458OrdPorDscto", StringUtil.LTrimStr( A1458OrdPorDscto, 5, 2));
            A1459OrdPorIva = T003I11_A1459OrdPorIva[0];
            AssignAttri("", false, "A1459OrdPorIva", StringUtil.LTrimStr( A1459OrdPorIva, 5, 2));
            A1454OrdObs = T003I11_A1454OrdObs[0];
            AssignAttri("", false, "A1454OrdObs", A1454OrdObs);
            A1453OrdItem = T003I11_A1453OrdItem[0];
            AssignAttri("", false, "A1453OrdItem", StringUtil.LTrimStr( (decimal)(A1453OrdItem), 6, 0));
            A1462OrdSts = T003I11_A1462OrdSts[0];
            AssignAttri("", false, "A1462OrdSts", A1462OrdSts);
            A1469OrdUsuC = T003I11_A1469OrdUsuC[0];
            AssignAttri("", false, "A1469OrdUsuC", A1469OrdUsuC);
            A1451OrdFecC = T003I11_A1451OrdFecC[0];
            AssignAttri("", false, "A1451OrdFecC", context.localUtil.TToC( A1451OrdFecC, 8, 5, 0, 3, "/", ":", " "));
            A1470OrdUsuM = T003I11_A1470OrdUsuM[0];
            AssignAttri("", false, "A1470OrdUsuM", A1470OrdUsuM);
            A1452OrdFecM = T003I11_A1452OrdFecM[0];
            AssignAttri("", false, "A1452OrdFecM", context.localUtil.TToC( A1452OrdFecM, 8, 5, 0, 3, "/", ":", " "));
            A1426OrdAut = T003I11_A1426OrdAut[0];
            AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            A1467OrdUsuAut = T003I11_A1467OrdUsuAut[0];
            AssignAttri("", false, "A1467OrdUsuAut", A1467OrdUsuAut);
            A1449OrdFecAut = T003I11_A1449OrdFecAut[0];
            AssignAttri("", false, "A1449OrdFecAut", context.localUtil.Format(A1449OrdFecAut, "99/99/99"));
            A1468OrdUsuAut1 = T003I11_A1468OrdUsuAut1[0];
            A1450OrdFecAut1 = T003I11_A1450OrdFecAut1[0];
            A1461OrdRequ = T003I11_A1461OrdRequ[0];
            AssignAttri("", false, "A1461OrdRequ", A1461OrdRequ);
            A1448OrdEntrega = T003I11_A1448OrdEntrega[0];
            AssignAttri("", false, "A1448OrdEntrega", A1448OrdEntrega);
            A1466OrdTip = T003I11_A1466OrdTip[0];
            AssignAttri("", false, "A1466OrdTip", A1466OrdTip);
            A1425OrdAlmCod = T003I11_A1425OrdAlmCod[0];
            n1425OrdAlmCod = T003I11_n1425OrdAlmCod[0];
            AssignAttri("", false, "A1425OrdAlmCod", StringUtil.LTrimStr( (decimal)(A1425OrdAlmCod), 6, 0));
            A1424OrdAIVA = T003I11_A1424OrdAIVA[0];
            A1427OrdConpDsc = T003I11_A1427OrdConpDsc[0];
            A2236OrdTItemCron = T003I11_A2236OrdTItemCron[0];
            A244PrvCod = T003I11_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A292OrdConpCod = T003I11_A292OrdConpCod[0];
            AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrimStr( (decimal)(A292OrdConpCod), 6, 0));
            A291OrdCosCod = T003I11_A291OrdCosCod[0];
            n291OrdCosCod = T003I11_n291OrdCosCod[0];
            AssignAttri("", false, "A291OrdCosCod", A291OrdCosCod);
            A290OrdMonCod = T003I11_A290OrdMonCod[0];
            AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrimStr( (decimal)(A290OrdMonCod), 6, 0));
            A298TprvCod = T003I11_A298TprvCod[0];
            A1463OrdSubAfecto = T003I11_A1463OrdSubAfecto[0];
            A1464OrdSubInafecto = T003I11_A1464OrdSubInafecto[0];
            ZM3I121( -9) ;
         }
         pr_default.close(7);
         OnLoadActions3I121( ) ;
      }

      protected void OnLoadActions3I121( )
      {
         A1465OrdSubTotal = (decimal)(A1463OrdSubAfecto+A1464OrdSubInafecto);
         AssignAttri("", false, "A1465OrdSubTotal", StringUtil.LTrimStr( A1465OrdSubTotal, 15, 2));
         A2233OrdDscto = NumberUtil.Round( ((A1465OrdSubTotal)*A1458OrdPorDscto)/ (decimal)(100), 2);
         AssignAttri("", false, "A2233OrdDscto", StringUtil.LTrimStr( A2233OrdDscto, 15, 2));
         A2234OrdIva = NumberUtil.Round( ((A1463OrdSubAfecto-A2233OrdDscto)*A1459OrdPorIva)/ (decimal)(100), 2);
         AssignAttri("", false, "A2234OrdIva", StringUtil.LTrimStr( A2234OrdIva, 15, 2));
         A2235OrdTot = (decimal)((A1465OrdSubTotal+A2234OrdIva)-A2233OrdDscto);
         AssignAttri("", false, "A2235OrdTot", StringUtil.LTrimStr( A2235OrdTot, 15, 2));
      }

      protected void CheckExtendedTable3I121( )
      {
         nIsDirty_121 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003I9 */
         pr_default.execute(6, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A1463OrdSubAfecto = T003I9_A1463OrdSubAfecto[0];
            A1464OrdSubInafecto = T003I9_A1464OrdSubInafecto[0];
         }
         else
         {
            nIsDirty_121 = 1;
            A1463OrdSubAfecto = 0;
            AssignAttri("", false, "A1463OrdSubAfecto", StringUtil.LTrimStr( A1463OrdSubAfecto, 15, 2));
            nIsDirty_121 = 1;
            A1464OrdSubInafecto = 0;
            AssignAttri("", false, "A1464OrdSubInafecto", StringUtil.LTrimStr( A1464OrdSubInafecto, 15, 2));
         }
         pr_default.close(6);
         nIsDirty_121 = 1;
         A1465OrdSubTotal = (decimal)(A1463OrdSubAfecto+A1464OrdSubInafecto);
         AssignAttri("", false, "A1465OrdSubTotal", StringUtil.LTrimStr( A1465OrdSubTotal, 15, 2));
         nIsDirty_121 = 1;
         A2233OrdDscto = NumberUtil.Round( ((A1465OrdSubTotal)*A1458OrdPorDscto)/ (decimal)(100), 2);
         AssignAttri("", false, "A2233OrdDscto", StringUtil.LTrimStr( A2233OrdDscto, 15, 2));
         nIsDirty_121 = 1;
         A2234OrdIva = NumberUtil.Round( ((A1463OrdSubAfecto-A2233OrdDscto)*A1459OrdPorIva)/ (decimal)(100), 2);
         AssignAttri("", false, "A2234OrdIva", StringUtil.LTrimStr( A2234OrdIva, 15, 2));
         nIsDirty_121 = 1;
         A2235OrdTot = (decimal)((A1465OrdSubTotal+A2234OrdIva)-A2233OrdDscto);
         AssignAttri("", false, "A2235OrdTot", StringUtil.LTrimStr( A2235OrdTot, 15, 2));
         /* Using cursor T003I4 */
         pr_default.execute(2, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A298TprvCod = T003I4_A298TprvCod[0];
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A293OrdFec) || ( DateTimeUtil.ResetTime ( A293OrdFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "ORDFEC");
            AnyError = 1;
            GX_FocusControl = edtOrdFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003I5 */
         pr_default.execute(3, new Object[] {A292OrdConpCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "ORDCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1427OrdConpDsc = T003I5_A1427OrdConpDsc[0];
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1451OrdFecC) || ( A1451OrdFecC >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Creación fuera de rango", "OutOfRange", 1, "ORDFECC");
            AnyError = 1;
            GX_FocusControl = edtOrdFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1452OrdFecM) || ( A1452OrdFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Modificación fuera de rango", "OutOfRange", 1, "ORDFECM");
            AnyError = 1;
            GX_FocusControl = edtOrdFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1449OrdFecAut) || ( DateTimeUtil.ResetTime ( A1449OrdFecAut ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Autorización fuera de rango", "OutOfRange", 1, "ORDFECAUT");
            AnyError = 1;
            GX_FocusControl = edtOrdFecAut_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003I6 */
         pr_default.execute(4, new Object[] {n291OrdCosCod, A291OrdCosCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A291OrdCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Ordenes C.Costo'.", "ForeignKeyNotFound", 1, "ORDCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T003I7 */
         pr_default.execute(5, new Object[] {A290OrdMonCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "ORDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors3I121( )
      {
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( string A289OrdCod )
      {
         /* Using cursor T003I13 */
         pr_default.execute(8, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A1463OrdSubAfecto = T003I13_A1463OrdSubAfecto[0];
            A1464OrdSubInafecto = T003I13_A1464OrdSubInafecto[0];
         }
         else
         {
            A1463OrdSubAfecto = 0;
            AssignAttri("", false, "A1463OrdSubAfecto", StringUtil.LTrimStr( A1463OrdSubAfecto, 15, 2));
            A1464OrdSubInafecto = 0;
            AssignAttri("", false, "A1464OrdSubInafecto", StringUtil.LTrimStr( A1464OrdSubInafecto, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1463OrdSubAfecto, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1464OrdSubInafecto, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_10( string A244PrvCod )
      {
         /* Using cursor T003I14 */
         pr_default.execute(9, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A298TprvCod = T003I14_A298TprvCod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_11( int A292OrdConpCod )
      {
         /* Using cursor T003I15 */
         pr_default.execute(10, new Object[] {A292OrdConpCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "ORDCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1427OrdConpDsc = T003I15_A1427OrdConpDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1427OrdConpDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_12( string A291OrdCosCod )
      {
         /* Using cursor T003I16 */
         pr_default.execute(11, new Object[] {n291OrdCosCod, A291OrdCosCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A291OrdCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Ordenes C.Costo'.", "ForeignKeyNotFound", 1, "ORDCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_13( int A290OrdMonCod )
      {
         /* Using cursor T003I17 */
         pr_default.execute(12, new Object[] {A290OrdMonCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "ORDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdMonCod_Internalname;
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

      protected void GetKey3I121( )
      {
         /* Using cursor T003I18 */
         pr_default.execute(13, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound121 = 1;
         }
         else
         {
            RcdFound121 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003I3 */
         pr_default.execute(1, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3I121( 9) ;
            RcdFound121 = 1;
            A289OrdCod = T003I3_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A293OrdFec = T003I3_A293OrdFec[0];
            AssignAttri("", false, "A293OrdFec", context.localUtil.Format(A293OrdFec, "99/99/99"));
            A1458OrdPorDscto = T003I3_A1458OrdPorDscto[0];
            AssignAttri("", false, "A1458OrdPorDscto", StringUtil.LTrimStr( A1458OrdPorDscto, 5, 2));
            A1459OrdPorIva = T003I3_A1459OrdPorIva[0];
            AssignAttri("", false, "A1459OrdPorIva", StringUtil.LTrimStr( A1459OrdPorIva, 5, 2));
            A1454OrdObs = T003I3_A1454OrdObs[0];
            AssignAttri("", false, "A1454OrdObs", A1454OrdObs);
            A1453OrdItem = T003I3_A1453OrdItem[0];
            AssignAttri("", false, "A1453OrdItem", StringUtil.LTrimStr( (decimal)(A1453OrdItem), 6, 0));
            A1462OrdSts = T003I3_A1462OrdSts[0];
            AssignAttri("", false, "A1462OrdSts", A1462OrdSts);
            A1469OrdUsuC = T003I3_A1469OrdUsuC[0];
            AssignAttri("", false, "A1469OrdUsuC", A1469OrdUsuC);
            A1451OrdFecC = T003I3_A1451OrdFecC[0];
            AssignAttri("", false, "A1451OrdFecC", context.localUtil.TToC( A1451OrdFecC, 8, 5, 0, 3, "/", ":", " "));
            A1470OrdUsuM = T003I3_A1470OrdUsuM[0];
            AssignAttri("", false, "A1470OrdUsuM", A1470OrdUsuM);
            A1452OrdFecM = T003I3_A1452OrdFecM[0];
            AssignAttri("", false, "A1452OrdFecM", context.localUtil.TToC( A1452OrdFecM, 8, 5, 0, 3, "/", ":", " "));
            A1426OrdAut = T003I3_A1426OrdAut[0];
            AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
            A1467OrdUsuAut = T003I3_A1467OrdUsuAut[0];
            AssignAttri("", false, "A1467OrdUsuAut", A1467OrdUsuAut);
            A1449OrdFecAut = T003I3_A1449OrdFecAut[0];
            AssignAttri("", false, "A1449OrdFecAut", context.localUtil.Format(A1449OrdFecAut, "99/99/99"));
            A1468OrdUsuAut1 = T003I3_A1468OrdUsuAut1[0];
            A1450OrdFecAut1 = T003I3_A1450OrdFecAut1[0];
            A1461OrdRequ = T003I3_A1461OrdRequ[0];
            AssignAttri("", false, "A1461OrdRequ", A1461OrdRequ);
            A1448OrdEntrega = T003I3_A1448OrdEntrega[0];
            AssignAttri("", false, "A1448OrdEntrega", A1448OrdEntrega);
            A1466OrdTip = T003I3_A1466OrdTip[0];
            AssignAttri("", false, "A1466OrdTip", A1466OrdTip);
            A1425OrdAlmCod = T003I3_A1425OrdAlmCod[0];
            n1425OrdAlmCod = T003I3_n1425OrdAlmCod[0];
            AssignAttri("", false, "A1425OrdAlmCod", StringUtil.LTrimStr( (decimal)(A1425OrdAlmCod), 6, 0));
            A1424OrdAIVA = T003I3_A1424OrdAIVA[0];
            A2236OrdTItemCron = T003I3_A2236OrdTItemCron[0];
            A244PrvCod = T003I3_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A292OrdConpCod = T003I3_A292OrdConpCod[0];
            AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrimStr( (decimal)(A292OrdConpCod), 6, 0));
            A291OrdCosCod = T003I3_A291OrdCosCod[0];
            n291OrdCosCod = T003I3_n291OrdCosCod[0];
            AssignAttri("", false, "A291OrdCosCod", A291OrdCosCod);
            A290OrdMonCod = T003I3_A290OrdMonCod[0];
            AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrimStr( (decimal)(A290OrdMonCod), 6, 0));
            Z289OrdCod = A289OrdCod;
            sMode121 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3I121( ) ;
            if ( AnyError == 1 )
            {
               RcdFound121 = 0;
               InitializeNonKey3I121( ) ;
            }
            Gx_mode = sMode121;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound121 = 0;
            InitializeNonKey3I121( ) ;
            sMode121 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode121;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3I121( ) ;
         if ( RcdFound121 == 0 )
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
         RcdFound121 = 0;
         /* Using cursor T003I19 */
         pr_default.execute(14, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T003I19_A289OrdCod[0], A289OrdCod) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T003I19_A289OrdCod[0], A289OrdCod) > 0 ) ) )
            {
               A289OrdCod = T003I19_A289OrdCod[0];
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               RcdFound121 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound121 = 0;
         /* Using cursor T003I20 */
         pr_default.execute(15, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T003I20_A289OrdCod[0], A289OrdCod) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T003I20_A289OrdCod[0], A289OrdCod) < 0 ) ) )
            {
               A289OrdCod = T003I20_A289OrdCod[0];
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               RcdFound121 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3I121( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3I121( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound121 == 1 )
            {
               if ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 )
               {
                  A289OrdCod = Z289OrdCod;
                  AssignAttri("", false, "A289OrdCod", A289OrdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ORDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3I121( ) ;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3I121( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtOrdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtOrdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3I121( ) ;
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
         if ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 )
         {
            A289OrdCod = Z289OrdCod;
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOrdCod_Internalname;
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
         GetKey3I121( ) ;
         if ( RcdFound121 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ORDCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 )
            {
               A289OrdCod = Z289OrdCod;
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ORDCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCod_Internalname;
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
            if ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtOrdCod_Internalname;
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
         context.RollbackDataStores("cporden",pr_default);
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3I0( ) ;
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
         if ( RcdFound121 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3I121( ) ;
         if ( RcdFound121 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3I121( ) ;
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
         if ( RcdFound121 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
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
         if ( RcdFound121 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
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
         ScanStart3I121( ) ;
         if ( RcdFound121 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound121 != 0 )
            {
               ScanNext3I121( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3I121( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3I121( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003I2 */
            pr_default.execute(0, new Object[] {A289OrdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPORDEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z293OrdFec ) != DateTimeUtil.ResetTime ( T003I2_A293OrdFec[0] ) ) || ( Z1458OrdPorDscto != T003I2_A1458OrdPorDscto[0] ) || ( Z1459OrdPorIva != T003I2_A1459OrdPorIva[0] ) || ( Z1453OrdItem != T003I2_A1453OrdItem[0] ) || ( StringUtil.StrCmp(Z1462OrdSts, T003I2_A1462OrdSts[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1469OrdUsuC, T003I2_A1469OrdUsuC[0]) != 0 ) || ( Z1451OrdFecC != T003I2_A1451OrdFecC[0] ) || ( StringUtil.StrCmp(Z1470OrdUsuM, T003I2_A1470OrdUsuM[0]) != 0 ) || ( Z1452OrdFecM != T003I2_A1452OrdFecM[0] ) || ( Z1426OrdAut != T003I2_A1426OrdAut[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1467OrdUsuAut, T003I2_A1467OrdUsuAut[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1449OrdFecAut ) != DateTimeUtil.ResetTime ( T003I2_A1449OrdFecAut[0] ) ) || ( StringUtil.StrCmp(Z1468OrdUsuAut1, T003I2_A1468OrdUsuAut1[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1450OrdFecAut1 ) != DateTimeUtil.ResetTime ( T003I2_A1450OrdFecAut1[0] ) ) || ( StringUtil.StrCmp(Z1461OrdRequ, T003I2_A1461OrdRequ[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1448OrdEntrega, T003I2_A1448OrdEntrega[0]) != 0 ) || ( StringUtil.StrCmp(Z1466OrdTip, T003I2_A1466OrdTip[0]) != 0 ) || ( Z1425OrdAlmCod != T003I2_A1425OrdAlmCod[0] ) || ( Z1424OrdAIVA != T003I2_A1424OrdAIVA[0] ) || ( Z2236OrdTItemCron != T003I2_A2236OrdTItemCron[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z244PrvCod, T003I2_A244PrvCod[0]) != 0 ) || ( Z292OrdConpCod != T003I2_A292OrdConpCod[0] ) || ( StringUtil.StrCmp(Z291OrdCosCod, T003I2_A291OrdCosCod[0]) != 0 ) || ( Z290OrdMonCod != T003I2_A290OrdMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z293OrdFec ) != DateTimeUtil.ResetTime ( T003I2_A293OrdFec[0] ) )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdFec");
                  GXUtil.WriteLogRaw("Old: ",Z293OrdFec);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A293OrdFec[0]);
               }
               if ( Z1458OrdPorDscto != T003I2_A1458OrdPorDscto[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdPorDscto");
                  GXUtil.WriteLogRaw("Old: ",Z1458OrdPorDscto);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1458OrdPorDscto[0]);
               }
               if ( Z1459OrdPorIva != T003I2_A1459OrdPorIva[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdPorIva");
                  GXUtil.WriteLogRaw("Old: ",Z1459OrdPorIva);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1459OrdPorIva[0]);
               }
               if ( Z1453OrdItem != T003I2_A1453OrdItem[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdItem");
                  GXUtil.WriteLogRaw("Old: ",Z1453OrdItem);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1453OrdItem[0]);
               }
               if ( StringUtil.StrCmp(Z1462OrdSts, T003I2_A1462OrdSts[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdSts");
                  GXUtil.WriteLogRaw("Old: ",Z1462OrdSts);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1462OrdSts[0]);
               }
               if ( StringUtil.StrCmp(Z1469OrdUsuC, T003I2_A1469OrdUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z1469OrdUsuC);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1469OrdUsuC[0]);
               }
               if ( Z1451OrdFecC != T003I2_A1451OrdFecC[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdFecC");
                  GXUtil.WriteLogRaw("Old: ",Z1451OrdFecC);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1451OrdFecC[0]);
               }
               if ( StringUtil.StrCmp(Z1470OrdUsuM, T003I2_A1470OrdUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z1470OrdUsuM);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1470OrdUsuM[0]);
               }
               if ( Z1452OrdFecM != T003I2_A1452OrdFecM[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdFecM");
                  GXUtil.WriteLogRaw("Old: ",Z1452OrdFecM);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1452OrdFecM[0]);
               }
               if ( Z1426OrdAut != T003I2_A1426OrdAut[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdAut");
                  GXUtil.WriteLogRaw("Old: ",Z1426OrdAut);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1426OrdAut[0]);
               }
               if ( StringUtil.StrCmp(Z1467OrdUsuAut, T003I2_A1467OrdUsuAut[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdUsuAut");
                  GXUtil.WriteLogRaw("Old: ",Z1467OrdUsuAut);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1467OrdUsuAut[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1449OrdFecAut ) != DateTimeUtil.ResetTime ( T003I2_A1449OrdFecAut[0] ) )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdFecAut");
                  GXUtil.WriteLogRaw("Old: ",Z1449OrdFecAut);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1449OrdFecAut[0]);
               }
               if ( StringUtil.StrCmp(Z1468OrdUsuAut1, T003I2_A1468OrdUsuAut1[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdUsuAut1");
                  GXUtil.WriteLogRaw("Old: ",Z1468OrdUsuAut1);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1468OrdUsuAut1[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1450OrdFecAut1 ) != DateTimeUtil.ResetTime ( T003I2_A1450OrdFecAut1[0] ) )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdFecAut1");
                  GXUtil.WriteLogRaw("Old: ",Z1450OrdFecAut1);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1450OrdFecAut1[0]);
               }
               if ( StringUtil.StrCmp(Z1461OrdRequ, T003I2_A1461OrdRequ[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdRequ");
                  GXUtil.WriteLogRaw("Old: ",Z1461OrdRequ);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1461OrdRequ[0]);
               }
               if ( StringUtil.StrCmp(Z1448OrdEntrega, T003I2_A1448OrdEntrega[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdEntrega");
                  GXUtil.WriteLogRaw("Old: ",Z1448OrdEntrega);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1448OrdEntrega[0]);
               }
               if ( StringUtil.StrCmp(Z1466OrdTip, T003I2_A1466OrdTip[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdTip");
                  GXUtil.WriteLogRaw("Old: ",Z1466OrdTip);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1466OrdTip[0]);
               }
               if ( Z1425OrdAlmCod != T003I2_A1425OrdAlmCod[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdAlmCod");
                  GXUtil.WriteLogRaw("Old: ",Z1425OrdAlmCod);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1425OrdAlmCod[0]);
               }
               if ( Z1424OrdAIVA != T003I2_A1424OrdAIVA[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdAIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1424OrdAIVA);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A1424OrdAIVA[0]);
               }
               if ( Z2236OrdTItemCron != T003I2_A2236OrdTItemCron[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdTItemCron");
                  GXUtil.WriteLogRaw("Old: ",Z2236OrdTItemCron);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A2236OrdTItemCron[0]);
               }
               if ( StringUtil.StrCmp(Z244PrvCod, T003I2_A244PrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"PrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z244PrvCod);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A244PrvCod[0]);
               }
               if ( Z292OrdConpCod != T003I2_A292OrdConpCod[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdConpCod");
                  GXUtil.WriteLogRaw("Old: ",Z292OrdConpCod);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A292OrdConpCod[0]);
               }
               if ( StringUtil.StrCmp(Z291OrdCosCod, T003I2_A291OrdCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z291OrdCosCod);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A291OrdCosCod[0]);
               }
               if ( Z290OrdMonCod != T003I2_A290OrdMonCod[0] )
               {
                  GXUtil.WriteLog("cporden:[seudo value changed for attri]"+"OrdMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z290OrdMonCod);
                  GXUtil.WriteLogRaw("Current: ",T003I2_A290OrdMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPORDEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3I121( )
      {
         BeforeValidate3I121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3I121( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3I121( 0) ;
            CheckOptimisticConcurrency3I121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3I121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3I121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003I21 */
                     pr_default.execute(16, new Object[] {A289OrdCod, A293OrdFec, A1458OrdPorDscto, A1459OrdPorIva, A1454OrdObs, A1453OrdItem, A1462OrdSts, A1469OrdUsuC, A1451OrdFecC, A1470OrdUsuM, A1452OrdFecM, A1426OrdAut, A1467OrdUsuAut, A1449OrdFecAut, A1468OrdUsuAut1, A1450OrdFecAut1, A1461OrdRequ, A1448OrdEntrega, A1466OrdTip, n1425OrdAlmCod, A1425OrdAlmCod, A1424OrdAIVA, A2236OrdTItemCron, A244PrvCod, A292OrdConpCod, n291OrdCosCod, A291OrdCosCod, A290OrdMonCod});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CPORDEN");
                     if ( (pr_default.getStatus(16) == 1) )
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
                           ResetCaption3I0( ) ;
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
               Load3I121( ) ;
            }
            EndLevel3I121( ) ;
         }
         CloseExtendedTableCursors3I121( ) ;
      }

      protected void Update3I121( )
      {
         BeforeValidate3I121( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3I121( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3I121( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3I121( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3I121( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003I22 */
                     pr_default.execute(17, new Object[] {A293OrdFec, A1458OrdPorDscto, A1459OrdPorIva, A1454OrdObs, A1453OrdItem, A1462OrdSts, A1469OrdUsuC, A1451OrdFecC, A1470OrdUsuM, A1452OrdFecM, A1426OrdAut, A1467OrdUsuAut, A1449OrdFecAut, A1468OrdUsuAut1, A1450OrdFecAut1, A1461OrdRequ, A1448OrdEntrega, A1466OrdTip, n1425OrdAlmCod, A1425OrdAlmCod, A1424OrdAIVA, A2236OrdTItemCron, A244PrvCod, A292OrdConpCod, n291OrdCosCod, A291OrdCosCod, A290OrdMonCod, A289OrdCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CPORDEN");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPORDEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3I121( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3I0( ) ;
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
            EndLevel3I121( ) ;
         }
         CloseExtendedTableCursors3I121( ) ;
      }

      protected void DeferredUpdate3I121( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3I121( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3I121( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3I121( ) ;
            AfterConfirm3I121( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3I121( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003I23 */
                  pr_default.execute(18, new Object[] {A289OrdCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CPORDEN");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound121 == 0 )
                        {
                           InitAll3I121( ) ;
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
                        ResetCaption3I0( ) ;
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
         sMode121 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3I121( ) ;
         Gx_mode = sMode121;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3I121( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003I25 */
            pr_default.execute(19, new Object[] {A289OrdCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A1463OrdSubAfecto = T003I25_A1463OrdSubAfecto[0];
               A1464OrdSubInafecto = T003I25_A1464OrdSubInafecto[0];
            }
            else
            {
               A1463OrdSubAfecto = 0;
               AssignAttri("", false, "A1463OrdSubAfecto", StringUtil.LTrimStr( A1463OrdSubAfecto, 15, 2));
               A1464OrdSubInafecto = 0;
               AssignAttri("", false, "A1464OrdSubInafecto", StringUtil.LTrimStr( A1464OrdSubInafecto, 15, 2));
            }
            pr_default.close(19);
            A1465OrdSubTotal = (decimal)(A1463OrdSubAfecto+A1464OrdSubInafecto);
            AssignAttri("", false, "A1465OrdSubTotal", StringUtil.LTrimStr( A1465OrdSubTotal, 15, 2));
            /* Using cursor T003I26 */
            pr_default.execute(20, new Object[] {A244PrvCod});
            A298TprvCod = T003I26_A298TprvCod[0];
            pr_default.close(20);
            /* Using cursor T003I27 */
            pr_default.execute(21, new Object[] {A292OrdConpCod});
            A1427OrdConpDsc = T003I27_A1427OrdConpDsc[0];
            pr_default.close(21);
            A2233OrdDscto = NumberUtil.Round( ((A1465OrdSubTotal)*A1458OrdPorDscto)/ (decimal)(100), 2);
            AssignAttri("", false, "A2233OrdDscto", StringUtil.LTrimStr( A2233OrdDscto, 15, 2));
            A2234OrdIva = NumberUtil.Round( ((A1463OrdSubAfecto-A2233OrdDscto)*A1459OrdPorIva)/ (decimal)(100), 2);
            AssignAttri("", false, "A2234OrdIva", StringUtil.LTrimStr( A2234OrdIva, 15, 2));
            A2235OrdTot = (decimal)((A1465OrdSubTotal+A2234OrdIva)-A2233OrdDscto);
            AssignAttri("", false, "A2235OrdTot", StringUtil.LTrimStr( A2235OrdTot, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003I28 */
            pr_default.execute(22, new Object[] {A289OrdCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Orden de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T003I29 */
            pr_default.execute(23, new Object[] {A289OrdCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel3I121( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3I121( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            context.CommitDataStores("cporden",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            context.RollbackDataStores("cporden",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3I121( )
      {
         /* Using cursor T003I30 */
         pr_default.execute(24);
         RcdFound121 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound121 = 1;
            A289OrdCod = T003I30_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3I121( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound121 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound121 = 1;
            A289OrdCod = T003I30_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
         }
      }

      protected void ScanEnd3I121( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm3I121( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3I121( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3I121( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3I121( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3I121( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3I121( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3I121( )
      {
         edtOrdCod_Enabled = 0;
         AssignProp("", false, edtOrdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCod_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtOrdFec_Enabled = 0;
         AssignProp("", false, edtOrdFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdFec_Enabled), 5, 0), true);
         edtOrdConpCod_Enabled = 0;
         AssignProp("", false, edtOrdConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdConpCod_Enabled), 5, 0), true);
         edtOrdPorDscto_Enabled = 0;
         AssignProp("", false, edtOrdPorDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdPorDscto_Enabled), 5, 0), true);
         edtOrdPorIva_Enabled = 0;
         AssignProp("", false, edtOrdPorIva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdPorIva_Enabled), 5, 0), true);
         edtOrdObs_Enabled = 0;
         AssignProp("", false, edtOrdObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdObs_Enabled), 5, 0), true);
         edtOrdItem_Enabled = 0;
         AssignProp("", false, edtOrdItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdItem_Enabled), 5, 0), true);
         edtOrdSts_Enabled = 0;
         AssignProp("", false, edtOrdSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdSts_Enabled), 5, 0), true);
         edtOrdUsuC_Enabled = 0;
         AssignProp("", false, edtOrdUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdUsuC_Enabled), 5, 0), true);
         edtOrdFecC_Enabled = 0;
         AssignProp("", false, edtOrdFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdFecC_Enabled), 5, 0), true);
         edtOrdUsuM_Enabled = 0;
         AssignProp("", false, edtOrdUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdUsuM_Enabled), 5, 0), true);
         edtOrdFecM_Enabled = 0;
         AssignProp("", false, edtOrdFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdFecM_Enabled), 5, 0), true);
         edtOrdAut_Enabled = 0;
         AssignProp("", false, edtOrdAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdAut_Enabled), 5, 0), true);
         edtOrdUsuAut_Enabled = 0;
         AssignProp("", false, edtOrdUsuAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdUsuAut_Enabled), 5, 0), true);
         edtOrdFecAut_Enabled = 0;
         AssignProp("", false, edtOrdFecAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdFecAut_Enabled), 5, 0), true);
         edtOrdCosCod_Enabled = 0;
         AssignProp("", false, edtOrdCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCosCod_Enabled), 5, 0), true);
         edtOrdRequ_Enabled = 0;
         AssignProp("", false, edtOrdRequ_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdRequ_Enabled), 5, 0), true);
         edtOrdEntrega_Enabled = 0;
         AssignProp("", false, edtOrdEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdEntrega_Enabled), 5, 0), true);
         edtOrdMonCod_Enabled = 0;
         AssignProp("", false, edtOrdMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdMonCod_Enabled), 5, 0), true);
         edtOrdTip_Enabled = 0;
         AssignProp("", false, edtOrdTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdTip_Enabled), 5, 0), true);
         edtOrdAlmCod_Enabled = 0;
         AssignProp("", false, edtOrdAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdAlmCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3I121( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025188", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cporden.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CPORDEN");
         forbiddenHiddens.Add("OrdUsuAut1", StringUtil.RTrim( context.localUtil.Format( A1468OrdUsuAut1, "")));
         forbiddenHiddens.Add("OrdFecAut1", context.localUtil.Format(A1450OrdFecAut1, "99/99/99"));
         forbiddenHiddens.Add("OrdAIVA", context.localUtil.Format( (decimal)(A1424OrdAIVA), "9"));
         forbiddenHiddens.Add("OrdTItemCron", context.localUtil.Format( (decimal)(A2236OrdTItemCron), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cporden:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z289OrdCod", StringUtil.RTrim( Z289OrdCod));
         GxWebStd.gx_hidden_field( context, "Z293OrdFec", context.localUtil.DToC( Z293OrdFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1458OrdPorDscto", StringUtil.LTrim( StringUtil.NToC( Z1458OrdPorDscto, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1459OrdPorIva", StringUtil.LTrim( StringUtil.NToC( Z1459OrdPorIva, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1453OrdItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1453OrdItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1462OrdSts", StringUtil.RTrim( Z1462OrdSts));
         GxWebStd.gx_hidden_field( context, "Z1469OrdUsuC", StringUtil.RTrim( Z1469OrdUsuC));
         GxWebStd.gx_hidden_field( context, "Z1451OrdFecC", context.localUtil.TToC( Z1451OrdFecC, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1470OrdUsuM", StringUtil.RTrim( Z1470OrdUsuM));
         GxWebStd.gx_hidden_field( context, "Z1452OrdFecM", context.localUtil.TToC( Z1452OrdFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1426OrdAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1426OrdAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1467OrdUsuAut", StringUtil.RTrim( Z1467OrdUsuAut));
         GxWebStd.gx_hidden_field( context, "Z1449OrdFecAut", context.localUtil.DToC( Z1449OrdFecAut, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1468OrdUsuAut1", StringUtil.RTrim( Z1468OrdUsuAut1));
         GxWebStd.gx_hidden_field( context, "Z1450OrdFecAut1", context.localUtil.DToC( Z1450OrdFecAut1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1461OrdRequ", StringUtil.RTrim( Z1461OrdRequ));
         GxWebStd.gx_hidden_field( context, "Z1448OrdEntrega", StringUtil.RTrim( Z1448OrdEntrega));
         GxWebStd.gx_hidden_field( context, "Z1466OrdTip", Z1466OrdTip);
         GxWebStd.gx_hidden_field( context, "Z1425OrdAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1425OrdAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1424OrdAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1424OrdAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2236OrdTItemCron", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2236OrdTItemCron), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z292OrdConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z292OrdConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z291OrdCosCod", StringUtil.RTrim( Z291OrdCosCod));
         GxWebStd.gx_hidden_field( context, "Z290OrdMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290OrdMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "ORDSUBTOTAL", StringUtil.LTrim( StringUtil.NToC( A1465OrdSubTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDDSCTO", StringUtil.LTrim( StringUtil.NToC( A2233OrdDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDSUBAFECTO", StringUtil.LTrim( StringUtil.NToC( A1463OrdSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDIVA", StringUtil.LTrim( StringUtil.NToC( A2234OrdIva, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDSUBINAFECTO", StringUtil.LTrim( StringUtil.NToC( A1464OrdSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDTOT", StringUtil.LTrim( StringUtil.NToC( A2235OrdTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDUSUAUT1", StringUtil.RTrim( A1468OrdUsuAut1));
         GxWebStd.gx_hidden_field( context, "ORDFECAUT1", context.localUtil.DToC( A1450OrdFecAut1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "ORDAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1424OrdAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDTITEMCRON", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2236OrdTItemCron), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TPRVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ORDCONPDSC", StringUtil.RTrim( A1427OrdConpDsc));
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
         return formatLink("cporden.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPORDEN" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ordenes de Compra - Cabecera" ;
      }

      protected void InitializeNonKey3I121( )
      {
         A2235OrdTot = 0;
         AssignAttri("", false, "A2235OrdTot", StringUtil.LTrimStr( A2235OrdTot, 15, 2));
         A1465OrdSubTotal = 0;
         AssignAttri("", false, "A1465OrdSubTotal", StringUtil.LTrimStr( A1465OrdSubTotal, 15, 2));
         A2234OrdIva = 0;
         AssignAttri("", false, "A2234OrdIva", StringUtil.LTrimStr( A2234OrdIva, 15, 2));
         A2233OrdDscto = 0;
         AssignAttri("", false, "A2233OrdDscto", StringUtil.LTrimStr( A2233OrdDscto, 15, 2));
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         A293OrdFec = DateTime.MinValue;
         AssignAttri("", false, "A293OrdFec", context.localUtil.Format(A293OrdFec, "99/99/99"));
         A292OrdConpCod = 0;
         AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrimStr( (decimal)(A292OrdConpCod), 6, 0));
         A1458OrdPorDscto = 0;
         AssignAttri("", false, "A1458OrdPorDscto", StringUtil.LTrimStr( A1458OrdPorDscto, 5, 2));
         A1459OrdPorIva = 0;
         AssignAttri("", false, "A1459OrdPorIva", StringUtil.LTrimStr( A1459OrdPorIva, 5, 2));
         A1454OrdObs = "";
         AssignAttri("", false, "A1454OrdObs", A1454OrdObs);
         A1453OrdItem = 0;
         AssignAttri("", false, "A1453OrdItem", StringUtil.LTrimStr( (decimal)(A1453OrdItem), 6, 0));
         A1462OrdSts = "";
         AssignAttri("", false, "A1462OrdSts", A1462OrdSts);
         A1469OrdUsuC = "";
         AssignAttri("", false, "A1469OrdUsuC", A1469OrdUsuC);
         A1451OrdFecC = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1451OrdFecC", context.localUtil.TToC( A1451OrdFecC, 8, 5, 0, 3, "/", ":", " "));
         A1470OrdUsuM = "";
         AssignAttri("", false, "A1470OrdUsuM", A1470OrdUsuM);
         A1452OrdFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1452OrdFecM", context.localUtil.TToC( A1452OrdFecM, 8, 5, 0, 3, "/", ":", " "));
         A1426OrdAut = 0;
         AssignAttri("", false, "A1426OrdAut", StringUtil.Str( (decimal)(A1426OrdAut), 1, 0));
         A1467OrdUsuAut = "";
         AssignAttri("", false, "A1467OrdUsuAut", A1467OrdUsuAut);
         A1449OrdFecAut = DateTime.MinValue;
         AssignAttri("", false, "A1449OrdFecAut", context.localUtil.Format(A1449OrdFecAut, "99/99/99"));
         A1468OrdUsuAut1 = "";
         AssignAttri("", false, "A1468OrdUsuAut1", A1468OrdUsuAut1);
         A1450OrdFecAut1 = DateTime.MinValue;
         AssignAttri("", false, "A1450OrdFecAut1", context.localUtil.Format(A1450OrdFecAut1, "99/99/99"));
         A291OrdCosCod = "";
         n291OrdCosCod = false;
         AssignAttri("", false, "A291OrdCosCod", A291OrdCosCod);
         A1461OrdRequ = "";
         AssignAttri("", false, "A1461OrdRequ", A1461OrdRequ);
         A1448OrdEntrega = "";
         AssignAttri("", false, "A1448OrdEntrega", A1448OrdEntrega);
         A290OrdMonCod = 0;
         AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrimStr( (decimal)(A290OrdMonCod), 6, 0));
         A1466OrdTip = "";
         AssignAttri("", false, "A1466OrdTip", A1466OrdTip);
         A1425OrdAlmCod = 0;
         n1425OrdAlmCod = false;
         AssignAttri("", false, "A1425OrdAlmCod", StringUtil.LTrimStr( (decimal)(A1425OrdAlmCod), 6, 0));
         A1463OrdSubAfecto = 0;
         AssignAttri("", false, "A1463OrdSubAfecto", StringUtil.LTrimStr( A1463OrdSubAfecto, 15, 2));
         A1464OrdSubInafecto = 0;
         AssignAttri("", false, "A1464OrdSubInafecto", StringUtil.LTrimStr( A1464OrdSubInafecto, 15, 2));
         A1424OrdAIVA = 0;
         AssignAttri("", false, "A1424OrdAIVA", StringUtil.Str( (decimal)(A1424OrdAIVA), 1, 0));
         A1427OrdConpDsc = "";
         AssignAttri("", false, "A1427OrdConpDsc", A1427OrdConpDsc);
         A2236OrdTItemCron = 0;
         AssignAttri("", false, "A2236OrdTItemCron", StringUtil.LTrimStr( (decimal)(A2236OrdTItemCron), 6, 0));
         A298TprvCod = 0;
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         Z293OrdFec = DateTime.MinValue;
         Z1458OrdPorDscto = 0;
         Z1459OrdPorIva = 0;
         Z1453OrdItem = 0;
         Z1462OrdSts = "";
         Z1469OrdUsuC = "";
         Z1451OrdFecC = (DateTime)(DateTime.MinValue);
         Z1470OrdUsuM = "";
         Z1452OrdFecM = (DateTime)(DateTime.MinValue);
         Z1426OrdAut = 0;
         Z1467OrdUsuAut = "";
         Z1449OrdFecAut = DateTime.MinValue;
         Z1468OrdUsuAut1 = "";
         Z1450OrdFecAut1 = DateTime.MinValue;
         Z1461OrdRequ = "";
         Z1448OrdEntrega = "";
         Z1466OrdTip = "";
         Z1425OrdAlmCod = 0;
         Z1424OrdAIVA = 0;
         Z2236OrdTItemCron = 0;
         Z244PrvCod = "";
         Z292OrdConpCod = 0;
         Z291OrdCosCod = "";
         Z290OrdMonCod = 0;
      }

      protected void InitAll3I121( )
      {
         A289OrdCod = "";
         AssignAttri("", false, "A289OrdCod", A289OrdCod);
         InitializeNonKey3I121( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251834", true, true);
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
         context.AddJavascriptSource("cporden.js", "?202281810251834", false, true);
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
         edtOrdCod_Internalname = "ORDCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPrvCod_Internalname = "PRVCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtOrdFec_Internalname = "ORDFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtOrdConpCod_Internalname = "ORDCONPCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtOrdPorDscto_Internalname = "ORDPORDSCTO";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtOrdPorIva_Internalname = "ORDPORIVA";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtOrdObs_Internalname = "ORDOBS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtOrdItem_Internalname = "ORDITEM";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtOrdSts_Internalname = "ORDSTS";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtOrdUsuC_Internalname = "ORDUSUC";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtOrdFecC_Internalname = "ORDFECC";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtOrdUsuM_Internalname = "ORDUSUM";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtOrdFecM_Internalname = "ORDFECM";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtOrdAut_Internalname = "ORDAUT";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtOrdUsuAut_Internalname = "ORDUSUAUT";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtOrdFecAut_Internalname = "ORDFECAUT";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtOrdCosCod_Internalname = "ORDCOSCOD";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtOrdRequ_Internalname = "ORDREQU";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtOrdEntrega_Internalname = "ORDENTREGA";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtOrdMonCod_Internalname = "ORDMONCOD";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtOrdTip_Internalname = "ORDTIP";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtOrdAlmCod_Internalname = "ORDALMCOD";
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
         Form.Caption = "Ordenes de Compra - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtOrdAlmCod_Jsonclick = "";
         edtOrdAlmCod_Enabled = 1;
         edtOrdTip_Jsonclick = "";
         edtOrdTip_Enabled = 1;
         edtOrdMonCod_Jsonclick = "";
         edtOrdMonCod_Enabled = 1;
         edtOrdEntrega_Jsonclick = "";
         edtOrdEntrega_Enabled = 1;
         edtOrdRequ_Jsonclick = "";
         edtOrdRequ_Enabled = 1;
         edtOrdCosCod_Jsonclick = "";
         edtOrdCosCod_Enabled = 1;
         edtOrdFecAut_Jsonclick = "";
         edtOrdFecAut_Enabled = 1;
         edtOrdUsuAut_Jsonclick = "";
         edtOrdUsuAut_Enabled = 1;
         edtOrdAut_Jsonclick = "";
         edtOrdAut_Enabled = 1;
         edtOrdFecM_Jsonclick = "";
         edtOrdFecM_Enabled = 1;
         edtOrdUsuM_Jsonclick = "";
         edtOrdUsuM_Enabled = 1;
         edtOrdFecC_Jsonclick = "";
         edtOrdFecC_Enabled = 1;
         edtOrdUsuC_Jsonclick = "";
         edtOrdUsuC_Enabled = 1;
         edtOrdSts_Jsonclick = "";
         edtOrdSts_Enabled = 1;
         edtOrdItem_Jsonclick = "";
         edtOrdItem_Enabled = 1;
         edtOrdObs_Enabled = 1;
         edtOrdPorIva_Jsonclick = "";
         edtOrdPorIva_Enabled = 1;
         edtOrdPorDscto_Jsonclick = "";
         edtOrdPorDscto_Enabled = 1;
         edtOrdConpCod_Jsonclick = "";
         edtOrdConpCod_Enabled = 1;
         edtOrdFec_Jsonclick = "";
         edtOrdFec_Enabled = 1;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtOrdCod_Jsonclick = "";
         edtOrdCod_Enabled = 1;
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
         GX_FocusControl = edtPrvCod_Internalname;
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

      public void Valid_Ordcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T003I25 */
         pr_default.execute(19, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A1463OrdSubAfecto = T003I25_A1463OrdSubAfecto[0];
            A1464OrdSubInafecto = T003I25_A1464OrdSubInafecto[0];
         }
         else
         {
            A1463OrdSubAfecto = 0;
            A1464OrdSubInafecto = 0;
         }
         pr_default.close(19);
         A1465OrdSubTotal = (decimal)(A1463OrdSubAfecto+A1464OrdSubInafecto);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A244PrvCod", StringUtil.RTrim( A244PrvCod));
         AssignAttri("", false, "A293OrdFec", context.localUtil.Format(A293OrdFec, "99/99/99"));
         AssignAttri("", false, "A292OrdConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A292OrdConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1458OrdPorDscto", StringUtil.LTrim( StringUtil.NToC( A1458OrdPorDscto, 5, 2, ".", "")));
         AssignAttri("", false, "A1459OrdPorIva", StringUtil.LTrim( StringUtil.NToC( A1459OrdPorIva, 5, 2, ".", "")));
         AssignAttri("", false, "A1454OrdObs", A1454OrdObs);
         AssignAttri("", false, "A1453OrdItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1453OrdItem), 6, 0, ".", "")));
         AssignAttri("", false, "A1462OrdSts", StringUtil.RTrim( A1462OrdSts));
         AssignAttri("", false, "A1469OrdUsuC", StringUtil.RTrim( A1469OrdUsuC));
         AssignAttri("", false, "A1451OrdFecC", context.localUtil.TToC( A1451OrdFecC, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1470OrdUsuM", StringUtil.RTrim( A1470OrdUsuM));
         AssignAttri("", false, "A1452OrdFecM", context.localUtil.TToC( A1452OrdFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1426OrdAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1426OrdAut), 1, 0, ".", "")));
         AssignAttri("", false, "A1467OrdUsuAut", StringUtil.RTrim( A1467OrdUsuAut));
         AssignAttri("", false, "A1449OrdFecAut", context.localUtil.Format(A1449OrdFecAut, "99/99/99"));
         AssignAttri("", false, "A1468OrdUsuAut1", StringUtil.RTrim( A1468OrdUsuAut1));
         AssignAttri("", false, "A1450OrdFecAut1", context.localUtil.Format(A1450OrdFecAut1, "99/99/99"));
         AssignAttri("", false, "A291OrdCosCod", StringUtil.RTrim( A291OrdCosCod));
         AssignAttri("", false, "A1461OrdRequ", StringUtil.RTrim( A1461OrdRequ));
         AssignAttri("", false, "A1448OrdEntrega", StringUtil.RTrim( A1448OrdEntrega));
         AssignAttri("", false, "A290OrdMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290OrdMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1466OrdTip", A1466OrdTip);
         AssignAttri("", false, "A1425OrdAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1425OrdAlmCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1424OrdAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1424OrdAIVA), 1, 0, ".", "")));
         AssignAttri("", false, "A2236OrdTItemCron", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2236OrdTItemCron), 6, 0, ".", "")));
         AssignAttri("", false, "A1463OrdSubAfecto", StringUtil.LTrim( StringUtil.NToC( A1463OrdSubAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1464OrdSubInafecto", StringUtil.LTrim( StringUtil.NToC( A1464OrdSubInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1465OrdSubTotal", StringUtil.LTrim( StringUtil.NToC( A1465OrdSubTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A2233OrdDscto", StringUtil.LTrim( StringUtil.NToC( A2233OrdDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A2234OrdIva", StringUtil.LTrim( StringUtil.NToC( A2234OrdIva, 15, 2, ".", "")));
         AssignAttri("", false, "A2235OrdTot", StringUtil.LTrim( StringUtil.NToC( A2235OrdTot, 15, 2, ".", "")));
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1427OrdConpDsc", StringUtil.RTrim( A1427OrdConpDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z289OrdCod", StringUtil.RTrim( Z289OrdCod));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z293OrdFec", context.localUtil.Format(Z293OrdFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z292OrdConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z292OrdConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1458OrdPorDscto", StringUtil.LTrim( StringUtil.NToC( Z1458OrdPorDscto, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1459OrdPorIva", StringUtil.LTrim( StringUtil.NToC( Z1459OrdPorIva, 5, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1454OrdObs", Z1454OrdObs);
         GxWebStd.gx_hidden_field( context, "Z1453OrdItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1453OrdItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1462OrdSts", StringUtil.RTrim( Z1462OrdSts));
         GxWebStd.gx_hidden_field( context, "Z1469OrdUsuC", StringUtil.RTrim( Z1469OrdUsuC));
         GxWebStd.gx_hidden_field( context, "Z1451OrdFecC", context.localUtil.TToC( Z1451OrdFecC, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1470OrdUsuM", StringUtil.RTrim( Z1470OrdUsuM));
         GxWebStd.gx_hidden_field( context, "Z1452OrdFecM", context.localUtil.TToC( Z1452OrdFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1426OrdAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1426OrdAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1467OrdUsuAut", StringUtil.RTrim( Z1467OrdUsuAut));
         GxWebStd.gx_hidden_field( context, "Z1449OrdFecAut", context.localUtil.Format(Z1449OrdFecAut, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1468OrdUsuAut1", StringUtil.RTrim( Z1468OrdUsuAut1));
         GxWebStd.gx_hidden_field( context, "Z1450OrdFecAut1", context.localUtil.Format(Z1450OrdFecAut1, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z291OrdCosCod", StringUtil.RTrim( Z291OrdCosCod));
         GxWebStd.gx_hidden_field( context, "Z1461OrdRequ", StringUtil.RTrim( Z1461OrdRequ));
         GxWebStd.gx_hidden_field( context, "Z1448OrdEntrega", StringUtil.RTrim( Z1448OrdEntrega));
         GxWebStd.gx_hidden_field( context, "Z290OrdMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290OrdMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1466OrdTip", Z1466OrdTip);
         GxWebStd.gx_hidden_field( context, "Z1425OrdAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1425OrdAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1424OrdAIVA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1424OrdAIVA), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2236OrdTItemCron", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2236OrdTItemCron), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1463OrdSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1463OrdSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1464OrdSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1464OrdSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1465OrdSubTotal", StringUtil.LTrim( StringUtil.NToC( Z1465OrdSubTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2233OrdDscto", StringUtil.LTrim( StringUtil.NToC( Z2233OrdDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2234OrdIva", StringUtil.LTrim( StringUtil.NToC( Z2234OrdIva, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2235OrdTot", StringUtil.LTrim( StringUtil.NToC( Z2235OrdTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1427OrdConpDsc", StringUtil.RTrim( Z1427OrdConpDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prvcod( )
      {
         /* Using cursor T003I26 */
         pr_default.execute(20, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
         }
         A298TprvCod = T003I26_A298TprvCod[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")));
      }

      public void Valid_Ordconpcod( )
      {
         /* Using cursor T003I27 */
         pr_default.execute(21, new Object[] {A292OrdConpCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "ORDCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdConpCod_Internalname;
         }
         A1427OrdConpDsc = T003I27_A1427OrdConpDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1427OrdConpDsc", StringUtil.RTrim( A1427OrdConpDsc));
      }

      public void Valid_Ordcoscod( )
      {
         n291OrdCosCod = false;
         /* Using cursor T003I31 */
         pr_default.execute(25, new Object[] {n291OrdCosCod, A291OrdCosCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A291OrdCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Ordenes C.Costo'.", "ForeignKeyNotFound", 1, "ORDCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtOrdCosCod_Internalname;
            }
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ordmoncod( )
      {
         /* Using cursor T003I32 */
         pr_default.execute(26, new Object[] {A290OrdMonCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "ORDMONCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdMonCod_Internalname;
         }
         pr_default.close(26);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1468OrdUsuAut1',fld:'ORDUSUAUT1',pic:''},{av:'A1450OrdFecAut1',fld:'ORDFECAUT1',pic:''},{av:'A1424OrdAIVA',fld:'ORDAIVA',pic:'9'},{av:'A2236OrdTItemCron',fld:'ORDTITEMCRON',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_ORDCOD","{handler:'Valid_Ordcod',iparms:[{av:'A2236OrdTItemCron',fld:'ORDTITEMCRON',pic:'ZZZZZ9'},{av:'A1424OrdAIVA',fld:'ORDAIVA',pic:'9'},{av:'A1450OrdFecAut1',fld:'ORDFECAUT1',pic:''},{av:'A1468OrdUsuAut1',fld:'ORDUSUAUT1',pic:''},{av:'A289OrdCod',fld:'ORDCOD',pic:''},{av:'A1463OrdSubAfecto',fld:'ORDSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1464OrdSubInafecto',fld:'ORDSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ORDCOD",",oparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A293OrdFec',fld:'ORDFEC',pic:''},{av:'A292OrdConpCod',fld:'ORDCONPCOD',pic:'ZZZZZ9'},{av:'A1458OrdPorDscto',fld:'ORDPORDSCTO',pic:'Z9.99'},{av:'A1459OrdPorIva',fld:'ORDPORIVA',pic:'Z9.99'},{av:'A1454OrdObs',fld:'ORDOBS',pic:''},{av:'A1453OrdItem',fld:'ORDITEM',pic:'ZZZZZ9'},{av:'A1462OrdSts',fld:'ORDSTS',pic:''},{av:'A1469OrdUsuC',fld:'ORDUSUC',pic:''},{av:'A1451OrdFecC',fld:'ORDFECC',pic:'99/99/99 99:99'},{av:'A1470OrdUsuM',fld:'ORDUSUM',pic:''},{av:'A1452OrdFecM',fld:'ORDFECM',pic:'99/99/99 99:99'},{av:'A1426OrdAut',fld:'ORDAUT',pic:'9'},{av:'A1467OrdUsuAut',fld:'ORDUSUAUT',pic:''},{av:'A1449OrdFecAut',fld:'ORDFECAUT',pic:''},{av:'A1468OrdUsuAut1',fld:'ORDUSUAUT1',pic:''},{av:'A1450OrdFecAut1',fld:'ORDFECAUT1',pic:''},{av:'A291OrdCosCod',fld:'ORDCOSCOD',pic:''},{av:'A1461OrdRequ',fld:'ORDREQU',pic:''},{av:'A1448OrdEntrega',fld:'ORDENTREGA',pic:''},{av:'A290OrdMonCod',fld:'ORDMONCOD',pic:'ZZZZZ9'},{av:'A1466OrdTip',fld:'ORDTIP',pic:''},{av:'A1425OrdAlmCod',fld:'ORDALMCOD',pic:'ZZZZZ9'},{av:'A1424OrdAIVA',fld:'ORDAIVA',pic:'9'},{av:'A2236OrdTItemCron',fld:'ORDTITEMCRON',pic:'ZZZZZ9'},{av:'A1463OrdSubAfecto',fld:'ORDSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1464OrdSubInafecto',fld:'ORDSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1465OrdSubTotal',fld:'ORDSUBTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2233OrdDscto',fld:'ORDDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2234OrdIva',fld:'ORDIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2235OrdTot',fld:'ORDTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'},{av:'A1427OrdConpDsc',fld:'ORDCONPDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z289OrdCod'},{av:'Z244PrvCod'},{av:'Z293OrdFec'},{av:'Z292OrdConpCod'},{av:'Z1458OrdPorDscto'},{av:'Z1459OrdPorIva'},{av:'Z1454OrdObs'},{av:'Z1453OrdItem'},{av:'Z1462OrdSts'},{av:'Z1469OrdUsuC'},{av:'Z1451OrdFecC'},{av:'Z1470OrdUsuM'},{av:'Z1452OrdFecM'},{av:'Z1426OrdAut'},{av:'Z1467OrdUsuAut'},{av:'Z1449OrdFecAut'},{av:'Z1468OrdUsuAut1'},{av:'Z1450OrdFecAut1'},{av:'Z291OrdCosCod'},{av:'Z1461OrdRequ'},{av:'Z1448OrdEntrega'},{av:'Z290OrdMonCod'},{av:'Z1466OrdTip'},{av:'Z1425OrdAlmCod'},{av:'Z1424OrdAIVA'},{av:'Z2236OrdTItemCron'},{av:'Z1463OrdSubAfecto'},{av:'Z1464OrdSubInafecto'},{av:'Z1465OrdSubTotal'},{av:'Z2233OrdDscto'},{av:'Z2234OrdIva'},{av:'Z2235OrdTot'},{av:'Z298TprvCod'},{av:'Z1427OrdConpDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_ORDFEC","{handler:'Valid_Ordfec',iparms:[]");
         setEventMetadata("VALID_ORDFEC",",oparms:[]}");
         setEventMetadata("VALID_ORDCONPCOD","{handler:'Valid_Ordconpcod',iparms:[{av:'A292OrdConpCod',fld:'ORDCONPCOD',pic:'ZZZZZ9'},{av:'A1427OrdConpDsc',fld:'ORDCONPDSC',pic:''}]");
         setEventMetadata("VALID_ORDCONPCOD",",oparms:[{av:'A1427OrdConpDsc',fld:'ORDCONPDSC',pic:''}]}");
         setEventMetadata("VALID_ORDPORDSCTO","{handler:'Valid_Ordpordscto',iparms:[]");
         setEventMetadata("VALID_ORDPORDSCTO",",oparms:[]}");
         setEventMetadata("VALID_ORDPORIVA","{handler:'Valid_Ordporiva',iparms:[]");
         setEventMetadata("VALID_ORDPORIVA",",oparms:[]}");
         setEventMetadata("VALID_ORDFECC","{handler:'Valid_Ordfecc',iparms:[]");
         setEventMetadata("VALID_ORDFECC",",oparms:[]}");
         setEventMetadata("VALID_ORDFECM","{handler:'Valid_Ordfecm',iparms:[]");
         setEventMetadata("VALID_ORDFECM",",oparms:[]}");
         setEventMetadata("VALID_ORDFECAUT","{handler:'Valid_Ordfecaut',iparms:[]");
         setEventMetadata("VALID_ORDFECAUT",",oparms:[]}");
         setEventMetadata("VALID_ORDCOSCOD","{handler:'Valid_Ordcoscod',iparms:[{av:'A291OrdCosCod',fld:'ORDCOSCOD',pic:''}]");
         setEventMetadata("VALID_ORDCOSCOD",",oparms:[]}");
         setEventMetadata("VALID_ORDMONCOD","{handler:'Valid_Ordmoncod',iparms:[{av:'A290OrdMonCod',fld:'ORDMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ORDMONCOD",",oparms:[]}");
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z289OrdCod = "";
         Z293OrdFec = DateTime.MinValue;
         Z1462OrdSts = "";
         Z1469OrdUsuC = "";
         Z1451OrdFecC = (DateTime)(DateTime.MinValue);
         Z1470OrdUsuM = "";
         Z1452OrdFecM = (DateTime)(DateTime.MinValue);
         Z1467OrdUsuAut = "";
         Z1449OrdFecAut = DateTime.MinValue;
         Z1468OrdUsuAut1 = "";
         Z1450OrdFecAut1 = DateTime.MinValue;
         Z1461OrdRequ = "";
         Z1448OrdEntrega = "";
         Z1466OrdTip = "";
         Z244PrvCod = "";
         Z291OrdCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A289OrdCod = "";
         A244PrvCod = "";
         A291OrdCosCod = "";
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
         A293OrdFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1454OrdObs = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A1462OrdSts = "";
         lblTextblock10_Jsonclick = "";
         A1469OrdUsuC = "";
         lblTextblock11_Jsonclick = "";
         A1451OrdFecC = (DateTime)(DateTime.MinValue);
         lblTextblock12_Jsonclick = "";
         A1470OrdUsuM = "";
         lblTextblock13_Jsonclick = "";
         A1452OrdFecM = (DateTime)(DateTime.MinValue);
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1467OrdUsuAut = "";
         lblTextblock16_Jsonclick = "";
         A1449OrdFecAut = DateTime.MinValue;
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A1461OrdRequ = "";
         lblTextblock19_Jsonclick = "";
         A1448OrdEntrega = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         A1466OrdTip = "";
         lblTextblock22_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1468OrdUsuAut1 = "";
         A1450OrdFecAut1 = DateTime.MinValue;
         Gx_mode = "";
         A1427OrdConpDsc = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1454OrdObs = "";
         Z1427OrdConpDsc = "";
         T003I11_A289OrdCod = new string[] {""} ;
         T003I11_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         T003I11_A1458OrdPorDscto = new decimal[1] ;
         T003I11_A1459OrdPorIva = new decimal[1] ;
         T003I11_A1454OrdObs = new string[] {""} ;
         T003I11_A1453OrdItem = new int[1] ;
         T003I11_A1462OrdSts = new string[] {""} ;
         T003I11_A1469OrdUsuC = new string[] {""} ;
         T003I11_A1451OrdFecC = new DateTime[] {DateTime.MinValue} ;
         T003I11_A1470OrdUsuM = new string[] {""} ;
         T003I11_A1452OrdFecM = new DateTime[] {DateTime.MinValue} ;
         T003I11_A1426OrdAut = new short[1] ;
         T003I11_A1467OrdUsuAut = new string[] {""} ;
         T003I11_A1449OrdFecAut = new DateTime[] {DateTime.MinValue} ;
         T003I11_A1468OrdUsuAut1 = new string[] {""} ;
         T003I11_A1450OrdFecAut1 = new DateTime[] {DateTime.MinValue} ;
         T003I11_A1461OrdRequ = new string[] {""} ;
         T003I11_A1448OrdEntrega = new string[] {""} ;
         T003I11_A1466OrdTip = new string[] {""} ;
         T003I11_A1425OrdAlmCod = new int[1] ;
         T003I11_n1425OrdAlmCod = new bool[] {false} ;
         T003I11_A1424OrdAIVA = new short[1] ;
         T003I11_A1427OrdConpDsc = new string[] {""} ;
         T003I11_A2236OrdTItemCron = new int[1] ;
         T003I11_A244PrvCod = new string[] {""} ;
         T003I11_A292OrdConpCod = new int[1] ;
         T003I11_A291OrdCosCod = new string[] {""} ;
         T003I11_n291OrdCosCod = new bool[] {false} ;
         T003I11_A290OrdMonCod = new int[1] ;
         T003I11_A298TprvCod = new int[1] ;
         T003I11_A1463OrdSubAfecto = new decimal[1] ;
         T003I11_A1464OrdSubInafecto = new decimal[1] ;
         T003I9_A1463OrdSubAfecto = new decimal[1] ;
         T003I9_A1464OrdSubInafecto = new decimal[1] ;
         T003I4_A298TprvCod = new int[1] ;
         T003I5_A1427OrdConpDsc = new string[] {""} ;
         T003I6_A291OrdCosCod = new string[] {""} ;
         T003I6_n291OrdCosCod = new bool[] {false} ;
         T003I7_A290OrdMonCod = new int[1] ;
         T003I13_A1463OrdSubAfecto = new decimal[1] ;
         T003I13_A1464OrdSubInafecto = new decimal[1] ;
         T003I14_A298TprvCod = new int[1] ;
         T003I15_A1427OrdConpDsc = new string[] {""} ;
         T003I16_A291OrdCosCod = new string[] {""} ;
         T003I16_n291OrdCosCod = new bool[] {false} ;
         T003I17_A290OrdMonCod = new int[1] ;
         T003I18_A289OrdCod = new string[] {""} ;
         T003I3_A289OrdCod = new string[] {""} ;
         T003I3_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         T003I3_A1458OrdPorDscto = new decimal[1] ;
         T003I3_A1459OrdPorIva = new decimal[1] ;
         T003I3_A1454OrdObs = new string[] {""} ;
         T003I3_A1453OrdItem = new int[1] ;
         T003I3_A1462OrdSts = new string[] {""} ;
         T003I3_A1469OrdUsuC = new string[] {""} ;
         T003I3_A1451OrdFecC = new DateTime[] {DateTime.MinValue} ;
         T003I3_A1470OrdUsuM = new string[] {""} ;
         T003I3_A1452OrdFecM = new DateTime[] {DateTime.MinValue} ;
         T003I3_A1426OrdAut = new short[1] ;
         T003I3_A1467OrdUsuAut = new string[] {""} ;
         T003I3_A1449OrdFecAut = new DateTime[] {DateTime.MinValue} ;
         T003I3_A1468OrdUsuAut1 = new string[] {""} ;
         T003I3_A1450OrdFecAut1 = new DateTime[] {DateTime.MinValue} ;
         T003I3_A1461OrdRequ = new string[] {""} ;
         T003I3_A1448OrdEntrega = new string[] {""} ;
         T003I3_A1466OrdTip = new string[] {""} ;
         T003I3_A1425OrdAlmCod = new int[1] ;
         T003I3_n1425OrdAlmCod = new bool[] {false} ;
         T003I3_A1424OrdAIVA = new short[1] ;
         T003I3_A2236OrdTItemCron = new int[1] ;
         T003I3_A244PrvCod = new string[] {""} ;
         T003I3_A292OrdConpCod = new int[1] ;
         T003I3_A291OrdCosCod = new string[] {""} ;
         T003I3_n291OrdCosCod = new bool[] {false} ;
         T003I3_A290OrdMonCod = new int[1] ;
         sMode121 = "";
         T003I19_A289OrdCod = new string[] {""} ;
         T003I20_A289OrdCod = new string[] {""} ;
         T003I2_A289OrdCod = new string[] {""} ;
         T003I2_A293OrdFec = new DateTime[] {DateTime.MinValue} ;
         T003I2_A1458OrdPorDscto = new decimal[1] ;
         T003I2_A1459OrdPorIva = new decimal[1] ;
         T003I2_A1454OrdObs = new string[] {""} ;
         T003I2_A1453OrdItem = new int[1] ;
         T003I2_A1462OrdSts = new string[] {""} ;
         T003I2_A1469OrdUsuC = new string[] {""} ;
         T003I2_A1451OrdFecC = new DateTime[] {DateTime.MinValue} ;
         T003I2_A1470OrdUsuM = new string[] {""} ;
         T003I2_A1452OrdFecM = new DateTime[] {DateTime.MinValue} ;
         T003I2_A1426OrdAut = new short[1] ;
         T003I2_A1467OrdUsuAut = new string[] {""} ;
         T003I2_A1449OrdFecAut = new DateTime[] {DateTime.MinValue} ;
         T003I2_A1468OrdUsuAut1 = new string[] {""} ;
         T003I2_A1450OrdFecAut1 = new DateTime[] {DateTime.MinValue} ;
         T003I2_A1461OrdRequ = new string[] {""} ;
         T003I2_A1448OrdEntrega = new string[] {""} ;
         T003I2_A1466OrdTip = new string[] {""} ;
         T003I2_A1425OrdAlmCod = new int[1] ;
         T003I2_n1425OrdAlmCod = new bool[] {false} ;
         T003I2_A1424OrdAIVA = new short[1] ;
         T003I2_A2236OrdTItemCron = new int[1] ;
         T003I2_A244PrvCod = new string[] {""} ;
         T003I2_A292OrdConpCod = new int[1] ;
         T003I2_A291OrdCosCod = new string[] {""} ;
         T003I2_n291OrdCosCod = new bool[] {false} ;
         T003I2_A290OrdMonCod = new int[1] ;
         T003I25_A1463OrdSubAfecto = new decimal[1] ;
         T003I25_A1464OrdSubInafecto = new decimal[1] ;
         T003I26_A298TprvCod = new int[1] ;
         T003I27_A1427OrdConpDsc = new string[] {""} ;
         T003I28_A289OrdCod = new string[] {""} ;
         T003I28_A295OrdDItem = new int[1] ;
         T003I29_A289OrdCod = new string[] {""} ;
         T003I29_A294OrdCron = new int[1] ;
         T003I30_A289OrdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ289OrdCod = "";
         ZZ244PrvCod = "";
         ZZ293OrdFec = DateTime.MinValue;
         ZZ1454OrdObs = "";
         ZZ1462OrdSts = "";
         ZZ1469OrdUsuC = "";
         ZZ1451OrdFecC = (DateTime)(DateTime.MinValue);
         ZZ1470OrdUsuM = "";
         ZZ1452OrdFecM = (DateTime)(DateTime.MinValue);
         ZZ1467OrdUsuAut = "";
         ZZ1449OrdFecAut = DateTime.MinValue;
         ZZ1468OrdUsuAut1 = "";
         ZZ1450OrdFecAut1 = DateTime.MinValue;
         ZZ291OrdCosCod = "";
         ZZ1461OrdRequ = "";
         ZZ1448OrdEntrega = "";
         ZZ1466OrdTip = "";
         ZZ1427OrdConpDsc = "";
         T003I31_A291OrdCosCod = new string[] {""} ;
         T003I31_n291OrdCosCod = new bool[] {false} ;
         T003I32_A290OrdMonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cporden__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cporden__default(),
            new Object[][] {
                new Object[] {
               T003I2_A289OrdCod, T003I2_A293OrdFec, T003I2_A1458OrdPorDscto, T003I2_A1459OrdPorIva, T003I2_A1454OrdObs, T003I2_A1453OrdItem, T003I2_A1462OrdSts, T003I2_A1469OrdUsuC, T003I2_A1451OrdFecC, T003I2_A1470OrdUsuM,
               T003I2_A1452OrdFecM, T003I2_A1426OrdAut, T003I2_A1467OrdUsuAut, T003I2_A1449OrdFecAut, T003I2_A1468OrdUsuAut1, T003I2_A1450OrdFecAut1, T003I2_A1461OrdRequ, T003I2_A1448OrdEntrega, T003I2_A1466OrdTip, T003I2_A1425OrdAlmCod,
               T003I2_n1425OrdAlmCod, T003I2_A1424OrdAIVA, T003I2_A2236OrdTItemCron, T003I2_A244PrvCod, T003I2_A292OrdConpCod, T003I2_A291OrdCosCod, T003I2_n291OrdCosCod, T003I2_A290OrdMonCod
               }
               , new Object[] {
               T003I3_A289OrdCod, T003I3_A293OrdFec, T003I3_A1458OrdPorDscto, T003I3_A1459OrdPorIva, T003I3_A1454OrdObs, T003I3_A1453OrdItem, T003I3_A1462OrdSts, T003I3_A1469OrdUsuC, T003I3_A1451OrdFecC, T003I3_A1470OrdUsuM,
               T003I3_A1452OrdFecM, T003I3_A1426OrdAut, T003I3_A1467OrdUsuAut, T003I3_A1449OrdFecAut, T003I3_A1468OrdUsuAut1, T003I3_A1450OrdFecAut1, T003I3_A1461OrdRequ, T003I3_A1448OrdEntrega, T003I3_A1466OrdTip, T003I3_A1425OrdAlmCod,
               T003I3_n1425OrdAlmCod, T003I3_A1424OrdAIVA, T003I3_A2236OrdTItemCron, T003I3_A244PrvCod, T003I3_A292OrdConpCod, T003I3_A291OrdCosCod, T003I3_n291OrdCosCod, T003I3_A290OrdMonCod
               }
               , new Object[] {
               T003I4_A298TprvCod
               }
               , new Object[] {
               T003I5_A1427OrdConpDsc
               }
               , new Object[] {
               T003I6_A291OrdCosCod
               }
               , new Object[] {
               T003I7_A290OrdMonCod
               }
               , new Object[] {
               T003I9_A1463OrdSubAfecto, T003I9_A1464OrdSubInafecto
               }
               , new Object[] {
               T003I11_A289OrdCod, T003I11_A293OrdFec, T003I11_A1458OrdPorDscto, T003I11_A1459OrdPorIva, T003I11_A1454OrdObs, T003I11_A1453OrdItem, T003I11_A1462OrdSts, T003I11_A1469OrdUsuC, T003I11_A1451OrdFecC, T003I11_A1470OrdUsuM,
               T003I11_A1452OrdFecM, T003I11_A1426OrdAut, T003I11_A1467OrdUsuAut, T003I11_A1449OrdFecAut, T003I11_A1468OrdUsuAut1, T003I11_A1450OrdFecAut1, T003I11_A1461OrdRequ, T003I11_A1448OrdEntrega, T003I11_A1466OrdTip, T003I11_A1425OrdAlmCod,
               T003I11_n1425OrdAlmCod, T003I11_A1424OrdAIVA, T003I11_A1427OrdConpDsc, T003I11_A2236OrdTItemCron, T003I11_A244PrvCod, T003I11_A292OrdConpCod, T003I11_A291OrdCosCod, T003I11_n291OrdCosCod, T003I11_A290OrdMonCod, T003I11_A298TprvCod,
               T003I11_A1463OrdSubAfecto, T003I11_A1464OrdSubInafecto
               }
               , new Object[] {
               T003I13_A1463OrdSubAfecto, T003I13_A1464OrdSubInafecto
               }
               , new Object[] {
               T003I14_A298TprvCod
               }
               , new Object[] {
               T003I15_A1427OrdConpDsc
               }
               , new Object[] {
               T003I16_A291OrdCosCod
               }
               , new Object[] {
               T003I17_A290OrdMonCod
               }
               , new Object[] {
               T003I18_A289OrdCod
               }
               , new Object[] {
               T003I19_A289OrdCod
               }
               , new Object[] {
               T003I20_A289OrdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003I25_A1463OrdSubAfecto, T003I25_A1464OrdSubInafecto
               }
               , new Object[] {
               T003I26_A298TprvCod
               }
               , new Object[] {
               T003I27_A1427OrdConpDsc
               }
               , new Object[] {
               T003I28_A289OrdCod, T003I28_A295OrdDItem
               }
               , new Object[] {
               T003I29_A289OrdCod, T003I29_A294OrdCron
               }
               , new Object[] {
               T003I30_A289OrdCod
               }
               , new Object[] {
               T003I31_A291OrdCosCod
               }
               , new Object[] {
               T003I32_A290OrdMonCod
               }
            }
         );
      }

      private short Z1426OrdAut ;
      private short Z1424OrdAIVA ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1426OrdAut ;
      private short A1424OrdAIVA ;
      private short GX_JID ;
      private short RcdFound121 ;
      private short nIsDirty_121 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1426OrdAut ;
      private short ZZ1424OrdAIVA ;
      private int Z1453OrdItem ;
      private int Z1425OrdAlmCod ;
      private int Z2236OrdTItemCron ;
      private int Z292OrdConpCod ;
      private int Z290OrdMonCod ;
      private int A292OrdConpCod ;
      private int A290OrdMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtOrdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtPrvCod_Enabled ;
      private int edtOrdFec_Enabled ;
      private int edtOrdConpCod_Enabled ;
      private int edtOrdPorDscto_Enabled ;
      private int edtOrdPorIva_Enabled ;
      private int edtOrdObs_Enabled ;
      private int A1453OrdItem ;
      private int edtOrdItem_Enabled ;
      private int edtOrdSts_Enabled ;
      private int edtOrdUsuC_Enabled ;
      private int edtOrdFecC_Enabled ;
      private int edtOrdUsuM_Enabled ;
      private int edtOrdFecM_Enabled ;
      private int edtOrdAut_Enabled ;
      private int edtOrdUsuAut_Enabled ;
      private int edtOrdFecAut_Enabled ;
      private int edtOrdCosCod_Enabled ;
      private int edtOrdRequ_Enabled ;
      private int edtOrdEntrega_Enabled ;
      private int edtOrdMonCod_Enabled ;
      private int edtOrdTip_Enabled ;
      private int A1425OrdAlmCod ;
      private int edtOrdAlmCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A2236OrdTItemCron ;
      private int A298TprvCod ;
      private int Z298TprvCod ;
      private int idxLst ;
      private int ZZ292OrdConpCod ;
      private int ZZ1453OrdItem ;
      private int ZZ290OrdMonCod ;
      private int ZZ1425OrdAlmCod ;
      private int ZZ2236OrdTItemCron ;
      private int ZZ298TprvCod ;
      private decimal Z1458OrdPorDscto ;
      private decimal Z1459OrdPorIva ;
      private decimal A1458OrdPorDscto ;
      private decimal A1459OrdPorIva ;
      private decimal A1465OrdSubTotal ;
      private decimal A2233OrdDscto ;
      private decimal A1463OrdSubAfecto ;
      private decimal A2234OrdIva ;
      private decimal A1464OrdSubInafecto ;
      private decimal A2235OrdTot ;
      private decimal Z1463OrdSubAfecto ;
      private decimal Z1464OrdSubInafecto ;
      private decimal Z1465OrdSubTotal ;
      private decimal Z2233OrdDscto ;
      private decimal Z2234OrdIva ;
      private decimal Z2235OrdTot ;
      private decimal ZZ1458OrdPorDscto ;
      private decimal ZZ1459OrdPorIva ;
      private decimal ZZ1463OrdSubAfecto ;
      private decimal ZZ1464OrdSubInafecto ;
      private decimal ZZ1465OrdSubTotal ;
      private decimal ZZ2233OrdDscto ;
      private decimal ZZ2234OrdIva ;
      private decimal ZZ2235OrdTot ;
      private string sPrefix ;
      private string Z289OrdCod ;
      private string Z1462OrdSts ;
      private string Z1469OrdUsuC ;
      private string Z1470OrdUsuM ;
      private string Z1467OrdUsuAut ;
      private string Z1468OrdUsuAut1 ;
      private string Z1461OrdRequ ;
      private string Z1448OrdEntrega ;
      private string Z244PrvCod ;
      private string Z291OrdCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A289OrdCod ;
      private string A244PrvCod ;
      private string A291OrdCosCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOrdCod_Internalname ;
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
      private string edtOrdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtPrvCod_Internalname ;
      private string edtPrvCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtOrdFec_Internalname ;
      private string edtOrdFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtOrdConpCod_Internalname ;
      private string edtOrdConpCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtOrdPorDscto_Internalname ;
      private string edtOrdPorDscto_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtOrdPorIva_Internalname ;
      private string edtOrdPorIva_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtOrdObs_Internalname ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtOrdItem_Internalname ;
      private string edtOrdItem_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtOrdSts_Internalname ;
      private string A1462OrdSts ;
      private string edtOrdSts_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtOrdUsuC_Internalname ;
      private string A1469OrdUsuC ;
      private string edtOrdUsuC_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtOrdFecC_Internalname ;
      private string edtOrdFecC_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtOrdUsuM_Internalname ;
      private string A1470OrdUsuM ;
      private string edtOrdUsuM_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtOrdFecM_Internalname ;
      private string edtOrdFecM_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtOrdAut_Internalname ;
      private string edtOrdAut_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtOrdUsuAut_Internalname ;
      private string A1467OrdUsuAut ;
      private string edtOrdUsuAut_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtOrdFecAut_Internalname ;
      private string edtOrdFecAut_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtOrdCosCod_Internalname ;
      private string edtOrdCosCod_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtOrdRequ_Internalname ;
      private string A1461OrdRequ ;
      private string edtOrdRequ_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtOrdEntrega_Internalname ;
      private string A1448OrdEntrega ;
      private string edtOrdEntrega_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtOrdMonCod_Internalname ;
      private string edtOrdMonCod_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtOrdTip_Internalname ;
      private string edtOrdTip_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtOrdAlmCod_Internalname ;
      private string edtOrdAlmCod_Jsonclick ;
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
      private string A1468OrdUsuAut1 ;
      private string Gx_mode ;
      private string A1427OrdConpDsc ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1427OrdConpDsc ;
      private string sMode121 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ289OrdCod ;
      private string ZZ244PrvCod ;
      private string ZZ1462OrdSts ;
      private string ZZ1469OrdUsuC ;
      private string ZZ1470OrdUsuM ;
      private string ZZ1467OrdUsuAut ;
      private string ZZ1468OrdUsuAut1 ;
      private string ZZ291OrdCosCod ;
      private string ZZ1461OrdRequ ;
      private string ZZ1448OrdEntrega ;
      private string ZZ1427OrdConpDsc ;
      private DateTime Z1451OrdFecC ;
      private DateTime Z1452OrdFecM ;
      private DateTime A1451OrdFecC ;
      private DateTime A1452OrdFecM ;
      private DateTime ZZ1451OrdFecC ;
      private DateTime ZZ1452OrdFecM ;
      private DateTime Z293OrdFec ;
      private DateTime Z1449OrdFecAut ;
      private DateTime Z1450OrdFecAut1 ;
      private DateTime A293OrdFec ;
      private DateTime A1449OrdFecAut ;
      private DateTime A1450OrdFecAut1 ;
      private DateTime ZZ293OrdFec ;
      private DateTime ZZ1449OrdFecAut ;
      private DateTime ZZ1450OrdFecAut1 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n291OrdCosCod ;
      private bool wbErr ;
      private bool n1425OrdAlmCod ;
      private bool Gx_longc ;
      private string A1454OrdObs ;
      private string Z1454OrdObs ;
      private string ZZ1454OrdObs ;
      private string Z1466OrdTip ;
      private string A1466OrdTip ;
      private string ZZ1466OrdTip ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003I11_A289OrdCod ;
      private DateTime[] T003I11_A293OrdFec ;
      private decimal[] T003I11_A1458OrdPorDscto ;
      private decimal[] T003I11_A1459OrdPorIva ;
      private string[] T003I11_A1454OrdObs ;
      private int[] T003I11_A1453OrdItem ;
      private string[] T003I11_A1462OrdSts ;
      private string[] T003I11_A1469OrdUsuC ;
      private DateTime[] T003I11_A1451OrdFecC ;
      private string[] T003I11_A1470OrdUsuM ;
      private DateTime[] T003I11_A1452OrdFecM ;
      private short[] T003I11_A1426OrdAut ;
      private string[] T003I11_A1467OrdUsuAut ;
      private DateTime[] T003I11_A1449OrdFecAut ;
      private string[] T003I11_A1468OrdUsuAut1 ;
      private DateTime[] T003I11_A1450OrdFecAut1 ;
      private string[] T003I11_A1461OrdRequ ;
      private string[] T003I11_A1448OrdEntrega ;
      private string[] T003I11_A1466OrdTip ;
      private int[] T003I11_A1425OrdAlmCod ;
      private bool[] T003I11_n1425OrdAlmCod ;
      private short[] T003I11_A1424OrdAIVA ;
      private string[] T003I11_A1427OrdConpDsc ;
      private int[] T003I11_A2236OrdTItemCron ;
      private string[] T003I11_A244PrvCod ;
      private int[] T003I11_A292OrdConpCod ;
      private string[] T003I11_A291OrdCosCod ;
      private bool[] T003I11_n291OrdCosCod ;
      private int[] T003I11_A290OrdMonCod ;
      private int[] T003I11_A298TprvCod ;
      private decimal[] T003I11_A1463OrdSubAfecto ;
      private decimal[] T003I11_A1464OrdSubInafecto ;
      private decimal[] T003I9_A1463OrdSubAfecto ;
      private decimal[] T003I9_A1464OrdSubInafecto ;
      private int[] T003I4_A298TprvCod ;
      private string[] T003I5_A1427OrdConpDsc ;
      private string[] T003I6_A291OrdCosCod ;
      private bool[] T003I6_n291OrdCosCod ;
      private int[] T003I7_A290OrdMonCod ;
      private decimal[] T003I13_A1463OrdSubAfecto ;
      private decimal[] T003I13_A1464OrdSubInafecto ;
      private int[] T003I14_A298TprvCod ;
      private string[] T003I15_A1427OrdConpDsc ;
      private string[] T003I16_A291OrdCosCod ;
      private bool[] T003I16_n291OrdCosCod ;
      private int[] T003I17_A290OrdMonCod ;
      private string[] T003I18_A289OrdCod ;
      private string[] T003I3_A289OrdCod ;
      private DateTime[] T003I3_A293OrdFec ;
      private decimal[] T003I3_A1458OrdPorDscto ;
      private decimal[] T003I3_A1459OrdPorIva ;
      private string[] T003I3_A1454OrdObs ;
      private int[] T003I3_A1453OrdItem ;
      private string[] T003I3_A1462OrdSts ;
      private string[] T003I3_A1469OrdUsuC ;
      private DateTime[] T003I3_A1451OrdFecC ;
      private string[] T003I3_A1470OrdUsuM ;
      private DateTime[] T003I3_A1452OrdFecM ;
      private short[] T003I3_A1426OrdAut ;
      private string[] T003I3_A1467OrdUsuAut ;
      private DateTime[] T003I3_A1449OrdFecAut ;
      private string[] T003I3_A1468OrdUsuAut1 ;
      private DateTime[] T003I3_A1450OrdFecAut1 ;
      private string[] T003I3_A1461OrdRequ ;
      private string[] T003I3_A1448OrdEntrega ;
      private string[] T003I3_A1466OrdTip ;
      private int[] T003I3_A1425OrdAlmCod ;
      private bool[] T003I3_n1425OrdAlmCod ;
      private short[] T003I3_A1424OrdAIVA ;
      private int[] T003I3_A2236OrdTItemCron ;
      private string[] T003I3_A244PrvCod ;
      private int[] T003I3_A292OrdConpCod ;
      private string[] T003I3_A291OrdCosCod ;
      private bool[] T003I3_n291OrdCosCod ;
      private int[] T003I3_A290OrdMonCod ;
      private string[] T003I19_A289OrdCod ;
      private string[] T003I20_A289OrdCod ;
      private string[] T003I2_A289OrdCod ;
      private DateTime[] T003I2_A293OrdFec ;
      private decimal[] T003I2_A1458OrdPorDscto ;
      private decimal[] T003I2_A1459OrdPorIva ;
      private string[] T003I2_A1454OrdObs ;
      private int[] T003I2_A1453OrdItem ;
      private string[] T003I2_A1462OrdSts ;
      private string[] T003I2_A1469OrdUsuC ;
      private DateTime[] T003I2_A1451OrdFecC ;
      private string[] T003I2_A1470OrdUsuM ;
      private DateTime[] T003I2_A1452OrdFecM ;
      private short[] T003I2_A1426OrdAut ;
      private string[] T003I2_A1467OrdUsuAut ;
      private DateTime[] T003I2_A1449OrdFecAut ;
      private string[] T003I2_A1468OrdUsuAut1 ;
      private DateTime[] T003I2_A1450OrdFecAut1 ;
      private string[] T003I2_A1461OrdRequ ;
      private string[] T003I2_A1448OrdEntrega ;
      private string[] T003I2_A1466OrdTip ;
      private int[] T003I2_A1425OrdAlmCod ;
      private bool[] T003I2_n1425OrdAlmCod ;
      private short[] T003I2_A1424OrdAIVA ;
      private int[] T003I2_A2236OrdTItemCron ;
      private string[] T003I2_A244PrvCod ;
      private int[] T003I2_A292OrdConpCod ;
      private string[] T003I2_A291OrdCosCod ;
      private bool[] T003I2_n291OrdCosCod ;
      private int[] T003I2_A290OrdMonCod ;
      private decimal[] T003I25_A1463OrdSubAfecto ;
      private decimal[] T003I25_A1464OrdSubInafecto ;
      private int[] T003I26_A298TprvCod ;
      private string[] T003I27_A1427OrdConpDsc ;
      private string[] T003I28_A289OrdCod ;
      private int[] T003I28_A295OrdDItem ;
      private string[] T003I29_A289OrdCod ;
      private int[] T003I29_A294OrdCron ;
      private string[] T003I30_A289OrdCod ;
      private string[] T003I31_A291OrdCosCod ;
      private bool[] T003I31_n291OrdCosCod ;
      private int[] T003I32_A290OrdMonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cporden__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cporden__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003I11;
        prmT003I11 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I9;
        prmT003I9 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I4;
        prmT003I4 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003I5;
        prmT003I5 = new Object[] {
        new ParDef("@OrdConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003I6;
        prmT003I6 = new Object[] {
        new ParDef("@OrdCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT003I7;
        prmT003I7 = new Object[] {
        new ParDef("@OrdMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003I13;
        prmT003I13 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I14;
        prmT003I14 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003I15;
        prmT003I15 = new Object[] {
        new ParDef("@OrdConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003I16;
        prmT003I16 = new Object[] {
        new ParDef("@OrdCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT003I17;
        prmT003I17 = new Object[] {
        new ParDef("@OrdMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003I18;
        prmT003I18 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I3;
        prmT003I3 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I19;
        prmT003I19 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I20;
        prmT003I20 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I2;
        prmT003I2 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I21;
        prmT003I21 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdFec",GXType.Date,8,0) ,
        new ParDef("@OrdPorDscto",GXType.Decimal,5,2) ,
        new ParDef("@OrdPorIva",GXType.Decimal,5,2) ,
        new ParDef("@OrdObs",GXType.NVarChar,1000,0) ,
        new ParDef("@OrdItem",GXType.Int32,6,0) ,
        new ParDef("@OrdSts",GXType.NChar,1,0) ,
        new ParDef("@OrdUsuC",GXType.NChar,10,0) ,
        new ParDef("@OrdFecC",GXType.DateTime,8,5) ,
        new ParDef("@OrdUsuM",GXType.NChar,10,0) ,
        new ParDef("@OrdFecM",GXType.DateTime,8,5) ,
        new ParDef("@OrdAut",GXType.Int16,1,0) ,
        new ParDef("@OrdUsuAut",GXType.NChar,10,0) ,
        new ParDef("@OrdFecAut",GXType.Date,8,0) ,
        new ParDef("@OrdUsuAut1",GXType.NChar,10,0) ,
        new ParDef("@OrdFecAut1",GXType.Date,8,0) ,
        new ParDef("@OrdRequ",GXType.NChar,20,0) ,
        new ParDef("@OrdEntrega",GXType.NChar,100,0) ,
        new ParDef("@OrdTip",GXType.NVarChar,1,0) ,
        new ParDef("@OrdAlmCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@OrdAIVA",GXType.Int16,1,0) ,
        new ParDef("@OrdTItemCron",GXType.Int32,6,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@OrdConpCod",GXType.Int32,6,0) ,
        new ParDef("@OrdCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@OrdMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003I22;
        prmT003I22 = new Object[] {
        new ParDef("@OrdFec",GXType.Date,8,0) ,
        new ParDef("@OrdPorDscto",GXType.Decimal,5,2) ,
        new ParDef("@OrdPorIva",GXType.Decimal,5,2) ,
        new ParDef("@OrdObs",GXType.NVarChar,1000,0) ,
        new ParDef("@OrdItem",GXType.Int32,6,0) ,
        new ParDef("@OrdSts",GXType.NChar,1,0) ,
        new ParDef("@OrdUsuC",GXType.NChar,10,0) ,
        new ParDef("@OrdFecC",GXType.DateTime,8,5) ,
        new ParDef("@OrdUsuM",GXType.NChar,10,0) ,
        new ParDef("@OrdFecM",GXType.DateTime,8,5) ,
        new ParDef("@OrdAut",GXType.Int16,1,0) ,
        new ParDef("@OrdUsuAut",GXType.NChar,10,0) ,
        new ParDef("@OrdFecAut",GXType.Date,8,0) ,
        new ParDef("@OrdUsuAut1",GXType.NChar,10,0) ,
        new ParDef("@OrdFecAut1",GXType.Date,8,0) ,
        new ParDef("@OrdRequ",GXType.NChar,20,0) ,
        new ParDef("@OrdEntrega",GXType.NChar,100,0) ,
        new ParDef("@OrdTip",GXType.NVarChar,1,0) ,
        new ParDef("@OrdAlmCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@OrdAIVA",GXType.Int16,1,0) ,
        new ParDef("@OrdTItemCron",GXType.Int32,6,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@OrdConpCod",GXType.Int32,6,0) ,
        new ParDef("@OrdCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@OrdMonCod",GXType.Int32,6,0) ,
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I23;
        prmT003I23 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I28;
        prmT003I28 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I29;
        prmT003I29 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I30;
        prmT003I30 = new Object[] {
        };
        Object[] prmT003I25;
        prmT003I25 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003I26;
        prmT003I26 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003I27;
        prmT003I27 = new Object[] {
        new ParDef("@OrdConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003I31;
        prmT003I31 = new Object[] {
        new ParDef("@OrdCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT003I32;
        prmT003I32 = new Object[] {
        new ParDef("@OrdMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003I2", "SELECT [OrdCod], [OrdFec], [OrdPorDscto], [OrdPorIva], [OrdObs], [OrdItem], [OrdSts], [OrdUsuC], [OrdFecC], [OrdUsuM], [OrdFecM], [OrdAut], [OrdUsuAut], [OrdFecAut], [OrdUsuAut1], [OrdFecAut1], [OrdRequ], [OrdEntrega], [OrdTip], [OrdAlmCod], [OrdAIVA], [OrdTItemCron], [PrvCod], [OrdConpCod] AS OrdConpCod, [OrdCosCod] AS OrdCosCod, [OrdMonCod] AS OrdMonCod FROM [CPORDEN] WITH (UPDLOCK) WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I3", "SELECT [OrdCod], [OrdFec], [OrdPorDscto], [OrdPorIva], [OrdObs], [OrdItem], [OrdSts], [OrdUsuC], [OrdFecC], [OrdUsuM], [OrdFecM], [OrdAut], [OrdUsuAut], [OrdFecAut], [OrdUsuAut1], [OrdFecAut1], [OrdRequ], [OrdEntrega], [OrdTip], [OrdAlmCod], [OrdAIVA], [OrdTItemCron], [PrvCod], [OrdConpCod] AS OrdConpCod, [OrdCosCod] AS OrdCosCod, [OrdMonCod] AS OrdMonCod FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I4", "SELECT [TprvCod] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I5", "SELECT [ConpDsc] AS OrdConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @OrdConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I6", "SELECT [COSCod] AS OrdCosCod FROM [CBCOSTOS] WHERE [COSCod] = @OrdCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I7", "SELECT [MonCod] AS OrdMonCod FROM [CMONEDAS] WHERE [MonCod] = @OrdMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I9", "SELECT COALESCE( T1.[OrdSubAfecto], 0) AS OrdSubAfecto, COALESCE( T1.[OrdSubInafecto], 0) AS OrdSubInafecto FROM (SELECT SUM(CASE  WHEN [OrdDIna] = 0 THEN [OrdDTot] ELSE 0 END) AS OrdSubAfecto, [OrdCod], SUM(CASE  WHEN [OrdDIna] = 1 THEN [OrdDTot] ELSE 0 END) AS OrdSubInafecto FROM [CPORDENDET] GROUP BY [OrdCod] ) T1 WHERE T1.[OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I11", "SELECT TM1.[OrdCod], TM1.[OrdFec], TM1.[OrdPorDscto], TM1.[OrdPorIva], TM1.[OrdObs], TM1.[OrdItem], TM1.[OrdSts], TM1.[OrdUsuC], TM1.[OrdFecC], TM1.[OrdUsuM], TM1.[OrdFecM], TM1.[OrdAut], TM1.[OrdUsuAut], TM1.[OrdFecAut], TM1.[OrdUsuAut1], TM1.[OrdFecAut1], TM1.[OrdRequ], TM1.[OrdEntrega], TM1.[OrdTip], TM1.[OrdAlmCod], TM1.[OrdAIVA], T4.[ConpDsc] AS OrdConpDsc, TM1.[OrdTItemCron], TM1.[PrvCod], TM1.[OrdConpCod] AS OrdConpCod, TM1.[OrdCosCod] AS OrdCosCod, TM1.[OrdMonCod] AS OrdMonCod, T3.[TprvCod], COALESCE( T2.[OrdSubAfecto], 0) AS OrdSubAfecto, COALESCE( T2.[OrdSubInafecto], 0) AS OrdSubInafecto FROM ((([CPORDEN] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN [OrdDIna] = 0 THEN [OrdDTot] ELSE 0 END) AS OrdSubAfecto, [OrdCod], SUM(CASE  WHEN [OrdDIna] = 1 THEN [OrdDTot] ELSE 0 END) AS OrdSubInafecto FROM [CPORDENDET] GROUP BY [OrdCod] ) T2 ON T2.[OrdCod] = TM1.[OrdCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = TM1.[PrvCod]) INNER JOIN [CCONDICIONPAGO] T4 ON T4.[Conpcod] = TM1.[OrdConpCod]) WHERE TM1.[OrdCod] = @OrdCod ORDER BY TM1.[OrdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003I11,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I13", "SELECT COALESCE( T1.[OrdSubAfecto], 0) AS OrdSubAfecto, COALESCE( T1.[OrdSubInafecto], 0) AS OrdSubInafecto FROM (SELECT SUM(CASE  WHEN [OrdDIna] = 0 THEN [OrdDTot] ELSE 0 END) AS OrdSubAfecto, [OrdCod], SUM(CASE  WHEN [OrdDIna] = 1 THEN [OrdDTot] ELSE 0 END) AS OrdSubInafecto FROM [CPORDENDET] GROUP BY [OrdCod] ) T1 WHERE T1.[OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I14", "SELECT [TprvCod] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I15", "SELECT [ConpDsc] AS OrdConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @OrdConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I16", "SELECT [COSCod] AS OrdCosCod FROM [CBCOSTOS] WHERE [COSCod] = @OrdCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I17", "SELECT [MonCod] AS OrdMonCod FROM [CMONEDAS] WHERE [MonCod] = @OrdMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I18", "SELECT [OrdCod] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003I18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I19", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE ( [OrdCod] > @OrdCod) ORDER BY [OrdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003I19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003I20", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE ( [OrdCod] < @OrdCod) ORDER BY [OrdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003I20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003I21", "INSERT INTO [CPORDEN]([OrdCod], [OrdFec], [OrdPorDscto], [OrdPorIva], [OrdObs], [OrdItem], [OrdSts], [OrdUsuC], [OrdFecC], [OrdUsuM], [OrdFecM], [OrdAut], [OrdUsuAut], [OrdFecAut], [OrdUsuAut1], [OrdFecAut1], [OrdRequ], [OrdEntrega], [OrdTip], [OrdAlmCod], [OrdAIVA], [OrdTItemCron], [PrvCod], [OrdConpCod], [OrdCosCod], [OrdMonCod]) VALUES(@OrdCod, @OrdFec, @OrdPorDscto, @OrdPorIva, @OrdObs, @OrdItem, @OrdSts, @OrdUsuC, @OrdFecC, @OrdUsuM, @OrdFecM, @OrdAut, @OrdUsuAut, @OrdFecAut, @OrdUsuAut1, @OrdFecAut1, @OrdRequ, @OrdEntrega, @OrdTip, @OrdAlmCod, @OrdAIVA, @OrdTItemCron, @PrvCod, @OrdConpCod, @OrdCosCod, @OrdMonCod)", GxErrorMask.GX_NOMASK,prmT003I21)
           ,new CursorDef("T003I22", "UPDATE [CPORDEN] SET [OrdFec]=@OrdFec, [OrdPorDscto]=@OrdPorDscto, [OrdPorIva]=@OrdPorIva, [OrdObs]=@OrdObs, [OrdItem]=@OrdItem, [OrdSts]=@OrdSts, [OrdUsuC]=@OrdUsuC, [OrdFecC]=@OrdFecC, [OrdUsuM]=@OrdUsuM, [OrdFecM]=@OrdFecM, [OrdAut]=@OrdAut, [OrdUsuAut]=@OrdUsuAut, [OrdFecAut]=@OrdFecAut, [OrdUsuAut1]=@OrdUsuAut1, [OrdFecAut1]=@OrdFecAut1, [OrdRequ]=@OrdRequ, [OrdEntrega]=@OrdEntrega, [OrdTip]=@OrdTip, [OrdAlmCod]=@OrdAlmCod, [OrdAIVA]=@OrdAIVA, [OrdTItemCron]=@OrdTItemCron, [PrvCod]=@PrvCod, [OrdConpCod]=@OrdConpCod, [OrdCosCod]=@OrdCosCod, [OrdMonCod]=@OrdMonCod  WHERE [OrdCod] = @OrdCod", GxErrorMask.GX_NOMASK,prmT003I22)
           ,new CursorDef("T003I23", "DELETE FROM [CPORDEN]  WHERE [OrdCod] = @OrdCod", GxErrorMask.GX_NOMASK,prmT003I23)
           ,new CursorDef("T003I25", "SELECT COALESCE( T1.[OrdSubAfecto], 0) AS OrdSubAfecto, COALESCE( T1.[OrdSubInafecto], 0) AS OrdSubInafecto FROM (SELECT SUM(CASE  WHEN [OrdDIna] = 0 THEN [OrdDTot] ELSE 0 END) AS OrdSubAfecto, [OrdCod], SUM(CASE  WHEN [OrdDIna] = 1 THEN [OrdDTot] ELSE 0 END) AS OrdSubInafecto FROM [CPORDENDET] GROUP BY [OrdCod] ) T1 WHERE T1.[OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I26", "SELECT [TprvCod] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I27", "SELECT [ConpDsc] AS OrdConpDsc FROM [CCONDICIONPAGO] WHERE [Conpcod] = @OrdConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I28", "SELECT TOP 1 [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003I29", "SELECT TOP 1 [OrdCod], [OrdCron] FROM [CPORDENCRON] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003I30", "SELECT [OrdCod] FROM [CPORDEN] ORDER BY [OrdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003I30,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I31", "SELECT [COSCod] AS OrdCosCod FROM [CBCOSTOS] WHERE [COSCod] = @OrdCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003I32", "SELECT [MonCod] AS OrdMonCod FROM [CMONEDAS] WHERE [MonCod] = @OrdMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003I32,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((bool[]) buf[20])[0] = rslt.wasNull(20);
              ((short[]) buf[21])[0] = rslt.getShort(21);
              ((int[]) buf[22])[0] = rslt.getInt(22);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 10);
              ((bool[]) buf[26])[0] = rslt.wasNull(25);
              ((int[]) buf[27])[0] = rslt.getInt(26);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((bool[]) buf[20])[0] = rslt.wasNull(20);
              ((short[]) buf[21])[0] = rslt.getShort(21);
              ((int[]) buf[22])[0] = rslt.getInt(22);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 10);
              ((bool[]) buf[26])[0] = rslt.wasNull(25);
              ((int[]) buf[27])[0] = rslt.getInt(26);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getVarchar(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((bool[]) buf[20])[0] = rslt.wasNull(20);
              ((short[]) buf[21])[0] = rslt.getShort(21);
              ((string[]) buf[22])[0] = rslt.getString(22, 100);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((string[]) buf[24])[0] = rslt.getString(24, 20);
              ((int[]) buf[25])[0] = rslt.getInt(25);
              ((string[]) buf[26])[0] = rslt.getString(26, 10);
              ((bool[]) buf[27])[0] = rslt.wasNull(26);
              ((int[]) buf[28])[0] = rslt.getInt(27);
              ((int[]) buf[29])[0] = rslt.getInt(28);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
              ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
