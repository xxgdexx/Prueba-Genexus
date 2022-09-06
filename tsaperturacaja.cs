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
   public class tsaperturacaja : GXDataArea
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
            A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A358CajCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A364AperMonCod = (int)(NumberUtil.Val( GetPar( "AperMonCod"), "."));
            AssignAttri("", false, "A364AperMonCod", StringUtil.LTrimStr( (decimal)(A364AperMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A364AperMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A363AperForCod = (int)(NumberUtil.Val( GetPar( "AperForCod"), "."));
            AssignAttri("", false, "A363AperForCod", StringUtil.LTrimStr( (decimal)(A363AperForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A363AperForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A361AperBanCod = (int)(NumberUtil.Val( GetPar( "AperBanCod"), "."));
            n361AperBanCod = false;
            AssignAttri("", false, "A361AperBanCod", StringUtil.LTrimStr( (decimal)(A361AperBanCod), 6, 0));
            A362AperCueBan = GetPar( "AperCueBan");
            n362AperCueBan = false;
            AssignAttri("", false, "A362AperCueBan", A362AperCueBan);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A361AperBanCod, A362AperCueBan) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A360AperTmov = (int)(NumberUtil.Val( GetPar( "AperTmov"), "."));
            n360AperTmov = false;
            AssignAttri("", false, "A360AperTmov", StringUtil.LTrimStr( (decimal)(A360AperTmov), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A360AperTmov) ;
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
            Form.Meta.addItem("description", "Apertura de Caja Chica", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsaperturacaja( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsaperturacaja( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSAPERTURACAJA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Caja Chica", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A358CajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Caja Chica", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperCajCod_Internalname, StringUtil.RTrim( A359AperCajCod), StringUtil.RTrim( context.localUtil.Format( A359AperCajCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperCajCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha Apertura", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAperCajFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAperCajFec_Internalname, context.localUtil.Format(A441AperCajFec, "99/99/99"), context.localUtil.Format( A441AperCajFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperCajFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperCajFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         GxWebStd.gx_bitmap( context, edtAperCajFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAperCajFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Moneda", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A364AperMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A364AperMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A364AperMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo forma pago", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A363AperForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A363AperForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A363AperForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Banco", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A361AperBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A361AperBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A361AperBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Cuenta", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperCueBan_Internalname, StringUtil.RTrim( A362AperCueBan), StringUtil.RTrim( context.localUtil.Format( A362AperCueBan, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperCueBan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperCueBan_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "N° Cheque", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperCheque_Internalname, StringUtil.RTrim( A442AperCheque), StringUtil.RTrim( context.localUtil.Format( A442AperCheque, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperCheque_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperCheque_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Importe Mov.", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A455AperImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperImporte_Enabled!=0) ? context.localUtil.Format( A455AperImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A455AperImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Importe Tope", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperTope_Internalname, StringUtil.LTrim( StringUtil.NToC( A473AperTope, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperTope_Enabled!=0) ? context.localUtil.Format( A473AperTope, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A473AperTope, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperTope_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperTope_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Movimiento Bancos", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperTmov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A360AperTmov), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperTmov_Enabled!=0) ? context.localUtil.Format( (decimal)(A360AperTmov), "ZZZZZ9") : context.localUtil.Format( (decimal)(A360AperTmov), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperTmov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperTmov_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "N° Registro", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperBanReg_Internalname, StringUtil.RTrim( A440AperBanReg), StringUtil.RTrim( context.localUtil.Format( A440AperBanReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperBanReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperBanReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Situacion", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperSts_Internalname, StringUtil.RTrim( A470AperSts), StringUtil.RTrim( context.localUtil.Format( A470AperSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Saldo Anterior", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A457AperSaldo, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperSaldo_Enabled!=0) ? context.localUtil.Format( A457AperSaldo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A457AperSaldo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperSaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperSaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Reposiciones", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperReponer_Internalname, StringUtil.LTrim( StringUtil.NToC( A467AperReponer, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperReponer_Enabled!=0) ? context.localUtil.Format( A467AperReponer, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A467AperReponer, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperReponer_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperReponer_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Total Item", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAperTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A471AperTItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtAperTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A471AperTItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A471AperTItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperTItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Movimiento Banco", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAperTMovDsc_Internalname, StringUtil.RTrim( A472AperTMovDsc), StringUtil.RTrim( context.localUtil.Format( A472AperTMovDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperTMovDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperTMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Importe Total", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAperImpTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A456AperImpTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtAperImpTotal_Enabled!=0) ? context.localUtil.Format( A456AperImpTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A456AperImpTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperImpTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperImpTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Moneda", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSAPERTURACAJA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAperMonDsc_Internalname, StringUtil.RTrim( A458AperMonDsc), StringUtil.RTrim( context.localUtil.Format( A458AperMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAperMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAperMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSAPERTURACAJA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSAPERTURACAJA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSAPERTURACAJA.htm");
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
            Z358CajCod = (int)(context.localUtil.CToN( cgiGet( "Z358CajCod"), ".", ","));
            Z359AperCajCod = cgiGet( "Z359AperCajCod");
            Z441AperCajFec = context.localUtil.CToD( cgiGet( "Z441AperCajFec"), 0);
            Z442AperCheque = cgiGet( "Z442AperCheque");
            Z455AperImporte = context.localUtil.CToN( cgiGet( "Z455AperImporte"), ".", ",");
            Z473AperTope = context.localUtil.CToN( cgiGet( "Z473AperTope"), ".", ",");
            Z440AperBanReg = cgiGet( "Z440AperBanReg");
            n440AperBanReg = (String.IsNullOrEmpty(StringUtil.RTrim( A440AperBanReg)) ? true : false);
            Z470AperSts = cgiGet( "Z470AperSts");
            Z457AperSaldo = context.localUtil.CToN( cgiGet( "Z457AperSaldo"), ".", ",");
            Z467AperReponer = context.localUtil.CToN( cgiGet( "Z467AperReponer"), ".", ",");
            Z471AperTItem = (int)(context.localUtil.CToN( cgiGet( "Z471AperTItem"), ".", ","));
            Z364AperMonCod = (int)(context.localUtil.CToN( cgiGet( "Z364AperMonCod"), ".", ","));
            Z363AperForCod = (int)(context.localUtil.CToN( cgiGet( "Z363AperForCod"), ".", ","));
            Z361AperBanCod = (int)(context.localUtil.CToN( cgiGet( "Z361AperBanCod"), ".", ","));
            n361AperBanCod = ((0==A361AperBanCod) ? true : false);
            Z362AperCueBan = cgiGet( "Z362AperCueBan");
            n362AperCueBan = (String.IsNullOrEmpty(StringUtil.RTrim( A362AperCueBan)) ? true : false);
            Z360AperTmov = (int)(context.localUtil.CToN( cgiGet( "Z360AperTmov"), ".", ","));
            n360AperTmov = ((0==A360AperTmov) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A358CajCod = 0;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            else
            {
               A358CajCod = (int)(context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            A359AperCajCod = cgiGet( edtAperCajCod_Internalname);
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            if ( context.localUtil.VCDate( cgiGet( edtAperCajFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Apertura"}), 1, "APERCAJFEC");
               AnyError = 1;
               GX_FocusControl = edtAperCajFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A441AperCajFec = DateTime.MinValue;
               AssignAttri("", false, "A441AperCajFec", context.localUtil.Format(A441AperCajFec, "99/99/99"));
            }
            else
            {
               A441AperCajFec = context.localUtil.CToD( cgiGet( edtAperCajFec_Internalname), 2);
               AssignAttri("", false, "A441AperCajFec", context.localUtil.Format(A441AperCajFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERMONCOD");
               AnyError = 1;
               GX_FocusControl = edtAperMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A364AperMonCod = 0;
               AssignAttri("", false, "A364AperMonCod", StringUtil.LTrimStr( (decimal)(A364AperMonCod), 6, 0));
            }
            else
            {
               A364AperMonCod = (int)(context.localUtil.CToN( cgiGet( edtAperMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A364AperMonCod", StringUtil.LTrimStr( (decimal)(A364AperMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERFORCOD");
               AnyError = 1;
               GX_FocusControl = edtAperForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A363AperForCod = 0;
               AssignAttri("", false, "A363AperForCod", StringUtil.LTrimStr( (decimal)(A363AperForCod), 6, 0));
            }
            else
            {
               A363AperForCod = (int)(context.localUtil.CToN( cgiGet( edtAperForCod_Internalname), ".", ","));
               AssignAttri("", false, "A363AperForCod", StringUtil.LTrimStr( (decimal)(A363AperForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERBANCOD");
               AnyError = 1;
               GX_FocusControl = edtAperBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A361AperBanCod = 0;
               n361AperBanCod = false;
               AssignAttri("", false, "A361AperBanCod", StringUtil.LTrimStr( (decimal)(A361AperBanCod), 6, 0));
            }
            else
            {
               A361AperBanCod = (int)(context.localUtil.CToN( cgiGet( edtAperBanCod_Internalname), ".", ","));
               n361AperBanCod = false;
               AssignAttri("", false, "A361AperBanCod", StringUtil.LTrimStr( (decimal)(A361AperBanCod), 6, 0));
            }
            n361AperBanCod = ((0==A361AperBanCod) ? true : false);
            A362AperCueBan = cgiGet( edtAperCueBan_Internalname);
            n362AperCueBan = false;
            AssignAttri("", false, "A362AperCueBan", A362AperCueBan);
            n362AperCueBan = (String.IsNullOrEmpty(StringUtil.RTrim( A362AperCueBan)) ? true : false);
            A442AperCheque = cgiGet( edtAperCheque_Internalname);
            AssignAttri("", false, "A442AperCheque", A442AperCheque);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtAperImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A455AperImporte = 0;
               AssignAttri("", false, "A455AperImporte", StringUtil.LTrimStr( A455AperImporte, 15, 2));
            }
            else
            {
               A455AperImporte = context.localUtil.CToN( cgiGet( edtAperImporte_Internalname), ".", ",");
               AssignAttri("", false, "A455AperImporte", StringUtil.LTrimStr( A455AperImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperTope_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperTope_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERTOPE");
               AnyError = 1;
               GX_FocusControl = edtAperTope_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A473AperTope = 0;
               AssignAttri("", false, "A473AperTope", StringUtil.LTrimStr( A473AperTope, 15, 2));
            }
            else
            {
               A473AperTope = context.localUtil.CToN( cgiGet( edtAperTope_Internalname), ".", ",");
               AssignAttri("", false, "A473AperTope", StringUtil.LTrimStr( A473AperTope, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperTmov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperTmov_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERTMOV");
               AnyError = 1;
               GX_FocusControl = edtAperTmov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A360AperTmov = 0;
               n360AperTmov = false;
               AssignAttri("", false, "A360AperTmov", StringUtil.LTrimStr( (decimal)(A360AperTmov), 6, 0));
            }
            else
            {
               A360AperTmov = (int)(context.localUtil.CToN( cgiGet( edtAperTmov_Internalname), ".", ","));
               n360AperTmov = false;
               AssignAttri("", false, "A360AperTmov", StringUtil.LTrimStr( (decimal)(A360AperTmov), 6, 0));
            }
            n360AperTmov = ((0==A360AperTmov) ? true : false);
            A440AperBanReg = cgiGet( edtAperBanReg_Internalname);
            n440AperBanReg = false;
            AssignAttri("", false, "A440AperBanReg", A440AperBanReg);
            n440AperBanReg = (String.IsNullOrEmpty(StringUtil.RTrim( A440AperBanReg)) ? true : false);
            A470AperSts = cgiGet( edtAperSts_Internalname);
            AssignAttri("", false, "A470AperSts", A470AperSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperSaldo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperSaldo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERSALDO");
               AnyError = 1;
               GX_FocusControl = edtAperSaldo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A457AperSaldo = 0;
               AssignAttri("", false, "A457AperSaldo", StringUtil.LTrimStr( A457AperSaldo, 15, 2));
            }
            else
            {
               A457AperSaldo = context.localUtil.CToN( cgiGet( edtAperSaldo_Internalname), ".", ",");
               AssignAttri("", false, "A457AperSaldo", StringUtil.LTrimStr( A457AperSaldo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperReponer_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtAperReponer_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERREPONER");
               AnyError = 1;
               GX_FocusControl = edtAperReponer_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A467AperReponer = 0;
               AssignAttri("", false, "A467AperReponer", StringUtil.LTrimStr( A467AperReponer, 15, 2));
            }
            else
            {
               A467AperReponer = context.localUtil.CToN( cgiGet( edtAperReponer_Internalname), ".", ",");
               AssignAttri("", false, "A467AperReponer", StringUtil.LTrimStr( A467AperReponer, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAperTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAperTItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "APERTITEM");
               AnyError = 1;
               GX_FocusControl = edtAperTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A471AperTItem = 0;
               AssignAttri("", false, "A471AperTItem", StringUtil.LTrimStr( (decimal)(A471AperTItem), 6, 0));
            }
            else
            {
               A471AperTItem = (int)(context.localUtil.CToN( cgiGet( edtAperTItem_Internalname), ".", ","));
               AssignAttri("", false, "A471AperTItem", StringUtil.LTrimStr( (decimal)(A471AperTItem), 6, 0));
            }
            A472AperTMovDsc = cgiGet( edtAperTMovDsc_Internalname);
            AssignAttri("", false, "A472AperTMovDsc", A472AperTMovDsc);
            A456AperImpTotal = context.localUtil.CToN( cgiGet( edtAperImpTotal_Internalname), ".", ",");
            AssignAttri("", false, "A456AperImpTotal", StringUtil.LTrimStr( A456AperImpTotal, 15, 2));
            A458AperMonDsc = cgiGet( edtAperMonDsc_Internalname);
            AssignAttri("", false, "A458AperMonDsc", A458AperMonDsc);
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
               A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = GetPar( "AperCajCod");
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
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
               InitAll4Z166( ) ;
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
         DisableAttributes4Z166( ) ;
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

      protected void CONFIRM_4Z0( )
      {
         BeforeValidate4Z166( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4Z166( ) ;
            }
            else
            {
               CheckExtendedTable4Z166( ) ;
               if ( AnyError == 0 )
               {
                  ZM4Z166( 4) ;
                  ZM4Z166( 5) ;
                  ZM4Z166( 6) ;
                  ZM4Z166( 7) ;
                  ZM4Z166( 8) ;
               }
               CloseExtendedTableCursors4Z166( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4Z0( ) ;
         }
      }

      protected void ResetCaption4Z0( )
      {
      }

      protected void ZM4Z166( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z441AperCajFec = T004Z3_A441AperCajFec[0];
               Z442AperCheque = T004Z3_A442AperCheque[0];
               Z455AperImporte = T004Z3_A455AperImporte[0];
               Z473AperTope = T004Z3_A473AperTope[0];
               Z440AperBanReg = T004Z3_A440AperBanReg[0];
               Z470AperSts = T004Z3_A470AperSts[0];
               Z457AperSaldo = T004Z3_A457AperSaldo[0];
               Z467AperReponer = T004Z3_A467AperReponer[0];
               Z471AperTItem = T004Z3_A471AperTItem[0];
               Z364AperMonCod = T004Z3_A364AperMonCod[0];
               Z363AperForCod = T004Z3_A363AperForCod[0];
               Z361AperBanCod = T004Z3_A361AperBanCod[0];
               Z362AperCueBan = T004Z3_A362AperCueBan[0];
               Z360AperTmov = T004Z3_A360AperTmov[0];
            }
            else
            {
               Z441AperCajFec = A441AperCajFec;
               Z442AperCheque = A442AperCheque;
               Z455AperImporte = A455AperImporte;
               Z473AperTope = A473AperTope;
               Z440AperBanReg = A440AperBanReg;
               Z470AperSts = A470AperSts;
               Z457AperSaldo = A457AperSaldo;
               Z467AperReponer = A467AperReponer;
               Z471AperTItem = A471AperTItem;
               Z364AperMonCod = A364AperMonCod;
               Z363AperForCod = A363AperForCod;
               Z361AperBanCod = A361AperBanCod;
               Z362AperCueBan = A362AperCueBan;
               Z360AperTmov = A360AperTmov;
            }
         }
         if ( GX_JID == -3 )
         {
            Z359AperCajCod = A359AperCajCod;
            Z441AperCajFec = A441AperCajFec;
            Z442AperCheque = A442AperCheque;
            Z455AperImporte = A455AperImporte;
            Z473AperTope = A473AperTope;
            Z440AperBanReg = A440AperBanReg;
            Z470AperSts = A470AperSts;
            Z457AperSaldo = A457AperSaldo;
            Z467AperReponer = A467AperReponer;
            Z471AperTItem = A471AperTItem;
            Z358CajCod = A358CajCod;
            Z364AperMonCod = A364AperMonCod;
            Z363AperForCod = A363AperForCod;
            Z361AperBanCod = A361AperBanCod;
            Z362AperCueBan = A362AperCueBan;
            Z360AperTmov = A360AperTmov;
            Z458AperMonDsc = A458AperMonDsc;
            Z472AperTMovDsc = A472AperTMovDsc;
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

      protected void Load4Z166( )
      {
         /* Using cursor T004Z9 */
         pr_default.execute(7, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound166 = 1;
            A441AperCajFec = T004Z9_A441AperCajFec[0];
            AssignAttri("", false, "A441AperCajFec", context.localUtil.Format(A441AperCajFec, "99/99/99"));
            A442AperCheque = T004Z9_A442AperCheque[0];
            AssignAttri("", false, "A442AperCheque", A442AperCheque);
            A455AperImporte = T004Z9_A455AperImporte[0];
            AssignAttri("", false, "A455AperImporte", StringUtil.LTrimStr( A455AperImporte, 15, 2));
            A473AperTope = T004Z9_A473AperTope[0];
            AssignAttri("", false, "A473AperTope", StringUtil.LTrimStr( A473AperTope, 15, 2));
            A440AperBanReg = T004Z9_A440AperBanReg[0];
            n440AperBanReg = T004Z9_n440AperBanReg[0];
            AssignAttri("", false, "A440AperBanReg", A440AperBanReg);
            A470AperSts = T004Z9_A470AperSts[0];
            AssignAttri("", false, "A470AperSts", A470AperSts);
            A457AperSaldo = T004Z9_A457AperSaldo[0];
            AssignAttri("", false, "A457AperSaldo", StringUtil.LTrimStr( A457AperSaldo, 15, 2));
            A467AperReponer = T004Z9_A467AperReponer[0];
            AssignAttri("", false, "A467AperReponer", StringUtil.LTrimStr( A467AperReponer, 15, 2));
            A471AperTItem = T004Z9_A471AperTItem[0];
            AssignAttri("", false, "A471AperTItem", StringUtil.LTrimStr( (decimal)(A471AperTItem), 6, 0));
            A472AperTMovDsc = T004Z9_A472AperTMovDsc[0];
            AssignAttri("", false, "A472AperTMovDsc", A472AperTMovDsc);
            A458AperMonDsc = T004Z9_A458AperMonDsc[0];
            AssignAttri("", false, "A458AperMonDsc", A458AperMonDsc);
            A364AperMonCod = T004Z9_A364AperMonCod[0];
            AssignAttri("", false, "A364AperMonCod", StringUtil.LTrimStr( (decimal)(A364AperMonCod), 6, 0));
            A363AperForCod = T004Z9_A363AperForCod[0];
            AssignAttri("", false, "A363AperForCod", StringUtil.LTrimStr( (decimal)(A363AperForCod), 6, 0));
            A361AperBanCod = T004Z9_A361AperBanCod[0];
            n361AperBanCod = T004Z9_n361AperBanCod[0];
            AssignAttri("", false, "A361AperBanCod", StringUtil.LTrimStr( (decimal)(A361AperBanCod), 6, 0));
            A362AperCueBan = T004Z9_A362AperCueBan[0];
            n362AperCueBan = T004Z9_n362AperCueBan[0];
            AssignAttri("", false, "A362AperCueBan", A362AperCueBan);
            A360AperTmov = T004Z9_A360AperTmov[0];
            n360AperTmov = T004Z9_n360AperTmov[0];
            AssignAttri("", false, "A360AperTmov", StringUtil.LTrimStr( (decimal)(A360AperTmov), 6, 0));
            ZM4Z166( -3) ;
         }
         pr_default.close(7);
         OnLoadActions4Z166( ) ;
      }

      protected void OnLoadActions4Z166( )
      {
         A456AperImpTotal = (decimal)(A457AperSaldo+A455AperImporte);
         AssignAttri("", false, "A456AperImpTotal", StringUtil.LTrimStr( A456AperImpTotal, 15, 2));
      }

      protected void CheckExtendedTable4Z166( )
      {
         nIsDirty_166 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004Z4 */
         pr_default.execute(2, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A441AperCajFec) || ( DateTimeUtil.ResetTime ( A441AperCajFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Apertura fuera de rango", "OutOfRange", 1, "APERCAJFEC");
            AnyError = 1;
            GX_FocusControl = edtAperCajFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T004Z5 */
         pr_default.execute(3, new Object[] {A364AperMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "APERMONCOD");
            AnyError = 1;
            GX_FocusControl = edtAperMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A458AperMonDsc = T004Z5_A458AperMonDsc[0];
         AssignAttri("", false, "A458AperMonDsc", A458AperMonDsc);
         pr_default.close(3);
         /* Using cursor T004Z6 */
         pr_default.execute(4, new Object[] {A363AperForCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "APERFORCOD");
            AnyError = 1;
            GX_FocusControl = edtAperForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T004Z7 */
         pr_default.execute(5, new Object[] {n361AperBanCod, A361AperBanCod, n362AperCueBan, A362AperCueBan});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A361AperBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A362AperCueBan)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Caja Chica Banco'.", "ForeignKeyNotFound", 1, "APERCUEBAN");
               AnyError = 1;
               GX_FocusControl = edtAperBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         nIsDirty_166 = 1;
         A456AperImpTotal = (decimal)(A457AperSaldo+A455AperImporte);
         AssignAttri("", false, "A456AperImpTotal", StringUtil.LTrimStr( A456AperImpTotal, 15, 2));
         /* Using cursor T004Z8 */
         pr_default.execute(6, new Object[] {n360AperTmov, A360AperTmov});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A360AperTmov) ) )
            {
               GX_msglist.addItem("No existe 'Sub Apertura Caja Movimiento'.", "ForeignKeyNotFound", 1, "APERTMOV");
               AnyError = 1;
               GX_FocusControl = edtAperTmov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A472AperTMovDsc = T004Z8_A472AperTMovDsc[0];
         AssignAttri("", false, "A472AperTMovDsc", A472AperTMovDsc);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors4Z166( )
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

      protected void gxLoad_4( int A358CajCod )
      {
         /* Using cursor T004Z10 */
         pr_default.execute(8, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
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

      protected void gxLoad_5( int A364AperMonCod )
      {
         /* Using cursor T004Z11 */
         pr_default.execute(9, new Object[] {A364AperMonCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "APERMONCOD");
            AnyError = 1;
            GX_FocusControl = edtAperMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A458AperMonDsc = T004Z11_A458AperMonDsc[0];
         AssignAttri("", false, "A458AperMonDsc", A458AperMonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A458AperMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( int A363AperForCod )
      {
         /* Using cursor T004Z12 */
         pr_default.execute(10, new Object[] {A363AperForCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "APERFORCOD");
            AnyError = 1;
            GX_FocusControl = edtAperForCod_Internalname;
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

      protected void gxLoad_7( int A361AperBanCod ,
                               string A362AperCueBan )
      {
         /* Using cursor T004Z13 */
         pr_default.execute(11, new Object[] {n361AperBanCod, A361AperBanCod, n362AperCueBan, A362AperCueBan});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A361AperBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A362AperCueBan)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Caja Chica Banco'.", "ForeignKeyNotFound", 1, "APERCUEBAN");
               AnyError = 1;
               GX_FocusControl = edtAperBanCod_Internalname;
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

      protected void gxLoad_8( int A360AperTmov )
      {
         /* Using cursor T004Z14 */
         pr_default.execute(12, new Object[] {n360AperTmov, A360AperTmov});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A360AperTmov) ) )
            {
               GX_msglist.addItem("No existe 'Sub Apertura Caja Movimiento'.", "ForeignKeyNotFound", 1, "APERTMOV");
               AnyError = 1;
               GX_FocusControl = edtAperTmov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A472AperTMovDsc = T004Z14_A472AperTMovDsc[0];
         AssignAttri("", false, "A472AperTMovDsc", A472AperTMovDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A472AperTMovDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey4Z166( )
      {
         /* Using cursor T004Z15 */
         pr_default.execute(13, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound166 = 1;
         }
         else
         {
            RcdFound166 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004Z3 */
         pr_default.execute(1, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4Z166( 3) ;
            RcdFound166 = 1;
            A359AperCajCod = T004Z3_A359AperCajCod[0];
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            A441AperCajFec = T004Z3_A441AperCajFec[0];
            AssignAttri("", false, "A441AperCajFec", context.localUtil.Format(A441AperCajFec, "99/99/99"));
            A442AperCheque = T004Z3_A442AperCheque[0];
            AssignAttri("", false, "A442AperCheque", A442AperCheque);
            A455AperImporte = T004Z3_A455AperImporte[0];
            AssignAttri("", false, "A455AperImporte", StringUtil.LTrimStr( A455AperImporte, 15, 2));
            A473AperTope = T004Z3_A473AperTope[0];
            AssignAttri("", false, "A473AperTope", StringUtil.LTrimStr( A473AperTope, 15, 2));
            A440AperBanReg = T004Z3_A440AperBanReg[0];
            n440AperBanReg = T004Z3_n440AperBanReg[0];
            AssignAttri("", false, "A440AperBanReg", A440AperBanReg);
            A470AperSts = T004Z3_A470AperSts[0];
            AssignAttri("", false, "A470AperSts", A470AperSts);
            A457AperSaldo = T004Z3_A457AperSaldo[0];
            AssignAttri("", false, "A457AperSaldo", StringUtil.LTrimStr( A457AperSaldo, 15, 2));
            A467AperReponer = T004Z3_A467AperReponer[0];
            AssignAttri("", false, "A467AperReponer", StringUtil.LTrimStr( A467AperReponer, 15, 2));
            A471AperTItem = T004Z3_A471AperTItem[0];
            AssignAttri("", false, "A471AperTItem", StringUtil.LTrimStr( (decimal)(A471AperTItem), 6, 0));
            A358CajCod = T004Z3_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A364AperMonCod = T004Z3_A364AperMonCod[0];
            AssignAttri("", false, "A364AperMonCod", StringUtil.LTrimStr( (decimal)(A364AperMonCod), 6, 0));
            A363AperForCod = T004Z3_A363AperForCod[0];
            AssignAttri("", false, "A363AperForCod", StringUtil.LTrimStr( (decimal)(A363AperForCod), 6, 0));
            A361AperBanCod = T004Z3_A361AperBanCod[0];
            n361AperBanCod = T004Z3_n361AperBanCod[0];
            AssignAttri("", false, "A361AperBanCod", StringUtil.LTrimStr( (decimal)(A361AperBanCod), 6, 0));
            A362AperCueBan = T004Z3_A362AperCueBan[0];
            n362AperCueBan = T004Z3_n362AperCueBan[0];
            AssignAttri("", false, "A362AperCueBan", A362AperCueBan);
            A360AperTmov = T004Z3_A360AperTmov[0];
            n360AperTmov = T004Z3_n360AperTmov[0];
            AssignAttri("", false, "A360AperTmov", StringUtil.LTrimStr( (decimal)(A360AperTmov), 6, 0));
            Z358CajCod = A358CajCod;
            Z359AperCajCod = A359AperCajCod;
            sMode166 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4Z166( ) ;
            if ( AnyError == 1 )
            {
               RcdFound166 = 0;
               InitializeNonKey4Z166( ) ;
            }
            Gx_mode = sMode166;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound166 = 0;
            InitializeNonKey4Z166( ) ;
            sMode166 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode166;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4Z166( ) ;
         if ( RcdFound166 == 0 )
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
         RcdFound166 = 0;
         /* Using cursor T004Z16 */
         pr_default.execute(14, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T004Z16_A358CajCod[0] < A358CajCod ) || ( T004Z16_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T004Z16_A359AperCajCod[0], A359AperCajCod) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T004Z16_A358CajCod[0] > A358CajCod ) || ( T004Z16_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T004Z16_A359AperCajCod[0], A359AperCajCod) > 0 ) ) )
            {
               A358CajCod = T004Z16_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = T004Z16_A359AperCajCod[0];
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               RcdFound166 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound166 = 0;
         /* Using cursor T004Z17 */
         pr_default.execute(15, new Object[] {A358CajCod, A359AperCajCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T004Z17_A358CajCod[0] > A358CajCod ) || ( T004Z17_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T004Z17_A359AperCajCod[0], A359AperCajCod) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T004Z17_A358CajCod[0] < A358CajCod ) || ( T004Z17_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T004Z17_A359AperCajCod[0], A359AperCajCod) < 0 ) ) )
            {
               A358CajCod = T004Z17_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = T004Z17_A359AperCajCod[0];
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               RcdFound166 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4Z166( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4Z166( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound166 == 1 )
            {
               if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) )
               {
                  A358CajCod = Z358CajCod;
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
                  A359AperCajCod = Z359AperCajCod;
                  AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4Z166( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4Z166( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4Z166( ) ;
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
         if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) )
         {
            A358CajCod = Z358CajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = Z359AperCajCod;
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCajCod_Internalname;
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
         GetKey4Z166( ) ;
         if ( RcdFound166 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) )
            {
               A358CajCod = Z358CajCod;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A359AperCajCod = Z359AperCajCod;
               AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
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
            if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A359AperCajCod, Z359AperCajCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
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
         context.RollbackDataStores("tsaperturacaja",pr_default);
         GX_FocusControl = edtAperCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4Z0( ) ;
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
         if ( RcdFound166 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAperCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4Z166( ) ;
         if ( RcdFound166 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4Z166( ) ;
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
         if ( RcdFound166 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperCajFec_Internalname;
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
         if ( RcdFound166 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperCajFec_Internalname;
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
         ScanStart4Z166( ) ;
         if ( RcdFound166 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound166 != 0 )
            {
               ScanNext4Z166( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAperCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4Z166( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4Z166( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004Z2 */
            pr_default.execute(0, new Object[] {A358CajCod, A359AperCajCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSAPERTURACAJA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z441AperCajFec ) != DateTimeUtil.ResetTime ( T004Z2_A441AperCajFec[0] ) ) || ( StringUtil.StrCmp(Z442AperCheque, T004Z2_A442AperCheque[0]) != 0 ) || ( Z455AperImporte != T004Z2_A455AperImporte[0] ) || ( Z473AperTope != T004Z2_A473AperTope[0] ) || ( StringUtil.StrCmp(Z440AperBanReg, T004Z2_A440AperBanReg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z470AperSts, T004Z2_A470AperSts[0]) != 0 ) || ( Z457AperSaldo != T004Z2_A457AperSaldo[0] ) || ( Z467AperReponer != T004Z2_A467AperReponer[0] ) || ( Z471AperTItem != T004Z2_A471AperTItem[0] ) || ( Z364AperMonCod != T004Z2_A364AperMonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z363AperForCod != T004Z2_A363AperForCod[0] ) || ( Z361AperBanCod != T004Z2_A361AperBanCod[0] ) || ( StringUtil.StrCmp(Z362AperCueBan, T004Z2_A362AperCueBan[0]) != 0 ) || ( Z360AperTmov != T004Z2_A360AperTmov[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z441AperCajFec ) != DateTimeUtil.ResetTime ( T004Z2_A441AperCajFec[0] ) )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperCajFec");
                  GXUtil.WriteLogRaw("Old: ",Z441AperCajFec);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A441AperCajFec[0]);
               }
               if ( StringUtil.StrCmp(Z442AperCheque, T004Z2_A442AperCheque[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperCheque");
                  GXUtil.WriteLogRaw("Old: ",Z442AperCheque);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A442AperCheque[0]);
               }
               if ( Z455AperImporte != T004Z2_A455AperImporte[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperImporte");
                  GXUtil.WriteLogRaw("Old: ",Z455AperImporte);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A455AperImporte[0]);
               }
               if ( Z473AperTope != T004Z2_A473AperTope[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperTope");
                  GXUtil.WriteLogRaw("Old: ",Z473AperTope);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A473AperTope[0]);
               }
               if ( StringUtil.StrCmp(Z440AperBanReg, T004Z2_A440AperBanReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperBanReg");
                  GXUtil.WriteLogRaw("Old: ",Z440AperBanReg);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A440AperBanReg[0]);
               }
               if ( StringUtil.StrCmp(Z470AperSts, T004Z2_A470AperSts[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperSts");
                  GXUtil.WriteLogRaw("Old: ",Z470AperSts);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A470AperSts[0]);
               }
               if ( Z457AperSaldo != T004Z2_A457AperSaldo[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperSaldo");
                  GXUtil.WriteLogRaw("Old: ",Z457AperSaldo);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A457AperSaldo[0]);
               }
               if ( Z467AperReponer != T004Z2_A467AperReponer[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperReponer");
                  GXUtil.WriteLogRaw("Old: ",Z467AperReponer);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A467AperReponer[0]);
               }
               if ( Z471AperTItem != T004Z2_A471AperTItem[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperTItem");
                  GXUtil.WriteLogRaw("Old: ",Z471AperTItem);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A471AperTItem[0]);
               }
               if ( Z364AperMonCod != T004Z2_A364AperMonCod[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z364AperMonCod);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A364AperMonCod[0]);
               }
               if ( Z363AperForCod != T004Z2_A363AperForCod[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperForCod");
                  GXUtil.WriteLogRaw("Old: ",Z363AperForCod);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A363AperForCod[0]);
               }
               if ( Z361AperBanCod != T004Z2_A361AperBanCod[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z361AperBanCod);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A361AperBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z362AperCueBan, T004Z2_A362AperCueBan[0]) != 0 )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperCueBan");
                  GXUtil.WriteLogRaw("Old: ",Z362AperCueBan);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A362AperCueBan[0]);
               }
               if ( Z360AperTmov != T004Z2_A360AperTmov[0] )
               {
                  GXUtil.WriteLog("tsaperturacaja:[seudo value changed for attri]"+"AperTmov");
                  GXUtil.WriteLogRaw("Old: ",Z360AperTmov);
                  GXUtil.WriteLogRaw("Current: ",T004Z2_A360AperTmov[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSAPERTURACAJA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4Z166( )
      {
         BeforeValidate4Z166( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4Z166( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4Z166( 0) ;
            CheckOptimisticConcurrency4Z166( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4Z166( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4Z166( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004Z18 */
                     pr_default.execute(16, new Object[] {A359AperCajCod, A441AperCajFec, A442AperCheque, A455AperImporte, A473AperTope, n440AperBanReg, A440AperBanReg, A470AperSts, A457AperSaldo, A467AperReponer, A471AperTItem, A358CajCod, A364AperMonCod, A363AperForCod, n361AperBanCod, A361AperBanCod, n362AperCueBan, A362AperCueBan, n360AperTmov, A360AperTmov});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("TSAPERTURACAJA");
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
                           ResetCaption4Z0( ) ;
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
               Load4Z166( ) ;
            }
            EndLevel4Z166( ) ;
         }
         CloseExtendedTableCursors4Z166( ) ;
      }

      protected void Update4Z166( )
      {
         BeforeValidate4Z166( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4Z166( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4Z166( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4Z166( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4Z166( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004Z19 */
                     pr_default.execute(17, new Object[] {A441AperCajFec, A442AperCheque, A455AperImporte, A473AperTope, n440AperBanReg, A440AperBanReg, A470AperSts, A457AperSaldo, A467AperReponer, A471AperTItem, A364AperMonCod, A363AperForCod, n361AperBanCod, A361AperBanCod, n362AperCueBan, A362AperCueBan, n360AperTmov, A360AperTmov, A358CajCod, A359AperCajCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("TSAPERTURACAJA");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSAPERTURACAJA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4Z166( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4Z0( ) ;
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
            EndLevel4Z166( ) ;
         }
         CloseExtendedTableCursors4Z166( ) ;
      }

      protected void DeferredUpdate4Z166( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4Z166( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4Z166( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4Z166( ) ;
            AfterConfirm4Z166( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4Z166( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004Z20 */
                  pr_default.execute(18, new Object[] {A358CajCod, A359AperCajCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("TSAPERTURACAJA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound166 == 0 )
                        {
                           InitAll4Z166( ) ;
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
                        ResetCaption4Z0( ) ;
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
         sMode166 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4Z166( ) ;
         Gx_mode = sMode166;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4Z166( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004Z21 */
            pr_default.execute(19, new Object[] {A364AperMonCod});
            A458AperMonDsc = T004Z21_A458AperMonDsc[0];
            AssignAttri("", false, "A458AperMonDsc", A458AperMonDsc);
            pr_default.close(19);
            /* Using cursor T004Z22 */
            pr_default.execute(20, new Object[] {n360AperTmov, A360AperTmov});
            A472AperTMovDsc = T004Z22_A472AperTMovDsc[0];
            AssignAttri("", false, "A472AperTMovDsc", A472AperTMovDsc);
            pr_default.close(20);
            A456AperImpTotal = (decimal)(A457AperSaldo+A455AperImporte);
            AssignAttri("", false, "A456AperImpTotal", StringUtil.LTrimStr( A456AperImpTotal, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T004Z23 */
            pr_default.execute(21, new Object[] {A358CajCod, A359AperCajCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reposicion de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel4Z166( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4Z166( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            context.CommitDataStores("tsaperturacaja",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4Z0( ) ;
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
            context.RollbackDataStores("tsaperturacaja",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4Z166( )
      {
         /* Using cursor T004Z24 */
         pr_default.execute(22);
         RcdFound166 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound166 = 1;
            A358CajCod = T004Z24_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = T004Z24_A359AperCajCod[0];
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4Z166( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound166 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound166 = 1;
            A358CajCod = T004Z24_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A359AperCajCod = T004Z24_A359AperCajCod[0];
            AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
         }
      }

      protected void ScanEnd4Z166( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm4Z166( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4Z166( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4Z166( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4Z166( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4Z166( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4Z166( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4Z166( )
      {
         edtCajCod_Enabled = 0;
         AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         edtAperCajCod_Enabled = 0;
         AssignProp("", false, edtAperCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperCajCod_Enabled), 5, 0), true);
         edtAperCajFec_Enabled = 0;
         AssignProp("", false, edtAperCajFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperCajFec_Enabled), 5, 0), true);
         edtAperMonCod_Enabled = 0;
         AssignProp("", false, edtAperMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperMonCod_Enabled), 5, 0), true);
         edtAperForCod_Enabled = 0;
         AssignProp("", false, edtAperForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperForCod_Enabled), 5, 0), true);
         edtAperBanCod_Enabled = 0;
         AssignProp("", false, edtAperBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperBanCod_Enabled), 5, 0), true);
         edtAperCueBan_Enabled = 0;
         AssignProp("", false, edtAperCueBan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperCueBan_Enabled), 5, 0), true);
         edtAperCheque_Enabled = 0;
         AssignProp("", false, edtAperCheque_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperCheque_Enabled), 5, 0), true);
         edtAperImporte_Enabled = 0;
         AssignProp("", false, edtAperImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperImporte_Enabled), 5, 0), true);
         edtAperTope_Enabled = 0;
         AssignProp("", false, edtAperTope_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperTope_Enabled), 5, 0), true);
         edtAperTmov_Enabled = 0;
         AssignProp("", false, edtAperTmov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperTmov_Enabled), 5, 0), true);
         edtAperBanReg_Enabled = 0;
         AssignProp("", false, edtAperBanReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperBanReg_Enabled), 5, 0), true);
         edtAperSts_Enabled = 0;
         AssignProp("", false, edtAperSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperSts_Enabled), 5, 0), true);
         edtAperSaldo_Enabled = 0;
         AssignProp("", false, edtAperSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperSaldo_Enabled), 5, 0), true);
         edtAperReponer_Enabled = 0;
         AssignProp("", false, edtAperReponer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperReponer_Enabled), 5, 0), true);
         edtAperTItem_Enabled = 0;
         AssignProp("", false, edtAperTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperTItem_Enabled), 5, 0), true);
         edtAperTMovDsc_Enabled = 0;
         AssignProp("", false, edtAperTMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperTMovDsc_Enabled), 5, 0), true);
         edtAperImpTotal_Enabled = 0;
         AssignProp("", false, edtAperImpTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperImpTotal_Enabled), 5, 0), true);
         edtAperMonDsc_Enabled = 0;
         AssignProp("", false, edtAperMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAperMonDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4Z166( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4Z0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025460", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsaperturacaja.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z359AperCajCod", StringUtil.RTrim( Z359AperCajCod));
         GxWebStd.gx_hidden_field( context, "Z441AperCajFec", context.localUtil.DToC( Z441AperCajFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z442AperCheque", StringUtil.RTrim( Z442AperCheque));
         GxWebStd.gx_hidden_field( context, "Z455AperImporte", StringUtil.LTrim( StringUtil.NToC( Z455AperImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z473AperTope", StringUtil.LTrim( StringUtil.NToC( Z473AperTope, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z440AperBanReg", StringUtil.RTrim( Z440AperBanReg));
         GxWebStd.gx_hidden_field( context, "Z470AperSts", StringUtil.RTrim( Z470AperSts));
         GxWebStd.gx_hidden_field( context, "Z457AperSaldo", StringUtil.LTrim( StringUtil.NToC( Z457AperSaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z467AperReponer", StringUtil.LTrim( StringUtil.NToC( Z467AperReponer, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z471AperTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z471AperTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z364AperMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z364AperMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z363AperForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z363AperForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z361AperBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z361AperBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z362AperCueBan", StringUtil.RTrim( Z362AperCueBan));
         GxWebStd.gx_hidden_field( context, "Z360AperTmov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z360AperTmov), 6, 0, ".", "")));
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
         return formatLink("tsaperturacaja.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSAPERTURACAJA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Apertura de Caja Chica" ;
      }

      protected void InitializeNonKey4Z166( )
      {
         A456AperImpTotal = 0;
         AssignAttri("", false, "A456AperImpTotal", StringUtil.LTrimStr( A456AperImpTotal, 15, 2));
         A441AperCajFec = DateTime.MinValue;
         AssignAttri("", false, "A441AperCajFec", context.localUtil.Format(A441AperCajFec, "99/99/99"));
         A364AperMonCod = 0;
         AssignAttri("", false, "A364AperMonCod", StringUtil.LTrimStr( (decimal)(A364AperMonCod), 6, 0));
         A363AperForCod = 0;
         AssignAttri("", false, "A363AperForCod", StringUtil.LTrimStr( (decimal)(A363AperForCod), 6, 0));
         A361AperBanCod = 0;
         n361AperBanCod = false;
         AssignAttri("", false, "A361AperBanCod", StringUtil.LTrimStr( (decimal)(A361AperBanCod), 6, 0));
         n361AperBanCod = ((0==A361AperBanCod) ? true : false);
         A362AperCueBan = "";
         n362AperCueBan = false;
         AssignAttri("", false, "A362AperCueBan", A362AperCueBan);
         n362AperCueBan = (String.IsNullOrEmpty(StringUtil.RTrim( A362AperCueBan)) ? true : false);
         A442AperCheque = "";
         AssignAttri("", false, "A442AperCheque", A442AperCheque);
         A455AperImporte = 0;
         AssignAttri("", false, "A455AperImporte", StringUtil.LTrimStr( A455AperImporte, 15, 2));
         A473AperTope = 0;
         AssignAttri("", false, "A473AperTope", StringUtil.LTrimStr( A473AperTope, 15, 2));
         A360AperTmov = 0;
         n360AperTmov = false;
         AssignAttri("", false, "A360AperTmov", StringUtil.LTrimStr( (decimal)(A360AperTmov), 6, 0));
         n360AperTmov = ((0==A360AperTmov) ? true : false);
         A440AperBanReg = "";
         n440AperBanReg = false;
         AssignAttri("", false, "A440AperBanReg", A440AperBanReg);
         n440AperBanReg = (String.IsNullOrEmpty(StringUtil.RTrim( A440AperBanReg)) ? true : false);
         A470AperSts = "";
         AssignAttri("", false, "A470AperSts", A470AperSts);
         A457AperSaldo = 0;
         AssignAttri("", false, "A457AperSaldo", StringUtil.LTrimStr( A457AperSaldo, 15, 2));
         A467AperReponer = 0;
         AssignAttri("", false, "A467AperReponer", StringUtil.LTrimStr( A467AperReponer, 15, 2));
         A471AperTItem = 0;
         AssignAttri("", false, "A471AperTItem", StringUtil.LTrimStr( (decimal)(A471AperTItem), 6, 0));
         A472AperTMovDsc = "";
         AssignAttri("", false, "A472AperTMovDsc", A472AperTMovDsc);
         A458AperMonDsc = "";
         AssignAttri("", false, "A458AperMonDsc", A458AperMonDsc);
         Z441AperCajFec = DateTime.MinValue;
         Z442AperCheque = "";
         Z455AperImporte = 0;
         Z473AperTope = 0;
         Z440AperBanReg = "";
         Z470AperSts = "";
         Z457AperSaldo = 0;
         Z467AperReponer = 0;
         Z471AperTItem = 0;
         Z364AperMonCod = 0;
         Z363AperForCod = 0;
         Z361AperBanCod = 0;
         Z362AperCueBan = "";
         Z360AperTmov = 0;
      }

      protected void InitAll4Z166( )
      {
         A358CajCod = 0;
         AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         A359AperCajCod = "";
         AssignAttri("", false, "A359AperCajCod", A359AperCajCod);
         InitializeNonKey4Z166( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254615", true, true);
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
         context.AddJavascriptSource("tsaperturacaja.js", "?202281810254615", false, true);
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
         edtCajCod_Internalname = "CAJCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAperCajCod_Internalname = "APERCAJCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtAperCajFec_Internalname = "APERCAJFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAperMonCod_Internalname = "APERMONCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtAperForCod_Internalname = "APERFORCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtAperBanCod_Internalname = "APERBANCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtAperCueBan_Internalname = "APERCUEBAN";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtAperCheque_Internalname = "APERCHEQUE";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtAperImporte_Internalname = "APERIMPORTE";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtAperTope_Internalname = "APERTOPE";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtAperTmov_Internalname = "APERTMOV";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtAperBanReg_Internalname = "APERBANREG";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtAperSts_Internalname = "APERSTS";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtAperSaldo_Internalname = "APERSALDO";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtAperReponer_Internalname = "APERREPONER";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtAperTItem_Internalname = "APERTITEM";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtAperTMovDsc_Internalname = "APERTMOVDSC";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtAperImpTotal_Internalname = "APERIMPTOTAL";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtAperMonDsc_Internalname = "APERMONDSC";
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
         Form.Caption = "Apertura de Caja Chica";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAperMonDsc_Jsonclick = "";
         edtAperMonDsc_Enabled = 0;
         edtAperImpTotal_Jsonclick = "";
         edtAperImpTotal_Enabled = 0;
         edtAperTMovDsc_Jsonclick = "";
         edtAperTMovDsc_Enabled = 0;
         edtAperTItem_Jsonclick = "";
         edtAperTItem_Enabled = 1;
         edtAperReponer_Jsonclick = "";
         edtAperReponer_Enabled = 1;
         edtAperSaldo_Jsonclick = "";
         edtAperSaldo_Enabled = 1;
         edtAperSts_Jsonclick = "";
         edtAperSts_Enabled = 1;
         edtAperBanReg_Jsonclick = "";
         edtAperBanReg_Enabled = 1;
         edtAperTmov_Jsonclick = "";
         edtAperTmov_Enabled = 1;
         edtAperTope_Jsonclick = "";
         edtAperTope_Enabled = 1;
         edtAperImporte_Jsonclick = "";
         edtAperImporte_Enabled = 1;
         edtAperCheque_Jsonclick = "";
         edtAperCheque_Enabled = 1;
         edtAperCueBan_Jsonclick = "";
         edtAperCueBan_Enabled = 1;
         edtAperBanCod_Jsonclick = "";
         edtAperBanCod_Enabled = 1;
         edtAperForCod_Jsonclick = "";
         edtAperForCod_Enabled = 1;
         edtAperMonCod_Jsonclick = "";
         edtAperMonCod_Enabled = 1;
         edtAperCajFec_Jsonclick = "";
         edtAperCajFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtAperCajCod_Jsonclick = "";
         edtAperCajCod_Enabled = 1;
         edtCajCod_Jsonclick = "";
         edtCajCod_Enabled = 1;
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
         /* Using cursor T004Z25 */
         pr_default.execute(23, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(23);
         GX_FocusControl = edtAperCajFec_Internalname;
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

      public void Valid_Cajcod( )
      {
         /* Using cursor T004Z25 */
         pr_default.execute(23, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Apercajcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A441AperCajFec", context.localUtil.Format(A441AperCajFec, "99/99/99"));
         AssignAttri("", false, "A364AperMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A364AperMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A363AperForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A363AperForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A361AperBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A361AperBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A362AperCueBan", StringUtil.RTrim( A362AperCueBan));
         AssignAttri("", false, "A442AperCheque", StringUtil.RTrim( A442AperCheque));
         AssignAttri("", false, "A455AperImporte", StringUtil.LTrim( StringUtil.NToC( A455AperImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A473AperTope", StringUtil.LTrim( StringUtil.NToC( A473AperTope, 15, 2, ".", "")));
         AssignAttri("", false, "A360AperTmov", StringUtil.LTrim( StringUtil.NToC( (decimal)(A360AperTmov), 6, 0, ".", "")));
         AssignAttri("", false, "A440AperBanReg", StringUtil.RTrim( A440AperBanReg));
         AssignAttri("", false, "A470AperSts", StringUtil.RTrim( A470AperSts));
         AssignAttri("", false, "A457AperSaldo", StringUtil.LTrim( StringUtil.NToC( A457AperSaldo, 15, 2, ".", "")));
         AssignAttri("", false, "A467AperReponer", StringUtil.LTrim( StringUtil.NToC( A467AperReponer, 15, 2, ".", "")));
         AssignAttri("", false, "A471AperTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A471AperTItem), 6, 0, ".", "")));
         AssignAttri("", false, "A458AperMonDsc", StringUtil.RTrim( A458AperMonDsc));
         AssignAttri("", false, "A456AperImpTotal", StringUtil.LTrim( StringUtil.NToC( A456AperImpTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A472AperTMovDsc", StringUtil.RTrim( A472AperTMovDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z359AperCajCod", StringUtil.RTrim( Z359AperCajCod));
         GxWebStd.gx_hidden_field( context, "Z441AperCajFec", context.localUtil.Format(Z441AperCajFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z364AperMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z364AperMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z363AperForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z363AperForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z361AperBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z361AperBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z362AperCueBan", StringUtil.RTrim( Z362AperCueBan));
         GxWebStd.gx_hidden_field( context, "Z442AperCheque", StringUtil.RTrim( Z442AperCheque));
         GxWebStd.gx_hidden_field( context, "Z455AperImporte", StringUtil.LTrim( StringUtil.NToC( Z455AperImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z473AperTope", StringUtil.LTrim( StringUtil.NToC( Z473AperTope, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z360AperTmov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z360AperTmov), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z440AperBanReg", StringUtil.RTrim( Z440AperBanReg));
         GxWebStd.gx_hidden_field( context, "Z470AperSts", StringUtil.RTrim( Z470AperSts));
         GxWebStd.gx_hidden_field( context, "Z457AperSaldo", StringUtil.LTrim( StringUtil.NToC( Z457AperSaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z467AperReponer", StringUtil.LTrim( StringUtil.NToC( Z467AperReponer, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z471AperTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z471AperTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z458AperMonDsc", StringUtil.RTrim( Z458AperMonDsc));
         GxWebStd.gx_hidden_field( context, "Z456AperImpTotal", StringUtil.LTrim( StringUtil.NToC( Z456AperImpTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z472AperTMovDsc", StringUtil.RTrim( Z472AperTMovDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Apermoncod( )
      {
         /* Using cursor T004Z21 */
         pr_default.execute(19, new Object[] {A364AperMonCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "APERMONCOD");
            AnyError = 1;
            GX_FocusControl = edtAperMonCod_Internalname;
         }
         A458AperMonDsc = T004Z21_A458AperMonDsc[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A458AperMonDsc", StringUtil.RTrim( A458AperMonDsc));
      }

      public void Valid_Aperforcod( )
      {
         /* Using cursor T004Z26 */
         pr_default.execute(24, new Object[] {A363AperForCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "APERFORCOD");
            AnyError = 1;
            GX_FocusControl = edtAperForCod_Internalname;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Apercueban( )
      {
         n361AperBanCod = false;
         n362AperCueBan = false;
         /* Using cursor T004Z27 */
         pr_default.execute(25, new Object[] {n361AperBanCod, A361AperBanCod, n362AperCueBan, A362AperCueBan});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A361AperBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A362AperCueBan)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Caja Chica Banco'.", "ForeignKeyNotFound", 1, "APERCUEBAN");
               AnyError = 1;
               GX_FocusControl = edtAperBanCod_Internalname;
            }
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Apertmov( )
      {
         n360AperTmov = false;
         /* Using cursor T004Z22 */
         pr_default.execute(20, new Object[] {n360AperTmov, A360AperTmov});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A360AperTmov) ) )
            {
               GX_msglist.addItem("No existe 'Sub Apertura Caja Movimiento'.", "ForeignKeyNotFound", 1, "APERTMOV");
               AnyError = 1;
               GX_FocusControl = edtAperTmov_Internalname;
            }
         }
         A472AperTMovDsc = T004Z22_A472AperTMovDsc[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A472AperTMovDsc", StringUtil.RTrim( A472AperTMovDsc));
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
         setEventMetadata("VALID_CAJCOD","{handler:'Valid_Cajcod',iparms:[{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CAJCOD",",oparms:[]}");
         setEventMetadata("VALID_APERCAJCOD","{handler:'Valid_Apercajcod',iparms:[{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'},{av:'A359AperCajCod',fld:'APERCAJCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_APERCAJCOD",",oparms:[{av:'A441AperCajFec',fld:'APERCAJFEC',pic:''},{av:'A364AperMonCod',fld:'APERMONCOD',pic:'ZZZZZ9'},{av:'A363AperForCod',fld:'APERFORCOD',pic:'ZZZZZ9'},{av:'A361AperBanCod',fld:'APERBANCOD',pic:'ZZZZZ9'},{av:'A362AperCueBan',fld:'APERCUEBAN',pic:''},{av:'A442AperCheque',fld:'APERCHEQUE',pic:''},{av:'A455AperImporte',fld:'APERIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A473AperTope',fld:'APERTOPE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A360AperTmov',fld:'APERTMOV',pic:'ZZZZZ9'},{av:'A440AperBanReg',fld:'APERBANREG',pic:''},{av:'A470AperSts',fld:'APERSTS',pic:''},{av:'A457AperSaldo',fld:'APERSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A467AperReponer',fld:'APERREPONER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A471AperTItem',fld:'APERTITEM',pic:'ZZZZZ9'},{av:'A458AperMonDsc',fld:'APERMONDSC',pic:''},{av:'A456AperImpTotal',fld:'APERIMPTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A472AperTMovDsc',fld:'APERTMOVDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z358CajCod'},{av:'Z359AperCajCod'},{av:'Z441AperCajFec'},{av:'Z364AperMonCod'},{av:'Z363AperForCod'},{av:'Z361AperBanCod'},{av:'Z362AperCueBan'},{av:'Z442AperCheque'},{av:'Z455AperImporte'},{av:'Z473AperTope'},{av:'Z360AperTmov'},{av:'Z440AperBanReg'},{av:'Z470AperSts'},{av:'Z457AperSaldo'},{av:'Z467AperReponer'},{av:'Z471AperTItem'},{av:'Z458AperMonDsc'},{av:'Z456AperImpTotal'},{av:'Z472AperTMovDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_APERCAJFEC","{handler:'Valid_Apercajfec',iparms:[]");
         setEventMetadata("VALID_APERCAJFEC",",oparms:[]}");
         setEventMetadata("VALID_APERMONCOD","{handler:'Valid_Apermoncod',iparms:[{av:'A364AperMonCod',fld:'APERMONCOD',pic:'ZZZZZ9'},{av:'A458AperMonDsc',fld:'APERMONDSC',pic:''}]");
         setEventMetadata("VALID_APERMONCOD",",oparms:[{av:'A458AperMonDsc',fld:'APERMONDSC',pic:''}]}");
         setEventMetadata("VALID_APERFORCOD","{handler:'Valid_Aperforcod',iparms:[{av:'A363AperForCod',fld:'APERFORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_APERFORCOD",",oparms:[]}");
         setEventMetadata("VALID_APERBANCOD","{handler:'Valid_Aperbancod',iparms:[]");
         setEventMetadata("VALID_APERBANCOD",",oparms:[]}");
         setEventMetadata("VALID_APERCUEBAN","{handler:'Valid_Apercueban',iparms:[{av:'A361AperBanCod',fld:'APERBANCOD',pic:'ZZZZZ9'},{av:'A362AperCueBan',fld:'APERCUEBAN',pic:''}]");
         setEventMetadata("VALID_APERCUEBAN",",oparms:[]}");
         setEventMetadata("VALID_APERIMPORTE","{handler:'Valid_Aperimporte',iparms:[]");
         setEventMetadata("VALID_APERIMPORTE",",oparms:[]}");
         setEventMetadata("VALID_APERTMOV","{handler:'Valid_Apertmov',iparms:[{av:'A360AperTmov',fld:'APERTMOV',pic:'ZZZZZ9'},{av:'A472AperTMovDsc',fld:'APERTMOVDSC',pic:''}]");
         setEventMetadata("VALID_APERTMOV",",oparms:[{av:'A472AperTMovDsc',fld:'APERTMOVDSC',pic:''}]}");
         setEventMetadata("VALID_APERSALDO","{handler:'Valid_Apersaldo',iparms:[]");
         setEventMetadata("VALID_APERSALDO",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(19);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z359AperCajCod = "";
         Z441AperCajFec = DateTime.MinValue;
         Z442AperCheque = "";
         Z440AperBanReg = "";
         Z470AperSts = "";
         Z362AperCueBan = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A362AperCueBan = "";
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
         A359AperCajCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A441AperCajFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A442AperCheque = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A440AperBanReg = "";
         lblTextblock13_Jsonclick = "";
         A470AperSts = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         A472AperTMovDsc = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         A458AperMonDsc = "";
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
         Z458AperMonDsc = "";
         Z472AperTMovDsc = "";
         T004Z9_A359AperCajCod = new string[] {""} ;
         T004Z9_A441AperCajFec = new DateTime[] {DateTime.MinValue} ;
         T004Z9_A442AperCheque = new string[] {""} ;
         T004Z9_A455AperImporte = new decimal[1] ;
         T004Z9_A473AperTope = new decimal[1] ;
         T004Z9_A440AperBanReg = new string[] {""} ;
         T004Z9_n440AperBanReg = new bool[] {false} ;
         T004Z9_A470AperSts = new string[] {""} ;
         T004Z9_A457AperSaldo = new decimal[1] ;
         T004Z9_A467AperReponer = new decimal[1] ;
         T004Z9_A471AperTItem = new int[1] ;
         T004Z9_A472AperTMovDsc = new string[] {""} ;
         T004Z9_A458AperMonDsc = new string[] {""} ;
         T004Z9_A358CajCod = new int[1] ;
         T004Z9_A364AperMonCod = new int[1] ;
         T004Z9_A363AperForCod = new int[1] ;
         T004Z9_A361AperBanCod = new int[1] ;
         T004Z9_n361AperBanCod = new bool[] {false} ;
         T004Z9_A362AperCueBan = new string[] {""} ;
         T004Z9_n362AperCueBan = new bool[] {false} ;
         T004Z9_A360AperTmov = new int[1] ;
         T004Z9_n360AperTmov = new bool[] {false} ;
         T004Z4_A358CajCod = new int[1] ;
         T004Z5_A458AperMonDsc = new string[] {""} ;
         T004Z6_A363AperForCod = new int[1] ;
         T004Z7_A361AperBanCod = new int[1] ;
         T004Z7_n361AperBanCod = new bool[] {false} ;
         T004Z8_A472AperTMovDsc = new string[] {""} ;
         T004Z10_A358CajCod = new int[1] ;
         T004Z11_A458AperMonDsc = new string[] {""} ;
         T004Z12_A363AperForCod = new int[1] ;
         T004Z13_A361AperBanCod = new int[1] ;
         T004Z13_n361AperBanCod = new bool[] {false} ;
         T004Z14_A472AperTMovDsc = new string[] {""} ;
         T004Z15_A358CajCod = new int[1] ;
         T004Z15_A359AperCajCod = new string[] {""} ;
         T004Z3_A359AperCajCod = new string[] {""} ;
         T004Z3_A441AperCajFec = new DateTime[] {DateTime.MinValue} ;
         T004Z3_A442AperCheque = new string[] {""} ;
         T004Z3_A455AperImporte = new decimal[1] ;
         T004Z3_A473AperTope = new decimal[1] ;
         T004Z3_A440AperBanReg = new string[] {""} ;
         T004Z3_n440AperBanReg = new bool[] {false} ;
         T004Z3_A470AperSts = new string[] {""} ;
         T004Z3_A457AperSaldo = new decimal[1] ;
         T004Z3_A467AperReponer = new decimal[1] ;
         T004Z3_A471AperTItem = new int[1] ;
         T004Z3_A358CajCod = new int[1] ;
         T004Z3_A364AperMonCod = new int[1] ;
         T004Z3_A363AperForCod = new int[1] ;
         T004Z3_A361AperBanCod = new int[1] ;
         T004Z3_n361AperBanCod = new bool[] {false} ;
         T004Z3_A362AperCueBan = new string[] {""} ;
         T004Z3_n362AperCueBan = new bool[] {false} ;
         T004Z3_A360AperTmov = new int[1] ;
         T004Z3_n360AperTmov = new bool[] {false} ;
         sMode166 = "";
         T004Z16_A358CajCod = new int[1] ;
         T004Z16_A359AperCajCod = new string[] {""} ;
         T004Z17_A358CajCod = new int[1] ;
         T004Z17_A359AperCajCod = new string[] {""} ;
         T004Z2_A359AperCajCod = new string[] {""} ;
         T004Z2_A441AperCajFec = new DateTime[] {DateTime.MinValue} ;
         T004Z2_A442AperCheque = new string[] {""} ;
         T004Z2_A455AperImporte = new decimal[1] ;
         T004Z2_A473AperTope = new decimal[1] ;
         T004Z2_A440AperBanReg = new string[] {""} ;
         T004Z2_n440AperBanReg = new bool[] {false} ;
         T004Z2_A470AperSts = new string[] {""} ;
         T004Z2_A457AperSaldo = new decimal[1] ;
         T004Z2_A467AperReponer = new decimal[1] ;
         T004Z2_A471AperTItem = new int[1] ;
         T004Z2_A358CajCod = new int[1] ;
         T004Z2_A364AperMonCod = new int[1] ;
         T004Z2_A363AperForCod = new int[1] ;
         T004Z2_A361AperBanCod = new int[1] ;
         T004Z2_n361AperBanCod = new bool[] {false} ;
         T004Z2_A362AperCueBan = new string[] {""} ;
         T004Z2_n362AperCueBan = new bool[] {false} ;
         T004Z2_A360AperTmov = new int[1] ;
         T004Z2_n360AperTmov = new bool[] {false} ;
         T004Z21_A458AperMonDsc = new string[] {""} ;
         T004Z22_A472AperTMovDsc = new string[] {""} ;
         T004Z23_A358CajCod = new int[1] ;
         T004Z23_A359AperCajCod = new string[] {""} ;
         T004Z23_A373AperCajItem = new int[1] ;
         T004Z24_A358CajCod = new int[1] ;
         T004Z24_A359AperCajCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004Z25_A358CajCod = new int[1] ;
         ZZ359AperCajCod = "";
         ZZ441AperCajFec = DateTime.MinValue;
         ZZ362AperCueBan = "";
         ZZ442AperCheque = "";
         ZZ440AperBanReg = "";
         ZZ470AperSts = "";
         ZZ458AperMonDsc = "";
         ZZ472AperTMovDsc = "";
         T004Z26_A363AperForCod = new int[1] ;
         T004Z27_A361AperBanCod = new int[1] ;
         T004Z27_n361AperBanCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsaperturacaja__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsaperturacaja__default(),
            new Object[][] {
                new Object[] {
               T004Z2_A359AperCajCod, T004Z2_A441AperCajFec, T004Z2_A442AperCheque, T004Z2_A455AperImporte, T004Z2_A473AperTope, T004Z2_A440AperBanReg, T004Z2_n440AperBanReg, T004Z2_A470AperSts, T004Z2_A457AperSaldo, T004Z2_A467AperReponer,
               T004Z2_A471AperTItem, T004Z2_A358CajCod, T004Z2_A364AperMonCod, T004Z2_A363AperForCod, T004Z2_A361AperBanCod, T004Z2_n361AperBanCod, T004Z2_A362AperCueBan, T004Z2_n362AperCueBan, T004Z2_A360AperTmov, T004Z2_n360AperTmov
               }
               , new Object[] {
               T004Z3_A359AperCajCod, T004Z3_A441AperCajFec, T004Z3_A442AperCheque, T004Z3_A455AperImporte, T004Z3_A473AperTope, T004Z3_A440AperBanReg, T004Z3_n440AperBanReg, T004Z3_A470AperSts, T004Z3_A457AperSaldo, T004Z3_A467AperReponer,
               T004Z3_A471AperTItem, T004Z3_A358CajCod, T004Z3_A364AperMonCod, T004Z3_A363AperForCod, T004Z3_A361AperBanCod, T004Z3_n361AperBanCod, T004Z3_A362AperCueBan, T004Z3_n362AperCueBan, T004Z3_A360AperTmov, T004Z3_n360AperTmov
               }
               , new Object[] {
               T004Z4_A358CajCod
               }
               , new Object[] {
               T004Z5_A458AperMonDsc
               }
               , new Object[] {
               T004Z6_A363AperForCod
               }
               , new Object[] {
               T004Z7_A361AperBanCod
               }
               , new Object[] {
               T004Z8_A472AperTMovDsc
               }
               , new Object[] {
               T004Z9_A359AperCajCod, T004Z9_A441AperCajFec, T004Z9_A442AperCheque, T004Z9_A455AperImporte, T004Z9_A473AperTope, T004Z9_A440AperBanReg, T004Z9_n440AperBanReg, T004Z9_A470AperSts, T004Z9_A457AperSaldo, T004Z9_A467AperReponer,
               T004Z9_A471AperTItem, T004Z9_A472AperTMovDsc, T004Z9_A458AperMonDsc, T004Z9_A358CajCod, T004Z9_A364AperMonCod, T004Z9_A363AperForCod, T004Z9_A361AperBanCod, T004Z9_n361AperBanCod, T004Z9_A362AperCueBan, T004Z9_n362AperCueBan,
               T004Z9_A360AperTmov, T004Z9_n360AperTmov
               }
               , new Object[] {
               T004Z10_A358CajCod
               }
               , new Object[] {
               T004Z11_A458AperMonDsc
               }
               , new Object[] {
               T004Z12_A363AperForCod
               }
               , new Object[] {
               T004Z13_A361AperBanCod
               }
               , new Object[] {
               T004Z14_A472AperTMovDsc
               }
               , new Object[] {
               T004Z15_A358CajCod, T004Z15_A359AperCajCod
               }
               , new Object[] {
               T004Z16_A358CajCod, T004Z16_A359AperCajCod
               }
               , new Object[] {
               T004Z17_A358CajCod, T004Z17_A359AperCajCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004Z21_A458AperMonDsc
               }
               , new Object[] {
               T004Z22_A472AperTMovDsc
               }
               , new Object[] {
               T004Z23_A358CajCod, T004Z23_A359AperCajCod, T004Z23_A373AperCajItem
               }
               , new Object[] {
               T004Z24_A358CajCod, T004Z24_A359AperCajCod
               }
               , new Object[] {
               T004Z25_A358CajCod
               }
               , new Object[] {
               T004Z26_A363AperForCod
               }
               , new Object[] {
               T004Z27_A361AperBanCod
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
      private short RcdFound166 ;
      private short nIsDirty_166 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z358CajCod ;
      private int Z471AperTItem ;
      private int Z364AperMonCod ;
      private int Z363AperForCod ;
      private int Z361AperBanCod ;
      private int Z360AperTmov ;
      private int A358CajCod ;
      private int A364AperMonCod ;
      private int A363AperForCod ;
      private int A361AperBanCod ;
      private int A360AperTmov ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCajCod_Enabled ;
      private int edtAperCajCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtAperCajFec_Enabled ;
      private int edtAperMonCod_Enabled ;
      private int edtAperForCod_Enabled ;
      private int edtAperBanCod_Enabled ;
      private int edtAperCueBan_Enabled ;
      private int edtAperCheque_Enabled ;
      private int edtAperImporte_Enabled ;
      private int edtAperTope_Enabled ;
      private int edtAperTmov_Enabled ;
      private int edtAperBanReg_Enabled ;
      private int edtAperSts_Enabled ;
      private int edtAperSaldo_Enabled ;
      private int edtAperReponer_Enabled ;
      private int A471AperTItem ;
      private int edtAperTItem_Enabled ;
      private int edtAperTMovDsc_Enabled ;
      private int edtAperImpTotal_Enabled ;
      private int edtAperMonDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ358CajCod ;
      private int ZZ364AperMonCod ;
      private int ZZ363AperForCod ;
      private int ZZ361AperBanCod ;
      private int ZZ360AperTmov ;
      private int ZZ471AperTItem ;
      private decimal Z455AperImporte ;
      private decimal Z473AperTope ;
      private decimal Z457AperSaldo ;
      private decimal Z467AperReponer ;
      private decimal A455AperImporte ;
      private decimal A473AperTope ;
      private decimal A457AperSaldo ;
      private decimal A467AperReponer ;
      private decimal A456AperImpTotal ;
      private decimal Z456AperImpTotal ;
      private decimal ZZ455AperImporte ;
      private decimal ZZ473AperTope ;
      private decimal ZZ457AperSaldo ;
      private decimal ZZ467AperReponer ;
      private decimal ZZ456AperImpTotal ;
      private string sPrefix ;
      private string Z359AperCajCod ;
      private string Z442AperCheque ;
      private string Z440AperBanReg ;
      private string Z470AperSts ;
      private string Z362AperCueBan ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A362AperCueBan ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCajCod_Internalname ;
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
      private string edtCajCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAperCajCod_Internalname ;
      private string A359AperCajCod ;
      private string edtAperCajCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtAperCajFec_Internalname ;
      private string edtAperCajFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAperMonCod_Internalname ;
      private string edtAperMonCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtAperForCod_Internalname ;
      private string edtAperForCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtAperBanCod_Internalname ;
      private string edtAperBanCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtAperCueBan_Internalname ;
      private string edtAperCueBan_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtAperCheque_Internalname ;
      private string A442AperCheque ;
      private string edtAperCheque_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtAperImporte_Internalname ;
      private string edtAperImporte_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtAperTope_Internalname ;
      private string edtAperTope_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtAperTmov_Internalname ;
      private string edtAperTmov_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtAperBanReg_Internalname ;
      private string A440AperBanReg ;
      private string edtAperBanReg_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtAperSts_Internalname ;
      private string A470AperSts ;
      private string edtAperSts_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtAperSaldo_Internalname ;
      private string edtAperSaldo_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtAperReponer_Internalname ;
      private string edtAperReponer_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtAperTItem_Internalname ;
      private string edtAperTItem_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtAperTMovDsc_Internalname ;
      private string A472AperTMovDsc ;
      private string edtAperTMovDsc_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtAperImpTotal_Internalname ;
      private string edtAperImpTotal_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtAperMonDsc_Internalname ;
      private string A458AperMonDsc ;
      private string edtAperMonDsc_Jsonclick ;
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
      private string Z458AperMonDsc ;
      private string Z472AperTMovDsc ;
      private string sMode166 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ359AperCajCod ;
      private string ZZ362AperCueBan ;
      private string ZZ442AperCheque ;
      private string ZZ440AperBanReg ;
      private string ZZ470AperSts ;
      private string ZZ458AperMonDsc ;
      private string ZZ472AperTMovDsc ;
      private DateTime Z441AperCajFec ;
      private DateTime A441AperCajFec ;
      private DateTime ZZ441AperCajFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n361AperBanCod ;
      private bool n362AperCueBan ;
      private bool n360AperTmov ;
      private bool wbErr ;
      private bool n440AperBanReg ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004Z9_A359AperCajCod ;
      private DateTime[] T004Z9_A441AperCajFec ;
      private string[] T004Z9_A442AperCheque ;
      private decimal[] T004Z9_A455AperImporte ;
      private decimal[] T004Z9_A473AperTope ;
      private string[] T004Z9_A440AperBanReg ;
      private bool[] T004Z9_n440AperBanReg ;
      private string[] T004Z9_A470AperSts ;
      private decimal[] T004Z9_A457AperSaldo ;
      private decimal[] T004Z9_A467AperReponer ;
      private int[] T004Z9_A471AperTItem ;
      private string[] T004Z9_A472AperTMovDsc ;
      private string[] T004Z9_A458AperMonDsc ;
      private int[] T004Z9_A358CajCod ;
      private int[] T004Z9_A364AperMonCod ;
      private int[] T004Z9_A363AperForCod ;
      private int[] T004Z9_A361AperBanCod ;
      private bool[] T004Z9_n361AperBanCod ;
      private string[] T004Z9_A362AperCueBan ;
      private bool[] T004Z9_n362AperCueBan ;
      private int[] T004Z9_A360AperTmov ;
      private bool[] T004Z9_n360AperTmov ;
      private int[] T004Z4_A358CajCod ;
      private string[] T004Z5_A458AperMonDsc ;
      private int[] T004Z6_A363AperForCod ;
      private int[] T004Z7_A361AperBanCod ;
      private bool[] T004Z7_n361AperBanCod ;
      private string[] T004Z8_A472AperTMovDsc ;
      private int[] T004Z10_A358CajCod ;
      private string[] T004Z11_A458AperMonDsc ;
      private int[] T004Z12_A363AperForCod ;
      private int[] T004Z13_A361AperBanCod ;
      private bool[] T004Z13_n361AperBanCod ;
      private string[] T004Z14_A472AperTMovDsc ;
      private int[] T004Z15_A358CajCod ;
      private string[] T004Z15_A359AperCajCod ;
      private string[] T004Z3_A359AperCajCod ;
      private DateTime[] T004Z3_A441AperCajFec ;
      private string[] T004Z3_A442AperCheque ;
      private decimal[] T004Z3_A455AperImporte ;
      private decimal[] T004Z3_A473AperTope ;
      private string[] T004Z3_A440AperBanReg ;
      private bool[] T004Z3_n440AperBanReg ;
      private string[] T004Z3_A470AperSts ;
      private decimal[] T004Z3_A457AperSaldo ;
      private decimal[] T004Z3_A467AperReponer ;
      private int[] T004Z3_A471AperTItem ;
      private int[] T004Z3_A358CajCod ;
      private int[] T004Z3_A364AperMonCod ;
      private int[] T004Z3_A363AperForCod ;
      private int[] T004Z3_A361AperBanCod ;
      private bool[] T004Z3_n361AperBanCod ;
      private string[] T004Z3_A362AperCueBan ;
      private bool[] T004Z3_n362AperCueBan ;
      private int[] T004Z3_A360AperTmov ;
      private bool[] T004Z3_n360AperTmov ;
      private int[] T004Z16_A358CajCod ;
      private string[] T004Z16_A359AperCajCod ;
      private int[] T004Z17_A358CajCod ;
      private string[] T004Z17_A359AperCajCod ;
      private string[] T004Z2_A359AperCajCod ;
      private DateTime[] T004Z2_A441AperCajFec ;
      private string[] T004Z2_A442AperCheque ;
      private decimal[] T004Z2_A455AperImporte ;
      private decimal[] T004Z2_A473AperTope ;
      private string[] T004Z2_A440AperBanReg ;
      private bool[] T004Z2_n440AperBanReg ;
      private string[] T004Z2_A470AperSts ;
      private decimal[] T004Z2_A457AperSaldo ;
      private decimal[] T004Z2_A467AperReponer ;
      private int[] T004Z2_A471AperTItem ;
      private int[] T004Z2_A358CajCod ;
      private int[] T004Z2_A364AperMonCod ;
      private int[] T004Z2_A363AperForCod ;
      private int[] T004Z2_A361AperBanCod ;
      private bool[] T004Z2_n361AperBanCod ;
      private string[] T004Z2_A362AperCueBan ;
      private bool[] T004Z2_n362AperCueBan ;
      private int[] T004Z2_A360AperTmov ;
      private bool[] T004Z2_n360AperTmov ;
      private string[] T004Z21_A458AperMonDsc ;
      private string[] T004Z22_A472AperTMovDsc ;
      private int[] T004Z23_A358CajCod ;
      private string[] T004Z23_A359AperCajCod ;
      private int[] T004Z23_A373AperCajItem ;
      private int[] T004Z24_A358CajCod ;
      private string[] T004Z24_A359AperCajCod ;
      private int[] T004Z25_A358CajCod ;
      private int[] T004Z26_A363AperForCod ;
      private int[] T004Z27_A361AperBanCod ;
      private bool[] T004Z27_n361AperBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsaperturacaja__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsaperturacaja__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004Z9;
        prmT004Z9 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z4;
        prmT004Z4 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z5;
        prmT004Z5 = new Object[] {
        new ParDef("@AperMonCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z6;
        prmT004Z6 = new Object[] {
        new ParDef("@AperForCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z7;
        prmT004Z7 = new Object[] {
        new ParDef("@AperBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperCueBan",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT004Z8;
        prmT004Z8 = new Object[] {
        new ParDef("@AperTmov",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT004Z10;
        prmT004Z10 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z11;
        prmT004Z11 = new Object[] {
        new ParDef("@AperMonCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z12;
        prmT004Z12 = new Object[] {
        new ParDef("@AperForCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z13;
        prmT004Z13 = new Object[] {
        new ParDef("@AperBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperCueBan",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT004Z14;
        prmT004Z14 = new Object[] {
        new ParDef("@AperTmov",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT004Z15;
        prmT004Z15 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z3;
        prmT004Z3 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z16;
        prmT004Z16 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z17;
        prmT004Z17 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z2;
        prmT004Z2 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z18;
        prmT004Z18 = new Object[] {
        new ParDef("@AperCajCod",GXType.NChar,10,0) ,
        new ParDef("@AperCajFec",GXType.Date,8,0) ,
        new ParDef("@AperCheque",GXType.NChar,20,0) ,
        new ParDef("@AperImporte",GXType.Decimal,15,2) ,
        new ParDef("@AperTope",GXType.Decimal,15,2) ,
        new ParDef("@AperBanReg",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@AperSts",GXType.NChar,1,0) ,
        new ParDef("@AperSaldo",GXType.Decimal,15,2) ,
        new ParDef("@AperReponer",GXType.Decimal,15,2) ,
        new ParDef("@AperTItem",GXType.Int32,6,0) ,
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperMonCod",GXType.Int32,6,0) ,
        new ParDef("@AperForCod",GXType.Int32,6,0) ,
        new ParDef("@AperBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperCueBan",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@AperTmov",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT004Z19;
        prmT004Z19 = new Object[] {
        new ParDef("@AperCajFec",GXType.Date,8,0) ,
        new ParDef("@AperCheque",GXType.NChar,20,0) ,
        new ParDef("@AperImporte",GXType.Decimal,15,2) ,
        new ParDef("@AperTope",GXType.Decimal,15,2) ,
        new ParDef("@AperBanReg",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@AperSts",GXType.NChar,1,0) ,
        new ParDef("@AperSaldo",GXType.Decimal,15,2) ,
        new ParDef("@AperReponer",GXType.Decimal,15,2) ,
        new ParDef("@AperTItem",GXType.Int32,6,0) ,
        new ParDef("@AperMonCod",GXType.Int32,6,0) ,
        new ParDef("@AperForCod",GXType.Int32,6,0) ,
        new ParDef("@AperBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperCueBan",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@AperTmov",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z20;
        prmT004Z20 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z23;
        prmT004Z23 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@AperCajCod",GXType.NChar,10,0)
        };
        Object[] prmT004Z24;
        prmT004Z24 = new Object[] {
        };
        Object[] prmT004Z25;
        prmT004Z25 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z21;
        prmT004Z21 = new Object[] {
        new ParDef("@AperMonCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z26;
        prmT004Z26 = new Object[] {
        new ParDef("@AperForCod",GXType.Int32,6,0)
        };
        Object[] prmT004Z27;
        prmT004Z27 = new Object[] {
        new ParDef("@AperBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AperCueBan",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT004Z22;
        prmT004Z22 = new Object[] {
        new ParDef("@AperTmov",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T004Z2", "SELECT [AperCajCod], [AperCajFec], [AperCheque], [AperImporte], [AperTope], [AperBanReg], [AperSts], [AperSaldo], [AperReponer], [AperTItem], [CajCod], [AperMonCod] AS AperMonCod, [AperForCod] AS AperForCod, [AperBanCod] AS AperBanCod, [AperCueBan] AS AperCueBan, [AperTmov] AS AperTmov FROM [TSAPERTURACAJA] WITH (UPDLOCK) WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z3", "SELECT [AperCajCod], [AperCajFec], [AperCheque], [AperImporte], [AperTope], [AperBanReg], [AperSts], [AperSaldo], [AperReponer], [AperTItem], [CajCod], [AperMonCod] AS AperMonCod, [AperForCod] AS AperForCod, [AperBanCod] AS AperBanCod, [AperCueBan] AS AperCueBan, [AperTmov] AS AperTmov FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z4", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z5", "SELECT [MonDsc] AS AperMonDsc FROM [CMONEDAS] WHERE [MonCod] = @AperMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z6", "SELECT [ForCod] AS AperForCod FROM [CFORMAPAGO] WHERE [ForCod] = @AperForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z7", "SELECT [BanCod] AS AperBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @AperBanCod AND [CBCod] = @AperCueBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z8", "SELECT [ConBDsc] AS AperTMovDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AperTmov ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z9", "SELECT TM1.[AperCajCod], TM1.[AperCajFec], TM1.[AperCheque], TM1.[AperImporte], TM1.[AperTope], TM1.[AperBanReg], TM1.[AperSts], TM1.[AperSaldo], TM1.[AperReponer], TM1.[AperTItem], T3.[ConBDsc] AS AperTMovDsc, T2.[MonDsc] AS AperMonDsc, TM1.[CajCod], TM1.[AperMonCod] AS AperMonCod, TM1.[AperForCod] AS AperForCod, TM1.[AperBanCod] AS AperBanCod, TM1.[AperCueBan] AS AperCueBan, TM1.[AperTmov] AS AperTmov FROM (([TSAPERTURACAJA] TM1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = TM1.[AperMonCod]) LEFT JOIN [TSCONCEPTOBANCOS] T3 ON T3.[ConBCod] = TM1.[AperTmov]) WHERE TM1.[CajCod] = @CajCod and TM1.[AperCajCod] = @AperCajCod ORDER BY TM1.[CajCod], TM1.[AperCajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z10", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z11", "SELECT [MonDsc] AS AperMonDsc FROM [CMONEDAS] WHERE [MonCod] = @AperMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z12", "SELECT [ForCod] AS AperForCod FROM [CFORMAPAGO] WHERE [ForCod] = @AperForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z13", "SELECT [BanCod] AS AperBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @AperBanCod AND [CBCod] = @AperCueBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z14", "SELECT [ConBDsc] AS AperTMovDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AperTmov ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z15", "SELECT [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z16", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE ( [CajCod] > @CajCod or [CajCod] = @CajCod and [AperCajCod] > @AperCajCod) ORDER BY [CajCod], [AperCajCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004Z17", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE ( [CajCod] < @CajCod or [CajCod] = @CajCod and [AperCajCod] < @AperCajCod) ORDER BY [CajCod] DESC, [AperCajCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004Z18", "INSERT INTO [TSAPERTURACAJA]([AperCajCod], [AperCajFec], [AperCheque], [AperImporte], [AperTope], [AperBanReg], [AperSts], [AperSaldo], [AperReponer], [AperTItem], [CajCod], [AperMonCod], [AperForCod], [AperBanCod], [AperCueBan], [AperTmov]) VALUES(@AperCajCod, @AperCajFec, @AperCheque, @AperImporte, @AperTope, @AperBanReg, @AperSts, @AperSaldo, @AperReponer, @AperTItem, @CajCod, @AperMonCod, @AperForCod, @AperBanCod, @AperCueBan, @AperTmov)", GxErrorMask.GX_NOMASK,prmT004Z18)
           ,new CursorDef("T004Z19", "UPDATE [TSAPERTURACAJA] SET [AperCajFec]=@AperCajFec, [AperCheque]=@AperCheque, [AperImporte]=@AperImporte, [AperTope]=@AperTope, [AperBanReg]=@AperBanReg, [AperSts]=@AperSts, [AperSaldo]=@AperSaldo, [AperReponer]=@AperReponer, [AperTItem]=@AperTItem, [AperMonCod]=@AperMonCod, [AperForCod]=@AperForCod, [AperBanCod]=@AperBanCod, [AperCueBan]=@AperCueBan, [AperTmov]=@AperTmov  WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod", GxErrorMask.GX_NOMASK,prmT004Z19)
           ,new CursorDef("T004Z20", "DELETE FROM [TSAPERTURACAJA]  WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod", GxErrorMask.GX_NOMASK,prmT004Z20)
           ,new CursorDef("T004Z21", "SELECT [MonDsc] AS AperMonDsc FROM [CMONEDAS] WHERE [MonCod] = @AperMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z22", "SELECT [ConBDsc] AS AperTMovDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AperTmov ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z23", "SELECT TOP 1 [CajCod], [AperCajCod], [AperCajItem] FROM [TSCAJAREPOSICION] WHERE [CajCod] = @CajCod AND [AperCajCod] = @AperCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004Z24", "SELECT [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] ORDER BY [CajCod], [AperCajCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z25", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z26", "SELECT [ForCod] AS AperForCod FROM [CFORMAPAGO] WHERE [ForCod] = @AperForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Z27", "SELECT [BanCod] AS AperBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @AperBanCod AND [CBCod] = @AperCueBan ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Z27,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
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
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
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
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
