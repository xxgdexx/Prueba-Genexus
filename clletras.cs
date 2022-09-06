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
   public class clletras : GXDataArea
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
            A206LetCCliCod = GetPar( "LetCCliCod");
            AssignAttri("", false, "A206LetCCliCod", A206LetCCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A206LetCCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A205LetCMonCod = (int)(NumberUtil.Val( GetPar( "LetCMonCod"), "."));
            AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrimStr( (decimal)(A205LetCMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A205LetCMonCod) ;
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
            Form.Meta.addItem("description", "Letras por Cobrar - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLetCLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clletras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clletras( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLLETRAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Canje", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCLetCod_Internalname, StringUtil.RTrim( A204LetCLetCod), StringUtil.RTrim( context.localUtil.Format( A204LetCLetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCLetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCLetCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cliente", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCCliCod_Internalname, StringUtil.RTrim( A206LetCCliCod), StringUtil.RTrim( context.localUtil.Format( A206LetCCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha Canje", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLetCLetFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLetCLetFec_Internalname, context.localUtil.Format(A1114LetCLetFec, "99/99/99"), context.localUtil.Format( A1114LetCLetFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCLetFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCLetFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         GxWebStd.gx_bitmap( context, edtLetCLetFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLetCLetFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Forma de Pago", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1110LetCForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetCForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1110LetCForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1110LetCForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Tipo de Cambio", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1119LetCTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtLetCTipCmb_Enabled!=0) ? context.localUtil.Format( A1119LetCTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1119LetCTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Estado", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCSts_Internalname, StringUtil.RTrim( A1117LetCSts), StringUtil.RTrim( context.localUtil.Format( A1117LetCSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Moneda", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A205LetCMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetCMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A205LetCMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A205LetCMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Importe", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A1113LetCImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtLetCImporte_Enabled!=0) ? context.localUtil.Format( A1113LetCImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1113LetCImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Año", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1124LetCVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtLetCVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1124LetCVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1124LetCVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Mes", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1125LetCVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtLetCVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1125LetCVouMes), "Z9") : context.localUtil.Format( (decimal)(A1125LetCVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Tipo Asiento", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCTasiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1118LetCTasiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetCTasiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1118LetCTasiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1118LetCTasiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCTasiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCTasiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "N° Voucher", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCVouNum_Internalname, StringUtil.RTrim( A1126LetCVouNum), StringUtil.RTrim( context.localUtil.Format( A1126LetCVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Usuario", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetCUsuCod_Internalname, StringUtil.RTrim( A1121LetCUsuCod), StringUtil.RTrim( context.localUtil.Format( A1121LetCUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Usuario Fecha", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLLETRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLetCUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLetCUsuFec_Internalname, context.localUtil.TToC( A1122LetCUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1122LetCUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetCUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetCUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLLETRAS.htm");
         GxWebStd.gx_bitmap( context, edtLetCUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLetCUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLLETRAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLLETRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLLETRAS.htm");
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
            Z204LetCLetCod = cgiGet( "Z204LetCLetCod");
            Z1114LetCLetFec = context.localUtil.CToD( cgiGet( "Z1114LetCLetFec"), 0);
            Z1110LetCForCod = (int)(context.localUtil.CToN( cgiGet( "Z1110LetCForCod"), ".", ","));
            Z1119LetCTipCmb = context.localUtil.CToN( cgiGet( "Z1119LetCTipCmb"), ".", ",");
            Z1117LetCSts = cgiGet( "Z1117LetCSts");
            Z1113LetCImporte = context.localUtil.CToN( cgiGet( "Z1113LetCImporte"), ".", ",");
            Z1124LetCVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1124LetCVouAno"), ".", ","));
            Z1125LetCVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1125LetCVouMes"), ".", ","));
            Z1118LetCTasiCod = (int)(context.localUtil.CToN( cgiGet( "Z1118LetCTasiCod"), ".", ","));
            Z1126LetCVouNum = cgiGet( "Z1126LetCVouNum");
            Z1121LetCUsuCod = cgiGet( "Z1121LetCUsuCod");
            Z1122LetCUsuFec = context.localUtil.CToT( cgiGet( "Z1122LetCUsuFec"), 0);
            Z206LetCCliCod = cgiGet( "Z206LetCCliCod");
            Z205LetCMonCod = (int)(context.localUtil.CToN( cgiGet( "Z205LetCMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A204LetCLetCod = cgiGet( edtLetCLetCod_Internalname);
            AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
            A206LetCCliCod = cgiGet( edtLetCCliCod_Internalname);
            AssignAttri("", false, "A206LetCCliCod", A206LetCCliCod);
            if ( context.localUtil.VCDate( cgiGet( edtLetCLetFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Canje"}), 1, "LETCLETFEC");
               AnyError = 1;
               GX_FocusControl = edtLetCLetFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1114LetCLetFec = DateTime.MinValue;
               AssignAttri("", false, "A1114LetCLetFec", context.localUtil.Format(A1114LetCLetFec, "99/99/99"));
            }
            else
            {
               A1114LetCLetFec = context.localUtil.CToD( cgiGet( edtLetCLetFec_Internalname), 2);
               AssignAttri("", false, "A1114LetCLetFec", context.localUtil.Format(A1114LetCLetFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLetCForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1110LetCForCod = 0;
               AssignAttri("", false, "A1110LetCForCod", StringUtil.LTrimStr( (decimal)(A1110LetCForCod), 6, 0));
            }
            else
            {
               A1110LetCForCod = (int)(context.localUtil.CToN( cgiGet( edtLetCForCod_Internalname), ".", ","));
               AssignAttri("", false, "A1110LetCForCod", StringUtil.LTrimStr( (decimal)(A1110LetCForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtLetCTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1119LetCTipCmb = 0;
               AssignAttri("", false, "A1119LetCTipCmb", StringUtil.LTrimStr( A1119LetCTipCmb, 15, 5));
            }
            else
            {
               A1119LetCTipCmb = context.localUtil.CToN( cgiGet( edtLetCTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1119LetCTipCmb", StringUtil.LTrimStr( A1119LetCTipCmb, 15, 5));
            }
            A1117LetCSts = cgiGet( edtLetCSts_Internalname);
            AssignAttri("", false, "A1117LetCSts", A1117LetCSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCMONCOD");
               AnyError = 1;
               GX_FocusControl = edtLetCMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A205LetCMonCod = 0;
               AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrimStr( (decimal)(A205LetCMonCod), 6, 0));
            }
            else
            {
               A205LetCMonCod = (int)(context.localUtil.CToN( cgiGet( edtLetCMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrimStr( (decimal)(A205LetCMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtLetCImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1113LetCImporte = 0;
               AssignAttri("", false, "A1113LetCImporte", StringUtil.LTrimStr( A1113LetCImporte, 15, 2));
            }
            else
            {
               A1113LetCImporte = context.localUtil.CToN( cgiGet( edtLetCImporte_Internalname), ".", ",");
               AssignAttri("", false, "A1113LetCImporte", StringUtil.LTrimStr( A1113LetCImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCVOUANO");
               AnyError = 1;
               GX_FocusControl = edtLetCVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1124LetCVouAno = 0;
               AssignAttri("", false, "A1124LetCVouAno", StringUtil.LTrimStr( (decimal)(A1124LetCVouAno), 4, 0));
            }
            else
            {
               A1124LetCVouAno = (short)(context.localUtil.CToN( cgiGet( edtLetCVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1124LetCVouAno", StringUtil.LTrimStr( (decimal)(A1124LetCVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCVOUMES");
               AnyError = 1;
               GX_FocusControl = edtLetCVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1125LetCVouMes = 0;
               AssignAttri("", false, "A1125LetCVouMes", StringUtil.LTrimStr( (decimal)(A1125LetCVouMes), 2, 0));
            }
            else
            {
               A1125LetCVouMes = (short)(context.localUtil.CToN( cgiGet( edtLetCVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1125LetCVouMes", StringUtil.LTrimStr( (decimal)(A1125LetCVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetCTasiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetCTasiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETCTASICOD");
               AnyError = 1;
               GX_FocusControl = edtLetCTasiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1118LetCTasiCod = 0;
               AssignAttri("", false, "A1118LetCTasiCod", StringUtil.LTrimStr( (decimal)(A1118LetCTasiCod), 6, 0));
            }
            else
            {
               A1118LetCTasiCod = (int)(context.localUtil.CToN( cgiGet( edtLetCTasiCod_Internalname), ".", ","));
               AssignAttri("", false, "A1118LetCTasiCod", StringUtil.LTrimStr( (decimal)(A1118LetCTasiCod), 6, 0));
            }
            A1126LetCVouNum = cgiGet( edtLetCVouNum_Internalname);
            AssignAttri("", false, "A1126LetCVouNum", A1126LetCVouNum);
            A1121LetCUsuCod = cgiGet( edtLetCUsuCod_Internalname);
            AssignAttri("", false, "A1121LetCUsuCod", A1121LetCUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtLetCUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "LETCUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtLetCUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1122LetCUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1122LetCUsuFec", context.localUtil.TToC( A1122LetCUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1122LetCUsuFec = context.localUtil.CToT( cgiGet( edtLetCUsuFec_Internalname));
               AssignAttri("", false, "A1122LetCUsuFec", context.localUtil.TToC( A1122LetCUsuFec, 8, 5, 0, 3, "/", ":", " "));
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
               A204LetCLetCod = GetPar( "LetCLetCod");
               AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
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
               InitAll2Q93( ) ;
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
         DisableAttributes2Q93( ) ;
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

      protected void CONFIRM_2Q0( )
      {
         BeforeValidate2Q93( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Q93( ) ;
            }
            else
            {
               CheckExtendedTable2Q93( ) ;
               if ( AnyError == 0 )
               {
                  ZM2Q93( 4) ;
                  ZM2Q93( 5) ;
               }
               CloseExtendedTableCursors2Q93( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2Q0( ) ;
         }
      }

      protected void ResetCaption2Q0( )
      {
      }

      protected void ZM2Q93( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1114LetCLetFec = T002Q3_A1114LetCLetFec[0];
               Z1110LetCForCod = T002Q3_A1110LetCForCod[0];
               Z1119LetCTipCmb = T002Q3_A1119LetCTipCmb[0];
               Z1117LetCSts = T002Q3_A1117LetCSts[0];
               Z1113LetCImporte = T002Q3_A1113LetCImporte[0];
               Z1124LetCVouAno = T002Q3_A1124LetCVouAno[0];
               Z1125LetCVouMes = T002Q3_A1125LetCVouMes[0];
               Z1118LetCTasiCod = T002Q3_A1118LetCTasiCod[0];
               Z1126LetCVouNum = T002Q3_A1126LetCVouNum[0];
               Z1121LetCUsuCod = T002Q3_A1121LetCUsuCod[0];
               Z1122LetCUsuFec = T002Q3_A1122LetCUsuFec[0];
               Z206LetCCliCod = T002Q3_A206LetCCliCod[0];
               Z205LetCMonCod = T002Q3_A205LetCMonCod[0];
            }
            else
            {
               Z1114LetCLetFec = A1114LetCLetFec;
               Z1110LetCForCod = A1110LetCForCod;
               Z1119LetCTipCmb = A1119LetCTipCmb;
               Z1117LetCSts = A1117LetCSts;
               Z1113LetCImporte = A1113LetCImporte;
               Z1124LetCVouAno = A1124LetCVouAno;
               Z1125LetCVouMes = A1125LetCVouMes;
               Z1118LetCTasiCod = A1118LetCTasiCod;
               Z1126LetCVouNum = A1126LetCVouNum;
               Z1121LetCUsuCod = A1121LetCUsuCod;
               Z1122LetCUsuFec = A1122LetCUsuFec;
               Z206LetCCliCod = A206LetCCliCod;
               Z205LetCMonCod = A205LetCMonCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z204LetCLetCod = A204LetCLetCod;
            Z1114LetCLetFec = A1114LetCLetFec;
            Z1110LetCForCod = A1110LetCForCod;
            Z1119LetCTipCmb = A1119LetCTipCmb;
            Z1117LetCSts = A1117LetCSts;
            Z1113LetCImporte = A1113LetCImporte;
            Z1124LetCVouAno = A1124LetCVouAno;
            Z1125LetCVouMes = A1125LetCVouMes;
            Z1118LetCTasiCod = A1118LetCTasiCod;
            Z1126LetCVouNum = A1126LetCVouNum;
            Z1121LetCUsuCod = A1121LetCUsuCod;
            Z1122LetCUsuFec = A1122LetCUsuFec;
            Z206LetCCliCod = A206LetCCliCod;
            Z205LetCMonCod = A205LetCMonCod;
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

      protected void Load2Q93( )
      {
         /* Using cursor T002Q6 */
         pr_default.execute(4, new Object[] {A204LetCLetCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound93 = 1;
            A1114LetCLetFec = T002Q6_A1114LetCLetFec[0];
            AssignAttri("", false, "A1114LetCLetFec", context.localUtil.Format(A1114LetCLetFec, "99/99/99"));
            A1110LetCForCod = T002Q6_A1110LetCForCod[0];
            AssignAttri("", false, "A1110LetCForCod", StringUtil.LTrimStr( (decimal)(A1110LetCForCod), 6, 0));
            A1119LetCTipCmb = T002Q6_A1119LetCTipCmb[0];
            AssignAttri("", false, "A1119LetCTipCmb", StringUtil.LTrimStr( A1119LetCTipCmb, 15, 5));
            A1117LetCSts = T002Q6_A1117LetCSts[0];
            AssignAttri("", false, "A1117LetCSts", A1117LetCSts);
            A1113LetCImporte = T002Q6_A1113LetCImporte[0];
            AssignAttri("", false, "A1113LetCImporte", StringUtil.LTrimStr( A1113LetCImporte, 15, 2));
            A1124LetCVouAno = T002Q6_A1124LetCVouAno[0];
            AssignAttri("", false, "A1124LetCVouAno", StringUtil.LTrimStr( (decimal)(A1124LetCVouAno), 4, 0));
            A1125LetCVouMes = T002Q6_A1125LetCVouMes[0];
            AssignAttri("", false, "A1125LetCVouMes", StringUtil.LTrimStr( (decimal)(A1125LetCVouMes), 2, 0));
            A1118LetCTasiCod = T002Q6_A1118LetCTasiCod[0];
            AssignAttri("", false, "A1118LetCTasiCod", StringUtil.LTrimStr( (decimal)(A1118LetCTasiCod), 6, 0));
            A1126LetCVouNum = T002Q6_A1126LetCVouNum[0];
            AssignAttri("", false, "A1126LetCVouNum", A1126LetCVouNum);
            A1121LetCUsuCod = T002Q6_A1121LetCUsuCod[0];
            AssignAttri("", false, "A1121LetCUsuCod", A1121LetCUsuCod);
            A1122LetCUsuFec = T002Q6_A1122LetCUsuFec[0];
            AssignAttri("", false, "A1122LetCUsuFec", context.localUtil.TToC( A1122LetCUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A206LetCCliCod = T002Q6_A206LetCCliCod[0];
            AssignAttri("", false, "A206LetCCliCod", A206LetCCliCod);
            A205LetCMonCod = T002Q6_A205LetCMonCod[0];
            AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrimStr( (decimal)(A205LetCMonCod), 6, 0));
            ZM2Q93( -3) ;
         }
         pr_default.close(4);
         OnLoadActions2Q93( ) ;
      }

      protected void OnLoadActions2Q93( )
      {
      }

      protected void CheckExtendedTable2Q93( )
      {
         nIsDirty_93 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002Q4 */
         pr_default.execute(2, new Object[] {A206LetCCliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "LETCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLetCCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1114LetCLetFec) || ( DateTimeUtil.ResetTime ( A1114LetCLetFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Canje fuera de rango", "OutOfRange", 1, "LETCLETFEC");
            AnyError = 1;
            GX_FocusControl = edtLetCLetFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002Q5 */
         pr_default.execute(3, new Object[] {A205LetCMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LETCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLetCMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1122LetCUsuFec) || ( A1122LetCUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "LETCUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtLetCUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2Q93( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A206LetCCliCod )
      {
         /* Using cursor T002Q7 */
         pr_default.execute(5, new Object[] {A206LetCCliCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "LETCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLetCCliCod_Internalname;
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

      protected void gxLoad_5( int A205LetCMonCod )
      {
         /* Using cursor T002Q8 */
         pr_default.execute(6, new Object[] {A205LetCMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LETCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLetCMonCod_Internalname;
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

      protected void GetKey2Q93( )
      {
         /* Using cursor T002Q9 */
         pr_default.execute(7, new Object[] {A204LetCLetCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound93 = 1;
         }
         else
         {
            RcdFound93 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002Q3 */
         pr_default.execute(1, new Object[] {A204LetCLetCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Q93( 3) ;
            RcdFound93 = 1;
            A204LetCLetCod = T002Q3_A204LetCLetCod[0];
            AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
            A1114LetCLetFec = T002Q3_A1114LetCLetFec[0];
            AssignAttri("", false, "A1114LetCLetFec", context.localUtil.Format(A1114LetCLetFec, "99/99/99"));
            A1110LetCForCod = T002Q3_A1110LetCForCod[0];
            AssignAttri("", false, "A1110LetCForCod", StringUtil.LTrimStr( (decimal)(A1110LetCForCod), 6, 0));
            A1119LetCTipCmb = T002Q3_A1119LetCTipCmb[0];
            AssignAttri("", false, "A1119LetCTipCmb", StringUtil.LTrimStr( A1119LetCTipCmb, 15, 5));
            A1117LetCSts = T002Q3_A1117LetCSts[0];
            AssignAttri("", false, "A1117LetCSts", A1117LetCSts);
            A1113LetCImporte = T002Q3_A1113LetCImporte[0];
            AssignAttri("", false, "A1113LetCImporte", StringUtil.LTrimStr( A1113LetCImporte, 15, 2));
            A1124LetCVouAno = T002Q3_A1124LetCVouAno[0];
            AssignAttri("", false, "A1124LetCVouAno", StringUtil.LTrimStr( (decimal)(A1124LetCVouAno), 4, 0));
            A1125LetCVouMes = T002Q3_A1125LetCVouMes[0];
            AssignAttri("", false, "A1125LetCVouMes", StringUtil.LTrimStr( (decimal)(A1125LetCVouMes), 2, 0));
            A1118LetCTasiCod = T002Q3_A1118LetCTasiCod[0];
            AssignAttri("", false, "A1118LetCTasiCod", StringUtil.LTrimStr( (decimal)(A1118LetCTasiCod), 6, 0));
            A1126LetCVouNum = T002Q3_A1126LetCVouNum[0];
            AssignAttri("", false, "A1126LetCVouNum", A1126LetCVouNum);
            A1121LetCUsuCod = T002Q3_A1121LetCUsuCod[0];
            AssignAttri("", false, "A1121LetCUsuCod", A1121LetCUsuCod);
            A1122LetCUsuFec = T002Q3_A1122LetCUsuFec[0];
            AssignAttri("", false, "A1122LetCUsuFec", context.localUtil.TToC( A1122LetCUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A206LetCCliCod = T002Q3_A206LetCCliCod[0];
            AssignAttri("", false, "A206LetCCliCod", A206LetCCliCod);
            A205LetCMonCod = T002Q3_A205LetCMonCod[0];
            AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrimStr( (decimal)(A205LetCMonCod), 6, 0));
            Z204LetCLetCod = A204LetCLetCod;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2Q93( ) ;
            if ( AnyError == 1 )
            {
               RcdFound93 = 0;
               InitializeNonKey2Q93( ) ;
            }
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound93 = 0;
            InitializeNonKey2Q93( ) ;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode93;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Q93( ) ;
         if ( RcdFound93 == 0 )
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
         RcdFound93 = 0;
         /* Using cursor T002Q10 */
         pr_default.execute(8, new Object[] {A204LetCLetCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002Q10_A204LetCLetCod[0], A204LetCLetCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002Q10_A204LetCLetCod[0], A204LetCLetCod) > 0 ) ) )
            {
               A204LetCLetCod = T002Q10_A204LetCLetCod[0];
               AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
               RcdFound93 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound93 = 0;
         /* Using cursor T002Q11 */
         pr_default.execute(9, new Object[] {A204LetCLetCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002Q11_A204LetCLetCod[0], A204LetCLetCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002Q11_A204LetCLetCod[0], A204LetCLetCod) < 0 ) ) )
            {
               A204LetCLetCod = T002Q11_A204LetCLetCod[0];
               AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
               RcdFound93 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2Q93( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLetCLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2Q93( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound93 == 1 )
            {
               if ( StringUtil.StrCmp(A204LetCLetCod, Z204LetCLetCod) != 0 )
               {
                  A204LetCLetCod = Z204LetCLetCod;
                  AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LETCLETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLetCLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLetCLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2Q93( ) ;
                  GX_FocusControl = edtLetCLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A204LetCLetCod, Z204LetCLetCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLetCLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2Q93( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LETCLETCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLetCLetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLetCLetCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2Q93( ) ;
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
         if ( StringUtil.StrCmp(A204LetCLetCod, Z204LetCLetCod) != 0 )
         {
            A204LetCLetCod = Z204LetCLetCod;
            AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LETCLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetCLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLetCLetCod_Internalname;
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
         GetKey2Q93( ) ;
         if ( RcdFound93 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LETCLETCOD");
               AnyError = 1;
               GX_FocusControl = edtLetCLetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A204LetCLetCod, Z204LetCLetCod) != 0 )
            {
               A204LetCLetCod = Z204LetCLetCod;
               AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LETCLETCOD");
               AnyError = 1;
               GX_FocusControl = edtLetCLetCod_Internalname;
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
            if ( StringUtil.StrCmp(A204LetCLetCod, Z204LetCLetCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LETCLETCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLetCLetCod_Internalname;
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
         context.RollbackDataStores("clletras",pr_default);
         GX_FocusControl = edtLetCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2Q0( ) ;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LETCLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetCLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLetCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2Q93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Q93( ) ;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetCCliCod_Internalname;
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
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetCCliCod_Internalname;
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
         ScanStart2Q93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound93 != 0 )
            {
               ScanNext2Q93( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetCCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2Q93( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2Q93( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002Q2 */
            pr_default.execute(0, new Object[] {A204LetCLetCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLLETRAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1114LetCLetFec ) != DateTimeUtil.ResetTime ( T002Q2_A1114LetCLetFec[0] ) ) || ( Z1110LetCForCod != T002Q2_A1110LetCForCod[0] ) || ( Z1119LetCTipCmb != T002Q2_A1119LetCTipCmb[0] ) || ( StringUtil.StrCmp(Z1117LetCSts, T002Q2_A1117LetCSts[0]) != 0 ) || ( Z1113LetCImporte != T002Q2_A1113LetCImporte[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1124LetCVouAno != T002Q2_A1124LetCVouAno[0] ) || ( Z1125LetCVouMes != T002Q2_A1125LetCVouMes[0] ) || ( Z1118LetCTasiCod != T002Q2_A1118LetCTasiCod[0] ) || ( StringUtil.StrCmp(Z1126LetCVouNum, T002Q2_A1126LetCVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1121LetCUsuCod, T002Q2_A1121LetCUsuCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1122LetCUsuFec != T002Q2_A1122LetCUsuFec[0] ) || ( StringUtil.StrCmp(Z206LetCCliCod, T002Q2_A206LetCCliCod[0]) != 0 ) || ( Z205LetCMonCod != T002Q2_A205LetCMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1114LetCLetFec ) != DateTimeUtil.ResetTime ( T002Q2_A1114LetCLetFec[0] ) )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCLetFec");
                  GXUtil.WriteLogRaw("Old: ",Z1114LetCLetFec);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1114LetCLetFec[0]);
               }
               if ( Z1110LetCForCod != T002Q2_A1110LetCForCod[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCForCod");
                  GXUtil.WriteLogRaw("Old: ",Z1110LetCForCod);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1110LetCForCod[0]);
               }
               if ( Z1119LetCTipCmb != T002Q2_A1119LetCTipCmb[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1119LetCTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1119LetCTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z1117LetCSts, T002Q2_A1117LetCSts[0]) != 0 )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCSts");
                  GXUtil.WriteLogRaw("Old: ",Z1117LetCSts);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1117LetCSts[0]);
               }
               if ( Z1113LetCImporte != T002Q2_A1113LetCImporte[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCImporte");
                  GXUtil.WriteLogRaw("Old: ",Z1113LetCImporte);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1113LetCImporte[0]);
               }
               if ( Z1124LetCVouAno != T002Q2_A1124LetCVouAno[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1124LetCVouAno);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1124LetCVouAno[0]);
               }
               if ( Z1125LetCVouMes != T002Q2_A1125LetCVouMes[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1125LetCVouMes);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1125LetCVouMes[0]);
               }
               if ( Z1118LetCTasiCod != T002Q2_A1118LetCTasiCod[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCTasiCod");
                  GXUtil.WriteLogRaw("Old: ",Z1118LetCTasiCod);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1118LetCTasiCod[0]);
               }
               if ( StringUtil.StrCmp(Z1126LetCVouNum, T002Q2_A1126LetCVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1126LetCVouNum);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1126LetCVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1121LetCUsuCod, T002Q2_A1121LetCUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1121LetCUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1121LetCUsuCod[0]);
               }
               if ( Z1122LetCUsuFec != T002Q2_A1122LetCUsuFec[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1122LetCUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A1122LetCUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z206LetCCliCod, T002Q2_A206LetCCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z206LetCCliCod);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A206LetCCliCod[0]);
               }
               if ( Z205LetCMonCod != T002Q2_A205LetCMonCod[0] )
               {
                  GXUtil.WriteLog("clletras:[seudo value changed for attri]"+"LetCMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z205LetCMonCod);
                  GXUtil.WriteLogRaw("Current: ",T002Q2_A205LetCMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLLETRAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Q93( )
      {
         BeforeValidate2Q93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q93( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Q93( 0) ;
            CheckOptimisticConcurrency2Q93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Q93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Q12 */
                     pr_default.execute(10, new Object[] {A204LetCLetCod, A1114LetCLetFec, A1110LetCForCod, A1119LetCTipCmb, A1117LetCSts, A1113LetCImporte, A1124LetCVouAno, A1125LetCVouMes, A1118LetCTasiCod, A1126LetCVouNum, A1121LetCUsuCod, A1122LetCUsuFec, A206LetCCliCod, A205LetCMonCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLLETRAS");
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
                           ResetCaption2Q0( ) ;
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
               Load2Q93( ) ;
            }
            EndLevel2Q93( ) ;
         }
         CloseExtendedTableCursors2Q93( ) ;
      }

      protected void Update2Q93( )
      {
         BeforeValidate2Q93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q93( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Q93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002Q13 */
                     pr_default.execute(11, new Object[] {A1114LetCLetFec, A1110LetCForCod, A1119LetCTipCmb, A1117LetCSts, A1113LetCImporte, A1124LetCVouAno, A1125LetCVouMes, A1118LetCTasiCod, A1126LetCVouNum, A1121LetCUsuCod, A1122LetCUsuFec, A206LetCCliCod, A205LetCMonCod, A204LetCLetCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLLETRAS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLLETRAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Q93( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2Q0( ) ;
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
            EndLevel2Q93( ) ;
         }
         CloseExtendedTableCursors2Q93( ) ;
      }

      protected void DeferredUpdate2Q93( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2Q93( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q93( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Q93( ) ;
            AfterConfirm2Q93( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Q93( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002Q14 */
                  pr_default.execute(12, new Object[] {A204LetCLetCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLLETRAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound93 == 0 )
                        {
                           InitAll2Q93( ) ;
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
                        ResetCaption2Q0( ) ;
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
         sMode93 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2Q93( ) ;
         Gx_mode = sMode93;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2Q93( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002Q15 */
            pr_default.execute(13, new Object[] {A204LetCLetCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel2Q93( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Q93( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clletras",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clletras",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2Q93( )
      {
         /* Using cursor T002Q16 */
         pr_default.execute(14);
         RcdFound93 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound93 = 1;
            A204LetCLetCod = T002Q16_A204LetCLetCod[0];
            AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2Q93( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound93 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound93 = 1;
            A204LetCLetCod = T002Q16_A204LetCLetCod[0];
            AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
         }
      }

      protected void ScanEnd2Q93( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm2Q93( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Q93( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Q93( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Q93( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Q93( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Q93( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Q93( )
      {
         edtLetCLetCod_Enabled = 0;
         AssignProp("", false, edtLetCLetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCLetCod_Enabled), 5, 0), true);
         edtLetCCliCod_Enabled = 0;
         AssignProp("", false, edtLetCCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCCliCod_Enabled), 5, 0), true);
         edtLetCLetFec_Enabled = 0;
         AssignProp("", false, edtLetCLetFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCLetFec_Enabled), 5, 0), true);
         edtLetCForCod_Enabled = 0;
         AssignProp("", false, edtLetCForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCForCod_Enabled), 5, 0), true);
         edtLetCTipCmb_Enabled = 0;
         AssignProp("", false, edtLetCTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCTipCmb_Enabled), 5, 0), true);
         edtLetCSts_Enabled = 0;
         AssignProp("", false, edtLetCSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCSts_Enabled), 5, 0), true);
         edtLetCMonCod_Enabled = 0;
         AssignProp("", false, edtLetCMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCMonCod_Enabled), 5, 0), true);
         edtLetCImporte_Enabled = 0;
         AssignProp("", false, edtLetCImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCImporte_Enabled), 5, 0), true);
         edtLetCVouAno_Enabled = 0;
         AssignProp("", false, edtLetCVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCVouAno_Enabled), 5, 0), true);
         edtLetCVouMes_Enabled = 0;
         AssignProp("", false, edtLetCVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCVouMes_Enabled), 5, 0), true);
         edtLetCTasiCod_Enabled = 0;
         AssignProp("", false, edtLetCTasiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCTasiCod_Enabled), 5, 0), true);
         edtLetCVouNum_Enabled = 0;
         AssignProp("", false, edtLetCVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCVouNum_Enabled), 5, 0), true);
         edtLetCUsuCod_Enabled = 0;
         AssignProp("", false, edtLetCUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCUsuCod_Enabled), 5, 0), true);
         edtLetCUsuFec_Enabled = 0;
         AssignProp("", false, edtLetCUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetCUsuFec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2Q93( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2Q0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816425791", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clletras.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z204LetCLetCod", StringUtil.RTrim( Z204LetCLetCod));
         GxWebStd.gx_hidden_field( context, "Z1114LetCLetFec", context.localUtil.DToC( Z1114LetCLetFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1110LetCForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1110LetCForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1119LetCTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1119LetCTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1117LetCSts", StringUtil.RTrim( Z1117LetCSts));
         GxWebStd.gx_hidden_field( context, "Z1113LetCImporte", StringUtil.LTrim( StringUtil.NToC( Z1113LetCImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1124LetCVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1124LetCVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1125LetCVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1125LetCVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1118LetCTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1118LetCTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1126LetCVouNum", StringUtil.RTrim( Z1126LetCVouNum));
         GxWebStd.gx_hidden_field( context, "Z1121LetCUsuCod", StringUtil.RTrim( Z1121LetCUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1122LetCUsuFec", context.localUtil.TToC( Z1122LetCUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z206LetCCliCod", StringUtil.RTrim( Z206LetCCliCod));
         GxWebStd.gx_hidden_field( context, "Z205LetCMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z205LetCMonCod), 6, 0, ".", "")));
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
         return formatLink("clletras.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLLETRAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Letras por Cobrar - Cabecera" ;
      }

      protected void InitializeNonKey2Q93( )
      {
         A206LetCCliCod = "";
         AssignAttri("", false, "A206LetCCliCod", A206LetCCliCod);
         A1114LetCLetFec = DateTime.MinValue;
         AssignAttri("", false, "A1114LetCLetFec", context.localUtil.Format(A1114LetCLetFec, "99/99/99"));
         A1110LetCForCod = 0;
         AssignAttri("", false, "A1110LetCForCod", StringUtil.LTrimStr( (decimal)(A1110LetCForCod), 6, 0));
         A1119LetCTipCmb = 0;
         AssignAttri("", false, "A1119LetCTipCmb", StringUtil.LTrimStr( A1119LetCTipCmb, 15, 5));
         A1117LetCSts = "";
         AssignAttri("", false, "A1117LetCSts", A1117LetCSts);
         A205LetCMonCod = 0;
         AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrimStr( (decimal)(A205LetCMonCod), 6, 0));
         A1113LetCImporte = 0;
         AssignAttri("", false, "A1113LetCImporte", StringUtil.LTrimStr( A1113LetCImporte, 15, 2));
         A1124LetCVouAno = 0;
         AssignAttri("", false, "A1124LetCVouAno", StringUtil.LTrimStr( (decimal)(A1124LetCVouAno), 4, 0));
         A1125LetCVouMes = 0;
         AssignAttri("", false, "A1125LetCVouMes", StringUtil.LTrimStr( (decimal)(A1125LetCVouMes), 2, 0));
         A1118LetCTasiCod = 0;
         AssignAttri("", false, "A1118LetCTasiCod", StringUtil.LTrimStr( (decimal)(A1118LetCTasiCod), 6, 0));
         A1126LetCVouNum = "";
         AssignAttri("", false, "A1126LetCVouNum", A1126LetCVouNum);
         A1121LetCUsuCod = "";
         AssignAttri("", false, "A1121LetCUsuCod", A1121LetCUsuCod);
         A1122LetCUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1122LetCUsuFec", context.localUtil.TToC( A1122LetCUsuFec, 8, 5, 0, 3, "/", ":", " "));
         Z1114LetCLetFec = DateTime.MinValue;
         Z1110LetCForCod = 0;
         Z1119LetCTipCmb = 0;
         Z1117LetCSts = "";
         Z1113LetCImporte = 0;
         Z1124LetCVouAno = 0;
         Z1125LetCVouMes = 0;
         Z1118LetCTasiCod = 0;
         Z1126LetCVouNum = "";
         Z1121LetCUsuCod = "";
         Z1122LetCUsuFec = (DateTime)(DateTime.MinValue);
         Z206LetCCliCod = "";
         Z205LetCMonCod = 0;
      }

      protected void InitAll2Q93( )
      {
         A204LetCLetCod = "";
         AssignAttri("", false, "A204LetCLetCod", A204LetCLetCod);
         InitializeNonKey2Q93( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181642586", true, true);
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
         context.AddJavascriptSource("clletras.js", "?20228181642587", false, true);
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
         edtLetCLetCod_Internalname = "LETCLETCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLetCCliCod_Internalname = "LETCCLICOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLetCLetFec_Internalname = "LETCLETFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLetCForCod_Internalname = "LETCFORCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLetCTipCmb_Internalname = "LETCTIPCMB";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLetCSts_Internalname = "LETCSTS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLetCMonCod_Internalname = "LETCMONCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtLetCImporte_Internalname = "LETCIMPORTE";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLetCVouAno_Internalname = "LETCVOUANO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtLetCVouMes_Internalname = "LETCVOUMES";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtLetCTasiCod_Internalname = "LETCTASICOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtLetCVouNum_Internalname = "LETCVOUNUM";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtLetCUsuCod_Internalname = "LETCUSUCOD";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtLetCUsuFec_Internalname = "LETCUSUFEC";
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
         Form.Caption = "Letras por Cobrar - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLetCUsuFec_Jsonclick = "";
         edtLetCUsuFec_Enabled = 1;
         edtLetCUsuCod_Jsonclick = "";
         edtLetCUsuCod_Enabled = 1;
         edtLetCVouNum_Jsonclick = "";
         edtLetCVouNum_Enabled = 1;
         edtLetCTasiCod_Jsonclick = "";
         edtLetCTasiCod_Enabled = 1;
         edtLetCVouMes_Jsonclick = "";
         edtLetCVouMes_Enabled = 1;
         edtLetCVouAno_Jsonclick = "";
         edtLetCVouAno_Enabled = 1;
         edtLetCImporte_Jsonclick = "";
         edtLetCImporte_Enabled = 1;
         edtLetCMonCod_Jsonclick = "";
         edtLetCMonCod_Enabled = 1;
         edtLetCSts_Jsonclick = "";
         edtLetCSts_Enabled = 1;
         edtLetCTipCmb_Jsonclick = "";
         edtLetCTipCmb_Enabled = 1;
         edtLetCForCod_Jsonclick = "";
         edtLetCForCod_Enabled = 1;
         edtLetCLetFec_Jsonclick = "";
         edtLetCLetFec_Enabled = 1;
         edtLetCCliCod_Jsonclick = "";
         edtLetCCliCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLetCLetCod_Jsonclick = "";
         edtLetCLetCod_Enabled = 1;
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
         GX_FocusControl = edtLetCCliCod_Internalname;
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

      public void Valid_Letcletcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A206LetCCliCod", StringUtil.RTrim( A206LetCCliCod));
         AssignAttri("", false, "A1114LetCLetFec", context.localUtil.Format(A1114LetCLetFec, "99/99/99"));
         AssignAttri("", false, "A1110LetCForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1110LetCForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1119LetCTipCmb", StringUtil.LTrim( StringUtil.NToC( A1119LetCTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A1117LetCSts", StringUtil.RTrim( A1117LetCSts));
         AssignAttri("", false, "A205LetCMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A205LetCMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1113LetCImporte", StringUtil.LTrim( StringUtil.NToC( A1113LetCImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A1124LetCVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1124LetCVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1125LetCVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1125LetCVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1118LetCTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1118LetCTasiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1126LetCVouNum", StringUtil.RTrim( A1126LetCVouNum));
         AssignAttri("", false, "A1121LetCUsuCod", StringUtil.RTrim( A1121LetCUsuCod));
         AssignAttri("", false, "A1122LetCUsuFec", context.localUtil.TToC( A1122LetCUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z204LetCLetCod", StringUtil.RTrim( Z204LetCLetCod));
         GxWebStd.gx_hidden_field( context, "Z206LetCCliCod", StringUtil.RTrim( Z206LetCCliCod));
         GxWebStd.gx_hidden_field( context, "Z1114LetCLetFec", context.localUtil.Format(Z1114LetCLetFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1110LetCForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1110LetCForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1119LetCTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1119LetCTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1117LetCSts", StringUtil.RTrim( Z1117LetCSts));
         GxWebStd.gx_hidden_field( context, "Z205LetCMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z205LetCMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1113LetCImporte", StringUtil.LTrim( StringUtil.NToC( Z1113LetCImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1124LetCVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1124LetCVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1125LetCVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1125LetCVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1118LetCTasiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1118LetCTasiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1126LetCVouNum", StringUtil.RTrim( Z1126LetCVouNum));
         GxWebStd.gx_hidden_field( context, "Z1121LetCUsuCod", StringUtil.RTrim( Z1121LetCUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1122LetCUsuFec", context.localUtil.TToC( Z1122LetCUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Letcclicod( )
      {
         /* Using cursor T002Q17 */
         pr_default.execute(15, new Object[] {A206LetCCliCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "LETCCLICOD");
            AnyError = 1;
            GX_FocusControl = edtLetCCliCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Letcmoncod( )
      {
         /* Using cursor T002Q18 */
         pr_default.execute(16, new Object[] {A205LetCMonCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LETCMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLetCMonCod_Internalname;
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
         setEventMetadata("VALID_LETCLETCOD","{handler:'Valid_Letcletcod',iparms:[{av:'A204LetCLetCod',fld:'LETCLETCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LETCLETCOD",",oparms:[{av:'A206LetCCliCod',fld:'LETCCLICOD',pic:''},{av:'A1114LetCLetFec',fld:'LETCLETFEC',pic:''},{av:'A1110LetCForCod',fld:'LETCFORCOD',pic:'ZZZZZ9'},{av:'A1119LetCTipCmb',fld:'LETCTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1117LetCSts',fld:'LETCSTS',pic:''},{av:'A205LetCMonCod',fld:'LETCMONCOD',pic:'ZZZZZ9'},{av:'A1113LetCImporte',fld:'LETCIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1124LetCVouAno',fld:'LETCVOUANO',pic:'ZZZ9'},{av:'A1125LetCVouMes',fld:'LETCVOUMES',pic:'Z9'},{av:'A1118LetCTasiCod',fld:'LETCTASICOD',pic:'ZZZZZ9'},{av:'A1126LetCVouNum',fld:'LETCVOUNUM',pic:''},{av:'A1121LetCUsuCod',fld:'LETCUSUCOD',pic:''},{av:'A1122LetCUsuFec',fld:'LETCUSUFEC',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z204LetCLetCod'},{av:'Z206LetCCliCod'},{av:'Z1114LetCLetFec'},{av:'Z1110LetCForCod'},{av:'Z1119LetCTipCmb'},{av:'Z1117LetCSts'},{av:'Z205LetCMonCod'},{av:'Z1113LetCImporte'},{av:'Z1124LetCVouAno'},{av:'Z1125LetCVouMes'},{av:'Z1118LetCTasiCod'},{av:'Z1126LetCVouNum'},{av:'Z1121LetCUsuCod'},{av:'Z1122LetCUsuFec'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_LETCCLICOD","{handler:'Valid_Letcclicod',iparms:[{av:'A206LetCCliCod',fld:'LETCCLICOD',pic:''}]");
         setEventMetadata("VALID_LETCCLICOD",",oparms:[]}");
         setEventMetadata("VALID_LETCLETFEC","{handler:'Valid_Letcletfec',iparms:[]");
         setEventMetadata("VALID_LETCLETFEC",",oparms:[]}");
         setEventMetadata("VALID_LETCMONCOD","{handler:'Valid_Letcmoncod',iparms:[{av:'A205LetCMonCod',fld:'LETCMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LETCMONCOD",",oparms:[]}");
         setEventMetadata("VALID_LETCUSUFEC","{handler:'Valid_Letcusufec',iparms:[]");
         setEventMetadata("VALID_LETCUSUFEC",",oparms:[]}");
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
         Z204LetCLetCod = "";
         Z1114LetCLetFec = DateTime.MinValue;
         Z1117LetCSts = "";
         Z1126LetCVouNum = "";
         Z1121LetCUsuCod = "";
         Z1122LetCUsuFec = (DateTime)(DateTime.MinValue);
         Z206LetCCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A206LetCCliCod = "";
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
         A204LetCLetCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A1114LetCLetFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A1117LetCSts = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A1126LetCVouNum = "";
         lblTextblock13_Jsonclick = "";
         A1121LetCUsuCod = "";
         lblTextblock14_Jsonclick = "";
         A1122LetCUsuFec = (DateTime)(DateTime.MinValue);
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
         T002Q6_A204LetCLetCod = new string[] {""} ;
         T002Q6_A1114LetCLetFec = new DateTime[] {DateTime.MinValue} ;
         T002Q6_A1110LetCForCod = new int[1] ;
         T002Q6_A1119LetCTipCmb = new decimal[1] ;
         T002Q6_A1117LetCSts = new string[] {""} ;
         T002Q6_A1113LetCImporte = new decimal[1] ;
         T002Q6_A1124LetCVouAno = new short[1] ;
         T002Q6_A1125LetCVouMes = new short[1] ;
         T002Q6_A1118LetCTasiCod = new int[1] ;
         T002Q6_A1126LetCVouNum = new string[] {""} ;
         T002Q6_A1121LetCUsuCod = new string[] {""} ;
         T002Q6_A1122LetCUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002Q6_A206LetCCliCod = new string[] {""} ;
         T002Q6_A205LetCMonCod = new int[1] ;
         T002Q4_A206LetCCliCod = new string[] {""} ;
         T002Q5_A205LetCMonCod = new int[1] ;
         T002Q7_A206LetCCliCod = new string[] {""} ;
         T002Q8_A205LetCMonCod = new int[1] ;
         T002Q9_A204LetCLetCod = new string[] {""} ;
         T002Q3_A204LetCLetCod = new string[] {""} ;
         T002Q3_A1114LetCLetFec = new DateTime[] {DateTime.MinValue} ;
         T002Q3_A1110LetCForCod = new int[1] ;
         T002Q3_A1119LetCTipCmb = new decimal[1] ;
         T002Q3_A1117LetCSts = new string[] {""} ;
         T002Q3_A1113LetCImporte = new decimal[1] ;
         T002Q3_A1124LetCVouAno = new short[1] ;
         T002Q3_A1125LetCVouMes = new short[1] ;
         T002Q3_A1118LetCTasiCod = new int[1] ;
         T002Q3_A1126LetCVouNum = new string[] {""} ;
         T002Q3_A1121LetCUsuCod = new string[] {""} ;
         T002Q3_A1122LetCUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002Q3_A206LetCCliCod = new string[] {""} ;
         T002Q3_A205LetCMonCod = new int[1] ;
         sMode93 = "";
         T002Q10_A204LetCLetCod = new string[] {""} ;
         T002Q11_A204LetCLetCod = new string[] {""} ;
         T002Q2_A204LetCLetCod = new string[] {""} ;
         T002Q2_A1114LetCLetFec = new DateTime[] {DateTime.MinValue} ;
         T002Q2_A1110LetCForCod = new int[1] ;
         T002Q2_A1119LetCTipCmb = new decimal[1] ;
         T002Q2_A1117LetCSts = new string[] {""} ;
         T002Q2_A1113LetCImporte = new decimal[1] ;
         T002Q2_A1124LetCVouAno = new short[1] ;
         T002Q2_A1125LetCVouMes = new short[1] ;
         T002Q2_A1118LetCTasiCod = new int[1] ;
         T002Q2_A1126LetCVouNum = new string[] {""} ;
         T002Q2_A1121LetCUsuCod = new string[] {""} ;
         T002Q2_A1122LetCUsuFec = new DateTime[] {DateTime.MinValue} ;
         T002Q2_A206LetCCliCod = new string[] {""} ;
         T002Q2_A205LetCMonCod = new int[1] ;
         T002Q15_A204LetCLetCod = new string[] {""} ;
         T002Q15_A207LetCItem = new int[1] ;
         T002Q16_A204LetCLetCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ204LetCLetCod = "";
         ZZ206LetCCliCod = "";
         ZZ1114LetCLetFec = DateTime.MinValue;
         ZZ1117LetCSts = "";
         ZZ1126LetCVouNum = "";
         ZZ1121LetCUsuCod = "";
         ZZ1122LetCUsuFec = (DateTime)(DateTime.MinValue);
         T002Q17_A206LetCCliCod = new string[] {""} ;
         T002Q18_A205LetCMonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clletras__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clletras__default(),
            new Object[][] {
                new Object[] {
               T002Q2_A204LetCLetCod, T002Q2_A1114LetCLetFec, T002Q2_A1110LetCForCod, T002Q2_A1119LetCTipCmb, T002Q2_A1117LetCSts, T002Q2_A1113LetCImporte, T002Q2_A1124LetCVouAno, T002Q2_A1125LetCVouMes, T002Q2_A1118LetCTasiCod, T002Q2_A1126LetCVouNum,
               T002Q2_A1121LetCUsuCod, T002Q2_A1122LetCUsuFec, T002Q2_A206LetCCliCod, T002Q2_A205LetCMonCod
               }
               , new Object[] {
               T002Q3_A204LetCLetCod, T002Q3_A1114LetCLetFec, T002Q3_A1110LetCForCod, T002Q3_A1119LetCTipCmb, T002Q3_A1117LetCSts, T002Q3_A1113LetCImporte, T002Q3_A1124LetCVouAno, T002Q3_A1125LetCVouMes, T002Q3_A1118LetCTasiCod, T002Q3_A1126LetCVouNum,
               T002Q3_A1121LetCUsuCod, T002Q3_A1122LetCUsuFec, T002Q3_A206LetCCliCod, T002Q3_A205LetCMonCod
               }
               , new Object[] {
               T002Q4_A206LetCCliCod
               }
               , new Object[] {
               T002Q5_A205LetCMonCod
               }
               , new Object[] {
               T002Q6_A204LetCLetCod, T002Q6_A1114LetCLetFec, T002Q6_A1110LetCForCod, T002Q6_A1119LetCTipCmb, T002Q6_A1117LetCSts, T002Q6_A1113LetCImporte, T002Q6_A1124LetCVouAno, T002Q6_A1125LetCVouMes, T002Q6_A1118LetCTasiCod, T002Q6_A1126LetCVouNum,
               T002Q6_A1121LetCUsuCod, T002Q6_A1122LetCUsuFec, T002Q6_A206LetCCliCod, T002Q6_A205LetCMonCod
               }
               , new Object[] {
               T002Q7_A206LetCCliCod
               }
               , new Object[] {
               T002Q8_A205LetCMonCod
               }
               , new Object[] {
               T002Q9_A204LetCLetCod
               }
               , new Object[] {
               T002Q10_A204LetCLetCod
               }
               , new Object[] {
               T002Q11_A204LetCLetCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002Q15_A204LetCLetCod, T002Q15_A207LetCItem
               }
               , new Object[] {
               T002Q16_A204LetCLetCod
               }
               , new Object[] {
               T002Q17_A206LetCCliCod
               }
               , new Object[] {
               T002Q18_A205LetCMonCod
               }
            }
         );
      }

      private short Z1124LetCVouAno ;
      private short Z1125LetCVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1124LetCVouAno ;
      private short A1125LetCVouMes ;
      private short GX_JID ;
      private short RcdFound93 ;
      private short nIsDirty_93 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1124LetCVouAno ;
      private short ZZ1125LetCVouMes ;
      private int Z1110LetCForCod ;
      private int Z1118LetCTasiCod ;
      private int Z205LetCMonCod ;
      private int A205LetCMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLetCLetCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLetCCliCod_Enabled ;
      private int edtLetCLetFec_Enabled ;
      private int A1110LetCForCod ;
      private int edtLetCForCod_Enabled ;
      private int edtLetCTipCmb_Enabled ;
      private int edtLetCSts_Enabled ;
      private int edtLetCMonCod_Enabled ;
      private int edtLetCImporte_Enabled ;
      private int edtLetCVouAno_Enabled ;
      private int edtLetCVouMes_Enabled ;
      private int A1118LetCTasiCod ;
      private int edtLetCTasiCod_Enabled ;
      private int edtLetCVouNum_Enabled ;
      private int edtLetCUsuCod_Enabled ;
      private int edtLetCUsuFec_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ1110LetCForCod ;
      private int ZZ205LetCMonCod ;
      private int ZZ1118LetCTasiCod ;
      private decimal Z1119LetCTipCmb ;
      private decimal Z1113LetCImporte ;
      private decimal A1119LetCTipCmb ;
      private decimal A1113LetCImporte ;
      private decimal ZZ1119LetCTipCmb ;
      private decimal ZZ1113LetCImporte ;
      private string sPrefix ;
      private string Z204LetCLetCod ;
      private string Z1117LetCSts ;
      private string Z1126LetCVouNum ;
      private string Z1121LetCUsuCod ;
      private string Z206LetCCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A206LetCCliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLetCLetCod_Internalname ;
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
      private string A204LetCLetCod ;
      private string edtLetCLetCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLetCCliCod_Internalname ;
      private string edtLetCCliCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLetCLetFec_Internalname ;
      private string edtLetCLetFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLetCForCod_Internalname ;
      private string edtLetCForCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLetCTipCmb_Internalname ;
      private string edtLetCTipCmb_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLetCSts_Internalname ;
      private string A1117LetCSts ;
      private string edtLetCSts_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLetCMonCod_Internalname ;
      private string edtLetCMonCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtLetCImporte_Internalname ;
      private string edtLetCImporte_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLetCVouAno_Internalname ;
      private string edtLetCVouAno_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtLetCVouMes_Internalname ;
      private string edtLetCVouMes_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtLetCTasiCod_Internalname ;
      private string edtLetCTasiCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtLetCVouNum_Internalname ;
      private string A1126LetCVouNum ;
      private string edtLetCVouNum_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtLetCUsuCod_Internalname ;
      private string A1121LetCUsuCod ;
      private string edtLetCUsuCod_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtLetCUsuFec_Internalname ;
      private string edtLetCUsuFec_Jsonclick ;
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
      private string sMode93 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ204LetCLetCod ;
      private string ZZ206LetCCliCod ;
      private string ZZ1117LetCSts ;
      private string ZZ1126LetCVouNum ;
      private string ZZ1121LetCUsuCod ;
      private DateTime Z1122LetCUsuFec ;
      private DateTime A1122LetCUsuFec ;
      private DateTime ZZ1122LetCUsuFec ;
      private DateTime Z1114LetCLetFec ;
      private DateTime A1114LetCLetFec ;
      private DateTime ZZ1114LetCLetFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002Q6_A204LetCLetCod ;
      private DateTime[] T002Q6_A1114LetCLetFec ;
      private int[] T002Q6_A1110LetCForCod ;
      private decimal[] T002Q6_A1119LetCTipCmb ;
      private string[] T002Q6_A1117LetCSts ;
      private decimal[] T002Q6_A1113LetCImporte ;
      private short[] T002Q6_A1124LetCVouAno ;
      private short[] T002Q6_A1125LetCVouMes ;
      private int[] T002Q6_A1118LetCTasiCod ;
      private string[] T002Q6_A1126LetCVouNum ;
      private string[] T002Q6_A1121LetCUsuCod ;
      private DateTime[] T002Q6_A1122LetCUsuFec ;
      private string[] T002Q6_A206LetCCliCod ;
      private int[] T002Q6_A205LetCMonCod ;
      private string[] T002Q4_A206LetCCliCod ;
      private int[] T002Q5_A205LetCMonCod ;
      private string[] T002Q7_A206LetCCliCod ;
      private int[] T002Q8_A205LetCMonCod ;
      private string[] T002Q9_A204LetCLetCod ;
      private string[] T002Q3_A204LetCLetCod ;
      private DateTime[] T002Q3_A1114LetCLetFec ;
      private int[] T002Q3_A1110LetCForCod ;
      private decimal[] T002Q3_A1119LetCTipCmb ;
      private string[] T002Q3_A1117LetCSts ;
      private decimal[] T002Q3_A1113LetCImporte ;
      private short[] T002Q3_A1124LetCVouAno ;
      private short[] T002Q3_A1125LetCVouMes ;
      private int[] T002Q3_A1118LetCTasiCod ;
      private string[] T002Q3_A1126LetCVouNum ;
      private string[] T002Q3_A1121LetCUsuCod ;
      private DateTime[] T002Q3_A1122LetCUsuFec ;
      private string[] T002Q3_A206LetCCliCod ;
      private int[] T002Q3_A205LetCMonCod ;
      private string[] T002Q10_A204LetCLetCod ;
      private string[] T002Q11_A204LetCLetCod ;
      private string[] T002Q2_A204LetCLetCod ;
      private DateTime[] T002Q2_A1114LetCLetFec ;
      private int[] T002Q2_A1110LetCForCod ;
      private decimal[] T002Q2_A1119LetCTipCmb ;
      private string[] T002Q2_A1117LetCSts ;
      private decimal[] T002Q2_A1113LetCImporte ;
      private short[] T002Q2_A1124LetCVouAno ;
      private short[] T002Q2_A1125LetCVouMes ;
      private int[] T002Q2_A1118LetCTasiCod ;
      private string[] T002Q2_A1126LetCVouNum ;
      private string[] T002Q2_A1121LetCUsuCod ;
      private DateTime[] T002Q2_A1122LetCUsuFec ;
      private string[] T002Q2_A206LetCCliCod ;
      private int[] T002Q2_A205LetCMonCod ;
      private string[] T002Q15_A204LetCLetCod ;
      private int[] T002Q15_A207LetCItem ;
      private string[] T002Q16_A204LetCLetCod ;
      private string[] T002Q17_A206LetCCliCod ;
      private int[] T002Q18_A205LetCMonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clletras__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clletras__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002Q6;
        prmT002Q6 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q4;
        prmT002Q4 = new Object[] {
        new ParDef("@LetCCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002Q5;
        prmT002Q5 = new Object[] {
        new ParDef("@LetCMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002Q7;
        prmT002Q7 = new Object[] {
        new ParDef("@LetCCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002Q8;
        prmT002Q8 = new Object[] {
        new ParDef("@LetCMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002Q9;
        prmT002Q9 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q3;
        prmT002Q3 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q10;
        prmT002Q10 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q11;
        prmT002Q11 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q2;
        prmT002Q2 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q12;
        prmT002Q12 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetCLetFec",GXType.Date,8,0) ,
        new ParDef("@LetCForCod",GXType.Int32,6,0) ,
        new ParDef("@LetCTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LetCSts",GXType.NChar,1,0) ,
        new ParDef("@LetCImporte",GXType.Decimal,15,2) ,
        new ParDef("@LetCVouAno",GXType.Int16,4,0) ,
        new ParDef("@LetCVouMes",GXType.Int16,2,0) ,
        new ParDef("@LetCTasiCod",GXType.Int32,6,0) ,
        new ParDef("@LetCVouNum",GXType.NChar,10,0) ,
        new ParDef("@LetCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LetCUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LetCCliCod",GXType.NChar,20,0) ,
        new ParDef("@LetCMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002Q13;
        prmT002Q13 = new Object[] {
        new ParDef("@LetCLetFec",GXType.Date,8,0) ,
        new ParDef("@LetCForCod",GXType.Int32,6,0) ,
        new ParDef("@LetCTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LetCSts",GXType.NChar,1,0) ,
        new ParDef("@LetCImporte",GXType.Decimal,15,2) ,
        new ParDef("@LetCVouAno",GXType.Int16,4,0) ,
        new ParDef("@LetCVouMes",GXType.Int16,2,0) ,
        new ParDef("@LetCTasiCod",GXType.Int32,6,0) ,
        new ParDef("@LetCVouNum",GXType.NChar,10,0) ,
        new ParDef("@LetCUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LetCUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LetCCliCod",GXType.NChar,20,0) ,
        new ParDef("@LetCMonCod",GXType.Int32,6,0) ,
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q14;
        prmT002Q14 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q15;
        prmT002Q15 = new Object[] {
        new ParDef("@LetCLetCod",GXType.NChar,10,0)
        };
        Object[] prmT002Q16;
        prmT002Q16 = new Object[] {
        };
        Object[] prmT002Q17;
        prmT002Q17 = new Object[] {
        new ParDef("@LetCCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002Q18;
        prmT002Q18 = new Object[] {
        new ParDef("@LetCMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002Q2", "SELECT [LetCLetCod], [LetCLetFec], [LetCForCod], [LetCTipCmb], [LetCSts], [LetCImporte], [LetCVouAno], [LetCVouMes], [LetCTasiCod], [LetCVouNum], [LetCUsuCod], [LetCUsuFec], [LetCCliCod] AS LetCCliCod, [LetCMonCod] AS LetCMonCod FROM [CLLETRAS] WITH (UPDLOCK) WHERE [LetCLetCod] = @LetCLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q3", "SELECT [LetCLetCod], [LetCLetFec], [LetCForCod], [LetCTipCmb], [LetCSts], [LetCImporte], [LetCVouAno], [LetCVouMes], [LetCTasiCod], [LetCVouNum], [LetCUsuCod], [LetCUsuFec], [LetCCliCod] AS LetCCliCod, [LetCMonCod] AS LetCMonCod FROM [CLLETRAS] WHERE [LetCLetCod] = @LetCLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q4", "SELECT [CliCod] AS LetCCliCod FROM [CLCLIENTES] WHERE [CliCod] = @LetCCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q5", "SELECT [MonCod] AS LetCMonCod FROM [CMONEDAS] WHERE [MonCod] = @LetCMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q6", "SELECT TM1.[LetCLetCod], TM1.[LetCLetFec], TM1.[LetCForCod], TM1.[LetCTipCmb], TM1.[LetCSts], TM1.[LetCImporte], TM1.[LetCVouAno], TM1.[LetCVouMes], TM1.[LetCTasiCod], TM1.[LetCVouNum], TM1.[LetCUsuCod], TM1.[LetCUsuFec], TM1.[LetCCliCod] AS LetCCliCod, TM1.[LetCMonCod] AS LetCMonCod FROM [CLLETRAS] TM1 WHERE TM1.[LetCLetCod] = @LetCLetCod ORDER BY TM1.[LetCLetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q7", "SELECT [CliCod] AS LetCCliCod FROM [CLCLIENTES] WHERE [CliCod] = @LetCCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q8", "SELECT [MonCod] AS LetCMonCod FROM [CMONEDAS] WHERE [MonCod] = @LetCMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q9", "SELECT [LetCLetCod] FROM [CLLETRAS] WHERE [LetCLetCod] = @LetCLetCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q10", "SELECT TOP 1 [LetCLetCod] FROM [CLLETRAS] WHERE ( [LetCLetCod] > @LetCLetCod) ORDER BY [LetCLetCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Q11", "SELECT TOP 1 [LetCLetCod] FROM [CLLETRAS] WHERE ( [LetCLetCod] < @LetCLetCod) ORDER BY [LetCLetCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Q12", "INSERT INTO [CLLETRAS]([LetCLetCod], [LetCLetFec], [LetCForCod], [LetCTipCmb], [LetCSts], [LetCImporte], [LetCVouAno], [LetCVouMes], [LetCTasiCod], [LetCVouNum], [LetCUsuCod], [LetCUsuFec], [LetCCliCod], [LetCMonCod]) VALUES(@LetCLetCod, @LetCLetFec, @LetCForCod, @LetCTipCmb, @LetCSts, @LetCImporte, @LetCVouAno, @LetCVouMes, @LetCTasiCod, @LetCVouNum, @LetCUsuCod, @LetCUsuFec, @LetCCliCod, @LetCMonCod)", GxErrorMask.GX_NOMASK,prmT002Q12)
           ,new CursorDef("T002Q13", "UPDATE [CLLETRAS] SET [LetCLetFec]=@LetCLetFec, [LetCForCod]=@LetCForCod, [LetCTipCmb]=@LetCTipCmb, [LetCSts]=@LetCSts, [LetCImporte]=@LetCImporte, [LetCVouAno]=@LetCVouAno, [LetCVouMes]=@LetCVouMes, [LetCTasiCod]=@LetCTasiCod, [LetCVouNum]=@LetCVouNum, [LetCUsuCod]=@LetCUsuCod, [LetCUsuFec]=@LetCUsuFec, [LetCCliCod]=@LetCCliCod, [LetCMonCod]=@LetCMonCod  WHERE [LetCLetCod] = @LetCLetCod", GxErrorMask.GX_NOMASK,prmT002Q13)
           ,new CursorDef("T002Q14", "DELETE FROM [CLLETRAS]  WHERE [LetCLetCod] = @LetCLetCod", GxErrorMask.GX_NOMASK,prmT002Q14)
           ,new CursorDef("T002Q15", "SELECT TOP 1 [LetCLetCod], [LetCItem] FROM [CLLETRASDET] WHERE [LetCLetCod] = @LetCLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002Q16", "SELECT [LetCLetCod] FROM [CLLETRAS] ORDER BY [LetCLetCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q17", "SELECT [CliCod] AS LetCCliCod FROM [CLCLIENTES] WHERE [CliCod] = @LetCCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002Q18", "SELECT [MonCod] AS LetCMonCod FROM [CMONEDAS] WHERE [MonCod] = @LetCMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002Q18,1, GxCacheFrequency.OFF ,true,false )
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
