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
   public class tsaperturaentrega : GXDataArea
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
            A365EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A365EntCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A371AperEMonCod = (int)(NumberUtil.Val( GetPar( "AperEMonCod"), "."));
            AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrimStr( (decimal)(A371AperEMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A371AperEMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A370AperEForCod = (int)(NumberUtil.Val( GetPar( "AperEForCod"), "."));
            AssignAttri("", false, "A370AperEForCod", StringUtil.LTrimStr( (decimal)(A370AperEForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A370AperEForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A368AperEBanCod = (int)(NumberUtil.Val( GetPar( "AperEBanCod"), "."));
            n368AperEBanCod = false;
            AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrimStr( (decimal)(A368AperEBanCod), 6, 0));
            A369AperECueBan = GetPar( "AperECueBan");
            n369AperECueBan = false;
            AssignAttri("", false, "A369AperECueBan", A369AperECueBan);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A368AperEBanCod, A369AperECueBan) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A367AperETmov = (int)(NumberUtil.Val( GetPar( "AperETmov"), "."));
            n367AperETmov = false;
            AssignAttri("", false, "A367AperETmov", StringUtil.LTrimStr( (decimal)(A367AperETmov), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A367AperETmov) ;
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
            Form.Meta.addItem("description", "Apertura de Entrega a Rendir", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsaperturaentrega( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsaperturaentrega( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSAPERTURAENTREGA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365EntCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtEntCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Entrega a Rendir", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEntCod_Internalname, StringUtil.RTrim( A366AperEntCod), StringUtil.RTrim( context.localUtil.Format( A366AperEntCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEntCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha Apertura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAperEntFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAperEntFec_Internalname, context.localUtil.Format(A449AperEntFec, "99/99/99"), context.localUtil.Format( A449AperEntFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEntFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEntFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         GxWebStd.gx_bitmap( context, edtAperEntFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAperEntFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Moneda", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A371AperEMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperEMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A371AperEMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A371AperEMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo forma pago", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A370AperEForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperEForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A370AperEForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A370AperEForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Banco", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A368AperEBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperEBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A368AperEBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A368AperEBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Cuenta", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperECueBan_Internalname, StringUtil.RTrim( A369AperECueBan), StringUtil.RTrim( context.localUtil.Format( A369AperECueBan, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperECueBan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperECueBan_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "N° Cheque", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperECheque_Internalname, StringUtil.RTrim( A444AperECheque), StringUtil.RTrim( context.localUtil.Format( A444AperECheque, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperECheque_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperECheque_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Saldo Anterior", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperESaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A450AperESaldo, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperESaldo_Enabled!=0) ? context.localUtil.Format( A450AperESaldo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A450AperESaldo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperESaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperESaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Importe Mov.", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A445AperEImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperEImporte_Enabled!=0) ? context.localUtil.Format( A445AperEImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A445AperEImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Reposiciones", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEReponer_Internalname, StringUtil.LTrim( StringUtil.NToC( A447AperEReponer, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperEReponer_Enabled!=0) ? context.localUtil.Format( A447AperEReponer, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A447AperEReponer, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEReponer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEReponer_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Importe Tope", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperETope_Internalname, StringUtil.LTrim( StringUtil.NToC( A454AperETope, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperETope_Enabled!=0) ? context.localUtil.Format( A454AperETope, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A454AperETope, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperETope_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperETope_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Movimiento Bancos", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperETmov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AperETmov), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperETmov_Enabled!=0) ? context.localUtil.Format( (decimal)(A367AperETmov), "ZZZZZ9") : context.localUtil.Format( (decimal)(A367AperETmov), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperETmov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperETmov_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "N° Registro", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperEBanReg_Internalname, StringUtil.RTrim( A443AperEBanReg), StringUtil.RTrim( context.localUtil.Format( A443AperEBanReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEBanReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEBanReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Situacion", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperESts_Internalname, StringUtil.RTrim( A451AperESts), StringUtil.RTrim( context.localUtil.Format( A451AperESts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperESts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperESts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Total Item", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperETItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A452AperETItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperETItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A452AperETItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A452AperETItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperETItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperETItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Importe Total", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAperEImpTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A446AperEImpTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperEImpTotal_Enabled!=0) ? context.localUtil.Format( A446AperEImpTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A446AperEImpTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEImpTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEImpTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Moneda", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAperEMonDsc_Internalname, StringUtil.RTrim( A448AperEMonDsc), StringUtil.RTrim( context.localUtil.Format( A448AperEMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperEMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperEMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Movimiento Bancos", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAperETMovDsc_Internalname, StringUtil.RTrim( A453AperETMovDsc), StringUtil.RTrim( context.localUtil.Format( A453AperETMovDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperETMovDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperETMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURAENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURAENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSAPERTURAENTREGA.htm");
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
            Z365EntCod = (int)(context.localUtil.CToN( cgiGet( "Z365EntCod"), ".", ","));
            Z366AperEntCod = cgiGet( "Z366AperEntCod");
            Z449AperEntFec = context.localUtil.CToD( cgiGet( "Z449AperEntFec"), 0);
            Z444AperECheque = cgiGet( "Z444AperECheque");
            Z450AperESaldo = context.localUtil.CToN( cgiGet( "Z450AperESaldo"), ".", ",");
            Z445AperEImporte = context.localUtil.CToN( cgiGet( "Z445AperEImporte"), ".", ",");
            Z447AperEReponer = context.localUtil.CToN( cgiGet( "Z447AperEReponer"), ".", ",");
            Z454AperETope = context.localUtil.CToN( cgiGet( "Z454AperETope"), ".", ",");
            Z443AperEBanReg = cgiGet( "Z443AperEBanReg");
            n443AperEBanReg = (String.IsNullOrEmpty(StringUtil.RTrim( A443AperEBanReg)) ? true : false);
            Z451AperESts = cgiGet( "Z451AperESts");
            Z452AperETItem = (int)(context.localUtil.CToN( cgiGet( "Z452AperETItem"), ".", ","));
            Z371AperEMonCod = (int)(context.localUtil.CToN( cgiGet( "Z371AperEMonCod"), ".", ","));
            Z370AperEForCod = (int)(context.localUtil.CToN( cgiGet( "Z370AperEForCod"), ".", ","));
            Z368AperEBanCod = (int)(context.localUtil.CToN( cgiGet( "Z368AperEBanCod"), ".", ","));
            n368AperEBanCod = ((0==A368AperEBanCod) ? true : false);
            Z369AperECueBan = cgiGet( "Z369AperECueBan");
            n369AperECueBan = (String.IsNullOrEmpty(StringUtil.RTrim( A369AperECueBan)) ? true : false);
            Z367AperETmov = (int)(context.localUtil.CToN( cgiGet( "Z367AperETmov"), ".", ","));
            n367AperETmov = ((0==A367AperETmov) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A365EntCod = 0;
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            }
            else
            {
               A365EntCod = (int)(context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ","));
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            }
            A366AperEntCod = cgiGet( edtAperEntCod_Internalname);
            AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
            if ( context.localUtil.VCDate( cgiGet( edtAperEntFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Apertura"}), 1, "APERENTFEC");
               AnyError = 1;
               GX_FocusControl = edtAperEntFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A449AperEntFec = DateTime.MinValue;
               AssignAttri("", false, "A449AperEntFec", context.localUtil.Format(A449AperEntFec, "99/99/99"));
            }
            else
            {
               A449AperEntFec = context.localUtil.CToD( cgiGet( edtAperEntFec_Internalname), 2);
               AssignAttri("", false, "A449AperEntFec", context.localUtil.Format(A449AperEntFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperEMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperEMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APEREMONCOD");
               AnyError = 1;
               GX_FocusControl = edtAperEMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A371AperEMonCod = 0;
               AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrimStr( (decimal)(A371AperEMonCod), 6, 0));
            }
            else
            {
               A371AperEMonCod = (int)(context.localUtil.CToN( cgiGet( edtAperEMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrimStr( (decimal)(A371AperEMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperEForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperEForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APEREFORCOD");
               AnyError = 1;
               GX_FocusControl = edtAperEForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A370AperEForCod = 0;
               AssignAttri("", false, "A370AperEForCod", StringUtil.LTrimStr( (decimal)(A370AperEForCod), 6, 0));
            }
            else
            {
               A370AperEForCod = (int)(context.localUtil.CToN( cgiGet( edtAperEForCod_Internalname), ".", ","));
               AssignAttri("", false, "A370AperEForCod", StringUtil.LTrimStr( (decimal)(A370AperEForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperEBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperEBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APEREBANCOD");
               AnyError = 1;
               GX_FocusControl = edtAperEBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A368AperEBanCod = 0;
               n368AperEBanCod = false;
               AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrimStr( (decimal)(A368AperEBanCod), 6, 0));
            }
            else
            {
               A368AperEBanCod = (int)(context.localUtil.CToN( cgiGet( edtAperEBanCod_Internalname), ".", ","));
               n368AperEBanCod = false;
               AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrimStr( (decimal)(A368AperEBanCod), 6, 0));
            }
            n368AperEBanCod = ((0==A368AperEBanCod) ? true : false);
            A369AperECueBan = cgiGet( edtAperECueBan_Internalname);
            n369AperECueBan = false;
            AssignAttri("", false, "A369AperECueBan", A369AperECueBan);
            n369AperECueBan = (String.IsNullOrEmpty(StringUtil.RTrim( A369AperECueBan)) ? true : false);
            A444AperECheque = cgiGet( edtAperECheque_Internalname);
            AssignAttri("", false, "A444AperECheque", A444AperECheque);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperESaldo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperESaldo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERESALDO");
               AnyError = 1;
               GX_FocusControl = edtAperESaldo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A450AperESaldo = 0;
               AssignAttri("", false, "A450AperESaldo", StringUtil.LTrimStr( A450AperESaldo, 15, 2));
            }
            else
            {
               A450AperESaldo = context.localUtil.CToN( cgiGet( edtAperESaldo_Internalname), ".", ",");
               AssignAttri("", false, "A450AperESaldo", StringUtil.LTrimStr( A450AperESaldo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperEImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperEImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APEREIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtAperEImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A445AperEImporte = 0;
               AssignAttri("", false, "A445AperEImporte", StringUtil.LTrimStr( A445AperEImporte, 15, 2));
            }
            else
            {
               A445AperEImporte = context.localUtil.CToN( cgiGet( edtAperEImporte_Internalname), ".", ",");
               AssignAttri("", false, "A445AperEImporte", StringUtil.LTrimStr( A445AperEImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperEReponer_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperEReponer_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APEREREPONER");
               AnyError = 1;
               GX_FocusControl = edtAperEReponer_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A447AperEReponer = 0;
               AssignAttri("", false, "A447AperEReponer", StringUtil.LTrimStr( A447AperEReponer, 15, 2));
            }
            else
            {
               A447AperEReponer = context.localUtil.CToN( cgiGet( edtAperEReponer_Internalname), ".", ",");
               AssignAttri("", false, "A447AperEReponer", StringUtil.LTrimStr( A447AperEReponer, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperETope_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperETope_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERETOPE");
               AnyError = 1;
               GX_FocusControl = edtAperETope_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A454AperETope = 0;
               AssignAttri("", false, "A454AperETope", StringUtil.LTrimStr( A454AperETope, 15, 2));
            }
            else
            {
               A454AperETope = context.localUtil.CToN( cgiGet( edtAperETope_Internalname), ".", ",");
               AssignAttri("", false, "A454AperETope", StringUtil.LTrimStr( A454AperETope, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperETmov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperETmov_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERETMOV");
               AnyError = 1;
               GX_FocusControl = edtAperETmov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A367AperETmov = 0;
               n367AperETmov = false;
               AssignAttri("", false, "A367AperETmov", StringUtil.LTrimStr( (decimal)(A367AperETmov), 6, 0));
            }
            else
            {
               A367AperETmov = (int)(context.localUtil.CToN( cgiGet( edtAperETmov_Internalname), ".", ","));
               n367AperETmov = false;
               AssignAttri("", false, "A367AperETmov", StringUtil.LTrimStr( (decimal)(A367AperETmov), 6, 0));
            }
            n367AperETmov = ((0==A367AperETmov) ? true : false);
            A443AperEBanReg = cgiGet( edtAperEBanReg_Internalname);
            n443AperEBanReg = false;
            AssignAttri("", false, "A443AperEBanReg", A443AperEBanReg);
            n443AperEBanReg = (String.IsNullOrEmpty(StringUtil.RTrim( A443AperEBanReg)) ? true : false);
            A451AperESts = cgiGet( edtAperESts_Internalname);
            AssignAttri("", false, "A451AperESts", A451AperESts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperETItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperETItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERETITEM");
               AnyError = 1;
               GX_FocusControl = edtAperETItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A452AperETItem = 0;
               AssignAttri("", false, "A452AperETItem", StringUtil.LTrimStr( (decimal)(A452AperETItem), 6, 0));
            }
            else
            {
               A452AperETItem = (int)(context.localUtil.CToN( cgiGet( edtAperETItem_Internalname), ".", ","));
               AssignAttri("", false, "A452AperETItem", StringUtil.LTrimStr( (decimal)(A452AperETItem), 6, 0));
            }
            A446AperEImpTotal = context.localUtil.CToN( cgiGet( edtAperEImpTotal_Internalname), ".", ",");
            AssignAttri("", false, "A446AperEImpTotal", StringUtil.LTrimStr( A446AperEImpTotal, 15, 2));
            A448AperEMonDsc = cgiGet( edtAperEMonDsc_Internalname);
            AssignAttri("", false, "A448AperEMonDsc", A448AperEMonDsc);
            A453AperETMovDsc = cgiGet( edtAperETMovDsc_Internalname);
            AssignAttri("", false, "A453AperETMovDsc", A453AperETMovDsc);
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
               A365EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A366AperEntCod = GetPar( "AperEntCod");
               AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
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
               InitAll50167( ) ;
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
         DisableAttributes50167( ) ;
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

      protected void CONFIRM_500( )
      {
         BeforeValidate50167( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls50167( ) ;
            }
            else
            {
               CheckExtendedTable50167( ) ;
               if ( AnyError == 0 )
               {
                  ZM50167( 4) ;
                  ZM50167( 5) ;
                  ZM50167( 6) ;
                  ZM50167( 7) ;
                  ZM50167( 8) ;
               }
               CloseExtendedTableCursors50167( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues500( ) ;
         }
      }

      protected void ResetCaption500( )
      {
      }

      protected void ZM50167( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z449AperEntFec = T00503_A449AperEntFec[0];
               Z444AperECheque = T00503_A444AperECheque[0];
               Z450AperESaldo = T00503_A450AperESaldo[0];
               Z445AperEImporte = T00503_A445AperEImporte[0];
               Z447AperEReponer = T00503_A447AperEReponer[0];
               Z454AperETope = T00503_A454AperETope[0];
               Z443AperEBanReg = T00503_A443AperEBanReg[0];
               Z451AperESts = T00503_A451AperESts[0];
               Z452AperETItem = T00503_A452AperETItem[0];
               Z371AperEMonCod = T00503_A371AperEMonCod[0];
               Z370AperEForCod = T00503_A370AperEForCod[0];
               Z368AperEBanCod = T00503_A368AperEBanCod[0];
               Z369AperECueBan = T00503_A369AperECueBan[0];
               Z367AperETmov = T00503_A367AperETmov[0];
            }
            else
            {
               Z449AperEntFec = A449AperEntFec;
               Z444AperECheque = A444AperECheque;
               Z450AperESaldo = A450AperESaldo;
               Z445AperEImporte = A445AperEImporte;
               Z447AperEReponer = A447AperEReponer;
               Z454AperETope = A454AperETope;
               Z443AperEBanReg = A443AperEBanReg;
               Z451AperESts = A451AperESts;
               Z452AperETItem = A452AperETItem;
               Z371AperEMonCod = A371AperEMonCod;
               Z370AperEForCod = A370AperEForCod;
               Z368AperEBanCod = A368AperEBanCod;
               Z369AperECueBan = A369AperECueBan;
               Z367AperETmov = A367AperETmov;
            }
         }
         if ( GX_JID == -3 )
         {
            Z366AperEntCod = A366AperEntCod;
            Z449AperEntFec = A449AperEntFec;
            Z444AperECheque = A444AperECheque;
            Z450AperESaldo = A450AperESaldo;
            Z445AperEImporte = A445AperEImporte;
            Z447AperEReponer = A447AperEReponer;
            Z454AperETope = A454AperETope;
            Z443AperEBanReg = A443AperEBanReg;
            Z451AperESts = A451AperESts;
            Z452AperETItem = A452AperETItem;
            Z365EntCod = A365EntCod;
            Z371AperEMonCod = A371AperEMonCod;
            Z370AperEForCod = A370AperEForCod;
            Z368AperEBanCod = A368AperEBanCod;
            Z369AperECueBan = A369AperECueBan;
            Z367AperETmov = A367AperETmov;
            Z448AperEMonDsc = A448AperEMonDsc;
            Z453AperETMovDsc = A453AperETMovDsc;
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

      protected void Load50167( )
      {
         /* Using cursor T00509 */
         pr_default.execute(7, new Object[] {A365EntCod, A366AperEntCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound167 = 1;
            A449AperEntFec = T00509_A449AperEntFec[0];
            AssignAttri("", false, "A449AperEntFec", context.localUtil.Format(A449AperEntFec, "99/99/99"));
            A444AperECheque = T00509_A444AperECheque[0];
            AssignAttri("", false, "A444AperECheque", A444AperECheque);
            A450AperESaldo = T00509_A450AperESaldo[0];
            AssignAttri("", false, "A450AperESaldo", StringUtil.LTrimStr( A450AperESaldo, 15, 2));
            A445AperEImporte = T00509_A445AperEImporte[0];
            AssignAttri("", false, "A445AperEImporte", StringUtil.LTrimStr( A445AperEImporte, 15, 2));
            A447AperEReponer = T00509_A447AperEReponer[0];
            AssignAttri("", false, "A447AperEReponer", StringUtil.LTrimStr( A447AperEReponer, 15, 2));
            A454AperETope = T00509_A454AperETope[0];
            AssignAttri("", false, "A454AperETope", StringUtil.LTrimStr( A454AperETope, 15, 2));
            A443AperEBanReg = T00509_A443AperEBanReg[0];
            n443AperEBanReg = T00509_n443AperEBanReg[0];
            AssignAttri("", false, "A443AperEBanReg", A443AperEBanReg);
            A451AperESts = T00509_A451AperESts[0];
            AssignAttri("", false, "A451AperESts", A451AperESts);
            A452AperETItem = T00509_A452AperETItem[0];
            AssignAttri("", false, "A452AperETItem", StringUtil.LTrimStr( (decimal)(A452AperETItem), 6, 0));
            A448AperEMonDsc = T00509_A448AperEMonDsc[0];
            AssignAttri("", false, "A448AperEMonDsc", A448AperEMonDsc);
            A453AperETMovDsc = T00509_A453AperETMovDsc[0];
            AssignAttri("", false, "A453AperETMovDsc", A453AperETMovDsc);
            A371AperEMonCod = T00509_A371AperEMonCod[0];
            AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrimStr( (decimal)(A371AperEMonCod), 6, 0));
            A370AperEForCod = T00509_A370AperEForCod[0];
            AssignAttri("", false, "A370AperEForCod", StringUtil.LTrimStr( (decimal)(A370AperEForCod), 6, 0));
            A368AperEBanCod = T00509_A368AperEBanCod[0];
            n368AperEBanCod = T00509_n368AperEBanCod[0];
            AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrimStr( (decimal)(A368AperEBanCod), 6, 0));
            A369AperECueBan = T00509_A369AperECueBan[0];
            n369AperECueBan = T00509_n369AperECueBan[0];
            AssignAttri("", false, "A369AperECueBan", A369AperECueBan);
            A367AperETmov = T00509_A367AperETmov[0];
            n367AperETmov = T00509_n367AperETmov[0];
            AssignAttri("", false, "A367AperETmov", StringUtil.LTrimStr( (decimal)(A367AperETmov), 6, 0));
            ZM50167( -3) ;
         }
         pr_default.close(7);
         OnLoadActions50167( ) ;
      }

      protected void OnLoadActions50167( )
      {
         A446AperEImpTotal = (decimal)(A447AperEReponer+A445AperEImporte);
         AssignAttri("", false, "A446AperEImpTotal", StringUtil.LTrimStr( A446AperEImpTotal, 15, 2));
      }

      protected void CheckExtendedTable50167( )
      {
         nIsDirty_167 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00504 */
         pr_default.execute(2, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A449AperEntFec) || ( DateTimeUtil.ResetTime ( A449AperEntFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Apertura fuera de rango", "OutOfRange", 1, "APERENTFEC");
            AnyError = 1;
            GX_FocusControl = edtAperEntFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00505 */
         pr_default.execute(3, new Object[] {A371AperEMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "APEREMONCOD");
            AnyError = 1;
            GX_FocusControl = edtAperEMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A448AperEMonDsc = T00505_A448AperEMonDsc[0];
         AssignAttri("", false, "A448AperEMonDsc", A448AperEMonDsc);
         pr_default.close(3);
         /* Using cursor T00506 */
         pr_default.execute(4, new Object[] {A370AperEForCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "APEREFORCOD");
            AnyError = 1;
            GX_FocusControl = edtAperEForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T00507 */
         pr_default.execute(5, new Object[] {n368AperEBanCod, A368AperEBanCod, n369AperECueBan, A369AperECueBan});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A368AperEBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A369AperECueBan)) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "APERECUEBAN");
               AnyError = 1;
               GX_FocusControl = edtAperEBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         nIsDirty_167 = 1;
         A446AperEImpTotal = (decimal)(A447AperEReponer+A445AperEImporte);
         AssignAttri("", false, "A446AperEImpTotal", StringUtil.LTrimStr( A446AperEImpTotal, 15, 2));
         /* Using cursor T00508 */
         pr_default.execute(6, new Object[] {n367AperETmov, A367AperETmov});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A367AperETmov) ) )
            {
               GX_msglist.addItem("No existe 'Movimiento'.", "ForeignKeyNotFound", 1, "APERETMOV");
               AnyError = 1;
               GX_FocusControl = edtAperETmov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A453AperETMovDsc = T00508_A453AperETMovDsc[0];
         AssignAttri("", false, "A453AperETMovDsc", A453AperETMovDsc);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors50167( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A365EntCod )
      {
         /* Using cursor T005010 */
         pr_default.execute(8, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
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

      protected void gxLoad_5( int A371AperEMonCod )
      {
         /* Using cursor T005011 */
         pr_default.execute(9, new Object[] {A371AperEMonCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "APEREMONCOD");
            AnyError = 1;
            GX_FocusControl = edtAperEMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A448AperEMonDsc = T005011_A448AperEMonDsc[0];
         AssignAttri("", false, "A448AperEMonDsc", A448AperEMonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A448AperEMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( int A370AperEForCod )
      {
         /* Using cursor T005012 */
         pr_default.execute(10, new Object[] {A370AperEForCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "APEREFORCOD");
            AnyError = 1;
            GX_FocusControl = edtAperEForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_7( int A368AperEBanCod ,
                               string A369AperECueBan )
      {
         /* Using cursor T005013 */
         pr_default.execute(11, new Object[] {n368AperEBanCod, A368AperEBanCod, n369AperECueBan, A369AperECueBan});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A368AperEBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A369AperECueBan)) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "APERECUEBAN");
               AnyError = 1;
               GX_FocusControl = edtAperEBanCod_Internalname;
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

      protected void gxLoad_8( int A367AperETmov )
      {
         /* Using cursor T005014 */
         pr_default.execute(12, new Object[] {n367AperETmov, A367AperETmov});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A367AperETmov) ) )
            {
               GX_msglist.addItem("No existe 'Movimiento'.", "ForeignKeyNotFound", 1, "APERETMOV");
               AnyError = 1;
               GX_FocusControl = edtAperETmov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A453AperETMovDsc = T005014_A453AperETMovDsc[0];
         AssignAttri("", false, "A453AperETMovDsc", A453AperETMovDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A453AperETMovDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey50167( )
      {
         /* Using cursor T005015 */
         pr_default.execute(13, new Object[] {A365EntCod, A366AperEntCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound167 = 1;
         }
         else
         {
            RcdFound167 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00503 */
         pr_default.execute(1, new Object[] {A365EntCod, A366AperEntCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM50167( 3) ;
            RcdFound167 = 1;
            A366AperEntCod = T00503_A366AperEntCod[0];
            AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
            A449AperEntFec = T00503_A449AperEntFec[0];
            AssignAttri("", false, "A449AperEntFec", context.localUtil.Format(A449AperEntFec, "99/99/99"));
            A444AperECheque = T00503_A444AperECheque[0];
            AssignAttri("", false, "A444AperECheque", A444AperECheque);
            A450AperESaldo = T00503_A450AperESaldo[0];
            AssignAttri("", false, "A450AperESaldo", StringUtil.LTrimStr( A450AperESaldo, 15, 2));
            A445AperEImporte = T00503_A445AperEImporte[0];
            AssignAttri("", false, "A445AperEImporte", StringUtil.LTrimStr( A445AperEImporte, 15, 2));
            A447AperEReponer = T00503_A447AperEReponer[0];
            AssignAttri("", false, "A447AperEReponer", StringUtil.LTrimStr( A447AperEReponer, 15, 2));
            A454AperETope = T00503_A454AperETope[0];
            AssignAttri("", false, "A454AperETope", StringUtil.LTrimStr( A454AperETope, 15, 2));
            A443AperEBanReg = T00503_A443AperEBanReg[0];
            n443AperEBanReg = T00503_n443AperEBanReg[0];
            AssignAttri("", false, "A443AperEBanReg", A443AperEBanReg);
            A451AperESts = T00503_A451AperESts[0];
            AssignAttri("", false, "A451AperESts", A451AperESts);
            A452AperETItem = T00503_A452AperETItem[0];
            AssignAttri("", false, "A452AperETItem", StringUtil.LTrimStr( (decimal)(A452AperETItem), 6, 0));
            A365EntCod = T00503_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A371AperEMonCod = T00503_A371AperEMonCod[0];
            AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrimStr( (decimal)(A371AperEMonCod), 6, 0));
            A370AperEForCod = T00503_A370AperEForCod[0];
            AssignAttri("", false, "A370AperEForCod", StringUtil.LTrimStr( (decimal)(A370AperEForCod), 6, 0));
            A368AperEBanCod = T00503_A368AperEBanCod[0];
            n368AperEBanCod = T00503_n368AperEBanCod[0];
            AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrimStr( (decimal)(A368AperEBanCod), 6, 0));
            A369AperECueBan = T00503_A369AperECueBan[0];
            n369AperECueBan = T00503_n369AperECueBan[0];
            AssignAttri("", false, "A369AperECueBan", A369AperECueBan);
            A367AperETmov = T00503_A367AperETmov[0];
            n367AperETmov = T00503_n367AperETmov[0];
            AssignAttri("", false, "A367AperETmov", StringUtil.LTrimStr( (decimal)(A367AperETmov), 6, 0));
            Z365EntCod = A365EntCod;
            Z366AperEntCod = A366AperEntCod;
            sMode167 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load50167( ) ;
            if ( AnyError == 1 )
            {
               RcdFound167 = 0;
               InitializeNonKey50167( ) ;
            }
            Gx_mode = sMode167;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound167 = 0;
            InitializeNonKey50167( ) ;
            sMode167 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode167;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey50167( ) ;
         if ( RcdFound167 == 0 )
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
         RcdFound167 = 0;
         /* Using cursor T005016 */
         pr_default.execute(14, new Object[] {A365EntCod, A366AperEntCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T005016_A365EntCod[0] < A365EntCod ) || ( T005016_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005016_A366AperEntCod[0], A366AperEntCod) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T005016_A365EntCod[0] > A365EntCod ) || ( T005016_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005016_A366AperEntCod[0], A366AperEntCod) > 0 ) ) )
            {
               A365EntCod = T005016_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A366AperEntCod = T005016_A366AperEntCod[0];
               AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
               RcdFound167 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound167 = 0;
         /* Using cursor T005017 */
         pr_default.execute(15, new Object[] {A365EntCod, A366AperEntCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T005017_A365EntCod[0] > A365EntCod ) || ( T005017_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005017_A366AperEntCod[0], A366AperEntCod) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T005017_A365EntCod[0] < A365EntCod ) || ( T005017_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005017_A366AperEntCod[0], A366AperEntCod) < 0 ) ) )
            {
               A365EntCod = T005017_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A366AperEntCod = T005017_A366AperEntCod[0];
               AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
               RcdFound167 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey50167( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert50167( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound167 == 1 )
            {
               if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A366AperEntCod, Z366AperEntCod) != 0 ) )
               {
                  A365EntCod = Z365EntCod;
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
                  A366AperEntCod = Z366AperEntCod;
                  AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update50167( ) ;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A366AperEntCod, Z366AperEntCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert50167( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert50167( ) ;
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
         if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A366AperEntCod, Z366AperEntCod) != 0 ) )
         {
            A365EntCod = Z365EntCod;
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A366AperEntCod = Z366AperEntCod;
            AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEntCod_Internalname;
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
         GetKey50167( ) ;
         if ( RcdFound167 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A366AperEntCod, Z366AperEntCod) != 0 ) )
            {
               A365EntCod = Z365EntCod;
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A366AperEntCod = Z366AperEntCod;
               AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
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
            if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A366AperEntCod, Z366AperEntCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
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
         context.RollbackDataStores("tsaperturaentrega",pr_default);
         GX_FocusControl = edtAperEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_500( ) ;
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
         if ( RcdFound167 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAperEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart50167( ) ;
         if ( RcdFound167 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd50167( ) ;
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
         if ( RcdFound167 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperEntFec_Internalname;
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
         if ( RcdFound167 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperEntFec_Internalname;
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
         ScanStart50167( ) ;
         if ( RcdFound167 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound167 != 0 )
            {
               ScanNext50167( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd50167( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency50167( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00502 */
            pr_default.execute(0, new Object[] {A365EntCod, A366AperEntCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSAPERTURAENTREGA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z449AperEntFec ) != DateTimeUtil.ResetTime ( T00502_A449AperEntFec[0] ) ) || ( StringUtil.StrCmp(Z444AperECheque, T00502_A444AperECheque[0]) != 0 ) || ( Z450AperESaldo != T00502_A450AperESaldo[0] ) || ( Z445AperEImporte != T00502_A445AperEImporte[0] ) || ( Z447AperEReponer != T00502_A447AperEReponer[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z454AperETope != T00502_A454AperETope[0] ) || ( StringUtil.StrCmp(Z443AperEBanReg, T00502_A443AperEBanReg[0]) != 0 ) || ( StringUtil.StrCmp(Z451AperESts, T00502_A451AperESts[0]) != 0 ) || ( Z452AperETItem != T00502_A452AperETItem[0] ) || ( Z371AperEMonCod != T00502_A371AperEMonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z370AperEForCod != T00502_A370AperEForCod[0] ) || ( Z368AperEBanCod != T00502_A368AperEBanCod[0] ) || ( StringUtil.StrCmp(Z369AperECueBan, T00502_A369AperECueBan[0]) != 0 ) || ( Z367AperETmov != T00502_A367AperETmov[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z449AperEntFec ) != DateTimeUtil.ResetTime ( T00502_A449AperEntFec[0] ) )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEntFec");
                  GXUtil.WriteLogRaw("Old: ",Z449AperEntFec);
                  GXUtil.WriteLogRaw("Current: ",T00502_A449AperEntFec[0]);
               }
               if ( StringUtil.StrCmp(Z444AperECheque, T00502_A444AperECheque[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperECheque");
                  GXUtil.WriteLogRaw("Old: ",Z444AperECheque);
                  GXUtil.WriteLogRaw("Current: ",T00502_A444AperECheque[0]);
               }
               if ( Z450AperESaldo != T00502_A450AperESaldo[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperESaldo");
                  GXUtil.WriteLogRaw("Old: ",Z450AperESaldo);
                  GXUtil.WriteLogRaw("Current: ",T00502_A450AperESaldo[0]);
               }
               if ( Z445AperEImporte != T00502_A445AperEImporte[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEImporte");
                  GXUtil.WriteLogRaw("Old: ",Z445AperEImporte);
                  GXUtil.WriteLogRaw("Current: ",T00502_A445AperEImporte[0]);
               }
               if ( Z447AperEReponer != T00502_A447AperEReponer[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEReponer");
                  GXUtil.WriteLogRaw("Old: ",Z447AperEReponer);
                  GXUtil.WriteLogRaw("Current: ",T00502_A447AperEReponer[0]);
               }
               if ( Z454AperETope != T00502_A454AperETope[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperETope");
                  GXUtil.WriteLogRaw("Old: ",Z454AperETope);
                  GXUtil.WriteLogRaw("Current: ",T00502_A454AperETope[0]);
               }
               if ( StringUtil.StrCmp(Z443AperEBanReg, T00502_A443AperEBanReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEBanReg");
                  GXUtil.WriteLogRaw("Old: ",Z443AperEBanReg);
                  GXUtil.WriteLogRaw("Current: ",T00502_A443AperEBanReg[0]);
               }
               if ( StringUtil.StrCmp(Z451AperESts, T00502_A451AperESts[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperESts");
                  GXUtil.WriteLogRaw("Old: ",Z451AperESts);
                  GXUtil.WriteLogRaw("Current: ",T00502_A451AperESts[0]);
               }
               if ( Z452AperETItem != T00502_A452AperETItem[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperETItem");
                  GXUtil.WriteLogRaw("Old: ",Z452AperETItem);
                  GXUtil.WriteLogRaw("Current: ",T00502_A452AperETItem[0]);
               }
               if ( Z371AperEMonCod != T00502_A371AperEMonCod[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z371AperEMonCod);
                  GXUtil.WriteLogRaw("Current: ",T00502_A371AperEMonCod[0]);
               }
               if ( Z370AperEForCod != T00502_A370AperEForCod[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEForCod");
                  GXUtil.WriteLogRaw("Old: ",Z370AperEForCod);
                  GXUtil.WriteLogRaw("Current: ",T00502_A370AperEForCod[0]);
               }
               if ( Z368AperEBanCod != T00502_A368AperEBanCod[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperEBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z368AperEBanCod);
                  GXUtil.WriteLogRaw("Current: ",T00502_A368AperEBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z369AperECueBan, T00502_A369AperECueBan[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperECueBan");
                  GXUtil.WriteLogRaw("Old: ",Z369AperECueBan);
                  GXUtil.WriteLogRaw("Current: ",T00502_A369AperECueBan[0]);
               }
               if ( Z367AperETmov != T00502_A367AperETmov[0] )
               {
                  GXUtil.WriteLog("tsaperturaentrega:[seudo value changed for attri]"+"AperETmov");
                  GXUtil.WriteLogRaw("Old: ",Z367AperETmov);
                  GXUtil.WriteLogRaw("Current: ",T00502_A367AperETmov[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSAPERTURAENTREGA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert50167( )
      {
         BeforeValidate50167( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable50167( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM50167( 0) ;
            CheckOptimisticConcurrency50167( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm50167( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert50167( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005018 */
                     pr_default.execute(16, new Object[] {A366AperEntCod, A449AperEntFec, A444AperECheque, A450AperESaldo, A445AperEImporte, A447AperEReponer, A454AperETope, n443AperEBanReg, A443AperEBanReg, A451AperESts, A452AperETItem, A365EntCod, A371AperEMonCod, A370AperEForCod, n368AperEBanCod, A368AperEBanCod, n369AperECueBan, A369AperECueBan, n367AperETmov, A367AperETmov});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("TSAPERTURAENTREGA");
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
                           ResetCaption500( ) ;
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
               Load50167( ) ;
            }
            EndLevel50167( ) ;
         }
         CloseExtendedTableCursors50167( ) ;
      }

      protected void Update50167( )
      {
         BeforeValidate50167( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable50167( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency50167( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm50167( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate50167( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005019 */
                     pr_default.execute(17, new Object[] {A449AperEntFec, A444AperECheque, A450AperESaldo, A445AperEImporte, A447AperEReponer, A454AperETope, n443AperEBanReg, A443AperEBanReg, A451AperESts, A452AperETItem, A371AperEMonCod, A370AperEForCod, n368AperEBanCod, A368AperEBanCod, n369AperECueBan, A369AperECueBan, n367AperETmov, A367AperETmov, A365EntCod, A366AperEntCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("TSAPERTURAENTREGA");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSAPERTURAENTREGA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate50167( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption500( ) ;
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
            EndLevel50167( ) ;
         }
         CloseExtendedTableCursors50167( ) ;
      }

      protected void DeferredUpdate50167( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate50167( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency50167( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls50167( ) ;
            AfterConfirm50167( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete50167( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005020 */
                  pr_default.execute(18, new Object[] {A365EntCod, A366AperEntCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("TSAPERTURAENTREGA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound167 == 0 )
                        {
                           InitAll50167( ) ;
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
                        ResetCaption500( ) ;
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
         sMode167 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel50167( ) ;
         Gx_mode = sMode167;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls50167( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005021 */
            pr_default.execute(19, new Object[] {A371AperEMonCod});
            A448AperEMonDsc = T005021_A448AperEMonDsc[0];
            AssignAttri("", false, "A448AperEMonDsc", A448AperEMonDsc);
            pr_default.close(19);
            A446AperEImpTotal = (decimal)(A447AperEReponer+A445AperEImporte);
            AssignAttri("", false, "A446AperEImpTotal", StringUtil.LTrimStr( A446AperEImpTotal, 15, 2));
            /* Using cursor T005022 */
            pr_default.execute(20, new Object[] {n367AperETmov, A367AperETmov});
            A453AperETMovDsc = T005022_A453AperETMovDsc[0];
            AssignAttri("", false, "A453AperETMovDsc", A453AperETMovDsc);
            pr_default.close(20);
         }
      }

      protected void EndLevel50167( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete50167( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            context.CommitDataStores("tsaperturaentrega",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues500( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            context.RollbackDataStores("tsaperturaentrega",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart50167( )
      {
         /* Using cursor T005023 */
         pr_default.execute(21);
         RcdFound167 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound167 = 1;
            A365EntCod = T005023_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A366AperEntCod = T005023_A366AperEntCod[0];
            AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext50167( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound167 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound167 = 1;
            A365EntCod = T005023_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A366AperEntCod = T005023_A366AperEntCod[0];
            AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
         }
      }

      protected void ScanEnd50167( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm50167( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert50167( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate50167( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete50167( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete50167( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate50167( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes50167( )
      {
         edtEntCod_Enabled = 0;
         AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         edtAperEntCod_Enabled = 0;
         AssignProp("", false, edtAperEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEntCod_Enabled), 5, 0), true);
         edtAperEntFec_Enabled = 0;
         AssignProp("", false, edtAperEntFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEntFec_Enabled), 5, 0), true);
         edtAperEMonCod_Enabled = 0;
         AssignProp("", false, edtAperEMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEMonCod_Enabled), 5, 0), true);
         edtAperEForCod_Enabled = 0;
         AssignProp("", false, edtAperEForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEForCod_Enabled), 5, 0), true);
         edtAperEBanCod_Enabled = 0;
         AssignProp("", false, edtAperEBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEBanCod_Enabled), 5, 0), true);
         edtAperECueBan_Enabled = 0;
         AssignProp("", false, edtAperECueBan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperECueBan_Enabled), 5, 0), true);
         edtAperECheque_Enabled = 0;
         AssignProp("", false, edtAperECheque_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperECheque_Enabled), 5, 0), true);
         edtAperESaldo_Enabled = 0;
         AssignProp("", false, edtAperESaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperESaldo_Enabled), 5, 0), true);
         edtAperEImporte_Enabled = 0;
         AssignProp("", false, edtAperEImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEImporte_Enabled), 5, 0), true);
         edtAperEReponer_Enabled = 0;
         AssignProp("", false, edtAperEReponer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEReponer_Enabled), 5, 0), true);
         edtAperETope_Enabled = 0;
         AssignProp("", false, edtAperETope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperETope_Enabled), 5, 0), true);
         edtAperETmov_Enabled = 0;
         AssignProp("", false, edtAperETmov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperETmov_Enabled), 5, 0), true);
         edtAperEBanReg_Enabled = 0;
         AssignProp("", false, edtAperEBanReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEBanReg_Enabled), 5, 0), true);
         edtAperESts_Enabled = 0;
         AssignProp("", false, edtAperESts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperESts_Enabled), 5, 0), true);
         edtAperETItem_Enabled = 0;
         AssignProp("", false, edtAperETItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperETItem_Enabled), 5, 0), true);
         edtAperEImpTotal_Enabled = 0;
         AssignProp("", false, edtAperEImpTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEImpTotal_Enabled), 5, 0), true);
         edtAperEMonDsc_Enabled = 0;
         AssignProp("", false, edtAperEMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperEMonDsc_Enabled), 5, 0), true);
         edtAperETMovDsc_Enabled = 0;
         AssignProp("", false, edtAperETMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperETMovDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes50167( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues500( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255028", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsaperturaentrega.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z366AperEntCod", StringUtil.RTrim( Z366AperEntCod));
         GxWebStd.gx_hidden_field( context, "Z449AperEntFec", context.localUtil.DToC( Z449AperEntFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z444AperECheque", StringUtil.RTrim( Z444AperECheque));
         GxWebStd.gx_hidden_field( context, "Z450AperESaldo", StringUtil.LTrim( StringUtil.NToC( Z450AperESaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z445AperEImporte", StringUtil.LTrim( StringUtil.NToC( Z445AperEImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z447AperEReponer", StringUtil.LTrim( StringUtil.NToC( Z447AperEReponer, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z454AperETope", StringUtil.LTrim( StringUtil.NToC( Z454AperETope, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z443AperEBanReg", StringUtil.RTrim( Z443AperEBanReg));
         GxWebStd.gx_hidden_field( context, "Z451AperESts", StringUtil.RTrim( Z451AperESts));
         GxWebStd.gx_hidden_field( context, "Z452AperETItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z452AperETItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z371AperEMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z371AperEMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z370AperEForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z370AperEForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z368AperEBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z368AperEBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z369AperECueBan", StringUtil.RTrim( Z369AperECueBan));
         GxWebStd.gx_hidden_field( context, "Z367AperETmov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z367AperETmov), 6, 0, ".", "")));
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
         return formatLink("tsaperturaentrega.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSAPERTURAENTREGA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Apertura de Entrega a Rendir" ;
      }

      protected void InitializeNonKey50167( )
      {
         A446AperEImpTotal = 0;
         AssignAttri("", false, "A446AperEImpTotal", StringUtil.LTrimStr( A446AperEImpTotal, 15, 2));
         A449AperEntFec = DateTime.MinValue;
         AssignAttri("", false, "A449AperEntFec", context.localUtil.Format(A449AperEntFec, "99/99/99"));
         A371AperEMonCod = 0;
         AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrimStr( (decimal)(A371AperEMonCod), 6, 0));
         A370AperEForCod = 0;
         AssignAttri("", false, "A370AperEForCod", StringUtil.LTrimStr( (decimal)(A370AperEForCod), 6, 0));
         A368AperEBanCod = 0;
         n368AperEBanCod = false;
         AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrimStr( (decimal)(A368AperEBanCod), 6, 0));
         n368AperEBanCod = ((0==A368AperEBanCod) ? true : false);
         A369AperECueBan = "";
         n369AperECueBan = false;
         AssignAttri("", false, "A369AperECueBan", A369AperECueBan);
         n369AperECueBan = (String.IsNullOrEmpty(StringUtil.RTrim( A369AperECueBan)) ? true : false);
         A444AperECheque = "";
         AssignAttri("", false, "A444AperECheque", A444AperECheque);
         A450AperESaldo = 0;
         AssignAttri("", false, "A450AperESaldo", StringUtil.LTrimStr( A450AperESaldo, 15, 2));
         A445AperEImporte = 0;
         AssignAttri("", false, "A445AperEImporte", StringUtil.LTrimStr( A445AperEImporte, 15, 2));
         A447AperEReponer = 0;
         AssignAttri("", false, "A447AperEReponer", StringUtil.LTrimStr( A447AperEReponer, 15, 2));
         A454AperETope = 0;
         AssignAttri("", false, "A454AperETope", StringUtil.LTrimStr( A454AperETope, 15, 2));
         A367AperETmov = 0;
         n367AperETmov = false;
         AssignAttri("", false, "A367AperETmov", StringUtil.LTrimStr( (decimal)(A367AperETmov), 6, 0));
         n367AperETmov = ((0==A367AperETmov) ? true : false);
         A443AperEBanReg = "";
         n443AperEBanReg = false;
         AssignAttri("", false, "A443AperEBanReg", A443AperEBanReg);
         n443AperEBanReg = (String.IsNullOrEmpty(StringUtil.RTrim( A443AperEBanReg)) ? true : false);
         A451AperESts = "";
         AssignAttri("", false, "A451AperESts", A451AperESts);
         A452AperETItem = 0;
         AssignAttri("", false, "A452AperETItem", StringUtil.LTrimStr( (decimal)(A452AperETItem), 6, 0));
         A448AperEMonDsc = "";
         AssignAttri("", false, "A448AperEMonDsc", A448AperEMonDsc);
         A453AperETMovDsc = "";
         AssignAttri("", false, "A453AperETMovDsc", A453AperETMovDsc);
         Z449AperEntFec = DateTime.MinValue;
         Z444AperECheque = "";
         Z450AperESaldo = 0;
         Z445AperEImporte = 0;
         Z447AperEReponer = 0;
         Z454AperETope = 0;
         Z443AperEBanReg = "";
         Z451AperESts = "";
         Z452AperETItem = 0;
         Z371AperEMonCod = 0;
         Z370AperEForCod = 0;
         Z368AperEBanCod = 0;
         Z369AperECueBan = "";
         Z367AperETmov = 0;
      }

      protected void InitAll50167( )
      {
         A365EntCod = 0;
         AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         A366AperEntCod = "";
         AssignAttri("", false, "A366AperEntCod", A366AperEntCod);
         InitializeNonKey50167( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810255045", true, true);
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
         context.AddJavascriptSource("tsaperturaentrega.js", "?202281810255045", false, true);
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
         edtEntCod_Internalname = "ENTCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAperEntCod_Internalname = "APERENTCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtAperEntFec_Internalname = "APERENTFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAperEMonCod_Internalname = "APEREMONCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtAperEForCod_Internalname = "APEREFORCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtAperEBanCod_Internalname = "APEREBANCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtAperECueBan_Internalname = "APERECUEBAN";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtAperECheque_Internalname = "APERECHEQUE";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtAperESaldo_Internalname = "APERESALDO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtAperEImporte_Internalname = "APEREIMPORTE";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtAperEReponer_Internalname = "APEREREPONER";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtAperETope_Internalname = "APERETOPE";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtAperETmov_Internalname = "APERETMOV";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtAperEBanReg_Internalname = "APEREBANREG";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtAperESts_Internalname = "APERESTS";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtAperETItem_Internalname = "APERETITEM";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtAperEImpTotal_Internalname = "APEREIMPTOTAL";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtAperEMonDsc_Internalname = "APEREMONDSC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtAperETMovDsc_Internalname = "APERETMOVDSC";
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
         Form.Caption = "Apertura de Entrega a Rendir";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAperETMovDsc_Jsonclick = "";
         edtAperETMovDsc_Enabled = 0;
         edtAperEMonDsc_Jsonclick = "";
         edtAperEMonDsc_Enabled = 0;
         edtAperEImpTotal_Jsonclick = "";
         edtAperEImpTotal_Enabled = 0;
         edtAperETItem_Jsonclick = "";
         edtAperETItem_Enabled = 1;
         edtAperESts_Jsonclick = "";
         edtAperESts_Enabled = 1;
         edtAperEBanReg_Jsonclick = "";
         edtAperEBanReg_Enabled = 1;
         edtAperETmov_Jsonclick = "";
         edtAperETmov_Enabled = 1;
         edtAperETope_Jsonclick = "";
         edtAperETope_Enabled = 1;
         edtAperEReponer_Jsonclick = "";
         edtAperEReponer_Enabled = 1;
         edtAperEImporte_Jsonclick = "";
         edtAperEImporte_Enabled = 1;
         edtAperESaldo_Jsonclick = "";
         edtAperESaldo_Enabled = 1;
         edtAperECheque_Jsonclick = "";
         edtAperECheque_Enabled = 1;
         edtAperECueBan_Jsonclick = "";
         edtAperECueBan_Enabled = 1;
         edtAperEBanCod_Jsonclick = "";
         edtAperEBanCod_Enabled = 1;
         edtAperEForCod_Jsonclick = "";
         edtAperEForCod_Enabled = 1;
         edtAperEMonCod_Jsonclick = "";
         edtAperEMonCod_Enabled = 1;
         edtAperEntFec_Jsonclick = "";
         edtAperEntFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtAperEntCod_Jsonclick = "";
         edtAperEntCod_Enabled = 1;
         edtEntCod_Jsonclick = "";
         edtEntCod_Enabled = 1;
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
         /* Using cursor T005024 */
         pr_default.execute(22, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(22);
         GX_FocusControl = edtAperEntFec_Internalname;
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

      public void Valid_Entcod( )
      {
         /* Using cursor T005024 */
         pr_default.execute(22, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Aperentcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A449AperEntFec", context.localUtil.Format(A449AperEntFec, "99/99/99"));
         AssignAttri("", false, "A371AperEMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A371AperEMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A370AperEForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A370AperEForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A368AperEBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A368AperEBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A369AperECueBan", StringUtil.RTrim( A369AperECueBan));
         AssignAttri("", false, "A444AperECheque", StringUtil.RTrim( A444AperECheque));
         AssignAttri("", false, "A450AperESaldo", StringUtil.LTrim( StringUtil.NToC( A450AperESaldo, 15, 2, ".", "")));
         AssignAttri("", false, "A445AperEImporte", StringUtil.LTrim( StringUtil.NToC( A445AperEImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A447AperEReponer", StringUtil.LTrim( StringUtil.NToC( A447AperEReponer, 15, 2, ".", "")));
         AssignAttri("", false, "A454AperETope", StringUtil.LTrim( StringUtil.NToC( A454AperETope, 15, 2, ".", "")));
         AssignAttri("", false, "A367AperETmov", StringUtil.LTrim( StringUtil.NToC( (decimal)(A367AperETmov), 6, 0, ".", "")));
         AssignAttri("", false, "A443AperEBanReg", StringUtil.RTrim( A443AperEBanReg));
         AssignAttri("", false, "A451AperESts", StringUtil.RTrim( A451AperESts));
         AssignAttri("", false, "A452AperETItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A452AperETItem), 6, 0, ".", "")));
         AssignAttri("", false, "A448AperEMonDsc", StringUtil.RTrim( A448AperEMonDsc));
         AssignAttri("", false, "A446AperEImpTotal", StringUtil.LTrim( StringUtil.NToC( A446AperEImpTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A453AperETMovDsc", StringUtil.RTrim( A453AperETMovDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z366AperEntCod", StringUtil.RTrim( Z366AperEntCod));
         GxWebStd.gx_hidden_field( context, "Z449AperEntFec", context.localUtil.Format(Z449AperEntFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z371AperEMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z371AperEMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z370AperEForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z370AperEForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z368AperEBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z368AperEBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z369AperECueBan", StringUtil.RTrim( Z369AperECueBan));
         GxWebStd.gx_hidden_field( context, "Z444AperECheque", StringUtil.RTrim( Z444AperECheque));
         GxWebStd.gx_hidden_field( context, "Z450AperESaldo", StringUtil.LTrim( StringUtil.NToC( Z450AperESaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z445AperEImporte", StringUtil.LTrim( StringUtil.NToC( Z445AperEImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z447AperEReponer", StringUtil.LTrim( StringUtil.NToC( Z447AperEReponer, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z454AperETope", StringUtil.LTrim( StringUtil.NToC( Z454AperETope, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z367AperETmov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z367AperETmov), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z443AperEBanReg", StringUtil.RTrim( Z443AperEBanReg));
         GxWebStd.gx_hidden_field( context, "Z451AperESts", StringUtil.RTrim( Z451AperESts));
         GxWebStd.gx_hidden_field( context, "Z452AperETItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z452AperETItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z448AperEMonDsc", StringUtil.RTrim( Z448AperEMonDsc));
         GxWebStd.gx_hidden_field( context, "Z446AperEImpTotal", StringUtil.LTrim( StringUtil.NToC( Z446AperEImpTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z453AperETMovDsc", StringUtil.RTrim( Z453AperETMovDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Aperemoncod( )
      {
         /* Using cursor T005021 */
         pr_default.execute(19, new Object[] {A371AperEMonCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "APEREMONCOD");
            AnyError = 1;
            GX_FocusControl = edtAperEMonCod_Internalname;
         }
         A448AperEMonDsc = T005021_A448AperEMonDsc[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A448AperEMonDsc", StringUtil.RTrim( A448AperEMonDsc));
      }

      public void Valid_Apereforcod( )
      {
         /* Using cursor T005025 */
         pr_default.execute(23, new Object[] {A370AperEForCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "APEREFORCOD");
            AnyError = 1;
            GX_FocusControl = edtAperEForCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Aperecueban( )
      {
         n368AperEBanCod = false;
         n369AperECueBan = false;
         /* Using cursor T005026 */
         pr_default.execute(24, new Object[] {n368AperEBanCod, A368AperEBanCod, n369AperECueBan, A369AperECueBan});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A368AperEBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A369AperECueBan)) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "APERECUEBAN");
               AnyError = 1;
               GX_FocusControl = edtAperEBanCod_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Aperetmov( )
      {
         n367AperETmov = false;
         /* Using cursor T005022 */
         pr_default.execute(20, new Object[] {n367AperETmov, A367AperETmov});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A367AperETmov) ) )
            {
               GX_msglist.addItem("No existe 'Movimiento'.", "ForeignKeyNotFound", 1, "APERETMOV");
               AnyError = 1;
               GX_FocusControl = edtAperETmov_Internalname;
            }
         }
         A453AperETMovDsc = T005022_A453AperETMovDsc[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A453AperETMovDsc", StringUtil.RTrim( A453AperETMovDsc));
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
         setEventMetadata("VALID_ENTCOD","{handler:'Valid_Entcod',iparms:[{av:'A365EntCod',fld:'ENTCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ENTCOD",",oparms:[]}");
         setEventMetadata("VALID_APERENTCOD","{handler:'Valid_Aperentcod',iparms:[{av:'A365EntCod',fld:'ENTCOD',pic:'ZZZZZ9'},{av:'A366AperEntCod',fld:'APERENTCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_APERENTCOD",",oparms:[{av:'A449AperEntFec',fld:'APERENTFEC',pic:''},{av:'A371AperEMonCod',fld:'APEREMONCOD',pic:'ZZZZZ9'},{av:'A370AperEForCod',fld:'APEREFORCOD',pic:'ZZZZZ9'},{av:'A368AperEBanCod',fld:'APEREBANCOD',pic:'ZZZZZ9'},{av:'A369AperECueBan',fld:'APERECUEBAN',pic:''},{av:'A444AperECheque',fld:'APERECHEQUE',pic:''},{av:'A450AperESaldo',fld:'APERESALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A445AperEImporte',fld:'APEREIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A447AperEReponer',fld:'APEREREPONER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A454AperETope',fld:'APERETOPE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A367AperETmov',fld:'APERETMOV',pic:'ZZZZZ9'},{av:'A443AperEBanReg',fld:'APEREBANREG',pic:''},{av:'A451AperESts',fld:'APERESTS',pic:''},{av:'A452AperETItem',fld:'APERETITEM',pic:'ZZZZZ9'},{av:'A448AperEMonDsc',fld:'APEREMONDSC',pic:''},{av:'A446AperEImpTotal',fld:'APEREIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A453AperETMovDsc',fld:'APERETMOVDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z365EntCod'},{av:'Z366AperEntCod'},{av:'Z449AperEntFec'},{av:'Z371AperEMonCod'},{av:'Z370AperEForCod'},{av:'Z368AperEBanCod'},{av:'Z369AperECueBan'},{av:'Z444AperECheque'},{av:'Z450AperESaldo'},{av:'Z445AperEImporte'},{av:'Z447AperEReponer'},{av:'Z454AperETope'},{av:'Z367AperETmov'},{av:'Z443AperEBanReg'},{av:'Z451AperESts'},{av:'Z452AperETItem'},{av:'Z448AperEMonDsc'},{av:'Z446AperEImpTotal'},{av:'Z453AperETMovDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_APERENTFEC","{handler:'Valid_Aperentfec',iparms:[]");
         setEventMetadata("VALID_APERENTFEC",",oparms:[]}");
         setEventMetadata("VALID_APEREMONCOD","{handler:'Valid_Aperemoncod',iparms:[{av:'A371AperEMonCod',fld:'APEREMONCOD',pic:'ZZZZZ9'},{av:'A448AperEMonDsc',fld:'APEREMONDSC',pic:''}]");
         setEventMetadata("VALID_APEREMONCOD",",oparms:[{av:'A448AperEMonDsc',fld:'APEREMONDSC',pic:''}]}");
         setEventMetadata("VALID_APEREFORCOD","{handler:'Valid_Apereforcod',iparms:[{av:'A370AperEForCod',fld:'APEREFORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_APEREFORCOD",",oparms:[]}");
         setEventMetadata("VALID_APEREBANCOD","{handler:'Valid_Aperebancod',iparms:[]");
         setEventMetadata("VALID_APEREBANCOD",",oparms:[]}");
         setEventMetadata("VALID_APERECUEBAN","{handler:'Valid_Aperecueban',iparms:[{av:'A368AperEBanCod',fld:'APEREBANCOD',pic:'ZZZZZ9'},{av:'A369AperECueBan',fld:'APERECUEBAN',pic:''}]");
         setEventMetadata("VALID_APERECUEBAN",",oparms:[]}");
         setEventMetadata("VALID_APEREIMPORTE","{handler:'Valid_Apereimporte',iparms:[]");
         setEventMetadata("VALID_APEREIMPORTE",",oparms:[]}");
         setEventMetadata("VALID_APEREREPONER","{handler:'Valid_Aperereponer',iparms:[]");
         setEventMetadata("VALID_APEREREPONER",",oparms:[]}");
         setEventMetadata("VALID_APERETMOV","{handler:'Valid_Aperetmov',iparms:[{av:'A367AperETmov',fld:'APERETMOV',pic:'ZZZZZ9'},{av:'A453AperETMovDsc',fld:'APERETMOVDSC',pic:''}]");
         setEventMetadata("VALID_APERETMOV",",oparms:[{av:'A453AperETMovDsc',fld:'APERETMOVDSC',pic:''}]}");
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
         pr_default.close(22);
         pr_default.close(19);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z366AperEntCod = "";
         Z449AperEntFec = DateTime.MinValue;
         Z444AperECheque = "";
         Z443AperEBanReg = "";
         Z451AperESts = "";
         Z369AperECueBan = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A369AperECueBan = "";
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
         A366AperEntCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A449AperEntFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A444AperECheque = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A443AperEBanReg = "";
         lblTextblock15_Jsonclick = "";
         A451AperESts = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A448AperEMonDsc = "";
         lblTextblock19_Jsonclick = "";
         A453AperETMovDsc = "";
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
         Z448AperEMonDsc = "";
         Z453AperETMovDsc = "";
         T00509_A366AperEntCod = new string[] {""} ;
         T00509_A449AperEntFec = new DateTime[] {DateTime.MinValue} ;
         T00509_A444AperECheque = new string[] {""} ;
         T00509_A450AperESaldo = new decimal[1] ;
         T00509_A445AperEImporte = new decimal[1] ;
         T00509_A447AperEReponer = new decimal[1] ;
         T00509_A454AperETope = new decimal[1] ;
         T00509_A443AperEBanReg = new string[] {""} ;
         T00509_n443AperEBanReg = new bool[] {false} ;
         T00509_A451AperESts = new string[] {""} ;
         T00509_A452AperETItem = new int[1] ;
         T00509_A448AperEMonDsc = new string[] {""} ;
         T00509_A453AperETMovDsc = new string[] {""} ;
         T00509_A365EntCod = new int[1] ;
         T00509_A371AperEMonCod = new int[1] ;
         T00509_A370AperEForCod = new int[1] ;
         T00509_A368AperEBanCod = new int[1] ;
         T00509_n368AperEBanCod = new bool[] {false} ;
         T00509_A369AperECueBan = new string[] {""} ;
         T00509_n369AperECueBan = new bool[] {false} ;
         T00509_A367AperETmov = new int[1] ;
         T00509_n367AperETmov = new bool[] {false} ;
         T00504_A365EntCod = new int[1] ;
         T00505_A448AperEMonDsc = new string[] {""} ;
         T00506_A370AperEForCod = new int[1] ;
         T00507_A368AperEBanCod = new int[1] ;
         T00507_n368AperEBanCod = new bool[] {false} ;
         T00508_A453AperETMovDsc = new string[] {""} ;
         T005010_A365EntCod = new int[1] ;
         T005011_A448AperEMonDsc = new string[] {""} ;
         T005012_A370AperEForCod = new int[1] ;
         T005013_A368AperEBanCod = new int[1] ;
         T005013_n368AperEBanCod = new bool[] {false} ;
         T005014_A453AperETMovDsc = new string[] {""} ;
         T005015_A365EntCod = new int[1] ;
         T005015_A366AperEntCod = new string[] {""} ;
         T00503_A366AperEntCod = new string[] {""} ;
         T00503_A449AperEntFec = new DateTime[] {DateTime.MinValue} ;
         T00503_A444AperECheque = new string[] {""} ;
         T00503_A450AperESaldo = new decimal[1] ;
         T00503_A445AperEImporte = new decimal[1] ;
         T00503_A447AperEReponer = new decimal[1] ;
         T00503_A454AperETope = new decimal[1] ;
         T00503_A443AperEBanReg = new string[] {""} ;
         T00503_n443AperEBanReg = new bool[] {false} ;
         T00503_A451AperESts = new string[] {""} ;
         T00503_A452AperETItem = new int[1] ;
         T00503_A365EntCod = new int[1] ;
         T00503_A371AperEMonCod = new int[1] ;
         T00503_A370AperEForCod = new int[1] ;
         T00503_A368AperEBanCod = new int[1] ;
         T00503_n368AperEBanCod = new bool[] {false} ;
         T00503_A369AperECueBan = new string[] {""} ;
         T00503_n369AperECueBan = new bool[] {false} ;
         T00503_A367AperETmov = new int[1] ;
         T00503_n367AperETmov = new bool[] {false} ;
         sMode167 = "";
         T005016_A365EntCod = new int[1] ;
         T005016_A366AperEntCod = new string[] {""} ;
         T005017_A365EntCod = new int[1] ;
         T005017_A366AperEntCod = new string[] {""} ;
         T00502_A366AperEntCod = new string[] {""} ;
         T00502_A449AperEntFec = new DateTime[] {DateTime.MinValue} ;
         T00502_A444AperECheque = new string[] {""} ;
         T00502_A450AperESaldo = new decimal[1] ;
         T00502_A445AperEImporte = new decimal[1] ;
         T00502_A447AperEReponer = new decimal[1] ;
         T00502_A454AperETope = new decimal[1] ;
         T00502_A443AperEBanReg = new string[] {""} ;
         T00502_n443AperEBanReg = new bool[] {false} ;
         T00502_A451AperESts = new string[] {""} ;
         T00502_A452AperETItem = new int[1] ;
         T00502_A365EntCod = new int[1] ;
         T00502_A371AperEMonCod = new int[1] ;
         T00502_A370AperEForCod = new int[1] ;
         T00502_A368AperEBanCod = new int[1] ;
         T00502_n368AperEBanCod = new bool[] {false} ;
         T00502_A369AperECueBan = new string[] {""} ;
         T00502_n369AperECueBan = new bool[] {false} ;
         T00502_A367AperETmov = new int[1] ;
         T00502_n367AperETmov = new bool[] {false} ;
         T005021_A448AperEMonDsc = new string[] {""} ;
         T005022_A453AperETMovDsc = new string[] {""} ;
         T005023_A365EntCod = new int[1] ;
         T005023_A366AperEntCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T005024_A365EntCod = new int[1] ;
         ZZ366AperEntCod = "";
         ZZ449AperEntFec = DateTime.MinValue;
         ZZ369AperECueBan = "";
         ZZ444AperECheque = "";
         ZZ443AperEBanReg = "";
         ZZ451AperESts = "";
         ZZ448AperEMonDsc = "";
         ZZ453AperETMovDsc = "";
         T005025_A370AperEForCod = new int[1] ;
         T005026_A368AperEBanCod = new int[1] ;
         T005026_n368AperEBanCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsaperturaentrega__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsaperturaentrega__default(),
            new Object[][] {
                new Object[] {
               T00502_A366AperEntCod, T00502_A449AperEntFec, T00502_A444AperECheque, T00502_A450AperESaldo, T00502_A445AperEImporte, T00502_A447AperEReponer, T00502_A454AperETope, T00502_A443AperEBanReg, T00502_n443AperEBanReg, T00502_A451AperESts,
               T00502_A452AperETItem, T00502_A365EntCod, T00502_A371AperEMonCod, T00502_A370AperEForCod, T00502_A368AperEBanCod, T00502_n368AperEBanCod, T00502_A369AperECueBan, T00502_n369AperECueBan, T00502_A367AperETmov, T00502_n367AperETmov
               }
               , new Object[] {
               T00503_A366AperEntCod, T00503_A449AperEntFec, T00503_A444AperECheque, T00503_A450AperESaldo, T00503_A445AperEImporte, T00503_A447AperEReponer, T00503_A454AperETope, T00503_A443AperEBanReg, T00503_n443AperEBanReg, T00503_A451AperESts,
               T00503_A452AperETItem, T00503_A365EntCod, T00503_A371AperEMonCod, T00503_A370AperEForCod, T00503_A368AperEBanCod, T00503_n368AperEBanCod, T00503_A369AperECueBan, T00503_n369AperECueBan, T00503_A367AperETmov, T00503_n367AperETmov
               }
               , new Object[] {
               T00504_A365EntCod
               }
               , new Object[] {
               T00505_A448AperEMonDsc
               }
               , new Object[] {
               T00506_A370AperEForCod
               }
               , new Object[] {
               T00507_A368AperEBanCod
               }
               , new Object[] {
               T00508_A453AperETMovDsc
               }
               , new Object[] {
               T00509_A366AperEntCod, T00509_A449AperEntFec, T00509_A444AperECheque, T00509_A450AperESaldo, T00509_A445AperEImporte, T00509_A447AperEReponer, T00509_A454AperETope, T00509_A443AperEBanReg, T00509_n443AperEBanReg, T00509_A451AperESts,
               T00509_A452AperETItem, T00509_A448AperEMonDsc, T00509_A453AperETMovDsc, T00509_A365EntCod, T00509_A371AperEMonCod, T00509_A370AperEForCod, T00509_A368AperEBanCod, T00509_n368AperEBanCod, T00509_A369AperECueBan, T00509_n369AperECueBan,
               T00509_A367AperETmov, T00509_n367AperETmov
               }
               , new Object[] {
               T005010_A365EntCod
               }
               , new Object[] {
               T005011_A448AperEMonDsc
               }
               , new Object[] {
               T005012_A370AperEForCod
               }
               , new Object[] {
               T005013_A368AperEBanCod
               }
               , new Object[] {
               T005014_A453AperETMovDsc
               }
               , new Object[] {
               T005015_A365EntCod, T005015_A366AperEntCod
               }
               , new Object[] {
               T005016_A365EntCod, T005016_A366AperEntCod
               }
               , new Object[] {
               T005017_A365EntCod, T005017_A366AperEntCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005021_A448AperEMonDsc
               }
               , new Object[] {
               T005022_A453AperETMovDsc
               }
               , new Object[] {
               T005023_A365EntCod, T005023_A366AperEntCod
               }
               , new Object[] {
               T005024_A365EntCod
               }
               , new Object[] {
               T005025_A370AperEForCod
               }
               , new Object[] {
               T005026_A368AperEBanCod
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
      private short RcdFound167 ;
      private short nIsDirty_167 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z365EntCod ;
      private int Z452AperETItem ;
      private int Z371AperEMonCod ;
      private int Z370AperEForCod ;
      private int Z368AperEBanCod ;
      private int Z367AperETmov ;
      private int A365EntCod ;
      private int A371AperEMonCod ;
      private int A370AperEForCod ;
      private int A368AperEBanCod ;
      private int A367AperETmov ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEntCod_Enabled ;
      private int edtAperEntCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtAperEntFec_Enabled ;
      private int edtAperEMonCod_Enabled ;
      private int edtAperEForCod_Enabled ;
      private int edtAperEBanCod_Enabled ;
      private int edtAperECueBan_Enabled ;
      private int edtAperECheque_Enabled ;
      private int edtAperESaldo_Enabled ;
      private int edtAperEImporte_Enabled ;
      private int edtAperEReponer_Enabled ;
      private int edtAperETope_Enabled ;
      private int edtAperETmov_Enabled ;
      private int edtAperEBanReg_Enabled ;
      private int edtAperESts_Enabled ;
      private int A452AperETItem ;
      private int edtAperETItem_Enabled ;
      private int edtAperEImpTotal_Enabled ;
      private int edtAperEMonDsc_Enabled ;
      private int edtAperETMovDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ365EntCod ;
      private int ZZ371AperEMonCod ;
      private int ZZ370AperEForCod ;
      private int ZZ368AperEBanCod ;
      private int ZZ367AperETmov ;
      private int ZZ452AperETItem ;
      private decimal Z450AperESaldo ;
      private decimal Z445AperEImporte ;
      private decimal Z447AperEReponer ;
      private decimal Z454AperETope ;
      private decimal A450AperESaldo ;
      private decimal A445AperEImporte ;
      private decimal A447AperEReponer ;
      private decimal A454AperETope ;
      private decimal A446AperEImpTotal ;
      private decimal Z446AperEImpTotal ;
      private decimal ZZ450AperESaldo ;
      private decimal ZZ445AperEImporte ;
      private decimal ZZ447AperEReponer ;
      private decimal ZZ454AperETope ;
      private decimal ZZ446AperEImpTotal ;
      private string sPrefix ;
      private string Z366AperEntCod ;
      private string Z444AperECheque ;
      private string Z443AperEBanReg ;
      private string Z451AperESts ;
      private string Z369AperECueBan ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A369AperECueBan ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEntCod_Internalname ;
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
      private string edtEntCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAperEntCod_Internalname ;
      private string A366AperEntCod ;
      private string edtAperEntCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtAperEntFec_Internalname ;
      private string edtAperEntFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAperEMonCod_Internalname ;
      private string edtAperEMonCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtAperEForCod_Internalname ;
      private string edtAperEForCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtAperEBanCod_Internalname ;
      private string edtAperEBanCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtAperECueBan_Internalname ;
      private string edtAperECueBan_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtAperECheque_Internalname ;
      private string A444AperECheque ;
      private string edtAperECheque_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtAperESaldo_Internalname ;
      private string edtAperESaldo_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtAperEImporte_Internalname ;
      private string edtAperEImporte_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtAperEReponer_Internalname ;
      private string edtAperEReponer_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtAperETope_Internalname ;
      private string edtAperETope_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtAperETmov_Internalname ;
      private string edtAperETmov_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtAperEBanReg_Internalname ;
      private string A443AperEBanReg ;
      private string edtAperEBanReg_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtAperESts_Internalname ;
      private string A451AperESts ;
      private string edtAperESts_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtAperETItem_Internalname ;
      private string edtAperETItem_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtAperEImpTotal_Internalname ;
      private string edtAperEImpTotal_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtAperEMonDsc_Internalname ;
      private string A448AperEMonDsc ;
      private string edtAperEMonDsc_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtAperETMovDsc_Internalname ;
      private string A453AperETMovDsc ;
      private string edtAperETMovDsc_Jsonclick ;
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
      private string Z448AperEMonDsc ;
      private string Z453AperETMovDsc ;
      private string sMode167 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ366AperEntCod ;
      private string ZZ369AperECueBan ;
      private string ZZ444AperECheque ;
      private string ZZ443AperEBanReg ;
      private string ZZ451AperESts ;
      private string ZZ448AperEMonDsc ;
      private string ZZ453AperETMovDsc ;
      private DateTime Z449AperEntFec ;
      private DateTime A449AperEntFec ;
      private DateTime ZZ449AperEntFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n368AperEBanCod ;
      private bool n369AperECueBan ;
      private bool n367AperETmov ;
      private bool wbErr ;
      private bool n443AperEBanReg ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00509_A366AperEntCod ;
      private DateTime[] T00509_A449AperEntFec ;
      private string[] T00509_A444AperECheque ;
      private decimal[] T00509_A450AperESaldo ;
      private decimal[] T00509_A445AperEImporte ;
      private decimal[] T00509_A447AperEReponer ;
      private decimal[] T00509_A454AperETope ;
      private string[] T00509_A443AperEBanReg ;
      private bool[] T00509_n443AperEBanReg ;
      private string[] T00509_A451AperESts ;
      private int[] T00509_A452AperETItem ;
      private string[] T00509_A448AperEMonDsc ;
      private string[] T00509_A453AperETMovDsc ;
      private int[] T00509_A365EntCod ;
      private int[] T00509_A371AperEMonCod ;
      private int[] T00509_A370AperEForCod ;
      private int[] T00509_A368AperEBanCod ;
      private bool[] T00509_n368AperEBanCod ;
      private string[] T00509_A369AperECueBan ;
      private bool[] T00509_n369AperECueBan ;
      private int[] T00509_A367AperETmov ;
      private bool[] T00509_n367AperETmov ;
      private int[] T00504_A365EntCod ;
      private string[] T00505_A448AperEMonDsc ;
      private int[] T00506_A370AperEForCod ;
      private int[] T00507_A368AperEBanCod ;
      private bool[] T00507_n368AperEBanCod ;
      private string[] T00508_A453AperETMovDsc ;
      private int[] T005010_A365EntCod ;
      private string[] T005011_A448AperEMonDsc ;
      private int[] T005012_A370AperEForCod ;
      private int[] T005013_A368AperEBanCod ;
      private bool[] T005013_n368AperEBanCod ;
      private string[] T005014_A453AperETMovDsc ;
      private int[] T005015_A365EntCod ;
      private string[] T005015_A366AperEntCod ;
      private string[] T00503_A366AperEntCod ;
      private DateTime[] T00503_A449AperEntFec ;
      private string[] T00503_A444AperECheque ;
      private decimal[] T00503_A450AperESaldo ;
      private decimal[] T00503_A445AperEImporte ;
      private decimal[] T00503_A447AperEReponer ;
      private decimal[] T00503_A454AperETope ;
      private string[] T00503_A443AperEBanReg ;
      private bool[] T00503_n443AperEBanReg ;
      private string[] T00503_A451AperESts ;
      private int[] T00503_A452AperETItem ;
      private int[] T00503_A365EntCod ;
      private int[] T00503_A371AperEMonCod ;
      private int[] T00503_A370AperEForCod ;
      private int[] T00503_A368AperEBanCod ;
      private bool[] T00503_n368AperEBanCod ;
      private string[] T00503_A369AperECueBan ;
      private bool[] T00503_n369AperECueBan ;
      private int[] T00503_A367AperETmov ;
      private bool[] T00503_n367AperETmov ;
      private int[] T005016_A365EntCod ;
      private string[] T005016_A366AperEntCod ;
      private int[] T005017_A365EntCod ;
      private string[] T005017_A366AperEntCod ;
      private string[] T00502_A366AperEntCod ;
      private DateTime[] T00502_A449AperEntFec ;
      private string[] T00502_A444AperECheque ;
      private decimal[] T00502_A450AperESaldo ;
      private decimal[] T00502_A445AperEImporte ;
      private decimal[] T00502_A447AperEReponer ;
      private decimal[] T00502_A454AperETope ;
      private string[] T00502_A443AperEBanReg ;
      private bool[] T00502_n443AperEBanReg ;
      private string[] T00502_A451AperESts ;
      private int[] T00502_A452AperETItem ;
      private int[] T00502_A365EntCod ;
      private int[] T00502_A371AperEMonCod ;
      private int[] T00502_A370AperEForCod ;
      private int[] T00502_A368AperEBanCod ;
      private bool[] T00502_n368AperEBanCod ;
      private string[] T00502_A369AperECueBan ;
      private bool[] T00502_n369AperECueBan ;
      private int[] T00502_A367AperETmov ;
      private bool[] T00502_n367AperETmov ;
      private string[] T005021_A448AperEMonDsc ;
      private string[] T005022_A453AperETMovDsc ;
      private int[] T005023_A365EntCod ;
      private string[] T005023_A366AperEntCod ;
      private int[] T005024_A365EntCod ;
      private int[] T005025_A370AperEForCod ;
      private int[] T005026_A368AperEBanCod ;
      private bool[] T005026_n368AperEBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsaperturaentrega__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsaperturaentrega__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00509;
        prmT00509 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT00504;
        prmT00504 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT00505;
        prmT00505 = new Object[] {
        new ParDef("@AperEMonCod",GXType.Int32,6,0)
        };
        Object[] prmT00506;
        prmT00506 = new Object[] {
        new ParDef("@AperEForCod",GXType.Int32,6,0)
        };
        Object[] prmT00507;
        prmT00507 = new Object[] {
        new ParDef("@AperEBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperECueBan",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT00508;
        prmT00508 = new Object[] {
        new ParDef("@AperETmov",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005010;
        prmT005010 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005011;
        prmT005011 = new Object[] {
        new ParDef("@AperEMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005012;
        prmT005012 = new Object[] {
        new ParDef("@AperEForCod",GXType.Int32,6,0)
        };
        Object[] prmT005013;
        prmT005013 = new Object[] {
        new ParDef("@AperEBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperECueBan",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005014;
        prmT005014 = new Object[] {
        new ParDef("@AperETmov",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005015;
        prmT005015 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT00503;
        prmT00503 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT005016;
        prmT005016 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT005017;
        prmT005017 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT00502;
        prmT00502 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT005018;
        prmT005018 = new Object[] {
        new ParDef("@AperEntCod",GXType.NChar,10,0) ,
        new ParDef("@AperEntFec",GXType.Date,8,0) ,
        new ParDef("@AperECheque",GXType.NChar,20,0) ,
        new ParDef("@AperESaldo",GXType.Decimal,15,2) ,
        new ParDef("@AperEImporte",GXType.Decimal,15,2) ,
        new ParDef("@AperEReponer",GXType.Decimal,15,2) ,
        new ParDef("@AperETope",GXType.Decimal,15,2) ,
        new ParDef("@AperEBanReg",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@AperESts",GXType.NChar,1,0) ,
        new ParDef("@AperETItem",GXType.Int32,6,0) ,
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEMonCod",GXType.Int32,6,0) ,
        new ParDef("@AperEForCod",GXType.Int32,6,0) ,
        new ParDef("@AperEBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperECueBan",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@AperETmov",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005019;
        prmT005019 = new Object[] {
        new ParDef("@AperEntFec",GXType.Date,8,0) ,
        new ParDef("@AperECheque",GXType.NChar,20,0) ,
        new ParDef("@AperESaldo",GXType.Decimal,15,2) ,
        new ParDef("@AperEImporte",GXType.Decimal,15,2) ,
        new ParDef("@AperEReponer",GXType.Decimal,15,2) ,
        new ParDef("@AperETope",GXType.Decimal,15,2) ,
        new ParDef("@AperEBanReg",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@AperESts",GXType.NChar,1,0) ,
        new ParDef("@AperETItem",GXType.Int32,6,0) ,
        new ParDef("@AperEMonCod",GXType.Int32,6,0) ,
        new ParDef("@AperEForCod",GXType.Int32,6,0) ,
        new ParDef("@AperEBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperECueBan",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@AperETmov",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT005020;
        prmT005020 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@AperEntCod",GXType.NChar,10,0)
        };
        Object[] prmT005023;
        prmT005023 = new Object[] {
        };
        Object[] prmT005024;
        prmT005024 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005021;
        prmT005021 = new Object[] {
        new ParDef("@AperEMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005025;
        prmT005025 = new Object[] {
        new ParDef("@AperEForCod",GXType.Int32,6,0)
        };
        Object[] prmT005026;
        prmT005026 = new Object[] {
        new ParDef("@AperEBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperECueBan",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005022;
        prmT005022 = new Object[] {
        new ParDef("@AperETmov",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00502", "SELECT [AperEntCod], [AperEntFec], [AperECheque], [AperESaldo], [AperEImporte], [AperEReponer], [AperETope], [AperEBanReg], [AperESts], [AperETItem], [EntCod], [AperEMonCod] AS AperEMonCod, [AperEForCod] AS AperEForCod, [AperEBanCod] AS AperEBanCod, [AperECueBan] AS AperECueBan, [AperETmov] AS AperETmov FROM [TSAPERTURAENTREGA] WITH (UPDLOCK) WHERE [EntCod] = @EntCod AND [AperEntCod] = @AperEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00502,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00503", "SELECT [AperEntCod], [AperEntFec], [AperECheque], [AperESaldo], [AperEImporte], [AperEReponer], [AperETope], [AperEBanReg], [AperESts], [AperETItem], [EntCod], [AperEMonCod] AS AperEMonCod, [AperEForCod] AS AperEForCod, [AperEBanCod] AS AperEBanCod, [AperECueBan] AS AperECueBan, [AperETmov] AS AperETmov FROM [TSAPERTURAENTREGA] WHERE [EntCod] = @EntCod AND [AperEntCod] = @AperEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00503,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00504", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00504,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00505", "SELECT [MonDsc] AS AperEMonDsc FROM [CMONEDAS] WHERE [MonCod] = @AperEMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00505,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00506", "SELECT [ForCod] AS AperEForCod FROM [CFORMAPAGO] WHERE [ForCod] = @AperEForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00506,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00507", "SELECT [BanCod] AS AperEBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @AperEBanCod AND [CBCod] = @AperECueBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT00507,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00508", "SELECT [ConBDsc] AS AperETMovDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AperETmov ",true, GxErrorMask.GX_NOMASK, false, this,prmT00508,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00509", "SELECT TM1.[AperEntCod], TM1.[AperEntFec], TM1.[AperECheque], TM1.[AperESaldo], TM1.[AperEImporte], TM1.[AperEReponer], TM1.[AperETope], TM1.[AperEBanReg], TM1.[AperESts], TM1.[AperETItem], T2.[MonDsc] AS AperEMonDsc, T3.[ConBDsc] AS AperETMovDsc, TM1.[EntCod], TM1.[AperEMonCod] AS AperEMonCod, TM1.[AperEForCod] AS AperEForCod, TM1.[AperEBanCod] AS AperEBanCod, TM1.[AperECueBan] AS AperECueBan, TM1.[AperETmov] AS AperETmov FROM (([TSAPERTURAENTREGA] TM1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = TM1.[AperEMonCod]) LEFT JOIN [TSCONCEPTOBANCOS] T3 ON T3.[ConBCod] = TM1.[AperETmov]) WHERE TM1.[EntCod] = @EntCod and TM1.[AperEntCod] = @AperEntCod ORDER BY TM1.[EntCod], TM1.[AperEntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00509,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005010", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005010,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005011", "SELECT [MonDsc] AS AperEMonDsc FROM [CMONEDAS] WHERE [MonCod] = @AperEMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005011,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005012", "SELECT [ForCod] AS AperEForCod FROM [CFORMAPAGO] WHERE [ForCod] = @AperEForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005013", "SELECT [BanCod] AS AperEBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @AperEBanCod AND [CBCod] = @AperECueBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT005013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005014", "SELECT [ConBDsc] AS AperETMovDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AperETmov ",true, GxErrorMask.GX_NOMASK, false, this,prmT005014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005015", "SELECT [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [EntCod] = @EntCod AND [AperEntCod] = @AperEntCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005016", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE ( [EntCod] > @EntCod or [EntCod] = @EntCod and [AperEntCod] > @AperEntCod) ORDER BY [EntCod], [AperEntCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005017", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE ( [EntCod] < @EntCod or [EntCod] = @EntCod and [AperEntCod] < @AperEntCod) ORDER BY [EntCod] DESC, [AperEntCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005018", "INSERT INTO [TSAPERTURAENTREGA]([AperEntCod], [AperEntFec], [AperECheque], [AperESaldo], [AperEImporte], [AperEReponer], [AperETope], [AperEBanReg], [AperESts], [AperETItem], [EntCod], [AperEMonCod], [AperEForCod], [AperEBanCod], [AperECueBan], [AperETmov]) VALUES(@AperEntCod, @AperEntFec, @AperECheque, @AperESaldo, @AperEImporte, @AperEReponer, @AperETope, @AperEBanReg, @AperESts, @AperETItem, @EntCod, @AperEMonCod, @AperEForCod, @AperEBanCod, @AperECueBan, @AperETmov)", GxErrorMask.GX_NOMASK,prmT005018)
           ,new CursorDef("T005019", "UPDATE [TSAPERTURAENTREGA] SET [AperEntFec]=@AperEntFec, [AperECheque]=@AperECheque, [AperESaldo]=@AperESaldo, [AperEImporte]=@AperEImporte, [AperEReponer]=@AperEReponer, [AperETope]=@AperETope, [AperEBanReg]=@AperEBanReg, [AperESts]=@AperESts, [AperETItem]=@AperETItem, [AperEMonCod]=@AperEMonCod, [AperEForCod]=@AperEForCod, [AperEBanCod]=@AperEBanCod, [AperECueBan]=@AperECueBan, [AperETmov]=@AperETmov  WHERE [EntCod] = @EntCod AND [AperEntCod] = @AperEntCod", GxErrorMask.GX_NOMASK,prmT005019)
           ,new CursorDef("T005020", "DELETE FROM [TSAPERTURAENTREGA]  WHERE [EntCod] = @EntCod AND [AperEntCod] = @AperEntCod", GxErrorMask.GX_NOMASK,prmT005020)
           ,new CursorDef("T005021", "SELECT [MonDsc] AS AperEMonDsc FROM [CMONEDAS] WHERE [MonCod] = @AperEMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005021,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005022", "SELECT [ConBDsc] AS AperETMovDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AperETmov ",true, GxErrorMask.GX_NOMASK, false, this,prmT005022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005023", "SELECT [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] ORDER BY [EntCod], [AperEntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005023,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005024", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005025", "SELECT [ForCod] AS AperEForCod FROM [CFORMAPAGO] WHERE [ForCod] = @AperEForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005026", "SELECT [BanCod] AS AperEBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @AperEBanCod AND [CBCod] = @AperECueBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT005026,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 1);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getString(15, 20);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((int[]) buf[18])[0] = rslt.getInt(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 1);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getString(15, 20);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((int[]) buf[18])[0] = rslt.getInt(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 1);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 100);
              ((string[]) buf[12])[0] = rslt.getString(12, 100);
              ((int[]) buf[13])[0] = rslt.getInt(13);
              ((int[]) buf[14])[0] = rslt.getInt(14);
              ((int[]) buf[15])[0] = rslt.getInt(15);
              ((int[]) buf[16])[0] = rslt.getInt(16);
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 20);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((int[]) buf[20])[0] = rslt.getInt(18);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
