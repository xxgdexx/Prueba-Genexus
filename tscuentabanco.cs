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
   public class tscuentabanco : GXHttpHandler
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A372BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A372BanCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A180MonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A378CBCueCod = GetPar( "CBCueCod");
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A378CBCueCod) ;
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
            Form.Meta.addItem("description", "Cuentas de Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tscuentabanco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tscuentabanco( IGxContext context )
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
            RenderHtmlCloseForm57174( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSCUENTABANCO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Banco", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cuenta Banco", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCod_Internalname, StringUtil.RTrim( A377CBCod), StringUtil.RTrim( context.localUtil.Format( A377CBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Moneda", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "CBCue Cod", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCueCod_Internalname, StringUtil.RTrim( A378CBCueCod), StringUtil.RTrim( context.localUtil.Format( A378CBCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situación", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A504CBSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A504CBSts), "9") : context.localUtil.Format( (decimal)(A504CBSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Inicial", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCheqInicio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A490CBCheqInicio), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBCheqInicio_Enabled!=0) ? context.localUtil.Format( (decimal)(A490CBCheqInicio), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A490CBCheqInicio), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCheqInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCheqInicio_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Final", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCheqFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A489CBCheqFinal), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBCheqFinal_Enabled!=0) ? context.localUtil.Format( (decimal)(A489CBCheqFinal), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A489CBCheqFinal), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCheqFinal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCheqFinal_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Actual", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBCheqActual_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488CBCheqActual), 10, 0, ".", "")), StringUtil.LTrim( ((edtCBCheqActual_Enabled!=0) ? context.localUtil.Format( (decimal)(A488CBCheqActual), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A488CBCheqActual), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCheqActual_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCheqActual_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "CBCue Dsc", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSCUENTABANCO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCBCueDsc_Internalname, StringUtil.RTrim( A491CBCueDsc), StringUtil.RTrim( context.localUtil.Format( A491CBCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSCUENTABANCO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSCUENTABANCO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSCUENTABANCO.htm");
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
            Z372BanCod = (int)(context.localUtil.CToN( cgiGet( "Z372BanCod"), ".", ","));
            Z377CBCod = cgiGet( "Z377CBCod");
            Z504CBSts = (short)(context.localUtil.CToN( cgiGet( "Z504CBSts"), ".", ","));
            Z490CBCheqInicio = (long)(context.localUtil.CToN( cgiGet( "Z490CBCheqInicio"), ".", ","));
            Z489CBCheqFinal = (long)(context.localUtil.CToN( cgiGet( "Z489CBCheqFinal"), ".", ","));
            Z488CBCheqActual = (long)(context.localUtil.CToN( cgiGet( "Z488CBCheqActual"), ".", ","));
            Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
            Z378CBCueCod = cgiGet( "Z378CBCueCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANCOD");
               AnyError = 1;
               GX_FocusControl = edtBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A372BanCod = 0;
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            }
            else
            {
               A372BanCod = (int)(context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            }
            A377CBCod = cgiGet( edtCBCod_Internalname);
            AssignAttri("", false, "A377CBCod", A377CBCod);
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
            A378CBCueCod = cgiGet( edtCBCueCod_Internalname);
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBSTS");
               AnyError = 1;
               GX_FocusControl = edtCBSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A504CBSts = 0;
               AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
            }
            else
            {
               A504CBSts = (short)(context.localUtil.CToN( cgiGet( edtCBSts_Internalname), ".", ","));
               AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBCheqInicio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBCheqInicio_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBCHEQINICIO");
               AnyError = 1;
               GX_FocusControl = edtCBCheqInicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A490CBCheqInicio = 0;
               AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
            }
            else
            {
               A490CBCheqInicio = (long)(context.localUtil.CToN( cgiGet( edtCBCheqInicio_Internalname), ".", ","));
               AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBCheqFinal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBCheqFinal_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBCHEQFINAL");
               AnyError = 1;
               GX_FocusControl = edtCBCheqFinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A489CBCheqFinal = 0;
               AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
            }
            else
            {
               A489CBCheqFinal = (long)(context.localUtil.CToN( cgiGet( edtCBCheqFinal_Internalname), ".", ","));
               AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBCheqActual_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBCheqActual_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBCHEQACTUAL");
               AnyError = 1;
               GX_FocusControl = edtCBCheqActual_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A488CBCheqActual = 0;
               AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
            }
            else
            {
               A488CBCheqActual = (long)(context.localUtil.CToN( cgiGet( edtCBCheqActual_Internalname), ".", ","));
               AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
            }
            A491CBCueDsc = cgiGet( edtCBCueDsc_Internalname);
            AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
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
               A372BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               A377CBCod = GetPar( "CBCod");
               AssignAttri("", false, "A377CBCod", A377CBCod);
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
               InitAll57174( ) ;
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
         DisableAttributes57174( ) ;
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

      protected void CONFIRM_570( )
      {
         BeforeValidate57174( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls57174( ) ;
            }
            else
            {
               CheckExtendedTable57174( ) ;
               if ( AnyError == 0 )
               {
                  ZM57174( 2) ;
                  ZM57174( 3) ;
                  ZM57174( 4) ;
               }
               CloseExtendedTableCursors57174( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues570( ) ;
         }
      }

      protected void ResetCaption570( )
      {
      }

      protected void ZM57174( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z504CBSts = T00573_A504CBSts[0];
               Z490CBCheqInicio = T00573_A490CBCheqInicio[0];
               Z489CBCheqFinal = T00573_A489CBCheqFinal[0];
               Z488CBCheqActual = T00573_A488CBCheqActual[0];
               Z180MonCod = T00573_A180MonCod[0];
               Z378CBCueCod = T00573_A378CBCueCod[0];
            }
            else
            {
               Z504CBSts = A504CBSts;
               Z490CBCheqInicio = A490CBCheqInicio;
               Z489CBCheqFinal = A489CBCheqFinal;
               Z488CBCheqActual = A488CBCheqActual;
               Z180MonCod = A180MonCod;
               Z378CBCueCod = A378CBCueCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z377CBCod = A377CBCod;
            Z504CBSts = A504CBSts;
            Z490CBCheqInicio = A490CBCheqInicio;
            Z489CBCheqFinal = A489CBCheqFinal;
            Z488CBCheqActual = A488CBCheqActual;
            Z372BanCod = A372BanCod;
            Z180MonCod = A180MonCod;
            Z378CBCueCod = A378CBCueCod;
            Z491CBCueDsc = A491CBCueDsc;
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

      protected void Load57174( )
      {
         /* Using cursor T00577 */
         pr_default.execute(5, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound174 = 1;
            A504CBSts = T00577_A504CBSts[0];
            AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
            A490CBCheqInicio = T00577_A490CBCheqInicio[0];
            AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
            A489CBCheqFinal = T00577_A489CBCheqFinal[0];
            AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
            A488CBCheqActual = T00577_A488CBCheqActual[0];
            AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
            A491CBCueDsc = T00577_A491CBCueDsc[0];
            AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
            A180MonCod = T00577_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A378CBCueCod = T00577_A378CBCueCod[0];
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            ZM57174( -1) ;
         }
         pr_default.close(5);
         OnLoadActions57174( ) ;
      }

      protected void OnLoadActions57174( )
      {
      }

      protected void CheckExtendedTable57174( )
      {
         nIsDirty_174 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00574 */
         pr_default.execute(2, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00575 */
         pr_default.execute(3, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00576 */
         pr_default.execute(4, new Object[] {A378CBCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A491CBCueDsc = T00576_A491CBCueDsc[0];
         AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors57174( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A372BanCod )
      {
         /* Using cursor T00578 */
         pr_default.execute(6, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
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

      protected void gxLoad_3( int A180MonCod )
      {
         /* Using cursor T00579 */
         pr_default.execute(7, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
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

      protected void gxLoad_4( string A378CBCueCod )
      {
         /* Using cursor T005710 */
         pr_default.execute(8, new Object[] {A378CBCueCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A491CBCueDsc = T005710_A491CBCueDsc[0];
         AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A491CBCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey57174( )
      {
         /* Using cursor T005711 */
         pr_default.execute(9, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound174 = 1;
         }
         else
         {
            RcdFound174 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00573 */
         pr_default.execute(1, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM57174( 1) ;
            RcdFound174 = 1;
            A377CBCod = T00573_A377CBCod[0];
            AssignAttri("", false, "A377CBCod", A377CBCod);
            A504CBSts = T00573_A504CBSts[0];
            AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
            A490CBCheqInicio = T00573_A490CBCheqInicio[0];
            AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
            A489CBCheqFinal = T00573_A489CBCheqFinal[0];
            AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
            A488CBCheqActual = T00573_A488CBCheqActual[0];
            AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
            A372BanCod = T00573_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A180MonCod = T00573_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A378CBCueCod = T00573_A378CBCueCod[0];
            AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
            Z372BanCod = A372BanCod;
            Z377CBCod = A377CBCod;
            sMode174 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load57174( ) ;
            if ( AnyError == 1 )
            {
               RcdFound174 = 0;
               InitializeNonKey57174( ) ;
            }
            Gx_mode = sMode174;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound174 = 0;
            InitializeNonKey57174( ) ;
            sMode174 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode174;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey57174( ) ;
         if ( RcdFound174 == 0 )
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
         RcdFound174 = 0;
         /* Using cursor T005712 */
         pr_default.execute(10, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T005712_A372BanCod[0] < A372BanCod ) || ( T005712_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T005712_A377CBCod[0], A377CBCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T005712_A372BanCod[0] > A372BanCod ) || ( T005712_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T005712_A377CBCod[0], A377CBCod) > 0 ) ) )
            {
               A372BanCod = T005712_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               A377CBCod = T005712_A377CBCod[0];
               AssignAttri("", false, "A377CBCod", A377CBCod);
               RcdFound174 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound174 = 0;
         /* Using cursor T005713 */
         pr_default.execute(11, new Object[] {A372BanCod, A377CBCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T005713_A372BanCod[0] > A372BanCod ) || ( T005713_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T005713_A377CBCod[0], A377CBCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T005713_A372BanCod[0] < A372BanCod ) || ( T005713_A372BanCod[0] == A372BanCod ) && ( StringUtil.StrCmp(T005713_A377CBCod[0], A377CBCod) < 0 ) ) )
            {
               A372BanCod = T005713_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               A377CBCod = T005713_A377CBCod[0];
               AssignAttri("", false, "A377CBCod", A377CBCod);
               RcdFound174 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey57174( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert57174( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound174 == 1 )
            {
               if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
               {
                  A372BanCod = Z372BanCod;
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
                  A377CBCod = Z377CBCod;
                  AssignAttri("", false, "A377CBCod", A377CBCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update57174( ) ;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert57174( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert57174( ) ;
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
         if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
         {
            A372BanCod = Z372BanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A377CBCod = Z377CBCod;
            AssignAttri("", false, "A377CBCod", A377CBCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBanCod_Internalname;
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
         GetKey57174( ) ;
         if ( RcdFound174 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "BANCOD");
               AnyError = 1;
               GX_FocusControl = edtBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
            {
               A372BanCod = Z372BanCod;
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               A377CBCod = Z377CBCod;
               AssignAttri("", false, "A377CBCod", A377CBCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "BANCOD");
               AnyError = 1;
               GX_FocusControl = edtBanCod_Internalname;
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
            if ( ( A372BanCod != Z372BanCod ) || ( StringUtil.StrCmp(A377CBCod, Z377CBCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
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
         context.RollbackDataStores("tscuentabanco",pr_default);
         GX_FocusControl = edtMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_570( ) ;
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
         if ( RcdFound174 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart57174( ) ;
         if ( RcdFound174 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd57174( ) ;
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
         if ( RcdFound174 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonCod_Internalname;
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
         if ( RcdFound174 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonCod_Internalname;
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
         ScanStart57174( ) ;
         if ( RcdFound174 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound174 != 0 )
            {
               ScanNext57174( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd57174( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency57174( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00572 */
            pr_default.execute(0, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCUENTABANCO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z504CBSts != T00572_A504CBSts[0] ) || ( Z490CBCheqInicio != T00572_A490CBCheqInicio[0] ) || ( Z489CBCheqFinal != T00572_A489CBCheqFinal[0] ) || ( Z488CBCheqActual != T00572_A488CBCheqActual[0] ) || ( Z180MonCod != T00572_A180MonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z378CBCueCod, T00572_A378CBCueCod[0]) != 0 ) )
            {
               if ( Z504CBSts != T00572_A504CBSts[0] )
               {
                  GXUtil.WriteLog("tscuentabanco:[seudo value changed for attri]"+"CBSts");
                  GXUtil.WriteLogRaw("Old: ",Z504CBSts);
                  GXUtil.WriteLogRaw("Current: ",T00572_A504CBSts[0]);
               }
               if ( Z490CBCheqInicio != T00572_A490CBCheqInicio[0] )
               {
                  GXUtil.WriteLog("tscuentabanco:[seudo value changed for attri]"+"CBCheqInicio");
                  GXUtil.WriteLogRaw("Old: ",Z490CBCheqInicio);
                  GXUtil.WriteLogRaw("Current: ",T00572_A490CBCheqInicio[0]);
               }
               if ( Z489CBCheqFinal != T00572_A489CBCheqFinal[0] )
               {
                  GXUtil.WriteLog("tscuentabanco:[seudo value changed for attri]"+"CBCheqFinal");
                  GXUtil.WriteLogRaw("Old: ",Z489CBCheqFinal);
                  GXUtil.WriteLogRaw("Current: ",T00572_A489CBCheqFinal[0]);
               }
               if ( Z488CBCheqActual != T00572_A488CBCheqActual[0] )
               {
                  GXUtil.WriteLog("tscuentabanco:[seudo value changed for attri]"+"CBCheqActual");
                  GXUtil.WriteLogRaw("Old: ",Z488CBCheqActual);
                  GXUtil.WriteLogRaw("Current: ",T00572_A488CBCheqActual[0]);
               }
               if ( Z180MonCod != T00572_A180MonCod[0] )
               {
                  GXUtil.WriteLog("tscuentabanco:[seudo value changed for attri]"+"MonCod");
                  GXUtil.WriteLogRaw("Old: ",Z180MonCod);
                  GXUtil.WriteLogRaw("Current: ",T00572_A180MonCod[0]);
               }
               if ( StringUtil.StrCmp(Z378CBCueCod, T00572_A378CBCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tscuentabanco:[seudo value changed for attri]"+"CBCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z378CBCueCod);
                  GXUtil.WriteLogRaw("Current: ",T00572_A378CBCueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSCUENTABANCO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert57174( )
      {
         BeforeValidate57174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable57174( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM57174( 0) ;
            CheckOptimisticConcurrency57174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm57174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert57174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005714 */
                     pr_default.execute(12, new Object[] {A377CBCod, A504CBSts, A490CBCheqInicio, A489CBCheqFinal, A488CBCheqActual, A372BanCod, A180MonCod, A378CBCueCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCUENTABANCO");
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
                           ResetCaption570( ) ;
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
               Load57174( ) ;
            }
            EndLevel57174( ) ;
         }
         CloseExtendedTableCursors57174( ) ;
      }

      protected void Update57174( )
      {
         BeforeValidate57174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable57174( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency57174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm57174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate57174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005715 */
                     pr_default.execute(13, new Object[] {A504CBSts, A490CBCheqInicio, A489CBCheqFinal, A488CBCheqActual, A180MonCod, A378CBCueCod, A372BanCod, A377CBCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("TSCUENTABANCO");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSCUENTABANCO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate57174( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption570( ) ;
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
            EndLevel57174( ) ;
         }
         CloseExtendedTableCursors57174( ) ;
      }

      protected void DeferredUpdate57174( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate57174( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency57174( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls57174( ) ;
            AfterConfirm57174( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete57174( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005716 */
                  pr_default.execute(14, new Object[] {A372BanCod, A377CBCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("TSCUENTABANCO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound174 == 0 )
                        {
                           InitAll57174( ) ;
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
                        ResetCaption570( ) ;
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
         sMode174 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel57174( ) ;
         Gx_mode = sMode174;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls57174( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005717 */
            pr_default.execute(15, new Object[] {A378CBCueCod});
            A491CBCueDsc = T005717_A491CBCueDsc[0];
            AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005718 */
            pr_default.execute(16, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T005719 */
            pr_default.execute(17, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T005720 */
            pr_default.execute(18, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T005721 */
            pr_default.execute(19, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Libro Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T005722 */
            pr_default.execute(20, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T005723 */
            pr_default.execute(21, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T005724 */
            pr_default.execute(22, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T005725 */
            pr_default.execute(23, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T005726 */
            pr_default.execute(24, new Object[] {A372BanCod, A377CBCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel57174( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete57174( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            context.CommitDataStores("tscuentabanco",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues570( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            context.RollbackDataStores("tscuentabanco",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart57174( )
      {
         /* Using cursor T005727 */
         pr_default.execute(25);
         RcdFound174 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound174 = 1;
            A372BanCod = T005727_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A377CBCod = T005727_A377CBCod[0];
            AssignAttri("", false, "A377CBCod", A377CBCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext57174( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound174 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound174 = 1;
            A372BanCod = T005727_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A377CBCod = T005727_A377CBCod[0];
            AssignAttri("", false, "A377CBCod", A377CBCod);
         }
      }

      protected void ScanEnd57174( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm57174( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert57174( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate57174( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete57174( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete57174( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate57174( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes57174( )
      {
         edtBanCod_Enabled = 0;
         AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         edtCBCod_Enabled = 0;
         AssignProp("", false, edtCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCod_Enabled), 5, 0), true);
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         edtCBCueCod_Enabled = 0;
         AssignProp("", false, edtCBCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCueCod_Enabled), 5, 0), true);
         edtCBSts_Enabled = 0;
         AssignProp("", false, edtCBSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBSts_Enabled), 5, 0), true);
         edtCBCheqInicio_Enabled = 0;
         AssignProp("", false, edtCBCheqInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCheqInicio_Enabled), 5, 0), true);
         edtCBCheqFinal_Enabled = 0;
         AssignProp("", false, edtCBCheqFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCheqFinal_Enabled), 5, 0), true);
         edtCBCheqActual_Enabled = 0;
         AssignProp("", false, edtCBCheqActual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCheqActual_Enabled), 5, 0), true);
         edtCBCueDsc_Enabled = 0;
         AssignProp("", false, edtCBCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBCueDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes57174( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues570( )
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
         context.SendWebValue( "Cuentas de Bancos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255139", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tscuentabanco.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z372BanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z377CBCod", StringUtil.RTrim( Z377CBCod));
         GxWebStd.gx_hidden_field( context, "Z504CBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z504CBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z490CBCheqInicio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z490CBCheqInicio), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z489CBCheqFinal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z489CBCheqFinal), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z488CBCheqActual", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488CBCheqActual), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z378CBCueCod", StringUtil.RTrim( Z378CBCueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm57174( )
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
         return "TSCUENTABANCO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cuentas de Bancos" ;
      }

      protected void InitializeNonKey57174( )
      {
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         A378CBCueCod = "";
         AssignAttri("", false, "A378CBCueCod", A378CBCueCod);
         A504CBSts = 0;
         AssignAttri("", false, "A504CBSts", StringUtil.Str( (decimal)(A504CBSts), 1, 0));
         A490CBCheqInicio = 0;
         AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrimStr( (decimal)(A490CBCheqInicio), 10, 0));
         A489CBCheqFinal = 0;
         AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrimStr( (decimal)(A489CBCheqFinal), 10, 0));
         A488CBCheqActual = 0;
         AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrimStr( (decimal)(A488CBCheqActual), 10, 0));
         A491CBCueDsc = "";
         AssignAttri("", false, "A491CBCueDsc", A491CBCueDsc);
         Z504CBSts = 0;
         Z490CBCheqInicio = 0;
         Z489CBCheqFinal = 0;
         Z488CBCheqActual = 0;
         Z180MonCod = 0;
         Z378CBCueCod = "";
      }

      protected void InitAll57174( )
      {
         A372BanCod = 0;
         AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         A377CBCod = "";
         AssignAttri("", false, "A377CBCod", A377CBCod);
         InitializeNonKey57174( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810255148", true, true);
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
         context.AddJavascriptSource("tscuentabanco.js", "?202281810255148", false, true);
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
         edtBanCod_Internalname = "BANCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCBCod_Internalname = "CBCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMonCod_Internalname = "MONCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCBCueCod_Internalname = "CBCUECOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCBSts_Internalname = "CBSTS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCBCheqInicio_Internalname = "CBCHEQINICIO";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCBCheqFinal_Internalname = "CBCHEQFINAL";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCBCheqActual_Internalname = "CBCHEQACTUAL";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCBCueDsc_Internalname = "CBCUEDSC";
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
         edtCBCueDsc_Jsonclick = "";
         edtCBCueDsc_Enabled = 0;
         edtCBCheqActual_Jsonclick = "";
         edtCBCheqActual_Enabled = 1;
         edtCBCheqFinal_Jsonclick = "";
         edtCBCheqFinal_Enabled = 1;
         edtCBCheqInicio_Jsonclick = "";
         edtCBCheqInicio_Enabled = 1;
         edtCBSts_Jsonclick = "";
         edtCBSts_Enabled = 1;
         edtCBCueCod_Jsonclick = "";
         edtCBCueCod_Enabled = 1;
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCBCod_Jsonclick = "";
         edtCBCod_Enabled = 1;
         edtBanCod_Jsonclick = "";
         edtBanCod_Enabled = 1;
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
         /* Using cursor T005728 */
         pr_default.execute(26, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(26);
         GX_FocusControl = edtMonCod_Internalname;
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

      public void Valid_Bancod( )
      {
         /* Using cursor T005728 */
         pr_default.execute(26, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos'.", "ForeignKeyNotFound", 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
         }
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cbcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A378CBCueCod", StringUtil.RTrim( A378CBCueCod));
         AssignAttri("", false, "A504CBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A504CBSts), 1, 0, ".", "")));
         AssignAttri("", false, "A490CBCheqInicio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A490CBCheqInicio), 10, 0, ".", "")));
         AssignAttri("", false, "A489CBCheqFinal", StringUtil.LTrim( StringUtil.NToC( (decimal)(A489CBCheqFinal), 10, 0, ".", "")));
         AssignAttri("", false, "A488CBCheqActual", StringUtil.LTrim( StringUtil.NToC( (decimal)(A488CBCheqActual), 10, 0, ".", "")));
         AssignAttri("", false, "A491CBCueDsc", StringUtil.RTrim( A491CBCueDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z372BanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z377CBCod", StringUtil.RTrim( Z377CBCod));
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z378CBCueCod", StringUtil.RTrim( Z378CBCueCod));
         GxWebStd.gx_hidden_field( context, "Z504CBSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z504CBSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z490CBCheqInicio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z490CBCheqInicio), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z489CBCheqFinal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z489CBCheqFinal), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z488CBCheqActual", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488CBCheqActual), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z491CBCueDsc", StringUtil.RTrim( Z491CBCueDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Moncod( )
      {
         /* Using cursor T005729 */
         pr_default.execute(27, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Monedas'.", "ForeignKeyNotFound", 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cbcuecod( )
      {
         /* Using cursor T005717 */
         pr_default.execute(15, new Object[] {A378CBCueCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CBCUECOD");
            AnyError = 1;
            GX_FocusControl = edtCBCueCod_Internalname;
         }
         A491CBCueDsc = T005717_A491CBCueDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A491CBCueDsc", StringUtil.RTrim( A491CBCueDsc));
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
         setEventMetadata("VALID_BANCOD","{handler:'Valid_Bancod',iparms:[{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_BANCOD",",oparms:[]}");
         setEventMetadata("VALID_CBCOD","{handler:'Valid_Cbcod',iparms:[{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9'},{av:'A377CBCod',fld:'CBCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBCOD",",oparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A378CBCueCod',fld:'CBCUECOD',pic:''},{av:'A504CBSts',fld:'CBSTS',pic:'9'},{av:'A490CBCheqInicio',fld:'CBCHEQINICIO',pic:'ZZZZZZZZZ9'},{av:'A489CBCheqFinal',fld:'CBCHEQFINAL',pic:'ZZZZZZZZZ9'},{av:'A488CBCheqActual',fld:'CBCHEQACTUAL',pic:'ZZZZZZZZZ9'},{av:'A491CBCueDsc',fld:'CBCUEDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z372BanCod'},{av:'Z377CBCod'},{av:'Z180MonCod'},{av:'Z378CBCueCod'},{av:'Z504CBSts'},{av:'Z490CBCheqInicio'},{av:'Z489CBCheqFinal'},{av:'Z488CBCheqActual'},{av:'Z491CBCueDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MONCOD",",oparms:[]}");
         setEventMetadata("VALID_CBCUECOD","{handler:'Valid_Cbcuecod',iparms:[{av:'A378CBCueCod',fld:'CBCUECOD',pic:''},{av:'A491CBCueDsc',fld:'CBCUEDSC',pic:''}]");
         setEventMetadata("VALID_CBCUECOD",",oparms:[{av:'A491CBCueDsc',fld:'CBCUEDSC',pic:''}]}");
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
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z377CBCod = "";
         Z378CBCueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A378CBCueCod = "";
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
         A377CBCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A491CBCueDsc = "";
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
         Z491CBCueDsc = "";
         T00577_A377CBCod = new string[] {""} ;
         T00577_A504CBSts = new short[1] ;
         T00577_A490CBCheqInicio = new long[1] ;
         T00577_A489CBCheqFinal = new long[1] ;
         T00577_A488CBCheqActual = new long[1] ;
         T00577_A491CBCueDsc = new string[] {""} ;
         T00577_A372BanCod = new int[1] ;
         T00577_A180MonCod = new int[1] ;
         T00577_A378CBCueCod = new string[] {""} ;
         T00574_A372BanCod = new int[1] ;
         T00575_A180MonCod = new int[1] ;
         T00576_A491CBCueDsc = new string[] {""} ;
         T00578_A372BanCod = new int[1] ;
         T00579_A180MonCod = new int[1] ;
         T005710_A491CBCueDsc = new string[] {""} ;
         T005711_A372BanCod = new int[1] ;
         T005711_A377CBCod = new string[] {""} ;
         T00573_A377CBCod = new string[] {""} ;
         T00573_A504CBSts = new short[1] ;
         T00573_A490CBCheqInicio = new long[1] ;
         T00573_A489CBCheqFinal = new long[1] ;
         T00573_A488CBCheqActual = new long[1] ;
         T00573_A372BanCod = new int[1] ;
         T00573_A180MonCod = new int[1] ;
         T00573_A378CBCueCod = new string[] {""} ;
         sMode174 = "";
         T005712_A372BanCod = new int[1] ;
         T005712_A377CBCod = new string[] {""} ;
         T005713_A372BanCod = new int[1] ;
         T005713_A377CBCod = new string[] {""} ;
         T00572_A377CBCod = new string[] {""} ;
         T00572_A504CBSts = new short[1] ;
         T00572_A490CBCheqInicio = new long[1] ;
         T00572_A489CBCheqFinal = new long[1] ;
         T00572_A488CBCheqActual = new long[1] ;
         T00572_A372BanCod = new int[1] ;
         T00572_A180MonCod = new int[1] ;
         T00572_A378CBCueCod = new string[] {""} ;
         T005717_A491CBCueDsc = new string[] {""} ;
         T005718_A348UsuCod = new string[] {""} ;
         T005719_A412PagReg = new long[1] ;
         T005720_A387TSMovCod = new string[] {""} ;
         T005721_A379LBBanCod = new int[1] ;
         T005721_A380LBCBCod = new string[] {""} ;
         T005721_A381LBRegistro = new string[] {""} ;
         T005722_A365EntCod = new int[1] ;
         T005722_A366AperEntCod = new string[] {""} ;
         T005723_A358CajCod = new int[1] ;
         T005723_A359AperCajCod = new string[] {""} ;
         T005724_A354TSAntCod = new string[] {""} ;
         T005725_A270LiqCod = new string[] {""} ;
         T005725_A236LiqPrvCod = new string[] {""} ;
         T005725_A271LiqCodItem = new int[1] ;
         T005726_A166CobTip = new string[] {""} ;
         T005726_A167CobCod = new string[] {""} ;
         T005727_A372BanCod = new int[1] ;
         T005727_A377CBCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T005728_A372BanCod = new int[1] ;
         ZZ377CBCod = "";
         ZZ378CBCueCod = "";
         ZZ491CBCueDsc = "";
         T005729_A180MonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tscuentabanco__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tscuentabanco__default(),
            new Object[][] {
                new Object[] {
               T00572_A377CBCod, T00572_A504CBSts, T00572_A490CBCheqInicio, T00572_A489CBCheqFinal, T00572_A488CBCheqActual, T00572_A372BanCod, T00572_A180MonCod, T00572_A378CBCueCod
               }
               , new Object[] {
               T00573_A377CBCod, T00573_A504CBSts, T00573_A490CBCheqInicio, T00573_A489CBCheqFinal, T00573_A488CBCheqActual, T00573_A372BanCod, T00573_A180MonCod, T00573_A378CBCueCod
               }
               , new Object[] {
               T00574_A372BanCod
               }
               , new Object[] {
               T00575_A180MonCod
               }
               , new Object[] {
               T00576_A491CBCueDsc
               }
               , new Object[] {
               T00577_A377CBCod, T00577_A504CBSts, T00577_A490CBCheqInicio, T00577_A489CBCheqFinal, T00577_A488CBCheqActual, T00577_A491CBCueDsc, T00577_A372BanCod, T00577_A180MonCod, T00577_A378CBCueCod
               }
               , new Object[] {
               T00578_A372BanCod
               }
               , new Object[] {
               T00579_A180MonCod
               }
               , new Object[] {
               T005710_A491CBCueDsc
               }
               , new Object[] {
               T005711_A372BanCod, T005711_A377CBCod
               }
               , new Object[] {
               T005712_A372BanCod, T005712_A377CBCod
               }
               , new Object[] {
               T005713_A372BanCod, T005713_A377CBCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005717_A491CBCueDsc
               }
               , new Object[] {
               T005718_A348UsuCod
               }
               , new Object[] {
               T005719_A412PagReg
               }
               , new Object[] {
               T005720_A387TSMovCod
               }
               , new Object[] {
               T005721_A379LBBanCod, T005721_A380LBCBCod, T005721_A381LBRegistro
               }
               , new Object[] {
               T005722_A365EntCod, T005722_A366AperEntCod
               }
               , new Object[] {
               T005723_A358CajCod, T005723_A359AperCajCod
               }
               , new Object[] {
               T005724_A354TSAntCod
               }
               , new Object[] {
               T005725_A270LiqCod, T005725_A236LiqPrvCod, T005725_A271LiqCodItem
               }
               , new Object[] {
               T005726_A166CobTip, T005726_A167CobCod
               }
               , new Object[] {
               T005727_A372BanCod, T005727_A377CBCod
               }
               , new Object[] {
               T005728_A372BanCod
               }
               , new Object[] {
               T005729_A180MonCod
               }
            }
         );
      }

      private short Z504CBSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A504CBSts ;
      private short GX_JID ;
      private short RcdFound174 ;
      private short nIsDirty_174 ;
      private short Gx_BScreen ;
      private short ZZ504CBSts ;
      private int Z372BanCod ;
      private int Z180MonCod ;
      private int A372BanCod ;
      private int A180MonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtBanCod_Enabled ;
      private int edtCBCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMonCod_Enabled ;
      private int edtCBCueCod_Enabled ;
      private int edtCBSts_Enabled ;
      private int edtCBCheqInicio_Enabled ;
      private int edtCBCheqFinal_Enabled ;
      private int edtCBCheqActual_Enabled ;
      private int edtCBCueDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ372BanCod ;
      private int ZZ180MonCod ;
      private long Z490CBCheqInicio ;
      private long Z489CBCheqFinal ;
      private long Z488CBCheqActual ;
      private long A490CBCheqInicio ;
      private long A489CBCheqFinal ;
      private long A488CBCheqActual ;
      private long ZZ490CBCheqInicio ;
      private long ZZ489CBCheqFinal ;
      private long ZZ488CBCheqActual ;
      private string sPrefix ;
      private string Z377CBCod ;
      private string Z378CBCueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A378CBCueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtBanCod_Internalname ;
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
      private string edtBanCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCBCod_Internalname ;
      private string A377CBCod ;
      private string edtCBCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMonCod_Internalname ;
      private string edtMonCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCBCueCod_Internalname ;
      private string edtCBCueCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCBSts_Internalname ;
      private string edtCBSts_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCBCheqInicio_Internalname ;
      private string edtCBCheqInicio_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCBCheqFinal_Internalname ;
      private string edtCBCheqFinal_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCBCheqActual_Internalname ;
      private string edtCBCheqActual_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCBCueDsc_Internalname ;
      private string A491CBCueDsc ;
      private string edtCBCueDsc_Jsonclick ;
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
      private string Z491CBCueDsc ;
      private string sMode174 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ377CBCod ;
      private string ZZ378CBCueCod ;
      private string ZZ491CBCueDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00577_A377CBCod ;
      private short[] T00577_A504CBSts ;
      private long[] T00577_A490CBCheqInicio ;
      private long[] T00577_A489CBCheqFinal ;
      private long[] T00577_A488CBCheqActual ;
      private string[] T00577_A491CBCueDsc ;
      private int[] T00577_A372BanCod ;
      private int[] T00577_A180MonCod ;
      private string[] T00577_A378CBCueCod ;
      private int[] T00574_A372BanCod ;
      private int[] T00575_A180MonCod ;
      private string[] T00576_A491CBCueDsc ;
      private int[] T00578_A372BanCod ;
      private int[] T00579_A180MonCod ;
      private string[] T005710_A491CBCueDsc ;
      private int[] T005711_A372BanCod ;
      private string[] T005711_A377CBCod ;
      private string[] T00573_A377CBCod ;
      private short[] T00573_A504CBSts ;
      private long[] T00573_A490CBCheqInicio ;
      private long[] T00573_A489CBCheqFinal ;
      private long[] T00573_A488CBCheqActual ;
      private int[] T00573_A372BanCod ;
      private int[] T00573_A180MonCod ;
      private string[] T00573_A378CBCueCod ;
      private int[] T005712_A372BanCod ;
      private string[] T005712_A377CBCod ;
      private int[] T005713_A372BanCod ;
      private string[] T005713_A377CBCod ;
      private string[] T00572_A377CBCod ;
      private short[] T00572_A504CBSts ;
      private long[] T00572_A490CBCheqInicio ;
      private long[] T00572_A489CBCheqFinal ;
      private long[] T00572_A488CBCheqActual ;
      private int[] T00572_A372BanCod ;
      private int[] T00572_A180MonCod ;
      private string[] T00572_A378CBCueCod ;
      private string[] T005717_A491CBCueDsc ;
      private string[] T005718_A348UsuCod ;
      private long[] T005719_A412PagReg ;
      private string[] T005720_A387TSMovCod ;
      private int[] T005721_A379LBBanCod ;
      private string[] T005721_A380LBCBCod ;
      private string[] T005721_A381LBRegistro ;
      private int[] T005722_A365EntCod ;
      private string[] T005722_A366AperEntCod ;
      private int[] T005723_A358CajCod ;
      private string[] T005723_A359AperCajCod ;
      private string[] T005724_A354TSAntCod ;
      private string[] T005725_A270LiqCod ;
      private string[] T005725_A236LiqPrvCod ;
      private int[] T005725_A271LiqCodItem ;
      private string[] T005726_A166CobTip ;
      private string[] T005726_A167CobCod ;
      private int[] T005727_A372BanCod ;
      private string[] T005727_A377CBCod ;
      private int[] T005728_A372BanCod ;
      private int[] T005729_A180MonCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class tscuentabanco__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tscuentabanco__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00577;
        prmT00577 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT00574;
        prmT00574 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00575;
        prmT00575 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00576;
        prmT00576 = new Object[] {
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00578;
        prmT00578 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT00579;
        prmT00579 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT005710;
        prmT005710 = new Object[] {
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005711;
        prmT005711 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT00573;
        prmT00573 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005712;
        prmT005712 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005713;
        prmT005713 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT00572;
        prmT00572 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005714;
        prmT005714 = new Object[] {
        new ParDef("@CBCod",GXType.NChar,20,0) ,
        new ParDef("@CBSts",GXType.Int16,1,0) ,
        new ParDef("@CBCheqInicio",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqFinal",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqActual",GXType.Decimal,10,0) ,
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005715;
        prmT005715 = new Object[] {
        new ParDef("@CBSts",GXType.Int16,1,0) ,
        new ParDef("@CBCheqInicio",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqFinal",GXType.Decimal,10,0) ,
        new ParDef("@CBCheqActual",GXType.Decimal,10,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@CBCueCod",GXType.NChar,15,0) ,
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005716;
        prmT005716 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005718;
        prmT005718 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005719;
        prmT005719 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005720;
        prmT005720 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005721;
        prmT005721 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005722;
        prmT005722 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005723;
        prmT005723 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005724;
        prmT005724 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005725;
        prmT005725 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005726;
        prmT005726 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@CBCod",GXType.NChar,20,0)
        };
        Object[] prmT005727;
        prmT005727 = new Object[] {
        };
        Object[] prmT005728;
        prmT005728 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT005729;
        prmT005729 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT005717;
        prmT005717 = new Object[] {
        new ParDef("@CBCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00572", "SELECT [CBCod], [CBSts], [CBCheqInicio], [CBCheqFinal], [CBCheqActual], [BanCod], [MonCod], [CBCueCod] AS CBCueCod FROM [TSCUENTABANCO] WITH (UPDLOCK) WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00572,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00573", "SELECT [CBCod], [CBSts], [CBCheqInicio], [CBCheqFinal], [CBCheqActual], [BanCod], [MonCod], [CBCueCod] AS CBCueCod FROM [TSCUENTABANCO] WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00573,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00574", "SELECT [BanCod] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00574,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00575", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00575,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00576", "SELECT [CueDsc] AS CBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00576,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00577", "SELECT TM1.[CBCod], TM1.[CBSts], TM1.[CBCheqInicio], TM1.[CBCheqFinal], TM1.[CBCheqActual], T2.[CueDsc] AS CBCueDsc, TM1.[BanCod], TM1.[MonCod], TM1.[CBCueCod] AS CBCueCod FROM ([TSCUENTABANCO] TM1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[CBCueCod]) WHERE TM1.[BanCod] = @BanCod and TM1.[CBCod] = @CBCod ORDER BY TM1.[BanCod], TM1.[CBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00577,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00578", "SELECT [BanCod] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00578,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00579", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00579,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005710", "SELECT [CueDsc] AS CBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005710,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005711", "SELECT [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005711,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005712", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE ( [BanCod] > @BanCod or [BanCod] = @BanCod and [CBCod] > @CBCod) ORDER BY [BanCod], [CBCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005712,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005713", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE ( [BanCod] < @BanCod or [BanCod] = @BanCod and [CBCod] < @CBCod) ORDER BY [BanCod] DESC, [CBCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005713,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005714", "INSERT INTO [TSCUENTABANCO]([CBCod], [CBSts], [CBCheqInicio], [CBCheqFinal], [CBCheqActual], [BanCod], [MonCod], [CBCueCod]) VALUES(@CBCod, @CBSts, @CBCheqInicio, @CBCheqFinal, @CBCheqActual, @BanCod, @MonCod, @CBCueCod)", GxErrorMask.GX_NOMASK,prmT005714)
           ,new CursorDef("T005715", "UPDATE [TSCUENTABANCO] SET [CBSts]=@CBSts, [CBCheqInicio]=@CBCheqInicio, [CBCheqFinal]=@CBCheqFinal, [CBCheqActual]=@CBCheqActual, [MonCod]=@MonCod, [CBCueCod]=@CBCueCod  WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod", GxErrorMask.GX_NOMASK,prmT005715)
           ,new CursorDef("T005716", "DELETE FROM [TSCUENTABANCO]  WHERE [BanCod] = @BanCod AND [CBCod] = @CBCod", GxErrorMask.GX_NOMASK,prmT005716)
           ,new CursorDef("T005717", "SELECT [CueDsc] AS CBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @CBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005717,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005718", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuMosBanCod] = @BanCod AND [UsuMosCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005718,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005719", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagBanCod] = @BanCod AND [PagCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005719,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005720", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovBanCod] = @BanCod AND [TSMovCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005720,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005721", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @BanCod AND [LBCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005721,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005722", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEBanCod] = @BanCod AND [AperECueBan] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005722,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005723", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperBanCod] = @BanCod AND [AperCueBan] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005723,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005724", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [TSAntBanCod] = @BanCod AND [TSAntCBCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005724,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005725", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqBanCod] = @BanCod AND [LiqBanCue] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005725,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005726", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobBanCod] = @BanCod AND [CobCbCod] = @CBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005726,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005727", "SELECT [BanCod], [CBCod] FROM [TSCUENTABANCO] ORDER BY [BanCod], [CBCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005727,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005728", "SELECT [BanCod] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005728,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005729", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005729,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 26 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
