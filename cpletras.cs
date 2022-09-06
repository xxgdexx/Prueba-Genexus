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
   public class cpletras : GXDataArea
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
            A267LetPPrvCod = GetPar( "LetPPrvCod");
            AssignAttri("", false, "A267LetPPrvCod", A267LetPPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A267LetPPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A266LetPMonCod = (int)(NumberUtil.Val( GetPar( "LetPMonCod"), "."));
            AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrimStr( (decimal)(A266LetPMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A266LetPMonCod) ;
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
            Form.Meta.addItem("description", "Letras por Pagar - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpletras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpletras( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLETRAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Canje", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPLetCod_Internalname, StringUtil.RTrim( A265LetPLetCod), StringUtil.RTrim( context.localUtil.Format( A265LetPLetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPLetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPLetCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Proveedor", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPPrvCod_Internalname, StringUtil.RTrim( A267LetPPrvCod), StringUtil.RTrim( context.localUtil.Format( A267LetPPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha Canje", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLetPLetFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLetPLetFec_Internalname, context.localUtil.Format(A1140LetPLetFec, "99/99/99"), context.localUtil.Format( A1140LetPLetFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPLetFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPLetFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         GxWebStd.gx_bitmap( context, edtLetPLetFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLetPLetFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Forma de Pago", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1136LetPForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetPForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1136LetPForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1136LetPForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Tipo de Cambio", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1145LetPTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtLetPTipCmb_Enabled!=0) ? context.localUtil.Format( A1145LetPTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1145LetPTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Estado", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPSts_Internalname, StringUtil.RTrim( A1143LetPSts), StringUtil.RTrim( context.localUtil.Format( A1143LetPSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Moneda", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A266LetPMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetPMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A266LetPMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A266LetPMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Importe", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A1139LetPImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtLetPImporte_Enabled!=0) ? context.localUtil.Format( A1139LetPImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1139LetPImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Año", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1149LetPVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtLetPVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1149LetPVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1149LetPVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Mes", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1150LetPVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtLetPVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1150LetPVouMes), "Z9") : context.localUtil.Format( (decimal)(A1150LetPVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Tipo Asiento", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1144LetPTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetPTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1144LetPTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1144LetPTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "N° Voucher", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPVouNum_Internalname, StringUtil.RTrim( A1151LetPVouNum), StringUtil.RTrim( context.localUtil.Format( A1151LetPVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Usuario", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPUsuCod_Internalname, StringUtil.RTrim( A1147LetPUsuCod), StringUtil.RTrim( context.localUtil.Format( A1147LetPUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Usuario Fecha", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLetPUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLetPUsuFec_Internalname, context.localUtil.TToC( A1148LetPUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1148LetPUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRAS.htm");
         GxWebStd.gx_bitmap( context, edtLetPUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLetPUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLETRAS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPLETRAS.htm");
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
            Z265LetPLetCod = cgiGet( "Z265LetPLetCod");
            Z1140LetPLetFec = context.localUtil.CToD( cgiGet( "Z1140LetPLetFec"), 0);
            Z1136LetPForCod = (int)(context.localUtil.CToN( cgiGet( "Z1136LetPForCod"), ".", ","));
            Z1145LetPTipCmb = context.localUtil.CToN( cgiGet( "Z1145LetPTipCmb"), ".", ",");
            Z1143LetPSts = cgiGet( "Z1143LetPSts");
            Z1139LetPImporte = context.localUtil.CToN( cgiGet( "Z1139LetPImporte"), ".", ",");
            Z1149LetPVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1149LetPVouAno"), ".", ","));
            Z1150LetPVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1150LetPVouMes"), ".", ","));
            Z1144LetPTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z1144LetPTasiCod"), ".", ","));
            Z1151LetPVouNum = cgiGet( "Z1151LetPVouNum");
            Z1147LetPUsuCod = cgiGet( "Z1147LetPUsuCod");
            Z1148LetPUsuFec = context.localUtil.CToT( cgiGet( "Z1148LetPUsuFec"), 0);
            Z267LetPPrvCod = cgiGet( "Z267LetPPrvCod");
            Z266LetPMonCod = (int)(context.localUtil.CToN( cgiGet( "Z266LetPMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A265LetPLetCod = cgiGet( edtLetPLetCod_Internalname);
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            A267LetPPrvCod = StringUtil.Upper( cgiGet( edtLetPPrvCod_Internalname));
            AssignAttri("", false, "A267LetPPrvCod", A267LetPPrvCod);
            if ( context.localUtil.VCDate( cgiGet( edtLetPLetFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Canje"}), 1, "LETPLETFEC");
               AnyError = 1;
               GX_FocusControl = edtLetPLetFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1140LetPLetFec = DateTime.MinValue;
               AssignAttri("", false, "A1140LetPLetFec", context.localUtil.Format(A1140LetPLetFec, "99/99/99"));
            }
            else
            {
               A1140LetPLetFec = context.localUtil.CToD( cgiGet( edtLetPLetFec_Internalname), 2);
               AssignAttri("", false, "A1140LetPLetFec", context.localUtil.Format(A1140LetPLetFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLetPForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1136LetPForCod = 0;
               AssignAttri("", false, "A1136LetPForCod", StringUtil.LTrimStr( (decimal)(A1136LetPForCod), 6, 0));
            }
            else
            {
               A1136LetPForCod = (int)(context.localUtil.CToN( cgiGet( edtLetPForCod_Internalname), ".", ","));
               AssignAttri("", false, "A1136LetPForCod", StringUtil.LTrimStr( (decimal)(A1136LetPForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtLetPTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1145LetPTipCmb = 0;
               AssignAttri("", false, "A1145LetPTipCmb", StringUtil.LTrimStr( A1145LetPTipCmb, 15, 5));
            }
            else
            {
               A1145LetPTipCmb = context.localUtil.CToN( cgiGet( edtLetPTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1145LetPTipCmb", StringUtil.LTrimStr( A1145LetPTipCmb, 15, 5));
            }
            A1143LetPSts = cgiGet( edtLetPSts_Internalname);
            AssignAttri("", false, "A1143LetPSts", A1143LetPSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtLetPMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A266LetPMonCod = 0;
               AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrimStr( (decimal)(A266LetPMonCod), 6, 0));
            }
            else
            {
               A266LetPMonCod = (int)(context.localUtil.CToN( cgiGet( edtLetPMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrimStr( (decimal)(A266LetPMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtLetPImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1139LetPImporte = 0;
               AssignAttri("", false, "A1139LetPImporte", StringUtil.LTrimStr( A1139LetPImporte, 15, 2));
            }
            else
            {
               A1139LetPImporte = context.localUtil.CToN( cgiGet( edtLetPImporte_Internalname), ".", ",");
               AssignAttri("", false, "A1139LetPImporte", StringUtil.LTrimStr( A1139LetPImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPVOUANO");
               AnyError = 1;
               GX_FocusControl = edtLetPVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1149LetPVouAno = 0;
               AssignAttri("", false, "A1149LetPVouAno", StringUtil.LTrimStr( (decimal)(A1149LetPVouAno), 4, 0));
            }
            else
            {
               A1149LetPVouAno = (short)(context.localUtil.CToN( cgiGet( edtLetPVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1149LetPVouAno", StringUtil.LTrimStr( (decimal)(A1149LetPVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPVOUMES");
               AnyError = 1;
               GX_FocusControl = edtLetPVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1150LetPVouMes = 0;
               AssignAttri("", false, "A1150LetPVouMes", StringUtil.LTrimStr( (decimal)(A1150LetPVouMes), 2, 0));
            }
            else
            {
               A1150LetPVouMes = (short)(context.localUtil.CToN( cgiGet( edtLetPVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1150LetPVouMes", StringUtil.LTrimStr( (decimal)(A1150LetPVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPTASICOD");
               AnyError = 1;
               GX_FocusControl = edtLetPTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1144LetPTasiCod = 0;
               AssignAttri("", false, "A1144LetPTasiCod", StringUtil.LTrimStr( (decimal)(A1144LetPTasiCod), 6, 0));
            }
            else
            {
               A1144LetPTasiCod = (int)(context.localUtil.CToN( cgiGet( edtLetPTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A1144LetPTasiCod", StringUtil.LTrimStr( (decimal)(A1144LetPTasiCod), 6, 0));
            }
            A1151LetPVouNum = cgiGet( edtLetPVouNum_Internalname);
            AssignAttri("", false, "A1151LetPVouNum", A1151LetPVouNum);
            A1147LetPUsuCod = cgiGet( edtLetPUsuCod_Internalname);
            AssignAttri("", false, "A1147LetPUsuCod", A1147LetPUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtLetPUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "LETPUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtLetPUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1148LetPUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1148LetPUsuFec", context.localUtil.TToC( A1148LetPUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1148LetPUsuFec = context.localUtil.CToT( cgiGet( edtLetPUsuFec_Internalname));
               AssignAttri("", false, "A1148LetPUsuFec", context.localUtil.TToC( A1148LetPUsuFec, 8, 5, 0, 3, "/", ":", " "));
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
               A265LetPLetCod = GetPar( "LetPLetCod");
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
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
               InitAll3A113( ) ;
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
         DisableAttributes3A113( ) ;
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

      protected void CONFIRM_3A0( )
      {
         BeforeValidate3A113( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3A113( ) ;
            }
            else
            {
               CheckExtendedTable3A113( ) ;
               if ( AnyError == 0 )
               {
                  ZM3A113( 4) ;
                  ZM3A113( 5) ;
               }
               CloseExtendedTableCursors3A113( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3A0( ) ;
         }
      }

      protected void ResetCaption3A0( )
      {
      }

      protected void ZM3A113( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1140LetPLetFec = T003A3_A1140LetPLetFec[0];
               Z1136LetPForCod = T003A3_A1136LetPForCod[0];
               Z1145LetPTipCmb = T003A3_A1145LetPTipCmb[0];
               Z1143LetPSts = T003A3_A1143LetPSts[0];
               Z1139LetPImporte = T003A3_A1139LetPImporte[0];
               Z1149LetPVouAno = T003A3_A1149LetPVouAno[0];
               Z1150LetPVouMes = T003A3_A1150LetPVouMes[0];
               Z1144LetPTasiCod = T003A3_A1144LetPTasiCod[0];
               Z1151LetPVouNum = T003A3_A1151LetPVouNum[0];
               Z1147LetPUsuCod = T003A3_A1147LetPUsuCod[0];
               Z1148LetPUsuFec = T003A3_A1148LetPUsuFec[0];
               Z267LetPPrvCod = T003A3_A267LetPPrvCod[0];
               Z266LetPMonCod = T003A3_A266LetPMonCod[0];
            }
            else
            {
               Z1140LetPLetFec = A1140LetPLetFec;
               Z1136LetPForCod = A1136LetPForCod;
               Z1145LetPTipCmb = A1145LetPTipCmb;
               Z1143LetPSts = A1143LetPSts;
               Z1139LetPImporte = A1139LetPImporte;
               Z1149LetPVouAno = A1149LetPVouAno;
               Z1150LetPVouMes = A1150LetPVouMes;
               Z1144LetPTasiCod = A1144LetPTasiCod;
               Z1151LetPVouNum = A1151LetPVouNum;
               Z1147LetPUsuCod = A1147LetPUsuCod;
               Z1148LetPUsuFec = A1148LetPUsuFec;
               Z267LetPPrvCod = A267LetPPrvCod;
               Z266LetPMonCod = A266LetPMonCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z265LetPLetCod = A265LetPLetCod;
            Z1140LetPLetFec = A1140LetPLetFec;
            Z1136LetPForCod = A1136LetPForCod;
            Z1145LetPTipCmb = A1145LetPTipCmb;
            Z1143LetPSts = A1143LetPSts;
            Z1139LetPImporte = A1139LetPImporte;
            Z1149LetPVouAno = A1149LetPVouAno;
            Z1150LetPVouMes = A1150LetPVouMes;
            Z1144LetPTasiCod = A1144LetPTasiCod;
            Z1151LetPVouNum = A1151LetPVouNum;
            Z1147LetPUsuCod = A1147LetPUsuCod;
            Z1148LetPUsuFec = A1148LetPUsuFec;
            Z267LetPPrvCod = A267LetPPrvCod;
            Z266LetPMonCod = A266LetPMonCod;
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

      protected void Load3A113( )
      {
         /* Using cursor T003A6 */
         pr_default.execute(4, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound113 = 1;
            A1140LetPLetFec = T003A6_A1140LetPLetFec[0];
            AssignAttri("", false, "A1140LetPLetFec", context.localUtil.Format(A1140LetPLetFec, "99/99/99"));
            A1136LetPForCod = T003A6_A1136LetPForCod[0];
            AssignAttri("", false, "A1136LetPForCod", StringUtil.LTrimStr( (decimal)(A1136LetPForCod), 6, 0));
            A1145LetPTipCmb = T003A6_A1145LetPTipCmb[0];
            AssignAttri("", false, "A1145LetPTipCmb", StringUtil.LTrimStr( A1145LetPTipCmb, 15, 5));
            A1143LetPSts = T003A6_A1143LetPSts[0];
            AssignAttri("", false, "A1143LetPSts", A1143LetPSts);
            A1139LetPImporte = T003A6_A1139LetPImporte[0];
            AssignAttri("", false, "A1139LetPImporte", StringUtil.LTrimStr( A1139LetPImporte, 15, 2));
            A1149LetPVouAno = T003A6_A1149LetPVouAno[0];
            AssignAttri("", false, "A1149LetPVouAno", StringUtil.LTrimStr( (decimal)(A1149LetPVouAno), 4, 0));
            A1150LetPVouMes = T003A6_A1150LetPVouMes[0];
            AssignAttri("", false, "A1150LetPVouMes", StringUtil.LTrimStr( (decimal)(A1150LetPVouMes), 2, 0));
            A1144LetPTasiCod = T003A6_A1144LetPTasiCod[0];
            AssignAttri("", false, "A1144LetPTasiCod", StringUtil.LTrimStr( (decimal)(A1144LetPTasiCod), 6, 0));
            A1151LetPVouNum = T003A6_A1151LetPVouNum[0];
            AssignAttri("", false, "A1151LetPVouNum", A1151LetPVouNum);
            A1147LetPUsuCod = T003A6_A1147LetPUsuCod[0];
            AssignAttri("", false, "A1147LetPUsuCod", A1147LetPUsuCod);
            A1148LetPUsuFec = T003A6_A1148LetPUsuFec[0];
            AssignAttri("", false, "A1148LetPUsuFec", context.localUtil.TToC( A1148LetPUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A267LetPPrvCod = T003A6_A267LetPPrvCod[0];
            AssignAttri("", false, "A267LetPPrvCod", A267LetPPrvCod);
            A266LetPMonCod = T003A6_A266LetPMonCod[0];
            AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrimStr( (decimal)(A266LetPMonCod), 6, 0));
            ZM3A113( -3) ;
         }
         pr_default.close(4);
         OnLoadActions3A113( ) ;
      }

      protected void OnLoadActions3A113( )
      {
      }

      protected void CheckExtendedTable3A113( )
      {
         nIsDirty_113 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003A4 */
         pr_default.execute(2, new Object[] {A267LetPPrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "LETPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1140LetPLetFec) || ( DateTimeUtil.ResetTime ( A1140LetPLetFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Canje fuera de rango", "OutOfRange", 1, "LETPLETFEC");
            AnyError = 1;
            GX_FocusControl = edtLetPLetFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003A5 */
         pr_default.execute(3, new Object[] {A266LetPMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LETPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1148LetPUsuFec) || ( A1148LetPUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "LETPUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtLetPUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3A113( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A267LetPPrvCod )
      {
         /* Using cursor T003A7 */
         pr_default.execute(5, new Object[] {A267LetPPrvCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "LETPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPPrvCod_Internalname;
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

      protected void gxLoad_5( int A266LetPMonCod )
      {
         /* Using cursor T003A8 */
         pr_default.execute(6, new Object[] {A266LetPMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LETPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPMonCod_Internalname;
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

      protected void GetKey3A113( )
      {
         /* Using cursor T003A9 */
         pr_default.execute(7, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound113 = 1;
         }
         else
         {
            RcdFound113 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003A3 */
         pr_default.execute(1, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3A113( 3) ;
            RcdFound113 = 1;
            A265LetPLetCod = T003A3_A265LetPLetCod[0];
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            A1140LetPLetFec = T003A3_A1140LetPLetFec[0];
            AssignAttri("", false, "A1140LetPLetFec", context.localUtil.Format(A1140LetPLetFec, "99/99/99"));
            A1136LetPForCod = T003A3_A1136LetPForCod[0];
            AssignAttri("", false, "A1136LetPForCod", StringUtil.LTrimStr( (decimal)(A1136LetPForCod), 6, 0));
            A1145LetPTipCmb = T003A3_A1145LetPTipCmb[0];
            AssignAttri("", false, "A1145LetPTipCmb", StringUtil.LTrimStr( A1145LetPTipCmb, 15, 5));
            A1143LetPSts = T003A3_A1143LetPSts[0];
            AssignAttri("", false, "A1143LetPSts", A1143LetPSts);
            A1139LetPImporte = T003A3_A1139LetPImporte[0];
            AssignAttri("", false, "A1139LetPImporte", StringUtil.LTrimStr( A1139LetPImporte, 15, 2));
            A1149LetPVouAno = T003A3_A1149LetPVouAno[0];
            AssignAttri("", false, "A1149LetPVouAno", StringUtil.LTrimStr( (decimal)(A1149LetPVouAno), 4, 0));
            A1150LetPVouMes = T003A3_A1150LetPVouMes[0];
            AssignAttri("", false, "A1150LetPVouMes", StringUtil.LTrimStr( (decimal)(A1150LetPVouMes), 2, 0));
            A1144LetPTasiCod = T003A3_A1144LetPTasiCod[0];
            AssignAttri("", false, "A1144LetPTasiCod", StringUtil.LTrimStr( (decimal)(A1144LetPTasiCod), 6, 0));
            A1151LetPVouNum = T003A3_A1151LetPVouNum[0];
            AssignAttri("", false, "A1151LetPVouNum", A1151LetPVouNum);
            A1147LetPUsuCod = T003A3_A1147LetPUsuCod[0];
            AssignAttri("", false, "A1147LetPUsuCod", A1147LetPUsuCod);
            A1148LetPUsuFec = T003A3_A1148LetPUsuFec[0];
            AssignAttri("", false, "A1148LetPUsuFec", context.localUtil.TToC( A1148LetPUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A267LetPPrvCod = T003A3_A267LetPPrvCod[0];
            AssignAttri("", false, "A267LetPPrvCod", A267LetPPrvCod);
            A266LetPMonCod = T003A3_A266LetPMonCod[0];
            AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrimStr( (decimal)(A266LetPMonCod), 6, 0));
            Z265LetPLetCod = A265LetPLetCod;
            sMode113 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3A113( ) ;
            if ( AnyError == 1 )
            {
               RcdFound113 = 0;
               InitializeNonKey3A113( ) ;
            }
            Gx_mode = sMode113;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound113 = 0;
            InitializeNonKey3A113( ) ;
            sMode113 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode113;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3A113( ) ;
         if ( RcdFound113 == 0 )
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
         RcdFound113 = 0;
         /* Using cursor T003A10 */
         pr_default.execute(8, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003A10_A265LetPLetCod[0], A265LetPLetCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003A10_A265LetPLetCod[0], A265LetPLetCod) > 0 ) ) )
            {
               A265LetPLetCod = T003A10_A265LetPLetCod[0];
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
               RcdFound113 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound113 = 0;
         /* Using cursor T003A11 */
         pr_default.execute(9, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003A11_A265LetPLetCod[0], A265LetPLetCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003A11_A265LetPLetCod[0], A265LetPLetCod) < 0 ) ) )
            {
               A265LetPLetCod = T003A11_A265LetPLetCod[0];
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
               RcdFound113 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3A113( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3A113( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound113 == 1 )
            {
               if ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 )
               {
                  A265LetPLetCod = Z265LetPLetCod;
                  AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LETPLETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLetPLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLetPLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3A113( ) ;
                  GX_FocusControl = edtLetPLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLetPLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3A113( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LETPLETCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLetPLetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLetPLetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3A113( ) ;
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
         if ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 )
         {
            A265LetPLetCod = Z265LetPLetCod;
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLetPLetCod_Internalname;
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
         GetKey3A113( ) ;
         if ( RcdFound113 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LETPLETCOD");
               AnyError = 1;
               GX_FocusControl = edtLetPLetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 )
            {
               A265LetPLetCod = Z265LetPLetCod;
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LETPLETCOD");
               AnyError = 1;
               GX_FocusControl = edtLetPLetCod_Internalname;
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
            if ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LETPLETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLetPLetCod_Internalname;
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
         context.RollbackDataStores("cpletras",pr_default);
         GX_FocusControl = edtLetPPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3A0( ) ;
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
         if ( RcdFound113 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLetPPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3A113( ) ;
         if ( RcdFound113 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3A113( ) ;
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
         if ( RcdFound113 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPPrvCod_Internalname;
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
         if ( RcdFound113 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPPrvCod_Internalname;
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
         ScanStart3A113( ) ;
         if ( RcdFound113 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound113 != 0 )
            {
               ScanNext3A113( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3A113( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3A113( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003A2 */
            pr_default.execute(0, new Object[] {A265LetPLetCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLETRAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1140LetPLetFec ) != DateTimeUtil.ResetTime ( T003A2_A1140LetPLetFec[0] ) ) || ( Z1136LetPForCod != T003A2_A1136LetPForCod[0] ) || ( Z1145LetPTipCmb != T003A2_A1145LetPTipCmb[0] ) || ( StringUtil.StrCmp(Z1143LetPSts, T003A2_A1143LetPSts[0]) != 0 ) || ( Z1139LetPImporte != T003A2_A1139LetPImporte[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1149LetPVouAno != T003A2_A1149LetPVouAno[0] ) || ( Z1150LetPVouMes != T003A2_A1150LetPVouMes[0] ) || ( Z1144LetPTasiCod != T003A2_A1144LetPTasiCod[0] ) || ( StringUtil.StrCmp(Z1151LetPVouNum, T003A2_A1151LetPVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1147LetPUsuCod, T003A2_A1147LetPUsuCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1148LetPUsuFec != T003A2_A1148LetPUsuFec[0] ) || ( StringUtil.StrCmp(Z267LetPPrvCod, T003A2_A267LetPPrvCod[0]) != 0 ) || ( Z266LetPMonCod != T003A2_A266LetPMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1140LetPLetFec ) != DateTimeUtil.ResetTime ( T003A2_A1140LetPLetFec[0] ) )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPLetFec");
                  GXUtil.WriteLogRaw("Old: ",Z1140LetPLetFec);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1140LetPLetFec[0]);
               }
               if ( Z1136LetPForCod != T003A2_A1136LetPForCod[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPForCod");
                  GXUtil.WriteLogRaw("Old: ",Z1136LetPForCod);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1136LetPForCod[0]);
               }
               if ( Z1145LetPTipCmb != T003A2_A1145LetPTipCmb[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1145LetPTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1145LetPTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z1143LetPSts, T003A2_A1143LetPSts[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPSts");
                  GXUtil.WriteLogRaw("Old: ",Z1143LetPSts);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1143LetPSts[0]);
               }
               if ( Z1139LetPImporte != T003A2_A1139LetPImporte[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPImporte");
                  GXUtil.WriteLogRaw("Old: ",Z1139LetPImporte);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1139LetPImporte[0]);
               }
               if ( Z1149LetPVouAno != T003A2_A1149LetPVouAno[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1149LetPVouAno);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1149LetPVouAno[0]);
               }
               if ( Z1150LetPVouMes != T003A2_A1150LetPVouMes[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1150LetPVouMes);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1150LetPVouMes[0]);
               }
               if ( Z1144LetPTasiCod != T003A2_A1144LetPTasiCod[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z1144LetPTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1144LetPTasiCod[0]);
               }
               if ( StringUtil.StrCmp(Z1151LetPVouNum, T003A2_A1151LetPVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1151LetPVouNum);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1151LetPVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1147LetPUsuCod, T003A2_A1147LetPUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1147LetPUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1147LetPUsuCod[0]);
               }
               if ( Z1148LetPUsuFec != T003A2_A1148LetPUsuFec[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1148LetPUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A1148LetPUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z267LetPPrvCod, T003A2_A267LetPPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z267LetPPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A267LetPPrvCod[0]);
               }
               if ( Z266LetPMonCod != T003A2_A266LetPMonCod[0] )
               {
                  GXUtil.WriteLog("cpletras:[seudo value changed for attri]"+"LetPMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z266LetPMonCod);
                  GXUtil.WriteLogRaw("Current: ",T003A2_A266LetPMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLETRAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3A113( )
      {
         BeforeValidate3A113( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3A113( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3A113( 0) ;
            CheckOptimisticConcurrency3A113( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3A113( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3A113( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003A12 */
                     pr_default.execute(10, new Object[] {A265LetPLetCod, A1140LetPLetFec, A1136LetPForCod, A1145LetPTipCmb, A1143LetPSts, A1139LetPImporte, A1149LetPVouAno, A1150LetPVouMes, A1144LetPTasiCod, A1151LetPVouNum, A1147LetPUsuCod, A1148LetPUsuFec, A267LetPPrvCod, A266LetPMonCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLETRAS");
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
                           ResetCaption3A0( ) ;
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
               Load3A113( ) ;
            }
            EndLevel3A113( ) ;
         }
         CloseExtendedTableCursors3A113( ) ;
      }

      protected void Update3A113( )
      {
         BeforeValidate3A113( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3A113( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3A113( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3A113( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3A113( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003A13 */
                     pr_default.execute(11, new Object[] {A1140LetPLetFec, A1136LetPForCod, A1145LetPTipCmb, A1143LetPSts, A1139LetPImporte, A1149LetPVouAno, A1150LetPVouMes, A1144LetPTasiCod, A1151LetPVouNum, A1147LetPUsuCod, A1148LetPUsuFec, A267LetPPrvCod, A266LetPMonCod, A265LetPLetCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLETRAS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLETRAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3A113( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3A0( ) ;
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
            EndLevel3A113( ) ;
         }
         CloseExtendedTableCursors3A113( ) ;
      }

      protected void DeferredUpdate3A113( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3A113( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3A113( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3A113( ) ;
            AfterConfirm3A113( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3A113( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003A14 */
                  pr_default.execute(12, new Object[] {A265LetPLetCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLETRAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound113 == 0 )
                        {
                           InitAll3A113( ) ;
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
                        ResetCaption3A0( ) ;
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
         sMode113 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3A113( ) ;
         Gx_mode = sMode113;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3A113( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003A15 */
            pr_default.execute(13, new Object[] {A265LetPLetCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel3A113( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3A113( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpletras",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpletras",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3A113( )
      {
         /* Using cursor T003A16 */
         pr_default.execute(14);
         RcdFound113 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound113 = 1;
            A265LetPLetCod = T003A16_A265LetPLetCod[0];
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3A113( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound113 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound113 = 1;
            A265LetPLetCod = T003A16_A265LetPLetCod[0];
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
         }
      }

      protected void ScanEnd3A113( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm3A113( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3A113( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3A113( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3A113( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3A113( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3A113( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3A113( )
      {
         edtLetPLetCod_Enabled = 0;
         AssignProp("", false, edtLetPLetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPLetCod_Enabled), 5, 0), true);
         edtLetPPrvCod_Enabled = 0;
         AssignProp("", false, edtLetPPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPPrvCod_Enabled), 5, 0), true);
         edtLetPLetFec_Enabled = 0;
         AssignProp("", false, edtLetPLetFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPLetFec_Enabled), 5, 0), true);
         edtLetPForCod_Enabled = 0;
         AssignProp("", false, edtLetPForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPForCod_Enabled), 5, 0), true);
         edtLetPTipCmb_Enabled = 0;
         AssignProp("", false, edtLetPTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPTipCmb_Enabled), 5, 0), true);
         edtLetPSts_Enabled = 0;
         AssignProp("", false, edtLetPSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPSts_Enabled), 5, 0), true);
         edtLetPMonCod_Enabled = 0;
         AssignProp("", false, edtLetPMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPMonCod_Enabled), 5, 0), true);
         edtLetPImporte_Enabled = 0;
         AssignProp("", false, edtLetPImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPImporte_Enabled), 5, 0), true);
         edtLetPVouAno_Enabled = 0;
         AssignProp("", false, edtLetPVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPVouAno_Enabled), 5, 0), true);
         edtLetPVouMes_Enabled = 0;
         AssignProp("", false, edtLetPVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPVouMes_Enabled), 5, 0), true);
         edtLetPTasiCod_Enabled = 0;
         AssignProp("", false, edtLetPTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPTasiCod_Enabled), 5, 0), true);
         edtLetPVouNum_Enabled = 0;
         AssignProp("", false, edtLetPVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPVouNum_Enabled), 5, 0), true);
         edtLetPUsuCod_Enabled = 0;
         AssignProp("", false, edtLetPUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPUsuCod_Enabled), 5, 0), true);
         edtLetPUsuFec_Enabled = 0;
         AssignProp("", false, edtLetPUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPUsuFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3A113( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025013", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpletras.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z265LetPLetCod", StringUtil.RTrim( Z265LetPLetCod));
         GxWebStd.gx_hidden_field( context, "Z1140LetPLetFec", context.localUtil.DToC( Z1140LetPLetFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1136LetPForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1136LetPForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1145LetPTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1145LetPTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1143LetPSts", StringUtil.RTrim( Z1143LetPSts));
         GxWebStd.gx_hidden_field( context, "Z1139LetPImporte", StringUtil.LTrim( StringUtil.NToC( Z1139LetPImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1149LetPVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1149LetPVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1150LetPVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1150LetPVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1144LetPTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1144LetPTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1151LetPVouNum", StringUtil.RTrim( Z1151LetPVouNum));
         GxWebStd.gx_hidden_field( context, "Z1147LetPUsuCod", StringUtil.RTrim( Z1147LetPUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1148LetPUsuFec", context.localUtil.TToC( Z1148LetPUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z267LetPPrvCod", StringUtil.RTrim( Z267LetPPrvCod));
         GxWebStd.gx_hidden_field( context, "Z266LetPMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z266LetPMonCod), 6, 0, ".", "")));
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
         return formatLink("cpletras.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLETRAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Letras por Pagar - Cabecera" ;
      }

      protected void InitializeNonKey3A113( )
      {
         A267LetPPrvCod = "";
         AssignAttri("", false, "A267LetPPrvCod", A267LetPPrvCod);
         A1140LetPLetFec = DateTime.MinValue;
         AssignAttri("", false, "A1140LetPLetFec", context.localUtil.Format(A1140LetPLetFec, "99/99/99"));
         A1136LetPForCod = 0;
         AssignAttri("", false, "A1136LetPForCod", StringUtil.LTrimStr( (decimal)(A1136LetPForCod), 6, 0));
         A1145LetPTipCmb = 0;
         AssignAttri("", false, "A1145LetPTipCmb", StringUtil.LTrimStr( A1145LetPTipCmb, 15, 5));
         A1143LetPSts = "";
         AssignAttri("", false, "A1143LetPSts", A1143LetPSts);
         A266LetPMonCod = 0;
         AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrimStr( (decimal)(A266LetPMonCod), 6, 0));
         A1139LetPImporte = 0;
         AssignAttri("", false, "A1139LetPImporte", StringUtil.LTrimStr( A1139LetPImporte, 15, 2));
         A1149LetPVouAno = 0;
         AssignAttri("", false, "A1149LetPVouAno", StringUtil.LTrimStr( (decimal)(A1149LetPVouAno), 4, 0));
         A1150LetPVouMes = 0;
         AssignAttri("", false, "A1150LetPVouMes", StringUtil.LTrimStr( (decimal)(A1150LetPVouMes), 2, 0));
         A1144LetPTasiCod = 0;
         AssignAttri("", false, "A1144LetPTasiCod", StringUtil.LTrimStr( (decimal)(A1144LetPTasiCod), 6, 0));
         A1151LetPVouNum = "";
         AssignAttri("", false, "A1151LetPVouNum", A1151LetPVouNum);
         A1147LetPUsuCod = "";
         AssignAttri("", false, "A1147LetPUsuCod", A1147LetPUsuCod);
         A1148LetPUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1148LetPUsuFec", context.localUtil.TToC( A1148LetPUsuFec, 8, 5, 0, 3, "/", ":", " "));
         Z1140LetPLetFec = DateTime.MinValue;
         Z1136LetPForCod = 0;
         Z1145LetPTipCmb = 0;
         Z1143LetPSts = "";
         Z1139LetPImporte = 0;
         Z1149LetPVouAno = 0;
         Z1150LetPVouMes = 0;
         Z1144LetPTasiCod = 0;
         Z1151LetPVouNum = "";
         Z1147LetPUsuCod = "";
         Z1148LetPUsuFec = (DateTime)(DateTime.MinValue);
         Z267LetPPrvCod = "";
         Z266LetPMonCod = 0;
      }

      protected void InitAll3A113( )
      {
         A265LetPLetCod = "";
         AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
         InitializeNonKey3A113( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025023", true, true);
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
         context.AddJavascriptSource("cpletras.js", "?20228181025024", false, true);
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
         edtLetPLetCod_Internalname = "LETPLETCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLetPPrvCod_Internalname = "LETPPRVCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLetPLetFec_Internalname = "LETPLETFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLetPForCod_Internalname = "LETPFORCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLetPTipCmb_Internalname = "LETPTIPCMB";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLetPSts_Internalname = "LETPSTS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLetPMonCod_Internalname = "LETPMONCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtLetPImporte_Internalname = "LETPIMPORTE";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLetPVouAno_Internalname = "LETPVOUANO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtLetPVouMes_Internalname = "LETPVOUMES";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtLetPTasiCod_Internalname = "LETPTASICOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtLetPVouNum_Internalname = "LETPVOUNUM";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtLetPUsuCod_Internalname = "LETPUSUCOD";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtLetPUsuFec_Internalname = "LETPUSUFEC";
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
         Form.Caption = "Letras por Pagar - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLetPUsuFec_Jsonclick = "";
         edtLetPUsuFec_Enabled = 1;
         edtLetPUsuCod_Jsonclick = "";
         edtLetPUsuCod_Enabled = 1;
         edtLetPVouNum_Jsonclick = "";
         edtLetPVouNum_Enabled = 1;
         edtLetPTasiCod_Jsonclick = "";
         edtLetPTasiCod_Enabled = 1;
         edtLetPVouMes_Jsonclick = "";
         edtLetPVouMes_Enabled = 1;
         edtLetPVouAno_Jsonclick = "";
         edtLetPVouAno_Enabled = 1;
         edtLetPImporte_Jsonclick = "";
         edtLetPImporte_Enabled = 1;
         edtLetPMonCod_Jsonclick = "";
         edtLetPMonCod_Enabled = 1;
         edtLetPSts_Jsonclick = "";
         edtLetPSts_Enabled = 1;
         edtLetPTipCmb_Jsonclick = "";
         edtLetPTipCmb_Enabled = 1;
         edtLetPForCod_Jsonclick = "";
         edtLetPForCod_Enabled = 1;
         edtLetPLetFec_Jsonclick = "";
         edtLetPLetFec_Enabled = 1;
         edtLetPPrvCod_Jsonclick = "";
         edtLetPPrvCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLetPLetCod_Jsonclick = "";
         edtLetPLetCod_Enabled = 1;
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
         GX_FocusControl = edtLetPPrvCod_Internalname;
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

      public void Valid_Letpletcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A267LetPPrvCod", StringUtil.RTrim( A267LetPPrvCod));
         AssignAttri("", false, "A1140LetPLetFec", context.localUtil.Format(A1140LetPLetFec, "99/99/99"));
         AssignAttri("", false, "A1136LetPForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1136LetPForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1145LetPTipCmb", StringUtil.LTrim( StringUtil.NToC( A1145LetPTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A1143LetPSts", StringUtil.RTrim( A1143LetPSts));
         AssignAttri("", false, "A266LetPMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A266LetPMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1139LetPImporte", StringUtil.LTrim( StringUtil.NToC( A1139LetPImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A1149LetPVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1149LetPVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1150LetPVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1150LetPVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1144LetPTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1144LetPTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1151LetPVouNum", StringUtil.RTrim( A1151LetPVouNum));
         AssignAttri("", false, "A1147LetPUsuCod", StringUtil.RTrim( A1147LetPUsuCod));
         AssignAttri("", false, "A1148LetPUsuFec", context.localUtil.TToC( A1148LetPUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z265LetPLetCod", StringUtil.RTrim( Z265LetPLetCod));
         GxWebStd.gx_hidden_field( context, "Z267LetPPrvCod", StringUtil.RTrim( Z267LetPPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1140LetPLetFec", context.localUtil.Format(Z1140LetPLetFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1136LetPForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1136LetPForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1145LetPTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1145LetPTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1143LetPSts", StringUtil.RTrim( Z1143LetPSts));
         GxWebStd.gx_hidden_field( context, "Z266LetPMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z266LetPMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1139LetPImporte", StringUtil.LTrim( StringUtil.NToC( Z1139LetPImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1149LetPVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1149LetPVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1150LetPVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1150LetPVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1144LetPTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1144LetPTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1151LetPVouNum", StringUtil.RTrim( Z1151LetPVouNum));
         GxWebStd.gx_hidden_field( context, "Z1147LetPUsuCod", StringUtil.RTrim( Z1147LetPUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1148LetPUsuFec", context.localUtil.TToC( Z1148LetPUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Letpprvcod( )
      {
         /* Using cursor T003A17 */
         pr_default.execute(15, new Object[] {A267LetPPrvCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "LETPPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPPrvCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Letpmoncod( )
      {
         /* Using cursor T003A18 */
         pr_default.execute(16, new Object[] {A266LetPMonCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LETPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPMonCod_Internalname;
         }
         pr_default.close(16);
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
         setEventMetadata("VALID_LETPLETCOD","{handler:'Valid_Letpletcod',iparms:[{av:'A265LetPLetCod',fld:'LETPLETCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LETPLETCOD",",oparms:[{av:'A267LetPPrvCod',fld:'LETPPRVCOD',pic:'@!'},{av:'A1140LetPLetFec',fld:'LETPLETFEC',pic:''},{av:'A1136LetPForCod',fld:'LETPFORCOD',pic:'ZZZZZ9'},{av:'A1145LetPTipCmb',fld:'LETPTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1143LetPSts',fld:'LETPSTS',pic:''},{av:'A266LetPMonCod',fld:'LETPMONCOD',pic:'ZZZZZ9'},{av:'A1139LetPImporte',fld:'LETPIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1149LetPVouAno',fld:'LETPVOUANO',pic:'ZZZ9'},{av:'A1150LetPVouMes',fld:'LETPVOUMES',pic:'Z9'},{av:'A1144LetPTasiCod',fld:'LETPTASICOD',pic:'ZZZZZ9'},{av:'A1151LetPVouNum',fld:'LETPVOUNUM',pic:''},{av:'A1147LetPUsuCod',fld:'LETPUSUCOD',pic:''},{av:'A1148LetPUsuFec',fld:'LETPUSUFEC',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z265LetPLetCod'},{av:'Z267LetPPrvCod'},{av:'Z1140LetPLetFec'},{av:'Z1136LetPForCod'},{av:'Z1145LetPTipCmb'},{av:'Z1143LetPSts'},{av:'Z266LetPMonCod'},{av:'Z1139LetPImporte'},{av:'Z1149LetPVouAno'},{av:'Z1150LetPVouMes'},{av:'Z1144LetPTasiCod'},{av:'Z1151LetPVouNum'},{av:'Z1147LetPUsuCod'},{av:'Z1148LetPUsuFec'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_LETPPRVCOD","{handler:'Valid_Letpprvcod',iparms:[{av:'A267LetPPrvCod',fld:'LETPPRVCOD',pic:'@!'}]");
         setEventMetadata("VALID_LETPPRVCOD",",oparms:[]}");
         setEventMetadata("VALID_LETPLETFEC","{handler:'Valid_Letpletfec',iparms:[]");
         setEventMetadata("VALID_LETPLETFEC",",oparms:[]}");
         setEventMetadata("VALID_LETPMONCOD","{handler:'Valid_Letpmoncod',iparms:[{av:'A266LetPMonCod',fld:'LETPMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LETPMONCOD",",oparms:[]}");
         setEventMetadata("VALID_LETPUSUFEC","{handler:'Valid_Letpusufec',iparms:[]");
         setEventMetadata("VALID_LETPUSUFEC",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z265LetPLetCod = "";
         Z1140LetPLetFec = DateTime.MinValue;
         Z1143LetPSts = "";
         Z1151LetPVouNum = "";
         Z1147LetPUsuCod = "";
         Z1148LetPUsuFec = (DateTime)(DateTime.MinValue);
         Z267LetPPrvCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A267LetPPrvCod = "";
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
         A265LetPLetCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A1140LetPLetFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A1143LetPSts = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A1151LetPVouNum = "";
         lblTextblock13_Jsonclick = "";
         A1147LetPUsuCod = "";
         lblTextblock14_Jsonclick = "";
         A1148LetPUsuFec = (DateTime)(DateTime.MinValue);
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
         T003A6_A265LetPLetCod = new string[] {""} ;
         T003A6_A1140LetPLetFec = new DateTime[] {DateTime.MinValue} ;
         T003A6_A1136LetPForCod = new int[1] ;
         T003A6_A1145LetPTipCmb = new decimal[1] ;
         T003A6_A1143LetPSts = new string[] {""} ;
         T003A6_A1139LetPImporte = new decimal[1] ;
         T003A6_A1149LetPVouAno = new short[1] ;
         T003A6_A1150LetPVouMes = new short[1] ;
         T003A6_A1144LetPTasiCod = new int[1] ;
         T003A6_A1151LetPVouNum = new string[] {""} ;
         T003A6_A1147LetPUsuCod = new string[] {""} ;
         T003A6_A1148LetPUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003A6_A267LetPPrvCod = new string[] {""} ;
         T003A6_A266LetPMonCod = new int[1] ;
         T003A4_A267LetPPrvCod = new string[] {""} ;
         T003A5_A266LetPMonCod = new int[1] ;
         T003A7_A267LetPPrvCod = new string[] {""} ;
         T003A8_A266LetPMonCod = new int[1] ;
         T003A9_A265LetPLetCod = new string[] {""} ;
         T003A3_A265LetPLetCod = new string[] {""} ;
         T003A3_A1140LetPLetFec = new DateTime[] {DateTime.MinValue} ;
         T003A3_A1136LetPForCod = new int[1] ;
         T003A3_A1145LetPTipCmb = new decimal[1] ;
         T003A3_A1143LetPSts = new string[] {""} ;
         T003A3_A1139LetPImporte = new decimal[1] ;
         T003A3_A1149LetPVouAno = new short[1] ;
         T003A3_A1150LetPVouMes = new short[1] ;
         T003A3_A1144LetPTasiCod = new int[1] ;
         T003A3_A1151LetPVouNum = new string[] {""} ;
         T003A3_A1147LetPUsuCod = new string[] {""} ;
         T003A3_A1148LetPUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003A3_A267LetPPrvCod = new string[] {""} ;
         T003A3_A266LetPMonCod = new int[1] ;
         sMode113 = "";
         T003A10_A265LetPLetCod = new string[] {""} ;
         T003A11_A265LetPLetCod = new string[] {""} ;
         T003A2_A265LetPLetCod = new string[] {""} ;
         T003A2_A1140LetPLetFec = new DateTime[] {DateTime.MinValue} ;
         T003A2_A1136LetPForCod = new int[1] ;
         T003A2_A1145LetPTipCmb = new decimal[1] ;
         T003A2_A1143LetPSts = new string[] {""} ;
         T003A2_A1139LetPImporte = new decimal[1] ;
         T003A2_A1149LetPVouAno = new short[1] ;
         T003A2_A1150LetPVouMes = new short[1] ;
         T003A2_A1144LetPTasiCod = new int[1] ;
         T003A2_A1151LetPVouNum = new string[] {""} ;
         T003A2_A1147LetPUsuCod = new string[] {""} ;
         T003A2_A1148LetPUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003A2_A267LetPPrvCod = new string[] {""} ;
         T003A2_A266LetPMonCod = new int[1] ;
         T003A15_A265LetPLetCod = new string[] {""} ;
         T003A15_A268LetPItem = new int[1] ;
         T003A16_A265LetPLetCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ265LetPLetCod = "";
         ZZ267LetPPrvCod = "";
         ZZ1140LetPLetFec = DateTime.MinValue;
         ZZ1143LetPSts = "";
         ZZ1151LetPVouNum = "";
         ZZ1147LetPUsuCod = "";
         ZZ1148LetPUsuFec = (DateTime)(DateTime.MinValue);
         T003A17_A267LetPPrvCod = new string[] {""} ;
         T003A18_A266LetPMonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpletras__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpletras__default(),
            new Object[][] {
                new Object[] {
               T003A2_A265LetPLetCod, T003A2_A1140LetPLetFec, T003A2_A1136LetPForCod, T003A2_A1145LetPTipCmb, T003A2_A1143LetPSts, T003A2_A1139LetPImporte, T003A2_A1149LetPVouAno, T003A2_A1150LetPVouMes, T003A2_A1144LetPTasiCod, T003A2_A1151LetPVouNum,
               T003A2_A1147LetPUsuCod, T003A2_A1148LetPUsuFec, T003A2_A267LetPPrvCod, T003A2_A266LetPMonCod
               }
               , new Object[] {
               T003A3_A265LetPLetCod, T003A3_A1140LetPLetFec, T003A3_A1136LetPForCod, T003A3_A1145LetPTipCmb, T003A3_A1143LetPSts, T003A3_A1139LetPImporte, T003A3_A1149LetPVouAno, T003A3_A1150LetPVouMes, T003A3_A1144LetPTasiCod, T003A3_A1151LetPVouNum,
               T003A3_A1147LetPUsuCod, T003A3_A1148LetPUsuFec, T003A3_A267LetPPrvCod, T003A3_A266LetPMonCod
               }
               , new Object[] {
               T003A4_A267LetPPrvCod
               }
               , new Object[] {
               T003A5_A266LetPMonCod
               }
               , new Object[] {
               T003A6_A265LetPLetCod, T003A6_A1140LetPLetFec, T003A6_A1136LetPForCod, T003A6_A1145LetPTipCmb, T003A6_A1143LetPSts, T003A6_A1139LetPImporte, T003A6_A1149LetPVouAno, T003A6_A1150LetPVouMes, T003A6_A1144LetPTasiCod, T003A6_A1151LetPVouNum,
               T003A6_A1147LetPUsuCod, T003A6_A1148LetPUsuFec, T003A6_A267LetPPrvCod, T003A6_A266LetPMonCod
               }
               , new Object[] {
               T003A7_A267LetPPrvCod
               }
               , new Object[] {
               T003A8_A266LetPMonCod
               }
               , new Object[] {
               T003A9_A265LetPLetCod
               }
               , new Object[] {
               T003A10_A265LetPLetCod
               }
               , new Object[] {
               T003A11_A265LetPLetCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003A15_A265LetPLetCod, T003A15_A268LetPItem
               }
               , new Object[] {
               T003A16_A265LetPLetCod
               }
               , new Object[] {
               T003A17_A267LetPPrvCod
               }
               , new Object[] {
               T003A18_A266LetPMonCod
               }
            }
         );
      }

      private short Z1149LetPVouAno ;
      private short Z1150LetPVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1149LetPVouAno ;
      private short A1150LetPVouMes ;
      private short GX_JID ;
      private short RcdFound113 ;
      private short nIsDirty_113 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1149LetPVouAno ;
      private short ZZ1150LetPVouMes ;
      private int Z1136LetPForCod ;
      private int Z1144LetPTasiCod ;
      private int Z266LetPMonCod ;
      private int A266LetPMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLetPLetCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLetPPrvCod_Enabled ;
      private int edtLetPLetFec_Enabled ;
      private int A1136LetPForCod ;
      private int edtLetPForCod_Enabled ;
      private int edtLetPTipCmb_Enabled ;
      private int edtLetPSts_Enabled ;
      private int edtLetPMonCod_Enabled ;
      private int edtLetPImporte_Enabled ;
      private int edtLetPVouAno_Enabled ;
      private int edtLetPVouMes_Enabled ;
      private int A1144LetPTasiCod ;
      private int edtLetPTasiCod_Enabled ;
      private int edtLetPVouNum_Enabled ;
      private int edtLetPUsuCod_Enabled ;
      private int edtLetPUsuFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ1136LetPForCod ;
      private int ZZ266LetPMonCod ;
      private int ZZ1144LetPTasiCod ;
      private decimal Z1145LetPTipCmb ;
      private decimal Z1139LetPImporte ;
      private decimal A1145LetPTipCmb ;
      private decimal A1139LetPImporte ;
      private decimal ZZ1145LetPTipCmb ;
      private decimal ZZ1139LetPImporte ;
      private string sPrefix ;
      private string Z265LetPLetCod ;
      private string Z1143LetPSts ;
      private string Z1151LetPVouNum ;
      private string Z1147LetPUsuCod ;
      private string Z267LetPPrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A267LetPPrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLetPLetCod_Internalname ;
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
      private string A265LetPLetCod ;
      private string edtLetPLetCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLetPPrvCod_Internalname ;
      private string edtLetPPrvCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLetPLetFec_Internalname ;
      private string edtLetPLetFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLetPForCod_Internalname ;
      private string edtLetPForCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLetPTipCmb_Internalname ;
      private string edtLetPTipCmb_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLetPSts_Internalname ;
      private string A1143LetPSts ;
      private string edtLetPSts_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLetPMonCod_Internalname ;
      private string edtLetPMonCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtLetPImporte_Internalname ;
      private string edtLetPImporte_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLetPVouAno_Internalname ;
      private string edtLetPVouAno_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtLetPVouMes_Internalname ;
      private string edtLetPVouMes_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtLetPTasiCod_Internalname ;
      private string edtLetPTasiCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtLetPVouNum_Internalname ;
      private string A1151LetPVouNum ;
      private string edtLetPVouNum_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtLetPUsuCod_Internalname ;
      private string A1147LetPUsuCod ;
      private string edtLetPUsuCod_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtLetPUsuFec_Internalname ;
      private string edtLetPUsuFec_Jsonclick ;
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
      private string sMode113 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ265LetPLetCod ;
      private string ZZ267LetPPrvCod ;
      private string ZZ1143LetPSts ;
      private string ZZ1151LetPVouNum ;
      private string ZZ1147LetPUsuCod ;
      private DateTime Z1148LetPUsuFec ;
      private DateTime A1148LetPUsuFec ;
      private DateTime ZZ1148LetPUsuFec ;
      private DateTime Z1140LetPLetFec ;
      private DateTime A1140LetPLetFec ;
      private DateTime ZZ1140LetPLetFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003A6_A265LetPLetCod ;
      private DateTime[] T003A6_A1140LetPLetFec ;
      private int[] T003A6_A1136LetPForCod ;
      private decimal[] T003A6_A1145LetPTipCmb ;
      private string[] T003A6_A1143LetPSts ;
      private decimal[] T003A6_A1139LetPImporte ;
      private short[] T003A6_A1149LetPVouAno ;
      private short[] T003A6_A1150LetPVouMes ;
      private int[] T003A6_A1144LetPTasiCod ;
      private string[] T003A6_A1151LetPVouNum ;
      private string[] T003A6_A1147LetPUsuCod ;
      private DateTime[] T003A6_A1148LetPUsuFec ;
      private string[] T003A6_A267LetPPrvCod ;
      private int[] T003A6_A266LetPMonCod ;
      private string[] T003A4_A267LetPPrvCod ;
      private int[] T003A5_A266LetPMonCod ;
      private string[] T003A7_A267LetPPrvCod ;
      private int[] T003A8_A266LetPMonCod ;
      private string[] T003A9_A265LetPLetCod ;
      private string[] T003A3_A265LetPLetCod ;
      private DateTime[] T003A3_A1140LetPLetFec ;
      private int[] T003A3_A1136LetPForCod ;
      private decimal[] T003A3_A1145LetPTipCmb ;
      private string[] T003A3_A1143LetPSts ;
      private decimal[] T003A3_A1139LetPImporte ;
      private short[] T003A3_A1149LetPVouAno ;
      private short[] T003A3_A1150LetPVouMes ;
      private int[] T003A3_A1144LetPTasiCod ;
      private string[] T003A3_A1151LetPVouNum ;
      private string[] T003A3_A1147LetPUsuCod ;
      private DateTime[] T003A3_A1148LetPUsuFec ;
      private string[] T003A3_A267LetPPrvCod ;
      private int[] T003A3_A266LetPMonCod ;
      private string[] T003A10_A265LetPLetCod ;
      private string[] T003A11_A265LetPLetCod ;
      private string[] T003A2_A265LetPLetCod ;
      private DateTime[] T003A2_A1140LetPLetFec ;
      private int[] T003A2_A1136LetPForCod ;
      private decimal[] T003A2_A1145LetPTipCmb ;
      private string[] T003A2_A1143LetPSts ;
      private decimal[] T003A2_A1139LetPImporte ;
      private short[] T003A2_A1149LetPVouAno ;
      private short[] T003A2_A1150LetPVouMes ;
      private int[] T003A2_A1144LetPTasiCod ;
      private string[] T003A2_A1151LetPVouNum ;
      private string[] T003A2_A1147LetPUsuCod ;
      private DateTime[] T003A2_A1148LetPUsuFec ;
      private string[] T003A2_A267LetPPrvCod ;
      private int[] T003A2_A266LetPMonCod ;
      private string[] T003A15_A265LetPLetCod ;
      private int[] T003A15_A268LetPItem ;
      private string[] T003A16_A265LetPLetCod ;
      private string[] T003A17_A267LetPPrvCod ;
      private int[] T003A18_A266LetPMonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpletras__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpletras__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003A6;
        prmT003A6 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A4;
        prmT003A4 = new Object[] {
        new ParDef("@LetPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003A5;
        prmT003A5 = new Object[] {
        new ParDef("@LetPMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003A7;
        prmT003A7 = new Object[] {
        new ParDef("@LetPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003A8;
        prmT003A8 = new Object[] {
        new ParDef("@LetPMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003A9;
        prmT003A9 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A3;
        prmT003A3 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A10;
        prmT003A10 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A11;
        prmT003A11 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A2;
        prmT003A2 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A12;
        prmT003A12 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPLetFec",GXType.Date,8,0) ,
        new ParDef("@LetPForCod",GXType.Int32,6,0) ,
        new ParDef("@LetPTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LetPSts",GXType.NChar,1,0) ,
        new ParDef("@LetPImporte",GXType.Decimal,15,2) ,
        new ParDef("@LetPVouAno",GXType.Int16,4,0) ,
        new ParDef("@LetPVouMes",GXType.Int16,2,0) ,
        new ParDef("@LetPTasiCod",GXType.Int32,6,0) ,
        new ParDef("@LetPVouNum",GXType.NChar,10,0) ,
        new ParDef("@LetPUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LetPUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LetPPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LetPMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003A13;
        prmT003A13 = new Object[] {
        new ParDef("@LetPLetFec",GXType.Date,8,0) ,
        new ParDef("@LetPForCod",GXType.Int32,6,0) ,
        new ParDef("@LetPTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LetPSts",GXType.NChar,1,0) ,
        new ParDef("@LetPImporte",GXType.Decimal,15,2) ,
        new ParDef("@LetPVouAno",GXType.Int16,4,0) ,
        new ParDef("@LetPVouMes",GXType.Int16,2,0) ,
        new ParDef("@LetPTasiCod",GXType.Int32,6,0) ,
        new ParDef("@LetPVouNum",GXType.NChar,10,0) ,
        new ParDef("@LetPUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LetPUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LetPPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LetPMonCod",GXType.Int32,6,0) ,
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A14;
        prmT003A14 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A15;
        prmT003A15 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003A16;
        prmT003A16 = new Object[] {
        };
        Object[] prmT003A17;
        prmT003A17 = new Object[] {
        new ParDef("@LetPPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003A18;
        prmT003A18 = new Object[] {
        new ParDef("@LetPMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003A2", "SELECT [LetPLetCod], [LetPLetFec], [LetPForCod], [LetPTipCmb], [LetPSts], [LetPImporte], [LetPVouAno], [LetPVouMes], [LetPTasiCod], [LetPVouNum], [LetPUsuCod], [LetPUsuFec], [LetPPrvCod] AS LetPPrvCod, [LetPMonCod] AS LetPMonCod FROM [CPLETRAS] WITH (UPDLOCK) WHERE [LetPLetCod] = @LetPLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A3", "SELECT [LetPLetCod], [LetPLetFec], [LetPForCod], [LetPTipCmb], [LetPSts], [LetPImporte], [LetPVouAno], [LetPVouMes], [LetPTasiCod], [LetPVouNum], [LetPUsuCod], [LetPUsuFec], [LetPPrvCod] AS LetPPrvCod, [LetPMonCod] AS LetPMonCod FROM [CPLETRAS] WHERE [LetPLetCod] = @LetPLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A4", "SELECT [PrvCod] AS LetPPrvCod FROM [CPPROVEEDORES] WHERE [PrvCod] = @LetPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A5", "SELECT [MonCod] AS LetPMonCod FROM [CMONEDAS] WHERE [MonCod] = @LetPMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A6", "SELECT TM1.[LetPLetCod], TM1.[LetPLetFec], TM1.[LetPForCod], TM1.[LetPTipCmb], TM1.[LetPSts], TM1.[LetPImporte], TM1.[LetPVouAno], TM1.[LetPVouMes], TM1.[LetPTasiCod], TM1.[LetPVouNum], TM1.[LetPUsuCod], TM1.[LetPUsuFec], TM1.[LetPPrvCod] AS LetPPrvCod, TM1.[LetPMonCod] AS LetPMonCod FROM [CPLETRAS] TM1 WHERE TM1.[LetPLetCod] = @LetPLetCod ORDER BY TM1.[LetPLetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003A6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A7", "SELECT [PrvCod] AS LetPPrvCod FROM [CPPROVEEDORES] WHERE [PrvCod] = @LetPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A8", "SELECT [MonCod] AS LetPMonCod FROM [CMONEDAS] WHERE [MonCod] = @LetPMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A9", "SELECT [LetPLetCod] FROM [CPLETRAS] WHERE [LetPLetCod] = @LetPLetCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A10", "SELECT TOP 1 [LetPLetCod] FROM [CPLETRAS] WHERE ( [LetPLetCod] > @LetPLetCod) ORDER BY [LetPLetCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003A10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003A11", "SELECT TOP 1 [LetPLetCod] FROM [CPLETRAS] WHERE ( [LetPLetCod] < @LetPLetCod) ORDER BY [LetPLetCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003A12", "INSERT INTO [CPLETRAS]([LetPLetCod], [LetPLetFec], [LetPForCod], [LetPTipCmb], [LetPSts], [LetPImporte], [LetPVouAno], [LetPVouMes], [LetPTasiCod], [LetPVouNum], [LetPUsuCod], [LetPUsuFec], [LetPPrvCod], [LetPMonCod]) VALUES(@LetPLetCod, @LetPLetFec, @LetPForCod, @LetPTipCmb, @LetPSts, @LetPImporte, @LetPVouAno, @LetPVouMes, @LetPTasiCod, @LetPVouNum, @LetPUsuCod, @LetPUsuFec, @LetPPrvCod, @LetPMonCod)", GxErrorMask.GX_NOMASK,prmT003A12)
           ,new CursorDef("T003A13", "UPDATE [CPLETRAS] SET [LetPLetFec]=@LetPLetFec, [LetPForCod]=@LetPForCod, [LetPTipCmb]=@LetPTipCmb, [LetPSts]=@LetPSts, [LetPImporte]=@LetPImporte, [LetPVouAno]=@LetPVouAno, [LetPVouMes]=@LetPVouMes, [LetPTasiCod]=@LetPTasiCod, [LetPVouNum]=@LetPVouNum, [LetPUsuCod]=@LetPUsuCod, [LetPUsuFec]=@LetPUsuFec, [LetPPrvCod]=@LetPPrvCod, [LetPMonCod]=@LetPMonCod  WHERE [LetPLetCod] = @LetPLetCod", GxErrorMask.GX_NOMASK,prmT003A13)
           ,new CursorDef("T003A14", "DELETE FROM [CPLETRAS]  WHERE [LetPLetCod] = @LetPLetCod", GxErrorMask.GX_NOMASK,prmT003A14)
           ,new CursorDef("T003A15", "SELECT TOP 1 [LetPLetCod], [LetPItem] FROM [CPLETRASDET] WHERE [LetPLetCod] = @LetPLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003A16", "SELECT [LetPLetCod] FROM [CPLETRAS] ORDER BY [LetPLetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003A16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A17", "SELECT [PrvCod] AS LetPPrvCod FROM [CPPROVEEDORES] WHERE [PrvCod] = @LetPPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003A18", "SELECT [MonCod] AS LetPMonCod FROM [CMONEDAS] WHERE [MonCod] = @LetPMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003A18,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
