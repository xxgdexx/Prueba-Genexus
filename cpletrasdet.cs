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
   public class cpletrasdet : GXDataArea
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
            A265LetPLetCod = GetPar( "LetPLetCod");
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A265LetPLetCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A269LetPTipCod = GetPar( "LetPTipCod");
            AssignAttri("", false, "A269LetPTipCod", A269LetPTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A269LetPTipCod) ;
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

      public cpletrasdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpletrasdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLETRASDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Canje", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPLetCod_Internalname, StringUtil.RTrim( A265LetPLetCod), StringUtil.RTrim( context.localUtil.Format( A265LetPLetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPLetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPLetCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A268LetPItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetPItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A268LetPItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A268LetPItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Tipo D/L", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPTipo_Internalname, StringUtil.RTrim( A1146LetPTipo), StringUtil.RTrim( context.localUtil.Format( A1146LetPTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Tipo Documento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPTipCod_Internalname, StringUtil.RTrim( A269LetPTipCod), StringUtil.RTrim( context.localUtil.Format( A269LetPTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "N° Documento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPDocNum_Internalname, StringUtil.RTrim( A1131LetPDocNum), StringUtil.RTrim( context.localUtil.Format( A1131LetPDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPDocNum_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Dias", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1130LetPDias), 4, 0, ".", "")), StringUtil.LTrim( ((edtLetPDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A1130LetPDias), "ZZZ9") : context.localUtil.Format( (decimal)(A1130LetPDias), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPDias_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Fecha", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLetPFecLet_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLetPFecLet_Internalname, context.localUtil.Format(A1134LetPFecLet, "99/99/99"), context.localUtil.Format( A1134LetPFecLet, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPFecLet_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPFecLet_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRASDET.htm");
         GxWebStd.gx_bitmap( context, edtLetPFecLet_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLetPFecLet_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Fecha Vcto", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLetPFecVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLetPFecVcto_Internalname, context.localUtil.Format(A1135LetPFecVcto, "99/99/99"), context.localUtil.Format( A1135LetPFecVcto, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPFecVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPFecVcto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRASDET.htm");
         GxWebStd.gx_bitmap( context, edtLetPFecVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLetPFecVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Girador", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPGirador_Internalname, StringUtil.RTrim( A1137LetPGirador), StringUtil.RTrim( context.localUtil.Format( A1137LetPGirador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPGirador_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPGirador_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Lugar", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPLugar_Internalname, StringUtil.RTrim( A1141LetPLugar), StringUtil.RTrim( context.localUtil.Format( A1141LetPLugar, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPLugar_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPLugar_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Importe Documento", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPImpDet_Internalname, StringUtil.LTrim( StringUtil.NToC( A1138LetPImpDet, 17, 2, ".", "")), StringUtil.LTrim( ((edtLetPImpDet_Enabled!=0) ? context.localUtil.Format( A1138LetPImpDet, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1138LetPImpDet, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPImpDet_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPImpDet_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Codigo Banco", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1127LetPBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetPBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1127LetPBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1127LetPBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "N° Cuenta", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPCBCod_Internalname, StringUtil.RTrim( A1129LetPCBCod), StringUtil.RTrim( context.localUtil.Format( A1129LetPCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Seccion Bancaria", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPSec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1142LetPSec), 6, 0, ".", "")), StringUtil.LTrim( ((edtLetPSec_Enabled!=0) ? context.localUtil.Format( (decimal)(A1142LetPSec), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1142LetPSec), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPSec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPSec_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "N° Banco", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPBanNum_Internalname, StringUtil.RTrim( A1128LetPBanNum), StringUtil.RTrim( context.localUtil.Format( A1128LetPBanNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPBanNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPBanNum_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Proveedor", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPDPrvCod_Internalname, StringUtil.RTrim( A1133LetPDPrvCod), StringUtil.RTrim( context.localUtil.Format( A1133LetPDPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPDPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPDPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "% Letra", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLetPDPorc_Internalname, StringUtil.LTrim( StringUtil.NToC( A1132LetPDPorc, 20, 8, ".", "")), StringUtil.LTrim( ((edtLetPDPorc_Enabled!=0) ? context.localUtil.Format( A1132LetPDPorc, "ZZZ,ZZZ,ZZ9.99999999") : context.localUtil.Format( A1132LetPDPorc, "ZZZ,ZZZ,ZZ9.99999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLetPDPorc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLetPDPorc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_CPLETRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLETRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPLETRASDET.htm");
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
            Z268LetPItem = (int)(context.localUtil.CToN( cgiGet( "Z268LetPItem"), ".", ","));
            Z1146LetPTipo = cgiGet( "Z1146LetPTipo");
            Z1131LetPDocNum = cgiGet( "Z1131LetPDocNum");
            Z1130LetPDias = (short)(context.localUtil.CToN( cgiGet( "Z1130LetPDias"), ".", ","));
            Z1134LetPFecLet = context.localUtil.CToD( cgiGet( "Z1134LetPFecLet"), 0);
            Z1135LetPFecVcto = context.localUtil.CToD( cgiGet( "Z1135LetPFecVcto"), 0);
            Z1137LetPGirador = cgiGet( "Z1137LetPGirador");
            Z1141LetPLugar = cgiGet( "Z1141LetPLugar");
            Z1138LetPImpDet = context.localUtil.CToN( cgiGet( "Z1138LetPImpDet"), ".", ",");
            Z1127LetPBanCod = (int)(context.localUtil.CToN( cgiGet( "Z1127LetPBanCod"), ".", ","));
            Z1129LetPCBCod = cgiGet( "Z1129LetPCBCod");
            Z1142LetPSec = (int)(context.localUtil.CToN( cgiGet( "Z1142LetPSec"), ".", ","));
            Z1128LetPBanNum = cgiGet( "Z1128LetPBanNum");
            Z1133LetPDPrvCod = cgiGet( "Z1133LetPDPrvCod");
            Z1132LetPDPorc = context.localUtil.CToN( cgiGet( "Z1132LetPDPorc"), ".", ",");
            Z269LetPTipCod = cgiGet( "Z269LetPTipCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A265LetPLetCod = cgiGet( edtLetPLetCod_Internalname);
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPITEM");
               AnyError = 1;
               GX_FocusControl = edtLetPItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A268LetPItem = 0;
               AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
            }
            else
            {
               A268LetPItem = (int)(context.localUtil.CToN( cgiGet( edtLetPItem_Internalname), ".", ","));
               AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
            }
            A1146LetPTipo = cgiGet( edtLetPTipo_Internalname);
            AssignAttri("", false, "A1146LetPTipo", A1146LetPTipo);
            A269LetPTipCod = cgiGet( edtLetPTipCod_Internalname);
            AssignAttri("", false, "A269LetPTipCod", A269LetPTipCod);
            A1131LetPDocNum = cgiGet( edtLetPDocNum_Internalname);
            AssignAttri("", false, "A1131LetPDocNum", A1131LetPDocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPDias_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPDias_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPDIAS");
               AnyError = 1;
               GX_FocusControl = edtLetPDias_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1130LetPDias = 0;
               AssignAttri("", false, "A1130LetPDias", StringUtil.LTrimStr( (decimal)(A1130LetPDias), 4, 0));
            }
            else
            {
               A1130LetPDias = (short)(context.localUtil.CToN( cgiGet( edtLetPDias_Internalname), ".", ","));
               AssignAttri("", false, "A1130LetPDias", StringUtil.LTrimStr( (decimal)(A1130LetPDias), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtLetPFecLet_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "LETPFECLET");
               AnyError = 1;
               GX_FocusControl = edtLetPFecLet_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1134LetPFecLet = DateTime.MinValue;
               AssignAttri("", false, "A1134LetPFecLet", context.localUtil.Format(A1134LetPFecLet, "99/99/99"));
            }
            else
            {
               A1134LetPFecLet = context.localUtil.CToD( cgiGet( edtLetPFecLet_Internalname), 2);
               AssignAttri("", false, "A1134LetPFecLet", context.localUtil.Format(A1134LetPFecLet, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtLetPFecVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "LETPFECVCTO");
               AnyError = 1;
               GX_FocusControl = edtLetPFecVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1135LetPFecVcto = DateTime.MinValue;
               AssignAttri("", false, "A1135LetPFecVcto", context.localUtil.Format(A1135LetPFecVcto, "99/99/99"));
            }
            else
            {
               A1135LetPFecVcto = context.localUtil.CToD( cgiGet( edtLetPFecVcto_Internalname), 2);
               AssignAttri("", false, "A1135LetPFecVcto", context.localUtil.Format(A1135LetPFecVcto, "99/99/99"));
            }
            A1137LetPGirador = cgiGet( edtLetPGirador_Internalname);
            AssignAttri("", false, "A1137LetPGirador", A1137LetPGirador);
            A1141LetPLugar = cgiGet( edtLetPLugar_Internalname);
            AssignAttri("", false, "A1141LetPLugar", A1141LetPLugar);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPImpDet_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPImpDet_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPIMPDET");
               AnyError = 1;
               GX_FocusControl = edtLetPImpDet_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1138LetPImpDet = 0;
               AssignAttri("", false, "A1138LetPImpDet", StringUtil.LTrimStr( A1138LetPImpDet, 15, 2));
            }
            else
            {
               A1138LetPImpDet = context.localUtil.CToN( cgiGet( edtLetPImpDet_Internalname), ".", ",");
               AssignAttri("", false, "A1138LetPImpDet", StringUtil.LTrimStr( A1138LetPImpDet, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLetPBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1127LetPBanCod = 0;
               AssignAttri("", false, "A1127LetPBanCod", StringUtil.LTrimStr( (decimal)(A1127LetPBanCod), 6, 0));
            }
            else
            {
               A1127LetPBanCod = (int)(context.localUtil.CToN( cgiGet( edtLetPBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A1127LetPBanCod", StringUtil.LTrimStr( (decimal)(A1127LetPBanCod), 6, 0));
            }
            A1129LetPCBCod = cgiGet( edtLetPCBCod_Internalname);
            AssignAttri("", false, "A1129LetPCBCod", A1129LetPCBCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPSec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPSec_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPSEC");
               AnyError = 1;
               GX_FocusControl = edtLetPSec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1142LetPSec = 0;
               AssignAttri("", false, "A1142LetPSec", StringUtil.LTrimStr( (decimal)(A1142LetPSec), 6, 0));
            }
            else
            {
               A1142LetPSec = (int)(context.localUtil.CToN( cgiGet( edtLetPSec_Internalname), ".", ","));
               AssignAttri("", false, "A1142LetPSec", StringUtil.LTrimStr( (decimal)(A1142LetPSec), 6, 0));
            }
            A1128LetPBanNum = cgiGet( edtLetPBanNum_Internalname);
            AssignAttri("", false, "A1128LetPBanNum", A1128LetPBanNum);
            A1133LetPDPrvCod = cgiGet( edtLetPDPrvCod_Internalname);
            AssignAttri("", false, "A1133LetPDPrvCod", A1133LetPDPrvCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLetPDPorc_Internalname), ".", ",") < -99999999.99999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLetPDPorc_Internalname), ".", ",") > 999999999.99999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LETPDPORC");
               AnyError = 1;
               GX_FocusControl = edtLetPDPorc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1132LetPDPorc = 0;
               AssignAttri("", false, "A1132LetPDPorc", StringUtil.LTrimStr( A1132LetPDPorc, 18, 8));
            }
            else
            {
               A1132LetPDPorc = context.localUtil.CToN( cgiGet( edtLetPDPorc_Internalname), ".", ",");
               AssignAttri("", false, "A1132LetPDPorc", StringUtil.LTrimStr( A1132LetPDPorc, 18, 8));
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
               A268LetPItem = (int)(NumberUtil.Val( GetPar( "LetPItem"), "."));
               AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
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
               InitAll3B114( ) ;
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
         DisableAttributes3B114( ) ;
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

      protected void CONFIRM_3B0( )
      {
         BeforeValidate3B114( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3B114( ) ;
            }
            else
            {
               CheckExtendedTable3B114( ) ;
               if ( AnyError == 0 )
               {
                  ZM3B114( 4) ;
                  ZM3B114( 5) ;
               }
               CloseExtendedTableCursors3B114( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3B0( ) ;
         }
      }

      protected void ResetCaption3B0( )
      {
      }

      protected void ZM3B114( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1146LetPTipo = T003B3_A1146LetPTipo[0];
               Z1131LetPDocNum = T003B3_A1131LetPDocNum[0];
               Z1130LetPDias = T003B3_A1130LetPDias[0];
               Z1134LetPFecLet = T003B3_A1134LetPFecLet[0];
               Z1135LetPFecVcto = T003B3_A1135LetPFecVcto[0];
               Z1137LetPGirador = T003B3_A1137LetPGirador[0];
               Z1141LetPLugar = T003B3_A1141LetPLugar[0];
               Z1138LetPImpDet = T003B3_A1138LetPImpDet[0];
               Z1127LetPBanCod = T003B3_A1127LetPBanCod[0];
               Z1129LetPCBCod = T003B3_A1129LetPCBCod[0];
               Z1142LetPSec = T003B3_A1142LetPSec[0];
               Z1128LetPBanNum = T003B3_A1128LetPBanNum[0];
               Z1133LetPDPrvCod = T003B3_A1133LetPDPrvCod[0];
               Z1132LetPDPorc = T003B3_A1132LetPDPorc[0];
               Z269LetPTipCod = T003B3_A269LetPTipCod[0];
            }
            else
            {
               Z1146LetPTipo = A1146LetPTipo;
               Z1131LetPDocNum = A1131LetPDocNum;
               Z1130LetPDias = A1130LetPDias;
               Z1134LetPFecLet = A1134LetPFecLet;
               Z1135LetPFecVcto = A1135LetPFecVcto;
               Z1137LetPGirador = A1137LetPGirador;
               Z1141LetPLugar = A1141LetPLugar;
               Z1138LetPImpDet = A1138LetPImpDet;
               Z1127LetPBanCod = A1127LetPBanCod;
               Z1129LetPCBCod = A1129LetPCBCod;
               Z1142LetPSec = A1142LetPSec;
               Z1128LetPBanNum = A1128LetPBanNum;
               Z1133LetPDPrvCod = A1133LetPDPrvCod;
               Z1132LetPDPorc = A1132LetPDPorc;
               Z269LetPTipCod = A269LetPTipCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z268LetPItem = A268LetPItem;
            Z1146LetPTipo = A1146LetPTipo;
            Z1131LetPDocNum = A1131LetPDocNum;
            Z1130LetPDias = A1130LetPDias;
            Z1134LetPFecLet = A1134LetPFecLet;
            Z1135LetPFecVcto = A1135LetPFecVcto;
            Z1137LetPGirador = A1137LetPGirador;
            Z1141LetPLugar = A1141LetPLugar;
            Z1138LetPImpDet = A1138LetPImpDet;
            Z1127LetPBanCod = A1127LetPBanCod;
            Z1129LetPCBCod = A1129LetPCBCod;
            Z1142LetPSec = A1142LetPSec;
            Z1128LetPBanNum = A1128LetPBanNum;
            Z1133LetPDPrvCod = A1133LetPDPrvCod;
            Z1132LetPDPorc = A1132LetPDPorc;
            Z265LetPLetCod = A265LetPLetCod;
            Z269LetPTipCod = A269LetPTipCod;
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

      protected void Load3B114( )
      {
         /* Using cursor T003B6 */
         pr_default.execute(4, new Object[] {A265LetPLetCod, A268LetPItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound114 = 1;
            A1146LetPTipo = T003B6_A1146LetPTipo[0];
            AssignAttri("", false, "A1146LetPTipo", A1146LetPTipo);
            A1131LetPDocNum = T003B6_A1131LetPDocNum[0];
            AssignAttri("", false, "A1131LetPDocNum", A1131LetPDocNum);
            A1130LetPDias = T003B6_A1130LetPDias[0];
            AssignAttri("", false, "A1130LetPDias", StringUtil.LTrimStr( (decimal)(A1130LetPDias), 4, 0));
            A1134LetPFecLet = T003B6_A1134LetPFecLet[0];
            AssignAttri("", false, "A1134LetPFecLet", context.localUtil.Format(A1134LetPFecLet, "99/99/99"));
            A1135LetPFecVcto = T003B6_A1135LetPFecVcto[0];
            AssignAttri("", false, "A1135LetPFecVcto", context.localUtil.Format(A1135LetPFecVcto, "99/99/99"));
            A1137LetPGirador = T003B6_A1137LetPGirador[0];
            AssignAttri("", false, "A1137LetPGirador", A1137LetPGirador);
            A1141LetPLugar = T003B6_A1141LetPLugar[0];
            AssignAttri("", false, "A1141LetPLugar", A1141LetPLugar);
            A1138LetPImpDet = T003B6_A1138LetPImpDet[0];
            AssignAttri("", false, "A1138LetPImpDet", StringUtil.LTrimStr( A1138LetPImpDet, 15, 2));
            A1127LetPBanCod = T003B6_A1127LetPBanCod[0];
            AssignAttri("", false, "A1127LetPBanCod", StringUtil.LTrimStr( (decimal)(A1127LetPBanCod), 6, 0));
            A1129LetPCBCod = T003B6_A1129LetPCBCod[0];
            AssignAttri("", false, "A1129LetPCBCod", A1129LetPCBCod);
            A1142LetPSec = T003B6_A1142LetPSec[0];
            AssignAttri("", false, "A1142LetPSec", StringUtil.LTrimStr( (decimal)(A1142LetPSec), 6, 0));
            A1128LetPBanNum = T003B6_A1128LetPBanNum[0];
            AssignAttri("", false, "A1128LetPBanNum", A1128LetPBanNum);
            A1133LetPDPrvCod = T003B6_A1133LetPDPrvCod[0];
            AssignAttri("", false, "A1133LetPDPrvCod", A1133LetPDPrvCod);
            A1132LetPDPorc = T003B6_A1132LetPDPorc[0];
            AssignAttri("", false, "A1132LetPDPorc", StringUtil.LTrimStr( A1132LetPDPorc, 18, 8));
            A269LetPTipCod = T003B6_A269LetPTipCod[0];
            AssignAttri("", false, "A269LetPTipCod", A269LetPTipCod);
            ZM3B114( -3) ;
         }
         pr_default.close(4);
         OnLoadActions3B114( ) ;
      }

      protected void OnLoadActions3B114( )
      {
      }

      protected void CheckExtendedTable3B114( )
      {
         nIsDirty_114 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003B4 */
         pr_default.execute(2, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Letras'.", "ForeignKeyNotFound", 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T003B5 */
         pr_default.execute(3, new Object[] {A269LetPTipCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "LETPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1134LetPFecLet) || ( DateTimeUtil.ResetTime ( A1134LetPFecLet ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "LETPFECLET");
            AnyError = 1;
            GX_FocusControl = edtLetPFecLet_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1135LetPFecVcto) || ( DateTimeUtil.ResetTime ( A1135LetPFecVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "LETPFECVCTO");
            AnyError = 1;
            GX_FocusControl = edtLetPFecVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3B114( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A265LetPLetCod )
      {
         /* Using cursor T003B7 */
         pr_default.execute(5, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Letras'.", "ForeignKeyNotFound", 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
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

      protected void gxLoad_5( string A269LetPTipCod )
      {
         /* Using cursor T003B8 */
         pr_default.execute(6, new Object[] {A269LetPTipCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "LETPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPTipCod_Internalname;
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

      protected void GetKey3B114( )
      {
         /* Using cursor T003B9 */
         pr_default.execute(7, new Object[] {A265LetPLetCod, A268LetPItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound114 = 1;
         }
         else
         {
            RcdFound114 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003B3 */
         pr_default.execute(1, new Object[] {A265LetPLetCod, A268LetPItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3B114( 3) ;
            RcdFound114 = 1;
            A268LetPItem = T003B3_A268LetPItem[0];
            AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
            A1146LetPTipo = T003B3_A1146LetPTipo[0];
            AssignAttri("", false, "A1146LetPTipo", A1146LetPTipo);
            A1131LetPDocNum = T003B3_A1131LetPDocNum[0];
            AssignAttri("", false, "A1131LetPDocNum", A1131LetPDocNum);
            A1130LetPDias = T003B3_A1130LetPDias[0];
            AssignAttri("", false, "A1130LetPDias", StringUtil.LTrimStr( (decimal)(A1130LetPDias), 4, 0));
            A1134LetPFecLet = T003B3_A1134LetPFecLet[0];
            AssignAttri("", false, "A1134LetPFecLet", context.localUtil.Format(A1134LetPFecLet, "99/99/99"));
            A1135LetPFecVcto = T003B3_A1135LetPFecVcto[0];
            AssignAttri("", false, "A1135LetPFecVcto", context.localUtil.Format(A1135LetPFecVcto, "99/99/99"));
            A1137LetPGirador = T003B3_A1137LetPGirador[0];
            AssignAttri("", false, "A1137LetPGirador", A1137LetPGirador);
            A1141LetPLugar = T003B3_A1141LetPLugar[0];
            AssignAttri("", false, "A1141LetPLugar", A1141LetPLugar);
            A1138LetPImpDet = T003B3_A1138LetPImpDet[0];
            AssignAttri("", false, "A1138LetPImpDet", StringUtil.LTrimStr( A1138LetPImpDet, 15, 2));
            A1127LetPBanCod = T003B3_A1127LetPBanCod[0];
            AssignAttri("", false, "A1127LetPBanCod", StringUtil.LTrimStr( (decimal)(A1127LetPBanCod), 6, 0));
            A1129LetPCBCod = T003B3_A1129LetPCBCod[0];
            AssignAttri("", false, "A1129LetPCBCod", A1129LetPCBCod);
            A1142LetPSec = T003B3_A1142LetPSec[0];
            AssignAttri("", false, "A1142LetPSec", StringUtil.LTrimStr( (decimal)(A1142LetPSec), 6, 0));
            A1128LetPBanNum = T003B3_A1128LetPBanNum[0];
            AssignAttri("", false, "A1128LetPBanNum", A1128LetPBanNum);
            A1133LetPDPrvCod = T003B3_A1133LetPDPrvCod[0];
            AssignAttri("", false, "A1133LetPDPrvCod", A1133LetPDPrvCod);
            A1132LetPDPorc = T003B3_A1132LetPDPorc[0];
            AssignAttri("", false, "A1132LetPDPorc", StringUtil.LTrimStr( A1132LetPDPorc, 18, 8));
            A265LetPLetCod = T003B3_A265LetPLetCod[0];
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            A269LetPTipCod = T003B3_A269LetPTipCod[0];
            AssignAttri("", false, "A269LetPTipCod", A269LetPTipCod);
            Z265LetPLetCod = A265LetPLetCod;
            Z268LetPItem = A268LetPItem;
            sMode114 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3B114( ) ;
            if ( AnyError == 1 )
            {
               RcdFound114 = 0;
               InitializeNonKey3B114( ) ;
            }
            Gx_mode = sMode114;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound114 = 0;
            InitializeNonKey3B114( ) ;
            sMode114 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode114;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3B114( ) ;
         if ( RcdFound114 == 0 )
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
         RcdFound114 = 0;
         /* Using cursor T003B10 */
         pr_default.execute(8, new Object[] {A265LetPLetCod, A268LetPItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003B10_A265LetPLetCod[0], A265LetPLetCod) < 0 ) || ( StringUtil.StrCmp(T003B10_A265LetPLetCod[0], A265LetPLetCod) == 0 ) && ( T003B10_A268LetPItem[0] < A268LetPItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003B10_A265LetPLetCod[0], A265LetPLetCod) > 0 ) || ( StringUtil.StrCmp(T003B10_A265LetPLetCod[0], A265LetPLetCod) == 0 ) && ( T003B10_A268LetPItem[0] > A268LetPItem ) ) )
            {
               A265LetPLetCod = T003B10_A265LetPLetCod[0];
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
               A268LetPItem = T003B10_A268LetPItem[0];
               AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
               RcdFound114 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound114 = 0;
         /* Using cursor T003B11 */
         pr_default.execute(9, new Object[] {A265LetPLetCod, A268LetPItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003B11_A265LetPLetCod[0], A265LetPLetCod) > 0 ) || ( StringUtil.StrCmp(T003B11_A265LetPLetCod[0], A265LetPLetCod) == 0 ) && ( T003B11_A268LetPItem[0] > A268LetPItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003B11_A265LetPLetCod[0], A265LetPLetCod) < 0 ) || ( StringUtil.StrCmp(T003B11_A265LetPLetCod[0], A265LetPLetCod) == 0 ) && ( T003B11_A268LetPItem[0] < A268LetPItem ) ) )
            {
               A265LetPLetCod = T003B11_A265LetPLetCod[0];
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
               A268LetPItem = T003B11_A268LetPItem[0];
               AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
               RcdFound114 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3B114( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3B114( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound114 == 1 )
            {
               if ( ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 ) || ( A268LetPItem != Z268LetPItem ) )
               {
                  A265LetPLetCod = Z265LetPLetCod;
                  AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
                  A268LetPItem = Z268LetPItem;
                  AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
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
                  Update3B114( ) ;
                  GX_FocusControl = edtLetPLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 ) || ( A268LetPItem != Z268LetPItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLetPLetCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3B114( ) ;
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
                     Insert3B114( ) ;
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
         if ( ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 ) || ( A268LetPItem != Z268LetPItem ) )
         {
            A265LetPLetCod = Z265LetPLetCod;
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            A268LetPItem = Z268LetPItem;
            AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
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
         GetKey3B114( ) ;
         if ( RcdFound114 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LETPLETCOD");
               AnyError = 1;
               GX_FocusControl = edtLetPLetCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 ) || ( A268LetPItem != Z268LetPItem ) )
            {
               A265LetPLetCod = Z265LetPLetCod;
               AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
               A268LetPItem = Z268LetPItem;
               AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
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
            if ( ( StringUtil.StrCmp(A265LetPLetCod, Z265LetPLetCod) != 0 ) || ( A268LetPItem != Z268LetPItem ) )
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
         context.RollbackDataStores("cpletrasdet",pr_default);
         GX_FocusControl = edtLetPTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3B0( ) ;
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
         if ( RcdFound114 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLetPTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3B114( ) ;
         if ( RcdFound114 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3B114( ) ;
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
         if ( RcdFound114 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPTipo_Internalname;
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
         if ( RcdFound114 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPTipo_Internalname;
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
         ScanStart3B114( ) ;
         if ( RcdFound114 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound114 != 0 )
            {
               ScanNext3B114( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLetPTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3B114( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3B114( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003B2 */
            pr_default.execute(0, new Object[] {A265LetPLetCod, A268LetPItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLETRASDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1146LetPTipo, T003B2_A1146LetPTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z1131LetPDocNum, T003B2_A1131LetPDocNum[0]) != 0 ) || ( Z1130LetPDias != T003B2_A1130LetPDias[0] ) || ( DateTimeUtil.ResetTime ( Z1134LetPFecLet ) != DateTimeUtil.ResetTime ( T003B2_A1134LetPFecLet[0] ) ) || ( DateTimeUtil.ResetTime ( Z1135LetPFecVcto ) != DateTimeUtil.ResetTime ( T003B2_A1135LetPFecVcto[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1137LetPGirador, T003B2_A1137LetPGirador[0]) != 0 ) || ( StringUtil.StrCmp(Z1141LetPLugar, T003B2_A1141LetPLugar[0]) != 0 ) || ( Z1138LetPImpDet != T003B2_A1138LetPImpDet[0] ) || ( Z1127LetPBanCod != T003B2_A1127LetPBanCod[0] ) || ( StringUtil.StrCmp(Z1129LetPCBCod, T003B2_A1129LetPCBCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1142LetPSec != T003B2_A1142LetPSec[0] ) || ( StringUtil.StrCmp(Z1128LetPBanNum, T003B2_A1128LetPBanNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1133LetPDPrvCod, T003B2_A1133LetPDPrvCod[0]) != 0 ) || ( Z1132LetPDPorc != T003B2_A1132LetPDPorc[0] ) || ( StringUtil.StrCmp(Z269LetPTipCod, T003B2_A269LetPTipCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1146LetPTipo, T003B2_A1146LetPTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1146LetPTipo);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1146LetPTipo[0]);
               }
               if ( StringUtil.StrCmp(Z1131LetPDocNum, T003B2_A1131LetPDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z1131LetPDocNum);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1131LetPDocNum[0]);
               }
               if ( Z1130LetPDias != T003B2_A1130LetPDias[0] )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPDias");
                  GXUtil.WriteLogRaw("Old: ",Z1130LetPDias);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1130LetPDias[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1134LetPFecLet ) != DateTimeUtil.ResetTime ( T003B2_A1134LetPFecLet[0] ) )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPFecLet");
                  GXUtil.WriteLogRaw("Old: ",Z1134LetPFecLet);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1134LetPFecLet[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1135LetPFecVcto ) != DateTimeUtil.ResetTime ( T003B2_A1135LetPFecVcto[0] ) )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPFecVcto");
                  GXUtil.WriteLogRaw("Old: ",Z1135LetPFecVcto);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1135LetPFecVcto[0]);
               }
               if ( StringUtil.StrCmp(Z1137LetPGirador, T003B2_A1137LetPGirador[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPGirador");
                  GXUtil.WriteLogRaw("Old: ",Z1137LetPGirador);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1137LetPGirador[0]);
               }
               if ( StringUtil.StrCmp(Z1141LetPLugar, T003B2_A1141LetPLugar[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPLugar");
                  GXUtil.WriteLogRaw("Old: ",Z1141LetPLugar);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1141LetPLugar[0]);
               }
               if ( Z1138LetPImpDet != T003B2_A1138LetPImpDet[0] )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPImpDet");
                  GXUtil.WriteLogRaw("Old: ",Z1138LetPImpDet);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1138LetPImpDet[0]);
               }
               if ( Z1127LetPBanCod != T003B2_A1127LetPBanCod[0] )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z1127LetPBanCod);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1127LetPBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z1129LetPCBCod, T003B2_A1129LetPCBCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPCBCod");
                  GXUtil.WriteLogRaw("Old: ",Z1129LetPCBCod);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1129LetPCBCod[0]);
               }
               if ( Z1142LetPSec != T003B2_A1142LetPSec[0] )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPSec");
                  GXUtil.WriteLogRaw("Old: ",Z1142LetPSec);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1142LetPSec[0]);
               }
               if ( StringUtil.StrCmp(Z1128LetPBanNum, T003B2_A1128LetPBanNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPBanNum");
                  GXUtil.WriteLogRaw("Old: ",Z1128LetPBanNum);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1128LetPBanNum[0]);
               }
               if ( StringUtil.StrCmp(Z1133LetPDPrvCod, T003B2_A1133LetPDPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPDPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z1133LetPDPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1133LetPDPrvCod[0]);
               }
               if ( Z1132LetPDPorc != T003B2_A1132LetPDPorc[0] )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPDPorc");
                  GXUtil.WriteLogRaw("Old: ",Z1132LetPDPorc);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A1132LetPDPorc[0]);
               }
               if ( StringUtil.StrCmp(Z269LetPTipCod, T003B2_A269LetPTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpletrasdet:[seudo value changed for attri]"+"LetPTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z269LetPTipCod);
                  GXUtil.WriteLogRaw("Current: ",T003B2_A269LetPTipCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLETRASDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3B114( )
      {
         BeforeValidate3B114( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3B114( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3B114( 0) ;
            CheckOptimisticConcurrency3B114( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3B114( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3B114( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003B12 */
                     pr_default.execute(10, new Object[] {A268LetPItem, A1146LetPTipo, A1131LetPDocNum, A1130LetPDias, A1134LetPFecLet, A1135LetPFecVcto, A1137LetPGirador, A1141LetPLugar, A1138LetPImpDet, A1127LetPBanCod, A1129LetPCBCod, A1142LetPSec, A1128LetPBanNum, A1133LetPDPrvCod, A1132LetPDPorc, A265LetPLetCod, A269LetPTipCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLETRASDET");
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
                           ResetCaption3B0( ) ;
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
               Load3B114( ) ;
            }
            EndLevel3B114( ) ;
         }
         CloseExtendedTableCursors3B114( ) ;
      }

      protected void Update3B114( )
      {
         BeforeValidate3B114( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3B114( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3B114( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3B114( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3B114( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003B13 */
                     pr_default.execute(11, new Object[] {A1146LetPTipo, A1131LetPDocNum, A1130LetPDias, A1134LetPFecLet, A1135LetPFecVcto, A1137LetPGirador, A1141LetPLugar, A1138LetPImpDet, A1127LetPBanCod, A1129LetPCBCod, A1142LetPSec, A1128LetPBanNum, A1133LetPDPrvCod, A1132LetPDPorc, A269LetPTipCod, A265LetPLetCod, A268LetPItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLETRASDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLETRASDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3B114( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3B0( ) ;
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
            EndLevel3B114( ) ;
         }
         CloseExtendedTableCursors3B114( ) ;
      }

      protected void DeferredUpdate3B114( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3B114( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3B114( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3B114( ) ;
            AfterConfirm3B114( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3B114( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003B14 */
                  pr_default.execute(12, new Object[] {A265LetPLetCod, A268LetPItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLETRASDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound114 == 0 )
                        {
                           InitAll3B114( ) ;
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
                        ResetCaption3B0( ) ;
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
         sMode114 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3B114( ) ;
         Gx_mode = sMode114;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3B114( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel3B114( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3B114( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpletrasdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpletrasdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3B114( )
      {
         /* Using cursor T003B15 */
         pr_default.execute(13);
         RcdFound114 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound114 = 1;
            A265LetPLetCod = T003B15_A265LetPLetCod[0];
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            A268LetPItem = T003B15_A268LetPItem[0];
            AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3B114( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound114 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound114 = 1;
            A265LetPLetCod = T003B15_A265LetPLetCod[0];
            AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
            A268LetPItem = T003B15_A268LetPItem[0];
            AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
         }
      }

      protected void ScanEnd3B114( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm3B114( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3B114( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3B114( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3B114( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3B114( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3B114( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3B114( )
      {
         edtLetPLetCod_Enabled = 0;
         AssignProp("", false, edtLetPLetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPLetCod_Enabled), 5, 0), true);
         edtLetPItem_Enabled = 0;
         AssignProp("", false, edtLetPItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPItem_Enabled), 5, 0), true);
         edtLetPTipo_Enabled = 0;
         AssignProp("", false, edtLetPTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPTipo_Enabled), 5, 0), true);
         edtLetPTipCod_Enabled = 0;
         AssignProp("", false, edtLetPTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPTipCod_Enabled), 5, 0), true);
         edtLetPDocNum_Enabled = 0;
         AssignProp("", false, edtLetPDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPDocNum_Enabled), 5, 0), true);
         edtLetPDias_Enabled = 0;
         AssignProp("", false, edtLetPDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPDias_Enabled), 5, 0), true);
         edtLetPFecLet_Enabled = 0;
         AssignProp("", false, edtLetPFecLet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPFecLet_Enabled), 5, 0), true);
         edtLetPFecVcto_Enabled = 0;
         AssignProp("", false, edtLetPFecVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPFecVcto_Enabled), 5, 0), true);
         edtLetPGirador_Enabled = 0;
         AssignProp("", false, edtLetPGirador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPGirador_Enabled), 5, 0), true);
         edtLetPLugar_Enabled = 0;
         AssignProp("", false, edtLetPLugar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPLugar_Enabled), 5, 0), true);
         edtLetPImpDet_Enabled = 0;
         AssignProp("", false, edtLetPImpDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPImpDet_Enabled), 5, 0), true);
         edtLetPBanCod_Enabled = 0;
         AssignProp("", false, edtLetPBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPBanCod_Enabled), 5, 0), true);
         edtLetPCBCod_Enabled = 0;
         AssignProp("", false, edtLetPCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPCBCod_Enabled), 5, 0), true);
         edtLetPSec_Enabled = 0;
         AssignProp("", false, edtLetPSec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPSec_Enabled), 5, 0), true);
         edtLetPBanNum_Enabled = 0;
         AssignProp("", false, edtLetPBanNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPBanNum_Enabled), 5, 0), true);
         edtLetPDPrvCod_Enabled = 0;
         AssignProp("", false, edtLetPDPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPDPrvCod_Enabled), 5, 0), true);
         edtLetPDPorc_Enabled = 0;
         AssignProp("", false, edtLetPDPorc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLetPDPorc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3B114( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025350", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpletrasdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z268LetPItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268LetPItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1146LetPTipo", StringUtil.RTrim( Z1146LetPTipo));
         GxWebStd.gx_hidden_field( context, "Z1131LetPDocNum", StringUtil.RTrim( Z1131LetPDocNum));
         GxWebStd.gx_hidden_field( context, "Z1130LetPDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1130LetPDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1134LetPFecLet", context.localUtil.DToC( Z1134LetPFecLet, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1135LetPFecVcto", context.localUtil.DToC( Z1135LetPFecVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1137LetPGirador", StringUtil.RTrim( Z1137LetPGirador));
         GxWebStd.gx_hidden_field( context, "Z1141LetPLugar", StringUtil.RTrim( Z1141LetPLugar));
         GxWebStd.gx_hidden_field( context, "Z1138LetPImpDet", StringUtil.LTrim( StringUtil.NToC( Z1138LetPImpDet, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1127LetPBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1127LetPBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1129LetPCBCod", StringUtil.RTrim( Z1129LetPCBCod));
         GxWebStd.gx_hidden_field( context, "Z1142LetPSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1142LetPSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1128LetPBanNum", StringUtil.RTrim( Z1128LetPBanNum));
         GxWebStd.gx_hidden_field( context, "Z1133LetPDPrvCod", StringUtil.RTrim( Z1133LetPDPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1132LetPDPorc", StringUtil.LTrim( StringUtil.NToC( Z1132LetPDPorc, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z269LetPTipCod", StringUtil.RTrim( Z269LetPTipCod));
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
         return formatLink("cpletrasdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLETRASDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Letras por Pagar - Cabecera" ;
      }

      protected void InitializeNonKey3B114( )
      {
         A1146LetPTipo = "";
         AssignAttri("", false, "A1146LetPTipo", A1146LetPTipo);
         A269LetPTipCod = "";
         AssignAttri("", false, "A269LetPTipCod", A269LetPTipCod);
         A1131LetPDocNum = "";
         AssignAttri("", false, "A1131LetPDocNum", A1131LetPDocNum);
         A1130LetPDias = 0;
         AssignAttri("", false, "A1130LetPDias", StringUtil.LTrimStr( (decimal)(A1130LetPDias), 4, 0));
         A1134LetPFecLet = DateTime.MinValue;
         AssignAttri("", false, "A1134LetPFecLet", context.localUtil.Format(A1134LetPFecLet, "99/99/99"));
         A1135LetPFecVcto = DateTime.MinValue;
         AssignAttri("", false, "A1135LetPFecVcto", context.localUtil.Format(A1135LetPFecVcto, "99/99/99"));
         A1137LetPGirador = "";
         AssignAttri("", false, "A1137LetPGirador", A1137LetPGirador);
         A1141LetPLugar = "";
         AssignAttri("", false, "A1141LetPLugar", A1141LetPLugar);
         A1138LetPImpDet = 0;
         AssignAttri("", false, "A1138LetPImpDet", StringUtil.LTrimStr( A1138LetPImpDet, 15, 2));
         A1127LetPBanCod = 0;
         AssignAttri("", false, "A1127LetPBanCod", StringUtil.LTrimStr( (decimal)(A1127LetPBanCod), 6, 0));
         A1129LetPCBCod = "";
         AssignAttri("", false, "A1129LetPCBCod", A1129LetPCBCod);
         A1142LetPSec = 0;
         AssignAttri("", false, "A1142LetPSec", StringUtil.LTrimStr( (decimal)(A1142LetPSec), 6, 0));
         A1128LetPBanNum = "";
         AssignAttri("", false, "A1128LetPBanNum", A1128LetPBanNum);
         A1133LetPDPrvCod = "";
         AssignAttri("", false, "A1133LetPDPrvCod", A1133LetPDPrvCod);
         A1132LetPDPorc = 0;
         AssignAttri("", false, "A1132LetPDPorc", StringUtil.LTrimStr( A1132LetPDPorc, 18, 8));
         Z1146LetPTipo = "";
         Z1131LetPDocNum = "";
         Z1130LetPDias = 0;
         Z1134LetPFecLet = DateTime.MinValue;
         Z1135LetPFecVcto = DateTime.MinValue;
         Z1137LetPGirador = "";
         Z1141LetPLugar = "";
         Z1138LetPImpDet = 0;
         Z1127LetPBanCod = 0;
         Z1129LetPCBCod = "";
         Z1142LetPSec = 0;
         Z1128LetPBanNum = "";
         Z1133LetPDPrvCod = "";
         Z1132LetPDPorc = 0;
         Z269LetPTipCod = "";
      }

      protected void InitAll3B114( )
      {
         A265LetPLetCod = "";
         AssignAttri("", false, "A265LetPLetCod", A265LetPLetCod);
         A268LetPItem = 0;
         AssignAttri("", false, "A268LetPItem", StringUtil.LTrimStr( (decimal)(A268LetPItem), 6, 0));
         InitializeNonKey3B114( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025363", true, true);
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
         context.AddJavascriptSource("cpletrasdet.js", "?20228181025364", false, true);
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
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLetPItem_Internalname = "LETPITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLetPTipo_Internalname = "LETPTIPO";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLetPTipCod_Internalname = "LETPTIPCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLetPDocNum_Internalname = "LETPDOCNUM";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLetPDias_Internalname = "LETPDIAS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLetPFecLet_Internalname = "LETPFECLET";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtLetPFecVcto_Internalname = "LETPFECVCTO";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLetPGirador_Internalname = "LETPGIRADOR";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtLetPLugar_Internalname = "LETPLUGAR";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtLetPImpDet_Internalname = "LETPIMPDET";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtLetPBanCod_Internalname = "LETPBANCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtLetPCBCod_Internalname = "LETPCBCOD";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtLetPSec_Internalname = "LETPSEC";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtLetPBanNum_Internalname = "LETPBANNUM";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtLetPDPrvCod_Internalname = "LETPDPRVCOD";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtLetPDPorc_Internalname = "LETPDPORC";
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
         edtLetPDPorc_Jsonclick = "";
         edtLetPDPorc_Enabled = 1;
         edtLetPDPrvCod_Jsonclick = "";
         edtLetPDPrvCod_Enabled = 1;
         edtLetPBanNum_Jsonclick = "";
         edtLetPBanNum_Enabled = 1;
         edtLetPSec_Jsonclick = "";
         edtLetPSec_Enabled = 1;
         edtLetPCBCod_Jsonclick = "";
         edtLetPCBCod_Enabled = 1;
         edtLetPBanCod_Jsonclick = "";
         edtLetPBanCod_Enabled = 1;
         edtLetPImpDet_Jsonclick = "";
         edtLetPImpDet_Enabled = 1;
         edtLetPLugar_Jsonclick = "";
         edtLetPLugar_Enabled = 1;
         edtLetPGirador_Jsonclick = "";
         edtLetPGirador_Enabled = 1;
         edtLetPFecVcto_Jsonclick = "";
         edtLetPFecVcto_Enabled = 1;
         edtLetPFecLet_Jsonclick = "";
         edtLetPFecLet_Enabled = 1;
         edtLetPDias_Jsonclick = "";
         edtLetPDias_Enabled = 1;
         edtLetPDocNum_Jsonclick = "";
         edtLetPDocNum_Enabled = 1;
         edtLetPTipCod_Jsonclick = "";
         edtLetPTipCod_Enabled = 1;
         edtLetPTipo_Jsonclick = "";
         edtLetPTipo_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLetPItem_Jsonclick = "";
         edtLetPItem_Enabled = 1;
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
         /* Using cursor T003B16 */
         pr_default.execute(14, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Letras'.", "ForeignKeyNotFound", 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtLetPTipo_Internalname;
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
         /* Using cursor T003B16 */
         pr_default.execute(14, new Object[] {A265LetPLetCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera de Letras'.", "ForeignKeyNotFound", 1, "LETPLETCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPLetCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Letpitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1146LetPTipo", StringUtil.RTrim( A1146LetPTipo));
         AssignAttri("", false, "A269LetPTipCod", StringUtil.RTrim( A269LetPTipCod));
         AssignAttri("", false, "A1131LetPDocNum", StringUtil.RTrim( A1131LetPDocNum));
         AssignAttri("", false, "A1130LetPDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1130LetPDias), 4, 0, ".", "")));
         AssignAttri("", false, "A1134LetPFecLet", context.localUtil.Format(A1134LetPFecLet, "99/99/99"));
         AssignAttri("", false, "A1135LetPFecVcto", context.localUtil.Format(A1135LetPFecVcto, "99/99/99"));
         AssignAttri("", false, "A1137LetPGirador", StringUtil.RTrim( A1137LetPGirador));
         AssignAttri("", false, "A1141LetPLugar", StringUtil.RTrim( A1141LetPLugar));
         AssignAttri("", false, "A1138LetPImpDet", StringUtil.LTrim( StringUtil.NToC( A1138LetPImpDet, 15, 2, ".", "")));
         AssignAttri("", false, "A1127LetPBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1127LetPBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1129LetPCBCod", StringUtil.RTrim( A1129LetPCBCod));
         AssignAttri("", false, "A1142LetPSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1142LetPSec), 6, 0, ".", "")));
         AssignAttri("", false, "A1128LetPBanNum", StringUtil.RTrim( A1128LetPBanNum));
         AssignAttri("", false, "A1133LetPDPrvCod", StringUtil.RTrim( A1133LetPDPrvCod));
         AssignAttri("", false, "A1132LetPDPorc", StringUtil.LTrim( StringUtil.NToC( A1132LetPDPorc, 18, 8, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z265LetPLetCod", StringUtil.RTrim( Z265LetPLetCod));
         GxWebStd.gx_hidden_field( context, "Z268LetPItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268LetPItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1146LetPTipo", StringUtil.RTrim( Z1146LetPTipo));
         GxWebStd.gx_hidden_field( context, "Z269LetPTipCod", StringUtil.RTrim( Z269LetPTipCod));
         GxWebStd.gx_hidden_field( context, "Z1131LetPDocNum", StringUtil.RTrim( Z1131LetPDocNum));
         GxWebStd.gx_hidden_field( context, "Z1130LetPDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1130LetPDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1134LetPFecLet", context.localUtil.Format(Z1134LetPFecLet, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1135LetPFecVcto", context.localUtil.Format(Z1135LetPFecVcto, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1137LetPGirador", StringUtil.RTrim( Z1137LetPGirador));
         GxWebStd.gx_hidden_field( context, "Z1141LetPLugar", StringUtil.RTrim( Z1141LetPLugar));
         GxWebStd.gx_hidden_field( context, "Z1138LetPImpDet", StringUtil.LTrim( StringUtil.NToC( Z1138LetPImpDet, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1127LetPBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1127LetPBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1129LetPCBCod", StringUtil.RTrim( Z1129LetPCBCod));
         GxWebStd.gx_hidden_field( context, "Z1142LetPSec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1142LetPSec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1128LetPBanNum", StringUtil.RTrim( Z1128LetPBanNum));
         GxWebStd.gx_hidden_field( context, "Z1133LetPDPrvCod", StringUtil.RTrim( Z1133LetPDPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1132LetPDPorc", StringUtil.LTrim( StringUtil.NToC( Z1132LetPDPorc, 18, 8, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Letptipcod( )
      {
         /* Using cursor T003B17 */
         pr_default.execute(15, new Object[] {A269LetPTipCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "LETPTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtLetPTipCod_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_LETPLETCOD","{handler:'Valid_Letpletcod',iparms:[{av:'A265LetPLetCod',fld:'LETPLETCOD',pic:''}]");
         setEventMetadata("VALID_LETPLETCOD",",oparms:[]}");
         setEventMetadata("VALID_LETPITEM","{handler:'Valid_Letpitem',iparms:[{av:'A265LetPLetCod',fld:'LETPLETCOD',pic:''},{av:'A268LetPItem',fld:'LETPITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LETPITEM",",oparms:[{av:'A1146LetPTipo',fld:'LETPTIPO',pic:''},{av:'A269LetPTipCod',fld:'LETPTIPCOD',pic:''},{av:'A1131LetPDocNum',fld:'LETPDOCNUM',pic:''},{av:'A1130LetPDias',fld:'LETPDIAS',pic:'ZZZ9'},{av:'A1134LetPFecLet',fld:'LETPFECLET',pic:''},{av:'A1135LetPFecVcto',fld:'LETPFECVCTO',pic:''},{av:'A1137LetPGirador',fld:'LETPGIRADOR',pic:''},{av:'A1141LetPLugar',fld:'LETPLUGAR',pic:''},{av:'A1138LetPImpDet',fld:'LETPIMPDET',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1127LetPBanCod',fld:'LETPBANCOD',pic:'ZZZZZ9'},{av:'A1129LetPCBCod',fld:'LETPCBCOD',pic:''},{av:'A1142LetPSec',fld:'LETPSEC',pic:'ZZZZZ9'},{av:'A1128LetPBanNum',fld:'LETPBANNUM',pic:''},{av:'A1133LetPDPrvCod',fld:'LETPDPRVCOD',pic:''},{av:'A1132LetPDPorc',fld:'LETPDPORC',pic:'ZZZ,ZZZ,ZZ9.99999999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z265LetPLetCod'},{av:'Z268LetPItem'},{av:'Z1146LetPTipo'},{av:'Z269LetPTipCod'},{av:'Z1131LetPDocNum'},{av:'Z1130LetPDias'},{av:'Z1134LetPFecLet'},{av:'Z1135LetPFecVcto'},{av:'Z1137LetPGirador'},{av:'Z1141LetPLugar'},{av:'Z1138LetPImpDet'},{av:'Z1127LetPBanCod'},{av:'Z1129LetPCBCod'},{av:'Z1142LetPSec'},{av:'Z1128LetPBanNum'},{av:'Z1133LetPDPrvCod'},{av:'Z1132LetPDPorc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_LETPTIPCOD","{handler:'Valid_Letptipcod',iparms:[{av:'A269LetPTipCod',fld:'LETPTIPCOD',pic:''}]");
         setEventMetadata("VALID_LETPTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_LETPFECLET","{handler:'Valid_Letpfeclet',iparms:[]");
         setEventMetadata("VALID_LETPFECLET",",oparms:[]}");
         setEventMetadata("VALID_LETPFECVCTO","{handler:'Valid_Letpfecvcto',iparms:[]");
         setEventMetadata("VALID_LETPFECVCTO",",oparms:[]}");
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
         Z265LetPLetCod = "";
         Z1146LetPTipo = "";
         Z1131LetPDocNum = "";
         Z1134LetPFecLet = DateTime.MinValue;
         Z1135LetPFecVcto = DateTime.MinValue;
         Z1137LetPGirador = "";
         Z1141LetPLugar = "";
         Z1129LetPCBCod = "";
         Z1128LetPBanNum = "";
         Z1133LetPDPrvCod = "";
         Z269LetPTipCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A265LetPLetCod = "";
         A269LetPTipCod = "";
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
         A1146LetPTipo = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A1131LetPDocNum = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1134LetPFecLet = DateTime.MinValue;
         lblTextblock8_Jsonclick = "";
         A1135LetPFecVcto = DateTime.MinValue;
         lblTextblock9_Jsonclick = "";
         A1137LetPGirador = "";
         lblTextblock10_Jsonclick = "";
         A1141LetPLugar = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A1129LetPCBCod = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1128LetPBanNum = "";
         lblTextblock16_Jsonclick = "";
         A1133LetPDPrvCod = "";
         lblTextblock17_Jsonclick = "";
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
         T003B6_A268LetPItem = new int[1] ;
         T003B6_A1146LetPTipo = new string[] {""} ;
         T003B6_A1131LetPDocNum = new string[] {""} ;
         T003B6_A1130LetPDias = new short[1] ;
         T003B6_A1134LetPFecLet = new DateTime[] {DateTime.MinValue} ;
         T003B6_A1135LetPFecVcto = new DateTime[] {DateTime.MinValue} ;
         T003B6_A1137LetPGirador = new string[] {""} ;
         T003B6_A1141LetPLugar = new string[] {""} ;
         T003B6_A1138LetPImpDet = new decimal[1] ;
         T003B6_A1127LetPBanCod = new int[1] ;
         T003B6_A1129LetPCBCod = new string[] {""} ;
         T003B6_A1142LetPSec = new int[1] ;
         T003B6_A1128LetPBanNum = new string[] {""} ;
         T003B6_A1133LetPDPrvCod = new string[] {""} ;
         T003B6_A1132LetPDPorc = new decimal[1] ;
         T003B6_A265LetPLetCod = new string[] {""} ;
         T003B6_A269LetPTipCod = new string[] {""} ;
         T003B4_A265LetPLetCod = new string[] {""} ;
         T003B5_A269LetPTipCod = new string[] {""} ;
         T003B7_A265LetPLetCod = new string[] {""} ;
         T003B8_A269LetPTipCod = new string[] {""} ;
         T003B9_A265LetPLetCod = new string[] {""} ;
         T003B9_A268LetPItem = new int[1] ;
         T003B3_A268LetPItem = new int[1] ;
         T003B3_A1146LetPTipo = new string[] {""} ;
         T003B3_A1131LetPDocNum = new string[] {""} ;
         T003B3_A1130LetPDias = new short[1] ;
         T003B3_A1134LetPFecLet = new DateTime[] {DateTime.MinValue} ;
         T003B3_A1135LetPFecVcto = new DateTime[] {DateTime.MinValue} ;
         T003B3_A1137LetPGirador = new string[] {""} ;
         T003B3_A1141LetPLugar = new string[] {""} ;
         T003B3_A1138LetPImpDet = new decimal[1] ;
         T003B3_A1127LetPBanCod = new int[1] ;
         T003B3_A1129LetPCBCod = new string[] {""} ;
         T003B3_A1142LetPSec = new int[1] ;
         T003B3_A1128LetPBanNum = new string[] {""} ;
         T003B3_A1133LetPDPrvCod = new string[] {""} ;
         T003B3_A1132LetPDPorc = new decimal[1] ;
         T003B3_A265LetPLetCod = new string[] {""} ;
         T003B3_A269LetPTipCod = new string[] {""} ;
         sMode114 = "";
         T003B10_A265LetPLetCod = new string[] {""} ;
         T003B10_A268LetPItem = new int[1] ;
         T003B11_A265LetPLetCod = new string[] {""} ;
         T003B11_A268LetPItem = new int[1] ;
         T003B2_A268LetPItem = new int[1] ;
         T003B2_A1146LetPTipo = new string[] {""} ;
         T003B2_A1131LetPDocNum = new string[] {""} ;
         T003B2_A1130LetPDias = new short[1] ;
         T003B2_A1134LetPFecLet = new DateTime[] {DateTime.MinValue} ;
         T003B2_A1135LetPFecVcto = new DateTime[] {DateTime.MinValue} ;
         T003B2_A1137LetPGirador = new string[] {""} ;
         T003B2_A1141LetPLugar = new string[] {""} ;
         T003B2_A1138LetPImpDet = new decimal[1] ;
         T003B2_A1127LetPBanCod = new int[1] ;
         T003B2_A1129LetPCBCod = new string[] {""} ;
         T003B2_A1142LetPSec = new int[1] ;
         T003B2_A1128LetPBanNum = new string[] {""} ;
         T003B2_A1133LetPDPrvCod = new string[] {""} ;
         T003B2_A1132LetPDPorc = new decimal[1] ;
         T003B2_A265LetPLetCod = new string[] {""} ;
         T003B2_A269LetPTipCod = new string[] {""} ;
         T003B15_A265LetPLetCod = new string[] {""} ;
         T003B15_A268LetPItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003B16_A265LetPLetCod = new string[] {""} ;
         ZZ265LetPLetCod = "";
         ZZ1146LetPTipo = "";
         ZZ269LetPTipCod = "";
         ZZ1131LetPDocNum = "";
         ZZ1134LetPFecLet = DateTime.MinValue;
         ZZ1135LetPFecVcto = DateTime.MinValue;
         ZZ1137LetPGirador = "";
         ZZ1141LetPLugar = "";
         ZZ1129LetPCBCod = "";
         ZZ1128LetPBanNum = "";
         ZZ1133LetPDPrvCod = "";
         T003B17_A269LetPTipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpletrasdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpletrasdet__default(),
            new Object[][] {
                new Object[] {
               T003B2_A268LetPItem, T003B2_A1146LetPTipo, T003B2_A1131LetPDocNum, T003B2_A1130LetPDias, T003B2_A1134LetPFecLet, T003B2_A1135LetPFecVcto, T003B2_A1137LetPGirador, T003B2_A1141LetPLugar, T003B2_A1138LetPImpDet, T003B2_A1127LetPBanCod,
               T003B2_A1129LetPCBCod, T003B2_A1142LetPSec, T003B2_A1128LetPBanNum, T003B2_A1133LetPDPrvCod, T003B2_A1132LetPDPorc, T003B2_A265LetPLetCod, T003B2_A269LetPTipCod
               }
               , new Object[] {
               T003B3_A268LetPItem, T003B3_A1146LetPTipo, T003B3_A1131LetPDocNum, T003B3_A1130LetPDias, T003B3_A1134LetPFecLet, T003B3_A1135LetPFecVcto, T003B3_A1137LetPGirador, T003B3_A1141LetPLugar, T003B3_A1138LetPImpDet, T003B3_A1127LetPBanCod,
               T003B3_A1129LetPCBCod, T003B3_A1142LetPSec, T003B3_A1128LetPBanNum, T003B3_A1133LetPDPrvCod, T003B3_A1132LetPDPorc, T003B3_A265LetPLetCod, T003B3_A269LetPTipCod
               }
               , new Object[] {
               T003B4_A265LetPLetCod
               }
               , new Object[] {
               T003B5_A269LetPTipCod
               }
               , new Object[] {
               T003B6_A268LetPItem, T003B6_A1146LetPTipo, T003B6_A1131LetPDocNum, T003B6_A1130LetPDias, T003B6_A1134LetPFecLet, T003B6_A1135LetPFecVcto, T003B6_A1137LetPGirador, T003B6_A1141LetPLugar, T003B6_A1138LetPImpDet, T003B6_A1127LetPBanCod,
               T003B6_A1129LetPCBCod, T003B6_A1142LetPSec, T003B6_A1128LetPBanNum, T003B6_A1133LetPDPrvCod, T003B6_A1132LetPDPorc, T003B6_A265LetPLetCod, T003B6_A269LetPTipCod
               }
               , new Object[] {
               T003B7_A265LetPLetCod
               }
               , new Object[] {
               T003B8_A269LetPTipCod
               }
               , new Object[] {
               T003B9_A265LetPLetCod, T003B9_A268LetPItem
               }
               , new Object[] {
               T003B10_A265LetPLetCod, T003B10_A268LetPItem
               }
               , new Object[] {
               T003B11_A265LetPLetCod, T003B11_A268LetPItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003B15_A265LetPLetCod, T003B15_A268LetPItem
               }
               , new Object[] {
               T003B16_A265LetPLetCod
               }
               , new Object[] {
               T003B17_A269LetPTipCod
               }
            }
         );
      }

      private short Z1130LetPDias ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1130LetPDias ;
      private short GX_JID ;
      private short RcdFound114 ;
      private short nIsDirty_114 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1130LetPDias ;
      private int Z268LetPItem ;
      private int Z1127LetPBanCod ;
      private int Z1142LetPSec ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLetPLetCod_Enabled ;
      private int A268LetPItem ;
      private int edtLetPItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLetPTipo_Enabled ;
      private int edtLetPTipCod_Enabled ;
      private int edtLetPDocNum_Enabled ;
      private int edtLetPDias_Enabled ;
      private int edtLetPFecLet_Enabled ;
      private int edtLetPFecVcto_Enabled ;
      private int edtLetPGirador_Enabled ;
      private int edtLetPLugar_Enabled ;
      private int edtLetPImpDet_Enabled ;
      private int A1127LetPBanCod ;
      private int edtLetPBanCod_Enabled ;
      private int edtLetPCBCod_Enabled ;
      private int A1142LetPSec ;
      private int edtLetPSec_Enabled ;
      private int edtLetPBanNum_Enabled ;
      private int edtLetPDPrvCod_Enabled ;
      private int edtLetPDPorc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ268LetPItem ;
      private int ZZ1127LetPBanCod ;
      private int ZZ1142LetPSec ;
      private decimal Z1138LetPImpDet ;
      private decimal Z1132LetPDPorc ;
      private decimal A1138LetPImpDet ;
      private decimal A1132LetPDPorc ;
      private decimal ZZ1138LetPImpDet ;
      private decimal ZZ1132LetPDPorc ;
      private string sPrefix ;
      private string Z265LetPLetCod ;
      private string Z1146LetPTipo ;
      private string Z1131LetPDocNum ;
      private string Z1137LetPGirador ;
      private string Z1141LetPLugar ;
      private string Z1129LetPCBCod ;
      private string Z1128LetPBanNum ;
      private string Z1133LetPDPrvCod ;
      private string Z269LetPTipCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A265LetPLetCod ;
      private string A269LetPTipCod ;
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
      private string edtLetPLetCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLetPItem_Internalname ;
      private string edtLetPItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLetPTipo_Internalname ;
      private string A1146LetPTipo ;
      private string edtLetPTipo_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLetPTipCod_Internalname ;
      private string edtLetPTipCod_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLetPDocNum_Internalname ;
      private string A1131LetPDocNum ;
      private string edtLetPDocNum_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLetPDias_Internalname ;
      private string edtLetPDias_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLetPFecLet_Internalname ;
      private string edtLetPFecLet_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtLetPFecVcto_Internalname ;
      private string edtLetPFecVcto_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLetPGirador_Internalname ;
      private string A1137LetPGirador ;
      private string edtLetPGirador_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtLetPLugar_Internalname ;
      private string A1141LetPLugar ;
      private string edtLetPLugar_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtLetPImpDet_Internalname ;
      private string edtLetPImpDet_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtLetPBanCod_Internalname ;
      private string edtLetPBanCod_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtLetPCBCod_Internalname ;
      private string A1129LetPCBCod ;
      private string edtLetPCBCod_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtLetPSec_Internalname ;
      private string edtLetPSec_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtLetPBanNum_Internalname ;
      private string A1128LetPBanNum ;
      private string edtLetPBanNum_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtLetPDPrvCod_Internalname ;
      private string A1133LetPDPrvCod ;
      private string edtLetPDPrvCod_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtLetPDPorc_Internalname ;
      private string edtLetPDPorc_Jsonclick ;
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
      private string sMode114 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ265LetPLetCod ;
      private string ZZ1146LetPTipo ;
      private string ZZ269LetPTipCod ;
      private string ZZ1131LetPDocNum ;
      private string ZZ1137LetPGirador ;
      private string ZZ1141LetPLugar ;
      private string ZZ1129LetPCBCod ;
      private string ZZ1128LetPBanNum ;
      private string ZZ1133LetPDPrvCod ;
      private DateTime Z1134LetPFecLet ;
      private DateTime Z1135LetPFecVcto ;
      private DateTime A1134LetPFecLet ;
      private DateTime A1135LetPFecVcto ;
      private DateTime ZZ1134LetPFecLet ;
      private DateTime ZZ1135LetPFecVcto ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T003B6_A268LetPItem ;
      private string[] T003B6_A1146LetPTipo ;
      private string[] T003B6_A1131LetPDocNum ;
      private short[] T003B6_A1130LetPDias ;
      private DateTime[] T003B6_A1134LetPFecLet ;
      private DateTime[] T003B6_A1135LetPFecVcto ;
      private string[] T003B6_A1137LetPGirador ;
      private string[] T003B6_A1141LetPLugar ;
      private decimal[] T003B6_A1138LetPImpDet ;
      private int[] T003B6_A1127LetPBanCod ;
      private string[] T003B6_A1129LetPCBCod ;
      private int[] T003B6_A1142LetPSec ;
      private string[] T003B6_A1128LetPBanNum ;
      private string[] T003B6_A1133LetPDPrvCod ;
      private decimal[] T003B6_A1132LetPDPorc ;
      private string[] T003B6_A265LetPLetCod ;
      private string[] T003B6_A269LetPTipCod ;
      private string[] T003B4_A265LetPLetCod ;
      private string[] T003B5_A269LetPTipCod ;
      private string[] T003B7_A265LetPLetCod ;
      private string[] T003B8_A269LetPTipCod ;
      private string[] T003B9_A265LetPLetCod ;
      private int[] T003B9_A268LetPItem ;
      private int[] T003B3_A268LetPItem ;
      private string[] T003B3_A1146LetPTipo ;
      private string[] T003B3_A1131LetPDocNum ;
      private short[] T003B3_A1130LetPDias ;
      private DateTime[] T003B3_A1134LetPFecLet ;
      private DateTime[] T003B3_A1135LetPFecVcto ;
      private string[] T003B3_A1137LetPGirador ;
      private string[] T003B3_A1141LetPLugar ;
      private decimal[] T003B3_A1138LetPImpDet ;
      private int[] T003B3_A1127LetPBanCod ;
      private string[] T003B3_A1129LetPCBCod ;
      private int[] T003B3_A1142LetPSec ;
      private string[] T003B3_A1128LetPBanNum ;
      private string[] T003B3_A1133LetPDPrvCod ;
      private decimal[] T003B3_A1132LetPDPorc ;
      private string[] T003B3_A265LetPLetCod ;
      private string[] T003B3_A269LetPTipCod ;
      private string[] T003B10_A265LetPLetCod ;
      private int[] T003B10_A268LetPItem ;
      private string[] T003B11_A265LetPLetCod ;
      private int[] T003B11_A268LetPItem ;
      private int[] T003B2_A268LetPItem ;
      private string[] T003B2_A1146LetPTipo ;
      private string[] T003B2_A1131LetPDocNum ;
      private short[] T003B2_A1130LetPDias ;
      private DateTime[] T003B2_A1134LetPFecLet ;
      private DateTime[] T003B2_A1135LetPFecVcto ;
      private string[] T003B2_A1137LetPGirador ;
      private string[] T003B2_A1141LetPLugar ;
      private decimal[] T003B2_A1138LetPImpDet ;
      private int[] T003B2_A1127LetPBanCod ;
      private string[] T003B2_A1129LetPCBCod ;
      private int[] T003B2_A1142LetPSec ;
      private string[] T003B2_A1128LetPBanNum ;
      private string[] T003B2_A1133LetPDPrvCod ;
      private decimal[] T003B2_A1132LetPDPorc ;
      private string[] T003B2_A265LetPLetCod ;
      private string[] T003B2_A269LetPTipCod ;
      private string[] T003B15_A265LetPLetCod ;
      private int[] T003B15_A268LetPItem ;
      private string[] T003B16_A265LetPLetCod ;
      private string[] T003B17_A269LetPTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpletrasdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpletrasdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003B6;
        prmT003B6 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B4;
        prmT003B4 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003B5;
        prmT003B5 = new Object[] {
        new ParDef("@LetPTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003B7;
        prmT003B7 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003B8;
        prmT003B8 = new Object[] {
        new ParDef("@LetPTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003B9;
        prmT003B9 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B3;
        prmT003B3 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B10;
        prmT003B10 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B11;
        prmT003B11 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B2;
        prmT003B2 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B12;
        prmT003B12 = new Object[] {
        new ParDef("@LetPItem",GXType.Int32,6,0) ,
        new ParDef("@LetPTipo",GXType.NChar,1,0) ,
        new ParDef("@LetPDocNum",GXType.NChar,15,0) ,
        new ParDef("@LetPDias",GXType.Int16,4,0) ,
        new ParDef("@LetPFecLet",GXType.Date,8,0) ,
        new ParDef("@LetPFecVcto",GXType.Date,8,0) ,
        new ParDef("@LetPGirador",GXType.NChar,100,0) ,
        new ParDef("@LetPLugar",GXType.NChar,100,0) ,
        new ParDef("@LetPImpDet",GXType.Decimal,15,2) ,
        new ParDef("@LetPBanCod",GXType.Int32,6,0) ,
        new ParDef("@LetPCBCod",GXType.NChar,20,0) ,
        new ParDef("@LetPSec",GXType.Int32,6,0) ,
        new ParDef("@LetPBanNum",GXType.NChar,20,0) ,
        new ParDef("@LetPDPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LetPDPorc",GXType.Decimal,18,8) ,
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003B13;
        prmT003B13 = new Object[] {
        new ParDef("@LetPTipo",GXType.NChar,1,0) ,
        new ParDef("@LetPDocNum",GXType.NChar,15,0) ,
        new ParDef("@LetPDias",GXType.Int16,4,0) ,
        new ParDef("@LetPFecLet",GXType.Date,8,0) ,
        new ParDef("@LetPFecVcto",GXType.Date,8,0) ,
        new ParDef("@LetPGirador",GXType.NChar,100,0) ,
        new ParDef("@LetPLugar",GXType.NChar,100,0) ,
        new ParDef("@LetPImpDet",GXType.Decimal,15,2) ,
        new ParDef("@LetPBanCod",GXType.Int32,6,0) ,
        new ParDef("@LetPCBCod",GXType.NChar,20,0) ,
        new ParDef("@LetPSec",GXType.Int32,6,0) ,
        new ParDef("@LetPBanNum",GXType.NChar,20,0) ,
        new ParDef("@LetPDPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LetPDPorc",GXType.Decimal,18,8) ,
        new ParDef("@LetPTipCod",GXType.NChar,3,0) ,
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B14;
        prmT003B14 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0) ,
        new ParDef("@LetPItem",GXType.Int32,6,0)
        };
        Object[] prmT003B15;
        prmT003B15 = new Object[] {
        };
        Object[] prmT003B16;
        prmT003B16 = new Object[] {
        new ParDef("@LetPLetCod",GXType.NChar,10,0)
        };
        Object[] prmT003B17;
        prmT003B17 = new Object[] {
        new ParDef("@LetPTipCod",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003B2", "SELECT [LetPItem], [LetPTipo], [LetPDocNum], [LetPDias], [LetPFecLet], [LetPFecVcto], [LetPGirador], [LetPLugar], [LetPImpDet], [LetPBanCod], [LetPCBCod], [LetPSec], [LetPBanNum], [LetPDPrvCod], [LetPDPorc], [LetPLetCod], [LetPTipCod] AS LetPTipCod FROM [CPLETRASDET] WITH (UPDLOCK) WHERE [LetPLetCod] = @LetPLetCod AND [LetPItem] = @LetPItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B3", "SELECT [LetPItem], [LetPTipo], [LetPDocNum], [LetPDias], [LetPFecLet], [LetPFecVcto], [LetPGirador], [LetPLugar], [LetPImpDet], [LetPBanCod], [LetPCBCod], [LetPSec], [LetPBanNum], [LetPDPrvCod], [LetPDPorc], [LetPLetCod], [LetPTipCod] AS LetPTipCod FROM [CPLETRASDET] WHERE [LetPLetCod] = @LetPLetCod AND [LetPItem] = @LetPItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B4", "SELECT [LetPLetCod] FROM [CPLETRAS] WHERE [LetPLetCod] = @LetPLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B5", "SELECT [TipCod] AS LetPTipCod FROM [CTIPDOC] WHERE [TipCod] = @LetPTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B6", "SELECT TM1.[LetPItem], TM1.[LetPTipo], TM1.[LetPDocNum], TM1.[LetPDias], TM1.[LetPFecLet], TM1.[LetPFecVcto], TM1.[LetPGirador], TM1.[LetPLugar], TM1.[LetPImpDet], TM1.[LetPBanCod], TM1.[LetPCBCod], TM1.[LetPSec], TM1.[LetPBanNum], TM1.[LetPDPrvCod], TM1.[LetPDPorc], TM1.[LetPLetCod], TM1.[LetPTipCod] AS LetPTipCod FROM [CPLETRASDET] TM1 WHERE TM1.[LetPLetCod] = @LetPLetCod and TM1.[LetPItem] = @LetPItem ORDER BY TM1.[LetPLetCod], TM1.[LetPItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003B6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B7", "SELECT [LetPLetCod] FROM [CPLETRAS] WHERE [LetPLetCod] = @LetPLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B8", "SELECT [TipCod] AS LetPTipCod FROM [CTIPDOC] WHERE [TipCod] = @LetPTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B9", "SELECT [LetPLetCod], [LetPItem] FROM [CPLETRASDET] WHERE [LetPLetCod] = @LetPLetCod AND [LetPItem] = @LetPItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B10", "SELECT TOP 1 [LetPLetCod], [LetPItem] FROM [CPLETRASDET] WHERE ( [LetPLetCod] > @LetPLetCod or [LetPLetCod] = @LetPLetCod and [LetPItem] > @LetPItem) ORDER BY [LetPLetCod], [LetPItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003B10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003B11", "SELECT TOP 1 [LetPLetCod], [LetPItem] FROM [CPLETRASDET] WHERE ( [LetPLetCod] < @LetPLetCod or [LetPLetCod] = @LetPLetCod and [LetPItem] < @LetPItem) ORDER BY [LetPLetCod] DESC, [LetPItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003B11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003B12", "INSERT INTO [CPLETRASDET]([LetPItem], [LetPTipo], [LetPDocNum], [LetPDias], [LetPFecLet], [LetPFecVcto], [LetPGirador], [LetPLugar], [LetPImpDet], [LetPBanCod], [LetPCBCod], [LetPSec], [LetPBanNum], [LetPDPrvCod], [LetPDPorc], [LetPLetCod], [LetPTipCod]) VALUES(@LetPItem, @LetPTipo, @LetPDocNum, @LetPDias, @LetPFecLet, @LetPFecVcto, @LetPGirador, @LetPLugar, @LetPImpDet, @LetPBanCod, @LetPCBCod, @LetPSec, @LetPBanNum, @LetPDPrvCod, @LetPDPorc, @LetPLetCod, @LetPTipCod)", GxErrorMask.GX_NOMASK,prmT003B12)
           ,new CursorDef("T003B13", "UPDATE [CPLETRASDET] SET [LetPTipo]=@LetPTipo, [LetPDocNum]=@LetPDocNum, [LetPDias]=@LetPDias, [LetPFecLet]=@LetPFecLet, [LetPFecVcto]=@LetPFecVcto, [LetPGirador]=@LetPGirador, [LetPLugar]=@LetPLugar, [LetPImpDet]=@LetPImpDet, [LetPBanCod]=@LetPBanCod, [LetPCBCod]=@LetPCBCod, [LetPSec]=@LetPSec, [LetPBanNum]=@LetPBanNum, [LetPDPrvCod]=@LetPDPrvCod, [LetPDPorc]=@LetPDPorc, [LetPTipCod]=@LetPTipCod  WHERE [LetPLetCod] = @LetPLetCod AND [LetPItem] = @LetPItem", GxErrorMask.GX_NOMASK,prmT003B13)
           ,new CursorDef("T003B14", "DELETE FROM [CPLETRASDET]  WHERE [LetPLetCod] = @LetPLetCod AND [LetPItem] = @LetPItem", GxErrorMask.GX_NOMASK,prmT003B14)
           ,new CursorDef("T003B15", "SELECT [LetPLetCod], [LetPItem] FROM [CPLETRASDET] ORDER BY [LetPLetCod], [LetPItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003B15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B16", "SELECT [LetPLetCod] FROM [CPLETRAS] WHERE [LetPLetCod] = @LetPLetCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003B17", "SELECT [TipCod] AS LetPTipCod FROM [CTIPDOC] WHERE [TipCod] = @LetPTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003B17,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((string[]) buf[16])[0] = rslt.getString(17, 3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((string[]) buf[16])[0] = rslt.getString(17, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 20);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((string[]) buf[13])[0] = rslt.getString(14, 20);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((string[]) buf[16])[0] = rslt.getString(17, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
